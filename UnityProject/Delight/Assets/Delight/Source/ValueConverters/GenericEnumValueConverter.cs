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
    public class GenericEnumValueConverter : ValueConverter
    {
        #region Constructor

        private Type _enumType;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public GenericEnumValueConverter(Type enumType)
        {
            _enumType = enumType;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets initializer from string value.
        /// </summary>
        public override string GetInitializer(string stringValue)
        {
            var enumTypeName = _enumType.FullName.Replace('+', '.');

            if (stringValue.Contains("|"))
            {
                return String.Join(" | ", stringValue.Split('|').Select(x => String.Format("{0}.{1}", enumTypeName, Enum.Parse(_enumType, x, true))));
            }

            return String.Format("{0}.{1}", enumTypeName, Enum.Parse(_enumType, stringValue, true));
        }

        /// <summary>
        /// Converts value from string.
        /// </summary>
        public override object ConvertGeneric(string stringValue)
        {
            // used for runtime conversions of strings to enums
            return Enum.Parse(_enumType, stringValue, true);
        }

        /// <summary>
        /// Converts value from object.
        /// </summary>
        public override object ConvertGeneric(object objectValue)
        {
            if (objectValue is string)
            {
                return ConvertGeneric((string)objectValue);
            }
            return null;
        }
        
        #endregion
    }
}
