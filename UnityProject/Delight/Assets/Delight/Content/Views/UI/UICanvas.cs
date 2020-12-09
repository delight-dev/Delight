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
        #region Fields

        private Vector2 _defaultReferenceResolution;
        private float _defaultMatch;

        #endregion

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

        protected override void AfterLoad()
        {
            base.AfterLoad();

            if (AdjustToScreenOrientation != AdjustToScreenOrientation.Never)
            {
                if (!ReferenceResolutionProperty.IsUndefined(this))
                {
                    _defaultReferenceResolution = ReferenceResolution;
                    _defaultMatch = MatchWidthOrHeight;
                }

                Models.Globals.PropertyChanged -= Globals_PropertyChanged;
                Models.Globals.PropertyChanged += Globals_PropertyChanged;
            }
        }

        protected override void AfterUnload()
        {
            base.AfterUnload();

            if (AdjustToScreenOrientation != AdjustToScreenOrientation.Never)
            {
                Models.Globals.PropertyChanged -= Globals_PropertyChanged;
            }
        }

        private void Globals_PropertyChanged(object source, string propertyName)
        {
            if (propertyName == nameof(Models.Globals.IsPortrait))
            {
                if (!ReferenceResolutionProperty.IsUndefined(this))
                {
                    if (AdjustToScreenOrientation == AdjustToScreenOrientation.SwapResolutionAndMatchInPortrait)
                    {
                        ReferenceResolution = Models.Globals.IsPortrait ? new Vector2(_defaultReferenceResolution.y, _defaultReferenceResolution.x) : _defaultReferenceResolution;
                        if (ScreenMatchMode == CanvasScaler.ScreenMatchMode.MatchWidthOrHeight)
                        {
                            MatchWidthOrHeight = Models.Globals.IsPortrait ? 1 - _defaultMatch : _defaultMatch;
                        }
                    }
                    else if (AdjustToScreenOrientation == AdjustToScreenOrientation.SwapResolutionAndMatchInLandscape)
                    {
                        ReferenceResolution = Models.Globals.IsLandscape ? new Vector2(_defaultReferenceResolution.y, _defaultReferenceResolution.x) : _defaultReferenceResolution;
                        if (ScreenMatchMode == CanvasScaler.ScreenMatchMode.MatchWidthOrHeight)
                        {
                            MatchWidthOrHeight = Models.Globals.IsLandscape ? 1 - _defaultMatch : _defaultMatch;
                        }
                    }
                }
            }
        }

        #endregion
    }

    /// <summary>
    /// Enum indicating how canvas to adjust to screen orientation. Can be used to retain UI proportions as the screen orientation changes.
    /// </summary>
    public enum AdjustToScreenOrientation
    {
        Never = 0,
        SwapResolutionAndMatchInPortrait = 1,
        SwapResolutionAndMatchInLandscape = 2,
    }
}
