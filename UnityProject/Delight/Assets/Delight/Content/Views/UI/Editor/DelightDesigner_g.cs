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

                // binding <Label Text="{view.Name}">
                listItem1.Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "Item", "Name" }, new List<Func<BindableObject>> { () => tiView, () => (tiView.Item as Delight.DesignerView) }) }, new BindingPath(new List<string> { "Text" }, new List<Func<BindableObject>> { () => label2 }), () => label2.Text = (tiView.Item as Delight.DesignerView).Name, () => { }, false));
                listItem1.IsDynamic = true;
                listItem1.SetContentTemplateData(tiView);
                return listItem1;
            }, typeof(ListItem), "ListItem1"));
            XmlEditor = new Region(this, Grid1.Content, "XmlEditor", XmlEditorTemplate);
            Grid1.Cell.SetValue(XmlEditor, new CellIndex(0, 1));
            XmlEditor1 = new XmlEditor(this, XmlEditor.Content, "XmlEditor1", XmlEditor1Template);
            XmlEditArea = new Region(this, XmlEditor.Content, "XmlEditArea", XmlEditAreaTemplate);
            XmlTextInputField = new InputField(this, XmlEditArea.Content, "XmlTextInputField", XmlTextInputFieldTemplate);

            // binding <InputField Text="{XmlText}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "XmlText" }, new List<Func<BindableObject>> { () => this }) }, new BindingPath(new List<string> { "XmlTextInputField", "Text" }, new List<Func<BindableObject>> { () => this, () => XmlTextInputField }), () => XmlTextInputField.Text = XmlText, () => XmlText = XmlTextInputField.Text, true));
            XmlTextLabel = new Label(this, XmlEditArea.Content, "XmlTextLabel", XmlTextLabelTemplate);
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
            dependencyProperties.Add(XmlEditorProperty);
            dependencyProperties.Add(XmlEditorTemplateProperty);
            dependencyProperties.Add(XmlEditor1Property);
            dependencyProperties.Add(XmlEditor1TemplateProperty);
            dependencyProperties.Add(XmlEditAreaProperty);
            dependencyProperties.Add(XmlEditAreaTemplateProperty);
            dependencyProperties.Add(XmlTextInputFieldProperty);
            dependencyProperties.Add(XmlTextInputFieldTemplateProperty);
            dependencyProperties.Add(XmlTextLabelProperty);
            dependencyProperties.Add(XmlTextLabelTemplateProperty);
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

        public readonly static DependencyProperty<Region> XmlEditorProperty = new DependencyProperty<Region>("XmlEditor");
        public Region XmlEditor
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

        public readonly static DependencyProperty<XmlEditor> XmlEditor1Property = new DependencyProperty<XmlEditor>("XmlEditor1");
        public XmlEditor XmlEditor1
        {
            get { return XmlEditor1Property.GetValue(this); }
            set { XmlEditor1Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> XmlEditor1TemplateProperty = new DependencyProperty<Template>("XmlEditor1Template");
        public Template XmlEditor1Template
        {
            get { return XmlEditor1TemplateProperty.GetValue(this); }
            set { XmlEditor1TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> XmlEditAreaProperty = new DependencyProperty<Region>("XmlEditArea");
        public Region XmlEditArea
        {
            get { return XmlEditAreaProperty.GetValue(this); }
            set { XmlEditAreaProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> XmlEditAreaTemplateProperty = new DependencyProperty<Template>("XmlEditAreaTemplate");
        public Template XmlEditAreaTemplate
        {
            get { return XmlEditAreaTemplateProperty.GetValue(this); }
            set { XmlEditAreaTemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<InputField> XmlTextInputFieldProperty = new DependencyProperty<InputField>("XmlTextInputField");
        public InputField XmlTextInputField
        {
            get { return XmlTextInputFieldProperty.GetValue(this); }
            set { XmlTextInputFieldProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> XmlTextInputFieldTemplateProperty = new DependencyProperty<Template>("XmlTextInputFieldTemplate");
        public Template XmlTextInputFieldTemplate
        {
            get { return XmlTextInputFieldTemplateProperty.GetValue(this); }
            set { XmlTextInputFieldTemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Label> XmlTextLabelProperty = new DependencyProperty<Label>("XmlTextLabel");
        public Label XmlTextLabel
        {
            get { return XmlTextLabelProperty.GetValue(this); }
            set { XmlTextLabelProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> XmlTextLabelTemplateProperty = new DependencyProperty<Template>("XmlTextLabelTemplate");
        public Template XmlTextLabelTemplate
        {
            get { return XmlTextLabelTemplateProperty.GetValue(this); }
            set { XmlTextLabelTemplateProperty.SetValue(this, value); }
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
                    Delight.DelightDesigner.XmlEditorTemplateProperty.SetDefault(_delightDesigner, DelightDesignerXmlEditor);
                    Delight.DelightDesigner.XmlEditor1TemplateProperty.SetDefault(_delightDesigner, DelightDesignerXmlEditor1);
                    Delight.DelightDesigner.XmlEditAreaTemplateProperty.SetDefault(_delightDesigner, DelightDesignerXmlEditArea);
                    Delight.DelightDesigner.XmlTextInputFieldTemplateProperty.SetDefault(_delightDesigner, DelightDesignerXmlTextInputField);
                    Delight.DelightDesigner.XmlTextLabelTemplateProperty.SetDefault(_delightDesigner, DelightDesignerXmlTextLabel);
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
                    Delight.Region.BackgroundColorProperty.SetDefault(_delightDesignerContentExplorer, new UnityEngine.Color(0.9921569f, 0.9921569f, 0.9921569f, 1f));
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
                    Delight.Label.OverflowModeProperty.SetDefault(_delightDesignerLabel1, TMPro.TextOverflowModes.Ellipsis);
                    Delight.Label.FontColorProperty.SetDefault(_delightDesignerLabel1, new UnityEngine.Color(0.2235294f, 0.2666667f, 0.3490196f, 1f));
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
                    Delight.Label.FontColorProperty.SetDefault(_delightDesignerLabel2, new UnityEngine.Color(0.2235294f, 0.2666667f, 0.3490196f, 0.8f));
                    Delight.Label.WidthProperty.SetDefault(_delightDesignerLabel2, new ElementSize(1f, ElementSizeUnit.Percents));
                    Delight.Label.MarginProperty.SetDefault(_delightDesignerLabel2, new ElementMargin(new ElementSize(16f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels)));
                    Delight.Label.EnableWordWrappingProperty.SetDefault(_delightDesignerLabel2, false);
                    Delight.Label.OverflowModeProperty.SetDefault(_delightDesignerLabel2, TMPro.TextOverflowModes.Ellipsis);
                    Delight.Label.ExtraPaddingProperty.SetDefault(_delightDesignerLabel2, true);
                    Delight.Label.TextProperty.SetHasBinding(_delightDesignerLabel2);
                }
                return _delightDesignerLabel2;
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
                    _delightDesignerXmlEditor = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _delightDesignerXmlEditor.Name = "DelightDesignerXmlEditor";
#endif
                    Delight.Region.BackgroundColorProperty.SetDefault(_delightDesignerXmlEditor, new UnityEngine.Color(0.9843137f, 0.9843137f, 0.9843137f, 1f));
                }
                return _delightDesignerXmlEditor;
            }
        }

        private static Template _delightDesignerXmlEditor1;
        public static Template DelightDesignerXmlEditor1
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerXmlEditor1 == null || _delightDesignerXmlEditor1.CurrentVersion != Template.Version)
#else
                if (_delightDesignerXmlEditor1 == null)
#endif
                {
                    _delightDesignerXmlEditor1 = new Template(XmlEditorTemplates.XmlEditor);
#if UNITY_EDITOR
                    _delightDesignerXmlEditor1.Name = "DelightDesignerXmlEditor1";
#endif
                    Delight.XmlEditor.ScrollableAreaTemplateProperty.SetDefault(_delightDesignerXmlEditor1, DelightDesignerXmlEditor1ScrollableArea);
                    Delight.XmlEditor.XmlEditRegionTemplateProperty.SetDefault(_delightDesignerXmlEditor1, DelightDesignerXmlEditor1XmlEditRegion);
                    Delight.XmlEditor.LineNumbersLabelTemplateProperty.SetDefault(_delightDesignerXmlEditor1, DelightDesignerXmlEditor1LineNumbersLabel);
                    Delight.XmlEditor.XmlTextRegionTemplateProperty.SetDefault(_delightDesignerXmlEditor1, DelightDesignerXmlEditor1XmlTextRegion);
                    Delight.XmlEditor.XmlTextLabelTemplateProperty.SetDefault(_delightDesignerXmlEditor1, DelightDesignerXmlEditor1XmlTextLabel);
                    Delight.XmlEditor.CaretTemplateProperty.SetDefault(_delightDesignerXmlEditor1, DelightDesignerXmlEditor1Caret);
                    Delight.XmlEditor.CaretElementTemplateProperty.SetDefault(_delightDesignerXmlEditor1, DelightDesignerXmlEditor1CaretElement);
                }
                return _delightDesignerXmlEditor1;
            }
        }

        private static Template _delightDesignerXmlEditor1ScrollableArea;
        public static Template DelightDesignerXmlEditor1ScrollableArea
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerXmlEditor1ScrollableArea == null || _delightDesignerXmlEditor1ScrollableArea.CurrentVersion != Template.Version)
#else
                if (_delightDesignerXmlEditor1ScrollableArea == null)
#endif
                {
                    _delightDesignerXmlEditor1ScrollableArea = new Template(XmlEditorTemplates.XmlEditorScrollableArea);
#if UNITY_EDITOR
                    _delightDesignerXmlEditor1ScrollableArea.Name = "DelightDesignerXmlEditor1ScrollableArea";
#endif
                    Delight.ScrollableRegion.ContentRegionTemplateProperty.SetDefault(_delightDesignerXmlEditor1ScrollableArea, DelightDesignerXmlEditor1ScrollableAreaContentRegion);
                    Delight.ScrollableRegion.HorizontalScrollbarTemplateProperty.SetDefault(_delightDesignerXmlEditor1ScrollableArea, DelightDesignerXmlEditor1ScrollableAreaHorizontalScrollbar);
                    Delight.ScrollableRegion.VerticalScrollbarTemplateProperty.SetDefault(_delightDesignerXmlEditor1ScrollableArea, DelightDesignerXmlEditor1ScrollableAreaVerticalScrollbar);
                }
                return _delightDesignerXmlEditor1ScrollableArea;
            }
        }

        private static Template _delightDesignerXmlEditor1ScrollableAreaContentRegion;
        public static Template DelightDesignerXmlEditor1ScrollableAreaContentRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerXmlEditor1ScrollableAreaContentRegion == null || _delightDesignerXmlEditor1ScrollableAreaContentRegion.CurrentVersion != Template.Version)
#else
                if (_delightDesignerXmlEditor1ScrollableAreaContentRegion == null)
#endif
                {
                    _delightDesignerXmlEditor1ScrollableAreaContentRegion = new Template(XmlEditorTemplates.XmlEditorScrollableAreaContentRegion);
#if UNITY_EDITOR
                    _delightDesignerXmlEditor1ScrollableAreaContentRegion.Name = "DelightDesignerXmlEditor1ScrollableAreaContentRegion";
#endif
                }
                return _delightDesignerXmlEditor1ScrollableAreaContentRegion;
            }
        }

        private static Template _delightDesignerXmlEditor1ScrollableAreaHorizontalScrollbar;
        public static Template DelightDesignerXmlEditor1ScrollableAreaHorizontalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerXmlEditor1ScrollableAreaHorizontalScrollbar == null || _delightDesignerXmlEditor1ScrollableAreaHorizontalScrollbar.CurrentVersion != Template.Version)
#else
                if (_delightDesignerXmlEditor1ScrollableAreaHorizontalScrollbar == null)
#endif
                {
                    _delightDesignerXmlEditor1ScrollableAreaHorizontalScrollbar = new Template(XmlEditorTemplates.XmlEditorScrollableAreaHorizontalScrollbar);
#if UNITY_EDITOR
                    _delightDesignerXmlEditor1ScrollableAreaHorizontalScrollbar.Name = "DelightDesignerXmlEditor1ScrollableAreaHorizontalScrollbar";
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_delightDesignerXmlEditor1ScrollableAreaHorizontalScrollbar, DelightDesignerXmlEditor1ScrollableAreaHorizontalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_delightDesignerXmlEditor1ScrollableAreaHorizontalScrollbar, DelightDesignerXmlEditor1ScrollableAreaHorizontalScrollbarHandle);
                }
                return _delightDesignerXmlEditor1ScrollableAreaHorizontalScrollbar;
            }
        }

        private static Template _delightDesignerXmlEditor1ScrollableAreaHorizontalScrollbarBar;
        public static Template DelightDesignerXmlEditor1ScrollableAreaHorizontalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerXmlEditor1ScrollableAreaHorizontalScrollbarBar == null || _delightDesignerXmlEditor1ScrollableAreaHorizontalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_delightDesignerXmlEditor1ScrollableAreaHorizontalScrollbarBar == null)
