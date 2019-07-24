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
            // constructing ScrollableRegion (ScrollableArea)
            ScrollableArea = new ScrollableRegion(this, this, "ScrollableArea", ScrollableAreaTemplate);
            XmlEditRegion = new Region(this, ScrollableArea.Content, "XmlEditRegion", XmlEditRegionTemplate);
            LineNumbersLabel = new Label(this, XmlEditRegion.Content, "LineNumbersLabel", LineNumbersLabelTemplate);
            XmlTextRegion = new Region(this, XmlEditRegion.Content, "XmlTextRegion", XmlTextRegionTemplate);
            XmlTextLabel = new Label(this, XmlTextRegion.Content, "XmlTextLabel", XmlTextLabelTemplate);
            Caret = new Label(this, XmlTextRegion.Content, "Caret", CaretTemplate);

            // constructing Label (CaretElement)
            CaretElement = new Label(this, this, "CaretElement", CaretElementTemplate);
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
            dependencyProperties.Add(ScrollableAreaProperty);
            dependencyProperties.Add(ScrollableAreaTemplateProperty);
            dependencyProperties.Add(XmlEditRegionProperty);
            dependencyProperties.Add(XmlEditRegionTemplateProperty);
            dependencyProperties.Add(LineNumbersLabelProperty);
            dependencyProperties.Add(LineNumbersLabelTemplateProperty);
            dependencyProperties.Add(XmlTextRegionProperty);
            dependencyProperties.Add(XmlTextRegionTemplateProperty);
            dependencyProperties.Add(XmlTextLabelProperty);
            dependencyProperties.Add(XmlTextLabelTemplateProperty);
            dependencyProperties.Add(CaretProperty);
            dependencyProperties.Add(CaretTemplateProperty);
            dependencyProperties.Add(CaretElementProperty);
            dependencyProperties.Add(CaretElementTemplateProperty);
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

        public readonly static DependencyProperty<ScrollableRegion> ScrollableAreaProperty = new DependencyProperty<ScrollableRegion>("ScrollableArea");
        public ScrollableRegion ScrollableArea
        {
            get { return ScrollableAreaProperty.GetValue(this); }
            set { ScrollableAreaProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> ScrollableAreaTemplateProperty = new DependencyProperty<Template>("ScrollableAreaTemplate");
        public Template ScrollableAreaTemplate
        {
            get { return ScrollableAreaTemplateProperty.GetValue(this); }
            set { ScrollableAreaTemplateProperty.SetValue(this, value); }
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

        public readonly static DependencyProperty<Label> CaretElementProperty = new DependencyProperty<Label>("CaretElement");
        public Label CaretElement
        {
            get { return CaretElementProperty.GetValue(this); }
            set { CaretElementProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> CaretElementTemplateProperty = new DependencyProperty<Template>("CaretElementTemplate");
        public Template CaretElementTemplate
        {
            get { return CaretElementTemplateProperty.GetValue(this); }
            set { CaretElementTemplateProperty.SetValue(this, value); }
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
                    Delight.XmlEditor.ScrollableAreaTemplateProperty.SetDefault(_xmlEditor, XmlEditorScrollableArea);
                    Delight.XmlEditor.XmlEditRegionTemplateProperty.SetDefault(_xmlEditor, XmlEditorXmlEditRegion);
                    Delight.XmlEditor.LineNumbersLabelTemplateProperty.SetDefault(_xmlEditor, XmlEditorLineNumbersLabel);
                    Delight.XmlEditor.XmlTextRegionTemplateProperty.SetDefault(_xmlEditor, XmlEditorXmlTextRegion);
                    Delight.XmlEditor.XmlTextLabelTemplateProperty.SetDefault(_xmlEditor, XmlEditorXmlTextLabel);
                    Delight.XmlEditor.CaretTemplateProperty.SetDefault(_xmlEditor, XmlEditorCaret);
                    Delight.XmlEditor.CaretElementTemplateProperty.SetDefault(_xmlEditor, XmlEditorCaretElement);
                }
                return _xmlEditor;
            }
        }

        private static Template _xmlEditorScrollableArea;
        public static Template XmlEditorScrollableArea
        {
            get
            {
#if UNITY_EDITOR
                if (_xmlEditorScrollableArea == null || _xmlEditorScrollableArea.CurrentVersion != Template.Version)
#else
                if (_xmlEditorScrollableArea == null)
#endif
                {
                    _xmlEditorScrollableArea = new Template(ScrollableRegionTemplates.ScrollableRegion);
#if UNITY_EDITOR
                    _xmlEditorScrollableArea.Name = "XmlEditorScrollableArea";
#endif
                    Delight.ScrollableRegion.WidthProperty.SetDefault(_xmlEditorScrollableArea, new ElementSize(1f, ElementSizeUnit.Percents));
                    Delight.ScrollableRegion.HeightProperty.SetDefault(_xmlEditorScrollableArea, new ElementSize(1f, ElementSizeUnit.Percents));
                    Delight.ScrollableRegion.ContentAlignmentProperty.SetDefault(_xmlEditorScrollableArea, Delight.ElementAlignment.TopLeft);
                    Delight.ScrollableRegion.HasInertiaProperty.SetDefault(_xmlEditorScrollableArea, false);
                    Delight.ScrollableRegion.ScrollBoundsProperty.SetDefault(_xmlEditorScrollableArea, Delight.ScrollBounds.Clamped);
                    Delight.ScrollableRegion.ContentRegionTemplateProperty.SetDefault(_xmlEditorScrollableArea, XmlEditorScrollableAreaContentRegion);
                    Delight.ScrollableRegion.HorizontalScrollbarTemplateProperty.SetDefault(_xmlEditorScrollableArea, XmlEditorScrollableAreaHorizontalScrollbar);
                    Delight.ScrollableRegion.VerticalScrollbarTemplateProperty.SetDefault(_xmlEditorScrollableArea, XmlEditorScrollableAreaVerticalScrollbar);
                }
                return _xmlEditorScrollableArea;
            }
        }

        private static Template _xmlEditorScrollableAreaContentRegion;
        public static Template XmlEditorScrollableAreaContentRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_xmlEditorScrollableAreaContentRegion == null || _xmlEditorScrollableAreaContentRegion.CurrentVersion != Template.Version)
#else
                if (_xmlEditorScrollableAreaContentRegion == null)
#endif
                {
                    _xmlEditorScrollableAreaContentRegion = new Template(ScrollableRegionTemplates.ScrollableRegionContentRegion);
#if UNITY_EDITOR
                    _xmlEditorScrollableAreaContentRegion.Name = "XmlEditorScrollableAreaContentRegion";
#endif
                }
                return _xmlEditorScrollableAreaContentRegion;
            }
        }

        private static Template _xmlEditorScrollableAreaHorizontalScrollbar;
        public static Template XmlEditorScrollableAreaHorizontalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_xmlEditorScrollableAreaHorizontalScrollbar == null || _xmlEditorScrollableAreaHorizontalScrollbar.CurrentVersion != Template.Version)
