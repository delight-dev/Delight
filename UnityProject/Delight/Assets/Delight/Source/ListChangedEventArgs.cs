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
    /// Contains arguments for the list changed event.
    /// </summary>
    public class ListChangedEventArgs : EventArgs
    {
        public ListChangeAction ListChangeAction;
        public int StartIndex;
        public int EndIndex;
        public ElementAlignment? Alignment;
    }

    /// <summary>
    /// Enum indicating type of list change action initiated.
    /// </summary>
    public enum ListChangeAction
    {
        /// <summary>
        /// Items added to list.
        /// </summary>
        Add = 0,

        /// <summary>
        /// Items rearranged within list.
        /// </summary>
        Rearranged = 1,

        /// <summary>
        /// Items removed from list.
        /// </summary>
        Remove = 2,

        /// <summary>
        /// Items replaced in list.
        /// </summary>
        Replace = 3,

        /// <summary>
        /// All items cleared from list.
        /// </summary>
        Clear = 4,

        /// <summary>
        /// Items modified in list.
        /// </summary>
        Modify = 5,

        /// <summary>
        /// Item selected in list.
        /// </summary>
        Select = 6,

        /// <summary>
        /// Item scrolled to.
        /// </summary>
        ScrollTo = 7,

        /// <summary>
        /// DynamicAdd.
        /// </summary>
        DynamicAdd = 8

    }
}
