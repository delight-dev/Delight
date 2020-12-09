#if DELIGHT_MODULE_PLAYFAB

// Internal view logic generated from "PlayFabLogin.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class PlayFabLogin : UIView
    {
        #region Constructors

        public PlayFabLogin(View parent, View layoutParent = null, string id = null, Template template = null, bool deferInitialization = false) :
            base(parent, layoutParent, id, template ?? PlayFabLoginTemplates.Default, deferInitialization)
        {
            if (deferInitialization)
                return;

            // constructing Grid (Grid1)
            Grid1 = new LayoutGrid(this, this, "Grid1", Grid1Template);
            Region1 = new Region(this, Grid1.Content, "Region1", Region1Template);
            Grid1.Cell.SetValue(Region1, new CellIndex(0, 0));
            Group1 = new Group(this, Region1.Content, "Group1", Group1Template);

            // binding <Group IsActive="{!@PlayFabUser.IsLoggedIn}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "IsLoggedIn" }, new List<Func<object>> { () => Models.PlayFabUser }) }, new BindingPath(new List<string> { "Group1", "IsActive" }, new List<Func<object>> { () => this, () => Group1 }), () => Group1.IsActive = !Models.PlayFabUser.IsLoggedIn, () => { }, false));
            Label1 = new Label(this, Group1.Content, "Label1", Label1Template);
            Label2 = new Label(this, Group1.Content, "Label2", Label2Template);
            InputField1 = new InputField(this, Group1.Content, "InputField1", InputField1Template);

            // binding <InputField Text="{Email}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "Email" }, new List<Func<object>> { () => this }) }, new BindingPath(new List<string> { "InputField1", "Text" }, new List<Func<object>> { () => this, () => InputField1 }), () => InputField1.Text = Email, () => Email = InputField1.Text, true));
            Label3 = new Label(this, Group1.Content, "Label3", Label3Template);
            InputField2 = new InputField(this, Group1.Content, "InputField2", InputField2Template);

            // binding <InputField Text="{Password}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "Password" }, new List<Func<object>> { () => this }) }, new BindingPath(new List<string> { "InputField2", "Text" }, new List<Func<object>> { () => this, () => InputField2 }), () => InputField2.Text = Password, () => Password = InputField2.Text, true));
            Button1 = new Button(this, Group1.Content, "Button1", Button1Template);
            Button1.Click.RegisterHandler(this, "LogIn");

            // binding <Button IsDisabled="{@PlayFabUser.IsLoggingIn}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "IsLoggingIn" }, new List<Func<object>> { () => Models.PlayFabUser }) }, new BindingPath(new List<string> { "Button1", "IsDisabled" }, new List<Func<object>> { () => this, () => Button1 }), () => Button1.IsDisabled = Models.PlayFabUser.IsLoggingIn, () => { }, false));
            Label4 = new Label(this, Group1.Content, "Label4", Label4Template);

            // binding <Label Text="Failed to log in: {@PlayFabUser.LoggedInFailedMessage}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "LoggedInFailedMessage" }, new List<Func<object>> { () => Models.PlayFabUser }) }, new BindingPath(new List<string> { "Label4", "Text" }, new List<Func<object>> { () => this, () => Label4 }), () => Label4.Text = String.Format("Failed to log in: {0}", Models.PlayFabUser.LoggedInFailedMessage), () => { }, false));

            // binding <Label IsVisible="{@PlayFabUser.LoggedInFailed}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "LoggedInFailed" }, new List<Func<object>> { () => Models.PlayFabUser }) }, new BindingPath(new List<string> { "Label4", "IsVisible" }, new List<Func<object>> { () => this, () => Label4 }), () => Label4.IsVisible = Models.PlayFabUser.LoggedInFailed, () => { }, false));
            Group2 = new Group(this, Region1.Content, "Group2", Group2Template);

            // binding <Group IsActive="{@PlayFabUser.IsLoggedIn}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "IsLoggedIn" }, new List<Func<object>> { () => Models.PlayFabUser }) }, new BindingPath(new List<string> { "Group2", "IsActive" }, new List<Func<object>> { () => this, () => Group2 }), () => Group2.IsActive = Models.PlayFabUser.IsLoggedIn, () => { }, false));
            Button2 = new Button(this, Group2.Content, "Button2", Button2Template);
            Button2.Click.RegisterHandler(this, "LogOut");
            this.AfterInitializeInternal();
        }

        public PlayFabLogin() : this(null)
        {
        }

        static PlayFabLogin()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(PlayFabLoginTemplates.Default, dependencyProperties);

            dependencyProperties.Add(EmailProperty);
            dependencyProperties.Add(PasswordProperty);
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
            dependencyProperties.Add(Group2Property);
            dependencyProperties.Add(Group2TemplateProperty);
            dependencyProperties.Add(Button2Property);
            dependencyProperties.Add(Button2TemplateProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<System.String> EmailProperty = new DependencyProperty<System.String>("Email");
        public System.String Email
        {
            get { return EmailProperty.GetValue(this); }
            set { EmailProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.String> PasswordProperty = new DependencyProperty<System.String>("Password");
        public System.String Password
        {
            get { return PasswordProperty.GetValue(this); }
            set { PasswordProperty.SetValue(this, value); }
        }

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

        public readonly static DependencyProperty<Group> Group2Property = new DependencyProperty<Group>("Group2");
        public Group Group2
        {
            get { return Group2Property.GetValue(this); }
            set { Group2Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Group2TemplateProperty = new DependencyProperty<Template>("Group2Template");
        public Template Group2Template
        {
            get { return Group2TemplateProperty.GetValue(this); }
            set { Group2TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Button> Button2Property = new DependencyProperty<Button>("Button2");
        public Button Button2
        {
            get { return Button2Property.GetValue(this); }
            set { Button2Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Button2TemplateProperty = new DependencyProperty<Template>("Button2Template");
        public Template Button2Template
        {
            get { return Button2TemplateProperty.GetValue(this); }
            set { Button2TemplateProperty.SetValue(this, value); }
        }

        #endregion
    }

    #region Data Templates

    public static class PlayFabLoginTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return PlayFabLogin;
            }
        }

        private static Template _playFabLogin;
        public static Template PlayFabLogin
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabLogin == null || _playFabLogin.CurrentVersion != Template.Version)
#else
                if (_playFabLogin == null)
#endif
                {
                    _playFabLogin = new Template(UIViewTemplates.UIView);
#if UNITY_EDITOR
                    _playFabLogin.Name = "PlayFabLogin";
                    _playFabLogin.LineNumber = 0;
                    _playFabLogin.LinePosition = 0;
#endif
                    Delight.PlayFabLogin.EmailProperty.SetDefault(_playFabLogin, "opacic@gmail.com");
                    Delight.PlayFabLogin.PasswordProperty.SetDefault(_playFabLogin, "kattkatt");
                    Delight.PlayFabLogin.Grid1TemplateProperty.SetDefault(_playFabLogin, PlayFabLoginGrid1);
                    Delight.PlayFabLogin.Region1TemplateProperty.SetDefault(_playFabLogin, PlayFabLoginRegion1);
                    Delight.PlayFabLogin.Group1TemplateProperty.SetDefault(_playFabLogin, PlayFabLoginGroup1);
                    Delight.PlayFabLogin.Label1TemplateProperty.SetDefault(_playFabLogin, PlayFabLoginLabel1);
                    Delight.PlayFabLogin.Label2TemplateProperty.SetDefault(_playFabLogin, PlayFabLoginLabel2);
                    Delight.PlayFabLogin.InputField1TemplateProperty.SetDefault(_playFabLogin, PlayFabLoginInputField1);
                    Delight.PlayFabLogin.Label3TemplateProperty.SetDefault(_playFabLogin, PlayFabLoginLabel3);
                    Delight.PlayFabLogin.InputField2TemplateProperty.SetDefault(_playFabLogin, PlayFabLoginInputField2);
                    Delight.PlayFabLogin.Button1TemplateProperty.SetDefault(_playFabLogin, PlayFabLoginButton1);
                    Delight.PlayFabLogin.Label4TemplateProperty.SetDefault(_playFabLogin, PlayFabLoginLabel4);
                    Delight.PlayFabLogin.Group2TemplateProperty.SetDefault(_playFabLogin, PlayFabLoginGroup2);
                    Delight.PlayFabLogin.Button2TemplateProperty.SetDefault(_playFabLogin, PlayFabLoginButton2);
                }
                return _playFabLogin;
            }
        }

        private static Template _playFabLoginGrid1;
        public static Template PlayFabLoginGrid1
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabLoginGrid1 == null || _playFabLoginGrid1.CurrentVersion != Template.Version)
#else
                if (_playFabLoginGrid1 == null)
#endif
                {
                    _playFabLoginGrid1 = new Template(LayoutGridTemplates.LayoutGrid);
#if UNITY_EDITOR
                    _playFabLoginGrid1.Name = "PlayFabLoginGrid1";
                    _playFabLoginGrid1.LineNumber = 4;
                    _playFabLoginGrid1.LinePosition = 4;
#endif
                    Delight.LayoutGrid.ColumnsProperty.SetDefault(_playFabLoginGrid1, new ColumnDefinitions { new ColumnDefinition(new ElementSize(1f, ElementSizeUnit.Proportional)), new ColumnDefinition(new ElementSize(1f, ElementSizeUnit.Proportional))});
                }
                return _playFabLoginGrid1;
            }
        }

        private static Template _playFabLoginRegion1;
        public static Template PlayFabLoginRegion1
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabLoginRegion1 == null || _playFabLoginRegion1.CurrentVersion != Template.Version)
#else
                if (_playFabLoginRegion1 == null)
