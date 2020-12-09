#region Using Statements
using PlayFab.ClientModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    /// <summary>
    /// Represents a player profile.
    /// </summary>
    public partial class PlayFabUserDataRecord : ModelObject
    {
        #region Properties

        /// <summary>
        /// Timestamp for when this data was last updated.
        /// </summary>
        private DateTime? _LastUpdated;
        public DateTime? LastUpdated
        {
            get { return _LastUpdated; }
            set { SetProperty(ref _LastUpdated, value); }
        }

        /// <summary>
        /// Indicates whether this data can be read by all users (public) or only the user (private). This is used for GetUserData
        /// requests being made by one player about another player.
        /// </summary>
        public UserDataPermission? _Permission;
        public UserDataPermission? Permission { get { return _Permission; } set { SetProperty(ref _Permission, value); } }


        /// <summary>
        /// Data stored for the specified user data key.
        /// </summary>
        public string _Value;
        public string Value { get { return _Value; } set { SetProperty(ref _Value, value); } }

        #endregion
    }

    #region Data Provider

    public partial class PlayFabUserDataRecordData : DataProvider<PlayFabUserDataRecord>
    {
#if DELIGHT_MODULE_PLAYFAB

        #region Methods

        /*public override async Task<PlayFabUserDataRecord> GetAsync(string id, bool forceUpdate = false)
        {
            if (!forceUpdate)
            {
                if (Data.TryGetValue(id, out var currentRecord))
                {
                    return currentRecord;
                }
            }

            var result = await PlayFabServices.GetPlayerProfile(id);
            if (result.Success)
            {
                var playFabPlayerProfile = result.Result.PlayerProfile;
                var playerProfile = PlayFabServices.FromPlayerProfileModel(playFabPlayerProfile);
                Models.PlayFabPlayerProfiles.Add(playerProfile, false);
                return playerProfile;
            }
            else
            {
                return null;
            }
        }*/
        #endregion

#endif
    }

    #endregion
    public static partial class Models
    {
        public static PlayFabUserDataRecordData PlayFabUserDataRecords = new PlayFabUserDataRecordData();
    }
}
