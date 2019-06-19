#region Using Statements
using System;
#endregion

namespace Delight
{
    /// <summary>
    /// Enum indicating view load mode.
    /// </summary>
    [Flags]
    public enum LoadMode
    {
        /// <summary>
        /// View is loaded automatically when parent is loaded. 
        /// </summary>
        Automatic = 0,

        /// <summary>
        /// View is loaded when explicitly requested to load by calling its Load method. 
        /// </summary>
        Manual = 1,
        OnDemand = 1,

        /// <summary>
        /// Makes view hidden while view and referenced assets are loading.
        /// </summary>
        HiddenWhileLoading = 2,
        ManualHiddenWhileLoading = 3
    }
}
