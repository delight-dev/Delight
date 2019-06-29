#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class List
    {
        #region Fields

        private BindableCollection _oldCollection;
        private Dictionary<BindableObject, ListItem> _presentedItems = new Dictionary<BindableObject, ListItem>();

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
                case nameof(Orientation):
                    ListOrientationChanged();
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
                CreateItem(item);
            }

            UpdateLayout();
        }

        /// <summary>
        /// Called after the view and its children has been loaded.
        /// </summary>
        protected override void AfterLoad()
        {
            base.AfterLoad();
            ItemsChanged();
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
        }

        /// <summary>
        /// Called when the list of items has been changed.
        /// </summary>
        private void OnCollectionChanged(object sender, CollectionChangedEventArgs e)
        {
            if( !IsLoaded )
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
                UpdateLayout();
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
                    CreateItem(e.Item);
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

                default:
                    throw new ArgumentOutOfRangeException();
            }

            return updateLayout;

            // TODO implement collection change actions
            //// update list of items
            //else if (e.ListChangeAction == ListChangeAction.ScrollTo)
            //{
            //    ScrollTo(e.StartIndex, e.Alignment);
            //}
            //else if (e.ListChangeAction == ListChangeAction.Modify)
            //{
            //    ItemsModified(e.StartIndex, e.EndIndex, e.FieldPath);
            //}
            //else if (e.ListChangeAction == ListChangeAction.Select)
            //{
            //    SelectItem(e.StartIndex);
            //}

            //if (ListChanged.HasEntries)
            //{
            //    ListChanged.Trigger(new ListChangedActionData { ListChangeAction = e.ListChangeAction, StartIndex = e.StartIndex, EndIndex = e.EndIndex, FieldPath = e.FieldPath });
            //}
        }

        /// <summary>
        /// Replaces presented items. 
        /// </summary>
        private void ReplaceItems()
        {
            if (IsVirtualized)
            {
                // TODO implement
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
                    CreateItem(Items.Get(i));
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
                // TODO implement
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

            // clear list items
            ClearItems();

            if (IsLoaded)
            {
                CreateItems();
            }
        }

        /// <summary>
        /// Clears the list. 
        /// </summary>
        private void ClearItems()
        {
            // unload and clear existing children
            foreach (var child in Content.LayoutChildren)
            {
                child.Unload();
            }
            Content.LayoutChildren.Clear();
            _presentedItems.Clear();
        }

        public void ListOrientationChanged()
        {
            // TODO implement rearrangement of list
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
            // update layout and notify parents if size has changed
            if (UpdateLayout(false))
            {
                NotifyParentOfChildLayoutChanged();
            }
        }

        /// <summary>
        /// Called when a new item is to be generated.
        /// </summary>
        protected override View CreateItem(BindableObject item)
        {
            if (IsVirtualized)
            {
                // TODO implement
            }

            var listItem = base.CreateItem(item) as ListItem;
            if (IsScrollable && listItem != null)
            {
                ScrollableRegion.UnblockDragEvents(listItem as SceneObjectView);
            }

            // unblock drag-events in parent scrollable regions
            // TODO this can be done through a better mechanism as we need to do this anytime new children are added to an hierarchy not just here
            this.ForEachParent<ScrollableRegion>(x => x.UnblockDragEvents(listItem as SceneObjectView));
            if (!_presentedItems.ContainsKey(item))
            {
                _presentedItems.Add(item, listItem);
            }

            // set item data on list item for easy reference
            listItem.Item = item;
            return listItem;
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

            DisableLayoutUpdate = defaultDisableLayoutUpdate;
            return base.UpdateLayout(notifyParent) || hasNewSize;
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

            List<UIView> children = new List<UIView>();
            Content.ForEach<UIView>(x =>
            {
                children.Add(x);
            }, false);

            // get size of content and set content offsets and alignment
            var spacingSize = Spacing ?? ElementSize.Default;
            var spacing = isHorizontal ? (HorizontalSpacing != null ? HorizontalSpacing.Pixels : spacingSize.Pixels)
                 : (VerticalSpacing != null ? VerticalSpacing.Pixels : spacingSize.Pixels);

            int childCount = children.Count;
            int childIndex = 0;
            for (int i = 0; i < childCount; ++i)
            {
                var childView = children[i];
                var childWidth = childView.OverrideWidth ?? (childView.Width ?? ElementSize.Default);
                var childHeight = childView.OverrideHeight ?? (childView.Height ?? ElementSize.Default);

                if (childWidth.Unit == ElementSizeUnit.Percents)
                {
                    if (isHorizontal)
                    {
                        Debug.LogWarning(String.Format("[Delight] Unable to group view \"{0}\" horizontally as it doesn't specify its width in pixels.", childView.Name));
                        continue;
                    }
                    else
                    {
                        percentageWidth = true;
                    }
                }

                if (childHeight.Unit == ElementSizeUnit.Percents)
                {
                    if (!isHorizontal)
                    {
                        Debug.LogWarning(String.Format("[Delight] Unable to group view \"{0}\" vertically as it doesn't specify its height in pixels or elements.", childView.Name));
                        continue;
                    }
                    else
                    {
                        percentageHeight = true;
                    }
                }

                bool defaultDisableChildLayoutUpdate = childView.DisableLayoutUpdate;
                childView.DisableLayoutUpdate = true;

                // set offsets and alignment
                var offset = new ElementMargin(
                    new ElementSize(isHorizontal ? totalWidth + spacing * childIndex : 0f, ElementSizeUnit.Pixels),
                    new ElementSize(!isHorizontal ? totalHeight + spacing * childIndex : 0f, ElementSizeUnit.Pixels));

                // set desired alignment if it is valid for the orientation otherwise use defaults
                var alignment = ElementAlignment.Center;
                var defaultAlignment = isHorizontal ? ElementAlignment.Left : ElementAlignment.Top;
                var desiredAlignment = !ContentAlignmentProperty.IsUndefined(this) ? ContentAlignment : childView.Alignment;
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
                    totalWidth += childWidth;
                    maxWidth = childWidth.Pixels > maxWidth ? childWidth.Pixels : maxWidth;
                }

                if (!percentageHeight)
                {
                    totalHeight += childHeight;
                    maxHeight = childHeight.Pixels > maxHeight ? childHeight.Pixels : maxHeight;
                }

                // update child layout
                if (!offset.Equals(childView.OffsetFromParent) || alignment != childView.Alignment)
                {
                    childView.OffsetFromParent = offset;
                    childView.Alignment = alignment;

                    childView.UpdateLayout(false);
                }
                ++childIndex;
                childView.DisableLayoutUpdate = defaultDisableChildLayoutUpdate;
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
                    ScrollableRegion.ContentRegion.Width = newWidth;
                    ScrollableRegion.ContentRegion.Height = newHeight;
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
            List<UIView> children = new List<UIView>();
            Content.ForEach<UIView>(x =>
            {
                children.Add(x);
            }, false);

            // get size of content and set content offsets and alignment
            var spacing = Spacing ?? ElementSize.Default;
            var horizontalSpacing = HorizontalSpacing != null ? HorizontalSpacing.Pixels : spacing.Pixels;
            var verticalSpacing = VerticalSpacing != null ? VerticalSpacing.Pixels : spacing.Pixels;
            float xOffset = 0f;
            float yOffset = 0f;
            float maxColumnWidth = 0;
            float maxRowHeight = 0;
            int childCount = children.Count;
            int childIndex = 0;
            bool firstItem = true;

            for (int i = 0; i < childCount; ++i)
            {
                var childView = children[i];
                var childWidth = childView.OverrideWidth ?? (childView.Width ?? ElementSize.Default);
                var childHeight = childView.OverrideHeight ?? (childView.Height ?? ElementSize.Default);

                if (childWidth.Unit == ElementSizeUnit.Percents && isHorizontal)
                {
                    Debug.LogWarning(String.Format("[Delight] Unable to group view \"{0}\" horizontally as it doesn't specify its width in pixels.", childView.Name));
                    continue;
                }

                if (childHeight.Unit == ElementSizeUnit.Percents && !isHorizontal)
                {
                    Debug.LogWarning(String.Format("[Delight] Unable to group view \"{0}\" vertically as it doesn't specify its height in pixels or elements.", childView.Name));
                    continue;
                }

                bool defaultDisableChildLayoutUpdate = childView.DisableLayoutUpdate;
                childView.DisableLayoutUpdate = true;
                ElementMargin offset = null;

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
                    else if ((xOffset + childWidth + horizontalSpacing) > ActualWidth)
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
                    xOffset += childWidth;
                    maxRowHeight = Mathf.Max(maxRowHeight, childHeight);
                    maxWidth = Mathf.Max(maxWidth, xOffset);
                    maxHeight = Mathf.Max(maxHeight, yOffset + childHeight);
                }
                else
                {
                    // set offset on children flowing vertically
                    if (firstItem)
                    {
                        yOffset = 0;
                        firstItem = false;
                    }
                    else if ((yOffset + childHeight + verticalSpacing) > ActualHeight)
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
                    yOffset += childHeight;
                    maxColumnWidth = Mathf.Max(maxColumnWidth, childWidth);
                    maxWidth = Mathf.Max(maxWidth, xOffset + childWidth);
                    maxHeight = Mathf.Max(maxHeight, yOffset);
                }

                // update child layout if changed
                if (!offset.Equals(childView.OffsetFromParent) || alignment != childView.Alignment)
                {
                    childView.OffsetFromParent = offset;
                    childView.Alignment = alignment;
                    childView.UpdateLayout(false);
                }

                ++childIndex;
                childView.DisableLayoutUpdate = defaultDisableChildLayoutUpdate;
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
                        ScrollableRegion.ContentRegion.Height = newHeight;
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
                        ScrollableRegion.ContentRegion.Width = newWidth;
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
        /// Selects item in the list.
        /// </summary>
        public void SelectItem(BindableObject item, bool triggeredByClick = false)
        {
            if(_presentedItems.TryGetValue(item, out var listItem))
            {
                SelectItem(listItem);
            }
        }

        /// <summary>
        /// Selects item in the list.
        /// </summary>
        public void SelectItem(ListItem listItem, bool triggeredByClick = false)
        {
            if (listItem == null || (triggeredByClick && !CanSelect))
                return;

            // is item already selected?
            if (listItem.IsSelected)
            {
                // yes. can it be deselected?
                if (triggeredByClick && !CanDeselect)
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

                // deselect other items
                foreach (ListItem item in Content.LayoutChildren)
                {
                    if (item == listItem)
                        continue;

                    // deselect and trigger actions
                    SetSelected(item, false);
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
        /// Selects item in the list.
        /// </summary>
        //public void SelectItem(int index)
        //{
        //    if (Items == null || index < 0 || index >= Items.Count)
        //        return;

        //    if (IsVirtualized)
        //    {
        //        // TODO implement virtualized selection logic
        //        //_selectedItem = Items[index];
        //        //int startIndex = _previousFirstRowIndex * ItemsPerVirtualizedRow;
        //        //int endIndex = startIndex + (VirtualizedItemsCount - 1);

        //        //// is item outside viewport? 
        //        //if (index < startIndex || index > endIndex)
        //        //    return; // yes. no need to update

        //        //// select virtualized list item
        //        //var virtualizedItem = _virtualizedItems[index - startIndex];
        //        //SelectItem(virtualizedItem, false);
        //    }
        //    else
        //    {
        //        SelectItem(_presentedListItems[index] as ListItem, false);
        //    }
        //}

        /// <summary>
        /// Selects or deselects a list item.
        /// </summary>
        private void SetSelected(ListItem listItem, bool selected)
        {
            if (listItem == null)
                return;

            listItem.IsSelected = selected;

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
