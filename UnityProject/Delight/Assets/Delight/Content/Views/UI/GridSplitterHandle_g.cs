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
            // constructing Image (SplitterHandle)
            SplitterHandle = new Image(this, this, "SplitterHandle", SplitterHandleTemplate);
            Drag.RegisterHandler(this, "OnDrag");
            BeginDrag.RegisterHandler(this, "OnBeginDrag");
            InitializePotentialDrag.RegisterHandler(this, "OnInitializePotentialDrag");
            EndDrag.RegisterHandler(this, "OnEndDrag");
            MouseEnter.RegisterHandler(this, "OnMouseEnter");
            MouseExit.RegisterHandler(this, "OnMouseExit");
            ContentContainer = SplitterHandle;
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
            dependencyProperties.Add(SplitterHandleProperty);
            dependencyProperties.Add(SplitterHandleTemplateProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<System.Boolean> IsEnabledProperty = new DependencyProperty<System.Boolean>("IsEnabled");
        public System.Boolean IsEnabled
        {
            get { return IsEnabledProperty.GetValue(this); }
            set { IsEnabledProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Image> SplitterHandleProperty = new DependencyProperty<Image>("SplitterHandle");
        public Image SplitterHandle
        {
            get { return SplitterHandleProperty.GetValue(this); }
            set { SplitterHandleProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> SplitterHandleTemplateProperty = new DependencyProperty<Template>("SplitterHandleTemplate");
        public Template SplitterHandleTemplate
        {
            get { return SplitterHandleTemplateProperty.GetValue(this); }
            set { SplitterHandleTemplateProperty.SetValue(this, value); }
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
                    Delight.GridSplitterHandle.RaycastBlockModeProperty.SetDefault(_gridSplitterHandle, Delight.RaycastBlockMode.Always);
                    Delight.GridSplitterHandle.SplitterHandleTemplateProperty.SetDefault(_gridSplitterHandle, GridSplitterHandleSplitterHandle);
                }
                return _gridSplitterHandle;
            }
        }

        private static Template _gridSplitterHandleSplitterHandle;
        public static Template GridSplitterHandleSplitterHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_gridSplitterHandleSplitterHandle == null || _gridSplitterHandleSplitterHandle.CurrentVersion != Template.Version)
#else
                if (_gridSplitterHandleSplitterHandle == null)
#endif
                {
                    _gridSplitterHandleSplitterHandle = new Template(ImageTemplates.Image);
#if UNITY_EDITOR
                    _gridSplitterHandleSplitterHandle.Name = "GridSplitterHandleSplitterHandle";
#endif
                    Delight.Image.WidthProperty.SetDefault(_gridSplitterHandleSplitterHandle, new ElementSize(1f, ElementSizeUnit.Percents));
                    Delight.Image.HeightProperty.SetDefault(_gridSplitterHandleSplitterHandle, new ElementSize(1f, ElementSizeUnit.Percents));
                }
                return _gridSplitterHandleSplitterHandle;
            }
        }

        #endregion
    }

    #endregion
}
