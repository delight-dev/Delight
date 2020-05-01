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
    public partial class TitleView
    {
        public string MyMethod(string input1, string input2)
        {
            if (int.TryParse(input1, out var number1) && int.TryParse(input2, out var number2))
                return (number1 + number2).ToString();

            return "specify two numbers";
        }
    }
}
