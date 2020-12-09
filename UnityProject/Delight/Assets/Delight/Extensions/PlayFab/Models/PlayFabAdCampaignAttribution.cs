#region Using Statements
using System;
#endregion

namespace Delight
{
    /// <summary>
    /// Represents an ad campaign attribution.
    /// </summary>
    public partial class PlayFabAdCampaignAttribution : ModelObject
    {
        #region Properties

        private DateTime _AttributedAt;
        /// <summary>
        /// UTC time stamp of attribution
        /// </summary>
        public DateTime AttributedAt
        {
            get { return _AttributedAt; }
            set { SetProperty(ref _AttributedAt, value); }
        }

        private string _CampaignId;
        /// <summary>
        /// Attribution campaign identifier
        /// </summary>
        public string CampaignId
        {
            get { return _CampaignId; }
            set { SetProperty(ref _CampaignId, value); }
        }

        private string _Platform;
        /// <summary>
        /// Attribution network name
        /// </summary>
        public string Platform
        {
            get { return _Platform; }
            set { SetProperty(ref _Platform, value); }
        }

        #endregion
    }
}
