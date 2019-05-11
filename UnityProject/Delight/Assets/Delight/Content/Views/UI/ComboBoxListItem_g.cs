// Internal view logic generated from "ComboBoxListItem.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class ComboBoxListItem : ListItem
    {
        #region Constructors

        public ComboBoxListItem(View parent, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :
            base(parent, layoutParent, id, template ?? ComboBoxListItemTemplates.Default, initializer)
        {
            this.AfterInitializeInternal();
        }

        public ComboBoxListItem() : this(null)
        {
        }

        static ComboBoxListItem()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(ComboBoxListItemTemplates.Default, dependencyProperties);
        }

        #endregion

        #region Properties

        #endregion
    }

    #region Data Templates

    public static class ComboBoxListItemTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return ComboBoxListItem;
            }
        }

        private static Template _comboBoxListItem;
        public static Template ComboBoxListItem
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxListItem == null || _comboBoxListItem.CurrentVersion != Template.Version)
#else
                if (_comboBoxListItem == null)
#endif
                {
                    _comboBoxListItem = new Template(ListItemTemplates.ListItem);
#if UNITY_EDITOR
                    _comboBoxListItem.Name = "ComboBoxListItem";
#endif
                    Delight.ComboBoxListItem.AutoSizeToContentProperty.SetDefault(_comboBoxListItem, false);
                }
                return _comboBoxListItem;
            }
        }

        #endregion
    }

    #endregion
}
