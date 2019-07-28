#if DELIGHT_MODULE_TEXTMESHPRO

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
            Grid1.Cell.SetValue(ScrollableContentRegion, new CellIndex(0, 2));
            ContentRegionCanvas = new UICanvas(this, ScrollableContentRegion.Content, "ContentRegionCanvas", ContentRegionCanvasTemplate);
            ViewContentRegion = new Region(this, ContentRegionCanvas.Content, "ViewContentRegion", ViewContentRegionTemplate);
            ContentExplorer = new Region(this, Grid1.Content, "ContentExplorer", ContentExplorerTemplate);
            Grid1.Cell.SetValue(ContentExplorer, new CellIndex(0, 0));
            Label1 = new Label(this, ContentExplorer.Content, "Label1", Label1Template);
            List1 = new List(this, ContentExplorer.Content, "List1", List1Template);
            List1.ItemSelected.RegisterHandler(this, "ViewSelected");

            // binding <List Items="{view in DesignerViews}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "DesignerViews" }, new List<Func<BindableObject>> { () => this }) }, new BindingPath(new List<string> { "List1", "Items" }, new List<Func<BindableObject>> { () => this, () => List1 }), () => List1.Items = DesignerViews, () => { }, false));

            // templates for List1
            List1.ContentTemplates.Add(new ContentTemplate(tiView => 
            {
                var listItem1 = new ListItem(this, List1.Content, "ListItem1", ListItem1Template);
                var label2 = new Label(this, listItem1.Content, "Label2", Label2Template);

                // binding <Label Text="{view.DisplayName}">
                listItem1.Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "Item", "DisplayName" }, new List<Func<BindableObject>> { () => tiView, () => (tiView.Item as Delight.DesignerView) }) }, new BindingPath(new List<string> { "Text" }, new List<Func<BindableObject>> { () => label2 }), () => label2.Text = (tiView.Item as Delight.DesignerView).DisplayName, () => { }, false));
                listItem1.IsDynamic = true;
                listItem1.SetContentTemplateData(tiView);
                return listItem1;
            }, typeof(ListItem), "ListItem1"));
            XmlEditorRegion = new Region(this, Grid1.Content, "XmlEditorRegion", XmlEditorRegionTemplate);
            Grid1.Cell.SetValue(XmlEditorRegion, new CellIndex(0, 1));
            XmlEditor = new XmlEditor(this, XmlEditorRegion.Content, "XmlEditor", XmlEditorTemplate);
            XmlEditor.Edit.RegisterHandler(this, "OnEdit");
            GridSplitter1 = new GridSplitter(this, Grid1.Content, "GridSplitter1", GridSplitter1Template);
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
            dependencyProperties.Add(XmlTextProperty);
            dependencyProperties.Add(Grid1Property);
            dependencyProperties.Add(Grid1TemplateProperty);
            dependencyProperties.Add(ScrollableContentRegionProperty);
            dependencyProperties.Add(ScrollableContentRegionTemplateProperty);
            dependencyProperties.Add(ContentRegionCanvasProperty);
            dependencyProperties.Add(ContentRegionCanvasTemplateProperty);
            dependencyProperties.Add(ViewContentRegionProperty);
            dependencyProperties.Add(ViewContentRegionTemplateProperty);
            dependencyProperties.Add(ContentExplorerProperty);
            dependencyProperties.Add(ContentExplorerTemplateProperty);
            dependencyProperties.Add(Label1Property);
            dependencyProperties.Add(Label1TemplateProperty);
            dependencyProperties.Add(List1Property);
            dependencyProperties.Add(List1TemplateProperty);
            dependencyProperties.Add(ListItem1Property);
            dependencyProperties.Add(ListItem1TemplateProperty);
            dependencyProperties.Add(Label2Property);
            dependencyProperties.Add(Label2TemplateProperty);
            dependencyProperties.Add(XmlEditorRegionProperty);
            dependencyProperties.Add(XmlEditorRegionTemplateProperty);
            dependencyProperties.Add(XmlEditorProperty);
            dependencyProperties.Add(XmlEditorTemplateProperty);
            dependencyProperties.Add(GridSplitter1Property);
            dependencyProperties.Add(GridSplitter1TemplateProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<Delight.DesignerViewData> DesignerViewsProperty = new DependencyProperty<Delight.DesignerViewData>("DesignerViews");
        public Delight.DesignerViewData DesignerViews
        {
            get { return DesignerViewsProperty.GetValue(this); }
            set { DesignerViewsProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.String> XmlTextProperty = new DependencyProperty<System.String>("XmlText");
        public System.String XmlText
        {
            get { return XmlTextProperty.GetValue(this); }
            set { XmlTextProperty.SetValue(this, value); }
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

        public readonly static DependencyProperty<Region> ContentExplorerProperty = new DependencyProperty<Region>("ContentExplorer");
        public Region ContentExplorer
        {
            get { return ContentExplorerProperty.GetValue(this); }
            set { ContentExplorerProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> ContentExplorerTemplateProperty = new DependencyProperty<Template>("ContentExplorerTemplate");
        public Template ContentExplorerTemplate
        {
            get { return ContentExplorerTemplateProperty.GetValue(this); }
            set { ContentExplorerTemplateProperty.SetValue(this, value); }
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

        public readonly static DependencyProperty<ListItem> ListItem1Property = new DependencyProperty<ListItem>("ListItem1");
        public ListItem ListItem1
        {
            get { return ListItem1Property.GetValue(this); }
            set { ListItem1Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> ListItem1TemplateProperty = new DependencyProperty<Template>("ListItem1Template");
        public Template ListItem1Template
        {
            get { return ListItem1TemplateProperty.GetValue(this); }
            set { ListItem1TemplateProperty.SetValue(this, value); }
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

        public readonly static DependencyProperty<Region> XmlEditorRegionProperty = new DependencyProperty<Region>("XmlEditorRegion");
        public Region XmlEditorRegion
        {
            get { return XmlEditorRegionProperty.GetValue(this); }
            set { XmlEditorRegionProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> XmlEditorRegionTemplateProperty = new DependencyProperty<Template>("XmlEditorRegionTemplate");
        public Template XmlEditorRegionTemplate
        {
            get { return XmlEditorRegionTemplateProperty.GetValue(this); }
            set { XmlEditorRegionTemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<XmlEditor> XmlEditorProperty = new DependencyProperty<XmlEditor>("XmlEditor");
        public XmlEditor XmlEditor
        {
            get { return XmlEditorProperty.GetValue(this); }
            set { XmlEditorProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> XmlEditorTemplateProperty = new DependencyProperty<Template>("XmlEditorTemplate");
        public Template XmlEditorTemplate
        {
            get { return XmlEditorTemplateProperty.GetValue(this); }
            set { XmlEditorTemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<GridSplitter> GridSplitter1Property = new DependencyProperty<GridSplitter>("GridSplitter1");
        public GridSplitter GridSplitter1
        {
            get { return GridSplitter1Property.GetValue(this); }
            set { GridSplitter1Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> GridSplitter1TemplateProperty = new DependencyProperty<Template>("GridSplitter1Template");
        public Template GridSplitter1Template
        {
            get { return GridSplitter1TemplateProperty.GetValue(this); }
            set { GridSplitter1TemplateProperty.SetValue(this, value); }
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
                    Delight.DelightDesigner.ContentExplorerTemplateProperty.SetDefault(_delightDesigner, DelightDesignerContentExplorer);
                    Delight.DelightDesigner.Label1TemplateProperty.SetDefault(_delightDesigner, DelightDesignerLabel1);
                    Delight.DelightDesigner.List1TemplateProperty.SetDefault(_delightDesigner, DelightDesignerList1);
                    Delight.DelightDesigner.ListItem1TemplateProperty.SetDefault(_delightDesigner, DelightDesignerListItem1);
                    Delight.DelightDesigner.Label2TemplateProperty.SetDefault(_delightDesigner, DelightDesignerLabel2);
                    Delight.DelightDesigner.XmlEditorRegionTemplateProperty.SetDefault(_delightDesigner, DelightDesignerXmlEditorRegion);
                    Delight.DelightDesigner.XmlEditorTemplateProperty.SetDefault(_delightDesigner, DelightDesignerXmlEditor);
                    Delight.DelightDesigner.GridSplitter1TemplateProperty.SetDefault(_delightDesigner, DelightDesignerGridSplitter1);
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
                    Delight.LayoutGrid.ColumnsProperty.SetDefault(_delightDesignerGrid1, new ColumnDefinitions { new ColumnDefinition(new ElementSize(170f, ElementSizeUnit.Pixels), 20f), new ColumnDefinition(new ElementSize(450f, ElementSizeUnit.Pixels), 20f), new ColumnDefinition(new ElementSize(1f, ElementSizeUnit.Proportional))});
                    Delight.LayoutGrid.RowsProperty.SetDefault(_delightDesignerGrid1, new RowDefinitions { new RowDefinition(new ElementSize(1f, ElementSizeUnit.Proportional))});
                    Delight.LayoutGrid.BackgroundColorProperty.SetDefault(_delightDesignerGrid1, new UnityEngine.Color(0.3333333f, 0.6392157f, 1f, 1f));
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

        private static Template _delightDesignerContentExplorer;
        public static Template DelightDesignerContentExplorer
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerContentExplorer == null || _delightDesignerContentExplorer.CurrentVersion != Template.Version)
#else
                if (_delightDesignerContentExplorer == null)
#endif
                {
                    _delightDesignerContentExplorer = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _delightDesignerContentExplorer.Name = "DelightDesignerContentExplorer";
#endif
                    Delight.Region.BackgroundColorProperty.SetDefault(_delightDesignerContentExplorer, new UnityEngine.Color(0.7647059f, 0.7647059f, 0.7647059f, 1f));
                }
                return _delightDesignerContentExplorer;
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
                    Delight.Label.TextProperty.SetDefault(_delightDesignerLabel1, "Views");
                    Delight.Label.FontSizeProperty.SetDefault(_delightDesignerLabel1, 18f);
                    Delight.Label.FontProperty.SetDefault(_delightDesignerLabel1, Assets.TMP_FontAssets["Segoe UI SDF"]);
                    Delight.Label.AlignmentProperty.SetDefault(_delightDesignerLabel1, Delight.ElementAlignment.TopLeft);
                    Delight.Label.MarginProperty.SetDefault(_delightDesignerLabel1, new ElementMargin(new ElementSize(19f, ElementSizeUnit.Pixels), new ElementSize(10f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels)));
                    Delight.Label.HeightProperty.SetDefault(_delightDesignerLabel1, new ElementSize(40f, ElementSizeUnit.Pixels));
                    Delight.Label.TextAlignmentProperty.SetDefault(_delightDesignerLabel1, TMPro.TextAlignmentOptions.Left);
                    Delight.Label.WidthProperty.SetDefault(_delightDesignerLabel1, new ElementSize(1f, ElementSizeUnit.Percents));
                    Delight.Label.OverflowModeProperty.SetDefault(_delightDesignerLabel1, TMPro.TextOverflowModes.Truncate);
                    Delight.Label.FontColorProperty.SetDefault(_delightDesignerLabel1, new UnityEngine.Color(0.2f, 0.2f, 0.2f, 1f));
                }
                return _delightDesignerLabel1;
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
                    Delight.List.MarginProperty.SetDefault(_delightDesignerList1, new ElementMargin(new ElementSize(4f, ElementSizeUnit.Pixels), new ElementSize(50f, ElementSizeUnit.Pixels), new ElementSize(2f, ElementSizeUnit.Pixels), new ElementSize(2f, ElementSizeUnit.Pixels)));
                    Delight.List.BackgroundColorProperty.SetDefault(_delightDesignerList1, new UnityEngine.Color(0f, 0f, 0f, 0f));
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
                    Delight.ScrollableRegion.VerticalScrollbarVisibilityProperty.SetDefault(_delightDesignerList1ScrollableRegion, Delight.ScrollbarVisibilityMode.Remove);
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

        private static Template _delightDesignerListItem1;
        public static Template DelightDesignerListItem1
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerListItem1 == null || _delightDesignerListItem1.CurrentVersion != Template.Version)
#else
                if (_delightDesignerListItem1 == null)
#endif
                {
                    _delightDesignerListItem1 = new Template(ListItemTemplates.ListItem);
#if UNITY_EDITOR
                    _delightDesignerListItem1.Name = "DelightDesignerListItem1";
#endif
                    Delight.ListItem.BackgroundSpriteProperty.SetStateDefault("Pressed", _delightDesignerListItem1, Assets.Sprites["ListSelection"]);
                    Delight.ListItem.BackgroundSpriteProperty.SetStateDefault("Highlighted", _delightDesignerListItem1, Assets.Sprites["ListSelection"]);
                    Delight.ListItem.BackgroundColorProperty.SetStateDefault("Highlighted", _delightDesignerListItem1, new UnityEngine.Color(0.9764706f, 0.9764706f, 0.9764706f, 1f));
                    Delight.ListItem.BackgroundColorProperty.SetStateDefault("Selected", _delightDesignerListItem1, new UnityEngine.Color(0.9568627f, 0.9568627f, 0.9568627f, 1f));
                    Delight.ListItem.BackgroundColorProperty.SetStateDefault("Pressed", _delightDesignerListItem1, new UnityEngine.Color(0.9568627f, 0.9568627f, 0.9568627f, 1f));
                }
                return _delightDesignerListItem1;
            }
        }

        private static Template _delightDesignerLabel2;
        public static Template DelightDesignerLabel2
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerLabel2 == null || _delightDesignerLabel2.CurrentVersion != Template.Version)
#else
                if (_delightDesignerLabel2 == null)
#endif
                {
                    _delightDesignerLabel2 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _delightDesignerLabel2.Name = "DelightDesignerLabel2";
#endif
                    Delight.Label.FontSizeProperty.SetDefault(_delightDesignerLabel2, 16f);
                    Delight.Label.FontProperty.SetDefault(_delightDesignerLabel2, Assets.TMP_FontAssets["Segoe UI SDF"]);
                    Delight.Label.HeightProperty.SetDefault(_delightDesignerLabel2, new ElementSize(24f, ElementSizeUnit.Pixels));
                    Delight.Label.FontColorProperty.SetDefault(_delightDesignerLabel2, new UnityEngine.Color(0.2235294f, 0.2666667f, 0.3490196f, 1f));
                    Delight.Label.WidthProperty.SetDefault(_delightDesignerLabel2, new ElementSize(1f, ElementSizeUnit.Percents));
                    Delight.Label.MarginProperty.SetDefault(_delightDesignerLabel2, new ElementMargin(new ElementSize(16f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels)));
                    Delight.Label.EnableWordWrappingProperty.SetDefault(_delightDesignerLabel2, false);
                    Delight.Label.OverflowModeProperty.SetDefault(_delightDesignerLabel2, TMPro.TextOverflowModes.Truncate);
                    Delight.Label.ExtraPaddingProperty.SetDefault(_delightDesignerLabel2, true);
                    Delight.Label.TextProperty.SetHasBinding(_delightDesignerLabel2);
                }
                return _delightDesignerLabel2;
            }
        }

        private static Template _delightDesignerXmlEditorRegion;
        public static Template DelightDesignerXmlEditorRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerXmlEditorRegion == null || _delightDesignerXmlEditorRegion.CurrentVersion != Template.Version)
#else
                if (_delightDesignerXmlEditorRegion == null)
#endif
                {
                    _delightDesignerXmlEditorRegion = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _delightDesignerXmlEditorRegion.Name = "DelightDesignerXmlEditorRegion";
#endif
                    Delight.Region.BackgroundColorProperty.SetDefault(_delightDesignerXmlEditorRegion, new UnityEngine.Color(0.9843137f, 0.9843137f, 0.9843137f, 1f));
                }
                return _delightDesignerXmlEditorRegion;
            }
        }

        private static Template _delightDesignerXmlEditor;
        public static Template DelightDesignerXmlEditor
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerXmlEditor == null || _delightDesignerXmlEditor.CurrentVersion != Template.Version)
#else
                if (_delightDesignerXmlEditor == null)
#endif
                {
                    _delightDesignerXmlEditor = new Template(XmlEditorTemplates.XmlEditor);
#if UNITY_EDITOR
                    _delightDesignerXmlEditor.Name = "DelightDesignerXmlEditor";
#endif
                    Delight.XmlEditor.MarginProperty.SetDefault(_delightDesignerXmlEditor, new ElementMargin(new ElementSize(10f, ElementSizeUnit.Pixels), new ElementSize(21f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels)));
                    Delight.XmlEditor.ScrollableRegionTemplateProperty.SetDefault(_delightDesignerXmlEditor, DelightDesignerXmlEditorScrollableRegion);
                    Delight.XmlEditor.XmlEditRegionTemplateProperty.SetDefault(_delightDesignerXmlEditor, DelightDesignerXmlEditorXmlEditRegion);
                    Delight.XmlEditor.XmlEditLeftMarginTemplateProperty.SetDefault(_delightDesignerXmlEditor, DelightDesignerXmlEditorXmlEditLeftMargin);
                    Delight.XmlEditor.LineNumbersLabelTemplateProperty.SetDefault(_delightDesignerXmlEditor, DelightDesignerXmlEditorLineNumbersLabel);
                    Delight.XmlEditor.XmlTextRegionTemplateProperty.SetDefault(_delightDesignerXmlEditor, DelightDesignerXmlEditorXmlTextRegion);
                    Delight.XmlEditor.TextSelectionTemplateProperty.SetDefault(_delightDesignerXmlEditor, DelightDesignerXmlEditorTextSelection);
                    Delight.XmlEditor.XmlTextLabelTemplateProperty.SetDefault(_delightDesignerXmlEditor, DelightDesignerXmlEditorXmlTextLabel);
                    Delight.XmlEditor.CaretTemplateProperty.SetDefault(_delightDesignerXmlEditor, DelightDesignerXmlEditorCaret);
                    Delight.XmlEditor.DebugTextLabelTemplateProperty.SetDefault(_delightDesignerXmlEditor, DelightDesignerXmlEditorDebugTextLabel);
                }
                return _delightDesignerXmlEditor;
            }
        }

        private static Template _delightDesignerXmlEditorScrollableRegion;
        public static Template DelightDesignerXmlEditorScrollableRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerXmlEditorScrollableRegion == null || _delightDesignerXmlEditorScrollableRegion.CurrentVersion != Template.Version)
#else
                if (_delightDesignerXmlEditorScrollableRegion == null)
#endif
                {
                    _delightDesignerXmlEditorScrollableRegion = new Template(XmlEditorTemplates.XmlEditorScrollableRegion);
#if UNITY_EDITOR
                    _delightDesignerXmlEditorScrollableRegion.Name = "DelightDesignerXmlEditorScrollableRegion";
#endif
                    Delight.ScrollableRegion.ContentRegionTemplateProperty.SetDefault(_delightDesignerXmlEditorScrollableRegion, DelightDesignerXmlEditorScrollableRegionContentRegion);
                    Delight.ScrollableRegion.HorizontalScrollbarTemplateProperty.SetDefault(_delightDesignerXmlEditorScrollableRegion, DelightDesignerXmlEditorScrollableRegionHorizontalScrollbar);
                    Delight.ScrollableRegion.VerticalScrollbarTemplateProperty.SetDefault(_delightDesignerXmlEditorScrollableRegion, DelightDesignerXmlEditorScrollableRegionVerticalScrollbar);
                }
                return _delightDesignerXmlEditorScrollableRegion;
            }
        }

        private static Template _delightDesignerXmlEditorScrollableRegionContentRegion;
        public static Template DelightDesignerXmlEditorScrollableRegionContentRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerXmlEditorScrollableRegionContentRegion == null || _delightDesignerXmlEditorScrollableRegionContentRegion.CurrentVersion != Template.Version)
#else
                if (_delightDesignerXmlEditorScrollableRegionContentRegion == null)
#endif
                {
                    _delightDesignerXmlEditorScrollableRegionContentRegion = new Template(XmlEditorTemplates.XmlEditorScrollableRegionContentRegion);
#if UNITY_EDITOR
                    _delightDesignerXmlEditorScrollableRegionContentRegion.Name = "DelightDesignerXmlEditorScrollableRegionContentRegion";
#endif
                }
                return _delightDesignerXmlEditorScrollableRegionContentRegion;
            }
        }

        private static Template _delightDesignerXmlEditorScrollableRegionHorizontalScrollbar;
        public static Template DelightDesignerXmlEditorScrollableRegionHorizontalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerXmlEditorScrollableRegionHorizontalScrollbar == null || _delightDesignerXmlEditorScrollableRegionHorizontalScrollbar.CurrentVersion != Template.Version)
