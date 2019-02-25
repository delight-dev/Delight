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
            // constructing Region (ContentRegion)
            ContentRegion = new Region(this, this, "ContentRegion", ContentRegionTemplate);
            GridImage = new Image(this, ContentRegion.Content, "GridImage", GridImageTemplate);
            Image1 = new Image(this, ContentRegion.Content, "Image1", Image1Template);
            Image2 = new Image(this, ContentRegion.Content, "Image2", Image2Template);
            Button1 = new Button(this, ContentRegion.Content, "Button1", Button1Template);
            Button1.Click += ResolveActionHandler(this, "Test1");

            // constructing Grid (Grid1)
            Grid1 = new LayoutGrid(this, this, "Grid1", Grid1Template);
            Cell00 = new Region(this, Grid1.Content, "Cell00", Cell00Template);
            Grid1.Cell.SetValue(Cell00, new CellIndex(0, 0));
            Cell01 = new Region(this, Grid1.Content, "Cell01", Cell01Template);
            Grid1.Cell.SetValue(Cell01, new CellIndex(0, 1));
            Cell02 = new Region(this, Grid1.Content, "Cell02", Cell02Template);
            Grid1.Cell.SetValue(Cell02, new CellIndex(0, 2));
            Cell10 = new Region(this, Grid1.Content, "Cell10", Cell10Template);
            Grid1.Cell.SetValue(Cell10, new CellIndex(1, 0));
            Cell11 = new Region(this, Grid1.Content, "Cell11", Cell11Template);
            Grid1.Cell.SetValue(Cell11, new CellIndex(1, 1));
            Cell12 = new Region(this, Grid1.Content, "Cell12", Cell12Template);
            Grid1.Cell.SetValue(Cell12, new CellIndex(1, 2));
            Cell20 = new Region(this, Grid1.Content, "Cell20", Cell20Template);
            Grid1.Cell.SetValue(Cell20, new CellIndex(2, 0));
            Cell21 = new Region(this, Grid1.Content, "Cell21", Cell21Template);
            Grid1.Cell.SetValue(Cell21, new CellIndex(2, 1));
            Cell22 = new Region(this, Grid1.Content, "Cell22", Cell22Template);
            Grid1.Cell.SetValue(Cell22, new CellIndex(2, 2));
            this.AfterInitializeInternal();
        }

        public DelightDesigner() : this(null)
        {
        }

        static DelightDesigner()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(DelightDesignerTemplates.Default, dependencyProperties);

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
            dependencyProperties.Add(Grid1Property);
            dependencyProperties.Add(Grid1TemplateProperty);
            dependencyProperties.Add(Cell00Property);
            dependencyProperties.Add(Cell00TemplateProperty);
            dependencyProperties.Add(Cell01Property);
            dependencyProperties.Add(Cell01TemplateProperty);
            dependencyProperties.Add(Cell02Property);
            dependencyProperties.Add(Cell02TemplateProperty);
            dependencyProperties.Add(Cell10Property);
            dependencyProperties.Add(Cell10TemplateProperty);
            dependencyProperties.Add(Cell11Property);
            dependencyProperties.Add(Cell11TemplateProperty);
            dependencyProperties.Add(Cell12Property);
            dependencyProperties.Add(Cell12TemplateProperty);
            dependencyProperties.Add(Cell20Property);
            dependencyProperties.Add(Cell20TemplateProperty);
            dependencyProperties.Add(Cell21Property);
            dependencyProperties.Add(Cell21TemplateProperty);
            dependencyProperties.Add(Cell22Property);
            dependencyProperties.Add(Cell22TemplateProperty);
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

        public readonly static DependencyProperty<Region> Cell00Property = new DependencyProperty<Region>("Cell00");
        public Region Cell00
        {
            get { return Cell00Property.GetValue(this); }
            set { Cell00Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Cell00TemplateProperty = new DependencyProperty<Template>("Cell00Template");
        public Template Cell00Template
        {
            get { return Cell00TemplateProperty.GetValue(this); }
            set { Cell00TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> Cell01Property = new DependencyProperty<Region>("Cell01");
        public Region Cell01
        {
            get { return Cell01Property.GetValue(this); }
            set { Cell01Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Cell01TemplateProperty = new DependencyProperty<Template>("Cell01Template");
        public Template Cell01Template
        {
            get { return Cell01TemplateProperty.GetValue(this); }
            set { Cell01TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> Cell02Property = new DependencyProperty<Region>("Cell02");
        public Region Cell02
        {
            get { return Cell02Property.GetValue(this); }
            set { Cell02Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Cell02TemplateProperty = new DependencyProperty<Template>("Cell02Template");
        public Template Cell02Template
        {
            get { return Cell02TemplateProperty.GetValue(this); }
            set { Cell02TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> Cell10Property = new DependencyProperty<Region>("Cell10");
        public Region Cell10
        {
            get { return Cell10Property.GetValue(this); }
            set { Cell10Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Cell10TemplateProperty = new DependencyProperty<Template>("Cell10Template");
        public Template Cell10Template
        {
            get { return Cell10TemplateProperty.GetValue(this); }
            set { Cell10TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> Cell11Property = new DependencyProperty<Region>("Cell11");
        public Region Cell11
        {
            get { return Cell11Property.GetValue(this); }
            set { Cell11Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Cell11TemplateProperty = new DependencyProperty<Template>("Cell11Template");
        public Template Cell11Template
        {
            get { return Cell11TemplateProperty.GetValue(this); }
            set { Cell11TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> Cell12Property = new DependencyProperty<Region>("Cell12");
        public Region Cell12
        {
            get { return Cell12Property.GetValue(this); }
            set { Cell12Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Cell12TemplateProperty = new DependencyProperty<Template>("Cell12Template");
        public Template Cell12Template
        {
            get { return Cell12TemplateProperty.GetValue(this); }
            set { Cell12TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> Cell20Property = new DependencyProperty<Region>("Cell20");
        public Region Cell20
        {
            get { return Cell20Property.GetValue(this); }
            set { Cell20Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Cell20TemplateProperty = new DependencyProperty<Template>("Cell20Template");
        public Template Cell20Template
        {
            get { return Cell20TemplateProperty.GetValue(this); }
            set { Cell20TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> Cell21Property = new DependencyProperty<Region>("Cell21");
        public Region Cell21
        {
            get { return Cell21Property.GetValue(this); }
            set { Cell21Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Cell21TemplateProperty = new DependencyProperty<Template>("Cell21Template");
        public Template Cell21Template
        {
            get { return Cell21TemplateProperty.GetValue(this); }
            set { Cell21TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> Cell22Property = new DependencyProperty<Region>("Cell22");
        public Region Cell22
        {
            get { return Cell22Property.GetValue(this); }
            set { Cell22Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Cell22TemplateProperty = new DependencyProperty<Template>("Cell22Template");
        public Template Cell22Template
        {
            get { return Cell22TemplateProperty.GetValue(this); }
            set { Cell22TemplateProperty.SetValue(this, value); }
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
                    Delight.DelightDesigner.ContentRegionTemplateProperty.SetDefault(_delightDesigner, DelightDesignerContentRegion);
                    Delight.DelightDesigner.GridImageTemplateProperty.SetDefault(_delightDesigner, DelightDesignerGridImage);
                    Delight.DelightDesigner.Image1TemplateProperty.SetDefault(_delightDesigner, DelightDesignerImage1);
                    Delight.DelightDesigner.Image2TemplateProperty.SetDefault(_delightDesigner, DelightDesignerImage2);
                    Delight.DelightDesigner.Button1TemplateProperty.SetDefault(_delightDesigner, DelightDesignerButton1);
                    Delight.DelightDesigner.Grid1TemplateProperty.SetDefault(_delightDesigner, DelightDesignerGrid1);
                    Delight.DelightDesigner.Cell00TemplateProperty.SetDefault(_delightDesigner, DelightDesignerCell00);
                    Delight.DelightDesigner.Cell01TemplateProperty.SetDefault(_delightDesigner, DelightDesignerCell01);
                    Delight.DelightDesigner.Cell02TemplateProperty.SetDefault(_delightDesigner, DelightDesignerCell02);
                    Delight.DelightDesigner.Cell10TemplateProperty.SetDefault(_delightDesigner, DelightDesignerCell10);
                    Delight.DelightDesigner.Cell11TemplateProperty.SetDefault(_delightDesigner, DelightDesignerCell11);
                    Delight.DelightDesigner.Cell12TemplateProperty.SetDefault(_delightDesigner, DelightDesignerCell12);
                    Delight.DelightDesigner.Cell20TemplateProperty.SetDefault(_delightDesigner, DelightDesignerCell20);
                    Delight.DelightDesigner.Cell21TemplateProperty.SetDefault(_delightDesigner, DelightDesignerCell21);
                    Delight.DelightDesigner.Cell22TemplateProperty.SetDefault(_delightDesigner, DelightDesignerCell22);
                }
                return _delightDesigner;
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
                    Delight.Region.MarginProperty.SetDefault(_delightDesignerContentRegion, new ElementMargin(new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels)));
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
                    Delight.LayoutGrid.RowDefinitionsProperty.SetDefault(_delightDesignerGrid1, new RowDefinitions { new RowDefinition(new ElementSize(200f, ElementSizeUnit.Pixels)), new RowDefinition(new ElementSize(1f, ElementSizeUnit.Proportional)), new RowDefinition(new ElementSize(1f, ElementSizeUnit.Proportional))});
                    Delight.LayoutGrid.ColumnDefinitionsProperty.SetDefault(_delightDesignerGrid1, new ColumnDefinitions { new ColumnDefinition(new ElementSize(200f, ElementSizeUnit.Pixels)), new ColumnDefinition(new ElementSize(200f, ElementSizeUnit.Pixels)), new ColumnDefinition(new ElementSize(1f, ElementSizeUnit.Proportional))});
                }
                return _delightDesignerGrid1;
            }
        }

        private static Template _delightDesignerCell00;
        public static Template DelightDesignerCell00
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerCell00 == null || _delightDesignerCell00.CurrentVersion != Template.Version)
#else
                if (_delightDesignerCell00 == null)
#endif
                {
                    _delightDesignerCell00 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _delightDesignerCell00.Name = "DelightDesignerCell00";
#endif
                    Delight.Region.BackgroundColorProperty.SetDefault(_delightDesignerCell00, new UnityEngine.Color(0.3254902f, 0.5372549f, 0.8784314f, 1f));
                }
                return _delightDesignerCell00;
            }
        }

        private static Template _delightDesignerCell01;
        public static Template DelightDesignerCell01
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerCell01 == null || _delightDesignerCell01.CurrentVersion != Template.Version)
#else
                if (_delightDesignerCell01 == null)
#endif
                {
                    _delightDesignerCell01 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _delightDesignerCell01.Name = "DelightDesignerCell01";
#endif
                    Delight.Region.BackgroundColorProperty.SetDefault(_delightDesignerCell01, new UnityEngine.Color(0.8901961f, 0.4588235f, 0.9764706f, 1f));
                }
                return _delightDesignerCell01;
            }
        }

        private static Template _delightDesignerCell02;
        public static Template DelightDesignerCell02
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerCell02 == null || _delightDesignerCell02.CurrentVersion != Template.Version)
#else
                if (_delightDesignerCell02 == null)
#endif
                {
                    _delightDesignerCell02 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _delightDesignerCell02.Name = "DelightDesignerCell02";
#endif
                    Delight.Region.BackgroundColorProperty.SetDefault(_delightDesignerCell02, new UnityEngine.Color(0.454902f, 0.9764706f, 0.8352941f, 1f));
                }
                return _delightDesignerCell02;
            }
        }

        private static Template _delightDesignerCell10;
        public static Template DelightDesignerCell10
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerCell10 == null || _delightDesignerCell10.CurrentVersion != Template.Version)
#else
                if (_delightDesignerCell10 == null)
#endif
                {
                    _delightDesignerCell10 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _delightDesignerCell10.Name = "DelightDesignerCell10";
#endif
                    Delight.Region.BackgroundColorProperty.SetDefault(_delightDesignerCell10, new UnityEngine.Color(0.9764706f, 0.7764706f, 0.454902f, 1f));
                }
                return _delightDesignerCell10;
            }
        }

        private static Template _delightDesignerCell11;
        public static Template DelightDesignerCell11
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerCell11 == null || _delightDesignerCell11.CurrentVersion != Template.Version)
#else
                if (_delightDesignerCell11 == null)
#endif
                {
                    _delightDesignerCell11 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _delightDesignerCell11.Name = "DelightDesignerCell11";
#endif
                    Delight.Region.BackgroundColorProperty.SetDefault(_delightDesignerCell11, new UnityEngine.Color(0.9882353f, 0.9294118f, 0.1764706f, 1f));
                }
                return _delightDesignerCell11;
            }
        }

        private static Template _delightDesignerCell12;
        public static Template DelightDesignerCell12
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerCell12 == null || _delightDesignerCell12.CurrentVersion != Template.Version)
#else
                if (_delightDesignerCell12 == null)
#endif
                {
                    _delightDesignerCell12 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _delightDesignerCell12.Name = "DelightDesignerCell12";
#endif
                    Delight.Region.BackgroundColorProperty.SetDefault(_delightDesignerCell12, new UnityEngine.Color(0.172549f, 0.9686275f, 0.1843137f, 1f));
                }
                return _delightDesignerCell12;
            }
        }

        private static Template _delightDesignerCell20;
        public static Template DelightDesignerCell20
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerCell20 == null || _delightDesignerCell20.CurrentVersion != Template.Version)
#else
                if (_delightDesignerCell20 == null)
#endif
                {
                    _delightDesignerCell20 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _delightDesignerCell20.Name = "DelightDesignerCell20";
#endif
                    Delight.Region.BackgroundColorProperty.SetDefault(_delightDesignerCell20, new UnityEngine.Color(0.9372549f, 0.3333333f, 0.1686275f, 1f));
                }
                return _delightDesignerCell20;
            }
        }

        private static Template _delightDesignerCell21;
        public static Template DelightDesignerCell21
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerCell21 == null || _delightDesignerCell21.CurrentVersion != Template.Version)
#else
                if (_delightDesignerCell21 == null)
#endif
                {
                    _delightDesignerCell21 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _delightDesignerCell21.Name = "DelightDesignerCell21";
#endif
                    Delight.Region.BackgroundColorProperty.SetDefault(_delightDesignerCell21, new UnityEngine.Color(0f, 0.5294118f, 1f, 1f));
                }
                return _delightDesignerCell21;
            }
        }

        private static Template _delightDesignerCell22;
        public static Template DelightDesignerCell22
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerCell22 == null || _delightDesignerCell22.CurrentVersion != Template.Version)
#else
                if (_delightDesignerCell22 == null)
#endif
                {
                    _delightDesignerCell22 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _delightDesignerCell22.Name = "DelightDesignerCell22";
#endif
                    Delight.Region.BackgroundColorProperty.SetDefault(_delightDesignerCell22, new UnityEngine.Color(0.5294118f, 0.1882353f, 0.6784314f, 1f));
                }
                return _delightDesignerCell22;
            }
        }

        #endregion
    }

    #endregion
}
