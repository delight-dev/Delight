// Internal view logic generated from "ScrollableRegion.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class ScrollableRegion : UICanvas
    {
        #region Constructors

        public ScrollableRegion(View parent, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :
            base(parent, layoutParent, id, template ?? ScrollableRegionTemplates.Default, initializer)
        {
            // constructing Region (ContentRegion)
            ContentRegion = new Region(this, this, "ContentRegion", ContentRegionTemplate);

            // binding <Region Alignment="{ContentAlignment}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "ContentAlignment" }, new List<Func<BindableObject>> { () => this }) }, new BindingPath(new List<string> { "ContentRegion", "Alignment" }, new List<Func<BindableObject>> { () => this, () => ContentRegion }), () => ContentRegion.Alignment = ContentAlignment, () => { }, false));

            // constructing Scrollbar (HorizontalScrollbar)
            HorizontalScrollbar = new Scrollbar(this, this, "HorizontalScrollbar", HorizontalScrollbarTemplate);

            // constructing Scrollbar (VerticalScrollbar)
            VerticalScrollbar = new Scrollbar(this, this, "VerticalScrollbar", VerticalScrollbarTemplate);
            Drag.RegisterHandler(this, "OnDrag");
            BeginDrag.RegisterHandler(this, "OnBeginDrag");
            InitializePotentialDrag.RegisterHandler(this, "OnInitializePotentialDrag");
            EndDrag.RegisterHandler(this, "OnEndDrag");
            Scroll.RegisterHandler(this, "OnScroll");
            ContentContainer = ContentRegion;
            this.AfterInitializeInternal();
        }

        public ScrollableRegion() : this(null)
        {
        }

        static ScrollableRegion()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(ScrollableRegionTemplates.Default, dependencyProperties);

            dependencyProperties.Add(MaskContentProperty);
            dependencyProperties.Add(MaskProperty);
            dependencyProperties.Add(ImageComponentProperty);
            dependencyProperties.Add(HasInertiaProperty);
            dependencyProperties.Add(DecelerationRateProperty);
            dependencyProperties.Add(ElasticityProperty);
            dependencyProperties.Add(CanScrollHorizontallyProperty);
            dependencyProperties.Add(CanScrollVerticallyProperty);
            dependencyProperties.Add(ContentAlignmentProperty);
            dependencyProperties.Add(AutoSizeContentRegionProperty);
            dependencyProperties.Add(ScrollBoundsProperty);
            dependencyProperties.Add(DebugOffsetTextProperty);
            dependencyProperties.Add(DisableInteractionScrollDeltaProperty);
            dependencyProperties.Add(ScrollSensitivityProperty);
            dependencyProperties.Add(HorizontalScrollbarVisibilityProperty);
            dependencyProperties.Add(VerticalScrollbarVisibilityProperty);
            dependencyProperties.Add(DisableMouseWheelProperty);
            dependencyProperties.Add(ContentScrolledProperty);
            dependencyProperties.Add(ScrollEnabledProperty);
            dependencyProperties.Add(ContentRegionProperty);
            dependencyProperties.Add(ContentRegionTemplateProperty);
            dependencyProperties.Add(HorizontalScrollbarProperty);
            dependencyProperties.Add(HorizontalScrollbarTemplateProperty);
            dependencyProperties.Add(VerticalScrollbarProperty);
            dependencyProperties.Add(VerticalScrollbarTemplateProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<System.Boolean> MaskContentProperty = new DependencyProperty<System.Boolean>("MaskContent");
        public System.Boolean MaskContent
        {
            get { return MaskContentProperty.GetValue(this); }
            set { MaskContentProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<UnityEngine.UI.RectMask2D> MaskProperty = new DependencyProperty<UnityEngine.UI.RectMask2D>("Mask");
        public UnityEngine.UI.RectMask2D Mask
        {
            get { return MaskProperty.GetValue(this); }
            set { MaskProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<UnityEngine.UI.Image> ImageComponentProperty = new DependencyProperty<UnityEngine.UI.Image>("ImageComponent");
        public UnityEngine.UI.Image ImageComponent
        {
            get { return ImageComponentProperty.GetValue(this); }
            set { ImageComponentProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> HasInertiaProperty = new DependencyProperty<System.Boolean>("HasInertia");
        public System.Boolean HasInertia
        {
            get { return HasInertiaProperty.GetValue(this); }
            set { HasInertiaProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Single> DecelerationRateProperty = new DependencyProperty<System.Single>("DecelerationRate");
        public System.Single DecelerationRate
        {
            get { return DecelerationRateProperty.GetValue(this); }
            set { DecelerationRateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Single> ElasticityProperty = new DependencyProperty<System.Single>("Elasticity");
        public System.Single Elasticity
        {
            get { return ElasticityProperty.GetValue(this); }
            set { ElasticityProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> CanScrollHorizontallyProperty = new DependencyProperty<System.Boolean>("CanScrollHorizontally");
        public System.Boolean CanScrollHorizontally
        {
            get { return CanScrollHorizontallyProperty.GetValue(this); }
            set { CanScrollHorizontallyProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> CanScrollVerticallyProperty = new DependencyProperty<System.Boolean>("CanScrollVertically");
        public System.Boolean CanScrollVertically
        {
            get { return CanScrollVerticallyProperty.GetValue(this); }
            set { CanScrollVerticallyProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Delight.ElementAlignment> ContentAlignmentProperty = new DependencyProperty<Delight.ElementAlignment>("ContentAlignment");
        public Delight.ElementAlignment ContentAlignment
        {
            get { return ContentAlignmentProperty.GetValue(this); }
            set { ContentAlignmentProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> AutoSizeContentRegionProperty = new DependencyProperty<System.Boolean>("AutoSizeContentRegion");
        public System.Boolean AutoSizeContentRegion
        {
            get { return AutoSizeContentRegionProperty.GetValue(this); }
            set { AutoSizeContentRegionProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Delight.ScrollBounds> ScrollBoundsProperty = new DependencyProperty<Delight.ScrollBounds>("ScrollBounds");
        public Delight.ScrollBounds ScrollBounds
        {
            get { return ScrollBoundsProperty.GetValue(this); }
            set { ScrollBoundsProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.String> DebugOffsetTextProperty = new DependencyProperty<System.String>("DebugOffsetText");
        public System.String DebugOffsetText
        {
            get { return DebugOffsetTextProperty.GetValue(this); }
            set { DebugOffsetTextProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Single> DisableInteractionScrollDeltaProperty = new DependencyProperty<System.Single>("DisableInteractionScrollDelta");
        public System.Single DisableInteractionScrollDelta
        {
            get { return DisableInteractionScrollDeltaProperty.GetValue(this); }
            set { DisableInteractionScrollDeltaProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Single> ScrollSensitivityProperty = new DependencyProperty<System.Single>("ScrollSensitivity");
        public System.Single ScrollSensitivity
        {
            get { return ScrollSensitivityProperty.GetValue(this); }
            set { ScrollSensitivityProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Delight.ScrollbarVisibilityMode> HorizontalScrollbarVisibilityProperty = new DependencyProperty<Delight.ScrollbarVisibilityMode>("HorizontalScrollbarVisibility");
        public Delight.ScrollbarVisibilityMode HorizontalScrollbarVisibility
        {
            get { return HorizontalScrollbarVisibilityProperty.GetValue(this); }
            set { HorizontalScrollbarVisibilityProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Delight.ScrollbarVisibilityMode> VerticalScrollbarVisibilityProperty = new DependencyProperty<Delight.ScrollbarVisibilityMode>("VerticalScrollbarVisibility");
        public Delight.ScrollbarVisibilityMode VerticalScrollbarVisibility
        {
            get { return VerticalScrollbarVisibilityProperty.GetValue(this); }
            set { VerticalScrollbarVisibilityProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> DisableMouseWheelProperty = new DependencyProperty<System.Boolean>("DisableMouseWheel");
        public System.Boolean DisableMouseWheel
        {
            get { return DisableMouseWheelProperty.GetValue(this); }
            set { DisableMouseWheelProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ViewAction> ContentScrolledProperty = new DependencyProperty<ViewAction>("ContentScrolled", () => new ViewAction());
        public ViewAction ContentScrolled
        {
            get { return ContentScrolledProperty.GetValue(this); }
            set { ContentScrolledProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> ScrollEnabledProperty = new DependencyProperty<System.Boolean>("ScrollEnabled");
        public System.Boolean ScrollEnabled
        {
            get { return ScrollEnabledProperty.GetValue(this); }
            set { ScrollEnabledProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> ContentRegionProperty = new DependencyProperty<Region>("ContentRegion");
        public Region ContentRegion
        {
            get { return ContentRegionProperty.GetValue(this); }
            set { ContentRegionProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> ContentRegionTemplateProperty = new DependencyProperty<Template>("ContentRegionTemplate");
        public Template ContentRegionTemplate
        {
            get { return ContentRegionTemplateProperty.GetValue(this); }
            set { ContentRegionTemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Scrollbar> HorizontalScrollbarProperty = new DependencyProperty<Scrollbar>("HorizontalScrollbar");
        public Scrollbar HorizontalScrollbar
        {
            get { return HorizontalScrollbarProperty.GetValue(this); }
            set { HorizontalScrollbarProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> HorizontalScrollbarTemplateProperty = new DependencyProperty<Template>("HorizontalScrollbarTemplate");
        public Template HorizontalScrollbarTemplate
        {
            get { return HorizontalScrollbarTemplateProperty.GetValue(this); }
            set { HorizontalScrollbarTemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Scrollbar> VerticalScrollbarProperty = new DependencyProperty<Scrollbar>("VerticalScrollbar");
        public Scrollbar VerticalScrollbar
        {
            get { return VerticalScrollbarProperty.GetValue(this); }
            set { VerticalScrollbarProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> VerticalScrollbarTemplateProperty = new DependencyProperty<Template>("VerticalScrollbarTemplate");
        public Template VerticalScrollbarTemplate
        {
            get { return VerticalScrollbarTemplateProperty.GetValue(this); }
            set { VerticalScrollbarTemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty HorizontalScrollbarLengthProperty = Scrollbar.LengthProperty;
        public Delight.ElementSize HorizontalScrollbarLength
        {
            get { return HorizontalScrollbar.Length; }
            set { HorizontalScrollbar.Length = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBreadthProperty = Scrollbar.BreadthProperty;
        public Delight.ElementSize HorizontalScrollbarBreadth
        {
            get { return HorizontalScrollbar.Breadth; }
            set { HorizontalScrollbar.Breadth = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarOrientationProperty = Scrollbar.OrientationProperty;
        public Delight.ElementOrientation HorizontalScrollbarOrientation
        {
            get { return HorizontalScrollbar.Orientation; }
            set { HorizontalScrollbar.Orientation = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarScrollPositionProperty = Scrollbar.ScrollPositionProperty;
        public System.Single HorizontalScrollbarScrollPosition
        {
            get { return HorizontalScrollbar.ScrollPosition; }
            set { HorizontalScrollbar.ScrollPosition = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarViewportRatioProperty = Scrollbar.ViewportRatioProperty;
        public System.Single HorizontalScrollbarViewportRatio
        {
            get { return HorizontalScrollbar.ViewportRatio; }
            set { HorizontalScrollbar.ViewportRatio = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarSpriteProperty = Scrollbar.BarSpriteProperty;
        public SpriteAsset HorizontalScrollbarBarSprite
        {
            get { return HorizontalScrollbar.BarSprite; }
            set { HorizontalScrollbar.BarSprite = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarOverrideSpriteProperty = Scrollbar.BarOverrideSpriteProperty;
        public SpriteAsset HorizontalScrollbarBarOverrideSprite
        {
            get { return HorizontalScrollbar.BarOverrideSprite; }
            set { HorizontalScrollbar.BarOverrideSprite = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarTypeProperty = Scrollbar.BarTypeProperty;
        public UnityEngine.UI.Image.Type HorizontalScrollbarBarType
        {
            get { return HorizontalScrollbar.BarType; }
            set { HorizontalScrollbar.BarType = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarPreserveAspectProperty = Scrollbar.BarPreserveAspectProperty;
        public System.Boolean HorizontalScrollbarBarPreserveAspect
        {
            get { return HorizontalScrollbar.BarPreserveAspect; }
            set { HorizontalScrollbar.BarPreserveAspect = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarFillCenterProperty = Scrollbar.BarFillCenterProperty;
        public System.Boolean HorizontalScrollbarBarFillCenter
        {
            get { return HorizontalScrollbar.BarFillCenter; }
            set { HorizontalScrollbar.BarFillCenter = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarFillMethodProperty = Scrollbar.BarFillMethodProperty;
        public UnityEngine.UI.Image.FillMethod HorizontalScrollbarBarFillMethod
        {
            get { return HorizontalScrollbar.BarFillMethod; }
            set { HorizontalScrollbar.BarFillMethod = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarFillAmountProperty = Scrollbar.BarFillAmountProperty;
        public System.Single HorizontalScrollbarBarFillAmount
        {
            get { return HorizontalScrollbar.BarFillAmount; }
            set { HorizontalScrollbar.BarFillAmount = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarFillClockwiseProperty = Scrollbar.BarFillClockwiseProperty;
        public System.Boolean HorizontalScrollbarBarFillClockwise
        {
            get { return HorizontalScrollbar.BarFillClockwise; }
            set { HorizontalScrollbar.BarFillClockwise = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarFillOriginProperty = Scrollbar.BarFillOriginProperty;
        public System.Int32 HorizontalScrollbarBarFillOrigin
        {
            get { return HorizontalScrollbar.BarFillOrigin; }
            set { HorizontalScrollbar.BarFillOrigin = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarAlphaHitTestMinimumThresholdProperty = Scrollbar.BarAlphaHitTestMinimumThresholdProperty;
        public System.Single HorizontalScrollbarBarAlphaHitTestMinimumThreshold
        {
            get { return HorizontalScrollbar.BarAlphaHitTestMinimumThreshold; }
            set { HorizontalScrollbar.BarAlphaHitTestMinimumThreshold = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarUseSpriteMeshProperty = Scrollbar.BarUseSpriteMeshProperty;
        public System.Boolean HorizontalScrollbarBarUseSpriteMesh
        {
            get { return HorizontalScrollbar.BarUseSpriteMesh; }
            set { HorizontalScrollbar.BarUseSpriteMesh = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarMaterialProperty = Scrollbar.BarMaterialProperty;
        public MaterialAsset HorizontalScrollbarBarMaterial
        {
            get { return HorizontalScrollbar.BarMaterial; }
            set { HorizontalScrollbar.BarMaterial = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarOnCullStateChangedProperty = Scrollbar.BarOnCullStateChangedProperty;
        public UnityEngine.UI.MaskableGraphic.CullStateChangedEvent HorizontalScrollbarBarOnCullStateChanged
        {
            get { return HorizontalScrollbar.BarOnCullStateChanged; }
            set { HorizontalScrollbar.BarOnCullStateChanged = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarMaskableProperty = Scrollbar.BarMaskableProperty;
        public System.Boolean HorizontalScrollbarBarMaskable
        {
            get { return HorizontalScrollbar.BarMaskable; }
            set { HorizontalScrollbar.BarMaskable = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarColorProperty = Scrollbar.BarColorProperty;
        public UnityEngine.Color HorizontalScrollbarBarColor
        {
            get { return HorizontalScrollbar.BarColor; }
            set { HorizontalScrollbar.BarColor = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarRaycastTargetProperty = Scrollbar.BarRaycastTargetProperty;
        public System.Boolean HorizontalScrollbarBarRaycastTarget
        {
            get { return HorizontalScrollbar.BarRaycastTarget; }
            set { HorizontalScrollbar.BarRaycastTarget = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarWidthProperty = Scrollbar.BarWidthProperty;
        public Delight.ElementSize HorizontalScrollbarBarWidth
        {
            get { return HorizontalScrollbar.BarWidth; }
            set { HorizontalScrollbar.BarWidth = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarHeightProperty = Scrollbar.BarHeightProperty;
        public Delight.ElementSize HorizontalScrollbarBarHeight
        {
            get { return HorizontalScrollbar.BarHeight; }
            set { HorizontalScrollbar.BarHeight = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarOverrideWidthProperty = Scrollbar.BarOverrideWidthProperty;
        public Delight.ElementSize HorizontalScrollbarBarOverrideWidth
        {
            get { return HorizontalScrollbar.BarOverrideWidth; }
            set { HorizontalScrollbar.BarOverrideWidth = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarOverrideHeightProperty = Scrollbar.BarOverrideHeightProperty;
        public Delight.ElementSize HorizontalScrollbarBarOverrideHeight
        {
            get { return HorizontalScrollbar.BarOverrideHeight; }
            set { HorizontalScrollbar.BarOverrideHeight = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarScaleProperty = Scrollbar.BarScaleProperty;
        public UnityEngine.Vector3 HorizontalScrollbarBarScale
        {
            get { return HorizontalScrollbar.BarScale; }
            set { HorizontalScrollbar.BarScale = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarAlignmentProperty = Scrollbar.BarAlignmentProperty;
        public Delight.ElementAlignment HorizontalScrollbarBarAlignment
        {
            get { return HorizontalScrollbar.BarAlignment; }
            set { HorizontalScrollbar.BarAlignment = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarMarginProperty = Scrollbar.BarMarginProperty;
        public Delight.ElementMargin HorizontalScrollbarBarMargin
        {
            get { return HorizontalScrollbar.BarMargin; }
            set { HorizontalScrollbar.BarMargin = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarOffsetProperty = Scrollbar.BarOffsetProperty;
        public Delight.ElementMargin HorizontalScrollbarBarOffset
        {
            get { return HorizontalScrollbar.BarOffset; }
            set { HorizontalScrollbar.BarOffset = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarOffsetFromParentProperty = Scrollbar.BarOffsetFromParentProperty;
        public Delight.ElementMargin HorizontalScrollbarBarOffsetFromParent
        {
            get { return HorizontalScrollbar.BarOffsetFromParent; }
            set { HorizontalScrollbar.BarOffsetFromParent = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarPivotProperty = Scrollbar.BarPivotProperty;
        public UnityEngine.Vector2 HorizontalScrollbarBarPivot
        {
            get { return HorizontalScrollbar.BarPivot; }
            set { HorizontalScrollbar.BarPivot = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarLayoutRootProperty = Scrollbar.BarLayoutRootProperty;
        public Delight.LayoutRoot HorizontalScrollbarBarLayoutRoot
        {
            get { return HorizontalScrollbar.BarLayoutRoot; }
            set { HorizontalScrollbar.BarLayoutRoot = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarDisableLayoutUpdateProperty = Scrollbar.BarDisableLayoutUpdateProperty;
        public System.Boolean HorizontalScrollbarBarDisableLayoutUpdate
        {
            get { return HorizontalScrollbar.BarDisableLayoutUpdate; }
            set { HorizontalScrollbar.BarDisableLayoutUpdate = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarAlphaProperty = Scrollbar.BarAlphaProperty;
        public System.Single HorizontalScrollbarBarAlpha
        {
            get { return HorizontalScrollbar.BarAlpha; }
            set { HorizontalScrollbar.BarAlpha = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarIsVisibleProperty = Scrollbar.BarIsVisibleProperty;
        public System.Boolean HorizontalScrollbarBarIsVisible
        {
            get { return HorizontalScrollbar.BarIsVisible; }
            set { HorizontalScrollbar.BarIsVisible = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarRaycastBlockModeProperty = Scrollbar.BarRaycastBlockModeProperty;
        public Delight.RaycastBlockMode HorizontalScrollbarBarRaycastBlockMode
        {
            get { return HorizontalScrollbar.BarRaycastBlockMode; }
            set { HorizontalScrollbar.BarRaycastBlockMode = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarUseFastShaderProperty = Scrollbar.BarUseFastShaderProperty;
        public System.Boolean HorizontalScrollbarBarUseFastShader
        {
            get { return HorizontalScrollbar.BarUseFastShader; }
            set { HorizontalScrollbar.BarUseFastShader = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarBubbleNotifyChildLayoutChangedProperty = Scrollbar.BarBubbleNotifyChildLayoutChangedProperty;
        public System.Boolean HorizontalScrollbarBarBubbleNotifyChildLayoutChanged
        {
            get { return HorizontalScrollbar.BarBubbleNotifyChildLayoutChanged; }
            set { HorizontalScrollbar.BarBubbleNotifyChildLayoutChanged = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarIgnoreFlipProperty = Scrollbar.BarIgnoreFlipProperty;
        public System.Boolean HorizontalScrollbarBarIgnoreFlip
        {
            get { return HorizontalScrollbar.BarIgnoreFlip; }
            set { HorizontalScrollbar.BarIgnoreFlip = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarGameObjectProperty = Scrollbar.BarGameObjectProperty;
        public UnityEngine.GameObject HorizontalScrollbarBarGameObject
        {
            get { return HorizontalScrollbar.BarGameObject; }
            set { HorizontalScrollbar.BarGameObject = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarEnableScriptEventsProperty = Scrollbar.BarEnableScriptEventsProperty;
        public System.Boolean HorizontalScrollbarBarEnableScriptEvents
        {
            get { return HorizontalScrollbar.BarEnableScriptEvents; }
            set { HorizontalScrollbar.BarEnableScriptEvents = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarIgnoreObjectProperty = Scrollbar.BarIgnoreObjectProperty;
        public System.Boolean HorizontalScrollbarBarIgnoreObject
        {
            get { return HorizontalScrollbar.BarIgnoreObject; }
            set { HorizontalScrollbar.BarIgnoreObject = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarIsActiveProperty = Scrollbar.BarIsActiveProperty;
        public System.Boolean HorizontalScrollbarBarIsActive
        {
            get { return HorizontalScrollbar.BarIsActive; }
            set { HorizontalScrollbar.BarIsActive = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarLoadModeProperty = Scrollbar.BarLoadModeProperty;
        public Delight.LoadMode HorizontalScrollbarBarLoadMode
        {
            get { return HorizontalScrollbar.BarLoadMode; }
            set { HorizontalScrollbar.BarLoadMode = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleSpriteProperty = Scrollbar.HandleSpriteProperty;
        public SpriteAsset HorizontalScrollbarHandleSprite
        {
            get { return HorizontalScrollbar.HandleSprite; }
            set { HorizontalScrollbar.HandleSprite = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleOverrideSpriteProperty = Scrollbar.HandleOverrideSpriteProperty;
        public SpriteAsset HorizontalScrollbarHandleOverrideSprite
        {
            get { return HorizontalScrollbar.HandleOverrideSprite; }
            set { HorizontalScrollbar.HandleOverrideSprite = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleTypeProperty = Scrollbar.HandleTypeProperty;
        public UnityEngine.UI.Image.Type HorizontalScrollbarHandleType
        {
            get { return HorizontalScrollbar.HandleType; }
            set { HorizontalScrollbar.HandleType = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandlePreserveAspectProperty = Scrollbar.HandlePreserveAspectProperty;
        public System.Boolean HorizontalScrollbarHandlePreserveAspect
        {
            get { return HorizontalScrollbar.HandlePreserveAspect; }
            set { HorizontalScrollbar.HandlePreserveAspect = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleFillCenterProperty = Scrollbar.HandleFillCenterProperty;
        public System.Boolean HorizontalScrollbarHandleFillCenter
        {
            get { return HorizontalScrollbar.HandleFillCenter; }
            set { HorizontalScrollbar.HandleFillCenter = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleFillMethodProperty = Scrollbar.HandleFillMethodProperty;
        public UnityEngine.UI.Image.FillMethod HorizontalScrollbarHandleFillMethod
        {
            get { return HorizontalScrollbar.HandleFillMethod; }
            set { HorizontalScrollbar.HandleFillMethod = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleFillAmountProperty = Scrollbar.HandleFillAmountProperty;
        public System.Single HorizontalScrollbarHandleFillAmount
        {
            get { return HorizontalScrollbar.HandleFillAmount; }
            set { HorizontalScrollbar.HandleFillAmount = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleFillClockwiseProperty = Scrollbar.HandleFillClockwiseProperty;
        public System.Boolean HorizontalScrollbarHandleFillClockwise
        {
            get { return HorizontalScrollbar.HandleFillClockwise; }
            set { HorizontalScrollbar.HandleFillClockwise = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleFillOriginProperty = Scrollbar.HandleFillOriginProperty;
        public System.Int32 HorizontalScrollbarHandleFillOrigin
        {
            get { return HorizontalScrollbar.HandleFillOrigin; }
            set { HorizontalScrollbar.HandleFillOrigin = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleAlphaHitTestMinimumThresholdProperty = Scrollbar.HandleAlphaHitTestMinimumThresholdProperty;
        public System.Single HorizontalScrollbarHandleAlphaHitTestMinimumThreshold
        {
            get { return HorizontalScrollbar.HandleAlphaHitTestMinimumThreshold; }
            set { HorizontalScrollbar.HandleAlphaHitTestMinimumThreshold = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleUseSpriteMeshProperty = Scrollbar.HandleUseSpriteMeshProperty;
        public System.Boolean HorizontalScrollbarHandleUseSpriteMesh
        {
            get { return HorizontalScrollbar.HandleUseSpriteMesh; }
            set { HorizontalScrollbar.HandleUseSpriteMesh = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleMaterialProperty = Scrollbar.HandleMaterialProperty;
        public MaterialAsset HorizontalScrollbarHandleMaterial
        {
            get { return HorizontalScrollbar.HandleMaterial; }
            set { HorizontalScrollbar.HandleMaterial = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleOnCullStateChangedProperty = Scrollbar.HandleOnCullStateChangedProperty;
        public UnityEngine.UI.MaskableGraphic.CullStateChangedEvent HorizontalScrollbarHandleOnCullStateChanged
        {
            get { return HorizontalScrollbar.HandleOnCullStateChanged; }
            set { HorizontalScrollbar.HandleOnCullStateChanged = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleMaskableProperty = Scrollbar.HandleMaskableProperty;
        public System.Boolean HorizontalScrollbarHandleMaskable
        {
            get { return HorizontalScrollbar.HandleMaskable; }
            set { HorizontalScrollbar.HandleMaskable = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleColorProperty = Scrollbar.HandleColorProperty;
        public UnityEngine.Color HorizontalScrollbarHandleColor
        {
            get { return HorizontalScrollbar.HandleColor; }
            set { HorizontalScrollbar.HandleColor = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleRaycastTargetProperty = Scrollbar.HandleRaycastTargetProperty;
        public System.Boolean HorizontalScrollbarHandleRaycastTarget
        {
            get { return HorizontalScrollbar.HandleRaycastTarget; }
            set { HorizontalScrollbar.HandleRaycastTarget = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleWidthProperty = Scrollbar.HandleWidthProperty;
        public Delight.ElementSize HorizontalScrollbarHandleWidth
        {
            get { return HorizontalScrollbar.HandleWidth; }
            set { HorizontalScrollbar.HandleWidth = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleHeightProperty = Scrollbar.HandleHeightProperty;
        public Delight.ElementSize HorizontalScrollbarHandleHeight
        {
            get { return HorizontalScrollbar.HandleHeight; }
            set { HorizontalScrollbar.HandleHeight = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleOverrideWidthProperty = Scrollbar.HandleOverrideWidthProperty;
        public Delight.ElementSize HorizontalScrollbarHandleOverrideWidth
        {
            get { return HorizontalScrollbar.HandleOverrideWidth; }
            set { HorizontalScrollbar.HandleOverrideWidth = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleOverrideHeightProperty = Scrollbar.HandleOverrideHeightProperty;
        public Delight.ElementSize HorizontalScrollbarHandleOverrideHeight
        {
            get { return HorizontalScrollbar.HandleOverrideHeight; }
            set { HorizontalScrollbar.HandleOverrideHeight = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleScaleProperty = Scrollbar.HandleScaleProperty;
        public UnityEngine.Vector3 HorizontalScrollbarHandleScale
        {
            get { return HorizontalScrollbar.HandleScale; }
            set { HorizontalScrollbar.HandleScale = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleAlignmentProperty = Scrollbar.HandleAlignmentProperty;
        public Delight.ElementAlignment HorizontalScrollbarHandleAlignment
        {
            get { return HorizontalScrollbar.HandleAlignment; }
            set { HorizontalScrollbar.HandleAlignment = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleMarginProperty = Scrollbar.HandleMarginProperty;
        public Delight.ElementMargin HorizontalScrollbarHandleMargin
        {
            get { return HorizontalScrollbar.HandleMargin; }
            set { HorizontalScrollbar.HandleMargin = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleOffsetProperty = Scrollbar.HandleOffsetProperty;
        public Delight.ElementMargin HorizontalScrollbarHandleOffset
        {
            get { return HorizontalScrollbar.HandleOffset; }
            set { HorizontalScrollbar.HandleOffset = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleOffsetFromParentProperty = Scrollbar.HandleOffsetFromParentProperty;
        public Delight.ElementMargin HorizontalScrollbarHandleOffsetFromParent
        {
            get { return HorizontalScrollbar.HandleOffsetFromParent; }
            set { HorizontalScrollbar.HandleOffsetFromParent = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandlePivotProperty = Scrollbar.HandlePivotProperty;
        public UnityEngine.Vector2 HorizontalScrollbarHandlePivot
        {
            get { return HorizontalScrollbar.HandlePivot; }
            set { HorizontalScrollbar.HandlePivot = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleLayoutRootProperty = Scrollbar.HandleLayoutRootProperty;
        public Delight.LayoutRoot HorizontalScrollbarHandleLayoutRoot
        {
            get { return HorizontalScrollbar.HandleLayoutRoot; }
            set { HorizontalScrollbar.HandleLayoutRoot = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleDisableLayoutUpdateProperty = Scrollbar.HandleDisableLayoutUpdateProperty;
        public System.Boolean HorizontalScrollbarHandleDisableLayoutUpdate
        {
            get { return HorizontalScrollbar.HandleDisableLayoutUpdate; }
            set { HorizontalScrollbar.HandleDisableLayoutUpdate = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleAlphaProperty = Scrollbar.HandleAlphaProperty;
        public System.Single HorizontalScrollbarHandleAlpha
        {
            get { return HorizontalScrollbar.HandleAlpha; }
            set { HorizontalScrollbar.HandleAlpha = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleIsVisibleProperty = Scrollbar.HandleIsVisibleProperty;
        public System.Boolean HorizontalScrollbarHandleIsVisible
        {
            get { return HorizontalScrollbar.HandleIsVisible; }
            set { HorizontalScrollbar.HandleIsVisible = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleRaycastBlockModeProperty = Scrollbar.HandleRaycastBlockModeProperty;
        public Delight.RaycastBlockMode HorizontalScrollbarHandleRaycastBlockMode
        {
            get { return HorizontalScrollbar.HandleRaycastBlockMode; }
            set { HorizontalScrollbar.HandleRaycastBlockMode = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleUseFastShaderProperty = Scrollbar.HandleUseFastShaderProperty;
        public System.Boolean HorizontalScrollbarHandleUseFastShader
        {
            get { return HorizontalScrollbar.HandleUseFastShader; }
            set { HorizontalScrollbar.HandleUseFastShader = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleBubbleNotifyChildLayoutChangedProperty = Scrollbar.HandleBubbleNotifyChildLayoutChangedProperty;
        public System.Boolean HorizontalScrollbarHandleBubbleNotifyChildLayoutChanged
        {
            get { return HorizontalScrollbar.HandleBubbleNotifyChildLayoutChanged; }
            set { HorizontalScrollbar.HandleBubbleNotifyChildLayoutChanged = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleIgnoreFlipProperty = Scrollbar.HandleIgnoreFlipProperty;
        public System.Boolean HorizontalScrollbarHandleIgnoreFlip
        {
            get { return HorizontalScrollbar.HandleIgnoreFlip; }
            set { HorizontalScrollbar.HandleIgnoreFlip = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleGameObjectProperty = Scrollbar.HandleGameObjectProperty;
        public UnityEngine.GameObject HorizontalScrollbarHandleGameObject
        {
            get { return HorizontalScrollbar.HandleGameObject; }
            set { HorizontalScrollbar.HandleGameObject = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleEnableScriptEventsProperty = Scrollbar.HandleEnableScriptEventsProperty;
        public System.Boolean HorizontalScrollbarHandleEnableScriptEvents
        {
            get { return HorizontalScrollbar.HandleEnableScriptEvents; }
            set { HorizontalScrollbar.HandleEnableScriptEvents = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleIgnoreObjectProperty = Scrollbar.HandleIgnoreObjectProperty;
        public System.Boolean HorizontalScrollbarHandleIgnoreObject
        {
            get { return HorizontalScrollbar.HandleIgnoreObject; }
            set { HorizontalScrollbar.HandleIgnoreObject = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleIsActiveProperty = Scrollbar.HandleIsActiveProperty;
        public System.Boolean HorizontalScrollbarHandleIsActive
        {
            get { return HorizontalScrollbar.HandleIsActive; }
            set { HorizontalScrollbar.HandleIsActive = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleLoadModeProperty = Scrollbar.HandleLoadModeProperty;
        public Delight.LoadMode HorizontalScrollbarHandleLoadMode
        {
            get { return HorizontalScrollbar.HandleLoadMode; }
            set { HorizontalScrollbar.HandleLoadMode = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBackgroundSpriteProperty = Scrollbar.BackgroundSpriteProperty;
        public SpriteAsset HorizontalScrollbarBackgroundSprite
        {
            get { return HorizontalScrollbar.BackgroundSprite; }
            set { HorizontalScrollbar.BackgroundSprite = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBackgroundOverrideSpriteProperty = Scrollbar.BackgroundOverrideSpriteProperty;
        public SpriteAsset HorizontalScrollbarBackgroundOverrideSprite
        {
            get { return HorizontalScrollbar.BackgroundOverrideSprite; }
            set { HorizontalScrollbar.BackgroundOverrideSprite = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBackgroundTypeProperty = Scrollbar.BackgroundTypeProperty;
        public UnityEngine.UI.Image.Type HorizontalScrollbarBackgroundType
        {
            get { return HorizontalScrollbar.BackgroundType; }
            set { HorizontalScrollbar.BackgroundType = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBackgroundPreserveAspectProperty = Scrollbar.BackgroundPreserveAspectProperty;
        public System.Boolean HorizontalScrollbarBackgroundPreserveAspect
        {
            get { return HorizontalScrollbar.BackgroundPreserveAspect; }
            set { HorizontalScrollbar.BackgroundPreserveAspect = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBackgroundFillCenterProperty = Scrollbar.BackgroundFillCenterProperty;
        public System.Boolean HorizontalScrollbarBackgroundFillCenter
        {
            get { return HorizontalScrollbar.BackgroundFillCenter; }
            set { HorizontalScrollbar.BackgroundFillCenter = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBackgroundFillMethodProperty = Scrollbar.BackgroundFillMethodProperty;
        public UnityEngine.UI.Image.FillMethod HorizontalScrollbarBackgroundFillMethod
        {
            get { return HorizontalScrollbar.BackgroundFillMethod; }
            set { HorizontalScrollbar.BackgroundFillMethod = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBackgroundFillAmountProperty = Scrollbar.BackgroundFillAmountProperty;
        public System.Single HorizontalScrollbarBackgroundFillAmount
        {
            get { return HorizontalScrollbar.BackgroundFillAmount; }
            set { HorizontalScrollbar.BackgroundFillAmount = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBackgroundFillClockwiseProperty = Scrollbar.BackgroundFillClockwiseProperty;
        public System.Boolean HorizontalScrollbarBackgroundFillClockwise
        {
            get { return HorizontalScrollbar.BackgroundFillClockwise; }
            set { HorizontalScrollbar.BackgroundFillClockwise = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBackgroundFillOriginProperty = Scrollbar.BackgroundFillOriginProperty;
        public System.Int32 HorizontalScrollbarBackgroundFillOrigin
        {
            get { return HorizontalScrollbar.BackgroundFillOrigin; }
            set { HorizontalScrollbar.BackgroundFillOrigin = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBackgroundAlphaHitTestMinimumThresholdProperty = Scrollbar.BackgroundAlphaHitTestMinimumThresholdProperty;
        public System.Single HorizontalScrollbarBackgroundAlphaHitTestMinimumThreshold
        {
            get { return HorizontalScrollbar.BackgroundAlphaHitTestMinimumThreshold; }
            set { HorizontalScrollbar.BackgroundAlphaHitTestMinimumThreshold = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBackgroundUseSpriteMeshProperty = Scrollbar.BackgroundUseSpriteMeshProperty;
        public System.Boolean HorizontalScrollbarBackgroundUseSpriteMesh
        {
            get { return HorizontalScrollbar.BackgroundUseSpriteMesh; }
            set { HorizontalScrollbar.BackgroundUseSpriteMesh = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBackgroundMaterialProperty = Scrollbar.BackgroundMaterialProperty;
        public MaterialAsset HorizontalScrollbarBackgroundMaterial
        {
            get { return HorizontalScrollbar.BackgroundMaterial; }
            set { HorizontalScrollbar.BackgroundMaterial = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBackgroundOnCullStateChangedProperty = Scrollbar.BackgroundOnCullStateChangedProperty;
        public UnityEngine.UI.MaskableGraphic.CullStateChangedEvent HorizontalScrollbarBackgroundOnCullStateChanged
        {
            get { return HorizontalScrollbar.BackgroundOnCullStateChanged; }
            set { HorizontalScrollbar.BackgroundOnCullStateChanged = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBackgroundMaskableProperty = Scrollbar.BackgroundMaskableProperty;
        public System.Boolean HorizontalScrollbarBackgroundMaskable
        {
            get { return HorizontalScrollbar.BackgroundMaskable; }
            set { HorizontalScrollbar.BackgroundMaskable = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBackgroundColorProperty = Scrollbar.BackgroundColorProperty;
        public UnityEngine.Color HorizontalScrollbarBackgroundColor
        {
            get { return HorizontalScrollbar.BackgroundColor; }
            set { HorizontalScrollbar.BackgroundColor = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBackgroundRaycastTargetProperty = Scrollbar.BackgroundRaycastTargetProperty;
        public System.Boolean HorizontalScrollbarBackgroundRaycastTarget
        {
            get { return HorizontalScrollbar.BackgroundRaycastTarget; }
            set { HorizontalScrollbar.BackgroundRaycastTarget = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarWidthProperty = Scrollbar.WidthProperty;
        public Delight.ElementSize HorizontalScrollbarWidth
        {
            get { return HorizontalScrollbar.Width; }
            set { HorizontalScrollbar.Width = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHeightProperty = Scrollbar.HeightProperty;
        public Delight.ElementSize HorizontalScrollbarHeight
        {
            get { return HorizontalScrollbar.Height; }
            set { HorizontalScrollbar.Height = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarOverrideWidthProperty = Scrollbar.OverrideWidthProperty;
        public Delight.ElementSize HorizontalScrollbarOverrideWidth
        {
            get { return HorizontalScrollbar.OverrideWidth; }
            set { HorizontalScrollbar.OverrideWidth = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarOverrideHeightProperty = Scrollbar.OverrideHeightProperty;
        public Delight.ElementSize HorizontalScrollbarOverrideHeight
        {
            get { return HorizontalScrollbar.OverrideHeight; }
            set { HorizontalScrollbar.OverrideHeight = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarScaleProperty = Scrollbar.ScaleProperty;
        public UnityEngine.Vector3 HorizontalScrollbarScale
        {
            get { return HorizontalScrollbar.Scale; }
            set { HorizontalScrollbar.Scale = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarAlignmentProperty = Scrollbar.AlignmentProperty;
        public Delight.ElementAlignment HorizontalScrollbarAlignment
        {
            get { return HorizontalScrollbar.Alignment; }
            set { HorizontalScrollbar.Alignment = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarMarginProperty = Scrollbar.MarginProperty;
        public Delight.ElementMargin HorizontalScrollbarMargin
        {
            get { return HorizontalScrollbar.Margin; }
            set { HorizontalScrollbar.Margin = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarOffsetProperty = Scrollbar.OffsetProperty;
        public Delight.ElementMargin HorizontalScrollbarOffset
        {
            get { return HorizontalScrollbar.Offset; }
            set { HorizontalScrollbar.Offset = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarOffsetFromParentProperty = Scrollbar.OffsetFromParentProperty;
        public Delight.ElementMargin HorizontalScrollbarOffsetFromParent
        {
            get { return HorizontalScrollbar.OffsetFromParent; }
            set { HorizontalScrollbar.OffsetFromParent = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarPivotProperty = Scrollbar.PivotProperty;
        public UnityEngine.Vector2 HorizontalScrollbarPivot
        {
            get { return HorizontalScrollbar.Pivot; }
            set { HorizontalScrollbar.Pivot = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarLayoutRootProperty = Scrollbar.LayoutRootProperty;
        public Delight.LayoutRoot HorizontalScrollbarLayoutRoot
        {
            get { return HorizontalScrollbar.LayoutRoot; }
            set { HorizontalScrollbar.LayoutRoot = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarDisableLayoutUpdateProperty = Scrollbar.DisableLayoutUpdateProperty;
        public System.Boolean HorizontalScrollbarDisableLayoutUpdate
        {
            get { return HorizontalScrollbar.DisableLayoutUpdate; }
            set { HorizontalScrollbar.DisableLayoutUpdate = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarAlphaProperty = Scrollbar.AlphaProperty;
        public System.Single HorizontalScrollbarAlpha
        {
            get { return HorizontalScrollbar.Alpha; }
            set { HorizontalScrollbar.Alpha = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarIsVisibleProperty = Scrollbar.IsVisibleProperty;
        public System.Boolean HorizontalScrollbarIsVisible
        {
            get { return HorizontalScrollbar.IsVisible; }
            set { HorizontalScrollbar.IsVisible = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarRaycastBlockModeProperty = Scrollbar.RaycastBlockModeProperty;
        public Delight.RaycastBlockMode HorizontalScrollbarRaycastBlockMode
        {
            get { return HorizontalScrollbar.RaycastBlockMode; }
            set { HorizontalScrollbar.RaycastBlockMode = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarUseFastShaderProperty = Scrollbar.UseFastShaderProperty;
        public System.Boolean HorizontalScrollbarUseFastShader
        {
            get { return HorizontalScrollbar.UseFastShader; }
            set { HorizontalScrollbar.UseFastShader = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBubbleNotifyChildLayoutChangedProperty = Scrollbar.BubbleNotifyChildLayoutChangedProperty;
        public System.Boolean HorizontalScrollbarBubbleNotifyChildLayoutChanged
        {
            get { return HorizontalScrollbar.BubbleNotifyChildLayoutChanged; }
            set { HorizontalScrollbar.BubbleNotifyChildLayoutChanged = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarIgnoreFlipProperty = Scrollbar.IgnoreFlipProperty;
        public System.Boolean HorizontalScrollbarIgnoreFlip
        {
            get { return HorizontalScrollbar.IgnoreFlip; }
            set { HorizontalScrollbar.IgnoreFlip = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarGameObjectProperty = Scrollbar.GameObjectProperty;
        public UnityEngine.GameObject HorizontalScrollbarGameObject
        {
            get { return HorizontalScrollbar.GameObject; }
            set { HorizontalScrollbar.GameObject = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarEnableScriptEventsProperty = Scrollbar.EnableScriptEventsProperty;
        public System.Boolean HorizontalScrollbarEnableScriptEvents
        {
            get { return HorizontalScrollbar.EnableScriptEvents; }
            set { HorizontalScrollbar.EnableScriptEvents = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarIgnoreObjectProperty = Scrollbar.IgnoreObjectProperty;
        public System.Boolean HorizontalScrollbarIgnoreObject
        {
            get { return HorizontalScrollbar.IgnoreObject; }
            set { HorizontalScrollbar.IgnoreObject = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarIsActiveProperty = Scrollbar.IsActiveProperty;
        public System.Boolean HorizontalScrollbarIsActive
        {
            get { return HorizontalScrollbar.IsActive; }
            set { HorizontalScrollbar.IsActive = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarLoadModeProperty = Scrollbar.LoadModeProperty;
        public Delight.LoadMode HorizontalScrollbarLoadMode
        {
            get { return HorizontalScrollbar.LoadMode; }
            set { HorizontalScrollbar.LoadMode = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarLengthProperty = Scrollbar.LengthProperty;
        public Delight.ElementSize VerticalScrollbarLength
        {
            get { return VerticalScrollbar.Length; }
            set { VerticalScrollbar.Length = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBreadthProperty = Scrollbar.BreadthProperty;
        public Delight.ElementSize VerticalScrollbarBreadth
        {
            get { return VerticalScrollbar.Breadth; }
            set { VerticalScrollbar.Breadth = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarOrientationProperty = Scrollbar.OrientationProperty;
        public Delight.ElementOrientation VerticalScrollbarOrientation
        {
            get { return VerticalScrollbar.Orientation; }
            set { VerticalScrollbar.Orientation = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarScrollPositionProperty = Scrollbar.ScrollPositionProperty;
        public System.Single VerticalScrollbarScrollPosition
        {
            get { return VerticalScrollbar.ScrollPosition; }
            set { VerticalScrollbar.ScrollPosition = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarViewportRatioProperty = Scrollbar.ViewportRatioProperty;
        public System.Single VerticalScrollbarViewportRatio
        {
            get { return VerticalScrollbar.ViewportRatio; }
            set { VerticalScrollbar.ViewportRatio = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarSpriteProperty = Scrollbar.BarSpriteProperty;
        public SpriteAsset VerticalScrollbarBarSprite
        {
            get { return VerticalScrollbar.BarSprite; }
            set { VerticalScrollbar.BarSprite = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarOverrideSpriteProperty = Scrollbar.BarOverrideSpriteProperty;
        public SpriteAsset VerticalScrollbarBarOverrideSprite
        {
            get { return VerticalScrollbar.BarOverrideSprite; }
            set { VerticalScrollbar.BarOverrideSprite = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarTypeProperty = Scrollbar.BarTypeProperty;
        public UnityEngine.UI.Image.Type VerticalScrollbarBarType
        {
            get { return VerticalScrollbar.BarType; }
            set { VerticalScrollbar.BarType = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarPreserveAspectProperty = Scrollbar.BarPreserveAspectProperty;
        public System.Boolean VerticalScrollbarBarPreserveAspect
        {
            get { return VerticalScrollbar.BarPreserveAspect; }
            set { VerticalScrollbar.BarPreserveAspect = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarFillCenterProperty = Scrollbar.BarFillCenterProperty;
        public System.Boolean VerticalScrollbarBarFillCenter
        {
            get { return VerticalScrollbar.BarFillCenter; }
            set { VerticalScrollbar.BarFillCenter = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarFillMethodProperty = Scrollbar.BarFillMethodProperty;
        public UnityEngine.UI.Image.FillMethod VerticalScrollbarBarFillMethod
        {
            get { return VerticalScrollbar.BarFillMethod; }
            set { VerticalScrollbar.BarFillMethod = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarFillAmountProperty = Scrollbar.BarFillAmountProperty;
        public System.Single VerticalScrollbarBarFillAmount
        {
            get { return VerticalScrollbar.BarFillAmount; }
            set { VerticalScrollbar.BarFillAmount = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarFillClockwiseProperty = Scrollbar.BarFillClockwiseProperty;
        public System.Boolean VerticalScrollbarBarFillClockwise
        {
            get { return VerticalScrollbar.BarFillClockwise; }
            set { VerticalScrollbar.BarFillClockwise = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarFillOriginProperty = Scrollbar.BarFillOriginProperty;
        public System.Int32 VerticalScrollbarBarFillOrigin
        {
            get { return VerticalScrollbar.BarFillOrigin; }
            set { VerticalScrollbar.BarFillOrigin = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarAlphaHitTestMinimumThresholdProperty = Scrollbar.BarAlphaHitTestMinimumThresholdProperty;
        public System.Single VerticalScrollbarBarAlphaHitTestMinimumThreshold
        {
            get { return VerticalScrollbar.BarAlphaHitTestMinimumThreshold; }
            set { VerticalScrollbar.BarAlphaHitTestMinimumThreshold = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarUseSpriteMeshProperty = Scrollbar.BarUseSpriteMeshProperty;
        public System.Boolean VerticalScrollbarBarUseSpriteMesh
        {
            get { return VerticalScrollbar.BarUseSpriteMesh; }
            set { VerticalScrollbar.BarUseSpriteMesh = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarMaterialProperty = Scrollbar.BarMaterialProperty;
        public MaterialAsset VerticalScrollbarBarMaterial
        {
            get { return VerticalScrollbar.BarMaterial; }
            set { VerticalScrollbar.BarMaterial = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarOnCullStateChangedProperty = Scrollbar.BarOnCullStateChangedProperty;
        public UnityEngine.UI.MaskableGraphic.CullStateChangedEvent VerticalScrollbarBarOnCullStateChanged
        {
            get { return VerticalScrollbar.BarOnCullStateChanged; }
            set { VerticalScrollbar.BarOnCullStateChanged = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarMaskableProperty = Scrollbar.BarMaskableProperty;
        public System.Boolean VerticalScrollbarBarMaskable
        {
            get { return VerticalScrollbar.BarMaskable; }
            set { VerticalScrollbar.BarMaskable = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarColorProperty = Scrollbar.BarColorProperty;
        public UnityEngine.Color VerticalScrollbarBarColor
        {
            get { return VerticalScrollbar.BarColor; }
            set { VerticalScrollbar.BarColor = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarRaycastTargetProperty = Scrollbar.BarRaycastTargetProperty;
        public System.Boolean VerticalScrollbarBarRaycastTarget
        {
            get { return VerticalScrollbar.BarRaycastTarget; }
            set { VerticalScrollbar.BarRaycastTarget = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarWidthProperty = Scrollbar.BarWidthProperty;
        public Delight.ElementSize VerticalScrollbarBarWidth
        {
            get { return VerticalScrollbar.BarWidth; }
            set { VerticalScrollbar.BarWidth = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarHeightProperty = Scrollbar.BarHeightProperty;
        public Delight.ElementSize VerticalScrollbarBarHeight
        {
            get { return VerticalScrollbar.BarHeight; }
            set { VerticalScrollbar.BarHeight = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarOverrideWidthProperty = Scrollbar.BarOverrideWidthProperty;
        public Delight.ElementSize VerticalScrollbarBarOverrideWidth
        {
            get { return VerticalScrollbar.BarOverrideWidth; }
            set { VerticalScrollbar.BarOverrideWidth = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarOverrideHeightProperty = Scrollbar.BarOverrideHeightProperty;
        public Delight.ElementSize VerticalScrollbarBarOverrideHeight
        {
            get { return VerticalScrollbar.BarOverrideHeight; }
            set { VerticalScrollbar.BarOverrideHeight = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarScaleProperty = Scrollbar.BarScaleProperty;
        public UnityEngine.Vector3 VerticalScrollbarBarScale
        {
            get { return VerticalScrollbar.BarScale; }
            set { VerticalScrollbar.BarScale = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarAlignmentProperty = Scrollbar.BarAlignmentProperty;
        public Delight.ElementAlignment VerticalScrollbarBarAlignment
        {
            get { return VerticalScrollbar.BarAlignment; }
            set { VerticalScrollbar.BarAlignment = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarMarginProperty = Scrollbar.BarMarginProperty;
        public Delight.ElementMargin VerticalScrollbarBarMargin
        {
            get { return VerticalScrollbar.BarMargin; }
            set { VerticalScrollbar.BarMargin = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarOffsetProperty = Scrollbar.BarOffsetProperty;
        public Delight.ElementMargin VerticalScrollbarBarOffset
        {
            get { return VerticalScrollbar.BarOffset; }
            set { VerticalScrollbar.BarOffset = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarOffsetFromParentProperty = Scrollbar.BarOffsetFromParentProperty;
        public Delight.ElementMargin VerticalScrollbarBarOffsetFromParent
        {
            get { return VerticalScrollbar.BarOffsetFromParent; }
            set { VerticalScrollbar.BarOffsetFromParent = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarPivotProperty = Scrollbar.BarPivotProperty;
        public UnityEngine.Vector2 VerticalScrollbarBarPivot
        {
            get { return VerticalScrollbar.BarPivot; }
            set { VerticalScrollbar.BarPivot = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarLayoutRootProperty = Scrollbar.BarLayoutRootProperty;
        public Delight.LayoutRoot VerticalScrollbarBarLayoutRoot
        {
            get { return VerticalScrollbar.BarLayoutRoot; }
            set { VerticalScrollbar.BarLayoutRoot = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarDisableLayoutUpdateProperty = Scrollbar.BarDisableLayoutUpdateProperty;
        public System.Boolean VerticalScrollbarBarDisableLayoutUpdate
        {
            get { return VerticalScrollbar.BarDisableLayoutUpdate; }
            set { VerticalScrollbar.BarDisableLayoutUpdate = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarAlphaProperty = Scrollbar.BarAlphaProperty;
        public System.Single VerticalScrollbarBarAlpha
        {
            get { return VerticalScrollbar.BarAlpha; }
            set { VerticalScrollbar.BarAlpha = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarIsVisibleProperty = Scrollbar.BarIsVisibleProperty;
        public System.Boolean VerticalScrollbarBarIsVisible
        {
            get { return VerticalScrollbar.BarIsVisible; }
            set { VerticalScrollbar.BarIsVisible = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarRaycastBlockModeProperty = Scrollbar.BarRaycastBlockModeProperty;
        public Delight.RaycastBlockMode VerticalScrollbarBarRaycastBlockMode
        {
            get { return VerticalScrollbar.BarRaycastBlockMode; }
            set { VerticalScrollbar.BarRaycastBlockMode = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarUseFastShaderProperty = Scrollbar.BarUseFastShaderProperty;
        public System.Boolean VerticalScrollbarBarUseFastShader
        {
            get { return VerticalScrollbar.BarUseFastShader; }
            set { VerticalScrollbar.BarUseFastShader = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarBubbleNotifyChildLayoutChangedProperty = Scrollbar.BarBubbleNotifyChildLayoutChangedProperty;
        public System.Boolean VerticalScrollbarBarBubbleNotifyChildLayoutChanged
        {
            get { return VerticalScrollbar.BarBubbleNotifyChildLayoutChanged; }
            set { VerticalScrollbar.BarBubbleNotifyChildLayoutChanged = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarIgnoreFlipProperty = Scrollbar.BarIgnoreFlipProperty;
        public System.Boolean VerticalScrollbarBarIgnoreFlip
        {
            get { return VerticalScrollbar.BarIgnoreFlip; }
            set { VerticalScrollbar.BarIgnoreFlip = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarGameObjectProperty = Scrollbar.BarGameObjectProperty;
        public UnityEngine.GameObject VerticalScrollbarBarGameObject
        {
            get { return VerticalScrollbar.BarGameObject; }
            set { VerticalScrollbar.BarGameObject = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarEnableScriptEventsProperty = Scrollbar.BarEnableScriptEventsProperty;
        public System.Boolean VerticalScrollbarBarEnableScriptEvents
        {
            get { return VerticalScrollbar.BarEnableScriptEvents; }
            set { VerticalScrollbar.BarEnableScriptEvents = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarIgnoreObjectProperty = Scrollbar.BarIgnoreObjectProperty;
        public System.Boolean VerticalScrollbarBarIgnoreObject
        {
            get { return VerticalScrollbar.BarIgnoreObject; }
            set { VerticalScrollbar.BarIgnoreObject = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarIsActiveProperty = Scrollbar.BarIsActiveProperty;
        public System.Boolean VerticalScrollbarBarIsActive
        {
            get { return VerticalScrollbar.BarIsActive; }
            set { VerticalScrollbar.BarIsActive = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarLoadModeProperty = Scrollbar.BarLoadModeProperty;
        public Delight.LoadMode VerticalScrollbarBarLoadMode
        {
            get { return VerticalScrollbar.BarLoadMode; }
            set { VerticalScrollbar.BarLoadMode = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleSpriteProperty = Scrollbar.HandleSpriteProperty;
        public SpriteAsset VerticalScrollbarHandleSprite
        {
            get { return VerticalScrollbar.HandleSprite; }
            set { VerticalScrollbar.HandleSprite = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleOverrideSpriteProperty = Scrollbar.HandleOverrideSpriteProperty;
        public SpriteAsset VerticalScrollbarHandleOverrideSprite
        {
            get { return VerticalScrollbar.HandleOverrideSprite; }
            set { VerticalScrollbar.HandleOverrideSprite = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleTypeProperty = Scrollbar.HandleTypeProperty;
        public UnityEngine.UI.Image.Type VerticalScrollbarHandleType
        {
            get { return VerticalScrollbar.HandleType; }
            set { VerticalScrollbar.HandleType = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandlePreserveAspectProperty = Scrollbar.HandlePreserveAspectProperty;
        public System.Boolean VerticalScrollbarHandlePreserveAspect
        {
            get { return VerticalScrollbar.HandlePreserveAspect; }
            set { VerticalScrollbar.HandlePreserveAspect = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleFillCenterProperty = Scrollbar.HandleFillCenterProperty;
        public System.Boolean VerticalScrollbarHandleFillCenter
        {
            get { return VerticalScrollbar.HandleFillCenter; }
            set { VerticalScrollbar.HandleFillCenter = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleFillMethodProperty = Scrollbar.HandleFillMethodProperty;
        public UnityEngine.UI.Image.FillMethod VerticalScrollbarHandleFillMethod
        {
            get { return VerticalScrollbar.HandleFillMethod; }
            set { VerticalScrollbar.HandleFillMethod = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleFillAmountProperty = Scrollbar.HandleFillAmountProperty;
        public System.Single VerticalScrollbarHandleFillAmount
        {
            get { return VerticalScrollbar.HandleFillAmount; }
            set { VerticalScrollbar.HandleFillAmount = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleFillClockwiseProperty = Scrollbar.HandleFillClockwiseProperty;
        public System.Boolean VerticalScrollbarHandleFillClockwise
        {
            get { return VerticalScrollbar.HandleFillClockwise; }
            set { VerticalScrollbar.HandleFillClockwise = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleFillOriginProperty = Scrollbar.HandleFillOriginProperty;
        public System.Int32 VerticalScrollbarHandleFillOrigin
        {
            get { return VerticalScrollbar.HandleFillOrigin; }
            set { VerticalScrollbar.HandleFillOrigin = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleAlphaHitTestMinimumThresholdProperty = Scrollbar.HandleAlphaHitTestMinimumThresholdProperty;
        public System.Single VerticalScrollbarHandleAlphaHitTestMinimumThreshold
        {
            get { return VerticalScrollbar.HandleAlphaHitTestMinimumThreshold; }
            set { VerticalScrollbar.HandleAlphaHitTestMinimumThreshold = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleUseSpriteMeshProperty = Scrollbar.HandleUseSpriteMeshProperty;
        public System.Boolean VerticalScrollbarHandleUseSpriteMesh
        {
            get { return VerticalScrollbar.HandleUseSpriteMesh; }
            set { VerticalScrollbar.HandleUseSpriteMesh = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleMaterialProperty = Scrollbar.HandleMaterialProperty;
        public MaterialAsset VerticalScrollbarHandleMaterial
        {
            get { return VerticalScrollbar.HandleMaterial; }
            set { VerticalScrollbar.HandleMaterial = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleOnCullStateChangedProperty = Scrollbar.HandleOnCullStateChangedProperty;
        public UnityEngine.UI.MaskableGraphic.CullStateChangedEvent VerticalScrollbarHandleOnCullStateChanged
        {
            get { return VerticalScrollbar.HandleOnCullStateChanged; }
            set { VerticalScrollbar.HandleOnCullStateChanged = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleMaskableProperty = Scrollbar.HandleMaskableProperty;
        public System.Boolean VerticalScrollbarHandleMaskable
        {
            get { return VerticalScrollbar.HandleMaskable; }
            set { VerticalScrollbar.HandleMaskable = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleColorProperty = Scrollbar.HandleColorProperty;
        public UnityEngine.Color VerticalScrollbarHandleColor
        {
            get { return VerticalScrollbar.HandleColor; }
            set { VerticalScrollbar.HandleColor = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleRaycastTargetProperty = Scrollbar.HandleRaycastTargetProperty;
        public System.Boolean VerticalScrollbarHandleRaycastTarget
        {
            get { return VerticalScrollbar.HandleRaycastTarget; }
            set { VerticalScrollbar.HandleRaycastTarget = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleWidthProperty = Scrollbar.HandleWidthProperty;
        public Delight.ElementSize VerticalScrollbarHandleWidth
        {
            get { return VerticalScrollbar.HandleWidth; }
            set { VerticalScrollbar.HandleWidth = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleHeightProperty = Scrollbar.HandleHeightProperty;
        public Delight.ElementSize VerticalScrollbarHandleHeight
        {
            get { return VerticalScrollbar.HandleHeight; }
            set { VerticalScrollbar.HandleHeight = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleOverrideWidthProperty = Scrollbar.HandleOverrideWidthProperty;
        public Delight.ElementSize VerticalScrollbarHandleOverrideWidth
        {
            get { return VerticalScrollbar.HandleOverrideWidth; }
            set { VerticalScrollbar.HandleOverrideWidth = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleOverrideHeightProperty = Scrollbar.HandleOverrideHeightProperty;
        public Delight.ElementSize VerticalScrollbarHandleOverrideHeight
        {
            get { return VerticalScrollbar.HandleOverrideHeight; }
            set { VerticalScrollbar.HandleOverrideHeight = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleScaleProperty = Scrollbar.HandleScaleProperty;
        public UnityEngine.Vector3 VerticalScrollbarHandleScale
        {
            get { return VerticalScrollbar.HandleScale; }
            set { VerticalScrollbar.HandleScale = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleAlignmentProperty = Scrollbar.HandleAlignmentProperty;
        public Delight.ElementAlignment VerticalScrollbarHandleAlignment
        {
            get { return VerticalScrollbar.HandleAlignment; }
            set { VerticalScrollbar.HandleAlignment = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleMarginProperty = Scrollbar.HandleMarginProperty;
        public Delight.ElementMargin VerticalScrollbarHandleMargin
        {
            get { return VerticalScrollbar.HandleMargin; }
            set { VerticalScrollbar.HandleMargin = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleOffsetProperty = Scrollbar.HandleOffsetProperty;
        public Delight.ElementMargin VerticalScrollbarHandleOffset
        {
            get { return VerticalScrollbar.HandleOffset; }
            set { VerticalScrollbar.HandleOffset = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleOffsetFromParentProperty = Scrollbar.HandleOffsetFromParentProperty;
        public Delight.ElementMargin VerticalScrollbarHandleOffsetFromParent
        {
            get { return VerticalScrollbar.HandleOffsetFromParent; }
            set { VerticalScrollbar.HandleOffsetFromParent = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandlePivotProperty = Scrollbar.HandlePivotProperty;
        public UnityEngine.Vector2 VerticalScrollbarHandlePivot
        {
            get { return VerticalScrollbar.HandlePivot; }
            set { VerticalScrollbar.HandlePivot = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleLayoutRootProperty = Scrollbar.HandleLayoutRootProperty;
        public Delight.LayoutRoot VerticalScrollbarHandleLayoutRoot
        {
            get { return VerticalScrollbar.HandleLayoutRoot; }
            set { VerticalScrollbar.HandleLayoutRoot = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleDisableLayoutUpdateProperty = Scrollbar.HandleDisableLayoutUpdateProperty;
        public System.Boolean VerticalScrollbarHandleDisableLayoutUpdate
        {
            get { return VerticalScrollbar.HandleDisableLayoutUpdate; }
            set { VerticalScrollbar.HandleDisableLayoutUpdate = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleAlphaProperty = Scrollbar.HandleAlphaProperty;
        public System.Single VerticalScrollbarHandleAlpha
        {
            get { return VerticalScrollbar.HandleAlpha; }
            set { VerticalScrollbar.HandleAlpha = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleIsVisibleProperty = Scrollbar.HandleIsVisibleProperty;
        public System.Boolean VerticalScrollbarHandleIsVisible
        {
            get { return VerticalScrollbar.HandleIsVisible; }
            set { VerticalScrollbar.HandleIsVisible = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleRaycastBlockModeProperty = Scrollbar.HandleRaycastBlockModeProperty;
        public Delight.RaycastBlockMode VerticalScrollbarHandleRaycastBlockMode
        {
            get { return VerticalScrollbar.HandleRaycastBlockMode; }
            set { VerticalScrollbar.HandleRaycastBlockMode = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleUseFastShaderProperty = Scrollbar.HandleUseFastShaderProperty;
        public System.Boolean VerticalScrollbarHandleUseFastShader
        {
            get { return VerticalScrollbar.HandleUseFastShader; }
            set { VerticalScrollbar.HandleUseFastShader = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleBubbleNotifyChildLayoutChangedProperty = Scrollbar.HandleBubbleNotifyChildLayoutChangedProperty;
        public System.Boolean VerticalScrollbarHandleBubbleNotifyChildLayoutChanged
        {
            get { return VerticalScrollbar.HandleBubbleNotifyChildLayoutChanged; }
            set { VerticalScrollbar.HandleBubbleNotifyChildLayoutChanged = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleIgnoreFlipProperty = Scrollbar.HandleIgnoreFlipProperty;
        public System.Boolean VerticalScrollbarHandleIgnoreFlip
        {
            get { return VerticalScrollbar.HandleIgnoreFlip; }
            set { VerticalScrollbar.HandleIgnoreFlip = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleGameObjectProperty = Scrollbar.HandleGameObjectProperty;
        public UnityEngine.GameObject VerticalScrollbarHandleGameObject
        {
            get { return VerticalScrollbar.HandleGameObject; }
            set { VerticalScrollbar.HandleGameObject = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleEnableScriptEventsProperty = Scrollbar.HandleEnableScriptEventsProperty;
        public System.Boolean VerticalScrollbarHandleEnableScriptEvents
        {
            get { return VerticalScrollbar.HandleEnableScriptEvents; }
            set { VerticalScrollbar.HandleEnableScriptEvents = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleIgnoreObjectProperty = Scrollbar.HandleIgnoreObjectProperty;
        public System.Boolean VerticalScrollbarHandleIgnoreObject
        {
            get { return VerticalScrollbar.HandleIgnoreObject; }
            set { VerticalScrollbar.HandleIgnoreObject = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleIsActiveProperty = Scrollbar.HandleIsActiveProperty;
        public System.Boolean VerticalScrollbarHandleIsActive
        {
            get { return VerticalScrollbar.HandleIsActive; }
            set { VerticalScrollbar.HandleIsActive = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleLoadModeProperty = Scrollbar.HandleLoadModeProperty;
        public Delight.LoadMode VerticalScrollbarHandleLoadMode
        {
            get { return VerticalScrollbar.HandleLoadMode; }
            set { VerticalScrollbar.HandleLoadMode = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBackgroundSpriteProperty = Scrollbar.BackgroundSpriteProperty;
        public SpriteAsset VerticalScrollbarBackgroundSprite
        {
            get { return VerticalScrollbar.BackgroundSprite; }
            set { VerticalScrollbar.BackgroundSprite = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBackgroundOverrideSpriteProperty = Scrollbar.BackgroundOverrideSpriteProperty;
        public SpriteAsset VerticalScrollbarBackgroundOverrideSprite
        {
            get { return VerticalScrollbar.BackgroundOverrideSprite; }
            set { VerticalScrollbar.BackgroundOverrideSprite = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBackgroundTypeProperty = Scrollbar.BackgroundTypeProperty;
        public UnityEngine.UI.Image.Type VerticalScrollbarBackgroundType
        {
            get { return VerticalScrollbar.BackgroundType; }
            set { VerticalScrollbar.BackgroundType = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBackgroundPreserveAspectProperty = Scrollbar.BackgroundPreserveAspectProperty;
        public System.Boolean VerticalScrollbarBackgroundPreserveAspect
        {
            get { return VerticalScrollbar.BackgroundPreserveAspect; }
            set { VerticalScrollbar.BackgroundPreserveAspect = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBackgroundFillCenterProperty = Scrollbar.BackgroundFillCenterProperty;
        public System.Boolean VerticalScrollbarBackgroundFillCenter
        {
            get { return VerticalScrollbar.BackgroundFillCenter; }
            set { VerticalScrollbar.BackgroundFillCenter = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBackgroundFillMethodProperty = Scrollbar.BackgroundFillMethodProperty;
        public UnityEngine.UI.Image.FillMethod VerticalScrollbarBackgroundFillMethod
        {
            get { return VerticalScrollbar.BackgroundFillMethod; }
            set { VerticalScrollbar.BackgroundFillMethod = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBackgroundFillAmountProperty = Scrollbar.BackgroundFillAmountProperty;
        public System.Single VerticalScrollbarBackgroundFillAmount
        {
            get { return VerticalScrollbar.BackgroundFillAmount; }
            set { VerticalScrollbar.BackgroundFillAmount = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBackgroundFillClockwiseProperty = Scrollbar.BackgroundFillClockwiseProperty;
        public System.Boolean VerticalScrollbarBackgroundFillClockwise
        {
            get { return VerticalScrollbar.BackgroundFillClockwise; }
            set { VerticalScrollbar.BackgroundFillClockwise = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBackgroundFillOriginProperty = Scrollbar.BackgroundFillOriginProperty;
        public System.Int32 VerticalScrollbarBackgroundFillOrigin
        {
            get { return VerticalScrollbar.BackgroundFillOrigin; }
            set { VerticalScrollbar.BackgroundFillOrigin = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBackgroundAlphaHitTestMinimumThresholdProperty = Scrollbar.BackgroundAlphaHitTestMinimumThresholdProperty;
        public System.Single VerticalScrollbarBackgroundAlphaHitTestMinimumThreshold
        {
            get { return VerticalScrollbar.BackgroundAlphaHitTestMinimumThreshold; }
            set { VerticalScrollbar.BackgroundAlphaHitTestMinimumThreshold = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBackgroundUseSpriteMeshProperty = Scrollbar.BackgroundUseSpriteMeshProperty;
        public System.Boolean VerticalScrollbarBackgroundUseSpriteMesh
        {
            get { return VerticalScrollbar.BackgroundUseSpriteMesh; }
            set { VerticalScrollbar.BackgroundUseSpriteMesh = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBackgroundMaterialProperty = Scrollbar.BackgroundMaterialProperty;
        public MaterialAsset VerticalScrollbarBackgroundMaterial
        {
            get { return VerticalScrollbar.BackgroundMaterial; }
            set { VerticalScrollbar.BackgroundMaterial = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBackgroundOnCullStateChangedProperty = Scrollbar.BackgroundOnCullStateChangedProperty;
        public UnityEngine.UI.MaskableGraphic.CullStateChangedEvent VerticalScrollbarBackgroundOnCullStateChanged
        {
            get { return VerticalScrollbar.BackgroundOnCullStateChanged; }
            set { VerticalScrollbar.BackgroundOnCullStateChanged = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBackgroundMaskableProperty = Scrollbar.BackgroundMaskableProperty;
        public System.Boolean VerticalScrollbarBackgroundMaskable
        {
            get { return VerticalScrollbar.BackgroundMaskable; }
            set { VerticalScrollbar.BackgroundMaskable = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBackgroundColorProperty = Scrollbar.BackgroundColorProperty;
        public UnityEngine.Color VerticalScrollbarBackgroundColor
        {
            get { return VerticalScrollbar.BackgroundColor; }
            set { VerticalScrollbar.BackgroundColor = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBackgroundRaycastTargetProperty = Scrollbar.BackgroundRaycastTargetProperty;
        public System.Boolean VerticalScrollbarBackgroundRaycastTarget
        {
            get { return VerticalScrollbar.BackgroundRaycastTarget; }
            set { VerticalScrollbar.BackgroundRaycastTarget = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarWidthProperty = Scrollbar.WidthProperty;
        public Delight.ElementSize VerticalScrollbarWidth
        {
            get { return VerticalScrollbar.Width; }
            set { VerticalScrollbar.Width = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHeightProperty = Scrollbar.HeightProperty;
        public Delight.ElementSize VerticalScrollbarHeight
        {
            get { return VerticalScrollbar.Height; }
            set { VerticalScrollbar.Height = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarOverrideWidthProperty = Scrollbar.OverrideWidthProperty;
        public Delight.ElementSize VerticalScrollbarOverrideWidth
        {
            get { return VerticalScrollbar.OverrideWidth; }
            set { VerticalScrollbar.OverrideWidth = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarOverrideHeightProperty = Scrollbar.OverrideHeightProperty;
        public Delight.ElementSize VerticalScrollbarOverrideHeight
        {
            get { return VerticalScrollbar.OverrideHeight; }
            set { VerticalScrollbar.OverrideHeight = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarScaleProperty = Scrollbar.ScaleProperty;
        public UnityEngine.Vector3 VerticalScrollbarScale
        {
            get { return VerticalScrollbar.Scale; }
            set { VerticalScrollbar.Scale = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarAlignmentProperty = Scrollbar.AlignmentProperty;
        public Delight.ElementAlignment VerticalScrollbarAlignment
        {
            get { return VerticalScrollbar.Alignment; }
            set { VerticalScrollbar.Alignment = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarMarginProperty = Scrollbar.MarginProperty;
        public Delight.ElementMargin VerticalScrollbarMargin
        {
            get { return VerticalScrollbar.Margin; }
            set { VerticalScrollbar.Margin = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarOffsetProperty = Scrollbar.OffsetProperty;
        public Delight.ElementMargin VerticalScrollbarOffset
        {
            get { return VerticalScrollbar.Offset; }
            set { VerticalScrollbar.Offset = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarOffsetFromParentProperty = Scrollbar.OffsetFromParentProperty;
        public Delight.ElementMargin VerticalScrollbarOffsetFromParent
        {
            get { return VerticalScrollbar.OffsetFromParent; }
            set { VerticalScrollbar.OffsetFromParent = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarPivotProperty = Scrollbar.PivotProperty;
        public UnityEngine.Vector2 VerticalScrollbarPivot
        {
            get { return VerticalScrollbar.Pivot; }
            set { VerticalScrollbar.Pivot = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarLayoutRootProperty = Scrollbar.LayoutRootProperty;
        public Delight.LayoutRoot VerticalScrollbarLayoutRoot
        {
            get { return VerticalScrollbar.LayoutRoot; }
            set { VerticalScrollbar.LayoutRoot = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarDisableLayoutUpdateProperty = Scrollbar.DisableLayoutUpdateProperty;
        public System.Boolean VerticalScrollbarDisableLayoutUpdate
        {
            get { return VerticalScrollbar.DisableLayoutUpdate; }
            set { VerticalScrollbar.DisableLayoutUpdate = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarAlphaProperty = Scrollbar.AlphaProperty;
        public System.Single VerticalScrollbarAlpha
        {
            get { return VerticalScrollbar.Alpha; }
            set { VerticalScrollbar.Alpha = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarIsVisibleProperty = Scrollbar.IsVisibleProperty;
        public System.Boolean VerticalScrollbarIsVisible
        {
            get { return VerticalScrollbar.IsVisible; }
            set { VerticalScrollbar.IsVisible = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarRaycastBlockModeProperty = Scrollbar.RaycastBlockModeProperty;
        public Delight.RaycastBlockMode VerticalScrollbarRaycastBlockMode
        {
            get { return VerticalScrollbar.RaycastBlockMode; }
            set { VerticalScrollbar.RaycastBlockMode = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarUseFastShaderProperty = Scrollbar.UseFastShaderProperty;
        public System.Boolean VerticalScrollbarUseFastShader
        {
            get { return VerticalScrollbar.UseFastShader; }
            set { VerticalScrollbar.UseFastShader = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBubbleNotifyChildLayoutChangedProperty = Scrollbar.BubbleNotifyChildLayoutChangedProperty;
        public System.Boolean VerticalScrollbarBubbleNotifyChildLayoutChanged
        {
            get { return VerticalScrollbar.BubbleNotifyChildLayoutChanged; }
            set { VerticalScrollbar.BubbleNotifyChildLayoutChanged = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarIgnoreFlipProperty = Scrollbar.IgnoreFlipProperty;
        public System.Boolean VerticalScrollbarIgnoreFlip
        {
            get { return VerticalScrollbar.IgnoreFlip; }
            set { VerticalScrollbar.IgnoreFlip = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarGameObjectProperty = Scrollbar.GameObjectProperty;
        public UnityEngine.GameObject VerticalScrollbarGameObject
        {
            get { return VerticalScrollbar.GameObject; }
            set { VerticalScrollbar.GameObject = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarEnableScriptEventsProperty = Scrollbar.EnableScriptEventsProperty;
        public System.Boolean VerticalScrollbarEnableScriptEvents
        {
            get { return VerticalScrollbar.EnableScriptEvents; }
            set { VerticalScrollbar.EnableScriptEvents = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarIgnoreObjectProperty = Scrollbar.IgnoreObjectProperty;
        public System.Boolean VerticalScrollbarIgnoreObject
        {
            get { return VerticalScrollbar.IgnoreObject; }
            set { VerticalScrollbar.IgnoreObject = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarIsActiveProperty = Scrollbar.IsActiveProperty;
        public System.Boolean VerticalScrollbarIsActive
        {
            get { return VerticalScrollbar.IsActive; }
            set { VerticalScrollbar.IsActive = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarLoadModeProperty = Scrollbar.LoadModeProperty;
        public Delight.LoadMode VerticalScrollbarLoadMode
        {
            get { return VerticalScrollbar.LoadMode; }
            set { VerticalScrollbar.LoadMode = value; }
        }

        #endregion
    }

    #region Data Templates

    public static class ScrollableRegionTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return ScrollableRegion;
            }
        }

        private static Template _scrollableRegion;
        public static Template ScrollableRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollableRegion == null || _scrollableRegion.CurrentVersion != Template.Version)
#else
                if (_scrollableRegion == null)
#endif
                {
                    _scrollableRegion = new Template(UICanvasTemplates.UICanvas);
#if UNITY_EDITOR
                    _scrollableRegion.Name = "ScrollableRegion";
#endif
                    Delight.ScrollableRegion.MaskContentProperty.SetDefault(_scrollableRegion, true);
                    Delight.ScrollableRegion.HasInertiaProperty.SetDefault(_scrollableRegion, true);
                    Delight.ScrollableRegion.DecelerationRateProperty.SetDefault(_scrollableRegion, 0.135f);
                    Delight.ScrollableRegion.ElasticityProperty.SetDefault(_scrollableRegion, 0.1f);
                    Delight.ScrollableRegion.CanScrollHorizontallyProperty.SetDefault(_scrollableRegion, true);
                    Delight.ScrollableRegion.CanScrollVerticallyProperty.SetDefault(_scrollableRegion, true);
                    Delight.ScrollableRegion.EnableScriptEventsProperty.SetDefault(_scrollableRegion, true);
                    Delight.ScrollableRegion.AutoSizeContentRegionProperty.SetDefault(_scrollableRegion, true);
                    Delight.ScrollableRegion.ScrollBoundsProperty.SetDefault(_scrollableRegion, Delight.ScrollBounds.Elastic);
                    Delight.ScrollableRegion.ScrollSensitivityProperty.SetDefault(_scrollableRegion, 60f);
                    Delight.ScrollableRegion.HorizontalScrollbarVisibilityProperty.SetDefault(_scrollableRegion, Delight.ScrollbarVisibilityMode.Auto);
                    Delight.ScrollableRegion.VerticalScrollbarVisibilityProperty.SetDefault(_scrollableRegion, Delight.ScrollbarVisibilityMode.Auto);
                    Delight.ScrollableRegion.ScrollEnabledProperty.SetDefault(_scrollableRegion, true);
                    Delight.ScrollableRegion.ContentRegionTemplateProperty.SetDefault(_scrollableRegion, ScrollableRegionContentRegion);
                    Delight.ScrollableRegion.HorizontalScrollbarTemplateProperty.SetDefault(_scrollableRegion, ScrollableRegionHorizontalScrollbar);
                    Delight.ScrollableRegion.VerticalScrollbarTemplateProperty.SetDefault(_scrollableRegion, ScrollableRegionVerticalScrollbar);
                }
                return _scrollableRegion;
            }
        }

        private static Template _scrollableRegionContentRegion;
        public static Template ScrollableRegionContentRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollableRegionContentRegion == null || _scrollableRegionContentRegion.CurrentVersion != Template.Version)
#else
                if (_scrollableRegionContentRegion == null)
#endif
                {
                    _scrollableRegionContentRegion = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _scrollableRegionContentRegion.Name = "ScrollableRegionContentRegion";
#endif
                    Delight.Region.BubbleNotifyChildLayoutChangedProperty.SetDefault(_scrollableRegionContentRegion, true);
                    Delight.Region.AlignmentProperty.SetHasBinding(_scrollableRegionContentRegion);
                }
                return _scrollableRegionContentRegion;
            }
        }

        private static Template _scrollableRegionHorizontalScrollbar;
        public static Template ScrollableRegionHorizontalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollableRegionHorizontalScrollbar == null || _scrollableRegionHorizontalScrollbar.CurrentVersion != Template.Version)
#else
                if (_scrollableRegionHorizontalScrollbar == null)
#endif
                {
                    _scrollableRegionHorizontalScrollbar = new Template(ScrollbarTemplates.Scrollbar);
#if UNITY_EDITOR
                    _scrollableRegionHorizontalScrollbar.Name = "ScrollableRegionHorizontalScrollbar";
#endif
                    Delight.Scrollbar.OrientationProperty.SetDefault(_scrollableRegionHorizontalScrollbar, Delight.ElementOrientation.Horizontal);
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_scrollableRegionHorizontalScrollbar, ScrollableRegionHorizontalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_scrollableRegionHorizontalScrollbar, ScrollableRegionHorizontalScrollbarHandle);
                }
                return _scrollableRegionHorizontalScrollbar;
            }
        }

        private static Template _scrollableRegionHorizontalScrollbarBar;
        public static Template ScrollableRegionHorizontalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollableRegionHorizontalScrollbarBar == null || _scrollableRegionHorizontalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_scrollableRegionHorizontalScrollbarBar == null)
#endif
                {
                    _scrollableRegionHorizontalScrollbarBar = new Template(ScrollbarTemplates.ScrollbarBar);
#if UNITY_EDITOR
                    _scrollableRegionHorizontalScrollbarBar.Name = "ScrollableRegionHorizontalScrollbarBar";
#endif
                }
                return _scrollableRegionHorizontalScrollbarBar;
            }
        }

        private static Template _scrollableRegionHorizontalScrollbarHandle;
        public static Template ScrollableRegionHorizontalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollableRegionHorizontalScrollbarHandle == null || _scrollableRegionHorizontalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_scrollableRegionHorizontalScrollbarHandle == null)
#endif
                {
                    _scrollableRegionHorizontalScrollbarHandle = new Template(ScrollbarTemplates.ScrollbarHandle);
#if UNITY_EDITOR
                    _scrollableRegionHorizontalScrollbarHandle.Name = "ScrollableRegionHorizontalScrollbarHandle";
#endif
                }
                return _scrollableRegionHorizontalScrollbarHandle;
            }
        }

        private static Template _scrollableRegionVerticalScrollbar;
        public static Template ScrollableRegionVerticalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollableRegionVerticalScrollbar == null || _scrollableRegionVerticalScrollbar.CurrentVersion != Template.Version)
#else
                if (_scrollableRegionVerticalScrollbar == null)
#endif
                {
                    _scrollableRegionVerticalScrollbar = new Template(ScrollbarTemplates.Scrollbar);
#if UNITY_EDITOR
                    _scrollableRegionVerticalScrollbar.Name = "ScrollableRegionVerticalScrollbar";
#endif
                    Delight.Scrollbar.OrientationProperty.SetDefault(_scrollableRegionVerticalScrollbar, Delight.ElementOrientation.Vertical);
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_scrollableRegionVerticalScrollbar, ScrollableRegionVerticalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_scrollableRegionVerticalScrollbar, ScrollableRegionVerticalScrollbarHandle);
                }
                return _scrollableRegionVerticalScrollbar;
            }
        }

        private static Template _scrollableRegionVerticalScrollbarBar;
        public static Template ScrollableRegionVerticalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollableRegionVerticalScrollbarBar == null || _scrollableRegionVerticalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_scrollableRegionVerticalScrollbarBar == null)
#endif
                {
                    _scrollableRegionVerticalScrollbarBar = new Template(ScrollbarTemplates.ScrollbarBar);
#if UNITY_EDITOR
                    _scrollableRegionVerticalScrollbarBar.Name = "ScrollableRegionVerticalScrollbarBar";
#endif
                }
                return _scrollableRegionVerticalScrollbarBar;
            }
        }

        private static Template _scrollableRegionVerticalScrollbarHandle;
        public static Template ScrollableRegionVerticalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollableRegionVerticalScrollbarHandle == null || _scrollableRegionVerticalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_scrollableRegionVerticalScrollbarHandle == null)
#endif
                {
                    _scrollableRegionVerticalScrollbarHandle = new Template(ScrollbarTemplates.ScrollbarHandle);
#if UNITY_EDITOR
                    _scrollableRegionVerticalScrollbarHandle.Name = "ScrollableRegionVerticalScrollbarHandle";
#endif
                }
                return _scrollableRegionVerticalScrollbarHandle;
            }
        }

        #endregion
    }

    #endregion
}
