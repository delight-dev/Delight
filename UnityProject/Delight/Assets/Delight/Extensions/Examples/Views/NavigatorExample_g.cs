// Internal view logic generated from "NavigatorExample.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class NavigatorExample : LayoutRoot
    {
        #region Constructors

        public NavigatorExample(View parent, View layoutParent = null, string id = null, Template template = null, bool deferInitialization = false) :
            base(parent, layoutParent, id, template ?? NavigatorExampleTemplates.Default, deferInitialization)
        {
            if (deferInitialization)
                return;

            // constructing Navigator (Navigator1)
            Navigator1 = new Navigator(this, this, "Navigator1", Navigator1Template);
            Region1 = new Region(this, Navigator1.Content, "Region1", Region1Template);
            Navigator1.Path.SetValue(Region1, "/");
            Region1.StateAnimations.Clear();
            var region1StateAnimation1 = new StateAnimation("Closed", DefaultStateName);
            region1StateAnimation1.Add(new Animator<Delight.ElementMargin>(Region1, 0.85f, 0f, false, false, 0f, false, EasingFunctions.Get("QuadraticEaseOut"), Delight.ElementMarginValueConverter.Interpolator, x => Region1.Offset = x, () => Region1.Offset, () => Region.OffsetProperty.NotifyPropertyChanged(Region1), Region.OffsetProperty, "Closed", DefaultStateName));
            region1StateAnimation1.Add(new Animator<UnityEngine.Vector3>(Region1, 0.85f, 0f, false, false, 0f, false, EasingFunctions.Get("QuadraticEaseOut"), Delight.Vector3ValueConverter.Interpolator, x => Region1.Scale = x, () => Region1.Scale, () => Region.ScaleProperty.NotifyPropertyChanged(Region1), Region.ScaleProperty, "Closed", DefaultStateName));
            Region1.StateAnimations.Add(region1StateAnimation1);
            var region1StateAnimation2 = new StateAnimation(DefaultStateName, "Pushed");
            region1StateAnimation2.Add(new Animator<Delight.ElementMargin>(Region1, 0.85f, 0f, false, false, 0f, false, EasingFunctions.Get("QuadraticEaseOut"), Delight.ElementMarginValueConverter.Interpolator, x => Region1.Offset = x, () => Region1.Offset, () => Region.OffsetProperty.NotifyPropertyChanged(Region1), Region.OffsetProperty, DefaultStateName, "Pushed"));
            region1StateAnimation2.Add(new Animator<UnityEngine.Vector3>(Region1, 0.85f, 0f, false, false, 0f, false, EasingFunctions.Get("QuadraticEaseOut"), Delight.Vector3ValueConverter.Interpolator, x => Region1.Scale = x, () => Region1.Scale, () => Region.ScaleProperty.NotifyPropertyChanged(Region1), Region.ScaleProperty, DefaultStateName, "Pushed"));
            Region1.StateAnimations.Add(region1StateAnimation2);
            var region1StateAnimation3 = new StateAnimation("Pushed", DefaultStateName);
            region1StateAnimation3.Add(new Animator<Delight.ElementMargin>(Region1, 0.85f, 0f, false, false, 0f, false, EasingFunctions.Get("QuadraticEaseOut"), Delight.ElementMarginValueConverter.Interpolator, x => Region1.Offset = x, () => Region1.Offset, () => Region.OffsetProperty.NotifyPropertyChanged(Region1), Region.OffsetProperty, "Pushed", DefaultStateName));
            region1StateAnimation3.Add(new Animator<UnityEngine.Vector3>(Region1, 0.85f, 0f, false, false, 0f, false, EasingFunctions.Get("QuadraticEaseOut"), Delight.Vector3ValueConverter.Interpolator, x => Region1.Scale = x, () => Region1.Scale, () => Region.ScaleProperty.NotifyPropertyChanged(Region1), Region.ScaleProperty, "Pushed", DefaultStateName));
            Region1.StateAnimations.Add(region1StateAnimation3);
            var region1StateAnimation4 = new StateAnimation(DefaultStateName, "Closed");
            region1StateAnimation4.Add(new Animator<Delight.ElementMargin>(Region1, 0.85f, 0f, false, false, 0f, false, EasingFunctions.Get("QuadraticEaseOut"), Delight.ElementMarginValueConverter.Interpolator, x => Region1.Offset = x, () => Region1.Offset, () => Region.OffsetProperty.NotifyPropertyChanged(Region1), Region.OffsetProperty, DefaultStateName, "Closed"));
            region1StateAnimation4.Add(new Animator<UnityEngine.Vector3>(Region1, 0.85f, 0f, false, false, 0f, false, EasingFunctions.Get("QuadraticEaseOut"), Delight.Vector3ValueConverter.Interpolator, x => Region1.Scale = x, () => Region1.Scale, () => Region.ScaleProperty.NotifyPropertyChanged(Region1), Region.ScaleProperty, DefaultStateName, "Closed"));
            Region1.StateAnimations.Add(region1StateAnimation4);
            Label1 = new Label(this, Region1.Content, "Label1", Label1Template);
            Region2 = new Region(this, Navigator1.Content, "Region2", Region2Template);
            Navigator1.Path.SetValue(Region2, "/test");
            Region2.StateAnimations.Clear();
            var region2StateAnimation1 = new StateAnimation("Closed", DefaultStateName);
            region2StateAnimation1.Add(new Animator<Delight.ElementMargin>(Region2, 0.85f, 0f, false, false, 0f, false, EasingFunctions.Get("QuadraticEaseOut"), Delight.ElementMarginValueConverter.Interpolator, x => Region2.Offset = x, () => Region2.Offset, () => Region.OffsetProperty.NotifyPropertyChanged(Region2), Region.OffsetProperty, "Closed", DefaultStateName));
            region2StateAnimation1.Add(new Animator<UnityEngine.Vector3>(Region2, 0.85f, 0f, false, false, 0f, false, EasingFunctions.Get("QuadraticEaseOut"), Delight.Vector3ValueConverter.Interpolator, x => Region2.Scale = x, () => Region2.Scale, () => Region.ScaleProperty.NotifyPropertyChanged(Region2), Region.ScaleProperty, "Closed", DefaultStateName));
            Region2.StateAnimations.Add(region2StateAnimation1);
            var region2StateAnimation2 = new StateAnimation(DefaultStateName, "Pushed");
            region2StateAnimation2.Add(new Animator<Delight.ElementMargin>(Region2, 0.85f, 0f, false, false, 0f, false, EasingFunctions.Get("QuadraticEaseOut"), Delight.ElementMarginValueConverter.Interpolator, x => Region2.Offset = x, () => Region2.Offset, () => Region.OffsetProperty.NotifyPropertyChanged(Region2), Region.OffsetProperty, DefaultStateName, "Pushed"));
            region2StateAnimation2.Add(new Animator<UnityEngine.Vector3>(Region2, 0.85f, 0f, false, false, 0f, false, EasingFunctions.Get("QuadraticEaseOut"), Delight.Vector3ValueConverter.Interpolator, x => Region2.Scale = x, () => Region2.Scale, () => Region.ScaleProperty.NotifyPropertyChanged(Region2), Region.ScaleProperty, DefaultStateName, "Pushed"));
            Region2.StateAnimations.Add(region2StateAnimation2);
            var region2StateAnimation3 = new StateAnimation("Pushed", DefaultStateName);
            region2StateAnimation3.Add(new Animator<Delight.ElementMargin>(Region2, 0.85f, 0f, false, false, 0f, false, EasingFunctions.Get("QuadraticEaseOut"), Delight.ElementMarginValueConverter.Interpolator, x => Region2.Offset = x, () => Region2.Offset, () => Region.OffsetProperty.NotifyPropertyChanged(Region2), Region.OffsetProperty, "Pushed", DefaultStateName));
            region2StateAnimation3.Add(new Animator<UnityEngine.Vector3>(Region2, 0.85f, 0f, false, false, 0f, false, EasingFunctions.Get("QuadraticEaseOut"), Delight.Vector3ValueConverter.Interpolator, x => Region2.Scale = x, () => Region2.Scale, () => Region.ScaleProperty.NotifyPropertyChanged(Region2), Region.ScaleProperty, "Pushed", DefaultStateName));
            Region2.StateAnimations.Add(region2StateAnimation3);
            var region2StateAnimation4 = new StateAnimation(DefaultStateName, "Closed");
            region2StateAnimation4.Add(new Animator<Delight.ElementMargin>(Region2, 0.85f, 0f, false, false, 0f, false, EasingFunctions.Get("QuadraticEaseOut"), Delight.ElementMarginValueConverter.Interpolator, x => Region2.Offset = x, () => Region2.Offset, () => Region.OffsetProperty.NotifyPropertyChanged(Region2), Region.OffsetProperty, DefaultStateName, "Closed"));
            region2StateAnimation4.Add(new Animator<UnityEngine.Vector3>(Region2, 0.85f, 0f, false, false, 0f, false, EasingFunctions.Get("QuadraticEaseOut"), Delight.Vector3ValueConverter.Interpolator, x => Region2.Scale = x, () => Region2.Scale, () => Region.ScaleProperty.NotifyPropertyChanged(Region2), Region.ScaleProperty, DefaultStateName, "Closed"));
            Region2.StateAnimations.Add(region2StateAnimation4);
            Label2 = new Label(this, Region2.Content, "Label2", Label2Template);

            // constructing Group (Group1)
            Group1 = new Group(this, this, "Group1", Group1Template);
            Button1 = new Button(this, Group1.Content, "Button1", Button1Template);
            Button1.Click.RegisterHandler(this, "OpenRoot");
            Button2 = new Button(this, Group1.Content, "Button2", Button2Template);
            Button2.Click.RegisterHandler(this, "OpenTest");
            Button3 = new Button(this, Group1.Content, "Button3", Button3Template);
            Button3.Click.RegisterHandler(this, "Pop");
            this.AfterInitializeInternal();
        }

        public NavigatorExample() : this(null)
        {
        }

        static NavigatorExample()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(NavigatorExampleTemplates.Default, dependencyProperties);

            dependencyProperties.Add(Navigator1Property);
            dependencyProperties.Add(Navigator1TemplateProperty);
            dependencyProperties.Add(Region1Property);
            dependencyProperties.Add(Region1TemplateProperty);
            dependencyProperties.Add(Label1Property);
            dependencyProperties.Add(Label1TemplateProperty);
            dependencyProperties.Add(Region2Property);
            dependencyProperties.Add(Region2TemplateProperty);
            dependencyProperties.Add(Label2Property);
            dependencyProperties.Add(Label2TemplateProperty);
            dependencyProperties.Add(Group1Property);
            dependencyProperties.Add(Group1TemplateProperty);
            dependencyProperties.Add(Button1Property);
            dependencyProperties.Add(Button1TemplateProperty);
            dependencyProperties.Add(Button2Property);
            dependencyProperties.Add(Button2TemplateProperty);
            dependencyProperties.Add(Button3Property);
            dependencyProperties.Add(Button3TemplateProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<Navigator> Navigator1Property = new DependencyProperty<Navigator>("Navigator1");
        public Navigator Navigator1
        {
            get { return Navigator1Property.GetValue(this); }
            set { Navigator1Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Navigator1TemplateProperty = new DependencyProperty<Template>("Navigator1Template");
        public Template Navigator1Template
        {
            get { return Navigator1TemplateProperty.GetValue(this); }
            set { Navigator1TemplateProperty.SetValue(this, value); }
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

        #endregion
    }

    #region Data Templates

    public static class NavigatorExampleTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return NavigatorExample;
            }
        }

        private static Template _navigatorExample;
        public static Template NavigatorExample
        {
            get
            {
#if UNITY_EDITOR
                if (_navigatorExample == null || _navigatorExample.CurrentVersion != Template.Version)
#else
                if (_navigatorExample == null)
#endif
                {
                    _navigatorExample = new Template(LayoutRootTemplates.LayoutRoot);
#if UNITY_EDITOR
                    _navigatorExample.Name = "NavigatorExample";
                    _navigatorExample.LineNumber = 0;
                    _navigatorExample.LinePosition = 0;
#endif
                    Delight.NavigatorExample.Navigator1TemplateProperty.SetDefault(_navigatorExample, NavigatorExampleNavigator1);
                    Delight.NavigatorExample.Region1TemplateProperty.SetDefault(_navigatorExample, NavigatorExampleRegion1);
                    Delight.NavigatorExample.Label1TemplateProperty.SetDefault(_navigatorExample, NavigatorExampleLabel1);
                    Delight.NavigatorExample.Region2TemplateProperty.SetDefault(_navigatorExample, NavigatorExampleRegion2);
                    Delight.NavigatorExample.Label2TemplateProperty.SetDefault(_navigatorExample, NavigatorExampleLabel2);
                    Delight.NavigatorExample.Group1TemplateProperty.SetDefault(_navigatorExample, NavigatorExampleGroup1);
                    Delight.NavigatorExample.Button1TemplateProperty.SetDefault(_navigatorExample, NavigatorExampleButton1);
                    Delight.NavigatorExample.Button2TemplateProperty.SetDefault(_navigatorExample, NavigatorExampleButton2);
                    Delight.NavigatorExample.Button3TemplateProperty.SetDefault(_navigatorExample, NavigatorExampleButton3);
                }
                return _navigatorExample;
            }
        }

        private static Template _navigatorExampleNavigator1;
        public static Template NavigatorExampleNavigator1
        {
            get
            {
#if UNITY_EDITOR
                if (_navigatorExampleNavigator1 == null || _navigatorExampleNavigator1.CurrentVersion != Template.Version)
#else
                if (_navigatorExampleNavigator1 == null)
#endif
                {
                    _navigatorExampleNavigator1 = new Template(NavigatorTemplates.Navigator);
#if UNITY_EDITOR
                    _navigatorExampleNavigator1.Name = "NavigatorExampleNavigator1";
                    _navigatorExampleNavigator1.LineNumber = 3;
                    _navigatorExampleNavigator1.LinePosition = 4;
#endif
                }
                return _navigatorExampleNavigator1;
            }
        }

        private static Template _navigatorExampleRegion1;
        public static Template NavigatorExampleRegion1
        {
            get
            {
#if UNITY_EDITOR
                if (_navigatorExampleRegion1 == null || _navigatorExampleRegion1.CurrentVersion != Template.Version)
#else
                if (_navigatorExampleRegion1 == null)
#endif
                {
                    _navigatorExampleRegion1 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _navigatorExampleRegion1.Name = "NavigatorExampleRegion1";
                    _navigatorExampleRegion1.LineNumber = 4;
                    _navigatorExampleRegion1.LinePosition = 6;
#endif
                    Delight.Region.BackgroundColorProperty.SetDefault(_navigatorExampleRegion1, new UnityEngine.Color(0f, 0f, 1f, 1f));
                    Delight.Region.OffsetProperty.SetDefault(_navigatorExampleRegion1, new ElementMargin(new ElementSize(0f, ElementSizeUnit.Percents), new ElementSize(0f, ElementSizeUnit.Percents), new ElementSize(0f, ElementSizeUnit.Percents), new ElementSize(0f, ElementSizeUnit.Percents)));
                    Delight.Region.OffsetProperty.SetStateDefault("Closed", _navigatorExampleRegion1, new ElementMargin(new ElementSize(0f, ElementSizeUnit.Percents), new ElementSize(0f, ElementSizeUnit.Percents), new ElementSize(1f, ElementSizeUnit.Percents), new ElementSize(0f, ElementSizeUnit.Percents)));
                    Delight.Region.OffsetProperty.SetStateDefault("Pushed", _navigatorExampleRegion1, new ElementMargin(new ElementSize(1f, ElementSizeUnit.Percents), new ElementSize(0f, ElementSizeUnit.Percents), new ElementSize(0f, ElementSizeUnit.Percents), new ElementSize(0f, ElementSizeUnit.Percents)));
                }
                return _navigatorExampleRegion1;
            }
        }

        private static Template _navigatorExampleLabel1;
        public static Template NavigatorExampleLabel1
        {
            get
            {
#if UNITY_EDITOR
                if (_navigatorExampleLabel1 == null || _navigatorExampleLabel1.CurrentVersion != Template.Version)
#else
                if (_navigatorExampleLabel1 == null)
#endif
                {
                    _navigatorExampleLabel1 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _navigatorExampleLabel1.Name = "NavigatorExampleLabel1";
                    _navigatorExampleLabel1.LineNumber = 6;
                    _navigatorExampleLabel1.LinePosition = 8;
#endif
                    Delight.Label.TextProperty.SetDefault(_navigatorExampleLabel1, "/");
                }
                return _navigatorExampleLabel1;
            }
        }

        private static Template _navigatorExampleRegion2;
        public static Template NavigatorExampleRegion2
        {
            get
            {
#if UNITY_EDITOR
                if (_navigatorExampleRegion2 == null || _navigatorExampleRegion2.CurrentVersion != Template.Version)
#else
                if (_navigatorExampleRegion2 == null)
#endif
                {
                    _navigatorExampleRegion2 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _navigatorExampleRegion2.Name = "NavigatorExampleRegion2";
                    _navigatorExampleRegion2.LineNumber = 9;
                    _navigatorExampleRegion2.LinePosition = 6;
#endif
                    Delight.Region.BackgroundColorProperty.SetDefault(_navigatorExampleRegion2, new UnityEngine.Color(0.627451f, 0.1254902f, 0.9411765f, 1f));
                    Delight.Region.OffsetProperty.SetDefault(_navigatorExampleRegion2, new ElementMargin(new ElementSize(0f, ElementSizeUnit.Percents), new ElementSize(0f, ElementSizeUnit.Percents), new ElementSize(0f, ElementSizeUnit.Percents), new ElementSize(0f, ElementSizeUnit.Percents)));
                    Delight.Region.OffsetProperty.SetStateDefault("Closed", _navigatorExampleRegion2, new ElementMargin(new ElementSize(0f, ElementSizeUnit.Percents), new ElementSize(0f, ElementSizeUnit.Percents), new ElementSize(1f, ElementSizeUnit.Percents), new ElementSize(0f, ElementSizeUnit.Percents)));
                    Delight.Region.OffsetProperty.SetStateDefault("Pushed", _navigatorExampleRegion2, new ElementMargin(new ElementSize(1f, ElementSizeUnit.Percents), new ElementSize(0f, ElementSizeUnit.Percents), new ElementSize(0f, ElementSizeUnit.Percents), new ElementSize(0f, ElementSizeUnit.Percents)));
                }
                return _navigatorExampleRegion2;
            }
        }

        private static Template _navigatorExampleLabel2;
        public static Template NavigatorExampleLabel2
        {
            get
            {
#if UNITY_EDITOR
                if (_navigatorExampleLabel2 == null || _navigatorExampleLabel2.CurrentVersion != Template.Version)
#else
                if (_navigatorExampleLabel2 == null)
#endif
                {
                    _navigatorExampleLabel2 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _navigatorExampleLabel2.Name = "NavigatorExampleLabel2";
                    _navigatorExampleLabel2.LineNumber = 11;
                    _navigatorExampleLabel2.LinePosition = 8;
#endif
                    Delight.Label.TextProperty.SetDefault(_navigatorExampleLabel2, "/test");
                }
                return _navigatorExampleLabel2;
            }
        }

        private static Template _navigatorExampleGroup1;
        public static Template NavigatorExampleGroup1
        {
            get
            {
#if UNITY_EDITOR
                if (_navigatorExampleGroup1 == null || _navigatorExampleGroup1.CurrentVersion != Template.Version)
#else
                if (_navigatorExampleGroup1 == null)
#endif
                {
                    _navigatorExampleGroup1 = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _navigatorExampleGroup1.Name = "NavigatorExampleGroup1";
                    _navigatorExampleGroup1.LineNumber = 15;
                    _navigatorExampleGroup1.LinePosition = 4;
#endif
                    Delight.Group.SpacingProperty.SetDefault(_navigatorExampleGroup1, new ElementSize(5f, ElementSizeUnit.Pixels));
                    Delight.Group.AlignmentProperty.SetDefault(_navigatorExampleGroup1, Delight.ElementAlignment.TopLeft);
                    Delight.Group.OrientationProperty.SetDefault(_navigatorExampleGroup1, Delight.ElementOrientation.Horizontal);
                    Delight.Group.OffsetProperty.SetDefault(_navigatorExampleGroup1, new ElementMargin(new ElementSize(20f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels)));
                }
                return _navigatorExampleGroup1;
            }
        }

        private static Template _navigatorExampleButton1;
        public static Template NavigatorExampleButton1
        {
            get
            {
#if UNITY_EDITOR
                if (_navigatorExampleButton1 == null || _navigatorExampleButton1.CurrentVersion != Template.Version)
#else
                if (_navigatorExampleButton1 == null)
#endif
                {
                    _navigatorExampleButton1 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _navigatorExampleButton1.Name = "NavigatorExampleButton1";
                    _navigatorExampleButton1.LineNumber = 16;
                    _navigatorExampleButton1.LinePosition = 6;
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_navigatorExampleButton1, NavigatorExampleButton1Label);
                }
                return _navigatorExampleButton1;
            }
        }

        private static Template _navigatorExampleButton1Label;
        public static Template NavigatorExampleButton1Label
        {
            get
            {
#if UNITY_EDITOR
                if (_navigatorExampleButton1Label == null || _navigatorExampleButton1Label.CurrentVersion != Template.Version)
#else
                if (_navigatorExampleButton1Label == null)
#endif
                {
                    _navigatorExampleButton1Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _navigatorExampleButton1Label.Name = "NavigatorExampleButton1Label";
                    _navigatorExampleButton1Label.LineNumber = 15;
                    _navigatorExampleButton1Label.LinePosition = 4;
#endif
                    Delight.Label.TextProperty.SetDefault(_navigatorExampleButton1Label, "Open '/'");
                }
                return _navigatorExampleButton1Label;
            }
        }

        private static Template _navigatorExampleButton2;
        public static Template NavigatorExampleButton2
        {
            get
            {
#if UNITY_EDITOR
                if (_navigatorExampleButton2 == null || _navigatorExampleButton2.CurrentVersion != Template.Version)
#else
                if (_navigatorExampleButton2 == null)
#endif
                {
                    _navigatorExampleButton2 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _navigatorExampleButton2.Name = "NavigatorExampleButton2";
                    _navigatorExampleButton2.LineNumber = 17;
                    _navigatorExampleButton2.LinePosition = 6;
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_navigatorExampleButton2, NavigatorExampleButton2Label);
                }
                return _navigatorExampleButton2;
            }
        }

        private static Template _navigatorExampleButton2Label;
        public static Template NavigatorExampleButton2Label
        {
            get
            {
#if UNITY_EDITOR
                if (_navigatorExampleButton2Label == null || _navigatorExampleButton2Label.CurrentVersion != Template.Version)
#else
                if (_navigatorExampleButton2Label == null)
#endif
                {
                    _navigatorExampleButton2Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _navigatorExampleButton2Label.Name = "NavigatorExampleButton2Label";
                    _navigatorExampleButton2Label.LineNumber = 15;
                    _navigatorExampleButton2Label.LinePosition = 4;
#endif
                    Delight.Label.TextProperty.SetDefault(_navigatorExampleButton2Label, "Open '/test'");
                }
                return _navigatorExampleButton2Label;
            }
        }

        private static Template _navigatorExampleButton3;
        public static Template NavigatorExampleButton3
        {
            get
            {
#if UNITY_EDITOR
                if (_navigatorExampleButton3 == null || _navigatorExampleButton3.CurrentVersion != Template.Version)
#else
                if (_navigatorExampleButton3 == null)
#endif
                {
                    _navigatorExampleButton3 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _navigatorExampleButton3.Name = "NavigatorExampleButton3";
                    _navigatorExampleButton3.LineNumber = 18;
                    _navigatorExampleButton3.LinePosition = 6;
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_navigatorExampleButton3, NavigatorExampleButton3Label);
                }
                return _navigatorExampleButton3;
            }
        }

        private static Template _navigatorExampleButton3Label;
        public static Template NavigatorExampleButton3Label
        {
            get
            {
#if UNITY_EDITOR
                if (_navigatorExampleButton3Label == null || _navigatorExampleButton3Label.CurrentVersion != Template.Version)
#else
                if (_navigatorExampleButton3Label == null)
#endif
                {
                    _navigatorExampleButton3Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _navigatorExampleButton3Label.Name = "NavigatorExampleButton3Label";
                    _navigatorExampleButton3Label.LineNumber = 15;
                    _navigatorExampleButton3Label.LinePosition = 4;
#endif
                    Delight.Label.TextProperty.SetDefault(_navigatorExampleButton3Label, "Back");
                }
                return _navigatorExampleButton3Label;
            }
        }

        #endregion
    }

    #endregion
}
