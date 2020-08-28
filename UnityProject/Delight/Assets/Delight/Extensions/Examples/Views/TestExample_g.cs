// Internal view logic generated from "TestExample.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class TestExample : LayoutRoot
    {
        #region Constructors

        public TestExample(View parent, View layoutParent = null, string id = null, Template template = null, bool deferInitialization = false) :
            base(parent, layoutParent, id, template ?? TestExampleTemplates.Default, deferInitialization)
        {
            if (deferInitialization)
                return;

            // constructing Group (Group1)
            Group1 = new Group(this, this, "Group1", Group1Template);
            List1 = new List(this, Group1.Content, "List1", List1Template);
            List1.ItemSelected.RegisterHandler(this, "OnItemSelected");

            // binding <List Items="{level in @FilteredDemoLevels}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> {  }, new List<Func<BindableObject>> {  }) }, new BindingPath(new List<string> { "List1", "Items" }, new List<Func<BindableObject>> { () => this, () => List1 }), () => List1.Items = Models.FilteredDemoLevels, () => { }, false));

            // templates for List1
            List1.ContentTemplates.Add(new ContentTemplate(tiLevel => 
            {
                var listItem1 = new ListItem(this, List1.Content, "ListItem1", ListItem1Template);
                listItem1.Click.RegisterHandler(() => Button1.Text = (tiLevel.Item as Delight.DemoLevel).Name);
                var label1 = new Label(this, listItem1.Content, "Label1", Label1Template);

                // binding <Label Text="$ {level.Name}">
                listItem1.Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "Item", "Name" }, new List<Func<BindableObject>> { () => tiLevel, () => (tiLevel.Item as Delight.DemoLevel) }) }, new BindingPath(new List<string> { "Text" }, new List<Func<BindableObject>> { () => label1 }), () => label1.Text = (tiLevel.Item as Delight.DemoLevel).Name, () => { }, false));
                listItem1.IsDynamic = true;
                listItem1.SetContentTemplateData(tiLevel);
                return listItem1;
            }, typeof(ListItem), "ListItem1"));
            Button1 = new Button(this, Group1.Content, "Button1", Button1Template);
            Button1.Click.RegisterHandler(this, "Test");
            this.AfterInitializeInternal();
        }

        public TestExample() : this(null)
        {
        }

        static TestExample()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(TestExampleTemplates.Default, dependencyProperties);

            dependencyProperties.Add(Group1Property);
            dependencyProperties.Add(Group1TemplateProperty);
            dependencyProperties.Add(List1Property);
            dependencyProperties.Add(List1TemplateProperty);
            dependencyProperties.Add(ListItem1Property);
            dependencyProperties.Add(ListItem1TemplateProperty);
            dependencyProperties.Add(Label1Property);
            dependencyProperties.Add(Label1TemplateProperty);
            dependencyProperties.Add(Button1Property);
            dependencyProperties.Add(Button1TemplateProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<Group> Group1Property = new DependencyProperty<Group>("Group1");
        public Group Group1
        {
            get { return Group1Property.GetValue(this); }
            set { Group1Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Group1TemplateProperty = new DependencyProperty<Template>("Group1Template");
        public Template Group1Template
        {
            get { return Group1TemplateProperty.GetValue(this); }
            set { Group1TemplateProperty.SetValue(this, value); }
        }

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

        public readonly static DependencyProperty<ListItem> ListItem1Property = new DependencyProperty<ListItem>("ListItem1");
        public ListItem ListItem1
        {
            get { return ListItem1Property.GetValue(this); }
            set { ListItem1Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> ListItem1TemplateProperty = new DependencyProperty<Template>("ListItem1Template");
        public Template ListItem1Template
        {
            get { return ListItem1TemplateProperty.GetValue(this); }
            set { ListItem1TemplateProperty.SetValue(this, value); }
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

        #endregion
    }

    #region Data Templates

    public static class TestExampleTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return TestExample;
            }
        }

        private static Template _testExample;
        public static Template TestExample
        {
            get
            {
#if UNITY_EDITOR
                if (_testExample == null || _testExample.CurrentVersion != Template.Version)
#else
                if (_testExample == null)
#endif
                {
                    _testExample = new Template(LayoutRootTemplates.LayoutRoot);
#if UNITY_EDITOR
                    _testExample.Name = "TestExample";
                    _testExample.LineNumber = 0;
                    _testExample.LinePosition = 0;
#endif
                    Delight.TestExample.Group1TemplateProperty.SetDefault(_testExample, TestExampleGroup1);
                    Delight.TestExample.List1TemplateProperty.SetDefault(_testExample, TestExampleList1);
                    Delight.TestExample.ListItem1TemplateProperty.SetDefault(_testExample, TestExampleListItem1);
                    Delight.TestExample.Label1TemplateProperty.SetDefault(_testExample, TestExampleLabel1);
                    Delight.TestExample.Button1TemplateProperty.SetDefault(_testExample, TestExampleButton1);
                }
                return _testExample;
            }
        }

        private static Template _testExampleGroup1;
        public static Template TestExampleGroup1
        {
            get
            {
#if UNITY_EDITOR
                if (_testExampleGroup1 == null || _testExampleGroup1.CurrentVersion != Template.Version)
#else
                if (_testExampleGroup1 == null)
#endif
                {
                    _testExampleGroup1 = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _testExampleGroup1.Name = "TestExampleGroup1";
                    _testExampleGroup1.LineNumber = 3;
                    _testExampleGroup1.LinePosition = 4;
#endif
                }
                return _testExampleGroup1;
            }
        }

        private static Template _testExampleList1;
        public static Template TestExampleList1
        {
            get
            {
#if UNITY_EDITOR
                if (_testExampleList1 == null || _testExampleList1.CurrentVersion != Template.Version)
#else
                if (_testExampleList1 == null)
#endif
                {
                    _testExampleList1 = new Template(ListTemplates.List);
#if UNITY_EDITOR
                    _testExampleList1.Name = "TestExampleList1";
                    _testExampleList1.LineNumber = 4;
                    _testExampleList1.LinePosition = 6;
#endif
                    Delight.List.ItemsProperty.SetHasBinding(_testExampleList1);
                    Delight.List.ScrollableRegionTemplateProperty.SetDefault(_testExampleList1, TestExampleList1ScrollableRegion);
                }
                return _testExampleList1;
            }
        }

        private static Template _testExampleList1ScrollableRegion;
        public static Template TestExampleList1ScrollableRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_testExampleList1ScrollableRegion == null || _testExampleList1ScrollableRegion.CurrentVersion != Template.Version)
#else
                if (_testExampleList1ScrollableRegion == null)
#endif
                {
                    _testExampleList1ScrollableRegion = new Template(ListTemplates.ListScrollableRegion);
#if UNITY_EDITOR
                    _testExampleList1ScrollableRegion.Name = "TestExampleList1ScrollableRegion";
                    _testExampleList1ScrollableRegion.LineNumber = 0;
                    _testExampleList1ScrollableRegion.LinePosition = 0;
#endif
                    Delight.ScrollableRegion.ContentRegionTemplateProperty.SetDefault(_testExampleList1ScrollableRegion, TestExampleList1ScrollableRegionContentRegion);
                    Delight.ScrollableRegion.HorizontalScrollbarTemplateProperty.SetDefault(_testExampleList1ScrollableRegion, TestExampleList1ScrollableRegionHorizontalScrollbar);
                    Delight.ScrollableRegion.VerticalScrollbarTemplateProperty.SetDefault(_testExampleList1ScrollableRegion, TestExampleList1ScrollableRegionVerticalScrollbar);
                }
                return _testExampleList1ScrollableRegion;
            }
        }

        private static Template _testExampleList1ScrollableRegionContentRegion;
        public static Template TestExampleList1ScrollableRegionContentRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_testExampleList1ScrollableRegionContentRegion == null || _testExampleList1ScrollableRegionContentRegion.CurrentVersion != Template.Version)
