// Internal view logic generated from "Aa.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class Aa : UIView
    {
        #region Constructors

        public Aa(View parent, View layoutParent = null, string id = null, Template template = null, bool deferInitialization = false) :
            base(parent, layoutParent, id, template ?? AaTemplates.Default, deferInitialization)
        {
            if (deferInitialization)
                return;

            // constructing TitleView (TitleView1)
            TitleView1 = new TitleView(this, this, "TitleView1", TitleView1Template);
            this.AfterInitializeInternal();
        }

        public Aa() : this(null)
        {
        }

        static Aa()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(AaTemplates.Default, dependencyProperties);

            dependencyProperties.Add(TitleView1Property);
            dependencyProperties.Add(TitleView1TemplateProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<TitleView> TitleView1Property = new DependencyProperty<TitleView>("TitleView1");
        public TitleView TitleView1
        {
            get { return TitleView1Property.GetValue(this); }
            set { TitleView1Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> TitleView1TemplateProperty = new DependencyProperty<Template>("TitleView1Template");
        public Template TitleView1Template
        {
            get { return TitleView1TemplateProperty.GetValue(this); }
            set { TitleView1TemplateProperty.SetValue(this, value); }
        }

        #endregion
    }

    #region Data Templates

    public static class AaTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return Aa;
            }
        }

        private static Template _aa;
        public static Template Aa
        {
            get
            {
#if UNITY_EDITOR
                if (_aa == null || _aa.CurrentVersion != Template.Version)
#else
                if (_aa == null)
#endif
                {
                    _aa = new Template(UIViewTemplates.UIView);
#if UNITY_EDITOR
                    _aa.Name = "Aa";
#endif
                    Delight.Aa.TitleView1TemplateProperty.SetDefault(_aa, AaTitleView1);
                }
                return _aa;
            }
        }

        private static Template _aaTitleView1;
        public static Template AaTitleView1
        {
            get
            {
#if UNITY_EDITOR
                if (_aaTitleView1 == null || _aaTitleView1.CurrentVersion != Template.Version)
#else
                if (_aaTitleView1 == null)
#endif
                {
                    _aaTitleView1 = new Template(TitleViewTemplates.TitleView);
#if UNITY_EDITOR
                    _aaTitleView1.Name = "AaTitleView1";
#endif
                    Delight.TitleView.TitleProperty.SetDefault(_aaTitleView1, "Test title");
                    Delight.TitleView.Group1TemplateProperty.SetDefault(_aaTitleView1, AaTitleView1Group1);
                    Delight.TitleView.Button1TemplateProperty.SetDefault(_aaTitleView1, AaTitleView1Button1);
                    Delight.TitleView.CheckBox1TemplateProperty.SetDefault(_aaTitleView1, AaTitleView1CheckBox1);
                    Delight.TitleView.CheckBox2TemplateProperty.SetDefault(_aaTitleView1, AaTitleView1CheckBox2);
                    Delight.TitleView.InputTemplateProperty.SetDefault(_aaTitleView1, AaTitleView1Input);
                    Delight.TitleView.Label1TemplateProperty.SetDefault(_aaTitleView1, AaTitleView1Label1);
                    Delight.TitleView.Label2TemplateProperty.SetDefault(_aaTitleView1, AaTitleView1Label2);
                    Delight.TitleView.Input1TemplateProperty.SetDefault(_aaTitleView1, AaTitleView1Input1);
                    Delight.TitleView.Input2TemplateProperty.SetDefault(_aaTitleView1, AaTitleView1Input2);
                    Delight.TitleView.Label3TemplateProperty.SetDefault(_aaTitleView1, AaTitleView1Label3);
                }
                return _aaTitleView1;
            }
        }

        private static Template _aaTitleView1Group1;
        public static Template AaTitleView1Group1
        {
            get
            {
#if UNITY_EDITOR
                if (_aaTitleView1Group1 == null || _aaTitleView1Group1.CurrentVersion != Template.Version)
#else
                if (_aaTitleView1Group1 == null)
#endif
                {
                    _aaTitleView1Group1 = new Template(TitleViewTemplates.TitleViewGroup1);
#if UNITY_EDITOR
                    _aaTitleView1Group1.Name = "AaTitleView1Group1";
#endif
                }
                return _aaTitleView1Group1;
            }
        }

        private static Template _aaTitleView1Button1;
        public static Template AaTitleView1Button1
        {
            get
            {
#if UNITY_EDITOR
                if (_aaTitleView1Button1 == null || _aaTitleView1Button1.CurrentVersion != Template.Version)
#else
                if (_aaTitleView1Button1 == null)
#endif
                {
                    _aaTitleView1Button1 = new Template(TitleViewTemplates.TitleViewButton1);
#if UNITY_EDITOR
                    _aaTitleView1Button1.Name = "AaTitleView1Button1";
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_aaTitleView1Button1, AaTitleView1Button1Label);
                }
                return _aaTitleView1Button1;
            }
        }

        private static Template _aaTitleView1Button1Label;
        public static Template AaTitleView1Button1Label
        {
            get
            {
#if UNITY_EDITOR
                if (_aaTitleView1Button1Label == null || _aaTitleView1Button1Label.CurrentVersion != Template.Version)
#else
                if (_aaTitleView1Button1Label == null)
#endif
                {
                    _aaTitleView1Button1Label = new Template(TitleViewTemplates.TitleViewButton1Label);
#if UNITY_EDITOR
                    _aaTitleView1Button1Label.Name = "AaTitleView1Button1Label";
#endif
                }
                return _aaTitleView1Button1Label;
            }
        }

        private static Template _aaTitleView1CheckBox1;
        public static Template AaTitleView1CheckBox1
        {
            get
            {
#if UNITY_EDITOR
                if (_aaTitleView1CheckBox1 == null || _aaTitleView1CheckBox1.CurrentVersion != Template.Version)
#else
                if (_aaTitleView1CheckBox1 == null)
#endif
                {
                    _aaTitleView1CheckBox1 = new Template(TitleViewTemplates.TitleViewCheckBox1);
#if UNITY_EDITOR
                    _aaTitleView1CheckBox1.Name = "AaTitleView1CheckBox1";
#endif
                    Delight.CheckBox.CheckBoxGroupTemplateProperty.SetDefault(_aaTitleView1CheckBox1, AaTitleView1CheckBox1CheckBoxGroup);
                    Delight.CheckBox.CheckBoxImageViewTemplateProperty.SetDefault(_aaTitleView1CheckBox1, AaTitleView1CheckBox1CheckBoxImageView);
                    Delight.CheckBox.CheckBoxLabelTemplateProperty.SetDefault(_aaTitleView1CheckBox1, AaTitleView1CheckBox1CheckBoxLabel);
                }
                return _aaTitleView1CheckBox1;
            }
        }

        private static Template _aaTitleView1CheckBox1CheckBoxGroup;
        public static Template AaTitleView1CheckBox1CheckBoxGroup
        {
            get
            {
#if UNITY_EDITOR
                if (_aaTitleView1CheckBox1CheckBoxGroup == null || _aaTitleView1CheckBox1CheckBoxGroup.CurrentVersion != Template.Version)
#else
                if (_aaTitleView1CheckBox1CheckBoxGroup == null)
#endif
                {
                    _aaTitleView1CheckBox1CheckBoxGroup = new Template(TitleViewTemplates.TitleViewCheckBox1CheckBoxGroup);
#if UNITY_EDITOR
                    _aaTitleView1CheckBox1CheckBoxGroup.Name = "AaTitleView1CheckBox1CheckBoxGroup";
#endif
                }
                return _aaTitleView1CheckBox1CheckBoxGroup;
            }
        }

        private static Template _aaTitleView1CheckBox1CheckBoxImageView;
        public static Template AaTitleView1CheckBox1CheckBoxImageView
        {
            get
            {
#if UNITY_EDITOR
                if (_aaTitleView1CheckBox1CheckBoxImageView == null || _aaTitleView1CheckBox1CheckBoxImageView.CurrentVersion != Template.Version)
#else
                if (_aaTitleView1CheckBox1CheckBoxImageView == null)
#endif
                {
                    _aaTitleView1CheckBox1CheckBoxImageView = new Template(TitleViewTemplates.TitleViewCheckBox1CheckBoxImageView);
#if UNITY_EDITOR
                    _aaTitleView1CheckBox1CheckBoxImageView.Name = "AaTitleView1CheckBox1CheckBoxImageView";
#endif
                }
                return _aaTitleView1CheckBox1CheckBoxImageView;
            }
        }

        private static Template _aaTitleView1CheckBox1CheckBoxLabel;
        public static Template AaTitleView1CheckBox1CheckBoxLabel
        {
            get
            {
#if UNITY_EDITOR
                if (_aaTitleView1CheckBox1CheckBoxLabel == null || _aaTitleView1CheckBox1CheckBoxLabel.CurrentVersion != Template.Version)
#else
                if (_aaTitleView1CheckBox1CheckBoxLabel == null)
#endif
                {
                    _aaTitleView1CheckBox1CheckBoxLabel = new Template(TitleViewTemplates.TitleViewCheckBox1CheckBoxLabel);
#if UNITY_EDITOR
                    _aaTitleView1CheckBox1CheckBoxLabel.Name = "AaTitleView1CheckBox1CheckBoxLabel";
#endif
                }
                return _aaTitleView1CheckBox1CheckBoxLabel;
            }
        }

        private static Template _aaTitleView1CheckBox2;
        public static Template AaTitleView1CheckBox2
        {
            get
            {
#if UNITY_EDITOR
                if (_aaTitleView1CheckBox2 == null || _aaTitleView1CheckBox2.CurrentVersion != Template.Version)
#else
                if (_aaTitleView1CheckBox2 == null)
#endif
                {
                    _aaTitleView1CheckBox2 = new Template(TitleViewTemplates.TitleViewCheckBox2);
#if UNITY_EDITOR
                    _aaTitleView1CheckBox2.Name = "AaTitleView1CheckBox2";
#endif
                    Delight.CheckBox.CheckBoxGroupTemplateProperty.SetDefault(_aaTitleView1CheckBox2, AaTitleView1CheckBox2CheckBoxGroup);
                    Delight.CheckBox.CheckBoxImageViewTemplateProperty.SetDefault(_aaTitleView1CheckBox2, AaTitleView1CheckBox2CheckBoxImageView);
                    Delight.CheckBox.CheckBoxLabelTemplateProperty.SetDefault(_aaTitleView1CheckBox2, AaTitleView1CheckBox2CheckBoxLabel);
                }
                return _aaTitleView1CheckBox2;
            }
        }

        private static Template _aaTitleView1CheckBox2CheckBoxGroup;
        public static Template AaTitleView1CheckBox2CheckBoxGroup
        {
            get
            {
#if UNITY_EDITOR
                if (_aaTitleView1CheckBox2CheckBoxGroup == null || _aaTitleView1CheckBox2CheckBoxGroup.CurrentVersion != Template.Version)
#else
                if (_aaTitleView1CheckBox2CheckBoxGroup == null)
#endif
                {
                    _aaTitleView1CheckBox2CheckBoxGroup = new Template(TitleViewTemplates.TitleViewCheckBox2CheckBoxGroup);
#if UNITY_EDITOR
                    _aaTitleView1CheckBox2CheckBoxGroup.Name = "AaTitleView1CheckBox2CheckBoxGroup";
#endif
                }
                return _aaTitleView1CheckBox2CheckBoxGroup;
            }
        }

        private static Template _aaTitleView1CheckBox2CheckBoxImageView;
        public static Template AaTitleView1CheckBox2CheckBoxImageView
        {
            get
            {
#if UNITY_EDITOR
                if (_aaTitleView1CheckBox2CheckBoxImageView == null || _aaTitleView1CheckBox2CheckBoxImageView.CurrentVersion != Template.Version)
#else
                if (_aaTitleView1CheckBox2CheckBoxImageView == null)
#endif
                {
                    _aaTitleView1CheckBox2CheckBoxImageView = new Template(TitleViewTemplates.TitleViewCheckBox2CheckBoxImageView);
#if UNITY_EDITOR
                    _aaTitleView1CheckBox2CheckBoxImageView.Name = "AaTitleView1CheckBox2CheckBoxImageView";
#endif
                }
                return _aaTitleView1CheckBox2CheckBoxImageView;
            }
        }

        private static Template _aaTitleView1CheckBox2CheckBoxLabel;
        public static Template AaTitleView1CheckBox2CheckBoxLabel
        {
            get
            {
#if UNITY_EDITOR
                if (_aaTitleView1CheckBox2CheckBoxLabel == null || _aaTitleView1CheckBox2CheckBoxLabel.CurrentVersion != Template.Version)
#else
                if (_aaTitleView1CheckBox2CheckBoxLabel == null)
#endif
                {
                    _aaTitleView1CheckBox2CheckBoxLabel = new Template(TitleViewTemplates.TitleViewCheckBox2CheckBoxLabel);
#if UNITY_EDITOR
                    _aaTitleView1CheckBox2CheckBoxLabel.Name = "AaTitleView1CheckBox2CheckBoxLabel";
#endif
                }
                return _aaTitleView1CheckBox2CheckBoxLabel;
            }
        }

        private static Template _aaTitleView1Input;
        public static Template AaTitleView1Input
        {
            get
            {
#if UNITY_EDITOR
                if (_aaTitleView1Input == null || _aaTitleView1Input.CurrentVersion != Template.Version)
#else
                if (_aaTitleView1Input == null)
#endif
                {
                    _aaTitleView1Input = new Template(TitleViewTemplates.TitleViewInput);
#if UNITY_EDITOR
                    _aaTitleView1Input.Name = "AaTitleView1Input";
#endif
                    Delight.InputField.InputFieldPlaceholderTemplateProperty.SetDefault(_aaTitleView1Input, AaTitleView1InputInputFieldPlaceholder);
                    Delight.InputField.TextAreaTemplateProperty.SetDefault(_aaTitleView1Input, AaTitleView1InputTextArea);
                    Delight.InputField.InputTextTemplateProperty.SetDefault(_aaTitleView1Input, AaTitleView1InputInputText);
                }
                return _aaTitleView1Input;
            }
        }

        private static Template _aaTitleView1InputInputFieldPlaceholder;
        public static Template AaTitleView1InputInputFieldPlaceholder
        {
            get
            {
#if UNITY_EDITOR
                if (_aaTitleView1InputInputFieldPlaceholder == null || _aaTitleView1InputInputFieldPlaceholder.CurrentVersion != Template.Version)
#else
                if (_aaTitleView1InputInputFieldPlaceholder == null)
#endif
                {
                    _aaTitleView1InputInputFieldPlaceholder = new Template(TitleViewTemplates.TitleViewInputInputFieldPlaceholder);
#if UNITY_EDITOR
                    _aaTitleView1InputInputFieldPlaceholder.Name = "AaTitleView1InputInputFieldPlaceholder";
#endif
                }
                return _aaTitleView1InputInputFieldPlaceholder;
            }
        }

        private static Template _aaTitleView1InputTextArea;
        public static Template AaTitleView1InputTextArea
        {
            get
            {
#if UNITY_EDITOR
                if (_aaTitleView1InputTextArea == null || _aaTitleView1InputTextArea.CurrentVersion != Template.Version)
#else
                if (_aaTitleView1InputTextArea == null)
#endif
                {
                    _aaTitleView1InputTextArea = new Template(TitleViewTemplates.TitleViewInputTextArea);
#if UNITY_EDITOR
                    _aaTitleView1InputTextArea.Name = "AaTitleView1InputTextArea";
#endif
                }
                return _aaTitleView1InputTextArea;
            }
        }

        private static Template _aaTitleView1InputInputText;
        public static Template AaTitleView1InputInputText
        {
            get
            {
#if UNITY_EDITOR
                if (_aaTitleView1InputInputText == null || _aaTitleView1InputInputText.CurrentVersion != Template.Version)
#else
                if (_aaTitleView1InputInputText == null)
#endif
                {
                    _aaTitleView1InputInputText = new Template(TitleViewTemplates.TitleViewInputInputText);
#if UNITY_EDITOR
                    _aaTitleView1InputInputText.Name = "AaTitleView1InputInputText";
#endif
                }
                return _aaTitleView1InputInputText;
            }
        }

        private static Template _aaTitleView1Label1;
        public static Template AaTitleView1Label1
        {
            get
            {
#if UNITY_EDITOR
                if (_aaTitleView1Label1 == null || _aaTitleView1Label1.CurrentVersion != Template.Version)
#else
                if (_aaTitleView1Label1 == null)
#endif
                {
                    _aaTitleView1Label1 = new Template(TitleViewTemplates.TitleViewLabel1);
#if UNITY_EDITOR
                    _aaTitleView1Label1.Name = "AaTitleView1Label1";
#endif
                }
                return _aaTitleView1Label1;
            }
        }

        private static Template _aaTitleView1Label2;
        public static Template AaTitleView1Label2
        {
            get
            {
#if UNITY_EDITOR
                if (_aaTitleView1Label2 == null || _aaTitleView1Label2.CurrentVersion != Template.Version)
#else
                if (_aaTitleView1Label2 == null)
#endif
                {
                    _aaTitleView1Label2 = new Template(TitleViewTemplates.TitleViewLabel2);
#if UNITY_EDITOR
                    _aaTitleView1Label2.Name = "AaTitleView1Label2";
#endif
                }
                return _aaTitleView1Label2;
            }
        }

        private static Template _aaTitleView1Input1;
        public static Template AaTitleView1Input1
        {
            get
            {
#if UNITY_EDITOR
                if (_aaTitleView1Input1 == null || _aaTitleView1Input1.CurrentVersion != Template.Version)
#else
                if (_aaTitleView1Input1 == null)
#endif
                {
                    _aaTitleView1Input1 = new Template(TitleViewTemplates.TitleViewInput1);
#if UNITY_EDITOR
                    _aaTitleView1Input1.Name = "AaTitleView1Input1";
#endif
                    Delight.InputField.InputFieldPlaceholderTemplateProperty.SetDefault(_aaTitleView1Input1, AaTitleView1Input1InputFieldPlaceholder);
                    Delight.InputField.TextAreaTemplateProperty.SetDefault(_aaTitleView1Input1, AaTitleView1Input1TextArea);
                    Delight.InputField.InputTextTemplateProperty.SetDefault(_aaTitleView1Input1, AaTitleView1Input1InputText);
                }
                return _aaTitleView1Input1;
            }
        }

        private static Template _aaTitleView1Input1InputFieldPlaceholder;
        public static Template AaTitleView1Input1InputFieldPlaceholder
        {
            get
            {
#if UNITY_EDITOR
                if (_aaTitleView1Input1InputFieldPlaceholder == null || _aaTitleView1Input1InputFieldPlaceholder.CurrentVersion != Template.Version)
#else
                if (_aaTitleView1Input1InputFieldPlaceholder == null)
#endif
                {
                    _aaTitleView1Input1InputFieldPlaceholder = new Template(TitleViewTemplates.TitleViewInput1InputFieldPlaceholder);
#if UNITY_EDITOR
                    _aaTitleView1Input1InputFieldPlaceholder.Name = "AaTitleView1Input1InputFieldPlaceholder";
#endif
                }
                return _aaTitleView1Input1InputFieldPlaceholder;
            }
        }

        private static Template _aaTitleView1Input1TextArea;
        public static Template AaTitleView1Input1TextArea
        {
            get
            {
#if UNITY_EDITOR
                if (_aaTitleView1Input1TextArea == null || _aaTitleView1Input1TextArea.CurrentVersion != Template.Version)
#else
                if (_aaTitleView1Input1TextArea == null)
#endif
                {
                    _aaTitleView1Input1TextArea = new Template(TitleViewTemplates.TitleViewInput1TextArea);
#if UNITY_EDITOR
                    _aaTitleView1Input1TextArea.Name = "AaTitleView1Input1TextArea";
#endif
                }
                return _aaTitleView1Input1TextArea;
            }
        }

        private static Template _aaTitleView1Input1InputText;
        public static Template AaTitleView1Input1InputText
        {
            get
            {
#if UNITY_EDITOR
                if (_aaTitleView1Input1InputText == null || _aaTitleView1Input1InputText.CurrentVersion != Template.Version)
#else
                if (_aaTitleView1Input1InputText == null)
#endif
                {
                    _aaTitleView1Input1InputText = new Template(TitleViewTemplates.TitleViewInput1InputText);
#if UNITY_EDITOR
                    _aaTitleView1Input1InputText.Name = "AaTitleView1Input1InputText";
#endif
                }
                return _aaTitleView1Input1InputText;
            }
        }

        private static Template _aaTitleView1Input2;
        public static Template AaTitleView1Input2
        {
            get
            {
#if UNITY_EDITOR
                if (_aaTitleView1Input2 == null || _aaTitleView1Input2.CurrentVersion != Template.Version)
#else
                if (_aaTitleView1Input2 == null)
#endif
                {
                    _aaTitleView1Input2 = new Template(TitleViewTemplates.TitleViewInput2);
#if UNITY_EDITOR
                    _aaTitleView1Input2.Name = "AaTitleView1Input2";
#endif
                    Delight.InputField.InputFieldPlaceholderTemplateProperty.SetDefault(_aaTitleView1Input2, AaTitleView1Input2InputFieldPlaceholder);
                    Delight.InputField.TextAreaTemplateProperty.SetDefault(_aaTitleView1Input2, AaTitleView1Input2TextArea);
                    Delight.InputField.InputTextTemplateProperty.SetDefault(_aaTitleView1Input2, AaTitleView1Input2InputText);
                }
                return _aaTitleView1Input2;
            }
        }

        private static Template _aaTitleView1Input2InputFieldPlaceholder;
        public static Template AaTitleView1Input2InputFieldPlaceholder
        {
            get
            {
#if UNITY_EDITOR
                if (_aaTitleView1Input2InputFieldPlaceholder == null || _aaTitleView1Input2InputFieldPlaceholder.CurrentVersion != Template.Version)
#else
                if (_aaTitleView1Input2InputFieldPlaceholder == null)
#endif
                {
                    _aaTitleView1Input2InputFieldPlaceholder = new Template(TitleViewTemplates.TitleViewInput2InputFieldPlaceholder);
#if UNITY_EDITOR
                    _aaTitleView1Input2InputFieldPlaceholder.Name = "AaTitleView1Input2InputFieldPlaceholder";
#endif
                }
                return _aaTitleView1Input2InputFieldPlaceholder;
            }
        }

        private static Template _aaTitleView1Input2TextArea;
        public static Template AaTitleView1Input2TextArea
        {
            get
            {
#if UNITY_EDITOR
                if (_aaTitleView1Input2TextArea == null || _aaTitleView1Input2TextArea.CurrentVersion != Template.Version)
#else
                if (_aaTitleView1Input2TextArea == null)
#endif
                {
                    _aaTitleView1Input2TextArea = new Template(TitleViewTemplates.TitleViewInput2TextArea);
#if UNITY_EDITOR
                    _aaTitleView1Input2TextArea.Name = "AaTitleView1Input2TextArea";
#endif
                }
                return _aaTitleView1Input2TextArea;
            }
        }

        private static Template _aaTitleView1Input2InputText;
        public static Template AaTitleView1Input2InputText
        {
            get
            {
#if UNITY_EDITOR
                if (_aaTitleView1Input2InputText == null || _aaTitleView1Input2InputText.CurrentVersion != Template.Version)
#else
                if (_aaTitleView1Input2InputText == null)
#endif
                {
                    _aaTitleView1Input2InputText = new Template(TitleViewTemplates.TitleViewInput2InputText);
#if UNITY_EDITOR
                    _aaTitleView1Input2InputText.Name = "AaTitleView1Input2InputText";
#endif
                }
                return _aaTitleView1Input2InputText;
            }
        }

        private static Template _aaTitleView1Label3;
        public static Template AaTitleView1Label3
        {
            get
            {
#if UNITY_EDITOR
                if (_aaTitleView1Label3 == null || _aaTitleView1Label3.CurrentVersion != Template.Version)
#else
                if (_aaTitleView1Label3 == null)
#endif
                {
                    _aaTitleView1Label3 = new Template(TitleViewTemplates.TitleViewLabel3);
#if UNITY_EDITOR
                    _aaTitleView1Label3.Name = "AaTitleView1Label3";
#endif
                }
                return _aaTitleView1Label3;
            }
        }

        #endregion
    }

    #endregion
}