#endif
                {
                    _delightDesignerXmlEditor1ScrollableAreaHorizontalScrollbarBar = new Template(XmlEditorTemplates.XmlEditorScrollableAreaHorizontalScrollbarBar);
#if UNITY_EDITOR
                    _delightDesignerXmlEditor1ScrollableAreaHorizontalScrollbarBar.Name = "DelightDesignerXmlEditor1ScrollableAreaHorizontalScrollbarBar";
#endif
                }
                return _delightDesignerXmlEditor1ScrollableAreaHorizontalScrollbarBar;
            }
        }

        private static Template _delightDesignerXmlEditor1ScrollableAreaHorizontalScrollbarHandle;
        public static Template DelightDesignerXmlEditor1ScrollableAreaHorizontalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerXmlEditor1ScrollableAreaHorizontalScrollbarHandle == null || _delightDesignerXmlEditor1ScrollableAreaHorizontalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_delightDesignerXmlEditor1ScrollableAreaHorizontalScrollbarHandle == null)
#endif
                {
                    _delightDesignerXmlEditor1ScrollableAreaHorizontalScrollbarHandle = new Template(XmlEditorTemplates.XmlEditorScrollableAreaHorizontalScrollbarHandle);
#if UNITY_EDITOR
                    _delightDesignerXmlEditor1ScrollableAreaHorizontalScrollbarHandle.Name = "DelightDesignerXmlEditor1ScrollableAreaHorizontalScrollbarHandle";
#endif
                }
                return _delightDesignerXmlEditor1ScrollableAreaHorizontalScrollbarHandle;
            }
        }

        private static Template _delightDesignerXmlEditor1ScrollableAreaVerticalScrollbar;
        public static Template DelightDesignerXmlEditor1ScrollableAreaVerticalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerXmlEditor1ScrollableAreaVerticalScrollbar == null || _delightDesignerXmlEditor1ScrollableAreaVerticalScrollbar.CurrentVersion != Template.Version)
