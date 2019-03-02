#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class ListItem
    {
        #region Properties

        /// <summary>
        /// Parent list the item resides in.
        /// </summary>
        public List ParentList { get; set; }

        /// <summary>
        /// Returns default item style.
        /// </summary>
        public string DefaultItemStyle
        {
            get
            {
                return IsAlternate ? "Alternate" : String.Empty;
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

            // find parent list
            ParentList = this.FindParent<List>();
        }

        /// <summary>
        /// Called when a child changes its layout.
        /// </summary>
        protected override void ChildLayoutChanged()
        {
            base.ChildLayoutChanged();

            // the layout of the list item need to be updated
            LayoutRoot.RegisterNeedLayoutUpdate(this);
        }

        /// <summary>
        /// Updates layout.
        /// </summary>
        public override void UpdateLayout(bool notifyParent = true)
        {
            bool defaultDisableLayoutUpdate = DisableLayoutUpdate;
            DisableLayoutUpdate = true;

            bool hasNewSize = false;

            // the default behavior of the list-item is to adjust its height and width to its content
            float maxWidth = 0f;
            float maxHeight = 0f;
            int childCount = LayoutChildren.Count;

            // get size of content and set content offsets and alignment
            for (int i = 0; i < childCount; ++i)
            {
                var childView = LayoutChildren[i] as UIView;
                if (childView == null)
                    continue;

                var childWidth = childView.OverrideWidth ?? (childView.Width ?? ElementSize.Default);
                var childHeight = childView.OverrideHeight ?? (childView.Height ?? ElementSize.Default);

                // get size of content
                if (childWidth.Unit != ElementSizeUnit.Percents)
                {
                    maxWidth = childWidth.Pixels > maxWidth ? childWidth.Pixels : maxWidth;
                }

                if (childHeight.Unit != ElementSizeUnit.Percents)
                {
                    maxHeight = childHeight.Pixels > maxHeight ? childHeight.Pixels : maxHeight;
                }
            }

            // add margins
            var margin = Margin ?? ElementMargin.Default;
            maxWidth += margin.Left.Pixels + margin.Right.Pixels;
            maxHeight += margin.Top.Pixels + margin.Bottom.Pixels;

            // adjust size to content unless it has been set
            var newWidth = new ElementSize(maxWidth);            
            if (!newWidth.Equals(Width))
            {
                Width = newWidth;
                hasNewSize = true;
            }
            var newHeight = new ElementSize(maxHeight);
            if (!newHeight.Equals(Height))
            {
                Height = newHeight;
                hasNewSize = true;
            }

            DisableLayoutUpdate = defaultDisableLayoutUpdate;

            base.UpdateLayout(notifyParent && hasNewSize);
        }

        /// <summary>
        /// Called when mouse is clicked.
        /// </summary>
        public void ListItemMouseClick()
        {
            if (ParentList == null || State == "Disabled")
                return;

            if (!ParentList.SelectOnMouseUp)
                return;

            SetState("Selected"); // TODO implement
            //ParentList.SelectItem(this, true);
        }

        /// <summary>
        /// Called when mouse enters.
        /// </summary>
        public void ListItemMouseEnter()
        {
            Debug.Log("ListItemMouseEnter()"); // TODO remove

            if (State == "Disabled")
                return;

            IsMouseOver = true;
            if (IsSelected)
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
        public void ListItemMouseExit()
        {
            Debug.Log("ListItemMouseExit()"); // TODO remove

            if (State == "Disabled")
                return;

            IsMouseOver = false;
            if (IsSelected)
                return;

            SetState(DefaultItemStyle);
        }

        /// <summary>
        /// Called when mouse down.
        /// </summary>
        public void ListItemMouseDown()
        {
            if (ParentList == null || State == "Disabled")
                return;

            if (!ParentList.SelectOnMouseUp)
            {
                SetState("Selected"); // TODO implement
                //ParentList.SelectItem(this, true);
            }
            else
            {
                IsPressed = true;
                if (IsSelected)
                    return;

                SetState("Pressed");
            }
        }

        /// <summary>
        /// Called when mouse up.
        /// </summary>
        public void ListItemMouseUp()
        {
            if (State == "Disabled")
                return;

            IsPressed = false;
            if (IsSelected)
                return;

            if (IsMouseOver)
            {
                SetState("Highlighted");
            }
            else
            {
                SetState(DefaultItemStyle);
            }
        }

        #endregion
    }
}
