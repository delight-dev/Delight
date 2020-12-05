// Internal view logic generated from "AdaptableUITest.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class AdaptableUITest : UIView
    {
        #region Constructors

        public AdaptableUITest(View parent, View layoutParent = null, string id = null, Template template = null, bool deferInitialization = false) :
            base(parent, layoutParent, id, template ?? AdaptableUITestTemplates.Default, deferInitialization)
        {
            if (deferInitialization)
                return;

            // constructing Region (RegionTest)
            RegionTest = new Region(this, this, "RegionTest", RegionTestTemplate);

            // binding <Region Width="{TestWidth}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "TestWidth" }, new List<Func<object>> { () => this }) }, new BindingPath(new List<string> { "RegionTest", "Width" }, new List<Func<object>> { () => this, () => RegionTest }), () => RegionTest.Width = TestWidth, () => { }, false));
            this.AfterInitializeInternal();
        }

        public AdaptableUITest() : this(null)
        {
        }

        static AdaptableUITest()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(AdaptableUITestTemplates.Default, dependencyProperties);

            dependencyProperties.Add(TestWidthProperty);
            dependencyProperties.Add(RegionTestProperty);
            dependencyProperties.Add(RegionTestTemplateProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<Delight.ElementSize> TestWidthProperty = new DependencyProperty<Delight.ElementSize>("TestWidth");
        public Delight.ElementSize TestWidth
        {
            get { return TestWidthProperty.GetValue(this); }
            set { TestWidthProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> RegionTestProperty = new DependencyProperty<Region>("RegionTest");
        public Region RegionTest
        {
            get { return RegionTestProperty.GetValue(this); }
            set { RegionTestProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> RegionTestTemplateProperty = new DependencyProperty<Template>("RegionTestTemplate");
        public Template RegionTestTemplate
        {
            get { return RegionTestTemplateProperty.GetValue(this); }
            set { RegionTestTemplateProperty.SetValue(this, value); }
        }

        #endregion
    }

    #region Data Templates

    public static class AdaptableUITestTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return AdaptableUITest;
            }
        }

        private static Template _adaptableUITest;
        public static Template AdaptableUITest
        {
            get
            {
#if UNITY_EDITOR
                if (_adaptableUITest == null || _adaptableUITest.CurrentVersion != Template.Version)
#else
                if (_adaptableUITest == null)
#endif
                {
                    _adaptableUITest = new Template(UIViewTemplates.UIView);
#if UNITY_EDITOR
                    _adaptableUITest.Name = "AdaptableUITest";
                    _adaptableUITest.LineNumber = 0;
                    _adaptableUITest.LinePosition = 0;
#endif
                    Delight.AdaptableUITest.EnableScriptEventsProperty.SetDefault(_adaptableUITest, true);
                    Delight.AdaptableUITest.TestWidthProperty.SetDefault(_adaptableUITest, new ElementSize(100f, ElementSizeUnit.Pixels));
                    Delight.AdaptableUITest.RegionTestTemplateProperty.SetDefault(_adaptableUITest, AdaptableUITestRegionTest);
                }
                return _adaptableUITest;
            }
        }

        private static Template _adaptableUITestRegionTest;
        public static Template AdaptableUITestRegionTest
        {
            get
            {
#if UNITY_EDITOR
                if (_adaptableUITestRegionTest == null || _adaptableUITestRegionTest.CurrentVersion != Template.Version)
#else
                if (_adaptableUITestRegionTest == null)
#endif
                {
                    _adaptableUITestRegionTest = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _adaptableUITestRegionTest.Name = "AdaptableUITestRegionTest";
                    _adaptableUITestRegionTest.LineNumber = 4;
                    _adaptableUITestRegionTest.LinePosition = 4;
#endif
                    Delight.Region.WidthProperty.SetStateDefault("Landscape", _adaptableUITestRegionTest, new ElementSize(500f, ElementSizeUnit.Pixels));
                    Delight.Region.BackgroundColorProperty.SetDefault(_adaptableUITestRegionTest, new UnityEngine.Color(0f, 0f, 1f, 1f));
                    Delight.Region.BackgroundColorProperty.SetStateDefault("Landscape", _adaptableUITestRegionTest, new UnityEngine.Color(1f, 0f, 0f, 1f));
                    Delight.Region.WidthProperty.SetHasBinding(_adaptableUITestRegionTest);
                }
                return _adaptableUITestRegionTest;
            }
        }

        #endregion
    }

    #endregion
}
