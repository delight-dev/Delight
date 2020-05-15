// Internal view logic generated from "ModelBindingTest.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class ModelBindingTest : LayoutRoot
    {
        #region Constructors

        public ModelBindingTest(View parent, View layoutParent = null, string id = null, Template template = null, bool deferInitialization = false) :
            base(parent, layoutParent, id, template ?? ModelBindingTestTemplates.Default, deferInitialization)
        {
            if (deferInitialization)
                return;

            // constructing Group (Group1)
            Group1 = new Group(this, this, "Group1", Group1Template);
            Group2 = new Group(this, Group1.Content, "Group2", Group2Template);
            Button1 = new Button(this, Group2.Content, "Button1", Button1Template);
            Button1.Click.RegisterHandler(this, "Test1");
            Button2 = new Button(this, Group2.Content, "Button2", Button2Template);
            Button2.Click.RegisterHandler(this, "Add");
            Button3 = new Button(this, Group2.Content, "Button3", Button3Template);
            Button3.Click.RegisterHandler(this, "Remove");
            Label1 = new Label(this, Group2.Content, "Label1", Label1Template);

            // binding <Label Text="{@Loc.Greeting1}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "Greeting1", "Label" }, new List<Func<BindableObject>> { () => Models.Loc, () => Models.Loc["Greeting1"] }) }, new BindingPath(new List<string> { "Label1", "Text" }, new List<Func<BindableObject>> { () => this, () => Label1 }), () => Label1.Text = Models.Loc["Greeting1"].Label, () => { }, false));
            Label2 = new Label(this, Group2.Content, "Label2", Label2Template);

            // binding <Label Text="{@Loc.Greeting2}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "Greeting2", "Label" }, new List<Func<BindableObject>> { () => Models.Loc, () => Models.Loc["Greeting2"] }) }, new BindingPath(new List<string> { "Label2", "Text" }, new List<Func<BindableObject>> { () => this, () => Label2 }), () => Label2.Text = Models.Loc["Greeting2"].Label, () => { }, false));
            PlayerList = new List(this, Group1.Content, "PlayerList", PlayerListTemplate);

            // binding <List Items="{player in @Players}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> {  }, new List<Func<BindableObject>> {  }) }, new BindingPath(new List<string> { "PlayerList", "Items" }, new List<Func<BindableObject>> { () => this, () => PlayerList }), () => PlayerList.Items = Models.Players, () => { }, false));

            // templates for PlayerList
            PlayerList.ContentTemplates.Add(new ContentTemplate(tiPlayer => 
            {
                var playerListContent = new ListItem(this, PlayerList.Content, "PlayerListContent", PlayerListContentTemplate);
                var group3 = new Group(this, playerListContent.Content, "Group3", Group3Template);
                var label3 = new Label(this, group3.Content, "Label3", Label3Template);

                // binding <Label Text="{player.Name}">
                playerListContent.Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "Item", "Name" }, new List<Func<BindableObject>> { () => tiPlayer, () => (tiPlayer.Item as Delight.Player) }) }, new BindingPath(new List<string> { "Text" }, new List<Func<BindableObject>> { () => label3 }), () => label3.Text = (tiPlayer.Item as Delight.Player).Name, () => { }, false));
                var achievementsList = new List(this, group3.Content, "AchievementsList", AchievementsListTemplate);
                achievementsList.ItemSelected.RegisterHandler(this, "AchievementSelectionChanged");

                // binding <List Items="{achievement in player.Achievements}">
                playerListContent.Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "Item", "Achievements" }, new List<Func<BindableObject>> { () => tiPlayer, () => (tiPlayer.Item as Delight.Player) }) }, new BindingPath(new List<string> { "Items" }, new List<Func<BindableObject>> { () => achievementsList }), () => achievementsList.Items = (tiPlayer.Item as Delight.Player).Achievements, () => { }, false));

                // templates for achievementsList
                achievementsList.ContentTemplates.Add(new ContentTemplate(tiAchievement => 
                {
                    var achievementsListContent = new ListItem(this, achievementsList.Content, "AchievementsListContent", AchievementsListContentTemplate);
                    var label4 = new Label(this, achievementsListContent.Content, "Label4", Label4Template);

                    // binding <Label Text="{achievement.Title}">
                    achievementsListContent.Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "Item", "Title" }, new List<Func<BindableObject>> { () => tiAchievement, () => (tiAchievement.Item as Delight.Achievement) }) }, new BindingPath(new List<string> { "Text" }, new List<Func<BindableObject>> { () => label4 }), () => label4.Text = (tiAchievement.Item as Delight.Achievement).Title, () => { }, false));
                    achievementsListContent.IsDynamic = true;
                    achievementsListContent.SetContentTemplateData(tiAchievement);
                    return achievementsListContent;
                }, typeof(ListItem), "AchievementsListContent"));
                playerListContent.IsDynamic = true;
                playerListContent.SetContentTemplateData(tiPlayer);
                return playerListContent;
            }, typeof(ListItem), "PlayerListContent"));
            this.AfterInitializeInternal();
        }

        public ModelBindingTest() : this(null)
        {
        }

        static ModelBindingTest()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(ModelBindingTestTemplates.Default, dependencyProperties);

            dependencyProperties.Add(SomeParentPropertyProperty);
            dependencyProperties.Add(Group1Property);
            dependencyProperties.Add(Group1TemplateProperty);
            dependencyProperties.Add(Group2Property);
            dependencyProperties.Add(Group2TemplateProperty);
            dependencyProperties.Add(Button1Property);
            dependencyProperties.Add(Button1TemplateProperty);
            dependencyProperties.Add(Button2Property);
            dependencyProperties.Add(Button2TemplateProperty);
            dependencyProperties.Add(Button3Property);
            dependencyProperties.Add(Button3TemplateProperty);
            dependencyProperties.Add(Label1Property);
            dependencyProperties.Add(Label1TemplateProperty);
            dependencyProperties.Add(Label2Property);
            dependencyProperties.Add(Label2TemplateProperty);
            dependencyProperties.Add(PlayerListProperty);
            dependencyProperties.Add(PlayerListTemplateProperty);
            dependencyProperties.Add(Group3Property);
            dependencyProperties.Add(Group3TemplateProperty);
            dependencyProperties.Add(Label3Property);
            dependencyProperties.Add(Label3TemplateProperty);
            dependencyProperties.Add(AchievementsListProperty);
            dependencyProperties.Add(AchievementsListTemplateProperty);
            dependencyProperties.Add(Label4Property);
            dependencyProperties.Add(Label4TemplateProperty);
            dependencyProperties.Add(PlayerListContentProperty);
            dependencyProperties.Add(PlayerListContentTemplateProperty);
            dependencyProperties.Add(AchievementsListContentProperty);
            dependencyProperties.Add(AchievementsListContentTemplateProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<System.String> SomeParentPropertyProperty = new DependencyProperty<System.String>("SomeParentProperty");
        public System.String SomeParentProperty
        {
            get { return SomeParentPropertyProperty.GetValue(this); }
            set { SomeParentPropertyProperty.SetValue(this, value); }
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

        public readonly static DependencyProperty<Button> Button3Property = new DependencyProperty<Button>("Button3");
        public Button Button3
        {
            get { return Button3Property.GetValue(this); }
            set { Button3Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Button3TemplateProperty = new DependencyProperty<Template>("Button3Template");
        public Template Button3Template
        {
            get { return Button3TemplateProperty.GetValue(this); }
            set { Button3TemplateProperty.SetValue(this, value); }
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

        public readonly static DependencyProperty<Group> Group3Property = new DependencyProperty<Group>("Group3");
        public Group Group3
        {
            get { return Group3Property.GetValue(this); }
            set { Group3Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Group3TemplateProperty = new DependencyProperty<Template>("Group3Template");
        public Template Group3Template
        {
            get { return Group3TemplateProperty.GetValue(this); }
            set { Group3TemplateProperty.SetValue(this, value); }
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

        public readonly static DependencyProperty<List> AchievementsListProperty = new DependencyProperty<List>("AchievementsList");
        public List AchievementsList
        {
            get { return AchievementsListProperty.GetValue(this); }
            set { AchievementsListProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> AchievementsListTemplateProperty = new DependencyProperty<Template>("AchievementsListTemplate");
        public Template AchievementsListTemplate
        {
            get { return AchievementsListTemplateProperty.GetValue(this); }
            set { AchievementsListTemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Label> Label4Property = new DependencyProperty<Label>("Label4");
        public Label Label4
        {
            get { return Label4Property.GetValue(this); }
            set { Label4Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Label4TemplateProperty = new DependencyProperty<Template>("Label4Template");
        public Template Label4Template
        {
            get { return Label4TemplateProperty.GetValue(this); }
            set { Label4TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ListItem> PlayerListContentProperty = new DependencyProperty<ListItem>("PlayerListContent");
        public ListItem PlayerListContent
        {
            get { return PlayerListContentProperty.GetValue(this); }
            set { PlayerListContentProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> PlayerListContentTemplateProperty = new DependencyProperty<Template>("PlayerListContentTemplate");
        public Template PlayerListContentTemplate
        {
            get { return PlayerListContentTemplateProperty.GetValue(this); }
            set { PlayerListContentTemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ListItem> AchievementsListContentProperty = new DependencyProperty<ListItem>("AchievementsListContent");
        public ListItem AchievementsListContent
        {
            get { return AchievementsListContentProperty.GetValue(this); }
            set { AchievementsListContentProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> AchievementsListContentTemplateProperty = new DependencyProperty<Template>("AchievementsListContentTemplate");
        public Template AchievementsListContentTemplate
        {
            get { return AchievementsListContentTemplateProperty.GetValue(this); }
            set { AchievementsListContentTemplateProperty.SetValue(this, value); }
        }

        #endregion
    }

    #region Data Templates

    public static class ModelBindingTestTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return ModelBindingTest;
            }
        }

        private static Template _modelBindingTest;
        public static Template ModelBindingTest
        {
            get
            {
#if UNITY_EDITOR
                if (_modelBindingTest == null || _modelBindingTest.CurrentVersion != Template.Version)
#else
                if (_modelBindingTest == null)
#endif
                {
                    _modelBindingTest = new Template(LayoutRootTemplates.LayoutRoot);
#if UNITY_EDITOR
                    _modelBindingTest.Name = "ModelBindingTest";
#endif
                    Delight.ModelBindingTest.Group1TemplateProperty.SetDefault(_modelBindingTest, ModelBindingTestGroup1);
                    Delight.ModelBindingTest.Group2TemplateProperty.SetDefault(_modelBindingTest, ModelBindingTestGroup2);
                    Delight.ModelBindingTest.Button1TemplateProperty.SetDefault(_modelBindingTest, ModelBindingTestButton1);
                    Delight.ModelBindingTest.Button2TemplateProperty.SetDefault(_modelBindingTest, ModelBindingTestButton2);
                    Delight.ModelBindingTest.Button3TemplateProperty.SetDefault(_modelBindingTest, ModelBindingTestButton3);
                    Delight.ModelBindingTest.Label1TemplateProperty.SetDefault(_modelBindingTest, ModelBindingTestLabel1);
                    Delight.ModelBindingTest.Label2TemplateProperty.SetDefault(_modelBindingTest, ModelBindingTestLabel2);
                    Delight.ModelBindingTest.PlayerListTemplateProperty.SetDefault(_modelBindingTest, ModelBindingTestPlayerList);
                    Delight.ModelBindingTest.PlayerListContentTemplateProperty.SetDefault(_modelBindingTest, ModelBindingTestPlayerListContent);
                    Delight.ModelBindingTest.Group3TemplateProperty.SetDefault(_modelBindingTest, ModelBindingTestGroup3);
                    Delight.ModelBindingTest.Label3TemplateProperty.SetDefault(_modelBindingTest, ModelBindingTestLabel3);
                    Delight.ModelBindingTest.AchievementsListTemplateProperty.SetDefault(_modelBindingTest, ModelBindingTestAchievementsList);
                    Delight.ModelBindingTest.AchievementsListContentTemplateProperty.SetDefault(_modelBindingTest, ModelBindingTestAchievementsListContent);
                    Delight.ModelBindingTest.Label4TemplateProperty.SetDefault(_modelBindingTest, ModelBindingTestLabel4);
                }
                return _modelBindingTest;
            }
        }

        private static Template _modelBindingTestGroup1;
        public static Template ModelBindingTestGroup1
        {
            get
            {
#if UNITY_EDITOR
                if (_modelBindingTestGroup1 == null || _modelBindingTestGroup1.CurrentVersion != Template.Version)
#else
                if (_modelBindingTestGroup1 == null)
#endif
                {
                    _modelBindingTestGroup1 = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _modelBindingTestGroup1.Name = "ModelBindingTestGroup1";
#endif
                    Delight.Group.OrientationProperty.SetDefault(_modelBindingTestGroup1, Delight.ElementOrientation.Horizontal);
                    Delight.Group.SpacingProperty.SetDefault(_modelBindingTestGroup1, new ElementSize(10f, ElementSizeUnit.Pixels));
                }
                return _modelBindingTestGroup1;
            }
        }

        private static Template _modelBindingTestGroup2;
        public static Template ModelBindingTestGroup2
        {
            get
            {
#if UNITY_EDITOR
                if (_modelBindingTestGroup2 == null || _modelBindingTestGroup2.CurrentVersion != Template.Version)
#else
                if (_modelBindingTestGroup2 == null)
#endif
                {
                    _modelBindingTestGroup2 = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _modelBindingTestGroup2.Name = "ModelBindingTestGroup2";
#endif
                    Delight.Group.SpacingProperty.SetDefault(_modelBindingTestGroup2, new ElementSize(10f, ElementSizeUnit.Pixels));
                    Delight.Group.WidthProperty.SetDefault(_modelBindingTestGroup2, new ElementSize(100f, ElementSizeUnit.Pixels));
                }
                return _modelBindingTestGroup2;
            }
        }

        private static Template _modelBindingTestButton1;
        public static Template ModelBindingTestButton1
        {
            get
            {
#if UNITY_EDITOR
                if (_modelBindingTestButton1 == null || _modelBindingTestButton1.CurrentVersion != Template.Version)
#else
                if (_modelBindingTestButton1 == null)
#endif
                {
                    _modelBindingTestButton1 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _modelBindingTestButton1.Name = "ModelBindingTestButton1";
#endif
                    Delight.Button.WidthProperty.SetDefault(_modelBindingTestButton1, new ElementSize(1f, ElementSizeUnit.Percents));
                    Delight.Button.LabelTemplateProperty.SetDefault(_modelBindingTestButton1, ModelBindingTestButton1Label);
                }
                return _modelBindingTestButton1;
            }
        }

        private static Template _modelBindingTestButton1Label;
        public static Template ModelBindingTestButton1Label
        {
            get
            {
#if UNITY_EDITOR
                if (_modelBindingTestButton1Label == null || _modelBindingTestButton1Label.CurrentVersion != Template.Version)
#else
                if (_modelBindingTestButton1Label == null)
#endif
                {
                    _modelBindingTestButton1Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _modelBindingTestButton1Label.Name = "ModelBindingTestButton1Label";
#endif
                    Delight.Label.TextProperty.SetDefault(_modelBindingTestButton1Label, "Test 1");
                }
                return _modelBindingTestButton1Label;
            }
        }

        private static Template _modelBindingTestButton2;
        public static Template ModelBindingTestButton2
        {
            get
            {
#if UNITY_EDITOR
                if (_modelBindingTestButton2 == null || _modelBindingTestButton2.CurrentVersion != Template.Version)
#else
                if (_modelBindingTestButton2 == null)
#endif
                {
                    _modelBindingTestButton2 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _modelBindingTestButton2.Name = "ModelBindingTestButton2";
#endif
                    Delight.Button.WidthProperty.SetDefault(_modelBindingTestButton2, new ElementSize(1f, ElementSizeUnit.Percents));
                    Delight.Button.LabelTemplateProperty.SetDefault(_modelBindingTestButton2, ModelBindingTestButton2Label);
                }
                return _modelBindingTestButton2;
            }
        }

        private static Template _modelBindingTestButton2Label;
        public static Template ModelBindingTestButton2Label
        {
            get
            {
#if UNITY_EDITOR
                if (_modelBindingTestButton2Label == null || _modelBindingTestButton2Label.CurrentVersion != Template.Version)
#else
                if (_modelBindingTestButton2Label == null)
#endif
                {
                    _modelBindingTestButton2Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _modelBindingTestButton2Label.Name = "ModelBindingTestButton2Label";
#endif
                    Delight.Label.TextProperty.SetDefault(_modelBindingTestButton2Label, "Add");
                }
                return _modelBindingTestButton2Label;
            }
        }

        private static Template _modelBindingTestButton3;
        public static Template ModelBindingTestButton3
        {
            get
            {
#if UNITY_EDITOR
                if (_modelBindingTestButton3 == null || _modelBindingTestButton3.CurrentVersion != Template.Version)
#else
                if (_modelBindingTestButton3 == null)
#endif
                {
                    _modelBindingTestButton3 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _modelBindingTestButton3.Name = "ModelBindingTestButton3";
#endif
                    Delight.Button.WidthProperty.SetDefault(_modelBindingTestButton3, new ElementSize(1f, ElementSizeUnit.Percents));
                    Delight.Button.LabelTemplateProperty.SetDefault(_modelBindingTestButton3, ModelBindingTestButton3Label);
                }
                return _modelBindingTestButton3;
            }
        }

        private static Template _modelBindingTestButton3Label;
        public static Template ModelBindingTestButton3Label
        {
            get
            {
#if UNITY_EDITOR
                if (_modelBindingTestButton3Label == null || _modelBindingTestButton3Label.CurrentVersion != Template.Version)
#else
                if (_modelBindingTestButton3Label == null)
#endif
                {
                    _modelBindingTestButton3Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _modelBindingTestButton3Label.Name = "ModelBindingTestButton3Label";
#endif
                    Delight.Label.TextProperty.SetDefault(_modelBindingTestButton3Label, "Remove");
                }
                return _modelBindingTestButton3Label;
            }
        }

        private static Template _modelBindingTestLabel1;
        public static Template ModelBindingTestLabel1
        {
            get
            {
#if UNITY_EDITOR
                if (_modelBindingTestLabel1 == null || _modelBindingTestLabel1.CurrentVersion != Template.Version)
#else
                if (_modelBindingTestLabel1 == null)
#endif
                {
                    _modelBindingTestLabel1 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _modelBindingTestLabel1.Name = "ModelBindingTestLabel1";
#endif
                    Delight.Label.TextProperty.SetHasBinding(_modelBindingTestLabel1);
                }
                return _modelBindingTestLabel1;
            }
        }

        private static Template _modelBindingTestLabel2;
        public static Template ModelBindingTestLabel2
        {
            get
            {
#if UNITY_EDITOR
                if (_modelBindingTestLabel2 == null || _modelBindingTestLabel2.CurrentVersion != Template.Version)
#else
                if (_modelBindingTestLabel2 == null)
#endif
                {
                    _modelBindingTestLabel2 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _modelBindingTestLabel2.Name = "ModelBindingTestLabel2";
#endif
                    Delight.Label.TextProperty.SetHasBinding(_modelBindingTestLabel2);
                }
                return _modelBindingTestLabel2;
            }
        }

        private static Template _modelBindingTestPlayerList;
        public static Template ModelBindingTestPlayerList
        {
            get
            {
#if UNITY_EDITOR
                if (_modelBindingTestPlayerList == null || _modelBindingTestPlayerList.CurrentVersion != Template.Version)
#else
                if (_modelBindingTestPlayerList == null)
#endif
                {
                    _modelBindingTestPlayerList = new Template(ListTemplates.List);
#if UNITY_EDITOR
                    _modelBindingTestPlayerList.Name = "ModelBindingTestPlayerList";
#endif
                    Delight.List.WidthProperty.SetDefault(_modelBindingTestPlayerList, new ElementSize(200f, ElementSizeUnit.Pixels));
                    Delight.List.HeightProperty.SetDefault(_modelBindingTestPlayerList, new ElementSize(500f, ElementSizeUnit.Pixels));
                    Delight.List.BackgroundColorProperty.SetDefault(_modelBindingTestPlayerList, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.List.SpacingProperty.SetDefault(_modelBindingTestPlayerList, new ElementSize(5f, ElementSizeUnit.Pixels));
                    Delight.List.IsScrollableProperty.SetDefault(_modelBindingTestPlayerList, true);
                    Delight.List.ItemsProperty.SetHasBinding(_modelBindingTestPlayerList);
                    Delight.List.ScrollableRegionTemplateProperty.SetDefault(_modelBindingTestPlayerList, ModelBindingTestPlayerListScrollableRegion);
                }
                return _modelBindingTestPlayerList;
            }
        }

        private static Template _modelBindingTestPlayerListScrollableRegion;
        public static Template ModelBindingTestPlayerListScrollableRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_modelBindingTestPlayerListScrollableRegion == null || _modelBindingTestPlayerListScrollableRegion.CurrentVersion != Template.Version)
#else
                if (_modelBindingTestPlayerListScrollableRegion == null)
#endif
                {
                    _modelBindingTestPlayerListScrollableRegion = new Template(ListTemplates.ListScrollableRegion);
#if UNITY_EDITOR
                    _modelBindingTestPlayerListScrollableRegion.Name = "ModelBindingTestPlayerListScrollableRegion";
#endif
                    Delight.ScrollableRegion.ContentRegionTemplateProperty.SetDefault(_modelBindingTestPlayerListScrollableRegion, ModelBindingTestPlayerListScrollableRegionContentRegion);
                    Delight.ScrollableRegion.HorizontalScrollbarTemplateProperty.SetDefault(_modelBindingTestPlayerListScrollableRegion, ModelBindingTestPlayerListScrollableRegionHorizontalScrollbar);
                    Delight.ScrollableRegion.VerticalScrollbarTemplateProperty.SetDefault(_modelBindingTestPlayerListScrollableRegion, ModelBindingTestPlayerListScrollableRegionVerticalScrollbar);
                }
                return _modelBindingTestPlayerListScrollableRegion;
            }
        }

        private static Template _modelBindingTestPlayerListScrollableRegionContentRegion;
        public static Template ModelBindingTestPlayerListScrollableRegionContentRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_modelBindingTestPlayerListScrollableRegionContentRegion == null || _modelBindingTestPlayerListScrollableRegionContentRegion.CurrentVersion != Template.Version)
#else
                if (_modelBindingTestPlayerListScrollableRegionContentRegion == null)
#endif
                {
                    _modelBindingTestPlayerListScrollableRegionContentRegion = new Template(ListTemplates.ListScrollableRegionContentRegion);
#if UNITY_EDITOR
                    _modelBindingTestPlayerListScrollableRegionContentRegion.Name = "ModelBindingTestPlayerListScrollableRegionContentRegion";
#endif
                }
                return _modelBindingTestPlayerListScrollableRegionContentRegion;
            }
        }

        private static Template _modelBindingTestPlayerListScrollableRegionHorizontalScrollbar;
        public static Template ModelBindingTestPlayerListScrollableRegionHorizontalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_modelBindingTestPlayerListScrollableRegionHorizontalScrollbar == null || _modelBindingTestPlayerListScrollableRegionHorizontalScrollbar.CurrentVersion != Template.Version)
#else
                if (_modelBindingTestPlayerListScrollableRegionHorizontalScrollbar == null)
#endif
                {
                    _modelBindingTestPlayerListScrollableRegionHorizontalScrollbar = new Template(ListTemplates.ListScrollableRegionHorizontalScrollbar);
#if UNITY_EDITOR
                    _modelBindingTestPlayerListScrollableRegionHorizontalScrollbar.Name = "ModelBindingTestPlayerListScrollableRegionHorizontalScrollbar";
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_modelBindingTestPlayerListScrollableRegionHorizontalScrollbar, ModelBindingTestPlayerListScrollableRegionHorizontalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_modelBindingTestPlayerListScrollableRegionHorizontalScrollbar, ModelBindingTestPlayerListScrollableRegionHorizontalScrollbarHandle);
                }
                return _modelBindingTestPlayerListScrollableRegionHorizontalScrollbar;
            }
        }

        private static Template _modelBindingTestPlayerListScrollableRegionHorizontalScrollbarBar;
        public static Template ModelBindingTestPlayerListScrollableRegionHorizontalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_modelBindingTestPlayerListScrollableRegionHorizontalScrollbarBar == null || _modelBindingTestPlayerListScrollableRegionHorizontalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_modelBindingTestPlayerListScrollableRegionHorizontalScrollbarBar == null)
#endif
                {
                    _modelBindingTestPlayerListScrollableRegionHorizontalScrollbarBar = new Template(ListTemplates.ListScrollableRegionHorizontalScrollbarBar);
#if UNITY_EDITOR
                    _modelBindingTestPlayerListScrollableRegionHorizontalScrollbarBar.Name = "ModelBindingTestPlayerListScrollableRegionHorizontalScrollbarBar";
#endif
                }
                return _modelBindingTestPlayerListScrollableRegionHorizontalScrollbarBar;
            }
        }

        private static Template _modelBindingTestPlayerListScrollableRegionHorizontalScrollbarHandle;
        public static Template ModelBindingTestPlayerListScrollableRegionHorizontalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_modelBindingTestPlayerListScrollableRegionHorizontalScrollbarHandle == null || _modelBindingTestPlayerListScrollableRegionHorizontalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_modelBindingTestPlayerListScrollableRegionHorizontalScrollbarHandle == null)
#endif
                {
                    _modelBindingTestPlayerListScrollableRegionHorizontalScrollbarHandle = new Template(ListTemplates.ListScrollableRegionHorizontalScrollbarHandle);
#if UNITY_EDITOR
                    _modelBindingTestPlayerListScrollableRegionHorizontalScrollbarHandle.Name = "ModelBindingTestPlayerListScrollableRegionHorizontalScrollbarHandle";
#endif
                }
                return _modelBindingTestPlayerListScrollableRegionHorizontalScrollbarHandle;
            }
        }

        private static Template _modelBindingTestPlayerListScrollableRegionVerticalScrollbar;
        public static Template ModelBindingTestPlayerListScrollableRegionVerticalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_modelBindingTestPlayerListScrollableRegionVerticalScrollbar == null || _modelBindingTestPlayerListScrollableRegionVerticalScrollbar.CurrentVersion != Template.Version)
#else
                if (_modelBindingTestPlayerListScrollableRegionVerticalScrollbar == null)
#endif
                {
                    _modelBindingTestPlayerListScrollableRegionVerticalScrollbar = new Template(ListTemplates.ListScrollableRegionVerticalScrollbar);
#if UNITY_EDITOR
                    _modelBindingTestPlayerListScrollableRegionVerticalScrollbar.Name = "ModelBindingTestPlayerListScrollableRegionVerticalScrollbar";
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_modelBindingTestPlayerListScrollableRegionVerticalScrollbar, ModelBindingTestPlayerListScrollableRegionVerticalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_modelBindingTestPlayerListScrollableRegionVerticalScrollbar, ModelBindingTestPlayerListScrollableRegionVerticalScrollbarHandle);
                }
                return _modelBindingTestPlayerListScrollableRegionVerticalScrollbar;
            }
        }

        private static Template _modelBindingTestPlayerListScrollableRegionVerticalScrollbarBar;
        public static Template ModelBindingTestPlayerListScrollableRegionVerticalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_modelBindingTestPlayerListScrollableRegionVerticalScrollbarBar == null || _modelBindingTestPlayerListScrollableRegionVerticalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_modelBindingTestPlayerListScrollableRegionVerticalScrollbarBar == null)
