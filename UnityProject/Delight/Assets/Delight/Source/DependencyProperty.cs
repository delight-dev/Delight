#region Using Statements
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using UnityEngine;
#endregion

namespace Delight
{
    /// <summary>
    /// Dependency property. A dependency property manages the property values of dependency objects (views). Contains information about a property, its default values, various states, and property changed handlers attached.
    /// </summary>
    public class DependencyProperty<T> : DependencyProperty
    {
        #region Fields

        public Dictionary<Template, T> Defaults;
        public Dictionary<DependencyObject, T> Values; // TODO here we want a weak keyed dictionary, perhaps by 
        public Dictionary<Template, bool> BindingSet;
        public ValueConverter<T> ValueConverter;
        public Dictionary<string, Dictionary<Template, T>> StateDefaults;
        public Dictionary<Template, bool> HasStateDefaults;

        public Dictionary<DependencyObject, PropertyChangedEventHandler> PropertyChangedHandlers;
        public bool IsAssetType;
        public bool IsAtomicBindableObjectType;
        public bool ClearValuesOnUnload;
        public Func<T> Activator;

        #endregion

        #region Methods

        /// <summary>
        /// Gets dependency property value for specified instance.
        /// </summary>
        public virtual T GetValue(DependencyObject key)
        {
            T currentValue;
            if (Values.TryGetValue(key, out currentValue))
            {
                return currentValue;
            }
            else
            {
                if (Activator != null)
                {
                    // use activator to create initial value
                    var value = Activator();
                    Values.Add(key, value);
                    return value;
                }

                return GetDefault(key);
            }
        }

        /// <summary>
        /// Sets dependency property value for specified instance.
        /// </summary>
        public virtual void SetValue(DependencyObject key, T value, bool notifyPropertyChangedListeners = true)
        {
            // get old value
            T oldValue;
            T currentValue;
            bool hasCurrentValue = Values.TryGetValue(key, out currentValue);
            if (hasCurrentValue)
            {
                oldValue = currentValue;
            }
            else
            {
                oldValue = GetDefault(key);
            }

            // has value changed?
            if (oldValue != null ? oldValue.Equals(value) : value == null)
            {
                return; // no.
            }

            // set value
            if (hasCurrentValue)
            {
                Values[key] = value;
            }
            else
            {
                Values.Add(key, value);
            }

            bool isLoadingAsset = false;
            if (IsAtomicBindableObjectType)
            {
                // detach old property changed listeners
                if (oldValue != null)
                {
                    DetachPropertyChangedHandler(key, oldValue);
                    if (IsAssetType)
                    {
                        // unregister reference if its an asset object
                        var assetObject = oldValue as AssetObject;
                        assetObject.UnregisterReference(key);
                    }
                }

                // attach new property changed listeners
                if (value != null)
                {
                    AttachPropertyChangedHandler(key, value);
                    if (IsAssetType)
                    {
                        // register reference if its an asset object
                        var assetObject = value as AssetObject;                        
                        assetObject.RegisterReference(key);
                        isLoadingAsset = !assetObject.IsLoaded;
                    }
                }
            }

            // trigger property-changed event
            if (notifyPropertyChangedListeners && !isLoadingAsset)
            {
                key.OnPropertyChanged(PropertyName); // TODO see if we can use CallerMemberName here so we don't have to store property name for each property (although again its just one per type so no huge deal)

                // trigger asset change if asset (and not loaded) 
                if (IsAssetType)
                {
                    OnAssetChanged(key);
                }
            }
        }

        /// <summary>
        /// Attaches property changed handler. 
        /// </summary>
        private void AttachPropertyChangedHandler(DependencyObject key, T value)
        {
            // detach any existing event handlers
            DetachPropertyChangedHandler(key, value);

            // attach new event handler
            PropertyChangedEventHandler eventHandler = null;
            if (IsAssetType)
            {
                eventHandler = (x, y) =>
                {
                    OnAssetChanged(key);
                    key.OnPropertyChanged(PropertyName);
                };
            }
            else
            {
                eventHandler = (x, y) => key.OnPropertyChanged(PropertyName);
            }
            PropertyChangedHandlers.Add(key, eventHandler);
            (value as AtomicBindableObject).PropertyChanged += eventHandler;
        }

        /// <summary>
        /// Called when asset has changed. 
        /// </summary>
        public virtual void OnAssetChanged(DependencyObject key)
        {
        }

        /// <summary>
        /// Detaches property changed handler from the object.
        /// </summary>
        private void DetachPropertyChangedHandler(DependencyObject key, T value)
        {
            PropertyChangedEventHandler eventHandler;
            if (PropertyChangedHandlers.TryGetValue(key, out eventHandler))
            {
                (value as AtomicBindableObject).PropertyChanged -= eventHandler;
                PropertyChangedHandlers.Remove(key);
            }
        }

