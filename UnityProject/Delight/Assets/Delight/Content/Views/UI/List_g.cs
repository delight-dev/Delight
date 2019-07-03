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

        public readonly static DependencyProperty<ViewAction> ItemSelectedProperty = new DependencyProperty<ViewAction>("ItemSelected");
        public ViewAction ItemSelected
        {
            get { return ItemSelectedProperty.GetValue(this); }
            set { ItemSelectedProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ViewAction> ItemDeselectedProperty = new DependencyProperty<ViewAction>("ItemDeselected");
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
