#region Using Statements
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using UnityEngine;
#endregion

namespace Delight
{
    /// <summary>
    /// Base class for views.
    /// </summary>
    public partial class View : DependencyObject, IInitialize
    {
        #region Fields

        public delegate void ViewAction(DependencyObject sender, object eventArgs);
        public delegate void LoadedEventHandler(object source);
        public event LoadedEventHandler Loaded;

        protected View _parent;
        protected View _layoutParent;
        protected View _content;
        protected List<View> _layoutChildren;
        protected List<Binding> _bindings;
        protected Action<View> _initializer;
        protected bool _isLoaded;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public View(View parent, View layoutParent, string id, Template template, Action<View> initializer) : base(id, template ?? ViewTemplates.Default)
        {
            _parent = parent;
            _bindings = new List<Binding>();
            _layoutChildren = new List<View>();
            _layoutParent = layoutParent ?? parent;
            if (_layoutParent != null)
            {
                _layoutParent.LayoutChildren.Add(this);
            }

            _initializer = initializer;
            _content = this;
            BeforeInitialize();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets view parent.
        /// </summary>
        public View Parent
        {
            get { return _parent; }
            set { _parent = value; }
        }

        /// <summary>
        /// Gets or sets layout parent.
        /// </summary>
        public View LayoutParent
        {
            get { return _layoutParent; }
            set { _layoutParent = value; }
        }

        /// <summary>
        /// Gets or sets content container.
        /// </summary>
        public View ContentContainer
        {
            get { return _content; }
            set { _content = value; }
        }

        /// <summary>
        /// Gets content container.
        /// </summary>
        public View Content
        {
            get
            {
                var content = ContentContainer;
                while (content != content.ContentContainer)
                    content = content.ContentContainer;
                return content;
            }
        }

        /// <summary>
        /// Gets or sets layout children.
        /// </summary>
        public List<View> LayoutChildren
        {
            get { return _layoutChildren; }
        }

        /// <summary>
        /// Gets boolean indicating if view is loaded.
        /// </summary>
        public bool IsLoaded
        {
            get { return _isLoaded; }
        }

        /// <summary>
        /// Gets list of bindings.
        /// </summary>
        public List<Binding> Bindings => _bindings;

        #endregion

        #region Methods

        /// <summary>
        /// Called once in the object's lifetime before construction of children and before load.
        /// </summary>
        protected virtual void BeforeInitialize()
        {
        }

        /// <summary>
        /// Called once in the object's lifetime after construction of children and before load.
        /// </summary>
        public virtual void AfterInitialize()
        {
        }

        /// <summary>
        /// Loads the view asynchronously. 
        /// </summary>
        public async Task LoadAsync()
        {
            if (IsLoaded)
                return;

            await LoadAsyncInternal(true);
            AfterInitiatedLoad();
        }

        /// <summary>
        /// Loads the view asynchronously. 
        /// </summary>
        protected async Task LoadAsyncInternal(bool initiatedLoad)
        {
            if (IsLoaded)
                return;

            if (LoadMode == LoadMode.Manual && !initiatedLoad)
                return;

            BeforeLoad();
            LoadDependencyProperties();

            await Task.WhenAll(LayoutChildren.Select(x => x.LoadAsyncInternal(false)));

            UpdateBindings();

            _initializer?.Invoke(this);

            _isLoaded = true;
            AfterLoad();

            Loaded?.Invoke(this);
        }

        /// <summary>
        /// Loads the view. Called when load is initiated from an external source.
        /// </summary>
        public void Load()
        {
            if (IsLoaded)
                return;

            LoadInternal(true);
            AfterInitiatedLoad();
        }

        /// <summary>
        /// Loads the view. Called internally. 
        /// </summary>
        protected void LoadInternal(bool initiatedLoad)
        {
            if (IsLoaded)
                return;

            if (LoadMode == LoadMode.Manual && !initiatedLoad)
                return;

            BeforeLoad();
            LoadDependencyProperties();

            foreach (var child in LayoutChildren)
            {
                child.LoadInternal(false);
            }

            UpdateBindings();

            _initializer?.Invoke(this);

            _isLoaded = true;
            AfterLoad();

            Loaded?.Invoke(this);
        }

        /// <summary>
        /// Called just before the view and its children are loaded.
        /// </summary>
        protected virtual void BeforeLoad()
        {
        }

        /// <summary>
        /// Called after the view and its children has been loaded.
        /// </summary>
        protected virtual void AfterLoad()
        {
        }

        /// <summary>
        /// Called after the top-most view who initiated the load, has been loaded. Used to update parents.
        /// </summary>
        protected virtual void AfterInitiatedLoad()
        {
            UpdateParentBindings();
        }

        /// <summary>
        /// Called after the top-most view who initiated the unload, has been unloaded. Used to update parents.
        /// </summary>
        protected virtual void AfterInitiatedUnload()
        {
        }

        /// <summary>
        /// Updates bindings after children has been loaded.
        /// </summary>
        public void UpdateBindings()
        {
            // update all bindings
            foreach (var binding in _bindings)
            {
                binding.UpdateBinding();
            }
        }

        /// <summary>
        /// Updates bindings to specific target object.
        /// </summary>
        public void UpdateBindings(DependencyObject targetObject)
        {
            // update bindings to target object
            foreach (var binding in _bindings)
            {
                if (binding.TargetObjects.Contains(targetObject))
                {
                    binding.UpdateBinding();
                }
            }
        }

        /// <summary>
        /// Updates bindings to this view in parent. 
        /// </summary>
        public void UpdateParentBindings()
        {
            if (Parent != null)
            {
                Parent.UpdateBindings(this);
            }
        }

        /// <summary>
        /// Loads dependency properties. 
        /// </summary>
        protected void LoadDependencyProperties()
        {
            var template = _template;
            while (true)
            {
                List<DependencyProperty> dependencyProperties;
                if (DependencyProperties.TryGetValue(template, out dependencyProperties))
                {
                    // iterate through all dependency properties and initialize them
                    for (int i = 0; i < dependencyProperties.Count; ++i)
                    {
                        dependencyProperties[i].Load(this);
                    }
                }

                // do the same for properties in base class
                template = template.BasedOn;
                if (template == ViewTemplates.Default)
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Unloads the view.
        /// </summary>
        public void Unload()
        {
            if (!IsLoaded)
                return;

            UnloadInternal();
            AfterInitiatedUnload();
        }

        /// <summary>
        /// Unloads the view.
        /// </summary>
        protected void UnloadInternal()
        {
            if (!IsLoaded)
                return;

            BeforeUnload();
            foreach (var child in LayoutChildren)
            {
                child.UnloadInternal();
            }

            AfterUnload();
            UnloadDependencyProperties();

            _isLoaded = false;
        }

        /// <summary>
        /// Unloads dependency properties. 
        /// </summary>
        protected void UnloadDependencyProperties()
        {
            var template = _template;
            while (true)
            {
                List<DependencyProperty> dependencyProperties;
                if (DependencyProperties.TryGetValue(template, out dependencyProperties))
                {
                    // iterate through all dependency properties and clear run-time values
                    for (int i = 0; i < dependencyProperties.Count; ++i)
                    {
                        dependencyProperties[i].Unload(this);
                    }
                }

                // do the same for properties in base class
                template = template.BasedOn;
                if (template == ViewTemplates.Default)
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Called just before the view and its children are unloaded.
        /// </summary>
        protected virtual void BeforeUnload()
        {
        }

        /// <summary>
        /// Called after the view and its children has been unloaded.
        /// </summary>
        protected virtual void AfterUnload()
        {
        }

        /// <summary>
        /// Returns view action.
        /// </summary>
        protected ViewAction Action(ViewAction action)
        {
            return action; // TODO remove if replaced by ResolveActionHandler
        }

        /// <summary>
        /// Returns view action from action.
        /// </summary>
        protected ViewAction Action(Action action)
        {
            return (x, y) => action(); // TODO remove if replaced by ResolveActionHandler
        }

        /// <summary>
        /// Resolves action handler from name. 
        /// </summary>
        protected ViewAction ResolveActionHandler(View parent, string actionHandlerName)
        {
            // look for a method with the same name as the entry
            var parentType = parent.GetType();
            var actionHandler = parentType.GetMethod(actionHandlerName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (actionHandler == null)
            {
                Debug.LogError(String.Format("[Delight] {0}: Unable to initialize view action handler \"{1}()\". View action handler not found in view \"{2}\".", GetType().Name, actionHandlerName, parentType.Name));
                return (x, y) => { };
            }

            ParameterInfo[] viewActionMethodParameters = actionHandler.GetParameters();
            int parameterCount = viewActionMethodParameters.Length;
            if (parameterCount <= 0)
            {
                return (x, y) => actionHandler.Invoke(parent, null);
            }
            else if (parameterCount == 1)
            {
                return (x, y) => actionHandler.Invoke(parent, new object[] { x });
            }
            else
            {
                return (x, y) => actionHandler.Invoke(parent, new object[] { x, y });
            }
        }

        /// <summary>
        /// Sets the state of the view.
        /// </summary>
        public virtual void SetState(string newState)
        {
            if (newState.IEquals(_previousState))
                return;

            var stateChangingProperties = GetStateChangingProperties(newState);
            if (stateChangingProperties != null)
            {
                // unload all state changing dependency properties
                for (int i = 0; i < stateChangingProperties.Count; ++i)
                {
                    stateChangingProperties[i].Unload(this);
                }

                // set state
                _state = newState;
                _previousState = newState;

                // load all state changing dependency properties
                for (int i = 0; i < stateChangingProperties.Count; ++i)
                {
                    stateChangingProperties[i].Load(this);
                }
            }
        }

        /// <summary>
        /// Gets list of state changing properties.
        /// </summary>
        private List<DependencyProperty> GetStateChangingProperties(string newState)
        {
            // get list of properties changing state for this template
            List<DependencyProperty> stateChangingProperties;
            if (!StateChangingProperties.TryGetValue(_template, out stateChangingProperties))
            {
                List<DependencyProperty> templateStateChangingProperties = null;

                // initialize list of all properties that changes state for this template                
                var template = _template;
                while (true)
                {
                    List<DependencyProperty> dependencyProperties;
                    if (DependencyProperties.TryGetValue(template, out dependencyProperties))
                    {
                        // iterate through all dependency properties and clear run-time values
                        for (int i = 0; i < dependencyProperties.Count; ++i)
                        {
                            var dependencyProperty = dependencyProperties[i];
                            if (dependencyProperty.HasState(_template))
                            {
                                if (templateStateChangingProperties == null)
                                    templateStateChangingProperties = new List<DependencyProperty>();

                                templateStateChangingProperties.Add(dependencyProperties[i]);
                            }
                        }
                    }

                    // do the same for properties in base class
                    template = template.BasedOn;
                    if (template == ViewTemplates.Default)
                    {
                        break;
                    }
                }

                stateChangingProperties = templateStateChangingProperties;
                StateChangingProperties.Add(_template, stateChangingProperties);
            }

            if (stateChangingProperties == null)
                return null;

            // filter properties and return those affected by the state change
            for (int i = stateChangingProperties.Count - 1; i >= 0; --i)
            {
                var property = stateChangingProperties[i];
                if (property.HasState(_template, _previousState) || property.HasState(_template, newState))
                    continue;

                stateChangingProperties.RemoveAt(i);
            }

            return stateChangingProperties;
        }

        #endregion
    }
}
