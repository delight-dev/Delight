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
            Group3 = new Group(this, Group2.Content, "Group3", Group3Template);
            Button1 = new Button(this, Group3.Content, "Button1", Button1Template);
            Button1.Click.RegisterHandler(this, "ButtonClick");
            Button2 = new Button(this, Group3.Content, "Button2", Button2Template);
            Button2.Click.RegisterHandler(this, "Reset");
            Label1 = new Label(this, Group2.Content, "Label1", Label1Template);

            // binding <Label Text="Click count: {ClickCount}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "ClickCount" }, new List<Func<BindableObject>> { () => this }) }, new BindingPath(new List<string> { "Label1", "Text" }, new List<Func<BindableObject>> { () => this, () => Label1 }), () => Label1.Text = String.Format("Click count: {0}", ClickCount), () => { }, false));
            Label2 = new Label(this, Group2.Content, "Label2", Label2Template);

            // binding <Label Text="$ {ClickCount}.ToString()">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "ClickCount" }, new List<Func<BindableObject>> { () => this }) }, new BindingPath(new List<string> { "Label2", "Text" }, new List<Func<BindableObject>> { () => this, () => Label2 }), () => Label2.Text = ClickCount.ToString(), () => { }, false));
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
            dependencyProperties.Add(Group3Property);
            dependencyProperties.Add(Group3TemplateProperty);
            dependencyProperties.Add(Button1Property);
            dependencyProperties.Add(Button1TemplateProperty);
            dependencyProperties.Add(Button2Property);
            dependencyProperties.Add(Button2TemplateProperty);
            dependencyProperties.Add(Label1Property);
            dependencyProperties.Add(Label1TemplateProperty);
            dependencyProperties.Add(Label2Property);
            dependencyProperties.Add(Label2TemplateProperty);
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
                    Delight.BindingExpressionsExample.Group3TemplateProperty.SetDefault(_bindingExpressionsExample, BindingExpressionsExampleGroup3);
                    Delight.BindingExpressionsExample.Button1TemplateProperty.SetDefault(_bindingExpressionsExample, BindingExpressionsExampleButton1);
                    Delight.BindingExpressionsExample.Button2TemplateProperty.SetDefault(_bindingExpressionsExample, BindingExpressionsExampleButton2);
                    Delight.BindingExpressionsExample.Label1TemplateProperty.SetDefault(_bindingExpressionsExample, BindingExpressionsExampleLabel1);
                    Delight.BindingExpressionsExample.Label2TemplateProperty.SetDefault(_bindingExpressionsExample, BindingExpressionsExampleLabel2);
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
                    Delight.Group.SpacingProperty.SetDefault(_bindingExpressionsExampleGroup2, new ElementSize(5f, ElementSizeUnit.Pixels));
                }
                return _bindingExpressionsExampleGroup2;
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
                    Delight.Group.OrientationProperty.SetDefault(_bindingExpressionsExampleGroup3, Delight.ElementOrientation.Horizontal);
                    Delight.Group.SpacingProperty.SetDefault(_bindingExpressionsExampleGroup3, new ElementSize(5f, ElementSizeUnit.Pixels));
                }
                return _bindingExpressionsExampleGroup3;
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
                    Delight.Label.AutoSizeProperty.SetDefault(_bindingExpressionsExampleLabel1, Delight.AutoSize.Default);
                    Delight.Label.FontColorProperty.SetDefault(_bindingExpressionsExampleLabel1, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Label.TextProperty.SetHasBinding(_bindingExpressionsExampleLabel1);
                }
                return _bindingExpressionsExampleLabel1;
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
                    Delight.Label.AutoSizeProperty.SetDefault(_bindingExpressionsExampleLabel2, Delight.AutoSize.Default);
                    Delight.Label.FontColorProperty.SetDefault(_bindingExpressionsExampleLabel2, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Label.TextProperty.SetHasBinding(_bindingExpressionsExampleLabel2);
                }
                return _bindingExpressionsExampleLabel2;
            }
        }

        #endregion
    }

    #endregion
}
