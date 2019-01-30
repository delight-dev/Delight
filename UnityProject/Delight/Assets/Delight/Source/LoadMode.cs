#region Using Statements
using System;
#endregion

namespace Delight
{
    /// <summary>
    /// Enum indicating view load mode.
    /// </summary>
    public enum LoadMode
    {
        /// <summary>
        /// View is loaded automatically when parent is loaded. 
        /// </summary>
        Automatic = 0,

        /// <summary>
        /// View is loaded when explicitly requested to load by calling its Load method. 
        /// </summary>
        OnDemand = 1
    }
}
