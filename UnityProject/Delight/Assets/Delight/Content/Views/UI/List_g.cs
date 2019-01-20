// Internal view logic generated from "List.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class ListView : CollectionView
    {
        #region Constructors

        public ListView(View parent, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :
            base(parent, layoutParent, id, template ?? ListViewTemplates.Default, initializer)
        {
        }

        public ListView() : this(null)
        {
        }

        static ListView()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(ListViewTemplates.Default, dependencyProperties);
        }

        #endregion

        #region Properties

        #endregion
    }

    #region Data Templates

    public static class ListViewTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return ListView;
            }
        }

        private static Template _listView;
        public static Template ListView
        {
            get
            {
#if UNITY_EDITOR
                if (_listView == null || _listView.CurrentVersion != Template.Version)
#else
                if (_listView == null)
#endif
                {
                    _listView = new Template(CollectionViewTemplates.CollectionView);
                }
                return _listView;
            }
        }

        #endregion
    }

    #endregion
}
