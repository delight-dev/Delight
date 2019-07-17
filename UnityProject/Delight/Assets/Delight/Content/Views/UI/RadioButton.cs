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
    /// Presents a one-of-many selection option. If multiple radio buttons shares the same parent only one is selected at a time.
    /// </summary>
    public partial class RadioButton
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
            LayoutRoot.RegisterChangeHandler(OnRadioButtonChildLayoutChanged);
        }

        /// <summary>
        /// Called when the layout of a child has been changed. 
        /// </summary>
        public void OnRadioButtonChildLayoutChanged()
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
            var newWidth = new ElementSize(RadioButtonGroup.ActualWidth, ElementSizeUnit.Pixels);
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
        /// Called when radio button is clicked.
        /// </summary>
        public void RadioButtonClick()
        {
            if (!IsInteractable || IsDisabled)
                return;

            // deselect all radio buttons
            if (LayoutParent != null)
            {
                LayoutParent.Content.ForEach<RadioButton>(x =>
                {
                    x.IsChecked = false;
                }, false);
            }

            // select this radio button
            IsChecked = true;
        }

        /// <summary>
        /// Sets the state of the view.
        /// </summary>
        public override void SetState(string state)
        {
            if (state.IEquals(_previousState))
                return;

            base.SetState(state);
            RadioButtonImageView.SetState(state);
            RadioButtonLabel.SetState(state);
        }

        /// <summary>
        /// Called by designer to make the view presentable in the designer.
        /// </summary>
        public override void PrepareForDesigner()
        {
            Text = "RadioButton";
        }

        #endregion
    }
}
