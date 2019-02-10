#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
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

        public BindableCollection<Achievement> Achievements
        {
            get { return Models.Achievements.Get(this); }
        }

        public BindableCollection<Highscore> Highscores
        {
            get { return Models.Highscores.Get(this); }
        }
    }

    public partial class PlayerData : DataProvider<Player>
    {
        public PlayerData()
        {
            Add(new Player { Id = "Player1", Name = "Player 1" });
            Add(new Player { Id = "Player2", Name = "Player 2" });
            Add(new Player { Id = "Player3", Name = "Player 3" });
            Add(new Player { Id = "Player4", Name = "Player 4" });
        }
    }

    public static partial class Models
    {
        public static PlayerData Players = new PlayerData();
    }
}
