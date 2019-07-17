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
    /// Base views for tab content displayed within the TabPanel.
    /// </summary>
    public partial class Tab
    {
        /// <summary>
        /// Sets content template data.
        /// </summary>
        public override void SetContentTemplateData(ContentTemplateData contentTemplateData)
        {
            ContentTemplateData = contentTemplateData;
        }
    }
}