#else
                if (_delightDesignerXmlEditorScrollableRegionHorizontalScrollbar == null)
#endif
                {
                    _delightDesignerXmlEditorScrollableRegionHorizontalScrollbar = new Template(XmlEditorTemplates.XmlEditorScrollableRegionHorizontalScrollbar);
#if UNITY_EDITOR
                    _delightDesignerXmlEditorScrollableRegionHorizontalScrollbar.Name = "DelightDesignerXmlEditorScrollableRegionHorizontalScrollbar";
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_delightDesignerXmlEditorScrollableRegionHorizontalScrollbar, DelightDesignerXmlEditorScrollableRegionHorizontalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_delightDesignerXmlEditorScrollableRegionHorizontalScrollbar, DelightDesignerXmlEditorScrollableRegionHorizontalScrollbarHandle);
                }
                return _delightDesignerXmlEditorScrollableRegionHorizontalScrollbar;
            }
        }

        private static Template _delightDesignerXmlEditorScrollableRegionHorizontalScrollbarBar;
        public static Template DelightDesignerXmlEditorScrollableRegionHorizontalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerXmlEditorScrollableRegionHorizontalScrollbarBar == null || _delightDesignerXmlEditorScrollableRegionHorizontalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_delightDesignerXmlEditorScrollableRegionHorizontalScrollbarBar == null)
