#region Using Statements
using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using System.Net;
#endregion

namespace Delight
{
    /// <summary>
    /// The list presents a static or dynamic list of items. The list can be set to be scrollable through the IsScrollable property. items can be made selectable. Items can be arranged vertically or horizontally. The items can overflow or be wrapped to create flowing lists.
    /// </summary>
    public partial class List
    {
        #region Fields

        private BindableObject _selectedItem;
        private BindableCollection _oldCollection;
        private Dictionary<BindableObject, ListItem> _presentedItems = new Dictionary<BindableObject, ListItem>();

        // for virtualized list
        private Dictionary<BindableObject, int> _indexOfItem;
        private Dictionary<ContentTemplate, VirtualItem> _contentTemplateVirtualItem;
        private Dictionary<ContentTemplate, List<ListItem>> _realizedItemPool;
        private List<VirtualItem> _virtualItems;

        // for paged lists
        private NavigationButton _nextButton;
        private NavigationButton _previousButton;
        private Group _pageButtonGroup;
        private ContentTemplate _pageButtonTemplate;

        #endregion

        #region Methods

        /// <summary>
        /// Called when a property has been changed. 
        /// </summary>
        public override void OnChanged(string property)
        {
            base.OnChanged(property);
            switch (property)
            {
                case nameof(SelectedItem):
                    if (_selectedItem != SelectedItem)
                    {
                        SelectItem(SelectedItem);
                    }
                    break;

                case nameof(Orientation):
                    if (IsLoaded)
                    {
                        ClearItems();
                        CreateItems();
                    }
                    break;

                case nameof(Items):
                    ItemsChanged();
                    break;

                case nameof(PageIndex):
                    PageIndexChanged();
                    break;
            }
        }

        /// <summary>
        /// Called when the page index has been changed.
        /// </summary>
        private void PageIndexChanged()
        {
            if (IsPaged)
            {
                UpdateLayout(false);
            }
        }

        /// <summary>
        /// Generates views from data in collection. 
        /// </summary>
        protected void CreateItems()
        {
            if (Items == null)
                return;

            // call to initialize dynamic lists if necessary
#pragma warning disable CS4014
            Items.LoadData();
#pragma warning restore CS4014
            foreach (var item in Items)
            {
                CreateListItem(item);
            }

            // update layout and notify parents if size has changed
            if (UpdateLayout(false))
            {
                NotifyParentOfChildLayoutChanged();
            }
        }

        /// <summary>
        /// Called during initialization. 
        /// </summary>
        public override void AfterInitialize()
        {
            base.AfterInitialize();

            if (IsVirtualized)
            {
                _indexOfItem = new Dictionary<BindableObject, int>();
                _virtualItems = new List<VirtualItem>();
                _realizedItemPool = new Dictionary<ContentTemplate, List<ListItem>>();
                IsScrollable = true; // virtualized lists are always scrollable

                ScrollableRegion.ContentScrolled.RegisterHandler(this, "ContentScrolled");
            }

            if (IsPaged)
            {
                if (!IsScrollable)
                {
                    // paged views are made scrollable so the items are put inside scrollable content and the buttons can reside outside
                    // not interfering with list logic
                    ScrollableRegion.ScrollBounds = ScrollBounds.Clamped;
                    ScrollableRegion.HorizontalScrollbarVisibility = ScrollbarVisibilityMode.Remove;
                    ScrollableRegion.VerticalScrollbarVisibility = ScrollbarVisibilityMode.Remove;
                    IsScrollable = true;
                }
            }
        }

        /// <summary>
        /// Creates navigation buttons
        /// </summary>
        protected void CreateNavigationButtons()
        {
            if (ContentTemplates == null)
                return;

            if (ShowNavigationButtons == NavigationButtonsVisibility.None)
                return;

            bool showNextPrevious = ShowNavigationButtons == NavigationButtonsVisibility.All || ShowNavigationButtons == NavigationButtonsVisibility.NextPrevious;
            bool showPage = ShowNavigationButtons == NavigationButtonsVisibility.All || ShowNavigationButtons == NavigationButtonsVisibility.Page;

            foreach (var contentTemplate in ContentTemplates)
            {
                if (!typeof(NavigationButton).IsAssignableFrom(contentTemplate.TemplateType))
                    continue;

                var templateData = new ContentTemplateData();
                var button = contentTemplate.Activator(templateData) as NavigationButton;
                switch (button.NavigationType)
                {
                    case NavigationButtonType.NextAndPrevious:
                        if (!showNextPrevious)
                        {
                            button.Destroy();
                            break;
                        }

                        if (_nextButton != null)
                        {
                            _nextButton.Destroy();
                        }
                        if (_previousButton != null)
                        {
                            _previousButton.Destroy();
                        }
                        _nextButton = button;
                        _previousButton = contentTemplate.Activator(templateData) as NavigationButton;

                        // mirror previous navigation button
                        _previousButton.Scale = new Vector3(-1, 1, 1);
                        if (_previousButton.Offset != null)
                        {
                            _previousButton.Offset = _previousButton.Offset != null ? new ElementMargin(_previousButton.Offset.Right, _previousButton.Offset.Top, _previousButton.Offset.Left, _previousButton.Offset.Bottom) : null;
                        }
                        break;

                    case NavigationButtonType.Next:
                        if (!showNextPrevious)
                        {
                            button.Destroy();
                            break;
                        }

                        if (_nextButton != null)
                        {
                            _nextButton.Destroy();
                        }
                        _nextButton = button;
                        break;

                    case NavigationButtonType.Previous:
                        if (!showNextPrevious)
                        {
                            button.Destroy();
                            break;
                        }

                        if (_previousButton != null)
                        {
                            _previousButton.Destroy();
                        }
                        _previousButton = button;
                        break;

                    case NavigationButtonType.Page:
                        if (!showPage)
                        {
                            button.Destroy();
                            break;
                        }

                        _pageButtonTemplate = contentTemplate;
                        button.Destroy();
                        break;
                }
            }

            if (showNextPrevious)
            {
                bool defaultText = false;
                if (_nextButton == null)
                {
                    _nextButton = new NavigationButton(this, Content);
                    _nextButton.Offset = new ElementMargin(40, 0, 0, 0);
                    _nextButton.Text = ">";
                    _nextButton.DisplayLabel = true;
                    defaultText = true;
                }

                _nextButton.Alignment = ElementAlignment.Right;
                _nextButton.NavigationType = NavigationButtonType.Next;
                _nextButton.ParentList = this;
                _nextButton.IsDynamic = true;
                _nextButton.MoveTo(this);
                _nextButton.Load();

                if (defaultText)
                {
                    _nextButton.Text = ">";
                }

                defaultText = false;
                if (_previousButton == null)
                {
                    _previousButton = new NavigationButton(this, Content);
                    _previousButton.Offset = new ElementMargin(0, 0, 40, 0);
                    _previousButton.DisplayLabel = true;
                    _previousButton.Scale = new Vector3(-1, 1, 1);
                    defaultText = true;
                }

                _previousButton.Alignment = ElementAlignment.Left;
                _previousButton.NavigationType = NavigationButtonType.Previous;
                _previousButton.ParentList = this;
                _previousButton.IsDynamic = true;
                _previousButton.MoveTo(this);
                _previousButton.Load();

                if (defaultText)
                {
                    _previousButton.Text = ">";
                }
            }

            if (showPage)
            {
                // create page buttons group
                _pageButtonGroup = new Group(this, this, "PageButtonsGroup");
                _pageButtonGroup.Alignment = PageNavigationGroupAlignment;
                _pageButtonGroup.Orientation = PageNavigationGroupOrientation;
                _pageButtonGroup.Offset = PageNavigationGroupOffset;
                _pageButtonGroup.Spacing = PageNavigationGroupSpacing;
                _pageButtonGroup.IsDynamic = true;
                _pageButtonGroup.Load();
            }
        }

