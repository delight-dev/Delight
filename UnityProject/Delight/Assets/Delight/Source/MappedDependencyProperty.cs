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
    /// Dependency property that maps to another property or field like a unity component property. E.g. TextComponent.text. Stores no data on its own. 
    /// </summary>
    public class MappedDependencyProperty<T, TObject, TParent> : DependencyProperty
        where TParent : DependencyObject
    {
        #region Fields

        public Dictionary<DependencyObject, bool> ValueSet;
        public Dictionary<Template, T> Defaults;
        public Dictionary<Template, bool> BindingSet;
        public Func<TParent, TObject> ObjectGetter;
        public Func<TObject, T> Getter;
        public Action<TObject, T> Setter;
        public Dictionary<string, Dictionary<Template, T>> StateDefaults;
        public Dictionary<Template, bool> HasStateDefaults;

        #endregion

        #region Methods

        /// <summary>
        /// Gets mapped dependency property value for specified instance.
        /// </summary>
        public T GetValue(DependencyObject key)
        {
            if (State != null)
                return GetStateDefault(key, State);

            bool valueSet = false;
            ValueSet.TryGetValue(key, out valueSet);

            var target = ObjectGetter((TParent)key);
            if (valueSet && target != null)
            {
                return Getter(target);
            }
            else
            {
                return GetDefault(key);
            }
        }

        /// <summary>
        /// Sets dependency property value for specified instance.
        /// </summary>
        public void SetValue(DependencyObject key, T value, bool notifyPropertyChangedListeners = true)
        {
            var target = ObjectGetter((TParent)key);
            if (target == null)
                return;

            ValueSet[key] = true;

            // has value changed?
            T oldValue = Getter(target);
            if (oldValue != null ? oldValue.Equals(value) : value == null)
            {
                return; // no.
            }

            Setter(target, value);

            // trigger property-changed event
            if (notifyPropertyChangedListeners)
            {
                key.OnPropertyChanged(PropertyName);
            }
        }

        /// <summary>
        /// Checks if dependency property value is undefined (no run-time or default value set). Mainly used check if values of non-nullable types has been set.
        /// </summary>
        public override bool IsUndefined(DependencyObject key, bool checkAllStates = false)
        {
            bool valueSet = false;
            ValueSet.TryGetValue(key, out valueSet);
            if (valueSet)
                return false;

            if(HasBinding(key))
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
        public T GetDefault(DependencyObject key, bool getStateDefault = true)
        {
            T defaultValue;
            TryGetDefault(key, out defaultValue, getStateDefault);
            return defaultValue;
        }

        /// <summary>
        /// Gets default value if it exist.
        /// </summary>
        public bool TryGetDefault(DependencyObject key, out T defaultValue, bool getStateDefault = true)
        {
            // try get state default value
            defaultValue = default(T);
            if (getStateDefault && TryGetStateDefault(key, out defaultValue))
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
        /// Gets default state value.
        /// </summary>
        public T GetStateDefault(DependencyObject key)
        {
            return GetStateDefault(key, key.State);
        }

        /// <summary>
        /// Gets default state value.
        /// </summary>
        public new T GetStateDefault(DependencyObject key, string state)
        {
            if (String.IsNullOrEmpty(state) || state == DependencyObject.DefaultStateName)
            {
                return GetDefault(key, false);
            }
            else if (state == DependencyObject.AnyStateName)
            {
                return GetStateDefault(key);
            }

            TryGetStateDefault(key.Template, state, out var defaultValue);
            return defaultValue;
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
        public void SetDefault(Template template, T defaultValue)
        {
            Defaults[template] = defaultValue;
        }

        /// <summary>
        /// Initializes the mapped dependency property.
        /// </summary>
        public override void Load(DependencyObject key)
        {
            base.Load(key);

            var target = ObjectGetter((TParent)key);
            if (target == null)
                return;

            bool valueSet = false;
            ValueSet.TryGetValue(key, out valueSet);
            if (valueSet) // if value already has been set, don't overwrite it with default value
                return;

            // map default value to target
            T defaultValue; 
            if (TryGetDefault(key, out defaultValue))
            {
                Setter(target, defaultValue);
            }

            // trigger initial property changed on load
            key.OnPropertyChanged(PropertyName);
        }

        /// <summary>
        /// Initializes the mapped dependency property.
        /// </summary>
        public override async Task LoadAsync(DependencyObject key)
        {
            await base.LoadAsync(key);

            var target = ObjectGetter((TParent)key);
            if (target == null)
                return;

            bool valueSet = false;
            ValueSet.TryGetValue(key, out valueSet);
            if (valueSet) // if value already has been set, don't overwrite it with default value
                return;

            // map default value to target
            T defaultValue;
            if (TryGetDefault(key, out defaultValue))
            {
                Setter(target, defaultValue);
            }

            // trigger initial property changed on load
            key.OnPropertyChanged(PropertyName);
        }


        /// <summary>
        /// Clears run-time values for the specified instance.
        /// </summary>
        public override void Unload(DependencyObject key)
        {
            base.Unload(key);
            ValueSet.Remove(key);
        }

        /// <summary>
        /// Sets default state value for type.
        /// </summary>
        public void SetStateDefault(string state, Template template, T defaultValue)
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
        /// Sets default value for type.
        /// </summary>
        public override void SetDefaultGeneric(Template template, object defaultValue)
        {
            SetDefault(template, (T)defaultValue);
        }

        /// <summary>
        /// Sets default state value for type.
        /// </summary>
        public override void SetStateDefaultGeneric(string state, Template template, object defaultValue)
        {
            SetStateDefault(state, template, (T)defaultValue);
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
        /// Checks if property has binding.
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
        /// Sets boolean indicating if property has binding.
        /// </summary>
        public override void SetHasBinding(Template template, bool hasBinding = true)
        {
            if (BindingSet == null)
            {
                BindingSet = new Dictionary<Template, bool>();
            }

            BindingSet[template] = hasBinding;
        }

        /// <summary>
        /// Sets boolean indicating that value has been set. Used if value is modified directly and not through the dependency property.
        /// </summary>
        public void SetHasValue(DependencyObject key, bool hasValue = true)
        {
            ValueSet[key] = hasValue;
        }

        /// <summary>
        /// Sets dependency property value for specified instance.
        /// </summary>
        public override void SetValueGeneric(DependencyObject key, object value, bool notifyPropertyChangedListeners = true)
        {
            SetValue(key, (T)value, notifyPropertyChangedListeners);
        }

        /// <summary>
        /// Gets default state value.
        /// </summary>
        public override object GetStateDefaultGeneric(DependencyObject key, string state)
        {
            return GetStateDefault(key, state);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public MappedDependencyProperty(string propertyName, Func<TParent, TObject> objectGetter, Func<TObject, T> getter, Action<TObject, T> setter)
        {
            ValueSet = new Dictionary<DependencyObject, bool>();
            Defaults = new Dictionary<Template, T>();
            Getter = getter;
            Setter = setter;
            ObjectGetter = objectGetter;
            PropertyName = propertyName;
        }

        #endregion
    }
}
