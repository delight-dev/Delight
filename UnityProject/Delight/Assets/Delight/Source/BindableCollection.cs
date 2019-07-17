#region Using Statements
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
#endregion

namespace Delight
{
    /// <summary>
    /// Base class for bindable generic collections. Bindable collections notifies observers when the collection changes and enables e.g. the List view to update when items are added.
    /// </summary>
    public partial class BindableCollection<T> : BindableCollection, IEnumerable<T>
        where T : BindableObject
    {
        #region Fields

        protected Dictionary<string, T> _data = new Dictionary<string, T>();
        protected List<KeyValuePair<string, T>> _dataList = new List<KeyValuePair<string, T>>();
        protected bool _batchNotifications = false;
        protected List<CollectionChangedEventArgs> _collectionChangedEventArgsBatch = new List<CollectionChangedEventArgs>();
        protected bool _suppressNotifications = false;

        #endregion

        #region Properties

        public virtual T this[string id]
        {
            get
            {
                if (id == null)
                    return null;

                T item;
                if (Data.TryGetValue(id, out item))
                {
                    return item;
                }
                return null;
            }
        }

        public virtual T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                    return null;

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

        public override BindableObject Get(string id)
        {
            return this[id];
        }

        public override BindableObject Get(int index)
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

        public virtual void AddRange(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                Add(item);
            }
        }

        public virtual void Add(T item)
        {
            if (String.IsNullOrEmpty(item.Id))
            {
                item.Id = Guid.NewGuid().ToString();
            }
            else if (Data.ContainsKey(item.Id))
            {
                Debug.LogWarning(String.Format("#Delight# BindableCollection<{0}>: attempt to add item \"{1}\" already in the collection.", typeof(T).Name, item.Id));
                return;
            }

            Data.Add(item.Id, item);
            DataList.Add(new KeyValuePair<string, T>(item.Id, item));

            Notify(new CollectionChangedEventArgs
            {
                ChangeAction = CollectionChangeAction.Add,
                Item = item
            });
            OnPropertyChanged(item.Id);
        }

        public virtual void Insert(int index, T item)
        {
            if (String.IsNullOrEmpty(item.Id))
            {
                item.Id = Guid.NewGuid().ToString();
            }
            else if (Data.ContainsKey(item.Id))
            {
                Debug.LogWarning(String.Format("#Delight# BindableCollection<{0}>: attempt to insert item \"{1}\" already in the collection.", typeof(T).Name, item.Id));
                return;
            }

            Data.Add(item.Id, item);
            DataList.Insert(index, new KeyValuePair<string, T>(item.Id, item));

            Notify(new CollectionChangedEventArgs
            {
                ChangeAction = CollectionChangeAction.Replace
            });
            OnPropertyChanged(item.Id);
        }

        public virtual void Clear()
        {
            Data.Clear();
            DataList.Clear();
            Notify(new CollectionChangedEventArgs
            {
                ChangeAction = CollectionChangeAction.Clear
            });
        }

        private void Notify(CollectionChangedEventArgs eventArgs)
        {
            if (_suppressNotifications)
                return;

            if (_batchNotifications)
                _collectionChangedEventArgsBatch.Add(eventArgs);
            else
                OnCollectionChanged(eventArgs);
        }

        public virtual void Replace(IEnumerable<T> items)
        {
            Data.Clear();
            DataList.Clear();
            foreach (var item in items)
            {
                Data.Add(item.Id, item);
                DataList.Add(new KeyValuePair<string, T>(item.Id, item));
            }
            Notify(new CollectionChangedEventArgs
            {
                ChangeAction = CollectionChangeAction.Replace
            });
        }

        // TODO remove, here for backwards compatilibity with MarkLight
        public void ItemsModified()
        {
            Notify(new CollectionChangedEventArgs
            {
                ChangeAction = CollectionChangeAction.Replace
            });
        }

        // TODO remove, here for backwards compatilibity with MarkLight
        public void ItemsModified(string fieldPath)
        {
            Notify(new CollectionChangedEventArgs
            {
                ChangeAction = CollectionChangeAction.Replace
            });
        }

        // TODO remove, here for backwards compatilibity with MarkLight
        public void ItemModified(T item, string fieldPath = "")
        {
            Notify(new CollectionChangedEventArgs
            {
                ChangeAction = CollectionChangeAction.Replace
            });
        }

        // TODO remove, here for backwards compatilibity with MarkLight
        public void ItemModified(int index, string fieldPath = "")
        {
            Notify(new CollectionChangedEventArgs
            {
                ChangeAction = CollectionChangeAction.Replace
            });
        }

        public virtual bool Contains(T item)
        {
            return Data.ContainsKey(item.Id);
        }

        public virtual bool RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
                return false;

            return Remove(this[index]);
        }

        public virtual bool Remove(T item)
        {
            // TODO we might want a dictionary to keep track of index to make this O(1)
            bool wasRemoved = Data.Remove(item.Id);
            if (wasRemoved)
            {
                for (int i = 0; i < Count; ++i)
                {
                    if (_dataList[i].Value == item)
                    {
                        DataList.RemoveAt(i);
                        break;
                    }
                }

                Notify(new CollectionChangedEventArgs
                {
                    ChangeAction = CollectionChangeAction.Remove,
                    Item = item
                });
                return true;
            }

            return false;
        }

        public virtual void SelectAndScrollTo(int index, ElementAlignment? alignment = null, ElementMargin offset = null)
        {
            if (index < 0 || index >= Count)
                return;

            SelectAndScrollTo(this[index], alignment, offset, true);
        }

        public virtual void SelectAndScrollTo(T item, ElementAlignment? alignment = null, ElementMargin offset = null, bool scrollTo = false)
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

        public virtual void RemoveRange(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                Remove(item);
            }
        }

        /// <summary>
        /// Returns first item matching the predicate.
        /// </summary>
        public T Find(Predicate<T> predicate)
        {
            foreach (var item in _dataList)
            {
                if (predicate(item.Value))
                    return item.Value;
            }

            return null;
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
            foreach (var item in _dataList)
            {
                if (predicate(item.Value))
                    return item.Value;
            }
            return null;
        }

        public bool Any()
        {
            return Count > 0;
        }

        public bool Any(Func<T, bool> predicate)
        {
            foreach (var item in _dataList)
            {
                if (predicate(item.Value))
                    return true;
            }
            return false;
        }

        public int IndexOf(T item)
        {
            // TODO we might want a dictionary to keep track of index to make it O(1)
            for (int i = 0; i < Count; ++i)
            {
                if (_dataList[i].Value == item)
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
    public abstract partial class BindableCollection : BindableObject, IEnumerable<BindableObject>, INotifyCollectionChanged
    {
        #region Fields

        public event CollectionChangedEventHandler CollectionChanged;

        #endregion

        #region Properties

        public abstract int Count { get; }

        #endregion

        #region Methods

        public abstract BindableObject Get(string id);
        public abstract BindableObject Get(int index);
        protected virtual void UpdateData()
        {
        }

        /// <summary>
        /// Notifies listeners that collection has been changed.
        /// </summary>
        public void OnCollectionChanged(CollectionChangedEventArgs eventArgs)
        {
            CollectionChanged?.Invoke(this, eventArgs);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<BindableObject> GetEnumerator()
        {
            UpdateData();
            for (int i = 0; i < Count; ++i)
            {
                yield return Get(i);
            }
        }

        #endregion
    }
}
