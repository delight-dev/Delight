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

        #endregion
    }
}
