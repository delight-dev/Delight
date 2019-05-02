#region Using Statements
using System;
using System.Collections.Generic;
#endregion

namespace Delight
{
    /// <summary>
    /// Represents a binding target or source. 
    /// </summary>
    public class BindingPath
    {
        #region Fields

        public List<Func<BindableObject>> ObjectGetters;
        public List<string> Properties;
        public List<BindableObject> Objects;
        public bool IsReachable;
        public Binding Binding;
        public bool IsTarget; 

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new instance of the class.
        /// </summary>
        public BindingPath(List<string> properties, List<Func<BindableObject>> objectGetters)
        {
            Properties = properties;
            ObjectGetters = objectGetters;
            Objects = new List<BindableObject>();
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
                Binding.UpdateBinding(IsTarget);
                return;
            }

            if (index < Objects.Count - 1)
            {
                // yes. the bindable object changed is not last in chain
                Binding.UpdateBinding(IsTarget);
                return;
            }

            //LogPropagation();
            if (IsTarget)
            {
                if (Binding.IsTwoWay)
                {
                    Binding.PropagateTargetPropertyValue();
                }
            }
            else
            {
                Binding.PropagateSourcePropertyValue();
            }
        }

        #endregion
    }
}