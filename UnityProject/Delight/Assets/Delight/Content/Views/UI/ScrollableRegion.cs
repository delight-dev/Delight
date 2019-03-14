#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
#endregion

namespace Delight
{
    // TODO move to separate file
    /// <summary>
    /// Determines how scrolling should be restricted. 
    /// </summary>
    public enum ScrollBounds
    {
        Clamped = 0,
        Elastic = 1,
        None = 2
    }

    /// <summary>
    /// Scrollable region. 
    /// </summary>
    public partial class ScrollableRegion
    {
        #region Fields

        public Vector2 NormalizedPosition;
        public Vector2 AbsolutePosition;
        public float ScrollSensitivity = 60f; // how sensitive the scrolling is to scroll wheel and track pad movement
        public float DisableInteractionScrollDelta; // If set any interaction with child views (clicks, etc) is disabled when the specified amount of pixels has been scrolled. This is used e.g. to disable clicks while scrolling a selectable list of items.
        // determines initial origin position of the scrollable content: TopLeft, Top, etc.
                                                  //public ViewAction NormalizedPostionChanged;


        private float _actualWidth;
        private float _actualHeight;
        private bool _isDragging;
        private bool _hasDisabledInteraction;
        private Vector2 _velocity;
        private Vector2 _dragStartPosition;
        private Vector2 _contentStartOffset;
        private bool _isOutOfBounds;
        //private bool _hasStartedToScroll;

        // so what we need to do is to calculate initial offset of content based on
        // its alignment, viewport size and content size so we need to map this out 
        // how we calculate this offset. And we need to do this when the viewport changes
        // size, and when content changes size - but we don't want to reset it always, 
        // only if it falls outside the bounds, or the user hasn't started to scroll yet.
        // 

        // public int ScrollSensitivity = 1; // I think it's pixels per scrollwheel scroll
        // public bool HasInertia = true; // if false ignore velocity and deceleration
        // public MovementType MovementType = Elastic, Clamped, Unrestricted... not sure unrestricted ever makes sense. 
        // But here we can have maybe looping or infinite scroll... for that to work we need to be able to duplicate
        // content that logic can be handled by parent list. But if we want infinite scroll we want to also be able 
        // to control the scrollbars... we also might want to snap to items when scrolling in list or even just allow
        // to scroll in item increments... all that can be handled by the list above, which means

        // public ScrollbarVisibility HorizontalScrollbarVisibility;
        // public ScrollbarVisibility VerticalScrollbarVisibility;

        // so this view simply needs to notify parents when content is moved

        #endregion

        #region Methods

