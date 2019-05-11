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
            ViewSwitcher1.SwitchTo(ModelBindingTest);
        }

        public void ShowScrollExample()
        {
            ViewSwitcher1.SwitchTo(ScrollExample);
        }

        public void ShowAssetManagementTest()
        {
            ViewSwitcher1.SwitchTo(AssetManagementTest);
        }

        public void ShowInputFieldExample()
        {
            ViewSwitcher1.SwitchTo(InputFieldExample);
        }
        
        public void ShowSliderExample()
        {
            ViewSwitcher1.SwitchTo(SliderExample);
        }

        public void ShowBindingTest()
        {
            ViewSwitcher1.SwitchTo(BindingTest);
        }

        public void ShowComboBoxExample()
        {
            ViewSwitcher1.SwitchTo(ComboBoxExample);
        }
    }
}
