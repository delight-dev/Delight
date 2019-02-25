// Internal view logic generated from "EditorMainView.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class DelightDesigner
    {
        public override void AfterInitialize()
        {
            base.AfterInitialize();

            //Grid1.Cell.SetValue(Cell00, new CellIndex(0, 0));
            //Grid1.Cell.SetValue(Cell01, new CellIndex(0, 1));
            //Grid1.Cell.SetValue(Cell02, new CellIndex(0, 2));

            //Grid1.Cell.SetValue(Cell10, new CellIndex(1, 0));
            //Grid1.Cell.SetValue(Cell11, new CellIndex(1, 1));
            //Grid1.Cell.SetValue(Cell12, new CellIndex(1, 2));

            //Grid1.Cell.SetValue(Cell20, new CellIndex(2, 0));
            //Grid1.Cell.SetValue(Cell21, new CellIndex(2, 1));
            //Grid1.Cell.SetValue(Cell22, new CellIndex(2, 2));
        }

        public override void Update()
        {
            base.Update();
 
            // center and adjust background grid to window
            var gridWidth = (float)((Math.Ceiling(ContentRegion.ActualWidth / 200) + 1) * 200);
            var gridHeight = (float)((Math.Ceiling(ContentRegion.ActualHeight / 200) + 1) * 200);
            if (GridImage.Width.Pixels != gridWidth || GridImage.Height.Pixels != gridHeight)
            {
                GridImage.SetSize(gridWidth, gridHeight);
                GridImage.UpdateLayout(false); // trigger layout update to remove stuttering as layout is changed one frame later
                GridImage.IsVisible = true;
            }            
        }

        public void Test1()
        {
            //Button1.SetState("Highlighted");            
        }
    }
}