#endif
                {
                    _playFabLoginRegion1 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _playFabLoginRegion1.Name = "PlayFabLoginRegion1";
                    _playFabLoginRegion1.LineNumber = 7;
                    _playFabLoginRegion1.LinePosition = 6;
#endif
                    Delight.Region.MarginProperty.SetDefault(_playFabLoginRegion1, new ElementMargin(new ElementSize(10f, ElementSizeUnit.Pixels)));
                }
                return _playFabLoginRegion1;
            }
        }

        private static Template _playFabLoginGroup1;
        public static Template PlayFabLoginGroup1
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabLoginGroup1 == null || _playFabLoginGroup1.CurrentVersion != Template.Version)
#else
                if (_playFabLoginGroup1 == null)
#endif
                {
                    _playFabLoginGroup1 = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _playFabLoginGroup1.Name = "PlayFabLoginGroup1";
                    _playFabLoginGroup1.LineNumber = 8;
                    _playFabLoginGroup1.LinePosition = 8;
#endif
                    Delight.Group.SpacingProperty.SetDefault(_playFabLoginGroup1, new ElementSize(5f, ElementSizeUnit.Pixels));
                    Delight.Group.AlignmentProperty.SetDefault(_playFabLoginGroup1, Delight.ElementAlignment.TopLeft);
                    Delight.Group.IsActiveProperty.SetHasBinding(_playFabLoginGroup1);
                }
                return _playFabLoginGroup1;
            }
        }

        private static Template _playFabLoginLabel1;
        public static Template PlayFabLoginLabel1
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabLoginLabel1 == null || _playFabLoginLabel1.CurrentVersion != Template.Version)
#else
                if (_playFabLoginLabel1 == null)
