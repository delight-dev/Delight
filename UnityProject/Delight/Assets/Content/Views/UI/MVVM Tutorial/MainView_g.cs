// Internal view logic generated from "MainView.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class MainView : UIView
    {
        #region Constructors

        public MainView(View parent, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :
            base(parent, layoutParent, id, template ?? MainViewTemplates.Default, initializer)
        {
            // constructing Region (StudentList)
            StudentList = new Region(this, this, "StudentList", StudentListTemplate);

            // constructing Region (Region1)
            Region1 = new Region(this, this, "Region1", Region1Template);
            Group1 = new Group(this, Region1, "Group1", Group1Template);
            Button1 = new Button(this, Group1, "Button1", Button1Template, x => 
            {
                var source = x as Button;
                source.Click = ResolveActionHandler(this, "AddStudent");
            });
            Button2 = new Button(this, Group1, "Button2", Button2Template, x => 
            {
                var source = x as Button;
                source.Click = ResolveActionHandler(this, "RemoveStudent");
            });
            Button3 = new Button(this, Group1, "Button3", Button3Template, x => 
            {
                var source = x as Button;
                source.Click = ResolveActionHandler(this, "EditStudent");
            });
            Button4 = new Button(this, Group1, "Button4", Button4Template, x => 
            {
                var source = x as Button;
                source.Click = ResolveActionHandler(this, "SubmitChanges");
            });
        }

        public MainView() : this(null)
        {
        }

        static MainView()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(MainViewTemplates.Default, dependencyProperties);

            dependencyProperties.Add(StudentListProperty);
            dependencyProperties.Add(StudentListTemplateProperty);
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
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<Region> StudentListProperty = new DependencyProperty<Region>("StudentList");
        public Region StudentList
        {
            get { return StudentListProperty.GetValue(this); }
            set { StudentListProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> StudentListTemplateProperty = new DependencyProperty<Template>("StudentListTemplate");
        public Template StudentListTemplate
        {
            get { return StudentListTemplateProperty.GetValue(this); }
            set { StudentListTemplateProperty.SetValue(this, value); }
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

        #endregion
    }

    #region Data Templates

    public static class MainViewTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return MainView;
            }
        }

        private static Template _mainView;
        public static Template MainView
        {
            get
            {
#if UNITY_EDITOR
                if (_mainView == null || _mainView.CurrentVersion != Template.Version)
#else
                if (_mainView == null)
#endif
                {
                    _mainView = new Template(UIViewTemplates.UIView);
                    Delight.MainView.StudentListTemplateProperty.SetDefault(_mainView, MainViewStudentList);
                    Delight.MainView.Region1TemplateProperty.SetDefault(_mainView, MainViewRegion1);
                    Delight.MainView.Group1TemplateProperty.SetDefault(_mainView, MainViewGroup1);
                    Delight.MainView.Button1TemplateProperty.SetDefault(_mainView, MainViewButton1);
                    Delight.MainView.Button2TemplateProperty.SetDefault(_mainView, MainViewButton2);
                    Delight.MainView.Button3TemplateProperty.SetDefault(_mainView, MainViewButton3);
                    Delight.MainView.Button4TemplateProperty.SetDefault(_mainView, MainViewButton4);
                }
                return _mainView;
            }
        }

        private static Template _mainViewStudentList;
        public static Template MainViewStudentList
        {
            get
            {
#if UNITY_EDITOR
                if (_mainViewStudentList == null || _mainViewStudentList.CurrentVersion != Template.Version)
#else
                if (_mainViewStudentList == null)
#endif
                {
                    _mainViewStudentList = new Template(RegionTemplates.Region);
                    Delight.Region.WidthProperty.SetDefault(_mainViewStudentList, new ElementSize(0.75f, ElementSizeUnit.Percents));
                    Delight.Region.AlignmentProperty.SetDefault(_mainViewStudentList, Delight.ElementAlignment.Left);
                    Delight.Region.MarginProperty.SetDefault(_mainViewStudentList, new ElementMargin(10f, 10f, 10f, 10f));
                    Delight.Region.BackgroundColorProperty.SetDefault(_mainViewStudentList, new UnityEngine.Color(0.9607843f, 1f, 0.9803922f, 1f));
                }
                return _mainViewStudentList;
            }
        }

        private static Template _mainViewRegion1;
        public static Template MainViewRegion1
        {
            get
            {
#if UNITY_EDITOR
                if (_mainViewRegion1 == null || _mainViewRegion1.CurrentVersion != Template.Version)
#else
                if (_mainViewRegion1 == null)
#endif
                {
                    _mainViewRegion1 = new Template(RegionTemplates.Region);
                    Delight.Region.WidthProperty.SetDefault(_mainViewRegion1, new ElementSize(0.25f, ElementSizeUnit.Percents));
                    Delight.Region.AlignmentProperty.SetDefault(_mainViewRegion1, Delight.ElementAlignment.Right);
                    Delight.Region.MarginProperty.SetDefault(_mainViewRegion1, new ElementMargin(10f, 10f, 10f, 10f));
                }
                return _mainViewRegion1;
            }
        }

        private static Template _mainViewGroup1;
        public static Template MainViewGroup1
        {
            get
            {
#if UNITY_EDITOR
                if (_mainViewGroup1 == null || _mainViewGroup1.CurrentVersion != Template.Version)
#else
                if (_mainViewGroup1 == null)
#endif
                {
                    _mainViewGroup1 = new Template(GroupTemplates.Group);
                    Delight.Group.AlignmentProperty.SetDefault(_mainViewGroup1, Delight.ElementAlignment.Top);
                    Delight.Group.SpacingProperty.SetDefault(_mainViewGroup1, new ElementSize(5f, ElementSizeUnit.Pixels));
                }
                return _mainViewGroup1;
            }
        }

        private static Template _mainViewButton1;
        public static Template MainViewButton1
        {
            get
            {
#if UNITY_EDITOR
                if (_mainViewButton1 == null || _mainViewButton1.CurrentVersion != Template.Version)
#else
                if (_mainViewButton1 == null)
#endif
                {
                    _mainViewButton1 = new Template(ButtonTemplates.Button);
                    Delight.Button.LabelTemplateProperty.SetDefault(_mainViewButton1, MainViewButton1Label);
                }
                return _mainViewButton1;
            }
        }

        private static Template _mainViewButton1Label;
        public static Template MainViewButton1Label
        {
            get
            {
#if UNITY_EDITOR
                if (_mainViewButton1Label == null || _mainViewButton1Label.CurrentVersion != Template.Version)
#else
                if (_mainViewButton1Label == null)
#endif
                {
                    _mainViewButton1Label = new Template(ButtonTemplates.ButtonLabel);
                    Delight.Label.TextProperty.SetDefault(_mainViewButton1Label, "Add Student");
                    Delight.Label.FontSizeProperty.SetDefault(_mainViewButton1Label, 18f);
                    Delight.Label.ColorProperty.SetDefault(_mainViewButton1Label, new UnityEngine.Color(0f, 0f, 0f, 1f));
                    Delight.Label.TextAlignmentProperty.SetDefault(_mainViewButton1Label, TMPro.TextAlignmentOptions.Center);
                    Delight.Label.ExtraPaddingProperty.SetDefault(_mainViewButton1Label, true);
                }
                return _mainViewButton1Label;
            }
        }

        private static Template _mainViewButton2;
        public static Template MainViewButton2
        {
            get
            {
#if UNITY_EDITOR
                if (_mainViewButton2 == null || _mainViewButton2.CurrentVersion != Template.Version)
#else
                if (_mainViewButton2 == null)
#endif
                {
                    _mainViewButton2 = new Template(ButtonTemplates.Button);
                    Delight.Button.LabelTemplateProperty.SetDefault(_mainViewButton2, MainViewButton2Label);
                }
                return _mainViewButton2;
            }
        }

        private static Template _mainViewButton2Label;
        public static Template MainViewButton2Label
        {
            get
            {
#if UNITY_EDITOR
                if (_mainViewButton2Label == null || _mainViewButton2Label.CurrentVersion != Template.Version)
#else
                if (_mainViewButton2Label == null)
#endif
                {
                    _mainViewButton2Label = new Template(ButtonTemplates.ButtonLabel);
                    Delight.Label.TextProperty.SetDefault(_mainViewButton2Label, "Remove Student");
                    Delight.Label.FontSizeProperty.SetDefault(_mainViewButton2Label, 18f);
                    Delight.Label.ColorProperty.SetDefault(_mainViewButton2Label, new UnityEngine.Color(0f, 0f, 0f, 1f));
                    Delight.Label.TextAlignmentProperty.SetDefault(_mainViewButton2Label, TMPro.TextAlignmentOptions.Center);
                    Delight.Label.ExtraPaddingProperty.SetDefault(_mainViewButton2Label, true);
                }
                return _mainViewButton2Label;
            }
        }

        private static Template _mainViewButton3;
        public static Template MainViewButton3
        {
            get
            {
#if UNITY_EDITOR
                if (_mainViewButton3 == null || _mainViewButton3.CurrentVersion != Template.Version)
#else
                if (_mainViewButton3 == null)
#endif
                {
                    _mainViewButton3 = new Template(ButtonTemplates.Button);
                    Delight.Button.LabelTemplateProperty.SetDefault(_mainViewButton3, MainViewButton3Label);
                }
                return _mainViewButton3;
            }
        }

        private static Template _mainViewButton3Label;
        public static Template MainViewButton3Label
        {
            get
            {
#if UNITY_EDITOR
                if (_mainViewButton3Label == null || _mainViewButton3Label.CurrentVersion != Template.Version)
#else
                if (_mainViewButton3Label == null)
#endif
                {
                    _mainViewButton3Label = new Template(ButtonTemplates.ButtonLabel);
                    Delight.Label.TextProperty.SetDefault(_mainViewButton3Label, "Edit Student");
                    Delight.Label.FontSizeProperty.SetDefault(_mainViewButton3Label, 18f);
                    Delight.Label.ColorProperty.SetDefault(_mainViewButton3Label, new UnityEngine.Color(0f, 0f, 0f, 1f));
                    Delight.Label.TextAlignmentProperty.SetDefault(_mainViewButton3Label, TMPro.TextAlignmentOptions.Center);
                    Delight.Label.ExtraPaddingProperty.SetDefault(_mainViewButton3Label, true);
                }
                return _mainViewButton3Label;
            }
        }

        private static Template _mainViewButton4;
        public static Template MainViewButton4
        {
            get
            {
#if UNITY_EDITOR
                if (_mainViewButton4 == null || _mainViewButton4.CurrentVersion != Template.Version)
#else
                if (_mainViewButton4 == null)
#endif
                {
                    _mainViewButton4 = new Template(ButtonTemplates.Button);
                    Delight.Button.LabelTemplateProperty.SetDefault(_mainViewButton4, MainViewButton4Label);
                }
                return _mainViewButton4;
            }
        }

        private static Template _mainViewButton4Label;
        public static Template MainViewButton4Label
        {
            get
            {
#if UNITY_EDITOR
                if (_mainViewButton4Label == null || _mainViewButton4Label.CurrentVersion != Template.Version)
#else
                if (_mainViewButton4Label == null)
#endif
                {
                    _mainViewButton4Label = new Template(ButtonTemplates.ButtonLabel);
                    Delight.Label.TextProperty.SetDefault(_mainViewButton4Label, "Submit Changes");
                    Delight.Label.FontSizeProperty.SetDefault(_mainViewButton4Label, 18f);
                    Delight.Label.ColorProperty.SetDefault(_mainViewButton4Label, new UnityEngine.Color(0f, 0f, 0f, 1f));
                    Delight.Label.TextAlignmentProperty.SetDefault(_mainViewButton4Label, TMPro.TextAlignmentOptions.Center);
                    Delight.Label.ExtraPaddingProperty.SetDefault(_mainViewButton4Label, true);
                }
                return _mainViewButton4Label;
            }
        }

        #endregion
    }

    #endregion
}
