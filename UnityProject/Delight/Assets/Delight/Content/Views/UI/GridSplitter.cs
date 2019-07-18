#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
#endregion

namespace Delight
{
    /// <summary>
    /// Allows for resizing of columns and rows in the Grid view. 
    /// </summary>
    public partial class GridSplitter
    {
        #region Fields

        private LayoutGrid _parentGrid;
        public BindableCollection<ContentTemplate> ContentTemplates = new BindableCollection<ContentTemplate>();

        #endregion

        #region Methods

        /// <summary>
        /// Called after the view has been loaded.
        /// </summary>
        protected override void AfterLoad()
        {
            base.AfterLoad();
            _parentGrid = LayoutParent as LayoutGrid;

            if (_parentGrid == null)
            {
                Debug.LogError(String.Format("#Delight# {0}: GridSplitter must reside within a Grid view.", Name));
                return;
            }

            // create grid-splitters based on parent grid
            var cellSpan = _parentGrid.CellSpan.GetValue(this);
            var cell = _parentGrid.Cell.GetValue(this);

            int columnCount = _parentGrid.Columns.Count;
            int rowCount = _parentGrid.Rows.Count;

            if (cellSpan == null)
            {
                cellSpan = new CellIndex(rowCount, columnCount);
            }

            if (cell == null)
            {
                cell = new CellIndex(0, 0);
            }

            var actualCellSpan = new CellIndex(Math.Min(rowCount - cell.Row, cellSpan.Row), Math.Min(columnCount - cell.Column, cellSpan.Column));            
            int columnSplitterCount = (actualCellSpan.Column - 1) - cell.Column;
            int rowSplitterCount = (actualCellSpan.Row - 1) - cell.Row;
            var contentTemplate = ContentTemplates?.FirstOrDefault();

            if (SplitMode == SplitMode.Columns || SplitMode == SplitMode.RowsAndColumns)
            {
                for (int i = 0; i < columnSplitterCount; ++i)
                {
                    var gridSplitterHandlerRegion = new Region(_parentGrid);
                    gridSplitterHandlerRegion.Id = String.Format("ColumnGridSplitterRegion{0}", i + 1);
                    gridSplitterHandlerRegion.Load();
                    gridSplitterHandlerRegion.IsDynamic = true;
                    _parentGrid.Cell.SetValue(gridSplitterHandlerRegion, new CellIndex(cell.Row, cell.Column + i));
                    _parentGrid.CellSpan.SetValue(gridSplitterHandlerRegion, new CellIndex(cellSpan.Row, 1));

                    var gridSplitterHandle = new GridSplitterHandle(_parentGrid);
                    gridSplitterHandle.MoveTo(gridSplitterHandlerRegion);
                    gridSplitterHandle.Load();

                    var thickness = Thickness ?? 10;
                    var interactionThickness = InteractionThickness ?? thickness;
                    var difference = interactionThickness - thickness;
                    if (difference > 0)
                    {
                        gridSplitterHandle.SplitterHandle.Margin = new ElementMargin(difference / 2, 0, difference / 2, 0);
                    }

                    gridSplitterHandle.Width = interactionThickness;
                    gridSplitterHandle.Offset = new ElementMargin(interactionThickness / 2, 0);
                    gridSplitterHandle.Alignment = ElementAlignment.Right;
                    gridSplitterHandle.SplitterHandle.Color = SplitterColor;
                    gridSplitterHandle.SplitterHandle.Sprite = SplitterSprite;
                    gridSplitterHandle.SetSizeOnDragEnded = SetSizeOnDragEnded;
                    gridSplitterHandle.ParentRegion = gridSplitterHandlerRegion;
                    gridSplitterHandle.ParentGrid = _parentGrid;
                    gridSplitterHandle.Index = cell.Column + i;
                    gridSplitterHandle.IsColumnSplitter = true;
                    gridSplitterHandle.BePushy = BePushy;

                    // create content for the handle                
                    if (contentTemplate == null)
                        continue;

                    var gridSplitterHandleContent = contentTemplate.Activator(ContentTemplateData.Empty);
                    gridSplitterHandleContent.MoveTo(gridSplitterHandle.Content);
                    gridSplitterHandleContent.Load();
                }
            }

            if (SplitMode == SplitMode.Rows || SplitMode == SplitMode.RowsAndColumns)
            {
                for (int i = 0; i < rowSplitterCount; ++i)
                {
                    var gridSplitterHandlerRegion = new Region(_parentGrid);
                    gridSplitterHandlerRegion.Id = String.Format("RowGridSplitterRegion{0}", i + 1);
                    gridSplitterHandlerRegion.Load();
                    gridSplitterHandlerRegion.IsDynamic = true;
                    _parentGrid.Cell.SetValue(gridSplitterHandlerRegion, new CellIndex(cell.Row + i, cell.Column));
                    _parentGrid.CellSpan.SetValue(gridSplitterHandlerRegion, new CellIndex(1, cellSpan.Column));

                    var gridSplitterHandle = new GridSplitterHandle(_parentGrid);
                    gridSplitterHandle.MoveTo(gridSplitterHandlerRegion);
                    gridSplitterHandle.Load();

                    var thickness = Thickness ?? 10;
                    var interactionThickness = InteractionThickness ?? thickness;
                    var difference = interactionThickness - thickness;
                    if (difference > 0)
                    {
                        gridSplitterHandle.SplitterHandle.Margin = new ElementMargin(0, difference / 2, 0, difference / 2);
                    }

                    gridSplitterHandle.Height = interactionThickness;
                    gridSplitterHandle.Offset = new ElementMargin(0, interactionThickness / 2);
                    gridSplitterHandle.Alignment = ElementAlignment.Bottom;
                    gridSplitterHandle.SplitterHandle.Color = SplitterColor;
                    gridSplitterHandle.SplitterHandle.Sprite = SplitterSprite;
                    gridSplitterHandle.SetSizeOnDragEnded = SetSizeOnDragEnded;
                    gridSplitterHandle.ParentRegion = gridSplitterHandlerRegion;
                    gridSplitterHandle.ParentGrid = _parentGrid;
                    gridSplitterHandle.Index = cell.Row + i;
                    gridSplitterHandle.IsColumnSplitter = false;
                    gridSplitterHandle.BePushy = BePushy;

                    // create content for the handle                
                    if (contentTemplate == null)
                        continue;

                    var gridSplitterHandleContent = contentTemplate.Activator(ContentTemplateData.Empty);
                    gridSplitterHandleContent.MoveTo(gridSplitterHandle);
                    gridSplitterHandleContent.Load();
                }
            }
        }

        #endregion
    }
}
