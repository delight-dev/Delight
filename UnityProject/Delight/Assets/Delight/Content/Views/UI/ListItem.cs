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
        #region Methods

        /// <summary>
        /// Called when a child changes its layout.
        /// </summary>
        protected override void ChildLayoutChanged()
        {
            base.ChildLayoutChanged();

            // the layout of the list item need to be updated
            LayoutRoot.RegisterNeedLayoutUpdate(this);
        }

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

                var childWidth = childView.Width ?? ElementSize.Default;
                var childHeight = childView.Height ?? ElementSize.Default;

                // get size of content
                if (childWidth.Unit != ElementSizeUnit.Percents)
                {
                    maxWidth = childView.Width.Pixels > maxWidth ? childWidth.Pixels : maxWidth;
                }

                if (childHeight.Unit != ElementSizeUnit.Percents)
                {
                    maxHeight = childHeight.Pixels > maxHeight ? childView.Height.Pixels : maxHeight;
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

        #endregion
    }
}
