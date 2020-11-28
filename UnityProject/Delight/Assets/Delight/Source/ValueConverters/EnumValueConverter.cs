#region Using Statements
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
#endregion

namespace Delight
{
    /// <summary>
    /// Enum value converter.
    /// </summary>
    public class EnumValueConverter<T> : ValueConverter<T>
    {
        #region Methods

        /// <summary>
        /// Gets initializer from string value.
        /// </summary>
        public override string GetInitializer(string stringValue)
        {
            var enumType = typeof(T);
            var enumTypeName = enumType.FullName.Replace('+', '.');

            if (stringValue.Contains("|"))
            {
                return String.Join(" | ", stringValue.Split('|').Select(x => String.Format("{0}.{1}", enumTypeName, (T)Enum.Parse(typeof(T), x, true))));
            }

            return String.Format("{0}.{1}", enumTypeName, (T)Enum.Parse(typeof(T), stringValue, true));
        }

        /// <summary>
        /// Converts value from string.
        /// </summary>
        public override T Convert(string stringValue)
        {
            return (T)Enum.Parse(typeof(T), stringValue, true);
        } 

        /// <summary>
        /// Converts value from object.
        /// </summary>
        public override T Convert(object objectValue)
        {
            if (objectValue == null)
                return default(T);

            return Convert(objectValue.ToString());
        }

        /// <summary>
        /// Interpolates value for type.
        /// </summary>
        public override T Interpolate(T from, T to, float weight)
        {
            return Interpolator(from, to, weight);
        }

        /// <summary>
        /// Interpolates value for type.
        /// </summary>
        public static T Interpolator(T from, T to, float weight)
        {
            return weight < 1f ? from : to;
        }

        /// <summary>
        /// Interpolates generic value for type.
        /// </summary>
        public override object InterpolateGeneric(object from, object to, float weight)
        {
            return Interpolate((T)from, (T)to, weight);
        }

        #endregion
    }
}