        /// <summary>
        /// Called for virtualized lists to update the realized items.
        /// </summary>
        public void ContentScrolled()
        {
            UpdateRealizedItems();
        }

        /// <summary>
        /// Called after the view and its children has been loaded.
        /// </summary>
        protected override void AfterLoad()
        {
            base.AfterLoad();

            if (IsStaticProperty.IsUndefined(this) && ItemsProperty.IsUndefined(this))
            {
                // if items property isn't defined (no value or binding) assume list is meant to be static
                IsStatic = true;
            }

            if (IsPaged)
            {
                CreateNavigationButtons();
            }

            if (IsStatic)
            {
                IsVirtualized = false; // static list can't be virtualized
                CreateStaticListItems();
                return;
            }
            else
            {
                ItemsChanged();
            }
        }

        /// <summary>
        /// Called when the view has been unloaded.
        /// </summary>
        protected override void AfterUnload()
        {
            base.AfterUnload();
            if (Items != null)
            {
                // unsubscribe to change events in the old list
                Items.CollectionChanged -= OnCollectionChanged;
            }

            _presentedItems.Clear();
            if (IsVirtualized)
            {
                _virtualItems.Clear();
                _indexOfItem.Clear();
                _realizedItemPool.Clear();
            }
        }

        /// <summary>
        /// Called when the list of items has been changed.
        /// </summary>
        private void OnCollectionChanged(object sender, CollectionChangedEventArgs e)
        {
            if (!IsLoaded)
                return;

            // Debug.Log("Collection changed");
            bool updateLayout = false;
            if (e.ChangeAction == CollectionChangeAction.Batch)
            {
                var eventArgsBatch = (e as BatchedCollectionChangedEventArgs).CollectionChangedEventArgsBatch;
                foreach (var eventArgs in eventArgsBatch)
                {
                    updateLayout |= OnCollectionChanged(eventArgs);
                }
            }
            else
            {
                updateLayout = OnCollectionChanged(e);
            }

            if (updateLayout)
            {
                // update layout and notify parents if size has changed
                if (UpdateLayout(false))
                {
                    NotifyParentOfChildLayoutChanged();
                }
            }
        }

        /// <summary>
        /// Handles collection changed events.
        /// </summary>
        private bool OnCollectionChanged(CollectionChangedEventArgs e)
        {
            bool updateLayout = false;
            switch (e.ChangeAction)
            {
                case CollectionChangeAction.AddRange:
                    var rangeArgs = e as CollectionChangedRangeEventArgs;
                    foreach (var item in rangeArgs.Items)
                    {
                        CreateListItem(item);
                    }
                    updateLayout = true;
                    break;

                case CollectionChangeAction.Add:
                    CreateListItem(e.Item);
                    updateLayout = true;
                    break;

                case CollectionChangeAction.Remove:
                    DestroyItem(e.Item);
                    updateLayout = true;
                    break;

                case CollectionChangeAction.Replace:
                    ReplaceItems();
                    updateLayout = true;
                    break;

                case CollectionChangeAction.Clear:
                    ClearItems();
                    updateLayout = true;
                    break;

                case CollectionChangeAction.Select:
                    var selectArgs = e as CollectionSelectionEventArgs;
                    if (selectArgs.ScrollTo)
                    {
                        SelectAndScrollToItem(e.Item, selectArgs.Alignment, selectArgs.Offset);
                    }
                    else
                    {
                        SelectItem(e.Item, true);
                    }
                    break;

                case CollectionChangeAction.ScrollTo:
                    var scrollArgs = e as CollectionSelectionEventArgs;
                    ScrollTo(e.Item, scrollArgs.Alignment, scrollArgs.Offset);
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }

            return updateLayout;
        }

        /// <summary>
        /// Scrolls to specified item.
        /// </summary>
        public void ScrollTo(int index, ElementAlignment? alignment = null, ElementMargin offset = null)
        {
            var item = Items.GetGeneric(index);
            ScrollTo(item, alignment, offset);
        }

        /// <summary>
        /// Gets virtual item from bindable item.
        /// </summary>
        public VirtualItem GetVirtualItem(BindableObject item)
        {
            if (!_indexOfItem.TryGetValue(item, out int index))
                return null;

            return _virtualItems[index];
        }

        /// <summary>
        /// Scrolls to specified item.
        /// </summary>
        public void ScrollTo(BindableObject item, ElementAlignment? alignment = null, ElementMargin offset = null)
        {
            if (!IsScrollable || item == null)
                return;

            ListItem listItem = null;
            VirtualItem virtualItem = null;
            if (!IsVirtualized)
            {
                if (!_presentedItems.TryGetValue(item, out listItem))
                    return;
            }
            else
            {
                virtualItem = GetVirtualItem(item);
                if (virtualItem == null)
                    return;
            }

            if (offset == null)
            {
                offset = new ElementMargin();
            }

            if (ScrollsHorizontally)
            {
                // set horizontal scroll distance
                float viewportWidth = ScrollableRegion.ViewportWidth;
                float scrollRegionWidth = ScrollableRegion.ContentWidth;
                float scrollWidth = scrollRegionWidth - viewportWidth;
                if (scrollWidth <= 0)
                {
                    return;
                }

                // calculate the scroll position based on alignment and offset
                float itemPosition = !IsVirtualized ? listItem.OffsetFromParent.Left.Pixels : virtualItem.Offset.Left.Pixels;
                float itemWidth = !IsVirtualized ? listItem.Width.Pixels : virtualItem.Width.Pixels;
                float scrollOffset = 0;

                if (alignment == null || alignment.Value.HasFlag(ElementAlignment.Right))
                {
                    // scroll so item is the right side of viewport
                    scrollOffset = itemPosition + itemWidth + offset.Left.Pixels + offset.Bottom.Pixels - viewportWidth;
                }
                else if (alignment.Value.HasFlag(ElementAlignment.Top) || alignment.Value.HasFlag(ElementAlignment.Bottom) ||
                    alignment.Value == ElementAlignment.Center)
                {
                    // scroll so item is at center of viewport
                    scrollOffset = itemPosition + itemWidth / 2 + offset.Left.Pixels + offset.Right.Pixels
                        - viewportWidth / 2;
                }
                else
                {
                    // scroll so item is at left side of viewport
                    scrollOffset = itemPosition + offset.Left.Pixels + offset.Right.Pixels;
                }

                ScrollableRegion.SetAbsoluteScrollPosition(scrollOffset, 0);
            }
            else
            {
                // set vertical scroll distance
                float viewportHeight = ScrollableRegion.ViewportHeight;

                // calculate the scroll position based on alignment and offset
                float itemPosition = !IsVirtualized ? listItem.OffsetFromParent.Top.Pixels : virtualItem.Offset.Top.Pixels;
                float itemHeight = !IsVirtualized ? listItem.Height.Pixels : virtualItem.Height.Pixels;
                float scrollOffset = 0;

                if (alignment == null || alignment.Value.HasFlag(ElementAlignment.Bottom))
                {
                    // scroll so item is at bottom of viewport
                    scrollOffset = itemPosition + itemHeight + offset.Top.Pixels + offset.Bottom.Pixels - viewportHeight;

                }
                else if (alignment.Value.HasFlag(ElementAlignment.Left) || alignment.Value.HasFlag(ElementAlignment.Right) ||
                    alignment.Value == ElementAlignment.Center)
                {
                    // scroll so item is at center of viewport
                    scrollOffset = itemPosition + itemHeight / 2 + offset.Top.Pixels + offset.Bottom.Pixels
                        - viewportHeight / 2;
                }
                else
                {
                    // scroll so item is at top of viewport
                    scrollOffset = itemPosition + offset.Top.Pixels + offset.Bottom.Pixels;
                }

                ScrollableRegion.SetAbsoluteScrollPosition(0, scrollOffset);
            }
        }

