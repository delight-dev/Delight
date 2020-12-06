// Internal view logic generated from "ResponsiveUIExample.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class ResponsiveUIExample : UIView
    {
        #region Constructors

        public ResponsiveUIExample(View parent, View layoutParent = null, string id = null, Template template = null, bool deferInitialization = false) :
            base(parent, layoutParent, id, template ?? ResponsiveUIExampleTemplates.Default, deferInitialization)
        {
            if (deferInitialization)
                return;

            // constructing Region (Region1)
            Region1 = new Region(this, this, "Region1", Region1Template);

            // binding <Region Width="$ {@IsPortrait} ? XML(100%) : XML(50%)">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "IsPortrait" }, new List<Func<object>> { () => Models.Globals }) }, new BindingPath(new List<string> { "Region1", "Width" }, new List<Func<object>> { () => this, () => Region1 }), () => Region1.Width = Models.Globals.IsPortrait ? new ElementSize(1f, ElementSizeUnit.Percents) : new ElementSize(0.5f, ElementSizeUnit.Percents), () => { }, false));

            // constructing Region (Region2)
            Region2 = new Region(this, this, "Region2", Region2Template);

            // binding <Region IsActive="$ {@ScreenWidth} LT 500 ? true : false">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "ScreenWidth" }, new List<Func<object>> { () => Models.Globals }) }, new BindingPath(new List<string> { "Region2", "IsActive" }, new List<Func<object>> { () => this, () => Region2 }), () => Region2.IsActive = Models.Globals.ScreenWidth < 500 ? true : false, () => { }, false));

            // constructing Label (Label1)
            Label1 = new Label(this, this, "Label1", Label1Template);

            // binding <Label Text="$ ({@ScreenWidth} GT 100).ToString()">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "ScreenWidth" }, new List<Func<object>> { () => Models.Globals }) }, new BindingPath(new List<string> { "Label1", "Text" }, new List<Func<object>> { () => this, () => Label1 }), () => Label1.Text = (Models.Globals.ScreenWidth > 100).ToString(), () => { }, false));
            this.AfterInitializeInternal();
        }

        public ResponsiveUIExample() : this(null)
        {
        }

        static ResponsiveUIExample()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(ResponsiveUIExampleTemplates.Default, dependencyProperties);

            dependencyProperties.Add(TestWidthProperty);
            dependencyProperties.Add(Region1Property);
            dependencyProperties.Add(Region1TemplateProperty);
            dependencyProperties.Add(Region2Property);
            dependencyProperties.Add(Region2TemplateProperty);
            dependencyProperties.Add(Label1Property);
            dependencyProperties.Add(Label1TemplateProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<Delight.ElementSize> TestWidthProperty = new DependencyProperty<Delight.ElementSize>("TestWidth");
        public Delight.ElementSize TestWidth
        {
            get { return TestWidthProperty.GetValue(this); }
            set { TestWidthProperty.SetValue(this, value); }
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

        public readonly static DependencyProperty<Region> Region2Property = new DependencyProperty<Region>("Region2");
        public Region Region2
        {
            get { return Region2Property.GetValue(this); }
            set { Region2Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Region2TemplateProperty = new DependencyProperty<Template>("Region2Template");
        public Template Region2Template
        {
            get { return Region2TemplateProperty.GetValue(this); }
            set { Region2TemplateProperty.SetValue(this, value); }
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

        #endregion
    }

    #region Data Templates

    public static class ResponsiveUIExampleTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return ResponsiveUIExample;
            }
        }

        private static Template _responsiveUIExample;
        public static Template ResponsiveUIExample
        {
            get
            {
#if UNITY_EDITOR
                if (_responsiveUIExample == null || _responsiveUIExample.CurrentVersion != Template.Version)
#else
                if (_responsiveUIExample == null)
#endif
                {
                    _responsiveUIExample = new Template(UIViewTemplates.UIView);
#if UNITY_EDITOR
                    _responsiveUIExample.Name = "ResponsiveUIExample";
                    _responsiveUIExample.LineNumber = 0;
                    _responsiveUIExample.LinePosition = 0;
#endif
                    Delight.ResponsiveUIExample.EnableScriptEventsProperty.SetDefault(_responsiveUIExample, true);
                    Delight.ResponsiveUIExample.TestWidthProperty.SetDefault(_responsiveUIExample, new ElementSize(100f, ElementSizeUnit.Pixels));
                    Delight.ResponsiveUIExample.Region1TemplateProperty.SetDefault(_responsiveUIExample, ResponsiveUIExampleRegion1);
                    Delight.ResponsiveUIExample.Region2TemplateProperty.SetDefault(_responsiveUIExample, ResponsiveUIExampleRegion2);
                    Delight.ResponsiveUIExample.Label1TemplateProperty.SetDefault(_responsiveUIExample, ResponsiveUIExampleLabel1);
                }
                return _responsiveUIExample;
            }
        }

        private static Template _responsiveUIExampleRegion1;
        public static Template ResponsiveUIExampleRegion1
        {
            get
            {
#if UNITY_EDITOR
                if (_responsiveUIExampleRegion1 == null || _responsiveUIExampleRegion1.CurrentVersion != Template.Version)
#else
                if (_responsiveUIExampleRegion1 == null)
#endif
                {
                    _responsiveUIExampleRegion1 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _responsiveUIExampleRegion1.Name = "ResponsiveUIExampleRegion1";
                    _responsiveUIExampleRegion1.LineNumber = 4;
                    _responsiveUIExampleRegion1.LinePosition = 4;
#endif
                    Delight.Region.BackgroundColorProperty.SetDefault(_responsiveUIExampleRegion1, new UnityEngine.Color(0f, 1f, 0f, 1f));
                    Delight.Region.WidthProperty.SetHasBinding(_responsiveUIExampleRegion1);
                }
                return _responsiveUIExampleRegion1;
            }
        }

        private static Template _responsiveUIExampleRegion2;
        public static Template ResponsiveUIExampleRegion2
        {
            get
            {
#if UNITY_EDITOR
                if (_responsiveUIExampleRegion2 == null || _responsiveUIExampleRegion2.CurrentVersion != Template.Version)
#else
                if (_responsiveUIExampleRegion2 == null)
#endif
                {
                    _responsiveUIExampleRegion2 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _responsiveUIExampleRegion2.Name = "ResponsiveUIExampleRegion2";
                    _responsiveUIExampleRegion2.LineNumber = 5;
                    _responsiveUIExampleRegion2.LinePosition = 4;
#endif
                    Delight.Region.BackgroundColorProperty.SetDefault(_responsiveUIExampleRegion2, new UnityEngine.Color(0f, 1f, 0f, 1f));
                    Delight.Region.IsActiveProperty.SetHasBinding(_responsiveUIExampleRegion2);
                }
                return _responsiveUIExampleRegion2;
            }
        }

        private static Template _responsiveUIExampleLabel1;
        public static Template ResponsiveUIExampleLabel1
        {
            get
            {
#if UNITY_EDITOR
                if (_responsiveUIExampleLabel1 == null || _responsiveUIExampleLabel1.CurrentVersion != Template.Version)
#else
                if (_responsiveUIExampleLabel1 == null)
#endif
                {
                    _responsiveUIExampleLabel1 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _responsiveUIExampleLabel1.Name = "ResponsiveUIExampleLabel1";
                    _responsiveUIExampleLabel1.LineNumber = 7;
                    _responsiveUIExampleLabel1.LinePosition = 4;
#endif
                    Delight.Label.TextProperty.SetHasBinding(_responsiveUIExampleLabel1);
                }
                return _responsiveUIExampleLabel1;
            }
        }

        #endregion
    }

    #endregion
}
