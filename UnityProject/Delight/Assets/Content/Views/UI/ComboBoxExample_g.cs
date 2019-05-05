// Internal view logic generated from "ComboBoxExample.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class ComboBoxExample : LayoutRoot
    {
        #region Constructors

        public ComboBoxExample(View parent, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :
            base(parent, layoutParent, id, template ?? ComboBoxExampleTemplates.Default, initializer)
        {
            // constructing Group (Group1)
            Group1 = new Group(this, this, "Group1", Group1Template);
            Group2 = new Group(this, Group1.Content, "Group2", Group2Template);
            Button1 = new Button(this, Group2.Content, "Button1", Button1Template);
            Button1.Click += ResolveActionHandler(this, "Add");
            Button2 = new Button(this, Group2.Content, "Button2", Button2Template);
            Button2.Click += ResolveActionHandler(this, "Remove");
            ComboBox = new ComboBox(this, Group1.Content, "ComboBox", ComboBoxTemplate);
            ComboBox.ItemSelected += ResolveActionHandler(this, "ItemSelected");

            // binding <ComboBox Items="{player in @Players}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> {  }, new List<Func<BindableObject>> {  }) }, new BindingPath(new List<string> { "ComboBox", "Items" }, new List<Func<BindableObject>> { () => this, () => ComboBox }), () => ComboBox.Items = Models.Players, () => { }, false));

            // Template for ComboBox
            ComboBox.ContentTemplate = new ContentTemplate(tiPlayer => 
            {
                var comboBoxContent = new ComboBoxListItem(this, ComboBox.Content, "ComboBoxContent", ComboBoxContentTemplate);
                var label1 = new Label(this, comboBoxContent.Content, "Label1", Label1Template);

                // binding <Label Text="{player.Name}">
                comboBoxContent.Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "Item", "Name" }, new List<Func<BindableObject>> { () => tiPlayer, () => tiPlayer.Item }) }, new BindingPath(new List<string> { "Text" }, new List<Func<BindableObject>> { () => label1 }), () => label1.Text = (tiPlayer.Item as Delight.Player).Name, () => { }, false));
                return comboBoxContent;
            });
            this.AfterInitializeInternal();
        }

        public ComboBoxExample() : this(null)
        {
        }

        static ComboBoxExample()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(ComboBoxExampleTemplates.Default, dependencyProperties);

            dependencyProperties.Add(Group1Property);
            dependencyProperties.Add(Group1TemplateProperty);
            dependencyProperties.Add(Group2Property);
            dependencyProperties.Add(Group2TemplateProperty);
            dependencyProperties.Add(Button1Property);
            dependencyProperties.Add(Button1TemplateProperty);
            dependencyProperties.Add(Button2Property);
            dependencyProperties.Add(Button2TemplateProperty);
            dependencyProperties.Add(ComboBoxProperty);
            dependencyProperties.Add(ComboBoxTemplateProperty);
            dependencyProperties.Add(Label1Property);
            dependencyProperties.Add(Label1TemplateProperty);
            dependencyProperties.Add(ComboBoxContentProperty);
            dependencyProperties.Add(ComboBoxContentTemplateProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<Group> Group1Property = new DependencyProperty<Group>("Group1");
        public Group Group1
        {
            get { return Group1Property.GetValue(this); }
            set { Group1Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Group1TemplateProperty = new DependencyProperty<Template>("Group1Template");
        public Template Group1Template
        {
            get { return Group1TemplateProperty.GetValue(this); }
            set { Group1TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Group> Group2Property = new DependencyProperty<Group>("Group2");
        public Group Group2
        {
            get { return Group2Property.GetValue(this); }
            set { Group2Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Group2TemplateProperty = new DependencyProperty<Template>("Group2Template");
        public Template Group2Template
        {
            get { return Group2TemplateProperty.GetValue(this); }
            set { Group2TemplateProperty.SetValue(this, value); }
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

        public readonly static DependencyProperty<Button> Button2Property = new DependencyProperty<Button>("Button2");
        public Button Button2
        {
            get { return Button2Property.GetValue(this); }
            set { Button2Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Button2TemplateProperty = new DependencyProperty<Template>("Button2Template");
        public Template Button2Template
        {
            get { return Button2TemplateProperty.GetValue(this); }
            set { Button2TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ComboBox> ComboBoxProperty = new DependencyProperty<ComboBox>("ComboBox");
        public ComboBox ComboBox
        {
            get { return ComboBoxProperty.GetValue(this); }
            set { ComboBoxProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> ComboBoxTemplateProperty = new DependencyProperty<Template>("ComboBoxTemplate");
        public Template ComboBoxTemplate
        {
            get { return ComboBoxTemplateProperty.GetValue(this); }
            set { ComboBoxTemplateProperty.SetValue(this, value); }
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

        public readonly static DependencyProperty<ComboBoxListItem> ComboBoxContentProperty = new DependencyProperty<ComboBoxListItem>("ComboBoxContent");
        public ComboBoxListItem ComboBoxContent
        {
            get { return ComboBoxContentProperty.GetValue(this); }
            set { ComboBoxContentProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> ComboBoxContentTemplateProperty = new DependencyProperty<Template>("ComboBoxContentTemplate");
        public Template ComboBoxContentTemplate
        {
            get { return ComboBoxContentTemplateProperty.GetValue(this); }
            set { ComboBoxContentTemplateProperty.SetValue(this, value); }
        }

        #endregion
    }

    #region Data Templates

    public static class ComboBoxExampleTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return ComboBoxExample;
            }
        }

        private static Template _comboBoxExample;
        public static Template ComboBoxExample
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxExample == null || _comboBoxExample.CurrentVersion != Template.Version)
#else
                if (_comboBoxExample == null)
#endif
                {
                    _comboBoxExample = new Template(LayoutRootTemplates.LayoutRoot);
#if UNITY_EDITOR
                    _comboBoxExample.Name = "ComboBoxExample";
#endif
                    Delight.ComboBoxExample.Group1TemplateProperty.SetDefault(_comboBoxExample, ComboBoxExampleGroup1);
                    Delight.ComboBoxExample.Group2TemplateProperty.SetDefault(_comboBoxExample, ComboBoxExampleGroup2);
                    Delight.ComboBoxExample.Button1TemplateProperty.SetDefault(_comboBoxExample, ComboBoxExampleButton1);
                    Delight.ComboBoxExample.Button2TemplateProperty.SetDefault(_comboBoxExample, ComboBoxExampleButton2);
                    Delight.ComboBoxExample.ComboBoxTemplateProperty.SetDefault(_comboBoxExample, ComboBoxExampleComboBox);
                    Delight.ComboBoxExample.ComboBoxContentTemplateProperty.SetDefault(_comboBoxExample, ComboBoxExampleComboBoxContent);
                    Delight.ComboBoxExample.Label1TemplateProperty.SetDefault(_comboBoxExample, ComboBoxExampleLabel1);
                }
                return _comboBoxExample;
            }
        }

        private static Template _comboBoxExampleGroup1;
        public static Template ComboBoxExampleGroup1
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxExampleGroup1 == null || _comboBoxExampleGroup1.CurrentVersion != Template.Version)
#else
                if (_comboBoxExampleGroup1 == null)
#endif
                {
                    _comboBoxExampleGroup1 = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _comboBoxExampleGroup1.Name = "ComboBoxExampleGroup1";
#endif
                    Delight.Group.OrientationProperty.SetDefault(_comboBoxExampleGroup1, Delight.ElementOrientation.Vertical);
                    Delight.Group.SpacingProperty.SetDefault(_comboBoxExampleGroup1, new ElementSize(15f, ElementSizeUnit.Pixels));
                    Delight.Group.ContentAlignmentProperty.SetDefault(_comboBoxExampleGroup1, Delight.ElementAlignment.Left);
                }
                return _comboBoxExampleGroup1;
            }
        }

        private static Template _comboBoxExampleGroup2;
        public static Template ComboBoxExampleGroup2
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxExampleGroup2 == null || _comboBoxExampleGroup2.CurrentVersion != Template.Version)
#else
                if (_comboBoxExampleGroup2 == null)
#endif
                {
                    _comboBoxExampleGroup2 = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _comboBoxExampleGroup2.Name = "ComboBoxExampleGroup2";
#endif
                    Delight.Group.OrientationProperty.SetDefault(_comboBoxExampleGroup2, Delight.ElementOrientation.Horizontal);
                    Delight.Group.SpacingProperty.SetDefault(_comboBoxExampleGroup2, new ElementSize(15f, ElementSizeUnit.Pixels));
                }
                return _comboBoxExampleGroup2;
            }
        }

        private static Template _comboBoxExampleButton1;
        public static Template ComboBoxExampleButton1
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxExampleButton1 == null || _comboBoxExampleButton1.CurrentVersion != Template.Version)
#else
                if (_comboBoxExampleButton1 == null)
#endif
                {
                    _comboBoxExampleButton1 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _comboBoxExampleButton1.Name = "ComboBoxExampleButton1";
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_comboBoxExampleButton1, ComboBoxExampleButton1Label);
                }
                return _comboBoxExampleButton1;
            }
        }

        private static Template _comboBoxExampleButton1Label;
        public static Template ComboBoxExampleButton1Label
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxExampleButton1Label == null || _comboBoxExampleButton1Label.CurrentVersion != Template.Version)
#else
                if (_comboBoxExampleButton1Label == null)
