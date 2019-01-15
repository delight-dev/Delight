#region Using Statements
using System;
using System.Collections.Generic;
using System.ComponentModel;
#endregion

namespace Delight
{
    public class BindableObjectBinding
    {
        #region Fields

        private Func<BindableObject> _sourceObjectGetter;
        private Func<BindableObject> _targetObjectGetter;
        private Action _propagateSourcePropertyValue;
        private Action _propagateTargetPropertyValue;
        private string _sourceProperty;
        private string _targetProperty;
        private BindableObject _sourceObject;
        private BindableObject _targetObject;

        #endregion

        #region Constructor

        public BindableObjectBinding(string sourceProperty, string targetProperty,
            Func<BindableObject> sourceObjectGetter, Func<BindableObject> targetObjectGetter,
            Action propagateSourcePropertyValue, Action propagateTargetPropertyValue)
        {
            _sourceProperty = sourceProperty;
            _targetProperty = targetProperty;
            _sourceObjectGetter = sourceObjectGetter;
            _targetObjectGetter = targetObjectGetter;
            _propagateSourcePropertyValue = propagateSourcePropertyValue;
            _propagateTargetPropertyValue = propagateTargetPropertyValue;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Updates the binding. 
        /// </summary>
        public void UpdateBinding()
        {
            // detach any existing property changed listeners
            if (_sourceObject != null) _sourceObject.PropertyChanged -= SourcePropertyChanged;
            if (_targetObject != null) _targetObject.PropertyChanged -= TargetPropertyChanged;

            // get source and target objects
            _sourceObject = _sourceObjectGetter();
            _targetObject = _targetObjectGetter();

            // attach property changed listeners
            if (_sourceObject != null) _sourceObject.PropertyChanged += SourcePropertyChanged;
            if (_targetObject != null) _targetObject.PropertyChanged += TargetPropertyChanged;

            // trigger source changed
            if (_sourceObject != null) SourcePropertyChanged(_sourceObject, _sourceProperty);
        }

        /// <summary>
        /// Called when a property in the binding source has been changed.
        /// </summary>
        public void SourcePropertyChanged(object source, string property)
        {
            if (property == _sourceProperty) _propagateSourcePropertyValue();
        }

        /// <summary>
        /// Called when a property in the binding target has been changed.
        /// </summary>
        public void TargetPropertyChanged(object source, string property)
        {
            if (property == _targetProperty) _propagateTargetPropertyValue();
        }

        #endregion

        #region Properties

        public BindableObject SourceObject
        {
            get
            {
                return _sourceObjectGetter(); // TODO here we can perhaps return _sourceObject instead
            }
        }

        public BindableObject TargetObject
        {
            get
            {
                return _targetObjectGetter();
            }
        }

        #endregion
    }
}
