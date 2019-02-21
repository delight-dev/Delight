// Internal view logic generated from "LargeButton.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class LargeButton : Button
    {
        #region Constructors

        public LargeButton(View parent, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :
            base(parent, layoutParent, id, template ?? LargeButtonTemplates.Default, initializer)
        {
            this.AfterInitializeInternal();
        }

        public LargeButton() : this(null)
        {
        }

        static LargeButton()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(LargeButtonTemplates.Default, dependencyProperties);
        }

        #endregion

        #region Properties

        #endregion
    }

    #region Data Templates

    public static class LargeButtonTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return LargeButton;
            }
        }

        private static Template _largeButton;
        public static Template LargeButton
        {
            get
            {
#if UNITY_EDITOR
                if (_largeButton == null || _largeButton.CurrentVersion != Template.Version)
#else
                if (_largeButton == null)
#endif
                {
                    _largeButton = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _largeButton.Name = "LargeButton";
#endif
                    Delight.LargeButton.WidthProperty.SetDefault(_largeButton, new ElementSize(180f, ElementSizeUnit.Pixels));
                    Delight.LargeButton.HeightProperty.SetDefault(_largeButton, new ElementSize(100f, ElementSizeUnit.Pixels));
                    Delight.LargeButton.BackgroundColorProperty.SetDefault(_largeButton, new UnityEngine.Color(0f, 1f, 0f, 1f));
                    Delight.LargeButton.LabelTemplateProperty.SetDefault(_largeButton, LargeButtonLabel);
                }
                return _largeButton;
            }
        }

        private static Template _largeButtonLabel;
        public static Template LargeButtonLabel
        {
            get
            {
#if UNITY_EDITOR
                if (_largeButtonLabel == null || _largeButtonLabel.CurrentVersion != Template.Version)
#else
                if (_largeButtonLabel == null)
#endif
                {
                    _largeButtonLabel = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _largeButtonLabel.Name = "LargeButtonLabel";
#endif
                }
                return _largeButtonLabel;
            }
        }

        #endregion
    }

    #endregion
}