        /// <summary>
        /// Replaces presented items. 
        /// </summary>
        private void ReplaceItems()
        {
            // deselect all items
            int selectedIndex = GetSelectedItemIndex();
            DeselectAll();

            if (IsVirtualized)
            {
                ClearItems();
                CreateItems();
                return;
            }

            int newItemsCount = Items.Count;
            if (newItemsCount <= 0)
            {
                ClearItems();
                return;
            }

            _presentedItems.Clear();

            // we assume layout sibling index corresponds to item index
            var childCount = Content.LayoutChildren.Count;
            int replaceCount = newItemsCount >= childCount ? childCount : newItemsCount;
            for (int i = 0; i < replaceCount; ++i)
            {
                // replace items
                var listItem = Content.LayoutChildren[i] as ListItem;
                var newItem = Items.GetGeneric(i);
                listItem.Item = newItem;
                if (listItem.ContentTemplateData != null)
                {
                    listItem.ContentTemplateData.Item = newItem;
                }
                _presentedItems.Add(newItem, listItem);
            }

            if (newItemsCount > childCount)
            {
                // old list smaller than new - add items
                for (int i = childCount; i < newItemsCount; ++i)
                {
                    CreateListItem(Items.GetGeneric(i));
                }
            }
            else if (newItemsCount < childCount)
            {
                // old list larger than new - remove items
                for (int i = childCount - 1; i >= newItemsCount; --i)
                {
                    var listItem = Content.LayoutChildren[i];
                    listItem.Unload();
                }
            }

            // reselect item
            if (selectedIndex >= 0 && selectedIndex < newItemsCount)
            {
                SelectItem(selectedIndex);
            }
        }

        /// <summary>
        /// Destroys item in list.
        /// </summary>
        protected virtual void DestroyItem(BindableObject item)
        {
            if (IsVirtualized)
            {
                ClearItems();
                CreateItems();
                return;
            }

            if (!_presentedItems.TryGetValue(item, out var listItem))
                return;

            var index = Content.LayoutChildren.IndexOf(listItem);
            listItem.Unload();
            Content.LayoutChildren.Remove(listItem);
            _presentedItems.Remove(item);

            // update index and IsAlternate on subsequent list items
            for (int i = index; i < Content.LayoutChildren.Count; ++i)
            {
                var subsequentListItem = Content.LayoutChildren[i] as ListItem;
                subsequentListItem.IsAlternate = IsOdd(i);
                subsequentListItem.ContentTemplateData.ZeroIndex = i;
            }
        }

        /// <summary>
        /// Called when the list of items has been replaced.
        /// </summary>
        public virtual void ItemsChanged()
        {
            if (_oldCollection != null)
            {
                // unsubscribe from change events in the old list
                _oldCollection.CollectionChanged -= OnCollectionChanged;
            }
            _oldCollection = Items;

            // add new list
            if (Items != null)
            {
                // subscribe to change events in the new list
                Items.CollectionChanged += OnCollectionChanged;
            }

            // generate new items
            if (IsLoaded)
            {
                ClearItems();
                CreateItems();
            }
        }

        /// <summary>
        /// Clears the list. 
        /// </summary>
        private void ClearItems()
        {
            if (IsVirtualized)
            {
                // unrealize all items
                foreach (var virtualItem in _virtualItems)
                {
                    UnrealizeItem(virtualItem);
                }

                _virtualItems.Clear();
                _indexOfItem.Clear();
                return;
            }

            // unload and clear existing children
            for (int i = Content.LayoutChildren.Count - 1; i >= 0; --i)
            {
                var child = Content.LayoutChildren[i];
                if (IsPaged && child is NavigationButton)
                    continue;

                child.Unload();
            }
            _presentedItems.Clear();
        }