#endif
                {
                    _modelBindingTestPlayerListScrollableRegionVerticalScrollbarBar = new Template(ListTemplates.ListScrollableRegionVerticalScrollbarBar);
#if UNITY_EDITOR
                    _modelBindingTestPlayerListScrollableRegionVerticalScrollbarBar.Name = "ModelBindingTestPlayerListScrollableRegionVerticalScrollbarBar";
#endif
                }
                return _modelBindingTestPlayerListScrollableRegionVerticalScrollbarBar;
            }
        }

        private static Template _modelBindingTestPlayerListScrollableRegionVerticalScrollbarHandle;
        public static Template ModelBindingTestPlayerListScrollableRegionVerticalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_modelBindingTestPlayerListScrollableRegionVerticalScrollbarHandle == null || _modelBindingTestPlayerListScrollableRegionVerticalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_modelBindingTestPlayerListScrollableRegionVerticalScrollbarHandle == null)
#endif
                {
                    _modelBindingTestPlayerListScrollableRegionVerticalScrollbarHandle = new Template(ListTemplates.ListScrollableRegionVerticalScrollbarHandle);
#if UNITY_EDITOR
                    _modelBindingTestPlayerListScrollableRegionVerticalScrollbarHandle.Name = "ModelBindingTestPlayerListScrollableRegionVerticalScrollbarHandle";
#endif
                }
                return _modelBindingTestPlayerListScrollableRegionVerticalScrollbarHandle;
            }
        }

        private static Template _modelBindingTestPlayerListContent;
        public static Template ModelBindingTestPlayerListContent
        {
            get
            {
#if UNITY_EDITOR
                if (_modelBindingTestPlayerListContent == null || _modelBindingTestPlayerListContent.CurrentVersion != Template.Version)
#else
                if (_modelBindingTestPlayerListContent == null)
#endif
                {
                    _modelBindingTestPlayerListContent = new Template(ListItemTemplates.ListItem);
#if UNITY_EDITOR
                    _modelBindingTestPlayerListContent.Name = "ModelBindingTestPlayerListContent";
#endif
                }
                return _modelBindingTestPlayerListContent;
            }
        }

        private static Template _modelBindingTestGroup3;
        public static Template ModelBindingTestGroup3
        {
            get
            {
#if UNITY_EDITOR
                if (_modelBindingTestGroup3 == null || _modelBindingTestGroup3.CurrentVersion != Template.Version)
#else
                if (_modelBindingTestGroup3 == null)
#endif
                {
                    _modelBindingTestGroup3 = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _modelBindingTestGroup3.Name = "ModelBindingTestGroup3";
#endif
                }
                return _modelBindingTestGroup3;
            }
        }

        private static Template _modelBindingTestLabel3;
        public static Template ModelBindingTestLabel3
        {
            get
            {
#if UNITY_EDITOR
                if (_modelBindingTestLabel3 == null || _modelBindingTestLabel3.CurrentVersion != Template.Version)
#else
                if (_modelBindingTestLabel3 == null)
#endif
                {
                    _modelBindingTestLabel3 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _modelBindingTestLabel3.Name = "ModelBindingTestLabel3";
#endif
                    Delight.Label.TextProperty.SetHasBinding(_modelBindingTestLabel3);
                }
                return _modelBindingTestLabel3;
            }
        }

        private static Template _modelBindingTestAchievementsList;
        public static Template ModelBindingTestAchievementsList
        {
            get
            {
#if UNITY_EDITOR
                if (_modelBindingTestAchievementsList == null || _modelBindingTestAchievementsList.CurrentVersion != Template.Version)
#else
                if (_modelBindingTestAchievementsList == null)
#endif
                {
                    _modelBindingTestAchievementsList = new Template(ListTemplates.List);
#if UNITY_EDITOR
                    _modelBindingTestAchievementsList.Name = "ModelBindingTestAchievementsList";
#endif
                    Delight.List.OrientationProperty.SetDefault(_modelBindingTestAchievementsList, Delight.ElementOrientation.Vertical);
                    Delight.List.OffsetProperty.SetDefault(_modelBindingTestAchievementsList, new ElementMargin(new ElementSize(50f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels)));
                    Delight.List.ItemsProperty.SetHasBinding(_modelBindingTestAchievementsList);
                    Delight.List.ScrollableRegionTemplateProperty.SetDefault(_modelBindingTestAchievementsList, ModelBindingTestAchievementsListScrollableRegion);
                }
                return _modelBindingTestAchievementsList;
            }
        }

        private static Template _modelBindingTestAchievementsListScrollableRegion;
        public static Template ModelBindingTestAchievementsListScrollableRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_modelBindingTestAchievementsListScrollableRegion == null || _modelBindingTestAchievementsListScrollableRegion.CurrentVersion != Template.Version)