#endif
                {
                    _delightDesignerXmlEditorScrollableRegionHorizontalScrollbarBar = new Template(XmlEditorTemplates.XmlEditorScrollableRegionHorizontalScrollbarBar);
#if UNITY_EDITOR
                    _delightDesignerXmlEditorScrollableRegionHorizontalScrollbarBar.Name = "DelightDesignerXmlEditorScrollableRegionHorizontalScrollbarBar";
#endif
                }
                return _delightDesignerXmlEditorScrollableRegionHorizontalScrollbarBar;
            }
        }

        private static Template _delightDesignerXmlEditorScrollableRegionHorizontalScrollbarHandle;
        public static Template DelightDesignerXmlEditorScrollableRegionHorizontalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerXmlEditorScrollableRegionHorizontalScrollbarHandle == null || _delightDesignerXmlEditorScrollableRegionHorizontalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_delightDesignerXmlEditorScrollableRegionHorizontalScrollbarHandle == null)
#endif
                {
                    _delightDesignerXmlEditorScrollableRegionHorizontalScrollbarHandle = new Template(XmlEditorTemplates.XmlEditorScrollableRegionHorizontalScrollbarHandle);
#if UNITY_EDITOR
                    _delightDesignerXmlEditorScrollableRegionHorizontalScrollbarHandle.Name = "DelightDesignerXmlEditorScrollableRegionHorizontalScrollbarHandle";
#endif
                }
                return _delightDesignerXmlEditorScrollableRegionHorizontalScrollbarHandle;
            }
        }

        private static Template _delightDesignerXmlEditorScrollableRegionVerticalScrollbar;
        public static Template DelightDesignerXmlEditorScrollableRegionVerticalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerXmlEditorScrollableRegionVerticalScrollbar == null || _delightDesignerXmlEditorScrollableRegionVerticalScrollbar.CurrentVersion != Template.Version)
