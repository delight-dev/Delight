#region Using Statements
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using UnityEngine;
#endregion

namespace Delight
{
    /// <summary>
    /// Generic list that notify observers when items are added, deleted or moved.
    /// </summary>
    [Serializable]
    public class ObservableList<T> : IObservableList, IEnumerable<T>
    {
        #region Fields

        private List<T> _list;
        private object _selectedItem;
        public event EventHandler<ListChangedEventArgs> ListChanged;        

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public ObservableList()
        {
            _list = new List<T>();
        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public ObservableList(int capacity)
        {
            _list = new List<T>(capacity);
        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public ObservableList(IEnumerable<T> collection)
        {
            _list = new List<T>(collection);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds item to the end of the list.
        /// </summary>
        public void Add(object item)
        {
            Add((T)item);
        }

        /// <summary>
        /// Adds a range of items to the list.
        /// </summary>
        public void Add(IEnumerable items)
        {
            foreach (var item in items)
            {
                Add((T)item);
            }
        }

        /// <summary>
        /// Adds item to the end of the list.
        /// </summary>
        public void Add(T item)
        {
            int index = _list.Count;
            _list.Add(item);
            ListChanged?.Invoke(this, new ListChangedEventArgs { ListChangeAction = ListChangeAction.Add, StartIndex = index, EndIndex = index });
        }

        /// <summary>
        /// Adds a range of items to the end of the list.
        /// </summary>
        public void AddRange(IEnumerable<T> items)
        {
            int itemCount = items.Count();
            if (itemCount <= 0)
                return;

            int startIndex = _list.Count;
            int endIndex = startIndex + (itemCount - 1);

            _list.AddRange(items);
            ListChanged?.Invoke(this, new ListChangedEventArgs { ListChangeAction = ListChangeAction.Add, StartIndex = startIndex, EndIndex = endIndex });
        }

        /// <summary>
        /// Replaces the items in the list.
        /// </summary>
        public void Replace(IEnumerable<T> newItems)
        {
            var newItemsList = new List<T>(newItems);
            int newItemsCount = newItemsList.Count;
            if (newItemsCount <= 0)
            {
                Clear();
                return;
            }

            int replaceCount = newItemsCount >= Count ? Count : newItemsCount;            
            for (int i = 0; i < replaceCount; ++i)
            {
                _list[i] = newItemsList[i];
            }

            if (replaceCount > 0)
            {
                ListChanged?.Invoke(this, new ListChangedEventArgs { ListChangeAction = ListChangeAction.Replace, StartIndex = 0, EndIndex = replaceCount - 1 });
            }

            if (newItemsCount > Count)
            {
                // old list smaller than new - add items
                AddRange(newItemsList.Skip(replaceCount));
            }
            else if (newItemsCount < Count)
            {
                // old list larger than new - remove items
                RemoveRange(newItemsCount, Count - newItemsCount);
            }
        }

        /// <summary>
        /// Replaces a single item in the list.
        /// </summary>
        public void Replace(int index, T item)
        {
            if (index < 0 || index >= Count)
                return;

            _list[index] = item;
            ListChanged?.Invoke(this, new ListChangedEventArgs { ListChangeAction = ListChangeAction.Replace, StartIndex = index, EndIndex = index });
        }

        /// <summary>
        /// Informs observers that item has been modified.
        /// </summary>
        public void ItemModified(T item)
        {
            int index = IndexOf(item);
            if (index < 0)
                return;

            ItemsModified(index, index);
        }

        /// <summary>
        /// Informs observers that item has been modified.
        /// </summary>
        public void ItemModified(int index)
        {
            if (index < 0 || index >= Count)
                return;
            
            ItemsModified(index, index);            
        }

        /// <summary>
        /// Informs observers that all items have been modified.
        /// </summary>
        public void ItemsModified()
        {
            if (Count <= 0)
                return;

            ListChanged?.Invoke(this, new ListChangedEventArgs { ListChangeAction = ListChangeAction.Modify, StartIndex = 0, EndIndex = Count - 1 });
        }

        /// <summary>
        /// Informs observers that items have been modified.
        /// </summary>
        public void ItemsModified(int startIndex, int endIndex)
        {
            ListChanged?.Invoke(this, new ListChangedEventArgs { ListChangeAction = ListChangeAction.Modify, StartIndex = startIndex, EndIndex = endIndex });
        }

        /// <summary>
        /// Returns list as read-only collection.
        /// </summary>
        public ReadOnlyCollection<T> AsReadOnly()
        {
            return _list.AsReadOnly();
        }

        /// <summary>
        /// Performs a binary search on the sorted list using default comparer and returning a zero-based index of the item.
        /// </summary>
        public int BinarySearch(T item)
        {
            return _list.BinarySearch(item);
        }

        /// <summary>
        /// Performs a binary search on the sorted list using default comparer and returning a zero-based index of the item.
        /// </summary>
        public int BinarySearch(T item, IComparer<T> comparer)
        {
            return _list.BinarySearch(item, comparer);
        }

        /// <summary>
        /// Performs a binary search on the sorted list using default comparer and returning a zero-based index of the item.
        /// </summary>
        public int BinarySearch(int index, int count, T item, IComparer<T> comparer)
        {
            return _list.BinarySearch(index, count, item, comparer);
        }

        /// <summary>
        /// Removes all items from the list.
        /// </summary>
        public void Clear()
        {
            if (_list.Count > 0)
            {
                _list.Clear();
                ListChanged?.Invoke(this, new ListChangedEventArgs { ListChangeAction = ListChangeAction.Clear });
            }
        }

        /// <summary>
        /// Returns boolean indicating if list contains the item.
        /// </summary>
        public bool Contains(T item)
        {
            return _list.Contains(item);
        }

        /// <summary>
        /// Converts the items in the list to another type and returns a new list.
        /// </summary>
        public List<TOutput> ConvertAll<TOutput>(Converter<T, TOutput> converter)
        {
            return _list.ConvertAll(converter);
        }

        /// <summary>
        /// Copies the list to an array.
        /// </summary>
        public void CopyTo(T[] array)
        {
            _list.CopyTo(array);
        }

        /// <summary>
        /// Copies the list to an array.
        /// </summary>
        public void CopyTo(T[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Copies the list to an array.
        /// </summary>
        public void CopyTo(int index, T[] array, int arrayIndex, int count)
        {
            _list.CopyTo(index, array, arrayIndex, count);
        }
        
        /// <summary>
        /// Returns boolean indicating if an item matching the predicate exists in the list.
        /// </summary>
        public bool Exists(Predicate<T> predicate)
        {
            return _list.Exists(predicate);
        }

        /// <summary>
        /// Returns first item matching the predicate.
        /// </summary>
        public T Find(Predicate<T> predicate)
        {
            return _list.Find(predicate);
        }

        /// <summary>
        /// Returns all items that matches the predicate.
        /// </summary>
        public List<T> FindAll(Predicate<T> predicate)
        {
            return _list.FindAll(predicate);
        }

        /// <summary>
        /// Returns the index of the item matching the predicate.
        /// </summary>
        public int FindIndex(Predicate<T> predicate)
        {
            return _list.FindIndex(predicate);
        }

        /// <summary>
        /// Returns the index of the item matching the predicate.
        /// </summary>
        public int FindIndex(int startIndex, Predicate<T> predicate)
        {
            return _list.FindIndex(startIndex, predicate);
        }
        
        /// <summary>
        /// Returns the index of the item matching the predicate.
        /// </summary>
        public int FindIndex(int startIndex, int count, Predicate<T> predicate)
        {
            return _list.FindIndex(startIndex, count, predicate);
        }

        /// <summary>
        /// Returns the last item matching the predicate.
        /// </summary>
        public T FindLast(Predicate<T> predicate)
        {
            return _list.FindLast(predicate);
        }

        /// <summary>
        /// Returns the index of the last item matching the predicate.
        /// </summary>
        public int FindLastIndex(Predicate<T> predicate)
        {
            return _list.FindLastIndex(predicate);
        }

        /// <summary>
        /// Returns the index of the last item matching the predicate.
        /// </summary>
        public int FindLastIndex(int startIndex, Predicate<T> predicate)
        {
            return _list.FindLastIndex(startIndex, predicate);
        }

        /// <summary>
        /// Returns the index of the last item matching the predicate.
        /// </summary>
        public int FindLastIndex(int startIndex, int count, Predicate<T> predicate)
        {
            return _list.FindLastIndex(startIndex, count, predicate);
        }

        /// <summary>
        /// Performs an action on each item in the list.
        /// </summary>
        public void ForEach(Action<T> action)
        {
            _list.ForEach(action);
        }

        /// <summary>
        /// Gets list enumerator.
        /// </summary>
        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        /// <summary>
        /// Gets list enumerator.
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Creates a shallow copies of the specified range of items in the list.
        /// </summary>
        public List<T> GetRange(int index, int count)
        {
            return _list.GetRange(index, count);
        }

        /// <summary>
        /// Gets the index of the specified item.
        /// </summary>
        public int IndexOf(T item)
        {
            return _list.IndexOf(item);
        }

        /// <summary>
        /// Gets the index of the specified item.
        /// </summary>
        public int IndexOf(T item, int startIndex)
        {
            return _list.IndexOf(item, startIndex);
        }

        /// <summary>
        /// Gets the index of the specified item.
        /// </summary>
        public int IndexOf(T item, int startIndex, int count)
        {
            return _list.IndexOf(item, startIndex, count);
        }

        /// <summary>
        /// Inserts an item into the list at the specified index.
        /// </summary>
        public void Insert(int index, T item)
        {
            _list.Insert(index, item);
            ListChanged?.Invoke(this, new ListChangedEventArgs { ListChangeAction = ListChangeAction.Add, StartIndex = index, EndIndex = index });
        }

        /// <summary>
        /// Inserts a range of items at the specified index.
        /// </summary>
        public void InsertRange(int startIndex, IEnumerable<T> collection)
        {
            int itemCount = collection.Count();
            int endIndex = startIndex + (itemCount - 1);
            _list.InsertRange(startIndex, collection);
            ListChanged?.Invoke(this, new ListChangedEventArgs { ListChangeAction = ListChangeAction.Add, StartIndex = startIndex, EndIndex = endIndex });
        }

        /// <summary>
        /// Gets the last index of the specified item.
        /// </summary>
        public int LastIndexOf(T item)
        {
            return _list.LastIndexOf(item);
        }

        /// <summary>
        /// Gets the last index of the specified item.
        /// </summary>
        public int LastIndexOf(T item, int startIndex)
        {
            return _list.LastIndexOf(item, startIndex);
        }

        /// <summary>
        /// Gets the last index of the specified item.
        /// </summary>
        public int LastIndexOf(T item, int startIndex, int count)
        {
            return _list.LastIndexOf(item, startIndex, count);
        }

        /// <summary>
        /// Removes the first occurance of an item from the list.
        /// </summary>
        public bool Remove(object item)
        {
            return Remove((T)item);
        }

        /// <summary>
        /// Removes the first occurance of an item from the list.
        /// </summary>
        public bool Remove(T item)
        {
            int index = _list.IndexOf(item);
            if (index >= 0)
            {             
                RemoveAt(index);
                return true;
            }

            return false;
        }
        
        /// <summary>
        /// Removes the items from the list.
        /// </summary>
        public void Remove(IEnumerable items)
        {
            var toRemove = new List<T>(items.OfType<T>());
            foreach (var item in toRemove)
            {
                Remove(item);
            }
        }

        /// <summary>
        /// Removes all items that matches the predicate.
        /// </summary>
        public int RemoveAll(Predicate<T> predicate)
        {
            int removedCount = 0;
            for (int i = _list.Count - 1; i >= 0; --i)
            {
                if (predicate(_list[i]))
                {
                    RemoveAt(i);
                    ++removedCount;
                }
            }
            
            return removedCount;
        }

        /// <summary>
        /// Removes item at the specified index.
        /// </summary>
        public void RemoveAt(int index)
        {
            _list.RemoveAt(index);
            ListChanged?.Invoke(this, new ListChangedEventArgs { ListChangeAction = ListChangeAction.Remove, StartIndex = index, EndIndex = index });
        }

        /// <summary>
        /// Removes a range of items from the list.
        /// </summary>
        public void RemoveRange(int startIndex, int count)
        {
            int endIndex = startIndex + (count - 1);
            _list.RemoveRange(startIndex, count);
            ListChanged?.Invoke(this, new ListChangedEventArgs { ListChangeAction = ListChangeAction.Remove, StartIndex = startIndex, EndIndex = endIndex });
        }

        /// <summary>
        /// Reverses the order of the list.
        /// </summary>
        public void Reverse()
        {
            _list.Reverse();
            ListChanged?.Invoke(this, new ListChangedEventArgs { ListChangeAction = ListChangeAction.Rearranged });
        }

        /// <summary>
        /// Reverses the order of the items in the specified range.
        /// </summary>
        public void Reverse(int startIndex, int count)
        {
            _list.Reverse(startIndex, count);
            ListChanged?.Invoke(this, new ListChangedEventArgs { ListChangeAction = ListChangeAction.Rearranged });
        }

        /// <summary>
        /// Sorts the list using the default comparer.
        /// </summary>
        public void Sort()
        {
            _list.Sort();
            ListChanged?.Invoke(this, new ListChangedEventArgs { ListChangeAction = ListChangeAction.Rearranged });
        }

        /// <summary>
        /// Sorts the list.
        /// </summary>
        public void Sort(Comparison<T> comparison)
        {
            _list.Sort(comparison);
            ListChanged?.Invoke(this, new ListChangedEventArgs { ListChangeAction = ListChangeAction.Rearranged });
        }

        /// <summary>
        /// Sorts the list.
        /// </summary>
        public void Sort(IComparer<T> comparer)
        {
            _list.Sort(comparer);
            ListChanged?.Invoke(this, new ListChangedEventArgs { ListChangeAction = ListChangeAction.Rearranged });
        }

        /// <summary>
        /// Sorts the list.
        /// </summary>
        public void Sort(int startIndex, int count, IComparer<T> comparer)
        {
            _list.Sort(startIndex, count, comparer);
            ListChanged?.Invoke(this, new ListChangedEventArgs { ListChangeAction = ListChangeAction.Rearranged });
        }

        /// <summary>
        /// Copies the list to an array.
        /// </summary>
        public T[] ToArray()
        {
            return _list.ToArray();
        }

        /// <summary>
        /// Sets capacity to the number of items in the list.
        /// </summary>
        public void TrimExcess()
        {
            _list.TrimExcess();
        }

        /// <summary>
        /// Returns boolean indicating if all items matches the predicate.
        /// </summary>
        public bool TrueForAll(Predicate<T> predicate)
        {
            return _list.TrueForAll(predicate);
        }

        /// <summary>
        /// Sets selected item without notifying observers.
        /// </summary>
        public void SetSelected(object item)
        {
            _selectedItem = item;
        }

        /// <summary>
        /// Gets index of an item.
        /// </summary>
        public int GetIndex(object item)
        {
            return item != null ? IndexOf((T)item) : -1;
        }

        /// <summary>
        /// Scrolls to item.
        /// </summary>
        public void ScrollTo(T item, ElementAlignment? alignment = null, ElementMargin offset = null)
        {
            int index = _list.IndexOf(item);
            if (index >= 0)
            {
                ScrollTo(index, alignment, offset);
            }
        }

        /// <summary>
        /// Scrolls to item.
        /// </summary>
        public void ScrollTo(int index, ElementAlignment? alignment = null, ElementMargin offset = null)
        {
            ListChanged?.Invoke(this, new ListChangedEventArgs { ListChangeAction = ListChangeAction.ScrollTo, StartIndex = index, EndIndex = index, Alignment = alignment });
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the capacity of the list.
        /// </summary>
        public int Capacity
        {
            get
            {
                return _list.Capacity;
            }
            set
            {
                _list.Capacity = value;
            }
        }

        /// <summary>
        /// Gets the number of items in the list.
        /// </summary>
        public int Count
        {
            get
            {
                return _list.Count;
            }
        }

        /// <summary>
        /// Gets item at index.
        /// </summary>
        object IObservableList.this[int index]
        {
            get
            {
                return this[index];
            }
        }

        /// <summary>
        /// Gets or sets the item at the specified index.
        /// </summary>
        public T this[int index]
        {
            get
            {
                return _list[index];
            }
            set
            {
                var currentItem = _list[index];
                bool valueChanged = value != null ? !value.Equals(currentItem) : currentItem != null;
                if (valueChanged)
                {
                    _list[index] = value;
                    ListChanged?.Invoke(this, new ListChangedEventArgs { ListChangeAction = ListChangeAction.Replace, StartIndex = index, EndIndex = index });
                }
            }
        }

        /// <summary>
        /// Gets or sets the selected item.
        /// </summary>
        public T SelectedItem
        {
            get
            {
                return _selectedItem != null ? (T)_selectedItem : default(T);
            }
            set
            {
                SelectedIndex = IndexOf(value);
            }
        }

        /// <summary>
        /// Gets or sets the selected index.
        /// </summary>
        public int SelectedIndex
        {
            get
            {
                return _selectedItem != null ? IndexOf((T)_selectedItem) : -1;
            }
            set
            {
                if (value < 0 || value >= Count)
                {
                    _selectedItem = null;
                    return;
                }

                int currentIndex = SelectedIndex;
                if (currentIndex != value)
                {
                    _selectedItem = this[value];
                    ListChanged?.Invoke(this, new ListChangedEventArgs { ListChangeAction = ListChangeAction.Select, StartIndex = value, EndIndex = value });
                }
            }
        }

        #endregion
    }
}
