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
    public class Binding : IUpdateable
    {
        #region Fields

        public List<BindingPath> Sources;
        public BindingPath Target;

        public Action PropagateSourceToTarget;
        public Action PropagateTargetToSource;
        public bool SourcesReachable;
        public bool IsTwoWay;
        public bool IsSimple;
        public LayoutRoot LayoutRoot;
        public bool HasRegisteredInLayoutRoot;

        private static Type BindableObjectType = typeof(BindableObject);

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
        /// Called each frame and tracks changes in non-bindable objects.
        /// </summary>
        public void OnUpdate()
        {
            bool hasUpdated = false;

            // track changes in source and propagate value to target
            foreach (var source in Sources)
            {
                hasUpdated = source.OnUpdate(hasUpdated);
            }

            if (IsTwoWay)
            {
                Target.OnUpdate(hasUpdated);
            }
        }

        /// <summary>
        /// Updates the binding and propagates it. 
        /// </summary>
        public void UpdateBinding(bool propagateValues = true, bool propagateTargetToSource = false, LayoutRoot layoutRoot = null)
        {
            if (layoutRoot != null)
            {
                LayoutRoot = layoutRoot;
            }

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
                    RemoveChangeListener(source, sourceObject);
                }
            }

            if (IsTwoWay)
            {
                foreach (var targetObject in Target.Objects)
                {
                    RemoveChangeListener(Target, targetObject);
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
                    AddChangeListener(source, sourceObject);
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
                    AddChangeListener(Target, targetObject);
                }
            }

            // propagate value if sources and target can be reached
            if (!Target.IsReachable || !SourcesReachable)
                return;

            //LogPropagation(propagateTargetToSource);
            if (propagateValues)
            {
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
        }

        /// <summary>
        /// Returns boolean indicating if binding has target object.
        /// </summary>
        public bool HasTarget(object targetObject)
        {
            return IsSimple ? false : Target.Objects.Contains(targetObject);
        }

        /// <summary>
        /// Adds change listener to object.
        /// </summary>
        private void AddChangeListener(BindingPath source, object sourceObject)
        {
            if (BindableObjectType.IsAssignableFrom(sourceObject.GetType()))
            {
                var bindableSourceObject = sourceObject as BindableObject;
                bindableSourceObject.PropertyChanged += source.PropertyChanged;
            }
            else
            {
                if (!HasRegisteredInLayoutRoot)
                {
                    LayoutRoot.RegisterUpdateable(this);
                    HasRegisteredInLayoutRoot = true;
                }
            }
        }

        /// <summary>
        /// Removes change listener from object.
        /// </summary>
        private void RemoveChangeListener(BindingPath source, object sourceObject)
        {
            if (BindableObjectType.IsAssignableFrom(sourceObject.GetType()))
            {
                var bindableSourceObject = sourceObject as BindableObject;
                bindableSourceObject.PropertyChanged -= source.PropertyChanged;
            }
        }

        #endregion
    }
}