        /// <summary>
        /// Called just before the view and its children are loaded.
        /// </summary>
        protected override void BeforeLoad()
        {
            base.BeforeLoad();

            // if the list isn't scrollable, disable the scrollable region
            if (!IsScrollable)
            {
                ScrollableRegion.Ignore();
            }

            ScrollableRegion.CanScrollHorizontally = ScrollsHorizontally;
            ScrollableRegion.CanScrollVertically = !ScrollsHorizontally;

            if (IsVirtualized && VirtualItemGetter.Method == null)
            {
                // get the default size of each item template
                var templateData = new ContentTemplateData { Item = null };
                _contentTemplateVirtualItem = new Dictionary<ContentTemplate, VirtualItem>();
                foreach (var contentTemplate in ContentTemplates)
                {
                    if (!typeof(ListItem).IsAssignableFrom(contentTemplate.TemplateType))
                        continue;

                    var itemView = contentTemplate.Activator(new ContentTemplateData { Item = null }) as ListItem;
                    if (itemView.Width == null && itemView.Height == null)
                    {
                        // if size not set, try adjust item to content
                        itemView.DisableLayoutUpdate = true;
                        itemView.AdjustSizeToContent();
                        itemView.DisableLayoutUpdate = false;
                    }

                    var itemWidth = itemView.OverrideWidth ?? itemView.Width ?? ElementSize.FromPercents(1);
                    var itemHeight = itemView.OverrideHeight ?? itemView.Height ?? ElementSize.FromPercents(1);
                    _contentTemplateVirtualItem.Add(contentTemplate, new VirtualItem(itemWidth, itemHeight, contentTemplate));
                    itemView.Destroy();
                }
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

            // the layout of the list needs to be updated
            LayoutRoot.RegisterChangeHandler(OnListChildLayoutChanged);
        }

        /// <summary>
        /// Called when the layout of a child has been changed. 
        /// </summary>
        public void OnListChildLayoutChanged()
        {
            if (IsVirtualized)
                return;

            // update layout and notify parents if size has changed
            if (UpdateLayout(false))
            {
                NotifyParentOfChildLayoutChanged();
            }
        }

        /// <summary>
        /// Called when a new dynamic list item is to be generated.
        /// </summary>
        protected void CreateListItem(BindableObject item)
        {
            string templateId = TemplateSelector?.Invoke(item) as string;
            if (IsVirtualized)
            {
                // add virtual item
                VirtualItem virtualItem = null;
                if (VirtualItemGetter.Method != null)
                {
                    virtualItem = VirtualItemGetter.Invoke(item) as VirtualItem;
                }
                else
                {
                    var template = GetContentTemplate(null, templateId);
                    if (template != null)
                    {
                        _contentTemplateVirtualItem.TryGetValue(template, out virtualItem);
                    }
                }

                if (virtualItem != null)
                {
                    var newVirtualItem = new VirtualItem(virtualItem.Width, virtualItem.Height, virtualItem.ContentTemplate);
                    if (newVirtualItem.ContentTemplate == null)
                    {
                        var template = GetContentTemplate(null, templateId);
                        newVirtualItem.ContentTemplate = template;
                    }
                    _virtualItems.Add(newVirtualItem);
                    _indexOfItem.Add(item, _virtualItems.Count - 1);

                    newVirtualItem.Item = item;
                    newVirtualItem.IsAlternate = IsOdd(_virtualItems.Count - 1);
                    newVirtualItem.Index = _virtualItems.Count - 1;
                }
                return;
            }

            var listItem = base.CreateItem(item, null, templateId) as ListItem;
            if (listItem == null)
                return;

            listItem.Load();

            UnblockListItemDragEvents(listItem);

            if (item != null)
            {
                if (!_presentedItems.ContainsKey(item))
                {
                    _presentedItems.Add(item, listItem);
                }

                // set item data on list item for easy reference
                listItem.Item = item;
                listItem.IsAlternate = IsOdd(_presentedItems.Count - 1);
                listItem.ContentTemplateData.ZeroIndex = _presentedItems.Count - 1;
            }
        }

        /// <summary>
        /// Updates the layout of the group. 
        /// </summary>
        public override bool UpdateLayout(bool notifyParent = true)
        {
            bool defaultDisableLayoutUpdate = DisableLayoutUpdate;
            DisableLayoutUpdate = true;

            // update overflowing or wrapped layout
            bool hasNewSize = false;
            if (Overflow == OverflowMode.Overflow)
            {
                hasNewSize = UpdateLayoutOverflow();
            }
            else
            {
                hasNewSize = UpdateLayoutWrapped();
            }

            // update realized items for virtualized lists
            if (IsVirtualized)
            {
                UpdateRealizedItems();
            }

            // update next/previous navigation buttons
            if (IsPaged)
            {
                int maxPageIndex = GetMaxPageIndex();
                if (_nextButton != null && _previousButton != null)
                {
                    _nextButton.IsActive = PageIndex < maxPageIndex;
                    _previousButton.IsActive = PageIndex > 0;
                }

                if (_pageButtonGroup != null)
                {
                    // make sure we have enough page navigation buttons for the list
                    int newPageButtonCount = (maxPageIndex + 1) - _pageButtonGroup.LayoutChildren.Count;
                    for (int i = 0; i < newPageButtonCount; ++i)
                    {
                        NavigationButton newPageButton = null;
                        if (_pageButtonTemplate != null)
                        {
                            var templateData = new ContentTemplateData();
                            newPageButton = _pageButtonTemplate.Activator(templateData) as NavigationButton;
                        }
                        else
                        {
                            newPageButton = new NavigationButton(this, Content);
                            newPageButton.NavigationType = NavigationButtonType.Page;
                        }

                        newPageButton.IsToggleButton = true;
                        newPageButton.CanToggleOff = false;
                        newPageButton.ParentList = this;
                        newPageButton.Label.Width = ElementSize.FromPercents(1); // TODO workaround for bug #18 with derived views not applying parent template correctly
                        newPageButton.Label.Height = ElementSize.FromPercents(1);
                        newPageButton.MoveTo(_pageButtonGroup);
                        newPageButton.Load();
                    }

                    for (int i = 0; i < _pageButtonGroup.LayoutChildren.Count; ++i)
                    {
                        var navigationButton = _pageButtonGroup.LayoutChildren[i] as NavigationButton;
                        if (i > maxPageIndex)
                        {
                            navigationButton.IsActive = false;
                            continue;
                        }

                        navigationButton.IsActive = true;
                        if (navigationButton.DisplayLabel)
                        {
                            navigationButton.Text = (i + 1).ToString();
                        }
                        navigationButton.PageIndex = i;
                        navigationButton.ToggleValue = i == PageIndex;
                    }
                }
            }

            DisableLayoutUpdate = defaultDisableLayoutUpdate;
            return base.UpdateLayout(notifyParent) || hasNewSize;
        }

        /// <summary>
        /// Updates realized items.
        /// </summary>
        private void UpdateRealizedItems()
        {
            foreach (var virtualItem in _virtualItems)
            {
                // see if virtual item is in viewport
                if (!IsVirtualItemInViewport(virtualItem))
                {
                    // if it has a previously realized item add it back to the pool
                    UnrealizeItem(virtualItem);
                    continue;
                }

                RealizeItem(virtualItem);
            }
        }

        /// <summary>
        /// Unrealizes virtual item.
        /// </summary>
        private void UnrealizeItem(VirtualItem virtualItem)
        {
            if (virtualItem.RealizedItem == null)
                return; // item already unrealized

            if (!_realizedItemPool.TryGetValue(virtualItem.ContentTemplate, out var realizedItemPool))
            {
                realizedItemPool = new List<ListItem>();
                _realizedItemPool.Add(virtualItem.ContentTemplate, realizedItemPool);
            }

            realizedItemPool.Add(virtualItem.RealizedItem);
            virtualItem.RealizedItem.SetIsActive(false);
            virtualItem.RealizedItem = null;
        }

        /// <summary>
        /// Realizes virtual item.
        /// </summary>
        private void RealizeItem(VirtualItem virtualItem)
        {
            if (virtualItem.RealizedItem != null)
                return; // item already realized

            // see if a realized item is available from the pool
            ListItem realizedItem = null;
            if (_realizedItemPool.TryGetValue(virtualItem.ContentTemplate, out var realizedItemPool))
            {
                int lastIndex = realizedItemPool.Count - 1;
                if (lastIndex >= 0)
                {
                    realizedItem = realizedItemPool[lastIndex];
                    realizedItemPool.RemoveAt(lastIndex);
                }
            }

            if (realizedItem == null)
            {
                // create new realized item
                realizedItem = CreateRealizedListItem(virtualItem);
            }

            // set size and offset of realized item to match virtual item
            realizedItem.SetIsActive(true);
            realizedItem.Width = virtualItem.Width;
            realizedItem.Height = virtualItem.Height;
            realizedItem.OffsetFromParent = virtualItem.Offset;
            realizedItem.Alignment = virtualItem.Alignment;
            realizedItem.IsSelected = virtualItem.IsSelected;
            realizedItem.Item = virtualItem.Item;
            realizedItem.IsAlternate = virtualItem.IsAlternate;
            if (realizedItem.ContentTemplateData != null)
            {
                realizedItem.ContentTemplateData.Item = virtualItem.Item;
            }
            virtualItem.RealizedItem = realizedItem;
        }

        /// <summary>
        /// Creates new realized list item from virtual item.
        /// </summary>
        protected ListItem CreateRealizedListItem(VirtualItem virtualItem)
        {
            var listItem = virtualItem.ContentTemplate.Activator(new ContentTemplateData { Item = virtualItem.Item, ZeroIndex = virtualItem.Index }) as ListItem;
            if (listItem == null)
                return null;

            listItem.DisableLayoutUpdate = true;
            listItem.Width = virtualItem.Width;
            listItem.Height = virtualItem.Height;
            listItem.OffsetFromParent = virtualItem.Offset;
            listItem.Alignment = virtualItem.Alignment;
            listItem.IsSelected = virtualItem.IsSelected;
            listItem.Item = virtualItem.Item;
            listItem.DisableLayoutUpdate = false;
            listItem.IsAlternate = virtualItem.IsAlternate;

            listItem.Load();

            UnblockListItemDragEvents(listItem);
            listItem.Item = virtualItem.Item;
            return listItem;
        }

        /// <summary>
        /// Returns true if the virtual item is visible in the viewport.
        /// </summary>
        private bool IsVirtualItemInViewport(VirtualItem virtualItem)
        {
            if (IsPaged)
            {
                int itemsPerPage = PageSize > 0 ? PageSize : int.MaxValue;
                int pageIndex = Mathf.FloorToInt(virtualItem.Index / itemsPerPage);
                if (pageIndex != PageIndex)
                {
                    // item not in current page
                    return false;
                }
            }

            var contentOffset = ScrollableRegion.GetContentOffset();
            float vpXMin = 0 - RealizationMargin.x;
            float vpYMin = 0 - RealizationMargin.y;
            float vpXMax = ScrollableRegion.ViewportWidth + RealizationMargin.x;
            float vpYMax = ScrollableRegion.ViewportHeight + RealizationMargin.y;

            if (Overflow == OverflowMode.Wrap)
            {
                // check both axis
                float xMin = (virtualItem.Offset.Left.Pixels) + contentOffset.x;
                float xMax = (virtualItem.Offset.Left.Pixels + virtualItem.Width.Pixels) + contentOffset.x;
                float yMin = (virtualItem.Offset.Top.Pixels) + contentOffset.y;
                float yMax = (virtualItem.Offset.Top.Pixels + virtualItem.Height.Pixels) + contentOffset.y;
                return (xMax >= 0 && xMin <= vpXMax) && (yMax >= 0 && yMin <= vpYMax);
            }
            else
            {
                if (ScrollsHorizontally)
                {
                    float xMin = (virtualItem.Offset.Left.Pixels) + contentOffset.x;
                    float xMax = (virtualItem.Offset.Left.Pixels + virtualItem.Width.Pixels) + contentOffset.x;
                    return xMax >= 0 && xMin <= vpXMax;
                }
                else
                {
                    float yMin = (virtualItem.Offset.Top.Pixels) + contentOffset.y;
                    float yMax = (virtualItem.Offset.Top.Pixels + virtualItem.Height.Pixels) + contentOffset.y;
                    return yMax >= 0 && yMin <= vpYMax;
                }
            }
        }

        /// <summary>
        /// Updates layout in overflowing lists (default).
        /// </summary>
        private bool UpdateLayoutOverflow()
        {
            bool hasNewSize = false;
            float maxWidth = 0f;
            float maxHeight = 0f;
            float totalWidth = 0f;
            float totalHeight = 0f;
            bool percentageWidth = false;
            bool percentageHeight = false;
            bool isHorizontal = Orientation == ElementOrientation.Horizontal;
            int itemsPerPage = IsPaged && PageSize > 0 ? PageSize : int.MaxValue;

            List<UIView> children = null;
            if (!IsVirtualized)
            {
                children = new List<UIView>();
                int itemIndex = 0;
                Content.ForEach<UIView>(x =>
                {
                    if (IsPaged)
                    {
                        int pageIndex = Mathf.FloorToInt(itemIndex / itemsPerPage);
                        x.IsActive = pageIndex == PageIndex;
                        ++itemIndex;
                    }

                    if (!x.IsActive)
                        return; // don't arrange disabled items

                    children.Add(x);
                }, false);
            }

            // get size of content and set content offsets and alignment
            var spacingSize = Spacing ?? ElementSize.Default;
            var spacing = isHorizontal ? (HorizontalSpacing != null ? HorizontalSpacing.Pixels : spacingSize.Pixels)
                 : (VerticalSpacing != null ? VerticalSpacing.Pixels : spacingSize.Pixels);

            var virtualItems = IsVirtualized ? _virtualItems.Skip(PageIndex * itemsPerPage).Take(itemsPerPage).ToList() : null;
            int childCount = !IsVirtualized ? children.Count : virtualItems.Count;
            int childIndex = 0;

            for (int i = 0; i < childCount; ++i)
            {
                var childView = !IsVirtualized ? children[i] : null;
                var childViewAlignment = !IsVirtualized ? childView.Alignment : ElementAlignment.Center;
                VirtualItem childSize = null;
                if (!IsVirtualized)
                {
                    childSize = new VirtualItem(childView.OverrideWidth ?? (childView.Width ?? ElementSize.Default),
                        childView.OverrideHeight ?? (childView.Height ?? ElementSize.Default));
                }
                else
                {
                    childSize = virtualItems[i];
                }

                if (childSize.Width.Unit == ElementSizeUnit.Percents)
                {
                    if (isHorizontal)
                    {
                        Debug.LogWarning(String.Format("#Delight# {0}: Unable to arrange list item horizontally as it doesn't specify its width in pixels.", Name));
                        continue;
                    }
                    else
                    {
                        percentageWidth = true;
                    }
                }

                if (childSize.Height.Unit == ElementSizeUnit.Percents)
                {
                    if (!isHorizontal)
                    {
                        Debug.LogWarning(String.Format("#Delight# {0} Unable to arrange list item vertically as it doesn't specify its height in pixels.", Name));
                        continue;
                    }
                    else
                    {
                        percentageHeight = true;
                    }
                }

                // set offsets and alignment
                var offset = new ElementMargin(
                    new ElementSize(isHorizontal ? totalWidth + spacing * childIndex : 0f, ElementSizeUnit.Pixels),
                    new ElementSize(!isHorizontal ? totalHeight + spacing * childIndex : 0f, ElementSizeUnit.Pixels));

                // set desired alignment if it is valid for the orientation otherwise use defaults
                var alignment = ElementAlignment.Center;
                var defaultAlignment = isHorizontal ? ElementAlignment.Left : ElementAlignment.Top;
                var desiredAlignment = !ContentAlignmentProperty.IsUndefined(this) ? ContentAlignment : childViewAlignment;
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
                    totalWidth += childSize.Width.Pixels;
                    maxWidth = childSize.Width.Pixels > maxWidth ? childSize.Width.Pixels : maxWidth;
                }

                if (!percentageHeight)
                {
                    totalHeight += childSize.Height.Pixels;
                    maxHeight = childSize.Height.Pixels > maxHeight ? childSize.Height.Pixels : maxHeight;
                }

                if (!DisableItemArrangement)
                {
                    if (!IsVirtualized)
                    {
                        bool defaultDisableChildLayoutUpdate = childView.DisableLayoutUpdate;
                        childView.DisableLayoutUpdate = true;

                        // update child layout
                        if (!offset.Equals(childView.OffsetFromParent) || alignment != childView.Alignment)
                        {
                            childView.OffsetFromParent = offset;
                            childView.Alignment = alignment;

                            childView.UpdateLayout(false);
                        }

                        childView.DisableLayoutUpdate = defaultDisableChildLayoutUpdate;
                    }
                    else
                    {
                        // set offset of virtual size
                        childSize.Offset = offset;
                        childSize.Alignment = alignment;
                    }
                }

                ++childIndex;
            }

            // calculate total width and height
            float totalSpacing = childCount > 1 ? (childIndex - 1) * spacing : 0f;
            var padding = Padding ?? ElementMargin.Default;
            var margin = Margin ?? ElementMargin.Default;

            // .. add margins
            if (!percentageWidth)
            {
                totalWidth += isHorizontal ? totalSpacing : 0f;
                totalWidth += margin.Left.Pixels + margin.Right.Pixels + padding.Left.Pixels + padding.Right.Pixels;
                maxWidth += margin.Left.Pixels + margin.Right.Pixels + padding.Left.Pixels + padding.Right.Pixels;
            }

            if (!percentageHeight)
            {
                totalHeight += !isHorizontal ? totalSpacing : 0f;
                totalHeight += margin.Top.Pixels + margin.Bottom.Pixels + padding.Top.Pixels + padding.Bottom.Pixels;
                maxHeight += margin.Top.Pixels + margin.Bottom.Pixels + padding.Top.Pixels + padding.Bottom.Pixels;
            }

            var newWidth = !percentageWidth ? new ElementSize(isHorizontal ? totalWidth : maxWidth, ElementSizeUnit.Pixels) :
                new ElementSize(1, ElementSizeUnit.Percents);
            var newHeight = !percentageHeight ? new ElementSize(!isHorizontal ? totalHeight : maxHeight, ElementSizeUnit.Pixels) :
                new ElementSize(1, ElementSizeUnit.Percents);

            // if width not specified, adjust width to content
            if (!IsScrollable)
            {
                if (WidthProperty.IsUndefined(this))
                {
                    if (!newWidth.Equals(OverrideWidth))
                    {
                        OverrideWidth = newWidth;
                        hasNewSize = true;
                    }
                }
                else if (OverrideWidth != null && !OverrideWidth.Equals(Width))
                {
                    // clear override
                    OverrideWidth = null;
                    hasNewSize = true;
                }

                // if height not specified, adjust height to content
                if (HeightProperty.IsUndefined(this))
                {
                    if (!newHeight.Equals(OverrideHeight))
                    {
                        OverrideHeight = newHeight;
                        hasNewSize = true;
                    }
                }
                else if (OverrideHeight != null && !OverrideHeight.Equals(Height))
                {
                    // clear override
                    OverrideHeight = null;
                    hasNewSize = true;
                }
            }
            else
            {
                // update size of content region
                if (!newWidth.Equals(ScrollableRegion.ContentRegion.Width) ||
                    !newHeight.Equals(ScrollableRegion.ContentRegion.Height))
                {
                    bool disableUpdate = ScrollableRegion.ContentRegion.DisableLayoutUpdate;
                    ScrollableRegion.ContentRegion.DisableLayoutUpdate = true;
                    ScrollableRegion.ContentRegion.Width = new ElementSize(newWidth);
                    ScrollableRegion.ContentRegion.Height = new ElementSize(newHeight);
                    ScrollableRegion.ContentRegion.UpdateLayout(false);
                    ScrollableRegion.UpdateScrollbars();
                    ScrollableRegion.ContentRegion.DisableLayoutUpdate = disableUpdate;
                }

                if (ScrollableRegionContentAlignmentProperty.IsUndefined(ScrollableRegion))
                {
                    // adjust content alignment based on orientation
                    ScrollableRegionContentAlignment = ScrollsHorizontally ? ElementAlignment.Left : ElementAlignment.Top;
                }
            }

            return hasNewSize;
        }

