#region Using Statements
using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
#endregion

namespace Delight
{
    /// <summary>
    /// Dependency property that notifies dependency object if property changes in dependency property object.
    /// </summary>
    public class BindableObjectDependencyProperty<T> : DependencyProperty<T>
        where T : BindableObject
    {
        #region Fields

        public Dictionary<DependencyObject, PropertyChangedEventHandler> PropertyChangedHandlers;

        #endregion

        #region Methods

        /// <summary>
        /// Sets dependency property value for specified instance.
        /// </summary>
        public override void SetValue(DependencyObject key, T value, bool notifyObservers = true)
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

            // detach old property changed listeners
            if (oldValue != null)
            {
                DetachPropertyChangedHandler(key, oldValue);
            }

            // attach new property changed listeners
            if (value != null)
            {
                AttachPropertyChangedHandler(key, value);
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
            key.OnPropertyChanged(PropertyName);
        }

        /// <summary>
        /// Attaches property changed handler. 
        /// </summary>
        private void AttachPropertyChangedHandler(DependencyObject key, T value)
        {
            // detach any existing event handlers
            DetachPropertyChangedHandler(key, value);

            // attach new event handler
            void eventHandler(object x, string y) => key.OnPropertyChanged(PropertyName);
            PropertyChangedHandlers.Add(key, eventHandler);
            value.PropertyChanged += eventHandler;
        }

        /// <summary>
        /// Detaches property changed handler from the object.
        /// </summary>
        private void DetachPropertyChangedHandler(DependencyObject key, T value)
        {
            PropertyChangedEventHandler eventHandler;
            if (PropertyChangedHandlers.TryGetValue(key, out eventHandler))
            {
                value.PropertyChanged -= eventHandler;
                PropertyChangedHandlers.Remove(key);
            }
        }

        /// <summary>
        /// Called when the dependency object has been loaded.
        /// </summary>
        public override void Load(DependencyObject key)
        {
            base.Load(key);

            // attach listeners
            var value = GetValue(key);
            if (value == null)
                return;

            AttachPropertyChangedHandler(key, value);

            // register reference if its an asset object
            if (value is AssetObject)
            {
                var assetObject = value as AssetObject;
                assetObject.RegisterReference(key);
            }

            // trigger initial property changed on load
            key.OnPropertyChanged(PropertyName);
        }

        /// <summary>
        /// Called when the dependency object has been unloaded. Clears run-time values for the specified instance.
        /// </summary>
        public override void Unload(DependencyObject key)
        {
            var value = GetValue(key);
            if (value == null)
            {
                base.Unload(key);
                return;
            }
            
            DetachPropertyChangedHandler(key, value);

            // trigger unload if its an asset object
            if (value is AssetObject)
            {
                var assetObject = value as AssetObject;
                assetObject.UnregisterReference(key);
            }           

            base.Unload(key);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public BindableObjectDependencyProperty(string propertyName) : base(propertyName)
        {
            PropertyChangedHandlers = new Dictionary<DependencyObject, PropertyChangedEventHandler>();
        }

        #endregion
    }
}
