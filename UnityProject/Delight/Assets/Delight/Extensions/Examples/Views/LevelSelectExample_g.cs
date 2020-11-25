// Internal view logic generated from "LevelSelectExample.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class LevelSelectExample : UIView
    {
        #region Constructors

        public LevelSelectExample(View parent, View layoutParent = null, string id = null, Template template = null, bool deferInitialization = false) :
            base(parent, layoutParent, id, template ?? LevelSelectExampleTemplates.Default, deferInitialization)
        {
            if (deferInitialization)
                return;

            // constructing Image (Image1)
            Image1 = new Image(this, this, "Image1", Image1Template);

            // constructing Label (Label1)
            Label1 = new Label(this, this, "Label1", Label1Template);

            // constructing List (List1)
            List1 = new List(this, this, "List1", List1Template);

            // binding <List Items="{level in @DemoLevels}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> {  }, new List<Func<object>> {  }) }, new BindingPath(new List<string> { "List1", "Items" }, new List<Func<object>> { () => this, () => List1 }), () => List1.Items = Models.DemoLevels, () => { }, false));

            // templates for List1
            List1.ContentTemplates.Add(new ContentTemplate(tiLevel => 
            {
                var listItem1 = new ListItem(this, List1.Content, "ListItem1", ListItem1Template);
                var label2 = new Label(this, listItem1.Content, "Label2", Label2Template);

                // binding <Label Text="{level.Index:0}">
                listItem1.Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "Index" }, new List<Func<object>> { () => tiLevel }) }, new BindingPath(new List<string> { "Text" }, new List<Func<object>> { () => label2 }), () => label2.Text = String.Format("{0:0}", tiLevel.Index), () => { }, false));
                var image2 = new Image(this, listItem1.Content, "Image2", Image2Template);

                // binding <Image Sprite="{level.Stars}">
                listItem1.Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "Item", "Stars" }, new List<Func<object>> { () => tiLevel, () => (tiLevel.Item as Delight.DemoLevel) }) }, new BindingPath(new List<string> { "Sprite" }, new List<Func<object>> { () => image2 }), () => image2.Sprite = (tiLevel.Item as Delight.DemoLevel).Stars, () => { }, false));
                listItem1.IsDynamic = true;
                listItem1.SetContentTemplateData(tiLevel);
                return listItem1;
            }, typeof(ListItem), "ListItem1"));

            // templates for List1
            List1.ContentTemplates.Add(new ContentTemplate(tiLevel => 
            {
                var navigationButton1 = new NavigationButton(this, List1.Content, "NavigationButton1", NavigationButton1Template);
                navigationButton1.IsDynamic = true;
                navigationButton1.SetContentTemplateData(tiLevel);
                return navigationButton1;
            }, typeof(NavigationButton), "NavigationButton1"));

            // templates for List1
            List1.ContentTemplates.Add(new ContentTemplate(tiLevel => 
            {
                var navigationButton2 = new NavigationButton(this, List1.Content, "NavigationButton2", NavigationButton2Template);
                navigationButton2.IsDynamic = true;
                navigationButton2.SetContentTemplateData(tiLevel);
                return navigationButton2;
            }, typeof(NavigationButton), "NavigationButton2"));

            // constructing Button (Button1)
            Button1 = new Button(this, this, "Button1", Button1Template);
            Button1.Click.RegisterHandler(this, "BackButtonClick");
            this.AfterInitializeInternal();
        }

        public LevelSelectExample() : this(null)
        {
        }

        static LevelSelectExample()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(LevelSelectExampleTemplates.Default, dependencyProperties);

            dependencyProperties.Add(NavigateBackProperty);
            dependencyProperties.Add(Image1Property);
            dependencyProperties.Add(Image1TemplateProperty);
            dependencyProperties.Add(Label1Property);
            dependencyProperties.Add(Label1TemplateProperty);
            dependencyProperties.Add(List1Property);
            dependencyProperties.Add(List1TemplateProperty);
            dependencyProperties.Add(ListItem1Property);
            dependencyProperties.Add(ListItem1TemplateProperty);
            dependencyProperties.Add(Label2Property);
            dependencyProperties.Add(Label2TemplateProperty);
            dependencyProperties.Add(Image2Property);
            dependencyProperties.Add(Image2TemplateProperty);
            dependencyProperties.Add(NavigationButton1Property);
            dependencyProperties.Add(NavigationButton1TemplateProperty);
            dependencyProperties.Add(NavigationButton2Property);
            dependencyProperties.Add(NavigationButton2TemplateProperty);
            dependencyProperties.Add(Button1Property);
            dependencyProperties.Add(Button1TemplateProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<ViewAction> NavigateBackProperty = new DependencyProperty<ViewAction>("NavigateBack", () => new ViewAction());
        public ViewAction NavigateBack
        {
            get { return NavigateBackProperty.GetValue(this); }
            set { NavigateBackProperty.SetValue(this, value); }
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

        public readonly static DependencyProperty<NavigationButton> NavigationButton1Property = new DependencyProperty<NavigationButton>("NavigationButton1");
        public NavigationButton NavigationButton1
        {
            get { return NavigationButton1Property.GetValue(this); }
            set { NavigationButton1Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> NavigationButton1TemplateProperty = new DependencyProperty<Template>("NavigationButton1Template");
        public Template NavigationButton1Template
        {
            get { return NavigationButton1TemplateProperty.GetValue(this); }
            set { NavigationButton1TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<NavigationButton> NavigationButton2Property = new DependencyProperty<NavigationButton>("NavigationButton2");
        public NavigationButton NavigationButton2
        {
            get { return NavigationButton2Property.GetValue(this); }
            set { NavigationButton2Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> NavigationButton2TemplateProperty = new DependencyProperty<Template>("NavigationButton2Template");
        public Template NavigationButton2Template
        {
            get { return NavigationButton2TemplateProperty.GetValue(this); }
            set { NavigationButton2TemplateProperty.SetValue(this, value); }
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

        #endregion
    }

    #region Data Templates

    public static class LevelSelectExampleTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return LevelSelectExample;
            }
        }

        private static Template _levelSelectExample;
        public static Template LevelSelectExample
        {
            get
            {
#if UNITY_EDITOR
                if (_levelSelectExample == null || _levelSelectExample.CurrentVersion != Template.Version)
#else
                if (_levelSelectExample == null)
#endif
                {
                    _levelSelectExample = new Template(UIViewTemplates.UIView);
#if UNITY_EDITOR
                    _levelSelectExample.Name = "LevelSelectExample";
                    _levelSelectExample.LineNumber = 0;
                    _levelSelectExample.LinePosition = 0;
#endif
                    Delight.LevelSelectExample.WidthProperty.SetDefault(_levelSelectExample, new ElementSize(750f, ElementSizeUnit.Pixels));
                    Delight.LevelSelectExample.HeightProperty.SetDefault(_levelSelectExample, new ElementSize(600f, ElementSizeUnit.Pixels));
                    Delight.LevelSelectExample.Image1TemplateProperty.SetDefault(_levelSelectExample, LevelSelectExampleImage1);
                    Delight.LevelSelectExample.Label1TemplateProperty.SetDefault(_levelSelectExample, LevelSelectExampleLabel1);
                    Delight.LevelSelectExample.List1TemplateProperty.SetDefault(_levelSelectExample, LevelSelectExampleList1);
                    Delight.LevelSelectExample.ListItem1TemplateProperty.SetDefault(_levelSelectExample, LevelSelectExampleListItem1);
                    Delight.LevelSelectExample.Label2TemplateProperty.SetDefault(_levelSelectExample, LevelSelectExampleLabel2);
                    Delight.LevelSelectExample.Image2TemplateProperty.SetDefault(_levelSelectExample, LevelSelectExampleImage2);
                    Delight.LevelSelectExample.NavigationButton1TemplateProperty.SetDefault(_levelSelectExample, LevelSelectExampleNavigationButton1);
                    Delight.LevelSelectExample.NavigationButton2TemplateProperty.SetDefault(_levelSelectExample, LevelSelectExampleNavigationButton2);
                    Delight.LevelSelectExample.Button1TemplateProperty.SetDefault(_levelSelectExample, LevelSelectExampleButton1);
                }
                return _levelSelectExample;
            }
        }

        private static Template _levelSelectExampleImage1;
        public static Template LevelSelectExampleImage1
        {
            get
            {
#if UNITY_EDITOR
                if (_levelSelectExampleImage1 == null || _levelSelectExampleImage1.CurrentVersion != Template.Version)
#else
                if (_levelSelectExampleImage1 == null)
#endif
                {
                    _levelSelectExampleImage1 = new Template(ImageTemplates.Image);
#if UNITY_EDITOR
                    _levelSelectExampleImage1.Name = "LevelSelectExampleImage1";
                    _levelSelectExampleImage1.LineNumber = 3;
                    _levelSelectExampleImage1.LinePosition = 4;
#endif
                    Delight.Image.SpriteProperty.SetDefault(_levelSelectExampleImage1, Assets.Sprites["LevelSelectBg"]);
                    Delight.Image.PreserveAspectProperty.SetDefault(_levelSelectExampleImage1, true);
                    Delight.Image.WidthProperty.SetDefault(_levelSelectExampleImage1, new ElementSize(600f, ElementSizeUnit.Pixels));
                }
                return _levelSelectExampleImage1;
            }
        }

        private static Template _levelSelectExampleLabel1;
        public static Template LevelSelectExampleLabel1
        {
            get
            {
#if UNITY_EDITOR
                if (_levelSelectExampleLabel1 == null || _levelSelectExampleLabel1.CurrentVersion != Template.Version)
#else
                if (_levelSelectExampleLabel1 == null)
#endif
                {
                    _levelSelectExampleLabel1 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _levelSelectExampleLabel1.Name = "LevelSelectExampleLabel1";
                    _levelSelectExampleLabel1.LineNumber = 4;
                    _levelSelectExampleLabel1.LinePosition = 4;
#endif
                    Delight.Label.TextProperty.SetDefault(_levelSelectExampleLabel1, "Level Select");
                    Delight.Label.AutoSizeProperty.SetDefault(_levelSelectExampleLabel1, Delight.AutoSize.Default);
                    Delight.Label.FontSizeProperty.SetDefault(_levelSelectExampleLabel1, 50f);
                    Delight.Label.OffsetProperty.SetDefault(_levelSelectExampleLabel1, new ElementMargin(new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(225f, ElementSizeUnit.Pixels)));
                    Delight.Label.FontColorProperty.SetDefault(_levelSelectExampleLabel1, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Label.FontProperty.SetDefault(_levelSelectExampleLabel1, Assets.TMP_FontAssets["AveriaSansLibre-Bold SDF"]);
                }
                return _levelSelectExampleLabel1;
            }
        }

        private static Template _levelSelectExampleList1;
        public static Template LevelSelectExampleList1
        {
            get
            {
#if UNITY_EDITOR
                if (_levelSelectExampleList1 == null || _levelSelectExampleList1.CurrentVersion != Template.Version)
#else
                if (_levelSelectExampleList1 == null)
#endif
                {
                    _levelSelectExampleList1 = new Template(ListTemplates.List);
#if UNITY_EDITOR
                    _levelSelectExampleList1.Name = "LevelSelectExampleList1";
                    _levelSelectExampleList1.LineNumber = 5;
                    _levelSelectExampleList1.LinePosition = 4;
#endif
                    Delight.List.OverflowProperty.SetDefault(_levelSelectExampleList1, Delight.OverflowMode.Wrap);
                    Delight.List.OrientationProperty.SetDefault(_levelSelectExampleList1, Delight.ElementOrientation.Horizontal);
                    Delight.List.WidthProperty.SetDefault(_levelSelectExampleList1, new ElementSize(470f, ElementSizeUnit.Pixels));
                    Delight.List.HeightProperty.SetDefault(_levelSelectExampleList1, new ElementSize(310f, ElementSizeUnit.Pixels));
                    Delight.List.SpacingProperty.SetDefault(_levelSelectExampleList1, new ElementSize(10f, ElementSizeUnit.Pixels));
                    Delight.List.OffsetProperty.SetDefault(_levelSelectExampleList1, new ElementMargin(new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(170f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels)));
                    Delight.List.DeselectAfterSelectProperty.SetDefault(_levelSelectExampleList1, true);
                    Delight.List.AlignmentProperty.SetDefault(_levelSelectExampleList1, Delight.ElementAlignment.Top);
                    Delight.List.IsPagedProperty.SetDefault(_levelSelectExampleList1, true);
                    Delight.List.PageSizeProperty.SetDefault(_levelSelectExampleList1, 6);
                    Delight.List.ShowNavigationButtonsProperty.SetDefault(_levelSelectExampleList1, Delight.NavigationButtonsVisibility.All);
                    Delight.List.PageNavigationGroupOffsetProperty.SetDefault(_levelSelectExampleList1, new ElementMargin(new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(50f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels)));
                    Delight.List.PageNavigationGroupSpacingProperty.SetDefault(_levelSelectExampleList1, new ElementSize(5f, ElementSizeUnit.Pixels));
                    Delight.List.ItemsProperty.SetHasBinding(_levelSelectExampleList1);
                    Delight.List.ScrollableRegionTemplateProperty.SetDefault(_levelSelectExampleList1, LevelSelectExampleList1ScrollableRegion);
                }
                return _levelSelectExampleList1;
            }
        }

        private static Template _levelSelectExampleList1ScrollableRegion;
        public static Template LevelSelectExampleList1ScrollableRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_levelSelectExampleList1ScrollableRegion == null || _levelSelectExampleList1ScrollableRegion.CurrentVersion != Template.Version)
#else
                if (_levelSelectExampleList1ScrollableRegion == null)
#endif
                {
                    _levelSelectExampleList1ScrollableRegion = new Template(ListTemplates.ListScrollableRegion);
#if UNITY_EDITOR
                    _levelSelectExampleList1ScrollableRegion.Name = "LevelSelectExampleList1ScrollableRegion";
                    _levelSelectExampleList1ScrollableRegion.LineNumber = 29;
                    _levelSelectExampleList1ScrollableRegion.LinePosition = 4;
#endif
                    Delight.ScrollableRegion.ContentRegionTemplateProperty.SetDefault(_levelSelectExampleList1ScrollableRegion, LevelSelectExampleList1ScrollableRegionContentRegion);
                    Delight.ScrollableRegion.HorizontalScrollbarTemplateProperty.SetDefault(_levelSelectExampleList1ScrollableRegion, LevelSelectExampleList1ScrollableRegionHorizontalScrollbar);
                    Delight.ScrollableRegion.VerticalScrollbarTemplateProperty.SetDefault(_levelSelectExampleList1ScrollableRegion, LevelSelectExampleList1ScrollableRegionVerticalScrollbar);
                }
                return _levelSelectExampleList1ScrollableRegion;
            }
        }

        private static Template _levelSelectExampleList1ScrollableRegionContentRegion;
        public static Template LevelSelectExampleList1ScrollableRegionContentRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_levelSelectExampleList1ScrollableRegionContentRegion == null || _levelSelectExampleList1ScrollableRegionContentRegion.CurrentVersion != Template.Version)
#else
                if (_levelSelectExampleList1ScrollableRegionContentRegion == null)
#endif
                {
                    _levelSelectExampleList1ScrollableRegionContentRegion = new Template(ListTemplates.ListScrollableRegionContentRegion);
#if UNITY_EDITOR
                    _levelSelectExampleList1ScrollableRegionContentRegion.Name = "LevelSelectExampleList1ScrollableRegionContentRegion";
                    _levelSelectExampleList1ScrollableRegionContentRegion.LineNumber = 24;
                    _levelSelectExampleList1ScrollableRegionContentRegion.LinePosition = 4;
#endif
                }
                return _levelSelectExampleList1ScrollableRegionContentRegion;
            }
        }

        private static Template _levelSelectExampleList1ScrollableRegionHorizontalScrollbar;
        public static Template LevelSelectExampleList1ScrollableRegionHorizontalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_levelSelectExampleList1ScrollableRegionHorizontalScrollbar == null || _levelSelectExampleList1ScrollableRegionHorizontalScrollbar.CurrentVersion != Template.Version)