#endif
                {
                    _comboBoxExampleButton1Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _comboBoxExampleButton1Label.Name = "ComboBoxExampleButton1Label";
#endif
                    Delight.Label.TextProperty.SetDefault(_comboBoxExampleButton1Label, "Add");
                }
                return _comboBoxExampleButton1Label;
            }
        }

        private static Template _comboBoxExampleButton2;
        public static Template ComboBoxExampleButton2
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxExampleButton2 == null || _comboBoxExampleButton2.CurrentVersion != Template.Version)
#else
                if (_comboBoxExampleButton2 == null)
#endif
                {
                    _comboBoxExampleButton2 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _comboBoxExampleButton2.Name = "ComboBoxExampleButton2";
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_comboBoxExampleButton2, ComboBoxExampleButton2Label);
                }
                return _comboBoxExampleButton2;
            }
        }

        private static Template _comboBoxExampleButton2Label;
        public static Template ComboBoxExampleButton2Label
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxExampleButton2Label == null || _comboBoxExampleButton2Label.CurrentVersion != Template.Version)
#else
                if (_comboBoxExampleButton2Label == null)
#endif
                {
                    _comboBoxExampleButton2Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _comboBoxExampleButton2Label.Name = "ComboBoxExampleButton2Label";
#endif
                    Delight.Label.TextProperty.SetDefault(_comboBoxExampleButton2Label, "Remove");
                }
                return _comboBoxExampleButton2Label;
            }
        }

        private static Template _comboBoxExampleComboBox;
        public static Template ComboBoxExampleComboBox
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxExampleComboBox == null || _comboBoxExampleComboBox.CurrentVersion != Template.Version)
#else
                if (_comboBoxExampleComboBox == null)
