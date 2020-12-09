#region Using Statements
#endregion

namespace Delight
{
    /// <summary>
    /// Represents a linked platform account.
    /// </summary>
    public partial class PlayFabLinkedPlatformAccount : ModelObject
    {
        #region Properties

        private string _Email;
        /// <summary>
        /// Linked account email of the user on the platform, if available
        /// </summary>
        public string Email
        {
            get { return _Email; }
            set { SetProperty(ref _Email, value); }
        }

        private PlayFab.ClientModels.LoginIdentityProvider? _Platform;
        /// <summary>
        /// Authentication platform
        /// </summary>
        public PlayFab.ClientModels.LoginIdentityProvider? Platform
        {
            get { return _Platform; }
            set { SetProperty(ref _Platform, value); }
        }

        private string _PlatformUserId;
        /// <summary>
        /// Unique account identifier of the user on the platform
        /// </summary>
        public string PlatformUserId
        {
            get { return _PlatformUserId; }
            set { SetProperty(ref _PlatformUserId, value); }
        }

        private string _Username;
        /// <summary>
        /// Linked account username of the user on the platform, if available
        /// </summary>
        public string Username
        {
            get { return _Username; }
            set { SetProperty(ref _Username, value); }
        }

        #endregion
    }
}
