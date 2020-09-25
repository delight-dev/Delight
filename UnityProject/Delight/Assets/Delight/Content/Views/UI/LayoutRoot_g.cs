// Internal view logic generated from "LayoutRoot.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class LayoutRoot : UICanvas
    {
        #region Constructors

        public LayoutRoot(View parent, View layoutParent = null, string id = null, Template template = null, bool deferInitialization = false) :
            base(parent, layoutParent, id, template ?? LayoutRootTemplates.Default, deferInitialization)
        {
            if (deferInitialization)
                return;

            this.AfterInitializeInternal();
        }

        public LayoutRoot() : this(null)
        {
        }

        static LayoutRoot()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(LayoutRootTemplates.Default, dependencyProperties);
        }

        #endregion

        #region Properties

        #endregion
    }

    #region Data Templates

    public static class LayoutRootTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return LayoutRoot;
            }
        }

        private static Template _layoutRoot;
        public static Template LayoutRoot
        {
            get
            {
#if UNITY_EDITOR
                if (_layoutRoot == null || _layoutRoot.CurrentVersion != Template.Version)
#else
                if (_layoutRoot == null)
#endif
                {
                    _layoutRoot = new Template(UICanvasTemplates.UICanvas);
#if UNITY_EDITOR
                    _layoutRoot.Name = "LayoutRoot";
                    _layoutRoot.LineNumber = 0;
                    _layoutRoot.LinePosition = 0;
#endif
                    Delight.LayoutRoot.EnableScriptEventsProperty.SetDefault(_layoutRoot, true);
                    Delight.LayoutRoot.RenderModeProperty.SetDefault(_layoutRoot, UnityEngine.RenderMode.ScreenSpaceOverlay);
                }
                return _layoutRoot;
            }
        }

        #endregion
    }

    #endregion
}
