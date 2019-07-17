#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    /// <summary>
    /// Holds information about a localized label. Used by the localization mechanism. 
    /// </summary>
    public partial class LocalizationLabel : ModelObject
    {
        #region Properties

        private string _label;
        public string Label
        {
            get { return _label; }
            set { SetProperty(ref _label, value); }
        }

        #endregion

        #region Methods

        public static implicit operator string(LocalizationLabel loc)
        {
            return loc?.Label;
        }

        #endregion
    }

    #region Data Provider

    public partial class LocalizationData : DataProvider<LocalizationLabel>
    {
    }

    public static partial class Models
    {
        public static LocalizationData Loc = new LocalizationData();
    }

    #endregion
}
