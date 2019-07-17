// Internal view logic generated from "GridSplitterHandle.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class GridSplitterHandle : UIImageView
    {
        #region Constructors

        public GridSplitterHandle(View parent, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :
            base(parent, layoutParent, id, template ?? GridSplitterHandleTemplates.Default, initializer)
        {
            Drag.RegisterHandler(this, "OnDrag");
            BeginDrag.RegisterHandler(this, "OnBeginDrag");
            InitializePotentialDrag.RegisterHandler(this, "OnInitializePotentialDrag");
            EndDrag.RegisterHandler(this, "OnEndDrag");
            this.AfterInitializeInternal();
        }

        public GridSplitterHandle() : this(null)
        {
        }

        static GridSplitterHandle()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(GridSplitterHandleTemplates.Default, dependencyProperties);

            dependencyProperties.Add(IsEnabledProperty);
            dependencyProperties.Add(CanResizeHorizontallyProperty);
            dependencyProperties.Add(CanResizeVerticallyProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<System.Boolean> IsEnabledProperty = new DependencyProperty<System.Boolean>("IsEnabled");
        public System.Boolean IsEnabled
        {
            get { return IsEnabledProperty.GetValue(this); }
            set { IsEnabledProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> CanResizeHorizontallyProperty = new DependencyProperty<System.Boolean>("CanResizeHorizontally");
        public System.Boolean CanResizeHorizontally
        {
            get { return CanResizeHorizontallyProperty.GetValue(this); }
            set { CanResizeHorizontallyProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> CanResizeVerticallyProperty = new DependencyProperty<System.Boolean>("CanResizeVertically");
        public System.Boolean CanResizeVertically
        {
            get { return CanResizeVerticallyProperty.GetValue(this); }
            set { CanResizeVerticallyProperty.SetValue(this, value); }
        }

        #endregion
    }

    #region Data Templates

    public static class GridSplitterHandleTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return GridSplitterHandle;
            }
        }

        private static Template _gridSplitterHandle;
        public static Template GridSplitterHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_gridSplitterHandle == null || _gridSplitterHandle.CurrentVersion != Template.Version)
#else
                if (_gridSplitterHandle == null)
#endif
                {
                    _gridSplitterHandle = new Template(UIImageViewTemplates.UIImageView);
#if UNITY_EDITOR
                    _gridSplitterHandle.Name = "GridSplitterHandle";
#endif
                    Delight.GridSplitterHandle.IsEnabledProperty.SetDefault(_gridSplitterHandle, true);
                    Delight.GridSplitterHandle.BackgroundColorProperty.SetDefault(_gridSplitterHandle, new UnityEngine.Color(0f, 0f, 0f, 0f));
                }
                return _gridSplitterHandle;
            }
        }

        #endregion
    }

    #endregion
}
