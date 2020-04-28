#region Using Statements
using System;
using System.Collections.Generic;
#endregion

namespace Delight
{
    /// <summary>
    /// Represents a runtime binding target or source. 
    /// </summary>
    public class RuntimeBindingPath : BindingPath
    {
        #region Fields

        public bool IsNegated;
        public ValueConverter ValueConverter;

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new instance of the class.
        /// </summary>
        public RuntimeBindingPath(List<string> properties, List<Func<BindableObject>> objectGetters, bool isNegated, ValueConverter valueConverter) : base(properties, objectGetters)
        {
            IsNegated = isNegated;
            ValueConverter = valueConverter;
        }

        #endregion
    }
}