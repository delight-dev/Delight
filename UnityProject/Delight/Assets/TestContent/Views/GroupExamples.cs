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
    public partial class GroupExamples
    {
        public void AttackModifierSelected(ItemSelectionActionData itemData)
        {
        }

        public void Toggle1(PointerEventData pointerData)
        {
            IsActive1 = !IsActive1;
        }

        public void Toggle2(PointerEventData pointerData)
        {
            IsActive2 = !IsActive2;
        }

        public void SetWidth()
        {
            TestWidth = 400;
        }
    }
}
