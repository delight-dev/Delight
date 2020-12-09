#region Using Statements
using System;
#endregion

namespace Delight
{
    /// <summary>
    /// Represents a subscription.
    /// </summary>
    public partial class PlayFabSubscription : ModelObject
    {
        #region Properties

        private DateTime _Expiration;
        /// <summary>
        /// When this subscription expires.
        /// </summary>
        public DateTime Expiration
        {
            get { return _Expiration; }
            set { SetProperty(ref _Expiration, value); }
        }

        private DateTime _InitialSubscriptionTime;
        /// <summary>
        /// The time the subscription was orignially purchased
        /// </summary>
        public DateTime InitialSubscriptionTime
        {
            get { return _InitialSubscriptionTime; }
            set { SetProperty(ref _InitialSubscriptionTime, value); }
        }

        private bool _IsActive;
        /// <summary>
        /// Whether this subscription is currently active. That is, if Expiration > now.
        /// </summary>
        public bool IsActive
        {
            get { return _IsActive; }
            set { SetProperty(ref _IsActive, value); }
        }

        private PlayFab.ClientModels.SubscriptionProviderStatus? _Status;
        /// <summary>
        /// The status of this subscription, according to the subscription provider.
        /// </summary>
        public PlayFab.ClientModels.SubscriptionProviderStatus? Status
        {
            get { return _Status; }
            set { SetProperty(ref _Status, value); }
        }

        private string _SubscriptionId;
        /// <summary>
        /// The id for this subscription
        /// </summary>
        public string SubscriptionId
        {
            get { return _SubscriptionId; }
            set { SetProperty(ref _SubscriptionId, value); }
        }

        private string _SubscriptionItemId;
        /// <summary>
        /// The item id for this subscription from the primary catalog
        /// </summary>
        public string SubscriptionItemId
        {
            get { return _SubscriptionItemId; }
            set { SetProperty(ref _SubscriptionItemId, value); }
        }

        private string _SubscriptionProvider;
        /// <summary>
        /// The provider for this subscription. Apple or Google Play are supported today.
        /// </summary>
        public string SubscriptionProvider
        {
            get { return _SubscriptionProvider; }
            set { SetProperty(ref _SubscriptionProvider, value); }
        }

        #endregion
    }
}
