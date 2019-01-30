#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
#endregion

namespace Delight
{
    public partial class ModelBindingTest
    {
        int i = 0;
        public void Test1()
        {
            Models.Players["Player1"].Name = "Julia " + i++;
            SomeParentProperty = "Yo " + i;
        }

        public void Test2()
        {
            Models.Players["Player1"].Achievements.Add(new Achievement { Title = "Hello" });
        }

        protected override void BeforeLoad()
        {
            base.BeforeLoad();
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
    }
}
