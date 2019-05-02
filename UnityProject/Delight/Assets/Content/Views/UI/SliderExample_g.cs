// Internal view logic generated from "SliderExample.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class SliderExample : UIView
    {
        #region Constructors

        public SliderExample(View parent, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :
            base(parent, layoutParent, id, template ?? SliderExampleTemplates.Default, initializer)
        {
            // constructing Group (Group1)
            Group1 = new Group(this, this, "Group1", Group1Template);
            Group2 = new Group(this, Group1.Content, "Group2", Group2Template);
            Slider1 = new Slider(this, Group2.Content, "Slider1", Slider1Template);
            Label1 = new Label(this, Group2.Content, "Label1", Label1Template);

            // binding <Label Text="{Slider1.Value:0} %">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "Slider1", "Value" }, new List<Func<BindableObject>> { () => this, () => Slider1 }) }, new BindingPath(new List<string> { "Label1", "Text" }, new List<Func<BindableObject>> { () => this, () => Label1 }), () => Label1.Text = String.Format("{0:0} %", Slider1.Value), () => { }, false));
            Group3 = new Group(this, Group1.Content, "Group3", Group3Template);
            Slider2 = new Slider(this, Group3.Content, "Slider2", Slider2Template);
            Label2 = new Label(this, Group3.Content, "Label2", Label2Template);

            // binding <Label Text="{Slider2.Value:0.0}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "Slider2", "Value" }, new List<Func<BindableObject>> { () => this, () => Slider2 }) }, new BindingPath(new List<string> { "Label2", "Text" }, new List<Func<BindableObject>> { () => this, () => Label2 }), () => Label2.Text = String.Format("{0:0.0}", Slider2.Value), () => { }, false));
            this.AfterInitializeInternal();
        }

        public SliderExample() : this(null)
        {
        }

        static SliderExample()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(SliderExampleTemplates.Default, dependencyProperties);

            dependencyProperties.Add(Group1Property);
            dependencyProperties.Add(Group1TemplateProperty);
            dependencyProperties.Add(Group2Property);
            dependencyProperties.Add(Group2TemplateProperty);
            dependencyProperties.Add(Slider1Property);
            dependencyProperties.Add(Slider1TemplateProperty);
            dependencyProperties.Add(Label1Property);
            dependencyProperties.Add(Label1TemplateProperty);
            dependencyProperties.Add(Group3Property);
            dependencyProperties.Add(Group3TemplateProperty);
            dependencyProperties.Add(Slider2Property);
            dependencyProperties.Add(Slider2TemplateProperty);
            dependencyProperties.Add(Label2Property);
            dependencyProperties.Add(Label2TemplateProperty);
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

        public readonly static DependencyProperty<Slider> Slider1Property = new DependencyProperty<Slider>("Slider1");
        public Slider Slider1
        {
            get { return Slider1Property.GetValue(this); }
            set { Slider1Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Slider1TemplateProperty = new DependencyProperty<Template>("Slider1Template");
        public Template Slider1Template
        {
            get { return Slider1TemplateProperty.GetValue(this); }
            set { Slider1TemplateProperty.SetValue(this, value); }
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

        public readonly static DependencyProperty<Slider> Slider2Property = new DependencyProperty<Slider>("Slider2");
        public Slider Slider2
        {
            get { return Slider2Property.GetValue(this); }
            set { Slider2Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Slider2TemplateProperty = new DependencyProperty<Template>("Slider2Template");
        public Template Slider2Template
        {
            get { return Slider2TemplateProperty.GetValue(this); }
            set { Slider2TemplateProperty.SetValue(this, value); }
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

    public static class SliderExampleTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return SliderExample;
            }
        }

        private static Template _sliderExample;
        public static Template SliderExample
        {
            get
            {
#if UNITY_EDITOR
                if (_sliderExample == null || _sliderExample.CurrentVersion != Template.Version)
#else
                if (_sliderExample == null)
#endif
                {
                    _sliderExample = new Template(UIViewTemplates.UIView);
#if UNITY_EDITOR
                    _sliderExample.Name = "SliderExample";
#endif
                    Delight.SliderExample.Group1TemplateProperty.SetDefault(_sliderExample, SliderExampleGroup1);
                    Delight.SliderExample.Group2TemplateProperty.SetDefault(_sliderExample, SliderExampleGroup2);
                    Delight.SliderExample.Slider1TemplateProperty.SetDefault(_sliderExample, SliderExampleSlider1);
                    Delight.SliderExample.Label1TemplateProperty.SetDefault(_sliderExample, SliderExampleLabel1);
                    Delight.SliderExample.Group3TemplateProperty.SetDefault(_sliderExample, SliderExampleGroup3);
                    Delight.SliderExample.Slider2TemplateProperty.SetDefault(_sliderExample, SliderExampleSlider2);
                    Delight.SliderExample.Label2TemplateProperty.SetDefault(_sliderExample, SliderExampleLabel2);
                }
                return _sliderExample;
            }
        }

        private static Template _sliderExampleGroup1;
        public static Template SliderExampleGroup1
        {
            get
            {
#if UNITY_EDITOR
                if (_sliderExampleGroup1 == null || _sliderExampleGroup1.CurrentVersion != Template.Version)
#else
                if (_sliderExampleGroup1 == null)
#endif
                {
                    _sliderExampleGroup1 = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _sliderExampleGroup1.Name = "SliderExampleGroup1";
#endif
                    Delight.Group.OrientationProperty.SetDefault(_sliderExampleGroup1, Delight.ElementOrientation.Horizontal);
                    Delight.Group.SpacingProperty.SetDefault(_sliderExampleGroup1, new ElementSize(30f, ElementSizeUnit.Pixels));
                    Delight.Group.ContentAlignmentProperty.SetDefault(_sliderExampleGroup1, Delight.ElementAlignment.Bottom);
                }
                return _sliderExampleGroup1;
            }
        }

        private static Template _sliderExampleGroup2;
        public static Template SliderExampleGroup2
        {
            get
            {
#if UNITY_EDITOR
                if (_sliderExampleGroup2 == null || _sliderExampleGroup2.CurrentVersion != Template.Version)
#else
                if (_sliderExampleGroup2 == null)
#endif
                {
                    _sliderExampleGroup2 = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _sliderExampleGroup2.Name = "SliderExampleGroup2";
#endif
                    Delight.Group.OrientationProperty.SetDefault(_sliderExampleGroup2, Delight.ElementOrientation.Vertical);
                }
                return _sliderExampleGroup2;
            }
        }

        private static Template _sliderExampleSlider1;
        public static Template SliderExampleSlider1
        {
            get
            {
#if UNITY_EDITOR
                if (_sliderExampleSlider1 == null || _sliderExampleSlider1.CurrentVersion != Template.Version)
#else
                if (_sliderExampleSlider1 == null)
#endif
                {
                    _sliderExampleSlider1 = new Template(SliderTemplates.Slider);
#if UNITY_EDITOR
                    _sliderExampleSlider1.Name = "SliderExampleSlider1";
#endif
                    Delight.Slider.SliderRegionTemplateProperty.SetDefault(_sliderExampleSlider1, SliderExampleSlider1SliderRegion);
                    Delight.Slider.SliderBackgroundImageViewTemplateProperty.SetDefault(_sliderExampleSlider1, SliderExampleSlider1SliderBackgroundImageView);
                    Delight.Slider.SliderFillRegionTemplateProperty.SetDefault(_sliderExampleSlider1, SliderExampleSlider1SliderFillRegion);
                    Delight.Slider.SliderFillImageViewTemplateProperty.SetDefault(_sliderExampleSlider1, SliderExampleSlider1SliderFillImageView);
                    Delight.Slider.SliderHandleImageViewTemplateProperty.SetDefault(_sliderExampleSlider1, SliderExampleSlider1SliderHandleImageView);
                }
                return _sliderExampleSlider1;
            }
        }

        private static Template _sliderExampleSlider1SliderRegion;
        public static Template SliderExampleSlider1SliderRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_sliderExampleSlider1SliderRegion == null || _sliderExampleSlider1SliderRegion.CurrentVersion != Template.Version)
#else
                if (_sliderExampleSlider1SliderRegion == null)
#endif
                {
                    _sliderExampleSlider1SliderRegion = new Template(SliderTemplates.SliderSliderRegion);
#if UNITY_EDITOR
                    _sliderExampleSlider1SliderRegion.Name = "SliderExampleSlider1SliderRegion";
#endif
                }
                return _sliderExampleSlider1SliderRegion;
            }
        }

        private static Template _sliderExampleSlider1SliderBackgroundImageView;
        public static Template SliderExampleSlider1SliderBackgroundImageView
        {
            get
            {
#if UNITY_EDITOR
                if (_sliderExampleSlider1SliderBackgroundImageView == null || _sliderExampleSlider1SliderBackgroundImageView.CurrentVersion != Template.Version)
#else
                if (_sliderExampleSlider1SliderBackgroundImageView == null)
#endif
                {
                    _sliderExampleSlider1SliderBackgroundImageView = new Template(SliderTemplates.SliderSliderBackgroundImageView);
#if UNITY_EDITOR
                    _sliderExampleSlider1SliderBackgroundImageView.Name = "SliderExampleSlider1SliderBackgroundImageView";
#endif
                }
                return _sliderExampleSlider1SliderBackgroundImageView;
            }
        }

        private static Template _sliderExampleSlider1SliderFillRegion;
        public static Template SliderExampleSlider1SliderFillRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_sliderExampleSlider1SliderFillRegion == null || _sliderExampleSlider1SliderFillRegion.CurrentVersion != Template.Version)
#else
                if (_sliderExampleSlider1SliderFillRegion == null)
#endif
                {
                    _sliderExampleSlider1SliderFillRegion = new Template(SliderTemplates.SliderSliderFillRegion);
#if UNITY_EDITOR
                    _sliderExampleSlider1SliderFillRegion.Name = "SliderExampleSlider1SliderFillRegion";
#endif
                }
                return _sliderExampleSlider1SliderFillRegion;
            }
        }

        private static Template _sliderExampleSlider1SliderFillImageView;
        public static Template SliderExampleSlider1SliderFillImageView
        {
            get
            {
#if UNITY_EDITOR
                if (_sliderExampleSlider1SliderFillImageView == null || _sliderExampleSlider1SliderFillImageView.CurrentVersion != Template.Version)
#else
                if (_sliderExampleSlider1SliderFillImageView == null)
#endif
                {
                    _sliderExampleSlider1SliderFillImageView = new Template(SliderTemplates.SliderSliderFillImageView);
#if UNITY_EDITOR
                    _sliderExampleSlider1SliderFillImageView.Name = "SliderExampleSlider1SliderFillImageView";
#endif
                }
                return _sliderExampleSlider1SliderFillImageView;
            }
        }

        private static Template _sliderExampleSlider1SliderHandleImageView;
        public static Template SliderExampleSlider1SliderHandleImageView
        {
            get
            {
#if UNITY_EDITOR
                if (_sliderExampleSlider1SliderHandleImageView == null || _sliderExampleSlider1SliderHandleImageView.CurrentVersion != Template.Version)
#else
                if (_sliderExampleSlider1SliderHandleImageView == null)
#endif
                {
                    _sliderExampleSlider1SliderHandleImageView = new Template(SliderTemplates.SliderSliderHandleImageView);
#if UNITY_EDITOR
                    _sliderExampleSlider1SliderHandleImageView.Name = "SliderExampleSlider1SliderHandleImageView";
#endif
                }
                return _sliderExampleSlider1SliderHandleImageView;
            }
        }

        private static Template _sliderExampleLabel1;
        public static Template SliderExampleLabel1
        {
            get
            {
#if UNITY_EDITOR
                if (_sliderExampleLabel1 == null || _sliderExampleLabel1.CurrentVersion != Template.Version)
#else
                if (_sliderExampleLabel1 == null)
#endif
                {
                    _sliderExampleLabel1 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _sliderExampleLabel1.Name = "SliderExampleLabel1";
#endif
                    Delight.Label.WidthProperty.SetDefault(_sliderExampleLabel1, new ElementSize(100f, ElementSizeUnit.Pixels));
                    Delight.Label.TextAlignmentProperty.SetDefault(_sliderExampleLabel1, TMPro.TextAlignmentOptions.Center);
                }
                return _sliderExampleLabel1;
            }
        }

        private static Template _sliderExampleGroup3;
        public static Template SliderExampleGroup3
        {
            get
            {
#if UNITY_EDITOR
                if (_sliderExampleGroup3 == null || _sliderExampleGroup3.CurrentVersion != Template.Version)
#else
                if (_sliderExampleGroup3 == null)
#endif
                {
                    _sliderExampleGroup3 = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _sliderExampleGroup3.Name = "SliderExampleGroup3";
#endif
                    Delight.Group.OrientationProperty.SetDefault(_sliderExampleGroup3, Delight.ElementOrientation.Vertical);
                }
                return _sliderExampleGroup3;
            }
        }

        private static Template _sliderExampleSlider2;
        public static Template SliderExampleSlider2
        {
            get
            {
#if UNITY_EDITOR
                if (_sliderExampleSlider2 == null || _sliderExampleSlider2.CurrentVersion != Template.Version)
#else
                if (_sliderExampleSlider2 == null)
#endif
                {
                    _sliderExampleSlider2 = new Template(SliderTemplates.Slider);
#if UNITY_EDITOR
                    _sliderExampleSlider2.Name = "SliderExampleSlider2";
#endif
                    Delight.Slider.OrientationProperty.SetDefault(_sliderExampleSlider2, Delight.ElementOrientation.Vertical);
                    Delight.Slider.MinProperty.SetDefault(_sliderExampleSlider2, 20f);
                    Delight.Slider.MaxProperty.SetDefault(_sliderExampleSlider2, 180f);
                    Delight.Slider.ValueProperty.SetDefault(_sliderExampleSlider2, 50f);
                    Delight.Slider.SliderRegionTemplateProperty.SetDefault(_sliderExampleSlider2, SliderExampleSlider2SliderRegion);
                    Delight.Slider.SliderBackgroundImageViewTemplateProperty.SetDefault(_sliderExampleSlider2, SliderExampleSlider2SliderBackgroundImageView);
                    Delight.Slider.SliderFillRegionTemplateProperty.SetDefault(_sliderExampleSlider2, SliderExampleSlider2SliderFillRegion);
                    Delight.Slider.SliderFillImageViewTemplateProperty.SetDefault(_sliderExampleSlider2, SliderExampleSlider2SliderFillImageView);
                    Delight.Slider.SliderHandleImageViewTemplateProperty.SetDefault(_sliderExampleSlider2, SliderExampleSlider2SliderHandleImageView);
                }
                return _sliderExampleSlider2;
            }
        }

        private static Template _sliderExampleSlider2SliderRegion;
        public static Template SliderExampleSlider2SliderRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_sliderExampleSlider2SliderRegion == null || _sliderExampleSlider2SliderRegion.CurrentVersion != Template.Version)
