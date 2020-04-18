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
    public partial class Item : ModelObject
    {
        #region Properties

        [SerializeField]
        public string IconId { get; set; }
        public SpriteAsset Icon
        {
            get { return Assets.Sprites[IconId]; }
            set { IconId = value?.Id; }
        }

        [SerializeField]
        private String _name;
        public String Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        #endregion
    }

    #region Data Provider

    public partial class ItemData : DataProvider<Item>
    {
        #region Fields

        public readonly Item SwordItem1;
        public readonly Item SwordItem2;
        public readonly Item SwordItem3;

        #endregion

        #region Constructor

        public ItemData()
        {
            SwordItem1 = new Item { Id = "SwordItem1", Icon = Assets.Sprites["SwordIcon"], Name = "Sword" };
            Add(SwordItem1);
            SwordItem2 = new Item { Id = "SwordItem2", Icon = Assets.Sprites["SwordIcon"], Name = "Sword 2" };
            Add(SwordItem2);
            SwordItem3 = new Item { Id = "SwordItem3", Icon = Assets.Sprites["SwordIcon"], Name = "Sword 3" };
            Add(SwordItem3);
            Add(new Item { Icon = Assets.Sprites["SwordIcon"], Name = "Sword 4" });
            Add(new Item { Icon = Assets.Sprites["SwordIcon"], Name = "Sword 5" });
            Add(new Item { Icon = Assets.Sprites["SwordIcon"], Name = "Sword 6" });
        }

        #endregion
    }

    public static partial class Models
    {
        public static ItemData Items = new ItemData();
    }

    #endregion
}
