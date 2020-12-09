#if DELIGHT_MODULE_PLAYFAB

// Internal view logic generated from "PlayFabRegister.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class PlayFabRegister : UIView
    {
        #region Constructors

        public PlayFabRegister(View parent, View layoutParent = null, string id = null, Template template = null, bool deferInitialization = false) :
            base(parent, layoutParent, id, template ?? PlayFabRegisterTemplates.Default, deferInitialization)
        {
            if (deferInitialization)
                return;

            // constructing Grid (Grid1)
            Grid1 = new LayoutGrid(this, this, "Grid1", Grid1Template);
            Region1 = new Region(this, Grid1.Content, "Region1", Region1Template);
            Grid1.Cell.SetValue(Region1, new CellIndex(0, 0));
            Group1 = new Group(this, Region1.Content, "Group1", Group1Template);
            Label1 = new Label(this, Group1.Content, "Label1", Label1Template);
            Label2 = new Label(this, Group1.Content, "Label2", Label2Template);
            InputField1 = new InputField(this, Group1.Content, "InputField1", InputField1Template);

            // binding <InputField Text="{@PlayFabRegistrationForm.Email}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "Email" }, new List<Func<object>> { () => Models.PlayFabRegistrationForm }) }, new BindingPath(new List<string> { "InputField1", "Text" }, new List<Func<object>> { () => this, () => InputField1 }), () => InputField1.Text = Models.PlayFabRegistrationForm.Email, () => Models.PlayFabRegistrationForm.Email = InputField1.Text, true));
            Label3 = new Label(this, Group1.Content, "Label3", Label3Template);
            InputField2 = new InputField(this, Group1.Content, "InputField2", InputField2Template);

            // binding <InputField Text="{@PlayFabRegistrationForm.Password}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "Password" }, new List<Func<object>> { () => Models.PlayFabRegistrationForm }) }, new BindingPath(new List<string> { "InputField2", "Text" }, new List<Func<object>> { () => this, () => InputField2 }), () => InputField2.Text = Models.PlayFabRegistrationForm.Password, () => Models.PlayFabRegistrationForm.Password = InputField2.Text, true));
            Button1 = new Button(this, Group1.Content, "Button1", Button1Template);
            Button1.Click.RegisterHandler(this, "Register");

            // binding <Button IsDisabled="{@PlayFabRegistrationForm.IsRegistering}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "IsRegistering" }, new List<Func<object>> { () => Models.PlayFabRegistrationForm }) }, new BindingPath(new List<string> { "Button1", "IsDisabled" }, new List<Func<object>> { () => this, () => Button1 }), () => Button1.IsDisabled = Models.PlayFabRegistrationForm.IsRegistering, () => { }, false));
            Label4 = new Label(this, Group1.Content, "Label4", Label4Template);

            // binding <Label Text="{@PlayFabRegistrationForm.RegistrationMessage}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "RegistrationMessage" }, new List<Func<object>> { () => Models.PlayFabRegistrationForm }) }, new BindingPath(new List<string> { "Label4", "Text" }, new List<Func<object>> { () => this, () => Label4 }), () => Label4.Text = Models.PlayFabRegistrationForm.RegistrationMessage, () => { }, false));

            // binding <Label IsVisible="{@PlayFabRegistrationForm.ShowRegistrationMessage}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "ShowRegistrationMessage" }, new List<Func<object>> { () => Models.PlayFabRegistrationForm }) }, new BindingPath(new List<string> { "Label4", "IsVisible" }, new List<Func<object>> { () => this, () => Label4 }), () => Label4.IsVisible = Models.PlayFabRegistrationForm.ShowRegistrationMessage, () => { }, false));
            this.AfterInitializeInternal();
        }

        public PlayFabRegister() : this(null)
        {
        }

        static PlayFabRegister()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(PlayFabRegisterTemplates.Default, dependencyProperties);

            dependencyProperties.Add(Grid1Property);
            dependencyProperties.Add(Grid1TemplateProperty);
            dependencyProperties.Add(Region1Property);
            dependencyProperties.Add(Region1TemplateProperty);
            dependencyProperties.Add(Group1Property);
            dependencyProperties.Add(Group1TemplateProperty);
            dependencyProperties.Add(Label1Property);
            dependencyProperties.Add(Label1TemplateProperty);
            dependencyProperties.Add(Label2Property);
            dependencyProperties.Add(Label2TemplateProperty);
            dependencyProperties.Add(InputField1Property);
            dependencyProperties.Add(InputField1TemplateProperty);
            dependencyProperties.Add(Label3Property);
            dependencyProperties.Add(Label3TemplateProperty);
            dependencyProperties.Add(InputField2Property);
            dependencyProperties.Add(InputField2TemplateProperty);
            dependencyProperties.Add(Button1Property);
            dependencyProperties.Add(Button1TemplateProperty);
            dependencyProperties.Add(Label4Property);
            dependencyProperties.Add(Label4TemplateProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<LayoutGrid> Grid1Property = new DependencyProperty<LayoutGrid>("Grid1");
        public LayoutGrid Grid1
        {
            get { return Grid1Property.GetValue(this); }
            set { Grid1Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Grid1TemplateProperty = new DependencyProperty<Template>("Grid1Template");
        public Template Grid1Template
        {
            get { return Grid1TemplateProperty.GetValue(this); }
            set { Grid1TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> Region1Property = new DependencyProperty<Region>("Region1");
        public Region Region1
        {
            get { return Region1Property.GetValue(this); }
            set { Region1Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Region1TemplateProperty = new DependencyProperty<Template>("Region1Template");
        public Template Region1Template
        {
            get { return Region1TemplateProperty.GetValue(this); }
            set { Region1TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Group> Group1Property = new DependencyProperty<Group>("Group1");
        public Group Group1
        {
            get { return Group1Property.GetValue(this); }
            set { Group1Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Group1TemplateProperty = new DependencyProperty<Template>("Group1Template");
        public Template Group1Template
        {
            get { return Group1TemplateProperty.GetValue(this); }
            set { Group1TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Label> Label1Property = new DependencyProperty<Label>("Label1");
        public Label Label1
        {
            get { return Label1Property.GetValue(this); }
            set { Label1Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Label1TemplateProperty = new DependencyProperty<Template>("Label1Template");
        public Template Label1Template
        {
            get { return Label1TemplateProperty.GetValue(this); }
            set { Label1TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Label> Label2Property = new DependencyProperty<Label>("Label2");
        public Label Label2
        {
            get { return Label2Property.GetValue(this); }
            set { Label2Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Label2TemplateProperty = new DependencyProperty<Template>("Label2Template");
        public Template Label2Template
        {
            get { return Label2TemplateProperty.GetValue(this); }
            set { Label2TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<InputField> InputField1Property = new DependencyProperty<InputField>("InputField1");
        public InputField InputField1
        {
            get { return InputField1Property.GetValue(this); }
            set { InputField1Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> InputField1TemplateProperty = new DependencyProperty<Template>("InputField1Template");
        public Template InputField1Template
        {
            get { return InputField1TemplateProperty.GetValue(this); }
            set { InputField1TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Label> Label3Property = new DependencyProperty<Label>("Label3");
        public Label Label3
        {
            get { return Label3Property.GetValue(this); }
            set { Label3Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Label3TemplateProperty = new DependencyProperty<Template>("Label3Template");
        public Template Label3Template
        {
            get { return Label3TemplateProperty.GetValue(this); }
            set { Label3TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<InputField> InputField2Property = new DependencyProperty<InputField>("InputField2");
        public InputField InputField2
        {
            get { return InputField2Property.GetValue(this); }
            set { InputField2Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> InputField2TemplateProperty = new DependencyProperty<Template>("InputField2Template");
        public Template InputField2Template
        {
            get { return InputField2TemplateProperty.GetValue(this); }
            set { InputField2TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Button> Button1Property = new DependencyProperty<Button>("Button1");
        public Button Button1
        {
            get { return Button1Property.GetValue(this); }
            set { Button1Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Button1TemplateProperty = new DependencyProperty<Template>("Button1Template");
        public Template Button1Template
        {
            get { return Button1TemplateProperty.GetValue(this); }
            set { Button1TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Label> Label4Property = new DependencyProperty<Label>("Label4");
        public Label Label4
        {
            get { return Label4Property.GetValue(this); }
            set { Label4Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Label4TemplateProperty = new DependencyProperty<Template>("Label4Template");
        public Template Label4Template
        {
            get { return Label4TemplateProperty.GetValue(this); }
            set { Label4TemplateProperty.SetValue(this, value); }
        }

        #endregion
    }

    #region Data Templates

    public static class PlayFabRegisterTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return PlayFabRegister;
            }
        }

        private static Template _playFabRegister;
        public static Template PlayFabRegister
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabRegister == null || _playFabRegister.CurrentVersion != Template.Version)
#else
                if (_playFabRegister == null)
#endif
                {
                    _playFabRegister = new Template(UIViewTemplates.UIView);
#if UNITY_EDITOR
                    _playFabRegister.Name = "PlayFabRegister";
                    _playFabRegister.LineNumber = 0;
                    _playFabRegister.LinePosition = 0;
#endif
                    Delight.PlayFabRegister.Grid1TemplateProperty.SetDefault(_playFabRegister, PlayFabRegisterGrid1);
                    Delight.PlayFabRegister.Region1TemplateProperty.SetDefault(_playFabRegister, PlayFabRegisterRegion1);
                    Delight.PlayFabRegister.Group1TemplateProperty.SetDefault(_playFabRegister, PlayFabRegisterGroup1);
                    Delight.PlayFabRegister.Label1TemplateProperty.SetDefault(_playFabRegister, PlayFabRegisterLabel1);
                    Delight.PlayFabRegister.Label2TemplateProperty.SetDefault(_playFabRegister, PlayFabRegisterLabel2);
                    Delight.PlayFabRegister.InputField1TemplateProperty.SetDefault(_playFabRegister, PlayFabRegisterInputField1);
                    Delight.PlayFabRegister.Label3TemplateProperty.SetDefault(_playFabRegister, PlayFabRegisterLabel3);
                    Delight.PlayFabRegister.InputField2TemplateProperty.SetDefault(_playFabRegister, PlayFabRegisterInputField2);
                    Delight.PlayFabRegister.Button1TemplateProperty.SetDefault(_playFabRegister, PlayFabRegisterButton1);
                    Delight.PlayFabRegister.Label4TemplateProperty.SetDefault(_playFabRegister, PlayFabRegisterLabel4);
                }
                return _playFabRegister;
            }
        }

        private static Template _playFabRegisterGrid1;
        public static Template PlayFabRegisterGrid1
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabRegisterGrid1 == null || _playFabRegisterGrid1.CurrentVersion != Template.Version)
#else
                if (_playFabRegisterGrid1 == null)
#endif
                {
                    _playFabRegisterGrid1 = new Template(LayoutGridTemplates.LayoutGrid);
#if UNITY_EDITOR
                    _playFabRegisterGrid1.Name = "PlayFabRegisterGrid1";
                    _playFabRegisterGrid1.LineNumber = 4;
                    _playFabRegisterGrid1.LinePosition = 4;
#endif
                    Delight.LayoutGrid.ColumnsProperty.SetDefault(_playFabRegisterGrid1, new ColumnDefinitions { new ColumnDefinition(new ElementSize(1f, ElementSizeUnit.Proportional)), new ColumnDefinition(new ElementSize(1f, ElementSizeUnit.Proportional))});
                }
                return _playFabRegisterGrid1;
            }
        }

        private static Template _playFabRegisterRegion1;
        public static Template PlayFabRegisterRegion1
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabRegisterRegion1 == null || _playFabRegisterRegion1.CurrentVersion != Template.Version)
#else
                if (_playFabRegisterRegion1 == null)
#endif
                {
                    _playFabRegisterRegion1 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _playFabRegisterRegion1.Name = "PlayFabRegisterRegion1";
                    _playFabRegisterRegion1.LineNumber = 7;
                    _playFabRegisterRegion1.LinePosition = 6;
#endif
                    Delight.Region.MarginProperty.SetDefault(_playFabRegisterRegion1, new ElementMargin(new ElementSize(10f, ElementSizeUnit.Pixels)));
                }
                return _playFabRegisterRegion1;
            }
        }

        private static Template _playFabRegisterGroup1;
        public static Template PlayFabRegisterGroup1
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabRegisterGroup1 == null || _playFabRegisterGroup1.CurrentVersion != Template.Version)
#else
                if (_playFabRegisterGroup1 == null)
#endif
                {
                    _playFabRegisterGroup1 = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _playFabRegisterGroup1.Name = "PlayFabRegisterGroup1";
                    _playFabRegisterGroup1.LineNumber = 8;
                    _playFabRegisterGroup1.LinePosition = 8;
#endif
                    Delight.Group.SpacingProperty.SetDefault(_playFabRegisterGroup1, new ElementSize(5f, ElementSizeUnit.Pixels));
                    Delight.Group.AlignmentProperty.SetDefault(_playFabRegisterGroup1, Delight.ElementAlignment.TopLeft);
                }
                return _playFabRegisterGroup1;
            }
        }

        private static Template _playFabRegisterLabel1;
        public static Template PlayFabRegisterLabel1
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabRegisterLabel1 == null || _playFabRegisterLabel1.CurrentVersion != Template.Version)
#else
                if (_playFabRegisterLabel1 == null)
#endif
                {
                    _playFabRegisterLabel1 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _playFabRegisterLabel1.Name = "PlayFabRegisterLabel1";
                    _playFabRegisterLabel1.LineNumber = 9;
                    _playFabRegisterLabel1.LinePosition = 10;
#endif
                    Delight.Label.TextProperty.SetDefault(_playFabRegisterLabel1, "Register");
                    Delight.Label.AutoSizeProperty.SetDefault(_playFabRegisterLabel1, Delight.AutoSize.Default);
                    Delight.Label.FontSizeProperty.SetDefault(_playFabRegisterLabel1, 30f);
                    Delight.Label.FontColorProperty.SetDefault(_playFabRegisterLabel1, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Label.FontProperty.SetDefault(_playFabRegisterLabel1, Assets.TMP_FontAssets["Segoe UI SDF"]);
                    Delight.Label.AlignmentProperty.SetDefault(_playFabRegisterLabel1, Delight.ElementAlignment.Left);
                }
                return _playFabRegisterLabel1;
            }
        }

        private static Template _playFabRegisterLabel2;
        public static Template PlayFabRegisterLabel2
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabRegisterLabel2 == null || _playFabRegisterLabel2.CurrentVersion != Template.Version)
#else
                if (_playFabRegisterLabel2 == null)
#endif
                {
                    _playFabRegisterLabel2 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _playFabRegisterLabel2.Name = "PlayFabRegisterLabel2";
                    _playFabRegisterLabel2.LineNumber = 10;
                    _playFabRegisterLabel2.LinePosition = 10;
#endif
                    Delight.Label.TextProperty.SetDefault(_playFabRegisterLabel2, "Email");
                    Delight.Label.AutoSizeProperty.SetDefault(_playFabRegisterLabel2, Delight.AutoSize.Default);
                    Delight.Label.FontSizeProperty.SetDefault(_playFabRegisterLabel2, 14f);
                    Delight.Label.FontColorProperty.SetDefault(_playFabRegisterLabel2, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Label.FontProperty.SetDefault(_playFabRegisterLabel2, Assets.TMP_FontAssets["Segoe UI SDF"]);
                    Delight.Label.AlignmentProperty.SetDefault(_playFabRegisterLabel2, Delight.ElementAlignment.Left);
                }
                return _playFabRegisterLabel2;
            }
        }

        private static Template _playFabRegisterInputField1;
        public static Template PlayFabRegisterInputField1
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabRegisterInputField1 == null || _playFabRegisterInputField1.CurrentVersion != Template.Version)
#else
                if (_playFabRegisterInputField1 == null)
#endif
                {
                    _playFabRegisterInputField1 = new Template(InputFieldTemplates.InputField);
#if UNITY_EDITOR
                    _playFabRegisterInputField1.Name = "PlayFabRegisterInputField1";
                    _playFabRegisterInputField1.LineNumber = 11;
                    _playFabRegisterInputField1.LinePosition = 10;
#endif
                    Delight.InputField.AlignmentProperty.SetDefault(_playFabRegisterInputField1, Delight.ElementAlignment.Left);
                    Delight.InputField.TextProperty.SetHasBinding(_playFabRegisterInputField1);
                    Delight.InputField.InputFieldPlaceholderTemplateProperty.SetDefault(_playFabRegisterInputField1, PlayFabRegisterInputField1InputFieldPlaceholder);
                    Delight.InputField.TextAreaTemplateProperty.SetDefault(_playFabRegisterInputField1, PlayFabRegisterInputField1TextArea);
                    Delight.InputField.InputTextTemplateProperty.SetDefault(_playFabRegisterInputField1, PlayFabRegisterInputField1InputText);
                }
                return _playFabRegisterInputField1;
            }
        }

        private static Template _playFabRegisterInputField1InputFieldPlaceholder;
        public static Template PlayFabRegisterInputField1InputFieldPlaceholder
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabRegisterInputField1InputFieldPlaceholder == null || _playFabRegisterInputField1InputFieldPlaceholder.CurrentVersion != Template.Version)
#else
                if (_playFabRegisterInputField1InputFieldPlaceholder == null)
#endif
                {
                    _playFabRegisterInputField1InputFieldPlaceholder = new Template(InputFieldTemplates.InputFieldInputFieldPlaceholder);
#if UNITY_EDITOR
                    _playFabRegisterInputField1InputFieldPlaceholder.Name = "PlayFabRegisterInputField1InputFieldPlaceholder";
                    _playFabRegisterInputField1InputFieldPlaceholder.LineNumber = 12;
                    _playFabRegisterInputField1InputFieldPlaceholder.LinePosition = 4;
#endif
                }
                return _playFabRegisterInputField1InputFieldPlaceholder;
            }
        }

        private static Template _playFabRegisterInputField1TextArea;
        public static Template PlayFabRegisterInputField1TextArea
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabRegisterInputField1TextArea == null || _playFabRegisterInputField1TextArea.CurrentVersion != Template.Version)
#else
                if (_playFabRegisterInputField1TextArea == null)
#endif
                {
                    _playFabRegisterInputField1TextArea = new Template(InputFieldTemplates.InputFieldTextArea);
#if UNITY_EDITOR
                    _playFabRegisterInputField1TextArea.Name = "PlayFabRegisterInputField1TextArea";
                    _playFabRegisterInputField1TextArea.LineNumber = 13;
                    _playFabRegisterInputField1TextArea.LinePosition = 4;
#endif
                }
                return _playFabRegisterInputField1TextArea;
            }
        }

        private static Template _playFabRegisterInputField1InputText;
        public static Template PlayFabRegisterInputField1InputText
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabRegisterInputField1InputText == null || _playFabRegisterInputField1InputText.CurrentVersion != Template.Version)
#else
                if (_playFabRegisterInputField1InputText == null)
#endif
                {
                    _playFabRegisterInputField1InputText = new Template(InputFieldTemplates.InputFieldInputText);
#if UNITY_EDITOR
                    _playFabRegisterInputField1InputText.Name = "PlayFabRegisterInputField1InputText";
                    _playFabRegisterInputField1InputText.LineNumber = 14;
                    _playFabRegisterInputField1InputText.LinePosition = 6;
#endif
                }
                return _playFabRegisterInputField1InputText;
            }
        }

        private static Template _playFabRegisterLabel3;
        public static Template PlayFabRegisterLabel3
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabRegisterLabel3 == null || _playFabRegisterLabel3.CurrentVersion != Template.Version)
#else
                if (_playFabRegisterLabel3 == null)
#endif
                {
                    _playFabRegisterLabel3 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _playFabRegisterLabel3.Name = "PlayFabRegisterLabel3";
                    _playFabRegisterLabel3.LineNumber = 12;
                    _playFabRegisterLabel3.LinePosition = 10;
#endif
                    Delight.Label.TextProperty.SetDefault(_playFabRegisterLabel3, "Password");
                    Delight.Label.AutoSizeProperty.SetDefault(_playFabRegisterLabel3, Delight.AutoSize.Default);
                    Delight.Label.FontSizeProperty.SetDefault(_playFabRegisterLabel3, 14f);
                    Delight.Label.FontColorProperty.SetDefault(_playFabRegisterLabel3, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Label.FontProperty.SetDefault(_playFabRegisterLabel3, Assets.TMP_FontAssets["Segoe UI SDF"]);
                    Delight.Label.AlignmentProperty.SetDefault(_playFabRegisterLabel3, Delight.ElementAlignment.Left);
                }
                return _playFabRegisterLabel3;
            }
        }

        private static Template _playFabRegisterInputField2;
        public static Template PlayFabRegisterInputField2
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabRegisterInputField2 == null || _playFabRegisterInputField2.CurrentVersion != Template.Version)
#else
                if (_playFabRegisterInputField2 == null)
#endif
                {
                    _playFabRegisterInputField2 = new Template(InputFieldTemplates.InputField);
#if UNITY_EDITOR
                    _playFabRegisterInputField2.Name = "PlayFabRegisterInputField2";
                    _playFabRegisterInputField2.LineNumber = 13;
                    _playFabRegisterInputField2.LinePosition = 10;
#endif
                    Delight.InputField.InputTypeProperty.SetDefault(_playFabRegisterInputField2, TMPro.TMP_InputField.InputType.Password);
                    Delight.InputField.AlignmentProperty.SetDefault(_playFabRegisterInputField2, Delight.ElementAlignment.Left);
                    Delight.InputField.TextProperty.SetHasBinding(_playFabRegisterInputField2);
                    Delight.InputField.InputFieldPlaceholderTemplateProperty.SetDefault(_playFabRegisterInputField2, PlayFabRegisterInputField2InputFieldPlaceholder);
                    Delight.InputField.TextAreaTemplateProperty.SetDefault(_playFabRegisterInputField2, PlayFabRegisterInputField2TextArea);
                    Delight.InputField.InputTextTemplateProperty.SetDefault(_playFabRegisterInputField2, PlayFabRegisterInputField2InputText);
                }
                return _playFabRegisterInputField2;
            }
        }

        private static Template _playFabRegisterInputField2InputFieldPlaceholder;
        public static Template PlayFabRegisterInputField2InputFieldPlaceholder
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabRegisterInputField2InputFieldPlaceholder == null || _playFabRegisterInputField2InputFieldPlaceholder.CurrentVersion != Template.Version)
#else
                if (_playFabRegisterInputField2InputFieldPlaceholder == null)
#endif
                {
                    _playFabRegisterInputField2InputFieldPlaceholder = new Template(InputFieldTemplates.InputFieldInputFieldPlaceholder);
#if UNITY_EDITOR
                    _playFabRegisterInputField2InputFieldPlaceholder.Name = "PlayFabRegisterInputField2InputFieldPlaceholder";
                    _playFabRegisterInputField2InputFieldPlaceholder.LineNumber = 12;
                    _playFabRegisterInputField2InputFieldPlaceholder.LinePosition = 4;
#endif
                }
                return _playFabRegisterInputField2InputFieldPlaceholder;
            }
        }

        private static Template _playFabRegisterInputField2TextArea;
        public static Template PlayFabRegisterInputField2TextArea
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabRegisterInputField2TextArea == null || _playFabRegisterInputField2TextArea.CurrentVersion != Template.Version)
#else
                if (_playFabRegisterInputField2TextArea == null)
