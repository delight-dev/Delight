#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    /// <summary>
    /// View that resizes itself to its content by default.
    /// </summary>
    public partial class Frame
    {
        #region Fields

        private bool _sizeSet = false;

        #endregion
        
        #region Methods

        /// <summary>
        /// Called before the view is loaded.
        /// </summary>
        protected override void BeforeLoad()
        {
            base.BeforeLoad();
            if (Width != null || Height != null)
            {
                _sizeSet = true;
            }
        }

        /// <summary>
        /// Called when a child changes its layout.
        /// </summary>
        protected override void ChildLayoutChanged()
        {
            base.ChildLayoutChanged();
            if (IgnoreObject)
                return;

            // the layout of the list item needs to be updated
            LayoutRoot.RegisterChangeHandler(OnFrameChildLayoutChanged);
        }

        /// <summary>
        /// Called when the layout of a child has been changed. 
        /// </summary>
        public void OnFrameChildLayoutChanged()
        {
            // here we want to update the layout but only if size has changed
            if (UpdateLayout(false))
            {
                NotifyParentOfChildLayoutChanged();
            }
        }

        /// <summary>
        /// Updates layout.
        /// </summary>
        public override bool UpdateLayout(bool notifyParent = true)
        {
            bool defaultDisableLayoutUpdate = DisableLayoutUpdate;
            DisableLayoutUpdate = true;

            bool hasNewSize = false;
            if (AutoSizeToContent && !_sizeSet)
            {
                hasNewSize = AdjustSizeToContent();
            }

            DisableLayoutUpdate = defaultDisableLayoutUpdate;
            return base.UpdateLayout(notifyParent) || hasNewSize;
        }

        #endregion
    }
}
