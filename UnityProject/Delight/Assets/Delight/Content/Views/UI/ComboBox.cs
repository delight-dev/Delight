#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class ComboBox
    {
        #region Methods

        /// <summary>
        /// Called when a property has been changed. 
        /// </summary>
        public override void OnPropertyChanged(object source, string property)
        {
            if (IgnoreObject)
                return;

            base.OnPropertyChanged(source, property);
            switch (property)
            {
                case nameof(IsDropUp):
                    IsDropUpChanged();
                    break;
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

            // if list is scrollable we need to force select on mouse up and set scroll delta for the combo box to be usable
            if (IsScrollable)
            {
                if (!DisableInteractionScrollDeltaProperty.IsUndefined(ComboBoxList.ScrollableRegion)) // TODO implement
                {
                    DisableInteractionScrollDelta = 1f;
                }
                SelectOnMouseUp = true;
            }

            IsDropUpChanged();
        }

        /// <summary>
        /// Called once per frame if EnableScriptEvents is true.
        /// </summary>
        public override void Update()
        {
            // if list is open check if user has clicked outside
            if (ComboBoxList.IsActive)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (!ComboBoxButton.ContainsMouse(Input.mousePosition) &&
                        !ComboBoxList.ContainsMouse(Input.mousePosition))
                    {
                        ComboBoxList.IsActive = false;
                        ComboBoxButton.ToggleValue = false;
                    }
                }
            }
        }

        /// <summary>
        /// Called when IsDropUp field changes.
        /// </summary>
        public virtual void IsDropUpChanged()
        {
            if (IsDropUp)
            {
                ComboBoxListCanvas.OffsetFromParent = new ElementMargin(0, -ComboBoxList.ActualHeight, 0, 0);
                //ComboBoxList.SortDirection.Value = ElementSortDirection.Descending;
                // TODO implement sort direction
            }
            else
            {
                ComboBoxListCanvas.OffsetFromParent = new ElementMargin(0, ActualHeight, 0, 0);
                //ComboBoxList.SortDirection.Value = ElementSortDirection.Ascending;
                // TODO implement sort direction
            }
        }

        /// <summary>
        /// Called when mouse is clicked.
        /// </summary>
        public void ComboBoxButtonClick(Button source)
        {
            // toggle combo box list
            if (source.ToggleValue)
            {
                ComboBoxList.IsActive = true;

                if (IsDropUp)
                {
                    ComboBoxListCanvas.OffsetFromParent = new ElementMargin(0, -ComboBoxList.ActualHeight, 0, 0);
                    //ComboBoxList.SortDirection.Value = ElementSortDirection.Descending;
                    // TODO implement sort direction
                }
                else
                {
                    ComboBoxListCanvas.OffsetFromParent = new ElementMargin(0, ActualHeight, 0, 0);
                    //ComboBoxList.SortDirection.Value = ElementSortDirection.Ascending;
                    // TODO implement sort direction
                }
            }
            else
            {
                ComboBoxList.IsActive = false;
            }
        }

        /// <summary>
        /// Called when combo box list selection changes.
        /// </summary>
        public void ComboBoxListSelectionChanged(List sender, ListItem listItem)
        {
            // close list and set selected item text
            ComboBoxButton.ToggleValue = false;
            //ComboBoxButton.Text = listItem != null ? actionData.ItemView.Text.Value : String.Empty;
            // TODO implement getting item text data using reflection 
            ComboBoxList.IsActive = false;
        }

        #endregion
    }
}