#else
                if (_xmlEditorScrollableAreaHorizontalScrollbar == null)
#endif
                {
                    _xmlEditorScrollableAreaHorizontalScrollbar = new Template(ScrollableRegionTemplates.ScrollableRegionHorizontalScrollbar);
#if UNITY_EDITOR
                    _xmlEditorScrollableAreaHorizontalScrollbar.Name = "XmlEditorScrollableAreaHorizontalScrollbar";
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_xmlEditorScrollableAreaHorizontalScrollbar, XmlEditorScrollableAreaHorizontalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_xmlEditorScrollableAreaHorizontalScrollbar, XmlEditorScrollableAreaHorizontalScrollbarHandle);
                }
                return _xmlEditorScrollableAreaHorizontalScrollbar;
            }
        }

        private static Template _xmlEditorScrollableAreaHorizontalScrollbarBar;
        public static Template XmlEditorScrollableAreaHorizontalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_xmlEditorScrollableAreaHorizontalScrollbarBar == null || _xmlEditorScrollableAreaHorizontalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_xmlEditorScrollableAreaHorizontalScrollbarBar == null)
#endif
                {
                    _xmlEditorScrollableAreaHorizontalScrollbarBar = new Template(ScrollableRegionTemplates.ScrollableRegionHorizontalScrollbarBar);
#if UNITY_EDITOR
                    _xmlEditorScrollableAreaHorizontalScrollbarBar.Name = "XmlEditorScrollableAreaHorizontalScrollbarBar";
#endif
                }
                return _xmlEditorScrollableAreaHorizontalScrollbarBar;
            }
        }

        private static Template _xmlEditorScrollableAreaHorizontalScrollbarHandle;
        public static Template XmlEditorScrollableAreaHorizontalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_xmlEditorScrollableAreaHorizontalScrollbarHandle == null || _xmlEditorScrollableAreaHorizontalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_xmlEditorScrollableAreaHorizontalScrollbarHandle == null)