#endif
                {
                    _playFabRegisterInputField2TextArea = new Template(InputFieldTemplates.InputFieldTextArea);
#if UNITY_EDITOR
                    _playFabRegisterInputField2TextArea.Name = "PlayFabRegisterInputField2TextArea";
                    _playFabRegisterInputField2TextArea.LineNumber = 13;
                    _playFabRegisterInputField2TextArea.LinePosition = 4;
#endif
                }
                return _playFabRegisterInputField2TextArea;
            }
        }

        private static Template _playFabRegisterInputField2InputText;
        public static Template PlayFabRegisterInputField2InputText
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabRegisterInputField2InputText == null || _playFabRegisterInputField2InputText.CurrentVersion != Template.Version)
#else
                if (_playFabRegisterInputField2InputText == null)
#endif
                {
                    _playFabRegisterInputField2InputText = new Template(InputFieldTemplates.InputFieldInputText);
#if UNITY_EDITOR
                    _playFabRegisterInputField2InputText.Name = "PlayFabRegisterInputField2InputText";
                    _playFabRegisterInputField2InputText.LineNumber = 14;
                    _playFabRegisterInputField2InputText.LinePosition = 6;
#endif
                }
                return _playFabRegisterInputField2InputText;
            }
        }

        private static Template _playFabRegisterButton1;
        public static Template PlayFabRegisterButton1
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabRegisterButton1 == null || _playFabRegisterButton1.CurrentVersion != Template.Version)
#else
                if (_playFabRegisterButton1 == null)