#else
                if (_delightDesignerXmlEditorScrollableRegionVerticalScrollbar == null)
#endif
                {
                    _delightDesignerXmlEditorScrollableRegionVerticalScrollbar = new Template(XmlEditorTemplates.XmlEditorScrollableRegionVerticalScrollbar);
#if UNITY_EDITOR
                    _delightDesignerXmlEditorScrollableRegionVerticalScrollbar.Name = "DelightDesignerXmlEditorScrollableRegionVerticalScrollbar";
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_delightDesignerXmlEditorScrollableRegionVerticalScrollbar, DelightDesignerXmlEditorScrollableRegionVerticalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_delightDesignerXmlEditorScrollableRegionVerticalScrollbar, DelightDesignerXmlEditorScrollableRegionVerticalScrollbarHandle);
                }
                return _delightDesignerXmlEditorScrollableRegionVerticalScrollbar;
            }
        }

        private static Template _delightDesignerXmlEditorScrollableRegionVerticalScrollbarBar;
        public static Template DelightDesignerXmlEditorScrollableRegionVerticalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerXmlEditorScrollableRegionVerticalScrollbarBar == null || _delightDesignerXmlEditorScrollableRegionVerticalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_delightDesignerXmlEditorScrollableRegionVerticalScrollbarBar == null)