#else
                if (_modelBindingTestAchievementsListScrollableRegion == null)
#endif
                {
                    _modelBindingTestAchievementsListScrollableRegion = new Template(ListTemplates.ListScrollableRegion);
#if UNITY_EDITOR
                    _modelBindingTestAchievementsListScrollableRegion.Name = "ModelBindingTestAchievementsListScrollableRegion";
#endif
                    Delight.ScrollableRegion.ContentRegionTemplateProperty.SetDefault(_modelBindingTestAchievementsListScrollableRegion, ModelBindingTestAchievementsListScrollableRegionContentRegion);
                    Delight.ScrollableRegion.HorizontalScrollbarTemplateProperty.SetDefault(_modelBindingTestAchievementsListScrollableRegion, ModelBindingTestAchievementsListScrollableRegionHorizontalScrollbar);
                    Delight.ScrollableRegion.VerticalScrollbarTemplateProperty.SetDefault(_modelBindingTestAchievementsListScrollableRegion, ModelBindingTestAchievementsListScrollableRegionVerticalScrollbar);
                }
                return _modelBindingTestAchievementsListScrollableRegion;
            }
        }

        private static Template _modelBindingTestAchievementsListScrollableRegionContentRegion;
        public static Template ModelBindingTestAchievementsListScrollableRegionContentRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_modelBindingTestAchievementsListScrollableRegionContentRegion == null || _modelBindingTestAchievementsListScrollableRegionContentRegion.CurrentVersion != Template.Version)
