#region Using Statements
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
#endregion

namespace Delight
{
    /// <summary>
    /// Float value converter.
    /// </summary>
    public class FloatValueConverter : ValueConverter<float>
    {
        #region Fields
        #endregion

        #region Methods

        /// <summary>
        /// Gets initializer from string value.
        /// </summary>
        public override string GetInitializer(string stringValue)
        {
            var convertedValue = Convert(stringValue);
            return convertedValue.ToString(CultureInfo.InvariantCulture) + "f";
        }

        /// <summary>
        /// Converts value from string.
        /// </summary>
        public override float Convert(string stringValue)
        {
            return System.Convert.ToSingle(stringValue, CultureInfo.InvariantCulture);
        } 

        /// <summary>
        /// Converts value from object.
        /// </summary>
        public override float Convert(object objectValue)
        {
            if (objectValue == null)
                return default(float);

            return System.Convert.ToSingle(objectValue, CultureInfo.InvariantCulture);            
        }

        /// <summary>
        /// Interpolates value for type.
        /// </summary>
        public override float Interpolate(float from, float to, float weight)
        {
            return Interpolator(from, to, weight);
        }

        /// <summary>
        /// Interpolates value for type.
        /// </summary>
        public static float Interpolator(float from, float to, float weight)
        {
            return Lerp(from, to, weight);
        }

        #endregion

        #region Constructor
        #endregion
    }
}
