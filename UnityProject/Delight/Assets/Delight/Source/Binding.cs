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

        public Action PropagateSourceToTarget;
        public Action PropagateTargetToSource;
        public bool SourcesReachable;
        public bool IsTwoWay;
        public bool IsSimple;

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new instance of the class.
        /// </summary>
        public Binding(List<BindingPath> sources, BindingPath target, Action propagateSourceToTarget, Action propagateTargetToSource, bool isTwoWay)
        {
            Sources = sources;
            Target = target;
            Target.Binding = this;
            Target.IsTarget = true;
            Sources.ForEach(x => x.Binding = this);

            PropagateSourceToTarget = propagateSourceToTarget;
            PropagateTargetToSource = propagateTargetToSource;
            IsTwoWay = isTwoWay;
        }

        /// <summary>
        /// Creates a very simple binding that just propagates source to target on update. Used by embedded expressions without binding sources.
        /// </summary>
        public Binding(Action propagateSourceToTarget)
        {
            PropagateSourceToTarget = propagateSourceToTarget;
            IsSimple = true;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Updates the binding and propagates it. 
        /// </summary>
        public void UpdateBinding(bool propagateTargetToSource = false)
        {
            if (IsSimple)
            {
                PropagateSourceToTarget();
                return;
            }

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
                PropagateSourceToTarget();
            }
            else
            {
                if (IsTwoWay)
                {
                    PropagateTargetToSource();
                }
            }
        }

        /// <summary>
        /// Returns boolean indicating if binding has target object.
        /// </summary>
        public bool HasTarget(DependencyObject targetObject)
        {
            return IsSimple ? false : Target.Objects.Contains(targetObject);
        }

        #endregion
    }
}
