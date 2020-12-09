#if DELIGHT_MODULE_PLAYFAB

#region Using Statements
using PlayFab;
using PlayFab.ClientModels;
using PlayFab.Internal;
using PlayFab.SharedModels;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    /// <summary>
    /// Helper methods for integrating Delight with PlayFab. Converts PlayFab async callback methods to async/await. 
    /// </summary>
    public static class PlayFabServices
    {
        #region Methods

        #region Service Calls

        /// <summary>
        /// Verify client login.
        /// </summary>
        public static bool IsClientLoggedIn()
        {
            return PlayFabSettings.staticPlayer.IsClientLoggedIn();
        }

        /// <summary>
        /// Clear the Client SessionToken which allows this Client to call API calls requiring login.
        /// A new/fresh login will be required after calling this.
        /// </summary>
        public static void ForgetAllCredentials()
        {
            PlayFabSettings.staticPlayer.ForgetAllCredentials();
        }

        /// <summary>
        /// Accepts an open trade (one that has not yet been accepted or cancelled), if the locally signed-in player is in the
        /// allowed player list for the trade, or it is open to all players. If the call is successful, the offered and accepted
        /// items will be swapped between the two players' inventories.
        /// </summary>
        public static Task<PlayFabAcceptTradeResponse> AcceptTrade(AcceptTradeRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabAcceptTradeResponse>();

            PlayFabClientAPI.AcceptTrade(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabAcceptTradeResponse { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabAcceptTradeResponse { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Adds the PlayFab user, based upon a match against a supplied unique identifier, to the friend list of the local user.
        /// </summary>
        public static Task<PlayFabAddFriendResult> AddFriend(string playerId)
        {
            return AddFriend(new AddFriendRequest { FriendPlayFabId = playerId });
        }

        /// <summary>
        /// Adds the PlayFab user, based upon a match against a supplied unique identifier, to the friend list of the local user. At
        /// least one of FriendPlayFabId,FriendUsername,FriendEmail, or FriendTitleDisplayName should be initialized.
        /// </summary>
        public static Task<PlayFabAddFriendResult> AddFriend(AddFriendRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabAddFriendResult>();

            PlayFabClientAPI.AddFriend(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabAddFriendResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabAddFriendResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }



        /// <summary>
        /// Adds the specified generic service identifier to the player's PlayFab account. This is designed to allow for a PlayFab
        /// ID lookup of any arbitrary service identifier a title wants to add. This identifier should never be used as
        /// authentication credentials, as the intent is that it is easily accessible by other players.
        /// </summary>
        public static Task<PlayFabAddGenericIDResult> AddGenericID(AddGenericIDRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabAddGenericIDResult>();

            PlayFabClientAPI.AddGenericID(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabAddGenericIDResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabAddGenericIDResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Adds or updates a contact email to the player's profile.
        /// </summary>
        public static Task<PlayFabAddOrUpdateContactEmailResult> AddOrUpdateContactEmail(AddOrUpdateContactEmailRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabAddOrUpdateContactEmailResult>();

            PlayFabClientAPI.AddOrUpdateContactEmail(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabAddOrUpdateContactEmailResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabAddOrUpdateContactEmailResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Adds users to the set of those able to update both the shared data, as well as the set of users in the group. Only users
        /// in the group can add new members. Shared Groups are designed for sharing data between a very small number of players,
        /// please see our guide: https://docs.microsoft.com/gaming/playfab/features/social/groups/using-shared-group-data
        /// </summary>
        public static Task<PlayFabAddSharedGroupMembersResult> AddSharedGroupMembers(AddSharedGroupMembersRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabAddSharedGroupMembersResult>();

            PlayFabClientAPI.AddSharedGroupMembers(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabAddSharedGroupMembersResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabAddSharedGroupMembersResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Adds playfab username/password auth to an existing account created via an anonymous auth method, e.g. automatic device
        /// ID login.
        /// </summary>
        public static Task<PlayFabAddUsernamePasswordResult> AddUsernamePassword(AddUsernamePasswordRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabAddUsernamePasswordResult>();

            PlayFabClientAPI.AddUsernamePassword(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabAddUsernamePasswordResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabAddUsernamePasswordResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Increments the user's balance of the specified virtual currency by the stated amount
        /// </summary>
        public static Task<PlayFabModifyUserVirtualCurrencyResult> AddUserVirtualCurrency(AddUserVirtualCurrencyRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabModifyUserVirtualCurrencyResult>();

            PlayFabClientAPI.AddUserVirtualCurrency(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabModifyUserVirtualCurrencyResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabModifyUserVirtualCurrencyResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Registers the Android device to receive push notifications
        /// </summary>
        public static Task<PlayFabAndroidDevicePushNotificationRegistrationResult> AndroidDevicePushNotificationRegistration(AndroidDevicePushNotificationRegistrationRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabAndroidDevicePushNotificationRegistrationResult>();

            PlayFabClientAPI.AndroidDevicePushNotificationRegistration(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabAndroidDevicePushNotificationRegistrationResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabAndroidDevicePushNotificationRegistrationResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Attributes an install for advertisment.
        /// </summary>
        public static Task<PlayFabAttributeInstallResult> AttributeInstall(AttributeInstallRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabAttributeInstallResult>();

            PlayFabClientAPI.AttributeInstall(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabAttributeInstallResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabAttributeInstallResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Cancels an open trade (one that has not yet been accepted or cancelled). Note that only the player who created the trade
        /// can cancel it via this API call, to prevent griefing of the trade system (cancelling trades in order to prevent other
        /// players from accepting them, for trades that can be claimed by more than one player).
        /// </summary>
        public static Task<PlayFabCancelTradeResponse> CancelTrade(CancelTradeRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabCancelTradeResponse>();

            PlayFabClientAPI.CancelTrade(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabCancelTradeResponse { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabCancelTradeResponse { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Confirms with the payment provider that the purchase was approved (if applicable) and adjusts inventory and virtual
        /// currency balances as appropriate
        /// </summary>
        public static Task<PlayFabConfirmPurchaseResult> ConfirmPurchase(ConfirmPurchaseRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabConfirmPurchaseResult>();

            PlayFabClientAPI.ConfirmPurchase(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabConfirmPurchaseResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabConfirmPurchaseResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Consume uses of a consumable item. When all uses are consumed, it will be removed from the player's inventory.
        /// </summary>
        public static Task<PlayFabConsumeItemResult> ConsumeItem(ConsumeItemRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabConsumeItemResult>();

            PlayFabClientAPI.ConsumeItem(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabConsumeItemResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabConsumeItemResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Checks for any new consumable entitlements. If any are found, they are consumed and added as PlayFab items
        /// </summary>
        public static Task<PlayFabConsumePSNEntitlementsResult> ConsumePSNEntitlements(ConsumePSNEntitlementsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabConsumePSNEntitlementsResult>();

            PlayFabClientAPI.ConsumePSNEntitlements(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabConsumePSNEntitlementsResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabConsumePSNEntitlementsResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Grants the player's current entitlements from Xbox Live, consuming all availble items in Xbox and granting them to the
        /// player's PlayFab inventory. This call is idempotent and will not grant previously granted items to the player.
        /// </summary>
        public static Task<PlayFabConsumeXboxEntitlementsResult> ConsumeXboxEntitlements(ConsumeXboxEntitlementsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabConsumeXboxEntitlementsResult>();

            PlayFabClientAPI.ConsumeXboxEntitlements(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabConsumeXboxEntitlementsResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabConsumeXboxEntitlementsResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Requests the creation of a shared group object, containing key/value pairs which may be updated by all members of the
        /// group. Upon creation, the current user will be the only member of the group. Shared Groups are designed for sharing data
        /// between a very small number of players, please see our guide:
        /// https://docs.microsoft.com/gaming/playfab/features/social/groups/using-shared-group-data
        /// </summary>
        public static Task<PlayFabCreateSharedGroupResult> CreateSharedGroup(CreateSharedGroupRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabCreateSharedGroupResult>();

            PlayFabClientAPI.CreateSharedGroup(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabCreateSharedGroupResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabCreateSharedGroupResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Executes a CloudScript function, with the 'currentPlayerId' set to the PlayFab ID of the authenticated player.
        /// </summary>
        public static Task<PlayFabExecuteCloudScriptResult> ExecuteCloudScript(ExecuteCloudScriptRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabExecuteCloudScriptResult>();

            PlayFabClientAPI.ExecuteCloudScript(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabExecuteCloudScriptResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabExecuteCloudScriptResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Executes a CloudScript function, with the 'currentPlayerId' set to the PlayFab ID of the authenticated player.
        /// </summary>
        public static Task<PlayFabExecuteCloudScriptResult> ExecuteCloudScript<TOut>(ExecuteCloudScriptRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabExecuteCloudScriptResult>();

            PlayFabClientAPI.ExecuteCloudScript<TOut>(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabExecuteCloudScriptResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabExecuteCloudScriptResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Retrieves the user's PlayFab account details
        /// </summary>
        public static Task<PlayFabGetAccountInfoResult> GetAccountInfo(GetAccountInfoRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabGetAccountInfoResult>();

            PlayFabClientAPI.GetAccountInfo(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetAccountInfoResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetAccountInfoResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Returns a list of ad placements and a reward for each
        /// </summary>
        public static Task<PlayFabGetAdPlacementsResult> GetAdPlacements(GetAdPlacementsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabGetAdPlacementsResult>();

            PlayFabClientAPI.GetAdPlacements(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetAdPlacementsResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetAdPlacementsResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Lists all of the characters that belong to a specific user. CharacterIds are not globally unique; characterId must be
        /// evaluated with the parent PlayFabId to guarantee uniqueness.
        /// </summary>
        public static Task<PlayFabListUsersCharactersResult> GetAllUsersCharacters(ListUsersCharactersRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabListUsersCharactersResult>();

            PlayFabClientAPI.GetAllUsersCharacters(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabListUsersCharactersResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabListUsersCharactersResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Retrieves the specified version of the title's catalog of virtual goods, including all defined properties
        /// </summary>
        public static Task<PlayFabGetCatalogItemsResult> GetCatalogItems(string catalogVersion, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            return GetCatalogItems(new GetCatalogItemsRequest { CatalogVersion = catalogVersion }, customData, extraHeaders);
        }

        /// <summary>
        /// Retrieves the specified version of the title's catalog of virtual goods, including all defined properties
        /// </summary>
        public static Task<PlayFabGetCatalogItemsResult> GetCatalogItems(GetCatalogItemsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabGetCatalogItemsResult>();

            PlayFabClientAPI.GetCatalogItems(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetCatalogItemsResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetCatalogItemsResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Retrieves the title-specific custom data for the character which is readable and writable by the client
        /// </summary>
        public static Task<PlayFabGetCharacterDataResult> GetCharacterData(GetCharacterDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabGetCharacterDataResult>();

            PlayFabClientAPI.GetCharacterData(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetCharacterDataResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetCharacterDataResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Retrieves the specified character's current inventory of virtual goods
        /// </summary>
        public static Task<PlayFabGetCharacterInventoryResult> GetCharacterInventory(GetCharacterInventoryRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabGetCharacterInventoryResult>();

            PlayFabClientAPI.GetCharacterInventory(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetCharacterInventoryResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetCharacterInventoryResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Retrieves a list of ranked characters for the given statistic, starting from the indicated point in the leaderboard
        /// </summary>
        public static Task<PlayFabGetCharacterLeaderboardResult> GetCharacterLeaderboard(GetCharacterLeaderboardRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabGetCharacterLeaderboardResult>();

            PlayFabClientAPI.GetCharacterLeaderboard(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetCharacterLeaderboardResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetCharacterLeaderboardResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Retrieves the title-specific custom data for the character which can only be read by the client
        /// </summary>
        public static Task<PlayFabGetCharacterDataResult> GetCharacterReadOnlyData(GetCharacterDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabGetCharacterDataResult>();

            PlayFabClientAPI.GetCharacterReadOnlyData(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetCharacterDataResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetCharacterDataResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Retrieves the details of all title-specific statistics for the user
        /// </summary>
        public static Task<PlayFabGetCharacterStatisticsResult> GetCharacterStatistics(GetCharacterStatisticsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabGetCharacterStatisticsResult>();

            PlayFabClientAPI.GetCharacterStatistics(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetCharacterStatisticsResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetCharacterStatisticsResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// This API retrieves a pre-signed URL for accessing a content file for the title. A subsequent HTTP GET to the returned
        /// URL will attempt to download the content. A HEAD query to the returned URL will attempt to retrieve the metadata of the
        /// content. Note that a successful result does not guarantee the existence of this content - if it has not been uploaded,
        /// the query to retrieve the data will fail. See this post for more information:
        /// https://community.playfab.com/hc/community/posts/205469488-How-to-upload-files-to-PlayFab-s-Content-Service. Also,
        /// please be aware that the Content service is specifically PlayFab's CDN offering, for which standard CDN rates apply.
        /// </summary>
        public static Task<PlayFabGetContentDownloadUrlResult> GetContentDownloadUrl(GetContentDownloadUrlRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabGetContentDownloadUrlResult>();

            PlayFabClientAPI.GetContentDownloadUrl(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetContentDownloadUrlResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetContentDownloadUrlResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Get details about all current running game servers matching the given parameters.
        /// </summary>
        public static Task<PlayFabCurrentGamesResult> GetCurrentGames(CurrentGamesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabCurrentGamesResult>();

            PlayFabClientAPI.GetCurrentGames(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabCurrentGamesResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabCurrentGamesResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Retrieves a list of ranked friends of the current player for the given statistic, starting from the indicated point in
        /// the leaderboard
        /// </summary>
        public static Task<PlayFabGetLeaderboardResult> GetFriendLeaderboard(GetFriendLeaderboardRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabGetLeaderboardResult>();

            PlayFabClientAPI.GetFriendLeaderboard(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetLeaderboardResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetLeaderboardResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Retrieves a list of ranked friends of the current player for the given statistic, centered on the requested PlayFab
        /// user. If PlayFabId is empty or null will return currently logged in user.
        /// </summary>
        public static Task<PlayFabGetFriendLeaderboardAroundPlayerResult> GetFriendLeaderboardAroundPlayer(GetFriendLeaderboardAroundPlayerRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabGetFriendLeaderboardAroundPlayerResult>();

            PlayFabClientAPI.GetFriendLeaderboardAroundPlayer(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetFriendLeaderboardAroundPlayerResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetFriendLeaderboardAroundPlayerResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Retrieves the current friend list for the local user, constrained to users who have PlayFab accounts.
        /// </summary>
        public static Task<PlayFabGetFriendsListResult> GetFriendsList()
        {
            // TODO include steam and facebook friends by default?
            return GetFriendsList(new GetFriendsListRequest { IncludeFacebookFriends = false, IncludeSteamFriends = false, ProfileConstraints = new PlayerProfileViewConstraints { ShowDisplayName = true, ShowAvatarUrl = true } });
        }

        /// <summary>
        /// Retrieves the current friend list for the local user, constrained to users who have PlayFab accounts. Friends from
        /// linked accounts (Facebook, Steam) are also included. You may optionally exclude some linked services' friends.
        /// </summary>
        public static Task<PlayFabGetFriendsListResult> GetFriendsList(GetFriendsListRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabGetFriendsListResult>();

            PlayFabClientAPI.GetFriendsList(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetFriendsListResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetFriendsListResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Get details about the regions hosting game servers matching the given parameters.
        /// </summary>
        public static Task<PlayFabGameServerRegionsResult> GetGameServerRegions(GameServerRegionsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabGameServerRegionsResult>();

            PlayFabClientAPI.GetGameServerRegions(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabGameServerRegionsResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabGameServerRegionsResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Retrieves a list of ranked users for the given statistic, starting from the indicated point in the leaderboard
        /// </summary>
        public static Task<PlayFabGetLeaderboardResult> GetLeaderboard(GetLeaderboardRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabGetLeaderboardResult>();

            PlayFabClientAPI.GetLeaderboard(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetLeaderboardResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetLeaderboardResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Retrieves a list of ranked characters for the given statistic, centered on the requested Character ID
        /// </summary>
        public static Task<PlayFabGetLeaderboardAroundCharacterResult> GetLeaderboardAroundCharacter(GetLeaderboardAroundCharacterRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabGetLeaderboardAroundCharacterResult>();

            PlayFabClientAPI.GetLeaderboardAroundCharacter(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetLeaderboardAroundCharacterResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetLeaderboardAroundCharacterResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Retrieves a list of ranked users for the given statistic, centered on the requested player. If PlayFabId is empty or
        /// null will return currently logged in user.
        /// </summary>
        public static Task<PlayFabGetLeaderboardAroundPlayerResult> GetLeaderboardAroundPlayer(GetLeaderboardAroundPlayerRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabGetLeaderboardAroundPlayerResult>();

            PlayFabClientAPI.GetLeaderboardAroundPlayer(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetLeaderboardAroundPlayerResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetLeaderboardAroundPlayerResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Retrieves a list of all of the user's characters for the given statistic.
        /// </summary>
        public static Task<PlayFabGetLeaderboardForUsersCharactersResult> GetLeaderboardForUserCharacters(GetLeaderboardForUsersCharactersRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabGetLeaderboardForUsersCharactersResult>();

            PlayFabClientAPI.GetLeaderboardForUserCharacters(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetLeaderboardForUsersCharactersResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetLeaderboardForUsersCharactersResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// For payments flows where the provider requires playfab (the fulfiller) to initiate the transaction, but the client
        /// completes the rest of the flow. In the Xsolla case, the token returned here will be passed to Xsolla by the client to
        /// create a cart. Poll GetPurchase using the returned OrderId once you've completed the payment.
        /// </summary>
        public static Task<PlayFabGetPaymentTokenResult> GetPaymentToken(GetPaymentTokenRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabGetPaymentTokenResult>();

            PlayFabClientAPI.GetPaymentToken(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetPaymentTokenResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetPaymentTokenResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Gets a Photon custom authentication token that can be used to securely join the player into a Photon room. See
        /// https://docs.microsoft.com/gaming/playfab/features/multiplayer/photon/quickstart for more details.
        /// </summary>
        public static Task<PlayFabGetPhotonAuthenticationTokenResult> GetPhotonAuthenticationToken(string photonApplicationId, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            return GetPhotonAuthenticationToken(new GetPhotonAuthenticationTokenRequest { PhotonApplicationId = photonApplicationId }, customData, extraHeaders);
        }

        /// <summary>
        /// Gets a Photon custom authentication token that can be used to securely join the player into a Photon room. See
        /// https://docs.microsoft.com/gaming/playfab/features/multiplayer/photon/quickstart for more details.
        /// </summary>
        public static Task<PlayFabGetPhotonAuthenticationTokenResult> GetPhotonAuthenticationToken(GetPhotonAuthenticationTokenRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabGetPhotonAuthenticationTokenResult>();

            PlayFabClientAPI.GetPhotonAuthenticationToken(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetPhotonAuthenticationTokenResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetPhotonAuthenticationTokenResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Retrieves all of the user's different kinds of info.
        /// </summary>
        public static Task<PlayFabGetPlayerCombinedInfoResult> GetPlayerCombinedInfo(GetPlayerCombinedInfoRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabGetPlayerCombinedInfoResult>();

            PlayFabClientAPI.GetPlayerCombinedInfo(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetPlayerCombinedInfoResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetPlayerCombinedInfoResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Gets player profile and its user data.
        /// </summary>
        public static Task<PlayFabGetPlayerCombinedInfoResult> GetPlayerCombinedInfo(string id)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabGetPlayerCombinedInfoResult>();

            PlayFabClientAPI.GetPlayerCombinedInfo(new GetPlayerCombinedInfoRequest { PlayFabId = id, InfoRequestParameters = DefaultInfoRequestParameters },
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetPlayerCombinedInfoResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetPlayerCombinedInfoResult { Success = false, Error = error });
                }, null, null);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Gets player profile.
        /// </summary>
        public static Task<PlayFabGetPlayerProfileResult> GetPlayerProfile(string id, PlayerProfileViewConstraints profileConstraints = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabGetPlayerProfileResult>();

            var request = new GetPlayerProfileRequest { PlayFabId = id, ProfileConstraints = profileConstraints };
            PlayFabClientAPI.GetPlayerProfile(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetPlayerProfileResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetPlayerProfileResult { Success = false, Error = error });
                });

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Retrieves the player's profile
        /// </summary>
        public static Task<PlayFabGetPlayerProfileResult> GetPlayerProfile(GetPlayerProfileRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabGetPlayerProfileResult>();

            PlayFabClientAPI.GetPlayerProfile(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetPlayerProfileResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetPlayerProfileResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// List all segments that a player currently belongs to at this moment in time.
        /// </summary>
        public static Task<PlayFabGetPlayerSegmentsResult> GetPlayerSegments(GetPlayerSegmentsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabGetPlayerSegmentsResult>();

            PlayFabClientAPI.GetPlayerSegments(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetPlayerSegmentsResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetPlayerSegmentsResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Retrieves the indicated statistics (current version and values for all statistics, if none are specified), for the local
        /// player.
        /// </summary>
        public static Task<PlayFabGetPlayerStatisticsResult> GetPlayerStatistics(GetPlayerStatisticsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabGetPlayerStatisticsResult>();

            PlayFabClientAPI.GetPlayerStatistics(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetPlayerStatisticsResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetPlayerStatisticsResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Retrieves the information on the available versions of the specified statistic.
        /// </summary>
        public static Task<PlayFabGetPlayerStatisticVersionsResult> GetPlayerStatisticVersions(GetPlayerStatisticVersionsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabGetPlayerStatisticVersionsResult>();

            PlayFabClientAPI.GetPlayerStatisticVersions(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetPlayerStatisticVersionsResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetPlayerStatisticVersionsResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Get all tags with a given Namespace (optional) from a player profile.
        /// </summary>
        public static Task<PlayFabGetPlayerTagsResult> GetPlayerTags(GetPlayerTagsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabGetPlayerTagsResult>();

            PlayFabClientAPI.GetPlayerTags(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetPlayerTagsResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetPlayerTagsResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Gets all trades the player has either opened or accepted, optionally filtered by trade status.
        /// </summary>
        public static Task<PlayFabGetPlayerTradesResponse> GetPlayerTrades(GetPlayerTradesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabGetPlayerTradesResponse>();

            PlayFabClientAPI.GetPlayerTrades(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetPlayerTradesResponse { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetPlayerTradesResponse { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Facebook identifiers.
        /// </summary>
        public static Task<PlayFabGetPlayFabIDsFromFacebookIDsResult> GetPlayFabIDsFromFacebookIDs(GetPlayFabIDsFromFacebookIDsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabGetPlayFabIDsFromFacebookIDsResult>();

            PlayFabClientAPI.GetPlayFabIDsFromFacebookIDs(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetPlayFabIDsFromFacebookIDsResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetPlayFabIDsFromFacebookIDsResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Facebook Instant Game identifiers.
        /// </summary>
        public static Task<PlayFabGetPlayFabIDsFromFacebookInstantGamesIdsResult> GetPlayFabIDsFromFacebookInstantGamesIds(GetPlayFabIDsFromFacebookInstantGamesIdsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabGetPlayFabIDsFromFacebookInstantGamesIdsResult>();

            PlayFabClientAPI.GetPlayFabIDsFromFacebookInstantGamesIds(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetPlayFabIDsFromFacebookInstantGamesIdsResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetPlayFabIDsFromFacebookInstantGamesIdsResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Game Center identifiers (referenced in the Game Center
        /// Programming Guide as the Player Identifier).
        /// </summary>
        public static Task<PlayFabGetPlayFabIDsFromGameCenterIDsResult> GetPlayFabIDsFromGameCenterIDs(GetPlayFabIDsFromGameCenterIDsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabGetPlayFabIDsFromGameCenterIDsResult>();

            PlayFabClientAPI.GetPlayFabIDsFromGameCenterIDs(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetPlayFabIDsFromGameCenterIDsResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetPlayFabIDsFromGameCenterIDsResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of generic service identifiers. A generic identifier is the
        /// service name plus the service-specific ID for the player, as specified by the title when the generic identifier was
        /// added to the player account.
        /// </summary>
        public static Task<PlayFabGetPlayFabIDsFromGenericIDsResult> GetPlayFabIDsFromGenericIDs(GetPlayFabIDsFromGenericIDsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabGetPlayFabIDsFromGenericIDsResult>();

            PlayFabClientAPI.GetPlayFabIDsFromGenericIDs(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetPlayFabIDsFromGenericIDsResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetPlayFabIDsFromGenericIDsResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Google identifiers. The Google identifiers are the IDs for
        /// the user accounts, available as "id" in the Google+ People API calls.
        /// </summary>
        public static Task<PlayFabGetPlayFabIDsFromGoogleIDsResult> GetPlayFabIDsFromGoogleIDs(GetPlayFabIDsFromGoogleIDsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabGetPlayFabIDsFromGoogleIDsResult>();

            PlayFabClientAPI.GetPlayFabIDsFromGoogleIDs(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetPlayFabIDsFromGoogleIDsResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetPlayFabIDsFromGoogleIDsResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Kongregate identifiers. The Kongregate identifiers are the
        /// IDs for the user accounts, available as "user_id" from the Kongregate API methods(ex:
        /// http://developers.kongregate.com/docs/client/getUserId).
        /// </summary>
        public static Task<PlayFabGetPlayFabIDsFromKongregateIDsResult> GetPlayFabIDsFromKongregateIDs(GetPlayFabIDsFromKongregateIDsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabGetPlayFabIDsFromKongregateIDsResult>();

            PlayFabClientAPI.GetPlayFabIDsFromKongregateIDs(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetPlayFabIDsFromKongregateIDsResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetPlayFabIDsFromKongregateIDsResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Nintendo Switch identifiers.
        /// </summary>
        public static Task<PlayFabGetPlayFabIDsFromNintendoSwitchDeviceIdsResult> GetPlayFabIDsFromNintendoSwitchDeviceIds(GetPlayFabIDsFromNintendoSwitchDeviceIdsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabGetPlayFabIDsFromNintendoSwitchDeviceIdsResult>();

            PlayFabClientAPI.GetPlayFabIDsFromNintendoSwitchDeviceIds(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetPlayFabIDsFromNintendoSwitchDeviceIdsResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetPlayFabIDsFromNintendoSwitchDeviceIdsResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of PlayStation Network identifiers.
        /// </summary>
        public static Task<PlayFabGetPlayFabIDsFromPSNAccountIDsResult> GetPlayFabIDsFromPSNAccountIDs(GetPlayFabIDsFromPSNAccountIDsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabGetPlayFabIDsFromPSNAccountIDsResult>();

            PlayFabClientAPI.GetPlayFabIDsFromPSNAccountIDs(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetPlayFabIDsFromPSNAccountIDsResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetPlayFabIDsFromPSNAccountIDsResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Steam identifiers. The Steam identifiers are the profile
        /// IDs for the user accounts, available as SteamId in the Steamworks Community API calls.
        /// </summary>
        public static Task<PlayFabGetPlayFabIDsFromSteamIDsResult> GetPlayFabIDsFromSteamIDs(GetPlayFabIDsFromSteamIDsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabGetPlayFabIDsFromSteamIDsResult>();

            PlayFabClientAPI.GetPlayFabIDsFromSteamIDs(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetPlayFabIDsFromSteamIDsResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetPlayFabIDsFromSteamIDsResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Twitch identifiers. The Twitch identifiers are the IDs for
        /// the user accounts, available as "_id" from the Twitch API methods (ex:
        /// https://github.com/justintv/Twitch-API/blob/master/v3_resources/users.md#get-usersuser).
        /// </summary>
        public static Task<PlayFabGetPlayFabIDsFromTwitchIDsResult> GetPlayFabIDsFromTwitchIDs(GetPlayFabIDsFromTwitchIDsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabGetPlayFabIDsFromTwitchIDsResult>();

            PlayFabClientAPI.GetPlayFabIDsFromTwitchIDs(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetPlayFabIDsFromTwitchIDsResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetPlayFabIDsFromTwitchIDsResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of XboxLive identifiers.
        /// </summary>
        public static Task<PlayFabGetPlayFabIDsFromXboxLiveIDsResult> GetPlayFabIDsFromXboxLiveIDs(GetPlayFabIDsFromXboxLiveIDsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabGetPlayFabIDsFromXboxLiveIDsResult>();

            PlayFabClientAPI.GetPlayFabIDsFromXboxLiveIDs(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetPlayFabIDsFromXboxLiveIDsResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetPlayFabIDsFromXboxLiveIDsResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Retrieves the key-value store of custom publisher settings
        /// </summary>
        public static Task<PlayFabGetPublisherDataResult> GetPublisherData(GetPublisherDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabGetPublisherDataResult>();

            PlayFabClientAPI.GetPublisherData(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetPublisherDataResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetPublisherDataResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Retrieves a purchase along with its current PlayFab status. Returns inventory items from the purchase that are still
        /// active.
        /// </summary>
        public static Task<PlayFabGetPurchaseResult> GetPurchase(GetPurchaseRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabGetPurchaseResult>();

            PlayFabClientAPI.GetPurchase(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetPurchaseResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetPurchaseResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Retrieves data stored in a shared group object, as well as the list of members in the group. Non-members of the group
        /// may use this to retrieve group data, including membership, but they will not receive data for keys marked as private.
        /// Shared Groups are designed for sharing data between a very small number of players, please see our guide:
        /// https://docs.microsoft.com/gaming/playfab/features/social/groups/using-shared-group-data
        /// </summary>
        public static Task<PlayFabGetSharedGroupDataResult> GetSharedGroupData(GetSharedGroupDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabGetSharedGroupDataResult>();

            PlayFabClientAPI.GetSharedGroupData(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetSharedGroupDataResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetSharedGroupDataResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Retrieves the set of items defined for the specified store, including all prices defined
        /// </summary>
        public static Task<PlayFabGetStoreItemsResult> GetStoreItems(GetStoreItemsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabGetStoreItemsResult>();

            PlayFabClientAPI.GetStoreItems(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetStoreItemsResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetStoreItemsResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Retrieves the current server time
        /// </summary>
        public static Task<PlayFabGetTimeResult> GetTime(GetTimeRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabGetTimeResult>();

            PlayFabClientAPI.GetTime(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetTimeResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetTimeResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Retrieves the key-value store of custom title settings
        /// </summary>
        public static Task<PlayFabGetTitleDataResult> GetTitleData(List<string> keys = null, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            return GetTitleData(new GetTitleDataRequest { Keys = keys }, customData, extraHeaders);
        }

        /// <summary>
        /// Retrieves the key-value store of custom title settings
        /// </summary>
        public static Task<PlayFabGetTitleDataResult> GetTitleData(GetTitleDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabGetTitleDataResult>();

            PlayFabClientAPI.GetTitleData(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetTitleDataResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetTitleDataResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Retrieves the title news feed, as configured in the developer portal
        /// </summary>
        public static Task<PlayFabGetTitleNewsResult> GetTitleNews(GetTitleNewsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabGetTitleNewsResult>();

            PlayFabClientAPI.GetTitleNews(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetTitleNewsResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetTitleNewsResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Returns the title's base 64 encoded RSA CSP blob.
        /// </summary>
        public static Task<PlayFabGetTitlePublicKeyResult> GetTitlePublicKey(GetTitlePublicKeyRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabGetTitlePublicKeyResult>();

            PlayFabClientAPI.GetTitlePublicKey(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetTitlePublicKeyResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetTitlePublicKeyResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Gets the current status of an existing trade.
        /// </summary>
        public static Task<PlayFabGetTradeStatusResponse> GetTradeStatus(GetTradeStatusRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabGetTradeStatusResponse>();

            PlayFabClientAPI.GetTradeStatus(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetTradeStatusResponse { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetTradeStatusResponse { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Retrieves the title-specific custom data for the user which is readable and writable by the client
        /// </summary>
        public static Task<PlayFabGetUserDataResult> GetUserData()
        {
            return GetUserData(new GetUserDataRequest());
        }
        public static Task<PlayFabGetUserDataResult> GetUserData(GetUserDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            Debug.Log("GetUserData");
            var taskCompletionSource = new TaskCompletionSource<PlayFabGetUserDataResult>();

            PlayFabClientAPI.GetUserData(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetUserDataResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetUserDataResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Retrieves the user's current inventory of virtual goods
        /// </summary>
        public static Task<PlayFabGetUserInventoryResult> GetUserInventory(GetUserInventoryRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabGetUserInventoryResult>();

            PlayFabClientAPI.GetUserInventory(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetUserInventoryResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetUserInventoryResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Retrieves the publisher-specific custom data for the user which is readable and writable by the client
        /// </summary>
        public static Task<PlayFabGetUserDataResult> GetUserPublisherData(GetUserDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabGetUserDataResult>();

            PlayFabClientAPI.GetUserPublisherData(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetUserDataResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetUserDataResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Retrieves the publisher-specific custom data for the user which can only be read by the client
        /// </summary>
        public static Task<PlayFabGetUserDataResult> GetUserPublisherReadOnlyData(GetUserDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabGetUserDataResult>();

            PlayFabClientAPI.GetUserPublisherReadOnlyData(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetUserDataResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetUserDataResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Retrieves the title-specific custom data for the user which can only be read by the client
        /// </summary>
        public static Task<PlayFabGetUserDataResult> GetUserReadOnlyData(GetUserDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabGetUserDataResult>();

            PlayFabClientAPI.GetUserReadOnlyData(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetUserDataResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetUserDataResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Requests a challenge from the server to be signed by Windows Hello Passport service to authenticate.
        /// </summary>
        public static Task<PlayFabGetWindowsHelloChallengeResponse> GetWindowsHelloChallenge(GetWindowsHelloChallengeRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabGetWindowsHelloChallengeResponse>();

            PlayFabClientAPI.GetWindowsHelloChallenge(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetWindowsHelloChallengeResponse { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabGetWindowsHelloChallengeResponse { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Grants the specified character type to the user. CharacterIds are not globally unique; characterId must be evaluated
        /// with the parent PlayFabId to guarantee uniqueness.
        /// </summary>
        public static Task<PlayFabGrantCharacterToUserResult> GrantCharacterToUser(GrantCharacterToUserRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabGrantCharacterToUserResult>();

            PlayFabClientAPI.GrantCharacterToUser(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabGrantCharacterToUserResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabGrantCharacterToUserResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Links the Android device identifier to the user's PlayFab account
        /// </summary>
        public static Task<PlayFabLinkAndroidDeviceIDResult> LinkAndroidDeviceID(LinkAndroidDeviceIDRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabLinkAndroidDeviceIDResult>();

            PlayFabClientAPI.LinkAndroidDeviceID(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabLinkAndroidDeviceIDResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabLinkAndroidDeviceIDResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Links the Apple account associated with the token to the user's PlayFab account.
        /// </summary>
        public static Task<PlayFabEmptyResult> LinkApple(LinkAppleRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabEmptyResult>();

            PlayFabClientAPI.LinkApple(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabEmptyResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabEmptyResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Links the custom identifier, generated by the title, to the user's PlayFab account
        /// </summary>
        public static Task<PlayFabLinkCustomIDResult> LinkCustomID(LinkCustomIDRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabLinkCustomIDResult>();

            PlayFabClientAPI.LinkCustomID(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabLinkCustomIDResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabLinkCustomIDResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Links the Facebook account associated with the provided Facebook access token to the user's PlayFab account
        /// </summary>
        public static Task<PlayFabLinkFacebookAccountResult> LinkFacebookAccount(LinkFacebookAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabLinkFacebookAccountResult>();

            PlayFabClientAPI.LinkFacebookAccount(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabLinkFacebookAccountResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabLinkFacebookAccountResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Links the Facebook Instant Games Id to the user's PlayFab account
        /// </summary>
        public static Task<PlayFabLinkFacebookInstantGamesIdResult> LinkFacebookInstantGamesId(LinkFacebookInstantGamesIdRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabLinkFacebookInstantGamesIdResult>();

            PlayFabClientAPI.LinkFacebookInstantGamesId(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabLinkFacebookInstantGamesIdResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabLinkFacebookInstantGamesIdResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Links the Game Center account associated with the provided Game Center ID to the user's PlayFab account
        /// </summary>
        public static Task<PlayFabLinkGameCenterAccountResult> LinkGameCenterAccount(LinkGameCenterAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabLinkGameCenterAccountResult>();

            PlayFabClientAPI.LinkGameCenterAccount(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabLinkGameCenterAccountResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabLinkGameCenterAccountResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Links the currently signed-in user account to their Google account, using their Google account credentials
        /// </summary>
        public static Task<PlayFabLinkGoogleAccountResult> LinkGoogleAccount(LinkGoogleAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabLinkGoogleAccountResult>();

            PlayFabClientAPI.LinkGoogleAccount(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabLinkGoogleAccountResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabLinkGoogleAccountResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Links the vendor-specific iOS device identifier to the user's PlayFab account
        /// </summary>
        public static Task<PlayFabLinkIOSDeviceIDResult> LinkIOSDeviceID(LinkIOSDeviceIDRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabLinkIOSDeviceIDResult>();

            PlayFabClientAPI.LinkIOSDeviceID(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabLinkIOSDeviceIDResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabLinkIOSDeviceIDResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Links the Kongregate identifier to the user's PlayFab account
        /// </summary>
        public static Task<PlayFabLinkKongregateAccountResult> LinkKongregate(LinkKongregateAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabLinkKongregateAccountResult>();

            PlayFabClientAPI.LinkKongregate(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabLinkKongregateAccountResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabLinkKongregateAccountResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Links the Nintendo account associated with the token to the user's PlayFab account.
        /// </summary>
        //public static Task<PlayFabEmptyResult> LinkNintendoServiceAccount(LinkNintendoServiceAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        //{
        //    var taskCompletionSource = new TaskCompletionSource<PlayFabEmptyResult>();

        //    PlayFabClientAPI.LinkNintendoServiceAccount(request,
        //        result =>
        //        {
        //            taskCompletionSource.SetResult(new PlayFabEmptyResult { Success = true, Result = result });
        //        },
        //        error =>
        //        {
        //            taskCompletionSource.SetResult(new PlayFabEmptyResult { Success = false, Error = error });
        //        }, customData, extraHeaders);

        //    return taskCompletionSource.Task;
        //}

        /// <summary>
        /// Links the NintendoSwitchDeviceId to the user's PlayFab account
        /// </summary>
        public static Task<PlayFabLinkNintendoSwitchDeviceIdResult> LinkNintendoSwitchDeviceId(LinkNintendoSwitchDeviceIdRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabLinkNintendoSwitchDeviceIdResult>();

            PlayFabClientAPI.LinkNintendoSwitchDeviceId(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabLinkNintendoSwitchDeviceIdResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabLinkNintendoSwitchDeviceIdResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Links an OpenID Connect account to a user's PlayFab account, based on an existing relationship between a title and an
        /// Open ID Connect provider and the OpenId Connect JWT from that provider.
        /// </summary>
        public static Task<PlayFabEmptyResult> LinkOpenIdConnect(LinkOpenIdConnectRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabEmptyResult>();

            PlayFabClientAPI.LinkOpenIdConnect(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabEmptyResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabEmptyResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Links the PlayStation Network account associated with the provided access code to the user's PlayFab account
        /// </summary>
        public static Task<PlayFabLinkPSNAccountResult> LinkPSNAccount(LinkPSNAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabLinkPSNAccountResult>();

            PlayFabClientAPI.LinkPSNAccount(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabLinkPSNAccountResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabLinkPSNAccountResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Links the Steam account associated with the provided Steam authentication ticket to the user's PlayFab account
        /// </summary>
        public static Task<PlayFabLinkSteamAccountResult> LinkSteamAccount(LinkSteamAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabLinkSteamAccountResult>();

            PlayFabClientAPI.LinkSteamAccount(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabLinkSteamAccountResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabLinkSteamAccountResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Links the Twitch account associated with the token to the user's PlayFab account.
        /// </summary>
        public static Task<PlayFabLinkTwitchAccountResult> LinkTwitch(LinkTwitchAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabLinkTwitchAccountResult>();

            PlayFabClientAPI.LinkTwitch(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabLinkTwitchAccountResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabLinkTwitchAccountResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Link Windows Hello authentication to the current PlayFab Account
        /// </summary>
        public static Task<PlayFabLinkWindowsHelloAccountResponse> LinkWindowsHello(LinkWindowsHelloAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabLinkWindowsHelloAccountResponse>();

            PlayFabClientAPI.LinkWindowsHello(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabLinkWindowsHelloAccountResponse { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabLinkWindowsHelloAccountResponse { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Links the Xbox Live account associated with the provided access code to the user's PlayFab account
        /// </summary>
        public static Task<PlayFabLinkXboxAccountResult> LinkXboxAccount(LinkXboxAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabLinkXboxAccountResult>();

            PlayFabClientAPI.LinkXboxAccount(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabLinkXboxAccountResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabLinkXboxAccountResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Logs the user in using email and password.
        /// </summary>
        public static Task<PlayFabLoginResult> LoginWithEmailAddress(string email, string password)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabLoginResult>();

            var request = new LoginWithEmailAddressRequest { Email = email, Password = password, InfoRequestParameters = DefaultInfoRequestParameters };
            PlayFabClientAPI.LoginWithEmailAddress(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabLoginResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabLoginResult { Success = false, Error = error });
                });

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Signs the user in using the Android device identifier, returning a session identifier that can subsequently be used for
        /// API calls which require an authenticated user
        /// </summary>
        public static Task<PlayFabLoginResult> LoginWithAndroidDeviceID(LoginWithAndroidDeviceIDRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabLoginResult>();

            PlayFabClientAPI.LoginWithAndroidDeviceID(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabLoginResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabLoginResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Signs in the user with a Sign in with Apple identity token.
        /// </summary>
        public static Task<PlayFabLoginResult> LoginWithApple(LoginWithAppleRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabLoginResult>();

            PlayFabClientAPI.LoginWithApple(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabLoginResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabLoginResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Signs the user in using a custom unique identifier generated by the title, returning a session identifier that can
        /// subsequently be used for API calls which require an authenticated user
        /// </summary>
        public static Task<PlayFabLoginResult> LoginWithCustomID(string customId, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabLoginResult>();

            PlayFabClientAPI.LoginWithCustomID(new LoginWithCustomIDRequest { CreateAccount = true, CustomId = customId, InfoRequestParameters = DefaultInfoRequestParameters },
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabLoginResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabLoginResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Signs the user in using a custom unique identifier generated by the title, returning a session identifier that can
        /// subsequently be used for API calls which require an authenticated user
        /// </summary>
        public static Task<PlayFabLoginResult> LoginWithCustomID(LoginWithCustomIDRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabLoginResult>();

            PlayFabClientAPI.LoginWithCustomID(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabLoginResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabLoginResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Signs the user into the PlayFab account, returning a session identifier that can subsequently be used for API calls
        /// which require an authenticated user. Unlike most other login API calls, LoginWithEmailAddress does not permit the
        /// creation of new accounts via the CreateAccountFlag. Email addresses may be used to create accounts via
        /// RegisterPlayFabUser.
        /// </summary>
        public static Task<PlayFabLoginResult> LoginWithEmailAddress(LoginWithEmailAddressRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabLoginResult>();

            PlayFabClientAPI.LoginWithEmailAddress(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabLoginResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabLoginResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Signs the user in using a Facebook access token, returning a session identifier that can subsequently be used for API
        /// calls which require an authenticated user
        /// </summary>
        public static Task<PlayFabLoginResult> LoginWithFacebook(LoginWithFacebookRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabLoginResult>();

            PlayFabClientAPI.LoginWithFacebook(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabLoginResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabLoginResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Signs the user in using a Facebook Instant Games ID, returning a session identifier that can subsequently be used for
        /// API calls which require an authenticated user. Requires Facebook Instant Games to be configured.
        /// </summary>
        public static Task<PlayFabLoginResult> LoginWithFacebookInstantGamesId(LoginWithFacebookInstantGamesIdRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabLoginResult>();

            PlayFabClientAPI.LoginWithFacebookInstantGamesId(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabLoginResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabLoginResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Signs the user in using an iOS Game Center player identifier, returning a session identifier that can subsequently be
        /// used for API calls which require an authenticated user
        /// </summary>
        public static Task<PlayFabLoginResult> LoginWithGameCenter(LoginWithGameCenterRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabLoginResult>();

            PlayFabClientAPI.LoginWithGameCenter(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabLoginResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabLoginResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Signs the user in using their Google account credentials
        /// </summary>
        public static Task<PlayFabLoginResult> LoginWithGoogleAccount(LoginWithGoogleAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabLoginResult>();

            PlayFabClientAPI.LoginWithGoogleAccount(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabLoginResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabLoginResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Signs the user in using the vendor-specific iOS device identifier, returning a session identifier that can subsequently
        /// be used for API calls which require an authenticated user
        /// </summary>
        public static Task<PlayFabLoginResult> LoginWithIOSDeviceID(LoginWithIOSDeviceIDRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabLoginResult>();

            PlayFabClientAPI.LoginWithIOSDeviceID(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabLoginResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabLoginResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Signs the user in using a Kongregate player account.
        /// </summary>
        public static Task<PlayFabLoginResult> LoginWithKongregate(LoginWithKongregateRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabLoginResult>();

            PlayFabClientAPI.LoginWithKongregate(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabLoginResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabLoginResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Signs in the user with a Nintendo service account token.
        /// </summary>
        //public static Task<PlayFabLoginResult> LoginWithNintendoServiceAccount(LoginWithNintendoServiceAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        //{
        //    var taskCompletionSource = new TaskCompletionSource<PlayFabLoginResult>();

        //    PlayFabClientAPI.LoginWithNintendoServiceAccount(request,
        //        result =>
        //        {
        //            taskCompletionSource.SetResult(new PlayFabLoginResult { Success = true, Result = result });
        //        },
        //        error =>
        //        {
        //            taskCompletionSource.SetResult(new PlayFabLoginResult { Success = false, Error = error });
        //        }, customData, extraHeaders);

        //    return taskCompletionSource.Task;
        //}

        /// <summary>
        /// Signs the user in using a Nintendo Switch Device ID, returning a session identifier that can subsequently be used for
        /// API calls which require an authenticated user
        /// </summary>
        public static Task<PlayFabLoginResult> LoginWithNintendoSwitchDeviceId(LoginWithNintendoSwitchDeviceIdRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabLoginResult>();

            PlayFabClientAPI.LoginWithNintendoSwitchDeviceId(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabLoginResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabLoginResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Logs in a user with an Open ID Connect JWT created by an existing relationship between a title and an Open ID Connect
        /// provider.
        /// </summary>
        public static Task<PlayFabLoginResult> LoginWithOpenIdConnect(LoginWithOpenIdConnectRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabLoginResult>();

            PlayFabClientAPI.LoginWithOpenIdConnect(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabLoginResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabLoginResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Signs the user into the PlayFab account, returning a session identifier that can subsequently be used for API calls
        /// which require an authenticated user. Unlike most other login API calls, LoginWithPlayFab does not permit the creation of
        /// new accounts via the CreateAccountFlag. Username/Password credentials may be used to create accounts via
        /// RegisterPlayFabUser, or added to existing accounts using AddUsernamePassword.
        /// </summary>
        public static Task<PlayFabLoginResult> LoginWithPlayFab(LoginWithPlayFabRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabLoginResult>();

            PlayFabClientAPI.LoginWithPlayFab(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabLoginResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabLoginResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Signs the user in using a PlayStation Network authentication code, returning a session identifier that can subsequently
        /// be used for API calls which require an authenticated user
        /// </summary>
        public static Task<PlayFabLoginResult> LoginWithPSN(LoginWithPSNRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabLoginResult>();

            PlayFabClientAPI.LoginWithPSN(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabLoginResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabLoginResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Signs the user in using a Steam authentication ticket, returning a session identifier that can subsequently be used for
        /// API calls which require an authenticated user
        /// </summary>
        public static Task<PlayFabLoginResult> LoginWithSteam(LoginWithSteamRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabLoginResult>();

            PlayFabClientAPI.LoginWithSteam(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabLoginResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabLoginResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Signs the user in using a Twitch access token.
        /// </summary>
        public static Task<PlayFabLoginResult> LoginWithTwitch(LoginWithTwitchRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabLoginResult>();

            PlayFabClientAPI.LoginWithTwitch(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabLoginResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabLoginResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Completes the Windows Hello login flow by returning the signed value of the challange from GetWindowsHelloChallenge.
        /// Windows Hello has a 2 step client to server authentication scheme. Step one is to request from the server a challenge
        /// string. Step two is to request the user sign the string via Windows Hello and then send the signed value back to the
        /// server.
        /// </summary>
        public static Task<PlayFabLoginResult> LoginWithWindowsHello(LoginWithWindowsHelloRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabLoginResult>();

            PlayFabClientAPI.LoginWithWindowsHello(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabLoginResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabLoginResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Signs the user in using a Xbox Live Token, returning a session identifier that can subsequently be used for API calls
        /// which require an authenticated user
        /// </summary>
        public static Task<PlayFabLoginResult> LoginWithXbox(LoginWithXboxRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabLoginResult>();

            PlayFabClientAPI.LoginWithXbox(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabLoginResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabLoginResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Attempts to locate a game session matching the given parameters. If the goal is to match the player into a specific
        /// active session, only the LobbyId is required. Otherwise, the BuildVersion, GameMode, and Region are all required
        /// parameters. Note that parameters specified in the search are required (they are not weighting factors). If a slot is
        /// found in a server instance matching the parameters, the slot will be assigned to that player, removing it from the
        /// availabe set. In that case, the information on the game session will be returned, otherwise the Status returned will be
        /// GameNotFound.
        /// </summary>
        public static Task<PlayFabMatchmakeResult> Matchmake(MatchmakeRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabMatchmakeResult>();

            PlayFabClientAPI.Matchmake(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabMatchmakeResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabMatchmakeResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Opens a new outstanding trade. Note that a given item instance may only be in one open trade at a time.
        /// </summary>
        public static Task<PlayFabOpenTradeResponse> OpenTrade(OpenTradeRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabOpenTradeResponse>();

            PlayFabClientAPI.OpenTrade(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabOpenTradeResponse { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabOpenTradeResponse { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Selects a payment option for purchase order created via StartPurchase
        /// </summary>
        public static Task<PlayFabPayForPurchaseResult> PayForPurchase(PayForPurchaseRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabPayForPurchaseResult>();

            PlayFabClientAPI.PayForPurchase(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabPayForPurchaseResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabPayForPurchaseResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Buys a single item with virtual currency. You must specify both the virtual currency to use to purchase, as well as what
        /// the client believes the price to be. This lets the server fail the purchase if the price has changed.
        /// </summary>
        public static Task<PlayFabPurchaseItemResult> PurchaseItem(PurchaseItemRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabPurchaseItemResult>();

            PlayFabClientAPI.PurchaseItem(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabPurchaseItemResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabPurchaseItemResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Adds the virtual goods associated with the coupon to the user's inventory. Coupons can be generated via the
        /// Economy->Catalogs tab in the PlayFab Game Manager.
        /// </summary>
        public static Task<PlayFabRedeemCouponResult> RedeemCoupon(RedeemCouponRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabRedeemCouponResult>();

            PlayFabClientAPI.RedeemCoupon(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabRedeemCouponResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabRedeemCouponResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Uses the supplied OAuth code to refresh the internally cached player PSN auth token
        /// </summary>
        public static Task<PlayFabEmptyResponse> RefreshPSNAuthToken(RefreshPSNAuthTokenRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabEmptyResponse>();

            PlayFabClientAPI.RefreshPSNAuthToken(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabEmptyResponse { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabEmptyResponse { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Registers the iOS device to receive push notifications
        /// </summary>
        public static Task<PlayFabRegisterForIOSPushNotificationResult> RegisterForIOSPushNotification(RegisterForIOSPushNotificationRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabRegisterForIOSPushNotificationResult>();

            PlayFabClientAPI.RegisterForIOSPushNotification(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabRegisterForIOSPushNotificationResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabRegisterForIOSPushNotificationResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Registers a new Playfab user account using email and password, returning a session identifier that can subsequently be used for API calls which
        /// require an authenticated user.
        /// </summary>
        public static Task<PlayFabRegisterPlayFabUserResult> RegisterWithEmailAddress(string email, string password, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            return RegisterPlayFabUser(new RegisterPlayFabUserRequest { Email = email, Password = password, RequireBothUsernameAndEmail = false, InfoRequestParameters = DefaultInfoRequestParameters }, customData, extraHeaders);
        }

        /// <summary>
        /// Registers a new Playfab user account, returning a session identifier that can subsequently be used for API calls which
        /// require an authenticated user. You must supply either a username or an email address.
        /// </summary>
        public static Task<PlayFabRegisterPlayFabUserResult> RegisterPlayFabUser(RegisterPlayFabUserRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabRegisterPlayFabUserResult>();

            PlayFabClientAPI.RegisterPlayFabUser(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabRegisterPlayFabUserResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabRegisterPlayFabUserResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Registers a new PlayFab user account using Windows Hello authentication, returning a session ticket that can
        /// subsequently be used for API calls which require an authenticated user
        /// </summary>
        public static Task<PlayFabLoginResult> RegisterWithWindowsHello(RegisterWithWindowsHelloRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabLoginResult>();

            PlayFabClientAPI.RegisterWithWindowsHello(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabLoginResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabLoginResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Removes a contact email from the player's profile.
        /// </summary>
        public static Task<PlayFabRemoveContactEmailResult> RemoveContactEmail(RemoveContactEmailRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabRemoveContactEmailResult>();

            PlayFabClientAPI.RemoveContactEmail(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabRemoveContactEmailResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabRemoveContactEmailResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Removes a specified user from the friend list of the local user
        /// </summary>
        public static Task<PlayFabRemoveFriendResult> RemoveFriend(string playerId)
        {
            return RemoveFriend(new RemoveFriendRequest { FriendPlayFabId = playerId });
        }

        /// <summary>
        /// Removes a specified user from the friend list of the local user
        /// </summary>
        public static Task<PlayFabRemoveFriendResult> RemoveFriend(RemoveFriendRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabRemoveFriendResult>();

            PlayFabClientAPI.RemoveFriend(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabRemoveFriendResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabRemoveFriendResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Removes the specified generic service identifier from the player's PlayFab account.
        /// </summary>
        public static Task<PlayFabRemoveGenericIDResult> RemoveGenericID(RemoveGenericIDRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabRemoveGenericIDResult>();

            PlayFabClientAPI.RemoveGenericID(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabRemoveGenericIDResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabRemoveGenericIDResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Removes users from the set of those able to update the shared data and the set of users in the group. Only users in the
        /// group can remove members. If as a result of the call, zero users remain with access, the group and its associated data
        /// will be deleted. Shared Groups are designed for sharing data between a very small number of players, please see our
        /// guide: https://docs.microsoft.com/gaming/playfab/features/social/groups/using-shared-group-data
        /// </summary>
        public static Task<PlayFabRemoveSharedGroupMembersResult> RemoveSharedGroupMembers(RemoveSharedGroupMembersRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabRemoveSharedGroupMembersResult>();

            PlayFabClientAPI.RemoveSharedGroupMembers(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabRemoveSharedGroupMembersResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabRemoveSharedGroupMembersResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Report player's ad activity
        /// </summary>
        public static Task<PlayFabReportAdActivityResult> ReportAdActivity(ReportAdActivityRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabReportAdActivityResult>();

            PlayFabClientAPI.ReportAdActivity(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabReportAdActivityResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabReportAdActivityResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Write a PlayStream event to describe the provided player device information. This API method is not designed to be
        /// called directly by developers. Each PlayFab client SDK will eventually report this information automatically.
        /// </summary>
        public static Task<PlayFabEmptyResponse> ReportDeviceInfo(DeviceInfoRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabEmptyResponse>();

            PlayFabClientAPI.ReportDeviceInfo(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabEmptyResponse { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabEmptyResponse { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Submit a report for another player (due to bad bahavior, etc.), so that customer service representatives for the title
        /// can take action concerning potentially toxic players.
        /// </summary>
        public static Task<PlayFabReportPlayerClientResult> ReportPlayer(ReportPlayerClientRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabReportPlayerClientResult>();

            PlayFabClientAPI.ReportPlayer(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabReportPlayerClientResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabReportPlayerClientResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Restores all in-app purchases based on the given restore receipt
        /// </summary>
        public static Task<PlayFabRestoreIOSPurchasesResult> RestoreIOSPurchases(RestoreIOSPurchasesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabRestoreIOSPurchasesResult>();

            PlayFabClientAPI.RestoreIOSPurchases(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabRestoreIOSPurchasesResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabRestoreIOSPurchasesResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Reward player's ad activity
        /// </summary>
        public static Task<PlayFabRewardAdActivityResult> RewardAdActivity(RewardAdActivityRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabRewardAdActivityResult>();

            PlayFabClientAPI.RewardAdActivity(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabRewardAdActivityResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabRewardAdActivityResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Forces an email to be sent to the registered email address for the user's account, with a link allowing the user to
        /// change the password.If an account recovery email template ID is provided, an email using the custom email template will
        /// be used.
        /// </summary>
        public static Task<PlayFabSendAccountRecoveryEmailResult> SendAccountRecoveryEmail(SendAccountRecoveryEmailRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabSendAccountRecoveryEmailResult>();

            PlayFabClientAPI.SendAccountRecoveryEmail(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabSendAccountRecoveryEmailResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabSendAccountRecoveryEmailResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Updates the tag list for a specified user in the friend list of the local user
        /// </summary>
        public static Task<PlayFabSetFriendTagsResult> SetFriendTags(SetFriendTagsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabSetFriendTagsResult>();

            PlayFabClientAPI.SetFriendTags(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabSetFriendTagsResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabSetFriendTagsResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Sets the player's secret if it is not already set. Player secrets are used to sign API requests. To reset a player's
        /// secret use the Admin or Server API method SetPlayerSecret.
        /// </summary>
        public static Task<PlayFabSetPlayerSecretResult> SetPlayerSecret(SetPlayerSecretRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabSetPlayerSecretResult>();

            PlayFabClientAPI.SetPlayerSecret(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabSetPlayerSecretResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabSetPlayerSecretResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Start a new game server with a given configuration, add the current player and return the connection information.
        /// </summary>
        public static Task<PlayFabStartGameResult> StartGame(StartGameRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabStartGameResult>();

            PlayFabClientAPI.StartGame(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabStartGameResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabStartGameResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Creates an order for a list of items from the title catalog
        /// </summary>
        public static Task<PlayFabStartPurchaseResult> StartPurchase(StartPurchaseRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabStartPurchaseResult>();

            PlayFabClientAPI.StartPurchase(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabStartPurchaseResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabStartPurchaseResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Decrements the user's balance of the specified virtual currency by the stated amount. It is possible to make a VC
        /// balance negative with this API.
        /// </summary>
        public static Task<PlayFabModifyUserVirtualCurrencyResult> SubtractUserVirtualCurrency(SubtractUserVirtualCurrencyRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabModifyUserVirtualCurrencyResult>();

            PlayFabClientAPI.SubtractUserVirtualCurrency(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabModifyUserVirtualCurrencyResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabModifyUserVirtualCurrencyResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Unlinks the related Android device identifier from the user's PlayFab account
        /// </summary>
        public static Task<PlayFabUnlinkAndroidDeviceIDResult> UnlinkAndroidDeviceID(UnlinkAndroidDeviceIDRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabUnlinkAndroidDeviceIDResult>();

            PlayFabClientAPI.UnlinkAndroidDeviceID(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabUnlinkAndroidDeviceIDResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabUnlinkAndroidDeviceIDResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Unlinks the related Apple account from the user's PlayFab account.
        /// </summary>
        public static Task<PlayFabEmptyResponse> UnlinkApple(UnlinkAppleRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabEmptyResponse>();

            PlayFabClientAPI.UnlinkApple(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabEmptyResponse { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabEmptyResponse { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Unlinks the related custom identifier from the user's PlayFab account
        /// </summary>
        public static Task<PlayFabUnlinkCustomIDResult> UnlinkCustomID(UnlinkCustomIDRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabUnlinkCustomIDResult>();

            PlayFabClientAPI.UnlinkCustomID(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabUnlinkCustomIDResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabUnlinkCustomIDResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Unlinks the related Facebook account from the user's PlayFab account
        /// </summary>
        public static Task<PlayFabUnlinkFacebookAccountResult> UnlinkFacebookAccount(UnlinkFacebookAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabUnlinkFacebookAccountResult>();

            PlayFabClientAPI.UnlinkFacebookAccount(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabUnlinkFacebookAccountResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabUnlinkFacebookAccountResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Unlinks the related Facebook Instant Game Ids from the user's PlayFab account
        /// </summary>
        public static Task<PlayFabUnlinkFacebookInstantGamesIdResult> UnlinkFacebookInstantGamesId(UnlinkFacebookInstantGamesIdRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabUnlinkFacebookInstantGamesIdResult>();

            PlayFabClientAPI.UnlinkFacebookInstantGamesId(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabUnlinkFacebookInstantGamesIdResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabUnlinkFacebookInstantGamesIdResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Unlinks the related Game Center account from the user's PlayFab account
        /// </summary>
        public static Task<PlayFabUnlinkGameCenterAccountResult> UnlinkGameCenterAccount(UnlinkGameCenterAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabUnlinkGameCenterAccountResult>();

            PlayFabClientAPI.UnlinkGameCenterAccount(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabUnlinkGameCenterAccountResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabUnlinkGameCenterAccountResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Unlinks the related Google account from the user's PlayFab account
        /// (https://developers.google.com/android/reference/com/google/android/gms/auth/GoogleAuthUtil#public-methods).
        /// </summary>
        public static Task<PlayFabUnlinkGoogleAccountResult> UnlinkGoogleAccount(UnlinkGoogleAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabUnlinkGoogleAccountResult>();

            PlayFabClientAPI.UnlinkGoogleAccount(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabUnlinkGoogleAccountResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabUnlinkGoogleAccountResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Unlinks the related iOS device identifier from the user's PlayFab account
        /// </summary>
        public static Task<PlayFabUnlinkIOSDeviceIDResult> UnlinkIOSDeviceID(UnlinkIOSDeviceIDRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabUnlinkIOSDeviceIDResult>();

            PlayFabClientAPI.UnlinkIOSDeviceID(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabUnlinkIOSDeviceIDResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabUnlinkIOSDeviceIDResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Unlinks the related Kongregate identifier from the user's PlayFab account
        /// </summary>
        public static Task<PlayFabUnlinkKongregateAccountResult> UnlinkKongregate(UnlinkKongregateAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabUnlinkKongregateAccountResult>();

            PlayFabClientAPI.UnlinkKongregate(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabUnlinkKongregateAccountResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabUnlinkKongregateAccountResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Unlinks the related NintendoSwitchDeviceId from the user's PlayFab account
        /// </summary>
        public static Task<PlayFabUnlinkNintendoSwitchDeviceIdResult> UnlinkNintendoSwitchDeviceId(UnlinkNintendoSwitchDeviceIdRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabUnlinkNintendoSwitchDeviceIdResult>();

            PlayFabClientAPI.UnlinkNintendoSwitchDeviceId(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabUnlinkNintendoSwitchDeviceIdResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabUnlinkNintendoSwitchDeviceIdResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Unlinks an OpenID Connect account from a user's PlayFab account, based on the connection ID of an existing relationship
        /// between a title and an Open ID Connect provider.
        /// </summary>
        public static Task<PlayFabEmptyResponse> UnlinkOpenIdConnect(UnlinkOpenIdConnectRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabEmptyResponse>();

            PlayFabClientAPI.UnlinkOpenIdConnect(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabEmptyResponse { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabEmptyResponse { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Unlinks the related PSN account from the user's PlayFab account
        /// </summary>
        public static Task<PlayFabUnlinkPSNAccountResult> UnlinkPSNAccount(UnlinkPSNAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabUnlinkPSNAccountResult>();

            PlayFabClientAPI.UnlinkPSNAccount(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabUnlinkPSNAccountResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabUnlinkPSNAccountResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Unlinks the related Steam account from the user's PlayFab account
        /// </summary>
        public static Task<PlayFabUnlinkSteamAccountResult> UnlinkSteamAccount(UnlinkSteamAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabUnlinkSteamAccountResult>();

            PlayFabClientAPI.UnlinkSteamAccount(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabUnlinkSteamAccountResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabUnlinkSteamAccountResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Unlinks the related Twitch account from the user's PlayFab account.
        /// </summary>
        public static Task<PlayFabUnlinkTwitchAccountResult> UnlinkTwitch(UnlinkTwitchAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabUnlinkTwitchAccountResult>();

            PlayFabClientAPI.UnlinkTwitch(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabUnlinkTwitchAccountResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabUnlinkTwitchAccountResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Unlink Windows Hello authentication from the current PlayFab Account
        /// </summary>
        public static Task<PlayFabUnlinkWindowsHelloAccountResponse> UnlinkWindowsHello(UnlinkWindowsHelloAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabUnlinkWindowsHelloAccountResponse>();

            PlayFabClientAPI.UnlinkWindowsHello(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabUnlinkWindowsHelloAccountResponse { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabUnlinkWindowsHelloAccountResponse { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Unlinks the related Xbox Live account from the user's PlayFab account
        /// </summary>
        public static Task<PlayFabUnlinkXboxAccountResult> UnlinkXboxAccount(UnlinkXboxAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabUnlinkXboxAccountResult>();

            PlayFabClientAPI.UnlinkXboxAccount(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabUnlinkXboxAccountResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabUnlinkXboxAccountResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Opens the specified container, with the specified key (when required), and returns the contents of the opened container.
        /// If the container (and key when relevant) are consumable (RemainingUses > 0), their RemainingUses will be decremented,
        /// consistent with the operation of ConsumeItem.
        /// </summary>
        public static Task<PlayFabUnlockContainerItemResult> UnlockContainerInstance(UnlockContainerInstanceRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabUnlockContainerItemResult>();

            PlayFabClientAPI.UnlockContainerInstance(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabUnlockContainerItemResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabUnlockContainerItemResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Searches target inventory for an ItemInstance matching the given CatalogItemId, if necessary unlocks it using an
        /// appropriate key, and returns the contents of the opened container. If the container (and key when relevant) are
        /// consumable (RemainingUses > 0), their RemainingUses will be decremented, consistent with the operation of ConsumeItem.
        /// </summary>
        public static Task<PlayFabUnlockContainerItemResult> UnlockContainerItem(UnlockContainerItemRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabUnlockContainerItemResult>();

            PlayFabClientAPI.UnlockContainerItem(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabUnlockContainerItemResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabUnlockContainerItemResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Update the avatar URL of the player
        /// </summary>
        public static Task<PlayFabEmptyResponse> UpdateAvatarUrl(string avatarUrl, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabEmptyResponse>();

            PlayFabClientAPI.UpdateAvatarUrl(new UpdateAvatarUrlRequest { ImageUrl = avatarUrl },
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabEmptyResponse { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabEmptyResponse { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Update the avatar URL of the player
        /// </summary>
        public static Task<PlayFabEmptyResponse> UpdateAvatarUrl(UpdateAvatarUrlRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabEmptyResponse>();

            PlayFabClientAPI.UpdateAvatarUrl(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabEmptyResponse { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabEmptyResponse { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Creates and updates the title-specific custom data for the user's character which is readable and writable by the client
        /// </summary>
        public static Task<PlayFabUpdateCharacterDataResult> UpdateCharacterData(UpdateCharacterDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabUpdateCharacterDataResult>();

            PlayFabClientAPI.UpdateCharacterData(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabUpdateCharacterDataResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabUpdateCharacterDataResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Updates the values of the specified title-specific statistics for the specific character. By default, clients are not
        /// permitted to update statistics. Developers may override this setting in the Game Manager > Settings > API Features.
        /// </summary>
        public static Task<PlayFabUpdateCharacterStatisticsResult> UpdateCharacterStatistics(UpdateCharacterStatisticsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabUpdateCharacterStatisticsResult>();

            PlayFabClientAPI.UpdateCharacterStatistics(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabUpdateCharacterStatisticsResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabUpdateCharacterStatisticsResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Updates the values of the specified title-specific statistics for the user. By default, clients are not permitted to
        /// update statistics. Developers may override this setting in the Game Manager > Settings > API Features.
        /// </summary>
        public static Task<PlayFabUpdatePlayerStatisticsResult> UpdatePlayerStatistics(UpdatePlayerStatisticsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabUpdatePlayerStatisticsResult>();

            PlayFabClientAPI.UpdatePlayerStatistics(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabUpdatePlayerStatisticsResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabUpdatePlayerStatisticsResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Adds, updates, and removes data keys for a shared group object. If the permission is set to Public, all fields updated
        /// or added in this call will be readable by users not in the group. By default, data permissions are set to Private.
        /// Regardless of the permission setting, only members of the group can update the data. Shared Groups are designed for
        /// sharing data between a very small number of players, please see our guide:
        /// https://docs.microsoft.com/gaming/playfab/features/social/groups/using-shared-group-data
        /// </summary>
        public static Task<PlayFabUpdateSharedGroupDataResult> UpdateSharedGroupData(UpdateSharedGroupDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabUpdateSharedGroupDataResult>();

            PlayFabClientAPI.UpdateSharedGroupData(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabUpdateSharedGroupDataResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabUpdateSharedGroupDataResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Creates and updates the title-specific custom data for the user which is readable and writable by the client
        /// </summary>
        public static Task<PlayFabUpdateUserDataResult> UpdateUserData(UpdateUserDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabUpdateUserDataResult>();

            PlayFabClientAPI.UpdateUserData(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabUpdateUserDataResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabUpdateUserDataResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Creates and updates the publisher-specific custom data for the user which is readable and writable by the client
        /// </summary>
        public static Task<PlayFabUpdateUserDataResult> UpdateUserPublisherData(UpdateUserDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabUpdateUserDataResult>();

            PlayFabClientAPI.UpdateUserPublisherData(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabUpdateUserDataResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabUpdateUserDataResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Updates display name for user.
        /// </summary>
        public static Task<PlayFabUpdateUserTitleDisplayNameResult> UpdateDisplayName(string displayName)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabUpdateUserTitleDisplayNameResult>();

            var request = new UpdateUserTitleDisplayNameRequest { DisplayName = displayName };
            PlayFabClientAPI.UpdateUserTitleDisplayName(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabUpdateUserTitleDisplayNameResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabUpdateUserTitleDisplayNameResult { Success = false, Error = error });
                });

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Updates the title specific display name for the user
        /// </summary>
        public static Task<PlayFabUpdateUserTitleDisplayNameResult> UpdateUserTitleDisplayName(UpdateUserTitleDisplayNameRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabUpdateUserTitleDisplayNameResult>();

            PlayFabClientAPI.UpdateUserTitleDisplayName(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabUpdateUserTitleDisplayNameResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabUpdateUserTitleDisplayNameResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Validates with Amazon that the receipt for an Amazon App Store in-app purchase is valid and that it matches the
        /// purchased catalog item
        /// </summary>
        public static Task<PlayFabValidateAmazonReceiptResult> ValidateAmazonIAPReceipt(ValidateAmazonReceiptRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabValidateAmazonReceiptResult>();

            PlayFabClientAPI.ValidateAmazonIAPReceipt(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabValidateAmazonReceiptResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabValidateAmazonReceiptResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Validates a Google Play purchase and gives the corresponding item to the player.
        /// </summary>
        public static Task<PlayFabValidateGooglePlayPurchaseResult> ValidateGooglePlayPurchase(ValidateGooglePlayPurchaseRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabValidateGooglePlayPurchaseResult>();

            PlayFabClientAPI.ValidateGooglePlayPurchase(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabValidateGooglePlayPurchaseResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabValidateGooglePlayPurchaseResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Validates with the Apple store that the receipt for an iOS in-app purchase is valid and that it matches the purchased
        /// catalog item
        /// </summary>
        public static Task<PlayFabValidateIOSReceiptResult> ValidateIOSReceipt(ValidateIOSReceiptRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabValidateIOSReceiptResult>();

            PlayFabClientAPI.ValidateIOSReceipt(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabValidateIOSReceiptResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabValidateIOSReceiptResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Validates with Windows that the receipt for an Windows App Store in-app purchase is valid and that it matches the
        /// purchased catalog item
        /// </summary>
        public static Task<PlayFabValidateWindowsReceiptResult> ValidateWindowsStoreReceipt(ValidateWindowsReceiptRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabValidateWindowsReceiptResult>();

            PlayFabClientAPI.ValidateWindowsStoreReceipt(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabValidateWindowsReceiptResult { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabValidateWindowsReceiptResult { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Writes a character-based event into PlayStream.
        /// </summary>
        public static Task<PlayFabWriteEventResponse> WriteCharacterEvent(WriteClientCharacterEventRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabWriteEventResponse>();

            PlayFabClientAPI.WriteCharacterEvent(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabWriteEventResponse { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabWriteEventResponse { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Writes a player-based event into PlayStream.
        /// </summary>
        public static Task<PlayFabWriteEventResponse> WritePlayerEvent(WriteClientPlayerEventRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabWriteEventResponse>();

            PlayFabClientAPI.WritePlayerEvent(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabWriteEventResponse { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabWriteEventResponse { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Writes a title-based event into PlayStream.
        /// </summary>
        public static Task<PlayFabWriteEventResponse> WriteTitleEvent(WriteTitleEventRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabWriteEventResponse>();

            PlayFabClientAPI.WriteTitleEvent(request,
                result =>
                {
                    taskCompletionSource.SetResult(new PlayFabWriteEventResponse { Success = true, Result = result });
                },
                error =>
                {
                    taskCompletionSource.SetResult(new PlayFabWriteEventResponse { Success = false, Error = error });
                }, customData, extraHeaders);

            return taskCompletionSource.Task;
        }

        #endregion

        #region Type Conversion

        /// <summary>
        /// Converts list of PlayFab models to bindable collection of delight models.
        /// </summary>
        public static BindableCollection<To> FromPlayFabList<To, From>(List<From> list, Func<From, To> converter)
            where To : BindableObject
        {
            var bindableCollection = new BindableCollection<To>();
            if (list == null)
                return bindableCollection;

            foreach (var item in list)
            {
                bindableCollection.Add(converter(item));
            }
            return bindableCollection;
        }

        /// <summary>
        /// Gets player profile object from PlayFab player profile. 
        /// </summary>
        public static PlayFabPlayerProfile FromPlayerProfileModel(PlayerProfileModel playerProfileModel, Dictionary<string, UserDataRecord> userData = null, List<ItemInstance> userInventory = null)
        {
            var playerProfile = new PlayFabPlayerProfile();
            playerProfile.Id = playerProfileModel.PlayerId;
            playerProfile.AdCampaignAttributions = FromPlayFabList(playerProfileModel.AdCampaignAttributions, FromAdCampaignAttributionModel);
            playerProfile.AvatarUrl = playerProfileModel.AvatarUrl;
            playerProfile.BannedUntil = playerProfileModel.BannedUntil;
            playerProfile.ContactEmailAddresses = FromPlayFabList(playerProfileModel.ContactEmailAddresses, FromContactEmailInfoModel);
            playerProfile.Created = playerProfileModel.Created;
            playerProfile.DisplayName = playerProfileModel.DisplayName;
            playerProfile.ExperimentVariants = playerProfileModel.ExperimentVariants;
            playerProfile.LastLogin = playerProfileModel.LastLogin;
            playerProfile.LinkedAccounts = FromPlayFabList(playerProfileModel.LinkedAccounts, FromLinkedPlatformAccountModel);
            playerProfile.Locations = FromPlayFabList(playerProfileModel.Locations, FromLocationModel);
            playerProfile.Memberships = FromPlayFabList(playerProfileModel.Memberships, FromMembershipModel);
            playerProfile.Origination = playerProfileModel.Origination;
            playerProfile.PublisherId = playerProfileModel.PublisherId;
            playerProfile.PushNotificationRegistrations = FromPlayFabList(playerProfileModel.PushNotificationRegistrations, FromPushNotificationRegistrationModel);
            playerProfile.Statistics = FromPlayFabList(playerProfileModel.Statistics, FromStatisticModel);
            playerProfile.Tags = FromPlayFabList(playerProfileModel.Tags, FromTagModel);
            playerProfile.TitleId = playerProfileModel.TitleId;
            playerProfile.TotalValueToDateInUSD = playerProfileModel.TotalValueToDateInUSD;
            playerProfile.ValuesToDate = FromPlayFabList(playerProfileModel.ValuesToDate, FromValueToDateModel);
            playerProfile.InventoryItems = FromPlayFabList(userInventory, FromItemInstance);

            if (userData != null)
            {
                var userDataRecords = new Dictionary<string, PlayFabUserDataRecord>();
                foreach (var kv in userData)
                {
                    userDataRecords.Add(kv.Key, FromUserDataRecord(kv.Value));
                }
                playerProfile.UserData = userDataRecords;
            }

            return playerProfile;
        }

        /// <summary>
        /// Gets Delight PlayFabStatistic from PlayFab ValueToDateModel.
        /// </summary>
        public static PlayFabStatistic FromStatisticModel(StatisticModel statisticModel)
        {
            var statistic = new PlayFabStatistic();
            statistic.Name = statisticModel.Name;
            statistic.Value = statisticModel.Value;
            statistic.Version = statisticModel.Version;
            return statistic;
        }

        /// <summary>
        /// Gets Delight PlayFabValueToDate from ValueToDateModel.
        /// </summary>
        public static PlayFabValueToDate FromValueToDateModel(ValueToDateModel valueToDate)
        {
            var playerProfile = new PlayFabValueToDate();
            playerProfile.Currency = valueToDate.Currency;
            playerProfile.TotalValue = valueToDate.TotalValue;
            playerProfile.TotalValueAsDecimal = valueToDate.TotalValueAsDecimal;
            return playerProfile;
        }

        /// <summary>
        /// Gets Delight PlayFabInventoryItem from CatalogItem.
        /// </summary>
        public static PlayFabInventoryItem FromCatalogItem(CatalogItem catalogItem)
        {
            var inventoryItem = new PlayFabInventoryItem();
            inventoryItem.CatalogVersion = catalogItem.CatalogVersion;
            inventoryItem.DisplayName = catalogItem.DisplayName;
            inventoryItem.Id = catalogItem.ItemId;
            inventoryItem.ItemClass = catalogItem.ItemClass;
            return inventoryItem;
        }

        /// <summary>
        /// Gets Delight PlayFabInventoryItem from ItemInstance.
        /// </summary>
        public static PlayFabInventoryItem FromItemInstance(ItemInstance itemInstance)
        {
            var inventoryItem = new PlayFabInventoryItem();
            inventoryItem.CatalogVersion = itemInstance.CatalogVersion;
            inventoryItem.DisplayName = itemInstance.DisplayName;
            inventoryItem.Id = itemInstance.ItemId;
            inventoryItem.ItemClass = itemInstance.ItemClass;
            inventoryItem.UnitCurrency = itemInstance.UnitCurrency;
            inventoryItem.UnitPrice = itemInstance.UnitPrice;
            inventoryItem.IsOwnedByPlayer = true;
            inventoryItem.CustomData = itemInstance.CustomData != null ? 
                new Dictionary<string, string>(itemInstance.CustomData) : 
                new Dictionary<string, string>();
            return inventoryItem;
        }

        /// <summary>
        /// Converts PlayFab model to bindable Delight model.
        /// </summary>
        public static PlayFabTag FromTagModel(TagModel tagModel)
        {
            var tag = new PlayFabTag();
            tag.TagValue = tagModel.TagValue;
            return tag;
        }

        /// <summary>
        /// Converts PlayFab model to bindable Delight model.
        /// </summary>
        public static PlayFabPushNotificationRegistration FromPushNotificationRegistrationModel(PushNotificationRegistrationModel pushNotificationModel)
        {
            var pushNotification = new PlayFabPushNotificationRegistration();
            pushNotification.NotificationEndpointARN = pushNotificationModel.NotificationEndpointARN;
            pushNotification.Platform = pushNotificationModel.Platform;
            return pushNotification;
        }

        /// <summary>
        /// Converts PlayFab model to bindable Delight model.
        /// </summary>
        public static PlayFabMembership FromMembershipModel(MembershipModel membershipModel)
        {
            var membership = new PlayFabMembership();
            membership.IsActive = membershipModel.IsActive;
            membership.MembershipExpiration = membershipModel.MembershipExpiration;
            membership.MembershipId = membershipModel.MembershipId;
            membership.OverrideExpiration = membershipModel.OverrideExpiration;
            membership.Subscriptions = FromPlayFabList(membershipModel.Subscriptions, FromSubscriptionModel);
            return membership;
        }

        /// <summary>
        /// Converts PlayFab model to bindable Delight model.
        /// </summary>
        public static PlayFabSubscription FromSubscriptionModel(SubscriptionModel subscriptionModel)
        {
            var subscription = new PlayFabSubscription();
            subscription.Expiration = subscriptionModel.Expiration;
            subscription.InitialSubscriptionTime = subscriptionModel.InitialSubscriptionTime;
            subscription.IsActive = subscriptionModel.IsActive;
            subscription.Status = subscriptionModel.Status;
            subscription.SubscriptionId = subscriptionModel.SubscriptionId;
            subscription.SubscriptionItemId = subscriptionModel.SubscriptionItemId;
            subscription.SubscriptionProvider = subscriptionModel.SubscriptionProvider;
            return subscription;
        }

        /// <summary>
        /// Converts PlayFab model to bindable Delight model.
        /// </summary>
        public static PlayFabLocation FromLocationModel(LocationModel locationModel)
        {
            var location = new PlayFabLocation();
            location.City = locationModel.City;
            location.ContinentCode = locationModel.ContinentCode;
            location.CountryCode = locationModel.CountryCode;
            location.Latitude = locationModel.Latitude;
            location.Longitude = locationModel.Longitude;
            return location;
        }

        /// <summary>
        /// Converts PlayFab model to bindable Delight model.
        /// </summary>
        public static PlayFabLinkedPlatformAccount FromLinkedPlatformAccountModel(LinkedPlatformAccountModel linkedAccountModel)
        {
            var linkedAccount = new PlayFabLinkedPlatformAccount();
            linkedAccount.Email = linkedAccountModel.Email;
            linkedAccount.Platform = linkedAccountModel.Platform;
            linkedAccount.PlatformUserId = linkedAccountModel.PlatformUserId;
            linkedAccount.Username = linkedAccountModel.Username;
            return linkedAccount;
        }

        /// <summary>
        /// Converts PlayFab model to bindable Delight model.
        /// </summary>
        public static PlayFabContactEmailInfo FromContactEmailInfoModel(ContactEmailInfoModel emailInfoModel)
        {
            var emailInfo = new PlayFabContactEmailInfo();
            emailInfo.EmailAddress = emailInfoModel.EmailAddress;
            emailInfo.Name = emailInfoModel.Name;
            emailInfo.VerificationStatus = emailInfoModel.VerificationStatus;
            return emailInfo;
        }

        /// <summary>
        /// Converts PlayFab model to bindable Delight model.
        /// </summary>
        public static PlayFabAdCampaignAttribution FromAdCampaignAttributionModel(AdCampaignAttributionModel adCampaignAttributionModel)
        {
            var adCampaignAttribution = new PlayFabAdCampaignAttribution();
            adCampaignAttribution.AttributedAt = adCampaignAttributionModel.AttributedAt;
            adCampaignAttribution.CampaignId = adCampaignAttributionModel.CampaignId;
            adCampaignAttribution.Platform = adCampaignAttributionModel.Platform;
            return adCampaignAttribution;
        }

        /// <summary>
        /// Converts PlayFab user data record to bindable Delight model.
        /// </summary>
        public static PlayFabUserDataRecord FromUserDataRecord(UserDataRecord userDataRecordObject)
        {
            var userDataRecord = new PlayFabUserDataRecord();
            userDataRecord.LastUpdated = userDataRecordObject.LastUpdated;
            userDataRecord.Value = userDataRecordObject.Value;
            userDataRecord.Permission = userDataRecordObject.Permission;
            return userDataRecord;
        }

        #endregion

        #endregion

        #region Properties

        public static GetPlayerCombinedInfoRequestParams DefaultInfoRequestParameters = new GetPlayerCombinedInfoRequestParams { GetPlayerProfile = true, GetUserData = true, GetUserInventory = true };

        #endregion
    }

    /// <summary>
    /// Base class for wrapper for PlayFab service results.
    /// </summary>
    public class PlayFabServiceResultBase
    {
        public bool Success;
        public PlayFabError Error;
    }

    /// <summary>
    /// Generic wrapper for PlayFab service results.
    /// </summary>
    public class PlayFabServiceResult<T> : PlayFabServiceResultBase
         where T : PlayFabResultCommon
    {
        public T Result;
    }

    // wrappers for PlayFab service results
    public class PlayFabAcceptTradeResponse : PlayFabServiceResult<PlayFab.ClientModels.AcceptTradeResponse> { }
    public class PlayFabAddFriendResult : PlayFabServiceResult<PlayFab.ClientModels.AddFriendResult> { }
    public class PlayFabAddGenericIDResult : PlayFabServiceResult<PlayFab.ClientModels.AddGenericIDResult> { }
    public class PlayFabAddOrUpdateContactEmailResult : PlayFabServiceResult<PlayFab.ClientModels.AddOrUpdateContactEmailResult> { }
    public class PlayFabAddSharedGroupMembersResult : PlayFabServiceResult<PlayFab.ClientModels.AddSharedGroupMembersResult> { }
    public class PlayFabAddUsernamePasswordResult : PlayFabServiceResult<PlayFab.ClientModels.AddUsernamePasswordResult> { }
    public class PlayFabAndroidDevicePushNotificationRegistrationResult : PlayFabServiceResult<PlayFab.ClientModels.AndroidDevicePushNotificationRegistrationResult> { }
    public class PlayFabAttributeInstallResult : PlayFabServiceResult<PlayFab.ClientModels.AttributeInstallResult> { }
    public class PlayFabCancelTradeResponse : PlayFabServiceResult<PlayFab.ClientModels.CancelTradeResponse> { }
    public class PlayFabConfirmPurchaseResult : PlayFabServiceResult<PlayFab.ClientModels.ConfirmPurchaseResult> { }
    public class PlayFabConsumeItemResult : PlayFabServiceResult<PlayFab.ClientModels.ConsumeItemResult> { }
    public class PlayFabConsumePSNEntitlementsResult : PlayFabServiceResult<PlayFab.ClientModels.ConsumePSNEntitlementsResult> { }
    public class PlayFabConsumeXboxEntitlementsResult : PlayFabServiceResult<PlayFab.ClientModels.ConsumeXboxEntitlementsResult> { }
    public class PlayFabCreateSharedGroupResult : PlayFabServiceResult<PlayFab.ClientModels.CreateSharedGroupResult> { }
    public class PlayFabCurrentGamesResult : PlayFabServiceResult<PlayFab.ClientModels.CurrentGamesResult> { }
    public class PlayFabEmptyResponse : PlayFabServiceResult<PlayFab.ClientModels.EmptyResponse> { }
    public class PlayFabEmptyResult : PlayFabServiceResult<PlayFab.ClientModels.EmptyResult> { }
    public class PlayFabExecuteCloudScriptResult : PlayFabServiceResult<PlayFab.ClientModels.ExecuteCloudScriptResult> { }
    public class PlayFabGameServerRegionsResult : PlayFabServiceResult<PlayFab.ClientModels.GameServerRegionsResult> { }
    public class PlayFabGetAccountInfoResult : PlayFabServiceResult<PlayFab.ClientModels.GetAccountInfoResult> { }
    public class PlayFabGetAdPlacementsResult : PlayFabServiceResult<PlayFab.ClientModels.GetAdPlacementsResult> { }
    public class PlayFabGetCatalogItemsResult : PlayFabServiceResult<PlayFab.ClientModels.GetCatalogItemsResult> { }
    public class PlayFabGetCharacterDataResult : PlayFabServiceResult<PlayFab.ClientModels.GetCharacterDataResult> { }
    public class PlayFabGetCharacterInventoryResult : PlayFabServiceResult<PlayFab.ClientModels.GetCharacterInventoryResult> { }
    public class PlayFabGetCharacterLeaderboardResult : PlayFabServiceResult<PlayFab.ClientModels.GetCharacterLeaderboardResult> { }
    public class PlayFabGetCharacterStatisticsResult : PlayFabServiceResult<PlayFab.ClientModels.GetCharacterStatisticsResult> { }
    public class PlayFabGetContentDownloadUrlResult : PlayFabServiceResult<PlayFab.ClientModels.GetContentDownloadUrlResult> { }
    public class PlayFabGetFriendLeaderboardAroundPlayerResult : PlayFabServiceResult<PlayFab.ClientModels.GetFriendLeaderboardAroundPlayerResult> { }
    public class PlayFabGetFriendsListResult : PlayFabServiceResult<PlayFab.ClientModels.GetFriendsListResult> { }
    public class PlayFabGetLeaderboardAroundCharacterResult : PlayFabServiceResult<PlayFab.ClientModels.GetLeaderboardAroundCharacterResult> { }
    public class PlayFabGetLeaderboardAroundPlayerResult : PlayFabServiceResult<PlayFab.ClientModels.GetLeaderboardAroundPlayerResult> { }
    public class PlayFabGetLeaderboardForUsersCharactersResult : PlayFabServiceResult<PlayFab.ClientModels.GetLeaderboardForUsersCharactersResult> { }
    public class PlayFabGetLeaderboardResult : PlayFabServiceResult<PlayFab.ClientModels.GetLeaderboardResult> { }
    public class PlayFabGetPaymentTokenResult : PlayFabServiceResult<PlayFab.ClientModels.GetPaymentTokenResult> { }
    public class PlayFabGetPhotonAuthenticationTokenResult : PlayFabServiceResult<PlayFab.ClientModels.GetPhotonAuthenticationTokenResult> { }
    public class PlayFabGetPlayerCombinedInfoResult : PlayFabServiceResult<PlayFab.ClientModels.GetPlayerCombinedInfoResult> { }
    public class PlayFabGetPlayerProfileResult : PlayFabServiceResult<PlayFab.ClientModels.GetPlayerProfileResult> { }
    public class PlayFabGetPlayerSegmentsResult : PlayFabServiceResult<PlayFab.ClientModels.GetPlayerSegmentsResult> { }
    public class PlayFabGetPlayerStatisticsResult : PlayFabServiceResult<PlayFab.ClientModels.GetPlayerStatisticsResult> { }
    public class PlayFabGetPlayerStatisticVersionsResult : PlayFabServiceResult<PlayFab.ClientModels.GetPlayerStatisticVersionsResult> { }
    public class PlayFabGetPlayerTagsResult : PlayFabServiceResult<PlayFab.ClientModels.GetPlayerTagsResult> { }
    public class PlayFabGetPlayerTradesResponse : PlayFabServiceResult<PlayFab.ClientModels.GetPlayerTradesResponse> { }
    public class PlayFabGetPlayFabIDsFromFacebookIDsResult : PlayFabServiceResult<PlayFab.ClientModels.GetPlayFabIDsFromFacebookIDsResult> { }
    public class PlayFabGetPlayFabIDsFromFacebookInstantGamesIdsResult : PlayFabServiceResult<PlayFab.ClientModels.GetPlayFabIDsFromFacebookInstantGamesIdsResult> { }
    public class PlayFabGetPlayFabIDsFromGameCenterIDsResult : PlayFabServiceResult<PlayFab.ClientModels.GetPlayFabIDsFromGameCenterIDsResult> { }
    public class PlayFabGetPlayFabIDsFromGenericIDsResult : PlayFabServiceResult<PlayFab.ClientModels.GetPlayFabIDsFromGenericIDsResult> { }
    public class PlayFabGetPlayFabIDsFromGoogleIDsResult : PlayFabServiceResult<PlayFab.ClientModels.GetPlayFabIDsFromGoogleIDsResult> { }
    public class PlayFabGetPlayFabIDsFromKongregateIDsResult : PlayFabServiceResult<PlayFab.ClientModels.GetPlayFabIDsFromKongregateIDsResult> { }
    public class PlayFabGetPlayFabIDsFromNintendoSwitchDeviceIdsResult : PlayFabServiceResult<PlayFab.ClientModels.GetPlayFabIDsFromNintendoSwitchDeviceIdsResult> { }
    public class PlayFabGetPlayFabIDsFromPSNAccountIDsResult : PlayFabServiceResult<PlayFab.ClientModels.GetPlayFabIDsFromPSNAccountIDsResult> { }
    public class PlayFabGetPlayFabIDsFromSteamIDsResult : PlayFabServiceResult<PlayFab.ClientModels.GetPlayFabIDsFromSteamIDsResult> { }
    public class PlayFabGetPlayFabIDsFromTwitchIDsResult : PlayFabServiceResult<PlayFab.ClientModels.GetPlayFabIDsFromTwitchIDsResult> { }
    public class PlayFabGetPlayFabIDsFromXboxLiveIDsResult : PlayFabServiceResult<PlayFab.ClientModels.GetPlayFabIDsFromXboxLiveIDsResult> { }
    public class PlayFabGetPublisherDataResult : PlayFabServiceResult<PlayFab.ClientModels.GetPublisherDataResult> { }
    public class PlayFabGetPurchaseResult : PlayFabServiceResult<PlayFab.ClientModels.GetPurchaseResult> { }
    public class PlayFabGetSharedGroupDataResult : PlayFabServiceResult<PlayFab.ClientModels.GetSharedGroupDataResult> { }
    public class PlayFabGetStoreItemsResult : PlayFabServiceResult<PlayFab.ClientModels.GetStoreItemsResult> { }
    public class PlayFabGetTimeResult : PlayFabServiceResult<PlayFab.ClientModels.GetTimeResult> { }
    public class PlayFabGetTitleDataResult : PlayFabServiceResult<PlayFab.ClientModels.GetTitleDataResult> { }
    public class PlayFabGetTitleNewsResult : PlayFabServiceResult<PlayFab.ClientModels.GetTitleNewsResult> { }
    public class PlayFabGetTitlePublicKeyResult : PlayFabServiceResult<PlayFab.ClientModels.GetTitlePublicKeyResult> { }
    public class PlayFabGetTradeStatusResponse : PlayFabServiceResult<PlayFab.ClientModels.GetTradeStatusResponse> { }
    public class PlayFabGetUserDataResult : PlayFabServiceResult<PlayFab.ClientModels.GetUserDataResult> { }
    public class PlayFabGetUserInventoryResult : PlayFabServiceResult<PlayFab.ClientModels.GetUserInventoryResult> { }
    public class PlayFabGetWindowsHelloChallengeResponse : PlayFabServiceResult<PlayFab.ClientModels.GetWindowsHelloChallengeResponse> { }
    public class PlayFabGrantCharacterToUserResult : PlayFabServiceResult<PlayFab.ClientModels.GrantCharacterToUserResult> { }
    public class PlayFabLinkAndroidDeviceIDResult : PlayFabServiceResult<PlayFab.ClientModels.LinkAndroidDeviceIDResult> { }
    public class PlayFabLinkCustomIDResult : PlayFabServiceResult<PlayFab.ClientModels.LinkCustomIDResult> { }
    public class PlayFabLinkFacebookAccountResult : PlayFabServiceResult<PlayFab.ClientModels.LinkFacebookAccountResult> { }
    public class PlayFabLinkFacebookInstantGamesIdResult : PlayFabServiceResult<PlayFab.ClientModels.LinkFacebookInstantGamesIdResult> { }
    public class PlayFabLinkGameCenterAccountResult : PlayFabServiceResult<PlayFab.ClientModels.LinkGameCenterAccountResult> { }
    public class PlayFabLinkGoogleAccountResult : PlayFabServiceResult<PlayFab.ClientModels.LinkGoogleAccountResult> { }
    public class PlayFabLinkIOSDeviceIDResult : PlayFabServiceResult<PlayFab.ClientModels.LinkIOSDeviceIDResult> { }
    public class PlayFabLinkKongregateAccountResult : PlayFabServiceResult<PlayFab.ClientModels.LinkKongregateAccountResult> { }
    public class PlayFabLinkNintendoSwitchDeviceIdResult : PlayFabServiceResult<PlayFab.ClientModels.LinkNintendoSwitchDeviceIdResult> { }
    public class PlayFabLinkPSNAccountResult : PlayFabServiceResult<PlayFab.ClientModels.LinkPSNAccountResult> { }
    public class PlayFabLinkSteamAccountResult : PlayFabServiceResult<PlayFab.ClientModels.LinkSteamAccountResult> { }
    public class PlayFabLinkTwitchAccountResult : PlayFabServiceResult<PlayFab.ClientModels.LinkTwitchAccountResult> { }
    public class PlayFabLinkWindowsHelloAccountResponse : PlayFabServiceResult<PlayFab.ClientModels.LinkWindowsHelloAccountResponse> { }
    public class PlayFabLinkXboxAccountResult : PlayFabServiceResult<PlayFab.ClientModels.LinkXboxAccountResult> { }
    public class PlayFabListUsersCharactersResult : PlayFabServiceResult<PlayFab.ClientModels.ListUsersCharactersResult> { }
    public class PlayFabLoginResult : PlayFabServiceResult<PlayFab.ClientModels.LoginResult> { }
    public class PlayFabMatchmakeResult : PlayFabServiceResult<PlayFab.ClientModels.MatchmakeResult> { }
    public class PlayFabModifyUserVirtualCurrencyResult : PlayFabServiceResult<PlayFab.ClientModels.ModifyUserVirtualCurrencyResult> { }
    public class PlayFabOpenTradeResponse : PlayFabServiceResult<PlayFab.ClientModels.OpenTradeResponse> { }
    public class PlayFabPayForPurchaseResult : PlayFabServiceResult<PlayFab.ClientModels.PayForPurchaseResult> { }
    public class PlayFabPurchaseItemResult : PlayFabServiceResult<PlayFab.ClientModels.PurchaseItemResult> { }
    public class PlayFabRedeemCouponResult : PlayFabServiceResult<PlayFab.ClientModels.RedeemCouponResult> { }
    public class PlayFabRegisterForIOSPushNotificationResult : PlayFabServiceResult<PlayFab.ClientModels.RegisterForIOSPushNotificationResult> { }
    public class PlayFabRegisterPlayFabUserResult : PlayFabServiceResult<PlayFab.ClientModels.RegisterPlayFabUserResult> { }
    public class PlayFabRemoveContactEmailResult : PlayFabServiceResult<PlayFab.ClientModels.RemoveContactEmailResult> { }
    public class PlayFabRemoveFriendResult : PlayFabServiceResult<PlayFab.ClientModels.RemoveFriendResult> { }
    public class PlayFabRemoveGenericIDResult : PlayFabServiceResult<PlayFab.ClientModels.RemoveGenericIDResult> { }
    public class PlayFabRemoveSharedGroupMembersResult : PlayFabServiceResult<PlayFab.ClientModels.RemoveSharedGroupMembersResult> { }
    public class PlayFabReportAdActivityResult : PlayFabServiceResult<PlayFab.ClientModels.ReportAdActivityResult> { }
    public class PlayFabReportPlayerClientResult : PlayFabServiceResult<PlayFab.ClientModels.ReportPlayerClientResult> { }
    public class PlayFabRestoreIOSPurchasesResult : PlayFabServiceResult<PlayFab.ClientModels.RestoreIOSPurchasesResult> { }
    public class PlayFabRewardAdActivityResult : PlayFabServiceResult<PlayFab.ClientModels.RewardAdActivityResult> { }
    public class PlayFabSendAccountRecoveryEmailResult : PlayFabServiceResult<PlayFab.ClientModels.SendAccountRecoveryEmailResult> { }
    public class PlayFabSetFriendTagsResult : PlayFabServiceResult<PlayFab.ClientModels.SetFriendTagsResult> { }
    public class PlayFabSetPlayerSecretResult : PlayFabServiceResult<PlayFab.ClientModels.SetPlayerSecretResult> { }
    public class PlayFabStartGameResult : PlayFabServiceResult<PlayFab.ClientModels.StartGameResult> { }
    public class PlayFabStartPurchaseResult : PlayFabServiceResult<PlayFab.ClientModels.StartPurchaseResult> { }
    public class PlayFabUnlinkAndroidDeviceIDResult : PlayFabServiceResult<PlayFab.ClientModels.UnlinkAndroidDeviceIDResult> { }
    public class PlayFabUnlinkCustomIDResult : PlayFabServiceResult<PlayFab.ClientModels.UnlinkCustomIDResult> { }
    public class PlayFabUnlinkFacebookAccountResult : PlayFabServiceResult<PlayFab.ClientModels.UnlinkFacebookAccountResult> { }
    public class PlayFabUnlinkFacebookInstantGamesIdResult : PlayFabServiceResult<PlayFab.ClientModels.UnlinkFacebookInstantGamesIdResult> { }
    public class PlayFabUnlinkGameCenterAccountResult : PlayFabServiceResult<PlayFab.ClientModels.UnlinkGameCenterAccountResult> { }
    public class PlayFabUnlinkGoogleAccountResult : PlayFabServiceResult<PlayFab.ClientModels.UnlinkGoogleAccountResult> { }
    public class PlayFabUnlinkIOSDeviceIDResult : PlayFabServiceResult<PlayFab.ClientModels.UnlinkIOSDeviceIDResult> { }
    public class PlayFabUnlinkKongregateAccountResult : PlayFabServiceResult<PlayFab.ClientModels.UnlinkKongregateAccountResult> { }
    public class PlayFabUnlinkNintendoSwitchDeviceIdResult : PlayFabServiceResult<PlayFab.ClientModels.UnlinkNintendoSwitchDeviceIdResult> { }
    public class PlayFabUnlinkPSNAccountResult : PlayFabServiceResult<PlayFab.ClientModels.UnlinkPSNAccountResult> { }
    public class PlayFabUnlinkSteamAccountResult : PlayFabServiceResult<PlayFab.ClientModels.UnlinkSteamAccountResult> { }
    public class PlayFabUnlinkTwitchAccountResult : PlayFabServiceResult<PlayFab.ClientModels.UnlinkTwitchAccountResult> { }
    public class PlayFabUnlinkWindowsHelloAccountResponse : PlayFabServiceResult<PlayFab.ClientModels.UnlinkWindowsHelloAccountResponse> { }
    public class PlayFabUnlinkXboxAccountResult : PlayFabServiceResult<PlayFab.ClientModels.UnlinkXboxAccountResult> { }
    public class PlayFabUnlockContainerItemResult : PlayFabServiceResult<PlayFab.ClientModels.UnlockContainerItemResult> { }
    public class PlayFabUpdateCharacterDataResult : PlayFabServiceResult<PlayFab.ClientModels.UpdateCharacterDataResult> { }
    public class PlayFabUpdateCharacterStatisticsResult : PlayFabServiceResult<PlayFab.ClientModels.UpdateCharacterStatisticsResult> { }
    public class PlayFabUpdatePlayerStatisticsResult : PlayFabServiceResult<PlayFab.ClientModels.UpdatePlayerStatisticsResult> { }
    public class PlayFabUpdateSharedGroupDataResult : PlayFabServiceResult<PlayFab.ClientModels.UpdateSharedGroupDataResult> { }
    public class PlayFabUpdateUserDataResult : PlayFabServiceResult<PlayFab.ClientModels.UpdateUserDataResult> { }
    public class PlayFabUpdateUserTitleDisplayNameResult : PlayFabServiceResult<PlayFab.ClientModels.UpdateUserTitleDisplayNameResult> { }
    public class PlayFabValidateAmazonReceiptResult : PlayFabServiceResult<PlayFab.ClientModels.ValidateAmazonReceiptResult> { }
    public class PlayFabValidateGooglePlayPurchaseResult : PlayFabServiceResult<PlayFab.ClientModels.ValidateGooglePlayPurchaseResult> { }
    public class PlayFabValidateIOSReceiptResult : PlayFabServiceResult<PlayFab.ClientModels.ValidateIOSReceiptResult> { }
    public class PlayFabValidateWindowsReceiptResult : PlayFabServiceResult<PlayFab.ClientModels.ValidateWindowsReceiptResult> { }
    public class PlayFabWriteEventResponse : PlayFabServiceResult<PlayFab.ClientModels.WriteEventResponse> { }
}

#endif