#else
                if (_delightDesignerXmlEditor1ScrollableAreaVerticalScrollbar == null)
#endif
                {
                    _delightDesignerXmlEditor1ScrollableAreaVerticalScrollbar = new Template(XmlEditorTemplates.XmlEditorScrollableAreaVerticalScrollbar);
#if UNITY_EDITOR
                    _delightDesignerXmlEditor1ScrollableAreaVerticalScrollbar.Name = "DelightDesignerXmlEditor1ScrollableAreaVerticalScrollbar";
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_delightDesignerXmlEditor1ScrollableAreaVerticalScrollbar, DelightDesignerXmlEditor1ScrollableAreaVerticalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_delightDesignerXmlEditor1ScrollableAreaVerticalScrollbar, DelightDesignerXmlEditor1ScrollableAreaVerticalScrollbarHandle);
                }
                return _delightDesignerXmlEditor1ScrollableAreaVerticalScrollbar;
            }
        }

        private static Template _delightDesignerXmlEditor1ScrollableAreaVerticalScrollbarBar;
        public static Template DelightDesignerXmlEditor1ScrollableAreaVerticalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerXmlEditor1ScrollableAreaVerticalScrollbarBar == null || _delightDesignerXmlEditor1ScrollableAreaVerticalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_delightDesignerXmlEditor1ScrollableAreaVerticalScrollbarBar == null)