#else
                if (_testExampleList1ScrollableRegionContentRegion == null)
#endif
                {
                    _testExampleList1ScrollableRegionContentRegion = new Template(ListTemplates.ListScrollableRegionContentRegion);
#if UNITY_EDITOR
                    _testExampleList1ScrollableRegionContentRegion.Name = "TestExampleList1ScrollableRegionContentRegion";
                    _testExampleList1ScrollableRegionContentRegion.LineNumber = 0;
                    _testExampleList1ScrollableRegionContentRegion.LinePosition = 0;
#endif
                }
                return _testExampleList1ScrollableRegionContentRegion;
            }
        }

        private static Template _testExampleList1ScrollableRegionHorizontalScrollbar;
        public static Template TestExampleList1ScrollableRegionHorizontalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_testExampleList1ScrollableRegionHorizontalScrollbar == null || _testExampleList1ScrollableRegionHorizontalScrollbar.CurrentVersion != Template.Version)
#else
                if (_testExampleList1ScrollableRegionHorizontalScrollbar == null)
#endif
                {
                    _testExampleList1ScrollableRegionHorizontalScrollbar = new Template(ListTemplates.ListScrollableRegionHorizontalScrollbar);
#if UNITY_EDITOR
                    _testExampleList1ScrollableRegionHorizontalScrollbar.Name = "TestExampleList1ScrollableRegionHorizontalScrollbar";
                    _testExampleList1ScrollableRegionHorizontalScrollbar.LineNumber = 0;
                    _testExampleList1ScrollableRegionHorizontalScrollbar.LinePosition = 0;
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_testExampleList1ScrollableRegionHorizontalScrollbar, TestExampleList1ScrollableRegionHorizontalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_testExampleList1ScrollableRegionHorizontalScrollbar, TestExampleList1ScrollableRegionHorizontalScrollbarHandle);
                }
                return _testExampleList1ScrollableRegionHorizontalScrollbar;
            }
        }

        private static Template _testExampleList1ScrollableRegionHorizontalScrollbarBar;
        public static Template TestExampleList1ScrollableRegionHorizontalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_testExampleList1ScrollableRegionHorizontalScrollbarBar == null || _testExampleList1ScrollableRegionHorizontalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_testExampleList1ScrollableRegionHorizontalScrollbarBar == null)
