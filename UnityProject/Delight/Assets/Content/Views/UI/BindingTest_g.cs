// Internal view logic generated from "BindingTest.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class BindingTest : UIView
    {
        #region Constructors

        public BindingTest(View parent, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :
            base(parent, layoutParent, id, template ?? BindingTestTemplates.Default, initializer)
        {
            // constructing Region (Region1)
            Region1 = new Region(this, this, "Region1", Region1Template);
            Group1 = new Group(this, Region1.Content, "Group1", Group1Template);
            Button1 = new Button(this, Group1.Content, "Button1", Button1Template);
            Button1.Click.RegisterHandler(this, "Test1");
            Button2 = new Button(this, Group1.Content, "Button2", Button2Template);
            Button2.Click.RegisterHandler(this, "Test2");
            Button3 = new Button(this, Group1.Content, "Button3", Button3Template);

            // binding <Button BackgroundColor="{TestBinding2}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "TestBinding2" }, new List<Func<BindableObject>> { () => this }) }, new BindingPath(new List<string> { "Button3", "BackgroundColor" }, new List<Func<BindableObject>> { () => this, () => Button3 }), () => Button3.BackgroundColor = TestBinding2, () => { }, false));
            Button4 = new Button(this, Group1.Content, "Button4", Button4Template);
            Label1 = new Label(this, Group1.Content, "Label1", Label1Template);

            // binding <Label Text="{TestBinding}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "TestBinding" }, new List<Func<BindableObject>> { () => this }) }, new BindingPath(new List<string> { "Label1", "Text" }, new List<Func<BindableObject>> { () => this, () => Label1 }), () => Label1.Text = TestBinding, () => { }, false));
            Button5 = new Button(this, Group1.Content, "Button5", Button5Template);

            // binding <Button Text="{TestBinding}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "TestBinding" }, new List<Func<BindableObject>> { () => this }) }, new BindingPath(new List<string> { "Button5", "Text" }, new List<Func<BindableObject>> { () => this, () => Button5 }), () => Button5.Text = TestBinding, () => { }, false));
            Button6 = new Button(this, Group1.Content, "Button6", Button6Template);

            // binding <Button Text="{Player1.Name}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "Player1", "Name" }, new List<Func<BindableObject>> { () => this, () => Player1 }) }, new BindingPath(new List<string> { "Button6", "Text" }, new List<Func<BindableObject>> { () => this, () => Button6 }), () => Button6.Text = Player1.Name, () => { }, false));

            // constructing Region (RegionOnDemand)
            RegionOnDemand = new Region(this, this, "RegionOnDemand", RegionOnDemandTemplate);
            Group2 = new Group(this, RegionOnDemand.Content, "Group2", Group2Template);
            Label2 = new Label(this, Group2.Content, "Label2", Label2Template);

            // binding <Label Text="{TestBinding}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "TestBinding" }, new List<Func<BindableObject>> { () => this }) }, new BindingPath(new List<string> { "Label2", "Text" }, new List<Func<BindableObject>> { () => this, () => Label2 }), () => Label2.Text = TestBinding, () => { }, false));
            Label3 = new Label(this, Group2.Content, "Label3", Label3Template);

            // binding <Label Text="{Player1.Name}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "Player1", "Name" }, new List<Func<BindableObject>> { () => this, () => Player1 }) }, new BindingPath(new List<string> { "Label3", "Text" }, new List<Func<BindableObject>> { () => this, () => Label3 }), () => Label3.Text = Player1.Name, () => { }, false));
            this.AfterInitializeInternal();
        }

        public BindingTest() : this(null)
        {
        }

        static BindingTest()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(BindingTestTemplates.Default, dependencyProperties);

            dependencyProperties.Add(Player1Property);
            dependencyProperties.Add(TestBindingProperty);
            dependencyProperties.Add(TestBinding2Property);
            dependencyProperties.Add(TestBinding3Property);
            dependencyProperties.Add(Region1Property);
            dependencyProperties.Add(Region1TemplateProperty);
            dependencyProperties.Add(Group1Property);
            dependencyProperties.Add(Group1TemplateProperty);
            dependencyProperties.Add(Button1Property);
            dependencyProperties.Add(Button1TemplateProperty);
            dependencyProperties.Add(Button2Property);
            dependencyProperties.Add(Button2TemplateProperty);
            dependencyProperties.Add(Button3Property);
            dependencyProperties.Add(Button3TemplateProperty);
            dependencyProperties.Add(Button4Property);
            dependencyProperties.Add(Button4TemplateProperty);
            dependencyProperties.Add(Label1Property);
            dependencyProperties.Add(Label1TemplateProperty);
            dependencyProperties.Add(Button5Property);
            dependencyProperties.Add(Button5TemplateProperty);
            dependencyProperties.Add(Button6Property);
            dependencyProperties.Add(Button6TemplateProperty);
            dependencyProperties.Add(RegionOnDemandProperty);
            dependencyProperties.Add(RegionOnDemandTemplateProperty);
            dependencyProperties.Add(Group2Property);
            dependencyProperties.Add(Group2TemplateProperty);
            dependencyProperties.Add(Label2Property);
            dependencyProperties.Add(Label2TemplateProperty);
            dependencyProperties.Add(Label3Property);
            dependencyProperties.Add(Label3TemplateProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<Delight.Player> Player1Property = new DependencyProperty<Delight.Player>("Player1");
        public Delight.Player Player1
        {
            get { return Player1Property.GetValue(this); }
            set { Player1Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.String> TestBindingProperty = new DependencyProperty<System.String>("TestBinding");
        public System.String TestBinding
        {
            get { return TestBindingProperty.GetValue(this); }
            set { TestBindingProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<UnityEngine.Color> TestBinding2Property = new DependencyProperty<UnityEngine.Color>("TestBinding2");
        public UnityEngine.Color TestBinding2
        {
            get { return TestBinding2Property.GetValue(this); }
            set { TestBinding2Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Delight.TestType2> TestBinding3Property = new DependencyProperty<Delight.TestType2>("TestBinding3");
        public Delight.TestType2 TestBinding3
        {
            get { return TestBinding3Property.GetValue(this); }
            set { TestBinding3Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> Region1Property = new DependencyProperty<Region>("Region1");
        public Region Region1
        {
            get { return Region1Property.GetValue(this); }
            set { Region1Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Region1TemplateProperty = new DependencyProperty<Template>("Region1Template");
        public Template Region1Template
        {
            get { return Region1TemplateProperty.GetValue(this); }
            set { Region1TemplateProperty.SetValue(this, value); }
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

        public readonly static DependencyProperty<Button> Button6Property = new DependencyProperty<Button>("Button6");
        public Button Button6
        {
            get { return Button6Property.GetValue(this); }
            set { Button6Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Button6TemplateProperty = new DependencyProperty<Template>("Button6Template");
        public Template Button6Template
        {
            get { return Button6TemplateProperty.GetValue(this); }
            set { Button6TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> RegionOnDemandProperty = new DependencyProperty<Region>("RegionOnDemand");
        public Region RegionOnDemand
        {
            get { return RegionOnDemandProperty.GetValue(this); }
            set { RegionOnDemandProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> RegionOnDemandTemplateProperty = new DependencyProperty<Template>("RegionOnDemandTemplate");
        public Template RegionOnDemandTemplate
        {
            get { return RegionOnDemandTemplateProperty.GetValue(this); }
            set { RegionOnDemandTemplateProperty.SetValue(this, value); }
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

        #endregion
    }

    #region Data Templates

    public static class BindingTestTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return BindingTest;
            }
        }

        private static Template _bindingTest;
        public static Template BindingTest
        {
            get
            {
#if UNITY_EDITOR
                if (_bindingTest == null || _bindingTest.CurrentVersion != Template.Version)
#else
                if (_bindingTest == null)
#endif
                {
                    _bindingTest = new Template(UIViewTemplates.UIView);
#if UNITY_EDITOR
                    _bindingTest.Name = "BindingTest";
#endif
                    Delight.BindingTest.Region1TemplateProperty.SetDefault(_bindingTest, BindingTestRegion1);
                    Delight.BindingTest.Group1TemplateProperty.SetDefault(_bindingTest, BindingTestGroup1);
                    Delight.BindingTest.Button1TemplateProperty.SetDefault(_bindingTest, BindingTestButton1);
                    Delight.BindingTest.Button2TemplateProperty.SetDefault(_bindingTest, BindingTestButton2);
                    Delight.BindingTest.Button3TemplateProperty.SetDefault(_bindingTest, BindingTestButton3);
                    Delight.BindingTest.Button4TemplateProperty.SetDefault(_bindingTest, BindingTestButton4);
                    Delight.BindingTest.Label1TemplateProperty.SetDefault(_bindingTest, BindingTestLabel1);
                    Delight.BindingTest.Button5TemplateProperty.SetDefault(_bindingTest, BindingTestButton5);
                    Delight.BindingTest.Button6TemplateProperty.SetDefault(_bindingTest, BindingTestButton6);
                    Delight.BindingTest.RegionOnDemandTemplateProperty.SetDefault(_bindingTest, BindingTestRegionOnDemand);
                    Delight.BindingTest.Group2TemplateProperty.SetDefault(_bindingTest, BindingTestGroup2);
                    Delight.BindingTest.Label2TemplateProperty.SetDefault(_bindingTest, BindingTestLabel2);
                    Delight.BindingTest.Label3TemplateProperty.SetDefault(_bindingTest, BindingTestLabel3);
                }
                return _bindingTest;
            }
        }

        private static Template _bindingTestRegion1;
        public static Template BindingTestRegion1
        {
            get
            {
#if UNITY_EDITOR
                if (_bindingTestRegion1 == null || _bindingTestRegion1.CurrentVersion != Template.Version)
#else
                if (_bindingTestRegion1 == null)
#endif
                {
                    _bindingTestRegion1 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _bindingTestRegion1.Name = "BindingTestRegion1";
#endif
                    Delight.Region.WidthProperty.SetDefault(_bindingTestRegion1, new ElementSize(0.25f, ElementSizeUnit.Percents));
                    Delight.Region.AlignmentProperty.SetDefault(_bindingTestRegion1, Delight.ElementAlignment.Left);
                    Delight.Region.MarginProperty.SetDefault(_bindingTestRegion1, new ElementMargin(new ElementSize(30f, ElementSizeUnit.Pixels), new ElementSize(30f, ElementSizeUnit.Pixels), new ElementSize(15f, ElementSizeUnit.Pixels), new ElementSize(30f, ElementSizeUnit.Pixels)));
                    Delight.Region.BackgroundColorProperty.SetDefault(_bindingTestRegion1, new UnityEngine.Color(0.9372549f, 0.4392157f, 0.4156863f, 1f));
                }
                return _bindingTestRegion1;
            }
        }

        private static Template _bindingTestGroup1;
        public static Template BindingTestGroup1
        {
            get
            {
#if UNITY_EDITOR
                if (_bindingTestGroup1 == null || _bindingTestGroup1.CurrentVersion != Template.Version)
#else
                if (_bindingTestGroup1 == null)
#endif
                {
                    _bindingTestGroup1 = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _bindingTestGroup1.Name = "BindingTestGroup1";
#endif
                    Delight.Group.SpacingProperty.SetDefault(_bindingTestGroup1, new ElementSize(10f, ElementSizeUnit.Pixels));
                    Delight.Group.AlignmentProperty.SetDefault(_bindingTestGroup1, Delight.ElementAlignment.Top);
                    Delight.Group.MarginProperty.SetDefault(_bindingTestGroup1, new ElementMargin(new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(30f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels)));
                }
                return _bindingTestGroup1;
            }
        }

        private static Template _bindingTestButton1;
        public static Template BindingTestButton1
        {
            get
            {
#if UNITY_EDITOR
                if (_bindingTestButton1 == null || _bindingTestButton1.CurrentVersion != Template.Version)
#else
                if (_bindingTestButton1 == null)
#endif
                {
                    _bindingTestButton1 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _bindingTestButton1.Name = "BindingTestButton1";
#endif
                    Delight.Button.BackgroundColorProperty.SetDefault(_bindingTestButton1, new UnityEngine.Color(0f, 0f, 1f, 1f));
                    Delight.Button.LabelTemplateProperty.SetDefault(_bindingTestButton1, BindingTestButton1Label);
                }
                return _bindingTestButton1;
            }
        }

        private static Template _bindingTestButton1Label;
        public static Template BindingTestButton1Label
        {
            get
            {
#if UNITY_EDITOR
                if (_bindingTestButton1Label == null || _bindingTestButton1Label.CurrentVersion != Template.Version)
#else
                if (_bindingTestButton1Label == null)
#endif
                {
                    _bindingTestButton1Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _bindingTestButton1Label.Name = "BindingTestButton1Label";
#endif
                    Delight.Label.TextProperty.SetDefault(_bindingTestButton1Label, "Test 1");
                    Delight.Label.FontSizeProperty.SetDefault(_bindingTestButton1Label, 24);
                    Delight.Label.TextAlignmentProperty.SetDefault(_bindingTestButton1Label, Delight.ElementAlignment.Center);
                }
                return _bindingTestButton1Label;
            }
        }

        private static Template _bindingTestButton2;
        public static Template BindingTestButton2
        {
            get
            {
#if UNITY_EDITOR
                if (_bindingTestButton2 == null || _bindingTestButton2.CurrentVersion != Template.Version)
#else
                if (_bindingTestButton2 == null)
#endif
                {
                    _bindingTestButton2 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _bindingTestButton2.Name = "BindingTestButton2";
#endif
                    Delight.Button.BackgroundColorProperty.SetDefault(_bindingTestButton2, new UnityEngine.Color(1f, 0f, 0f, 1f));
                    Delight.Button.LabelTemplateProperty.SetDefault(_bindingTestButton2, BindingTestButton2Label);
                }
                return _bindingTestButton2;
            }
        }

        private static Template _bindingTestButton2Label;
        public static Template BindingTestButton2Label
        {
            get
            {
#if UNITY_EDITOR
                if (_bindingTestButton2Label == null || _bindingTestButton2Label.CurrentVersion != Template.Version)
#else
                if (_bindingTestButton2Label == null)
#endif
                {
                    _bindingTestButton2Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _bindingTestButton2Label.Name = "BindingTestButton2Label";
#endif
                    Delight.Label.TextProperty.SetDefault(_bindingTestButton2Label, "Test 2");
                    Delight.Label.TextAlignmentProperty.SetDefault(_bindingTestButton2Label, Delight.ElementAlignment.Center);
                }
                return _bindingTestButton2Label;
            }
        }

        private static Template _bindingTestButton3;
        public static Template BindingTestButton3
        {
            get
            {
#if UNITY_EDITOR
                if (_bindingTestButton3 == null || _bindingTestButton3.CurrentVersion != Template.Version)
#else
                if (_bindingTestButton3 == null)
#endif
                {
                    _bindingTestButton3 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _bindingTestButton3.Name = "BindingTestButton3";
#endif
                    Delight.Button.BackgroundColorProperty.SetHasBinding(_bindingTestButton3);
                    Delight.Button.LabelTemplateProperty.SetDefault(_bindingTestButton3, BindingTestButton3Label);
                }
                return _bindingTestButton3;
            }
        }

        private static Template _bindingTestButton3Label;
        public static Template BindingTestButton3Label
        {
            get
            {
#if UNITY_EDITOR
                if (_bindingTestButton3Label == null || _bindingTestButton3Label.CurrentVersion != Template.Version)
#else
                if (_bindingTestButton3Label == null)
#endif
                {
                    _bindingTestButton3Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _bindingTestButton3Label.Name = "BindingTestButton3Label";
#endif
                    Delight.Label.TextProperty.SetDefault(_bindingTestButton3Label, "Bg");
                    Delight.Label.TextAlignmentProperty.SetDefault(_bindingTestButton3Label, Delight.ElementAlignment.Center);
                }
                return _bindingTestButton3Label;
            }
        }

        private static Template _bindingTestButton4;
        public static Template BindingTestButton4
        {
            get
            {
#if UNITY_EDITOR
                if (_bindingTestButton4 == null || _bindingTestButton4.CurrentVersion != Template.Version)
#else
                if (_bindingTestButton4 == null)
#endif
                {
                    _bindingTestButton4 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _bindingTestButton4.Name = "BindingTestButton4";
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_bindingTestButton4, BindingTestButton4Label);
                }
                return _bindingTestButton4;
            }
        }

        private static Template _bindingTestButton4Label;
        public static Template BindingTestButton4Label
        {
            get
            {
#if UNITY_EDITOR
                if (_bindingTestButton4Label == null || _bindingTestButton4Label.CurrentVersion != Template.Version)
#else
                if (_bindingTestButton4Label == null)
#endif
                {
                    _bindingTestButton4Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _bindingTestButton4Label.Name = "BindingTestButton4Label";
#endif
                    Delight.Label.TextProperty.SetDefault(_bindingTestButton4Label, "Large Button");
                    Delight.Label.TextAlignmentProperty.SetDefault(_bindingTestButton4Label, Delight.ElementAlignment.Center);
                }
                return _bindingTestButton4Label;
            }
        }

        private static Template _bindingTestLabel1;
        public static Template BindingTestLabel1
        {
            get
            {
#if UNITY_EDITOR
                if (_bindingTestLabel1 == null || _bindingTestLabel1.CurrentVersion != Template.Version)
#else
                if (_bindingTestLabel1 == null)
#endif
                {
                    _bindingTestLabel1 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _bindingTestLabel1.Name = "BindingTestLabel1";
#endif
                    Delight.Label.WidthProperty.SetDefault(_bindingTestLabel1, new ElementSize(130f, ElementSizeUnit.Pixels));
                    Delight.Label.HeightProperty.SetDefault(_bindingTestLabel1, new ElementSize(50f, ElementSizeUnit.Pixels));
                    Delight.Label.TextProperty.SetHasBinding(_bindingTestLabel1);
                }
                return _bindingTestLabel1;
            }
        }

        private static Template _bindingTestButton5;
        public static Template BindingTestButton5
        {
            get
            {
#if UNITY_EDITOR
                if (_bindingTestButton5 == null || _bindingTestButton5.CurrentVersion != Template.Version)
#else
                if (_bindingTestButton5 == null)
#endif
                {
                    _bindingTestButton5 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _bindingTestButton5.Name = "BindingTestButton5";
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_bindingTestButton5, BindingTestButton5Label);
                }
                return _bindingTestButton5;
            }
        }

        private static Template _bindingTestButton5Label;
        public static Template BindingTestButton5Label
        {
            get
            {
#if UNITY_EDITOR
                if (_bindingTestButton5Label == null || _bindingTestButton5Label.CurrentVersion != Template.Version)
#else
                if (_bindingTestButton5Label == null)
#endif
                {
                    _bindingTestButton5Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _bindingTestButton5Label.Name = "BindingTestButton5Label";
#endif
                    Delight.Label.TextProperty.SetHasBinding(_bindingTestButton5Label);
                }
                return _bindingTestButton5Label;
            }
        }

        private static Template _bindingTestButton6;
        public static Template BindingTestButton6
        {
            get
            {
#if UNITY_EDITOR
                if (_bindingTestButton6 == null || _bindingTestButton6.CurrentVersion != Template.Version)
#else
                if (_bindingTestButton6 == null)
#endif
                {
                    _bindingTestButton6 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _bindingTestButton6.Name = "BindingTestButton6";
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_bindingTestButton6, BindingTestButton6Label);
                }
                return _bindingTestButton6;
            }
        }

        private static Template _bindingTestButton6Label;
        public static Template BindingTestButton6Label
        {
            get
            {
#if UNITY_EDITOR
                if (_bindingTestButton6Label == null || _bindingTestButton6Label.CurrentVersion != Template.Version)
#else
                if (_bindingTestButton6Label == null)
#endif
                {
                    _bindingTestButton6Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _bindingTestButton6Label.Name = "BindingTestButton6Label";
#endif
                    Delight.Label.TextProperty.SetHasBinding(_bindingTestButton6Label);
                }
                return _bindingTestButton6Label;
            }
        }

        private static Template _bindingTestRegionOnDemand;
        public static Template BindingTestRegionOnDemand
        {
            get
            {
#if UNITY_EDITOR
                if (_bindingTestRegionOnDemand == null || _bindingTestRegionOnDemand.CurrentVersion != Template.Version)
#else
                if (_bindingTestRegionOnDemand == null)
#endif
                {
                    _bindingTestRegionOnDemand = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _bindingTestRegionOnDemand.Name = "BindingTestRegionOnDemand";
#endif
                    Delight.Region.WidthProperty.SetDefault(_bindingTestRegionOnDemand, new ElementSize(0.75f, ElementSizeUnit.Percents));
                    Delight.Region.AlignmentProperty.SetDefault(_bindingTestRegionOnDemand, Delight.ElementAlignment.Right);
                    Delight.Region.MarginProperty.SetDefault(_bindingTestRegionOnDemand, new ElementMargin(new ElementSize(15f, ElementSizeUnit.Pixels), new ElementSize(30f, ElementSizeUnit.Pixels), new ElementSize(30f, ElementSizeUnit.Pixels), new ElementSize(30f, ElementSizeUnit.Pixels)));
                    Delight.Region.BackgroundColorProperty.SetDefault(_bindingTestRegionOnDemand, new UnityEngine.Color(0.5803922f, 0.5803922f, 0.5803922f, 1f));
                }
                return _bindingTestRegionOnDemand;
            }
        }

        private static Template _bindingTestGroup2;
        public static Template BindingTestGroup2
        {
            get
            {
#if UNITY_EDITOR
                if (_bindingTestGroup2 == null || _bindingTestGroup2.CurrentVersion != Template.Version)
#else
                if (_bindingTestGroup2 == null)
#endif
                {
                    _bindingTestGroup2 = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _bindingTestGroup2.Name = "BindingTestGroup2";
#endif
                }
                return _bindingTestGroup2;
            }
        }

        private static Template _bindingTestLabel2;
        public static Template BindingTestLabel2
        {
            get
            {
#if UNITY_EDITOR
                if (_bindingTestLabel2 == null || _bindingTestLabel2.CurrentVersion != Template.Version)
#else
                if (_bindingTestLabel2 == null)
#endif
                {
                    _bindingTestLabel2 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _bindingTestLabel2.Name = "BindingTestLabel2";
#endif
                    Delight.Label.HeightProperty.SetDefault(_bindingTestLabel2, new ElementSize(40f, ElementSizeUnit.Pixels));
                    Delight.Label.TextProperty.SetHasBinding(_bindingTestLabel2);
                }
                return _bindingTestLabel2;
            }
        }

        private static Template _bindingTestLabel3;
        public static Template BindingTestLabel3
        {
            get
            {
#if UNITY_EDITOR
                if (_bindingTestLabel3 == null || _bindingTestLabel3.CurrentVersion != Template.Version)
#else
                if (_bindingTestLabel3 == null)
#endif
                {
                    _bindingTestLabel3 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _bindingTestLabel3.Name = "BindingTestLabel3";
#endif
                    Delight.Label.HeightProperty.SetDefault(_bindingTestLabel3, new ElementSize(40f, ElementSizeUnit.Pixels));
                    Delight.Label.TextProperty.SetHasBinding(_bindingTestLabel3);
                }
                return _bindingTestLabel3;
            }
        }

        #endregion
    }

    #endregion
}
