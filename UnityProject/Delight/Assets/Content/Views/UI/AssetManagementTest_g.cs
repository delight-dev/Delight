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
            ImageGroup = new Group(this, Group1, "ImageGroup", ImageGroupTemplate);
            ImageSet1 = new Group(this, ImageGroup, "ImageSet1", ImageSet1Template);
            Image1 = new Image(this, ImageSet1, "Image1", Image1Template);
            Image2 = new Image(this, ImageSet1, "Image2", Image2Template);
            ImageSet2 = new Group(this, ImageGroup, "ImageSet2", ImageSet2Template);
            Image3 = new Image(this, ImageSet2, "Image3", Image3Template);
            Image4 = new Image(this, ImageSet2, "Image4", Image4Template);
            ImageSet3 = new Group(this, ImageGroup, "ImageSet3", ImageSet3Template);
            Image5 = new Image(this, ImageSet3, "Image5", Image5Template);
            Image6 = new Image(this, ImageSet3, "Image6", Image6Template);
            ImageSet4 = new Group(this, ImageGroup, "ImageSet4", ImageSet4Template);
            Image7 = new Image(this, ImageSet4, "Image7", Image7Template);
            Label4 = new Label(this, Group1, "Label4", Label4Template);

            // binding <Label Text="{LoadProgress}">
            Bindings.Add(new Binding(
                new List<string> { "LoadProgress" },
                new List<string> { "Label4", "Text" },
                new List<Func<BindableObject>> { () => this },
                new List<Func<BindableObject>> { () => this, () => Label4 },
                () => Label4.Text = LoadProgress,
                () => { }
            ));
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
            dependencyProperties.Add(LoadProgressProperty);
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
            dependencyProperties.Add(ImageGroupProperty);
            dependencyProperties.Add(ImageGroupTemplateProperty);
            dependencyProperties.Add(ImageSet1Property);
            dependencyProperties.Add(ImageSet1TemplateProperty);
            dependencyProperties.Add(Image1Property);
            dependencyProperties.Add(Image1TemplateProperty);
            dependencyProperties.Add(Image2Property);
            dependencyProperties.Add(Image2TemplateProperty);
            dependencyProperties.Add(ImageSet2Property);
            dependencyProperties.Add(ImageSet2TemplateProperty);
            dependencyProperties.Add(Image3Property);
            dependencyProperties.Add(Image3TemplateProperty);
            dependencyProperties.Add(Image4Property);
            dependencyProperties.Add(Image4TemplateProperty);
            dependencyProperties.Add(ImageSet3Property);
            dependencyProperties.Add(ImageSet3TemplateProperty);
            dependencyProperties.Add(Image5Property);
            dependencyProperties.Add(Image5TemplateProperty);
            dependencyProperties.Add(Image6Property);
            dependencyProperties.Add(Image6TemplateProperty);
            dependencyProperties.Add(ImageSet4Property);
            dependencyProperties.Add(ImageSet4TemplateProperty);
            dependencyProperties.Add(Image7Property);
            dependencyProperties.Add(Image7TemplateProperty);
            dependencyProperties.Add(Label4Property);
            dependencyProperties.Add(Label4TemplateProperty);
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

        public readonly static DependencyProperty<System.String> LoadProgressProperty = new DependencyProperty<System.String>("LoadProgress");
        public System.String LoadProgress
        {
            get { return LoadProgressProperty.GetValue(this); }
            set { LoadProgressProperty.SetValue(this, value); }
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

        public readonly static DependencyProperty<Group> ImageGroupProperty = new DependencyProperty<Group>("ImageGroup");
        public Group ImageGroup
        {
            get { return ImageGroupProperty.GetValue(this); }
            set { ImageGroupProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> ImageGroupTemplateProperty = new DependencyProperty<Template>("ImageGroupTemplate");
        public Template ImageGroupTemplate
        {
            get { return ImageGroupTemplateProperty.GetValue(this); }
            set { ImageGroupTemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Group> ImageSet1Property = new DependencyProperty<Group>("ImageSet1");
        public Group ImageSet1
        {
            get { return ImageSet1Property.GetValue(this); }
            set { ImageSet1Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> ImageSet1TemplateProperty = new DependencyProperty<Template>("ImageSet1Template");
        public Template ImageSet1Template
        {
            get { return ImageSet1TemplateProperty.GetValue(this); }
            set { ImageSet1TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Image> Image1Property = new DependencyProperty<Image>("Image1");
        public Image Image1
        {
            get { return Image1Property.GetValue(this); }
            set { Image1Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Image1TemplateProperty = new DependencyProperty<Template>("Image1Template");
        public Template Image1Template
        {
            get { return Image1TemplateProperty.GetValue(this); }
            set { Image1TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Image> Image2Property = new DependencyProperty<Image>("Image2");
        public Image Image2
        {
            get { return Image2Property.GetValue(this); }
            set { Image2Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Image2TemplateProperty = new DependencyProperty<Template>("Image2Template");
        public Template Image2Template
        {
            get { return Image2TemplateProperty.GetValue(this); }
            set { Image2TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Group> ImageSet2Property = new DependencyProperty<Group>("ImageSet2");
        public Group ImageSet2
        {
            get { return ImageSet2Property.GetValue(this); }
            set { ImageSet2Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> ImageSet2TemplateProperty = new DependencyProperty<Template>("ImageSet2Template");
        public Template ImageSet2Template
        {
            get { return ImageSet2TemplateProperty.GetValue(this); }
            set { ImageSet2TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Image> Image3Property = new DependencyProperty<Image>("Image3");
        public Image Image3
        {
            get { return Image3Property.GetValue(this); }
            set { Image3Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Image3TemplateProperty = new DependencyProperty<Template>("Image3Template");
        public Template Image3Template
        {
            get { return Image3TemplateProperty.GetValue(this); }
            set { Image3TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Image> Image4Property = new DependencyProperty<Image>("Image4");
        public Image Image4
        {
            get { return Image4Property.GetValue(this); }
            set { Image4Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Image4TemplateProperty = new DependencyProperty<Template>("Image4Template");
        public Template Image4Template
        {
            get { return Image4TemplateProperty.GetValue(this); }
            set { Image4TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Group> ImageSet3Property = new DependencyProperty<Group>("ImageSet3");
        public Group ImageSet3
        {
            get { return ImageSet3Property.GetValue(this); }
            set { ImageSet3Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> ImageSet3TemplateProperty = new DependencyProperty<Template>("ImageSet3Template");
        public Template ImageSet3Template
        {
            get { return ImageSet3TemplateProperty.GetValue(this); }
            set { ImageSet3TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Image> Image5Property = new DependencyProperty<Image>("Image5");
        public Image Image5
        {
            get { return Image5Property.GetValue(this); }
            set { Image5Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Image5TemplateProperty = new DependencyProperty<Template>("Image5Template");
        public Template Image5Template
        {
            get { return Image5TemplateProperty.GetValue(this); }
            set { Image5TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Image> Image6Property = new DependencyProperty<Image>("Image6");
        public Image Image6
        {
            get { return Image6Property.GetValue(this); }
            set { Image6Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Image6TemplateProperty = new DependencyProperty<Template>("Image6Template");
        public Template Image6Template
        {
            get { return Image6TemplateProperty.GetValue(this); }
            set { Image6TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Group> ImageSet4Property = new DependencyProperty<Group>("ImageSet4");
        public Group ImageSet4
        {
            get { return ImageSet4Property.GetValue(this); }
            set { ImageSet4Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> ImageSet4TemplateProperty = new DependencyProperty<Template>("ImageSet4Template");
        public Template ImageSet4Template
        {
            get { return ImageSet4TemplateProperty.GetValue(this); }
            set { ImageSet4TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Image> Image7Property = new DependencyProperty<Image>("Image7");
        public Image Image7
        {
            get { return Image7Property.GetValue(this); }
            set { Image7Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Image7TemplateProperty = new DependencyProperty<Template>("Image7Template");
        public Template Image7Template
        {
            get { return Image7TemplateProperty.GetValue(this); }
            set { Image7TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Label> Label4Property = new DependencyProperty<Label>("Label4");
        public Label Label4
        {
            get { return Label4Property.GetValue(this); }
            set { Label4Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Label4TemplateProperty = new DependencyProperty<Template>("Label4Template");
        public Template Label4Template
        {
            get { return Label4TemplateProperty.GetValue(this); }
            set { Label4TemplateProperty.SetValue(this, value); }
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
                    Delight.AssetManagementTest.ImageGroupTemplateProperty.SetDefault(_assetManagementTest, AssetManagementTestImageGroup);
                    Delight.AssetManagementTest.ImageSet1TemplateProperty.SetDefault(_assetManagementTest, AssetManagementTestImageSet1);
                    Delight.AssetManagementTest.Image1TemplateProperty.SetDefault(_assetManagementTest, AssetManagementTestImage1);
                    Delight.AssetManagementTest.Image2TemplateProperty.SetDefault(_assetManagementTest, AssetManagementTestImage2);
                    Delight.AssetManagementTest.ImageSet2TemplateProperty.SetDefault(_assetManagementTest, AssetManagementTestImageSet2);
                    Delight.AssetManagementTest.Image3TemplateProperty.SetDefault(_assetManagementTest, AssetManagementTestImage3);
                    Delight.AssetManagementTest.Image4TemplateProperty.SetDefault(_assetManagementTest, AssetManagementTestImage4);
                    Delight.AssetManagementTest.ImageSet3TemplateProperty.SetDefault(_assetManagementTest, AssetManagementTestImageSet3);
                    Delight.AssetManagementTest.Image5TemplateProperty.SetDefault(_assetManagementTest, AssetManagementTestImage5);
                    Delight.AssetManagementTest.Image6TemplateProperty.SetDefault(_assetManagementTest, AssetManagementTestImage6);
                    Delight.AssetManagementTest.ImageSet4TemplateProperty.SetDefault(_assetManagementTest, AssetManagementTestImageSet4);
                    Delight.AssetManagementTest.Image7TemplateProperty.SetDefault(_assetManagementTest, AssetManagementTestImage7);
                    Delight.AssetManagementTest.Label4TemplateProperty.SetDefault(_assetManagementTest, AssetManagementTestLabel4);
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
                    Delight.Group.OrientationProperty.SetDefault(_assetManagementTestGroup2, Delight.ElementOrientation.Horizontal);
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
                    Delight.Label.TextProperty.SetDefault(_assetManagementTestButton1Label, "Load");
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
                    Delight.Label.TextProperty.SetDefault(_assetManagementTestButton2Label, "Unload");
                }
                return _assetManagementTestButton2Label;
            }
        }

        private static Template _assetManagementTestImageGroup;
        public static Template AssetManagementTestImageGroup
        {
            get
            {
#if UNITY_EDITOR
                if (_assetManagementTestImageGroup == null || _assetManagementTestImageGroup.CurrentVersion != Template.Version)
#else
                if (_assetManagementTestImageGroup == null)
#endif
                {
                    _assetManagementTestImageGroup = new Template(GroupTemplates.Group);
                    Delight.Group.OrientationProperty.SetDefault(_assetManagementTestImageGroup, Delight.ElementOrientation.Horizontal);
                    Delight.Group.SpacingProperty.SetDefault(_assetManagementTestImageGroup, new ElementSize(5f, ElementSizeUnit.Pixels));
                    Delight.Group.LoadModeProperty.SetDefault(_assetManagementTestImageGroup, Delight.LoadMode.Manual);
                }
                return _assetManagementTestImageGroup;
            }
        }

        private static Template _assetManagementTestImageSet1;
        public static Template AssetManagementTestImageSet1
        {
            get
            {
#if UNITY_EDITOR
                if (_assetManagementTestImageSet1 == null || _assetManagementTestImageSet1.CurrentVersion != Template.Version)
#else
                if (_assetManagementTestImageSet1 == null)
#endif
                {
                    _assetManagementTestImageSet1 = new Template(GroupTemplates.Group);
                    Delight.Group.SpacingProperty.SetDefault(_assetManagementTestImageSet1, new ElementSize(5f, ElementSizeUnit.Pixels));
                }
                return _assetManagementTestImageSet1;
            }
        }

        private static Template _assetManagementTestImage1;
        public static Template AssetManagementTestImage1
        {
            get
            {
#if UNITY_EDITOR
                if (_assetManagementTestImage1 == null || _assetManagementTestImage1.CurrentVersion != Template.Version)
#else
                if (_assetManagementTestImage1 == null)
#endif
                {
                    _assetManagementTestImage1 = new Template(ImageTemplates.Image);
                    Delight.Image.SpriteProperty.SetDefault(_assetManagementTestImage1, Assets.Sprites["Frame1"]);
                }
                return _assetManagementTestImage1;
            }
        }

        private static Template _assetManagementTestImage2;
        public static Template AssetManagementTestImage2
        {
            get
            {
#if UNITY_EDITOR
                if (_assetManagementTestImage2 == null || _assetManagementTestImage2.CurrentVersion != Template.Version)
#else
                if (_assetManagementTestImage2 == null)
#endif
                {
                    _assetManagementTestImage2 = new Template(ImageTemplates.Image);
                    Delight.Image.SpriteProperty.SetDefault(_assetManagementTestImage2, Assets.Sprites["Frame2"]);
                }
                return _assetManagementTestImage2;
            }
        }

        private static Template _assetManagementTestImageSet2;
        public static Template AssetManagementTestImageSet2
        {
            get
            {
#if UNITY_EDITOR
                if (_assetManagementTestImageSet2 == null || _assetManagementTestImageSet2.CurrentVersion != Template.Version)
#else
                if (_assetManagementTestImageSet2 == null)
#endif
                {
                    _assetManagementTestImageSet2 = new Template(GroupTemplates.Group);
                    Delight.Group.SpacingProperty.SetDefault(_assetManagementTestImageSet2, new ElementSize(5f, ElementSizeUnit.Pixels));
                }
                return _assetManagementTestImageSet2;
            }
        }

        private static Template _assetManagementTestImage3;
        public static Template AssetManagementTestImage3
        {
            get
            {
#if UNITY_EDITOR
                if (_assetManagementTestImage3 == null || _assetManagementTestImage3.CurrentVersion != Template.Version)
#else
                if (_assetManagementTestImage3 == null)
#endif
                {
                    _assetManagementTestImage3 = new Template(ImageTemplates.Image);
                    Delight.Image.SpriteProperty.SetDefault(_assetManagementTestImage3, Assets.Sprites["Frame3"]);
                }
                return _assetManagementTestImage3;
            }
        }

        private static Template _assetManagementTestImage4;
        public static Template AssetManagementTestImage4
        {
            get
            {
#if UNITY_EDITOR
                if (_assetManagementTestImage4 == null || _assetManagementTestImage4.CurrentVersion != Template.Version)
#else
                if (_assetManagementTestImage4 == null)
#endif
                {
                    _assetManagementTestImage4 = new Template(ImageTemplates.Image);
                    Delight.Image.SpriteProperty.SetDefault(_assetManagementTestImage4, Assets.Sprites["Frame4"]);
                }
                return _assetManagementTestImage4;
            }
        }

        private static Template _assetManagementTestImageSet3;
        public static Template AssetManagementTestImageSet3
        {
            get
            {
#if UNITY_EDITOR
                if (_assetManagementTestImageSet3 == null || _assetManagementTestImageSet3.CurrentVersion != Template.Version)
#else
                if (_assetManagementTestImageSet3 == null)
#endif
                {
                    _assetManagementTestImageSet3 = new Template(GroupTemplates.Group);
                    Delight.Group.SpacingProperty.SetDefault(_assetManagementTestImageSet3, new ElementSize(5f, ElementSizeUnit.Pixels));
                }
                return _assetManagementTestImageSet3;
            }
        }

        private static Template _assetManagementTestImage5;
        public static Template AssetManagementTestImage5
        {
            get
            {
#if UNITY_EDITOR
                if (_assetManagementTestImage5 == null || _assetManagementTestImage5.CurrentVersion != Template.Version)
#else
                if (_assetManagementTestImage5 == null)
#endif
                {
                    _assetManagementTestImage5 = new Template(ImageTemplates.Image);
                    Delight.Image.SpriteProperty.SetDefault(_assetManagementTestImage5, Assets.Sprites["Frame2"]);
                }
                return _assetManagementTestImage5;
            }
        }

        private static Template _assetManagementTestImage6;
        public static Template AssetManagementTestImage6
        {
            get
            {
#if UNITY_EDITOR
                if (_assetManagementTestImage6 == null || _assetManagementTestImage6.CurrentVersion != Template.Version)
#else
                if (_assetManagementTestImage6 == null)
#endif
                {
                    _assetManagementTestImage6 = new Template(ImageTemplates.Image);
                    Delight.Image.SpriteProperty.SetDefault(_assetManagementTestImage6, Assets.Sprites["Frame3"]);
                }
                return _assetManagementTestImage6;
            }
        }

        private static Template _assetManagementTestImageSet4;
        public static Template AssetManagementTestImageSet4
        {
            get
            {
#if UNITY_EDITOR
                if (_assetManagementTestImageSet4 == null || _assetManagementTestImageSet4.CurrentVersion != Template.Version)
#else
                if (_assetManagementTestImageSet4 == null)
#endif
                {
                    _assetManagementTestImageSet4 = new Template(GroupTemplates.Group);
                    Delight.Group.SpacingProperty.SetDefault(_assetManagementTestImageSet4, new ElementSize(5f, ElementSizeUnit.Pixels));
                }
                return _assetManagementTestImageSet4;
            }
        }

        private static Template _assetManagementTestImage7;
        public static Template AssetManagementTestImage7
        {
            get
            {
#if UNITY_EDITOR
                if (_assetManagementTestImage7 == null || _assetManagementTestImage7.CurrentVersion != Template.Version)
#else
                if (_assetManagementTestImage7 == null)
#endif
                {
                    _assetManagementTestImage7 = new Template(ImageTemplates.Image);
                    Delight.Image.SpriteProperty.SetDefault(_assetManagementTestImage7, Assets.Sprites["BigSprite"]);
                    Delight.Image.WidthProperty.SetDefault(_assetManagementTestImage7, new ElementSize(256f, ElementSizeUnit.Pixels));
                    Delight.Image.HeightProperty.SetDefault(_assetManagementTestImage7, new ElementSize(517f, ElementSizeUnit.Pixels));
                }
                return _assetManagementTestImage7;
            }
        }

        private static Template _assetManagementTestLabel4;
        public static Template AssetManagementTestLabel4
        {
            get
            {
#if UNITY_EDITOR
                if (_assetManagementTestLabel4 == null || _assetManagementTestLabel4.CurrentVersion != Template.Version)
#else
                if (_assetManagementTestLabel4 == null)
#endif
                {
                    _assetManagementTestLabel4 = new Template(LabelTemplates.Label);
                    Delight.Label.WidthProperty.SetDefault(_assetManagementTestLabel4, new ElementSize(400f, ElementSizeUnit.Pixels));
                    Delight.Label.AlignmentProperty.SetDefault(_assetManagementTestLabel4, Delight.ElementAlignment.Center);
                    Delight.Label.TextAlignmentProperty.SetDefault(_assetManagementTestLabel4, TMPro.TextAlignmentOptions.Center);
                }
                return _assetManagementTestLabel4;
            }
        }

        #endregion
    }

    #endregion
}
