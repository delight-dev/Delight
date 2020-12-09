#region Using Statements
using PlayFab;
using PlayFab.ClientModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    /// <summary>
    /// User represents the PlayFab user view model.
    /// </summary>
    public partial class PlayFabUser : ModelObject
    {
        #region Properties

        [SerializeField]
        private bool _isLoggedIn;
        public bool IsLoggedIn
        {
            get { return _isLoggedIn; }
            set { SetProperty(ref _isLoggedIn, value); }
        }

        [SerializeField]
        private bool _isLoggingIn;
        public bool IsLoggingIn
        {
            get { return _isLoggingIn; }
            set { SetProperty(ref _isLoggingIn, value); }
        }

        [SerializeField]
        private bool _loggedInFailed;
        public bool LoggedInFailed
        {
            get { return _loggedInFailed; }
            set { SetProperty(ref _loggedInFailed, value); }
        }

        [SerializeField]
        private string _loggedInFailedMessage;
        public string LoggedInFailedMessage
        {
            get { return _loggedInFailedMessage; }
            set { SetProperty(ref _loggedInFailedMessage, value); }
        }

        [SerializeField]
        private PlayFabPlayerProfile _playerProfile;
        public PlayFabPlayerProfile PlayerProfile
        {
            get { return _playerProfile; }
            set { SetProperty(ref _playerProfile, value); }
        }

        [SerializeField]
        private bool _isRegistering;
        public bool IsRegistering
        {
            get { return _isRegistering; }
            set { SetProperty(ref _isRegistering, value); }
        }

        [SerializeField]
        private bool _registrationFailed;
        public bool RegistrationFailed
        {
            get { return _registrationFailed; }
            set { SetProperty(ref _registrationFailed, value); }
        }

        [SerializeField]
        private string _registrationFailedMessage;
        public string RegistrationFailedMessage
        {
            get { return _registrationFailedMessage; }
            set { SetProperty(ref _registrationFailedMessage, value); }
        }

        private BindableCollection<PlayFabPlayerProfile> _friends;
        /// <summary>
        /// List of player friends.
        /// </summary>
        public BindableCollection<PlayFabPlayerProfile> Friends
        {
            get { return _friends; }
            set { SetProperty(ref _friends, value); }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Logs in the user using email and password.
        /// </summary>
        public async Task LogIn(string email, string password, bool newAccount = false)
        {
#if DELIGHT_MODULE_PLAYFAB
            IsLoggingIn = true;
            LoggedInFailed = false;
            IsLoggedIn = false;

            // log in 
            var result = await PlayFabServices.LoginWithEmailAddress(email, password);
            if (!result.Success)
            {
                IsLoggingIn = false;
                IsLoggedIn = false;
                LoggedInFailed = true;
                LoggedInFailedMessage = result.Error.ErrorMessage;
                return;
            }

            // create PlayerProfile object from the payload
            var playFabPlayerProfile = result.Result.InfoResultPayload.PlayerProfile;
            var playerProfile = PlayFabServices.FromPlayerProfileModel(playFabPlayerProfile, result.Result.InfoResultPayload.UserData, result.Result.InfoResultPayload.UserInventory);
            Models.PlayFabPlayerProfiles.Add(playerProfile);
            PlayerProfile = playerProfile;

            // load list of friends
            var getFriendsResult = await PlayFabServices.GetFriendsList();
            if (getFriendsResult.Success)
            {
                var friends = new List<PlayFabPlayerProfile>();
                foreach (var friendInfo in getFriendsResult.Result.Friends)
                {
                    var friendProfile = PlayFabServices.FromPlayerProfileModel(friendInfo.Profile);
                    friends.Add(friendProfile);
                }

                Models.PlayFabPlayerProfiles.AddRange(friends);
                Friends.Replace(friends);
            }

            IsLoggingIn = false;
            IsLoggedIn = true;
            Messenger.Send(UserLoggedInMessage.Default);
#else
            await Task.FromResult(0); // just to prevent compiler warning
#endif
        }

        /// <summary>
        /// Logs in the user using custom ID.
        /// </summary>
        public async Task LogInWithCustomID(string customId)
        {
#if DELIGHT_MODULE_PLAYFAB
            IsLoggingIn = true;
            LoggedInFailed = false;

            // log in 
            var result = await PlayFabServices.LoginWithCustomID(customId);
            if (!result.Success)
            {
                IsLoggingIn = false;
                IsLoggedIn = false;
                LoggedInFailed = true;
                LoggedInFailedMessage = result.Error.ErrorMessage;
                return;
            }

            // create PlayerProfile object from the payload
            var playFabPlayerProfile = result?.Result?.InfoResultPayload?.PlayerProfile;
            if (playFabPlayerProfile != null)
            {
                var playerProfile = PlayFabServices.FromPlayerProfileModel(playFabPlayerProfile, result.Result.InfoResultPayload.UserData, result.Result.InfoResultPayload.UserInventory);
                Models.PlayFabPlayerProfiles.Add(playerProfile);
                PlayerProfile = playerProfile;
            }

            IsLoggingIn = false;
            IsLoggedIn = true;
#else
            await Task.FromResult(0); // just to prevent compiler warning
#endif
        }

        /// <summary>
        /// Registers new user and logs in.
        /// </summary>
        public async Task RegisterAndLogin(string email, string password)
        {
#if DELIGHT_MODULE_PLAYFAB
            // register user
            IsRegistering = true;
            RegistrationFailed = false;

            // register user
            var result = await PlayFabServices.RegisterWithEmailAddress(email, password);

            IsRegistering = false;
            if (result.Success)
            {
                IsRegistering = false;
            }
            else
            {
                RegistrationFailedMessage = result.Error.ErrorMessage;
                RegistrationFailed = true;
                return;
            }

            // log in
            await LogIn(email, password, true);
#else
            await Task.FromResult(0); // just to prevent compiler warning
#endif
        }

        /// <summary>
        /// Log out.
        /// </summary>
        public void LogOut()
        {
            IsLoggedIn = false;
        }

        /// <summary>
        /// Adds friend.
        /// </summary>
        public async Task AddFriend(string playerId)
        {
#if DELIGHT_MODULE_PLAYFAB
            // add friend 
            var result = await PlayFabServices.AddFriend(playerId);
            if (result.Success)
            {
                // get friend profile info
                var getPlayerProfileResult = await PlayFabServices.GetPlayerProfile(playerId);
                if (getPlayerProfileResult.Success)
                {
                    // TODO maybe add implicit converter to make this cleaner
                    Friends.Add(PlayFabServices.FromPlayerProfileModel(getPlayerProfileResult.Result.PlayerProfile));
                }
            }
#else
            await Task.FromResult(0); // just to prevent compiler warning
#endif
        }

        /// <summary>
        /// Remove friend.
        /// </summary>
        public async Task RemoveFriend(string playerId)
        {
#if DELIGHT_MODULE_PLAYFAB
            var result = await PlayFabServices.RemoveFriend(playerId);
            if (result.Success)
            {
                var removedFriend = Friends?.FirstOrDefault(x => x.Id == playerId);
                if (removedFriend != null)
                {
                    Friends.Remove(removedFriend);
                }
            }
#else
            await Task.FromResult(0); // just to prevent compiler warning
#endif
        }

        /// <summary>
        /// Searches for player.
        /// </summary>
        public async Task<PlayFabPlayerProfile> SearchForPlayer(string displayName)
        {
#if DELIGHT_MODULE_PLAYFAB
            // add friend 
            var result = await PlayFabServices.GetAccountInfo(new GetAccountInfoRequest { TitleDisplayName = displayName });
            if (result.Success)
            {
                // get friend profile info
                var getPlayerProfileResult = await PlayFabServices.GetPlayerProfile(result.Result.AccountInfo.PlayFabId);
                if (getPlayerProfileResult.Success)
                {
                    return PlayFabServices.FromPlayerProfileModel(getPlayerProfileResult.Result.PlayerProfile);
                }
            }

            return null;
#else
            await Task.FromResult(0); // just to prevent compiler warning
#endif
        }

        #endregion

        #region Constructor

        public PlayFabUser()
        {
            Friends = new BindableCollection<PlayFabPlayerProfile>();
        }

        #endregion
    }

    #region Data Provider

    public partial class PlayFabUserData : DataProvider<PlayFabUser>
    {
        #region Methods
        #endregion
    }

    public static partial class Models
    {
        public static PlayFabUser PlayFabUser = new PlayFabUser();
    }

    #endregion
}

