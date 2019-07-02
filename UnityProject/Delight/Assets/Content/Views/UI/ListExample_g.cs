// Internal view logic generated from "ListExample.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class ListExample : LayoutRoot
    {
        #region Constructors

        public ListExample(View parent, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :
            base(parent, layoutParent, id, template ?? ListExampleTemplates.Default, initializer)
        {
            // constructing Group (Group1)
            Group1 = new Group(this, this, "Group1", Group1Template);
            Group2 = new Group(this, Group1.Content, "Group2", Group2Template);
            Button1 = new Button(this, Group2.Content, "Button1", Button1Template);
            if (Button1.Click == null) Button1.Click = new ViewAction();
            Button1.Click.RegisterHandler(ResolveActionHandler(this, "Add"));
            Button2 = new Button(this, Group2.Content, "Button2", Button2Template);
            if (Button2.Click == null) Button2.Click = new ViewAction();
            Button2.Click.RegisterHandler(ResolveActionHandler(this, "Remove"));
            PlayerList = new List(this, Group1.Content, "PlayerList", PlayerListTemplate);

            // binding <List Items="{player in Players}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "Players" }, new List<Func<BindableObject>> { () => this }) }, new BindingPath(new List<string> { "PlayerList", "Items" }, new List<Func<BindableObject>> { () => this, () => PlayerList }), () => PlayerList.Items = Players, () => { }, false));

            // Template for PlayerList
            PlayerList.ContentTemplate = new ContentTemplate(tiPlayer => 
            {
                var listItem1 = new ListItem(this, PlayerList.Content, "ListItem1", ListItem1Template);
                var image1 = new Image(this, listItem1.Content, "Image1", Image1Template);

                // binding <Image Color="{player.Color}">
                listItem1.Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "Item", "Color" }, new List<Func<BindableObject>> { () => tiPlayer, () => (tiPlayer.Item as Delight.Player) }) }, new BindingPath(new List<string> { "Color" }, new List<Func<BindableObject>> { () => image1 }), () => image1.Color = (tiPlayer.Item as Delight.Player).Color, () => { }, false));
                var label1 = new Label(this, listItem1.Content, "Label1", Label1Template);

                // binding <Label Text="{player.Name}">
                listItem1.Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "Item", "Name" }, new List<Func<BindableObject>> { () => tiPlayer, () => (tiPlayer.Item as Delight.Player) }) }, new BindingPath(new List<string> { "Text" }, new List<Func<BindableObject>> { () => label1 }), () => label1.Text = (tiPlayer.Item as Delight.Player).Name, () => { }, false));
                listItem1.ContentTemplateData = tiPlayer;
                return listItem1;
            });
            this.AfterInitializeInternal();
        }

        public ListExample() : this(null)
        {
        }

        static ListExample()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(ListExampleTemplates.Default, dependencyProperties);

            dependencyProperties.Add(PlayersProperty);
            dependencyProperties.Add(Group1Property);
            dependencyProperties.Add(Group1TemplateProperty);
            dependencyProperties.Add(Group2Property);
            dependencyProperties.Add(Group2TemplateProperty);
            dependencyProperties.Add(Button1Property);
            dependencyProperties.Add(Button1TemplateProperty);
            dependencyProperties.Add(Button2Property);
            dependencyProperties.Add(Button2TemplateProperty);
            dependencyProperties.Add(PlayerListProperty);
            dependencyProperties.Add(PlayerListTemplateProperty);
            dependencyProperties.Add(ListItem1Property);
            dependencyProperties.Add(ListItem1TemplateProperty);
            dependencyProperties.Add(Image1Property);
            dependencyProperties.Add(Image1TemplateProperty);
            dependencyProperties.Add(Label1Property);
            dependencyProperties.Add(Label1TemplateProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<Delight.BindableCollection<Delight.Player>> PlayersProperty = new DependencyProperty<Delight.BindableCollection<Delight.Player>>("Players");
        public Delight.BindableCollection<Delight.Player> Players
        {
            get { return PlayersProperty.GetValue(this); }
            set { PlayersProperty.SetValue(this, value); }
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

        public readonly static DependencyProperty<List> PlayerListProperty = new DependencyProperty<List>("PlayerList");
        public List PlayerList
        {
            get { return PlayerListProperty.GetValue(this); }
            set { PlayerListProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> PlayerListTemplateProperty = new DependencyProperty<Template>("PlayerListTemplate");
        public Template PlayerListTemplate
        {
            get { return PlayerListTemplateProperty.GetValue(this); }
            set { PlayerListTemplateProperty.SetValue(this, value); }
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

        #endregion
    }

    #region Data Templates

    public static class ListExampleTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return ListExample;
            }
        }

        private static Template _listExample;
        public static Template ListExample
        {
            get
            {
#if UNITY_EDITOR
                if (_listExample == null || _listExample.CurrentVersion != Template.Version)
#else
                if (_listExample == null)
#endif
                {
                    _listExample = new Template(LayoutRootTemplates.LayoutRoot);
#if UNITY_EDITOR
                    _listExample.Name = "ListExample";
#endif
                    Delight.ListExample.Group1TemplateProperty.SetDefault(_listExample, ListExampleGroup1);
                    Delight.ListExample.Group2TemplateProperty.SetDefault(_listExample, ListExampleGroup2);
                    Delight.ListExample.Button1TemplateProperty.SetDefault(_listExample, ListExampleButton1);
                    Delight.ListExample.Button2TemplateProperty.SetDefault(_listExample, ListExampleButton2);
                    Delight.ListExample.PlayerListTemplateProperty.SetDefault(_listExample, ListExamplePlayerList);
                    Delight.ListExample.ListItem1TemplateProperty.SetDefault(_listExample, ListExampleListItem1);
                    Delight.ListExample.Image1TemplateProperty.SetDefault(_listExample, ListExampleImage1);
                    Delight.ListExample.Label1TemplateProperty.SetDefault(_listExample, ListExampleLabel1);
                }
                return _listExample;
            }
        }

        private static Template _listExampleGroup1;
        public static Template ListExampleGroup1
        {
            get
            {
#if UNITY_EDITOR
                if (_listExampleGroup1 == null || _listExampleGroup1.CurrentVersion != Template.Version)
#else
                if (_listExampleGroup1 == null)
#endif
                {
                    _listExampleGroup1 = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _listExampleGroup1.Name = "ListExampleGroup1";
#endif
                    Delight.Group.OrientationProperty.SetDefault(_listExampleGroup1, Delight.ElementOrientation.Horizontal);
                    Delight.Group.SpacingProperty.SetDefault(_listExampleGroup1, new ElementSize(10f, ElementSizeUnit.Pixels));
                }
                return _listExampleGroup1;
            }
        }

        private static Template _listExampleGroup2;
        public static Template ListExampleGroup2
        {
            get
            {
#if UNITY_EDITOR
                if (_listExampleGroup2 == null || _listExampleGroup2.CurrentVersion != Template.Version)
#else
                if (_listExampleGroup2 == null)
#endif
                {
                    _listExampleGroup2 = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _listExampleGroup2.Name = "ListExampleGroup2";
#endif
                    Delight.Group.SpacingProperty.SetDefault(_listExampleGroup2, new ElementSize(10f, ElementSizeUnit.Pixels));
                    Delight.Group.WidthProperty.SetDefault(_listExampleGroup2, new ElementSize(100f, ElementSizeUnit.Pixels));
                }
                return _listExampleGroup2;
            }
        }

        private static Template _listExampleButton1;
        public static Template ListExampleButton1
        {
            get
            {
#if UNITY_EDITOR
                if (_listExampleButton1 == null || _listExampleButton1.CurrentVersion != Template.Version)
#else
                if (_listExampleButton1 == null)
#endif
                {
                    _listExampleButton1 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _listExampleButton1.Name = "ListExampleButton1";
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_listExampleButton1, ListExampleButton1Label);
                }
                return _listExampleButton1;
            }
        }

        private static Template _listExampleButton1Label;
        public static Template ListExampleButton1Label
        {
            get
            {
#if UNITY_EDITOR
                if (_listExampleButton1Label == null || _listExampleButton1Label.CurrentVersion != Template.Version)
#else
                if (_listExampleButton1Label == null)
#endif
                {
                    _listExampleButton1Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _listExampleButton1Label.Name = "ListExampleButton1Label";
#endif
                    Delight.Label.TextProperty.SetDefault(_listExampleButton1Label, "Add");
                }
                return _listExampleButton1Label;
            }
        }

        private static Template _listExampleButton2;
        public static Template ListExampleButton2
        {
            get
            {
#if UNITY_EDITOR
                if (_listExampleButton2 == null || _listExampleButton2.CurrentVersion != Template.Version)
#else
                if (_listExampleButton2 == null)
#endif
                {
                    _listExampleButton2 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _listExampleButton2.Name = "ListExampleButton2";
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_listExampleButton2, ListExampleButton2Label);
                }
                return _listExampleButton2;
            }
        }

        private static Template _listExampleButton2Label;
        public static Template ListExampleButton2Label
        {
            get
            {
#if UNITY_EDITOR
                if (_listExampleButton2Label == null || _listExampleButton2Label.CurrentVersion != Template.Version)
#else
                if (_listExampleButton2Label == null)
#endif
                {
                    _listExampleButton2Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _listExampleButton2Label.Name = "ListExampleButton2Label";
#endif
                    Delight.Label.TextProperty.SetDefault(_listExampleButton2Label, "Remove");
                }
                return _listExampleButton2Label;
            }
        }

        private static Template _listExamplePlayerList;
        public static Template ListExamplePlayerList
        {
            get
            {
#if UNITY_EDITOR
                if (_listExamplePlayerList == null || _listExamplePlayerList.CurrentVersion != Template.Version)
#else
                if (_listExamplePlayerList == null)
#endif
                {
                    _listExamplePlayerList = new Template(ListTemplates.List);
#if UNITY_EDITOR
                    _listExamplePlayerList.Name = "ListExamplePlayerList";
#endif
                    Delight.List.WidthProperty.SetDefault(_listExamplePlayerList, new ElementSize(500f, ElementSizeUnit.Pixels));
                    Delight.List.HeightProperty.SetDefault(_listExamplePlayerList, new ElementSize(500f, ElementSizeUnit.Pixels));
                    Delight.List.BackgroundColorProperty.SetDefault(_listExamplePlayerList, new UnityEngine.Color(0f, 1f, 0f, 1f));
                    Delight.List.SpacingProperty.SetDefault(_listExamplePlayerList, new ElementSize(5f, ElementSizeUnit.Pixels));
                    Delight.List.IsScrollableProperty.SetDefault(_listExamplePlayerList, true);
                    Delight.List.OverflowProperty.SetDefault(_listExamplePlayerList, Delight.OverflowMode.Wrap);
                    Delight.List.OrientationProperty.SetDefault(_listExamplePlayerList, Delight.ElementOrientation.Horizontal);
                    Delight.List.ItemsProperty.SetHasBinding(_listExamplePlayerList);
                    Delight.List.ScrollableRegionTemplateProperty.SetDefault(_listExamplePlayerList, ListExamplePlayerListScrollableRegion);
                }
                return _listExamplePlayerList;
            }
        }

        private static Template _listExamplePlayerListScrollableRegion;
        public static Template ListExamplePlayerListScrollableRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_listExamplePlayerListScrollableRegion == null || _listExamplePlayerListScrollableRegion.CurrentVersion != Template.Version)
