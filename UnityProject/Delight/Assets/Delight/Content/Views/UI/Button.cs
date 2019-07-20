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
    /// The button view is a clickable region with text. Has the additional states: Highlighted, Pressed and Disabled. The button can be set to toggle through IsToggleButton and to adjust its size to its text through the AutoSize field.
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
        /// Called once in the object's lifetime after construction of children and before load.
        /// </summary>
        public override void AfterInitialize()
        {
            base.AfterInitialize();

            // listens to label 
            Label.PropertyChanged += Label_PropertyChanged;
        }

        /// <summary>
        /// Called when a property has been changed. 
        /// </summary>
        public override void OnChanged(string property)
        {
            base.OnChanged(property);
            switch (property)
            {
                case nameof(IsDisabled):
                    IsDisabledChanged();
                    break;

                case nameof(ToggleValue):
                    ToggleValueChanged();
                    break;
            }
        }

        /// <summary>
        /// Called when toggle value changes.
        /// </summary>
        public void ToggleValueChanged()
        {
            if (!IsToggleButton)
                return;

            if (ToggleValue)
            {
                SetState("Pressed");
            }
            else
            {
                SetState(DefaultStateName);
            }

            ToggleClick?.Invoke(this, ToggleValue);
        }

        /// <summary>
        /// Called when property on button label is changed.
        /// </summary>
        private void Label_PropertyChanged(object source, string propertyName)
        {
            switch (propertyName)
            {
                case nameof(Label.Width):
                case nameof(Label.Height):
                case nameof(Label.Text):
                    TextChanged();
                    break;

            }
        }

        /// <summary>
        /// Called when label text changes.
        /// </summary>
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

            // disable label if no text is shown 
            Label.IsActive = !String.IsNullOrEmpty(Label.Text);
        }

        /// <summary>
        /// Called just before the view and its children are loaded.
        /// </summary>
        protected override void BeforeLoad()
        {
            if (IgnoreObject)
                return;
            base.BeforeLoad();

            bool autoSizeUndefined = AutoSizeProperty.IsUndefined(this);
            if (autoSizeUndefined)
            {
                // if autosize is undefined, set default value depending if width and height is set
                bool widthUndefined = WidthProperty.IsUndefined(this);
                bool heightUndefined = HeightProperty.IsUndefined(this);

                if (widthUndefined && !heightUndefined)
                    AutoSize = AutoSize.Width;
                else if (!widthUndefined && heightUndefined)
                    AutoSize = AutoSize.Height;
                else if (widthUndefined && heightUndefined)
                    AutoSize = AutoSize.WidthAndHeight;
                else
                    AutoSize = AutoSize.None;
            }

            Label.AutoSize = AutoSize;
            if (AutoSize == AutoSize.None && WidthProperty.IsUndefined(this))
            {
                // if size isn't specified and the button doesn't adjust to label size, then set default width
                WidthProperty.SetValue(this, DefaultWidth, false);
            }

            if (LayoutParent is ToggleGroup)
            {
                // default to toggle-button if in toggle-group
                IsToggleButton = true;
                CanToggleOff = false;
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

            // adjust size initially to text
            TextChanged();

            if (IsToggleButton)
            {
                ToggleValueChanged();
            }

            if (ImageComponent == null && BackgroundSpriteProperty.IsUndefined(this))
            {
                // provide raycast target so transparent clicks are tracked
                if (GameObject?.GetComponent<RaycastTargetGraphic>() == null)
                {
                    GameObject?.AddComponent<RaycastTargetGraphic>();
                }
            }
        }

        /// <summary>
        /// Called when mouse is clicked.
        /// </summary>
        public void ButtonMouseClick()
        {
            if (!IsToggleButton)
                return;

            // if toggle-button change state
            if (ToggleValue && !CanToggleOff)
                return;
            if (!ToggleValue && !CanToggleOn)
                return;
            ToggleValue = !ToggleValue;

            // if in toggle-group untoggle all other buttons
            if (LayoutParent is ToggleGroup)
            {
                LayoutParent.ForEach<Button>(x =>
                {
                    if (x.IsToggleButton && x != this)
                    {
                        x.ToggleValue = false;
                    }
                });
            }
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
            if (state.IEquals(_previousState))
                return;

            base.SetState(state);
            Label.SetState(state);
        }

        /// <summary>
        /// Called when the button is disabled/enabled.
        /// </summary>
        public void IsDisabledChanged()
        {
            if (IsDisabled)
            {
                SetState("Disabled");

                // disable button actions
                Click.IsEnabled = false;
                MouseEnter.IsEnabled = false;
                MouseExit.IsEnabled = false;
                MouseDown.IsEnabled = false;
                MouseUp.IsEnabled = false;
            }
            else
            {
                SetState(IsToggleButton && ToggleValue ? "Pressed" : DefaultStateName);

                // enable button actions
                Click.IsEnabled = true;
                MouseEnter.IsEnabled = true;
                MouseExit.IsEnabled = true;
                MouseDown.IsEnabled = true;
                MouseUp.IsEnabled = true;
            }
        }

        /// <summary>
        /// Called when the button is disabled.
        /// </summary>
        public override void OnDisable()
        {
            if (!IsToggleButton && !IsDisabled)
            {
                // reset state to default if view is deactivated
                SetState(DefaultStateName);
            }
        }

        /// <summary>
        /// Called by designer to make the view presentable in the designer.
        /// </summary>
        public override void PrepareForDesigner()
        {
            Text = "Button";
        }

        #endregion
    }
}
