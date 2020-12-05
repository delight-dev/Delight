#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
#endregion

namespace Delight
{
    public class BindingPath
    {
        #region Fields

        public List<Func<object>> ObjectGetters;
        public List<string> Properties;
        public List<object> Objects;
        public bool IsReachable;
        public Binding Binding;
        public bool IsTarget;
        private object _oldValue; 

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new instance of the class.
        /// </summary>
        public BindingPath(List<string> properties, List<Func<object>> objectGetters)
        {
            Properties = properties;
            ObjectGetters = objectGetters;
            Objects = new List<object>();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Called when a property in the binding sources has been changed.
        /// </summary>
        public void PropertyChanged(object source, string property)
        {
            int index = Objects.IndexOf(source as BindableObject);
            if (index < 0) return;

            // is the binding to this property?
            if (property != Properties[index])
                return; // no.

            // does the binding need to be updated?
            if (!Binding.SourcesReachable || !Binding.Target.IsReachable)
            {
                // yes. the binding hasn't been connected yet
                Binding.UpdateBinding(true, IsTarget);
                return;
            }

            if (index < Objects.Count - 1)
            {
                // yes. the bindable object changed is not last in chain
                Binding.UpdateBinding(true, IsTarget);
                return;
            }

            if (IsTarget)
            {
                if (Binding.IsTwoWay)
                {
                    Binding.PropagateTargetToSource();
                }
            }
            else
            {
                Binding.PropagateSourceToTarget();
            }
        }

        /// <summary>
        /// Checks the binding has changed and propagates changes. Used when binding to non-bindable objects. Returns true if binding has changed.
        /// </summary>
        public bool OnUpdate(bool hasUpdatedPreviously)
        {
            // check if any object along the chain has been updated
            for (int i = 0; i < Objects.Count; ++i)
            {
                var oldObject = Objects[i];
                var obj = ObjectGetters[i]();
                if (oldObject != obj)
                {
                    Debug.Log("Non-bindable object changed"); // TODO cleanup
                    Binding.UpdateBinding(hasUpdatedPreviously, IsTarget);
                    return true;
                }
            }

            // check if value has changed
            if (Binding.SourcesReachable && Binding.Target.IsReachable)
            {
                var obj = ObjectGetters.Last()();
                object currentValue = obj.GetPropertyValue(Properties.Last());

                // has value changed?
                if (_oldValue != null ? _oldValue.Equals(currentValue) : currentValue == null)
                {
                    return hasUpdatedPreviously; // no.
                }

                _oldValue = currentValue;
                if (IsTarget)
                {
                    if (Binding.IsTwoWay)
                    {
                        Binding.PropagateTargetToSource();
                    }
                }
                else
                {
                    Binding.PropagateSourceToTarget();
                }

                return true;
            }

            return hasUpdatedPreviously;
        }

        #endregion
    }
}