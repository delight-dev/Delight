// Internal view logic generated from "HighscoreDemo.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class HighscoreDemo : UIView
    {
        #region Constructors

        public HighscoreDemo(View parent, View layoutParent = null, string id = null, Template template = null, bool deferInitialization = false) :
            base(parent, layoutParent, id, template ?? HighscoreDemoTemplates.Default, deferInitialization)
        {
            if (deferInitialization)
                return;

            // constructing Image (Image1)
            Image1 = new Image(this, this, "Image1", Image1Template);

            // constructing Group (Group1)
            Group1 = new Group(this, this, "Group1", Group1Template);
            Label1 = new Label(this, Group1.Content, "Label1", Label1Template);
            List1 = new List(this, Group1.Content, "List1", List1Template);

            // binding <List Items="{highscore in @Highscores}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> {  }, new List<Func<BindableObject>> {  }) }, new BindingPath(new List<string> { "List1", "Items" }, new List<Func<BindableObject>> { () => this, () => List1 }), () => List1.Items = Models.Highscores, () => { }, false));

            // templates for List1
            List1.ContentTemplates.Add(new ContentTemplate(tiHighscore => 
            {
                var listItem1 = new ListItem(this, List1.Content, "ListItem1", ListItem1Template);
                var label2 = new Label(this, listItem1.Content, "Label2", Label2Template);
                listItem1.SetListItemState.SetValue(label2, true);

                // binding <Label Text="{highscore.Index}. {highscore.Player.Name}">
                listItem1.Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "Index" }, new List<Func<BindableObject>> { () => tiHighscore }), new BindingPath(new List<string> { "Item", "Player", "Name" }, new List<Func<BindableObject>> { () => tiHighscore, () => (tiHighscore.Item as Delight.Highscore), () => (tiHighscore.Item as Delight.Highscore).Player }) }, new BindingPath(new List<string> { "Text" }, new List<Func<BindableObject>> { () => label2 }), () => label2.Text = String.Format("{0}. {1}", tiHighscore.Index, (tiHighscore.Item as Delight.Highscore).Player.Name), () => { }, false));
                var label3 = new Label(this, listItem1.Content, "Label3", Label3Template);
                listItem1.SetListItemState.SetValue(label3, true);

                // binding <Label Text="{highscore.ScoreText}">
                listItem1.Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "Item", "ScoreText" }, new List<Func<BindableObject>> { () => tiHighscore, () => (tiHighscore.Item as Delight.Highscore) }) }, new BindingPath(new List<string> { "Text" }, new List<Func<BindableObject>> { () => label3 }), () => label3.Text = (tiHighscore.Item as Delight.Highscore).ScoreText, () => { }, false));
                listItem1.IsDynamic = true;
                listItem1.SetContentTemplateData(tiHighscore);
                return listItem1;
            }, typeof(ListItem), "ListItem1"));
            this.AfterInitializeInternal();
        }

        public HighscoreDemo() : this(null)
        {
        }

        static HighscoreDemo()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(HighscoreDemoTemplates.Default, dependencyProperties);

            dependencyProperties.Add(Image1Property);
            dependencyProperties.Add(Image1TemplateProperty);
            dependencyProperties.Add(Group1Property);
            dependencyProperties.Add(Group1TemplateProperty);
            dependencyProperties.Add(Label1Property);
            dependencyProperties.Add(Label1TemplateProperty);
            dependencyProperties.Add(List1Property);
            dependencyProperties.Add(List1TemplateProperty);
            dependencyProperties.Add(ListItem1Property);
            dependencyProperties.Add(ListItem1TemplateProperty);
            dependencyProperties.Add(Label2Property);
            dependencyProperties.Add(Label2TemplateProperty);
            dependencyProperties.Add(Label3Property);
            dependencyProperties.Add(Label3TemplateProperty);
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

        public readonly static DependencyProperty<Label> Label3Property = new DependencyProperty<Label>("Label3");
        public Label Label3
        {
            get { return Label3Property.GetValue(this); }
            set { Label3Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Label3TemplateProperty = new DependencyProperty<Template>("Label3Template");
        public Template Label3Template
        {
            get { return Label3TemplateProperty.GetValue(this); }
            set { Label3TemplateProperty.SetValue(this, value); }
        }

        #endregion
    }

    #region Data Templates

    public static class HighscoreDemoTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return HighscoreDemo;
            }
        }

        private static Template _highscoreDemo;
        public static Template HighscoreDemo
        {
            get
            {
#if UNITY_EDITOR
                if (_highscoreDemo == null || _highscoreDemo.CurrentVersion != Template.Version)
#else
                if (_highscoreDemo == null)
#endif
                {
                    _highscoreDemo = new Template(UIViewTemplates.UIView);
#if UNITY_EDITOR
                    _highscoreDemo.Name = "HighscoreDemo";
#endif
                    Delight.HighscoreDemo.Image1TemplateProperty.SetDefault(_highscoreDemo, HighscoreDemoImage1);
                    Delight.HighscoreDemo.Group1TemplateProperty.SetDefault(_highscoreDemo, HighscoreDemoGroup1);
                    Delight.HighscoreDemo.Label1TemplateProperty.SetDefault(_highscoreDemo, HighscoreDemoLabel1);
                    Delight.HighscoreDemo.List1TemplateProperty.SetDefault(_highscoreDemo, HighscoreDemoList1);
                    Delight.HighscoreDemo.ListItem1TemplateProperty.SetDefault(_highscoreDemo, HighscoreDemoListItem1);
                    Delight.HighscoreDemo.Label2TemplateProperty.SetDefault(_highscoreDemo, HighscoreDemoLabel2);
                    Delight.HighscoreDemo.Label3TemplateProperty.SetDefault(_highscoreDemo, HighscoreDemoLabel3);
                }
                return _highscoreDemo;
            }
        }

        private static Template _highscoreDemoImage1;
        public static Template HighscoreDemoImage1
        {
            get
            {
#if UNITY_EDITOR
                if (_highscoreDemoImage1 == null || _highscoreDemoImage1.CurrentVersion != Template.Version)
#else
                if (_highscoreDemoImage1 == null)
#endif
                {
                    _highscoreDemoImage1 = new Template(ImageTemplates.Image);
#if UNITY_EDITOR
                    _highscoreDemoImage1.Name = "HighscoreDemoImage1";
#endif
                    Delight.Image.SpriteProperty.SetDefault(_highscoreDemoImage1, Assets.Sprites["audionautbg"]);
                    Delight.Image.WidthProperty.SetDefault(_highscoreDemoImage1, new ElementSize(1240f, ElementSizeUnit.Pixels));
                    Delight.Image.HeightProperty.SetDefault(_highscoreDemoImage1, new ElementSize(720f, ElementSizeUnit.Pixels));
                }
                return _highscoreDemoImage1;
            }
        }

        private static Template _highscoreDemoGroup1;
        public static Template HighscoreDemoGroup1
        {
            get
            {
#if UNITY_EDITOR
                if (_highscoreDemoGroup1 == null || _highscoreDemoGroup1.CurrentVersion != Template.Version)
#else
                if (_highscoreDemoGroup1 == null)
#endif
                {
                    _highscoreDemoGroup1 = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _highscoreDemoGroup1.Name = "HighscoreDemoGroup1";
#endif
                    Delight.Group.SpacingProperty.SetDefault(_highscoreDemoGroup1, new ElementSize(20f, ElementSizeUnit.Pixels));
                }
                return _highscoreDemoGroup1;
            }
        }

        private static Template _highscoreDemoLabel1;
        public static Template HighscoreDemoLabel1
        {
            get
            {
#if UNITY_EDITOR
                if (_highscoreDemoLabel1 == null || _highscoreDemoLabel1.CurrentVersion != Template.Version)
#else
                if (_highscoreDemoLabel1 == null)
#endif
                {
                    _highscoreDemoLabel1 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _highscoreDemoLabel1.Name = "HighscoreDemoLabel1";
#endif
                    Delight.Label.TextProperty.SetDefault(_highscoreDemoLabel1, "High Scores");
                    Delight.Label.FontSizeProperty.SetDefault(_highscoreDemoLabel1, 45f);
                    Delight.Label.AutoSizeProperty.SetDefault(_highscoreDemoLabel1, Delight.AutoSize.Default);
                    Delight.Label.FontColorProperty.SetDefault(_highscoreDemoLabel1, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Label.FontProperty.SetDefault(_highscoreDemoLabel1, Assets.TMP_FontAssets["Discognate"]);
                }
                return _highscoreDemoLabel1;
            }
        }

        private static Template _highscoreDemoList1;
        public static Template HighscoreDemoList1
        {
            get
            {
#if UNITY_EDITOR
                if (_highscoreDemoList1 == null || _highscoreDemoList1.CurrentVersion != Template.Version)
#else
                if (_highscoreDemoList1 == null)
#endif
                {
                    _highscoreDemoList1 = new Template(ListTemplates.List);
#if UNITY_EDITOR
                    _highscoreDemoList1.Name = "HighscoreDemoList1";
#endif
                    Delight.List.AlternateItemsProperty.SetDefault(_highscoreDemoList1, true);
                    Delight.List.ItemsProperty.SetHasBinding(_highscoreDemoList1);
                    Delight.List.ScrollableRegionTemplateProperty.SetDefault(_highscoreDemoList1, HighscoreDemoList1ScrollableRegion);
                }
                return _highscoreDemoList1;
            }
        }

        private static Template _highscoreDemoList1ScrollableRegion;
        public static Template HighscoreDemoList1ScrollableRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_highscoreDemoList1ScrollableRegion == null || _highscoreDemoList1ScrollableRegion.CurrentVersion != Template.Version)
