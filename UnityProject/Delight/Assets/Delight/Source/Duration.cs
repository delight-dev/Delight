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
    /// Represents a duration in seconds.
    /// </summary>
    [Serializable]
    public class Duration : AtomicBindableObject
    {
        #region Fields

        [SerializeField]
        private float _value;
        public float Value
        {
            get { return _value; }
            set { SetProperty(ref _value, value); }
        }

        public static readonly Duration Default = new Duration();

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public Duration()
        {
            _value = 0f;
        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="value">Duration in seconds.</param>
        public Duration(float value)
        {
            _value = value;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Converts float to Duration.
        /// </summary>
        public static implicit operator Duration(float value)
        {
            return new Duration(value);
        }


        /// <summary>
        /// Converts Duration to float.
        /// </summary>
        public static implicit operator float(Duration duration)
        {
            return duration != null ? duration.Value : 0;
        }

        /// <summary>
        /// Parses string into duration.
        /// </summary>
        public static Duration Parse(string stringValue)
        {
            float duration = 0;
            string trimmedValue = stringValue.Trim();
            if (trimmedValue.EndsWith("ms", StringComparison.OrdinalIgnoreCase))
            {
                int lastIndex = trimmedValue.LastIndexOf("ms", StringComparison.OrdinalIgnoreCase);
                duration = System.Convert.ToSingle(trimmedValue.Substring(0, lastIndex), CultureInfo.InvariantCulture) / 1000f;
            }
            else if (trimmedValue.EndsWith("s", StringComparison.OrdinalIgnoreCase))
            {
                int lastIndex = trimmedValue.LastIndexOf("s", StringComparison.OrdinalIgnoreCase);
                duration = System.Convert.ToSingle(trimmedValue.Substring(0, lastIndex), CultureInfo.InvariantCulture);
            }
            else if (trimmedValue.EndsWith("min", StringComparison.OrdinalIgnoreCase))
            {
                int lastIndex = trimmedValue.LastIndexOf("min", StringComparison.OrdinalIgnoreCase);
                duration = System.Convert.ToSingle(trimmedValue.Substring(0, lastIndex), CultureInfo.InvariantCulture) * 60f;
            }
            else
            {
                duration = System.Convert.ToSingle(trimmedValue, CultureInfo.InvariantCulture);
            }

            return duration;
        }

        /// <summary>
        /// Converts element size to string.
        /// </summary>
        public override string ToString()
        {
            return Value.ToString();
        }

        /// <summary>
        /// Compares sizes.
        /// </summary>
        public override bool Equals(object obj)
        {
            var duration = obj as Duration;
            return (duration != null) && (duration.Value == Value);
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
