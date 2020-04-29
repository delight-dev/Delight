// Internal view logic generated from "InventoryTestScene.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class InventoryTestScene : UIView
    {
        #region Constructors

        public InventoryTestScene(View parent, View layoutParent = null, string id = null, Template template = null, bool deferInitialization = false) :
            base(parent, layoutParent, id, template ?? InventoryTestSceneTemplates.Default, deferInitialization)
        {
            if (deferInitialization)
                return;

            // constructing List (List1)
            List1 = new List(this, this, "List1", List1Template);

            // binding <List Items="{item in @Inventories.DefaultInventory.InventoryItems}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "InventoryItems" }, new List<Func<BindableObject>> { () => Models.Inventories["DefaultInventory"] }) }, new BindingPath(new List<string> { "List1", "Items" }, new List<Func<BindableObject>> { () => this, () => List1 }), () => List1.Items = Models.Inventories["DefaultInventory"].InventoryItems, () => { }, false));

            // templates for List1
            List1.ContentTemplates.Add(new ContentTemplate(tiItem => 
            {
                var list1Content = new ListItem(this, List1.Content, "List1Content", List1ContentTemplate);
                var label1 = new Label(this, list1Content.Content, "Label1", Label1Template);

                // binding <Label Text="{item.Item.Name}">
                list1Content.Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "Item", "Item", "Name" }, new List<Func<BindableObject>> { () => tiItem, () => (tiItem.Item as Delight.InventoryItem), () => (tiItem.Item as Delight.InventoryItem).Item }) }, new BindingPath(new List<string> { "Text" }, new List<Func<BindableObject>> { () => label1 }), () => label1.Text = (tiItem.Item as Delight.InventoryItem).Item.Name, () => { }, false));
                list1Content.IsDynamic = true;
                list1Content.SetContentTemplateData(tiItem);
                return list1Content;
            }, typeof(ListItem), "List1Content"));

            // constructing Button (Button1)
            Button1 = new Button(this, this, "Button1", Button1Template);
            Button1.Click.RegisterHandler(this, "AddItem");
            this.AfterInitializeInternal();
        }

        public InventoryTestScene() : this(null)
        {
        }

        static InventoryTestScene()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(InventoryTestSceneTemplates.Default, dependencyProperties);

            dependencyProperties.Add(List1Property);
            dependencyProperties.Add(List1TemplateProperty);
            dependencyProperties.Add(Label1Property);
            dependencyProperties.Add(Label1TemplateProperty);
            dependencyProperties.Add(Button1Property);
            dependencyProperties.Add(Button1TemplateProperty);
            dependencyProperties.Add(List1ContentProperty);
            dependencyProperties.Add(List1ContentTemplateProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<List> List1Property = new DependencyProperty<List>("List1");
        public List List1
        {
            get { return List1Property.GetValue(this); }
            set { List1Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> List1TemplateProperty = new DependencyProperty<Template>("List1Template");
        public Template List1Template
        {
            get { return List1TemplateProperty.GetValue(this); }
            set { List1TemplateProperty.SetValue(this, value); }
        }

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

        public readonly static DependencyProperty<Button> Button1Property = new DependencyProperty<Button>("Button1");
        public Button Button1
        {
            get { return Button1Property.GetValue(this); }
            set { Button1Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Button1TemplateProperty = new DependencyProperty<Template>("Button1Template");
        public Template Button1Template
        {
            get { return Button1TemplateProperty.GetValue(this); }
            set { Button1TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ListItem> List1ContentProperty = new DependencyProperty<ListItem>("List1Content");
        public ListItem List1Content
        {
            get { return List1ContentProperty.GetValue(this); }
            set { List1ContentProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> List1ContentTemplateProperty = new DependencyProperty<Template>("List1ContentTemplate");
        public Template List1ContentTemplate
        {
            get { return List1ContentTemplateProperty.GetValue(this); }
            set { List1ContentTemplateProperty.SetValue(this, value); }
        }

        #endregion
    }

    #region Data Templates

    public static class InventoryTestSceneTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return InventoryTestScene;
            }
        }

        private static Template _inventoryTestScene;
        public static Template InventoryTestScene
        {
            get
            {
#if UNITY_EDITOR
                if (_inventoryTestScene == null || _inventoryTestScene.CurrentVersion != Template.Version)
#else
                if (_inventoryTestScene == null)
#endif
                {
                    _inventoryTestScene = new Template(UIViewTemplates.UIView);
#if UNITY_EDITOR
                    _inventoryTestScene.Name = "InventoryTestScene";
#endif
                    Delight.InventoryTestScene.List1TemplateProperty.SetDefault(_inventoryTestScene, InventoryTestSceneList1);
                    Delight.InventoryTestScene.List1ContentTemplateProperty.SetDefault(_inventoryTestScene, InventoryTestSceneList1Content);
                    Delight.InventoryTestScene.Label1TemplateProperty.SetDefault(_inventoryTestScene, InventoryTestSceneLabel1);
                    Delight.InventoryTestScene.Button1TemplateProperty.SetDefault(_inventoryTestScene, InventoryTestSceneButton1);
                }
                return _inventoryTestScene;
            }
        }

        private static Template _inventoryTestSceneList1;
        public static Template InventoryTestSceneList1
        {
            get
            {
#if UNITY_EDITOR
                if (_inventoryTestSceneList1 == null || _inventoryTestSceneList1.CurrentVersion != Template.Version)
#else
                if (_inventoryTestSceneList1 == null)
#endif
                {
                    _inventoryTestSceneList1 = new Template(ListTemplates.List);
#if UNITY_EDITOR
                    _inventoryTestSceneList1.Name = "InventoryTestSceneList1";
#endif
                    Delight.List.ItemsProperty.SetHasBinding(_inventoryTestSceneList1);
                    Delight.List.ScrollableRegionTemplateProperty.SetDefault(_inventoryTestSceneList1, InventoryTestSceneList1ScrollableRegion);
                }
                return _inventoryTestSceneList1;
            }
        }

        private static Template _inventoryTestSceneList1ScrollableRegion;
        public static Template InventoryTestSceneList1ScrollableRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_inventoryTestSceneList1ScrollableRegion == null || _inventoryTestSceneList1ScrollableRegion.CurrentVersion != Template.Version)
#else
                if (_inventoryTestSceneList1ScrollableRegion == null)
#endif
                {
                    _inventoryTestSceneList1ScrollableRegion = new Template(ListTemplates.ListScrollableRegion);
#if UNITY_EDITOR
                    _inventoryTestSceneList1ScrollableRegion.Name = "InventoryTestSceneList1ScrollableRegion";
#endif
                    Delight.ScrollableRegion.ContentRegionTemplateProperty.SetDefault(_inventoryTestSceneList1ScrollableRegion, InventoryTestSceneList1ScrollableRegionContentRegion);
                    Delight.ScrollableRegion.HorizontalScrollbarTemplateProperty.SetDefault(_inventoryTestSceneList1ScrollableRegion, InventoryTestSceneList1ScrollableRegionHorizontalScrollbar);
                    Delight.ScrollableRegion.VerticalScrollbarTemplateProperty.SetDefault(_inventoryTestSceneList1ScrollableRegion, InventoryTestSceneList1ScrollableRegionVerticalScrollbar);
                }
                return _inventoryTestSceneList1ScrollableRegion;
            }
        }

        private static Template _inventoryTestSceneList1ScrollableRegionContentRegion;
        public static Template InventoryTestSceneList1ScrollableRegionContentRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_inventoryTestSceneList1ScrollableRegionContentRegion == null || _inventoryTestSceneList1ScrollableRegionContentRegion.CurrentVersion != Template.Version)
#else
                if (_inventoryTestSceneList1ScrollableRegionContentRegion == null)
#endif
                {
                    _inventoryTestSceneList1ScrollableRegionContentRegion = new Template(ListTemplates.ListScrollableRegionContentRegion);
#if UNITY_EDITOR
                    _inventoryTestSceneList1ScrollableRegionContentRegion.Name = "InventoryTestSceneList1ScrollableRegionContentRegion";
#endif
                }
                return _inventoryTestSceneList1ScrollableRegionContentRegion;
            }
        }

        private static Template _inventoryTestSceneList1ScrollableRegionHorizontalScrollbar;
        public static Template InventoryTestSceneList1ScrollableRegionHorizontalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_inventoryTestSceneList1ScrollableRegionHorizontalScrollbar == null || _inventoryTestSceneList1ScrollableRegionHorizontalScrollbar.CurrentVersion != Template.Version)
