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
                    Delight.TitleView.Button1TemplateProperty.SetDefault(_aaTitleView1, AaTitleView1Button1);
                }
                return _aaTitleView1;
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

        #endregion
    }

    #endregion
}