#endif
                {
                    _delightDesignerXmlEditor1ScrollableAreaVerticalScrollbarBar = new Template(XmlEditorTemplates.XmlEditorScrollableAreaVerticalScrollbarBar);
#if UNITY_EDITOR
                    _delightDesignerXmlEditor1ScrollableAreaVerticalScrollbarBar.Name = "DelightDesignerXmlEditor1ScrollableAreaVerticalScrollbarBar";
#endif
                }
                return _delightDesignerXmlEditor1ScrollableAreaVerticalScrollbarBar;
            }
        }

        private static Template _delightDesignerXmlEditor1ScrollableAreaVerticalScrollbarHandle;
        public static Template DelightDesignerXmlEditor1ScrollableAreaVerticalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerXmlEditor1ScrollableAreaVerticalScrollbarHandle == null || _delightDesignerXmlEditor1ScrollableAreaVerticalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_delightDesignerXmlEditor1ScrollableAreaVerticalScrollbarHandle == null)
#endif
                {
                    _delightDesignerXmlEditor1ScrollableAreaVerticalScrollbarHandle = new Template(XmlEditorTemplates.XmlEditorScrollableAreaVerticalScrollbarHandle);
#if UNITY_EDITOR
                    _delightDesignerXmlEditor1ScrollableAreaVerticalScrollbarHandle.Name = "DelightDesignerXmlEditor1ScrollableAreaVerticalScrollbarHandle";
#endif
                }
                return _delightDesignerXmlEditor1ScrollableAreaVerticalScrollbarHandle;
            }
        }

        private static Template _delightDesignerXmlEditor1XmlEditRegion;
        public static Template DelightDesignerXmlEditor1XmlEditRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerXmlEditor1XmlEditRegion == null || _delightDesignerXmlEditor1XmlEditRegion.CurrentVersion != Template.Version)
