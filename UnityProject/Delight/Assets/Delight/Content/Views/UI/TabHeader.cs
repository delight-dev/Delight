#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    /// <summary>
    /// Base view for tab headers displayed by the TabPanel.
    /// </summary>
    public partial class TabHeader
    {
        #region Properties

        /// <summary>
        /// Parent tab panel the tab header resides in.
        /// </summary>
        public TabPanel ParentTabPanel { get; set; }

        #endregion

        #region Methods

        public void TabToggleClick()
        {
            if (!ToggleValue)
                return;

            ParentTabPanel.SelectedTabIndex = TabIndex;
        }

        /// <summary>
        /// Sets content template data.
        /// </summary>
        public override void SetContentTemplateData(ContentTemplateData contentTemplateData)
        {
            ContentTemplateData = contentTemplateData;
        }

        #endregion
    }
}
