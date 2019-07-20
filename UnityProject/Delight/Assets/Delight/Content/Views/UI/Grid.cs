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
    /// View that displays static content in a grid layout (note has the alias Grid in XML). 
    /// </summary>
    public partial class LayoutGrid
    {
        #region Fields

        private float _actualWidth;
        private float _actualHeight;

        #endregion

        #region Methods

        /// <summary>
        /// Called when a property has been changed. 
        /// </summary>
        public override void OnChanged(string property)
        {
            base.OnChanged(property);
            switch (property)
            {
                case nameof(Cell):
                case nameof(CellSpan):
                    CellChanged();
                    break;
            }
        }

        /// <summary>
        /// Called just before the view and its children are loaded.
        /// </summary>
        protected override void BeforeLoad()
        {
            // if the grid size isn't fixed track size changes
            if (Width == null || Width.Unit != ElementSizeUnit.Pixels ||
                Height == null || Height.Unit != ElementSizeUnit.Pixels)
            {
                EnableScriptEvents = true;
            }

            base.BeforeLoad();
        }

        /// <summary>
        /// Called just before the view and its children are loaded.
        /// </summary>
        protected override void AfterLoad()
        {
            base.AfterLoad();
            if (EnableScriptEvents)
            {
                _actualWidth = ActualWidth;
                _actualHeight = ActualHeight;
            }
        }

        /// <summary>
        /// Called once per frame if EnableScriptEvents is true.
        /// </summary>
        public override void Update()
        {
            base.Update();
            if (_actualWidth != ActualWidth || _actualHeight != ActualHeight)
            {
                _actualWidth = ActualWidth;
                _actualHeight = ActualHeight;
                UpdateLayout(false);
            }
        }

        /// <summary>
        /// Updates the layout of the grid. 
        /// </summary>
        public override bool UpdateLayout(bool notifyParent = true)
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
                    if (!(child is GridSplitter))
                    {
                        Debug.LogWarning(String.Format("#Delight# {0}: Unable to arrange view \"{1}\" in the grid as it doesn't specify its cell index. Specify cell index as an attached property on the view, e.g. <{1} Grid.CellIndex=\"0,1\" ...>, to put the view in the first row and second column.", Name, child.Name));
                    }
                    continue;
                }

                // calculate width, height and offset of view based on cell index
                var columnDefinition = GetColumnDefinition(child);
                var rowDefinition = GetRowDefinition(child);

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

            return false;
        }

        /// <summary>
        /// Resizes a column. 
        /// </summary>
        public void ResizeColumn(int columnIndex, float desiredWidth, bool bePushy = false)
        {
            if (columnIndex < 0 || columnIndex >= Columns.Count)
                return;

            var column = Columns[columnIndex];
            if (desiredWidth < column.MinWidth)
                desiredWidth = column.MinWidth;

            if (desiredWidth > column.MaxWidth)
                desiredWidth = column.MaxWidth; // TODO handle bePushy?

            var difference = column.ActualWidth - desiredWidth;
            float resize = difference;
            int nextColumnIndex = columnIndex + 1;

            // adjust following columns
            for (int i = nextColumnIndex; i < Columns.Count; ++i)
            {
                var nextColumnWidth = Columns[i].ActualWidth + resize;
                if (nextColumnWidth >= Columns[i].MinWidth)
                {
                    // there is room to resize we're all good
                    Columns[i].Width = nextColumnWidth;
                    resize = 0;
                    break;
                }
                else if (bePushy)
                {
                    Columns[i].Width = Columns[i].MinWidth;
                    resize = nextColumnWidth - Columns[i].MinWidth;
                }
                else
                {
                    // limit reached
                    Columns[i].Width = Columns[i].MinWidth;
                    resize = nextColumnWidth - Columns[i].MinWidth;
                    break;
                }
            }

            column.Width = column.ActualWidth - (difference - resize);
            UpdateLayout(false);
        }

        /// <summary>
        /// Resizes a row. 
        /// </summary>
        public void ResizeRow(int rowIndex, float desiredHeight, bool bePushy = false)
        {
            if (rowIndex < 0 || rowIndex >= Rows.Count)
                return;

            var row = Rows[rowIndex];
            if (desiredHeight < row.MinHeight)
                desiredHeight = row.MinHeight;

            if (desiredHeight > row.MaxHeight)
                desiredHeight = row.MaxHeight; // TODO handle bePushy?

            var difference = row.ActualHeight - desiredHeight;
            float resize = difference;
            int nextRowIndex = rowIndex + 1;

            // adjust following columns
            for (int i = nextRowIndex; i < Rows.Count; ++i)
            {
                var nextRowHeight = Rows[i].ActualHeight + resize;
                if (nextRowHeight >= Rows[i].MinHeight)
                {
                    // there is room to resize we're all good
                    Rows[i].Height = nextRowHeight;
                    resize = 0;
                    break;
                }
                else if (bePushy)
                {
                    Rows[i].Height = Rows[i].MinHeight;
                    resize = nextRowHeight - Rows[i].MinHeight;
                }
                else
                {
                    // limit reached
                    Rows[i].Height = Rows[i].MinHeight;
                    resize = nextRowHeight - Rows[i].MinHeight;
                    break;
                }
            }

            row.Height = row.ActualHeight - (difference - resize);
            UpdateLayout(false);
        }

        /// <summary>
        /// Gets column definition for the specified view.
        /// </summary>
        private ColumnDefinition GetColumnDefinition(UIView child)
        {
            var cellIndex = Cell.GetValue(child);
            int columnIndex = cellIndex.Column < Columns.Count ? cellIndex.Column : Columns.Count - 1;
            var columnDefinition = Columns[columnIndex];

            var cellSpan = CellSpan.GetValue(child);
            if (cellSpan == null || cellSpan.Column <= 1)
                return columnDefinition;

            var columnSpacing = ColumnSpacing ?? (Spacing ?? ElementSize.Default);

            // calculate new column definition based on column span
            var spannedColumnDefinition = new ColumnDefinition(columnDefinition);
            for (int i = 1; i < cellSpan.Column; ++i)
            {
                int nextColumnIndex = columnIndex + i;
                if (nextColumnIndex >= Columns.Count)
                    break;

                var nextColumnDefinition = Columns[nextColumnIndex];

                // add actual width and spacing of next column
                spannedColumnDefinition.ActualWidth += nextColumnDefinition.ActualWidth + columnSpacing;
            }
            return spannedColumnDefinition;
        }

        /// <summary>
        /// Gets row definition for the specified view.
        /// </summary>
        private RowDefinition GetRowDefinition(UIView child)
        {
            var cellIndex = Cell.GetValue(child);
            int rowIndex = cellIndex.Row < Rows.Count ? cellIndex.Row : Rows.Count - 1;
            var rowDefinition = Rows[rowIndex];

            var cellSpan = CellSpan.GetValue(child);
            if (cellSpan == null || cellSpan.Row <= 1)
                return rowDefinition;

            var rowSpacing = RowSpacing ?? (Spacing ?? ElementSize.Default);

            // calculate new row definition based on row span
            var spannedRowDefinition = new RowDefinition(rowDefinition);
            for (int i = 1; i < cellSpan.Row; ++i)
            {
                int nextRowIndex = rowIndex + i;
                if (nextRowIndex >= Rows.Count)
                    break;

                var nextRowDefinition = Rows[nextRowIndex];

                // add actual width and spacing of next row
                spannedRowDefinition.ActualHeight += nextRowDefinition.ActualHeight + rowSpacing;
            }
            return spannedRowDefinition;
        }

        /// <summary>
        /// Updates row and column definition sizes and offsets based on grid size.
        /// </summary>
        public void UpdateRowAndColumnDefinitions()
        {
            if (Columns == null || Columns.Count <= 0)
            {
                Columns = new ColumnDefinitions { new ColumnDefinition(ElementSize.FromProportion(1)) };
            }

            if (Rows == null || Rows.Count <= 0)
            {
                Rows = new RowDefinitions { new RowDefinition(ElementSize.FromProportion(1)) };
            }

            var spacing = Spacing ?? ElementSize.Default;
            var rowSpacing = RowSpacing ?? spacing;
            var columnSpacing = ColumnSpacing ?? spacing;

            // calculate column definition actual width and offset
            float totalColumnSpacing = (Columns.Count - 1) * columnSpacing.Pixels / Columns.Count;
            float totalFixedColumnWidth = Columns.Sum(x => x.Width.Pixels);
            float totalColumnProportion = Columns.Sum(x => x.Width.Proportion);
            float currentColumnOffset = 0;

            for (int i = 0; i < Columns.Count; ++i)
            {
                var columnDefinition = Columns[i];
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
            float totalRowSpacing = (Rows.Count - 1) * rowSpacing.Pixels / Rows.Count;
            float totalFixedRowHeight = Rows.Sum(x => x.Height.Pixels);
            float totalRowProportion = Rows.Sum(x => x.Height.Proportion);
            float currentRowOffset = 0;

            for (int i = 0; i < Rows.Count; ++i)
            {
                var rowDefinition = Rows[i];
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

        /// <summary>
        /// Called when the cell index or span of a child has been changed.
        /// </summary>
        private void CellChanged()
        {
            if (IgnoreObject || DisableLayoutUpdate)
                return;

            //Debug.Log(String.Format("{0}.LayoutChanged()", Name));            
            LayoutRoot?.RegisterChangeHandler(OnCellChanged);
        }

        /// <summary>
        /// Called when the cell index or span of a child has been changed. 
        /// </summary>
        public void OnCellChanged()
        {
            UpdateLayout(false);
        }

        #endregion
    }

    /// <summary>
    /// List of row definitions.
    /// </summary>
    public class RowDefinitions : List<RowDefinition>
    {
    }

    /// <summary>
    /// List of column definitions.
    /// </summary>
    public class ColumnDefinitions : List<ColumnDefinition>
    {
    }

    /// <summary>
    /// Contains information about a row in the grid.
    /// </summary>
    public class RowDefinition
    {
        #region Fields

        public ElementSize Height;
        public float ActualHeight;
        public float ActualOffset;
        public float MinHeight;
        public float MaxHeight;

        #endregion

        #region Constructors

        public RowDefinition(ElementSize height)
        {
            Height = height;
            MaxHeight = float.MaxValue;
        }

        public RowDefinition(ElementSize height, float minHeight)
        {
            Height = height;
            MinHeight = minHeight;
            MaxHeight = float.MaxValue;
        }

        public RowDefinition(ElementSize height, float minHeight, float maxHeight)
        {
            Height = height;
            MinHeight = minHeight;
            MaxHeight = maxHeight;
        }

        public RowDefinition(RowDefinition rowDefinition)
        {
            Height = rowDefinition.Height;
            ActualHeight = rowDefinition.ActualHeight;
            ActualOffset = rowDefinition.ActualOffset;
        }

        #endregion
    }

    /// <summary>
    /// Contains information about a column in the grid.
    /// </summary>
    public class ColumnDefinition
    {
        #region Fields

        public ElementSize Width;
        public float ActualWidth;
        public float ActualOffset;
        public float MinWidth;
        public float MaxWidth;

        #endregion

        #region Constructors

        public ColumnDefinition(ElementSize width)
        {
            Width = width;
            MaxWidth = float.MaxValue;
        }

        public ColumnDefinition(ElementSize width, float minWidth)
        {
            Width = width;
            MinWidth = minWidth;
            MaxWidth = float.MaxValue;
        }

        public ColumnDefinition(ElementSize width, float minWidth, float maxWidth)
        {
            Width = width;
            MinWidth = minWidth;
            MaxWidth = maxWidth;
        }

        public ColumnDefinition(ColumnDefinition columnDefinition)
        {
            Width = columnDefinition.Width;
            ActualWidth = columnDefinition.ActualWidth;
            ActualOffset = columnDefinition.ActualOffset;
        }

        #endregion
    }

    /// <summary>
    /// Represents cell index (row, column).
    /// </summary>
    public class CellIndex
    {
        #region Fields

        public int Row;
        public int Column;

        #endregion

        #region Constructor

        public CellIndex(int row, int column)
        {
            Row = row;
            Column = column;
        }

        #endregion
    }
}
