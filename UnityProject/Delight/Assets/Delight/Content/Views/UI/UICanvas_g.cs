// Internal view logic generated from "UICanvas.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class UICanvas : UIView
    {
        #region Constructors

        public UICanvas(View parent, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :
            base(parent, layoutParent, id, template ?? UICanvasTemplates.Default, initializer)
        {
            this.AfterInitializeInternal();
        }

        public UICanvas() : this(null)
        {
        }

        static UICanvas()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(UICanvasTemplates.Default, dependencyProperties);

            dependencyProperties.Add(CanvasProperty);
            dependencyProperties.Add(CanvasScalerProperty);
            dependencyProperties.Add(GraphicRaycasterProperty);
            dependencyProperties.Add(RenderCameraProperty);
            dependencyProperties.Add(RenderModeProperty);
            dependencyProperties.Add(ScaleFactorProperty);
            dependencyProperties.Add(ReferencePixelsPerUnitProperty);
            dependencyProperties.Add(OverridePixelPerfectProperty);
            dependencyProperties.Add(PixelPerfectProperty);
            dependencyProperties.Add(PlaneDistanceProperty);
            dependencyProperties.Add(OverrideSortingProperty);
            dependencyProperties.Add(SortingOrderProperty);
            dependencyProperties.Add(TargetDisplayProperty);
            dependencyProperties.Add(SortingLayerIDProperty);
            dependencyProperties.Add(AdditionalShaderChannelsProperty);
            dependencyProperties.Add(SortingLayerNameProperty);
            dependencyProperties.Add(WorldCameraProperty);
            dependencyProperties.Add(NormalizedSortingGridSizeProperty);
            dependencyProperties.Add(UiScaleModeProperty);
            dependencyProperties.Add(CanvasScalerReferencePixelsPerUnitProperty);
            dependencyProperties.Add(CanvasScalerScaleFactorProperty);
            dependencyProperties.Add(ReferenceResolutionProperty);
            dependencyProperties.Add(ScreenMatchModeProperty);
            dependencyProperties.Add(MatchWidthOrHeightProperty);
            dependencyProperties.Add(PhysicalUnitProperty);
            dependencyProperties.Add(FallbackScreenDPIProperty);
            dependencyProperties.Add(DefaultSpriteDPIProperty);
            dependencyProperties.Add(DynamicPixelsPerUnitProperty);
            dependencyProperties.Add(IgnoreReversedGraphicsProperty);
            dependencyProperties.Add(BlockingObjectsProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<UnityEngine.Canvas> CanvasProperty = new DependencyProperty<UnityEngine.Canvas>("Canvas");
        public UnityEngine.Canvas Canvas
        {
            get { return CanvasProperty.GetValue(this); }
            set { CanvasProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<UnityEngine.UI.CanvasScaler> CanvasScalerProperty = new DependencyProperty<UnityEngine.UI.CanvasScaler>("CanvasScaler");
        public UnityEngine.UI.CanvasScaler CanvasScaler
        {
            get { return CanvasScalerProperty.GetValue(this); }
            set { CanvasScalerProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<UnityEngine.UI.GraphicRaycaster> GraphicRaycasterProperty = new DependencyProperty<UnityEngine.UI.GraphicRaycaster>("GraphicRaycaster");
        public UnityEngine.UI.GraphicRaycaster GraphicRaycaster
        {
            get { return GraphicRaycasterProperty.GetValue(this); }
            set { GraphicRaycasterProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.String> RenderCameraProperty = new DependencyProperty<System.String>("RenderCamera");
        public System.String RenderCamera
        {
            get { return RenderCameraProperty.GetValue(this); }
            set { RenderCameraProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<UnityEngine.RenderMode, UnityEngine.Canvas, UICanvas> RenderModeProperty = new MappedDependencyProperty<UnityEngine.RenderMode, UnityEngine.Canvas, UICanvas>("RenderMode", x => x.Canvas, x => x.renderMode, (x, y) => x.renderMode = y);
        public UnityEngine.RenderMode RenderMode
        {
            get { return RenderModeProperty.GetValue(this); }
            set { RenderModeProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Single, UnityEngine.Canvas, UICanvas> ScaleFactorProperty = new MappedDependencyProperty<System.Single, UnityEngine.Canvas, UICanvas>("ScaleFactor", x => x.Canvas, x => x.scaleFactor, (x, y) => x.scaleFactor = y);
        public System.Single ScaleFactor
        {
            get { return ScaleFactorProperty.GetValue(this); }
            set { ScaleFactorProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Single, UnityEngine.Canvas, UICanvas> ReferencePixelsPerUnitProperty = new MappedDependencyProperty<System.Single, UnityEngine.Canvas, UICanvas>("ReferencePixelsPerUnit", x => x.Canvas, x => x.referencePixelsPerUnit, (x, y) => x.referencePixelsPerUnit = y);
        public System.Single ReferencePixelsPerUnit
        {
            get { return ReferencePixelsPerUnitProperty.GetValue(this); }
            set { ReferencePixelsPerUnitProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Boolean, UnityEngine.Canvas, UICanvas> OverridePixelPerfectProperty = new MappedDependencyProperty<System.Boolean, UnityEngine.Canvas, UICanvas>("OverridePixelPerfect", x => x.Canvas, x => x.overridePixelPerfect, (x, y) => x.overridePixelPerfect = y);
        public System.Boolean OverridePixelPerfect
        {
            get { return OverridePixelPerfectProperty.GetValue(this); }
            set { OverridePixelPerfectProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Boolean, UnityEngine.Canvas, UICanvas> PixelPerfectProperty = new MappedDependencyProperty<System.Boolean, UnityEngine.Canvas, UICanvas>("PixelPerfect", x => x.Canvas, x => x.pixelPerfect, (x, y) => x.pixelPerfect = y);
        public System.Boolean PixelPerfect
        {
            get { return PixelPerfectProperty.GetValue(this); }
            set { PixelPerfectProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Single, UnityEngine.Canvas, UICanvas> PlaneDistanceProperty = new MappedDependencyProperty<System.Single, UnityEngine.Canvas, UICanvas>("PlaneDistance", x => x.Canvas, x => x.planeDistance, (x, y) => x.planeDistance = y);
        public System.Single PlaneDistance
        {
            get { return PlaneDistanceProperty.GetValue(this); }
            set { PlaneDistanceProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Boolean, UnityEngine.Canvas, UICanvas> OverrideSortingProperty = new MappedDependencyProperty<System.Boolean, UnityEngine.Canvas, UICanvas>("OverrideSorting", x => x.Canvas, x => x.overrideSorting, (x, y) => x.overrideSorting = y);
        public System.Boolean OverrideSorting
        {
            get { return OverrideSortingProperty.GetValue(this); }
            set { OverrideSortingProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Int32, UnityEngine.Canvas, UICanvas> SortingOrderProperty = new MappedDependencyProperty<System.Int32, UnityEngine.Canvas, UICanvas>("SortingOrder", x => x.Canvas, x => x.sortingOrder, (x, y) => x.sortingOrder = y);
        public System.Int32 SortingOrder
        {
            get { return SortingOrderProperty.GetValue(this); }
            set { SortingOrderProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Int32, UnityEngine.Canvas, UICanvas> TargetDisplayProperty = new MappedDependencyProperty<System.Int32, UnityEngine.Canvas, UICanvas>("TargetDisplay", x => x.Canvas, x => x.targetDisplay, (x, y) => x.targetDisplay = y);
        public System.Int32 TargetDisplay
        {
            get { return TargetDisplayProperty.GetValue(this); }
            set { TargetDisplayProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Int32, UnityEngine.Canvas, UICanvas> SortingLayerIDProperty = new MappedDependencyProperty<System.Int32, UnityEngine.Canvas, UICanvas>("SortingLayerID", x => x.Canvas, x => x.sortingLayerID, (x, y) => x.sortingLayerID = y);
        public System.Int32 SortingLayerID
        {
            get { return SortingLayerIDProperty.GetValue(this); }
            set { SortingLayerIDProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<UnityEngine.AdditionalCanvasShaderChannels, UnityEngine.Canvas, UICanvas> AdditionalShaderChannelsProperty = new MappedDependencyProperty<UnityEngine.AdditionalCanvasShaderChannels, UnityEngine.Canvas, UICanvas>("AdditionalShaderChannels", x => x.Canvas, x => x.additionalShaderChannels, (x, y) => x.additionalShaderChannels = y);
        public UnityEngine.AdditionalCanvasShaderChannels AdditionalShaderChannels
        {
            get { return AdditionalShaderChannelsProperty.GetValue(this); }
            set { AdditionalShaderChannelsProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.String, UnityEngine.Canvas, UICanvas> SortingLayerNameProperty = new MappedDependencyProperty<System.String, UnityEngine.Canvas, UICanvas>("SortingLayerName", x => x.Canvas, x => x.sortingLayerName, (x, y) => x.sortingLayerName = y);
        public System.String SortingLayerName
        {
            get { return SortingLayerNameProperty.GetValue(this); }
            set { SortingLayerNameProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<UnityEngine.Camera, UnityEngine.Canvas, UICanvas> WorldCameraProperty = new MappedDependencyProperty<UnityEngine.Camera, UnityEngine.Canvas, UICanvas>("WorldCamera", x => x.Canvas, x => x.worldCamera, (x, y) => x.worldCamera = y);
        public UnityEngine.Camera WorldCamera
        {
            get { return WorldCameraProperty.GetValue(this); }
            set { WorldCameraProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Single, UnityEngine.Canvas, UICanvas> NormalizedSortingGridSizeProperty = new MappedDependencyProperty<System.Single, UnityEngine.Canvas, UICanvas>("NormalizedSortingGridSize", x => x.Canvas, x => x.normalizedSortingGridSize, (x, y) => x.normalizedSortingGridSize = y);
        public System.Single NormalizedSortingGridSize
        {
            get { return NormalizedSortingGridSizeProperty.GetValue(this); }
            set { NormalizedSortingGridSizeProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<UnityEngine.UI.CanvasScaler.ScaleMode, UnityEngine.UI.CanvasScaler, UICanvas> UiScaleModeProperty = new MappedDependencyProperty<UnityEngine.UI.CanvasScaler.ScaleMode, UnityEngine.UI.CanvasScaler, UICanvas>("UiScaleMode", x => x.CanvasScaler, x => x.uiScaleMode, (x, y) => x.uiScaleMode = y);
        public UnityEngine.UI.CanvasScaler.ScaleMode UiScaleMode
        {
            get { return UiScaleModeProperty.GetValue(this); }
            set { UiScaleModeProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Single, UnityEngine.UI.CanvasScaler, UICanvas> CanvasScalerReferencePixelsPerUnitProperty = new MappedDependencyProperty<System.Single, UnityEngine.UI.CanvasScaler, UICanvas>("CanvasScalerReferencePixelsPerUnit", x => x.CanvasScaler, x => x.referencePixelsPerUnit, (x, y) => x.referencePixelsPerUnit = y);
        public System.Single CanvasScalerReferencePixelsPerUnit
        {
            get { return CanvasScalerReferencePixelsPerUnitProperty.GetValue(this); }
            set { CanvasScalerReferencePixelsPerUnitProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Single, UnityEngine.UI.CanvasScaler, UICanvas> CanvasScalerScaleFactorProperty = new MappedDependencyProperty<System.Single, UnityEngine.UI.CanvasScaler, UICanvas>("CanvasScalerScaleFactor", x => x.CanvasScaler, x => x.scaleFactor, (x, y) => x.scaleFactor = y);
        public System.Single CanvasScalerScaleFactor
        {
            get { return CanvasScalerScaleFactorProperty.GetValue(this); }
            set { CanvasScalerScaleFactorProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<UnityEngine.Vector2, UnityEngine.UI.CanvasScaler, UICanvas> ReferenceResolutionProperty = new MappedDependencyProperty<UnityEngine.Vector2, UnityEngine.UI.CanvasScaler, UICanvas>("ReferenceResolution", x => x.CanvasScaler, x => x.referenceResolution, (x, y) => x.referenceResolution = y);
        public UnityEngine.Vector2 ReferenceResolution
        {
            get { return ReferenceResolutionProperty.GetValue(this); }
            set { ReferenceResolutionProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<UnityEngine.UI.CanvasScaler.ScreenMatchMode, UnityEngine.UI.CanvasScaler, UICanvas> ScreenMatchModeProperty = new MappedDependencyProperty<UnityEngine.UI.CanvasScaler.ScreenMatchMode, UnityEngine.UI.CanvasScaler, UICanvas>("ScreenMatchMode", x => x.CanvasScaler, x => x.screenMatchMode, (x, y) => x.screenMatchMode = y);
        public UnityEngine.UI.CanvasScaler.ScreenMatchMode ScreenMatchMode
        {
            get { return ScreenMatchModeProperty.GetValue(this); }
            set { ScreenMatchModeProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Single, UnityEngine.UI.CanvasScaler, UICanvas> MatchWidthOrHeightProperty = new MappedDependencyProperty<System.Single, UnityEngine.UI.CanvasScaler, UICanvas>("MatchWidthOrHeight", x => x.CanvasScaler, x => x.matchWidthOrHeight, (x, y) => x.matchWidthOrHeight = y);
        public System.Single MatchWidthOrHeight
        {
            get { return MatchWidthOrHeightProperty.GetValue(this); }
            set { MatchWidthOrHeightProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<UnityEngine.UI.CanvasScaler.Unit, UnityEngine.UI.CanvasScaler, UICanvas> PhysicalUnitProperty = new MappedDependencyProperty<UnityEngine.UI.CanvasScaler.Unit, UnityEngine.UI.CanvasScaler, UICanvas>("PhysicalUnit", x => x.CanvasScaler, x => x.physicalUnit, (x, y) => x.physicalUnit = y);
        public UnityEngine.UI.CanvasScaler.Unit PhysicalUnit
        {
            get { return PhysicalUnitProperty.GetValue(this); }
            set { PhysicalUnitProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Single, UnityEngine.UI.CanvasScaler, UICanvas> FallbackScreenDPIProperty = new MappedDependencyProperty<System.Single, UnityEngine.UI.CanvasScaler, UICanvas>("FallbackScreenDPI", x => x.CanvasScaler, x => x.fallbackScreenDPI, (x, y) => x.fallbackScreenDPI = y);
        public System.Single FallbackScreenDPI
        {
            get { return FallbackScreenDPIProperty.GetValue(this); }
            set { FallbackScreenDPIProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Single, UnityEngine.UI.CanvasScaler, UICanvas> DefaultSpriteDPIProperty = new MappedDependencyProperty<System.Single, UnityEngine.UI.CanvasScaler, UICanvas>("DefaultSpriteDPI", x => x.CanvasScaler, x => x.defaultSpriteDPI, (x, y) => x.defaultSpriteDPI = y);
        public System.Single DefaultSpriteDPI
        {
            get { return DefaultSpriteDPIProperty.GetValue(this); }
            set { DefaultSpriteDPIProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Single, UnityEngine.UI.CanvasScaler, UICanvas> DynamicPixelsPerUnitProperty = new MappedDependencyProperty<System.Single, UnityEngine.UI.CanvasScaler, UICanvas>("DynamicPixelsPerUnit", x => x.CanvasScaler, x => x.dynamicPixelsPerUnit, (x, y) => x.dynamicPixelsPerUnit = y);
        public System.Single DynamicPixelsPerUnit
        {
            get { return DynamicPixelsPerUnitProperty.GetValue(this); }
            set { DynamicPixelsPerUnitProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Boolean, UnityEngine.UI.GraphicRaycaster, UICanvas> IgnoreReversedGraphicsProperty = new MappedDependencyProperty<System.Boolean, UnityEngine.UI.GraphicRaycaster, UICanvas>("IgnoreReversedGraphics", x => x.GraphicRaycaster, x => x.ignoreReversedGraphics, (x, y) => x.ignoreReversedGraphics = y);
        public System.Boolean IgnoreReversedGraphics
        {
            get { return IgnoreReversedGraphicsProperty.GetValue(this); }
            set { IgnoreReversedGraphicsProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<UnityEngine.UI.GraphicRaycaster.BlockingObjects, UnityEngine.UI.GraphicRaycaster, UICanvas> BlockingObjectsProperty = new MappedDependencyProperty<UnityEngine.UI.GraphicRaycaster.BlockingObjects, UnityEngine.UI.GraphicRaycaster, UICanvas>("BlockingObjects", x => x.GraphicRaycaster, x => x.blockingObjects, (x, y) => x.blockingObjects = y);
        public UnityEngine.UI.GraphicRaycaster.BlockingObjects BlockingObjects
        {
            get { return BlockingObjectsProperty.GetValue(this); }
            set { BlockingObjectsProperty.SetValue(this, value); }
        }

        #endregion
    }

    #region Data Templates

    public static class UICanvasTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return UICanvas;
            }
        }

        private static Template _uICanvas;
        public static Template UICanvas
        {
            get
            {
#if UNITY_EDITOR
                if (_uICanvas == null || _uICanvas.CurrentVersion != Template.Version)
#else
                if (_uICanvas == null)
#endif
                {
                    _uICanvas = new Template(UIViewTemplates.UIView);
#if UNITY_EDITOR
                    _uICanvas.Name = "UICanvas";
#endif
                    Delight.UICanvas.PixelPerfectProperty.SetDefault(_uICanvas, false);
                }
                return _uICanvas;
            }
        }

        #endregion
    }

    #endregion
}
