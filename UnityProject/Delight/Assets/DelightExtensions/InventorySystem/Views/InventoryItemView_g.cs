// Internal view logic generated from "InventoryItemView.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class InventoryItemView : UIImageView
    {
        #region Constructors

        public InventoryItemView(View parent, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :
            base(parent, layoutParent, id, template ?? InventoryItemViewTemplates.Default, initializer)
        {
            this.AfterInitializeInternal();
        }

        public InventoryItemView() : this(null)
        {
        }

        static InventoryItemView()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(InventoryItemViewTemplates.Default, dependencyProperties);

            dependencyProperties.Add(ItemProperty);
            dependencyProperties.Add(ContentTemplateDataProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<Delight.BindableObject> ItemProperty = new DependencyProperty<Delight.BindableObject>("Item");
        public Delight.BindableObject Item
        {
            get { return ItemProperty.GetValue(this); }
            set { ItemProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Delight.ContentTemplateData> ContentTemplateDataProperty = new DependencyProperty<Delight.ContentTemplateData>("ContentTemplateData");
        public Delight.ContentTemplateData ContentTemplateData
        {
            get { return ContentTemplateDataProperty.GetValue(this); }
            set { ContentTemplateDataProperty.SetValue(this, value); }
        }

        #endregion
    }

    #region Data Templates

    public static class InventoryItemViewTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return InventoryItemView;
            }
        }

        private static Template _inventoryItemView;
        public static Template InventoryItemView
        {
            get
            {
#if UNITY_EDITOR
                if (_inventoryItemView == null || _inventoryItemView.CurrentVersion != Template.Version)
#else
                if (_inventoryItemView == null)
#endif
                {
                    _inventoryItemView = new Template(UIImageViewTemplates.UIImageView);
#if UNITY_EDITOR
                    _inventoryItemView.Name = "InventoryItemView";
#endif
                }
                return _inventoryItemView;
            }
        }

        #endregion
    }

    #endregion
}
