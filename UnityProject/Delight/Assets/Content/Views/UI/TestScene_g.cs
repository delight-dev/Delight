// Internal view logic generated from "TestScene.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class TestScene : LayoutRoot
    {
        #region Constructors

        public TestScene(View parent, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :
            base(parent, layoutParent, id, template ?? TestSceneTemplates.Default, initializer)
        {
            // constructing Group (Group1)
            Group1 = new Group(this, this, "Group1", Group1Template);
            Button1 = new Button(this, Group1, "Button1", Button1Template, x => 
            {
                var source = x as Button;
                source.Click = ResolveActionHandler(this, "Test1");
            });
            Button2 = new Button(this, Group1, "Button2", Button2Template, x => 
            {
                var source = x as Button;
                source.Click = ResolveActionHandler(this, "Test2");
            });

            // constructing Region (Region1)
            Region1 = new Region(this, this, "Region1", Region1Template);
            BindingTest1 = new BindingTest(this, Region1, "BindingTest1", BindingTest1Template);
        }

        public TestScene() : this(null)
        {
        }

        static TestScene()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(TestSceneTemplates.Default, dependencyProperties);

            dependencyProperties.Add(Group1Property);
            dependencyProperties.Add(Group1TemplateProperty);
            dependencyProperties.Add(Button1Property);
            dependencyProperties.Add(Button1TemplateProperty);
            dependencyProperties.Add(Button2Property);
            dependencyProperties.Add(Button2TemplateProperty);
            dependencyProperties.Add(Region1Property);
            dependencyProperties.Add(Region1TemplateProperty);
            dependencyProperties.Add(BindingTest1Property);
            dependencyProperties.Add(BindingTest1TemplateProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<Group> Group1Property = new DependencyProperty<Group>();
        public Group Group1
        {
            get { return Group1Property.GetValue(this); }
            set { Group1Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Group1TemplateProperty = new DependencyProperty<Template>();
        public Template Group1Template
        {
            get { return Group1TemplateProperty.GetValue(this); }
            set { Group1TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Button> Button1Property = new DependencyProperty<Button>();
        public Button Button1
        {
            get { return Button1Property.GetValue(this); }
            set { Button1Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Button1TemplateProperty = new DependencyProperty<Template>();
        public Template Button1Template
        {
            get { return Button1TemplateProperty.GetValue(this); }
            set { Button1TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Button> Button2Property = new DependencyProperty<Button>();
        public Button Button2
        {
            get { return Button2Property.GetValue(this); }
            set { Button2Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Button2TemplateProperty = new DependencyProperty<Template>();
        public Template Button2Template
        {
            get { return Button2TemplateProperty.GetValue(this); }
            set { Button2TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> Region1Property = new DependencyProperty<Region>();
        public Region Region1
        {
            get { return Region1Property.GetValue(this); }
            set { Region1Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Region1TemplateProperty = new DependencyProperty<Template>();
        public Template Region1Template
        {
            get { return Region1TemplateProperty.GetValue(this); }
            set { Region1TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<BindingTest> BindingTest1Property = new DependencyProperty<BindingTest>();
        public BindingTest BindingTest1
        {
            get { return BindingTest1Property.GetValue(this); }
            set { BindingTest1Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> BindingTest1TemplateProperty = new DependencyProperty<Template>();
        public Template BindingTest1Template
        {
            get { return BindingTest1TemplateProperty.GetValue(this); }
            set { BindingTest1TemplateProperty.SetValue(this, value); }
        }

        #endregion
    }

    #region Data Templates

    public static class TestSceneTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return TestScene;
            }
        }

        private static Template _testScene;
        public static Template TestScene
        {
            get
            {
#if UNITY_EDITOR
                if (_testScene == null || _testScene.CurrentVersion != Template.Version)
#else
                if (_testScene == null)
#endif
                {
                    _testScene = new Template(LayoutRootTemplates.LayoutRoot);
                    Delight.TestScene.Group1TemplateProperty.SetDefault(_testScene, TestSceneGroup1);
                    Delight.TestScene.Button1TemplateProperty.SetDefault(_testScene, TestSceneButton1);
                    Delight.TestScene.Button2TemplateProperty.SetDefault(_testScene, TestSceneButton2);
                    Delight.TestScene.Region1TemplateProperty.SetDefault(_testScene, TestSceneRegion1);
                    Delight.TestScene.BindingTest1TemplateProperty.SetDefault(_testScene, TestSceneBindingTest1);
                }
                return _testScene;
            }
        }

        private static Template _testSceneGroup1;
        public static Template TestSceneGroup1
        {
            get
            {
#if UNITY_EDITOR
                if (_testSceneGroup1 == null || _testSceneGroup1.CurrentVersion != Template.Version)
#else
                if (_testSceneGroup1 == null)
#endif
                {
                    _testSceneGroup1 = new Template(GroupTemplates.Group);
                    Delight.Group.OrientationProperty.SetDefault(_testSceneGroup1, Delight.ElementOrientation.Horizontal);
                    Delight.Group.AlignmentProperty.SetDefault(_testSceneGroup1, Delight.ElementAlignment.TopLeft);
                    Delight.Group.OffsetProperty.SetDefault(_testSceneGroup1, new ElementMargin(10f, 10f, 0f, 0f));
                    Delight.Group.SpacingProperty.SetDefault(_testSceneGroup1, new ElementSize(10f, ElementSizeUnit.Pixels));
                }
                return _testSceneGroup1;
            }
        }

        private static Template _testSceneButton1;
        public static Template TestSceneButton1
        {
            get
            {
#if UNITY_EDITOR
                if (_testSceneButton1 == null || _testSceneButton1.CurrentVersion != Template.Version)
#else
                if (_testSceneButton1 == null)
#endif
                {
                    _testSceneButton1 = new Template(ButtonTemplates.Button);
                    Delight.Button.LabelTemplateProperty.SetDefault(_testSceneButton1, TestSceneButton1Label);
                }
                return _testSceneButton1;
            }
        }

        private static Template _testSceneButton1Label;
        public static Template TestSceneButton1Label
        {
            get
            {
#if UNITY_EDITOR
                if (_testSceneButton1Label == null || _testSceneButton1Label.CurrentVersion != Template.Version)
#else
                if (_testSceneButton1Label == null)
#endif
                {
                    _testSceneButton1Label = new Template(ButtonTemplates.ButtonLabel);
                    Delight.Label.TextProperty.SetDefault(_testSceneButton1Label, "Test 1");
                }
                return _testSceneButton1Label;
            }
        }

        private static Template _testSceneButton2;
        public static Template TestSceneButton2
        {
            get
            {
#if UNITY_EDITOR
                if (_testSceneButton2 == null || _testSceneButton2.CurrentVersion != Template.Version)
#else
                if (_testSceneButton2 == null)
#endif
                {
                    _testSceneButton2 = new Template(ButtonTemplates.Button);
                    Delight.Button.LabelTemplateProperty.SetDefault(_testSceneButton2, TestSceneButton2Label);
                }
                return _testSceneButton2;
            }
        }

        private static Template _testSceneButton2Label;
        public static Template TestSceneButton2Label
        {
            get
            {
#if UNITY_EDITOR
                if (_testSceneButton2Label == null || _testSceneButton2Label.CurrentVersion != Template.Version)
#else
                if (_testSceneButton2Label == null)
#endif
                {
                    _testSceneButton2Label = new Template(ButtonTemplates.ButtonLabel);
                    Delight.Label.TextProperty.SetDefault(_testSceneButton2Label, "Test 2");
                }
                return _testSceneButton2Label;
            }
        }

        private static Template _testSceneRegion1;
        public static Template TestSceneRegion1
        {
            get
            {
#if UNITY_EDITOR
                if (_testSceneRegion1 == null || _testSceneRegion1.CurrentVersion != Template.Version)
#else
                if (_testSceneRegion1 == null)
#endif
                {
                    _testSceneRegion1 = new Template(RegionTemplates.Region);
                    Delight.Region.MarginProperty.SetDefault(_testSceneRegion1, new ElementMargin(0f, 200f, 0f, 0f));
                }
                return _testSceneRegion1;
            }
        }

        private static Template _testSceneBindingTest1;
        public static Template TestSceneBindingTest1
        {
            get
            {
#if UNITY_EDITOR
                if (_testSceneBindingTest1 == null || _testSceneBindingTest1.CurrentVersion != Template.Version)
#else
                if (_testSceneBindingTest1 == null)
#endif
                {
                    _testSceneBindingTest1 = new Template(BindingTestTemplates.BindingTest);
                    Delight.BindingTest.TestBindingProperty.SetDefault(_testSceneBindingTest1, "Patrik");
                    Delight.BindingTest.Region1TemplateProperty.SetDefault(_testSceneBindingTest1, TestSceneBindingTest1Region1);
                    Delight.BindingTest.Group1TemplateProperty.SetDefault(_testSceneBindingTest1, TestSceneBindingTest1Group1);
                    Delight.BindingTest.Button1TemplateProperty.SetDefault(_testSceneBindingTest1, TestSceneBindingTest1Button1);
                    Delight.BindingTest.Button2TemplateProperty.SetDefault(_testSceneBindingTest1, TestSceneBindingTest1Button2);
                    Delight.BindingTest.Button3TemplateProperty.SetDefault(_testSceneBindingTest1, TestSceneBindingTest1Button3);
                    Delight.BindingTest.LargeButton1TemplateProperty.SetDefault(_testSceneBindingTest1, TestSceneBindingTest1LargeButton1);
                    Delight.BindingTest.Label1TemplateProperty.SetDefault(_testSceneBindingTest1, TestSceneBindingTest1Label1);
                    Delight.BindingTest.Button4TemplateProperty.SetDefault(_testSceneBindingTest1, TestSceneBindingTest1Button4);
                    Delight.BindingTest.RegionOnDemandTemplateProperty.SetDefault(_testSceneBindingTest1, TestSceneBindingTest1RegionOnDemand);
                    Delight.BindingTest.Label2TemplateProperty.SetDefault(_testSceneBindingTest1, TestSceneBindingTest1Label2);
                }
                return _testSceneBindingTest1;
            }
        }

        private static Template _testSceneBindingTest1Region1;
        public static Template TestSceneBindingTest1Region1
        {
            get
            {
#if UNITY_EDITOR
                if (_testSceneBindingTest1Region1 == null || _testSceneBindingTest1Region1.CurrentVersion != Template.Version)
#else
                if (_testSceneBindingTest1Region1 == null)
#endif
                {
                    _testSceneBindingTest1Region1 = new Template(BindingTestTemplates.BindingTestRegion1);
                }
                return _testSceneBindingTest1Region1;
            }
        }

        private static Template _testSceneBindingTest1Group1;
        public static Template TestSceneBindingTest1Group1
        {
            get
            {
#if UNITY_EDITOR
                if (_testSceneBindingTest1Group1 == null || _testSceneBindingTest1Group1.CurrentVersion != Template.Version)
#else
                if (_testSceneBindingTest1Group1 == null)
#endif
                {
                    _testSceneBindingTest1Group1 = new Template(BindingTestTemplates.BindingTestGroup1);
                }
                return _testSceneBindingTest1Group1;
            }
        }

        private static Template _testSceneBindingTest1Button1;
        public static Template TestSceneBindingTest1Button1
        {
            get
            {
#if UNITY_EDITOR
                if (_testSceneBindingTest1Button1 == null || _testSceneBindingTest1Button1.CurrentVersion != Template.Version)
#else
                if (_testSceneBindingTest1Button1 == null)
#endif
                {
                    _testSceneBindingTest1Button1 = new Template(BindingTestTemplates.BindingTestButton1);
                    Delight.Button.BackgroundColorProperty.SetDefault(_testSceneBindingTest1Button1, new UnityEngine.Color(1f, 1f, 0f, 1f));
                    Delight.Button.LabelTemplateProperty.SetDefault(_testSceneBindingTest1Button1, TestSceneBindingTest1Button1Label);
                }
                return _testSceneBindingTest1Button1;
            }
        }

        private static Template _testSceneBindingTest1Button1Label;
        public static Template TestSceneBindingTest1Button1Label
        {
            get
            {
#if UNITY_EDITOR
                if (_testSceneBindingTest1Button1Label == null || _testSceneBindingTest1Button1Label.CurrentVersion != Template.Version)
#else
                if (_testSceneBindingTest1Button1Label == null)
#endif
                {
                    _testSceneBindingTest1Button1Label = new Template(BindingTestTemplates.BindingTestButton1Label);
                }
                return _testSceneBindingTest1Button1Label;
            }
        }

        private static Template _testSceneBindingTest1Button2;
        public static Template TestSceneBindingTest1Button2
        {
            get
            {
#if UNITY_EDITOR
                if (_testSceneBindingTest1Button2 == null || _testSceneBindingTest1Button2.CurrentVersion != Template.Version)
#else
                if (_testSceneBindingTest1Button2 == null)
#endif
                {
                    _testSceneBindingTest1Button2 = new Template(BindingTestTemplates.BindingTestButton2);
                    Delight.Button.LabelTemplateProperty.SetDefault(_testSceneBindingTest1Button2, TestSceneBindingTest1Button2Label);
                }
                return _testSceneBindingTest1Button2;
            }
        }

        private static Template _testSceneBindingTest1Button2Label;
        public static Template TestSceneBindingTest1Button2Label
        {
            get
            {
#if UNITY_EDITOR
                if (_testSceneBindingTest1Button2Label == null || _testSceneBindingTest1Button2Label.CurrentVersion != Template.Version)
#else
                if (_testSceneBindingTest1Button2Label == null)
#endif
                {
                    _testSceneBindingTest1Button2Label = new Template(BindingTestTemplates.BindingTestButton2Label);
                }
                return _testSceneBindingTest1Button2Label;
            }
        }

        private static Template _testSceneBindingTest1Button3;
        public static Template TestSceneBindingTest1Button3
        {
            get
            {
#if UNITY_EDITOR
                if (_testSceneBindingTest1Button3 == null || _testSceneBindingTest1Button3.CurrentVersion != Template.Version)
#else
                if (_testSceneBindingTest1Button3 == null)
#endif
                {
                    _testSceneBindingTest1Button3 = new Template(BindingTestTemplates.BindingTestButton3);
                    Delight.Button.LabelTemplateProperty.SetDefault(_testSceneBindingTest1Button3, TestSceneBindingTest1Button3Label);
                }
                return _testSceneBindingTest1Button3;
            }
        }

        private static Template _testSceneBindingTest1Button3Label;
        public static Template TestSceneBindingTest1Button3Label
        {
            get
            {
#if UNITY_EDITOR
                if (_testSceneBindingTest1Button3Label == null || _testSceneBindingTest1Button3Label.CurrentVersion != Template.Version)
#else
                if (_testSceneBindingTest1Button3Label == null)
#endif
                {
                    _testSceneBindingTest1Button3Label = new Template(BindingTestTemplates.BindingTestButton3Label);
                }
                return _testSceneBindingTest1Button3Label;
            }
        }

        private static Template _testSceneBindingTest1LargeButton1;
        public static Template TestSceneBindingTest1LargeButton1
        {
            get
            {
#if UNITY_EDITOR
                if (_testSceneBindingTest1LargeButton1 == null || _testSceneBindingTest1LargeButton1.CurrentVersion != Template.Version)
#else
                if (_testSceneBindingTest1LargeButton1 == null)
#endif
                {
                    _testSceneBindingTest1LargeButton1 = new Template(BindingTestTemplates.BindingTestLargeButton1);
                    Delight.LargeButton.LabelTemplateProperty.SetDefault(_testSceneBindingTest1LargeButton1, TestSceneBindingTest1LargeButton1Label);
                }
                return _testSceneBindingTest1LargeButton1;
            }
        }

        private static Template _testSceneBindingTest1LargeButton1Label;
        public static Template TestSceneBindingTest1LargeButton1Label
        {
            get
            {
#if UNITY_EDITOR
                if (_testSceneBindingTest1LargeButton1Label == null || _testSceneBindingTest1LargeButton1Label.CurrentVersion != Template.Version)
#else
                if (_testSceneBindingTest1LargeButton1Label == null)
#endif
                {
                    _testSceneBindingTest1LargeButton1Label = new Template(BindingTestTemplates.BindingTestLargeButton1Label);
                }
                return _testSceneBindingTest1LargeButton1Label;
            }
        }

        private static Template _testSceneBindingTest1Label1;
        public static Template TestSceneBindingTest1Label1
        {
            get
            {
#if UNITY_EDITOR
                if (_testSceneBindingTest1Label1 == null || _testSceneBindingTest1Label1.CurrentVersion != Template.Version)
#else
                if (_testSceneBindingTest1Label1 == null)
#endif
                {
                    _testSceneBindingTest1Label1 = new Template(BindingTestTemplates.BindingTestLabel1);
                }
                return _testSceneBindingTest1Label1;
            }
        }

        private static Template _testSceneBindingTest1Button4;
        public static Template TestSceneBindingTest1Button4
        {
            get
            {
#if UNITY_EDITOR
                if (_testSceneBindingTest1Button4 == null || _testSceneBindingTest1Button4.CurrentVersion != Template.Version)
#else
                if (_testSceneBindingTest1Button4 == null)
#endif
                {
                    _testSceneBindingTest1Button4 = new Template(BindingTestTemplates.BindingTestButton4);
                    Delight.Button.LabelTemplateProperty.SetDefault(_testSceneBindingTest1Button4, TestSceneBindingTest1Button4Label);
                }
                return _testSceneBindingTest1Button4;
            }
        }

        private static Template _testSceneBindingTest1Button4Label;
        public static Template TestSceneBindingTest1Button4Label
        {
            get
            {
#if UNITY_EDITOR
                if (_testSceneBindingTest1Button4Label == null || _testSceneBindingTest1Button4Label.CurrentVersion != Template.Version)
#else
                if (_testSceneBindingTest1Button4Label == null)
#endif
                {
                    _testSceneBindingTest1Button4Label = new Template(BindingTestTemplates.BindingTestButton4Label);
                }
                return _testSceneBindingTest1Button4Label;
            }
        }

        private static Template _testSceneBindingTest1RegionOnDemand;
        public static Template TestSceneBindingTest1RegionOnDemand
        {
            get
            {
#if UNITY_EDITOR
                if (_testSceneBindingTest1RegionOnDemand == null || _testSceneBindingTest1RegionOnDemand.CurrentVersion != Template.Version)
#else
                if (_testSceneBindingTest1RegionOnDemand == null)
#endif
                {
                    _testSceneBindingTest1RegionOnDemand = new Template(BindingTestTemplates.BindingTestRegionOnDemand);
                }
                return _testSceneBindingTest1RegionOnDemand;
            }
        }

        private static Template _testSceneBindingTest1Label2;
        public static Template TestSceneBindingTest1Label2
        {
            get
            {
#if UNITY_EDITOR
                if (_testSceneBindingTest1Label2 == null || _testSceneBindingTest1Label2.CurrentVersion != Template.Version)
#else
                if (_testSceneBindingTest1Label2 == null)
#endif
                {
                    _testSceneBindingTest1Label2 = new Template(BindingTestTemplates.BindingTestLabel2);
                }
                return _testSceneBindingTest1Label2;
            }
        }

        #endregion
    }

    #endregion
}
