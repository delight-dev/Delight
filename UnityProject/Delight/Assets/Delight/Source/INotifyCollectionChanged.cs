#region Using Statements
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
#endregion

namespace Delight
{
    public delegate void CollectionChangedEventHandler(object source, CollectionChangedEventArgs eventArgs);

    /// <summary>
    /// Interface for collections notifying listeners the collection has been changed.
    /// </summary>
    public interface INotifyCollectionChanged
    {
        #region Fields

        event CollectionChangedEventHandler CollectionChanged;

        #endregion
    }
}