        /// <summary>
        /// Called when the dependency object has been loaded.
        /// </summary>
        public override void Load(DependencyObject key)
        {
            base.Load(key);
            if (!IsAtomicBindableObjectType)
                return;

            // attach listeners
            var value = GetValue(key);
            if (value == null)
                return;

            AttachPropertyChangedHandler(key, value);

            // register reference if its an asset object
            bool isLoadingAsset = false;
            if (IsAssetType)
            {
                var assetObject = value as AssetObject;
                isLoadingAsset = !assetObject.IsLoaded;
                assetObject.RegisterReference(key);
            }

            if (!isLoadingAsset)
            {
                // trigger initial property changed on load
                key.OnPropertyChanged(PropertyName);

                // trigger asset change if asset
                if (IsAssetType)
                {
                    OnAssetChanged(key);
                }
            }
        }

        /// <summary>
        /// Called when the dependency object has been loaded.
        /// </summary>
        public override async Task LoadAsync(DependencyObject key)
        {
            if (!IsAtomicBindableObjectType)
                return;

            // attach listeners
            var value = GetValue(key);
            if (value == null)
                return;

            AttachPropertyChangedHandler(key, value);

            // register reference if its an asset object
            bool isLoadingAsset = false;
            if (IsAssetType)
            {
                var assetObject = value as AssetObject;                
                await assetObject.RegisterReferenceAsync(key);
                isLoadingAsset = !assetObject.IsLoaded;
            }

            if (!isLoadingAsset)
            {
                // trigger initial property changed on load
                key.OnPropertyChanged(PropertyName);

                // trigger asset change if asset
                if (IsAssetType)
                {
                    OnAssetChanged(key);
                }
            }
        }

        /// <summary>
        /// Called when the dependency object has been unloaded. Clears run-time values for the specified instance.
        /// </summary>
        public override void Unload(DependencyObject key)
        {
            base.Unload(key);

            // detach property changed handlers
            if (IsAtomicBindableObjectType)
            {
                var value = GetValue(key);
                if (value != null)
                {
                    DetachPropertyChangedHandler(key, value);

                    // unregister reference to asset
                    if (IsAssetType)
                    {
                        var assetObject = value as AssetObject;
                        assetObject.UnregisterReference(key);
                    }
                }
            }

            if (ClearValuesOnUnload)
            {
                Values.Remove(key);
            }
        }

        /// <summary>
        /// Checks if dependency property value is undefined (no run-time or default value set). Mainly used check if values of non-nullable types has been set.
        /// </summary>
        public override bool IsUndefined(DependencyObject key, bool checkAllStates = false)
        {
            if (Values.ContainsKey(key))
                return false;

            if (HasBinding(key))
            {
                return false;
            }

            T defaultValue;
            if (checkAllStates && StateDefaults != null)
            {
                foreach (var state in StateDefaults.Keys)
                {
                    if (TryGetStateDefault(key.Template, state, out defaultValue))
                        return false;
                }
            }

            return !TryGetDefault(key, out defaultValue);
        }

        /// <summary>
        /// Gets default value from type.
        /// </summary>
        public virtual T GetDefault(DependencyObject key)
        {
            T defaultValue;
            TryGetDefault(key, out defaultValue);
            return defaultValue;
        }

