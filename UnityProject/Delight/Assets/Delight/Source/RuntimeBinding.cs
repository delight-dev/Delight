#region Using Statements
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
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

        public Func<object[], object> TransformMethod;
        public string FormatString;
        public BindingType BindingType;

        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new instance of the class. Used by runtime bindings.
        /// </summary>
        public RuntimeBinding(List<BindingPath> sources, BindingPath target, bool isTwoWay, BindingType bindingType, Func<object[], object> transformMethod, string formatString) : base(sources, target, null, null, isTwoWay)
        {
            PropagateSourceToTarget = PropagateSourceToTargetMethod;
            PropagateTargetToSource = PropagateTargetToSourceMethod;
            BindingType = bindingType;
            TransformMethod = transformMethod;
            FormatString = formatString;
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
                    var source = Sources[0] as RuntimeBindingPath;
                    var value = source.GetValue();

                    var target = Target as RuntimeBindingPath;
                    target.SetValue(value);
                    break;


                case BindingType.MultiBindingTransform:
                    if (TransformMethod == null)
                        return;

                    var transformSourceValues = Sources.Select(x => (x as RuntimeBindingPath).GetValue()).ToArray();
                    var transformedValue = TransformMethod(transformSourceValues);

                    var transformTarget = Target as RuntimeBindingPath;
                    transformTarget.SetValue(transformedValue);
                    break;

                case BindingType.MultiBindingFormatString:
                    var formatSourceValues = Sources.Select(x => (x as RuntimeBindingPath).GetValue()).ToArray();
                    var formattedValue = String.Format(FormatString, formatSourceValues);

                    var formatStringTarget = Target as RuntimeBindingPath;
                    formatStringTarget.SetValue(formattedValue);
                    break;

                default:
                    break;
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
                    var target = Target as RuntimeBindingPath;
                    var value = target.GetValue();

                    var source = Sources[0] as RuntimeBindingPath;
                    source.SetValue(value);
                    break;

                case BindingType.MultiBindingTransform:
                case BindingType.MultiBindingFormatString:
                default:
                    break;
            }
        }

        #endregion
    }
}