#else
                if (_listExamplePlayerListScrollableRegion == null)
#endif
                {
                    _listExamplePlayerListScrollableRegion = new Template(ListTemplates.ListScrollableRegion);
#if UNITY_EDITOR
                    _listExamplePlayerListScrollableRegion.Name = "ListExamplePlayerListScrollableRegion";
#endif
                    Delight.ScrollableRegion.ContentRegionTemplateProperty.SetDefault(_listExamplePlayerListScrollableRegion, ListExamplePlayerListScrollableRegionContentRegion);
                    Delight.ScrollableRegion.HorizontalScrollbarTemplateProperty.SetDefault(_listExamplePlayerListScrollableRegion, ListExamplePlayerListScrollableRegionHorizontalScrollbar);
                    Delight.ScrollableRegion.VerticalScrollbarTemplateProperty.SetDefault(_listExamplePlayerListScrollableRegion, ListExamplePlayerListScrollableRegionVerticalScrollbar);
                }
                return _listExamplePlayerListScrollableRegion;
            }
        }

        private static Template _listExamplePlayerListScrollableRegionContentRegion;
        public static Template ListExamplePlayerListScrollableRegionContentRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_listExamplePlayerListScrollableRegionContentRegion == null || _listExamplePlayerListScrollableRegionContentRegion.CurrentVersion != Template.Version)
