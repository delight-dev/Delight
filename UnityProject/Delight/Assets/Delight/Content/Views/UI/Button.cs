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
