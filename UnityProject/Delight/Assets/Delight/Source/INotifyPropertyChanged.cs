#region Using Statements
using System;
using System.Collections.Generic;
using UnityEngine;
#endregion

namespace Delight
{
    public delegate void PropertyChangedEventHandler(object source, string propertyName);

    /// <summary>
    /// Base class for bindable objects.
    /// </summary>
    public interface INotifyPropertyChanged
    {
        #region Fields

        event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
