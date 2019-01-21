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

        // TODO remove
        private Player _childPlayer;
        public Player ChildPlayer
        {
            get { return _childPlayer; }
            set { SetProperty(ref _childPlayer, value); }
        }
    }

    public abstract class DataProvider<T> : BindableCollection<T>
        where T : BindableObject
    {
    }

    public partial class PlayerData : DataProvider<Player>
    {
        private Player _player1;
        public Player Player1
        {
            get { return _player1; }
            set
            {
                SetProperty(ref _player1, value);
            } 
        }

        public PlayerData()
        {
            Player1 = new Player
            {
                Id = "Player1",
                Name = "Player 1",
                ChildPlayer = new Player
                {
                    Name = "Player 1.1",
                    ChildPlayer = new Player
                    {
                        Name = "Player 1.1.1"
                    }
                }
            };
            Add(Player1);
            Add(new Player
            {
                Id = "Player2",
                Name = "Player 2",
                ChildPlayer = new Player
                {
                    Name = "Player 2.1",
                    ChildPlayer = new Player
                    {
                        Name = "Player 2.1.1"
                    }
                }
            });
            Add(new Player
            {
                Id = "Player3",
                Name = "Player 3",
                ChildPlayer = new Player
                {
                    Name = "Player 3.1",
                    ChildPlayer = new Player
                    {
                        Name = "Player 3.1.1"
                    }
                }
            });
            Add(new Player
            {
                Id = "Player4",
                Name = "Player 4",
                ChildPlayer = new Player
                {
                    Name = "Player 4.1",
                    ChildPlayer = new Player
                    {
                        Name = "Player 4.1.1"
                    }
                }
            });
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