#endif
                {
                    _delightDesignerXmlEditorScrollableRegionVerticalScrollbarBar = new Template(XmlEditorTemplates.XmlEditorScrollableRegionVerticalScrollbarBar);
#if UNITY_EDITOR
                    _delightDesignerXmlEditorScrollableRegionVerticalScrollbarBar.Name = "DelightDesignerXmlEditorScrollableRegionVerticalScrollbarBar";
#endif
                }
                return _delightDesignerXmlEditorScrollableRegionVerticalScrollbarBar;
            }
        }

        private static Template _delightDesignerXmlEditorScrollableRegionVerticalScrollbarHandle;
        public static Template DelightDesignerXmlEditorScrollableRegionVerticalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerXmlEditorScrollableRegionVerticalScrollbarHandle == null || _delightDesignerXmlEditorScrollableRegionVerticalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_delightDesignerXmlEditorScrollableRegionVerticalScrollbarHandle == null)
#endif
                {
                    _delightDesignerXmlEditorScrollableRegionVerticalScrollbarHandle = new Template(XmlEditorTemplates.XmlEditorScrollableRegionVerticalScrollbarHandle);
#if UNITY_EDITOR
                    _delightDesignerXmlEditorScrollableRegionVerticalScrollbarHandle.Name = "DelightDesignerXmlEditorScrollableRegionVerticalScrollbarHandle";
#endif
                }
                return _delightDesignerXmlEditorScrollableRegionVerticalScrollbarHandle;
            }
        }

        private static Template _delightDesignerXmlEditorXmlEditRegion;
        public static Template DelightDesignerXmlEditorXmlEditRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerXmlEditorXmlEditRegion == null || _delightDesignerXmlEditorXmlEditRegion.CurrentVersion != Template.Version)
