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
    /// A scrollbar with a draggable handle. Used by the ScrollableRegion view. 
    /// </summary>
    public partial class Scrollbar
    {
        /// <summary>
        /// Called when a property has been changed. 
        /// </summary>
        public override void OnChanged(string property)
        {
            base.OnChanged(property);
            switch (property)
            {
                case nameof(Breadth):
                case nameof(Length):
                    UpdateLayout(true);
                    break;

                case nameof(Orientation):
                case nameof(Alignment):
                    UpdateLayout(false);
                    break;

                case nameof(ViewportRatio):
                case nameof(ScrollPosition):
                    SetScrollPosition(ScrollPosition, ViewportRatio);
                    break;
            }
        }

        public override void Ignore()
        {
            base.Ignore();
            Bar.Ignore();
            Handle.Ignore();
        }

        /// <summary>
        /// Updates the layout of the scrollbar. 
        /// </summary>
        public override bool UpdateLayout(bool notifyParent = true)
        {
            bool defaultDisableLayoutUpdate = DisableLayoutUpdate;
            DisableLayoutUpdate = true;

            // set properties based on orientation of scrollbar
            if (AlignmentProperty.IsUndefined(this))
            {
                Alignment = Orientation == ElementOrientation.Horizontal ? ElementAlignment.Bottom : ElementAlignment.Right;
            }

            if (WidthProperty.IsUndefined(this))
            {                
                OverrideWidth = Orientation == ElementOrientation.Horizontal ? Length : Breadth;
            }

            if (HeightProperty.IsUndefined(this))
            {
                OverrideHeight = Orientation == ElementOrientation.Horizontal ? Breadth : Length;
            }

            if (Orientation == ElementOrientation.Horizontal)
            {
                Handle.Alignment = ElementAlignment.Left;
            }
            else
            {
                Handle.Alignment = ElementAlignment.Top;
            }

            DisableLayoutUpdate = defaultDisableLayoutUpdate;
            return base.UpdateLayout(notifyParent);
        }

        /// <summary>
        /// Sets scroll position. 
        /// </summary>
        public void SetScrollPosition(float position, float? viewportRatio = null)
        {
            ScrollPositionProperty.SetValue(this, position, false);

            if (float.IsNaN(position))
                position = 0;

            position = Mathf.Clamp(position, 0, 1);
            if (viewportRatio.HasValue)
            {
                float ratio = Mathf.Clamp(viewportRatio.Value, 0, 1);
                ViewportRatioProperty.SetValue(this, ratio, false);
            }

            Handle.DisableLayoutUpdate = true;
            if (Handle.OffsetFromParent == null)
                Handle.OffsetFromParent = new ElementMargin();

            // calculate handle position
            if (Orientation == ElementOrientation.Horizontal)
            {
                float totalLength = Bar.ActualWidth;
                float handleLength = totalLength * ViewportRatio;
                float scrollLength = Math.Max(0, totalLength - handleLength);

                Handle.Width = handleLength;
                Handle.OffsetFromParent.Left = position * scrollLength;                
            }
            else
            {
                float totalLength = Bar.ActualHeight;
                float handleLength = totalLength * ViewportRatio;
                float scrollLength = Math.Max(0, totalLength - handleLength);
                
                Handle.Height = handleLength;
                Handle.OffsetFromParent.Top = position * scrollLength;
            }
            Handle.DisableLayoutUpdate = false;
            Handle.UpdateLayout(false);
        }
    }
}
