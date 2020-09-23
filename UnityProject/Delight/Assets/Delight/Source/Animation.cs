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
    /// Controls a collection of animators.
    /// </summary>
    public class Animation : List<Animator>
    {
        #region Methods

        /// <summary>
        /// Starts the animation.
        /// </summary>
        public void StartAnimation()
        {
            for (int i = 0; i < Count; ++i)
            {
                this[i].StartAnimation();
            }
        }

        /// <summary>
        /// Stops the animation.
        /// </summary>
        public void StopAnimation()
        {
            for (int i = 0; i < Count; ++i)
            {
                this[i].StopAnimation();
            }
        }

        /// <summary>
        /// Resets and stops animation.
        /// </summary>
        public void ResetAndStopAnimation()
        {
            for (int i = 0; i < Count; ++i)
            {
                this[i].ResetAndStopAnimation();
            }
        }

        /// <summary>
        /// Reverses the animation. Resumes the animation if paused.
        /// </summary>
        public void ReverseAnimation()
        {
            for (int i = 0; i < Count; ++i)
            {
                this[i].ReverseAnimation();
            }
        }

        /// <summary>
        /// Pauses animation.
        /// </summary>
        public void PauseAnimation()
        {
            for (int i = 0; i < Count; ++i)
            {
                this[i].PauseAnimation();
            }
        }

        /// <summary>
        /// Resumes paused animation.
        /// </summary>
        public void ResumeAnimation()
        {
            for (int i = 0; i < Count; ++i)
            {
                this[i].ResumeAnimation();
            }
        }

        /// <summary>
        /// Resets the animation to its initial state (doesn't stop it).
        /// </summary>
        public void ResetAnimation()
        {
            for (int i = 0; i < Count; ++i)
            {
                this[i].ResetAnimation();
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets a boolean indicating whether this animation is active.
        /// </summary>
        public virtual bool IsRunning
        {
            get
            {
                return this.Any(x => x.IsRunning);
            }
        }

        /// <summary>
        /// Gets a boolean indicating whether this animation is reversing.
        /// </summary>
        public virtual bool IsReversing
        {
            get
            {
                return this.Any(x => x.IsReversing);
            }
        }

        /// <summary>
        /// Gets a boolean indicating whether this animation is completed.
        /// </summary>
        public virtual bool IsCompleted
        {
            get
            {
                return this.All(x => x.IsCompleted);
            }
            set
            {
                this.ForEach(x => x.IsCompleted = value);
            }
        }

        /// <summary>
        /// Gets a boolean indicating whether this animation is paused.
        /// </summary>
        public virtual bool IsPaused
        {
            get
            {
                return this.All(x => x.IsPaused);
            }
        }

        #endregion
    }
}
