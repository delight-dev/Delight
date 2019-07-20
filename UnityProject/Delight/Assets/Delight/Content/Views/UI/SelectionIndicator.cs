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
    /// <summary>
    /// Renders a selection box around the parent view. Used by the designer and live editor to indicate selected view. 
    /// </summary>
    public partial class SelectionIndicator
    {
        #region Methods

        /// <summary>
        /// Called by designer to make the view presentable in the designer.
        /// </summary>
        public override void PrepareForDesigner()
        {
            base.PrepareForDesigner();
            Width = 500;
            Height = 500;
        }

        #endregion
    }
}
