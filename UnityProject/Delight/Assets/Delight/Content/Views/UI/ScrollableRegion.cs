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
    /// <summary>
    /// Scrollable region. 
    /// </summary>
    public partial class ScrollableRegion
    {
        #region Fields

        public Vector2 NormalizedPosition;
        public Vector2 AbsolutePosition;
        public float DisableInteractionScrollDelta; 

        private float _actualWidth;
        private float _actualHeight;
        private bool _isDragging;
        private bool _hasDisabledInteraction;
        private Vector2 _velocity;
        private Vector2 _dragStartPosition;
        private Vector2 _contentStartOffset;
        private Vector2 _previousContentOffset;
        private bool _isOutOfBoundsElastic;
        private bool _offsetChangedFromStartPosition;

        #endregion

        #region Methods

        /// <summary>
        /// Called once per frame if EnableScriptEvents is true.
        /// </summary>
        public override void Update()
        {
            base.Update();

            Vector2 contentOffset = GetContentOffset();
            float deltaTime = Time.unscaledDeltaTime;

            //  calculate velocity if dragging and inertia is activated
            if (_isDragging && HasInertia)
            {
                Vector3 newVelocity = (contentOffset - _previousContentOffset) / deltaTime;
                _velocity = Vector3.Lerp(_velocity, newVelocity, deltaTime * 10);
            }

            // calculate inertia and elastic movement
            if (!_isDragging && (_isOutOfBoundsElastic || _velocity != Vector2.zero))
            {
                if (HasInertia)
                {
                    _velocity *= Mathf.Pow(DecelerationRate, deltaTime);
                    if (Mathf.Abs(_velocity.x) < 1)
                        _velocity.x = 0;
                    if (Mathf.Abs(_velocity.y) < 1)
                        _velocity.y = 0;
                    contentOffset += _velocity * deltaTime;

                    // check if content is out of bounds 
                    if (ScrollBounds != ScrollBounds.None && IsOutOfBounds(contentOffset))
                    {
                        if (ScrollBounds == ScrollBounds.Elastic)
                        {
                            _isOutOfBoundsElastic = true;
                        }
                        else if (ScrollBounds == ScrollBounds.Clamped)
                        {
                            var clampedOffset = GetClampedOffset(contentOffset);
                            SetContentOffset(clampedOffset);
                        }
                    }
                    else
                    {
                        _isOutOfBoundsElastic = false;
                        SetContentOffset(contentOffset);
                    }
                    
                }

                if (_isOutOfBoundsElastic)
                {
                    var elasticOffset = GetElasticOffset(contentOffset, true);
                    SetContentOffset(elasticOffset);
                }
            }

            // has the size of the scrollable region changed?
            if (_actualWidth != ActualWidth || _actualHeight != ActualHeight)
            {
                // yes. adjust content region to bounds
                _actualWidth = ActualWidth;
                _actualHeight = ActualHeight;

                if (_offsetChangedFromStartPosition)
                {
                    if (ScrollBounds != ScrollBounds.None)
                    {
                        // stop movement
                        _velocity = Vector2.zero;

                        // clamp offset
                        var clampedContentOffset = GetClampedOffset(contentOffset);
                        if (!clampedContentOffset.Equals(contentOffset))
                        {
                            SetContentOffset(clampedContentOffset);
                        }
                    }
                }
            }

            _previousContentOffset = contentOffset;
        }

        /// <summary>
        /// Returns true if content offset is out of bounds.
        /// </summary>
        private bool IsOutOfBounds(Vector2 offset)
        {
            Vector2 min, max;
            GetBounds(out min, out max);

            float cx = ContentRegion.ActualWidth;
            float cy = ContentRegion.ActualHeight;
            float vpx = ActualWidth;
            float vpy = ActualHeight;

            // adjust min/max if content is smaller than viewport
            if (cx < vpx)
            {
                min.x = 0;
                max.x = 0;
            }

            if (cy < vpy)
            {
                min.y = 0;
                max.y = 0;
            }

            return (offset.x > min.x) || (offset.x < max.x) || (offset.y > min.y) || (offset.y < max.y);
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
        /// Sets view to be ignored (must be called before load). Ignored objects are disabled/ignored in the object hierarchy (but their children aren't).
        /// </summary>
        public override void Ignore()
        {
            base.Ignore();
            ContentRegion.IgnoreObject = true;
            HorizontalScrollbar.Ignore();
            VerticalScrollbar.Ignore();
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

            if (!CanScrollHorizontally || HorizontalScrollbarVisibility == ScrollbarVisibilityMode.Never)
            {
                HorizontalScrollbar.Ignore();
            }

            if (!CanScrollVertically || HorizontalScrollbarVisibility == ScrollbarVisibilityMode.Never)
            {
                VerticalScrollbar.Ignore();
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

            _offsetChangedFromStartPosition = true;

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

            SetContentOffset(contentOffset);            
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
            else if (ScrollBounds == ScrollBounds.Elastic && IsOutOfBounds(contentOffset))
            {
                _isOutOfBoundsElastic = true;
            }

            _offsetChangedFromStartPosition = true;
            SetContentOffset(contentOffset);
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
        /// Gets elastic offset.
        /// </summary>
        private Vector2 GetElasticOffset(Vector2 offset, bool step = false)
        {
            Vector2 min, max;
            GetBounds(out min, out max);
            _isOutOfBoundsElastic = false;

            Vector2 elasticOffset = offset;

            float cx = ContentRegion.ActualWidth;
            float cy = ContentRegion.ActualHeight;
            float vpx = ActualWidth;
            float vpy = ActualHeight;

            // adjust min/max if content is smaller than viewport
            if (cx < vpx)
            {
                vpx = cx;
                min.x = 0;
                max.x = 0;
            }

            if (cy < vpy)
            {
                vpy = cy;
                min.y = 0;
                max.y = 0;
            }

            float speedX = _velocity.x;
            float speedY = _velocity.y;            

            // if offset is out of bounds apply rubber band effect
            if (offset.x > min.x)
            {
                _isOutOfBoundsElastic = true;
                if (step)
                {
                    elasticOffset.x = Mathf.SmoothDamp(offset.x, min.x, ref speedX, Elasticity, Mathf.Infinity, Time.unscaledDeltaTime);
                }
                else
                {
                    elasticOffset.x = min.x + RubberDelta(-min.x + offset.x, vpx);
                }
            }

            if (offset.x < max.x)
            {
                _isOutOfBoundsElastic = true;
                if (step)
                {
                    elasticOffset.x = Mathf.SmoothDamp(offset.x, max.x, ref speedX, Elasticity, Mathf.Infinity, Time.unscaledDeltaTime);
                }
                else
                {
                    elasticOffset.x = max.x - RubberDelta(max.x - offset.x, vpx);
                }
            }

            if (offset.y > min.y)
            {
                _isOutOfBoundsElastic = true;
                if (step)
                {
                    elasticOffset.y = Mathf.SmoothDamp(offset.y, min.y, ref speedY, Elasticity, Mathf.Infinity, Time.unscaledDeltaTime);
                }
                else
                {
                    elasticOffset.y = min.y + RubberDelta(-min.y + offset.y, vpy);
                }
            }

            if (offset.y < max.y)
            {
                _isOutOfBoundsElastic = true;
                if (step)
                {
                    elasticOffset.y = Mathf.SmoothDamp(offset.y, max.y, ref speedY, Elasticity, Mathf.Infinity, Time.unscaledDeltaTime);
                }
                else
                {
                    elasticOffset.y = max.y - RubberDelta(max.y - offset.y, vpy);
                }
            }

            if (step)
            {
                _velocity.x = Mathf.Abs(speedX) < 1 ? 0 : speedX;
                _velocity.y = Mathf.Abs(speedY) < 1 ? 0 : speedY;
            }

            return elasticOffset;
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

        /// <summary>
        /// Gets current content offset as vector.
        /// </summary>
        private Vector2 GetContentOffset()
        {
            if (ContentRegion.OffsetFromParent == null)
                ContentRegion.OffsetFromParent = new ElementMargin();

            return new Vector2(ContentRegion.OffsetFromParent.Left.Pixels,
                ContentRegion.OffsetFromParent.Top.Pixels);
        }

        /// <summary>
        /// Sets content offset as vector.
        /// </summary>
        private void SetContentOffset(Vector2 contentOffset)
        {
            if (ContentRegion.OffsetFromParent == null)
                ContentRegion.OffsetFromParent = new ElementMargin();

            if (CanScrollHorizontally)
                ContentRegion.OffsetFromParent.Left.Pixels = contentOffset.x;

            if (CanScrollVertically)
                ContentRegion.OffsetFromParent.Top.Pixels = contentOffset.y;
        }

        #endregion
    }
}
