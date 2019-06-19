#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class RectMask2D
    {
        /// <summary>
        /// Called just before the view and its children are loaded.
        /// </summary>
        protected override void BeforeLoad()
        {
            base.BeforeLoad();

            RectMask2DComponent = GameObject.AddComponent<UnityEngine.UI.RectMask2D>();
        }
    }
}
