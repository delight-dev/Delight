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
        public readonly Player Player5;
        public readonly Player Player6;
        public readonly Player Player7;
        public readonly Player Player8;
        public readonly Player Player9;
        public readonly Player Player10;
        public readonly Player Player11;
        public readonly Player Player12;
        public readonly Player Player13;

        #endregion

        #region Constructor

        public PlayerData()
        {
            Player1 = new Player { Id = "Player1", Name = "Wizball" };
            Add(Player1);
            Player2 = new Player { Id = "Player2", Name = "asdf" };
            Add(Player2);
            Player3 = new Player { Id = "Player3", Name = "Yesper" };
            Add(Player3);
            Player4 = new Player { Id = "Player4", Name = "Jacob4" };
            Add(Player4);
            Player5 = new Player { Id = "Player5", Name = "xCool" };
            Add(Player5);
            Player6 = new Player { Id = "Player6", Name = "pking1" };
            Add(Player6);
            Player7 = new Player { Id = "Player7", Name = "pjkminCoo" };
            Add(Player7);
            Player8 = new Player { Id = "Player8", Name = "Machin1st" };
            Add(Player8);
            Player9 = new Player { Id = "Player9", Name = "DWerck16" };
            Add(Player9);
            Player10 = new Player { Id = "Player10", Name = "Pfauxhypocricy" };
            Add(Player10);
            Player11 = new Player { Id = "Player11", Name = "Bananaman13" };
            Add(Player11);
            Player12 = new Player { Id = "Player12", Name = "Opwiz" };
            Add(Player12);
            Player13 = new Player { Id = "Player13", Name = "afauxicy" };
            Add(Player13);
        }

        #endregion
    }

    public static partial class Models
    {
        public static PlayerData Players = new PlayerData();
    }

    #endregion
}
