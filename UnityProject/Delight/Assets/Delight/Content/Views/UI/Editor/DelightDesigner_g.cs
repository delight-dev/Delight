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
            ContentRegion = new ScrollableRegion(this, Grid1.Content, "ContentRegion", ContentRegionTemplate);
            Grid1.Cell.SetValue(ContentRegion, new CellIndex(1, 1));
            Grid1.CellSpan.SetValue(ContentRegion, new CellIndex(1, 2));
            GridBackgroundRegion = new Region(this, ContentRegion.Content, "GridBackgroundRegion", GridBackgroundRegionTemplate);
            GridImage = new Image(this, GridBackgroundRegion.Content, "GridImage", GridImageTemplate);
            Image1 = new Image(this, GridBackgroundRegion.Content, "Image1", Image1Template);
            Image2 = new Image(this, GridBackgroundRegion.Content, "Image2", Image2Template);
            ViewRegion = new Region(this, ContentRegion.Content, "ViewRegion", ViewRegionTemplate);
            Region1 = new Region(this, Grid1.Content, "Region1", Region1Template);
            Grid1.Cell.SetValue(Region1, new CellIndex(0, 0));
            Grid1.CellSpan.SetValue(Region1, new CellIndex(2, 1));
            List1 = new List(this, Region1.Content, "List1", List1Template);
            if (List1.ItemSelected == null) List1.ItemSelected = new ViewAction();
            List1.ItemSelected.RegisterHandler(ResolveActionHandler(this, "ViewSelected"));

            // binding <List Items="{view in DesignerViews}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "DesignerViews" }, new List<Func<BindableObject>> { () => this }) }, new BindingPath(new List<string> { "List1", "Items" }, new List<Func<BindableObject>> { () => this, () => List1 }), () => List1.Items = DesignerViews, () => { }, false));

            // Template for List1
            List1.ContentTemplate = new ContentTemplate(tiView => 
            {
                var list1Content = new ListItem(this, List1.Content, "List1Content", List1ContentTemplate);
                var label1 = new Label(this, list1Content.Content, "Label1", Label1Template);

                // binding <Label Text="{view.Name}">
                list1Content.Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "Item", "Name" }, new List<Func<BindableObject>> { () => tiView, () => (tiView.Item as Delight.DesignerView) }) }, new BindingPath(new List<string> { "Text" }, new List<Func<BindableObject>> { () => label1 }), () => label1.Text = (tiView.Item as Delight.DesignerView).Name, () => { }, false));
                list1Content.ContentTemplateData = tiView;
                return list1Content;
            });
            Region2 = new Region(this, Grid1.Content, "Region2", Region2Template);
            Grid1.Cell.SetValue(Region2, new CellIndex(0, 1));
            Grid1.CellSpan.SetValue(Region2, new CellIndex(1, 2));
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
            dependencyProperties.Add(GridBackgroundRegionProperty);
            dependencyProperties.Add(GridBackgroundRegionTemplateProperty);
            dependencyProperties.Add(GridImageProperty);
            dependencyProperties.Add(GridImageTemplateProperty);
            dependencyProperties.Add(Image1Property);
            dependencyProperties.Add(Image1TemplateProperty);
            dependencyProperties.Add(Image2Property);
            dependencyProperties.Add(Image2TemplateProperty);
            dependencyProperties.Add(ViewRegionProperty);
            dependencyProperties.Add(ViewRegionTemplateProperty);
            dependencyProperties.Add(Region1Property);
            dependencyProperties.Add(Region1TemplateProperty);
            dependencyProperties.Add(List1Property);
            dependencyProperties.Add(List1TemplateProperty);
            dependencyProperties.Add(Label1Property);
            dependencyProperties.Add(Label1TemplateProperty);
            dependencyProperties.Add(Region2Property);
            dependencyProperties.Add(Region2TemplateProperty);
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

        public readonly static DependencyProperty<ScrollableRegion> ContentRegionProperty = new DependencyProperty<ScrollableRegion>("ContentRegion");
        public ScrollableRegion ContentRegion
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

        public readonly static DependencyProperty<Region> GridBackgroundRegionProperty = new DependencyProperty<Region>("GridBackgroundRegion");
        public Region GridBackgroundRegion
        {
            get { return GridBackgroundRegionProperty.GetValue(this); }
            set { GridBackgroundRegionProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> GridBackgroundRegionTemplateProperty = new DependencyProperty<Template>("GridBackgroundRegionTemplate");
        public Template GridBackgroundRegionTemplate
        {
            get { return GridBackgroundRegionTemplateProperty.GetValue(this); }
            set { GridBackgroundRegionTemplateProperty.SetValue(this, value); }
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

        public readonly static DependencyProperty<Region> ViewRegionProperty = new DependencyProperty<Region>("ViewRegion");
        public Region ViewRegion
        {
            get { return ViewRegionProperty.GetValue(this); }
            set { ViewRegionProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> ViewRegionTemplateProperty = new DependencyProperty<Template>("ViewRegionTemplate");
        public Template ViewRegionTemplate
        {
            get { return ViewRegionTemplateProperty.GetValue(this); }
            set { ViewRegionTemplateProperty.SetValue(this, value); }
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
                    Delight.DelightDesigner.GridBackgroundRegionTemplateProperty.SetDefault(_delightDesigner, DelightDesignerGridBackgroundRegion);
                    Delight.DelightDesigner.GridImageTemplateProperty.SetDefault(_delightDesigner, DelightDesignerGridImage);
                    Delight.DelightDesigner.Image1TemplateProperty.SetDefault(_delightDesigner, DelightDesignerImage1);
                    Delight.DelightDesigner.Image2TemplateProperty.SetDefault(_delightDesigner, DelightDesignerImage2);
                    Delight.DelightDesigner.ViewRegionTemplateProperty.SetDefault(_delightDesigner, DelightDesignerViewRegion);
                    Delight.DelightDesigner.Region1TemplateProperty.SetDefault(_delightDesigner, DelightDesignerRegion1);
                    Delight.DelightDesigner.List1TemplateProperty.SetDefault(_delightDesigner, DelightDesignerList1);
                    Delight.DelightDesigner.List1ContentTemplateProperty.SetDefault(_delightDesigner, DelightDesignerList1Content);
                    Delight.DelightDesigner.Label1TemplateProperty.SetDefault(_delightDesigner, DelightDesignerLabel1);
                    Delight.DelightDesigner.Region2TemplateProperty.SetDefault(_delightDesigner, DelightDesignerRegion2);
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
                    _delightDesignerContentRegion = new Template(ScrollableRegionTemplates.ScrollableRegion);
#if UNITY_EDITOR
                    _delightDesignerContentRegion.Name = "DelightDesignerContentRegion";
#endif
                    Delight.ScrollableRegion.HasInertiaProperty.SetDefault(_delightDesignerContentRegion, false);
                    Delight.ScrollableRegion.HorizontalScrollbarVisibilityProperty.SetDefault(_delightDesignerContentRegion, Delight.ScrollbarVisibilityMode.Remove);
                    Delight.ScrollableRegion.VerticalScrollbarVisibilityProperty.SetDefault(_delightDesignerContentRegion, Delight.ScrollbarVisibilityMode.Remove);
                    Delight.ScrollableRegion.ContentRegionTemplateProperty.SetDefault(_delightDesignerContentRegion, DelightDesignerContentRegionContentRegion);
                    Delight.ScrollableRegion.HorizontalScrollbarTemplateProperty.SetDefault(_delightDesignerContentRegion, DelightDesignerContentRegionHorizontalScrollbar);
                    Delight.ScrollableRegion.VerticalScrollbarTemplateProperty.SetDefault(_delightDesignerContentRegion, DelightDesignerContentRegionVerticalScrollbar);
                }
                return _delightDesignerContentRegion;
            }
        }

        private static Template _delightDesignerContentRegionContentRegion;
        public static Template DelightDesignerContentRegionContentRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerContentRegionContentRegion == null || _delightDesignerContentRegionContentRegion.CurrentVersion != Template.Version)
#else
                if (_delightDesignerContentRegionContentRegion == null)
#endif
                {
                    _delightDesignerContentRegionContentRegion = new Template(ScrollableRegionTemplates.ScrollableRegionContentRegion);
#if UNITY_EDITOR
                    _delightDesignerContentRegionContentRegion.Name = "DelightDesignerContentRegionContentRegion";
#endif
                }
                return _delightDesignerContentRegionContentRegion;
            }
        }

        private static Template _delightDesignerContentRegionHorizontalScrollbar;
        public static Template DelightDesignerContentRegionHorizontalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerContentRegionHorizontalScrollbar == null || _delightDesignerContentRegionHorizontalScrollbar.CurrentVersion != Template.Version)
