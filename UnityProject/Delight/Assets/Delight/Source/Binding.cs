#region Using Statements
using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
#endregion

namespace Delight
{
    public class Binding
    {
        #region Fields

        private List<Func<BindableObject>> _sourceObjectGetters;
        private List<Func<BindableObject>> _targetObjectGetters;
        private Action _propagateSourcePropertyValue;
        private Action _propagateTargetPropertyValue;
        private List<string> _sourceProperties;
        private List<string> _targetProperties;
        private List<BindableObject> _sourceObjects;
        private List<BindableObject> _targetObjects;
        private bool _sourceReachable;
        private bool _targetReachable;

        #endregion

        #region Constructor

        public Binding(List<string> sourceProperties, List<string> targetProperties,
            List<Func<BindableObject>> sourceObjectGetters, List<Func<BindableObject>> targetObjectGetters,
            Action propagateSourcePropertyValue, Action propagateTargetPropertyValue)
        {
            _sourceProperties = sourceProperties;
            _targetProperties = targetProperties;
            _sourceObjectGetters = sourceObjectGetters;
            _targetObjectGetters = targetObjectGetters;
            _propagateSourcePropertyValue = propagateSourcePropertyValue;
            _propagateTargetPropertyValue = propagateTargetPropertyValue;
            _sourceObjects = new List<BindableObject>();
            _targetObjects = new List<BindableObject>();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Updates the binding and propagates it. 
        /// </summary>
        public void UpdateBinding(bool propagateTargetToSource = false)
        {
            // detach any existing property changed listeners
            foreach (var sourceObject in _sourceObjects)
            {
                sourceObject.PropertyChanged -= SourcePropertyChanged;
            }

            foreach (var targetObject in _targetObjects)
            {
                targetObject.PropertyChanged -= TargetPropertyChanged;
            }

            // get source and target objects and attach property changed listeners
            _sourceObjects.Clear();
            _sourceReachable = true;
            foreach (var sourceObjectGetter in _sourceObjectGetters)
            {
                var sourceObject = sourceObjectGetter();
                if (sourceObject == null)
                {
                    _sourceReachable = false;
                    break;
                }

                _sourceObjects.Add(sourceObject);
                sourceObject.PropertyChanged += SourcePropertyChanged;
            }

            _targetObjects.Clear();
            _targetReachable = true;
            foreach (var targetObjectGetter in _targetObjectGetters)
            {
                var targetObject = targetObjectGetter();
                if (targetObject == null)
                {
                    _targetReachable = false;
                    break;
                }

                _targetObjects.Add(targetObject);
                targetObject.PropertyChanged += TargetPropertyChanged;
            }

            // propagate value
            if (_sourceReachable && _targetReachable)
            {
                //LogPropagation(propagateTargetToSource);
                if (!propagateTargetToSource)
                {
                    _propagateSourcePropertyValue();
                }
                else
                {
                    _propagateTargetPropertyValue();
                }
            }
        }

        /// <summary>
        /// Called when a property in the binding sources has been changed.
        /// </summary>
        public void SourcePropertyChanged(object source, string property)
        {
            int index = _sourceObjects.IndexOf(source as BindableObject);
            if (index < 0) return;

            // is the binding to this property?
            if (property != _sourceProperties[index])
                return; // no.

            // does the binding need to be updated?
            if (!_sourceReachable || !_targetReachable)
            {
                // yes. the binding hasn't been connected yet
                UpdateBinding();
                return;
            }

            if (index < _sourceObjects.Count - 1)
            {
                // yes. the bindable object changed is not last in chain
                UpdateBinding();
                return;
            }

            //LogPropagation();
            _propagateSourcePropertyValue();
        }

        /// <summary>
        /// Called when a property in the binding targets has been changed.
        /// </summary>
        public void TargetPropertyChanged(object source, string property)
        {
            int index = _targetObjects.IndexOf(source as BindableObject);
            if (index < 0) return;

            // is the binding to this property?
            if (property != _targetProperties[index])
                return; // no.

            // does the binding need to be updated?
            if (!_sourceReachable || !_targetReachable)
            {
                // yes. the binding hasn't been connected yet
                UpdateBinding(true);
                return;
            }

            if (index < _targetObjects.Count - 1)
            {
                // yes. the bindable object changed is not last in chain
                UpdateBinding(true);
                return;
            }

            //LogPropagation(true);
            _propagateTargetPropertyValue();
        }

        /// <summary>
        /// Logs binding propagation for debugging purposes.
        /// </summary>
        public void LogPropagation(bool targetToSource = false)
        {
            string leftHand = targetToSource ? string.Join(".", _sourceProperties) :
                string.Join(".", _targetProperties);
            string rightHand = targetToSource ? string.Join(".", _targetProperties) :
                string.Join(".", _sourceProperties);
            Debug.Log(String.Format("Propagating {0} = {1}", leftHand, rightHand));
        }

        #endregion

        #region Properties

        public List<BindableObject> SourceObjects => _sourceObjects;
        public List<BindableObject> TargetObjects => _targetObjects;

        #endregion
    }
}
