// Internal view logic generated from "InventoryView.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class InventoryView : Collection
    {
        #region Constructors

        public InventoryView(View parent, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :
            base(parent, layoutParent, id, template ?? InventoryViewTemplates.Default, initializer)
        {
            // constructing Label (Label1)
            Label1 = new Label(this, this, "Label1", Label1Template);
            this.AfterInitializeInternal();
        }

        public InventoryView() : this(null)
        {
        }

        static InventoryView()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(InventoryViewTemplates.Default, dependencyProperties);

            dependencyProperties.Add(Label1Property);
            dependencyProperties.Add(Label1TemplateProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<Label> Label1Property = new DependencyProperty<Label>("Label1");
        public Label Label1
        {
            get { return Label1Property.GetValue(this); }
            set { Label1Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Label1TemplateProperty = new DependencyProperty<Template>("Label1Template");
        public Template Label1Template
        {
            get { return Label1TemplateProperty.GetValue(this); }
            set { Label1TemplateProperty.SetValue(this, value); }
        }

        #endregion
    }

    #region Data Templates

    public static class InventoryViewTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return InventoryView;
            }
        }

        private static Template _inventoryView;
        public static Template InventoryView
        {
            get
            {
#if UNITY_EDITOR
                if (_inventoryView == null || _inventoryView.CurrentVersion != Template.Version)
#else
                if (_inventoryView == null)
#endif
                {
                    _inventoryView = new Template(CollectionTemplates.Collection);
#if UNITY_EDITOR
                    _inventoryView.Name = "InventoryView";
#endif
                    Delight.InventoryView.Label1TemplateProperty.SetDefault(_inventoryView, InventoryViewLabel1);
                }
                return _inventoryView;
            }
        }

        private static Template _inventoryViewLabel1;
        public static Template InventoryViewLabel1
        {
            get
            {
#if UNITY_EDITOR
                if (_inventoryViewLabel1 == null || _inventoryViewLabel1.CurrentVersion != Template.Version)
#else
                if (_inventoryViewLabel1 == null)
#endif
                {
                    _inventoryViewLabel1 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _inventoryViewLabel1.Name = "InventoryViewLabel1";
#endif
                    Delight.Label.TextProperty.SetDefault(_inventoryViewLabel1, "Our awesome inventory view");
                }
                return _inventoryViewLabel1;
            }
        }

        #endregion
    }

    #endregion
}
