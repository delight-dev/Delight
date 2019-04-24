#region Using Statements
using System;
#endregion

namespace Delight
{
    /// <summary>
    /// Enum indicating view switcher mode.
    /// </summary>
    public enum SwitchMode
    {
        /// <summary>
        /// Views start out preloaded and enabled/disabled when they are switched to/from
        /// </summary>
        Enable = 0,

        /// <summary>
        /// Views are loaded/unloaded when they are switched to/from.
        /// </summary>
        Load = 1,

        /// <summary>
        /// Views are loaded first time when switched to and then enabled/disabled when switched to/from.
        /// </summary>
        LoadOnce = 2
    }
}
