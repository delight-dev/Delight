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
        public T GetValue(DependencyObject key)
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
        public void SetValue(DependencyObject key, T value, bool notifyObservers = true)
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
            key.NotifyPropertyChanged(key, this);
        }

        /// <summary>
        /// Checks if dependency property value is undefined (no run-time or default value set). Mainly used check if values of non-nullable types has been set.
        /// </summary>
        public bool IsUndefined(DependencyObject key)
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
        public T GetDefault(Template template)
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
        public void SetDefault(Template template, T defaultValue)
        {
            Defaults[template] = defaultValue;
        }

        /// <summary>
        /// Clears run-time values for the specified dependency object.
        /// </summary>
        public void Clear(DependencyObject key)
        {
            Values.Remove(key);            
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public DependencyProperty()
        {
            Values = new Dictionary<DependencyObject, T>();
            Defaults = new Dictionary<Template, T>();
            ValueConverter = ValueConverter<T>.Empty;
        }

        #endregion
    }

    /// <summary>
    /// Base class for dependency properties.
    /// </summary>
    public class DependencyProperty
    {
        public virtual void Initialize(DependencyObject key)
        {
        }
    }
}
