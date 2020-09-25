#region Using Statements
using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
#endregion

namespace Delight
{
    /// <summary>
    /// Animates the values of a specific property. 
    /// </summary>
    public class Animator<T> : Animator
    {
        #region Fields

        public EasingFunctionDelegate EasingFunction;
        public Func<T, T, float, T> ValueInterpolator;
        public Action<T> ValueSetter;
        public Func<T> ValueGetter;

        public Func<T> FromGetter;
        public Func<T> ToGetter;
        protected T From;
        protected T To;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public Animator(View target)
        {
            Target = new WeakReference<View>(target);
            EasingFunction = EasingFunctions.Linear;
        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public Animator(View target, float duration, float startOffset, bool autoReset, bool autoReverse, float reverseSpeed, bool notifyPropertyChangedWhileAnimating,
            EasingFunctionDelegate easingFunction, Func<T, T, float, T> valueInterpolator, Action<T> valueSetter, Func<T> fromGetter, Func<T> toGetter,
            Action notifyPropertyChanged, DependencyProperty property)
        {
            Duration = duration;
            StartOffset = startOffset;
            AutoReset = autoReset;
            AutoReverse = autoReverse;
            ReverseSpeed = reverseSpeed;
            NotifyPropertyChangedWhileAnimating = notifyPropertyChangedWhileAnimating;
            ValueInterpolator = valueInterpolator;
            ValueSetter = valueSetter;
            FromGetter = fromGetter;
            ToGetter = toGetter;
            NotifyPropertyChanged = notifyPropertyChanged;
            Property = property;

            Target = new WeakReference<View>(target);
            EasingFunction = easingFunction;
        }


        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public Animator(View target, float duration, float startOffset, bool autoReset, bool autoReverse, float reverseSpeed, bool notifyPropertyChangedWhileAnimating,
            EasingFunctionDelegate easingFunction, Func<T, T, float, T> valueInterpolator, Action<T> valueSetter, Func<T> valueGetter,
            Action notifyPropertyChanged, DependencyProperty property, string fromState, string toState)
        {
            Duration = duration;
            StartOffset = startOffset;
            AutoReset = autoReset;
            AutoReverse = autoReverse;
            ReverseSpeed = reverseSpeed;
            NotifyPropertyChangedWhileAnimating = notifyPropertyChangedWhileAnimating;
            ValueInterpolator = valueInterpolator;
            ValueSetter = valueSetter;
            ValueGetter = valueGetter;
            NotifyPropertyChanged = notifyPropertyChanged;
            Property = property;
            FromState = fromState;
            ToState = toState;

            Target = new WeakReference<View>(target);
            EasingFunction = easingFunction;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Updates the animation each frame. 
        /// </summary>
        public override void Update(float deltaTime)
        {
            bool targetIsAlive = Target.TryGetTarget(out var target);
            if (!targetIsAlive || !target.IsLoaded)
            {
                if (!IsCompleted)
                {
                    CompleteAnimation();
                }
                return;
            }

            if (!IsRunning || IsCompleted)
                return;

            _elapsedTime = IsReversing ? _elapsedTime - deltaTime * ReverseSpeed :
                _elapsedTime + deltaTime;

            // start animation once passed startOffset
            if (!IsReversing && _elapsedTime < StartOffset)
                return;

            // clamp elapsed time to max duration
            float t = IsReversing ? _elapsedTime.Clamp(0, Duration) : (_elapsedTime - StartOffset).Clamp(0, Duration);
            float weight = Duration > 0 ? EasingFunction(t / Duration) : (IsReversing ? 0f : 1f);

            T interpolatedValue = default(T);
            interpolatedValue = ValueInterpolator.Invoke(From, To, weight);

            Property.DisableNotifyPropertyChanged = !NotifyPropertyChangedWhileAnimating;
            ValueSetter(interpolatedValue);
            Property.DisableNotifyPropertyChanged = false;

            // is animation done?
            if ((IsReversing && t <= 0) || (!IsReversing && t >= Duration))
            {
                // yes. should animation auto-reverse?
                if (!IsReversing && AutoReverse)
                {
                    // yes. reverse the animation
                    IsReversing = true;

                    // call animation reversed event
                    OnReversed();
                    return;
                }

                // animation is complete
                CompleteAnimation();
            }

            return;
        }

        /// <summary>
        /// Resets the value. 
        /// </summary>
        public override void ResetValue()
        {
            bool targetIsAlive = Target.TryGetTarget(out var target);
            if (!targetIsAlive || !target.IsLoaded)
                return;

            ValueSetter(From);
        }

        /// <summary>
        /// Starts animation.
        /// </summary>
        public override void StartAnimation()
        {
            base.StartAnimation();

            Property.State = FromState;
            From = ValueGetter();
            Property.State = ToState;
            To = ValueGetter();
            Property.State = null;
        }

        #endregion
    }

    /// <summary>
    /// Base class for animators.
    /// </summary>
    public class Animator
    {
        #region Fields

        public delegate float EasingFunctionDelegate(float t);

        public string FromState;
        public string ToState;
        public float Duration; // duration in seconds
        public float StartOffset;
        public bool AutoReset;
        public bool AutoReverse;
        public float ReverseSpeed;
        public bool NotifyPropertyChangedWhileAnimating;
        public Action NotifyPropertyChanged;
        public WeakReference<View> Target;
        public DependencyProperty Property;

        // animation state
        public bool IsRunning { get; protected set; }
        public bool IsReversing { get; protected set; }
        public bool IsCompleted { get; set; }
        public bool IsPaused { get; protected set; }

        public delegate void AnimationEventHandler(Animator animator);
        public event AnimationEventHandler Started = delegate { };
        public event AnimationEventHandler Completed = delegate { };
        public event AnimationEventHandler Paused = delegate { };
        public event AnimationEventHandler Reversed = delegate { };
        public event AnimationEventHandler Stopped = delegate { };
        public event AnimationEventHandler Resumed = delegate { };

        protected float _elapsedTime;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public Animator()
        {
            ReverseSpeed = 1.0f;

            // default animation state
            IsRunning = false;
            IsReversing = false;
            IsCompleted = true;
            IsPaused = true;
            NotifyPropertyChangedWhileAnimating = false;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Updates the animator. Called once per frame.
        /// </summary>
        public virtual void Update(float deltaTime)
        {
        }

        /// <summary>
        /// Starts the animation.
        /// </summary>
        public virtual void StartAnimation()
        {
            // do nothing if animation is already active
            if (IsRunning)
            {
                return;
            }

            ResetAnimation();
            IsRunning = true;

            // call start event 
            OnStarted();
        }

        /// <summary>
        /// Called when the animation is completed.
        /// </summary>
        public void CompleteAnimation()
        {
            if (AutoReset)
            {
                ResetAndStopAnimation();
            }
            else
            {
                PauseAnimation();
            }

            IsCompleted = true;
            if (!NotifyPropertyChangedWhileAnimating && NotifyPropertyChanged != null && Target.TryGetTarget(out var target))
            {
                // notify property changed
                NotifyPropertyChanged();
            }

            // call animation completed event
            OnCompleted();
        }

        /// <summary>
        /// Stops the animation.
        /// </summary>
        public void StopAnimation()
        {
            IsRunning = false;

            // call animation completed event
            OnStopped();
        }

        /// <summary>
        /// Resets and stops animation.
        /// </summary>
        public void ResetAndStopAnimation()
        {
            ResetAnimation();
            StopAnimation();
        }

        /// <summary>
        /// Reverses the animation. Resumes the animation if paused.
        /// </summary>
        public void ReverseAnimation()
        {
            // reverse animation if active
            if (IsRunning)
            {
                IsReversing = true;
            }
            else if (IsPaused)
            {
                IsCompleted = false;
                IsReversing = true;
                ResumeAnimation();
            }

            // call animation reversed event
            OnReversed();
        }

        /// <summary>
        /// Pauses animation.
        /// </summary>
        public void PauseAnimation()
        {
            IsRunning = false;
            IsPaused = true;

            // call animation paused event
            OnPaused();
        }

        /// <summary>
        /// Resumes paused animation.
        /// </summary>
        public void ResumeAnimation()
        {
            if (IsPaused)
            {
                IsRunning = true;
                IsPaused = false;

                // call animation completed event
                OnResumed();
            }
        }

        /// <summary>
        /// Resets the animation to its initial state (doesn't stop it).
        /// </summary>
        public void ResetAnimation()
        {
            // resets the animation (but doesn't stop it)                        
            _elapsedTime = 0;
            IsReversing = false;
            IsPaused = false;
            IsCompleted = false;
            ResetValue();
        }

        /// <summary>
        /// Resets the value. 
        /// </summary>
        public virtual void ResetValue()
        {
        }

        /// <summary>
        /// Invokes Started event.
        /// </summary>
        protected void OnStarted()
        {
            Started.Invoke(this);
        }

        /// <summary>
        /// Invokes Completed event.
        /// </summary>
        protected void OnCompleted()
        {
            Completed.Invoke(this);
        }

        /// <summary>
        /// Invokes Paused event.
        /// </summary>
        protected void OnPaused()
        {
            Paused.Invoke(this);
        }

        /// <summary>
        /// Invokes Reversed event.
        /// </summary>
        protected void OnReversed()
        {
            Reversed.Invoke(this);
        }

        /// <summary>
        /// Invokes Stopped event.
        /// </summary>
        protected void OnStopped()
        {
            Stopped.Invoke(this);
        }

        /// <summary>
        /// Invokes Resumed event.
        /// </summary>
        protected void OnResumed()
        {
            Resumed.Invoke(this);
        }

        #endregion
    }
}
