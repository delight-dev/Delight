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
    public partial class Achievement : ModelObject
    {
        #region Properties

        [SerializeField]
        public string PlayerId { get; set; }
        public Player Player
        {
            get { return Models.Players[PlayerId]; }
            set { PlayerId = value?.Id; }
        }

        [SerializeField]
        public string IconId { get; set; }
        public SpriteAsset Icon
        {
            get { return Assets.Sprites[IconId]; }
            set { IconId = value?.Id; }
        }

        [SerializeField]
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        #endregion
    }

    #region Data Provider

    public partial class AchievementData : DataProvider<Achievement>
    {
        #region Fields


        #endregion

        #region Constructor

        public AchievementData()
        {
            Add(new Achievement { PlayerId = "Player1", Title = "A1-3" });
            Add(new Achievement { PlayerId = "Player1", Title = "A1-4" });
            Add(new Achievement { PlayerId = "Player2", Title = "A2-1" });
            Add(new Achievement { PlayerId = "Player2", Title = "A2-2" });
            Add(new Achievement { PlayerId = "Player2", Title = "A2-3" });
            Add(new Achievement { PlayerId = "Player3", Title = "A3-1" });
            Add(new Achievement { PlayerId = "Player3", Title = "A3-2" });
            Add(new Achievement { PlayerId = "Player4", Title = "A4-1" });
            Add(new Achievement { PlayerId = "Player5", Title = "A5-1" });
            Add(new Achievement { PlayerId = "Player5", Title = "A5-2" });
        }

        #endregion

        #region Methods

        protected Dictionary<string, BindableCollectionSubset<Achievement>> _playerAchievements = new Dictionary<string, BindableCollectionSubset<Achievement>>();
        public virtual BindableCollectionSubset<Achievement> Get(Player player)
        {
            if (player == null)
                return null;

            string playerId = player.Id;
            BindableCollectionSubset<Achievement> playerAchievements;
            if (_playerAchievements.TryGetValue(playerId, out playerAchievements))
                return playerAchievements;

            playerAchievements = new BindableCollectionSubset<Achievement>(this, x => x.PlayerId == playerId, x => x.PlayerId = playerId);
            _playerAchievements.Add(playerId, playerAchievements);
            return playerAchievements;
        }

        #endregion
    }

    public static partial class Models
    {
        public static AchievementData Achievements = new AchievementData();
    }

    #endregion
}
