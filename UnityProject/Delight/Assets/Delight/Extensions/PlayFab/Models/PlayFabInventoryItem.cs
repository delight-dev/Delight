#region Using Statements
using System;
using System.Collections.Generic;
#endregion

namespace Delight
{
    /// <summary>
    /// Represents inventory item.
    /// </summary>
    public partial class PlayFabInventoryItem : ModelObject
    {
        #region Properties

        private bool _IsOwnedByPlayer;
        /// <summary>
        /// Boolean indicating if item is owned by player.
        /// </summary>
        public bool IsOwnedByPlayer
        {
            get { return _IsOwnedByPlayer; }
            set { SetProperty(ref _IsOwnedByPlayer, value); }
        }

        private string _CatalogVersion;
        /// <summary>
        /// Boolean indicating if item is owned by player.
        /// </summary>
        public string CatalogVersion
        {
            get { return _CatalogVersion; }
            set { SetProperty(ref _CatalogVersion, value); }
        }

        private string _DisplayName;
        /// <summary>
        /// Display name of the item at the time it was purchased. 
        /// </summary>
        public string DisplayName
        {
            get { return _DisplayName; }
            set { SetProperty(ref _DisplayName, value); }
        }

        private string _ItemClass;
        /// <summary>
        /// Class name for the inventory item.
        /// </summary>
        public string ItemClass
        {
            get { return _ItemClass; }
            set { SetProperty(ref _ItemClass, value); }
        }

        private uint _UnitPrice;
        /// <summary>
        /// Cost of the catalog item in the given currency.
        /// </summary>
        public uint UnitPrice
        {
            get { return _UnitPrice; }
            set { SetProperty(ref _UnitPrice, value); }
        }

        private string _UnitCurrency;
        /// <summary>
        /// Currency type for the item.
        /// </summary>
        public string UnitCurrency
        {
            get { return _UnitCurrency; }
            set { SetProperty(ref _UnitCurrency, value); }
        }

        private Dictionary<string, string> _CustomData;
        /// <summary>
        /// Custom data for item.
        /// </summary>
        public Dictionary<string, string> CustomData
        {
            get { return _CustomData; }
            set { SetProperty(ref _CustomData, value); }
        }

        #endregion
    }
}