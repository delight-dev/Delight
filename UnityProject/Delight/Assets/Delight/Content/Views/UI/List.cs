#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
        public override void OnPropertyChanged(object source, string property)
        {
            if (IgnoreObject)
                return;

            base.OnPropertyChanged(source, property);
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

            foreach (var item in Items.GetDataEnumerator())
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
            CreateItems();
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
                    break;

                case CollectionChangeAction.Clear:
                    updateLayout = true;
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }

            return updateLayout;

            // TODO implement collection change actions
            //// update list of items
            //else if (e.ListChangeAction == ListChangeAction.Remove)
            //{
            //    UpdateItems();
            //}
            //else if (e.ListChangeAction == ListChangeAction.Replace)
            //{
            //    _updateVirtualization = true;
            //}
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
            //else if (e.ListChangeAction == ListChangeAction.Move)
            //{
            //    _updateVirtualization = true;
            //}

            //if (ListChanged.HasEntries)
            //{
            //    ListChanged.Trigger(new ListChangedActionData { ListChangeAction = e.ListChangeAction, StartIndex = e.StartIndex, EndIndex = e.EndIndex, FieldPath = e.FieldPath });
            //}
        }

        /// <summary>
        /// Destroys item in list.
        /// </summary>
        protected virtual void DestroyItem(BindableObject item)
        {
            if (IsVirtualized)
            {
                // TODO implement
                throw new NotImplementedException();
            }

            ListItem listItem;
            if (_presentedItems.TryGetValue(item, out listItem))
            {
                listItem.Unload();
                Content.LayoutChildren.Remove(listItem);
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
                return null;
            }

            var listItem = base.CreateItem(item) as ListItem;
            if (IsScrollable && listItem != null)
            {
                ScrollableRegion.UnblockDragEvents(listItem as SceneObjectView);
            }

            // unblock drag-events in parent scrollable regions
            // TODO this can be done through a better mechanism as we need to do this anytime new children are added to an hierarchy not just here
            this.ForEachParent<ScrollableRegion>(x => x.UnblockDragEvents(listItem as SceneObjectView));
            _presentedItems.Add(item, listItem);

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
            var spacing = Spacing ?? ElementSize.Default;
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
                    new ElementSize(isHorizontal ? totalWidth + spacing.Pixels * childIndex : 0f, ElementSizeUnit.Pixels),
                    new ElementSize(!isHorizontal ? totalHeight + spacing.Pixels * childIndex : 0f, ElementSizeUnit.Pixels));

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
            float totalSpacing = childCount > 1 ? (childIndex - 1) * spacing.Pixels : 0f;

            // .. add margins
            if (!percentageWidth)
            {
                var margin = Margin ?? ElementMargin.Default;
                totalWidth += isHorizontal ? totalSpacing : 0f;
                totalWidth += margin.Left.Pixels + margin.Right.Pixels;
                maxWidth += margin.Left.Pixels + margin.Right.Pixels;
            }

            if (!percentageHeight)
            {
                var margin = Margin ?? ElementMargin.Default;
                totalHeight += !isHorizontal ? totalSpacing : 0f;
                totalHeight += margin.Top.Pixels + margin.Bottom.Pixels;
                maxHeight += margin.Top.Pixels + margin.Bottom.Pixels;
            }

            var newWidth = !percentageWidth ? new ElementSize(isHorizontal ? totalWidth : maxWidth, ElementSizeUnit.Pixels) :
                new ElementSize(1, ElementSizeUnit.Percents);
            var newHeight = !percentageHeight ? new ElementSize(!isHorizontal ? totalHeight : maxHeight, ElementSizeUnit.Pixels) :
                new ElementSize(1, ElementSizeUnit.Percents);

            // if width not specified, adjust width to content
            if (WidthProperty.IsUndefined(this))
            {
                if (!newWidth.Equals(OverrideWidth))
                {
                    OverrideWidth = newWidth;
                    hasNewSize = true;
                }
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

            // update size of content region
            if (IsScrollable)
            {
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

            DisableLayoutUpdate = defaultDisableLayoutUpdate;
            return base.UpdateLayout(notifyParent) || hasNewSize;
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
                return OverflowMode == OverflowMode.Wrap ? Orientation == ElementOrientation.Vertical : Orientation == ElementOrientation.Horizontal;
            }
        }

        #endregion
    }
}
