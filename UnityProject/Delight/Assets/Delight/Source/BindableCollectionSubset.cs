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
        protected Action<T> _fkSetter;

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

            _parentCollection.CollectionChanged -= ParentCollectionChanged;
            _parentCollection.Add(item);
            _parentCollection.CollectionChanged += ParentCollectionChanged;

            base.Add(item);
        }

        public override void Clear()
        {
            _parentCollection.CollectionChanged -= ParentCollectionChanged;
            _parentCollection.RemoveRange(Data.Values);
            _parentCollection.CollectionChanged += ParentCollectionChanged;

            base.Clear();
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

            _parentCollection.CollectionChanged -= ParentCollectionChanged;
            _parentCollection.Replace(items);
            _parentCollection.CollectionChanged += ParentCollectionChanged;

            base.Replace(items);
        }

        public override bool Contains(T item)
        {
            return Data.ContainsKey(item.Id);
        }

        public override bool Remove(T item)
        {
            _parentCollection.CollectionChanged -= ParentCollectionChanged;
            _parentCollection.Remove(item);
            _parentCollection.CollectionChanged += ParentCollectionChanged;

            return base.Remove(item);
        }

        public override void RemoveRange(IEnumerable<T> items)
        {
            _parentCollection.CollectionChanged -= ParentCollectionChanged;
            _parentCollection.RemoveRange(items);
            _parentCollection.CollectionChanged += ParentCollectionChanged;

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
