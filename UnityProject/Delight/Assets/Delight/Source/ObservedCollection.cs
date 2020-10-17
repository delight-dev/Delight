#region Using Statements
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
#endregion

namespace Delight
{
    /// <summary>
    /// Wraps collections that isn't of type BindableCollection and adds functionality to notify when the collection changes.
    /// </summary>
    public class ObservedCollection : BindableCollection, IUpdateable
    {
        #region Fields

        public static Type IListType = typeof(System.Collections.IList);
        public static Type INotifyCollectionChangedType = typeof(INotifyCollectionChanged);
        public static Type IEnumerableType = typeof(IEnumerable);
        public static Type BindableObjectType = typeof(BindableObject);

        private IList _genericList;
        private int _oldCount;
        public override int Count => _genericList != null ? _genericList.Count : 0;
        private bool _hasBindableItems;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public ObservedCollection(object obj, LayoutRoot layoutRoot)
        {
            Type objType = obj.GetType();
            if (objType.IsGenericType) 
            {
                if (objType.GetGenericTypeDefinition() == typeof(ObservableCollection<>))
                {
                    // if object is of type ObservableCollection<> we subscribe to INotifyCollectionChanged events
                    _genericList = obj as IList;
                    _hasBindableItems = BindableObjectType.IsAssignableFrom(objType.GetGenericArguments()[0]);

                    // get event to register to it 
                    var eventInfo = objType.GetEvent("CollectionChanged");
                    var handler = Delegate.CreateDelegate(eventInfo.EventHandlerType, this, nameof(OnCollectionChanged));
                    eventInfo.AddEventHandler(obj, handler);
                }
                else if (objType.GetGenericTypeDefinition() == typeof(List<>))
                {
                    // if object is of type List<> we track changes each frame
                    _genericList = obj as IList;                    
                    _hasBindableItems = BindableObjectType.IsAssignableFrom(objType.GetGenericArguments()[0]);
                    layoutRoot.RegisterUpdateable(this);
                }
            }
        }

        #endregion

        #region Methods

        public override object GetGeneric(string id)
        {
            if (_genericList == null) 
                return null;

            if (_hasBindableItems)
            {
                foreach (var item in _genericList)
                {
                    if ((item as BindableObject).Id == id)
                    {
                        return item;
                    }
                }
            }
            else
            {
                foreach (var item in _genericList)
                {
                    if (item.GetHashCode().ToString() == id)
                    {
                        return item;
                    }
                }
            }

            return null;
        }

        public override object GetGeneric(int index)
        {
            return _genericList != null ? _genericList[index] : null;
        }

        public void OnCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    OnCollectionChanged(new CollectionChangedRangeEventArgs { ChangeAction = CollectionChangeAction.AddRange, Items = e.NewItems.ToList<object>() });
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Move:
                    OnCollectionChanged(new CollectionChangedEventArgs { ChangeAction = CollectionChangeAction.Replace });
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    OnCollectionChanged(new CollectionChangedRangeEventArgs { ChangeAction = CollectionChangeAction.RemoveRange, Items = e.OldItems.ToList<object>() });
                    break;
                default:
                case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                    OnCollectionChanged(new CollectionChangedEventArgs { ChangeAction = CollectionChangeAction.Replace });
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Reset:
                    OnCollectionChanged(new CollectionChangedEventArgs { ChangeAction = CollectionChangeAction.Clear });
                    break;
            }
        }

        public void OnUpdate()
        {
            if (_genericList == null)
                return;

            if (_oldCount != _genericList.Count)
            {
                _oldCount = _genericList.Count;
                OnCollectionChanged(new CollectionChangedEventArgs { ChangeAction = CollectionChangeAction.Replace });
            }
        }

        public static bool CanBeObserved(object obj)
        {
            if (obj == null)
                return false;

            Type objType = obj.GetType();
            return IEnumerableType.IsAssignableFrom(objType);
        }

        #endregion
    }
}
