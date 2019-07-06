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
            ScrollableContentRegion = new ScrollableRegion(this, Grid1.Content, "ScrollableContentRegion", ScrollableContentRegionTemplate);
            ScrollableContentRegion.Scroll.RegisterHandler(this, "OnScroll");
            Grid1.Cell.SetValue(ScrollableContentRegion, new CellIndex(1, 1));
            Grid1.CellSpan.SetValue(ScrollableContentRegion, new CellIndex(1, 2));
            ContentRegionCanvas = new UICanvas(this, ScrollableContentRegion.Content, "ContentRegionCanvas", ContentRegionCanvasTemplate);
            ViewContentRegion = new Region(this, ContentRegionCanvas.Content, "ViewContentRegion", ViewContentRegionTemplate);
            Region1 = new Region(this, Grid1.Content, "Region1", Region1Template);
            Grid1.Cell.SetValue(Region1, new CellIndex(0, 0));
            Grid1.CellSpan.SetValue(Region1, new CellIndex(2, 1));
            List1 = new List(this, Region1.Content, "List1", List1Template);
            List1.ItemSelected.RegisterHandler(this, "ViewSelected");

            // binding <List Items="{view in DesignerViews}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "DesignerViews" }, new List<Func<BindableObject>> { () => this }) }, new BindingPath(new List<string> { "List1", "Items" }, new List<Func<BindableObject>> { () => this, () => List1 }), () => List1.Items = DesignerViews, () => { }, false));

            // templates for List1
            List1.ContentTemplates.Add(new ContentTemplate(tiView => 
            {
                var list1Content = new ListItem(this, List1.Content, "List1Content", List1ContentTemplate);
                var label1 = new Label(this, list1Content.Content, "Label1", Label1Template);

                // binding <Label Text="{view.Name}">
                list1Content.Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "Item", "Name" }, new List<Func<BindableObject>> { () => tiView, () => (tiView.Item as Delight.DesignerView) }) }, new BindingPath(new List<string> { "Text" }, new List<Func<BindableObject>> { () => label1 }), () => label1.Text = (tiView.Item as Delight.DesignerView).Name, () => { }, false));
                list1Content.ContentTemplateData = tiView;
                return list1Content;
            }, typeof(ListItem), "List1Content"));
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
            dependencyProperties.Add(ScrollableContentRegionProperty);
            dependencyProperties.Add(ScrollableContentRegionTemplateProperty);
            dependencyProperties.Add(ContentRegionCanvasProperty);
            dependencyProperties.Add(ContentRegionCanvasTemplateProperty);
            dependencyProperties.Add(ViewContentRegionProperty);
            dependencyProperties.Add(ViewContentRegionTemplateProperty);
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

        public readonly static DependencyProperty<ScrollableRegion> ScrollableContentRegionProperty = new DependencyProperty<ScrollableRegion>("ScrollableContentRegion");
        public ScrollableRegion ScrollableContentRegion
        {
            get { return ScrollableContentRegionProperty.GetValue(this); }
            set { ScrollableContentRegionProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> ScrollableContentRegionTemplateProperty = new DependencyProperty<Template>("ScrollableContentRegionTemplate");
        public Template ScrollableContentRegionTemplate
        {
            get { return ScrollableContentRegionTemplateProperty.GetValue(this); }
            set { ScrollableContentRegionTemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<UICanvas> ContentRegionCanvasProperty = new DependencyProperty<UICanvas>("ContentRegionCanvas");
        public UICanvas ContentRegionCanvas
        {
            get { return ContentRegionCanvasProperty.GetValue(this); }
            set { ContentRegionCanvasProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> ContentRegionCanvasTemplateProperty = new DependencyProperty<Template>("ContentRegionCanvasTemplate");
        public Template ContentRegionCanvasTemplate
        {
            get { return ContentRegionCanvasTemplateProperty.GetValue(this); }
            set { ContentRegionCanvasTemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> ViewContentRegionProperty = new DependencyProperty<Region>("ViewContentRegion");
        public Region ViewContentRegion
        {
            get { return ViewContentRegionProperty.GetValue(this); }
            set { ViewContentRegionProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> ViewContentRegionTemplateProperty = new DependencyProperty<Template>("ViewContentRegionTemplate");
        public Template ViewContentRegionTemplate
        {
            get { return ViewContentRegionTemplateProperty.GetValue(this); }
            set { ViewContentRegionTemplateProperty.SetValue(this, value); }
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
                    Delight.DelightDesigner.ScrollableContentRegionTemplateProperty.SetDefault(_delightDesigner, DelightDesignerScrollableContentRegion);
                    Delight.DelightDesigner.ContentRegionCanvasTemplateProperty.SetDefault(_delightDesigner, DelightDesignerContentRegionCanvas);
                    Delight.DelightDesigner.ViewContentRegionTemplateProperty.SetDefault(_delightDesigner, DelightDesignerViewContentRegion);
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

        private static Template _delightDesignerScrollableContentRegion;
        public static Template DelightDesignerScrollableContentRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerScrollableContentRegion == null || _delightDesignerScrollableContentRegion.CurrentVersion != Template.Version)
#else
                if (_delightDesignerScrollableContentRegion == null)
#endif
                {
                    _delightDesignerScrollableContentRegion = new Template(ScrollableRegionTemplates.ScrollableRegion);
#if UNITY_EDITOR
                    _delightDesignerScrollableContentRegion.Name = "DelightDesignerScrollableContentRegion";
#endif
                    Delight.ScrollableRegion.HasInertiaProperty.SetDefault(_delightDesignerScrollableContentRegion, false);
                    Delight.ScrollableRegion.DisableMouseWheelProperty.SetDefault(_delightDesignerScrollableContentRegion, true);
                    Delight.ScrollableRegion.HorizontalScrollbarVisibilityProperty.SetDefault(_delightDesignerScrollableContentRegion, Delight.ScrollbarVisibilityMode.Remove);
                    Delight.ScrollableRegion.VerticalScrollbarVisibilityProperty.SetDefault(_delightDesignerScrollableContentRegion, Delight.ScrollbarVisibilityMode.Remove);
                    Delight.ScrollableRegion.ContentRegionTemplateProperty.SetDefault(_delightDesignerScrollableContentRegion, DelightDesignerScrollableContentRegionContentRegion);
                    Delight.ScrollableRegion.HorizontalScrollbarTemplateProperty.SetDefault(_delightDesignerScrollableContentRegion, DelightDesignerScrollableContentRegionHorizontalScrollbar);
                    Delight.ScrollableRegion.VerticalScrollbarTemplateProperty.SetDefault(_delightDesignerScrollableContentRegion, DelightDesignerScrollableContentRegionVerticalScrollbar);
                }
                return _delightDesignerScrollableContentRegion;
            }
        }

        private static Template _delightDesignerScrollableContentRegionContentRegion;
        public static Template DelightDesignerScrollableContentRegionContentRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerScrollableContentRegionContentRegion == null || _delightDesignerScrollableContentRegionContentRegion.CurrentVersion != Template.Version)
#else
                if (_delightDesignerScrollableContentRegionContentRegion == null)
#endif
                {
                    _delightDesignerScrollableContentRegionContentRegion = new Template(ScrollableRegionTemplates.ScrollableRegionContentRegion);
#if UNITY_EDITOR
                    _delightDesignerScrollableContentRegionContentRegion.Name = "DelightDesignerScrollableContentRegionContentRegion";
#endif
                }
                return _delightDesignerScrollableContentRegionContentRegion;
            }
        }

        private static Template _delightDesignerScrollableContentRegionHorizontalScrollbar;
        public static Template DelightDesignerScrollableContentRegionHorizontalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerScrollableContentRegionHorizontalScrollbar == null || _delightDesignerScrollableContentRegionHorizontalScrollbar.CurrentVersion != Template.Version)
#else
                if (_delightDesignerScrollableContentRegionHorizontalScrollbar == null)
#endif
                {
                    _delightDesignerScrollableContentRegionHorizontalScrollbar = new Template(ScrollableRegionTemplates.ScrollableRegionHorizontalScrollbar);
#if UNITY_EDITOR
                    _delightDesignerScrollableContentRegionHorizontalScrollbar.Name = "DelightDesignerScrollableContentRegionHorizontalScrollbar";
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_delightDesignerScrollableContentRegionHorizontalScrollbar, DelightDesignerScrollableContentRegionHorizontalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_delightDesignerScrollableContentRegionHorizontalScrollbar, DelightDesignerScrollableContentRegionHorizontalScrollbarHandle);
                }
                return _delightDesignerScrollableContentRegionHorizontalScrollbar;
            }
        }

        private static Template _delightDesignerScrollableContentRegionHorizontalScrollbarBar;
        public static Template DelightDesignerScrollableContentRegionHorizontalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerScrollableContentRegionHorizontalScrollbarBar == null || _delightDesignerScrollableContentRegionHorizontalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_delightDesignerScrollableContentRegionHorizontalScrollbarBar == null)
