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

            // test of template generation with nested lists
            DynamicList.ItemInitializer = player =>
            {
                // FIRST LIST TEMPLATE
                var playerListItem = new ListItem(this, DynamicList, "ListItem");
                playerListItem.Item = player;

                var label1 = new Label(this, playerListItem, "Label1", LabelTemplates.Default);

                // binding <Label Text="{@Players[Id].Name}">
                playerListItem.Bindings.Add(new Binding(
                        new List<string> { "Name" },
                        new List<string> { "Label1", "Text" },
                        new List<Func<BindableObject>> { () => Models.Players[playerListItem.Item.Id] },
                        new List<Func<BindableObject>> { () => this, () => label1 },
                        () => label1.Text = Models.Players[playerListItem.Item.Id].Name,
                        () => { }
                    ));

                AchievementsList = new List(this, playerListItem, "AchievementsList", AchievementsListTemplate);

                // binding <List Items="{player.Achievements}">
                playerListItem.Bindings.Add(new Binding(
                    new List<string> { "Achievements" },
                    new List<string> { "AchievementsList", "Items" },
                    new List<Func<BindableObject>> { () => Models.Players[playerListItem.Item.Id] },
                    new List<Func<BindableObject>> { () => this, () => AchievementsList },
                    () => AchievementsList.Items = Models.Players[playerListItem.Item.Id].Achievements,
                    () => { }
                ));

                AchievementsList.ItemInitializer = achievement =>
                {
                    // NESTED LIST TEMPLATE
                    var achievementListItem = new ListItem(this, AchievementsList, "ListItem");
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
        }

        public void Test2()
        {
            Models.Players["Player1"].Achievements.Add(new Achievement
            {
                PlayerId = "Player1", // TODO make it so PlayerId doesn't have to be specified here
                Title = "Hello"
            });
        }
    }
}
