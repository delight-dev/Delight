#region Using Statements
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
    public partial class PlayFabPlayerProfile : ModelObject
    {
        #region Properties

        [SerializeField]
        private string _displayName = string.Empty;
        /// <summary>
        /// Player display name
        /// </summary>
        public string DisplayName
        {
            get { return _displayName; }
            set { SetProperty(ref _displayName, value); }
        }

        [SerializeField]
        private string _avatarUrl;
        /// <summary>
        /// URL of the player's avatar image
        /// </summary>
        public string AvatarUrl
        {
            get { return _avatarUrl; }
            set { SetProperty(ref _avatarUrl, value); }
        }

        private BindableCollection<PlayFabAdCampaignAttribution> _AdCampaignAttributions;
        /// <summary>
        /// List of advertising campaigns the player has been attributed to
        /// </summary>
        public BindableCollection<PlayFabAdCampaignAttribution> AdCampaignAttributions
        {
            get { return _AdCampaignAttributions; }
            set { SetProperty(ref _AdCampaignAttributions, value); }
        }

        private DateTime? _BannedUntil;
        /// <summary>
        /// If the player is currently banned, the UTC Date when the ban expires
        /// </summary>
        public DateTime? BannedUntil
        {
            get { return _BannedUntil; }
            set { SetProperty(ref _BannedUntil, value); }
        }

        private BindableCollection<PlayFabContactEmailInfo> _ContactEmailAddresses;
        /// <summary>
        /// List of all contact email info associated with the player account
        /// </summary>
        public BindableCollection<PlayFabContactEmailInfo> ContactEmailAddresses
        {
            get { return _ContactEmailAddresses; }
            set { SetProperty(ref _ContactEmailAddresses, value); }
        }

        private DateTime? _Created;
        /// <summary>
        /// Player record created
        /// </summary>
        public DateTime? Created
        {
            get { return _Created; }
            set { SetProperty(ref _Created, value); }
        }

        private List<string> _ExperimentVariants;
        /// <summary>
        /// List of experiment variants for the player.
        /// </summary>
        public List<string> ExperimentVariants
        {
            get { return _ExperimentVariants; }
            set { SetProperty(ref _ExperimentVariants, value); }
        }

        private DateTime? _LastLogin;
        /// <summary>
        /// UTC time when the player most recently logged in to the title
        /// </summary>
        public DateTime? LastLogin
        {
            get { return _LastLogin; }
            set { SetProperty(ref _LastLogin, value); }
        }

        private BindableCollection<PlayFabLinkedPlatformAccount> _LinkedAccounts;
        /// <summary>
        /// List of all authentication systems linked to this player account
        /// </summary>
        public BindableCollection<PlayFabLinkedPlatformAccount> LinkedAccounts
        {
            get { return _LinkedAccounts; }
            set { SetProperty(ref _LinkedAccounts, value); }
        }

        private BindableCollection<PlayFabLocation> _Locations;
        /// <summary>
        /// List of geographic locations from which the player has logged in to the title
        /// </summary>
        public BindableCollection<PlayFabLocation> Locations
        {
            get { return _Locations; }
            set { SetProperty(ref _Locations, value); }
        }

        private BindableCollection<PlayFabMembership> _Memberships;
        /// <summary>
        /// List of memberships for the player, along with whether are expired.
        /// </summary>
        public BindableCollection<PlayFabMembership> Memberships
        {
            get { return _Memberships; }
            set { SetProperty(ref _Memberships, value); }
        }

        private PlayFab.ClientModels.LoginIdentityProvider? _Origination;
        /// <summary>
        /// Player account origination
        /// </summary>
        public PlayFab.ClientModels.LoginIdentityProvider? Origination
        {
            get { return _Origination; }
            set { SetProperty(ref _Origination, value); }
        }

        private string _PublisherId;
        /// <summary>
        /// Publisher this player belongs to
        /// </summary>
        public string PublisherId
        {
            get { return _PublisherId; }
            set { SetProperty(ref _PublisherId, value); }
        }

        private BindableCollection<PlayFabPushNotificationRegistration> _PushNotificationRegistrations;
        /// <summary>
        /// List of configured end points registered for sending the player push notifications
        /// </summary>
        public BindableCollection<PlayFabPushNotificationRegistration> PushNotificationRegistrations
        {
            get { return _PushNotificationRegistrations; }
            set { SetProperty(ref _PushNotificationRegistrations, value); }
        }

        private BindableCollection<PlayFabStatistic> _Statistics;
        /// <summary>
        /// List of leaderboard statistic values for the player
        /// </summary>
        public BindableCollection<PlayFabStatistic> Statistics
        {
            get { return _Statistics; }
            set { SetProperty(ref _Statistics, value); }
        }

        private BindableCollection<PlayFabTag> _Tags;
        /// <summary>
        /// List of player's tags for segmentation
        /// </summary>
        public BindableCollection<PlayFabTag> Tags
        {
            get { return _Tags; }
            set { SetProperty(ref _Tags, value); }
        }

        private string _TitleId;
        /// <summary>
        /// Title ID this player profile applies to
        /// </summary>
        public string TitleId
        {
            get { return _TitleId; }
            set { SetProperty(ref _TitleId, value); }
        }

        private uint? _TotalValueToDateInUSD;
        /// <summary>
        /// Sum of the player's purchases made with real-money currencies, converted to US dollars equivalent and represented as a
        /// whole number of cents (1/100 USD). For example, 999 indicates nine dollars and ninety-nine cents.
        /// </summary>
        public uint? TotalValueToDateInUSD
        {
            get { return _TotalValueToDateInUSD; }
            set { SetProperty(ref _TotalValueToDateInUSD, value); }
        }

        private BindableCollection<PlayFabValueToDate> _ValuesToDate;
        /// <summary>
        /// List of the player's lifetime purchase totals, summed by real-money currency
        /// </summary>
        public BindableCollection<PlayFabValueToDate> ValuesToDate
        {
            get { return _ValuesToDate; }
            set { SetProperty(ref _ValuesToDate, value); }
        }

        private BindableCollection<PlayFabInventoryItem> _InventoryItems;
        /// <summary>
        /// List of player's inventory items. 
        /// </summary>
        public BindableCollection<PlayFabInventoryItem> InventoryItems
        {
            get { return _InventoryItems; }
            set { SetProperty(ref _InventoryItems, value); }
        }

        private Dictionary<string, PlayFabUserDataRecord> _UserData;
        /// <summary>
        /// Custom data for item.
        /// </summary>
        public Dictionary<string, PlayFabUserDataRecord> UserData
        {
            get { return _UserData; }
            set { SetProperty(ref _UserData, value); }
        }

        #endregion

        #region Methods
        #endregion
    }

    #region Data Provider

    public partial class PlayFabPlayerProfileData : DataProvider<PlayFabPlayerProfile>
    {
#if DELIGHT_MODULE_PLAYFAB

        #region Methods

        /// <summary>
        /// Loads specified data asynchronously.
        /// </summary>
        public async Task<PlayFabPlayerProfile> GetAsync(string id)
        {
            if (Data.TryGetValue(id, out var currentProfile))
            {
                return currentProfile;
            }

            var result = await PlayFabServices.GetPlayerProfile(id);
            if (result.Success)
            {
                var playFabPlayerProfile = result.Result.PlayerProfile;
                var playerProfile = PlayFabServices.FromPlayerProfileModel(playFabPlayerProfile);
                Models.PlayFabPlayerProfiles.Add(playerProfile);
                return playerProfile;
            }
            else
            {
                return null;
            }
        }

        #endregion

#endif
    }

    public static partial class Models
    {
        public static PlayFabPlayerProfileData PlayFabPlayerProfiles = new PlayFabPlayerProfileData();
    }

    #endregion
}
