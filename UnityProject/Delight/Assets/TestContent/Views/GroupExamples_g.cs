// Internal view logic generated from "GroupExamples.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class GroupExamples : UIView
    {
        #region Constructors

        public GroupExamples(View parent, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :
            base(parent, layoutParent, id, template ?? GroupExamplesTemplates.Default, initializer)
        {
            // constructing List (PlayerList)
            PlayerList = new List(this, this, "PlayerList", PlayerListTemplate);
            PlayerList.ItemSelected.RegisterHandler(this, "AttackModifierSelected");

            // binding <List Items="{player in @Players}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> {  }, new List<Func<BindableObject>> {  }) }, new BindingPath(new List<string> { "PlayerList", "Items" }, new List<Func<BindableObject>> { () => this, () => PlayerList }), () => PlayerList.Items = Models.Players, () => { }, false));

            // binding <List Width="{TestWidth}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "TestWidth" }, new List<Func<BindableObject>> { () => this }) }, new BindingPath(new List<string> { "PlayerList", "Width" }, new List<Func<BindableObject>> { () => this, () => PlayerList }), () => PlayerList.Width = TestWidth, () => { }, false));

            // binding <List Height="{TestWidth}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "TestWidth" }, new List<Func<BindableObject>> { () => this }) }, new BindingPath(new List<string> { "PlayerList", "Height" }, new List<Func<BindableObject>> { () => this, () => PlayerList }), () => PlayerList.Height = TestWidth, () => { }, false));

            // templates for PlayerList
            PlayerList.ContentTemplates.Add(new ContentTemplate(tiPlayer => 
            {
                var listItem1 = new ListItem(this, PlayerList.Content, "ListItem1", ListItem1Template);
                var buttonTest = new Label(this, listItem1.Content, "ButtonTest", ButtonTestTemplate);

                // binding <Label Text="{player.Name}">
                listItem1.Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "Item", "Name" }, new List<Func<BindableObject>> { () => tiPlayer, () => (tiPlayer.Item as Delight.Player) }) }, new BindingPath(new List<string> { "Text" }, new List<Func<BindableObject>> { () => buttonTest }), () => buttonTest.Text = (tiPlayer.Item as Delight.Player).Name, () => { }, false));
                listItem1.IsDynamic = true;
                listItem1.SetContentTemplateData(tiPlayer);
                return listItem1;
            }, typeof(ListItem), "ListItem1"));

            // constructing Button (Button1)
            Button1 = new Button(this, this, "Button1", Button1Template);
            Button1.Click.RegisterHandler(this, "SetWidth");
            this.AfterInitializeInternal();
        }

        public GroupExamples() : this(null)
        {
        }

        static GroupExamples()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(GroupExamplesTemplates.Default, dependencyProperties);

            dependencyProperties.Add(IsActive1Property);
            dependencyProperties.Add(IsActive2Property);
            dependencyProperties.Add(TestWidthProperty);
            dependencyProperties.Add(PlayerListProperty);
            dependencyProperties.Add(PlayerListTemplateProperty);
            dependencyProperties.Add(ListItem1Property);
            dependencyProperties.Add(ListItem1TemplateProperty);
            dependencyProperties.Add(ButtonTestProperty);
            dependencyProperties.Add(ButtonTestTemplateProperty);
            dependencyProperties.Add(Button1Property);
            dependencyProperties.Add(Button1TemplateProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<System.Boolean> IsActive1Property = new DependencyProperty<System.Boolean>("IsActive1");
        public System.Boolean IsActive1
        {
            get { return IsActive1Property.GetValue(this); }
            set { IsActive1Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> IsActive2Property = new DependencyProperty<System.Boolean>("IsActive2");
        public System.Boolean IsActive2
        {
            get { return IsActive2Property.GetValue(this); }
            set { IsActive2Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Delight.ElementSize> TestWidthProperty = new DependencyProperty<Delight.ElementSize>("TestWidth");
        public Delight.ElementSize TestWidth
        {
            get { return TestWidthProperty.GetValue(this); }
            set { TestWidthProperty.SetValue(this, value); }
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

        public readonly static DependencyProperty<Label> ButtonTestProperty = new DependencyProperty<Label>("ButtonTest");
        public Label ButtonTest
        {
            get { return ButtonTestProperty.GetValue(this); }
            set { ButtonTestProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> ButtonTestTemplateProperty = new DependencyProperty<Template>("ButtonTestTemplate");
        public Template ButtonTestTemplate
        {
            get { return ButtonTestTemplateProperty.GetValue(this); }
            set { ButtonTestTemplateProperty.SetValue(this, value); }
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

    public static class GroupExamplesTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return GroupExamples;
            }
        }

        private static Template _groupExamples;
        public static Template GroupExamples
        {
            get
            {
#if UNITY_EDITOR
                if (_groupExamples == null || _groupExamples.CurrentVersion != Template.Version)
#else
                if (_groupExamples == null)
#endif
                {
                    _groupExamples = new Template(UIViewTemplates.UIView);
#if UNITY_EDITOR
                    _groupExamples.Name = "GroupExamples";
#endif
                    Delight.GroupExamples.TestWidthProperty.SetDefault(_groupExamples, new ElementSize(0f, ElementSizeUnit.Pixels));
                    Delight.GroupExamples.PlayerListTemplateProperty.SetDefault(_groupExamples, GroupExamplesPlayerList);
                    Delight.GroupExamples.ListItem1TemplateProperty.SetDefault(_groupExamples, GroupExamplesListItem1);
                    Delight.GroupExamples.ButtonTestTemplateProperty.SetDefault(_groupExamples, GroupExamplesButtonTest);
                    Delight.GroupExamples.Button1TemplateProperty.SetDefault(_groupExamples, GroupExamplesButton1);
                }
                return _groupExamples;
            }
        }

        private static Template _groupExamplesPlayerList;
        public static Template GroupExamplesPlayerList
        {
            get
            {
#if UNITY_EDITOR
                if (_groupExamplesPlayerList == null || _groupExamplesPlayerList.CurrentVersion != Template.Version)
#else
                if (_groupExamplesPlayerList == null)
#endif
                {
                    _groupExamplesPlayerList = new Template(ListTemplates.List);
#if UNITY_EDITOR
                    _groupExamplesPlayerList.Name = "GroupExamplesPlayerList";
#endif
                    Delight.List.BackgroundColorProperty.SetDefault(_groupExamplesPlayerList, new UnityEngine.Color(0f, 1f, 0f, 1f));
                    Delight.List.SpacingProperty.SetDefault(_groupExamplesPlayerList, new ElementSize(5f, ElementSizeUnit.Pixels));
                    Delight.List.IsScrollableProperty.SetDefault(_groupExamplesPlayerList, false);
                    Delight.List.OrientationProperty.SetDefault(_groupExamplesPlayerList, Delight.ElementOrientation.Horizontal);
                    Delight.List.OverflowProperty.SetDefault(_groupExamplesPlayerList, Delight.OverflowMode.Wrap);
                    Delight.List.ContentAlignmentProperty.SetDefault(_groupExamplesPlayerList, Delight.ElementAlignment.Right);
                    Delight.List.DeselectAfterSelectProperty.SetDefault(_groupExamplesPlayerList, true);
                    Delight.List.ScaleProperty.SetDefault(_groupExamplesPlayerList, new Vector3(1f, 1f, 1f));
                    Delight.List.ItemsProperty.SetHasBinding(_groupExamplesPlayerList);
                    Delight.List.WidthProperty.SetHasBinding(_groupExamplesPlayerList);
                    Delight.List.HeightProperty.SetHasBinding(_groupExamplesPlayerList);
                    Delight.List.ScrollableRegionTemplateProperty.SetDefault(_groupExamplesPlayerList, GroupExamplesPlayerListScrollableRegion);
                }
                return _groupExamplesPlayerList;
            }
        }

        private static Template _groupExamplesPlayerListScrollableRegion;
        public static Template GroupExamplesPlayerListScrollableRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_groupExamplesPlayerListScrollableRegion == null || _groupExamplesPlayerListScrollableRegion.CurrentVersion != Template.Version)
#else
                if (_groupExamplesPlayerListScrollableRegion == null)
#endif
                {
                    _groupExamplesPlayerListScrollableRegion = new Template(ListTemplates.ListScrollableRegion);
#if UNITY_EDITOR
                    _groupExamplesPlayerListScrollableRegion.Name = "GroupExamplesPlayerListScrollableRegion";
#endif
                    Delight.ScrollableRegion.DisableInteractionScrollDeltaProperty.SetDefault(_groupExamplesPlayerListScrollableRegion, 4f);
                    Delight.ScrollableRegion.CanScrollHorizontallyProperty.SetDefault(_groupExamplesPlayerListScrollableRegion, false);
                    Delight.ScrollableRegion.CanScrollVerticallyProperty.SetDefault(_groupExamplesPlayerListScrollableRegion, false);
                    Delight.ScrollableRegion.HorizontalScrollbarVisibilityProperty.SetDefault(_groupExamplesPlayerListScrollableRegion, Delight.ScrollbarVisibilityMode.Remove);
                    Delight.ScrollableRegion.VerticalScrollbarVisibilityProperty.SetDefault(_groupExamplesPlayerListScrollableRegion, Delight.ScrollbarVisibilityMode.Remove);
                    Delight.ScrollableRegion.ContentRegionTemplateProperty.SetDefault(_groupExamplesPlayerListScrollableRegion, GroupExamplesPlayerListScrollableRegionContentRegion);
                    Delight.ScrollableRegion.HorizontalScrollbarTemplateProperty.SetDefault(_groupExamplesPlayerListScrollableRegion, GroupExamplesPlayerListScrollableRegionHorizontalScrollbar);
                    Delight.ScrollableRegion.VerticalScrollbarTemplateProperty.SetDefault(_groupExamplesPlayerListScrollableRegion, GroupExamplesPlayerListScrollableRegionVerticalScrollbar);
                }
                return _groupExamplesPlayerListScrollableRegion;
            }
        }

        private static Template _groupExamplesPlayerListScrollableRegionContentRegion;
        public static Template GroupExamplesPlayerListScrollableRegionContentRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_groupExamplesPlayerListScrollableRegionContentRegion == null || _groupExamplesPlayerListScrollableRegionContentRegion.CurrentVersion != Template.Version)
#else
                if (_groupExamplesPlayerListScrollableRegionContentRegion == null)
#endif
                {
                    _groupExamplesPlayerListScrollableRegionContentRegion = new Template(ListTemplates.ListScrollableRegionContentRegion);
#if UNITY_EDITOR
                    _groupExamplesPlayerListScrollableRegionContentRegion.Name = "GroupExamplesPlayerListScrollableRegionContentRegion";
#endif
                }
                return _groupExamplesPlayerListScrollableRegionContentRegion;
            }
        }

        private static Template _groupExamplesPlayerListScrollableRegionHorizontalScrollbar;
        public static Template GroupExamplesPlayerListScrollableRegionHorizontalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_groupExamplesPlayerListScrollableRegionHorizontalScrollbar == null || _groupExamplesPlayerListScrollableRegionHorizontalScrollbar.CurrentVersion != Template.Version)
