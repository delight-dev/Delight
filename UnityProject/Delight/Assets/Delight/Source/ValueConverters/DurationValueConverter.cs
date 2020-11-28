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
    public class DurationValueConverter : ValueConverter<Duration>
    {
        #region Methods

        /// <summary>
        /// Gets initializer from string value.
        /// </summary>
        public override string GetInitializer(string stringValue)
        {
            var convertedValue = Convert(stringValue);
            return convertedValue.Value.ToString(CultureInfo.InvariantCulture) + "f";
        }

        /// <summary>
        /// Converts value from string.
        /// </summary>
        public override Duration Convert(string stringValue)
        {
            return Duration.Parse(stringValue);
        } 

        /// <summary>
        /// Converts value from object.
        /// </summary>
        public override Duration Convert(object objectValue)
        {
            if (objectValue == null)
                return Duration.Default;

            return System.Convert.ToSingle(objectValue, CultureInfo.InvariantCulture);            
        }

        /// <summary>
        /// Interpolates value for type.
        /// </summary>
        public override Duration Interpolate(Duration from, Duration to, float weight)
        {
            return Interpolator(from, to, weight);
        }

        /// <summary>
        /// Interpolates value for type.
        /// </summary>
        public static Duration Interpolator(Duration from, Duration to, float weight)
        {
            return Lerp(from, to, weight);
        }

        /// <summary>
        /// Interpolates generic value for type.
        /// </summary>
        public override object InterpolateGeneric(object from, object to, float weight)
        {
            return Interpolate((Duration)from, (Duration)to, weight);
        }

        #endregion
    }
}