#endif
                {
                    _delightDesignerScrollableContentRegionHorizontalScrollbarBar = new Template(ScrollableRegionTemplates.ScrollableRegionHorizontalScrollbarBar);
#if UNITY_EDITOR
                    _delightDesignerScrollableContentRegionHorizontalScrollbarBar.Name = "DelightDesignerScrollableContentRegionHorizontalScrollbarBar";
#endif
                }
                return _delightDesignerScrollableContentRegionHorizontalScrollbarBar;
            }
        }

        private static Template _delightDesignerScrollableContentRegionHorizontalScrollbarHandle;
        public static Template DelightDesignerScrollableContentRegionHorizontalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerScrollableContentRegionHorizontalScrollbarHandle == null || _delightDesignerScrollableContentRegionHorizontalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_delightDesignerScrollableContentRegionHorizontalScrollbarHandle == null)
#endif
                {
                    _delightDesignerScrollableContentRegionHorizontalScrollbarHandle = new Template(ScrollableRegionTemplates.ScrollableRegionHorizontalScrollbarHandle);
#if UNITY_EDITOR
                    _delightDesignerScrollableContentRegionHorizontalScrollbarHandle.Name = "DelightDesignerScrollableContentRegionHorizontalScrollbarHandle";
#endif
                }
                return _delightDesignerScrollableContentRegionHorizontalScrollbarHandle;
            }
        }

        private static Template _delightDesignerScrollableContentRegionVerticalScrollbar;
        public static Template DelightDesignerScrollableContentRegionVerticalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerScrollableContentRegionVerticalScrollbar == null || _delightDesignerScrollableContentRegionVerticalScrollbar.CurrentVersion != Template.Version)