#else
                if (_levelSelectExampleList1ScrollableRegionHorizontalScrollbar == null)
#endif
                {
                    _levelSelectExampleList1ScrollableRegionHorizontalScrollbar = new Template(ListTemplates.ListScrollableRegionHorizontalScrollbar);
#if UNITY_EDITOR
                    _levelSelectExampleList1ScrollableRegionHorizontalScrollbar.Name = "LevelSelectExampleList1ScrollableRegionHorizontalScrollbar";
                    _levelSelectExampleList1ScrollableRegionHorizontalScrollbar.LineNumber = 26;
                    _levelSelectExampleList1ScrollableRegionHorizontalScrollbar.LinePosition = 4;
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_levelSelectExampleList1ScrollableRegionHorizontalScrollbar, LevelSelectExampleList1ScrollableRegionHorizontalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_levelSelectExampleList1ScrollableRegionHorizontalScrollbar, LevelSelectExampleList1ScrollableRegionHorizontalScrollbarHandle);
                }
                return _levelSelectExampleList1ScrollableRegionHorizontalScrollbar;
            }
        }

        private static Template _levelSelectExampleList1ScrollableRegionHorizontalScrollbarBar;
        public static Template LevelSelectExampleList1ScrollableRegionHorizontalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_levelSelectExampleList1ScrollableRegionHorizontalScrollbarBar == null || _levelSelectExampleList1ScrollableRegionHorizontalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_levelSelectExampleList1ScrollableRegionHorizontalScrollbarBar == null)
