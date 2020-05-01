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
    /// ScrollbarVisibility converter.
    /// </summary>
    public class ScrollbarVisibilityConverter : ValueConverter
    {
        #region Methods

        public bool ConvertTo(ScrollbarVisibilityMode value)
        {
            return value == ScrollbarVisibilityMode.Always;
        }

        public ScrollbarVisibilityMode ConvertFrom(bool value)
        {
            return value ? ScrollbarVisibilityMode.Always : ScrollbarVisibilityMode.Never;
        }

        public override object ConvertToGeneric(object objectValue)
        {
            return ConvertTo((ScrollbarVisibilityMode)objectValue);
        }

        public override object ConvertFromGeneric(object objectValue)
        {
            return ConvertFrom((bool)objectValue);
        }

        #endregion
    }
}
