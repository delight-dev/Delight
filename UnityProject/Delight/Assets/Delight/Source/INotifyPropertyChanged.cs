#region Using Statements
using System;
using System.Collections.Generic;
using UnityEngine;
#endregion

namespace Delight
{
    public delegate void PropertyChangedEventHandler(object source, string propertyName);

    /// <summary>
    /// Interface for objects notifying listeners a property has been changed.
    /// </summary>
    public interface INotifyPropertyChanged
    {
        #region Fields

        event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
