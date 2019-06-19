#region Using Statements
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
#endregion

namespace Delight
{
    /// <summary>
    /// String value converter.
    /// </summary>
    public class StringValueConverter : ValueConverter<string>
    {
        #region Fields               
        #endregion

        #region Methods

        /// <summary>
        /// Gets initializer from string value.
        /// </summary>
        public override string GetInitializer(string stringValue)
        {
            return stringValue != null ? "\"" + stringValue + "\"" : "\"\"";
        }

        /// <summary>
        /// Converts value from string.
        /// </summary>
        public override string Convert(string stringValue)
        {
            return stringValue;
        }

        /// <summary>
        /// Converts value from object.
        /// </summary>
        public override string Convert(object objectValue)
        {
            if (objectValue == null)
                return default(string);

            return System.Convert.ToString(objectValue, CultureInfo.InvariantCulture);
        }

        public string ConvertTo(object value)
        {
            return Convert(value);
        }

        public object ConvertFrom(string value)
        {
            return null;
        }

        #endregion
    }
}
