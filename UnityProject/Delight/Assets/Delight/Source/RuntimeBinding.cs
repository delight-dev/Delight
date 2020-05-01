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
            switch (BindingType)
            {
                case BindingType.SingleBinding:
                default:
                    var sourcePath = Sources[0] as RuntimeBindingPath;
                    var sourceObject = sourcePath.Objects.Last();
                    var value = sourceObject.GetPropertyValue(sourcePath.Properties.Last());
                    var transformedValue = value;

                    if (sourcePath.IsNegated)
                    {
                        transformedValue = !(bool)value;
                    }

                    if (sourcePath.ValueConverter != null)
                    {
                        transformedValue = sourcePath.ValueConverter.ConvertToGeneric(transformedValue);
                    }

                    var targetObject = Target.Objects.Last();
                    targetObject.SetPropertyValue(Target.Properties.Last(), transformedValue);
                    break;

                    //    case BindingType.MultiBindingTransform:
                    //        sourceToTargetValue = string.Format("{0}({1})", propertyBinding.TransformMethod, string.Join(", ", convertedSourceProperties));
                    //        break;

                    //    case BindingType.MultiBindingFormatString:
                    //        sourceToTargetValue = string.Format("String.Format(\"{0}\", {1})", propertyBinding.FormatString, string.Join(", ", convertedSourceProperties));
                    //        break;
            }
        }

        /// <summary>
        /// Propagates the target value to source. Used by runtime bindings.
        /// </summary>
        public void PropagateTargetToSourceMethod()
        {
            switch (BindingType)
            {
                case BindingType.SingleBinding:
                default:
                    var sourcePath = Sources[0] as RuntimeBindingPath;
                    var targetObject = Target.Objects.Last();
                    var value = targetObject.GetPropertyValue(Target.Properties.Last());
                    var transformedValue = value;

                    if (sourcePath.ValueConverter != null)
                    {
                        // convert value
                        transformedValue = sourcePath.ValueConverter.ConvertFromGeneric(transformedValue);
                    }

                    if (sourcePath.IsNegated)
                    {
                        transformedValue = !(bool)value;
                    }

                    var sourceObject = sourcePath.Objects.Last();
                    sourceObject.SetPropertyValue(sourcePath.Properties.Last(), transformedValue);
                    break;

                    //    case BindingType.MultiBindingTransform:
                    //        sourceToTargetValue = string.Format("{0}({1})", propertyBinding.TransformMethod, string.Join(", ", convertedSourceProperties));
                    //        break;

                    //    case BindingType.MultiBindingFormatString:
                    //        sourceToTargetValue = string.Format("String.Format(\"{0}\", {1})", propertyBinding.FormatString, string.Join(", ", convertedSourceProperties));
                    //        break;
            }
        }

        #endregion
    }
}