        /// <summary>
        /// Called once per frame if EnableScriptEvents is true.
        /// </summary>
        public override void Update()
        {
            base.Update();
            if (_actualWidth != ActualWidth || _actualHeight != ActualHeight)
            {
                _actualWidth = ActualWidth;
                _actualHeight = ActualHeight;

                // here we want to clamp offset if necessary 
                if (ContentRegion.OffsetFromParent == null)
                    return;

                Vector2 contentOffset = GetContentOffset();
                if (ScrollBounds != ScrollBounds.None)
                {
                    var clampedContentOffset = GetClampedOffset(contentOffset);
                    if (!clampedContentOffset.Equals(contentOffset))
                    {
                        if (CanScrollHorizontally)
                        {
                            ContentRegion.OffsetFromParent.Left.Pixels = clampedContentOffset.x;
                        }

                        if (CanScrollVertically)
                        {
                            ContentRegion.OffsetFromParent.Top.Pixels = clampedContentOffset.y;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets offset clamped to bounds.
        /// </summary>
        public Vector2 GetClampedOffset(Vector2 offset)
        {
            Vector2 clampedOffset = offset;
            Vector2 min, max;
            GetBounds(out min, out max);

            float cx = ContentRegion.ActualWidth;
            float cy = ContentRegion.ActualHeight;
            float vpx = ActualWidth;
            float vpy = ActualHeight;

            if (cx < vpx)
            {
                // if content is smaller than viewport we reset x offset to 0
                clampedOffset.x = 0;
            }
            else
            {
                // clamp x offset to bounds
                clampedOffset.x = Mathf.Max(clampedOffset.x, max.x);
                clampedOffset.x = Mathf.Min(clampedOffset.x, min.x);
            }

            if (cy < vpy)
            {
                // if content is smaller than viewport we reset y offset to 0
                clampedOffset.y = 0;
            }
            else
            {
                // clamp y offset to bounds
                clampedOffset.y = Mathf.Max(clampedOffset.y, max.y);
                clampedOffset.y = Mathf.Min(clampedOffset.y, min.y);
            }

            return clampedOffset;
        }

        /// <summary>
        /// Get bounds. 
        /// </summary>
        public void GetBounds(out Vector2 min, out Vector2 max)
        {
            float cx = ContentRegion.ActualWidth;
            float cy = ContentRegion.ActualHeight;
            float vpx = ActualWidth;
            float vpy = ActualHeight;

            float maxX = vpx - cx;
            float maxY = vpy - cy;
            float minX = 0;
            float minY = 0;
            float halfMaxX = maxX / 2f;
            float halfMaxY = maxY / 2f;

            // adjust min/max offset depending on content alignment
            switch (ContentAlignment)
            {
                case ElementAlignment.TopLeft:
                    break;

                case ElementAlignment.Top:
                    minX = -halfMaxX;
                    maxX = halfMaxX;
                    break;

                case ElementAlignment.TopRight:
                    minX = -maxX;
                    maxX = 0;
                    break;

                case ElementAlignment.Left:
                    minY = -halfMaxY;
                    maxY = halfMaxY;
                    break;

                case ElementAlignment.Center:
                    minX = -halfMaxX;
                    maxX = halfMaxX;
                    minY = -halfMaxY;
                    maxY = halfMaxY;
                    break;

                case ElementAlignment.Right:
                    minX = -maxX;
                    maxX = 0;
                    minY = -halfMaxY;
                    maxY = halfMaxY;
                    break;

                case ElementAlignment.BottomLeft:
                    minY = -maxY;
                    maxY = 0;
                    break;

                case ElementAlignment.Bottom:
                    minX = -halfMaxX;
                    maxX = halfMaxX;
                    minY = -maxY;
                    maxY = 0;
                    break;

                case ElementAlignment.BottomRight:
                    minX = -maxX;
                    maxX = 0;
                    minY = -maxY;
                    maxY = 0;
                    break;
            }

            min = new Vector2(minX, minY);
            max = new Vector2(maxX, maxY);
        }

        /// <summary>
        /// Called when a child changes its layout.
        /// </summary>
        protected override void ChildLayoutChanged()
        {
            base.ChildLayoutChanged();
            if (AutoSizeContentRegion)
            {
                // update size and layout of the content region if necessary
                LayoutRoot.RegisterChangeHandler(AdjustContentRegionSizeToChildren);
            }
        }

        /// <summary>
        /// Updates the size of the content region. 
        /// </summary>
        public void AdjustContentRegionSizeToChildren()
        {
            bool hasNewSize = false;

            // the default behavior of the scrollable region is to adjust its height and width to its content
            float maxWidth = 0f;
            float maxHeight = 0f;
            int childCount = ContentRegion.LayoutChildren.Count;

            // get size of content and set content offsets and alignment
            for (int i = 0; i < childCount; ++i)
            {
                var childView = ContentRegion.LayoutChildren[i] as UIView;
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

            bool defaultContentDisableLayoutUpdate = ContentRegion.DisableLayoutUpdate;
            ContentRegion.DisableLayoutUpdate = true;

            // adjust size to content unless it has been set
            var newWidth = new ElementSize(maxWidth);
            if (!newWidth.Equals(ContentRegion.Width))
            {
                ContentRegion.Width = newWidth;
                hasNewSize = true;
            }
            var newHeight = new ElementSize(maxHeight);
            if (!newHeight.Equals(Height))
            {
                ContentRegion.Height = newHeight;
                hasNewSize = true;
            }

            ContentRegion.DisableLayoutUpdate = defaultContentDisableLayoutUpdate;

            if (hasNewSize)
            {
                ContentRegion.UpdateLayout(false);
            }            
        }

        /// <summary>
        /// Called just before the view and its children are loaded.
        /// </summary>
        protected override void BeforeLoad()
        {
            base.BeforeLoad();
            if (IgnoreObject)
                return;

            if (MaskContent)
            {
                Mask = GameObject.AddComponent<UnityEngine.UI.RectMask2D>();
            }            
        }

        /// <summary>
        /// Called after the view and its children has been loaded.
        /// </summary>
        protected override void AfterLoad()
        {
            base.AfterLoad();
            UnblockDragEvents();

            if (AutoSizeContentRegion)
            {
                AdjustContentRegionSizeToChildren();
            }
        }

        /// <summary>
        /// Called when the content is dragged.
        /// </summary>
        public void OnDrag(DependencyObject sender, object eventArgs)
        {
            PointerEventData pointerData = eventArgs as PointerEventData;

            Vector2 dragPosition;
            if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(RectTransform, pointerData.position, pointerData.pressEventCamera, out dragPosition))
                return;

            var dragDelta = dragPosition - _dragStartPosition;
            var contentPosition = new Vector2(dragPosition.x - _contentStartOffset.x,
                -dragPosition.y - _contentStartOffset.y);

            if (ContentRegion.OffsetFromParent == null)
                ContentRegion.OffsetFromParent = new ElementMargin();

            // adjust content offset
            Vector2 contentOffset = new Vector2(_contentStartOffset.x + dragDelta.x, _contentStartOffset.y - dragDelta.y);
            if (ScrollBounds == ScrollBounds.Clamped)
            {
                contentOffset = GetClampedOffset(contentOffset);
            }
            else if (ScrollBounds == ScrollBounds.Elastic)
            {
                contentOffset = GetElasticOffset(contentOffset);
            }

            if (CanScrollHorizontally)
            {
                ContentRegion.OffsetFromParent.Left.Pixels = contentOffset.x;
            }

            if (CanScrollVertically)
            {
                ContentRegion.OffsetFromParent.Top.Pixels = contentOffset.y;
            }
        }

        /// <summary>
        /// Called when the content is starting to be dragged.
        /// </summary>
        public void OnBeginDrag(DependencyObject sender, object eventArgs)
        {
            PointerEventData pointerData = eventArgs as PointerEventData;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(RectTransform, pointerData.position, pointerData.pressEventCamera, out _dragStartPosition);

            _contentStartOffset = GetContentOffset();           
            _isDragging = true;
        }

        /// <summary>
        /// Called when the content is stopped being dragged.
        /// </summary>
        public void OnEndDrag(DependencyObject sender, object eventArgs)
        {
            _isDragging = false;
        }

        /// <summary>
        /// Called when the content is potentially started to be dragged.
        /// </summary>
        public void OnInitializePotentialDrag(DependencyObject sender, object eventArgs)
        {
            _velocity = Vector2.zero;
        }

        /// <summary>
        /// Called when the content is scrolled using mouse wheel or track pad.
        /// </summary>
        public void OnScroll(DependencyObject sender, object eventArgs)
        {
            PointerEventData pointerData = eventArgs as PointerEventData;
            Vector2 delta = pointerData.scrollDelta;

            //delta.y *= -1;
            if (CanScrollVertically && !CanScrollHorizontally)
            {
                if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y))
                    delta.y = delta.x;
                delta.x = 0;
            }
            if (CanScrollHorizontally && !CanScrollVertically)
            {
                if (Mathf.Abs(delta.y) > Mathf.Abs(delta.x))
                    delta.x = delta.y;
                delta.y = 0;
            }

            Vector2 contentOffset = GetContentOffset();
            contentOffset += delta * ScrollSensitivity;
            if (ScrollBounds == ScrollBounds.Clamped)
            {
                contentOffset = GetClampedOffset(contentOffset);
            }

            if (CanScrollHorizontally)
            {
                ContentRegion.OffsetFromParent.Left.Pixels = contentOffset.x;
            }

            if (CanScrollVertically)
            {
                ContentRegion.OffsetFromParent.Top.Pixels = contentOffset.y;
            }
        }

        /// <summary>
        /// Makes it so draggable child views aren't blocking the region from being dragged. 
        /// </summary>
        public void UnblockDragEvents()
        {
            this.ForEach<SceneObjectView>(x => UnblockDragEvents(x));
        }

        /// <summary>
        /// Makes it so a draggable child view isn't blocking the region from being dragged. 
        /// </summary>
        public void UnblockDragEvents(SceneObjectView view)
        {
            if (view.GameObject == null)
                return;

            var eventTrigger = view.GameObject.GetComponent<EventTrigger>();

            if (eventTrigger == null)
                return;

#if UNITY_4_6 || UNITY_5_0
            var triggers = eventTrigger.delegates;
#else
            var triggers = eventTrigger.triggers;
#endif

            if (triggers == null)
                return;

            // check if view has drag event entries
            bool hasDragEntries = false;
            bool hasScrollEntries = false;
            foreach (var entry in triggers)
            {
                if (entry.eventID == EventTriggerType.BeginDrag ||
                    entry.eventID == EventTriggerType.EndDrag ||
                    entry.eventID == EventTriggerType.Drag ||
                    entry.eventID == EventTriggerType.InitializePotentialDrag)
                {
                    hasDragEntries = true;
                }
                else if (entry.eventID == EventTriggerType.Scroll)
                {
                    hasScrollEntries = true;
                }
            }

            // unblock scroll events if the view doesn't handle scrolling
            if (!hasScrollEntries)
            {
                // unblock scroll
                var scrollEntry = new EventTrigger.Entry();
                scrollEntry.eventID = EventTriggerType.Scroll;
                scrollEntry.callback = new EventTrigger.TriggerEvent();
                scrollEntry.callback.AddListener(eventData => OnScroll(this, eventData));
                triggers.Add(scrollEntry);
            }

            // unblock drag events if the view doesn't handle drag events
            if (!hasDragEntries)
            {
                // unblock initialize potential drag 
                var initializePotentialDragEntry = new EventTrigger.Entry();
                initializePotentialDragEntry.eventID = EventTriggerType.InitializePotentialDrag;
                initializePotentialDragEntry.callback = new EventTrigger.TriggerEvent();
                initializePotentialDragEntry.callback.AddListener(eventData => OnInitializePotentialDrag(this, eventData));
                triggers.Add(initializePotentialDragEntry);

                // unblock begin drag
                var beginDragEntry = new EventTrigger.Entry();
                beginDragEntry.eventID = EventTriggerType.BeginDrag;
                beginDragEntry.callback = new EventTrigger.TriggerEvent();
                beginDragEntry.callback.AddListener(eventData => OnBeginDrag(this, eventData));
                triggers.Add(beginDragEntry);

                // drag
                var dragEntry = new EventTrigger.Entry();
                dragEntry.eventID = EventTriggerType.Drag;
                dragEntry.callback = new EventTrigger.TriggerEvent();
                dragEntry.callback.AddListener(eventData => OnDrag(this, eventData));
                triggers.Add(dragEntry);

                // end drag
                var endDragEntry = new EventTrigger.Entry();
                endDragEntry.eventID = EventTriggerType.EndDrag;
                endDragEntry.callback = new EventTrigger.TriggerEvent();
                endDragEntry.callback.AddListener(eventData => OnEndDrag(this, eventData));
                triggers.Add(endDragEntry);
            }

        }

        /// <summary>
        /// Calculate rubber delta.
        /// </summary>
        private static float RubberDelta(float offset, float viewSize)
        {
            return (1.0f - (1.0f / ((offset * 0.55f / viewSize) + 1.0f))) * viewSize;
        }

        private Vector2 GetElasticOffset(Vector2 offset)
        {
            Vector2 min, max;
            GetBounds(out min, out max);
            _isOutOfBounds = false;

            Vector2 elasticOffset = offset;

            // if offset is out of bounds apply rubber band effect
            if (offset.x > min.x)
            {
                _isOutOfBounds = true;
                elasticOffset.x = min.x + RubberDelta(-min.x + offset.x, ActualWidth);
            }

            if (offset.x < max.x)
            {
                _isOutOfBounds = true;
                elasticOffset.x = max.x - RubberDelta(max.x - offset.x, ActualWidth);
            }

            if (offset.y > min.y)
            {
                _isOutOfBounds = true;
                elasticOffset.y = min.y + RubberDelta(-min.y + offset.y, ActualHeight);
            }

            if (offset.y < max.y)
            {
                _isOutOfBounds = true;
                elasticOffset.y = max.y - RubberDelta(max.y - offset.y, ActualHeight);
            }

            return elasticOffset;
        }

        /// <summary>
        /// Gets current content offset as vector.
        /// </summary>
        /// <returns></returns>
        private Vector2 GetContentOffset()
        {
            if (ContentRegion.OffsetFromParent == null)
                ContentRegion.OffsetFromParent = new ElementMargin();

            return new Vector2(ContentRegion.OffsetFromParent.Left.Pixels,
                ContentRegion.OffsetFromParent.Top.Pixels);
        }

        #endregion
    }
}