#else
                if (_groupExamplesPlayerListScrollableRegionHorizontalScrollbar == null)
#endif
                {
                    _groupExamplesPlayerListScrollableRegionHorizontalScrollbar = new Template(ListTemplates.ListScrollableRegionHorizontalScrollbar);
#if UNITY_EDITOR
                    _groupExamplesPlayerListScrollableRegionHorizontalScrollbar.Name = "GroupExamplesPlayerListScrollableRegionHorizontalScrollbar";
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_groupExamplesPlayerListScrollableRegionHorizontalScrollbar, GroupExamplesPlayerListScrollableRegionHorizontalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_groupExamplesPlayerListScrollableRegionHorizontalScrollbar, GroupExamplesPlayerListScrollableRegionHorizontalScrollbarHandle);
                }
                return _groupExamplesPlayerListScrollableRegionHorizontalScrollbar;
            }
        }

        private static Template _groupExamplesPlayerListScrollableRegionHorizontalScrollbarBar;
        public static Template GroupExamplesPlayerListScrollableRegionHorizontalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_groupExamplesPlayerListScrollableRegionHorizontalScrollbarBar == null || _groupExamplesPlayerListScrollableRegionHorizontalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_groupExamplesPlayerListScrollableRegionHorizontalScrollbarBar == null)