#else
                if (_delightDesignerContentRegionHorizontalScrollbar == null)
#endif
                {
                    _delightDesignerContentRegionHorizontalScrollbar = new Template(ScrollableRegionTemplates.ScrollableRegionHorizontalScrollbar);
#if UNITY_EDITOR
                    _delightDesignerContentRegionHorizontalScrollbar.Name = "DelightDesignerContentRegionHorizontalScrollbar";
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_delightDesignerContentRegionHorizontalScrollbar, DelightDesignerContentRegionHorizontalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_delightDesignerContentRegionHorizontalScrollbar, DelightDesignerContentRegionHorizontalScrollbarHandle);
                }
                return _delightDesignerContentRegionHorizontalScrollbar;
            }
        }

        private static Template _delightDesignerContentRegionHorizontalScrollbarBar;
        public static Template DelightDesignerContentRegionHorizontalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerContentRegionHorizontalScrollbarBar == null || _delightDesignerContentRegionHorizontalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_delightDesignerContentRegionHorizontalScrollbarBar == null)
#endif
                {
                    _delightDesignerContentRegionHorizontalScrollbarBar = new Template(ScrollableRegionTemplates.ScrollableRegionHorizontalScrollbarBar);
#if UNITY_EDITOR
                    _delightDesignerContentRegionHorizontalScrollbarBar.Name = "DelightDesignerContentRegionHorizontalScrollbarBar";
#endif
                }
                return _delightDesignerContentRegionHorizontalScrollbarBar;
            }
        }

        private static Template _delightDesignerContentRegionHorizontalScrollbarHandle;
        public static Template DelightDesignerContentRegionHorizontalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerContentRegionHorizontalScrollbarHandle == null || _delightDesignerContentRegionHorizontalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_delightDesignerContentRegionHorizontalScrollbarHandle == null)
