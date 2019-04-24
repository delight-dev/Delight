// Internal view logic generated from "ViewSwitcherTest.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class ViewSwitcherTest : LayoutRoot
    {
        #region Constructors

        public ViewSwitcherTest(View parent, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :
            base(parent, layoutParent, id, template ?? ViewSwitcherTestTemplates.Default, initializer)
        {
            // constructing Region (Region1)
            Region1 = new Region(this, this, "Region1", Region1Template);
            Group1 = new Group(this, Region1.Content, "Group1", Group1Template);
            Button1 = new Button(this, Group1.Content, "Button1", Button1Template);
            Button1.Click += ResolveActionHandler(this, "ShowModelBindingTest");
            Button2 = new Button(this, Group1.Content, "Button2", Button2Template);
            Button2.Click += ResolveActionHandler(this, "ShowScrollExample");
            Button3 = new Button(this, Group1.Content, "Button3", Button3Template);
            Button3.Click += ResolveActionHandler(this, "ShowAssetManagementTest");
            ViewSwitcher1 = new ViewSwitcher(this, Region1.Content, "ViewSwitcher1", ViewSwitcher1Template);
            ModelBindingTest = new ModelBindingTest(this, ViewSwitcher1.Content, "ModelBindingTest", ModelBindingTestTemplate);
            ScrollExample = new ScrollExample(this, ViewSwitcher1.Content, "ScrollExample", ScrollExampleTemplate);
            AssetManagementTest = new AssetManagementTest(this, ViewSwitcher1.Content, "AssetManagementTest", AssetManagementTestTemplate);
            this.AfterInitializeInternal();
        }

        public ViewSwitcherTest() : this(null)
        {
        }

        static ViewSwitcherTest()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(ViewSwitcherTestTemplates.Default, dependencyProperties);

            dependencyProperties.Add(Region1Property);
            dependencyProperties.Add(Region1TemplateProperty);
            dependencyProperties.Add(Group1Property);
            dependencyProperties.Add(Group1TemplateProperty);
            dependencyProperties.Add(Button1Property);
            dependencyProperties.Add(Button1TemplateProperty);
            dependencyProperties.Add(Button2Property);
            dependencyProperties.Add(Button2TemplateProperty);
            dependencyProperties.Add(Button3Property);
            dependencyProperties.Add(Button3TemplateProperty);
            dependencyProperties.Add(ViewSwitcher1Property);
            dependencyProperties.Add(ViewSwitcher1TemplateProperty);
            dependencyProperties.Add(ModelBindingTestProperty);
            dependencyProperties.Add(ModelBindingTestTemplateProperty);
            dependencyProperties.Add(ScrollExampleProperty);
            dependencyProperties.Add(ScrollExampleTemplateProperty);
            dependencyProperties.Add(AssetManagementTestProperty);
            dependencyProperties.Add(AssetManagementTestTemplateProperty);
        }

        #endregion

        #region Properties

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

        public readonly static DependencyProperty<Button> Button3Property = new DependencyProperty<Button>("Button3");
        public Button Button3
        {
            get { return Button3Property.GetValue(this); }
            set { Button3Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Button3TemplateProperty = new DependencyProperty<Template>("Button3Template");
        public Template Button3Template
        {
            get { return Button3TemplateProperty.GetValue(this); }
            set { Button3TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ViewSwitcher> ViewSwitcher1Property = new DependencyProperty<ViewSwitcher>("ViewSwitcher1");
        public ViewSwitcher ViewSwitcher1
        {
            get { return ViewSwitcher1Property.GetValue(this); }
            set { ViewSwitcher1Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> ViewSwitcher1TemplateProperty = new DependencyProperty<Template>("ViewSwitcher1Template");
        public Template ViewSwitcher1Template
        {
            get { return ViewSwitcher1TemplateProperty.GetValue(this); }
            set { ViewSwitcher1TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ModelBindingTest> ModelBindingTestProperty = new DependencyProperty<ModelBindingTest>("ModelBindingTest");
        public ModelBindingTest ModelBindingTest
        {
            get { return ModelBindingTestProperty.GetValue(this); }
            set { ModelBindingTestProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> ModelBindingTestTemplateProperty = new DependencyProperty<Template>("ModelBindingTestTemplate");
        public Template ModelBindingTestTemplate
        {
            get { return ModelBindingTestTemplateProperty.GetValue(this); }
            set { ModelBindingTestTemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ScrollExample> ScrollExampleProperty = new DependencyProperty<ScrollExample>("ScrollExample");
        public ScrollExample ScrollExample
        {
            get { return ScrollExampleProperty.GetValue(this); }
            set { ScrollExampleProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> ScrollExampleTemplateProperty = new DependencyProperty<Template>("ScrollExampleTemplate");
        public Template ScrollExampleTemplate
        {
            get { return ScrollExampleTemplateProperty.GetValue(this); }
            set { ScrollExampleTemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<AssetManagementTest> AssetManagementTestProperty = new DependencyProperty<AssetManagementTest>("AssetManagementTest");
        public AssetManagementTest AssetManagementTest
        {
            get { return AssetManagementTestProperty.GetValue(this); }
            set { AssetManagementTestProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> AssetManagementTestTemplateProperty = new DependencyProperty<Template>("AssetManagementTestTemplate");
        public Template AssetManagementTestTemplate
        {
            get { return AssetManagementTestTemplateProperty.GetValue(this); }
            set { AssetManagementTestTemplateProperty.SetValue(this, value); }
        }

        #endregion
    }

    #region Data Templates

    public static class ViewSwitcherTestTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return ViewSwitcherTest;
            }
        }

        private static Template _viewSwitcherTest;
        public static Template ViewSwitcherTest
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTest == null || _viewSwitcherTest.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTest == null)
#endif
                {
                    _viewSwitcherTest = new Template(LayoutRootTemplates.LayoutRoot);
#if UNITY_EDITOR
                    _viewSwitcherTest.Name = "ViewSwitcherTest";
#endif
                    Delight.ViewSwitcherTest.Region1TemplateProperty.SetDefault(_viewSwitcherTest, ViewSwitcherTestRegion1);
                    Delight.ViewSwitcherTest.Group1TemplateProperty.SetDefault(_viewSwitcherTest, ViewSwitcherTestGroup1);
                    Delight.ViewSwitcherTest.Button1TemplateProperty.SetDefault(_viewSwitcherTest, ViewSwitcherTestButton1);
                    Delight.ViewSwitcherTest.Button2TemplateProperty.SetDefault(_viewSwitcherTest, ViewSwitcherTestButton2);
                    Delight.ViewSwitcherTest.Button3TemplateProperty.SetDefault(_viewSwitcherTest, ViewSwitcherTestButton3);
                    Delight.ViewSwitcherTest.ViewSwitcher1TemplateProperty.SetDefault(_viewSwitcherTest, ViewSwitcherTestViewSwitcher1);
                    Delight.ViewSwitcherTest.ModelBindingTestTemplateProperty.SetDefault(_viewSwitcherTest, ViewSwitcherTestModelBindingTest);
                    Delight.ViewSwitcherTest.ScrollExampleTemplateProperty.SetDefault(_viewSwitcherTest, ViewSwitcherTestScrollExample);
                    Delight.ViewSwitcherTest.AssetManagementTestTemplateProperty.SetDefault(_viewSwitcherTest, ViewSwitcherTestAssetManagementTest);
                }
                return _viewSwitcherTest;
            }
        }

        private static Template _viewSwitcherTestRegion1;
        public static Template ViewSwitcherTestRegion1
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestRegion1 == null || _viewSwitcherTestRegion1.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestRegion1 == null)
#endif
                {
                    _viewSwitcherTestRegion1 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _viewSwitcherTestRegion1.Name = "ViewSwitcherTestRegion1";
#endif
                }
                return _viewSwitcherTestRegion1;
            }
        }

        private static Template _viewSwitcherTestGroup1;
        public static Template ViewSwitcherTestGroup1
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestGroup1 == null || _viewSwitcherTestGroup1.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestGroup1 == null)
#endif
                {
                    _viewSwitcherTestGroup1 = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _viewSwitcherTestGroup1.Name = "ViewSwitcherTestGroup1";
#endif
                    Delight.Group.HeightProperty.SetDefault(_viewSwitcherTestGroup1, new ElementSize(50f, ElementSizeUnit.Pixels));
                    Delight.Group.SpacingProperty.SetDefault(_viewSwitcherTestGroup1, new ElementSize(10f, ElementSizeUnit.Pixels));
                    Delight.Group.OrientationProperty.SetDefault(_viewSwitcherTestGroup1, Delight.ElementOrientation.Horizontal);
                    Delight.Group.AlignmentProperty.SetDefault(_viewSwitcherTestGroup1, Delight.ElementAlignment.Top);
                }
                return _viewSwitcherTestGroup1;
            }
        }

        private static Template _viewSwitcherTestButton1;
        public static Template ViewSwitcherTestButton1
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestButton1 == null || _viewSwitcherTestButton1.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestButton1 == null)
#endif
                {
                    _viewSwitcherTestButton1 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _viewSwitcherTestButton1.Name = "ViewSwitcherTestButton1";
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_viewSwitcherTestButton1, ViewSwitcherTestButton1Label);
                }
                return _viewSwitcherTestButton1;
            }
        }

        private static Template _viewSwitcherTestButton1Label;
        public static Template ViewSwitcherTestButton1Label
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestButton1Label == null || _viewSwitcherTestButton1Label.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestButton1Label == null)
#endif
                {
                    _viewSwitcherTestButton1Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _viewSwitcherTestButton1Label.Name = "ViewSwitcherTestButton1Label";
#endif
                    Delight.Label.TextProperty.SetDefault(_viewSwitcherTestButton1Label, "ModelBindingTest");
                }
                return _viewSwitcherTestButton1Label;
            }
        }

        private static Template _viewSwitcherTestButton2;
        public static Template ViewSwitcherTestButton2
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestButton2 == null || _viewSwitcherTestButton2.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestButton2 == null)
#endif
                {
                    _viewSwitcherTestButton2 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _viewSwitcherTestButton2.Name = "ViewSwitcherTestButton2";
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_viewSwitcherTestButton2, ViewSwitcherTestButton2Label);
                }
                return _viewSwitcherTestButton2;
            }
        }

        private static Template _viewSwitcherTestButton2Label;
        public static Template ViewSwitcherTestButton2Label
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestButton2Label == null || _viewSwitcherTestButton2Label.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestButton2Label == null)
#endif
                {
                    _viewSwitcherTestButton2Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _viewSwitcherTestButton2Label.Name = "ViewSwitcherTestButton2Label";
#endif
                    Delight.Label.TextProperty.SetDefault(_viewSwitcherTestButton2Label, "ScrollExample");
                }
                return _viewSwitcherTestButton2Label;
            }
        }

        private static Template _viewSwitcherTestButton3;
        public static Template ViewSwitcherTestButton3
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestButton3 == null || _viewSwitcherTestButton3.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestButton3 == null)
#endif
                {
                    _viewSwitcherTestButton3 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _viewSwitcherTestButton3.Name = "ViewSwitcherTestButton3";
#endif
                    Delight.Button.WidthProperty.SetDefault(_viewSwitcherTestButton3, new ElementSize(300f, ElementSizeUnit.Pixels));
                    Delight.Button.LabelTemplateProperty.SetDefault(_viewSwitcherTestButton3, ViewSwitcherTestButton3Label);
                }
                return _viewSwitcherTestButton3;
            }
        }

        private static Template _viewSwitcherTestButton3Label;
        public static Template ViewSwitcherTestButton3Label
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestButton3Label == null || _viewSwitcherTestButton3Label.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestButton3Label == null)
#endif
                {
                    _viewSwitcherTestButton3Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _viewSwitcherTestButton3Label.Name = "ViewSwitcherTestButton3Label";
#endif
                    Delight.Label.TextProperty.SetDefault(_viewSwitcherTestButton3Label, "AssetManagementTest");
                }
                return _viewSwitcherTestButton3Label;
            }
        }

        private static Template _viewSwitcherTestViewSwitcher1;
        public static Template ViewSwitcherTestViewSwitcher1
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestViewSwitcher1 == null || _viewSwitcherTestViewSwitcher1.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestViewSwitcher1 == null)
#endif
                {
                    _viewSwitcherTestViewSwitcher1 = new Template(ViewSwitcherTemplates.ViewSwitcher);
#if UNITY_EDITOR
                    _viewSwitcherTestViewSwitcher1.Name = "ViewSwitcherTestViewSwitcher1";
#endif
                    Delight.ViewSwitcher.MarginProperty.SetDefault(_viewSwitcherTestViewSwitcher1, new ElementMargin(new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(50f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels)));
                    Delight.ViewSwitcher.SwitchModeProperty.SetDefault(_viewSwitcherTestViewSwitcher1, Delight.SwitchMode.Enable);
                }
                return _viewSwitcherTestViewSwitcher1;
            }
        }

        private static Template _viewSwitcherTestModelBindingTest;
        public static Template ViewSwitcherTestModelBindingTest
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestModelBindingTest == null || _viewSwitcherTestModelBindingTest.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestModelBindingTest == null)
#endif
                {
                    _viewSwitcherTestModelBindingTest = new Template(ModelBindingTestTemplates.ModelBindingTest);
#if UNITY_EDITOR
                    _viewSwitcherTestModelBindingTest.Name = "ViewSwitcherTestModelBindingTest";
#endif
                    Delight.ModelBindingTest.Group1TemplateProperty.SetDefault(_viewSwitcherTestModelBindingTest, ViewSwitcherTestModelBindingTestGroup1);
                    Delight.ModelBindingTest.Group2TemplateProperty.SetDefault(_viewSwitcherTestModelBindingTest, ViewSwitcherTestModelBindingTestGroup2);
                    Delight.ModelBindingTest.Button1TemplateProperty.SetDefault(_viewSwitcherTestModelBindingTest, ViewSwitcherTestModelBindingTestButton1);
                    Delight.ModelBindingTest.Button2TemplateProperty.SetDefault(_viewSwitcherTestModelBindingTest, ViewSwitcherTestModelBindingTestButton2);
                    Delight.ModelBindingTest.PlayerListTemplateProperty.SetDefault(_viewSwitcherTestModelBindingTest, ViewSwitcherTestModelBindingTestPlayerList);
                    Delight.ModelBindingTest.PlayerListContentTemplateProperty.SetDefault(_viewSwitcherTestModelBindingTest, ViewSwitcherTestModelBindingTestPlayerListContent);
                    Delight.ModelBindingTest.Group3TemplateProperty.SetDefault(_viewSwitcherTestModelBindingTest, ViewSwitcherTestModelBindingTestGroup3);
                    Delight.ModelBindingTest.Label1TemplateProperty.SetDefault(_viewSwitcherTestModelBindingTest, ViewSwitcherTestModelBindingTestLabel1);
                    Delight.ModelBindingTest.AchievementsListTemplateProperty.SetDefault(_viewSwitcherTestModelBindingTest, ViewSwitcherTestModelBindingTestAchievementsList);
                    Delight.ModelBindingTest.AchievementsListContentTemplateProperty.SetDefault(_viewSwitcherTestModelBindingTest, ViewSwitcherTestModelBindingTestAchievementsListContent);
                    Delight.ModelBindingTest.Label2TemplateProperty.SetDefault(_viewSwitcherTestModelBindingTest, ViewSwitcherTestModelBindingTestLabel2);
                }
                return _viewSwitcherTestModelBindingTest;
            }
        }

        private static Template _viewSwitcherTestModelBindingTestGroup1;
        public static Template ViewSwitcherTestModelBindingTestGroup1
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestModelBindingTestGroup1 == null || _viewSwitcherTestModelBindingTestGroup1.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestModelBindingTestGroup1 == null)
#endif
                {
                    _viewSwitcherTestModelBindingTestGroup1 = new Template(ModelBindingTestTemplates.ModelBindingTestGroup1);
#if UNITY_EDITOR
                    _viewSwitcherTestModelBindingTestGroup1.Name = "ViewSwitcherTestModelBindingTestGroup1";
#endif
                }
                return _viewSwitcherTestModelBindingTestGroup1;
            }
        }

        private static Template _viewSwitcherTestModelBindingTestGroup2;
        public static Template ViewSwitcherTestModelBindingTestGroup2
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestModelBindingTestGroup2 == null || _viewSwitcherTestModelBindingTestGroup2.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestModelBindingTestGroup2 == null)
#endif
                {
                    _viewSwitcherTestModelBindingTestGroup2 = new Template(ModelBindingTestTemplates.ModelBindingTestGroup2);
#if UNITY_EDITOR
                    _viewSwitcherTestModelBindingTestGroup2.Name = "ViewSwitcherTestModelBindingTestGroup2";
#endif
                }
                return _viewSwitcherTestModelBindingTestGroup2;
            }
        }

        private static Template _viewSwitcherTestModelBindingTestButton1;
        public static Template ViewSwitcherTestModelBindingTestButton1
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestModelBindingTestButton1 == null || _viewSwitcherTestModelBindingTestButton1.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestModelBindingTestButton1 == null)
#endif
                {
                    _viewSwitcherTestModelBindingTestButton1 = new Template(ModelBindingTestTemplates.ModelBindingTestButton1);
#if UNITY_EDITOR
                    _viewSwitcherTestModelBindingTestButton1.Name = "ViewSwitcherTestModelBindingTestButton1";
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_viewSwitcherTestModelBindingTestButton1, ViewSwitcherTestModelBindingTestButton1Label);
                }
                return _viewSwitcherTestModelBindingTestButton1;
            }
        }

        private static Template _viewSwitcherTestModelBindingTestButton1Label;
        public static Template ViewSwitcherTestModelBindingTestButton1Label
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestModelBindingTestButton1Label == null || _viewSwitcherTestModelBindingTestButton1Label.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestModelBindingTestButton1Label == null)
#endif
                {
                    _viewSwitcherTestModelBindingTestButton1Label = new Template(ModelBindingTestTemplates.ModelBindingTestButton1Label);
#if UNITY_EDITOR
                    _viewSwitcherTestModelBindingTestButton1Label.Name = "ViewSwitcherTestModelBindingTestButton1Label";
#endif
                }
                return _viewSwitcherTestModelBindingTestButton1Label;
            }
        }

        private static Template _viewSwitcherTestModelBindingTestButton2;
        public static Template ViewSwitcherTestModelBindingTestButton2
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestModelBindingTestButton2 == null || _viewSwitcherTestModelBindingTestButton2.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestModelBindingTestButton2 == null)
#endif
                {
                    _viewSwitcherTestModelBindingTestButton2 = new Template(ModelBindingTestTemplates.ModelBindingTestButton2);
#if UNITY_EDITOR
                    _viewSwitcherTestModelBindingTestButton2.Name = "ViewSwitcherTestModelBindingTestButton2";
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_viewSwitcherTestModelBindingTestButton2, ViewSwitcherTestModelBindingTestButton2Label);
                }
                return _viewSwitcherTestModelBindingTestButton2;
            }
        }

        private static Template _viewSwitcherTestModelBindingTestButton2Label;
        public static Template ViewSwitcherTestModelBindingTestButton2Label
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestModelBindingTestButton2Label == null || _viewSwitcherTestModelBindingTestButton2Label.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestModelBindingTestButton2Label == null)
#endif
                {
                    _viewSwitcherTestModelBindingTestButton2Label = new Template(ModelBindingTestTemplates.ModelBindingTestButton2Label);
#if UNITY_EDITOR
                    _viewSwitcherTestModelBindingTestButton2Label.Name = "ViewSwitcherTestModelBindingTestButton2Label";
#endif
                }
                return _viewSwitcherTestModelBindingTestButton2Label;
            }
        }

        private static Template _viewSwitcherTestModelBindingTestPlayerList;
        public static Template ViewSwitcherTestModelBindingTestPlayerList
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestModelBindingTestPlayerList == null || _viewSwitcherTestModelBindingTestPlayerList.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestModelBindingTestPlayerList == null)
#endif
                {
                    _viewSwitcherTestModelBindingTestPlayerList = new Template(ModelBindingTestTemplates.ModelBindingTestPlayerList);
#if UNITY_EDITOR
                    _viewSwitcherTestModelBindingTestPlayerList.Name = "ViewSwitcherTestModelBindingTestPlayerList";
#endif
                    Delight.List.ScrollableRegionTemplateProperty.SetDefault(_viewSwitcherTestModelBindingTestPlayerList, ViewSwitcherTestModelBindingTestPlayerListScrollableRegion);
                }
                return _viewSwitcherTestModelBindingTestPlayerList;
            }
        }

        private static Template _viewSwitcherTestModelBindingTestPlayerListScrollableRegion;
        public static Template ViewSwitcherTestModelBindingTestPlayerListScrollableRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestModelBindingTestPlayerListScrollableRegion == null || _viewSwitcherTestModelBindingTestPlayerListScrollableRegion.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestModelBindingTestPlayerListScrollableRegion == null)
#endif
                {
                    _viewSwitcherTestModelBindingTestPlayerListScrollableRegion = new Template(ModelBindingTestTemplates.ModelBindingTestPlayerListScrollableRegion);
#if UNITY_EDITOR
                    _viewSwitcherTestModelBindingTestPlayerListScrollableRegion.Name = "ViewSwitcherTestModelBindingTestPlayerListScrollableRegion";
#endif
                    Delight.ScrollableRegion.ContentRegionTemplateProperty.SetDefault(_viewSwitcherTestModelBindingTestPlayerListScrollableRegion, ViewSwitcherTestModelBindingTestPlayerListScrollableRegionContentRegion);
                    Delight.ScrollableRegion.HorizontalScrollbarTemplateProperty.SetDefault(_viewSwitcherTestModelBindingTestPlayerListScrollableRegion, ViewSwitcherTestModelBindingTestPlayerListScrollableRegionHorizontalScrollbar);
                    Delight.ScrollableRegion.VerticalScrollbarTemplateProperty.SetDefault(_viewSwitcherTestModelBindingTestPlayerListScrollableRegion, ViewSwitcherTestModelBindingTestPlayerListScrollableRegionVerticalScrollbar);
                }
                return _viewSwitcherTestModelBindingTestPlayerListScrollableRegion;
            }
        }

        private static Template _viewSwitcherTestModelBindingTestPlayerListScrollableRegionContentRegion;
        public static Template ViewSwitcherTestModelBindingTestPlayerListScrollableRegionContentRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestModelBindingTestPlayerListScrollableRegionContentRegion == null || _viewSwitcherTestModelBindingTestPlayerListScrollableRegionContentRegion.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestModelBindingTestPlayerListScrollableRegionContentRegion == null)
