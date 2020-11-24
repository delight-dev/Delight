// Internal view logic generated from "DraggableRegion.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class DraggableRegion : UIImageView
    {
        #region Constructors

        public DraggableRegion(View parent, View layoutParent = null, string id = null, Template template = null, bool deferInitialization = false) :
            base(parent, layoutParent, id, template ?? DraggableRegionTemplates.Default, deferInitialization)
        {
            if (deferInitialization)
                return;

            Drag.RegisterHandler(this, "OnDrag");
            this.AfterInitializeInternal();
        }

        public DraggableRegion() : this(null)
        {
        }

        static DraggableRegion()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(DraggableRegionTemplates.Default, dependencyProperties);
        }

        #endregion

        #region Properties

        #endregion
    }

    #region Data Templates

    public static class DraggableRegionTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return DraggableRegion;
            }
        }

        private static Template _draggableRegion;
        public static Template DraggableRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_draggableRegion == null || _draggableRegion.CurrentVersion != Template.Version)
#else
                if (_draggableRegion == null)
#endif
                {
                    _draggableRegion = new Template(UIImageViewTemplates.UIImageView);
#if UNITY_EDITOR
                    _draggableRegion.Name = "DraggableRegion";
                    _draggableRegion.LineNumber = 0;
                    _draggableRegion.LinePosition = 0;
#endif
                    Delight.DraggableRegion.BackgroundColorProperty.SetDefault(_draggableRegion, new UnityEngine.Color(0f, 0f, 1f, 1f));
                }
                return _draggableRegion;
            }
        }

        #endregion
    }

    #endregion
}