#endif
                {
                    _delightDesignerContentRegionHorizontalScrollbarHandle = new Template(ScrollableRegionTemplates.ScrollableRegionHorizontalScrollbarHandle);
#if UNITY_EDITOR
                    _delightDesignerContentRegionHorizontalScrollbarHandle.Name = "DelightDesignerContentRegionHorizontalScrollbarHandle";
#endif
                }
                return _delightDesignerContentRegionHorizontalScrollbarHandle;
            }
        }

        private static Template _delightDesignerContentRegionVerticalScrollbar;
        public static Template DelightDesignerContentRegionVerticalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerContentRegionVerticalScrollbar == null || _delightDesignerContentRegionVerticalScrollbar.CurrentVersion != Template.Version)
#else
                if (_delightDesignerContentRegionVerticalScrollbar == null)
#endif
                {
                    _delightDesignerContentRegionVerticalScrollbar = new Template(ScrollableRegionTemplates.ScrollableRegionVerticalScrollbar);
#if UNITY_EDITOR
                    _delightDesignerContentRegionVerticalScrollbar.Name = "DelightDesignerContentRegionVerticalScrollbar";
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_delightDesignerContentRegionVerticalScrollbar, DelightDesignerContentRegionVerticalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_delightDesignerContentRegionVerticalScrollbar, DelightDesignerContentRegionVerticalScrollbarHandle);
                }
                return _delightDesignerContentRegionVerticalScrollbar;
            }
        }

        private static Template _delightDesignerContentRegionVerticalScrollbarBar;
        public static Template DelightDesignerContentRegionVerticalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerContentRegionVerticalScrollbarBar == null || _delightDesignerContentRegionVerticalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_delightDesignerContentRegionVerticalScrollbarBar == null)
