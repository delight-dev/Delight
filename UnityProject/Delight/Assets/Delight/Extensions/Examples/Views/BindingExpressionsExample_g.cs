// Internal view logic generated from "BindingExpressionsExample.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class BindingExpressionsExample : LayoutRoot
    {
        #region Constructors

        public BindingExpressionsExample(View parent, View layoutParent = null, string id = null, Template template = null, bool deferInitialization = false) :
            base(parent, layoutParent, id, template ?? BindingExpressionsExampleTemplates.Default, deferInitialization)
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
            Button1.Click.RegisterHandler(this, "ButtonClick");
            Button2 = new Button(this, Group4.Content, "Button2", Button2Template);
            Button2.Click.RegisterHandler(this, "Reset");
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

        public BindingExpressionsExample() : this(null)
        {
        }

        static BindingExpressionsExample()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(BindingExpressionsExampleTemplates.Default, dependencyProperties);

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

    public static class BindingExpressionsExampleTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return BindingExpressionsExample;
            }
        }

        private static Template _bindingExpressionsExample;
        public static Template BindingExpressionsExample
        {
            get
            {
#if UNITY_EDITOR
                if (_bindingExpressionsExample == null || _bindingExpressionsExample.CurrentVersion != Template.Version)
#else
                if (_bindingExpressionsExample == null)
#endif
                {
                    _bindingExpressionsExample = new Template(LayoutRootTemplates.LayoutRoot);
#if UNITY_EDITOR
                    _bindingExpressionsExample.Name = "BindingExpressionsExample";
#endif
                    Delight.BindingExpressionsExample.Group1TemplateProperty.SetDefault(_bindingExpressionsExample, BindingExpressionsExampleGroup1);
                    Delight.BindingExpressionsExample.Group2TemplateProperty.SetDefault(_bindingExpressionsExample, BindingExpressionsExampleGroup2);
                    Delight.BindingExpressionsExample.Region1TemplateProperty.SetDefault(_bindingExpressionsExample, BindingExpressionsExampleRegion1);
                    Delight.BindingExpressionsExample.Region2TemplateProperty.SetDefault(_bindingExpressionsExample, BindingExpressionsExampleRegion2);
                    Delight.BindingExpressionsExample.Label1TemplateProperty.SetDefault(_bindingExpressionsExample, BindingExpressionsExampleLabel1);
                    Delight.BindingExpressionsExample.Region3TemplateProperty.SetDefault(_bindingExpressionsExample, BindingExpressionsExampleRegion3);
                    Delight.BindingExpressionsExample.Region4TemplateProperty.SetDefault(_bindingExpressionsExample, BindingExpressionsExampleRegion4);
                    Delight.BindingExpressionsExample.Label2TemplateProperty.SetDefault(_bindingExpressionsExample, BindingExpressionsExampleLabel2);
                    Delight.BindingExpressionsExample.Region5TemplateProperty.SetDefault(_bindingExpressionsExample, BindingExpressionsExampleRegion5);
                    Delight.BindingExpressionsExample.Region6TemplateProperty.SetDefault(_bindingExpressionsExample, BindingExpressionsExampleRegion6);
                    Delight.BindingExpressionsExample.Label3TemplateProperty.SetDefault(_bindingExpressionsExample, BindingExpressionsExampleLabel3);
                    Delight.BindingExpressionsExample.Group3TemplateProperty.SetDefault(_bindingExpressionsExample, BindingExpressionsExampleGroup3);
                    Delight.BindingExpressionsExample.Group4TemplateProperty.SetDefault(_bindingExpressionsExample, BindingExpressionsExampleGroup4);
                    Delight.BindingExpressionsExample.Button1TemplateProperty.SetDefault(_bindingExpressionsExample, BindingExpressionsExampleButton1);
                    Delight.BindingExpressionsExample.Button2TemplateProperty.SetDefault(_bindingExpressionsExample, BindingExpressionsExampleButton2);
                    Delight.BindingExpressionsExample.Label4TemplateProperty.SetDefault(_bindingExpressionsExample, BindingExpressionsExampleLabel4);
                    Delight.BindingExpressionsExample.Group5TemplateProperty.SetDefault(_bindingExpressionsExample, BindingExpressionsExampleGroup5);
                    Delight.BindingExpressionsExample.Label5TemplateProperty.SetDefault(_bindingExpressionsExample, BindingExpressionsExampleLabel5);
                    Delight.BindingExpressionsExample.Label6TemplateProperty.SetDefault(_bindingExpressionsExample, BindingExpressionsExampleLabel6);
                }
                return _bindingExpressionsExample;
            }
        }

        private static Template _bindingExpressionsExampleGroup1;
        public static Template BindingExpressionsExampleGroup1
        {
            get
            {
#if UNITY_EDITOR
                if (_bindingExpressionsExampleGroup1 == null || _bindingExpressionsExampleGroup1.CurrentVersion != Template.Version)
#else
                if (_bindingExpressionsExampleGroup1 == null)
#endif
                {
                    _bindingExpressionsExampleGroup1 = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _bindingExpressionsExampleGroup1.Name = "BindingExpressionsExampleGroup1";
#endif
                    Delight.Group.SpacingProperty.SetDefault(_bindingExpressionsExampleGroup1, new ElementSize(10f, ElementSizeUnit.Pixels));
                }
                return _bindingExpressionsExampleGroup1;
            }
        }

        private static Template _bindingExpressionsExampleGroup2;
        public static Template BindingExpressionsExampleGroup2
        {
            get
            {
#if UNITY_EDITOR
                if (_bindingExpressionsExampleGroup2 == null || _bindingExpressionsExampleGroup2.CurrentVersion != Template.Version)
#else
                if (_bindingExpressionsExampleGroup2 == null)
#endif
                {
                    _bindingExpressionsExampleGroup2 = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _bindingExpressionsExampleGroup2.Name = "BindingExpressionsExampleGroup2";
#endif
                    Delight.Group.OrientationProperty.SetDefault(_bindingExpressionsExampleGroup2, Delight.ElementOrientation.Horizontal);
                    Delight.Group.SpacingProperty.SetDefault(_bindingExpressionsExampleGroup2, new ElementSize(5f, ElementSizeUnit.Pixels));
                }
                return _bindingExpressionsExampleGroup2;
            }
        }

        private static Template _bindingExpressionsExampleRegion1;
        public static Template BindingExpressionsExampleRegion1
        {
            get
            {
#if UNITY_EDITOR
                if (_bindingExpressionsExampleRegion1 == null || _bindingExpressionsExampleRegion1.CurrentVersion != Template.Version)
#else
                if (_bindingExpressionsExampleRegion1 == null)
#endif
                {
                    _bindingExpressionsExampleRegion1 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _bindingExpressionsExampleRegion1.Name = "BindingExpressionsExampleRegion1";
#endif
                    Delight.Region.BackgroundColorProperty.SetDefault(_bindingExpressionsExampleRegion1, new UnityEngine.Color(0f, 0f, 1f, 1f));
                    Delight.Region.WidthProperty.SetDefault(_bindingExpressionsExampleRegion1, new ElementSize(50f, ElementSizeUnit.Pixels));
                    Delight.Region.HeightProperty.SetDefault(_bindingExpressionsExampleRegion1, new ElementSize(50f, ElementSizeUnit.Pixels));
                }
                return _bindingExpressionsExampleRegion1;
            }
        }

        private static Template _bindingExpressionsExampleRegion2;
        public static Template BindingExpressionsExampleRegion2
        {
            get
            {
#if UNITY_EDITOR
                if (_bindingExpressionsExampleRegion2 == null || _bindingExpressionsExampleRegion2.CurrentVersion != Template.Version)
#else
                if (_bindingExpressionsExampleRegion2 == null)
#endif
                {
                    _bindingExpressionsExampleRegion2 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _bindingExpressionsExampleRegion2.Name = "BindingExpressionsExampleRegion2";
#endif
                    Delight.Region.BackgroundColorProperty.SetDefault(_bindingExpressionsExampleRegion2, new UnityEngine.Color(1f, 1f, 0f, 1f));
                    Delight.Region.IsVisibleProperty.SetHasBinding(_bindingExpressionsExampleRegion2);
                }
                return _bindingExpressionsExampleRegion2;
            }
        }

        private static Template _bindingExpressionsExampleLabel1;
        public static Template BindingExpressionsExampleLabel1
        {
            get
            {
#if UNITY_EDITOR
                if (_bindingExpressionsExampleLabel1 == null || _bindingExpressionsExampleLabel1.CurrentVersion != Template.Version)
#else
                if (_bindingExpressionsExampleLabel1 == null)
#endif
                {
                    _bindingExpressionsExampleLabel1 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _bindingExpressionsExampleLabel1.Name = "BindingExpressionsExampleLabel1";
#endif
                    Delight.Label.TextProperty.SetDefault(_bindingExpressionsExampleLabel1, "> 0");
                    Delight.Label.AutoSizeProperty.SetDefault(_bindingExpressionsExampleLabel1, Delight.AutoSize.Default);
                }
                return _bindingExpressionsExampleLabel1;
            }
        }

        private static Template _bindingExpressionsExampleRegion3;
        public static Template BindingExpressionsExampleRegion3
        {
            get
            {
#if UNITY_EDITOR
                if (_bindingExpressionsExampleRegion3 == null || _bindingExpressionsExampleRegion3.CurrentVersion != Template.Version)
#else
                if (_bindingExpressionsExampleRegion3 == null)
#endif
                {
                    _bindingExpressionsExampleRegion3 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _bindingExpressionsExampleRegion3.Name = "BindingExpressionsExampleRegion3";
#endif
                    Delight.Region.BackgroundColorProperty.SetDefault(_bindingExpressionsExampleRegion3, new UnityEngine.Color(0f, 0f, 1f, 1f));
                    Delight.Region.WidthProperty.SetDefault(_bindingExpressionsExampleRegion3, new ElementSize(50f, ElementSizeUnit.Pixels));
                    Delight.Region.HeightProperty.SetDefault(_bindingExpressionsExampleRegion3, new ElementSize(50f, ElementSizeUnit.Pixels));
                }
                return _bindingExpressionsExampleRegion3;
            }
        }

        private static Template _bindingExpressionsExampleRegion4;
        public static Template BindingExpressionsExampleRegion4
        {
            get
            {
#if UNITY_EDITOR
                if (_bindingExpressionsExampleRegion4 == null || _bindingExpressionsExampleRegion4.CurrentVersion != Template.Version)
#else
                if (_bindingExpressionsExampleRegion4 == null)
#endif
                {
                    _bindingExpressionsExampleRegion4 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _bindingExpressionsExampleRegion4.Name = "BindingExpressionsExampleRegion4";
#endif
                    Delight.Region.BackgroundColorProperty.SetDefault(_bindingExpressionsExampleRegion4, new UnityEngine.Color(1f, 1f, 0f, 1f));
                    Delight.Region.IsVisibleProperty.SetHasBinding(_bindingExpressionsExampleRegion4);
                }
                return _bindingExpressionsExampleRegion4;
            }
        }

        private static Template _bindingExpressionsExampleLabel2;
        public static Template BindingExpressionsExampleLabel2
        {
            get
            {
#if UNITY_EDITOR
                if (_bindingExpressionsExampleLabel2 == null || _bindingExpressionsExampleLabel2.CurrentVersion != Template.Version)
#else
                if (_bindingExpressionsExampleLabel2 == null)
#endif
                {
                    _bindingExpressionsExampleLabel2 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _bindingExpressionsExampleLabel2.Name = "BindingExpressionsExampleLabel2";
#endif
                    Delight.Label.TextProperty.SetDefault(_bindingExpressionsExampleLabel2, "> 5");
                    Delight.Label.AutoSizeProperty.SetDefault(_bindingExpressionsExampleLabel2, Delight.AutoSize.Default);
                }
                return _bindingExpressionsExampleLabel2;
            }
        }

        private static Template _bindingExpressionsExampleRegion5;
        public static Template BindingExpressionsExampleRegion5
        {
            get
            {
#if UNITY_EDITOR
                if (_bindingExpressionsExampleRegion5 == null || _bindingExpressionsExampleRegion5.CurrentVersion != Template.Version)
#else
                if (_bindingExpressionsExampleRegion5 == null)
#endif
                {
                    _bindingExpressionsExampleRegion5 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _bindingExpressionsExampleRegion5.Name = "BindingExpressionsExampleRegion5";
#endif
                    Delight.Region.BackgroundColorProperty.SetDefault(_bindingExpressionsExampleRegion5, new UnityEngine.Color(0f, 0f, 1f, 1f));
                    Delight.Region.WidthProperty.SetDefault(_bindingExpressionsExampleRegion5, new ElementSize(50f, ElementSizeUnit.Pixels));
                    Delight.Region.HeightProperty.SetDefault(_bindingExpressionsExampleRegion5, new ElementSize(50f, ElementSizeUnit.Pixels));
                }
                return _bindingExpressionsExampleRegion5;
            }
        }

        private static Template _bindingExpressionsExampleRegion6;
        public static Template BindingExpressionsExampleRegion6
        {
            get
            {
#if UNITY_EDITOR
                if (_bindingExpressionsExampleRegion6 == null || _bindingExpressionsExampleRegion6.CurrentVersion != Template.Version)
#else
                if (_bindingExpressionsExampleRegion6 == null)
#endif
                {
                    _bindingExpressionsExampleRegion6 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _bindingExpressionsExampleRegion6.Name = "BindingExpressionsExampleRegion6";
#endif
                    Delight.Region.BackgroundColorProperty.SetDefault(_bindingExpressionsExampleRegion6, new UnityEngine.Color(1f, 1f, 0f, 1f));
                    Delight.Region.IsVisibleProperty.SetHasBinding(_bindingExpressionsExampleRegion6);
                }
                return _bindingExpressionsExampleRegion6;
            }
        }

        private static Template _bindingExpressionsExampleLabel3;
        public static Template BindingExpressionsExampleLabel3
        {
            get
            {
#if UNITY_EDITOR
                if (_bindingExpressionsExampleLabel3 == null || _bindingExpressionsExampleLabel3.CurrentVersion != Template.Version)
#else
                if (_bindingExpressionsExampleLabel3 == null)
#endif
                {
                    _bindingExpressionsExampleLabel3 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _bindingExpressionsExampleLabel3.Name = "BindingExpressionsExampleLabel3";
#endif
                    Delight.Label.TextProperty.SetDefault(_bindingExpressionsExampleLabel3, "> 10");
                    Delight.Label.AutoSizeProperty.SetDefault(_bindingExpressionsExampleLabel3, Delight.AutoSize.Default);
                }
                return _bindingExpressionsExampleLabel3;
            }
        }

        private static Template _bindingExpressionsExampleGroup3;
        public static Template BindingExpressionsExampleGroup3
        {
            get
            {
#if UNITY_EDITOR
                if (_bindingExpressionsExampleGroup3 == null || _bindingExpressionsExampleGroup3.CurrentVersion != Template.Version)
#else
                if (_bindingExpressionsExampleGroup3 == null)
#endif
                {
                    _bindingExpressionsExampleGroup3 = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _bindingExpressionsExampleGroup3.Name = "BindingExpressionsExampleGroup3";
#endif
                    Delight.Group.SpacingProperty.SetDefault(_bindingExpressionsExampleGroup3, new ElementSize(5f, ElementSizeUnit.Pixels));
                }
                return _bindingExpressionsExampleGroup3;
            }
        }

        private static Template _bindingExpressionsExampleGroup4;
        public static Template BindingExpressionsExampleGroup4
        {
            get
            {
#if UNITY_EDITOR
                if (_bindingExpressionsExampleGroup4 == null || _bindingExpressionsExampleGroup4.CurrentVersion != Template.Version)
#else
                if (_bindingExpressionsExampleGroup4 == null)
#endif
                {
                    _bindingExpressionsExampleGroup4 = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _bindingExpressionsExampleGroup4.Name = "BindingExpressionsExampleGroup4";
#endif
                    Delight.Group.OrientationProperty.SetDefault(_bindingExpressionsExampleGroup4, Delight.ElementOrientation.Horizontal);
                    Delight.Group.SpacingProperty.SetDefault(_bindingExpressionsExampleGroup4, new ElementSize(5f, ElementSizeUnit.Pixels));
                }
                return _bindingExpressionsExampleGroup4;
            }
        }

        private static Template _bindingExpressionsExampleButton1;
        public static Template BindingExpressionsExampleButton1
        {
            get
            {
#if UNITY_EDITOR
                if (_bindingExpressionsExampleButton1 == null || _bindingExpressionsExampleButton1.CurrentVersion != Template.Version)
#else
                if (_bindingExpressionsExampleButton1 == null)
#endif
                {
                    _bindingExpressionsExampleButton1 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _bindingExpressionsExampleButton1.Name = "BindingExpressionsExampleButton1";
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_bindingExpressionsExampleButton1, BindingExpressionsExampleButton1Label);
                }
                return _bindingExpressionsExampleButton1;
            }
        }

        private static Template _bindingExpressionsExampleButton1Label;
        public static Template BindingExpressionsExampleButton1Label
        {
            get
            {
#if UNITY_EDITOR
                if (_bindingExpressionsExampleButton1Label == null || _bindingExpressionsExampleButton1Label.CurrentVersion != Template.Version)
#else
                if (_bindingExpressionsExampleButton1Label == null)
#endif
                {
                    _bindingExpressionsExampleButton1Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _bindingExpressionsExampleButton1Label.Name = "BindingExpressionsExampleButton1Label";
#endif
                    Delight.Label.TextProperty.SetDefault(_bindingExpressionsExampleButton1Label, "Click Me");
                }
                return _bindingExpressionsExampleButton1Label;
            }
        }

        private static Template _bindingExpressionsExampleButton2;
        public static Template BindingExpressionsExampleButton2
        {
            get
            {
#if UNITY_EDITOR
                if (_bindingExpressionsExampleButton2 == null || _bindingExpressionsExampleButton2.CurrentVersion != Template.Version)
#else
                if (_bindingExpressionsExampleButton2 == null)
#endif
                {
                    _bindingExpressionsExampleButton2 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _bindingExpressionsExampleButton2.Name = "BindingExpressionsExampleButton2";
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_bindingExpressionsExampleButton2, BindingExpressionsExampleButton2Label);
                }
                return _bindingExpressionsExampleButton2;
            }
        }

        private static Template _bindingExpressionsExampleButton2Label;
        public static Template BindingExpressionsExampleButton2Label
        {
            get
            {
#if UNITY_EDITOR
                if (_bindingExpressionsExampleButton2Label == null || _bindingExpressionsExampleButton2Label.CurrentVersion != Template.Version)
#else
                if (_bindingExpressionsExampleButton2Label == null)
#endif
                {
                    _bindingExpressionsExampleButton2Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _bindingExpressionsExampleButton2Label.Name = "BindingExpressionsExampleButton2Label";
#endif
                    Delight.Label.TextProperty.SetDefault(_bindingExpressionsExampleButton2Label, "Reset");
                }
                return _bindingExpressionsExampleButton2Label;
            }
        }

        private static Template _bindingExpressionsExampleLabel4;
        public static Template BindingExpressionsExampleLabel4
        {
            get
            {
#if UNITY_EDITOR
                if (_bindingExpressionsExampleLabel4 == null || _bindingExpressionsExampleLabel4.CurrentVersion != Template.Version)
#else
                if (_bindingExpressionsExampleLabel4 == null)
#endif
                {
                    _bindingExpressionsExampleLabel4 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _bindingExpressionsExampleLabel4.Name = "BindingExpressionsExampleLabel4";
#endif
                    Delight.Label.AutoSizeProperty.SetDefault(_bindingExpressionsExampleLabel4, Delight.AutoSize.Default);
                    Delight.Label.FontColorProperty.SetDefault(_bindingExpressionsExampleLabel4, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Label.TextProperty.SetHasBinding(_bindingExpressionsExampleLabel4);
                }
                return _bindingExpressionsExampleLabel4;
            }
        }

        private static Template _bindingExpressionsExampleGroup5;
        public static Template BindingExpressionsExampleGroup5
        {
            get
            {
#if UNITY_EDITOR
                if (_bindingExpressionsExampleGroup5 == null || _bindingExpressionsExampleGroup5.CurrentVersion != Template.Version)
#else
                if (_bindingExpressionsExampleGroup5 == null)
#endif
                {
                    _bindingExpressionsExampleGroup5 = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _bindingExpressionsExampleGroup5.Name = "BindingExpressionsExampleGroup5";
#endif
                    Delight.Group.OrientationProperty.SetDefault(_bindingExpressionsExampleGroup5, Delight.ElementOrientation.Horizontal);
                }
                return _bindingExpressionsExampleGroup5;
            }
        }

        private static Template _bindingExpressionsExampleLabel5;
        public static Template BindingExpressionsExampleLabel5
        {
            get
            {
#if UNITY_EDITOR
                if (_bindingExpressionsExampleLabel5 == null || _bindingExpressionsExampleLabel5.CurrentVersion != Template.Version)
#else
                if (_bindingExpressionsExampleLabel5 == null)
#endif
                {
                    _bindingExpressionsExampleLabel5 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _bindingExpressionsExampleLabel5.Name = "BindingExpressionsExampleLabel5";
#endif
                    Delight.Label.AutoSizeProperty.SetDefault(_bindingExpressionsExampleLabel5, Delight.AutoSize.Default);
                    Delight.Label.FontColorProperty.SetDefault(_bindingExpressionsExampleLabel5, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Label.TextProperty.SetHasBinding(_bindingExpressionsExampleLabel5);
                }
                return _bindingExpressionsExampleLabel5;
            }
        }

        private static Template _bindingExpressionsExampleLabel6;
        public static Template BindingExpressionsExampleLabel6
        {
            get
            {
#if UNITY_EDITOR
                if (_bindingExpressionsExampleLabel6 == null || _bindingExpressionsExampleLabel6.CurrentVersion != Template.Version)
#else
                if (_bindingExpressionsExampleLabel6 == null)
#endif
                {
                    _bindingExpressionsExampleLabel6 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _bindingExpressionsExampleLabel6.Name = "BindingExpressionsExampleLabel6";
#endif
                    Delight.Label.AutoSizeProperty.SetDefault(_bindingExpressionsExampleLabel6, Delight.AutoSize.Default);
                    Delight.Label.FontColorProperty.SetDefault(_bindingExpressionsExampleLabel6, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Label.TextProperty.SetHasBinding(_bindingExpressionsExampleLabel6);
                }
                return _bindingExpressionsExampleLabel6;
            }
        }

        #endregion
    }

    #endregion
}
