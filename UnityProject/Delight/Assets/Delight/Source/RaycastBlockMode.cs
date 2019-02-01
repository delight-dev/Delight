#region Using Statements
using System;
#endregion

namespace Delight
{
    /// <summary>
    /// Type of raycast blocking should be used.
    /// </summary>
    public enum RaycastBlockMode
    {
        /// <summary>
        /// Raycast is blocked if view is displayed and not transparent.
        /// </summary>
        Default = 0,

        /// <summary>
        /// Raycast is always blocked.
        /// </summary>
        Always = 1,

        /// <summary>
        /// Raycast is never blocked.
        /// </summary>
        Never = 2
    }
}