        /// <summary>
        /// Updates layout in wrapped lists.
        /// </summary>
        private bool UpdateLayoutWrapped()
        {
            var actualWidth = OverrideWidth ?? (Width ?? ElementSize.DefaultLayout);
            var actualHeight = OverrideHeight ?? (Height ?? ElementSize.DefaultLayout);
            
            if (Orientation == ElementOrientation.Horizontal && actualWidth.Unit != ElementSizeUnit.Pixels)
            {
                actualWidth = ActualWidth;
            }
            else if (Orientation == ElementOrientation.Vertical && actualHeight.Unit != ElementSizeUnit.Pixels)
            {
                actualHeight = ActualHeight;
            }

            bool hasNewSize = false;
            float maxWidth = 0f;
            float maxHeight = 0f;
            bool isHorizontal = Orientation == ElementOrientation.Horizontal;
            List<UIView> children = null;
            int itemsPerPage = IsPaged && PageSize > 0 ? PageSize : int.MaxValue;
            if (!IsVirtualized)
            {
                children = new List<UIView>();
                int itemIndex = 0;
                Content.ForEach<UIView>(x =>
                {
                    if (IsPaged)
                    {
                        int pageIndex = Mathf.FloorToInt(itemIndex / itemsPerPage);
                        x.IsActive = pageIndex == PageIndex;
                        ++itemIndex;
                    }

                    if (!x.IsActive)
                        return; // don't arrange disabled items

                    children.Add(x);
                }, false);
            }

            // get size of content and set content offsets and alignment
            var spacing = Spacing ?? ElementSize.Default;
            var horizontalSpacing = HorizontalSpacing != null ? HorizontalSpacing.Pixels : spacing.Pixels;
            var verticalSpacing = VerticalSpacing != null ? VerticalSpacing.Pixels : spacing.Pixels;
            float xOffset = 0f;
            float yOffset = 0f;
            float maxColumnWidth = 0;
            float maxRowHeight = 0;

            var virtualItems = IsVirtualized ? _virtualItems.Skip(PageIndex * itemsPerPage).Take(itemsPerPage).ToList() : null;
            int childCount = !IsVirtualized ? children.Count : virtualItems.Count;
            int childIndex = 0;
            bool firstItem = true;

            for (int i = 0; i < childCount; ++i)
            {
                var childView = !IsVirtualized ? children[i] : null;
                var childViewAlignment = !IsVirtualized ? childView.Alignment : ElementAlignment.Center;
                VirtualItem childSize = null;
                if (!IsVirtualized)
                {
                    childSize = new VirtualItem(childView.OverrideWidth ?? (childView.Width ?? ElementSize.Default),
                        childView.OverrideHeight ?? (childView.Height ?? ElementSize.Default));
                }
                else
                {
                    childSize = virtualItems[i];
                }

                if (childSize.Width.Unit == ElementSizeUnit.Percents && isHorizontal)
                {
                    Debug.LogError(String.Format("#Delight# {0}: Unable to arrange list item horizontally as it doesn't specify its width in pixels.", Name));
                    continue;
                }

                if (childSize.Height.Unit == ElementSizeUnit.Percents && !isHorizontal)
                {
                    Debug.LogError(String.Format("#Delight# {0}: Unable to arrange list item vertically as it doesn't specify its height in pixels or elements.", Name));
                    continue;
                }

                ElementMargin offset = new ElementMargin();

                // set offsets and alignment
                var alignment = ElementAlignment.TopLeft;
                if (isHorizontal)
                {
                    // set offset on children flowing horizontally
                    if (firstItem)
                    {
                        xOffset = 0;
                        firstItem = false;
                    }
                    else if ((xOffset + childSize.Width + horizontalSpacing) > actualWidth)
                    {
                        // item overflows to next row
                        xOffset = 0;
                        yOffset += maxRowHeight + verticalSpacing;
                        maxRowHeight = 0;
                    }
                    else
                    {
                        // item continues on the same row
                        xOffset += horizontalSpacing;
                    }

                    // set offsets
                    offset = new ElementMargin(xOffset, yOffset);
                    xOffset += childSize.Width;
                    maxRowHeight = Mathf.Max(maxRowHeight, childSize.Height);
                    maxWidth = Mathf.Max(maxWidth, xOffset);
                    maxHeight = Mathf.Max(maxHeight, yOffset + childSize.Height);
                }
                else
                {
                    // set offset on children flowing vertically
                    if (firstItem)
                    {
                        yOffset = 0;
                        firstItem = false;
                    }
                    else if ((yOffset + childSize.Height + verticalSpacing) > actualHeight)
                    {
                        // item overflows to next column
                        yOffset = 0;
                        xOffset += maxColumnWidth + horizontalSpacing;
                        maxColumnWidth = 0;
                    }
                    else
                    {
                        // item continues on the same column
                        yOffset += verticalSpacing;
                    }

                    // set offsets
                    offset = new ElementMargin(xOffset, yOffset);
                    yOffset += childSize.Height;
                    maxColumnWidth = Mathf.Max(maxColumnWidth, childSize.Width);
                    maxWidth = Mathf.Max(maxWidth, xOffset + childSize.Width);
                    maxHeight = Mathf.Max(maxHeight, yOffset);
                }

                if (!IsVirtualized)
                {
                    bool defaultDisableChildLayoutUpdate = childView.DisableLayoutUpdate;
                    childView.DisableLayoutUpdate = true;

                    // update child layout
                    if (!offset.Equals(childView.OffsetFromParent) || alignment != childView.Alignment)
                    {
                        childView.OffsetFromParent = offset;
                        childView.Alignment = alignment;

                        childView.UpdateLayout(false);
                    }

                    childView.DisableLayoutUpdate = defaultDisableChildLayoutUpdate;
                }
                else
                {
                    // set offset of virtual size
                    childSize.Offset = offset;
                    childSize.Alignment = alignment;
                }

                ++childIndex;
            }

            var padding = Padding ?? ElementMargin.Default;
            var margin = Margin ?? ElementMargin.Default;

            // adjust size to content
            if (isHorizontal)
            {
                // add margins
                maxHeight += margin.Top.Pixels + margin.Bottom.Pixels + padding.Top.Pixels + padding.Bottom.Pixels;
                var newHeight = new ElementSize(maxHeight);
                if (IsScrollable)
                {
                    if (!newHeight.Equals(ScrollableRegion.ContentRegion.Height))
                    {
                        bool disableUpdate = ScrollableRegion.ContentRegion.DisableLayoutUpdate;
                        ScrollableRegion.ContentRegion.DisableLayoutUpdate = true;
                        ScrollableRegion.ContentRegion.Height = new ElementSize(newHeight);
                        ScrollableRegion.ContentRegion.UpdateLayout(false);
                        ScrollableRegion.UpdateScrollbars();
                        ScrollableRegion.ContentRegion.DisableLayoutUpdate = disableUpdate;
                    }

                    if (ScrollableRegionContentAlignmentProperty.IsUndefined(ScrollableRegion))
                    {
                        // adjust content alignment based on orientation
                        ScrollableRegionContentAlignment = ScrollsHorizontally ? ElementAlignment.Left : ElementAlignment.Top;
                    }
                }
                else
                {
                    // if height not specified, adjust height to content
                    if (HeightProperty.IsUndefined(this))
                    {
                        if (!newHeight.Equals(OverrideHeight))
                        {
                            OverrideHeight = newHeight;
                            hasNewSize = true;
                        }
                    }
                    else
                    {
                        if (Height != null && !Height.Equals(OverrideHeight))
                        {
                            OverrideHeight = Height;
                            hasNewSize = true;
                        }
                    }
                }
            }
            else
            {
                // add margins
                maxWidth += margin.Left.Pixels + margin.Right.Pixels + padding.Left.Pixels + padding.Right.Pixels;
                var newWidth = new ElementSize(maxWidth);
                if (IsScrollable)
                {
                    if (!newWidth.Equals(ScrollableRegion.ContentRegion.Width))
                    {
                        bool disableUpdate = ScrollableRegion.ContentRegion.DisableLayoutUpdate;
                        ScrollableRegion.ContentRegion.DisableLayoutUpdate = true;
                        ScrollableRegion.ContentRegion.Width = new ElementSize(newWidth);
                        ScrollableRegion.ContentRegion.UpdateLayout(false);
                        ScrollableRegion.UpdateScrollbars();
                        ScrollableRegion.ContentRegion.DisableLayoutUpdate = disableUpdate;
                    }

                    if (ScrollableRegionContentAlignmentProperty.IsUndefined(ScrollableRegion))
                    {
                        // adjust content alignment based on orientation
                        ScrollableRegionContentAlignment = ScrollsHorizontally ? ElementAlignment.Left : ElementAlignment.Top;
                    }
                }
                else
                {
                    // if height not specified, adjust height to content
                    if (WidthProperty.IsUndefined(this))
                    {
                        if (!newWidth.Equals(OverrideWidth))
                        {
                            OverrideWidth = newWidth;
                            hasNewSize = true;
                        }
                    }
                    else
                    {
                        if (Width != null && !Width.Equals(OverrideWidth))
                        {
                            OverrideWidth = Width;
                            hasNewSize = true;
                        }
                    }
                }
            }

            return hasNewSize;
        }

