// Internal view logic generated from "Grid.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class LayoutGrid : UIImageView
    {
        #region Constructors

        public LayoutGrid(View parent, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :
            base(parent, layoutParent, id, template ?? LayoutGridTemplates.Default, initializer)
        {
            this.AfterInitializeInternal();
        }

        public LayoutGrid() : this(null)
        {
        }

        static LayoutGrid()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(LayoutGridTemplates.Default, dependencyProperties);

            dependencyProperties.Add(SpacingProperty);
            dependencyProperties.Add(ColumnSpacingProperty);
            dependencyProperties.Add(RowSpacingProperty);
            dependencyProperties.Add(RowDefinitionsProperty);
            dependencyProperties.Add(ColumnDefinitionsProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<Delight.ElementSize> SpacingProperty = new DependencyProperty<Delight.ElementSize>("Spacing");
        public Delight.ElementSize Spacing
        {
            get { return SpacingProperty.GetValue(this); }
            set { SpacingProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Delight.ElementSize> ColumnSpacingProperty = new DependencyProperty<Delight.ElementSize>("ColumnSpacing");
        public Delight.ElementSize ColumnSpacing
        {
            get { return ColumnSpacingProperty.GetValue(this); }
            set { ColumnSpacingProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Delight.ElementSize> RowSpacingProperty = new DependencyProperty<Delight.ElementSize>("RowSpacing");
        public Delight.ElementSize RowSpacing
        {
            get { return RowSpacingProperty.GetValue(this); }
            set { RowSpacingProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Delight.RowDefinitions> RowDefinitionsProperty = new DependencyProperty<Delight.RowDefinitions>("RowDefinitions");
        public Delight.RowDefinitions RowDefinitions
        {
            get { return RowDefinitionsProperty.GetValue(this); }
            set { RowDefinitionsProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Delight.ColumnDefinitions> ColumnDefinitionsProperty = new DependencyProperty<Delight.ColumnDefinitions>("ColumnDefinitions");
        public Delight.ColumnDefinitions ColumnDefinitions
        {
            get { return ColumnDefinitionsProperty.GetValue(this); }
            set { ColumnDefinitionsProperty.SetValue(this, value); }
        }

        #endregion
    }

    #region Data Templates

    public static class LayoutGridTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return LayoutGrid;
            }
        }

        private static Template _layoutGrid;
        public static Template LayoutGrid
        {
            get
            {
#if UNITY_EDITOR
                if (_layoutGrid == null || _layoutGrid.CurrentVersion != Template.Version)
#else
                if (_layoutGrid == null)
#endif
                {
                    _layoutGrid = new Template(UIImageViewTemplates.UIImageView);
#if UNITY_EDITOR
                    _layoutGrid.Name = "LayoutGrid";
#endif
                }
                return _layoutGrid;
            }
        }

        #endregion
    }

    #endregion
}