#endif
                {
                    _groupExamplesPlayerListScrollableRegionHorizontalScrollbarBar = new Template(ListTemplates.ListScrollableRegionHorizontalScrollbarBar);
#if UNITY_EDITOR
                    _groupExamplesPlayerListScrollableRegionHorizontalScrollbarBar.Name = "GroupExamplesPlayerListScrollableRegionHorizontalScrollbarBar";
#endif
                }
                return _groupExamplesPlayerListScrollableRegionHorizontalScrollbarBar;
            }
        }

        private static Template _groupExamplesPlayerListScrollableRegionHorizontalScrollbarHandle;
        public static Template GroupExamplesPlayerListScrollableRegionHorizontalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_groupExamplesPlayerListScrollableRegionHorizontalScrollbarHandle == null || _groupExamplesPlayerListScrollableRegionHorizontalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_groupExamplesPlayerListScrollableRegionHorizontalScrollbarHandle == null)
#endif
                {
                    _groupExamplesPlayerListScrollableRegionHorizontalScrollbarHandle = new Template(ListTemplates.ListScrollableRegionHorizontalScrollbarHandle);
#if UNITY_EDITOR
                    _groupExamplesPlayerListScrollableRegionHorizontalScrollbarHandle.Name = "GroupExamplesPlayerListScrollableRegionHorizontalScrollbarHandle";
#endif
                }
                return _groupExamplesPlayerListScrollableRegionHorizontalScrollbarHandle;
            }
        }

        private static Template _groupExamplesPlayerListScrollableRegionVerticalScrollbar;
        public static Template GroupExamplesPlayerListScrollableRegionVerticalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_groupExamplesPlayerListScrollableRegionVerticalScrollbar == null || _groupExamplesPlayerListScrollableRegionVerticalScrollbar.CurrentVersion != Template.Version)
