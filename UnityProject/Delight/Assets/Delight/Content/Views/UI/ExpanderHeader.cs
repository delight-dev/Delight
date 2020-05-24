#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
#endregion

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
        public override void SetState(string state)
        {
            if (state.IEquals(_previousState))
                return;
            base.SetState(state);

            foreach (var kv in SetExpanderState.AttachedValues)
            {
                if (!kv.Value)
                    continue;

                var view = kv.Key as View;
                if (view != null)
                {
                    view.SetState(state);
                }
            }
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
