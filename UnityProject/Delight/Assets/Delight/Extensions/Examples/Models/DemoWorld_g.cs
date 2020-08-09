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
    [Serializable]
    public partial class DemoWorld : ModelObject
    {
        #region Properties

        [SerializeField]
        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        public BindableCollection<DemoLevel> DemoLevels
        {
            get { return Models.DemoLevels.Get(this); }
        }

        #endregion
    }

    #region Data Provider

    public partial class DemoWorldData : DataProvider<DemoWorld>
    {
    }

    public static partial class Models
    {
        public static DemoWorldData DemoWorlds = new DemoWorldData();
    }

    #endregion
}
