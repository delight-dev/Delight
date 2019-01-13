#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
#endregion

namespace Delight
{
    /// <summary>
    /// Label view.
    /// </summary>
    public partial class Label
    {
        protected override void BeforeLoad()
        {
            base.BeforeLoad();

            TextMeshProUGUI = GameObject.AddComponent<TMPro.TextMeshProUGUI>();
        }
    }
}
