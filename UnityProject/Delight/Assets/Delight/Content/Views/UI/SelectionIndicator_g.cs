// Internal view logic generated from "SelectionIndicator.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class SelectionIndicator : UIImageView
    {
        #region Constructors

        public SelectionIndicator(View parent, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :
            base(parent, layoutParent, id, template ?? SelectionIndicatorTemplates.Default, initializer)
        {
            // constructing Button (SelectionTab)
            SelectionTab = new Button(this, this, "SelectionTab", SelectionTabTemplate);
            this.AfterInitializeInternal();
        }

        public SelectionIndicator() : this(null)
        {
        }

        static SelectionIndicator()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(SelectionIndicatorTemplates.Default, dependencyProperties);

            dependencyProperties.Add(SelectionTabProperty);
            dependencyProperties.Add(SelectionTabTemplateProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<Button> SelectionTabProperty = new DependencyProperty<Button>("SelectionTab");
        public Button SelectionTab
        {
            get { return SelectionTabProperty.GetValue(this); }
            set { SelectionTabProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> SelectionTabTemplateProperty = new DependencyProperty<Template>("SelectionTabTemplate");
        public Template SelectionTabTemplate
        {
            get { return SelectionTabTemplateProperty.GetValue(this); }
            set { SelectionTabTemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty SelectionTabDefaultWidthProperty = Button.DefaultWidthProperty;
        public Delight.ElementSize SelectionTabDefaultWidth
        {
            get { return SelectionTab.DefaultWidth; }
            set { SelectionTab.DefaultWidth = value; }
        }

        public readonly static DependencyProperty SelectionTabIsToggleButtonProperty = Button.IsToggleButtonProperty;
        public System.Boolean SelectionTabIsToggleButton
        {
            get { return SelectionTab.IsToggleButton; }
            set { SelectionTab.IsToggleButton = value; }
        }

        public readonly static DependencyProperty SelectionTabIsDisabledProperty = Button.IsDisabledProperty;
        public System.Boolean SelectionTabIsDisabled
        {
            get { return SelectionTab.IsDisabled; }
            set { SelectionTab.IsDisabled = value; }
        }

        public readonly static DependencyProperty SelectionTabToggleValueProperty = Button.ToggleValueProperty;
        public System.Boolean SelectionTabToggleValue
        {
            get { return SelectionTab.ToggleValue; }
            set { SelectionTab.ToggleValue = value; }
        }

        public readonly static DependencyProperty SelectionTabTextPaddingProperty = Button.TextPaddingProperty;
        public Delight.ElementMargin SelectionTabTextPadding
        {
            get { return SelectionTab.TextPadding; }
            set { SelectionTab.TextPadding = value; }
        }

        public readonly static DependencyProperty SelectionTabCanToggleOnProperty = Button.CanToggleOnProperty;
        public System.Boolean SelectionTabCanToggleOn
        {
            get { return SelectionTab.CanToggleOn; }
            set { SelectionTab.CanToggleOn = value; }
        }

        public readonly static DependencyProperty SelectionTabCanToggleOffProperty = Button.CanToggleOffProperty;
        public System.Boolean SelectionTabCanToggleOff
        {
            get { return SelectionTab.CanToggleOff; }
            set { SelectionTab.CanToggleOff = value; }
        }

        public readonly static DependencyProperty SelectionTabIsMouseOverProperty = Button.IsMouseOverProperty;
        public System.Boolean SelectionTabIsMouseOver
        {
            get { return SelectionTab.IsMouseOver; }
            set { SelectionTab.IsMouseOver = value; }
        }

        public readonly static DependencyProperty SelectionTabIsPressedProperty = Button.IsPressedProperty;
        public System.Boolean SelectionTabIsPressed
        {
            get { return SelectionTab.IsPressed; }
            set { SelectionTab.IsPressed = value; }
        }

        public readonly static DependencyProperty SelectionTabAutoSizeProperty = Button.AutoSizeProperty;
        public Delight.AutoSize SelectionTabAutoSize
        {
            get { return SelectionTab.AutoSize; }
            set { SelectionTab.AutoSize = value; }
        }

        public readonly static DependencyProperty SelectionTabTextOffsetProperty = Button.TextOffsetProperty;
        public Delight.ElementMargin SelectionTabTextOffset
        {
            get { return SelectionTab.TextOffset; }
            set { SelectionTab.TextOffset = value; }
        }

        public readonly static DependencyProperty SelectionTabIsCloseButtonProperty = Button.IsCloseButtonProperty;
        public System.Boolean SelectionTabIsCloseButton
        {
            get { return SelectionTab.IsCloseButton; }
            set { SelectionTab.IsCloseButton = value; }
        }

        public readonly static DependencyProperty SelectionTabIsBackButtonProperty = Button.IsBackButtonProperty;
        public System.Boolean SelectionTabIsBackButton
        {
            get { return SelectionTab.IsBackButton; }
            set { SelectionTab.IsBackButton = value; }
        }

        public readonly static DependencyProperty SelectionTabTextAlignmentProperty = Button.TextAlignmentProperty;
        public Delight.ElementAlignment SelectionTabTextAlignment
        {
            get { return SelectionTab.TextAlignment; }
            set { SelectionTab.TextAlignment = value; }
        }

        public readonly static DependencyProperty SelectionTabEnableWordWrappingProperty = Button.EnableWordWrappingProperty;
        public System.Boolean SelectionTabEnableWordWrapping
        {
            get { return SelectionTab.EnableWordWrapping; }
            set { SelectionTab.EnableWordWrapping = value; }
        }

        public readonly static DependencyProperty SelectionTabLabelAutoSizeProperty = Button.LabelAutoSizeProperty;
        public Delight.AutoSize SelectionTabLabelAutoSize
        {
            get { return SelectionTab.LabelAutoSize; }
            set { SelectionTab.LabelAutoSize = value; }
        }

        public readonly static DependencyProperty SelectionTabOverflowModeProperty = Button.OverflowModeProperty;
        public System.String SelectionTabOverflowMode
        {
            get { return SelectionTab.OverflowMode; }
            set { SelectionTab.OverflowMode = value; }
        }

        public readonly static DependencyProperty SelectionTabExtraPaddingProperty = Button.ExtraPaddingProperty;
        public System.Boolean SelectionTabExtraPadding
        {
            get { return SelectionTab.ExtraPadding; }
            set { SelectionTab.ExtraPadding = value; }
        }

        public readonly static DependencyProperty SelectionTabFontProperty = Button.FontProperty;
        public FontAsset SelectionTabFont
        {
            get { return SelectionTab.Font; }
            set { SelectionTab.Font = value; }
        }

        public readonly static DependencyProperty SelectionTabTextProperty = Button.TextProperty;
        public System.String SelectionTabText
        {
            get { return SelectionTab.Text; }
            set { SelectionTab.Text = value; }
        }

        public readonly static DependencyProperty SelectionTabSupportRichTextProperty = Button.SupportRichTextProperty;
        public System.Boolean SelectionTabSupportRichText
        {
            get { return SelectionTab.SupportRichText; }
            set { SelectionTab.SupportRichText = value; }
        }

        public readonly static DependencyProperty SelectionTabResizeTextForBestFitProperty = Button.ResizeTextForBestFitProperty;
        public System.Boolean SelectionTabResizeTextForBestFit
        {
            get { return SelectionTab.ResizeTextForBestFit; }
            set { SelectionTab.ResizeTextForBestFit = value; }
        }

        public readonly static DependencyProperty SelectionTabResizeTextMinSizeProperty = Button.ResizeTextMinSizeProperty;
        public System.Int32 SelectionTabResizeTextMinSize
        {
            get { return SelectionTab.ResizeTextMinSize; }
            set { SelectionTab.ResizeTextMinSize = value; }
        }

        public readonly static DependencyProperty SelectionTabResizeTextMaxSizeProperty = Button.ResizeTextMaxSizeProperty;
        public System.Int32 SelectionTabResizeTextMaxSize
        {
            get { return SelectionTab.ResizeTextMaxSize; }
            set { SelectionTab.ResizeTextMaxSize = value; }
        }

        public readonly static DependencyProperty SelectionTabTextComponentTextAlignmentProperty = Button.TextComponentTextAlignmentProperty;
        public UnityEngine.TextAnchor SelectionTabTextComponentTextAlignment
        {
            get { return SelectionTab.TextComponentTextAlignment; }
            set { SelectionTab.TextComponentTextAlignment = value; }
        }

        public readonly static DependencyProperty SelectionTabAlignByGeometryProperty = Button.AlignByGeometryProperty;
        public System.Boolean SelectionTabAlignByGeometry
        {
            get { return SelectionTab.AlignByGeometry; }
            set { SelectionTab.AlignByGeometry = value; }
        }

        public readonly static DependencyProperty SelectionTabFontSizeProperty = Button.FontSizeProperty;
        public System.Int32 SelectionTabFontSize
        {
            get { return SelectionTab.FontSize; }
            set { SelectionTab.FontSize = value; }
        }

        public readonly static DependencyProperty SelectionTabHorizontalOverflowProperty = Button.HorizontalOverflowProperty;
        public UnityEngine.HorizontalWrapMode SelectionTabHorizontalOverflow
        {
            get { return SelectionTab.HorizontalOverflow; }
            set { SelectionTab.HorizontalOverflow = value; }
        }

        public readonly static DependencyProperty SelectionTabVerticalOverflowProperty = Button.VerticalOverflowProperty;
        public UnityEngine.VerticalWrapMode SelectionTabVerticalOverflow
        {
            get { return SelectionTab.VerticalOverflow; }
            set { SelectionTab.VerticalOverflow = value; }
        }

        public readonly static DependencyProperty SelectionTabLineSpacingProperty = Button.LineSpacingProperty;
        public System.Single SelectionTabLineSpacing
        {
            get { return SelectionTab.LineSpacing; }
            set { SelectionTab.LineSpacing = value; }
        }

        public readonly static DependencyProperty SelectionTabFontStyleProperty = Button.FontStyleProperty;
        public UnityEngine.FontStyle SelectionTabFontStyle
        {
            get { return SelectionTab.FontStyle; }
            set { SelectionTab.FontStyle = value; }
        }

        public readonly static DependencyProperty SelectionTabOnCullStateChangedProperty = Button.OnCullStateChangedProperty;
        public UnityEngine.UI.MaskableGraphic.CullStateChangedEvent SelectionTabOnCullStateChanged
        {
            get { return SelectionTab.OnCullStateChanged; }
            set { SelectionTab.OnCullStateChanged = value; }
        }

        public readonly static DependencyProperty SelectionTabMaskableProperty = Button.MaskableProperty;
        public System.Boolean SelectionTabMaskable
        {
            get { return SelectionTab.Maskable; }
            set { SelectionTab.Maskable = value; }
        }

        public readonly static DependencyProperty SelectionTabFontColorProperty = Button.FontColorProperty;
        public UnityEngine.Color SelectionTabFontColor
        {
            get { return SelectionTab.FontColor; }
            set { SelectionTab.FontColor = value; }
        }

        public readonly static DependencyProperty SelectionTabRaycastTargetProperty = Button.RaycastTargetProperty;
        public System.Boolean SelectionTabRaycastTarget
        {
            get { return SelectionTab.RaycastTarget; }
            set { SelectionTab.RaycastTarget = value; }
        }

        public readonly static DependencyProperty SelectionTabMaterialProperty = Button.MaterialProperty;
        public MaterialAsset SelectionTabMaterial
        {
            get { return SelectionTab.Material; }
            set { SelectionTab.Material = value; }
        }

        public readonly static DependencyProperty SelectionTabLabelWidthProperty = Button.LabelWidthProperty;
        public Delight.ElementSize SelectionTabLabelWidth
        {
            get { return SelectionTab.LabelWidth; }
            set { SelectionTab.LabelWidth = value; }
        }

        public readonly static DependencyProperty SelectionTabLabelHeightProperty = Button.LabelHeightProperty;
        public Delight.ElementSize SelectionTabLabelHeight
        {
            get { return SelectionTab.LabelHeight; }
            set { SelectionTab.LabelHeight = value; }
        }

        public readonly static DependencyProperty SelectionTabLabelOverrideWidthProperty = Button.LabelOverrideWidthProperty;
        public Delight.ElementSize SelectionTabLabelOverrideWidth
        {
            get { return SelectionTab.LabelOverrideWidth; }
            set { SelectionTab.LabelOverrideWidth = value; }
        }

        public readonly static DependencyProperty SelectionTabLabelOverrideHeightProperty = Button.LabelOverrideHeightProperty;
        public Delight.ElementSize SelectionTabLabelOverrideHeight
        {
            get { return SelectionTab.LabelOverrideHeight; }
            set { SelectionTab.LabelOverrideHeight = value; }
        }

        public readonly static DependencyProperty SelectionTabLabelScaleProperty = Button.LabelScaleProperty;
        public UnityEngine.Vector3 SelectionTabLabelScale
        {
            get { return SelectionTab.LabelScale; }
            set { SelectionTab.LabelScale = value; }
        }

        public readonly static DependencyProperty SelectionTabLabelAlignmentProperty = Button.LabelAlignmentProperty;
        public Delight.ElementAlignment SelectionTabLabelAlignment
        {
            get { return SelectionTab.LabelAlignment; }
            set { SelectionTab.LabelAlignment = value; }
        }

        public readonly static DependencyProperty SelectionTabLabelMarginProperty = Button.LabelMarginProperty;
        public Delight.ElementMargin SelectionTabLabelMargin
        {
            get { return SelectionTab.LabelMargin; }
            set { SelectionTab.LabelMargin = value; }
        }

        public readonly static DependencyProperty SelectionTabLabelOffsetProperty = Button.LabelOffsetProperty;
        public Delight.ElementMargin SelectionTabLabelOffset
        {
            get { return SelectionTab.LabelOffset; }
            set { SelectionTab.LabelOffset = value; }
        }

        public readonly static DependencyProperty SelectionTabLabelOffsetFromParentProperty = Button.LabelOffsetFromParentProperty;
        public Delight.ElementMargin SelectionTabLabelOffsetFromParent
        {
            get { return SelectionTab.LabelOffsetFromParent; }
            set { SelectionTab.LabelOffsetFromParent = value; }
        }

        public readonly static DependencyProperty SelectionTabLabelPivotProperty = Button.LabelPivotProperty;
        public UnityEngine.Vector2 SelectionTabLabelPivot
        {
            get { return SelectionTab.LabelPivot; }
            set { SelectionTab.LabelPivot = value; }
        }

        public readonly static DependencyProperty SelectionTabLabelLayoutRootProperty = Button.LabelLayoutRootProperty;
        public Delight.LayoutRoot SelectionTabLabelLayoutRoot
        {
            get { return SelectionTab.LabelLayoutRoot; }
            set { SelectionTab.LabelLayoutRoot = value; }
        }

        public readonly static DependencyProperty SelectionTabLabelDisableLayoutUpdateProperty = Button.LabelDisableLayoutUpdateProperty;
        public System.Boolean SelectionTabLabelDisableLayoutUpdate
        {
            get { return SelectionTab.LabelDisableLayoutUpdate; }
            set { SelectionTab.LabelDisableLayoutUpdate = value; }
        }

        public readonly static DependencyProperty SelectionTabLabelAlphaProperty = Button.LabelAlphaProperty;
        public System.Single SelectionTabLabelAlpha
        {
            get { return SelectionTab.LabelAlpha; }
            set { SelectionTab.LabelAlpha = value; }
        }

        public readonly static DependencyProperty SelectionTabLabelIsVisibleProperty = Button.LabelIsVisibleProperty;
        public System.Boolean SelectionTabLabelIsVisible
        {
            get { return SelectionTab.LabelIsVisible; }
            set { SelectionTab.LabelIsVisible = value; }
        }

        public readonly static DependencyProperty SelectionTabLabelRaycastBlockModeProperty = Button.LabelRaycastBlockModeProperty;
        public Delight.RaycastBlockMode SelectionTabLabelRaycastBlockMode
        {
            get { return SelectionTab.LabelRaycastBlockMode; }
            set { SelectionTab.LabelRaycastBlockMode = value; }
        }

        public readonly static DependencyProperty SelectionTabLabelUseFastShaderProperty = Button.LabelUseFastShaderProperty;
        public System.Boolean SelectionTabLabelUseFastShader
        {
            get { return SelectionTab.LabelUseFastShader; }
            set { SelectionTab.LabelUseFastShader = value; }
        }

        public readonly static DependencyProperty SelectionTabLabelBubbleNotifyChildLayoutChangedProperty = Button.LabelBubbleNotifyChildLayoutChangedProperty;
        public System.Boolean SelectionTabLabelBubbleNotifyChildLayoutChanged
        {
            get { return SelectionTab.LabelBubbleNotifyChildLayoutChanged; }
            set { SelectionTab.LabelBubbleNotifyChildLayoutChanged = value; }
        }

        public readonly static DependencyProperty SelectionTabLabelIgnoreFlipProperty = Button.LabelIgnoreFlipProperty;
        public System.Boolean SelectionTabLabelIgnoreFlip
        {
            get { return SelectionTab.LabelIgnoreFlip; }
            set { SelectionTab.LabelIgnoreFlip = value; }
        }

        public readonly static DependencyProperty SelectionTabLabelGameObjectProperty = Button.LabelGameObjectProperty;
        public UnityEngine.GameObject SelectionTabLabelGameObject
        {
            get { return SelectionTab.LabelGameObject; }
            set { SelectionTab.LabelGameObject = value; }
        }

        public readonly static DependencyProperty SelectionTabLabelEnableScriptEventsProperty = Button.LabelEnableScriptEventsProperty;
        public System.Boolean SelectionTabLabelEnableScriptEvents
        {
            get { return SelectionTab.LabelEnableScriptEvents; }
            set { SelectionTab.LabelEnableScriptEvents = value; }
        }

        public readonly static DependencyProperty SelectionTabLabelIgnoreObjectProperty = Button.LabelIgnoreObjectProperty;
        public System.Boolean SelectionTabLabelIgnoreObject
        {
            get { return SelectionTab.LabelIgnoreObject; }
            set { SelectionTab.LabelIgnoreObject = value; }
        }

        public readonly static DependencyProperty SelectionTabLabelIsActiveProperty = Button.LabelIsActiveProperty;
        public System.Boolean SelectionTabLabelIsActive
        {
            get { return SelectionTab.LabelIsActive; }
            set { SelectionTab.LabelIsActive = value; }
        }

        public readonly static DependencyProperty SelectionTabLabelLoadModeProperty = Button.LabelLoadModeProperty;
        public Delight.LoadMode SelectionTabLabelLoadMode
        {
            get { return SelectionTab.LabelLoadMode; }
            set { SelectionTab.LabelLoadMode = value; }
        }

        public readonly static DependencyProperty SelectionTabBackgroundSpriteProperty = Button.BackgroundSpriteProperty;
        public SpriteAsset SelectionTabBackgroundSprite
        {
            get { return SelectionTab.BackgroundSprite; }
            set { SelectionTab.BackgroundSprite = value; }
        }

        public readonly static DependencyProperty SelectionTabBackgroundOverrideSpriteProperty = Button.BackgroundOverrideSpriteProperty;
        public SpriteAsset SelectionTabBackgroundOverrideSprite
        {
            get { return SelectionTab.BackgroundOverrideSprite; }
            set { SelectionTab.BackgroundOverrideSprite = value; }
        }

        public readonly static DependencyProperty SelectionTabBackgroundTypeProperty = Button.BackgroundTypeProperty;
        public UnityEngine.UI.Image.Type SelectionTabBackgroundType
        {
            get { return SelectionTab.BackgroundType; }
            set { SelectionTab.BackgroundType = value; }
        }

        public readonly static DependencyProperty SelectionTabBackgroundPreserveAspectProperty = Button.BackgroundPreserveAspectProperty;
        public System.Boolean SelectionTabBackgroundPreserveAspect
        {
            get { return SelectionTab.BackgroundPreserveAspect; }
            set { SelectionTab.BackgroundPreserveAspect = value; }
        }

        public readonly static DependencyProperty SelectionTabBackgroundFillCenterProperty = Button.BackgroundFillCenterProperty;
        public System.Boolean SelectionTabBackgroundFillCenter
        {
            get { return SelectionTab.BackgroundFillCenter; }
            set { SelectionTab.BackgroundFillCenter = value; }
        }

        public readonly static DependencyProperty SelectionTabBackgroundFillMethodProperty = Button.BackgroundFillMethodProperty;
        public UnityEngine.UI.Image.FillMethod SelectionTabBackgroundFillMethod
        {
            get { return SelectionTab.BackgroundFillMethod; }
            set { SelectionTab.BackgroundFillMethod = value; }
        }

        public readonly static DependencyProperty SelectionTabBackgroundFillAmountProperty = Button.BackgroundFillAmountProperty;
        public System.Single SelectionTabBackgroundFillAmount
        {
            get { return SelectionTab.BackgroundFillAmount; }
            set { SelectionTab.BackgroundFillAmount = value; }
        }

        public readonly static DependencyProperty SelectionTabBackgroundFillClockwiseProperty = Button.BackgroundFillClockwiseProperty;
        public System.Boolean SelectionTabBackgroundFillClockwise
        {
            get { return SelectionTab.BackgroundFillClockwise; }
            set { SelectionTab.BackgroundFillClockwise = value; }
        }

        public readonly static DependencyProperty SelectionTabBackgroundFillOriginProperty = Button.BackgroundFillOriginProperty;
        public System.Int32 SelectionTabBackgroundFillOrigin
        {
            get { return SelectionTab.BackgroundFillOrigin; }
            set { SelectionTab.BackgroundFillOrigin = value; }
        }

        public readonly static DependencyProperty SelectionTabBackgroundAlphaHitTestMinimumThresholdProperty = Button.BackgroundAlphaHitTestMinimumThresholdProperty;
        public System.Single SelectionTabBackgroundAlphaHitTestMinimumThreshold
        {
            get { return SelectionTab.BackgroundAlphaHitTestMinimumThreshold; }
            set { SelectionTab.BackgroundAlphaHitTestMinimumThreshold = value; }
        }

        public readonly static DependencyProperty SelectionTabBackgroundUseSpriteMeshProperty = Button.BackgroundUseSpriteMeshProperty;
        public System.Boolean SelectionTabBackgroundUseSpriteMesh
        {
            get { return SelectionTab.BackgroundUseSpriteMesh; }
            set { SelectionTab.BackgroundUseSpriteMesh = value; }
        }

        public readonly static DependencyProperty SelectionTabBackgroundMaterialProperty = Button.BackgroundMaterialProperty;
        public MaterialAsset SelectionTabBackgroundMaterial
        {
            get { return SelectionTab.BackgroundMaterial; }
            set { SelectionTab.BackgroundMaterial = value; }
        }

        public readonly static DependencyProperty SelectionTabBackgroundOnCullStateChangedProperty = Button.BackgroundOnCullStateChangedProperty;
        public UnityEngine.UI.MaskableGraphic.CullStateChangedEvent SelectionTabBackgroundOnCullStateChanged
        {
            get { return SelectionTab.BackgroundOnCullStateChanged; }
            set { SelectionTab.BackgroundOnCullStateChanged = value; }
        }

        public readonly static DependencyProperty SelectionTabBackgroundMaskableProperty = Button.BackgroundMaskableProperty;
        public System.Boolean SelectionTabBackgroundMaskable
        {
            get { return SelectionTab.BackgroundMaskable; }
            set { SelectionTab.BackgroundMaskable = value; }
        }

        public readonly static DependencyProperty SelectionTabBackgroundColorProperty = Button.BackgroundColorProperty;
        public UnityEngine.Color SelectionTabBackgroundColor
        {
            get { return SelectionTab.BackgroundColor; }
            set { SelectionTab.BackgroundColor = value; }
        }

        public readonly static DependencyProperty SelectionTabBackgroundRaycastTargetProperty = Button.BackgroundRaycastTargetProperty;
        public System.Boolean SelectionTabBackgroundRaycastTarget
        {
            get { return SelectionTab.BackgroundRaycastTarget; }
            set { SelectionTab.BackgroundRaycastTarget = value; }
        }

        public readonly static DependencyProperty SelectionTabWidthProperty = Button.WidthProperty;
        public Delight.ElementSize SelectionTabWidth
        {
            get { return SelectionTab.Width; }
            set { SelectionTab.Width = value; }
        }

        public readonly static DependencyProperty SelectionTabHeightProperty = Button.HeightProperty;
        public Delight.ElementSize SelectionTabHeight
        {
            get { return SelectionTab.Height; }
            set { SelectionTab.Height = value; }
        }

        public readonly static DependencyProperty SelectionTabOverrideWidthProperty = Button.OverrideWidthProperty;
        public Delight.ElementSize SelectionTabOverrideWidth
        {
            get { return SelectionTab.OverrideWidth; }
            set { SelectionTab.OverrideWidth = value; }
        }

        public readonly static DependencyProperty SelectionTabOverrideHeightProperty = Button.OverrideHeightProperty;
        public Delight.ElementSize SelectionTabOverrideHeight
        {
            get { return SelectionTab.OverrideHeight; }
            set { SelectionTab.OverrideHeight = value; }
        }

        public readonly static DependencyProperty SelectionTabScaleProperty = Button.ScaleProperty;
        public UnityEngine.Vector3 SelectionTabScale
        {
            get { return SelectionTab.Scale; }
            set { SelectionTab.Scale = value; }
        }

        public readonly static DependencyProperty SelectionTabAlignmentProperty = Button.AlignmentProperty;
        public Delight.ElementAlignment SelectionTabAlignment
        {
            get { return SelectionTab.Alignment; }
            set { SelectionTab.Alignment = value; }
        }

        public readonly static DependencyProperty SelectionTabMarginProperty = Button.MarginProperty;
        public Delight.ElementMargin SelectionTabMargin
        {
            get { return SelectionTab.Margin; }
            set { SelectionTab.Margin = value; }
        }

        public readonly static DependencyProperty SelectionTabOffsetProperty = Button.OffsetProperty;
        public Delight.ElementMargin SelectionTabOffset
        {
            get { return SelectionTab.Offset; }
            set { SelectionTab.Offset = value; }
        }

        public readonly static DependencyProperty SelectionTabOffsetFromParentProperty = Button.OffsetFromParentProperty;
        public Delight.ElementMargin SelectionTabOffsetFromParent
        {
            get { return SelectionTab.OffsetFromParent; }
            set { SelectionTab.OffsetFromParent = value; }
        }

        public readonly static DependencyProperty SelectionTabPivotProperty = Button.PivotProperty;
        public UnityEngine.Vector2 SelectionTabPivot
        {
            get { return SelectionTab.Pivot; }
            set { SelectionTab.Pivot = value; }
        }

        public readonly static DependencyProperty SelectionTabLayoutRootProperty = Button.LayoutRootProperty;
        public Delight.LayoutRoot SelectionTabLayoutRoot
        {
            get { return SelectionTab.LayoutRoot; }
            set { SelectionTab.LayoutRoot = value; }
        }

        public readonly static DependencyProperty SelectionTabDisableLayoutUpdateProperty = Button.DisableLayoutUpdateProperty;
        public System.Boolean SelectionTabDisableLayoutUpdate
        {
            get { return SelectionTab.DisableLayoutUpdate; }
            set { SelectionTab.DisableLayoutUpdate = value; }
        }

        public readonly static DependencyProperty SelectionTabAlphaProperty = Button.AlphaProperty;
        public System.Single SelectionTabAlpha
        {
            get { return SelectionTab.Alpha; }
            set { SelectionTab.Alpha = value; }
        }

        public readonly static DependencyProperty SelectionTabIsVisibleProperty = Button.IsVisibleProperty;
        public System.Boolean SelectionTabIsVisible
        {
            get { return SelectionTab.IsVisible; }
            set { SelectionTab.IsVisible = value; }
        }

        public readonly static DependencyProperty SelectionTabRaycastBlockModeProperty = Button.RaycastBlockModeProperty;
        public Delight.RaycastBlockMode SelectionTabRaycastBlockMode
        {
            get { return SelectionTab.RaycastBlockMode; }
            set { SelectionTab.RaycastBlockMode = value; }
        }

        public readonly static DependencyProperty SelectionTabUseFastShaderProperty = Button.UseFastShaderProperty;
        public System.Boolean SelectionTabUseFastShader
        {
            get { return SelectionTab.UseFastShader; }
            set { SelectionTab.UseFastShader = value; }
        }

        public readonly static DependencyProperty SelectionTabBubbleNotifyChildLayoutChangedProperty = Button.BubbleNotifyChildLayoutChangedProperty;
        public System.Boolean SelectionTabBubbleNotifyChildLayoutChanged
        {
            get { return SelectionTab.BubbleNotifyChildLayoutChanged; }
            set { SelectionTab.BubbleNotifyChildLayoutChanged = value; }
        }

        public readonly static DependencyProperty SelectionTabIgnoreFlipProperty = Button.IgnoreFlipProperty;
        public System.Boolean SelectionTabIgnoreFlip
        {
            get { return SelectionTab.IgnoreFlip; }
            set { SelectionTab.IgnoreFlip = value; }
        }

        public readonly static DependencyProperty SelectionTabGameObjectProperty = Button.GameObjectProperty;
        public UnityEngine.GameObject SelectionTabGameObject
        {
            get { return SelectionTab.GameObject; }
            set { SelectionTab.GameObject = value; }
        }

        public readonly static DependencyProperty SelectionTabEnableScriptEventsProperty = Button.EnableScriptEventsProperty;
        public System.Boolean SelectionTabEnableScriptEvents
        {
            get { return SelectionTab.EnableScriptEvents; }
            set { SelectionTab.EnableScriptEvents = value; }
        }

        public readonly static DependencyProperty SelectionTabIgnoreObjectProperty = Button.IgnoreObjectProperty;
        public System.Boolean SelectionTabIgnoreObject
        {
            get { return SelectionTab.IgnoreObject; }
            set { SelectionTab.IgnoreObject = value; }
        }

        public readonly static DependencyProperty SelectionTabIsActiveProperty = Button.IsActiveProperty;
        public System.Boolean SelectionTabIsActive
        {
            get { return SelectionTab.IsActive; }
            set { SelectionTab.IsActive = value; }
        }

        public readonly static DependencyProperty SelectionTabLoadModeProperty = Button.LoadModeProperty;
        public Delight.LoadMode SelectionTabLoadMode
        {
            get { return SelectionTab.LoadMode; }
            set { SelectionTab.LoadMode = value; }
        }

        #endregion
    }

    #region Data Templates

    public static class SelectionIndicatorTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return SelectionIndicator;
            }
        }

        private static Template _selectionIndicator;
        public static Template SelectionIndicator
        {
            get
            {
#if UNITY_EDITOR
                if (_selectionIndicator == null || _selectionIndicator.CurrentVersion != Template.Version)
#else
                if (_selectionIndicator == null)
#endif
                {
                    _selectionIndicator = new Template(UIImageViewTemplates.UIImageView);
#if UNITY_EDITOR
                    _selectionIndicator.Name = "SelectionIndicator";
#endif
                    Delight.SelectionIndicator.WidthProperty.SetDefault(_selectionIndicator, new ElementSize(1f, ElementSizeUnit.Percents));
                    Delight.SelectionIndicator.HeightProperty.SetDefault(_selectionIndicator, new ElementSize(1f, ElementSizeUnit.Percents));
                    Delight.SelectionIndicator.BackgroundSpriteProperty.SetDefault(_selectionIndicator, Assets.Sprites["Selection"]);
                    Delight.SelectionIndicator.SelectionTabTemplateProperty.SetDefault(_selectionIndicator, SelectionIndicatorSelectionTab);
                }
                return _selectionIndicator;
            }
        }

        private static Template _selectionIndicatorSelectionTab;
        public static Template SelectionIndicatorSelectionTab
        {
            get
            {
#if UNITY_EDITOR
                if (_selectionIndicatorSelectionTab == null || _selectionIndicatorSelectionTab.CurrentVersion != Template.Version)
#else
                if (_selectionIndicatorSelectionTab == null)
#endif
                {
                    _selectionIndicatorSelectionTab = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _selectionIndicatorSelectionTab.Name = "SelectionIndicatorSelectionTab";
#endif
                    Delight.Button.HeightProperty.SetDefault(_selectionIndicatorSelectionTab, new ElementSize(15f, ElementSizeUnit.Pixels));
                    Delight.Button.AlignmentProperty.SetDefault(_selectionIndicatorSelectionTab, Delight.ElementAlignment.TopLeft);
                    Delight.Button.OffsetProperty.SetDefault(_selectionIndicatorSelectionTab, new ElementMargin(new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(15f, ElementSizeUnit.Pixels)));
                    Delight.Button.BackgroundColorProperty.SetDefault(_selectionIndicatorSelectionTab, new UnityEngine.Color(0.9568627f, 0.9568627f, 0.9568627f, 1f));
                    Delight.Button.BackgroundColorProperty.SetStateDefault("Highlighted", _selectionIndicatorSelectionTab, new UnityEngine.Color(0.9568627f, 0.9568627f, 0.9568627f, 1f));
                    Delight.Button.BackgroundColorProperty.SetStateDefault("Pressed", _selectionIndicatorSelectionTab, new UnityEngine.Color(0.9568627f, 0.9568627f, 0.9568627f, 1f));
                    Delight.Button.LabelTemplateProperty.SetDefault(_selectionIndicatorSelectionTab, SelectionIndicatorSelectionTabLabel);
                }
                return _selectionIndicatorSelectionTab;
            }
        }

        private static Template _selectionIndicatorSelectionTabLabel;
        public static Template SelectionIndicatorSelectionTabLabel
        {
            get
            {
#if UNITY_EDITOR
                if (_selectionIndicatorSelectionTabLabel == null || _selectionIndicatorSelectionTabLabel.CurrentVersion != Template.Version)
#else
                if (_selectionIndicatorSelectionTabLabel == null)
#endif
                {
                    _selectionIndicatorSelectionTabLabel = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _selectionIndicatorSelectionTabLabel.Name = "SelectionIndicatorSelectionTabLabel";
#endif
                    Delight.Label.TextProperty.SetDefault(_selectionIndicatorSelectionTabLabel, "Button");
                    Delight.Label.FontSizeProperty.SetDefault(_selectionIndicatorSelectionTabLabel, 10);
                    Delight.Label.FontColorProperty.SetDefault(_selectionIndicatorSelectionTabLabel, new UnityEngine.Color(0.4784314f, 0.4313726f, 0.4313726f, 1f));
                    Delight.Label.FontColorProperty.SetStateDefault("Highlighted", _selectionIndicatorSelectionTabLabel, new UnityEngine.Color(0.4784314f, 0.4313726f, 0.4313726f, 1f));
                    Delight.Label.FontColorProperty.SetStateDefault("Pressed", _selectionIndicatorSelectionTabLabel, new UnityEngine.Color(0.4784314f, 0.4313726f, 0.4313726f, 1f));
                }
                return _selectionIndicatorSelectionTabLabel;
            }
        }

        #endregion
    }

    #endregion
}
