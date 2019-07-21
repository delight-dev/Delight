#if DELIGHT_MODULE_TEXTMESHPRO

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

            dependencyProperties.Add(TMP_InputFieldComponentProperty);
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
            dependencyProperties.Add(ShouldHideSoftKeyboardProperty);
            dependencyProperties.Add(TextProperty);
            dependencyProperties.Add(CaretBlinkRateProperty);
            dependencyProperties.Add(CaretWidthProperty);
            dependencyProperties.Add(TextViewportProperty);
            dependencyProperties.Add(TextComponentProperty);
            dependencyProperties.Add(PlaceholderProperty);
            dependencyProperties.Add(VerticalScrollbarProperty);
            dependencyProperties.Add(ScrollSensitivityProperty);
            dependencyProperties.Add(CaretColorProperty);
            dependencyProperties.Add(CustomCaretColorProperty);
            dependencyProperties.Add(SelectionColorProperty);
            dependencyProperties.Add(OnEndEditProperty);
            dependencyProperties.Add(OnSubmitProperty);
            dependencyProperties.Add(OnSelectProperty);
            dependencyProperties.Add(OnDeselectProperty);
            dependencyProperties.Add(OnTextSelectionProperty);
            dependencyProperties.Add(OnEndTextSelectionProperty);
            dependencyProperties.Add(OnValueChangedProperty);
            dependencyProperties.Add(OnTouchScreenKeyboardStatusChangedProperty);
            dependencyProperties.Add(OnValidateInputProperty);
            dependencyProperties.Add(CharacterLimitProperty);
            dependencyProperties.Add(PointSizeProperty);
            dependencyProperties.Add(FontAssetProperty);
            dependencyProperties.Add(OnFocusSelectAllProperty);
            dependencyProperties.Add(ResetOnDeActivationProperty);
            dependencyProperties.Add(RestoreOriginalTextOnEscapeProperty);
            dependencyProperties.Add(IsRichTextEditingAllowedProperty);
            dependencyProperties.Add(ContentTypeProperty);
            dependencyProperties.Add(LineTypeProperty);
            dependencyProperties.Add(LineLimitProperty);
            dependencyProperties.Add(InputTypeProperty);
            dependencyProperties.Add(KeyboardTypeProperty);
            dependencyProperties.Add(CharacterValidationProperty);
            dependencyProperties.Add(InputValidatorProperty);
            dependencyProperties.Add(ReadOnlyProperty);
            dependencyProperties.Add(RichTextProperty);
            dependencyProperties.Add(AsteriskCharProperty);
            dependencyProperties.Add(CaretPositionProperty);
            dependencyProperties.Add(SelectionAnchorPositionProperty);
            dependencyProperties.Add(SelectionFocusPositionProperty);
            dependencyProperties.Add(StringPositionProperty);
            dependencyProperties.Add(SelectionStringAnchorPositionProperty);
            dependencyProperties.Add(SelectionStringFocusPositionProperty);
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

        public readonly static DependencyProperty<TMPro.TMP_InputField> TMP_InputFieldComponentProperty = new DependencyProperty<TMPro.TMP_InputField>("TMP_InputFieldComponent");
        public TMPro.TMP_InputField TMP_InputFieldComponent
        {
            get { return TMP_InputFieldComponentProperty.GetValue(this); }
            set { TMP_InputFieldComponentProperty.SetValue(this, value); }
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

        public readonly static DependencyProperty<ViewAction> EndEditProperty = new DependencyProperty<ViewAction>("EndEdit", () => new ViewAction());
        public ViewAction EndEdit
        {
            get { return EndEditProperty.GetValue(this); }
            set { EndEditProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ViewAction> ValueChangedProperty = new DependencyProperty<ViewAction>("ValueChanged", () => new ViewAction());
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

        public readonly static MappedDependencyProperty<System.Boolean, TMPro.TMP_InputField, InputField> ShouldHideMobileInputProperty = new MappedDependencyProperty<System.Boolean, TMPro.TMP_InputField, InputField>("ShouldHideMobileInput", x => x.TMP_InputFieldComponent, x => x.shouldHideMobileInput, (x, y) => x.shouldHideMobileInput = y);
        public System.Boolean ShouldHideMobileInput
        {
            get { return ShouldHideMobileInputProperty.GetValue(this); }
            set { ShouldHideMobileInputProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Boolean, TMPro.TMP_InputField, InputField> ShouldHideSoftKeyboardProperty = new MappedDependencyProperty<System.Boolean, TMPro.TMP_InputField, InputField>("ShouldHideSoftKeyboard", x => x.TMP_InputFieldComponent, x => x.shouldHideSoftKeyboard, (x, y) => x.shouldHideSoftKeyboard = y);
        public System.Boolean ShouldHideSoftKeyboard
        {
            get { return ShouldHideSoftKeyboardProperty.GetValue(this); }
            set { ShouldHideSoftKeyboardProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.String, TMPro.TMP_InputField, InputField> TextProperty = new MappedDependencyProperty<System.String, TMPro.TMP_InputField, InputField>("Text", x => x.TMP_InputFieldComponent, x => x.text, (x, y) => x.text = y);
        public System.String Text
        {
            get { return TextProperty.GetValue(this); }
            set { TextProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Single, TMPro.TMP_InputField, InputField> CaretBlinkRateProperty = new MappedDependencyProperty<System.Single, TMPro.TMP_InputField, InputField>("CaretBlinkRate", x => x.TMP_InputFieldComponent, x => x.caretBlinkRate, (x, y) => x.caretBlinkRate = y);
        public System.Single CaretBlinkRate
        {
            get { return CaretBlinkRateProperty.GetValue(this); }
            set { CaretBlinkRateProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Int32, TMPro.TMP_InputField, InputField> CaretWidthProperty = new MappedDependencyProperty<System.Int32, TMPro.TMP_InputField, InputField>("CaretWidth", x => x.TMP_InputFieldComponent, x => x.caretWidth, (x, y) => x.caretWidth = y);
        public System.Int32 CaretWidth
        {
            get { return CaretWidthProperty.GetValue(this); }
            set { CaretWidthProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<UnityEngine.RectTransform, TMPro.TMP_InputField, InputField> TextViewportProperty = new MappedDependencyProperty<UnityEngine.RectTransform, TMPro.TMP_InputField, InputField>("TextViewport", x => x.TMP_InputFieldComponent, x => x.textViewport, (x, y) => x.textViewport = y);
        public UnityEngine.RectTransform TextViewport
        {
            get { return TextViewportProperty.GetValue(this); }
            set { TextViewportProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<TMPro.TMP_Text, TMPro.TMP_InputField, InputField> TextComponentProperty = new MappedDependencyProperty<TMPro.TMP_Text, TMPro.TMP_InputField, InputField>("TextComponent", x => x.TMP_InputFieldComponent, x => x.textComponent, (x, y) => x.textComponent = y);
        public TMPro.TMP_Text TextComponent
        {
            get { return TextComponentProperty.GetValue(this); }
            set { TextComponentProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<UnityEngine.UI.Graphic, TMPro.TMP_InputField, InputField> PlaceholderProperty = new MappedDependencyProperty<UnityEngine.UI.Graphic, TMPro.TMP_InputField, InputField>("Placeholder", x => x.TMP_InputFieldComponent, x => x.placeholder, (x, y) => x.placeholder = y);
        public UnityEngine.UI.Graphic Placeholder
        {
            get { return PlaceholderProperty.GetValue(this); }
            set { PlaceholderProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<UnityEngine.UI.Scrollbar, TMPro.TMP_InputField, InputField> VerticalScrollbarProperty = new MappedDependencyProperty<UnityEngine.UI.Scrollbar, TMPro.TMP_InputField, InputField>("VerticalScrollbar", x => x.TMP_InputFieldComponent, x => x.verticalScrollbar, (x, y) => x.verticalScrollbar = y);
        public UnityEngine.UI.Scrollbar VerticalScrollbar
        {
            get { return VerticalScrollbarProperty.GetValue(this); }
            set { VerticalScrollbarProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Single, TMPro.TMP_InputField, InputField> ScrollSensitivityProperty = new MappedDependencyProperty<System.Single, TMPro.TMP_InputField, InputField>("ScrollSensitivity", x => x.TMP_InputFieldComponent, x => x.scrollSensitivity, (x, y) => x.scrollSensitivity = y);
        public System.Single ScrollSensitivity
        {
            get { return ScrollSensitivityProperty.GetValue(this); }
            set { ScrollSensitivityProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<UnityEngine.Color, TMPro.TMP_InputField, InputField> CaretColorProperty = new MappedDependencyProperty<UnityEngine.Color, TMPro.TMP_InputField, InputField>("CaretColor", x => x.TMP_InputFieldComponent, x => x.caretColor, (x, y) => x.caretColor = y);
        public UnityEngine.Color CaretColor
        {
            get { return CaretColorProperty.GetValue(this); }
            set { CaretColorProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Boolean, TMPro.TMP_InputField, InputField> CustomCaretColorProperty = new MappedDependencyProperty<System.Boolean, TMPro.TMP_InputField, InputField>("CustomCaretColor", x => x.TMP_InputFieldComponent, x => x.customCaretColor, (x, y) => x.customCaretColor = y);
        public System.Boolean CustomCaretColor
        {
            get { return CustomCaretColorProperty.GetValue(this); }
            set { CustomCaretColorProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<UnityEngine.Color, TMPro.TMP_InputField, InputField> SelectionColorProperty = new MappedDependencyProperty<UnityEngine.Color, TMPro.TMP_InputField, InputField>("SelectionColor", x => x.TMP_InputFieldComponent, x => x.selectionColor, (x, y) => x.selectionColor = y);
        public UnityEngine.Color SelectionColor
        {
            get { return SelectionColorProperty.GetValue(this); }
            set { SelectionColorProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<TMPro.TMP_InputField.SubmitEvent, TMPro.TMP_InputField, InputField> OnEndEditProperty = new MappedDependencyProperty<TMPro.TMP_InputField.SubmitEvent, TMPro.TMP_InputField, InputField>("OnEndEdit", x => x.TMP_InputFieldComponent, x => x.onEndEdit, (x, y) => x.onEndEdit = y);
        public TMPro.TMP_InputField.SubmitEvent OnEndEdit
        {
            get { return OnEndEditProperty.GetValue(this); }
            set { OnEndEditProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<TMPro.TMP_InputField.SubmitEvent, TMPro.TMP_InputField, InputField> OnSubmitProperty = new MappedDependencyProperty<TMPro.TMP_InputField.SubmitEvent, TMPro.TMP_InputField, InputField>("OnSubmit", x => x.TMP_InputFieldComponent, x => x.onSubmit, (x, y) => x.onSubmit = y);
        public TMPro.TMP_InputField.SubmitEvent OnSubmit
        {
            get { return OnSubmitProperty.GetValue(this); }
            set { OnSubmitProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<TMPro.TMP_InputField.SelectionEvent, TMPro.TMP_InputField, InputField> OnSelectProperty = new MappedDependencyProperty<TMPro.TMP_InputField.SelectionEvent, TMPro.TMP_InputField, InputField>("OnSelect", x => x.TMP_InputFieldComponent, x => x.onSelect, (x, y) => x.onSelect = y);
        public TMPro.TMP_InputField.SelectionEvent OnSelect
        {
            get { return OnSelectProperty.GetValue(this); }
            set { OnSelectProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<TMPro.TMP_InputField.SelectionEvent, TMPro.TMP_InputField, InputField> OnDeselectProperty = new MappedDependencyProperty<TMPro.TMP_InputField.SelectionEvent, TMPro.TMP_InputField, InputField>("OnDeselect", x => x.TMP_InputFieldComponent, x => x.onDeselect, (x, y) => x.onDeselect = y);
        public TMPro.TMP_InputField.SelectionEvent OnDeselect
        {
            get { return OnDeselectProperty.GetValue(this); }
            set { OnDeselectProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<TMPro.TMP_InputField.TextSelectionEvent, TMPro.TMP_InputField, InputField> OnTextSelectionProperty = new MappedDependencyProperty<TMPro.TMP_InputField.TextSelectionEvent, TMPro.TMP_InputField, InputField>("OnTextSelection", x => x.TMP_InputFieldComponent, x => x.onTextSelection, (x, y) => x.onTextSelection = y);
        public TMPro.TMP_InputField.TextSelectionEvent OnTextSelection
        {
            get { return OnTextSelectionProperty.GetValue(this); }
            set { OnTextSelectionProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<TMPro.TMP_InputField.TextSelectionEvent, TMPro.TMP_InputField, InputField> OnEndTextSelectionProperty = new MappedDependencyProperty<TMPro.TMP_InputField.TextSelectionEvent, TMPro.TMP_InputField, InputField>("OnEndTextSelection", x => x.TMP_InputFieldComponent, x => x.onEndTextSelection, (x, y) => x.onEndTextSelection = y);
        public TMPro.TMP_InputField.TextSelectionEvent OnEndTextSelection
        {
            get { return OnEndTextSelectionProperty.GetValue(this); }
            set { OnEndTextSelectionProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<TMPro.TMP_InputField.OnChangeEvent, TMPro.TMP_InputField, InputField> OnValueChangedProperty = new MappedDependencyProperty<TMPro.TMP_InputField.OnChangeEvent, TMPro.TMP_InputField, InputField>("OnValueChanged", x => x.TMP_InputFieldComponent, x => x.onValueChanged, (x, y) => x.onValueChanged = y);
        public TMPro.TMP_InputField.OnChangeEvent OnValueChanged
        {
            get { return OnValueChangedProperty.GetValue(this); }
            set { OnValueChangedProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<TMPro.TMP_InputField.TouchScreenKeyboardEvent, TMPro.TMP_InputField, InputField> OnTouchScreenKeyboardStatusChangedProperty = new MappedDependencyProperty<TMPro.TMP_InputField.TouchScreenKeyboardEvent, TMPro.TMP_InputField, InputField>("OnTouchScreenKeyboardStatusChanged", x => x.TMP_InputFieldComponent, x => x.onTouchScreenKeyboardStatusChanged, (x, y) => x.onTouchScreenKeyboardStatusChanged = y);
        public TMPro.TMP_InputField.TouchScreenKeyboardEvent OnTouchScreenKeyboardStatusChanged
        {
            get { return OnTouchScreenKeyboardStatusChangedProperty.GetValue(this); }
            set { OnTouchScreenKeyboardStatusChangedProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<TMPro.TMP_InputField.OnValidateInput, TMPro.TMP_InputField, InputField> OnValidateInputProperty = new MappedDependencyProperty<TMPro.TMP_InputField.OnValidateInput, TMPro.TMP_InputField, InputField>("OnValidateInput", x => x.TMP_InputFieldComponent, x => x.onValidateInput, (x, y) => x.onValidateInput = y);
        public TMPro.TMP_InputField.OnValidateInput OnValidateInput
        {
            get { return OnValidateInputProperty.GetValue(this); }
            set { OnValidateInputProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Int32, TMPro.TMP_InputField, InputField> CharacterLimitProperty = new MappedDependencyProperty<System.Int32, TMPro.TMP_InputField, InputField>("CharacterLimit", x => x.TMP_InputFieldComponent, x => x.characterLimit, (x, y) => x.characterLimit = y);
        public System.Int32 CharacterLimit
        {
            get { return CharacterLimitProperty.GetValue(this); }
            set { CharacterLimitProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Single, TMPro.TMP_InputField, InputField> PointSizeProperty = new MappedDependencyProperty<System.Single, TMPro.TMP_InputField, InputField>("PointSize", x => x.TMP_InputFieldComponent, x => x.pointSize, (x, y) => x.pointSize = y);
        public System.Single PointSize
        {
            get { return PointSizeProperty.GetValue(this); }
            set { PointSizeProperty.SetValue(this, value); }
        }

        public readonly static MappedAssetDependencyProperty<TMP_FontAsset, TMPro.TMP_InputField, InputField> FontAssetProperty = new MappedAssetDependencyProperty<TMP_FontAsset, TMPro.TMP_InputField, InputField>("FontAsset", x => x.TMP_InputFieldComponent, (x, y) => x.fontAsset = y?.UnityObject);
        public TMP_FontAsset FontAsset
        {
            get { return FontAssetProperty.GetValue(this); }
            set { FontAssetProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Boolean, TMPro.TMP_InputField, InputField> OnFocusSelectAllProperty = new MappedDependencyProperty<System.Boolean, TMPro.TMP_InputField, InputField>("OnFocusSelectAll", x => x.TMP_InputFieldComponent, x => x.onFocusSelectAll, (x, y) => x.onFocusSelectAll = y);
        public System.Boolean OnFocusSelectAll
        {
            get { return OnFocusSelectAllProperty.GetValue(this); }
            set { OnFocusSelectAllProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Boolean, TMPro.TMP_InputField, InputField> ResetOnDeActivationProperty = new MappedDependencyProperty<System.Boolean, TMPro.TMP_InputField, InputField>("ResetOnDeActivation", x => x.TMP_InputFieldComponent, x => x.resetOnDeActivation, (x, y) => x.resetOnDeActivation = y);
        public System.Boolean ResetOnDeActivation
        {
            get { return ResetOnDeActivationProperty.GetValue(this); }
            set { ResetOnDeActivationProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Boolean, TMPro.TMP_InputField, InputField> RestoreOriginalTextOnEscapeProperty = new MappedDependencyProperty<System.Boolean, TMPro.TMP_InputField, InputField>("RestoreOriginalTextOnEscape", x => x.TMP_InputFieldComponent, x => x.restoreOriginalTextOnEscape, (x, y) => x.restoreOriginalTextOnEscape = y);
        public System.Boolean RestoreOriginalTextOnEscape
        {
            get { return RestoreOriginalTextOnEscapeProperty.GetValue(this); }
            set { RestoreOriginalTextOnEscapeProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Boolean, TMPro.TMP_InputField, InputField> IsRichTextEditingAllowedProperty = new MappedDependencyProperty<System.Boolean, TMPro.TMP_InputField, InputField>("IsRichTextEditingAllowed", x => x.TMP_InputFieldComponent, x => x.isRichTextEditingAllowed, (x, y) => x.isRichTextEditingAllowed = y);
        public System.Boolean IsRichTextEditingAllowed
        {
            get { return IsRichTextEditingAllowedProperty.GetValue(this); }
            set { IsRichTextEditingAllowedProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<TMPro.TMP_InputField.ContentType, TMPro.TMP_InputField, InputField> ContentTypeProperty = new MappedDependencyProperty<TMPro.TMP_InputField.ContentType, TMPro.TMP_InputField, InputField>("ContentType", x => x.TMP_InputFieldComponent, x => x.contentType, (x, y) => x.contentType = y);
        public TMPro.TMP_InputField.ContentType ContentType
        {
            get { return ContentTypeProperty.GetValue(this); }
            set { ContentTypeProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<TMPro.TMP_InputField.LineType, TMPro.TMP_InputField, InputField> LineTypeProperty = new MappedDependencyProperty<TMPro.TMP_InputField.LineType, TMPro.TMP_InputField, InputField>("LineType", x => x.TMP_InputFieldComponent, x => x.lineType, (x, y) => x.lineType = y);
        public TMPro.TMP_InputField.LineType LineType
        {
            get { return LineTypeProperty.GetValue(this); }
            set { LineTypeProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Int32, TMPro.TMP_InputField, InputField> LineLimitProperty = new MappedDependencyProperty<System.Int32, TMPro.TMP_InputField, InputField>("LineLimit", x => x.TMP_InputFieldComponent, x => x.lineLimit, (x, y) => x.lineLimit = y);
        public System.Int32 LineLimit
        {
            get { return LineLimitProperty.GetValue(this); }
            set { LineLimitProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<TMPro.TMP_InputField.InputType, TMPro.TMP_InputField, InputField> InputTypeProperty = new MappedDependencyProperty<TMPro.TMP_InputField.InputType, TMPro.TMP_InputField, InputField>("InputType", x => x.TMP_InputFieldComponent, x => x.inputType, (x, y) => x.inputType = y);
        public TMPro.TMP_InputField.InputType InputType
        {
            get { return InputTypeProperty.GetValue(this); }
            set { InputTypeProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<UnityEngine.TouchScreenKeyboardType, TMPro.TMP_InputField, InputField> KeyboardTypeProperty = new MappedDependencyProperty<UnityEngine.TouchScreenKeyboardType, TMPro.TMP_InputField, InputField>("KeyboardType", x => x.TMP_InputFieldComponent, x => x.keyboardType, (x, y) => x.keyboardType = y);
        public UnityEngine.TouchScreenKeyboardType KeyboardType
        {
            get { return KeyboardTypeProperty.GetValue(this); }
            set { KeyboardTypeProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<TMPro.TMP_InputField.CharacterValidation, TMPro.TMP_InputField, InputField> CharacterValidationProperty = new MappedDependencyProperty<TMPro.TMP_InputField.CharacterValidation, TMPro.TMP_InputField, InputField>("CharacterValidation", x => x.TMP_InputFieldComponent, x => x.characterValidation, (x, y) => x.characterValidation = y);
        public TMPro.TMP_InputField.CharacterValidation CharacterValidation
        {
            get { return CharacterValidationProperty.GetValue(this); }
            set { CharacterValidationProperty.SetValue(this, value); }
        }

        public readonly static MappedAssetDependencyProperty<TMP_InputValidatorAsset, TMPro.TMP_InputField, InputField> InputValidatorProperty = new MappedAssetDependencyProperty<TMP_InputValidatorAsset, TMPro.TMP_InputField, InputField>("InputValidator", x => x.TMP_InputFieldComponent, (x, y) => x.inputValidator = y?.UnityObject);
        public TMP_InputValidatorAsset InputValidator
        {
            get { return InputValidatorProperty.GetValue(this); }
            set { InputValidatorProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Boolean, TMPro.TMP_InputField, InputField> ReadOnlyProperty = new MappedDependencyProperty<System.Boolean, TMPro.TMP_InputField, InputField>("ReadOnly", x => x.TMP_InputFieldComponent, x => x.readOnly, (x, y) => x.readOnly = y);
        public System.Boolean ReadOnly
        {
            get { return ReadOnlyProperty.GetValue(this); }
            set { ReadOnlyProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Boolean, TMPro.TMP_InputField, InputField> RichTextProperty = new MappedDependencyProperty<System.Boolean, TMPro.TMP_InputField, InputField>("RichText", x => x.TMP_InputFieldComponent, x => x.richText, (x, y) => x.richText = y);
        public System.Boolean RichText
        {
            get { return RichTextProperty.GetValue(this); }
            set { RichTextProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Char, TMPro.TMP_InputField, InputField> AsteriskCharProperty = new MappedDependencyProperty<System.Char, TMPro.TMP_InputField, InputField>("AsteriskChar", x => x.TMP_InputFieldComponent, x => x.asteriskChar, (x, y) => x.asteriskChar = y);
        public System.Char AsteriskChar
        {
            get { return AsteriskCharProperty.GetValue(this); }
            set { AsteriskCharProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Int32, TMPro.TMP_InputField, InputField> CaretPositionProperty = new MappedDependencyProperty<System.Int32, TMPro.TMP_InputField, InputField>("CaretPosition", x => x.TMP_InputFieldComponent, x => x.caretPosition, (x, y) => x.caretPosition = y);
        public System.Int32 CaretPosition
        {
            get { return CaretPositionProperty.GetValue(this); }
            set { CaretPositionProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Int32, TMPro.TMP_InputField, InputField> SelectionAnchorPositionProperty = new MappedDependencyProperty<System.Int32, TMPro.TMP_InputField, InputField>("SelectionAnchorPosition", x => x.TMP_InputFieldComponent, x => x.selectionAnchorPosition, (x, y) => x.selectionAnchorPosition = y);
        public System.Int32 SelectionAnchorPosition
        {
            get { return SelectionAnchorPositionProperty.GetValue(this); }
            set { SelectionAnchorPositionProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Int32, TMPro.TMP_InputField, InputField> SelectionFocusPositionProperty = new MappedDependencyProperty<System.Int32, TMPro.TMP_InputField, InputField>("SelectionFocusPosition", x => x.TMP_InputFieldComponent, x => x.selectionFocusPosition, (x, y) => x.selectionFocusPosition = y);
        public System.Int32 SelectionFocusPosition
        {
            get { return SelectionFocusPositionProperty.GetValue(this); }
            set { SelectionFocusPositionProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Int32, TMPro.TMP_InputField, InputField> StringPositionProperty = new MappedDependencyProperty<System.Int32, TMPro.TMP_InputField, InputField>("StringPosition", x => x.TMP_InputFieldComponent, x => x.stringPosition, (x, y) => x.stringPosition = y);
        public System.Int32 StringPosition
        {
            get { return StringPositionProperty.GetValue(this); }
            set { StringPositionProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Int32, TMPro.TMP_InputField, InputField> SelectionStringAnchorPositionProperty = new MappedDependencyProperty<System.Int32, TMPro.TMP_InputField, InputField>("SelectionStringAnchorPosition", x => x.TMP_InputFieldComponent, x => x.selectionStringAnchorPosition, (x, y) => x.selectionStringAnchorPosition = y);
        public System.Int32 SelectionStringAnchorPosition
        {
            get { return SelectionStringAnchorPositionProperty.GetValue(this); }
            set { SelectionStringAnchorPositionProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Int32, TMPro.TMP_InputField, InputField> SelectionStringFocusPositionProperty = new MappedDependencyProperty<System.Int32, TMPro.TMP_InputField, InputField>("SelectionStringFocusPosition", x => x.TMP_InputFieldComponent, x => x.selectionStringFocusPosition, (x, y) => x.selectionStringFocusPosition = y);
        public System.Int32 SelectionStringFocusPosition
        {
            get { return SelectionStringFocusPositionProperty.GetValue(this); }
            set { SelectionStringFocusPositionProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<UnityEngine.UI.Navigation, TMPro.TMP_InputField, InputField> NavigationProperty = new MappedDependencyProperty<UnityEngine.UI.Navigation, TMPro.TMP_InputField, InputField>("Navigation", x => x.TMP_InputFieldComponent, x => x.navigation, (x, y) => x.navigation = y);
        public UnityEngine.UI.Navigation Navigation
        {
            get { return NavigationProperty.GetValue(this); }
            set { NavigationProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<UnityEngine.UI.Selectable.Transition, TMPro.TMP_InputField, InputField> TransitionProperty = new MappedDependencyProperty<UnityEngine.UI.Selectable.Transition, TMPro.TMP_InputField, InputField>("Transition", x => x.TMP_InputFieldComponent, x => x.transition, (x, y) => x.transition = y);
        public UnityEngine.UI.Selectable.Transition Transition
        {
            get { return TransitionProperty.GetValue(this); }
            set { TransitionProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<UnityEngine.UI.ColorBlock, TMPro.TMP_InputField, InputField> ColorsProperty = new MappedDependencyProperty<UnityEngine.UI.ColorBlock, TMPro.TMP_InputField, InputField>("Colors", x => x.TMP_InputFieldComponent, x => x.colors, (x, y) => x.colors = y);
        public UnityEngine.UI.ColorBlock Colors
        {
            get { return ColorsProperty.GetValue(this); }
            set { ColorsProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<UnityEngine.UI.SpriteState, TMPro.TMP_InputField, InputField> SpriteStateProperty = new MappedDependencyProperty<UnityEngine.UI.SpriteState, TMPro.TMP_InputField, InputField>("SpriteState", x => x.TMP_InputFieldComponent, x => x.spriteState, (x, y) => x.spriteState = y);
        public UnityEngine.UI.SpriteState SpriteState
        {
            get { return SpriteStateProperty.GetValue(this); }
            set { SpriteStateProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<UnityEngine.UI.AnimationTriggers, TMPro.TMP_InputField, InputField> AnimationTriggersProperty = new MappedDependencyProperty<UnityEngine.UI.AnimationTriggers, TMPro.TMP_InputField, InputField>("AnimationTriggers", x => x.TMP_InputFieldComponent, x => x.animationTriggers, (x, y) => x.animationTriggers = y);
        public UnityEngine.UI.AnimationTriggers AnimationTriggers
        {
            get { return AnimationTriggersProperty.GetValue(this); }
            set { AnimationTriggersProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<UnityEngine.UI.Graphic, TMPro.TMP_InputField, InputField> TargetGraphicProperty = new MappedDependencyProperty<UnityEngine.UI.Graphic, TMPro.TMP_InputField, InputField>("TargetGraphic", x => x.TMP_InputFieldComponent, x => x.targetGraphic, (x, y) => x.targetGraphic = y);
        public UnityEngine.UI.Graphic TargetGraphic
        {
            get { return TargetGraphicProperty.GetValue(this); }
            set { TargetGraphicProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Boolean, TMPro.TMP_InputField, InputField> InteractableProperty = new MappedDependencyProperty<System.Boolean, TMPro.TMP_InputField, InputField>("Interactable", x => x.TMP_InputFieldComponent, x => x.interactable, (x, y) => x.interactable = y);
        public System.Boolean Interactable
        {
            get { return InteractableProperty.GetValue(this); }
            set { InteractableProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<UnityEngine.UI.Image, TMPro.TMP_InputField, InputField> ImageProperty = new MappedDependencyProperty<UnityEngine.UI.Image, TMPro.TMP_InputField, InputField>("Image", x => x.TMP_InputFieldComponent, x => x.image, (x, y) => x.image = y);
        public UnityEngine.UI.Image Image
        {
            get { return ImageProperty.GetValue(this); }
            set { ImageProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty AutoSizeProperty = Label.AutoSizeProperty;
        public Delight.AutoSize AutoSize
        {
            get { return InputText.AutoSize; }
            set { InputText.AutoSize = value; }
        }

        public readonly static DependencyProperty AutoSizeTextContainerProperty = Label.AutoSizeTextContainerProperty;
        public System.Boolean AutoSizeTextContainer
        {
            get { return InputText.AutoSizeTextContainer; }
            set { InputText.AutoSizeTextContainer = value; }
        }

        public readonly static DependencyProperty MaskOffsetProperty = Label.MaskOffsetProperty;
        public UnityEngine.Vector4 MaskOffset
        {
            get { return InputText.MaskOffset; }
            set { InputText.MaskOffset = value; }
        }

        public readonly static DependencyProperty InputTextTextProperty = Label.TextProperty;
        public System.String InputTextText
        {
            get { return InputText.Text; }
            set { InputText.Text = value; }
        }

        public readonly static DependencyProperty IsRightToLeftTextProperty = Label.IsRightToLeftTextProperty;
        public System.Boolean IsRightToLeftText
        {
            get { return InputText.IsRightToLeftText; }
            set { InputText.IsRightToLeftText = value; }
        }

        public readonly static DependencyProperty FontProperty = Label.FontProperty;
        public TMP_FontAsset Font
        {
            get { return InputText.Font; }
            set { InputText.Font = value; }
        }

        public readonly static DependencyProperty FontSharedMaterialProperty = Label.FontSharedMaterialProperty;
        public MaterialAsset FontSharedMaterial
        {
            get { return InputText.FontSharedMaterial; }
            set { InputText.FontSharedMaterial = value; }
        }

        public readonly static DependencyProperty FontSharedMaterialsProperty = Label.FontSharedMaterialsProperty;
        public UnityEngine.Material[] FontSharedMaterials
        {
            get { return InputText.FontSharedMaterials; }
            set { InputText.FontSharedMaterials = value; }
        }

        public readonly static DependencyProperty FontMaterialProperty = Label.FontMaterialProperty;
        public MaterialAsset FontMaterial
        {
            get { return InputText.FontMaterial; }
            set { InputText.FontMaterial = value; }
        }

        public readonly static DependencyProperty FontMaterialsProperty = Label.FontMaterialsProperty;
        public UnityEngine.Material[] FontMaterials
        {
            get { return InputText.FontMaterials; }
            set { InputText.FontMaterials = value; }
        }

        public readonly static DependencyProperty FontColorProperty = Label.FontColorProperty;
        public UnityEngine.Color FontColor
        {
            get { return InputText.FontColor; }
            set { InputText.FontColor = value; }
        }

        public readonly static DependencyProperty TextMeshProUGUIAlphaProperty = Label.TextMeshProUGUIAlphaProperty;
        public System.Single TextMeshProUGUIAlpha
        {
            get { return InputText.TextMeshProUGUIAlpha; }
            set { InputText.TextMeshProUGUIAlpha = value; }
        }

        public readonly static DependencyProperty EnableVertexGradientProperty = Label.EnableVertexGradientProperty;
        public System.Boolean EnableVertexGradient
        {
            get { return InputText.EnableVertexGradient; }
            set { InputText.EnableVertexGradient = value; }
        }

        public readonly static DependencyProperty ColorGradientProperty = Label.ColorGradientProperty;
        public TMPro.VertexGradient ColorGradient
        {
            get { return InputText.ColorGradient; }
            set { InputText.ColorGradient = value; }
        }

        public readonly static DependencyProperty ColorGradientPresetProperty = Label.ColorGradientPresetProperty;
        public TMP_ColorGradientAsset ColorGradientPreset
        {
            get { return InputText.ColorGradientPreset; }
            set { InputText.ColorGradientPreset = value; }
        }

        public readonly static DependencyProperty SpriteAssetProperty = Label.SpriteAssetProperty;
        public TMP_SpriteAsset SpriteAsset
        {
            get { return InputText.SpriteAsset; }
            set { InputText.SpriteAsset = value; }
        }

        public readonly static DependencyProperty TintAllSpritesProperty = Label.TintAllSpritesProperty;
        public System.Boolean TintAllSprites
        {
            get { return InputText.TintAllSprites; }
            set { InputText.TintAllSprites = value; }
        }

        public readonly static DependencyProperty OverrideColorTagsProperty = Label.OverrideColorTagsProperty;
        public System.Boolean OverrideColorTags
        {
            get { return InputText.OverrideColorTags; }
            set { InputText.OverrideColorTags = value; }
        }

        public readonly static DependencyProperty FaceColorProperty = Label.FaceColorProperty;
        public UnityEngine.Color32 FaceColor
        {
            get { return InputText.FaceColor; }
            set { InputText.FaceColor = value; }
        }

        public readonly static DependencyProperty OutlineColorProperty = Label.OutlineColorProperty;
        public UnityEngine.Color32 OutlineColor
        {
            get { return InputText.OutlineColor; }
            set { InputText.OutlineColor = value; }
        }

        public readonly static DependencyProperty OutlineWidthProperty = Label.OutlineWidthProperty;
        public System.Single OutlineWidth
        {
            get { return InputText.OutlineWidth; }
            set { InputText.OutlineWidth = value; }
        }

        public readonly static DependencyProperty FontSizeProperty = Label.FontSizeProperty;
        public System.Single FontSize
        {
            get { return InputText.FontSize; }
            set { InputText.FontSize = value; }
        }

        public readonly static DependencyProperty FontWeightProperty = Label.FontWeightProperty;
        public TMPro.FontWeight FontWeight
        {
            get { return InputText.FontWeight; }
            set { InputText.FontWeight = value; }
        }

        public readonly static DependencyProperty EnableAutoSizingProperty = Label.EnableAutoSizingProperty;
        public System.Boolean EnableAutoSizing
        {
            get { return InputText.EnableAutoSizing; }
            set { InputText.EnableAutoSizing = value; }
        }

        public readonly static DependencyProperty FontSizeMinProperty = Label.FontSizeMinProperty;
        public System.Single FontSizeMin
        {
            get { return InputText.FontSizeMin; }
            set { InputText.FontSizeMin = value; }
        }

        public readonly static DependencyProperty FontSizeMaxProperty = Label.FontSizeMaxProperty;
        public System.Single FontSizeMax
        {
            get { return InputText.FontSizeMax; }
            set { InputText.FontSizeMax = value; }
        }

        public readonly static DependencyProperty FontStyleProperty = Label.FontStyleProperty;
        public TMPro.FontStyles FontStyle
        {
            get { return InputText.FontStyle; }
            set { InputText.FontStyle = value; }
        }

        public readonly static DependencyProperty TextAlignmentProperty = Label.TextAlignmentProperty;
        public TMPro.TextAlignmentOptions TextAlignment
        {
            get { return InputText.TextAlignment; }
            set { InputText.TextAlignment = value; }
        }

        public readonly static DependencyProperty CharacterSpacingProperty = Label.CharacterSpacingProperty;
        public System.Single CharacterSpacing
        {
            get { return InputText.CharacterSpacing; }
            set { InputText.CharacterSpacing = value; }
        }

        public readonly static DependencyProperty WordSpacingProperty = Label.WordSpacingProperty;
        public System.Single WordSpacing
        {
            get { return InputText.WordSpacing; }
            set { InputText.WordSpacing = value; }
        }

        public readonly static DependencyProperty LineSpacingProperty = Label.LineSpacingProperty;
        public System.Single LineSpacing
        {
            get { return InputText.LineSpacing; }
            set { InputText.LineSpacing = value; }
        }

        public readonly static DependencyProperty LineSpacingAdjustmentProperty = Label.LineSpacingAdjustmentProperty;
        public System.Single LineSpacingAdjustment
        {
            get { return InputText.LineSpacingAdjustment; }
            set { InputText.LineSpacingAdjustment = value; }
        }

        public readonly static DependencyProperty ParagraphSpacingProperty = Label.ParagraphSpacingProperty;
        public System.Single ParagraphSpacing
        {
            get { return InputText.ParagraphSpacing; }
            set { InputText.ParagraphSpacing = value; }
        }

        public readonly static DependencyProperty CharacterWidthAdjustmentProperty = Label.CharacterWidthAdjustmentProperty;
        public System.Single CharacterWidthAdjustment
        {
            get { return InputText.CharacterWidthAdjustment; }
            set { InputText.CharacterWidthAdjustment = value; }
        }

        public readonly static DependencyProperty EnableWordWrappingProperty = Label.EnableWordWrappingProperty;
        public System.Boolean EnableWordWrapping
        {
            get { return InputText.EnableWordWrapping; }
            set { InputText.EnableWordWrapping = value; }
        }

        public readonly static DependencyProperty WordWrappingRatiosProperty = Label.WordWrappingRatiosProperty;
        public System.Single WordWrappingRatios
        {
            get { return InputText.WordWrappingRatios; }
            set { InputText.WordWrappingRatios = value; }
        }

        public readonly static DependencyProperty OverflowModeProperty = Label.OverflowModeProperty;
        public TMPro.TextOverflowModes OverflowMode
        {
            get { return InputText.OverflowMode; }
            set { InputText.OverflowMode = value; }
        }

        public readonly static DependencyProperty LinkedTextComponentProperty = Label.LinkedTextComponentProperty;
        public TMPro.TMP_Text LinkedTextComponent
        {
            get { return InputText.LinkedTextComponent; }
            set { InputText.LinkedTextComponent = value; }
        }

        public readonly static DependencyProperty IsLinkedTextComponentProperty = Label.IsLinkedTextComponentProperty;
        public System.Boolean IsLinkedTextComponent
        {
            get { return InputText.IsLinkedTextComponent; }
            set { InputText.IsLinkedTextComponent = value; }
        }

        public readonly static DependencyProperty EnableKerningProperty = Label.EnableKerningProperty;
        public System.Boolean EnableKerning
        {
            get { return InputText.EnableKerning; }
            set { InputText.EnableKerning = value; }
        }

        public readonly static DependencyProperty ExtraPaddingProperty = Label.ExtraPaddingProperty;
        public System.Boolean ExtraPadding
        {
            get { return InputText.ExtraPadding; }
            set { InputText.ExtraPadding = value; }
        }

        public readonly static DependencyProperty InputTextRichTextProperty = Label.RichTextProperty;
        public System.Boolean InputTextRichText
        {
            get { return InputText.RichText; }
            set { InputText.RichText = value; }
        }

        public readonly static DependencyProperty ParseCtrlCharactersProperty = Label.ParseCtrlCharactersProperty;
        public System.Boolean ParseCtrlCharacters
        {
            get { return InputText.ParseCtrlCharacters; }
            set { InputText.ParseCtrlCharacters = value; }
        }

        public readonly static DependencyProperty IsOverlayProperty = Label.IsOverlayProperty;
        public System.Boolean IsOverlay
        {
            get { return InputText.IsOverlay; }
            set { InputText.IsOverlay = value; }
        }

        public readonly static DependencyProperty IsOrthographicProperty = Label.IsOrthographicProperty;
        public System.Boolean IsOrthographic
        {
            get { return InputText.IsOrthographic; }
            set { InputText.IsOrthographic = value; }
        }

        public readonly static DependencyProperty EnableCullingProperty = Label.EnableCullingProperty;
        public System.Boolean EnableCulling
        {
            get { return InputText.EnableCulling; }
            set { InputText.EnableCulling = value; }
        }

        public readonly static DependencyProperty IgnoreRectMaskCullingProperty = Label.IgnoreRectMaskCullingProperty;
        public System.Boolean IgnoreRectMaskCulling
        {
            get { return InputText.IgnoreRectMaskCulling; }
            set { InputText.IgnoreRectMaskCulling = value; }
        }

        public readonly static DependencyProperty IgnoreVisibilityProperty = Label.IgnoreVisibilityProperty;
        public System.Boolean IgnoreVisibility
        {
            get { return InputText.IgnoreVisibility; }
            set { InputText.IgnoreVisibility = value; }
        }

        public readonly static DependencyProperty HorizontalMappingProperty = Label.HorizontalMappingProperty;
        public TMPro.TextureMappingOptions HorizontalMapping
        {
            get { return InputText.HorizontalMapping; }
            set { InputText.HorizontalMapping = value; }
        }

        public readonly static DependencyProperty VerticalMappingProperty = Label.VerticalMappingProperty;
        public TMPro.TextureMappingOptions VerticalMapping
        {
            get { return InputText.VerticalMapping; }
            set { InputText.VerticalMapping = value; }
        }

        public readonly static DependencyProperty MappingUvLineOffsetProperty = Label.MappingUvLineOffsetProperty;
        public System.Single MappingUvLineOffset
        {
            get { return InputText.MappingUvLineOffset; }
            set { InputText.MappingUvLineOffset = value; }
        }

        public readonly static DependencyProperty RenderModeProperty = Label.RenderModeProperty;
        public TMPro.TextRenderFlags RenderMode
        {
            get { return InputText.RenderMode; }
            set { InputText.RenderMode = value; }
        }

        public readonly static DependencyProperty GeometrySortingOrderProperty = Label.GeometrySortingOrderProperty;
        public TMPro.VertexSortingOrder GeometrySortingOrder
        {
            get { return InputText.GeometrySortingOrder; }
            set { InputText.GeometrySortingOrder = value; }
        }

        public readonly static DependencyProperty VertexBufferAutoSizeReductionProperty = Label.VertexBufferAutoSizeReductionProperty;
        public System.Boolean VertexBufferAutoSizeReduction
        {
            get { return InputText.VertexBufferAutoSizeReduction; }
            set { InputText.VertexBufferAutoSizeReduction = value; }
        }

        public readonly static DependencyProperty FirstVisibleCharacterProperty = Label.FirstVisibleCharacterProperty;
        public System.Int32 FirstVisibleCharacter
        {
            get { return InputText.FirstVisibleCharacter; }
            set { InputText.FirstVisibleCharacter = value; }
        }

        public readonly static DependencyProperty MaxVisibleCharactersProperty = Label.MaxVisibleCharactersProperty;
        public System.Int32 MaxVisibleCharacters
        {
            get { return InputText.MaxVisibleCharacters; }
            set { InputText.MaxVisibleCharacters = value; }
        }

        public readonly static DependencyProperty MaxVisibleWordsProperty = Label.MaxVisibleWordsProperty;
        public System.Int32 MaxVisibleWords
        {
            get { return InputText.MaxVisibleWords; }
            set { InputText.MaxVisibleWords = value; }
        }

        public readonly static DependencyProperty MaxVisibleLinesProperty = Label.MaxVisibleLinesProperty;
        public System.Int32 MaxVisibleLines
        {
            get { return InputText.MaxVisibleLines; }
            set { InputText.MaxVisibleLines = value; }
        }

        public readonly static DependencyProperty UseMaxVisibleDescenderProperty = Label.UseMaxVisibleDescenderProperty;
        public System.Boolean UseMaxVisibleDescender
        {
            get { return InputText.UseMaxVisibleDescender; }
            set { InputText.UseMaxVisibleDescender = value; }
        }

        public readonly static DependencyProperty PageToDisplayProperty = Label.PageToDisplayProperty;
        public System.Int32 PageToDisplay
        {
            get { return InputText.PageToDisplay; }
            set { InputText.PageToDisplay = value; }
        }

        public readonly static DependencyProperty InputTextTextMarginProperty = Label.TextMarginProperty;
        public UnityEngine.Vector4 InputTextTextMargin
        {
            get { return InputText.TextMargin; }
            set { InputText.TextMargin = value; }
        }

        public readonly static DependencyProperty HavePropertiesChangedProperty = Label.HavePropertiesChangedProperty;
        public System.Boolean HavePropertiesChanged
        {
            get { return InputText.HavePropertiesChanged; }
            set { InputText.HavePropertiesChanged = value; }
        }

        public readonly static DependencyProperty IsUsingLegacyAnimationComponentProperty = Label.IsUsingLegacyAnimationComponentProperty;
        public System.Boolean IsUsingLegacyAnimationComponent
        {
            get { return InputText.IsUsingLegacyAnimationComponent; }
            set { InputText.IsUsingLegacyAnimationComponent = value; }
        }

        public readonly static DependencyProperty IsVolumetricTextProperty = Label.IsVolumetricTextProperty;
        public System.Boolean IsVolumetricText
        {
            get { return InputText.IsVolumetricText; }
            set { InputText.IsVolumetricText = value; }
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
                    Delight.Label.TextAlignmentProperty.SetDefault(_inputFieldInputText, TMPro.TextAlignmentOptions.TopLeft);
                    Delight.Label.FontSizeProperty.SetDefault(_inputFieldInputText, 18f);
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
