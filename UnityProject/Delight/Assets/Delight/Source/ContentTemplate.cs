#region Using Statements
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
#endregion

namespace Delight
{
    /// <summary>
    /// Content template.
    /// </summary>
    public class ContentTemplate
    {
        public Func<ContentTemplateData, View> Activator;
        public ContentTemplate(Func<ContentTemplateData, View> activator)
        {
            Activator = activator;
        }
    }
}