#else
                if (_groupExamplesPlayerListScrollableRegionVerticalScrollbar == null)
#endif
                {
                    _groupExamplesPlayerListScrollableRegionVerticalScrollbar = new Template(ListTemplates.ListScrollableRegionVerticalScrollbar);
#if UNITY_EDITOR
                    _groupExamplesPlayerListScrollableRegionVerticalScrollbar.Name = "GroupExamplesPlayerListScrollableRegionVerticalScrollbar";
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_groupExamplesPlayerListScrollableRegionVerticalScrollbar, GroupExamplesPlayerListScrollableRegionVerticalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_groupExamplesPlayerListScrollableRegionVerticalScrollbar, GroupExamplesPlayerListScrollableRegionVerticalScrollbarHandle);
                }
                return _groupExamplesPlayerListScrollableRegionVerticalScrollbar;
            }
        }

        private static Template _groupExamplesPlayerListScrollableRegionVerticalScrollbarBar;
        public static Template GroupExamplesPlayerListScrollableRegionVerticalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_groupExamplesPlayerListScrollableRegionVerticalScrollbarBar == null || _groupExamplesPlayerListScrollableRegionVerticalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_groupExamplesPlayerListScrollableRegionVerticalScrollbarBar == null)
#endif
                {
                    _groupExamplesPlayerListScrollableRegionVerticalScrollbarBar = new Template(ListTemplates.ListScrollableRegionVerticalScrollbarBar);
#if UNITY_EDITOR
                    _groupExamplesPlayerListScrollableRegionVerticalScrollbarBar.Name = "GroupExamplesPlayerListScrollableRegionVerticalScrollbarBar";
#endif
                }
                return _groupExamplesPlayerListScrollableRegionVerticalScrollbarBar;
            }
        }

        private static Template _groupExamplesPlayerListScrollableRegionVerticalScrollbarHandle;
        public static Template GroupExamplesPlayerListScrollableRegionVerticalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_groupExamplesPlayerListScrollableRegionVerticalScrollbarHandle == null || _groupExamplesPlayerListScrollableRegionVerticalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_groupExamplesPlayerListScrollableRegionVerticalScrollbarHandle == null)