#endif
                {
                    _comboBoxExampleComboBox = new Template(ComboBoxTemplates.ComboBox);
#if UNITY_EDITOR
                    _comboBoxExampleComboBox.Name = "ComboBoxExampleComboBox";
#endif
                    Delight.ComboBox.IsDropUpProperty.SetDefault(_comboBoxExampleComboBox, false);
                    Delight.ComboBox.ComboBoxButtonTemplateProperty.SetDefault(_comboBoxExampleComboBox, ComboBoxExampleComboBoxComboBoxButton);
                    Delight.ComboBox.ComboBoxListCanvasTemplateProperty.SetDefault(_comboBoxExampleComboBox, ComboBoxExampleComboBoxComboBoxListCanvas);
                    Delight.ComboBox.ComboBoxListTemplateProperty.SetDefault(_comboBoxExampleComboBox, ComboBoxExampleComboBoxComboBoxList);
                }
                return _comboBoxExampleComboBox;
            }
        }

        private static Template _comboBoxExampleComboBoxComboBoxButton;
        public static Template ComboBoxExampleComboBoxComboBoxButton
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxExampleComboBoxComboBoxButton == null || _comboBoxExampleComboBoxComboBoxButton.CurrentVersion != Template.Version)
#else
                if (_comboBoxExampleComboBoxComboBoxButton == null)
