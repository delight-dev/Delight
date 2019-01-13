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
    public partial class View : DependencyObject
    {
        #region Fields

        public delegate void ViewAction(DependencyObject sender, object eventArgs);        
        
        protected View _parent;
        protected View _layoutParent;
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
            Initialize();
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

        #endregion

        #region Methods

        /// <summary>
        /// Called once in the object's lifetime by the constructor.
        /// </summary>
        public virtual void Initialize()
        {            
        }

        /// <summary>
        /// Loads the view asynchronously. 
        /// </summary>
        public async Task LoadAsync()
        {
            await LoadAsyncInternal();
            AfterInitialLoad();
        }

        /// <summary>
        /// Loads the view asynchronously. 
        /// </summary>
        protected async Task LoadAsyncInternal()
        {
            if (IsLoaded)
                return;

            BeforeLoad();
            InitializeDependencyProperties();

            await Task.WhenAll(LayoutChildren.Select(x => x.LoadAsyncInternal()));
            
            UpdateBindings();

            _initializer?.Invoke(this);

            _isLoaded = true;
            AfterLoad();
        }

        /// <summary>
        /// Loads the view. Called when load is initiated from an external source.
        /// </summary>
        public void Load()
        {
            LoadInternal();
            AfterInitialLoad();
        }

        /// <summary>
        /// Loads the view. Called internally. 
        /// </summary>
        protected void LoadInternal()
        {
            if (IsLoaded)
                return;

            BeforeLoad();
            InitializeDependencyProperties();

            foreach (var child in LayoutChildren)
            {
                child.LoadInternal();
            }
            
            UpdateBindings();

            _initializer?.Invoke(this);

            _isLoaded = true;
            AfterLoad();
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
        protected virtual void AfterInitialLoad()
        {
            UpdateParentBindings();
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
                if (binding.TargetObject == targetObject)
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
        /// Initializes dependency properties. 
        /// </summary>
        protected void InitializeDependencyProperties()
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
                        dependencyProperties[i].Initialize(this);
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
        public virtual void Unload()
        {
            BeforeUnload();
            foreach (var child in LayoutChildren)
            {
                child.Unload();
            }

            AfterUnload();
            ClearDependencyPropertyValues();

            _isLoaded = false;
        }

        /// <summary>
        /// Goes through and clears all run-time dependency property values. 
        /// </summary>
        protected virtual void ClearDependencyPropertyValues()
        {
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

        #endregion
    }       

    #region Data Templates

    public static class ViewTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return View;
            }
        }

        private static Template _view;
        public static Template View
        {
            get
            {
                if (_view == null)
                {
                    _view = new Template(null);
                }
                return _view;
            }
        }

        #endregion
    }

    #endregion
}