#endif
                {
                    _playFabLoginLabel1 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _playFabLoginLabel1.Name = "PlayFabLoginLabel1";
                    _playFabLoginLabel1.LineNumber = 9;
                    _playFabLoginLabel1.LinePosition = 10;
#endif
                    Delight.Label.TextProperty.SetDefault(_playFabLoginLabel1, "Login");
                    Delight.Label.AutoSizeProperty.SetDefault(_playFabLoginLabel1, Delight.AutoSize.Default);
                    Delight.Label.FontSizeProperty.SetDefault(_playFabLoginLabel1, 30f);
                    Delight.Label.FontColorProperty.SetDefault(_playFabLoginLabel1, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Label.FontProperty.SetDefault(_playFabLoginLabel1, Assets.TMP_FontAssets["Segoe UI SDF"]);
                    Delight.Label.AlignmentProperty.SetDefault(_playFabLoginLabel1, Delight.ElementAlignment.Left);
                }
                return _playFabLoginLabel1;
            }
        }

        private static Template _playFabLoginLabel2;
        public static Template PlayFabLoginLabel2
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabLoginLabel2 == null || _playFabLoginLabel2.CurrentVersion != Template.Version)
#else
                if (_playFabLoginLabel2 == null)
#endif
                {
                    _playFabLoginLabel2 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _playFabLoginLabel2.Name = "PlayFabLoginLabel2";
                    _playFabLoginLabel2.LineNumber = 10;
                    _playFabLoginLabel2.LinePosition = 10;
#endif
                    Delight.Label.TextProperty.SetDefault(_playFabLoginLabel2, "Email");
                    Delight.Label.AutoSizeProperty.SetDefault(_playFabLoginLabel2, Delight.AutoSize.Default);
                    Delight.Label.FontSizeProperty.SetDefault(_playFabLoginLabel2, 14f);
                    Delight.Label.FontColorProperty.SetDefault(_playFabLoginLabel2, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Label.FontProperty.SetDefault(_playFabLoginLabel2, Assets.TMP_FontAssets["Segoe UI SDF"]);
                    Delight.Label.AlignmentProperty.SetDefault(_playFabLoginLabel2, Delight.ElementAlignment.Left);
                }
                return _playFabLoginLabel2;
            }
        }

        private static Template _playFabLoginInputField1;
        public static Template PlayFabLoginInputField1
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabLoginInputField1 == null || _playFabLoginInputField1.CurrentVersion != Template.Version)
#else
                if (_playFabLoginInputField1 == null)
