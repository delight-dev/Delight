#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class TabHeader
    {
        #region Properties

        /// <summary>
        /// Parent tab panel the tab header resides in.
        /// </summary>
        public TabPanel ParentTabPanel { get; set; }

        #endregion

        #region Methods

        public async void TabToggleClick()
        {
            if (!ToggleValue)
                return;

            TabPanel.SelectedTabIndexProperty.SetValue(ParentTabPanel, TabIndex, false);
            await ParentTabPanel.TabSwitcher.SwitchTo(TabIndex);
        }

        #endregion
    }
}
