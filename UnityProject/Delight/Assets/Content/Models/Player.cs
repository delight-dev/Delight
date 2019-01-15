#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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

    public class DataProvider<T> : BindableObject
    {
    }

    public partial class PlayerData : DataProvider<Player>
    {
        private Player _player1;
        public Player Player1
        {
            get { return _player1; }
            set { SetProperty(ref _player1, value); }
        }

        public PlayerData()
        {
            _player1 = new Player { Name = "Patrik" };
        }
    }

    public static partial class Models
    {
        public static PlayerData Players = new PlayerData();

        // bootstrapping
        static Models()
        {
            Debug.Log("Models bootstrapper called");
        }
    }
}