        /// <summary>
        /// Selects item and scrolls to it.
        /// </summary>
        public void SelectAndScrollToItem(BindableObject item, ElementAlignment? alignment = null, ElementMargin offset = null)
        {
            SelectItem(item, true);
            ScrollTo(item, alignment, offset);
        }

        /// <summary>
        /// Selects item in the list.
        /// </summary>
        public void SelectItem(int index, bool triggeredByClick = false)
        {
            int itemCount = IsStatic ? Content.LayoutChildren.Count : (Items != null ? Items.Count : -1);
            if (index < 0 || index > itemCount)
            {
                DeselectAll();
                return;
            }

            if (IsStatic)
            {
                SelectItem(Content.LayoutChildren[index] as ListItem, triggeredByClick);
            }
            else
            {
                SelectItem(Items.GetGeneric(index), triggeredByClick);
            }
        }

        /// <summary>
        /// Selects item in the list.
        /// </summary>
        public void SelectItem(BindableObject item, bool triggeredByClick = false)
        {
            if (item == null)
            {
                DeselectAll();
                return;
            }

            if (IsVirtualized)
            {
                var virtualItem = GetVirtualItem(item);
                SelectVirtualItem(virtualItem);
            }
            else
            {
                if (_presentedItems.TryGetValue(item, out var listItem))
                {
                    SelectItem(listItem, triggeredByClick);
                }
            }
        }