#endif
                {
                    _playFabRegisterButton1 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _playFabRegisterButton1.Name = "PlayFabRegisterButton1";
                    _playFabRegisterButton1.LineNumber = 14;
                    _playFabRegisterButton1.LinePosition = 10;
#endif
                    Delight.Button.AlignmentProperty.SetDefault(_playFabRegisterButton1, Delight.ElementAlignment.Left);
                    Delight.Button.IsDisabledProperty.SetHasBinding(_playFabRegisterButton1);
                    Delight.Button.LabelTemplateProperty.SetDefault(_playFabRegisterButton1, PlayFabRegisterButton1Label);
                }
                return _playFabRegisterButton1;
            }
        }

        private static Template _playFabRegisterButton1Label;
        public static Template PlayFabRegisterButton1Label
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabRegisterButton1Label == null || _playFabRegisterButton1Label.CurrentVersion != Template.Version)
#else
                if (_playFabRegisterButton1Label == null)
#endif
                {
                    _playFabRegisterButton1Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _playFabRegisterButton1Label.Name = "PlayFabRegisterButton1Label";
                    _playFabRegisterButton1Label.LineNumber = 15;
                    _playFabRegisterButton1Label.LinePosition = 4;
#endif
                    Delight.Label.TextProperty.SetDefault(_playFabRegisterButton1Label, "Register");
                }
                return _playFabRegisterButton1Label;
            }
        }

        private static Template _playFabRegisterLabel4;
        public static Template PlayFabRegisterLabel4
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabRegisterLabel4 == null || _playFabRegisterLabel4.CurrentVersion != Template.Version)
#else
                if (_playFabRegisterLabel4 == null)
#endif
                {
                    _playFabRegisterLabel4 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _playFabRegisterLabel4.Name = "PlayFabRegisterLabel4";
                    _playFabRegisterLabel4.LineNumber = 15;
                    _playFabRegisterLabel4.LinePosition = 10;
#endif
                    Delight.Label.AutoSizeProperty.SetDefault(_playFabRegisterLabel4, Delight.AutoSize.Default);
                    Delight.Label.FontSizeProperty.SetDefault(_playFabRegisterLabel4, 20f);
                    Delight.Label.FontColorProperty.SetDefault(_playFabRegisterLabel4, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Label.FontProperty.SetDefault(_playFabRegisterLabel4, Assets.TMP_FontAssets["Segoe UI SDF"]);
                    Delight.Label.TextProperty.SetHasBinding(_playFabRegisterLabel4);
                    Delight.Label.IsVisibleProperty.SetHasBinding(_playFabRegisterLabel4);
                }
                return _playFabRegisterLabel4;
            }
        }

        #endregion
    }

    #endregion
}

#endif
