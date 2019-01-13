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
    /// Vector3 value converter.
    /// </summary>
    public class Vector3ValueConverter : ValueConverter<Vector3>
    {
        #region Methods

        /// <summary>
        /// Gets initializer from string value.
        /// </summary>
        public override string GetInitializer(string stringValue)
        {
            var convertedValue = Convert(stringValue);
            return String.Format(CultureInfo.InvariantCulture, "new Vector3({0}f, {1}f, {2}f)", convertedValue.x, convertedValue.y, convertedValue.z);
        }

        /// <summary>
        /// Converts value from string.
        /// </summary>
        public override Vector3 Convert(string stringValue)
        {
            float[] valueList;
            valueList = stringValue.Split(',').Select(x => System.Convert.ToSingle(x, CultureInfo.InvariantCulture)).ToArray();

            if (valueList.Length == 1)
            {
                return new Vector3(valueList[0], valueList[0], valueList[0]);
            }
            else if (valueList.Length == 2)
            {
                return new Vector3(valueList[0], valueList[1]);
            }
            else if (valueList.Length == 3)
            {
                return new Vector3(valueList[0], valueList[1], valueList[2]);
            }

            throw new Exception(String.Format("Improperly formatted string."));
        }

        /// <summary>
        /// Converts value from object.
        /// </summary>
        public override Vector3 Convert(object objectValue)
        {
            Type objectType = objectValue.GetType();
            if (objectType == typeof(string))
            {
                return Convert(objectValue as string);
            }
            else if (objectType == typeof(Vector3))
            {
                return (Vector3)objectValue;
            }

            throw new Exception(String.Format("Can't convert object of type \"{0}\" to Vector3.", objectType.Name));
        }

        #endregion
    }
}
