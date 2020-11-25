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
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> {  }, new List<Func<object>> {  }) }, new BindingPath(new List<string> { "List1", "Items" }, new List<Func<object>> { () => this, () => List1 }), () => List1.Items = Models.FilteredDemoLevels, () => { }, false));

            // templates for List1
            List1.ContentTemplates.Add(new ContentTemplate(tiLevel => 
            {
                var listItem1 = new ListItem(this, List1.Content, "ListItem1", ListItem1Template);
                listItem1.Click.RegisterHandler(() => MyButton.Text = (tiLevel.Item as Delight.DemoLevel).Name);
                var group2 = new Group(this, listItem1.Content, "Group2", Group2Template);
                var label1 = new Label(this, group2.Content, "Label1", Label1Template);

                // binding <Label Text="$ {level.Name}">
                listItem1.Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "Item", "Name" }, new List<Func<object>> { () => tiLevel, () => (tiLevel.Item as Delight.DemoLevel) }) }, new BindingPath(new List<string> { "Text" }, new List<Func<object>> { () => label1 }), () => label1.Text = (tiLevel.Item as Delight.DemoLevel).Name, () => { }, false));
                var label2 = new Label(this, group2.Content, "Label2", Label2Template);
                // binding <Label Text="$ Test2(40)">
                listItem1.Bindings.Add(new Binding(() => label2.Text = Test2(40)));
                var label3 = new Label(this, group2.Content, "Label3", Label3Template);

                // binding <Label Text="$ {{ string name = {level.Name}; return name + '!'; }}">
                listItem1.Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "Item", "Name" }, new List<Func<object>> { () => tiLevel, () => (tiLevel.Item as Delight.DemoLevel) }) }, new BindingPath(new List<string> { "Text" }, new List<Func<object>> { () => label3 }), () => label3.Text = ((Func<System.String>)(() => { string name = (tiLevel.Item as Delight.DemoLevel).Name; return name + "!"; } ))(), () => { }, false));
                var button1 = new Button(this, group2.Content, "Button1", Button1Template);
                button1.Click.RegisterHandler(() => {{ string name = (tiLevel.Item as Delight.DemoLevel).Name; Test2(10); return; }});

                // binding <Button Text="$ {level.Index} + '. Test'">
                listItem1.Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "Index" }, new List<Func<object>> { () => tiLevel }) }, new BindingPath(new List<string> { "Text" }, new List<Func<object>> { () => button1 }), () => button1.Text = tiLevel.Index + ". Test", () => { }, false));
                listItem1.IsDynamic = true;
                listItem1.SetContentTemplateData(tiLevel);
                return listItem1;
            }, typeof(ListItem), "ListItem1"));
            MyButton = new Button(this, Group1.Content, "MyButton", MyButtonTemplate);
            MyButton.Click.RegisterHandler(this, "Test");
            Label4 = new Label(this, Group1.Content, "Label4", Label4Template);
            // binding <Label Text="$ {{ string test = "hello"; return test; }}">
            Bindings.Add(new Binding(() => Label4.Text = ((Func<System.String>)(() => {{ string test = "hello"; return test; }} ))()));
            Label5 = new Label(this, Group1.Content, "Label5", Label5Template);

            // binding <Label Text="{Player.Name}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "Player", "Name" }, new List<Func<object>> { () => this, () => Player }) }, new BindingPath(new List<string> { "Label5", "Text" }, new List<Func<object>> { () => this, () => Label5 }), () => Label5.Text = Player.Name, () => { }, false));
            Button2 = new Button(this, Group1.Content, "Button2", Button2Template);
            Button2.Click.RegisterHandler(this, "NonBindableTest1");
            Button3 = new Button(this, Group1.Content, "Button3", Button3Template);
            Button3.Click.RegisterHandler(this, "NonBindableTest2");
            Label6 = new Label(this, Group1.Content, "Label6", Label6Template);

            // binding <Label Text="{NonBindableLevel.Name}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "NonBindableLevel", "Name" }, new List<Func<object>> { () => this, () => NonBindableLevel }) }, new BindingPath(new List<string> { "Label6", "Text" }, new List<Func<object>> { () => this, () => Label6 }), () => Label6.Text = NonBindableLevel.Name, () => { }, false));
            List2 = new List(this, Group1.Content, "List2", List2Template);

            // binding <List Items="{level2 in @NonBindableLevels}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> {  }, new List<Func<object>> {  }) }, new BindingPath(new List<string> { "List2", "Items" }, new List<Func<object>> { () => this, () => List2 }), () => List2.Items = Models.NonBindableLevels.ToBindableCollection(LayoutRoot), () => { }, false));

            // templates for List2
            List2.ContentTemplates.Add(new ContentTemplate(tiLevel2 => 
            {
                var listItem2 = new ListItem(this, List2.Content, "ListItem2", ListItem2Template);
                listItem2.Click.RegisterHandler(() => MyButton.Text = (tiLevel2.Item as Delight.NonBindableLevel).Name);
                var group3 = new Group(this, listItem2.Content, "Group3", Group3Template);
                var label7 = new Label(this, group3.Content, "Label7", Label7Template);

                // binding <Label Text="$ {level2.Name}">
                listItem2.Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "Item", "Name" }, new List<Func<object>> { () => tiLevel2, () => (tiLevel2.Item as Delight.NonBindableLevel) }) }, new BindingPath(new List<string> { "Text" }, new List<Func<object>> { () => label7 }), () => label7.Text = (tiLevel2.Item as Delight.NonBindableLevel).Name, () => { }, false));
                var button4 = new Button(this, group3.Content, "Button4", Button4Template);
                button4.Click.RegisterHandler(this, "AddLevel", () => (tiLevel2.Item as Delight.NonBindableLevel));
                var button5 = new Button(this, group3.Content, "Button5", Button5Template);
                button5.Click.RegisterHandler(this, "RemoveLevel", () => (tiLevel2.Item as Delight.NonBindableLevel));
                listItem2.IsDynamic = true;
                listItem2.SetContentTemplateData(tiLevel2);
                return listItem2;
            }, typeof(ListItem), "ListItem2"));
            this.AfterInitializeInternal();
        }

        public TestExample() : this(null)
        {
        }

        static TestExample()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(TestExampleTemplates.Default, dependencyProperties);

            dependencyProperties.Add(PlayerProperty);
            dependencyProperties.Add(NonBindableLevelProperty);
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
            dependencyProperties.Add(Label5Property);
            dependencyProperties.Add(Label5TemplateProperty);
            dependencyProperties.Add(Button2Property);
            dependencyProperties.Add(Button2TemplateProperty);
            dependencyProperties.Add(Button3Property);
            dependencyProperties.Add(Button3TemplateProperty);
            dependencyProperties.Add(Label6Property);
            dependencyProperties.Add(Label6TemplateProperty);
            dependencyProperties.Add(List2Property);
            dependencyProperties.Add(List2TemplateProperty);
            dependencyProperties.Add(ListItem2Property);
            dependencyProperties.Add(ListItem2TemplateProperty);
            dependencyProperties.Add(Group3Property);
            dependencyProperties.Add(Group3TemplateProperty);
            dependencyProperties.Add(Label7Property);
            dependencyProperties.Add(Label7TemplateProperty);
            dependencyProperties.Add(Button4Property);
            dependencyProperties.Add(Button4TemplateProperty);
            dependencyProperties.Add(Button5Property);
            dependencyProperties.Add(Button5TemplateProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<Delight.DemoPlayer> PlayerProperty = new DependencyProperty<Delight.DemoPlayer>("Player");
        public Delight.DemoPlayer Player
        {
            get { return PlayerProperty.GetValue(this); }
            set { PlayerProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Delight.NonBindableLevel> NonBindableLevelProperty = new DependencyProperty<Delight.NonBindableLevel>("NonBindableLevel");
        public Delight.NonBindableLevel NonBindableLevel
        {
            get { return NonBindableLevelProperty.GetValue(this); }
            set { NonBindableLevelProperty.SetValue(this, value); }
        }

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

        public readonly static DependencyProperty<Label> Label5Property = new DependencyProperty<Label>("Label5");
        public Label Label5
        {
            get { return Label5Property.GetValue(this); }
            set { Label5Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Label5TemplateProperty = new DependencyProperty<Template>("Label5Template");
        public Template Label5Template
        {
            get { return Label5TemplateProperty.GetValue(this); }
            set { Label5TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Button> Button2Property = new DependencyProperty<Button>("Button2");
        public Button Button2
        {
            get { return Button2Property.GetValue(this); }
            set { Button2Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Button2TemplateProperty = new DependencyProperty<Template>("Button2Template");
        public Template Button2Template
        {
            get { return Button2TemplateProperty.GetValue(this); }
            set { Button2TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Button> Button3Property = new DependencyProperty<Button>("Button3");
        public Button Button3
        {
            get { return Button3Property.GetValue(this); }
            set { Button3Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Button3TemplateProperty = new DependencyProperty<Template>("Button3Template");
        public Template Button3Template
        {
            get { return Button3TemplateProperty.GetValue(this); }
            set { Button3TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Label> Label6Property = new DependencyProperty<Label>("Label6");
        public Label Label6
        {
            get { return Label6Property.GetValue(this); }
            set { Label6Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Label6TemplateProperty = new DependencyProperty<Template>("Label6Template");
        public Template Label6Template
        {
            get { return Label6TemplateProperty.GetValue(this); }
            set { Label6TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<List> List2Property = new DependencyProperty<List>("List2");
        public List List2
        {
            get { return List2Property.GetValue(this); }
            set { List2Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> List2TemplateProperty = new DependencyProperty<Template>("List2Template");
        public Template List2Template
        {
            get { return List2TemplateProperty.GetValue(this); }
            set { List2TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ListItem> ListItem2Property = new DependencyProperty<ListItem>("ListItem2");
        public ListItem ListItem2
        {
            get { return ListItem2Property.GetValue(this); }
            set { ListItem2Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> ListItem2TemplateProperty = new DependencyProperty<Template>("ListItem2Template");
        public Template ListItem2Template
        {
            get { return ListItem2TemplateProperty.GetValue(this); }
            set { ListItem2TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Group> Group3Property = new DependencyProperty<Group>("Group3");
        public Group Group3
        {
            get { return Group3Property.GetValue(this); }
            set { Group3Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Group3TemplateProperty = new DependencyProperty<Template>("Group3Template");
        public Template Group3Template
        {
            get { return Group3TemplateProperty.GetValue(this); }
            set { Group3TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Label> Label7Property = new DependencyProperty<Label>("Label7");
        public Label Label7
        {
            get { return Label7Property.GetValue(this); }
            set { Label7Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Label7TemplateProperty = new DependencyProperty<Template>("Label7Template");
        public Template Label7Template
        {
            get { return Label7TemplateProperty.GetValue(this); }
            set { Label7TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Button> Button4Property = new DependencyProperty<Button>("Button4");
        public Button Button4
        {
            get { return Button4Property.GetValue(this); }
            set { Button4Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Button4TemplateProperty = new DependencyProperty<Template>("Button4Template");
        public Template Button4Template
        {
            get { return Button4TemplateProperty.GetValue(this); }
            set { Button4TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Button> Button5Property = new DependencyProperty<Button>("Button5");
        public Button Button5
        {
            get { return Button5Property.GetValue(this); }
            set { Button5Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Button5TemplateProperty = new DependencyProperty<Template>("Button5Template");
        public Template Button5Template
        {
            get { return Button5TemplateProperty.GetValue(this); }
            set { Button5TemplateProperty.SetValue(this, value); }
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
                    Delight.TestExample.PlayerProperty.SetDefault(_testExample, Models.DemoPlayers["Player1"]);
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
                    Delight.TestExample.Label5TemplateProperty.SetDefault(_testExample, TestExampleLabel5);
                    Delight.TestExample.Button2TemplateProperty.SetDefault(_testExample, TestExampleButton2);
                    Delight.TestExample.Button3TemplateProperty.SetDefault(_testExample, TestExampleButton3);
                    Delight.TestExample.Label6TemplateProperty.SetDefault(_testExample, TestExampleLabel6);
                    Delight.TestExample.List2TemplateProperty.SetDefault(_testExample, TestExampleList2);
                    Delight.TestExample.ListItem2TemplateProperty.SetDefault(_testExample, TestExampleListItem2);
                    Delight.TestExample.Group3TemplateProperty.SetDefault(_testExample, TestExampleGroup3);
                    Delight.TestExample.Label7TemplateProperty.SetDefault(_testExample, TestExampleLabel7);
                    Delight.TestExample.Button4TemplateProperty.SetDefault(_testExample, TestExampleButton4);
                    Delight.TestExample.Button5TemplateProperty.SetDefault(_testExample, TestExampleButton5);
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
                    _testExampleGroup1.LineNumber = 4;
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
                    _testExampleList1.LineNumber = 5;
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
                    _testExampleList1ScrollableRegion.LineNumber = 29;
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
                    _testExampleListItem1.LineNumber = 6;
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
                    _testExampleGroup2.LineNumber = 7;
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
                    _testExampleLabel1.LineNumber = 8;
                    _testExampleLabel1.LinePosition = 12;
#endif
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
                    _testExampleLabel2.LineNumber = 9;
                    _testExampleLabel2.LinePosition = 12;
#endif
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
                    _testExampleLabel3.LineNumber = 10;
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
                    _testExampleButton1.LineNumber = 11;
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
                    _testExampleMyButton.LineNumber = 15;
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
                    _testExampleLabel4.LineNumber = 16;
                    _testExampleLabel4.LinePosition = 6;
#endif
                }
                return _testExampleLabel4;
            }
        }

        private static Template _testExampleLabel5;
        public static Template TestExampleLabel5
        {
            get
            {
#if UNITY_EDITOR
                if (_testExampleLabel5 == null || _testExampleLabel5.CurrentVersion != Template.Version)
#else
                if (_testExampleLabel5 == null)
#endif
                {
                    _testExampleLabel5 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _testExampleLabel5.Name = "TestExampleLabel5";
                    _testExampleLabel5.LineNumber = 17;
                    _testExampleLabel5.LinePosition = 6;
#endif
                    Delight.Label.TextProperty.SetHasBinding(_testExampleLabel5);
                }
                return _testExampleLabel5;
            }
        }

        private static Template _testExampleButton2;
        public static Template TestExampleButton2
        {
            get
            {
#if UNITY_EDITOR
                if (_testExampleButton2 == null || _testExampleButton2.CurrentVersion != Template.Version)
#else
                if (_testExampleButton2 == null)
#endif
                {
                    _testExampleButton2 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _testExampleButton2.Name = "TestExampleButton2";
                    _testExampleButton2.LineNumber = 18;
                    _testExampleButton2.LinePosition = 6;
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_testExampleButton2, TestExampleButton2Label);
                }
                return _testExampleButton2;
            }
        }

        private static Template _testExampleButton2Label;
        public static Template TestExampleButton2Label
        {
            get
            {
#if UNITY_EDITOR
                if (_testExampleButton2Label == null || _testExampleButton2Label.CurrentVersion != Template.Version)
#else
                if (_testExampleButton2Label == null)
#endif
                {
                    _testExampleButton2Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _testExampleButton2Label.Name = "TestExampleButton2Label";
                    _testExampleButton2Label.LineNumber = 15;
                    _testExampleButton2Label.LinePosition = 4;
#endif
                    Delight.Label.TextProperty.SetDefault(_testExampleButton2Label, "NonBindableTest");
                }
                return _testExampleButton2Label;
            }
        }

        private static Template _testExampleButton3;
        public static Template TestExampleButton3
        {
            get
            {
#if UNITY_EDITOR
                if (_testExampleButton3 == null || _testExampleButton3.CurrentVersion != Template.Version)
#else
                if (_testExampleButton3 == null)
#endif
                {
                    _testExampleButton3 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _testExampleButton3.Name = "TestExampleButton3";
                    _testExampleButton3.LineNumber = 19;
                    _testExampleButton3.LinePosition = 6;
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_testExampleButton3, TestExampleButton3Label);
                }
                return _testExampleButton3;
            }
        }

        private static Template _testExampleButton3Label;
        public static Template TestExampleButton3Label
        {
            get
            {
#if UNITY_EDITOR
                if (_testExampleButton3Label == null || _testExampleButton3Label.CurrentVersion != Template.Version)
#else
                if (_testExampleButton3Label == null)
#endif
                {
                    _testExampleButton3Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _testExampleButton3Label.Name = "TestExampleButton3Label";
                    _testExampleButton3Label.LineNumber = 15;
                    _testExampleButton3Label.LinePosition = 4;
#endif
                    Delight.Label.TextProperty.SetDefault(_testExampleButton3Label, "NonBindableTest 2");
                }
                return _testExampleButton3Label;
            }
        }

        private static Template _testExampleLabel6;
        public static Template TestExampleLabel6
        {
            get
            {
#if UNITY_EDITOR
                if (_testExampleLabel6 == null || _testExampleLabel6.CurrentVersion != Template.Version)
#else
                if (_testExampleLabel6 == null)
#endif
                {
                    _testExampleLabel6 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _testExampleLabel6.Name = "TestExampleLabel6";
                    _testExampleLabel6.LineNumber = 20;
                    _testExampleLabel6.LinePosition = 6;
#endif
                    Delight.Label.TextProperty.SetHasBinding(_testExampleLabel6);
                }
                return _testExampleLabel6;
            }
        }

        private static Template _testExampleList2;
        public static Template TestExampleList2
        {
            get
            {
#if UNITY_EDITOR
                if (_testExampleList2 == null || _testExampleList2.CurrentVersion != Template.Version)
#else
                if (_testExampleList2 == null)
#endif
                {
                    _testExampleList2 = new Template(ListTemplates.List);
#if UNITY_EDITOR
                    _testExampleList2.Name = "TestExampleList2";
                    _testExampleList2.LineNumber = 22;
                    _testExampleList2.LinePosition = 6;
#endif
                    Delight.List.ItemsProperty.SetHasBinding(_testExampleList2);
                    Delight.List.ScrollableRegionTemplateProperty.SetDefault(_testExampleList2, TestExampleList2ScrollableRegion);
                }
                return _testExampleList2;
            }
        }

        private static Template _testExampleList2ScrollableRegion;
        public static Template TestExampleList2ScrollableRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_testExampleList2ScrollableRegion == null || _testExampleList2ScrollableRegion.CurrentVersion != Template.Version)
#else
                if (_testExampleList2ScrollableRegion == null)
#endif
                {
                    _testExampleList2ScrollableRegion = new Template(ListTemplates.ListScrollableRegion);
#if UNITY_EDITOR
                    _testExampleList2ScrollableRegion.Name = "TestExampleList2ScrollableRegion";
                    _testExampleList2ScrollableRegion.LineNumber = 29;
                    _testExampleList2ScrollableRegion.LinePosition = 4;
#endif
                    Delight.ScrollableRegion.ContentRegionTemplateProperty.SetDefault(_testExampleList2ScrollableRegion, TestExampleList2ScrollableRegionContentRegion);
                    Delight.ScrollableRegion.HorizontalScrollbarTemplateProperty.SetDefault(_testExampleList2ScrollableRegion, TestExampleList2ScrollableRegionHorizontalScrollbar);
                    Delight.ScrollableRegion.VerticalScrollbarTemplateProperty.SetDefault(_testExampleList2ScrollableRegion, TestExampleList2ScrollableRegionVerticalScrollbar);
                }
                return _testExampleList2ScrollableRegion;
            }
        }

        private static Template _testExampleList2ScrollableRegionContentRegion;
        public static Template TestExampleList2ScrollableRegionContentRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_testExampleList2ScrollableRegionContentRegion == null || _testExampleList2ScrollableRegionContentRegion.CurrentVersion != Template.Version)
#else
                if (_testExampleList2ScrollableRegionContentRegion == null)
#endif
                {
                    _testExampleList2ScrollableRegionContentRegion = new Template(ListTemplates.ListScrollableRegionContentRegion);
#if UNITY_EDITOR
                    _testExampleList2ScrollableRegionContentRegion.Name = "TestExampleList2ScrollableRegionContentRegion";
                    _testExampleList2ScrollableRegionContentRegion.LineNumber = 24;
                    _testExampleList2ScrollableRegionContentRegion.LinePosition = 4;
#endif
                }
                return _testExampleList2ScrollableRegionContentRegion;
            }
        }

        private static Template _testExampleList2ScrollableRegionHorizontalScrollbar;
        public static Template TestExampleList2ScrollableRegionHorizontalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_testExampleList2ScrollableRegionHorizontalScrollbar == null || _testExampleList2ScrollableRegionHorizontalScrollbar.CurrentVersion != Template.Version)
#else
                if (_testExampleList2ScrollableRegionHorizontalScrollbar == null)
#endif
                {
                    _testExampleList2ScrollableRegionHorizontalScrollbar = new Template(ListTemplates.ListScrollableRegionHorizontalScrollbar);
#if UNITY_EDITOR
                    _testExampleList2ScrollableRegionHorizontalScrollbar.Name = "TestExampleList2ScrollableRegionHorizontalScrollbar";
                    _testExampleList2ScrollableRegionHorizontalScrollbar.LineNumber = 26;
                    _testExampleList2ScrollableRegionHorizontalScrollbar.LinePosition = 4;
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_testExampleList2ScrollableRegionHorizontalScrollbar, TestExampleList2ScrollableRegionHorizontalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_testExampleList2ScrollableRegionHorizontalScrollbar, TestExampleList2ScrollableRegionHorizontalScrollbarHandle);
                }
                return _testExampleList2ScrollableRegionHorizontalScrollbar;
            }
        }

        private static Template _testExampleList2ScrollableRegionHorizontalScrollbarBar;
        public static Template TestExampleList2ScrollableRegionHorizontalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_testExampleList2ScrollableRegionHorizontalScrollbarBar == null || _testExampleList2ScrollableRegionHorizontalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_testExampleList2ScrollableRegionHorizontalScrollbarBar == null)
#endif
                {
                    _testExampleList2ScrollableRegionHorizontalScrollbarBar = new Template(ListTemplates.ListScrollableRegionHorizontalScrollbarBar);
#if UNITY_EDITOR
                    _testExampleList2ScrollableRegionHorizontalScrollbarBar.Name = "TestExampleList2ScrollableRegionHorizontalScrollbarBar";
                    _testExampleList2ScrollableRegionHorizontalScrollbarBar.LineNumber = 7;
                    _testExampleList2ScrollableRegionHorizontalScrollbarBar.LinePosition = 4;
#endif
                }
                return _testExampleList2ScrollableRegionHorizontalScrollbarBar;
            }
        }

        private static Template _testExampleList2ScrollableRegionHorizontalScrollbarHandle;
        public static Template TestExampleList2ScrollableRegionHorizontalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_testExampleList2ScrollableRegionHorizontalScrollbarHandle == null || _testExampleList2ScrollableRegionHorizontalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_testExampleList2ScrollableRegionHorizontalScrollbarHandle == null)
#endif
                {
                    _testExampleList2ScrollableRegionHorizontalScrollbarHandle = new Template(ListTemplates.ListScrollableRegionHorizontalScrollbarHandle);
#if UNITY_EDITOR
                    _testExampleList2ScrollableRegionHorizontalScrollbarHandle.Name = "TestExampleList2ScrollableRegionHorizontalScrollbarHandle";
                    _testExampleList2ScrollableRegionHorizontalScrollbarHandle.LineNumber = 8;
                    _testExampleList2ScrollableRegionHorizontalScrollbarHandle.LinePosition = 6;
#endif
                }
                return _testExampleList2ScrollableRegionHorizontalScrollbarHandle;
            }
        }

        private static Template _testExampleList2ScrollableRegionVerticalScrollbar;
        public static Template TestExampleList2ScrollableRegionVerticalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_testExampleList2ScrollableRegionVerticalScrollbar == null || _testExampleList2ScrollableRegionVerticalScrollbar.CurrentVersion != Template.Version)
#else
                if (_testExampleList2ScrollableRegionVerticalScrollbar == null)
#endif
                {
                    _testExampleList2ScrollableRegionVerticalScrollbar = new Template(ListTemplates.ListScrollableRegionVerticalScrollbar);
#if UNITY_EDITOR
                    _testExampleList2ScrollableRegionVerticalScrollbar.Name = "TestExampleList2ScrollableRegionVerticalScrollbar";
                    _testExampleList2ScrollableRegionVerticalScrollbar.LineNumber = 27;
                    _testExampleList2ScrollableRegionVerticalScrollbar.LinePosition = 4;
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_testExampleList2ScrollableRegionVerticalScrollbar, TestExampleList2ScrollableRegionVerticalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_testExampleList2ScrollableRegionVerticalScrollbar, TestExampleList2ScrollableRegionVerticalScrollbarHandle);
                }
                return _testExampleList2ScrollableRegionVerticalScrollbar;
            }
        }

        private static Template _testExampleList2ScrollableRegionVerticalScrollbarBar;
        public static Template TestExampleList2ScrollableRegionVerticalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_testExampleList2ScrollableRegionVerticalScrollbarBar == null || _testExampleList2ScrollableRegionVerticalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_testExampleList2ScrollableRegionVerticalScrollbarBar == null)
#endif
                {
                    _testExampleList2ScrollableRegionVerticalScrollbarBar = new Template(ListTemplates.ListScrollableRegionVerticalScrollbarBar);
#if UNITY_EDITOR
                    _testExampleList2ScrollableRegionVerticalScrollbarBar.Name = "TestExampleList2ScrollableRegionVerticalScrollbarBar";
                    _testExampleList2ScrollableRegionVerticalScrollbarBar.LineNumber = 7;
                    _testExampleList2ScrollableRegionVerticalScrollbarBar.LinePosition = 4;
#endif
                }
                return _testExampleList2ScrollableRegionVerticalScrollbarBar;
            }
        }

        private static Template _testExampleList2ScrollableRegionVerticalScrollbarHandle;
        public static Template TestExampleList2ScrollableRegionVerticalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_testExampleList2ScrollableRegionVerticalScrollbarHandle == null || _testExampleList2ScrollableRegionVerticalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_testExampleList2ScrollableRegionVerticalScrollbarHandle == null)
#endif
                {
                    _testExampleList2ScrollableRegionVerticalScrollbarHandle = new Template(ListTemplates.ListScrollableRegionVerticalScrollbarHandle);
#if UNITY_EDITOR
                    _testExampleList2ScrollableRegionVerticalScrollbarHandle.Name = "TestExampleList2ScrollableRegionVerticalScrollbarHandle";
                    _testExampleList2ScrollableRegionVerticalScrollbarHandle.LineNumber = 8;
                    _testExampleList2ScrollableRegionVerticalScrollbarHandle.LinePosition = 6;
#endif
                }
                return _testExampleList2ScrollableRegionVerticalScrollbarHandle;
            }
        }

        private static Template _testExampleListItem2;
        public static Template TestExampleListItem2
        {
            get
            {
#if UNITY_EDITOR
                if (_testExampleListItem2 == null || _testExampleListItem2.CurrentVersion != Template.Version)
#else
                if (_testExampleListItem2 == null)
#endif
                {
                    _testExampleListItem2 = new Template(ListItemTemplates.ListItem);
#if UNITY_EDITOR
                    _testExampleListItem2.Name = "TestExampleListItem2";
                    _testExampleListItem2.LineNumber = 23;
                    _testExampleListItem2.LinePosition = 8;
#endif
                }
                return _testExampleListItem2;
            }
        }

        private static Template _testExampleGroup3;
        public static Template TestExampleGroup3
        {
            get
            {
#if UNITY_EDITOR
                if (_testExampleGroup3 == null || _testExampleGroup3.CurrentVersion != Template.Version)
#else
                if (_testExampleGroup3 == null)
#endif
                {
                    _testExampleGroup3 = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _testExampleGroup3.Name = "TestExampleGroup3";
                    _testExampleGroup3.LineNumber = 24;
                    _testExampleGroup3.LinePosition = 10;
#endif
                    Delight.Group.OrientationProperty.SetDefault(_testExampleGroup3, Delight.ElementOrientation.Horizontal);
                }
                return _testExampleGroup3;
            }
        }

        private static Template _testExampleLabel7;
        public static Template TestExampleLabel7
        {
            get
            {
#if UNITY_EDITOR
                if (_testExampleLabel7 == null || _testExampleLabel7.CurrentVersion != Template.Version)
#else
                if (_testExampleLabel7 == null)
#endif
                {
                    _testExampleLabel7 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _testExampleLabel7.Name = "TestExampleLabel7";
                    _testExampleLabel7.LineNumber = 25;
                    _testExampleLabel7.LinePosition = 12;
#endif
                    Delight.Label.AutoSizeProperty.SetDefault(_testExampleLabel7, Delight.AutoSize.Default);
                    Delight.Label.TextProperty.SetHasBinding(_testExampleLabel7);
                }
                return _testExampleLabel7;
            }
        }

        private static Template _testExampleButton4;
        public static Template TestExampleButton4
        {
            get
            {
#if UNITY_EDITOR
                if (_testExampleButton4 == null || _testExampleButton4.CurrentVersion != Template.Version)
#else
                if (_testExampleButton4 == null)
#endif
                {
                    _testExampleButton4 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _testExampleButton4.Name = "TestExampleButton4";
                    _testExampleButton4.LineNumber = 26;
                    _testExampleButton4.LinePosition = 12;
#endif
                    Delight.Button.WidthProperty.SetDefault(_testExampleButton4, new ElementSize(100f, ElementSizeUnit.Pixels));
                    Delight.Button.LabelTemplateProperty.SetDefault(_testExampleButton4, TestExampleButton4Label);
                }
                return _testExampleButton4;
            }
        }

        private static Template _testExampleButton4Label;
        public static Template TestExampleButton4Label
        {
            get
            {
#if UNITY_EDITOR
                if (_testExampleButton4Label == null || _testExampleButton4Label.CurrentVersion != Template.Version)
#else
                if (_testExampleButton4Label == null)
#endif
                {
                    _testExampleButton4Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _testExampleButton4Label.Name = "TestExampleButton4Label";
                    _testExampleButton4Label.LineNumber = 15;
                    _testExampleButton4Label.LinePosition = 4;
#endif
                    Delight.Label.TextProperty.SetDefault(_testExampleButton4Label, "Add");
                }
                return _testExampleButton4Label;
            }
        }

        private static Template _testExampleButton5;
        public static Template TestExampleButton5
        {
            get
            {
#if UNITY_EDITOR
                if (_testExampleButton5 == null || _testExampleButton5.CurrentVersion != Template.Version)
#else
                if (_testExampleButton5 == null)
#endif
                {
                    _testExampleButton5 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _testExampleButton5.Name = "TestExampleButton5";
                    _testExampleButton5.LineNumber = 27;
                    _testExampleButton5.LinePosition = 12;
#endif
                    Delight.Button.WidthProperty.SetDefault(_testExampleButton5, new ElementSize(100f, ElementSizeUnit.Pixels));
                    Delight.Button.LabelTemplateProperty.SetDefault(_testExampleButton5, TestExampleButton5Label);
                }
                return _testExampleButton5;
            }
        }

        private static Template _testExampleButton5Label;
        public static Template TestExampleButton5Label
        {
            get
            {
#if UNITY_EDITOR
                if (_testExampleButton5Label == null || _testExampleButton5Label.CurrentVersion != Template.Version)
#else
                if (_testExampleButton5Label == null)
#endif
                {
                    _testExampleButton5Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _testExampleButton5Label.Name = "TestExampleButton5Label";
                    _testExampleButton5Label.LineNumber = 15;
                    _testExampleButton5Label.LinePosition = 4;
#endif
                    Delight.Label.TextProperty.SetDefault(_testExampleButton5Label, "Remove");
                }
                return _testExampleButton5Label;
            }
        }

        #endregion
    }

    #endregion
}
