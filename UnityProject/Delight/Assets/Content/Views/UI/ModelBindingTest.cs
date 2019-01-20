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

            // create list that we want to bind to our players
            var list = new CollectionView(this, DynamicList);
            list.Items = Models.Players;
        }

        private IDisposable _update;
        protected override void AfterLoad()
        {
            base.AfterLoad();

            // add one player every second
            _update = Observable.Interval(TimeSpan.FromMilliseconds(1000)).Subscribe(x =>
            {
                Models.Players.Add(new Player { Name = "Player " + x });
            });
        }

        int i = 0;
        public void Test1()
        {
            Models.Players.Player1.Name = "Julia " + i++;
        }

        public void Test2()
        {
            Label1.Text = "Sanna";
        }
    }
}