#endif
                {
                    _viewSwitcherTestModelBindingTestPlayerListScrollableRegionContentRegion = new Template(ModelBindingTestTemplates.ModelBindingTestPlayerListScrollableRegionContentRegion);
#if UNITY_EDITOR
                    _viewSwitcherTestModelBindingTestPlayerListScrollableRegionContentRegion.Name = "ViewSwitcherTestModelBindingTestPlayerListScrollableRegionContentRegion";
#endif
                }
                return _viewSwitcherTestModelBindingTestPlayerListScrollableRegionContentRegion;
            }
        }

        private static Template _viewSwitcherTestModelBindingTestPlayerListScrollableRegionHorizontalScrollbar;
        public static Template ViewSwitcherTestModelBindingTestPlayerListScrollableRegionHorizontalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestModelBindingTestPlayerListScrollableRegionHorizontalScrollbar == null || _viewSwitcherTestModelBindingTestPlayerListScrollableRegionHorizontalScrollbar.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestModelBindingTestPlayerListScrollableRegionHorizontalScrollbar == null)
#endif
                {
                    _viewSwitcherTestModelBindingTestPlayerListScrollableRegionHorizontalScrollbar = new Template(ModelBindingTestTemplates.ModelBindingTestPlayerListScrollableRegionHorizontalScrollbar);
#if UNITY_EDITOR
                    _viewSwitcherTestModelBindingTestPlayerListScrollableRegionHorizontalScrollbar.Name = "ViewSwitcherTestModelBindingTestPlayerListScrollableRegionHorizontalScrollbar";
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_viewSwitcherTestModelBindingTestPlayerListScrollableRegionHorizontalScrollbar, ViewSwitcherTestModelBindingTestPlayerListScrollableRegionHorizontalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_viewSwitcherTestModelBindingTestPlayerListScrollableRegionHorizontalScrollbar, ViewSwitcherTestModelBindingTestPlayerListScrollableRegionHorizontalScrollbarHandle);
                }
                return _viewSwitcherTestModelBindingTestPlayerListScrollableRegionHorizontalScrollbar;
            }
        }

        private static Template _viewSwitcherTestModelBindingTestPlayerListScrollableRegionHorizontalScrollbarBar;
        public static Template ViewSwitcherTestModelBindingTestPlayerListScrollableRegionHorizontalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestModelBindingTestPlayerListScrollableRegionHorizontalScrollbarBar == null || _viewSwitcherTestModelBindingTestPlayerListScrollableRegionHorizontalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestModelBindingTestPlayerListScrollableRegionHorizontalScrollbarBar == null)
#endif
                {
                    _viewSwitcherTestModelBindingTestPlayerListScrollableRegionHorizontalScrollbarBar = new Template(ModelBindingTestTemplates.ModelBindingTestPlayerListScrollableRegionHorizontalScrollbarBar);
#if UNITY_EDITOR
                    _viewSwitcherTestModelBindingTestPlayerListScrollableRegionHorizontalScrollbarBar.Name = "ViewSwitcherTestModelBindingTestPlayerListScrollableRegionHorizontalScrollbarBar";
#endif
                }
                return _viewSwitcherTestModelBindingTestPlayerListScrollableRegionHorizontalScrollbarBar;
            }
        }

        private static Template _viewSwitcherTestModelBindingTestPlayerListScrollableRegionHorizontalScrollbarHandle;
        public static Template ViewSwitcherTestModelBindingTestPlayerListScrollableRegionHorizontalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestModelBindingTestPlayerListScrollableRegionHorizontalScrollbarHandle == null || _viewSwitcherTestModelBindingTestPlayerListScrollableRegionHorizontalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestModelBindingTestPlayerListScrollableRegionHorizontalScrollbarHandle == null)
#endif
                {
                    _viewSwitcherTestModelBindingTestPlayerListScrollableRegionHorizontalScrollbarHandle = new Template(ModelBindingTestTemplates.ModelBindingTestPlayerListScrollableRegionHorizontalScrollbarHandle);
#if UNITY_EDITOR
                    _viewSwitcherTestModelBindingTestPlayerListScrollableRegionHorizontalScrollbarHandle.Name = "ViewSwitcherTestModelBindingTestPlayerListScrollableRegionHorizontalScrollbarHandle";
#endif
                }
                return _viewSwitcherTestModelBindingTestPlayerListScrollableRegionHorizontalScrollbarHandle;
            }
        }

        private static Template _viewSwitcherTestModelBindingTestPlayerListScrollableRegionVerticalScrollbar;
        public static Template ViewSwitcherTestModelBindingTestPlayerListScrollableRegionVerticalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestModelBindingTestPlayerListScrollableRegionVerticalScrollbar == null || _viewSwitcherTestModelBindingTestPlayerListScrollableRegionVerticalScrollbar.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestModelBindingTestPlayerListScrollableRegionVerticalScrollbar == null)
#endif
                {
                    _viewSwitcherTestModelBindingTestPlayerListScrollableRegionVerticalScrollbar = new Template(ModelBindingTestTemplates.ModelBindingTestPlayerListScrollableRegionVerticalScrollbar);
#if UNITY_EDITOR
                    _viewSwitcherTestModelBindingTestPlayerListScrollableRegionVerticalScrollbar.Name = "ViewSwitcherTestModelBindingTestPlayerListScrollableRegionVerticalScrollbar";
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_viewSwitcherTestModelBindingTestPlayerListScrollableRegionVerticalScrollbar, ViewSwitcherTestModelBindingTestPlayerListScrollableRegionVerticalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_viewSwitcherTestModelBindingTestPlayerListScrollableRegionVerticalScrollbar, ViewSwitcherTestModelBindingTestPlayerListScrollableRegionVerticalScrollbarHandle);
                }
                return _viewSwitcherTestModelBindingTestPlayerListScrollableRegionVerticalScrollbar;
            }
        }

        private static Template _viewSwitcherTestModelBindingTestPlayerListScrollableRegionVerticalScrollbarBar;
        public static Template ViewSwitcherTestModelBindingTestPlayerListScrollableRegionVerticalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestModelBindingTestPlayerListScrollableRegionVerticalScrollbarBar == null || _viewSwitcherTestModelBindingTestPlayerListScrollableRegionVerticalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestModelBindingTestPlayerListScrollableRegionVerticalScrollbarBar == null)
#endif
                {
                    _viewSwitcherTestModelBindingTestPlayerListScrollableRegionVerticalScrollbarBar = new Template(ModelBindingTestTemplates.ModelBindingTestPlayerListScrollableRegionVerticalScrollbarBar);
#if UNITY_EDITOR
                    _viewSwitcherTestModelBindingTestPlayerListScrollableRegionVerticalScrollbarBar.Name = "ViewSwitcherTestModelBindingTestPlayerListScrollableRegionVerticalScrollbarBar";
#endif
                }
                return _viewSwitcherTestModelBindingTestPlayerListScrollableRegionVerticalScrollbarBar;
            }
        }

        private static Template _viewSwitcherTestModelBindingTestPlayerListScrollableRegionVerticalScrollbarHandle;
        public static Template ViewSwitcherTestModelBindingTestPlayerListScrollableRegionVerticalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestModelBindingTestPlayerListScrollableRegionVerticalScrollbarHandle == null || _viewSwitcherTestModelBindingTestPlayerListScrollableRegionVerticalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestModelBindingTestPlayerListScrollableRegionVerticalScrollbarHandle == null)
#endif
                {
                    _viewSwitcherTestModelBindingTestPlayerListScrollableRegionVerticalScrollbarHandle = new Template(ModelBindingTestTemplates.ModelBindingTestPlayerListScrollableRegionVerticalScrollbarHandle);
#if UNITY_EDITOR
                    _viewSwitcherTestModelBindingTestPlayerListScrollableRegionVerticalScrollbarHandle.Name = "ViewSwitcherTestModelBindingTestPlayerListScrollableRegionVerticalScrollbarHandle";
#endif
                }
                return _viewSwitcherTestModelBindingTestPlayerListScrollableRegionVerticalScrollbarHandle;
            }
        }

        private static Template _viewSwitcherTestModelBindingTestPlayerListContent;
        public static Template ViewSwitcherTestModelBindingTestPlayerListContent
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestModelBindingTestPlayerListContent == null || _viewSwitcherTestModelBindingTestPlayerListContent.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestModelBindingTestPlayerListContent == null)
#endif
                {
                    _viewSwitcherTestModelBindingTestPlayerListContent = new Template(ModelBindingTestTemplates.ModelBindingTestPlayerListContent);
#if UNITY_EDITOR
                    _viewSwitcherTestModelBindingTestPlayerListContent.Name = "ViewSwitcherTestModelBindingTestPlayerListContent";
#endif
                }
                return _viewSwitcherTestModelBindingTestPlayerListContent;
            }
        }

        private static Template _viewSwitcherTestModelBindingTestGroup3;
        public static Template ViewSwitcherTestModelBindingTestGroup3
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestModelBindingTestGroup3 == null || _viewSwitcherTestModelBindingTestGroup3.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestModelBindingTestGroup3 == null)
#endif
                {
                    _viewSwitcherTestModelBindingTestGroup3 = new Template(ModelBindingTestTemplates.ModelBindingTestGroup3);
#if UNITY_EDITOR
                    _viewSwitcherTestModelBindingTestGroup3.Name = "ViewSwitcherTestModelBindingTestGroup3";
#endif
                }
                return _viewSwitcherTestModelBindingTestGroup3;
            }
        }

        private static Template _viewSwitcherTestModelBindingTestLabel1;
        public static Template ViewSwitcherTestModelBindingTestLabel1
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestModelBindingTestLabel1 == null || _viewSwitcherTestModelBindingTestLabel1.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestModelBindingTestLabel1 == null)
#endif
                {
                    _viewSwitcherTestModelBindingTestLabel1 = new Template(ModelBindingTestTemplates.ModelBindingTestLabel1);
#if UNITY_EDITOR
                    _viewSwitcherTestModelBindingTestLabel1.Name = "ViewSwitcherTestModelBindingTestLabel1";
#endif
                }
                return _viewSwitcherTestModelBindingTestLabel1;
            }
        }

        private static Template _viewSwitcherTestModelBindingTestAchievementsList;
        public static Template ViewSwitcherTestModelBindingTestAchievementsList
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestModelBindingTestAchievementsList == null || _viewSwitcherTestModelBindingTestAchievementsList.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestModelBindingTestAchievementsList == null)
#endif
                {
                    _viewSwitcherTestModelBindingTestAchievementsList = new Template(ModelBindingTestTemplates.ModelBindingTestAchievementsList);
#if UNITY_EDITOR
                    _viewSwitcherTestModelBindingTestAchievementsList.Name = "ViewSwitcherTestModelBindingTestAchievementsList";
#endif
                    Delight.List.ScrollableRegionTemplateProperty.SetDefault(_viewSwitcherTestModelBindingTestAchievementsList, ViewSwitcherTestModelBindingTestAchievementsListScrollableRegion);
                }
                return _viewSwitcherTestModelBindingTestAchievementsList;
            }
        }

        private static Template _viewSwitcherTestModelBindingTestAchievementsListScrollableRegion;
        public static Template ViewSwitcherTestModelBindingTestAchievementsListScrollableRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestModelBindingTestAchievementsListScrollableRegion == null || _viewSwitcherTestModelBindingTestAchievementsListScrollableRegion.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestModelBindingTestAchievementsListScrollableRegion == null)
#endif
                {
                    _viewSwitcherTestModelBindingTestAchievementsListScrollableRegion = new Template(ModelBindingTestTemplates.ModelBindingTestAchievementsListScrollableRegion);
#if UNITY_EDITOR
                    _viewSwitcherTestModelBindingTestAchievementsListScrollableRegion.Name = "ViewSwitcherTestModelBindingTestAchievementsListScrollableRegion";
#endif
                    Delight.ScrollableRegion.ContentRegionTemplateProperty.SetDefault(_viewSwitcherTestModelBindingTestAchievementsListScrollableRegion, ViewSwitcherTestModelBindingTestAchievementsListScrollableRegionContentRegion);
                    Delight.ScrollableRegion.HorizontalScrollbarTemplateProperty.SetDefault(_viewSwitcherTestModelBindingTestAchievementsListScrollableRegion, ViewSwitcherTestModelBindingTestAchievementsListScrollableRegionHorizontalScrollbar);
                    Delight.ScrollableRegion.VerticalScrollbarTemplateProperty.SetDefault(_viewSwitcherTestModelBindingTestAchievementsListScrollableRegion, ViewSwitcherTestModelBindingTestAchievementsListScrollableRegionVerticalScrollbar);
                }
                return _viewSwitcherTestModelBindingTestAchievementsListScrollableRegion;
            }
        }

        private static Template _viewSwitcherTestModelBindingTestAchievementsListScrollableRegionContentRegion;
        public static Template ViewSwitcherTestModelBindingTestAchievementsListScrollableRegionContentRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestModelBindingTestAchievementsListScrollableRegionContentRegion == null || _viewSwitcherTestModelBindingTestAchievementsListScrollableRegionContentRegion.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestModelBindingTestAchievementsListScrollableRegionContentRegion == null)
#endif
                {
                    _viewSwitcherTestModelBindingTestAchievementsListScrollableRegionContentRegion = new Template(ModelBindingTestTemplates.ModelBindingTestAchievementsListScrollableRegionContentRegion);
#if UNITY_EDITOR
                    _viewSwitcherTestModelBindingTestAchievementsListScrollableRegionContentRegion.Name = "ViewSwitcherTestModelBindingTestAchievementsListScrollableRegionContentRegion";
#endif
                }
                return _viewSwitcherTestModelBindingTestAchievementsListScrollableRegionContentRegion;
            }
        }

        private static Template _viewSwitcherTestModelBindingTestAchievementsListScrollableRegionHorizontalScrollbar;
        public static Template ViewSwitcherTestModelBindingTestAchievementsListScrollableRegionHorizontalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestModelBindingTestAchievementsListScrollableRegionHorizontalScrollbar == null || _viewSwitcherTestModelBindingTestAchievementsListScrollableRegionHorizontalScrollbar.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestModelBindingTestAchievementsListScrollableRegionHorizontalScrollbar == null)
#endif
                {
                    _viewSwitcherTestModelBindingTestAchievementsListScrollableRegionHorizontalScrollbar = new Template(ModelBindingTestTemplates.ModelBindingTestAchievementsListScrollableRegionHorizontalScrollbar);
#if UNITY_EDITOR
                    _viewSwitcherTestModelBindingTestAchievementsListScrollableRegionHorizontalScrollbar.Name = "ViewSwitcherTestModelBindingTestAchievementsListScrollableRegionHorizontalScrollbar";
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_viewSwitcherTestModelBindingTestAchievementsListScrollableRegionHorizontalScrollbar, ViewSwitcherTestModelBindingTestAchievementsListScrollableRegionHorizontalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_viewSwitcherTestModelBindingTestAchievementsListScrollableRegionHorizontalScrollbar, ViewSwitcherTestModelBindingTestAchievementsListScrollableRegionHorizontalScrollbarHandle);
                }
                return _viewSwitcherTestModelBindingTestAchievementsListScrollableRegionHorizontalScrollbar;
            }
        }

        private static Template _viewSwitcherTestModelBindingTestAchievementsListScrollableRegionHorizontalScrollbarBar;
        public static Template ViewSwitcherTestModelBindingTestAchievementsListScrollableRegionHorizontalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestModelBindingTestAchievementsListScrollableRegionHorizontalScrollbarBar == null || _viewSwitcherTestModelBindingTestAchievementsListScrollableRegionHorizontalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestModelBindingTestAchievementsListScrollableRegionHorizontalScrollbarBar == null)
#endif
                {
                    _viewSwitcherTestModelBindingTestAchievementsListScrollableRegionHorizontalScrollbarBar = new Template(ModelBindingTestTemplates.ModelBindingTestAchievementsListScrollableRegionHorizontalScrollbarBar);
#if UNITY_EDITOR
                    _viewSwitcherTestModelBindingTestAchievementsListScrollableRegionHorizontalScrollbarBar.Name = "ViewSwitcherTestModelBindingTestAchievementsListScrollableRegionHorizontalScrollbarBar";
#endif
                }
                return _viewSwitcherTestModelBindingTestAchievementsListScrollableRegionHorizontalScrollbarBar;
            }
        }

        private static Template _viewSwitcherTestModelBindingTestAchievementsListScrollableRegionHorizontalScrollbarHandle;
        public static Template ViewSwitcherTestModelBindingTestAchievementsListScrollableRegionHorizontalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestModelBindingTestAchievementsListScrollableRegionHorizontalScrollbarHandle == null || _viewSwitcherTestModelBindingTestAchievementsListScrollableRegionHorizontalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestModelBindingTestAchievementsListScrollableRegionHorizontalScrollbarHandle == null)
#endif
                {
                    _viewSwitcherTestModelBindingTestAchievementsListScrollableRegionHorizontalScrollbarHandle = new Template(ModelBindingTestTemplates.ModelBindingTestAchievementsListScrollableRegionHorizontalScrollbarHandle);
#if UNITY_EDITOR
                    _viewSwitcherTestModelBindingTestAchievementsListScrollableRegionHorizontalScrollbarHandle.Name = "ViewSwitcherTestModelBindingTestAchievementsListScrollableRegionHorizontalScrollbarHandle";
#endif
                }
                return _viewSwitcherTestModelBindingTestAchievementsListScrollableRegionHorizontalScrollbarHandle;
            }
        }

        private static Template _viewSwitcherTestModelBindingTestAchievementsListScrollableRegionVerticalScrollbar;
        public static Template ViewSwitcherTestModelBindingTestAchievementsListScrollableRegionVerticalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestModelBindingTestAchievementsListScrollableRegionVerticalScrollbar == null || _viewSwitcherTestModelBindingTestAchievementsListScrollableRegionVerticalScrollbar.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestModelBindingTestAchievementsListScrollableRegionVerticalScrollbar == null)
#endif
                {
                    _viewSwitcherTestModelBindingTestAchievementsListScrollableRegionVerticalScrollbar = new Template(ModelBindingTestTemplates.ModelBindingTestAchievementsListScrollableRegionVerticalScrollbar);
#if UNITY_EDITOR
                    _viewSwitcherTestModelBindingTestAchievementsListScrollableRegionVerticalScrollbar.Name = "ViewSwitcherTestModelBindingTestAchievementsListScrollableRegionVerticalScrollbar";
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_viewSwitcherTestModelBindingTestAchievementsListScrollableRegionVerticalScrollbar, ViewSwitcherTestModelBindingTestAchievementsListScrollableRegionVerticalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_viewSwitcherTestModelBindingTestAchievementsListScrollableRegionVerticalScrollbar, ViewSwitcherTestModelBindingTestAchievementsListScrollableRegionVerticalScrollbarHandle);
                }
                return _viewSwitcherTestModelBindingTestAchievementsListScrollableRegionVerticalScrollbar;
            }
        }

        private static Template _viewSwitcherTestModelBindingTestAchievementsListScrollableRegionVerticalScrollbarBar;
        public static Template ViewSwitcherTestModelBindingTestAchievementsListScrollableRegionVerticalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestModelBindingTestAchievementsListScrollableRegionVerticalScrollbarBar == null || _viewSwitcherTestModelBindingTestAchievementsListScrollableRegionVerticalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestModelBindingTestAchievementsListScrollableRegionVerticalScrollbarBar == null)
#endif
                {
                    _viewSwitcherTestModelBindingTestAchievementsListScrollableRegionVerticalScrollbarBar = new Template(ModelBindingTestTemplates.ModelBindingTestAchievementsListScrollableRegionVerticalScrollbarBar);
#if UNITY_EDITOR
                    _viewSwitcherTestModelBindingTestAchievementsListScrollableRegionVerticalScrollbarBar.Name = "ViewSwitcherTestModelBindingTestAchievementsListScrollableRegionVerticalScrollbarBar";
#endif
                }
                return _viewSwitcherTestModelBindingTestAchievementsListScrollableRegionVerticalScrollbarBar;
            }
        }

        private static Template _viewSwitcherTestModelBindingTestAchievementsListScrollableRegionVerticalScrollbarHandle;
        public static Template ViewSwitcherTestModelBindingTestAchievementsListScrollableRegionVerticalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestModelBindingTestAchievementsListScrollableRegionVerticalScrollbarHandle == null || _viewSwitcherTestModelBindingTestAchievementsListScrollableRegionVerticalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestModelBindingTestAchievementsListScrollableRegionVerticalScrollbarHandle == null)