#endif
                {
                    _playFabLoginInputField1 = new Template(InputFieldTemplates.InputField);
#if UNITY_EDITOR
                    _playFabLoginInputField1.Name = "PlayFabLoginInputField1";
                    _playFabLoginInputField1.LineNumber = 11;
                    _playFabLoginInputField1.LinePosition = 10;
#endif
                    Delight.InputField.AlignmentProperty.SetDefault(_playFabLoginInputField1, Delight.ElementAlignment.Left);
                    Delight.InputField.TextProperty.SetHasBinding(_playFabLoginInputField1);
                    Delight.InputField.InputFieldPlaceholderTemplateProperty.SetDefault(_playFabLoginInputField1, PlayFabLoginInputField1InputFieldPlaceholder);
                    Delight.InputField.TextAreaTemplateProperty.SetDefault(_playFabLoginInputField1, PlayFabLoginInputField1TextArea);
                    Delight.InputField.InputTextTemplateProperty.SetDefault(_playFabLoginInputField1, PlayFabLoginInputField1InputText);
                }
                return _playFabLoginInputField1;
            }
        }

        private static Template _playFabLoginInputField1InputFieldPlaceholder;
        public static Template PlayFabLoginInputField1InputFieldPlaceholder
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabLoginInputField1InputFieldPlaceholder == null || _playFabLoginInputField1InputFieldPlaceholder.CurrentVersion != Template.Version)
#else
                if (_playFabLoginInputField1InputFieldPlaceholder == null)
#endif
                {
                    _playFabLoginInputField1InputFieldPlaceholder = new Template(InputFieldTemplates.InputFieldInputFieldPlaceholder);
#if UNITY_EDITOR
                    _playFabLoginInputField1InputFieldPlaceholder.Name = "PlayFabLoginInputField1InputFieldPlaceholder";
                    _playFabLoginInputField1InputFieldPlaceholder.LineNumber = 12;
                    _playFabLoginInputField1InputFieldPlaceholder.LinePosition = 4;
#endif
                }
                return _playFabLoginInputField1InputFieldPlaceholder;
            }
        }

        private static Template _playFabLoginInputField1TextArea;
        public static Template PlayFabLoginInputField1TextArea
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabLoginInputField1TextArea == null || _playFabLoginInputField1TextArea.CurrentVersion != Template.Version)
#else
                if (_playFabLoginInputField1TextArea == null)
