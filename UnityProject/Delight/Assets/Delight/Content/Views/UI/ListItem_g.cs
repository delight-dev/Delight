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
    public partial class ListItem : UIImageView
    {
        #region Constructors

        public ListItem(View parent, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :
            base(parent, layoutParent, id, template ?? ListItemTemplates.Default, initializer)
        {
            Click += ResolveActionHandler(this, "ListItemMouseClick");
            MouseEnter += ResolveActionHandler(this, "ListItemMouseEnter");
            MouseExit += ResolveActionHandler(this, "ListItemMouseExit");
            MouseDown += ResolveActionHandler(this, "ListItemMouseDown");
            MouseUp += ResolveActionHandler(this, "ListItemMouseUp");
            this.AfterInitializeInternal();
        }

        public ListItem() : this(null)
        {
        }

        static ListItem()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(ListItemTemplates.Default, dependencyProperties);

            dependencyProperties.Add(ItemProperty);
            dependencyProperties.Add(IsDisabledProperty);
            dependencyProperties.Add(IsAlternateProperty);
            dependencyProperties.Add(IsSelectedProperty);
            dependencyProperties.Add(IsPressedProperty);
            dependencyProperties.Add(IsMouseOverProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<Delight.BindableObject> ItemProperty = new DependencyProperty<Delight.BindableObject>("Item");
        public Delight.BindableObject Item
        {
            get { return ItemProperty.GetValue(this); }
            set { ItemProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> IsDisabledProperty = new DependencyProperty<System.Boolean>("IsDisabled");
        public System.Boolean IsDisabled
        {
            get { return IsDisabledProperty.GetValue(this); }
            set { IsDisabledProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> IsAlternateProperty = new DependencyProperty<System.Boolean>("IsAlternate");
        public System.Boolean IsAlternate
        {
            get { return IsAlternateProperty.GetValue(this); }
            set { IsAlternateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> IsSelectedProperty = new DependencyProperty<System.Boolean>("IsSelected");
        public System.Boolean IsSelected
        {
            get { return IsSelectedProperty.GetValue(this); }
            set { IsSelectedProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> IsPressedProperty = new DependencyProperty<System.Boolean>("IsPressed");
        public System.Boolean IsPressed
        {
            get { return IsPressedProperty.GetValue(this); }
            set { IsPressedProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> IsMouseOverProperty = new DependencyProperty<System.Boolean>("IsMouseOver");
        public System.Boolean IsMouseOver
        {
            get { return IsMouseOverProperty.GetValue(this); }
            set { IsMouseOverProperty.SetValue(this, value); }
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
                    _listItem = new Template(UIImageViewTemplates.UIImageView);
#if UNITY_EDITOR
                    _listItem.Name = "ListItem";
#endif
                    Delight.ListItem.BackgroundColorProperty.SetStateDefault("Selected", _listItem, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.ListItem.BackgroundColorProperty.SetStateDefault("Highlighted", _listItem, new UnityEngine.Color(1f, 0f, 0f, 1f));
                    Delight.ListItem.BackgroundColorProperty.SetStateDefault("Pressed", _listItem, new UnityEngine.Color(0f, 0f, 1f, 1f));
                }
                return _listItem;
            }
        }

        #endregion
    }

    #endregion
}
