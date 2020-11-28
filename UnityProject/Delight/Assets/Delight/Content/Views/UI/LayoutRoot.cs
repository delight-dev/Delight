#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
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
        private List<KeyValuePair<int, WeakReference<IUpdateable>>> _toBeUpdated = new List<KeyValuePair<int, WeakReference<IUpdateable>>>();
        private HashSet<int> _toBeUpdatedKeys = new HashSet<int>();

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
                // update state animations
                float deltaTime = Time.deltaTime;

                try
                {
                    foreach (var animator in _animators)
                    {
                        animator.Update(deltaTime);
                        if (animator.IsCompleted)
                        {
                            _completedAnimators.Add(animator);
                        }
                    }
                }
                catch
                {
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

            if (_toBeUpdated.Count > 0)
            {
                // update updateables
                List<int> updateablesToBeRemoved = null;
                for (int i = _toBeUpdated.Count - 1; i >= 0; --i)
                {
                    var updateable = _toBeUpdated[i];
                    if (updateable.Value.TryGetTarget(out var target))
                    {
                        target.OnUpdate();
                    }
                    else
                    {
                        if (updateablesToBeRemoved == null)
                        {
                            updateablesToBeRemoved = new List<int>();
                        }

                        updateablesToBeRemoved.Add(updateable.Key);
                    }
                }

                if (updateablesToBeRemoved != null)
                {
                    foreach (var updateableKey in updateablesToBeRemoved)
                    {
                        _toBeUpdated.Remove(_toBeUpdated.First(x => x.Key == updateableKey));
                        _toBeUpdatedKeys.Remove(updateableKey);
                    }
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
        /// Registers a state animator to be updated each frame.
        /// </summary>
        public async void RegisterAnimator(Animator animator)
        {
            _animators.Add(animator);
        }

        /// <summary>
        /// Unregisters an animator to be updated each frame.
        /// </summary>
        public async void UnregisterStateAnimator(Animator animator)
        {
            _animators.Remove(animator);
        }

        /// <summary>
        /// Registers binding to be updated each frame.
        /// </summary>
        public void RegisterUpdateable(IUpdateable updateable)
        {
            int key = updateable.GetHashCode();
            if (!_toBeUpdatedKeys.Contains(key))
            {
                _toBeUpdated.Add(new KeyValuePair<int, WeakReference<IUpdateable>>(key, new WeakReference<IUpdateable>(updateable)));
                _toBeUpdatedKeys.Add(key);
            }
        }

        #endregion
    }
}