#else
                if (_highscoreDemoList1ScrollableRegion == null)
#endif
                {
                    _highscoreDemoList1ScrollableRegion = new Template(ListTemplates.ListScrollableRegion);
#if UNITY_EDITOR
                    _highscoreDemoList1ScrollableRegion.Name = "HighscoreDemoList1ScrollableRegion";
#endif
                    Delight.ScrollableRegion.ContentRegionTemplateProperty.SetDefault(_highscoreDemoList1ScrollableRegion, HighscoreDemoList1ScrollableRegionContentRegion);
                    Delight.ScrollableRegion.HorizontalScrollbarTemplateProperty.SetDefault(_highscoreDemoList1ScrollableRegion, HighscoreDemoList1ScrollableRegionHorizontalScrollbar);
                    Delight.ScrollableRegion.VerticalScrollbarTemplateProperty.SetDefault(_highscoreDemoList1ScrollableRegion, HighscoreDemoList1ScrollableRegionVerticalScrollbar);
                }
                return _highscoreDemoList1ScrollableRegion;
            }
        }

        private static Template _highscoreDemoList1ScrollableRegionContentRegion;
        public static Template HighscoreDemoList1ScrollableRegionContentRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_highscoreDemoList1ScrollableRegionContentRegion == null || _highscoreDemoList1ScrollableRegionContentRegion.CurrentVersion != Template.Version)
