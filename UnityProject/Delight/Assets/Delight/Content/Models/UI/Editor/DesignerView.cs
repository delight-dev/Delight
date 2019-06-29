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
    public class DesignerView: BindableObject
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private string _viewTypeName;
        public string ViewTypeName
        {
            get { return _viewTypeName; }
            set { SetProperty(ref _viewTypeName, value); }
        }
    }

    public class DesignerViewData : BindableCollection<DesignerView>
    {
        public DesignerViewData()
        {
            //// load designer view data from the object model
            //var contentObjectModel = ContentObjectModel.GetInstance();
            //foreach (var viewObject in contentObjectModel.ViewObjects)
            //{
            //    Add(new DesignerView { Id = viewObject.Name, Name = viewObject.Name });
            //}
        }
    }

    //public static partial class Models
    //{
    //    public static DesignerViewData DesignerViews = new DesignerViewData();
    //}
}