#endif
                {
                    _viewSwitcherTestModelBindingTestAchievementsListScrollableRegionVerticalScrollbarHandle = new Template(ModelBindingTestTemplates.ModelBindingTestAchievementsListScrollableRegionVerticalScrollbarHandle);
#if UNITY_EDITOR
                    _viewSwitcherTestModelBindingTestAchievementsListScrollableRegionVerticalScrollbarHandle.Name = "ViewSwitcherTestModelBindingTestAchievementsListScrollableRegionVerticalScrollbarHandle";
#endif
                }
                return _viewSwitcherTestModelBindingTestAchievementsListScrollableRegionVerticalScrollbarHandle;
            }
        }

        private static Template _viewSwitcherTestModelBindingTestAchievementsListContent;
        public static Template ViewSwitcherTestModelBindingTestAchievementsListContent
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestModelBindingTestAchievementsListContent == null || _viewSwitcherTestModelBindingTestAchievementsListContent.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestModelBindingTestAchievementsListContent == null)
#endif
                {
                    _viewSwitcherTestModelBindingTestAchievementsListContent = new Template(ModelBindingTestTemplates.ModelBindingTestAchievementsListContent);
#if UNITY_EDITOR
                    _viewSwitcherTestModelBindingTestAchievementsListContent.Name = "ViewSwitcherTestModelBindingTestAchievementsListContent";
#endif
                }
                return _viewSwitcherTestModelBindingTestAchievementsListContent;
            }
        }

        private static Template _viewSwitcherTestModelBindingTestLabel2;
        public static Template ViewSwitcherTestModelBindingTestLabel2
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestModelBindingTestLabel2 == null || _viewSwitcherTestModelBindingTestLabel2.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestModelBindingTestLabel2 == null)
#endif
                {
                    _viewSwitcherTestModelBindingTestLabel2 = new Template(ModelBindingTestTemplates.ModelBindingTestLabel2);
#if UNITY_EDITOR
                    _viewSwitcherTestModelBindingTestLabel2.Name = "ViewSwitcherTestModelBindingTestLabel2";
#endif
                }
                return _viewSwitcherTestModelBindingTestLabel2;
            }
        }

        private static Template _viewSwitcherTestScrollExample;
        public static Template ViewSwitcherTestScrollExample
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExample == null || _viewSwitcherTestScrollExample.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExample == null)
#endif
                {
                    _viewSwitcherTestScrollExample = new Template(ScrollExampleTemplates.ScrollExample);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExample.Name = "ViewSwitcherTestScrollExample";
#endif
                    Delight.ScrollExample.Grid1TemplateProperty.SetDefault(_viewSwitcherTestScrollExample, ViewSwitcherTestScrollExampleGrid1);
                    Delight.ScrollExample.ScrollableRegion1TemplateProperty.SetDefault(_viewSwitcherTestScrollExample, ViewSwitcherTestScrollExampleScrollableRegion1);
                    Delight.ScrollExample.Region1TemplateProperty.SetDefault(_viewSwitcherTestScrollExample, ViewSwitcherTestScrollExampleRegion1);
                    Delight.ScrollExample.Region2TemplateProperty.SetDefault(_viewSwitcherTestScrollExample, ViewSwitcherTestScrollExampleRegion2);
                    Delight.ScrollExample.Region3TemplateProperty.SetDefault(_viewSwitcherTestScrollExample, ViewSwitcherTestScrollExampleRegion3);
                    Delight.ScrollExample.Region4TemplateProperty.SetDefault(_viewSwitcherTestScrollExample, ViewSwitcherTestScrollExampleRegion4);
                    Delight.ScrollExample.Region5TemplateProperty.SetDefault(_viewSwitcherTestScrollExample, ViewSwitcherTestScrollExampleRegion5);
                    Delight.ScrollExample.ScrollableRegion2TemplateProperty.SetDefault(_viewSwitcherTestScrollExample, ViewSwitcherTestScrollExampleScrollableRegion2);
                    Delight.ScrollExample.Region6TemplateProperty.SetDefault(_viewSwitcherTestScrollExample, ViewSwitcherTestScrollExampleRegion6);
                    Delight.ScrollExample.Region7TemplateProperty.SetDefault(_viewSwitcherTestScrollExample, ViewSwitcherTestScrollExampleRegion7);
                    Delight.ScrollExample.Region8TemplateProperty.SetDefault(_viewSwitcherTestScrollExample, ViewSwitcherTestScrollExampleRegion8);
                    Delight.ScrollExample.Region9TemplateProperty.SetDefault(_viewSwitcherTestScrollExample, ViewSwitcherTestScrollExampleRegion9);
                    Delight.ScrollExample.Region10TemplateProperty.SetDefault(_viewSwitcherTestScrollExample, ViewSwitcherTestScrollExampleRegion10);
                    Delight.ScrollExample.ScrollableRegion3TemplateProperty.SetDefault(_viewSwitcherTestScrollExample, ViewSwitcherTestScrollExampleScrollableRegion3);
                    Delight.ScrollExample.Region11TemplateProperty.SetDefault(_viewSwitcherTestScrollExample, ViewSwitcherTestScrollExampleRegion11);
                    Delight.ScrollExample.Region12TemplateProperty.SetDefault(_viewSwitcherTestScrollExample, ViewSwitcherTestScrollExampleRegion12);
                    Delight.ScrollExample.Region13TemplateProperty.SetDefault(_viewSwitcherTestScrollExample, ViewSwitcherTestScrollExampleRegion13);
                    Delight.ScrollExample.Region14TemplateProperty.SetDefault(_viewSwitcherTestScrollExample, ViewSwitcherTestScrollExampleRegion14);
                    Delight.ScrollExample.Region15TemplateProperty.SetDefault(_viewSwitcherTestScrollExample, ViewSwitcherTestScrollExampleRegion15);
                    Delight.ScrollExample.ScrollableRegion4TemplateProperty.SetDefault(_viewSwitcherTestScrollExample, ViewSwitcherTestScrollExampleScrollableRegion4);
                    Delight.ScrollExample.Region16TemplateProperty.SetDefault(_viewSwitcherTestScrollExample, ViewSwitcherTestScrollExampleRegion16);
                    Delight.ScrollExample.Region17TemplateProperty.SetDefault(_viewSwitcherTestScrollExample, ViewSwitcherTestScrollExampleRegion17);
                    Delight.ScrollExample.Region18TemplateProperty.SetDefault(_viewSwitcherTestScrollExample, ViewSwitcherTestScrollExampleRegion18);
                    Delight.ScrollExample.Region19TemplateProperty.SetDefault(_viewSwitcherTestScrollExample, ViewSwitcherTestScrollExampleRegion19);
                    Delight.ScrollExample.Region20TemplateProperty.SetDefault(_viewSwitcherTestScrollExample, ViewSwitcherTestScrollExampleRegion20);
                    Delight.ScrollExample.ScrollableRegion5TemplateProperty.SetDefault(_viewSwitcherTestScrollExample, ViewSwitcherTestScrollExampleScrollableRegion5);
                    Delight.ScrollExample.Region21TemplateProperty.SetDefault(_viewSwitcherTestScrollExample, ViewSwitcherTestScrollExampleRegion21);
                    Delight.ScrollExample.Region22TemplateProperty.SetDefault(_viewSwitcherTestScrollExample, ViewSwitcherTestScrollExampleRegion22);
                    Delight.ScrollExample.Region23TemplateProperty.SetDefault(_viewSwitcherTestScrollExample, ViewSwitcherTestScrollExampleRegion23);
                    Delight.ScrollExample.Region24TemplateProperty.SetDefault(_viewSwitcherTestScrollExample, ViewSwitcherTestScrollExampleRegion24);
                    Delight.ScrollExample.Region25TemplateProperty.SetDefault(_viewSwitcherTestScrollExample, ViewSwitcherTestScrollExampleRegion25);
                    Delight.ScrollExample.ScrollableRegion6TemplateProperty.SetDefault(_viewSwitcherTestScrollExample, ViewSwitcherTestScrollExampleScrollableRegion6);
                    Delight.ScrollExample.Region26TemplateProperty.SetDefault(_viewSwitcherTestScrollExample, ViewSwitcherTestScrollExampleRegion26);
                    Delight.ScrollExample.Region27TemplateProperty.SetDefault(_viewSwitcherTestScrollExample, ViewSwitcherTestScrollExampleRegion27);
                    Delight.ScrollExample.Region28TemplateProperty.SetDefault(_viewSwitcherTestScrollExample, ViewSwitcherTestScrollExampleRegion28);
                    Delight.ScrollExample.Region29TemplateProperty.SetDefault(_viewSwitcherTestScrollExample, ViewSwitcherTestScrollExampleRegion29);
                    Delight.ScrollExample.Region30TemplateProperty.SetDefault(_viewSwitcherTestScrollExample, ViewSwitcherTestScrollExampleRegion30);
                    Delight.ScrollExample.ScrollableRegion7TemplateProperty.SetDefault(_viewSwitcherTestScrollExample, ViewSwitcherTestScrollExampleScrollableRegion7);
                    Delight.ScrollExample.Region31TemplateProperty.SetDefault(_viewSwitcherTestScrollExample, ViewSwitcherTestScrollExampleRegion31);
                    Delight.ScrollExample.Region32TemplateProperty.SetDefault(_viewSwitcherTestScrollExample, ViewSwitcherTestScrollExampleRegion32);
                    Delight.ScrollExample.Region33TemplateProperty.SetDefault(_viewSwitcherTestScrollExample, ViewSwitcherTestScrollExampleRegion33);
                    Delight.ScrollExample.Region34TemplateProperty.SetDefault(_viewSwitcherTestScrollExample, ViewSwitcherTestScrollExampleRegion34);
                    Delight.ScrollExample.Region35TemplateProperty.SetDefault(_viewSwitcherTestScrollExample, ViewSwitcherTestScrollExampleRegion35);
                    Delight.ScrollExample.ScrollableRegion8TemplateProperty.SetDefault(_viewSwitcherTestScrollExample, ViewSwitcherTestScrollExampleScrollableRegion8);
                    Delight.ScrollExample.Region36TemplateProperty.SetDefault(_viewSwitcherTestScrollExample, ViewSwitcherTestScrollExampleRegion36);
                    Delight.ScrollExample.Region37TemplateProperty.SetDefault(_viewSwitcherTestScrollExample, ViewSwitcherTestScrollExampleRegion37);
                    Delight.ScrollExample.Region38TemplateProperty.SetDefault(_viewSwitcherTestScrollExample, ViewSwitcherTestScrollExampleRegion38);
                    Delight.ScrollExample.Region39TemplateProperty.SetDefault(_viewSwitcherTestScrollExample, ViewSwitcherTestScrollExampleRegion39);
                    Delight.ScrollExample.Region40TemplateProperty.SetDefault(_viewSwitcherTestScrollExample, ViewSwitcherTestScrollExampleRegion40);
                    Delight.ScrollExample.ScrollableRegion9TemplateProperty.SetDefault(_viewSwitcherTestScrollExample, ViewSwitcherTestScrollExampleScrollableRegion9);
                    Delight.ScrollExample.Region41TemplateProperty.SetDefault(_viewSwitcherTestScrollExample, ViewSwitcherTestScrollExampleRegion41);
                    Delight.ScrollExample.Region42TemplateProperty.SetDefault(_viewSwitcherTestScrollExample, ViewSwitcherTestScrollExampleRegion42);
                    Delight.ScrollExample.Region43TemplateProperty.SetDefault(_viewSwitcherTestScrollExample, ViewSwitcherTestScrollExampleRegion43);
                    Delight.ScrollExample.Region44TemplateProperty.SetDefault(_viewSwitcherTestScrollExample, ViewSwitcherTestScrollExampleRegion44);
                    Delight.ScrollExample.Region45TemplateProperty.SetDefault(_viewSwitcherTestScrollExample, ViewSwitcherTestScrollExampleRegion45);
                }
                return _viewSwitcherTestScrollExample;
            }
        }

        private static Template _viewSwitcherTestScrollExampleGrid1;
        public static Template ViewSwitcherTestScrollExampleGrid1
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleGrid1 == null || _viewSwitcherTestScrollExampleGrid1.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleGrid1 == null)
#endif
                {
                    _viewSwitcherTestScrollExampleGrid1 = new Template(ScrollExampleTemplates.ScrollExampleGrid1);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleGrid1.Name = "ViewSwitcherTestScrollExampleGrid1";
#endif
                }
                return _viewSwitcherTestScrollExampleGrid1;
            }
        }

        private static Template _viewSwitcherTestScrollExampleScrollableRegion1;
        public static Template ViewSwitcherTestScrollExampleScrollableRegion1
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleScrollableRegion1 == null || _viewSwitcherTestScrollExampleScrollableRegion1.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleScrollableRegion1 == null)
#endif
                {
                    _viewSwitcherTestScrollExampleScrollableRegion1 = new Template(ScrollExampleTemplates.ScrollExampleScrollableRegion1);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleScrollableRegion1.Name = "ViewSwitcherTestScrollExampleScrollableRegion1";
#endif
                    Delight.ScrollableRegion.ContentRegionTemplateProperty.SetDefault(_viewSwitcherTestScrollExampleScrollableRegion1, ViewSwitcherTestScrollExampleScrollableRegion1ContentRegion);
                    Delight.ScrollableRegion.HorizontalScrollbarTemplateProperty.SetDefault(_viewSwitcherTestScrollExampleScrollableRegion1, ViewSwitcherTestScrollExampleScrollableRegion1HorizontalScrollbar);
                    Delight.ScrollableRegion.VerticalScrollbarTemplateProperty.SetDefault(_viewSwitcherTestScrollExampleScrollableRegion1, ViewSwitcherTestScrollExampleScrollableRegion1VerticalScrollbar);
                }
                return _viewSwitcherTestScrollExampleScrollableRegion1;
            }
        }

        private static Template _viewSwitcherTestScrollExampleScrollableRegion1ContentRegion;
        public static Template ViewSwitcherTestScrollExampleScrollableRegion1ContentRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleScrollableRegion1ContentRegion == null || _viewSwitcherTestScrollExampleScrollableRegion1ContentRegion.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleScrollableRegion1ContentRegion == null)
#endif
                {
                    _viewSwitcherTestScrollExampleScrollableRegion1ContentRegion = new Template(ScrollExampleTemplates.ScrollExampleScrollableRegion1ContentRegion);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleScrollableRegion1ContentRegion.Name = "ViewSwitcherTestScrollExampleScrollableRegion1ContentRegion";
#endif
                }
                return _viewSwitcherTestScrollExampleScrollableRegion1ContentRegion;
            }
        }

        private static Template _viewSwitcherTestScrollExampleScrollableRegion1HorizontalScrollbar;
        public static Template ViewSwitcherTestScrollExampleScrollableRegion1HorizontalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleScrollableRegion1HorizontalScrollbar == null || _viewSwitcherTestScrollExampleScrollableRegion1HorizontalScrollbar.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleScrollableRegion1HorizontalScrollbar == null)
#endif
                {
                    _viewSwitcherTestScrollExampleScrollableRegion1HorizontalScrollbar = new Template(ScrollExampleTemplates.ScrollExampleScrollableRegion1HorizontalScrollbar);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleScrollableRegion1HorizontalScrollbar.Name = "ViewSwitcherTestScrollExampleScrollableRegion1HorizontalScrollbar";
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_viewSwitcherTestScrollExampleScrollableRegion1HorizontalScrollbar, ViewSwitcherTestScrollExampleScrollableRegion1HorizontalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_viewSwitcherTestScrollExampleScrollableRegion1HorizontalScrollbar, ViewSwitcherTestScrollExampleScrollableRegion1HorizontalScrollbarHandle);
                }
                return _viewSwitcherTestScrollExampleScrollableRegion1HorizontalScrollbar;
            }
        }

        private static Template _viewSwitcherTestScrollExampleScrollableRegion1HorizontalScrollbarBar;
        public static Template ViewSwitcherTestScrollExampleScrollableRegion1HorizontalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleScrollableRegion1HorizontalScrollbarBar == null || _viewSwitcherTestScrollExampleScrollableRegion1HorizontalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleScrollableRegion1HorizontalScrollbarBar == null)
#endif
                {
                    _viewSwitcherTestScrollExampleScrollableRegion1HorizontalScrollbarBar = new Template(ScrollExampleTemplates.ScrollExampleScrollableRegion1HorizontalScrollbarBar);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleScrollableRegion1HorizontalScrollbarBar.Name = "ViewSwitcherTestScrollExampleScrollableRegion1HorizontalScrollbarBar";
#endif
                }
                return _viewSwitcherTestScrollExampleScrollableRegion1HorizontalScrollbarBar;
            }
        }

        private static Template _viewSwitcherTestScrollExampleScrollableRegion1HorizontalScrollbarHandle;
        public static Template ViewSwitcherTestScrollExampleScrollableRegion1HorizontalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleScrollableRegion1HorizontalScrollbarHandle == null || _viewSwitcherTestScrollExampleScrollableRegion1HorizontalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleScrollableRegion1HorizontalScrollbarHandle == null)
#endif
                {
                    _viewSwitcherTestScrollExampleScrollableRegion1HorizontalScrollbarHandle = new Template(ScrollExampleTemplates.ScrollExampleScrollableRegion1HorizontalScrollbarHandle);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleScrollableRegion1HorizontalScrollbarHandle.Name = "ViewSwitcherTestScrollExampleScrollableRegion1HorizontalScrollbarHandle";
#endif
                }
                return _viewSwitcherTestScrollExampleScrollableRegion1HorizontalScrollbarHandle;
            }
        }

        private static Template _viewSwitcherTestScrollExampleScrollableRegion1VerticalScrollbar;
        public static Template ViewSwitcherTestScrollExampleScrollableRegion1VerticalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleScrollableRegion1VerticalScrollbar == null || _viewSwitcherTestScrollExampleScrollableRegion1VerticalScrollbar.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleScrollableRegion1VerticalScrollbar == null)
#endif
                {
                    _viewSwitcherTestScrollExampleScrollableRegion1VerticalScrollbar = new Template(ScrollExampleTemplates.ScrollExampleScrollableRegion1VerticalScrollbar);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleScrollableRegion1VerticalScrollbar.Name = "ViewSwitcherTestScrollExampleScrollableRegion1VerticalScrollbar";
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_viewSwitcherTestScrollExampleScrollableRegion1VerticalScrollbar, ViewSwitcherTestScrollExampleScrollableRegion1VerticalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_viewSwitcherTestScrollExampleScrollableRegion1VerticalScrollbar, ViewSwitcherTestScrollExampleScrollableRegion1VerticalScrollbarHandle);
                }
                return _viewSwitcherTestScrollExampleScrollableRegion1VerticalScrollbar;
            }
        }

        private static Template _viewSwitcherTestScrollExampleScrollableRegion1VerticalScrollbarBar;
        public static Template ViewSwitcherTestScrollExampleScrollableRegion1VerticalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleScrollableRegion1VerticalScrollbarBar == null || _viewSwitcherTestScrollExampleScrollableRegion1VerticalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleScrollableRegion1VerticalScrollbarBar == null)
#endif
                {
                    _viewSwitcherTestScrollExampleScrollableRegion1VerticalScrollbarBar = new Template(ScrollExampleTemplates.ScrollExampleScrollableRegion1VerticalScrollbarBar);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleScrollableRegion1VerticalScrollbarBar.Name = "ViewSwitcherTestScrollExampleScrollableRegion1VerticalScrollbarBar";
#endif
                }
                return _viewSwitcherTestScrollExampleScrollableRegion1VerticalScrollbarBar;
            }
        }

        private static Template _viewSwitcherTestScrollExampleScrollableRegion1VerticalScrollbarHandle;
        public static Template ViewSwitcherTestScrollExampleScrollableRegion1VerticalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleScrollableRegion1VerticalScrollbarHandle == null || _viewSwitcherTestScrollExampleScrollableRegion1VerticalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleScrollableRegion1VerticalScrollbarHandle == null)
#endif
                {
                    _viewSwitcherTestScrollExampleScrollableRegion1VerticalScrollbarHandle = new Template(ScrollExampleTemplates.ScrollExampleScrollableRegion1VerticalScrollbarHandle);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleScrollableRegion1VerticalScrollbarHandle.Name = "ViewSwitcherTestScrollExampleScrollableRegion1VerticalScrollbarHandle";
#endif
                }
                return _viewSwitcherTestScrollExampleScrollableRegion1VerticalScrollbarHandle;
            }
        }

        private static Template _viewSwitcherTestScrollExampleRegion1;
        public static Template ViewSwitcherTestScrollExampleRegion1
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleRegion1 == null || _viewSwitcherTestScrollExampleRegion1.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleRegion1 == null)
#endif
                {
                    _viewSwitcherTestScrollExampleRegion1 = new Template(ScrollExampleTemplates.ScrollExampleRegion1);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleRegion1.Name = "ViewSwitcherTestScrollExampleRegion1";
#endif
                }
                return _viewSwitcherTestScrollExampleRegion1;
            }
        }

        private static Template _viewSwitcherTestScrollExampleRegion2;
        public static Template ViewSwitcherTestScrollExampleRegion2
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleRegion2 == null || _viewSwitcherTestScrollExampleRegion2.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleRegion2 == null)
#endif
                {
                    _viewSwitcherTestScrollExampleRegion2 = new Template(ScrollExampleTemplates.ScrollExampleRegion2);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleRegion2.Name = "ViewSwitcherTestScrollExampleRegion2";
#endif
                }
                return _viewSwitcherTestScrollExampleRegion2;
            }
        }

        private static Template _viewSwitcherTestScrollExampleRegion3;
        public static Template ViewSwitcherTestScrollExampleRegion3
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleRegion3 == null || _viewSwitcherTestScrollExampleRegion3.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleRegion3 == null)
#endif
                {
                    _viewSwitcherTestScrollExampleRegion3 = new Template(ScrollExampleTemplates.ScrollExampleRegion3);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleRegion3.Name = "ViewSwitcherTestScrollExampleRegion3";
#endif
                }
                return _viewSwitcherTestScrollExampleRegion3;
            }
        }

        private static Template _viewSwitcherTestScrollExampleRegion4;
        public static Template ViewSwitcherTestScrollExampleRegion4
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleRegion4 == null || _viewSwitcherTestScrollExampleRegion4.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleRegion4 == null)
#endif
                {
                    _viewSwitcherTestScrollExampleRegion4 = new Template(ScrollExampleTemplates.ScrollExampleRegion4);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleRegion4.Name = "ViewSwitcherTestScrollExampleRegion4";
#endif
                }
                return _viewSwitcherTestScrollExampleRegion4;
            }
        }

        private static Template _viewSwitcherTestScrollExampleRegion5;
        public static Template ViewSwitcherTestScrollExampleRegion5
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleRegion5 == null || _viewSwitcherTestScrollExampleRegion5.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleRegion5 == null)
#endif
                {
                    _viewSwitcherTestScrollExampleRegion5 = new Template(ScrollExampleTemplates.ScrollExampleRegion5);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleRegion5.Name = "ViewSwitcherTestScrollExampleRegion5";
#endif
                }
                return _viewSwitcherTestScrollExampleRegion5;
            }
        }

        private static Template _viewSwitcherTestScrollExampleScrollableRegion2;
        public static Template ViewSwitcherTestScrollExampleScrollableRegion2
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleScrollableRegion2 == null || _viewSwitcherTestScrollExampleScrollableRegion2.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleScrollableRegion2 == null)
#endif
                {
                    _viewSwitcherTestScrollExampleScrollableRegion2 = new Template(ScrollExampleTemplates.ScrollExampleScrollableRegion2);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleScrollableRegion2.Name = "ViewSwitcherTestScrollExampleScrollableRegion2";
#endif
                    Delight.ScrollableRegion.ContentRegionTemplateProperty.SetDefault(_viewSwitcherTestScrollExampleScrollableRegion2, ViewSwitcherTestScrollExampleScrollableRegion2ContentRegion);
                    Delight.ScrollableRegion.HorizontalScrollbarTemplateProperty.SetDefault(_viewSwitcherTestScrollExampleScrollableRegion2, ViewSwitcherTestScrollExampleScrollableRegion2HorizontalScrollbar);
                    Delight.ScrollableRegion.VerticalScrollbarTemplateProperty.SetDefault(_viewSwitcherTestScrollExampleScrollableRegion2, ViewSwitcherTestScrollExampleScrollableRegion2VerticalScrollbar);
                }
                return _viewSwitcherTestScrollExampleScrollableRegion2;
            }
        }

        private static Template _viewSwitcherTestScrollExampleScrollableRegion2ContentRegion;
        public static Template ViewSwitcherTestScrollExampleScrollableRegion2ContentRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleScrollableRegion2ContentRegion == null || _viewSwitcherTestScrollExampleScrollableRegion2ContentRegion.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleScrollableRegion2ContentRegion == null)