#else
                if (_modelBindingTestAchievementsListScrollableRegionContentRegion == null)
#endif
                {
                    _modelBindingTestAchievementsListScrollableRegionContentRegion = new Template(ListTemplates.ListScrollableRegionContentRegion);
#if UNITY_EDITOR
                    _modelBindingTestAchievementsListScrollableRegionContentRegion.Name = "ModelBindingTestAchievementsListScrollableRegionContentRegion";
#endif
                }
                return _modelBindingTestAchievementsListScrollableRegionContentRegion;
            }
        }

        private static Template _modelBindingTestAchievementsListScrollableRegionHorizontalScrollbar;
        public static Template ModelBindingTestAchievementsListScrollableRegionHorizontalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_modelBindingTestAchievementsListScrollableRegionHorizontalScrollbar == null || _modelBindingTestAchievementsListScrollableRegionHorizontalScrollbar.CurrentVersion != Template.Version)
#else
                if (_modelBindingTestAchievementsListScrollableRegionHorizontalScrollbar == null)
#endif
                {
                    _modelBindingTestAchievementsListScrollableRegionHorizontalScrollbar = new Template(ListTemplates.ListScrollableRegionHorizontalScrollbar);
#if UNITY_EDITOR
                    _modelBindingTestAchievementsListScrollableRegionHorizontalScrollbar.Name = "ModelBindingTestAchievementsListScrollableRegionHorizontalScrollbar";
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_modelBindingTestAchievementsListScrollableRegionHorizontalScrollbar, ModelBindingTestAchievementsListScrollableRegionHorizontalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_modelBindingTestAchievementsListScrollableRegionHorizontalScrollbar, ModelBindingTestAchievementsListScrollableRegionHorizontalScrollbarHandle);
                }
                return _modelBindingTestAchievementsListScrollableRegionHorizontalScrollbar;
            }
        }

        private static Template _modelBindingTestAchievementsListScrollableRegionHorizontalScrollbarBar;
        public static Template ModelBindingTestAchievementsListScrollableRegionHorizontalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_modelBindingTestAchievementsListScrollableRegionHorizontalScrollbarBar == null || _modelBindingTestAchievementsListScrollableRegionHorizontalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_modelBindingTestAchievementsListScrollableRegionHorizontalScrollbarBar == null)
