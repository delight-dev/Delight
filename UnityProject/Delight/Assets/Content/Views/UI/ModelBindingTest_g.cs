// Internal view logic generated from "ModelBindingTest.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class ModelBindingTest : LayoutRoot
    {
        #region Constructors

        public ModelBindingTest(View parent, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :
            base(parent, layoutParent, id, template ?? ModelBindingTestTemplates.Default, initializer)
        {
            // constructing Group (Group1)
            Group1 = new Group(this, this, "Group1", Group1Template);
            Group2 = new Group(this, Group1, "Group2", Group2Template);
            Button1 = new Button(this, Group2, "Button1", Button1Template, x => 
            {
                var source = x as Button;
                source.Click = ResolveActionHandler(this, "Test1");
            });
            Button2 = new Button(this, Group2, "Button2", Button2Template, x => 
            {
                var source = x as Button;
                source.Click = ResolveActionHandler(this, "Test2");
            });
            DynamicList = new List(this, Group1, "DynamicList", DynamicListTemplate);

            // binding <List Items="{@Players}">
            _bindings.Add(new Binding(
                new List<string> {  },
                new List<string> { "DynamicList", "Items" },
                new List<Func<BindableObject>> {  },
                new List<Func<BindableObject>> { () => this, () => DynamicList },
                () => DynamicList.Items = Models.Players,
                () => { }
            ));
        }

        public ModelBindingTest() : this(null)
        {
        }

        static ModelBindingTest()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(ModelBindingTestTemplates.Default, dependencyProperties);

            dependencyProperties.Add(Group1Property);
            dependencyProperties.Add(Group1TemplateProperty);
            dependencyProperties.Add(Group2Property);
            dependencyProperties.Add(Group2TemplateProperty);
            dependencyProperties.Add(Button1Property);
            dependencyProperties.Add(Button1TemplateProperty);
            dependencyProperties.Add(Button2Property);
            dependencyProperties.Add(Button2TemplateProperty);
            dependencyProperties.Add(DynamicListProperty);
            dependencyProperties.Add(DynamicListTemplateProperty);
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

        public readonly static DependencyProperty<List> DynamicListProperty = new DependencyProperty<List>("DynamicList");
        public List DynamicList
        {
            get { return DynamicListProperty.GetValue(this); }
            set { DynamicListProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> DynamicListTemplateProperty = new DependencyProperty<Template>("DynamicListTemplate");
        public Template DynamicListTemplate
        {
            get { return DynamicListTemplateProperty.GetValue(this); }
            set { DynamicListTemplateProperty.SetValue(this, value); }
        }

        #endregion
    }

    #region Data Templates

    public static class ModelBindingTestTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return ModelBindingTest;
            }
        }

        private static Template _modelBindingTest;
        public static Template ModelBindingTest
        {
            get
            {
#if UNITY_EDITOR
                if (_modelBindingTest == null || _modelBindingTest.CurrentVersion != Template.Version)
#else
                if (_modelBindingTest == null)
#endif
                {
                    _modelBindingTest = new Template(LayoutRootTemplates.LayoutRoot);
                    Delight.ModelBindingTest.Group1TemplateProperty.SetDefault(_modelBindingTest, ModelBindingTestGroup1);
                    Delight.ModelBindingTest.Group2TemplateProperty.SetDefault(_modelBindingTest, ModelBindingTestGroup2);
                    Delight.ModelBindingTest.Button1TemplateProperty.SetDefault(_modelBindingTest, ModelBindingTestButton1);
                    Delight.ModelBindingTest.Button2TemplateProperty.SetDefault(_modelBindingTest, ModelBindingTestButton2);
                    Delight.ModelBindingTest.DynamicListTemplateProperty.SetDefault(_modelBindingTest, ModelBindingTestDynamicList);
                }
                return _modelBindingTest;
            }
        }

        private static Template _modelBindingTestGroup1;
        public static Template ModelBindingTestGroup1
        {
            get
            {
#if UNITY_EDITOR
                if (_modelBindingTestGroup1 == null || _modelBindingTestGroup1.CurrentVersion != Template.Version)
#else
                if (_modelBindingTestGroup1 == null)
#endif
                {
                    _modelBindingTestGroup1 = new Template(GroupTemplates.Group);
                    Delight.Group.OrientationProperty.SetDefault(_modelBindingTestGroup1, Delight.ElementOrientation.Horizontal);
                }
                return _modelBindingTestGroup1;
            }
        }

        private static Template _modelBindingTestGroup2;
        public static Template ModelBindingTestGroup2
        {
            get
            {
#if UNITY_EDITOR
                if (_modelBindingTestGroup2 == null || _modelBindingTestGroup2.CurrentVersion != Template.Version)
#else
                if (_modelBindingTestGroup2 == null)
#endif
                {
                    _modelBindingTestGroup2 = new Template(GroupTemplates.Group);
                    Delight.Group.SpacingProperty.SetDefault(_modelBindingTestGroup2, new ElementSize(10f, ElementSizeUnit.Pixels));
                    Delight.Group.WidthProperty.SetDefault(_modelBindingTestGroup2, new ElementSize(500f, ElementSizeUnit.Pixels));
                }
                return _modelBindingTestGroup2;
            }
        }

        private static Template _modelBindingTestButton1;
        public static Template ModelBindingTestButton1
        {
            get
            {
#if UNITY_EDITOR
                if (_modelBindingTestButton1 == null || _modelBindingTestButton1.CurrentVersion != Template.Version)
#else
                if (_modelBindingTestButton1 == null)
#endif
                {
                    _modelBindingTestButton1 = new Template(ButtonTemplates.Button);
                    Delight.Button.LabelTemplateProperty.SetDefault(_modelBindingTestButton1, ModelBindingTestButton1Label);
                }
                return _modelBindingTestButton1;
            }
        }

        private static Template _modelBindingTestButton1Label;
        public static Template ModelBindingTestButton1Label
        {
            get
            {
#if UNITY_EDITOR
                if (_modelBindingTestButton1Label == null || _modelBindingTestButton1Label.CurrentVersion != Template.Version)
#else
                if (_modelBindingTestButton1Label == null)
#endif
                {
                    _modelBindingTestButton1Label = new Template(ButtonTemplates.ButtonLabel);
                    Delight.Label.TextProperty.SetDefault(_modelBindingTestButton1Label, "Test 1");
                }
                return _modelBindingTestButton1Label;
            }
        }

        private static Template _modelBindingTestButton2;
        public static Template ModelBindingTestButton2
        {
            get
            {
#if UNITY_EDITOR
                if (_modelBindingTestButton2 == null || _modelBindingTestButton2.CurrentVersion != Template.Version)
#else
                if (_modelBindingTestButton2 == null)
#endif
                {
                    _modelBindingTestButton2 = new Template(ButtonTemplates.Button);
                    Delight.Button.LabelTemplateProperty.SetDefault(_modelBindingTestButton2, ModelBindingTestButton2Label);
                }
                return _modelBindingTestButton2;
            }
        }

        private static Template _modelBindingTestButton2Label;
        public static Template ModelBindingTestButton2Label
        {
            get
            {
#if UNITY_EDITOR
                if (_modelBindingTestButton2Label == null || _modelBindingTestButton2Label.CurrentVersion != Template.Version)
#else
                if (_modelBindingTestButton2Label == null)
#endif
                {
                    _modelBindingTestButton2Label = new Template(ButtonTemplates.ButtonLabel);
                    Delight.Label.TextProperty.SetDefault(_modelBindingTestButton2Label, "Test 2");
                }
                return _modelBindingTestButton2Label;
            }
        }

        private static Template _modelBindingTestDynamicList;
        public static Template ModelBindingTestDynamicList
        {
            get
            {
#if UNITY_EDITOR
                if (_modelBindingTestDynamicList == null || _modelBindingTestDynamicList.CurrentVersion != Template.Version)
#else
                if (_modelBindingTestDynamicList == null)
#endif
                {
                    _modelBindingTestDynamicList = new Template(ListTemplates.List);
                    Delight.List.WidthProperty.SetDefault(_modelBindingTestDynamicList, new ElementSize(500f, ElementSizeUnit.Pixels));
                    Delight.List.BackgroundColorProperty.SetDefault(_modelBindingTestDynamicList, new UnityEngine.Color(0f, 1f, 0f, 1f));
                    Delight.List.MarginProperty.SetDefault(_modelBindingTestDynamicList, new ElementMargin(50f, 50f, 50f, 50f));
                }
                return _modelBindingTestDynamicList;
            }
        }

        #endregion
    }

    #endregion
}
