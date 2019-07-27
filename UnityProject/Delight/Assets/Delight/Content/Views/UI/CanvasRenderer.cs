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
    public partial class CanvasRendererView
    {
        #region Methods

        /// <summary>
        /// Called before the view is loaded.
        /// </summary>
        protected override void BeforeLoad()
        {
            if (IgnoreObject)
                return;
            base.BeforeLoad();

            CanvasRendererComponent = GameObject.AddComponent<CanvasRenderer>();
            CanvasRendererComponent.SetMaterial(Graphic.defaultGraphicMaterial, Texture2D.whiteTexture);

            var maskableComponent = GameObject.AddComponent<MaskableComponent>();
            maskableComponent.color = Color.clear;
        }

        #endregion
    }
}
