#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class InputFieldExample
    {
        public void OnValueChanged(string newValue)
        {
            Debug.Log("New value: " + newValue);
        }
    }
}