        /// <summary>
        /// Gets default value if it exist.
        /// </summary>
        public bool TryGetDefault(DependencyObject key, out T defaultValue)
        {
            // try get state default value
            defaultValue = default(T);
            if (TryGetStateDefault(key, out defaultValue))
            {
                return true;
            }

            // try get default value
            var template = key.Template;
            while (true)
            {
                if (Defaults.TryGetValue(template, out defaultValue))
                {
                    return true;
                }

                template = template.BasedOn;
                if (template == ViewTemplates.Default)
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Gets default state value if it exist.
        /// </summary>
        public bool TryGetStateDefault(DependencyObject key, out T defaultValue)
        {
            return TryGetStateDefault(key.Template, key.State, out defaultValue);
        }

        /// <summary>
        /// Gets default state value if it exist.
        /// </summary>
        public bool TryGetStateDefault(Template key, string state, out T defaultValue)
        {
            defaultValue = default(T);
            if (String.IsNullOrEmpty(state) || StateDefaults == null)
                return false;

            Dictionary<Template, T> stateDefaults;
            if (!StateDefaults.TryGetValue(state, out stateDefaults))
                return false;

            var template = key;
            while (true)
            {
                if (stateDefaults.TryGetValue(template, out defaultValue))
                {
                    return true;
                }

                template = template.BasedOn;
                if (template == ViewTemplates.Default)
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Sets default value for type.
        /// </summary>
        public virtual void SetDefault(Template template, T defaultValue)
        {
            Defaults[template] = defaultValue;
        }

        /// <summary>
        /// Sets default state value for type.
        /// </summary>
        public virtual void SetStateDefault(string state, Template template, T defaultValue)
        {
            if (StateDefaults == null)
            {
                StateDefaults = new Dictionary<string, Dictionary<Template, T>>();
                HasStateDefaults = new Dictionary<Template, bool>();
            }

            Dictionary<Template, T> stateValues;
            if (!StateDefaults.TryGetValue(state, out stateValues))
            {
                stateValues = new Dictionary<Template, T>();
                StateDefaults[state] = stateValues;
            }

            stateValues[template] = defaultValue;
            HasStateDefaults[template] = true;
        }

        /// <summary>
        /// Returns boolean indicating if dependency property has any state values set.
        /// </summary>
        public override bool HasState(Template key)
        {
            if (HasStateDefaults == null)
                return false;

            var template = key;
            while (true)
            {
                bool hasState = false;
                if (HasStateDefaults.TryGetValue(template, out hasState))
                {
                    if (hasState)
                    {
                        return true;
                    }
                }

                template = template.BasedOn;
                if (template == ViewTemplates.Default)
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Returns boolean indicating if dependency property has state value set.
        /// </summary>
        public override bool HasState(Template key, string state)
        {
            T defaultValue;
            return TryGetStateDefault(key, state, out defaultValue);
        }

        /// <summary>
        /// Checks if property is bound.
        /// </summary>
        public override bool HasBinding(DependencyObject key)
        {
            if (BindingSet == null)
                return false;

            // try get boolean indicating if the property has binding
            var template = key.Template;
            while (true)
            {
                if (BindingSet.TryGetValue(template, out var hasBinding))
                {
                    return true;
                }

                template = template.BasedOn;
                if (template == ViewTemplates.Default)
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Sets boolean indicating if property is bound.
        /// </summary>
        public override void SetHasBinding(Template template, bool hasBinding = true)
        {
            if (BindingSet == null)
            {
                BindingSet = new Dictionary<Template, bool>();
            }

            BindingSet[template] = hasBinding;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public DependencyProperty(string propertyName, Func<T> activator = null)
        {
            Values = new Dictionary<DependencyObject, T>();
            Defaults = new Dictionary<Template, T>();
            ValueConverter = ValueConverter<T>.Empty;
            PropertyName = propertyName;

            var propertyType = typeof(T);
            IsAssetType = typeof(AssetObject).IsAssignableFrom(propertyType);
            IsAtomicBindableObjectType = typeof(AtomicBindableObject).IsAssignableFrom(propertyType);

            // don't clear view references, content templates and view actions as they are set in constructor and not to change during run-time
            ClearValuesOnUnload = !typeof(View).IsAssignableFrom(propertyType) && !typeof(Delight.ViewAction).IsAssignableFrom(propertyType) &&
                !typeof(ContentTemplate).IsAssignableFrom(propertyType);
            Activator = activator;

            if (IsAtomicBindableObjectType)
            {
                PropertyChangedHandlers = new Dictionary<DependencyObject, PropertyChangedEventHandler>();
            }
        }

        #endregion
    }

    /// <summary>
    /// Base class for dependency properties.
    /// </summary>
    public class DependencyProperty
    {
        #region Fields

        public string PropertyName; // TODO by using [CallerMemberName] instead we might not have to store PropertyName

        #endregion

        #region Methods

        /// <summary>
        /// Called when the dependency object has been loaded. Used e.g. by mapped dependency properties to propagate initial values.
        /// </summary>
        public virtual void Load(DependencyObject key)
        {
        }

        /// <summary>
        /// Called when the dependency object has been loaded. Used e.g. by mapped dependency properties to propagate initial values.
        /// </summary>
        public virtual async Task LoadAsync(DependencyObject key)
        {
            await Task.FromResult(0); // just to prevent compiler warning
        }

        /// <summary>
        /// Called when the dependency object has been unloaded.
        /// </summary>
        public virtual void Unload(DependencyObject key)
        {
        }

        /// <summary>
        /// Returns boolean indicating if dependency property has any state values set.
        /// </summary>
        public virtual bool HasState(Template key)
        {
            return false;
        }

        /// <summary>
        /// Returns boolean indicating if dependency property has value set for the specified state.
        /// </summary>
        public virtual bool HasState(Template key, string state)
        {
            return false;
        }

        /// <summary>
        /// Checks if dependency property value is undefined (no run-time or default value set). Mainly used check if values of non-nullable types has been set.
        /// </summary>
        public virtual bool IsUndefined(DependencyObject key, bool checkAllStates = false)
        {
            return false;
        }

        /// <summary>
        /// Checks if property has binding.
        /// </summary>
        public virtual bool HasBinding(DependencyObject key)
        {
            return false;
        }

        /// <summary>
        /// Sets boolean indicating if property has binding.
        /// </summary>
        public virtual void SetHasBinding(Template template, bool hasBinding = false)
        {
        }

        #endregion
    }
}
