// Internal view logic generated from "ExpanderHeader.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class ExpanderHeader : UIView
    {
        #region Constructors

        public ExpanderHeader(View parent, View layoutParent = null, string id = null, Template template = null, bool deferInitialization = false) :
            base(parent, layoutParent, id, template ?? ExpanderHeaderTemplates.Default, deferInitialization)
        {
            if (deferInitialization)
                return;

            Click.RegisterHandler(this, "ExpanderHeaderClick");
            SetExpanderState = new AttachedProperty<System.Boolean>(this, "SetExpanderState");
            this.AfterInitializeInternal();
        }

        public ExpanderHeader() : this(null)
        {
        }

        static ExpanderHeader()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(ExpanderHeaderTemplates.Default, dependencyProperties);

            dependencyProperties.Add(TextProperty);
            dependencyProperties.Add(SpriteProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<System.String> TextProperty = new DependencyProperty<System.String>("Text");
        /// <summary>Expander header text.</summary>
        public System.String Text
        {
            get { return TextProperty.GetValue(this); }
            set { TextProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<SpriteAsset> SpriteProperty = new DependencyProperty<SpriteAsset>("Sprite");
        /// <summary>Expander header icon sprite.</summary>
        public SpriteAsset Sprite
        {
            get { return SpriteProperty.GetValue(this); }
            set { SpriteProperty.SetValue(this, value); }
        }

        public AttachedProperty<System.Boolean> SetExpanderState { get; private set; }

        #endregion
    }

    #region Data Templates

    public static class ExpanderHeaderTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return ExpanderHeader;
            }
        }

        private static Template _expanderHeader;
        public static Template ExpanderHeader
        {
            get
            {
#if UNITY_EDITOR
                if (_expanderHeader == null || _expanderHeader.CurrentVersion != Template.Version)
#else
                if (_expanderHeader == null)
#endif
                {
                    _expanderHeader = new Template(UIViewTemplates.UIView);
#if UNITY_EDITOR
                    _expanderHeader.Name = "ExpanderHeader";
                    _expanderHeader.LineNumber = 0;
                    _expanderHeader.LinePosition = 0;
#endif
                    Delight.ExpanderHeader.AlignmentProperty.SetDefault(_expanderHeader, Delight.ElementAlignment.TopLeft);
                    Delight.ExpanderHeader.RaycastBlockModeProperty.SetDefault(_expanderHeader, Delight.RaycastBlockMode.Always);
                }
                return _expanderHeader;
            }
        }

        #endregion
    }

    #endregion
}
