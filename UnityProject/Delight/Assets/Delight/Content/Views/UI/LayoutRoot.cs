#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
#endregion

namespace Delight
{
    /// <summary>
    /// LayoutRoot view.
    /// </summary>
    public partial class LayoutRoot
    {
        #region Fields

        private HashSet<UIView> _needLayoutUpdate = new HashSet<UIView>();
        private List<UIView> _toBeUpdated = new List<UIView>();

        #endregion

        #region Methods

        /// <summary>
        /// Updates the view. Called once each frame. 
        /// </summary>
        public override void Update()
        {
            base.Update();
            while (_needLayoutUpdate.Count > 0)
            {
                _toBeUpdated.AddRange(_needLayoutUpdate);
                _needLayoutUpdate.Clear();
                for (int i = 0; i < _toBeUpdated.Count; ++i)
                {
                    if (_toBeUpdated[i].IsLoaded)
                    {
                        _toBeUpdated[i].UpdateLayout();
                    }
                }
                _toBeUpdated.Clear();
            }
        }

        /// <summary>
        /// Registers the specified view to have its layout updated.
        /// </summary>
        public void RegisterNeedLayoutUpdate(UIView uiView)
        {
            _needLayoutUpdate.Add(uiView);
        }

        #endregion
    }
}
