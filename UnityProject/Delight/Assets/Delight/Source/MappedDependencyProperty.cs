#region Using Statements
using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
#endregion

namespace Delight
{   
    /// <summary>
    /// Dependency property that maps to another property or field.
    /// </summary>
    public class MappedDependencyProperty<T, TObject, TParent> : DependencyProperty
        where TParent : DependencyObject
    {
        #region Fields

        public Dictionary<DependencyObject, bool> ValueSet;
        public Dictionary<Template, T> Defaults;
        public Func<TParent, TObject> ObjectGetter;
        public Func<TObject, T> Getter;
        public Action<TObject, T> Setter;

        #endregion

        #region Methods

        /// <summary>
        /// Gets mapped dependency property value for specified instance.
        /// </summary>
        public T GetValue(DependencyObject key)
        {
            bool valueSet = false;
            ValueSet.TryGetValue(key, out valueSet);

            var target = ObjectGetter((TParent)key);
            if (valueSet && target != null)
            {
                return Getter(target);
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
            key.NotifyPropertyChanged(key, this);
        }

        /// <summary>
        /// Checks if dependency property value is undefined (no run-time or default value set). Mainly used check if values of non-nullable types has been set.
        /// </summary>
        public bool IsUndefined(DependencyObject key)
        {
            bool valueSet = false;
            ValueSet.TryGetValue(key, out valueSet);
            if (valueSet)
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
        /// Initializes the mapped dependency property.
        /// </summary>
        public override void Initialize(DependencyObject key)
        {
            base.Initialize(key);

            var target = ObjectGetter((TParent)key);
            if (target == null)
                return;

            bool valueSet = false;
            ValueSet.TryGetValue(key, out valueSet);
            if (valueSet) // TODO any reason to do this check here?
                return;

            // set default value if specified
            var template = key.Template;
            while (true)
            {
                T defaultValue;
                if (Defaults.TryGetValue(template, out defaultValue))
                {
                    Setter(target, defaultValue);
                    return;
                }

                template = template.BasedOn;
                if (template == ViewTemplates.Default)
                {
                    return;
                }
            }
        }

        #endregion        

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public MappedDependencyProperty(Func<TParent, TObject> objectGetter, Func<TObject, T> getter, Action<TObject, T> setter)
        {
            ValueSet = new Dictionary<DependencyObject, bool>();
            Defaults = new Dictionary<Template, T>();
            Getter = getter;
            Setter = setter;
            ObjectGetter = objectGetter;
        }

        #endregion
    }
}
