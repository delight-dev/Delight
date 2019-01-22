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
            Add(new Achievement { PlayerId = "Player1", Title = "Achievement 1-1" });
            Add(new Achievement { PlayerId = "Player1", Title = "Achievement 1-2" });
            Add(new Achievement { PlayerId = "Player1", Title = "Achievement 1-3" });
            Add(new Achievement { PlayerId = "Player1", Title = "Achievement 1-4" });
            Add(new Achievement { PlayerId = "Player2", Title = "Achievement 2-1" });
            Add(new Achievement { PlayerId = "Player2", Title = "Achievement 2-2" });
            Add(new Achievement { PlayerId = "Player2", Title = "Achievement 2-3" });
            Add(new Achievement { PlayerId = "Player2", Title = "Achievement 2-4" });
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

            playerAchievements = new BindableCollectionSubset<Achievement>(this, x => x.PlayerId == playerId);
            _playerAchievements.Add(playerId, playerAchievements);
            return playerAchievements;
        }
    }

    public static partial class Models
    {
        public static AchievementData Achievements = new AchievementData();
    }
}
