#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Threading.Tasks;
#endregion

#pragma warning disable CS4014

namespace Delight
{
    /// <summary>
    /// Defines the header of an expander.
    /// </summary>
    public partial class ExpanderHeader
    {
        #region Fields

        /// <summary>
        /// Parent expander the expander header resides in.
        /// </summary>
        public Expander ParentExpander { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Sets the state of the view.
        /// </summary>
        public override async Task SetState(string state, bool animate = true, float initialDelay = 0)
        {
            if (state.IEquals(_previousState))
                return;

            foreach (var kv in SetExpanderState.AttachedValues)
            {
                if (!kv.Value)
                    continue;

                var view = kv.Key as View;
                if (view != null)
                {
                    view.SetState(state, animate, initialDelay);
                }
            }

            await base.SetState(state, animate, initialDelay);
        }

        /// <summary>
        /// Called when the expander header is clicked. 
        /// </summary>
        public void ExpanderHeaderClick()
        {
            if (ParentExpander == null || !ParentExpander.IsInteractable || 
                ParentExpander.IsDisabled)
            {
                return;
            }

            ParentExpander.IsExpanded = !ParentExpander.IsExpanded;
        }

        #endregion
    }
}

#pragma warning restore CS4014