#endif
                {
                    _delightDesignerContentRegionVerticalScrollbarBar = new Template(ScrollableRegionTemplates.ScrollableRegionVerticalScrollbarBar);
#if UNITY_EDITOR
                    _delightDesignerContentRegionVerticalScrollbarBar.Name = "DelightDesignerContentRegionVerticalScrollbarBar";
#endif
                }
                return _delightDesignerContentRegionVerticalScrollbarBar;
            }
        }

        private static Template _delightDesignerContentRegionVerticalScrollbarHandle;
        public static Template DelightDesignerContentRegionVerticalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerContentRegionVerticalScrollbarHandle == null || _delightDesignerContentRegionVerticalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_delightDesignerContentRegionVerticalScrollbarHandle == null)
#endif
                {
                    _delightDesignerContentRegionVerticalScrollbarHandle = new Template(ScrollableRegionTemplates.ScrollableRegionVerticalScrollbarHandle);
#if UNITY_EDITOR
                    _delightDesignerContentRegionVerticalScrollbarHandle.Name = "DelightDesignerContentRegionVerticalScrollbarHandle";
#endif
                }
                return _delightDesignerContentRegionVerticalScrollbarHandle;
            }
        }

        private static Template _delightDesignerGridBackgroundRegion;
        public static Template DelightDesignerGridBackgroundRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerGridBackgroundRegion == null || _delightDesignerGridBackgroundRegion.CurrentVersion != Template.Version)
#else
                if (_delightDesignerGridBackgroundRegion == null)
#endif
                {
                    _delightDesignerGridBackgroundRegion = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _delightDesignerGridBackgroundRegion.Name = "DelightDesignerGridBackgroundRegion";
#endif
                    Delight.Region.WidthProperty.SetDefault(_delightDesignerGridBackgroundRegion, new ElementSize(1000f, ElementSizeUnit.Pixels));
                    Delight.Region.HeightProperty.SetDefault(_delightDesignerGridBackgroundRegion, new ElementSize(1000f, ElementSizeUnit.Pixels));
                }
                return _delightDesignerGridBackgroundRegion;
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

        private static Template _delightDesignerViewRegion;
        public static Template DelightDesignerViewRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerViewRegion == null || _delightDesignerViewRegion.CurrentVersion != Template.Version)
#else
                if (_delightDesignerViewRegion == null)
#endif
                {
                    _delightDesignerViewRegion = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _delightDesignerViewRegion.Name = "DelightDesignerViewRegion";
#endif
                }
                return _delightDesignerViewRegion;
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
                    Delight.Region.BackgroundColorProperty.SetDefault(_delightDesignerRegion1, new UnityEngine.Color(0.7019608f, 0.7019608f, 0.7019608f, 1f));
                }
                return _delightDesignerRegion1;
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
                    Delight.List.HeightProperty.SetDefault(_delightDesignerList1, new ElementSize(1f, ElementSizeUnit.Percents));
                    Delight.List.SelectOnMouseUpProperty.SetDefault(_delightDesignerList1, true);
                    Delight.List.ItemsProperty.SetHasBinding(_delightDesignerList1);
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
                    Delight.ScrollableRegion.ContentAlignmentProperty.SetDefault(_delightDesignerList1ScrollableRegion, Delight.ElementAlignment.Top);
                    Delight.ScrollableRegion.DisableInteractionScrollDeltaProperty.SetDefault(_delightDesignerList1ScrollableRegion, 1f);
                    Delight.ScrollableRegion.HasInertiaProperty.SetDefault(_delightDesignerList1ScrollableRegion, false);
                    Delight.ScrollableRegion.ContentRegionTemplateProperty.SetDefault(_delightDesignerList1ScrollableRegion, DelightDesignerList1ScrollableRegionContentRegion);
                    Delight.ScrollableRegion.HorizontalScrollbarTemplateProperty.SetDefault(_delightDesignerList1ScrollableRegion, DelightDesignerList1ScrollableRegionHorizontalScrollbar);
                    Delight.ScrollableRegion.VerticalScrollbarTemplateProperty.SetDefault(_delightDesignerList1ScrollableRegion, DelightDesignerList1ScrollableRegionVerticalScrollbar);
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

        private static Template _delightDesignerList1ScrollableRegionHorizontalScrollbar;
        public static Template DelightDesignerList1ScrollableRegionHorizontalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerList1ScrollableRegionHorizontalScrollbar == null || _delightDesignerList1ScrollableRegionHorizontalScrollbar.CurrentVersion != Template.Version)
