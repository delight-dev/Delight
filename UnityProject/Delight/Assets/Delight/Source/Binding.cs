#region Using Statements
using System;
using System.Collections.Generic;
using System.ComponentModel;
#endregion

namespace Delight
{
    public class Binding
    {
        #region Fields

        private Func<DependencyObject> _sourceObjectGetter;
        private Func<DependencyObject> _targetObjectGetter;
        private Action _propagateSourcePropertyValue;
        private Action _propagateTargetPropertyValue;
        private DependencyProperty _sourceProperty;
        private DependencyProperty _targetProperty;
        private DependencyObject _sourceObject;
        private DependencyObject _targetObject;

        #endregion

        #region Constructor

        public Binding(DependencyProperty sourceProperty, DependencyProperty targetProperty,
            Func<DependencyObject> sourceObjectGetter, Func<DependencyObject> targetObjectGetter,
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
        public void SourcePropertyChanged(DependencyObject source, DependencyProperty property)
        {
            if (property == _sourceProperty) _propagateSourcePropertyValue();
        }

        /// <summary>
        /// Called when a property in the binding target has been changed.
        /// </summary>
        public void TargetPropertyChanged(DependencyObject source, DependencyProperty property)
        {
            if (property == _targetProperty) _propagateTargetPropertyValue();
        }

        #endregion

        #region Properties

        public DependencyObject SourceObject
        {
            get
            {
                return _sourceObjectGetter(); // TODO here we can perhaps return _sourceObject instead
            }
        }

        public DependencyObject TargetObject
        {
            get
            {
                return _targetObjectGetter();
            }
        }

        #endregion
    }
}
