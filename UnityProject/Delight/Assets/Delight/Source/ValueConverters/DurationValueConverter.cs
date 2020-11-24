#region Using Statements
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
#endregion

namespace Delight
{
    /// <summary>
    /// Duration value converter.
    /// </summary>
    public class DurationValueConverter : ValueConverter<float>
    {
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
            float duration = 0;
            string trimmedValue = stringValue.Trim();
            if (trimmedValue.EndsWith("ms", StringComparison.OrdinalIgnoreCase))
            {
                int lastIndex = trimmedValue.LastIndexOf("ms", StringComparison.OrdinalIgnoreCase);
                duration = System.Convert.ToSingle(trimmedValue.Substring(0, lastIndex), CultureInfo.InvariantCulture) / 1000f;
            }
            else if (trimmedValue.EndsWith("s", StringComparison.OrdinalIgnoreCase))
            {
                int lastIndex = trimmedValue.LastIndexOf("s", StringComparison.OrdinalIgnoreCase);
                duration = System.Convert.ToSingle(trimmedValue.Substring(0, lastIndex), CultureInfo.InvariantCulture);
            }
            else if (trimmedValue.EndsWith("min", StringComparison.OrdinalIgnoreCase))
            {
                int lastIndex = trimmedValue.LastIndexOf("min", StringComparison.OrdinalIgnoreCase);
                duration = System.Convert.ToSingle(trimmedValue.Substring(0, lastIndex), CultureInfo.InvariantCulture) * 60f;
            }
            else
            {
                duration = System.Convert.ToSingle(trimmedValue, CultureInfo.InvariantCulture);
            }

            return duration;
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
    }
}