#endif
                {
                    _comboBoxExampleComboBoxComboBoxButton = new Template(ComboBoxTemplates.ComboBoxComboBoxButton);
#if UNITY_EDITOR
                    _comboBoxExampleComboBoxComboBoxButton.Name = "ComboBoxExampleComboBoxComboBoxButton";
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_comboBoxExampleComboBoxComboBoxButton, ComboBoxExampleComboBoxComboBoxButtonLabel);
                }
                return _comboBoxExampleComboBoxComboBoxButton;
            }
        }

        private static Template _comboBoxExampleComboBoxComboBoxButtonLabel;
        public static Template ComboBoxExampleComboBoxComboBoxButtonLabel
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxExampleComboBoxComboBoxButtonLabel == null || _comboBoxExampleComboBoxComboBoxButtonLabel.CurrentVersion != Template.Version)
#else
                if (_comboBoxExampleComboBoxComboBoxButtonLabel == null)
#endif
                {
                    _comboBoxExampleComboBoxComboBoxButtonLabel = new Template(ComboBoxTemplates.ComboBoxComboBoxButtonLabel);
#if UNITY_EDITOR
                    _comboBoxExampleComboBoxComboBoxButtonLabel.Name = "ComboBoxExampleComboBoxComboBoxButtonLabel";
#endif
                }
                return _comboBoxExampleComboBoxComboBoxButtonLabel;
            }
        }

        private static Template _comboBoxExampleComboBoxComboBoxListCanvas;
        public static Template ComboBoxExampleComboBoxComboBoxListCanvas
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxExampleComboBoxComboBoxListCanvas == null || _comboBoxExampleComboBoxComboBoxListCanvas.CurrentVersion != Template.Version)
#else
                if (_comboBoxExampleComboBoxComboBoxListCanvas == null)
#endif
                {
                    _comboBoxExampleComboBoxComboBoxListCanvas = new Template(ComboBoxTemplates.ComboBoxComboBoxListCanvas);
#if UNITY_EDITOR
                    _comboBoxExampleComboBoxComboBoxListCanvas.Name = "ComboBoxExampleComboBoxComboBoxListCanvas";
#endif
                }
                return _comboBoxExampleComboBoxComboBoxListCanvas;
            }
        }

        private static Template _comboBoxExampleComboBoxComboBoxList;
        public static Template ComboBoxExampleComboBoxComboBoxList
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxExampleComboBoxComboBoxList == null || _comboBoxExampleComboBoxComboBoxList.CurrentVersion != Template.Version)
#else
                if (_comboBoxExampleComboBoxComboBoxList == null)
#endif
                {
                    _comboBoxExampleComboBoxComboBoxList = new Template(ComboBoxTemplates.ComboBoxComboBoxList);
#if UNITY_EDITOR
                    _comboBoxExampleComboBoxComboBoxList.Name = "ComboBoxExampleComboBoxComboBoxList";
#endif
                    Delight.List.ScrollableRegionTemplateProperty.SetDefault(_comboBoxExampleComboBoxComboBoxList, ComboBoxExampleComboBoxComboBoxListScrollableRegion);
                }
                return _comboBoxExampleComboBoxComboBoxList;
            }
        }

        private static Template _comboBoxExampleComboBoxComboBoxListScrollableRegion;
        public static Template ComboBoxExampleComboBoxComboBoxListScrollableRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxExampleComboBoxComboBoxListScrollableRegion == null || _comboBoxExampleComboBoxComboBoxListScrollableRegion.CurrentVersion != Template.Version)
#else
                if (_comboBoxExampleComboBoxComboBoxListScrollableRegion == null)