#endif
                {
                    _playFabLoginInputField1TextArea = new Template(InputFieldTemplates.InputFieldTextArea);
#if UNITY_EDITOR
                    _playFabLoginInputField1TextArea.Name = "PlayFabLoginInputField1TextArea";
                    _playFabLoginInputField1TextArea.LineNumber = 13;
                    _playFabLoginInputField1TextArea.LinePosition = 4;
#endif
                }
                return _playFabLoginInputField1TextArea;
            }
        }

        private static Template _playFabLoginInputField1InputText;
        public static Template PlayFabLoginInputField1InputText
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabLoginInputField1InputText == null || _playFabLoginInputField1InputText.CurrentVersion != Template.Version)
#else
                if (_playFabLoginInputField1InputText == null)
#endif
                {
                    _playFabLoginInputField1InputText = new Template(InputFieldTemplates.InputFieldInputText);
#if UNITY_EDITOR
                    _playFabLoginInputField1InputText.Name = "PlayFabLoginInputField1InputText";
                    _playFabLoginInputField1InputText.LineNumber = 14;
                    _playFabLoginInputField1InputText.LinePosition = 6;
#endif
                }
                return _playFabLoginInputField1InputText;
            }
        }

        private static Template _playFabLoginLabel3;
        public static Template PlayFabLoginLabel3
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabLoginLabel3 == null || _playFabLoginLabel3.CurrentVersion != Template.Version)
#else
                if (_playFabLoginLabel3 == null)
#endif
                {
                    _playFabLoginLabel3 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _playFabLoginLabel3.Name = "PlayFabLoginLabel3";
                    _playFabLoginLabel3.LineNumber = 12;
                    _playFabLoginLabel3.LinePosition = 10;
#endif
                    Delight.Label.TextProperty.SetDefault(_playFabLoginLabel3, "Password");
                    Delight.Label.AutoSizeProperty.SetDefault(_playFabLoginLabel3, Delight.AutoSize.Default);
                    Delight.Label.FontSizeProperty.SetDefault(_playFabLoginLabel3, 14f);
                    Delight.Label.FontColorProperty.SetDefault(_playFabLoginLabel3, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Label.FontProperty.SetDefault(_playFabLoginLabel3, Assets.TMP_FontAssets["Segoe UI SDF"]);
                    Delight.Label.AlignmentProperty.SetDefault(_playFabLoginLabel3, Delight.ElementAlignment.Left);
                }
                return _playFabLoginLabel3;
            }
        }

        private static Template _playFabLoginInputField2;
        public static Template PlayFabLoginInputField2
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabLoginInputField2 == null || _playFabLoginInputField2.CurrentVersion != Template.Version)
#else
                if (_playFabLoginInputField2 == null)
#endif
                {
                    _playFabLoginInputField2 = new Template(InputFieldTemplates.InputField);
#if UNITY_EDITOR
                    _playFabLoginInputField2.Name = "PlayFabLoginInputField2";
                    _playFabLoginInputField2.LineNumber = 13;
                    _playFabLoginInputField2.LinePosition = 10;
#endif
                    Delight.InputField.InputTypeProperty.SetDefault(_playFabLoginInputField2, TMPro.TMP_InputField.InputType.Password);
                    Delight.InputField.AlignmentProperty.SetDefault(_playFabLoginInputField2, Delight.ElementAlignment.Left);
                    Delight.InputField.TextProperty.SetHasBinding(_playFabLoginInputField2);
                    Delight.InputField.InputFieldPlaceholderTemplateProperty.SetDefault(_playFabLoginInputField2, PlayFabLoginInputField2InputFieldPlaceholder);
                    Delight.InputField.TextAreaTemplateProperty.SetDefault(_playFabLoginInputField2, PlayFabLoginInputField2TextArea);
                    Delight.InputField.InputTextTemplateProperty.SetDefault(_playFabLoginInputField2, PlayFabLoginInputField2InputText);
                }
                return _playFabLoginInputField2;
            }
        }

        private static Template _playFabLoginInputField2InputFieldPlaceholder;
        public static Template PlayFabLoginInputField2InputFieldPlaceholder
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabLoginInputField2InputFieldPlaceholder == null || _playFabLoginInputField2InputFieldPlaceholder.CurrentVersion != Template.Version)
#else
                if (_playFabLoginInputField2InputFieldPlaceholder == null)
