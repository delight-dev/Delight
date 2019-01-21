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

        #endregion

        #region Properties

        public virtual T this[string id]
        {
            get
            {
                T item;
                if (_data.TryGetValue(id, out item))
                {
                    return item;
                }
                return null;
            }
            set
            {
            }
        }

        public override int Count => _data.Count;

        #endregion

        #region Methods

        public override BindableObject GetItem(string id)
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
            else if (_data.ContainsKey(item.Id))
            {
                return; 
            }

            _data.Add(item.Id, item);
            OnCollectionChanged(new CollectionChangedEventArgs
            {
                ChangeAction = CollectionChangeAction.Add,
                Id = item.Id
            });
        }

        public virtual void Clear()
        {
            _data.Clear();
            OnCollectionChanged(new CollectionChangedEventArgs
            {
                ChangeAction = CollectionChangeAction.Clear
            });
        }

        public virtual bool Contains(T item)
        {
            return _data.ContainsKey(item.Id);
        }

        public virtual bool Remove(T item)
        {
            bool wasRemoved = _data.Remove(item.Id);
            if (wasRemoved)
            {
                OnCollectionChanged(new CollectionChangedEventArgs
                {
                    ChangeAction = CollectionChangeAction.Remove,
                    Id = item.Id
                });
                return true;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _data.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override IEnumerable<BindableObject> GetDataEnumerator()
        {
            foreach (var data in _data.Values)
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
        public abstract BindableObject GetItem(string id);

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
