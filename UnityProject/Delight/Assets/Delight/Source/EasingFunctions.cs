#region Using Statements
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
#endregion

namespace Delight
{
    /// <summary>
    /// Easing functions derived from AHEasing, a library of easing functions. Credit goes to warrenm author of AHEasing.
    /// </summary>
    public static class EasingFunctions
    {
        #region Methods

        /// <summary>
        /// Gets easing function.
        /// </summary>
        public static Animator.EasingFunctionDelegate Get(EasingFunctionType type)
        {
            switch (type)
            {
                case EasingFunctionType.Linear:
                    return Linear;
                case EasingFunctionType.QuadraticEaseIn:
                    return QuadraticEaseIn;
                case EasingFunctionType.QuadraticEaseOut:
                    return QuadraticEaseOut;
                case EasingFunctionType.QuadraticEaseInOut:
                    return QuadraticEaseInOut;
                case EasingFunctionType.CubicEaseIn:
                    return CubicEaseIn;
                case EasingFunctionType.CubicEaseOut:
                    return CubicEaseOut;
                case EasingFunctionType.CubicEaseInOut:
                    return CubicEaseInOut;
                case EasingFunctionType.QuarticEaseIn:
                    return QuarticEaseIn;
                case EasingFunctionType.QuarticEaseOut:
                    return QuarticEaseOut;
                case EasingFunctionType.QuarticEaseInOut:
                    return QuarticEaseInOut;
                case EasingFunctionType.QuinticEaseIn:
                    return QuinticEaseIn;
                case EasingFunctionType.QuinticEaseOut:
                    return QuinticEaseOut;
                case EasingFunctionType.QuinticEaseInOut:
                    return QuinticEaseInOut;
                case EasingFunctionType.SineEaseIn:
                    return SineEaseIn;
                case EasingFunctionType.SineEaseOut:
                    return SineEaseOut;
                case EasingFunctionType.SineEaseInOut:
                    return SineEaseInOut;
                case EasingFunctionType.CircularEaseIn:
                    return CircularEaseIn;
                case EasingFunctionType.CircularEaseOut:
                    return CircularEaseOut;
                case EasingFunctionType.CircularEaseInOut:
                    return CircularEaseInOut;
                case EasingFunctionType.ExponentialEaseIn:
                    return ExponentialEaseIn;
                case EasingFunctionType.ExponentialEaseOut:
                    return ExponentialEaseOut;
                case EasingFunctionType.ExponentialEaseInOut:
                    return ExponentialEaseInOut;
                case EasingFunctionType.ElasticEaseIn:
                    return ElasticEaseIn;
                case EasingFunctionType.ElasticEaseOut:
                    return ElasticEaseOut;
                case EasingFunctionType.ElasticEaseInOut:
                    return ElasticEaseInOut;
                case EasingFunctionType.BounceEaseIn:
                    return BounceEaseIn;
                case EasingFunctionType.BounceEaseOut:
                    return BounceEaseOut;
                case EasingFunctionType.BounceEaseInOut:
                    return BounceEaseInOut;
                case EasingFunctionType.BackEaseIn:
                    return BackEaseIn;
                case EasingFunctionType.BackEaseOut:
                    return BackEaseOut;
                case EasingFunctionType.BackEaseInOut:
                    return BackEaseInOut;
                default:
                    return Linear;
            }
        }

        /// <summary>
        /// Gets easing function.
        /// </summary>
        public static Animator.EasingFunctionDelegate Get(string name)
        {
            if (Enum.TryParse<EasingFunctionType>(name, true, out var type))
            {
                return Get(type);
            }
            else
            {
                return Linear;
            }
        }

        /// <summary>
        /// Easing modeled after the line y = x
        /// </summary>
        public static float Linear(float p)
        {
            return p;
        }

        /// <summary>
        /// Easing modeled after the parabola y = x^2
        /// </summary>
        public static float QuadraticEaseIn(float p)
        {
            return p * p;
        }

        /// <summary>
        /// Easing modeled after the parabola y = -x^2 + 2x
        /// </summary>
        public static float QuadraticEaseOut(float p)
        {
            return -(p * (p - 2));
        }

        /// <summary>
        /// Easing modeled after the piecewise quadratic
        /// y = (1/2)((2x)^2)             ; [0, 0.5)
        /// y = -(1/2)((2x-1)*(2x-3) - 1) ; [0.5, 1]
        /// </summary>
        public static float QuadraticEaseInOut(float p)
        {
            if (p < 0.5f)
            {
                return 2 * p * p;
            }
            else
            {
                return (-2 * p * p) + (4 * p) - 1;
            }
        }

        /// <summary>
        /// Easing modeled after the cubic y = x^3
        /// </summary>
        public static float CubicEaseIn(float p)
        {
            return p * p * p;
        }

        /// <summary>
        /// Easing modeled after the cubic y = (x - 1)^3 + 1
        /// </summary>
        public static float CubicEaseOut(float p)
        {
            float f = (p - 1);
            return f * f * f + 1;
        }

