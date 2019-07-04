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
    /// Contains arguments for the collection selection event.
    /// </summary>
    public class CollectionSelectionEventArgs : CollectionChangedEventArgs
    {
        public bool ScrollTo;
        public bool Select;
        public ElementAlignment? Alignment;
        public ElementMargin Offset;
    }

    /// <summary>
    /// Contains a batch of collection changed event arguments.
    /// </summary>
    public class BatchedCollectionChangedEventArgs : CollectionChangedEventArgs
    {
        public List<CollectionChangedEventArgs> CollectionChangedEventArgsBatch;
    }
}
