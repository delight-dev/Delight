#region Using Statements
#endregion

namespace Delight
{
    /// <summary>
    /// Represents a location.
    /// </summary>
    public partial class PlayFabLocation : ModelObject
    {
        #region Properties

        private string _City;
        /// <summary>
        /// City name.
        /// </summary>
        public string City
        {
            get { return _City; }
            set { SetProperty(ref _City, value); }
        }

        private PlayFab.ClientModels.ContinentCode? _ContinentCode;
        /// <summary>
        /// The two-character continent code for this location
        /// </summary>
        public PlayFab.ClientModels.ContinentCode? ContinentCode
        {
            get { return _ContinentCode; }
            set { SetProperty(ref _ContinentCode, value); }
        }

        private PlayFab.ClientModels.CountryCode? _CountryCode;
        /// <summary>
        /// The two-character ISO 3166-1 country code for the country associated with the location
        /// </summary>
        public PlayFab.ClientModels.CountryCode? CountryCode
        {
            get { return _CountryCode; }
            set { SetProperty(ref _CountryCode, value); }
        }

        private double? _Latitude;
        /// <summary>
        /// Latitude coordinate of the geographic location.
        /// </summary>
        public double? Latitude
        {
            get { return _Latitude; }
            set { SetProperty(ref _Latitude, value); }
        }

        private double? _Longitude;
        /// <summary>
        /// Longitude coordinate of the geographic location.
        /// </summary>
        public double? Longitude
        {
            get { return _Longitude; }
            set { SetProperty(ref _Longitude, value); }
        }

        #endregion
    }
}
