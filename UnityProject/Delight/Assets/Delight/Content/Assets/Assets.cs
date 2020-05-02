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

        private static Dictionary<string, Func<View, string, AttachedProperty>> AttachedPropertyActivators;
        private static Dictionary<string, Func<View, View, string, Template, bool, View>> ViewActivators;
        private static Dictionary<string, Type> ViewTypes;
        public static DependencyObject RuntimeAssetObject = new DependencyObject();

        #endregion

        #region Methods

        public static View CreateView(string viewName)
        {
            return CreateView(viewName, null, null, string.Empty, null, false);
        }

        public static View CreateView(string viewName, View parent)
        {
            return CreateView(viewName, parent, null, string.Empty, null, false);
        }

        public static View CreateView(string viewName, View parent, View layoutParent)
        {
            return CreateView(viewName, parent, layoutParent, string.Empty, null, false);
        }

        public static View CreateView(string viewName, View parent, View layoutParent, string id)
        {
            return CreateView(viewName, parent, layoutParent, id, null, false);
        }

        public static View CreateView(string viewName, View parent, View layoutParent, string id, Template template)
        {
            return CreateView(viewName, parent, layoutParent, id, template, false);
        }

        public static View CreateView(string viewName, View parent, View layoutParent, string id, Template template, bool deferInitialization)
        {
            if (ViewActivators == null) return null;
            if (ViewActivators.TryGetValue(viewName, out var activator))
            {
                return activator(parent, layoutParent, id, template, deferInitialization);
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

        public static AttachedProperty CreateAttachedProperty(string fullTypeName, View parent, string propertyName)
        {
            if (AttachedPropertyActivators == null) return null;
            if (AttachedPropertyActivators.TryGetValue(fullTypeName, out var activator))
            {
                return activator(parent, propertyName);
            }
            return null;

        }

        #endregion
    }
}
