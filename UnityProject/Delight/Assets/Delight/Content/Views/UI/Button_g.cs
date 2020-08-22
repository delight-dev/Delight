// Internal view logic generated from "Button.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class Button : UIImageView
    {
        #region Constructors

        public Button(View parent, View layoutParent = null, string id = null, Template template = null, bool deferInitialization = false) :
            base(parent, layoutParent, id, template ?? ButtonTemplates.Default, deferInitialization)
        {
            if (deferInitialization)
                return;

            // constructing Label (Label)
            Label = new Label(this, this, "Label", LabelTemplate);

            // binding <Label Offset="{TextOffset}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "TextOffset" }, new List<Func<BindableObject>> { () => this }) }, new BindingPath(new List<string> { "Label", "Offset" }, new List<Func<BindableObject>> { () => this, () => Label }), () => Label.Offset = TextOffset, () => { }, false));

            // binding <Label IsActive="{DisplayLabel}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "DisplayLabel" }, new List<Func<BindableObject>> { () => this }) }, new BindingPath(new List<string> { "Label", "IsActive" }, new List<Func<BindableObject>> { () => this, () => Label }), () => Label.IsActive = DisplayLabel, () => { }, false));
            this.StateAnimations.Clear();
            var stateAnimation0 = new StateAnimation(AnyStateName, "Highlighted");
            stateAnimation0.Add(new Animator<UnityEngine.Color>(this, 0.05f, 0f, false, false, 0f, false, EasingFunctions.Get("Linear"), Delight.ColorValueConverter.Interpolator, x => this.BackgroundColor = x, () => this.BackgroundColor, () => Button.BackgroundColorProperty.NotifyPropertyChanged(this), Button.BackgroundColorProperty, AnyStateName, "Highlighted"));
            stateAnimation0.Add(new Animator<UnityEngine.Color>(this, 0.05f, 0f, false, false, 0f, false, EasingFunctions.Get("Linear"), Delight.ColorValueConverter.Interpolator, x => this.FontColor = x, () => this.FontColor, () => Button.FontColorProperty.NotifyPropertyChanged(this), Button.FontColorProperty, AnyStateName, "Highlighted"));
            this.StateAnimations.Add(stateAnimation0);
            var stateAnimation1 = new StateAnimation("Highlighted", DefaultStateName);
            stateAnimation1.Add(new Animator<UnityEngine.Color>(this, 0.5f, 0f, false, false, 0f, false, EasingFunctions.Get("Linear"), Delight.ColorValueConverter.Interpolator, x => this.BackgroundColor = x, () => this.BackgroundColor, () => Button.BackgroundColorProperty.NotifyPropertyChanged(this), Button.BackgroundColorProperty, "Highlighted", DefaultStateName));
            stateAnimation1.Add(new Animator<UnityEngine.Color>(this, 0.5f, 0f, false, false, 0f, false, EasingFunctions.Get("Linear"), Delight.ColorValueConverter.Interpolator, x => this.FontColor = x, () => this.FontColor, () => Button.FontColorProperty.NotifyPropertyChanged(this), Button.FontColorProperty, "Highlighted", DefaultStateName));
            this.StateAnimations.Add(stateAnimation1);
            Click.RegisterHandler(this, "ButtonMouseClick");
            MouseEnter.RegisterHandler(this, "ButtonMouseEnter");
            MouseExit.RegisterHandler(this, "ButtonMouseExit");
            MouseDown.RegisterHandler(this, "ButtonMouseDown");
            MouseUp.RegisterHandler(this, "ButtonMouseUp");
            this.AfterInitializeInternal();
        }

        public Button() : this(null)
        {
        }

        static Button()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(ButtonTemplates.Default, dependencyProperties);

            dependencyProperties.Add(DefaultWidthProperty);
            dependencyProperties.Add(IsToggleButtonProperty);
            dependencyProperties.Add(IsDisabledProperty);
            dependencyProperties.Add(ToggleValueProperty);
            dependencyProperties.Add(TextPaddingProperty);
            dependencyProperties.Add(CanToggleOnProperty);
            dependencyProperties.Add(CanToggleOffProperty);
            dependencyProperties.Add(ToggleClickProperty);
            dependencyProperties.Add(IsMouseOverProperty);
            dependencyProperties.Add(IsPressedProperty);
            dependencyProperties.Add(AutoSizeProperty);
            dependencyProperties.Add(TextOffsetProperty);
            dependencyProperties.Add(IsCloseButtonProperty);
            dependencyProperties.Add(IsBackButtonProperty);
            dependencyProperties.Add(DisplayLabelProperty);
            dependencyProperties.Add(LabelProperty);
            dependencyProperties.Add(LabelTemplateProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<Delight.ElementSize> DefaultWidthProperty = new DependencyProperty<Delight.ElementSize>("DefaultWidth");
        /// <summary>Default width of the button when none is specified.</summary>
        public Delight.ElementSize DefaultWidth
        {
            get { return DefaultWidthProperty.GetValue(this); }
            set { DefaultWidthProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> IsToggleButtonProperty = new DependencyProperty<System.Boolean>("IsToggleButton");
        /// <summary>Boolean indicating if the button is a toggle button.</summary>
        public System.Boolean IsToggleButton
        {
            get { return IsToggleButtonProperty.GetValue(this); }
            set { IsToggleButtonProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> IsDisabledProperty = new DependencyProperty<System.Boolean>("IsDisabled");
        /// <summary>Boolean indicating if this button is disabled.</summary>
        public System.Boolean IsDisabled
        {
            get { return IsDisabledProperty.GetValue(this); }
            set { IsDisabledProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> ToggleValueProperty = new DependencyProperty<System.Boolean>("ToggleValue");
        /// <summary>Toggle value of the button.</summary>
        public System.Boolean ToggleValue
        {
            get { return ToggleValueProperty.GetValue(this); }
            set { ToggleValueProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Delight.ElementMargin> TextPaddingProperty = new DependencyProperty<Delight.ElementMargin>("TextPadding");
        /// <summary>Padding applied when the button autosizes to its content.</summary>
        public Delight.ElementMargin TextPadding
        {
            get { return TextPaddingProperty.GetValue(this); }
            set { TextPaddingProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> CanToggleOnProperty = new DependencyProperty<System.Boolean>("CanToggleOn");
        /// <summary>Boolean indicating if the button can be toggled on.</summary>
        public System.Boolean CanToggleOn
        {
            get { return CanToggleOnProperty.GetValue(this); }
            set { CanToggleOnProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> CanToggleOffProperty = new DependencyProperty<System.Boolean>("CanToggleOff");
        /// <summary>Boolean indicating if the button can be toggled off.</summary>
        public System.Boolean CanToggleOff
        {
            get { return CanToggleOffProperty.GetValue(this); }
            set { CanToggleOffProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ViewAction> ToggleClickProperty = new DependencyProperty<ViewAction>("ToggleClick", () => new ViewAction());
        /// <summary>Action called when the button is toggled.</summary>
        public ViewAction ToggleClick
        {
            get { return ToggleClickProperty.GetValue(this); }
            set { ToggleClickProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> IsMouseOverProperty = new DependencyProperty<System.Boolean>("IsMouseOver");
        /// <summary>Boolean indicating if the mouse is over the button.</summary>
        public System.Boolean IsMouseOver
        {
            get { return IsMouseOverProperty.GetValue(this); }
            set { IsMouseOverProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> IsPressedProperty = new DependencyProperty<System.Boolean>("IsPressed");
        /// <summary>Boolean indicating if the button is pressed.</summary>
        public System.Boolean IsPressed
        {
            get { return IsPressedProperty.GetValue(this); }
            set { IsPressedProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Delight.AutoSize> AutoSizeProperty = new DependencyProperty<Delight.AutoSize>("AutoSize");
        /// <summary>Enum indicating if and how the button should automatically resize itself to the size of the text.</summary>
        public Delight.AutoSize AutoSize
        {
            get { return AutoSizeProperty.GetValue(this); }
            set { AutoSizeProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Delight.ElementMargin> TextOffsetProperty = new DependencyProperty<Delight.ElementMargin>("TextOffset");
        /// <summary>The offset of the button text label.</summary>
        public Delight.ElementMargin TextOffset
        {
            get { return TextOffsetProperty.GetValue(this); }
            set { TextOffsetProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> IsCloseButtonProperty = new DependencyProperty<System.Boolean>("IsCloseButton");
        /// <summary>Boolean indicating if this is a close button.</summary>
        public System.Boolean IsCloseButton
        {
            get { return IsCloseButtonProperty.GetValue(this); }
            set { IsCloseButtonProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> IsBackButtonProperty = new DependencyProperty<System.Boolean>("IsBackButton");
        /// <summary>Boolean indicating if this is a back button.</summary>
        public System.Boolean IsBackButton
        {
            get { return IsBackButtonProperty.GetValue(this); }
            set { IsBackButtonProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> DisplayLabelProperty = new DependencyProperty<System.Boolean>("DisplayLabel");
        /// <summary>Boolean indicating if the button label should be displayed.</summary>
        public System.Boolean DisplayLabel
        {
            get { return DisplayLabelProperty.GetValue(this); }
            set { DisplayLabelProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Label> LabelProperty = new DependencyProperty<Label>("Label");
        public Label Label
        {
            get { return LabelProperty.GetValue(this); }
            set { LabelProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> LabelTemplateProperty = new DependencyProperty<Template>("LabelTemplate");
        public Template LabelTemplate
        {
            get { return LabelTemplateProperty.GetValue(this); }
            set { LabelTemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty MaxWidthProperty = Label.MaxWidthProperty;
        public Delight.ElementSize MaxWidth
        {
            get { return Label.MaxWidth; }
            set { Label.MaxWidth = value; }
        }

        public readonly static DependencyProperty LabelAutoSizeProperty = Label.AutoSizeProperty;
        public Delight.AutoSize LabelAutoSize
        {
            get { return Label.AutoSize; }
            set { Label.AutoSize = value; }
        }

        public readonly static DependencyProperty AutoSizeTextContainerProperty = Label.AutoSizeTextContainerProperty;
        public System.Boolean AutoSizeTextContainer
        {
            get { return Label.AutoSizeTextContainer; }
            set { Label.AutoSizeTextContainer = value; }
        }

        public readonly static DependencyProperty MaskOffsetProperty = Label.MaskOffsetProperty;
        public UnityEngine.Vector4 MaskOffset
        {
            get { return Label.MaskOffset; }
            set { Label.MaskOffset = value; }
        }

        public readonly static DependencyProperty TextProperty = Label.TextProperty;
        /// <summary>Button text.</summary>
        public System.String Text
        {
            get { return Label.Text; }
            set { Label.Text = value; }
        }

        public readonly static DependencyProperty IsRightToLeftTextProperty = Label.IsRightToLeftTextProperty;
        public System.Boolean IsRightToLeftText
        {
            get { return Label.IsRightToLeftText; }
            set { Label.IsRightToLeftText = value; }
        }

        public readonly static DependencyProperty FontProperty = Label.FontProperty;
        public TMP_FontAsset Font
        {
            get { return Label.Font; }
            set { Label.Font = value; }
        }

        public readonly static DependencyProperty FontSharedMaterialProperty = Label.FontSharedMaterialProperty;
        public MaterialAsset FontSharedMaterial
        {
            get { return Label.FontSharedMaterial; }
            set { Label.FontSharedMaterial = value; }
        }

        public readonly static DependencyProperty FontSharedMaterialsProperty = Label.FontSharedMaterialsProperty;
        public UnityEngine.Material[] FontSharedMaterials
        {
            get { return Label.FontSharedMaterials; }
            set { Label.FontSharedMaterials = value; }
        }

        public readonly static DependencyProperty FontMaterialProperty = Label.FontMaterialProperty;
        public MaterialAsset FontMaterial
        {
            get { return Label.FontMaterial; }
            set { Label.FontMaterial = value; }
        }

        public readonly static DependencyProperty FontMaterialsProperty = Label.FontMaterialsProperty;
        public UnityEngine.Material[] FontMaterials
        {
            get { return Label.FontMaterials; }
            set { Label.FontMaterials = value; }
        }

        public readonly static DependencyProperty FontColorProperty = Label.FontColorProperty;
        public UnityEngine.Color FontColor
        {
            get { return Label.FontColor; }
            set { Label.FontColor = value; }
        }

        public readonly static DependencyProperty TextMeshProUGUIAlphaProperty = Label.TextMeshProUGUIAlphaProperty;
        public System.Single TextMeshProUGUIAlpha
        {
            get { return Label.TextMeshProUGUIAlpha; }
            set { Label.TextMeshProUGUIAlpha = value; }
        }

        public readonly static DependencyProperty EnableVertexGradientProperty = Label.EnableVertexGradientProperty;
        public System.Boolean EnableVertexGradient
        {
            get { return Label.EnableVertexGradient; }
            set { Label.EnableVertexGradient = value; }
        }

        public readonly static DependencyProperty ColorGradientProperty = Label.ColorGradientProperty;
        public TMPro.VertexGradient ColorGradient
        {
            get { return Label.ColorGradient; }
            set { Label.ColorGradient = value; }
        }

        public readonly static DependencyProperty ColorGradientPresetProperty = Label.ColorGradientPresetProperty;
        public TMP_ColorGradientAsset ColorGradientPreset
        {
            get { return Label.ColorGradientPreset; }
            set { Label.ColorGradientPreset = value; }
        }

        public readonly static DependencyProperty SpriteAssetProperty = Label.SpriteAssetProperty;
        public TMP_SpriteAsset SpriteAsset
        {
            get { return Label.SpriteAsset; }
            set { Label.SpriteAsset = value; }
        }

        public readonly static DependencyProperty TintAllSpritesProperty = Label.TintAllSpritesProperty;
        public System.Boolean TintAllSprites
        {
            get { return Label.TintAllSprites; }
            set { Label.TintAllSprites = value; }
        }

        public readonly static DependencyProperty OverrideColorTagsProperty = Label.OverrideColorTagsProperty;
        public System.Boolean OverrideColorTags
        {
            get { return Label.OverrideColorTags; }
            set { Label.OverrideColorTags = value; }
        }

        public readonly static DependencyProperty FaceColorProperty = Label.FaceColorProperty;
        public UnityEngine.Color32 FaceColor
        {
            get { return Label.FaceColor; }
            set { Label.FaceColor = value; }
        }

        public readonly static DependencyProperty OutlineColorProperty = Label.OutlineColorProperty;
        public UnityEngine.Color32 OutlineColor
        {
            get { return Label.OutlineColor; }
            set { Label.OutlineColor = value; }
        }

        public readonly static DependencyProperty OutlineWidthProperty = Label.OutlineWidthProperty;
        public System.Single OutlineWidth
        {
            get { return Label.OutlineWidth; }
            set { Label.OutlineWidth = value; }
        }

        public readonly static DependencyProperty FontSizeProperty = Label.FontSizeProperty;
        public System.Single FontSize
        {
            get { return Label.FontSize; }
            set { Label.FontSize = value; }
        }

        public readonly static DependencyProperty FontWeightProperty = Label.FontWeightProperty;
        public TMPro.FontWeight FontWeight
        {
            get { return Label.FontWeight; }
            set { Label.FontWeight = value; }
        }

        public readonly static DependencyProperty EnableAutoSizingProperty = Label.EnableAutoSizingProperty;
        public System.Boolean EnableAutoSizing
        {
            get { return Label.EnableAutoSizing; }
            set { Label.EnableAutoSizing = value; }
        }

        public readonly static DependencyProperty FontSizeMinProperty = Label.FontSizeMinProperty;
        public System.Single FontSizeMin
        {
            get { return Label.FontSizeMin; }
            set { Label.FontSizeMin = value; }
        }

        public readonly static DependencyProperty FontSizeMaxProperty = Label.FontSizeMaxProperty;
        public System.Single FontSizeMax
        {
            get { return Label.FontSizeMax; }
            set { Label.FontSizeMax = value; }
        }

        public readonly static DependencyProperty FontStyleProperty = Label.FontStyleProperty;
        public TMPro.FontStyles FontStyle
        {
            get { return Label.FontStyle; }
            set { Label.FontStyle = value; }
        }

        public readonly static DependencyProperty TextAlignmentProperty = Label.TextAlignmentProperty;
        public TMPro.TextAlignmentOptions TextAlignment
        {
            get { return Label.TextAlignment; }
            set { Label.TextAlignment = value; }
        }

        public readonly static DependencyProperty CharacterSpacingProperty = Label.CharacterSpacingProperty;
        public System.Single CharacterSpacing
        {
            get { return Label.CharacterSpacing; }
            set { Label.CharacterSpacing = value; }
        }

        public readonly static DependencyProperty WordSpacingProperty = Label.WordSpacingProperty;
        public System.Single WordSpacing
        {
            get { return Label.WordSpacing; }
            set { Label.WordSpacing = value; }
        }

        public readonly static DependencyProperty LineSpacingProperty = Label.LineSpacingProperty;
        public System.Single LineSpacing
        {
            get { return Label.LineSpacing; }
            set { Label.LineSpacing = value; }
        }

        public readonly static DependencyProperty LineSpacingAdjustmentProperty = Label.LineSpacingAdjustmentProperty;
        public System.Single LineSpacingAdjustment
        {
            get { return Label.LineSpacingAdjustment; }
            set { Label.LineSpacingAdjustment = value; }
        }

        public readonly static DependencyProperty ParagraphSpacingProperty = Label.ParagraphSpacingProperty;
        public System.Single ParagraphSpacing
        {
            get { return Label.ParagraphSpacing; }
            set { Label.ParagraphSpacing = value; }
        }

        public readonly static DependencyProperty CharacterWidthAdjustmentProperty = Label.CharacterWidthAdjustmentProperty;
        public System.Single CharacterWidthAdjustment
        {
            get { return Label.CharacterWidthAdjustment; }
            set { Label.CharacterWidthAdjustment = value; }
        }

        public readonly static DependencyProperty EnableWordWrappingProperty = Label.EnableWordWrappingProperty;
        public System.Boolean EnableWordWrapping
        {
            get { return Label.EnableWordWrapping; }
            set { Label.EnableWordWrapping = value; }
        }

        public readonly static DependencyProperty WordWrappingRatiosProperty = Label.WordWrappingRatiosProperty;
        public System.Single WordWrappingRatios
        {
            get { return Label.WordWrappingRatios; }
            set { Label.WordWrappingRatios = value; }
        }

        public readonly static DependencyProperty OverflowModeProperty = Label.OverflowModeProperty;
        public TMPro.TextOverflowModes OverflowMode
        {
            get { return Label.OverflowMode; }
            set { Label.OverflowMode = value; }
        }

        public readonly static DependencyProperty LinkedTextComponentProperty = Label.LinkedTextComponentProperty;
        public TMPro.TMP_Text LinkedTextComponent
        {
            get { return Label.LinkedTextComponent; }
            set { Label.LinkedTextComponent = value; }
        }

        public readonly static DependencyProperty IsLinkedTextComponentProperty = Label.IsLinkedTextComponentProperty;
        public System.Boolean IsLinkedTextComponent
        {
            get { return Label.IsLinkedTextComponent; }
            set { Label.IsLinkedTextComponent = value; }
        }

        public readonly static DependencyProperty EnableKerningProperty = Label.EnableKerningProperty;
        public System.Boolean EnableKerning
        {
            get { return Label.EnableKerning; }
            set { Label.EnableKerning = value; }
        }

        public readonly static DependencyProperty ExtraPaddingProperty = Label.ExtraPaddingProperty;
        public System.Boolean ExtraPadding
        {
            get { return Label.ExtraPadding; }
            set { Label.ExtraPadding = value; }
        }

        public readonly static DependencyProperty RichTextProperty = Label.RichTextProperty;
        public System.Boolean RichText
        {
            get { return Label.RichText; }
            set { Label.RichText = value; }
        }

        public readonly static DependencyProperty ParseCtrlCharactersProperty = Label.ParseCtrlCharactersProperty;
        public System.Boolean ParseCtrlCharacters
        {
            get { return Label.ParseCtrlCharacters; }
            set { Label.ParseCtrlCharacters = value; }
        }

        public readonly static DependencyProperty IsOverlayProperty = Label.IsOverlayProperty;
        public System.Boolean IsOverlay
        {
            get { return Label.IsOverlay; }
            set { Label.IsOverlay = value; }
        }

        public readonly static DependencyProperty IsOrthographicProperty = Label.IsOrthographicProperty;
        public System.Boolean IsOrthographic
        {
            get { return Label.IsOrthographic; }
            set { Label.IsOrthographic = value; }
        }

        public readonly static DependencyProperty EnableCullingProperty = Label.EnableCullingProperty;
        public System.Boolean EnableCulling
        {
            get { return Label.EnableCulling; }
            set { Label.EnableCulling = value; }
        }

        public readonly static DependencyProperty IgnoreRectMaskCullingProperty = Label.IgnoreRectMaskCullingProperty;
        public System.Boolean IgnoreRectMaskCulling
        {
            get { return Label.IgnoreRectMaskCulling; }
            set { Label.IgnoreRectMaskCulling = value; }
        }

        public readonly static DependencyProperty IgnoreVisibilityProperty = Label.IgnoreVisibilityProperty;
        public System.Boolean IgnoreVisibility
        {
            get { return Label.IgnoreVisibility; }
            set { Label.IgnoreVisibility = value; }
        }

        public readonly static DependencyProperty HorizontalMappingProperty = Label.HorizontalMappingProperty;
        public TMPro.TextureMappingOptions HorizontalMapping
        {
            get { return Label.HorizontalMapping; }
            set { Label.HorizontalMapping = value; }
        }

        public readonly static DependencyProperty VerticalMappingProperty = Label.VerticalMappingProperty;
        public TMPro.TextureMappingOptions VerticalMapping
        {
            get { return Label.VerticalMapping; }
            set { Label.VerticalMapping = value; }
        }

        public readonly static DependencyProperty MappingUvLineOffsetProperty = Label.MappingUvLineOffsetProperty;
        public System.Single MappingUvLineOffset
        {
            get { return Label.MappingUvLineOffset; }
            set { Label.MappingUvLineOffset = value; }
        }

        public readonly static DependencyProperty RenderModeProperty = Label.RenderModeProperty;
        public TMPro.TextRenderFlags RenderMode
        {
            get { return Label.RenderMode; }
            set { Label.RenderMode = value; }
        }

        public readonly static DependencyProperty GeometrySortingOrderProperty = Label.GeometrySortingOrderProperty;
        public TMPro.VertexSortingOrder GeometrySortingOrder
        {
            get { return Label.GeometrySortingOrder; }
            set { Label.GeometrySortingOrder = value; }
        }

        public readonly static DependencyProperty VertexBufferAutoSizeReductionProperty = Label.VertexBufferAutoSizeReductionProperty;
        public System.Boolean VertexBufferAutoSizeReduction
        {
            get { return Label.VertexBufferAutoSizeReduction; }
            set { Label.VertexBufferAutoSizeReduction = value; }
        }

        public readonly static DependencyProperty FirstVisibleCharacterProperty = Label.FirstVisibleCharacterProperty;
        public System.Int32 FirstVisibleCharacter
        {
            get { return Label.FirstVisibleCharacter; }
            set { Label.FirstVisibleCharacter = value; }
        }

        public readonly static DependencyProperty MaxVisibleCharactersProperty = Label.MaxVisibleCharactersProperty;
        public System.Int32 MaxVisibleCharacters
        {
            get { return Label.MaxVisibleCharacters; }
            set { Label.MaxVisibleCharacters = value; }
        }

        public readonly static DependencyProperty MaxVisibleWordsProperty = Label.MaxVisibleWordsProperty;
        public System.Int32 MaxVisibleWords
        {
            get { return Label.MaxVisibleWords; }
            set { Label.MaxVisibleWords = value; }
        }

        public readonly static DependencyProperty MaxVisibleLinesProperty = Label.MaxVisibleLinesProperty;
        public System.Int32 MaxVisibleLines
        {
            get { return Label.MaxVisibleLines; }
            set { Label.MaxVisibleLines = value; }
        }

        public readonly static DependencyProperty UseMaxVisibleDescenderProperty = Label.UseMaxVisibleDescenderProperty;
        public System.Boolean UseMaxVisibleDescender
        {
            get { return Label.UseMaxVisibleDescender; }
            set { Label.UseMaxVisibleDescender = value; }
        }

        public readonly static DependencyProperty PageToDisplayProperty = Label.PageToDisplayProperty;
        public System.Int32 PageToDisplay
        {
            get { return Label.PageToDisplay; }
            set { Label.PageToDisplay = value; }
        }

        public readonly static DependencyProperty TextMarginProperty = Label.TextMarginProperty;
        public UnityEngine.Vector4 TextMargin
        {
            get { return Label.TextMargin; }
            set { Label.TextMargin = value; }
        }

        public readonly static DependencyProperty HavePropertiesChangedProperty = Label.HavePropertiesChangedProperty;
        public System.Boolean HavePropertiesChanged
        {
            get { return Label.HavePropertiesChanged; }
            set { Label.HavePropertiesChanged = value; }
        }

        public readonly static DependencyProperty IsUsingLegacyAnimationComponentProperty = Label.IsUsingLegacyAnimationComponentProperty;
        public System.Boolean IsUsingLegacyAnimationComponent
        {
            get { return Label.IsUsingLegacyAnimationComponent; }
            set { Label.IsUsingLegacyAnimationComponent = value; }
        }

        public readonly static DependencyProperty IsVolumetricTextProperty = Label.IsVolumetricTextProperty;
        public System.Boolean IsVolumetricText
        {
            get { return Label.IsVolumetricText; }
            set { Label.IsVolumetricText = value; }
        }

        public readonly static DependencyProperty OnCullStateChangedProperty = Label.OnCullStateChangedProperty;
        public UnityEngine.UI.MaskableGraphic.CullStateChangedEvent OnCullStateChanged
        {
            get { return Label.OnCullStateChanged; }
            set { Label.OnCullStateChanged = value; }
        }

        public readonly static DependencyProperty MaskableProperty = Label.MaskableProperty;
        public System.Boolean Maskable
        {
            get { return Label.Maskable; }
            set { Label.Maskable = value; }
        }

        public readonly static DependencyProperty IsMaskingGraphicProperty = Label.IsMaskingGraphicProperty;
        public System.Boolean IsMaskingGraphic
        {
            get { return Label.IsMaskingGraphic; }
            set { Label.IsMaskingGraphic = value; }
        }

        public readonly static DependencyProperty RaycastTargetProperty = Label.RaycastTargetProperty;
        public System.Boolean RaycastTarget
        {
            get { return Label.RaycastTarget; }
            set { Label.RaycastTarget = value; }
        }

        public readonly static DependencyProperty MaterialProperty = Label.MaterialProperty;
        public MaterialAsset Material
        {
            get { return Label.Material; }
            set { Label.Material = value; }
        }

        public readonly static DependencyProperty LabelWidthProperty = Label.WidthProperty;
        public Delight.ElementSize LabelWidth
        {
            get { return Label.Width; }
            set { Label.Width = value; }
        }

        public readonly static DependencyProperty LabelHeightProperty = Label.HeightProperty;
        public Delight.ElementSize LabelHeight
        {
            get { return Label.Height; }
            set { Label.Height = value; }
        }

        public readonly static DependencyProperty LabelOverrideWidthProperty = Label.OverrideWidthProperty;
        public Delight.ElementSize LabelOverrideWidth
        {
            get { return Label.OverrideWidth; }
            set { Label.OverrideWidth = value; }
        }

        public readonly static DependencyProperty LabelOverrideHeightProperty = Label.OverrideHeightProperty;
        public Delight.ElementSize LabelOverrideHeight
        {
            get { return Label.OverrideHeight; }
            set { Label.OverrideHeight = value; }
        }

        public readonly static DependencyProperty LabelScaleProperty = Label.ScaleProperty;
        public UnityEngine.Vector3 LabelScale
        {
            get { return Label.Scale; }
            set { Label.Scale = value; }
        }

        public readonly static DependencyProperty LabelAlignmentProperty = Label.AlignmentProperty;
        public Delight.ElementAlignment LabelAlignment
        {
            get { return Label.Alignment; }
            set { Label.Alignment = value; }
        }

        public readonly static DependencyProperty LabelMarginProperty = Label.MarginProperty;
        public Delight.ElementMargin LabelMargin
        {
            get { return Label.Margin; }
            set { Label.Margin = value; }
        }

        public readonly static DependencyProperty LabelOffsetProperty = Label.OffsetProperty;
        public Delight.ElementMargin LabelOffset
        {
            get { return Label.Offset; }
            set { Label.Offset = value; }
        }

        public readonly static DependencyProperty LabelOffsetFromParentProperty = Label.OffsetFromParentProperty;
        public Delight.ElementMargin LabelOffsetFromParent
        {
            get { return Label.OffsetFromParent; }
            set { Label.OffsetFromParent = value; }
        }

        public readonly static DependencyProperty LabelPivotProperty = Label.PivotProperty;
        public UnityEngine.Vector2 LabelPivot
        {
            get { return Label.Pivot; }
            set { Label.Pivot = value; }
        }

        public readonly static DependencyProperty LabelDisableLayoutUpdateProperty = Label.DisableLayoutUpdateProperty;
        public System.Boolean LabelDisableLayoutUpdate
        {
            get { return Label.DisableLayoutUpdate; }
            set { Label.DisableLayoutUpdate = value; }
        }

        public readonly static DependencyProperty LabelAlphaProperty = Label.AlphaProperty;
        public System.Single LabelAlpha
        {
            get { return Label.Alpha; }
            set { Label.Alpha = value; }
        }

        public readonly static DependencyProperty LabelIsVisibleProperty = Label.IsVisibleProperty;
        public System.Boolean LabelIsVisible
        {
            get { return Label.IsVisible; }
            set { Label.IsVisible = value; }
        }

        public readonly static DependencyProperty LabelRaycastBlockModeProperty = Label.RaycastBlockModeProperty;
        public Delight.RaycastBlockMode LabelRaycastBlockMode
        {
            get { return Label.RaycastBlockMode; }
            set { Label.RaycastBlockMode = value; }
        }

        public readonly static DependencyProperty LabelUseFastShaderProperty = Label.UseFastShaderProperty;
        public System.Boolean LabelUseFastShader
        {
            get { return Label.UseFastShader; }
            set { Label.UseFastShader = value; }
        }

        public readonly static DependencyProperty LabelBubbleNotifyChildLayoutChangedProperty = Label.BubbleNotifyChildLayoutChangedProperty;
        public System.Boolean LabelBubbleNotifyChildLayoutChanged
        {
            get { return Label.BubbleNotifyChildLayoutChanged; }
            set { Label.BubbleNotifyChildLayoutChanged = value; }
        }

        public readonly static DependencyProperty LabelIgnoreFlipProperty = Label.IgnoreFlipProperty;
        public System.Boolean LabelIgnoreFlip
        {
            get { return Label.IgnoreFlip; }
            set { Label.IgnoreFlip = value; }
        }

        public readonly static DependencyProperty LabelRotationProperty = Label.RotationProperty;
        public UnityEngine.Quaternion LabelRotation
        {
            get { return Label.Rotation; }
            set { Label.Rotation = value; }
        }

        public readonly static DependencyProperty LabelPositionProperty = Label.PositionProperty;
        public UnityEngine.Vector3 LabelPosition
        {
            get { return Label.Position; }
            set { Label.Position = value; }
        }

        public readonly static DependencyProperty LabelGameObjectProperty = Label.GameObjectProperty;
        public UnityEngine.GameObject LabelGameObject
        {
            get { return Label.GameObject; }
            set { Label.GameObject = value; }
        }

        public readonly static DependencyProperty LabelEnableScriptEventsProperty = Label.EnableScriptEventsProperty;
        public System.Boolean LabelEnableScriptEvents
        {
            get { return Label.EnableScriptEvents; }
            set { Label.EnableScriptEvents = value; }
        }

        public readonly static DependencyProperty LabelIgnoreObjectProperty = Label.IgnoreObjectProperty;
        public System.Boolean LabelIgnoreObject
        {
            get { return Label.IgnoreObject; }
            set { Label.IgnoreObject = value; }
        }

        public readonly static DependencyProperty LabelIsActiveProperty = Label.IsActiveProperty;
        public System.Boolean LabelIsActive
        {
            get { return Label.IsActive; }
            set { Label.IsActive = value; }
        }

        public readonly static DependencyProperty LabelLoadModeProperty = Label.LoadModeProperty;
        public Delight.LoadMode LabelLoadMode
        {
            get { return Label.LoadMode; }
            set { Label.LoadMode = value; }
        }

        #endregion
    }

    #region Data Templates

    public static class ButtonTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return Button;
            }
        }

        private static Template _button;
        public static Template Button
        {
            get
            {
#if UNITY_EDITOR
                if (_button == null || _button.CurrentVersion != Template.Version)
#else
                if (_button == null)
#endif
                {
                    _button = new Template(UIImageViewTemplates.UIImageView);
#if UNITY_EDITOR
                    _button.Name = "Button";
                    _button.LineNumber = 0;
                    _button.LinePosition = 0;
#endif
                    Delight.Button.HeightProperty.SetDefault(_button, new ElementSize(40f, ElementSizeUnit.Pixels));
                    Delight.Button.DefaultWidthProperty.SetDefault(_button, new ElementSize(160f, ElementSizeUnit.Pixels));
                    Delight.Button.TextPaddingProperty.SetDefault(_button, new ElementMargin(new ElementSize(20f, ElementSizeUnit.Pixels), new ElementSize(10f, ElementSizeUnit.Pixels), new ElementSize(20f, ElementSizeUnit.Pixels), new ElementSize(10f, ElementSizeUnit.Pixels)));
                    Delight.Button.CanToggleOnProperty.SetDefault(_button, true);
                    Delight.Button.CanToggleOffProperty.SetDefault(_button, true);
                    Delight.Button.TextOffsetProperty.SetDefault(_button, new ElementMargin(new ElementSize(0f, ElementSizeUnit.Pixels)));
                    Delight.Button.EnableScriptEventsProperty.SetDefault(_button, true);
                    Delight.Button.DisplayLabelProperty.SetDefault(_button, true);
                    Delight.Button.BackgroundColorProperty.SetDefault(_button, new UnityEngine.Color(0.4901961f, 0.4901961f, 0.4901961f, 1f));
                    Delight.Button.BackgroundColorProperty.SetStateDefault("Highlighted", _button, new UnityEngine.Color(0.8980392f, 0.8980392f, 0.8980392f, 1f));
                    Delight.Button.BackgroundColorProperty.SetStateDefault("Pressed", _button, new UnityEngine.Color(0.9372549f, 0.4392157f, 0.4156863f, 1f));
                    Delight.Button.HeightProperty.SetDefault(_button, new ElementSize(30f, ElementSizeUnit.Pixels));
                    Delight.Button.BackgroundColorProperty.SetStateDefault("Disabled", _button, new UnityEngine.Color(0.4901961f, 0.4901961f, 0.4901961f, 1f));
                    Delight.Button.LabelTemplateProperty.SetDefault(_button, ButtonLabel);
                }
                return _button;
            }
        }

        private static Template _buttonLabel;
        public static Template ButtonLabel
        {
            get
            {
#if UNITY_EDITOR
                if (_buttonLabel == null || _buttonLabel.CurrentVersion != Template.Version)
#else
                if (_buttonLabel == null)
#endif
                {
                    _buttonLabel = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _buttonLabel.Name = "ButtonLabel";
                    _buttonLabel.LineNumber = 15;
                    _buttonLabel.LinePosition = 4;
#endif
                    Delight.Label.TextAlignmentProperty.SetDefault(_buttonLabel, TMPro.TextAlignmentOptions.Center);
                    Delight.Label.WidthProperty.SetDefault(_buttonLabel, new ElementSize(1f, ElementSizeUnit.Percents));
                    Delight.Label.HeightProperty.SetDefault(_buttonLabel, new ElementSize(1f, ElementSizeUnit.Percents));
                    Delight.Label.FontColorProperty.SetDefault(_buttonLabel, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Label.FontStyleProperty.SetDefault(_buttonLabel, TMPro.FontStyles.Normal);
                    Delight.Label.FontColorProperty.SetStateDefault("Highlighted", _buttonLabel, new UnityEngine.Color(0f, 0f, 0f, 1f));
                    Delight.Label.FontColorProperty.SetStateDefault("Pressed", _buttonLabel, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Label.FontSizeProperty.SetDefault(_buttonLabel, 16f);
                    Delight.Label.FontStyleProperty.SetStateDefault("Disabled", _buttonLabel, TMPro.FontStyles.Italic);
                    Delight.Label.FontColorProperty.SetStateDefault("Disabled", _buttonLabel, new UnityEngine.Color(0.8f, 0.8f, 0.8f, 1f));
                    Delight.Label.OffsetProperty.SetHasBinding(_buttonLabel);
                    Delight.Label.IsActiveProperty.SetHasBinding(_buttonLabel);
                }
                return _buttonLabel;
            }
        }

        #endregion
    }

    #endregion
}