#else
                if (_delightDesignerXmlEditor1XmlEditRegion == null)
#endif
                {
                    _delightDesignerXmlEditor1XmlEditRegion = new Template(XmlEditorTemplates.XmlEditorXmlEditRegion);
#if UNITY_EDITOR
                    _delightDesignerXmlEditor1XmlEditRegion.Name = "DelightDesignerXmlEditor1XmlEditRegion";
#endif
                }
                return _delightDesignerXmlEditor1XmlEditRegion;
            }
        }

        private static Template _delightDesignerXmlEditor1LineNumbersLabel;
        public static Template DelightDesignerXmlEditor1LineNumbersLabel
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerXmlEditor1LineNumbersLabel == null || _delightDesignerXmlEditor1LineNumbersLabel.CurrentVersion != Template.Version)
#else
                if (_delightDesignerXmlEditor1LineNumbersLabel == null)
#endif
                {
                    _delightDesignerXmlEditor1LineNumbersLabel = new Template(XmlEditorTemplates.XmlEditorLineNumbersLabel);
#if UNITY_EDITOR
                    _delightDesignerXmlEditor1LineNumbersLabel.Name = "DelightDesignerXmlEditor1LineNumbersLabel";
#endif
                }
                return _delightDesignerXmlEditor1LineNumbersLabel;
            }
        }

        private static Template _delightDesignerXmlEditor1XmlTextRegion;
        public static Template DelightDesignerXmlEditor1XmlTextRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerXmlEditor1XmlTextRegion == null || _delightDesignerXmlEditor1XmlTextRegion.CurrentVersion != Template.Version)
