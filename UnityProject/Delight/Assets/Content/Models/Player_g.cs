// Model generated from "Schema.txt"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class Player : ModelObject
    {
        #region Properties

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        public BindableCollection<Achievement> Achievements
        {
            get { return Models.Achievements.Get(this); }
        }

        #endregion
    }

    #region Data Provider

    public partial class PlayerData : DataProvider<Player>
    {
        #region Constructor


        #endregion
    }

    public static partial class Models
    {
        public static PlayerData Players = new PlayerData();
    }

    #endregion
}
