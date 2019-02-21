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
    public partial class EditorMainView
    {
        public override void Update()
        {
            base.Update();

            // center and adjust background grid to window
            var gridWidth = (float)((Math.Ceiling(ContentRegion.ActualWidth / 200) + 1) * 200);
            var gridHeight = (float)((Math.Ceiling(ContentRegion.ActualHeight / 200) + 1) * 200);
            if (GridImage.Width.Pixels != gridWidth || GridImage.Height.Pixels != gridHeight)
            {
                GridImage.SetSize(gridWidth, gridHeight);
            }
        }

        public void Test1()
        {
            //Button1.SetState("Highlighted");            
        }
    }
}