#else
                if (_delightDesignerXmlEditor1XmlTextRegion == null)
#endif
                {
                    _delightDesignerXmlEditor1XmlTextRegion = new Template(XmlEditorTemplates.XmlEditorXmlTextRegion);
#if UNITY_EDITOR
                    _delightDesignerXmlEditor1XmlTextRegion.Name = "DelightDesignerXmlEditor1XmlTextRegion";
#endif
                }
                return _delightDesignerXmlEditor1XmlTextRegion;
            }
        }

        private static Template _delightDesignerXmlEditor1XmlTextLabel;
        public static Template DelightDesignerXmlEditor1XmlTextLabel
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerXmlEditor1XmlTextLabel == null || _delightDesignerXmlEditor1XmlTextLabel.CurrentVersion != Template.Version)
#else
                if (_delightDesignerXmlEditor1XmlTextLabel == null)
#endif
                {
                    _delightDesignerXmlEditor1XmlTextLabel = new Template(XmlEditorTemplates.XmlEditorXmlTextLabel);
#if UNITY_EDITOR
                    _delightDesignerXmlEditor1XmlTextLabel.Name = "DelightDesignerXmlEditor1XmlTextLabel";
#endif
                }
                return _delightDesignerXmlEditor1XmlTextLabel;
            }
        }

        private static Template _delightDesignerXmlEditor1Caret;
        public static Template DelightDesignerXmlEditor1Caret
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerXmlEditor1Caret == null || _delightDesignerXmlEditor1Caret.CurrentVersion != Template.Version)
#else
                if (_delightDesignerXmlEditor1Caret == null)
#endif
                {
                    _delightDesignerXmlEditor1Caret = new Template(XmlEditorTemplates.XmlEditorCaret);
#if UNITY_EDITOR
                    _delightDesignerXmlEditor1Caret.Name = "DelightDesignerXmlEditor1Caret";
#endif
                }
                return _delightDesignerXmlEditor1Caret;
            }
        }

        private static Template _delightDesignerXmlEditor1CaretElement;
        public static Template DelightDesignerXmlEditor1CaretElement
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerXmlEditor1CaretElement == null || _delightDesignerXmlEditor1CaretElement.CurrentVersion != Template.Version)
#else
                if (_delightDesignerXmlEditor1CaretElement == null)
#endif
                {
                    _delightDesignerXmlEditor1CaretElement = new Template(XmlEditorTemplates.XmlEditorCaretElement);
#if UNITY_EDITOR
                    _delightDesignerXmlEditor1CaretElement.Name = "DelightDesignerXmlEditor1CaretElement";
#endif
                }
                return _delightDesignerXmlEditor1CaretElement;
            }
        }

        private static Template _delightDesignerXmlEditArea;
        public static Template DelightDesignerXmlEditArea
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerXmlEditArea == null || _delightDesignerXmlEditArea.CurrentVersion != Template.Version)
#else
                if (_delightDesignerXmlEditArea == null)
#endif
                {
                    _delightDesignerXmlEditArea = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _delightDesignerXmlEditArea.Name = "DelightDesignerXmlEditArea";
#endif
                    Delight.Region.MarginProperty.SetDefault(_delightDesignerXmlEditArea, new ElementMargin(new ElementSize(25f, ElementSizeUnit.Pixels), new ElementSize(25f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels)));
                }
                return _delightDesignerXmlEditArea;
            }
        }

        private static Template _delightDesignerXmlTextInputField;
        public static Template DelightDesignerXmlTextInputField
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerXmlTextInputField == null || _delightDesignerXmlTextInputField.CurrentVersion != Template.Version)
#else
                if (_delightDesignerXmlTextInputField == null)
