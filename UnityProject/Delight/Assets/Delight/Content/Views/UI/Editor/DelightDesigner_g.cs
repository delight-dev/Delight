// Internal view logic generated from "DelightDesigner.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class DelightDesigner : LayoutRoot
    {
        #region Constructors

        public DelightDesigner(View parent, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :
            base(parent, layoutParent, id, template ?? DelightDesignerTemplates.Default, initializer)
        {
            // constructing Grid (Grid1)
            Grid1 = new LayoutGrid(this, this, "Grid1", Grid1Template);
            ContentRegion = new Region(this, Grid1.Content, "ContentRegion", ContentRegionTemplate);
            Grid1.Cell.SetValue(ContentRegion, new CellIndex(1, 1));
            GridImage = new Image(this, ContentRegion.Content, "GridImage", GridImageTemplate);
            Image1 = new Image(this, ContentRegion.Content, "Image1", Image1Template);
            Image2 = new Image(this, ContentRegion.Content, "Image2", Image2Template);
            Button1 = new Button(this, ContentRegion.Content, "Button1", Button1Template);
            Button1.Click += ResolveActionHandler(this, "Test1");
            TestRegion = new ScrollableRegion(this, Grid1.Content, "TestRegion", TestRegionTemplate);
            Grid1.Cell.SetValue(TestRegion, new CellIndex(1, 1));
            Region1 = new Region(this, TestRegion.Content, "Region1", Region1Template);
            Region2 = new Region(this, Region1.Content, "Region2", Region2Template);
            Region3 = new Region(this, Region1.Content, "Region3", Region3Template);
            Region4 = new Region(this, Region1.Content, "Region4", Region4Template);
            Region5 = new Region(this, Region1.Content, "Region5", Region5Template);
            Region6 = new Region(this, Grid1.Content, "Region6", Region6Template);
            Grid1.Cell.SetValue(Region6, new CellIndex(0, 0));
            Grid1.CellSpan.SetValue(Region6, new CellIndex(2, 1));
            List1 = new List(this, Region6.Content, "List1", List1Template);

            // binding <List Items="{view in DesignerViews}">
            Bindings.Add(new Binding(
                new List<string> { "DesignerViews" },
                new List<string> { "List1", "Items" },
                new List<Func<BindableObject>> { () => this },
                new List<Func<BindableObject>> { () => this, () => List1 },
                () => List1.Items = DesignerViews,
                () => { }
            ));

            // Template for List1
            List1.ContentTemplate = new ContentTemplate(tiView => 
            {
                var list1Content = new ListItem(this, List1.Content, "List1Content", List1ContentTemplate);
                var label1 = new Label(this, list1Content.Content, "Label1", Label1Template);

                // binding <Label Text="{view.Name}">
                list1Content.Bindings.Add(new Binding(
                    new List<string> { "Item", "Name" },
                    new List<string> { "Text" },
                    new List<Func<BindableObject>> { () => tiView, () => tiView.Item },
                    new List<Func<BindableObject>> { () => label1 },
                    () => label1.Text = (tiView.Item as Delight.DesignerView).Name,
                    () => { }
                ));
                return list1Content;
            });
            Region7 = new Region(this, Grid1.Content, "Region7", Region7Template);
            Grid1.Cell.SetValue(Region7, new CellIndex(0, 1));
            Grid1.CellSpan.SetValue(Region7, new CellIndex(1, 2));
            Region8 = new Region(this, Grid1.Content, "Region8", Region8Template);
            Grid1.Cell.SetValue(Region8, new CellIndex(1, 2));
            this.AfterInitializeInternal();
        }

        public DelightDesigner() : this(null)
        {
        }

        static DelightDesigner()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(DelightDesignerTemplates.Default, dependencyProperties);

            dependencyProperties.Add(DesignerViewsProperty);
            dependencyProperties.Add(Grid1Property);
            dependencyProperties.Add(Grid1TemplateProperty);
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
            dependencyProperties.Add(TestRegionProperty);
            dependencyProperties.Add(TestRegionTemplateProperty);
            dependencyProperties.Add(Region1Property);
            dependencyProperties.Add(Region1TemplateProperty);
            dependencyProperties.Add(Region2Property);
            dependencyProperties.Add(Region2TemplateProperty);
            dependencyProperties.Add(Region3Property);
            dependencyProperties.Add(Region3TemplateProperty);
            dependencyProperties.Add(Region4Property);
            dependencyProperties.Add(Region4TemplateProperty);
            dependencyProperties.Add(Region5Property);
            dependencyProperties.Add(Region5TemplateProperty);
            dependencyProperties.Add(Region6Property);
            dependencyProperties.Add(Region6TemplateProperty);
            dependencyProperties.Add(List1Property);
            dependencyProperties.Add(List1TemplateProperty);
            dependencyProperties.Add(Label1Property);
            dependencyProperties.Add(Label1TemplateProperty);
            dependencyProperties.Add(Region7Property);
            dependencyProperties.Add(Region7TemplateProperty);
            dependencyProperties.Add(Region8Property);
            dependencyProperties.Add(Region8TemplateProperty);
            dependencyProperties.Add(List1ContentProperty);
            dependencyProperties.Add(List1ContentTemplateProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<Delight.DesignerViewData> DesignerViewsProperty = new DependencyProperty<Delight.DesignerViewData>("DesignerViews");
        public Delight.DesignerViewData DesignerViews
        {
            get { return DesignerViewsProperty.GetValue(this); }
            set { DesignerViewsProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<LayoutGrid> Grid1Property = new DependencyProperty<LayoutGrid>("Grid1");
        public LayoutGrid Grid1
        {
            get { return Grid1Property.GetValue(this); }
            set { Grid1Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Grid1TemplateProperty = new DependencyProperty<Template>("Grid1Template");
        public Template Grid1Template
        {
            get { return Grid1TemplateProperty.GetValue(this); }
            set { Grid1TemplateProperty.SetValue(this, value); }
        }

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

        public readonly static DependencyProperty<ScrollableRegion> TestRegionProperty = new DependencyProperty<ScrollableRegion>("TestRegion");
        public ScrollableRegion TestRegion
        {
            get { return TestRegionProperty.GetValue(this); }
            set { TestRegionProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> TestRegionTemplateProperty = new DependencyProperty<Template>("TestRegionTemplate");
        public Template TestRegionTemplate
        {
            get { return TestRegionTemplateProperty.GetValue(this); }
            set { TestRegionTemplateProperty.SetValue(this, value); }
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

        public readonly static DependencyProperty<Region> Region3Property = new DependencyProperty<Region>("Region3");
        public Region Region3
        {
            get { return Region3Property.GetValue(this); }
            set { Region3Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Region3TemplateProperty = new DependencyProperty<Template>("Region3Template");
        public Template Region3Template
        {
            get { return Region3TemplateProperty.GetValue(this); }
            set { Region3TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> Region4Property = new DependencyProperty<Region>("Region4");
        public Region Region4
        {
            get { return Region4Property.GetValue(this); }
            set { Region4Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Region4TemplateProperty = new DependencyProperty<Template>("Region4Template");
        public Template Region4Template
        {
            get { return Region4TemplateProperty.GetValue(this); }
            set { Region4TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> Region5Property = new DependencyProperty<Region>("Region5");
        public Region Region5
        {
            get { return Region5Property.GetValue(this); }
            set { Region5Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Region5TemplateProperty = new DependencyProperty<Template>("Region5Template");
        public Template Region5Template
        {
            get { return Region5TemplateProperty.GetValue(this); }
            set { Region5TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> Region6Property = new DependencyProperty<Region>("Region6");
        public Region Region6
        {
            get { return Region6Property.GetValue(this); }
            set { Region6Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Region6TemplateProperty = new DependencyProperty<Template>("Region6Template");
        public Template Region6Template
        {
            get { return Region6TemplateProperty.GetValue(this); }
            set { Region6TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<List> List1Property = new DependencyProperty<List>("List1");
        public List List1
        {
            get { return List1Property.GetValue(this); }
            set { List1Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> List1TemplateProperty = new DependencyProperty<Template>("List1Template");
        public Template List1Template
        {
            get { return List1TemplateProperty.GetValue(this); }
            set { List1TemplateProperty.SetValue(this, value); }
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

        public readonly static DependencyProperty<Region> Region7Property = new DependencyProperty<Region>("Region7");
        public Region Region7
        {
            get { return Region7Property.GetValue(this); }
            set { Region7Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Region7TemplateProperty = new DependencyProperty<Template>("Region7Template");
        public Template Region7Template
        {
            get { return Region7TemplateProperty.GetValue(this); }
            set { Region7TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> Region8Property = new DependencyProperty<Region>("Region8");
        public Region Region8
        {
            get { return Region8Property.GetValue(this); }
            set { Region8Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Region8TemplateProperty = new DependencyProperty<Template>("Region8Template");
        public Template Region8Template
        {
            get { return Region8TemplateProperty.GetValue(this); }
            set { Region8TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ListItem> List1ContentProperty = new DependencyProperty<ListItem>("List1Content");
        public ListItem List1Content
        {
            get { return List1ContentProperty.GetValue(this); }
            set { List1ContentProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> List1ContentTemplateProperty = new DependencyProperty<Template>("List1ContentTemplate");
        public Template List1ContentTemplate
        {
            get { return List1ContentTemplateProperty.GetValue(this); }
            set { List1ContentTemplateProperty.SetValue(this, value); }
        }

        #endregion
    }

    #region Data Templates

    public static class DelightDesignerTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return DelightDesigner;
            }
        }

        private static Template _delightDesigner;
        public static Template DelightDesigner
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesigner == null || _delightDesigner.CurrentVersion != Template.Version)
#else
                if (_delightDesigner == null)
#endif
                {
                    _delightDesigner = new Template(LayoutRootTemplates.LayoutRoot);
#if UNITY_EDITOR
                    _delightDesigner.Name = "DelightDesigner";
#endif
                    Delight.DelightDesigner.Grid1TemplateProperty.SetDefault(_delightDesigner, DelightDesignerGrid1);
                    Delight.DelightDesigner.ContentRegionTemplateProperty.SetDefault(_delightDesigner, DelightDesignerContentRegion);
                    Delight.DelightDesigner.GridImageTemplateProperty.SetDefault(_delightDesigner, DelightDesignerGridImage);
                    Delight.DelightDesigner.Image1TemplateProperty.SetDefault(_delightDesigner, DelightDesignerImage1);
                    Delight.DelightDesigner.Image2TemplateProperty.SetDefault(_delightDesigner, DelightDesignerImage2);
                    Delight.DelightDesigner.Button1TemplateProperty.SetDefault(_delightDesigner, DelightDesignerButton1);
                    Delight.DelightDesigner.TestRegionTemplateProperty.SetDefault(_delightDesigner, DelightDesignerTestRegion);
                    Delight.DelightDesigner.Region1TemplateProperty.SetDefault(_delightDesigner, DelightDesignerRegion1);
                    Delight.DelightDesigner.Region2TemplateProperty.SetDefault(_delightDesigner, DelightDesignerRegion2);
                    Delight.DelightDesigner.Region3TemplateProperty.SetDefault(_delightDesigner, DelightDesignerRegion3);
                    Delight.DelightDesigner.Region4TemplateProperty.SetDefault(_delightDesigner, DelightDesignerRegion4);
                    Delight.DelightDesigner.Region5TemplateProperty.SetDefault(_delightDesigner, DelightDesignerRegion5);
                    Delight.DelightDesigner.Region6TemplateProperty.SetDefault(_delightDesigner, DelightDesignerRegion6);
                    Delight.DelightDesigner.List1TemplateProperty.SetDefault(_delightDesigner, DelightDesignerList1);
                    Delight.DelightDesigner.List1ContentTemplateProperty.SetDefault(_delightDesigner, DelightDesignerList1Content);
                    Delight.DelightDesigner.Label1TemplateProperty.SetDefault(_delightDesigner, DelightDesignerLabel1);
                    Delight.DelightDesigner.Region7TemplateProperty.SetDefault(_delightDesigner, DelightDesignerRegion7);
                    Delight.DelightDesigner.Region8TemplateProperty.SetDefault(_delightDesigner, DelightDesignerRegion8);
                }
                return _delightDesigner;
            }
        }

        private static Template _delightDesignerGrid1;
        public static Template DelightDesignerGrid1
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerGrid1 == null || _delightDesignerGrid1.CurrentVersion != Template.Version)
#else
                if (_delightDesignerGrid1 == null)
#endif
                {
                    _delightDesignerGrid1 = new Template(LayoutGridTemplates.LayoutGrid);
#if UNITY_EDITOR
                    _delightDesignerGrid1.Name = "DelightDesignerGrid1";
#endif
                    Delight.LayoutGrid.ColumnsProperty.SetDefault(_delightDesignerGrid1, new ColumnDefinitions { new ColumnDefinition(new ElementSize(250f, ElementSizeUnit.Pixels)), new ColumnDefinition(new ElementSize(1f, ElementSizeUnit.Proportional)), new ColumnDefinition(new ElementSize(250f, ElementSizeUnit.Pixels))});
                    Delight.LayoutGrid.RowsProperty.SetDefault(_delightDesignerGrid1, new RowDefinitions { new RowDefinition(new ElementSize(50f, ElementSizeUnit.Pixels)), new RowDefinition(new ElementSize(1f, ElementSizeUnit.Proportional))});
                }
                return _delightDesignerGrid1;
            }
        }

        private static Template _delightDesignerContentRegion;
        public static Template DelightDesignerContentRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerContentRegion == null || _delightDesignerContentRegion.CurrentVersion != Template.Version)
#else
                if (_delightDesignerContentRegion == null)
#endif
                {
                    _delightDesignerContentRegion = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _delightDesignerContentRegion.Name = "DelightDesignerContentRegion";
#endif
                    Delight.Region.BackgroundColorProperty.SetDefault(_delightDesignerContentRegion, new UnityEngine.Color(0.9882353f, 0.9294118f, 0.1764706f, 1f));
                }
                return _delightDesignerContentRegion;
            }
        }

        private static Template _delightDesignerGridImage;
        public static Template DelightDesignerGridImage
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerGridImage == null || _delightDesignerGridImage.CurrentVersion != Template.Version)
#else
                if (_delightDesignerGridImage == null)
#endif
                {
                    _delightDesignerGridImage = new Template(ImageTemplates.Image);
#if UNITY_EDITOR
                    _delightDesignerGridImage.Name = "DelightDesignerGridImage";
#endif
                    Delight.Image.SpriteProperty.SetDefault(_delightDesignerGridImage, Assets.Sprites["DesignerGrid2"]);
                    Delight.Image.TypeProperty.SetDefault(_delightDesignerGridImage, UnityEngine.UI.Image.Type.Tiled);
                    Delight.Image.WidthProperty.SetDefault(_delightDesignerGridImage, new ElementSize(1f, ElementSizeUnit.Percents));
                    Delight.Image.HeightProperty.SetDefault(_delightDesignerGridImage, new ElementSize(1f, ElementSizeUnit.Percents));
                    Delight.Image.IsVisibleProperty.SetDefault(_delightDesignerGridImage, false);
                }
                return _delightDesignerGridImage;
            }
        }

        private static Template _delightDesignerImage1;
        public static Template DelightDesignerImage1
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerImage1 == null || _delightDesignerImage1.CurrentVersion != Template.Version)
#else
                if (_delightDesignerImage1 == null)
#endif
                {
                    _delightDesignerImage1 = new Template(ImageTemplates.Image);
#if UNITY_EDITOR
                    _delightDesignerImage1.Name = "DelightDesignerImage1";
#endif
                    Delight.Image.ColorProperty.SetDefault(_delightDesignerImage1, new UnityEngine.Color(0.2470588f, 0.2470588f, 0.2392157f, 1f));
                    Delight.Image.WidthProperty.SetDefault(_delightDesignerImage1, new ElementSize(1f, ElementSizeUnit.Pixels));
                    Delight.Image.HeightProperty.SetDefault(_delightDesignerImage1, new ElementSize(1f, ElementSizeUnit.Percents));
                }
                return _delightDesignerImage1;
            }
        }

        private static Template _delightDesignerImage2;
        public static Template DelightDesignerImage2
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerImage2 == null || _delightDesignerImage2.CurrentVersion != Template.Version)
#else
                if (_delightDesignerImage2 == null)
#endif
                {
                    _delightDesignerImage2 = new Template(ImageTemplates.Image);
#if UNITY_EDITOR
                    _delightDesignerImage2.Name = "DelightDesignerImage2";
#endif
                    Delight.Image.ColorProperty.SetDefault(_delightDesignerImage2, new UnityEngine.Color(0.2470588f, 0.2470588f, 0.2392157f, 1f));
                    Delight.Image.WidthProperty.SetDefault(_delightDesignerImage2, new ElementSize(1f, ElementSizeUnit.Percents));
                    Delight.Image.HeightProperty.SetDefault(_delightDesignerImage2, new ElementSize(1f, ElementSizeUnit.Pixels));
                }
                return _delightDesignerImage2;
            }
        }

        private static Template _delightDesignerButton1;
        public static Template DelightDesignerButton1
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerButton1 == null || _delightDesignerButton1.CurrentVersion != Template.Version)
#else
                if (_delightDesignerButton1 == null)
#endif
                {
                    _delightDesignerButton1 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _delightDesignerButton1.Name = "DelightDesignerButton1";
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_delightDesignerButton1, DelightDesignerButton1Label);
                }
                return _delightDesignerButton1;
            }
        }

        private static Template _delightDesignerButton1Label;
        public static Template DelightDesignerButton1Label
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerButton1Label == null || _delightDesignerButton1Label.CurrentVersion != Template.Version)
#else
                if (_delightDesignerButton1Label == null)
#endif
                {
                    _delightDesignerButton1Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _delightDesignerButton1Label.Name = "DelightDesignerButton1Label";
#endif
                    Delight.Label.TextProperty.SetDefault(_delightDesignerButton1Label, "Test");
                }
                return _delightDesignerButton1Label;
            }
        }

        private static Template _delightDesignerTestRegion;
        public static Template DelightDesignerTestRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerTestRegion == null || _delightDesignerTestRegion.CurrentVersion != Template.Version)
#else
                if (_delightDesignerTestRegion == null)
#endif
                {
                    _delightDesignerTestRegion = new Template(ScrollableRegionTemplates.ScrollableRegion);
#if UNITY_EDITOR
                    _delightDesignerTestRegion.Name = "DelightDesignerTestRegion";
#endif
                    Delight.ScrollableRegion.ContentRegionTemplateProperty.SetDefault(_delightDesignerTestRegion, DelightDesignerTestRegionContentRegion);
                }
                return _delightDesignerTestRegion;
            }
        }

        private static Template _delightDesignerTestRegionContentRegion;
        public static Template DelightDesignerTestRegionContentRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerTestRegionContentRegion == null || _delightDesignerTestRegionContentRegion.CurrentVersion != Template.Version)
#else
                if (_delightDesignerTestRegionContentRegion == null)
#endif
                {
                    _delightDesignerTestRegionContentRegion = new Template(ScrollableRegionTemplates.ScrollableRegionContentRegion);
#if UNITY_EDITOR
                    _delightDesignerTestRegionContentRegion.Name = "DelightDesignerTestRegionContentRegion";
#endif
                }
                return _delightDesignerTestRegionContentRegion;
            }
        }

        private static Template _delightDesignerRegion1;
        public static Template DelightDesignerRegion1
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerRegion1 == null || _delightDesignerRegion1.CurrentVersion != Template.Version)
#else
                if (_delightDesignerRegion1 == null)
#endif
                {
                    _delightDesignerRegion1 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _delightDesignerRegion1.Name = "DelightDesignerRegion1";
#endif
                    Delight.Region.WidthProperty.SetDefault(_delightDesignerRegion1, new ElementSize(2000f, ElementSizeUnit.Pixels));
                    Delight.Region.HeightProperty.SetDefault(_delightDesignerRegion1, new ElementSize(2000f, ElementSizeUnit.Pixels));
                    Delight.Region.BackgroundColorProperty.SetDefault(_delightDesignerRegion1, new UnityEngine.Color(1f, 1f, 1f, 1f));
                }
                return _delightDesignerRegion1;
            }
        }

        private static Template _delightDesignerRegion2;
        public static Template DelightDesignerRegion2
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerRegion2 == null || _delightDesignerRegion2.CurrentVersion != Template.Version)
#else
                if (_delightDesignerRegion2 == null)
#endif
                {
                    _delightDesignerRegion2 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _delightDesignerRegion2.Name = "DelightDesignerRegion2";
#endif
                    Delight.Region.WidthProperty.SetDefault(_delightDesignerRegion2, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.HeightProperty.SetDefault(_delightDesignerRegion2, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.BackgroundColorProperty.SetDefault(_delightDesignerRegion2, new UnityEngine.Color(0f, 0f, 1f, 1f));
                    Delight.Region.AlignmentProperty.SetDefault(_delightDesignerRegion2, Delight.ElementAlignment.TopLeft);
                }
                return _delightDesignerRegion2;
            }
        }

        private static Template _delightDesignerRegion3;
        public static Template DelightDesignerRegion3
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerRegion3 == null || _delightDesignerRegion3.CurrentVersion != Template.Version)
#else
                if (_delightDesignerRegion3 == null)