#endif
                {
                    _modelBindingTestAchievementsListScrollableRegionHorizontalScrollbarBar = new Template(ListTemplates.ListScrollableRegionHorizontalScrollbarBar);
#if UNITY_EDITOR
                    _modelBindingTestAchievementsListScrollableRegionHorizontalScrollbarBar.Name = "ModelBindingTestAchievementsListScrollableRegionHorizontalScrollbarBar";
#endif
                }
                return _modelBindingTestAchievementsListScrollableRegionHorizontalScrollbarBar;
            }
        }

        private static Template _modelBindingTestAchievementsListScrollableRegionHorizontalScrollbarHandle;
        public static Template ModelBindingTestAchievementsListScrollableRegionHorizontalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_modelBindingTestAchievementsListScrollableRegionHorizontalScrollbarHandle == null || _modelBindingTestAchievementsListScrollableRegionHorizontalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_modelBindingTestAchievementsListScrollableRegionHorizontalScrollbarHandle == null)
#endif
                {
                    _modelBindingTestAchievementsListScrollableRegionHorizontalScrollbarHandle = new Template(ListTemplates.ListScrollableRegionHorizontalScrollbarHandle);
#if UNITY_EDITOR
                    _modelBindingTestAchievementsListScrollableRegionHorizontalScrollbarHandle.Name = "ModelBindingTestAchievementsListScrollableRegionHorizontalScrollbarHandle";
#endif
                }
                return _modelBindingTestAchievementsListScrollableRegionHorizontalScrollbarHandle;
            }
        }

        private static Template _modelBindingTestAchievementsListScrollableRegionVerticalScrollbar;
        public static Template ModelBindingTestAchievementsListScrollableRegionVerticalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_modelBindingTestAchievementsListScrollableRegionVerticalScrollbar == null || _modelBindingTestAchievementsListScrollableRegionVerticalScrollbar.CurrentVersion != Template.Version)
