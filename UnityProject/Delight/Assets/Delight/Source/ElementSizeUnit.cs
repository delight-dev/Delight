#region Using Statements
using System;
#endregion

namespace Delight
{
    /// <summary>
    /// Defines element size unit as pixels or percentage.
    /// </summary>
    public enum ElementSizeUnit
    {
        /// <summary>
        /// Element size specified in pixels.
        /// </summary>
        Pixels = 0,

        /// <summary>
        /// Element size specified in percents.
        /// </summary>
        Percents = 1,

        /// <summary>
        /// Element size specified in proportion to other sizes.
        /// </summary>
        Proportional = 2
    }
}