#endif
                {
                    _levelSelectExampleList1ScrollableRegionHorizontalScrollbarBar = new Template(ListTemplates.ListScrollableRegionHorizontalScrollbarBar);
#if UNITY_EDITOR
                    _levelSelectExampleList1ScrollableRegionHorizontalScrollbarBar.Name = "LevelSelectExampleList1ScrollableRegionHorizontalScrollbarBar";
                    _levelSelectExampleList1ScrollableRegionHorizontalScrollbarBar.LineNumber = 7;
                    _levelSelectExampleList1ScrollableRegionHorizontalScrollbarBar.LinePosition = 4;
#endif
                }
                return _levelSelectExampleList1ScrollableRegionHorizontalScrollbarBar;
            }
        }

        private static Template _levelSelectExampleList1ScrollableRegionHorizontalScrollbarHandle;
        public static Template LevelSelectExampleList1ScrollableRegionHorizontalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_levelSelectExampleList1ScrollableRegionHorizontalScrollbarHandle == null || _levelSelectExampleList1ScrollableRegionHorizontalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_levelSelectExampleList1ScrollableRegionHorizontalScrollbarHandle == null)
#endif
                {
                    _levelSelectExampleList1ScrollableRegionHorizontalScrollbarHandle = new Template(ListTemplates.ListScrollableRegionHorizontalScrollbarHandle);
#if UNITY_EDITOR
                    _levelSelectExampleList1ScrollableRegionHorizontalScrollbarHandle.Name = "LevelSelectExampleList1ScrollableRegionHorizontalScrollbarHandle";
                    _levelSelectExampleList1ScrollableRegionHorizontalScrollbarHandle.LineNumber = 8;
                    _levelSelectExampleList1ScrollableRegionHorizontalScrollbarHandle.LinePosition = 6;
#endif
                }
                return _levelSelectExampleList1ScrollableRegionHorizontalScrollbarHandle;
            }
        }

        private static Template _levelSelectExampleList1ScrollableRegionVerticalScrollbar;
        public static Template LevelSelectExampleList1ScrollableRegionVerticalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_levelSelectExampleList1ScrollableRegionVerticalScrollbar == null || _levelSelectExampleList1ScrollableRegionVerticalScrollbar.CurrentVersion != Template.Version)
