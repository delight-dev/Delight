#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.Networking;
#endregion

namespace Delight
{
    /// <summary>
    /// Tab selection action data.
    /// </summary>
    public class TabSelectionActionData : ActionData
    {
        #region Fields

        public Tab Tab;
        public object Item;
        public bool IsSelected;

        #endregion

        #region Properties

        public override object RawData { get { return Item; } }

        #endregion
    }
}
