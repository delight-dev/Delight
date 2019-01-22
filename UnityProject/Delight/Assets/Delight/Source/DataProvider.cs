#region Using Statements
using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
#endregion

namespace Delight
{
    /// <summary>
    /// Base class for data providers.
    /// </summary>
    public abstract class DataProvider<T> : BindableCollection<T>
        where T : BindableObject
    {
    }
}
