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

            // constructing Region (RegionTest2)
            RegionTest2 = new Region(this, this, "RegionTest2", RegionTest2Template);

            // binding <Region Width="$ {@ScreenWidth.Pixels} - 600">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "ScreenWidth", "Pixels" }, new List<Func<object>> { () => Models.Globals, () => Models.Globals.ScreenWidth }) }, new BindingPath(new List<string> { "RegionTest2", "Width" }, new List<Func<object>> { () => this, () => RegionTest2 }), () => RegionTest2.Width = Models.Globals.ScreenWidth.Pixels - 600, () => { }, false));

            // constructing Region (RegionTest3)
            RegionTest3 = new Region(this, this, "RegionTest3", RegionTest3Template);

            // binding <Region Width="$ {@ScreenWidth.Pixels} - 300">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "ScreenWidth", "Pixels" }, new List<Func<object>> { () => Models.Globals, () => Models.Globals.ScreenWidth }) }, new BindingPath(new List<string> { "RegionTest3", "Width" }, new List<Func<object>> { () => this, () => RegionTest3 }), () => RegionTest3.Width = Models.Globals.ScreenWidth.Pixels - 300, () => { }, false));

            // constructing Region (RegionTest4)
            RegionTest4 = new Region(this, this, "RegionTest4", RegionTest4Template);

            // binding <Region Width="$ {@IsPortrait} ? 500 : 1000">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "IsPortrait" }, new List<Func<object>> { () => Models.Globals }) }, new BindingPath(new List<string> { "RegionTest4", "Width" }, new List<Func<object>> { () => this, () => RegionTest4 }), () => RegionTest4.Width = Models.Globals.IsPortrait ? 500 : 1000, () => { }, false));
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
            dependencyProperties.Add(RegionTest2Property);
            dependencyProperties.Add(RegionTest2TemplateProperty);
            dependencyProperties.Add(RegionTest3Property);
            dependencyProperties.Add(RegionTest3TemplateProperty);
            dependencyProperties.Add(RegionTest4Property);
            dependencyProperties.Add(RegionTest4TemplateProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<Delight.ElementSize> TestWidthProperty = new DependencyProperty<Delight.ElementSize>("TestWidth");
        public Delight.ElementSize TestWidth
        {
            get { return TestWidthProperty.GetValue(this); }
            set { TestWidthProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> RegionTest2Property = new DependencyProperty<Region>("RegionTest2");
        public Region RegionTest2
        {
            get { return RegionTest2Property.GetValue(this); }
            set { RegionTest2Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> RegionTest2TemplateProperty = new DependencyProperty<Template>("RegionTest2Template");
        public Template RegionTest2Template
        {
            get { return RegionTest2TemplateProperty.GetValue(this); }
            set { RegionTest2TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> RegionTest3Property = new DependencyProperty<Region>("RegionTest3");
        public Region RegionTest3
        {
            get { return RegionTest3Property.GetValue(this); }
            set { RegionTest3Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> RegionTest3TemplateProperty = new DependencyProperty<Template>("RegionTest3Template");
        public Template RegionTest3Template
        {
            get { return RegionTest3TemplateProperty.GetValue(this); }
            set { RegionTest3TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> RegionTest4Property = new DependencyProperty<Region>("RegionTest4");
        public Region RegionTest4
        {
            get { return RegionTest4Property.GetValue(this); }
            set { RegionTest4Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> RegionTest4TemplateProperty = new DependencyProperty<Template>("RegionTest4Template");
        public Template RegionTest4Template
        {
            get { return RegionTest4TemplateProperty.GetValue(this); }
            set { RegionTest4TemplateProperty.SetValue(this, value); }
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
                    Delight.ResponsiveUIExample.RegionTest2TemplateProperty.SetDefault(_responsiveUIExample, ResponsiveUIExampleRegionTest2);
                    Delight.ResponsiveUIExample.RegionTest3TemplateProperty.SetDefault(_responsiveUIExample, ResponsiveUIExampleRegionTest3);
                    Delight.ResponsiveUIExample.RegionTest4TemplateProperty.SetDefault(_responsiveUIExample, ResponsiveUIExampleRegionTest4);
                }
                return _responsiveUIExample;
            }
        }

        private static Template _responsiveUIExampleRegionTest2;
        public static Template ResponsiveUIExampleRegionTest2
        {
            get
            {
#if UNITY_EDITOR
                if (_responsiveUIExampleRegionTest2 == null || _responsiveUIExampleRegionTest2.CurrentVersion != Template.Version)
#else
                if (_responsiveUIExampleRegionTest2 == null)
#endif
                {
                    _responsiveUIExampleRegionTest2 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _responsiveUIExampleRegionTest2.Name = "ResponsiveUIExampleRegionTest2";
                    _responsiveUIExampleRegionTest2.LineNumber = 4;
                    _responsiveUIExampleRegionTest2.LinePosition = 4;
#endif
                    Delight.Region.BackgroundColorProperty.SetDefault(_responsiveUIExampleRegionTest2, new UnityEngine.Color(0f, 1f, 0f, 1f));
                    Delight.Region.WidthProperty.SetHasBinding(_responsiveUIExampleRegionTest2);
                }
                return _responsiveUIExampleRegionTest2;
            }
        }

        private static Template _responsiveUIExampleRegionTest3;
        public static Template ResponsiveUIExampleRegionTest3
        {
            get
            {
#if UNITY_EDITOR
                if (_responsiveUIExampleRegionTest3 == null || _responsiveUIExampleRegionTest3.CurrentVersion != Template.Version)
#else
                if (_responsiveUIExampleRegionTest3 == null)
#endif
                {
                    _responsiveUIExampleRegionTest3 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _responsiveUIExampleRegionTest3.Name = "ResponsiveUIExampleRegionTest3";
                    _responsiveUIExampleRegionTest3.LineNumber = 5;
                    _responsiveUIExampleRegionTest3.LinePosition = 4;
#endif
                    Delight.Region.BackgroundColorProperty.SetDefault(_responsiveUIExampleRegionTest3, new UnityEngine.Color(0f, 0f, 1f, 1f));
                    Delight.Region.WidthProperty.SetHasBinding(_responsiveUIExampleRegionTest3);
                }
                return _responsiveUIExampleRegionTest3;
            }
        }

        private static Template _responsiveUIExampleRegionTest4;
        public static Template ResponsiveUIExampleRegionTest4
        {
            get
            {
#if UNITY_EDITOR
                if (_responsiveUIExampleRegionTest4 == null || _responsiveUIExampleRegionTest4.CurrentVersion != Template.Version)
#else
                if (_responsiveUIExampleRegionTest4 == null)
#endif
                {
                    _responsiveUIExampleRegionTest4 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _responsiveUIExampleRegionTest4.Name = "ResponsiveUIExampleRegionTest4";
                    _responsiveUIExampleRegionTest4.LineNumber = 7;
                    _responsiveUIExampleRegionTest4.LinePosition = 4;
#endif
                    Delight.Region.BackgroundColorProperty.SetDefault(_responsiveUIExampleRegionTest4, new UnityEngine.Color(1f, 1f, 0f, 1f));
                    Delight.Region.WidthProperty.SetHasBinding(_responsiveUIExampleRegionTest4);
                }
                return _responsiveUIExampleRegionTest4;
            }
        }

        #endregion
    }

    #endregion
}
