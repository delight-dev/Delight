// Internal view logic generated from "EditorMainView.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class EditorMainView : LayoutRoot
    {
        #region Constructors

        public EditorMainView(View parent, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :
            base(parent, layoutParent, id, template ?? EditorMainViewTemplates.Default, initializer)
        {
            // constructing Region (ContentRegion)
            ContentRegion = new Region(this, this, "ContentRegion", ContentRegionTemplate);
            GridImage = new Image(this, ContentRegion, "GridImage", GridImageTemplate);
            Image1 = new Image(this, ContentRegion, "Image1", Image1Template);
            Image2 = new Image(this, ContentRegion, "Image2", Image2Template);
            Button1 = new Button(this, ContentRegion, "Button1", Button1Template);
            Button1.Click += ResolveActionHandler(this, "Test1");

            // constructing Region (LeftPanel)
            LeftPanel = new Region(this, this, "LeftPanel", LeftPanelTemplate);
            this.AfterInitializeInternal();
        }

        public EditorMainView() : this(null)
        {
        }

        static EditorMainView()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(EditorMainViewTemplates.Default, dependencyProperties);

            dependencyProperties.Add(ContentRegionProperty);
            dependencyProperties.Add(ContentRegionTemplateProperty);
            dependencyProperties.Add(GridImageProperty);
            dependencyProperties.Add(GridImageTemplateProperty);
            dependencyProperties.Add(Image1Property);
            dependencyProperties.Add(Image1TemplateProperty);
            dependencyProperties.Add(Image2Property);
            dependencyProperties.Add(Image2TemplateProperty);
            dependencyProperties.Add(Button1Property);
            dependencyProperties.Add(Button1TemplateProperty);
            dependencyProperties.Add(LeftPanelProperty);
            dependencyProperties.Add(LeftPanelTemplateProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<Region> ContentRegionProperty = new DependencyProperty<Region>("ContentRegion");
        public Region ContentRegion
        {
            get { return ContentRegionProperty.GetValue(this); }
            set { ContentRegionProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> ContentRegionTemplateProperty = new DependencyProperty<Template>("ContentRegionTemplate");
        public Template ContentRegionTemplate
        {
            get { return ContentRegionTemplateProperty.GetValue(this); }
            set { ContentRegionTemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Image> GridImageProperty = new DependencyProperty<Image>("GridImage");
        public Image GridImage
        {
            get { return GridImageProperty.GetValue(this); }
            set { GridImageProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> GridImageTemplateProperty = new DependencyProperty<Template>("GridImageTemplate");
        public Template GridImageTemplate
        {
            get { return GridImageTemplateProperty.GetValue(this); }
            set { GridImageTemplateProperty.SetValue(this, value); }
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

        public readonly static DependencyProperty<Region> LeftPanelProperty = new DependencyProperty<Region>("LeftPanel");
        public Region LeftPanel
        {
            get { return LeftPanelProperty.GetValue(this); }
            set { LeftPanelProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> LeftPanelTemplateProperty = new DependencyProperty<Template>("LeftPanelTemplate");
        public Template LeftPanelTemplate
        {
            get { return LeftPanelTemplateProperty.GetValue(this); }
            set { LeftPanelTemplateProperty.SetValue(this, value); }
        }

        #endregion
    }

    #region Data Templates

    public static class EditorMainViewTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return EditorMainView;
            }
        }

        private static Template _editorMainView;
        public static Template EditorMainView
        {
            get
            {
#if UNITY_EDITOR
                if (_editorMainView == null || _editorMainView.CurrentVersion != Template.Version)
#else
                if (_editorMainView == null)
#endif
                {
                    _editorMainView = new Template(LayoutRootTemplates.LayoutRoot);
#if UNITY_EDITOR
                    _editorMainView.Name = "EditorMainView";
#endif
                    Delight.EditorMainView.ContentRegionTemplateProperty.SetDefault(_editorMainView, EditorMainViewContentRegion);
                    Delight.EditorMainView.GridImageTemplateProperty.SetDefault(_editorMainView, EditorMainViewGridImage);
                    Delight.EditorMainView.Image1TemplateProperty.SetDefault(_editorMainView, EditorMainViewImage1);
                    Delight.EditorMainView.Image2TemplateProperty.SetDefault(_editorMainView, EditorMainViewImage2);
                    Delight.EditorMainView.Button1TemplateProperty.SetDefault(_editorMainView, EditorMainViewButton1);
                    Delight.EditorMainView.LeftPanelTemplateProperty.SetDefault(_editorMainView, EditorMainViewLeftPanel);
                }
                return _editorMainView;
            }
        }

        private static Template _editorMainViewContentRegion;
        public static Template EditorMainViewContentRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_editorMainViewContentRegion == null || _editorMainViewContentRegion.CurrentVersion != Template.Version)
#else
                if (_editorMainViewContentRegion == null)
#endif
                {
                    _editorMainViewContentRegion = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _editorMainViewContentRegion.Name = "EditorMainViewContentRegion";
#endif
                    Delight.Region.MarginProperty.SetDefault(_editorMainViewContentRegion, new ElementMargin(new ElementSize(250f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels)));
                }
                return _editorMainViewContentRegion;
            }
        }

        private static Template _editorMainViewGridImage;
        public static Template EditorMainViewGridImage
        {
            get
            {
#if UNITY_EDITOR
                if (_editorMainViewGridImage == null || _editorMainViewGridImage.CurrentVersion != Template.Version)
#else
                if (_editorMainViewGridImage == null)
#endif
                {
                    _editorMainViewGridImage = new Template(ImageTemplates.Image);
#if UNITY_EDITOR
                    _editorMainViewGridImage.Name = "EditorMainViewGridImage";
#endif
                    Delight.Image.SpriteProperty.SetDefault(_editorMainViewGridImage, Assets.Sprites["EditorGrid"]);
                    Delight.Image.TypeProperty.SetDefault(_editorMainViewGridImage, UnityEngine.UI.Image.Type.Tiled);
                    Delight.Image.WidthProperty.SetDefault(_editorMainViewGridImage, new ElementSize(1f, ElementSizeUnit.Percents));
                    Delight.Image.HeightProperty.SetDefault(_editorMainViewGridImage, new ElementSize(1f, ElementSizeUnit.Percents));
                    Delight.Image.IsVisibleProperty.SetDefault(_editorMainViewGridImage, false);
                }
                return _editorMainViewGridImage;
            }
        }

        private static Template _editorMainViewImage1;
        public static Template EditorMainViewImage1
        {
            get
            {
#if UNITY_EDITOR
                if (_editorMainViewImage1 == null || _editorMainViewImage1.CurrentVersion != Template.Version)
#else
                if (_editorMainViewImage1 == null)
#endif
                {
                    _editorMainViewImage1 = new Template(ImageTemplates.Image);
#if UNITY_EDITOR
                    _editorMainViewImage1.Name = "EditorMainViewImage1";
#endif
                    Delight.Image.ColorProperty.SetDefault(_editorMainViewImage1, new UnityEngine.Color(0.7568628f, 0.7568628f, 0.7607843f, 1f));
                    Delight.Image.WidthProperty.SetDefault(_editorMainViewImage1, new ElementSize(1f, ElementSizeUnit.Pixels));
                    Delight.Image.HeightProperty.SetDefault(_editorMainViewImage1, new ElementSize(1f, ElementSizeUnit.Percents));
                }
                return _editorMainViewImage1;
            }
        }

        private static Template _editorMainViewImage2;
        public static Template EditorMainViewImage2
        {
            get
            {
#if UNITY_EDITOR
                if (_editorMainViewImage2 == null || _editorMainViewImage2.CurrentVersion != Template.Version)
#else
                if (_editorMainViewImage2 == null)
#endif
                {
                    _editorMainViewImage2 = new Template(ImageTemplates.Image);
#if UNITY_EDITOR
                    _editorMainViewImage2.Name = "EditorMainViewImage2";
#endif
                    Delight.Image.ColorProperty.SetDefault(_editorMainViewImage2, new UnityEngine.Color(0.7568628f, 0.7568628f, 0.7607843f, 1f));
                    Delight.Image.WidthProperty.SetDefault(_editorMainViewImage2, new ElementSize(1f, ElementSizeUnit.Percents));
                    Delight.Image.HeightProperty.SetDefault(_editorMainViewImage2, new ElementSize(1f, ElementSizeUnit.Pixels));
                }
                return _editorMainViewImage2;
            }
        }

        private static Template _editorMainViewButton1;
        public static Template EditorMainViewButton1
        {
            get
            {
#if UNITY_EDITOR
                if (_editorMainViewButton1 == null || _editorMainViewButton1.CurrentVersion != Template.Version)
#else
                if (_editorMainViewButton1 == null)
#endif
                {
                    _editorMainViewButton1 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _editorMainViewButton1.Name = "EditorMainViewButton1";
#endif
                    Delight.Button.BackgroundColorProperty.SetStateDefault("Highlighted", _editorMainViewButton1, new UnityEngine.Color(1f, 0f, 0f, 1f));
                    Delight.Button.LabelTemplateProperty.SetDefault(_editorMainViewButton1, EditorMainViewButton1Label);
                }
                return _editorMainViewButton1;
            }
        }

        private static Template _editorMainViewButton1Label;
        public static Template EditorMainViewButton1Label
        {
            get
            {
#if UNITY_EDITOR
                if (_editorMainViewButton1Label == null || _editorMainViewButton1Label.CurrentVersion != Template.Version)
#else
                if (_editorMainViewButton1Label == null)
#endif
                {
                    _editorMainViewButton1Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _editorMainViewButton1Label.Name = "EditorMainViewButton1Label";
#endif
                    Delight.Label.TextProperty.SetDefault(_editorMainViewButton1Label, "Test");
                }
                return _editorMainViewButton1Label;
            }
        }

        private static Template _editorMainViewLeftPanel;
        public static Template EditorMainViewLeftPanel
        {
            get
            {
#if UNITY_EDITOR
                if (_editorMainViewLeftPanel == null || _editorMainViewLeftPanel.CurrentVersion != Template.Version)
#else
                if (_editorMainViewLeftPanel == null)
#endif
                {
                    _editorMainViewLeftPanel = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _editorMainViewLeftPanel.Name = "EditorMainViewLeftPanel";
#endif
                    Delight.Region.WidthProperty.SetDefault(_editorMainViewLeftPanel, new ElementSize(250f, ElementSizeUnit.Pixels));
                    Delight.Region.AlignmentProperty.SetDefault(_editorMainViewLeftPanel, Delight.ElementAlignment.Left);
                    Delight.Region.BackgroundColorProperty.SetDefault(_editorMainViewLeftPanel, new UnityEngine.Color(0.7568628f, 0.7568628f, 0.7607843f, 1f));
                }
                return _editorMainViewLeftPanel;
            }
        }

        #endregion
    }

    #endregion
}
