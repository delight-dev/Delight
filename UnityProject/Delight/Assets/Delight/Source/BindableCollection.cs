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
    /// Base class for bindable generic collections.
    /// </summary>
    public class BindableCollection<T> : BindableCollection, IEnumerable<T>
        where T : BindableObject
    {
        #region Fields

        protected Dictionary<string, T> _data = new Dictionary<string, T>();
        protected List<KeyValuePair<string, T>> _dataList = new List<KeyValuePair<string, T>>();
        protected bool _batchNotifications = false;
        protected List<CollectionChangedEventArgs> _collectionChangedEventArgsBatch = new List<CollectionChangedEventArgs>();

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
                Debug.LogWarning(String.Format("[Delight] BindableCollection<{0}>: attempt to add item \"{1}\" already in the collection.", typeof(T).Name, item.Id));
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

        public virtual bool Contains(T item)
        {
            return Data.ContainsKey(item.Id);
        }

        public virtual bool Remove(T item)
        {
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

        public virtual void RemoveRange(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                Remove(item);
            }
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
    /// Base class for bindable collections.
    /// </summary>
    public abstract class BindableCollection : BindableObject, IEnumerable<BindableObject>, INotifyCollectionChanged
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
