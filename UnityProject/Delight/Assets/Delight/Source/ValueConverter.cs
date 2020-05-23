#region Using Statements
using System;
using System.Collections.Generic;
using System.ComponentModel;
#endregion

namespace Delight
{
    /// <summary>
    /// Base class for value converters.
    /// </summary
    public class ValueConverter
    {
        #region Methods

        /// <summary>
        /// Gets initializer from string value.
        /// </summary>
        public virtual string GetInitializer(string stringValue)
        {
            return null;
        }

        /// <summary>
        /// Converts value from string.
        /// </summary>
        public virtual object ConvertGeneric(string stringValue)
        {
            return null;
        }

        /// <summary>
        /// Converts value from object.
        /// </summary>
        public virtual object ConvertGeneric(object objectValue)
        {
            return null;
        }

        /// <summary>
        /// Converts value to target type. 
        /// </summary>
        public virtual object ConvertToGeneric(object objectValue)
        {
            return objectValue;
        }

        /// <summary>
        /// Converts value from target type. 
        /// </summary>
        public virtual object ConvertFromGeneric(object objectValue)
        {
            return objectValue;
        }

        /// <summary>
        /// Interpolates values for type. 
        /// </summary>
        public virtual object InterpolateGeneric(object from, object to, float weight)
        {
            return weight < 1f ? from : to;
        }

        #endregion
    }

    /// <summary>
    /// Generic base class for value converters.
    /// </summary>
    public class ValueConverter<T> : ValueConverter
    {
        #region Fields

        public static readonly ValueConverter<T> Empty = new ValueConverter<T>();
                    
        #endregion

        #region Methods

        /// <summary>
        /// Converts value from string.
        /// </summary>
        public virtual T Convert(string stringValue)
        {
            return default(T);
        }

        /// <summary>
        /// Converts value from object.
        /// </summary>
        public virtual T Convert(object objectValue)
        {
            return default(T);
        }

        /// <summary>
        /// Converts value from string.
        /// </summary>
        public override object ConvertGeneric(string stringValue)
        {
            return Convert(stringValue);
        }

        /// <summary>
        /// Converts value from object.
        /// </summary>
        public override object ConvertGeneric(object objectValue)
        {
            return Convert(objectValue);
        }

        /// <summary>
        /// Interpolates value for type.
        /// </summary>
        public virtual T Interpolate(T from, T to, float weight)
        {
            return weight < 1f ? from : to;
        }

        /// <summary>
        /// Interpolates values for type. 
        /// </summary>
        public override object InterpolateGeneric(object from, object to, float weight)
        {
            return Interpolate((T)from, (T)to, weight);
        }

        /// <summary>
        /// Linear interpolation between two float values.
        /// </summary>
        public static float Lerp(float from, float to, float weight)
        {
            return (1f - weight) * from + weight * to;
        }

        #endregion

        #region Constructor
        #endregion
    }
}
