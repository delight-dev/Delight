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

            // binding <List Items="{level in @Levels}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> {  }, new List<Func<BindableObject>> {  }) }, new BindingPath(new List<string> { "List1", "Items" }, new List<Func<BindableObject>> { () => this, () => List1 }), () => List1.Items = Models.Levels, () => { }, false));

            // templates for List1
            List1.ContentTemplates.Add(new ContentTemplate(tiLevel => 
            {
                var listItem1 = new ListItem(this, List1.Content, "ListItem1", ListItem1Template);
                var label2 = new Label(this, listItem1.Content, "Label2", Label2Template);

                // binding <Label Text="{level.Index:0}">
                listItem1.Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "Index" }, new List<Func<BindableObject>> { () => tiLevel }) }, new BindingPath(new List<string> { "Text" }, new List<Func<BindableObject>> { () => label2 }), () => label2.Text = String.Format("{0:0}", tiLevel.Index), () => { }, false));
                var image2 = new Image(this, listItem1.Content, "Image2", Image2Template);

                // binding <Image Sprite="{level.Stars}">
                listItem1.Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "Item", "Stars" }, new List<Func<BindableObject>> { () => tiLevel, () => (tiLevel.Item as Delight.Level) }) }, new BindingPath(new List<string> { "Sprite" }, new List<Func<BindableObject>> { () => image2 }), () => image2.Sprite = (tiLevel.Item as Delight.Level).Stars, () => { }, false));
                listItem1.IsDynamic = true;
                listItem1.SetContentTemplateData(tiLevel);
                return listItem1;
            }, typeof(ListItem), "ListItem1"));
            this.AfterInitializeInternal();
        }

        public LevelSelectExample() : this(null)
        {
        }

        static LevelSelectExample()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(LevelSelectExampleTemplates.Default, dependencyProperties);

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
        }

        #endregion

        #region Properties

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
#endif
                    Delight.LevelSelectExample.WidthProperty.SetDefault(_levelSelectExample, new ElementSize(750f, ElementSizeUnit.Pixels));
                    Delight.LevelSelectExample.HeightProperty.SetDefault(_levelSelectExample, new ElementSize(600f, ElementSizeUnit.Pixels));
                    Delight.LevelSelectExample.Image1TemplateProperty.SetDefault(_levelSelectExample, LevelSelectExampleImage1);
                    Delight.LevelSelectExample.Label1TemplateProperty.SetDefault(_levelSelectExample, LevelSelectExampleLabel1);
                    Delight.LevelSelectExample.List1TemplateProperty.SetDefault(_levelSelectExample, LevelSelectExampleList1);
                    Delight.LevelSelectExample.ListItem1TemplateProperty.SetDefault(_levelSelectExample, LevelSelectExampleListItem1);
                    Delight.LevelSelectExample.Label2TemplateProperty.SetDefault(_levelSelectExample, LevelSelectExampleLabel2);
                    Delight.LevelSelectExample.Image2TemplateProperty.SetDefault(_levelSelectExample, LevelSelectExampleImage2);
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
#endif
                    Delight.Image.PreserveAspectProperty.SetDefault(_levelSelectExampleImage2, true);
                    Delight.Image.WidthProperty.SetDefault(_levelSelectExampleImage2, new ElementSize(110f, ElementSizeUnit.Pixels));
                    Delight.Image.OffsetProperty.SetDefault(_levelSelectExampleImage2, new ElementMargin(new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(20f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels)));
                    Delight.Image.SpriteProperty.SetHasBinding(_levelSelectExampleImage2);
                }
                return _levelSelectExampleImage2;
            }
        }

        #endregion
    }

    #endregion
}