#else
                if (_delightDesignerScrollableContentRegionVerticalScrollbar == null)
#endif
                {
                    _delightDesignerScrollableContentRegionVerticalScrollbar = new Template(ScrollableRegionTemplates.ScrollableRegionVerticalScrollbar);
#if UNITY_EDITOR
                    _delightDesignerScrollableContentRegionVerticalScrollbar.Name = "DelightDesignerScrollableContentRegionVerticalScrollbar";
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_delightDesignerScrollableContentRegionVerticalScrollbar, DelightDesignerScrollableContentRegionVerticalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_delightDesignerScrollableContentRegionVerticalScrollbar, DelightDesignerScrollableContentRegionVerticalScrollbarHandle);
                }
                return _delightDesignerScrollableContentRegionVerticalScrollbar;
            }
        }

        private static Template _delightDesignerScrollableContentRegionVerticalScrollbarBar;
        public static Template DelightDesignerScrollableContentRegionVerticalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerScrollableContentRegionVerticalScrollbarBar == null || _delightDesignerScrollableContentRegionVerticalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_delightDesignerScrollableContentRegionVerticalScrollbarBar == null)
#endif
                {
                    _delightDesignerScrollableContentRegionVerticalScrollbarBar = new Template(ScrollableRegionTemplates.ScrollableRegionVerticalScrollbarBar);
#if UNITY_EDITOR
                    _delightDesignerScrollableContentRegionVerticalScrollbarBar.Name = "DelightDesignerScrollableContentRegionVerticalScrollbarBar";
#endif
                }
                return _delightDesignerScrollableContentRegionVerticalScrollbarBar;
            }
        }

        private static Template _delightDesignerScrollableContentRegionVerticalScrollbarHandle;
        public static Template DelightDesignerScrollableContentRegionVerticalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerScrollableContentRegionVerticalScrollbarHandle == null || _delightDesignerScrollableContentRegionVerticalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_delightDesignerScrollableContentRegionVerticalScrollbarHandle == null)
#endif
                {
                    _delightDesignerScrollableContentRegionVerticalScrollbarHandle = new Template(ScrollableRegionTemplates.ScrollableRegionVerticalScrollbarHandle);
#if UNITY_EDITOR
                    _delightDesignerScrollableContentRegionVerticalScrollbarHandle.Name = "DelightDesignerScrollableContentRegionVerticalScrollbarHandle";
#endif
                }
                return _delightDesignerScrollableContentRegionVerticalScrollbarHandle;
            }
        }

        private static Template _delightDesignerContentRegionCanvas;
        public static Template DelightDesignerContentRegionCanvas
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerContentRegionCanvas == null || _delightDesignerContentRegionCanvas.CurrentVersion != Template.Version)
#else
                if (_delightDesignerContentRegionCanvas == null)
#endif
                {
                    _delightDesignerContentRegionCanvas = new Template(UICanvasTemplates.UICanvas);
#if UNITY_EDITOR
                    _delightDesignerContentRegionCanvas.Name = "DelightDesignerContentRegionCanvas";
#endif
                    Delight.UICanvas.ScaleProperty.SetDefault(_delightDesignerContentRegionCanvas, new Vector3(1f, 1f, 1f));
                }
                return _delightDesignerContentRegionCanvas;
            }
        }

        private static Template _delightDesignerViewContentRegion;
        public static Template DelightDesignerViewContentRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerViewContentRegion == null || _delightDesignerViewContentRegion.CurrentVersion != Template.Version)
#else
                if (_delightDesignerViewContentRegion == null)
#endif
                {
                    _delightDesignerViewContentRegion = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _delightDesignerViewContentRegion.Name = "DelightDesignerViewContentRegion";
#endif
                }
                return _delightDesignerViewContentRegion;
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
                    Delight.List.CanReselectProperty.SetDefault(_delightDesignerList1, true);
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
