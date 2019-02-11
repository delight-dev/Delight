#region Using Statements
using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
#endregion

namespace Delight
{
    /// <summary>
    /// Dependency property.
    /// </summary>
    public class DependencyProperty<T> : DependencyProperty
    {
        #region Fields

        public Dictionary<Template, T> Defaults;
        public Dictionary<DependencyObject, T> Values; // TODO here we want a weak keyed dictionary
        public ValueConverter<T> ValueConverter;

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
                return GetDefault(key.Template);
            }
        }
        
        /// <summary>
        /// Sets dependency property value for specified instance.
        /// </summary>
        public virtual void SetValue(DependencyObject key, T value, bool notifyObservers = true)
        {
            // get old value
            T oldValue;
            T currentValue;
            if (Values.TryGetValue(key, out currentValue))
            {
                oldValue = currentValue;
            }
            else
            {
                oldValue = GetDefault(key.Template);
            }

            // has value changed?
            if (oldValue != null ? oldValue.Equals(value) : value == null)
            {
                return; // no.
            }

            // set value
            if (currentValue != null)
            {
                Values[key] = value;
            }
            else
            {
                Values.Add(key, value);
            }

            // trigger property-changed event
            key.OnPropertyChanged(PropertyName); // TODO see if we can use CallerMemberName here so we don't have to store property name for each property (although again its just one per type so no huge deal)
        }

        /// <summary>
        /// Called when the dependency object has been unloaded. Clears run-time values for the specified instance.
        /// </summary>
        public override void Unload(DependencyObject key)
        {
            base.Unload(key);
            Values.Remove(key);
        }

        /// <summary>
        /// Checks if dependency property value is undefined (no run-time or default value set). Mainly used check if values of non-nullable types has been set.
        /// </summary>
        public virtual bool IsUndefined(DependencyObject key)
        {
            if (Values.ContainsKey(key))
                return false;

            var template = key.Template;
            while (true)
            {
                if (Defaults.ContainsKey(template))
                {
                    return false;
                }

                template = template.BasedOn;
                if (template == ViewTemplates.Default)
                {
                    return true;
                }
            }
        }

        /// <summary>
        /// Gets default value from type.
        /// </summary>
        public virtual T GetDefault(Template template)
        {
            while (true)
            {
                T defaultValue;
                if (Defaults.TryGetValue(template, out defaultValue))
                {
                    return defaultValue;
                }
                
                template = template.BasedOn;
                if (template == ViewTemplates.Default)
                {
                    return default(T);
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

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public DependencyProperty(string propertyName)
        {
            Values = new Dictionary<DependencyObject, T>();
            Defaults = new Dictionary<Template, T>();
            ValueConverter = ValueConverter<T>.Empty;
            PropertyName = propertyName;
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
        /// Called when the dependency object has been unloaded.
        /// </summary>
        public virtual void Unload(DependencyObject key)
        {
        }

        #endregion
    }
}