#else
                if (_delightDesignerXmlEditorXmlEditRegion == null)
#endif
                {
                    _delightDesignerXmlEditorXmlEditRegion = new Template(XmlEditorTemplates.XmlEditorXmlEditRegion);
#if UNITY_EDITOR
                    _delightDesignerXmlEditorXmlEditRegion.Name = "DelightDesignerXmlEditorXmlEditRegion";
#endif
                }
                return _delightDesignerXmlEditorXmlEditRegion;
            }
        }

        private static Template _delightDesignerXmlEditorXmlEditLeftMargin;
        public static Template DelightDesignerXmlEditorXmlEditLeftMargin
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerXmlEditorXmlEditLeftMargin == null || _delightDesignerXmlEditorXmlEditLeftMargin.CurrentVersion != Template.Version)
#else
                if (_delightDesignerXmlEditorXmlEditLeftMargin == null)
#endif
                {
                    _delightDesignerXmlEditorXmlEditLeftMargin = new Template(XmlEditorTemplates.XmlEditorXmlEditLeftMargin);
#if UNITY_EDITOR
                    _delightDesignerXmlEditorXmlEditLeftMargin.Name = "DelightDesignerXmlEditorXmlEditLeftMargin";
#endif
                }
                return _delightDesignerXmlEditorXmlEditLeftMargin;
            }
        }

        private static Template _delightDesignerXmlEditorLineNumbersLabel;
        public static Template DelightDesignerXmlEditorLineNumbersLabel
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerXmlEditorLineNumbersLabel == null || _delightDesignerXmlEditorLineNumbersLabel.CurrentVersion != Template.Version)
#else
                if (_delightDesignerXmlEditorLineNumbersLabel == null)
