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

        public GridSplitter(View parent, View layoutParent = null, string id = null, Template template = null, bool deferInitialization = false) :
            base(parent, layoutParent, id, template ?? GridSplitterTemplates.Default, deferInitialization)
        {
            if (deferInitialization)
                return;

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
            dependencyProperties.Add(SetSizeOnDragEndedProperty);
            dependencyProperties.Add(SplitModeProperty);
            dependencyProperties.Add(SplitterColorProperty);
            dependencyProperties.Add(SplitterSpriteProperty);
            dependencyProperties.Add(BePushyProperty);
            dependencyProperties.Add(OverrideProportionalSizeProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<Delight.ElementSize> ThicknessProperty = new DependencyProperty<Delight.ElementSize>("Thickness");
        /// <summary>The thickness of the grid splitter handles.</summary>
        public Delight.ElementSize Thickness
        {
            get { return ThicknessProperty.GetValue(this); }
            set { ThicknessProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Delight.ElementSize> InteractionThicknessProperty = new DependencyProperty<Delight.ElementSize>("InteractionThickness");
        /// <summary>Indicates how thick the interactable region of the splitter handle is. Can be larger than the actual thickness to make it easer for the user to interact with the handle.</summary>
        public Delight.ElementSize InteractionThickness
        {
            get { return InteractionThicknessProperty.GetValue(this); }
            set { InteractionThicknessProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> SetSizeOnDragEndedProperty = new DependencyProperty<System.Boolean>("SetSizeOnDragEnded");
        /// <summary>Boolean indicating if the size of the row/column should be set after the user releases the handle.</summary>
        public System.Boolean SetSizeOnDragEnded
        {
            get { return SetSizeOnDragEndedProperty.GetValue(this); }
            set { SetSizeOnDragEndedProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Delight.SplitMode> SplitModeProperty = new DependencyProperty<Delight.SplitMode>("SplitMode");
        /// <summary>Sets if the grid should be split by columns, rows or both.</summary>
        public Delight.SplitMode SplitMode
        {
            get { return SplitModeProperty.GetValue(this); }
            set { SplitModeProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<UnityEngine.Color> SplitterColorProperty = new DependencyProperty<UnityEngine.Color>("SplitterColor");
        /// <summary>Color used by the grid splitter handles.</summary>
        public UnityEngine.Color SplitterColor
        {
            get { return SplitterColorProperty.GetValue(this); }
            set { SplitterColorProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<SpriteAsset> SplitterSpriteProperty = new DependencyProperty<SpriteAsset>("SplitterSprite");
        /// <summary>Sprite used by the grid splitter handles.</summary>
        public SpriteAsset SplitterSprite
        {
            get { return SplitterSpriteProperty.GetValue(this); }
            set { SplitterSpriteProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> BePushyProperty = new DependencyProperty<System.Boolean>("BePushy");
        /// <summary>Boolean indicating if resizing one column/row beyond min/max should push into and resize subsequent rows/columns.</summary>
        public System.Boolean BePushy
        {
            get { return BePushyProperty.GetValue(this); }
            set { BePushyProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> OverrideProportionalSizeProperty = new DependencyProperty<System.Boolean>("OverrideProportionalSize");
        /// <summary>Boolean indicating if the proportional size of the columns/rows should be overriden when resizing, and set to absolute (pixel) sizes instead.</summary>
        public System.Boolean OverrideProportionalSize
        {
            get { return OverrideProportionalSizeProperty.GetValue(this); }
            set { OverrideProportionalSizeProperty.SetValue(this, value); }
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
                    _gridSplitter.LineNumber = 0;
                    _gridSplitter.LinePosition = 0;
#endif
                    Delight.GridSplitter.ThicknessProperty.SetDefault(_gridSplitter, new ElementSize(10f, ElementSizeUnit.Pixels));
                    Delight.GridSplitter.SplitModeProperty.SetDefault(_gridSplitter, Delight.SplitMode.RowsAndColumns);
                    Delight.GridSplitter.SplitterColorProperty.SetDefault(_gridSplitter, new UnityEngine.Color(0f, 0f, 0f, 0f));
                    Delight.GridSplitter.OverrideProportionalSizeProperty.SetDefault(_gridSplitter, true);
                }
                return _gridSplitter;
            }
        }

        #endregion
    }

    #endregion
}