#endif
                {
                    _testExampleList1ScrollableRegionHorizontalScrollbarBar = new Template(ListTemplates.ListScrollableRegionHorizontalScrollbarBar);
#if UNITY_EDITOR
                    _testExampleList1ScrollableRegionHorizontalScrollbarBar.Name = "TestExampleList1ScrollableRegionHorizontalScrollbarBar";
                    _testExampleList1ScrollableRegionHorizontalScrollbarBar.LineNumber = 0;
                    _testExampleList1ScrollableRegionHorizontalScrollbarBar.LinePosition = 0;
#endif
                }
                return _testExampleList1ScrollableRegionHorizontalScrollbarBar;
            }
        }

        private static Template _testExampleList1ScrollableRegionHorizontalScrollbarHandle;
        public static Template TestExampleList1ScrollableRegionHorizontalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_testExampleList1ScrollableRegionHorizontalScrollbarHandle == null || _testExampleList1ScrollableRegionHorizontalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_testExampleList1ScrollableRegionHorizontalScrollbarHandle == null)
#endif
                {
                    _testExampleList1ScrollableRegionHorizontalScrollbarHandle = new Template(ListTemplates.ListScrollableRegionHorizontalScrollbarHandle);
#if UNITY_EDITOR
                    _testExampleList1ScrollableRegionHorizontalScrollbarHandle.Name = "TestExampleList1ScrollableRegionHorizontalScrollbarHandle";
                    _testExampleList1ScrollableRegionHorizontalScrollbarHandle.LineNumber = 0;
                    _testExampleList1ScrollableRegionHorizontalScrollbarHandle.LinePosition = 0;
#endif
                }
                return _testExampleList1ScrollableRegionHorizontalScrollbarHandle;
            }
        }

        private static Template _testExampleList1ScrollableRegionVerticalScrollbar;
        public static Template TestExampleList1ScrollableRegionVerticalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_testExampleList1ScrollableRegionVerticalScrollbar == null || _testExampleList1ScrollableRegionVerticalScrollbar.CurrentVersion != Template.Version)
#else
                if (_testExampleList1ScrollableRegionVerticalScrollbar == null)
#endif
                {
                    _testExampleList1ScrollableRegionVerticalScrollbar = new Template(ListTemplates.ListScrollableRegionVerticalScrollbar);
#if UNITY_EDITOR
                    _testExampleList1ScrollableRegionVerticalScrollbar.Name = "TestExampleList1ScrollableRegionVerticalScrollbar";
                    _testExampleList1ScrollableRegionVerticalScrollbar.LineNumber = 0;
                    _testExampleList1ScrollableRegionVerticalScrollbar.LinePosition = 0;
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_testExampleList1ScrollableRegionVerticalScrollbar, TestExampleList1ScrollableRegionVerticalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_testExampleList1ScrollableRegionVerticalScrollbar, TestExampleList1ScrollableRegionVerticalScrollbarHandle);
                }
                return _testExampleList1ScrollableRegionVerticalScrollbar;
            }
        }

        private static Template _testExampleList1ScrollableRegionVerticalScrollbarBar;
        public static Template TestExampleList1ScrollableRegionVerticalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_testExampleList1ScrollableRegionVerticalScrollbarBar == null || _testExampleList1ScrollableRegionVerticalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_testExampleList1ScrollableRegionVerticalScrollbarBar == null)
