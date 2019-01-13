#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
#endregion

namespace Delight
{
    /// <summary>
    /// Group view.
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

            // the layout of the group needs to be updated
            LayoutRoot.RegisterNeedLayoutUpdate(this);
        }

        /// <summary>
        /// Updates the layout of the group. 
        /// </summary>
        public override void UpdateLayout(bool notifyParent = true)
        {
            bool defaultDisableLayoutUpdate = DisableLayoutUpdate;
            DisableLayoutUpdate = true;

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
                var view = children[i];
                if (view.Width.Unit == ElementSizeUnit.Percents)
                {
                    if (isHorizontal)
                    {
                        Debug.LogWarning(String.Format("[Delight] Unable to group view \"{0}\" horizontally as it doesn't specify its width in pixels.", view.Name));
                        continue;
                    }
                    else
                    {
                        percentageWidth = true;
                    }
                }

                if (view.Height.Unit == ElementSizeUnit.Percents)
                {
                    if (!isHorizontal)
                    {
                        Debug.LogWarning(String.Format("[Delight] Unable to group view \"{0}\" vertically as it doesn't specify its height in pixels or elements.", view.Name));
                        continue;
                    }
                    else
                    {
                        percentageHeight = true;
                    }
                }

                bool defaultDisableChildLayoutUpdate = view.DisableLayoutUpdate;
                view.DisableLayoutUpdate = true;

                // set offsets and alignment
                var offset = new ElementMargin(
                    new ElementSize(isHorizontal ? totalWidth + spacing.Pixels * childIndex : 0f, ElementSizeUnit.Pixels),
                    new ElementSize(!isHorizontal ? totalHeight + spacing.Pixels * childIndex : 0f, ElementSizeUnit.Pixels));
                view.OffsetFromParent = offset;

                // set desired alignment if it is valid for the orientation otherwise use defaults
                var alignment = isHorizontal ? ElementAlignment.Left : ElementAlignment.Top;
                var desiredAlignment = ContentAlignmentProperty.IsUndefined(this) ? ContentAlignment : view.Alignment;
                if (isHorizontal && (desiredAlignment == ElementAlignment.Top || desiredAlignment == ElementAlignment.Bottom
                    || desiredAlignment == ElementAlignment.TopLeft || desiredAlignment == ElementAlignment.BottomLeft))
                {
                    view.Alignment = alignment | desiredAlignment;
                }
                else if (!isHorizontal && (desiredAlignment == ElementAlignment.Left || desiredAlignment == ElementAlignment.Right
                    || desiredAlignment == ElementAlignment.TopLeft || desiredAlignment == ElementAlignment.TopRight))
                {
                    view.Alignment = alignment | desiredAlignment;
                }
                else
                {
                    view.Alignment = alignment;
                }

                // get size of content
                if (!percentageWidth)
                {
                    totalWidth += view.Width;
                    maxWidth = view.Width.Pixels > maxWidth ? view.Width.Pixels : maxWidth;
                }

                if (!percentageHeight)
                {
                    totalHeight += view.Height;
                    maxHeight = view.Height.Pixels > maxHeight ? view.Height.Pixels : maxHeight;
                }

                // update child layout
                view.UpdateLayout(false);
                ++childIndex;
                view.DisableLayoutUpdate = defaultDisableChildLayoutUpdate;
            }

            // set width and height 
            float totalSpacing = childCount > 1 ? (childIndex - 1) * spacing.Pixels : 0f;

            // adjust width to content
            if (!percentageWidth)
            {
                // add margins
                var margin = Margin ?? ElementMargin.Default;
                totalWidth += isHorizontal ? totalSpacing : 0f;
                totalWidth += margin.Left.Pixels + margin.Right.Pixels;
                maxWidth += margin.Left.Pixels + margin.Right.Pixels;

                // adjust width to content
                Width = new ElementSize(isHorizontal ? totalWidth : maxWidth, ElementSizeUnit.Pixels);
            }
            else
            {
                Width = new ElementSize(1, ElementSizeUnit.Percents);
            }

            // adjust height to content
            if (!percentageHeight)
            {
                // add margins
                var margin = Margin ?? ElementMargin.Default;
                totalHeight += !isHorizontal ? totalSpacing : 0f;
                totalHeight += margin.Top.Pixels + margin.Bottom.Pixels;
                maxHeight += margin.Top.Pixels + margin.Bottom.Pixels;

                // adjust height to content
                Height = new ElementSize(!isHorizontal ? totalHeight : maxHeight, ElementSizeUnit.Pixels);
            }
            else
            {
                Height = new ElementSize(1, ElementSizeUnit.Percents);
            }

            DisableLayoutUpdate = defaultDisableLayoutUpdate;

            // no need to notify parents if the group doesn't adjusts its size to content
            base.UpdateLayout(notifyParent);
        }

        #endregion
    }
}
