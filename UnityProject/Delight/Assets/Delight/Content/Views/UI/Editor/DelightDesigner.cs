// Internal view logic generated from "EditorMainView.xml"
#region Using Statements
using Delight.Editor.Parser;
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

            // initialize designer views
            DesignerViews = new DesignerViewData();

            // load designer view data from the object model
            var contentObjectModel = ContentObjectModel.GetInstance();
            foreach (var viewObject in contentObjectModel.ViewObjects)
            {
                DesignerViews.Add(new DesignerView { Id = viewObject.Name, Name = viewObject.Name });
            }
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
            var label = this.Find<Label>();

            Debug.Log("Label font = " + label.Font.UnityObject);

            //Button1.SetState("Highlighted");            
        }
    }
}
