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
    /// Aliases used when parsing views.
    /// </summary>
    public static partial class Aliases
    {
        private static Dictionary<string, string> _viewAliases;
        public static Dictionary<string, string> ViewAliases
        {
            get
            {
                if (_viewAliases == null)
                {
                    _viewAliases = new Dictionary<string, string>();
                    _viewAliases.Add("Canvas", "UICanvas");
                    _viewAliases.Add("Panel", "ScrollableRegion");
                }

                return _viewAliases;
            }
            set
            {
                _viewAliases = value;
            }
        }
    }
}