#else
                if (_highscoreDemoList1ScrollableRegionContentRegion == null)
#endif
                {
                    _highscoreDemoList1ScrollableRegionContentRegion = new Template(ListTemplates.ListScrollableRegionContentRegion);
#if UNITY_EDITOR
                    _highscoreDemoList1ScrollableRegionContentRegion.Name = "HighscoreDemoList1ScrollableRegionContentRegion";
#endif
                }
                return _highscoreDemoList1ScrollableRegionContentRegion;
            }
        }

        private static Template _highscoreDemoList1ScrollableRegionHorizontalScrollbar;
        public static Template HighscoreDemoList1ScrollableRegionHorizontalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_highscoreDemoList1ScrollableRegionHorizontalScrollbar == null || _highscoreDemoList1ScrollableRegionHorizontalScrollbar.CurrentVersion != Template.Version)
#else
                if (_highscoreDemoList1ScrollableRegionHorizontalScrollbar == null)
#endif
                {
                    _highscoreDemoList1ScrollableRegionHorizontalScrollbar = new Template(ListTemplates.ListScrollableRegionHorizontalScrollbar);
#if UNITY_EDITOR
                    _highscoreDemoList1ScrollableRegionHorizontalScrollbar.Name = "HighscoreDemoList1ScrollableRegionHorizontalScrollbar";
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_highscoreDemoList1ScrollableRegionHorizontalScrollbar, HighscoreDemoList1ScrollableRegionHorizontalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_highscoreDemoList1ScrollableRegionHorizontalScrollbar, HighscoreDemoList1ScrollableRegionHorizontalScrollbarHandle);
                }
                return _highscoreDemoList1ScrollableRegionHorizontalScrollbar;
            }
        }

        private static Template _highscoreDemoList1ScrollableRegionHorizontalScrollbarBar;
        public static Template HighscoreDemoList1ScrollableRegionHorizontalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_highscoreDemoList1ScrollableRegionHorizontalScrollbarBar == null || _highscoreDemoList1ScrollableRegionHorizontalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_highscoreDemoList1ScrollableRegionHorizontalScrollbarBar == null)
