#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class ViewSwitcherTest
    {
        public void ShowModelBindingTest()
        {
            ViewSwitcher1.SwitchTo(0);
        }

        public void ShowScrollExample()
        {
            ViewSwitcher1.SwitchTo(1);
        }

        public void ShowAssetManagementTest()
        {
            ViewSwitcher1.SwitchTo(2);
        }

        public void ShowInputFieldExample()
        {
            ViewSwitcher1.SwitchTo(3);
        }
    }
}
