// Internal view logic generated from "CheckBox.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class CheckBox : UIImageView
    {
        #region Constructors

        public CheckBox(View parent, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :
            base(parent, layoutParent, id, template ?? CheckBoxTemplates.Default, initializer)
        {
            // constructing Group (CheckBoxGroup)
            CheckBoxGroup = new Group(this, this, "CheckBoxGroup", CheckBoxGroupTemplate);

            // binding <Group Spacing="{Spacing}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "Spacing" }, new List<Func<BindableObject>> { () => this }) }, new BindingPath(new List<string> { "CheckBoxGroup", "Spacing" }, new List<Func<BindableObject>> { () => this, () => CheckBoxGroup }), () => CheckBoxGroup.Spacing = Spacing, () => { }, false));
            CheckBoxImageView = new Image(this, CheckBoxGroup.Content, "CheckBoxImageView", CheckBoxImageViewTemplate);
            CheckBoxLabel = new Label(this, CheckBoxGroup.Content, "CheckBoxLabel", CheckBoxLabelTemplate);
            Click += ResolveActionHandler(this, "CheckBoxClick");
            this.AfterInitializeInternal();
        }

        public CheckBox() : this(null)
        {
        }

        static CheckBox()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(CheckBoxTemplates.Default, dependencyProperties);

            dependencyProperties.Add(IsCheckedProperty);
            dependencyProperties.Add(IsDisabledProperty);
            dependencyProperties.Add(IsInteractableProperty);
            dependencyProperties.Add(SpacingProperty);
            dependencyProperties.Add(CheckBoxGroupProperty);
            dependencyProperties.Add(CheckBoxGroupTemplateProperty);
            dependencyProperties.Add(CheckBoxImageViewProperty);
            dependencyProperties.Add(CheckBoxImageViewTemplateProperty);
            dependencyProperties.Add(CheckBoxLabelProperty);
            dependencyProperties.Add(CheckBoxLabelTemplateProperty);
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

        public readonly static DependencyProperty<Group> CheckBoxGroupProperty = new DependencyProperty<Group>("CheckBoxGroup");
        public Group CheckBoxGroup
        {
            get { return CheckBoxGroupProperty.GetValue(this); }
            set { CheckBoxGroupProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> CheckBoxGroupTemplateProperty = new DependencyProperty<Template>("CheckBoxGroupTemplate");
        public Template CheckBoxGroupTemplate
        {
            get { return CheckBoxGroupTemplateProperty.GetValue(this); }
            set { CheckBoxGroupTemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Image> CheckBoxImageViewProperty = new DependencyProperty<Image>("CheckBoxImageView");
        public Image CheckBoxImageView
        {
            get { return CheckBoxImageViewProperty.GetValue(this); }
            set { CheckBoxImageViewProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> CheckBoxImageViewTemplateProperty = new DependencyProperty<Template>("CheckBoxImageViewTemplate");
        public Template CheckBoxImageViewTemplate
        {
            get { return CheckBoxImageViewTemplateProperty.GetValue(this); }
            set { CheckBoxImageViewTemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Label> CheckBoxLabelProperty = new DependencyProperty<Label>("CheckBoxLabel");
        public Label CheckBoxLabel
        {
            get { return CheckBoxLabelProperty.GetValue(this); }
            set { CheckBoxLabelProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> CheckBoxLabelTemplateProperty = new DependencyProperty<Template>("CheckBoxLabelTemplate");
        public Template CheckBoxLabelTemplate
        {
            get { return CheckBoxLabelTemplateProperty.GetValue(this); }
            set { CheckBoxLabelTemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty CheckBoxSpriteProperty = Image.SpriteProperty;
        public SpriteAsset CheckBoxSprite
        {
            get { return CheckBoxImageView.Sprite; }
            set { CheckBoxImageView.Sprite = value; }
        }

        public readonly static DependencyProperty CheckBoxOverrideSpriteProperty = Image.OverrideSpriteProperty;
        public SpriteAsset CheckBoxOverrideSprite
        {
            get { return CheckBoxImageView.OverrideSprite; }
            set { CheckBoxImageView.OverrideSprite = value; }
        }

        public readonly static DependencyProperty CheckBoxTypeProperty = Image.TypeProperty;
        public UnityEngine.UI.Image.Type CheckBoxType
        {
            get { return CheckBoxImageView.Type; }
            set { CheckBoxImageView.Type = value; }
        }

        public readonly static DependencyProperty CheckBoxPreserveAspectProperty = Image.PreserveAspectProperty;
        public System.Boolean CheckBoxPreserveAspect
        {
            get { return CheckBoxImageView.PreserveAspect; }
            set { CheckBoxImageView.PreserveAspect = value; }
        }

        public readonly static DependencyProperty CheckBoxFillCenterProperty = Image.FillCenterProperty;
        public System.Boolean CheckBoxFillCenter
        {
            get { return CheckBoxImageView.FillCenter; }
            set { CheckBoxImageView.FillCenter = value; }
        }

        public readonly static DependencyProperty CheckBoxFillMethodProperty = Image.FillMethodProperty;
        public UnityEngine.UI.Image.FillMethod CheckBoxFillMethod
        {
            get { return CheckBoxImageView.FillMethod; }
            set { CheckBoxImageView.FillMethod = value; }
        }

        public readonly static DependencyProperty CheckBoxFillAmountProperty = Image.FillAmountProperty;
        public System.Single CheckBoxFillAmount
        {
            get { return CheckBoxImageView.FillAmount; }
            set { CheckBoxImageView.FillAmount = value; }
        }

        public readonly static DependencyProperty CheckBoxFillClockwiseProperty = Image.FillClockwiseProperty;
        public System.Boolean CheckBoxFillClockwise
        {
            get { return CheckBoxImageView.FillClockwise; }
            set { CheckBoxImageView.FillClockwise = value; }
        }

        public readonly static DependencyProperty CheckBoxFillOriginProperty = Image.FillOriginProperty;
        public System.Int32 CheckBoxFillOrigin
        {
            get { return CheckBoxImageView.FillOrigin; }
            set { CheckBoxImageView.FillOrigin = value; }
        }

        public readonly static DependencyProperty CheckBoxAlphaHitTestMinimumThresholdProperty = Image.AlphaHitTestMinimumThresholdProperty;
        public System.Single CheckBoxAlphaHitTestMinimumThreshold
        {
            get { return CheckBoxImageView.AlphaHitTestMinimumThreshold; }
            set { CheckBoxImageView.AlphaHitTestMinimumThreshold = value; }
        }

        public readonly static DependencyProperty CheckBoxUseSpriteMeshProperty = Image.UseSpriteMeshProperty;
        public System.Boolean CheckBoxUseSpriteMesh
        {
            get { return CheckBoxImageView.UseSpriteMesh; }
            set { CheckBoxImageView.UseSpriteMesh = value; }
        }

        public readonly static DependencyProperty CheckBoxMaterialProperty = Image.MaterialProperty;
        public MaterialAsset CheckBoxMaterial
        {
            get { return CheckBoxImageView.Material; }
            set { CheckBoxImageView.Material = value; }
        }

        public readonly static DependencyProperty CheckBoxOnCullStateChangedProperty = Image.OnCullStateChangedProperty;
        public UnityEngine.UI.MaskableGraphic.CullStateChangedEvent CheckBoxOnCullStateChanged
        {
            get { return CheckBoxImageView.OnCullStateChanged; }
            set { CheckBoxImageView.OnCullStateChanged = value; }
        }

        public readonly static DependencyProperty CheckBoxMaskableProperty = Image.MaskableProperty;
        public System.Boolean CheckBoxMaskable
        {
            get { return CheckBoxImageView.Maskable; }
            set { CheckBoxImageView.Maskable = value; }
        }

        public readonly static DependencyProperty CheckBoxColorProperty = Image.ColorProperty;
        public UnityEngine.Color CheckBoxColor
        {
            get { return CheckBoxImageView.Color; }
            set { CheckBoxImageView.Color = value; }
        }

        public readonly static DependencyProperty CheckBoxRaycastTargetProperty = Image.RaycastTargetProperty;
        public System.Boolean CheckBoxRaycastTarget
        {
            get { return CheckBoxImageView.RaycastTarget; }
            set { CheckBoxImageView.RaycastTarget = value; }
        }

        public readonly static DependencyProperty CheckBoxWidthProperty = Image.WidthProperty;
        public Delight.ElementSize CheckBoxWidth
        {
            get { return CheckBoxImageView.Width; }
            set { CheckBoxImageView.Width = value; }
        }

        public readonly static DependencyProperty CheckBoxHeightProperty = Image.HeightProperty;
        public Delight.ElementSize CheckBoxHeight
        {
            get { return CheckBoxImageView.Height; }
            set { CheckBoxImageView.Height = value; }
        }

        public readonly static DependencyProperty CheckBoxOverrideWidthProperty = Image.OverrideWidthProperty;
        public Delight.ElementSize CheckBoxOverrideWidth
        {
            get { return CheckBoxImageView.OverrideWidth; }
            set { CheckBoxImageView.OverrideWidth = value; }
        }

        public readonly static DependencyProperty CheckBoxOverrideHeightProperty = Image.OverrideHeightProperty;
        public Delight.ElementSize CheckBoxOverrideHeight
        {
            get { return CheckBoxImageView.OverrideHeight; }
            set { CheckBoxImageView.OverrideHeight = value; }
        }

        public readonly static DependencyProperty CheckBoxScaleProperty = Image.ScaleProperty;
        public UnityEngine.Vector3 CheckBoxScale
        {
            get { return CheckBoxImageView.Scale; }
            set { CheckBoxImageView.Scale = value; }
        }

        public readonly static DependencyProperty CheckBoxAlignmentProperty = Image.AlignmentProperty;
        public Delight.ElementAlignment CheckBoxAlignment
        {
            get { return CheckBoxImageView.Alignment; }
            set { CheckBoxImageView.Alignment = value; }
        }

        public readonly static DependencyProperty CheckBoxMarginProperty = Image.MarginProperty;
        public Delight.ElementMargin CheckBoxMargin
        {
            get { return CheckBoxImageView.Margin; }
            set { CheckBoxImageView.Margin = value; }
        }

        public readonly static DependencyProperty CheckBoxOffsetProperty = Image.OffsetProperty;
        public Delight.ElementMargin CheckBoxOffset
        {
            get { return CheckBoxImageView.Offset; }
            set { CheckBoxImageView.Offset = value; }
        }

        public readonly static DependencyProperty CheckBoxOffsetFromParentProperty = Image.OffsetFromParentProperty;
        public Delight.ElementMargin CheckBoxOffsetFromParent
        {
            get { return CheckBoxImageView.OffsetFromParent; }
            set { CheckBoxImageView.OffsetFromParent = value; }
        }

        public readonly static DependencyProperty CheckBoxPivotProperty = Image.PivotProperty;
        public UnityEngine.Vector2 CheckBoxPivot
        {
            get { return CheckBoxImageView.Pivot; }
            set { CheckBoxImageView.Pivot = value; }
        }

        public readonly static DependencyProperty CheckBoxLayoutRootProperty = Image.LayoutRootProperty;
        public Delight.LayoutRoot CheckBoxLayoutRoot
        {
            get { return CheckBoxImageView.LayoutRoot; }
            set { CheckBoxImageView.LayoutRoot = value; }
        }

        public readonly static DependencyProperty CheckBoxDisableLayoutUpdateProperty = Image.DisableLayoutUpdateProperty;
        public System.Boolean CheckBoxDisableLayoutUpdate
        {
            get { return CheckBoxImageView.DisableLayoutUpdate; }
            set { CheckBoxImageView.DisableLayoutUpdate = value; }
        }

        public readonly static DependencyProperty CheckBoxAlphaProperty = Image.AlphaProperty;
        public System.Single CheckBoxAlpha
        {
            get { return CheckBoxImageView.Alpha; }
            set { CheckBoxImageView.Alpha = value; }
        }

        public readonly static DependencyProperty CheckBoxIsVisibleProperty = Image.IsVisibleProperty;
        public System.Boolean CheckBoxIsVisible
        {
            get { return CheckBoxImageView.IsVisible; }
            set { CheckBoxImageView.IsVisible = value; }
        }

        public readonly static DependencyProperty CheckBoxRaycastBlockModeProperty = Image.RaycastBlockModeProperty;
        public Delight.RaycastBlockMode CheckBoxRaycastBlockMode
        {
            get { return CheckBoxImageView.RaycastBlockMode; }
            set { CheckBoxImageView.RaycastBlockMode = value; }
        }

        public readonly static DependencyProperty CheckBoxUseFastShaderProperty = Image.UseFastShaderProperty;
        public System.Boolean CheckBoxUseFastShader
        {
            get { return CheckBoxImageView.UseFastShader; }
            set { CheckBoxImageView.UseFastShader = value; }
        }

        public readonly static DependencyProperty CheckBoxBubbleNotifyChildLayoutChangedProperty = Image.BubbleNotifyChildLayoutChangedProperty;
        public System.Boolean CheckBoxBubbleNotifyChildLayoutChanged
        {
            get { return CheckBoxImageView.BubbleNotifyChildLayoutChanged; }
            set { CheckBoxImageView.BubbleNotifyChildLayoutChanged = value; }
        }

        public readonly static DependencyProperty CheckBoxIgnoreFlipProperty = Image.IgnoreFlipProperty;
        public System.Boolean CheckBoxIgnoreFlip
        {
            get { return CheckBoxImageView.IgnoreFlip; }
            set { CheckBoxImageView.IgnoreFlip = value; }
        }

        public readonly static DependencyProperty CheckBoxGameObjectProperty = Image.GameObjectProperty;
        public UnityEngine.GameObject CheckBoxGameObject
        {
            get { return CheckBoxImageView.GameObject; }
            set { CheckBoxImageView.GameObject = value; }
        }

        public readonly static DependencyProperty CheckBoxEnableScriptEventsProperty = Image.EnableScriptEventsProperty;
        public System.Boolean CheckBoxEnableScriptEvents
        {
            get { return CheckBoxImageView.EnableScriptEvents; }
            set { CheckBoxImageView.EnableScriptEvents = value; }
        }

        public readonly static DependencyProperty CheckBoxIgnoreObjectProperty = Image.IgnoreObjectProperty;
        public System.Boolean CheckBoxIgnoreObject
        {
            get { return CheckBoxImageView.IgnoreObject; }
            set { CheckBoxImageView.IgnoreObject = value; }
        }

        public readonly static DependencyProperty CheckBoxIsActiveProperty = Image.IsActiveProperty;
        public System.Boolean CheckBoxIsActive
        {
            get { return CheckBoxImageView.IsActive; }
            set { CheckBoxImageView.IsActive = value; }
        }

        public readonly static DependencyProperty CheckBoxLoadModeProperty = Image.LoadModeProperty;
        public Delight.LoadMode CheckBoxLoadMode
        {
            get { return CheckBoxImageView.LoadMode; }
            set { CheckBoxImageView.LoadMode = value; }
        }

        public readonly static DependencyProperty AutoSizeProperty = Label.AutoSizeProperty;
        public Delight.AutoSize AutoSize
        {
            get { return CheckBoxLabel.AutoSize; }
            set { CheckBoxLabel.AutoSize = value; }
        }

        public readonly static DependencyProperty AutoSizeTextContainerProperty = Label.AutoSizeTextContainerProperty;
        public System.Boolean AutoSizeTextContainer
        {
            get { return CheckBoxLabel.AutoSizeTextContainer; }
            set { CheckBoxLabel.AutoSizeTextContainer = value; }
        }

        public readonly static DependencyProperty MaskOffsetProperty = Label.MaskOffsetProperty;
        public UnityEngine.Vector4 MaskOffset
        {
            get { return CheckBoxLabel.MaskOffset; }
            set { CheckBoxLabel.MaskOffset = value; }
        }

        public readonly static DependencyProperty TextProperty = Label.TextProperty;
        public System.String Text
        {
            get { return CheckBoxLabel.Text; }
            set { CheckBoxLabel.Text = value; }
        }

        public readonly static DependencyProperty IsRightToLeftTextProperty = Label.IsRightToLeftTextProperty;
        public System.Boolean IsRightToLeftText
        {
            get { return CheckBoxLabel.IsRightToLeftText; }
            set { CheckBoxLabel.IsRightToLeftText = value; }
        }

        public readonly static DependencyProperty FontProperty = Label.FontProperty;
        public TMP_FontAsset Font
        {
            get { return CheckBoxLabel.Font; }
            set { CheckBoxLabel.Font = value; }
        }

        public readonly static DependencyProperty FontSharedMaterialProperty = Label.FontSharedMaterialProperty;
        public MaterialAsset FontSharedMaterial
        {
            get { return CheckBoxLabel.FontSharedMaterial; }
            set { CheckBoxLabel.FontSharedMaterial = value; }
        }

        public readonly static DependencyProperty FontSharedMaterialsProperty = Label.FontSharedMaterialsProperty;
        public UnityEngine.Material[] FontSharedMaterials
        {
            get { return CheckBoxLabel.FontSharedMaterials; }
            set { CheckBoxLabel.FontSharedMaterials = value; }
        }

        public readonly static DependencyProperty FontMaterialProperty = Label.FontMaterialProperty;
        public MaterialAsset FontMaterial
        {
            get { return CheckBoxLabel.FontMaterial; }
            set { CheckBoxLabel.FontMaterial = value; }
        }

        public readonly static DependencyProperty FontMaterialsProperty = Label.FontMaterialsProperty;
        public UnityEngine.Material[] FontMaterials
        {
            get { return CheckBoxLabel.FontMaterials; }
            set { CheckBoxLabel.FontMaterials = value; }
        }

        public readonly static DependencyProperty FontColorProperty = Label.FontColorProperty;
        public UnityEngine.Color FontColor
        {
            get { return CheckBoxLabel.FontColor; }
            set { CheckBoxLabel.FontColor = value; }
        }

        public readonly static DependencyProperty TextMeshProUGUIAlphaProperty = Label.TextMeshProUGUIAlphaProperty;
        public System.Single TextMeshProUGUIAlpha
        {
            get { return CheckBoxLabel.TextMeshProUGUIAlpha; }
            set { CheckBoxLabel.TextMeshProUGUIAlpha = value; }
        }

        public readonly static DependencyProperty EnableVertexGradientProperty = Label.EnableVertexGradientProperty;
        public System.Boolean EnableVertexGradient
        {
            get { return CheckBoxLabel.EnableVertexGradient; }
            set { CheckBoxLabel.EnableVertexGradient = value; }
        }

        public readonly static DependencyProperty ColorGradientProperty = Label.ColorGradientProperty;
        public TMPro.VertexGradient ColorGradient
        {
            get { return CheckBoxLabel.ColorGradient; }
            set { CheckBoxLabel.ColorGradient = value; }
        }

        public readonly static DependencyProperty ColorGradientPresetProperty = Label.ColorGradientPresetProperty;
        public TMP_ColorGradientAsset ColorGradientPreset
        {
            get { return CheckBoxLabel.ColorGradientPreset; }
            set { CheckBoxLabel.ColorGradientPreset = value; }
        }

        public readonly static DependencyProperty SpriteAssetProperty = Label.SpriteAssetProperty;
        public TMP_SpriteAsset SpriteAsset
        {
            get { return CheckBoxLabel.SpriteAsset; }
            set { CheckBoxLabel.SpriteAsset = value; }
        }

        public readonly static DependencyProperty TintAllSpritesProperty = Label.TintAllSpritesProperty;
        public System.Boolean TintAllSprites
        {
            get { return CheckBoxLabel.TintAllSprites; }
            set { CheckBoxLabel.TintAllSprites = value; }
        }

        public readonly static DependencyProperty OverrideColorTagsProperty = Label.OverrideColorTagsProperty;
        public System.Boolean OverrideColorTags
        {
            get { return CheckBoxLabel.OverrideColorTags; }
            set { CheckBoxLabel.OverrideColorTags = value; }
        }

        public readonly static DependencyProperty FaceColorProperty = Label.FaceColorProperty;
        public UnityEngine.Color32 FaceColor
        {
            get { return CheckBoxLabel.FaceColor; }
            set { CheckBoxLabel.FaceColor = value; }
        }

        public readonly static DependencyProperty OutlineColorProperty = Label.OutlineColorProperty;
        public UnityEngine.Color32 OutlineColor
        {
            get { return CheckBoxLabel.OutlineColor; }
            set { CheckBoxLabel.OutlineColor = value; }
        }

        public readonly static DependencyProperty OutlineWidthProperty = Label.OutlineWidthProperty;
        public System.Single OutlineWidth
        {
            get { return CheckBoxLabel.OutlineWidth; }
            set { CheckBoxLabel.OutlineWidth = value; }
        }

        public readonly static DependencyProperty FontSizeProperty = Label.FontSizeProperty;
        public System.Single FontSize
        {
            get { return CheckBoxLabel.FontSize; }
            set { CheckBoxLabel.FontSize = value; }
        }

        public readonly static DependencyProperty FontWeightProperty = Label.FontWeightProperty;
        public TMPro.FontWeight FontWeight
        {
            get { return CheckBoxLabel.FontWeight; }
            set { CheckBoxLabel.FontWeight = value; }
        }

        public readonly static DependencyProperty EnableAutoSizingProperty = Label.EnableAutoSizingProperty;
        public System.Boolean EnableAutoSizing
        {
            get { return CheckBoxLabel.EnableAutoSizing; }
            set { CheckBoxLabel.EnableAutoSizing = value; }
        }

        public readonly static DependencyProperty FontSizeMinProperty = Label.FontSizeMinProperty;
        public System.Single FontSizeMin
        {
            get { return CheckBoxLabel.FontSizeMin; }
            set { CheckBoxLabel.FontSizeMin = value; }
        }

        public readonly static DependencyProperty FontSizeMaxProperty = Label.FontSizeMaxProperty;
        public System.Single FontSizeMax
        {
            get { return CheckBoxLabel.FontSizeMax; }
            set { CheckBoxLabel.FontSizeMax = value; }
        }

        public readonly static DependencyProperty FontStyleProperty = Label.FontStyleProperty;
        public TMPro.FontStyles FontStyle
        {
            get { return CheckBoxLabel.FontStyle; }
            set { CheckBoxLabel.FontStyle = value; }
        }

        public readonly static DependencyProperty TextAlignmentProperty = Label.TextAlignmentProperty;
        public TMPro.TextAlignmentOptions TextAlignment
        {
            get { return CheckBoxLabel.TextAlignment; }
            set { CheckBoxLabel.TextAlignment = value; }
        }

        public readonly static DependencyProperty CharacterSpacingProperty = Label.CharacterSpacingProperty;
        public System.Single CharacterSpacing
        {
            get { return CheckBoxLabel.CharacterSpacing; }
            set { CheckBoxLabel.CharacterSpacing = value; }
        }

        public readonly static DependencyProperty WordSpacingProperty = Label.WordSpacingProperty;
        public System.Single WordSpacing
        {
            get { return CheckBoxLabel.WordSpacing; }
            set { CheckBoxLabel.WordSpacing = value; }
        }

        public readonly static DependencyProperty LineSpacingProperty = Label.LineSpacingProperty;
        public System.Single LineSpacing
        {
            get { return CheckBoxLabel.LineSpacing; }
            set { CheckBoxLabel.LineSpacing = value; }
        }

        public readonly static DependencyProperty LineSpacingAdjustmentProperty = Label.LineSpacingAdjustmentProperty;
        public System.Single LineSpacingAdjustment
        {
            get { return CheckBoxLabel.LineSpacingAdjustment; }
            set { CheckBoxLabel.LineSpacingAdjustment = value; }
        }

        public readonly static DependencyProperty ParagraphSpacingProperty = Label.ParagraphSpacingProperty;
        public System.Single ParagraphSpacing
        {
            get { return CheckBoxLabel.ParagraphSpacing; }
            set { CheckBoxLabel.ParagraphSpacing = value; }
        }

        public readonly static DependencyProperty CharacterWidthAdjustmentProperty = Label.CharacterWidthAdjustmentProperty;
        public System.Single CharacterWidthAdjustment
        {
            get { return CheckBoxLabel.CharacterWidthAdjustment; }
            set { CheckBoxLabel.CharacterWidthAdjustment = value; }
        }

        public readonly static DependencyProperty EnableWordWrappingProperty = Label.EnableWordWrappingProperty;
        public System.Boolean EnableWordWrapping
        {
            get { return CheckBoxLabel.EnableWordWrapping; }
            set { CheckBoxLabel.EnableWordWrapping = value; }
        }

        public readonly static DependencyProperty WordWrappingRatiosProperty = Label.WordWrappingRatiosProperty;
        public System.Single WordWrappingRatios
        {
            get { return CheckBoxLabel.WordWrappingRatios; }
            set { CheckBoxLabel.WordWrappingRatios = value; }
        }

        public readonly static DependencyProperty OverflowModeProperty = Label.OverflowModeProperty;
        public TMPro.TextOverflowModes OverflowMode
        {
            get { return CheckBoxLabel.OverflowMode; }
            set { CheckBoxLabel.OverflowMode = value; }
        }

        public readonly static DependencyProperty LinkedTextComponentProperty = Label.LinkedTextComponentProperty;
        public TMPro.TMP_Text LinkedTextComponent
        {
            get { return CheckBoxLabel.LinkedTextComponent; }
            set { CheckBoxLabel.LinkedTextComponent = value; }
        }

        public readonly static DependencyProperty IsLinkedTextComponentProperty = Label.IsLinkedTextComponentProperty;
        public System.Boolean IsLinkedTextComponent
        {
            get { return CheckBoxLabel.IsLinkedTextComponent; }
            set { CheckBoxLabel.IsLinkedTextComponent = value; }
        }

        public readonly static DependencyProperty EnableKerningProperty = Label.EnableKerningProperty;
        public System.Boolean EnableKerning
        {
            get { return CheckBoxLabel.EnableKerning; }
            set { CheckBoxLabel.EnableKerning = value; }
        }

        public readonly static DependencyProperty ExtraPaddingProperty = Label.ExtraPaddingProperty;
        public System.Boolean ExtraPadding
        {
            get { return CheckBoxLabel.ExtraPadding; }
            set { CheckBoxLabel.ExtraPadding = value; }
        }

        public readonly static DependencyProperty RichTextProperty = Label.RichTextProperty;
        public System.Boolean RichText
        {
            get { return CheckBoxLabel.RichText; }
            set { CheckBoxLabel.RichText = value; }
        }

        public readonly static DependencyProperty ParseCtrlCharactersProperty = Label.ParseCtrlCharactersProperty;
        public System.Boolean ParseCtrlCharacters
        {
            get { return CheckBoxLabel.ParseCtrlCharacters; }
            set { CheckBoxLabel.ParseCtrlCharacters = value; }
        }

        public readonly static DependencyProperty IsOverlayProperty = Label.IsOverlayProperty;
        public System.Boolean IsOverlay
        {
            get { return CheckBoxLabel.IsOverlay; }
            set { CheckBoxLabel.IsOverlay = value; }
        }

        public readonly static DependencyProperty IsOrthographicProperty = Label.IsOrthographicProperty;
        public System.Boolean IsOrthographic
        {
            get { return CheckBoxLabel.IsOrthographic; }
            set { CheckBoxLabel.IsOrthographic = value; }
        }

        public readonly static DependencyProperty EnableCullingProperty = Label.EnableCullingProperty;
        public System.Boolean EnableCulling
        {
            get { return CheckBoxLabel.EnableCulling; }
            set { CheckBoxLabel.EnableCulling = value; }
        }

        public readonly static DependencyProperty IgnoreRectMaskCullingProperty = Label.IgnoreRectMaskCullingProperty;
        public System.Boolean IgnoreRectMaskCulling
        {
            get { return CheckBoxLabel.IgnoreRectMaskCulling; }
            set { CheckBoxLabel.IgnoreRectMaskCulling = value; }
        }

        public readonly static DependencyProperty IgnoreVisibilityProperty = Label.IgnoreVisibilityProperty;
        public System.Boolean IgnoreVisibility
        {
            get { return CheckBoxLabel.IgnoreVisibility; }
            set { CheckBoxLabel.IgnoreVisibility = value; }
        }

        public readonly static DependencyProperty HorizontalMappingProperty = Label.HorizontalMappingProperty;
        public TMPro.TextureMappingOptions HorizontalMapping
        {
            get { return CheckBoxLabel.HorizontalMapping; }
            set { CheckBoxLabel.HorizontalMapping = value; }
        }

        public readonly static DependencyProperty VerticalMappingProperty = Label.VerticalMappingProperty;
        public TMPro.TextureMappingOptions VerticalMapping
        {
            get { return CheckBoxLabel.VerticalMapping; }
            set { CheckBoxLabel.VerticalMapping = value; }
        }

        public readonly static DependencyProperty MappingUvLineOffsetProperty = Label.MappingUvLineOffsetProperty;
        public System.Single MappingUvLineOffset
        {
            get { return CheckBoxLabel.MappingUvLineOffset; }
            set { CheckBoxLabel.MappingUvLineOffset = value; }
        }

        public readonly static DependencyProperty RenderModeProperty = Label.RenderModeProperty;
        public TMPro.TextRenderFlags RenderMode
        {
            get { return CheckBoxLabel.RenderMode; }
            set { CheckBoxLabel.RenderMode = value; }
        }

        public readonly static DependencyProperty GeometrySortingOrderProperty = Label.GeometrySortingOrderProperty;
        public TMPro.VertexSortingOrder GeometrySortingOrder
        {
            get { return CheckBoxLabel.GeometrySortingOrder; }
            set { CheckBoxLabel.GeometrySortingOrder = value; }
        }

        public readonly static DependencyProperty VertexBufferAutoSizeReductionProperty = Label.VertexBufferAutoSizeReductionProperty;
        public System.Boolean VertexBufferAutoSizeReduction
        {
            get { return CheckBoxLabel.VertexBufferAutoSizeReduction; }
            set { CheckBoxLabel.VertexBufferAutoSizeReduction = value; }
        }

        public readonly static DependencyProperty FirstVisibleCharacterProperty = Label.FirstVisibleCharacterProperty;
        public System.Int32 FirstVisibleCharacter
        {
            get { return CheckBoxLabel.FirstVisibleCharacter; }
            set { CheckBoxLabel.FirstVisibleCharacter = value; }
        }

        public readonly static DependencyProperty MaxVisibleCharactersProperty = Label.MaxVisibleCharactersProperty;
        public System.Int32 MaxVisibleCharacters
        {
            get { return CheckBoxLabel.MaxVisibleCharacters; }
            set { CheckBoxLabel.MaxVisibleCharacters = value; }
        }

        public readonly static DependencyProperty MaxVisibleWordsProperty = Label.MaxVisibleWordsProperty;
        public System.Int32 MaxVisibleWords
        {
            get { return CheckBoxLabel.MaxVisibleWords; }
            set { CheckBoxLabel.MaxVisibleWords = value; }
        }

        public readonly static DependencyProperty MaxVisibleLinesProperty = Label.MaxVisibleLinesProperty;
        public System.Int32 MaxVisibleLines
        {
            get { return CheckBoxLabel.MaxVisibleLines; }
            set { CheckBoxLabel.MaxVisibleLines = value; }
        }

        public readonly static DependencyProperty UseMaxVisibleDescenderProperty = Label.UseMaxVisibleDescenderProperty;
        public System.Boolean UseMaxVisibleDescender
        {
            get { return CheckBoxLabel.UseMaxVisibleDescender; }
            set { CheckBoxLabel.UseMaxVisibleDescender = value; }
        }

        public readonly static DependencyProperty PageToDisplayProperty = Label.PageToDisplayProperty;
        public System.Int32 PageToDisplay
        {
            get { return CheckBoxLabel.PageToDisplay; }
            set { CheckBoxLabel.PageToDisplay = value; }
        }

        public readonly static DependencyProperty TextMarginProperty = Label.TextMarginProperty;
        public UnityEngine.Vector4 TextMargin
        {
            get { return CheckBoxLabel.TextMargin; }
            set { CheckBoxLabel.TextMargin = value; }
        }

        public readonly static DependencyProperty HavePropertiesChangedProperty = Label.HavePropertiesChangedProperty;
        public System.Boolean HavePropertiesChanged
        {
            get { return CheckBoxLabel.HavePropertiesChanged; }
            set { CheckBoxLabel.HavePropertiesChanged = value; }
        }

        public readonly static DependencyProperty IsUsingLegacyAnimationComponentProperty = Label.IsUsingLegacyAnimationComponentProperty;
        public System.Boolean IsUsingLegacyAnimationComponent
        {
            get { return CheckBoxLabel.IsUsingLegacyAnimationComponent; }
            set { CheckBoxLabel.IsUsingLegacyAnimationComponent = value; }
        }

        public readonly static DependencyProperty IsVolumetricTextProperty = Label.IsVolumetricTextProperty;
        public System.Boolean IsVolumetricText
        {
            get { return CheckBoxLabel.IsVolumetricText; }
            set { CheckBoxLabel.IsVolumetricText = value; }
        }

        public readonly static DependencyProperty OnCullStateChangedProperty = Label.OnCullStateChangedProperty;
        public UnityEngine.UI.MaskableGraphic.CullStateChangedEvent OnCullStateChanged
        {
            get { return CheckBoxLabel.OnCullStateChanged; }
            set { CheckBoxLabel.OnCullStateChanged = value; }
        }

        public readonly static DependencyProperty MaskableProperty = Label.MaskableProperty;
        public System.Boolean Maskable
        {
            get { return CheckBoxLabel.Maskable; }
            set { CheckBoxLabel.Maskable = value; }
        }

        public readonly static DependencyProperty RaycastTargetProperty = Label.RaycastTargetProperty;
        public System.Boolean RaycastTarget
        {
            get { return CheckBoxLabel.RaycastTarget; }
            set { CheckBoxLabel.RaycastTarget = value; }
        }

        public readonly static DependencyProperty MaterialProperty = Label.MaterialProperty;
        public MaterialAsset Material
        {
            get { return CheckBoxLabel.Material; }
            set { CheckBoxLabel.Material = value; }
        }

        public readonly static DependencyProperty CheckBoxLabelWidthProperty = Label.WidthProperty;
        public Delight.ElementSize CheckBoxLabelWidth
        {
            get { return CheckBoxLabel.Width; }
            set { CheckBoxLabel.Width = value; }
        }

        public readonly static DependencyProperty CheckBoxLabelHeightProperty = Label.HeightProperty;
        public Delight.ElementSize CheckBoxLabelHeight
        {
            get { return CheckBoxLabel.Height; }
            set { CheckBoxLabel.Height = value; }
        }

        public readonly static DependencyProperty CheckBoxLabelOverrideWidthProperty = Label.OverrideWidthProperty;
        public Delight.ElementSize CheckBoxLabelOverrideWidth
        {
            get { return CheckBoxLabel.OverrideWidth; }
            set { CheckBoxLabel.OverrideWidth = value; }
        }

        public readonly static DependencyProperty CheckBoxLabelOverrideHeightProperty = Label.OverrideHeightProperty;
        public Delight.ElementSize CheckBoxLabelOverrideHeight
        {
            get { return CheckBoxLabel.OverrideHeight; }
            set { CheckBoxLabel.OverrideHeight = value; }
        }

        public readonly static DependencyProperty CheckBoxLabelScaleProperty = Label.ScaleProperty;
        public UnityEngine.Vector3 CheckBoxLabelScale
        {
            get { return CheckBoxLabel.Scale; }
            set { CheckBoxLabel.Scale = value; }
        }

        public readonly static DependencyProperty CheckBoxLabelAlignmentProperty = Label.AlignmentProperty;
        public Delight.ElementAlignment CheckBoxLabelAlignment
        {
            get { return CheckBoxLabel.Alignment; }
            set { CheckBoxLabel.Alignment = value; }
        }

        public readonly static DependencyProperty CheckBoxLabelMarginProperty = Label.MarginProperty;
        public Delight.ElementMargin CheckBoxLabelMargin
        {
            get { return CheckBoxLabel.Margin; }
            set { CheckBoxLabel.Margin = value; }
        }

        public readonly static DependencyProperty CheckBoxLabelOffsetProperty = Label.OffsetProperty;
        public Delight.ElementMargin CheckBoxLabelOffset
        {
            get { return CheckBoxLabel.Offset; }
            set { CheckBoxLabel.Offset = value; }
        }

        public readonly static DependencyProperty CheckBoxLabelOffsetFromParentProperty = Label.OffsetFromParentProperty;
        public Delight.ElementMargin CheckBoxLabelOffsetFromParent
        {
            get { return CheckBoxLabel.OffsetFromParent; }
            set { CheckBoxLabel.OffsetFromParent = value; }
        }

        public readonly static DependencyProperty CheckBoxLabelPivotProperty = Label.PivotProperty;
        public UnityEngine.Vector2 CheckBoxLabelPivot
        {
            get { return CheckBoxLabel.Pivot; }
            set { CheckBoxLabel.Pivot = value; }
        }

        public readonly static DependencyProperty CheckBoxLabelLayoutRootProperty = Label.LayoutRootProperty;
        public Delight.LayoutRoot CheckBoxLabelLayoutRoot
        {
            get { return CheckBoxLabel.LayoutRoot; }
            set { CheckBoxLabel.LayoutRoot = value; }
        }

        public readonly static DependencyProperty CheckBoxLabelDisableLayoutUpdateProperty = Label.DisableLayoutUpdateProperty;
        public System.Boolean CheckBoxLabelDisableLayoutUpdate
        {
            get { return CheckBoxLabel.DisableLayoutUpdate; }
            set { CheckBoxLabel.DisableLayoutUpdate = value; }
        }

        public readonly static DependencyProperty CheckBoxLabelAlphaProperty = Label.AlphaProperty;
        public System.Single CheckBoxLabelAlpha
        {
            get { return CheckBoxLabel.Alpha; }
            set { CheckBoxLabel.Alpha = value; }
        }

        public readonly static DependencyProperty CheckBoxLabelIsVisibleProperty = Label.IsVisibleProperty;
        public System.Boolean CheckBoxLabelIsVisible
        {
            get { return CheckBoxLabel.IsVisible; }
            set { CheckBoxLabel.IsVisible = value; }
        }

        public readonly static DependencyProperty CheckBoxLabelRaycastBlockModeProperty = Label.RaycastBlockModeProperty;
        public Delight.RaycastBlockMode CheckBoxLabelRaycastBlockMode
        {
            get { return CheckBoxLabel.RaycastBlockMode; }
            set { CheckBoxLabel.RaycastBlockMode = value; }
        }

        public readonly static DependencyProperty CheckBoxLabelUseFastShaderProperty = Label.UseFastShaderProperty;
        public System.Boolean CheckBoxLabelUseFastShader
        {
            get { return CheckBoxLabel.UseFastShader; }
            set { CheckBoxLabel.UseFastShader = value; }
        }

        public readonly static DependencyProperty CheckBoxLabelBubbleNotifyChildLayoutChangedProperty = Label.BubbleNotifyChildLayoutChangedProperty;
        public System.Boolean CheckBoxLabelBubbleNotifyChildLayoutChanged
        {
            get { return CheckBoxLabel.BubbleNotifyChildLayoutChanged; }
            set { CheckBoxLabel.BubbleNotifyChildLayoutChanged = value; }
        }

        public readonly static DependencyProperty CheckBoxLabelIgnoreFlipProperty = Label.IgnoreFlipProperty;
        public System.Boolean CheckBoxLabelIgnoreFlip
        {
            get { return CheckBoxLabel.IgnoreFlip; }
            set { CheckBoxLabel.IgnoreFlip = value; }
        }

        public readonly static DependencyProperty CheckBoxLabelGameObjectProperty = Label.GameObjectProperty;
        public UnityEngine.GameObject CheckBoxLabelGameObject
        {
            get { return CheckBoxLabel.GameObject; }
            set { CheckBoxLabel.GameObject = value; }
        }

        public readonly static DependencyProperty CheckBoxLabelEnableScriptEventsProperty = Label.EnableScriptEventsProperty;
        public System.Boolean CheckBoxLabelEnableScriptEvents
        {
            get { return CheckBoxLabel.EnableScriptEvents; }
            set { CheckBoxLabel.EnableScriptEvents = value; }
        }

        public readonly static DependencyProperty CheckBoxLabelIgnoreObjectProperty = Label.IgnoreObjectProperty;
        public System.Boolean CheckBoxLabelIgnoreObject
        {
            get { return CheckBoxLabel.IgnoreObject; }
            set { CheckBoxLabel.IgnoreObject = value; }
        }

        public readonly static DependencyProperty CheckBoxLabelIsActiveProperty = Label.IsActiveProperty;
        public System.Boolean CheckBoxLabelIsActive
        {
            get { return CheckBoxLabel.IsActive; }
            set { CheckBoxLabel.IsActive = value; }
        }

        public readonly static DependencyProperty CheckBoxLabelLoadModeProperty = Label.LoadModeProperty;
        public Delight.LoadMode CheckBoxLabelLoadMode
        {
            get { return CheckBoxLabel.LoadMode; }
            set { CheckBoxLabel.LoadMode = value; }
        }

        #endregion
    }

    #region Data Templates

    public static class CheckBoxTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return CheckBox;
            }
        }

        private static Template _checkBox;
        public static Template CheckBox
        {
            get
            {
#if UNITY_EDITOR
                if (_checkBox == null || _checkBox.CurrentVersion != Template.Version)
#else
                if (_checkBox == null)
#endif
                {
                    _checkBox = new Template(UIImageViewTemplates.UIImageView);
#if UNITY_EDITOR
                    _checkBox.Name = "CheckBox";
#endif
                    Delight.CheckBox.IsInteractableProperty.SetDefault(_checkBox, true);
                    Delight.CheckBox.SpacingProperty.SetDefault(_checkBox, new ElementSize(10f, ElementSizeUnit.Pixels));
                    Delight.CheckBox.HeightProperty.SetDefault(_checkBox, new ElementSize(40f, ElementSizeUnit.Pixels));
                    Delight.CheckBox.HeightProperty.SetDefault(_checkBox, new ElementSize(25f, ElementSizeUnit.Pixels));
                    Delight.CheckBox.SpacingProperty.SetDefault(_checkBox, new ElementSize(10f, ElementSizeUnit.Pixels));
                    Delight.CheckBox.CheckBoxGroupTemplateProperty.SetDefault(_checkBox, CheckBoxCheckBoxGroup);
                    Delight.CheckBox.CheckBoxImageViewTemplateProperty.SetDefault(_checkBox, CheckBoxCheckBoxImageView);
                    Delight.CheckBox.CheckBoxLabelTemplateProperty.SetDefault(_checkBox, CheckBoxCheckBoxLabel);
                }
                return _checkBox;
            }
        }

        private static Template _checkBoxCheckBoxGroup;
        public static Template CheckBoxCheckBoxGroup
        {
            get
            {
#if UNITY_EDITOR
                if (_checkBoxCheckBoxGroup == null || _checkBoxCheckBoxGroup.CurrentVersion != Template.Version)
#else
                if (_checkBoxCheckBoxGroup == null)
#endif
                {
                    _checkBoxCheckBoxGroup = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _checkBoxCheckBoxGroup.Name = "CheckBoxCheckBoxGroup";
#endif
                    Delight.Group.OrientationProperty.SetDefault(_checkBoxCheckBoxGroup, Delight.ElementOrientation.Horizontal);
                }
                return _checkBoxCheckBoxGroup;
            }
        }

        private static Template _checkBoxCheckBoxImageView;
        public static Template CheckBoxCheckBoxImageView
        {
            get
            {
#if UNITY_EDITOR
                if (_checkBoxCheckBoxImageView == null || _checkBoxCheckBoxImageView.CurrentVersion != Template.Version)
#else
                if (_checkBoxCheckBoxImageView == null)
#endif
                {
                    _checkBoxCheckBoxImageView = new Template(ImageTemplates.Image);
#if UNITY_EDITOR
                    _checkBoxCheckBoxImageView.Name = "CheckBoxCheckBoxImageView";
#endif
                    Delight.Image.WidthProperty.SetDefault(_checkBoxCheckBoxImageView, new ElementSize(40f, ElementSizeUnit.Pixels));
                    Delight.Image.HeightProperty.SetDefault(_checkBoxCheckBoxImageView, new ElementSize(40f, ElementSizeUnit.Pixels));
                    Delight.Image.SpriteProperty.SetDefault(_checkBoxCheckBoxImageView, Assets.Sprites["CheckBox"]);
                    Delight.Image.SpriteProperty.SetStateDefault("Checked", _checkBoxCheckBoxImageView, Assets.Sprites["CheckBoxPressed"]);
                    Delight.Image.WidthProperty.SetDefault(_checkBoxCheckBoxImageView, new ElementSize(24f, ElementSizeUnit.Pixels));
                    Delight.Image.HeightProperty.SetDefault(_checkBoxCheckBoxImageView, new ElementSize(24f, ElementSizeUnit.Pixels));
                    Delight.Image.ColorProperty.SetDefault(_checkBoxCheckBoxImageView, new UnityEngine.Color(1f, 1f, 1f, 1f));
                }
                return _checkBoxCheckBoxImageView;
            }
        }

        private static Template _checkBoxCheckBoxLabel;
        public static Template CheckBoxCheckBoxLabel
        {
            get
            {
#if UNITY_EDITOR
                if (_checkBoxCheckBoxLabel == null || _checkBoxCheckBoxLabel.CurrentVersion != Template.Version)
#else
                if (_checkBoxCheckBoxLabel == null)
#endif
                {
                    _checkBoxCheckBoxLabel = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _checkBoxCheckBoxLabel.Name = "CheckBoxCheckBoxLabel";
#endif
                    Delight.Label.AutoSizeProperty.SetDefault(_checkBoxCheckBoxLabel, Delight.AutoSize.Width);
                    Delight.Label.HeightProperty.SetDefault(_checkBoxCheckBoxLabel, new ElementSize(1f, ElementSizeUnit.Percents));
                    Delight.Label.FontSizeProperty.SetDefault(_checkBoxCheckBoxLabel, 18f);
                    Delight.Label.FontStyleProperty.SetDefault(_checkBoxCheckBoxLabel, TMPro.FontStyles.Normal);
                    Delight.Label.FontColorProperty.SetDefault(_checkBoxCheckBoxLabel, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Label.FontStyleProperty.SetStateDefault("Disabled", _checkBoxCheckBoxLabel, TMPro.FontStyles.Italic);
                    Delight.Label.FontColorProperty.SetStateDefault("Disabled", _checkBoxCheckBoxLabel, new UnityEngine.Color(0.8f, 0.8f, 0.8f, 1f));
                }
                return _checkBoxCheckBoxLabel;
            }
        }

        #endregion
    }

    #endregion
}
