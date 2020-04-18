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
    public partial class InventoryItem : ModelObject
    {
        #region Properties

        [SerializeField]
        public string InventoryId { get; set; }
        public Inventory Inventory
        {
            get { return Models.Inventories[InventoryId]; }
            set { InventoryId = value?.Id; }
        }

        [SerializeField]
        public string ItemId { get; set; }
        public Item Item
        {
            get { return Models.Items[ItemId]; }
            set { ItemId = value?.Id; }
        }

        [SerializeField]
        private Vector2 _position;
        public Vector2 Position
        {
            get { return _position; }
            set { SetProperty(ref _position, value); }
        }

        #endregion
    }

    #region Data Provider

    public partial class InventoryItemData : DataProvider<InventoryItem>
    {
        #region Fields


        #endregion

        #region Constructor

        public InventoryItemData()
        {
            Add(new InventoryItem { InventoryId = "DefaultInventory", ItemId = "SwordItem1" });
            Add(new InventoryItem { InventoryId = "DefaultInventory", ItemId = "SwordItem2" });
        }

        #endregion

        #region Methods

        protected Dictionary<string, BindableCollectionSubset<InventoryItem>> _inventoryInventoryItems = new Dictionary<string, BindableCollectionSubset<InventoryItem>>();
        public virtual BindableCollectionSubset<InventoryItem> Get(Inventory inventory)
        {
            if (inventory == null)
                return null;

            string inventoryId = inventory.Id;
            BindableCollectionSubset<InventoryItem> inventoryInventoryItems;
            if (_inventoryInventoryItems.TryGetValue(inventoryId, out inventoryInventoryItems))
                return inventoryInventoryItems;

            inventoryInventoryItems = new BindableCollectionSubset<InventoryItem>(this, x => x.InventoryId == inventoryId, x => x.InventoryId = inventoryId);
            _inventoryInventoryItems.Add(inventoryId, inventoryInventoryItems);
            return inventoryInventoryItems;
        }

        #endregion
    }

    public static partial class Models
    {
        public static InventoryItemData InventoryItems = new InventoryItemData();
    }

    #endregion
}
