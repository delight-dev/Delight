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
        /// <summary>Boolean indicating if content is expanded.</summary>
        public System.Boolean IsExpanded
        {
            get { return IsExpandedProperty.GetValue(this); }
            set { IsExpandedProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> IsDisabledProperty = new DependencyProperty<System.Boolean>("IsDisabled");
        /// <summary>Boolean indicating if the expander button is deisabled.</summary>
        public System.Boolean IsDisabled
        {
            get { return IsDisabledProperty.GetValue(this); }
            set { IsDisabledProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Delight.ElementSize> HeaderHeightProperty = new DependencyProperty<Delight.ElementSize>("HeaderHeight");
        /// <summary>Height of the expander header.</summary>
        public Delight.ElementSize HeaderHeight
        {
            get { return HeaderHeightProperty.GetValue(this); }
            set { HeaderHeightProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Delight.ElementMargin> ContentMarginProperty = new DependencyProperty<Delight.ElementMargin>("ContentMargin");
        /// <summary>Margin of the expanded content.</summary>
        public Delight.ElementMargin ContentMargin
        {
            get { return ContentMarginProperty.GetValue(this); }
            set { ContentMarginProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Delight.ElementAlignment> HeaderAlignmentProperty = new DependencyProperty<Delight.ElementAlignment>("HeaderAlignment");
        /// <summary>Alignment of the expander header.</summary>
        public Delight.ElementAlignment HeaderAlignment
        {
            get { return HeaderAlignmentProperty.GetValue(this); }
            set { HeaderAlignmentProperty.SetValue(this, value); }
        }

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

        public readonly static DependencyProperty<Delight.SwitchMode> ToggleModeProperty = new DependencyProperty<Delight.SwitchMode>("ToggleMode");
        /// <summary>Enum indicating how the content should be toggled, e.g. if content should be loaded on-demand or be pre-loaded.</summary>
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
                    _expander.LineNumber = 0;
                    _expander.LinePosition = 0;
#endif
                    Delight.Expander.IsExpandedProperty.SetDefault(_expander, true);
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
