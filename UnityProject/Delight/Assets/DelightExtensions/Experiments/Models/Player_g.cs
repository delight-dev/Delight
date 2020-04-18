// Model generated from "Schema.txt"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class Player : ModelObject
    {
        #region Properties

        [SerializeField]
        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        [SerializeField]
        private Color _color;
        public Color Color
        {
            get { return _color; }
            set { SetProperty(ref _color, value); }
        }

        public BindableCollection<Highscore> Highscores
        {
            get { return Models.Highscores.Get(this); }
        }

        public BindableCollection<Achievement> Achievements
        {
            get { return Models.Achievements.Get(this); }
        }

        #endregion
    }

    #region Data Provider

    public partial class PlayerData : DataProvider<Player>
    {
        #region Fields

        public readonly Player Player1;
        public readonly Player Player2;
        public readonly Player Player3;
        public readonly Player Player4;

        #endregion

        #region Constructor

        public PlayerData()
        {
            Player1 = new Player { Id = "Player1", Name = "Player 1" };
            Add(Player1);
            Player2 = new Player { Id = "Player2", Name = "Player 2" };
            Add(Player2);
            Player3 = new Player { Id = "Player3", Name = "Player 3" };
            Add(Player3);
            Player4 = new Player { Id = "Player4", Name = "Player 4" };
            Add(Player4);
        }

        #endregion
    }

    public static partial class Models
    {
        public static PlayerData Players = new PlayerData();
    }

    #endregion
}