#else
                if (_sliderExampleSlider2SliderRegion == null)
#endif
                {
                    _sliderExampleSlider2SliderRegion = new Template(SliderTemplates.SliderSliderRegion);
#if UNITY_EDITOR
                    _sliderExampleSlider2SliderRegion.Name = "SliderExampleSlider2SliderRegion";
#endif
                }
                return _sliderExampleSlider2SliderRegion;
            }
        }

        private static Template _sliderExampleSlider2SliderBackgroundImageView;
        public static Template SliderExampleSlider2SliderBackgroundImageView
        {
            get
            {
#if UNITY_EDITOR
                if (_sliderExampleSlider2SliderBackgroundImageView == null || _sliderExampleSlider2SliderBackgroundImageView.CurrentVersion != Template.Version)
#else
                if (_sliderExampleSlider2SliderBackgroundImageView == null)
#endif
                {
                    _sliderExampleSlider2SliderBackgroundImageView = new Template(SliderTemplates.SliderSliderBackgroundImageView);
#if UNITY_EDITOR
                    _sliderExampleSlider2SliderBackgroundImageView.Name = "SliderExampleSlider2SliderBackgroundImageView";
#endif
                }
                return _sliderExampleSlider2SliderBackgroundImageView;
            }
        }

        private static Template _sliderExampleSlider2SliderFillRegion;
        public static Template SliderExampleSlider2SliderFillRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_sliderExampleSlider2SliderFillRegion == null || _sliderExampleSlider2SliderFillRegion.CurrentVersion != Template.Version)
