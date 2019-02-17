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
        public string LevelId { get; set; }
        public Level Level
        {
            get { return Models.Levels[LevelId]; }
            set { LevelId = value?.Id; }
        }

        public string PlayerId { get; set; }
        public Player Player
        {
            get { return Models.Players[PlayerId]; }
            set { PlayerId = value?.Id; }
        }

        private int _score;
        public int Score
        {
            get { return _score; }
            set { SetProperty(ref _score, value); }
        }

        public string ScoreText
        {
            get { return _score.ToString(); }
        }
    }

    public partial class HighscoreData : DataProvider<Highscore>
    {
        public HighscoreData()
        {
            Add(new Highscore { PlayerId = "Player1", LevelId = "Level1_1", Score = 380 });
            Add(new Highscore { PlayerId = "Player1", LevelId = "Level1_2", Score = 5471 });
            Add(new Highscore { PlayerId = "Player1", LevelId = "Level1_3", Score = 1547 });
            Add(new Highscore { PlayerId = "Player1", LevelId = "Level1_4", Score = 33579 });
            Add(new Highscore { PlayerId = "Player2", LevelId = "Level1_1", Score = 1235 });
            Add(new Highscore { PlayerId = "Player2", LevelId = "Level2_2", Score = 187 });
            Add(new Highscore { PlayerId = "Player2", LevelId = "Level3_3", Score = 13897 });
            Add(new Highscore { PlayerId = "Player3", LevelId = "Level1_4", Score = 88789 });
            Add(new Highscore { PlayerId = "Player3", LevelId = "Level2_3", Score = 12335 });
            Add(new Highscore { PlayerId = "Player3", LevelId = "Level1_1", Score = 878 });
            Add(new Highscore { PlayerId = "Player4", LevelId = "Level1_1", Score = 48 });
            Add(new Highscore { PlayerId = "Player4", LevelId = "Level1_2", Score = 18 });
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
    }

    public static partial class Models
    {
        public static HighscoreData Highscores = new HighscoreData();
    }
}
