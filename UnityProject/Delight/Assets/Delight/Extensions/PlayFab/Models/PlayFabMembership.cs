#region Using Statements
using System;
#endregion

namespace Delight
{
    /// <summary>
    /// Represents a membership.
    /// </summary>
    public partial class PlayFabMembership : ModelObject
    {
        #region Properties

        private bool _IsActive;
        /// <summary>
        /// Whether this membership is active. That is, whether the MembershipExpiration time has been reached.
        /// </summary>
        public bool IsActive
        {
            get { return _IsActive; }
            set { SetProperty(ref _IsActive, value); }
        }

        private DateTime _MembershipExpiration;
        /// <summary>
        /// The time this membership expires
        /// </summary>
        public DateTime MembershipExpiration
        {
            get { return _MembershipExpiration; }
            set { SetProperty(ref _MembershipExpiration, value); }
        }

        private string _MembershipId;
        /// <summary>
        /// The id of the membership
        /// </summary>
        public string MembershipId
        {
            get { return _MembershipId; }
            set { SetProperty(ref _MembershipId, value); }
        }

        private DateTime? _OverrideExpiration;
        /// <summary>
        /// Membership expirations can be explicitly overridden (via game manager or the admin api). If this membership has been
        /// overridden, this will be the new expiration time.
        /// </summary>
        public DateTime? OverrideExpiration
        {
            get { return _OverrideExpiration; }
            set { SetProperty(ref _OverrideExpiration, value); }
        }

        private BindableCollection<PlayFabSubscription> _Subscriptions;
        /// <summary>
        /// The list of subscriptions that this player has for this membership
        /// </summary>
        public BindableCollection<PlayFabSubscription> Subscriptions
        {
            get { return _Subscriptions; }
            set { SetProperty(ref _Subscriptions, value); }
        }

        #endregion
    }
}
