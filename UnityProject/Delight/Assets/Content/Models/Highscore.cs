#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class Highscore : BindableObject
    {
        private Level _level;
        public Level Level
        {
            get { return _level; }
            set { SetProperty(ref _level, value); }
        }

        private Player _player;
        public Player Player
        {
            get { return _player; }
            set { SetProperty(ref _player, value); }
        }

        private int _score;
        public int Score
        {
            get { return _score; }
            set { SetProperty(ref _score, value); }
        }
    }

    public static partial class Models
    {
        public static ObservableList<Highscore> Highscores = new ObservableList<Highscore>();
    }
}
