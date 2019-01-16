#region Using Statements
using System;
using System.Collections.Generic;
using UnityEngine;
#endregion

namespace Delight
{
    public delegate void CollectionChangedEventHandler(object source, CollectionChangedEventArgs eventArgs);

    /// <summary>
    /// Base class for bindable objects.
    /// </summary>
    public interface INotifyCollectionChanged
    {
        #region Fields

        event CollectionChangedEventHandler CollectionChanged;

        #endregion
    }
}
