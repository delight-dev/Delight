// Internal view logic generated from "OnDemandLoadingExample.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class OnDemandLoadingExample : LayoutRoot
    {
        #region Constructors

        public OnDemandLoadingExample(View parent, View layoutParent = null, string id = null, Template template = null, bool deferInitialization = false) :
            base(parent, layoutParent, id, template ?? OnDemandLoadingExampleTemplates.Default, deferInitialization)
        {
            if (deferInitialization)
                return;

            // constructing Label (Label1)
            Label1 = new Label(this, this, "Label1", Label1Template);

            // binding <Label Text="{TimeString}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "TimeString" }, new List<Func<object>> { () => this }) }, new BindingPath(new List<string> { "Label1", "Text" }, new List<Func<object>> { () => this, () => Label1 }), () => Label1.Text = TimeString, () => { }, false));

            // constructing Label (Label2)
            Label2 = new Label(this, this, "Label2", Label2Template);

            // binding <Label Text="{LoadedAssetsString}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "LoadedAssetsString" }, new List<Func<object>> { () => this }) }, new BindingPath(new List<string> { "Label2", "Text" }, new List<Func<object>> { () => this, () => Label2 }), () => Label2.Text = LoadedAssetsString, () => { }, false));

            // constructing Label (Label3)
            Label3 = new Label(this, this, "Label3", Label3Template);

            // binding <Label Text="{LoadedAssetBundlesString}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "LoadedAssetBundlesString" }, new List<Func<object>> { () => this }) }, new BindingPath(new List<string> { "Label3", "Text" }, new List<Func<object>> { () => this, () => Label3 }), () => Label3.Text = LoadedAssetBundlesString, () => { }, false));

            // constructing Region (Region1)
            Region1 = new Region(this, this, "Region1", Region1Template);
            Group1 = new Group(this, Region1.Content, "Group1", Group1Template);
            LoadAllButton = new Button(this, Group1.Content, "LoadAllButton", LoadAllButtonTemplate);
            LoadAllButton.Click.RegisterHandler(this, "LoadAll");
            Load1Button = new Button(this, Group1.Content, "Load1Button", Load1ButtonTemplate);
            Load1Button.Click.RegisterHandler(this, "ToggleLoad1");
            Load2Button = new Button(this, Group1.Content, "Load2Button", Load2ButtonTemplate);
            Load2Button.Click.RegisterHandler(this, "ToggleLoad2");
            Load3Button = new Button(this, Group1.Content, "Load3Button", Load3ButtonTemplate);
            Load3Button.Click.RegisterHandler(this, "ToggleLoad3");
            Load4Button = new Button(this, Group1.Content, "Load4Button", Load4ButtonTemplate);
            Load4Button.Click.RegisterHandler(this, "ToggleLoad4");
            Button1 = new Button(this, Group1.Content, "Button1", Button1Template);
            Button1.Click.RegisterHandler(this, "UnloadAll");
            Button2 = new Button(this, Group1.Content, "Button2", Button2Template);
            Button2.Click.RegisterHandler(this, "SetSprite");
            ImageGroup = new Group(this, Region1.Content, "ImageGroup", ImageGroupTemplate);
            ImageSet1 = new Group(this, ImageGroup.Content, "ImageSet1", ImageSet1Template);
            Image1 = new Image(this, ImageSet1.Content, "Image1", Image1Template);
            Image2 = new Image(this, ImageSet1.Content, "Image2", Image2Template);
            ImageSet2 = new Group(this, ImageGroup.Content, "ImageSet2", ImageSet2Template);
            Image3 = new Image(this, ImageSet2.Content, "Image3", Image3Template);
            Image4 = new Image(this, ImageSet2.Content, "Image4", Image4Template);
            ImageSet3 = new Group(this, ImageGroup.Content, "ImageSet3", ImageSet3Template);
            Image5 = new Image(this, ImageSet3.Content, "Image5", Image5Template);
            Image6 = new Image(this, ImageSet3.Content, "Image6", Image6Template);
            ImageSet4 = new Group(this, ImageGroup.Content, "ImageSet4", ImageSet4Template);
            BigSpriteImage = new Image(this, ImageSet4.Content, "BigSpriteImage", BigSpriteImageTemplate);
            Label4 = new Label(this, Region1.Content, "Label4", Label4Template);

            // binding <Label Text="{LoadProgress}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "LoadProgress" }, new List<Func<object>> { () => this }) }, new BindingPath(new List<string> { "Label4", "Text" }, new List<Func<object>> { () => this, () => Label4 }), () => Label4.Text = LoadProgress, () => { }, false));
            this.AfterInitializeInternal();
        }

        public OnDemandLoadingExample() : this(null)
        {
        }

        static OnDemandLoadingExample()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(OnDemandLoadingExampleTemplates.Default, dependencyProperties);

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
            dependencyProperties.Add(Region1Property);
            dependencyProperties.Add(Region1TemplateProperty);
            dependencyProperties.Add(Group1Property);
            dependencyProperties.Add(Group1TemplateProperty);
            dependencyProperties.Add(LoadAllButtonProperty);
            dependencyProperties.Add(LoadAllButtonTemplateProperty);
            dependencyProperties.Add(Load1ButtonProperty);
            dependencyProperties.Add(Load1ButtonTemplateProperty);
            dependencyProperties.Add(Load2ButtonProperty);
            dependencyProperties.Add(Load2ButtonTemplateProperty);
            dependencyProperties.Add(Load3ButtonProperty);
            dependencyProperties.Add(Load3ButtonTemplateProperty);
            dependencyProperties.Add(Load4ButtonProperty);
            dependencyProperties.Add(Load4ButtonTemplateProperty);
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
            dependencyProperties.Add(BigSpriteImageProperty);
            dependencyProperties.Add(BigSpriteImageTemplateProperty);
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

        public readonly static DependencyProperty<Button> LoadAllButtonProperty = new DependencyProperty<Button>("LoadAllButton");
        public Button LoadAllButton
        {
            get { return LoadAllButtonProperty.GetValue(this); }
            set { LoadAllButtonProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> LoadAllButtonTemplateProperty = new DependencyProperty<Template>("LoadAllButtonTemplate");
        public Template LoadAllButtonTemplate
        {
            get { return LoadAllButtonTemplateProperty.GetValue(this); }
            set { LoadAllButtonTemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Button> Load1ButtonProperty = new DependencyProperty<Button>("Load1Button");
        public Button Load1Button
        {
            get { return Load1ButtonProperty.GetValue(this); }
            set { Load1ButtonProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Load1ButtonTemplateProperty = new DependencyProperty<Template>("Load1ButtonTemplate");
        public Template Load1ButtonTemplate
        {
            get { return Load1ButtonTemplateProperty.GetValue(this); }
            set { Load1ButtonTemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Button> Load2ButtonProperty = new DependencyProperty<Button>("Load2Button");
        public Button Load2Button
        {
            get { return Load2ButtonProperty.GetValue(this); }
            set { Load2ButtonProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Load2ButtonTemplateProperty = new DependencyProperty<Template>("Load2ButtonTemplate");
        public Template Load2ButtonTemplate
        {
            get { return Load2ButtonTemplateProperty.GetValue(this); }
            set { Load2ButtonTemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Button> Load3ButtonProperty = new DependencyProperty<Button>("Load3Button");
        public Button Load3Button
        {
            get { return Load3ButtonProperty.GetValue(this); }
            set { Load3ButtonProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Load3ButtonTemplateProperty = new DependencyProperty<Template>("Load3ButtonTemplate");
        public Template Load3ButtonTemplate
        {
            get { return Load3ButtonTemplateProperty.GetValue(this); }
            set { Load3ButtonTemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Button> Load4ButtonProperty = new DependencyProperty<Button>("Load4Button");
        public Button Load4Button
        {
            get { return Load4ButtonProperty.GetValue(this); }
            set { Load4ButtonProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Load4ButtonTemplateProperty = new DependencyProperty<Template>("Load4ButtonTemplate");
        public Template Load4ButtonTemplate
        {
            get { return Load4ButtonTemplateProperty.GetValue(this); }
            set { Load4ButtonTemplateProperty.SetValue(this, value); }
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

        public readonly static DependencyProperty<Image> BigSpriteImageProperty = new DependencyProperty<Image>("BigSpriteImage");
        public Image BigSpriteImage
        {
            get { return BigSpriteImageProperty.GetValue(this); }
            set { BigSpriteImageProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> BigSpriteImageTemplateProperty = new DependencyProperty<Template>("BigSpriteImageTemplate");
        public Template BigSpriteImageTemplate
        {
            get { return BigSpriteImageTemplateProperty.GetValue(this); }
            set { BigSpriteImageTemplateProperty.SetValue(this, value); }
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

    public static class OnDemandLoadingExampleTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return OnDemandLoadingExample;
            }
        }

        private static Template _onDemandLoadingExample;
        public static Template OnDemandLoadingExample
        {
            get
            {
#if UNITY_EDITOR
                if (_onDemandLoadingExample == null || _onDemandLoadingExample.CurrentVersion != Template.Version)
#else
                if (_onDemandLoadingExample == null)
#endif
                {
                    _onDemandLoadingExample = new Template(LayoutRootTemplates.LayoutRoot);
#if UNITY_EDITOR
                    _onDemandLoadingExample.Name = "OnDemandLoadingExample";
                    _onDemandLoadingExample.LineNumber = 0;
                    _onDemandLoadingExample.LinePosition = 0;
#endif
                    Delight.OnDemandLoadingExample.EnableScriptEventsProperty.SetDefault(_onDemandLoadingExample, true);
                    Delight.OnDemandLoadingExample.Label1TemplateProperty.SetDefault(_onDemandLoadingExample, OnDemandLoadingExampleLabel1);
                    Delight.OnDemandLoadingExample.Label2TemplateProperty.SetDefault(_onDemandLoadingExample, OnDemandLoadingExampleLabel2);
                    Delight.OnDemandLoadingExample.Label3TemplateProperty.SetDefault(_onDemandLoadingExample, OnDemandLoadingExampleLabel3);
                    Delight.OnDemandLoadingExample.Region1TemplateProperty.SetDefault(_onDemandLoadingExample, OnDemandLoadingExampleRegion1);
                    Delight.OnDemandLoadingExample.Group1TemplateProperty.SetDefault(_onDemandLoadingExample, OnDemandLoadingExampleGroup1);
                    Delight.OnDemandLoadingExample.LoadAllButtonTemplateProperty.SetDefault(_onDemandLoadingExample, OnDemandLoadingExampleLoadAllButton);
                    Delight.OnDemandLoadingExample.Load1ButtonTemplateProperty.SetDefault(_onDemandLoadingExample, OnDemandLoadingExampleLoad1Button);
                    Delight.OnDemandLoadingExample.Load2ButtonTemplateProperty.SetDefault(_onDemandLoadingExample, OnDemandLoadingExampleLoad2Button);
                    Delight.OnDemandLoadingExample.Load3ButtonTemplateProperty.SetDefault(_onDemandLoadingExample, OnDemandLoadingExampleLoad3Button);
                    Delight.OnDemandLoadingExample.Load4ButtonTemplateProperty.SetDefault(_onDemandLoadingExample, OnDemandLoadingExampleLoad4Button);
                    Delight.OnDemandLoadingExample.Button1TemplateProperty.SetDefault(_onDemandLoadingExample, OnDemandLoadingExampleButton1);
                    Delight.OnDemandLoadingExample.Button2TemplateProperty.SetDefault(_onDemandLoadingExample, OnDemandLoadingExampleButton2);
                    Delight.OnDemandLoadingExample.ImageGroupTemplateProperty.SetDefault(_onDemandLoadingExample, OnDemandLoadingExampleImageGroup);
                    Delight.OnDemandLoadingExample.ImageSet1TemplateProperty.SetDefault(_onDemandLoadingExample, OnDemandLoadingExampleImageSet1);
                    Delight.OnDemandLoadingExample.Image1TemplateProperty.SetDefault(_onDemandLoadingExample, OnDemandLoadingExampleImage1);
                    Delight.OnDemandLoadingExample.Image2TemplateProperty.SetDefault(_onDemandLoadingExample, OnDemandLoadingExampleImage2);
                    Delight.OnDemandLoadingExample.ImageSet2TemplateProperty.SetDefault(_onDemandLoadingExample, OnDemandLoadingExampleImageSet2);
                    Delight.OnDemandLoadingExample.Image3TemplateProperty.SetDefault(_onDemandLoadingExample, OnDemandLoadingExampleImage3);
                    Delight.OnDemandLoadingExample.Image4TemplateProperty.SetDefault(_onDemandLoadingExample, OnDemandLoadingExampleImage4);
                    Delight.OnDemandLoadingExample.ImageSet3TemplateProperty.SetDefault(_onDemandLoadingExample, OnDemandLoadingExampleImageSet3);
                    Delight.OnDemandLoadingExample.Image5TemplateProperty.SetDefault(_onDemandLoadingExample, OnDemandLoadingExampleImage5);
                    Delight.OnDemandLoadingExample.Image6TemplateProperty.SetDefault(_onDemandLoadingExample, OnDemandLoadingExampleImage6);
                    Delight.OnDemandLoadingExample.ImageSet4TemplateProperty.SetDefault(_onDemandLoadingExample, OnDemandLoadingExampleImageSet4);
                    Delight.OnDemandLoadingExample.BigSpriteImageTemplateProperty.SetDefault(_onDemandLoadingExample, OnDemandLoadingExampleBigSpriteImage);
                    Delight.OnDemandLoadingExample.Label4TemplateProperty.SetDefault(_onDemandLoadingExample, OnDemandLoadingExampleLabel4);
                }
                return _onDemandLoadingExample;
            }
        }

        private static Template _onDemandLoadingExampleLabel1;
        public static Template OnDemandLoadingExampleLabel1
        {
            get
            {
#if UNITY_EDITOR
                if (_onDemandLoadingExampleLabel1 == null || _onDemandLoadingExampleLabel1.CurrentVersion != Template.Version)
#else
                if (_onDemandLoadingExampleLabel1 == null)
#endif
                {
                    _onDemandLoadingExampleLabel1 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _onDemandLoadingExampleLabel1.Name = "OnDemandLoadingExampleLabel1";
                    _onDemandLoadingExampleLabel1.LineNumber = 5;
                    _onDemandLoadingExampleLabel1.LinePosition = 4;
#endif
                    Delight.Label.WidthProperty.SetDefault(_onDemandLoadingExampleLabel1, new ElementSize(400f, ElementSizeUnit.Pixels));
                    Delight.Label.AlignmentProperty.SetDefault(_onDemandLoadingExampleLabel1, Delight.ElementAlignment.Top);
                    Delight.Label.TextAlignmentProperty.SetDefault(_onDemandLoadingExampleLabel1, TMPro.TextAlignmentOptions.Left);
                    Delight.Label.TextProperty.SetHasBinding(_onDemandLoadingExampleLabel1);
                }
                return _onDemandLoadingExampleLabel1;
            }
        }

        private static Template _onDemandLoadingExampleLabel2;
        public static Template OnDemandLoadingExampleLabel2
        {
            get
            {
#if UNITY_EDITOR
                if (_onDemandLoadingExampleLabel2 == null || _onDemandLoadingExampleLabel2.CurrentVersion != Template.Version)
#else
                if (_onDemandLoadingExampleLabel2 == null)
#endif
                {
                    _onDemandLoadingExampleLabel2 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _onDemandLoadingExampleLabel2.Name = "OnDemandLoadingExampleLabel2";
                    _onDemandLoadingExampleLabel2.LineNumber = 6;
                    _onDemandLoadingExampleLabel2.LinePosition = 4;
#endif
                    Delight.Label.WidthProperty.SetDefault(_onDemandLoadingExampleLabel2, new ElementSize(400f, ElementSizeUnit.Pixels));
                    Delight.Label.AlignmentProperty.SetDefault(_onDemandLoadingExampleLabel2, Delight.ElementAlignment.TopRight);
                    Delight.Label.TextAlignmentProperty.SetDefault(_onDemandLoadingExampleLabel2, TMPro.TextAlignmentOptions.TopLeft);
                    Delight.Label.TextProperty.SetHasBinding(_onDemandLoadingExampleLabel2);
                }
                return _onDemandLoadingExampleLabel2;
            }
        }

        private static Template _onDemandLoadingExampleLabel3;
        public static Template OnDemandLoadingExampleLabel3
        {
            get
            {
#if UNITY_EDITOR
                if (_onDemandLoadingExampleLabel3 == null || _onDemandLoadingExampleLabel3.CurrentVersion != Template.Version)
#else
                if (_onDemandLoadingExampleLabel3 == null)
#endif
                {
                    _onDemandLoadingExampleLabel3 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _onDemandLoadingExampleLabel3.Name = "OnDemandLoadingExampleLabel3";
                    _onDemandLoadingExampleLabel3.LineNumber = 7;
                    _onDemandLoadingExampleLabel3.LinePosition = 4;
#endif
                    Delight.Label.WidthProperty.SetDefault(_onDemandLoadingExampleLabel3, new ElementSize(400f, ElementSizeUnit.Pixels));
                    Delight.Label.AlignmentProperty.SetDefault(_onDemandLoadingExampleLabel3, Delight.ElementAlignment.TopLeft);
                    Delight.Label.TextAlignmentProperty.SetDefault(_onDemandLoadingExampleLabel3, TMPro.TextAlignmentOptions.TopLeft);
                    Delight.Label.TextProperty.SetHasBinding(_onDemandLoadingExampleLabel3);
                }
                return _onDemandLoadingExampleLabel3;
            }
        }

        private static Template _onDemandLoadingExampleRegion1;
        public static Template OnDemandLoadingExampleRegion1
        {
            get
            {
#if UNITY_EDITOR
                if (_onDemandLoadingExampleRegion1 == null || _onDemandLoadingExampleRegion1.CurrentVersion != Template.Version)
#else
                if (_onDemandLoadingExampleRegion1 == null)
#endif
                {
                    _onDemandLoadingExampleRegion1 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _onDemandLoadingExampleRegion1.Name = "OnDemandLoadingExampleRegion1";
                    _onDemandLoadingExampleRegion1.LineNumber = 9;
                    _onDemandLoadingExampleRegion1.LinePosition = 4;
#endif
                }
                return _onDemandLoadingExampleRegion1;
            }
        }

        private static Template _onDemandLoadingExampleGroup1;
        public static Template OnDemandLoadingExampleGroup1
        {
            get
            {
#if UNITY_EDITOR
                if (_onDemandLoadingExampleGroup1 == null || _onDemandLoadingExampleGroup1.CurrentVersion != Template.Version)
#else
                if (_onDemandLoadingExampleGroup1 == null)
#endif
                {
                    _onDemandLoadingExampleGroup1 = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _onDemandLoadingExampleGroup1.Name = "OnDemandLoadingExampleGroup1";
                    _onDemandLoadingExampleGroup1.LineNumber = 10;
                    _onDemandLoadingExampleGroup1.LinePosition = 6;
#endif
                    Delight.Group.SpacingProperty.SetDefault(_onDemandLoadingExampleGroup1, new ElementSize(5f, ElementSizeUnit.Pixels));
                    Delight.Group.OrientationProperty.SetDefault(_onDemandLoadingExampleGroup1, Delight.ElementOrientation.Vertical);
                    Delight.Group.AlignmentProperty.SetDefault(_onDemandLoadingExampleGroup1, Delight.ElementAlignment.TopLeft);
                    Delight.Group.OffsetProperty.SetDefault(_onDemandLoadingExampleGroup1, new ElementMargin(new ElementSize(20f, ElementSizeUnit.Pixels), new ElementSize(100f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels)));
                }
                return _onDemandLoadingExampleGroup1;
            }
        }

        private static Template _onDemandLoadingExampleLoadAllButton;
        public static Template OnDemandLoadingExampleLoadAllButton
        {
            get
            {
#if UNITY_EDITOR
                if (_onDemandLoadingExampleLoadAllButton == null || _onDemandLoadingExampleLoadAllButton.CurrentVersion != Template.Version)
#else
                if (_onDemandLoadingExampleLoadAllButton == null)
#endif
                {
                    _onDemandLoadingExampleLoadAllButton = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _onDemandLoadingExampleLoadAllButton.Name = "OnDemandLoadingExampleLoadAllButton";
                    _onDemandLoadingExampleLoadAllButton.LineNumber = 11;
                    _onDemandLoadingExampleLoadAllButton.LinePosition = 8;
#endif
                    Delight.Button.WidthProperty.SetDefault(_onDemandLoadingExampleLoadAllButton, new ElementSize(200f, ElementSizeUnit.Pixels));
                    Delight.Button.LabelTemplateProperty.SetDefault(_onDemandLoadingExampleLoadAllButton, OnDemandLoadingExampleLoadAllButtonLabel);
                }
                return _onDemandLoadingExampleLoadAllButton;
            }
        }

        private static Template _onDemandLoadingExampleLoadAllButtonLabel;
        public static Template OnDemandLoadingExampleLoadAllButtonLabel
        {
            get
            {
#if UNITY_EDITOR
                if (_onDemandLoadingExampleLoadAllButtonLabel == null || _onDemandLoadingExampleLoadAllButtonLabel.CurrentVersion != Template.Version)
#else
                if (_onDemandLoadingExampleLoadAllButtonLabel == null)
#endif
                {
                    _onDemandLoadingExampleLoadAllButtonLabel = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _onDemandLoadingExampleLoadAllButtonLabel.Name = "OnDemandLoadingExampleLoadAllButtonLabel";
                    _onDemandLoadingExampleLoadAllButtonLabel.LineNumber = 15;
                    _onDemandLoadingExampleLoadAllButtonLabel.LinePosition = 4;
#endif
                    Delight.Label.TextProperty.SetDefault(_onDemandLoadingExampleLoadAllButtonLabel, "LoadAll");
                }
                return _onDemandLoadingExampleLoadAllButtonLabel;
            }
        }

        private static Template _onDemandLoadingExampleLoad1Button;
        public static Template OnDemandLoadingExampleLoad1Button
        {
            get
            {
#if UNITY_EDITOR
                if (_onDemandLoadingExampleLoad1Button == null || _onDemandLoadingExampleLoad1Button.CurrentVersion != Template.Version)
#else
                if (_onDemandLoadingExampleLoad1Button == null)
#endif
                {
                    _onDemandLoadingExampleLoad1Button = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _onDemandLoadingExampleLoad1Button.Name = "OnDemandLoadingExampleLoad1Button";
                    _onDemandLoadingExampleLoad1Button.LineNumber = 12;
                    _onDemandLoadingExampleLoad1Button.LinePosition = 8;
#endif
                    Delight.Button.WidthProperty.SetDefault(_onDemandLoadingExampleLoad1Button, new ElementSize(200f, ElementSizeUnit.Pixels));
                    Delight.Button.LabelTemplateProperty.SetDefault(_onDemandLoadingExampleLoad1Button, OnDemandLoadingExampleLoad1ButtonLabel);
                }
                return _onDemandLoadingExampleLoad1Button;
            }
        }

        private static Template _onDemandLoadingExampleLoad1ButtonLabel;
        public static Template OnDemandLoadingExampleLoad1ButtonLabel
        {
            get
            {
#if UNITY_EDITOR
                if (_onDemandLoadingExampleLoad1ButtonLabel == null || _onDemandLoadingExampleLoad1ButtonLabel.CurrentVersion != Template.Version)
#else
                if (_onDemandLoadingExampleLoad1ButtonLabel == null)
#endif
                {
                    _onDemandLoadingExampleLoad1ButtonLabel = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _onDemandLoadingExampleLoad1ButtonLabel.Name = "OnDemandLoadingExampleLoad1ButtonLabel";
                    _onDemandLoadingExampleLoad1ButtonLabel.LineNumber = 15;
                    _onDemandLoadingExampleLoad1ButtonLabel.LinePosition = 4;
#endif
                    Delight.Label.TextProperty.SetDefault(_onDemandLoadingExampleLoad1ButtonLabel, "Load Set 1");
                }
                return _onDemandLoadingExampleLoad1ButtonLabel;
            }
        }

        private static Template _onDemandLoadingExampleLoad2Button;
        public static Template OnDemandLoadingExampleLoad2Button
        {
            get
            {
#if UNITY_EDITOR
                if (_onDemandLoadingExampleLoad2Button == null || _onDemandLoadingExampleLoad2Button.CurrentVersion != Template.Version)
#else
                if (_onDemandLoadingExampleLoad2Button == null)
#endif
                {
                    _onDemandLoadingExampleLoad2Button = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _onDemandLoadingExampleLoad2Button.Name = "OnDemandLoadingExampleLoad2Button";
                    _onDemandLoadingExampleLoad2Button.LineNumber = 13;
                    _onDemandLoadingExampleLoad2Button.LinePosition = 8;
#endif
                    Delight.Button.WidthProperty.SetDefault(_onDemandLoadingExampleLoad2Button, new ElementSize(200f, ElementSizeUnit.Pixels));
                    Delight.Button.LabelTemplateProperty.SetDefault(_onDemandLoadingExampleLoad2Button, OnDemandLoadingExampleLoad2ButtonLabel);
                }
                return _onDemandLoadingExampleLoad2Button;
            }
        }

        private static Template _onDemandLoadingExampleLoad2ButtonLabel;
        public static Template OnDemandLoadingExampleLoad2ButtonLabel
        {
            get
            {
#if UNITY_EDITOR
                if (_onDemandLoadingExampleLoad2ButtonLabel == null || _onDemandLoadingExampleLoad2ButtonLabel.CurrentVersion != Template.Version)
#else
                if (_onDemandLoadingExampleLoad2ButtonLabel == null)
#endif
                {
                    _onDemandLoadingExampleLoad2ButtonLabel = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _onDemandLoadingExampleLoad2ButtonLabel.Name = "OnDemandLoadingExampleLoad2ButtonLabel";
                    _onDemandLoadingExampleLoad2ButtonLabel.LineNumber = 15;
                    _onDemandLoadingExampleLoad2ButtonLabel.LinePosition = 4;
#endif
                    Delight.Label.TextProperty.SetDefault(_onDemandLoadingExampleLoad2ButtonLabel, "Load Set 2");
                }
                return _onDemandLoadingExampleLoad2ButtonLabel;
            }
        }

        private static Template _onDemandLoadingExampleLoad3Button;
        public static Template OnDemandLoadingExampleLoad3Button
        {
            get
            {
#if UNITY_EDITOR
                if (_onDemandLoadingExampleLoad3Button == null || _onDemandLoadingExampleLoad3Button.CurrentVersion != Template.Version)
#else
                if (_onDemandLoadingExampleLoad3Button == null)
#endif
                {
                    _onDemandLoadingExampleLoad3Button = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _onDemandLoadingExampleLoad3Button.Name = "OnDemandLoadingExampleLoad3Button";
                    _onDemandLoadingExampleLoad3Button.LineNumber = 14;
                    _onDemandLoadingExampleLoad3Button.LinePosition = 8;
#endif
                    Delight.Button.WidthProperty.SetDefault(_onDemandLoadingExampleLoad3Button, new ElementSize(200f, ElementSizeUnit.Pixels));
                    Delight.Button.LabelTemplateProperty.SetDefault(_onDemandLoadingExampleLoad3Button, OnDemandLoadingExampleLoad3ButtonLabel);
                }
                return _onDemandLoadingExampleLoad3Button;
            }
        }

        private static Template _onDemandLoadingExampleLoad3ButtonLabel;
        public static Template OnDemandLoadingExampleLoad3ButtonLabel
        {
            get
            {
#if UNITY_EDITOR
                if (_onDemandLoadingExampleLoad3ButtonLabel == null || _onDemandLoadingExampleLoad3ButtonLabel.CurrentVersion != Template.Version)
#else
                if (_onDemandLoadingExampleLoad3ButtonLabel == null)
#endif
                {
                    _onDemandLoadingExampleLoad3ButtonLabel = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _onDemandLoadingExampleLoad3ButtonLabel.Name = "OnDemandLoadingExampleLoad3ButtonLabel";
                    _onDemandLoadingExampleLoad3ButtonLabel.LineNumber = 15;
                    _onDemandLoadingExampleLoad3ButtonLabel.LinePosition = 4;
#endif
                    Delight.Label.TextProperty.SetDefault(_onDemandLoadingExampleLoad3ButtonLabel, "Load Set 3");
                }
                return _onDemandLoadingExampleLoad3ButtonLabel;
            }
        }

        private static Template _onDemandLoadingExampleLoad4Button;
        public static Template OnDemandLoadingExampleLoad4Button
        {
            get
            {
#if UNITY_EDITOR
                if (_onDemandLoadingExampleLoad4Button == null || _onDemandLoadingExampleLoad4Button.CurrentVersion != Template.Version)
#else
                if (_onDemandLoadingExampleLoad4Button == null)
#endif
                {
                    _onDemandLoadingExampleLoad4Button = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _onDemandLoadingExampleLoad4Button.Name = "OnDemandLoadingExampleLoad4Button";
                    _onDemandLoadingExampleLoad4Button.LineNumber = 15;
                    _onDemandLoadingExampleLoad4Button.LinePosition = 8;
#endif
                    Delight.Button.WidthProperty.SetDefault(_onDemandLoadingExampleLoad4Button, new ElementSize(200f, ElementSizeUnit.Pixels));
                    Delight.Button.LabelTemplateProperty.SetDefault(_onDemandLoadingExampleLoad4Button, OnDemandLoadingExampleLoad4ButtonLabel);
                }
                return _onDemandLoadingExampleLoad4Button;
            }
        }

        private static Template _onDemandLoadingExampleLoad4ButtonLabel;
        public static Template OnDemandLoadingExampleLoad4ButtonLabel
        {
            get
            {
#if UNITY_EDITOR
                if (_onDemandLoadingExampleLoad4ButtonLabel == null || _onDemandLoadingExampleLoad4ButtonLabel.CurrentVersion != Template.Version)
#else
                if (_onDemandLoadingExampleLoad4ButtonLabel == null)
#endif
                {
                    _onDemandLoadingExampleLoad4ButtonLabel = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _onDemandLoadingExampleLoad4ButtonLabel.Name = "OnDemandLoadingExampleLoad4ButtonLabel";
                    _onDemandLoadingExampleLoad4ButtonLabel.LineNumber = 15;
                    _onDemandLoadingExampleLoad4ButtonLabel.LinePosition = 4;
#endif
                    Delight.Label.TextProperty.SetDefault(_onDemandLoadingExampleLoad4ButtonLabel, "Load Set 4");
                }
                return _onDemandLoadingExampleLoad4ButtonLabel;
            }
        }

        private static Template _onDemandLoadingExampleButton1;
        public static Template OnDemandLoadingExampleButton1
        {
            get
            {
#if UNITY_EDITOR
                if (_onDemandLoadingExampleButton1 == null || _onDemandLoadingExampleButton1.CurrentVersion != Template.Version)
#else
                if (_onDemandLoadingExampleButton1 == null)
#endif
                {
                    _onDemandLoadingExampleButton1 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _onDemandLoadingExampleButton1.Name = "OnDemandLoadingExampleButton1";
                    _onDemandLoadingExampleButton1.LineNumber = 16;
                    _onDemandLoadingExampleButton1.LinePosition = 8;
#endif
                    Delight.Button.WidthProperty.SetDefault(_onDemandLoadingExampleButton1, new ElementSize(200f, ElementSizeUnit.Pixels));
                    Delight.Button.LabelTemplateProperty.SetDefault(_onDemandLoadingExampleButton1, OnDemandLoadingExampleButton1Label);
                }
                return _onDemandLoadingExampleButton1;
            }
        }

        private static Template _onDemandLoadingExampleButton1Label;
        public static Template OnDemandLoadingExampleButton1Label
        {
            get
            {
#if UNITY_EDITOR
                if (_onDemandLoadingExampleButton1Label == null || _onDemandLoadingExampleButton1Label.CurrentVersion != Template.Version)
#else
                if (_onDemandLoadingExampleButton1Label == null)
#endif
                {
                    _onDemandLoadingExampleButton1Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _onDemandLoadingExampleButton1Label.Name = "OnDemandLoadingExampleButton1Label";
                    _onDemandLoadingExampleButton1Label.LineNumber = 15;
                    _onDemandLoadingExampleButton1Label.LinePosition = 4;
#endif
                    Delight.Label.TextProperty.SetDefault(_onDemandLoadingExampleButton1Label, "UnloadAll");
                }
                return _onDemandLoadingExampleButton1Label;
            }
        }

        private static Template _onDemandLoadingExampleButton2;
        public static Template OnDemandLoadingExampleButton2
        {
            get
            {
#if UNITY_EDITOR
                if (_onDemandLoadingExampleButton2 == null || _onDemandLoadingExampleButton2.CurrentVersion != Template.Version)
#else
                if (_onDemandLoadingExampleButton2 == null)
#endif
                {
                    _onDemandLoadingExampleButton2 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _onDemandLoadingExampleButton2.Name = "OnDemandLoadingExampleButton2";
                    _onDemandLoadingExampleButton2.LineNumber = 17;
                    _onDemandLoadingExampleButton2.LinePosition = 8;
#endif
                    Delight.Button.WidthProperty.SetDefault(_onDemandLoadingExampleButton2, new ElementSize(200f, ElementSizeUnit.Pixels));
                    Delight.Button.LabelTemplateProperty.SetDefault(_onDemandLoadingExampleButton2, OnDemandLoadingExampleButton2Label);
                }
                return _onDemandLoadingExampleButton2;
            }
        }

        private static Template _onDemandLoadingExampleButton2Label;
        public static Template OnDemandLoadingExampleButton2Label
        {
            get
            {
#if UNITY_EDITOR
                if (_onDemandLoadingExampleButton2Label == null || _onDemandLoadingExampleButton2Label.CurrentVersion != Template.Version)
#else
                if (_onDemandLoadingExampleButton2Label == null)
#endif
                {
                    _onDemandLoadingExampleButton2Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _onDemandLoadingExampleButton2Label.Name = "OnDemandLoadingExampleButton2Label";
                    _onDemandLoadingExampleButton2Label.LineNumber = 15;
                    _onDemandLoadingExampleButton2Label.LinePosition = 4;
#endif
                    Delight.Label.TextProperty.SetDefault(_onDemandLoadingExampleButton2Label, "SetSprite");
                }
                return _onDemandLoadingExampleButton2Label;
            }
        }

        private static Template _onDemandLoadingExampleImageGroup;
        public static Template OnDemandLoadingExampleImageGroup
        {
            get
            {
#if UNITY_EDITOR
                if (_onDemandLoadingExampleImageGroup == null || _onDemandLoadingExampleImageGroup.CurrentVersion != Template.Version)
#else
                if (_onDemandLoadingExampleImageGroup == null)
#endif
                {
                    _onDemandLoadingExampleImageGroup = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _onDemandLoadingExampleImageGroup.Name = "OnDemandLoadingExampleImageGroup";
                    _onDemandLoadingExampleImageGroup.LineNumber = 21;
                    _onDemandLoadingExampleImageGroup.LinePosition = 6;
#endif
                    Delight.Group.OrientationProperty.SetDefault(_onDemandLoadingExampleImageGroup, Delight.ElementOrientation.Horizontal);
                    Delight.Group.SpacingProperty.SetDefault(_onDemandLoadingExampleImageGroup, new ElementSize(5f, ElementSizeUnit.Pixels));
                }
                return _onDemandLoadingExampleImageGroup;
            }
        }

        private static Template _onDemandLoadingExampleImageSet1;
        public static Template OnDemandLoadingExampleImageSet1
        {
            get
            {
#if UNITY_EDITOR
                if (_onDemandLoadingExampleImageSet1 == null || _onDemandLoadingExampleImageSet1.CurrentVersion != Template.Version)
#else
                if (_onDemandLoadingExampleImageSet1 == null)
#endif
                {
                    _onDemandLoadingExampleImageSet1 = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _onDemandLoadingExampleImageSet1.Name = "OnDemandLoadingExampleImageSet1";
                    _onDemandLoadingExampleImageSet1.LineNumber = 22;
                    _onDemandLoadingExampleImageSet1.LinePosition = 8;
#endif
                    Delight.Group.SpacingProperty.SetDefault(_onDemandLoadingExampleImageSet1, new ElementSize(5f, ElementSizeUnit.Pixels));
                    Delight.Group.LoadModeProperty.SetDefault(_onDemandLoadingExampleImageSet1, Delight.LoadMode.Manual);
                }
                return _onDemandLoadingExampleImageSet1;
            }
        }

        private static Template _onDemandLoadingExampleImage1;
        public static Template OnDemandLoadingExampleImage1
        {
            get
            {
#if UNITY_EDITOR
                if (_onDemandLoadingExampleImage1 == null || _onDemandLoadingExampleImage1.CurrentVersion != Template.Version)
#else
                if (_onDemandLoadingExampleImage1 == null)
#endif
                {
                    _onDemandLoadingExampleImage1 = new Template(ImageTemplates.Image);
#if UNITY_EDITOR
                    _onDemandLoadingExampleImage1.Name = "OnDemandLoadingExampleImage1";
                    _onDemandLoadingExampleImage1.LineNumber = 23;
                    _onDemandLoadingExampleImage1.LinePosition = 10;
#endif
                    Delight.Image.SpriteProperty.SetDefault(_onDemandLoadingExampleImage1, Assets.Sprites["Frame1"]);
                    Delight.Image.WidthProperty.SetDefault(_onDemandLoadingExampleImage1, new ElementSize(100f, ElementSizeUnit.Pixels));
                    Delight.Image.HeightProperty.SetDefault(_onDemandLoadingExampleImage1, new ElementSize(100f, ElementSizeUnit.Pixels));
                }
                return _onDemandLoadingExampleImage1;
            }
        }

        private static Template _onDemandLoadingExampleImage2;
        public static Template OnDemandLoadingExampleImage2
        {
            get
            {
#if UNITY_EDITOR
                if (_onDemandLoadingExampleImage2 == null || _onDemandLoadingExampleImage2.CurrentVersion != Template.Version)
#else
                if (_onDemandLoadingExampleImage2 == null)
#endif
                {
                    _onDemandLoadingExampleImage2 = new Template(ImageTemplates.Image);
#if UNITY_EDITOR
                    _onDemandLoadingExampleImage2.Name = "OnDemandLoadingExampleImage2";
                    _onDemandLoadingExampleImage2.LineNumber = 24;
                    _onDemandLoadingExampleImage2.LinePosition = 10;
#endif
                    Delight.Image.SpriteProperty.SetDefault(_onDemandLoadingExampleImage2, Assets.Sprites["Frame2"]);
                    Delight.Image.WidthProperty.SetDefault(_onDemandLoadingExampleImage2, new ElementSize(100f, ElementSizeUnit.Pixels));
                    Delight.Image.HeightProperty.SetDefault(_onDemandLoadingExampleImage2, new ElementSize(100f, ElementSizeUnit.Pixels));
                }
                return _onDemandLoadingExampleImage2;
            }
        }

        private static Template _onDemandLoadingExampleImageSet2;
        public static Template OnDemandLoadingExampleImageSet2
        {
            get
            {
#if UNITY_EDITOR
                if (_onDemandLoadingExampleImageSet2 == null || _onDemandLoadingExampleImageSet2.CurrentVersion != Template.Version)
#else
                if (_onDemandLoadingExampleImageSet2 == null)
#endif
                {
                    _onDemandLoadingExampleImageSet2 = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _onDemandLoadingExampleImageSet2.Name = "OnDemandLoadingExampleImageSet2";
                    _onDemandLoadingExampleImageSet2.LineNumber = 26;
                    _onDemandLoadingExampleImageSet2.LinePosition = 8;
#endif
                    Delight.Group.SpacingProperty.SetDefault(_onDemandLoadingExampleImageSet2, new ElementSize(5f, ElementSizeUnit.Pixels));
                    Delight.Group.LoadModeProperty.SetDefault(_onDemandLoadingExampleImageSet2, Delight.LoadMode.Manual);
                }
                return _onDemandLoadingExampleImageSet2;
            }
        }

        private static Template _onDemandLoadingExampleImage3;
        public static Template OnDemandLoadingExampleImage3
        {
            get
            {
#if UNITY_EDITOR
                if (_onDemandLoadingExampleImage3 == null || _onDemandLoadingExampleImage3.CurrentVersion != Template.Version)
#else
                if (_onDemandLoadingExampleImage3 == null)
#endif
                {
                    _onDemandLoadingExampleImage3 = new Template(ImageTemplates.Image);
#if UNITY_EDITOR
                    _onDemandLoadingExampleImage3.Name = "OnDemandLoadingExampleImage3";
                    _onDemandLoadingExampleImage3.LineNumber = 27;
                    _onDemandLoadingExampleImage3.LinePosition = 10;
#endif
                    Delight.Image.SpriteProperty.SetDefault(_onDemandLoadingExampleImage3, Assets.Sprites["Frame3"]);
                    Delight.Image.WidthProperty.SetDefault(_onDemandLoadingExampleImage3, new ElementSize(100f, ElementSizeUnit.Pixels));
                    Delight.Image.HeightProperty.SetDefault(_onDemandLoadingExampleImage3, new ElementSize(100f, ElementSizeUnit.Pixels));
                }
                return _onDemandLoadingExampleImage3;
            }
        }

        private static Template _onDemandLoadingExampleImage4;
        public static Template OnDemandLoadingExampleImage4
        {
            get
            {
#if UNITY_EDITOR
                if (_onDemandLoadingExampleImage4 == null || _onDemandLoadingExampleImage4.CurrentVersion != Template.Version)
#else
                if (_onDemandLoadingExampleImage4 == null)
#endif
                {
                    _onDemandLoadingExampleImage4 = new Template(ImageTemplates.Image);
#if UNITY_EDITOR
                    _onDemandLoadingExampleImage4.Name = "OnDemandLoadingExampleImage4";
                    _onDemandLoadingExampleImage4.LineNumber = 28;
                    _onDemandLoadingExampleImage4.LinePosition = 10;
#endif
                    Delight.Image.SpriteProperty.SetDefault(_onDemandLoadingExampleImage4, Assets.Sprites["Frame4"]);
                    Delight.Image.WidthProperty.SetDefault(_onDemandLoadingExampleImage4, new ElementSize(100f, ElementSizeUnit.Pixels));
                    Delight.Image.HeightProperty.SetDefault(_onDemandLoadingExampleImage4, new ElementSize(100f, ElementSizeUnit.Pixels));
                }
                return _onDemandLoadingExampleImage4;
            }
        }

        private static Template _onDemandLoadingExampleImageSet3;
        public static Template OnDemandLoadingExampleImageSet3
        {
            get
            {
#if UNITY_EDITOR
                if (_onDemandLoadingExampleImageSet3 == null || _onDemandLoadingExampleImageSet3.CurrentVersion != Template.Version)
#else
                if (_onDemandLoadingExampleImageSet3 == null)
#endif
                {
                    _onDemandLoadingExampleImageSet3 = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _onDemandLoadingExampleImageSet3.Name = "OnDemandLoadingExampleImageSet3";
                    _onDemandLoadingExampleImageSet3.LineNumber = 30;
                    _onDemandLoadingExampleImageSet3.LinePosition = 8;
#endif
                    Delight.Group.SpacingProperty.SetDefault(_onDemandLoadingExampleImageSet3, new ElementSize(5f, ElementSizeUnit.Pixels));
                    Delight.Group.LoadModeProperty.SetDefault(_onDemandLoadingExampleImageSet3, Delight.LoadMode.Manual);
                }
                return _onDemandLoadingExampleImageSet3;
            }
        }

        private static Template _onDemandLoadingExampleImage5;
        public static Template OnDemandLoadingExampleImage5
        {
            get
            {
#if UNITY_EDITOR
                if (_onDemandLoadingExampleImage5 == null || _onDemandLoadingExampleImage5.CurrentVersion != Template.Version)
#else
                if (_onDemandLoadingExampleImage5 == null)
#endif
                {
                    _onDemandLoadingExampleImage5 = new Template(ImageTemplates.Image);
#if UNITY_EDITOR
                    _onDemandLoadingExampleImage5.Name = "OnDemandLoadingExampleImage5";
                    _onDemandLoadingExampleImage5.LineNumber = 31;
                    _onDemandLoadingExampleImage5.LinePosition = 10;
#endif
                    Delight.Image.SpriteProperty.SetDefault(_onDemandLoadingExampleImage5, Assets.Sprites["Frame2"]);
                    Delight.Image.WidthProperty.SetDefault(_onDemandLoadingExampleImage5, new ElementSize(100f, ElementSizeUnit.Pixels));
                    Delight.Image.HeightProperty.SetDefault(_onDemandLoadingExampleImage5, new ElementSize(100f, ElementSizeUnit.Pixels));
                }
                return _onDemandLoadingExampleImage5;
            }
        }

        private static Template _onDemandLoadingExampleImage6;
        public static Template OnDemandLoadingExampleImage6
        {
            get
            {
#if UNITY_EDITOR
                if (_onDemandLoadingExampleImage6 == null || _onDemandLoadingExampleImage6.CurrentVersion != Template.Version)
#else
                if (_onDemandLoadingExampleImage6 == null)
#endif
                {
                    _onDemandLoadingExampleImage6 = new Template(ImageTemplates.Image);
#if UNITY_EDITOR
                    _onDemandLoadingExampleImage6.Name = "OnDemandLoadingExampleImage6";
                    _onDemandLoadingExampleImage6.LineNumber = 32;
                    _onDemandLoadingExampleImage6.LinePosition = 10;
#endif
                    Delight.Image.SpriteProperty.SetDefault(_onDemandLoadingExampleImage6, Assets.Sprites["Frame3"]);
                    Delight.Image.WidthProperty.SetDefault(_onDemandLoadingExampleImage6, new ElementSize(100f, ElementSizeUnit.Pixels));
                    Delight.Image.HeightProperty.SetDefault(_onDemandLoadingExampleImage6, new ElementSize(100f, ElementSizeUnit.Pixels));
                }
                return _onDemandLoadingExampleImage6;
            }
        }

        private static Template _onDemandLoadingExampleImageSet4;
        public static Template OnDemandLoadingExampleImageSet4
        {
            get
            {
#if UNITY_EDITOR
                if (_onDemandLoadingExampleImageSet4 == null || _onDemandLoadingExampleImageSet4.CurrentVersion != Template.Version)
#else
                if (_onDemandLoadingExampleImageSet4 == null)
#endif
                {
                    _onDemandLoadingExampleImageSet4 = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _onDemandLoadingExampleImageSet4.Name = "OnDemandLoadingExampleImageSet4";
                    _onDemandLoadingExampleImageSet4.LineNumber = 34;
                    _onDemandLoadingExampleImageSet4.LinePosition = 8;
#endif
                    Delight.Group.SpacingProperty.SetDefault(_onDemandLoadingExampleImageSet4, new ElementSize(5f, ElementSizeUnit.Pixels));
                    Delight.Group.LoadModeProperty.SetDefault(_onDemandLoadingExampleImageSet4, Delight.LoadMode.Manual);
                }
                return _onDemandLoadingExampleImageSet4;
            }
        }

        private static Template _onDemandLoadingExampleBigSpriteImage;
        public static Template OnDemandLoadingExampleBigSpriteImage
        {
            get
            {
#if UNITY_EDITOR
                if (_onDemandLoadingExampleBigSpriteImage == null || _onDemandLoadingExampleBigSpriteImage.CurrentVersion != Template.Version)
#else
                if (_onDemandLoadingExampleBigSpriteImage == null)
#endif
                {
                    _onDemandLoadingExampleBigSpriteImage = new Template(ImageTemplates.Image);
#if UNITY_EDITOR
                    _onDemandLoadingExampleBigSpriteImage.Name = "OnDemandLoadingExampleBigSpriteImage";
                    _onDemandLoadingExampleBigSpriteImage.LineNumber = 35;
                    _onDemandLoadingExampleBigSpriteImage.LinePosition = 10;
#endif
                    Delight.Image.SpriteProperty.SetDefault(_onDemandLoadingExampleBigSpriteImage, Assets.Sprites["BigSprite"]);
                    Delight.Image.WidthProperty.SetDefault(_onDemandLoadingExampleBigSpriteImage, new ElementSize(100f, ElementSizeUnit.Pixels));
                    Delight.Image.HeightProperty.SetDefault(_onDemandLoadingExampleBigSpriteImage, new ElementSize(205f, ElementSizeUnit.Pixels));
                }
                return _onDemandLoadingExampleBigSpriteImage;
            }
        }

        private static Template _onDemandLoadingExampleLabel4;
        public static Template OnDemandLoadingExampleLabel4
        {
            get
            {
#if UNITY_EDITOR
                if (_onDemandLoadingExampleLabel4 == null || _onDemandLoadingExampleLabel4.CurrentVersion != Template.Version)
#else
                if (_onDemandLoadingExampleLabel4 == null)
#endif
                {
                    _onDemandLoadingExampleLabel4 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _onDemandLoadingExampleLabel4.Name = "OnDemandLoadingExampleLabel4";
                    _onDemandLoadingExampleLabel4.LineNumber = 38;
                    _onDemandLoadingExampleLabel4.LinePosition = 6;
#endif
                    Delight.Label.WidthProperty.SetDefault(_onDemandLoadingExampleLabel4, new ElementSize(400f, ElementSizeUnit.Pixels));
                    Delight.Label.AlignmentProperty.SetDefault(_onDemandLoadingExampleLabel4, Delight.ElementAlignment.Center);
                    Delight.Label.TextAlignmentProperty.SetDefault(_onDemandLoadingExampleLabel4, TMPro.TextAlignmentOptions.Center);
                    Delight.Label.TextProperty.SetHasBinding(_onDemandLoadingExampleLabel4);
                }
                return _onDemandLoadingExampleLabel4;
            }
        }

        #endregion
    }

    #endregion
}
