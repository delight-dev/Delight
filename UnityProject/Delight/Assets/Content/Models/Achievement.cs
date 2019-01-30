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
    public partial class Achievement : BindableObject
    {
        public string AchievementSpriteId { get; set; }
        public SpriteAsset AchievementSprite
        {
            get { return Assets.Sprites[AchievementSpriteId]; }
            set { AchievementSpriteId = value?.Id; }
        }

        public string PlayerId { get; set; }
        public Player Player
        {
            get { return Models.Players[PlayerId]; }
            set { PlayerId = value?.Id; }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
    }

    public partial class AchievementData : DataProvider<Achievement>
    {
        public AchievementData()
        {
            Add(new Achievement { PlayerId = "Player1", Title = "A1-1" });
            Add(new Achievement { PlayerId = "Player1", Title = "A1-2" });
            Add(new Achievement { PlayerId = "Player1", Title = "A1-3" });
            Add(new Achievement { PlayerId = "Player1", Title = "A1-4" });
            Add(new Achievement { PlayerId = "Player2", Title = "A2-1" });
            Add(new Achievement { PlayerId = "Player2", Title = "A2-2" });
            Add(new Achievement { PlayerId = "Player2", Title = "A2-3" });
            Add(new Achievement { PlayerId = "Player3", Title = "A3-1" });
            Add(new Achievement { PlayerId = "Player3", Title = "A3-2" });
            Add(new Achievement { PlayerId = "Player4", Title = "A4-1" });
        }

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
    }

    public static partial class Models
    {
        public static AchievementData Achievements = new AchievementData();
    }
}
