#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    /// <summary>
    /// Main access point for all the assets used by the framework. 
    /// </summary>
    public static partial class Assets
    {
        #region Fields

        private static Dictionary<string, Func<View, View, Template, View>> ViewActivators;
        private static Dictionary<string, Type> ViewTypes;

        #endregion

        #region Methods

        public static View CreateView(string viewName)
        {
            return CreateView(viewName, null, null, null);
        }

        public static View CreateView(string viewName, View parent)
        {
            return CreateView(viewName, parent, null, null);
        }

        public static View CreateView(string viewName, View parent, View layoutParent)
        {
            return CreateView(viewName, parent, layoutParent, null);
        }

        public static View CreateView(string viewName, View parent, View layoutParent, Template template)
        {
            if (ViewActivators == null) return null;
            if (ViewActivators.TryGetValue(viewName, out var activator))
            {
                return activator(parent, layoutParent, template);
            }
            return null;
        }

        public static Type GetViewType(string viewTypeName)
        {
            if (ViewTypes == null) return null;
            if (ViewTypes.TryGetValue(viewTypeName, out var viewType))
            {
                return viewType;
            }
            return null;
        }

        #endregion
    }
}
