#region Using Statements
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
#endregion

namespace Delight
{
    /// <summary>
    /// Asset value converter.
    /// </summary>
    public class AssetObjectValueConverter
    {
        #region Methods

        /// <summary>
        /// Gets initializer from string value.
        /// </summary>
        public static string GetInitializer(string typeName, string stringValue)
        {
            if (String.IsNullOrEmpty(stringValue))
            {
                return "null";
            }

            return String.Format("Assets.{0}[\"{1}\"]", typeName.Pluralize(), stringValue);
        }        

        #endregion
    }
}
