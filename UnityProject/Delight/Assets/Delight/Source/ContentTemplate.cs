#region Using Statements
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
#endregion

namespace Delight
{
    /// <summary>
    /// Content template.
    /// </summary>
    public class ContentTemplate
    {
        public Func<ContentTemplateData, View> Activator;
        public ContentTemplate(Func<ContentTemplateData, View> activator)
        {
            Activator = activator;
        }
    }

    /// <summary>
    /// Content template.
    /// </summary>
    public class ContentTemplateData : BindableObject
    {
        private BindableObject _item;
        public BindableObject Item
        {
            get { return _item; }
            set { SetProperty(ref _item, value); }
        }

        private int _index;
        public int Index
        {
            get { return _index; }
            set { SetProperty(ref _index, value); }
        }

        private int _zeroIndex;
        public int ZeroIndex
        {
            get { return _zeroIndex; }
            set { SetProperty(ref _zeroIndex, value); }
        }
    }
}
