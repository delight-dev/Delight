#region Using Statements
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
#endregion

namespace Delight
{
    /// <summary>
    /// Int value converter.
    /// </summary>
    public class IntValueConverter : ValueConverter<int>
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
            return convertedValue.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Converts value from string.
        /// </summary>
        public override int Convert(string stringValue)
        {
            return System.Convert.ToInt32(stringValue, CultureInfo.InvariantCulture);
        } 

        /// <summary>
        /// Converts value from object.
        /// </summary>
        public override int Convert(object objectValue)
        {
            if (objectValue == null)
                return default(int);

            return System.Convert.ToInt32(objectValue, CultureInfo.InvariantCulture);            
        }

        /// <summary>
        /// Interpolates value for type.
        /// </summary>
        public override int Interpolate(int from, int to, float weight)
        {
            return Interpolator(from, to, weight);
        }

        /// <summary>
        /// Interpolates value for type.
        /// </summary>
        public static int Interpolator(int from, int to, float weight)
        {
            return (int)Math.Round(Lerp(from, to, weight));
        }

        #endregion
    }
}
