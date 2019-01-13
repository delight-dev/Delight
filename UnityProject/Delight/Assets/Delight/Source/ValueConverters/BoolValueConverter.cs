#region Using Statements
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
#endregion

namespace Delight
{
    /// <summary>
    /// Bool value converter.
    /// </summary>
    public class BoolValueConverter : ValueConverter<bool>
    {
        #region Methods

        /// <summary>
        /// Gets initializer from string value.
        /// </summary>
        public override string GetInitializer(string stringValue)
        {
            var convertedValue = Convert(stringValue);
            return convertedValue ? "true" : "false";
        }

        /// <summary>
        /// Converts value from string.
        /// </summary>
        public override bool Convert(string stringValue)
        {
            return System.Boolean.Parse(stringValue);
        }

        /// <summary>
        /// Converts value from object.
        /// </summary>
        public override bool Convert(object objectValue)
        {
            if (objectValue == null)
                return default(bool);

            return System.Convert.ToBoolean(objectValue);
        }

        #endregion
    }
}