#else
                if (_listExamplePlayerListScrollableRegionContentRegion == null)
#endif
                {
                    _listExamplePlayerListScrollableRegionContentRegion = new Template(ListTemplates.ListScrollableRegionContentRegion);
#if UNITY_EDITOR
                    _listExamplePlayerListScrollableRegionContentRegion.Name = "ListExamplePlayerListScrollableRegionContentRegion";
#endif
                }
                return _listExamplePlayerListScrollableRegionContentRegion;
            }
        }

        private static Template _listExamplePlayerListScrollableRegionHorizontalScrollbar;
        public static Template ListExamplePlayerListScrollableRegionHorizontalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_listExamplePlayerListScrollableRegionHorizontalScrollbar == null || _listExamplePlayerListScrollableRegionHorizontalScrollbar.CurrentVersion != Template.Version)
#else
                if (_listExamplePlayerListScrollableRegionHorizontalScrollbar == null)
#endif
                {
                    _listExamplePlayerListScrollableRegionHorizontalScrollbar = new Template(ListTemplates.ListScrollableRegionHorizontalScrollbar);
#if UNITY_EDITOR
                    _listExamplePlayerListScrollableRegionHorizontalScrollbar.Name = "ListExamplePlayerListScrollableRegionHorizontalScrollbar";
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_listExamplePlayerListScrollableRegionHorizontalScrollbar, ListExamplePlayerListScrollableRegionHorizontalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_listExamplePlayerListScrollableRegionHorizontalScrollbar, ListExamplePlayerListScrollableRegionHorizontalScrollbarHandle);
                }
                return _listExamplePlayerListScrollableRegionHorizontalScrollbar;
            }
        }

        private static Template _listExamplePlayerListScrollableRegionHorizontalScrollbarBar;
        public static Template ListExamplePlayerListScrollableRegionHorizontalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_listExamplePlayerListScrollableRegionHorizontalScrollbarBar == null || _listExamplePlayerListScrollableRegionHorizontalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_listExamplePlayerListScrollableRegionHorizontalScrollbarBar == null)
