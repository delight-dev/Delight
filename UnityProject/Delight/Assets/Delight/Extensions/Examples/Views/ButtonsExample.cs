#region Using Statements
using UnityEngine.EventSystems;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class ButtonsExample
    {
        public void ButtonClick()
        {
            ++ClickCount;
        }

        public void ItemSelected()
        {
        }
    }
}
