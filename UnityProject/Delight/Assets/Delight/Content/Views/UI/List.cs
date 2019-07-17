#region Using Statements
using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
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
            }
        }

        /// <summary>
        /// Generates views from data in collection. 
        /// </summary>
        protected void CreateItems()
        {
            if (Items == null)
                return;

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
                        SelectItem(e.Item);
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
            var item = Items.Get(index);
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
                var newItem = Items.Get(i);
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
                    CreateListItem(Items.Get(i));
                }
            }
            else if (newItemsCount < childCount)
            {
                // old list larger than new - remove items
                for (int i = childCount - 1; i >= newItemsCount; --i)
                {
                    var listItem = Content.LayoutChildren[i];
                    listItem.Unload();
                    Content.LayoutChildren.RemoveAt(i);
                }
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

            if (_presentedItems.TryGetValue(item, out var listItem))
            {
                listItem.Unload();
                Content.LayoutChildren.Remove(listItem);
                _presentedItems.Remove(item);
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
            foreach (var child in Content.LayoutChildren.ToList())
            {
                child.Unload();
            }
            Content.LayoutChildren.Clear();
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
                    newVirtualItem.Item = item;
                    _virtualItems.Add(newVirtualItem);
                    _indexOfItem.Add(item, _virtualItems.Count - 1);
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
            }
        }

        /// <summary>
        /// Updates the layout of the group. 
        /// </summary>
        public override bool UpdateLayout(bool notifyParent = true)
        {
            bool defaultDisableLayoutUpdate = DisableLayoutUpdate;
            DisableLayoutUpdate = true;

            bool hasNewSize = false;
            if (Overflow == OverflowMode.Overflow)
            {
                hasNewSize = UpdateLayoutOverflow();
            }
            else
            {
                hasNewSize = UpdateLayoutWrapped();
            }

            if (IsVirtualized)
            {
                UpdateRealizedItems();
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
            virtualItem.RealizedItem.IsActive = false;
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
            realizedItem.IsActive = true;
            realizedItem.Width = virtualItem.Width;
            realizedItem.Height = virtualItem.Height;
            realizedItem.OffsetFromParent = virtualItem.Offset;
            realizedItem.Alignment = virtualItem.Alignment;
            realizedItem.IsSelected = virtualItem.IsSelected;
            realizedItem.Item = virtualItem.Item;
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
            var listItem = virtualItem.ContentTemplate.Activator(new ContentTemplateData { Item = virtualItem.Item }) as ListItem;
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

            List<UIView> children = null;
            if (!IsVirtualized)
            {
                children = new List<UIView>();
                Content.ForEach<UIView>(x =>
                {
                    children.Add(x);
                }, false);
            }

            // get size of content and set content offsets and alignment
            var spacingSize = Spacing ?? ElementSize.Default;
            var spacing = isHorizontal ? (HorizontalSpacing != null ? HorizontalSpacing.Pixels : spacingSize.Pixels)
                 : (VerticalSpacing != null ? VerticalSpacing.Pixels : spacingSize.Pixels);

            int childCount = !IsVirtualized ? children.Count : _virtualItems.Count;
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
                    childSize = _virtualItems[i];
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
                    ScrollableRegion.ContentRegion.Width = new ElementSize(newWidth);
                    ScrollableRegion.ContentRegion.Height = new ElementSize(newHeight);
                    ScrollableRegion.UpdateLayout(false);
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
            bool hasNewSize = false;
            float maxWidth = 0f;
            float maxHeight = 0f;
            bool isHorizontal = Orientation == ElementOrientation.Horizontal;
            List<UIView> children = null;
            if (!IsVirtualized)
            {
                children = new List<UIView>();
                Content.ForEach<UIView>(x =>
                {
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
            int childCount = !IsVirtualized ? children.Count : _virtualItems.Count;
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
                    childSize = _virtualItems[i];
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
                    else if ((xOffset + childSize.Width + horizontalSpacing) > ActualWidth)
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
                    else if ((yOffset + childSize.Height + verticalSpacing) > ActualHeight)
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
                        ScrollableRegion.ContentRegion.Height = new ElementSize(newHeight);
                        ScrollableRegion.UpdateLayout(false);
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
                        if (!Height.Equals(OverrideHeight))
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
                        ScrollableRegion.ContentRegion.Width = new ElementSize(newWidth);
                        ScrollableRegion.UpdateLayout(false);
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
                        if (!Width.Equals(OverrideWidth))
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
            SelectItem(item);
            ScrollTo(item, alignment, offset);
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

            foreach (var listItem in _presentedItems.Values)
            {
                SetSelected(listItem, false);
            }

            if (SelectedItem != null)
            {
                SelectedItem = null;
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

            foreach (var contentTemplate in ContentTemplates)
            {
                var templateData = new ContentTemplateData();
                var listItem = contentTemplate.Activator(templateData) as ListItem;
                listItem.Load();
                UnblockListItemDragEvents(listItem);
            }
        }

        /// <summary>
        /// Unblocks drag events from list items, which makes it so draggable items don't block the list from being scrolled.
        /// </summary>
        private void UnblockListItemDragEvents(ListItem listItem)
        {
            if (listItem == null)
                return;

            if (IsScrollable)
            {
                ScrollableRegion.UnblockDragEvents(listItem as SceneObjectView);
            }

            // unblock drag-events in parent scrollable regions
            // TODO this can be done through a better mechanism as we need to do this anytime new children are added to an hierarchy not just here
            this.ForEachParent<ScrollableRegion>(x => x.UnblockDragEvents(listItem as SceneObjectView));
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
