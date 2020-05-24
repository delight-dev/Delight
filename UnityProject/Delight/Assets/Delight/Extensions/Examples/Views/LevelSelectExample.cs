#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
#endregion

namespace Delight
{
    public partial class LevelSelectExample
    {
        public void BackButtonClick()
        {
            NavigateBack?.Invoke(this, null);
        }
    }
}
