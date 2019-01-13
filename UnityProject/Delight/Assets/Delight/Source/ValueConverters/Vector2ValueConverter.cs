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
    /// Vector2 value converter.
    /// </summary>
    public class Vector2ValueConverter : ValueConverter<Vector2>
    {
        #region Methods

        /// <summary>
        /// Gets initializer from string value.
        /// </summary>
        public override string GetInitializer(string stringValue)
        {
            var convertedValue = Convert(stringValue);
            return String.Format(CultureInfo.InvariantCulture, "new Vector2({0}f, {1}f)", convertedValue.x, convertedValue.y);
        }

        /// <summary>
        /// Converts value from string.
        /// </summary>
        public override Vector2 Convert(string stringValue)
        {
            float[] valueList;
            valueList = stringValue.Split(',').Select(x => System.Convert.ToSingle(x, CultureInfo.InvariantCulture)).ToArray();

            if (valueList.Length == 1)
            {
                return new Vector2(valueList[0], valueList[0]);
            }
            else if (valueList.Length == 2)
            {
                return new Vector2(valueList[0], valueList[1]);
            }

            throw new Exception(String.Format("Improperly formatted string."));
        }

        /// <summary>
        /// Converts value from object.
        /// </summary>
        public override Vector2 Convert(object objectValue)
        {
            Type objectType = objectValue.GetType();
            if (objectType == typeof(string))
            {
                return Convert(objectValue as string);
            }
            else if (objectType == typeof(Vector2))
            {
                return (Vector2)objectValue;
            }

            throw new Exception(String.Format("Can't convert object of type \"{0}\" to Vector2.", objectType.Name));
        }

        #endregion
    }
}
