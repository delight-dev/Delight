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
        // TODO may contain additional methods such as "Save" for persisting data and LoadAll for fetching data
        // e.g. from a server. For this to work we want a way to track if an item is "dirty"
        // this can be extended with data providers that take parameters through Get method or maybe specified
        // as generic type parameters
    }

    public partial class PlayerData : DataProvider<Player>
    {
        public Player Player1 { get; }

        public PlayerData()
        {
            Player1 = new Player { Name = "Patrik" };
            Add(Player1);
        }

        //private Player _player1;
        //public Player Player1
        //{
        //    get { return _player1; }
        //    //set { SetProperty(ref _player1, value); }
        //}
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