#endif
                {
                    _viewSwitcherTestScrollExampleScrollableRegion2ContentRegion = new Template(ScrollExampleTemplates.ScrollExampleScrollableRegion2ContentRegion);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleScrollableRegion2ContentRegion.Name = "ViewSwitcherTestScrollExampleScrollableRegion2ContentRegion";
#endif
                }
                return _viewSwitcherTestScrollExampleScrollableRegion2ContentRegion;
            }
        }

        private static Template _viewSwitcherTestScrollExampleScrollableRegion2HorizontalScrollbar;
        public static Template ViewSwitcherTestScrollExampleScrollableRegion2HorizontalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleScrollableRegion2HorizontalScrollbar == null || _viewSwitcherTestScrollExampleScrollableRegion2HorizontalScrollbar.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleScrollableRegion2HorizontalScrollbar == null)
#endif
                {
                    _viewSwitcherTestScrollExampleScrollableRegion2HorizontalScrollbar = new Template(ScrollExampleTemplates.ScrollExampleScrollableRegion2HorizontalScrollbar);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleScrollableRegion2HorizontalScrollbar.Name = "ViewSwitcherTestScrollExampleScrollableRegion2HorizontalScrollbar";
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_viewSwitcherTestScrollExampleScrollableRegion2HorizontalScrollbar, ViewSwitcherTestScrollExampleScrollableRegion2HorizontalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_viewSwitcherTestScrollExampleScrollableRegion2HorizontalScrollbar, ViewSwitcherTestScrollExampleScrollableRegion2HorizontalScrollbarHandle);
                }
                return _viewSwitcherTestScrollExampleScrollableRegion2HorizontalScrollbar;
            }
        }

        private static Template _viewSwitcherTestScrollExampleScrollableRegion2HorizontalScrollbarBar;
        public static Template ViewSwitcherTestScrollExampleScrollableRegion2HorizontalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleScrollableRegion2HorizontalScrollbarBar == null || _viewSwitcherTestScrollExampleScrollableRegion2HorizontalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleScrollableRegion2HorizontalScrollbarBar == null)
#endif
                {
                    _viewSwitcherTestScrollExampleScrollableRegion2HorizontalScrollbarBar = new Template(ScrollExampleTemplates.ScrollExampleScrollableRegion2HorizontalScrollbarBar);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleScrollableRegion2HorizontalScrollbarBar.Name = "ViewSwitcherTestScrollExampleScrollableRegion2HorizontalScrollbarBar";
#endif
                }
                return _viewSwitcherTestScrollExampleScrollableRegion2HorizontalScrollbarBar;
            }
        }

        private static Template _viewSwitcherTestScrollExampleScrollableRegion2HorizontalScrollbarHandle;
        public static Template ViewSwitcherTestScrollExampleScrollableRegion2HorizontalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleScrollableRegion2HorizontalScrollbarHandle == null || _viewSwitcherTestScrollExampleScrollableRegion2HorizontalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleScrollableRegion2HorizontalScrollbarHandle == null)
#endif
                {
                    _viewSwitcherTestScrollExampleScrollableRegion2HorizontalScrollbarHandle = new Template(ScrollExampleTemplates.ScrollExampleScrollableRegion2HorizontalScrollbarHandle);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleScrollableRegion2HorizontalScrollbarHandle.Name = "ViewSwitcherTestScrollExampleScrollableRegion2HorizontalScrollbarHandle";
#endif
                }
                return _viewSwitcherTestScrollExampleScrollableRegion2HorizontalScrollbarHandle;
            }
        }

        private static Template _viewSwitcherTestScrollExampleScrollableRegion2VerticalScrollbar;
        public static Template ViewSwitcherTestScrollExampleScrollableRegion2VerticalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleScrollableRegion2VerticalScrollbar == null || _viewSwitcherTestScrollExampleScrollableRegion2VerticalScrollbar.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleScrollableRegion2VerticalScrollbar == null)
#endif
                {
                    _viewSwitcherTestScrollExampleScrollableRegion2VerticalScrollbar = new Template(ScrollExampleTemplates.ScrollExampleScrollableRegion2VerticalScrollbar);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleScrollableRegion2VerticalScrollbar.Name = "ViewSwitcherTestScrollExampleScrollableRegion2VerticalScrollbar";
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_viewSwitcherTestScrollExampleScrollableRegion2VerticalScrollbar, ViewSwitcherTestScrollExampleScrollableRegion2VerticalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_viewSwitcherTestScrollExampleScrollableRegion2VerticalScrollbar, ViewSwitcherTestScrollExampleScrollableRegion2VerticalScrollbarHandle);
                }
                return _viewSwitcherTestScrollExampleScrollableRegion2VerticalScrollbar;
            }
        }

        private static Template _viewSwitcherTestScrollExampleScrollableRegion2VerticalScrollbarBar;
        public static Template ViewSwitcherTestScrollExampleScrollableRegion2VerticalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleScrollableRegion2VerticalScrollbarBar == null || _viewSwitcherTestScrollExampleScrollableRegion2VerticalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleScrollableRegion2VerticalScrollbarBar == null)
#endif
                {
                    _viewSwitcherTestScrollExampleScrollableRegion2VerticalScrollbarBar = new Template(ScrollExampleTemplates.ScrollExampleScrollableRegion2VerticalScrollbarBar);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleScrollableRegion2VerticalScrollbarBar.Name = "ViewSwitcherTestScrollExampleScrollableRegion2VerticalScrollbarBar";
#endif
                }
                return _viewSwitcherTestScrollExampleScrollableRegion2VerticalScrollbarBar;
            }
        }

        private static Template _viewSwitcherTestScrollExampleScrollableRegion2VerticalScrollbarHandle;
        public static Template ViewSwitcherTestScrollExampleScrollableRegion2VerticalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleScrollableRegion2VerticalScrollbarHandle == null || _viewSwitcherTestScrollExampleScrollableRegion2VerticalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleScrollableRegion2VerticalScrollbarHandle == null)
#endif
                {
                    _viewSwitcherTestScrollExampleScrollableRegion2VerticalScrollbarHandle = new Template(ScrollExampleTemplates.ScrollExampleScrollableRegion2VerticalScrollbarHandle);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleScrollableRegion2VerticalScrollbarHandle.Name = "ViewSwitcherTestScrollExampleScrollableRegion2VerticalScrollbarHandle";
#endif
                }
                return _viewSwitcherTestScrollExampleScrollableRegion2VerticalScrollbarHandle;
            }
        }

        private static Template _viewSwitcherTestScrollExampleRegion6;
        public static Template ViewSwitcherTestScrollExampleRegion6
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleRegion6 == null || _viewSwitcherTestScrollExampleRegion6.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleRegion6 == null)
#endif
                {
                    _viewSwitcherTestScrollExampleRegion6 = new Template(ScrollExampleTemplates.ScrollExampleRegion6);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleRegion6.Name = "ViewSwitcherTestScrollExampleRegion6";
#endif
                }
                return _viewSwitcherTestScrollExampleRegion6;
            }
        }

        private static Template _viewSwitcherTestScrollExampleRegion7;
        public static Template ViewSwitcherTestScrollExampleRegion7
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleRegion7 == null || _viewSwitcherTestScrollExampleRegion7.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleRegion7 == null)
#endif
                {
                    _viewSwitcherTestScrollExampleRegion7 = new Template(ScrollExampleTemplates.ScrollExampleRegion7);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleRegion7.Name = "ViewSwitcherTestScrollExampleRegion7";
#endif
                }
                return _viewSwitcherTestScrollExampleRegion7;
            }
        }

        private static Template _viewSwitcherTestScrollExampleRegion8;
        public static Template ViewSwitcherTestScrollExampleRegion8
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleRegion8 == null || _viewSwitcherTestScrollExampleRegion8.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleRegion8 == null)
#endif
                {
                    _viewSwitcherTestScrollExampleRegion8 = new Template(ScrollExampleTemplates.ScrollExampleRegion8);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleRegion8.Name = "ViewSwitcherTestScrollExampleRegion8";
#endif
                }
                return _viewSwitcherTestScrollExampleRegion8;
            }
        }

        private static Template _viewSwitcherTestScrollExampleRegion9;
        public static Template ViewSwitcherTestScrollExampleRegion9
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleRegion9 == null || _viewSwitcherTestScrollExampleRegion9.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleRegion9 == null)
#endif
                {
                    _viewSwitcherTestScrollExampleRegion9 = new Template(ScrollExampleTemplates.ScrollExampleRegion9);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleRegion9.Name = "ViewSwitcherTestScrollExampleRegion9";
#endif
                }
                return _viewSwitcherTestScrollExampleRegion9;
            }
        }

        private static Template _viewSwitcherTestScrollExampleRegion10;
        public static Template ViewSwitcherTestScrollExampleRegion10
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleRegion10 == null || _viewSwitcherTestScrollExampleRegion10.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleRegion10 == null)
#endif
                {
                    _viewSwitcherTestScrollExampleRegion10 = new Template(ScrollExampleTemplates.ScrollExampleRegion10);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleRegion10.Name = "ViewSwitcherTestScrollExampleRegion10";
#endif
                }
                return _viewSwitcherTestScrollExampleRegion10;
            }
        }

        private static Template _viewSwitcherTestScrollExampleScrollableRegion3;
        public static Template ViewSwitcherTestScrollExampleScrollableRegion3
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleScrollableRegion3 == null || _viewSwitcherTestScrollExampleScrollableRegion3.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleScrollableRegion3 == null)
#endif
                {
                    _viewSwitcherTestScrollExampleScrollableRegion3 = new Template(ScrollExampleTemplates.ScrollExampleScrollableRegion3);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleScrollableRegion3.Name = "ViewSwitcherTestScrollExampleScrollableRegion3";
#endif
                    Delight.ScrollableRegion.ContentRegionTemplateProperty.SetDefault(_viewSwitcherTestScrollExampleScrollableRegion3, ViewSwitcherTestScrollExampleScrollableRegion3ContentRegion);
                    Delight.ScrollableRegion.HorizontalScrollbarTemplateProperty.SetDefault(_viewSwitcherTestScrollExampleScrollableRegion3, ViewSwitcherTestScrollExampleScrollableRegion3HorizontalScrollbar);
                    Delight.ScrollableRegion.VerticalScrollbarTemplateProperty.SetDefault(_viewSwitcherTestScrollExampleScrollableRegion3, ViewSwitcherTestScrollExampleScrollableRegion3VerticalScrollbar);
                }
                return _viewSwitcherTestScrollExampleScrollableRegion3;
            }
        }

        private static Template _viewSwitcherTestScrollExampleScrollableRegion3ContentRegion;
        public static Template ViewSwitcherTestScrollExampleScrollableRegion3ContentRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleScrollableRegion3ContentRegion == null || _viewSwitcherTestScrollExampleScrollableRegion3ContentRegion.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleScrollableRegion3ContentRegion == null)
#endif
                {
                    _viewSwitcherTestScrollExampleScrollableRegion3ContentRegion = new Template(ScrollExampleTemplates.ScrollExampleScrollableRegion3ContentRegion);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleScrollableRegion3ContentRegion.Name = "ViewSwitcherTestScrollExampleScrollableRegion3ContentRegion";
#endif
                }
                return _viewSwitcherTestScrollExampleScrollableRegion3ContentRegion;
            }
        }

        private static Template _viewSwitcherTestScrollExampleScrollableRegion3HorizontalScrollbar;
        public static Template ViewSwitcherTestScrollExampleScrollableRegion3HorizontalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleScrollableRegion3HorizontalScrollbar == null || _viewSwitcherTestScrollExampleScrollableRegion3HorizontalScrollbar.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleScrollableRegion3HorizontalScrollbar == null)
#endif
                {
                    _viewSwitcherTestScrollExampleScrollableRegion3HorizontalScrollbar = new Template(ScrollExampleTemplates.ScrollExampleScrollableRegion3HorizontalScrollbar);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleScrollableRegion3HorizontalScrollbar.Name = "ViewSwitcherTestScrollExampleScrollableRegion3HorizontalScrollbar";
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_viewSwitcherTestScrollExampleScrollableRegion3HorizontalScrollbar, ViewSwitcherTestScrollExampleScrollableRegion3HorizontalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_viewSwitcherTestScrollExampleScrollableRegion3HorizontalScrollbar, ViewSwitcherTestScrollExampleScrollableRegion3HorizontalScrollbarHandle);
                }
                return _viewSwitcherTestScrollExampleScrollableRegion3HorizontalScrollbar;
            }
        }

        private static Template _viewSwitcherTestScrollExampleScrollableRegion3HorizontalScrollbarBar;
        public static Template ViewSwitcherTestScrollExampleScrollableRegion3HorizontalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleScrollableRegion3HorizontalScrollbarBar == null || _viewSwitcherTestScrollExampleScrollableRegion3HorizontalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleScrollableRegion3HorizontalScrollbarBar == null)
#endif
                {
                    _viewSwitcherTestScrollExampleScrollableRegion3HorizontalScrollbarBar = new Template(ScrollExampleTemplates.ScrollExampleScrollableRegion3HorizontalScrollbarBar);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleScrollableRegion3HorizontalScrollbarBar.Name = "ViewSwitcherTestScrollExampleScrollableRegion3HorizontalScrollbarBar";
#endif
                }
                return _viewSwitcherTestScrollExampleScrollableRegion3HorizontalScrollbarBar;
            }
        }

        private static Template _viewSwitcherTestScrollExampleScrollableRegion3HorizontalScrollbarHandle;
        public static Template ViewSwitcherTestScrollExampleScrollableRegion3HorizontalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleScrollableRegion3HorizontalScrollbarHandle == null || _viewSwitcherTestScrollExampleScrollableRegion3HorizontalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleScrollableRegion3HorizontalScrollbarHandle == null)
#endif
                {
                    _viewSwitcherTestScrollExampleScrollableRegion3HorizontalScrollbarHandle = new Template(ScrollExampleTemplates.ScrollExampleScrollableRegion3HorizontalScrollbarHandle);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleScrollableRegion3HorizontalScrollbarHandle.Name = "ViewSwitcherTestScrollExampleScrollableRegion3HorizontalScrollbarHandle";
#endif
                }
                return _viewSwitcherTestScrollExampleScrollableRegion3HorizontalScrollbarHandle;
            }
        }

        private static Template _viewSwitcherTestScrollExampleScrollableRegion3VerticalScrollbar;
        public static Template ViewSwitcherTestScrollExampleScrollableRegion3VerticalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleScrollableRegion3VerticalScrollbar == null || _viewSwitcherTestScrollExampleScrollableRegion3VerticalScrollbar.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleScrollableRegion3VerticalScrollbar == null)
#endif
                {
                    _viewSwitcherTestScrollExampleScrollableRegion3VerticalScrollbar = new Template(ScrollExampleTemplates.ScrollExampleScrollableRegion3VerticalScrollbar);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleScrollableRegion3VerticalScrollbar.Name = "ViewSwitcherTestScrollExampleScrollableRegion3VerticalScrollbar";
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_viewSwitcherTestScrollExampleScrollableRegion3VerticalScrollbar, ViewSwitcherTestScrollExampleScrollableRegion3VerticalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_viewSwitcherTestScrollExampleScrollableRegion3VerticalScrollbar, ViewSwitcherTestScrollExampleScrollableRegion3VerticalScrollbarHandle);
                }
                return _viewSwitcherTestScrollExampleScrollableRegion3VerticalScrollbar;
            }
        }

        private static Template _viewSwitcherTestScrollExampleScrollableRegion3VerticalScrollbarBar;
        public static Template ViewSwitcherTestScrollExampleScrollableRegion3VerticalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleScrollableRegion3VerticalScrollbarBar == null || _viewSwitcherTestScrollExampleScrollableRegion3VerticalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleScrollableRegion3VerticalScrollbarBar == null)
#endif
                {
                    _viewSwitcherTestScrollExampleScrollableRegion3VerticalScrollbarBar = new Template(ScrollExampleTemplates.ScrollExampleScrollableRegion3VerticalScrollbarBar);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleScrollableRegion3VerticalScrollbarBar.Name = "ViewSwitcherTestScrollExampleScrollableRegion3VerticalScrollbarBar";
#endif
                }
                return _viewSwitcherTestScrollExampleScrollableRegion3VerticalScrollbarBar;
            }
        }

        private static Template _viewSwitcherTestScrollExampleScrollableRegion3VerticalScrollbarHandle;
        public static Template ViewSwitcherTestScrollExampleScrollableRegion3VerticalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleScrollableRegion3VerticalScrollbarHandle == null || _viewSwitcherTestScrollExampleScrollableRegion3VerticalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleScrollableRegion3VerticalScrollbarHandle == null)
#endif
                {
                    _viewSwitcherTestScrollExampleScrollableRegion3VerticalScrollbarHandle = new Template(ScrollExampleTemplates.ScrollExampleScrollableRegion3VerticalScrollbarHandle);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleScrollableRegion3VerticalScrollbarHandle.Name = "ViewSwitcherTestScrollExampleScrollableRegion3VerticalScrollbarHandle";
#endif
                }
                return _viewSwitcherTestScrollExampleScrollableRegion3VerticalScrollbarHandle;
            }
        }

        private static Template _viewSwitcherTestScrollExampleRegion11;
        public static Template ViewSwitcherTestScrollExampleRegion11
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleRegion11 == null || _viewSwitcherTestScrollExampleRegion11.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleRegion11 == null)
#endif
                {
                    _viewSwitcherTestScrollExampleRegion11 = new Template(ScrollExampleTemplates.ScrollExampleRegion11);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleRegion11.Name = "ViewSwitcherTestScrollExampleRegion11";
#endif
                }
                return _viewSwitcherTestScrollExampleRegion11;
            }
        }

        private static Template _viewSwitcherTestScrollExampleRegion12;
        public static Template ViewSwitcherTestScrollExampleRegion12
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleRegion12 == null || _viewSwitcherTestScrollExampleRegion12.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleRegion12 == null)
#endif
                {
                    _viewSwitcherTestScrollExampleRegion12 = new Template(ScrollExampleTemplates.ScrollExampleRegion12);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleRegion12.Name = "ViewSwitcherTestScrollExampleRegion12";
#endif
                }
                return _viewSwitcherTestScrollExampleRegion12;
            }
        }

        private static Template _viewSwitcherTestScrollExampleRegion13;
        public static Template ViewSwitcherTestScrollExampleRegion13
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleRegion13 == null || _viewSwitcherTestScrollExampleRegion13.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleRegion13 == null)
#endif
                {
                    _viewSwitcherTestScrollExampleRegion13 = new Template(ScrollExampleTemplates.ScrollExampleRegion13);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleRegion13.Name = "ViewSwitcherTestScrollExampleRegion13";
#endif
                }
                return _viewSwitcherTestScrollExampleRegion13;
            }
        }

        private static Template _viewSwitcherTestScrollExampleRegion14;
        public static Template ViewSwitcherTestScrollExampleRegion14
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleRegion14 == null || _viewSwitcherTestScrollExampleRegion14.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleRegion14 == null)
#endif
                {
                    _viewSwitcherTestScrollExampleRegion14 = new Template(ScrollExampleTemplates.ScrollExampleRegion14);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleRegion14.Name = "ViewSwitcherTestScrollExampleRegion14";
#endif
                }
                return _viewSwitcherTestScrollExampleRegion14;
            }
        }

        private static Template _viewSwitcherTestScrollExampleRegion15;
        public static Template ViewSwitcherTestScrollExampleRegion15
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleRegion15 == null || _viewSwitcherTestScrollExampleRegion15.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleRegion15 == null)
#endif
                {
                    _viewSwitcherTestScrollExampleRegion15 = new Template(ScrollExampleTemplates.ScrollExampleRegion15);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleRegion15.Name = "ViewSwitcherTestScrollExampleRegion15";
#endif
                }
                return _viewSwitcherTestScrollExampleRegion15;
            }
        }

        private static Template _viewSwitcherTestScrollExampleScrollableRegion4;
        public static Template ViewSwitcherTestScrollExampleScrollableRegion4
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleScrollableRegion4 == null || _viewSwitcherTestScrollExampleScrollableRegion4.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleScrollableRegion4 == null)
#endif
                {
                    _viewSwitcherTestScrollExampleScrollableRegion4 = new Template(ScrollExampleTemplates.ScrollExampleScrollableRegion4);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleScrollableRegion4.Name = "ViewSwitcherTestScrollExampleScrollableRegion4";
#endif
                    Delight.ScrollableRegion.ContentRegionTemplateProperty.SetDefault(_viewSwitcherTestScrollExampleScrollableRegion4, ViewSwitcherTestScrollExampleScrollableRegion4ContentRegion);
                    Delight.ScrollableRegion.HorizontalScrollbarTemplateProperty.SetDefault(_viewSwitcherTestScrollExampleScrollableRegion4, ViewSwitcherTestScrollExampleScrollableRegion4HorizontalScrollbar);
                    Delight.ScrollableRegion.VerticalScrollbarTemplateProperty.SetDefault(_viewSwitcherTestScrollExampleScrollableRegion4, ViewSwitcherTestScrollExampleScrollableRegion4VerticalScrollbar);
                }
                return _viewSwitcherTestScrollExampleScrollableRegion4;
            }
        }

        private static Template _viewSwitcherTestScrollExampleScrollableRegion4ContentRegion;
        public static Template ViewSwitcherTestScrollExampleScrollableRegion4ContentRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleScrollableRegion4ContentRegion == null || _viewSwitcherTestScrollExampleScrollableRegion4ContentRegion.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleScrollableRegion4ContentRegion == null)
#endif
                {
                    _viewSwitcherTestScrollExampleScrollableRegion4ContentRegion = new Template(ScrollExampleTemplates.ScrollExampleScrollableRegion4ContentRegion);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleScrollableRegion4ContentRegion.Name = "ViewSwitcherTestScrollExampleScrollableRegion4ContentRegion";
#endif
                }
                return _viewSwitcherTestScrollExampleScrollableRegion4ContentRegion;
            }
        }

        private static Template _viewSwitcherTestScrollExampleScrollableRegion4HorizontalScrollbar;
        public static Template ViewSwitcherTestScrollExampleScrollableRegion4HorizontalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleScrollableRegion4HorizontalScrollbar == null || _viewSwitcherTestScrollExampleScrollableRegion4HorizontalScrollbar.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleScrollableRegion4HorizontalScrollbar == null)
#endif
                {
                    _viewSwitcherTestScrollExampleScrollableRegion4HorizontalScrollbar = new Template(ScrollExampleTemplates.ScrollExampleScrollableRegion4HorizontalScrollbar);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleScrollableRegion4HorizontalScrollbar.Name = "ViewSwitcherTestScrollExampleScrollableRegion4HorizontalScrollbar";
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_viewSwitcherTestScrollExampleScrollableRegion4HorizontalScrollbar, ViewSwitcherTestScrollExampleScrollableRegion4HorizontalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_viewSwitcherTestScrollExampleScrollableRegion4HorizontalScrollbar, ViewSwitcherTestScrollExampleScrollableRegion4HorizontalScrollbarHandle);
                }
                return _viewSwitcherTestScrollExampleScrollableRegion4HorizontalScrollbar;
            }
        }

        private static Template _viewSwitcherTestScrollExampleScrollableRegion4HorizontalScrollbarBar;
        public static Template ViewSwitcherTestScrollExampleScrollableRegion4HorizontalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleScrollableRegion4HorizontalScrollbarBar == null || _viewSwitcherTestScrollExampleScrollableRegion4HorizontalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleScrollableRegion4HorizontalScrollbarBar == null)
