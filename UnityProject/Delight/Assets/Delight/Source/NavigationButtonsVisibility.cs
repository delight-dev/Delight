#region Using Statements
using System;
#endregion

namespace Delight
{
    /// <summary>
    /// Enum indicating the visibility of navigation buttons.
    /// </summary>
    public enum NavigationButtonsVisibility
    {
        /// <summary>
        /// No navigation buttons.
        /// </summary>
        None = 0,

        /// <summary>
        /// No navigation buttons.
        /// </summary>
        False = 0,

        /// <summary>
        /// Next/Previous navigation.
        /// </summary>
        True = 2,

        /// <summary>
        /// Both next/previous and page navigation.
        /// </summary>
        All = 1,

        /// <summary>
        /// Next/Previous navigation.
        /// </summary>
        NextPrevious = 2,

        /// <summary>
        /// Page navigation.
        /// </summary>
        Page = 3
    }
}
