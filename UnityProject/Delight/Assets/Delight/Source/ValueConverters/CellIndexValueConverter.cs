#region Using Statements
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using UnityEngine;
#endregion

namespace Delight
{
    /// <summary>
    /// CellIndex value converter.
    /// </summary>
    public class CellIndexValueConverter : ValueConverter<CellIndex>
    {
        #region Methods

        /// <summary>
        /// Gets initializer from string value.
        /// </summary>
        public override string GetInitializer(string stringValue)
        {
            int[] valueList;
            valueList = stringValue.Split(',').Select(x => System.Convert.ToInt32(x, CultureInfo.InvariantCulture)).ToArray();

            if (valueList.Length == 1)
            {
                return String.Format(CultureInfo.InvariantCulture, "new CellIndex({0}, 0)", valueList[0]);
            }
            else if (valueList.Length == 2)
            {
                return String.Format(CultureInfo.InvariantCulture, "new CellIndex({0}, {1})", valueList[0], valueList[1]);
            }

            throw new Exception(String.Format("Improperly formatted string."));            
        }

        /// <summary>
        /// Converts value from string.
        /// </summary>
        public override CellIndex Convert(string stringValue)
        {
            return null;
        }

        /// <summary>
        /// Converts value from object.
        /// </summary>
        public override CellIndex Convert(object objectValue)
        {
            return null;
        }

        #endregion
    }
}
