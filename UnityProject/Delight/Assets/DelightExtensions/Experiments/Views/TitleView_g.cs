// Internal view logic generated from "TitleView.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class TitleView : UIView
    {
        #region Constructors

        public TitleView(View parent, View layoutParent = null, string id = null, Template template = null, bool deferInitialization = false) :
            base(parent, layoutParent, id, template ?? TitleViewTemplates.Default, deferInitialization)
        {
            if (deferInitialization)
                return;

            // constructing Group (Group1)
            Group1 = new Group(this, this, "Group1", Group1Template);
            Button1 = new Button(this, Group1.Content, "Button1", Button1Template);

            // binding <Button Text="{Title}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "Title" }, new List<Func<BindableObject>> { () => this }) }, new BindingPath(new List<string> { "Button1", "Text" }, new List<Func<BindableObject>> { () => this, () => Button1 }), () => Button1.Text = Title, () => { }, false));
            CheckBox1 = new CheckBox(this, Group1.Content, "CheckBox1", CheckBox1Template);

            // binding <CheckBox IsChecked="{=Check}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "Check" }, new List<Func<BindableObject>> { () => this }) }, new BindingPath(new List<string> { "CheckBox1", "IsChecked" }, new List<Func<BindableObject>> { () => this, () => CheckBox1 }), () => CheckBox1.IsChecked = Check, () => Check = CheckBox1.IsChecked, true));
            CheckBox2 = new CheckBox(this, Group1.Content, "CheckBox2", CheckBox2Template);

            // binding <CheckBox IsChecked="{!Check}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "Check" }, new List<Func<BindableObject>> { () => this }) }, new BindingPath(new List<string> { "CheckBox2", "IsChecked" }, new List<Func<BindableObject>> { () => this, () => CheckBox2 }), () => CheckBox2.IsChecked = !Check, () => Check = !CheckBox2.IsChecked, true));
            Input = new InputField(this, Group1.Content, "Input", InputTemplate);
            Label1 = new Label(this, Group1.Content, "Label1", Label1Template);

            // binding <Label Text="{Input.Text}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "Input", "Text" }, new List<Func<BindableObject>> { () => this, () => Input }) }, new BindingPath(new List<string> { "Label1", "Text" }, new List<Func<BindableObject>> { () => this, () => Label1 }), () => Label1.Text = Input.Text, () => { }, false));
            Label2 = new Label(this, Group1.Content, "Label2", Label2Template);

            // binding <Label Text="{@DefaultRepositoryName}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> {  }, new List<Func<BindableObject>> {  }) }, new BindingPath(new List<string> { "Label2", "Text" }, new List<Func<BindableObject>> { () => this, () => Label2 }), () => Label2.Text = Models.DefaultRepositoryName, () => { }, false));
            Input1 = new InputField(this, Group1.Content, "Input1", Input1Template);
            Input2 = new InputField(this, Group1.Content, "Input2", Input2Template);
            Label3 = new Label(this, Group1.Content, "Label3", Label3Template);

            // binding <Label Text="$MyMethod({Input1.Text}, {Input2.Text})">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "Input1", "Text" }, new List<Func<BindableObject>> { () => this, () => Input1 }), new BindingPath(new List<string> { "Input2", "Text" }, new List<Func<BindableObject>> { () => this, () => Input2 }) }, new BindingPath(new List<string> { "Label3", "Text" }, new List<Func<BindableObject>> { () => this, () => Label3 }), () => Label3.Text = MyMethod(Input1.Text, Input2.Text), () => { }, false));
            this.AfterInitializeInternal();
        }

        public TitleView() : this(null)
        {
        }

        static TitleView()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(TitleViewTemplates.Default, dependencyProperties);

            dependencyProperties.Add(TitleProperty);
            dependencyProperties.Add(CheckProperty);
            dependencyProperties.Add(Group1Property);
            dependencyProperties.Add(Group1TemplateProperty);
            dependencyProperties.Add(Button1Property);
            dependencyProperties.Add(Button1TemplateProperty);
            dependencyProperties.Add(CheckBox1Property);
            dependencyProperties.Add(CheckBox1TemplateProperty);
            dependencyProperties.Add(CheckBox2Property);
            dependencyProperties.Add(CheckBox2TemplateProperty);
            dependencyProperties.Add(InputProperty);
            dependencyProperties.Add(InputTemplateProperty);
            dependencyProperties.Add(Label1Property);
            dependencyProperties.Add(Label1TemplateProperty);
            dependencyProperties.Add(Label2Property);
            dependencyProperties.Add(Label2TemplateProperty);
            dependencyProperties.Add(Input1Property);
            dependencyProperties.Add(Input1TemplateProperty);
            dependencyProperties.Add(Input2Property);
            dependencyProperties.Add(Input2TemplateProperty);
            dependencyProperties.Add(Label3Property);
            dependencyProperties.Add(Label3TemplateProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<System.String> TitleProperty = new DependencyProperty<System.String>("Title");
        public System.String Title
        {
            get { return TitleProperty.GetValue(this); }
            set { TitleProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> CheckProperty = new DependencyProperty<System.Boolean>("Check");
        public System.Boolean Check
        {
            get { return CheckProperty.GetValue(this); }
            set { CheckProperty.SetValue(this, value); }
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

        public readonly static DependencyProperty<CheckBox> CheckBox1Property = new DependencyProperty<CheckBox>("CheckBox1");
        public CheckBox CheckBox1
        {
            get { return CheckBox1Property.GetValue(this); }
            set { CheckBox1Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> CheckBox1TemplateProperty = new DependencyProperty<Template>("CheckBox1Template");
        public Template CheckBox1Template
        {
            get { return CheckBox1TemplateProperty.GetValue(this); }
            set { CheckBox1TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<CheckBox> CheckBox2Property = new DependencyProperty<CheckBox>("CheckBox2");
        public CheckBox CheckBox2
        {
            get { return CheckBox2Property.GetValue(this); }
            set { CheckBox2Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> CheckBox2TemplateProperty = new DependencyProperty<Template>("CheckBox2Template");
        public Template CheckBox2Template
        {
            get { return CheckBox2TemplateProperty.GetValue(this); }
            set { CheckBox2TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<InputField> InputProperty = new DependencyProperty<InputField>("Input");
        public InputField Input
        {
            get { return InputProperty.GetValue(this); }
            set { InputProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> InputTemplateProperty = new DependencyProperty<Template>("InputTemplate");
        public Template InputTemplate
        {
            get { return InputTemplateProperty.GetValue(this); }
            set { InputTemplateProperty.SetValue(this, value); }
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

        public readonly static DependencyProperty<InputField> Input1Property = new DependencyProperty<InputField>("Input1");
        public InputField Input1
        {
            get { return Input1Property.GetValue(this); }
            set { Input1Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Input1TemplateProperty = new DependencyProperty<Template>("Input1Template");
        public Template Input1Template
        {
            get { return Input1TemplateProperty.GetValue(this); }
            set { Input1TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<InputField> Input2Property = new DependencyProperty<InputField>("Input2");
        public InputField Input2
        {
            get { return Input2Property.GetValue(this); }
            set { Input2Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Input2TemplateProperty = new DependencyProperty<Template>("Input2Template");
        public Template Input2Template
        {
            get { return Input2TemplateProperty.GetValue(this); }
            set { Input2TemplateProperty.SetValue(this, value); }
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

        #endregion
    }

    #region Data Templates

    public static class TitleViewTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return TitleView;
            }
        }

        private static Template _titleView;
        public static Template TitleView
        {
            get
            {
#if UNITY_EDITOR
                if (_titleView == null || _titleView.CurrentVersion != Template.Version)
#else
                if (_titleView == null)
#endif
                {
                    _titleView = new Template(UIViewTemplates.UIView);
#if UNITY_EDITOR
                    _titleView.Name = "TitleView";
#endif
                    Delight.TitleView.CheckProperty.SetDefault(_titleView, true);
                    Delight.TitleView.Group1TemplateProperty.SetDefault(_titleView, TitleViewGroup1);
                    Delight.TitleView.Button1TemplateProperty.SetDefault(_titleView, TitleViewButton1);
                    Delight.TitleView.CheckBox1TemplateProperty.SetDefault(_titleView, TitleViewCheckBox1);
                    Delight.TitleView.CheckBox2TemplateProperty.SetDefault(_titleView, TitleViewCheckBox2);
                    Delight.TitleView.InputTemplateProperty.SetDefault(_titleView, TitleViewInput);
                    Delight.TitleView.Label1TemplateProperty.SetDefault(_titleView, TitleViewLabel1);
                    Delight.TitleView.Label2TemplateProperty.SetDefault(_titleView, TitleViewLabel2);
                    Delight.TitleView.Input1TemplateProperty.SetDefault(_titleView, TitleViewInput1);
                    Delight.TitleView.Input2TemplateProperty.SetDefault(_titleView, TitleViewInput2);
                    Delight.TitleView.Label3TemplateProperty.SetDefault(_titleView, TitleViewLabel3);
                }
                return _titleView;
            }
        }

        private static Template _titleViewGroup1;
        public static Template TitleViewGroup1
        {
            get
            {
#if UNITY_EDITOR
                if (_titleViewGroup1 == null || _titleViewGroup1.CurrentVersion != Template.Version)
#else
                if (_titleViewGroup1 == null)
#endif
                {
                    _titleViewGroup1 = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _titleViewGroup1.Name = "TitleViewGroup1";
#endif
                    Delight.Group.SpacingProperty.SetDefault(_titleViewGroup1, new ElementSize(5f, ElementSizeUnit.Pixels));
                }
                return _titleViewGroup1;
            }
        }

        private static Template _titleViewButton1;
        public static Template TitleViewButton1
        {
            get
            {
#if UNITY_EDITOR
                if (_titleViewButton1 == null || _titleViewButton1.CurrentVersion != Template.Version)
#else
                if (_titleViewButton1 == null)
#endif
                {
                    _titleViewButton1 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _titleViewButton1.Name = "TitleViewButton1";
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_titleViewButton1, TitleViewButton1Label);
                }
                return _titleViewButton1;
            }
        }

        private static Template _titleViewButton1Label;
        public static Template TitleViewButton1Label
        {
            get
            {
#if UNITY_EDITOR
                if (_titleViewButton1Label == null || _titleViewButton1Label.CurrentVersion != Template.Version)
#else
                if (_titleViewButton1Label == null)
#endif
                {
                    _titleViewButton1Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _titleViewButton1Label.Name = "TitleViewButton1Label";
#endif
                    Delight.Label.TextProperty.SetHasBinding(_titleViewButton1Label);
                }
                return _titleViewButton1Label;
            }
        }

        private static Template _titleViewCheckBox1;
        public static Template TitleViewCheckBox1
        {
            get
            {
#if UNITY_EDITOR
                if (_titleViewCheckBox1 == null || _titleViewCheckBox1.CurrentVersion != Template.Version)
#else
                if (_titleViewCheckBox1 == null)
#endif
                {
                    _titleViewCheckBox1 = new Template(CheckBoxTemplates.CheckBox);
#if UNITY_EDITOR
                    _titleViewCheckBox1.Name = "TitleViewCheckBox1";
#endif
                    Delight.CheckBox.IsCheckedProperty.SetHasBinding(_titleViewCheckBox1);
                    Delight.CheckBox.CheckBoxGroupTemplateProperty.SetDefault(_titleViewCheckBox1, TitleViewCheckBox1CheckBoxGroup);
                    Delight.CheckBox.CheckBoxImageViewTemplateProperty.SetDefault(_titleViewCheckBox1, TitleViewCheckBox1CheckBoxImageView);
                    Delight.CheckBox.CheckBoxLabelTemplateProperty.SetDefault(_titleViewCheckBox1, TitleViewCheckBox1CheckBoxLabel);
                }
                return _titleViewCheckBox1;
            }
        }

        private static Template _titleViewCheckBox1CheckBoxGroup;
        public static Template TitleViewCheckBox1CheckBoxGroup
        {
            get
            {
#if UNITY_EDITOR
                if (_titleViewCheckBox1CheckBoxGroup == null || _titleViewCheckBox1CheckBoxGroup.CurrentVersion != Template.Version)
#else
                if (_titleViewCheckBox1CheckBoxGroup == null)
#endif
                {
                    _titleViewCheckBox1CheckBoxGroup = new Template(CheckBoxTemplates.CheckBoxCheckBoxGroup);
#if UNITY_EDITOR
                    _titleViewCheckBox1CheckBoxGroup.Name = "TitleViewCheckBox1CheckBoxGroup";
#endif
                }
                return _titleViewCheckBox1CheckBoxGroup;
            }
        }

        private static Template _titleViewCheckBox1CheckBoxImageView;
        public static Template TitleViewCheckBox1CheckBoxImageView
        {
            get
            {
#if UNITY_EDITOR
                if (_titleViewCheckBox1CheckBoxImageView == null || _titleViewCheckBox1CheckBoxImageView.CurrentVersion != Template.Version)
#else
                if (_titleViewCheckBox1CheckBoxImageView == null)
#endif
                {
                    _titleViewCheckBox1CheckBoxImageView = new Template(CheckBoxTemplates.CheckBoxCheckBoxImageView);
#if UNITY_EDITOR
                    _titleViewCheckBox1CheckBoxImageView.Name = "TitleViewCheckBox1CheckBoxImageView";
#endif
                }
                return _titleViewCheckBox1CheckBoxImageView;
            }
        }

        private static Template _titleViewCheckBox1CheckBoxLabel;
        public static Template TitleViewCheckBox1CheckBoxLabel
        {
            get
            {
#if UNITY_EDITOR
                if (_titleViewCheckBox1CheckBoxLabel == null || _titleViewCheckBox1CheckBoxLabel.CurrentVersion != Template.Version)
#else
                if (_titleViewCheckBox1CheckBoxLabel == null)
#endif
                {
                    _titleViewCheckBox1CheckBoxLabel = new Template(CheckBoxTemplates.CheckBoxCheckBoxLabel);
#if UNITY_EDITOR
                    _titleViewCheckBox1CheckBoxLabel.Name = "TitleViewCheckBox1CheckBoxLabel";
#endif
                    Delight.Label.TextProperty.SetDefault(_titleViewCheckBox1CheckBoxLabel, "Check");
                }
                return _titleViewCheckBox1CheckBoxLabel;
            }
        }

        private static Template _titleViewCheckBox2;
        public static Template TitleViewCheckBox2
        {
            get
            {
#if UNITY_EDITOR
                if (_titleViewCheckBox2 == null || _titleViewCheckBox2.CurrentVersion != Template.Version)
#else
                if (_titleViewCheckBox2 == null)
#endif
                {
                    _titleViewCheckBox2 = new Template(CheckBoxTemplates.CheckBox);
#if UNITY_EDITOR
                    _titleViewCheckBox2.Name = "TitleViewCheckBox2";
#endif
                    Delight.CheckBox.IsCheckedProperty.SetHasBinding(_titleViewCheckBox2);
                    Delight.CheckBox.CheckBoxGroupTemplateProperty.SetDefault(_titleViewCheckBox2, TitleViewCheckBox2CheckBoxGroup);
                    Delight.CheckBox.CheckBoxImageViewTemplateProperty.SetDefault(_titleViewCheckBox2, TitleViewCheckBox2CheckBoxImageView);
                    Delight.CheckBox.CheckBoxLabelTemplateProperty.SetDefault(_titleViewCheckBox2, TitleViewCheckBox2CheckBoxLabel);
                }
                return _titleViewCheckBox2;
            }
        }

        private static Template _titleViewCheckBox2CheckBoxGroup;
        public static Template TitleViewCheckBox2CheckBoxGroup
        {
            get
            {
#if UNITY_EDITOR
                if (_titleViewCheckBox2CheckBoxGroup == null || _titleViewCheckBox2CheckBoxGroup.CurrentVersion != Template.Version)
#else
                if (_titleViewCheckBox2CheckBoxGroup == null)
#endif
                {
                    _titleViewCheckBox2CheckBoxGroup = new Template(CheckBoxTemplates.CheckBoxCheckBoxGroup);
#if UNITY_EDITOR
                    _titleViewCheckBox2CheckBoxGroup.Name = "TitleViewCheckBox2CheckBoxGroup";
#endif
                }
                return _titleViewCheckBox2CheckBoxGroup;
            }
        }

        private static Template _titleViewCheckBox2CheckBoxImageView;
        public static Template TitleViewCheckBox2CheckBoxImageView
        {
            get
            {
#if UNITY_EDITOR
                if (_titleViewCheckBox2CheckBoxImageView == null || _titleViewCheckBox2CheckBoxImageView.CurrentVersion != Template.Version)
#else
                if (_titleViewCheckBox2CheckBoxImageView == null)
#endif
                {
                    _titleViewCheckBox2CheckBoxImageView = new Template(CheckBoxTemplates.CheckBoxCheckBoxImageView);
#if UNITY_EDITOR
                    _titleViewCheckBox2CheckBoxImageView.Name = "TitleViewCheckBox2CheckBoxImageView";
#endif
                }
                return _titleViewCheckBox2CheckBoxImageView;
            }
        }

        private static Template _titleViewCheckBox2CheckBoxLabel;
        public static Template TitleViewCheckBox2CheckBoxLabel
        {
            get
            {
#if UNITY_EDITOR
                if (_titleViewCheckBox2CheckBoxLabel == null || _titleViewCheckBox2CheckBoxLabel.CurrentVersion != Template.Version)
#else
                if (_titleViewCheckBox2CheckBoxLabel == null)
#endif
                {
                    _titleViewCheckBox2CheckBoxLabel = new Template(CheckBoxTemplates.CheckBoxCheckBoxLabel);
#if UNITY_EDITOR
                    _titleViewCheckBox2CheckBoxLabel.Name = "TitleViewCheckBox2CheckBoxLabel";
#endif
                    Delight.Label.TextProperty.SetDefault(_titleViewCheckBox2CheckBoxLabel, "Check");
                }
                return _titleViewCheckBox2CheckBoxLabel;
            }
        }

        private static Template _titleViewInput;
        public static Template TitleViewInput
        {
            get
            {
#if UNITY_EDITOR
                if (_titleViewInput == null || _titleViewInput.CurrentVersion != Template.Version)
#else
                if (_titleViewInput == null)
#endif
                {
                    _titleViewInput = new Template(InputFieldTemplates.InputField);
#if UNITY_EDITOR
                    _titleViewInput.Name = "TitleViewInput";
#endif
                    Delight.InputField.TextProperty.SetDefault(_titleViewInput, "Test 3");
                    Delight.InputField.InputFieldPlaceholderTemplateProperty.SetDefault(_titleViewInput, TitleViewInputInputFieldPlaceholder);
                    Delight.InputField.TextAreaTemplateProperty.SetDefault(_titleViewInput, TitleViewInputTextArea);
                    Delight.InputField.InputTextTemplateProperty.SetDefault(_titleViewInput, TitleViewInputInputText);
                }
                return _titleViewInput;
            }
        }

        private static Template _titleViewInputInputFieldPlaceholder;
        public static Template TitleViewInputInputFieldPlaceholder
        {
            get
            {
#if UNITY_EDITOR
                if (_titleViewInputInputFieldPlaceholder == null || _titleViewInputInputFieldPlaceholder.CurrentVersion != Template.Version)
#else
                if (_titleViewInputInputFieldPlaceholder == null)
#endif
                {
                    _titleViewInputInputFieldPlaceholder = new Template(InputFieldTemplates.InputFieldInputFieldPlaceholder);
#if UNITY_EDITOR
                    _titleViewInputInputFieldPlaceholder.Name = "TitleViewInputInputFieldPlaceholder";
#endif
                }
                return _titleViewInputInputFieldPlaceholder;
            }
        }

        private static Template _titleViewInputTextArea;
        public static Template TitleViewInputTextArea
        {
            get
            {
#if UNITY_EDITOR
                if (_titleViewInputTextArea == null || _titleViewInputTextArea.CurrentVersion != Template.Version)
#else
                if (_titleViewInputTextArea == null)
#endif
                {
                    _titleViewInputTextArea = new Template(InputFieldTemplates.InputFieldTextArea);
#if UNITY_EDITOR
                    _titleViewInputTextArea.Name = "TitleViewInputTextArea";
#endif
                }
                return _titleViewInputTextArea;
            }
        }

        private static Template _titleViewInputInputText;
        public static Template TitleViewInputInputText
        {
            get
            {
#if UNITY_EDITOR
                if (_titleViewInputInputText == null || _titleViewInputInputText.CurrentVersion != Template.Version)
#else
                if (_titleViewInputInputText == null)
#endif
                {
                    _titleViewInputInputText = new Template(InputFieldTemplates.InputFieldInputText);
#if UNITY_EDITOR
                    _titleViewInputInputText.Name = "TitleViewInputInputText";
#endif
                }
                return _titleViewInputInputText;
            }
        }

        private static Template _titleViewLabel1;
        public static Template TitleViewLabel1
        {
            get
            {
#if UNITY_EDITOR
                if (_titleViewLabel1 == null || _titleViewLabel1.CurrentVersion != Template.Version)
#else
                if (_titleViewLabel1 == null)
#endif
                {
                    _titleViewLabel1 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _titleViewLabel1.Name = "TitleViewLabel1";
#endif
                    Delight.Label.TextProperty.SetHasBinding(_titleViewLabel1);
                }
                return _titleViewLabel1;
            }
        }

        private static Template _titleViewLabel2;
        public static Template TitleViewLabel2
        {
            get
            {
#if UNITY_EDITOR
                if (_titleViewLabel2 == null || _titleViewLabel2.CurrentVersion != Template.Version)
#else
                if (_titleViewLabel2 == null)
#endif
                {
                    _titleViewLabel2 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _titleViewLabel2.Name = "TitleViewLabel2";
#endif
                    Delight.Label.TextProperty.SetHasBinding(_titleViewLabel2);
                }
                return _titleViewLabel2;
            }
        }

        private static Template _titleViewInput1;
        public static Template TitleViewInput1
        {
            get
            {
#if UNITY_EDITOR
                if (_titleViewInput1 == null || _titleViewInput1.CurrentVersion != Template.Version)
#else
                if (_titleViewInput1 == null)
#endif
                {
                    _titleViewInput1 = new Template(InputFieldTemplates.InputField);
#if UNITY_EDITOR
                    _titleViewInput1.Name = "TitleViewInput1";
#endif
                    Delight.InputField.InputFieldPlaceholderTemplateProperty.SetDefault(_titleViewInput1, TitleViewInput1InputFieldPlaceholder);
                    Delight.InputField.TextAreaTemplateProperty.SetDefault(_titleViewInput1, TitleViewInput1TextArea);
                    Delight.InputField.InputTextTemplateProperty.SetDefault(_titleViewInput1, TitleViewInput1InputText);
                }
                return _titleViewInput1;
            }
        }

        private static Template _titleViewInput1InputFieldPlaceholder;
        public static Template TitleViewInput1InputFieldPlaceholder
        {
            get
            {
#if UNITY_EDITOR
                if (_titleViewInput1InputFieldPlaceholder == null || _titleViewInput1InputFieldPlaceholder.CurrentVersion != Template.Version)
#else
                if (_titleViewInput1InputFieldPlaceholder == null)
#endif
                {
                    _titleViewInput1InputFieldPlaceholder = new Template(InputFieldTemplates.InputFieldInputFieldPlaceholder);
#if UNITY_EDITOR
                    _titleViewInput1InputFieldPlaceholder.Name = "TitleViewInput1InputFieldPlaceholder";
#endif
                }
                return _titleViewInput1InputFieldPlaceholder;
            }
        }

        private static Template _titleViewInput1TextArea;
        public static Template TitleViewInput1TextArea
        {
            get
            {
#if UNITY_EDITOR
                if (_titleViewInput1TextArea == null || _titleViewInput1TextArea.CurrentVersion != Template.Version)
#else
                if (_titleViewInput1TextArea == null)
#endif
                {
                    _titleViewInput1TextArea = new Template(InputFieldTemplates.InputFieldTextArea);
#if UNITY_EDITOR
                    _titleViewInput1TextArea.Name = "TitleViewInput1TextArea";
#endif
                }
                return _titleViewInput1TextArea;
            }
        }

        private static Template _titleViewInput1InputText;
        public static Template TitleViewInput1InputText
        {
            get
            {
#if UNITY_EDITOR
                if (_titleViewInput1InputText == null || _titleViewInput1InputText.CurrentVersion != Template.Version)
#else
                if (_titleViewInput1InputText == null)
#endif
                {
                    _titleViewInput1InputText = new Template(InputFieldTemplates.InputFieldInputText);
#if UNITY_EDITOR
                    _titleViewInput1InputText.Name = "TitleViewInput1InputText";
#endif
                }
                return _titleViewInput1InputText;
            }
        }

        private static Template _titleViewInput2;
        public static Template TitleViewInput2
        {
            get
            {
#if UNITY_EDITOR
                if (_titleViewInput2 == null || _titleViewInput2.CurrentVersion != Template.Version)
#else
                if (_titleViewInput2 == null)
#endif
                {
                    _titleViewInput2 = new Template(InputFieldTemplates.InputField);
#if UNITY_EDITOR
                    _titleViewInput2.Name = "TitleViewInput2";
#endif
                    Delight.InputField.InputFieldPlaceholderTemplateProperty.SetDefault(_titleViewInput2, TitleViewInput2InputFieldPlaceholder);
                    Delight.InputField.TextAreaTemplateProperty.SetDefault(_titleViewInput2, TitleViewInput2TextArea);
                    Delight.InputField.InputTextTemplateProperty.SetDefault(_titleViewInput2, TitleViewInput2InputText);
                }
                return _titleViewInput2;
            }
        }

        private static Template _titleViewInput2InputFieldPlaceholder;
        public static Template TitleViewInput2InputFieldPlaceholder
        {
            get
            {
#if UNITY_EDITOR
                if (_titleViewInput2InputFieldPlaceholder == null || _titleViewInput2InputFieldPlaceholder.CurrentVersion != Template.Version)
#else
                if (_titleViewInput2InputFieldPlaceholder == null)
#endif
                {
                    _titleViewInput2InputFieldPlaceholder = new Template(InputFieldTemplates.InputFieldInputFieldPlaceholder);
#if UNITY_EDITOR
                    _titleViewInput2InputFieldPlaceholder.Name = "TitleViewInput2InputFieldPlaceholder";
#endif
                }
                return _titleViewInput2InputFieldPlaceholder;
            }
        }

        private static Template _titleViewInput2TextArea;
        public static Template TitleViewInput2TextArea
        {
            get
            {
#if UNITY_EDITOR
                if (_titleViewInput2TextArea == null || _titleViewInput2TextArea.CurrentVersion != Template.Version)
#else
                if (_titleViewInput2TextArea == null)
#endif
                {
                    _titleViewInput2TextArea = new Template(InputFieldTemplates.InputFieldTextArea);
#if UNITY_EDITOR
                    _titleViewInput2TextArea.Name = "TitleViewInput2TextArea";
#endif
                }
                return _titleViewInput2TextArea;
            }
        }

        private static Template _titleViewInput2InputText;
        public static Template TitleViewInput2InputText
        {
            get
            {
#if UNITY_EDITOR
                if (_titleViewInput2InputText == null || _titleViewInput2InputText.CurrentVersion != Template.Version)
#else
                if (_titleViewInput2InputText == null)
#endif
                {
                    _titleViewInput2InputText = new Template(InputFieldTemplates.InputFieldInputText);
#if UNITY_EDITOR
                    _titleViewInput2InputText.Name = "TitleViewInput2InputText";
#endif
                }
                return _titleViewInput2InputText;
            }
        }

        private static Template _titleViewLabel3;
        public static Template TitleViewLabel3
        {
            get
            {
#if UNITY_EDITOR
                if (_titleViewLabel3 == null || _titleViewLabel3.CurrentVersion != Template.Version)
#else
                if (_titleViewLabel3 == null)
#endif
                {
                    _titleViewLabel3 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _titleViewLabel3.Name = "TitleViewLabel3";
#endif
                    Delight.Label.TextProperty.SetHasBinding(_titleViewLabel3);
                }
                return _titleViewLabel3;
            }
        }

        #endregion
    }

    #endregion
}
