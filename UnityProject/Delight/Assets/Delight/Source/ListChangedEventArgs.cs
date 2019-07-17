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
}
