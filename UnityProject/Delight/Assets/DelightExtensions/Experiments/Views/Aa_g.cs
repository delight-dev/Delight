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

            // constructing Button (MyButton)
            MyButton = new Button(this, this, "MyButton", MyButtonTemplate);
            this.AfterInitializeInternal();
        }

        public Aa() : this(null)
        {
        }

        static Aa()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(AaTemplates.Default, dependencyProperties);

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
                    Delight.Aa.MyButtonTemplateProperty.SetDefault(_aa, AaMyButton);
                }
                return _aa;
            }
        }

        private static Template _aaMyButton;
        public static Template AaMyButton
        {
            get
            {
#if UNITY_EDITOR
                if (_aaMyButton == null || _aaMyButton.CurrentVersion != Template.Version)
#else
                if (_aaMyButton == null)
#endif
                {
                    _aaMyButton = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _aaMyButton.Name = "AaMyButton";
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_aaMyButton, AaMyButtonLabel);
                }
                return _aaMyButton;
            }
        }

        private static Template _aaMyButtonLabel;
        public static Template AaMyButtonLabel
        {
            get
            {
#if UNITY_EDITOR
                if (_aaMyButtonLabel == null || _aaMyButtonLabel.CurrentVersion != Template.Version)
#else
                if (_aaMyButtonLabel == null)
#endif
                {
                    _aaMyButtonLabel = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _aaMyButtonLabel.Name = "AaMyButtonLabel";
#endif
                    Delight.Label.TextProperty.SetDefault(_aaMyButtonLabel, "Hello");
                }
                return _aaMyButtonLabel;
            }
        }

        #endregion
    }

    #endregion
}