#endif
                {
                    _delightDesignerRegion3 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _delightDesignerRegion3.Name = "DelightDesignerRegion3";
#endif
                    Delight.Region.WidthProperty.SetDefault(_delightDesignerRegion3, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.HeightProperty.SetDefault(_delightDesignerRegion3, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.BackgroundColorProperty.SetDefault(_delightDesignerRegion3, new UnityEngine.Color(1f, 0f, 0f, 1f));
                    Delight.Region.AlignmentProperty.SetDefault(_delightDesignerRegion3, Delight.ElementAlignment.TopRight);
                }
                return _delightDesignerRegion3;
            }
        }

        private static Template _delightDesignerRegion4;
        public static Template DelightDesignerRegion4
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerRegion4 == null || _delightDesignerRegion4.CurrentVersion != Template.Version)
#else
                if (_delightDesignerRegion4 == null)
#endif
                {
                    _delightDesignerRegion4 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _delightDesignerRegion4.Name = "DelightDesignerRegion4";
#endif
                    Delight.Region.WidthProperty.SetDefault(_delightDesignerRegion4, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.HeightProperty.SetDefault(_delightDesignerRegion4, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.BackgroundColorProperty.SetDefault(_delightDesignerRegion4, new UnityEngine.Color(0f, 1f, 0f, 1f));
                    Delight.Region.AlignmentProperty.SetDefault(_delightDesignerRegion4, Delight.ElementAlignment.BottomLeft);
                }
                return _delightDesignerRegion4;
            }
        }

        private static Template _delightDesignerRegion5;
        public static Template DelightDesignerRegion5
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerRegion5 == null || _delightDesignerRegion5.CurrentVersion != Template.Version)
#else
                if (_delightDesignerRegion5 == null)
