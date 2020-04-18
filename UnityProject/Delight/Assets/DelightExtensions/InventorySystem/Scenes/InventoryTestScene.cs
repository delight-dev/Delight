#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
#endregion

namespace Delight
{
    public partial class InventoryTestScene
    {
        public void AddItem()
        {
            Models.Inventories.DefaultInventory.AddItem(Models.Items["SwordItem1"]);
        }
    }
}
