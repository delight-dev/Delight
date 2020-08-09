// Internal view logic generated from "InlineCodeExample.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class InlineCodeExample : LayoutRoot
    {
        #region Constructors

        public InlineCodeExample(View parent, View layoutParent = null, string id = null, Template template = null, bool deferInitialization = false) :
            base(parent, layoutParent, id, template ?? InlineCodeExampleTemplates.Default, deferInitialization)
        {
            if (deferInitialization)
                return;

            // constructing Group (Group1)
            Group1 = new Group(this, this, "Group1", Group1Template);
            Group2 = new Group(this, Group1.Content, "Group2", Group2Template);
            Region1 = new Region(this, Group2.Content, "Region1", Region1Template);
            Region2 = new Region(this, Region1.Content, "Region2", Region2Template);

            // binding <Region IsVisible="$ {ClickCount} > 0">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "ClickCount" }, new List<Func<BindableObject>> { () => this }) }, new BindingPath(new List<string> { "Region2", "IsVisible" }, new List<Func<BindableObject>> { () => this, () => Region2 }), () => Region2.IsVisible = ClickCount > 0, () => { }, false));
            Label1 = new Label(this, Region1.Content, "Label1", Label1Template);
            Region3 = new Region(this, Group2.Content, "Region3", Region3Template);
            Region4 = new Region(this, Region3.Content, "Region4", Region4Template);

            // binding <Region IsVisible="$ {ClickCount} > 5">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "ClickCount" }, new List<Func<BindableObject>> { () => this }) }, new BindingPath(new List<string> { "Region4", "IsVisible" }, new List<Func<BindableObject>> { () => this, () => Region4 }), () => Region4.IsVisible = ClickCount > 5, () => { }, false));
            Label2 = new Label(this, Region3.Content, "Label2", Label2Template);
            Region5 = new Region(this, Group2.Content, "Region5", Region5Template);
            Region6 = new Region(this, Region5.Content, "Region6", Region6Template);

            // binding <Region IsVisible="$ {ClickCount} > 10">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "ClickCount" }, new List<Func<BindableObject>> { () => this }) }, new BindingPath(new List<string> { "Region6", "IsVisible" }, new List<Func<BindableObject>> { () => this, () => Region6 }), () => Region6.IsVisible = ClickCount > 10, () => { }, false));
            Label3 = new Label(this, Region5.Content, "Label3", Label3Template);
            Group3 = new Group(this, Group1.Content, "Group3", Group3Template);
            Group4 = new Group(this, Group3.Content, "Group4", Group4Template);
            Button1 = new Button(this, Group4.Content, "Button1", Button1Template);
            Button1.Click.RegisterHandler(() => ++ClickCount);
            Button2 = new Button(this, Group4.Content, "Button2", Button2Template);
            Button2.Click.RegisterHandler(() => ClickCount = 0);
            Label4 = new Label(this, Group3.Content, "Label4", Label4Template);

            // binding <Label Text="Click count: {ClickCount}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "ClickCount" }, new List<Func<BindableObject>> { () => this }) }, new BindingPath(new List<string> { "Label4", "Text" }, new List<Func<BindableObject>> { () => this, () => Label4 }), () => Label4.Text = String.Format("Click count: {0}", ClickCount), () => { }, false));
            Group5 = new Group(this, Group3.Content, "Group5", Group5Template);
            Label5 = new Label(this, Group5.Content, "Label5", Label5Template);

            // binding <Label Text="{ClickCount}^2 = ">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "ClickCount" }, new List<Func<BindableObject>> { () => this }) }, new BindingPath(new List<string> { "Label5", "Text" }, new List<Func<BindableObject>> { () => this, () => Label5 }), () => Label5.Text = String.Format("{0}^2 = ", ClickCount), () => { }, false));
            Label6 = new Label(this, Group5.Content, "Label6", Label6Template);

            // binding <Label Text="$ Math.Pow({ClickCount}, 2).ToString()">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "ClickCount" }, new List<Func<BindableObject>> { () => this }) }, new BindingPath(new List<string> { "Label6", "Text" }, new List<Func<BindableObject>> { () => this, () => Label6 }), () => Label6.Text = Math.Pow(ClickCount, 2).ToString(), () => { }, false));
            this.AfterInitializeInternal();
        }

        public InlineCodeExample() : this(null)
        {
        }

        static InlineCodeExample()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(InlineCodeExampleTemplates.Default, dependencyProperties);

            dependencyProperties.Add(ClickCountProperty);
            dependencyProperties.Add(Group1Property);
            dependencyProperties.Add(Group1TemplateProperty);
            dependencyProperties.Add(Group2Property);
            dependencyProperties.Add(Group2TemplateProperty);
            dependencyProperties.Add(Region1Property);
            dependencyProperties.Add(Region1TemplateProperty);
            dependencyProperties.Add(Region2Property);
            dependencyProperties.Add(Region2TemplateProperty);
            dependencyProperties.Add(Label1Property);
            dependencyProperties.Add(Label1TemplateProperty);
            dependencyProperties.Add(Region3Property);
            dependencyProperties.Add(Region3TemplateProperty);
            dependencyProperties.Add(Region4Property);
            dependencyProperties.Add(Region4TemplateProperty);
            dependencyProperties.Add(Label2Property);
            dependencyProperties.Add(Label2TemplateProperty);
            dependencyProperties.Add(Region5Property);
            dependencyProperties.Add(Region5TemplateProperty);
            dependencyProperties.Add(Region6Property);
            dependencyProperties.Add(Region6TemplateProperty);
            dependencyProperties.Add(Label3Property);
            dependencyProperties.Add(Label3TemplateProperty);
            dependencyProperties.Add(Group3Property);
            dependencyProperties.Add(Group3TemplateProperty);
            dependencyProperties.Add(Group4Property);
            dependencyProperties.Add(Group4TemplateProperty);
            dependencyProperties.Add(Button1Property);
            dependencyProperties.Add(Button1TemplateProperty);
            dependencyProperties.Add(Button2Property);
            dependencyProperties.Add(Button2TemplateProperty);
            dependencyProperties.Add(Label4Property);
            dependencyProperties.Add(Label4TemplateProperty);
            dependencyProperties.Add(Group5Property);
            dependencyProperties.Add(Group5TemplateProperty);
            dependencyProperties.Add(Label5Property);
            dependencyProperties.Add(Label5TemplateProperty);
            dependencyProperties.Add(Label6Property);
            dependencyProperties.Add(Label6TemplateProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<System.Int32> ClickCountProperty = new DependencyProperty<System.Int32>("ClickCount");
        public System.Int32 ClickCount
        {
            get { return ClickCountProperty.GetValue(this); }
            set { ClickCountProperty.SetValue(this, value); }
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

        public readonly static DependencyProperty<Region> Region2Property = new DependencyProperty<Region>("Region2");
        public Region Region2
        {
            get { return Region2Property.GetValue(this); }
            set { Region2Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Region2TemplateProperty = new DependencyProperty<Template>("Region2Template");
        public Template Region2Template
        {
            get { return Region2TemplateProperty.GetValue(this); }
            set { Region2TemplateProperty.SetValue(this, value); }
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

        public readonly static DependencyProperty<Region> Region3Property = new DependencyProperty<Region>("Region3");
        public Region Region3
        {
            get { return Region3Property.GetValue(this); }
            set { Region3Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Region3TemplateProperty = new DependencyProperty<Template>("Region3Template");
        public Template Region3Template
        {
            get { return Region3TemplateProperty.GetValue(this); }
            set { Region3TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> Region4Property = new DependencyProperty<Region>("Region4");
        public Region Region4
        {
            get { return Region4Property.GetValue(this); }
            set { Region4Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Region4TemplateProperty = new DependencyProperty<Template>("Region4Template");
        public Template Region4Template
        {
            get { return Region4TemplateProperty.GetValue(this); }
            set { Region4TemplateProperty.SetValue(this, value); }
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

        public readonly static DependencyProperty<Region> Region5Property = new DependencyProperty<Region>("Region5");
        public Region Region5
        {
            get { return Region5Property.GetValue(this); }
            set { Region5Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Region5TemplateProperty = new DependencyProperty<Template>("Region5Template");
        public Template Region5Template
        {
            get { return Region5TemplateProperty.GetValue(this); }
            set { Region5TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> Region6Property = new DependencyProperty<Region>("Region6");
        public Region Region6
        {
            get { return Region6Property.GetValue(this); }
            set { Region6Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Region6TemplateProperty = new DependencyProperty<Template>("Region6Template");
        public Template Region6Template
        {
            get { return Region6TemplateProperty.GetValue(this); }
            set { Region6TemplateProperty.SetValue(this, value); }
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

        public readonly static DependencyProperty<Group> Group4Property = new DependencyProperty<Group>("Group4");
        public Group Group4
        {
            get { return Group4Property.GetValue(this); }
            set { Group4Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Group4TemplateProperty = new DependencyProperty<Template>("Group4Template");
        public Template Group4Template
        {
            get { return Group4TemplateProperty.GetValue(this); }
            set { Group4TemplateProperty.SetValue(this, value); }
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

        public readonly static DependencyProperty<Group> Group5Property = new DependencyProperty<Group>("Group5");
        public Group Group5
        {
            get { return Group5Property.GetValue(this); }
            set { Group5Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Group5TemplateProperty = new DependencyProperty<Template>("Group5Template");
        public Template Group5Template
        {
            get { return Group5TemplateProperty.GetValue(this); }
            set { Group5TemplateProperty.SetValue(this, value); }
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

        #endregion
    }

    #region Data Templates

    public static class InlineCodeExampleTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return InlineCodeExample;
            }
        }

        private static Template _inlineCodeExample;
        public static Template InlineCodeExample
        {
            get
            {
#if UNITY_EDITOR
                if (_inlineCodeExample == null || _inlineCodeExample.CurrentVersion != Template.Version)
#else
                if (_inlineCodeExample == null)
#endif
                {
                    _inlineCodeExample = new Template(LayoutRootTemplates.LayoutRoot);
#if UNITY_EDITOR
                    _inlineCodeExample.Name = "InlineCodeExample";
#endif
                    Delight.InlineCodeExample.Group1TemplateProperty.SetDefault(_inlineCodeExample, InlineCodeExampleGroup1);
                    Delight.InlineCodeExample.Group2TemplateProperty.SetDefault(_inlineCodeExample, InlineCodeExampleGroup2);
                    Delight.InlineCodeExample.Region1TemplateProperty.SetDefault(_inlineCodeExample, InlineCodeExampleRegion1);
                    Delight.InlineCodeExample.Region2TemplateProperty.SetDefault(_inlineCodeExample, InlineCodeExampleRegion2);
                    Delight.InlineCodeExample.Label1TemplateProperty.SetDefault(_inlineCodeExample, InlineCodeExampleLabel1);
                    Delight.InlineCodeExample.Region3TemplateProperty.SetDefault(_inlineCodeExample, InlineCodeExampleRegion3);
                    Delight.InlineCodeExample.Region4TemplateProperty.SetDefault(_inlineCodeExample, InlineCodeExampleRegion4);
                    Delight.InlineCodeExample.Label2TemplateProperty.SetDefault(_inlineCodeExample, InlineCodeExampleLabel2);
                    Delight.InlineCodeExample.Region5TemplateProperty.SetDefault(_inlineCodeExample, InlineCodeExampleRegion5);
                    Delight.InlineCodeExample.Region6TemplateProperty.SetDefault(_inlineCodeExample, InlineCodeExampleRegion6);
                    Delight.InlineCodeExample.Label3TemplateProperty.SetDefault(_inlineCodeExample, InlineCodeExampleLabel3);
                    Delight.InlineCodeExample.Group3TemplateProperty.SetDefault(_inlineCodeExample, InlineCodeExampleGroup3);
                    Delight.InlineCodeExample.Group4TemplateProperty.SetDefault(_inlineCodeExample, InlineCodeExampleGroup4);
                    Delight.InlineCodeExample.Button1TemplateProperty.SetDefault(_inlineCodeExample, InlineCodeExampleButton1);
                    Delight.InlineCodeExample.Button2TemplateProperty.SetDefault(_inlineCodeExample, InlineCodeExampleButton2);
                    Delight.InlineCodeExample.Label4TemplateProperty.SetDefault(_inlineCodeExample, InlineCodeExampleLabel4);
                    Delight.InlineCodeExample.Group5TemplateProperty.SetDefault(_inlineCodeExample, InlineCodeExampleGroup5);
                    Delight.InlineCodeExample.Label5TemplateProperty.SetDefault(_inlineCodeExample, InlineCodeExampleLabel5);
                    Delight.InlineCodeExample.Label6TemplateProperty.SetDefault(_inlineCodeExample, InlineCodeExampleLabel6);
                }
                return _inlineCodeExample;
            }
        }

        private static Template _inlineCodeExampleGroup1;
        public static Template InlineCodeExampleGroup1
        {
            get
            {
#if UNITY_EDITOR
                if (_inlineCodeExampleGroup1 == null || _inlineCodeExampleGroup1.CurrentVersion != Template.Version)
#else
                if (_inlineCodeExampleGroup1 == null)
#endif
                {
                    _inlineCodeExampleGroup1 = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _inlineCodeExampleGroup1.Name = "InlineCodeExampleGroup1";
#endif
                    Delight.Group.SpacingProperty.SetDefault(_inlineCodeExampleGroup1, new ElementSize(10f, ElementSizeUnit.Pixels));
                }
                return _inlineCodeExampleGroup1;
            }
        }

        private static Template _inlineCodeExampleGroup2;
        public static Template InlineCodeExampleGroup2
        {
            get
            {
#if UNITY_EDITOR
                if (_inlineCodeExampleGroup2 == null || _inlineCodeExampleGroup2.CurrentVersion != Template.Version)
#else
                if (_inlineCodeExampleGroup2 == null)
#endif
                {
                    _inlineCodeExampleGroup2 = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _inlineCodeExampleGroup2.Name = "InlineCodeExampleGroup2";
#endif
                    Delight.Group.OrientationProperty.SetDefault(_inlineCodeExampleGroup2, Delight.ElementOrientation.Horizontal);
                    Delight.Group.SpacingProperty.SetDefault(_inlineCodeExampleGroup2, new ElementSize(5f, ElementSizeUnit.Pixels));
                }
                return _inlineCodeExampleGroup2;
            }
        }

        private static Template _inlineCodeExampleRegion1;
        public static Template InlineCodeExampleRegion1
        {
            get
            {
#if UNITY_EDITOR
                if (_inlineCodeExampleRegion1 == null || _inlineCodeExampleRegion1.CurrentVersion != Template.Version)
#else
                if (_inlineCodeExampleRegion1 == null)
#endif
                {
                    _inlineCodeExampleRegion1 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _inlineCodeExampleRegion1.Name = "InlineCodeExampleRegion1";
#endif
                    Delight.Region.BackgroundColorProperty.SetDefault(_inlineCodeExampleRegion1, new UnityEngine.Color(0f, 0f, 1f, 1f));
                    Delight.Region.WidthProperty.SetDefault(_inlineCodeExampleRegion1, new ElementSize(50f, ElementSizeUnit.Pixels));
                    Delight.Region.HeightProperty.SetDefault(_inlineCodeExampleRegion1, new ElementSize(50f, ElementSizeUnit.Pixels));
                }
                return _inlineCodeExampleRegion1;
            }
        }

        private static Template _inlineCodeExampleRegion2;
        public static Template InlineCodeExampleRegion2
        {
            get
            {
#if UNITY_EDITOR
                if (_inlineCodeExampleRegion2 == null || _inlineCodeExampleRegion2.CurrentVersion != Template.Version)
#else
                if (_inlineCodeExampleRegion2 == null)
#endif
                {
                    _inlineCodeExampleRegion2 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _inlineCodeExampleRegion2.Name = "InlineCodeExampleRegion2";
#endif
                    Delight.Region.BackgroundColorProperty.SetDefault(_inlineCodeExampleRegion2, new UnityEngine.Color(1f, 1f, 0f, 1f));
                    Delight.Region.IsVisibleProperty.SetHasBinding(_inlineCodeExampleRegion2);
                }
                return _inlineCodeExampleRegion2;
            }
        }

        private static Template _inlineCodeExampleLabel1;
        public static Template InlineCodeExampleLabel1
        {
            get
            {
#if UNITY_EDITOR
                if (_inlineCodeExampleLabel1 == null || _inlineCodeExampleLabel1.CurrentVersion != Template.Version)
#else
                if (_inlineCodeExampleLabel1 == null)
#endif
                {
                    _inlineCodeExampleLabel1 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _inlineCodeExampleLabel1.Name = "InlineCodeExampleLabel1";
#endif
                    Delight.Label.TextProperty.SetDefault(_inlineCodeExampleLabel1, "> 0");
                    Delight.Label.AutoSizeProperty.SetDefault(_inlineCodeExampleLabel1, Delight.AutoSize.Default);
                }
                return _inlineCodeExampleLabel1;
            }
        }

        private static Template _inlineCodeExampleRegion3;
        public static Template InlineCodeExampleRegion3
        {
            get
            {
#if UNITY_EDITOR
                if (_inlineCodeExampleRegion3 == null || _inlineCodeExampleRegion3.CurrentVersion != Template.Version)
#else
                if (_inlineCodeExampleRegion3 == null)
#endif
                {
                    _inlineCodeExampleRegion3 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _inlineCodeExampleRegion3.Name = "InlineCodeExampleRegion3";
#endif
                    Delight.Region.BackgroundColorProperty.SetDefault(_inlineCodeExampleRegion3, new UnityEngine.Color(0f, 0f, 1f, 1f));
                    Delight.Region.WidthProperty.SetDefault(_inlineCodeExampleRegion3, new ElementSize(50f, ElementSizeUnit.Pixels));
                    Delight.Region.HeightProperty.SetDefault(_inlineCodeExampleRegion3, new ElementSize(50f, ElementSizeUnit.Pixels));
                }
                return _inlineCodeExampleRegion3;
            }
        }

        private static Template _inlineCodeExampleRegion4;
        public static Template InlineCodeExampleRegion4
        {
            get
            {
#if UNITY_EDITOR
                if (_inlineCodeExampleRegion4 == null || _inlineCodeExampleRegion4.CurrentVersion != Template.Version)
#else
                if (_inlineCodeExampleRegion4 == null)
#endif
                {
                    _inlineCodeExampleRegion4 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _inlineCodeExampleRegion4.Name = "InlineCodeExampleRegion4";
#endif
                    Delight.Region.BackgroundColorProperty.SetDefault(_inlineCodeExampleRegion4, new UnityEngine.Color(1f, 1f, 0f, 1f));
                    Delight.Region.IsVisibleProperty.SetHasBinding(_inlineCodeExampleRegion4);
                }
                return _inlineCodeExampleRegion4;
            }
        }

        private static Template _inlineCodeExampleLabel2;
        public static Template InlineCodeExampleLabel2
        {
            get
            {
#if UNITY_EDITOR
                if (_inlineCodeExampleLabel2 == null || _inlineCodeExampleLabel2.CurrentVersion != Template.Version)
#else
                if (_inlineCodeExampleLabel2 == null)
#endif
                {
                    _inlineCodeExampleLabel2 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _inlineCodeExampleLabel2.Name = "InlineCodeExampleLabel2";
#endif
                    Delight.Label.TextProperty.SetDefault(_inlineCodeExampleLabel2, "> 5");
                    Delight.Label.AutoSizeProperty.SetDefault(_inlineCodeExampleLabel2, Delight.AutoSize.Default);
                }
                return _inlineCodeExampleLabel2;
            }
        }

        private static Template _inlineCodeExampleRegion5;
        public static Template InlineCodeExampleRegion5
        {
            get
            {
#if UNITY_EDITOR
                if (_inlineCodeExampleRegion5 == null || _inlineCodeExampleRegion5.CurrentVersion != Template.Version)
#else
                if (_inlineCodeExampleRegion5 == null)
#endif
                {
                    _inlineCodeExampleRegion5 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _inlineCodeExampleRegion5.Name = "InlineCodeExampleRegion5";
#endif
                    Delight.Region.BackgroundColorProperty.SetDefault(_inlineCodeExampleRegion5, new UnityEngine.Color(0f, 0f, 1f, 1f));
                    Delight.Region.WidthProperty.SetDefault(_inlineCodeExampleRegion5, new ElementSize(50f, ElementSizeUnit.Pixels));
                    Delight.Region.HeightProperty.SetDefault(_inlineCodeExampleRegion5, new ElementSize(50f, ElementSizeUnit.Pixels));
                }
                return _inlineCodeExampleRegion5;
            }
        }

        private static Template _inlineCodeExampleRegion6;
        public static Template InlineCodeExampleRegion6
        {
            get
            {
#if UNITY_EDITOR
                if (_inlineCodeExampleRegion6 == null || _inlineCodeExampleRegion6.CurrentVersion != Template.Version)
#else
                if (_inlineCodeExampleRegion6 == null)
#endif
                {
                    _inlineCodeExampleRegion6 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _inlineCodeExampleRegion6.Name = "InlineCodeExampleRegion6";
#endif
                    Delight.Region.BackgroundColorProperty.SetDefault(_inlineCodeExampleRegion6, new UnityEngine.Color(1f, 1f, 0f, 1f));
                    Delight.Region.IsVisibleProperty.SetHasBinding(_inlineCodeExampleRegion6);
                }
                return _inlineCodeExampleRegion6;
            }
        }

        private static Template _inlineCodeExampleLabel3;
        public static Template InlineCodeExampleLabel3
        {
            get
            {
#if UNITY_EDITOR
                if (_inlineCodeExampleLabel3 == null || _inlineCodeExampleLabel3.CurrentVersion != Template.Version)
#else
                if (_inlineCodeExampleLabel3 == null)
#endif
                {
                    _inlineCodeExampleLabel3 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _inlineCodeExampleLabel3.Name = "InlineCodeExampleLabel3";
#endif
                    Delight.Label.TextProperty.SetDefault(_inlineCodeExampleLabel3, "> 10");
                    Delight.Label.AutoSizeProperty.SetDefault(_inlineCodeExampleLabel3, Delight.AutoSize.Default);
                }
                return _inlineCodeExampleLabel3;
            }
        }

        private static Template _inlineCodeExampleGroup3;
        public static Template InlineCodeExampleGroup3
        {
            get
            {
#if UNITY_EDITOR
                if (_inlineCodeExampleGroup3 == null || _inlineCodeExampleGroup3.CurrentVersion != Template.Version)
#else
                if (_inlineCodeExampleGroup3 == null)
#endif
                {
                    _inlineCodeExampleGroup3 = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _inlineCodeExampleGroup3.Name = "InlineCodeExampleGroup3";
#endif
                    Delight.Group.SpacingProperty.SetDefault(_inlineCodeExampleGroup3, new ElementSize(5f, ElementSizeUnit.Pixels));
                }
                return _inlineCodeExampleGroup3;
            }
        }

        private static Template _inlineCodeExampleGroup4;
        public static Template InlineCodeExampleGroup4
        {
            get
            {
#if UNITY_EDITOR
                if (_inlineCodeExampleGroup4 == null || _inlineCodeExampleGroup4.CurrentVersion != Template.Version)
#else
                if (_inlineCodeExampleGroup4 == null)
#endif
                {
                    _inlineCodeExampleGroup4 = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _inlineCodeExampleGroup4.Name = "InlineCodeExampleGroup4";
#endif
                    Delight.Group.OrientationProperty.SetDefault(_inlineCodeExampleGroup4, Delight.ElementOrientation.Horizontal);
                    Delight.Group.SpacingProperty.SetDefault(_inlineCodeExampleGroup4, new ElementSize(5f, ElementSizeUnit.Pixels));
                }
                return _inlineCodeExampleGroup4;
            }
        }

        private static Template _inlineCodeExampleButton1;
        public static Template InlineCodeExampleButton1
        {
            get
            {
#if UNITY_EDITOR
                if (_inlineCodeExampleButton1 == null || _inlineCodeExampleButton1.CurrentVersion != Template.Version)
#else
                if (_inlineCodeExampleButton1 == null)
#endif
                {
                    _inlineCodeExampleButton1 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _inlineCodeExampleButton1.Name = "InlineCodeExampleButton1";
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_inlineCodeExampleButton1, InlineCodeExampleButton1Label);
                }
                return _inlineCodeExampleButton1;
            }
        }

        private static Template _inlineCodeExampleButton1Label;
        public static Template InlineCodeExampleButton1Label
        {
            get
            {
#if UNITY_EDITOR
                if (_inlineCodeExampleButton1Label == null || _inlineCodeExampleButton1Label.CurrentVersion != Template.Version)
#else
                if (_inlineCodeExampleButton1Label == null)
#endif
                {
                    _inlineCodeExampleButton1Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _inlineCodeExampleButton1Label.Name = "InlineCodeExampleButton1Label";
#endif
                    Delight.Label.TextProperty.SetDefault(_inlineCodeExampleButton1Label, "Click Me");
                }
                return _inlineCodeExampleButton1Label;
            }
        }

        private static Template _inlineCodeExampleButton2;
        public static Template InlineCodeExampleButton2
        {
            get
            {
#if UNITY_EDITOR
                if (_inlineCodeExampleButton2 == null || _inlineCodeExampleButton2.CurrentVersion != Template.Version)
#else
                if (_inlineCodeExampleButton2 == null)
#endif
                {
                    _inlineCodeExampleButton2 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _inlineCodeExampleButton2.Name = "InlineCodeExampleButton2";
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_inlineCodeExampleButton2, InlineCodeExampleButton2Label);
                }
                return _inlineCodeExampleButton2;
            }
        }

        private static Template _inlineCodeExampleButton2Label;
        public static Template InlineCodeExampleButton2Label
        {
            get
            {
#if UNITY_EDITOR
                if (_inlineCodeExampleButton2Label == null || _inlineCodeExampleButton2Label.CurrentVersion != Template.Version)
#else
                if (_inlineCodeExampleButton2Label == null)
#endif
                {
                    _inlineCodeExampleButton2Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _inlineCodeExampleButton2Label.Name = "InlineCodeExampleButton2Label";
#endif
                    Delight.Label.TextProperty.SetDefault(_inlineCodeExampleButton2Label, "Reset");
                }
                return _inlineCodeExampleButton2Label;
            }
        }

        private static Template _inlineCodeExampleLabel4;
        public static Template InlineCodeExampleLabel4
        {
            get
            {
#if UNITY_EDITOR
                if (_inlineCodeExampleLabel4 == null || _inlineCodeExampleLabel4.CurrentVersion != Template.Version)
#else
                if (_inlineCodeExampleLabel4 == null)
#endif
                {
                    _inlineCodeExampleLabel4 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _inlineCodeExampleLabel4.Name = "InlineCodeExampleLabel4";
#endif
                    Delight.Label.AutoSizeProperty.SetDefault(_inlineCodeExampleLabel4, Delight.AutoSize.Default);
                    Delight.Label.FontColorProperty.SetDefault(_inlineCodeExampleLabel4, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Label.TextProperty.SetHasBinding(_inlineCodeExampleLabel4);
                }
                return _inlineCodeExampleLabel4;
            }
        }

        private static Template _inlineCodeExampleGroup5;
        public static Template InlineCodeExampleGroup5
        {
            get
            {
#if UNITY_EDITOR
                if (_inlineCodeExampleGroup5 == null || _inlineCodeExampleGroup5.CurrentVersion != Template.Version)
#else
                if (_inlineCodeExampleGroup5 == null)
#endif
                {
                    _inlineCodeExampleGroup5 = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _inlineCodeExampleGroup5.Name = "InlineCodeExampleGroup5";
#endif
                    Delight.Group.OrientationProperty.SetDefault(_inlineCodeExampleGroup5, Delight.ElementOrientation.Horizontal);
                }
                return _inlineCodeExampleGroup5;
            }
        }

        private static Template _inlineCodeExampleLabel5;
        public static Template InlineCodeExampleLabel5
        {
            get
            {
#if UNITY_EDITOR
                if (_inlineCodeExampleLabel5 == null || _inlineCodeExampleLabel5.CurrentVersion != Template.Version)
#else
                if (_inlineCodeExampleLabel5 == null)
#endif
                {
                    _inlineCodeExampleLabel5 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _inlineCodeExampleLabel5.Name = "InlineCodeExampleLabel5";
#endif
                    Delight.Label.AutoSizeProperty.SetDefault(_inlineCodeExampleLabel5, Delight.AutoSize.Default);
                    Delight.Label.FontColorProperty.SetDefault(_inlineCodeExampleLabel5, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Label.TextProperty.SetHasBinding(_inlineCodeExampleLabel5);
                }
                return _inlineCodeExampleLabel5;
            }
        }

        private static Template _inlineCodeExampleLabel6;
        public static Template InlineCodeExampleLabel6
        {
            get
            {
#if UNITY_EDITOR
                if (_inlineCodeExampleLabel6 == null || _inlineCodeExampleLabel6.CurrentVersion != Template.Version)
#else
                if (_inlineCodeExampleLabel6 == null)
#endif
                {
                    _inlineCodeExampleLabel6 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _inlineCodeExampleLabel6.Name = "InlineCodeExampleLabel6";
#endif
                    Delight.Label.AutoSizeProperty.SetDefault(_inlineCodeExampleLabel6, Delight.AutoSize.Default);
                    Delight.Label.FontColorProperty.SetDefault(_inlineCodeExampleLabel6, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Label.TextProperty.SetHasBinding(_inlineCodeExampleLabel6);
                }
                return _inlineCodeExampleLabel6;
            }
        }

        #endregion
    }

    #endregion
}