#endif
                {
                    _viewSwitcherTestScrollExampleScrollableRegion4HorizontalScrollbarBar = new Template(ScrollExampleTemplates.ScrollExampleScrollableRegion4HorizontalScrollbarBar);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleScrollableRegion4HorizontalScrollbarBar.Name = "ViewSwitcherTestScrollExampleScrollableRegion4HorizontalScrollbarBar";
#endif
                }
                return _viewSwitcherTestScrollExampleScrollableRegion4HorizontalScrollbarBar;
            }
        }

        private static Template _viewSwitcherTestScrollExampleScrollableRegion4HorizontalScrollbarHandle;
        public static Template ViewSwitcherTestScrollExampleScrollableRegion4HorizontalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleScrollableRegion4HorizontalScrollbarHandle == null || _viewSwitcherTestScrollExampleScrollableRegion4HorizontalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleScrollableRegion4HorizontalScrollbarHandle == null)
#endif
                {
                    _viewSwitcherTestScrollExampleScrollableRegion4HorizontalScrollbarHandle = new Template(ScrollExampleTemplates.ScrollExampleScrollableRegion4HorizontalScrollbarHandle);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleScrollableRegion4HorizontalScrollbarHandle.Name = "ViewSwitcherTestScrollExampleScrollableRegion4HorizontalScrollbarHandle";
#endif
                }
                return _viewSwitcherTestScrollExampleScrollableRegion4HorizontalScrollbarHandle;
            }
        }

        private static Template _viewSwitcherTestScrollExampleScrollableRegion4VerticalScrollbar;
        public static Template ViewSwitcherTestScrollExampleScrollableRegion4VerticalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleScrollableRegion4VerticalScrollbar == null || _viewSwitcherTestScrollExampleScrollableRegion4VerticalScrollbar.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleScrollableRegion4VerticalScrollbar == null)
#endif
                {
                    _viewSwitcherTestScrollExampleScrollableRegion4VerticalScrollbar = new Template(ScrollExampleTemplates.ScrollExampleScrollableRegion4VerticalScrollbar);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleScrollableRegion4VerticalScrollbar.Name = "ViewSwitcherTestScrollExampleScrollableRegion4VerticalScrollbar";
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_viewSwitcherTestScrollExampleScrollableRegion4VerticalScrollbar, ViewSwitcherTestScrollExampleScrollableRegion4VerticalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_viewSwitcherTestScrollExampleScrollableRegion4VerticalScrollbar, ViewSwitcherTestScrollExampleScrollableRegion4VerticalScrollbarHandle);
                }
                return _viewSwitcherTestScrollExampleScrollableRegion4VerticalScrollbar;
            }
        }

        private static Template _viewSwitcherTestScrollExampleScrollableRegion4VerticalScrollbarBar;
        public static Template ViewSwitcherTestScrollExampleScrollableRegion4VerticalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleScrollableRegion4VerticalScrollbarBar == null || _viewSwitcherTestScrollExampleScrollableRegion4VerticalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleScrollableRegion4VerticalScrollbarBar == null)
#endif
                {
                    _viewSwitcherTestScrollExampleScrollableRegion4VerticalScrollbarBar = new Template(ScrollExampleTemplates.ScrollExampleScrollableRegion4VerticalScrollbarBar);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleScrollableRegion4VerticalScrollbarBar.Name = "ViewSwitcherTestScrollExampleScrollableRegion4VerticalScrollbarBar";
#endif
                }
                return _viewSwitcherTestScrollExampleScrollableRegion4VerticalScrollbarBar;
            }
        }

        private static Template _viewSwitcherTestScrollExampleScrollableRegion4VerticalScrollbarHandle;
        public static Template ViewSwitcherTestScrollExampleScrollableRegion4VerticalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleScrollableRegion4VerticalScrollbarHandle == null || _viewSwitcherTestScrollExampleScrollableRegion4VerticalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleScrollableRegion4VerticalScrollbarHandle == null)
#endif
                {
                    _viewSwitcherTestScrollExampleScrollableRegion4VerticalScrollbarHandle = new Template(ScrollExampleTemplates.ScrollExampleScrollableRegion4VerticalScrollbarHandle);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleScrollableRegion4VerticalScrollbarHandle.Name = "ViewSwitcherTestScrollExampleScrollableRegion4VerticalScrollbarHandle";
#endif
                }
                return _viewSwitcherTestScrollExampleScrollableRegion4VerticalScrollbarHandle;
            }
        }

        private static Template _viewSwitcherTestScrollExampleRegion16;
        public static Template ViewSwitcherTestScrollExampleRegion16
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleRegion16 == null || _viewSwitcherTestScrollExampleRegion16.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleRegion16 == null)
#endif
                {
                    _viewSwitcherTestScrollExampleRegion16 = new Template(ScrollExampleTemplates.ScrollExampleRegion16);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleRegion16.Name = "ViewSwitcherTestScrollExampleRegion16";
#endif
                }
                return _viewSwitcherTestScrollExampleRegion16;
            }
        }

        private static Template _viewSwitcherTestScrollExampleRegion17;
        public static Template ViewSwitcherTestScrollExampleRegion17
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleRegion17 == null || _viewSwitcherTestScrollExampleRegion17.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleRegion17 == null)
#endif
                {
                    _viewSwitcherTestScrollExampleRegion17 = new Template(ScrollExampleTemplates.ScrollExampleRegion17);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleRegion17.Name = "ViewSwitcherTestScrollExampleRegion17";
#endif
                }
                return _viewSwitcherTestScrollExampleRegion17;
            }
        }

        private static Template _viewSwitcherTestScrollExampleRegion18;
        public static Template ViewSwitcherTestScrollExampleRegion18
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleRegion18 == null || _viewSwitcherTestScrollExampleRegion18.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleRegion18 == null)
#endif
                {
                    _viewSwitcherTestScrollExampleRegion18 = new Template(ScrollExampleTemplates.ScrollExampleRegion18);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleRegion18.Name = "ViewSwitcherTestScrollExampleRegion18";
#endif
                }
                return _viewSwitcherTestScrollExampleRegion18;
            }
        }

        private static Template _viewSwitcherTestScrollExampleRegion19;
        public static Template ViewSwitcherTestScrollExampleRegion19
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleRegion19 == null || _viewSwitcherTestScrollExampleRegion19.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleRegion19 == null)
#endif
                {
                    _viewSwitcherTestScrollExampleRegion19 = new Template(ScrollExampleTemplates.ScrollExampleRegion19);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleRegion19.Name = "ViewSwitcherTestScrollExampleRegion19";
#endif
                }
                return _viewSwitcherTestScrollExampleRegion19;
            }
        }

        private static Template _viewSwitcherTestScrollExampleRegion20;
        public static Template ViewSwitcherTestScrollExampleRegion20
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleRegion20 == null || _viewSwitcherTestScrollExampleRegion20.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleRegion20 == null)
#endif
                {
                    _viewSwitcherTestScrollExampleRegion20 = new Template(ScrollExampleTemplates.ScrollExampleRegion20);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleRegion20.Name = "ViewSwitcherTestScrollExampleRegion20";
#endif
                }
                return _viewSwitcherTestScrollExampleRegion20;
            }
        }

        private static Template _viewSwitcherTestScrollExampleScrollableRegion5;
        public static Template ViewSwitcherTestScrollExampleScrollableRegion5
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleScrollableRegion5 == null || _viewSwitcherTestScrollExampleScrollableRegion5.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleScrollableRegion5 == null)
#endif
                {
                    _viewSwitcherTestScrollExampleScrollableRegion5 = new Template(ScrollExampleTemplates.ScrollExampleScrollableRegion5);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleScrollableRegion5.Name = "ViewSwitcherTestScrollExampleScrollableRegion5";
#endif
                    Delight.ScrollableRegion.ContentRegionTemplateProperty.SetDefault(_viewSwitcherTestScrollExampleScrollableRegion5, ViewSwitcherTestScrollExampleScrollableRegion5ContentRegion);
                    Delight.ScrollableRegion.HorizontalScrollbarTemplateProperty.SetDefault(_viewSwitcherTestScrollExampleScrollableRegion5, ViewSwitcherTestScrollExampleScrollableRegion5HorizontalScrollbar);
                    Delight.ScrollableRegion.VerticalScrollbarTemplateProperty.SetDefault(_viewSwitcherTestScrollExampleScrollableRegion5, ViewSwitcherTestScrollExampleScrollableRegion5VerticalScrollbar);
                }
                return _viewSwitcherTestScrollExampleScrollableRegion5;
            }
        }

        private static Template _viewSwitcherTestScrollExampleScrollableRegion5ContentRegion;
        public static Template ViewSwitcherTestScrollExampleScrollableRegion5ContentRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleScrollableRegion5ContentRegion == null || _viewSwitcherTestScrollExampleScrollableRegion5ContentRegion.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleScrollableRegion5ContentRegion == null)
#endif
                {
                    _viewSwitcherTestScrollExampleScrollableRegion5ContentRegion = new Template(ScrollExampleTemplates.ScrollExampleScrollableRegion5ContentRegion);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleScrollableRegion5ContentRegion.Name = "ViewSwitcherTestScrollExampleScrollableRegion5ContentRegion";
#endif
                }
                return _viewSwitcherTestScrollExampleScrollableRegion5ContentRegion;
            }
        }

        private static Template _viewSwitcherTestScrollExampleScrollableRegion5HorizontalScrollbar;
        public static Template ViewSwitcherTestScrollExampleScrollableRegion5HorizontalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleScrollableRegion5HorizontalScrollbar == null || _viewSwitcherTestScrollExampleScrollableRegion5HorizontalScrollbar.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleScrollableRegion5HorizontalScrollbar == null)
#endif
                {
                    _viewSwitcherTestScrollExampleScrollableRegion5HorizontalScrollbar = new Template(ScrollExampleTemplates.ScrollExampleScrollableRegion5HorizontalScrollbar);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleScrollableRegion5HorizontalScrollbar.Name = "ViewSwitcherTestScrollExampleScrollableRegion5HorizontalScrollbar";
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_viewSwitcherTestScrollExampleScrollableRegion5HorizontalScrollbar, ViewSwitcherTestScrollExampleScrollableRegion5HorizontalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_viewSwitcherTestScrollExampleScrollableRegion5HorizontalScrollbar, ViewSwitcherTestScrollExampleScrollableRegion5HorizontalScrollbarHandle);
                }
                return _viewSwitcherTestScrollExampleScrollableRegion5HorizontalScrollbar;
            }
        }

        private static Template _viewSwitcherTestScrollExampleScrollableRegion5HorizontalScrollbarBar;
        public static Template ViewSwitcherTestScrollExampleScrollableRegion5HorizontalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleScrollableRegion5HorizontalScrollbarBar == null || _viewSwitcherTestScrollExampleScrollableRegion5HorizontalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleScrollableRegion5HorizontalScrollbarBar == null)
#endif
                {
                    _viewSwitcherTestScrollExampleScrollableRegion5HorizontalScrollbarBar = new Template(ScrollExampleTemplates.ScrollExampleScrollableRegion5HorizontalScrollbarBar);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleScrollableRegion5HorizontalScrollbarBar.Name = "ViewSwitcherTestScrollExampleScrollableRegion5HorizontalScrollbarBar";
#endif
                }
                return _viewSwitcherTestScrollExampleScrollableRegion5HorizontalScrollbarBar;
            }
        }

        private static Template _viewSwitcherTestScrollExampleScrollableRegion5HorizontalScrollbarHandle;
        public static Template ViewSwitcherTestScrollExampleScrollableRegion5HorizontalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleScrollableRegion5HorizontalScrollbarHandle == null || _viewSwitcherTestScrollExampleScrollableRegion5HorizontalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleScrollableRegion5HorizontalScrollbarHandle == null)
#endif
                {
                    _viewSwitcherTestScrollExampleScrollableRegion5HorizontalScrollbarHandle = new Template(ScrollExampleTemplates.ScrollExampleScrollableRegion5HorizontalScrollbarHandle);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleScrollableRegion5HorizontalScrollbarHandle.Name = "ViewSwitcherTestScrollExampleScrollableRegion5HorizontalScrollbarHandle";
#endif
                }
                return _viewSwitcherTestScrollExampleScrollableRegion5HorizontalScrollbarHandle;
            }
        }

        private static Template _viewSwitcherTestScrollExampleScrollableRegion5VerticalScrollbar;
        public static Template ViewSwitcherTestScrollExampleScrollableRegion5VerticalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleScrollableRegion5VerticalScrollbar == null || _viewSwitcherTestScrollExampleScrollableRegion5VerticalScrollbar.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleScrollableRegion5VerticalScrollbar == null)
#endif
                {
                    _viewSwitcherTestScrollExampleScrollableRegion5VerticalScrollbar = new Template(ScrollExampleTemplates.ScrollExampleScrollableRegion5VerticalScrollbar);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleScrollableRegion5VerticalScrollbar.Name = "ViewSwitcherTestScrollExampleScrollableRegion5VerticalScrollbar";
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_viewSwitcherTestScrollExampleScrollableRegion5VerticalScrollbar, ViewSwitcherTestScrollExampleScrollableRegion5VerticalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_viewSwitcherTestScrollExampleScrollableRegion5VerticalScrollbar, ViewSwitcherTestScrollExampleScrollableRegion5VerticalScrollbarHandle);
                }
                return _viewSwitcherTestScrollExampleScrollableRegion5VerticalScrollbar;
            }
        }

        private static Template _viewSwitcherTestScrollExampleScrollableRegion5VerticalScrollbarBar;
        public static Template ViewSwitcherTestScrollExampleScrollableRegion5VerticalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleScrollableRegion5VerticalScrollbarBar == null || _viewSwitcherTestScrollExampleScrollableRegion5VerticalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleScrollableRegion5VerticalScrollbarBar == null)
#endif
                {
                    _viewSwitcherTestScrollExampleScrollableRegion5VerticalScrollbarBar = new Template(ScrollExampleTemplates.ScrollExampleScrollableRegion5VerticalScrollbarBar);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleScrollableRegion5VerticalScrollbarBar.Name = "ViewSwitcherTestScrollExampleScrollableRegion5VerticalScrollbarBar";
#endif
                }
                return _viewSwitcherTestScrollExampleScrollableRegion5VerticalScrollbarBar;
            }
        }

        private static Template _viewSwitcherTestScrollExampleScrollableRegion5VerticalScrollbarHandle;
        public static Template ViewSwitcherTestScrollExampleScrollableRegion5VerticalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleScrollableRegion5VerticalScrollbarHandle == null || _viewSwitcherTestScrollExampleScrollableRegion5VerticalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleScrollableRegion5VerticalScrollbarHandle == null)
#endif
                {
                    _viewSwitcherTestScrollExampleScrollableRegion5VerticalScrollbarHandle = new Template(ScrollExampleTemplates.ScrollExampleScrollableRegion5VerticalScrollbarHandle);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleScrollableRegion5VerticalScrollbarHandle.Name = "ViewSwitcherTestScrollExampleScrollableRegion5VerticalScrollbarHandle";
#endif
                }
                return _viewSwitcherTestScrollExampleScrollableRegion5VerticalScrollbarHandle;
            }
        }

        private static Template _viewSwitcherTestScrollExampleRegion21;
        public static Template ViewSwitcherTestScrollExampleRegion21
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleRegion21 == null || _viewSwitcherTestScrollExampleRegion21.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleRegion21 == null)
#endif
                {
                    _viewSwitcherTestScrollExampleRegion21 = new Template(ScrollExampleTemplates.ScrollExampleRegion21);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleRegion21.Name = "ViewSwitcherTestScrollExampleRegion21";
#endif
                }
                return _viewSwitcherTestScrollExampleRegion21;
            }
        }

        private static Template _viewSwitcherTestScrollExampleRegion22;
        public static Template ViewSwitcherTestScrollExampleRegion22
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleRegion22 == null || _viewSwitcherTestScrollExampleRegion22.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleRegion22 == null)
#endif
                {
                    _viewSwitcherTestScrollExampleRegion22 = new Template(ScrollExampleTemplates.ScrollExampleRegion22);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleRegion22.Name = "ViewSwitcherTestScrollExampleRegion22";
#endif
                }
                return _viewSwitcherTestScrollExampleRegion22;
            }
        }

        private static Template _viewSwitcherTestScrollExampleRegion23;
        public static Template ViewSwitcherTestScrollExampleRegion23
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleRegion23 == null || _viewSwitcherTestScrollExampleRegion23.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleRegion23 == null)
#endif
                {
                    _viewSwitcherTestScrollExampleRegion23 = new Template(ScrollExampleTemplates.ScrollExampleRegion23);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleRegion23.Name = "ViewSwitcherTestScrollExampleRegion23";
#endif
                }
                return _viewSwitcherTestScrollExampleRegion23;
            }
        }

        private static Template _viewSwitcherTestScrollExampleRegion24;
        public static Template ViewSwitcherTestScrollExampleRegion24
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleRegion24 == null || _viewSwitcherTestScrollExampleRegion24.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleRegion24 == null)
#endif
                {
                    _viewSwitcherTestScrollExampleRegion24 = new Template(ScrollExampleTemplates.ScrollExampleRegion24);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleRegion24.Name = "ViewSwitcherTestScrollExampleRegion24";
#endif
                }
                return _viewSwitcherTestScrollExampleRegion24;
            }
        }

        private static Template _viewSwitcherTestScrollExampleRegion25;
        public static Template ViewSwitcherTestScrollExampleRegion25
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleRegion25 == null || _viewSwitcherTestScrollExampleRegion25.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleRegion25 == null)
#endif
                {
                    _viewSwitcherTestScrollExampleRegion25 = new Template(ScrollExampleTemplates.ScrollExampleRegion25);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleRegion25.Name = "ViewSwitcherTestScrollExampleRegion25";
#endif
                }
                return _viewSwitcherTestScrollExampleRegion25;
            }
        }

        private static Template _viewSwitcherTestScrollExampleScrollableRegion6;
        public static Template ViewSwitcherTestScrollExampleScrollableRegion6
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleScrollableRegion6 == null || _viewSwitcherTestScrollExampleScrollableRegion6.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleScrollableRegion6 == null)
#endif
                {
                    _viewSwitcherTestScrollExampleScrollableRegion6 = new Template(ScrollExampleTemplates.ScrollExampleScrollableRegion6);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleScrollableRegion6.Name = "ViewSwitcherTestScrollExampleScrollableRegion6";
#endif
                    Delight.ScrollableRegion.ContentRegionTemplateProperty.SetDefault(_viewSwitcherTestScrollExampleScrollableRegion6, ViewSwitcherTestScrollExampleScrollableRegion6ContentRegion);
                    Delight.ScrollableRegion.HorizontalScrollbarTemplateProperty.SetDefault(_viewSwitcherTestScrollExampleScrollableRegion6, ViewSwitcherTestScrollExampleScrollableRegion6HorizontalScrollbar);
                    Delight.ScrollableRegion.VerticalScrollbarTemplateProperty.SetDefault(_viewSwitcherTestScrollExampleScrollableRegion6, ViewSwitcherTestScrollExampleScrollableRegion6VerticalScrollbar);
                }
                return _viewSwitcherTestScrollExampleScrollableRegion6;
            }
        }

        private static Template _viewSwitcherTestScrollExampleScrollableRegion6ContentRegion;
        public static Template ViewSwitcherTestScrollExampleScrollableRegion6ContentRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleScrollableRegion6ContentRegion == null || _viewSwitcherTestScrollExampleScrollableRegion6ContentRegion.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleScrollableRegion6ContentRegion == null)
#endif
                {
                    _viewSwitcherTestScrollExampleScrollableRegion6ContentRegion = new Template(ScrollExampleTemplates.ScrollExampleScrollableRegion6ContentRegion);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleScrollableRegion6ContentRegion.Name = "ViewSwitcherTestScrollExampleScrollableRegion6ContentRegion";
#endif
                }
                return _viewSwitcherTestScrollExampleScrollableRegion6ContentRegion;
            }
        }

        private static Template _viewSwitcherTestScrollExampleScrollableRegion6HorizontalScrollbar;
        public static Template ViewSwitcherTestScrollExampleScrollableRegion6HorizontalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleScrollableRegion6HorizontalScrollbar == null || _viewSwitcherTestScrollExampleScrollableRegion6HorizontalScrollbar.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleScrollableRegion6HorizontalScrollbar == null)
#endif
                {
                    _viewSwitcherTestScrollExampleScrollableRegion6HorizontalScrollbar = new Template(ScrollExampleTemplates.ScrollExampleScrollableRegion6HorizontalScrollbar);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleScrollableRegion6HorizontalScrollbar.Name = "ViewSwitcherTestScrollExampleScrollableRegion6HorizontalScrollbar";
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_viewSwitcherTestScrollExampleScrollableRegion6HorizontalScrollbar, ViewSwitcherTestScrollExampleScrollableRegion6HorizontalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_viewSwitcherTestScrollExampleScrollableRegion6HorizontalScrollbar, ViewSwitcherTestScrollExampleScrollableRegion6HorizontalScrollbarHandle);
                }
                return _viewSwitcherTestScrollExampleScrollableRegion6HorizontalScrollbar;
            }
        }

        private static Template _viewSwitcherTestScrollExampleScrollableRegion6HorizontalScrollbarBar;
        public static Template ViewSwitcherTestScrollExampleScrollableRegion6HorizontalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleScrollableRegion6HorizontalScrollbarBar == null || _viewSwitcherTestScrollExampleScrollableRegion6HorizontalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleScrollableRegion6HorizontalScrollbarBar == null)
#endif
                {
                    _viewSwitcherTestScrollExampleScrollableRegion6HorizontalScrollbarBar = new Template(ScrollExampleTemplates.ScrollExampleScrollableRegion6HorizontalScrollbarBar);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleScrollableRegion6HorizontalScrollbarBar.Name = "ViewSwitcherTestScrollExampleScrollableRegion6HorizontalScrollbarBar";
#endif
                }
                return _viewSwitcherTestScrollExampleScrollableRegion6HorizontalScrollbarBar;
            }
        }

        private static Template _viewSwitcherTestScrollExampleScrollableRegion6HorizontalScrollbarHandle;
        public static Template ViewSwitcherTestScrollExampleScrollableRegion6HorizontalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleScrollableRegion6HorizontalScrollbarHandle == null || _viewSwitcherTestScrollExampleScrollableRegion6HorizontalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleScrollableRegion6HorizontalScrollbarHandle == null)