#endif
                {
                    _delightDesignerRegion5 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _delightDesignerRegion5.Name = "DelightDesignerRegion5";
#endif
                    Delight.Region.WidthProperty.SetDefault(_delightDesignerRegion5, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.HeightProperty.SetDefault(_delightDesignerRegion5, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.BackgroundColorProperty.SetDefault(_delightDesignerRegion5, new UnityEngine.Color(1f, 1f, 0f, 1f));
                    Delight.Region.AlignmentProperty.SetDefault(_delightDesignerRegion5, Delight.ElementAlignment.BottomRight);
                }
                return _delightDesignerRegion5;
            }
        }

        private static Template _delightDesignerRegion6;
        public static Template DelightDesignerRegion6
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerRegion6 == null || _delightDesignerRegion6.CurrentVersion != Template.Version)
#else
                if (_delightDesignerRegion6 == null)
#endif
                {
                    _delightDesignerRegion6 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _delightDesignerRegion6.Name = "DelightDesignerRegion6";
#endif
                    Delight.Region.BackgroundColorProperty.SetDefault(_delightDesignerRegion6, new UnityEngine.Color(0.7019608f, 0.7019608f, 0.7019608f, 1f));
                }
                return _delightDesignerRegion6;
            }
        }

        private static Template _delightDesignerList1;
        public static Template DelightDesignerList1
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerList1 == null || _delightDesignerList1.CurrentVersion != Template.Version)
#else
                if (_delightDesignerList1 == null)
