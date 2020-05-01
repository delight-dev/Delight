#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
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

        #region Methods

        /// <summary>
        /// Gets value from binding path. 
        /// </summary>
        public object GetValue()
        {
            var obj = Objects.Last();
            var value = obj.GetPropertyValue(Properties.Last());
            var transformedValue = value;

            if (IsNegated)
            {
                transformedValue = !(bool)value;
            }

            if (ValueConverter != null)
            {
                transformedValue = ValueConverter.ConvertToGeneric(transformedValue);
            }

            return transformedValue; 
        }

        /// <summary>
        /// Sets value at binding path.
        /// </summary>
        public void SetValue(object value)
        {
            var obj = Objects.Last();
            var transformedValue = value;

            if (ValueConverter != null)
            {
                transformedValue = ValueConverter.ConvertFromGeneric(transformedValue);
            }

            if (IsNegated)
            {
                transformedValue = !(bool)value;
            }

            obj.SetPropertyValue(Properties.Last(), transformedValue);
        }

        #endregion
    }
}