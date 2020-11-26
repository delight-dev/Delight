#region Using Statements
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine;
#endregion

namespace Delight
{
    /// <summary>
    /// Base class for bindable generic collections. Bindable collections notifies observers when the collection changes and enables e.g. the List view to update when items are added.
    /// </summary>
    public partial class BindableCollection<T> : BindableCollection, IEnumerable<T>
    {
        #region Fields

        protected Dictionary<string, T> _data = new Dictionary<string, T>();
        protected List<KeyValuePair<string, T>> _dataList = new List<KeyValuePair<string, T>>();
        protected bool _batchNotifications = false;
        protected List<CollectionChangedEventArgs> _collectionChangedEventArgsBatch = new List<CollectionChangedEventArgs>();
        protected bool _suppressNotifications = false;
        public static bool IsBindableObject = typeof(BindableObject).IsAssignableFrom(typeof(T));

        #endregion

        #region Properties

        public virtual T this[string id]
        {
            get
            {
                if (id == null)
                    return default(T);

                T item;
                if (Data.TryGetValue(id, out item))
                {
                    return item;
                }
                return default(T);
            }
        }

        public virtual T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                    return default(T);

                return DataList[index].Value;
            }
        }

        protected virtual Dictionary<string, T> Data
        {
            get
            {
                UpdateData();
                return _data;
            }
        }

        protected virtual List<KeyValuePair<string, T>> DataList
        {
            get
            {
                UpdateData();
                return _dataList;
            }
        }

        public override int Count => Data.Count;
        public override bool IsEmpty => Data.Count <= 0;

        #endregion

        #region Constructor

        public BindableCollection()
        {
        }

        public BindableCollection(IEnumerable<T> items)
        {
            AddRange(items);
        }

        #endregion

        #region Methods

        public override object GetGeneric(string id)
        {
            return this[id];
        }

        public override object GetGeneric(int index)
        {
            return this[index];
        }

        public virtual void Edit(Action edit)
        {
            _batchNotifications = true;
            edit();
            _batchNotifications = false;
            OnCollectionChanged(new BatchedCollectionChangedEventArgs
            {
                ChangeAction = CollectionChangeAction.Batch,
                CollectionChangedEventArgsBatch = _collectionChangedEventArgsBatch.ToList()
            });
            _collectionChangedEventArgsBatch.Clear();
        }

        public string GetId(object item, bool checkSetNewId = false)
        {
            if (IsBindableObject)
            {
                var bindableObject = item as BindableObject;
                if (bindableObject == null)
                    return null;

                if (checkSetNewId && String.IsNullOrEmpty(bindableObject.Id))
                {
                    bindableObject.Id = Guid.NewGuid().ToString();
                    return bindableObject.Id;
                }
                else
                {
                    return bindableObject.Id;
                }
            }

            return item.GetHashCode().ToString();
        }

        public virtual void AddRange(IEnumerable<T> items, bool? animate = null)
        {
            var addedItems = new List<object>();
            foreach (var item in items)
            {
                string id = GetId(item, true);
                if (Data.ContainsKey(id))
                {
                    continue;
                }

                Data.Add(id, item);
                DataList.Add(new KeyValuePair<string, T>(id, item));
                OnPropertyChanged(id);
                addedItems.Add(item);
            }

            if (addedItems.Any())
            {
                Notify(new CollectionChangedRangeEventArgs
                {
                    ChangeAction = CollectionChangeAction.AddRange,
                    Items = addedItems,
                    Animate = animate
                });
            }
        }

        public virtual void Add(T item, bool? animate = null)
        {
            string id = GetId(item, true);
            if (Data.ContainsKey(id))
            {
                return;
            }

            Data.Add(id, item);
            DataList.Add(new KeyValuePair<string, T>(id, item));

            Notify(new CollectionChangedEventArgs
            {
                ChangeAction = CollectionChangeAction.Add,
                Item = item,
                Animate = animate
            });
            OnPropertyChanged(id);
        }

        public virtual void Insert(int index, T item, bool? animate = null)
        {
            string id = GetId(item, true);
            if (Data.ContainsKey(id))
            {
                return;
            }

            Data.Add(id, item);
            DataList.Insert(index, new KeyValuePair<string, T>(id, item));

            Notify(new CollectionChangedEventArgs
            {
                ChangeAction = CollectionChangeAction.Replace,
                Animate = animate
            });
            OnPropertyChanged(id);
        }

        public virtual void Clear(bool? animate = null)
        {
            Data.Clear();
            DataList.Clear();
            Notify(new CollectionChangedEventArgs
            {
                ChangeAction = CollectionChangeAction.Clear,
                Animate = animate
            });
        }

        protected void Notify(CollectionChangedEventArgs eventArgs)
        {
            if (_suppressNotifications)
                return;

            if (_batchNotifications)
                _collectionChangedEventArgsBatch.Add(eventArgs);
            else
                OnCollectionChanged(eventArgs);
        }

        public virtual void Replace(IEnumerable<T> items, bool? animate = null)
        {
            Data.Clear();
            DataList.Clear();
            foreach (var item in items)
            {
                string id = GetId(item, true);
                Data.Add(id, item);
                DataList.Add(new KeyValuePair<string, T>(id, item));
            }
            Notify(new CollectionChangedEventArgs
            {
                ChangeAction = CollectionChangeAction.Replace,
                Animate = animate
            });
        }

        // TODO here for backwards compatibility with MarkLight
        public void ItemsModified()
        {
            Notify(new CollectionChangedEventArgs
            {
                ChangeAction = CollectionChangeAction.Replace
            });
        }

        public virtual bool Contains(T item)
        {
            return Data.ContainsKey(GetId(item));
        }

        public virtual bool RemoveAt(int index, bool? animate = null)
        {
            if (index < 0 || index >= Count)
                return false;

            return Remove(this[index], animate);
        }

        public virtual bool Remove(T item, bool? animate = null)
        {
            // TODO we might want a dictionary to keep track of index to make this O(1)
            bool wasRemoved = Data.Remove(GetId(item));
            if (wasRemoved)
            {
                for (int i = 0; i < DataList.Count; ++i)
                {
                    if (EqualityComparer<T>.Default.Equals(_dataList[i].Value, item))
                    {
                        DataList.RemoveAt(i);
                        break;
                    }
                }

                Notify(new CollectionChangedEventArgs
                {
                    ChangeAction = CollectionChangeAction.Remove,
                    Item = item,
                    Animate = animate
                });
                return true;
            }

            return false;
        }

        public virtual void RemoveRange(IEnumerable<T> items, bool? animate = null)
        {
            // TODO we might want a dictionary to keep track of index to make this O(1)
            var removedItems = new List<object>();
            foreach (var item in items)
            {
                bool wasRemoved = Data.Remove(GetId(item));
                if (wasRemoved)
                {
                    for (int i = 0; i < DataList.Count; ++i)
                    {
                        if (EqualityComparer<T>.Default.Equals(_dataList[i].Value, item))
                        {
                            DataList.RemoveAt(i);
                            removedItems.Add(item);
                            break;
                        }
                    }
                }
            }

            if (removedItems.Any())
            {
                Notify(new CollectionChangedRangeEventArgs
                {
                    ChangeAction = CollectionChangeAction.RemoveRange,
                    Items = removedItems,
                    Animate = animate
                });
            }
        }

        public virtual void Reverse()
        {
            DataList.Reverse();
        }

        public virtual void SelectAndScrollTo(int index, ElementAlignment? alignment = null, ElementMargin offset = null)
        {
            if (index < 0 || index >= Count)
                return;

            SelectAndScrollTo(this[index], alignment, offset);
        }

        public virtual void SelectAndScrollTo(T item, ElementAlignment? alignment = null, ElementMargin offset = null)
        {
            Notify(new CollectionSelectionEventArgs
            {
                ChangeAction = CollectionChangeAction.Select,
                Item = item,
                Alignment = alignment,
                Offset = offset,
                ScrollTo = true
            });
        }

        public virtual void Select(int index, ElementAlignment? alignment = null, ElementMargin offset = null)
        {
            if (index < 0 || index >= Count)
                return;

            Select(this[index], alignment, offset);
        }

        public virtual void Select(T item, ElementAlignment? alignment = null, ElementMargin offset = null, bool scrollTo = false)
        {
            Notify(new CollectionSelectionEventArgs
            {
                ChangeAction = CollectionChangeAction.Select,
                Item = item,
                Alignment = alignment,
                Offset = offset,
                ScrollTo = scrollTo
            });
        }

        public virtual void ScrollTo(int index, ElementAlignment? alignment = null, ElementMargin offset = null)
        {
            if (index < 0 || index >= Count)
                return;

            ScrollTo(this[index], alignment, offset);
        }

        public virtual void ScrollTo(T item, ElementAlignment? alignment = null, ElementMargin offset = null)
        {
            Notify(new CollectionSelectionEventArgs
            {
                ChangeAction = CollectionChangeAction.ScrollTo,
                Item = item,
                Alignment = alignment,
                Offset = offset
            });
        }

        /// <summary>
        /// Returns first item matching the predicate.
        /// </summary>
        public T Find(Predicate<T> predicate)
        {
            foreach (var item in DataList)
            {
                if (predicate(item.Value))
                    return item.Value;
            }

            return default(T);
        }

        public int FindIndex(Predicate<T> predicate)
        {
            return IndexOf(this.Find(predicate));
        }

        public T First()
        {
            return FirstOrDefault();
        }

        public T First(Func<T, bool> predicate)
        {
            return FirstOrDefault(predicate);
        }

        public T FirstOrDefault()
        {
            return this[0];
        }

        public T FirstOrDefault(Func<T, bool> predicate)
        {
            foreach (var item in DataList)
            {
                if (predicate(item.Value))
                    return item.Value;
            }
            return default(T);
        }

        public bool Any()
        {
            return Count > 0;
        }

        public bool Any(Func<T, bool> predicate)
        {
            foreach (var item in DataList)
            {
                if (predicate(item.Value))
                    return true;
            }
            return false;
        }

        public void ForEach(Action<T> action)
        {
            foreach (var item in DataList)
            {
                action(item.Value);
            }
        }

        public IEnumerable<T> Where(Func<T, bool> predicate)
        {
            foreach (var data in DataList)
            {
                if (predicate(data.Value))
                {
                    yield return data.Value;
                }
            }
        }

        public int IndexOf(T item)
        {
            // TODO we might want a dictionary to keep track of index to make it O(1)
            for (int i = 0; i < Count; ++i)
            {
                if (EqualityComparer<T>.Default.Equals(DataList[i].Value, item))
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Gets list from bindable collection.
        /// </summary>
        public List<T> ToList()
        {
            return new List<T>(this);
        }

        public new virtual IEnumerator<T> GetEnumerator()
        {
            UpdateData();
            foreach (var data in DataList)
            {
                yield return data.Value;
            }
        }

        #endregion
    }

    /// <summary>
    /// Base class for bindable collections. Bindable collections notifies observers when the collection changes and enables e.g. the List view to update when items are added.
    /// </summary>
    public abstract partial class BindableCollection : BindableObject, IEnumerable<object>, INotifyCollectionChanged
    {
        #region Fields

        public event CollectionChangedEventHandler CollectionChanged;

        #endregion

        #region Properties

        public abstract int Count { get; }
        public abstract bool IsEmpty { get; }

        #endregion

        #region Methods

        public abstract object GetGeneric(string id);
        public abstract object GetGeneric(int index);
        protected virtual void UpdateData()
        {
        }
        public virtual async Task LoadData()
        {
            await Task.FromResult(0); // to prevent compiler warning
        }


        /// <summary>
        /// Notifies listeners that collection has been changed.
        /// </summary>
        public void OnCollectionChanged(CollectionChangedEventArgs eventArgs)
        {
            OnPropertyChanged(nameof(Count));
            OnPropertyChanged(nameof(IsEmpty));
            CollectionChanged?.Invoke(this, eventArgs);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<object> GetEnumerator()
        {
            UpdateData();
            for (int i = 0; i < Count; ++i)
            {
                yield return GetGeneric(i);
            }
        }

        #endregion
    }
}
