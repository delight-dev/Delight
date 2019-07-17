#region Using Statements
using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
#endregion

namespace Delight
{
    /// <summary>
    /// Provides logic for switching between mutliple child views and displaying one at a time. By default the views are loaded when they are displayed, behavior can be changed through the SwitchMode property. 
    /// </summary>
    public partial class ViewSwitcher
    {
        #region Fields

        public SceneObjectView ActiveView;

        #endregion

        #region Methods

        /// <summary>
        /// Called before the view is loaded.
        /// </summary>
        protected override void BeforeLoad()
        {
            if (IgnoreObject)
                return;
            base.BeforeLoad();

            var firstChild = Content.LayoutChildren.FirstOrDefault();

            // make sure load-mode is set to Manual in children if we're loading them
            foreach (SceneObjectView child in Content.LayoutChildren)
            {
                if (!String.IsNullOrEmpty(StartView) && child.Id.IEquals(StartView))
                {
                    ActiveView = child;
                    continue;
                }

                if (ShowFirstByDefault && child == firstChild)
                {
                    ActiveView = child;
                    continue;
                }

                var childLoadMode = child.LoadMode | ChildLoadMode;
                if (SwitchMode != SwitchMode.Enable)
                {
                    var loadMode = childLoadMode | LoadMode.Manual;
                    child.LoadMode = loadMode;
                }
                else
                {
                    childLoadMode &= ~LoadMode.Manual; // remove any manual flag to force automatic if we're activating them
                    child.LoadMode = childLoadMode;
                    child.IsActive = false;
                }
            }

        }

        /// <summary>
        /// Called after the view is loaded.
        /// </summary>
        protected override void AfterLoad()
        {
            if (IgnoreObject)
                return;
            base.AfterLoad();

            // load active view if it hasn't been loaded
            if (ActiveView != null)
            {
                if (!ActiveView.IsLoaded)
                    ActiveView.Load();

                if (!ActiveView.IsActive)
                    ActiveView.IsActive = true;
            }
        }

        /// <summary>
        /// Switches to view at index.
        /// </summary>
        public void SwitchTo(int index)
        {
            var view = Content.LayoutChildren.ElementAtOrDefault(index);
            SwitchTo(view);
        }

        /// <summary>
        /// Switches to the view specified.
        /// </summary>
        public void SwitchTo(View view)
        {
            if (view == ActiveView)
                return;

            if (ActiveView != null)
            {
                if (SwitchMode == SwitchMode.Load)
                {
                    ActiveView.Unload();
                }
                else
                {
                    ActiveView.IsActive = false;
                }
            }

            ActiveView = view as SceneObjectView;
            if (ActiveView == null)
                return;

            // load/activate view
            ActiveView.Load();
            ActiveView.IsActive = true;
        }

        /// <summary>
        /// Switches to view at index.
        /// </summary>
        public async Task SwitchToAsync(int index)
        {
            var view = Content.LayoutChildren.ElementAtOrDefault(index);
            await SwitchToAsync(view);
        }

        /// <summary>
        /// Switches to the view specified.
        /// </summary>
        public async Task SwitchToAsync(View view)
        {
            if (view == ActiveView)
                return;

            if (ActiveView != null)
            {
                if (SwitchMode == SwitchMode.Load)
                {
                    ActiveView.Unload();
                }
                else
                {
                    ActiveView.IsActive = false;
                }
            }

            ActiveView = view as SceneObjectView;
            if (ActiveView == null)
                return;

            // load/activate view
            await ActiveView.LoadAsync();
            ActiveView.IsActive = true;
        }

        #endregion
    }
}
