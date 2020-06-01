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
            int[] valueList;
            valueList = stringValue.Split(',').Select(x => System.Convert.ToInt32(x, CultureInfo.InvariantCulture)).ToArray();

            if (valueList.Length == 1)
            {
                return new CellIndex(valueList[0], 0);
            }
            else if (valueList.Length == 2)
            {
                return new CellIndex(valueList[0], valueList[1]);
            }

            throw new Exception(String.Format("Improperly formatted string."));
        }

        /// <summary>
        /// Converts value from object.
        /// </summary>
        public override CellIndex Convert(object objectValue)
        {
            if (objectValue == null)
                return default(CellIndex);

            Type objectType = objectValue.GetType();
            if (objectType == typeof(string))
            {
                return Convert(objectValue as string);
            }
            else if (objectType == typeof(CellIndex))
            {
                return (CellIndex)objectValue;
            }

            throw new Exception(String.Format("Can't convert object of type \"{0}\" to {1}", objectType.Name, nameof(CellIndex)));
        }

        /// <summary>
        /// Interpolates value for type.
        /// </summary>
        public override CellIndex Interpolate(CellIndex from, CellIndex to, float weight)
        {
            return Interpolator(from, to, weight);
        }

        /// <summary>
        /// Interpolates value for type.
        /// </summary>
        public static CellIndex Interpolator(CellIndex from, CellIndex to, float weight)
        {
            if (from == null || to == null)
                return weight < 1f ? from : to;

            return new CellIndex((int)Math.Round(Lerp(from.Row, to.Row, weight)), (int)Math.Round(Lerp(from.Column, to.Column, weight)));
        }

        #endregion
    }
}
