#region Using Statements
using System;
#endregion

namespace Delight
{
    /// <summary>
    /// Enum indicating navigation button type.
    /// </summary>
    public enum NavigationType
    {
        /// <summary>
        /// Next/Previous navigation.
        /// </summary>
        Both = 0,

        /// <summary>
        /// Next navigation.
        /// </summary>
        Next = 1,

        /// <summary>
        /// Previous navigation.
        /// </summary>
        Previous = 2,

        /// <summary>
        /// Page navigation.
        /// </summary>
        Page = 3
    }
}
