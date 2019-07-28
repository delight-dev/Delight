// Internal view logic generated from "List.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class List : Collection
    {
        #region Constructors

        public List(View parent, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :
            base(parent, layoutParent, id, template ?? ListTemplates.Default, initializer)
        {
            // constructing ScrollableRegion (ScrollableRegion)
            ScrollableRegion = new ScrollableRegion(this, this, "ScrollableRegion", ScrollableRegionTemplate);
            ContentContainer = ScrollableRegion;
            this.AfterInitializeInternal();
        }

        public List() : this(null)
        {
        }

        static List()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(ListTemplates.Default, dependencyProperties);

            dependencyProperties.Add(OrientationProperty);
            dependencyProperties.Add(SpacingProperty);
            dependencyProperties.Add(HorizontalSpacingProperty);
            dependencyProperties.Add(VerticalSpacingProperty);
            dependencyProperties.Add(PaddingProperty);
            dependencyProperties.Add(ContentAlignmentProperty);
            dependencyProperties.Add(AlternateItemsProperty);
            dependencyProperties.Add(IsScrollableProperty);
            dependencyProperties.Add(IsVirtualizedProperty);
            dependencyProperties.Add(OverflowProperty);
            dependencyProperties.Add(SortDirectionProperty);
            dependencyProperties.Add(ItemSelectedProperty);
            dependencyProperties.Add(ItemDeselectedProperty);
            dependencyProperties.Add(CanSelectProperty);
            dependencyProperties.Add(CanDeselectProperty);
            dependencyProperties.Add(CanMultiSelectProperty);
            dependencyProperties.Add(CanReselectProperty);
            dependencyProperties.Add(DeselectAfterSelectProperty);
            dependencyProperties.Add(SelectOnMouseUpProperty);
            dependencyProperties.Add(SelectedItemProperty);
            dependencyProperties.Add(IsStaticProperty);
            dependencyProperties.Add(VirtualItemGetterProperty);
            dependencyProperties.Add(RealizationMarginProperty);
            dependencyProperties.Add(ScrollableRegionProperty);
            dependencyProperties.Add(ScrollableRegionTemplateProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<Delight.ElementOrientation> OrientationProperty = new DependencyProperty<Delight.ElementOrientation>("Orientation");
        public Delight.ElementOrientation Orientation
        {
            get { return OrientationProperty.GetValue(this); }
            set { OrientationProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Delight.ElementSize> SpacingProperty = new DependencyProperty<Delight.ElementSize>("Spacing");
        public Delight.ElementSize Spacing
        {
            get { return SpacingProperty.GetValue(this); }
            set { SpacingProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Delight.ElementSize> HorizontalSpacingProperty = new DependencyProperty<Delight.ElementSize>("HorizontalSpacing");
        public Delight.ElementSize HorizontalSpacing
        {
            get { return HorizontalSpacingProperty.GetValue(this); }
            set { HorizontalSpacingProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Delight.ElementSize> VerticalSpacingProperty = new DependencyProperty<Delight.ElementSize>("VerticalSpacing");
        public Delight.ElementSize VerticalSpacing
        {
            get { return VerticalSpacingProperty.GetValue(this); }
            set { VerticalSpacingProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Delight.ElementMargin> PaddingProperty = new DependencyProperty<Delight.ElementMargin>("Padding");
        public Delight.ElementMargin Padding
        {
            get { return PaddingProperty.GetValue(this); }
            set { PaddingProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Delight.ElementAlignment> ContentAlignmentProperty = new DependencyProperty<Delight.ElementAlignment>("ContentAlignment");
        public Delight.ElementAlignment ContentAlignment
        {
            get { return ContentAlignmentProperty.GetValue(this); }
            set { ContentAlignmentProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> AlternateItemsProperty = new DependencyProperty<System.Boolean>("AlternateItems");
        public System.Boolean AlternateItems
        {
            get { return AlternateItemsProperty.GetValue(this); }
            set { AlternateItemsProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> IsScrollableProperty = new DependencyProperty<System.Boolean>("IsScrollable");
        public System.Boolean IsScrollable
        {
            get { return IsScrollableProperty.GetValue(this); }
            set { IsScrollableProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> IsVirtualizedProperty = new DependencyProperty<System.Boolean>("IsVirtualized");
        public System.Boolean IsVirtualized
        {
            get { return IsVirtualizedProperty.GetValue(this); }
            set { IsVirtualizedProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Delight.OverflowMode> OverflowProperty = new DependencyProperty<Delight.OverflowMode>("Overflow");
        public Delight.OverflowMode Overflow
        {
            get { return OverflowProperty.GetValue(this); }
            set { OverflowProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Delight.ElementSortDirection> SortDirectionProperty = new DependencyProperty<Delight.ElementSortDirection>("SortDirection");
        public Delight.ElementSortDirection SortDirection
        {
            get { return SortDirectionProperty.GetValue(this); }
            set { SortDirectionProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ViewAction> ItemSelectedProperty = new DependencyProperty<ViewAction>("ItemSelected", () => new ViewAction());
        public ViewAction ItemSelected
        {
            get { return ItemSelectedProperty.GetValue(this); }
            set { ItemSelectedProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ViewAction> ItemDeselectedProperty = new DependencyProperty<ViewAction>("ItemDeselected", () => new ViewAction());
        public ViewAction ItemDeselected
        {
            get { return ItemDeselectedProperty.GetValue(this); }
            set { ItemDeselectedProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> CanSelectProperty = new DependencyProperty<System.Boolean>("CanSelect");
        public System.Boolean CanSelect
        {
            get { return CanSelectProperty.GetValue(this); }
            set { CanSelectProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> CanDeselectProperty = new DependencyProperty<System.Boolean>("CanDeselect");
        public System.Boolean CanDeselect
        {
            get { return CanDeselectProperty.GetValue(this); }
            set { CanDeselectProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> CanMultiSelectProperty = new DependencyProperty<System.Boolean>("CanMultiSelect");
        public System.Boolean CanMultiSelect
        {
            get { return CanMultiSelectProperty.GetValue(this); }
            set { CanMultiSelectProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> CanReselectProperty = new DependencyProperty<System.Boolean>("CanReselect");
        public System.Boolean CanReselect
        {
            get { return CanReselectProperty.GetValue(this); }
            set { CanReselectProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> DeselectAfterSelectProperty = new DependencyProperty<System.Boolean>("DeselectAfterSelect");
        public System.Boolean DeselectAfterSelect
        {
            get { return DeselectAfterSelectProperty.GetValue(this); }
            set { DeselectAfterSelectProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> SelectOnMouseUpProperty = new DependencyProperty<System.Boolean>("SelectOnMouseUp");
        public System.Boolean SelectOnMouseUp
        {
            get { return SelectOnMouseUpProperty.GetValue(this); }
            set { SelectOnMouseUpProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Delight.BindableObject> SelectedItemProperty = new DependencyProperty<Delight.BindableObject>("SelectedItem");
        public Delight.BindableObject SelectedItem
        {
            get { return SelectedItemProperty.GetValue(this); }
            set { SelectedItemProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> IsStaticProperty = new DependencyProperty<System.Boolean>("IsStatic");
        public System.Boolean IsStatic
        {
            get { return IsStaticProperty.GetValue(this); }
            set { IsStaticProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ViewMethod> VirtualItemGetterProperty = new DependencyProperty<ViewMethod>("VirtualItemGetter", () => new ViewMethod());
        public ViewMethod VirtualItemGetter
        {
            get { return VirtualItemGetterProperty.GetValue(this); }
            set { VirtualItemGetterProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<UnityEngine.Vector2> RealizationMarginProperty = new DependencyProperty<UnityEngine.Vector2>("RealizationMargin");
        public UnityEngine.Vector2 RealizationMargin
        {
            get { return RealizationMarginProperty.GetValue(this); }
            set { RealizationMarginProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ScrollableRegion> ScrollableRegionProperty = new DependencyProperty<ScrollableRegion>("ScrollableRegion");
        public ScrollableRegion ScrollableRegion
        {
            get { return ScrollableRegionProperty.GetValue(this); }
            set { ScrollableRegionProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> ScrollableRegionTemplateProperty = new DependencyProperty<Template>("ScrollableRegionTemplate");
        public Template ScrollableRegionTemplate
        {
            get { return ScrollableRegionTemplateProperty.GetValue(this); }
            set { ScrollableRegionTemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty MaskContentProperty = ScrollableRegion.MaskContentProperty;
        public System.Boolean MaskContent
        {
            get { return ScrollableRegion.MaskContent; }
            set { ScrollableRegion.MaskContent = value; }
        }

        public readonly static DependencyProperty HasInertiaProperty = ScrollableRegion.HasInertiaProperty;
        public System.Boolean HasInertia
        {
            get { return ScrollableRegion.HasInertia; }
            set { ScrollableRegion.HasInertia = value; }
        }

        public readonly static DependencyProperty DecelerationRateProperty = ScrollableRegion.DecelerationRateProperty;
        public System.Single DecelerationRate
        {
            get { return ScrollableRegion.DecelerationRate; }
            set { ScrollableRegion.DecelerationRate = value; }
        }

        public readonly static DependencyProperty ElasticityProperty = ScrollableRegion.ElasticityProperty;
        public System.Single Elasticity
        {
            get { return ScrollableRegion.Elasticity; }
            set { ScrollableRegion.Elasticity = value; }
        }

        public readonly static DependencyProperty CanScrollHorizontallyProperty = ScrollableRegion.CanScrollHorizontallyProperty;
        public System.Boolean CanScrollHorizontally
        {
            get { return ScrollableRegion.CanScrollHorizontally; }
            set { ScrollableRegion.CanScrollHorizontally = value; }
        }

        public readonly static DependencyProperty CanScrollVerticallyProperty = ScrollableRegion.CanScrollVerticallyProperty;
        public System.Boolean CanScrollVertically
        {
            get { return ScrollableRegion.CanScrollVertically; }
            set { ScrollableRegion.CanScrollVertically = value; }
        }

        public readonly static DependencyProperty ScrollableRegionContentAlignmentProperty = ScrollableRegion.ContentAlignmentProperty;
        public Delight.ElementAlignment ScrollableRegionContentAlignment
        {
            get { return ScrollableRegion.ContentAlignment; }
            set { ScrollableRegion.ContentAlignment = value; }
        }

        public readonly static DependencyProperty AutoSizeContentRegionProperty = ScrollableRegion.AutoSizeContentRegionProperty;
        public System.Boolean AutoSizeContentRegion
        {
            get { return ScrollableRegion.AutoSizeContentRegion; }
            set { ScrollableRegion.AutoSizeContentRegion = value; }
        }

        public readonly static DependencyProperty ScrollBoundsProperty = ScrollableRegion.ScrollBoundsProperty;
        public Delight.ScrollBounds ScrollBounds
        {
            get { return ScrollableRegion.ScrollBounds; }
            set { ScrollableRegion.ScrollBounds = value; }
        }

        public readonly static DependencyProperty DebugOffsetTextProperty = ScrollableRegion.DebugOffsetTextProperty;
        public System.String DebugOffsetText
        {
            get { return ScrollableRegion.DebugOffsetText; }
            set { ScrollableRegion.DebugOffsetText = value; }
        }

        public readonly static DependencyProperty DisableInteractionScrollDeltaProperty = ScrollableRegion.DisableInteractionScrollDeltaProperty;
        public System.Single DisableInteractionScrollDelta
        {
            get { return ScrollableRegion.DisableInteractionScrollDelta; }
            set { ScrollableRegion.DisableInteractionScrollDelta = value; }
        }

        public readonly static DependencyProperty ScrollSensitivityProperty = ScrollableRegion.ScrollSensitivityProperty;
        public System.Single ScrollSensitivity
        {
            get { return ScrollableRegion.ScrollSensitivity; }
            set { ScrollableRegion.ScrollSensitivity = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarVisibilityProperty = ScrollableRegion.HorizontalScrollbarVisibilityProperty;
        public Delight.ScrollbarVisibilityMode HorizontalScrollbarVisibility
        {
            get { return ScrollableRegion.HorizontalScrollbarVisibility; }
            set { ScrollableRegion.HorizontalScrollbarVisibility = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarVisibilityProperty = ScrollableRegion.VerticalScrollbarVisibilityProperty;
        public Delight.ScrollbarVisibilityMode VerticalScrollbarVisibility
        {
            get { return ScrollableRegion.VerticalScrollbarVisibility; }
            set { ScrollableRegion.VerticalScrollbarVisibility = value; }
        }

        public readonly static DependencyProperty DisableMouseWheelProperty = ScrollableRegion.DisableMouseWheelProperty;
        public System.Boolean DisableMouseWheel
        {
            get { return ScrollableRegion.DisableMouseWheel; }
            set { ScrollableRegion.DisableMouseWheel = value; }
        }

        public readonly static DependencyProperty ScrollEnabledProperty = ScrollableRegion.ScrollEnabledProperty;
        public System.Boolean ScrollEnabled
        {
            get { return ScrollableRegion.ScrollEnabled; }
            set { ScrollableRegion.ScrollEnabled = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarLengthProperty = ScrollableRegion.HorizontalScrollbarLengthProperty;
        public Delight.ElementSize HorizontalScrollbarLength
        {
            get { return ScrollableRegion.HorizontalScrollbarLength; }
            set { ScrollableRegion.HorizontalScrollbarLength = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBreadthProperty = ScrollableRegion.HorizontalScrollbarBreadthProperty;
        public Delight.ElementSize HorizontalScrollbarBreadth
        {
            get { return ScrollableRegion.HorizontalScrollbarBreadth; }
            set { ScrollableRegion.HorizontalScrollbarBreadth = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarOrientationProperty = ScrollableRegion.HorizontalScrollbarOrientationProperty;
        public Delight.ElementOrientation HorizontalScrollbarOrientation
        {
            get { return ScrollableRegion.HorizontalScrollbarOrientation; }
            set { ScrollableRegion.HorizontalScrollbarOrientation = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarScrollPositionProperty = ScrollableRegion.HorizontalScrollbarScrollPositionProperty;
        public System.Single HorizontalScrollbarScrollPosition
        {
            get { return ScrollableRegion.HorizontalScrollbarScrollPosition; }
            set { ScrollableRegion.HorizontalScrollbarScrollPosition = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarViewportRatioProperty = ScrollableRegion.HorizontalScrollbarViewportRatioProperty;
        public System.Single HorizontalScrollbarViewportRatio
        {
            get { return ScrollableRegion.HorizontalScrollbarViewportRatio; }
            set { ScrollableRegion.HorizontalScrollbarViewportRatio = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarSpriteProperty = ScrollableRegion.HorizontalScrollbarBarSpriteProperty;
        public SpriteAsset HorizontalScrollbarBarSprite
        {
            get { return ScrollableRegion.HorizontalScrollbarBarSprite; }
            set { ScrollableRegion.HorizontalScrollbarBarSprite = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarOverrideSpriteProperty = ScrollableRegion.HorizontalScrollbarBarOverrideSpriteProperty;
        public SpriteAsset HorizontalScrollbarBarOverrideSprite
        {
            get { return ScrollableRegion.HorizontalScrollbarBarOverrideSprite; }
            set { ScrollableRegion.HorizontalScrollbarBarOverrideSprite = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarTypeProperty = ScrollableRegion.HorizontalScrollbarBarTypeProperty;
        public UnityEngine.UI.Image.Type HorizontalScrollbarBarType
        {
            get { return ScrollableRegion.HorizontalScrollbarBarType; }
            set { ScrollableRegion.HorizontalScrollbarBarType = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarPreserveAspectProperty = ScrollableRegion.HorizontalScrollbarBarPreserveAspectProperty;
        public System.Boolean HorizontalScrollbarBarPreserveAspect
        {
            get { return ScrollableRegion.HorizontalScrollbarBarPreserveAspect; }
            set { ScrollableRegion.HorizontalScrollbarBarPreserveAspect = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarFillCenterProperty = ScrollableRegion.HorizontalScrollbarBarFillCenterProperty;
        public System.Boolean HorizontalScrollbarBarFillCenter
        {
            get { return ScrollableRegion.HorizontalScrollbarBarFillCenter; }
            set { ScrollableRegion.HorizontalScrollbarBarFillCenter = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarFillMethodProperty = ScrollableRegion.HorizontalScrollbarBarFillMethodProperty;
        public UnityEngine.UI.Image.FillMethod HorizontalScrollbarBarFillMethod
        {
            get { return ScrollableRegion.HorizontalScrollbarBarFillMethod; }
            set { ScrollableRegion.HorizontalScrollbarBarFillMethod = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarFillAmountProperty = ScrollableRegion.HorizontalScrollbarBarFillAmountProperty;
        public System.Single HorizontalScrollbarBarFillAmount
        {
            get { return ScrollableRegion.HorizontalScrollbarBarFillAmount; }
            set { ScrollableRegion.HorizontalScrollbarBarFillAmount = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarFillClockwiseProperty = ScrollableRegion.HorizontalScrollbarBarFillClockwiseProperty;
        public System.Boolean HorizontalScrollbarBarFillClockwise
        {
            get { return ScrollableRegion.HorizontalScrollbarBarFillClockwise; }
            set { ScrollableRegion.HorizontalScrollbarBarFillClockwise = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarFillOriginProperty = ScrollableRegion.HorizontalScrollbarBarFillOriginProperty;
        public System.Int32 HorizontalScrollbarBarFillOrigin
        {
            get { return ScrollableRegion.HorizontalScrollbarBarFillOrigin; }
            set { ScrollableRegion.HorizontalScrollbarBarFillOrigin = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarAlphaHitTestMinimumThresholdProperty = ScrollableRegion.HorizontalScrollbarBarAlphaHitTestMinimumThresholdProperty;
        public System.Single HorizontalScrollbarBarAlphaHitTestMinimumThreshold
        {
            get { return ScrollableRegion.HorizontalScrollbarBarAlphaHitTestMinimumThreshold; }
            set { ScrollableRegion.HorizontalScrollbarBarAlphaHitTestMinimumThreshold = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarUseSpriteMeshProperty = ScrollableRegion.HorizontalScrollbarBarUseSpriteMeshProperty;
        public System.Boolean HorizontalScrollbarBarUseSpriteMesh
        {
            get { return ScrollableRegion.HorizontalScrollbarBarUseSpriteMesh; }
            set { ScrollableRegion.HorizontalScrollbarBarUseSpriteMesh = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarMaterialProperty = ScrollableRegion.HorizontalScrollbarBarMaterialProperty;
        public MaterialAsset HorizontalScrollbarBarMaterial
        {
            get { return ScrollableRegion.HorizontalScrollbarBarMaterial; }
            set { ScrollableRegion.HorizontalScrollbarBarMaterial = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarOnCullStateChangedProperty = ScrollableRegion.HorizontalScrollbarBarOnCullStateChangedProperty;
        public UnityEngine.UI.MaskableGraphic.CullStateChangedEvent HorizontalScrollbarBarOnCullStateChanged
        {
            get { return ScrollableRegion.HorizontalScrollbarBarOnCullStateChanged; }
            set { ScrollableRegion.HorizontalScrollbarBarOnCullStateChanged = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarMaskableProperty = ScrollableRegion.HorizontalScrollbarBarMaskableProperty;
        public System.Boolean HorizontalScrollbarBarMaskable
        {
            get { return ScrollableRegion.HorizontalScrollbarBarMaskable; }
            set { ScrollableRegion.HorizontalScrollbarBarMaskable = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarColorProperty = ScrollableRegion.HorizontalScrollbarBarColorProperty;
        public UnityEngine.Color HorizontalScrollbarBarColor
        {
            get { return ScrollableRegion.HorizontalScrollbarBarColor; }
            set { ScrollableRegion.HorizontalScrollbarBarColor = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarRaycastTargetProperty = ScrollableRegion.HorizontalScrollbarBarRaycastTargetProperty;
        public System.Boolean HorizontalScrollbarBarRaycastTarget
        {
            get { return ScrollableRegion.HorizontalScrollbarBarRaycastTarget; }
            set { ScrollableRegion.HorizontalScrollbarBarRaycastTarget = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarWidthProperty = ScrollableRegion.HorizontalScrollbarBarWidthProperty;
        public Delight.ElementSize HorizontalScrollbarBarWidth
        {
            get { return ScrollableRegion.HorizontalScrollbarBarWidth; }
            set { ScrollableRegion.HorizontalScrollbarBarWidth = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarHeightProperty = ScrollableRegion.HorizontalScrollbarBarHeightProperty;
        public Delight.ElementSize HorizontalScrollbarBarHeight
        {
            get { return ScrollableRegion.HorizontalScrollbarBarHeight; }
            set { ScrollableRegion.HorizontalScrollbarBarHeight = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarOverrideWidthProperty = ScrollableRegion.HorizontalScrollbarBarOverrideWidthProperty;
        public Delight.ElementSize HorizontalScrollbarBarOverrideWidth
        {
            get { return ScrollableRegion.HorizontalScrollbarBarOverrideWidth; }
            set { ScrollableRegion.HorizontalScrollbarBarOverrideWidth = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarOverrideHeightProperty = ScrollableRegion.HorizontalScrollbarBarOverrideHeightProperty;
        public Delight.ElementSize HorizontalScrollbarBarOverrideHeight
        {
            get { return ScrollableRegion.HorizontalScrollbarBarOverrideHeight; }
            set { ScrollableRegion.HorizontalScrollbarBarOverrideHeight = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarScaleProperty = ScrollableRegion.HorizontalScrollbarBarScaleProperty;
        public UnityEngine.Vector3 HorizontalScrollbarBarScale
        {
            get { return ScrollableRegion.HorizontalScrollbarBarScale; }
            set { ScrollableRegion.HorizontalScrollbarBarScale = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarAlignmentProperty = ScrollableRegion.HorizontalScrollbarBarAlignmentProperty;
        public Delight.ElementAlignment HorizontalScrollbarBarAlignment
        {
            get { return ScrollableRegion.HorizontalScrollbarBarAlignment; }
            set { ScrollableRegion.HorizontalScrollbarBarAlignment = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarMarginProperty = ScrollableRegion.HorizontalScrollbarBarMarginProperty;
        public Delight.ElementMargin HorizontalScrollbarBarMargin
        {
            get { return ScrollableRegion.HorizontalScrollbarBarMargin; }
            set { ScrollableRegion.HorizontalScrollbarBarMargin = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarOffsetProperty = ScrollableRegion.HorizontalScrollbarBarOffsetProperty;
        public Delight.ElementMargin HorizontalScrollbarBarOffset
        {
            get { return ScrollableRegion.HorizontalScrollbarBarOffset; }
            set { ScrollableRegion.HorizontalScrollbarBarOffset = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarOffsetFromParentProperty = ScrollableRegion.HorizontalScrollbarBarOffsetFromParentProperty;
        public Delight.ElementMargin HorizontalScrollbarBarOffsetFromParent
        {
            get { return ScrollableRegion.HorizontalScrollbarBarOffsetFromParent; }
            set { ScrollableRegion.HorizontalScrollbarBarOffsetFromParent = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarPivotProperty = ScrollableRegion.HorizontalScrollbarBarPivotProperty;
        public UnityEngine.Vector2 HorizontalScrollbarBarPivot
        {
            get { return ScrollableRegion.HorizontalScrollbarBarPivot; }
            set { ScrollableRegion.HorizontalScrollbarBarPivot = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarLayoutRootProperty = ScrollableRegion.HorizontalScrollbarBarLayoutRootProperty;
        public Delight.LayoutRoot HorizontalScrollbarBarLayoutRoot
        {
            get { return ScrollableRegion.HorizontalScrollbarBarLayoutRoot; }
            set { ScrollableRegion.HorizontalScrollbarBarLayoutRoot = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarDisableLayoutUpdateProperty = ScrollableRegion.HorizontalScrollbarBarDisableLayoutUpdateProperty;
        public System.Boolean HorizontalScrollbarBarDisableLayoutUpdate
        {
            get { return ScrollableRegion.HorizontalScrollbarBarDisableLayoutUpdate; }
            set { ScrollableRegion.HorizontalScrollbarBarDisableLayoutUpdate = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarAlphaProperty = ScrollableRegion.HorizontalScrollbarBarAlphaProperty;
        public System.Single HorizontalScrollbarBarAlpha
        {
            get { return ScrollableRegion.HorizontalScrollbarBarAlpha; }
            set { ScrollableRegion.HorizontalScrollbarBarAlpha = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarIsVisibleProperty = ScrollableRegion.HorizontalScrollbarBarIsVisibleProperty;
        public System.Boolean HorizontalScrollbarBarIsVisible
        {
            get { return ScrollableRegion.HorizontalScrollbarBarIsVisible; }
            set { ScrollableRegion.HorizontalScrollbarBarIsVisible = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarRaycastBlockModeProperty = ScrollableRegion.HorizontalScrollbarBarRaycastBlockModeProperty;
        public Delight.RaycastBlockMode HorizontalScrollbarBarRaycastBlockMode
        {
            get { return ScrollableRegion.HorizontalScrollbarBarRaycastBlockMode; }
            set { ScrollableRegion.HorizontalScrollbarBarRaycastBlockMode = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarUseFastShaderProperty = ScrollableRegion.HorizontalScrollbarBarUseFastShaderProperty;
        public System.Boolean HorizontalScrollbarBarUseFastShader
        {
            get { return ScrollableRegion.HorizontalScrollbarBarUseFastShader; }
            set { ScrollableRegion.HorizontalScrollbarBarUseFastShader = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarBubbleNotifyChildLayoutChangedProperty = ScrollableRegion.HorizontalScrollbarBarBubbleNotifyChildLayoutChangedProperty;
        public System.Boolean HorizontalScrollbarBarBubbleNotifyChildLayoutChanged
        {
            get { return ScrollableRegion.HorizontalScrollbarBarBubbleNotifyChildLayoutChanged; }
            set { ScrollableRegion.HorizontalScrollbarBarBubbleNotifyChildLayoutChanged = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarIgnoreFlipProperty = ScrollableRegion.HorizontalScrollbarBarIgnoreFlipProperty;
        public System.Boolean HorizontalScrollbarBarIgnoreFlip
        {
            get { return ScrollableRegion.HorizontalScrollbarBarIgnoreFlip; }
            set { ScrollableRegion.HorizontalScrollbarBarIgnoreFlip = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarGameObjectProperty = ScrollableRegion.HorizontalScrollbarBarGameObjectProperty;
        public UnityEngine.GameObject HorizontalScrollbarBarGameObject
        {
            get { return ScrollableRegion.HorizontalScrollbarBarGameObject; }
            set { ScrollableRegion.HorizontalScrollbarBarGameObject = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarEnableScriptEventsProperty = ScrollableRegion.HorizontalScrollbarBarEnableScriptEventsProperty;
        public System.Boolean HorizontalScrollbarBarEnableScriptEvents
        {
            get { return ScrollableRegion.HorizontalScrollbarBarEnableScriptEvents; }
            set { ScrollableRegion.HorizontalScrollbarBarEnableScriptEvents = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarIgnoreObjectProperty = ScrollableRegion.HorizontalScrollbarBarIgnoreObjectProperty;
        public System.Boolean HorizontalScrollbarBarIgnoreObject
        {
            get { return ScrollableRegion.HorizontalScrollbarBarIgnoreObject; }
            set { ScrollableRegion.HorizontalScrollbarBarIgnoreObject = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarIsActiveProperty = ScrollableRegion.HorizontalScrollbarBarIsActiveProperty;
        public System.Boolean HorizontalScrollbarBarIsActive
        {
            get { return ScrollableRegion.HorizontalScrollbarBarIsActive; }
            set { ScrollableRegion.HorizontalScrollbarBarIsActive = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarLoadModeProperty = ScrollableRegion.HorizontalScrollbarBarLoadModeProperty;
        public Delight.LoadMode HorizontalScrollbarBarLoadMode
        {
            get { return ScrollableRegion.HorizontalScrollbarBarLoadMode; }
            set { ScrollableRegion.HorizontalScrollbarBarLoadMode = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleSpriteProperty = ScrollableRegion.HorizontalScrollbarHandleSpriteProperty;
        public SpriteAsset HorizontalScrollbarHandleSprite
        {
            get { return ScrollableRegion.HorizontalScrollbarHandleSprite; }
            set { ScrollableRegion.HorizontalScrollbarHandleSprite = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleOverrideSpriteProperty = ScrollableRegion.HorizontalScrollbarHandleOverrideSpriteProperty;
        public SpriteAsset HorizontalScrollbarHandleOverrideSprite
        {
            get { return ScrollableRegion.HorizontalScrollbarHandleOverrideSprite; }
            set { ScrollableRegion.HorizontalScrollbarHandleOverrideSprite = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleTypeProperty = ScrollableRegion.HorizontalScrollbarHandleTypeProperty;
        public UnityEngine.UI.Image.Type HorizontalScrollbarHandleType
        {
            get { return ScrollableRegion.HorizontalScrollbarHandleType; }
            set { ScrollableRegion.HorizontalScrollbarHandleType = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandlePreserveAspectProperty = ScrollableRegion.HorizontalScrollbarHandlePreserveAspectProperty;
        public System.Boolean HorizontalScrollbarHandlePreserveAspect
        {
            get { return ScrollableRegion.HorizontalScrollbarHandlePreserveAspect; }
            set { ScrollableRegion.HorizontalScrollbarHandlePreserveAspect = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleFillCenterProperty = ScrollableRegion.HorizontalScrollbarHandleFillCenterProperty;
        public System.Boolean HorizontalScrollbarHandleFillCenter
        {
            get { return ScrollableRegion.HorizontalScrollbarHandleFillCenter; }
            set { ScrollableRegion.HorizontalScrollbarHandleFillCenter = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleFillMethodProperty = ScrollableRegion.HorizontalScrollbarHandleFillMethodProperty;
        public UnityEngine.UI.Image.FillMethod HorizontalScrollbarHandleFillMethod
        {
            get { return ScrollableRegion.HorizontalScrollbarHandleFillMethod; }
            set { ScrollableRegion.HorizontalScrollbarHandleFillMethod = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleFillAmountProperty = ScrollableRegion.HorizontalScrollbarHandleFillAmountProperty;
        public System.Single HorizontalScrollbarHandleFillAmount
        {
            get { return ScrollableRegion.HorizontalScrollbarHandleFillAmount; }
            set { ScrollableRegion.HorizontalScrollbarHandleFillAmount = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleFillClockwiseProperty = ScrollableRegion.HorizontalScrollbarHandleFillClockwiseProperty;
        public System.Boolean HorizontalScrollbarHandleFillClockwise
        {
            get { return ScrollableRegion.HorizontalScrollbarHandleFillClockwise; }
            set { ScrollableRegion.HorizontalScrollbarHandleFillClockwise = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleFillOriginProperty = ScrollableRegion.HorizontalScrollbarHandleFillOriginProperty;
        public System.Int32 HorizontalScrollbarHandleFillOrigin
        {
            get { return ScrollableRegion.HorizontalScrollbarHandleFillOrigin; }
            set { ScrollableRegion.HorizontalScrollbarHandleFillOrigin = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleAlphaHitTestMinimumThresholdProperty = ScrollableRegion.HorizontalScrollbarHandleAlphaHitTestMinimumThresholdProperty;
        public System.Single HorizontalScrollbarHandleAlphaHitTestMinimumThreshold
        {
            get { return ScrollableRegion.HorizontalScrollbarHandleAlphaHitTestMinimumThreshold; }
            set { ScrollableRegion.HorizontalScrollbarHandleAlphaHitTestMinimumThreshold = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleUseSpriteMeshProperty = ScrollableRegion.HorizontalScrollbarHandleUseSpriteMeshProperty;
        public System.Boolean HorizontalScrollbarHandleUseSpriteMesh
        {
            get { return ScrollableRegion.HorizontalScrollbarHandleUseSpriteMesh; }
            set { ScrollableRegion.HorizontalScrollbarHandleUseSpriteMesh = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleMaterialProperty = ScrollableRegion.HorizontalScrollbarHandleMaterialProperty;
        public MaterialAsset HorizontalScrollbarHandleMaterial
        {
            get { return ScrollableRegion.HorizontalScrollbarHandleMaterial; }
            set { ScrollableRegion.HorizontalScrollbarHandleMaterial = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleOnCullStateChangedProperty = ScrollableRegion.HorizontalScrollbarHandleOnCullStateChangedProperty;
        public UnityEngine.UI.MaskableGraphic.CullStateChangedEvent HorizontalScrollbarHandleOnCullStateChanged
        {
            get { return ScrollableRegion.HorizontalScrollbarHandleOnCullStateChanged; }
            set { ScrollableRegion.HorizontalScrollbarHandleOnCullStateChanged = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleMaskableProperty = ScrollableRegion.HorizontalScrollbarHandleMaskableProperty;
        public System.Boolean HorizontalScrollbarHandleMaskable
        {
            get { return ScrollableRegion.HorizontalScrollbarHandleMaskable; }
            set { ScrollableRegion.HorizontalScrollbarHandleMaskable = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleColorProperty = ScrollableRegion.HorizontalScrollbarHandleColorProperty;
        public UnityEngine.Color HorizontalScrollbarHandleColor
        {
            get { return ScrollableRegion.HorizontalScrollbarHandleColor; }
            set { ScrollableRegion.HorizontalScrollbarHandleColor = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleRaycastTargetProperty = ScrollableRegion.HorizontalScrollbarHandleRaycastTargetProperty;
        public System.Boolean HorizontalScrollbarHandleRaycastTarget
        {
            get { return ScrollableRegion.HorizontalScrollbarHandleRaycastTarget; }
            set { ScrollableRegion.HorizontalScrollbarHandleRaycastTarget = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleWidthProperty = ScrollableRegion.HorizontalScrollbarHandleWidthProperty;
        public Delight.ElementSize HorizontalScrollbarHandleWidth
        {
            get { return ScrollableRegion.HorizontalScrollbarHandleWidth; }
            set { ScrollableRegion.HorizontalScrollbarHandleWidth = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleHeightProperty = ScrollableRegion.HorizontalScrollbarHandleHeightProperty;
        public Delight.ElementSize HorizontalScrollbarHandleHeight
        {
            get { return ScrollableRegion.HorizontalScrollbarHandleHeight; }
            set { ScrollableRegion.HorizontalScrollbarHandleHeight = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleOverrideWidthProperty = ScrollableRegion.HorizontalScrollbarHandleOverrideWidthProperty;
        public Delight.ElementSize HorizontalScrollbarHandleOverrideWidth
        {
            get { return ScrollableRegion.HorizontalScrollbarHandleOverrideWidth; }
            set { ScrollableRegion.HorizontalScrollbarHandleOverrideWidth = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleOverrideHeightProperty = ScrollableRegion.HorizontalScrollbarHandleOverrideHeightProperty;
        public Delight.ElementSize HorizontalScrollbarHandleOverrideHeight
        {
            get { return ScrollableRegion.HorizontalScrollbarHandleOverrideHeight; }
            set { ScrollableRegion.HorizontalScrollbarHandleOverrideHeight = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleScaleProperty = ScrollableRegion.HorizontalScrollbarHandleScaleProperty;
        public UnityEngine.Vector3 HorizontalScrollbarHandleScale
        {
            get { return ScrollableRegion.HorizontalScrollbarHandleScale; }
            set { ScrollableRegion.HorizontalScrollbarHandleScale = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleAlignmentProperty = ScrollableRegion.HorizontalScrollbarHandleAlignmentProperty;
        public Delight.ElementAlignment HorizontalScrollbarHandleAlignment
        {
            get { return ScrollableRegion.HorizontalScrollbarHandleAlignment; }
            set { ScrollableRegion.HorizontalScrollbarHandleAlignment = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleMarginProperty = ScrollableRegion.HorizontalScrollbarHandleMarginProperty;
        public Delight.ElementMargin HorizontalScrollbarHandleMargin
        {
            get { return ScrollableRegion.HorizontalScrollbarHandleMargin; }
            set { ScrollableRegion.HorizontalScrollbarHandleMargin = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleOffsetProperty = ScrollableRegion.HorizontalScrollbarHandleOffsetProperty;
        public Delight.ElementMargin HorizontalScrollbarHandleOffset
        {
            get { return ScrollableRegion.HorizontalScrollbarHandleOffset; }
            set { ScrollableRegion.HorizontalScrollbarHandleOffset = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleOffsetFromParentProperty = ScrollableRegion.HorizontalScrollbarHandleOffsetFromParentProperty;
        public Delight.ElementMargin HorizontalScrollbarHandleOffsetFromParent
        {
            get { return ScrollableRegion.HorizontalScrollbarHandleOffsetFromParent; }
            set { ScrollableRegion.HorizontalScrollbarHandleOffsetFromParent = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandlePivotProperty = ScrollableRegion.HorizontalScrollbarHandlePivotProperty;
        public UnityEngine.Vector2 HorizontalScrollbarHandlePivot
        {
            get { return ScrollableRegion.HorizontalScrollbarHandlePivot; }
            set { ScrollableRegion.HorizontalScrollbarHandlePivot = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleLayoutRootProperty = ScrollableRegion.HorizontalScrollbarHandleLayoutRootProperty;
        public Delight.LayoutRoot HorizontalScrollbarHandleLayoutRoot
        {
            get { return ScrollableRegion.HorizontalScrollbarHandleLayoutRoot; }
            set { ScrollableRegion.HorizontalScrollbarHandleLayoutRoot = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleDisableLayoutUpdateProperty = ScrollableRegion.HorizontalScrollbarHandleDisableLayoutUpdateProperty;
        public System.Boolean HorizontalScrollbarHandleDisableLayoutUpdate
        {
            get { return ScrollableRegion.HorizontalScrollbarHandleDisableLayoutUpdate; }
            set { ScrollableRegion.HorizontalScrollbarHandleDisableLayoutUpdate = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleAlphaProperty = ScrollableRegion.HorizontalScrollbarHandleAlphaProperty;
        public System.Single HorizontalScrollbarHandleAlpha
        {
            get { return ScrollableRegion.HorizontalScrollbarHandleAlpha; }
            set { ScrollableRegion.HorizontalScrollbarHandleAlpha = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleIsVisibleProperty = ScrollableRegion.HorizontalScrollbarHandleIsVisibleProperty;
        public System.Boolean HorizontalScrollbarHandleIsVisible
        {
            get { return ScrollableRegion.HorizontalScrollbarHandleIsVisible; }
            set { ScrollableRegion.HorizontalScrollbarHandleIsVisible = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleRaycastBlockModeProperty = ScrollableRegion.HorizontalScrollbarHandleRaycastBlockModeProperty;
        public Delight.RaycastBlockMode HorizontalScrollbarHandleRaycastBlockMode
        {
            get { return ScrollableRegion.HorizontalScrollbarHandleRaycastBlockMode; }
            set { ScrollableRegion.HorizontalScrollbarHandleRaycastBlockMode = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleUseFastShaderProperty = ScrollableRegion.HorizontalScrollbarHandleUseFastShaderProperty;
        public System.Boolean HorizontalScrollbarHandleUseFastShader
        {
            get { return ScrollableRegion.HorizontalScrollbarHandleUseFastShader; }
            set { ScrollableRegion.HorizontalScrollbarHandleUseFastShader = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleBubbleNotifyChildLayoutChangedProperty = ScrollableRegion.HorizontalScrollbarHandleBubbleNotifyChildLayoutChangedProperty;
        public System.Boolean HorizontalScrollbarHandleBubbleNotifyChildLayoutChanged
        {
            get { return ScrollableRegion.HorizontalScrollbarHandleBubbleNotifyChildLayoutChanged; }
            set { ScrollableRegion.HorizontalScrollbarHandleBubbleNotifyChildLayoutChanged = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleIgnoreFlipProperty = ScrollableRegion.HorizontalScrollbarHandleIgnoreFlipProperty;
        public System.Boolean HorizontalScrollbarHandleIgnoreFlip
        {
            get { return ScrollableRegion.HorizontalScrollbarHandleIgnoreFlip; }
            set { ScrollableRegion.HorizontalScrollbarHandleIgnoreFlip = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleGameObjectProperty = ScrollableRegion.HorizontalScrollbarHandleGameObjectProperty;
        public UnityEngine.GameObject HorizontalScrollbarHandleGameObject
        {
            get { return ScrollableRegion.HorizontalScrollbarHandleGameObject; }
            set { ScrollableRegion.HorizontalScrollbarHandleGameObject = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleEnableScriptEventsProperty = ScrollableRegion.HorizontalScrollbarHandleEnableScriptEventsProperty;
        public System.Boolean HorizontalScrollbarHandleEnableScriptEvents
        {
            get { return ScrollableRegion.HorizontalScrollbarHandleEnableScriptEvents; }
            set { ScrollableRegion.HorizontalScrollbarHandleEnableScriptEvents = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleIgnoreObjectProperty = ScrollableRegion.HorizontalScrollbarHandleIgnoreObjectProperty;
        public System.Boolean HorizontalScrollbarHandleIgnoreObject
        {
            get { return ScrollableRegion.HorizontalScrollbarHandleIgnoreObject; }
            set { ScrollableRegion.HorizontalScrollbarHandleIgnoreObject = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleIsActiveProperty = ScrollableRegion.HorizontalScrollbarHandleIsActiveProperty;
        public System.Boolean HorizontalScrollbarHandleIsActive
        {
            get { return ScrollableRegion.HorizontalScrollbarHandleIsActive; }
            set { ScrollableRegion.HorizontalScrollbarHandleIsActive = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleLoadModeProperty = ScrollableRegion.HorizontalScrollbarHandleLoadModeProperty;
        public Delight.LoadMode HorizontalScrollbarHandleLoadMode
        {
            get { return ScrollableRegion.HorizontalScrollbarHandleLoadMode; }
            set { ScrollableRegion.HorizontalScrollbarHandleLoadMode = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBackgroundSpriteProperty = ScrollableRegion.HorizontalScrollbarBackgroundSpriteProperty;
        public SpriteAsset HorizontalScrollbarBackgroundSprite
        {
            get { return ScrollableRegion.HorizontalScrollbarBackgroundSprite; }
            set { ScrollableRegion.HorizontalScrollbarBackgroundSprite = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBackgroundOverrideSpriteProperty = ScrollableRegion.HorizontalScrollbarBackgroundOverrideSpriteProperty;
        public SpriteAsset HorizontalScrollbarBackgroundOverrideSprite
        {
            get { return ScrollableRegion.HorizontalScrollbarBackgroundOverrideSprite; }
            set { ScrollableRegion.HorizontalScrollbarBackgroundOverrideSprite = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBackgroundTypeProperty = ScrollableRegion.HorizontalScrollbarBackgroundTypeProperty;
        public UnityEngine.UI.Image.Type HorizontalScrollbarBackgroundType
        {
            get { return ScrollableRegion.HorizontalScrollbarBackgroundType; }
            set { ScrollableRegion.HorizontalScrollbarBackgroundType = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBackgroundPreserveAspectProperty = ScrollableRegion.HorizontalScrollbarBackgroundPreserveAspectProperty;
        public System.Boolean HorizontalScrollbarBackgroundPreserveAspect
        {
            get { return ScrollableRegion.HorizontalScrollbarBackgroundPreserveAspect; }
            set { ScrollableRegion.HorizontalScrollbarBackgroundPreserveAspect = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBackgroundFillCenterProperty = ScrollableRegion.HorizontalScrollbarBackgroundFillCenterProperty;
        public System.Boolean HorizontalScrollbarBackgroundFillCenter
        {
            get { return ScrollableRegion.HorizontalScrollbarBackgroundFillCenter; }
            set { ScrollableRegion.HorizontalScrollbarBackgroundFillCenter = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBackgroundFillMethodProperty = ScrollableRegion.HorizontalScrollbarBackgroundFillMethodProperty;
        public UnityEngine.UI.Image.FillMethod HorizontalScrollbarBackgroundFillMethod
        {
            get { return ScrollableRegion.HorizontalScrollbarBackgroundFillMethod; }
            set { ScrollableRegion.HorizontalScrollbarBackgroundFillMethod = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBackgroundFillAmountProperty = ScrollableRegion.HorizontalScrollbarBackgroundFillAmountProperty;
        public System.Single HorizontalScrollbarBackgroundFillAmount
        {
            get { return ScrollableRegion.HorizontalScrollbarBackgroundFillAmount; }
            set { ScrollableRegion.HorizontalScrollbarBackgroundFillAmount = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBackgroundFillClockwiseProperty = ScrollableRegion.HorizontalScrollbarBackgroundFillClockwiseProperty;
        public System.Boolean HorizontalScrollbarBackgroundFillClockwise
        {
            get { return ScrollableRegion.HorizontalScrollbarBackgroundFillClockwise; }
            set { ScrollableRegion.HorizontalScrollbarBackgroundFillClockwise = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBackgroundFillOriginProperty = ScrollableRegion.HorizontalScrollbarBackgroundFillOriginProperty;
        public System.Int32 HorizontalScrollbarBackgroundFillOrigin
        {
            get { return ScrollableRegion.HorizontalScrollbarBackgroundFillOrigin; }
            set { ScrollableRegion.HorizontalScrollbarBackgroundFillOrigin = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBackgroundAlphaHitTestMinimumThresholdProperty = ScrollableRegion.HorizontalScrollbarBackgroundAlphaHitTestMinimumThresholdProperty;
        public System.Single HorizontalScrollbarBackgroundAlphaHitTestMinimumThreshold
        {
            get { return ScrollableRegion.HorizontalScrollbarBackgroundAlphaHitTestMinimumThreshold; }
            set { ScrollableRegion.HorizontalScrollbarBackgroundAlphaHitTestMinimumThreshold = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBackgroundUseSpriteMeshProperty = ScrollableRegion.HorizontalScrollbarBackgroundUseSpriteMeshProperty;
        public System.Boolean HorizontalScrollbarBackgroundUseSpriteMesh
        {
            get { return ScrollableRegion.HorizontalScrollbarBackgroundUseSpriteMesh; }
            set { ScrollableRegion.HorizontalScrollbarBackgroundUseSpriteMesh = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBackgroundMaterialProperty = ScrollableRegion.HorizontalScrollbarBackgroundMaterialProperty;
        public MaterialAsset HorizontalScrollbarBackgroundMaterial
        {
            get { return ScrollableRegion.HorizontalScrollbarBackgroundMaterial; }
            set { ScrollableRegion.HorizontalScrollbarBackgroundMaterial = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBackgroundOnCullStateChangedProperty = ScrollableRegion.HorizontalScrollbarBackgroundOnCullStateChangedProperty;
        public UnityEngine.UI.MaskableGraphic.CullStateChangedEvent HorizontalScrollbarBackgroundOnCullStateChanged
        {
            get { return ScrollableRegion.HorizontalScrollbarBackgroundOnCullStateChanged; }
            set { ScrollableRegion.HorizontalScrollbarBackgroundOnCullStateChanged = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBackgroundMaskableProperty = ScrollableRegion.HorizontalScrollbarBackgroundMaskableProperty;
        public System.Boolean HorizontalScrollbarBackgroundMaskable
        {
            get { return ScrollableRegion.HorizontalScrollbarBackgroundMaskable; }
            set { ScrollableRegion.HorizontalScrollbarBackgroundMaskable = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBackgroundColorProperty = ScrollableRegion.HorizontalScrollbarBackgroundColorProperty;
        public UnityEngine.Color HorizontalScrollbarBackgroundColor
        {
            get { return ScrollableRegion.HorizontalScrollbarBackgroundColor; }
            set { ScrollableRegion.HorizontalScrollbarBackgroundColor = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBackgroundRaycastTargetProperty = ScrollableRegion.HorizontalScrollbarBackgroundRaycastTargetProperty;
        public System.Boolean HorizontalScrollbarBackgroundRaycastTarget
        {
            get { return ScrollableRegion.HorizontalScrollbarBackgroundRaycastTarget; }
            set { ScrollableRegion.HorizontalScrollbarBackgroundRaycastTarget = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarWidthProperty = ScrollableRegion.HorizontalScrollbarWidthProperty;
        public Delight.ElementSize HorizontalScrollbarWidth
        {
            get { return ScrollableRegion.HorizontalScrollbarWidth; }
            set { ScrollableRegion.HorizontalScrollbarWidth = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHeightProperty = ScrollableRegion.HorizontalScrollbarHeightProperty;
        public Delight.ElementSize HorizontalScrollbarHeight
        {
            get { return ScrollableRegion.HorizontalScrollbarHeight; }
            set { ScrollableRegion.HorizontalScrollbarHeight = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarOverrideWidthProperty = ScrollableRegion.HorizontalScrollbarOverrideWidthProperty;
        public Delight.ElementSize HorizontalScrollbarOverrideWidth
        {
            get { return ScrollableRegion.HorizontalScrollbarOverrideWidth; }
            set { ScrollableRegion.HorizontalScrollbarOverrideWidth = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarOverrideHeightProperty = ScrollableRegion.HorizontalScrollbarOverrideHeightProperty;
        public Delight.ElementSize HorizontalScrollbarOverrideHeight
        {
            get { return ScrollableRegion.HorizontalScrollbarOverrideHeight; }
            set { ScrollableRegion.HorizontalScrollbarOverrideHeight = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarScaleProperty = ScrollableRegion.HorizontalScrollbarScaleProperty;
        public UnityEngine.Vector3 HorizontalScrollbarScale
        {
            get { return ScrollableRegion.HorizontalScrollbarScale; }
            set { ScrollableRegion.HorizontalScrollbarScale = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarAlignmentProperty = ScrollableRegion.HorizontalScrollbarAlignmentProperty;
        public Delight.ElementAlignment HorizontalScrollbarAlignment
        {
            get { return ScrollableRegion.HorizontalScrollbarAlignment; }
            set { ScrollableRegion.HorizontalScrollbarAlignment = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarMarginProperty = ScrollableRegion.HorizontalScrollbarMarginProperty;
        public Delight.ElementMargin HorizontalScrollbarMargin
        {
            get { return ScrollableRegion.HorizontalScrollbarMargin; }
            set { ScrollableRegion.HorizontalScrollbarMargin = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarOffsetProperty = ScrollableRegion.HorizontalScrollbarOffsetProperty;
        public Delight.ElementMargin HorizontalScrollbarOffset
        {
            get { return ScrollableRegion.HorizontalScrollbarOffset; }
            set { ScrollableRegion.HorizontalScrollbarOffset = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarOffsetFromParentProperty = ScrollableRegion.HorizontalScrollbarOffsetFromParentProperty;
        public Delight.ElementMargin HorizontalScrollbarOffsetFromParent
        {
            get { return ScrollableRegion.HorizontalScrollbarOffsetFromParent; }
            set { ScrollableRegion.HorizontalScrollbarOffsetFromParent = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarPivotProperty = ScrollableRegion.HorizontalScrollbarPivotProperty;
        public UnityEngine.Vector2 HorizontalScrollbarPivot
        {
            get { return ScrollableRegion.HorizontalScrollbarPivot; }
            set { ScrollableRegion.HorizontalScrollbarPivot = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarLayoutRootProperty = ScrollableRegion.HorizontalScrollbarLayoutRootProperty;
        public Delight.LayoutRoot HorizontalScrollbarLayoutRoot
        {
            get { return ScrollableRegion.HorizontalScrollbarLayoutRoot; }
            set { ScrollableRegion.HorizontalScrollbarLayoutRoot = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarDisableLayoutUpdateProperty = ScrollableRegion.HorizontalScrollbarDisableLayoutUpdateProperty;
        public System.Boolean HorizontalScrollbarDisableLayoutUpdate
        {
            get { return ScrollableRegion.HorizontalScrollbarDisableLayoutUpdate; }
            set { ScrollableRegion.HorizontalScrollbarDisableLayoutUpdate = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarAlphaProperty = ScrollableRegion.HorizontalScrollbarAlphaProperty;
        public System.Single HorizontalScrollbarAlpha
        {
            get { return ScrollableRegion.HorizontalScrollbarAlpha; }
            set { ScrollableRegion.HorizontalScrollbarAlpha = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarIsVisibleProperty = ScrollableRegion.HorizontalScrollbarIsVisibleProperty;
        public System.Boolean HorizontalScrollbarIsVisible
        {
            get { return ScrollableRegion.HorizontalScrollbarIsVisible; }
            set { ScrollableRegion.HorizontalScrollbarIsVisible = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarRaycastBlockModeProperty = ScrollableRegion.HorizontalScrollbarRaycastBlockModeProperty;
        public Delight.RaycastBlockMode HorizontalScrollbarRaycastBlockMode
        {
            get { return ScrollableRegion.HorizontalScrollbarRaycastBlockMode; }
            set { ScrollableRegion.HorizontalScrollbarRaycastBlockMode = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarUseFastShaderProperty = ScrollableRegion.HorizontalScrollbarUseFastShaderProperty;
        public System.Boolean HorizontalScrollbarUseFastShader
        {
            get { return ScrollableRegion.HorizontalScrollbarUseFastShader; }
            set { ScrollableRegion.HorizontalScrollbarUseFastShader = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBubbleNotifyChildLayoutChangedProperty = ScrollableRegion.HorizontalScrollbarBubbleNotifyChildLayoutChangedProperty;
        public System.Boolean HorizontalScrollbarBubbleNotifyChildLayoutChanged
        {
            get { return ScrollableRegion.HorizontalScrollbarBubbleNotifyChildLayoutChanged; }
            set { ScrollableRegion.HorizontalScrollbarBubbleNotifyChildLayoutChanged = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarIgnoreFlipProperty = ScrollableRegion.HorizontalScrollbarIgnoreFlipProperty;
        public System.Boolean HorizontalScrollbarIgnoreFlip
        {
            get { return ScrollableRegion.HorizontalScrollbarIgnoreFlip; }
            set { ScrollableRegion.HorizontalScrollbarIgnoreFlip = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarGameObjectProperty = ScrollableRegion.HorizontalScrollbarGameObjectProperty;
        public UnityEngine.GameObject HorizontalScrollbarGameObject
        {
            get { return ScrollableRegion.HorizontalScrollbarGameObject; }
            set { ScrollableRegion.HorizontalScrollbarGameObject = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarEnableScriptEventsProperty = ScrollableRegion.HorizontalScrollbarEnableScriptEventsProperty;
        public System.Boolean HorizontalScrollbarEnableScriptEvents
        {
            get { return ScrollableRegion.HorizontalScrollbarEnableScriptEvents; }
            set { ScrollableRegion.HorizontalScrollbarEnableScriptEvents = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarIgnoreObjectProperty = ScrollableRegion.HorizontalScrollbarIgnoreObjectProperty;
        public System.Boolean HorizontalScrollbarIgnoreObject
        {
            get { return ScrollableRegion.HorizontalScrollbarIgnoreObject; }
            set { ScrollableRegion.HorizontalScrollbarIgnoreObject = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarIsActiveProperty = ScrollableRegion.HorizontalScrollbarIsActiveProperty;
        public System.Boolean HorizontalScrollbarIsActive
        {
            get { return ScrollableRegion.HorizontalScrollbarIsActive; }
            set { ScrollableRegion.HorizontalScrollbarIsActive = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarLoadModeProperty = ScrollableRegion.HorizontalScrollbarLoadModeProperty;
        public Delight.LoadMode HorizontalScrollbarLoadMode
        {
            get { return ScrollableRegion.HorizontalScrollbarLoadMode; }
            set { ScrollableRegion.HorizontalScrollbarLoadMode = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarLengthProperty = ScrollableRegion.VerticalScrollbarLengthProperty;
        public Delight.ElementSize VerticalScrollbarLength
        {
            get { return ScrollableRegion.VerticalScrollbarLength; }
            set { ScrollableRegion.VerticalScrollbarLength = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBreadthProperty = ScrollableRegion.VerticalScrollbarBreadthProperty;
        public Delight.ElementSize VerticalScrollbarBreadth
        {
            get { return ScrollableRegion.VerticalScrollbarBreadth; }
            set { ScrollableRegion.VerticalScrollbarBreadth = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarOrientationProperty = ScrollableRegion.VerticalScrollbarOrientationProperty;
        public Delight.ElementOrientation VerticalScrollbarOrientation
        {
            get { return ScrollableRegion.VerticalScrollbarOrientation; }
            set { ScrollableRegion.VerticalScrollbarOrientation = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarScrollPositionProperty = ScrollableRegion.VerticalScrollbarScrollPositionProperty;
        public System.Single VerticalScrollbarScrollPosition
        {
            get { return ScrollableRegion.VerticalScrollbarScrollPosition; }
            set { ScrollableRegion.VerticalScrollbarScrollPosition = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarViewportRatioProperty = ScrollableRegion.VerticalScrollbarViewportRatioProperty;
        public System.Single VerticalScrollbarViewportRatio
        {
            get { return ScrollableRegion.VerticalScrollbarViewportRatio; }
            set { ScrollableRegion.VerticalScrollbarViewportRatio = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarSpriteProperty = ScrollableRegion.VerticalScrollbarBarSpriteProperty;
        public SpriteAsset VerticalScrollbarBarSprite
        {
            get { return ScrollableRegion.VerticalScrollbarBarSprite; }
            set { ScrollableRegion.VerticalScrollbarBarSprite = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarOverrideSpriteProperty = ScrollableRegion.VerticalScrollbarBarOverrideSpriteProperty;
        public SpriteAsset VerticalScrollbarBarOverrideSprite
        {
            get { return ScrollableRegion.VerticalScrollbarBarOverrideSprite; }
            set { ScrollableRegion.VerticalScrollbarBarOverrideSprite = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarTypeProperty = ScrollableRegion.VerticalScrollbarBarTypeProperty;
        public UnityEngine.UI.Image.Type VerticalScrollbarBarType
        {
            get { return ScrollableRegion.VerticalScrollbarBarType; }
            set { ScrollableRegion.VerticalScrollbarBarType = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarPreserveAspectProperty = ScrollableRegion.VerticalScrollbarBarPreserveAspectProperty;
        public System.Boolean VerticalScrollbarBarPreserveAspect
        {
            get { return ScrollableRegion.VerticalScrollbarBarPreserveAspect; }
            set { ScrollableRegion.VerticalScrollbarBarPreserveAspect = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarFillCenterProperty = ScrollableRegion.VerticalScrollbarBarFillCenterProperty;
        public System.Boolean VerticalScrollbarBarFillCenter
        {
            get { return ScrollableRegion.VerticalScrollbarBarFillCenter; }
            set { ScrollableRegion.VerticalScrollbarBarFillCenter = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarFillMethodProperty = ScrollableRegion.VerticalScrollbarBarFillMethodProperty;
        public UnityEngine.UI.Image.FillMethod VerticalScrollbarBarFillMethod
        {
            get { return ScrollableRegion.VerticalScrollbarBarFillMethod; }
            set { ScrollableRegion.VerticalScrollbarBarFillMethod = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarFillAmountProperty = ScrollableRegion.VerticalScrollbarBarFillAmountProperty;
        public System.Single VerticalScrollbarBarFillAmount
        {
            get { return ScrollableRegion.VerticalScrollbarBarFillAmount; }
            set { ScrollableRegion.VerticalScrollbarBarFillAmount = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarFillClockwiseProperty = ScrollableRegion.VerticalScrollbarBarFillClockwiseProperty;
        public System.Boolean VerticalScrollbarBarFillClockwise
        {
            get { return ScrollableRegion.VerticalScrollbarBarFillClockwise; }
            set { ScrollableRegion.VerticalScrollbarBarFillClockwise = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarFillOriginProperty = ScrollableRegion.VerticalScrollbarBarFillOriginProperty;
        public System.Int32 VerticalScrollbarBarFillOrigin
        {
            get { return ScrollableRegion.VerticalScrollbarBarFillOrigin; }
            set { ScrollableRegion.VerticalScrollbarBarFillOrigin = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarAlphaHitTestMinimumThresholdProperty = ScrollableRegion.VerticalScrollbarBarAlphaHitTestMinimumThresholdProperty;
        public System.Single VerticalScrollbarBarAlphaHitTestMinimumThreshold
        {
            get { return ScrollableRegion.VerticalScrollbarBarAlphaHitTestMinimumThreshold; }
            set { ScrollableRegion.VerticalScrollbarBarAlphaHitTestMinimumThreshold = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarUseSpriteMeshProperty = ScrollableRegion.VerticalScrollbarBarUseSpriteMeshProperty;
        public System.Boolean VerticalScrollbarBarUseSpriteMesh
        {
            get { return ScrollableRegion.VerticalScrollbarBarUseSpriteMesh; }
            set { ScrollableRegion.VerticalScrollbarBarUseSpriteMesh = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarMaterialProperty = ScrollableRegion.VerticalScrollbarBarMaterialProperty;
        public MaterialAsset VerticalScrollbarBarMaterial
        {
            get { return ScrollableRegion.VerticalScrollbarBarMaterial; }
            set { ScrollableRegion.VerticalScrollbarBarMaterial = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarOnCullStateChangedProperty = ScrollableRegion.VerticalScrollbarBarOnCullStateChangedProperty;
        public UnityEngine.UI.MaskableGraphic.CullStateChangedEvent VerticalScrollbarBarOnCullStateChanged
        {
            get { return ScrollableRegion.VerticalScrollbarBarOnCullStateChanged; }
            set { ScrollableRegion.VerticalScrollbarBarOnCullStateChanged = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarMaskableProperty = ScrollableRegion.VerticalScrollbarBarMaskableProperty;
        public System.Boolean VerticalScrollbarBarMaskable
        {
            get { return ScrollableRegion.VerticalScrollbarBarMaskable; }
            set { ScrollableRegion.VerticalScrollbarBarMaskable = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarColorProperty = ScrollableRegion.VerticalScrollbarBarColorProperty;
        public UnityEngine.Color VerticalScrollbarBarColor
        {
            get { return ScrollableRegion.VerticalScrollbarBarColor; }
            set { ScrollableRegion.VerticalScrollbarBarColor = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarRaycastTargetProperty = ScrollableRegion.VerticalScrollbarBarRaycastTargetProperty;
        public System.Boolean VerticalScrollbarBarRaycastTarget
        {
            get { return ScrollableRegion.VerticalScrollbarBarRaycastTarget; }
            set { ScrollableRegion.VerticalScrollbarBarRaycastTarget = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarWidthProperty = ScrollableRegion.VerticalScrollbarBarWidthProperty;
        public Delight.ElementSize VerticalScrollbarBarWidth
        {
            get { return ScrollableRegion.VerticalScrollbarBarWidth; }
            set { ScrollableRegion.VerticalScrollbarBarWidth = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarHeightProperty = ScrollableRegion.VerticalScrollbarBarHeightProperty;
        public Delight.ElementSize VerticalScrollbarBarHeight
        {
            get { return ScrollableRegion.VerticalScrollbarBarHeight; }
            set { ScrollableRegion.VerticalScrollbarBarHeight = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarOverrideWidthProperty = ScrollableRegion.VerticalScrollbarBarOverrideWidthProperty;
        public Delight.ElementSize VerticalScrollbarBarOverrideWidth
        {
            get { return ScrollableRegion.VerticalScrollbarBarOverrideWidth; }
            set { ScrollableRegion.VerticalScrollbarBarOverrideWidth = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarOverrideHeightProperty = ScrollableRegion.VerticalScrollbarBarOverrideHeightProperty;
        public Delight.ElementSize VerticalScrollbarBarOverrideHeight
        {
            get { return ScrollableRegion.VerticalScrollbarBarOverrideHeight; }
            set { ScrollableRegion.VerticalScrollbarBarOverrideHeight = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarScaleProperty = ScrollableRegion.VerticalScrollbarBarScaleProperty;
        public UnityEngine.Vector3 VerticalScrollbarBarScale
        {
            get { return ScrollableRegion.VerticalScrollbarBarScale; }
            set { ScrollableRegion.VerticalScrollbarBarScale = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarAlignmentProperty = ScrollableRegion.VerticalScrollbarBarAlignmentProperty;
        public Delight.ElementAlignment VerticalScrollbarBarAlignment
        {
            get { return ScrollableRegion.VerticalScrollbarBarAlignment; }
            set { ScrollableRegion.VerticalScrollbarBarAlignment = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarMarginProperty = ScrollableRegion.VerticalScrollbarBarMarginProperty;
        public Delight.ElementMargin VerticalScrollbarBarMargin
        {
            get { return ScrollableRegion.VerticalScrollbarBarMargin; }
            set { ScrollableRegion.VerticalScrollbarBarMargin = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarOffsetProperty = ScrollableRegion.VerticalScrollbarBarOffsetProperty;
        public Delight.ElementMargin VerticalScrollbarBarOffset
        {
            get { return ScrollableRegion.VerticalScrollbarBarOffset; }
            set { ScrollableRegion.VerticalScrollbarBarOffset = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarOffsetFromParentProperty = ScrollableRegion.VerticalScrollbarBarOffsetFromParentProperty;
        public Delight.ElementMargin VerticalScrollbarBarOffsetFromParent
        {
            get { return ScrollableRegion.VerticalScrollbarBarOffsetFromParent; }
            set { ScrollableRegion.VerticalScrollbarBarOffsetFromParent = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarPivotProperty = ScrollableRegion.VerticalScrollbarBarPivotProperty;
        public UnityEngine.Vector2 VerticalScrollbarBarPivot
        {
            get { return ScrollableRegion.VerticalScrollbarBarPivot; }
            set { ScrollableRegion.VerticalScrollbarBarPivot = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarLayoutRootProperty = ScrollableRegion.VerticalScrollbarBarLayoutRootProperty;
        public Delight.LayoutRoot VerticalScrollbarBarLayoutRoot
        {
            get { return ScrollableRegion.VerticalScrollbarBarLayoutRoot; }
            set { ScrollableRegion.VerticalScrollbarBarLayoutRoot = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarDisableLayoutUpdateProperty = ScrollableRegion.VerticalScrollbarBarDisableLayoutUpdateProperty;
        public System.Boolean VerticalScrollbarBarDisableLayoutUpdate
        {
            get { return ScrollableRegion.VerticalScrollbarBarDisableLayoutUpdate; }
            set { ScrollableRegion.VerticalScrollbarBarDisableLayoutUpdate = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarAlphaProperty = ScrollableRegion.VerticalScrollbarBarAlphaProperty;
        public System.Single VerticalScrollbarBarAlpha
        {
            get { return ScrollableRegion.VerticalScrollbarBarAlpha; }
            set { ScrollableRegion.VerticalScrollbarBarAlpha = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarIsVisibleProperty = ScrollableRegion.VerticalScrollbarBarIsVisibleProperty;
        public System.Boolean VerticalScrollbarBarIsVisible
        {
            get { return ScrollableRegion.VerticalScrollbarBarIsVisible; }
            set { ScrollableRegion.VerticalScrollbarBarIsVisible = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarRaycastBlockModeProperty = ScrollableRegion.VerticalScrollbarBarRaycastBlockModeProperty;
        public Delight.RaycastBlockMode VerticalScrollbarBarRaycastBlockMode
        {
            get { return ScrollableRegion.VerticalScrollbarBarRaycastBlockMode; }
            set { ScrollableRegion.VerticalScrollbarBarRaycastBlockMode = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarUseFastShaderProperty = ScrollableRegion.VerticalScrollbarBarUseFastShaderProperty;
        public System.Boolean VerticalScrollbarBarUseFastShader
        {
            get { return ScrollableRegion.VerticalScrollbarBarUseFastShader; }
            set { ScrollableRegion.VerticalScrollbarBarUseFastShader = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarBubbleNotifyChildLayoutChangedProperty = ScrollableRegion.VerticalScrollbarBarBubbleNotifyChildLayoutChangedProperty;
        public System.Boolean VerticalScrollbarBarBubbleNotifyChildLayoutChanged
        {
            get { return ScrollableRegion.VerticalScrollbarBarBubbleNotifyChildLayoutChanged; }
            set { ScrollableRegion.VerticalScrollbarBarBubbleNotifyChildLayoutChanged = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarIgnoreFlipProperty = ScrollableRegion.VerticalScrollbarBarIgnoreFlipProperty;
        public System.Boolean VerticalScrollbarBarIgnoreFlip
        {
            get { return ScrollableRegion.VerticalScrollbarBarIgnoreFlip; }
            set { ScrollableRegion.VerticalScrollbarBarIgnoreFlip = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarGameObjectProperty = ScrollableRegion.VerticalScrollbarBarGameObjectProperty;
        public UnityEngine.GameObject VerticalScrollbarBarGameObject
        {
            get { return ScrollableRegion.VerticalScrollbarBarGameObject; }
            set { ScrollableRegion.VerticalScrollbarBarGameObject = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarEnableScriptEventsProperty = ScrollableRegion.VerticalScrollbarBarEnableScriptEventsProperty;
        public System.Boolean VerticalScrollbarBarEnableScriptEvents
        {
            get { return ScrollableRegion.VerticalScrollbarBarEnableScriptEvents; }
            set { ScrollableRegion.VerticalScrollbarBarEnableScriptEvents = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarIgnoreObjectProperty = ScrollableRegion.VerticalScrollbarBarIgnoreObjectProperty;
        public System.Boolean VerticalScrollbarBarIgnoreObject
        {
            get { return ScrollableRegion.VerticalScrollbarBarIgnoreObject; }
            set { ScrollableRegion.VerticalScrollbarBarIgnoreObject = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarIsActiveProperty = ScrollableRegion.VerticalScrollbarBarIsActiveProperty;
        public System.Boolean VerticalScrollbarBarIsActive
        {
            get { return ScrollableRegion.VerticalScrollbarBarIsActive; }
            set { ScrollableRegion.VerticalScrollbarBarIsActive = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarLoadModeProperty = ScrollableRegion.VerticalScrollbarBarLoadModeProperty;
        public Delight.LoadMode VerticalScrollbarBarLoadMode
        {
            get { return ScrollableRegion.VerticalScrollbarBarLoadMode; }
            set { ScrollableRegion.VerticalScrollbarBarLoadMode = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleSpriteProperty = ScrollableRegion.VerticalScrollbarHandleSpriteProperty;
        public SpriteAsset VerticalScrollbarHandleSprite
        {
            get { return ScrollableRegion.VerticalScrollbarHandleSprite; }
            set { ScrollableRegion.VerticalScrollbarHandleSprite = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleOverrideSpriteProperty = ScrollableRegion.VerticalScrollbarHandleOverrideSpriteProperty;
        public SpriteAsset VerticalScrollbarHandleOverrideSprite
        {
            get { return ScrollableRegion.VerticalScrollbarHandleOverrideSprite; }
            set { ScrollableRegion.VerticalScrollbarHandleOverrideSprite = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleTypeProperty = ScrollableRegion.VerticalScrollbarHandleTypeProperty;
        public UnityEngine.UI.Image.Type VerticalScrollbarHandleType
        {
            get { return ScrollableRegion.VerticalScrollbarHandleType; }
            set { ScrollableRegion.VerticalScrollbarHandleType = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandlePreserveAspectProperty = ScrollableRegion.VerticalScrollbarHandlePreserveAspectProperty;
        public System.Boolean VerticalScrollbarHandlePreserveAspect
        {
            get { return ScrollableRegion.VerticalScrollbarHandlePreserveAspect; }
            set { ScrollableRegion.VerticalScrollbarHandlePreserveAspect = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleFillCenterProperty = ScrollableRegion.VerticalScrollbarHandleFillCenterProperty;
        public System.Boolean VerticalScrollbarHandleFillCenter
        {
            get { return ScrollableRegion.VerticalScrollbarHandleFillCenter; }
            set { ScrollableRegion.VerticalScrollbarHandleFillCenter = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleFillMethodProperty = ScrollableRegion.VerticalScrollbarHandleFillMethodProperty;
        public UnityEngine.UI.Image.FillMethod VerticalScrollbarHandleFillMethod
        {
            get { return ScrollableRegion.VerticalScrollbarHandleFillMethod; }
            set { ScrollableRegion.VerticalScrollbarHandleFillMethod = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleFillAmountProperty = ScrollableRegion.VerticalScrollbarHandleFillAmountProperty;
        public System.Single VerticalScrollbarHandleFillAmount
        {
            get { return ScrollableRegion.VerticalScrollbarHandleFillAmount; }
            set { ScrollableRegion.VerticalScrollbarHandleFillAmount = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleFillClockwiseProperty = ScrollableRegion.VerticalScrollbarHandleFillClockwiseProperty;
        public System.Boolean VerticalScrollbarHandleFillClockwise
        {
            get { return ScrollableRegion.VerticalScrollbarHandleFillClockwise; }
            set { ScrollableRegion.VerticalScrollbarHandleFillClockwise = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleFillOriginProperty = ScrollableRegion.VerticalScrollbarHandleFillOriginProperty;
        public System.Int32 VerticalScrollbarHandleFillOrigin
        {
            get { return ScrollableRegion.VerticalScrollbarHandleFillOrigin; }
            set { ScrollableRegion.VerticalScrollbarHandleFillOrigin = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleAlphaHitTestMinimumThresholdProperty = ScrollableRegion.VerticalScrollbarHandleAlphaHitTestMinimumThresholdProperty;
        public System.Single VerticalScrollbarHandleAlphaHitTestMinimumThreshold
        {
            get { return ScrollableRegion.VerticalScrollbarHandleAlphaHitTestMinimumThreshold; }
            set { ScrollableRegion.VerticalScrollbarHandleAlphaHitTestMinimumThreshold = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleUseSpriteMeshProperty = ScrollableRegion.VerticalScrollbarHandleUseSpriteMeshProperty;
        public System.Boolean VerticalScrollbarHandleUseSpriteMesh
        {
            get { return ScrollableRegion.VerticalScrollbarHandleUseSpriteMesh; }
            set { ScrollableRegion.VerticalScrollbarHandleUseSpriteMesh = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleMaterialProperty = ScrollableRegion.VerticalScrollbarHandleMaterialProperty;
        public MaterialAsset VerticalScrollbarHandleMaterial
        {
            get { return ScrollableRegion.VerticalScrollbarHandleMaterial; }
            set { ScrollableRegion.VerticalScrollbarHandleMaterial = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleOnCullStateChangedProperty = ScrollableRegion.VerticalScrollbarHandleOnCullStateChangedProperty;
        public UnityEngine.UI.MaskableGraphic.CullStateChangedEvent VerticalScrollbarHandleOnCullStateChanged
        {
            get { return ScrollableRegion.VerticalScrollbarHandleOnCullStateChanged; }
            set { ScrollableRegion.VerticalScrollbarHandleOnCullStateChanged = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleMaskableProperty = ScrollableRegion.VerticalScrollbarHandleMaskableProperty;
        public System.Boolean VerticalScrollbarHandleMaskable
        {
            get { return ScrollableRegion.VerticalScrollbarHandleMaskable; }
            set { ScrollableRegion.VerticalScrollbarHandleMaskable = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleColorProperty = ScrollableRegion.VerticalScrollbarHandleColorProperty;
        public UnityEngine.Color VerticalScrollbarHandleColor
        {
            get { return ScrollableRegion.VerticalScrollbarHandleColor; }
            set { ScrollableRegion.VerticalScrollbarHandleColor = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleRaycastTargetProperty = ScrollableRegion.VerticalScrollbarHandleRaycastTargetProperty;
        public System.Boolean VerticalScrollbarHandleRaycastTarget
        {
            get { return ScrollableRegion.VerticalScrollbarHandleRaycastTarget; }
            set { ScrollableRegion.VerticalScrollbarHandleRaycastTarget = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleWidthProperty = ScrollableRegion.VerticalScrollbarHandleWidthProperty;
        public Delight.ElementSize VerticalScrollbarHandleWidth
        {
            get { return ScrollableRegion.VerticalScrollbarHandleWidth; }
            set { ScrollableRegion.VerticalScrollbarHandleWidth = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleHeightProperty = ScrollableRegion.VerticalScrollbarHandleHeightProperty;
        public Delight.ElementSize VerticalScrollbarHandleHeight
        {
            get { return ScrollableRegion.VerticalScrollbarHandleHeight; }
            set { ScrollableRegion.VerticalScrollbarHandleHeight = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleOverrideWidthProperty = ScrollableRegion.VerticalScrollbarHandleOverrideWidthProperty;
        public Delight.ElementSize VerticalScrollbarHandleOverrideWidth
        {
            get { return ScrollableRegion.VerticalScrollbarHandleOverrideWidth; }
            set { ScrollableRegion.VerticalScrollbarHandleOverrideWidth = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleOverrideHeightProperty = ScrollableRegion.VerticalScrollbarHandleOverrideHeightProperty;
        public Delight.ElementSize VerticalScrollbarHandleOverrideHeight
        {
            get { return ScrollableRegion.VerticalScrollbarHandleOverrideHeight; }
            set { ScrollableRegion.VerticalScrollbarHandleOverrideHeight = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleScaleProperty = ScrollableRegion.VerticalScrollbarHandleScaleProperty;
        public UnityEngine.Vector3 VerticalScrollbarHandleScale
        {
            get { return ScrollableRegion.VerticalScrollbarHandleScale; }
            set { ScrollableRegion.VerticalScrollbarHandleScale = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleAlignmentProperty = ScrollableRegion.VerticalScrollbarHandleAlignmentProperty;
        public Delight.ElementAlignment VerticalScrollbarHandleAlignment
        {
            get { return ScrollableRegion.VerticalScrollbarHandleAlignment; }
            set { ScrollableRegion.VerticalScrollbarHandleAlignment = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleMarginProperty = ScrollableRegion.VerticalScrollbarHandleMarginProperty;
        public Delight.ElementMargin VerticalScrollbarHandleMargin
        {
            get { return ScrollableRegion.VerticalScrollbarHandleMargin; }
            set { ScrollableRegion.VerticalScrollbarHandleMargin = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleOffsetProperty = ScrollableRegion.VerticalScrollbarHandleOffsetProperty;
        public Delight.ElementMargin VerticalScrollbarHandleOffset
        {
            get { return ScrollableRegion.VerticalScrollbarHandleOffset; }
            set { ScrollableRegion.VerticalScrollbarHandleOffset = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleOffsetFromParentProperty = ScrollableRegion.VerticalScrollbarHandleOffsetFromParentProperty;
        public Delight.ElementMargin VerticalScrollbarHandleOffsetFromParent
        {
            get { return ScrollableRegion.VerticalScrollbarHandleOffsetFromParent; }
            set { ScrollableRegion.VerticalScrollbarHandleOffsetFromParent = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandlePivotProperty = ScrollableRegion.VerticalScrollbarHandlePivotProperty;
        public UnityEngine.Vector2 VerticalScrollbarHandlePivot
        {
            get { return ScrollableRegion.VerticalScrollbarHandlePivot; }
            set { ScrollableRegion.VerticalScrollbarHandlePivot = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleLayoutRootProperty = ScrollableRegion.VerticalScrollbarHandleLayoutRootProperty;
        public Delight.LayoutRoot VerticalScrollbarHandleLayoutRoot
        {
            get { return ScrollableRegion.VerticalScrollbarHandleLayoutRoot; }
            set { ScrollableRegion.VerticalScrollbarHandleLayoutRoot = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleDisableLayoutUpdateProperty = ScrollableRegion.VerticalScrollbarHandleDisableLayoutUpdateProperty;
        public System.Boolean VerticalScrollbarHandleDisableLayoutUpdate
        {
            get { return ScrollableRegion.VerticalScrollbarHandleDisableLayoutUpdate; }
            set { ScrollableRegion.VerticalScrollbarHandleDisableLayoutUpdate = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleAlphaProperty = ScrollableRegion.VerticalScrollbarHandleAlphaProperty;
        public System.Single VerticalScrollbarHandleAlpha
        {
            get { return ScrollableRegion.VerticalScrollbarHandleAlpha; }
            set { ScrollableRegion.VerticalScrollbarHandleAlpha = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleIsVisibleProperty = ScrollableRegion.VerticalScrollbarHandleIsVisibleProperty;
        public System.Boolean VerticalScrollbarHandleIsVisible
        {
            get { return ScrollableRegion.VerticalScrollbarHandleIsVisible; }
            set { ScrollableRegion.VerticalScrollbarHandleIsVisible = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleRaycastBlockModeProperty = ScrollableRegion.VerticalScrollbarHandleRaycastBlockModeProperty;
        public Delight.RaycastBlockMode VerticalScrollbarHandleRaycastBlockMode
        {
            get { return ScrollableRegion.VerticalScrollbarHandleRaycastBlockMode; }
            set { ScrollableRegion.VerticalScrollbarHandleRaycastBlockMode = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleUseFastShaderProperty = ScrollableRegion.VerticalScrollbarHandleUseFastShaderProperty;
        public System.Boolean VerticalScrollbarHandleUseFastShader
        {
            get { return ScrollableRegion.VerticalScrollbarHandleUseFastShader; }
            set { ScrollableRegion.VerticalScrollbarHandleUseFastShader = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleBubbleNotifyChildLayoutChangedProperty = ScrollableRegion.VerticalScrollbarHandleBubbleNotifyChildLayoutChangedProperty;
        public System.Boolean VerticalScrollbarHandleBubbleNotifyChildLayoutChanged
        {
            get { return ScrollableRegion.VerticalScrollbarHandleBubbleNotifyChildLayoutChanged; }
            set { ScrollableRegion.VerticalScrollbarHandleBubbleNotifyChildLayoutChanged = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleIgnoreFlipProperty = ScrollableRegion.VerticalScrollbarHandleIgnoreFlipProperty;
        public System.Boolean VerticalScrollbarHandleIgnoreFlip
        {
            get { return ScrollableRegion.VerticalScrollbarHandleIgnoreFlip; }
            set { ScrollableRegion.VerticalScrollbarHandleIgnoreFlip = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleGameObjectProperty = ScrollableRegion.VerticalScrollbarHandleGameObjectProperty;
        public UnityEngine.GameObject VerticalScrollbarHandleGameObject
        {
            get { return ScrollableRegion.VerticalScrollbarHandleGameObject; }
            set { ScrollableRegion.VerticalScrollbarHandleGameObject = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleEnableScriptEventsProperty = ScrollableRegion.VerticalScrollbarHandleEnableScriptEventsProperty;
        public System.Boolean VerticalScrollbarHandleEnableScriptEvents
        {
            get { return ScrollableRegion.VerticalScrollbarHandleEnableScriptEvents; }
            set { ScrollableRegion.VerticalScrollbarHandleEnableScriptEvents = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleIgnoreObjectProperty = ScrollableRegion.VerticalScrollbarHandleIgnoreObjectProperty;
        public System.Boolean VerticalScrollbarHandleIgnoreObject
        {
            get { return ScrollableRegion.VerticalScrollbarHandleIgnoreObject; }
            set { ScrollableRegion.VerticalScrollbarHandleIgnoreObject = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleIsActiveProperty = ScrollableRegion.VerticalScrollbarHandleIsActiveProperty;
        public System.Boolean VerticalScrollbarHandleIsActive
        {
            get { return ScrollableRegion.VerticalScrollbarHandleIsActive; }
            set { ScrollableRegion.VerticalScrollbarHandleIsActive = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleLoadModeProperty = ScrollableRegion.VerticalScrollbarHandleLoadModeProperty;
        public Delight.LoadMode VerticalScrollbarHandleLoadMode
        {
            get { return ScrollableRegion.VerticalScrollbarHandleLoadMode; }
            set { ScrollableRegion.VerticalScrollbarHandleLoadMode = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBackgroundSpriteProperty = ScrollableRegion.VerticalScrollbarBackgroundSpriteProperty;
        public SpriteAsset VerticalScrollbarBackgroundSprite
        {
            get { return ScrollableRegion.VerticalScrollbarBackgroundSprite; }
            set { ScrollableRegion.VerticalScrollbarBackgroundSprite = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBackgroundOverrideSpriteProperty = ScrollableRegion.VerticalScrollbarBackgroundOverrideSpriteProperty;
        public SpriteAsset VerticalScrollbarBackgroundOverrideSprite
        {
            get { return ScrollableRegion.VerticalScrollbarBackgroundOverrideSprite; }
            set { ScrollableRegion.VerticalScrollbarBackgroundOverrideSprite = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBackgroundTypeProperty = ScrollableRegion.VerticalScrollbarBackgroundTypeProperty;
        public UnityEngine.UI.Image.Type VerticalScrollbarBackgroundType
        {
            get { return ScrollableRegion.VerticalScrollbarBackgroundType; }
            set { ScrollableRegion.VerticalScrollbarBackgroundType = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBackgroundPreserveAspectProperty = ScrollableRegion.VerticalScrollbarBackgroundPreserveAspectProperty;
        public System.Boolean VerticalScrollbarBackgroundPreserveAspect
        {
            get { return ScrollableRegion.VerticalScrollbarBackgroundPreserveAspect; }
            set { ScrollableRegion.VerticalScrollbarBackgroundPreserveAspect = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBackgroundFillCenterProperty = ScrollableRegion.VerticalScrollbarBackgroundFillCenterProperty;
        public System.Boolean VerticalScrollbarBackgroundFillCenter
        {
            get { return ScrollableRegion.VerticalScrollbarBackgroundFillCenter; }
            set { ScrollableRegion.VerticalScrollbarBackgroundFillCenter = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBackgroundFillMethodProperty = ScrollableRegion.VerticalScrollbarBackgroundFillMethodProperty;
        public UnityEngine.UI.Image.FillMethod VerticalScrollbarBackgroundFillMethod
        {
            get { return ScrollableRegion.VerticalScrollbarBackgroundFillMethod; }
            set { ScrollableRegion.VerticalScrollbarBackgroundFillMethod = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBackgroundFillAmountProperty = ScrollableRegion.VerticalScrollbarBackgroundFillAmountProperty;
        public System.Single VerticalScrollbarBackgroundFillAmount
        {
            get { return ScrollableRegion.VerticalScrollbarBackgroundFillAmount; }
            set { ScrollableRegion.VerticalScrollbarBackgroundFillAmount = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBackgroundFillClockwiseProperty = ScrollableRegion.VerticalScrollbarBackgroundFillClockwiseProperty;
        public System.Boolean VerticalScrollbarBackgroundFillClockwise
        {
            get { return ScrollableRegion.VerticalScrollbarBackgroundFillClockwise; }
            set { ScrollableRegion.VerticalScrollbarBackgroundFillClockwise = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBackgroundFillOriginProperty = ScrollableRegion.VerticalScrollbarBackgroundFillOriginProperty;
        public System.Int32 VerticalScrollbarBackgroundFillOrigin
        {
            get { return ScrollableRegion.VerticalScrollbarBackgroundFillOrigin; }
            set { ScrollableRegion.VerticalScrollbarBackgroundFillOrigin = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBackgroundAlphaHitTestMinimumThresholdProperty = ScrollableRegion.VerticalScrollbarBackgroundAlphaHitTestMinimumThresholdProperty;
        public System.Single VerticalScrollbarBackgroundAlphaHitTestMinimumThreshold
        {
            get { return ScrollableRegion.VerticalScrollbarBackgroundAlphaHitTestMinimumThreshold; }
            set { ScrollableRegion.VerticalScrollbarBackgroundAlphaHitTestMinimumThreshold = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBackgroundUseSpriteMeshProperty = ScrollableRegion.VerticalScrollbarBackgroundUseSpriteMeshProperty;
        public System.Boolean VerticalScrollbarBackgroundUseSpriteMesh
        {
            get { return ScrollableRegion.VerticalScrollbarBackgroundUseSpriteMesh; }
            set { ScrollableRegion.VerticalScrollbarBackgroundUseSpriteMesh = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBackgroundMaterialProperty = ScrollableRegion.VerticalScrollbarBackgroundMaterialProperty;
        public MaterialAsset VerticalScrollbarBackgroundMaterial
        {
            get { return ScrollableRegion.VerticalScrollbarBackgroundMaterial; }
            set { ScrollableRegion.VerticalScrollbarBackgroundMaterial = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBackgroundOnCullStateChangedProperty = ScrollableRegion.VerticalScrollbarBackgroundOnCullStateChangedProperty;
        public UnityEngine.UI.MaskableGraphic.CullStateChangedEvent VerticalScrollbarBackgroundOnCullStateChanged
        {
            get { return ScrollableRegion.VerticalScrollbarBackgroundOnCullStateChanged; }
            set { ScrollableRegion.VerticalScrollbarBackgroundOnCullStateChanged = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBackgroundMaskableProperty = ScrollableRegion.VerticalScrollbarBackgroundMaskableProperty;
        public System.Boolean VerticalScrollbarBackgroundMaskable
        {
            get { return ScrollableRegion.VerticalScrollbarBackgroundMaskable; }
            set { ScrollableRegion.VerticalScrollbarBackgroundMaskable = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBackgroundColorProperty = ScrollableRegion.VerticalScrollbarBackgroundColorProperty;
        public UnityEngine.Color VerticalScrollbarBackgroundColor
        {
            get { return ScrollableRegion.VerticalScrollbarBackgroundColor; }
            set { ScrollableRegion.VerticalScrollbarBackgroundColor = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBackgroundRaycastTargetProperty = ScrollableRegion.VerticalScrollbarBackgroundRaycastTargetProperty;
        public System.Boolean VerticalScrollbarBackgroundRaycastTarget
        {
            get { return ScrollableRegion.VerticalScrollbarBackgroundRaycastTarget; }
            set { ScrollableRegion.VerticalScrollbarBackgroundRaycastTarget = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarWidthProperty = ScrollableRegion.VerticalScrollbarWidthProperty;
        public Delight.ElementSize VerticalScrollbarWidth
        {
            get { return ScrollableRegion.VerticalScrollbarWidth; }
            set { ScrollableRegion.VerticalScrollbarWidth = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHeightProperty = ScrollableRegion.VerticalScrollbarHeightProperty;
        public Delight.ElementSize VerticalScrollbarHeight
        {
            get { return ScrollableRegion.VerticalScrollbarHeight; }
            set { ScrollableRegion.VerticalScrollbarHeight = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarOverrideWidthProperty = ScrollableRegion.VerticalScrollbarOverrideWidthProperty;
        public Delight.ElementSize VerticalScrollbarOverrideWidth
        {
            get { return ScrollableRegion.VerticalScrollbarOverrideWidth; }
            set { ScrollableRegion.VerticalScrollbarOverrideWidth = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarOverrideHeightProperty = ScrollableRegion.VerticalScrollbarOverrideHeightProperty;
        public Delight.ElementSize VerticalScrollbarOverrideHeight
        {
            get { return ScrollableRegion.VerticalScrollbarOverrideHeight; }
            set { ScrollableRegion.VerticalScrollbarOverrideHeight = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarScaleProperty = ScrollableRegion.VerticalScrollbarScaleProperty;
        public UnityEngine.Vector3 VerticalScrollbarScale
        {
            get { return ScrollableRegion.VerticalScrollbarScale; }
            set { ScrollableRegion.VerticalScrollbarScale = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarAlignmentProperty = ScrollableRegion.VerticalScrollbarAlignmentProperty;
        public Delight.ElementAlignment VerticalScrollbarAlignment
        {
            get { return ScrollableRegion.VerticalScrollbarAlignment; }
            set { ScrollableRegion.VerticalScrollbarAlignment = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarMarginProperty = ScrollableRegion.VerticalScrollbarMarginProperty;
        public Delight.ElementMargin VerticalScrollbarMargin
        {
            get { return ScrollableRegion.VerticalScrollbarMargin; }
            set { ScrollableRegion.VerticalScrollbarMargin = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarOffsetProperty = ScrollableRegion.VerticalScrollbarOffsetProperty;
        public Delight.ElementMargin VerticalScrollbarOffset
        {
            get { return ScrollableRegion.VerticalScrollbarOffset; }
            set { ScrollableRegion.VerticalScrollbarOffset = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarOffsetFromParentProperty = ScrollableRegion.VerticalScrollbarOffsetFromParentProperty;
        public Delight.ElementMargin VerticalScrollbarOffsetFromParent
        {
            get { return ScrollableRegion.VerticalScrollbarOffsetFromParent; }
            set { ScrollableRegion.VerticalScrollbarOffsetFromParent = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarPivotProperty = ScrollableRegion.VerticalScrollbarPivotProperty;
        public UnityEngine.Vector2 VerticalScrollbarPivot
        {
            get { return ScrollableRegion.VerticalScrollbarPivot; }
            set { ScrollableRegion.VerticalScrollbarPivot = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarLayoutRootProperty = ScrollableRegion.VerticalScrollbarLayoutRootProperty;
        public Delight.LayoutRoot VerticalScrollbarLayoutRoot
        {
            get { return ScrollableRegion.VerticalScrollbarLayoutRoot; }
            set { ScrollableRegion.VerticalScrollbarLayoutRoot = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarDisableLayoutUpdateProperty = ScrollableRegion.VerticalScrollbarDisableLayoutUpdateProperty;
        public System.Boolean VerticalScrollbarDisableLayoutUpdate
        {
            get { return ScrollableRegion.VerticalScrollbarDisableLayoutUpdate; }
            set { ScrollableRegion.VerticalScrollbarDisableLayoutUpdate = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarAlphaProperty = ScrollableRegion.VerticalScrollbarAlphaProperty;
        public System.Single VerticalScrollbarAlpha
        {
            get { return ScrollableRegion.VerticalScrollbarAlpha; }
            set { ScrollableRegion.VerticalScrollbarAlpha = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarIsVisibleProperty = ScrollableRegion.VerticalScrollbarIsVisibleProperty;
        public System.Boolean VerticalScrollbarIsVisible
        {
            get { return ScrollableRegion.VerticalScrollbarIsVisible; }
            set { ScrollableRegion.VerticalScrollbarIsVisible = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarRaycastBlockModeProperty = ScrollableRegion.VerticalScrollbarRaycastBlockModeProperty;
        public Delight.RaycastBlockMode VerticalScrollbarRaycastBlockMode
        {
            get { return ScrollableRegion.VerticalScrollbarRaycastBlockMode; }
            set { ScrollableRegion.VerticalScrollbarRaycastBlockMode = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarUseFastShaderProperty = ScrollableRegion.VerticalScrollbarUseFastShaderProperty;
        public System.Boolean VerticalScrollbarUseFastShader
        {
            get { return ScrollableRegion.VerticalScrollbarUseFastShader; }
            set { ScrollableRegion.VerticalScrollbarUseFastShader = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBubbleNotifyChildLayoutChangedProperty = ScrollableRegion.VerticalScrollbarBubbleNotifyChildLayoutChangedProperty;
        public System.Boolean VerticalScrollbarBubbleNotifyChildLayoutChanged
        {
            get { return ScrollableRegion.VerticalScrollbarBubbleNotifyChildLayoutChanged; }
            set { ScrollableRegion.VerticalScrollbarBubbleNotifyChildLayoutChanged = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarIgnoreFlipProperty = ScrollableRegion.VerticalScrollbarIgnoreFlipProperty;
        public System.Boolean VerticalScrollbarIgnoreFlip
        {
            get { return ScrollableRegion.VerticalScrollbarIgnoreFlip; }
            set { ScrollableRegion.VerticalScrollbarIgnoreFlip = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarGameObjectProperty = ScrollableRegion.VerticalScrollbarGameObjectProperty;
        public UnityEngine.GameObject VerticalScrollbarGameObject
        {
            get { return ScrollableRegion.VerticalScrollbarGameObject; }
            set { ScrollableRegion.VerticalScrollbarGameObject = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarEnableScriptEventsProperty = ScrollableRegion.VerticalScrollbarEnableScriptEventsProperty;
        public System.Boolean VerticalScrollbarEnableScriptEvents
        {
            get { return ScrollableRegion.VerticalScrollbarEnableScriptEvents; }
            set { ScrollableRegion.VerticalScrollbarEnableScriptEvents = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarIgnoreObjectProperty = ScrollableRegion.VerticalScrollbarIgnoreObjectProperty;
        public System.Boolean VerticalScrollbarIgnoreObject
        {
            get { return ScrollableRegion.VerticalScrollbarIgnoreObject; }
            set { ScrollableRegion.VerticalScrollbarIgnoreObject = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarIsActiveProperty = ScrollableRegion.VerticalScrollbarIsActiveProperty;
        public System.Boolean VerticalScrollbarIsActive
        {
            get { return ScrollableRegion.VerticalScrollbarIsActive; }
            set { ScrollableRegion.VerticalScrollbarIsActive = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarLoadModeProperty = ScrollableRegion.VerticalScrollbarLoadModeProperty;
        public Delight.LoadMode VerticalScrollbarLoadMode
        {
            get { return ScrollableRegion.VerticalScrollbarLoadMode; }
            set { ScrollableRegion.VerticalScrollbarLoadMode = value; }
        }

        public readonly static DependencyProperty RenderCameraProperty = ScrollableRegion.RenderCameraProperty;
        public System.String RenderCamera
        {
            get { return ScrollableRegion.RenderCamera; }
            set { ScrollableRegion.RenderCamera = value; }
        }

        public readonly static DependencyProperty RenderModeProperty = ScrollableRegion.RenderModeProperty;
        public UnityEngine.RenderMode RenderMode
        {
            get { return ScrollableRegion.RenderMode; }
            set { ScrollableRegion.RenderMode = value; }
        }

        public readonly static DependencyProperty ScaleFactorProperty = ScrollableRegion.ScaleFactorProperty;
        public System.Single ScaleFactor
        {
            get { return ScrollableRegion.ScaleFactor; }
            set { ScrollableRegion.ScaleFactor = value; }
        }

        public readonly static DependencyProperty ReferencePixelsPerUnitProperty = ScrollableRegion.ReferencePixelsPerUnitProperty;
        public System.Single ReferencePixelsPerUnit
        {
            get { return ScrollableRegion.ReferencePixelsPerUnit; }
            set { ScrollableRegion.ReferencePixelsPerUnit = value; }
        }

        public readonly static DependencyProperty OverridePixelPerfectProperty = ScrollableRegion.OverridePixelPerfectProperty;
        public System.Boolean OverridePixelPerfect
        {
            get { return ScrollableRegion.OverridePixelPerfect; }
            set { ScrollableRegion.OverridePixelPerfect = value; }
        }

        public readonly static DependencyProperty PixelPerfectProperty = ScrollableRegion.PixelPerfectProperty;
        public System.Boolean PixelPerfect
        {
            get { return ScrollableRegion.PixelPerfect; }
            set { ScrollableRegion.PixelPerfect = value; }
        }

        public readonly static DependencyProperty PlaneDistanceProperty = ScrollableRegion.PlaneDistanceProperty;
        public System.Single PlaneDistance
        {
            get { return ScrollableRegion.PlaneDistance; }
            set { ScrollableRegion.PlaneDistance = value; }
        }

        public readonly static DependencyProperty OverrideSortingProperty = ScrollableRegion.OverrideSortingProperty;
        public System.Boolean OverrideSorting
        {
            get { return ScrollableRegion.OverrideSorting; }
            set { ScrollableRegion.OverrideSorting = value; }
        }

        public readonly static DependencyProperty SortingOrderProperty = ScrollableRegion.SortingOrderProperty;
        public System.Int32 SortingOrder
        {
            get { return ScrollableRegion.SortingOrder; }
            set { ScrollableRegion.SortingOrder = value; }
        }

        public readonly static DependencyProperty TargetDisplayProperty = ScrollableRegion.TargetDisplayProperty;
        public System.Int32 TargetDisplay
        {
            get { return ScrollableRegion.TargetDisplay; }
            set { ScrollableRegion.TargetDisplay = value; }
        }

        public readonly static DependencyProperty SortingLayerIDProperty = ScrollableRegion.SortingLayerIDProperty;
        public System.Int32 SortingLayerID
        {
            get { return ScrollableRegion.SortingLayerID; }
            set { ScrollableRegion.SortingLayerID = value; }
        }

        public readonly static DependencyProperty AdditionalShaderChannelsProperty = ScrollableRegion.AdditionalShaderChannelsProperty;
        public UnityEngine.AdditionalCanvasShaderChannels AdditionalShaderChannels
        {
            get { return ScrollableRegion.AdditionalShaderChannels; }
            set { ScrollableRegion.AdditionalShaderChannels = value; }
        }

        public readonly static DependencyProperty SortingLayerNameProperty = ScrollableRegion.SortingLayerNameProperty;
        public System.String SortingLayerName
        {
            get { return ScrollableRegion.SortingLayerName; }
            set { ScrollableRegion.SortingLayerName = value; }
        }

        public readonly static DependencyProperty WorldCameraProperty = ScrollableRegion.WorldCameraProperty;
        public UnityEngine.Camera WorldCamera
        {
            get { return ScrollableRegion.WorldCamera; }
            set { ScrollableRegion.WorldCamera = value; }
        }

        public readonly static DependencyProperty NormalizedSortingGridSizeProperty = ScrollableRegion.NormalizedSortingGridSizeProperty;
        public System.Single NormalizedSortingGridSize
        {
            get { return ScrollableRegion.NormalizedSortingGridSize; }
            set { ScrollableRegion.NormalizedSortingGridSize = value; }
        }

        public readonly static DependencyProperty UiScaleModeProperty = ScrollableRegion.UiScaleModeProperty;
        public UnityEngine.UI.CanvasScaler.ScaleMode UiScaleMode
        {
            get { return ScrollableRegion.UiScaleMode; }
            set { ScrollableRegion.UiScaleMode = value; }
        }

        public readonly static DependencyProperty CanvasScalerReferencePixelsPerUnitProperty = ScrollableRegion.CanvasScalerReferencePixelsPerUnitProperty;
        public System.Single CanvasScalerReferencePixelsPerUnit
        {
            get { return ScrollableRegion.CanvasScalerReferencePixelsPerUnit; }
            set { ScrollableRegion.CanvasScalerReferencePixelsPerUnit = value; }
        }

        public readonly static DependencyProperty CanvasScalerScaleFactorProperty = ScrollableRegion.CanvasScalerScaleFactorProperty;
        public System.Single CanvasScalerScaleFactor
        {
            get { return ScrollableRegion.CanvasScalerScaleFactor; }
            set { ScrollableRegion.CanvasScalerScaleFactor = value; }
        }

        public readonly static DependencyProperty ReferenceResolutionProperty = ScrollableRegion.ReferenceResolutionProperty;
        public UnityEngine.Vector2 ReferenceResolution
        {
            get { return ScrollableRegion.ReferenceResolution; }
            set { ScrollableRegion.ReferenceResolution = value; }
        }

        public readonly static DependencyProperty ScreenMatchModeProperty = ScrollableRegion.ScreenMatchModeProperty;
        public UnityEngine.UI.CanvasScaler.ScreenMatchMode ScreenMatchMode
        {
            get { return ScrollableRegion.ScreenMatchMode; }
            set { ScrollableRegion.ScreenMatchMode = value; }
        }

        public readonly static DependencyProperty MatchWidthOrHeightProperty = ScrollableRegion.MatchWidthOrHeightProperty;
        public System.Single MatchWidthOrHeight
        {
            get { return ScrollableRegion.MatchWidthOrHeight; }
            set { ScrollableRegion.MatchWidthOrHeight = value; }
        }

        public readonly static DependencyProperty PhysicalUnitProperty = ScrollableRegion.PhysicalUnitProperty;
        public UnityEngine.UI.CanvasScaler.Unit PhysicalUnit
        {
            get { return ScrollableRegion.PhysicalUnit; }
            set { ScrollableRegion.PhysicalUnit = value; }
        }

        public readonly static DependencyProperty FallbackScreenDPIProperty = ScrollableRegion.FallbackScreenDPIProperty;
        public System.Single FallbackScreenDPI
        {
            get { return ScrollableRegion.FallbackScreenDPI; }
            set { ScrollableRegion.FallbackScreenDPI = value; }
        }

        public readonly static DependencyProperty DefaultSpriteDPIProperty = ScrollableRegion.DefaultSpriteDPIProperty;
        public System.Single DefaultSpriteDPI
        {
            get { return ScrollableRegion.DefaultSpriteDPI; }
            set { ScrollableRegion.DefaultSpriteDPI = value; }
        }

        public readonly static DependencyProperty DynamicPixelsPerUnitProperty = ScrollableRegion.DynamicPixelsPerUnitProperty;
        public System.Single DynamicPixelsPerUnit
        {
            get { return ScrollableRegion.DynamicPixelsPerUnit; }
            set { ScrollableRegion.DynamicPixelsPerUnit = value; }
        }

        public readonly static DependencyProperty IgnoreReversedGraphicsProperty = ScrollableRegion.IgnoreReversedGraphicsProperty;
        public System.Boolean IgnoreReversedGraphics
        {
            get { return ScrollableRegion.IgnoreReversedGraphics; }
            set { ScrollableRegion.IgnoreReversedGraphics = value; }
        }

        public readonly static DependencyProperty BlockingObjectsProperty = ScrollableRegion.BlockingObjectsProperty;
        public UnityEngine.UI.GraphicRaycaster.BlockingObjects BlockingObjects
        {
            get { return ScrollableRegion.BlockingObjects; }
            set { ScrollableRegion.BlockingObjects = value; }
        }

        public readonly static DependencyProperty ScrollableRegionWidthProperty = ScrollableRegion.WidthProperty;
        public Delight.ElementSize ScrollableRegionWidth
        {
            get { return ScrollableRegion.Width; }
            set { ScrollableRegion.Width = value; }
        }

        public readonly static DependencyProperty ScrollableRegionHeightProperty = ScrollableRegion.HeightProperty;
        public Delight.ElementSize ScrollableRegionHeight
        {
            get { return ScrollableRegion.Height; }
            set { ScrollableRegion.Height = value; }
        }

        public readonly static DependencyProperty ScrollableRegionOverrideWidthProperty = ScrollableRegion.OverrideWidthProperty;
        public Delight.ElementSize ScrollableRegionOverrideWidth
        {
            get { return ScrollableRegion.OverrideWidth; }
            set { ScrollableRegion.OverrideWidth = value; }
        }

        public readonly static DependencyProperty ScrollableRegionOverrideHeightProperty = ScrollableRegion.OverrideHeightProperty;
        public Delight.ElementSize ScrollableRegionOverrideHeight
        {
            get { return ScrollableRegion.OverrideHeight; }
            set { ScrollableRegion.OverrideHeight = value; }
        }

        public readonly static DependencyProperty ScrollableRegionScaleProperty = ScrollableRegion.ScaleProperty;
        public UnityEngine.Vector3 ScrollableRegionScale
        {
            get { return ScrollableRegion.Scale; }
            set { ScrollableRegion.Scale = value; }
        }

        public readonly static DependencyProperty ScrollableRegionAlignmentProperty = ScrollableRegion.AlignmentProperty;
        public Delight.ElementAlignment ScrollableRegionAlignment
        {
            get { return ScrollableRegion.Alignment; }
            set { ScrollableRegion.Alignment = value; }
        }

        public readonly static DependencyProperty ScrollableRegionMarginProperty = ScrollableRegion.MarginProperty;
        public Delight.ElementMargin ScrollableRegionMargin
        {
            get { return ScrollableRegion.Margin; }
            set { ScrollableRegion.Margin = value; }
        }

        public readonly static DependencyProperty ScrollableRegionOffsetProperty = ScrollableRegion.OffsetProperty;
        public Delight.ElementMargin ScrollableRegionOffset
        {
            get { return ScrollableRegion.Offset; }
            set { ScrollableRegion.Offset = value; }
        }

        public readonly static DependencyProperty ScrollableRegionOffsetFromParentProperty = ScrollableRegion.OffsetFromParentProperty;
        public Delight.ElementMargin ScrollableRegionOffsetFromParent
        {
            get { return ScrollableRegion.OffsetFromParent; }
            set { ScrollableRegion.OffsetFromParent = value; }
        }

        public readonly static DependencyProperty ScrollableRegionPivotProperty = ScrollableRegion.PivotProperty;
        public UnityEngine.Vector2 ScrollableRegionPivot
        {
            get { return ScrollableRegion.Pivot; }
            set { ScrollableRegion.Pivot = value; }
        }

        public readonly static DependencyProperty ScrollableRegionLayoutRootProperty = ScrollableRegion.LayoutRootProperty;
        public Delight.LayoutRoot ScrollableRegionLayoutRoot
        {
            get { return ScrollableRegion.LayoutRoot; }
            set { ScrollableRegion.LayoutRoot = value; }
        }

        public readonly static DependencyProperty ScrollableRegionDisableLayoutUpdateProperty = ScrollableRegion.DisableLayoutUpdateProperty;
        public System.Boolean ScrollableRegionDisableLayoutUpdate
        {
            get { return ScrollableRegion.DisableLayoutUpdate; }
            set { ScrollableRegion.DisableLayoutUpdate = value; }
        }

        public readonly static DependencyProperty ScrollableRegionAlphaProperty = ScrollableRegion.AlphaProperty;
        public System.Single ScrollableRegionAlpha
        {
            get { return ScrollableRegion.Alpha; }
            set { ScrollableRegion.Alpha = value; }
        }

        public readonly static DependencyProperty ScrollableRegionIsVisibleProperty = ScrollableRegion.IsVisibleProperty;
        public System.Boolean ScrollableRegionIsVisible
        {
            get { return ScrollableRegion.IsVisible; }
            set { ScrollableRegion.IsVisible = value; }
        }

        public readonly static DependencyProperty ScrollableRegionRaycastBlockModeProperty = ScrollableRegion.RaycastBlockModeProperty;
        public Delight.RaycastBlockMode ScrollableRegionRaycastBlockMode
        {
            get { return ScrollableRegion.RaycastBlockMode; }
            set { ScrollableRegion.RaycastBlockMode = value; }
        }

        public readonly static DependencyProperty ScrollableRegionUseFastShaderProperty = ScrollableRegion.UseFastShaderProperty;
        public System.Boolean ScrollableRegionUseFastShader
        {
            get { return ScrollableRegion.UseFastShader; }
            set { ScrollableRegion.UseFastShader = value; }
        }

        public readonly static DependencyProperty ScrollableRegionBubbleNotifyChildLayoutChangedProperty = ScrollableRegion.BubbleNotifyChildLayoutChangedProperty;
        public System.Boolean ScrollableRegionBubbleNotifyChildLayoutChanged
        {
            get { return ScrollableRegion.BubbleNotifyChildLayoutChanged; }
            set { ScrollableRegion.BubbleNotifyChildLayoutChanged = value; }
        }

        public readonly static DependencyProperty ScrollableRegionIgnoreFlipProperty = ScrollableRegion.IgnoreFlipProperty;
        public System.Boolean ScrollableRegionIgnoreFlip
        {
            get { return ScrollableRegion.IgnoreFlip; }
            set { ScrollableRegion.IgnoreFlip = value; }
        }

        public readonly static DependencyProperty ScrollableRegionGameObjectProperty = ScrollableRegion.GameObjectProperty;
        public UnityEngine.GameObject ScrollableRegionGameObject
        {
            get { return ScrollableRegion.GameObject; }
            set { ScrollableRegion.GameObject = value; }
        }

        public readonly static DependencyProperty ScrollableRegionEnableScriptEventsProperty = ScrollableRegion.EnableScriptEventsProperty;
        public System.Boolean ScrollableRegionEnableScriptEvents
        {
            get { return ScrollableRegion.EnableScriptEvents; }
            set { ScrollableRegion.EnableScriptEvents = value; }
        }

        public readonly static DependencyProperty ScrollableRegionIgnoreObjectProperty = ScrollableRegion.IgnoreObjectProperty;
        public System.Boolean ScrollableRegionIgnoreObject
        {
            get { return ScrollableRegion.IgnoreObject; }
            set { ScrollableRegion.IgnoreObject = value; }
        }

        public readonly static DependencyProperty ScrollableRegionIsActiveProperty = ScrollableRegion.IsActiveProperty;
        public System.Boolean ScrollableRegionIsActive
        {
            get { return ScrollableRegion.IsActive; }
            set { ScrollableRegion.IsActive = value; }
        }

        public readonly static DependencyProperty ScrollableRegionLoadModeProperty = ScrollableRegion.LoadModeProperty;
        public Delight.LoadMode ScrollableRegionLoadMode
        {
            get { return ScrollableRegion.LoadMode; }
            set { ScrollableRegion.LoadMode = value; }
        }

        #endregion
    }

    #region Data Templates

    public static class ListTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return List;
            }
        }

        private static Template _list;
        public static Template List
        {
            get
            {
#if UNITY_EDITOR
                if (_list == null || _list.CurrentVersion != Template.Version)
#else
                if (_list == null)
#endif
                {
                    _list = new Template(CollectionTemplates.Collection);
#if UNITY_EDITOR
                    _list.Name = "List";
#endif
                    Delight.List.CanSelectProperty.SetDefault(_list, true);
                    Delight.List.ScrollableRegionTemplateProperty.SetDefault(_list, ListScrollableRegion);
                }
                return _list;
            }
        }

        private static Template _listScrollableRegion;
        public static Template ListScrollableRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_listScrollableRegion == null || _listScrollableRegion.CurrentVersion != Template.Version)
#else
                if (_listScrollableRegion == null)
#endif
                {
                    _listScrollableRegion = new Template(ScrollableRegionTemplates.ScrollableRegion);
#if UNITY_EDITOR
                    _listScrollableRegion.Name = "ListScrollableRegion";
#endif
                    Delight.ScrollableRegion.MaskContentProperty.SetDefault(_listScrollableRegion, true);
                    Delight.ScrollableRegion.BubbleNotifyChildLayoutChangedProperty.SetDefault(_listScrollableRegion, true);
                    Delight.ScrollableRegion.AutoSizeContentRegionProperty.SetDefault(_listScrollableRegion, false);
                    Delight.ScrollableRegion.ContentRegionTemplateProperty.SetDefault(_listScrollableRegion, ListScrollableRegionContentRegion);
                    Delight.ScrollableRegion.HorizontalScrollbarTemplateProperty.SetDefault(_listScrollableRegion, ListScrollableRegionHorizontalScrollbar);
                    Delight.ScrollableRegion.VerticalScrollbarTemplateProperty.SetDefault(_listScrollableRegion, ListScrollableRegionVerticalScrollbar);
                }
                return _listScrollableRegion;
            }
        }

        private static Template _listScrollableRegionContentRegion;
        public static Template ListScrollableRegionContentRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_listScrollableRegionContentRegion == null || _listScrollableRegionContentRegion.CurrentVersion != Template.Version)
#else
                if (_listScrollableRegionContentRegion == null)
#endif
                {
                    _listScrollableRegionContentRegion = new Template(ScrollableRegionTemplates.ScrollableRegionContentRegion);
#if UNITY_EDITOR
                    _listScrollableRegionContentRegion.Name = "ListScrollableRegionContentRegion";
#endif
                }
                return _listScrollableRegionContentRegion;
            }
        }

        private static Template _listScrollableRegionHorizontalScrollbar;
        public static Template ListScrollableRegionHorizontalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_listScrollableRegionHorizontalScrollbar == null || _listScrollableRegionHorizontalScrollbar.CurrentVersion != Template.Version)
#else
                if (_listScrollableRegionHorizontalScrollbar == null)
#endif
                {
                    _listScrollableRegionHorizontalScrollbar = new Template(ScrollableRegionTemplates.ScrollableRegionHorizontalScrollbar);
#if UNITY_EDITOR
                    _listScrollableRegionHorizontalScrollbar.Name = "ListScrollableRegionHorizontalScrollbar";
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_listScrollableRegionHorizontalScrollbar, ListScrollableRegionHorizontalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_listScrollableRegionHorizontalScrollbar, ListScrollableRegionHorizontalScrollbarHandle);
                }
                return _listScrollableRegionHorizontalScrollbar;
            }
        }

        private static Template _listScrollableRegionHorizontalScrollbarBar;
        public static Template ListScrollableRegionHorizontalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_listScrollableRegionHorizontalScrollbarBar == null || _listScrollableRegionHorizontalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_listScrollableRegionHorizontalScrollbarBar == null)
#endif
                {
                    _listScrollableRegionHorizontalScrollbarBar = new Template(ScrollableRegionTemplates.ScrollableRegionHorizontalScrollbarBar);
#if UNITY_EDITOR
                    _listScrollableRegionHorizontalScrollbarBar.Name = "ListScrollableRegionHorizontalScrollbarBar";
#endif
                }
                return _listScrollableRegionHorizontalScrollbarBar;
            }
        }

        private static Template _listScrollableRegionHorizontalScrollbarHandle;
        public static Template ListScrollableRegionHorizontalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_listScrollableRegionHorizontalScrollbarHandle == null || _listScrollableRegionHorizontalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_listScrollableRegionHorizontalScrollbarHandle == null)
#endif
                {
                    _listScrollableRegionHorizontalScrollbarHandle = new Template(ScrollableRegionTemplates.ScrollableRegionHorizontalScrollbarHandle);
#if UNITY_EDITOR
                    _listScrollableRegionHorizontalScrollbarHandle.Name = "ListScrollableRegionHorizontalScrollbarHandle";
#endif
                }
                return _listScrollableRegionHorizontalScrollbarHandle;
            }
        }

        private static Template _listScrollableRegionVerticalScrollbar;
        public static Template ListScrollableRegionVerticalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_listScrollableRegionVerticalScrollbar == null || _listScrollableRegionVerticalScrollbar.CurrentVersion != Template.Version)
#else
                if (_listScrollableRegionVerticalScrollbar == null)
#endif
                {
                    _listScrollableRegionVerticalScrollbar = new Template(ScrollableRegionTemplates.ScrollableRegionVerticalScrollbar);
#if UNITY_EDITOR
                    _listScrollableRegionVerticalScrollbar.Name = "ListScrollableRegionVerticalScrollbar";
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_listScrollableRegionVerticalScrollbar, ListScrollableRegionVerticalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_listScrollableRegionVerticalScrollbar, ListScrollableRegionVerticalScrollbarHandle);
                }
                return _listScrollableRegionVerticalScrollbar;
            }
        }

        private static Template _listScrollableRegionVerticalScrollbarBar;
        public static Template ListScrollableRegionVerticalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_listScrollableRegionVerticalScrollbarBar == null || _listScrollableRegionVerticalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_listScrollableRegionVerticalScrollbarBar == null)
#endif
                {
                    _listScrollableRegionVerticalScrollbarBar = new Template(ScrollableRegionTemplates.ScrollableRegionVerticalScrollbarBar);
#if UNITY_EDITOR
                    _listScrollableRegionVerticalScrollbarBar.Name = "ListScrollableRegionVerticalScrollbarBar";
#endif
                }
                return _listScrollableRegionVerticalScrollbarBar;
            }
        }

        private static Template _listScrollableRegionVerticalScrollbarHandle;
        public static Template ListScrollableRegionVerticalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_listScrollableRegionVerticalScrollbarHandle == null || _listScrollableRegionVerticalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_listScrollableRegionVerticalScrollbarHandle == null)
#endif
                {
                    _listScrollableRegionVerticalScrollbarHandle = new Template(ScrollableRegionTemplates.ScrollableRegionVerticalScrollbarHandle);
#if UNITY_EDITOR
                    _listScrollableRegionVerticalScrollbarHandle.Name = "ListScrollableRegionVerticalScrollbarHandle";
#endif
                }
                return _listScrollableRegionVerticalScrollbarHandle;
            }
        }

        #endregion
    }

    #endregion
}
