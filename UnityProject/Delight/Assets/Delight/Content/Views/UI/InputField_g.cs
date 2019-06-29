#if !DELIGHT_MODULE_TEXTMESHPRO

// Internal view logic generated from "InputField.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class InputField : UIImageView
    {
        #region Constructors

        public InputField(View parent, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :
            base(parent, layoutParent, id, template ?? InputFieldTemplates.Default, initializer)
        {
            // constructing Region (InputFieldPlaceholder)
            InputFieldPlaceholder = new Region(this, this, "InputFieldPlaceholder", InputFieldPlaceholderTemplate);

            // constructing RectMask2D (TextArea)
            TextArea = new RectMask2D(this, this, "TextArea", TextAreaTemplate);

            // binding <RectMask2D Margin="{TextMargin}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "TextMargin" }, new List<Func<BindableObject>> { () => this }) }, new BindingPath(new List<string> { "TextArea", "Margin" }, new List<Func<BindableObject>> { () => this, () => TextArea }), () => TextArea.Margin = TextMargin, () => { }, false));
            InputText = new Label(this, TextArea.Content, "InputText", InputTextTemplate);
            ContentContainer = InputFieldPlaceholder;
            this.AfterInitializeInternal();
        }

        public InputField() : this(null)
        {
        }

        static InputField()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(InputFieldTemplates.Default, dependencyProperties);

            dependencyProperties.Add(InputFieldComponentProperty);
            dependencyProperties.Add(SetValueOnEndEditProperty);
            dependencyProperties.Add(OnlyTriggerValueChangedFromUIProperty);
            dependencyProperties.Add(EndEditProperty);
            dependencyProperties.Add(ValueChangedProperty);
            dependencyProperties.Add(TextMarginProperty);
            dependencyProperties.Add(InputFieldPlaceholderProperty);
            dependencyProperties.Add(InputFieldPlaceholderTemplateProperty);
            dependencyProperties.Add(TextAreaProperty);
            dependencyProperties.Add(TextAreaTemplateProperty);
            dependencyProperties.Add(InputTextProperty);
            dependencyProperties.Add(InputTextTemplateProperty);
            dependencyProperties.Add(ShouldHideMobileInputProperty);
            dependencyProperties.Add(TextProperty);
            dependencyProperties.Add(CaretBlinkRateProperty);
            dependencyProperties.Add(CaretWidthProperty);
            dependencyProperties.Add(TextComponentProperty);
            dependencyProperties.Add(PlaceholderProperty);
            dependencyProperties.Add(CaretColorProperty);
            dependencyProperties.Add(CustomCaretColorProperty);
            dependencyProperties.Add(SelectionColorProperty);
            dependencyProperties.Add(OnEndEditProperty);
            dependencyProperties.Add(OnValueChangedProperty);
            dependencyProperties.Add(OnValidateInputProperty);
            dependencyProperties.Add(CharacterLimitProperty);
            dependencyProperties.Add(ContentTypeProperty);
            dependencyProperties.Add(LineTypeProperty);
            dependencyProperties.Add(InputTypeProperty);
            dependencyProperties.Add(KeyboardTypeProperty);
            dependencyProperties.Add(CharacterValidationProperty);
            dependencyProperties.Add(ReadOnlyProperty);
            dependencyProperties.Add(AsteriskCharProperty);
            dependencyProperties.Add(CaretPositionProperty);
            dependencyProperties.Add(SelectionAnchorPositionProperty);
            dependencyProperties.Add(SelectionFocusPositionProperty);
            dependencyProperties.Add(NavigationProperty);
            dependencyProperties.Add(TransitionProperty);
            dependencyProperties.Add(ColorsProperty);
            dependencyProperties.Add(SpriteStateProperty);
            dependencyProperties.Add(AnimationTriggersProperty);
            dependencyProperties.Add(TargetGraphicProperty);
            dependencyProperties.Add(InteractableProperty);
            dependencyProperties.Add(ImageProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<UnityEngine.UI.InputField> InputFieldComponentProperty = new DependencyProperty<UnityEngine.UI.InputField>("InputFieldComponent");
        public UnityEngine.UI.InputField InputFieldComponent
        {
            get { return InputFieldComponentProperty.GetValue(this); }
            set { InputFieldComponentProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> SetValueOnEndEditProperty = new DependencyProperty<System.Boolean>("SetValueOnEndEdit");
        public System.Boolean SetValueOnEndEdit
        {
            get { return SetValueOnEndEditProperty.GetValue(this); }
            set { SetValueOnEndEditProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> OnlyTriggerValueChangedFromUIProperty = new DependencyProperty<System.Boolean>("OnlyTriggerValueChangedFromUI");
        public System.Boolean OnlyTriggerValueChangedFromUI
        {
            get { return OnlyTriggerValueChangedFromUIProperty.GetValue(this); }
            set { OnlyTriggerValueChangedFromUIProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ViewAction> EndEditProperty = new DependencyProperty<ViewAction>("EndEdit");
        public ViewAction EndEdit
        {
            get { return EndEditProperty.GetValue(this); }
            set { EndEditProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ViewAction> ValueChangedProperty = new DependencyProperty<ViewAction>("ValueChanged");
        public ViewAction ValueChanged
        {
            get { return ValueChangedProperty.GetValue(this); }
            set { ValueChangedProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Delight.ElementMargin> TextMarginProperty = new DependencyProperty<Delight.ElementMargin>("TextMargin");
        public Delight.ElementMargin TextMargin
        {
            get { return TextMarginProperty.GetValue(this); }
            set { TextMarginProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> InputFieldPlaceholderProperty = new DependencyProperty<Region>("InputFieldPlaceholder");
        public Region InputFieldPlaceholder
        {
            get { return InputFieldPlaceholderProperty.GetValue(this); }
            set { InputFieldPlaceholderProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> InputFieldPlaceholderTemplateProperty = new DependencyProperty<Template>("InputFieldPlaceholderTemplate");
        public Template InputFieldPlaceholderTemplate
        {
            get { return InputFieldPlaceholderTemplateProperty.GetValue(this); }
            set { InputFieldPlaceholderTemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<RectMask2D> TextAreaProperty = new DependencyProperty<RectMask2D>("TextArea");
        public RectMask2D TextArea
        {
            get { return TextAreaProperty.GetValue(this); }
            set { TextAreaProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> TextAreaTemplateProperty = new DependencyProperty<Template>("TextAreaTemplate");
        public Template TextAreaTemplate
        {
            get { return TextAreaTemplateProperty.GetValue(this); }
            set { TextAreaTemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Label> InputTextProperty = new DependencyProperty<Label>("InputText");
        public Label InputText
        {
            get { return InputTextProperty.GetValue(this); }
            set { InputTextProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> InputTextTemplateProperty = new DependencyProperty<Template>("InputTextTemplate");
        public Template InputTextTemplate
        {
            get { return InputTextTemplateProperty.GetValue(this); }
            set { InputTextTemplateProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Boolean, UnityEngine.UI.InputField, InputField> ShouldHideMobileInputProperty = new MappedDependencyProperty<System.Boolean, UnityEngine.UI.InputField, InputField>("ShouldHideMobileInput", x => x.InputFieldComponent, x => x.shouldHideMobileInput, (x, y) => x.shouldHideMobileInput = y);
        public System.Boolean ShouldHideMobileInput
        {
            get { return ShouldHideMobileInputProperty.GetValue(this); }
            set { ShouldHideMobileInputProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.String, UnityEngine.UI.InputField, InputField> TextProperty = new MappedDependencyProperty<System.String, UnityEngine.UI.InputField, InputField>("Text", x => x.InputFieldComponent, x => x.text, (x, y) => x.text = y);
        public System.String Text
        {
            get { return TextProperty.GetValue(this); }
            set { TextProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Single, UnityEngine.UI.InputField, InputField> CaretBlinkRateProperty = new MappedDependencyProperty<System.Single, UnityEngine.UI.InputField, InputField>("CaretBlinkRate", x => x.InputFieldComponent, x => x.caretBlinkRate, (x, y) => x.caretBlinkRate = y);
        public System.Single CaretBlinkRate
        {
            get { return CaretBlinkRateProperty.GetValue(this); }
            set { CaretBlinkRateProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Int32, UnityEngine.UI.InputField, InputField> CaretWidthProperty = new MappedDependencyProperty<System.Int32, UnityEngine.UI.InputField, InputField>("CaretWidth", x => x.InputFieldComponent, x => x.caretWidth, (x, y) => x.caretWidth = y);
        public System.Int32 CaretWidth
        {
            get { return CaretWidthProperty.GetValue(this); }
            set { CaretWidthProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<UnityEngine.UI.Text, UnityEngine.UI.InputField, InputField> TextComponentProperty = new MappedDependencyProperty<UnityEngine.UI.Text, UnityEngine.UI.InputField, InputField>("TextComponent", x => x.InputFieldComponent, x => x.textComponent, (x, y) => x.textComponent = y);
        public UnityEngine.UI.Text TextComponent
        {
            get { return TextComponentProperty.GetValue(this); }
            set { TextComponentProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<UnityEngine.UI.Graphic, UnityEngine.UI.InputField, InputField> PlaceholderProperty = new MappedDependencyProperty<UnityEngine.UI.Graphic, UnityEngine.UI.InputField, InputField>("Placeholder", x => x.InputFieldComponent, x => x.placeholder, (x, y) => x.placeholder = y);
        public UnityEngine.UI.Graphic Placeholder
        {
            get { return PlaceholderProperty.GetValue(this); }
            set { PlaceholderProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<UnityEngine.Color, UnityEngine.UI.InputField, InputField> CaretColorProperty = new MappedDependencyProperty<UnityEngine.Color, UnityEngine.UI.InputField, InputField>("CaretColor", x => x.InputFieldComponent, x => x.caretColor, (x, y) => x.caretColor = y);
        public UnityEngine.Color CaretColor
        {
            get { return CaretColorProperty.GetValue(this); }
            set { CaretColorProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Boolean, UnityEngine.UI.InputField, InputField> CustomCaretColorProperty = new MappedDependencyProperty<System.Boolean, UnityEngine.UI.InputField, InputField>("CustomCaretColor", x => x.InputFieldComponent, x => x.customCaretColor, (x, y) => x.customCaretColor = y);
        public System.Boolean CustomCaretColor
        {
            get { return CustomCaretColorProperty.GetValue(this); }
            set { CustomCaretColorProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<UnityEngine.Color, UnityEngine.UI.InputField, InputField> SelectionColorProperty = new MappedDependencyProperty<UnityEngine.Color, UnityEngine.UI.InputField, InputField>("SelectionColor", x => x.InputFieldComponent, x => x.selectionColor, (x, y) => x.selectionColor = y);
        public UnityEngine.Color SelectionColor
        {
            get { return SelectionColorProperty.GetValue(this); }
            set { SelectionColorProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<UnityEngine.UI.InputField.SubmitEvent, UnityEngine.UI.InputField, InputField> OnEndEditProperty = new MappedDependencyProperty<UnityEngine.UI.InputField.SubmitEvent, UnityEngine.UI.InputField, InputField>("OnEndEdit", x => x.InputFieldComponent, x => x.onEndEdit, (x, y) => x.onEndEdit = y);
        public UnityEngine.UI.InputField.SubmitEvent OnEndEdit
        {
            get { return OnEndEditProperty.GetValue(this); }
            set { OnEndEditProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<UnityEngine.UI.InputField.OnChangeEvent, UnityEngine.UI.InputField, InputField> OnValueChangedProperty = new MappedDependencyProperty<UnityEngine.UI.InputField.OnChangeEvent, UnityEngine.UI.InputField, InputField>("OnValueChanged", x => x.InputFieldComponent, x => x.onValueChanged, (x, y) => x.onValueChanged = y);
        public UnityEngine.UI.InputField.OnChangeEvent OnValueChanged
        {
            get { return OnValueChangedProperty.GetValue(this); }
            set { OnValueChangedProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<UnityEngine.UI.InputField.OnValidateInput, UnityEngine.UI.InputField, InputField> OnValidateInputProperty = new MappedDependencyProperty<UnityEngine.UI.InputField.OnValidateInput, UnityEngine.UI.InputField, InputField>("OnValidateInput", x => x.InputFieldComponent, x => x.onValidateInput, (x, y) => x.onValidateInput = y);
        public UnityEngine.UI.InputField.OnValidateInput OnValidateInput
        {
            get { return OnValidateInputProperty.GetValue(this); }
            set { OnValidateInputProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Int32, UnityEngine.UI.InputField, InputField> CharacterLimitProperty = new MappedDependencyProperty<System.Int32, UnityEngine.UI.InputField, InputField>("CharacterLimit", x => x.InputFieldComponent, x => x.characterLimit, (x, y) => x.characterLimit = y);
        public System.Int32 CharacterLimit
        {
            get { return CharacterLimitProperty.GetValue(this); }
            set { CharacterLimitProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<UnityEngine.UI.InputField.ContentType, UnityEngine.UI.InputField, InputField> ContentTypeProperty = new MappedDependencyProperty<UnityEngine.UI.InputField.ContentType, UnityEngine.UI.InputField, InputField>("ContentType", x => x.InputFieldComponent, x => x.contentType, (x, y) => x.contentType = y);
        public UnityEngine.UI.InputField.ContentType ContentType
        {
            get { return ContentTypeProperty.GetValue(this); }
            set { ContentTypeProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<UnityEngine.UI.InputField.LineType, UnityEngine.UI.InputField, InputField> LineTypeProperty = new MappedDependencyProperty<UnityEngine.UI.InputField.LineType, UnityEngine.UI.InputField, InputField>("LineType", x => x.InputFieldComponent, x => x.lineType, (x, y) => x.lineType = y);
        public UnityEngine.UI.InputField.LineType LineType
        {
            get { return LineTypeProperty.GetValue(this); }
            set { LineTypeProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<UnityEngine.UI.InputField.InputType, UnityEngine.UI.InputField, InputField> InputTypeProperty = new MappedDependencyProperty<UnityEngine.UI.InputField.InputType, UnityEngine.UI.InputField, InputField>("InputType", x => x.InputFieldComponent, x => x.inputType, (x, y) => x.inputType = y);
        public UnityEngine.UI.InputField.InputType InputType
        {
            get { return InputTypeProperty.GetValue(this); }
            set { InputTypeProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<UnityEngine.TouchScreenKeyboardType, UnityEngine.UI.InputField, InputField> KeyboardTypeProperty = new MappedDependencyProperty<UnityEngine.TouchScreenKeyboardType, UnityEngine.UI.InputField, InputField>("KeyboardType", x => x.InputFieldComponent, x => x.keyboardType, (x, y) => x.keyboardType = y);
        public UnityEngine.TouchScreenKeyboardType KeyboardType
        {
            get { return KeyboardTypeProperty.GetValue(this); }
            set { KeyboardTypeProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<UnityEngine.UI.InputField.CharacterValidation, UnityEngine.UI.InputField, InputField> CharacterValidationProperty = new MappedDependencyProperty<UnityEngine.UI.InputField.CharacterValidation, UnityEngine.UI.InputField, InputField>("CharacterValidation", x => x.InputFieldComponent, x => x.characterValidation, (x, y) => x.characterValidation = y);
        public UnityEngine.UI.InputField.CharacterValidation CharacterValidation
        {
            get { return CharacterValidationProperty.GetValue(this); }
            set { CharacterValidationProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Boolean, UnityEngine.UI.InputField, InputField> ReadOnlyProperty = new MappedDependencyProperty<System.Boolean, UnityEngine.UI.InputField, InputField>("ReadOnly", x => x.InputFieldComponent, x => x.readOnly, (x, y) => x.readOnly = y);
        public System.Boolean ReadOnly
        {
            get { return ReadOnlyProperty.GetValue(this); }
            set { ReadOnlyProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Char, UnityEngine.UI.InputField, InputField> AsteriskCharProperty = new MappedDependencyProperty<System.Char, UnityEngine.UI.InputField, InputField>("AsteriskChar", x => x.InputFieldComponent, x => x.asteriskChar, (x, y) => x.asteriskChar = y);
        public System.Char AsteriskChar
        {
            get { return AsteriskCharProperty.GetValue(this); }
            set { AsteriskCharProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Int32, UnityEngine.UI.InputField, InputField> CaretPositionProperty = new MappedDependencyProperty<System.Int32, UnityEngine.UI.InputField, InputField>("CaretPosition", x => x.InputFieldComponent, x => x.caretPosition, (x, y) => x.caretPosition = y);
        public System.Int32 CaretPosition
        {
            get { return CaretPositionProperty.GetValue(this); }
            set { CaretPositionProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Int32, UnityEngine.UI.InputField, InputField> SelectionAnchorPositionProperty = new MappedDependencyProperty<System.Int32, UnityEngine.UI.InputField, InputField>("SelectionAnchorPosition", x => x.InputFieldComponent, x => x.selectionAnchorPosition, (x, y) => x.selectionAnchorPosition = y);
        public System.Int32 SelectionAnchorPosition
        {
            get { return SelectionAnchorPositionProperty.GetValue(this); }
            set { SelectionAnchorPositionProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Int32, UnityEngine.UI.InputField, InputField> SelectionFocusPositionProperty = new MappedDependencyProperty<System.Int32, UnityEngine.UI.InputField, InputField>("SelectionFocusPosition", x => x.InputFieldComponent, x => x.selectionFocusPosition, (x, y) => x.selectionFocusPosition = y);
        public System.Int32 SelectionFocusPosition
        {
            get { return SelectionFocusPositionProperty.GetValue(this); }
            set { SelectionFocusPositionProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<UnityEngine.UI.Navigation, UnityEngine.UI.InputField, InputField> NavigationProperty = new MappedDependencyProperty<UnityEngine.UI.Navigation, UnityEngine.UI.InputField, InputField>("Navigation", x => x.InputFieldComponent, x => x.navigation, (x, y) => x.navigation = y);
        public UnityEngine.UI.Navigation Navigation
        {
            get { return NavigationProperty.GetValue(this); }
            set { NavigationProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<UnityEngine.UI.Selectable.Transition, UnityEngine.UI.InputField, InputField> TransitionProperty = new MappedDependencyProperty<UnityEngine.UI.Selectable.Transition, UnityEngine.UI.InputField, InputField>("Transition", x => x.InputFieldComponent, x => x.transition, (x, y) => x.transition = y);
        public UnityEngine.UI.Selectable.Transition Transition
        {
            get { return TransitionProperty.GetValue(this); }
            set { TransitionProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<UnityEngine.UI.ColorBlock, UnityEngine.UI.InputField, InputField> ColorsProperty = new MappedDependencyProperty<UnityEngine.UI.ColorBlock, UnityEngine.UI.InputField, InputField>("Colors", x => x.InputFieldComponent, x => x.colors, (x, y) => x.colors = y);
        public UnityEngine.UI.ColorBlock Colors
        {
            get { return ColorsProperty.GetValue(this); }
            set { ColorsProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<UnityEngine.UI.SpriteState, UnityEngine.UI.InputField, InputField> SpriteStateProperty = new MappedDependencyProperty<UnityEngine.UI.SpriteState, UnityEngine.UI.InputField, InputField>("SpriteState", x => x.InputFieldComponent, x => x.spriteState, (x, y) => x.spriteState = y);
        public UnityEngine.UI.SpriteState SpriteState
        {
            get { return SpriteStateProperty.GetValue(this); }
            set { SpriteStateProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<UnityEngine.UI.AnimationTriggers, UnityEngine.UI.InputField, InputField> AnimationTriggersProperty = new MappedDependencyProperty<UnityEngine.UI.AnimationTriggers, UnityEngine.UI.InputField, InputField>("AnimationTriggers", x => x.InputFieldComponent, x => x.animationTriggers, (x, y) => x.animationTriggers = y);
        public UnityEngine.UI.AnimationTriggers AnimationTriggers
        {
            get { return AnimationTriggersProperty.GetValue(this); }
            set { AnimationTriggersProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<UnityEngine.UI.Graphic, UnityEngine.UI.InputField, InputField> TargetGraphicProperty = new MappedDependencyProperty<UnityEngine.UI.Graphic, UnityEngine.UI.InputField, InputField>("TargetGraphic", x => x.InputFieldComponent, x => x.targetGraphic, (x, y) => x.targetGraphic = y);
        public UnityEngine.UI.Graphic TargetGraphic
        {
            get { return TargetGraphicProperty.GetValue(this); }
            set { TargetGraphicProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Boolean, UnityEngine.UI.InputField, InputField> InteractableProperty = new MappedDependencyProperty<System.Boolean, UnityEngine.UI.InputField, InputField>("Interactable", x => x.InputFieldComponent, x => x.interactable, (x, y) => x.interactable = y);
        public System.Boolean Interactable
        {
            get { return InteractableProperty.GetValue(this); }
            set { InteractableProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<UnityEngine.UI.Image, UnityEngine.UI.InputField, InputField> ImageProperty = new MappedDependencyProperty<UnityEngine.UI.Image, UnityEngine.UI.InputField, InputField>("Image", x => x.InputFieldComponent, x => x.image, (x, y) => x.image = y);
        public UnityEngine.UI.Image Image
        {
            get { return ImageProperty.GetValue(this); }
            set { ImageProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty TextAlignmentProperty = Label.TextAlignmentProperty;
        public Delight.ElementAlignment TextAlignment
        {
            get { return InputText.TextAlignment; }
            set { InputText.TextAlignment = value; }
        }

        public readonly static DependencyProperty AutoSizeProperty = Label.AutoSizeProperty;
        public Delight.AutoSize AutoSize
        {
            get { return InputText.AutoSize; }
            set { InputText.AutoSize = value; }
        }

        public readonly static DependencyProperty FontProperty = Label.FontProperty;
        public FontAsset Font
        {
            get { return InputText.Font; }
            set { InputText.Font = value; }
        }

        public readonly static DependencyProperty InputTextTextProperty = Label.TextProperty;
        public System.String InputTextText
        {
            get { return InputText.Text; }
            set { InputText.Text = value; }
        }

        public readonly static DependencyProperty SupportRichTextProperty = Label.SupportRichTextProperty;
        public System.Boolean SupportRichText
        {
            get { return InputText.SupportRichText; }
            set { InputText.SupportRichText = value; }
        }

        public readonly static DependencyProperty ResizeTextForBestFitProperty = Label.ResizeTextForBestFitProperty;
        public System.Boolean ResizeTextForBestFit
        {
            get { return InputText.ResizeTextForBestFit; }
            set { InputText.ResizeTextForBestFit = value; }
        }

        public readonly static DependencyProperty ResizeTextMinSizeProperty = Label.ResizeTextMinSizeProperty;
        public System.Int32 ResizeTextMinSize
        {
            get { return InputText.ResizeTextMinSize; }
            set { InputText.ResizeTextMinSize = value; }
        }

        public readonly static DependencyProperty ResizeTextMaxSizeProperty = Label.ResizeTextMaxSizeProperty;
        public System.Int32 ResizeTextMaxSize
        {
            get { return InputText.ResizeTextMaxSize; }
            set { InputText.ResizeTextMaxSize = value; }
        }

        public readonly static DependencyProperty TextComponentTextAlignmentProperty = Label.TextComponentTextAlignmentProperty;
        public UnityEngine.TextAnchor TextComponentTextAlignment
        {
            get { return InputText.TextComponentTextAlignment; }
            set { InputText.TextComponentTextAlignment = value; }
        }

        public readonly static DependencyProperty AlignByGeometryProperty = Label.AlignByGeometryProperty;
        public System.Boolean AlignByGeometry
        {
            get { return InputText.AlignByGeometry; }
            set { InputText.AlignByGeometry = value; }
        }

        public readonly static DependencyProperty FontSizeProperty = Label.FontSizeProperty;
        public System.Int32 FontSize
        {
            get { return InputText.FontSize; }
            set { InputText.FontSize = value; }
        }

        public readonly static DependencyProperty HorizontalOverflowProperty = Label.HorizontalOverflowProperty;
        public UnityEngine.HorizontalWrapMode HorizontalOverflow
        {
            get { return InputText.HorizontalOverflow; }
            set { InputText.HorizontalOverflow = value; }
        }

        public readonly static DependencyProperty VerticalOverflowProperty = Label.VerticalOverflowProperty;
        public UnityEngine.VerticalWrapMode VerticalOverflow
        {
            get { return InputText.VerticalOverflow; }
            set { InputText.VerticalOverflow = value; }
        }

        public readonly static DependencyProperty LineSpacingProperty = Label.LineSpacingProperty;
        public System.Single LineSpacing
        {
            get { return InputText.LineSpacing; }
            set { InputText.LineSpacing = value; }
        }

        public readonly static DependencyProperty FontStyleProperty = Label.FontStyleProperty;
        public UnityEngine.FontStyle FontStyle
        {
            get { return InputText.FontStyle; }
            set { InputText.FontStyle = value; }
        }

        public readonly static DependencyProperty OnCullStateChangedProperty = Label.OnCullStateChangedProperty;
        public UnityEngine.UI.MaskableGraphic.CullStateChangedEvent OnCullStateChanged
        {
            get { return InputText.OnCullStateChanged; }
            set { InputText.OnCullStateChanged = value; }
        }

        public readonly static DependencyProperty MaskableProperty = Label.MaskableProperty;
        public System.Boolean Maskable
        {
            get { return InputText.Maskable; }
            set { InputText.Maskable = value; }
        }

        public readonly static DependencyProperty FontColorProperty = Label.FontColorProperty;
        public UnityEngine.Color FontColor
        {
            get { return InputText.FontColor; }
            set { InputText.FontColor = value; }
        }

        public readonly static DependencyProperty RaycastTargetProperty = Label.RaycastTargetProperty;
        public System.Boolean RaycastTarget
        {
            get { return InputText.RaycastTarget; }
            set { InputText.RaycastTarget = value; }
        }

        public readonly static DependencyProperty MaterialProperty = Label.MaterialProperty;
        public MaterialAsset Material
        {
            get { return InputText.Material; }
            set { InputText.Material = value; }
        }

        public readonly static DependencyProperty InputTextWidthProperty = Label.WidthProperty;
        public Delight.ElementSize InputTextWidth
        {
            get { return InputText.Width; }
            set { InputText.Width = value; }
        }

        public readonly static DependencyProperty InputTextHeightProperty = Label.HeightProperty;
        public Delight.ElementSize InputTextHeight
        {
            get { return InputText.Height; }
            set { InputText.Height = value; }
        }

        public readonly static DependencyProperty InputTextOverrideWidthProperty = Label.OverrideWidthProperty;
        public Delight.ElementSize InputTextOverrideWidth
        {
            get { return InputText.OverrideWidth; }
            set { InputText.OverrideWidth = value; }
        }

        public readonly static DependencyProperty InputTextOverrideHeightProperty = Label.OverrideHeightProperty;
        public Delight.ElementSize InputTextOverrideHeight
        {
            get { return InputText.OverrideHeight; }
            set { InputText.OverrideHeight = value; }
        }

        public readonly static DependencyProperty InputTextScaleProperty = Label.ScaleProperty;
        public UnityEngine.Vector3 InputTextScale
        {
            get { return InputText.Scale; }
            set { InputText.Scale = value; }
        }

        public readonly static DependencyProperty InputTextAlignmentProperty = Label.AlignmentProperty;
        public Delight.ElementAlignment InputTextAlignment
        {
            get { return InputText.Alignment; }
            set { InputText.Alignment = value; }
        }

        public readonly static DependencyProperty InputTextMarginProperty = Label.MarginProperty;
        public Delight.ElementMargin InputTextMargin
        {
            get { return InputText.Margin; }
            set { InputText.Margin = value; }
        }

        public readonly static DependencyProperty InputTextOffsetProperty = Label.OffsetProperty;
        public Delight.ElementMargin InputTextOffset
        {
            get { return InputText.Offset; }
            set { InputText.Offset = value; }
        }

        public readonly static DependencyProperty InputTextOffsetFromParentProperty = Label.OffsetFromParentProperty;
        public Delight.ElementMargin InputTextOffsetFromParent
        {
            get { return InputText.OffsetFromParent; }
            set { InputText.OffsetFromParent = value; }
        }

        public readonly static DependencyProperty InputTextPivotProperty = Label.PivotProperty;
        public UnityEngine.Vector2 InputTextPivot
        {
            get { return InputText.Pivot; }
            set { InputText.Pivot = value; }
        }

        public readonly static DependencyProperty InputTextLayoutRootProperty = Label.LayoutRootProperty;
        public Delight.LayoutRoot InputTextLayoutRoot
        {
            get { return InputText.LayoutRoot; }
            set { InputText.LayoutRoot = value; }
        }

        public readonly static DependencyProperty InputTextDisableLayoutUpdateProperty = Label.DisableLayoutUpdateProperty;
        public System.Boolean InputTextDisableLayoutUpdate
        {
            get { return InputText.DisableLayoutUpdate; }
            set { InputText.DisableLayoutUpdate = value; }
        }

        public readonly static DependencyProperty InputTextAlphaProperty = Label.AlphaProperty;
        public System.Single InputTextAlpha
        {
            get { return InputText.Alpha; }
            set { InputText.Alpha = value; }
        }

        public readonly static DependencyProperty InputTextIsVisibleProperty = Label.IsVisibleProperty;
        public System.Boolean InputTextIsVisible
        {
            get { return InputText.IsVisible; }
            set { InputText.IsVisible = value; }
        }

        public readonly static DependencyProperty InputTextRaycastBlockModeProperty = Label.RaycastBlockModeProperty;
        public Delight.RaycastBlockMode InputTextRaycastBlockMode
        {
            get { return InputText.RaycastBlockMode; }
            set { InputText.RaycastBlockMode = value; }
        }

        public readonly static DependencyProperty InputTextUseFastShaderProperty = Label.UseFastShaderProperty;
        public System.Boolean InputTextUseFastShader
        {
            get { return InputText.UseFastShader; }
            set { InputText.UseFastShader = value; }
        }

        public readonly static DependencyProperty InputTextBubbleNotifyChildLayoutChangedProperty = Label.BubbleNotifyChildLayoutChangedProperty;
        public System.Boolean InputTextBubbleNotifyChildLayoutChanged
        {
            get { return InputText.BubbleNotifyChildLayoutChanged; }
            set { InputText.BubbleNotifyChildLayoutChanged = value; }
        }

        public readonly static DependencyProperty InputTextIgnoreFlipProperty = Label.IgnoreFlipProperty;
        public System.Boolean InputTextIgnoreFlip
        {
            get { return InputText.IgnoreFlip; }
            set { InputText.IgnoreFlip = value; }
        }

        public readonly static DependencyProperty InputTextGameObjectProperty = Label.GameObjectProperty;
        public UnityEngine.GameObject InputTextGameObject
        {
            get { return InputText.GameObject; }
            set { InputText.GameObject = value; }
        }

        public readonly static DependencyProperty InputTextEnableScriptEventsProperty = Label.EnableScriptEventsProperty;
        public System.Boolean InputTextEnableScriptEvents
        {
            get { return InputText.EnableScriptEvents; }
            set { InputText.EnableScriptEvents = value; }
        }

        public readonly static DependencyProperty InputTextIgnoreObjectProperty = Label.IgnoreObjectProperty;
        public System.Boolean InputTextIgnoreObject
        {
            get { return InputText.IgnoreObject; }
            set { InputText.IgnoreObject = value; }
        }

        public readonly static DependencyProperty InputTextIsActiveProperty = Label.IsActiveProperty;
        public System.Boolean InputTextIsActive
        {
            get { return InputText.IsActive; }
            set { InputText.IsActive = value; }
        }

        public readonly static DependencyProperty InputTextLoadModeProperty = Label.LoadModeProperty;
        public Delight.LoadMode InputTextLoadMode
        {
            get { return InputText.LoadMode; }
            set { InputText.LoadMode = value; }
        }

        #endregion
    }

    #region Data Templates

    public static class InputFieldTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return InputField;
            }
        }

        private static Template _inputField;
        public static Template InputField
        {
            get
            {
#if UNITY_EDITOR
                if (_inputField == null || _inputField.CurrentVersion != Template.Version)
#else
                if (_inputField == null)
#endif
                {
                    _inputField = new Template(UIImageViewTemplates.UIImageView);
#if UNITY_EDITOR
                    _inputField.Name = "InputField";
#endif
                    Delight.InputField.WidthProperty.SetDefault(_inputField, new ElementSize(120f, ElementSizeUnit.Pixels));
                    Delight.InputField.HeightProperty.SetDefault(_inputField, new ElementSize(40f, ElementSizeUnit.Pixels));
                    Delight.InputField.TextMarginProperty.SetDefault(_inputField, new ElementMargin(new ElementSize(9f, ElementSizeUnit.Pixels)));
                    Delight.InputField.BackgroundColorProperty.SetDefault(_inputField, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.InputField.WidthProperty.SetDefault(_inputField, new ElementSize(400f, ElementSizeUnit.Pixels));
                    Delight.InputField.HeightProperty.SetDefault(_inputField, new ElementSize(50f, ElementSizeUnit.Pixels));
                    Delight.InputField.SelectionColorProperty.SetDefault(_inputField, new UnityEngine.Color(0.9372549f, 0.4392157f, 0.4156863f, 1f));
                    Delight.InputField.TextMarginProperty.SetDefault(_inputField, new ElementMargin(new ElementSize(10f, ElementSizeUnit.Pixels), new ElementSize(12f, ElementSizeUnit.Pixels), new ElementSize(10f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels)));
                    Delight.InputField.InputFieldPlaceholderTemplateProperty.SetDefault(_inputField, InputFieldInputFieldPlaceholder);
                    Delight.InputField.TextAreaTemplateProperty.SetDefault(_inputField, InputFieldTextArea);
                    Delight.InputField.InputTextTemplateProperty.SetDefault(_inputField, InputFieldInputText);
                }
                return _inputField;
            }
        }

        private static Template _inputFieldInputFieldPlaceholder;
        public static Template InputFieldInputFieldPlaceholder
        {
            get
            {
#if UNITY_EDITOR
                if (_inputFieldInputFieldPlaceholder == null || _inputFieldInputFieldPlaceholder.CurrentVersion != Template.Version)
#else
                if (_inputFieldInputFieldPlaceholder == null)
#endif
                {
                    _inputFieldInputFieldPlaceholder = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _inputFieldInputFieldPlaceholder.Name = "InputFieldInputFieldPlaceholder";
#endif
                }
                return _inputFieldInputFieldPlaceholder;
            }
        }

        private static Template _inputFieldTextArea;
        public static Template InputFieldTextArea
        {
            get
            {
#if UNITY_EDITOR
                if (_inputFieldTextArea == null || _inputFieldTextArea.CurrentVersion != Template.Version)
#else
                if (_inputFieldTextArea == null)
#endif
                {
                    _inputFieldTextArea = new Template(RectMask2DTemplates.RectMask2D);
#if UNITY_EDITOR
                    _inputFieldTextArea.Name = "InputFieldTextArea";
#endif
                    Delight.RectMask2D.MarginProperty.SetHasBinding(_inputFieldTextArea);
                }
                return _inputFieldTextArea;
            }
        }

        private static Template _inputFieldInputText;
        public static Template InputFieldInputText
        {
            get
            {
#if UNITY_EDITOR
                if (_inputFieldInputText == null || _inputFieldInputText.CurrentVersion != Template.Version)
#else
                if (_inputFieldInputText == null)
#endif
                {
                    _inputFieldInputText = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _inputFieldInputText.Name = "InputFieldInputText";
#endif
                    Delight.Label.WidthProperty.SetDefault(_inputFieldInputText, new ElementSize(1f, ElementSizeUnit.Percents));
                    Delight.Label.HeightProperty.SetDefault(_inputFieldInputText, new ElementSize(1f, ElementSizeUnit.Percents));
                    Delight.Label.TextAlignmentProperty.SetDefault(_inputFieldInputText, Delight.ElementAlignment.TopLeft);
                    Delight.Label.FontSizeProperty.SetDefault(_inputFieldInputText, 18);
                    Delight.Label.FontColorProperty.SetDefault(_inputFieldInputText, new UnityEngine.Color(0f, 0f, 0f, 1f));
                }
                return _inputFieldInputText;
            }
        }

        #endregion
    }

    #endregion
}

#endif
