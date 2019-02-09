#region Using Statements
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        protected virtual Dictionary<string, T> Data
        {
            get
            {
                return _data;
            }
        }

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

        public override int Count => Data.Count;

        #endregion

        #region Constructor

        public BindableCollection()
        {
        }

        public BindableCollection(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                Add(item); // TODO replace with AddRange
            }
        }

        #endregion

        #region Methods

        public override BindableObject Get(string id)
        {
            return this[id];
        }

        public virtual void Edit(Action edit)
        {
            // TODO here we want to implement batch edit of collection so just a single change 
            // notification is sent, by setting a internal bool _batchNotifications and letting Add, Remove, etc. check the bool and queue the notifications
            edit();
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
            OnCollectionChanged(new CollectionChangedEventArgs
            {
                ChangeAction = CollectionChangeAction.Add,
                Item = item
            });
        }

        public virtual void Clear()
        {
            Data.Clear();
            OnCollectionChanged(new CollectionChangedEventArgs
            {
                ChangeAction = CollectionChangeAction.Clear
            });
        }

        public virtual void Replace(IEnumerable<T> items)
        {
            Data.Clear();
            foreach (var item in items)
            {
                Data.Add(item.Id, item);
            }
            OnCollectionChanged(new CollectionChangedEventArgs
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
                OnCollectionChanged(new CollectionChangedEventArgs
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
                // TODO implement batch removes
                Remove(item);
            }            
        }

        public virtual IEnumerator<T> GetEnumerator()
        {
            return Data.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override IEnumerable<BindableObject> GetDataEnumerator()
        {
            foreach (var data in Data.Values)
            {
                yield return data;
            }
        }

        #endregion
    }

    /// <summary>
    /// Base class for bindable collections.
    /// </summary>
    public abstract class BindableCollection : BindableObject, INotifyCollectionChanged
    {
        #region Fields

        public event CollectionChangedEventHandler CollectionChanged;

        #endregion

        #region Properties

        public abstract int Count { get; }

        #endregion

        #region Methods

        public abstract IEnumerable<BindableObject> GetDataEnumerator();
        public abstract BindableObject Get(string id);

        /// <summary>
        /// Notifies listeners that collection has been changed.
        /// </summary>
        public void OnCollectionChanged(CollectionChangedEventArgs eventArgs)
        {
            CollectionChanged?.Invoke(this, eventArgs);
        }

        #endregion
    }
}
