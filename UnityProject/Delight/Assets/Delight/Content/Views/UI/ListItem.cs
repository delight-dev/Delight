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
    /// Base view for items displayed within the List view. Has the extra states: Disabled, Highlighted, Pressed and Selected. 
    /// </summary>
    public partial class ListItem
    {
        #region Fields

        private bool _sizeSet = false;

        #endregion

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
        /// Called when a property has been changed. 
        /// </summary>
        public override void OnChanged(string property)
        {
            base.OnChanged(property);
            switch (property)
            {
                case nameof(IsSelected):
                    IsSelectedChanged();
                    break;
            }
        }

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
        /// Called before the view is loaded.
        /// </summary>
        protected override void BeforeLoad()
        {
            base.BeforeLoad();

            if (Width != null || Height != null)
            {
                _sizeSet = true;
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

            // the layout of the list item needs to be updated
            LayoutRoot.RegisterChangeHandler(OnListItemChildLayoutChanged);
        }

        /// <summary>
        /// Called when the layout of a child has been changed. 
        /// </summary>
        public void OnListItemChildLayoutChanged()
        {
            // here we want to update the layout but only if size has changed
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
            bool defaultDisableLayoutUpdate = DisableLayoutUpdate;
            DisableLayoutUpdate = true;

            bool hasNewSize = false;
            if (AutoSizeToContent && !_sizeSet)
            {
                hasNewSize = AdjustSizeToContent();
            }
            else
            {
                ElementSize newWidth = Width;
                ElementSize newHeight = Height;

                // adjust width and height to ParentList
                if (ParentList == null || ParentList.Orientation == ElementOrientation.Horizontal)
                {
                    newWidth = Width != null && Width.Unit != ElementSizeUnit.Percents
                        ? Width
                        : new ElementSize(Length);

                    if (Height == null)
                    {
                        newHeight = Breadth != null ? new ElementSize(Breadth) : ElementSize.FromPercents(1);
                    }
                }
                else
                {
                    // if neither width nor length is set, use 100% width                
                    if (Width == null)
                    {
                        newWidth = Length != null ? new ElementSize(Length) : ElementSize.FromPercents(1);
                    }

                    newHeight = Height != null && Height.Unit != ElementSizeUnit.Percents
                        ? Height
                        : new ElementSize(Breadth);
                }

                // adjust size to content unless it has been set
                if (!newWidth.Equals(Width))
                {
                    Width = newWidth;
                    hasNewSize = true;
                }

                if (!newHeight.Equals(Height))
                {
                    Height = newHeight;
                    hasNewSize = true;
                }
            }

            DisableLayoutUpdate = defaultDisableLayoutUpdate;
            return base.UpdateLayout(notifyParent) || hasNewSize;
        }

        /// <summary>
        /// Adjusts the size of the list item to its content. 
        /// </summary>
        public bool AdjustSizeToContent()
        {
            bool hasNewSize = false;

            // the default behavior of the list-item is to adjust its height and width to its content
            bool percentageWidth = true;
            bool percentageHeight = true;
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
                    percentageWidth = false;
                }

                if (childHeight.Unit != ElementSizeUnit.Percents)
                {
                    maxHeight = childHeight.Pixels > maxHeight ? childHeight.Pixels : maxHeight;
                    percentageHeight = false;
                }
            }

            // add margins
            var margin = Margin ?? ElementMargin.Default;
            maxWidth += margin.Left.Pixels + margin.Right.Pixels;
            maxHeight += margin.Top.Pixels + margin.Bottom.Pixels;

            // adjust size to content unless it has been set
            var newWidth = percentageWidth ? ElementSize.FromPercents(1) : new ElementSize(maxWidth);
            if (!newWidth.Equals(Width))
            {
                Width = newWidth;
                hasNewSize = true;
            }
            var newHeight = percentageHeight ? ElementSize.FromPercents(1) : new ElementSize(maxHeight);
            if (!newHeight.Equals(Height))
            {
                Height = newHeight;
                hasNewSize = true;
            }

            return hasNewSize;
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

            SetState("Selected");
            ParentList.SelectItem(this, true);
        }

        /// <summary>
        /// Called when mouse enters.
        /// </summary>
        public void ListItemMouseEnter()
        {
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
                SetState("Selected");
                ParentList.SelectItem(this, true);
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

        /// <summary>
        /// Called when the IsSelected field changes.
        /// </summary>
        public virtual void IsSelectedChanged()
        {
            if (State == "Disabled")
                return;

            if (IsSelected)
            {
                SetState("Selected");
            }
            else
            {
                SetState(DefaultItemStyle);
            }
        }

        /// <summary>
        /// Sets content template data.
        /// </summary>
        public override void SetContentTemplateData(ContentTemplateData contentTemplateData)
        {
            ContentTemplateData = contentTemplateData;
        }

        #endregion
    }
}
