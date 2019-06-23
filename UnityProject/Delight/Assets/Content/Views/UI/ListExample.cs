#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class ListExample
    {
        protected override void BeforeLoad()
        {
            base.BeforeLoad();

            System.Random random = new System.Random();

            var playerList = new BindableCollection<Player>();
            for (int i = 1; i <= 50; ++i)
            {
                playerList.Add(new Player { Name = "Item " + i, Color = new Color(random.Next(0, 255) / 255f, random.Next(0, 255) / 255f, random.Next(0, 255) / 255f) });
            }
            Players = playerList;
        }

        public void Add()
        {

        }

        public void Remove()
        {

        }
    }
}
