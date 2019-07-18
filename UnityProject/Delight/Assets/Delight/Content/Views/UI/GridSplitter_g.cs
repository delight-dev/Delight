// Internal view logic generated from "GridSplitter.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class GridSplitter : UIView
    {
        #region Constructors

        public GridSplitter(View parent, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :
            base(parent, layoutParent, id, template ?? GridSplitterTemplates.Default, initializer)
        {
            this.AfterInitializeInternal();
        }

        public GridSplitter() : this(null)
        {
        }

        static GridSplitter()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(GridSplitterTemplates.Default, dependencyProperties);

            dependencyProperties.Add(ThicknessProperty);
            dependencyProperties.Add(InteractionThicknessProperty);
            dependencyProperties.Add(SpacingProperty);
            dependencyProperties.Add(SetSizeOnDragEndedProperty);
            dependencyProperties.Add(IsEnabledProperty);
            dependencyProperties.Add(SplitModeProperty);
            dependencyProperties.Add(SplitterColorProperty);
            dependencyProperties.Add(SplitterSpriteProperty);
            dependencyProperties.Add(BePushyProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<Delight.ElementSize> ThicknessProperty = new DependencyProperty<Delight.ElementSize>("Thickness");
        public Delight.ElementSize Thickness
        {
            get { return ThicknessProperty.GetValue(this); }
            set { ThicknessProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Delight.ElementSize> InteractionThicknessProperty = new DependencyProperty<Delight.ElementSize>("InteractionThickness");
        public Delight.ElementSize InteractionThickness
        {
            get { return InteractionThicknessProperty.GetValue(this); }
            set { InteractionThicknessProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Delight.ElementSize> SpacingProperty = new DependencyProperty<Delight.ElementSize>("Spacing");
        public Delight.ElementSize Spacing
        {
            get { return SpacingProperty.GetValue(this); }
            set { SpacingProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> SetSizeOnDragEndedProperty = new DependencyProperty<System.Boolean>("SetSizeOnDragEnded");
        public System.Boolean SetSizeOnDragEnded
        {
            get { return SetSizeOnDragEndedProperty.GetValue(this); }
            set { SetSizeOnDragEndedProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> IsEnabledProperty = new DependencyProperty<System.Boolean>("IsEnabled");
        public System.Boolean IsEnabled
        {
            get { return IsEnabledProperty.GetValue(this); }
            set { IsEnabledProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Delight.SplitMode> SplitModeProperty = new DependencyProperty<Delight.SplitMode>("SplitMode");
        public Delight.SplitMode SplitMode
        {
            get { return SplitModeProperty.GetValue(this); }
            set { SplitModeProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<UnityEngine.Color> SplitterColorProperty = new DependencyProperty<UnityEngine.Color>("SplitterColor");
        public UnityEngine.Color SplitterColor
        {
            get { return SplitterColorProperty.GetValue(this); }
            set { SplitterColorProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<SpriteAsset> SplitterSpriteProperty = new DependencyProperty<SpriteAsset>("SplitterSprite");
        public SpriteAsset SplitterSprite
        {
            get { return SplitterSpriteProperty.GetValue(this); }
            set { SplitterSpriteProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> BePushyProperty = new DependencyProperty<System.Boolean>("BePushy");
        public System.Boolean BePushy
        {
            get { return BePushyProperty.GetValue(this); }
            set { BePushyProperty.SetValue(this, value); }
        }

        #endregion
    }

    #region Data Templates

    public static class GridSplitterTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return GridSplitter;
            }
        }

        private static Template _gridSplitter;
        public static Template GridSplitter
        {
            get
            {
#if UNITY_EDITOR
                if (_gridSplitter == null || _gridSplitter.CurrentVersion != Template.Version)
#else
                if (_gridSplitter == null)
#endif
                {
                    _gridSplitter = new Template(UIViewTemplates.UIView);
#if UNITY_EDITOR
                    _gridSplitter.Name = "GridSplitter";
#endif
                    Delight.GridSplitter.ThicknessProperty.SetDefault(_gridSplitter, new ElementSize(10f, ElementSizeUnit.Pixels));
                    Delight.GridSplitter.IsEnabledProperty.SetDefault(_gridSplitter, true);
                    Delight.GridSplitter.SplitModeProperty.SetDefault(_gridSplitter, Delight.SplitMode.RowsAndColumns);
                    Delight.GridSplitter.SplitterColorProperty.SetDefault(_gridSplitter, new UnityEngine.Color(0f, 0f, 0f, 0f));
                }
                return _gridSplitter;
            }
        }

        #endregion
    }

    #endregion
}
