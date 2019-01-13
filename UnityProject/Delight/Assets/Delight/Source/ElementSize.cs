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
    /// Represents size in pixels or percentage.
    /// </summary>
    [Serializable]
    public class ElementSize
    {
        #region Fields

        [SerializeField]
        private float _value;

        [SerializeField]
        private ElementSizeUnit _unit;

        [SerializeField]
        private bool _fill;

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
            _value = elementSize.Value;
            _unit = elementSize.Unit;
            _fill = elementSize.Fill;
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
        /// Parses string into element size.
        /// </summary>
        public static ElementSize Parse(string value)
        {
            ElementSize elementSize = new ElementSize();
            string trimmedValue = value.Trim();
            if (trimmedValue == "*")
            {
                elementSize.Value = 1;
                elementSize.Unit = ElementSizeUnit.Percents;
                elementSize.Fill = true;
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
                return Value.ToString() + "%";
            }
            else
            {
                return Value.ToString();
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets element size value.
        /// </summary>
        public float Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
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
        }

        /// <summary>
        /// Gets or sets element size in percents.
        /// </summary>
        public float Percent
        {
            get
            {
                return _unit == ElementSizeUnit.Percents ? _value : 0f;
            }
        }

        /// <summary>
        /// Gets or sets element size unit.
        /// </summary>
        public ElementSizeUnit Unit
        {
            get
            {
                return _unit;
            }
            set
            {
                _unit = value;
            }
        }

        /// <summary>
        /// Gets or sets boolean indicating if element size is to fill out remaining space (used by DataGrid).
        /// </summary>
        public bool Fill
        {
            get
            {
                return _fill;
            }
            set
            {
                _fill = value;
            }
        }

        #endregion
    }
}