#endif
                {
                    _viewSwitcherTestScrollExampleScrollableRegion6HorizontalScrollbarHandle = new Template(ScrollExampleTemplates.ScrollExampleScrollableRegion6HorizontalScrollbarHandle);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleScrollableRegion6HorizontalScrollbarHandle.Name = "ViewSwitcherTestScrollExampleScrollableRegion6HorizontalScrollbarHandle";
#endif
                }
                return _viewSwitcherTestScrollExampleScrollableRegion6HorizontalScrollbarHandle;
            }
        }

        private static Template _viewSwitcherTestScrollExampleScrollableRegion6VerticalScrollbar;
        public static Template ViewSwitcherTestScrollExampleScrollableRegion6VerticalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleScrollableRegion6VerticalScrollbar == null || _viewSwitcherTestScrollExampleScrollableRegion6VerticalScrollbar.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleScrollableRegion6VerticalScrollbar == null)
#endif
                {
                    _viewSwitcherTestScrollExampleScrollableRegion6VerticalScrollbar = new Template(ScrollExampleTemplates.ScrollExampleScrollableRegion6VerticalScrollbar);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleScrollableRegion6VerticalScrollbar.Name = "ViewSwitcherTestScrollExampleScrollableRegion6VerticalScrollbar";
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_viewSwitcherTestScrollExampleScrollableRegion6VerticalScrollbar, ViewSwitcherTestScrollExampleScrollableRegion6VerticalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_viewSwitcherTestScrollExampleScrollableRegion6VerticalScrollbar, ViewSwitcherTestScrollExampleScrollableRegion6VerticalScrollbarHandle);
                }
                return _viewSwitcherTestScrollExampleScrollableRegion6VerticalScrollbar;
            }
        }

        private static Template _viewSwitcherTestScrollExampleScrollableRegion6VerticalScrollbarBar;
        public static Template ViewSwitcherTestScrollExampleScrollableRegion6VerticalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleScrollableRegion6VerticalScrollbarBar == null || _viewSwitcherTestScrollExampleScrollableRegion6VerticalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleScrollableRegion6VerticalScrollbarBar == null)
#endif
                {
                    _viewSwitcherTestScrollExampleScrollableRegion6VerticalScrollbarBar = new Template(ScrollExampleTemplates.ScrollExampleScrollableRegion6VerticalScrollbarBar);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleScrollableRegion6VerticalScrollbarBar.Name = "ViewSwitcherTestScrollExampleScrollableRegion6VerticalScrollbarBar";
#endif
                }
                return _viewSwitcherTestScrollExampleScrollableRegion6VerticalScrollbarBar;
            }
        }

        private static Template _viewSwitcherTestScrollExampleScrollableRegion6VerticalScrollbarHandle;
        public static Template ViewSwitcherTestScrollExampleScrollableRegion6VerticalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleScrollableRegion6VerticalScrollbarHandle == null || _viewSwitcherTestScrollExampleScrollableRegion6VerticalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleScrollableRegion6VerticalScrollbarHandle == null)
#endif
                {
                    _viewSwitcherTestScrollExampleScrollableRegion6VerticalScrollbarHandle = new Template(ScrollExampleTemplates.ScrollExampleScrollableRegion6VerticalScrollbarHandle);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleScrollableRegion6VerticalScrollbarHandle.Name = "ViewSwitcherTestScrollExampleScrollableRegion6VerticalScrollbarHandle";
#endif
                }
                return _viewSwitcherTestScrollExampleScrollableRegion6VerticalScrollbarHandle;
            }
        }

        private static Template _viewSwitcherTestScrollExampleRegion26;
        public static Template ViewSwitcherTestScrollExampleRegion26
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleRegion26 == null || _viewSwitcherTestScrollExampleRegion26.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleRegion26 == null)
#endif
                {
                    _viewSwitcherTestScrollExampleRegion26 = new Template(ScrollExampleTemplates.ScrollExampleRegion26);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleRegion26.Name = "ViewSwitcherTestScrollExampleRegion26";
#endif
                }
                return _viewSwitcherTestScrollExampleRegion26;
            }
        }

        private static Template _viewSwitcherTestScrollExampleRegion27;
        public static Template ViewSwitcherTestScrollExampleRegion27
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleRegion27 == null || _viewSwitcherTestScrollExampleRegion27.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleRegion27 == null)
#endif
                {
                    _viewSwitcherTestScrollExampleRegion27 = new Template(ScrollExampleTemplates.ScrollExampleRegion27);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleRegion27.Name = "ViewSwitcherTestScrollExampleRegion27";
#endif
                }
                return _viewSwitcherTestScrollExampleRegion27;
            }
        }

        private static Template _viewSwitcherTestScrollExampleRegion28;
        public static Template ViewSwitcherTestScrollExampleRegion28
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleRegion28 == null || _viewSwitcherTestScrollExampleRegion28.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleRegion28 == null)
#endif
                {
                    _viewSwitcherTestScrollExampleRegion28 = new Template(ScrollExampleTemplates.ScrollExampleRegion28);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleRegion28.Name = "ViewSwitcherTestScrollExampleRegion28";
#endif
                }
                return _viewSwitcherTestScrollExampleRegion28;
            }
        }

        private static Template _viewSwitcherTestScrollExampleRegion29;
        public static Template ViewSwitcherTestScrollExampleRegion29
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleRegion29 == null || _viewSwitcherTestScrollExampleRegion29.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleRegion29 == null)
#endif
                {
                    _viewSwitcherTestScrollExampleRegion29 = new Template(ScrollExampleTemplates.ScrollExampleRegion29);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleRegion29.Name = "ViewSwitcherTestScrollExampleRegion29";
#endif
                }
                return _viewSwitcherTestScrollExampleRegion29;
            }
        }

        private static Template _viewSwitcherTestScrollExampleRegion30;
        public static Template ViewSwitcherTestScrollExampleRegion30
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleRegion30 == null || _viewSwitcherTestScrollExampleRegion30.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleRegion30 == null)
#endif
                {
                    _viewSwitcherTestScrollExampleRegion30 = new Template(ScrollExampleTemplates.ScrollExampleRegion30);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleRegion30.Name = "ViewSwitcherTestScrollExampleRegion30";
#endif
                }
                return _viewSwitcherTestScrollExampleRegion30;
            }
        }

        private static Template _viewSwitcherTestScrollExampleScrollableRegion7;
        public static Template ViewSwitcherTestScrollExampleScrollableRegion7
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleScrollableRegion7 == null || _viewSwitcherTestScrollExampleScrollableRegion7.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleScrollableRegion7 == null)
#endif
                {
                    _viewSwitcherTestScrollExampleScrollableRegion7 = new Template(ScrollExampleTemplates.ScrollExampleScrollableRegion7);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleScrollableRegion7.Name = "ViewSwitcherTestScrollExampleScrollableRegion7";
#endif
                    Delight.ScrollableRegion.ContentRegionTemplateProperty.SetDefault(_viewSwitcherTestScrollExampleScrollableRegion7, ViewSwitcherTestScrollExampleScrollableRegion7ContentRegion);
                    Delight.ScrollableRegion.HorizontalScrollbarTemplateProperty.SetDefault(_viewSwitcherTestScrollExampleScrollableRegion7, ViewSwitcherTestScrollExampleScrollableRegion7HorizontalScrollbar);
                    Delight.ScrollableRegion.VerticalScrollbarTemplateProperty.SetDefault(_viewSwitcherTestScrollExampleScrollableRegion7, ViewSwitcherTestScrollExampleScrollableRegion7VerticalScrollbar);
                }
                return _viewSwitcherTestScrollExampleScrollableRegion7;
            }
        }

        private static Template _viewSwitcherTestScrollExampleScrollableRegion7ContentRegion;
        public static Template ViewSwitcherTestScrollExampleScrollableRegion7ContentRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleScrollableRegion7ContentRegion == null || _viewSwitcherTestScrollExampleScrollableRegion7ContentRegion.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleScrollableRegion7ContentRegion == null)
#endif
                {
                    _viewSwitcherTestScrollExampleScrollableRegion7ContentRegion = new Template(ScrollExampleTemplates.ScrollExampleScrollableRegion7ContentRegion);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleScrollableRegion7ContentRegion.Name = "ViewSwitcherTestScrollExampleScrollableRegion7ContentRegion";
#endif
                }
                return _viewSwitcherTestScrollExampleScrollableRegion7ContentRegion;
            }
        }

        private static Template _viewSwitcherTestScrollExampleScrollableRegion7HorizontalScrollbar;
        public static Template ViewSwitcherTestScrollExampleScrollableRegion7HorizontalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleScrollableRegion7HorizontalScrollbar == null || _viewSwitcherTestScrollExampleScrollableRegion7HorizontalScrollbar.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleScrollableRegion7HorizontalScrollbar == null)
#endif
                {
                    _viewSwitcherTestScrollExampleScrollableRegion7HorizontalScrollbar = new Template(ScrollExampleTemplates.ScrollExampleScrollableRegion7HorizontalScrollbar);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleScrollableRegion7HorizontalScrollbar.Name = "ViewSwitcherTestScrollExampleScrollableRegion7HorizontalScrollbar";
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_viewSwitcherTestScrollExampleScrollableRegion7HorizontalScrollbar, ViewSwitcherTestScrollExampleScrollableRegion7HorizontalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_viewSwitcherTestScrollExampleScrollableRegion7HorizontalScrollbar, ViewSwitcherTestScrollExampleScrollableRegion7HorizontalScrollbarHandle);
                }
                return _viewSwitcherTestScrollExampleScrollableRegion7HorizontalScrollbar;
            }
        }

        private static Template _viewSwitcherTestScrollExampleScrollableRegion7HorizontalScrollbarBar;
        public static Template ViewSwitcherTestScrollExampleScrollableRegion7HorizontalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleScrollableRegion7HorizontalScrollbarBar == null || _viewSwitcherTestScrollExampleScrollableRegion7HorizontalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleScrollableRegion7HorizontalScrollbarBar == null)
#endif
                {
                    _viewSwitcherTestScrollExampleScrollableRegion7HorizontalScrollbarBar = new Template(ScrollExampleTemplates.ScrollExampleScrollableRegion7HorizontalScrollbarBar);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleScrollableRegion7HorizontalScrollbarBar.Name = "ViewSwitcherTestScrollExampleScrollableRegion7HorizontalScrollbarBar";
#endif
                }
                return _viewSwitcherTestScrollExampleScrollableRegion7HorizontalScrollbarBar;
            }
        }

        private static Template _viewSwitcherTestScrollExampleScrollableRegion7HorizontalScrollbarHandle;
        public static Template ViewSwitcherTestScrollExampleScrollableRegion7HorizontalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleScrollableRegion7HorizontalScrollbarHandle == null || _viewSwitcherTestScrollExampleScrollableRegion7HorizontalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleScrollableRegion7HorizontalScrollbarHandle == null)
#endif
                {
                    _viewSwitcherTestScrollExampleScrollableRegion7HorizontalScrollbarHandle = new Template(ScrollExampleTemplates.ScrollExampleScrollableRegion7HorizontalScrollbarHandle);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleScrollableRegion7HorizontalScrollbarHandle.Name = "ViewSwitcherTestScrollExampleScrollableRegion7HorizontalScrollbarHandle";
#endif
                }
                return _viewSwitcherTestScrollExampleScrollableRegion7HorizontalScrollbarHandle;
            }
        }

        private static Template _viewSwitcherTestScrollExampleScrollableRegion7VerticalScrollbar;
        public static Template ViewSwitcherTestScrollExampleScrollableRegion7VerticalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleScrollableRegion7VerticalScrollbar == null || _viewSwitcherTestScrollExampleScrollableRegion7VerticalScrollbar.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleScrollableRegion7VerticalScrollbar == null)
#endif
                {
                    _viewSwitcherTestScrollExampleScrollableRegion7VerticalScrollbar = new Template(ScrollExampleTemplates.ScrollExampleScrollableRegion7VerticalScrollbar);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleScrollableRegion7VerticalScrollbar.Name = "ViewSwitcherTestScrollExampleScrollableRegion7VerticalScrollbar";
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_viewSwitcherTestScrollExampleScrollableRegion7VerticalScrollbar, ViewSwitcherTestScrollExampleScrollableRegion7VerticalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_viewSwitcherTestScrollExampleScrollableRegion7VerticalScrollbar, ViewSwitcherTestScrollExampleScrollableRegion7VerticalScrollbarHandle);
                }
                return _viewSwitcherTestScrollExampleScrollableRegion7VerticalScrollbar;
            }
        }

        private static Template _viewSwitcherTestScrollExampleScrollableRegion7VerticalScrollbarBar;
        public static Template ViewSwitcherTestScrollExampleScrollableRegion7VerticalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleScrollableRegion7VerticalScrollbarBar == null || _viewSwitcherTestScrollExampleScrollableRegion7VerticalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleScrollableRegion7VerticalScrollbarBar == null)
#endif
                {
                    _viewSwitcherTestScrollExampleScrollableRegion7VerticalScrollbarBar = new Template(ScrollExampleTemplates.ScrollExampleScrollableRegion7VerticalScrollbarBar);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleScrollableRegion7VerticalScrollbarBar.Name = "ViewSwitcherTestScrollExampleScrollableRegion7VerticalScrollbarBar";
#endif
                }
                return _viewSwitcherTestScrollExampleScrollableRegion7VerticalScrollbarBar;
            }
        }

        private static Template _viewSwitcherTestScrollExampleScrollableRegion7VerticalScrollbarHandle;
        public static Template ViewSwitcherTestScrollExampleScrollableRegion7VerticalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleScrollableRegion7VerticalScrollbarHandle == null || _viewSwitcherTestScrollExampleScrollableRegion7VerticalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleScrollableRegion7VerticalScrollbarHandle == null)
#endif
                {
                    _viewSwitcherTestScrollExampleScrollableRegion7VerticalScrollbarHandle = new Template(ScrollExampleTemplates.ScrollExampleScrollableRegion7VerticalScrollbarHandle);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleScrollableRegion7VerticalScrollbarHandle.Name = "ViewSwitcherTestScrollExampleScrollableRegion7VerticalScrollbarHandle";
#endif
                }
                return _viewSwitcherTestScrollExampleScrollableRegion7VerticalScrollbarHandle;
            }
        }

        private static Template _viewSwitcherTestScrollExampleRegion31;
        public static Template ViewSwitcherTestScrollExampleRegion31
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleRegion31 == null || _viewSwitcherTestScrollExampleRegion31.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleRegion31 == null)
#endif
                {
                    _viewSwitcherTestScrollExampleRegion31 = new Template(ScrollExampleTemplates.ScrollExampleRegion31);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleRegion31.Name = "ViewSwitcherTestScrollExampleRegion31";
#endif
                }
                return _viewSwitcherTestScrollExampleRegion31;
            }
        }

        private static Template _viewSwitcherTestScrollExampleRegion32;
        public static Template ViewSwitcherTestScrollExampleRegion32
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleRegion32 == null || _viewSwitcherTestScrollExampleRegion32.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleRegion32 == null)
#endif
                {
                    _viewSwitcherTestScrollExampleRegion32 = new Template(ScrollExampleTemplates.ScrollExampleRegion32);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleRegion32.Name = "ViewSwitcherTestScrollExampleRegion32";
#endif
                }
                return _viewSwitcherTestScrollExampleRegion32;
            }
        }

        private static Template _viewSwitcherTestScrollExampleRegion33;
        public static Template ViewSwitcherTestScrollExampleRegion33
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleRegion33 == null || _viewSwitcherTestScrollExampleRegion33.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleRegion33 == null)
#endif
                {
                    _viewSwitcherTestScrollExampleRegion33 = new Template(ScrollExampleTemplates.ScrollExampleRegion33);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleRegion33.Name = "ViewSwitcherTestScrollExampleRegion33";
#endif
                }
                return _viewSwitcherTestScrollExampleRegion33;
            }
        }

        private static Template _viewSwitcherTestScrollExampleRegion34;
        public static Template ViewSwitcherTestScrollExampleRegion34
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleRegion34 == null || _viewSwitcherTestScrollExampleRegion34.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleRegion34 == null)
#endif
                {
                    _viewSwitcherTestScrollExampleRegion34 = new Template(ScrollExampleTemplates.ScrollExampleRegion34);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleRegion34.Name = "ViewSwitcherTestScrollExampleRegion34";
#endif
                }
                return _viewSwitcherTestScrollExampleRegion34;
            }
        }

        private static Template _viewSwitcherTestScrollExampleRegion35;
        public static Template ViewSwitcherTestScrollExampleRegion35
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleRegion35 == null || _viewSwitcherTestScrollExampleRegion35.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleRegion35 == null)
#endif
                {
                    _viewSwitcherTestScrollExampleRegion35 = new Template(ScrollExampleTemplates.ScrollExampleRegion35);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleRegion35.Name = "ViewSwitcherTestScrollExampleRegion35";
#endif
                }
                return _viewSwitcherTestScrollExampleRegion35;
            }
        }

        private static Template _viewSwitcherTestScrollExampleScrollableRegion8;
        public static Template ViewSwitcherTestScrollExampleScrollableRegion8
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleScrollableRegion8 == null || _viewSwitcherTestScrollExampleScrollableRegion8.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleScrollableRegion8 == null)
#endif
                {
                    _viewSwitcherTestScrollExampleScrollableRegion8 = new Template(ScrollExampleTemplates.ScrollExampleScrollableRegion8);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleScrollableRegion8.Name = "ViewSwitcherTestScrollExampleScrollableRegion8";
#endif
                    Delight.ScrollableRegion.ContentRegionTemplateProperty.SetDefault(_viewSwitcherTestScrollExampleScrollableRegion8, ViewSwitcherTestScrollExampleScrollableRegion8ContentRegion);
                    Delight.ScrollableRegion.HorizontalScrollbarTemplateProperty.SetDefault(_viewSwitcherTestScrollExampleScrollableRegion8, ViewSwitcherTestScrollExampleScrollableRegion8HorizontalScrollbar);
                    Delight.ScrollableRegion.VerticalScrollbarTemplateProperty.SetDefault(_viewSwitcherTestScrollExampleScrollableRegion8, ViewSwitcherTestScrollExampleScrollableRegion8VerticalScrollbar);
                }
                return _viewSwitcherTestScrollExampleScrollableRegion8;
            }
        }

        private static Template _viewSwitcherTestScrollExampleScrollableRegion8ContentRegion;
        public static Template ViewSwitcherTestScrollExampleScrollableRegion8ContentRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleScrollableRegion8ContentRegion == null || _viewSwitcherTestScrollExampleScrollableRegion8ContentRegion.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleScrollableRegion8ContentRegion == null)
#endif
                {
                    _viewSwitcherTestScrollExampleScrollableRegion8ContentRegion = new Template(ScrollExampleTemplates.ScrollExampleScrollableRegion8ContentRegion);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleScrollableRegion8ContentRegion.Name = "ViewSwitcherTestScrollExampleScrollableRegion8ContentRegion";
#endif
                }
                return _viewSwitcherTestScrollExampleScrollableRegion8ContentRegion;
            }
        }

        private static Template _viewSwitcherTestScrollExampleScrollableRegion8HorizontalScrollbar;
        public static Template ViewSwitcherTestScrollExampleScrollableRegion8HorizontalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleScrollableRegion8HorizontalScrollbar == null || _viewSwitcherTestScrollExampleScrollableRegion8HorizontalScrollbar.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleScrollableRegion8HorizontalScrollbar == null)
#endif
                {
                    _viewSwitcherTestScrollExampleScrollableRegion8HorizontalScrollbar = new Template(ScrollExampleTemplates.ScrollExampleScrollableRegion8HorizontalScrollbar);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleScrollableRegion8HorizontalScrollbar.Name = "ViewSwitcherTestScrollExampleScrollableRegion8HorizontalScrollbar";
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_viewSwitcherTestScrollExampleScrollableRegion8HorizontalScrollbar, ViewSwitcherTestScrollExampleScrollableRegion8HorizontalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_viewSwitcherTestScrollExampleScrollableRegion8HorizontalScrollbar, ViewSwitcherTestScrollExampleScrollableRegion8HorizontalScrollbarHandle);
                }
                return _viewSwitcherTestScrollExampleScrollableRegion8HorizontalScrollbar;
            }
        }

        private static Template _viewSwitcherTestScrollExampleScrollableRegion8HorizontalScrollbarBar;
        public static Template ViewSwitcherTestScrollExampleScrollableRegion8HorizontalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleScrollableRegion8HorizontalScrollbarBar == null || _viewSwitcherTestScrollExampleScrollableRegion8HorizontalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleScrollableRegion8HorizontalScrollbarBar == null)
#endif
                {
                    _viewSwitcherTestScrollExampleScrollableRegion8HorizontalScrollbarBar = new Template(ScrollExampleTemplates.ScrollExampleScrollableRegion8HorizontalScrollbarBar);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleScrollableRegion8HorizontalScrollbarBar.Name = "ViewSwitcherTestScrollExampleScrollableRegion8HorizontalScrollbarBar";
#endif
                }
                return _viewSwitcherTestScrollExampleScrollableRegion8HorizontalScrollbarBar;
            }
        }

        private static Template _viewSwitcherTestScrollExampleScrollableRegion8HorizontalScrollbarHandle;
        public static Template ViewSwitcherTestScrollExampleScrollableRegion8HorizontalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleScrollableRegion8HorizontalScrollbarHandle == null || _viewSwitcherTestScrollExampleScrollableRegion8HorizontalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleScrollableRegion8HorizontalScrollbarHandle == null)
#endif
                {
                    _viewSwitcherTestScrollExampleScrollableRegion8HorizontalScrollbarHandle = new Template(ScrollExampleTemplates.ScrollExampleScrollableRegion8HorizontalScrollbarHandle);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleScrollableRegion8HorizontalScrollbarHandle.Name = "ViewSwitcherTestScrollExampleScrollableRegion8HorizontalScrollbarHandle";
#endif
                }
                return _viewSwitcherTestScrollExampleScrollableRegion8HorizontalScrollbarHandle;
            }
        }

        private static Template _viewSwitcherTestScrollExampleScrollableRegion8VerticalScrollbar;
        public static Template ViewSwitcherTestScrollExampleScrollableRegion8VerticalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleScrollableRegion8VerticalScrollbar == null || _viewSwitcherTestScrollExampleScrollableRegion8VerticalScrollbar.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleScrollableRegion8VerticalScrollbar == null)
