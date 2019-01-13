#region Using Statements
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
#endregion

namespace Delight
{
    /// <summary>
    /// Interface for lists that notify observers when items are added, deleted or moved.
    /// </summary>
    public interface IObservableList
    {
        #region Fields

        event EventHandler<ListChangedEventArgs> ListChanged;

        #endregion

        #region Methods

        void Add(object item);
        void Add(IEnumerable items);
        bool Remove(object item);
        void Remove(IEnumerable items);
        void SetSelected(object item);
        int GetIndex(object item);

        #endregion

        #region Properties

        /// <summary>
        /// Gets the number of items in the list.
        /// </summary>
        int Count
        {
            get;
        }

        /// <summary>
        /// Gets the item at index.
        /// </summary>
        object this[int index] { get; }

        #endregion
    }
}
