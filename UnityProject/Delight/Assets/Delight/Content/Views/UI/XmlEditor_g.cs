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

        public XmlEditor(View parent, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :
            base(parent, layoutParent, id, template ?? XmlEditorTemplates.Default, initializer)
        {
            // constructing ScrollableRegion (ScrollableRegion)
            ScrollableRegion = new ScrollableRegion(this, this, "ScrollableRegion", ScrollableRegionTemplate);
            XmlEditRegion = new Region(this, ScrollableRegion.Content, "XmlEditRegion", XmlEditRegionTemplate);
            XmlEditLeftMargin = new Region(this, XmlEditRegion.Content, "XmlEditLeftMargin", XmlEditLeftMarginTemplate);
            LineNumbersLabel = new Label(this, XmlEditLeftMargin.Content, "LineNumbersLabel", LineNumbersLabelTemplate);
            XmlTextRegion = new Region(this, XmlEditRegion.Content, "XmlTextRegion", XmlTextRegionTemplate);
            TextSelection = new CanvasRendererView(this, XmlTextRegion.Content, "TextSelection", TextSelectionTemplate);
            XmlTextLabel = new Label(this, XmlTextRegion.Content, "XmlTextLabel", XmlTextLabelTemplate);
            Caret = new Label(this, XmlTextRegion.Content, "Caret", CaretTemplate);

            // constructing Label (DebugTextLabel)
            DebugTextLabel = new Label(this, this, "DebugTextLabel", DebugTextLabelTemplate);
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
            dependencyProperties.Add(ScrollableRegionProperty);
            dependencyProperties.Add(ScrollableRegionTemplateProperty);
            dependencyProperties.Add(XmlEditRegionProperty);
            dependencyProperties.Add(XmlEditRegionTemplateProperty);
            dependencyProperties.Add(XmlEditLeftMarginProperty);
            dependencyProperties.Add(XmlEditLeftMarginTemplateProperty);
            dependencyProperties.Add(LineNumbersLabelProperty);
            dependencyProperties.Add(LineNumbersLabelTemplateProperty);
            dependencyProperties.Add(XmlTextRegionProperty);
            dependencyProperties.Add(XmlTextRegionTemplateProperty);
            dependencyProperties.Add(TextSelectionProperty);
            dependencyProperties.Add(TextSelectionTemplateProperty);
            dependencyProperties.Add(XmlTextLabelProperty);
            dependencyProperties.Add(XmlTextLabelTemplateProperty);
            dependencyProperties.Add(CaretProperty);
            dependencyProperties.Add(CaretTemplateProperty);
            dependencyProperties.Add(DebugTextLabelProperty);
            dependencyProperties.Add(DebugTextLabelTemplateProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<System.String> XmlTextProperty = new DependencyProperty<System.String>("XmlText");
        public System.String XmlText
        {
            get { return XmlTextProperty.GetValue(this); }
            set { XmlTextProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> IsFocusedProperty = new DependencyProperty<System.Boolean>("IsFocused");
        public System.Boolean IsFocused
        {
            get { return IsFocusedProperty.GetValue(this); }
            set { IsFocusedProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ViewAction> EditProperty = new DependencyProperty<ViewAction>("Edit", () => new ViewAction());
        public ViewAction Edit
        {
            get { return EditProperty.GetValue(this); }
            set { EditProperty.SetValue(this, value); }
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
                    Delight.XmlEditor.XmlEditLeftMarginTemplateProperty.SetDefault(_xmlEditor, XmlEditorXmlEditLeftMargin);
                    Delight.XmlEditor.LineNumbersLabelTemplateProperty.SetDefault(_xmlEditor, XmlEditorLineNumbersLabel);
                    Delight.XmlEditor.XmlTextRegionTemplateProperty.SetDefault(_xmlEditor, XmlEditorXmlTextRegion);
                    Delight.XmlEditor.TextSelectionTemplateProperty.SetDefault(_xmlEditor, XmlEditorTextSelection);
                    Delight.XmlEditor.XmlTextLabelTemplateProperty.SetDefault(_xmlEditor, XmlEditorXmlTextLabel);
                    Delight.XmlEditor.CaretTemplateProperty.SetDefault(_xmlEditor, XmlEditorCaret);
                    Delight.XmlEditor.DebugTextLabelTemplateProperty.SetDefault(_xmlEditor, XmlEditorDebugTextLabel);
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
                    Delight.Region.MarginProperty.SetDefault(_xmlEditorXmlEditLeftMargin, new ElementMargin(new ElementSize(0f, ElementSizeUnit.Pixels)));
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
                    Delight.Label.WidthProperty.SetDefault(_xmlEditorDebugTextLabel, new ElementSize(300f, ElementSizeUnit.Pixels));
                    Delight.Label.HeightProperty.SetDefault(_xmlEditorDebugTextLabel, new ElementSize(22f, ElementSizeUnit.Pixels));
                    Delight.Label.AlignmentProperty.SetDefault(_xmlEditorDebugTextLabel, Delight.ElementAlignment.TopRight);
                    Delight.Label.RichTextProperty.SetDefault(_xmlEditorDebugTextLabel, false);
                    Delight.Label.OverflowModeProperty.SetDefault(_xmlEditorDebugTextLabel, TMPro.TextOverflowModes.Overflow);
                    Delight.Label.FontProperty.SetDefault(_xmlEditorDebugTextLabel, Assets.TMP_FontAssets["Inconsolata-Regular SDF"]);
                    Delight.Label.FontSizeProperty.SetDefault(_xmlEditorDebugTextLabel, 20f);
                    Delight.Label.MarginProperty.SetDefault(_xmlEditorDebugTextLabel, new ElementMargin(new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(21f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels)));
                    Delight.Label.TextAlignmentProperty.SetDefault(_xmlEditorDebugTextLabel, TMPro.TextAlignmentOptions.TopRight);
                }
                return _xmlEditorDebugTextLabel;
            }
        }

        #endregion
    }

    #endregion
}

#endif