#endif
                {
                    _listExamplePlayerListScrollableRegionHorizontalScrollbarBar = new Template(ListTemplates.ListScrollableRegionHorizontalScrollbarBar);
#if UNITY_EDITOR
                    _listExamplePlayerListScrollableRegionHorizontalScrollbarBar.Name = "ListExamplePlayerListScrollableRegionHorizontalScrollbarBar";
#endif
                }
                return _listExamplePlayerListScrollableRegionHorizontalScrollbarBar;
            }
        }

        private static Template _listExamplePlayerListScrollableRegionHorizontalScrollbarHandle;
        public static Template ListExamplePlayerListScrollableRegionHorizontalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_listExamplePlayerListScrollableRegionHorizontalScrollbarHandle == null || _listExamplePlayerListScrollableRegionHorizontalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_listExamplePlayerListScrollableRegionHorizontalScrollbarHandle == null)
#endif
                {
                    _listExamplePlayerListScrollableRegionHorizontalScrollbarHandle = new Template(ListTemplates.ListScrollableRegionHorizontalScrollbarHandle);
#if UNITY_EDITOR
                    _listExamplePlayerListScrollableRegionHorizontalScrollbarHandle.Name = "ListExamplePlayerListScrollableRegionHorizontalScrollbarHandle";
#endif
                }
                return _listExamplePlayerListScrollableRegionHorizontalScrollbarHandle;
            }
        }

        private static Template _listExamplePlayerListScrollableRegionVerticalScrollbar;
        public static Template ListExamplePlayerListScrollableRegionVerticalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_listExamplePlayerListScrollableRegionVerticalScrollbar == null || _listExamplePlayerListScrollableRegionVerticalScrollbar.CurrentVersion != Template.Version)
#else
                if (_listExamplePlayerListScrollableRegionVerticalScrollbar == null)