#endif
                {
                    _delightDesignerList1 = new Template(ListTemplates.List);
#if UNITY_EDITOR
                    _delightDesignerList1.Name = "DelightDesignerList1";
#endif
                    Delight.List.IsScrollableProperty.SetDefault(_delightDesignerList1, true);
                    Delight.List.AlignmentProperty.SetDefault(_delightDesignerList1, Delight.ElementAlignment.Top);
                    Delight.List.MarginProperty.SetDefault(_delightDesignerList1, new ElementMargin(new ElementSize(5f, ElementSizeUnit.Pixels), new ElementSize(50f, ElementSizeUnit.Pixels), new ElementSize(5f, ElementSizeUnit.Pixels), new ElementSize(5f, ElementSizeUnit.Pixels)));
                    Delight.List.BackgroundColorProperty.SetDefault(_delightDesignerList1, new UnityEngine.Color(0.9215686f, 0.9215686f, 0.9215686f, 1f));
                    Delight.List.WidthProperty.SetDefault(_delightDesignerList1, new ElementSize(1f, ElementSizeUnit.Percents));
                    Delight.List.HeightProperty.SetDefault(_delightDesignerList1, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.List.ScrollableRegionTemplateProperty.SetDefault(_delightDesignerList1, DelightDesignerList1ScrollableRegion);
                }
                return _delightDesignerList1;
            }
        }

        private static Template _delightDesignerList1ScrollableRegion;
        public static Template DelightDesignerList1ScrollableRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerList1ScrollableRegion == null || _delightDesignerList1ScrollableRegion.CurrentVersion != Template.Version)
