#region Using Statements
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
#endregion

namespace Delight
{
    /// <summary>
    /// Converts between values.
    /// </summary>
    public partial class ConvertValue
    {
        #region Methods

        /// <summary>
        /// Converts string to int.
        /// </summary>
        public static int IntFromString(string stringValue)
        {
            // TODO another way is to add extension methods to the type so we get:
            // int.ConvertFromString(), etc.
            return Convert.ToInt32(stringValue, CultureInfo.InvariantCulture);                        
        }

        #endregion
    }
}
