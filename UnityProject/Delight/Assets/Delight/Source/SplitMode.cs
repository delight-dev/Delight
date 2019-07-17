#region Using Statements
using System;
#endregion

namespace Delight
{
    /// <summary>
    /// Enum indicating how a gridsplitter should split a grid.
    /// </summary>
    public enum SplitMode
    {
        /// <summary>
        /// Split rows so they can be resized.
        /// </summary>
        Rows = 1,

        /// <summary>
        /// Split columns so they can be resized. 
        /// </summary>
        Columns = 2,

        /// <summary>
        /// Split both rows and columns so they can be resized.
        /// </summary>
        RowsAndColumns = 3
    }
}
