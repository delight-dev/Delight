#region Using Statements
using System;
using System.Collections.Generic;
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

        #endregion

        #region Methods

        /// <summary>
        /// Updates the view. Called once each frame. 
        /// </summary>
        public override void LateUpdate()
        {
            base.LateUpdate();
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

        #endregion
    }
}
