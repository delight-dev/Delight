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
    /// Quaternion value converter.
    /// </summary>
    public class QuaternionValueConverter : ValueConverter<Quaternion>
    {
        #region Methods

        /// <summary>
        /// Gets initializer from string value.
        /// </summary>
        public override string GetInitializer(string stringValue)
        {
            var convertedValue = Convert(stringValue);
            return String.Format(CultureInfo.InvariantCulture, "Quaternion.Euler({0}f, {1}f, {2}f)", convertedValue.x, convertedValue.y, convertedValue.z);
        }

        /// <summary>
        /// Converts value from string.
        /// </summary>
        public override Quaternion Convert(string stringValue)
        {
            float[] valueList;
            valueList = stringValue.Split(',').Select(x => System.Convert.ToSingle(x, CultureInfo.InvariantCulture)).ToArray();

            if (valueList.Length == 1)
            {
                return Quaternion.Euler(new Vector3(valueList[0], valueList[0], valueList[0]));
            }
            else if (valueList.Length == 2)
            {
                return Quaternion.Euler( new Vector3(valueList[0], valueList[1]));
            }
            else if (valueList.Length == 3)
            {
                return Quaternion.Euler(new Vector3(valueList[0], valueList[1], valueList[2]));
            }

            throw new Exception(String.Format("Improperly formatted string."));
        }

        /// <summary>
        /// Converts value from object.
        /// </summary>
        public override Quaternion Convert(object objectValue)
        {
            Type objectType = objectValue.GetType();
            if (objectType == typeof(string))
            {
                return Convert(objectValue as string);
            }
            else if (objectType == typeof(Quaternion))
            {
                return (Quaternion)objectValue;
            }
            else if(objectType == typeof(Vector3))
            {
                return Quaternion.Euler((Vector3)objectValue);
            }

            throw new Exception(String.Format("Can't convert object of type \"{0}\" to Quaternion.", objectType.Name));
        }

        /// <summary>
        /// Interpolates value for type.
        /// </summary>
        public override Quaternion Interpolate(Quaternion from, Quaternion to, float weight)
        {
            return Interpolator(from, to, weight);
        }

        /// <summary>
        /// Interpolates value for type.
        /// </summary>
        public static Quaternion Interpolator(Quaternion from, Quaternion to, float weight)
        {
            return Quaternion.Lerp(from, to, weight);
        }

        #endregion
    }
}
