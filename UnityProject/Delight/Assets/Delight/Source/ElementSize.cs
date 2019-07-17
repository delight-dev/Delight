#region Using Statements
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnityEngine;
#endregion

namespace Delight
{
    /// <summary>
    /// Represents size in pixels or percentage of an element. 
    /// </summary>
    [Serializable]
    public class ElementSize : AtomicBindableObject
    {
        #region Fields

        [SerializeField]
        private float _value;
        public float Value
        {
            get { return _value; }
            set { SetProperty(ref _value, value); }
        }

        [SerializeField]
        private ElementSizeUnit _unit;
        public ElementSizeUnit Unit
        {
            get { return _unit; }
            set { SetProperty(ref _unit, value); }
        }
        
        /// <summary>
        /// Gets or sets element size in pixels.
        /// </summary>
        public float Pixels
        {
            get
            {
                if (_unit == ElementSizeUnit.Pixels)
                {
                    return _value;
                }
                else
                {
                    return 0f;
                }
            }
            set
            {
                _unit = ElementSizeUnit.Pixels;
                Value = value;
            }
        }

        /// <summary>
        /// Gets or sets element size in percents.
        /// </summary>
        public float Percent
        {
            get
            {
                return _unit == ElementSizeUnit.Percents || _unit == ElementSizeUnit.Proportional ? _value : 0f;
            }
            set
            {
                _unit = ElementSizeUnit.Percents;
                Value = value;
            }
        }

        /// <summary>
        /// Gets or sets element size in proportions.
        /// </summary>
        public float Proportion
        {
            get
            {
                return _unit == ElementSizeUnit.Percents || _unit == ElementSizeUnit.Proportional ? _value : 0f;
            }
            set
            {
                _unit = ElementSizeUnit.Proportional;
                Value = value;
            }
        }

        public static readonly ElementSize Default = new ElementSize();
        public static readonly ElementSize DefaultLayout = new ElementSize(1.0f, ElementSizeUnit.Percents);

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public ElementSize()
        {
            _value = 0f;
            _unit = ElementSizeUnit.Pixels;
        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public ElementSize(float pixels)
        {
            _value = pixels;
            _unit = ElementSizeUnit.Pixels;
        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="value">Size in pixels or percent. Percentages are specified in the range 0-1.</param>
        /// <param name="unit">Specifies if the size is in pixels or percents.</param>
        public ElementSize(float value, ElementSizeUnit unit)
        {
            _value = value;
            _unit = unit;
        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public ElementSize(ElementSize elementSize)
        {
            if (elementSize == null)
            {
                _value = 0.0f;
                _unit = ElementSizeUnit.Pixels;
            }
            else
            {
                _value = elementSize.Value;
                _unit = elementSize.Unit;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Converts float to element size.
        /// </summary>
        public static implicit operator ElementSize(float value)
        {
            return ElementSize.FromPixels(value);
        }


        /// <summary>
        /// Converts element size to float.
        /// </summary>
        public static implicit operator float(ElementSize value)
        {
            return value != null ? value.Pixels : 0;
        }

        /// <summary>
        /// Gets element size with the specified pixel size.
        /// </summary>
        public static ElementSize FromPixels(float pixels)
        {
            return new ElementSize(pixels, ElementSizeUnit.Pixels);
        }

        /// <summary>
        /// Gets element size with the specified percent size (0.0 - 1.0).
        /// </summary>
        public static ElementSize FromPercents(float percents)
        {
            return new ElementSize(percents, ElementSizeUnit.Percents);
        }

        /// <summary>
        /// Gets element size with the specified proportion.
        /// </summary>
        public static ElementSize FromProportion(float proportion)
        {
            return new ElementSize(proportion, ElementSizeUnit.Proportional);
        }

        /// <summary>
        /// Parses string into element size.
        /// </summary>
        public static ElementSize Parse(string value)
        {
            ElementSize elementSize = new ElementSize();
            string trimmedValue = value.Trim();
            if (trimmedValue.EndsWith("*"))
            {
                int lastIndex = trimmedValue.LastIndexOf("*", StringComparison.OrdinalIgnoreCase);
                var proportion = lastIndex > 0 ? System.Convert.ToSingle(trimmedValue.Substring(0, lastIndex), CultureInfo.InvariantCulture) : 1.0f;
                elementSize.Value = proportion;
                elementSize.Unit = ElementSizeUnit.Proportional;
            }
            else if (trimmedValue.EndsWith("%"))
            {
                int lastIndex = trimmedValue.LastIndexOf("%", StringComparison.OrdinalIgnoreCase);
                elementSize.Value = System.Convert.ToSingle(trimmedValue.Substring(0, lastIndex), CultureInfo.InvariantCulture) / 100.0f;
                elementSize.Unit = ElementSizeUnit.Percents;
            }
            else if (trimmedValue.EndsWith("px"))
            {
                int lastIndex = trimmedValue.LastIndexOf("px", StringComparison.OrdinalIgnoreCase);
                elementSize.Value = System.Convert.ToSingle(trimmedValue.Substring(0, lastIndex), CultureInfo.InvariantCulture);
                elementSize.Unit = ElementSizeUnit.Pixels;
            }
            else
            {
                elementSize.Value = System.Convert.ToSingle(trimmedValue, CultureInfo.InvariantCulture);
                elementSize.Unit = ElementSizeUnit.Pixels;
            }

            return elementSize;
        }

        /// <summary>
        /// Converts element size to string.
        /// </summary>
        public override string ToString()
        {
            if (Unit == ElementSizeUnit.Percents)
            {
                return (Value * 100).ToString() + "%";
            }
            else
            {
                return Value.ToString();
            }
        }

        /// <summary>
        /// Compares sizes.
        /// </summary>
        public override bool Equals(object obj)
        {
            var elementSize = obj as ElementSize;
            return (elementSize != null) && (elementSize.Unit == Unit) && (elementSize.Value == Value);
        }

        /// <summary>
        /// Gets hashcode.
        /// </summary>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion
    }
}