#endif
                {
                    _comboBoxExampleComboBoxComboBoxListScrollableRegion = new Template(ComboBoxTemplates.ComboBoxComboBoxListScrollableRegion);
#if UNITY_EDITOR
                    _comboBoxExampleComboBoxComboBoxListScrollableRegion.Name = "ComboBoxExampleComboBoxComboBoxListScrollableRegion";
#endif
                    Delight.ScrollableRegion.ContentRegionTemplateProperty.SetDefault(_comboBoxExampleComboBoxComboBoxListScrollableRegion, ComboBoxExampleComboBoxComboBoxListScrollableRegionContentRegion);
                    Delight.ScrollableRegion.HorizontalScrollbarTemplateProperty.SetDefault(_comboBoxExampleComboBoxComboBoxListScrollableRegion, ComboBoxExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbar);
                    Delight.ScrollableRegion.VerticalScrollbarTemplateProperty.SetDefault(_comboBoxExampleComboBoxComboBoxListScrollableRegion, ComboBoxExampleComboBoxComboBoxListScrollableRegionVerticalScrollbar);
                }
                return _comboBoxExampleComboBoxComboBoxListScrollableRegion;
            }
        }

        private static Template _comboBoxExampleComboBoxComboBoxListScrollableRegionContentRegion;
        public static Template ComboBoxExampleComboBoxComboBoxListScrollableRegionContentRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxExampleComboBoxComboBoxListScrollableRegionContentRegion == null || _comboBoxExampleComboBoxComboBoxListScrollableRegionContentRegion.CurrentVersion != Template.Version)
#else
                if (_comboBoxExampleComboBoxComboBoxListScrollableRegionContentRegion == null)
#endif
                {
                    _comboBoxExampleComboBoxComboBoxListScrollableRegionContentRegion = new Template(ComboBoxTemplates.ComboBoxComboBoxListScrollableRegionContentRegion);
#if UNITY_EDITOR
                    _comboBoxExampleComboBoxComboBoxListScrollableRegionContentRegion.Name = "ComboBoxExampleComboBoxComboBoxListScrollableRegionContentRegion";
#endif
                }
                return _comboBoxExampleComboBoxComboBoxListScrollableRegionContentRegion;
            }
        }

        private static Template _comboBoxExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbar;
        public static Template ComboBoxExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbar == null || _comboBoxExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbar.CurrentVersion != Template.Version)
#else
                if (_comboBoxExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbar == null)
#endif
                {
                    _comboBoxExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbar = new Template(ComboBoxTemplates.ComboBoxComboBoxListScrollableRegionHorizontalScrollbar);
#if UNITY_EDITOR
                    _comboBoxExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbar.Name = "ComboBoxExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbar";
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_comboBoxExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbar, ComboBoxExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_comboBoxExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbar, ComboBoxExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbarHandle);
                }
                return _comboBoxExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbar;
            }
        }

        private static Template _comboBoxExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbarBar;
        public static Template ComboBoxExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbarBar == null || _comboBoxExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_comboBoxExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbarBar == null)
#endif
                {
                    _comboBoxExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbarBar = new Template(ComboBoxTemplates.ComboBoxComboBoxListScrollableRegionHorizontalScrollbarBar);
#if UNITY_EDITOR
                    _comboBoxExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbarBar.Name = "ComboBoxExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbarBar";
#endif
                }
                return _comboBoxExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbarBar;
            }
        }

        private static Template _comboBoxExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbarHandle;
        public static Template ComboBoxExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbarHandle == null || _comboBoxExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_comboBoxExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbarHandle == null)
#endif
                {
                    _comboBoxExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbarHandle = new Template(ComboBoxTemplates.ComboBoxComboBoxListScrollableRegionHorizontalScrollbarHandle);
#if UNITY_EDITOR
                    _comboBoxExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbarHandle.Name = "ComboBoxExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbarHandle";
#endif
                }
                return _comboBoxExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbarHandle;
            }
        }

        private static Template _comboBoxExampleComboBoxComboBoxListScrollableRegionVerticalScrollbar;
        public static Template ComboBoxExampleComboBoxComboBoxListScrollableRegionVerticalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxExampleComboBoxComboBoxListScrollableRegionVerticalScrollbar == null || _comboBoxExampleComboBoxComboBoxListScrollableRegionVerticalScrollbar.CurrentVersion != Template.Version)
#else
                if (_comboBoxExampleComboBoxComboBoxListScrollableRegionVerticalScrollbar == null)
