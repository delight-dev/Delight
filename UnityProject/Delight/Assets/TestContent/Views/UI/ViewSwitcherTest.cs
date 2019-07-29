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
    public partial class ViewSwitcherTest
    {
        public void ShowModelBindingTest()
        {
            //ViewSwitcher1.SwitchTo(ModelBindingTest);
        }

        public async void ShowScrollExample()
        {
            await ViewSwitcher1.SwitchToAsync(ScrollExample);
        }

        public async void ShowAssetManagementTest()
        {
            await ViewSwitcher1.SwitchToAsync(AssetManagementTest);
        }

        public async void ShowInputFieldExample()
        {
            await ViewSwitcher1.SwitchToAsync(InputFieldExample);
        }
        
        public async void ShowSliderExample()
        {
            await ViewSwitcher1.SwitchToAsync(SliderExample);
        }

        public async void ShowBindingTest()
        {
            await ViewSwitcher1.SwitchToAsync(BindingTest);
        }

        public void ShowComboBoxExample()
        {
            //ViewSwitcher1.SwitchTo(ComboBoxExample);
        }
    }
}
