#region Using Statements
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using UnityEngine;
#endregion

namespace Delight
{
    /// <summary>
    /// ElementMargin value converter.
    /// </summary>
    public class ElementMarginValueConverter : ValueConverter<ElementMargin>
    {
        #region Methods

        /// <summary>
        /// Gets initializer from string value.
        /// </summary>
        public override string GetInitializer(string stringValue)
        {
            var elementSizeConverter = new ElementSizeValueConverter();

            string[] valueList;
            valueList = stringValue.Split(',').ToArray();
            if (valueList.Length == 1)
            {
                return String.Format(CultureInfo.InvariantCulture, "new ElementMargin({0})",
                    elementSizeConverter.GetInitializer(valueList[0]));
            }
            else if (valueList.Length == 2)
            {
                return String.Format(CultureInfo.InvariantCulture, "new ElementMargin({0}, {1})",
                    elementSizeConverter.GetInitializer(valueList[0]),
                    elementSizeConverter.GetInitializer(valueList[1]));
            }
            else if (valueList.Length == 3)
            {
                return String.Format(CultureInfo.InvariantCulture, "new ElementMargin({0}, {1}, {2})",
                    elementSizeConverter.GetInitializer(valueList[0]),
                    elementSizeConverter.GetInitializer(valueList[1]),
                    elementSizeConverter.GetInitializer(valueList[2]));
            }
            else if (valueList.Length == 4)
            {
                return String.Format(CultureInfo.InvariantCulture, "new ElementMargin({0}, {1}, {2}, {3})",
                    elementSizeConverter.GetInitializer(valueList[0]),
                    elementSizeConverter.GetInitializer(valueList[1]),
                    elementSizeConverter.GetInitializer(valueList[2]),
                    elementSizeConverter.GetInitializer(valueList[3]));
            }

            throw new Exception(String.Format("Improperly formatted string."));
        }

        /// <summary>
        /// Converts value from string.
        /// </summary>
        public override ElementMargin Convert(string stringValue)
        { 
            string[] valueList;
            valueList = stringValue.Split(',').ToArray();
            if (valueList.Length == 1)
            {
                return new ElementMargin(ElementSize.Parse(valueList[0]));
            }
            else if (valueList.Length == 2)
            {
                return new ElementMargin(
                    ElementSize.Parse(valueList[0]),
                    ElementSize.Parse(valueList[1]));
            }
            else if (valueList.Length == 3)
            {
                return new ElementMargin(
                    ElementSize.Parse(valueList[0]),
                    ElementSize.Parse(valueList[1]),
                    ElementSize.Parse(valueList[2]));
            }
            else if (valueList.Length == 4)
            {
                return new ElementMargin(
                    ElementSize.Parse(valueList[0]),
                    ElementSize.Parse(valueList[1]),
                    ElementSize.Parse(valueList[2]),
                    ElementSize.Parse(valueList[3]));
            }

            throw new Exception(String.Format("Improperly formatted string."));
        }

        /// <summary>
        /// Converts value from object.
        /// </summary>
        public override ElementMargin Convert(object objectValue)
        {
            if (objectValue == null)
                return null;

            Type objectType = objectValue.GetType();
            if (objectType == typeof(string))
            {
                return Convert(objectValue as string);
            }
            else if (objectType == typeof(ElementMargin))
            {
                return (ElementMargin)objectValue;
            }

            throw new Exception(String.Format("Can't convert object of type \"{0}\" to ElementMargin.", objectType.Name));
        }

        /// <summary>
        /// Interpolates value for type.
        /// </summary>
        public override ElementMargin Interpolate(ElementMargin from, ElementMargin to, float weight)
        {
            return Interpolator(from, to, weight);
        }

        /// <summary>
        /// Interpolates value for type.
        /// </summary>
        public static ElementMargin Interpolator(ElementMargin from, ElementMargin to, float weight)
        {           
            if (from == null || to == null)
                return weight < 1f ? from : to;

            return new ElementMargin(
                ElementSizeValueConverter.Interpolator(from.Left, to.Left, weight),
                ElementSizeValueConverter.Interpolator(from.Top, to.Top, weight),
                ElementSizeValueConverter.Interpolator(from.Right, to.Right, weight),
                ElementSizeValueConverter.Interpolator(from.Bottom, to.Bottom, weight));
        }

        #endregion
    }
}
