#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class Player : BindableObject
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }
    }

    public abstract class DataProvider<T> : BindableCollection<T>
    {
    }

    public partial class PlayerData : DataProvider<Player>
    {
        public Player Player1 { get; }

        public PlayerData()
        {
            Player1 = new Player { Name = "Patrik" };
            Add(Player1);
        }
    }

    public static partial class Models
    {
        public static PlayerData Players = new PlayerData();

        static Models()
        {
            // TODO lookup model bootstrappers and execute them
        }
    }
}
