// Internal view logic generated from "Expander.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class Expander : UIImageView
    {
        #region Constructors

        public Expander(View parent, View layoutParent = null, string id = null, Template template = null, bool deferInitialization = false) :
            base(parent, layoutParent, id, template ?? ExpanderTemplates.Default, deferInitialization)
        {
            if (deferInitialization)
                return;

            this.AfterInitializeInternal();
        }

        public Expander() : this(null)
        {
        }

        static Expander()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(ExpanderTemplates.Default, dependencyProperties);

            dependencyProperties.Add(IsExpandedProperty);
            dependencyProperties.Add(IsDisabledProperty);
            dependencyProperties.Add(IsInteractableProperty);
            dependencyProperties.Add(HeaderHeightProperty);
            dependencyProperties.Add(ContentMarginProperty);
            dependencyProperties.Add(HeaderAlignmentProperty);
            dependencyProperties.Add(TextProperty);
            dependencyProperties.Add(SpriteProperty);
            dependencyProperties.Add(ToggleModeProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<System.Boolean> IsExpandedProperty = new DependencyProperty<System.Boolean>("IsExpanded");
        public System.Boolean IsExpanded
        {
            get { return IsExpandedProperty.GetValue(this); }
            set { IsExpandedProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> IsDisabledProperty = new DependencyProperty<System.Boolean>("IsDisabled");
        public System.Boolean IsDisabled
        {
            get { return IsDisabledProperty.GetValue(this); }
            set { IsDisabledProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> IsInteractableProperty = new DependencyProperty<System.Boolean>("IsInteractable");
        public System.Boolean IsInteractable
        {
            get { return IsInteractableProperty.GetValue(this); }
            set { IsInteractableProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Delight.ElementSize> HeaderHeightProperty = new DependencyProperty<Delight.ElementSize>("HeaderHeight");
        public Delight.ElementSize HeaderHeight
        {
            get { return HeaderHeightProperty.GetValue(this); }
            set { HeaderHeightProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Delight.ElementMargin> ContentMarginProperty = new DependencyProperty<Delight.ElementMargin>("ContentMargin");
        public Delight.ElementMargin ContentMargin
        {
            get { return ContentMarginProperty.GetValue(this); }
            set { ContentMarginProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Delight.ElementAlignment> HeaderAlignmentProperty = new DependencyProperty<Delight.ElementAlignment>("HeaderAlignment");
        public Delight.ElementAlignment HeaderAlignment
        {
            get { return HeaderAlignmentProperty.GetValue(this); }
            set { HeaderAlignmentProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.String> TextProperty = new DependencyProperty<System.String>("Text");
        public System.String Text
        {
            get { return TextProperty.GetValue(this); }
            set { TextProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<SpriteAsset> SpriteProperty = new DependencyProperty<SpriteAsset>("Sprite");
        public SpriteAsset Sprite
        {
            get { return SpriteProperty.GetValue(this); }
            set { SpriteProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Delight.SwitchMode> ToggleModeProperty = new DependencyProperty<Delight.SwitchMode>("ToggleMode");
        public Delight.SwitchMode ToggleMode
        {
            get { return ToggleModeProperty.GetValue(this); }
            set { ToggleModeProperty.SetValue(this, value); }
        }

        #endregion
    }

    #region Data Templates

    public static class ExpanderTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return Expander;
            }
        }

        private static Template _expander;
        public static Template Expander
        {
            get
            {
#if UNITY_EDITOR
                if (_expander == null || _expander.CurrentVersion != Template.Version)
#else
                if (_expander == null)
#endif
                {
                    _expander = new Template(UIImageViewTemplates.UIImageView);
#if UNITY_EDITOR
                    _expander.Name = "Expander";
#endif
                    Delight.Expander.IsExpandedProperty.SetDefault(_expander, true);
                    Delight.Expander.IsInteractableProperty.SetDefault(_expander, true);
                    Delight.Expander.ContentMarginProperty.SetDefault(_expander, new ElementMargin(new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(10f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels)));
                    Delight.Expander.HeaderAlignmentProperty.SetDefault(_expander, Delight.ElementAlignment.TopLeft);
                    Delight.Expander.ToggleModeProperty.SetDefault(_expander, Delight.SwitchMode.Enable);
                    Delight.Expander.SpriteProperty.SetDefault(_expander, Assets.Sprites["ExpanderArrowRight"]);
                    Delight.Expander.SpriteProperty.SetStateDefault("Expanded", _expander, Assets.Sprites["ExpanderArrowDown"]);
                }
                return _expander;
            }
        }

        #endregion
    }

    #endregion
}