#endif
                {
                    _playFabLoginInputField2InputFieldPlaceholder = new Template(InputFieldTemplates.InputFieldInputFieldPlaceholder);
#if UNITY_EDITOR
                    _playFabLoginInputField2InputFieldPlaceholder.Name = "PlayFabLoginInputField2InputFieldPlaceholder";
                    _playFabLoginInputField2InputFieldPlaceholder.LineNumber = 12;
                    _playFabLoginInputField2InputFieldPlaceholder.LinePosition = 4;
#endif
                }
                return _playFabLoginInputField2InputFieldPlaceholder;
            }
        }

        private static Template _playFabLoginInputField2TextArea;
        public static Template PlayFabLoginInputField2TextArea
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabLoginInputField2TextArea == null || _playFabLoginInputField2TextArea.CurrentVersion != Template.Version)
#else
                if (_playFabLoginInputField2TextArea == null)
#endif
                {
                    _playFabLoginInputField2TextArea = new Template(InputFieldTemplates.InputFieldTextArea);
#if UNITY_EDITOR
                    _playFabLoginInputField2TextArea.Name = "PlayFabLoginInputField2TextArea";
                    _playFabLoginInputField2TextArea.LineNumber = 13;
                    _playFabLoginInputField2TextArea.LinePosition = 4;
#endif
                }
                return _playFabLoginInputField2TextArea;
            }
        }

        private static Template _playFabLoginInputField2InputText;
        public static Template PlayFabLoginInputField2InputText
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabLoginInputField2InputText == null || _playFabLoginInputField2InputText.CurrentVersion != Template.Version)
#else
                if (_playFabLoginInputField2InputText == null)
#endif
                {
                    _playFabLoginInputField2InputText = new Template(InputFieldTemplates.InputFieldInputText);
#if UNITY_EDITOR
                    _playFabLoginInputField2InputText.Name = "PlayFabLoginInputField2InputText";
                    _playFabLoginInputField2InputText.LineNumber = 14;
                    _playFabLoginInputField2InputText.LinePosition = 6;
#endif
                }
                return _playFabLoginInputField2InputText;
            }
        }

        private static Template _playFabLoginButton1;
        public static Template PlayFabLoginButton1
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabLoginButton1 == null || _playFabLoginButton1.CurrentVersion != Template.Version)
#else
                if (_playFabLoginButton1 == null)
#endif
                {
                    _playFabLoginButton1 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _playFabLoginButton1.Name = "PlayFabLoginButton1";
                    _playFabLoginButton1.LineNumber = 14;
                    _playFabLoginButton1.LinePosition = 10;
#endif
                    Delight.Button.AlignmentProperty.SetDefault(_playFabLoginButton1, Delight.ElementAlignment.Left);
                    Delight.Button.IsDisabledProperty.SetHasBinding(_playFabLoginButton1);
                    Delight.Button.LabelTemplateProperty.SetDefault(_playFabLoginButton1, PlayFabLoginButton1Label);
                }
                return _playFabLoginButton1;
            }
        }

        private static Template _playFabLoginButton1Label;
        public static Template PlayFabLoginButton1Label
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabLoginButton1Label == null || _playFabLoginButton1Label.CurrentVersion != Template.Version)
#else
                if (_playFabLoginButton1Label == null)
