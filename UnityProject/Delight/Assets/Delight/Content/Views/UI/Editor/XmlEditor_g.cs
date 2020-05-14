#if DELIGHT_MODULE_TEXTMESHPRO

// Internal view logic generated from "XmlEditor.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class XmlEditor : UIImageView
    {
        #region Constructors

        public XmlEditor(View parent, View layoutParent = null, string id = null, Template template = null, bool deferInitialization = false) :
            base(parent, layoutParent, id, template ?? XmlEditorTemplates.Default, deferInitialization)
        {
            if (deferInitialization)
                return;

            // constructing ScrollableRegion (ScrollableRegion)
            ScrollableRegion = new ScrollableRegion(this, this, "ScrollableRegion", ScrollableRegionTemplate);
            XmlEditRegion = new Region(this, ScrollableRegion.Content, "XmlEditRegion", XmlEditRegionTemplate);
            XmlTextRegion = new Region(this, XmlEditRegion.Content, "XmlTextRegion", XmlTextRegionTemplate);
            TextSelection = new CanvasRendererView(this, XmlTextRegion.Content, "TextSelection", TextSelectionTemplate);
            XmlTextLabel = new Label(this, XmlTextRegion.Content, "XmlTextLabel", XmlTextLabelTemplate);
            Caret = new Label(this, XmlTextRegion.Content, "Caret", CaretTemplate);
            UICanvas1 = new UICanvas(this, XmlTextRegion.Content, "UICanvas1", UICanvas1Template);
            AutoCompleteBox = new Region(this, UICanvas1.Content, "AutoCompleteBox", AutoCompleteBoxTemplate);
            AutoCompleteOptionsList = new List(this, AutoCompleteBox.Content, "AutoCompleteOptionsList", AutoCompleteOptionsListTemplate);
            AutoCompleteOptionsList.TemplateSelector.RegisterMethod(this, "AutoCompleteOptionSelector");

            // binding <List Items="{option in AutoCompleteOptions}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "AutoCompleteOptions" }, new List<Func<BindableObject>> { () => this }) }, new BindingPath(new List<string> { "AutoCompleteOptionsList", "Items" }, new List<Func<BindableObject>> { () => this, () => AutoCompleteOptionsList }), () => AutoCompleteOptionsList.Items = AutoCompleteOptions, () => { }, false));

            // binding <List SelectedItem="{SelectedAutoCompleteOption}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "SelectedAutoCompleteOption" }, new List<Func<BindableObject>> { () => this }) }, new BindingPath(new List<string> { "AutoCompleteOptionsList", "SelectedItem" }, new List<Func<BindableObject>> { () => this, () => AutoCompleteOptionsList }), () => AutoCompleteOptionsList.SelectedItem = SelectedAutoCompleteOption, () => SelectedAutoCompleteOption = AutoCompleteOptionsList.SelectedItem as Delight.AutoCompleteOption, true));

            // templates for AutoCompleteOptionsList
            AutoCompleteOptionsList.ContentTemplates.Add(new ContentTemplate(tiOption => 
            {
                var defaultOptionItem = new ListItem(this, AutoCompleteOptionsList.Content, "DefaultOptionItem", DefaultOptionItemTemplate);
                defaultOptionItem.Click.RegisterHandler(this, "AutoCompleteOptionSelected", () => (tiOption.Item as Delight.AutoCompleteOption));
                var label1 = new Label(this, defaultOptionItem.Content, "Label1", Label1Template);

                // binding <Label Text="{option.DisplayText}">
                defaultOptionItem.Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "Item", "DisplayText" }, new List<Func<BindableObject>> { () => tiOption, () => (tiOption.Item as Delight.AutoCompleteOption) }) }, new BindingPath(new List<string> { "Text" }, new List<Func<BindableObject>> { () => label1 }), () => label1.Text = (tiOption.Item as Delight.AutoCompleteOption).DisplayText, () => { }, false));
                defaultOptionItem.IsDynamic = true;
                defaultOptionItem.SetContentTemplateData(tiOption);
                return defaultOptionItem;
            }, typeof(ListItem), "DefaultOptionItem"));

            // templates for AutoCompleteOptionsList
            AutoCompleteOptionsList.ContentTemplates.Add(new ContentTemplate(tiOption => 
            {
                var assetOptionItem = new ListItem(this, AutoCompleteOptionsList.Content, "AssetOptionItem", AssetOptionItemTemplate);
                assetOptionItem.Click.RegisterHandler(this, "AutoCompleteOptionSelected", () => (tiOption.Item as Delight.AutoCompleteOption));
                var rawImage1 = new RawImage(this, assetOptionItem.Content, "RawImage1", RawImage1Template);

                // binding <RawImage Texture="{option.PreviewThumbnail}">
                assetOptionItem.Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "Item", "PreviewThumbnail" }, new List<Func<BindableObject>> { () => tiOption, () => (tiOption.Item as Delight.AutoCompleteOption) }) }, new BindingPath(new List<string> { "Texture" }, new List<Func<BindableObject>> { () => rawImage1 }), () => rawImage1.Texture = (tiOption.Item as Delight.AutoCompleteOption).PreviewThumbnail, () => { }, false));
                var label2 = new Label(this, assetOptionItem.Content, "Label2", Label2Template);

                // binding <Label Text="{option.DisplayText}">
                assetOptionItem.Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "Item", "DisplayText" }, new List<Func<BindableObject>> { () => tiOption, () => (tiOption.Item as Delight.AutoCompleteOption) }) }, new BindingPath(new List<string> { "Text" }, new List<Func<BindableObject>> { () => label2 }), () => label2.Text = (tiOption.Item as Delight.AutoCompleteOption).DisplayText, () => { }, false));
                assetOptionItem.IsDynamic = true;
                assetOptionItem.SetContentTemplateData(tiOption);
                return assetOptionItem;
            }, typeof(ListItem), "AssetOptionItem"));
            DebugTextLabel = new Label(this, AutoCompleteBox.Content, "DebugTextLabel", DebugTextLabelTemplate);
            TooltipBox = new Frame(this, UICanvas1.Content, "TooltipBox", TooltipBoxTemplate);
            TooltipLabel = new Label(this, TooltipBox.Content, "TooltipLabel", TooltipLabelTemplate);
            Image1 = new Image(this, TooltipBox.Content, "Image1", Image1Template);
            XmlEditLeftMargin = new Region(this, XmlEditRegion.Content, "XmlEditLeftMargin", XmlEditLeftMarginTemplate);
            LineNumbersLabel = new Label(this, XmlEditLeftMargin.Content, "LineNumbersLabel", LineNumbersLabelTemplate);
            LineNumbersRightBorder = new Region(this, XmlEditLeftMargin.Content, "LineNumbersRightBorder", LineNumbersRightBorderTemplate);
            this.AfterInitializeInternal();
        }

        public XmlEditor() : this(null)
        {
        }

        static XmlEditor()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(XmlEditorTemplates.Default, dependencyProperties);

            dependencyProperties.Add(XmlTextProperty);
            dependencyProperties.Add(IsFocusedProperty);
            dependencyProperties.Add(EditProperty);
            dependencyProperties.Add(AutoCompleteOptionsProperty);
            dependencyProperties.Add(SelectedAutoCompleteOptionProperty);
            dependencyProperties.Add(DesignerViewsProperty);
            dependencyProperties.Add(ScrollableRegionProperty);
            dependencyProperties.Add(ScrollableRegionTemplateProperty);
            dependencyProperties.Add(XmlEditRegionProperty);
            dependencyProperties.Add(XmlEditRegionTemplateProperty);
            dependencyProperties.Add(XmlTextRegionProperty);
            dependencyProperties.Add(XmlTextRegionTemplateProperty);
            dependencyProperties.Add(TextSelectionProperty);
            dependencyProperties.Add(TextSelectionTemplateProperty);
            dependencyProperties.Add(XmlTextLabelProperty);
            dependencyProperties.Add(XmlTextLabelTemplateProperty);
            dependencyProperties.Add(CaretProperty);
            dependencyProperties.Add(CaretTemplateProperty);
            dependencyProperties.Add(UICanvas1Property);
            dependencyProperties.Add(UICanvas1TemplateProperty);
            dependencyProperties.Add(AutoCompleteBoxProperty);
            dependencyProperties.Add(AutoCompleteBoxTemplateProperty);
            dependencyProperties.Add(AutoCompleteOptionsListProperty);
            dependencyProperties.Add(AutoCompleteOptionsListTemplateProperty);
            dependencyProperties.Add(DefaultOptionItemProperty);
            dependencyProperties.Add(DefaultOptionItemTemplateProperty);
            dependencyProperties.Add(Label1Property);
            dependencyProperties.Add(Label1TemplateProperty);
            dependencyProperties.Add(AssetOptionItemProperty);
            dependencyProperties.Add(AssetOptionItemTemplateProperty);
            dependencyProperties.Add(RawImage1Property);
            dependencyProperties.Add(RawImage1TemplateProperty);
            dependencyProperties.Add(Label2Property);
            dependencyProperties.Add(Label2TemplateProperty);
            dependencyProperties.Add(DebugTextLabelProperty);
            dependencyProperties.Add(DebugTextLabelTemplateProperty);
            dependencyProperties.Add(TooltipBoxProperty);
            dependencyProperties.Add(TooltipBoxTemplateProperty);
            dependencyProperties.Add(TooltipLabelProperty);
            dependencyProperties.Add(TooltipLabelTemplateProperty);
            dependencyProperties.Add(Image1Property);
            dependencyProperties.Add(Image1TemplateProperty);
            dependencyProperties.Add(XmlEditLeftMarginProperty);
            dependencyProperties.Add(XmlEditLeftMarginTemplateProperty);
            dependencyProperties.Add(LineNumbersLabelProperty);
            dependencyProperties.Add(LineNumbersLabelTemplateProperty);
            dependencyProperties.Add(LineNumbersRightBorderProperty);
            dependencyProperties.Add(LineNumbersRightBorderTemplateProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<System.String> XmlTextProperty = new DependencyProperty<System.String>("XmlText");
        /// <summary>Used to set the XML text in the editor.</summary>
        public System.String XmlText
        {
            get { return XmlTextProperty.GetValue(this); }
            set { XmlTextProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> IsFocusedProperty = new DependencyProperty<System.Boolean>("IsFocused");
        /// <summary>Boolean indicating if the editor is focused.</summary>
        public System.Boolean IsFocused
        {
            get { return IsFocusedProperty.GetValue(this); }
            set { IsFocusedProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ViewAction> EditProperty = new DependencyProperty<ViewAction>("Edit", () => new ViewAction());
        /// <summary>Action called when the user edits the view.</summary>
        public ViewAction Edit
        {
            get { return EditProperty.GetValue(this); }
            set { EditProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Delight.AutoCompleteOptionData> AutoCompleteOptionsProperty = new DependencyProperty<Delight.AutoCompleteOptionData>("AutoCompleteOptions");
        /// <summary>Contains a list of options presented when auto-complete is activated.</summary>
        public Delight.AutoCompleteOptionData AutoCompleteOptions
        {
            get { return AutoCompleteOptionsProperty.GetValue(this); }
            set { AutoCompleteOptionsProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Delight.AutoCompleteOption> SelectedAutoCompleteOptionProperty = new DependencyProperty<Delight.AutoCompleteOption>("SelectedAutoCompleteOption");
        /// <summary>The currently selected auto-complete option.</summary>
        public Delight.AutoCompleteOption SelectedAutoCompleteOption
        {
            get { return SelectedAutoCompleteOptionProperty.GetValue(this); }
            set { SelectedAutoCompleteOptionProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Delight.Editor.Parser.DesignerViewData> DesignerViewsProperty = new DependencyProperty<Delight.Editor.Parser.DesignerViewData>("DesignerViews");
        /// <summary>Contains the list of all views.</summary>
        public Delight.Editor.Parser.DesignerViewData DesignerViews
        {
            get { return DesignerViewsProperty.GetValue(this); }
            set { DesignerViewsProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ScrollableRegion> ScrollableRegionProperty = new DependencyProperty<ScrollableRegion>("ScrollableRegion");
        public ScrollableRegion ScrollableRegion
        {
            get { return ScrollableRegionProperty.GetValue(this); }
            set { ScrollableRegionProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> ScrollableRegionTemplateProperty = new DependencyProperty<Template>("ScrollableRegionTemplate");
        public Template ScrollableRegionTemplate
        {
            get { return ScrollableRegionTemplateProperty.GetValue(this); }
            set { ScrollableRegionTemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> XmlEditRegionProperty = new DependencyProperty<Region>("XmlEditRegion");
        public Region XmlEditRegion
        {
            get { return XmlEditRegionProperty.GetValue(this); }
            set { XmlEditRegionProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> XmlEditRegionTemplateProperty = new DependencyProperty<Template>("XmlEditRegionTemplate");
        public Template XmlEditRegionTemplate
        {
            get { return XmlEditRegionTemplateProperty.GetValue(this); }
            set { XmlEditRegionTemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> XmlTextRegionProperty = new DependencyProperty<Region>("XmlTextRegion");
        public Region XmlTextRegion
        {
            get { return XmlTextRegionProperty.GetValue(this); }
            set { XmlTextRegionProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> XmlTextRegionTemplateProperty = new DependencyProperty<Template>("XmlTextRegionTemplate");
        public Template XmlTextRegionTemplate
        {
            get { return XmlTextRegionTemplateProperty.GetValue(this); }
            set { XmlTextRegionTemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<CanvasRendererView> TextSelectionProperty = new DependencyProperty<CanvasRendererView>("TextSelection");
        public CanvasRendererView TextSelection
        {
            get { return TextSelectionProperty.GetValue(this); }
            set { TextSelectionProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> TextSelectionTemplateProperty = new DependencyProperty<Template>("TextSelectionTemplate");
        public Template TextSelectionTemplate
        {
            get { return TextSelectionTemplateProperty.GetValue(this); }
            set { TextSelectionTemplateProperty.SetValue(this, value); }
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

        public readonly static DependencyProperty<Label> CaretProperty = new DependencyProperty<Label>("Caret");
        public Label Caret
        {
            get { return CaretProperty.GetValue(this); }
            set { CaretProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> CaretTemplateProperty = new DependencyProperty<Template>("CaretTemplate");
        public Template CaretTemplate
        {
            get { return CaretTemplateProperty.GetValue(this); }
            set { CaretTemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<UICanvas> UICanvas1Property = new DependencyProperty<UICanvas>("UICanvas1");
        public UICanvas UICanvas1
        {
            get { return UICanvas1Property.GetValue(this); }
            set { UICanvas1Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> UICanvas1TemplateProperty = new DependencyProperty<Template>("UICanvas1Template");
        public Template UICanvas1Template
        {
            get { return UICanvas1TemplateProperty.GetValue(this); }
            set { UICanvas1TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> AutoCompleteBoxProperty = new DependencyProperty<Region>("AutoCompleteBox");
        public Region AutoCompleteBox
        {
            get { return AutoCompleteBoxProperty.GetValue(this); }
            set { AutoCompleteBoxProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> AutoCompleteBoxTemplateProperty = new DependencyProperty<Template>("AutoCompleteBoxTemplate");
        public Template AutoCompleteBoxTemplate
        {
            get { return AutoCompleteBoxTemplateProperty.GetValue(this); }
            set { AutoCompleteBoxTemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<List> AutoCompleteOptionsListProperty = new DependencyProperty<List>("AutoCompleteOptionsList");
        public List AutoCompleteOptionsList
        {
            get { return AutoCompleteOptionsListProperty.GetValue(this); }
            set { AutoCompleteOptionsListProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> AutoCompleteOptionsListTemplateProperty = new DependencyProperty<Template>("AutoCompleteOptionsListTemplate");
        public Template AutoCompleteOptionsListTemplate
        {
            get { return AutoCompleteOptionsListTemplateProperty.GetValue(this); }
            set { AutoCompleteOptionsListTemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ListItem> DefaultOptionItemProperty = new DependencyProperty<ListItem>("DefaultOptionItem");
        public ListItem DefaultOptionItem
        {
            get { return DefaultOptionItemProperty.GetValue(this); }
            set { DefaultOptionItemProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> DefaultOptionItemTemplateProperty = new DependencyProperty<Template>("DefaultOptionItemTemplate");
        public Template DefaultOptionItemTemplate
        {
            get { return DefaultOptionItemTemplateProperty.GetValue(this); }
            set { DefaultOptionItemTemplateProperty.SetValue(this, value); }
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

        public readonly static DependencyProperty<ListItem> AssetOptionItemProperty = new DependencyProperty<ListItem>("AssetOptionItem");
        public ListItem AssetOptionItem
        {
            get { return AssetOptionItemProperty.GetValue(this); }
            set { AssetOptionItemProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> AssetOptionItemTemplateProperty = new DependencyProperty<Template>("AssetOptionItemTemplate");
        public Template AssetOptionItemTemplate
        {
            get { return AssetOptionItemTemplateProperty.GetValue(this); }
            set { AssetOptionItemTemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<RawImage> RawImage1Property = new DependencyProperty<RawImage>("RawImage1");
        public RawImage RawImage1
        {
            get { return RawImage1Property.GetValue(this); }
            set { RawImage1Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> RawImage1TemplateProperty = new DependencyProperty<Template>("RawImage1Template");
        public Template RawImage1Template
        {
            get { return RawImage1TemplateProperty.GetValue(this); }
            set { RawImage1TemplateProperty.SetValue(this, value); }
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

        public readonly static DependencyProperty<Label> DebugTextLabelProperty = new DependencyProperty<Label>("DebugTextLabel");
        public Label DebugTextLabel
        {
            get { return DebugTextLabelProperty.GetValue(this); }
            set { DebugTextLabelProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> DebugTextLabelTemplateProperty = new DependencyProperty<Template>("DebugTextLabelTemplate");
        public Template DebugTextLabelTemplate
        {
            get { return DebugTextLabelTemplateProperty.GetValue(this); }
            set { DebugTextLabelTemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Frame> TooltipBoxProperty = new DependencyProperty<Frame>("TooltipBox");
        public Frame TooltipBox
        {
            get { return TooltipBoxProperty.GetValue(this); }
            set { TooltipBoxProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> TooltipBoxTemplateProperty = new DependencyProperty<Template>("TooltipBoxTemplate");
        public Template TooltipBoxTemplate
        {
            get { return TooltipBoxTemplateProperty.GetValue(this); }
            set { TooltipBoxTemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Label> TooltipLabelProperty = new DependencyProperty<Label>("TooltipLabel");
        public Label TooltipLabel
        {
            get { return TooltipLabelProperty.GetValue(this); }
            set { TooltipLabelProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> TooltipLabelTemplateProperty = new DependencyProperty<Template>("TooltipLabelTemplate");
        public Template TooltipLabelTemplate
        {
            get { return TooltipLabelTemplateProperty.GetValue(this); }
            set { TooltipLabelTemplateProperty.SetValue(this, value); }
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

        public readonly static DependencyProperty<Region> XmlEditLeftMarginProperty = new DependencyProperty<Region>("XmlEditLeftMargin");
        public Region XmlEditLeftMargin
        {
            get { return XmlEditLeftMarginProperty.GetValue(this); }
            set { XmlEditLeftMarginProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> XmlEditLeftMarginTemplateProperty = new DependencyProperty<Template>("XmlEditLeftMarginTemplate");
        public Template XmlEditLeftMarginTemplate
        {
            get { return XmlEditLeftMarginTemplateProperty.GetValue(this); }
            set { XmlEditLeftMarginTemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Label> LineNumbersLabelProperty = new DependencyProperty<Label>("LineNumbersLabel");
        public Label LineNumbersLabel
        {
            get { return LineNumbersLabelProperty.GetValue(this); }
            set { LineNumbersLabelProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> LineNumbersLabelTemplateProperty = new DependencyProperty<Template>("LineNumbersLabelTemplate");
        public Template LineNumbersLabelTemplate
        {
            get { return LineNumbersLabelTemplateProperty.GetValue(this); }
            set { LineNumbersLabelTemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> LineNumbersRightBorderProperty = new DependencyProperty<Region>("LineNumbersRightBorder");
        public Region LineNumbersRightBorder
        {
            get { return LineNumbersRightBorderProperty.GetValue(this); }
            set { LineNumbersRightBorderProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> LineNumbersRightBorderTemplateProperty = new DependencyProperty<Template>("LineNumbersRightBorderTemplate");
        public Template LineNumbersRightBorderTemplate
        {
            get { return LineNumbersRightBorderTemplateProperty.GetValue(this); }
            set { LineNumbersRightBorderTemplateProperty.SetValue(this, value); }
        }

        #endregion
    }

    #region Data Templates

    public static class XmlEditorTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return XmlEditor;
            }
        }

        private static Template _xmlEditor;
        public static Template XmlEditor
        {
            get
            {
#if UNITY_EDITOR
                if (_xmlEditor == null || _xmlEditor.CurrentVersion != Template.Version)
#else
                if (_xmlEditor == null)
#endif
                {
                    _xmlEditor = new Template(UIImageViewTemplates.UIImageView);
#if UNITY_EDITOR
                    _xmlEditor.Name = "XmlEditor";
#endif
                    Delight.XmlEditor.BackgroundColorProperty.SetDefault(_xmlEditor, new UnityEngine.Color(0.9843137f, 0.9843137f, 0.9843137f, 1f));
                    Delight.XmlEditor.EnableScriptEventsProperty.SetDefault(_xmlEditor, true);
                    Delight.XmlEditor.IsFocusedProperty.SetDefault(_xmlEditor, true);
                    Delight.XmlEditor.ScrollableRegionTemplateProperty.SetDefault(_xmlEditor, XmlEditorScrollableRegion);
                    Delight.XmlEditor.XmlEditRegionTemplateProperty.SetDefault(_xmlEditor, XmlEditorXmlEditRegion);
                    Delight.XmlEditor.XmlTextRegionTemplateProperty.SetDefault(_xmlEditor, XmlEditorXmlTextRegion);
                    Delight.XmlEditor.TextSelectionTemplateProperty.SetDefault(_xmlEditor, XmlEditorTextSelection);
                    Delight.XmlEditor.XmlTextLabelTemplateProperty.SetDefault(_xmlEditor, XmlEditorXmlTextLabel);
                    Delight.XmlEditor.CaretTemplateProperty.SetDefault(_xmlEditor, XmlEditorCaret);
                    Delight.XmlEditor.UICanvas1TemplateProperty.SetDefault(_xmlEditor, XmlEditorUICanvas1);
                    Delight.XmlEditor.AutoCompleteBoxTemplateProperty.SetDefault(_xmlEditor, XmlEditorAutoCompleteBox);
                    Delight.XmlEditor.AutoCompleteOptionsListTemplateProperty.SetDefault(_xmlEditor, XmlEditorAutoCompleteOptionsList);
                    Delight.XmlEditor.DefaultOptionItemTemplateProperty.SetDefault(_xmlEditor, XmlEditorDefaultOptionItem);
                    Delight.XmlEditor.Label1TemplateProperty.SetDefault(_xmlEditor, XmlEditorLabel1);
                    Delight.XmlEditor.AssetOptionItemTemplateProperty.SetDefault(_xmlEditor, XmlEditorAssetOptionItem);
                    Delight.XmlEditor.RawImage1TemplateProperty.SetDefault(_xmlEditor, XmlEditorRawImage1);
                    Delight.XmlEditor.Label2TemplateProperty.SetDefault(_xmlEditor, XmlEditorLabel2);
                    Delight.XmlEditor.DebugTextLabelTemplateProperty.SetDefault(_xmlEditor, XmlEditorDebugTextLabel);
                    Delight.XmlEditor.TooltipBoxTemplateProperty.SetDefault(_xmlEditor, XmlEditorTooltipBox);
                    Delight.XmlEditor.TooltipLabelTemplateProperty.SetDefault(_xmlEditor, XmlEditorTooltipLabel);
                    Delight.XmlEditor.Image1TemplateProperty.SetDefault(_xmlEditor, XmlEditorImage1);
                    Delight.XmlEditor.XmlEditLeftMarginTemplateProperty.SetDefault(_xmlEditor, XmlEditorXmlEditLeftMargin);
                    Delight.XmlEditor.LineNumbersLabelTemplateProperty.SetDefault(_xmlEditor, XmlEditorLineNumbersLabel);
                    Delight.XmlEditor.LineNumbersRightBorderTemplateProperty.SetDefault(_xmlEditor, XmlEditorLineNumbersRightBorder);
                }
                return _xmlEditor;
            }
        }

        private static Template _xmlEditorScrollableRegion;
        public static Template XmlEditorScrollableRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_xmlEditorScrollableRegion == null || _xmlEditorScrollableRegion.CurrentVersion != Template.Version)
#else
                if (_xmlEditorScrollableRegion == null)
#endif
                {
                    _xmlEditorScrollableRegion = new Template(ScrollableRegionTemplates.ScrollableRegion);
#if UNITY_EDITOR
                    _xmlEditorScrollableRegion.Name = "XmlEditorScrollableRegion";
#endif
                    Delight.ScrollableRegion.WidthProperty.SetDefault(_xmlEditorScrollableRegion, new ElementSize(1f, ElementSizeUnit.Percents));
                    Delight.ScrollableRegion.HeightProperty.SetDefault(_xmlEditorScrollableRegion, new ElementSize(1f, ElementSizeUnit.Percents));
                    Delight.ScrollableRegion.ContentAlignmentProperty.SetDefault(_xmlEditorScrollableRegion, Delight.ElementAlignment.TopLeft);
                    Delight.ScrollableRegion.HasInertiaProperty.SetDefault(_xmlEditorScrollableRegion, false);
                    Delight.ScrollableRegion.ScrollBoundsProperty.SetDefault(_xmlEditorScrollableRegion, Delight.ScrollBounds.Clamped);
                    Delight.ScrollableRegion.ScrollEnabledProperty.SetDefault(_xmlEditorScrollableRegion, false);
                    Delight.ScrollableRegion.UnblockDragEventsInChildrenProperty.SetDefault(_xmlEditorScrollableRegion, false);
                    Delight.ScrollableRegion.ContentRegionTemplateProperty.SetDefault(_xmlEditorScrollableRegion, XmlEditorScrollableRegionContentRegion);
                    Delight.ScrollableRegion.HorizontalScrollbarTemplateProperty.SetDefault(_xmlEditorScrollableRegion, XmlEditorScrollableRegionHorizontalScrollbar);
                    Delight.ScrollableRegion.VerticalScrollbarTemplateProperty.SetDefault(_xmlEditorScrollableRegion, XmlEditorScrollableRegionVerticalScrollbar);
                }
                return _xmlEditorScrollableRegion;
            }
        }

        private static Template _xmlEditorScrollableRegionContentRegion;
        public static Template XmlEditorScrollableRegionContentRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_xmlEditorScrollableRegionContentRegion == null || _xmlEditorScrollableRegionContentRegion.CurrentVersion != Template.Version)
#else
                if (_xmlEditorScrollableRegionContentRegion == null)
#endif
                {
                    _xmlEditorScrollableRegionContentRegion = new Template(ScrollableRegionTemplates.ScrollableRegionContentRegion);
#if UNITY_EDITOR
                    _xmlEditorScrollableRegionContentRegion.Name = "XmlEditorScrollableRegionContentRegion";
#endif
                }
                return _xmlEditorScrollableRegionContentRegion;
            }
        }

        private static Template _xmlEditorScrollableRegionHorizontalScrollbar;
        public static Template XmlEditorScrollableRegionHorizontalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_xmlEditorScrollableRegionHorizontalScrollbar == null || _xmlEditorScrollableRegionHorizontalScrollbar.CurrentVersion != Template.Version)
#else
                if (_xmlEditorScrollableRegionHorizontalScrollbar == null)
#endif
                {
                    _xmlEditorScrollableRegionHorizontalScrollbar = new Template(ScrollableRegionTemplates.ScrollableRegionHorizontalScrollbar);
#if UNITY_EDITOR
                    _xmlEditorScrollableRegionHorizontalScrollbar.Name = "XmlEditorScrollableRegionHorizontalScrollbar";
#endif
                    Delight.Scrollbar.BackgroundColorProperty.SetDefault(_xmlEditorScrollableRegionHorizontalScrollbar, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Scrollbar.BreadthProperty.SetDefault(_xmlEditorScrollableRegionHorizontalScrollbar, new ElementSize(15f, ElementSizeUnit.Pixels));
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_xmlEditorScrollableRegionHorizontalScrollbar, XmlEditorScrollableRegionHorizontalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_xmlEditorScrollableRegionHorizontalScrollbar, XmlEditorScrollableRegionHorizontalScrollbarHandle);
                }
                return _xmlEditorScrollableRegionHorizontalScrollbar;
            }
        }

        private static Template _xmlEditorScrollableRegionHorizontalScrollbarBar;
        public static Template XmlEditorScrollableRegionHorizontalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_xmlEditorScrollableRegionHorizontalScrollbarBar == null || _xmlEditorScrollableRegionHorizontalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_xmlEditorScrollableRegionHorizontalScrollbarBar == null)
#endif
                {
                    _xmlEditorScrollableRegionHorizontalScrollbarBar = new Template(ScrollableRegionTemplates.ScrollableRegionHorizontalScrollbarBar);
#if UNITY_EDITOR
                    _xmlEditorScrollableRegionHorizontalScrollbarBar.Name = "XmlEditorScrollableRegionHorizontalScrollbarBar";
#endif
                    Delight.Image.ColorProperty.SetDefault(_xmlEditorScrollableRegionHorizontalScrollbarBar, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Image.MarginProperty.SetDefault(_xmlEditorScrollableRegionHorizontalScrollbarBar, new ElementMargin(new ElementSize(3f, ElementSizeUnit.Pixels), new ElementSize(5f, ElementSizeUnit.Pixels), new ElementSize(3f, ElementSizeUnit.Pixels), new ElementSize(5f, ElementSizeUnit.Pixels)));
                }
                return _xmlEditorScrollableRegionHorizontalScrollbarBar;
            }
        }

        private static Template _xmlEditorScrollableRegionHorizontalScrollbarHandle;
        public static Template XmlEditorScrollableRegionHorizontalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_xmlEditorScrollableRegionHorizontalScrollbarHandle == null || _xmlEditorScrollableRegionHorizontalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_xmlEditorScrollableRegionHorizontalScrollbarHandle == null)
#endif
                {
                    _xmlEditorScrollableRegionHorizontalScrollbarHandle = new Template(ScrollableRegionTemplates.ScrollableRegionHorizontalScrollbarHandle);
#if UNITY_EDITOR
                    _xmlEditorScrollableRegionHorizontalScrollbarHandle.Name = "XmlEditorScrollableRegionHorizontalScrollbarHandle";
#endif
                    Delight.Image.ColorProperty.SetDefault(_xmlEditorScrollableRegionHorizontalScrollbarHandle, new UnityEngine.Color(0.7490196f, 0.7490196f, 0.7490196f, 1f));
                }
                return _xmlEditorScrollableRegionHorizontalScrollbarHandle;
            }
        }

        private static Template _xmlEditorScrollableRegionVerticalScrollbar;
        public static Template XmlEditorScrollableRegionVerticalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_xmlEditorScrollableRegionVerticalScrollbar == null || _xmlEditorScrollableRegionVerticalScrollbar.CurrentVersion != Template.Version)
#else
                if (_xmlEditorScrollableRegionVerticalScrollbar == null)
#endif
                {
                    _xmlEditorScrollableRegionVerticalScrollbar = new Template(ScrollableRegionTemplates.ScrollableRegionVerticalScrollbar);
#if UNITY_EDITOR
                    _xmlEditorScrollableRegionVerticalScrollbar.Name = "XmlEditorScrollableRegionVerticalScrollbar";
#endif
                    Delight.Scrollbar.BackgroundColorProperty.SetDefault(_xmlEditorScrollableRegionVerticalScrollbar, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Scrollbar.BreadthProperty.SetDefault(_xmlEditorScrollableRegionVerticalScrollbar, new ElementSize(15f, ElementSizeUnit.Pixels));
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_xmlEditorScrollableRegionVerticalScrollbar, XmlEditorScrollableRegionVerticalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_xmlEditorScrollableRegionVerticalScrollbar, XmlEditorScrollableRegionVerticalScrollbarHandle);
                }
                return _xmlEditorScrollableRegionVerticalScrollbar;
            }
        }

        private static Template _xmlEditorScrollableRegionVerticalScrollbarBar;
        public static Template XmlEditorScrollableRegionVerticalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_xmlEditorScrollableRegionVerticalScrollbarBar == null || _xmlEditorScrollableRegionVerticalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_xmlEditorScrollableRegionVerticalScrollbarBar == null)
#endif
                {
                    _xmlEditorScrollableRegionVerticalScrollbarBar = new Template(ScrollableRegionTemplates.ScrollableRegionVerticalScrollbarBar);
#if UNITY_EDITOR
                    _xmlEditorScrollableRegionVerticalScrollbarBar.Name = "XmlEditorScrollableRegionVerticalScrollbarBar";
#endif
                    Delight.Image.ColorProperty.SetDefault(_xmlEditorScrollableRegionVerticalScrollbarBar, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Image.MarginProperty.SetDefault(_xmlEditorScrollableRegionVerticalScrollbarBar, new ElementMargin(new ElementSize(5f, ElementSizeUnit.Pixels), new ElementSize(3f, ElementSizeUnit.Pixels), new ElementSize(5f, ElementSizeUnit.Pixels), new ElementSize(3f, ElementSizeUnit.Pixels)));
                }
                return _xmlEditorScrollableRegionVerticalScrollbarBar;
            }
        }

        private static Template _xmlEditorScrollableRegionVerticalScrollbarHandle;
        public static Template XmlEditorScrollableRegionVerticalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_xmlEditorScrollableRegionVerticalScrollbarHandle == null || _xmlEditorScrollableRegionVerticalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_xmlEditorScrollableRegionVerticalScrollbarHandle == null)
#endif
                {
                    _xmlEditorScrollableRegionVerticalScrollbarHandle = new Template(ScrollableRegionTemplates.ScrollableRegionVerticalScrollbarHandle);
#if UNITY_EDITOR
                    _xmlEditorScrollableRegionVerticalScrollbarHandle.Name = "XmlEditorScrollableRegionVerticalScrollbarHandle";
#endif
                    Delight.Image.ColorProperty.SetDefault(_xmlEditorScrollableRegionVerticalScrollbarHandle, new UnityEngine.Color(0.7490196f, 0.7490196f, 0.7490196f, 1f));
                }
                return _xmlEditorScrollableRegionVerticalScrollbarHandle;
            }
        }

        private static Template _xmlEditorXmlEditRegion;
        public static Template XmlEditorXmlEditRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_xmlEditorXmlEditRegion == null || _xmlEditorXmlEditRegion.CurrentVersion != Template.Version)
#else
                if (_xmlEditorXmlEditRegion == null)
#endif
                {
                    _xmlEditorXmlEditRegion = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _xmlEditorXmlEditRegion.Name = "XmlEditorXmlEditRegion";
#endif
                    Delight.Region.WidthProperty.SetDefault(_xmlEditorXmlEditRegion, new ElementSize(500f, ElementSizeUnit.Pixels));
                    Delight.Region.HeightProperty.SetDefault(_xmlEditorXmlEditRegion, new ElementSize(500f, ElementSizeUnit.Pixels));
                    Delight.Region.AlignmentProperty.SetDefault(_xmlEditorXmlEditRegion, Delight.ElementAlignment.TopLeft);
                }
                return _xmlEditorXmlEditRegion;
            }
        }

        private static Template _xmlEditorXmlTextRegion;
        public static Template XmlEditorXmlTextRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_xmlEditorXmlTextRegion == null || _xmlEditorXmlTextRegion.CurrentVersion != Template.Version)
#else
                if (_xmlEditorXmlTextRegion == null)
#endif
                {
                    _xmlEditorXmlTextRegion = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _xmlEditorXmlTextRegion.Name = "XmlEditorXmlTextRegion";
#endif
                    Delight.Region.WidthProperty.SetDefault(_xmlEditorXmlTextRegion, new ElementSize(1f, ElementSizeUnit.Percents));
                    Delight.Region.HeightProperty.SetDefault(_xmlEditorXmlTextRegion, new ElementSize(1f, ElementSizeUnit.Percents));
                    Delight.Region.MarginProperty.SetDefault(_xmlEditorXmlTextRegion, new ElementMargin(new ElementSize(60f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels)));
                }
                return _xmlEditorXmlTextRegion;
            }
        }

        private static Template _xmlEditorTextSelection;
        public static Template XmlEditorTextSelection
        {
            get
            {
#if UNITY_EDITOR
                if (_xmlEditorTextSelection == null || _xmlEditorTextSelection.CurrentVersion != Template.Version)
#else
                if (_xmlEditorTextSelection == null)
#endif
                {
                    _xmlEditorTextSelection = new Template(CanvasRendererViewTemplates.CanvasRendererView);
#if UNITY_EDITOR
                    _xmlEditorTextSelection.Name = "XmlEditorTextSelection";
#endif
                    Delight.CanvasRendererView.WidthProperty.SetDefault(_xmlEditorTextSelection, new ElementSize(2000f, ElementSizeUnit.Pixels));
                    Delight.CanvasRendererView.HeightProperty.SetDefault(_xmlEditorTextSelection, new ElementSize(10000f, ElementSizeUnit.Pixels));
                    Delight.CanvasRendererView.AlignmentProperty.SetDefault(_xmlEditorTextSelection, Delight.ElementAlignment.TopLeft);
                }
                return _xmlEditorTextSelection;
            }
        }

        private static Template _xmlEditorXmlTextLabel;
        public static Template XmlEditorXmlTextLabel
        {
            get
            {
#if UNITY_EDITOR
                if (_xmlEditorXmlTextLabel == null || _xmlEditorXmlTextLabel.CurrentVersion != Template.Version)
#else
                if (_xmlEditorXmlTextLabel == null)
#endif
                {
                    _xmlEditorXmlTextLabel = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _xmlEditorXmlTextLabel.Name = "XmlEditorXmlTextLabel";
#endif
                    Delight.Label.WidthProperty.SetDefault(_xmlEditorXmlTextLabel, new ElementSize(2000f, ElementSizeUnit.Pixels));
                    Delight.Label.HeightProperty.SetDefault(_xmlEditorXmlTextLabel, new ElementSize(10000f, ElementSizeUnit.Pixels));
                    Delight.Label.FontProperty.SetDefault(_xmlEditorXmlTextLabel, Assets.TMP_FontAssets["Inconsolata-Regular SDF"]);
                    Delight.Label.FontSizeProperty.SetDefault(_xmlEditorXmlTextLabel, 20f);
                    Delight.Label.TextAlignmentProperty.SetDefault(_xmlEditorXmlTextLabel, TMPro.TextAlignmentOptions.TopLeft);
                    Delight.Label.RichTextProperty.SetDefault(_xmlEditorXmlTextLabel, false);
                    Delight.Label.OverflowModeProperty.SetDefault(_xmlEditorXmlTextLabel, TMPro.TextOverflowModes.Overflow);
                    Delight.Label.EnableWordWrappingProperty.SetDefault(_xmlEditorXmlTextLabel, false);
                    Delight.Label.AlignmentProperty.SetDefault(_xmlEditorXmlTextLabel, Delight.ElementAlignment.TopLeft);
                }
                return _xmlEditorXmlTextLabel;
            }
        }

        private static Template _xmlEditorCaret;
        public static Template XmlEditorCaret
        {
            get
            {
#if UNITY_EDITOR
                if (_xmlEditorCaret == null || _xmlEditorCaret.CurrentVersion != Template.Version)
#else
                if (_xmlEditorCaret == null)
#endif
                {
                    _xmlEditorCaret = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _xmlEditorCaret.Name = "XmlEditorCaret";
#endif
                    Delight.Label.TextProperty.SetDefault(_xmlEditorCaret, "|");
                    Delight.Label.WidthProperty.SetDefault(_xmlEditorCaret, new ElementSize(20f, ElementSizeUnit.Pixels));
                    Delight.Label.HeightProperty.SetDefault(_xmlEditorCaret, new ElementSize(20f, ElementSizeUnit.Pixels));
                    Delight.Label.FontProperty.SetDefault(_xmlEditorCaret, Assets.TMP_FontAssets["Inconsolata-Regular SDF"]);
                    Delight.Label.FontSizeProperty.SetDefault(_xmlEditorCaret, 20f);
                    Delight.Label.FontColorProperty.SetDefault(_xmlEditorCaret, new UnityEngine.Color(0f, 0f, 0f, 1f));
                    Delight.Label.OffsetProperty.SetDefault(_xmlEditorCaret, new ElementMargin(new ElementSize(-5f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels)));
                    Delight.Label.TextAlignmentProperty.SetDefault(_xmlEditorCaret, TMPro.TextAlignmentOptions.TopLeft);
                    Delight.Label.RichTextProperty.SetDefault(_xmlEditorCaret, false);
                    Delight.Label.OverflowModeProperty.SetDefault(_xmlEditorCaret, TMPro.TextOverflowModes.Overflow);
                    Delight.Label.EnableWordWrappingProperty.SetDefault(_xmlEditorCaret, false);
                    Delight.Label.AlignmentProperty.SetDefault(_xmlEditorCaret, Delight.ElementAlignment.TopLeft);
                }
                return _xmlEditorCaret;
            }
        }

        private static Template _xmlEditorUICanvas1;
        public static Template XmlEditorUICanvas1
        {
            get
            {
#if UNITY_EDITOR
                if (_xmlEditorUICanvas1 == null || _xmlEditorUICanvas1.CurrentVersion != Template.Version)
#else
                if (_xmlEditorUICanvas1 == null)
#endif
                {
                    _xmlEditorUICanvas1 = new Template(UICanvasTemplates.UICanvas);
#if UNITY_EDITOR
                    _xmlEditorUICanvas1.Name = "XmlEditorUICanvas1";
#endif
                    Delight.UICanvas.SortingOrderProperty.SetDefault(_xmlEditorUICanvas1, 1);
                    Delight.UICanvas.OverrideSortingProperty.SetDefault(_xmlEditorUICanvas1, true);
                }
                return _xmlEditorUICanvas1;
            }
        }

        private static Template _xmlEditorAutoCompleteBox;
        public static Template XmlEditorAutoCompleteBox
        {
            get
            {
#if UNITY_EDITOR
                if (_xmlEditorAutoCompleteBox == null || _xmlEditorAutoCompleteBox.CurrentVersion != Template.Version)
#else
                if (_xmlEditorAutoCompleteBox == null)
#endif
                {
                    _xmlEditorAutoCompleteBox = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _xmlEditorAutoCompleteBox.Name = "XmlEditorAutoCompleteBox";
#endif
                    Delight.Region.WidthProperty.SetDefault(_xmlEditorAutoCompleteBox, new ElementSize(300f, ElementSizeUnit.Pixels));
                    Delight.Region.HeightProperty.SetDefault(_xmlEditorAutoCompleteBox, new ElementSize(150f, ElementSizeUnit.Pixels));
                    Delight.Region.AlignmentProperty.SetDefault(_xmlEditorAutoCompleteBox, Delight.ElementAlignment.TopLeft);
                    Delight.Region.BackgroundColorProperty.SetDefault(_xmlEditorAutoCompleteBox, new UnityEngine.Color(0.8862745f, 0.8862745f, 0.8862745f, 1f));
                    Delight.Region.IsVisibleProperty.SetDefault(_xmlEditorAutoCompleteBox, false);
                }
                return _xmlEditorAutoCompleteBox;
            }
        }

        private static Template _xmlEditorAutoCompleteOptionsList;
        public static Template XmlEditorAutoCompleteOptionsList
        {
            get
            {
#if UNITY_EDITOR
                if (_xmlEditorAutoCompleteOptionsList == null || _xmlEditorAutoCompleteOptionsList.CurrentVersion != Template.Version)
#else
                if (_xmlEditorAutoCompleteOptionsList == null)
#endif
                {
                    _xmlEditorAutoCompleteOptionsList = new Template(ListTemplates.List);
#if UNITY_EDITOR
                    _xmlEditorAutoCompleteOptionsList.Name = "XmlEditorAutoCompleteOptionsList";
#endif
                    Delight.List.IsScrollableProperty.SetDefault(_xmlEditorAutoCompleteOptionsList, true);
                    Delight.List.WidthProperty.SetDefault(_xmlEditorAutoCompleteOptionsList, new ElementSize(1f, ElementSizeUnit.Percents));
                    Delight.List.HeightProperty.SetDefault(_xmlEditorAutoCompleteOptionsList, new ElementSize(150f, ElementSizeUnit.Pixels));
                    Delight.List.BackgroundColorProperty.SetDefault(_xmlEditorAutoCompleteOptionsList, new UnityEngine.Color(0.8862745f, 0.8862745f, 0.8862745f, 1f));
                    Delight.List.IsVirtualizedProperty.SetDefault(_xmlEditorAutoCompleteOptionsList, true);
                    Delight.List.ItemsProperty.SetHasBinding(_xmlEditorAutoCompleteOptionsList);
                    Delight.List.SelectedItemProperty.SetHasBinding(_xmlEditorAutoCompleteOptionsList);
                    Delight.List.ScrollableRegionTemplateProperty.SetDefault(_xmlEditorAutoCompleteOptionsList, XmlEditorAutoCompleteOptionsListScrollableRegion);
                }
                return _xmlEditorAutoCompleteOptionsList;
            }
        }

        private static Template _xmlEditorAutoCompleteOptionsListScrollableRegion;
        public static Template XmlEditorAutoCompleteOptionsListScrollableRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_xmlEditorAutoCompleteOptionsListScrollableRegion == null || _xmlEditorAutoCompleteOptionsListScrollableRegion.CurrentVersion != Template.Version)
#else
                if (_xmlEditorAutoCompleteOptionsListScrollableRegion == null)
#endif
                {
                    _xmlEditorAutoCompleteOptionsListScrollableRegion = new Template(ListTemplates.ListScrollableRegion);
#if UNITY_EDITOR
                    _xmlEditorAutoCompleteOptionsListScrollableRegion.Name = "XmlEditorAutoCompleteOptionsListScrollableRegion";
#endif
                    Delight.ScrollableRegion.ContentRegionTemplateProperty.SetDefault(_xmlEditorAutoCompleteOptionsListScrollableRegion, XmlEditorAutoCompleteOptionsListScrollableRegionContentRegion);
                    Delight.ScrollableRegion.HorizontalScrollbarTemplateProperty.SetDefault(_xmlEditorAutoCompleteOptionsListScrollableRegion, XmlEditorAutoCompleteOptionsListScrollableRegionHorizontalScrollbar);
                    Delight.ScrollableRegion.VerticalScrollbarTemplateProperty.SetDefault(_xmlEditorAutoCompleteOptionsListScrollableRegion, XmlEditorAutoCompleteOptionsListScrollableRegionVerticalScrollbar);
                }
                return _xmlEditorAutoCompleteOptionsListScrollableRegion;
            }
        }

        private static Template _xmlEditorAutoCompleteOptionsListScrollableRegionContentRegion;
        public static Template XmlEditorAutoCompleteOptionsListScrollableRegionContentRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_xmlEditorAutoCompleteOptionsListScrollableRegionContentRegion == null || _xmlEditorAutoCompleteOptionsListScrollableRegionContentRegion.CurrentVersion != Template.Version)
#else
                if (_xmlEditorAutoCompleteOptionsListScrollableRegionContentRegion == null)
#endif
                {
                    _xmlEditorAutoCompleteOptionsListScrollableRegionContentRegion = new Template(ListTemplates.ListScrollableRegionContentRegion);
#if UNITY_EDITOR
                    _xmlEditorAutoCompleteOptionsListScrollableRegionContentRegion.Name = "XmlEditorAutoCompleteOptionsListScrollableRegionContentRegion";
#endif
                }
                return _xmlEditorAutoCompleteOptionsListScrollableRegionContentRegion;
            }
        }

        private static Template _xmlEditorAutoCompleteOptionsListScrollableRegionHorizontalScrollbar;
        public static Template XmlEditorAutoCompleteOptionsListScrollableRegionHorizontalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_xmlEditorAutoCompleteOptionsListScrollableRegionHorizontalScrollbar == null || _xmlEditorAutoCompleteOptionsListScrollableRegionHorizontalScrollbar.CurrentVersion != Template.Version)
#else
                if (_xmlEditorAutoCompleteOptionsListScrollableRegionHorizontalScrollbar == null)
#endif
                {
                    _xmlEditorAutoCompleteOptionsListScrollableRegionHorizontalScrollbar = new Template(ListTemplates.ListScrollableRegionHorizontalScrollbar);
#if UNITY_EDITOR
                    _xmlEditorAutoCompleteOptionsListScrollableRegionHorizontalScrollbar.Name = "XmlEditorAutoCompleteOptionsListScrollableRegionHorizontalScrollbar";
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_xmlEditorAutoCompleteOptionsListScrollableRegionHorizontalScrollbar, XmlEditorAutoCompleteOptionsListScrollableRegionHorizontalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_xmlEditorAutoCompleteOptionsListScrollableRegionHorizontalScrollbar, XmlEditorAutoCompleteOptionsListScrollableRegionHorizontalScrollbarHandle);
                }
                return _xmlEditorAutoCompleteOptionsListScrollableRegionHorizontalScrollbar;
            }
        }

        private static Template _xmlEditorAutoCompleteOptionsListScrollableRegionHorizontalScrollbarBar;
        public static Template XmlEditorAutoCompleteOptionsListScrollableRegionHorizontalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_xmlEditorAutoCompleteOptionsListScrollableRegionHorizontalScrollbarBar == null || _xmlEditorAutoCompleteOptionsListScrollableRegionHorizontalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_xmlEditorAutoCompleteOptionsListScrollableRegionHorizontalScrollbarBar == null)
#endif
                {
                    _xmlEditorAutoCompleteOptionsListScrollableRegionHorizontalScrollbarBar = new Template(ListTemplates.ListScrollableRegionHorizontalScrollbarBar);
#if UNITY_EDITOR
                    _xmlEditorAutoCompleteOptionsListScrollableRegionHorizontalScrollbarBar.Name = "XmlEditorAutoCompleteOptionsListScrollableRegionHorizontalScrollbarBar";
#endif
                }
                return _xmlEditorAutoCompleteOptionsListScrollableRegionHorizontalScrollbarBar;
            }
        }

        private static Template _xmlEditorAutoCompleteOptionsListScrollableRegionHorizontalScrollbarHandle;
        public static Template XmlEditorAutoCompleteOptionsListScrollableRegionHorizontalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_xmlEditorAutoCompleteOptionsListScrollableRegionHorizontalScrollbarHandle == null || _xmlEditorAutoCompleteOptionsListScrollableRegionHorizontalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_xmlEditorAutoCompleteOptionsListScrollableRegionHorizontalScrollbarHandle == null)
#endif
                {
                    _xmlEditorAutoCompleteOptionsListScrollableRegionHorizontalScrollbarHandle = new Template(ListTemplates.ListScrollableRegionHorizontalScrollbarHandle);
#if UNITY_EDITOR
                    _xmlEditorAutoCompleteOptionsListScrollableRegionHorizontalScrollbarHandle.Name = "XmlEditorAutoCompleteOptionsListScrollableRegionHorizontalScrollbarHandle";
#endif
                }
                return _xmlEditorAutoCompleteOptionsListScrollableRegionHorizontalScrollbarHandle;
            }
        }

        private static Template _xmlEditorAutoCompleteOptionsListScrollableRegionVerticalScrollbar;
        public static Template XmlEditorAutoCompleteOptionsListScrollableRegionVerticalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_xmlEditorAutoCompleteOptionsListScrollableRegionVerticalScrollbar == null || _xmlEditorAutoCompleteOptionsListScrollableRegionVerticalScrollbar.CurrentVersion != Template.Version)
#else
                if (_xmlEditorAutoCompleteOptionsListScrollableRegionVerticalScrollbar == null)
#endif
                {
                    _xmlEditorAutoCompleteOptionsListScrollableRegionVerticalScrollbar = new Template(ListTemplates.ListScrollableRegionVerticalScrollbar);
#if UNITY_EDITOR
                    _xmlEditorAutoCompleteOptionsListScrollableRegionVerticalScrollbar.Name = "XmlEditorAutoCompleteOptionsListScrollableRegionVerticalScrollbar";
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_xmlEditorAutoCompleteOptionsListScrollableRegionVerticalScrollbar, XmlEditorAutoCompleteOptionsListScrollableRegionVerticalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_xmlEditorAutoCompleteOptionsListScrollableRegionVerticalScrollbar, XmlEditorAutoCompleteOptionsListScrollableRegionVerticalScrollbarHandle);
                }
                return _xmlEditorAutoCompleteOptionsListScrollableRegionVerticalScrollbar;
            }
        }

        private static Template _xmlEditorAutoCompleteOptionsListScrollableRegionVerticalScrollbarBar;
        public static Template XmlEditorAutoCompleteOptionsListScrollableRegionVerticalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_xmlEditorAutoCompleteOptionsListScrollableRegionVerticalScrollbarBar == null || _xmlEditorAutoCompleteOptionsListScrollableRegionVerticalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_xmlEditorAutoCompleteOptionsListScrollableRegionVerticalScrollbarBar == null)
#endif
                {
                    _xmlEditorAutoCompleteOptionsListScrollableRegionVerticalScrollbarBar = new Template(ListTemplates.ListScrollableRegionVerticalScrollbarBar);
#if UNITY_EDITOR
                    _xmlEditorAutoCompleteOptionsListScrollableRegionVerticalScrollbarBar.Name = "XmlEditorAutoCompleteOptionsListScrollableRegionVerticalScrollbarBar";
#endif
                }
                return _xmlEditorAutoCompleteOptionsListScrollableRegionVerticalScrollbarBar;
            }
        }

        private static Template _xmlEditorAutoCompleteOptionsListScrollableRegionVerticalScrollbarHandle;
        public static Template XmlEditorAutoCompleteOptionsListScrollableRegionVerticalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_xmlEditorAutoCompleteOptionsListScrollableRegionVerticalScrollbarHandle == null || _xmlEditorAutoCompleteOptionsListScrollableRegionVerticalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_xmlEditorAutoCompleteOptionsListScrollableRegionVerticalScrollbarHandle == null)
#endif
                {
                    _xmlEditorAutoCompleteOptionsListScrollableRegionVerticalScrollbarHandle = new Template(ListTemplates.ListScrollableRegionVerticalScrollbarHandle);
#if UNITY_EDITOR
                    _xmlEditorAutoCompleteOptionsListScrollableRegionVerticalScrollbarHandle.Name = "XmlEditorAutoCompleteOptionsListScrollableRegionVerticalScrollbarHandle";
#endif
                }
                return _xmlEditorAutoCompleteOptionsListScrollableRegionVerticalScrollbarHandle;
            }
        }

        private static Template _xmlEditorDefaultOptionItem;
        public static Template XmlEditorDefaultOptionItem
        {
            get
            {
#if UNITY_EDITOR
                if (_xmlEditorDefaultOptionItem == null || _xmlEditorDefaultOptionItem.CurrentVersion != Template.Version)
#else
                if (_xmlEditorDefaultOptionItem == null)
#endif
                {
                    _xmlEditorDefaultOptionItem = new Template(ListItemTemplates.ListItem);
#if UNITY_EDITOR
                    _xmlEditorDefaultOptionItem.Name = "XmlEditorDefaultOptionItem";
#endif
                    Delight.ListItem.WidthProperty.SetDefault(_xmlEditorDefaultOptionItem, new ElementSize(1f, ElementSizeUnit.Percents));
                    Delight.ListItem.HeightProperty.SetDefault(_xmlEditorDefaultOptionItem, new ElementSize(20f, ElementSizeUnit.Pixels));
                    Delight.ListItem.BackgroundColorProperty.SetDefault(_xmlEditorDefaultOptionItem, new UnityEngine.Color(0.8862745f, 0.8862745f, 0.8862745f, 1f));
                    Delight.ListItem.BackgroundColorProperty.SetStateDefault("Selected", _xmlEditorDefaultOptionItem, new UnityEngine.Color(0.7843137f, 0.7843137f, 0.7843137f, 1f));
                }
                return _xmlEditorDefaultOptionItem;
            }
        }

        private static Template _xmlEditorLabel1;
        public static Template XmlEditorLabel1
        {
            get
            {
#if UNITY_EDITOR
                if (_xmlEditorLabel1 == null || _xmlEditorLabel1.CurrentVersion != Template.Version)
#else
                if (_xmlEditorLabel1 == null)
#endif
                {
                    _xmlEditorLabel1 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _xmlEditorLabel1.Name = "XmlEditorLabel1";
#endif
                    Delight.Label.WidthProperty.SetDefault(_xmlEditorLabel1, new ElementSize(1f, ElementSizeUnit.Percents));
                    Delight.Label.HeightProperty.SetDefault(_xmlEditorLabel1, new ElementSize(21f, ElementSizeUnit.Pixels));
                    Delight.Label.AlignmentProperty.SetDefault(_xmlEditorLabel1, Delight.ElementAlignment.TopLeft);
                    Delight.Label.RichTextProperty.SetDefault(_xmlEditorLabel1, true);
                    Delight.Label.OverflowModeProperty.SetDefault(_xmlEditorLabel1, TMPro.TextOverflowModes.Truncate);
                    Delight.Label.EnableWordWrappingProperty.SetDefault(_xmlEditorLabel1, false);
                    Delight.Label.FontProperty.SetDefault(_xmlEditorLabel1, Assets.TMP_FontAssets["Inconsolata-Regular SDF"]);
                    Delight.Label.FontSizeProperty.SetDefault(_xmlEditorLabel1, 20f);
                    Delight.Label.FontColorProperty.SetDefault(_xmlEditorLabel1, new UnityEngine.Color(0.3568628f, 0.3568628f, 0.3568628f, 1f));
                    Delight.Label.MarginProperty.SetDefault(_xmlEditorLabel1, new ElementMargin(new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels)));
                    Delight.Label.TextAlignmentProperty.SetDefault(_xmlEditorLabel1, TMPro.TextAlignmentOptions.TopLeft);
                    Delight.Label.TextProperty.SetHasBinding(_xmlEditorLabel1);
                }
                return _xmlEditorLabel1;
            }
        }

        private static Template _xmlEditorAssetOptionItem;
        public static Template XmlEditorAssetOptionItem
        {
            get
            {
#if UNITY_EDITOR
                if (_xmlEditorAssetOptionItem == null || _xmlEditorAssetOptionItem.CurrentVersion != Template.Version)
#else
                if (_xmlEditorAssetOptionItem == null)
#endif
                {
                    _xmlEditorAssetOptionItem = new Template(ListItemTemplates.ListItem);
#if UNITY_EDITOR
                    _xmlEditorAssetOptionItem.Name = "XmlEditorAssetOptionItem";
#endif
                    Delight.ListItem.WidthProperty.SetDefault(_xmlEditorAssetOptionItem, new ElementSize(1f, ElementSizeUnit.Percents));
                    Delight.ListItem.HeightProperty.SetDefault(_xmlEditorAssetOptionItem, new ElementSize(20f, ElementSizeUnit.Pixels));
                    Delight.ListItem.BackgroundColorProperty.SetDefault(_xmlEditorAssetOptionItem, new UnityEngine.Color(0.8862745f, 0.8862745f, 0.8862745f, 1f));
                    Delight.ListItem.BackgroundColorProperty.SetStateDefault("Selected", _xmlEditorAssetOptionItem, new UnityEngine.Color(0.7843137f, 0.7843137f, 0.7843137f, 1f));
                }
                return _xmlEditorAssetOptionItem;
            }
        }

        private static Template _xmlEditorRawImage1;
        public static Template XmlEditorRawImage1
        {
            get
            {
#if UNITY_EDITOR
                if (_xmlEditorRawImage1 == null || _xmlEditorRawImage1.CurrentVersion != Template.Version)
#else
                if (_xmlEditorRawImage1 == null)
#endif
                {
                    _xmlEditorRawImage1 = new Template(RawImageTemplates.RawImage);
#if UNITY_EDITOR
                    _xmlEditorRawImage1.Name = "XmlEditorRawImage1";
#endif
                    Delight.RawImage.WidthProperty.SetDefault(_xmlEditorRawImage1, new ElementSize(20f, ElementSizeUnit.Pixels));
                    Delight.RawImage.HeightProperty.SetDefault(_xmlEditorRawImage1, new ElementSize(20f, ElementSizeUnit.Pixels));
                    Delight.RawImage.AlignmentProperty.SetDefault(_xmlEditorRawImage1, Delight.ElementAlignment.Left);
                    Delight.RawImage.TextureProperty.SetHasBinding(_xmlEditorRawImage1);
                }
                return _xmlEditorRawImage1;
            }
        }

        private static Template _xmlEditorLabel2;
        public static Template XmlEditorLabel2
        {
            get
            {
#if UNITY_EDITOR
                if (_xmlEditorLabel2 == null || _xmlEditorLabel2.CurrentVersion != Template.Version)
#else
                if (_xmlEditorLabel2 == null)
#endif
                {
                    _xmlEditorLabel2 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _xmlEditorLabel2.Name = "XmlEditorLabel2";
#endif
                    Delight.Label.WidthProperty.SetDefault(_xmlEditorLabel2, new ElementSize(1f, ElementSizeUnit.Percents));
                    Delight.Label.HeightProperty.SetDefault(_xmlEditorLabel2, new ElementSize(21f, ElementSizeUnit.Pixels));
                    Delight.Label.AlignmentProperty.SetDefault(_xmlEditorLabel2, Delight.ElementAlignment.TopLeft);
                    Delight.Label.RichTextProperty.SetDefault(_xmlEditorLabel2, true);
                    Delight.Label.OverflowModeProperty.SetDefault(_xmlEditorLabel2, TMPro.TextOverflowModes.Truncate);
                    Delight.Label.EnableWordWrappingProperty.SetDefault(_xmlEditorLabel2, false);
                    Delight.Label.FontProperty.SetDefault(_xmlEditorLabel2, Assets.TMP_FontAssets["Inconsolata-Regular SDF"]);
                    Delight.Label.FontSizeProperty.SetDefault(_xmlEditorLabel2, 20f);
                    Delight.Label.FontColorProperty.SetDefault(_xmlEditorLabel2, new UnityEngine.Color(0.3568628f, 0.3568628f, 0.3568628f, 1f));
                    Delight.Label.MarginProperty.SetDefault(_xmlEditorLabel2, new ElementMargin(new ElementSize(25f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels)));
                    Delight.Label.TextAlignmentProperty.SetDefault(_xmlEditorLabel2, TMPro.TextAlignmentOptions.TopLeft);
                    Delight.Label.TextProperty.SetHasBinding(_xmlEditorLabel2);
                }
                return _xmlEditorLabel2;
            }
        }

        private static Template _xmlEditorDebugTextLabel;
        public static Template XmlEditorDebugTextLabel
        {
            get
            {
#if UNITY_EDITOR
                if (_xmlEditorDebugTextLabel == null || _xmlEditorDebugTextLabel.CurrentVersion != Template.Version)
#else
                if (_xmlEditorDebugTextLabel == null)
#endif
                {
                    _xmlEditorDebugTextLabel = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _xmlEditorDebugTextLabel.Name = "XmlEditorDebugTextLabel";
#endif
                    Delight.Label.WidthProperty.SetDefault(_xmlEditorDebugTextLabel, new ElementSize(1f, ElementSizeUnit.Percents));
                    Delight.Label.HeightProperty.SetDefault(_xmlEditorDebugTextLabel, new ElementSize(21f, ElementSizeUnit.Pixels));
                    Delight.Label.AlignmentProperty.SetDefault(_xmlEditorDebugTextLabel, Delight.ElementAlignment.TopLeft);
                    Delight.Label.RichTextProperty.SetDefault(_xmlEditorDebugTextLabel, false);
                    Delight.Label.OverflowModeProperty.SetDefault(_xmlEditorDebugTextLabel, TMPro.TextOverflowModes.Ellipsis);
                    Delight.Label.EnableWordWrappingProperty.SetDefault(_xmlEditorDebugTextLabel, false);
                    Delight.Label.FontProperty.SetDefault(_xmlEditorDebugTextLabel, Assets.TMP_FontAssets["Inconsolata-Regular SDF"]);
                    Delight.Label.FontSizeProperty.SetDefault(_xmlEditorDebugTextLabel, 20f);
                    Delight.Label.FontColorProperty.SetDefault(_xmlEditorDebugTextLabel, new UnityEngine.Color(0.3568628f, 0.3568628f, 0.3568628f, 1f));
                    Delight.Label.OffsetProperty.SetDefault(_xmlEditorDebugTextLabel, new ElementMargin(new ElementSize(200f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels)));
                    Delight.Label.TextAlignmentProperty.SetDefault(_xmlEditorDebugTextLabel, TMPro.TextAlignmentOptions.TopLeft);
                    Delight.Label.IsVisibleProperty.SetDefault(_xmlEditorDebugTextLabel, false);
                }
                return _xmlEditorDebugTextLabel;
            }
        }

        private static Template _xmlEditorTooltipBox;
        public static Template XmlEditorTooltipBox
        {
            get
            {
#if UNITY_EDITOR
                if (_xmlEditorTooltipBox == null || _xmlEditorTooltipBox.CurrentVersion != Template.Version)
#else
                if (_xmlEditorTooltipBox == null)
#endif
                {
                    _xmlEditorTooltipBox = new Template(FrameTemplates.Frame);
#if UNITY_EDITOR
                    _xmlEditorTooltipBox.Name = "XmlEditorTooltipBox";
#endif
                    Delight.Frame.BackgroundColorProperty.SetDefault(_xmlEditorTooltipBox, new UnityEngine.Color(0.8078431f, 0.9058824f, 0.8235294f, 1f));
                    Delight.Frame.AlignmentProperty.SetDefault(_xmlEditorTooltipBox, Delight.ElementAlignment.BottomLeft);
                    Delight.Frame.IsVisibleProperty.SetDefault(_xmlEditorTooltipBox, false);
                }
                return _xmlEditorTooltipBox;
            }
        }

        private static Template _xmlEditorTooltipLabel;
        public static Template XmlEditorTooltipLabel
        {
            get
            {
#if UNITY_EDITOR
                if (_xmlEditorTooltipLabel == null || _xmlEditorTooltipLabel.CurrentVersion != Template.Version)
#else
                if (_xmlEditorTooltipLabel == null)
#endif
                {
                    _xmlEditorTooltipLabel = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _xmlEditorTooltipLabel.Name = "XmlEditorTooltipLabel";
#endif
                    Delight.Label.TextProperty.SetDefault(_xmlEditorTooltipLabel, "TooltipLabel");
                    Delight.Label.FontProperty.SetDefault(_xmlEditorTooltipLabel, Assets.TMP_FontAssets["Segoe UI SDF"]);
                    Delight.Label.FontSizeProperty.SetDefault(_xmlEditorTooltipLabel, 14f);
                    Delight.Label.AutoSizeProperty.SetDefault(_xmlEditorTooltipLabel, Delight.AutoSize.Default);
                    Delight.Label.MarginProperty.SetDefault(_xmlEditorTooltipLabel, new ElementMargin(new ElementSize(5f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(5f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels)));
                    Delight.Label.MaxWidthProperty.SetDefault(_xmlEditorTooltipLabel, new ElementSize(400f, ElementSizeUnit.Pixels));
                }
                return _xmlEditorTooltipLabel;
            }
        }

        private static Template _xmlEditorImage1;
        public static Template XmlEditorImage1
        {
            get
            {
#if UNITY_EDITOR
                if (_xmlEditorImage1 == null || _xmlEditorImage1.CurrentVersion != Template.Version)
#else
                if (_xmlEditorImage1 == null)
#endif
                {
                    _xmlEditorImage1 = new Template(ImageTemplates.Image);
#if UNITY_EDITOR
                    _xmlEditorImage1.Name = "XmlEditorImage1";
#endif
                    Delight.Image.SpriteProperty.SetDefault(_xmlEditorImage1, Assets.Sprites["TooltipArrow"]);
                    Delight.Image.AlignmentProperty.SetDefault(_xmlEditorImage1, Delight.ElementAlignment.BottomLeft);
                    Delight.Image.OffsetProperty.SetDefault(_xmlEditorImage1, new ElementMargin(new ElementSize(10f, ElementSizeUnit.Pixels), new ElementSize(6f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels)));
                    Delight.Image.ColorProperty.SetDefault(_xmlEditorImage1, new UnityEngine.Color(0.8078431f, 0.9058824f, 0.8235294f, 1f));
                }
                return _xmlEditorImage1;
            }
        }

        private static Template _xmlEditorXmlEditLeftMargin;
        public static Template XmlEditorXmlEditLeftMargin
        {
            get
            {
#if UNITY_EDITOR
                if (_xmlEditorXmlEditLeftMargin == null || _xmlEditorXmlEditLeftMargin.CurrentVersion != Template.Version)
#else
                if (_xmlEditorXmlEditLeftMargin == null)
#endif
                {
                    _xmlEditorXmlEditLeftMargin = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _xmlEditorXmlEditLeftMargin.Name = "XmlEditorXmlEditLeftMargin";
#endif
                    Delight.Region.WidthProperty.SetDefault(_xmlEditorXmlEditLeftMargin, new ElementSize(50f, ElementSizeUnit.Pixels));
                    Delight.Region.HeightProperty.SetDefault(_xmlEditorXmlEditLeftMargin, new ElementSize(21f, ElementSizeUnit.Pixels));
                    Delight.Region.AlignmentProperty.SetDefault(_xmlEditorXmlEditLeftMargin, Delight.ElementAlignment.TopLeft);
                    Delight.Region.OffsetProperty.SetDefault(_xmlEditorXmlEditLeftMargin, new ElementMargin(new ElementSize(0f, ElementSizeUnit.Pixels)));
                    Delight.Region.MarginProperty.SetDefault(_xmlEditorXmlEditLeftMargin, new ElementMargin(new ElementSize(0f, ElementSizeUnit.Pixels)));
                    Delight.Region.BackgroundColorProperty.SetDefault(_xmlEditorXmlEditLeftMargin, new UnityEngine.Color(0.9843137f, 0.9843137f, 0.9843137f, 1f));
                }
                return _xmlEditorXmlEditLeftMargin;
            }
        }

        private static Template _xmlEditorLineNumbersLabel;
        public static Template XmlEditorLineNumbersLabel
        {
            get
            {
#if UNITY_EDITOR
                if (_xmlEditorLineNumbersLabel == null || _xmlEditorLineNumbersLabel.CurrentVersion != Template.Version)
#else
                if (_xmlEditorLineNumbersLabel == null)
#endif
                {
                    _xmlEditorLineNumbersLabel = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _xmlEditorLineNumbersLabel.Name = "XmlEditorLineNumbersLabel";
#endif
                    Delight.Label.WidthProperty.SetDefault(_xmlEditorLineNumbersLabel, new ElementSize(50f, ElementSizeUnit.Pixels));
                    Delight.Label.HeightProperty.SetDefault(_xmlEditorLineNumbersLabel, new ElementSize(21f, ElementSizeUnit.Pixels));
                    Delight.Label.FontProperty.SetDefault(_xmlEditorLineNumbersLabel, Assets.TMP_FontAssets["Inconsolata-Regular SDF"]);
                    Delight.Label.FontSizeProperty.SetDefault(_xmlEditorLineNumbersLabel, 20f);
                    Delight.Label.FontColorProperty.SetDefault(_xmlEditorLineNumbersLabel, new UnityEngine.Color(0.5333334f, 0.5333334f, 0.5333334f, 1f));
                    Delight.Label.TextAlignmentProperty.SetDefault(_xmlEditorLineNumbersLabel, TMPro.TextAlignmentOptions.TopRight);
                    Delight.Label.RichTextProperty.SetDefault(_xmlEditorLineNumbersLabel, false);
                    Delight.Label.OverflowModeProperty.SetDefault(_xmlEditorLineNumbersLabel, TMPro.TextOverflowModes.Overflow);
                    Delight.Label.EnableWordWrappingProperty.SetDefault(_xmlEditorLineNumbersLabel, false);
                    Delight.Label.AlignmentProperty.SetDefault(_xmlEditorLineNumbersLabel, Delight.ElementAlignment.TopLeft);
                }
                return _xmlEditorLineNumbersLabel;
            }
        }

        private static Template _xmlEditorLineNumbersRightBorder;
        public static Template XmlEditorLineNumbersRightBorder
        {
            get
            {
#if UNITY_EDITOR
                if (_xmlEditorLineNumbersRightBorder == null || _xmlEditorLineNumbersRightBorder.CurrentVersion != Template.Version)
#else
                if (_xmlEditorLineNumbersRightBorder == null)
#endif
                {
                    _xmlEditorLineNumbersRightBorder = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _xmlEditorLineNumbersRightBorder.Name = "XmlEditorLineNumbersRightBorder";
#endif
                    Delight.Region.BackgroundColorProperty.SetDefault(_xmlEditorLineNumbersRightBorder, new UnityEngine.Color(0.9843137f, 0.9843137f, 0.9843137f, 1f));
                    Delight.Region.WidthProperty.SetDefault(_xmlEditorLineNumbersRightBorder, new ElementSize(10f, ElementSizeUnit.Pixels));
                    Delight.Region.AlignmentProperty.SetDefault(_xmlEditorLineNumbersRightBorder, Delight.ElementAlignment.Right);
                    Delight.Region.OffsetProperty.SetDefault(_xmlEditorLineNumbersRightBorder, new ElementMargin(new ElementSize(10f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels)));
                }
                return _xmlEditorLineNumbersRightBorder;
            }
        }

        #endregion
    }

    #endregion
}

#endif
