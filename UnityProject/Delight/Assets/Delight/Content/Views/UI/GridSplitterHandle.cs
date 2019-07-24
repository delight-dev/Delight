#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
#endregion

namespace Delight
{
    /// <summary>
    /// Handle used to resize a rows or column in the Grid view. Created and managed by the GridSplitter view.
    /// </summary>
    public partial class GridSplitterHandle
    {
        #region Fields

        public Region ParentRegion;
        public LayoutGrid ParentGrid;
        public int Index;
        public bool IsColumnSplitter;
        public bool SetSizeOnDragEnded;
        public bool BePushy;

        private bool _offsetChangedFromStartPosition;
        private Vector2 _dragStartPosition;
        private Vector2 _splitterHandleStartOffset;
        private Vector2 _startSize;

        #endregion

        #region Methods

        /// <summary>
        /// Called after the view has been loaded.
        /// </summary>
        protected override void AfterLoad()
        {
            base.AfterLoad();
        }

        /// <summary>
        /// Called when the content is dragged.
        /// </summary>
        public void OnDrag(DependencyObject sender, PointerEventData pointerData)
        {
            if (!IsEnabled)
                return;

            _offsetChangedFromStartPosition = true;

            // adjust splitter handle offset
            Vector2 dragPosition;
            if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(ParentGrid.RectTransform, pointerData.position, pointerData.pressEventCamera, out dragPosition))
                return;
            var dragDelta = dragPosition - _dragStartPosition;

            if (SetSizeOnDragEnded)
            {                
                // TODO check if grid can be resized if not stay

                Vector2 contentOffset = new Vector2(_splitterHandleStartOffset.x + dragDelta.x, _splitterHandleStartOffset.y - dragDelta.y);
                contentOffset = GetClampedHandleOffset(contentOffset);

                SetHandleOffset(contentOffset);
            }
            else
            {
                // resize grid
                if (IsColumnSplitter)
                {
                    ParentGrid.ResizeColumn(Index, new ElementSize(_startSize.x + dragDelta.x), BePushy);
                }
                else
                {
                    ParentGrid.ResizeRow(Index, new ElementSize(_startSize.y - dragDelta.y), BePushy);
                }
            }
        }

        /// <summary>
        /// Called when the content is starting to be dragged.
        /// </summary>
        public void OnBeginDrag(DependencyObject sender, PointerEventData pointerData)
        {
            if (!IsEnabled)
                return;

            RectTransformUtility.ScreenPointToLocalPointInRectangle(ParentGrid.RectTransform, pointerData.position, pointerData.pressEventCamera, out _dragStartPosition);

            _splitterHandleStartOffset = GetHandleOffset();
            _startSize = new Vector2(ParentRegion.ActualWidth, ParentRegion.ActualHeight);
        }

        /// <summary>
        /// Called when the content is stopped being dragged.
        /// </summary>
        public void OnEndDrag(DependencyObject sender, PointerEventData pointerData)
        {
            if (!IsEnabled)
                return;

            if (SetSizeOnDragEnded && _offsetChangedFromStartPosition)
            {
                // resize grid
                Vector2 dragPosition;
                if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(ParentGrid.RectTransform, pointerData.position, pointerData.pressEventCamera, out dragPosition))
                    return;
                var dragDelta = dragPosition - _dragStartPosition;

                SetHandleOffset(_splitterHandleStartOffset);

                if (IsColumnSplitter)
                {
                    ParentGrid.ResizeColumn(Index, new ElementSize(_startSize.x + dragDelta.x), BePushy);
                }
                else
                {
                    ParentGrid.ResizeRow(Index, new ElementSize(_startSize.y - dragDelta.y), BePushy);
                }
            }
        }

        /// <summary>
        /// Called when the content is potentially started to be dragged.
        /// </summary>
        public void OnInitializePotentialDrag(DependencyObject sender, object eventArgs)
        {
        }

        /// <summary>
        /// Gets current handle offset as vector.
        /// </summary>
        public Vector2 GetHandleOffset()
        {
            if (OffsetFromParent == null)
                OffsetFromParent = new ElementMargin();

            return new Vector2(OffsetFromParent.Left.Pixels,
                OffsetFromParent.Top.Pixels);
        }

        /// <summary>
        /// Gets offset clamped to bounds.
        /// </summary>
        public Vector2 GetClampedHandleOffset(Vector2 offset)
        {
            return offset;

            //Vector2 clampedOffset = offset;
            //Vector2 min, max;
            //GetBounds(out min, out max);

            //float cx = ContentRegion.ActualWidth;
            //float cy = ContentRegion.ActualHeight;
            //float vpx = ActualWidth;
            //float vpy = ActualHeight;

            //if (cx < vpx)
            //{
            //    // if content is smaller than viewport we reset x offset to 0
            //    clampedOffset.x = 0;
            //}
            //else
            //{
            //    // clamp x offset to bounds
            //    clampedOffset.x = Mathf.Max(clampedOffset.x, max.x);
            //    clampedOffset.x = Mathf.Min(clampedOffset.x, min.x);
            //}

            //if (cy < vpy)
            //{
            //    // if content is smaller than viewport we reset y offset to 0
            //    clampedOffset.y = 0;
            //}
            //else
            //{
            //    // clamp y offset to bounds
            //    clampedOffset.y = Mathf.Max(clampedOffset.y, max.y);
            //    clampedOffset.y = Mathf.Min(clampedOffset.y, min.y);
            //}

            //return clampedOffset;
        }

        /// <summary>
        /// Sets content offset as vector.
        /// </summary>
        private void SetHandleOffset(Vector2 contentOffset)
        {
            if (OffsetFromParent == null)
                OffsetFromParent = new ElementMargin();

            if (IsColumnSplitter)
            {
                if (OffsetFromParent.Left.Pixels != contentOffset.x)
                {
                    OffsetFromParent.Left.Pixels = contentOffset.x;
                }
            }
            else
            {
                if (OffsetFromParent.Top.Pixels != contentOffset.y)
                {
                    OffsetFromParent.Top.Pixels = contentOffset.y;
                }
            }
        }

        /// <summary>
        /// Called when the mouse enters the view.
        /// </summary>
        public void OnMouseEnter(PointerEventData pointerData)
        {
            //Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        }

        /// <summary>
        /// Called when the mouse exits the view.
        /// </summary>
        public void OnMouseExit(PointerEventData pointerData)
        {
            //Cursor.SetCursor(null, Vector3.zero, CursorMode.Auto);
        }

        #endregion
    }
}