#endif
                {
                    _delightDesignerXmlEditorLineNumbersLabel = new Template(XmlEditorTemplates.XmlEditorLineNumbersLabel);
#if UNITY_EDITOR
                    _delightDesignerXmlEditorLineNumbersLabel.Name = "DelightDesignerXmlEditorLineNumbersLabel";
#endif
                }
                return _delightDesignerXmlEditorLineNumbersLabel;
            }
        }

        private static Template _delightDesignerXmlEditorXmlTextRegion;
        public static Template DelightDesignerXmlEditorXmlTextRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerXmlEditorXmlTextRegion == null || _delightDesignerXmlEditorXmlTextRegion.CurrentVersion != Template.Version)
#else
                if (_delightDesignerXmlEditorXmlTextRegion == null)
#endif
                {
                    _delightDesignerXmlEditorXmlTextRegion = new Template(XmlEditorTemplates.XmlEditorXmlTextRegion);
#if UNITY_EDITOR
                    _delightDesignerXmlEditorXmlTextRegion.Name = "DelightDesignerXmlEditorXmlTextRegion";
#endif
                }
                return _delightDesignerXmlEditorXmlTextRegion;
            }
        }

        private static Template _delightDesignerXmlEditorTextSelection;
        public static Template DelightDesignerXmlEditorTextSelection
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerXmlEditorTextSelection == null || _delightDesignerXmlEditorTextSelection.CurrentVersion != Template.Version)
#else
                if (_delightDesignerXmlEditorTextSelection == null)
