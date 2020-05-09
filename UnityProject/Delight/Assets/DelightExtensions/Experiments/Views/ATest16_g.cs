// Internal view logic generated from "ATest16.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class ATest16 : UIView
    {
        #region Constructors

        public ATest16(View parent, View layoutParent = null, string id = null, Template template = null, bool deferInitialization = false) :
            base(parent, layoutParent, id, template ?? ATest16Templates.Default, deferInitialization)
        {
            if (deferInitialization)
                return;

            // constructing ATest15 (ATest151)
            ATest151 = new ATest15(this, this, "ATest151", ATest151Template);
            this.AfterInitializeInternal();
        }

        public ATest16() : this(null)
        {
        }

        static ATest16()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(ATest16Templates.Default, dependencyProperties);

            dependencyProperties.Add(MyStringProperty);
            dependencyProperties.Add(ATest151Property);
            dependencyProperties.Add(ATest151TemplateProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<System.String> MyStringProperty = new DependencyProperty<System.String>("MyString");
        public System.String MyString
        {
            get { return MyStringProperty.GetValue(this); }
            set { MyStringProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ATest15> ATest151Property = new DependencyProperty<ATest15>("ATest151");
        public ATest15 ATest151
        {
            get { return ATest151Property.GetValue(this); }
            set { ATest151Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> ATest151TemplateProperty = new DependencyProperty<Template>("ATest151Template");
        public Template ATest151Template
        {
            get { return ATest151TemplateProperty.GetValue(this); }
            set { ATest151TemplateProperty.SetValue(this, value); }
        }

        #endregion
    }

    #region Data Templates

    public static class ATest16Templates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return ATest16;
            }
        }

        private static Template _aTest16;
        public static Template ATest16
        {
            get
            {
#if UNITY_EDITOR
                if (_aTest16 == null || _aTest16.CurrentVersion != Template.Version)
#else
                if (_aTest16 == null)
#endif
                {
                    _aTest16 = new Template(UIViewTemplates.UIView);
#if UNITY_EDITOR
                    _aTest16.Name = "ATest16";
#endif
                    Delight.ATest16.ATest151TemplateProperty.SetDefault(_aTest16, ATest16ATest151);
                }
                return _aTest16;
            }
        }

        private static Template _aTest16ATest151;
        public static Template ATest16ATest151
        {
            get
            {
#if UNITY_EDITOR
                if (_aTest16ATest151 == null || _aTest16ATest151.CurrentVersion != Template.Version)
#else
                if (_aTest16ATest151 == null)
#endif
                {
                    _aTest16ATest151 = new Template(ATest15Templates.ATest15);
#if UNITY_EDITOR
                    _aTest16ATest151.Name = "ATest16ATest151";
#endif
                    Delight.ATest15.Label1TemplateProperty.SetDefault(_aTest16ATest151, ATest16ATest151Label1);
                }
                return _aTest16ATest151;
            }
        }

        private static Template _aTest16ATest151Label1;
        public static Template ATest16ATest151Label1
        {
            get
            {
#if UNITY_EDITOR
                if (_aTest16ATest151Label1 == null || _aTest16ATest151Label1.CurrentVersion != Template.Version)
#else
                if (_aTest16ATest151Label1 == null)
#endif
                {
                    _aTest16ATest151Label1 = new Template(ATest15Templates.ATest15Label1);
#if UNITY_EDITOR
                    _aTest16ATest151Label1.Name = "ATest16ATest151Label1";
#endif
                }
                return _aTest16ATest151Label1;
            }
        }

        #endregion
    }

    #endregion
}