#endif
                {
                    _xmlEditorScrollableAreaHorizontalScrollbarHandle = new Template(ScrollableRegionTemplates.ScrollableRegionHorizontalScrollbarHandle);
#if UNITY_EDITOR
                    _xmlEditorScrollableAreaHorizontalScrollbarHandle.Name = "XmlEditorScrollableAreaHorizontalScrollbarHandle";
#endif
                }
                return _xmlEditorScrollableAreaHorizontalScrollbarHandle;
            }
        }

        private static Template _xmlEditorScrollableAreaVerticalScrollbar;
        public static Template XmlEditorScrollableAreaVerticalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_xmlEditorScrollableAreaVerticalScrollbar == null || _xmlEditorScrollableAreaVerticalScrollbar.CurrentVersion != Template.Version)
#else
                if (_xmlEditorScrollableAreaVerticalScrollbar == null)
#endif
                {
                    _xmlEditorScrollableAreaVerticalScrollbar = new Template(ScrollableRegionTemplates.ScrollableRegionVerticalScrollbar);
#if UNITY_EDITOR
                    _xmlEditorScrollableAreaVerticalScrollbar.Name = "XmlEditorScrollableAreaVerticalScrollbar";
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_xmlEditorScrollableAreaVerticalScrollbar, XmlEditorScrollableAreaVerticalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_xmlEditorScrollableAreaVerticalScrollbar, XmlEditorScrollableAreaVerticalScrollbarHandle);
                }
                return _xmlEditorScrollableAreaVerticalScrollbar;
            }
        }

        private static Template _xmlEditorScrollableAreaVerticalScrollbarBar;
        public static Template XmlEditorScrollableAreaVerticalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_xmlEditorScrollableAreaVerticalScrollbarBar == null || _xmlEditorScrollableAreaVerticalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_xmlEditorScrollableAreaVerticalScrollbarBar == null)
#endif
                {
                    _xmlEditorScrollableAreaVerticalScrollbarBar = new Template(ScrollableRegionTemplates.ScrollableRegionVerticalScrollbarBar);
#if UNITY_EDITOR
                    _xmlEditorScrollableAreaVerticalScrollbarBar.Name = "XmlEditorScrollableAreaVerticalScrollbarBar";
#endif
                }
                return _xmlEditorScrollableAreaVerticalScrollbarBar;
            }
        }

        private static Template _xmlEditorScrollableAreaVerticalScrollbarHandle;
        public static Template XmlEditorScrollableAreaVerticalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_xmlEditorScrollableAreaVerticalScrollbarHandle == null || _xmlEditorScrollableAreaVerticalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_xmlEditorScrollableAreaVerticalScrollbarHandle == null)
