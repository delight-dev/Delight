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
    /// The canvas view is used to render UI components and controls things like draw sort order, scaling and render mode. Can also be used to reduce draw calls by sectioning off portion of the UI (i.e. that changes a lot) into a separate canvas.
    /// </summary>
    public partial class UICanvas
    {
        #region Methods

        protected override void BeforeLoad()
        {
            base.BeforeLoad();
            if (IgnoreObject)
                return;

            Canvas = GameObject.AddComponent<UnityEngine.Canvas>();
            CanvasScaler = GameObject.AddComponent<UnityEngine.UI.CanvasScaler>();
            GraphicRaycaster = GameObject.AddComponent<UnityEngine.UI.GraphicRaycaster>();

            if (RenderCamera != null)
            {
                var camera = GameObject.Find(RenderCamera);
                if (camera != null)
                {
                    var cameraComponent = camera.GetComponent<UnityEngine.Camera>();
                    WorldCamera = cameraComponent;
                }
            }
        }

        #endregion
    }
}
