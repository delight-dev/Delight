#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class ModelBindingTest
    {
        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void BeforeLoad()
        {
            base.BeforeLoad();

            // test if we can change playerListItem.Item during run-time and see the changes reflected
            // test of template generation with nested lists
            PlayerList.ItemInitializer = player =>
            {
                // FIRST LIST TEMPLATE
                var playerListItem = new ListItem(this, PlayerList, "ListItem");
                playerListItem.Item = player;

                var group3 = new Group(this, playerListItem, "Group3", Group3Template);
                var label1 = new Label(this, group3, "Label1", Label1Template);

                // binding <Label Text="{@Players[Id].Name}">
                playerListItem.Bindings.Add(new Binding(
                        new List<string> { "Name" },
                        new List<string> { "Label1", "Text" },
                        new List<Func<BindableObject>> { () => Models.Players[playerListItem.Item.Id] },
                        new List<Func<BindableObject>> { () => this, () => label1 },
                        () => label1.Text = Models.Players[playerListItem.Item.Id].Name,
                        () => { }
                    ));

                var achievementsList = new List(this, group3, "AchievementsList", AchievementsListTemplate);

                // binding <List Items="{player.Achievements}">
                playerListItem.Bindings.Add(new Binding(
                    new List<string> { "Achievements" },
                    new List<string> { "AchievementsList", "Items" },
                    new List<Func<BindableObject>> { () => Models.Players[playerListItem.Item.Id] },
                    new List<Func<BindableObject>> { () => this, () => achievementsList },
                    () => achievementsList.Items = Models.Players[playerListItem.Item.Id].Achievements,
                    () => { }
                ));

                achievementsList.ItemInitializer = achievement =>
                {
                    // NESTED LIST TEMPLATE
                    var achievementListItem = new ListItem(this, achievementsList, "ListItem");
                    achievementListItem.Item = achievement;

                    var label2 = new Label(this, achievementListItem, "Label1", LabelTemplates.Default);

                    // binding <Label Text="{achievement.Title}">
                    achievementListItem.Bindings.Add(new Binding(
                        new List<string> { "Title" },
                        new List<string> { "Label1", "Text" },
                        new List<Func<BindableObject>> { () => Models.Players[playerListItem.Item.Id].Achievements[achievementListItem.Item.Id] },
                        new List<Func<BindableObject>> { () => this, () => label2 },
                        () =>
                        {
                            label2.Text = Models.Players[playerListItem.Item.Id].Achievements[achievementListItem.Item.Id].Title;
                        },
                        () => { }
                    ));

                    return achievementListItem;
                };

                return playerListItem;
            };

            //PlayerList.ItemInitializer = item1 =>
            //{                
            //    var playerListItem1 = new PlayerListItem(this, PlayerList, "PlayerListItem1", ListItemTemplates.Default);
            //    playerListItem1.Player = item1 as Player;
            //    return playerListItem1;
            //};
        }

        private IDisposable _update;
        protected override void AfterLoad()
        {
            base.AfterLoad();

            // add one player every second
            _update = Observable.Interval(TimeSpan.FromMilliseconds(1000)).Subscribe(x =>
            {
                //Models.Players.Add(new Player { Id = "Player " + x, Name = "Player " + x });
            });
        }

        int i = 0;
        public void Test1()
        {
            Models.Players["Player1"].Name = "Julia " + i++;

            // test changing list item to another one and see if bindings update.
            //var listItem = DynamicList.LayoutChildren[0] as ListItem;
            //listItem.Item = Models.Players["Player2"];
            //listItem.UpdateBindings();
        }

        public void Test2()
        {
            Models.Players["Player1"].Achievements.Add(new Achievement { Title = "Hello" });
        }
    }
}
