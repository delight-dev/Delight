#if DELIGHT_MODULE_TEXTMESHPRO

// Internal view logic generated from "Label.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class Label : UIView
    {
        #region Constructors

        public Label(View parent, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :
            base(parent, layoutParent, id, template ?? LabelTemplates.Default, initializer)
        {
            this.AfterInitializeInternal();
        }

        public Label() : this(null)
        {
        }

        static Label()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(LabelTemplates.Default, dependencyProperties);

            dependencyProperties.Add(TextMeshProUGUIProperty);
            dependencyProperties.Add(AutoSizeProperty);
            dependencyProperties.Add(AutoSizeTextContainerProperty);
            dependencyProperties.Add(MaskOffsetProperty);
            dependencyProperties.Add(TextProperty);
            dependencyProperties.Add(IsRightToLeftTextProperty);
            dependencyProperties.Add(FontProperty);
            dependencyProperties.Add(FontSharedMaterialProperty);
            dependencyProperties.Add(FontSharedMaterialsProperty);
            dependencyProperties.Add(FontMaterialProperty);
            dependencyProperties.Add(FontMaterialsProperty);
            dependencyProperties.Add(FontColorProperty);
            dependencyProperties.Add(TextMeshProUGUIAlphaProperty);
            dependencyProperties.Add(EnableVertexGradientProperty);
            dependencyProperties.Add(ColorGradientProperty);
            dependencyProperties.Add(ColorGradientPresetProperty);
            dependencyProperties.Add(SpriteAssetProperty);
            dependencyProperties.Add(TintAllSpritesProperty);
            dependencyProperties.Add(OverrideColorTagsProperty);
            dependencyProperties.Add(FaceColorProperty);
            dependencyProperties.Add(OutlineColorProperty);
            dependencyProperties.Add(OutlineWidthProperty);
            dependencyProperties.Add(FontSizeProperty);
            dependencyProperties.Add(FontWeightProperty);
            dependencyProperties.Add(EnableAutoSizingProperty);
            dependencyProperties.Add(FontSizeMinProperty);
            dependencyProperties.Add(FontSizeMaxProperty);
            dependencyProperties.Add(FontStyleProperty);
            dependencyProperties.Add(TextAlignmentProperty);
            dependencyProperties.Add(CharacterSpacingProperty);
            dependencyProperties.Add(WordSpacingProperty);
            dependencyProperties.Add(LineSpacingProperty);
            dependencyProperties.Add(LineSpacingAdjustmentProperty);
            dependencyProperties.Add(ParagraphSpacingProperty);
            dependencyProperties.Add(CharacterWidthAdjustmentProperty);
            dependencyProperties.Add(EnableWordWrappingProperty);
            dependencyProperties.Add(WordWrappingRatiosProperty);
            dependencyProperties.Add(OverflowModeProperty);
            dependencyProperties.Add(LinkedTextComponentProperty);
            dependencyProperties.Add(IsLinkedTextComponentProperty);
            dependencyProperties.Add(EnableKerningProperty);
            dependencyProperties.Add(ExtraPaddingProperty);
            dependencyProperties.Add(RichTextProperty);
            dependencyProperties.Add(ParseCtrlCharactersProperty);
            dependencyProperties.Add(IsOverlayProperty);
            dependencyProperties.Add(IsOrthographicProperty);
            dependencyProperties.Add(EnableCullingProperty);
            dependencyProperties.Add(IgnoreRectMaskCullingProperty);
            dependencyProperties.Add(IgnoreVisibilityProperty);
            dependencyProperties.Add(HorizontalMappingProperty);
            dependencyProperties.Add(VerticalMappingProperty);
            dependencyProperties.Add(MappingUvLineOffsetProperty);
            dependencyProperties.Add(RenderModeProperty);
            dependencyProperties.Add(GeometrySortingOrderProperty);
            dependencyProperties.Add(VertexBufferAutoSizeReductionProperty);
            dependencyProperties.Add(FirstVisibleCharacterProperty);
            dependencyProperties.Add(MaxVisibleCharactersProperty);
            dependencyProperties.Add(MaxVisibleWordsProperty);
            dependencyProperties.Add(MaxVisibleLinesProperty);
            dependencyProperties.Add(UseMaxVisibleDescenderProperty);
            dependencyProperties.Add(PageToDisplayProperty);
            dependencyProperties.Add(TextMarginProperty);
            dependencyProperties.Add(HavePropertiesChangedProperty);
            dependencyProperties.Add(IsUsingLegacyAnimationComponentProperty);
            dependencyProperties.Add(IsVolumetricTextProperty);
            dependencyProperties.Add(OnCullStateChangedProperty);
            dependencyProperties.Add(MaskableProperty);
            dependencyProperties.Add(RaycastTargetProperty);
            dependencyProperties.Add(MaterialProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<TMPro.TextMeshProUGUI> TextMeshProUGUIProperty = new DependencyProperty<TMPro.TextMeshProUGUI>("TextMeshProUGUI");
        public TMPro.TextMeshProUGUI TextMeshProUGUI
        {
            get { return TextMeshProUGUIProperty.GetValue(this); }
            set { TextMeshProUGUIProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Delight.AutoSize> AutoSizeProperty = new DependencyProperty<Delight.AutoSize>("AutoSize");
        public Delight.AutoSize AutoSize
        {
            get { return AutoSizeProperty.GetValue(this); }
            set { AutoSizeProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Boolean, TMPro.TextMeshProUGUI, Label> AutoSizeTextContainerProperty = new MappedDependencyProperty<System.Boolean, TMPro.TextMeshProUGUI, Label>("AutoSizeTextContainer", x => x.TextMeshProUGUI, x => x.autoSizeTextContainer, (x, y) => x.autoSizeTextContainer = y);
        public System.Boolean AutoSizeTextContainer
        {
            get { return AutoSizeTextContainerProperty.GetValue(this); }
            set { AutoSizeTextContainerProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<UnityEngine.Vector4, TMPro.TextMeshProUGUI, Label> MaskOffsetProperty = new MappedDependencyProperty<UnityEngine.Vector4, TMPro.TextMeshProUGUI, Label>("MaskOffset", x => x.TextMeshProUGUI, x => x.maskOffset, (x, y) => x.maskOffset = y);
        public UnityEngine.Vector4 MaskOffset
        {
            get { return MaskOffsetProperty.GetValue(this); }
            set { MaskOffsetProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.String, TMPro.TextMeshProUGUI, Label> TextProperty = new MappedDependencyProperty<System.String, TMPro.TextMeshProUGUI, Label>("Text", x => x.TextMeshProUGUI, x => x.text, (x, y) => x.text = y);
        public System.String Text
        {
            get { return TextProperty.GetValue(this); }
            set { TextProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Boolean, TMPro.TextMeshProUGUI, Label> IsRightToLeftTextProperty = new MappedDependencyProperty<System.Boolean, TMPro.TextMeshProUGUI, Label>("IsRightToLeftText", x => x.TextMeshProUGUI, x => x.isRightToLeftText, (x, y) => x.isRightToLeftText = y);
        public System.Boolean IsRightToLeftText
        {
            get { return IsRightToLeftTextProperty.GetValue(this); }
            set { IsRightToLeftTextProperty.SetValue(this, value); }
        }

        public readonly static MappedAssetDependencyProperty<TMP_FontAsset, TMPro.TextMeshProUGUI, Label> FontProperty = new MappedAssetDependencyProperty<TMP_FontAsset, TMPro.TextMeshProUGUI, Label>("Font", x => x.TextMeshProUGUI, (x, y) => x.font = y?.UnityObject);
        public TMP_FontAsset Font
        {
            get { return FontProperty.GetValue(this); }
            set { FontProperty.SetValue(this, value); }
        }

        public readonly static MappedAssetDependencyProperty<MaterialAsset, TMPro.TextMeshProUGUI, Label> FontSharedMaterialProperty = new MappedAssetDependencyProperty<MaterialAsset, TMPro.TextMeshProUGUI, Label>("FontSharedMaterial", x => x.TextMeshProUGUI, (x, y) => x.fontSharedMaterial = y?.UnityObject);
        public MaterialAsset FontSharedMaterial
        {
            get { return FontSharedMaterialProperty.GetValue(this); }
            set { FontSharedMaterialProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<UnityEngine.Material[], TMPro.TextMeshProUGUI, Label> FontSharedMaterialsProperty = new MappedDependencyProperty<UnityEngine.Material[], TMPro.TextMeshProUGUI, Label>("FontSharedMaterials", x => x.TextMeshProUGUI, x => x.fontSharedMaterials, (x, y) => x.fontSharedMaterials = y);
        public UnityEngine.Material[] FontSharedMaterials
        {
            get { return FontSharedMaterialsProperty.GetValue(this); }
            set { FontSharedMaterialsProperty.SetValue(this, value); }
        }

        public readonly static MappedAssetDependencyProperty<MaterialAsset, TMPro.TextMeshProUGUI, Label> FontMaterialProperty = new MappedAssetDependencyProperty<MaterialAsset, TMPro.TextMeshProUGUI, Label>("FontMaterial", x => x.TextMeshProUGUI, (x, y) => x.fontMaterial = y?.UnityObject);
        public MaterialAsset FontMaterial
        {
            get { return FontMaterialProperty.GetValue(this); }
            set { FontMaterialProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<UnityEngine.Material[], TMPro.TextMeshProUGUI, Label> FontMaterialsProperty = new MappedDependencyProperty<UnityEngine.Material[], TMPro.TextMeshProUGUI, Label>("FontMaterials", x => x.TextMeshProUGUI, x => x.fontMaterials, (x, y) => x.fontMaterials = y);
        public UnityEngine.Material[] FontMaterials
        {
            get { return FontMaterialsProperty.GetValue(this); }
            set { FontMaterialsProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<UnityEngine.Color, TMPro.TextMeshProUGUI, Label> FontColorProperty = new MappedDependencyProperty<UnityEngine.Color, TMPro.TextMeshProUGUI, Label>("FontColor", x => x.TextMeshProUGUI, x => x.color, (x, y) => x.color = y);
        public UnityEngine.Color FontColor
        {
            get { return FontColorProperty.GetValue(this); }
            set { FontColorProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Single, TMPro.TextMeshProUGUI, Label> TextMeshProUGUIAlphaProperty = new MappedDependencyProperty<System.Single, TMPro.TextMeshProUGUI, Label>("TextMeshProUGUIAlpha", x => x.TextMeshProUGUI, x => x.alpha, (x, y) => x.alpha = y);
        public System.Single TextMeshProUGUIAlpha
        {
            get { return TextMeshProUGUIAlphaProperty.GetValue(this); }
            set { TextMeshProUGUIAlphaProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Boolean, TMPro.TextMeshProUGUI, Label> EnableVertexGradientProperty = new MappedDependencyProperty<System.Boolean, TMPro.TextMeshProUGUI, Label>("EnableVertexGradient", x => x.TextMeshProUGUI, x => x.enableVertexGradient, (x, y) => x.enableVertexGradient = y);
        public System.Boolean EnableVertexGradient
        {
            get { return EnableVertexGradientProperty.GetValue(this); }
            set { EnableVertexGradientProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<TMPro.VertexGradient, TMPro.TextMeshProUGUI, Label> ColorGradientProperty = new MappedDependencyProperty<TMPro.VertexGradient, TMPro.TextMeshProUGUI, Label>("ColorGradient", x => x.TextMeshProUGUI, x => x.colorGradient, (x, y) => x.colorGradient = y);
        public TMPro.VertexGradient ColorGradient
        {
            get { return ColorGradientProperty.GetValue(this); }
            set { ColorGradientProperty.SetValue(this, value); }
        }

        public readonly static MappedAssetDependencyProperty<TMP_ColorGradientAsset, TMPro.TextMeshProUGUI, Label> ColorGradientPresetProperty = new MappedAssetDependencyProperty<TMP_ColorGradientAsset, TMPro.TextMeshProUGUI, Label>("ColorGradientPreset", x => x.TextMeshProUGUI, (x, y) => x.colorGradientPreset = y?.UnityObject);
        public TMP_ColorGradientAsset ColorGradientPreset
        {
            get { return ColorGradientPresetProperty.GetValue(this); }
            set { ColorGradientPresetProperty.SetValue(this, value); }
        }

        public readonly static MappedAssetDependencyProperty<TMP_SpriteAsset, TMPro.TextMeshProUGUI, Label> SpriteAssetProperty = new MappedAssetDependencyProperty<TMP_SpriteAsset, TMPro.TextMeshProUGUI, Label>("SpriteAsset", x => x.TextMeshProUGUI, (x, y) => x.spriteAsset = y?.UnityObject);
        public TMP_SpriteAsset SpriteAsset
        {
            get { return SpriteAssetProperty.GetValue(this); }
            set { SpriteAssetProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Boolean, TMPro.TextMeshProUGUI, Label> TintAllSpritesProperty = new MappedDependencyProperty<System.Boolean, TMPro.TextMeshProUGUI, Label>("TintAllSprites", x => x.TextMeshProUGUI, x => x.tintAllSprites, (x, y) => x.tintAllSprites = y);
        public System.Boolean TintAllSprites
        {
            get { return TintAllSpritesProperty.GetValue(this); }
            set { TintAllSpritesProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Boolean, TMPro.TextMeshProUGUI, Label> OverrideColorTagsProperty = new MappedDependencyProperty<System.Boolean, TMPro.TextMeshProUGUI, Label>("OverrideColorTags", x => x.TextMeshProUGUI, x => x.overrideColorTags, (x, y) => x.overrideColorTags = y);
        public System.Boolean OverrideColorTags
        {
            get { return OverrideColorTagsProperty.GetValue(this); }
            set { OverrideColorTagsProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<UnityEngine.Color32, TMPro.TextMeshProUGUI, Label> FaceColorProperty = new MappedDependencyProperty<UnityEngine.Color32, TMPro.TextMeshProUGUI, Label>("FaceColor", x => x.TextMeshProUGUI, x => x.faceColor, (x, y) => x.faceColor = y);
        public UnityEngine.Color32 FaceColor
        {
            get { return FaceColorProperty.GetValue(this); }
            set { FaceColorProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<UnityEngine.Color32, TMPro.TextMeshProUGUI, Label> OutlineColorProperty = new MappedDependencyProperty<UnityEngine.Color32, TMPro.TextMeshProUGUI, Label>("OutlineColor", x => x.TextMeshProUGUI, x => x.outlineColor, (x, y) => x.outlineColor = y);
        public UnityEngine.Color32 OutlineColor
        {
            get { return OutlineColorProperty.GetValue(this); }
            set { OutlineColorProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Single, TMPro.TextMeshProUGUI, Label> OutlineWidthProperty = new MappedDependencyProperty<System.Single, TMPro.TextMeshProUGUI, Label>("OutlineWidth", x => x.TextMeshProUGUI, x => x.outlineWidth, (x, y) => x.outlineWidth = y);
        public System.Single OutlineWidth
        {
            get { return OutlineWidthProperty.GetValue(this); }
            set { OutlineWidthProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Single, TMPro.TextMeshProUGUI, Label> FontSizeProperty = new MappedDependencyProperty<System.Single, TMPro.TextMeshProUGUI, Label>("FontSize", x => x.TextMeshProUGUI, x => x.fontSize, (x, y) => x.fontSize = y);
        public System.Single FontSize
        {
            get { return FontSizeProperty.GetValue(this); }
            set { FontSizeProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<TMPro.FontWeight, TMPro.TextMeshProUGUI, Label> FontWeightProperty = new MappedDependencyProperty<TMPro.FontWeight, TMPro.TextMeshProUGUI, Label>("FontWeight", x => x.TextMeshProUGUI, x => x.fontWeight, (x, y) => x.fontWeight = y);
        public TMPro.FontWeight FontWeight
        {
            get { return FontWeightProperty.GetValue(this); }
            set { FontWeightProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Boolean, TMPro.TextMeshProUGUI, Label> EnableAutoSizingProperty = new MappedDependencyProperty<System.Boolean, TMPro.TextMeshProUGUI, Label>("EnableAutoSizing", x => x.TextMeshProUGUI, x => x.enableAutoSizing, (x, y) => x.enableAutoSizing = y);
        public System.Boolean EnableAutoSizing
        {
            get { return EnableAutoSizingProperty.GetValue(this); }
            set { EnableAutoSizingProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Single, TMPro.TextMeshProUGUI, Label> FontSizeMinProperty = new MappedDependencyProperty<System.Single, TMPro.TextMeshProUGUI, Label>("FontSizeMin", x => x.TextMeshProUGUI, x => x.fontSizeMin, (x, y) => x.fontSizeMin = y);
        public System.Single FontSizeMin
        {
            get { return FontSizeMinProperty.GetValue(this); }
            set { FontSizeMinProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Single, TMPro.TextMeshProUGUI, Label> FontSizeMaxProperty = new MappedDependencyProperty<System.Single, TMPro.TextMeshProUGUI, Label>("FontSizeMax", x => x.TextMeshProUGUI, x => x.fontSizeMax, (x, y) => x.fontSizeMax = y);
        public System.Single FontSizeMax
        {
            get { return FontSizeMaxProperty.GetValue(this); }
            set { FontSizeMaxProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<TMPro.FontStyles, TMPro.TextMeshProUGUI, Label> FontStyleProperty = new MappedDependencyProperty<TMPro.FontStyles, TMPro.TextMeshProUGUI, Label>("FontStyle", x => x.TextMeshProUGUI, x => x.fontStyle, (x, y) => x.fontStyle = y);
        public TMPro.FontStyles FontStyle
        {
            get { return FontStyleProperty.GetValue(this); }
            set { FontStyleProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<TMPro.TextAlignmentOptions, TMPro.TextMeshProUGUI, Label> TextAlignmentProperty = new MappedDependencyProperty<TMPro.TextAlignmentOptions, TMPro.TextMeshProUGUI, Label>("TextAlignment", x => x.TextMeshProUGUI, x => x.alignment, (x, y) => x.alignment = y);
        public TMPro.TextAlignmentOptions TextAlignment
        {
            get { return TextAlignmentProperty.GetValue(this); }
            set { TextAlignmentProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Single, TMPro.TextMeshProUGUI, Label> CharacterSpacingProperty = new MappedDependencyProperty<System.Single, TMPro.TextMeshProUGUI, Label>("CharacterSpacing", x => x.TextMeshProUGUI, x => x.characterSpacing, (x, y) => x.characterSpacing = y);
        public System.Single CharacterSpacing
        {
            get { return CharacterSpacingProperty.GetValue(this); }
            set { CharacterSpacingProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Single, TMPro.TextMeshProUGUI, Label> WordSpacingProperty = new MappedDependencyProperty<System.Single, TMPro.TextMeshProUGUI, Label>("WordSpacing", x => x.TextMeshProUGUI, x => x.wordSpacing, (x, y) => x.wordSpacing = y);
        public System.Single WordSpacing
        {
            get { return WordSpacingProperty.GetValue(this); }
            set { WordSpacingProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Single, TMPro.TextMeshProUGUI, Label> LineSpacingProperty = new MappedDependencyProperty<System.Single, TMPro.TextMeshProUGUI, Label>("LineSpacing", x => x.TextMeshProUGUI, x => x.lineSpacing, (x, y) => x.lineSpacing = y);
        public System.Single LineSpacing
        {
            get { return LineSpacingProperty.GetValue(this); }
            set { LineSpacingProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Single, TMPro.TextMeshProUGUI, Label> LineSpacingAdjustmentProperty = new MappedDependencyProperty<System.Single, TMPro.TextMeshProUGUI, Label>("LineSpacingAdjustment", x => x.TextMeshProUGUI, x => x.lineSpacingAdjustment, (x, y) => x.lineSpacingAdjustment = y);
        public System.Single LineSpacingAdjustment
        {
            get { return LineSpacingAdjustmentProperty.GetValue(this); }
            set { LineSpacingAdjustmentProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Single, TMPro.TextMeshProUGUI, Label> ParagraphSpacingProperty = new MappedDependencyProperty<System.Single, TMPro.TextMeshProUGUI, Label>("ParagraphSpacing", x => x.TextMeshProUGUI, x => x.paragraphSpacing, (x, y) => x.paragraphSpacing = y);
        public System.Single ParagraphSpacing
        {
            get { return ParagraphSpacingProperty.GetValue(this); }
            set { ParagraphSpacingProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Single, TMPro.TextMeshProUGUI, Label> CharacterWidthAdjustmentProperty = new MappedDependencyProperty<System.Single, TMPro.TextMeshProUGUI, Label>("CharacterWidthAdjustment", x => x.TextMeshProUGUI, x => x.characterWidthAdjustment, (x, y) => x.characterWidthAdjustment = y);
        public System.Single CharacterWidthAdjustment
        {
            get { return CharacterWidthAdjustmentProperty.GetValue(this); }
            set { CharacterWidthAdjustmentProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Boolean, TMPro.TextMeshProUGUI, Label> EnableWordWrappingProperty = new MappedDependencyProperty<System.Boolean, TMPro.TextMeshProUGUI, Label>("EnableWordWrapping", x => x.TextMeshProUGUI, x => x.enableWordWrapping, (x, y) => x.enableWordWrapping = y);
        public System.Boolean EnableWordWrapping
        {
            get { return EnableWordWrappingProperty.GetValue(this); }
            set { EnableWordWrappingProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Single, TMPro.TextMeshProUGUI, Label> WordWrappingRatiosProperty = new MappedDependencyProperty<System.Single, TMPro.TextMeshProUGUI, Label>("WordWrappingRatios", x => x.TextMeshProUGUI, x => x.wordWrappingRatios, (x, y) => x.wordWrappingRatios = y);
        public System.Single WordWrappingRatios
        {
            get { return WordWrappingRatiosProperty.GetValue(this); }
            set { WordWrappingRatiosProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<TMPro.TextOverflowModes, TMPro.TextMeshProUGUI, Label> OverflowModeProperty = new MappedDependencyProperty<TMPro.TextOverflowModes, TMPro.TextMeshProUGUI, Label>("OverflowMode", x => x.TextMeshProUGUI, x => x.overflowMode, (x, y) => x.overflowMode = y);
        public TMPro.TextOverflowModes OverflowMode
        {
            get { return OverflowModeProperty.GetValue(this); }
            set { OverflowModeProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<TMPro.TMP_Text, TMPro.TextMeshProUGUI, Label> LinkedTextComponentProperty = new MappedDependencyProperty<TMPro.TMP_Text, TMPro.TextMeshProUGUI, Label>("LinkedTextComponent", x => x.TextMeshProUGUI, x => x.linkedTextComponent, (x, y) => x.linkedTextComponent = y);
        public TMPro.TMP_Text LinkedTextComponent
        {
            get { return LinkedTextComponentProperty.GetValue(this); }
            set { LinkedTextComponentProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Boolean, TMPro.TextMeshProUGUI, Label> IsLinkedTextComponentProperty = new MappedDependencyProperty<System.Boolean, TMPro.TextMeshProUGUI, Label>("IsLinkedTextComponent", x => x.TextMeshProUGUI, x => x.isLinkedTextComponent, (x, y) => x.isLinkedTextComponent = y);
        public System.Boolean IsLinkedTextComponent
        {
            get { return IsLinkedTextComponentProperty.GetValue(this); }
            set { IsLinkedTextComponentProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Boolean, TMPro.TextMeshProUGUI, Label> EnableKerningProperty = new MappedDependencyProperty<System.Boolean, TMPro.TextMeshProUGUI, Label>("EnableKerning", x => x.TextMeshProUGUI, x => x.enableKerning, (x, y) => x.enableKerning = y);
        public System.Boolean EnableKerning
        {
            get { return EnableKerningProperty.GetValue(this); }
            set { EnableKerningProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Boolean, TMPro.TextMeshProUGUI, Label> ExtraPaddingProperty = new MappedDependencyProperty<System.Boolean, TMPro.TextMeshProUGUI, Label>("ExtraPadding", x => x.TextMeshProUGUI, x => x.extraPadding, (x, y) => x.extraPadding = y);
        public System.Boolean ExtraPadding
        {
            get { return ExtraPaddingProperty.GetValue(this); }
            set { ExtraPaddingProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Boolean, TMPro.TextMeshProUGUI, Label> RichTextProperty = new MappedDependencyProperty<System.Boolean, TMPro.TextMeshProUGUI, Label>("RichText", x => x.TextMeshProUGUI, x => x.richText, (x, y) => x.richText = y);
        public System.Boolean RichText
        {
            get { return RichTextProperty.GetValue(this); }
            set { RichTextProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Boolean, TMPro.TextMeshProUGUI, Label> ParseCtrlCharactersProperty = new MappedDependencyProperty<System.Boolean, TMPro.TextMeshProUGUI, Label>("ParseCtrlCharacters", x => x.TextMeshProUGUI, x => x.parseCtrlCharacters, (x, y) => x.parseCtrlCharacters = y);
        public System.Boolean ParseCtrlCharacters
        {
            get { return ParseCtrlCharactersProperty.GetValue(this); }
            set { ParseCtrlCharactersProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Boolean, TMPro.TextMeshProUGUI, Label> IsOverlayProperty = new MappedDependencyProperty<System.Boolean, TMPro.TextMeshProUGUI, Label>("IsOverlay", x => x.TextMeshProUGUI, x => x.isOverlay, (x, y) => x.isOverlay = y);
        public System.Boolean IsOverlay
        {
            get { return IsOverlayProperty.GetValue(this); }
            set { IsOverlayProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Boolean, TMPro.TextMeshProUGUI, Label> IsOrthographicProperty = new MappedDependencyProperty<System.Boolean, TMPro.TextMeshProUGUI, Label>("IsOrthographic", x => x.TextMeshProUGUI, x => x.isOrthographic, (x, y) => x.isOrthographic = y);
        public System.Boolean IsOrthographic
        {
            get { return IsOrthographicProperty.GetValue(this); }
            set { IsOrthographicProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Boolean, TMPro.TextMeshProUGUI, Label> EnableCullingProperty = new MappedDependencyProperty<System.Boolean, TMPro.TextMeshProUGUI, Label>("EnableCulling", x => x.TextMeshProUGUI, x => x.enableCulling, (x, y) => x.enableCulling = y);
        public System.Boolean EnableCulling
        {
            get { return EnableCullingProperty.GetValue(this); }
            set { EnableCullingProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Boolean, TMPro.TextMeshProUGUI, Label> IgnoreRectMaskCullingProperty = new MappedDependencyProperty<System.Boolean, TMPro.TextMeshProUGUI, Label>("IgnoreRectMaskCulling", x => x.TextMeshProUGUI, x => x.ignoreRectMaskCulling, (x, y) => x.ignoreRectMaskCulling = y);
        public System.Boolean IgnoreRectMaskCulling
        {
            get { return IgnoreRectMaskCullingProperty.GetValue(this); }
            set { IgnoreRectMaskCullingProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Boolean, TMPro.TextMeshProUGUI, Label> IgnoreVisibilityProperty = new MappedDependencyProperty<System.Boolean, TMPro.TextMeshProUGUI, Label>("IgnoreVisibility", x => x.TextMeshProUGUI, x => x.ignoreVisibility, (x, y) => x.ignoreVisibility = y);
        public System.Boolean IgnoreVisibility
        {
            get { return IgnoreVisibilityProperty.GetValue(this); }
            set { IgnoreVisibilityProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<TMPro.TextureMappingOptions, TMPro.TextMeshProUGUI, Label> HorizontalMappingProperty = new MappedDependencyProperty<TMPro.TextureMappingOptions, TMPro.TextMeshProUGUI, Label>("HorizontalMapping", x => x.TextMeshProUGUI, x => x.horizontalMapping, (x, y) => x.horizontalMapping = y);
        public TMPro.TextureMappingOptions HorizontalMapping
        {
            get { return HorizontalMappingProperty.GetValue(this); }
            set { HorizontalMappingProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<TMPro.TextureMappingOptions, TMPro.TextMeshProUGUI, Label> VerticalMappingProperty = new MappedDependencyProperty<TMPro.TextureMappingOptions, TMPro.TextMeshProUGUI, Label>("VerticalMapping", x => x.TextMeshProUGUI, x => x.verticalMapping, (x, y) => x.verticalMapping = y);
        public TMPro.TextureMappingOptions VerticalMapping
        {
            get { return VerticalMappingProperty.GetValue(this); }
            set { VerticalMappingProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Single, TMPro.TextMeshProUGUI, Label> MappingUvLineOffsetProperty = new MappedDependencyProperty<System.Single, TMPro.TextMeshProUGUI, Label>("MappingUvLineOffset", x => x.TextMeshProUGUI, x => x.mappingUvLineOffset, (x, y) => x.mappingUvLineOffset = y);
        public System.Single MappingUvLineOffset
        {
            get { return MappingUvLineOffsetProperty.GetValue(this); }
            set { MappingUvLineOffsetProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<TMPro.TextRenderFlags, TMPro.TextMeshProUGUI, Label> RenderModeProperty = new MappedDependencyProperty<TMPro.TextRenderFlags, TMPro.TextMeshProUGUI, Label>("RenderMode", x => x.TextMeshProUGUI, x => x.renderMode, (x, y) => x.renderMode = y);
        public TMPro.TextRenderFlags RenderMode
        {
            get { return RenderModeProperty.GetValue(this); }
            set { RenderModeProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<TMPro.VertexSortingOrder, TMPro.TextMeshProUGUI, Label> GeometrySortingOrderProperty = new MappedDependencyProperty<TMPro.VertexSortingOrder, TMPro.TextMeshProUGUI, Label>("GeometrySortingOrder", x => x.TextMeshProUGUI, x => x.geometrySortingOrder, (x, y) => x.geometrySortingOrder = y);
        public TMPro.VertexSortingOrder GeometrySortingOrder
        {
            get { return GeometrySortingOrderProperty.GetValue(this); }
            set { GeometrySortingOrderProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Boolean, TMPro.TextMeshProUGUI, Label> VertexBufferAutoSizeReductionProperty = new MappedDependencyProperty<System.Boolean, TMPro.TextMeshProUGUI, Label>("VertexBufferAutoSizeReduction", x => x.TextMeshProUGUI, x => x.vertexBufferAutoSizeReduction, (x, y) => x.vertexBufferAutoSizeReduction = y);
        public System.Boolean VertexBufferAutoSizeReduction
        {
            get { return VertexBufferAutoSizeReductionProperty.GetValue(this); }
            set { VertexBufferAutoSizeReductionProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Int32, TMPro.TextMeshProUGUI, Label> FirstVisibleCharacterProperty = new MappedDependencyProperty<System.Int32, TMPro.TextMeshProUGUI, Label>("FirstVisibleCharacter", x => x.TextMeshProUGUI, x => x.firstVisibleCharacter, (x, y) => x.firstVisibleCharacter = y);
        public System.Int32 FirstVisibleCharacter
        {
            get { return FirstVisibleCharacterProperty.GetValue(this); }
            set { FirstVisibleCharacterProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Int32, TMPro.TextMeshProUGUI, Label> MaxVisibleCharactersProperty = new MappedDependencyProperty<System.Int32, TMPro.TextMeshProUGUI, Label>("MaxVisibleCharacters", x => x.TextMeshProUGUI, x => x.maxVisibleCharacters, (x, y) => x.maxVisibleCharacters = y);
        public System.Int32 MaxVisibleCharacters
        {
            get { return MaxVisibleCharactersProperty.GetValue(this); }
            set { MaxVisibleCharactersProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Int32, TMPro.TextMeshProUGUI, Label> MaxVisibleWordsProperty = new MappedDependencyProperty<System.Int32, TMPro.TextMeshProUGUI, Label>("MaxVisibleWords", x => x.TextMeshProUGUI, x => x.maxVisibleWords, (x, y) => x.maxVisibleWords = y);
        public System.Int32 MaxVisibleWords
        {
            get { return MaxVisibleWordsProperty.GetValue(this); }
            set { MaxVisibleWordsProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Int32, TMPro.TextMeshProUGUI, Label> MaxVisibleLinesProperty = new MappedDependencyProperty<System.Int32, TMPro.TextMeshProUGUI, Label>("MaxVisibleLines", x => x.TextMeshProUGUI, x => x.maxVisibleLines, (x, y) => x.maxVisibleLines = y);
        public System.Int32 MaxVisibleLines
        {
            get { return MaxVisibleLinesProperty.GetValue(this); }
            set { MaxVisibleLinesProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Boolean, TMPro.TextMeshProUGUI, Label> UseMaxVisibleDescenderProperty = new MappedDependencyProperty<System.Boolean, TMPro.TextMeshProUGUI, Label>("UseMaxVisibleDescender", x => x.TextMeshProUGUI, x => x.useMaxVisibleDescender, (x, y) => x.useMaxVisibleDescender = y);
        public System.Boolean UseMaxVisibleDescender
        {
            get { return UseMaxVisibleDescenderProperty.GetValue(this); }
            set { UseMaxVisibleDescenderProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Int32, TMPro.TextMeshProUGUI, Label> PageToDisplayProperty = new MappedDependencyProperty<System.Int32, TMPro.TextMeshProUGUI, Label>("PageToDisplay", x => x.TextMeshProUGUI, x => x.pageToDisplay, (x, y) => x.pageToDisplay = y);
        public System.Int32 PageToDisplay
        {
            get { return PageToDisplayProperty.GetValue(this); }
            set { PageToDisplayProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<UnityEngine.Vector4, TMPro.TextMeshProUGUI, Label> TextMarginProperty = new MappedDependencyProperty<UnityEngine.Vector4, TMPro.TextMeshProUGUI, Label>("TextMargin", x => x.TextMeshProUGUI, x => x.margin, (x, y) => x.margin = y);
        public UnityEngine.Vector4 TextMargin
        {
            get { return TextMarginProperty.GetValue(this); }
            set { TextMarginProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Boolean, TMPro.TextMeshProUGUI, Label> HavePropertiesChangedProperty = new MappedDependencyProperty<System.Boolean, TMPro.TextMeshProUGUI, Label>("HavePropertiesChanged", x => x.TextMeshProUGUI, x => x.havePropertiesChanged, (x, y) => x.havePropertiesChanged = y);
        public System.Boolean HavePropertiesChanged
        {
            get { return HavePropertiesChangedProperty.GetValue(this); }
            set { HavePropertiesChangedProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Boolean, TMPro.TextMeshProUGUI, Label> IsUsingLegacyAnimationComponentProperty = new MappedDependencyProperty<System.Boolean, TMPro.TextMeshProUGUI, Label>("IsUsingLegacyAnimationComponent", x => x.TextMeshProUGUI, x => x.isUsingLegacyAnimationComponent, (x, y) => x.isUsingLegacyAnimationComponent = y);
        public System.Boolean IsUsingLegacyAnimationComponent
        {
            get { return IsUsingLegacyAnimationComponentProperty.GetValue(this); }
            set { IsUsingLegacyAnimationComponentProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Boolean, TMPro.TextMeshProUGUI, Label> IsVolumetricTextProperty = new MappedDependencyProperty<System.Boolean, TMPro.TextMeshProUGUI, Label>("IsVolumetricText", x => x.TextMeshProUGUI, x => x.isVolumetricText, (x, y) => x.isVolumetricText = y);
        public System.Boolean IsVolumetricText
        {
            get { return IsVolumetricTextProperty.GetValue(this); }
            set { IsVolumetricTextProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<UnityEngine.UI.MaskableGraphic.CullStateChangedEvent, TMPro.TextMeshProUGUI, Label> OnCullStateChangedProperty = new MappedDependencyProperty<UnityEngine.UI.MaskableGraphic.CullStateChangedEvent, TMPro.TextMeshProUGUI, Label>("OnCullStateChanged", x => x.TextMeshProUGUI, x => x.onCullStateChanged, (x, y) => x.onCullStateChanged = y);
        public UnityEngine.UI.MaskableGraphic.CullStateChangedEvent OnCullStateChanged
        {
            get { return OnCullStateChangedProperty.GetValue(this); }
            set { OnCullStateChangedProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Boolean, TMPro.TextMeshProUGUI, Label> MaskableProperty = new MappedDependencyProperty<System.Boolean, TMPro.TextMeshProUGUI, Label>("Maskable", x => x.TextMeshProUGUI, x => x.maskable, (x, y) => x.maskable = y);
        public System.Boolean Maskable
        {
            get { return MaskableProperty.GetValue(this); }
            set { MaskableProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Boolean, TMPro.TextMeshProUGUI, Label> RaycastTargetProperty = new MappedDependencyProperty<System.Boolean, TMPro.TextMeshProUGUI, Label>("RaycastTarget", x => x.TextMeshProUGUI, x => x.raycastTarget, (x, y) => x.raycastTarget = y);
        public System.Boolean RaycastTarget
        {
            get { return RaycastTargetProperty.GetValue(this); }
            set { RaycastTargetProperty.SetValue(this, value); }
        }

        public readonly static MappedAssetDependencyProperty<MaterialAsset, TMPro.TextMeshProUGUI, Label> MaterialProperty = new MappedAssetDependencyProperty<MaterialAsset, TMPro.TextMeshProUGUI, Label>("Material", x => x.TextMeshProUGUI, (x, y) => x.material = y?.UnityObject);
        public MaterialAsset Material
        {
            get { return MaterialProperty.GetValue(this); }
            set { MaterialProperty.SetValue(this, value); }
        }

        #endregion
    }

    #region Data Templates

    public static class LabelTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return Label;
            }
        }

        private static Template _label;
        public static Template Label
        {
            get
            {
#if UNITY_EDITOR
                if (_label == null || _label.CurrentVersion != Template.Version)
#else
                if (_label == null)
#endif
                {
                    _label = new Template(UIViewTemplates.UIView);
#if UNITY_EDITOR
                    _label.Name = "Label";
#endif
                    Delight.Label.TextAlignmentProperty.SetDefault(_label, TMPro.TextAlignmentOptions.Left);
                    Delight.Label.WidthProperty.SetDefault(_label, new ElementSize(120f, ElementSizeUnit.Pixels));
                    Delight.Label.HeightProperty.SetDefault(_label, new ElementSize(40f, ElementSizeUnit.Pixels));
                    Delight.Label.FontColorProperty.SetDefault(_label, new UnityEngine.Color(0f, 0f, 0f, 1f));
                    Delight.Label.FontSizeProperty.SetDefault(_label, 24f);
                }
                return _label;
            }
        }

        #endregion
    }

    #endregion
}

#endif
