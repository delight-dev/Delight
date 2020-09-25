#region Using Statements
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;
#endregion

namespace Delight
{
    /// <summary>
    /// Controls a collection of animators activated when transitioning between the specified states.
    /// </summary>
    public class StateAnimation : Animation
    {
        #region Properties

        public string FromState;
        public string ToState;
        public bool FromAny;
        public bool ToAny;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public StateAnimation(string fromState, string toState)
        {
            FromState = fromState;
            ToState = toState;
            FromAny = fromState.IEquals(DependencyObject.AnyStateName);
            ToAny = toState.IEquals(DependencyObject.AnyStateName);
        }

        #endregion

        #region Methods
        #endregion

        #region Properties
        #endregion
    }
}
