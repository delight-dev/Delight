#region Using Statements
using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    /// <summary>
    /// Enables culling of meshes rendered by the CanvasRenderer component.
    /// </summary>
    public class MaskableComponent : MaskableGraphic
    {
        /// <summary>
        /// Override to Cull function of MaskableGraphic to prevent Culling.
        /// </summary>
        public override void Cull(Rect clipRect, bool validRect)
        {
        }
    }
}
