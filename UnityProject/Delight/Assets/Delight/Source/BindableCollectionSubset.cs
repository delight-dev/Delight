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
    /// Contains a subset of items from a parent bindable collection. It's automatically updated when the parent collection changes and allows for things like filtered collections. 
    /// </summary>
    public class BindableCollectionSubset<T> : BindableCollection<T>
        where T : BindableObject
    {
        #region Fields

        protected BindableCollection<T> _parentCollection;
        protected Func<T, bool> _filter;
        protected Action<T> _fkSetter;
        private bool _needUpdate = true;

        #endregion

        #region Constructor

        public BindableCollectionSubset(BindableCollection<T> parentCollection, Func<T, bool> filter, Action<T> fkSetter)
        {
            _parentCollection = parentCollection;
            _parentCollection.CollectionChanged += ParentCollectionChanged;
            _filter = filter;
            _fkSetter = fkSetter;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Called when the parent collection has been modified. 
        /// </summary>
        private void ParentCollectionChanged(object source, CollectionChangedEventArgs e)
        {
            switch (e.ChangeAction)
            {
                case CollectionChangeAction.Add:
                    if (_filter(e.Item as T))
                    {
                        base.Add(e.Item as T);
                    }
                    break;
                case CollectionChangeAction.Remove:
                    if (_filter(e.Item as T))
                    {
                        base.Remove(e.Item as T);
                    }
                    break;
                case CollectionChangeAction.Replace:
                    _data.Clear();
                    _needUpdate = true;
                    OnCollectionChanged(e);
                    break;
                case CollectionChangeAction.Clear:
                    base.Clear();
                    break;
            }
        }

        public override BindableObject Get(string id)
        {
            return this[id];
        }

        public override void Add(T item)
        {
            if (_fkSetter != null)
                _fkSetter(item);

            base.Add(item);

            _parentCollection.CollectionChanged -= ParentCollectionChanged;
            _parentCollection.Add(item);
            _parentCollection.CollectionChanged += ParentCollectionChanged;
        }

        public override void Clear()
        {
            base.Clear();

            _parentCollection.CollectionChanged -= ParentCollectionChanged;
            _parentCollection.RemoveRange(Data.Values);
            _parentCollection.CollectionChanged += ParentCollectionChanged;
        }

        public override void Replace(IEnumerable<T> items)
        {
            if (_fkSetter != null)
            {
                foreach (var item in items)
                {
                    _fkSetter(item);
                }
            }

            base.Replace(items);

            _parentCollection.CollectionChanged -= ParentCollectionChanged;
            _parentCollection.Replace(items);
            _parentCollection.CollectionChanged += ParentCollectionChanged;
        }

        public override bool Contains(T item)
        {
            return Data.ContainsKey(item.Id);
        }

        public override bool Remove(T item)
        {
            var result = base.Remove(item);

            _parentCollection.CollectionChanged -= ParentCollectionChanged;
            _parentCollection.Remove(item);
            _parentCollection.CollectionChanged += ParentCollectionChanged;

            return result;
        }

        public override void RemoveRange(IEnumerable<T> items)
        {
            base.RemoveRange(items);

            _parentCollection.CollectionChanged -= ParentCollectionChanged;
            _parentCollection.RemoveRange(items);
            _parentCollection.CollectionChanged += ParentCollectionChanged;
        }

        /// <summary>
        /// Updates collection if necessary.
        /// </summary>
        protected override void UpdateData()
        {
            base.UpdateData();
            if (!_needUpdate)
                return;

            _needUpdate = false;
            Data.Clear();
            DataList.Clear();
            foreach (var item in _parentCollection)
            {
                if (_filter(item))
                {
                    Data.Add(item.Id, item);
                    DataList.Add(new KeyValuePair<string, T>(item.Id, item));
                }
            }
        }

        #endregion
    }
}
