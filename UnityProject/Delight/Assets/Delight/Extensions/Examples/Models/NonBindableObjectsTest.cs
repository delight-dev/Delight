// for testing binding to non-bindable objects
#region Using Statements
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    /// <summary>
    /// For testing the binding system with non-bindable objects.
    /// </summary>
    public partial class NonBindableLevel
    {
        #region Properties

        public string Name { get; set; }
        public int Score { get; set; }
        public bool IsLocked { get; set; }
        public SpriteAsset Stars
        {
            get
            {
                return Assets.Sprites["Stars" + Score];
            }
        }

        #endregion
    }

    #region Data Provider

    public static partial class Models
    {
        public static ObservableCollection<NonBindableLevel> NonBindableLevels = new ObservableCollection<NonBindableLevel>();
    }

    #endregion
}