#else
                if (_delightDesignerList1ScrollableRegionHorizontalScrollbar == null)
#endif
                {
                    _delightDesignerList1ScrollableRegionHorizontalScrollbar = new Template(ListTemplates.ListScrollableRegionHorizontalScrollbar);
#if UNITY_EDITOR
                    _delightDesignerList1ScrollableRegionHorizontalScrollbar.Name = "DelightDesignerList1ScrollableRegionHorizontalScrollbar";
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_delightDesignerList1ScrollableRegionHorizontalScrollbar, DelightDesignerList1ScrollableRegionHorizontalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_delightDesignerList1ScrollableRegionHorizontalScrollbar, DelightDesignerList1ScrollableRegionHorizontalScrollbarHandle);
                }
                return _delightDesignerList1ScrollableRegionHorizontalScrollbar;
            }
        }

        private static Template _delightDesignerList1ScrollableRegionHorizontalScrollbarBar;
        public static Template DelightDesignerList1ScrollableRegionHorizontalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerList1ScrollableRegionHorizontalScrollbarBar == null || _delightDesignerList1ScrollableRegionHorizontalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_delightDesignerList1ScrollableRegionHorizontalScrollbarBar == null)
#endif
                {
                    _delightDesignerList1ScrollableRegionHorizontalScrollbarBar = new Template(ListTemplates.ListScrollableRegionHorizontalScrollbarBar);
#if UNITY_EDITOR
                    _delightDesignerList1ScrollableRegionHorizontalScrollbarBar.Name = "DelightDesignerList1ScrollableRegionHorizontalScrollbarBar";
#endif
                }
                return _delightDesignerList1ScrollableRegionHorizontalScrollbarBar;
            }
        }

        private static Template _delightDesignerList1ScrollableRegionHorizontalScrollbarHandle;
        public static Template DelightDesignerList1ScrollableRegionHorizontalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerList1ScrollableRegionHorizontalScrollbarHandle == null || _delightDesignerList1ScrollableRegionHorizontalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_delightDesignerList1ScrollableRegionHorizontalScrollbarHandle == null)
#endif
                {
                    _delightDesignerList1ScrollableRegionHorizontalScrollbarHandle = new Template(ListTemplates.ListScrollableRegionHorizontalScrollbarHandle);
#if UNITY_EDITOR
                    _delightDesignerList1ScrollableRegionHorizontalScrollbarHandle.Name = "DelightDesignerList1ScrollableRegionHorizontalScrollbarHandle";
#endif
                }
                return _delightDesignerList1ScrollableRegionHorizontalScrollbarHandle;
            }
        }

        private static Template _delightDesignerList1ScrollableRegionVerticalScrollbar;
        public static Template DelightDesignerList1ScrollableRegionVerticalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerList1ScrollableRegionVerticalScrollbar == null || _delightDesignerList1ScrollableRegionVerticalScrollbar.CurrentVersion != Template.Version)
#else
                if (_delightDesignerList1ScrollableRegionVerticalScrollbar == null)
