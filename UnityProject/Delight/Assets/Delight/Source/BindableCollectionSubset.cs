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
    /// Contains a subset of items from a parent bindable collection. It's automatically updated when the parent collection changes and allows for things like filtered and sorted collections. 
    /// </summary>
    public class BindableCollectionSubset<T> : BindableCollection<T>
        where T : BindableObject
    {
        #region Fields

        protected BindableCollection<T> _parentCollection;
        protected Func<T, bool> _filter;
        protected Action<T> _fkSetter;
        private bool _needUpdate = true;
        private string[] _updateOnPropertyChanged;

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a bindable collection subset that contains items that fulfills foreign key constraints defined by the filter.
        /// Updates whenever the parent collection changes. New items added have their foreign key automatically set.
        /// </summary>
        public BindableCollectionSubset(BindableCollection<T> parentCollection,
            Func<T, bool> foreignKeyConstraint, Action<T> fkSetter)
        {
            _parentCollection = parentCollection;
            _parentCollection.CollectionChanged += ParentCollectionChanged;
            _filter = foreignKeyConstraint;
            _fkSetter = fkSetter;
        }

        /// <summary>
        /// Creates a filtered bindable collection subset that updates whenever parent collection changes or the item no longer fulfills the filter condition.
        /// </summary>
        public BindableCollectionSubset(BindableCollection<T> parentCollection,
            Func<T, bool> filter, params string[] updateOnPropertyChanged)
        {
            _parentCollection = parentCollection;
            _parentCollection.CollectionChanged += ParentCollectionChanged;
            _filter = filter;
            _updateOnPropertyChanged = updateOnPropertyChanged;
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
                case CollectionChangeAction.AddRange:
                    var rangeArgs = e as CollectionChangedRangeEventArgs;
                    List<T> addedItems = new List<T>();
                    foreach (var item in rangeArgs.Items)
                    {
                        var newItemInRange = item as T;
                        if (_filter(newItemInRange))
                        {
                            addedItems.Add(newItemInRange);                            
                        }
                        AddPropertyChangedListener(newItemInRange);
                    }

                    base.AddRange(addedItems);
                    break;

                case CollectionChangeAction.Add:
                    var newItem = e.Item as T;
                    if (_filter(newItem))
                    {
                        base.Add(newItem);
                    }
                    AddPropertyChangedListener(newItem);
                    break;
                case CollectionChangeAction.Remove:
                    var removedItem = e.Item as T;
                    if (_filter(removedItem))
                    {
                        base.Remove(removedItem);
                    }
                    RemovePropertyChangedListener(removedItem);
                    break;
                case CollectionChangeAction.Replace:
                    foreach (var item in _data.Values)
                    {
                        RemovePropertyChangedListener(item);
                    }

                    _data.Clear();
                    _dataList.Clear();
                    _needUpdate = true;
                    OnCollectionChanged(e);
                    break;
                case CollectionChangeAction.Clear:
                    base.Clear();
                    break;
            }
        }

        public override BindableObject GetGeneric(string id)
        {
            return this[id];
        }

        public override void Add(T item)
        {
            if (_fkSetter != null)
                _fkSetter(item);

            base.Add(item);

            AddPropertyChangedListener(item);

            _parentCollection.CollectionChanged -= ParentCollectionChanged;
            _parentCollection.Add(item);
            _parentCollection.CollectionChanged += ParentCollectionChanged;
        }

        private void AddPropertyChangedListener(T item)
        {
            if (_updateOnPropertyChanged == null)
                return;

            item.PropertyChanged -= ItemPropertyChanged;
            item.PropertyChanged += ItemPropertyChanged;
        }

        private void RemovePropertyChangedListener(T item)
        {
            if (_updateOnPropertyChanged == null)
                return;

            item.PropertyChanged -= ItemPropertyChanged;
        }

        private void ItemPropertyChanged(object source, string propertyName)
        {
            for (int i = 0; i < _updateOnPropertyChanged.Length; ++i)
            {
                if (propertyName != _updateOnPropertyChanged[i])
                    continue;

                if (!_filter((T)source))
                {
                    // item no longer fulfills condition - remove from list
                    base.Remove((T)source);
                }
                else
                {
                    // item fulfills condition - add it to list if it's not already in there
                    base.Add((T)source);
                }

                return;
            }
        }

        public override void Clear()
        {
            base.Clear();

            foreach (var item in _data.Values)
            {
                RemovePropertyChangedListener(item);
            }

            _parentCollection.CollectionChanged -= ParentCollectionChanged;
            _parentCollection.RemoveRange(Data.Values);
            _parentCollection.CollectionChanged += ParentCollectionChanged;
        }

        public override void Replace(IEnumerable<T> items)
        {
            foreach (var item in _data.Values)
            {
                RemovePropertyChangedListener(item);
            }

            foreach (var item in items)
            {
                if (_fkSetter != null)
                {
                    _fkSetter(item);
                }

                AddPropertyChangedListener(item);
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
            if (result)
            {
                RemovePropertyChangedListener(item);
            }

            _parentCollection.CollectionChanged -= ParentCollectionChanged;
            _parentCollection.Remove(item);
            _parentCollection.CollectionChanged += ParentCollectionChanged;

            return result;
        }

        public override void RemoveRange(IEnumerable<T> items)
        {
            base.RemoveRange(items);
            foreach (var item in items)
            {
                RemovePropertyChangedListener(item);
            }

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

            foreach (var item in _data.Values)
            {
                RemovePropertyChangedListener(item);
            }

            Data.Clear();
            DataList.Clear();
            foreach (var item in _parentCollection)
            {
                if (_filter(item))
                {
                    Data.Add(item.Id, item);
                    DataList.Add(new KeyValuePair<string, T>(item.Id, item));                    
                }

                AddPropertyChangedListener(item);
            }
        }

        #endregion
    }
}
