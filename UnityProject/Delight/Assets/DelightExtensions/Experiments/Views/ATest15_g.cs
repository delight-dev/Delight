// Internal view logic generated from "ATest15.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class ATest15 : UIView
    {
        #region Constructors

        public ATest15(View parent, View layoutParent = null, string id = null, Template template = null, bool deferInitialization = false) :
            base(parent, layoutParent, id, template ?? ATest15Templates.Default, deferInitialization)
        {
            if (deferInitialization)
                return;

            // constructing Label (Label1)
            Label1 = new Label(this, this, "Label1", Label1Template);
            this.AfterInitializeInternal();
        }

        public ATest15() : this(null)
        {
        }

        static ATest15()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(ATest15Templates.Default, dependencyProperties);

            dependencyProperties.Add(Label1Property);
            dependencyProperties.Add(Label1TemplateProperty);
        }

        #endregion

        #region Properties

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

        #endregion
    }

    #region Data Templates

    public static class ATest15Templates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return ATest15;
            }
        }

        private static Template _aTest15;
        public static Template ATest15
        {
            get
            {
#if UNITY_EDITOR
                if (_aTest15 == null || _aTest15.CurrentVersion != Template.Version)
#else
                if (_aTest15 == null)
#endif
                {
                    _aTest15 = new Template(UIViewTemplates.UIView);
#if UNITY_EDITOR
                    _aTest15.Name = "ATest15";
#endif
                    Delight.ATest15.Label1TemplateProperty.SetDefault(_aTest15, ATest15Label1);
                }
                return _aTest15;
            }
        }

        private static Template _aTest15Label1;
        public static Template ATest15Label1
        {
            get
            {
#if UNITY_EDITOR
                if (_aTest15Label1 == null || _aTest15Label1.CurrentVersion != Template.Version)
#else
                if (_aTest15Label1 == null)
#endif
                {
                    _aTest15Label1 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _aTest15Label1.Name = "ATest15Label1";
#endif
                    Delight.Label.TextProperty.SetDefault(_aTest15Label1, "ATest15");
                }
                return _aTest15Label1;
            }
        }

        #endregion
    }

    #endregion
}
