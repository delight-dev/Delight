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

        public delegate void ChangeHandler();
        public delegate void LoadedEventHandler(object source);
        public event LoadedEventHandler Loaded;

        protected View _parent;
        protected View _layoutParent;
        protected View _content;
        protected List<View> _layoutChildren;
        protected List<Binding> _bindings;
        protected Action<View> _initializer;
        protected bool _isLoaded;
        protected bool _isDynamic;

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
            _previousState = string.Empty;
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

        /// <summary>
        /// Boolean indicating if view is dynamic and should be removed completely when unloaded.
        /// </summary>
        public bool IsDynamic
        {
            get { return _isDynamic; }
            set { _isDynamic = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Resolves action handler from name. TODO remove
        /// </summary>
        public ViewAction.ViewActionDelegate ResolveActionHandler(object obj, string actionHandlerName, params Func<object>[] paramGetters)
        {
            // look for a method with the same name as the entry
            var parentType = obj.GetType();
            var actionHandler = parentType.GetMethod(actionHandlerName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (actionHandler == null)
            {
                Debug.LogError(String.Format("#Delight# {0}: Unable to initialize view action handler \"{1}()\". View action handler not found in view \"{2}\".", GetType().Name, actionHandlerName, parentType.Name));
                return (x, y) => { };
            }

            ParameterInfo[] viewActionMethodParameters = actionHandler.GetParameters();
            int parameterCount = viewActionMethodParameters.Length;
            if (parameterCount <= 0)
            {
                return (x, y) => actionHandler.Invoke(obj, null);
            }

            if (paramGetters.Length > 0)
            {
                // check if first parameter is a reference to the sender or view action
                if (typeof(View).IsAssignableFrom(viewActionMethodParameters[0].ParameterType))
                {
                    switch (paramGetters.Length)
                    {
                        case 1:
                            return (x, y) => actionHandler.Invoke(obj, new object[] { x, paramGetters[0]() });
                        case 2:
                            return (x, y) => actionHandler.Invoke(obj, new object[] { x, paramGetters[0](), paramGetters[1]() });
                        case 3:
                            return (x, y) => actionHandler.Invoke(obj, new object[] { x, paramGetters[0](), paramGetters[1](), paramGetters[2]() });
                        case 4:
                            return (x, y) => actionHandler.Invoke(obj, new object[] { x, paramGetters[0](), paramGetters[1](), paramGetters[2](), paramGetters[3]() });
                        case 5:
                            return (x, y) => actionHandler.Invoke(obj, new object[] { x, paramGetters[0](), paramGetters[1](), paramGetters[2](), paramGetters[3](), paramGetters[4]() });
                        case 6:
                            return (x, y) => actionHandler.Invoke(obj, new object[] { x, paramGetters[0](), paramGetters[1](), paramGetters[2](), paramGetters[3](), paramGetters[4](), paramGetters[5]() });
                        case 7:
                            return (x, y) => actionHandler.Invoke(obj, new object[] { x, paramGetters[0](), paramGetters[1](), paramGetters[2](), paramGetters[3](), paramGetters[4](), paramGetters[5](), paramGetters[6]() });
                        case 8:
                            return (x, y) => actionHandler.Invoke(obj, new object[] { x, paramGetters[0](), paramGetters[1](), paramGetters[2](), paramGetters[3](), paramGetters[4](), paramGetters[5](), paramGetters[6](), paramGetters[7]() });
                        case 9:
                            return (x, y) => actionHandler.Invoke(obj, new object[] { x, paramGetters[0](), paramGetters[1](), paramGetters[2](), paramGetters[3](), paramGetters[4](), paramGetters[5](), paramGetters[6](), paramGetters[7](), paramGetters[8]() });
                        case 10:
                            return (x, y) => actionHandler.Invoke(obj, new object[] { x, paramGetters[0](), paramGetters[1](), paramGetters[2](), paramGetters[3](), paramGetters[4](), paramGetters[5](), paramGetters[6](), paramGetters[7](), paramGetters[8](), paramGetters[9]() });
                        default:
                            Debug.LogError(String.Format("#Delight# {0}: Unable to initialize view action handler \"{1}()\". A maximum of 10 parameters are allowed for view action handlers.", GetType().Name, actionHandlerName, parentType.Name));
                            return (x, y) => { };
                    }
                }
                else
                {
                    switch (paramGetters.Length)
                    {
                        case 1:
                            return (x, y) => actionHandler.Invoke(obj, new object[] { paramGetters[0]() });
                        case 2:
                            return (x, y) => actionHandler.Invoke(obj, new object[] { paramGetters[0](), paramGetters[1]() });
                        case 3:
                            return (x, y) => actionHandler.Invoke(obj, new object[] { paramGetters[0](), paramGetters[1](), paramGetters[2]() });
                        case 4:
                            return (x, y) => actionHandler.Invoke(obj, new object[] { paramGetters[0](), paramGetters[1](), paramGetters[2](), paramGetters[3]() });
                        case 5:
                            return (x, y) => actionHandler.Invoke(obj, new object[] { paramGetters[0](), paramGetters[1](), paramGetters[2](), paramGetters[3](), paramGetters[4]() });
                        case 6:
                            return (x, y) => actionHandler.Invoke(obj, new object[] { paramGetters[0](), paramGetters[1](), paramGetters[2](), paramGetters[3](), paramGetters[4](), paramGetters[5]() });
                        case 7:
                            return (x, y) => actionHandler.Invoke(obj, new object[] { paramGetters[0](), paramGetters[1](), paramGetters[2](), paramGetters[3](), paramGetters[4](), paramGetters[5](), paramGetters[6]() });
                        case 8:
                            return (x, y) => actionHandler.Invoke(obj, new object[] { paramGetters[0](), paramGetters[1](), paramGetters[2](), paramGetters[3](), paramGetters[4](), paramGetters[5](), paramGetters[6](), paramGetters[7]() });
                        case 9:
                            return (x, y) => actionHandler.Invoke(obj, new object[] { paramGetters[0](), paramGetters[1](), paramGetters[2](), paramGetters[3](), paramGetters[4](), paramGetters[5](), paramGetters[6](), paramGetters[7](), paramGetters[8]() });
                        case 10:
                            return (x, y) => actionHandler.Invoke(obj, new object[] { paramGetters[0](), paramGetters[1](), paramGetters[2](), paramGetters[3](), paramGetters[4](), paramGetters[5](), paramGetters[6](), paramGetters[7](), paramGetters[8](), paramGetters[9]() });
                        default:
                            Debug.LogError(String.Format("#Delight# {0}: Unable to initialize view action handler \"{1}()\". A maximum of 10 parameters are allowed for view action handlers.", GetType().Name, actionHandlerName, parentType.Name));
                            return (x, y) => { };
                    }
                }
            }

            if (parameterCount == 1)
            {
                // check if first parameter is a reference to the sender or view action
                if (typeof(View).IsAssignableFrom(viewActionMethodParameters[0].ParameterType))
                {
                    // parameter is the sender
                    return (x, y) => actionHandler.Invoke(obj, new object[] { x });
                }
                else if (typeof(ActionData).IsAssignableFrom(viewActionMethodParameters[0].ParameterType))
                {
                    // parameter is the view action data
                    return (x, y) => actionHandler.Invoke(obj, new object[] { y });
                }
                else
                {
                    // try pass the raw data
                    return (x, y) => actionHandler.Invoke(obj, new object[] { (y as ActionData) != null ? (y as ActionData).RawData : y });
                }
            }
            else
            {
                return (x, y) => actionHandler.Invoke(obj, new object[] { x, y });
            }
        }


        /// <summary>
        /// Called when a property has been changed.
        /// </summary>
        public override void OnPropertyChanged(object source, string property)
        {
            base.OnPropertyChanged(source, property);
            if (!IsLoaded)
                return;

            // call OnChanged if the view is loaded
            OnChanged(property);
        }

        /// <summary>
        /// Called when a property has been changed.
        /// </summary>
        public virtual void OnChanged(string property)
        {
        }

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

            await LoadAsyncInternal(true, false);
            AfterInitiatedLoad();
        }

        /// <summary>
        /// Loads the view asynchronously. 
        /// </summary>
        protected async Task LoadAsyncInternal(bool initiatedLoad, bool parentAwaitAssets)
        {
            if (IsLoaded)
                return;

            if (LoadMode.HasFlag(LoadMode.Manual) && !initiatedLoad)
                return;

            BeforeLoad();

            bool awaitAssets = parentAwaitAssets || LoadMode.HasFlag(LoadMode.AwaitAssets);
            await Task.WhenAll(LayoutChildren.ToList().Select(x => x.LoadAsyncInternal(false, awaitAssets)));

            _isLoaded = true;
            AfterChildrenLoaded();
            Initialize();

            if (awaitAssets)
            {
                await LoadDependencyPropertiesAsync();
            }
            else
            {
                LoadDependencyProperties();
            }
            UpdateBindings();

            _initializer?.Invoke(this);

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

            if (LoadMode.HasFlag(LoadMode.Manual) && !initiatedLoad)
                return;

            BeforeLoad();

            foreach (var child in LayoutChildren.ToList())
            {
                child.LoadInternal(false);
            }

            _isLoaded = true;
            AfterChildrenLoaded();
            Initialize();

            LoadDependencyProperties();
            UpdateBindings();

            _initializer?.Invoke(this);

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
        /// Called just after the children are loaded, but before dependency properties are loaded.
        /// </summary>
        protected virtual void AfterChildrenLoaded()
        {
        }

        /// <summary>
        /// Called after the view and its children has been loaded.
        /// </summary>
        protected virtual void AfterLoad()
        {
        }

        /// <summary>
        /// Called after the view and its children has been loaded.
        /// </summary>
        public virtual void Initialize()
        {
            // TODO rivality alias
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
                if (binding.Target.Objects.Contains(targetObject))
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
        /// Loads dependency asynchronously. 
        /// </summary>
        protected async Task LoadDependencyPropertiesAsync()
        {
            var template = _template;
            while (true)
            {
                List<DependencyProperty> dependencyProperties;
                if (DependencyProperties.TryGetValue(template, out dependencyProperties))
                {
                    // initialize all dependency properties asynchronously
                    await Task.WhenAll(dependencyProperties.Select(x => x.LoadAsync(this)));
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
            foreach (var child in LayoutChildren.ToList())
            {
                child.UnloadInternal();
            }

            AfterUnload();
            UnloadDependencyProperties();
            _isLoaded = false;

            if (IsDynamic)
            {
                Destroy();
            }
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
        /// Unloads the view and removes it from layout parent. 
        /// </summary>
        public virtual void Destroy()
        {
            Unload();
            if (LayoutParent != null)
            {
                LayoutParent.LayoutChildren.Remove(this);
                LayoutParent = null;
            }
            Parent = null;

            // TODO verify the view is released from memory
        }

        /// <summary>
        /// Moves view to another layout parent. 
        /// </summary>
        public virtual void MoveTo(View newLayoutParent)
        {
            if (newLayoutParent == LayoutParent)
                return;

            if (LayoutParent != null)
            {
                LayoutParent.LayoutChildren.Remove(this);
            }

            LayoutParent = newLayoutParent;
            if (LayoutParent != null)
            {
                newLayoutParent.LayoutChildren.Add(this);
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
            else
            {
                // set state
                _state = newState;
                _previousState = newState;
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
                    if (DependencyProperties.TryGetValue(template, out var dependencyProperties))
                    {
                        // iterate through all dependency properties and check if it has state
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
            var filteredStateChangingProperties = new List<DependencyProperty>();
            for (int i = 0; i < stateChangingProperties.Count; ++i)
            {
                var property = stateChangingProperties[i];
                if (!property.HasState(_template, _previousState) && !property.HasState(_template, newState))
                    continue;

                filteredStateChangingProperties.Add(stateChangingProperties[i]);
            }

            return filteredStateChangingProperties;
        }

        /// <summary>
        /// Called by designer to make the view presentable in the designer.
        /// </summary>
        public virtual void PrepareForDesigner()
        {
        }

        /// <summary>
        /// Sets content template data.
        /// </summary>
        public virtual void SetContentTemplateData(ContentTemplateData contentTemplateData)
        {
        }

        #endregion
    }
}