#else
                if (_sliderExampleSlider2SliderFillRegion == null)
#endif
                {
                    _sliderExampleSlider2SliderFillRegion = new Template(SliderTemplates.SliderSliderFillRegion);
#if UNITY_EDITOR
                    _sliderExampleSlider2SliderFillRegion.Name = "SliderExampleSlider2SliderFillRegion";
#endif
                }
                return _sliderExampleSlider2SliderFillRegion;
            }
        }

        private static Template _sliderExampleSlider2SliderFillImageView;
        public static Template SliderExampleSlider2SliderFillImageView
        {
            get
            {
#if UNITY_EDITOR
                if (_sliderExampleSlider2SliderFillImageView == null || _sliderExampleSlider2SliderFillImageView.CurrentVersion != Template.Version)
#else
                if (_sliderExampleSlider2SliderFillImageView == null)
#endif
                {
                    _sliderExampleSlider2SliderFillImageView = new Template(SliderTemplates.SliderSliderFillImageView);
#if UNITY_EDITOR
                    _sliderExampleSlider2SliderFillImageView.Name = "SliderExampleSlider2SliderFillImageView";
#endif
                }
                return _sliderExampleSlider2SliderFillImageView;
            }
        }

        private static Template _sliderExampleSlider2SliderHandleImageView;
        public static Template SliderExampleSlider2SliderHandleImageView
        {
            get
            {
#if UNITY_EDITOR
                if (_sliderExampleSlider2SliderHandleImageView == null || _sliderExampleSlider2SliderHandleImageView.CurrentVersion != Template.Version)
#else
                if (_sliderExampleSlider2SliderHandleImageView == null)
#endif
                {
                    _sliderExampleSlider2SliderHandleImageView = new Template(SliderTemplates.SliderSliderHandleImageView);
#if UNITY_EDITOR
                    _sliderExampleSlider2SliderHandleImageView.Name = "SliderExampleSlider2SliderHandleImageView";
#endif
                }
                return _sliderExampleSlider2SliderHandleImageView;
            }
        }

        private static Template _sliderExampleLabel2;
        public static Template SliderExampleLabel2
        {
            get
            {
#if UNITY_EDITOR
                if (_sliderExampleLabel2 == null || _sliderExampleLabel2.CurrentVersion != Template.Version)
#else
                if (_sliderExampleLabel2 == null)
#endif
                {
                    _sliderExampleLabel2 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _sliderExampleLabel2.Name = "SliderExampleLabel2";
#endif
                    Delight.Label.WidthProperty.SetDefault(_sliderExampleLabel2, new ElementSize(100f, ElementSizeUnit.Pixels));
                    Delight.Label.TextAlignmentProperty.SetDefault(_sliderExampleLabel2, TMPro.TextAlignmentOptions.Center);
                }
                return _sliderExampleLabel2;
            }
        }

        #endregion
    }

    #endregion
}