#endif
                {
                    _highscoreDemoList1ScrollableRegionHorizontalScrollbarBar = new Template(ListTemplates.ListScrollableRegionHorizontalScrollbarBar);
#if UNITY_EDITOR
                    _highscoreDemoList1ScrollableRegionHorizontalScrollbarBar.Name = "HighscoreDemoList1ScrollableRegionHorizontalScrollbarBar";
#endif
                }
                return _highscoreDemoList1ScrollableRegionHorizontalScrollbarBar;
            }
        }

        private static Template _highscoreDemoList1ScrollableRegionHorizontalScrollbarHandle;
        public static Template HighscoreDemoList1ScrollableRegionHorizontalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_highscoreDemoList1ScrollableRegionHorizontalScrollbarHandle == null || _highscoreDemoList1ScrollableRegionHorizontalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_highscoreDemoList1ScrollableRegionHorizontalScrollbarHandle == null)
#endif
                {
                    _highscoreDemoList1ScrollableRegionHorizontalScrollbarHandle = new Template(ListTemplates.ListScrollableRegionHorizontalScrollbarHandle);
#if UNITY_EDITOR
                    _highscoreDemoList1ScrollableRegionHorizontalScrollbarHandle.Name = "HighscoreDemoList1ScrollableRegionHorizontalScrollbarHandle";
#endif
                }
                return _highscoreDemoList1ScrollableRegionHorizontalScrollbarHandle;
            }
        }

        private static Template _highscoreDemoList1ScrollableRegionVerticalScrollbar;
        public static Template HighscoreDemoList1ScrollableRegionVerticalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_highscoreDemoList1ScrollableRegionVerticalScrollbar == null || _highscoreDemoList1ScrollableRegionVerticalScrollbar.CurrentVersion != Template.Version)
#else
                if (_highscoreDemoList1ScrollableRegionVerticalScrollbar == null)
#endif
                {
                    _highscoreDemoList1ScrollableRegionVerticalScrollbar = new Template(ListTemplates.ListScrollableRegionVerticalScrollbar);
#if UNITY_EDITOR
                    _highscoreDemoList1ScrollableRegionVerticalScrollbar.Name = "HighscoreDemoList1ScrollableRegionVerticalScrollbar";
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_highscoreDemoList1ScrollableRegionVerticalScrollbar, HighscoreDemoList1ScrollableRegionVerticalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_highscoreDemoList1ScrollableRegionVerticalScrollbar, HighscoreDemoList1ScrollableRegionVerticalScrollbarHandle);
                }
                return _highscoreDemoList1ScrollableRegionVerticalScrollbar;
            }
        }

        private static Template _highscoreDemoList1ScrollableRegionVerticalScrollbarBar;
        public static Template HighscoreDemoList1ScrollableRegionVerticalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_highscoreDemoList1ScrollableRegionVerticalScrollbarBar == null || _highscoreDemoList1ScrollableRegionVerticalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_highscoreDemoList1ScrollableRegionVerticalScrollbarBar == null)
#endif
                {
                    _highscoreDemoList1ScrollableRegionVerticalScrollbarBar = new Template(ListTemplates.ListScrollableRegionVerticalScrollbarBar);
#if UNITY_EDITOR
                    _highscoreDemoList1ScrollableRegionVerticalScrollbarBar.Name = "HighscoreDemoList1ScrollableRegionVerticalScrollbarBar";
#endif
                }
                return _highscoreDemoList1ScrollableRegionVerticalScrollbarBar;
            }
        }

        private static Template _highscoreDemoList1ScrollableRegionVerticalScrollbarHandle;
        public static Template HighscoreDemoList1ScrollableRegionVerticalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_highscoreDemoList1ScrollableRegionVerticalScrollbarHandle == null || _highscoreDemoList1ScrollableRegionVerticalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_highscoreDemoList1ScrollableRegionVerticalScrollbarHandle == null)