#endif
                {
                    _delightDesignerXmlTextInputField = new Template(InputFieldTemplates.InputField);
#if UNITY_EDITOR
                    _delightDesignerXmlTextInputField.Name = "DelightDesignerXmlTextInputField";
#endif
                    Delight.InputField.WidthProperty.SetDefault(_delightDesignerXmlTextInputField, new ElementSize(1f, ElementSizeUnit.Percents));
                    Delight.InputField.HeightProperty.SetDefault(_delightDesignerXmlTextInputField, new ElementSize(1f, ElementSizeUnit.Percents));
                    Delight.InputField.MarginProperty.SetDefault(_delightDesignerXmlTextInputField, new ElementMargin(new ElementSize(2f, ElementSizeUnit.Pixels), new ElementSize(2f, ElementSizeUnit.Pixels), new ElementSize(2f, ElementSizeUnit.Pixels), new ElementSize(2f, ElementSizeUnit.Pixels)));
                    Delight.InputField.LineTypeProperty.SetDefault(_delightDesignerXmlTextInputField, TMPro.TMP_InputField.LineType.MultiLineNewline);
                    Delight.InputField.IsRichTextEditingAllowedProperty.SetDefault(_delightDesignerXmlTextInputField, false);
                    Delight.InputField.RichTextProperty.SetDefault(_delightDesignerXmlTextInputField, false);
                    Delight.InputField.BackgroundColorProperty.SetDefault(_delightDesignerXmlTextInputField, new UnityEngine.Color(0f, 0f, 0f, 0f));
                    Delight.InputField.TextProperty.SetHasBinding(_delightDesignerXmlTextInputField);
                    Delight.InputField.InputFieldPlaceholderTemplateProperty.SetDefault(_delightDesignerXmlTextInputField, DelightDesignerXmlTextInputFieldInputFieldPlaceholder);
                    Delight.InputField.TextAreaTemplateProperty.SetDefault(_delightDesignerXmlTextInputField, DelightDesignerXmlTextInputFieldTextArea);
                    Delight.InputField.InputTextTemplateProperty.SetDefault(_delightDesignerXmlTextInputField, DelightDesignerXmlTextInputFieldInputText);
                }
                return _delightDesignerXmlTextInputField;
            }
        }

        private static Template _delightDesignerXmlTextInputFieldInputFieldPlaceholder;
        public static Template DelightDesignerXmlTextInputFieldInputFieldPlaceholder
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerXmlTextInputFieldInputFieldPlaceholder == null || _delightDesignerXmlTextInputFieldInputFieldPlaceholder.CurrentVersion != Template.Version)
#else
                if (_delightDesignerXmlTextInputFieldInputFieldPlaceholder == null)
#endif
                {
                    _delightDesignerXmlTextInputFieldInputFieldPlaceholder = new Template(InputFieldTemplates.InputFieldInputFieldPlaceholder);
#if UNITY_EDITOR
                    _delightDesignerXmlTextInputFieldInputFieldPlaceholder.Name = "DelightDesignerXmlTextInputFieldInputFieldPlaceholder";
#endif
                }
                return _delightDesignerXmlTextInputFieldInputFieldPlaceholder;
            }
        }

        private static Template _delightDesignerXmlTextInputFieldTextArea;
        public static Template DelightDesignerXmlTextInputFieldTextArea
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerXmlTextInputFieldTextArea == null || _delightDesignerXmlTextInputFieldTextArea.CurrentVersion != Template.Version)
#else
                if (_delightDesignerXmlTextInputFieldTextArea == null)
