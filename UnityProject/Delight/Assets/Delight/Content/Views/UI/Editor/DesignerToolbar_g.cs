// Internal view logic generated from "DesignerToolbar.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class DesignerToolbar : UIImageView
    {
        #region Constructors

        public DesignerToolbar(View parent, View layoutParent = null, string id = null, Template template = null, bool deferInitialization = false) :
            base(parent, layoutParent, id, template ?? DesignerToolbarTemplates.Default, deferInitialization)
        {
            if (deferInitialization)
                return;

            this.AfterInitializeInternal();
        }

        public DesignerToolbar() : this(null)
        {
        }

        static DesignerToolbar()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(DesignerToolbarTemplates.Default, dependencyProperties);
        }

        #endregion

        #region Properties

        #endregion
    }

    #region Data Templates

    public static class DesignerToolbarTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return DesignerToolbar;
            }
        }

        private static Template _designerToolbar;
        public static Template DesignerToolbar
        {
            get
            {
#if UNITY_EDITOR
                if (_designerToolbar == null || _designerToolbar.CurrentVersion != Template.Version)
#else
                if (_designerToolbar == null)
#endif
                {
                    _designerToolbar = new Template(UIImageViewTemplates.UIImageView);
#if UNITY_EDITOR
                    _designerToolbar.Name = "DesignerToolbar";
                    _designerToolbar.LineNumber = 0;
                    _designerToolbar.LinePosition = 0;
#endif
                }
                return _designerToolbar;
            }
        }

        #endregion
    }

    #endregion
}
