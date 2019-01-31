// Internal view logic generated from "AssetManagementTest.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class AssetManagementTest : LayoutRoot
    {
        #region Constructors

        public AssetManagementTest(View parent, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :
            base(parent, layoutParent, id, template ?? AssetManagementTestTemplates.Default, initializer)
        {
            // constructing Label (Label1)
            Label1 = new Label(this, this, "Label1", Label1Template);

            // binding <Label Text="{TimeString}">
            Bindings.Add(new Binding(
                new List<string> { "TimeString" },
                new List<string> { "Label1", "Text" },
                new List<Func<BindableObject>> { () => this },
                new List<Func<BindableObject>> { () => this, () => Label1 },
                () => Label1.Text = TimeString,
                () => { }
            ));

            // constructing Label (Label2)
            Label2 = new Label(this, this, "Label2", Label2Template);

            // binding <Label Text="{LoadedAssetsString}">
            Bindings.Add(new Binding(
                new List<string> { "LoadedAssetsString" },
                new List<string> { "Label2", "Text" },
                new List<Func<BindableObject>> { () => this },
                new List<Func<BindableObject>> { () => this, () => Label2 },
                () => Label2.Text = LoadedAssetsString,
                () => { }
            ));

            // constructing Label (Label3)
            Label3 = new Label(this, this, "Label3", Label3Template);

            // binding <Label Text="{LoadedAssetBundlesString}">
            Bindings.Add(new Binding(
                new List<string> { "LoadedAssetBundlesString" },
                new List<string> { "Label3", "Text" },
                new List<Func<BindableObject>> { () => this },
                new List<Func<BindableObject>> { () => this, () => Label3 },
                () => Label3.Text = LoadedAssetBundlesString,
                () => { }
            ));

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
            BigSlowView1 = new BigSlowView(this, Group1, "BigSlowView1", BigSlowView1Template);
            TestImage = new Image(this, Group1, "TestImage", TestImageTemplate);
            this.AfterInitializeInternal();
        }

        public AssetManagementTest() : this(null)
        {
        }

        static AssetManagementTest()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(AssetManagementTestTemplates.Default, dependencyProperties);

            dependencyProperties.Add(TimeStringProperty);
            dependencyProperties.Add(LoadedAssetsStringProperty);
            dependencyProperties.Add(LoadedAssetBundlesStringProperty);
            dependencyProperties.Add(Label1Property);
            dependencyProperties.Add(Label1TemplateProperty);
            dependencyProperties.Add(Label2Property);
            dependencyProperties.Add(Label2TemplateProperty);
            dependencyProperties.Add(Label3Property);
            dependencyProperties.Add(Label3TemplateProperty);
            dependencyProperties.Add(Group1Property);
            dependencyProperties.Add(Group1TemplateProperty);
            dependencyProperties.Add(Group2Property);
            dependencyProperties.Add(Group2TemplateProperty);
            dependencyProperties.Add(Button1Property);
            dependencyProperties.Add(Button1TemplateProperty);
            dependencyProperties.Add(Button2Property);
            dependencyProperties.Add(Button2TemplateProperty);
            dependencyProperties.Add(BigSlowView1Property);
            dependencyProperties.Add(BigSlowView1TemplateProperty);
            dependencyProperties.Add(TestImageProperty);
            dependencyProperties.Add(TestImageTemplateProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<System.String> TimeStringProperty = new DependencyProperty<System.String>("TimeString");
        public System.String TimeString
        {
            get { return TimeStringProperty.GetValue(this); }
            set { TimeStringProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.String> LoadedAssetsStringProperty = new DependencyProperty<System.String>("LoadedAssetsString");
        public System.String LoadedAssetsString
        {
            get { return LoadedAssetsStringProperty.GetValue(this); }
            set { LoadedAssetsStringProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.String> LoadedAssetBundlesStringProperty = new DependencyProperty<System.String>("LoadedAssetBundlesString");
        public System.String LoadedAssetBundlesString
        {
            get { return LoadedAssetBundlesStringProperty.GetValue(this); }
            set { LoadedAssetBundlesStringProperty.SetValue(this, value); }
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

        public readonly static DependencyProperty<Label> Label2Property = new DependencyProperty<Label>("Label2");
        public Label Label2
        {
            get { return Label2Property.GetValue(this); }
            set { Label2Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Label2TemplateProperty = new DependencyProperty<Template>("Label2Template");
        public Template Label2Template
        {
            get { return Label2TemplateProperty.GetValue(this); }
            set { Label2TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Label> Label3Property = new DependencyProperty<Label>("Label3");
        public Label Label3
        {
            get { return Label3Property.GetValue(this); }
            set { Label3Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Label3TemplateProperty = new DependencyProperty<Template>("Label3Template");
        public Template Label3Template
        {
            get { return Label3TemplateProperty.GetValue(this); }
            set { Label3TemplateProperty.SetValue(this, value); }
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

        public readonly static DependencyProperty<BigSlowView> BigSlowView1Property = new DependencyProperty<BigSlowView>("BigSlowView1");
        public BigSlowView BigSlowView1
        {
            get { return BigSlowView1Property.GetValue(this); }
            set { BigSlowView1Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> BigSlowView1TemplateProperty = new DependencyProperty<Template>("BigSlowView1Template");
        public Template BigSlowView1Template
        {
            get { return BigSlowView1TemplateProperty.GetValue(this); }
            set { BigSlowView1TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Image> TestImageProperty = new DependencyProperty<Image>("TestImage");
        public Image TestImage
        {
            get { return TestImageProperty.GetValue(this); }
            set { TestImageProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> TestImageTemplateProperty = new DependencyProperty<Template>("TestImageTemplate");
        public Template TestImageTemplate
        {
            get { return TestImageTemplateProperty.GetValue(this); }
            set { TestImageTemplateProperty.SetValue(this, value); }
        }

        #endregion
    }

    #region Data Templates

    public static class AssetManagementTestTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return AssetManagementTest;
            }
        }

        private static Template _assetManagementTest;
        public static Template AssetManagementTest
        {
            get
            {
#if UNITY_EDITOR
                if (_assetManagementTest == null || _assetManagementTest.CurrentVersion != Template.Version)
#else
                if (_assetManagementTest == null)
#endif
                {
                    _assetManagementTest = new Template(LayoutRootTemplates.LayoutRoot);
                    Delight.AssetManagementTest.Label1TemplateProperty.SetDefault(_assetManagementTest, AssetManagementTestLabel1);
                    Delight.AssetManagementTest.Label2TemplateProperty.SetDefault(_assetManagementTest, AssetManagementTestLabel2);
                    Delight.AssetManagementTest.Label3TemplateProperty.SetDefault(_assetManagementTest, AssetManagementTestLabel3);
                    Delight.AssetManagementTest.Group1TemplateProperty.SetDefault(_assetManagementTest, AssetManagementTestGroup1);
                    Delight.AssetManagementTest.Group2TemplateProperty.SetDefault(_assetManagementTest, AssetManagementTestGroup2);
                    Delight.AssetManagementTest.Button1TemplateProperty.SetDefault(_assetManagementTest, AssetManagementTestButton1);
                    Delight.AssetManagementTest.Button2TemplateProperty.SetDefault(_assetManagementTest, AssetManagementTestButton2);
                    Delight.AssetManagementTest.BigSlowView1TemplateProperty.SetDefault(_assetManagementTest, AssetManagementTestBigSlowView1);
                    Delight.AssetManagementTest.TestImageTemplateProperty.SetDefault(_assetManagementTest, AssetManagementTestTestImage);
                }
                return _assetManagementTest;
            }
        }

        private static Template _assetManagementTestLabel1;
        public static Template AssetManagementTestLabel1
        {
            get
            {
#if UNITY_EDITOR
                if (_assetManagementTestLabel1 == null || _assetManagementTestLabel1.CurrentVersion != Template.Version)
#else
                if (_assetManagementTestLabel1 == null)
#endif
                {
                    _assetManagementTestLabel1 = new Template(LabelTemplates.Label);
                    Delight.Label.WidthProperty.SetDefault(_assetManagementTestLabel1, new ElementSize(400f, ElementSizeUnit.Pixels));
                    Delight.Label.AlignmentProperty.SetDefault(_assetManagementTestLabel1, Delight.ElementAlignment.Top);
                    Delight.Label.TextAlignmentProperty.SetDefault(_assetManagementTestLabel1, TMPro.TextAlignmentOptions.Left);
                }
                return _assetManagementTestLabel1;
            }
        }

        private static Template _assetManagementTestLabel2;
        public static Template AssetManagementTestLabel2
        {
            get
            {
#if UNITY_EDITOR
                if (_assetManagementTestLabel2 == null || _assetManagementTestLabel2.CurrentVersion != Template.Version)
#else
                if (_assetManagementTestLabel2 == null)
#endif
                {
                    _assetManagementTestLabel2 = new Template(LabelTemplates.Label);
                    Delight.Label.WidthProperty.SetDefault(_assetManagementTestLabel2, new ElementSize(400f, ElementSizeUnit.Pixels));
                    Delight.Label.AlignmentProperty.SetDefault(_assetManagementTestLabel2, Delight.ElementAlignment.TopRight);
                    Delight.Label.TextAlignmentProperty.SetDefault(_assetManagementTestLabel2, TMPro.TextAlignmentOptions.TopLeft);
                }
                return _assetManagementTestLabel2;
            }
        }

        private static Template _assetManagementTestLabel3;
        public static Template AssetManagementTestLabel3
        {
            get
            {
#if UNITY_EDITOR
                if (_assetManagementTestLabel3 == null || _assetManagementTestLabel3.CurrentVersion != Template.Version)
#else
                if (_assetManagementTestLabel3 == null)
#endif
                {
                    _assetManagementTestLabel3 = new Template(LabelTemplates.Label);
                    Delight.Label.WidthProperty.SetDefault(_assetManagementTestLabel3, new ElementSize(400f, ElementSizeUnit.Pixels));
                    Delight.Label.AlignmentProperty.SetDefault(_assetManagementTestLabel3, Delight.ElementAlignment.TopLeft);
                    Delight.Label.TextAlignmentProperty.SetDefault(_assetManagementTestLabel3, TMPro.TextAlignmentOptions.TopLeft);
                }
                return _assetManagementTestLabel3;
            }
        }

        private static Template _assetManagementTestGroup1;
        public static Template AssetManagementTestGroup1
        {
            get
            {
#if UNITY_EDITOR
                if (_assetManagementTestGroup1 == null || _assetManagementTestGroup1.CurrentVersion != Template.Version)
#else
                if (_assetManagementTestGroup1 == null)
#endif
                {
                    _assetManagementTestGroup1 = new Template(GroupTemplates.Group);
                    Delight.Group.OrientationProperty.SetDefault(_assetManagementTestGroup1, Delight.ElementOrientation.Horizontal);
                }
                return _assetManagementTestGroup1;
            }
        }

        private static Template _assetManagementTestGroup2;
        public static Template AssetManagementTestGroup2
        {
            get
            {
#if UNITY_EDITOR
                if (_assetManagementTestGroup2 == null || _assetManagementTestGroup2.CurrentVersion != Template.Version)
#else
                if (_assetManagementTestGroup2 == null)
#endif
                {
                    _assetManagementTestGroup2 = new Template(GroupTemplates.Group);
                    Delight.Group.SpacingProperty.SetDefault(_assetManagementTestGroup2, new ElementSize(10f, ElementSizeUnit.Pixels));
                    Delight.Group.WidthProperty.SetDefault(_assetManagementTestGroup2, new ElementSize(500f, ElementSizeUnit.Pixels));
                }
                return _assetManagementTestGroup2;
            }
        }

        private static Template _assetManagementTestButton1;
        public static Template AssetManagementTestButton1
        {
            get
            {
#if UNITY_EDITOR
                if (_assetManagementTestButton1 == null || _assetManagementTestButton1.CurrentVersion != Template.Version)
#else
                if (_assetManagementTestButton1 == null)
#endif
                {
                    _assetManagementTestButton1 = new Template(ButtonTemplates.Button);
                    Delight.Button.LabelTemplateProperty.SetDefault(_assetManagementTestButton1, AssetManagementTestButton1Label);
                }
                return _assetManagementTestButton1;
            }
        }

        private static Template _assetManagementTestButton1Label;
        public static Template AssetManagementTestButton1Label
        {
            get
            {
#if UNITY_EDITOR
                if (_assetManagementTestButton1Label == null || _assetManagementTestButton1Label.CurrentVersion != Template.Version)
#else
                if (_assetManagementTestButton1Label == null)
#endif
                {
                    _assetManagementTestButton1Label = new Template(ButtonTemplates.ButtonLabel);
                    Delight.Label.TextProperty.SetDefault(_assetManagementTestButton1Label, "Test 1");
                }
                return _assetManagementTestButton1Label;
            }
        }

        private static Template _assetManagementTestButton2;
        public static Template AssetManagementTestButton2
        {
            get
            {
#if UNITY_EDITOR
                if (_assetManagementTestButton2 == null || _assetManagementTestButton2.CurrentVersion != Template.Version)
#else
                if (_assetManagementTestButton2 == null)
#endif
                {
                    _assetManagementTestButton2 = new Template(ButtonTemplates.Button);
                    Delight.Button.LabelTemplateProperty.SetDefault(_assetManagementTestButton2, AssetManagementTestButton2Label);
                }
                return _assetManagementTestButton2;
            }
        }

        private static Template _assetManagementTestButton2Label;
        public static Template AssetManagementTestButton2Label
        {
            get
            {
#if UNITY_EDITOR
                if (_assetManagementTestButton2Label == null || _assetManagementTestButton2Label.CurrentVersion != Template.Version)
#else
                if (_assetManagementTestButton2Label == null)
#endif
                {
                    _assetManagementTestButton2Label = new Template(ButtonTemplates.ButtonLabel);
                    Delight.Label.TextProperty.SetDefault(_assetManagementTestButton2Label, "Test 2");
                }
                return _assetManagementTestButton2Label;
            }
        }

        private static Template _assetManagementTestBigSlowView1;
        public static Template AssetManagementTestBigSlowView1
        {
            get
            {
#if UNITY_EDITOR
                if (_assetManagementTestBigSlowView1 == null || _assetManagementTestBigSlowView1.CurrentVersion != Template.Version)
#else
                if (_assetManagementTestBigSlowView1 == null)
#endif
                {
                    _assetManagementTestBigSlowView1 = new Template(BigSlowViewTemplates.BigSlowView);
                    Delight.BigSlowView.LoadModeProperty.SetDefault(_assetManagementTestBigSlowView1, Delight.LoadMode.OnDemand);
                }
                return _assetManagementTestBigSlowView1;
            }
        }

        private static Template _assetManagementTestTestImage;
        public static Template AssetManagementTestTestImage
        {
            get
            {
#if UNITY_EDITOR
                if (_assetManagementTestTestImage == null || _assetManagementTestTestImage.CurrentVersion != Template.Version)
#else
                if (_assetManagementTestTestImage == null)
#endif
                {
                    _assetManagementTestTestImage = new Template(ImageTemplates.Image);
                    Delight.Image.WidthProperty.SetDefault(_assetManagementTestTestImage, new ElementSize(200f, ElementSizeUnit.Pixels));
                    Delight.Image.HeightProperty.SetDefault(_assetManagementTestTestImage, new ElementSize(200f, ElementSizeUnit.Pixels));
                    Delight.Image.BackgroundColorProperty.SetDefault(_assetManagementTestTestImage, new UnityEngine.Color(1f, 1f, 1f, 1f));
                }
                return _assetManagementTestTestImage;
            }
        }

        #endregion
    }

    #endregion
}