#else
                if (_inventoryTestSceneList1ScrollableRegionHorizontalScrollbar == null)
#endif
                {
                    _inventoryTestSceneList1ScrollableRegionHorizontalScrollbar = new Template(ListTemplates.ListScrollableRegionHorizontalScrollbar);
#if UNITY_EDITOR
                    _inventoryTestSceneList1ScrollableRegionHorizontalScrollbar.Name = "InventoryTestSceneList1ScrollableRegionHorizontalScrollbar";
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_inventoryTestSceneList1ScrollableRegionHorizontalScrollbar, InventoryTestSceneList1ScrollableRegionHorizontalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_inventoryTestSceneList1ScrollableRegionHorizontalScrollbar, InventoryTestSceneList1ScrollableRegionHorizontalScrollbarHandle);
                }
                return _inventoryTestSceneList1ScrollableRegionHorizontalScrollbar;
            }
        }

        private static Template _inventoryTestSceneList1ScrollableRegionHorizontalScrollbarBar;
        public static Template InventoryTestSceneList1ScrollableRegionHorizontalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_inventoryTestSceneList1ScrollableRegionHorizontalScrollbarBar == null || _inventoryTestSceneList1ScrollableRegionHorizontalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_inventoryTestSceneList1ScrollableRegionHorizontalScrollbarBar == null)