#else
                if (_levelSelectExampleList1ScrollableRegionVerticalScrollbar == null)
#endif
                {
                    _levelSelectExampleList1ScrollableRegionVerticalScrollbar = new Template(ListTemplates.ListScrollableRegionVerticalScrollbar);
#if UNITY_EDITOR
                    _levelSelectExampleList1ScrollableRegionVerticalScrollbar.Name = "LevelSelectExampleList1ScrollableRegionVerticalScrollbar";
                    _levelSelectExampleList1ScrollableRegionVerticalScrollbar.LineNumber = 27;
                    _levelSelectExampleList1ScrollableRegionVerticalScrollbar.LinePosition = 4;
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_levelSelectExampleList1ScrollableRegionVerticalScrollbar, LevelSelectExampleList1ScrollableRegionVerticalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_levelSelectExampleList1ScrollableRegionVerticalScrollbar, LevelSelectExampleList1ScrollableRegionVerticalScrollbarHandle);
                }
                return _levelSelectExampleList1ScrollableRegionVerticalScrollbar;
            }
        }

        private static Template _levelSelectExampleList1ScrollableRegionVerticalScrollbarBar;
        public static Template LevelSelectExampleList1ScrollableRegionVerticalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_levelSelectExampleList1ScrollableRegionVerticalScrollbarBar == null || _levelSelectExampleList1ScrollableRegionVerticalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_levelSelectExampleList1ScrollableRegionVerticalScrollbarBar == null)