#endif
                {
                    _viewSwitcherTestScrollExampleScrollableRegion8VerticalScrollbar = new Template(ScrollExampleTemplates.ScrollExampleScrollableRegion8VerticalScrollbar);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleScrollableRegion8VerticalScrollbar.Name = "ViewSwitcherTestScrollExampleScrollableRegion8VerticalScrollbar";
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_viewSwitcherTestScrollExampleScrollableRegion8VerticalScrollbar, ViewSwitcherTestScrollExampleScrollableRegion8VerticalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_viewSwitcherTestScrollExampleScrollableRegion8VerticalScrollbar, ViewSwitcherTestScrollExampleScrollableRegion8VerticalScrollbarHandle);
                }
                return _viewSwitcherTestScrollExampleScrollableRegion8VerticalScrollbar;
            }
        }

        private static Template _viewSwitcherTestScrollExampleScrollableRegion8VerticalScrollbarBar;
        public static Template ViewSwitcherTestScrollExampleScrollableRegion8VerticalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleScrollableRegion8VerticalScrollbarBar == null || _viewSwitcherTestScrollExampleScrollableRegion8VerticalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleScrollableRegion8VerticalScrollbarBar == null)
#endif
                {
                    _viewSwitcherTestScrollExampleScrollableRegion8VerticalScrollbarBar = new Template(ScrollExampleTemplates.ScrollExampleScrollableRegion8VerticalScrollbarBar);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleScrollableRegion8VerticalScrollbarBar.Name = "ViewSwitcherTestScrollExampleScrollableRegion8VerticalScrollbarBar";
#endif
                }
                return _viewSwitcherTestScrollExampleScrollableRegion8VerticalScrollbarBar;
            }
        }

        private static Template _viewSwitcherTestScrollExampleScrollableRegion8VerticalScrollbarHandle;
        public static Template ViewSwitcherTestScrollExampleScrollableRegion8VerticalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleScrollableRegion8VerticalScrollbarHandle == null || _viewSwitcherTestScrollExampleScrollableRegion8VerticalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleScrollableRegion8VerticalScrollbarHandle == null)
#endif
                {
                    _viewSwitcherTestScrollExampleScrollableRegion8VerticalScrollbarHandle = new Template(ScrollExampleTemplates.ScrollExampleScrollableRegion8VerticalScrollbarHandle);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleScrollableRegion8VerticalScrollbarHandle.Name = "ViewSwitcherTestScrollExampleScrollableRegion8VerticalScrollbarHandle";
#endif
                }
                return _viewSwitcherTestScrollExampleScrollableRegion8VerticalScrollbarHandle;
            }
        }

        private static Template _viewSwitcherTestScrollExampleRegion36;
        public static Template ViewSwitcherTestScrollExampleRegion36
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleRegion36 == null || _viewSwitcherTestScrollExampleRegion36.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleRegion36 == null)
#endif
                {
                    _viewSwitcherTestScrollExampleRegion36 = new Template(ScrollExampleTemplates.ScrollExampleRegion36);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleRegion36.Name = "ViewSwitcherTestScrollExampleRegion36";
#endif
                }
                return _viewSwitcherTestScrollExampleRegion36;
            }
        }

        private static Template _viewSwitcherTestScrollExampleRegion37;
        public static Template ViewSwitcherTestScrollExampleRegion37
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleRegion37 == null || _viewSwitcherTestScrollExampleRegion37.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleRegion37 == null)
#endif
                {
                    _viewSwitcherTestScrollExampleRegion37 = new Template(ScrollExampleTemplates.ScrollExampleRegion37);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleRegion37.Name = "ViewSwitcherTestScrollExampleRegion37";
#endif
                }
                return _viewSwitcherTestScrollExampleRegion37;
            }
        }

        private static Template _viewSwitcherTestScrollExampleRegion38;
        public static Template ViewSwitcherTestScrollExampleRegion38
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleRegion38 == null || _viewSwitcherTestScrollExampleRegion38.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleRegion38 == null)
#endif
                {
                    _viewSwitcherTestScrollExampleRegion38 = new Template(ScrollExampleTemplates.ScrollExampleRegion38);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleRegion38.Name = "ViewSwitcherTestScrollExampleRegion38";
#endif
                }
                return _viewSwitcherTestScrollExampleRegion38;
            }
        }

        private static Template _viewSwitcherTestScrollExampleRegion39;
        public static Template ViewSwitcherTestScrollExampleRegion39
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleRegion39 == null || _viewSwitcherTestScrollExampleRegion39.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleRegion39 == null)
#endif
                {
                    _viewSwitcherTestScrollExampleRegion39 = new Template(ScrollExampleTemplates.ScrollExampleRegion39);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleRegion39.Name = "ViewSwitcherTestScrollExampleRegion39";
#endif
                }
                return _viewSwitcherTestScrollExampleRegion39;
            }
        }

        private static Template _viewSwitcherTestScrollExampleRegion40;
        public static Template ViewSwitcherTestScrollExampleRegion40
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleRegion40 == null || _viewSwitcherTestScrollExampleRegion40.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleRegion40 == null)
#endif
                {
                    _viewSwitcherTestScrollExampleRegion40 = new Template(ScrollExampleTemplates.ScrollExampleRegion40);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleRegion40.Name = "ViewSwitcherTestScrollExampleRegion40";
#endif
                }
                return _viewSwitcherTestScrollExampleRegion40;
            }
        }

        private static Template _viewSwitcherTestScrollExampleScrollableRegion9;
        public static Template ViewSwitcherTestScrollExampleScrollableRegion9
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleScrollableRegion9 == null || _viewSwitcherTestScrollExampleScrollableRegion9.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleScrollableRegion9 == null)
#endif
                {
                    _viewSwitcherTestScrollExampleScrollableRegion9 = new Template(ScrollExampleTemplates.ScrollExampleScrollableRegion9);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleScrollableRegion9.Name = "ViewSwitcherTestScrollExampleScrollableRegion9";
#endif
                    Delight.ScrollableRegion.ContentRegionTemplateProperty.SetDefault(_viewSwitcherTestScrollExampleScrollableRegion9, ViewSwitcherTestScrollExampleScrollableRegion9ContentRegion);
                    Delight.ScrollableRegion.HorizontalScrollbarTemplateProperty.SetDefault(_viewSwitcherTestScrollExampleScrollableRegion9, ViewSwitcherTestScrollExampleScrollableRegion9HorizontalScrollbar);
                    Delight.ScrollableRegion.VerticalScrollbarTemplateProperty.SetDefault(_viewSwitcherTestScrollExampleScrollableRegion9, ViewSwitcherTestScrollExampleScrollableRegion9VerticalScrollbar);
                }
                return _viewSwitcherTestScrollExampleScrollableRegion9;
            }
        }

        private static Template _viewSwitcherTestScrollExampleScrollableRegion9ContentRegion;
        public static Template ViewSwitcherTestScrollExampleScrollableRegion9ContentRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleScrollableRegion9ContentRegion == null || _viewSwitcherTestScrollExampleScrollableRegion9ContentRegion.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleScrollableRegion9ContentRegion == null)
#endif
                {
                    _viewSwitcherTestScrollExampleScrollableRegion9ContentRegion = new Template(ScrollExampleTemplates.ScrollExampleScrollableRegion9ContentRegion);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleScrollableRegion9ContentRegion.Name = "ViewSwitcherTestScrollExampleScrollableRegion9ContentRegion";
#endif
                }
                return _viewSwitcherTestScrollExampleScrollableRegion9ContentRegion;
            }
        }

        private static Template _viewSwitcherTestScrollExampleScrollableRegion9HorizontalScrollbar;
        public static Template ViewSwitcherTestScrollExampleScrollableRegion9HorizontalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleScrollableRegion9HorizontalScrollbar == null || _viewSwitcherTestScrollExampleScrollableRegion9HorizontalScrollbar.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleScrollableRegion9HorizontalScrollbar == null)
#endif
                {
                    _viewSwitcherTestScrollExampleScrollableRegion9HorizontalScrollbar = new Template(ScrollExampleTemplates.ScrollExampleScrollableRegion9HorizontalScrollbar);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleScrollableRegion9HorizontalScrollbar.Name = "ViewSwitcherTestScrollExampleScrollableRegion9HorizontalScrollbar";
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_viewSwitcherTestScrollExampleScrollableRegion9HorizontalScrollbar, ViewSwitcherTestScrollExampleScrollableRegion9HorizontalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_viewSwitcherTestScrollExampleScrollableRegion9HorizontalScrollbar, ViewSwitcherTestScrollExampleScrollableRegion9HorizontalScrollbarHandle);
                }
                return _viewSwitcherTestScrollExampleScrollableRegion9HorizontalScrollbar;
            }
        }

        private static Template _viewSwitcherTestScrollExampleScrollableRegion9HorizontalScrollbarBar;
        public static Template ViewSwitcherTestScrollExampleScrollableRegion9HorizontalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleScrollableRegion9HorizontalScrollbarBar == null || _viewSwitcherTestScrollExampleScrollableRegion9HorizontalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleScrollableRegion9HorizontalScrollbarBar == null)
#endif
                {
                    _viewSwitcherTestScrollExampleScrollableRegion9HorizontalScrollbarBar = new Template(ScrollExampleTemplates.ScrollExampleScrollableRegion9HorizontalScrollbarBar);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleScrollableRegion9HorizontalScrollbarBar.Name = "ViewSwitcherTestScrollExampleScrollableRegion9HorizontalScrollbarBar";
#endif
                }
                return _viewSwitcherTestScrollExampleScrollableRegion9HorizontalScrollbarBar;
            }
        }

        private static Template _viewSwitcherTestScrollExampleScrollableRegion9HorizontalScrollbarHandle;
        public static Template ViewSwitcherTestScrollExampleScrollableRegion9HorizontalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleScrollableRegion9HorizontalScrollbarHandle == null || _viewSwitcherTestScrollExampleScrollableRegion9HorizontalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleScrollableRegion9HorizontalScrollbarHandle == null)
#endif
                {
                    _viewSwitcherTestScrollExampleScrollableRegion9HorizontalScrollbarHandle = new Template(ScrollExampleTemplates.ScrollExampleScrollableRegion9HorizontalScrollbarHandle);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleScrollableRegion9HorizontalScrollbarHandle.Name = "ViewSwitcherTestScrollExampleScrollableRegion9HorizontalScrollbarHandle";
#endif
                }
                return _viewSwitcherTestScrollExampleScrollableRegion9HorizontalScrollbarHandle;
            }
        }

        private static Template _viewSwitcherTestScrollExampleScrollableRegion9VerticalScrollbar;
        public static Template ViewSwitcherTestScrollExampleScrollableRegion9VerticalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleScrollableRegion9VerticalScrollbar == null || _viewSwitcherTestScrollExampleScrollableRegion9VerticalScrollbar.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleScrollableRegion9VerticalScrollbar == null)
#endif
                {
                    _viewSwitcherTestScrollExampleScrollableRegion9VerticalScrollbar = new Template(ScrollExampleTemplates.ScrollExampleScrollableRegion9VerticalScrollbar);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleScrollableRegion9VerticalScrollbar.Name = "ViewSwitcherTestScrollExampleScrollableRegion9VerticalScrollbar";
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_viewSwitcherTestScrollExampleScrollableRegion9VerticalScrollbar, ViewSwitcherTestScrollExampleScrollableRegion9VerticalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_viewSwitcherTestScrollExampleScrollableRegion9VerticalScrollbar, ViewSwitcherTestScrollExampleScrollableRegion9VerticalScrollbarHandle);
                }
                return _viewSwitcherTestScrollExampleScrollableRegion9VerticalScrollbar;
            }
        }

        private static Template _viewSwitcherTestScrollExampleScrollableRegion9VerticalScrollbarBar;
        public static Template ViewSwitcherTestScrollExampleScrollableRegion9VerticalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleScrollableRegion9VerticalScrollbarBar == null || _viewSwitcherTestScrollExampleScrollableRegion9VerticalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleScrollableRegion9VerticalScrollbarBar == null)
#endif
                {
                    _viewSwitcherTestScrollExampleScrollableRegion9VerticalScrollbarBar = new Template(ScrollExampleTemplates.ScrollExampleScrollableRegion9VerticalScrollbarBar);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleScrollableRegion9VerticalScrollbarBar.Name = "ViewSwitcherTestScrollExampleScrollableRegion9VerticalScrollbarBar";
#endif
                }
                return _viewSwitcherTestScrollExampleScrollableRegion9VerticalScrollbarBar;
            }
        }

        private static Template _viewSwitcherTestScrollExampleScrollableRegion9VerticalScrollbarHandle;
        public static Template ViewSwitcherTestScrollExampleScrollableRegion9VerticalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleScrollableRegion9VerticalScrollbarHandle == null || _viewSwitcherTestScrollExampleScrollableRegion9VerticalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleScrollableRegion9VerticalScrollbarHandle == null)