#endif
                {
                    _highscoreDemoList1ScrollableRegionVerticalScrollbarHandle = new Template(ListTemplates.ListScrollableRegionVerticalScrollbarHandle);
#if UNITY_EDITOR
                    _highscoreDemoList1ScrollableRegionVerticalScrollbarHandle.Name = "HighscoreDemoList1ScrollableRegionVerticalScrollbarHandle";
#endif
                }
                return _highscoreDemoList1ScrollableRegionVerticalScrollbarHandle;
            }
        }

        private static Template _highscoreDemoListItem1;
        public static Template HighscoreDemoListItem1
        {
            get
            {
#if UNITY_EDITOR
                if (_highscoreDemoListItem1 == null || _highscoreDemoListItem1.CurrentVersion != Template.Version)
#else
                if (_highscoreDemoListItem1 == null)
#endif
                {
                    _highscoreDemoListItem1 = new Template(ListItemTemplates.ListItem);
#if UNITY_EDITOR
                    _highscoreDemoListItem1.Name = "HighscoreDemoListItem1";
#endif
                    Delight.ListItem.WidthProperty.SetDefault(_highscoreDemoListItem1, new ElementSize(500f, ElementSizeUnit.Pixels));
                    Delight.ListItem.HeightProperty.SetDefault(_highscoreDemoListItem1, new ElementSize(30f, ElementSizeUnit.Pixels));
                    Delight.ListItem.BackgroundColorProperty.SetStateDefault("Alternate", _highscoreDemoListItem1, new UnityEngine.Color(0.06666667f, 0.06666667f, 0.06666667f, 0.2f));
                }
                return _highscoreDemoListItem1;
            }
        }

        private static Template _highscoreDemoLabel2;
        public static Template HighscoreDemoLabel2
        {
            get
            {
#if UNITY_EDITOR
                if (_highscoreDemoLabel2 == null || _highscoreDemoLabel2.CurrentVersion != Template.Version)
#else
                if (_highscoreDemoLabel2 == null)
#endif
                {
                    _highscoreDemoLabel2 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _highscoreDemoLabel2.Name = "HighscoreDemoLabel2";
#endif
                    Delight.Label.AutoSizeProperty.SetDefault(_highscoreDemoLabel2, Delight.AutoSize.Default);
                    Delight.Label.FontColorProperty.SetDefault(_highscoreDemoLabel2, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Label.FontSizeProperty.SetDefault(_highscoreDemoLabel2, 22f);
                    Delight.Label.AlignmentProperty.SetDefault(_highscoreDemoLabel2, Delight.ElementAlignment.Left);
                    Delight.Label.FontColorProperty.SetStateDefault("Highlighted", _highscoreDemoLabel2, new UnityEngine.Color(0f, 0f, 0f, 1f));
                    Delight.Label.TextProperty.SetHasBinding(_highscoreDemoLabel2);
                }
                return _highscoreDemoLabel2;
            }
        }

        private static Template _highscoreDemoLabel3;
        public static Template HighscoreDemoLabel3
        {
            get
            {
#if UNITY_EDITOR
                if (_highscoreDemoLabel3 == null || _highscoreDemoLabel3.CurrentVersion != Template.Version)
#else
                if (_highscoreDemoLabel3 == null)
#endif
                {
                    _highscoreDemoLabel3 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _highscoreDemoLabel3.Name = "HighscoreDemoLabel3";
#endif
                    Delight.Label.AutoSizeProperty.SetDefault(_highscoreDemoLabel3, Delight.AutoSize.Default);
                    Delight.Label.FontColorProperty.SetDefault(_highscoreDemoLabel3, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Label.FontSizeProperty.SetDefault(_highscoreDemoLabel3, 22f);
                    Delight.Label.AlignmentProperty.SetDefault(_highscoreDemoLabel3, Delight.ElementAlignment.Right);
                    Delight.Label.FontColorProperty.SetStateDefault("Highlighted", _highscoreDemoLabel3, new UnityEngine.Color(0f, 0f, 0f, 1f));
                    Delight.Label.TextProperty.SetHasBinding(_highscoreDemoLabel3);
                }
                return _highscoreDemoLabel3;
            }
        }

        #endregion
    }

    #endregion
}
