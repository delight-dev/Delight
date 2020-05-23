#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using UnityEngine;
#endregion

namespace Delight
{
    /// <summary>
    /// Represents a layout root canvas under which all UI views must reside.
    /// </summary>
    public partial class LayoutRoot
    {
        #region Fields

        private HashSet<ChangeHandler> _registeredChangeHandlers = new HashSet<ChangeHandler>();
        private List<ChangeHandler> _changeHandlers = new List<ChangeHandler>();
        private HashSet<Animator> _animators = new HashSet<Animator>();
        private List<Animator> _completedAnimators = new List<Animator>();

        #endregion

        #region Methods

        /// <summary>
        /// Updates the view. Called once each frame.
        /// </summary>
        public override void Update()
        {
            base.Update();

            if (_animators.Count > 0)
            {
                // update animations
                float deltaTime = Time.deltaTime;
                foreach (var animator in _animators)
                {
                    animator.Update(deltaTime);
                    if (animator.IsCompleted)
                    {
                        _completedAnimators.Add(animator);
                    }
                }

                if (_completedAnimators.Any())
                {
                    foreach (var animator in _completedAnimators)
                    {
                        _animators.Remove(animator);
                    }
                    _completedAnimators.Clear();
                }
            }
        }

        /// <summary>
        /// Updates the view. Called once each frame. 
        /// </summary>
        public override void LateUpdate()
        {
            base.LateUpdate();

            // call triggered property change handlers
            while (_registeredChangeHandlers.Count > 0)
            {
                _changeHandlers.AddRange(_registeredChangeHandlers);
                _registeredChangeHandlers.Clear();
                for (int i = 0; i < _changeHandlers.Count; ++i)
                {
                    _changeHandlers[i]?.Invoke();
                }
                _changeHandlers.Clear();
            }
        }

        /// <summary>
        /// Registers a change handler to be triggered on next late update.
        /// </summary>
        public void RegisterChangeHandler(ChangeHandler changeHandler)
        {
            _registeredChangeHandlers.Add(changeHandler);
        }

        /// <summary>
        /// Registers an animator to be updated each frame.
        /// </summary>
        public void RegisterAnimator(Animator animator)
        {
            _animators.Add(animator);
        }

        /// <summary>
        /// Unregisters an animator to be updated each frame.
        /// </summary>
        public void UnregisterAnimator(Animator animator)
        {
            _animators.Remove(animator);
        }

        #endregion
    }
}
