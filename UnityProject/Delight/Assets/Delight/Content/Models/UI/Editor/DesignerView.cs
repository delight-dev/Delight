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
    /// <summary>
    /// Contains information about a view in the designer.
    /// </summary>
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

        private bool _isDirty;
        public bool IsDirty
        {
            get { return _isDirty; }
            set
            {
                SetProperty(ref _isDirty, value);
                OnPropertyChanged(nameof(DisplayName));
            }
        }

        public string DisplayName
        {
            get
            {
                return IsDirty ? Name + "*" : Name;
            }
        }

        public ViewObject ViewObject
        {
            get; set;
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