#endif
                {
                    _playFabLoginButton1Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _playFabLoginButton1Label.Name = "PlayFabLoginButton1Label";
                    _playFabLoginButton1Label.LineNumber = 15;
                    _playFabLoginButton1Label.LinePosition = 4;
#endif
                    Delight.Label.TextProperty.SetDefault(_playFabLoginButton1Label, "Log in");
                }
                return _playFabLoginButton1Label;
            }
        }

        private static Template _playFabLoginLabel4;
        public static Template PlayFabLoginLabel4
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabLoginLabel4 == null || _playFabLoginLabel4.CurrentVersion != Template.Version)
#else
                if (_playFabLoginLabel4 == null)
#endif
                {
                    _playFabLoginLabel4 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _playFabLoginLabel4.Name = "PlayFabLoginLabel4";
                    _playFabLoginLabel4.LineNumber = 15;
                    _playFabLoginLabel4.LinePosition = 10;
#endif
                    Delight.Label.AutoSizeProperty.SetDefault(_playFabLoginLabel4, Delight.AutoSize.Default);
                    Delight.Label.FontSizeProperty.SetDefault(_playFabLoginLabel4, 20f);
                    Delight.Label.FontColorProperty.SetDefault(_playFabLoginLabel4, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Label.FontProperty.SetDefault(_playFabLoginLabel4, Assets.TMP_FontAssets["Segoe UI SDF"]);
                    Delight.Label.TextProperty.SetHasBinding(_playFabLoginLabel4);
                    Delight.Label.IsVisibleProperty.SetHasBinding(_playFabLoginLabel4);
                }
                return _playFabLoginLabel4;
            }
        }

        private static Template _playFabLoginGroup2;
        public static Template PlayFabLoginGroup2
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabLoginGroup2 == null || _playFabLoginGroup2.CurrentVersion != Template.Version)
#else
                if (_playFabLoginGroup2 == null)
#endif
                {
                    _playFabLoginGroup2 = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _playFabLoginGroup2.Name = "PlayFabLoginGroup2";
                    _playFabLoginGroup2.LineNumber = 17;
                    _playFabLoginGroup2.LinePosition = 8;
#endif
                    Delight.Group.AlignmentProperty.SetDefault(_playFabLoginGroup2, Delight.ElementAlignment.TopLeft);
                    Delight.Group.ContentAlignmentProperty.SetDefault(_playFabLoginGroup2, Delight.ElementAlignment.Left);
                    Delight.Group.IsActiveProperty.SetHasBinding(_playFabLoginGroup2);
                }
                return _playFabLoginGroup2;
            }
        }

        private static Template _playFabLoginButton2;
        public static Template PlayFabLoginButton2
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabLoginButton2 == null || _playFabLoginButton2.CurrentVersion != Template.Version)
#else
                if (_playFabLoginButton2 == null)
#endif
                {
                    _playFabLoginButton2 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _playFabLoginButton2.Name = "PlayFabLoginButton2";
                    _playFabLoginButton2.LineNumber = 18;
                    _playFabLoginButton2.LinePosition = 10;
#endif
                    Delight.Button.AlignmentProperty.SetDefault(_playFabLoginButton2, Delight.ElementAlignment.Left);
                    Delight.Button.LabelTemplateProperty.SetDefault(_playFabLoginButton2, PlayFabLoginButton2Label);
                }
                return _playFabLoginButton2;
            }
        }

        private static Template _playFabLoginButton2Label;
        public static Template PlayFabLoginButton2Label
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabLoginButton2Label == null || _playFabLoginButton2Label.CurrentVersion != Template.Version)
#else
                if (_playFabLoginButton2Label == null)
#endif
                {
                    _playFabLoginButton2Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _playFabLoginButton2Label.Name = "PlayFabLoginButton2Label";
                    _playFabLoginButton2Label.LineNumber = 15;
                    _playFabLoginButton2Label.LinePosition = 4;
#endif
                    Delight.Label.TextProperty.SetDefault(_playFabLoginButton2Label, "Log out");
                }
                return _playFabLoginButton2Label;
            }
        }

        #endregion
    }

    #endregion
}

#endif
