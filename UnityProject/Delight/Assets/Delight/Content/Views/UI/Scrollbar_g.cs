// Internal view logic generated from "Scrollbar.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class Scrollbar : UIImageView
    {
        #region Constructors

        public Scrollbar(View parent, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :
            base(parent, layoutParent, id, template ?? ScrollbarTemplates.Default, initializer)
        {
            // constructing Image (Bar)
            Bar = new Image(this, this, "Bar", BarTemplate);
            Handle = new Image(this, Bar.Content, "Handle", HandleTemplate);
            this.AfterInitializeInternal();
        }

        public Scrollbar() : this(null)
        {
        }

        static Scrollbar()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(ScrollbarTemplates.Default, dependencyProperties);

            dependencyProperties.Add(LengthProperty);
            dependencyProperties.Add(BreadthProperty);
            dependencyProperties.Add(OrientationProperty);
            dependencyProperties.Add(ScrollPositionProperty);
            dependencyProperties.Add(ViewportRatioProperty);
            dependencyProperties.Add(BarProperty);
            dependencyProperties.Add(BarTemplateProperty);
            dependencyProperties.Add(HandleProperty);
            dependencyProperties.Add(HandleTemplateProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<Delight.ElementSize> LengthProperty = new DependencyProperty<Delight.ElementSize>("Length");
        public Delight.ElementSize Length
        {
            get { return LengthProperty.GetValue(this); }
            set { LengthProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Delight.ElementSize> BreadthProperty = new DependencyProperty<Delight.ElementSize>("Breadth");
        public Delight.ElementSize Breadth
        {
            get { return BreadthProperty.GetValue(this); }
            set { BreadthProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Delight.ElementOrientation> OrientationProperty = new DependencyProperty<Delight.ElementOrientation>("Orientation");
        public Delight.ElementOrientation Orientation
        {
            get { return OrientationProperty.GetValue(this); }
            set { OrientationProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Single> ScrollPositionProperty = new DependencyProperty<System.Single>("ScrollPosition");
        public System.Single ScrollPosition
        {
            get { return ScrollPositionProperty.GetValue(this); }
            set { ScrollPositionProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Single> ViewportRatioProperty = new DependencyProperty<System.Single>("ViewportRatio");
        public System.Single ViewportRatio
        {
            get { return ViewportRatioProperty.GetValue(this); }
            set { ViewportRatioProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Image> BarProperty = new DependencyProperty<Image>("Bar");
        public Image Bar
        {
            get { return BarProperty.GetValue(this); }
            set { BarProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> BarTemplateProperty = new DependencyProperty<Template>("BarTemplate");
        public Template BarTemplate
        {
            get { return BarTemplateProperty.GetValue(this); }
            set { BarTemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Image> HandleProperty = new DependencyProperty<Image>("Handle");
        public Image Handle
        {
            get { return HandleProperty.GetValue(this); }
            set { HandleProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> HandleTemplateProperty = new DependencyProperty<Template>("HandleTemplate");
        public Template HandleTemplate
        {
            get { return HandleTemplateProperty.GetValue(this); }
            set { HandleTemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty BarSpriteProperty = Image.SpriteProperty;
        public SpriteAsset BarSprite
        {
            get { return Bar.Sprite; }
            set { Bar.Sprite = value; }
        }

        public readonly static DependencyProperty BarOverrideSpriteProperty = Image.OverrideSpriteProperty;
        public SpriteAsset BarOverrideSprite
        {
            get { return Bar.OverrideSprite; }
            set { Bar.OverrideSprite = value; }
        }

        public readonly static DependencyProperty BarTypeProperty = Image.TypeProperty;
        public UnityEngine.UI.Image.Type BarType
        {
            get { return Bar.Type; }
            set { Bar.Type = value; }
        }

        public readonly static DependencyProperty BarPreserveAspectProperty = Image.PreserveAspectProperty;
        public System.Boolean BarPreserveAspect
        {
            get { return Bar.PreserveAspect; }
            set { Bar.PreserveAspect = value; }
        }

        public readonly static DependencyProperty BarFillCenterProperty = Image.FillCenterProperty;
        public System.Boolean BarFillCenter
        {
            get { return Bar.FillCenter; }
            set { Bar.FillCenter = value; }
        }

        public readonly static DependencyProperty BarFillMethodProperty = Image.FillMethodProperty;
        public UnityEngine.UI.Image.FillMethod BarFillMethod
        {
            get { return Bar.FillMethod; }
            set { Bar.FillMethod = value; }
        }

        public readonly static DependencyProperty BarFillAmountProperty = Image.FillAmountProperty;
        public System.Single BarFillAmount
        {
            get { return Bar.FillAmount; }
            set { Bar.FillAmount = value; }
        }

        public readonly static DependencyProperty BarFillClockwiseProperty = Image.FillClockwiseProperty;
        public System.Boolean BarFillClockwise
        {
            get { return Bar.FillClockwise; }
            set { Bar.FillClockwise = value; }
        }

        public readonly static DependencyProperty BarFillOriginProperty = Image.FillOriginProperty;
        public System.Int32 BarFillOrigin
        {
            get { return Bar.FillOrigin; }
            set { Bar.FillOrigin = value; }
        }

        public readonly static DependencyProperty BarAlphaHitTestMinimumThresholdProperty = Image.AlphaHitTestMinimumThresholdProperty;
        public System.Single BarAlphaHitTestMinimumThreshold
        {
            get { return Bar.AlphaHitTestMinimumThreshold; }
            set { Bar.AlphaHitTestMinimumThreshold = value; }
        }

        public readonly static DependencyProperty BarUseSpriteMeshProperty = Image.UseSpriteMeshProperty;
        public System.Boolean BarUseSpriteMesh
        {
            get { return Bar.UseSpriteMesh; }
            set { Bar.UseSpriteMesh = value; }
        }

        public readonly static DependencyProperty BarMaterialProperty = Image.MaterialProperty;
        public MaterialAsset BarMaterial
        {
            get { return Bar.Material; }
            set { Bar.Material = value; }
        }

        public readonly static DependencyProperty BarOnCullStateChangedProperty = Image.OnCullStateChangedProperty;
        public UnityEngine.UI.MaskableGraphic.CullStateChangedEvent BarOnCullStateChanged
        {
            get { return Bar.OnCullStateChanged; }
            set { Bar.OnCullStateChanged = value; }
        }

        public readonly static DependencyProperty BarMaskableProperty = Image.MaskableProperty;
        public System.Boolean BarMaskable
        {
            get { return Bar.Maskable; }
            set { Bar.Maskable = value; }
        }

        public readonly static DependencyProperty BarColorProperty = Image.ColorProperty;
        public UnityEngine.Color BarColor
        {
            get { return Bar.Color; }
            set { Bar.Color = value; }
        }

        public readonly static DependencyProperty BarRaycastTargetProperty = Image.RaycastTargetProperty;
        public System.Boolean BarRaycastTarget
        {
            get { return Bar.RaycastTarget; }
            set { Bar.RaycastTarget = value; }
        }

        public readonly static DependencyProperty BarWidthProperty = Image.WidthProperty;
        public Delight.ElementSize BarWidth
        {
            get { return Bar.Width; }
            set { Bar.Width = value; }
        }

        public readonly static DependencyProperty BarHeightProperty = Image.HeightProperty;
        public Delight.ElementSize BarHeight
        {
            get { return Bar.Height; }
            set { Bar.Height = value; }
        }

        public readonly static DependencyProperty BarOverrideWidthProperty = Image.OverrideWidthProperty;
        public Delight.ElementSize BarOverrideWidth
        {
            get { return Bar.OverrideWidth; }
            set { Bar.OverrideWidth = value; }
        }

        public readonly static DependencyProperty BarOverrideHeightProperty = Image.OverrideHeightProperty;
        public Delight.ElementSize BarOverrideHeight
        {
            get { return Bar.OverrideHeight; }
            set { Bar.OverrideHeight = value; }
        }

        public readonly static DependencyProperty BarScaleProperty = Image.ScaleProperty;
        public UnityEngine.Vector3 BarScale
        {
            get { return Bar.Scale; }
            set { Bar.Scale = value; }
        }

        public readonly static DependencyProperty BarAlignmentProperty = Image.AlignmentProperty;
        public Delight.ElementAlignment BarAlignment
        {
            get { return Bar.Alignment; }
            set { Bar.Alignment = value; }
        }

        public readonly static DependencyProperty BarMarginProperty = Image.MarginProperty;
        public Delight.ElementMargin BarMargin
        {
            get { return Bar.Margin; }
            set { Bar.Margin = value; }
        }

        public readonly static DependencyProperty BarOffsetProperty = Image.OffsetProperty;
        public Delight.ElementMargin BarOffset
        {
            get { return Bar.Offset; }
            set { Bar.Offset = value; }
        }

        public readonly static DependencyProperty BarOffsetFromParentProperty = Image.OffsetFromParentProperty;
        public Delight.ElementMargin BarOffsetFromParent
        {
            get { return Bar.OffsetFromParent; }
            set { Bar.OffsetFromParent = value; }
        }

        public readonly static DependencyProperty BarPivotProperty = Image.PivotProperty;
        public UnityEngine.Vector2 BarPivot
        {
            get { return Bar.Pivot; }
            set { Bar.Pivot = value; }
        }

        public readonly static DependencyProperty BarLayoutRootProperty = Image.LayoutRootProperty;
        public Delight.LayoutRoot BarLayoutRoot
        {
            get { return Bar.LayoutRoot; }
            set { Bar.LayoutRoot = value; }
        }

        public readonly static DependencyProperty BarDisableLayoutUpdateProperty = Image.DisableLayoutUpdateProperty;
        public System.Boolean BarDisableLayoutUpdate
        {
            get { return Bar.DisableLayoutUpdate; }
            set { Bar.DisableLayoutUpdate = value; }
        }

        public readonly static DependencyProperty BarAlphaProperty = Image.AlphaProperty;
        public System.Single BarAlpha
        {
            get { return Bar.Alpha; }
            set { Bar.Alpha = value; }
        }

        public readonly static DependencyProperty BarIsVisibleProperty = Image.IsVisibleProperty;
        public System.Boolean BarIsVisible
        {
            get { return Bar.IsVisible; }
            set { Bar.IsVisible = value; }
        }

        public readonly static DependencyProperty BarRaycastBlockModeProperty = Image.RaycastBlockModeProperty;
        public Delight.RaycastBlockMode BarRaycastBlockMode
        {
            get { return Bar.RaycastBlockMode; }
            set { Bar.RaycastBlockMode = value; }
        }

        public readonly static DependencyProperty BarUseFastShaderProperty = Image.UseFastShaderProperty;
        public System.Boolean BarUseFastShader
        {
            get { return Bar.UseFastShader; }
            set { Bar.UseFastShader = value; }
        }

        public readonly static DependencyProperty BarBubbleNotifyChildLayoutChangedProperty = Image.BubbleNotifyChildLayoutChangedProperty;
        public System.Boolean BarBubbleNotifyChildLayoutChanged
        {
            get { return Bar.BubbleNotifyChildLayoutChanged; }
            set { Bar.BubbleNotifyChildLayoutChanged = value; }
        }

        public readonly static DependencyProperty BarIgnoreFlipProperty = Image.IgnoreFlipProperty;
        public System.Boolean BarIgnoreFlip
        {
            get { return Bar.IgnoreFlip; }
            set { Bar.IgnoreFlip = value; }
        }

        public readonly static DependencyProperty BarGameObjectProperty = Image.GameObjectProperty;
        public UnityEngine.GameObject BarGameObject
        {
            get { return Bar.GameObject; }
            set { Bar.GameObject = value; }
        }

        public readonly static DependencyProperty BarEnableScriptEventsProperty = Image.EnableScriptEventsProperty;
        public System.Boolean BarEnableScriptEvents
        {
            get { return Bar.EnableScriptEvents; }
            set { Bar.EnableScriptEvents = value; }
        }

        public readonly static DependencyProperty BarIgnoreObjectProperty = Image.IgnoreObjectProperty;
        public System.Boolean BarIgnoreObject
        {
            get { return Bar.IgnoreObject; }
            set { Bar.IgnoreObject = value; }
        }

        public readonly static DependencyProperty BarIsActiveProperty = Image.IsActiveProperty;
        public System.Boolean BarIsActive
        {
            get { return Bar.IsActive; }
            set { Bar.IsActive = value; }
        }

        public readonly static DependencyProperty BarLoadModeProperty = Image.LoadModeProperty;
        public Delight.LoadMode BarLoadMode
        {
            get { return Bar.LoadMode; }
            set { Bar.LoadMode = value; }
        }

        public readonly static DependencyProperty HandleSpriteProperty = Image.SpriteProperty;
        public SpriteAsset HandleSprite
        {
            get { return Handle.Sprite; }
            set { Handle.Sprite = value; }
        }

        public readonly static DependencyProperty HandleOverrideSpriteProperty = Image.OverrideSpriteProperty;
        public SpriteAsset HandleOverrideSprite
        {
            get { return Handle.OverrideSprite; }
            set { Handle.OverrideSprite = value; }
        }

        public readonly static DependencyProperty HandleTypeProperty = Image.TypeProperty;
        public UnityEngine.UI.Image.Type HandleType
        {
            get { return Handle.Type; }
            set { Handle.Type = value; }
        }

        public readonly static DependencyProperty HandlePreserveAspectProperty = Image.PreserveAspectProperty;
        public System.Boolean HandlePreserveAspect
        {
            get { return Handle.PreserveAspect; }
            set { Handle.PreserveAspect = value; }
        }

        public readonly static DependencyProperty HandleFillCenterProperty = Image.FillCenterProperty;
        public System.Boolean HandleFillCenter
        {
            get { return Handle.FillCenter; }
            set { Handle.FillCenter = value; }
        }

        public readonly static DependencyProperty HandleFillMethodProperty = Image.FillMethodProperty;
        public UnityEngine.UI.Image.FillMethod HandleFillMethod
        {
            get { return Handle.FillMethod; }
            set { Handle.FillMethod = value; }
        }

        public readonly static DependencyProperty HandleFillAmountProperty = Image.FillAmountProperty;
        public System.Single HandleFillAmount
        {
            get { return Handle.FillAmount; }
            set { Handle.FillAmount = value; }
        }

        public readonly static DependencyProperty HandleFillClockwiseProperty = Image.FillClockwiseProperty;
        public System.Boolean HandleFillClockwise
        {
            get { return Handle.FillClockwise; }
            set { Handle.FillClockwise = value; }
        }

        public readonly static DependencyProperty HandleFillOriginProperty = Image.FillOriginProperty;
        public System.Int32 HandleFillOrigin
        {
            get { return Handle.FillOrigin; }
            set { Handle.FillOrigin = value; }
        }

        public readonly static DependencyProperty HandleAlphaHitTestMinimumThresholdProperty = Image.AlphaHitTestMinimumThresholdProperty;
        public System.Single HandleAlphaHitTestMinimumThreshold
        {
            get { return Handle.AlphaHitTestMinimumThreshold; }
            set { Handle.AlphaHitTestMinimumThreshold = value; }
        }

        public readonly static DependencyProperty HandleUseSpriteMeshProperty = Image.UseSpriteMeshProperty;
        public System.Boolean HandleUseSpriteMesh
        {
            get { return Handle.UseSpriteMesh; }
            set { Handle.UseSpriteMesh = value; }
        }

        public readonly static DependencyProperty HandleMaterialProperty = Image.MaterialProperty;
        public MaterialAsset HandleMaterial
        {
            get { return Handle.Material; }
            set { Handle.Material = value; }
        }

        public readonly static DependencyProperty HandleOnCullStateChangedProperty = Image.OnCullStateChangedProperty;
        public UnityEngine.UI.MaskableGraphic.CullStateChangedEvent HandleOnCullStateChanged
        {
            get { return Handle.OnCullStateChanged; }
            set { Handle.OnCullStateChanged = value; }
        }

        public readonly static DependencyProperty HandleMaskableProperty = Image.MaskableProperty;
        public System.Boolean HandleMaskable
        {
            get { return Handle.Maskable; }
            set { Handle.Maskable = value; }
        }

        public readonly static DependencyProperty HandleColorProperty = Image.ColorProperty;
        public UnityEngine.Color HandleColor
        {
            get { return Handle.Color; }
            set { Handle.Color = value; }
        }

        public readonly static DependencyProperty HandleRaycastTargetProperty = Image.RaycastTargetProperty;
        public System.Boolean HandleRaycastTarget
        {
            get { return Handle.RaycastTarget; }
            set { Handle.RaycastTarget = value; }
        }

        public readonly static DependencyProperty HandleWidthProperty = Image.WidthProperty;
        public Delight.ElementSize HandleWidth
        {
            get { return Handle.Width; }
            set { Handle.Width = value; }
        }

        public readonly static DependencyProperty HandleHeightProperty = Image.HeightProperty;
        public Delight.ElementSize HandleHeight
        {
            get { return Handle.Height; }
            set { Handle.Height = value; }
        }

        public readonly static DependencyProperty HandleOverrideWidthProperty = Image.OverrideWidthProperty;
        public Delight.ElementSize HandleOverrideWidth
        {
            get { return Handle.OverrideWidth; }
            set { Handle.OverrideWidth = value; }
        }

        public readonly static DependencyProperty HandleOverrideHeightProperty = Image.OverrideHeightProperty;
        public Delight.ElementSize HandleOverrideHeight
        {
            get { return Handle.OverrideHeight; }
            set { Handle.OverrideHeight = value; }
        }

        public readonly static DependencyProperty HandleScaleProperty = Image.ScaleProperty;
        public UnityEngine.Vector3 HandleScale
        {
            get { return Handle.Scale; }
            set { Handle.Scale = value; }
        }

        public readonly static DependencyProperty HandleAlignmentProperty = Image.AlignmentProperty;
        public Delight.ElementAlignment HandleAlignment
        {
            get { return Handle.Alignment; }
            set { Handle.Alignment = value; }
        }

        public readonly static DependencyProperty HandleMarginProperty = Image.MarginProperty;
        public Delight.ElementMargin HandleMargin
        {
            get { return Handle.Margin; }
            set { Handle.Margin = value; }
        }

        public readonly static DependencyProperty HandleOffsetProperty = Image.OffsetProperty;
        public Delight.ElementMargin HandleOffset
        {
            get { return Handle.Offset; }
            set { Handle.Offset = value; }
        }

        public readonly static DependencyProperty HandleOffsetFromParentProperty = Image.OffsetFromParentProperty;
        public Delight.ElementMargin HandleOffsetFromParent
        {
            get { return Handle.OffsetFromParent; }
            set { Handle.OffsetFromParent = value; }
        }

        public readonly static DependencyProperty HandlePivotProperty = Image.PivotProperty;
        public UnityEngine.Vector2 HandlePivot
        {
            get { return Handle.Pivot; }
            set { Handle.Pivot = value; }
        }

        public readonly static DependencyProperty HandleLayoutRootProperty = Image.LayoutRootProperty;
        public Delight.LayoutRoot HandleLayoutRoot
        {
            get { return Handle.LayoutRoot; }
            set { Handle.LayoutRoot = value; }
        }

        public readonly static DependencyProperty HandleDisableLayoutUpdateProperty = Image.DisableLayoutUpdateProperty;
        public System.Boolean HandleDisableLayoutUpdate
        {
            get { return Handle.DisableLayoutUpdate; }
            set { Handle.DisableLayoutUpdate = value; }
        }

        public readonly static DependencyProperty HandleAlphaProperty = Image.AlphaProperty;
        public System.Single HandleAlpha
        {
            get { return Handle.Alpha; }
            set { Handle.Alpha = value; }
        }

        public readonly static DependencyProperty HandleIsVisibleProperty = Image.IsVisibleProperty;
        public System.Boolean HandleIsVisible
        {
            get { return Handle.IsVisible; }
            set { Handle.IsVisible = value; }
        }

        public readonly static DependencyProperty HandleRaycastBlockModeProperty = Image.RaycastBlockModeProperty;
        public Delight.RaycastBlockMode HandleRaycastBlockMode
        {
            get { return Handle.RaycastBlockMode; }
            set { Handle.RaycastBlockMode = value; }
        }

        public readonly static DependencyProperty HandleUseFastShaderProperty = Image.UseFastShaderProperty;
        public System.Boolean HandleUseFastShader
        {
            get { return Handle.UseFastShader; }
            set { Handle.UseFastShader = value; }
        }

        public readonly static DependencyProperty HandleBubbleNotifyChildLayoutChangedProperty = Image.BubbleNotifyChildLayoutChangedProperty;
        public System.Boolean HandleBubbleNotifyChildLayoutChanged
        {
            get { return Handle.BubbleNotifyChildLayoutChanged; }
            set { Handle.BubbleNotifyChildLayoutChanged = value; }
        }

        public readonly static DependencyProperty HandleIgnoreFlipProperty = Image.IgnoreFlipProperty;
        public System.Boolean HandleIgnoreFlip
        {
            get { return Handle.IgnoreFlip; }
            set { Handle.IgnoreFlip = value; }
        }

        public readonly static DependencyProperty HandleGameObjectProperty = Image.GameObjectProperty;
        public UnityEngine.GameObject HandleGameObject
        {
            get { return Handle.GameObject; }
            set { Handle.GameObject = value; }
        }

        public readonly static DependencyProperty HandleEnableScriptEventsProperty = Image.EnableScriptEventsProperty;
        public System.Boolean HandleEnableScriptEvents
        {
            get { return Handle.EnableScriptEvents; }
            set { Handle.EnableScriptEvents = value; }
        }

        public readonly static DependencyProperty HandleIgnoreObjectProperty = Image.IgnoreObjectProperty;
        public System.Boolean HandleIgnoreObject
        {
            get { return Handle.IgnoreObject; }
            set { Handle.IgnoreObject = value; }
        }

        public readonly static DependencyProperty HandleIsActiveProperty = Image.IsActiveProperty;
        public System.Boolean HandleIsActive
        {
            get { return Handle.IsActive; }
            set { Handle.IsActive = value; }
        }

        public readonly static DependencyProperty HandleLoadModeProperty = Image.LoadModeProperty;
        public Delight.LoadMode HandleLoadMode
        {
            get { return Handle.LoadMode; }
            set { Handle.LoadMode = value; }
        }

        #endregion
    }

    #region Data Templates

    public static class ScrollbarTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return Scrollbar;
            }
        }

        private static Template _scrollbar;
        public static Template Scrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollbar == null || _scrollbar.CurrentVersion != Template.Version)
#else
                if (_scrollbar == null)
#endif
                {
                    _scrollbar = new Template(UIImageViewTemplates.UIImageView);
#if UNITY_EDITOR
                    _scrollbar.Name = "Scrollbar";
#endif
                    Delight.Scrollbar.LengthProperty.SetDefault(_scrollbar, new ElementSize(1f, ElementSizeUnit.Percents));
                    Delight.Scrollbar.BreadthProperty.SetDefault(_scrollbar, new ElementSize(10f, ElementSizeUnit.Pixels));
                    Delight.Scrollbar.ViewportRatioProperty.SetDefault(_scrollbar, 0.1f);
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_scrollbar, ScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_scrollbar, ScrollbarHandle);
                }
                return _scrollbar;
            }
        }

        private static Template _scrollbarBar;
        public static Template ScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollbarBar == null || _scrollbarBar.CurrentVersion != Template.Version)
#else
                if (_scrollbarBar == null)
#endif
                {
                    _scrollbarBar = new Template(ImageTemplates.Image);
#if UNITY_EDITOR
                    _scrollbarBar.Name = "ScrollbarBar";
#endif
                    Delight.Image.ColorProperty.SetDefault(_scrollbarBar, new UnityEngine.Color(0.5f, 0.5f, 0.5f, 1f));
                    Delight.Image.WidthProperty.SetDefault(_scrollbarBar, new ElementSize(1f, ElementSizeUnit.Percents));
                    Delight.Image.HeightProperty.SetDefault(_scrollbarBar, new ElementSize(1f, ElementSizeUnit.Percents));
                }
                return _scrollbarBar;
            }
        }

        private static Template _scrollbarHandle;
        public static Template ScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollbarHandle == null || _scrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_scrollbarHandle == null)
#endif
                {
                    _scrollbarHandle = new Template(ImageTemplates.Image);
#if UNITY_EDITOR
                    _scrollbarHandle.Name = "ScrollbarHandle";
#endif
                    Delight.Image.ColorProperty.SetDefault(_scrollbarHandle, new UnityEngine.Color(0.6470588f, 0.1647059f, 0.1647059f, 1f));
                    Delight.Image.WidthProperty.SetDefault(_scrollbarHandle, new ElementSize(1f, ElementSizeUnit.Percents));
                    Delight.Image.HeightProperty.SetDefault(_scrollbarHandle, new ElementSize(1f, ElementSizeUnit.Percents));
                }
                return _scrollbarHandle;
            }
        }

        #endregion
    }

    #endregion
}
