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
    public abstract class BindableCollection<T> : BindableObject, IBindableCollection, IEnumerable<T>
    {
        #region Fields

        public event CollectionChangedEventHandler CollectionChanged;
        protected List<T> _data = new List<T>();

        #endregion

        #region Properties

        public int Count => _data != null ? _data.Count : 0;
        public bool IsReadOnly => false;

        /// <summary>
        /// Gets or sets the item at the specified index.
        /// </summary>
        public T this[int index]
        {
            get
            {
                return _data[index];
            }
        }

        #endregion

        #region Methods

        public void Edit(Action edit)
        {
            // TODO here we want to implement batch edit of collection so just a single change 
            // notification is sent, by setting a internal bool _batchNotifications and letting Add, Remove, etc. check the bool and queue the notifications
            edit();
        }

        public void Add(T item)
        {
            int index = _data.Count;
            _data.Add(item);
            OnCollectionChanged(new CollectionChangedEventArgs
            {
                ChangeAction = CollectionChangeAction.Add,
                Index = index
            });
        }

        public void Clear()
        {
            _data.Clear();
        }

        public bool Contains(T item)
        {
            return _data.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _data.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            return _data.Remove(item);
        }

        /// <summary>
        /// Gets enumerator for collection.
        /// </summary>
        public IEnumerator<T> GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        /// <summary>
        /// Gets enumerator for collection.
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Notifies listeners that collection has been changed.
        /// </summary>
        public void OnCollectionChanged(CollectionChangedEventArgs eventArgs)
        {
            CollectionChanged?.Invoke(this, eventArgs);
        }

        #region IBindableCollection

        public void Add(object item)
        {
            Add((T)item);
        }

        public void Add(IEnumerable items)
        {
            foreach (var item in items)
            {
                Add((T)item);
            }
        }

        public bool Remove(object item)
        {
            throw new NotImplementedException();
        }

        public void Remove(IEnumerable items)
        {
            throw new NotImplementedException();
        }

        public void SetSelected(object item)
        {
            throw new NotImplementedException();
        }

        public int GetIndex(object item)
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion
    }
}
