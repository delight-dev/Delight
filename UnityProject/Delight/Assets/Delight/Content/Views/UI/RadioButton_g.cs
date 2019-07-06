// Internal view logic generated from "RadioButton.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class RadioButton : UIImageView
    {
        #region Constructors

        public RadioButton(View parent, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :
            base(parent, layoutParent, id, template ?? RadioButtonTemplates.Default, initializer)
        {
            // constructing Group (RadioButtonGroup)
            RadioButtonGroup = new Group(this, this, "RadioButtonGroup", RadioButtonGroupTemplate);

            // binding <Group Spacing="{Spacing}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "Spacing" }, new List<Func<BindableObject>> { () => this }) }, new BindingPath(new List<string> { "RadioButtonGroup", "Spacing" }, new List<Func<BindableObject>> { () => this, () => RadioButtonGroup }), () => RadioButtonGroup.Spacing = Spacing, () => { }, false));
            RadioButtonImageView = new Image(this, RadioButtonGroup.Content, "RadioButtonImageView", RadioButtonImageViewTemplate);
            RadioButtonLabel = new Label(this, RadioButtonGroup.Content, "RadioButtonLabel", RadioButtonLabelTemplate);
            Click.RegisterHandler(this, "RadioButtonClick");
            this.AfterInitializeInternal();
        }

        public RadioButton() : this(null)
        {
        }

        static RadioButton()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(RadioButtonTemplates.Default, dependencyProperties);

            dependencyProperties.Add(IsCheckedProperty);
            dependencyProperties.Add(IsDisabledProperty);
            dependencyProperties.Add(IsInteractableProperty);
            dependencyProperties.Add(SpacingProperty);
            dependencyProperties.Add(RadioButtonGroupProperty);
            dependencyProperties.Add(RadioButtonGroupTemplateProperty);
            dependencyProperties.Add(RadioButtonImageViewProperty);
            dependencyProperties.Add(RadioButtonImageViewTemplateProperty);
            dependencyProperties.Add(RadioButtonLabelProperty);
            dependencyProperties.Add(RadioButtonLabelTemplateProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<System.Boolean> IsCheckedProperty = new DependencyProperty<System.Boolean>("IsChecked");
        public System.Boolean IsChecked
        {
            get { return IsCheckedProperty.GetValue(this); }
            set { IsCheckedProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> IsDisabledProperty = new DependencyProperty<System.Boolean>("IsDisabled");
        public System.Boolean IsDisabled
        {
            get { return IsDisabledProperty.GetValue(this); }
            set { IsDisabledProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> IsInteractableProperty = new DependencyProperty<System.Boolean>("IsInteractable");
        public System.Boolean IsInteractable
        {
            get { return IsInteractableProperty.GetValue(this); }
            set { IsInteractableProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Delight.ElementSize> SpacingProperty = new DependencyProperty<Delight.ElementSize>("Spacing");
        public Delight.ElementSize Spacing
        {
            get { return SpacingProperty.GetValue(this); }
            set { SpacingProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Group> RadioButtonGroupProperty = new DependencyProperty<Group>("RadioButtonGroup");
        public Group RadioButtonGroup
        {
            get { return RadioButtonGroupProperty.GetValue(this); }
            set { RadioButtonGroupProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> RadioButtonGroupTemplateProperty = new DependencyProperty<Template>("RadioButtonGroupTemplate");
        public Template RadioButtonGroupTemplate
        {
            get { return RadioButtonGroupTemplateProperty.GetValue(this); }
            set { RadioButtonGroupTemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Image> RadioButtonImageViewProperty = new DependencyProperty<Image>("RadioButtonImageView");
        public Image RadioButtonImageView
        {
            get { return RadioButtonImageViewProperty.GetValue(this); }
            set { RadioButtonImageViewProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> RadioButtonImageViewTemplateProperty = new DependencyProperty<Template>("RadioButtonImageViewTemplate");
        public Template RadioButtonImageViewTemplate
        {
            get { return RadioButtonImageViewTemplateProperty.GetValue(this); }
            set { RadioButtonImageViewTemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Label> RadioButtonLabelProperty = new DependencyProperty<Label>("RadioButtonLabel");
        public Label RadioButtonLabel
        {
            get { return RadioButtonLabelProperty.GetValue(this); }
            set { RadioButtonLabelProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> RadioButtonLabelTemplateProperty = new DependencyProperty<Template>("RadioButtonLabelTemplate");
        public Template RadioButtonLabelTemplate
        {
            get { return RadioButtonLabelTemplateProperty.GetValue(this); }
            set { RadioButtonLabelTemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty RadioButtonSpriteProperty = Image.SpriteProperty;
        public SpriteAsset RadioButtonSprite
        {
            get { return RadioButtonImageView.Sprite; }
            set { RadioButtonImageView.Sprite = value; }
        }

        public readonly static DependencyProperty RadioButtonOverrideSpriteProperty = Image.OverrideSpriteProperty;
        public SpriteAsset RadioButtonOverrideSprite
        {
            get { return RadioButtonImageView.OverrideSprite; }
            set { RadioButtonImageView.OverrideSprite = value; }
        }

        public readonly static DependencyProperty RadioButtonTypeProperty = Image.TypeProperty;
        public UnityEngine.UI.Image.Type RadioButtonType
        {
            get { return RadioButtonImageView.Type; }
            set { RadioButtonImageView.Type = value; }
        }

        public readonly static DependencyProperty RadioButtonPreserveAspectProperty = Image.PreserveAspectProperty;
        public System.Boolean RadioButtonPreserveAspect
        {
            get { return RadioButtonImageView.PreserveAspect; }
            set { RadioButtonImageView.PreserveAspect = value; }
        }

        public readonly static DependencyProperty RadioButtonFillCenterProperty = Image.FillCenterProperty;
        public System.Boolean RadioButtonFillCenter
        {
            get { return RadioButtonImageView.FillCenter; }
            set { RadioButtonImageView.FillCenter = value; }
        }

        public readonly static DependencyProperty RadioButtonFillMethodProperty = Image.FillMethodProperty;
        public UnityEngine.UI.Image.FillMethod RadioButtonFillMethod
        {
            get { return RadioButtonImageView.FillMethod; }
            set { RadioButtonImageView.FillMethod = value; }
        }

        public readonly static DependencyProperty RadioButtonFillAmountProperty = Image.FillAmountProperty;
        public System.Single RadioButtonFillAmount
        {
            get { return RadioButtonImageView.FillAmount; }
            set { RadioButtonImageView.FillAmount = value; }
        }

        public readonly static DependencyProperty RadioButtonFillClockwiseProperty = Image.FillClockwiseProperty;
        public System.Boolean RadioButtonFillClockwise
        {
            get { return RadioButtonImageView.FillClockwise; }
            set { RadioButtonImageView.FillClockwise = value; }
        }

        public readonly static DependencyProperty RadioButtonFillOriginProperty = Image.FillOriginProperty;
        public System.Int32 RadioButtonFillOrigin
        {
            get { return RadioButtonImageView.FillOrigin; }
            set { RadioButtonImageView.FillOrigin = value; }
        }

        public readonly static DependencyProperty RadioButtonAlphaHitTestMinimumThresholdProperty = Image.AlphaHitTestMinimumThresholdProperty;
        public System.Single RadioButtonAlphaHitTestMinimumThreshold
        {
            get { return RadioButtonImageView.AlphaHitTestMinimumThreshold; }
            set { RadioButtonImageView.AlphaHitTestMinimumThreshold = value; }
        }

        public readonly static DependencyProperty RadioButtonUseSpriteMeshProperty = Image.UseSpriteMeshProperty;
        public System.Boolean RadioButtonUseSpriteMesh
        {
            get { return RadioButtonImageView.UseSpriteMesh; }
            set { RadioButtonImageView.UseSpriteMesh = value; }
        }

        public readonly static DependencyProperty RadioButtonMaterialProperty = Image.MaterialProperty;
        public MaterialAsset RadioButtonMaterial
        {
            get { return RadioButtonImageView.Material; }
            set { RadioButtonImageView.Material = value; }
        }

        public readonly static DependencyProperty RadioButtonOnCullStateChangedProperty = Image.OnCullStateChangedProperty;
        public UnityEngine.UI.MaskableGraphic.CullStateChangedEvent RadioButtonOnCullStateChanged
        {
            get { return RadioButtonImageView.OnCullStateChanged; }
            set { RadioButtonImageView.OnCullStateChanged = value; }
        }

        public readonly static DependencyProperty RadioButtonMaskableProperty = Image.MaskableProperty;
        public System.Boolean RadioButtonMaskable
        {
            get { return RadioButtonImageView.Maskable; }
            set { RadioButtonImageView.Maskable = value; }
        }

        public readonly static DependencyProperty RadioButtonColorProperty = Image.ColorProperty;
        public UnityEngine.Color RadioButtonColor
        {
            get { return RadioButtonImageView.Color; }
            set { RadioButtonImageView.Color = value; }
        }

        public readonly static DependencyProperty RadioButtonRaycastTargetProperty = Image.RaycastTargetProperty;
        public System.Boolean RadioButtonRaycastTarget
        {
            get { return RadioButtonImageView.RaycastTarget; }
            set { RadioButtonImageView.RaycastTarget = value; }
        }

        public readonly static DependencyProperty RadioButtonWidthProperty = Image.WidthProperty;
        public Delight.ElementSize RadioButtonWidth
        {
            get { return RadioButtonImageView.Width; }
            set { RadioButtonImageView.Width = value; }
        }

        public readonly static DependencyProperty RadioButtonHeightProperty = Image.HeightProperty;
        public Delight.ElementSize RadioButtonHeight
        {
            get { return RadioButtonImageView.Height; }
            set { RadioButtonImageView.Height = value; }
        }

        public readonly static DependencyProperty RadioButtonOverrideWidthProperty = Image.OverrideWidthProperty;
        public Delight.ElementSize RadioButtonOverrideWidth
        {
            get { return RadioButtonImageView.OverrideWidth; }
            set { RadioButtonImageView.OverrideWidth = value; }
        }

        public readonly static DependencyProperty RadioButtonOverrideHeightProperty = Image.OverrideHeightProperty;
        public Delight.ElementSize RadioButtonOverrideHeight
        {
            get { return RadioButtonImageView.OverrideHeight; }
            set { RadioButtonImageView.OverrideHeight = value; }
        }

        public readonly static DependencyProperty RadioButtonScaleProperty = Image.ScaleProperty;
        public UnityEngine.Vector3 RadioButtonScale
        {
            get { return RadioButtonImageView.Scale; }
            set { RadioButtonImageView.Scale = value; }
        }

        public readonly static DependencyProperty RadioButtonAlignmentProperty = Image.AlignmentProperty;
        public Delight.ElementAlignment RadioButtonAlignment
        {
            get { return RadioButtonImageView.Alignment; }
            set { RadioButtonImageView.Alignment = value; }
        }

        public readonly static DependencyProperty RadioButtonMarginProperty = Image.MarginProperty;
        public Delight.ElementMargin RadioButtonMargin
        {
            get { return RadioButtonImageView.Margin; }
            set { RadioButtonImageView.Margin = value; }
        }

        public readonly static DependencyProperty RadioButtonOffsetProperty = Image.OffsetProperty;
        public Delight.ElementMargin RadioButtonOffset
        {
            get { return RadioButtonImageView.Offset; }
            set { RadioButtonImageView.Offset = value; }
        }

        public readonly static DependencyProperty RadioButtonOffsetFromParentProperty = Image.OffsetFromParentProperty;
        public Delight.ElementMargin RadioButtonOffsetFromParent
        {
            get { return RadioButtonImageView.OffsetFromParent; }
            set { RadioButtonImageView.OffsetFromParent = value; }
        }

        public readonly static DependencyProperty RadioButtonPivotProperty = Image.PivotProperty;
        public UnityEngine.Vector2 RadioButtonPivot
        {
            get { return RadioButtonImageView.Pivot; }
            set { RadioButtonImageView.Pivot = value; }
        }

        public readonly static DependencyProperty RadioButtonLayoutRootProperty = Image.LayoutRootProperty;
        public Delight.LayoutRoot RadioButtonLayoutRoot
        {
            get { return RadioButtonImageView.LayoutRoot; }
            set { RadioButtonImageView.LayoutRoot = value; }
        }

        public readonly static DependencyProperty RadioButtonDisableLayoutUpdateProperty = Image.DisableLayoutUpdateProperty;
        public System.Boolean RadioButtonDisableLayoutUpdate
        {
            get { return RadioButtonImageView.DisableLayoutUpdate; }
            set { RadioButtonImageView.DisableLayoutUpdate = value; }
        }

        public readonly static DependencyProperty RadioButtonAlphaProperty = Image.AlphaProperty;
        public System.Single RadioButtonAlpha
        {
            get { return RadioButtonImageView.Alpha; }
            set { RadioButtonImageView.Alpha = value; }
        }

        public readonly static DependencyProperty RadioButtonIsVisibleProperty = Image.IsVisibleProperty;
        public System.Boolean RadioButtonIsVisible
        {
            get { return RadioButtonImageView.IsVisible; }
            set { RadioButtonImageView.IsVisible = value; }
        }

        public readonly static DependencyProperty RadioButtonRaycastBlockModeProperty = Image.RaycastBlockModeProperty;
        public Delight.RaycastBlockMode RadioButtonRaycastBlockMode
        {
            get { return RadioButtonImageView.RaycastBlockMode; }
            set { RadioButtonImageView.RaycastBlockMode = value; }
        }

        public readonly static DependencyProperty RadioButtonUseFastShaderProperty = Image.UseFastShaderProperty;
        public System.Boolean RadioButtonUseFastShader
        {
            get { return RadioButtonImageView.UseFastShader; }
            set { RadioButtonImageView.UseFastShader = value; }
        }

        public readonly static DependencyProperty RadioButtonBubbleNotifyChildLayoutChangedProperty = Image.BubbleNotifyChildLayoutChangedProperty;
        public System.Boolean RadioButtonBubbleNotifyChildLayoutChanged
        {
            get { return RadioButtonImageView.BubbleNotifyChildLayoutChanged; }
            set { RadioButtonImageView.BubbleNotifyChildLayoutChanged = value; }
        }

        public readonly static DependencyProperty RadioButtonIgnoreFlipProperty = Image.IgnoreFlipProperty;
        public System.Boolean RadioButtonIgnoreFlip
        {
            get { return RadioButtonImageView.IgnoreFlip; }
            set { RadioButtonImageView.IgnoreFlip = value; }
        }

        public readonly static DependencyProperty RadioButtonGameObjectProperty = Image.GameObjectProperty;
        public UnityEngine.GameObject RadioButtonGameObject
        {
            get { return RadioButtonImageView.GameObject; }
            set { RadioButtonImageView.GameObject = value; }
        }

        public readonly static DependencyProperty RadioButtonEnableScriptEventsProperty = Image.EnableScriptEventsProperty;
        public System.Boolean RadioButtonEnableScriptEvents
        {
            get { return RadioButtonImageView.EnableScriptEvents; }
            set { RadioButtonImageView.EnableScriptEvents = value; }
        }

        public readonly static DependencyProperty RadioButtonIgnoreObjectProperty = Image.IgnoreObjectProperty;
        public System.Boolean RadioButtonIgnoreObject
        {
            get { return RadioButtonImageView.IgnoreObject; }
            set { RadioButtonImageView.IgnoreObject = value; }
        }

        public readonly static DependencyProperty RadioButtonIsActiveProperty = Image.IsActiveProperty;
        public System.Boolean RadioButtonIsActive
        {
            get { return RadioButtonImageView.IsActive; }
            set { RadioButtonImageView.IsActive = value; }
        }

        public readonly static DependencyProperty RadioButtonLoadModeProperty = Image.LoadModeProperty;
        public Delight.LoadMode RadioButtonLoadMode
        {
            get { return RadioButtonImageView.LoadMode; }
            set { RadioButtonImageView.LoadMode = value; }
        }

        public readonly static DependencyProperty TextAlignmentProperty = Label.TextAlignmentProperty;
        public Delight.ElementAlignment TextAlignment
        {
            get { return RadioButtonLabel.TextAlignment; }
            set { RadioButtonLabel.TextAlignment = value; }
        }

        public readonly static DependencyProperty EnableWordWrappingProperty = Label.EnableWordWrappingProperty;
        public System.Boolean EnableWordWrapping
        {
            get { return RadioButtonLabel.EnableWordWrapping; }
            set { RadioButtonLabel.EnableWordWrapping = value; }
        }

        public readonly static DependencyProperty AutoSizeProperty = Label.AutoSizeProperty;
        public Delight.AutoSize AutoSize
        {
            get { return RadioButtonLabel.AutoSize; }
            set { RadioButtonLabel.AutoSize = value; }
        }

        public readonly static DependencyProperty OverflowModeProperty = Label.OverflowModeProperty;
        public System.String OverflowMode
        {
            get { return RadioButtonLabel.OverflowMode; }
            set { RadioButtonLabel.OverflowMode = value; }
        }

        public readonly static DependencyProperty ExtraPaddingProperty = Label.ExtraPaddingProperty;
        public System.Boolean ExtraPadding
        {
            get { return RadioButtonLabel.ExtraPadding; }
            set { RadioButtonLabel.ExtraPadding = value; }
        }

        public readonly static DependencyProperty FontProperty = Label.FontProperty;
        public FontAsset Font
        {
            get { return RadioButtonLabel.Font; }
            set { RadioButtonLabel.Font = value; }
        }

        public readonly static DependencyProperty TextProperty = Label.TextProperty;
        public System.String Text
        {
            get { return RadioButtonLabel.Text; }
            set { RadioButtonLabel.Text = value; }
        }

        public readonly static DependencyProperty SupportRichTextProperty = Label.SupportRichTextProperty;
        public System.Boolean SupportRichText
        {
            get { return RadioButtonLabel.SupportRichText; }
            set { RadioButtonLabel.SupportRichText = value; }
        }

        public readonly static DependencyProperty ResizeTextForBestFitProperty = Label.ResizeTextForBestFitProperty;
        public System.Boolean ResizeTextForBestFit
        {
            get { return RadioButtonLabel.ResizeTextForBestFit; }
            set { RadioButtonLabel.ResizeTextForBestFit = value; }
        }

        public readonly static DependencyProperty ResizeTextMinSizeProperty = Label.ResizeTextMinSizeProperty;
        public System.Int32 ResizeTextMinSize
        {
            get { return RadioButtonLabel.ResizeTextMinSize; }
            set { RadioButtonLabel.ResizeTextMinSize = value; }
        }

        public readonly static DependencyProperty ResizeTextMaxSizeProperty = Label.ResizeTextMaxSizeProperty;
        public System.Int32 ResizeTextMaxSize
        {
            get { return RadioButtonLabel.ResizeTextMaxSize; }
            set { RadioButtonLabel.ResizeTextMaxSize = value; }
        }

        public readonly static DependencyProperty TextComponentTextAlignmentProperty = Label.TextComponentTextAlignmentProperty;
        public UnityEngine.TextAnchor TextComponentTextAlignment
        {
            get { return RadioButtonLabel.TextComponentTextAlignment; }
            set { RadioButtonLabel.TextComponentTextAlignment = value; }
        }

        public readonly static DependencyProperty AlignByGeometryProperty = Label.AlignByGeometryProperty;
        public System.Boolean AlignByGeometry
        {
            get { return RadioButtonLabel.AlignByGeometry; }
            set { RadioButtonLabel.AlignByGeometry = value; }
        }

        public readonly static DependencyProperty FontSizeProperty = Label.FontSizeProperty;
        public System.Int32 FontSize
        {
            get { return RadioButtonLabel.FontSize; }
            set { RadioButtonLabel.FontSize = value; }
        }

        public readonly static DependencyProperty HorizontalOverflowProperty = Label.HorizontalOverflowProperty;
        public UnityEngine.HorizontalWrapMode HorizontalOverflow
        {
            get { return RadioButtonLabel.HorizontalOverflow; }
            set { RadioButtonLabel.HorizontalOverflow = value; }
        }

        public readonly static DependencyProperty VerticalOverflowProperty = Label.VerticalOverflowProperty;
        public UnityEngine.VerticalWrapMode VerticalOverflow
        {
            get { return RadioButtonLabel.VerticalOverflow; }
            set { RadioButtonLabel.VerticalOverflow = value; }
        }

        public readonly static DependencyProperty LineSpacingProperty = Label.LineSpacingProperty;
        public System.Single LineSpacing
        {
            get { return RadioButtonLabel.LineSpacing; }
            set { RadioButtonLabel.LineSpacing = value; }
        }

        public readonly static DependencyProperty FontStyleProperty = Label.FontStyleProperty;
        public UnityEngine.FontStyle FontStyle
        {
            get { return RadioButtonLabel.FontStyle; }
            set { RadioButtonLabel.FontStyle = value; }
        }

        public readonly static DependencyProperty OnCullStateChangedProperty = Label.OnCullStateChangedProperty;
        public UnityEngine.UI.MaskableGraphic.CullStateChangedEvent OnCullStateChanged
        {
            get { return RadioButtonLabel.OnCullStateChanged; }
            set { RadioButtonLabel.OnCullStateChanged = value; }
        }

        public readonly static DependencyProperty MaskableProperty = Label.MaskableProperty;
        public System.Boolean Maskable
        {
            get { return RadioButtonLabel.Maskable; }
            set { RadioButtonLabel.Maskable = value; }
        }

        public readonly static DependencyProperty FontColorProperty = Label.FontColorProperty;
        public UnityEngine.Color FontColor
        {
            get { return RadioButtonLabel.FontColor; }
            set { RadioButtonLabel.FontColor = value; }
        }

        public readonly static DependencyProperty RaycastTargetProperty = Label.RaycastTargetProperty;
        public System.Boolean RaycastTarget
        {
            get { return RadioButtonLabel.RaycastTarget; }
            set { RadioButtonLabel.RaycastTarget = value; }
        }

        public readonly static DependencyProperty MaterialProperty = Label.MaterialProperty;
        public MaterialAsset Material
        {
            get { return RadioButtonLabel.Material; }
            set { RadioButtonLabel.Material = value; }
        }

        public readonly static DependencyProperty RadioButtonLabelWidthProperty = Label.WidthProperty;
        public Delight.ElementSize RadioButtonLabelWidth
        {
            get { return RadioButtonLabel.Width; }
            set { RadioButtonLabel.Width = value; }
        }

        public readonly static DependencyProperty RadioButtonLabelHeightProperty = Label.HeightProperty;
        public Delight.ElementSize RadioButtonLabelHeight
        {
            get { return RadioButtonLabel.Height; }
            set { RadioButtonLabel.Height = value; }
        }

        public readonly static DependencyProperty RadioButtonLabelOverrideWidthProperty = Label.OverrideWidthProperty;
        public Delight.ElementSize RadioButtonLabelOverrideWidth
        {
            get { return RadioButtonLabel.OverrideWidth; }
            set { RadioButtonLabel.OverrideWidth = value; }
        }

        public readonly static DependencyProperty RadioButtonLabelOverrideHeightProperty = Label.OverrideHeightProperty;
        public Delight.ElementSize RadioButtonLabelOverrideHeight
        {
            get { return RadioButtonLabel.OverrideHeight; }
            set { RadioButtonLabel.OverrideHeight = value; }
        }

        public readonly static DependencyProperty RadioButtonLabelScaleProperty = Label.ScaleProperty;
        public UnityEngine.Vector3 RadioButtonLabelScale
        {
            get { return RadioButtonLabel.Scale; }
            set { RadioButtonLabel.Scale = value; }
        }

        public readonly static DependencyProperty RadioButtonLabelAlignmentProperty = Label.AlignmentProperty;
        public Delight.ElementAlignment RadioButtonLabelAlignment
        {
            get { return RadioButtonLabel.Alignment; }
            set { RadioButtonLabel.Alignment = value; }
        }

        public readonly static DependencyProperty RadioButtonLabelMarginProperty = Label.MarginProperty;
        public Delight.ElementMargin RadioButtonLabelMargin
        {
            get { return RadioButtonLabel.Margin; }
            set { RadioButtonLabel.Margin = value; }
        }

        public readonly static DependencyProperty RadioButtonLabelOffsetProperty = Label.OffsetProperty;
        public Delight.ElementMargin RadioButtonLabelOffset
        {
            get { return RadioButtonLabel.Offset; }
            set { RadioButtonLabel.Offset = value; }
        }

        public readonly static DependencyProperty RadioButtonLabelOffsetFromParentProperty = Label.OffsetFromParentProperty;
        public Delight.ElementMargin RadioButtonLabelOffsetFromParent
        {
            get { return RadioButtonLabel.OffsetFromParent; }
            set { RadioButtonLabel.OffsetFromParent = value; }
        }

        public readonly static DependencyProperty RadioButtonLabelPivotProperty = Label.PivotProperty;
        public UnityEngine.Vector2 RadioButtonLabelPivot
        {
            get { return RadioButtonLabel.Pivot; }
            set { RadioButtonLabel.Pivot = value; }
        }

        public readonly static DependencyProperty RadioButtonLabelLayoutRootProperty = Label.LayoutRootProperty;
        public Delight.LayoutRoot RadioButtonLabelLayoutRoot
        {
            get { return RadioButtonLabel.LayoutRoot; }
            set { RadioButtonLabel.LayoutRoot = value; }
        }

        public readonly static DependencyProperty RadioButtonLabelDisableLayoutUpdateProperty = Label.DisableLayoutUpdateProperty;
        public System.Boolean RadioButtonLabelDisableLayoutUpdate
        {
            get { return RadioButtonLabel.DisableLayoutUpdate; }
            set { RadioButtonLabel.DisableLayoutUpdate = value; }
        }

        public readonly static DependencyProperty RadioButtonLabelAlphaProperty = Label.AlphaProperty;
        public System.Single RadioButtonLabelAlpha
        {
            get { return RadioButtonLabel.Alpha; }
            set { RadioButtonLabel.Alpha = value; }
        }

        public readonly static DependencyProperty RadioButtonLabelIsVisibleProperty = Label.IsVisibleProperty;
        public System.Boolean RadioButtonLabelIsVisible
        {
            get { return RadioButtonLabel.IsVisible; }
            set { RadioButtonLabel.IsVisible = value; }
        }

        public readonly static DependencyProperty RadioButtonLabelRaycastBlockModeProperty = Label.RaycastBlockModeProperty;
        public Delight.RaycastBlockMode RadioButtonLabelRaycastBlockMode
        {
            get { return RadioButtonLabel.RaycastBlockMode; }
            set { RadioButtonLabel.RaycastBlockMode = value; }
        }

        public readonly static DependencyProperty RadioButtonLabelUseFastShaderProperty = Label.UseFastShaderProperty;
        public System.Boolean RadioButtonLabelUseFastShader
        {
            get { return RadioButtonLabel.UseFastShader; }
            set { RadioButtonLabel.UseFastShader = value; }
        }

        public readonly static DependencyProperty RadioButtonLabelBubbleNotifyChildLayoutChangedProperty = Label.BubbleNotifyChildLayoutChangedProperty;
        public System.Boolean RadioButtonLabelBubbleNotifyChildLayoutChanged
        {
            get { return RadioButtonLabel.BubbleNotifyChildLayoutChanged; }
            set { RadioButtonLabel.BubbleNotifyChildLayoutChanged = value; }
        }

        public readonly static DependencyProperty RadioButtonLabelIgnoreFlipProperty = Label.IgnoreFlipProperty;
        public System.Boolean RadioButtonLabelIgnoreFlip
        {
            get { return RadioButtonLabel.IgnoreFlip; }
            set { RadioButtonLabel.IgnoreFlip = value; }
        }

        public readonly static DependencyProperty RadioButtonLabelGameObjectProperty = Label.GameObjectProperty;
        public UnityEngine.GameObject RadioButtonLabelGameObject
        {
            get { return RadioButtonLabel.GameObject; }
            set { RadioButtonLabel.GameObject = value; }
        }

        public readonly static DependencyProperty RadioButtonLabelEnableScriptEventsProperty = Label.EnableScriptEventsProperty;
        public System.Boolean RadioButtonLabelEnableScriptEvents
        {
            get { return RadioButtonLabel.EnableScriptEvents; }
            set { RadioButtonLabel.EnableScriptEvents = value; }
        }

        public readonly static DependencyProperty RadioButtonLabelIgnoreObjectProperty = Label.IgnoreObjectProperty;
        public System.Boolean RadioButtonLabelIgnoreObject
        {
            get { return RadioButtonLabel.IgnoreObject; }
            set { RadioButtonLabel.IgnoreObject = value; }
        }

        public readonly static DependencyProperty RadioButtonLabelIsActiveProperty = Label.IsActiveProperty;
        public System.Boolean RadioButtonLabelIsActive
        {
            get { return RadioButtonLabel.IsActive; }
            set { RadioButtonLabel.IsActive = value; }
        }

        public readonly static DependencyProperty RadioButtonLabelLoadModeProperty = Label.LoadModeProperty;
        public Delight.LoadMode RadioButtonLabelLoadMode
        {
            get { return RadioButtonLabel.LoadMode; }
            set { RadioButtonLabel.LoadMode = value; }
        }

        #endregion
    }

    #region Data Templates

    public static class RadioButtonTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return RadioButton;
            }
        }

        private static Template _radioButton;
        public static Template RadioButton
        {
            get
            {
#if UNITY_EDITOR
                if (_radioButton == null || _radioButton.CurrentVersion != Template.Version)
#else
                if (_radioButton == null)
#endif
                {
                    _radioButton = new Template(UIImageViewTemplates.UIImageView);
#if UNITY_EDITOR
                    _radioButton.Name = "RadioButton";
#endif
                    Delight.RadioButton.IsInteractableProperty.SetDefault(_radioButton, true);
                    Delight.RadioButton.SpacingProperty.SetDefault(_radioButton, new ElementSize(10f, ElementSizeUnit.Pixels));
                    Delight.RadioButton.HeightProperty.SetDefault(_radioButton, new ElementSize(40f, ElementSizeUnit.Pixels));
                    Delight.RadioButton.HeightProperty.SetDefault(_radioButton, new ElementSize(25f, ElementSizeUnit.Pixels));
                    Delight.RadioButton.SpacingProperty.SetDefault(_radioButton, new ElementSize(10f, ElementSizeUnit.Pixels));
                    Delight.RadioButton.RadioButtonGroupTemplateProperty.SetDefault(_radioButton, RadioButtonRadioButtonGroup);
                    Delight.RadioButton.RadioButtonImageViewTemplateProperty.SetDefault(_radioButton, RadioButtonRadioButtonImageView);
                    Delight.RadioButton.RadioButtonLabelTemplateProperty.SetDefault(_radioButton, RadioButtonRadioButtonLabel);
                }
                return _radioButton;
            }
        }

        private static Template _radioButtonRadioButtonGroup;
        public static Template RadioButtonRadioButtonGroup
        {
            get
            {
#if UNITY_EDITOR
                if (_radioButtonRadioButtonGroup == null || _radioButtonRadioButtonGroup.CurrentVersion != Template.Version)
#else
                if (_radioButtonRadioButtonGroup == null)
#endif
                {
                    _radioButtonRadioButtonGroup = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _radioButtonRadioButtonGroup.Name = "RadioButtonRadioButtonGroup";
#endif
                    Delight.Group.OrientationProperty.SetDefault(_radioButtonRadioButtonGroup, Delight.ElementOrientation.Horizontal);
                    Delight.Group.SpacingProperty.SetHasBinding(_radioButtonRadioButtonGroup);
                }
                return _radioButtonRadioButtonGroup;
            }
        }

        private static Template _radioButtonRadioButtonImageView;
        public static Template RadioButtonRadioButtonImageView
        {
            get
            {
#if UNITY_EDITOR
                if (_radioButtonRadioButtonImageView == null || _radioButtonRadioButtonImageView.CurrentVersion != Template.Version)
#else
                if (_radioButtonRadioButtonImageView == null)
#endif
                {
                    _radioButtonRadioButtonImageView = new Template(ImageTemplates.Image);
#if UNITY_EDITOR
                    _radioButtonRadioButtonImageView.Name = "RadioButtonRadioButtonImageView";
#endif
                    Delight.Image.WidthProperty.SetDefault(_radioButtonRadioButtonImageView, new ElementSize(40f, ElementSizeUnit.Pixels));
                    Delight.Image.HeightProperty.SetDefault(_radioButtonRadioButtonImageView, new ElementSize(40f, ElementSizeUnit.Pixels));
                    Delight.Image.SpriteProperty.SetDefault(_radioButtonRadioButtonImageView, Assets.Sprites["RadioButton"]);
                    Delight.Image.SpriteProperty.SetStateDefault("Checked", _radioButtonRadioButtonImageView, Assets.Sprites["RadioButtonPressed"]);
                    Delight.Image.WidthProperty.SetDefault(_radioButtonRadioButtonImageView, new ElementSize(19f, ElementSizeUnit.Pixels));
                    Delight.Image.HeightProperty.SetDefault(_radioButtonRadioButtonImageView, new ElementSize(19f, ElementSizeUnit.Pixels));
                    Delight.Image.ColorProperty.SetDefault(_radioButtonRadioButtonImageView, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Image.OffsetProperty.SetDefault(_radioButtonRadioButtonImageView, new ElementMargin(new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(1f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels)));
                }
                return _radioButtonRadioButtonImageView;
            }
        }

        private static Template _radioButtonRadioButtonLabel;
        public static Template RadioButtonRadioButtonLabel
        {
            get
            {
#if UNITY_EDITOR
                if (_radioButtonRadioButtonLabel == null || _radioButtonRadioButtonLabel.CurrentVersion != Template.Version)
#else
                if (_radioButtonRadioButtonLabel == null)
#endif
                {
                    _radioButtonRadioButtonLabel = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _radioButtonRadioButtonLabel.Name = "RadioButtonRadioButtonLabel";
#endif
                    Delight.Label.AutoSizeProperty.SetDefault(_radioButtonRadioButtonLabel, Delight.AutoSize.Width);
                    Delight.Label.HeightProperty.SetDefault(_radioButtonRadioButtonLabel, new ElementSize(1f, ElementSizeUnit.Percents));
                    Delight.Label.FontSizeProperty.SetDefault(_radioButtonRadioButtonLabel, 18);
                    Delight.Label.FontColorProperty.SetDefault(_radioButtonRadioButtonLabel, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Label.FontStyleProperty.SetDefault(_radioButtonRadioButtonLabel, UnityEngine.FontStyle.Normal);
                    Delight.Label.FontStyleProperty.SetStateDefault("Disabled", _radioButtonRadioButtonLabel, UnityEngine.FontStyle.Italic);
                    Delight.Label.FontColorProperty.SetStateDefault("Disabled", _radioButtonRadioButtonLabel, new UnityEngine.Color(0.8f, 0.8f, 0.8f, 1f));
                }
                return _radioButtonRadioButtonLabel;
            }
        }

        #endregion
    }

    #endregion
}
