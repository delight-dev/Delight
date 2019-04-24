#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
#endregion

namespace Delight
{
    /// <summary>
    /// Button view.
    /// </summary>
    public partial class Button
    {
        #region Properties

        /// <summary>
        /// Gets value indicating if button is a toggle button and is pressed.
        /// </summary>
        public bool TogglePressed
        {
            get
            {
                return IsToggleButton && ToggleValue;
            }
        }

        #endregion

        #region Methods

        public override void AfterInitialize()
        {
            base.AfterInitialize();

            // listens to label 
            Label.PropertyChanged += Label_PropertyChanged;
        }

        private void Label_PropertyChanged(object source, string propertyName)
        {
            if (propertyName == nameof(Label.Text))
            {
                TextChanged();
            }
        }

        public virtual void TextChanged()
        {
            // adjust button size to text
            if (AutoSize == AutoSize.Width || AutoSize == AutoSize.Default)
            {
                Width = new ElementSize(Label.PreferredWidth + TextPadding.Left.Pixels + TextPadding.Right.Pixels);
            }
            else if (AutoSize == AutoSize.Height)
            {
                Height = new ElementSize(Label.PreferredHeight + TextPadding.Top.Pixels + TextPadding.Bottom.Pixels);
            }
            else if (AutoSize == AutoSize.WidthAndHeight)
            {
                Width = new ElementSize(Label.PreferredWidth + TextPadding.Left.Pixels + TextPadding.Right.Pixels);
                Height = new ElementSize(Label.PreferredHeight + TextPadding.Top.Pixels + TextPadding.Bottom.Pixels);
            }
        }

        protected override void BeforeLoad()
        {
            if (IgnoreObject)
                return;
            base.BeforeLoad();

            if (AutoSize == AutoSize.None && WidthProperty.IsUndefined(this))
            {
                // if size isn't specified and the button doesn't adjust to label size, then set default width
                WidthProperty.SetValue(this, DefaultWidth, false);
            }
        }

        protected override void AfterLoad()
        {
            if (IgnoreObject)
                return;
            base.AfterLoad();

            if (AutoSize != AutoSize.None)
            {
                // adjust size initially to text
                TextChanged();
            }
        }

        /// <summary>
        /// Called when mouse is clicked.
        /// </summary>
        public void ButtonMouseClick()
        {
            Debug.Log("ButtonMouseClick() called");

            if (!IsToggleButton)
                return;

            // if toggle-button change state
            if (ToggleValue == true && !CanToggleOff)
                return;
            if (ToggleValue == false && !CanToggleOn)
                return;
            ToggleValue = !ToggleValue;
        }

        /// <summary>
        /// Called when mouse enters.
        /// </summary>
        public void ButtonMouseEnter()
        {
            IsMouseOver = true;
            if (TogglePressed)
                return;

            if (IsPressed)
            {
                SetState("Pressed");
            }
            else
            {
                SetState("Highlighted");
            }
        }

        /// <summary>
        /// Called when mouse exits.
        /// </summary>
        public void ButtonMouseExit()
        {
            IsMouseOver = false;
            if (TogglePressed)
                return;

            SetState(DefaultStateName);
        }

        /// <summary>
        /// Called when mouse down.
        /// </summary>
        public void ButtonMouseDown()
        {
            IsPressed = true;
            if (TogglePressed)
                return;

            SetState("Pressed");
        }

        /// <summary>
        /// Called when mouse up.
        /// </summary>
        public void ButtonMouseUp()
        {
            IsPressed = false;
            if (TogglePressed)
                return;

            if (IsMouseOver)
            {
                SetState("Highlighted");
            }
            else
            {
                SetState(DefaultStateName);
            }
        }

        /// <summary>
        /// Sets the state of the view.
        /// </summary>
        public override void SetState(string state)
        {
            base.SetState(state);
            Label.SetState(state);
        }

        /// <summary>
        /// Called when the button is disabled.
        /// </summary>
        public void OnDisable()
        {
            if (!IsToggleButton && !IsDisabled)
            {
                // reset state to default if view is deactivated
                SetState(DefaultStateName);
            }
        }

        #endregion
    }
}
