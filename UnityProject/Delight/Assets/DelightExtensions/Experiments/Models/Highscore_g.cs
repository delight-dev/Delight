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
    public partial class Highscore : ModelObject
    {
        #region Properties

        [SerializeField]
        public string LevelId { get; set; }
        public Level Level
        {
            get { return Models.Levels[LevelId]; }
            set { LevelId = value?.Id; }
        }

        [SerializeField]
        public string PlayerId { get; set; }
        public Player Player
        {
            get { return Models.Players[PlayerId]; }
            set { PlayerId = value?.Id; }
        }

        [SerializeField]
        private int _score;
        public int Score
        {
            get { return _score; }
            set { SetProperty(ref _score, value); }
        }

        #endregion
    }

    #region Data Provider

    public partial class HighscoreData : DataProvider<Highscore>
    {
        #region Fields


        #endregion

        #region Constructor

        public HighscoreData()
        {
            Add(new Highscore { LevelId = "Level1_1", PlayerId = "Player1", Score = 88789 });
            Add(new Highscore { LevelId = "Level1_2", PlayerId = "Player2", Score = 33579 });
            Add(new Highscore { LevelId = "Level1_3", PlayerId = "Player3", Score = 13897 });
            Add(new Highscore { LevelId = "Level1_4", PlayerId = "Player4", Score = 12335 });
            Add(new Highscore { LevelId = "Level1_1", PlayerId = "Player5", Score = 5471 });
            Add(new Highscore { LevelId = "Level2_2", PlayerId = "Player6", Score = 1547 });
            Add(new Highscore { LevelId = "Level3_3", PlayerId = "Player7", Score = 1235 });
            Add(new Highscore { LevelId = "Level1_4", PlayerId = "Player8", Score = 878 });
            Add(new Highscore { LevelId = "Level2_3", PlayerId = "Player9", Score = 380 });
            Add(new Highscore { LevelId = "Level1_1", PlayerId = "Player10", Score = 187 });
            Add(new Highscore { LevelId = "Level1_1", PlayerId = "Player11", Score = 48 });
            Add(new Highscore { LevelId = "Level1_2", PlayerId = "Player12", Score = 18 });
            Add(new Highscore { LevelId = "Level1_2", PlayerId = "Player13", Score = 18 });
        }

        #endregion

        #region Methods

        protected Dictionary<string, BindableCollectionSubset<Highscore>> _levelHighscores = new Dictionary<string, BindableCollectionSubset<Highscore>>();
        public virtual BindableCollectionSubset<Highscore> Get(Level level)
        {
            if (level == null)
                return null;

            string levelId = level.Id;
            BindableCollectionSubset<Highscore> levelHighscores;
            if (_levelHighscores.TryGetValue(levelId, out levelHighscores))
                return levelHighscores;

            levelHighscores = new BindableCollectionSubset<Highscore>(this, x => x.LevelId == levelId, x => x.LevelId = levelId);
            _levelHighscores.Add(levelId, levelHighscores);
            return levelHighscores;
        }

        protected Dictionary<string, BindableCollectionSubset<Highscore>> _playerHighscores = new Dictionary<string, BindableCollectionSubset<Highscore>>();
        public virtual BindableCollectionSubset<Highscore> Get(Player player)
        {
            if (player == null)
                return null;

            string playerId = player.Id;
            BindableCollectionSubset<Highscore> playerHighscores;
            if (_playerHighscores.TryGetValue(playerId, out playerHighscores))
                return playerHighscores;

            playerHighscores = new BindableCollectionSubset<Highscore>(this, x => x.PlayerId == playerId, x => x.PlayerId = playerId);
            _playerHighscores.Add(playerId, playerHighscores);
            return playerHighscores;
        }

        #endregion
    }

    public static partial class Models
    {
        public static HighscoreData Highscores = new HighscoreData();
    }

    #endregion
}
