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
    /// Base view for tab content displayed within the TabPanel.
    /// </summary>
    public partial class Tab
    {
        public BindableObject Item { get; set; }

        /// <summary>
        /// Sets content template data.
        /// </summary>
        public override void SetContentTemplateData(ContentTemplateData contentTemplateData)
        {
            ContentTemplateData = contentTemplateData;
        }
    }
}