#else
                if (_modelBindingTestAchievementsListScrollableRegionVerticalScrollbar == null)
#endif
                {
                    _modelBindingTestAchievementsListScrollableRegionVerticalScrollbar = new Template(ListTemplates.ListScrollableRegionVerticalScrollbar);
#if UNITY_EDITOR
                    _modelBindingTestAchievementsListScrollableRegionVerticalScrollbar.Name = "ModelBindingTestAchievementsListScrollableRegionVerticalScrollbar";
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_modelBindingTestAchievementsListScrollableRegionVerticalScrollbar, ModelBindingTestAchievementsListScrollableRegionVerticalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_modelBindingTestAchievementsListScrollableRegionVerticalScrollbar, ModelBindingTestAchievementsListScrollableRegionVerticalScrollbarHandle);
                }
                return _modelBindingTestAchievementsListScrollableRegionVerticalScrollbar;
            }
        }

        private static Template _modelBindingTestAchievementsListScrollableRegionVerticalScrollbarBar;
        public static Template ModelBindingTestAchievementsListScrollableRegionVerticalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_modelBindingTestAchievementsListScrollableRegionVerticalScrollbarBar == null || _modelBindingTestAchievementsListScrollableRegionVerticalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_modelBindingTestAchievementsListScrollableRegionVerticalScrollbarBar == null)
