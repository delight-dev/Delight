// Internal view logic generated from "ATest13.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class ATest13 : UIView
    {
        #region Constructors

        public ATest13(View parent, View layoutParent = null, string id = null, Template template = null, bool deferInitialization = false) :
            base(parent, layoutParent, id, template ?? ATest13Templates.Default, deferInitialization)
        {
            if (deferInitialization)
                return;

            // constructing Button (MyButton)
            MyButton = new Button(this, this, "MyButton", MyButtonTemplate);
            this.AfterInitializeInternal();
        }

        public ATest13() : this(null)
        {
        }

        static ATest13()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(ATest13Templates.Default, dependencyProperties);

            dependencyProperties.Add(MyStringProperty);
            dependencyProperties.Add(MyButtonProperty);
            dependencyProperties.Add(MyButtonTemplateProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<System.String> MyStringProperty = new DependencyProperty<System.String>("MyString");
        public System.String MyString
        {
            get { return MyStringProperty.GetValue(this); }
            set { MyStringProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Button> MyButtonProperty = new DependencyProperty<Button>("MyButton");
        public Button MyButton
        {
            get { return MyButtonProperty.GetValue(this); }
            set { MyButtonProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> MyButtonTemplateProperty = new DependencyProperty<Template>("MyButtonTemplate");
        public Template MyButtonTemplate
        {
            get { return MyButtonTemplateProperty.GetValue(this); }
            set { MyButtonTemplateProperty.SetValue(this, value); }
        }

        #endregion
    }

    #region Data Templates

    public static class ATest13Templates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return ATest13;
            }
        }

        private static Template _aTest13;
        public static Template ATest13
        {
            get
            {
#if UNITY_EDITOR
                if (_aTest13 == null || _aTest13.CurrentVersion != Template.Version)
#else
                if (_aTest13 == null)
#endif
                {
                    _aTest13 = new Template(UIViewTemplates.UIView);
#if UNITY_EDITOR
                    _aTest13.Name = "ATest13";
#endif
                    Delight.ATest13.MyButtonTemplateProperty.SetDefault(_aTest13, ATest13MyButton);
                }
                return _aTest13;
            }
        }

        private static Template _aTest13MyButton;
        public static Template ATest13MyButton
        {
            get
            {
#if UNITY_EDITOR
                if (_aTest13MyButton == null || _aTest13MyButton.CurrentVersion != Template.Version)
#else
                if (_aTest13MyButton == null)
#endif
                {
                    _aTest13MyButton = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _aTest13MyButton.Name = "ATest13MyButton";
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_aTest13MyButton, ATest13MyButtonLabel);
                }
                return _aTest13MyButton;
            }
        }

        private static Template _aTest13MyButtonLabel;
        public static Template ATest13MyButtonLabel
        {
            get
            {
#if UNITY_EDITOR
                if (_aTest13MyButtonLabel == null || _aTest13MyButtonLabel.CurrentVersion != Template.Version)
#else
                if (_aTest13MyButtonLabel == null)
#endif
                {
                    _aTest13MyButtonLabel = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _aTest13MyButtonLabel.Name = "ATest13MyButtonLabel";
#endif
                    Delight.Label.TextProperty.SetDefault(_aTest13MyButtonLabel, "Hello");
                }
                return _aTest13MyButtonLabel;
            }
        }

        #endregion
    }

    #endregion
}
