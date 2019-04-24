#region Using Statements
using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    /// <summary>
    /// Provides logic for switching between views. 
    /// </summary>
    public partial class ViewSwitcher
    {
        public SceneObjectView ActiveView;

        protected override void BeforeLoad()
        {
            if (IgnoreObject)
                return;
            base.BeforeLoad();

            var firstChild = Content.LayoutChildren.FirstOrDefault();

            // make sure load-mode is set to Manual in children
            foreach (SceneObjectView child in Content.LayoutChildren)
            {
                if (!String.IsNullOrEmpty(StartView) && child.Id.IEquals(StartView))
                {
                    ActiveView = child;
                    continue;
                }

                if (SwitchToDefault && child == firstChild)
                {
                    ActiveView = child;
                    continue;
                }

                if (SwitchMode != SwitchMode.Enable)
                {
                    child.LoadMode = LoadMode.Manual;
                }
                else
                {
                    child.IsActive = false;
                }
            }

        }

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

        public void SwitchTo(int index)
        {
            var view = Content.LayoutChildren.ElementAtOrDefault(index);
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

            if (SwitchMode == SwitchMode.Enable)
            {
                ActiveView.IsActive = true;
            }
            else
            {
                ActiveView.Load();
            }
        }
    }
}
