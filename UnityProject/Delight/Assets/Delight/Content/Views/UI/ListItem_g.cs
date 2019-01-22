// Internal view logic generated from "ListItem.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class ListItem : UIView
    {
        #region Constructors

        public ListItem(View parent, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :
            base(parent, layoutParent, id, template ?? ListItemTemplates.Default, initializer)
        {
        }

        public ListItem() : this(null)
        {
        }

        static ListItem()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(ListItemTemplates.Default, dependencyProperties);

            dependencyProperties.Add(ItemProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<Delight.BindableObject> ItemProperty = new DependencyProperty<Delight.BindableObject>("Item");
        public Delight.BindableObject Item
        {
            get { return ItemProperty.GetValue(this); }
            set { ItemProperty.SetValue(this, value); }
        }

        #endregion
    }

    #region Data Templates

    public static class ListItemTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return ListItem;
            }
        }

        private static Template _listItem;
        public static Template ListItem
        {
            get
            {
#if UNITY_EDITOR
                if (_listItem == null || _listItem.CurrentVersion != Template.Version)
#else
                if (_listItem == null)
#endif
                {
                    _listItem = new Template(UIViewTemplates.UIView);
                }
                return _listItem;
            }
        }

        #endregion
    }

    #endregion
}
