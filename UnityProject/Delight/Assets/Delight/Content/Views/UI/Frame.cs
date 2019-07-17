#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    /// <summary>
    /// View that resizes itself to its content by default.
    /// </summary>
    public partial class Frame
    {
        #region Fields

        private bool _sizeSet = false;

        #endregion
        
        #region Methods

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
            LayoutRoot.RegisterChangeHandler(OnFrameChildLayoutChanged);
        }

        /// <summary>
        /// Called when the layout of a child has been changed. 
        /// </summary>
        public void OnFrameChildLayoutChanged()
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

            DisableLayoutUpdate = defaultDisableLayoutUpdate;
            return base.UpdateLayout(notifyParent) || hasNewSize;
        }

        /// <summary>
        /// Adjusts the size of the list item to its content. 
        /// </summary>
        private bool AdjustSizeToContent()
        {
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

            return hasNewSize;
        }

        #endregion
    }
}
