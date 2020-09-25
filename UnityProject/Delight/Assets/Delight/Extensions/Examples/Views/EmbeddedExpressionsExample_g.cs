// Internal view logic generated from "EmbeddedExpressionsExample.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class EmbeddedExpressionsExample : LayoutRoot
    {
        #region Constructors

        public EmbeddedExpressionsExample(View parent, View layoutParent = null, string id = null, Template template = null, bool deferInitialization = false) :
            base(parent, layoutParent, id, template ?? EmbeddedExpressionsExampleTemplates.Default, deferInitialization)
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

        public EmbeddedExpressionsExample() : this(null)
        {
        }

        static EmbeddedExpressionsExample()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(EmbeddedExpressionsExampleTemplates.Default, dependencyProperties);

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

    public static class EmbeddedExpressionsExampleTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return EmbeddedExpressionsExample;
            }
        }

        private static Template _embeddedExpressionsExample;
        public static Template EmbeddedExpressionsExample
        {
            get
            {
#if UNITY_EDITOR
                if (_embeddedExpressionsExample == null || _embeddedExpressionsExample.CurrentVersion != Template.Version)
#else
                if (_embeddedExpressionsExample == null)
#endif
                {
                    _embeddedExpressionsExample = new Template(LayoutRootTemplates.LayoutRoot);
#if UNITY_EDITOR
                    _embeddedExpressionsExample.Name = "EmbeddedExpressionsExample";
                    _embeddedExpressionsExample.LineNumber = 0;
                    _embeddedExpressionsExample.LinePosition = 0;
#endif
                    Delight.EmbeddedExpressionsExample.Group1TemplateProperty.SetDefault(_embeddedExpressionsExample, EmbeddedExpressionsExampleGroup1);
                    Delight.EmbeddedExpressionsExample.Group2TemplateProperty.SetDefault(_embeddedExpressionsExample, EmbeddedExpressionsExampleGroup2);
                    Delight.EmbeddedExpressionsExample.Region1TemplateProperty.SetDefault(_embeddedExpressionsExample, EmbeddedExpressionsExampleRegion1);
                    Delight.EmbeddedExpressionsExample.Region2TemplateProperty.SetDefault(_embeddedExpressionsExample, EmbeddedExpressionsExampleRegion2);
                    Delight.EmbeddedExpressionsExample.Label1TemplateProperty.SetDefault(_embeddedExpressionsExample, EmbeddedExpressionsExampleLabel1);
                    Delight.EmbeddedExpressionsExample.Region3TemplateProperty.SetDefault(_embeddedExpressionsExample, EmbeddedExpressionsExampleRegion3);
                    Delight.EmbeddedExpressionsExample.Region4TemplateProperty.SetDefault(_embeddedExpressionsExample, EmbeddedExpressionsExampleRegion4);
                    Delight.EmbeddedExpressionsExample.Label2TemplateProperty.SetDefault(_embeddedExpressionsExample, EmbeddedExpressionsExampleLabel2);
                    Delight.EmbeddedExpressionsExample.Region5TemplateProperty.SetDefault(_embeddedExpressionsExample, EmbeddedExpressionsExampleRegion5);
                    Delight.EmbeddedExpressionsExample.Region6TemplateProperty.SetDefault(_embeddedExpressionsExample, EmbeddedExpressionsExampleRegion6);
                    Delight.EmbeddedExpressionsExample.Label3TemplateProperty.SetDefault(_embeddedExpressionsExample, EmbeddedExpressionsExampleLabel3);
                    Delight.EmbeddedExpressionsExample.Group3TemplateProperty.SetDefault(_embeddedExpressionsExample, EmbeddedExpressionsExampleGroup3);
                    Delight.EmbeddedExpressionsExample.Group4TemplateProperty.SetDefault(_embeddedExpressionsExample, EmbeddedExpressionsExampleGroup4);
                    Delight.EmbeddedExpressionsExample.Button1TemplateProperty.SetDefault(_embeddedExpressionsExample, EmbeddedExpressionsExampleButton1);
                    Delight.EmbeddedExpressionsExample.Button2TemplateProperty.SetDefault(_embeddedExpressionsExample, EmbeddedExpressionsExampleButton2);
                    Delight.EmbeddedExpressionsExample.Label4TemplateProperty.SetDefault(_embeddedExpressionsExample, EmbeddedExpressionsExampleLabel4);
                    Delight.EmbeddedExpressionsExample.Group5TemplateProperty.SetDefault(_embeddedExpressionsExample, EmbeddedExpressionsExampleGroup5);
                    Delight.EmbeddedExpressionsExample.Label5TemplateProperty.SetDefault(_embeddedExpressionsExample, EmbeddedExpressionsExampleLabel5);
                    Delight.EmbeddedExpressionsExample.Label6TemplateProperty.SetDefault(_embeddedExpressionsExample, EmbeddedExpressionsExampleLabel6);
                }
                return _embeddedExpressionsExample;
            }
        }

        private static Template _embeddedExpressionsExampleGroup1;
        public static Template EmbeddedExpressionsExampleGroup1
        {
            get
            {
#if UNITY_EDITOR
                if (_embeddedExpressionsExampleGroup1 == null || _embeddedExpressionsExampleGroup1.CurrentVersion != Template.Version)
#else
                if (_embeddedExpressionsExampleGroup1 == null)
#endif
                {
                    _embeddedExpressionsExampleGroup1 = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _embeddedExpressionsExampleGroup1.Name = "EmbeddedExpressionsExampleGroup1";
                    _embeddedExpressionsExampleGroup1.LineNumber = 4;
                    _embeddedExpressionsExampleGroup1.LinePosition = 4;
#endif
                    Delight.Group.SpacingProperty.SetDefault(_embeddedExpressionsExampleGroup1, new ElementSize(10f, ElementSizeUnit.Pixels));
                }
                return _embeddedExpressionsExampleGroup1;
            }
        }

        private static Template _embeddedExpressionsExampleGroup2;
        public static Template EmbeddedExpressionsExampleGroup2
        {
            get
            {
#if UNITY_EDITOR
                if (_embeddedExpressionsExampleGroup2 == null || _embeddedExpressionsExampleGroup2.CurrentVersion != Template.Version)
#else
                if (_embeddedExpressionsExampleGroup2 == null)
#endif
                {
                    _embeddedExpressionsExampleGroup2 = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _embeddedExpressionsExampleGroup2.Name = "EmbeddedExpressionsExampleGroup2";
                    _embeddedExpressionsExampleGroup2.LineNumber = 6;
                    _embeddedExpressionsExampleGroup2.LinePosition = 6;
#endif
                    Delight.Group.OrientationProperty.SetDefault(_embeddedExpressionsExampleGroup2, Delight.ElementOrientation.Horizontal);
                    Delight.Group.SpacingProperty.SetDefault(_embeddedExpressionsExampleGroup2, new ElementSize(5f, ElementSizeUnit.Pixels));
                }
                return _embeddedExpressionsExampleGroup2;
            }
        }

        private static Template _embeddedExpressionsExampleRegion1;
        public static Template EmbeddedExpressionsExampleRegion1
        {
            get
            {
#if UNITY_EDITOR
                if (_embeddedExpressionsExampleRegion1 == null || _embeddedExpressionsExampleRegion1.CurrentVersion != Template.Version)
#else
                if (_embeddedExpressionsExampleRegion1 == null)
#endif
                {
                    _embeddedExpressionsExampleRegion1 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _embeddedExpressionsExampleRegion1.Name = "EmbeddedExpressionsExampleRegion1";
                    _embeddedExpressionsExampleRegion1.LineNumber = 7;
                    _embeddedExpressionsExampleRegion1.LinePosition = 8;
#endif
                    Delight.Region.BackgroundColorProperty.SetDefault(_embeddedExpressionsExampleRegion1, new UnityEngine.Color(0f, 0f, 1f, 1f));
                    Delight.Region.WidthProperty.SetDefault(_embeddedExpressionsExampleRegion1, new ElementSize(50f, ElementSizeUnit.Pixels));
                    Delight.Region.HeightProperty.SetDefault(_embeddedExpressionsExampleRegion1, new ElementSize(50f, ElementSizeUnit.Pixels));
                }
                return _embeddedExpressionsExampleRegion1;
            }
        }

        private static Template _embeddedExpressionsExampleRegion2;
        public static Template EmbeddedExpressionsExampleRegion2
        {
            get
            {
#if UNITY_EDITOR
                if (_embeddedExpressionsExampleRegion2 == null || _embeddedExpressionsExampleRegion2.CurrentVersion != Template.Version)
#else
                if (_embeddedExpressionsExampleRegion2 == null)
#endif
                {
                    _embeddedExpressionsExampleRegion2 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _embeddedExpressionsExampleRegion2.Name = "EmbeddedExpressionsExampleRegion2";
                    _embeddedExpressionsExampleRegion2.LineNumber = 8;
                    _embeddedExpressionsExampleRegion2.LinePosition = 10;
#endif
                    Delight.Region.BackgroundColorProperty.SetDefault(_embeddedExpressionsExampleRegion2, new UnityEngine.Color(1f, 1f, 0f, 1f));
                    Delight.Region.IsVisibleProperty.SetHasBinding(_embeddedExpressionsExampleRegion2);
                }
                return _embeddedExpressionsExampleRegion2;
            }
        }

        private static Template _embeddedExpressionsExampleLabel1;
        public static Template EmbeddedExpressionsExampleLabel1
        {
            get
            {
#if UNITY_EDITOR
                if (_embeddedExpressionsExampleLabel1 == null || _embeddedExpressionsExampleLabel1.CurrentVersion != Template.Version)
#else
                if (_embeddedExpressionsExampleLabel1 == null)
#endif
                {
                    _embeddedExpressionsExampleLabel1 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _embeddedExpressionsExampleLabel1.Name = "EmbeddedExpressionsExampleLabel1";
                    _embeddedExpressionsExampleLabel1.LineNumber = 9;
                    _embeddedExpressionsExampleLabel1.LinePosition = 10;
#endif
                    Delight.Label.TextProperty.SetDefault(_embeddedExpressionsExampleLabel1, "> 0");
                    Delight.Label.AutoSizeProperty.SetDefault(_embeddedExpressionsExampleLabel1, Delight.AutoSize.Default);
                }
                return _embeddedExpressionsExampleLabel1;
            }
        }

        private static Template _embeddedExpressionsExampleRegion3;
        public static Template EmbeddedExpressionsExampleRegion3
        {
            get
            {
#if UNITY_EDITOR
                if (_embeddedExpressionsExampleRegion3 == null || _embeddedExpressionsExampleRegion3.CurrentVersion != Template.Version)
#else
                if (_embeddedExpressionsExampleRegion3 == null)
#endif
                {
                    _embeddedExpressionsExampleRegion3 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _embeddedExpressionsExampleRegion3.Name = "EmbeddedExpressionsExampleRegion3";
                    _embeddedExpressionsExampleRegion3.LineNumber = 11;
                    _embeddedExpressionsExampleRegion3.LinePosition = 8;
#endif
                    Delight.Region.BackgroundColorProperty.SetDefault(_embeddedExpressionsExampleRegion3, new UnityEngine.Color(0f, 0f, 1f, 1f));
                    Delight.Region.WidthProperty.SetDefault(_embeddedExpressionsExampleRegion3, new ElementSize(50f, ElementSizeUnit.Pixels));
                    Delight.Region.HeightProperty.SetDefault(_embeddedExpressionsExampleRegion3, new ElementSize(50f, ElementSizeUnit.Pixels));
                }
                return _embeddedExpressionsExampleRegion3;
            }
        }

        private static Template _embeddedExpressionsExampleRegion4;
        public static Template EmbeddedExpressionsExampleRegion4
        {
            get
            {
#if UNITY_EDITOR
                if (_embeddedExpressionsExampleRegion4 == null || _embeddedExpressionsExampleRegion4.CurrentVersion != Template.Version)
#else
                if (_embeddedExpressionsExampleRegion4 == null)
#endif
                {
                    _embeddedExpressionsExampleRegion4 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _embeddedExpressionsExampleRegion4.Name = "EmbeddedExpressionsExampleRegion4";
                    _embeddedExpressionsExampleRegion4.LineNumber = 12;
                    _embeddedExpressionsExampleRegion4.LinePosition = 10;
#endif
                    Delight.Region.BackgroundColorProperty.SetDefault(_embeddedExpressionsExampleRegion4, new UnityEngine.Color(1f, 1f, 0f, 1f));
                    Delight.Region.IsVisibleProperty.SetHasBinding(_embeddedExpressionsExampleRegion4);
                }
                return _embeddedExpressionsExampleRegion4;
            }
        }

        private static Template _embeddedExpressionsExampleLabel2;
        public static Template EmbeddedExpressionsExampleLabel2
        {
            get
            {
#if UNITY_EDITOR
                if (_embeddedExpressionsExampleLabel2 == null || _embeddedExpressionsExampleLabel2.CurrentVersion != Template.Version)
#else
                if (_embeddedExpressionsExampleLabel2 == null)
#endif
                {
                    _embeddedExpressionsExampleLabel2 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _embeddedExpressionsExampleLabel2.Name = "EmbeddedExpressionsExampleLabel2";
                    _embeddedExpressionsExampleLabel2.LineNumber = 13;
                    _embeddedExpressionsExampleLabel2.LinePosition = 10;
#endif
                    Delight.Label.TextProperty.SetDefault(_embeddedExpressionsExampleLabel2, "> 5");
                    Delight.Label.AutoSizeProperty.SetDefault(_embeddedExpressionsExampleLabel2, Delight.AutoSize.Default);
                }
                return _embeddedExpressionsExampleLabel2;
            }
        }

        private static Template _embeddedExpressionsExampleRegion5;
        public static Template EmbeddedExpressionsExampleRegion5
        {
            get
            {
#if UNITY_EDITOR
                if (_embeddedExpressionsExampleRegion5 == null || _embeddedExpressionsExampleRegion5.CurrentVersion != Template.Version)
#else
                if (_embeddedExpressionsExampleRegion5 == null)
#endif
                {
                    _embeddedExpressionsExampleRegion5 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _embeddedExpressionsExampleRegion5.Name = "EmbeddedExpressionsExampleRegion5";
                    _embeddedExpressionsExampleRegion5.LineNumber = 15;
                    _embeddedExpressionsExampleRegion5.LinePosition = 8;
#endif
                    Delight.Region.BackgroundColorProperty.SetDefault(_embeddedExpressionsExampleRegion5, new UnityEngine.Color(0f, 0f, 1f, 1f));
                    Delight.Region.WidthProperty.SetDefault(_embeddedExpressionsExampleRegion5, new ElementSize(50f, ElementSizeUnit.Pixels));
                    Delight.Region.HeightProperty.SetDefault(_embeddedExpressionsExampleRegion5, new ElementSize(50f, ElementSizeUnit.Pixels));
                }
                return _embeddedExpressionsExampleRegion5;
            }
        }

        private static Template _embeddedExpressionsExampleRegion6;
        public static Template EmbeddedExpressionsExampleRegion6
        {
            get
            {
#if UNITY_EDITOR
                if (_embeddedExpressionsExampleRegion6 == null || _embeddedExpressionsExampleRegion6.CurrentVersion != Template.Version)
#else
                if (_embeddedExpressionsExampleRegion6 == null)
#endif
                {
                    _embeddedExpressionsExampleRegion6 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _embeddedExpressionsExampleRegion6.Name = "EmbeddedExpressionsExampleRegion6";
                    _embeddedExpressionsExampleRegion6.LineNumber = 16;
                    _embeddedExpressionsExampleRegion6.LinePosition = 10;
#endif
                    Delight.Region.BackgroundColorProperty.SetDefault(_embeddedExpressionsExampleRegion6, new UnityEngine.Color(1f, 1f, 0f, 1f));
                    Delight.Region.IsVisibleProperty.SetHasBinding(_embeddedExpressionsExampleRegion6);
                }
                return _embeddedExpressionsExampleRegion6;
            }
        }

        private static Template _embeddedExpressionsExampleLabel3;
        public static Template EmbeddedExpressionsExampleLabel3
        {
            get
            {
#if UNITY_EDITOR
                if (_embeddedExpressionsExampleLabel3 == null || _embeddedExpressionsExampleLabel3.CurrentVersion != Template.Version)
#else
                if (_embeddedExpressionsExampleLabel3 == null)
#endif
                {
                    _embeddedExpressionsExampleLabel3 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _embeddedExpressionsExampleLabel3.Name = "EmbeddedExpressionsExampleLabel3";
                    _embeddedExpressionsExampleLabel3.LineNumber = 17;
                    _embeddedExpressionsExampleLabel3.LinePosition = 10;
#endif
                    Delight.Label.TextProperty.SetDefault(_embeddedExpressionsExampleLabel3, "> 10");
                    Delight.Label.AutoSizeProperty.SetDefault(_embeddedExpressionsExampleLabel3, Delight.AutoSize.Default);
                }
                return _embeddedExpressionsExampleLabel3;
            }
        }

        private static Template _embeddedExpressionsExampleGroup3;
        public static Template EmbeddedExpressionsExampleGroup3
        {
            get
            {
#if UNITY_EDITOR
                if (_embeddedExpressionsExampleGroup3 == null || _embeddedExpressionsExampleGroup3.CurrentVersion != Template.Version)
#else
                if (_embeddedExpressionsExampleGroup3 == null)
#endif
                {
                    _embeddedExpressionsExampleGroup3 = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _embeddedExpressionsExampleGroup3.Name = "EmbeddedExpressionsExampleGroup3";
                    _embeddedExpressionsExampleGroup3.LineNumber = 21;
                    _embeddedExpressionsExampleGroup3.LinePosition = 6;
#endif
                    Delight.Group.SpacingProperty.SetDefault(_embeddedExpressionsExampleGroup3, new ElementSize(5f, ElementSizeUnit.Pixels));
                }
                return _embeddedExpressionsExampleGroup3;
            }
        }

        private static Template _embeddedExpressionsExampleGroup4;
        public static Template EmbeddedExpressionsExampleGroup4
        {
            get
            {
#if UNITY_EDITOR
                if (_embeddedExpressionsExampleGroup4 == null || _embeddedExpressionsExampleGroup4.CurrentVersion != Template.Version)
#else
                if (_embeddedExpressionsExampleGroup4 == null)
#endif
                {
                    _embeddedExpressionsExampleGroup4 = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _embeddedExpressionsExampleGroup4.Name = "EmbeddedExpressionsExampleGroup4";
                    _embeddedExpressionsExampleGroup4.LineNumber = 22;
                    _embeddedExpressionsExampleGroup4.LinePosition = 8;
#endif
                    Delight.Group.OrientationProperty.SetDefault(_embeddedExpressionsExampleGroup4, Delight.ElementOrientation.Horizontal);
                    Delight.Group.SpacingProperty.SetDefault(_embeddedExpressionsExampleGroup4, new ElementSize(5f, ElementSizeUnit.Pixels));
                }
                return _embeddedExpressionsExampleGroup4;
            }
        }

        private static Template _embeddedExpressionsExampleButton1;
        public static Template EmbeddedExpressionsExampleButton1
        {
            get
            {
#if UNITY_EDITOR
                if (_embeddedExpressionsExampleButton1 == null || _embeddedExpressionsExampleButton1.CurrentVersion != Template.Version)
#else
                if (_embeddedExpressionsExampleButton1 == null)
#endif
                {
                    _embeddedExpressionsExampleButton1 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _embeddedExpressionsExampleButton1.Name = "EmbeddedExpressionsExampleButton1";
                    _embeddedExpressionsExampleButton1.LineNumber = 23;
                    _embeddedExpressionsExampleButton1.LinePosition = 10;
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_embeddedExpressionsExampleButton1, EmbeddedExpressionsExampleButton1Label);
                }
                return _embeddedExpressionsExampleButton1;
            }
        }

        private static Template _embeddedExpressionsExampleButton1Label;
        public static Template EmbeddedExpressionsExampleButton1Label
        {
            get
            {
#if UNITY_EDITOR
                if (_embeddedExpressionsExampleButton1Label == null || _embeddedExpressionsExampleButton1Label.CurrentVersion != Template.Version)
#else
                if (_embeddedExpressionsExampleButton1Label == null)
#endif
                {
                    _embeddedExpressionsExampleButton1Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _embeddedExpressionsExampleButton1Label.Name = "EmbeddedExpressionsExampleButton1Label";
                    _embeddedExpressionsExampleButton1Label.LineNumber = 15;
                    _embeddedExpressionsExampleButton1Label.LinePosition = 4;
#endif
                    Delight.Label.TextProperty.SetDefault(_embeddedExpressionsExampleButton1Label, "Click Me");
                }
                return _embeddedExpressionsExampleButton1Label;
            }
        }

        private static Template _embeddedExpressionsExampleButton2;
        public static Template EmbeddedExpressionsExampleButton2
        {
            get
            {
#if UNITY_EDITOR
                if (_embeddedExpressionsExampleButton2 == null || _embeddedExpressionsExampleButton2.CurrentVersion != Template.Version)
#else
                if (_embeddedExpressionsExampleButton2 == null)
#endif
                {
                    _embeddedExpressionsExampleButton2 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _embeddedExpressionsExampleButton2.Name = "EmbeddedExpressionsExampleButton2";
                    _embeddedExpressionsExampleButton2.LineNumber = 24;
                    _embeddedExpressionsExampleButton2.LinePosition = 10;
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_embeddedExpressionsExampleButton2, EmbeddedExpressionsExampleButton2Label);
                }
                return _embeddedExpressionsExampleButton2;
            }
        }

        private static Template _embeddedExpressionsExampleButton2Label;
        public static Template EmbeddedExpressionsExampleButton2Label
        {
            get
            {
#if UNITY_EDITOR
                if (_embeddedExpressionsExampleButton2Label == null || _embeddedExpressionsExampleButton2Label.CurrentVersion != Template.Version)
#else
                if (_embeddedExpressionsExampleButton2Label == null)
#endif
                {
                    _embeddedExpressionsExampleButton2Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _embeddedExpressionsExampleButton2Label.Name = "EmbeddedExpressionsExampleButton2Label";
                    _embeddedExpressionsExampleButton2Label.LineNumber = 15;
                    _embeddedExpressionsExampleButton2Label.LinePosition = 4;
#endif
                    Delight.Label.TextProperty.SetDefault(_embeddedExpressionsExampleButton2Label, "Reset");
                }
                return _embeddedExpressionsExampleButton2Label;
            }
        }

        private static Template _embeddedExpressionsExampleLabel4;
        public static Template EmbeddedExpressionsExampleLabel4
        {
            get
            {
#if UNITY_EDITOR
                if (_embeddedExpressionsExampleLabel4 == null || _embeddedExpressionsExampleLabel4.CurrentVersion != Template.Version)
#else
                if (_embeddedExpressionsExampleLabel4 == null)
#endif
                {
                    _embeddedExpressionsExampleLabel4 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _embeddedExpressionsExampleLabel4.Name = "EmbeddedExpressionsExampleLabel4";
                    _embeddedExpressionsExampleLabel4.LineNumber = 26;
                    _embeddedExpressionsExampleLabel4.LinePosition = 8;
#endif
                    Delight.Label.AutoSizeProperty.SetDefault(_embeddedExpressionsExampleLabel4, Delight.AutoSize.Default);
                    Delight.Label.FontColorProperty.SetDefault(_embeddedExpressionsExampleLabel4, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Label.TextProperty.SetHasBinding(_embeddedExpressionsExampleLabel4);
                }
                return _embeddedExpressionsExampleLabel4;
            }
        }

        private static Template _embeddedExpressionsExampleGroup5;
        public static Template EmbeddedExpressionsExampleGroup5
        {
            get
            {
#if UNITY_EDITOR
                if (_embeddedExpressionsExampleGroup5 == null || _embeddedExpressionsExampleGroup5.CurrentVersion != Template.Version)
#else
                if (_embeddedExpressionsExampleGroup5 == null)
#endif
                {
                    _embeddedExpressionsExampleGroup5 = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _embeddedExpressionsExampleGroup5.Name = "EmbeddedExpressionsExampleGroup5";
                    _embeddedExpressionsExampleGroup5.LineNumber = 27;
                    _embeddedExpressionsExampleGroup5.LinePosition = 8;
#endif
                    Delight.Group.OrientationProperty.SetDefault(_embeddedExpressionsExampleGroup5, Delight.ElementOrientation.Horizontal);
                }
                return _embeddedExpressionsExampleGroup5;
            }
        }

        private static Template _embeddedExpressionsExampleLabel5;
        public static Template EmbeddedExpressionsExampleLabel5
        {
            get
            {
#if UNITY_EDITOR
                if (_embeddedExpressionsExampleLabel5 == null || _embeddedExpressionsExampleLabel5.CurrentVersion != Template.Version)
#else
                if (_embeddedExpressionsExampleLabel5 == null)
#endif
                {
                    _embeddedExpressionsExampleLabel5 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _embeddedExpressionsExampleLabel5.Name = "EmbeddedExpressionsExampleLabel5";
                    _embeddedExpressionsExampleLabel5.LineNumber = 28;
                    _embeddedExpressionsExampleLabel5.LinePosition = 10;
#endif
                    Delight.Label.AutoSizeProperty.SetDefault(_embeddedExpressionsExampleLabel5, Delight.AutoSize.Default);
                    Delight.Label.FontColorProperty.SetDefault(_embeddedExpressionsExampleLabel5, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Label.TextProperty.SetHasBinding(_embeddedExpressionsExampleLabel5);
                }
                return _embeddedExpressionsExampleLabel5;
            }
        }

        private static Template _embeddedExpressionsExampleLabel6;
        public static Template EmbeddedExpressionsExampleLabel6
        {
            get
            {
#if UNITY_EDITOR
                if (_embeddedExpressionsExampleLabel6 == null || _embeddedExpressionsExampleLabel6.CurrentVersion != Template.Version)
#else
                if (_embeddedExpressionsExampleLabel6 == null)
#endif
                {
                    _embeddedExpressionsExampleLabel6 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _embeddedExpressionsExampleLabel6.Name = "EmbeddedExpressionsExampleLabel6";
                    _embeddedExpressionsExampleLabel6.LineNumber = 29;
                    _embeddedExpressionsExampleLabel6.LinePosition = 10;
#endif
                    Delight.Label.AutoSizeProperty.SetDefault(_embeddedExpressionsExampleLabel6, Delight.AutoSize.Default);
                    Delight.Label.FontColorProperty.SetDefault(_embeddedExpressionsExampleLabel6, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Label.TextProperty.SetHasBinding(_embeddedExpressionsExampleLabel6);
                }
                return _embeddedExpressionsExampleLabel6;
            }
        }

        #endregion
    }

    #endregion
}
