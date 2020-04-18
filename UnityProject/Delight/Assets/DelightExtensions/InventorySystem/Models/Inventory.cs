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
        /// <summary>
        /// Adds item to inventory.
        /// </summary>
        public void AddItem(Item item)
        {
            InventoryItems.Add(new InventoryItem { Item = item, Inventory = this });
        }
    }
}
