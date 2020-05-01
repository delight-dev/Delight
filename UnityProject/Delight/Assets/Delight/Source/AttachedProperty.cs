#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
#endregion

namespace Delight
{
    /// <summary>
    /// Base class for attached properties. Attached properties allows values to be associated with views, e.g. <Label Grid.Cell="1,1" /> tells the parent Grid which cell the label should be in.
    /// </summary>
    public class AttachedProperty<T> : AttachedProperty
    {
        #region Fields

        private Dictionary<object, T> _attachedValues;
        private BindableObject _parent;
        private string _propertyName;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public AttachedProperty(BindableObject parent, string propertyName)
        {
            _attachedValues = new Dictionary<object, T>();
            _parent = parent;
            _propertyName = propertyName;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Sets attached value and notifies parent.
        /// </summary>
        public void SetValue(object child, T value)
        {
            if (_attachedValues == null)
            {
                _attachedValues = new Dictionary<object, T>();
                _attachedValues.Add(child, value);
                return;
            }

            T oldValue;
            if (_attachedValues.TryGetValue(child, out oldValue))
            {
                if (Equals(oldValue, value))
                {
                    return;
                }                
            }

            _attachedValues[child] = value;
            _parent.OnPropertyChanged(_propertyName);
        }

        /// <summary>
        /// Gets attached property value.
        /// </summary>
        public T GetValue(object child)
        {
            if (_attachedValues == null)
                return default(T);
                       
            T value;
            if (_attachedValues.TryGetValue(child, out value))
            {
                return value;
            }

            return default(T);
        }

        /// <summary>
        /// Tries getting attached property value.
        /// </summary>
        public bool TryGetValue(object child, out T value)
        {
            value = default(T);
            return _attachedValues != null ? _attachedValues.TryGetValue(child, out value) : false;
        }

        /// <summary>
        /// Sets attached value and notifies parent.
        /// </summary>
        public override void SetValueGeneric(object child, object value)
        {
            SetValue(child, (T)value);
        }

        /// <summary>
        /// Gets attached property value.
        /// </summary>
        public override object GetValueGeneric(object child)
        {
            return GetValue(child);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets attached values.
        /// </summary>
        public Dictionary<object, T> AttachedValues
        {
            get
            {
                return _attachedValues;
            }
        }

        #endregion
    }

    /// <summary>
    /// Generic base class for attached properties.
    /// </summary>
    public class AttachedProperty
    {
        #region Methods

        /// <summary>
        /// Sets attached value and notifies parent.
        /// </summary>
        public virtual void SetValueGeneric(object child, object value)
        {
        }

        /// <summary>
        /// Gets attached property value.
        /// </summary>
        public virtual object GetValueGeneric(object child)
        {
            return null;
        }

        #endregion
    }
}