        /// <summary>
        /// Selects item in the list.
        /// </summary>
        public void SelectItem(ListItem listItem, bool triggeredByClick = false)
        {
            if (listItem == null || (triggeredByClick && !CanSelect))
                return;

            if (IsVirtualized)
            {
                var virtualItem = GetVirtualItem(listItem.Item);
                SelectVirtualItem(virtualItem);
                return;
            }

            // is item already selected?
            if (listItem.IsSelected)
            {
                // yes. can it be deselected?
                if (triggeredByClick && !CheckCanDeselect())
                {
                    // no. should it be re-selected?
                    if (CanReselect)
                    {
                        // yes. select it again
                        SetSelected(listItem, true);
                    }

                    return; // no.
                }

                // deselect and trigger actions
                SetSelected(listItem, false);
            }
            else
            {
                // select
                SetSelected(listItem, true);

                // deselect other items if we can't multi-select
                if (!CanMultiSelect)
                {
                    foreach (ListItem item in Content.LayoutChildren)
                    {
                        if (item == listItem)
                            continue;

                        // deselect and trigger actions
                        SetSelected(item, false);
                    }
                }

                // should this item immediately be deselected?
                if (DeselectAfterSelect)
                {
                    // yes.
                    SetSelected(listItem, false);
                }
            }
        }

        /// <summary>
        /// Selects or deselects a list item.
        /// </summary>
        private void SetSelected(ListItem listItem, bool selected)
        {
            if (listItem == null)
                return;

            listItem.IsSelected = selected;
            if (selected)
            {
                _selectedItem = listItem.Item;
                SelectedItem = listItem.Item;
            }

            ItemSelectionActionData data = new ItemSelectionActionData { IsSelected = selected, ListItem = listItem, Item = listItem.Item };
            if (selected)
            {
                ItemSelected?.Invoke(this, data);
            }
            else
            {
                ItemDeselected?.Invoke(this, data);
            }
        }

        /// <summary>
        /// Selects item in the list.
        /// </summary>
        private void SelectVirtualItem(VirtualItem listItem, bool triggeredByClick = false)
        {
            if (listItem == null || (triggeredByClick && !CanSelect))
                return;

            // is item already selected?
            if (listItem.IsSelected)
            {
                // yes. can it be deselected?
                if (triggeredByClick && !CheckCanDeselect())
                {
                    // no. should it be re-selected?
                    if (CanReselect)
                    {
                        // yes. select it again
                        SetSelectedVirtual(listItem, true);
                    }

                    return; // no.
                }

                // deselect and trigger actions
                SetSelectedVirtual(listItem, false);
            }
            else
            {
                // select
                SetSelectedVirtual(listItem, true);

                // deselect other items if we can't multi-select
                if (!CanMultiSelect)
                {
                    foreach (VirtualItem item in _virtualItems)
                    {
                        if (item == listItem)
                            continue;

                        // deselect and trigger actions
                        SetSelectedVirtual(item, false);
                    }
                }

                // should this item immediately be deselected?
                if (DeselectAfterSelect)
                {
                    // yes.
                    SetSelectedVirtual(listItem, false);
                }
            }
        }

        /// <summary>
        /// Selects or deselects a list item.
        /// </summary>
        private void SetSelectedVirtual(VirtualItem listItem, bool selected)
        {
            if (listItem == null)
                return;

            listItem.IsSelected = selected;
            if (listItem.RealizedItem != null)
            {
                listItem.RealizedItem.IsSelected = selected;
            }

            if (selected)
            {
                _selectedItem = listItem.Item;
                SelectedItem = listItem.Item;
            }

            ItemSelectionActionData data = new ItemSelectionActionData { IsSelected = selected, ListItem = listItem.RealizedItem, Item = listItem.Item };
            if (selected)
            {
                ItemSelected?.Invoke(this, data);
            }
            else
            {
                ItemDeselected?.Invoke(this, data);
            }
        }

