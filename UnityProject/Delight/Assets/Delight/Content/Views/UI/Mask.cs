#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    /// <summary>
    /// A view that masks any content using the background sprite and color as mask.
    /// </summary>
    public partial class Mask : UIImageView
    {
        /// <summary>
        /// Called just before the view and its children are loaded.
        /// </summary>
        protected override void BeforeLoad()
        {
            base.BeforeLoad();

            MaskComponent = GameObject.AddComponent<UnityEngine.UI.Mask>();
        }
    }

}
