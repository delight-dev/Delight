#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
#endregion

namespace Delight
{
    /// <summary>
    /// Contains arguments for the collection changed event.
    /// </summary>
    public class CollectionChangedEventArgs : EventArgs
    {
        public CollectionChangeAction ChangeAction;
        public BindableObject Item;
    }

    /// <summary>
    /// Enum indicating how the collection has changed.
    /// </summary>
    public enum CollectionChangeAction
    {
        /// <summary>
        /// Item added to collection.
        /// </summary>
        Add = 0,

        /// <summary>
        /// Item removed from collection.
        /// </summary>
        Remove = 1,

        /// <summary>
        /// All items in collection replaced with new set of items.
        /// </summary>
        Replace = 2,

        /// <summary>
        /// All items cleared from collection.
        /// </summary>
        Clear = 3
    }
}
