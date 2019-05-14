#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
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
        public LocalizationLabel Greeting1 = new LocalizationLabel { Id = "Greeting1", Label = "Test 1" };
        public LocalizationLabel Greeting2 = new LocalizationLabel { Id = "Greeting2", Label = "Test 2" };
    }

    public static partial class Models
    {
        public static LocalizationData Loc = new LocalizationData();
    }

    #endregion
}
