// Internal view logic generated from "RectMask2D.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class RectMask2D : UIImageView
    {
        #region Constructors

        public RectMask2D(View parent, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :
            base(parent, layoutParent, id, template ?? RectMask2DTemplates.Default, initializer)
        {
            this.AfterInitializeInternal();
        }

        public RectMask2D() : this(null)
        {
        }

        static RectMask2D()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(RectMask2DTemplates.Default, dependencyProperties);

            dependencyProperties.Add(RectMask2DComponentProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<UnityEngine.UI.RectMask2D> RectMask2DComponentProperty = new DependencyProperty<UnityEngine.UI.RectMask2D>("RectMask2DComponent");
        public UnityEngine.UI.RectMask2D RectMask2DComponent
        {
            get { return RectMask2DComponentProperty.GetValue(this); }
            set { RectMask2DComponentProperty.SetValue(this, value); }
        }

        #endregion
    }

    #region Data Templates

    public static class RectMask2DTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return RectMask2D;
            }
        }

        private static Template _rectMask2D;
        public static Template RectMask2D
        {
            get
            {
#if UNITY_EDITOR
                if (_rectMask2D == null || _rectMask2D.CurrentVersion != Template.Version)
#else
                if (_rectMask2D == null)
#endif
                {
                    _rectMask2D = new Template(UIImageViewTemplates.UIImageView);
#if UNITY_EDITOR
                    _rectMask2D.Name = "RectMask2D";
#endif
                    Delight.RectMask2D.WidthProperty.SetDefault(_rectMask2D, new ElementSize(1f, ElementSizeUnit.Percents));
                    Delight.RectMask2D.HeightProperty.SetDefault(_rectMask2D, new ElementSize(1f, ElementSizeUnit.Percents));
                }
                return _rectMask2D;
            }
        }

        #endregion
    }

    #endregion
}
