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
    public class ScrollbarVisibilityConverter
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

        #endregion
    }
}