        /// <summary>
        /// Deselects all items.
        /// </summary>
        public void DeselectAll()
        {
            if (IsVirtualized)
            {
                foreach (var virtualItem in _virtualItems)
                {
                    SetSelectedVirtual(virtualItem, false);
                }
                return;
            }
            else if (IsStatic)
            {
                foreach (var listItem in Content.LayoutChildren)
                {
                    SetSelected(listItem as ListItem, false);
                }
            }
            else
            {
                foreach (var listItem in _presentedItems.Values)
                {
                    SetSelected(listItem, false);
                }

                if (SelectedItem != null)
                {
                    SelectedItem = null;
                }
            }
        }

        /// <summary>
        /// Gets selected item of type.
        /// </summary>
        public T GetSelected<T>() where T : BindableObject
        {
            return SelectedItem as T;
        }

        /// <summary>
        /// Checks if an item can be deselected. 
        /// </summary>
        private bool CheckCanDeselect()
        {
            return CanDeselectProperty.IsUndefined(this) ? CanMultiSelect : CanDeselect;
        }

        /// <summary>
        /// Generates static list items.
        /// </summary>
        private void CreateStaticListItems()
        {
            if (ContentTemplates == null)
                return;

            int index = 0;
            foreach (var contentTemplate in ContentTemplates)
            {
                var templateData = new ContentTemplateData();
                templateData.ZeroIndex = index;

                var listItem = contentTemplate.Activator(templateData) as ListItem;
                listItem.IsAlternate = IsOdd(index + 1);
                listItem.Load();
                UnblockListItemDragEvents(listItem);
                ++index;
            }
        }



        /// <summary>
        /// Unblocks drag events from list items, which makes it so draggable items don't block the list from being scrolled.
        /// </summary>
        private void UnblockListItemDragEvents(ListItem listItem)
        {
            if (listItem == null)
                return;

            var viewsToUnblock = listItem.HierarchyToList<SceneObjectView>();
            if (IsScrollable)
            {
                ScrollableRegion.UnblockDragEvents(viewsToUnblock);
            }

            // unblock drag-events in parent scrollable regions
            // TODO this can be done through a better mechanism as we need to do this anytime new children are added to an hierarchy not just here            
            this.ForEachParent<ScrollableRegion>(x => x.UnblockDragEvents(viewsToUnblock));
        }

        /// <summary>
        /// Gets list item based belonging to bindable object.
        /// </summary>
        public ListItem GetListItem(BindableObject key)
        {
            if (IsVirtualized)
            {
                return null;
            }
            else
            {
                _presentedItems.TryGetValue(key, out var listItem);
                return listItem;
            }
        }

        /// <summary>
        /// Gets list items.
        /// </summary>
        public List<ListItem> GetActiveListItems()
        {
            if (IsVirtualized)
            {
                return null;
            }
            else
            {
                var listItems = new List<ListItem>();
                foreach (ListItem listItem in Content.LayoutChildren)
                {
                    listItems.Add(listItem);
                }
                return listItems;
            }
        }

        /// <summary>
        /// Gets bool inidcating if the number is odd.
        /// </summary>
        public static bool IsOdd(int value)
        {
            return value % 2 != 0;
        }

        /// <summary>
        /// Gets the index of the currently selected item.
        /// </summary>
        public int GetSelectedItemIndex()
        {
            if (SelectedItem == null)
                return -1;

            if (IsVirtualized)
            {
                return _indexOfItem.TryGetValue(SelectedItem, out var selectedIndex) ? selectedIndex : -1;
            }
            else
            {
                var listItem = GetListItem(SelectedItem);
                return listItem != null ? listItem.ContentTemplateData.ZeroIndex : -1;
            }
        }

        /// <summary>
        /// Selects next item in list. 
        /// </summary>
        public void SelectNext(bool scrollTo = true, ElementAlignment? alignment = null, ElementMargin offset = null)
        {
            // find next item in list 
            int index = GetSelectedItemIndex();
            if (index == -1)
                return;

            var nextItem = Items.GetGeneric(index + 1);
            if (nextItem == null)
                return;

            // scroll to next item
            if (scrollTo)
            {
                alignment = alignment ?? (ScrollsHorizontally ? ElementAlignment.Right : ElementAlignment.Bottom);
                SelectAndScrollToItem(nextItem, alignment, offset);
            }
            else
            {
                SelectItem(nextItem, true);
            }
        }

        /// <summary>
        /// Selects previous item in list. 
        /// </summary>
        public void SelectPrevious(bool scrollTo = true, ElementAlignment? alignment = null, ElementMargin offset = null)
        {
            // find previous item in list 
            int index = GetSelectedItemIndex();
            if (index == -1)
                return;

            var nextItem = Items.GetGeneric(index - 1);
            if (nextItem == null)
                return;

            // scroll to previous item
            if (scrollTo)
            {
                alignment = alignment ?? (ScrollsHorizontally ? ElementAlignment.Left : ElementAlignment.Top);
                SelectAndScrollToItem(nextItem, alignment, offset);
            }
            else
            {
                SelectItem(nextItem, true);
            }
        }

        /// <summary>
        /// Scrolls the list down a page.
        /// </summary>
        public void ScrollPageDown(bool moveSelection = false)
        {
            if (!IsScrollable)
            {
                return;
            }

            // TODO implement
            // moves the page down
            // find all items visible in viewport and select last one
        }

        /// <summary>
        /// Scrolls the list up a page.
        /// </summary>
        public void ScrollPageUp(bool moveSelection = false)
        {
            if (!IsScrollable)
            {
                return;
            }

            // TODO implement
            // moves the page down
            // find all items visible in viewport and select first one
        }

        /// <summary>
        /// Gets max page index of paged lists.
        /// </summary>
        public int GetMaxPageIndex()
        {
            if (Items == null)
                return 0;

            int itemsPerPage = IsPaged && PageSize > 0 ? PageSize : int.MaxValue;
            int maxPageIndex = Mathf.FloorToInt((Items.Count - 1) / itemsPerPage);
            return maxPageIndex;
        }

        /// <summary>
        /// Navigates to next page in paged lists.
        /// </summary>
        public void NextPage()
        {
            if (!IsPaged || Items == null)
                return;

            int childCount = Items.Count;
            if (childCount == 0)
                return;

            int maxPageIndex = GetMaxPageIndex();
            if (PageIndex >= maxPageIndex)
                return;

            ++PageIndex;
        }

        /// <summary>
        /// Navigates to previous page in paged lists.
        /// </summary>
        public void PreviousPage()
        {
            if (!IsPaged || Items == null)
                return;

            int childCount = Items.Count;
            if (childCount == 0)
                return;

            if (PageIndex <= 0)
                return;

            --PageIndex;
        }

        /// <summary>
        /// Jumps to the specified page in paged lists.
        /// </summary>
        public void JumpToPage(int pageIndex)
        {
            if (!IsPaged || Items == null)
                return;

            int childCount = Items.Count;
            if (childCount == 0)
                return;

            int maxPageIndex = GetMaxPageIndex();
            if (pageIndex > maxPageIndex || pageIndex < 0)
                return;

            PageIndex = pageIndex;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Returns boolean indicating if list scrolls horizontally. 
        /// </summary>
        public bool ScrollsHorizontally
        {
            get
            {
                return Overflow == OverflowMode.Wrap ? Orientation == ElementOrientation.Vertical : Orientation == ElementOrientation.Horizontal;
            }
        }

        #endregion
    }
}
