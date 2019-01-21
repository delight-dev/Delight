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
    public partial class List : Collection
    {
        #region Constructors

        public List(View parent, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :
            base(parent, layoutParent, id, template ?? ListTemplates.Default, initializer)
        {
        }

        public List() : this(null)
        {
        }

        static List()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(ListTemplates.Default, dependencyProperties);
        }

        #endregion

        #region Properties

        #endregion
    }

    #region Data Templates

    public static class ListTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return List;
            }
        }

        private static Template _list;
        public static Template List
        {
            get
            {
#if UNITY_EDITOR
                if (_list == null || _list.CurrentVersion != Template.Version)
#else
                if (_list == null)
#endif
                {
                    _list = new Template(CollectionTemplates.Collection);
                }
                return _list;
            }
        }

        #endregion
    }

    #endregion
}
