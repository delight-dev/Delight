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
                        var newItemInRange = (T)item;
                        if (_filter(newItemInRange))
                        {
                            addedItems.Add(newItemInRange);                            
                        }
                        AddPropertyChangedListener(newItemInRange);
                    }

                    base.AddRange(addedItems);
                    break;

                case CollectionChangeAction.Add:
                    var newItem = (T)e.Item;
                    if (_filter(newItem))
                    {
                        base.Add(newItem);
                    }
                    AddPropertyChangedListener(newItem);
                    break;
                case CollectionChangeAction.Remove:
                    var removedItem = (T)e.Item;
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

        public override object GetGeneric(string id)
        {
            return this[id];
        }

        public override void Add(T item, bool? animate = null)
        {
            if (_fkSetter != null)
                _fkSetter(item);

            base.Add(item, animate);

            AddPropertyChangedListener(item);

            _parentCollection.CollectionChanged -= ParentCollectionChanged;
            _parentCollection.Add(item, animate);
            _parentCollection.CollectionChanged += ParentCollectionChanged;
        }

        private void AddPropertyChangedListener(T item)
        {
            if (_updateOnPropertyChanged == null)
                return;

            if (IsBindableObject)
            {
                var bindableObject = item as BindableObject;
                bindableObject.PropertyChanged -= ItemPropertyChanged;
                bindableObject.PropertyChanged += ItemPropertyChanged;
            }
        }

        private void RemovePropertyChangedListener(T item)
        {
            if (_updateOnPropertyChanged == null)
                return;

            if (IsBindableObject)
            {
                var bindableObject = item as BindableObject;
                bindableObject.PropertyChanged -= ItemPropertyChanged;
            }
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

        public override void Clear(bool? animate = null)
        {
            base.Clear(animate);

            foreach (var item in _data.Values)
            {
                RemovePropertyChangedListener(item);
            }

            _parentCollection.CollectionChanged -= ParentCollectionChanged;
            _parentCollection.RemoveRange(Data.Values, animate);
            _parentCollection.CollectionChanged += ParentCollectionChanged;
        }

        public override void Replace(IEnumerable<T> items, bool? animate = null)
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

            base.Replace(items, animate);

            _parentCollection.CollectionChanged -= ParentCollectionChanged;
            _parentCollection.Replace(items, animate);
            _parentCollection.CollectionChanged += ParentCollectionChanged;
        }

        public override bool Contains(T item)
        {
            return Data.ContainsKey(GetId(item));
        }

        public override bool Remove(T item, bool? animate = null)
        {
            var result = base.Remove(item, animate);
            if (result)
            {
                RemovePropertyChangedListener(item);
            }

            _parentCollection.CollectionChanged -= ParentCollectionChanged;
            _parentCollection.Remove(item, animate);
            _parentCollection.CollectionChanged += ParentCollectionChanged;

            return result;
        }

        public override void RemoveRange(IEnumerable<T> items, bool? animate = null)
        {
            base.RemoveRange(items, animate);
            foreach (var item in items)
            {
                RemovePropertyChangedListener(item);
            }

            _parentCollection.CollectionChanged -= ParentCollectionChanged;
            _parentCollection.RemoveRange(items, animate);
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
                    string id = GetId(item);
                    Data.Add(id, item);
                    DataList.Add(new KeyValuePair<string, T>(id, item));
                }

                AddPropertyChangedListener(item);
            }
        }

        #endregion
    }
}
