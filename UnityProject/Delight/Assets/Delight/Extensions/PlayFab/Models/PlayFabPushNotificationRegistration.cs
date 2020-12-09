#region Using Statements
using PlayFab.ClientModels;
#endregion

namespace Delight
{
    /// <summary>
    /// Represents a push notification registration.
    /// </summary>
    public partial class PlayFabPushNotificationRegistration : ModelObject
    {
        #region Properties

        /// <summary>
        /// Notification configured endpoint
        /// </summary>
        private string _NotificationEndpointARN;
        public string NotificationEndpointARN
        {
            get { return _NotificationEndpointARN; }
            set { SetProperty(ref _NotificationEndpointARN, value); }
        }

        /// <summary>
        /// Push notification platform
        /// </summary>
        private PushNotificationPlatform? _Platform;
        public PushNotificationPlatform? Platform
        {
            get { return _Platform; }
            set { SetProperty(ref _Platform, value); }
        }

        #endregion
    }
}
