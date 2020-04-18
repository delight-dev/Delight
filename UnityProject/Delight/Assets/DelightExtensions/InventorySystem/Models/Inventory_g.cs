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
    public partial class Inventory : ModelObject
    {
        #region Properties

        public BindableCollection<InventoryItem> InventoryItems
        {
            get { return Models.InventoryItems.Get(this); }
        }

        #endregion
    }

    #region Data Provider

    public partial class InventoryData : DataProvider<Inventory>
    {
        #region Fields

        public readonly Inventory DefaultInventory;

        #endregion

        #region Constructor

        public InventoryData()
        {
            DefaultInventory = new Inventory { Id = "DefaultInventory" };
            Add(DefaultInventory);
        }

        #endregion
    }

    public static partial class Models
    {
        public static InventoryData Inventories = new InventoryData();
    }

    #endregion
}
