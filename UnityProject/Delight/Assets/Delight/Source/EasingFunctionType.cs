#region Using Statements
using System;
#endregion

namespace Delight
{
    /// <summary>
    /// Specifies what kind of easing function should be used when values are interpolated.
    /// </summary>
    public enum EasingFunctionType
    {
        /// <summary>
        /// Linear easing function.
        /// </summary>
        Linear = 0,

        /// <summary>
        /// Quadratic ease in function.
        /// </summary>
        QuadraticEaseIn = 1,

        /// <summary>
        /// Quadratic ease out function.
        /// </summary>
        QuadraticEaseOut = 2,

        /// <summary>
        /// Quadratic ease in and out function.
        /// </summary>
        QuadraticEaseInOut = 3,

        /// <summary>
        /// Cubic ease in function.
        /// </summary>
        CubicEaseIn = 4,

        /// <summary>
        /// Cubic ease out function.
        /// </summary>
        CubicEaseOut = 5,

        /// <summary>
        /// Cubic ease in and out function.
        /// </summary>
        CubicEaseInOut = 6,

        /// <summary>
        /// Quartic ease in function.
        /// </summary>
        QuarticEaseIn = 7,

        /// <summary>
        /// Quartic ease out function.
        /// </summary>
        QuarticEaseOut = 8,

        /// <summary>
        /// Quartic ease in and out function.
        /// </summary>
        QuarticEaseInOut = 9,

        /// <summary>
        /// Quintic ease in function.
        /// </summary>
        QuinticEaseIn = 10,

        /// <summary>
        /// Quintic ease out function.
        /// </summary>
        QuinticEaseOut = 11,

        /// <summary>
        /// Quintic ease in and out function.
        /// </summary>
        QuinticEaseInOut = 12,

        /// <summary>
        /// Sine ease in function.
        /// </summary>
        SineEaseIn = 13,

        /// <summary>
        /// Sine ease out function.
        /// </summary>
        SineEaseOut = 14,

        /// <summary>
        /// Sine ease in and out function.
        /// </summary>
        SineEaseInOut = 15,

        /// <summary>
        /// Circular ease in function.
        /// </summary>
        CircularEaseIn = 16,

        /// <summary>
        /// Circular ease out function.
        /// </summary>
        CircularEaseOut = 17,

        /// <summary>
        /// Circular ease in and out function.
        /// </summary>
        CircularEaseInOut = 18,

        /// <summary>
        /// Expontential ease in function.
        /// </summary>
        ExponentialEaseIn = 19,

        /// <summary>
        /// Exponential ease out function.
        /// </summary>
        ExponentialEaseOut = 20,

        /// <summary>
        /// Exponential ease in and out function.
        /// </summary>
        ExponentialEaseInOut = 21,

        /// <summary>
        /// Elastic ease in function.
        /// </summary>
        ElasticEaseIn = 22,

        /// <summary>
        /// Elastic ease out function.
        /// </summary>
        ElasticEaseOut = 23,

        /// <summary>
        /// Elastic ease in and out function.
        /// </summary>         
        ElasticEaseInOut = 24,

        /// <summary>
        /// Bounce ease in function.
        /// </summary>
        BounceEaseIn = 25,

        /// <summary>
        /// Bounce ease out function.
        /// </summary>
        BounceEaseOut = 26,

        /// <summary>
        /// Bounce ease in and out function.
        /// </summary>
        BounceEaseInOut = 27,

        /// <summary>
        /// Back ease in function.
        /// </summary>
        BackEaseIn = 28,

        /// <summary>
        /// Back ease out function.
        /// </summary>
        BackEaseOut = 29,

        /// <summary>
        /// Back ease in and out function.
        /// </summary>
        BackEaseInOut = 30
    }
}