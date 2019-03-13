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
                                
                //UpdateLayout(false);
            }
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
                UpdateContentRegion();
            }
            //LayoutRoot.RegisterNeedLayoutUpdate(this);
        }

        /// <summary>
        /// Updates the size of the content region. 
        /// </summary>
        public void UpdateContentRegion()
        {
            bool hasNewSize = false;

            // the default behavior of the list-item is to adjust its height and width to its content
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
        }

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

            //ContentRegion.RectTransform.anchoredPosition = new Vector2(_contentStartOffset.x + dragDelta.x, _contentStartOffset.y + dragDelta.y);

            if (CanScrollHorizontally)
            {
                ContentRegion.OffsetFromParent.Left.Pixels = _contentStartOffset.x + dragDelta.x; //- RubberDelta(contentPosition.x, _actualWidth);
            }

            if (CanScrollVertically)
            {
                ContentRegion.OffsetFromParent.Top.Pixels = _contentStartOffset.y - dragDelta.y; //- RubberDelta(-contentPosition.y, _actualHeight);
            }
        }

        private static float RubberDelta(float position, float viewSize)
        {
            return (1 - (1 / ((Mathf.Abs(position) * 0.55f / viewSize) + 1))) * viewSize * Mathf.Sign(position);
        }

        public void OnBeginDrag(DependencyObject sender, object eventArgs)
        {
            PointerEventData pointerData = eventArgs as PointerEventData;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(RectTransform, pointerData.position, pointerData.pressEventCamera, out _dragStartPosition);

            if (ContentRegion.OffsetFromParent == null)
                ContentRegion.OffsetFromParent = new ElementMargin();

            _contentStartOffset.x = ContentRegion.OffsetFromParent.Left.Pixels;
            _contentStartOffset.y = ContentRegion.OffsetFromParent.Top.Pixels;

            //_contentStartOffset = ContentRegion.RectTransform.anchoredPosition;

            //Debug.Log("Content start offset = " + _contentStartOffset.x);

            _isDragging = true;
        }

        public void OnEndDrag(DependencyObject sender, object eventArgs)
        {
            _isDragging = false;
        }

        public void OnInitializePotentialDrag(DependencyObject sender, object eventArgs)
        {
            _velocity = Vector2.zero;
        }

        public void OnScroll(DependencyObject sender, object eventArgs)
        {
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

        #endregion

        //private Camera mainCamera;
        //private RectTransform canvasRect;
        //public RectTransform viewport;
        //public RectTransform content;
        //private Rect viewportOld;
        //private Rect contentOld;

        //private List<Vector2> dragCoordinates = new List<Vector2>();
        //private List<float> offsets = new List<float>();
        //private int offsetsAveraged = 4;
        //private float offset;
        //private float velocity = 0;
        //private bool changesMade = false;

        //public float decelration = 0.135f;
        //public float scrollSensitivity;
        //public OnValueChanged onValueChanged;

        //[HideInInspector]
        //public float verticalNormalizedPosition
        //{
        //    get
        //    {
        //        float sizeDelta = CaculateDeltaSize();
        //        if (sizeDelta == 0)
        //        {
        //            return 0;
        //        }
        //        else
        //        {
        //            return 1 - content.transform.localPosition.y / sizeDelta;
        //        }
        //    }
        //    set
        //    {
        //        float o_verticalNormalizedPosition = verticalNormalizedPosition;
        //        float m_verticalNormalizedPosition = Mathf.Max(0, Mathf.Min(1, value));
        //        float maxY = CaculateDeltaSize();
        //        content.transform.localPosition = new Vector3(content.transform.localPosition.x, Mathf.Max(0, (1 - m_verticalNormalizedPosition) * maxY), content.transform.localPosition.z);
        //        float n_verticalNormalizedPosition = verticalNormalizedPosition;
        //        if (o_verticalNormalizedPosition != n_verticalNormalizedPosition)
        //        {
        //            onValueChanged.Invoke();
        //        }
        //    }
        //}

        //private float CaculateDeltaSize()
        //{
        //    return Mathf.Max(0, content.rect.height - viewport.rect.height); ;
        //}


        //private void Awake()
        //{
        //    mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        //    canvasRect = transform.root.GetComponent<RectTransform>();
        //}

        //private Vector2 ConvertEventDataDrag(PointerEventData eventData)
        //{
        //    return new Vector2(eventData.position.x / mainCamera.pixelWidth * canvasRect.rect.width, eventData.position.y / mainCamera.pixelHeight * canvasRect.rect.height);
        //}

        //private Vector2 ConvertEventDataScroll(PointerEventData eventData)
        //{
        //    return new Vector2(eventData.scrollDelta.x / mainCamera.pixelWidth * canvasRect.rect.width, eventData.scrollDelta.y / mainCamera.pixelHeight * canvasRect.rect.height) * scrollSensitivity;
        //}

        //public void OnPointerDown(PointerEventData eventData)
        //{
        //    velocity = 0;
        //    dragCoordinates.Clear();
        //    offsets.Clear();
        //    dragCoordinates.Add(ConvertEventDataDrag(eventData));
        //}

        //public void OnScroll(PointerEventData eventData)
        //{
        //    UpdateOffsetsScroll(ConvertEventDataScroll(eventData));
        //    OffsetContent(offsets[offsets.Count - 1]);
        //}

        //public void OnDrag(PointerEventData eventData)
        //{
        //    dragCoordinates.Add(ConvertEventDataDrag(eventData));
        //    UpdateOffsetsDrag();
        //    OffsetContent(offsets[offsets.Count - 1]);
        //}

        //public void OnPointerUp(PointerEventData eventData)
        //{
        //    dragCoordinates.Add(ConvertEventDataDrag(eventData));
        //    UpdateOffsetsDrag();
        //    OffsetContent(offsets[offsets.Count - 1]);
        //    float totalOffsets = 0;
        //    foreach (float offset in offsets)
        //    {
        //        totalOffsets += offset;
        //    }
        //    velocity = totalOffsets / offsetsAveraged;
        //    dragCoordinates.Clear();
        //    offsets.Clear();
        //}

        //private void OffsetContent(float givenOffset)
        //{
        //    float newY = Mathf.Max(0, Mathf.Min(CaculateDeltaSize(), content.transform.localPosition.y + givenOffset));
        //    if (content.transform.localPosition.y != newY)
        //    {
        //        content.transform.localPosition = new Vector3(content.transform.localPosition.x, newY, content.transform.localPosition.z);
        //    }
        //    onValueChanged.Invoke();
        //}

        //private void UpdateOffsetsDrag()
        //{
        //    offsets.Add(dragCoordinates[dragCoordinates.Count - 1].y - dragCoordinates[dragCoordinates.Count - 2].y);
        //    if (offsets.Count > offsetsAveraged)
        //    {
        //        offsets.RemoveAt(0);
        //    }
        //}

        //private void UpdateOffsetsScroll(Vector2 givenScrollDelta)
        //{
        //    offsets.Add(givenScrollDelta.y);
        //    if (offsets.Count > offsetsAveraged)
        //    {
        //        offsets.RemoveAt(0);
        //    }
        //}

        //private void LateUpdate()
        //{
        //    if (viewport.rect != viewportOld)
        //    {
        //        changesMade = true;
        //        viewportOld = new Rect(viewport.rect);
        //    }
        //    if (content.rect != contentOld)
        //    {
        //        changesMade = true;
        //        contentOld = new Rect(content.rect);
        //    }
        //    if (velocity != 0)
        //    {
        //        changesMade = true;
        //        velocity = (velocity / Mathf.Abs(velocity)) * Mathf.FloorToInt(Mathf.Abs(velocity) * (1 - decelration));
        //        offset = velocity;
        //    }
        //    if (changesMade)
        //    {
        //        OffsetContent(offset);
        //        changesMade = false;
        //        offset = 0;
        //    }
        //}

    }
}
