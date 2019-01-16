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
        public int Index;
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
        /// Item moved within collection.
        /// </summary>
        Move = 1,

        /// <summary>
        /// Item removed from collection.
        /// </summary>
        Remove = 2,

        /// <summary>
        /// Item replaced in collection.
        /// </summary>
        Replace = 3,

        /// <summary>
        /// All items cleared from collection.
        /// </summary>
        Clear = 4,

        /// <summary>
        /// Items modified in collection.
        /// </summary>
        Modify = 5
    }
}
