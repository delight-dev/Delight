// Internal view logic generated from "ComboBox.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class ComboBox : UIView
    {
        #region Constructors

        public ComboBox(View parent, View layoutParent = null, string id = null, Template template = null, bool deferInitialization = false) :
            base(parent, layoutParent, id, template ?? ComboBoxTemplates.Default, deferInitialization)
        {
            if (deferInitialization)
                return;

            // constructing Button (ComboBoxButton)
            ComboBoxButton = new Button(this, this, "ComboBoxButton", ComboBoxButtonTemplate);
            ComboBoxButton.Click.RegisterHandler(this, "ComboBoxButtonClick");

            // constructing UICanvas (ComboBoxListCanvas)
            ComboBoxListCanvas = new UICanvas(this, this, "ComboBoxListCanvas", ComboBoxListCanvasTemplate);
            ComboBoxList = new List(this, ComboBoxListCanvas.Content, "ComboBoxList", ComboBoxListTemplate);
            ComboBoxList.ItemSelected.RegisterHandler(this, "ComboBoxListSelectionChanged");
            ContentContainer = ComboBoxList;
            this.AfterInitializeInternal();
        }

        public ComboBox() : this(null)
        {
        }

        static ComboBox()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(ComboBoxTemplates.Default, dependencyProperties);

            dependencyProperties.Add(IsDropUpProperty);
            dependencyProperties.Add(ItemSelectedProperty);
            dependencyProperties.Add(ComboBoxButtonProperty);
            dependencyProperties.Add(ComboBoxButtonTemplateProperty);
            dependencyProperties.Add(ComboBoxListCanvasProperty);
            dependencyProperties.Add(ComboBoxListCanvasTemplateProperty);
            dependencyProperties.Add(ComboBoxListProperty);
            dependencyProperties.Add(ComboBoxListTemplateProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<System.Boolean> IsDropUpProperty = new DependencyProperty<System.Boolean>("IsDropUp");
        public System.Boolean IsDropUp
        {
            get { return IsDropUpProperty.GetValue(this); }
            set { IsDropUpProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ViewAction> ItemSelectedProperty = new DependencyProperty<ViewAction>("ItemSelected", () => new ViewAction());
        public ViewAction ItemSelected
        {
            get { return ItemSelectedProperty.GetValue(this); }
            set { ItemSelectedProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Button> ComboBoxButtonProperty = new DependencyProperty<Button>("ComboBoxButton");
        public Button ComboBoxButton
        {
            get { return ComboBoxButtonProperty.GetValue(this); }
            set { ComboBoxButtonProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> ComboBoxButtonTemplateProperty = new DependencyProperty<Template>("ComboBoxButtonTemplate");
        public Template ComboBoxButtonTemplate
        {
            get { return ComboBoxButtonTemplateProperty.GetValue(this); }
            set { ComboBoxButtonTemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<UICanvas> ComboBoxListCanvasProperty = new DependencyProperty<UICanvas>("ComboBoxListCanvas");
        public UICanvas ComboBoxListCanvas
        {
            get { return ComboBoxListCanvasProperty.GetValue(this); }
            set { ComboBoxListCanvasProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> ComboBoxListCanvasTemplateProperty = new DependencyProperty<Template>("ComboBoxListCanvasTemplate");
        public Template ComboBoxListCanvasTemplate
        {
            get { return ComboBoxListCanvasTemplateProperty.GetValue(this); }
            set { ComboBoxListCanvasTemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<List> ComboBoxListProperty = new DependencyProperty<List>("ComboBoxList");
        public List ComboBoxList
        {
            get { return ComboBoxListProperty.GetValue(this); }
            set { ComboBoxListProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> ComboBoxListTemplateProperty = new DependencyProperty<Template>("ComboBoxListTemplate");
        public Template ComboBoxListTemplate
        {
            get { return ComboBoxListTemplateProperty.GetValue(this); }
            set { ComboBoxListTemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty OrientationProperty = List.OrientationProperty;
        public Delight.ElementOrientation Orientation
        {
            get { return ComboBoxList.Orientation; }
            set { ComboBoxList.Orientation = value; }
        }

        public readonly static DependencyProperty SpacingProperty = List.SpacingProperty;
        public Delight.ElementSize Spacing
        {
            get { return ComboBoxList.Spacing; }
            set { ComboBoxList.Spacing = value; }
        }

        public readonly static DependencyProperty HorizontalSpacingProperty = List.HorizontalSpacingProperty;
        public Delight.ElementSize HorizontalSpacing
        {
            get { return ComboBoxList.HorizontalSpacing; }
            set { ComboBoxList.HorizontalSpacing = value; }
        }

        public readonly static DependencyProperty VerticalSpacingProperty = List.VerticalSpacingProperty;
        public Delight.ElementSize VerticalSpacing
        {
            get { return ComboBoxList.VerticalSpacing; }
            set { ComboBoxList.VerticalSpacing = value; }
        }

        public readonly static DependencyProperty PaddingProperty = List.PaddingProperty;
        public Delight.ElementMargin Padding
        {
            get { return ComboBoxList.Padding; }
            set { ComboBoxList.Padding = value; }
        }

        public readonly static DependencyProperty ContentAlignmentProperty = List.ContentAlignmentProperty;
        public Delight.ElementAlignment ContentAlignment
        {
            get { return ComboBoxList.ContentAlignment; }
            set { ComboBoxList.ContentAlignment = value; }
        }

        public readonly static DependencyProperty AlternateItemsProperty = List.AlternateItemsProperty;
        public System.Boolean AlternateItems
        {
            get { return ComboBoxList.AlternateItems; }
            set { ComboBoxList.AlternateItems = value; }
        }

        public readonly static DependencyProperty IsScrollableProperty = List.IsScrollableProperty;
        public System.Boolean IsScrollable
        {
            get { return ComboBoxList.IsScrollable; }
            set { ComboBoxList.IsScrollable = value; }
        }

        public readonly static DependencyProperty IsVirtualizedProperty = List.IsVirtualizedProperty;
        public System.Boolean IsVirtualized
        {
            get { return ComboBoxList.IsVirtualized; }
            set { ComboBoxList.IsVirtualized = value; }
        }

        public readonly static DependencyProperty OverflowProperty = List.OverflowProperty;
        public Delight.OverflowMode Overflow
        {
            get { return ComboBoxList.Overflow; }
            set { ComboBoxList.Overflow = value; }
        }

        public readonly static DependencyProperty SortDirectionProperty = List.SortDirectionProperty;
        public Delight.ElementSortDirection SortDirection
        {
            get { return ComboBoxList.SortDirection; }
            set { ComboBoxList.SortDirection = value; }
        }

        public readonly static DependencyProperty CanSelectProperty = List.CanSelectProperty;
        public System.Boolean CanSelect
        {
            get { return ComboBoxList.CanSelect; }
            set { ComboBoxList.CanSelect = value; }
        }

        public readonly static DependencyProperty CanDeselectProperty = List.CanDeselectProperty;
        public System.Boolean CanDeselect
        {
            get { return ComboBoxList.CanDeselect; }
            set { ComboBoxList.CanDeselect = value; }
        }

        public readonly static DependencyProperty CanMultiSelectProperty = List.CanMultiSelectProperty;
        public System.Boolean CanMultiSelect
        {
            get { return ComboBoxList.CanMultiSelect; }
            set { ComboBoxList.CanMultiSelect = value; }
        }

        public readonly static DependencyProperty CanReselectProperty = List.CanReselectProperty;
        public System.Boolean CanReselect
        {
            get { return ComboBoxList.CanReselect; }
            set { ComboBoxList.CanReselect = value; }
        }

        public readonly static DependencyProperty DeselectAfterSelectProperty = List.DeselectAfterSelectProperty;
        public System.Boolean DeselectAfterSelect
        {
            get { return ComboBoxList.DeselectAfterSelect; }
            set { ComboBoxList.DeselectAfterSelect = value; }
        }

        public readonly static DependencyProperty SelectOnMouseUpProperty = List.SelectOnMouseUpProperty;
        public System.Boolean SelectOnMouseUp
        {
            get { return ComboBoxList.SelectOnMouseUp; }
            set { ComboBoxList.SelectOnMouseUp = value; }
        }

        public readonly static DependencyProperty SelectedItemProperty = List.SelectedItemProperty;
        public Delight.BindableObject SelectedItem
        {
            get { return ComboBoxList.SelectedItem; }
            set { ComboBoxList.SelectedItem = value; }
        }

        public readonly static DependencyProperty IsStaticProperty = List.IsStaticProperty;
        public System.Boolean IsStatic
        {
            get { return ComboBoxList.IsStatic; }
            set { ComboBoxList.IsStatic = value; }
        }

        public readonly static DependencyProperty RealizationMarginProperty = List.RealizationMarginProperty;
        public UnityEngine.Vector2 RealizationMargin
        {
            get { return ComboBoxList.RealizationMargin; }
            set { ComboBoxList.RealizationMargin = value; }
        }

        public readonly static DependencyProperty DisableItemArrangementProperty = List.DisableItemArrangementProperty;
        public System.Boolean DisableItemArrangement
        {
            get { return ComboBoxList.DisableItemArrangement; }
            set { ComboBoxList.DisableItemArrangement = value; }
        }

        public readonly static DependencyProperty MaskContentProperty = List.MaskContentProperty;
        public System.Boolean MaskContent
        {
            get { return ComboBoxList.MaskContent; }
            set { ComboBoxList.MaskContent = value; }
        }

        public readonly static DependencyProperty HasInertiaProperty = List.HasInertiaProperty;
        public System.Boolean HasInertia
        {
            get { return ComboBoxList.HasInertia; }
            set { ComboBoxList.HasInertia = value; }
        }

        public readonly static DependencyProperty DecelerationRateProperty = List.DecelerationRateProperty;
        public System.Single DecelerationRate
        {
            get { return ComboBoxList.DecelerationRate; }
            set { ComboBoxList.DecelerationRate = value; }
        }

        public readonly static DependencyProperty ElasticityProperty = List.ElasticityProperty;
        public System.Single Elasticity
        {
            get { return ComboBoxList.Elasticity; }
            set { ComboBoxList.Elasticity = value; }
        }

        public readonly static DependencyProperty CanScrollHorizontallyProperty = List.CanScrollHorizontallyProperty;
        public System.Boolean CanScrollHorizontally
        {
            get { return ComboBoxList.CanScrollHorizontally; }
            set { ComboBoxList.CanScrollHorizontally = value; }
        }

        public readonly static DependencyProperty CanScrollVerticallyProperty = List.CanScrollVerticallyProperty;
        public System.Boolean CanScrollVertically
        {
            get { return ComboBoxList.CanScrollVertically; }
            set { ComboBoxList.CanScrollVertically = value; }
        }

        public readonly static DependencyProperty ScrollableRegionContentAlignmentProperty = List.ScrollableRegionContentAlignmentProperty;
        public Delight.ElementAlignment ScrollableRegionContentAlignment
        {
            get { return ComboBoxList.ScrollableRegionContentAlignment; }
            set { ComboBoxList.ScrollableRegionContentAlignment = value; }
        }

        public readonly static DependencyProperty AutoSizeContentRegionProperty = List.AutoSizeContentRegionProperty;
        public System.Boolean AutoSizeContentRegion
        {
            get { return ComboBoxList.AutoSizeContentRegion; }
            set { ComboBoxList.AutoSizeContentRegion = value; }
        }

        public readonly static DependencyProperty ScrollBoundsProperty = List.ScrollBoundsProperty;
        public Delight.ScrollBounds ScrollBounds
        {
            get { return ComboBoxList.ScrollBounds; }
            set { ComboBoxList.ScrollBounds = value; }
        }

        public readonly static DependencyProperty DebugOffsetTextProperty = List.DebugOffsetTextProperty;
        public System.String DebugOffsetText
        {
            get { return ComboBoxList.DebugOffsetText; }
            set { ComboBoxList.DebugOffsetText = value; }
        }

        public readonly static DependencyProperty DisableInteractionScrollDeltaProperty = List.DisableInteractionScrollDeltaProperty;
        public System.Single DisableInteractionScrollDelta
        {
            get { return ComboBoxList.DisableInteractionScrollDelta; }
            set { ComboBoxList.DisableInteractionScrollDelta = value; }
        }

        public readonly static DependencyProperty ScrollSensitivityProperty = List.ScrollSensitivityProperty;
        public System.Single ScrollSensitivity
        {
            get { return ComboBoxList.ScrollSensitivity; }
            set { ComboBoxList.ScrollSensitivity = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarVisibilityProperty = List.HorizontalScrollbarVisibilityProperty;
        public Delight.ScrollbarVisibilityMode HorizontalScrollbarVisibility
        {
            get { return ComboBoxList.HorizontalScrollbarVisibility; }
            set { ComboBoxList.HorizontalScrollbarVisibility = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarVisibilityProperty = List.VerticalScrollbarVisibilityProperty;
        public Delight.ScrollbarVisibilityMode VerticalScrollbarVisibility
        {
            get { return ComboBoxList.VerticalScrollbarVisibility; }
            set { ComboBoxList.VerticalScrollbarVisibility = value; }
        }

        public readonly static DependencyProperty DisableMouseWheelProperty = List.DisableMouseWheelProperty;
        public System.Boolean DisableMouseWheel
        {
            get { return ComboBoxList.DisableMouseWheel; }
            set { ComboBoxList.DisableMouseWheel = value; }
        }

        public readonly static DependencyProperty UnblockDragEventsInChildrenProperty = List.UnblockDragEventsInChildrenProperty;
        public System.Boolean UnblockDragEventsInChildren
        {
            get { return ComboBoxList.UnblockDragEventsInChildren; }
            set { ComboBoxList.UnblockDragEventsInChildren = value; }
        }

        public readonly static DependencyProperty ScrollEnabledProperty = List.ScrollEnabledProperty;
        public System.Boolean ScrollEnabled
        {
            get { return ComboBoxList.ScrollEnabled; }
            set { ComboBoxList.ScrollEnabled = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarLengthProperty = List.HorizontalScrollbarLengthProperty;
        public Delight.ElementSize HorizontalScrollbarLength
        {
            get { return ComboBoxList.HorizontalScrollbarLength; }
            set { ComboBoxList.HorizontalScrollbarLength = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBreadthProperty = List.HorizontalScrollbarBreadthProperty;
        public Delight.ElementSize HorizontalScrollbarBreadth
        {
            get { return ComboBoxList.HorizontalScrollbarBreadth; }
            set { ComboBoxList.HorizontalScrollbarBreadth = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarOrientationProperty = List.HorizontalScrollbarOrientationProperty;
        public Delight.ElementOrientation HorizontalScrollbarOrientation
        {
            get { return ComboBoxList.HorizontalScrollbarOrientation; }
            set { ComboBoxList.HorizontalScrollbarOrientation = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarScrollPositionProperty = List.HorizontalScrollbarScrollPositionProperty;
        public System.Single HorizontalScrollbarScrollPosition
        {
            get { return ComboBoxList.HorizontalScrollbarScrollPosition; }
            set { ComboBoxList.HorizontalScrollbarScrollPosition = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarViewportRatioProperty = List.HorizontalScrollbarViewportRatioProperty;
        public System.Single HorizontalScrollbarViewportRatio
        {
            get { return ComboBoxList.HorizontalScrollbarViewportRatio; }
            set { ComboBoxList.HorizontalScrollbarViewportRatio = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarSpriteProperty = List.HorizontalScrollbarBarSpriteProperty;
        public SpriteAsset HorizontalScrollbarBarSprite
        {
            get { return ComboBoxList.HorizontalScrollbarBarSprite; }
            set { ComboBoxList.HorizontalScrollbarBarSprite = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarOverrideSpriteProperty = List.HorizontalScrollbarBarOverrideSpriteProperty;
        public SpriteAsset HorizontalScrollbarBarOverrideSprite
        {
            get { return ComboBoxList.HorizontalScrollbarBarOverrideSprite; }
            set { ComboBoxList.HorizontalScrollbarBarOverrideSprite = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarTypeProperty = List.HorizontalScrollbarBarTypeProperty;
        public UnityEngine.UI.Image.Type HorizontalScrollbarBarType
        {
            get { return ComboBoxList.HorizontalScrollbarBarType; }
            set { ComboBoxList.HorizontalScrollbarBarType = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarPreserveAspectProperty = List.HorizontalScrollbarBarPreserveAspectProperty;
        public System.Boolean HorizontalScrollbarBarPreserveAspect
        {
            get { return ComboBoxList.HorizontalScrollbarBarPreserveAspect; }
            set { ComboBoxList.HorizontalScrollbarBarPreserveAspect = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarFillCenterProperty = List.HorizontalScrollbarBarFillCenterProperty;
        public System.Boolean HorizontalScrollbarBarFillCenter
        {
            get { return ComboBoxList.HorizontalScrollbarBarFillCenter; }
            set { ComboBoxList.HorizontalScrollbarBarFillCenter = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarFillMethodProperty = List.HorizontalScrollbarBarFillMethodProperty;
        public UnityEngine.UI.Image.FillMethod HorizontalScrollbarBarFillMethod
        {
            get { return ComboBoxList.HorizontalScrollbarBarFillMethod; }
            set { ComboBoxList.HorizontalScrollbarBarFillMethod = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarFillAmountProperty = List.HorizontalScrollbarBarFillAmountProperty;
        public System.Single HorizontalScrollbarBarFillAmount
        {
            get { return ComboBoxList.HorizontalScrollbarBarFillAmount; }
            set { ComboBoxList.HorizontalScrollbarBarFillAmount = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarFillClockwiseProperty = List.HorizontalScrollbarBarFillClockwiseProperty;
        public System.Boolean HorizontalScrollbarBarFillClockwise
        {
            get { return ComboBoxList.HorizontalScrollbarBarFillClockwise; }
            set { ComboBoxList.HorizontalScrollbarBarFillClockwise = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarFillOriginProperty = List.HorizontalScrollbarBarFillOriginProperty;
        public System.Int32 HorizontalScrollbarBarFillOrigin
        {
            get { return ComboBoxList.HorizontalScrollbarBarFillOrigin; }
            set { ComboBoxList.HorizontalScrollbarBarFillOrigin = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarAlphaHitTestMinimumThresholdProperty = List.HorizontalScrollbarBarAlphaHitTestMinimumThresholdProperty;
        public System.Single HorizontalScrollbarBarAlphaHitTestMinimumThreshold
        {
            get { return ComboBoxList.HorizontalScrollbarBarAlphaHitTestMinimumThreshold; }
            set { ComboBoxList.HorizontalScrollbarBarAlphaHitTestMinimumThreshold = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarUseSpriteMeshProperty = List.HorizontalScrollbarBarUseSpriteMeshProperty;
        public System.Boolean HorizontalScrollbarBarUseSpriteMesh
        {
            get { return ComboBoxList.HorizontalScrollbarBarUseSpriteMesh; }
            set { ComboBoxList.HorizontalScrollbarBarUseSpriteMesh = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarPixelsPerUnitMultiplierProperty = List.HorizontalScrollbarBarPixelsPerUnitMultiplierProperty;
        public System.Single HorizontalScrollbarBarPixelsPerUnitMultiplier
        {
            get { return ComboBoxList.HorizontalScrollbarBarPixelsPerUnitMultiplier; }
            set { ComboBoxList.HorizontalScrollbarBarPixelsPerUnitMultiplier = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarMaterialProperty = List.HorizontalScrollbarBarMaterialProperty;
        public MaterialAsset HorizontalScrollbarBarMaterial
        {
            get { return ComboBoxList.HorizontalScrollbarBarMaterial; }
            set { ComboBoxList.HorizontalScrollbarBarMaterial = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarOnCullStateChangedProperty = List.HorizontalScrollbarBarOnCullStateChangedProperty;
        public UnityEngine.UI.MaskableGraphic.CullStateChangedEvent HorizontalScrollbarBarOnCullStateChanged
        {
            get { return ComboBoxList.HorizontalScrollbarBarOnCullStateChanged; }
            set { ComboBoxList.HorizontalScrollbarBarOnCullStateChanged = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarMaskableProperty = List.HorizontalScrollbarBarMaskableProperty;
        public System.Boolean HorizontalScrollbarBarMaskable
        {
            get { return ComboBoxList.HorizontalScrollbarBarMaskable; }
            set { ComboBoxList.HorizontalScrollbarBarMaskable = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarIsMaskingGraphicProperty = List.HorizontalScrollbarBarIsMaskingGraphicProperty;
        public System.Boolean HorizontalScrollbarBarIsMaskingGraphic
        {
            get { return ComboBoxList.HorizontalScrollbarBarIsMaskingGraphic; }
            set { ComboBoxList.HorizontalScrollbarBarIsMaskingGraphic = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarColorProperty = List.HorizontalScrollbarBarColorProperty;
        public UnityEngine.Color HorizontalScrollbarBarColor
        {
            get { return ComboBoxList.HorizontalScrollbarBarColor; }
            set { ComboBoxList.HorizontalScrollbarBarColor = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarRaycastTargetProperty = List.HorizontalScrollbarBarRaycastTargetProperty;
        public System.Boolean HorizontalScrollbarBarRaycastTarget
        {
            get { return ComboBoxList.HorizontalScrollbarBarRaycastTarget; }
            set { ComboBoxList.HorizontalScrollbarBarRaycastTarget = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarWidthProperty = List.HorizontalScrollbarBarWidthProperty;
        public Delight.ElementSize HorizontalScrollbarBarWidth
        {
            get { return ComboBoxList.HorizontalScrollbarBarWidth; }
            set { ComboBoxList.HorizontalScrollbarBarWidth = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarHeightProperty = List.HorizontalScrollbarBarHeightProperty;
        public Delight.ElementSize HorizontalScrollbarBarHeight
        {
            get { return ComboBoxList.HorizontalScrollbarBarHeight; }
            set { ComboBoxList.HorizontalScrollbarBarHeight = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarOverrideWidthProperty = List.HorizontalScrollbarBarOverrideWidthProperty;
        public Delight.ElementSize HorizontalScrollbarBarOverrideWidth
        {
            get { return ComboBoxList.HorizontalScrollbarBarOverrideWidth; }
            set { ComboBoxList.HorizontalScrollbarBarOverrideWidth = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarOverrideHeightProperty = List.HorizontalScrollbarBarOverrideHeightProperty;
        public Delight.ElementSize HorizontalScrollbarBarOverrideHeight
        {
            get { return ComboBoxList.HorizontalScrollbarBarOverrideHeight; }
            set { ComboBoxList.HorizontalScrollbarBarOverrideHeight = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarScaleProperty = List.HorizontalScrollbarBarScaleProperty;
        public UnityEngine.Vector3 HorizontalScrollbarBarScale
        {
            get { return ComboBoxList.HorizontalScrollbarBarScale; }
            set { ComboBoxList.HorizontalScrollbarBarScale = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarAlignmentProperty = List.HorizontalScrollbarBarAlignmentProperty;
        public Delight.ElementAlignment HorizontalScrollbarBarAlignment
        {
            get { return ComboBoxList.HorizontalScrollbarBarAlignment; }
            set { ComboBoxList.HorizontalScrollbarBarAlignment = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarMarginProperty = List.HorizontalScrollbarBarMarginProperty;
        public Delight.ElementMargin HorizontalScrollbarBarMargin
        {
            get { return ComboBoxList.HorizontalScrollbarBarMargin; }
            set { ComboBoxList.HorizontalScrollbarBarMargin = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarOffsetProperty = List.HorizontalScrollbarBarOffsetProperty;
        public Delight.ElementMargin HorizontalScrollbarBarOffset
        {
            get { return ComboBoxList.HorizontalScrollbarBarOffset; }
            set { ComboBoxList.HorizontalScrollbarBarOffset = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarOffsetFromParentProperty = List.HorizontalScrollbarBarOffsetFromParentProperty;
        public Delight.ElementMargin HorizontalScrollbarBarOffsetFromParent
        {
            get { return ComboBoxList.HorizontalScrollbarBarOffsetFromParent; }
            set { ComboBoxList.HorizontalScrollbarBarOffsetFromParent = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarPivotProperty = List.HorizontalScrollbarBarPivotProperty;
        public UnityEngine.Vector2 HorizontalScrollbarBarPivot
        {
            get { return ComboBoxList.HorizontalScrollbarBarPivot; }
            set { ComboBoxList.HorizontalScrollbarBarPivot = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarLayoutRootProperty = List.HorizontalScrollbarBarLayoutRootProperty;
        public Delight.LayoutRoot HorizontalScrollbarBarLayoutRoot
        {
            get { return ComboBoxList.HorizontalScrollbarBarLayoutRoot; }
            set { ComboBoxList.HorizontalScrollbarBarLayoutRoot = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarDisableLayoutUpdateProperty = List.HorizontalScrollbarBarDisableLayoutUpdateProperty;
        public System.Boolean HorizontalScrollbarBarDisableLayoutUpdate
        {
            get { return ComboBoxList.HorizontalScrollbarBarDisableLayoutUpdate; }
            set { ComboBoxList.HorizontalScrollbarBarDisableLayoutUpdate = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarAlphaProperty = List.HorizontalScrollbarBarAlphaProperty;
        public System.Single HorizontalScrollbarBarAlpha
        {
            get { return ComboBoxList.HorizontalScrollbarBarAlpha; }
            set { ComboBoxList.HorizontalScrollbarBarAlpha = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarIsVisibleProperty = List.HorizontalScrollbarBarIsVisibleProperty;
        public System.Boolean HorizontalScrollbarBarIsVisible
        {
            get { return ComboBoxList.HorizontalScrollbarBarIsVisible; }
            set { ComboBoxList.HorizontalScrollbarBarIsVisible = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarRaycastBlockModeProperty = List.HorizontalScrollbarBarRaycastBlockModeProperty;
        public Delight.RaycastBlockMode HorizontalScrollbarBarRaycastBlockMode
        {
            get { return ComboBoxList.HorizontalScrollbarBarRaycastBlockMode; }
            set { ComboBoxList.HorizontalScrollbarBarRaycastBlockMode = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarUseFastShaderProperty = List.HorizontalScrollbarBarUseFastShaderProperty;
        public System.Boolean HorizontalScrollbarBarUseFastShader
        {
            get { return ComboBoxList.HorizontalScrollbarBarUseFastShader; }
            set { ComboBoxList.HorizontalScrollbarBarUseFastShader = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarBubbleNotifyChildLayoutChangedProperty = List.HorizontalScrollbarBarBubbleNotifyChildLayoutChangedProperty;
        public System.Boolean HorizontalScrollbarBarBubbleNotifyChildLayoutChanged
        {
            get { return ComboBoxList.HorizontalScrollbarBarBubbleNotifyChildLayoutChanged; }
            set { ComboBoxList.HorizontalScrollbarBarBubbleNotifyChildLayoutChanged = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarIgnoreFlipProperty = List.HorizontalScrollbarBarIgnoreFlipProperty;
        public System.Boolean HorizontalScrollbarBarIgnoreFlip
        {
            get { return ComboBoxList.HorizontalScrollbarBarIgnoreFlip; }
            set { ComboBoxList.HorizontalScrollbarBarIgnoreFlip = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarRotationProperty = List.HorizontalScrollbarBarRotationProperty;
        public UnityEngine.Quaternion HorizontalScrollbarBarRotation
        {
            get { return ComboBoxList.HorizontalScrollbarBarRotation; }
            set { ComboBoxList.HorizontalScrollbarBarRotation = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarPositionProperty = List.HorizontalScrollbarBarPositionProperty;
        public UnityEngine.Vector3 HorizontalScrollbarBarPosition
        {
            get { return ComboBoxList.HorizontalScrollbarBarPosition; }
            set { ComboBoxList.HorizontalScrollbarBarPosition = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarGameObjectProperty = List.HorizontalScrollbarBarGameObjectProperty;
        public UnityEngine.GameObject HorizontalScrollbarBarGameObject
        {
            get { return ComboBoxList.HorizontalScrollbarBarGameObject; }
            set { ComboBoxList.HorizontalScrollbarBarGameObject = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarEnableScriptEventsProperty = List.HorizontalScrollbarBarEnableScriptEventsProperty;
        public System.Boolean HorizontalScrollbarBarEnableScriptEvents
        {
            get { return ComboBoxList.HorizontalScrollbarBarEnableScriptEvents; }
            set { ComboBoxList.HorizontalScrollbarBarEnableScriptEvents = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarIgnoreObjectProperty = List.HorizontalScrollbarBarIgnoreObjectProperty;
        public System.Boolean HorizontalScrollbarBarIgnoreObject
        {
            get { return ComboBoxList.HorizontalScrollbarBarIgnoreObject; }
            set { ComboBoxList.HorizontalScrollbarBarIgnoreObject = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarIsActiveProperty = List.HorizontalScrollbarBarIsActiveProperty;
        public System.Boolean HorizontalScrollbarBarIsActive
        {
            get { return ComboBoxList.HorizontalScrollbarBarIsActive; }
            set { ComboBoxList.HorizontalScrollbarBarIsActive = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBarLoadModeProperty = List.HorizontalScrollbarBarLoadModeProperty;
        public Delight.LoadMode HorizontalScrollbarBarLoadMode
        {
            get { return ComboBoxList.HorizontalScrollbarBarLoadMode; }
            set { ComboBoxList.HorizontalScrollbarBarLoadMode = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleSpriteProperty = List.HorizontalScrollbarHandleSpriteProperty;
        public SpriteAsset HorizontalScrollbarHandleSprite
        {
            get { return ComboBoxList.HorizontalScrollbarHandleSprite; }
            set { ComboBoxList.HorizontalScrollbarHandleSprite = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleOverrideSpriteProperty = List.HorizontalScrollbarHandleOverrideSpriteProperty;
        public SpriteAsset HorizontalScrollbarHandleOverrideSprite
        {
            get { return ComboBoxList.HorizontalScrollbarHandleOverrideSprite; }
            set { ComboBoxList.HorizontalScrollbarHandleOverrideSprite = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleTypeProperty = List.HorizontalScrollbarHandleTypeProperty;
        public UnityEngine.UI.Image.Type HorizontalScrollbarHandleType
        {
            get { return ComboBoxList.HorizontalScrollbarHandleType; }
            set { ComboBoxList.HorizontalScrollbarHandleType = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandlePreserveAspectProperty = List.HorizontalScrollbarHandlePreserveAspectProperty;
        public System.Boolean HorizontalScrollbarHandlePreserveAspect
        {
            get { return ComboBoxList.HorizontalScrollbarHandlePreserveAspect; }
            set { ComboBoxList.HorizontalScrollbarHandlePreserveAspect = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleFillCenterProperty = List.HorizontalScrollbarHandleFillCenterProperty;
        public System.Boolean HorizontalScrollbarHandleFillCenter
        {
            get { return ComboBoxList.HorizontalScrollbarHandleFillCenter; }
            set { ComboBoxList.HorizontalScrollbarHandleFillCenter = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleFillMethodProperty = List.HorizontalScrollbarHandleFillMethodProperty;
        public UnityEngine.UI.Image.FillMethod HorizontalScrollbarHandleFillMethod
        {
            get { return ComboBoxList.HorizontalScrollbarHandleFillMethod; }
            set { ComboBoxList.HorizontalScrollbarHandleFillMethod = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleFillAmountProperty = List.HorizontalScrollbarHandleFillAmountProperty;
        public System.Single HorizontalScrollbarHandleFillAmount
        {
            get { return ComboBoxList.HorizontalScrollbarHandleFillAmount; }
            set { ComboBoxList.HorizontalScrollbarHandleFillAmount = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleFillClockwiseProperty = List.HorizontalScrollbarHandleFillClockwiseProperty;
        public System.Boolean HorizontalScrollbarHandleFillClockwise
        {
            get { return ComboBoxList.HorizontalScrollbarHandleFillClockwise; }
            set { ComboBoxList.HorizontalScrollbarHandleFillClockwise = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleFillOriginProperty = List.HorizontalScrollbarHandleFillOriginProperty;
        public System.Int32 HorizontalScrollbarHandleFillOrigin
        {
            get { return ComboBoxList.HorizontalScrollbarHandleFillOrigin; }
            set { ComboBoxList.HorizontalScrollbarHandleFillOrigin = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleAlphaHitTestMinimumThresholdProperty = List.HorizontalScrollbarHandleAlphaHitTestMinimumThresholdProperty;
        public System.Single HorizontalScrollbarHandleAlphaHitTestMinimumThreshold
        {
            get { return ComboBoxList.HorizontalScrollbarHandleAlphaHitTestMinimumThreshold; }
            set { ComboBoxList.HorizontalScrollbarHandleAlphaHitTestMinimumThreshold = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleUseSpriteMeshProperty = List.HorizontalScrollbarHandleUseSpriteMeshProperty;
        public System.Boolean HorizontalScrollbarHandleUseSpriteMesh
        {
            get { return ComboBoxList.HorizontalScrollbarHandleUseSpriteMesh; }
            set { ComboBoxList.HorizontalScrollbarHandleUseSpriteMesh = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandlePixelsPerUnitMultiplierProperty = List.HorizontalScrollbarHandlePixelsPerUnitMultiplierProperty;
        public System.Single HorizontalScrollbarHandlePixelsPerUnitMultiplier
        {
            get { return ComboBoxList.HorizontalScrollbarHandlePixelsPerUnitMultiplier; }
            set { ComboBoxList.HorizontalScrollbarHandlePixelsPerUnitMultiplier = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleMaterialProperty = List.HorizontalScrollbarHandleMaterialProperty;
        public MaterialAsset HorizontalScrollbarHandleMaterial
        {
            get { return ComboBoxList.HorizontalScrollbarHandleMaterial; }
            set { ComboBoxList.HorizontalScrollbarHandleMaterial = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleOnCullStateChangedProperty = List.HorizontalScrollbarHandleOnCullStateChangedProperty;
        public UnityEngine.UI.MaskableGraphic.CullStateChangedEvent HorizontalScrollbarHandleOnCullStateChanged
        {
            get { return ComboBoxList.HorizontalScrollbarHandleOnCullStateChanged; }
            set { ComboBoxList.HorizontalScrollbarHandleOnCullStateChanged = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleMaskableProperty = List.HorizontalScrollbarHandleMaskableProperty;
        public System.Boolean HorizontalScrollbarHandleMaskable
        {
            get { return ComboBoxList.HorizontalScrollbarHandleMaskable; }
            set { ComboBoxList.HorizontalScrollbarHandleMaskable = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleIsMaskingGraphicProperty = List.HorizontalScrollbarHandleIsMaskingGraphicProperty;
        public System.Boolean HorizontalScrollbarHandleIsMaskingGraphic
        {
            get { return ComboBoxList.HorizontalScrollbarHandleIsMaskingGraphic; }
            set { ComboBoxList.HorizontalScrollbarHandleIsMaskingGraphic = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleColorProperty = List.HorizontalScrollbarHandleColorProperty;
        public UnityEngine.Color HorizontalScrollbarHandleColor
        {
            get { return ComboBoxList.HorizontalScrollbarHandleColor; }
            set { ComboBoxList.HorizontalScrollbarHandleColor = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleRaycastTargetProperty = List.HorizontalScrollbarHandleRaycastTargetProperty;
        public System.Boolean HorizontalScrollbarHandleRaycastTarget
        {
            get { return ComboBoxList.HorizontalScrollbarHandleRaycastTarget; }
            set { ComboBoxList.HorizontalScrollbarHandleRaycastTarget = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleWidthProperty = List.HorizontalScrollbarHandleWidthProperty;
        public Delight.ElementSize HorizontalScrollbarHandleWidth
        {
            get { return ComboBoxList.HorizontalScrollbarHandleWidth; }
            set { ComboBoxList.HorizontalScrollbarHandleWidth = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleHeightProperty = List.HorizontalScrollbarHandleHeightProperty;
        public Delight.ElementSize HorizontalScrollbarHandleHeight
        {
            get { return ComboBoxList.HorizontalScrollbarHandleHeight; }
            set { ComboBoxList.HorizontalScrollbarHandleHeight = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleOverrideWidthProperty = List.HorizontalScrollbarHandleOverrideWidthProperty;
        public Delight.ElementSize HorizontalScrollbarHandleOverrideWidth
        {
            get { return ComboBoxList.HorizontalScrollbarHandleOverrideWidth; }
            set { ComboBoxList.HorizontalScrollbarHandleOverrideWidth = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleOverrideHeightProperty = List.HorizontalScrollbarHandleOverrideHeightProperty;
        public Delight.ElementSize HorizontalScrollbarHandleOverrideHeight
        {
            get { return ComboBoxList.HorizontalScrollbarHandleOverrideHeight; }
            set { ComboBoxList.HorizontalScrollbarHandleOverrideHeight = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleScaleProperty = List.HorizontalScrollbarHandleScaleProperty;
        public UnityEngine.Vector3 HorizontalScrollbarHandleScale
        {
            get { return ComboBoxList.HorizontalScrollbarHandleScale; }
            set { ComboBoxList.HorizontalScrollbarHandleScale = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleAlignmentProperty = List.HorizontalScrollbarHandleAlignmentProperty;
        public Delight.ElementAlignment HorizontalScrollbarHandleAlignment
        {
            get { return ComboBoxList.HorizontalScrollbarHandleAlignment; }
            set { ComboBoxList.HorizontalScrollbarHandleAlignment = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleMarginProperty = List.HorizontalScrollbarHandleMarginProperty;
        public Delight.ElementMargin HorizontalScrollbarHandleMargin
        {
            get { return ComboBoxList.HorizontalScrollbarHandleMargin; }
            set { ComboBoxList.HorizontalScrollbarHandleMargin = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleOffsetProperty = List.HorizontalScrollbarHandleOffsetProperty;
        public Delight.ElementMargin HorizontalScrollbarHandleOffset
        {
            get { return ComboBoxList.HorizontalScrollbarHandleOffset; }
            set { ComboBoxList.HorizontalScrollbarHandleOffset = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleOffsetFromParentProperty = List.HorizontalScrollbarHandleOffsetFromParentProperty;
        public Delight.ElementMargin HorizontalScrollbarHandleOffsetFromParent
        {
            get { return ComboBoxList.HorizontalScrollbarHandleOffsetFromParent; }
            set { ComboBoxList.HorizontalScrollbarHandleOffsetFromParent = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandlePivotProperty = List.HorizontalScrollbarHandlePivotProperty;
        public UnityEngine.Vector2 HorizontalScrollbarHandlePivot
        {
            get { return ComboBoxList.HorizontalScrollbarHandlePivot; }
            set { ComboBoxList.HorizontalScrollbarHandlePivot = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleLayoutRootProperty = List.HorizontalScrollbarHandleLayoutRootProperty;
        public Delight.LayoutRoot HorizontalScrollbarHandleLayoutRoot
        {
            get { return ComboBoxList.HorizontalScrollbarHandleLayoutRoot; }
            set { ComboBoxList.HorizontalScrollbarHandleLayoutRoot = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleDisableLayoutUpdateProperty = List.HorizontalScrollbarHandleDisableLayoutUpdateProperty;
        public System.Boolean HorizontalScrollbarHandleDisableLayoutUpdate
        {
            get { return ComboBoxList.HorizontalScrollbarHandleDisableLayoutUpdate; }
            set { ComboBoxList.HorizontalScrollbarHandleDisableLayoutUpdate = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleAlphaProperty = List.HorizontalScrollbarHandleAlphaProperty;
        public System.Single HorizontalScrollbarHandleAlpha
        {
            get { return ComboBoxList.HorizontalScrollbarHandleAlpha; }
            set { ComboBoxList.HorizontalScrollbarHandleAlpha = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleIsVisibleProperty = List.HorizontalScrollbarHandleIsVisibleProperty;
        public System.Boolean HorizontalScrollbarHandleIsVisible
        {
            get { return ComboBoxList.HorizontalScrollbarHandleIsVisible; }
            set { ComboBoxList.HorizontalScrollbarHandleIsVisible = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleRaycastBlockModeProperty = List.HorizontalScrollbarHandleRaycastBlockModeProperty;
        public Delight.RaycastBlockMode HorizontalScrollbarHandleRaycastBlockMode
        {
            get { return ComboBoxList.HorizontalScrollbarHandleRaycastBlockMode; }
            set { ComboBoxList.HorizontalScrollbarHandleRaycastBlockMode = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleUseFastShaderProperty = List.HorizontalScrollbarHandleUseFastShaderProperty;
        public System.Boolean HorizontalScrollbarHandleUseFastShader
        {
            get { return ComboBoxList.HorizontalScrollbarHandleUseFastShader; }
            set { ComboBoxList.HorizontalScrollbarHandleUseFastShader = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleBubbleNotifyChildLayoutChangedProperty = List.HorizontalScrollbarHandleBubbleNotifyChildLayoutChangedProperty;
        public System.Boolean HorizontalScrollbarHandleBubbleNotifyChildLayoutChanged
        {
            get { return ComboBoxList.HorizontalScrollbarHandleBubbleNotifyChildLayoutChanged; }
            set { ComboBoxList.HorizontalScrollbarHandleBubbleNotifyChildLayoutChanged = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleIgnoreFlipProperty = List.HorizontalScrollbarHandleIgnoreFlipProperty;
        public System.Boolean HorizontalScrollbarHandleIgnoreFlip
        {
            get { return ComboBoxList.HorizontalScrollbarHandleIgnoreFlip; }
            set { ComboBoxList.HorizontalScrollbarHandleIgnoreFlip = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleRotationProperty = List.HorizontalScrollbarHandleRotationProperty;
        public UnityEngine.Quaternion HorizontalScrollbarHandleRotation
        {
            get { return ComboBoxList.HorizontalScrollbarHandleRotation; }
            set { ComboBoxList.HorizontalScrollbarHandleRotation = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandlePositionProperty = List.HorizontalScrollbarHandlePositionProperty;
        public UnityEngine.Vector3 HorizontalScrollbarHandlePosition
        {
            get { return ComboBoxList.HorizontalScrollbarHandlePosition; }
            set { ComboBoxList.HorizontalScrollbarHandlePosition = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleGameObjectProperty = List.HorizontalScrollbarHandleGameObjectProperty;
        public UnityEngine.GameObject HorizontalScrollbarHandleGameObject
        {
            get { return ComboBoxList.HorizontalScrollbarHandleGameObject; }
            set { ComboBoxList.HorizontalScrollbarHandleGameObject = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleEnableScriptEventsProperty = List.HorizontalScrollbarHandleEnableScriptEventsProperty;
        public System.Boolean HorizontalScrollbarHandleEnableScriptEvents
        {
            get { return ComboBoxList.HorizontalScrollbarHandleEnableScriptEvents; }
            set { ComboBoxList.HorizontalScrollbarHandleEnableScriptEvents = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleIgnoreObjectProperty = List.HorizontalScrollbarHandleIgnoreObjectProperty;
        public System.Boolean HorizontalScrollbarHandleIgnoreObject
        {
            get { return ComboBoxList.HorizontalScrollbarHandleIgnoreObject; }
            set { ComboBoxList.HorizontalScrollbarHandleIgnoreObject = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleIsActiveProperty = List.HorizontalScrollbarHandleIsActiveProperty;
        public System.Boolean HorizontalScrollbarHandleIsActive
        {
            get { return ComboBoxList.HorizontalScrollbarHandleIsActive; }
            set { ComboBoxList.HorizontalScrollbarHandleIsActive = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHandleLoadModeProperty = List.HorizontalScrollbarHandleLoadModeProperty;
        public Delight.LoadMode HorizontalScrollbarHandleLoadMode
        {
            get { return ComboBoxList.HorizontalScrollbarHandleLoadMode; }
            set { ComboBoxList.HorizontalScrollbarHandleLoadMode = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBackgroundSpriteProperty = List.HorizontalScrollbarBackgroundSpriteProperty;
        public SpriteAsset HorizontalScrollbarBackgroundSprite
        {
            get { return ComboBoxList.HorizontalScrollbarBackgroundSprite; }
            set { ComboBoxList.HorizontalScrollbarBackgroundSprite = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBackgroundOverrideSpriteProperty = List.HorizontalScrollbarBackgroundOverrideSpriteProperty;
        public SpriteAsset HorizontalScrollbarBackgroundOverrideSprite
        {
            get { return ComboBoxList.HorizontalScrollbarBackgroundOverrideSprite; }
            set { ComboBoxList.HorizontalScrollbarBackgroundOverrideSprite = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBackgroundTypeProperty = List.HorizontalScrollbarBackgroundTypeProperty;
        public UnityEngine.UI.Image.Type HorizontalScrollbarBackgroundType
        {
            get { return ComboBoxList.HorizontalScrollbarBackgroundType; }
            set { ComboBoxList.HorizontalScrollbarBackgroundType = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBackgroundPreserveAspectProperty = List.HorizontalScrollbarBackgroundPreserveAspectProperty;
        public System.Boolean HorizontalScrollbarBackgroundPreserveAspect
        {
            get { return ComboBoxList.HorizontalScrollbarBackgroundPreserveAspect; }
            set { ComboBoxList.HorizontalScrollbarBackgroundPreserveAspect = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBackgroundFillCenterProperty = List.HorizontalScrollbarBackgroundFillCenterProperty;
        public System.Boolean HorizontalScrollbarBackgroundFillCenter
        {
            get { return ComboBoxList.HorizontalScrollbarBackgroundFillCenter; }
            set { ComboBoxList.HorizontalScrollbarBackgroundFillCenter = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBackgroundFillMethodProperty = List.HorizontalScrollbarBackgroundFillMethodProperty;
        public UnityEngine.UI.Image.FillMethod HorizontalScrollbarBackgroundFillMethod
        {
            get { return ComboBoxList.HorizontalScrollbarBackgroundFillMethod; }
            set { ComboBoxList.HorizontalScrollbarBackgroundFillMethod = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBackgroundFillAmountProperty = List.HorizontalScrollbarBackgroundFillAmountProperty;
        public System.Single HorizontalScrollbarBackgroundFillAmount
        {
            get { return ComboBoxList.HorizontalScrollbarBackgroundFillAmount; }
            set { ComboBoxList.HorizontalScrollbarBackgroundFillAmount = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBackgroundFillClockwiseProperty = List.HorizontalScrollbarBackgroundFillClockwiseProperty;
        public System.Boolean HorizontalScrollbarBackgroundFillClockwise
        {
            get { return ComboBoxList.HorizontalScrollbarBackgroundFillClockwise; }
            set { ComboBoxList.HorizontalScrollbarBackgroundFillClockwise = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBackgroundFillOriginProperty = List.HorizontalScrollbarBackgroundFillOriginProperty;
        public System.Int32 HorizontalScrollbarBackgroundFillOrigin
        {
            get { return ComboBoxList.HorizontalScrollbarBackgroundFillOrigin; }
            set { ComboBoxList.HorizontalScrollbarBackgroundFillOrigin = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBackgroundAlphaHitTestMinimumThresholdProperty = List.HorizontalScrollbarBackgroundAlphaHitTestMinimumThresholdProperty;
        public System.Single HorizontalScrollbarBackgroundAlphaHitTestMinimumThreshold
        {
            get { return ComboBoxList.HorizontalScrollbarBackgroundAlphaHitTestMinimumThreshold; }
            set { ComboBoxList.HorizontalScrollbarBackgroundAlphaHitTestMinimumThreshold = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBackgroundUseSpriteMeshProperty = List.HorizontalScrollbarBackgroundUseSpriteMeshProperty;
        public System.Boolean HorizontalScrollbarBackgroundUseSpriteMesh
        {
            get { return ComboBoxList.HorizontalScrollbarBackgroundUseSpriteMesh; }
            set { ComboBoxList.HorizontalScrollbarBackgroundUseSpriteMesh = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBackgroundPixelsPerUnitMultiplierProperty = List.HorizontalScrollbarBackgroundPixelsPerUnitMultiplierProperty;
        public System.Single HorizontalScrollbarBackgroundPixelsPerUnitMultiplier
        {
            get { return ComboBoxList.HorizontalScrollbarBackgroundPixelsPerUnitMultiplier; }
            set { ComboBoxList.HorizontalScrollbarBackgroundPixelsPerUnitMultiplier = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBackgroundMaterialProperty = List.HorizontalScrollbarBackgroundMaterialProperty;
        public MaterialAsset HorizontalScrollbarBackgroundMaterial
        {
            get { return ComboBoxList.HorizontalScrollbarBackgroundMaterial; }
            set { ComboBoxList.HorizontalScrollbarBackgroundMaterial = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBackgroundOnCullStateChangedProperty = List.HorizontalScrollbarBackgroundOnCullStateChangedProperty;
        public UnityEngine.UI.MaskableGraphic.CullStateChangedEvent HorizontalScrollbarBackgroundOnCullStateChanged
        {
            get { return ComboBoxList.HorizontalScrollbarBackgroundOnCullStateChanged; }
            set { ComboBoxList.HorizontalScrollbarBackgroundOnCullStateChanged = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBackgroundMaskableProperty = List.HorizontalScrollbarBackgroundMaskableProperty;
        public System.Boolean HorizontalScrollbarBackgroundMaskable
        {
            get { return ComboBoxList.HorizontalScrollbarBackgroundMaskable; }
            set { ComboBoxList.HorizontalScrollbarBackgroundMaskable = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBackgroundIsMaskingGraphicProperty = List.HorizontalScrollbarBackgroundIsMaskingGraphicProperty;
        public System.Boolean HorizontalScrollbarBackgroundIsMaskingGraphic
        {
            get { return ComboBoxList.HorizontalScrollbarBackgroundIsMaskingGraphic; }
            set { ComboBoxList.HorizontalScrollbarBackgroundIsMaskingGraphic = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBackgroundColorProperty = List.HorizontalScrollbarBackgroundColorProperty;
        public UnityEngine.Color HorizontalScrollbarBackgroundColor
        {
            get { return ComboBoxList.HorizontalScrollbarBackgroundColor; }
            set { ComboBoxList.HorizontalScrollbarBackgroundColor = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBackgroundRaycastTargetProperty = List.HorizontalScrollbarBackgroundRaycastTargetProperty;
        public System.Boolean HorizontalScrollbarBackgroundRaycastTarget
        {
            get { return ComboBoxList.HorizontalScrollbarBackgroundRaycastTarget; }
            set { ComboBoxList.HorizontalScrollbarBackgroundRaycastTarget = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarWidthProperty = List.HorizontalScrollbarWidthProperty;
        public Delight.ElementSize HorizontalScrollbarWidth
        {
            get { return ComboBoxList.HorizontalScrollbarWidth; }
            set { ComboBoxList.HorizontalScrollbarWidth = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarHeightProperty = List.HorizontalScrollbarHeightProperty;
        public Delight.ElementSize HorizontalScrollbarHeight
        {
            get { return ComboBoxList.HorizontalScrollbarHeight; }
            set { ComboBoxList.HorizontalScrollbarHeight = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarOverrideWidthProperty = List.HorizontalScrollbarOverrideWidthProperty;
        public Delight.ElementSize HorizontalScrollbarOverrideWidth
        {
            get { return ComboBoxList.HorizontalScrollbarOverrideWidth; }
            set { ComboBoxList.HorizontalScrollbarOverrideWidth = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarOverrideHeightProperty = List.HorizontalScrollbarOverrideHeightProperty;
        public Delight.ElementSize HorizontalScrollbarOverrideHeight
        {
            get { return ComboBoxList.HorizontalScrollbarOverrideHeight; }
            set { ComboBoxList.HorizontalScrollbarOverrideHeight = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarScaleProperty = List.HorizontalScrollbarScaleProperty;
        public UnityEngine.Vector3 HorizontalScrollbarScale
        {
            get { return ComboBoxList.HorizontalScrollbarScale; }
            set { ComboBoxList.HorizontalScrollbarScale = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarAlignmentProperty = List.HorizontalScrollbarAlignmentProperty;
        public Delight.ElementAlignment HorizontalScrollbarAlignment
        {
            get { return ComboBoxList.HorizontalScrollbarAlignment; }
            set { ComboBoxList.HorizontalScrollbarAlignment = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarMarginProperty = List.HorizontalScrollbarMarginProperty;
        public Delight.ElementMargin HorizontalScrollbarMargin
        {
            get { return ComboBoxList.HorizontalScrollbarMargin; }
            set { ComboBoxList.HorizontalScrollbarMargin = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarOffsetProperty = List.HorizontalScrollbarOffsetProperty;
        public Delight.ElementMargin HorizontalScrollbarOffset
        {
            get { return ComboBoxList.HorizontalScrollbarOffset; }
            set { ComboBoxList.HorizontalScrollbarOffset = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarOffsetFromParentProperty = List.HorizontalScrollbarOffsetFromParentProperty;
        public Delight.ElementMargin HorizontalScrollbarOffsetFromParent
        {
            get { return ComboBoxList.HorizontalScrollbarOffsetFromParent; }
            set { ComboBoxList.HorizontalScrollbarOffsetFromParent = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarPivotProperty = List.HorizontalScrollbarPivotProperty;
        public UnityEngine.Vector2 HorizontalScrollbarPivot
        {
            get { return ComboBoxList.HorizontalScrollbarPivot; }
            set { ComboBoxList.HorizontalScrollbarPivot = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarLayoutRootProperty = List.HorizontalScrollbarLayoutRootProperty;
        public Delight.LayoutRoot HorizontalScrollbarLayoutRoot
        {
            get { return ComboBoxList.HorizontalScrollbarLayoutRoot; }
            set { ComboBoxList.HorizontalScrollbarLayoutRoot = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarDisableLayoutUpdateProperty = List.HorizontalScrollbarDisableLayoutUpdateProperty;
        public System.Boolean HorizontalScrollbarDisableLayoutUpdate
        {
            get { return ComboBoxList.HorizontalScrollbarDisableLayoutUpdate; }
            set { ComboBoxList.HorizontalScrollbarDisableLayoutUpdate = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarAlphaProperty = List.HorizontalScrollbarAlphaProperty;
        public System.Single HorizontalScrollbarAlpha
        {
            get { return ComboBoxList.HorizontalScrollbarAlpha; }
            set { ComboBoxList.HorizontalScrollbarAlpha = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarIsVisibleProperty = List.HorizontalScrollbarIsVisibleProperty;
        public System.Boolean HorizontalScrollbarIsVisible
        {
            get { return ComboBoxList.HorizontalScrollbarIsVisible; }
            set { ComboBoxList.HorizontalScrollbarIsVisible = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarRaycastBlockModeProperty = List.HorizontalScrollbarRaycastBlockModeProperty;
        public Delight.RaycastBlockMode HorizontalScrollbarRaycastBlockMode
        {
            get { return ComboBoxList.HorizontalScrollbarRaycastBlockMode; }
            set { ComboBoxList.HorizontalScrollbarRaycastBlockMode = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarUseFastShaderProperty = List.HorizontalScrollbarUseFastShaderProperty;
        public System.Boolean HorizontalScrollbarUseFastShader
        {
            get { return ComboBoxList.HorizontalScrollbarUseFastShader; }
            set { ComboBoxList.HorizontalScrollbarUseFastShader = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarBubbleNotifyChildLayoutChangedProperty = List.HorizontalScrollbarBubbleNotifyChildLayoutChangedProperty;
        public System.Boolean HorizontalScrollbarBubbleNotifyChildLayoutChanged
        {
            get { return ComboBoxList.HorizontalScrollbarBubbleNotifyChildLayoutChanged; }
            set { ComboBoxList.HorizontalScrollbarBubbleNotifyChildLayoutChanged = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarIgnoreFlipProperty = List.HorizontalScrollbarIgnoreFlipProperty;
        public System.Boolean HorizontalScrollbarIgnoreFlip
        {
            get { return ComboBoxList.HorizontalScrollbarIgnoreFlip; }
            set { ComboBoxList.HorizontalScrollbarIgnoreFlip = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarRotationProperty = List.HorizontalScrollbarRotationProperty;
        public UnityEngine.Quaternion HorizontalScrollbarRotation
        {
            get { return ComboBoxList.HorizontalScrollbarRotation; }
            set { ComboBoxList.HorizontalScrollbarRotation = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarPositionProperty = List.HorizontalScrollbarPositionProperty;
        public UnityEngine.Vector3 HorizontalScrollbarPosition
        {
            get { return ComboBoxList.HorizontalScrollbarPosition; }
            set { ComboBoxList.HorizontalScrollbarPosition = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarGameObjectProperty = List.HorizontalScrollbarGameObjectProperty;
        public UnityEngine.GameObject HorizontalScrollbarGameObject
        {
            get { return ComboBoxList.HorizontalScrollbarGameObject; }
            set { ComboBoxList.HorizontalScrollbarGameObject = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarEnableScriptEventsProperty = List.HorizontalScrollbarEnableScriptEventsProperty;
        public System.Boolean HorizontalScrollbarEnableScriptEvents
        {
            get { return ComboBoxList.HorizontalScrollbarEnableScriptEvents; }
            set { ComboBoxList.HorizontalScrollbarEnableScriptEvents = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarIgnoreObjectProperty = List.HorizontalScrollbarIgnoreObjectProperty;
        public System.Boolean HorizontalScrollbarIgnoreObject
        {
            get { return ComboBoxList.HorizontalScrollbarIgnoreObject; }
            set { ComboBoxList.HorizontalScrollbarIgnoreObject = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarIsActiveProperty = List.HorizontalScrollbarIsActiveProperty;
        public System.Boolean HorizontalScrollbarIsActive
        {
            get { return ComboBoxList.HorizontalScrollbarIsActive; }
            set { ComboBoxList.HorizontalScrollbarIsActive = value; }
        }

        public readonly static DependencyProperty HorizontalScrollbarLoadModeProperty = List.HorizontalScrollbarLoadModeProperty;
        public Delight.LoadMode HorizontalScrollbarLoadMode
        {
            get { return ComboBoxList.HorizontalScrollbarLoadMode; }
            set { ComboBoxList.HorizontalScrollbarLoadMode = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarLengthProperty = List.VerticalScrollbarLengthProperty;
        public Delight.ElementSize VerticalScrollbarLength
        {
            get { return ComboBoxList.VerticalScrollbarLength; }
            set { ComboBoxList.VerticalScrollbarLength = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBreadthProperty = List.VerticalScrollbarBreadthProperty;
        public Delight.ElementSize VerticalScrollbarBreadth
        {
            get { return ComboBoxList.VerticalScrollbarBreadth; }
            set { ComboBoxList.VerticalScrollbarBreadth = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarOrientationProperty = List.VerticalScrollbarOrientationProperty;
        public Delight.ElementOrientation VerticalScrollbarOrientation
        {
            get { return ComboBoxList.VerticalScrollbarOrientation; }
            set { ComboBoxList.VerticalScrollbarOrientation = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarScrollPositionProperty = List.VerticalScrollbarScrollPositionProperty;
        public System.Single VerticalScrollbarScrollPosition
        {
            get { return ComboBoxList.VerticalScrollbarScrollPosition; }
            set { ComboBoxList.VerticalScrollbarScrollPosition = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarViewportRatioProperty = List.VerticalScrollbarViewportRatioProperty;
        public System.Single VerticalScrollbarViewportRatio
        {
            get { return ComboBoxList.VerticalScrollbarViewportRatio; }
            set { ComboBoxList.VerticalScrollbarViewportRatio = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarSpriteProperty = List.VerticalScrollbarBarSpriteProperty;
        public SpriteAsset VerticalScrollbarBarSprite
        {
            get { return ComboBoxList.VerticalScrollbarBarSprite; }
            set { ComboBoxList.VerticalScrollbarBarSprite = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarOverrideSpriteProperty = List.VerticalScrollbarBarOverrideSpriteProperty;
        public SpriteAsset VerticalScrollbarBarOverrideSprite
        {
            get { return ComboBoxList.VerticalScrollbarBarOverrideSprite; }
            set { ComboBoxList.VerticalScrollbarBarOverrideSprite = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarTypeProperty = List.VerticalScrollbarBarTypeProperty;
        public UnityEngine.UI.Image.Type VerticalScrollbarBarType
        {
            get { return ComboBoxList.VerticalScrollbarBarType; }
            set { ComboBoxList.VerticalScrollbarBarType = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarPreserveAspectProperty = List.VerticalScrollbarBarPreserveAspectProperty;
        public System.Boolean VerticalScrollbarBarPreserveAspect
        {
            get { return ComboBoxList.VerticalScrollbarBarPreserveAspect; }
            set { ComboBoxList.VerticalScrollbarBarPreserveAspect = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarFillCenterProperty = List.VerticalScrollbarBarFillCenterProperty;
        public System.Boolean VerticalScrollbarBarFillCenter
        {
            get { return ComboBoxList.VerticalScrollbarBarFillCenter; }
            set { ComboBoxList.VerticalScrollbarBarFillCenter = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarFillMethodProperty = List.VerticalScrollbarBarFillMethodProperty;
        public UnityEngine.UI.Image.FillMethod VerticalScrollbarBarFillMethod
        {
            get { return ComboBoxList.VerticalScrollbarBarFillMethod; }
            set { ComboBoxList.VerticalScrollbarBarFillMethod = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarFillAmountProperty = List.VerticalScrollbarBarFillAmountProperty;
        public System.Single VerticalScrollbarBarFillAmount
        {
            get { return ComboBoxList.VerticalScrollbarBarFillAmount; }
            set { ComboBoxList.VerticalScrollbarBarFillAmount = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarFillClockwiseProperty = List.VerticalScrollbarBarFillClockwiseProperty;
        public System.Boolean VerticalScrollbarBarFillClockwise
        {
            get { return ComboBoxList.VerticalScrollbarBarFillClockwise; }
            set { ComboBoxList.VerticalScrollbarBarFillClockwise = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarFillOriginProperty = List.VerticalScrollbarBarFillOriginProperty;
        public System.Int32 VerticalScrollbarBarFillOrigin
        {
            get { return ComboBoxList.VerticalScrollbarBarFillOrigin; }
            set { ComboBoxList.VerticalScrollbarBarFillOrigin = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarAlphaHitTestMinimumThresholdProperty = List.VerticalScrollbarBarAlphaHitTestMinimumThresholdProperty;
        public System.Single VerticalScrollbarBarAlphaHitTestMinimumThreshold
        {
            get { return ComboBoxList.VerticalScrollbarBarAlphaHitTestMinimumThreshold; }
            set { ComboBoxList.VerticalScrollbarBarAlphaHitTestMinimumThreshold = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarUseSpriteMeshProperty = List.VerticalScrollbarBarUseSpriteMeshProperty;
        public System.Boolean VerticalScrollbarBarUseSpriteMesh
        {
            get { return ComboBoxList.VerticalScrollbarBarUseSpriteMesh; }
            set { ComboBoxList.VerticalScrollbarBarUseSpriteMesh = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarPixelsPerUnitMultiplierProperty = List.VerticalScrollbarBarPixelsPerUnitMultiplierProperty;
        public System.Single VerticalScrollbarBarPixelsPerUnitMultiplier
        {
            get { return ComboBoxList.VerticalScrollbarBarPixelsPerUnitMultiplier; }
            set { ComboBoxList.VerticalScrollbarBarPixelsPerUnitMultiplier = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarMaterialProperty = List.VerticalScrollbarBarMaterialProperty;
        public MaterialAsset VerticalScrollbarBarMaterial
        {
            get { return ComboBoxList.VerticalScrollbarBarMaterial; }
            set { ComboBoxList.VerticalScrollbarBarMaterial = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarOnCullStateChangedProperty = List.VerticalScrollbarBarOnCullStateChangedProperty;
        public UnityEngine.UI.MaskableGraphic.CullStateChangedEvent VerticalScrollbarBarOnCullStateChanged
        {
            get { return ComboBoxList.VerticalScrollbarBarOnCullStateChanged; }
            set { ComboBoxList.VerticalScrollbarBarOnCullStateChanged = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarMaskableProperty = List.VerticalScrollbarBarMaskableProperty;
        public System.Boolean VerticalScrollbarBarMaskable
        {
            get { return ComboBoxList.VerticalScrollbarBarMaskable; }
            set { ComboBoxList.VerticalScrollbarBarMaskable = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarIsMaskingGraphicProperty = List.VerticalScrollbarBarIsMaskingGraphicProperty;
        public System.Boolean VerticalScrollbarBarIsMaskingGraphic
        {
            get { return ComboBoxList.VerticalScrollbarBarIsMaskingGraphic; }
            set { ComboBoxList.VerticalScrollbarBarIsMaskingGraphic = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarColorProperty = List.VerticalScrollbarBarColorProperty;
        public UnityEngine.Color VerticalScrollbarBarColor
        {
            get { return ComboBoxList.VerticalScrollbarBarColor; }
            set { ComboBoxList.VerticalScrollbarBarColor = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarRaycastTargetProperty = List.VerticalScrollbarBarRaycastTargetProperty;
        public System.Boolean VerticalScrollbarBarRaycastTarget
        {
            get { return ComboBoxList.VerticalScrollbarBarRaycastTarget; }
            set { ComboBoxList.VerticalScrollbarBarRaycastTarget = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarWidthProperty = List.VerticalScrollbarBarWidthProperty;
        public Delight.ElementSize VerticalScrollbarBarWidth
        {
            get { return ComboBoxList.VerticalScrollbarBarWidth; }
            set { ComboBoxList.VerticalScrollbarBarWidth = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarHeightProperty = List.VerticalScrollbarBarHeightProperty;
        public Delight.ElementSize VerticalScrollbarBarHeight
        {
            get { return ComboBoxList.VerticalScrollbarBarHeight; }
            set { ComboBoxList.VerticalScrollbarBarHeight = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarOverrideWidthProperty = List.VerticalScrollbarBarOverrideWidthProperty;
        public Delight.ElementSize VerticalScrollbarBarOverrideWidth
        {
            get { return ComboBoxList.VerticalScrollbarBarOverrideWidth; }
            set { ComboBoxList.VerticalScrollbarBarOverrideWidth = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarOverrideHeightProperty = List.VerticalScrollbarBarOverrideHeightProperty;
        public Delight.ElementSize VerticalScrollbarBarOverrideHeight
        {
            get { return ComboBoxList.VerticalScrollbarBarOverrideHeight; }
            set { ComboBoxList.VerticalScrollbarBarOverrideHeight = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarScaleProperty = List.VerticalScrollbarBarScaleProperty;
        public UnityEngine.Vector3 VerticalScrollbarBarScale
        {
            get { return ComboBoxList.VerticalScrollbarBarScale; }
            set { ComboBoxList.VerticalScrollbarBarScale = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarAlignmentProperty = List.VerticalScrollbarBarAlignmentProperty;
        public Delight.ElementAlignment VerticalScrollbarBarAlignment
        {
            get { return ComboBoxList.VerticalScrollbarBarAlignment; }
            set { ComboBoxList.VerticalScrollbarBarAlignment = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarMarginProperty = List.VerticalScrollbarBarMarginProperty;
        public Delight.ElementMargin VerticalScrollbarBarMargin
        {
            get { return ComboBoxList.VerticalScrollbarBarMargin; }
            set { ComboBoxList.VerticalScrollbarBarMargin = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarOffsetProperty = List.VerticalScrollbarBarOffsetProperty;
        public Delight.ElementMargin VerticalScrollbarBarOffset
        {
            get { return ComboBoxList.VerticalScrollbarBarOffset; }
            set { ComboBoxList.VerticalScrollbarBarOffset = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarOffsetFromParentProperty = List.VerticalScrollbarBarOffsetFromParentProperty;
        public Delight.ElementMargin VerticalScrollbarBarOffsetFromParent
        {
            get { return ComboBoxList.VerticalScrollbarBarOffsetFromParent; }
            set { ComboBoxList.VerticalScrollbarBarOffsetFromParent = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarPivotProperty = List.VerticalScrollbarBarPivotProperty;
        public UnityEngine.Vector2 VerticalScrollbarBarPivot
        {
            get { return ComboBoxList.VerticalScrollbarBarPivot; }
            set { ComboBoxList.VerticalScrollbarBarPivot = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarLayoutRootProperty = List.VerticalScrollbarBarLayoutRootProperty;
        public Delight.LayoutRoot VerticalScrollbarBarLayoutRoot
        {
            get { return ComboBoxList.VerticalScrollbarBarLayoutRoot; }
            set { ComboBoxList.VerticalScrollbarBarLayoutRoot = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarDisableLayoutUpdateProperty = List.VerticalScrollbarBarDisableLayoutUpdateProperty;
        public System.Boolean VerticalScrollbarBarDisableLayoutUpdate
        {
            get { return ComboBoxList.VerticalScrollbarBarDisableLayoutUpdate; }
            set { ComboBoxList.VerticalScrollbarBarDisableLayoutUpdate = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarAlphaProperty = List.VerticalScrollbarBarAlphaProperty;
        public System.Single VerticalScrollbarBarAlpha
        {
            get { return ComboBoxList.VerticalScrollbarBarAlpha; }
            set { ComboBoxList.VerticalScrollbarBarAlpha = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarIsVisibleProperty = List.VerticalScrollbarBarIsVisibleProperty;
        public System.Boolean VerticalScrollbarBarIsVisible
        {
            get { return ComboBoxList.VerticalScrollbarBarIsVisible; }
            set { ComboBoxList.VerticalScrollbarBarIsVisible = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarRaycastBlockModeProperty = List.VerticalScrollbarBarRaycastBlockModeProperty;
        public Delight.RaycastBlockMode VerticalScrollbarBarRaycastBlockMode
        {
            get { return ComboBoxList.VerticalScrollbarBarRaycastBlockMode; }
            set { ComboBoxList.VerticalScrollbarBarRaycastBlockMode = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarUseFastShaderProperty = List.VerticalScrollbarBarUseFastShaderProperty;
        public System.Boolean VerticalScrollbarBarUseFastShader
        {
            get { return ComboBoxList.VerticalScrollbarBarUseFastShader; }
            set { ComboBoxList.VerticalScrollbarBarUseFastShader = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarBubbleNotifyChildLayoutChangedProperty = List.VerticalScrollbarBarBubbleNotifyChildLayoutChangedProperty;
        public System.Boolean VerticalScrollbarBarBubbleNotifyChildLayoutChanged
        {
            get { return ComboBoxList.VerticalScrollbarBarBubbleNotifyChildLayoutChanged; }
            set { ComboBoxList.VerticalScrollbarBarBubbleNotifyChildLayoutChanged = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarIgnoreFlipProperty = List.VerticalScrollbarBarIgnoreFlipProperty;
        public System.Boolean VerticalScrollbarBarIgnoreFlip
        {
            get { return ComboBoxList.VerticalScrollbarBarIgnoreFlip; }
            set { ComboBoxList.VerticalScrollbarBarIgnoreFlip = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarRotationProperty = List.VerticalScrollbarBarRotationProperty;
        public UnityEngine.Quaternion VerticalScrollbarBarRotation
        {
            get { return ComboBoxList.VerticalScrollbarBarRotation; }
            set { ComboBoxList.VerticalScrollbarBarRotation = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarPositionProperty = List.VerticalScrollbarBarPositionProperty;
        public UnityEngine.Vector3 VerticalScrollbarBarPosition
        {
            get { return ComboBoxList.VerticalScrollbarBarPosition; }
            set { ComboBoxList.VerticalScrollbarBarPosition = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarGameObjectProperty = List.VerticalScrollbarBarGameObjectProperty;
        public UnityEngine.GameObject VerticalScrollbarBarGameObject
        {
            get { return ComboBoxList.VerticalScrollbarBarGameObject; }
            set { ComboBoxList.VerticalScrollbarBarGameObject = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarEnableScriptEventsProperty = List.VerticalScrollbarBarEnableScriptEventsProperty;
        public System.Boolean VerticalScrollbarBarEnableScriptEvents
        {
            get { return ComboBoxList.VerticalScrollbarBarEnableScriptEvents; }
            set { ComboBoxList.VerticalScrollbarBarEnableScriptEvents = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarIgnoreObjectProperty = List.VerticalScrollbarBarIgnoreObjectProperty;
        public System.Boolean VerticalScrollbarBarIgnoreObject
        {
            get { return ComboBoxList.VerticalScrollbarBarIgnoreObject; }
            set { ComboBoxList.VerticalScrollbarBarIgnoreObject = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarIsActiveProperty = List.VerticalScrollbarBarIsActiveProperty;
        public System.Boolean VerticalScrollbarBarIsActive
        {
            get { return ComboBoxList.VerticalScrollbarBarIsActive; }
            set { ComboBoxList.VerticalScrollbarBarIsActive = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBarLoadModeProperty = List.VerticalScrollbarBarLoadModeProperty;
        public Delight.LoadMode VerticalScrollbarBarLoadMode
        {
            get { return ComboBoxList.VerticalScrollbarBarLoadMode; }
            set { ComboBoxList.VerticalScrollbarBarLoadMode = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleSpriteProperty = List.VerticalScrollbarHandleSpriteProperty;
        public SpriteAsset VerticalScrollbarHandleSprite
        {
            get { return ComboBoxList.VerticalScrollbarHandleSprite; }
            set { ComboBoxList.VerticalScrollbarHandleSprite = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleOverrideSpriteProperty = List.VerticalScrollbarHandleOverrideSpriteProperty;
        public SpriteAsset VerticalScrollbarHandleOverrideSprite
        {
            get { return ComboBoxList.VerticalScrollbarHandleOverrideSprite; }
            set { ComboBoxList.VerticalScrollbarHandleOverrideSprite = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleTypeProperty = List.VerticalScrollbarHandleTypeProperty;
        public UnityEngine.UI.Image.Type VerticalScrollbarHandleType
        {
            get { return ComboBoxList.VerticalScrollbarHandleType; }
            set { ComboBoxList.VerticalScrollbarHandleType = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandlePreserveAspectProperty = List.VerticalScrollbarHandlePreserveAspectProperty;
        public System.Boolean VerticalScrollbarHandlePreserveAspect
        {
            get { return ComboBoxList.VerticalScrollbarHandlePreserveAspect; }
            set { ComboBoxList.VerticalScrollbarHandlePreserveAspect = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleFillCenterProperty = List.VerticalScrollbarHandleFillCenterProperty;
        public System.Boolean VerticalScrollbarHandleFillCenter
        {
            get { return ComboBoxList.VerticalScrollbarHandleFillCenter; }
            set { ComboBoxList.VerticalScrollbarHandleFillCenter = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleFillMethodProperty = List.VerticalScrollbarHandleFillMethodProperty;
        public UnityEngine.UI.Image.FillMethod VerticalScrollbarHandleFillMethod
        {
            get { return ComboBoxList.VerticalScrollbarHandleFillMethod; }
            set { ComboBoxList.VerticalScrollbarHandleFillMethod = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleFillAmountProperty = List.VerticalScrollbarHandleFillAmountProperty;
        public System.Single VerticalScrollbarHandleFillAmount
        {
            get { return ComboBoxList.VerticalScrollbarHandleFillAmount; }
            set { ComboBoxList.VerticalScrollbarHandleFillAmount = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleFillClockwiseProperty = List.VerticalScrollbarHandleFillClockwiseProperty;
        public System.Boolean VerticalScrollbarHandleFillClockwise
        {
            get { return ComboBoxList.VerticalScrollbarHandleFillClockwise; }
            set { ComboBoxList.VerticalScrollbarHandleFillClockwise = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleFillOriginProperty = List.VerticalScrollbarHandleFillOriginProperty;
        public System.Int32 VerticalScrollbarHandleFillOrigin
        {
            get { return ComboBoxList.VerticalScrollbarHandleFillOrigin; }
            set { ComboBoxList.VerticalScrollbarHandleFillOrigin = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleAlphaHitTestMinimumThresholdProperty = List.VerticalScrollbarHandleAlphaHitTestMinimumThresholdProperty;
        public System.Single VerticalScrollbarHandleAlphaHitTestMinimumThreshold
        {
            get { return ComboBoxList.VerticalScrollbarHandleAlphaHitTestMinimumThreshold; }
            set { ComboBoxList.VerticalScrollbarHandleAlphaHitTestMinimumThreshold = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleUseSpriteMeshProperty = List.VerticalScrollbarHandleUseSpriteMeshProperty;
        public System.Boolean VerticalScrollbarHandleUseSpriteMesh
        {
            get { return ComboBoxList.VerticalScrollbarHandleUseSpriteMesh; }
            set { ComboBoxList.VerticalScrollbarHandleUseSpriteMesh = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandlePixelsPerUnitMultiplierProperty = List.VerticalScrollbarHandlePixelsPerUnitMultiplierProperty;
        public System.Single VerticalScrollbarHandlePixelsPerUnitMultiplier
        {
            get { return ComboBoxList.VerticalScrollbarHandlePixelsPerUnitMultiplier; }
            set { ComboBoxList.VerticalScrollbarHandlePixelsPerUnitMultiplier = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleMaterialProperty = List.VerticalScrollbarHandleMaterialProperty;
        public MaterialAsset VerticalScrollbarHandleMaterial
        {
            get { return ComboBoxList.VerticalScrollbarHandleMaterial; }
            set { ComboBoxList.VerticalScrollbarHandleMaterial = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleOnCullStateChangedProperty = List.VerticalScrollbarHandleOnCullStateChangedProperty;
        public UnityEngine.UI.MaskableGraphic.CullStateChangedEvent VerticalScrollbarHandleOnCullStateChanged
        {
            get { return ComboBoxList.VerticalScrollbarHandleOnCullStateChanged; }
            set { ComboBoxList.VerticalScrollbarHandleOnCullStateChanged = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleMaskableProperty = List.VerticalScrollbarHandleMaskableProperty;
        public System.Boolean VerticalScrollbarHandleMaskable
        {
            get { return ComboBoxList.VerticalScrollbarHandleMaskable; }
            set { ComboBoxList.VerticalScrollbarHandleMaskable = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleIsMaskingGraphicProperty = List.VerticalScrollbarHandleIsMaskingGraphicProperty;
        public System.Boolean VerticalScrollbarHandleIsMaskingGraphic
        {
            get { return ComboBoxList.VerticalScrollbarHandleIsMaskingGraphic; }
            set { ComboBoxList.VerticalScrollbarHandleIsMaskingGraphic = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleColorProperty = List.VerticalScrollbarHandleColorProperty;
        public UnityEngine.Color VerticalScrollbarHandleColor
        {
            get { return ComboBoxList.VerticalScrollbarHandleColor; }
            set { ComboBoxList.VerticalScrollbarHandleColor = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleRaycastTargetProperty = List.VerticalScrollbarHandleRaycastTargetProperty;
        public System.Boolean VerticalScrollbarHandleRaycastTarget
        {
            get { return ComboBoxList.VerticalScrollbarHandleRaycastTarget; }
            set { ComboBoxList.VerticalScrollbarHandleRaycastTarget = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleWidthProperty = List.VerticalScrollbarHandleWidthProperty;
        public Delight.ElementSize VerticalScrollbarHandleWidth
        {
            get { return ComboBoxList.VerticalScrollbarHandleWidth; }
            set { ComboBoxList.VerticalScrollbarHandleWidth = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleHeightProperty = List.VerticalScrollbarHandleHeightProperty;
        public Delight.ElementSize VerticalScrollbarHandleHeight
        {
            get { return ComboBoxList.VerticalScrollbarHandleHeight; }
            set { ComboBoxList.VerticalScrollbarHandleHeight = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleOverrideWidthProperty = List.VerticalScrollbarHandleOverrideWidthProperty;
        public Delight.ElementSize VerticalScrollbarHandleOverrideWidth
        {
            get { return ComboBoxList.VerticalScrollbarHandleOverrideWidth; }
            set { ComboBoxList.VerticalScrollbarHandleOverrideWidth = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleOverrideHeightProperty = List.VerticalScrollbarHandleOverrideHeightProperty;
        public Delight.ElementSize VerticalScrollbarHandleOverrideHeight
        {
            get { return ComboBoxList.VerticalScrollbarHandleOverrideHeight; }
            set { ComboBoxList.VerticalScrollbarHandleOverrideHeight = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleScaleProperty = List.VerticalScrollbarHandleScaleProperty;
        public UnityEngine.Vector3 VerticalScrollbarHandleScale
        {
            get { return ComboBoxList.VerticalScrollbarHandleScale; }
            set { ComboBoxList.VerticalScrollbarHandleScale = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleAlignmentProperty = List.VerticalScrollbarHandleAlignmentProperty;
        public Delight.ElementAlignment VerticalScrollbarHandleAlignment
        {
            get { return ComboBoxList.VerticalScrollbarHandleAlignment; }
            set { ComboBoxList.VerticalScrollbarHandleAlignment = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleMarginProperty = List.VerticalScrollbarHandleMarginProperty;
        public Delight.ElementMargin VerticalScrollbarHandleMargin
        {
            get { return ComboBoxList.VerticalScrollbarHandleMargin; }
            set { ComboBoxList.VerticalScrollbarHandleMargin = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleOffsetProperty = List.VerticalScrollbarHandleOffsetProperty;
        public Delight.ElementMargin VerticalScrollbarHandleOffset
        {
            get { return ComboBoxList.VerticalScrollbarHandleOffset; }
            set { ComboBoxList.VerticalScrollbarHandleOffset = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleOffsetFromParentProperty = List.VerticalScrollbarHandleOffsetFromParentProperty;
        public Delight.ElementMargin VerticalScrollbarHandleOffsetFromParent
        {
            get { return ComboBoxList.VerticalScrollbarHandleOffsetFromParent; }
            set { ComboBoxList.VerticalScrollbarHandleOffsetFromParent = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandlePivotProperty = List.VerticalScrollbarHandlePivotProperty;
        public UnityEngine.Vector2 VerticalScrollbarHandlePivot
        {
            get { return ComboBoxList.VerticalScrollbarHandlePivot; }
            set { ComboBoxList.VerticalScrollbarHandlePivot = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleLayoutRootProperty = List.VerticalScrollbarHandleLayoutRootProperty;
        public Delight.LayoutRoot VerticalScrollbarHandleLayoutRoot
        {
            get { return ComboBoxList.VerticalScrollbarHandleLayoutRoot; }
            set { ComboBoxList.VerticalScrollbarHandleLayoutRoot = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleDisableLayoutUpdateProperty = List.VerticalScrollbarHandleDisableLayoutUpdateProperty;
        public System.Boolean VerticalScrollbarHandleDisableLayoutUpdate
        {
            get { return ComboBoxList.VerticalScrollbarHandleDisableLayoutUpdate; }
            set { ComboBoxList.VerticalScrollbarHandleDisableLayoutUpdate = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleAlphaProperty = List.VerticalScrollbarHandleAlphaProperty;
        public System.Single VerticalScrollbarHandleAlpha
        {
            get { return ComboBoxList.VerticalScrollbarHandleAlpha; }
            set { ComboBoxList.VerticalScrollbarHandleAlpha = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleIsVisibleProperty = List.VerticalScrollbarHandleIsVisibleProperty;
        public System.Boolean VerticalScrollbarHandleIsVisible
        {
            get { return ComboBoxList.VerticalScrollbarHandleIsVisible; }
            set { ComboBoxList.VerticalScrollbarHandleIsVisible = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleRaycastBlockModeProperty = List.VerticalScrollbarHandleRaycastBlockModeProperty;
        public Delight.RaycastBlockMode VerticalScrollbarHandleRaycastBlockMode
        {
            get { return ComboBoxList.VerticalScrollbarHandleRaycastBlockMode; }
            set { ComboBoxList.VerticalScrollbarHandleRaycastBlockMode = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleUseFastShaderProperty = List.VerticalScrollbarHandleUseFastShaderProperty;
        public System.Boolean VerticalScrollbarHandleUseFastShader
        {
            get { return ComboBoxList.VerticalScrollbarHandleUseFastShader; }
            set { ComboBoxList.VerticalScrollbarHandleUseFastShader = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleBubbleNotifyChildLayoutChangedProperty = List.VerticalScrollbarHandleBubbleNotifyChildLayoutChangedProperty;
        public System.Boolean VerticalScrollbarHandleBubbleNotifyChildLayoutChanged
        {
            get { return ComboBoxList.VerticalScrollbarHandleBubbleNotifyChildLayoutChanged; }
            set { ComboBoxList.VerticalScrollbarHandleBubbleNotifyChildLayoutChanged = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleIgnoreFlipProperty = List.VerticalScrollbarHandleIgnoreFlipProperty;
        public System.Boolean VerticalScrollbarHandleIgnoreFlip
        {
            get { return ComboBoxList.VerticalScrollbarHandleIgnoreFlip; }
            set { ComboBoxList.VerticalScrollbarHandleIgnoreFlip = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleRotationProperty = List.VerticalScrollbarHandleRotationProperty;
        public UnityEngine.Quaternion VerticalScrollbarHandleRotation
        {
            get { return ComboBoxList.VerticalScrollbarHandleRotation; }
            set { ComboBoxList.VerticalScrollbarHandleRotation = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandlePositionProperty = List.VerticalScrollbarHandlePositionProperty;
        public UnityEngine.Vector3 VerticalScrollbarHandlePosition
        {
            get { return ComboBoxList.VerticalScrollbarHandlePosition; }
            set { ComboBoxList.VerticalScrollbarHandlePosition = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleGameObjectProperty = List.VerticalScrollbarHandleGameObjectProperty;
        public UnityEngine.GameObject VerticalScrollbarHandleGameObject
        {
            get { return ComboBoxList.VerticalScrollbarHandleGameObject; }
            set { ComboBoxList.VerticalScrollbarHandleGameObject = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleEnableScriptEventsProperty = List.VerticalScrollbarHandleEnableScriptEventsProperty;
        public System.Boolean VerticalScrollbarHandleEnableScriptEvents
        {
            get { return ComboBoxList.VerticalScrollbarHandleEnableScriptEvents; }
            set { ComboBoxList.VerticalScrollbarHandleEnableScriptEvents = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleIgnoreObjectProperty = List.VerticalScrollbarHandleIgnoreObjectProperty;
        public System.Boolean VerticalScrollbarHandleIgnoreObject
        {
            get { return ComboBoxList.VerticalScrollbarHandleIgnoreObject; }
            set { ComboBoxList.VerticalScrollbarHandleIgnoreObject = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleIsActiveProperty = List.VerticalScrollbarHandleIsActiveProperty;
        public System.Boolean VerticalScrollbarHandleIsActive
        {
            get { return ComboBoxList.VerticalScrollbarHandleIsActive; }
            set { ComboBoxList.VerticalScrollbarHandleIsActive = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHandleLoadModeProperty = List.VerticalScrollbarHandleLoadModeProperty;
        public Delight.LoadMode VerticalScrollbarHandleLoadMode
        {
            get { return ComboBoxList.VerticalScrollbarHandleLoadMode; }
            set { ComboBoxList.VerticalScrollbarHandleLoadMode = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBackgroundSpriteProperty = List.VerticalScrollbarBackgroundSpriteProperty;
        public SpriteAsset VerticalScrollbarBackgroundSprite
        {
            get { return ComboBoxList.VerticalScrollbarBackgroundSprite; }
            set { ComboBoxList.VerticalScrollbarBackgroundSprite = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBackgroundOverrideSpriteProperty = List.VerticalScrollbarBackgroundOverrideSpriteProperty;
        public SpriteAsset VerticalScrollbarBackgroundOverrideSprite
        {
            get { return ComboBoxList.VerticalScrollbarBackgroundOverrideSprite; }
            set { ComboBoxList.VerticalScrollbarBackgroundOverrideSprite = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBackgroundTypeProperty = List.VerticalScrollbarBackgroundTypeProperty;
        public UnityEngine.UI.Image.Type VerticalScrollbarBackgroundType
        {
            get { return ComboBoxList.VerticalScrollbarBackgroundType; }
            set { ComboBoxList.VerticalScrollbarBackgroundType = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBackgroundPreserveAspectProperty = List.VerticalScrollbarBackgroundPreserveAspectProperty;
        public System.Boolean VerticalScrollbarBackgroundPreserveAspect
        {
            get { return ComboBoxList.VerticalScrollbarBackgroundPreserveAspect; }
            set { ComboBoxList.VerticalScrollbarBackgroundPreserveAspect = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBackgroundFillCenterProperty = List.VerticalScrollbarBackgroundFillCenterProperty;
        public System.Boolean VerticalScrollbarBackgroundFillCenter
        {
            get { return ComboBoxList.VerticalScrollbarBackgroundFillCenter; }
            set { ComboBoxList.VerticalScrollbarBackgroundFillCenter = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBackgroundFillMethodProperty = List.VerticalScrollbarBackgroundFillMethodProperty;
        public UnityEngine.UI.Image.FillMethod VerticalScrollbarBackgroundFillMethod
        {
            get { return ComboBoxList.VerticalScrollbarBackgroundFillMethod; }
            set { ComboBoxList.VerticalScrollbarBackgroundFillMethod = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBackgroundFillAmountProperty = List.VerticalScrollbarBackgroundFillAmountProperty;
        public System.Single VerticalScrollbarBackgroundFillAmount
        {
            get { return ComboBoxList.VerticalScrollbarBackgroundFillAmount; }
            set { ComboBoxList.VerticalScrollbarBackgroundFillAmount = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBackgroundFillClockwiseProperty = List.VerticalScrollbarBackgroundFillClockwiseProperty;
        public System.Boolean VerticalScrollbarBackgroundFillClockwise
        {
            get { return ComboBoxList.VerticalScrollbarBackgroundFillClockwise; }
            set { ComboBoxList.VerticalScrollbarBackgroundFillClockwise = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBackgroundFillOriginProperty = List.VerticalScrollbarBackgroundFillOriginProperty;
        public System.Int32 VerticalScrollbarBackgroundFillOrigin
        {
            get { return ComboBoxList.VerticalScrollbarBackgroundFillOrigin; }
            set { ComboBoxList.VerticalScrollbarBackgroundFillOrigin = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBackgroundAlphaHitTestMinimumThresholdProperty = List.VerticalScrollbarBackgroundAlphaHitTestMinimumThresholdProperty;
        public System.Single VerticalScrollbarBackgroundAlphaHitTestMinimumThreshold
        {
            get { return ComboBoxList.VerticalScrollbarBackgroundAlphaHitTestMinimumThreshold; }
            set { ComboBoxList.VerticalScrollbarBackgroundAlphaHitTestMinimumThreshold = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBackgroundUseSpriteMeshProperty = List.VerticalScrollbarBackgroundUseSpriteMeshProperty;
        public System.Boolean VerticalScrollbarBackgroundUseSpriteMesh
        {
            get { return ComboBoxList.VerticalScrollbarBackgroundUseSpriteMesh; }
            set { ComboBoxList.VerticalScrollbarBackgroundUseSpriteMesh = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBackgroundPixelsPerUnitMultiplierProperty = List.VerticalScrollbarBackgroundPixelsPerUnitMultiplierProperty;
        public System.Single VerticalScrollbarBackgroundPixelsPerUnitMultiplier
        {
            get { return ComboBoxList.VerticalScrollbarBackgroundPixelsPerUnitMultiplier; }
            set { ComboBoxList.VerticalScrollbarBackgroundPixelsPerUnitMultiplier = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBackgroundMaterialProperty = List.VerticalScrollbarBackgroundMaterialProperty;
        public MaterialAsset VerticalScrollbarBackgroundMaterial
        {
            get { return ComboBoxList.VerticalScrollbarBackgroundMaterial; }
            set { ComboBoxList.VerticalScrollbarBackgroundMaterial = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBackgroundOnCullStateChangedProperty = List.VerticalScrollbarBackgroundOnCullStateChangedProperty;
        public UnityEngine.UI.MaskableGraphic.CullStateChangedEvent VerticalScrollbarBackgroundOnCullStateChanged
        {
            get { return ComboBoxList.VerticalScrollbarBackgroundOnCullStateChanged; }
            set { ComboBoxList.VerticalScrollbarBackgroundOnCullStateChanged = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBackgroundMaskableProperty = List.VerticalScrollbarBackgroundMaskableProperty;
        public System.Boolean VerticalScrollbarBackgroundMaskable
        {
            get { return ComboBoxList.VerticalScrollbarBackgroundMaskable; }
            set { ComboBoxList.VerticalScrollbarBackgroundMaskable = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBackgroundIsMaskingGraphicProperty = List.VerticalScrollbarBackgroundIsMaskingGraphicProperty;
        public System.Boolean VerticalScrollbarBackgroundIsMaskingGraphic
        {
            get { return ComboBoxList.VerticalScrollbarBackgroundIsMaskingGraphic; }
            set { ComboBoxList.VerticalScrollbarBackgroundIsMaskingGraphic = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBackgroundColorProperty = List.VerticalScrollbarBackgroundColorProperty;
        public UnityEngine.Color VerticalScrollbarBackgroundColor
        {
            get { return ComboBoxList.VerticalScrollbarBackgroundColor; }
            set { ComboBoxList.VerticalScrollbarBackgroundColor = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBackgroundRaycastTargetProperty = List.VerticalScrollbarBackgroundRaycastTargetProperty;
        public System.Boolean VerticalScrollbarBackgroundRaycastTarget
        {
            get { return ComboBoxList.VerticalScrollbarBackgroundRaycastTarget; }
            set { ComboBoxList.VerticalScrollbarBackgroundRaycastTarget = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarWidthProperty = List.VerticalScrollbarWidthProperty;
        public Delight.ElementSize VerticalScrollbarWidth
        {
            get { return ComboBoxList.VerticalScrollbarWidth; }
            set { ComboBoxList.VerticalScrollbarWidth = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarHeightProperty = List.VerticalScrollbarHeightProperty;
        public Delight.ElementSize VerticalScrollbarHeight
        {
            get { return ComboBoxList.VerticalScrollbarHeight; }
            set { ComboBoxList.VerticalScrollbarHeight = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarOverrideWidthProperty = List.VerticalScrollbarOverrideWidthProperty;
        public Delight.ElementSize VerticalScrollbarOverrideWidth
        {
            get { return ComboBoxList.VerticalScrollbarOverrideWidth; }
            set { ComboBoxList.VerticalScrollbarOverrideWidth = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarOverrideHeightProperty = List.VerticalScrollbarOverrideHeightProperty;
        public Delight.ElementSize VerticalScrollbarOverrideHeight
        {
            get { return ComboBoxList.VerticalScrollbarOverrideHeight; }
            set { ComboBoxList.VerticalScrollbarOverrideHeight = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarScaleProperty = List.VerticalScrollbarScaleProperty;
        public UnityEngine.Vector3 VerticalScrollbarScale
        {
            get { return ComboBoxList.VerticalScrollbarScale; }
            set { ComboBoxList.VerticalScrollbarScale = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarAlignmentProperty = List.VerticalScrollbarAlignmentProperty;
        public Delight.ElementAlignment VerticalScrollbarAlignment
        {
            get { return ComboBoxList.VerticalScrollbarAlignment; }
            set { ComboBoxList.VerticalScrollbarAlignment = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarMarginProperty = List.VerticalScrollbarMarginProperty;
        public Delight.ElementMargin VerticalScrollbarMargin
        {
            get { return ComboBoxList.VerticalScrollbarMargin; }
            set { ComboBoxList.VerticalScrollbarMargin = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarOffsetProperty = List.VerticalScrollbarOffsetProperty;
        public Delight.ElementMargin VerticalScrollbarOffset
        {
            get { return ComboBoxList.VerticalScrollbarOffset; }
            set { ComboBoxList.VerticalScrollbarOffset = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarOffsetFromParentProperty = List.VerticalScrollbarOffsetFromParentProperty;
        public Delight.ElementMargin VerticalScrollbarOffsetFromParent
        {
            get { return ComboBoxList.VerticalScrollbarOffsetFromParent; }
            set { ComboBoxList.VerticalScrollbarOffsetFromParent = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarPivotProperty = List.VerticalScrollbarPivotProperty;
        public UnityEngine.Vector2 VerticalScrollbarPivot
        {
            get { return ComboBoxList.VerticalScrollbarPivot; }
            set { ComboBoxList.VerticalScrollbarPivot = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarLayoutRootProperty = List.VerticalScrollbarLayoutRootProperty;
        public Delight.LayoutRoot VerticalScrollbarLayoutRoot
        {
            get { return ComboBoxList.VerticalScrollbarLayoutRoot; }
            set { ComboBoxList.VerticalScrollbarLayoutRoot = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarDisableLayoutUpdateProperty = List.VerticalScrollbarDisableLayoutUpdateProperty;
        public System.Boolean VerticalScrollbarDisableLayoutUpdate
        {
            get { return ComboBoxList.VerticalScrollbarDisableLayoutUpdate; }
            set { ComboBoxList.VerticalScrollbarDisableLayoutUpdate = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarAlphaProperty = List.VerticalScrollbarAlphaProperty;
        public System.Single VerticalScrollbarAlpha
        {
            get { return ComboBoxList.VerticalScrollbarAlpha; }
            set { ComboBoxList.VerticalScrollbarAlpha = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarIsVisibleProperty = List.VerticalScrollbarIsVisibleProperty;
        public System.Boolean VerticalScrollbarIsVisible
        {
            get { return ComboBoxList.VerticalScrollbarIsVisible; }
            set { ComboBoxList.VerticalScrollbarIsVisible = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarRaycastBlockModeProperty = List.VerticalScrollbarRaycastBlockModeProperty;
        public Delight.RaycastBlockMode VerticalScrollbarRaycastBlockMode
        {
            get { return ComboBoxList.VerticalScrollbarRaycastBlockMode; }
            set { ComboBoxList.VerticalScrollbarRaycastBlockMode = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarUseFastShaderProperty = List.VerticalScrollbarUseFastShaderProperty;
        public System.Boolean VerticalScrollbarUseFastShader
        {
            get { return ComboBoxList.VerticalScrollbarUseFastShader; }
            set { ComboBoxList.VerticalScrollbarUseFastShader = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarBubbleNotifyChildLayoutChangedProperty = List.VerticalScrollbarBubbleNotifyChildLayoutChangedProperty;
        public System.Boolean VerticalScrollbarBubbleNotifyChildLayoutChanged
        {
            get { return ComboBoxList.VerticalScrollbarBubbleNotifyChildLayoutChanged; }
            set { ComboBoxList.VerticalScrollbarBubbleNotifyChildLayoutChanged = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarIgnoreFlipProperty = List.VerticalScrollbarIgnoreFlipProperty;
        public System.Boolean VerticalScrollbarIgnoreFlip
        {
            get { return ComboBoxList.VerticalScrollbarIgnoreFlip; }
            set { ComboBoxList.VerticalScrollbarIgnoreFlip = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarRotationProperty = List.VerticalScrollbarRotationProperty;
        public UnityEngine.Quaternion VerticalScrollbarRotation
        {
            get { return ComboBoxList.VerticalScrollbarRotation; }
            set { ComboBoxList.VerticalScrollbarRotation = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarPositionProperty = List.VerticalScrollbarPositionProperty;
        public UnityEngine.Vector3 VerticalScrollbarPosition
        {
            get { return ComboBoxList.VerticalScrollbarPosition; }
            set { ComboBoxList.VerticalScrollbarPosition = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarGameObjectProperty = List.VerticalScrollbarGameObjectProperty;
        public UnityEngine.GameObject VerticalScrollbarGameObject
        {
            get { return ComboBoxList.VerticalScrollbarGameObject; }
            set { ComboBoxList.VerticalScrollbarGameObject = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarEnableScriptEventsProperty = List.VerticalScrollbarEnableScriptEventsProperty;
        public System.Boolean VerticalScrollbarEnableScriptEvents
        {
            get { return ComboBoxList.VerticalScrollbarEnableScriptEvents; }
            set { ComboBoxList.VerticalScrollbarEnableScriptEvents = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarIgnoreObjectProperty = List.VerticalScrollbarIgnoreObjectProperty;
        public System.Boolean VerticalScrollbarIgnoreObject
        {
            get { return ComboBoxList.VerticalScrollbarIgnoreObject; }
            set { ComboBoxList.VerticalScrollbarIgnoreObject = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarIsActiveProperty = List.VerticalScrollbarIsActiveProperty;
        public System.Boolean VerticalScrollbarIsActive
        {
            get { return ComboBoxList.VerticalScrollbarIsActive; }
            set { ComboBoxList.VerticalScrollbarIsActive = value; }
        }

        public readonly static DependencyProperty VerticalScrollbarLoadModeProperty = List.VerticalScrollbarLoadModeProperty;
        public Delight.LoadMode VerticalScrollbarLoadMode
        {
            get { return ComboBoxList.VerticalScrollbarLoadMode; }
            set { ComboBoxList.VerticalScrollbarLoadMode = value; }
        }

        public readonly static DependencyProperty RenderCameraProperty = List.RenderCameraProperty;
        public System.String RenderCamera
        {
            get { return ComboBoxList.RenderCamera; }
            set { ComboBoxList.RenderCamera = value; }
        }

        public readonly static DependencyProperty RenderModeProperty = List.RenderModeProperty;
        public UnityEngine.RenderMode RenderMode
        {
            get { return ComboBoxList.RenderMode; }
            set { ComboBoxList.RenderMode = value; }
        }

        public readonly static DependencyProperty ScaleFactorProperty = List.ScaleFactorProperty;
        public System.Single ScaleFactor
        {
            get { return ComboBoxList.ScaleFactor; }
            set { ComboBoxList.ScaleFactor = value; }
        }

        public readonly static DependencyProperty ReferencePixelsPerUnitProperty = List.ReferencePixelsPerUnitProperty;
        public System.Single ReferencePixelsPerUnit
        {
            get { return ComboBoxList.ReferencePixelsPerUnit; }
            set { ComboBoxList.ReferencePixelsPerUnit = value; }
        }

        public readonly static DependencyProperty OverridePixelPerfectProperty = List.OverridePixelPerfectProperty;
        public System.Boolean OverridePixelPerfect
        {
            get { return ComboBoxList.OverridePixelPerfect; }
            set { ComboBoxList.OverridePixelPerfect = value; }
        }

        public readonly static DependencyProperty PixelPerfectProperty = List.PixelPerfectProperty;
        public System.Boolean PixelPerfect
        {
            get { return ComboBoxList.PixelPerfect; }
            set { ComboBoxList.PixelPerfect = value; }
        }

        public readonly static DependencyProperty PlaneDistanceProperty = List.PlaneDistanceProperty;
        public System.Single PlaneDistance
        {
            get { return ComboBoxList.PlaneDistance; }
            set { ComboBoxList.PlaneDistance = value; }
        }

        public readonly static DependencyProperty OverrideSortingProperty = List.OverrideSortingProperty;
        public System.Boolean OverrideSorting
        {
            get { return ComboBoxList.OverrideSorting; }
            set { ComboBoxList.OverrideSorting = value; }
        }

        public readonly static DependencyProperty SortingOrderProperty = List.SortingOrderProperty;
        public System.Int32 SortingOrder
        {
            get { return ComboBoxList.SortingOrder; }
            set { ComboBoxList.SortingOrder = value; }
        }

        public readonly static DependencyProperty TargetDisplayProperty = List.TargetDisplayProperty;
        public System.Int32 TargetDisplay
        {
            get { return ComboBoxList.TargetDisplay; }
            set { ComboBoxList.TargetDisplay = value; }
        }

        public readonly static DependencyProperty SortingLayerIDProperty = List.SortingLayerIDProperty;
        public System.Int32 SortingLayerID
        {
            get { return ComboBoxList.SortingLayerID; }
            set { ComboBoxList.SortingLayerID = value; }
        }

        public readonly static DependencyProperty AdditionalShaderChannelsProperty = List.AdditionalShaderChannelsProperty;
        public UnityEngine.AdditionalCanvasShaderChannels AdditionalShaderChannels
        {
            get { return ComboBoxList.AdditionalShaderChannels; }
            set { ComboBoxList.AdditionalShaderChannels = value; }
        }

        public readonly static DependencyProperty SortingLayerNameProperty = List.SortingLayerNameProperty;
        public System.String SortingLayerName
        {
            get { return ComboBoxList.SortingLayerName; }
            set { ComboBoxList.SortingLayerName = value; }
        }

        public readonly static DependencyProperty WorldCameraProperty = List.WorldCameraProperty;
        public UnityEngine.Camera WorldCamera
        {
            get { return ComboBoxList.WorldCamera; }
            set { ComboBoxList.WorldCamera = value; }
        }

        public readonly static DependencyProperty NormalizedSortingGridSizeProperty = List.NormalizedSortingGridSizeProperty;
        public System.Single NormalizedSortingGridSize
        {
            get { return ComboBoxList.NormalizedSortingGridSize; }
            set { ComboBoxList.NormalizedSortingGridSize = value; }
        }

        public readonly static DependencyProperty UiScaleModeProperty = List.UiScaleModeProperty;
        public UnityEngine.UI.CanvasScaler.ScaleMode UiScaleMode
        {
            get { return ComboBoxList.UiScaleMode; }
            set { ComboBoxList.UiScaleMode = value; }
        }

        public readonly static DependencyProperty CanvasScalerReferencePixelsPerUnitProperty = List.CanvasScalerReferencePixelsPerUnitProperty;
        public System.Single CanvasScalerReferencePixelsPerUnit
        {
            get { return ComboBoxList.CanvasScalerReferencePixelsPerUnit; }
            set { ComboBoxList.CanvasScalerReferencePixelsPerUnit = value; }
        }

        public readonly static DependencyProperty CanvasScalerScaleFactorProperty = List.CanvasScalerScaleFactorProperty;
        public System.Single CanvasScalerScaleFactor
        {
            get { return ComboBoxList.CanvasScalerScaleFactor; }
            set { ComboBoxList.CanvasScalerScaleFactor = value; }
        }

        public readonly static DependencyProperty ReferenceResolutionProperty = List.ReferenceResolutionProperty;
        public UnityEngine.Vector2 ReferenceResolution
        {
            get { return ComboBoxList.ReferenceResolution; }
            set { ComboBoxList.ReferenceResolution = value; }
        }

        public readonly static DependencyProperty ScreenMatchModeProperty = List.ScreenMatchModeProperty;
        public UnityEngine.UI.CanvasScaler.ScreenMatchMode ScreenMatchMode
        {
            get { return ComboBoxList.ScreenMatchMode; }
            set { ComboBoxList.ScreenMatchMode = value; }
        }

        public readonly static DependencyProperty MatchWidthOrHeightProperty = List.MatchWidthOrHeightProperty;
        public System.Single MatchWidthOrHeight
        {
            get { return ComboBoxList.MatchWidthOrHeight; }
            set { ComboBoxList.MatchWidthOrHeight = value; }
        }

        public readonly static DependencyProperty PhysicalUnitProperty = List.PhysicalUnitProperty;
        public UnityEngine.UI.CanvasScaler.Unit PhysicalUnit
        {
            get { return ComboBoxList.PhysicalUnit; }
            set { ComboBoxList.PhysicalUnit = value; }
        }

        public readonly static DependencyProperty FallbackScreenDPIProperty = List.FallbackScreenDPIProperty;
        public System.Single FallbackScreenDPI
        {
            get { return ComboBoxList.FallbackScreenDPI; }
            set { ComboBoxList.FallbackScreenDPI = value; }
        }

        public readonly static DependencyProperty DefaultSpriteDPIProperty = List.DefaultSpriteDPIProperty;
        public System.Single DefaultSpriteDPI
        {
            get { return ComboBoxList.DefaultSpriteDPI; }
            set { ComboBoxList.DefaultSpriteDPI = value; }
        }

        public readonly static DependencyProperty DynamicPixelsPerUnitProperty = List.DynamicPixelsPerUnitProperty;
        public System.Single DynamicPixelsPerUnit
        {
            get { return ComboBoxList.DynamicPixelsPerUnit; }
            set { ComboBoxList.DynamicPixelsPerUnit = value; }
        }

        public readonly static DependencyProperty IgnoreReversedGraphicsProperty = List.IgnoreReversedGraphicsProperty;
        public System.Boolean IgnoreReversedGraphics
        {
            get { return ComboBoxList.IgnoreReversedGraphics; }
            set { ComboBoxList.IgnoreReversedGraphics = value; }
        }

        public readonly static DependencyProperty BlockingObjectsProperty = List.BlockingObjectsProperty;
        public UnityEngine.UI.GraphicRaycaster.BlockingObjects BlockingObjects
        {
            get { return ComboBoxList.BlockingObjects; }
            set { ComboBoxList.BlockingObjects = value; }
        }

        public readonly static DependencyProperty ScrollableRegionWidthProperty = List.ScrollableRegionWidthProperty;
        public Delight.ElementSize ScrollableRegionWidth
        {
            get { return ComboBoxList.ScrollableRegionWidth; }
            set { ComboBoxList.ScrollableRegionWidth = value; }
        }

        public readonly static DependencyProperty ScrollableRegionHeightProperty = List.ScrollableRegionHeightProperty;
        public Delight.ElementSize ScrollableRegionHeight
        {
            get { return ComboBoxList.ScrollableRegionHeight; }
            set { ComboBoxList.ScrollableRegionHeight = value; }
        }

        public readonly static DependencyProperty ScrollableRegionOverrideWidthProperty = List.ScrollableRegionOverrideWidthProperty;
        public Delight.ElementSize ScrollableRegionOverrideWidth
        {
            get { return ComboBoxList.ScrollableRegionOverrideWidth; }
            set { ComboBoxList.ScrollableRegionOverrideWidth = value; }
        }

        public readonly static DependencyProperty ScrollableRegionOverrideHeightProperty = List.ScrollableRegionOverrideHeightProperty;
        public Delight.ElementSize ScrollableRegionOverrideHeight
        {
            get { return ComboBoxList.ScrollableRegionOverrideHeight; }
            set { ComboBoxList.ScrollableRegionOverrideHeight = value; }
        }

        public readonly static DependencyProperty ScrollableRegionScaleProperty = List.ScrollableRegionScaleProperty;
        public UnityEngine.Vector3 ScrollableRegionScale
        {
            get { return ComboBoxList.ScrollableRegionScale; }
            set { ComboBoxList.ScrollableRegionScale = value; }
        }

        public readonly static DependencyProperty ScrollableRegionAlignmentProperty = List.ScrollableRegionAlignmentProperty;
        public Delight.ElementAlignment ScrollableRegionAlignment
        {
            get { return ComboBoxList.ScrollableRegionAlignment; }
            set { ComboBoxList.ScrollableRegionAlignment = value; }
        }

        public readonly static DependencyProperty ScrollableRegionMarginProperty = List.ScrollableRegionMarginProperty;
        public Delight.ElementMargin ScrollableRegionMargin
        {
            get { return ComboBoxList.ScrollableRegionMargin; }
            set { ComboBoxList.ScrollableRegionMargin = value; }
        }

        public readonly static DependencyProperty ScrollableRegionOffsetProperty = List.ScrollableRegionOffsetProperty;
        public Delight.ElementMargin ScrollableRegionOffset
        {
            get { return ComboBoxList.ScrollableRegionOffset; }
            set { ComboBoxList.ScrollableRegionOffset = value; }
        }

        public readonly static DependencyProperty ScrollableRegionOffsetFromParentProperty = List.ScrollableRegionOffsetFromParentProperty;
        public Delight.ElementMargin ScrollableRegionOffsetFromParent
        {
            get { return ComboBoxList.ScrollableRegionOffsetFromParent; }
            set { ComboBoxList.ScrollableRegionOffsetFromParent = value; }
        }

        public readonly static DependencyProperty ScrollableRegionPivotProperty = List.ScrollableRegionPivotProperty;
        public UnityEngine.Vector2 ScrollableRegionPivot
        {
            get { return ComboBoxList.ScrollableRegionPivot; }
            set { ComboBoxList.ScrollableRegionPivot = value; }
        }

        public readonly static DependencyProperty ScrollableRegionLayoutRootProperty = List.ScrollableRegionLayoutRootProperty;
        public Delight.LayoutRoot ScrollableRegionLayoutRoot
        {
            get { return ComboBoxList.ScrollableRegionLayoutRoot; }
            set { ComboBoxList.ScrollableRegionLayoutRoot = value; }
        }

        public readonly static DependencyProperty ScrollableRegionDisableLayoutUpdateProperty = List.ScrollableRegionDisableLayoutUpdateProperty;
        public System.Boolean ScrollableRegionDisableLayoutUpdate
        {
            get { return ComboBoxList.ScrollableRegionDisableLayoutUpdate; }
            set { ComboBoxList.ScrollableRegionDisableLayoutUpdate = value; }
        }

        public readonly static DependencyProperty ScrollableRegionAlphaProperty = List.ScrollableRegionAlphaProperty;
        public System.Single ScrollableRegionAlpha
        {
            get { return ComboBoxList.ScrollableRegionAlpha; }
            set { ComboBoxList.ScrollableRegionAlpha = value; }
        }

        public readonly static DependencyProperty ScrollableRegionIsVisibleProperty = List.ScrollableRegionIsVisibleProperty;
        public System.Boolean ScrollableRegionIsVisible
        {
            get { return ComboBoxList.ScrollableRegionIsVisible; }
            set { ComboBoxList.ScrollableRegionIsVisible = value; }
        }

        public readonly static DependencyProperty ScrollableRegionRaycastBlockModeProperty = List.ScrollableRegionRaycastBlockModeProperty;
        public Delight.RaycastBlockMode ScrollableRegionRaycastBlockMode
        {
            get { return ComboBoxList.ScrollableRegionRaycastBlockMode; }
            set { ComboBoxList.ScrollableRegionRaycastBlockMode = value; }
        }

        public readonly static DependencyProperty ScrollableRegionUseFastShaderProperty = List.ScrollableRegionUseFastShaderProperty;
        public System.Boolean ScrollableRegionUseFastShader
        {
            get { return ComboBoxList.ScrollableRegionUseFastShader; }
            set { ComboBoxList.ScrollableRegionUseFastShader = value; }
        }

        public readonly static DependencyProperty ScrollableRegionBubbleNotifyChildLayoutChangedProperty = List.ScrollableRegionBubbleNotifyChildLayoutChangedProperty;
        public System.Boolean ScrollableRegionBubbleNotifyChildLayoutChanged
        {
            get { return ComboBoxList.ScrollableRegionBubbleNotifyChildLayoutChanged; }
            set { ComboBoxList.ScrollableRegionBubbleNotifyChildLayoutChanged = value; }
        }

        public readonly static DependencyProperty ScrollableRegionIgnoreFlipProperty = List.ScrollableRegionIgnoreFlipProperty;
        public System.Boolean ScrollableRegionIgnoreFlip
        {
            get { return ComboBoxList.ScrollableRegionIgnoreFlip; }
            set { ComboBoxList.ScrollableRegionIgnoreFlip = value; }
        }

        public readonly static DependencyProperty ScrollableRegionRotationProperty = List.ScrollableRegionRotationProperty;
        public UnityEngine.Quaternion ScrollableRegionRotation
        {
            get { return ComboBoxList.ScrollableRegionRotation; }
            set { ComboBoxList.ScrollableRegionRotation = value; }
        }

        public readonly static DependencyProperty ScrollableRegionPositionProperty = List.ScrollableRegionPositionProperty;
        public UnityEngine.Vector3 ScrollableRegionPosition
        {
            get { return ComboBoxList.ScrollableRegionPosition; }
            set { ComboBoxList.ScrollableRegionPosition = value; }
        }

        public readonly static DependencyProperty ScrollableRegionGameObjectProperty = List.ScrollableRegionGameObjectProperty;
        public UnityEngine.GameObject ScrollableRegionGameObject
        {
            get { return ComboBoxList.ScrollableRegionGameObject; }
            set { ComboBoxList.ScrollableRegionGameObject = value; }
        }

        public readonly static DependencyProperty ScrollableRegionEnableScriptEventsProperty = List.ScrollableRegionEnableScriptEventsProperty;
        public System.Boolean ScrollableRegionEnableScriptEvents
        {
            get { return ComboBoxList.ScrollableRegionEnableScriptEvents; }
            set { ComboBoxList.ScrollableRegionEnableScriptEvents = value; }
        }

        public readonly static DependencyProperty ScrollableRegionIgnoreObjectProperty = List.ScrollableRegionIgnoreObjectProperty;
        public System.Boolean ScrollableRegionIgnoreObject
        {
            get { return ComboBoxList.ScrollableRegionIgnoreObject; }
            set { ComboBoxList.ScrollableRegionIgnoreObject = value; }
        }

        public readonly static DependencyProperty ScrollableRegionIsActiveProperty = List.ScrollableRegionIsActiveProperty;
        public System.Boolean ScrollableRegionIsActive
        {
            get { return ComboBoxList.ScrollableRegionIsActive; }
            set { ComboBoxList.ScrollableRegionIsActive = value; }
        }

        public readonly static DependencyProperty ScrollableRegionLoadModeProperty = List.ScrollableRegionLoadModeProperty;
        public Delight.LoadMode ScrollableRegionLoadMode
        {
            get { return ComboBoxList.ScrollableRegionLoadMode; }
            set { ComboBoxList.ScrollableRegionLoadMode = value; }
        }

        public readonly static DependencyProperty ItemsProperty = List.ItemsProperty;
        public Delight.BindableCollection Items
        {
            get { return ComboBoxList.Items; }
            set { ComboBoxList.Items = value; }
        }

        public readonly static DependencyProperty BackgroundSpriteProperty = List.BackgroundSpriteProperty;
        public SpriteAsset BackgroundSprite
        {
            get { return ComboBoxList.BackgroundSprite; }
            set { ComboBoxList.BackgroundSprite = value; }
        }

        public readonly static DependencyProperty BackgroundOverrideSpriteProperty = List.BackgroundOverrideSpriteProperty;
        public SpriteAsset BackgroundOverrideSprite
        {
            get { return ComboBoxList.BackgroundOverrideSprite; }
            set { ComboBoxList.BackgroundOverrideSprite = value; }
        }

        public readonly static DependencyProperty BackgroundTypeProperty = List.BackgroundTypeProperty;
        public UnityEngine.UI.Image.Type BackgroundType
        {
            get { return ComboBoxList.BackgroundType; }
            set { ComboBoxList.BackgroundType = value; }
        }

        public readonly static DependencyProperty BackgroundPreserveAspectProperty = List.BackgroundPreserveAspectProperty;
        public System.Boolean BackgroundPreserveAspect
        {
            get { return ComboBoxList.BackgroundPreserveAspect; }
            set { ComboBoxList.BackgroundPreserveAspect = value; }
        }

        public readonly static DependencyProperty BackgroundFillCenterProperty = List.BackgroundFillCenterProperty;
        public System.Boolean BackgroundFillCenter
        {
            get { return ComboBoxList.BackgroundFillCenter; }
            set { ComboBoxList.BackgroundFillCenter = value; }
        }

        public readonly static DependencyProperty BackgroundFillMethodProperty = List.BackgroundFillMethodProperty;
        public UnityEngine.UI.Image.FillMethod BackgroundFillMethod
        {
            get { return ComboBoxList.BackgroundFillMethod; }
            set { ComboBoxList.BackgroundFillMethod = value; }
        }

        public readonly static DependencyProperty BackgroundFillAmountProperty = List.BackgroundFillAmountProperty;
        public System.Single BackgroundFillAmount
        {
            get { return ComboBoxList.BackgroundFillAmount; }
            set { ComboBoxList.BackgroundFillAmount = value; }
        }

        public readonly static DependencyProperty BackgroundFillClockwiseProperty = List.BackgroundFillClockwiseProperty;
        public System.Boolean BackgroundFillClockwise
        {
            get { return ComboBoxList.BackgroundFillClockwise; }
            set { ComboBoxList.BackgroundFillClockwise = value; }
        }

        public readonly static DependencyProperty BackgroundFillOriginProperty = List.BackgroundFillOriginProperty;
        public System.Int32 BackgroundFillOrigin
        {
            get { return ComboBoxList.BackgroundFillOrigin; }
            set { ComboBoxList.BackgroundFillOrigin = value; }
        }

        public readonly static DependencyProperty BackgroundAlphaHitTestMinimumThresholdProperty = List.BackgroundAlphaHitTestMinimumThresholdProperty;
        public System.Single BackgroundAlphaHitTestMinimumThreshold
        {
            get { return ComboBoxList.BackgroundAlphaHitTestMinimumThreshold; }
            set { ComboBoxList.BackgroundAlphaHitTestMinimumThreshold = value; }
        }

        public readonly static DependencyProperty BackgroundUseSpriteMeshProperty = List.BackgroundUseSpriteMeshProperty;
        public System.Boolean BackgroundUseSpriteMesh
        {
            get { return ComboBoxList.BackgroundUseSpriteMesh; }
            set { ComboBoxList.BackgroundUseSpriteMesh = value; }
        }

        public readonly static DependencyProperty BackgroundPixelsPerUnitMultiplierProperty = List.BackgroundPixelsPerUnitMultiplierProperty;
        public System.Single BackgroundPixelsPerUnitMultiplier
        {
            get { return ComboBoxList.BackgroundPixelsPerUnitMultiplier; }
            set { ComboBoxList.BackgroundPixelsPerUnitMultiplier = value; }
        }

        public readonly static DependencyProperty BackgroundMaterialProperty = List.BackgroundMaterialProperty;
        public MaterialAsset BackgroundMaterial
        {
            get { return ComboBoxList.BackgroundMaterial; }
            set { ComboBoxList.BackgroundMaterial = value; }
        }

        public readonly static DependencyProperty BackgroundOnCullStateChangedProperty = List.BackgroundOnCullStateChangedProperty;
        public UnityEngine.UI.MaskableGraphic.CullStateChangedEvent BackgroundOnCullStateChanged
        {
            get { return ComboBoxList.BackgroundOnCullStateChanged; }
            set { ComboBoxList.BackgroundOnCullStateChanged = value; }
        }

        public readonly static DependencyProperty BackgroundMaskableProperty = List.BackgroundMaskableProperty;
        public System.Boolean BackgroundMaskable
        {
            get { return ComboBoxList.BackgroundMaskable; }
            set { ComboBoxList.BackgroundMaskable = value; }
        }

        public readonly static DependencyProperty BackgroundIsMaskingGraphicProperty = List.BackgroundIsMaskingGraphicProperty;
        public System.Boolean BackgroundIsMaskingGraphic
        {
            get { return ComboBoxList.BackgroundIsMaskingGraphic; }
            set { ComboBoxList.BackgroundIsMaskingGraphic = value; }
        }

        public readonly static DependencyProperty BackgroundColorProperty = List.BackgroundColorProperty;
        public UnityEngine.Color BackgroundColor
        {
            get { return ComboBoxList.BackgroundColor; }
            set { ComboBoxList.BackgroundColor = value; }
        }

        public readonly static DependencyProperty BackgroundRaycastTargetProperty = List.BackgroundRaycastTargetProperty;
        public System.Boolean BackgroundRaycastTarget
        {
            get { return ComboBoxList.BackgroundRaycastTarget; }
            set { ComboBoxList.BackgroundRaycastTarget = value; }
        }

        public readonly static DependencyProperty ComboBoxListWidthProperty = List.WidthProperty;
        public Delight.ElementSize ComboBoxListWidth
        {
            get { return ComboBoxList.Width; }
            set { ComboBoxList.Width = value; }
        }

        public readonly static DependencyProperty ComboBoxListHeightProperty = List.HeightProperty;
        public Delight.ElementSize ComboBoxListHeight
        {
            get { return ComboBoxList.Height; }
            set { ComboBoxList.Height = value; }
        }

        public readonly static DependencyProperty ComboBoxListOverrideWidthProperty = List.OverrideWidthProperty;
        public Delight.ElementSize ComboBoxListOverrideWidth
        {
            get { return ComboBoxList.OverrideWidth; }
            set { ComboBoxList.OverrideWidth = value; }
        }

        public readonly static DependencyProperty ComboBoxListOverrideHeightProperty = List.OverrideHeightProperty;
        public Delight.ElementSize ComboBoxListOverrideHeight
        {
            get { return ComboBoxList.OverrideHeight; }
            set { ComboBoxList.OverrideHeight = value; }
        }

        public readonly static DependencyProperty ComboBoxListScaleProperty = List.ScaleProperty;
        public UnityEngine.Vector3 ComboBoxListScale
        {
            get { return ComboBoxList.Scale; }
            set { ComboBoxList.Scale = value; }
        }

        public readonly static DependencyProperty ComboBoxListAlignmentProperty = List.AlignmentProperty;
        public Delight.ElementAlignment ComboBoxListAlignment
        {
            get { return ComboBoxList.Alignment; }
            set { ComboBoxList.Alignment = value; }
        }

        public readonly static DependencyProperty ComboBoxListMarginProperty = List.MarginProperty;
        public Delight.ElementMargin ComboBoxListMargin
        {
            get { return ComboBoxList.Margin; }
            set { ComboBoxList.Margin = value; }
        }

        public readonly static DependencyProperty ComboBoxListOffsetProperty = List.OffsetProperty;
        public Delight.ElementMargin ComboBoxListOffset
        {
            get { return ComboBoxList.Offset; }
            set { ComboBoxList.Offset = value; }
        }

        public readonly static DependencyProperty ComboBoxListOffsetFromParentProperty = List.OffsetFromParentProperty;
        public Delight.ElementMargin ComboBoxListOffsetFromParent
        {
            get { return ComboBoxList.OffsetFromParent; }
            set { ComboBoxList.OffsetFromParent = value; }
        }

        public readonly static DependencyProperty ComboBoxListPivotProperty = List.PivotProperty;
        public UnityEngine.Vector2 ComboBoxListPivot
        {
            get { return ComboBoxList.Pivot; }
            set { ComboBoxList.Pivot = value; }
        }

        public readonly static DependencyProperty ComboBoxListLayoutRootProperty = List.LayoutRootProperty;
        public Delight.LayoutRoot ComboBoxListLayoutRoot
        {
            get { return ComboBoxList.LayoutRoot; }
            set { ComboBoxList.LayoutRoot = value; }
        }

        public readonly static DependencyProperty ComboBoxListDisableLayoutUpdateProperty = List.DisableLayoutUpdateProperty;
        public System.Boolean ComboBoxListDisableLayoutUpdate
        {
            get { return ComboBoxList.DisableLayoutUpdate; }
            set { ComboBoxList.DisableLayoutUpdate = value; }
        }

        public readonly static DependencyProperty ComboBoxListAlphaProperty = List.AlphaProperty;
        public System.Single ComboBoxListAlpha
        {
            get { return ComboBoxList.Alpha; }
            set { ComboBoxList.Alpha = value; }
        }

        public readonly static DependencyProperty ComboBoxListIsVisibleProperty = List.IsVisibleProperty;
        public System.Boolean ComboBoxListIsVisible
        {
            get { return ComboBoxList.IsVisible; }
            set { ComboBoxList.IsVisible = value; }
        }

        public readonly static DependencyProperty ComboBoxListRaycastBlockModeProperty = List.RaycastBlockModeProperty;
        public Delight.RaycastBlockMode ComboBoxListRaycastBlockMode
        {
            get { return ComboBoxList.RaycastBlockMode; }
            set { ComboBoxList.RaycastBlockMode = value; }
        }

        public readonly static DependencyProperty ComboBoxListUseFastShaderProperty = List.UseFastShaderProperty;
        public System.Boolean ComboBoxListUseFastShader
        {
            get { return ComboBoxList.UseFastShader; }
            set { ComboBoxList.UseFastShader = value; }
        }

        public readonly static DependencyProperty ComboBoxListBubbleNotifyChildLayoutChangedProperty = List.BubbleNotifyChildLayoutChangedProperty;
        public System.Boolean ComboBoxListBubbleNotifyChildLayoutChanged
        {
            get { return ComboBoxList.BubbleNotifyChildLayoutChanged; }
            set { ComboBoxList.BubbleNotifyChildLayoutChanged = value; }
        }

        public readonly static DependencyProperty ComboBoxListIgnoreFlipProperty = List.IgnoreFlipProperty;
        public System.Boolean ComboBoxListIgnoreFlip
        {
            get { return ComboBoxList.IgnoreFlip; }
            set { ComboBoxList.IgnoreFlip = value; }
        }

        public readonly static DependencyProperty ComboBoxListRotationProperty = List.RotationProperty;
        public UnityEngine.Quaternion ComboBoxListRotation
        {
            get { return ComboBoxList.Rotation; }
            set { ComboBoxList.Rotation = value; }
        }

        public readonly static DependencyProperty ComboBoxListPositionProperty = List.PositionProperty;
        public UnityEngine.Vector3 ComboBoxListPosition
        {
            get { return ComboBoxList.Position; }
            set { ComboBoxList.Position = value; }
        }

        public readonly static DependencyProperty ComboBoxListGameObjectProperty = List.GameObjectProperty;
        public UnityEngine.GameObject ComboBoxListGameObject
        {
            get { return ComboBoxList.GameObject; }
            set { ComboBoxList.GameObject = value; }
        }

        public readonly static DependencyProperty ComboBoxListEnableScriptEventsProperty = List.EnableScriptEventsProperty;
        public System.Boolean ComboBoxListEnableScriptEvents
        {
            get { return ComboBoxList.EnableScriptEvents; }
            set { ComboBoxList.EnableScriptEvents = value; }
        }

        public readonly static DependencyProperty ComboBoxListIgnoreObjectProperty = List.IgnoreObjectProperty;
        public System.Boolean ComboBoxListIgnoreObject
        {
            get { return ComboBoxList.IgnoreObject; }
            set { ComboBoxList.IgnoreObject = value; }
        }

        public readonly static DependencyProperty ComboBoxListIsActiveProperty = List.IsActiveProperty;
        public System.Boolean ComboBoxListIsActive
        {
            get { return ComboBoxList.IsActive; }
            set { ComboBoxList.IsActive = value; }
        }

        public readonly static DependencyProperty ComboBoxListLoadModeProperty = List.LoadModeProperty;
        public Delight.LoadMode ComboBoxListLoadMode
        {
            get { return ComboBoxList.LoadMode; }
            set { ComboBoxList.LoadMode = value; }
        }

        public readonly static DependencyProperty ButtonDefaultWidthProperty = Button.DefaultWidthProperty;
        public Delight.ElementSize ButtonDefaultWidth
        {
            get { return ComboBoxButton.DefaultWidth; }
            set { ComboBoxButton.DefaultWidth = value; }
        }

        public readonly static DependencyProperty ButtonIsToggleButtonProperty = Button.IsToggleButtonProperty;
        public System.Boolean ButtonIsToggleButton
        {
            get { return ComboBoxButton.IsToggleButton; }
            set { ComboBoxButton.IsToggleButton = value; }
        }

        public readonly static DependencyProperty ButtonIsDisabledProperty = Button.IsDisabledProperty;
        public System.Boolean ButtonIsDisabled
        {
            get { return ComboBoxButton.IsDisabled; }
            set { ComboBoxButton.IsDisabled = value; }
        }

        public readonly static DependencyProperty ButtonToggleValueProperty = Button.ToggleValueProperty;
        public System.Boolean ButtonToggleValue
        {
            get { return ComboBoxButton.ToggleValue; }
            set { ComboBoxButton.ToggleValue = value; }
        }

        public readonly static DependencyProperty ButtonTextPaddingProperty = Button.TextPaddingProperty;
        public Delight.ElementMargin ButtonTextPadding
        {
            get { return ComboBoxButton.TextPadding; }
            set { ComboBoxButton.TextPadding = value; }
        }

        public readonly static DependencyProperty ButtonCanToggleOnProperty = Button.CanToggleOnProperty;
        public System.Boolean ButtonCanToggleOn
        {
            get { return ComboBoxButton.CanToggleOn; }
            set { ComboBoxButton.CanToggleOn = value; }
        }

        public readonly static DependencyProperty ButtonCanToggleOffProperty = Button.CanToggleOffProperty;
        public System.Boolean ButtonCanToggleOff
        {
            get { return ComboBoxButton.CanToggleOff; }
            set { ComboBoxButton.CanToggleOff = value; }
        }

        public readonly static DependencyProperty ButtonIsMouseOverProperty = Button.IsMouseOverProperty;
        public System.Boolean ButtonIsMouseOver
        {
            get { return ComboBoxButton.IsMouseOver; }
            set { ComboBoxButton.IsMouseOver = value; }
        }

        public readonly static DependencyProperty ButtonIsPressedProperty = Button.IsPressedProperty;
        public System.Boolean ButtonIsPressed
        {
            get { return ComboBoxButton.IsPressed; }
            set { ComboBoxButton.IsPressed = value; }
        }

        public readonly static DependencyProperty ButtonAutoSizeProperty = Button.AutoSizeProperty;
        public Delight.AutoSize ButtonAutoSize
        {
            get { return ComboBoxButton.AutoSize; }
            set { ComboBoxButton.AutoSize = value; }
        }

        public readonly static DependencyProperty ButtonTextOffsetProperty = Button.TextOffsetProperty;
        public Delight.ElementMargin ButtonTextOffset
        {
            get { return ComboBoxButton.TextOffset; }
            set { ComboBoxButton.TextOffset = value; }
        }

        public readonly static DependencyProperty ButtonIsCloseButtonProperty = Button.IsCloseButtonProperty;
        public System.Boolean ButtonIsCloseButton
        {
            get { return ComboBoxButton.IsCloseButton; }
            set { ComboBoxButton.IsCloseButton = value; }
        }

        public readonly static DependencyProperty ButtonIsBackButtonProperty = Button.IsBackButtonProperty;
        public System.Boolean ButtonIsBackButton
        {
            get { return ComboBoxButton.IsBackButton; }
            set { ComboBoxButton.IsBackButton = value; }
        }

        public readonly static DependencyProperty ButtonLabelAutoSizeProperty = Button.LabelAutoSizeProperty;
        public Delight.AutoSize ButtonLabelAutoSize
        {
            get { return ComboBoxButton.LabelAutoSize; }
            set { ComboBoxButton.LabelAutoSize = value; }
        }

        public readonly static DependencyProperty ButtonAutoSizeTextContainerProperty = Button.AutoSizeTextContainerProperty;
        public System.Boolean ButtonAutoSizeTextContainer
        {
            get { return ComboBoxButton.AutoSizeTextContainer; }
            set { ComboBoxButton.AutoSizeTextContainer = value; }
        }

        public readonly static DependencyProperty ButtonMaskOffsetProperty = Button.MaskOffsetProperty;
        public UnityEngine.Vector4 ButtonMaskOffset
        {
            get { return ComboBoxButton.MaskOffset; }
            set { ComboBoxButton.MaskOffset = value; }
        }

        public readonly static DependencyProperty ButtonTextProperty = Button.TextProperty;
        public System.String ButtonText
        {
            get { return ComboBoxButton.Text; }
            set { ComboBoxButton.Text = value; }
        }

        public readonly static DependencyProperty ButtonIsRightToLeftTextProperty = Button.IsRightToLeftTextProperty;
        public System.Boolean ButtonIsRightToLeftText
        {
            get { return ComboBoxButton.IsRightToLeftText; }
            set { ComboBoxButton.IsRightToLeftText = value; }
        }

        public readonly static DependencyProperty ButtonFontProperty = Button.FontProperty;
        public TMP_FontAsset ButtonFont
        {
            get { return ComboBoxButton.Font; }
            set { ComboBoxButton.Font = value; }
        }

        public readonly static DependencyProperty ButtonFontSharedMaterialProperty = Button.FontSharedMaterialProperty;
        public MaterialAsset ButtonFontSharedMaterial
        {
            get { return ComboBoxButton.FontSharedMaterial; }
            set { ComboBoxButton.FontSharedMaterial = value; }
        }

        public readonly static DependencyProperty ButtonFontSharedMaterialsProperty = Button.FontSharedMaterialsProperty;
        public UnityEngine.Material[] ButtonFontSharedMaterials
        {
            get { return ComboBoxButton.FontSharedMaterials; }
            set { ComboBoxButton.FontSharedMaterials = value; }
        }

        public readonly static DependencyProperty ButtonFontMaterialProperty = Button.FontMaterialProperty;
        public MaterialAsset ButtonFontMaterial
        {
            get { return ComboBoxButton.FontMaterial; }
            set { ComboBoxButton.FontMaterial = value; }
        }

        public readonly static DependencyProperty ButtonFontMaterialsProperty = Button.FontMaterialsProperty;
        public UnityEngine.Material[] ButtonFontMaterials
        {
            get { return ComboBoxButton.FontMaterials; }
            set { ComboBoxButton.FontMaterials = value; }
        }

        public readonly static DependencyProperty ButtonFontColorProperty = Button.FontColorProperty;
        public UnityEngine.Color ButtonFontColor
        {
            get { return ComboBoxButton.FontColor; }
            set { ComboBoxButton.FontColor = value; }
        }

        public readonly static DependencyProperty ButtonTextMeshProUGUIAlphaProperty = Button.TextMeshProUGUIAlphaProperty;
        public System.Single ButtonTextMeshProUGUIAlpha
        {
            get { return ComboBoxButton.TextMeshProUGUIAlpha; }
            set { ComboBoxButton.TextMeshProUGUIAlpha = value; }
        }

        public readonly static DependencyProperty ButtonEnableVertexGradientProperty = Button.EnableVertexGradientProperty;
        public System.Boolean ButtonEnableVertexGradient
        {
            get { return ComboBoxButton.EnableVertexGradient; }
            set { ComboBoxButton.EnableVertexGradient = value; }
        }

        public readonly static DependencyProperty ButtonColorGradientProperty = Button.ColorGradientProperty;
        public TMPro.VertexGradient ButtonColorGradient
        {
            get { return ComboBoxButton.ColorGradient; }
            set { ComboBoxButton.ColorGradient = value; }
        }

        public readonly static DependencyProperty ButtonColorGradientPresetProperty = Button.ColorGradientPresetProperty;
        public TMP_ColorGradientAsset ButtonColorGradientPreset
        {
            get { return ComboBoxButton.ColorGradientPreset; }
            set { ComboBoxButton.ColorGradientPreset = value; }
        }

        public readonly static DependencyProperty ButtonSpriteAssetProperty = Button.SpriteAssetProperty;
        public TMP_SpriteAsset ButtonSpriteAsset
        {
            get { return ComboBoxButton.SpriteAsset; }
            set { ComboBoxButton.SpriteAsset = value; }
        }

        public readonly static DependencyProperty ButtonTintAllSpritesProperty = Button.TintAllSpritesProperty;
        public System.Boolean ButtonTintAllSprites
        {
            get { return ComboBoxButton.TintAllSprites; }
            set { ComboBoxButton.TintAllSprites = value; }
        }

        public readonly static DependencyProperty ButtonOverrideColorTagsProperty = Button.OverrideColorTagsProperty;
        public System.Boolean ButtonOverrideColorTags
        {
            get { return ComboBoxButton.OverrideColorTags; }
            set { ComboBoxButton.OverrideColorTags = value; }
        }

        public readonly static DependencyProperty ButtonFaceColorProperty = Button.FaceColorProperty;
        public UnityEngine.Color32 ButtonFaceColor
        {
            get { return ComboBoxButton.FaceColor; }
            set { ComboBoxButton.FaceColor = value; }
        }

        public readonly static DependencyProperty ButtonOutlineColorProperty = Button.OutlineColorProperty;
        public UnityEngine.Color32 ButtonOutlineColor
        {
            get { return ComboBoxButton.OutlineColor; }
            set { ComboBoxButton.OutlineColor = value; }
        }

        public readonly static DependencyProperty ButtonOutlineWidthProperty = Button.OutlineWidthProperty;
        public System.Single ButtonOutlineWidth
        {
            get { return ComboBoxButton.OutlineWidth; }
            set { ComboBoxButton.OutlineWidth = value; }
        }

        public readonly static DependencyProperty ButtonFontSizeProperty = Button.FontSizeProperty;
        public System.Single ButtonFontSize
        {
            get { return ComboBoxButton.FontSize; }
            set { ComboBoxButton.FontSize = value; }
        }

        public readonly static DependencyProperty ButtonFontWeightProperty = Button.FontWeightProperty;
        public TMPro.FontWeight ButtonFontWeight
        {
            get { return ComboBoxButton.FontWeight; }
            set { ComboBoxButton.FontWeight = value; }
        }

        public readonly static DependencyProperty ButtonEnableAutoSizingProperty = Button.EnableAutoSizingProperty;
        public System.Boolean ButtonEnableAutoSizing
        {
            get { return ComboBoxButton.EnableAutoSizing; }
            set { ComboBoxButton.EnableAutoSizing = value; }
        }

        public readonly static DependencyProperty ButtonFontSizeMinProperty = Button.FontSizeMinProperty;
        public System.Single ButtonFontSizeMin
        {
            get { return ComboBoxButton.FontSizeMin; }
            set { ComboBoxButton.FontSizeMin = value; }
        }

        public readonly static DependencyProperty ButtonFontSizeMaxProperty = Button.FontSizeMaxProperty;
        public System.Single ButtonFontSizeMax
        {
            get { return ComboBoxButton.FontSizeMax; }
            set { ComboBoxButton.FontSizeMax = value; }
        }

        public readonly static DependencyProperty ButtonFontStyleProperty = Button.FontStyleProperty;
        public TMPro.FontStyles ButtonFontStyle
        {
            get { return ComboBoxButton.FontStyle; }
            set { ComboBoxButton.FontStyle = value; }
        }

        public readonly static DependencyProperty ButtonTextAlignmentProperty = Button.TextAlignmentProperty;
        public TMPro.TextAlignmentOptions ButtonTextAlignment
        {
            get { return ComboBoxButton.TextAlignment; }
            set { ComboBoxButton.TextAlignment = value; }
        }

        public readonly static DependencyProperty ButtonCharacterSpacingProperty = Button.CharacterSpacingProperty;
        public System.Single ButtonCharacterSpacing
        {
            get { return ComboBoxButton.CharacterSpacing; }
            set { ComboBoxButton.CharacterSpacing = value; }
        }

        public readonly static DependencyProperty ButtonWordSpacingProperty = Button.WordSpacingProperty;
        public System.Single ButtonWordSpacing
        {
            get { return ComboBoxButton.WordSpacing; }
            set { ComboBoxButton.WordSpacing = value; }
        }

        public readonly static DependencyProperty ButtonLineSpacingProperty = Button.LineSpacingProperty;
        public System.Single ButtonLineSpacing
        {
            get { return ComboBoxButton.LineSpacing; }
            set { ComboBoxButton.LineSpacing = value; }
        }

        public readonly static DependencyProperty ButtonLineSpacingAdjustmentProperty = Button.LineSpacingAdjustmentProperty;
        public System.Single ButtonLineSpacingAdjustment
        {
            get { return ComboBoxButton.LineSpacingAdjustment; }
            set { ComboBoxButton.LineSpacingAdjustment = value; }
        }

        public readonly static DependencyProperty ButtonParagraphSpacingProperty = Button.ParagraphSpacingProperty;
        public System.Single ButtonParagraphSpacing
        {
            get { return ComboBoxButton.ParagraphSpacing; }
            set { ComboBoxButton.ParagraphSpacing = value; }
        }

        public readonly static DependencyProperty ButtonCharacterWidthAdjustmentProperty = Button.CharacterWidthAdjustmentProperty;
        public System.Single ButtonCharacterWidthAdjustment
        {
            get { return ComboBoxButton.CharacterWidthAdjustment; }
            set { ComboBoxButton.CharacterWidthAdjustment = value; }
        }

        public readonly static DependencyProperty ButtonEnableWordWrappingProperty = Button.EnableWordWrappingProperty;
        public System.Boolean ButtonEnableWordWrapping
        {
            get { return ComboBoxButton.EnableWordWrapping; }
            set { ComboBoxButton.EnableWordWrapping = value; }
        }

        public readonly static DependencyProperty ButtonWordWrappingRatiosProperty = Button.WordWrappingRatiosProperty;
        public System.Single ButtonWordWrappingRatios
        {
            get { return ComboBoxButton.WordWrappingRatios; }
            set { ComboBoxButton.WordWrappingRatios = value; }
        }

        public readonly static DependencyProperty ButtonOverflowModeProperty = Button.OverflowModeProperty;
        public TMPro.TextOverflowModes ButtonOverflowMode
        {
            get { return ComboBoxButton.OverflowMode; }
            set { ComboBoxButton.OverflowMode = value; }
        }

        public readonly static DependencyProperty ButtonLinkedTextComponentProperty = Button.LinkedTextComponentProperty;
        public TMPro.TMP_Text ButtonLinkedTextComponent
        {
            get { return ComboBoxButton.LinkedTextComponent; }
            set { ComboBoxButton.LinkedTextComponent = value; }
        }

        public readonly static DependencyProperty ButtonIsLinkedTextComponentProperty = Button.IsLinkedTextComponentProperty;
        public System.Boolean ButtonIsLinkedTextComponent
        {
            get { return ComboBoxButton.IsLinkedTextComponent; }
            set { ComboBoxButton.IsLinkedTextComponent = value; }
        }

        public readonly static DependencyProperty ButtonEnableKerningProperty = Button.EnableKerningProperty;
        public System.Boolean ButtonEnableKerning
        {
            get { return ComboBoxButton.EnableKerning; }
            set { ComboBoxButton.EnableKerning = value; }
        }

        public readonly static DependencyProperty ButtonExtraPaddingProperty = Button.ExtraPaddingProperty;
        public System.Boolean ButtonExtraPadding
        {
            get { return ComboBoxButton.ExtraPadding; }
            set { ComboBoxButton.ExtraPadding = value; }
        }

        public readonly static DependencyProperty ButtonRichTextProperty = Button.RichTextProperty;
        public System.Boolean ButtonRichText
        {
            get { return ComboBoxButton.RichText; }
            set { ComboBoxButton.RichText = value; }
        }

        public readonly static DependencyProperty ButtonParseCtrlCharactersProperty = Button.ParseCtrlCharactersProperty;
        public System.Boolean ButtonParseCtrlCharacters
        {
            get { return ComboBoxButton.ParseCtrlCharacters; }
            set { ComboBoxButton.ParseCtrlCharacters = value; }
        }

        public readonly static DependencyProperty ButtonIsOverlayProperty = Button.IsOverlayProperty;
        public System.Boolean ButtonIsOverlay
        {
            get { return ComboBoxButton.IsOverlay; }
            set { ComboBoxButton.IsOverlay = value; }
        }

        public readonly static DependencyProperty ButtonIsOrthographicProperty = Button.IsOrthographicProperty;
        public System.Boolean ButtonIsOrthographic
        {
            get { return ComboBoxButton.IsOrthographic; }
            set { ComboBoxButton.IsOrthographic = value; }
        }

        public readonly static DependencyProperty ButtonEnableCullingProperty = Button.EnableCullingProperty;
        public System.Boolean ButtonEnableCulling
        {
            get { return ComboBoxButton.EnableCulling; }
            set { ComboBoxButton.EnableCulling = value; }
        }

        public readonly static DependencyProperty ButtonIgnoreRectMaskCullingProperty = Button.IgnoreRectMaskCullingProperty;
        public System.Boolean ButtonIgnoreRectMaskCulling
        {
            get { return ComboBoxButton.IgnoreRectMaskCulling; }
            set { ComboBoxButton.IgnoreRectMaskCulling = value; }
        }

        public readonly static DependencyProperty ButtonIgnoreVisibilityProperty = Button.IgnoreVisibilityProperty;
        public System.Boolean ButtonIgnoreVisibility
        {
            get { return ComboBoxButton.IgnoreVisibility; }
            set { ComboBoxButton.IgnoreVisibility = value; }
        }

        public readonly static DependencyProperty ButtonHorizontalMappingProperty = Button.HorizontalMappingProperty;
        public TMPro.TextureMappingOptions ButtonHorizontalMapping
        {
            get { return ComboBoxButton.HorizontalMapping; }
            set { ComboBoxButton.HorizontalMapping = value; }
        }

        public readonly static DependencyProperty ButtonVerticalMappingProperty = Button.VerticalMappingProperty;
        public TMPro.TextureMappingOptions ButtonVerticalMapping
        {
            get { return ComboBoxButton.VerticalMapping; }
            set { ComboBoxButton.VerticalMapping = value; }
        }

        public readonly static DependencyProperty ButtonMappingUvLineOffsetProperty = Button.MappingUvLineOffsetProperty;
        public System.Single ButtonMappingUvLineOffset
        {
            get { return ComboBoxButton.MappingUvLineOffset; }
            set { ComboBoxButton.MappingUvLineOffset = value; }
        }

        public readonly static DependencyProperty ButtonRenderModeProperty = Button.RenderModeProperty;
        public TMPro.TextRenderFlags ButtonRenderMode
        {
            get { return ComboBoxButton.RenderMode; }
            set { ComboBoxButton.RenderMode = value; }
        }

        public readonly static DependencyProperty ButtonGeometrySortingOrderProperty = Button.GeometrySortingOrderProperty;
        public TMPro.VertexSortingOrder ButtonGeometrySortingOrder
        {
            get { return ComboBoxButton.GeometrySortingOrder; }
            set { ComboBoxButton.GeometrySortingOrder = value; }
        }

        public readonly static DependencyProperty ButtonVertexBufferAutoSizeReductionProperty = Button.VertexBufferAutoSizeReductionProperty;
        public System.Boolean ButtonVertexBufferAutoSizeReduction
        {
            get { return ComboBoxButton.VertexBufferAutoSizeReduction; }
            set { ComboBoxButton.VertexBufferAutoSizeReduction = value; }
        }

        public readonly static DependencyProperty ButtonFirstVisibleCharacterProperty = Button.FirstVisibleCharacterProperty;
        public System.Int32 ButtonFirstVisibleCharacter
        {
            get { return ComboBoxButton.FirstVisibleCharacter; }
            set { ComboBoxButton.FirstVisibleCharacter = value; }
        }

        public readonly static DependencyProperty ButtonMaxVisibleCharactersProperty = Button.MaxVisibleCharactersProperty;
        public System.Int32 ButtonMaxVisibleCharacters
        {
            get { return ComboBoxButton.MaxVisibleCharacters; }
            set { ComboBoxButton.MaxVisibleCharacters = value; }
        }

        public readonly static DependencyProperty ButtonMaxVisibleWordsProperty = Button.MaxVisibleWordsProperty;
        public System.Int32 ButtonMaxVisibleWords
        {
            get { return ComboBoxButton.MaxVisibleWords; }
            set { ComboBoxButton.MaxVisibleWords = value; }
        }

        public readonly static DependencyProperty ButtonMaxVisibleLinesProperty = Button.MaxVisibleLinesProperty;
        public System.Int32 ButtonMaxVisibleLines
        {
            get { return ComboBoxButton.MaxVisibleLines; }
            set { ComboBoxButton.MaxVisibleLines = value; }
        }

        public readonly static DependencyProperty ButtonUseMaxVisibleDescenderProperty = Button.UseMaxVisibleDescenderProperty;
        public System.Boolean ButtonUseMaxVisibleDescender
        {
            get { return ComboBoxButton.UseMaxVisibleDescender; }
            set { ComboBoxButton.UseMaxVisibleDescender = value; }
        }

        public readonly static DependencyProperty ButtonPageToDisplayProperty = Button.PageToDisplayProperty;
        public System.Int32 ButtonPageToDisplay
        {
            get { return ComboBoxButton.PageToDisplay; }
            set { ComboBoxButton.PageToDisplay = value; }
        }

        public readonly static DependencyProperty ButtonTextMarginProperty = Button.TextMarginProperty;
        public UnityEngine.Vector4 ButtonTextMargin
        {
            get { return ComboBoxButton.TextMargin; }
            set { ComboBoxButton.TextMargin = value; }
        }

        public readonly static DependencyProperty ButtonHavePropertiesChangedProperty = Button.HavePropertiesChangedProperty;
        public System.Boolean ButtonHavePropertiesChanged
        {
            get { return ComboBoxButton.HavePropertiesChanged; }
            set { ComboBoxButton.HavePropertiesChanged = value; }
        }

        public readonly static DependencyProperty ButtonIsUsingLegacyAnimationComponentProperty = Button.IsUsingLegacyAnimationComponentProperty;
        public System.Boolean ButtonIsUsingLegacyAnimationComponent
        {
            get { return ComboBoxButton.IsUsingLegacyAnimationComponent; }
            set { ComboBoxButton.IsUsingLegacyAnimationComponent = value; }
        }

        public readonly static DependencyProperty ButtonIsVolumetricTextProperty = Button.IsVolumetricTextProperty;
        public System.Boolean ButtonIsVolumetricText
        {
            get { return ComboBoxButton.IsVolumetricText; }
            set { ComboBoxButton.IsVolumetricText = value; }
        }

        public readonly static DependencyProperty ButtonOnCullStateChangedProperty = Button.OnCullStateChangedProperty;
        public UnityEngine.UI.MaskableGraphic.CullStateChangedEvent ButtonOnCullStateChanged
        {
            get { return ComboBoxButton.OnCullStateChanged; }
            set { ComboBoxButton.OnCullStateChanged = value; }
        }

        public readonly static DependencyProperty ButtonMaskableProperty = Button.MaskableProperty;
        public System.Boolean ButtonMaskable
        {
            get { return ComboBoxButton.Maskable; }
            set { ComboBoxButton.Maskable = value; }
        }

        public readonly static DependencyProperty ButtonIsMaskingGraphicProperty = Button.IsMaskingGraphicProperty;
        public System.Boolean ButtonIsMaskingGraphic
        {
            get { return ComboBoxButton.IsMaskingGraphic; }
            set { ComboBoxButton.IsMaskingGraphic = value; }
        }

        public readonly static DependencyProperty ButtonRaycastTargetProperty = Button.RaycastTargetProperty;
        public System.Boolean ButtonRaycastTarget
        {
            get { return ComboBoxButton.RaycastTarget; }
            set { ComboBoxButton.RaycastTarget = value; }
        }

        public readonly static DependencyProperty ButtonMaterialProperty = Button.MaterialProperty;
        public MaterialAsset ButtonMaterial
        {
            get { return ComboBoxButton.Material; }
            set { ComboBoxButton.Material = value; }
        }

        public readonly static DependencyProperty ButtonLabelWidthProperty = Button.LabelWidthProperty;
        public Delight.ElementSize ButtonLabelWidth
        {
            get { return ComboBoxButton.LabelWidth; }
            set { ComboBoxButton.LabelWidth = value; }
        }

        public readonly static DependencyProperty ButtonLabelHeightProperty = Button.LabelHeightProperty;
        public Delight.ElementSize ButtonLabelHeight
        {
            get { return ComboBoxButton.LabelHeight; }
            set { ComboBoxButton.LabelHeight = value; }
        }

        public readonly static DependencyProperty ButtonLabelOverrideWidthProperty = Button.LabelOverrideWidthProperty;
        public Delight.ElementSize ButtonLabelOverrideWidth
        {
            get { return ComboBoxButton.LabelOverrideWidth; }
            set { ComboBoxButton.LabelOverrideWidth = value; }
        }

        public readonly static DependencyProperty ButtonLabelOverrideHeightProperty = Button.LabelOverrideHeightProperty;
        public Delight.ElementSize ButtonLabelOverrideHeight
        {
            get { return ComboBoxButton.LabelOverrideHeight; }
            set { ComboBoxButton.LabelOverrideHeight = value; }
        }

        public readonly static DependencyProperty ButtonLabelScaleProperty = Button.LabelScaleProperty;
        public UnityEngine.Vector3 ButtonLabelScale
        {
            get { return ComboBoxButton.LabelScale; }
            set { ComboBoxButton.LabelScale = value; }
        }

        public readonly static DependencyProperty ButtonLabelAlignmentProperty = Button.LabelAlignmentProperty;
        public Delight.ElementAlignment ButtonLabelAlignment
        {
            get { return ComboBoxButton.LabelAlignment; }
            set { ComboBoxButton.LabelAlignment = value; }
        }

        public readonly static DependencyProperty ButtonLabelMarginProperty = Button.LabelMarginProperty;
        public Delight.ElementMargin ButtonLabelMargin
        {
            get { return ComboBoxButton.LabelMargin; }
            set { ComboBoxButton.LabelMargin = value; }
        }

        public readonly static DependencyProperty ButtonLabelOffsetProperty = Button.LabelOffsetProperty;
        public Delight.ElementMargin ButtonLabelOffset
        {
            get { return ComboBoxButton.LabelOffset; }
            set { ComboBoxButton.LabelOffset = value; }
        }

        public readonly static DependencyProperty ButtonLabelOffsetFromParentProperty = Button.LabelOffsetFromParentProperty;
        public Delight.ElementMargin ButtonLabelOffsetFromParent
        {
            get { return ComboBoxButton.LabelOffsetFromParent; }
            set { ComboBoxButton.LabelOffsetFromParent = value; }
        }

        public readonly static DependencyProperty ButtonLabelPivotProperty = Button.LabelPivotProperty;
        public UnityEngine.Vector2 ButtonLabelPivot
        {
            get { return ComboBoxButton.LabelPivot; }
            set { ComboBoxButton.LabelPivot = value; }
        }

        public readonly static DependencyProperty ButtonLabelLayoutRootProperty = Button.LabelLayoutRootProperty;
        public Delight.LayoutRoot ButtonLabelLayoutRoot
        {
            get { return ComboBoxButton.LabelLayoutRoot; }
            set { ComboBoxButton.LabelLayoutRoot = value; }
        }

        public readonly static DependencyProperty ButtonLabelDisableLayoutUpdateProperty = Button.LabelDisableLayoutUpdateProperty;
        public System.Boolean ButtonLabelDisableLayoutUpdate
        {
            get { return ComboBoxButton.LabelDisableLayoutUpdate; }
            set { ComboBoxButton.LabelDisableLayoutUpdate = value; }
        }

        public readonly static DependencyProperty ButtonLabelAlphaProperty = Button.LabelAlphaProperty;
        public System.Single ButtonLabelAlpha
        {
            get { return ComboBoxButton.LabelAlpha; }
            set { ComboBoxButton.LabelAlpha = value; }
        }

        public readonly static DependencyProperty ButtonLabelIsVisibleProperty = Button.LabelIsVisibleProperty;
        public System.Boolean ButtonLabelIsVisible
        {
            get { return ComboBoxButton.LabelIsVisible; }
            set { ComboBoxButton.LabelIsVisible = value; }
        }

        public readonly static DependencyProperty ButtonLabelRaycastBlockModeProperty = Button.LabelRaycastBlockModeProperty;
        public Delight.RaycastBlockMode ButtonLabelRaycastBlockMode
        {
            get { return ComboBoxButton.LabelRaycastBlockMode; }
            set { ComboBoxButton.LabelRaycastBlockMode = value; }
        }

        public readonly static DependencyProperty ButtonLabelUseFastShaderProperty = Button.LabelUseFastShaderProperty;
        public System.Boolean ButtonLabelUseFastShader
        {
            get { return ComboBoxButton.LabelUseFastShader; }
            set { ComboBoxButton.LabelUseFastShader = value; }
        }

        public readonly static DependencyProperty ButtonLabelBubbleNotifyChildLayoutChangedProperty = Button.LabelBubbleNotifyChildLayoutChangedProperty;
        public System.Boolean ButtonLabelBubbleNotifyChildLayoutChanged
        {
            get { return ComboBoxButton.LabelBubbleNotifyChildLayoutChanged; }
            set { ComboBoxButton.LabelBubbleNotifyChildLayoutChanged = value; }
        }

        public readonly static DependencyProperty ButtonLabelIgnoreFlipProperty = Button.LabelIgnoreFlipProperty;
        public System.Boolean ButtonLabelIgnoreFlip
        {
            get { return ComboBoxButton.LabelIgnoreFlip; }
            set { ComboBoxButton.LabelIgnoreFlip = value; }
        }

        public readonly static DependencyProperty ButtonLabelRotationProperty = Button.LabelRotationProperty;
        public UnityEngine.Quaternion ButtonLabelRotation
        {
            get { return ComboBoxButton.LabelRotation; }
            set { ComboBoxButton.LabelRotation = value; }
        }

        public readonly static DependencyProperty ButtonLabelPositionProperty = Button.LabelPositionProperty;
        public UnityEngine.Vector3 ButtonLabelPosition
        {
            get { return ComboBoxButton.LabelPosition; }
            set { ComboBoxButton.LabelPosition = value; }
        }

        public readonly static DependencyProperty ButtonLabelGameObjectProperty = Button.LabelGameObjectProperty;
        public UnityEngine.GameObject ButtonLabelGameObject
        {
            get { return ComboBoxButton.LabelGameObject; }
            set { ComboBoxButton.LabelGameObject = value; }
        }

        public readonly static DependencyProperty ButtonLabelEnableScriptEventsProperty = Button.LabelEnableScriptEventsProperty;
        public System.Boolean ButtonLabelEnableScriptEvents
        {
            get { return ComboBoxButton.LabelEnableScriptEvents; }
            set { ComboBoxButton.LabelEnableScriptEvents = value; }
        }

        public readonly static DependencyProperty ButtonLabelIgnoreObjectProperty = Button.LabelIgnoreObjectProperty;
        public System.Boolean ButtonLabelIgnoreObject
        {
            get { return ComboBoxButton.LabelIgnoreObject; }
            set { ComboBoxButton.LabelIgnoreObject = value; }
        }

        public readonly static DependencyProperty ButtonLabelIsActiveProperty = Button.LabelIsActiveProperty;
        public System.Boolean ButtonLabelIsActive
        {
            get { return ComboBoxButton.LabelIsActive; }
            set { ComboBoxButton.LabelIsActive = value; }
        }

        public readonly static DependencyProperty ButtonLabelLoadModeProperty = Button.LabelLoadModeProperty;
        public Delight.LoadMode ButtonLabelLoadMode
        {
            get { return ComboBoxButton.LabelLoadMode; }
            set { ComboBoxButton.LabelLoadMode = value; }
        }

        public readonly static DependencyProperty ButtonBackgroundSpriteProperty = Button.BackgroundSpriteProperty;
        public SpriteAsset ButtonBackgroundSprite
        {
            get { return ComboBoxButton.BackgroundSprite; }
            set { ComboBoxButton.BackgroundSprite = value; }
        }

        public readonly static DependencyProperty ButtonBackgroundOverrideSpriteProperty = Button.BackgroundOverrideSpriteProperty;
        public SpriteAsset ButtonBackgroundOverrideSprite
        {
            get { return ComboBoxButton.BackgroundOverrideSprite; }
            set { ComboBoxButton.BackgroundOverrideSprite = value; }
        }

        public readonly static DependencyProperty ButtonBackgroundTypeProperty = Button.BackgroundTypeProperty;
        public UnityEngine.UI.Image.Type ButtonBackgroundType
        {
            get { return ComboBoxButton.BackgroundType; }
            set { ComboBoxButton.BackgroundType = value; }
        }

        public readonly static DependencyProperty ButtonBackgroundPreserveAspectProperty = Button.BackgroundPreserveAspectProperty;
        public System.Boolean ButtonBackgroundPreserveAspect
        {
            get { return ComboBoxButton.BackgroundPreserveAspect; }
            set { ComboBoxButton.BackgroundPreserveAspect = value; }
        }

        public readonly static DependencyProperty ButtonBackgroundFillCenterProperty = Button.BackgroundFillCenterProperty;
        public System.Boolean ButtonBackgroundFillCenter
        {
            get { return ComboBoxButton.BackgroundFillCenter; }
            set { ComboBoxButton.BackgroundFillCenter = value; }
        }

        public readonly static DependencyProperty ButtonBackgroundFillMethodProperty = Button.BackgroundFillMethodProperty;
        public UnityEngine.UI.Image.FillMethod ButtonBackgroundFillMethod
        {
            get { return ComboBoxButton.BackgroundFillMethod; }
            set { ComboBoxButton.BackgroundFillMethod = value; }
        }

        public readonly static DependencyProperty ButtonBackgroundFillAmountProperty = Button.BackgroundFillAmountProperty;
        public System.Single ButtonBackgroundFillAmount
        {
            get { return ComboBoxButton.BackgroundFillAmount; }
            set { ComboBoxButton.BackgroundFillAmount = value; }
        }

        public readonly static DependencyProperty ButtonBackgroundFillClockwiseProperty = Button.BackgroundFillClockwiseProperty;
        public System.Boolean ButtonBackgroundFillClockwise
        {
            get { return ComboBoxButton.BackgroundFillClockwise; }
            set { ComboBoxButton.BackgroundFillClockwise = value; }
        }

        public readonly static DependencyProperty ButtonBackgroundFillOriginProperty = Button.BackgroundFillOriginProperty;
        public System.Int32 ButtonBackgroundFillOrigin
        {
            get { return ComboBoxButton.BackgroundFillOrigin; }
            set { ComboBoxButton.BackgroundFillOrigin = value; }
        }

        public readonly static DependencyProperty ButtonBackgroundAlphaHitTestMinimumThresholdProperty = Button.BackgroundAlphaHitTestMinimumThresholdProperty;
        public System.Single ButtonBackgroundAlphaHitTestMinimumThreshold
        {
            get { return ComboBoxButton.BackgroundAlphaHitTestMinimumThreshold; }
            set { ComboBoxButton.BackgroundAlphaHitTestMinimumThreshold = value; }
        }

        public readonly static DependencyProperty ButtonBackgroundUseSpriteMeshProperty = Button.BackgroundUseSpriteMeshProperty;
        public System.Boolean ButtonBackgroundUseSpriteMesh
        {
            get { return ComboBoxButton.BackgroundUseSpriteMesh; }
            set { ComboBoxButton.BackgroundUseSpriteMesh = value; }
        }

        public readonly static DependencyProperty ButtonBackgroundPixelsPerUnitMultiplierProperty = Button.BackgroundPixelsPerUnitMultiplierProperty;
        public System.Single ButtonBackgroundPixelsPerUnitMultiplier
        {
            get { return ComboBoxButton.BackgroundPixelsPerUnitMultiplier; }
            set { ComboBoxButton.BackgroundPixelsPerUnitMultiplier = value; }
        }

        public readonly static DependencyProperty ButtonBackgroundMaterialProperty = Button.BackgroundMaterialProperty;
        public MaterialAsset ButtonBackgroundMaterial
        {
            get { return ComboBoxButton.BackgroundMaterial; }
            set { ComboBoxButton.BackgroundMaterial = value; }
        }

        public readonly static DependencyProperty ButtonBackgroundOnCullStateChangedProperty = Button.BackgroundOnCullStateChangedProperty;
        public UnityEngine.UI.MaskableGraphic.CullStateChangedEvent ButtonBackgroundOnCullStateChanged
        {
            get { return ComboBoxButton.BackgroundOnCullStateChanged; }
            set { ComboBoxButton.BackgroundOnCullStateChanged = value; }
        }

        public readonly static DependencyProperty ButtonBackgroundMaskableProperty = Button.BackgroundMaskableProperty;
        public System.Boolean ButtonBackgroundMaskable
        {
            get { return ComboBoxButton.BackgroundMaskable; }
            set { ComboBoxButton.BackgroundMaskable = value; }
        }

        public readonly static DependencyProperty ButtonBackgroundIsMaskingGraphicProperty = Button.BackgroundIsMaskingGraphicProperty;
        public System.Boolean ButtonBackgroundIsMaskingGraphic
        {
            get { return ComboBoxButton.BackgroundIsMaskingGraphic; }
            set { ComboBoxButton.BackgroundIsMaskingGraphic = value; }
        }

        public readonly static DependencyProperty ButtonBackgroundColorProperty = Button.BackgroundColorProperty;
        public UnityEngine.Color ButtonBackgroundColor
        {
            get { return ComboBoxButton.BackgroundColor; }
            set { ComboBoxButton.BackgroundColor = value; }
        }

        public readonly static DependencyProperty ButtonBackgroundRaycastTargetProperty = Button.BackgroundRaycastTargetProperty;
        public System.Boolean ButtonBackgroundRaycastTarget
        {
            get { return ComboBoxButton.BackgroundRaycastTarget; }
            set { ComboBoxButton.BackgroundRaycastTarget = value; }
        }

        public readonly static DependencyProperty ButtonWidthProperty = Button.WidthProperty;
        public Delight.ElementSize ButtonWidth
        {
            get { return ComboBoxButton.Width; }
            set { ComboBoxButton.Width = value; }
        }

        public readonly static DependencyProperty ButtonHeightProperty = Button.HeightProperty;
        public Delight.ElementSize ButtonHeight
        {
            get { return ComboBoxButton.Height; }
            set { ComboBoxButton.Height = value; }
        }

        public readonly static DependencyProperty ButtonOverrideWidthProperty = Button.OverrideWidthProperty;
        public Delight.ElementSize ButtonOverrideWidth
        {
            get { return ComboBoxButton.OverrideWidth; }
            set { ComboBoxButton.OverrideWidth = value; }
        }

        public readonly static DependencyProperty ButtonOverrideHeightProperty = Button.OverrideHeightProperty;
        public Delight.ElementSize ButtonOverrideHeight
        {
            get { return ComboBoxButton.OverrideHeight; }
            set { ComboBoxButton.OverrideHeight = value; }
        }

        public readonly static DependencyProperty ButtonScaleProperty = Button.ScaleProperty;
        public UnityEngine.Vector3 ButtonScale
        {
            get { return ComboBoxButton.Scale; }
            set { ComboBoxButton.Scale = value; }
        }

        public readonly static DependencyProperty ButtonAlignmentProperty = Button.AlignmentProperty;
        public Delight.ElementAlignment ButtonAlignment
        {
            get { return ComboBoxButton.Alignment; }
            set { ComboBoxButton.Alignment = value; }
        }

        public readonly static DependencyProperty ButtonMarginProperty = Button.MarginProperty;
        public Delight.ElementMargin ButtonMargin
        {
            get { return ComboBoxButton.Margin; }
            set { ComboBoxButton.Margin = value; }
        }

        public readonly static DependencyProperty ButtonOffsetProperty = Button.OffsetProperty;
        public Delight.ElementMargin ButtonOffset
        {
            get { return ComboBoxButton.Offset; }
            set { ComboBoxButton.Offset = value; }
        }

        public readonly static DependencyProperty ButtonOffsetFromParentProperty = Button.OffsetFromParentProperty;
        public Delight.ElementMargin ButtonOffsetFromParent
        {
            get { return ComboBoxButton.OffsetFromParent; }
            set { ComboBoxButton.OffsetFromParent = value; }
        }

        public readonly static DependencyProperty ButtonPivotProperty = Button.PivotProperty;
        public UnityEngine.Vector2 ButtonPivot
        {
            get { return ComboBoxButton.Pivot; }
            set { ComboBoxButton.Pivot = value; }
        }

        public readonly static DependencyProperty ButtonLayoutRootProperty = Button.LayoutRootProperty;
        public Delight.LayoutRoot ButtonLayoutRoot
        {
            get { return ComboBoxButton.LayoutRoot; }
            set { ComboBoxButton.LayoutRoot = value; }
        }

        public readonly static DependencyProperty ButtonDisableLayoutUpdateProperty = Button.DisableLayoutUpdateProperty;
        public System.Boolean ButtonDisableLayoutUpdate
        {
            get { return ComboBoxButton.DisableLayoutUpdate; }
            set { ComboBoxButton.DisableLayoutUpdate = value; }
        }

        public readonly static DependencyProperty ButtonAlphaProperty = Button.AlphaProperty;
        public System.Single ButtonAlpha
        {
            get { return ComboBoxButton.Alpha; }
            set { ComboBoxButton.Alpha = value; }
        }

        public readonly static DependencyProperty ButtonIsVisibleProperty = Button.IsVisibleProperty;
        public System.Boolean ButtonIsVisible
        {
            get { return ComboBoxButton.IsVisible; }
            set { ComboBoxButton.IsVisible = value; }
        }

        public readonly static DependencyProperty ButtonRaycastBlockModeProperty = Button.RaycastBlockModeProperty;
        public Delight.RaycastBlockMode ButtonRaycastBlockMode
        {
            get { return ComboBoxButton.RaycastBlockMode; }
            set { ComboBoxButton.RaycastBlockMode = value; }
        }

        public readonly static DependencyProperty ButtonUseFastShaderProperty = Button.UseFastShaderProperty;
        public System.Boolean ButtonUseFastShader
        {
            get { return ComboBoxButton.UseFastShader; }
            set { ComboBoxButton.UseFastShader = value; }
        }

        public readonly static DependencyProperty ButtonBubbleNotifyChildLayoutChangedProperty = Button.BubbleNotifyChildLayoutChangedProperty;
        public System.Boolean ButtonBubbleNotifyChildLayoutChanged
        {
            get { return ComboBoxButton.BubbleNotifyChildLayoutChanged; }
            set { ComboBoxButton.BubbleNotifyChildLayoutChanged = value; }
        }

        public readonly static DependencyProperty ButtonIgnoreFlipProperty = Button.IgnoreFlipProperty;
        public System.Boolean ButtonIgnoreFlip
        {
            get { return ComboBoxButton.IgnoreFlip; }
            set { ComboBoxButton.IgnoreFlip = value; }
        }

        public readonly static DependencyProperty ButtonRotationProperty = Button.RotationProperty;
        public UnityEngine.Quaternion ButtonRotation
        {
            get { return ComboBoxButton.Rotation; }
            set { ComboBoxButton.Rotation = value; }
        }

        public readonly static DependencyProperty ButtonPositionProperty = Button.PositionProperty;
        public UnityEngine.Vector3 ButtonPosition
        {
            get { return ComboBoxButton.Position; }
            set { ComboBoxButton.Position = value; }
        }

        public readonly static DependencyProperty ButtonGameObjectProperty = Button.GameObjectProperty;
        public UnityEngine.GameObject ButtonGameObject
        {
            get { return ComboBoxButton.GameObject; }
            set { ComboBoxButton.GameObject = value; }
        }

        public readonly static DependencyProperty ButtonEnableScriptEventsProperty = Button.EnableScriptEventsProperty;
        public System.Boolean ButtonEnableScriptEvents
        {
            get { return ComboBoxButton.EnableScriptEvents; }
            set { ComboBoxButton.EnableScriptEvents = value; }
        }

        public readonly static DependencyProperty ButtonIgnoreObjectProperty = Button.IgnoreObjectProperty;
        public System.Boolean ButtonIgnoreObject
        {
            get { return ComboBoxButton.IgnoreObject; }
            set { ComboBoxButton.IgnoreObject = value; }
        }

        public readonly static DependencyProperty ButtonIsActiveProperty = Button.IsActiveProperty;
        public System.Boolean ButtonIsActive
        {
            get { return ComboBoxButton.IsActive; }
            set { ComboBoxButton.IsActive = value; }
        }

        public readonly static DependencyProperty ButtonLoadModeProperty = Button.LoadModeProperty;
        public Delight.LoadMode ButtonLoadMode
        {
            get { return ComboBoxButton.LoadMode; }
            set { ComboBoxButton.LoadMode = value; }
        }

        #endregion
    }

    #region Data Templates

    public static class ComboBoxTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return ComboBox;
            }
        }

        private static Template _comboBox;
        public static Template ComboBox
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBox == null || _comboBox.CurrentVersion != Template.Version)
#else
                if (_comboBox == null)
#endif
                {
                    _comboBox = new Template(UIViewTemplates.UIView);
#if UNITY_EDITOR
                    _comboBox.Name = "ComboBox";
#endif
                    Delight.ComboBox.WidthProperty.SetDefault(_comboBox, new ElementSize(160f, ElementSizeUnit.Pixels));
                    Delight.ComboBox.HeightProperty.SetDefault(_comboBox, new ElementSize(40f, ElementSizeUnit.Pixels));
                    Delight.ComboBox.EnableScriptEventsProperty.SetDefault(_comboBox, true);
                    Delight.ComboBox.HeightProperty.SetDefault(_comboBox, new ElementSize(32f, ElementSizeUnit.Pixels));
                    Delight.ComboBox.WidthProperty.SetDefault(_comboBox, new ElementSize(200f, ElementSizeUnit.Pixels));
                    Delight.ComboBox.ComboBoxButtonTemplateProperty.SetDefault(_comboBox, ComboBoxComboBoxButton);
                    Delight.ComboBox.ComboBoxListCanvasTemplateProperty.SetDefault(_comboBox, ComboBoxComboBoxListCanvas);
                    Delight.ComboBox.ComboBoxListTemplateProperty.SetDefault(_comboBox, ComboBoxComboBoxList);
                }
                return _comboBox;
            }
        }

        private static Template _comboBoxComboBoxButton;
        public static Template ComboBoxComboBoxButton
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxComboBoxButton == null || _comboBoxComboBoxButton.CurrentVersion != Template.Version)
#else
                if (_comboBoxComboBoxButton == null)
#endif
                {
                    _comboBoxComboBoxButton = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _comboBoxComboBoxButton.Name = "ComboBoxComboBoxButton";
#endif
                    Delight.Button.IsToggleButtonProperty.SetDefault(_comboBoxComboBoxButton, true);
                    Delight.Button.WidthProperty.SetDefault(_comboBoxComboBoxButton, new ElementSize(1f, ElementSizeUnit.Percents));
                    Delight.Button.HeightProperty.SetDefault(_comboBoxComboBoxButton, new ElementSize(1f, ElementSizeUnit.Percents));
                    Delight.Button.AutoSizeProperty.SetDefault(_comboBoxComboBoxButton, Delight.AutoSize.False);
                    Delight.Button.MarginProperty.SetDefault(_comboBoxComboBoxButton, new ElementMargin(new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(2f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels)));
                    Delight.Button.BackgroundSpriteProperty.SetDefault(_comboBoxComboBoxButton, Assets.Sprites["ComboBoxButton"]);
                    Delight.Button.BackgroundColorProperty.SetDefault(_comboBoxComboBoxButton, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Button.BackgroundSpriteProperty.SetStateDefault("Pressed", _comboBoxComboBoxButton, Assets.Sprites["ComboBoxButtonPressed"]);
                    Delight.Button.BackgroundColorProperty.SetStateDefault("Highlighted", _comboBoxComboBoxButton, new UnityEngine.Color(0.8666667f, 0.8666667f, 0.8666667f, 1f));
                    Delight.Button.BackgroundColorProperty.SetStateDefault("Pressed", _comboBoxComboBoxButton, new UnityEngine.Color(0.9333333f, 0.9333333f, 0.9333333f, 1f));
                    Delight.Button.LabelTemplateProperty.SetDefault(_comboBoxComboBoxButton, ComboBoxComboBoxButtonLabel);
                }
                return _comboBoxComboBoxButton;
            }
        }

        private static Template _comboBoxComboBoxButtonLabel;
        public static Template ComboBoxComboBoxButtonLabel
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxComboBoxButtonLabel == null || _comboBoxComboBoxButtonLabel.CurrentVersion != Template.Version)
#else
                if (_comboBoxComboBoxButtonLabel == null)
#endif
                {
                    _comboBoxComboBoxButtonLabel = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _comboBoxComboBoxButtonLabel.Name = "ComboBoxComboBoxButtonLabel";
#endif
                    Delight.Label.FontSizeProperty.SetDefault(_comboBoxComboBoxButtonLabel, 16f);
                    Delight.Label.FontColorProperty.SetDefault(_comboBoxComboBoxButtonLabel, new UnityEngine.Color(0f, 0f, 0f, 1f));
                    Delight.Label.TextAlignmentProperty.SetDefault(_comboBoxComboBoxButtonLabel, TMPro.TextAlignmentOptions.Left);
                    Delight.Label.MarginProperty.SetDefault(_comboBoxComboBoxButtonLabel, new ElementMargin(new ElementSize(10f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(10f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels)));
                    Delight.Label.FontColorProperty.SetStateDefault("Pressed", _comboBoxComboBoxButtonLabel, new UnityEngine.Color(0f, 0f, 0f, 1f));
                    Delight.Label.FontColorProperty.SetStateDefault("Highlighted", _comboBoxComboBoxButtonLabel, new UnityEngine.Color(0f, 0f, 0f, 1f));
                }
                return _comboBoxComboBoxButtonLabel;
            }
        }

        private static Template _comboBoxComboBoxListCanvas;
        public static Template ComboBoxComboBoxListCanvas
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxComboBoxListCanvas == null || _comboBoxComboBoxListCanvas.CurrentVersion != Template.Version)
#else
                if (_comboBoxComboBoxListCanvas == null)
#endif
                {
                    _comboBoxComboBoxListCanvas = new Template(UICanvasTemplates.UICanvas);
#if UNITY_EDITOR
                    _comboBoxComboBoxListCanvas.Name = "ComboBoxComboBoxListCanvas";
#endif
                    Delight.UICanvas.AlignmentProperty.SetDefault(_comboBoxComboBoxListCanvas, Delight.ElementAlignment.Top);
                    Delight.UICanvas.OverrideSortingProperty.SetDefault(_comboBoxComboBoxListCanvas, true);
                    Delight.UICanvas.SortingOrderProperty.SetDefault(_comboBoxComboBoxListCanvas, 10);
                }
                return _comboBoxComboBoxListCanvas;
            }
        }

        private static Template _comboBoxComboBoxList;
        public static Template ComboBoxComboBoxList
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxComboBoxList == null || _comboBoxComboBoxList.CurrentVersion != Template.Version)
#else
                if (_comboBoxComboBoxList == null)
#endif
                {
                    _comboBoxComboBoxList = new Template(ListTemplates.List);
#if UNITY_EDITOR
                    _comboBoxComboBoxList.Name = "ComboBoxComboBoxList";
#endif
                    Delight.List.WidthProperty.SetDefault(_comboBoxComboBoxList, new ElementSize(1f, ElementSizeUnit.Percents));
                    Delight.List.AlignmentProperty.SetDefault(_comboBoxComboBoxList, Delight.ElementAlignment.Top);
                    Delight.List.IsActiveProperty.SetDefault(_comboBoxComboBoxList, false);
                    Delight.List.CanReselectProperty.SetDefault(_comboBoxComboBoxList, true);
                    Delight.List.BackgroundColorProperty.SetDefault(_comboBoxComboBoxList, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.List.ScrollableRegionTemplateProperty.SetDefault(_comboBoxComboBoxList, ComboBoxComboBoxListScrollableRegion);
                }
                return _comboBoxComboBoxList;
            }
        }

        private static Template _comboBoxComboBoxListScrollableRegion;
        public static Template ComboBoxComboBoxListScrollableRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxComboBoxListScrollableRegion == null || _comboBoxComboBoxListScrollableRegion.CurrentVersion != Template.Version)
#else
                if (_comboBoxComboBoxListScrollableRegion == null)
#endif
                {
                    _comboBoxComboBoxListScrollableRegion = new Template(ListTemplates.ListScrollableRegion);
#if UNITY_EDITOR
                    _comboBoxComboBoxListScrollableRegion.Name = "ComboBoxComboBoxListScrollableRegion";
#endif
                    Delight.ScrollableRegion.ContentRegionTemplateProperty.SetDefault(_comboBoxComboBoxListScrollableRegion, ComboBoxComboBoxListScrollableRegionContentRegion);
                    Delight.ScrollableRegion.HorizontalScrollbarTemplateProperty.SetDefault(_comboBoxComboBoxListScrollableRegion, ComboBoxComboBoxListScrollableRegionHorizontalScrollbar);
                    Delight.ScrollableRegion.VerticalScrollbarTemplateProperty.SetDefault(_comboBoxComboBoxListScrollableRegion, ComboBoxComboBoxListScrollableRegionVerticalScrollbar);
                }
                return _comboBoxComboBoxListScrollableRegion;
            }
        }

        private static Template _comboBoxComboBoxListScrollableRegionContentRegion;
        public static Template ComboBoxComboBoxListScrollableRegionContentRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxComboBoxListScrollableRegionContentRegion == null || _comboBoxComboBoxListScrollableRegionContentRegion.CurrentVersion != Template.Version)
#else
                if (_comboBoxComboBoxListScrollableRegionContentRegion == null)
#endif
                {
                    _comboBoxComboBoxListScrollableRegionContentRegion = new Template(ListTemplates.ListScrollableRegionContentRegion);
#if UNITY_EDITOR
                    _comboBoxComboBoxListScrollableRegionContentRegion.Name = "ComboBoxComboBoxListScrollableRegionContentRegion";
#endif
                }
                return _comboBoxComboBoxListScrollableRegionContentRegion;
            }
        }

        private static Template _comboBoxComboBoxListScrollableRegionHorizontalScrollbar;
        public static Template ComboBoxComboBoxListScrollableRegionHorizontalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxComboBoxListScrollableRegionHorizontalScrollbar == null || _comboBoxComboBoxListScrollableRegionHorizontalScrollbar.CurrentVersion != Template.Version)
#else
                if (_comboBoxComboBoxListScrollableRegionHorizontalScrollbar == null)
#endif
                {
                    _comboBoxComboBoxListScrollableRegionHorizontalScrollbar = new Template(ListTemplates.ListScrollableRegionHorizontalScrollbar);
#if UNITY_EDITOR
                    _comboBoxComboBoxListScrollableRegionHorizontalScrollbar.Name = "ComboBoxComboBoxListScrollableRegionHorizontalScrollbar";
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_comboBoxComboBoxListScrollableRegionHorizontalScrollbar, ComboBoxComboBoxListScrollableRegionHorizontalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_comboBoxComboBoxListScrollableRegionHorizontalScrollbar, ComboBoxComboBoxListScrollableRegionHorizontalScrollbarHandle);
                }
                return _comboBoxComboBoxListScrollableRegionHorizontalScrollbar;
            }
        }

        private static Template _comboBoxComboBoxListScrollableRegionHorizontalScrollbarBar;
        public static Template ComboBoxComboBoxListScrollableRegionHorizontalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxComboBoxListScrollableRegionHorizontalScrollbarBar == null || _comboBoxComboBoxListScrollableRegionHorizontalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_comboBoxComboBoxListScrollableRegionHorizontalScrollbarBar == null)
#endif
                {
                    _comboBoxComboBoxListScrollableRegionHorizontalScrollbarBar = new Template(ListTemplates.ListScrollableRegionHorizontalScrollbarBar);
#if UNITY_EDITOR
                    _comboBoxComboBoxListScrollableRegionHorizontalScrollbarBar.Name = "ComboBoxComboBoxListScrollableRegionHorizontalScrollbarBar";
#endif
                }
                return _comboBoxComboBoxListScrollableRegionHorizontalScrollbarBar;
            }
        }

        private static Template _comboBoxComboBoxListScrollableRegionHorizontalScrollbarHandle;
        public static Template ComboBoxComboBoxListScrollableRegionHorizontalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxComboBoxListScrollableRegionHorizontalScrollbarHandle == null || _comboBoxComboBoxListScrollableRegionHorizontalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_comboBoxComboBoxListScrollableRegionHorizontalScrollbarHandle == null)
#endif
                {
                    _comboBoxComboBoxListScrollableRegionHorizontalScrollbarHandle = new Template(ListTemplates.ListScrollableRegionHorizontalScrollbarHandle);
#if UNITY_EDITOR
                    _comboBoxComboBoxListScrollableRegionHorizontalScrollbarHandle.Name = "ComboBoxComboBoxListScrollableRegionHorizontalScrollbarHandle";
#endif
                }
                return _comboBoxComboBoxListScrollableRegionHorizontalScrollbarHandle;
            }
        }

        private static Template _comboBoxComboBoxListScrollableRegionVerticalScrollbar;
        public static Template ComboBoxComboBoxListScrollableRegionVerticalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxComboBoxListScrollableRegionVerticalScrollbar == null || _comboBoxComboBoxListScrollableRegionVerticalScrollbar.CurrentVersion != Template.Version)
#else
                if (_comboBoxComboBoxListScrollableRegionVerticalScrollbar == null)
#endif
                {
                    _comboBoxComboBoxListScrollableRegionVerticalScrollbar = new Template(ListTemplates.ListScrollableRegionVerticalScrollbar);
#if UNITY_EDITOR
                    _comboBoxComboBoxListScrollableRegionVerticalScrollbar.Name = "ComboBoxComboBoxListScrollableRegionVerticalScrollbar";
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_comboBoxComboBoxListScrollableRegionVerticalScrollbar, ComboBoxComboBoxListScrollableRegionVerticalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_comboBoxComboBoxListScrollableRegionVerticalScrollbar, ComboBoxComboBoxListScrollableRegionVerticalScrollbarHandle);
                }
                return _comboBoxComboBoxListScrollableRegionVerticalScrollbar;
            }
        }

        private static Template _comboBoxComboBoxListScrollableRegionVerticalScrollbarBar;
        public static Template ComboBoxComboBoxListScrollableRegionVerticalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxComboBoxListScrollableRegionVerticalScrollbarBar == null || _comboBoxComboBoxListScrollableRegionVerticalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_comboBoxComboBoxListScrollableRegionVerticalScrollbarBar == null)
#endif
                {
                    _comboBoxComboBoxListScrollableRegionVerticalScrollbarBar = new Template(ListTemplates.ListScrollableRegionVerticalScrollbarBar);
#if UNITY_EDITOR
                    _comboBoxComboBoxListScrollableRegionVerticalScrollbarBar.Name = "ComboBoxComboBoxListScrollableRegionVerticalScrollbarBar";
#endif
                }
                return _comboBoxComboBoxListScrollableRegionVerticalScrollbarBar;
            }
        }

        private static Template _comboBoxComboBoxListScrollableRegionVerticalScrollbarHandle;
        public static Template ComboBoxComboBoxListScrollableRegionVerticalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxComboBoxListScrollableRegionVerticalScrollbarHandle == null || _comboBoxComboBoxListScrollableRegionVerticalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_comboBoxComboBoxListScrollableRegionVerticalScrollbarHandle == null)
#endif
                {
                    _comboBoxComboBoxListScrollableRegionVerticalScrollbarHandle = new Template(ListTemplates.ListScrollableRegionVerticalScrollbarHandle);
#if UNITY_EDITOR
                    _comboBoxComboBoxListScrollableRegionVerticalScrollbarHandle.Name = "ComboBoxComboBoxListScrollableRegionVerticalScrollbarHandle";
#endif
                }
                return _comboBoxComboBoxListScrollableRegionVerticalScrollbarHandle;
            }
        }

        #endregion
    }

    #endregion
}
