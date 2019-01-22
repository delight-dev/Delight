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
    /// Contains a subset of items from a parent collection.
    /// </summary>
    public class BindableCollectionSubset<T> : BindableCollection<T>
        where T : BindableObject
    {
        #region Fields

        protected BindableCollection<T> _parentCollection;
        protected Func<T, bool> _filter;

        #endregion

        #region Properties

        protected override Dictionary<string, T> Data
        {
            get
            {
                if (_needUpdate)
                {
                    Update();
                }

                return _data;
            }
        }

        private bool _needUpdate = true;

        #endregion

        #region Constructor

        public BindableCollectionSubset(BindableCollection<T> parentCollection, Func<T, bool> filter)
        {
            _parentCollection = parentCollection;
            _parentCollection.CollectionChanged += ParentCollection_CollectionChanged;
            _filter = filter;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Updates collection.
        /// </summary>
        private void Update()
        {
            _needUpdate = false;
            Data.Clear();
            foreach (var item in _parentCollection)
            {
                if (_filter(item))
                {
                    Data.Add(item.Id, item);
                }
            }
        }

        /// <summary>
        /// Called when the parent collection has been modified. 
        /// </summary>
        private void ParentCollection_CollectionChanged(object source, CollectionChangedEventArgs e)
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
                    if (_filter(e.Item as T))
                    {
                        OnCollectionChanged(e);
                    }
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
            // TODO update item foreign keys to fit into this subset
            // if the keys aren't empty and doesn't fit into this condition we should
            // throw a warning and invalidate the whole operation

            _parentCollection.CollectionChanged -= ParentCollection_CollectionChanged;
            _parentCollection.Add(item);
            _parentCollection.CollectionChanged += ParentCollection_CollectionChanged;

            base.Add(item);
        }

        public override void Clear()
        {
            _parentCollection.CollectionChanged -= ParentCollection_CollectionChanged;
            _parentCollection.RemoveRange(Data.Values);
            _parentCollection.CollectionChanged += ParentCollection_CollectionChanged;

            base.Clear();
        }

        public override void Replace(IEnumerable<T> items)
        {
            // TODO update item foreign keys to fit into this subset
            // if the keys aren't empty and doesn't fit into this condition we should
            // throw a warning and invalidate the whole operation

            _parentCollection.CollectionChanged -= ParentCollection_CollectionChanged;
            _parentCollection.Replace(items);
            _parentCollection.CollectionChanged += ParentCollection_CollectionChanged;

            base.Replace(items);
        }

        public override bool Contains(T item)
        {
            return Data.ContainsKey(item.Id);
        }

        public override bool Remove(T item)
        {
            _parentCollection.CollectionChanged -= ParentCollection_CollectionChanged;
            _parentCollection.Remove(item);
            _parentCollection.CollectionChanged += ParentCollection_CollectionChanged;

            return base.Remove(item);
        }

        public override void RemoveRange(IEnumerable<T> items)
        {
            _parentCollection.CollectionChanged -= ParentCollection_CollectionChanged;
            _parentCollection.RemoveRange(items);
            _parentCollection.CollectionChanged += ParentCollection_CollectionChanged;

            base.RemoveRange(items);
        }

        public override IEnumerator<T> GetEnumerator()
        {
            return Data.Values.GetEnumerator();
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
}