        /// <summary>
        /// Easing modeled after the piecewise cubic
        /// y = (1/2)((2x)^3)       ; [0, 0.5)
        /// y = (1/2)((2x-2)^3 + 2) ; [0.5, 1]
        /// </summary>
        public static float CubicEaseInOut(float p)
        {
            if (p < 0.5f)
            {
                return 4 * p * p * p;
            }
            else
            {
                float f = ((2 * p) - 2);
                return 0.5f * f * f * f + 1;
            }
        }

        /// <summary>
        /// Easing modeled after the quartic x^4
        /// </summary>
        public static float QuarticEaseIn(float p)
        {
            return p * p * p * p;
        }

        /// <summary>
        /// Easing modeled after the quartic y = 1 - (x - 1)^4
        /// </summary>
        public static float QuarticEaseOut(float p)
        {
            float f = (p - 1);
            return f * f * f * (1 - p) + 1;
        }

        /// <summary>
        /// Easing modeled after the piecewise quartic
        /// y = (1/2)((2x)^4)        ; [0, 0.5)
        /// y = -(1/2)((2x-2)^4 - 2) ; [0.5, 1]
        /// </summary>
        public static float QuarticEaseInOut(float p)
        {
            if (p < 0.5f)
            {
                return 8 * p * p * p * p;
            }
            else
            {
                float f = (p - 1);
                return -8 * f * f * f * f + 1;
            }
        }

        /// <summary>
        /// Easing modeled after the quintic y = x^5
        /// </summary>
        public static float QuinticEaseIn(float p)
        {
            return p * p * p * p * p;
        }

        /// <summary>
        /// Easing modeled after the quintic y = (x - 1)^5 + 1
        /// </summary>
        public static float QuinticEaseOut(float p)
        {
            float f = (p - 1);
            return f * f * f * f * f + 1;
        }

        /// <summary>
        /// Easing modeled after the piecewise quintic
        /// y = (1/2)((2x)^5)       ; [0, 0.5)
        /// y = (1/2)((2x-2)^5 + 2) ; [0.5, 1]
        /// </summary>
        public static float QuinticEaseInOut(float p)
        {
            if (p < 0.5f)
            {
                return 16 * p * p * p * p * p;
            }
            else
            {
                float f = ((2 * p) - 2);
                return 0.5f * f * f * f * f * f + 1;
            }
        }

        /// <summary>
        /// Easing modeled after quarter-cycle of sine wave
        /// </summary>
        public static float SineEaseIn(float p)
        {
            return Mathf.Sin((p - 1) * (Mathf.PI / 2f)) + 1;
        }

        /// <summary>
        /// Easing modeled after quarter-cycle of sine wave (different phase)
        /// </summary>
        public static float SineEaseOut(float p)
        {
            return Mathf.Sin(p * (Mathf.PI / 2f));
        }

        /// <summary>
        /// Easing modeled after half sine wave
        /// </summary>
        public static float SineEaseInOut(float p)
        {
            return 0.5f * (1 - Mathf.Cos(p * Mathf.PI));
        }

        /// <summary>
        /// Easing modeled after shifted quadrant IV of unit circle
        /// </summary>
        public static float CircularEaseIn(float p)
        {
            return 1 - Mathf.Sqrt(1 - (p * p));
        }

        /// <summary>
        /// Easing modeled after shifted quadrant II of unit circle
        /// </summary>
        public static float CircularEaseOut(float p)
        {
            return Mathf.Sqrt((2 - p) * p);
        }

        /// <summary>
        /// Easing modeled after the piecewise circular function
        /// y = (1/2)(1 - Mathf.Sqrt(1 - 4x^2))           ; [0, 0.5)
        /// y = (1/2)(Mathf.Sqrt(-(2x - 3)*(2x - 1)) + 1) ; [0.5, 1]
        /// </summary>
        public static float CircularEaseInOut(float p)
        {
            if (p < 0.5f)
            {
                return 0.5f * (1 - Mathf.Sqrt(1 - 4 * (p * p)));
            }
            else
            {
                return 0.5f * (Mathf.Sqrt(-((2 * p) - 3) * ((2 * p) - 1)) + 1);
            }
        }

        /// <summary>
        /// Easing modeled after the exponential function y = 2^(10(x - 1))
        /// </summary>
        public static float ExponentialEaseIn(float p)
        {
            return (p == 0.0f) ? p : Mathf.Pow(2, 10 * (p - 1));
        }

        /// <summary>
        /// Easing modeled after the exponential function y = -2^(-10x) + 1
        /// </summary>
        public static float ExponentialEaseOut(float p)
        {
            return (p == 1.0f) ? p : 1 - Mathf.Pow(2, -10 * p);
        }