#endif
                {
                    _groupExamplesPlayerListScrollableRegionVerticalScrollbarHandle = new Template(ListTemplates.ListScrollableRegionVerticalScrollbarHandle);
#if UNITY_EDITOR
                    _groupExamplesPlayerListScrollableRegionVerticalScrollbarHandle.Name = "GroupExamplesPlayerListScrollableRegionVerticalScrollbarHandle";
#endif
                }
                return _groupExamplesPlayerListScrollableRegionVerticalScrollbarHandle;
            }
        }

        private static Template _groupExamplesListItem1;
        public static Template GroupExamplesListItem1
        {
            get
            {
#if UNITY_EDITOR
                if (_groupExamplesListItem1 == null || _groupExamplesListItem1.CurrentVersion != Template.Version)
#else
                if (_groupExamplesListItem1 == null)
#endif
                {
                    _groupExamplesListItem1 = new Template(ListItemTemplates.ListItem);
#if UNITY_EDITOR
                    _groupExamplesListItem1.Name = "GroupExamplesListItem1";
#endif
                    Delight.ListItem.WidthProperty.SetDefault(_groupExamplesListItem1, new ElementSize(120f, ElementSizeUnit.Pixels));
                    Delight.ListItem.HeightProperty.SetDefault(_groupExamplesListItem1, new ElementSize(100f, ElementSizeUnit.Pixels));
                    Delight.ListItem.BackgroundColorProperty.SetDefault(_groupExamplesListItem1, new UnityEngine.Color(0f, 0f, 1f, 1f));
                }
                return _groupExamplesListItem1;
            }
        }

        private static Template _groupExamplesButtonTest;
        public static Template GroupExamplesButtonTest
        {
            get
            {
#if UNITY_EDITOR
                if (_groupExamplesButtonTest == null || _groupExamplesButtonTest.CurrentVersion != Template.Version)
#else
                if (_groupExamplesButtonTest == null)
#endif
                {
                    _groupExamplesButtonTest = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _groupExamplesButtonTest.Name = "GroupExamplesButtonTest";
#endif
                    Delight.Label.WidthProperty.SetDefault(_groupExamplesButtonTest, new ElementSize(100f, ElementSizeUnit.Pixels));
                    Delight.Label.TextProperty.SetHasBinding(_groupExamplesButtonTest);
                }
                return _groupExamplesButtonTest;
            }
        }

        private static Template _groupExamplesButton1;
        public static Template GroupExamplesButton1
        {
            get
            {
#if UNITY_EDITOR
                if (_groupExamplesButton1 == null || _groupExamplesButton1.CurrentVersion != Template.Version)
#else
                if (_groupExamplesButton1 == null)
#endif
                {
                    _groupExamplesButton1 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _groupExamplesButton1.Name = "GroupExamplesButton1";
#endif
                    Delight.Button.AlignmentProperty.SetDefault(_groupExamplesButton1, Delight.ElementAlignment.TopLeft);
                    Delight.Button.OffsetProperty.SetDefault(_groupExamplesButton1, new ElementMargin(new ElementSize(10f, ElementSizeUnit.Pixels), new ElementSize(10f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels)));
                    Delight.Button.LabelTemplateProperty.SetDefault(_groupExamplesButton1, GroupExamplesButton1Label);
                }
                return _groupExamplesButton1;
            }
        }

        private static Template _groupExamplesButton1Label;
        public static Template GroupExamplesButton1Label
        {
            get
            {
#if UNITY_EDITOR
                if (_groupExamplesButton1Label == null || _groupExamplesButton1Label.CurrentVersion != Template.Version)
#else
                if (_groupExamplesButton1Label == null)
#endif
                {
                    _groupExamplesButton1Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _groupExamplesButton1Label.Name = "GroupExamplesButton1Label";
#endif
                    Delight.Label.TextProperty.SetDefault(_groupExamplesButton1Label, "SetWidth");
                }
                return _groupExamplesButton1Label;
            }
        }

        #endregion
    }

    #endregion
}
