#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
#endregion

namespace Delight
{
    public partial class ListExample
    {
        public void Add()
        {
            int random = UnityEngine.Random.Range(0, 2000);
            int profileCount = UnityEngine.Random.Range(1, 7);
            Models.DemoPlayers.Add(new DemoPlayer { Name = "Player " + random, Icon = Assets.Sprites["ProfilePicture" + profileCount] });
        }
    }
}
