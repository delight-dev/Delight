#region Using Statements
using UnityEngine.EventSystems;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    /// <summary>
    /// Presents a static or dynamic list of items in a drop-down.
    /// </summary>
    public partial class ComboBox
    {
        #region Properties

        /// <summary>
        /// Passes along the template to the combo-box list.
        /// </summary>
        public BindableCollection<ContentTemplate> ContentTemplates
        {
            get
            {
                return ComboBoxList.ContentTemplates;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Called when a property has been changed. 
        /// </summary>
        public override void OnChanged(string property)
        {
            base.OnChanged(property);
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
        public void ComboBoxListSelectionChanged(List sender, ItemSelectionActionData selectionData)
        {
            // close list and set selected item text
            ComboBoxButton.ToggleValue = false;

            // take the text data from the first label in the list item
            if (selectionData.ListItem == null)
                ComboBoxButton.Text = string.Empty;
            else
            {
                var label = selectionData.ListItem.Find<Label>();
                ComboBoxButton.Text = label.Text;
            }

            ComboBoxList.IsActive = false;
            ItemSelected?.Invoke(this, selectionData);
        }

        #endregion
    }
}
