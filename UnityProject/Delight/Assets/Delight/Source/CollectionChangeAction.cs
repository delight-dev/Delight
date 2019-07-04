namespace Delight
{
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
        /// Items added to collection.
        /// </summary>
        AddRange = 1,

        /// <summary>
        /// Item removed from collection.
        /// </summary>
        Remove = 2,

        /// <summary>
        /// Items removed from collection.
        /// </summary>
        RemoveRange = 3,

        /// <summary>
        /// All items in collection replaced with new set of items.
        /// </summary>
        Replace = 4,

        /// <summary>
        /// All items cleared from collection.
        /// </summary>
        Clear = 5,

        /// <summary>
        /// Scroll to specified item.
        /// </summary>
        ScrollTo = 6,

        /// <summary>
        /// Selects the specified item.
        /// </summary>
        Select = 7,

        /// <summary>
        /// Batch of actions performed.
        /// </summary>
        Batch = 8
    }
}