#region Using Statements
using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
#endregion

namespace Delight
{
    /// <summary>
    /// Represents a data-binding (single or multi-binding). 
    /// </summary>
    public class Binding
    {
        #region Fields

        public List<BindingPath> Sources;
        public BindingPath Target;

        public Action PropagateSourcePropertyValue;
        public Action PropagateTargetPropertyValue;
        public bool SourcesReachable;
        public bool IsTwoWay;

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new instance of the class.
        /// </summary>
        public Binding(List<BindingPath> sources, BindingPath target, Action propagateSourcePropertyValue, Action propagateTargetPropertyValue, bool isTwoWay)
        {
            Sources = sources;
            Target = target;
            Target.Binding = this;
            Target.IsTarget = true;
            Sources.ForEach(x => x.Binding = this);

            PropagateSourcePropertyValue = propagateSourcePropertyValue;
            PropagateTargetPropertyValue = propagateTargetPropertyValue;
            IsTwoWay = isTwoWay;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Updates the binding and propagates it. 
        /// </summary>
        public void UpdateBinding(bool propagateTargetToSource = false)
        {
            // detach any existing property changed listeners
            foreach (var source in Sources)
            {
                foreach (var sourceObject in source.Objects)
                {
                    sourceObject.PropertyChanged -= source.PropertyChanged;
                }
            }

            if (IsTwoWay)
            {
                foreach (var targetObject in Target.Objects)
                {
                    targetObject.PropertyChanged -= Target.PropertyChanged;
                }
            }

            // get source and target objects and attach property changed listeners
            SourcesReachable = true;
            foreach (var source in Sources)
            {
                source.Objects.Clear();
                source.IsReachable = true;
                foreach (var sourceObjectGetter in source.ObjectGetters)
                {
                    var sourceObject = sourceObjectGetter();
                    if (sourceObject == null)
                    {
                        source.IsReachable = false;
                        SourcesReachable = false;
                        break;
                    }

                    source.Objects.Add(sourceObject);
                    sourceObject.PropertyChanged += source.PropertyChanged;
                }
            }

            Target.Objects.Clear();
            Target.IsReachable = true;
            foreach (var targetObjectGetter in Target.ObjectGetters)
            {
                var targetObject = targetObjectGetter();
                if (targetObject == null)
                {
                    Target.IsReachable = false;
                    break;
                }

                Target.Objects.Add(targetObject);

                if (IsTwoWay)
                {
                    targetObject.PropertyChanged += Target.PropertyChanged;
                }
            }

            // propagate value if sources and target can be reached
            if (!Target.IsReachable || !SourcesReachable)
                return;

            //LogPropagation(propagateTargetToSource);
            if (!propagateTargetToSource)
            {
                PropagateSourcePropertyValue();
            }
            else
            {
                if (IsTwoWay)
                {
                    PropagateTargetPropertyValue();
                }
            }
        }

        #endregion
    }
}
