// Internal view logic generated from "Mask.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class Mask : UIImageView
    {
        #region Constructors

        public Mask(View parent, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :
            base(parent, layoutParent, id, template ?? MaskTemplates.Default, initializer)
        {
            this.AfterInitializeInternal();
        }

        public Mask() : this(null)
        {
        }

        static Mask()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(MaskTemplates.Default, dependencyProperties);

            dependencyProperties.Add(MaskComponentProperty);
            dependencyProperties.Add(ShowMaskGraphicProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<UnityEngine.UI.Mask> MaskComponentProperty = new DependencyProperty<UnityEngine.UI.Mask>("MaskComponent");
        public UnityEngine.UI.Mask MaskComponent
        {
            get { return MaskComponentProperty.GetValue(this); }
            set { MaskComponentProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Boolean, UnityEngine.UI.Mask, Mask> ShowMaskGraphicProperty = new MappedDependencyProperty<System.Boolean, UnityEngine.UI.Mask, Mask>("ShowMaskGraphic", x => x.MaskComponent, x => x.showMaskGraphic, (x, y) => x.showMaskGraphic = y);
        public System.Boolean ShowMaskGraphic
        {
            get { return ShowMaskGraphicProperty.GetValue(this); }
            set { ShowMaskGraphicProperty.SetValue(this, value); }
        }

        #endregion
    }

    #region Data Templates

    public static class MaskTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return Mask;
            }
        }

        private static Template _mask;
        public static Template Mask
        {
            get
            {
#if UNITY_EDITOR
                if (_mask == null || _mask.CurrentVersion != Template.Version)
#else
                if (_mask == null)
#endif
                {
                    _mask = new Template(UIImageViewTemplates.UIImageView);
#if UNITY_EDITOR
                    _mask.Name = "Mask";
#endif
                    Delight.Mask.ShowMaskGraphicProperty.SetDefault(_mask, true);
                }
                return _mask;
            }
        }

        #endregion
    }

    #endregion
}