#endif
                {
                    _xmlEditorScrollableAreaVerticalScrollbarHandle = new Template(ScrollableRegionTemplates.ScrollableRegionVerticalScrollbarHandle);
#if UNITY_EDITOR
                    _xmlEditorScrollableAreaVerticalScrollbarHandle.Name = "XmlEditorScrollableAreaVerticalScrollbarHandle";
#endif
                }
                return _xmlEditorScrollableAreaVerticalScrollbarHandle;
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
                    Delight.Region.BackgroundColorProperty.SetDefault(_xmlEditorXmlEditRegion, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Region.AlignmentProperty.SetDefault(_xmlEditorXmlEditRegion, Delight.ElementAlignment.TopLeft);
                }
                return _xmlEditorXmlEditRegion;
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
                    Delight.Label.FontColorProperty.SetDefault(_xmlEditorLineNumbersLabel, new UnityEngine.Color(0.2f, 0.2f, 0.2f, 1f));
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
                    Delight.Label.TextProperty.SetDefault(_xmlEditorCaret, "_");
                    Delight.Label.WidthProperty.SetDefault(_xmlEditorCaret, new ElementSize(20f, ElementSizeUnit.Pixels));
                    Delight.Label.HeightProperty.SetDefault(_xmlEditorCaret, new ElementSize(20f, ElementSizeUnit.Pixels));
                    Delight.Label.FontProperty.SetDefault(_xmlEditorCaret, Assets.TMP_FontAssets["Inconsolata-Regular SDF"]);
                    Delight.Label.FontSizeProperty.SetDefault(_xmlEditorCaret, 20f);
                    Delight.Label.FontColorProperty.SetDefault(_xmlEditorCaret, new UnityEngine.Color(1f, 0f, 0f, 1f));
                    Delight.Label.TextAlignmentProperty.SetDefault(_xmlEditorCaret, TMPro.TextAlignmentOptions.TopLeft);
                    Delight.Label.RichTextProperty.SetDefault(_xmlEditorCaret, false);
                    Delight.Label.OverflowModeProperty.SetDefault(_xmlEditorCaret, TMPro.TextOverflowModes.Overflow);
                    Delight.Label.EnableWordWrappingProperty.SetDefault(_xmlEditorCaret, false);
                    Delight.Label.AlignmentProperty.SetDefault(_xmlEditorCaret, Delight.ElementAlignment.TopLeft);
                }
                return _xmlEditorCaret;
            }
        }

        private static Template _xmlEditorCaretElement;
        public static Template XmlEditorCaretElement
        {
            get
            {
#if UNITY_EDITOR
                if (_xmlEditorCaretElement == null || _xmlEditorCaretElement.CurrentVersion != Template.Version)
#else
                if (_xmlEditorCaretElement == null)
#endif
                {
                    _xmlEditorCaretElement = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _xmlEditorCaretElement.Name = "XmlEditorCaretElement";
#endif
                    Delight.Label.WidthProperty.SetDefault(_xmlEditorCaretElement, new ElementSize(300f, ElementSizeUnit.Pixels));
                    Delight.Label.HeightProperty.SetDefault(_xmlEditorCaretElement, new ElementSize(22f, ElementSizeUnit.Pixels));
                    Delight.Label.AlignmentProperty.SetDefault(_xmlEditorCaretElement, Delight.ElementAlignment.TopRight);
                    Delight.Label.RichTextProperty.SetDefault(_xmlEditorCaretElement, false);
                    Delight.Label.OverflowModeProperty.SetDefault(_xmlEditorCaretElement, TMPro.TextOverflowModes.Overflow);
                    Delight.Label.FontProperty.SetDefault(_xmlEditorCaretElement, Assets.TMP_FontAssets["Inconsolata-Regular SDF"]);
                    Delight.Label.FontSizeProperty.SetDefault(_xmlEditorCaretElement, 20f);
                    Delight.Label.TextAlignmentProperty.SetDefault(_xmlEditorCaretElement, TMPro.TextAlignmentOptions.TopRight);
                }
                return _xmlEditorCaretElement;
            }
        }

        #endregion
    }

    #endregion
}

#endif
