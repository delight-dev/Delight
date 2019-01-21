// Internal view logic generated from "DynamicListTest.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class DynamicListTest : LayoutRoot
    {
        #region Constructors

        public DynamicListTest(View parent, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :
            base(parent, layoutParent, id, template ?? DynamicListTestTemplates.Default, initializer)
        {
            // constructing Group (Group1)
            Group1 = new Group(this, this, "Group1", Group1Template);
            Group2 = new Group(this, Group1, "Group2", Group2Template);
            Button1 = new Button(this, Group2, "Button1", Button1Template, x => 
            {
                var source = x as Button;
                source.Click = ResolveActionHandler(this, "Test1");
            });
            Button2 = new Button(this, Group2, "Button2", Button2Template, x => 
            {
                var source = x as Button;
                source.Click = ResolveActionHandler(this, "Test2");
            });
            Region1 = new Region(this, Group1, "Region1", Region1Template);
            DynamicList = new List(this, Region1, "DynamicList", DynamicListTemplate);
        }

        public DynamicListTest() : this(null)
        {
        }

        static DynamicListTest()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(DynamicListTestTemplates.Default, dependencyProperties);

            dependencyProperties.Add(Group1Property);
            dependencyProperties.Add(Group1TemplateProperty);
            dependencyProperties.Add(Group2Property);
            dependencyProperties.Add(Group2TemplateProperty);
            dependencyProperties.Add(Button1Property);
            dependencyProperties.Add(Button1TemplateProperty);
            dependencyProperties.Add(Button2Property);
            dependencyProperties.Add(Button2TemplateProperty);
            dependencyProperties.Add(Region1Property);
            dependencyProperties.Add(Region1TemplateProperty);
            dependencyProperties.Add(DynamicListProperty);
            dependencyProperties.Add(DynamicListTemplateProperty);
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

        public readonly static DependencyProperty<Button> Button1Property = new DependencyProperty<Button>("Button1");
        public Button Button1
        {
            get { return Button1Property.GetValue(this); }
            set { Button1Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Button1TemplateProperty = new DependencyProperty<Template>("Button1Template");
        public Template Button1Template
        {
            get { return Button1TemplateProperty.GetValue(this); }
            set { Button1TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Button> Button2Property = new DependencyProperty<Button>("Button2");
        public Button Button2
        {
            get { return Button2Property.GetValue(this); }
            set { Button2Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Button2TemplateProperty = new DependencyProperty<Template>("Button2Template");
        public Template Button2Template
        {
            get { return Button2TemplateProperty.GetValue(this); }
            set { Button2TemplateProperty.SetValue(this, value); }
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

        public readonly static DependencyProperty<List> DynamicListProperty = new DependencyProperty<List>("DynamicList");
        public List DynamicList
        {
            get { return DynamicListProperty.GetValue(this); }
            set { DynamicListProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> DynamicListTemplateProperty = new DependencyProperty<Template>("DynamicListTemplate");
        public Template DynamicListTemplate
        {
            get { return DynamicListTemplateProperty.GetValue(this); }
            set { DynamicListTemplateProperty.SetValue(this, value); }
        }

        #endregion
    }

    #region Data Templates

    public static class DynamicListTestTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return DynamicListTest;
            }
        }

        private static Template _dynamicListTest;
        public static Template DynamicListTest
        {
            get
            {
#if UNITY_EDITOR
                if (_dynamicListTest == null || _dynamicListTest.CurrentVersion != Template.Version)
#else
                if (_dynamicListTest == null)
#endif
                {
                    _dynamicListTest = new Template(LayoutRootTemplates.LayoutRoot);
                    Delight.DynamicListTest.Group1TemplateProperty.SetDefault(_dynamicListTest, DynamicListTestGroup1);
                    Delight.DynamicListTest.Group2TemplateProperty.SetDefault(_dynamicListTest, DynamicListTestGroup2);
                    Delight.DynamicListTest.Button1TemplateProperty.SetDefault(_dynamicListTest, DynamicListTestButton1);
                    Delight.DynamicListTest.Button2TemplateProperty.SetDefault(_dynamicListTest, DynamicListTestButton2);
                    Delight.DynamicListTest.Region1TemplateProperty.SetDefault(_dynamicListTest, DynamicListTestRegion1);
                    Delight.DynamicListTest.DynamicListTemplateProperty.SetDefault(_dynamicListTest, DynamicListTestDynamicList);
                }
                return _dynamicListTest;
            }
        }

        private static Template _dynamicListTestGroup1;
        public static Template DynamicListTestGroup1
        {
            get
            {
#if UNITY_EDITOR
                if (_dynamicListTestGroup1 == null || _dynamicListTestGroup1.CurrentVersion != Template.Version)
#else
                if (_dynamicListTestGroup1 == null)
#endif
                {
                    _dynamicListTestGroup1 = new Template(GroupTemplates.Group);
                    Delight.Group.OrientationProperty.SetDefault(_dynamicListTestGroup1, Delight.ElementOrientation.Horizontal);
                }
                return _dynamicListTestGroup1;
            }
        }

        private static Template _dynamicListTestGroup2;
        public static Template DynamicListTestGroup2
        {
            get
            {
#if UNITY_EDITOR
                if (_dynamicListTestGroup2 == null || _dynamicListTestGroup2.CurrentVersion != Template.Version)
#else
                if (_dynamicListTestGroup2 == null)
#endif
                {
                    _dynamicListTestGroup2 = new Template(GroupTemplates.Group);
                    Delight.Group.SpacingProperty.SetDefault(_dynamicListTestGroup2, new ElementSize(10f, ElementSizeUnit.Pixels));
                    Delight.Group.WidthProperty.SetDefault(_dynamicListTestGroup2, new ElementSize(500f, ElementSizeUnit.Pixels));
                }
                return _dynamicListTestGroup2;
            }
        }

        private static Template _dynamicListTestButton1;
        public static Template DynamicListTestButton1
        {
            get
            {
#if UNITY_EDITOR
                if (_dynamicListTestButton1 == null || _dynamicListTestButton1.CurrentVersion != Template.Version)
#else
                if (_dynamicListTestButton1 == null)
#endif
                {
                    _dynamicListTestButton1 = new Template(ButtonTemplates.Button);
                    Delight.Button.LabelTemplateProperty.SetDefault(_dynamicListTestButton1, DynamicListTestButton1Label);
                }
                return _dynamicListTestButton1;
            }
        }

        private static Template _dynamicListTestButton1Label;
        public static Template DynamicListTestButton1Label
        {
            get
            {
#if UNITY_EDITOR
                if (_dynamicListTestButton1Label == null || _dynamicListTestButton1Label.CurrentVersion != Template.Version)
#else
                if (_dynamicListTestButton1Label == null)
#endif
                {
                    _dynamicListTestButton1Label = new Template(ButtonTemplates.ButtonLabel);
                    Delight.Label.TextProperty.SetDefault(_dynamicListTestButton1Label, "Test 1");
                }
                return _dynamicListTestButton1Label;
            }
        }

        private static Template _dynamicListTestButton2;
        public static Template DynamicListTestButton2
        {
            get
            {
#if UNITY_EDITOR
                if (_dynamicListTestButton2 == null || _dynamicListTestButton2.CurrentVersion != Template.Version)
#else
                if (_dynamicListTestButton2 == null)
#endif
                {
                    _dynamicListTestButton2 = new Template(ButtonTemplates.Button);
                    Delight.Button.LabelTemplateProperty.SetDefault(_dynamicListTestButton2, DynamicListTestButton2Label);
                }
                return _dynamicListTestButton2;
            }
        }

        private static Template _dynamicListTestButton2Label;
        public static Template DynamicListTestButton2Label
        {
            get
            {
#if UNITY_EDITOR
                if (_dynamicListTestButton2Label == null || _dynamicListTestButton2Label.CurrentVersion != Template.Version)
#else
                if (_dynamicListTestButton2Label == null)
#endif
                {
                    _dynamicListTestButton2Label = new Template(ButtonTemplates.ButtonLabel);
                    Delight.Label.TextProperty.SetDefault(_dynamicListTestButton2Label, "Test 2");
                }
                return _dynamicListTestButton2Label;
            }
        }

        private static Template _dynamicListTestRegion1;
        public static Template DynamicListTestRegion1
        {
            get
            {
#if UNITY_EDITOR
                if (_dynamicListTestRegion1 == null || _dynamicListTestRegion1.CurrentVersion != Template.Version)
#else
                if (_dynamicListTestRegion1 == null)
#endif
                {
                    _dynamicListTestRegion1 = new Template(RegionTemplates.Region);
                    Delight.Region.WidthProperty.SetDefault(_dynamicListTestRegion1, new ElementSize(500f, ElementSizeUnit.Pixels));
                    Delight.Region.MarginProperty.SetDefault(_dynamicListTestRegion1, new ElementMargin(50f, 50f, 50f, 50f));
                }
                return _dynamicListTestRegion1;
            }
        }

        private static Template _dynamicListTestDynamicList;
        public static Template DynamicListTestDynamicList
        {
            get
            {
#if UNITY_EDITOR
                if (_dynamicListTestDynamicList == null || _dynamicListTestDynamicList.CurrentVersion != Template.Version)
#else
                if (_dynamicListTestDynamicList == null)
#endif
                {
                    _dynamicListTestDynamicList = new Template(ListTemplates.List);
                    Delight.List.BackgroundColorProperty.SetDefault(_dynamicListTestDynamicList, new UnityEngine.Color(0f, 1f, 0f, 1f));
                }
                return _dynamicListTestDynamicList;
            }
        }

        #endregion
    }

    #endregion
}