#endif
                {
                    _delightDesignerXmlTextInputFieldTextArea = new Template(InputFieldTemplates.InputFieldTextArea);
#if UNITY_EDITOR
                    _delightDesignerXmlTextInputFieldTextArea.Name = "DelightDesignerXmlTextInputFieldTextArea";
#endif
                }
                return _delightDesignerXmlTextInputFieldTextArea;
            }
        }

        private static Template _delightDesignerXmlTextInputFieldInputText;
        public static Template DelightDesignerXmlTextInputFieldInputText
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerXmlTextInputFieldInputText == null || _delightDesignerXmlTextInputFieldInputText.CurrentVersion != Template.Version)
#else
                if (_delightDesignerXmlTextInputFieldInputText == null)
#endif
                {
                    _delightDesignerXmlTextInputFieldInputText = new Template(InputFieldTemplates.InputFieldInputText);
#if UNITY_EDITOR
                    _delightDesignerXmlTextInputFieldInputText.Name = "DelightDesignerXmlTextInputFieldInputText";
#endif
                    Delight.Label.OverflowModeProperty.SetDefault(_delightDesignerXmlTextInputFieldInputText, TMPro.TextOverflowModes.Overflow);
                    Delight.Label.EnableWordWrappingProperty.SetDefault(_delightDesignerXmlTextInputFieldInputText, false);
                    Delight.Label.FontProperty.SetDefault(_delightDesignerXmlTextInputFieldInputText, Assets.TMP_FontAssets["Inconsolata-Regular SDF"]);
                    Delight.Label.FontSizeProperty.SetDefault(_delightDesignerXmlTextInputFieldInputText, 20f);
                    Delight.Label.FontColorProperty.SetDefault(_delightDesignerXmlTextInputFieldInputText, new UnityEngine.Color(0.8666667f, 0.8666667f, 0.8666667f, 1f));
                }
                return _delightDesignerXmlTextInputFieldInputText;
            }
        }

        private static Template _delightDesignerXmlTextLabel;
        public static Template DelightDesignerXmlTextLabel
        {
            get
            {
#if UNITY_EDITOR
                if (_delightDesignerXmlTextLabel == null || _delightDesignerXmlTextLabel.CurrentVersion != Template.Version)
#else
                if (_delightDesignerXmlTextLabel == null)
#endif
                {
                    _delightDesignerXmlTextLabel = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _delightDesignerXmlTextLabel.Name = "DelightDesignerXmlTextLabel";
#endif
                    Delight.Label.FontProperty.SetDefault(_delightDesignerXmlTextLabel, Assets.TMP_FontAssets["Inconsolata-Regular SDF"]);
                    Delight.Label.FontSizeProperty.SetDefault(_delightDesignerXmlTextLabel, 20f);
                    Delight.Label.WidthProperty.SetDefault(_delightDesignerXmlTextLabel, new ElementSize(1f, ElementSizeUnit.Percents));
                    Delight.Label.HeightProperty.SetDefault(_delightDesignerXmlTextLabel, new ElementSize(1f, ElementSizeUnit.Percents));
                    Delight.Label.OverflowModeProperty.SetDefault(_delightDesignerXmlTextLabel, TMPro.TextOverflowModes.Overflow);
                    Delight.Label.EnableWordWrappingProperty.SetDefault(_delightDesignerXmlTextLabel, false);
                    Delight.Label.TextAlignmentProperty.SetDefault(_delightDesignerXmlTextLabel, TMPro.TextAlignmentOptions.TopLeft);
                    Delight.Label.MarginProperty.SetDefault(_delightDesignerXmlTextLabel, new ElementMargin(new ElementSize(12f, ElementSizeUnit.Pixels), new ElementSize(14f, ElementSizeUnit.Pixels), new ElementSize(2f, ElementSizeUnit.Pixels), new ElementSize(2f, ElementSizeUnit.Pixels)));
                    Delight.Label.RaycastBlockModeProperty.SetDefault(_delightDesignerXmlTextLabel, Delight.RaycastBlockMode.Never);
                }
                return _delightDesignerXmlTextLabel;
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