        /// <summary>
        /// Easing modeled after the piecewise exponential
        /// y = (1/2)2^(10(2x - 1))         ; [0,0.5)
        /// y = -(1/2)*2^(-10(2x - 1))) + 1 ; [0.5,1]
        /// </summary>
        public static float ExponentialEaseInOut(float p)
        {
            if (p == 0.0f || p == 1.0f) return p;

            if (p < 0.5f)
            {
                return 0.5f * Mathf.Pow(2, (20 * p) - 10);
            }
            else
            {
                return -0.5f * Mathf.Pow(2, (-20 * p) + 10) + 1;
            }
        }

        /// <summary>
        /// Easing modeled after the damped sine wave y = Mathf.Sin(13pi/2*x)*Mathf.Pow(2, 10 * (x - 1))
        /// </summary>
        public static float ElasticEaseIn(float p)
        {
            return Mathf.Sin(13 * (Mathf.PI / 2f) * p) * Mathf.Pow(2, 10 * (p - 1));
        }

        /// <summary>
        /// Easing modeled after the damped sine wave y = Mathf.Sin(-13pi/2*(x + 1))*Mathf.Pow(2, -10x) + 1
        /// </summary>
        public static float ElasticEaseOut(float p)
        {
            return Mathf.Sin(-13 * (Mathf.PI / 2f) * (p + 1)) * Mathf.Pow(2, -10 * p) + 1;
        }

        /// <summary>
        /// Easing modeled after the piecewise exponentially-damped sine wave:
        /// y = (1/2)*Mathf.Sin(13pi/2*(2*x))*Mathf.Pow(2, 10 * ((2*x) - 1))      ; [0,0.5)
        /// y = (1/2)*(Mathf.Sin(-13pi/2*((2x-1)+1))*Mathf.Pow(2,-10(2*x-1)) + 2) ; [0.5, 1]
        /// </summary>
        public static float ElasticEaseInOut(float p)
        {
            if (p < 0.5f)
            {
                return 0.5f * Mathf.Sin(13 * (Mathf.PI / 2f) * (2 * p)) * Mathf.Pow(2, 10 * ((2 * p) - 1));
            }
            else
            {
                return 0.5f * (Mathf.Sin(-13 * (Mathf.PI / 2f) * ((2 * p - 1) + 1)) * Mathf.Pow(2, -10 * (2 * p - 1)) + 2);
            }
        }

        /// <summary>
        /// Easing modeled after the overshooting cubic y = x^3-x*Mathf.Sin(x*pi)
        /// </summary>
        public static float BackEaseIn(float p)
        {
            return p * p * p - p * Mathf.Sin(p * Mathf.PI);
        }

        /// <summary>
        /// Easing modeled after overshooting cubic y = 1-((1-x)^3-(1-x)*Mathf.Sin((1-x)*pi))
        /// </summary>
        public static float BackEaseOut(float p)
        {
            float f = (1 - p);
            return 1 - (f * f * f - f * Mathf.Sin(f * Mathf.PI));
        }

        /// <summary>
        /// Easing modeled after the piecewise overshooting cubic function:
        /// y = (1/2)*((2x)^3-(2x)*Mathf.Sin(2*x*pi))           ; [0, 0.5)
        /// y = (1/2)*(1-((1-x)^3-(1-x)*Mathf.Sin((1-x)*pi))+1) ; [0.5, 1]
        /// </summary>
        public static float BackEaseInOut(float p)
        {
            if (p < 0.5f)
            {
                float f = 2 * p;
                return 0.5f * (f * f * f - f * Mathf.Sin(f * Mathf.PI));
            }
            else
            {
                float f = (1 - (2 * p - 1));
                return 0.5f * (1 - (f * f * f - f * Mathf.Sin(f * Mathf.PI))) + 0.5f;
            }
        }

        /// <summary>
        /// Easing modeled after the piecewise overshooting cubic function.
        /// </summary>
        public static float BounceEaseIn(float p)
        {
            return 1 - BounceEaseOut(1 - p);
        }

        /// <summary>
        /// Easing modeled after the piecewise overshooting cubic function.
        /// </summary>
        public static float BounceEaseOut(float p)
        {
            if (p < 4 / 11.0f)
            {
                return (121 * p * p) / 16.0f;
            }
            else if (p < 8 / 11.0f)
            {
                return (363 / 40.0f * p * p) - (99 / 10.0f * p) + 17 / 5.0f;
            }
            else if (p < 9 / 10.0f)
            {
                return (4356 / 361.0f * p * p) - (35442 / 1805.0f * p) + 16061 / 1805.0f;
            }
            else
            {
                return (54 / 5.0f * p * p) - (513 / 25.0f * p) + 268 / 25.0f;
            }
        }

        /// <summary>
        /// Easing modeled after the piecewise overshooting cubic function.
        /// </summary>
        public static float BounceEaseInOut(float p)
        {
            if (p < 0.5f)
            {
                return 0.5f * BounceEaseIn(p * 2);
            }
            else
            {
                return 0.5f * BounceEaseOut(p * 2 - 1) + 0.5f;
            }
        }

        #endregion
    }
}
