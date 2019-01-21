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

            DynamicList.ItemInitializer = item =>
            {
                var template = new UIView(this, DynamicList, "ListItem");
                var label1 = new Label(this, template, "Label1", LabelTemplates.Default);

                // binding <Label Text="{@Players[Id].Name}">
                template.Bindings.Add(new Binding(
                        new List<string> { "Name" },
                        new List<string> { "Label1", "Text" },
                        new List<Func<BindableObject>> { () => Models.Players[item.Id] },
                        new List<Func<BindableObject>> { () => this, () => label1 },
                        () => label1.Text = Models.Players[item.Id].Name,
                        () => { }
                    ));

                return template; // will probably be wrapped in a template
            };
        }

        private IDisposable _update;
        protected override void AfterLoad()
        {
            base.AfterLoad();

            // add one player every second
            _update = Observable.Interval(TimeSpan.FromMilliseconds(1000)).Subscribe(x =>
            {
                Models.Players.Add(new Player { Id = "Player " + x, Name = "Player " + x });
            });
        }

        int i = 0;
        public void Test1()
        {
            Models.Players["Player 1"].Name = "Julia " + i++;
        }

        public void Test2()
        {
            //Label1.Text = "Sanna";
        }
    }
}
