#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
#endregion

namespace Delight
{
    public partial class DefaultExpanderHeader
    {
        #region Methods

        

        /// <summary>
        /// Updates layout.
        /// </summary>
        public override bool UpdateLayout(bool notifyParent = true)
        {
            bool hasNewSize = false;
            var newWidth = new ElementSize(HeaderGroup.ActualWidth, ElementSizeUnit.Pixels);
            if (!newWidth.Equals(Width))
            {
                WidthProperty.SetValue(this, newWidth, false);
                hasNewSize = true;
            }

            return base.UpdateLayout(notifyParent) || hasNewSize;
        }

        #endregion
    }
}
