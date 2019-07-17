#region Using Statements
using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
#endregion

namespace Delight
{
    /// <summary>
    /// Generic base class for data providers. Provides access to bindable objects of a certain type.
    /// </summary>
    public abstract class DataProvider<T> : BindableCollection<T>
        where T : BindableObject
    {
    }
}
