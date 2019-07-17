#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
#endregion

namespace Delight
{
    /// <summary>
    /// The group is used to spacially arrange child views next to each other either horizontally or vertically based on the Orientation property.
    /// </summary>
    public partial class Group
    {
        #region Properties
        #endregion

        #region Methods

        /// <summary>
        /// Called when a child changes its layout.
        /// </summary>
        protected override void ChildLayoutChanged()
        {
            base.ChildLayoutChanged();
            if (IgnoreObject)
                return;

            // the layout of the group needs to be updated
            LayoutRoot.RegisterChangeHandler(OnGroupChildLayoutChanged);
        }

        /// <summary>
        /// Called when the layout of a child has been changed. 
        /// </summary>
        public void OnGroupChildLayoutChanged()
        {
            // here we want to update the layout but only if size has changed
            if (UpdateLayout(false))
            {
                NotifyParentOfChildLayoutChanged();
            }
        }

        /// <summary>
        /// Updates the layout of the group. 
        /// </summary>
        public override bool UpdateLayout(bool notifyParent = true)
        {
            bool defaultDisableLayoutUpdate = DisableLayoutUpdate;
            DisableLayoutUpdate = true;

            bool hasNewSize = false;
            float maxWidth = 0f;
            float maxHeight = 0f;
            float totalWidth = 0f;
            float totalHeight = 0f;
            bool percentageWidth = false;
            bool percentageHeight = false;
            bool isHorizontal = Orientation == ElementOrientation.Horizontal;
            List<UIView> children = new List<UIView>();
            this.ForEach<UIView>(x =>
            {
                children.Add(x);
            }, false);

            // get size of content and set content offsets and alignment
            var spacing = Spacing ?? ElementSize.Default;
            int childCount = children.Count;
            int childIndex = 0;
            for (int i = 0; i < childCount; ++i)
            {
                var childView = children[i];
                if (!childView.IsActive)
                {
                    // don't group inactive views
                    continue;
                }

                var childWidth = childView.OverrideWidth ?? (childView.Width ?? ElementSize.Default);
                var childHeight = childView.OverrideHeight ?? (childView.Height ?? ElementSize.Default);

                if (childWidth.Unit == ElementSizeUnit.Percents)
                {
                    if (isHorizontal)
                    {
                        Debug.LogWarning(String.Format("#Delight# Unable to group view \"{0}\" horizontally as it doesn't specify its width in pixels.", childView.Name));
                        continue;
                    }
                    else
                    {
                        percentageWidth = true;
                    }
                }

                if (childHeight.Unit == ElementSizeUnit.Percents)
                {
                    if (!isHorizontal)
                    {
                        Debug.LogWarning(String.Format("#Delight# Unable to group view \"{0}\" vertically as it doesn't specify its height in pixels or elements.", childView.Name));
                        continue;
                    }
                    else
                    {
                        percentageHeight = true;
                    }
                }

                bool defaultDisableChildLayoutUpdate = childView.DisableLayoutUpdate;
                childView.DisableLayoutUpdate = true;

                // set offsets and alignment
                var offset = new ElementMargin(
                    new ElementSize(isHorizontal ? totalWidth + spacing.Pixels * childIndex : 0f, ElementSizeUnit.Pixels),
                    new ElementSize(!isHorizontal ? totalHeight + spacing.Pixels * childIndex : 0f, ElementSizeUnit.Pixels));

                // set desired alignment if it is valid for the orientation otherwise use defaults
                var alignment = ElementAlignment.Center;
                var defaultAlignment = isHorizontal ? ElementAlignment.Left : ElementAlignment.Top;
                var desiredAlignment = !ContentAlignmentProperty.IsUndefined(this) ? ContentAlignment : childView.Alignment;
                if (isHorizontal && (desiredAlignment == ElementAlignment.Top || desiredAlignment == ElementAlignment.Bottom
                    || desiredAlignment == ElementAlignment.TopLeft || desiredAlignment == ElementAlignment.BottomLeft))
                {
                    alignment = defaultAlignment | desiredAlignment;
                }
                else if (!isHorizontal && (desiredAlignment == ElementAlignment.Left || desiredAlignment == ElementAlignment.Right
                    || desiredAlignment == ElementAlignment.TopLeft || desiredAlignment == ElementAlignment.TopRight))
                {
                    alignment = defaultAlignment | desiredAlignment;
                }
                else
                {
                    alignment = defaultAlignment;
                }

                // get size of content
                if (!percentageWidth)
                {
                    totalWidth += childWidth;
                    maxWidth = childWidth.Pixels > maxWidth ? childWidth.Pixels : maxWidth;
                }

                if (!percentageHeight)
                {
                    totalHeight += childHeight;
                    maxHeight = childHeight.Pixels > maxHeight ? childHeight.Pixels : maxHeight;
                }

                // update child layout
                if (!offset.Equals(childView.OffsetFromParent) || alignment != childView.Alignment)
                {
                    childView.OffsetFromParent = offset;
                    childView.Alignment = alignment;

                    childView.UpdateLayout(false);
                }
                ++childIndex;
                childView.DisableLayoutUpdate = defaultDisableChildLayoutUpdate;
            }

            // set width and height 
            float totalSpacing = childCount > 1 ? (childIndex - 1) * spacing.Pixels : 0f;

            // adjust width to content
            if (WidthProperty.IsUndefined(this))
            {
                if (!percentageWidth)
                {
                    // add margins
                    var margin = Margin ?? ElementMargin.Default;
                    totalWidth += isHorizontal ? totalSpacing : 0f;
                    totalWidth += margin.Left.Pixels + margin.Right.Pixels;
                    maxWidth += margin.Left.Pixels + margin.Right.Pixels;

                    // adjust width to content
                    var newWidth = new ElementSize(isHorizontal ? totalWidth : maxWidth, ElementSizeUnit.Pixels);
                    if (!newWidth.Equals(Width))
                    {
                        OverrideWidth = newWidth;
                        hasNewSize = true;
                    }
                }
                else
                {
                    var newWidth = new ElementSize(1, ElementSizeUnit.Percents);
                    if (!newWidth.Equals(Width))
                    {
                        OverrideWidth = newWidth;
                        hasNewSize = true;
                    }
                }
            }
            else if (OverrideWidth != null && !OverrideWidth.Equals(Width))
            {
                // clear override
                OverrideWidth = null;
                hasNewSize = true;
            }

            // adjust height to content
            if (HeightProperty.IsUndefined(this))
            {
                if (!percentageHeight)
                {
                    // add margins
                    var margin = Margin ?? ElementMargin.Default;
                    totalHeight += !isHorizontal ? totalSpacing : 0f;
                    totalHeight += margin.Top.Pixels + margin.Bottom.Pixels;
                    maxHeight += margin.Top.Pixels + margin.Bottom.Pixels;

                    // adjust height to content
                    var newHeight = new ElementSize(!isHorizontal ? totalHeight : maxHeight, ElementSizeUnit.Pixels);
                    if (!newHeight.Equals(Height))
                    {
                        OverrideHeight = newHeight;
                        hasNewSize = true;
                    }
                }
                else
                {
                    var newHeight = new ElementSize(1, ElementSizeUnit.Percents);
                    if (!newHeight.Equals(Height))
                    {
                        OverrideHeight = newHeight;
                        hasNewSize = true;
                    }
                }
            }
            else if (OverrideHeight != null && !OverrideHeight.Equals(Height))
            {
                // clear override
                OverrideHeight = null;
                hasNewSize = true;
            }

            DisableLayoutUpdate = defaultDisableLayoutUpdate;

            return base.UpdateLayout(notifyParent) || hasNewSize; 
        }

        #endregion
    }
}
