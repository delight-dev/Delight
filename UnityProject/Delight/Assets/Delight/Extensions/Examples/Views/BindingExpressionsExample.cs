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
    public partial class BindingExpressionsExample
    {
        public void Reset()
        {
            ClickCount = 0;
        }

        public void ButtonClick()
        {
            ++ClickCount;
        }
    }
}