#endif
                {
                    _delightDesignerList1ScrollableRegionVerticalScrollbar = new Template(ListTemplates.ListScrollableRegionVerticalScrollbar);
#if UNITY_EDITOR
                    _delightDesignerList1ScrollableRegionVerticalScrollbar.Name = "DelightDesignerList1ScrollableRegionVerticalScrollbar";
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_delightDesignerList1ScrollableRegionVerticalScrollbar, DelightDesignerList1ScrollableRegionVerticalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_delightDesignerList1ScrollableRegionVerticalScrollbar, DelightDesignerList1ScrollableRegionVerticalScrollbarHandle);
                }
                return _delightDesignerList1ScrollableRegionVerticalScrollbar;
            }
        }

        private static Template _delightDesignerList1ScrollableRegionVerticalScrollbarBar;
        public static Template DelightDesignerList1ScrollableRegionVerticalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerList1ScrollableRegionVerticalScrollbarBar == null || _delightDesignerList1ScrollableRegionVerticalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_delightDesignerList1ScrollableRegionVerticalScrollbarBar == null)
#endif
                {
                    _delightDesignerList1ScrollableRegionVerticalScrollbarBar = new Template(ListTemplates.ListScrollableRegionVerticalScrollbarBar);
#if UNITY_EDITOR
                    _delightDesignerList1ScrollableRegionVerticalScrollbarBar.Name = "DelightDesignerList1ScrollableRegionVerticalScrollbarBar";
#endif
                }
                return _delightDesignerList1ScrollableRegionVerticalScrollbarBar;
            }
        }

        private static Template _delightDesignerList1ScrollableRegionVerticalScrollbarHandle;
        public static Template DelightDesignerList1ScrollableRegionVerticalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerList1ScrollableRegionVerticalScrollbarHandle == null || _delightDesignerList1ScrollableRegionVerticalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_delightDesignerList1ScrollableRegionVerticalScrollbarHandle == null)
#endif
                {
                    _delightDesignerList1ScrollableRegionVerticalScrollbarHandle = new Template(ListTemplates.ListScrollableRegionVerticalScrollbarHandle);
#if UNITY_EDITOR
                    _delightDesignerList1ScrollableRegionVerticalScrollbarHandle.Name = "DelightDesignerList1ScrollableRegionVerticalScrollbarHandle";
#endif
                }
                return _delightDesignerList1ScrollableRegionVerticalScrollbarHandle;
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
                    Delight.Label.FontSizeProperty.SetDefault(_delightDesignerLabel1, 16);
                    Delight.Label.HeightProperty.SetDefault(_delightDesignerLabel1, new ElementSize(24f, ElementSizeUnit.Pixels));
                    Delight.Label.FontProperty.SetDefault(_delightDesignerLabel1, Assets.Fonts["Ebrima"]);
                    Delight.Label.WidthProperty.SetDefault(_delightDesignerLabel1, new ElementSize(240f, ElementSizeUnit.Pixels));
                    Delight.Label.EnableWordWrappingProperty.SetDefault(_delightDesignerLabel1, false);
                    Delight.Label.MarginProperty.SetDefault(_delightDesignerLabel1, new ElementMargin(new ElementSize(25f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels)));
                    Delight.Label.OverflowModeProperty.SetDefault(_delightDesignerLabel1, "Ellipsis");
                    Delight.Label.ExtraPaddingProperty.SetDefault(_delightDesignerLabel1, true);
                    Delight.Label.FontColorProperty.SetDefault(_delightDesignerLabel1, new UnityEngine.Color(0.1411765f, 0.1411765f, 0.1411765f, 1f));
                    Delight.Label.TextProperty.SetHasBinding(_delightDesignerLabel1);
                }
                return _delightDesignerLabel1;
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
                    Delight.Region.BackgroundColorProperty.SetDefault(_delightDesignerRegion2, new UnityEngine.Color(0.6392157f, 0.6352941f, 0.6392157f, 1f));
                }
                return _delightDesignerRegion2;
            }
        }

        #endregion
    }

    #endregion
}
