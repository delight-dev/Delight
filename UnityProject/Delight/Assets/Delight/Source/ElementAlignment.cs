#region Using Statements
using System;
#endregion

namespace Delight
{
    /// <summary>
    /// Enum indicating horizontal and vertical alignment of an element.
    /// </summary>
    [Flags]
    public enum ElementAlignment
    {
        /// <summary>
        /// Element centered horizontally and vertically.
        /// </summary>
        Center = 0,

        /// <summary>
        /// Element aligned to the left horizontally and centered vertically.
        /// </summary>
        Left = 1,

        /// <summary>
        /// Element aligned to the top vertically and centered horizontally.
        /// </summary>
        Top = 2,

        /// <summary>
        /// Element aligned to the right horizontally and centered vertically.
        /// </summary>
        Right = 4,

        /// <summary>
        /// Element aligned to the bottom vertically and centered horizontally.
        /// </summary>       
        Bottom = 8,

        /// <summary>
        /// Element aligned to the top vertically and to the left horizontally.
        /// </summary>
        TopLeft = Top | Left,

        /// <summary>
        /// Element aligned to the top vertically and to the right horizontally.
        /// </summary>
        TopRight = Top | Right,

        /// <summary>
        /// Element aligned to the bottom vertically and to the left horizontally.
        /// </summary>
        BottomLeft = Bottom | Left,

        /// <summary>
        /// Alement aligned to the bottom vertically and to the right horizontally.
        /// </summary>
        BottomRight = Bottom | Right
    }
}
