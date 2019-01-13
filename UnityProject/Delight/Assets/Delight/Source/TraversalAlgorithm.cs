#region Using Statements
using System;
#endregion

namespace Delight
{
    /// <summary>
    /// Enum indicating what traversal algorithm to use.
    /// </summary>
    public enum TraversalAlgorithm
    {
        /// <summary>
        /// Default traversal algorithm (depth first).
        /// </summary>
        Default = 0,

        /// <summary>
        /// Depth first traversal algorithm.
        /// </summary>
        DepthFirst = 0,

        /// <summary>
        /// Breadth first traversal algorithm.
        /// </summary>
        BreadthFirst = 1,

        /// <summary>
        /// Reverse depth first traversal algorithm.
        /// </summary>
        ReverseDepthFirst = 2,

        /// <summary>
        /// Reverse breadth first traversal algorithm.
        /// </summary>
        ReverseBreadthFirst= 3
    }
}
