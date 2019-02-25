#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using UnityEngine;
#endregion

namespace Delight
{
    /// <summary>
    /// Grid view.
    /// </summary>
    public partial class LayoutGrid
    {
        public override void AfterInitialize()
        {
            base.AfterInitialize();
        }

        /// <summary>
        /// Called when a child changes its layout.
        /// </summary>
        protected override void ChildLayoutChanged()
        {
            base.ChildLayoutChanged();

            // the layout of the grid children needs to be updated TODO clean up
            //LayoutRoot.RegisterNeedLayoutUpdate(this);
            // we don't necessarily need to change anything based on child layout changes - 
            // we override their width, height and offset
            // but we might need some way to be notified if a new child has been loaded/activated
        }

        /// <summary>
        /// Updates the layout of the grid. 
        /// </summary>
        public override void UpdateLayout(bool notifyParent = true)
        {
            base.UpdateLayout(notifyParent);

            bool defaultDisableLayoutUpdate = DisableLayoutUpdate;
            DisableLayoutUpdate = true;

            var children = new List<UIView>();
            Content.ForEach<UIView>(x => children.Add(x), false);

            UpdateRowAndColumnDefinitions();

            // arrange children into grid
            for (int i = 0; i < children.Count; ++i)
            {
                var child = children[i];
                var cellIndex = Cell.GetValue(child);
                if (cellIndex == null)
                {
                    Debug.LogWarning(String.Format("[Delight] {0}: Unable to arrange view \"{1}\" in the grid as it doesn't specify its cell index. Specify cell index as an attached property on the view, e.g. <{1} Grid.CellIndex=\"0,1\" ...>, to put the view in the first row and second column.", Name, child.Name));
                    continue;
                }               

                // calculate width, height and offset of view based on cell index
                int columnIndex = cellIndex.Column < ColumnDefinitions.Count ? cellIndex.Column : ColumnDefinitions.Count - 1;
                var columnDefinition = ColumnDefinitions[columnIndex];

                int rowIndex = cellIndex.Row < RowDefinitions.Count ? cellIndex.Row : RowDefinitions.Count - 1;
                var rowDefinition = RowDefinitions[rowIndex];

                ElementMargin cellOffset = new ElementMargin();
                cellOffset.Left = columnDefinition.ActualOffset;
                cellOffset.Top = rowDefinition.ActualOffset;

                // update child layout
                if (!cellOffset.Equals(child.OffsetFromParent) || 
                    !columnDefinition.ActualWidth.Equals(child.Width) || 
                    !rowDefinition.ActualHeight.Equals(child.Height) || 
                    child.Alignment != ElementAlignment.TopLeft)
                {
                    bool defaultDisableChildLayoutUpdate = child.DisableLayoutUpdate;
                    child.DisableLayoutUpdate = true;

                    child.OffsetFromParent = cellOffset;
                    child.Width = columnDefinition.ActualWidth;
                    child.Height = rowDefinition.ActualHeight;
                    child.Alignment = ElementAlignment.TopLeft;

                    child.UpdateLayout(false);
                    child.DisableLayoutUpdate = defaultDisableChildLayoutUpdate;
                }
            }

            DisableLayoutUpdate = defaultDisableLayoutUpdate;
        }

        /// <summary>
        /// Updates row and column definition sizes and offsets based on grid size.
        /// </summary>
        public void UpdateRowAndColumnDefinitions()
        {
            if (ColumnDefinitions == null || ColumnDefinitions.Count <= 0)
            {
                ColumnDefinitions = new ColumnDefinitions { new ColumnDefinition(ElementSize.FromProportion(1)) };
            }

            if (RowDefinitions == null || RowDefinitions.Count <= 0)
            {
                RowDefinitions = new RowDefinitions { new RowDefinition(ElementSize.FromProportion(1)) };
            }

            var spacing = Spacing ?? ElementSize.Default;
            var rowSpacing = RowSpacing ?? spacing;
            var columnSpacing = ColumnSpacing ?? spacing;

            // calculate column definition actual width and offset
            float totalColumnSpacing = (ColumnDefinitions.Count - 1) * columnSpacing.Pixels / ColumnDefinitions.Count;
            float totalFixedColumnWidth = ColumnDefinitions.Sum(x => x.Width.Pixels);
            float totalColumnProportion = ColumnDefinitions.Sum(x => x.Width.Proportion);
            float currentColumnOffset = 0;

            for (int i = 0; i < ColumnDefinitions.Count; ++i)
            {
                var columnDefinition = ColumnDefinitions[i];
                if (columnDefinition.Width.Unit == ElementSizeUnit.Pixels)
                {
                    columnDefinition.ActualWidth = columnDefinition.Width;
                }
                else
                {
                    // calculate width based on proportion
                    float percent = columnDefinition.Width.Proportion / totalColumnProportion;
                    columnDefinition.ActualWidth = percent * (ActualWidth - totalFixedColumnWidth) - totalColumnSpacing;
                }

                columnDefinition.ActualOffset = currentColumnOffset;
                currentColumnOffset += columnDefinition.ActualWidth + columnSpacing;
            }

            // calculate row definition actual width and offset
            float totalRowSpacing = (RowDefinitions.Count - 1) * rowSpacing.Pixels / RowDefinitions.Count;
            float totalFixedRowHeight = RowDefinitions.Sum(x => x.Height.Pixels);
            float totalRowProportion = RowDefinitions.Sum(x => x.Height.Proportion);
            float currentRowOffset = 0;

            for (int i = 0; i < RowDefinitions.Count; ++i)
            {
                var rowDefinition = RowDefinitions[i];
                if (rowDefinition.Height.Unit == ElementSizeUnit.Pixels)
                {
                    rowDefinition.ActualHeight = rowDefinition.Height;
                }
                else
                {
                    // calculate width based on proportion
                    float percent = rowDefinition.Height.Proportion / totalRowProportion;
                    rowDefinition.ActualHeight = percent * (ActualHeight - totalFixedRowHeight) - totalRowSpacing;
                }

                rowDefinition.ActualOffset = currentRowOffset;
                currentRowOffset += rowDefinition.ActualHeight + rowSpacing;
            }
        }
    }

    public class RowDefinitions : List<RowDefinition>
    {
    }

    public class ColumnDefinitions : List<ColumnDefinition>
    {
    }

    public class RowDefinition
    {
        public ElementSize Height;
        public float ActualHeight;
        public float ActualOffset;

        public RowDefinition(ElementSize height)
        {
            Height = height;
        }
    }

    public class ColumnDefinition
    {
        public ElementSize Width;
        public float ActualWidth;
        public float ActualOffset; 

        public ColumnDefinition(ElementSize width)
        {
            Width = width;
        }
    }

    public class CellIndex
    {
        public int Row;
        public int Column; 

        public CellIndex(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}
