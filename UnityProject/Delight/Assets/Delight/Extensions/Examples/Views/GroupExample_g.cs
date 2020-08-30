// Internal view logic generated from "GroupExample.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class GroupExample : UIView
    {
        #region Constructors

        public GroupExample(View parent, View layoutParent = null, string id = null, Template template = null, bool deferInitialization = false) :
            base(parent, layoutParent, id, template ?? GroupExampleTemplates.Default, deferInitialization)
        {
            if (deferInitialization)
                return;

            // constructing Label (Label1)
            Label1 = new Label(this, this, "Label1", Label1Template);

            // constructing Group (Group1)
            Group1 = new Group(this, this, "Group1", Group1Template);
            Button1 = new Button(this, Group1.Content, "Button1", Button1Template);
            Button2 = new Button(this, Group1.Content, "Button2", Button2Template);
            Button3 = new Button(this, Group1.Content, "Button3", Button3Template);

            // constructing Label (Label2)
            Label2 = new Label(this, this, "Label2", Label2Template);

            // constructing Group (Group2)
            Group2 = new Group(this, this, "Group2", Group2Template);
            Button4 = new Button(this, Group2.Content, "Button4", Button4Template);
            Button5 = new Button(this, Group2.Content, "Button5", Button5Template);
            Button6 = new Button(this, Group2.Content, "Button6", Button6Template);

            // constructing Label (Label3)
            Label3 = new Label(this, this, "Label3", Label3Template);

            // constructing Group (Group3)
            Group3 = new Group(this, this, "Group3", Group3Template);
            Button7 = new Button(this, Group3.Content, "Button7", Button7Template);
            Button8 = new Button(this, Group3.Content, "Button8", Button8Template);
            Button9 = new Button(this, Group3.Content, "Button9", Button9Template);
            this.AfterInitializeInternal();
        }

        public GroupExample() : this(null)
        {
        }

        static GroupExample()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(GroupExampleTemplates.Default, dependencyProperties);

            dependencyProperties.Add(Label1Property);
            dependencyProperties.Add(Label1TemplateProperty);
            dependencyProperties.Add(Group1Property);
            dependencyProperties.Add(Group1TemplateProperty);
            dependencyProperties.Add(Button1Property);
            dependencyProperties.Add(Button1TemplateProperty);
            dependencyProperties.Add(Button2Property);
            dependencyProperties.Add(Button2TemplateProperty);
            dependencyProperties.Add(Button3Property);
            dependencyProperties.Add(Button3TemplateProperty);
            dependencyProperties.Add(Label2Property);
            dependencyProperties.Add(Label2TemplateProperty);
            dependencyProperties.Add(Group2Property);
            dependencyProperties.Add(Group2TemplateProperty);
            dependencyProperties.Add(Button4Property);
            dependencyProperties.Add(Button4TemplateProperty);
            dependencyProperties.Add(Button5Property);
            dependencyProperties.Add(Button5TemplateProperty);
            dependencyProperties.Add(Button6Property);
            dependencyProperties.Add(Button6TemplateProperty);
            dependencyProperties.Add(Label3Property);
            dependencyProperties.Add(Label3TemplateProperty);
            dependencyProperties.Add(Group3Property);
            dependencyProperties.Add(Group3TemplateProperty);
            dependencyProperties.Add(Button7Property);
            dependencyProperties.Add(Button7TemplateProperty);
            dependencyProperties.Add(Button8Property);
            dependencyProperties.Add(Button8TemplateProperty);
            dependencyProperties.Add(Button9Property);
            dependencyProperties.Add(Button9TemplateProperty);
        }

        #endregion

        #region Properties

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

        public readonly static DependencyProperty<Button> Button7Property = new DependencyProperty<Button>("Button7");
        public Button Button7
        {
            get { return Button7Property.GetValue(this); }
            set { Button7Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Button7TemplateProperty = new DependencyProperty<Template>("Button7Template");
        public Template Button7Template
        {
            get { return Button7TemplateProperty.GetValue(this); }
            set { Button7TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Button> Button8Property = new DependencyProperty<Button>("Button8");
        public Button Button8
        {
            get { return Button8Property.GetValue(this); }
            set { Button8Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Button8TemplateProperty = new DependencyProperty<Template>("Button8Template");
        public Template Button8Template
        {
            get { return Button8TemplateProperty.GetValue(this); }
            set { Button8TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Button> Button9Property = new DependencyProperty<Button>("Button9");
        public Button Button9
        {
            get { return Button9Property.GetValue(this); }
            set { Button9Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Button9TemplateProperty = new DependencyProperty<Template>("Button9Template");
        public Template Button9Template
        {
            get { return Button9TemplateProperty.GetValue(this); }
            set { Button9TemplateProperty.SetValue(this, value); }
        }

        #endregion
    }

    #region Data Templates

    public static class GroupExampleTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return GroupExample;
            }
        }

        private static Template _groupExample;
        public static Template GroupExample
        {
            get
            {
#if UNITY_EDITOR
                if (_groupExample == null || _groupExample.CurrentVersion != Template.Version)
#else
                if (_groupExample == null)
#endif
                {
                    _groupExample = new Template(UIViewTemplates.UIView);
#if UNITY_EDITOR
                    _groupExample.Name = "GroupExample";
                    _groupExample.LineNumber = 0;
                    _groupExample.LinePosition = 0;
#endif
                    Delight.GroupExample.Label1TemplateProperty.SetDefault(_groupExample, GroupExampleLabel1);
                    Delight.GroupExample.Group1TemplateProperty.SetDefault(_groupExample, GroupExampleGroup1);
                    Delight.GroupExample.Button1TemplateProperty.SetDefault(_groupExample, GroupExampleButton1);
                    Delight.GroupExample.Button2TemplateProperty.SetDefault(_groupExample, GroupExampleButton2);
                    Delight.GroupExample.Button3TemplateProperty.SetDefault(_groupExample, GroupExampleButton3);
                    Delight.GroupExample.Label2TemplateProperty.SetDefault(_groupExample, GroupExampleLabel2);
                    Delight.GroupExample.Group2TemplateProperty.SetDefault(_groupExample, GroupExampleGroup2);
                    Delight.GroupExample.Button4TemplateProperty.SetDefault(_groupExample, GroupExampleButton4);
                    Delight.GroupExample.Button5TemplateProperty.SetDefault(_groupExample, GroupExampleButton5);
                    Delight.GroupExample.Button6TemplateProperty.SetDefault(_groupExample, GroupExampleButton6);
                    Delight.GroupExample.Label3TemplateProperty.SetDefault(_groupExample, GroupExampleLabel3);
                    Delight.GroupExample.Group3TemplateProperty.SetDefault(_groupExample, GroupExampleGroup3);
                    Delight.GroupExample.Button7TemplateProperty.SetDefault(_groupExample, GroupExampleButton7);
                    Delight.GroupExample.Button8TemplateProperty.SetDefault(_groupExample, GroupExampleButton8);
                    Delight.GroupExample.Button9TemplateProperty.SetDefault(_groupExample, GroupExampleButton9);
                }
                return _groupExample;
            }
        }

        private static Template _groupExampleLabel1;
        public static Template GroupExampleLabel1
        {
            get
            {
#if UNITY_EDITOR
                if (_groupExampleLabel1 == null || _groupExampleLabel1.CurrentVersion != Template.Version)
#else
                if (_groupExampleLabel1 == null)
#endif
                {
                    _groupExampleLabel1 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _groupExampleLabel1.Name = "GroupExampleLabel1";
                    _groupExampleLabel1.LineNumber = 4;
                    _groupExampleLabel1.LinePosition = 4;
#endif
                    Delight.Label.TextProperty.SetDefault(_groupExampleLabel1, "Group 1:");
                    Delight.Label.AutoSizeProperty.SetDefault(_groupExampleLabel1, Delight.AutoSize.Default);
                    Delight.Label.FontColorProperty.SetDefault(_groupExampleLabel1, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Label.OffsetProperty.SetDefault(_groupExampleLabel1, new ElementMargin(new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(250f, ElementSizeUnit.Pixels), new ElementSize(100f, ElementSizeUnit.Pixels)));
                }
                return _groupExampleLabel1;
            }
        }

        private static Template _groupExampleGroup1;
        public static Template GroupExampleGroup1
        {
            get
            {
#if UNITY_EDITOR
                if (_groupExampleGroup1 == null || _groupExampleGroup1.CurrentVersion != Template.Version)
#else
                if (_groupExampleGroup1 == null)
#endif
                {
                    _groupExampleGroup1 = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _groupExampleGroup1.Name = "GroupExampleGroup1";
                    _groupExampleGroup1.LineNumber = 5;
                    _groupExampleGroup1.LinePosition = 4;
#endif
                    Delight.Group.OrientationProperty.SetDefault(_groupExampleGroup1, Delight.ElementOrientation.Horizontal);
                    Delight.Group.SpacingProperty.SetDefault(_groupExampleGroup1, new ElementSize(4f, ElementSizeUnit.Pixels));
                    Delight.Group.OffsetProperty.SetDefault(_groupExampleGroup1, new ElementMargin(new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(100f, ElementSizeUnit.Pixels)));
                }
                return _groupExampleGroup1;
            }
        }

        private static Template _groupExampleButton1;
        public static Template GroupExampleButton1
        {
            get
            {
#if UNITY_EDITOR
                if (_groupExampleButton1 == null || _groupExampleButton1.CurrentVersion != Template.Version)
#else
                if (_groupExampleButton1 == null)
#endif
                {
                    _groupExampleButton1 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _groupExampleButton1.Name = "GroupExampleButton1";
                    _groupExampleButton1.LineNumber = 6;
                    _groupExampleButton1.LinePosition = 6;
#endif
                    Delight.Button.WidthProperty.SetDefault(_groupExampleButton1, new ElementSize(75f, ElementSizeUnit.Pixels));
                    Delight.Button.HeightProperty.SetDefault(_groupExampleButton1, new ElementSize(40f, ElementSizeUnit.Pixels));
                    Delight.Button.LabelTemplateProperty.SetDefault(_groupExampleButton1, GroupExampleButton1Label);
                }
                return _groupExampleButton1;
            }
        }

        private static Template _groupExampleButton1Label;
        public static Template GroupExampleButton1Label
        {
            get
            {
#if UNITY_EDITOR
                if (_groupExampleButton1Label == null || _groupExampleButton1Label.CurrentVersion != Template.Version)
#else
                if (_groupExampleButton1Label == null)
#endif
                {
                    _groupExampleButton1Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _groupExampleButton1Label.Name = "GroupExampleButton1Label";
                    _groupExampleButton1Label.LineNumber = 15;
                    _groupExampleButton1Label.LinePosition = 4;
#endif
                    Delight.Label.TextProperty.SetDefault(_groupExampleButton1Label, "Button 1");
                }
                return _groupExampleButton1Label;
            }
        }

        private static Template _groupExampleButton2;
        public static Template GroupExampleButton2
        {
            get
            {
#if UNITY_EDITOR
                if (_groupExampleButton2 == null || _groupExampleButton2.CurrentVersion != Template.Version)
#else
                if (_groupExampleButton2 == null)
#endif
                {
                    _groupExampleButton2 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _groupExampleButton2.Name = "GroupExampleButton2";
                    _groupExampleButton2.LineNumber = 7;
                    _groupExampleButton2.LinePosition = 6;
#endif
                    Delight.Button.WidthProperty.SetDefault(_groupExampleButton2, new ElementSize(175f, ElementSizeUnit.Pixels));
                    Delight.Button.HeightProperty.SetDefault(_groupExampleButton2, new ElementSize(70f, ElementSizeUnit.Pixels));
                    Delight.Button.LabelTemplateProperty.SetDefault(_groupExampleButton2, GroupExampleButton2Label);
                }
                return _groupExampleButton2;
            }
        }

        private static Template _groupExampleButton2Label;
        public static Template GroupExampleButton2Label
        {
            get
            {
#if UNITY_EDITOR
                if (_groupExampleButton2Label == null || _groupExampleButton2Label.CurrentVersion != Template.Version)
#else
                if (_groupExampleButton2Label == null)
#endif
                {
                    _groupExampleButton2Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _groupExampleButton2Label.Name = "GroupExampleButton2Label";
                    _groupExampleButton2Label.LineNumber = 15;
                    _groupExampleButton2Label.LinePosition = 4;
#endif
                    Delight.Label.TextProperty.SetDefault(_groupExampleButton2Label, "Large Button 2");
                }
                return _groupExampleButton2Label;
            }
        }

        private static Template _groupExampleButton3;
        public static Template GroupExampleButton3
        {
            get
            {
#if UNITY_EDITOR
                if (_groupExampleButton3 == null || _groupExampleButton3.CurrentVersion != Template.Version)
#else
                if (_groupExampleButton3 == null)
#endif
                {
                    _groupExampleButton3 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _groupExampleButton3.Name = "GroupExampleButton3";
                    _groupExampleButton3.LineNumber = 8;
                    _groupExampleButton3.LinePosition = 6;
#endif
                    Delight.Button.WidthProperty.SetDefault(_groupExampleButton3, new ElementSize(75f, ElementSizeUnit.Pixels));
                    Delight.Button.HeightProperty.SetDefault(_groupExampleButton3, new ElementSize(40f, ElementSizeUnit.Pixels));
                    Delight.Button.LabelTemplateProperty.SetDefault(_groupExampleButton3, GroupExampleButton3Label);
                }
                return _groupExampleButton3;
            }
        }

        private static Template _groupExampleButton3Label;
        public static Template GroupExampleButton3Label
        {
            get
            {
#if UNITY_EDITOR
                if (_groupExampleButton3Label == null || _groupExampleButton3Label.CurrentVersion != Template.Version)
#else
                if (_groupExampleButton3Label == null)
#endif
                {
                    _groupExampleButton3Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _groupExampleButton3Label.Name = "GroupExampleButton3Label";
                    _groupExampleButton3Label.LineNumber = 15;
                    _groupExampleButton3Label.LinePosition = 4;
#endif
                    Delight.Label.TextProperty.SetDefault(_groupExampleButton3Label, "Button 3");
                }
                return _groupExampleButton3Label;
            }
        }

        private static Template _groupExampleLabel2;
        public static Template GroupExampleLabel2
        {
            get
            {
#if UNITY_EDITOR
                if (_groupExampleLabel2 == null || _groupExampleLabel2.CurrentVersion != Template.Version)
#else
                if (_groupExampleLabel2 == null)
#endif
                {
                    _groupExampleLabel2 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _groupExampleLabel2.Name = "GroupExampleLabel2";
                    _groupExampleLabel2.LineNumber = 11;
                    _groupExampleLabel2.LinePosition = 4;
#endif
                    Delight.Label.TextProperty.SetDefault(_groupExampleLabel2, "Group 2:");
                    Delight.Label.AutoSizeProperty.SetDefault(_groupExampleLabel2, Delight.AutoSize.Default);
                    Delight.Label.FontColorProperty.SetDefault(_groupExampleLabel2, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Label.OffsetProperty.SetDefault(_groupExampleLabel2, new ElementMargin(new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(250f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels)));
                }
                return _groupExampleLabel2;
            }
        }

        private static Template _groupExampleGroup2;
        public static Template GroupExampleGroup2
        {
            get
            {
#if UNITY_EDITOR
                if (_groupExampleGroup2 == null || _groupExampleGroup2.CurrentVersion != Template.Version)
#else
                if (_groupExampleGroup2 == null)
#endif
                {
                    _groupExampleGroup2 = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _groupExampleGroup2.Name = "GroupExampleGroup2";
                    _groupExampleGroup2.LineNumber = 12;
                    _groupExampleGroup2.LinePosition = 4;
#endif
                    Delight.Group.OrientationProperty.SetDefault(_groupExampleGroup2, Delight.ElementOrientation.Horizontal);
                    Delight.Group.SpacingProperty.SetDefault(_groupExampleGroup2, new ElementSize(4f, ElementSizeUnit.Pixels));
                    Delight.Group.ContentAlignmentProperty.SetDefault(_groupExampleGroup2, Delight.ElementAlignment.Top);
                }
                return _groupExampleGroup2;
            }
        }

        private static Template _groupExampleButton4;
        public static Template GroupExampleButton4
        {
            get
            {
#if UNITY_EDITOR
                if (_groupExampleButton4 == null || _groupExampleButton4.CurrentVersion != Template.Version)
#else
                if (_groupExampleButton4 == null)
#endif
                {
                    _groupExampleButton4 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _groupExampleButton4.Name = "GroupExampleButton4";
                    _groupExampleButton4.LineNumber = 13;
                    _groupExampleButton4.LinePosition = 6;
#endif
                    Delight.Button.WidthProperty.SetDefault(_groupExampleButton4, new ElementSize(75f, ElementSizeUnit.Pixels));
                    Delight.Button.HeightProperty.SetDefault(_groupExampleButton4, new ElementSize(40f, ElementSizeUnit.Pixels));
                    Delight.Button.LabelTemplateProperty.SetDefault(_groupExampleButton4, GroupExampleButton4Label);
                }
                return _groupExampleButton4;
            }
        }

        private static Template _groupExampleButton4Label;
        public static Template GroupExampleButton4Label
        {
            get
            {
#if UNITY_EDITOR
                if (_groupExampleButton4Label == null || _groupExampleButton4Label.CurrentVersion != Template.Version)
#else
                if (_groupExampleButton4Label == null)
#endif
                {
                    _groupExampleButton4Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _groupExampleButton4Label.Name = "GroupExampleButton4Label";
                    _groupExampleButton4Label.LineNumber = 15;
                    _groupExampleButton4Label.LinePosition = 4;
#endif
                    Delight.Label.TextProperty.SetDefault(_groupExampleButton4Label, "Button 1");
                }
                return _groupExampleButton4Label;
            }
        }

        private static Template _groupExampleButton5;
        public static Template GroupExampleButton5
        {
            get
            {
#if UNITY_EDITOR
                if (_groupExampleButton5 == null || _groupExampleButton5.CurrentVersion != Template.Version)
#else
                if (_groupExampleButton5 == null)
#endif
                {
                    _groupExampleButton5 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _groupExampleButton5.Name = "GroupExampleButton5";
                    _groupExampleButton5.LineNumber = 14;
                    _groupExampleButton5.LinePosition = 6;
#endif
                    Delight.Button.WidthProperty.SetDefault(_groupExampleButton5, new ElementSize(175f, ElementSizeUnit.Pixels));
                    Delight.Button.HeightProperty.SetDefault(_groupExampleButton5, new ElementSize(70f, ElementSizeUnit.Pixels));
                    Delight.Button.LabelTemplateProperty.SetDefault(_groupExampleButton5, GroupExampleButton5Label);
                }
                return _groupExampleButton5;
            }
        }

        private static Template _groupExampleButton5Label;
        public static Template GroupExampleButton5Label
        {
            get
            {
#if UNITY_EDITOR
                if (_groupExampleButton5Label == null || _groupExampleButton5Label.CurrentVersion != Template.Version)
#else
                if (_groupExampleButton5Label == null)
#endif
                {
                    _groupExampleButton5Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _groupExampleButton5Label.Name = "GroupExampleButton5Label";
                    _groupExampleButton5Label.LineNumber = 15;
                    _groupExampleButton5Label.LinePosition = 4;
#endif
                    Delight.Label.TextProperty.SetDefault(_groupExampleButton5Label, "Large Button 2");
                }
                return _groupExampleButton5Label;
            }
        }

        private static Template _groupExampleButton6;
        public static Template GroupExampleButton6
        {
            get
            {
#if UNITY_EDITOR
                if (_groupExampleButton6 == null || _groupExampleButton6.CurrentVersion != Template.Version)
#else
                if (_groupExampleButton6 == null)
#endif
                {
                    _groupExampleButton6 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _groupExampleButton6.Name = "GroupExampleButton6";
                    _groupExampleButton6.LineNumber = 15;
                    _groupExampleButton6.LinePosition = 6;
#endif
                    Delight.Button.WidthProperty.SetDefault(_groupExampleButton6, new ElementSize(75f, ElementSizeUnit.Pixels));
                    Delight.Button.HeightProperty.SetDefault(_groupExampleButton6, new ElementSize(40f, ElementSizeUnit.Pixels));
                    Delight.Button.LabelTemplateProperty.SetDefault(_groupExampleButton6, GroupExampleButton6Label);
                }
                return _groupExampleButton6;
            }
        }

        private static Template _groupExampleButton6Label;
        public static Template GroupExampleButton6Label
        {
            get
            {
#if UNITY_EDITOR
                if (_groupExampleButton6Label == null || _groupExampleButton6Label.CurrentVersion != Template.Version)
#else
                if (_groupExampleButton6Label == null)
#endif
                {
                    _groupExampleButton6Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _groupExampleButton6Label.Name = "GroupExampleButton6Label";
                    _groupExampleButton6Label.LineNumber = 15;
                    _groupExampleButton6Label.LinePosition = 4;
#endif
                    Delight.Label.TextProperty.SetDefault(_groupExampleButton6Label, "Button 3");
                }
                return _groupExampleButton6Label;
            }
        }

        private static Template _groupExampleLabel3;
        public static Template GroupExampleLabel3
        {
            get
            {
#if UNITY_EDITOR
                if (_groupExampleLabel3 == null || _groupExampleLabel3.CurrentVersion != Template.Version)
#else
                if (_groupExampleLabel3 == null)
#endif
                {
                    _groupExampleLabel3 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _groupExampleLabel3.Name = "GroupExampleLabel3";
                    _groupExampleLabel3.LineNumber = 18;
                    _groupExampleLabel3.LinePosition = 4;
#endif
                    Delight.Label.TextProperty.SetDefault(_groupExampleLabel3, "Group 3:");
                    Delight.Label.AutoSizeProperty.SetDefault(_groupExampleLabel3, Delight.AutoSize.Default);
                    Delight.Label.FontColorProperty.SetDefault(_groupExampleLabel3, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Label.OffsetProperty.SetDefault(_groupExampleLabel3, new ElementMargin(new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(100f, ElementSizeUnit.Pixels), new ElementSize(250f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels)));
                }
                return _groupExampleLabel3;
            }
        }

        private static Template _groupExampleGroup3;
        public static Template GroupExampleGroup3
        {
            get
            {
#if UNITY_EDITOR
                if (_groupExampleGroup3 == null || _groupExampleGroup3.CurrentVersion != Template.Version)
#else
                if (_groupExampleGroup3 == null)
#endif
                {
                    _groupExampleGroup3 = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _groupExampleGroup3.Name = "GroupExampleGroup3";
                    _groupExampleGroup3.LineNumber = 19;
                    _groupExampleGroup3.LinePosition = 4;
#endif
                    Delight.Group.OrientationProperty.SetDefault(_groupExampleGroup3, Delight.ElementOrientation.Horizontal);
                    Delight.Group.SpacingProperty.SetDefault(_groupExampleGroup3, new ElementSize(4f, ElementSizeUnit.Pixels));
                    Delight.Group.ContentAlignmentProperty.SetDefault(_groupExampleGroup3, Delight.ElementAlignment.Bottom);
                    Delight.Group.OffsetProperty.SetDefault(_groupExampleGroup3, new ElementMargin(new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(100f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels)));
                }
                return _groupExampleGroup3;
            }
        }

        private static Template _groupExampleButton7;
        public static Template GroupExampleButton7
        {
            get
            {
#if UNITY_EDITOR
                if (_groupExampleButton7 == null || _groupExampleButton7.CurrentVersion != Template.Version)
#else
                if (_groupExampleButton7 == null)
#endif
                {
                    _groupExampleButton7 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _groupExampleButton7.Name = "GroupExampleButton7";
                    _groupExampleButton7.LineNumber = 20;
                    _groupExampleButton7.LinePosition = 6;
#endif
                    Delight.Button.WidthProperty.SetDefault(_groupExampleButton7, new ElementSize(75f, ElementSizeUnit.Pixels));
                    Delight.Button.HeightProperty.SetDefault(_groupExampleButton7, new ElementSize(40f, ElementSizeUnit.Pixels));
                    Delight.Button.LabelTemplateProperty.SetDefault(_groupExampleButton7, GroupExampleButton7Label);
                }
                return _groupExampleButton7;
            }
        }

        private static Template _groupExampleButton7Label;
        public static Template GroupExampleButton7Label
        {
            get
            {
#if UNITY_EDITOR
                if (_groupExampleButton7Label == null || _groupExampleButton7Label.CurrentVersion != Template.Version)
#else
                if (_groupExampleButton7Label == null)
#endif
                {
                    _groupExampleButton7Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _groupExampleButton7Label.Name = "GroupExampleButton7Label";
                    _groupExampleButton7Label.LineNumber = 15;
                    _groupExampleButton7Label.LinePosition = 4;
#endif
                    Delight.Label.TextProperty.SetDefault(_groupExampleButton7Label, "Button 1");
                }
                return _groupExampleButton7Label;
            }
        }

        private static Template _groupExampleButton8;
        public static Template GroupExampleButton8
        {
            get
            {
#if UNITY_EDITOR
                if (_groupExampleButton8 == null || _groupExampleButton8.CurrentVersion != Template.Version)
#else
                if (_groupExampleButton8 == null)
#endif
                {
                    _groupExampleButton8 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _groupExampleButton8.Name = "GroupExampleButton8";
                    _groupExampleButton8.LineNumber = 21;
                    _groupExampleButton8.LinePosition = 6;
#endif
                    Delight.Button.WidthProperty.SetDefault(_groupExampleButton8, new ElementSize(175f, ElementSizeUnit.Pixels));
                    Delight.Button.HeightProperty.SetDefault(_groupExampleButton8, new ElementSize(70f, ElementSizeUnit.Pixels));
                    Delight.Button.LabelTemplateProperty.SetDefault(_groupExampleButton8, GroupExampleButton8Label);
                }
                return _groupExampleButton8;
            }
        }

        private static Template _groupExampleButton8Label;
        public static Template GroupExampleButton8Label
        {
            get
            {
#if UNITY_EDITOR
                if (_groupExampleButton8Label == null || _groupExampleButton8Label.CurrentVersion != Template.Version)
#else
                if (_groupExampleButton8Label == null)
#endif
                {
                    _groupExampleButton8Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _groupExampleButton8Label.Name = "GroupExampleButton8Label";
                    _groupExampleButton8Label.LineNumber = 15;
                    _groupExampleButton8Label.LinePosition = 4;
#endif
                    Delight.Label.TextProperty.SetDefault(_groupExampleButton8Label, "Large Button 2");
                }
                return _groupExampleButton8Label;
            }
        }

        private static Template _groupExampleButton9;
        public static Template GroupExampleButton9
        {
            get
            {
#if UNITY_EDITOR
                if (_groupExampleButton9 == null || _groupExampleButton9.CurrentVersion != Template.Version)
#else
                if (_groupExampleButton9 == null)
#endif
                {
                    _groupExampleButton9 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _groupExampleButton9.Name = "GroupExampleButton9";
                    _groupExampleButton9.LineNumber = 22;
                    _groupExampleButton9.LinePosition = 6;
#endif
                    Delight.Button.WidthProperty.SetDefault(_groupExampleButton9, new ElementSize(75f, ElementSizeUnit.Pixels));
                    Delight.Button.HeightProperty.SetDefault(_groupExampleButton9, new ElementSize(40f, ElementSizeUnit.Pixels));
                    Delight.Button.LabelTemplateProperty.SetDefault(_groupExampleButton9, GroupExampleButton9Label);
                }
                return _groupExampleButton9;
            }
        }

        private static Template _groupExampleButton9Label;
        public static Template GroupExampleButton9Label
        {
            get
            {
#if UNITY_EDITOR
                if (_groupExampleButton9Label == null || _groupExampleButton9Label.CurrentVersion != Template.Version)
#else
                if (_groupExampleButton9Label == null)
#endif
                {
                    _groupExampleButton9Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _groupExampleButton9Label.Name = "GroupExampleButton9Label";
                    _groupExampleButton9Label.LineNumber = 15;
                    _groupExampleButton9Label.LinePosition = 4;
#endif
                    Delight.Label.TextProperty.SetDefault(_groupExampleButton9Label, "Button 3");
                }
                return _groupExampleButton9Label;
            }
        }

        #endregion
    }

    #endregion
}
