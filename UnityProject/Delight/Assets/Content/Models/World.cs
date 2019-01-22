#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class World : BindableObject
    {
        private int _order;
        public int Order
        {
            get { return _order; }
            set { SetProperty(ref _order, value); }
        }

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
    }

    public partial class WorldData : DataProvider<World>
    {
        public WorldData()
        {
            Add(new World { Id = "World1", Name = "World 1", Order = 1 });
            Add(new World { Id = "World2", Name = "World 2", Order = 2 });
            Add(new World { Id = "World3", Name = "World 3", Order = 3 });
        }
    }

    public static partial class Models
    {
        public static WorldData Worlds = new WorldData();
    }
}
