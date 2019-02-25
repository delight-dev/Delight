#region Using Statements
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using UnityEngine;
#endregion

namespace Delight
{
    /// <summary>
    /// ElementSize value converter.
    /// </summary>
    public class ElementSizeValueConverter : ValueConverter<ElementSize>
    {
        #region Methods

        /// <summary>
        /// Gets initializer from string value.
        /// </summary>
        public override string GetInitializer(string stringValue)
        {
            var convertedValue = Convert(stringValue);
            if (convertedValue.Unit == ElementSizeUnit.Pixels)
            {
                return String.Format(CultureInfo.InvariantCulture, "new ElementSize({0}f, ElementSizeUnit.Pixels)", convertedValue.Pixels);
            }
            else if (convertedValue.Unit == ElementSizeUnit.Percents)
            {                
                return String.Format(CultureInfo.InvariantCulture, "new ElementSize({0}f, ElementSizeUnit.Percents)", convertedValue.Percent);
            }
            else
            {
                return String.Format(CultureInfo.InvariantCulture, "new ElementSize({0}f, ElementSizeUnit.Proportional)", convertedValue.Proportion);
            }
        }

        /// <summary>
        /// Converts value from string.
        /// </summary>
        public override ElementSize Convert(string stringValue)
        {
            return ElementSize.Parse(stringValue);
        }

        /// <summary>
        /// Converts value from object.
        /// </summary>
        public override ElementSize Convert(object objectValue)
        {
            if (objectValue == null)
                return null;

            Type objectType = objectValue.GetType();
            if (objectType == typeof(string))
            {
                return Convert(objectValue as string);
            }
            else if (objectType == typeof(ElementSize))
            {
                return (ElementSize)objectValue;
            }

            throw new Exception(String.Format("Can't convert object of type \"{0}\" to ElementSize", objectType.Name));
        }

        #endregion
    }
}
