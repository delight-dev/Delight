#region Using Statements
#endregion

namespace Delight
{
    /// <summary>
    /// Represents a tag.
    /// </summary>
    public partial class PlayFabTag : ModelObject
    {
        #region Properties

        private string _TagValue;
        /// <summary>
        /// Full value of the tag, including namespace
        /// </summary>
        public string TagValue
        {
            get { return _TagValue; }
            set { SetProperty(ref _TagValue, value); }
        }

        #endregion
    }
}
