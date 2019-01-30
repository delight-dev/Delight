#region Using Statements
using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
#endregion

namespace Delight
{
    /// <summary>
    /// Interface for ensuring initialize method is called once on object construction. 
    /// </summary>
    public interface IInitialize
    {
        void AfterInitialize();
    }
}