#else
                if (_delightDesignerList1ScrollableRegion == null)
#endif
                {
                    _delightDesignerList1ScrollableRegion = new Template(ListTemplates.ListScrollableRegion);
#if UNITY_EDITOR
                    _delightDesignerList1ScrollableRegion.Name = "DelightDesignerList1ScrollableRegion";
#endif
                    Delight.ScrollableRegion.ContentRegionTemplateProperty.SetDefault(_delightDesignerList1ScrollableRegion, DelightDesignerList1ScrollableRegionContentRegion);
                }
                return _delightDesignerList1ScrollableRegion;
            }
        }

        private static Template _delightDesignerList1ScrollableRegionContentRegion;
        public static Template DelightDesignerList1ScrollableRegionContentRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerList1ScrollableRegionContentRegion == null || _delightDesignerList1ScrollableRegionContentRegion.CurrentVersion != Template.Version)
#else
                if (_delightDesignerList1ScrollableRegionContentRegion == null)
#endif
                {
                    _delightDesignerList1ScrollableRegionContentRegion = new Template(ListTemplates.ListScrollableRegionContentRegion);
#if UNITY_EDITOR
                    _delightDesignerList1ScrollableRegionContentRegion.Name = "DelightDesignerList1ScrollableRegionContentRegion";
#endif
                }
                return _delightDesignerList1ScrollableRegionContentRegion;
            }
        }

        private static Template _delightDesignerList1Content;
        public static Template DelightDesignerList1Content
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerList1Content == null || _delightDesignerList1Content.CurrentVersion != Template.Version)
#else
                if (_delightDesignerList1Content == null)
