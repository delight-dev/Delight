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
    public interface IBindableCollection : INotifyCollectionChanged, IEnumerable
    {
        #region Methods
        #endregion

        #region Properties
        #endregion
    }
}
