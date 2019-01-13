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

        #endregion

        #region Constructor
        #endregion
    }
}