#endif
                {
                    _levelSelectExampleList1ScrollableRegionVerticalScrollbarBar = new Template(ListTemplates.ListScrollableRegionVerticalScrollbarBar);
#if UNITY_EDITOR
                    _levelSelectExampleList1ScrollableRegionVerticalScrollbarBar.Name = "LevelSelectExampleList1ScrollableRegionVerticalScrollbarBar";
                    _levelSelectExampleList1ScrollableRegionVerticalScrollbarBar.LineNumber = 7;
                    _levelSelectExampleList1ScrollableRegionVerticalScrollbarBar.LinePosition = 4;
#endif
                }
                return _levelSelectExampleList1ScrollableRegionVerticalScrollbarBar;
            }
        }

        private static Template _levelSelectExampleList1ScrollableRegionVerticalScrollbarHandle;
        public static Template LevelSelectExampleList1ScrollableRegionVerticalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_levelSelectExampleList1ScrollableRegionVerticalScrollbarHandle == null || _levelSelectExampleList1ScrollableRegionVerticalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_levelSelectExampleList1ScrollableRegionVerticalScrollbarHandle == null)
#endif
                {
                    _levelSelectExampleList1ScrollableRegionVerticalScrollbarHandle = new Template(ListTemplates.ListScrollableRegionVerticalScrollbarHandle);
#if UNITY_EDITOR
                    _levelSelectExampleList1ScrollableRegionVerticalScrollbarHandle.Name = "LevelSelectExampleList1ScrollableRegionVerticalScrollbarHandle";
                    _levelSelectExampleList1ScrollableRegionVerticalScrollbarHandle.LineNumber = 8;
                    _levelSelectExampleList1ScrollableRegionVerticalScrollbarHandle.LinePosition = 6;
#endif
                }
                return _levelSelectExampleList1ScrollableRegionVerticalScrollbarHandle;
            }
        }

        private static Template _levelSelectExampleListItem1;
        public static Template LevelSelectExampleListItem1
        {
            get
            {
#if UNITY_EDITOR
                if (_levelSelectExampleListItem1 == null || _levelSelectExampleListItem1.CurrentVersion != Template.Version)
#else
                if (_levelSelectExampleListItem1 == null)
#endif
                {
                    _levelSelectExampleListItem1 = new Template(ListItemTemplates.ListItem);
#if UNITY_EDITOR
                    _levelSelectExampleListItem1.Name = "LevelSelectExampleListItem1";
                    _levelSelectExampleListItem1.LineNumber = 10;
                    _levelSelectExampleListItem1.LinePosition = 6;
#endif
                    Delight.ListItem.BackgroundColorProperty.SetDefault(_levelSelectExampleListItem1, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.ListItem.BackgroundSpriteProperty.SetDefault(_levelSelectExampleListItem1, Assets.Sprites["LevelSelectItemBg"]);
                    Delight.ListItem.WidthProperty.SetDefault(_levelSelectExampleListItem1, new ElementSize(150f, ElementSizeUnit.Pixels));
                    Delight.ListItem.HeightProperty.SetDefault(_levelSelectExampleListItem1, new ElementSize(150f, ElementSizeUnit.Pixels));
                }
                return _levelSelectExampleListItem1;
            }
        }

        private static Template _levelSelectExampleLabel2;
        public static Template LevelSelectExampleLabel2
        {
            get
            {
#if UNITY_EDITOR
                if (_levelSelectExampleLabel2 == null || _levelSelectExampleLabel2.CurrentVersion != Template.Version)
#else
                if (_levelSelectExampleLabel2 == null)
#endif
                {
                    _levelSelectExampleLabel2 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _levelSelectExampleLabel2.Name = "LevelSelectExampleLabel2";
                    _levelSelectExampleLabel2.LineNumber = 11;
                    _levelSelectExampleLabel2.LinePosition = 8;
#endif
                    Delight.Label.FontSizeProperty.SetDefault(_levelSelectExampleLabel2, 50f);
                    Delight.Label.AutoSizeProperty.SetDefault(_levelSelectExampleLabel2, Delight.AutoSize.Default);
                    Delight.Label.FontProperty.SetDefault(_levelSelectExampleLabel2, Assets.TMP_FontAssets["AveriaSansLibre-Bold SDF"]);
                    Delight.Label.FontColorProperty.SetDefault(_levelSelectExampleLabel2, new UnityEngine.Color(0.9254902f, 0.8078431f, 0.1764706f, 1f));
                    Delight.Label.OffsetProperty.SetDefault(_levelSelectExampleLabel2, new ElementMargin(new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(30f, ElementSizeUnit.Pixels)));
                    Delight.Label.TextProperty.SetHasBinding(_levelSelectExampleLabel2);
                }
                return _levelSelectExampleLabel2;
            }
        }

        private static Template _levelSelectExampleImage2;
        public static Template LevelSelectExampleImage2
        {
            get
            {
#if UNITY_EDITOR
                if (_levelSelectExampleImage2 == null || _levelSelectExampleImage2.CurrentVersion != Template.Version)
#else
                if (_levelSelectExampleImage2 == null)
#endif
                {
                    _levelSelectExampleImage2 = new Template(ImageTemplates.Image);
#if UNITY_EDITOR
                    _levelSelectExampleImage2.Name = "LevelSelectExampleImage2";
                    _levelSelectExampleImage2.LineNumber = 13;
                    _levelSelectExampleImage2.LinePosition = 8;
#endif
                    Delight.Image.PreserveAspectProperty.SetDefault(_levelSelectExampleImage2, true);
                    Delight.Image.WidthProperty.SetDefault(_levelSelectExampleImage2, new ElementSize(110f, ElementSizeUnit.Pixels));
                    Delight.Image.OffsetProperty.SetDefault(_levelSelectExampleImage2, new ElementMargin(new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(20f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels)));
                    Delight.Image.SpriteProperty.SetHasBinding(_levelSelectExampleImage2);
                }
                return _levelSelectExampleImage2;
            }
        }

        private static Template _levelSelectExampleNavigationButton1;
        public static Template LevelSelectExampleNavigationButton1
        {
            get
            {
#if UNITY_EDITOR
                if (_levelSelectExampleNavigationButton1 == null || _levelSelectExampleNavigationButton1.CurrentVersion != Template.Version)
#else
                if (_levelSelectExampleNavigationButton1 == null)
#endif
                {
                    _levelSelectExampleNavigationButton1 = new Template(NavigationButtonTemplates.NavigationButton);
#if UNITY_EDITOR
                    _levelSelectExampleNavigationButton1.Name = "LevelSelectExampleNavigationButton1";
                    _levelSelectExampleNavigationButton1.LineNumber = 15;
                    _levelSelectExampleNavigationButton1.LinePosition = 6;
#endif
                    Delight.NavigationButton.BackgroundSpriteProperty.SetDefault(_levelSelectExampleNavigationButton1, Assets.Sprites["LevelSelectRightArrow"]);
                    Delight.NavigationButton.BackgroundColorProperty.SetDefault(_levelSelectExampleNavigationButton1, new UnityEngine.Color(0.7333333f, 0.7333333f, 0.7333333f, 1f));
                    Delight.NavigationButton.BackgroundColorProperty.SetStateDefault("Highlighted", _levelSelectExampleNavigationButton1, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.NavigationButton.BackgroundColorProperty.SetStateDefault("Pressed", _levelSelectExampleNavigationButton1, new UnityEngine.Color(0.7333333f, 0.7333333f, 0.7333333f, 1f));
                    Delight.NavigationButton.WidthProperty.SetDefault(_levelSelectExampleNavigationButton1, new ElementSize(50f, ElementSizeUnit.Pixels));
                    Delight.NavigationButton.HeightProperty.SetDefault(_levelSelectExampleNavigationButton1, new ElementSize(77f, ElementSizeUnit.Pixels));
                    Delight.NavigationButton.OffsetProperty.SetDefault(_levelSelectExampleNavigationButton1, new ElementMargin(new ElementSize(110f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(10f, ElementSizeUnit.Pixels)));
                    Delight.NavigationButton.LabelTemplateProperty.SetDefault(_levelSelectExampleNavigationButton1, LevelSelectExampleNavigationButton1Label);
                }
                return _levelSelectExampleNavigationButton1;
            }
        }

        private static Template _levelSelectExampleNavigationButton1Label;
        public static Template LevelSelectExampleNavigationButton1Label
        {
            get
            {
#if UNITY_EDITOR
                if (_levelSelectExampleNavigationButton1Label == null || _levelSelectExampleNavigationButton1Label.CurrentVersion != Template.Version)
#else
                if (_levelSelectExampleNavigationButton1Label == null)
#endif
                {
                    _levelSelectExampleNavigationButton1Label = new Template(NavigationButtonTemplates.NavigationButtonLabel);
#if UNITY_EDITOR
                    _levelSelectExampleNavigationButton1Label.Name = "LevelSelectExampleNavigationButton1Label";
                    _levelSelectExampleNavigationButton1Label.LineNumber = 15;
                    _levelSelectExampleNavigationButton1Label.LinePosition = 4;
#endif
                }
                return _levelSelectExampleNavigationButton1Label;
            }
        }

        private static Template _levelSelectExampleNavigationButton2;
        public static Template LevelSelectExampleNavigationButton2
        {
            get
            {
#if UNITY_EDITOR
                if (_levelSelectExampleNavigationButton2 == null || _levelSelectExampleNavigationButton2.CurrentVersion != Template.Version)
#else
                if (_levelSelectExampleNavigationButton2 == null)
#endif
                {
                    _levelSelectExampleNavigationButton2 = new Template(NavigationButtonTemplates.NavigationButton);
#if UNITY_EDITOR
                    _levelSelectExampleNavigationButton2.Name = "LevelSelectExampleNavigationButton2";
                    _levelSelectExampleNavigationButton2.LineNumber = 18;
                    _levelSelectExampleNavigationButton2.LinePosition = 6;
#endif
                    Delight.NavigationButton.BackgroundSpriteProperty.SetDefault(_levelSelectExampleNavigationButton2, Assets.Sprites["LevelSelectPageButton"]);
                    Delight.NavigationButton.BackgroundSpriteProperty.SetStateDefault("Pressed", _levelSelectExampleNavigationButton2, Assets.Sprites["LevelSelectPageButtonPressed"]);
                    Delight.NavigationButton.BackgroundColorProperty.SetDefault(_levelSelectExampleNavigationButton2, new UnityEngine.Color(0.7333333f, 0.7333333f, 0.7333333f, 1f));
                    Delight.NavigationButton.BackgroundColorProperty.SetStateDefault("Highlighted", _levelSelectExampleNavigationButton2, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.NavigationButton.BackgroundColorProperty.SetStateDefault("Pressed", _levelSelectExampleNavigationButton2, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.NavigationButton.NavigationTypeProperty.SetDefault(_levelSelectExampleNavigationButton2, Delight.NavigationButtonType.Page);
                    Delight.NavigationButton.WidthProperty.SetDefault(_levelSelectExampleNavigationButton2, new ElementSize(50f, ElementSizeUnit.Pixels));
                    Delight.NavigationButton.HeightProperty.SetDefault(_levelSelectExampleNavigationButton2, new ElementSize(50f, ElementSizeUnit.Pixels));
                    Delight.NavigationButton.DisplayLabelProperty.SetDefault(_levelSelectExampleNavigationButton2, false);
                    Delight.NavigationButton.LabelTemplateProperty.SetDefault(_levelSelectExampleNavigationButton2, LevelSelectExampleNavigationButton2Label);
                }
                return _levelSelectExampleNavigationButton2;
            }
        }

        private static Template _levelSelectExampleNavigationButton2Label;
        public static Template LevelSelectExampleNavigationButton2Label
        {
            get
            {
#if UNITY_EDITOR
                if (_levelSelectExampleNavigationButton2Label == null || _levelSelectExampleNavigationButton2Label.CurrentVersion != Template.Version)
#else
                if (_levelSelectExampleNavigationButton2Label == null)
#endif
                {
                    _levelSelectExampleNavigationButton2Label = new Template(NavigationButtonTemplates.NavigationButtonLabel);
#if UNITY_EDITOR
                    _levelSelectExampleNavigationButton2Label.Name = "LevelSelectExampleNavigationButton2Label";
                    _levelSelectExampleNavigationButton2Label.LineNumber = 15;
                    _levelSelectExampleNavigationButton2Label.LinePosition = 4;
#endif
                }
                return _levelSelectExampleNavigationButton2Label;
            }
        }

        private static Template _levelSelectExampleButton1;
        public static Template LevelSelectExampleButton1
        {
            get
            {
#if UNITY_EDITOR
                if (_levelSelectExampleButton1 == null || _levelSelectExampleButton1.CurrentVersion != Template.Version)
#else
                if (_levelSelectExampleButton1 == null)
#endif
                {
                    _levelSelectExampleButton1 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _levelSelectExampleButton1.Name = "LevelSelectExampleButton1";
                    _levelSelectExampleButton1.LineNumber = 22;
                    _levelSelectExampleButton1.LinePosition = 4;
#endif
                    Delight.Button.BackgroundSpriteProperty.SetDefault(_levelSelectExampleButton1, Assets.Sprites["MainMenuDemoBackButton"]);
                    Delight.Button.BackgroundSpriteProperty.SetStateDefault("Pressed", _levelSelectExampleButton1, Assets.Sprites["MainMenuDemoBackButtonPressed"]);
                    Delight.Button.BackgroundColorProperty.SetDefault(_levelSelectExampleButton1, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Button.BackgroundColorProperty.SetStateDefault("Highlighted", _levelSelectExampleButton1, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Button.BackgroundColorProperty.SetStateDefault("Pressed", _levelSelectExampleButton1, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Button.WidthProperty.SetDefault(_levelSelectExampleButton1, new ElementSize(100f, ElementSizeUnit.Pixels));
                    Delight.Button.HeightProperty.SetDefault(_levelSelectExampleButton1, new ElementSize(102f, ElementSizeUnit.Pixels));
                    Delight.Button.AlignmentProperty.SetDefault(_levelSelectExampleButton1, Delight.ElementAlignment.Bottom);
                    Delight.Button.OffsetProperty.SetDefault(_levelSelectExampleButton1, new ElementMargin(new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(40f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels)));
                    Delight.Button.LabelTemplateProperty.SetDefault(_levelSelectExampleButton1, LevelSelectExampleButton1Label);
                }
                return _levelSelectExampleButton1;
            }
        }

        private static Template _levelSelectExampleButton1Label;
        public static Template LevelSelectExampleButton1Label
        {
            get
            {
#if UNITY_EDITOR
                if (_levelSelectExampleButton1Label == null || _levelSelectExampleButton1Label.CurrentVersion != Template.Version)
#else
                if (_levelSelectExampleButton1Label == null)
#endif
                {
                    _levelSelectExampleButton1Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _levelSelectExampleButton1Label.Name = "LevelSelectExampleButton1Label";
                    _levelSelectExampleButton1Label.LineNumber = 15;
                    _levelSelectExampleButton1Label.LinePosition = 4;
#endif
                }
                return _levelSelectExampleButton1Label;
            }
        }

        #endregion
    }

    #endregion
}