#endif
                {
                    _listExamplePlayerListScrollableRegionVerticalScrollbar = new Template(ListTemplates.ListScrollableRegionVerticalScrollbar);
#if UNITY_EDITOR
                    _listExamplePlayerListScrollableRegionVerticalScrollbar.Name = "ListExamplePlayerListScrollableRegionVerticalScrollbar";
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_listExamplePlayerListScrollableRegionVerticalScrollbar, ListExamplePlayerListScrollableRegionVerticalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_listExamplePlayerListScrollableRegionVerticalScrollbar, ListExamplePlayerListScrollableRegionVerticalScrollbarHandle);
                }
                return _listExamplePlayerListScrollableRegionVerticalScrollbar;
            }
        }

        private static Template _listExamplePlayerListScrollableRegionVerticalScrollbarBar;
        public static Template ListExamplePlayerListScrollableRegionVerticalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_listExamplePlayerListScrollableRegionVerticalScrollbarBar == null || _listExamplePlayerListScrollableRegionVerticalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_listExamplePlayerListScrollableRegionVerticalScrollbarBar == null)
#endif
                {
                    _listExamplePlayerListScrollableRegionVerticalScrollbarBar = new Template(ListTemplates.ListScrollableRegionVerticalScrollbarBar);
#if UNITY_EDITOR
                    _listExamplePlayerListScrollableRegionVerticalScrollbarBar.Name = "ListExamplePlayerListScrollableRegionVerticalScrollbarBar";
#endif
                }
                return _listExamplePlayerListScrollableRegionVerticalScrollbarBar;
            }
        }

        private static Template _listExamplePlayerListScrollableRegionVerticalScrollbarHandle;
        public static Template ListExamplePlayerListScrollableRegionVerticalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_listExamplePlayerListScrollableRegionVerticalScrollbarHandle == null || _listExamplePlayerListScrollableRegionVerticalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_listExamplePlayerListScrollableRegionVerticalScrollbarHandle == null)
#endif
                {
                    _listExamplePlayerListScrollableRegionVerticalScrollbarHandle = new Template(ListTemplates.ListScrollableRegionVerticalScrollbarHandle);
#if UNITY_EDITOR
                    _listExamplePlayerListScrollableRegionVerticalScrollbarHandle.Name = "ListExamplePlayerListScrollableRegionVerticalScrollbarHandle";
#endif
                }
                return _listExamplePlayerListScrollableRegionVerticalScrollbarHandle;
            }
        }

        private static Template _listExampleListItem1;
        public static Template ListExampleListItem1
        {
            get
            {
#if UNITY_EDITOR
                if (_listExampleListItem1 == null || _listExampleListItem1.CurrentVersion != Template.Version)
#else
                if (_listExampleListItem1 == null)
#endif
                {
                    _listExampleListItem1 = new Template(ListItemTemplates.ListItem);
#if UNITY_EDITOR
                    _listExampleListItem1.Name = "ListExampleListItem1";
#endif
                    Delight.ListItem.WidthProperty.SetDefault(_listExampleListItem1, new ElementSize(100f, ElementSizeUnit.Pixels));
                    Delight.ListItem.HeightProperty.SetDefault(_listExampleListItem1, new ElementSize(100f, ElementSizeUnit.Pixels));
                }
                return _listExampleListItem1;
            }
        }

        private static Template _listExampleImage1;
        public static Template ListExampleImage1
        {
            get
            {
#if UNITY_EDITOR
                if (_listExampleImage1 == null || _listExampleImage1.CurrentVersion != Template.Version)
#else
                if (_listExampleImage1 == null)
#endif
                {
                    _listExampleImage1 = new Template(ImageTemplates.Image);
#if UNITY_EDITOR
                    _listExampleImage1.Name = "ListExampleImage1";
#endif
                    Delight.Image.MarginProperty.SetDefault(_listExampleImage1, new ElementMargin(new ElementSize(5f, ElementSizeUnit.Pixels)));
                    Delight.Image.ColorProperty.SetHasBinding(_listExampleImage1);
                }
                return _listExampleImage1;
            }
        }

        private static Template _listExampleLabel1;
        public static Template ListExampleLabel1
        {
            get
            {
#if UNITY_EDITOR
                if (_listExampleLabel1 == null || _listExampleLabel1.CurrentVersion != Template.Version)
#else
                if (_listExampleLabel1 == null)
#endif
                {
                    _listExampleLabel1 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _listExampleLabel1.Name = "ListExampleLabel1";
#endif
                    Delight.Label.AutoSizeProperty.SetDefault(_listExampleLabel1, Delight.AutoSize.Default);
                    Delight.Label.TextProperty.SetHasBinding(_listExampleLabel1);
                }
                return _listExampleLabel1;
            }
        }

        #endregion
    }

    #endregion
}
