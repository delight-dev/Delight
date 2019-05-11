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

        public ComboBox(View parent, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :
            base(parent, layoutParent, id, template ?? ComboBoxTemplates.Default, initializer)
        {
            // constructing Button (ComboBoxButton)
            ComboBoxButton = new Button(this, this, "ComboBoxButton", ComboBoxButtonTemplate);
            ComboBoxButton.Click += ResolveActionHandler(this, "ComboBoxButtonClick");

            // constructing UICanvas (ComboBoxListCanvas)
            ComboBoxListCanvas = new UICanvas(this, this, "ComboBoxListCanvas", ComboBoxListCanvasTemplate);
            ComboBoxList = new List(this, ComboBoxListCanvas.Content, "ComboBoxList", ComboBoxListTemplate);
            ComboBoxList.ItemSelected += ResolveActionHandler(this, "ComboBoxListSelectionChanged");

            // Template for ComboBoxList
            ComboBoxList.ContentTemplate = new ContentTemplate(x0 => 
            {
                return null;
            });
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

        public readonly static DependencyProperty<ViewAction> ItemSelectedProperty = new DependencyProperty<ViewAction>("ItemSelected");
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

        public readonly static DependencyProperty OverflowModeProperty = List.OverflowModeProperty;
        public Delight.OverflowMode OverflowMode
        {
            get { return ComboBoxList.OverflowMode; }
            set { ComboBoxList.OverflowMode = value; }
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

        public readonly static DependencyProperty ContentTemplateProperty = List.ContentTemplateProperty;
        public Delight.ContentTemplate ContentTemplate
        {
            get { return ComboBoxList.ContentTemplate; }
            set { ComboBoxList.ContentTemplate = value; }
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

        public readonly static DependencyProperty ButtonTextMeshProUGUIMarginProperty = Button.TextMeshProUGUIMarginProperty;
        public UnityEngine.Vector4 ButtonTextMeshProUGUIMargin
        {
            get { return ComboBoxButton.TextMeshProUGUIMargin; }
            set { ComboBoxButton.TextMeshProUGUIMargin = value; }
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
                    Delight.ComboBox.HeightProperty.SetDefault(_comboBox, new ElementSize(52f, ElementSizeUnit.Pixels));
                    Delight.ComboBox.WidthProperty.SetDefault(_comboBox, new ElementSize(300f, ElementSizeUnit.Pixels));
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
                    Delight.Label.FontSizeProperty.SetDefault(_comboBoxComboBoxButtonLabel, 18f);
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
                    Delight.List.MarginProperty.SetDefault(_comboBoxComboBoxList, new ElementMargin(new ElementSize(2f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(1f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels)));
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