#endif
                {
                    _inventoryTestSceneList1ScrollableRegionHorizontalScrollbarBar = new Template(ListTemplates.ListScrollableRegionHorizontalScrollbarBar);
#if UNITY_EDITOR
                    _inventoryTestSceneList1ScrollableRegionHorizontalScrollbarBar.Name = "InventoryTestSceneList1ScrollableRegionHorizontalScrollbarBar";
#endif
                }
                return _inventoryTestSceneList1ScrollableRegionHorizontalScrollbarBar;
            }
        }

        private static Template _inventoryTestSceneList1ScrollableRegionHorizontalScrollbarHandle;
        public static Template InventoryTestSceneList1ScrollableRegionHorizontalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_inventoryTestSceneList1ScrollableRegionHorizontalScrollbarHandle == null || _inventoryTestSceneList1ScrollableRegionHorizontalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_inventoryTestSceneList1ScrollableRegionHorizontalScrollbarHandle == null)
#endif
                {
                    _inventoryTestSceneList1ScrollableRegionHorizontalScrollbarHandle = new Template(ListTemplates.ListScrollableRegionHorizontalScrollbarHandle);
#if UNITY_EDITOR
                    _inventoryTestSceneList1ScrollableRegionHorizontalScrollbarHandle.Name = "InventoryTestSceneList1ScrollableRegionHorizontalScrollbarHandle";
#endif
                }
                return _inventoryTestSceneList1ScrollableRegionHorizontalScrollbarHandle;
            }
        }

        private static Template _inventoryTestSceneList1ScrollableRegionVerticalScrollbar;
        public static Template InventoryTestSceneList1ScrollableRegionVerticalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_inventoryTestSceneList1ScrollableRegionVerticalScrollbar == null || _inventoryTestSceneList1ScrollableRegionVerticalScrollbar.CurrentVersion != Template.Version)
#else
                if (_inventoryTestSceneList1ScrollableRegionVerticalScrollbar == null)
#endif
                {
                    _inventoryTestSceneList1ScrollableRegionVerticalScrollbar = new Template(ListTemplates.ListScrollableRegionVerticalScrollbar);
#if UNITY_EDITOR
                    _inventoryTestSceneList1ScrollableRegionVerticalScrollbar.Name = "InventoryTestSceneList1ScrollableRegionVerticalScrollbar";
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_inventoryTestSceneList1ScrollableRegionVerticalScrollbar, InventoryTestSceneList1ScrollableRegionVerticalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_inventoryTestSceneList1ScrollableRegionVerticalScrollbar, InventoryTestSceneList1ScrollableRegionVerticalScrollbarHandle);
                }
                return _inventoryTestSceneList1ScrollableRegionVerticalScrollbar;
            }
        }

        private static Template _inventoryTestSceneList1ScrollableRegionVerticalScrollbarBar;
        public static Template InventoryTestSceneList1ScrollableRegionVerticalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_inventoryTestSceneList1ScrollableRegionVerticalScrollbarBar == null || _inventoryTestSceneList1ScrollableRegionVerticalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_inventoryTestSceneList1ScrollableRegionVerticalScrollbarBar == null)
