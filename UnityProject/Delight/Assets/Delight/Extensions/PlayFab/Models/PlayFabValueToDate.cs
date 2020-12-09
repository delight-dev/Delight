#region Using Statements
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    /// <summary>
    /// Represents a player value to date.
    /// </summary>
    public partial class PlayFabValueToDate : ModelObject
    {
        #region Properties

        private string _Currency;
        /// <summary>
        /// ISO 4217 code of the currency used in the purchases
        /// </summary>
        public string Currency
        {
            get { return _Currency; }
            set { SetProperty(ref _Currency, value); }
        }

        private uint _TotalValue;
        /// <summary>
        /// Total value of the purchases in a whole number of 1/100 monetary units. For example, 999 indicates nine dollars and
        /// ninety-nine cents when Currency is 'USD')
        /// </summary>
        public uint TotalValue
        {
            get { return _TotalValue; }
            set { SetProperty(ref _TotalValue, value); }
        }

        private string _TotalValueAsDecimal;
        /// <summary>
        /// Total value of the purchases in a string representation of decimal monetary units. For example, '9.99' indicates nine
        /// dollars and ninety-nine cents when Currency is 'USD'.
        /// </summary>
        public string TotalValueAsDecimal
        {
            get { return _TotalValueAsDecimal; }
            set { SetProperty(ref _TotalValueAsDecimal, value); }
        }

        #endregion
    }

    // TODO remove

    /// <summary>
    /// Represents a player XYZ.
    /// </summary>
    public partial class PlayFabXYZ : ModelObject
    {
        #region Properties
        #endregion
    }
}
