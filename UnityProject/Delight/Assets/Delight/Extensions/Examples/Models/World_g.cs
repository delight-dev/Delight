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
    public partial class World : ModelObject
    {
        #region Properties

        [SerializeField]
        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        public BindableCollection<Level> Levels
        {
            get { return Models.Levels.Get(this); }
        }

        #endregion
    }

    #region Data Provider

    public partial class WorldData : DataProvider<World>
    {
    }

    public static partial class Models
    {
        public static WorldData Worlds = new WorldData();
    }

    #endregion
}