#endif
                {
                    _inventoryTestSceneList1ScrollableRegionVerticalScrollbarBar = new Template(ListTemplates.ListScrollableRegionVerticalScrollbarBar);
#if UNITY_EDITOR
                    _inventoryTestSceneList1ScrollableRegionVerticalScrollbarBar.Name = "InventoryTestSceneList1ScrollableRegionVerticalScrollbarBar";
#endif
                }
                return _inventoryTestSceneList1ScrollableRegionVerticalScrollbarBar;
            }
        }

        private static Template _inventoryTestSceneList1ScrollableRegionVerticalScrollbarHandle;
        public static Template InventoryTestSceneList1ScrollableRegionVerticalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_inventoryTestSceneList1ScrollableRegionVerticalScrollbarHandle == null || _inventoryTestSceneList1ScrollableRegionVerticalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_inventoryTestSceneList1ScrollableRegionVerticalScrollbarHandle == null)
#endif
                {
                    _inventoryTestSceneList1ScrollableRegionVerticalScrollbarHandle = new Template(ListTemplates.ListScrollableRegionVerticalScrollbarHandle);
#if UNITY_EDITOR
                    _inventoryTestSceneList1ScrollableRegionVerticalScrollbarHandle.Name = "InventoryTestSceneList1ScrollableRegionVerticalScrollbarHandle";
#endif
                }
                return _inventoryTestSceneList1ScrollableRegionVerticalScrollbarHandle;
            }
        }

        private static Template _inventoryTestSceneList1Content;
        public static Template InventoryTestSceneList1Content
        {
            get
            {
#if UNITY_EDITOR
                if (_inventoryTestSceneList1Content == null || _inventoryTestSceneList1Content.CurrentVersion != Template.Version)
#else
                if (_inventoryTestSceneList1Content == null)
#endif
                {
                    _inventoryTestSceneList1Content = new Template(ListItemTemplates.ListItem);
#if UNITY_EDITOR
                    _inventoryTestSceneList1Content.Name = "InventoryTestSceneList1Content";
#endif
                }
                return _inventoryTestSceneList1Content;
            }
        }

        private static Template _inventoryTestSceneLabel1;
        public static Template InventoryTestSceneLabel1
        {
            get
            {
#if UNITY_EDITOR
                if (_inventoryTestSceneLabel1 == null || _inventoryTestSceneLabel1.CurrentVersion != Template.Version)
#else
                if (_inventoryTestSceneLabel1 == null)
#endif
                {
                    _inventoryTestSceneLabel1 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _inventoryTestSceneLabel1.Name = "InventoryTestSceneLabel1";
#endif
                    Delight.Label.TextProperty.SetHasBinding(_inventoryTestSceneLabel1);
                }
                return _inventoryTestSceneLabel1;
            }
        }

        private static Template _inventoryTestSceneButton1;
        public static Template InventoryTestSceneButton1
        {
            get
            {
#if UNITY_EDITOR
                if (_inventoryTestSceneButton1 == null || _inventoryTestSceneButton1.CurrentVersion != Template.Version)
#else
                if (_inventoryTestSceneButton1 == null)
#endif
                {
                    _inventoryTestSceneButton1 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _inventoryTestSceneButton1.Name = "InventoryTestSceneButton1";
#endif
                    Delight.Button.AlignmentProperty.SetDefault(_inventoryTestSceneButton1, Delight.ElementAlignment.TopLeft);
                    Delight.Button.OffsetProperty.SetDefault(_inventoryTestSceneButton1, new ElementMargin(new ElementSize(10f, ElementSizeUnit.Pixels), new ElementSize(10f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels)));
                    Delight.Button.LabelTemplateProperty.SetDefault(_inventoryTestSceneButton1, InventoryTestSceneButton1Label);
                }
                return _inventoryTestSceneButton1;
            }
        }

        private static Template _inventoryTestSceneButton1Label;
        public static Template InventoryTestSceneButton1Label
        {
            get
            {
#if UNITY_EDITOR
                if (_inventoryTestSceneButton1Label == null || _inventoryTestSceneButton1Label.CurrentVersion != Template.Version)
#else
                if (_inventoryTestSceneButton1Label == null)
#endif
                {
                    _inventoryTestSceneButton1Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _inventoryTestSceneButton1Label.Name = "InventoryTestSceneButton1Label";
#endif
                    Delight.Label.TextProperty.SetDefault(_inventoryTestSceneButton1Label, "Add Item");
                }
                return _inventoryTestSceneButton1Label;
            }
        }

        #endregion
    }

    #endregion
}