#endif
                {
                    _modelBindingTestAchievementsListScrollableRegionVerticalScrollbarBar = new Template(ListTemplates.ListScrollableRegionVerticalScrollbarBar);
#if UNITY_EDITOR
                    _modelBindingTestAchievementsListScrollableRegionVerticalScrollbarBar.Name = "ModelBindingTestAchievementsListScrollableRegionVerticalScrollbarBar";
#endif
                }
                return _modelBindingTestAchievementsListScrollableRegionVerticalScrollbarBar;
            }
        }

        private static Template _modelBindingTestAchievementsListScrollableRegionVerticalScrollbarHandle;
        public static Template ModelBindingTestAchievementsListScrollableRegionVerticalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_modelBindingTestAchievementsListScrollableRegionVerticalScrollbarHandle == null || _modelBindingTestAchievementsListScrollableRegionVerticalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_modelBindingTestAchievementsListScrollableRegionVerticalScrollbarHandle == null)
#endif
                {
                    _modelBindingTestAchievementsListScrollableRegionVerticalScrollbarHandle = new Template(ListTemplates.ListScrollableRegionVerticalScrollbarHandle);
#if UNITY_EDITOR
                    _modelBindingTestAchievementsListScrollableRegionVerticalScrollbarHandle.Name = "ModelBindingTestAchievementsListScrollableRegionVerticalScrollbarHandle";
#endif
                }
                return _modelBindingTestAchievementsListScrollableRegionVerticalScrollbarHandle;
            }
        }

        private static Template _modelBindingTestAchievementsListContent;
        public static Template ModelBindingTestAchievementsListContent
        {
            get
            {
#if UNITY_EDITOR
                if (_modelBindingTestAchievementsListContent == null || _modelBindingTestAchievementsListContent.CurrentVersion != Template.Version)
#else
                if (_modelBindingTestAchievementsListContent == null)
#endif
                {
                    _modelBindingTestAchievementsListContent = new Template(ListItemTemplates.ListItem);
#if UNITY_EDITOR
                    _modelBindingTestAchievementsListContent.Name = "ModelBindingTestAchievementsListContent";
#endif
                }
                return _modelBindingTestAchievementsListContent;
            }
        }

        private static Template _modelBindingTestLabel4;
        public static Template ModelBindingTestLabel4
        {
            get
            {
#if UNITY_EDITOR
                if (_modelBindingTestLabel4 == null || _modelBindingTestLabel4.CurrentVersion != Template.Version)
#else
                if (_modelBindingTestLabel4 == null)
#endif
                {
                    _modelBindingTestLabel4 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _modelBindingTestLabel4.Name = "ModelBindingTestLabel4";
#endif
                    Delight.Label.WidthProperty.SetDefault(_modelBindingTestLabel4, new ElementSize(150f, ElementSizeUnit.Pixels));
                    Delight.Label.HeightProperty.SetDefault(_modelBindingTestLabel4, new ElementSize(40f, ElementSizeUnit.Pixels));
                    Delight.Label.TextProperty.SetHasBinding(_modelBindingTestLabel4);
                }
                return _modelBindingTestLabel4;
            }
        }

        #endregion
    }

    #endregion
}
