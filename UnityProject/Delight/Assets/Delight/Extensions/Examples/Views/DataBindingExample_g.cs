// Internal view logic generated from "DataBindingExample.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class DataBindingExample : UIView
    {
        #region Constructors

        public DataBindingExample(View parent, View layoutParent = null, string id = null, Template template = null, bool deferInitialization = false) :
            base(parent, layoutParent, id, template ?? DataBindingExampleTemplates.Default, deferInitialization)
        {
            if (deferInitialization)
                return;

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

        public DataBindingExample() : this(null)
        {
        }

        static DataBindingExample()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(DataBindingExampleTemplates.Default, dependencyProperties);

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

    public static class DataBindingExampleTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return DataBindingExample;
            }
        }

        private static Template _dataBindingExample;
        public static Template DataBindingExample
        {
            get
            {
#if UNITY_EDITOR
                if (_dataBindingExample == null || _dataBindingExample.CurrentVersion != Template.Version)
#else
                if (_dataBindingExample == null)
#endif
                {
                    _dataBindingExample = new Template(UIViewTemplates.UIView);
#if UNITY_EDITOR
                    _dataBindingExample.Name = "DataBindingExample";
#endif
                    Delight.DataBindingExample.Region1TemplateProperty.SetDefault(_dataBindingExample, DataBindingExampleRegion1);
                    Delight.DataBindingExample.Group1TemplateProperty.SetDefault(_dataBindingExample, DataBindingExampleGroup1);
                    Delight.DataBindingExample.Button1TemplateProperty.SetDefault(_dataBindingExample, DataBindingExampleButton1);
                    Delight.DataBindingExample.Button2TemplateProperty.SetDefault(_dataBindingExample, DataBindingExampleButton2);
                    Delight.DataBindingExample.Button3TemplateProperty.SetDefault(_dataBindingExample, DataBindingExampleButton3);
                    Delight.DataBindingExample.Button4TemplateProperty.SetDefault(_dataBindingExample, DataBindingExampleButton4);
                    Delight.DataBindingExample.Label1TemplateProperty.SetDefault(_dataBindingExample, DataBindingExampleLabel1);
                    Delight.DataBindingExample.Button5TemplateProperty.SetDefault(_dataBindingExample, DataBindingExampleButton5);
                    Delight.DataBindingExample.Button6TemplateProperty.SetDefault(_dataBindingExample, DataBindingExampleButton6);
                    Delight.DataBindingExample.RegionOnDemandTemplateProperty.SetDefault(_dataBindingExample, DataBindingExampleRegionOnDemand);
                    Delight.DataBindingExample.Group2TemplateProperty.SetDefault(_dataBindingExample, DataBindingExampleGroup2);
                    Delight.DataBindingExample.Label2TemplateProperty.SetDefault(_dataBindingExample, DataBindingExampleLabel2);
                    Delight.DataBindingExample.Label3TemplateProperty.SetDefault(_dataBindingExample, DataBindingExampleLabel3);
                }
                return _dataBindingExample;
            }
        }

        private static Template _dataBindingExampleRegion1;
        public static Template DataBindingExampleRegion1
        {
            get
            {
#if UNITY_EDITOR
                if (_dataBindingExampleRegion1 == null || _dataBindingExampleRegion1.CurrentVersion != Template.Version)
#else
                if (_dataBindingExampleRegion1 == null)
#endif
                {
                    _dataBindingExampleRegion1 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _dataBindingExampleRegion1.Name = "DataBindingExampleRegion1";
#endif
                    Delight.Region.WidthProperty.SetDefault(_dataBindingExampleRegion1, new ElementSize(0.25f, ElementSizeUnit.Percents));
                    Delight.Region.AlignmentProperty.SetDefault(_dataBindingExampleRegion1, Delight.ElementAlignment.Left);
                    Delight.Region.MarginProperty.SetDefault(_dataBindingExampleRegion1, new ElementMargin(new ElementSize(30f, ElementSizeUnit.Pixels), new ElementSize(30f, ElementSizeUnit.Pixels), new ElementSize(15f, ElementSizeUnit.Pixels), new ElementSize(30f, ElementSizeUnit.Pixels)));
                    Delight.Region.BackgroundColorProperty.SetDefault(_dataBindingExampleRegion1, new UnityEngine.Color(0.9372549f, 0.4392157f, 0.4156863f, 1f));
                }
                return _dataBindingExampleRegion1;
            }
        }

        private static Template _dataBindingExampleGroup1;
        public static Template DataBindingExampleGroup1
        {
            get
            {
#if UNITY_EDITOR
                if (_dataBindingExampleGroup1 == null || _dataBindingExampleGroup1.CurrentVersion != Template.Version)
#else
                if (_dataBindingExampleGroup1 == null)
#endif
                {
                    _dataBindingExampleGroup1 = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _dataBindingExampleGroup1.Name = "DataBindingExampleGroup1";
#endif
                    Delight.Group.SpacingProperty.SetDefault(_dataBindingExampleGroup1, new ElementSize(6f, ElementSizeUnit.Pixels));
                    Delight.Group.AlignmentProperty.SetDefault(_dataBindingExampleGroup1, Delight.ElementAlignment.Top);
                    Delight.Group.MarginProperty.SetDefault(_dataBindingExampleGroup1, new ElementMargin(new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(30f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels)));
                }
                return _dataBindingExampleGroup1;
            }
        }

        private static Template _dataBindingExampleButton1;
        public static Template DataBindingExampleButton1
        {
            get
            {
#if UNITY_EDITOR
                if (_dataBindingExampleButton1 == null || _dataBindingExampleButton1.CurrentVersion != Template.Version)
#else
                if (_dataBindingExampleButton1 == null)
#endif
                {
                    _dataBindingExampleButton1 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _dataBindingExampleButton1.Name = "DataBindingExampleButton1";
#endif
                    Delight.Button.BackgroundColorProperty.SetDefault(_dataBindingExampleButton1, new UnityEngine.Color(0f, 0f, 1f, 1f));
                    Delight.Button.LabelTemplateProperty.SetDefault(_dataBindingExampleButton1, DataBindingExampleButton1Label);
                }
                return _dataBindingExampleButton1;
            }
        }

        private static Template _dataBindingExampleButton1Label;
        public static Template DataBindingExampleButton1Label
        {
            get
            {
#if UNITY_EDITOR
                if (_dataBindingExampleButton1Label == null || _dataBindingExampleButton1Label.CurrentVersion != Template.Version)
#else
                if (_dataBindingExampleButton1Label == null)
#endif
                {
                    _dataBindingExampleButton1Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _dataBindingExampleButton1Label.Name = "DataBindingExampleButton1Label";
#endif
                    Delight.Label.TextProperty.SetDefault(_dataBindingExampleButton1Label, "Test 1");
                    Delight.Label.TextAlignmentProperty.SetDefault(_dataBindingExampleButton1Label, TMPro.TextAlignmentOptions.Center);
                }
                return _dataBindingExampleButton1Label;
            }
        }

        private static Template _dataBindingExampleButton2;
        public static Template DataBindingExampleButton2
        {
            get
            {
#if UNITY_EDITOR
                if (_dataBindingExampleButton2 == null || _dataBindingExampleButton2.CurrentVersion != Template.Version)
#else
                if (_dataBindingExampleButton2 == null)
#endif
                {
                    _dataBindingExampleButton2 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _dataBindingExampleButton2.Name = "DataBindingExampleButton2";
#endif
                    Delight.Button.BackgroundColorProperty.SetDefault(_dataBindingExampleButton2, new UnityEngine.Color(1f, 0f, 0f, 1f));
                    Delight.Button.LabelTemplateProperty.SetDefault(_dataBindingExampleButton2, DataBindingExampleButton2Label);
                }
                return _dataBindingExampleButton2;
            }
        }

        private static Template _dataBindingExampleButton2Label;
        public static Template DataBindingExampleButton2Label
        {
            get
            {
#if UNITY_EDITOR
                if (_dataBindingExampleButton2Label == null || _dataBindingExampleButton2Label.CurrentVersion != Template.Version)
#else
                if (_dataBindingExampleButton2Label == null)
#endif
                {
                    _dataBindingExampleButton2Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _dataBindingExampleButton2Label.Name = "DataBindingExampleButton2Label";
#endif
                    Delight.Label.TextProperty.SetDefault(_dataBindingExampleButton2Label, "Test 2");
                    Delight.Label.TextAlignmentProperty.SetDefault(_dataBindingExampleButton2Label, TMPro.TextAlignmentOptions.Center);
                }
                return _dataBindingExampleButton2Label;
            }
        }

        private static Template _dataBindingExampleButton3;
        public static Template DataBindingExampleButton3
        {
            get
            {
#if UNITY_EDITOR
                if (_dataBindingExampleButton3 == null || _dataBindingExampleButton3.CurrentVersion != Template.Version)
#else
                if (_dataBindingExampleButton3 == null)
#endif
                {
                    _dataBindingExampleButton3 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _dataBindingExampleButton3.Name = "DataBindingExampleButton3";
#endif
                    Delight.Button.BackgroundColorProperty.SetHasBinding(_dataBindingExampleButton3);
                    Delight.Button.LabelTemplateProperty.SetDefault(_dataBindingExampleButton3, DataBindingExampleButton3Label);
                }
                return _dataBindingExampleButton3;
            }
        }

        private static Template _dataBindingExampleButton3Label;
        public static Template DataBindingExampleButton3Label
        {
            get
            {
#if UNITY_EDITOR
                if (_dataBindingExampleButton3Label == null || _dataBindingExampleButton3Label.CurrentVersion != Template.Version)
#else
                if (_dataBindingExampleButton3Label == null)
#endif
                {
                    _dataBindingExampleButton3Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _dataBindingExampleButton3Label.Name = "DataBindingExampleButton3Label";
#endif
                    Delight.Label.TextProperty.SetDefault(_dataBindingExampleButton3Label, "Bg");
                    Delight.Label.TextAlignmentProperty.SetDefault(_dataBindingExampleButton3Label, TMPro.TextAlignmentOptions.Center);
                }
                return _dataBindingExampleButton3Label;
            }
        }

        private static Template _dataBindingExampleButton4;
        public static Template DataBindingExampleButton4
        {
            get
            {
#if UNITY_EDITOR
                if (_dataBindingExampleButton4 == null || _dataBindingExampleButton4.CurrentVersion != Template.Version)
#else
                if (_dataBindingExampleButton4 == null)
#endif
                {
                    _dataBindingExampleButton4 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _dataBindingExampleButton4.Name = "DataBindingExampleButton4";
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_dataBindingExampleButton4, DataBindingExampleButton4Label);
                }
                return _dataBindingExampleButton4;
            }
        }

        private static Template _dataBindingExampleButton4Label;
        public static Template DataBindingExampleButton4Label
        {
            get
            {
#if UNITY_EDITOR
                if (_dataBindingExampleButton4Label == null || _dataBindingExampleButton4Label.CurrentVersion != Template.Version)
#else
                if (_dataBindingExampleButton4Label == null)
#endif
                {
                    _dataBindingExampleButton4Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _dataBindingExampleButton4Label.Name = "DataBindingExampleButton4Label";
#endif
                    Delight.Label.TextProperty.SetDefault(_dataBindingExampleButton4Label, "Large Button");
                    Delight.Label.TextAlignmentProperty.SetDefault(_dataBindingExampleButton4Label, TMPro.TextAlignmentOptions.Center);
                }
                return _dataBindingExampleButton4Label;
            }
        }

        private static Template _dataBindingExampleLabel1;
        public static Template DataBindingExampleLabel1
        {
            get
            {
#if UNITY_EDITOR
                if (_dataBindingExampleLabel1 == null || _dataBindingExampleLabel1.CurrentVersion != Template.Version)
#else
                if (_dataBindingExampleLabel1 == null)
#endif
                {
                    _dataBindingExampleLabel1 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _dataBindingExampleLabel1.Name = "DataBindingExampleLabel1";
#endif
                    Delight.Label.WidthProperty.SetDefault(_dataBindingExampleLabel1, new ElementSize(130f, ElementSizeUnit.Pixels));
                    Delight.Label.HeightProperty.SetDefault(_dataBindingExampleLabel1, new ElementSize(50f, ElementSizeUnit.Pixels));
                    Delight.Label.TextProperty.SetHasBinding(_dataBindingExampleLabel1);
                }
                return _dataBindingExampleLabel1;
            }
        }

        private static Template _dataBindingExampleButton5;
        public static Template DataBindingExampleButton5
        {
            get
            {
#if UNITY_EDITOR
                if (_dataBindingExampleButton5 == null || _dataBindingExampleButton5.CurrentVersion != Template.Version)
#else
                if (_dataBindingExampleButton5 == null)
#endif
                {
                    _dataBindingExampleButton5 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _dataBindingExampleButton5.Name = "DataBindingExampleButton5";
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_dataBindingExampleButton5, DataBindingExampleButton5Label);
                }
                return _dataBindingExampleButton5;
            }
        }

        private static Template _dataBindingExampleButton5Label;
        public static Template DataBindingExampleButton5Label
        {
            get
            {
#if UNITY_EDITOR
                if (_dataBindingExampleButton5Label == null || _dataBindingExampleButton5Label.CurrentVersion != Template.Version)
#else
                if (_dataBindingExampleButton5Label == null)
#endif
                {
                    _dataBindingExampleButton5Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _dataBindingExampleButton5Label.Name = "DataBindingExampleButton5Label";
#endif
                    Delight.Label.TextProperty.SetHasBinding(_dataBindingExampleButton5Label);
                }
                return _dataBindingExampleButton5Label;
            }
        }

        private static Template _dataBindingExampleButton6;
        public static Template DataBindingExampleButton6
        {
            get
            {
#if UNITY_EDITOR
                if (_dataBindingExampleButton6 == null || _dataBindingExampleButton6.CurrentVersion != Template.Version)
#else
                if (_dataBindingExampleButton6 == null)
#endif
                {
                    _dataBindingExampleButton6 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _dataBindingExampleButton6.Name = "DataBindingExampleButton6";
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_dataBindingExampleButton6, DataBindingExampleButton6Label);
                }
                return _dataBindingExampleButton6;
            }
        }

        private static Template _dataBindingExampleButton6Label;
        public static Template DataBindingExampleButton6Label
        {
            get
            {
#if UNITY_EDITOR
                if (_dataBindingExampleButton6Label == null || _dataBindingExampleButton6Label.CurrentVersion != Template.Version)
#else
                if (_dataBindingExampleButton6Label == null)
#endif
                {
                    _dataBindingExampleButton6Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _dataBindingExampleButton6Label.Name = "DataBindingExampleButton6Label";
#endif
                    Delight.Label.TextProperty.SetHasBinding(_dataBindingExampleButton6Label);
                }
                return _dataBindingExampleButton6Label;
            }
        }

        private static Template _dataBindingExampleRegionOnDemand;
        public static Template DataBindingExampleRegionOnDemand
        {
            get
            {
#if UNITY_EDITOR
                if (_dataBindingExampleRegionOnDemand == null || _dataBindingExampleRegionOnDemand.CurrentVersion != Template.Version)
#else
                if (_dataBindingExampleRegionOnDemand == null)
#endif
                {
                    _dataBindingExampleRegionOnDemand = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _dataBindingExampleRegionOnDemand.Name = "DataBindingExampleRegionOnDemand";
#endif
                    Delight.Region.WidthProperty.SetDefault(_dataBindingExampleRegionOnDemand, new ElementSize(0.75f, ElementSizeUnit.Percents));
                    Delight.Region.AlignmentProperty.SetDefault(_dataBindingExampleRegionOnDemand, Delight.ElementAlignment.Right);
                    Delight.Region.MarginProperty.SetDefault(_dataBindingExampleRegionOnDemand, new ElementMargin(new ElementSize(15f, ElementSizeUnit.Pixels), new ElementSize(30f, ElementSizeUnit.Pixels), new ElementSize(30f, ElementSizeUnit.Pixels), new ElementSize(30f, ElementSizeUnit.Pixels)));
                    Delight.Region.BackgroundColorProperty.SetDefault(_dataBindingExampleRegionOnDemand, new UnityEngine.Color(0.5803922f, 0.5803922f, 0.5803922f, 1f));
                }
                return _dataBindingExampleRegionOnDemand;
            }
        }

        private static Template _dataBindingExampleGroup2;
        public static Template DataBindingExampleGroup2
        {
            get
            {
#if UNITY_EDITOR
                if (_dataBindingExampleGroup2 == null || _dataBindingExampleGroup2.CurrentVersion != Template.Version)
#else
                if (_dataBindingExampleGroup2 == null)
#endif
                {
                    _dataBindingExampleGroup2 = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _dataBindingExampleGroup2.Name = "DataBindingExampleGroup2";
#endif
                }
                return _dataBindingExampleGroup2;
            }
        }

        private static Template _dataBindingExampleLabel2;
        public static Template DataBindingExampleLabel2
        {
            get
            {
#if UNITY_EDITOR
                if (_dataBindingExampleLabel2 == null || _dataBindingExampleLabel2.CurrentVersion != Template.Version)
#else
                if (_dataBindingExampleLabel2 == null)
#endif
                {
                    _dataBindingExampleLabel2 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _dataBindingExampleLabel2.Name = "DataBindingExampleLabel2";
#endif
                    Delight.Label.HeightProperty.SetDefault(_dataBindingExampleLabel2, new ElementSize(40f, ElementSizeUnit.Pixels));
                    Delight.Label.TextProperty.SetHasBinding(_dataBindingExampleLabel2);
                }
                return _dataBindingExampleLabel2;
            }
        }

        private static Template _dataBindingExampleLabel3;
        public static Template DataBindingExampleLabel3
        {
            get
            {
#if UNITY_EDITOR
                if (_dataBindingExampleLabel3 == null || _dataBindingExampleLabel3.CurrentVersion != Template.Version)
#else
                if (_dataBindingExampleLabel3 == null)
#endif
                {
                    _dataBindingExampleLabel3 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _dataBindingExampleLabel3.Name = "DataBindingExampleLabel3";
#endif
                    Delight.Label.HeightProperty.SetDefault(_dataBindingExampleLabel3, new ElementSize(40f, ElementSizeUnit.Pixels));
                    Delight.Label.TextProperty.SetHasBinding(_dataBindingExampleLabel3);
                }
                return _dataBindingExampleLabel3;
            }
        }

        #endregion
    }

    #endregion
}
