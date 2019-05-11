#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class Scrollbar : UIView
    {
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

        protected override void AfterLoad()
        {
            base.AfterLoad();
            if (IgnoreObject)
                return;

            // set properties based on orientation of scrollbar
            if (AlignmentProperty.IsUndefined(this))
            {
                Alignment = Orientation == ElementOrientation.Horizontal ? ElementAlignment.Bottom : ElementAlignment.Right;
            }

            if (WidthProperty.IsUndefined(this))
            {
                Width = Orientation == ElementOrientation.Horizontal ? Length : Breadth;
            }

            if (HeightProperty.IsUndefined(this))
            {
                Height = Orientation == ElementOrientation.Horizontal ? Breadth : Length;
            }

            if (Orientation == ElementOrientation.Horizontal)
            {
                Handle.Alignment = ElementAlignment.Left;
            }
            else
            {
                Handle.Alignment = ElementAlignment.Top;
            }
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
        }
    }
}