#endif
                {
                    _comboBoxExampleComboBoxComboBoxListScrollableRegionVerticalScrollbar = new Template(ComboBoxTemplates.ComboBoxComboBoxListScrollableRegionVerticalScrollbar);
#if UNITY_EDITOR
                    _comboBoxExampleComboBoxComboBoxListScrollableRegionVerticalScrollbar.Name = "ComboBoxExampleComboBoxComboBoxListScrollableRegionVerticalScrollbar";
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_comboBoxExampleComboBoxComboBoxListScrollableRegionVerticalScrollbar, ComboBoxExampleComboBoxComboBoxListScrollableRegionVerticalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_comboBoxExampleComboBoxComboBoxListScrollableRegionVerticalScrollbar, ComboBoxExampleComboBoxComboBoxListScrollableRegionVerticalScrollbarHandle);
                }
                return _comboBoxExampleComboBoxComboBoxListScrollableRegionVerticalScrollbar;
            }
        }

        private static Template _comboBoxExampleComboBoxComboBoxListScrollableRegionVerticalScrollbarBar;
        public static Template ComboBoxExampleComboBoxComboBoxListScrollableRegionVerticalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxExampleComboBoxComboBoxListScrollableRegionVerticalScrollbarBar == null || _comboBoxExampleComboBoxComboBoxListScrollableRegionVerticalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_comboBoxExampleComboBoxComboBoxListScrollableRegionVerticalScrollbarBar == null)
#endif
                {
                    _comboBoxExampleComboBoxComboBoxListScrollableRegionVerticalScrollbarBar = new Template(ComboBoxTemplates.ComboBoxComboBoxListScrollableRegionVerticalScrollbarBar);
#if UNITY_EDITOR
                    _comboBoxExampleComboBoxComboBoxListScrollableRegionVerticalScrollbarBar.Name = "ComboBoxExampleComboBoxComboBoxListScrollableRegionVerticalScrollbarBar";
#endif
                }
                return _comboBoxExampleComboBoxComboBoxListScrollableRegionVerticalScrollbarBar;
            }
        }

        private static Template _comboBoxExampleComboBoxComboBoxListScrollableRegionVerticalScrollbarHandle;
        public static Template ComboBoxExampleComboBoxComboBoxListScrollableRegionVerticalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxExampleComboBoxComboBoxListScrollableRegionVerticalScrollbarHandle == null || _comboBoxExampleComboBoxComboBoxListScrollableRegionVerticalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_comboBoxExampleComboBoxComboBoxListScrollableRegionVerticalScrollbarHandle == null)
#endif
                {
                    _comboBoxExampleComboBoxComboBoxListScrollableRegionVerticalScrollbarHandle = new Template(ComboBoxTemplates.ComboBoxComboBoxListScrollableRegionVerticalScrollbarHandle);
#if UNITY_EDITOR
                    _comboBoxExampleComboBoxComboBoxListScrollableRegionVerticalScrollbarHandle.Name = "ComboBoxExampleComboBoxComboBoxListScrollableRegionVerticalScrollbarHandle";
#endif
                }
                return _comboBoxExampleComboBoxComboBoxListScrollableRegionVerticalScrollbarHandle;
            }
        }

        private static Template _comboBoxExampleComboBoxContent;
        public static Template ComboBoxExampleComboBoxContent
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxExampleComboBoxContent == null || _comboBoxExampleComboBoxContent.CurrentVersion != Template.Version)
#else
                if (_comboBoxExampleComboBoxContent == null)
#endif
                {
                    _comboBoxExampleComboBoxContent = new Template(ComboBoxListItemTemplates.ComboBoxListItem);
#if UNITY_EDITOR
                    _comboBoxExampleComboBoxContent.Name = "ComboBoxExampleComboBoxContent";
#endif
                }
                return _comboBoxExampleComboBoxContent;
            }
        }

        private static Template _comboBoxExampleLabel1;
        public static Template ComboBoxExampleLabel1
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxExampleLabel1 == null || _comboBoxExampleLabel1.CurrentVersion != Template.Version)
#else
                if (_comboBoxExampleLabel1 == null)
#endif
                {
                    _comboBoxExampleLabel1 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _comboBoxExampleLabel1.Name = "ComboBoxExampleLabel1";
#endif
                    Delight.Label.WidthProperty.SetDefault(_comboBoxExampleLabel1, new ElementSize(1f, ElementSizeUnit.Percents));
                    Delight.Label.MarginProperty.SetDefault(_comboBoxExampleLabel1, new ElementMargin(new ElementSize(10f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels)));
                }
                return _comboBoxExampleLabel1;
            }
        }

        #endregion
    }

    #endregion
}
