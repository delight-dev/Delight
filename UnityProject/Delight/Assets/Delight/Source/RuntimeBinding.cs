#region Using Statements
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using UnityEngine;
#endregion

namespace Delight
{
    /// <summary>
    /// Represents a runtime data-binding (single or multi-binding). 
    /// </summary>
    public class RuntimeBinding : Binding
    {
        #region Fields

        public BindingType BindingType;

        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new instance of the class. Used by runtime bindings.
        /// </summary>
        public RuntimeBinding(List<BindingPath> sources, BindingPath target, bool isTwoWay, BindingType bindingType) : base(sources, target, null, null, isTwoWay)
        {
            PropagateSourceToTarget = PropagateSourceToTargetMethod;
            PropagateTargetToSource = PropagateTargetToSourceMethod;
            BindingType = bindingType;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Propagates the source value to target. Used by runtime bindings.
        /// </summary>
        public void PropagateSourceToTargetMethod()
        {
            var runtimeBindingSource = Sources[0] as RuntimeBindingPath;
            var sourceObject = runtimeBindingSource.Objects.Last();
            var value = sourceObject.GetPropertyValue(runtimeBindingSource.Properties.Last());

            var targetObject = Target.Objects.Last();
            targetObject.SetPropertyValue(Target.Properties.Last(), value);
        }

        /// <summary>
        /// Propagates the target value to source. Used by runtime bindings.
        /// </summary>
        public void PropagateTargetToSourceMethod()
        {
        }

        #endregion
    }
}
