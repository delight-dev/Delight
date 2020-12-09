#region Using Statements
#endregion

namespace Delight
{
    /// <summary>
    /// Represents contact email info.
    /// </summary>
    public partial class PlayFabContactEmailInfo : ModelObject
    {
        #region Properties

        private string _EmailAddress;
        /// <summary>
        /// The email address
        /// </summary>
        public string EmailAddress
        {
            get { return _EmailAddress; }
            set { SetProperty(ref _EmailAddress, value); }
        }

        private string _Name;
        /// <summary>
        /// The name of the email info data
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { SetProperty(ref _Name, value); }
        }

        private PlayFab.ClientModels.EmailVerificationStatus? _VerificationStatus;
        /// <summary>
        /// The verification status of the email
        /// </summary>
        public PlayFab.ClientModels.EmailVerificationStatus? VerificationStatus
        {
            get { return _VerificationStatus; }
            set { SetProperty(ref _VerificationStatus, value); }
        }

        #endregion
    }
}