#endif
                {
                    _delightDesignerXmlEditorTextSelection = new Template(XmlEditorTemplates.XmlEditorTextSelection);
#if UNITY_EDITOR
                    _delightDesignerXmlEditorTextSelection.Name = "DelightDesignerXmlEditorTextSelection";
#endif
                }
                return _delightDesignerXmlEditorTextSelection;
            }
        }

        private static Template _delightDesignerXmlEditorXmlTextLabel;
        public static Template DelightDesignerXmlEditorXmlTextLabel
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerXmlEditorXmlTextLabel == null || _delightDesignerXmlEditorXmlTextLabel.CurrentVersion != Template.Version)
#else
                if (_delightDesignerXmlEditorXmlTextLabel == null)
#endif
                {
                    _delightDesignerXmlEditorXmlTextLabel = new Template(XmlEditorTemplates.XmlEditorXmlTextLabel);
#if UNITY_EDITOR
                    _delightDesignerXmlEditorXmlTextLabel.Name = "DelightDesignerXmlEditorXmlTextLabel";
#endif
                }
                return _delightDesignerXmlEditorXmlTextLabel;
            }
        }

        private static Template _delightDesignerXmlEditorCaret;
        public static Template DelightDesignerXmlEditorCaret
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerXmlEditorCaret == null || _delightDesignerXmlEditorCaret.CurrentVersion != Template.Version)
#else
                if (_delightDesignerXmlEditorCaret == null)
#endif
                {
                    _delightDesignerXmlEditorCaret = new Template(XmlEditorTemplates.XmlEditorCaret);
#if UNITY_EDITOR
                    _delightDesignerXmlEditorCaret.Name = "DelightDesignerXmlEditorCaret";
#endif
                }
                return _delightDesignerXmlEditorCaret;
            }
        }

        private static Template _delightDesignerXmlEditorDebugTextLabel;
        public static Template DelightDesignerXmlEditorDebugTextLabel
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerXmlEditorDebugTextLabel == null || _delightDesignerXmlEditorDebugTextLabel.CurrentVersion != Template.Version)
#else
                if (_delightDesignerXmlEditorDebugTextLabel == null)
#endif
                {
                    _delightDesignerXmlEditorDebugTextLabel = new Template(XmlEditorTemplates.XmlEditorDebugTextLabel);
#if UNITY_EDITOR
                    _delightDesignerXmlEditorDebugTextLabel.Name = "DelightDesignerXmlEditorDebugTextLabel";
#endif
                }
                return _delightDesignerXmlEditorDebugTextLabel;
            }
        }

        private static Template _delightDesignerGridSplitter1;
        public static Template DelightDesignerGridSplitter1
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerGridSplitter1 == null || _delightDesignerGridSplitter1.CurrentVersion != Template.Version)
#else
                if (_delightDesignerGridSplitter1 == null)
#endif
                {
                    _delightDesignerGridSplitter1 = new Template(GridSplitterTemplates.GridSplitter);
#if UNITY_EDITOR
                    _delightDesignerGridSplitter1.Name = "DelightDesignerGridSplitter1";
#endif
                    Delight.GridSplitter.ThicknessProperty.SetDefault(_delightDesignerGridSplitter1, new ElementSize(20f, ElementSizeUnit.Pixels));
                }
                return _delightDesignerGridSplitter1;
            }
        }

        #endregion
    }

    #endregion
}

#endif