#endif
                {
                    _viewSwitcherTestScrollExampleScrollableRegion9VerticalScrollbarHandle = new Template(ScrollExampleTemplates.ScrollExampleScrollableRegion9VerticalScrollbarHandle);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleScrollableRegion9VerticalScrollbarHandle.Name = "ViewSwitcherTestScrollExampleScrollableRegion9VerticalScrollbarHandle";
#endif
                }
                return _viewSwitcherTestScrollExampleScrollableRegion9VerticalScrollbarHandle;
            }
        }

        private static Template _viewSwitcherTestScrollExampleRegion41;
        public static Template ViewSwitcherTestScrollExampleRegion41
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleRegion41 == null || _viewSwitcherTestScrollExampleRegion41.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleRegion41 == null)
#endif
                {
                    _viewSwitcherTestScrollExampleRegion41 = new Template(ScrollExampleTemplates.ScrollExampleRegion41);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleRegion41.Name = "ViewSwitcherTestScrollExampleRegion41";
#endif
                }
                return _viewSwitcherTestScrollExampleRegion41;
            }
        }

        private static Template _viewSwitcherTestScrollExampleRegion42;
        public static Template ViewSwitcherTestScrollExampleRegion42
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleRegion42 == null || _viewSwitcherTestScrollExampleRegion42.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleRegion42 == null)
#endif
                {
                    _viewSwitcherTestScrollExampleRegion42 = new Template(ScrollExampleTemplates.ScrollExampleRegion42);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleRegion42.Name = "ViewSwitcherTestScrollExampleRegion42";
#endif
                }
                return _viewSwitcherTestScrollExampleRegion42;
            }
        }

        private static Template _viewSwitcherTestScrollExampleRegion43;
        public static Template ViewSwitcherTestScrollExampleRegion43
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleRegion43 == null || _viewSwitcherTestScrollExampleRegion43.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleRegion43 == null)
#endif
                {
                    _viewSwitcherTestScrollExampleRegion43 = new Template(ScrollExampleTemplates.ScrollExampleRegion43);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleRegion43.Name = "ViewSwitcherTestScrollExampleRegion43";
#endif
                }
                return _viewSwitcherTestScrollExampleRegion43;
            }
        }

        private static Template _viewSwitcherTestScrollExampleRegion44;
        public static Template ViewSwitcherTestScrollExampleRegion44
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleRegion44 == null || _viewSwitcherTestScrollExampleRegion44.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleRegion44 == null)
#endif
                {
                    _viewSwitcherTestScrollExampleRegion44 = new Template(ScrollExampleTemplates.ScrollExampleRegion44);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleRegion44.Name = "ViewSwitcherTestScrollExampleRegion44";
#endif
                }
                return _viewSwitcherTestScrollExampleRegion44;
            }
        }

        private static Template _viewSwitcherTestScrollExampleRegion45;
        public static Template ViewSwitcherTestScrollExampleRegion45
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestScrollExampleRegion45 == null || _viewSwitcherTestScrollExampleRegion45.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestScrollExampleRegion45 == null)
#endif
                {
                    _viewSwitcherTestScrollExampleRegion45 = new Template(ScrollExampleTemplates.ScrollExampleRegion45);
#if UNITY_EDITOR
                    _viewSwitcherTestScrollExampleRegion45.Name = "ViewSwitcherTestScrollExampleRegion45";
#endif
                }
                return _viewSwitcherTestScrollExampleRegion45;
            }
        }

        private static Template _viewSwitcherTestAssetManagementTest;
        public static Template ViewSwitcherTestAssetManagementTest
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestAssetManagementTest == null || _viewSwitcherTestAssetManagementTest.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestAssetManagementTest == null)
#endif
                {
                    _viewSwitcherTestAssetManagementTest = new Template(AssetManagementTestTemplates.AssetManagementTest);
#if UNITY_EDITOR
                    _viewSwitcherTestAssetManagementTest.Name = "ViewSwitcherTestAssetManagementTest";
#endif
                    Delight.AssetManagementTest.Label1TemplateProperty.SetDefault(_viewSwitcherTestAssetManagementTest, ViewSwitcherTestAssetManagementTestLabel1);
                    Delight.AssetManagementTest.Label2TemplateProperty.SetDefault(_viewSwitcherTestAssetManagementTest, ViewSwitcherTestAssetManagementTestLabel2);
                    Delight.AssetManagementTest.Label3TemplateProperty.SetDefault(_viewSwitcherTestAssetManagementTest, ViewSwitcherTestAssetManagementTestLabel3);
                    Delight.AssetManagementTest.Region1TemplateProperty.SetDefault(_viewSwitcherTestAssetManagementTest, ViewSwitcherTestAssetManagementTestRegion1);
                    Delight.AssetManagementTest.Group1TemplateProperty.SetDefault(_viewSwitcherTestAssetManagementTest, ViewSwitcherTestAssetManagementTestGroup1);
                    Delight.AssetManagementTest.LoadAllButtonTemplateProperty.SetDefault(_viewSwitcherTestAssetManagementTest, ViewSwitcherTestAssetManagementTestLoadAllButton);
                    Delight.AssetManagementTest.Load1ButtonTemplateProperty.SetDefault(_viewSwitcherTestAssetManagementTest, ViewSwitcherTestAssetManagementTestLoad1Button);
                    Delight.AssetManagementTest.Load2ButtonTemplateProperty.SetDefault(_viewSwitcherTestAssetManagementTest, ViewSwitcherTestAssetManagementTestLoad2Button);
                    Delight.AssetManagementTest.Load3ButtonTemplateProperty.SetDefault(_viewSwitcherTestAssetManagementTest, ViewSwitcherTestAssetManagementTestLoad3Button);
                    Delight.AssetManagementTest.Load4ButtonTemplateProperty.SetDefault(_viewSwitcherTestAssetManagementTest, ViewSwitcherTestAssetManagementTestLoad4Button);
                    Delight.AssetManagementTest.Button1TemplateProperty.SetDefault(_viewSwitcherTestAssetManagementTest, ViewSwitcherTestAssetManagementTestButton1);
                    Delight.AssetManagementTest.Button2TemplateProperty.SetDefault(_viewSwitcherTestAssetManagementTest, ViewSwitcherTestAssetManagementTestButton2);
                    Delight.AssetManagementTest.ImageGroupTemplateProperty.SetDefault(_viewSwitcherTestAssetManagementTest, ViewSwitcherTestAssetManagementTestImageGroup);
                    Delight.AssetManagementTest.ImageSet1TemplateProperty.SetDefault(_viewSwitcherTestAssetManagementTest, ViewSwitcherTestAssetManagementTestImageSet1);
                    Delight.AssetManagementTest.Image1TemplateProperty.SetDefault(_viewSwitcherTestAssetManagementTest, ViewSwitcherTestAssetManagementTestImage1);
                    Delight.AssetManagementTest.Image2TemplateProperty.SetDefault(_viewSwitcherTestAssetManagementTest, ViewSwitcherTestAssetManagementTestImage2);
                    Delight.AssetManagementTest.ImageSet2TemplateProperty.SetDefault(_viewSwitcherTestAssetManagementTest, ViewSwitcherTestAssetManagementTestImageSet2);
                    Delight.AssetManagementTest.Image3TemplateProperty.SetDefault(_viewSwitcherTestAssetManagementTest, ViewSwitcherTestAssetManagementTestImage3);
                    Delight.AssetManagementTest.Image4TemplateProperty.SetDefault(_viewSwitcherTestAssetManagementTest, ViewSwitcherTestAssetManagementTestImage4);
                    Delight.AssetManagementTest.ImageSet3TemplateProperty.SetDefault(_viewSwitcherTestAssetManagementTest, ViewSwitcherTestAssetManagementTestImageSet3);
                    Delight.AssetManagementTest.Image5TemplateProperty.SetDefault(_viewSwitcherTestAssetManagementTest, ViewSwitcherTestAssetManagementTestImage5);
                    Delight.AssetManagementTest.Image6TemplateProperty.SetDefault(_viewSwitcherTestAssetManagementTest, ViewSwitcherTestAssetManagementTestImage6);
                    Delight.AssetManagementTest.ImageSet4TemplateProperty.SetDefault(_viewSwitcherTestAssetManagementTest, ViewSwitcherTestAssetManagementTestImageSet4);
                    Delight.AssetManagementTest.BigSpriteImageTemplateProperty.SetDefault(_viewSwitcherTestAssetManagementTest, ViewSwitcherTestAssetManagementTestBigSpriteImage);
                    Delight.AssetManagementTest.Label4TemplateProperty.SetDefault(_viewSwitcherTestAssetManagementTest, ViewSwitcherTestAssetManagementTestLabel4);
                }
                return _viewSwitcherTestAssetManagementTest;
            }
        }

        private static Template _viewSwitcherTestAssetManagementTestLabel1;
        public static Template ViewSwitcherTestAssetManagementTestLabel1
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestAssetManagementTestLabel1 == null || _viewSwitcherTestAssetManagementTestLabel1.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestAssetManagementTestLabel1 == null)
#endif
                {
                    _viewSwitcherTestAssetManagementTestLabel1 = new Template(AssetManagementTestTemplates.AssetManagementTestLabel1);
#if UNITY_EDITOR
                    _viewSwitcherTestAssetManagementTestLabel1.Name = "ViewSwitcherTestAssetManagementTestLabel1";
#endif
                }
                return _viewSwitcherTestAssetManagementTestLabel1;
            }
        }

        private static Template _viewSwitcherTestAssetManagementTestLabel2;
        public static Template ViewSwitcherTestAssetManagementTestLabel2
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestAssetManagementTestLabel2 == null || _viewSwitcherTestAssetManagementTestLabel2.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestAssetManagementTestLabel2 == null)
#endif
                {
                    _viewSwitcherTestAssetManagementTestLabel2 = new Template(AssetManagementTestTemplates.AssetManagementTestLabel2);
#if UNITY_EDITOR
                    _viewSwitcherTestAssetManagementTestLabel2.Name = "ViewSwitcherTestAssetManagementTestLabel2";
#endif
                }
                return _viewSwitcherTestAssetManagementTestLabel2;
            }
        }

        private static Template _viewSwitcherTestAssetManagementTestLabel3;
        public static Template ViewSwitcherTestAssetManagementTestLabel3
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestAssetManagementTestLabel3 == null || _viewSwitcherTestAssetManagementTestLabel3.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestAssetManagementTestLabel3 == null)
#endif
                {
                    _viewSwitcherTestAssetManagementTestLabel3 = new Template(AssetManagementTestTemplates.AssetManagementTestLabel3);
#if UNITY_EDITOR
                    _viewSwitcherTestAssetManagementTestLabel3.Name = "ViewSwitcherTestAssetManagementTestLabel3";
#endif
                }
                return _viewSwitcherTestAssetManagementTestLabel3;
            }
        }

        private static Template _viewSwitcherTestAssetManagementTestRegion1;
        public static Template ViewSwitcherTestAssetManagementTestRegion1
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestAssetManagementTestRegion1 == null || _viewSwitcherTestAssetManagementTestRegion1.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestAssetManagementTestRegion1 == null)
#endif
                {
                    _viewSwitcherTestAssetManagementTestRegion1 = new Template(AssetManagementTestTemplates.AssetManagementTestRegion1);
#if UNITY_EDITOR
                    _viewSwitcherTestAssetManagementTestRegion1.Name = "ViewSwitcherTestAssetManagementTestRegion1";
#endif
                }
                return _viewSwitcherTestAssetManagementTestRegion1;
            }
        }

        private static Template _viewSwitcherTestAssetManagementTestGroup1;
        public static Template ViewSwitcherTestAssetManagementTestGroup1
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestAssetManagementTestGroup1 == null || _viewSwitcherTestAssetManagementTestGroup1.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestAssetManagementTestGroup1 == null)
#endif
                {
                    _viewSwitcherTestAssetManagementTestGroup1 = new Template(AssetManagementTestTemplates.AssetManagementTestGroup1);
#if UNITY_EDITOR
                    _viewSwitcherTestAssetManagementTestGroup1.Name = "ViewSwitcherTestAssetManagementTestGroup1";
#endif
                }
                return _viewSwitcherTestAssetManagementTestGroup1;
            }
        }

        private static Template _viewSwitcherTestAssetManagementTestLoadAllButton;
        public static Template ViewSwitcherTestAssetManagementTestLoadAllButton
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestAssetManagementTestLoadAllButton == null || _viewSwitcherTestAssetManagementTestLoadAllButton.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestAssetManagementTestLoadAllButton == null)
#endif
                {
                    _viewSwitcherTestAssetManagementTestLoadAllButton = new Template(AssetManagementTestTemplates.AssetManagementTestLoadAllButton);
#if UNITY_EDITOR
                    _viewSwitcherTestAssetManagementTestLoadAllButton.Name = "ViewSwitcherTestAssetManagementTestLoadAllButton";
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_viewSwitcherTestAssetManagementTestLoadAllButton, ViewSwitcherTestAssetManagementTestLoadAllButtonLabel);
                }
                return _viewSwitcherTestAssetManagementTestLoadAllButton;
            }
        }

        private static Template _viewSwitcherTestAssetManagementTestLoadAllButtonLabel;
        public static Template ViewSwitcherTestAssetManagementTestLoadAllButtonLabel
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestAssetManagementTestLoadAllButtonLabel == null || _viewSwitcherTestAssetManagementTestLoadAllButtonLabel.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestAssetManagementTestLoadAllButtonLabel == null)
#endif
                {
                    _viewSwitcherTestAssetManagementTestLoadAllButtonLabel = new Template(AssetManagementTestTemplates.AssetManagementTestLoadAllButtonLabel);
#if UNITY_EDITOR
                    _viewSwitcherTestAssetManagementTestLoadAllButtonLabel.Name = "ViewSwitcherTestAssetManagementTestLoadAllButtonLabel";
#endif
                }
                return _viewSwitcherTestAssetManagementTestLoadAllButtonLabel;
            }
        }

        private static Template _viewSwitcherTestAssetManagementTestLoad1Button;
        public static Template ViewSwitcherTestAssetManagementTestLoad1Button
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestAssetManagementTestLoad1Button == null || _viewSwitcherTestAssetManagementTestLoad1Button.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestAssetManagementTestLoad1Button == null)
#endif
                {
                    _viewSwitcherTestAssetManagementTestLoad1Button = new Template(AssetManagementTestTemplates.AssetManagementTestLoad1Button);
#if UNITY_EDITOR
                    _viewSwitcherTestAssetManagementTestLoad1Button.Name = "ViewSwitcherTestAssetManagementTestLoad1Button";
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_viewSwitcherTestAssetManagementTestLoad1Button, ViewSwitcherTestAssetManagementTestLoad1ButtonLabel);
                }
                return _viewSwitcherTestAssetManagementTestLoad1Button;
            }
        }

        private static Template _viewSwitcherTestAssetManagementTestLoad1ButtonLabel;
        public static Template ViewSwitcherTestAssetManagementTestLoad1ButtonLabel
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestAssetManagementTestLoad1ButtonLabel == null || _viewSwitcherTestAssetManagementTestLoad1ButtonLabel.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestAssetManagementTestLoad1ButtonLabel == null)
#endif
                {
                    _viewSwitcherTestAssetManagementTestLoad1ButtonLabel = new Template(AssetManagementTestTemplates.AssetManagementTestLoad1ButtonLabel);
#if UNITY_EDITOR
                    _viewSwitcherTestAssetManagementTestLoad1ButtonLabel.Name = "ViewSwitcherTestAssetManagementTestLoad1ButtonLabel";
#endif
                }
                return _viewSwitcherTestAssetManagementTestLoad1ButtonLabel;
            }
        }

        private static Template _viewSwitcherTestAssetManagementTestLoad2Button;
        public static Template ViewSwitcherTestAssetManagementTestLoad2Button
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestAssetManagementTestLoad2Button == null || _viewSwitcherTestAssetManagementTestLoad2Button.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestAssetManagementTestLoad2Button == null)
#endif
                {
                    _viewSwitcherTestAssetManagementTestLoad2Button = new Template(AssetManagementTestTemplates.AssetManagementTestLoad2Button);
#if UNITY_EDITOR
                    _viewSwitcherTestAssetManagementTestLoad2Button.Name = "ViewSwitcherTestAssetManagementTestLoad2Button";
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_viewSwitcherTestAssetManagementTestLoad2Button, ViewSwitcherTestAssetManagementTestLoad2ButtonLabel);
                }
                return _viewSwitcherTestAssetManagementTestLoad2Button;
            }
        }

        private static Template _viewSwitcherTestAssetManagementTestLoad2ButtonLabel;
        public static Template ViewSwitcherTestAssetManagementTestLoad2ButtonLabel
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestAssetManagementTestLoad2ButtonLabel == null || _viewSwitcherTestAssetManagementTestLoad2ButtonLabel.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestAssetManagementTestLoad2ButtonLabel == null)
#endif
                {
                    _viewSwitcherTestAssetManagementTestLoad2ButtonLabel = new Template(AssetManagementTestTemplates.AssetManagementTestLoad2ButtonLabel);
#if UNITY_EDITOR
                    _viewSwitcherTestAssetManagementTestLoad2ButtonLabel.Name = "ViewSwitcherTestAssetManagementTestLoad2ButtonLabel";
#endif
                }
                return _viewSwitcherTestAssetManagementTestLoad2ButtonLabel;
            }
        }

        private static Template _viewSwitcherTestAssetManagementTestLoad3Button;
        public static Template ViewSwitcherTestAssetManagementTestLoad3Button
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestAssetManagementTestLoad3Button == null || _viewSwitcherTestAssetManagementTestLoad3Button.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestAssetManagementTestLoad3Button == null)
#endif
                {
                    _viewSwitcherTestAssetManagementTestLoad3Button = new Template(AssetManagementTestTemplates.AssetManagementTestLoad3Button);
#if UNITY_EDITOR
                    _viewSwitcherTestAssetManagementTestLoad3Button.Name = "ViewSwitcherTestAssetManagementTestLoad3Button";
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_viewSwitcherTestAssetManagementTestLoad3Button, ViewSwitcherTestAssetManagementTestLoad3ButtonLabel);
                }
                return _viewSwitcherTestAssetManagementTestLoad3Button;
            }
        }

        private static Template _viewSwitcherTestAssetManagementTestLoad3ButtonLabel;
        public static Template ViewSwitcherTestAssetManagementTestLoad3ButtonLabel
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestAssetManagementTestLoad3ButtonLabel == null || _viewSwitcherTestAssetManagementTestLoad3ButtonLabel.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestAssetManagementTestLoad3ButtonLabel == null)
#endif
                {
                    _viewSwitcherTestAssetManagementTestLoad3ButtonLabel = new Template(AssetManagementTestTemplates.AssetManagementTestLoad3ButtonLabel);
#if UNITY_EDITOR
                    _viewSwitcherTestAssetManagementTestLoad3ButtonLabel.Name = "ViewSwitcherTestAssetManagementTestLoad3ButtonLabel";
#endif
                }
                return _viewSwitcherTestAssetManagementTestLoad3ButtonLabel;
            }
        }

        private static Template _viewSwitcherTestAssetManagementTestLoad4Button;
        public static Template ViewSwitcherTestAssetManagementTestLoad4Button
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestAssetManagementTestLoad4Button == null || _viewSwitcherTestAssetManagementTestLoad4Button.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestAssetManagementTestLoad4Button == null)
#endif
                {
                    _viewSwitcherTestAssetManagementTestLoad4Button = new Template(AssetManagementTestTemplates.AssetManagementTestLoad4Button);
#if UNITY_EDITOR
                    _viewSwitcherTestAssetManagementTestLoad4Button.Name = "ViewSwitcherTestAssetManagementTestLoad4Button";
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_viewSwitcherTestAssetManagementTestLoad4Button, ViewSwitcherTestAssetManagementTestLoad4ButtonLabel);
                }
                return _viewSwitcherTestAssetManagementTestLoad4Button;
            }
        }

        private static Template _viewSwitcherTestAssetManagementTestLoad4ButtonLabel;
        public static Template ViewSwitcherTestAssetManagementTestLoad4ButtonLabel
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestAssetManagementTestLoad4ButtonLabel == null || _viewSwitcherTestAssetManagementTestLoad4ButtonLabel.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestAssetManagementTestLoad4ButtonLabel == null)
#endif
                {
                    _viewSwitcherTestAssetManagementTestLoad4ButtonLabel = new Template(AssetManagementTestTemplates.AssetManagementTestLoad4ButtonLabel);
#if UNITY_EDITOR
                    _viewSwitcherTestAssetManagementTestLoad4ButtonLabel.Name = "ViewSwitcherTestAssetManagementTestLoad4ButtonLabel";
#endif
                }
                return _viewSwitcherTestAssetManagementTestLoad4ButtonLabel;
            }
        }

        private static Template _viewSwitcherTestAssetManagementTestButton1;
        public static Template ViewSwitcherTestAssetManagementTestButton1
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestAssetManagementTestButton1 == null || _viewSwitcherTestAssetManagementTestButton1.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestAssetManagementTestButton1 == null)
#endif
                {
                    _viewSwitcherTestAssetManagementTestButton1 = new Template(AssetManagementTestTemplates.AssetManagementTestButton1);
#if UNITY_EDITOR
                    _viewSwitcherTestAssetManagementTestButton1.Name = "ViewSwitcherTestAssetManagementTestButton1";
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_viewSwitcherTestAssetManagementTestButton1, ViewSwitcherTestAssetManagementTestButton1Label);
                }
                return _viewSwitcherTestAssetManagementTestButton1;
            }
        }

        private static Template _viewSwitcherTestAssetManagementTestButton1Label;
        public static Template ViewSwitcherTestAssetManagementTestButton1Label
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestAssetManagementTestButton1Label == null || _viewSwitcherTestAssetManagementTestButton1Label.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestAssetManagementTestButton1Label == null)
#endif
                {
                    _viewSwitcherTestAssetManagementTestButton1Label = new Template(AssetManagementTestTemplates.AssetManagementTestButton1Label);
#if UNITY_EDITOR
                    _viewSwitcherTestAssetManagementTestButton1Label.Name = "ViewSwitcherTestAssetManagementTestButton1Label";
#endif
                }
                return _viewSwitcherTestAssetManagementTestButton1Label;
            }
        }

        private static Template _viewSwitcherTestAssetManagementTestButton2;
        public static Template ViewSwitcherTestAssetManagementTestButton2
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestAssetManagementTestButton2 == null || _viewSwitcherTestAssetManagementTestButton2.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestAssetManagementTestButton2 == null)
#endif
                {
                    _viewSwitcherTestAssetManagementTestButton2 = new Template(AssetManagementTestTemplates.AssetManagementTestButton2);
#if UNITY_EDITOR
                    _viewSwitcherTestAssetManagementTestButton2.Name = "ViewSwitcherTestAssetManagementTestButton2";
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_viewSwitcherTestAssetManagementTestButton2, ViewSwitcherTestAssetManagementTestButton2Label);
                }
                return _viewSwitcherTestAssetManagementTestButton2;
            }
        }

        private static Template _viewSwitcherTestAssetManagementTestButton2Label;
        public static Template ViewSwitcherTestAssetManagementTestButton2Label
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestAssetManagementTestButton2Label == null || _viewSwitcherTestAssetManagementTestButton2Label.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestAssetManagementTestButton2Label == null)
#endif
                {
                    _viewSwitcherTestAssetManagementTestButton2Label = new Template(AssetManagementTestTemplates.AssetManagementTestButton2Label);
#if UNITY_EDITOR
                    _viewSwitcherTestAssetManagementTestButton2Label.Name = "ViewSwitcherTestAssetManagementTestButton2Label";
#endif
                }
                return _viewSwitcherTestAssetManagementTestButton2Label;
            }
        }

        private static Template _viewSwitcherTestAssetManagementTestImageGroup;
        public static Template ViewSwitcherTestAssetManagementTestImageGroup
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestAssetManagementTestImageGroup == null || _viewSwitcherTestAssetManagementTestImageGroup.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestAssetManagementTestImageGroup == null)
#endif
                {
                    _viewSwitcherTestAssetManagementTestImageGroup = new Template(AssetManagementTestTemplates.AssetManagementTestImageGroup);
#if UNITY_EDITOR
                    _viewSwitcherTestAssetManagementTestImageGroup.Name = "ViewSwitcherTestAssetManagementTestImageGroup";
#endif
                }
                return _viewSwitcherTestAssetManagementTestImageGroup;
            }
        }

        private static Template _viewSwitcherTestAssetManagementTestImageSet1;
        public static Template ViewSwitcherTestAssetManagementTestImageSet1
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestAssetManagementTestImageSet1 == null || _viewSwitcherTestAssetManagementTestImageSet1.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestAssetManagementTestImageSet1 == null)
#endif
                {
                    _viewSwitcherTestAssetManagementTestImageSet1 = new Template(AssetManagementTestTemplates.AssetManagementTestImageSet1);
#if UNITY_EDITOR
                    _viewSwitcherTestAssetManagementTestImageSet1.Name = "ViewSwitcherTestAssetManagementTestImageSet1";
#endif
                }
                return _viewSwitcherTestAssetManagementTestImageSet1;
            }
        }

        private static Template _viewSwitcherTestAssetManagementTestImage1;
        public static Template ViewSwitcherTestAssetManagementTestImage1
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestAssetManagementTestImage1 == null || _viewSwitcherTestAssetManagementTestImage1.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestAssetManagementTestImage1 == null)
#endif
                {
                    _viewSwitcherTestAssetManagementTestImage1 = new Template(AssetManagementTestTemplates.AssetManagementTestImage1);
#if UNITY_EDITOR
                    _viewSwitcherTestAssetManagementTestImage1.Name = "ViewSwitcherTestAssetManagementTestImage1";
#endif
                }
                return _viewSwitcherTestAssetManagementTestImage1;
            }
        }

        private static Template _viewSwitcherTestAssetManagementTestImage2;
        public static Template ViewSwitcherTestAssetManagementTestImage2
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestAssetManagementTestImage2 == null || _viewSwitcherTestAssetManagementTestImage2.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestAssetManagementTestImage2 == null)
#endif
                {
                    _viewSwitcherTestAssetManagementTestImage2 = new Template(AssetManagementTestTemplates.AssetManagementTestImage2);
#if UNITY_EDITOR
                    _viewSwitcherTestAssetManagementTestImage2.Name = "ViewSwitcherTestAssetManagementTestImage2";
#endif
                }
                return _viewSwitcherTestAssetManagementTestImage2;
            }
        }

        private static Template _viewSwitcherTestAssetManagementTestImageSet2;
        public static Template ViewSwitcherTestAssetManagementTestImageSet2
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestAssetManagementTestImageSet2 == null || _viewSwitcherTestAssetManagementTestImageSet2.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestAssetManagementTestImageSet2 == null)
#endif
                {
                    _viewSwitcherTestAssetManagementTestImageSet2 = new Template(AssetManagementTestTemplates.AssetManagementTestImageSet2);
#if UNITY_EDITOR
                    _viewSwitcherTestAssetManagementTestImageSet2.Name = "ViewSwitcherTestAssetManagementTestImageSet2";
#endif
                }
                return _viewSwitcherTestAssetManagementTestImageSet2;
            }
        }

        private static Template _viewSwitcherTestAssetManagementTestImage3;
        public static Template ViewSwitcherTestAssetManagementTestImage3
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestAssetManagementTestImage3 == null || _viewSwitcherTestAssetManagementTestImage3.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestAssetManagementTestImage3 == null)
#endif
                {
                    _viewSwitcherTestAssetManagementTestImage3 = new Template(AssetManagementTestTemplates.AssetManagementTestImage3);
#if UNITY_EDITOR
                    _viewSwitcherTestAssetManagementTestImage3.Name = "ViewSwitcherTestAssetManagementTestImage3";
#endif
                }
                return _viewSwitcherTestAssetManagementTestImage3;
            }
        }

        private static Template _viewSwitcherTestAssetManagementTestImage4;
        public static Template ViewSwitcherTestAssetManagementTestImage4
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestAssetManagementTestImage4 == null || _viewSwitcherTestAssetManagementTestImage4.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestAssetManagementTestImage4 == null)
#endif
                {
                    _viewSwitcherTestAssetManagementTestImage4 = new Template(AssetManagementTestTemplates.AssetManagementTestImage4);
#if UNITY_EDITOR
                    _viewSwitcherTestAssetManagementTestImage4.Name = "ViewSwitcherTestAssetManagementTestImage4";
#endif
                }
                return _viewSwitcherTestAssetManagementTestImage4;
            }
        }

        private static Template _viewSwitcherTestAssetManagementTestImageSet3;
        public static Template ViewSwitcherTestAssetManagementTestImageSet3
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestAssetManagementTestImageSet3 == null || _viewSwitcherTestAssetManagementTestImageSet3.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestAssetManagementTestImageSet3 == null)
#endif
                {
                    _viewSwitcherTestAssetManagementTestImageSet3 = new Template(AssetManagementTestTemplates.AssetManagementTestImageSet3);
#if UNITY_EDITOR
                    _viewSwitcherTestAssetManagementTestImageSet3.Name = "ViewSwitcherTestAssetManagementTestImageSet3";
#endif
                }
                return _viewSwitcherTestAssetManagementTestImageSet3;
            }
        }

        private static Template _viewSwitcherTestAssetManagementTestImage5;
        public static Template ViewSwitcherTestAssetManagementTestImage5
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestAssetManagementTestImage5 == null || _viewSwitcherTestAssetManagementTestImage5.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestAssetManagementTestImage5 == null)
#endif
                {
                    _viewSwitcherTestAssetManagementTestImage5 = new Template(AssetManagementTestTemplates.AssetManagementTestImage5);
#if UNITY_EDITOR
                    _viewSwitcherTestAssetManagementTestImage5.Name = "ViewSwitcherTestAssetManagementTestImage5";
#endif
                }
                return _viewSwitcherTestAssetManagementTestImage5;
            }
        }

        private static Template _viewSwitcherTestAssetManagementTestImage6;
        public static Template ViewSwitcherTestAssetManagementTestImage6
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestAssetManagementTestImage6 == null || _viewSwitcherTestAssetManagementTestImage6.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestAssetManagementTestImage6 == null)
#endif
                {
                    _viewSwitcherTestAssetManagementTestImage6 = new Template(AssetManagementTestTemplates.AssetManagementTestImage6);
#if UNITY_EDITOR
                    _viewSwitcherTestAssetManagementTestImage6.Name = "ViewSwitcherTestAssetManagementTestImage6";
#endif
                }
                return _viewSwitcherTestAssetManagementTestImage6;
            }
        }

        private static Template _viewSwitcherTestAssetManagementTestImageSet4;
        public static Template ViewSwitcherTestAssetManagementTestImageSet4
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestAssetManagementTestImageSet4 == null || _viewSwitcherTestAssetManagementTestImageSet4.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestAssetManagementTestImageSet4 == null)
#endif
                {
                    _viewSwitcherTestAssetManagementTestImageSet4 = new Template(AssetManagementTestTemplates.AssetManagementTestImageSet4);
#if UNITY_EDITOR
                    _viewSwitcherTestAssetManagementTestImageSet4.Name = "ViewSwitcherTestAssetManagementTestImageSet4";
#endif
                }
                return _viewSwitcherTestAssetManagementTestImageSet4;
            }
        }

        private static Template _viewSwitcherTestAssetManagementTestBigSpriteImage;
        public static Template ViewSwitcherTestAssetManagementTestBigSpriteImage
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestAssetManagementTestBigSpriteImage == null || _viewSwitcherTestAssetManagementTestBigSpriteImage.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestAssetManagementTestBigSpriteImage == null)
#endif
                {
                    _viewSwitcherTestAssetManagementTestBigSpriteImage = new Template(AssetManagementTestTemplates.AssetManagementTestBigSpriteImage);
#if UNITY_EDITOR
                    _viewSwitcherTestAssetManagementTestBigSpriteImage.Name = "ViewSwitcherTestAssetManagementTestBigSpriteImage";
#endif
                }
                return _viewSwitcherTestAssetManagementTestBigSpriteImage;
            }
        }

        private static Template _viewSwitcherTestAssetManagementTestLabel4;
        public static Template ViewSwitcherTestAssetManagementTestLabel4
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcherTestAssetManagementTestLabel4 == null || _viewSwitcherTestAssetManagementTestLabel4.CurrentVersion != Template.Version)
#else
                if (_viewSwitcherTestAssetManagementTestLabel4 == null)
#endif
                {
                    _viewSwitcherTestAssetManagementTestLabel4 = new Template(AssetManagementTestTemplates.AssetManagementTestLabel4);
#if UNITY_EDITOR
                    _viewSwitcherTestAssetManagementTestLabel4.Name = "ViewSwitcherTestAssetManagementTestLabel4";
#endif
                }
                return _viewSwitcherTestAssetManagementTestLabel4;
            }
        }

        #endregion
    }

    #endregion
}
