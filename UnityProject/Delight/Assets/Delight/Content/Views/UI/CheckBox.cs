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
    /// A check box view consisting of a box that can be ticked and a text label.
    /// </summary>
    public partial class CheckBox
    {
        #region Methods

        /// <summary>
        /// Called when a property has been changed. 
        /// </summary>
        public override void OnChanged(string property)
        {
            base.OnChanged(property);
            switch (property)
            {
                case nameof(IsChecked):
                    IsCheckedChanged();
                    break;

                case nameof(IsDisabled):
                    IsDisabledChanged();
                    break;
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

            // the layout of the group needs to be updated
            LayoutRoot.RegisterChangeHandler(OnCheckBoxChildLayoutChanged);
        }

        /// <summary>
        /// Called when the layout of a child has been changed. 
        /// </summary>
        public void OnCheckBoxChildLayoutChanged()
        {
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
            bool hasNewSize = false;
            var newWidth = new ElementSize(CheckBoxGroup.ActualWidth, ElementSizeUnit.Pixels);
            if (!newWidth.Equals(Width))
            {
                WidthProperty.SetValue(this, newWidth, false);
                hasNewSize = true;
            }
            
            return base.UpdateLayout(notifyParent) || hasNewSize;
        }

        /// <summary>
        /// Called when the field IsChecked is changed.
        /// </summary>
        public virtual void IsCheckedChanged()
        {
            if (IsDisabled)
                return;

            if (IsChecked)
            {
                SetState("Checked");
            }
            else
            {
                SetState(DefaultStateName);
            }
        }

        /// <summary>
        /// Called when IsDisabled field changes.
        /// </summary>
        public virtual void IsDisabledChanged()
        {
            if (IsDisabled)
            {
                SetState("Disabled");
            }
            else
            {
                SetState(IsChecked ? "Checked" : DefaultStateName);
            }
        }

        /// <summary>
        /// Called when check box is clicked.
        /// </summary>
        public void CheckBoxClick()
        {
            if (!IsInteractable || IsDisabled)
                return;

            IsChecked = !IsChecked;
        }

        /// <summary>
        /// Sets the state of the view.
        /// </summary>
        public override void SetState(string state)
        {
            if (state.IEquals(_previousState))
                return;

            base.SetState(state);
            CheckBoxImageView.SetState(state);
            CheckBoxLabel.SetState(state);
        }

        /// <summary>
        /// Called by designer to make the view presentable in the designer.
        /// </summary>
        public override void PrepareForDesigner()
        {
            Text = "CheckBox";
        }

        #endregion
    }
}
