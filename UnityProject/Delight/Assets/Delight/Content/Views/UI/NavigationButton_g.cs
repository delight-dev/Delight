// Internal view logic generated from "NavigationButton.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class NavigationButton : Button
    {
        #region Constructors

        public NavigationButton(View parent, View layoutParent = null, string id = null, Template template = null, bool deferInitialization = false) :
            base(parent, layoutParent, id, template ?? NavigationButtonTemplates.Default, deferInitialization)
        {
            if (deferInitialization)
                return;

            Click.RegisterHandler(this, "NavigationButtonClick");
            this.AfterInitializeInternal();
        }

        public NavigationButton() : this(null)
        {
        }

        static NavigationButton()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(NavigationButtonTemplates.Default, dependencyProperties);

            dependencyProperties.Add(NavigationTypeProperty);
            dependencyProperties.Add(PageIndexProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<Delight.NavigationButtonType> NavigationTypeProperty = new DependencyProperty<Delight.NavigationButtonType>("NavigationType");
        /// <summary>Type of navigation button this button represents.</summary>
        public Delight.NavigationButtonType NavigationType
        {
            get { return NavigationTypeProperty.GetValue(this); }
            set { NavigationTypeProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Int32> PageIndexProperty = new DependencyProperty<System.Int32>("PageIndex");
        /// <summary>Set programmatically to keep track of which page this button navigates to.</summary>
        public System.Int32 PageIndex
        {
            get { return PageIndexProperty.GetValue(this); }
            set { PageIndexProperty.SetValue(this, value); }
        }

        #endregion
    }

    #region Data Templates

    public static class NavigationButtonTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return NavigationButton;
            }
        }

        private static Template _navigationButton;
        public static Template NavigationButton
        {
            get
            {
#if UNITY_EDITOR
                if (_navigationButton == null || _navigationButton.CurrentVersion != Template.Version)
#else
                if (_navigationButton == null)
#endif
                {
                    _navigationButton = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _navigationButton.Name = "NavigationButton";
                    _navigationButton.LineNumber = 0;
                    _navigationButton.LinePosition = 0;
#endif
                    Delight.NavigationButton.NavigationTypeProperty.SetDefault(_navigationButton, Delight.NavigationButtonType.NextAndPrevious);
                    Delight.NavigationButton.AutoSizeProperty.SetDefault(_navigationButton, Delight.AutoSize.False);
                    Delight.NavigationButton.WidthProperty.SetDefault(_navigationButton, new ElementSize(30f, ElementSizeUnit.Pixels));
                    Delight.NavigationButton.HeightProperty.SetDefault(_navigationButton, new ElementSize(40f, ElementSizeUnit.Pixels));
                    Delight.NavigationButton.BackgroundColorProperty.SetDefault(_navigationButton, new UnityEngine.Color(0.7333333f, 0.7333333f, 0.7333333f, 1f));
                    Delight.NavigationButton.BackgroundColorProperty.SetStateDefault("Highlighted", _navigationButton, new UnityEngine.Color(0.8666667f, 0.8666667f, 0.8666667f, 1f));
                    Delight.NavigationButton.BackgroundColorProperty.SetStateDefault("Pressed", _navigationButton, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.NavigationButton.LabelTemplateProperty.SetDefault(_navigationButton, NavigationButtonLabel);
                }
                return _navigationButton;
            }
        }

        private static Template _navigationButtonLabel;
        public static Template NavigationButtonLabel
        {
            get
            {
#if UNITY_EDITOR
                if (_navigationButtonLabel == null || _navigationButtonLabel.CurrentVersion != Template.Version)
#else
                if (_navigationButtonLabel == null)
#endif
                {
                    _navigationButtonLabel = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _navigationButtonLabel.Name = "NavigationButtonLabel";
                    _navigationButtonLabel.LineNumber = 15;
                    _navigationButtonLabel.LinePosition = 4;
#endif
                    Delight.Label.TextAlignmentProperty.SetDefault(_navigationButtonLabel, TMPro.TextAlignmentOptions.Center);
                }
                return _navigationButtonLabel;
            }
        }

        #endregion
    }

    #endregion
}
