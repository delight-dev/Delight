// Internal view logic generated from "BigSlowView.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class BigSlowView : UIImageView
    {
        #region Constructors

        public BigSlowView(View parent, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :
            base(parent, layoutParent, id, template ?? BigSlowViewTemplates.Default, initializer)
        {
            this.AfterInitializeInternal();
        }

        public BigSlowView() : this(null)
        {
        }

        static BigSlowView()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(BigSlowViewTemplates.Default, dependencyProperties);
        }

        #endregion

        #region Properties

        #endregion
    }

    #region Data Templates

    public static class BigSlowViewTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return BigSlowView;
            }
        }

        private static Template _bigSlowView;
        public static Template BigSlowView
        {
            get
            {
#if UNITY_EDITOR
                if (_bigSlowView == null || _bigSlowView.CurrentVersion != Template.Version)
#else
                if (_bigSlowView == null)
#endif
                {
                    _bigSlowView = new Template(UIImageViewTemplates.UIImageView);
#if UNITY_EDITOR
                    _bigSlowView.Name = "BigSlowView";
#endif
                    Delight.BigSlowView.WidthProperty.SetDefault(_bigSlowView, new ElementSize(300f, ElementSizeUnit.Pixels));
                    Delight.BigSlowView.HeightProperty.SetDefault(_bigSlowView, new ElementSize(300f, ElementSizeUnit.Pixels));
                    Delight.BigSlowView.BackgroundColorProperty.SetDefault(_bigSlowView, new UnityEngine.Color(0f, 1f, 0f, 1f));
                    Delight.BigSlowView.EnableScriptEventsProperty.SetDefault(_bigSlowView, true);
                }
                return _bigSlowView;
            }
        }

        #endregion
    }

    #endregion
}