#endif
                {
                    _delightDesignerList1Content = new Template(ListItemTemplates.ListItem);
#if UNITY_EDITOR
                    _delightDesignerList1Content.Name = "DelightDesignerList1Content";
#endif
                }
                return _delightDesignerList1Content;
            }
        }

        private static Template _delightDesignerLabel1;
        public static Template DelightDesignerLabel1
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerLabel1 == null || _delightDesignerLabel1.CurrentVersion != Template.Version)
#else
                if (_delightDesignerLabel1 == null)
#endif
                {
                    _delightDesignerLabel1 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _delightDesignerLabel1.Name = "DelightDesignerLabel1";
#endif
                    Delight.Label.FontSizeProperty.SetDefault(_delightDesignerLabel1, 16f);
                    Delight.Label.HeightProperty.SetDefault(_delightDesignerLabel1, new ElementSize(24f, ElementSizeUnit.Pixels));
                    Delight.Label.FontProperty.SetDefault(_delightDesignerLabel1, Assets.TMP_FontAssets["Ebrima SDF"]);
                    Delight.Label.WidthProperty.SetDefault(_delightDesignerLabel1, new ElementSize(240f, ElementSizeUnit.Pixels));
                    Delight.Label.EnableWordWrappingProperty.SetDefault(_delightDesignerLabel1, false);
                    Delight.Label.MarginProperty.SetDefault(_delightDesignerLabel1, new ElementMargin(new ElementSize(25f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels)));
                    Delight.Label.OverflowModeProperty.SetDefault(_delightDesignerLabel1, TMPro.TextOverflowModes.Ellipsis);
                    Delight.Label.ExtraPaddingProperty.SetDefault(_delightDesignerLabel1, true);
                    Delight.Label.FontColorProperty.SetDefault(_delightDesignerLabel1, new UnityEngine.Color(0.1411765f, 0.1411765f, 0.1411765f, 1f));
                }
                return _delightDesignerLabel1;
            }
        }

        private static Template _delightDesignerRegion7;
        public static Template DelightDesignerRegion7
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerRegion7 == null || _delightDesignerRegion7.CurrentVersion != Template.Version)
#else
                if (_delightDesignerRegion7 == null)
#endif
                {
                    _delightDesignerRegion7 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _delightDesignerRegion7.Name = "DelightDesignerRegion7";
#endif
                    Delight.Region.BackgroundColorProperty.SetDefault(_delightDesignerRegion7, new UnityEngine.Color(0.6392157f, 0.6352941f, 0.6392157f, 1f));
                }
                return _delightDesignerRegion7;
            }
        }

        private static Template _delightDesignerRegion8;
        public static Template DelightDesignerRegion8
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerRegion8 == null || _delightDesignerRegion8.CurrentVersion != Template.Version)
#else
                if (_delightDesignerRegion8 == null)
#endif
                {
                    _delightDesignerRegion8 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _delightDesignerRegion8.Name = "DelightDesignerRegion8";
#endif
                    Delight.Region.BackgroundColorProperty.SetDefault(_delightDesignerRegion8, new UnityEngine.Color(0.8627451f, 0.8627451f, 0.8627451f, 1f));
                }
                return _delightDesignerRegion8;
            }
        }

        #endregion
    }

    #endregion
}
