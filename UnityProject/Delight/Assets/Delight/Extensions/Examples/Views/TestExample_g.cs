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
                listItem1.Click.RegisterHandler(() => MyButton.Text = (tiLevel.Item as Delight.DemoLevel).Name);
                var group2 = new Group(this, listItem1.Content, "Group2", Group2Template);
                var label1 = new Label(this, group2.Content, "Label1", Label1Template);

                // binding <Label Text="$ {level.Name}">
                listItem1.Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "Item", "Name" }, new List<Func<BindableObject>> { () => tiLevel, () => (tiLevel.Item as Delight.DemoLevel) }) }, new BindingPath(new List<string> { "Text" }, new List<Func<BindableObject>> { () => label1 }), () => label1.Text = (tiLevel.Item as Delight.DemoLevel).Name, () => { }, false));
                var label2 = new Label(this, group2.Content, "Label2", Label2Template);
                // binding <Label Text="$ Test2(40)">
                listItem1.Bindings.Add(new Binding(() => label2.Text = Test2(40)));
                var label3 = new Label(this, group2.Content, "Label3", Label3Template);

                // binding <Label Text="$ {{ string name = {level.Name}; return name + '!'; }}">
                listItem1.Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "Item", "Name" }, new List<Func<BindableObject>> { () => tiLevel, () => (tiLevel.Item as Delight.DemoLevel) }) }, new BindingPath(new List<string> { "Text" }, new List<Func<BindableObject>> { () => label3 }), () => label3.Text = ((Func<System.String>)(() => { string name = (tiLevel.Item as Delight.DemoLevel).Name; return name + "!"; } ))(), () => { }, false));
                var button1 = new Button(this, group2.Content, "Button1", Button1Template);
                button1.Click.RegisterHandler(() => {{ string name = (tiLevel.Item as Delight.DemoLevel).Name; Test2(10); return; }});

                // binding <Button Text="$ {level.Index} + '. Test'">
                listItem1.Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "Index" }, new List<Func<BindableObject>> { () => tiLevel }) }, new BindingPath(new List<string> { "Text" }, new List<Func<BindableObject>> { () => button1 }), () => button1.Text = tiLevel.Index + ". Test", () => { }, false));
                listItem1.IsDynamic = true;
                listItem1.SetContentTemplateData(tiLevel);
                return listItem1;
            }, typeof(ListItem), "ListItem1"));
            MyButton = new Button(this, Group1.Content, "MyButton", MyButtonTemplate);
            MyButton.Click.RegisterHandler(this, "Test");
            Label4 = new Label(this, Group1.Content, "Label4", Label4Template);
            // binding <Label Text="$ {{ string test = "hello"; return test; }}">
            Bindings.Add(new Binding(() => Label4.Text = ((Func<System.String>)(() => {{ string test = "hello"; return test; }} ))()));
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
            dependencyProperties.Add(Group2Property);
            dependencyProperties.Add(Group2TemplateProperty);
            dependencyProperties.Add(Label1Property);
            dependencyProperties.Add(Label1TemplateProperty);
            dependencyProperties.Add(Label2Property);
            dependencyProperties.Add(Label2TemplateProperty);
            dependencyProperties.Add(Label3Property);
            dependencyProperties.Add(Label3TemplateProperty);
            dependencyProperties.Add(Button1Property);
            dependencyProperties.Add(Button1TemplateProperty);
            dependencyProperties.Add(MyButtonProperty);
            dependencyProperties.Add(MyButtonTemplateProperty);
            dependencyProperties.Add(Label4Property);
            dependencyProperties.Add(Label4TemplateProperty);
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

        public readonly static DependencyProperty<Group> Group2Property = new DependencyProperty<Group>("Group2");
        public Group Group2
        {
            get { return Group2Property.GetValue(this); }
            set { Group2Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Group2TemplateProperty = new DependencyProperty<Template>("Group2Template");
        public Template Group2Template
        {
            get { return Group2TemplateProperty.GetValue(this); }
            set { Group2TemplateProperty.SetValue(this, value); }
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

        public readonly static DependencyProperty<Label> Label2Property = new DependencyProperty<Label>("Label2");
        public Label Label2
        {
            get { return Label2Property.GetValue(this); }
            set { Label2Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Label2TemplateProperty = new DependencyProperty<Template>("Label2Template");
        public Template Label2Template
        {
            get { return Label2TemplateProperty.GetValue(this); }
            set { Label2TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Label> Label3Property = new DependencyProperty<Label>("Label3");
        public Label Label3
        {
            get { return Label3Property.GetValue(this); }
            set { Label3Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Label3TemplateProperty = new DependencyProperty<Template>("Label3Template");
        public Template Label3Template
        {
            get { return Label3TemplateProperty.GetValue(this); }
            set { Label3TemplateProperty.SetValue(this, value); }
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

        public readonly static DependencyProperty<Button> MyButtonProperty = new DependencyProperty<Button>("MyButton");
        public Button MyButton
        {
            get { return MyButtonProperty.GetValue(this); }
            set { MyButtonProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> MyButtonTemplateProperty = new DependencyProperty<Template>("MyButtonTemplate");
        public Template MyButtonTemplate
        {
            get { return MyButtonTemplateProperty.GetValue(this); }
            set { MyButtonTemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Label> Label4Property = new DependencyProperty<Label>("Label4");
        public Label Label4
        {
            get { return Label4Property.GetValue(this); }
            set { Label4Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Label4TemplateProperty = new DependencyProperty<Template>("Label4Template");
        public Template Label4Template
        {
            get { return Label4TemplateProperty.GetValue(this); }
            set { Label4TemplateProperty.SetValue(this, value); }
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
                    Delight.TestExample.Group2TemplateProperty.SetDefault(_testExample, TestExampleGroup2);
                    Delight.TestExample.Label1TemplateProperty.SetDefault(_testExample, TestExampleLabel1);
                    Delight.TestExample.Label2TemplateProperty.SetDefault(_testExample, TestExampleLabel2);
                    Delight.TestExample.Label3TemplateProperty.SetDefault(_testExample, TestExampleLabel3);
                    Delight.TestExample.Button1TemplateProperty.SetDefault(_testExample, TestExampleButton1);
                    Delight.TestExample.MyButtonTemplateProperty.SetDefault(_testExample, TestExampleMyButton);
                    Delight.TestExample.Label4TemplateProperty.SetDefault(_testExample, TestExampleLabel4);
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
                    _testExampleList1ScrollableRegion.LineNumber = 27;
                    _testExampleList1ScrollableRegion.LinePosition = 4;
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
                    _testExampleList1ScrollableRegionContentRegion.LineNumber = 24;
                    _testExampleList1ScrollableRegionContentRegion.LinePosition = 4;
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
                    _testExampleList1ScrollableRegionHorizontalScrollbar.LineNumber = 26;
                    _testExampleList1ScrollableRegionHorizontalScrollbar.LinePosition = 4;
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
                    _testExampleList1ScrollableRegionHorizontalScrollbarBar.LineNumber = 7;
                    _testExampleList1ScrollableRegionHorizontalScrollbarBar.LinePosition = 4;
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
                    _testExampleList1ScrollableRegionHorizontalScrollbarHandle.LineNumber = 8;
                    _testExampleList1ScrollableRegionHorizontalScrollbarHandle.LinePosition = 6;
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
                    _testExampleList1ScrollableRegionVerticalScrollbar.LineNumber = 27;
                    _testExampleList1ScrollableRegionVerticalScrollbar.LinePosition = 4;
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
                    _testExampleList1ScrollableRegionVerticalScrollbarBar.LineNumber = 7;
                    _testExampleList1ScrollableRegionVerticalScrollbarBar.LinePosition = 4;
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
                    _testExampleList1ScrollableRegionVerticalScrollbarHandle.LineNumber = 8;
                    _testExampleList1ScrollableRegionVerticalScrollbarHandle.LinePosition = 6;
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

        private static Template _testExampleGroup2;
        public static Template TestExampleGroup2
        {
            get
            {
#if UNITY_EDITOR
                if (_testExampleGroup2 == null || _testExampleGroup2.CurrentVersion != Template.Version)
#else
                if (_testExampleGroup2 == null)
#endif
                {
                    _testExampleGroup2 = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _testExampleGroup2.Name = "TestExampleGroup2";
                    _testExampleGroup2.LineNumber = 6;
                    _testExampleGroup2.LinePosition = 10;
#endif
                    Delight.Group.OrientationProperty.SetDefault(_testExampleGroup2, Delight.ElementOrientation.Horizontal);
                }
                return _testExampleGroup2;
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
                    _testExampleLabel1.LineNumber = 7;
                    _testExampleLabel1.LinePosition = 12;
#endif
                    Delight.Label.AutoSizeProperty.SetDefault(_testExampleLabel1, Delight.AutoSize.Default);
                    Delight.Label.TextProperty.SetHasBinding(_testExampleLabel1);
                }
                return _testExampleLabel1;
            }
        }

        private static Template _testExampleLabel2;
        public static Template TestExampleLabel2
        {
            get
            {
#if UNITY_EDITOR
                if (_testExampleLabel2 == null || _testExampleLabel2.CurrentVersion != Template.Version)
#else
                if (_testExampleLabel2 == null)
#endif
                {
                    _testExampleLabel2 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _testExampleLabel2.Name = "TestExampleLabel2";
                    _testExampleLabel2.LineNumber = 8;
                    _testExampleLabel2.LinePosition = 12;
#endif
                    Delight.Label.AutoSizeProperty.SetDefault(_testExampleLabel2, Delight.AutoSize.Default);
                }
                return _testExampleLabel2;
            }
        }

        private static Template _testExampleLabel3;
        public static Template TestExampleLabel3
        {
            get
            {
#if UNITY_EDITOR
                if (_testExampleLabel3 == null || _testExampleLabel3.CurrentVersion != Template.Version)
#else
                if (_testExampleLabel3 == null)
#endif
                {
                    _testExampleLabel3 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _testExampleLabel3.Name = "TestExampleLabel3";
                    _testExampleLabel3.LineNumber = 9;
                    _testExampleLabel3.LinePosition = 12;
#endif
                    Delight.Label.TextProperty.SetHasBinding(_testExampleLabel3);
                }
                return _testExampleLabel3;
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
                    _testExampleButton1.LineNumber = 10;
                    _testExampleButton1.LinePosition = 12;
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
                    _testExampleButton1Label.LineNumber = 15;
                    _testExampleButton1Label.LinePosition = 4;
#endif
                    Delight.Label.TextProperty.SetHasBinding(_testExampleButton1Label);
                }
                return _testExampleButton1Label;
            }
        }

        private static Template _testExampleMyButton;
        public static Template TestExampleMyButton
        {
            get
            {
#if UNITY_EDITOR
                if (_testExampleMyButton == null || _testExampleMyButton.CurrentVersion != Template.Version)
#else
                if (_testExampleMyButton == null)
#endif
                {
                    _testExampleMyButton = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _testExampleMyButton.Name = "TestExampleMyButton";
                    _testExampleMyButton.LineNumber = 14;
                    _testExampleMyButton.LinePosition = 6;
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_testExampleMyButton, TestExampleMyButtonLabel);
                }
                return _testExampleMyButton;
            }
        }

        private static Template _testExampleMyButtonLabel;
        public static Template TestExampleMyButtonLabel
        {
            get
            {
#if UNITY_EDITOR
                if (_testExampleMyButtonLabel == null || _testExampleMyButtonLabel.CurrentVersion != Template.Version)
#else
                if (_testExampleMyButtonLabel == null)
#endif
                {
                    _testExampleMyButtonLabel = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _testExampleMyButtonLabel.Name = "TestExampleMyButtonLabel";
                    _testExampleMyButtonLabel.LineNumber = 15;
                    _testExampleMyButtonLabel.LinePosition = 4;
#endif
                    Delight.Label.TextProperty.SetDefault(_testExampleMyButtonLabel, "Test");
                }
                return _testExampleMyButtonLabel;
            }
        }

        private static Template _testExampleLabel4;
        public static Template TestExampleLabel4
        {
            get
            {
#if UNITY_EDITOR
                if (_testExampleLabel4 == null || _testExampleLabel4.CurrentVersion != Template.Version)
#else
                if (_testExampleLabel4 == null)
#endif
                {
                    _testExampleLabel4 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _testExampleLabel4.Name = "TestExampleLabel4";
                    _testExampleLabel4.LineNumber = 15;
                    _testExampleLabel4.LinePosition = 6;
#endif
                }
                return _testExampleLabel4;
            }
        }

        #endregion
    }

    #endregion
}
