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

        public string PlayerId { get; set; }
        public Player Player
        {
            get { return Models.Players[PlayerId]; }
            set { PlayerId = value?.Id; }
        }

        public string IconId { get; set; }
        public SpriteAsset Icon
        {
            get { return Assets.Sprites[IconId]; }
            set { IconId = value?.Id; }
        }

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
        #region Constructor


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
