#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class LevelHighscores : BindableObject
    {
        private Level _level;
        public Level Level
        {
            get { return _level; }
            set { SetProperty(ref _level, value); }
        }

        private ObservableList<Highscore> _highscores;
        public ObservableList<Highscore> Highscores
        {
            get { return _highscores; }
            set { SetProperty(ref _highscores, value); }
        }

        private Highscore _selectedHighscore;
        public Highscore SelectedHighscore
        {
            get { return _selectedHighscore; }
            set { SetProperty(ref _selectedHighscore, value); }
        }

        public LevelHighscores()
        {
            _highscores = new ObservableList<Highscore>(Models.Highscores.Where(x => x.Level == _level));
        }
    }
}