#endif
                {
                    _testExampleList1ScrollableRegionVerticalScrollbarBar = new Template(ListTemplates.ListScrollableRegionVerticalScrollbarBar);
#if UNITY_EDITOR
                    _testExampleList1ScrollableRegionVerticalScrollbarBar.Name = "TestExampleList1ScrollableRegionVerticalScrollbarBar";
                    _testExampleList1ScrollableRegionVerticalScrollbarBar.LineNumber = 0;
                    _testExampleList1ScrollableRegionVerticalScrollbarBar.LinePosition = 0;
#endif
                }
                return _testExampleList1ScrollableRegionVerticalScrollbarBar;
            }
        }

        private static Template _testExampleList1ScrollableRegionVerticalScrollbarHandle;
        public static Template TestExampleList1ScrollableRegionVerticalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_testExampleList1ScrollableRegionVerticalScrollbarHandle == null || _testExampleList1ScrollableRegionVerticalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_testExampleList1ScrollableRegionVerticalScrollbarHandle == null)
#endif
                {
                    _testExampleList1ScrollableRegionVerticalScrollbarHandle = new Template(ListTemplates.ListScrollableRegionVerticalScrollbarHandle);
#if UNITY_EDITOR
                    _testExampleList1ScrollableRegionVerticalScrollbarHandle.Name = "TestExampleList1ScrollableRegionVerticalScrollbarHandle";
                    _testExampleList1ScrollableRegionVerticalScrollbarHandle.LineNumber = 0;
                    _testExampleList1ScrollableRegionVerticalScrollbarHandle.LinePosition = 0;
#endif
                }
                return _testExampleList1ScrollableRegionVerticalScrollbarHandle;
            }
        }

        private static Template _testExampleListItem1;
        public static Template TestExampleListItem1
        {
            get
            {
#if UNITY_EDITOR
                if (_testExampleListItem1 == null || _testExampleListItem1.CurrentVersion != Template.Version)
#else
                if (_testExampleListItem1 == null)
#endif
                {
                    _testExampleListItem1 = new Template(ListItemTemplates.ListItem);
#if UNITY_EDITOR
                    _testExampleListItem1.Name = "TestExampleListItem1";
                    _testExampleListItem1.LineNumber = 5;
                    _testExampleListItem1.LinePosition = 8;
#endif
                }
                return _testExampleListItem1;
            }
        }

        private static Template _testExampleLabel1;
        public static Template TestExampleLabel1
        {
            get
            {
#if UNITY_EDITOR
                if (_testExampleLabel1 == null || _testExampleLabel1.CurrentVersion != Template.Version)
#else
                if (_testExampleLabel1 == null)
#endif
                {
                    _testExampleLabel1 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _testExampleLabel1.Name = "TestExampleLabel1";
                    _testExampleLabel1.LineNumber = 6;
                    _testExampleLabel1.LinePosition = 10;
#endif
                    Delight.Label.TextProperty.SetHasBinding(_testExampleLabel1);
                }
                return _testExampleLabel1;
            }
        }

        private static Template _testExampleButton1;
        public static Template TestExampleButton1
        {
            get
            {
#if UNITY_EDITOR
                if (_testExampleButton1 == null || _testExampleButton1.CurrentVersion != Template.Version)
#else
                if (_testExampleButton1 == null)
#endif
                {
                    _testExampleButton1 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _testExampleButton1.Name = "TestExampleButton1";
                    _testExampleButton1.LineNumber = 9;
                    _testExampleButton1.LinePosition = 6;
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_testExampleButton1, TestExampleButton1Label);
                }
                return _testExampleButton1;
            }
        }

        private static Template _testExampleButton1Label;
        public static Template TestExampleButton1Label
        {
            get
            {
#if UNITY_EDITOR
                if (_testExampleButton1Label == null || _testExampleButton1Label.CurrentVersion != Template.Version)
#else
                if (_testExampleButton1Label == null)
#endif
                {
                    _testExampleButton1Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _testExampleButton1Label.Name = "TestExampleButton1Label";
                    _testExampleButton1Label.LineNumber = 0;
                    _testExampleButton1Label.LinePosition = 0;
#endif
                    Delight.Label.TextProperty.SetDefault(_testExampleButton1Label, "Test");
                }
                return _testExampleButton1Label;
            }
        }

        #endregion
    }

    #endregion
}
