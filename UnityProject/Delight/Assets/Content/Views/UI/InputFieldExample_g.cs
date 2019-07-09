// Internal view logic generated from "InputFieldExample.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class InputFieldExample : UIView
    {
        #region Constructors

        public InputFieldExample(View parent, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :
            base(parent, layoutParent, id, template ?? InputFieldExampleTemplates.Default, initializer)
        {
            // constructing Group (Group1)
            Group1 = new Group(this, this, "Group1", Group1Template);
            Group2 = new Group(this, Group1.Content, "Group2", Group2Template);
            Label1 = new Label(this, Group2.Content, "Label1", Label1Template);
            Label2 = new Label(this, Group2.Content, "Label2", Label2Template);
            InputField1 = new InputField(this, Group2.Content, "InputField1", InputField1Template);
            Label3 = new Label(this, Group2.Content, "Label3", Label3Template);
            InputField2 = new InputField(this, Group2.Content, "InputField2", InputField2Template);
            Label4 = new Label(this, Group2.Content, "Label4", Label4Template);
            InputField3 = new InputField(this, Group2.Content, "InputField3", InputField3Template);
            InputField3.ValueChanged.RegisterHandler(this, "OnValueChanged");
            Image1 = new Image(this, InputField3.Content, "Image1", Image1Template);
            Group3 = new Group(this, Group1.Content, "Group3", Group3Template);
            Label5 = new Label(this, Group3.Content, "Label5", Label5Template);
            InputField4 = new InputField(this, Group3.Content, "InputField4", InputField4Template);
            this.AfterInitializeInternal();
        }

        public InputFieldExample() : this(null)
        {
        }

        static InputFieldExample()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(InputFieldExampleTemplates.Default, dependencyProperties);

            dependencyProperties.Add(Group1Property);
            dependencyProperties.Add(Group1TemplateProperty);
            dependencyProperties.Add(Group2Property);
            dependencyProperties.Add(Group2TemplateProperty);
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
            dependencyProperties.Add(Label4Property);
            dependencyProperties.Add(Label4TemplateProperty);
            dependencyProperties.Add(InputField3Property);
            dependencyProperties.Add(InputField3TemplateProperty);
            dependencyProperties.Add(Image1Property);
            dependencyProperties.Add(Image1TemplateProperty);
            dependencyProperties.Add(Group3Property);
            dependencyProperties.Add(Group3TemplateProperty);
            dependencyProperties.Add(Label5Property);
            dependencyProperties.Add(Label5TemplateProperty);
            dependencyProperties.Add(InputField4Property);
            dependencyProperties.Add(InputField4TemplateProperty);
        }

        #endregion

        #region Properties

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

        public readonly static DependencyProperty<InputField> InputField3Property = new DependencyProperty<InputField>("InputField3");
        public InputField InputField3
        {
            get { return InputField3Property.GetValue(this); }
            set { InputField3Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> InputField3TemplateProperty = new DependencyProperty<Template>("InputField3Template");
        public Template InputField3Template
        {
            get { return InputField3TemplateProperty.GetValue(this); }
            set { InputField3TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Image> Image1Property = new DependencyProperty<Image>("Image1");
        public Image Image1
        {
            get { return Image1Property.GetValue(this); }
            set { Image1Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Image1TemplateProperty = new DependencyProperty<Template>("Image1Template");
        public Template Image1Template
        {
            get { return Image1TemplateProperty.GetValue(this); }
            set { Image1TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Group> Group3Property = new DependencyProperty<Group>("Group3");
        public Group Group3
        {
            get { return Group3Property.GetValue(this); }
            set { Group3Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Group3TemplateProperty = new DependencyProperty<Template>("Group3Template");
        public Template Group3Template
        {
            get { return Group3TemplateProperty.GetValue(this); }
            set { Group3TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Label> Label5Property = new DependencyProperty<Label>("Label5");
        public Label Label5
        {
            get { return Label5Property.GetValue(this); }
            set { Label5Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Label5TemplateProperty = new DependencyProperty<Template>("Label5Template");
        public Template Label5Template
        {
            get { return Label5TemplateProperty.GetValue(this); }
            set { Label5TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<InputField> InputField4Property = new DependencyProperty<InputField>("InputField4");
        public InputField InputField4
        {
            get { return InputField4Property.GetValue(this); }
            set { InputField4Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> InputField4TemplateProperty = new DependencyProperty<Template>("InputField4Template");
        public Template InputField4Template
        {
            get { return InputField4TemplateProperty.GetValue(this); }
            set { InputField4TemplateProperty.SetValue(this, value); }
        }

        #endregion
    }

    #region Data Templates

    public static class InputFieldExampleTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return InputFieldExample;
            }
        }

        private static Template _inputFieldExample;
        public static Template InputFieldExample
        {
            get
            {
#if UNITY_EDITOR
                if (_inputFieldExample == null || _inputFieldExample.CurrentVersion != Template.Version)
#else
                if (_inputFieldExample == null)
#endif
                {
                    _inputFieldExample = new Template(UIViewTemplates.UIView);
#if UNITY_EDITOR
                    _inputFieldExample.Name = "InputFieldExample";
#endif
                    Delight.InputFieldExample.Group1TemplateProperty.SetDefault(_inputFieldExample, InputFieldExampleGroup1);
                    Delight.InputFieldExample.Group2TemplateProperty.SetDefault(_inputFieldExample, InputFieldExampleGroup2);
                    Delight.InputFieldExample.Label1TemplateProperty.SetDefault(_inputFieldExample, InputFieldExampleLabel1);
                    Delight.InputFieldExample.Label2TemplateProperty.SetDefault(_inputFieldExample, InputFieldExampleLabel2);
                    Delight.InputFieldExample.InputField1TemplateProperty.SetDefault(_inputFieldExample, InputFieldExampleInputField1);
                    Delight.InputFieldExample.Label3TemplateProperty.SetDefault(_inputFieldExample, InputFieldExampleLabel3);
                    Delight.InputFieldExample.InputField2TemplateProperty.SetDefault(_inputFieldExample, InputFieldExampleInputField2);
                    Delight.InputFieldExample.Label4TemplateProperty.SetDefault(_inputFieldExample, InputFieldExampleLabel4);
                    Delight.InputFieldExample.InputField3TemplateProperty.SetDefault(_inputFieldExample, InputFieldExampleInputField3);
                    Delight.InputFieldExample.Image1TemplateProperty.SetDefault(_inputFieldExample, InputFieldExampleImage1);
                    Delight.InputFieldExample.Group3TemplateProperty.SetDefault(_inputFieldExample, InputFieldExampleGroup3);
                    Delight.InputFieldExample.Label5TemplateProperty.SetDefault(_inputFieldExample, InputFieldExampleLabel5);
                    Delight.InputFieldExample.InputField4TemplateProperty.SetDefault(_inputFieldExample, InputFieldExampleInputField4);
                }
                return _inputFieldExample;
            }
        }

        private static Template _inputFieldExampleGroup1;
        public static Template InputFieldExampleGroup1
        {
            get
            {
#if UNITY_EDITOR
                if (_inputFieldExampleGroup1 == null || _inputFieldExampleGroup1.CurrentVersion != Template.Version)
#else
                if (_inputFieldExampleGroup1 == null)
#endif
                {
                    _inputFieldExampleGroup1 = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _inputFieldExampleGroup1.Name = "InputFieldExampleGroup1";
#endif
                    Delight.Group.OrientationProperty.SetDefault(_inputFieldExampleGroup1, Delight.ElementOrientation.Horizontal);
                    Delight.Group.SpacingProperty.SetDefault(_inputFieldExampleGroup1, new ElementSize(30f, ElementSizeUnit.Pixels));
                    Delight.Group.ContentAlignmentProperty.SetDefault(_inputFieldExampleGroup1, Delight.ElementAlignment.Top);
                }
                return _inputFieldExampleGroup1;
            }
        }

        private static Template _inputFieldExampleGroup2;
        public static Template InputFieldExampleGroup2
        {
            get
            {
#if UNITY_EDITOR
                if (_inputFieldExampleGroup2 == null || _inputFieldExampleGroup2.CurrentVersion != Template.Version)
#else
                if (_inputFieldExampleGroup2 == null)
#endif
                {
                    _inputFieldExampleGroup2 = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _inputFieldExampleGroup2.Name = "InputFieldExampleGroup2";
#endif
                    Delight.Group.OrientationProperty.SetDefault(_inputFieldExampleGroup2, Delight.ElementOrientation.Vertical);
                    Delight.Group.SpacingProperty.SetDefault(_inputFieldExampleGroup2, new ElementSize(6f, ElementSizeUnit.Pixels));
                }
                return _inputFieldExampleGroup2;
            }
        }

        private static Template _inputFieldExampleLabel1;
        public static Template InputFieldExampleLabel1
        {
            get
            {
#if UNITY_EDITOR
                if (_inputFieldExampleLabel1 == null || _inputFieldExampleLabel1.CurrentVersion != Template.Version)
#else
                if (_inputFieldExampleLabel1 == null)
#endif
                {
                    _inputFieldExampleLabel1 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _inputFieldExampleLabel1.Name = "InputFieldExampleLabel1";
#endif
                    Delight.Label.TextProperty.SetDefault(_inputFieldExampleLabel1, "Single Line");
                    Delight.Label.AutoSizeProperty.SetDefault(_inputFieldExampleLabel1, Delight.AutoSize.Width);
                }
                return _inputFieldExampleLabel1;
            }
        }

        private static Template _inputFieldExampleLabel2;
        public static Template InputFieldExampleLabel2
        {
            get
            {
#if UNITY_EDITOR
                if (_inputFieldExampleLabel2 == null || _inputFieldExampleLabel2.CurrentVersion != Template.Version)
#else
                if (_inputFieldExampleLabel2 == null)
#endif
                {
                    _inputFieldExampleLabel2 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _inputFieldExampleLabel2.Name = "InputFieldExampleLabel2";
#endif
                    Delight.Label.TextProperty.SetDefault(_inputFieldExampleLabel2, "Normal");
                    Delight.Label.AutoSizeProperty.SetDefault(_inputFieldExampleLabel2, Delight.AutoSize.Width);
                    Delight.Label.FontSizeProperty.SetDefault(_inputFieldExampleLabel2, 12);
                    Delight.Label.HeightProperty.SetDefault(_inputFieldExampleLabel2, new ElementSize(20f, ElementSizeUnit.Pixels));
                }
                return _inputFieldExampleLabel2;
            }
        }

        private static Template _inputFieldExampleInputField1;
        public static Template InputFieldExampleInputField1
        {
            get
            {
#if UNITY_EDITOR
                if (_inputFieldExampleInputField1 == null || _inputFieldExampleInputField1.CurrentVersion != Template.Version)
#else
                if (_inputFieldExampleInputField1 == null)
#endif
                {
                    _inputFieldExampleInputField1 = new Template(InputFieldTemplates.InputField);
#if UNITY_EDITOR
                    _inputFieldExampleInputField1.Name = "InputFieldExampleInputField1";
#endif
                    Delight.InputField.WidthProperty.SetDefault(_inputFieldExampleInputField1, new ElementSize(200f, ElementSizeUnit.Pixels));
                    Delight.InputField.InputFieldPlaceholderTemplateProperty.SetDefault(_inputFieldExampleInputField1, InputFieldExampleInputField1InputFieldPlaceholder);
                    Delight.InputField.TextAreaTemplateProperty.SetDefault(_inputFieldExampleInputField1, InputFieldExampleInputField1TextArea);
                    Delight.InputField.InputTextTemplateProperty.SetDefault(_inputFieldExampleInputField1, InputFieldExampleInputField1InputText);
                }
                return _inputFieldExampleInputField1;
            }
        }

        private static Template _inputFieldExampleInputField1InputFieldPlaceholder;
        public static Template InputFieldExampleInputField1InputFieldPlaceholder
        {
            get
            {
#if UNITY_EDITOR
                if (_inputFieldExampleInputField1InputFieldPlaceholder == null || _inputFieldExampleInputField1InputFieldPlaceholder.CurrentVersion != Template.Version)
#else
                if (_inputFieldExampleInputField1InputFieldPlaceholder == null)
#endif
                {
                    _inputFieldExampleInputField1InputFieldPlaceholder = new Template(InputFieldTemplates.InputFieldInputFieldPlaceholder);
#if UNITY_EDITOR
                    _inputFieldExampleInputField1InputFieldPlaceholder.Name = "InputFieldExampleInputField1InputFieldPlaceholder";
#endif
                }
                return _inputFieldExampleInputField1InputFieldPlaceholder;
            }
        }

        private static Template _inputFieldExampleInputField1TextArea;
        public static Template InputFieldExampleInputField1TextArea
        {
            get
            {
#if UNITY_EDITOR
                if (_inputFieldExampleInputField1TextArea == null || _inputFieldExampleInputField1TextArea.CurrentVersion != Template.Version)
#else
                if (_inputFieldExampleInputField1TextArea == null)
#endif
                {
                    _inputFieldExampleInputField1TextArea = new Template(InputFieldTemplates.InputFieldTextArea);
#if UNITY_EDITOR
                    _inputFieldExampleInputField1TextArea.Name = "InputFieldExampleInputField1TextArea";
#endif
                }
                return _inputFieldExampleInputField1TextArea;
            }
        }

        private static Template _inputFieldExampleInputField1InputText;
        public static Template InputFieldExampleInputField1InputText
        {
            get
            {
#if UNITY_EDITOR
                if (_inputFieldExampleInputField1InputText == null || _inputFieldExampleInputField1InputText.CurrentVersion != Template.Version)
#else
                if (_inputFieldExampleInputField1InputText == null)
#endif
                {
                    _inputFieldExampleInputField1InputText = new Template(InputFieldTemplates.InputFieldInputText);
#if UNITY_EDITOR
                    _inputFieldExampleInputField1InputText.Name = "InputFieldExampleInputField1InputText";
#endif
                }
                return _inputFieldExampleInputField1InputText;
            }
        }

        private static Template _inputFieldExampleLabel3;
        public static Template InputFieldExampleLabel3
        {
            get
            {
#if UNITY_EDITOR
                if (_inputFieldExampleLabel3 == null || _inputFieldExampleLabel3.CurrentVersion != Template.Version)
#else
                if (_inputFieldExampleLabel3 == null)
#endif
                {
                    _inputFieldExampleLabel3 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _inputFieldExampleLabel3.Name = "InputFieldExampleLabel3";
#endif
                    Delight.Label.TextProperty.SetDefault(_inputFieldExampleLabel3, "Password");
                    Delight.Label.AutoSizeProperty.SetDefault(_inputFieldExampleLabel3, Delight.AutoSize.Default);
                    Delight.Label.FontSizeProperty.SetDefault(_inputFieldExampleLabel3, 12);
                    Delight.Label.HeightProperty.SetDefault(_inputFieldExampleLabel3, new ElementSize(20f, ElementSizeUnit.Pixels));
                }
                return _inputFieldExampleLabel3;
            }
        }

        private static Template _inputFieldExampleInputField2;
        public static Template InputFieldExampleInputField2
        {
            get
            {
#if UNITY_EDITOR
                if (_inputFieldExampleInputField2 == null || _inputFieldExampleInputField2.CurrentVersion != Template.Version)
#else
                if (_inputFieldExampleInputField2 == null)
#endif
                {
                    _inputFieldExampleInputField2 = new Template(InputFieldTemplates.InputField);
#if UNITY_EDITOR
                    _inputFieldExampleInputField2.Name = "InputFieldExampleInputField2";
#endif
                    Delight.InputField.WidthProperty.SetDefault(_inputFieldExampleInputField2, new ElementSize(200f, ElementSizeUnit.Pixels));
                    Delight.InputField.ContentTypeProperty.SetDefault(_inputFieldExampleInputField2, UnityEngine.UI.InputField.ContentType.Password);
                    Delight.InputField.InputFieldPlaceholderTemplateProperty.SetDefault(_inputFieldExampleInputField2, InputFieldExampleInputField2InputFieldPlaceholder);
                    Delight.InputField.TextAreaTemplateProperty.SetDefault(_inputFieldExampleInputField2, InputFieldExampleInputField2TextArea);
                    Delight.InputField.InputTextTemplateProperty.SetDefault(_inputFieldExampleInputField2, InputFieldExampleInputField2InputText);
                }
                return _inputFieldExampleInputField2;
            }
        }

        private static Template _inputFieldExampleInputField2InputFieldPlaceholder;
        public static Template InputFieldExampleInputField2InputFieldPlaceholder
        {
            get
            {
#if UNITY_EDITOR
                if (_inputFieldExampleInputField2InputFieldPlaceholder == null || _inputFieldExampleInputField2InputFieldPlaceholder.CurrentVersion != Template.Version)
#else
                if (_inputFieldExampleInputField2InputFieldPlaceholder == null)
#endif
                {
                    _inputFieldExampleInputField2InputFieldPlaceholder = new Template(InputFieldTemplates.InputFieldInputFieldPlaceholder);
#if UNITY_EDITOR
                    _inputFieldExampleInputField2InputFieldPlaceholder.Name = "InputFieldExampleInputField2InputFieldPlaceholder";
#endif
                }
                return _inputFieldExampleInputField2InputFieldPlaceholder;
            }
        }

        private static Template _inputFieldExampleInputField2TextArea;
        public static Template InputFieldExampleInputField2TextArea
        {
            get
            {
#if UNITY_EDITOR
                if (_inputFieldExampleInputField2TextArea == null || _inputFieldExampleInputField2TextArea.CurrentVersion != Template.Version)
#else
                if (_inputFieldExampleInputField2TextArea == null)
#endif
                {
                    _inputFieldExampleInputField2TextArea = new Template(InputFieldTemplates.InputFieldTextArea);
#if UNITY_EDITOR
                    _inputFieldExampleInputField2TextArea.Name = "InputFieldExampleInputField2TextArea";
#endif
                }
                return _inputFieldExampleInputField2TextArea;
            }
        }

        private static Template _inputFieldExampleInputField2InputText;
        public static Template InputFieldExampleInputField2InputText
        {
            get
            {
#if UNITY_EDITOR
                if (_inputFieldExampleInputField2InputText == null || _inputFieldExampleInputField2InputText.CurrentVersion != Template.Version)
#else
                if (_inputFieldExampleInputField2InputText == null)
#endif
                {
                    _inputFieldExampleInputField2InputText = new Template(InputFieldTemplates.InputFieldInputText);
#if UNITY_EDITOR
                    _inputFieldExampleInputField2InputText.Name = "InputFieldExampleInputField2InputText";
#endif
                }
                return _inputFieldExampleInputField2InputText;
            }
        }

        private static Template _inputFieldExampleLabel4;
        public static Template InputFieldExampleLabel4
        {
            get
            {
#if UNITY_EDITOR
                if (_inputFieldExampleLabel4 == null || _inputFieldExampleLabel4.CurrentVersion != Template.Version)
#else
                if (_inputFieldExampleLabel4 == null)
#endif
                {
                    _inputFieldExampleLabel4 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _inputFieldExampleLabel4.Name = "InputFieldExampleLabel4";
#endif
                    Delight.Label.TextProperty.SetDefault(_inputFieldExampleLabel4, "With placeholder content");
                    Delight.Label.AutoSizeProperty.SetDefault(_inputFieldExampleLabel4, Delight.AutoSize.Default);
                    Delight.Label.FontSizeProperty.SetDefault(_inputFieldExampleLabel4, 12);
                    Delight.Label.HeightProperty.SetDefault(_inputFieldExampleLabel4, new ElementSize(20f, ElementSizeUnit.Pixels));
                }
                return _inputFieldExampleLabel4;
            }
        }

        private static Template _inputFieldExampleInputField3;
        public static Template InputFieldExampleInputField3
        {
            get
            {
#if UNITY_EDITOR
                if (_inputFieldExampleInputField3 == null || _inputFieldExampleInputField3.CurrentVersion != Template.Version)
#else
                if (_inputFieldExampleInputField3 == null)
#endif
                {
                    _inputFieldExampleInputField3 = new Template(InputFieldTemplates.InputField);
#if UNITY_EDITOR
                    _inputFieldExampleInputField3.Name = "InputFieldExampleInputField3";
#endif
                    Delight.InputField.WidthProperty.SetDefault(_inputFieldExampleInputField3, new ElementSize(200f, ElementSizeUnit.Pixels));
                    Delight.InputField.InputFieldPlaceholderTemplateProperty.SetDefault(_inputFieldExampleInputField3, InputFieldExampleInputField3InputFieldPlaceholder);
                    Delight.InputField.TextAreaTemplateProperty.SetDefault(_inputFieldExampleInputField3, InputFieldExampleInputField3TextArea);
                    Delight.InputField.InputTextTemplateProperty.SetDefault(_inputFieldExampleInputField3, InputFieldExampleInputField3InputText);
                }
                return _inputFieldExampleInputField3;
            }
        }

        private static Template _inputFieldExampleInputField3InputFieldPlaceholder;
        public static Template InputFieldExampleInputField3InputFieldPlaceholder
        {
            get
            {
#if UNITY_EDITOR
                if (_inputFieldExampleInputField3InputFieldPlaceholder == null || _inputFieldExampleInputField3InputFieldPlaceholder.CurrentVersion != Template.Version)
#else
                if (_inputFieldExampleInputField3InputFieldPlaceholder == null)
#endif
                {
                    _inputFieldExampleInputField3InputFieldPlaceholder = new Template(InputFieldTemplates.InputFieldInputFieldPlaceholder);
#if UNITY_EDITOR
                    _inputFieldExampleInputField3InputFieldPlaceholder.Name = "InputFieldExampleInputField3InputFieldPlaceholder";
#endif
                }
                return _inputFieldExampleInputField3InputFieldPlaceholder;
            }
        }

        private static Template _inputFieldExampleInputField3TextArea;
        public static Template InputFieldExampleInputField3TextArea
        {
            get
            {
#if UNITY_EDITOR
                if (_inputFieldExampleInputField3TextArea == null || _inputFieldExampleInputField3TextArea.CurrentVersion != Template.Version)
#else
                if (_inputFieldExampleInputField3TextArea == null)
#endif
                {
                    _inputFieldExampleInputField3TextArea = new Template(InputFieldTemplates.InputFieldTextArea);
#if UNITY_EDITOR
                    _inputFieldExampleInputField3TextArea.Name = "InputFieldExampleInputField3TextArea";
#endif
                }
                return _inputFieldExampleInputField3TextArea;
            }
        }

        private static Template _inputFieldExampleInputField3InputText;
        public static Template InputFieldExampleInputField3InputText
        {
            get
            {
#if UNITY_EDITOR
                if (_inputFieldExampleInputField3InputText == null || _inputFieldExampleInputField3InputText.CurrentVersion != Template.Version)
#else
                if (_inputFieldExampleInputField3InputText == null)
#endif
                {
                    _inputFieldExampleInputField3InputText = new Template(InputFieldTemplates.InputFieldInputText);
#if UNITY_EDITOR
                    _inputFieldExampleInputField3InputText.Name = "InputFieldExampleInputField3InputText";
#endif
                }
                return _inputFieldExampleInputField3InputText;
            }
        }

        private static Template _inputFieldExampleImage1;
        public static Template InputFieldExampleImage1
        {
            get
            {
#if UNITY_EDITOR
                if (_inputFieldExampleImage1 == null || _inputFieldExampleImage1.CurrentVersion != Template.Version)
#else
                if (_inputFieldExampleImage1 == null)
#endif
                {
                    _inputFieldExampleImage1 = new Template(ImageTemplates.Image);
#if UNITY_EDITOR
                    _inputFieldExampleImage1.Name = "InputFieldExampleImage1";
#endif
                    Delight.Image.SpriteProperty.SetDefault(_inputFieldExampleImage1, Assets.Sprites["RainbowSquare"]);
                    Delight.Image.AlignmentProperty.SetDefault(_inputFieldExampleImage1, Delight.ElementAlignment.Left);
                    Delight.Image.OffsetProperty.SetDefault(_inputFieldExampleImage1, new ElementMargin(new ElementSize(10f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels)));
                }
                return _inputFieldExampleImage1;
            }
        }

        private static Template _inputFieldExampleGroup3;
        public static Template InputFieldExampleGroup3
        {
            get
            {
#if UNITY_EDITOR
                if (_inputFieldExampleGroup3 == null || _inputFieldExampleGroup3.CurrentVersion != Template.Version)
#else
                if (_inputFieldExampleGroup3 == null)
#endif
                {
                    _inputFieldExampleGroup3 = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _inputFieldExampleGroup3.Name = "InputFieldExampleGroup3";
#endif
                    Delight.Group.OrientationProperty.SetDefault(_inputFieldExampleGroup3, Delight.ElementOrientation.Vertical);
                    Delight.Group.SpacingProperty.SetDefault(_inputFieldExampleGroup3, new ElementSize(15f, ElementSizeUnit.Pixels));
                }
                return _inputFieldExampleGroup3;
            }
        }

        private static Template _inputFieldExampleLabel5;
        public static Template InputFieldExampleLabel5
        {
            get
            {
#if UNITY_EDITOR
                if (_inputFieldExampleLabel5 == null || _inputFieldExampleLabel5.CurrentVersion != Template.Version)
#else
                if (_inputFieldExampleLabel5 == null)
#endif
                {
                    _inputFieldExampleLabel5 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _inputFieldExampleLabel5.Name = "InputFieldExampleLabel5";
#endif
                    Delight.Label.TextProperty.SetDefault(_inputFieldExampleLabel5, "Multi Line");
                    Delight.Label.AlignmentProperty.SetDefault(_inputFieldExampleLabel5, Delight.ElementAlignment.Top);
                    Delight.Label.AutoSizeProperty.SetDefault(_inputFieldExampleLabel5, Delight.AutoSize.Width);
                }
                return _inputFieldExampleLabel5;
            }
        }

        private static Template _inputFieldExampleInputField4;
        public static Template InputFieldExampleInputField4
        {
            get
            {
#if UNITY_EDITOR
                if (_inputFieldExampleInputField4 == null || _inputFieldExampleInputField4.CurrentVersion != Template.Version)
#else
                if (_inputFieldExampleInputField4 == null)
#endif
                {
                    _inputFieldExampleInputField4 = new Template(InputFieldTemplates.InputField);
#if UNITY_EDITOR
                    _inputFieldExampleInputField4.Name = "InputFieldExampleInputField4";
#endif
                    Delight.InputField.WidthProperty.SetDefault(_inputFieldExampleInputField4, new ElementSize(200f, ElementSizeUnit.Pixels));
                    Delight.InputField.HeightProperty.SetDefault(_inputFieldExampleInputField4, new ElementSize(200f, ElementSizeUnit.Pixels));
                    Delight.InputField.LineTypeProperty.SetDefault(_inputFieldExampleInputField4, UnityEngine.UI.InputField.LineType.MultiLineNewline);
                    Delight.InputField.InputFieldPlaceholderTemplateProperty.SetDefault(_inputFieldExampleInputField4, InputFieldExampleInputField4InputFieldPlaceholder);
                    Delight.InputField.TextAreaTemplateProperty.SetDefault(_inputFieldExampleInputField4, InputFieldExampleInputField4TextArea);
                    Delight.InputField.InputTextTemplateProperty.SetDefault(_inputFieldExampleInputField4, InputFieldExampleInputField4InputText);
                }
                return _inputFieldExampleInputField4;
            }
        }

        private static Template _inputFieldExampleInputField4InputFieldPlaceholder;
        public static Template InputFieldExampleInputField4InputFieldPlaceholder
        {
            get
            {
#if UNITY_EDITOR
                if (_inputFieldExampleInputField4InputFieldPlaceholder == null || _inputFieldExampleInputField4InputFieldPlaceholder.CurrentVersion != Template.Version)
#else
                if (_inputFieldExampleInputField4InputFieldPlaceholder == null)
#endif
                {
                    _inputFieldExampleInputField4InputFieldPlaceholder = new Template(InputFieldTemplates.InputFieldInputFieldPlaceholder);
#if UNITY_EDITOR
                    _inputFieldExampleInputField4InputFieldPlaceholder.Name = "InputFieldExampleInputField4InputFieldPlaceholder";
#endif
                }
                return _inputFieldExampleInputField4InputFieldPlaceholder;
            }
        }

        private static Template _inputFieldExampleInputField4TextArea;
        public static Template InputFieldExampleInputField4TextArea
        {
            get
            {
#if UNITY_EDITOR
                if (_inputFieldExampleInputField4TextArea == null || _inputFieldExampleInputField4TextArea.CurrentVersion != Template.Version)
#else
                if (_inputFieldExampleInputField4TextArea == null)
#endif
                {
                    _inputFieldExampleInputField4TextArea = new Template(InputFieldTemplates.InputFieldTextArea);
#if UNITY_EDITOR
                    _inputFieldExampleInputField4TextArea.Name = "InputFieldExampleInputField4TextArea";
#endif
                }
                return _inputFieldExampleInputField4TextArea;
            }
        }

        private static Template _inputFieldExampleInputField4InputText;
        public static Template InputFieldExampleInputField4InputText
        {
            get
            {
#if UNITY_EDITOR
                if (_inputFieldExampleInputField4InputText == null || _inputFieldExampleInputField4InputText.CurrentVersion != Template.Version)
#else
                if (_inputFieldExampleInputField4InputText == null)
#endif
                {
                    _inputFieldExampleInputField4InputText = new Template(InputFieldTemplates.InputFieldInputText);
#if UNITY_EDITOR
                    _inputFieldExampleInputField4InputText.Name = "InputFieldExampleInputField4InputText";
#endif
                }
                return _inputFieldExampleInputField4InputText;
            }
        }

        #endregion
    }

    #endregion
}
