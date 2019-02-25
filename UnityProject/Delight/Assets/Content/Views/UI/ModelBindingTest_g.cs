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

        public ModelBindingTest(View parent, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :
            base(parent, layoutParent, id, template ?? ModelBindingTestTemplates.Default, initializer)
        {
            // constructing Group (Group1)
            Group1 = new Group(this, this, "Group1", Group1Template);
            Group2 = new Group(this, Group1.Content, "Group2", Group2Template);
            Button1 = new Button(this, Group2.Content, "Button1", Button1Template);
            Button1.Click += ResolveActionHandler(this, "Test1");
            Button2 = new Button(this, Group2.Content, "Button2", Button2Template);
            Button2.Click += ResolveActionHandler(this, "Test2");
            PlayerList = new List(this, Group1.Content, "PlayerList", PlayerListTemplate);

            // binding <List Items="{player in @Players}">
            Bindings.Add(new Binding(
                new List<string> {  },
                new List<string> { "PlayerList", "Items" },
                new List<Func<BindableObject>> {  },
                new List<Func<BindableObject>> { () => this, () => PlayerList },
                () => PlayerList.Items = Models.Players,
                () => { }
            ));

            // Template for PlayerList
            PlayerList.ContentTemplate = new ContentTemplate(tiPlayer => 
            {
                var playerListContent = new ListItem(this, PlayerList.Content, "PlayerListContent", PlayerListContentTemplate);
                var group3 = new Group(this, playerListContent.Content, "Group3", Group3Template);
                var label1 = new Label(this, group3.Content, "Label1", Label1Template);

                // binding <Label Text="{player.Name}">
                playerListContent.Bindings.Add(new Binding(
                    new List<string> { "Item", "Name" },
                    new List<string> { "Text" },
                    new List<Func<BindableObject>> { () => tiPlayer, () => tiPlayer.Item },
                    new List<Func<BindableObject>> { () => label1 },
                    () => label1.Text = (tiPlayer.Item as Delight.Player).Name,
                    () => { }
                ));
                var achievementsList = new List(this, group3.Content, "AchievementsList", AchievementsListTemplate);

                // binding <List Items="{achievement in player.Achievements}">
                playerListContent.Bindings.Add(new Binding(
                    new List<string> { "Item", "Achievements" },
                    new List<string> { "Items" },
                    new List<Func<BindableObject>> { () => tiPlayer, () => tiPlayer.Item },
                    new List<Func<BindableObject>> { () => achievementsList },
                    () => achievementsList.Items = (tiPlayer.Item as Delight.Player).Achievements,
                    () => { }
                ));

                // Template for achievementsList
                achievementsList.ContentTemplate = new ContentTemplate(tiAchievement => 
                {
                    var achievementsListContent = new ListItem(this, achievementsList.Content, "AchievementsListContent", AchievementsListContentTemplate);
                    var label2 = new Label(this, achievementsListContent.Content, "Label2", Label2Template);

                    // binding <Label Text="{achievement.Title}">
                    achievementsListContent.Bindings.Add(new Binding(
                        new List<string> { "Item", "Title" },
                        new List<string> { "Text" },
                        new List<Func<BindableObject>> { () => tiAchievement, () => tiAchievement.Item },
                        new List<Func<BindableObject>> { () => label2 },
                        () => label2.Text = (tiAchievement.Item as Delight.Achievement).Title,
                        () => { }
                    ));
                    return achievementsListContent;
                });
                return playerListContent;
            });
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
            dependencyProperties.Add(PlayerListProperty);
            dependencyProperties.Add(PlayerListTemplateProperty);
            dependencyProperties.Add(Group3Property);
            dependencyProperties.Add(Group3TemplateProperty);
            dependencyProperties.Add(Label1Property);
            dependencyProperties.Add(Label1TemplateProperty);
            dependencyProperties.Add(AchievementsListProperty);
            dependencyProperties.Add(AchievementsListTemplateProperty);
            dependencyProperties.Add(Label2Property);
            dependencyProperties.Add(Label2TemplateProperty);
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
                    Delight.ModelBindingTest.PlayerListTemplateProperty.SetDefault(_modelBindingTest, ModelBindingTestPlayerList);
                    Delight.ModelBindingTest.PlayerListContentTemplateProperty.SetDefault(_modelBindingTest, ModelBindingTestPlayerListContent);
                    Delight.ModelBindingTest.Group3TemplateProperty.SetDefault(_modelBindingTest, ModelBindingTestGroup3);
                    Delight.ModelBindingTest.Label1TemplateProperty.SetDefault(_modelBindingTest, ModelBindingTestLabel1);
                    Delight.ModelBindingTest.AchievementsListTemplateProperty.SetDefault(_modelBindingTest, ModelBindingTestAchievementsList);
                    Delight.ModelBindingTest.AchievementsListContentTemplateProperty.SetDefault(_modelBindingTest, ModelBindingTestAchievementsListContent);
                    Delight.ModelBindingTest.Label2TemplateProperty.SetDefault(_modelBindingTest, ModelBindingTestLabel2);
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
                    Delight.Group.WidthProperty.SetDefault(_modelBindingTestGroup2, new ElementSize(500f, ElementSizeUnit.Pixels));
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
                    Delight.Label.TextProperty.SetDefault(_modelBindingTestButton2Label, "Test 2");
                }
                return _modelBindingTestButton2Label;
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
                    Delight.List.WidthProperty.SetDefault(_modelBindingTestPlayerList, new ElementSize(500f, ElementSizeUnit.Pixels));
                    Delight.List.HeightProperty.SetDefault(_modelBindingTestPlayerList, new ElementSize(500f, ElementSizeUnit.Pixels));
                    Delight.List.BackgroundColorProperty.SetDefault(_modelBindingTestPlayerList, new UnityEngine.Color(0f, 1f, 0f, 1f));
                    Delight.List.SpacingProperty.SetDefault(_modelBindingTestPlayerList, new ElementSize(5f, ElementSizeUnit.Pixels));
                    Delight.List.IsScrollableProperty.SetDefault(_modelBindingTestPlayerList, true);
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
                }
                return _modelBindingTestPlayerListScrollableRegion;
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
                }
                return _modelBindingTestLabel1;
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
                }
                return _modelBindingTestAchievementsListScrollableRegion;
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
                }
                return _modelBindingTestLabel2;
            }
        }

        #endregion
    }

    #endregion
}
