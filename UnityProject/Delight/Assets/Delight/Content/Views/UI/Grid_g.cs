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

        public LayoutGrid(View parent, View layoutParent = null, string id = null, Template template = null, bool deferInitialization = false) :
            base(parent, layoutParent, id, template ?? LayoutGridTemplates.Default, deferInitialization)
        {
            if (deferInitialization)
                return;

            Cell = new AttachedProperty<Delight.CellIndex>(this, "Cell");
            CellSpan = new AttachedProperty<Delight.CellIndex>(this, "CellSpan");
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
            dependencyProperties.Add(RowsProperty);
            dependencyProperties.Add(ColumnsProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<Delight.ElementSize> SpacingProperty = new DependencyProperty<Delight.ElementSize>("Spacing");
        /// <summary>Spacing between grid row and columns.</summary>
        public Delight.ElementSize Spacing
        {
            get { return SpacingProperty.GetValue(this); }
            set { SpacingProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Delight.ElementSize> ColumnSpacingProperty = new DependencyProperty<Delight.ElementSize>("ColumnSpacing");
        /// <summary>Spacing between grid columns.</summary>
        public Delight.ElementSize ColumnSpacing
        {
            get { return ColumnSpacingProperty.GetValue(this); }
            set { ColumnSpacingProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Delight.ElementSize> RowSpacingProperty = new DependencyProperty<Delight.ElementSize>("RowSpacing");
        /// <summary>Spacing between grid rows.</summary>
        public Delight.ElementSize RowSpacing
        {
            get { return RowSpacingProperty.GetValue(this); }
            set { RowSpacingProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Delight.RowDefinitions> RowsProperty = new DependencyProperty<Delight.RowDefinitions>("Rows");
        /// <summary>Row definitions that determines the proportional or pixel size of each row in the grid as well as their min/max size.</summary>
        public Delight.RowDefinitions Rows
        {
            get { return RowsProperty.GetValue(this); }
            set { RowsProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Delight.ColumnDefinitions> ColumnsProperty = new DependencyProperty<Delight.ColumnDefinitions>("Columns");
        /// <summary>Column definitions that determines the proportional or pixel size of each column in the grid as well as their min/max size.</summary>
        public Delight.ColumnDefinitions Columns
        {
            get { return ColumnsProperty.GetValue(this); }
            set { ColumnsProperty.SetValue(this, value); }
        }

        public AttachedProperty<Delight.CellIndex> Cell { get; private set; }

        public AttachedProperty<Delight.CellIndex> CellSpan { get; private set; }

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
                    _layoutGrid.LineNumber = 0;
                    _layoutGrid.LinePosition = 0;
#endif
                    Delight.LayoutGrid.EnableScriptEventsProperty.SetDefault(_layoutGrid, true);
                }
                return _layoutGrid;
            }
        }

        #endregion
    }

    #endregion
}
