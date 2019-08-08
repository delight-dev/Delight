// Internal view logic generated from "ComboBoxExample.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class ComboBoxExample : LayoutRoot
    {
        #region Constructors

        public ComboBoxExample(View parent, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :
            base(parent, layoutParent, id, template ?? ComboBoxExampleTemplates.Default, initializer)
        {
            // constructing Group (Group1)
            Group1 = new Group(this, this, "Group1", Group1Template);
            Group2 = new Group(this, Group1.Content, "Group2", Group2Template);
            Group3 = new Group(this, Group2.Content, "Group3", Group3Template);
            CheckBox1 = new CheckBox(this, Group3.Content, "CheckBox1", CheckBox1Template);
            CheckBox2 = new CheckBox(this, Group3.Content, "CheckBox2", CheckBox2Template);
            CheckBox3 = new CheckBox(this, Group3.Content, "CheckBox3", CheckBox3Template);
            Group4 = new Group(this, Group2.Content, "Group4", Group4Template);
            RadioButton1 = new RadioButton(this, Group4.Content, "RadioButton1", RadioButton1Template);
            RadioButton2 = new RadioButton(this, Group4.Content, "RadioButton2", RadioButton2Template);
            RadioButton3 = new RadioButton(this, Group4.Content, "RadioButton3", RadioButton3Template);
            Group5 = new Group(this, Group1.Content, "Group5", Group5Template);
            Button1 = new Button(this, Group5.Content, "Button1", Button1Template);
            Button1.Click.RegisterHandler(this, "Add");
            Button2 = new Button(this, Group5.Content, "Button2", Button2Template);
            Button2.Click.RegisterHandler(this, "Remove");
            ComboBox = new ComboBox(this, Group1.Content, "ComboBox", ComboBoxTemplate);
            ComboBox.ItemSelected.RegisterHandler(this, "ItemSelected");

            // binding <ComboBox Items="{player in @Players}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> {  }, new List<Func<BindableObject>> {  }) }, new BindingPath(new List<string> { "ComboBox", "Items" }, new List<Func<BindableObject>> { () => this, () => ComboBox }), () => ComboBox.Items = Models.Players, () => { }, false));

            // templates for ComboBox
            ComboBox.ContentTemplates.Add(new ContentTemplate(tiPlayer => 
            {
                var comboBoxContent = new ComboBoxListItem(this, ComboBox.Content, "ComboBoxContent", ComboBoxContentTemplate);
                var label1 = new Label(this, comboBoxContent.Content, "Label1", Label1Template);

                // binding <Label Text="{player.Name}">
                comboBoxContent.Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "Item", "Name" }, new List<Func<BindableObject>> { () => tiPlayer, () => (tiPlayer.Item as Delight.Player) }) }, new BindingPath(new List<string> { "Text" }, new List<Func<BindableObject>> { () => label1 }), () => label1.Text = (tiPlayer.Item as Delight.Player).Name, () => { }, false));
                comboBoxContent.IsDynamic = true;
                comboBoxContent.SetContentTemplateData(tiPlayer);
                return comboBoxContent;
            }, typeof(ComboBoxListItem), "ComboBoxContent"));
            this.AfterInitializeInternal();
        }

        public ComboBoxExample() : this(null)
        {
        }

        static ComboBoxExample()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(ComboBoxExampleTemplates.Default, dependencyProperties);

            dependencyProperties.Add(Group1Property);
            dependencyProperties.Add(Group1TemplateProperty);
            dependencyProperties.Add(Group2Property);
            dependencyProperties.Add(Group2TemplateProperty);
            dependencyProperties.Add(Group3Property);
            dependencyProperties.Add(Group3TemplateProperty);
            dependencyProperties.Add(CheckBox1Property);
            dependencyProperties.Add(CheckBox1TemplateProperty);
            dependencyProperties.Add(CheckBox2Property);
            dependencyProperties.Add(CheckBox2TemplateProperty);
            dependencyProperties.Add(CheckBox3Property);
            dependencyProperties.Add(CheckBox3TemplateProperty);
            dependencyProperties.Add(Group4Property);
            dependencyProperties.Add(Group4TemplateProperty);
            dependencyProperties.Add(RadioButton1Property);
            dependencyProperties.Add(RadioButton1TemplateProperty);
            dependencyProperties.Add(RadioButton2Property);
            dependencyProperties.Add(RadioButton2TemplateProperty);
            dependencyProperties.Add(RadioButton3Property);
            dependencyProperties.Add(RadioButton3TemplateProperty);
            dependencyProperties.Add(Group5Property);
            dependencyProperties.Add(Group5TemplateProperty);
            dependencyProperties.Add(Button1Property);
            dependencyProperties.Add(Button1TemplateProperty);
            dependencyProperties.Add(Button2Property);
            dependencyProperties.Add(Button2TemplateProperty);
            dependencyProperties.Add(ComboBoxProperty);
            dependencyProperties.Add(ComboBoxTemplateProperty);
            dependencyProperties.Add(Label1Property);
            dependencyProperties.Add(Label1TemplateProperty);
            dependencyProperties.Add(ComboBoxContentProperty);
            dependencyProperties.Add(ComboBoxContentTemplateProperty);
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

        public readonly static DependencyProperty<CheckBox> CheckBox1Property = new DependencyProperty<CheckBox>("CheckBox1");
        public CheckBox CheckBox1
        {
            get { return CheckBox1Property.GetValue(this); }
            set { CheckBox1Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> CheckBox1TemplateProperty = new DependencyProperty<Template>("CheckBox1Template");
        public Template CheckBox1Template
        {
            get { return CheckBox1TemplateProperty.GetValue(this); }
            set { CheckBox1TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<CheckBox> CheckBox2Property = new DependencyProperty<CheckBox>("CheckBox2");
        public CheckBox CheckBox2
        {
            get { return CheckBox2Property.GetValue(this); }
            set { CheckBox2Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> CheckBox2TemplateProperty = new DependencyProperty<Template>("CheckBox2Template");
        public Template CheckBox2Template
        {
            get { return CheckBox2TemplateProperty.GetValue(this); }
            set { CheckBox2TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<CheckBox> CheckBox3Property = new DependencyProperty<CheckBox>("CheckBox3");
        public CheckBox CheckBox3
        {
            get { return CheckBox3Property.GetValue(this); }
            set { CheckBox3Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> CheckBox3TemplateProperty = new DependencyProperty<Template>("CheckBox3Template");
        public Template CheckBox3Template
        {
            get { return CheckBox3TemplateProperty.GetValue(this); }
            set { CheckBox3TemplateProperty.SetValue(this, value); }
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

        public readonly static DependencyProperty<RadioButton> RadioButton1Property = new DependencyProperty<RadioButton>("RadioButton1");
        public RadioButton RadioButton1
        {
            get { return RadioButton1Property.GetValue(this); }
            set { RadioButton1Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> RadioButton1TemplateProperty = new DependencyProperty<Template>("RadioButton1Template");
        public Template RadioButton1Template
        {
            get { return RadioButton1TemplateProperty.GetValue(this); }
            set { RadioButton1TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<RadioButton> RadioButton2Property = new DependencyProperty<RadioButton>("RadioButton2");
        public RadioButton RadioButton2
        {
            get { return RadioButton2Property.GetValue(this); }
            set { RadioButton2Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> RadioButton2TemplateProperty = new DependencyProperty<Template>("RadioButton2Template");
        public Template RadioButton2Template
        {
            get { return RadioButton2TemplateProperty.GetValue(this); }
            set { RadioButton2TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<RadioButton> RadioButton3Property = new DependencyProperty<RadioButton>("RadioButton3");
        public RadioButton RadioButton3
        {
            get { return RadioButton3Property.GetValue(this); }
            set { RadioButton3Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> RadioButton3TemplateProperty = new DependencyProperty<Template>("RadioButton3Template");
        public Template RadioButton3Template
        {
            get { return RadioButton3TemplateProperty.GetValue(this); }
            set { RadioButton3TemplateProperty.SetValue(this, value); }
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

        public readonly static DependencyProperty<ComboBox> ComboBoxProperty = new DependencyProperty<ComboBox>("ComboBox");
        public ComboBox ComboBox
        {
            get { return ComboBoxProperty.GetValue(this); }
            set { ComboBoxProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> ComboBoxTemplateProperty = new DependencyProperty<Template>("ComboBoxTemplate");
        public Template ComboBoxTemplate
        {
            get { return ComboBoxTemplateProperty.GetValue(this); }
            set { ComboBoxTemplateProperty.SetValue(this, value); }
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

        public readonly static DependencyProperty<ComboBoxListItem> ComboBoxContentProperty = new DependencyProperty<ComboBoxListItem>("ComboBoxContent");
        public ComboBoxListItem ComboBoxContent
        {
            get { return ComboBoxContentProperty.GetValue(this); }
            set { ComboBoxContentProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> ComboBoxContentTemplateProperty = new DependencyProperty<Template>("ComboBoxContentTemplate");
        public Template ComboBoxContentTemplate
        {
            get { return ComboBoxContentTemplateProperty.GetValue(this); }
            set { ComboBoxContentTemplateProperty.SetValue(this, value); }
        }

        #endregion
    }

    #region Data Templates

    public static class ComboBoxExampleTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return ComboBoxExample;
            }
        }

        private static Template _comboBoxExample;
        public static Template ComboBoxExample
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxExample == null || _comboBoxExample.CurrentVersion != Template.Version)
#else
                if (_comboBoxExample == null)
#endif
                {
                    _comboBoxExample = new Template(LayoutRootTemplates.LayoutRoot);
#if UNITY_EDITOR
                    _comboBoxExample.Name = "ComboBoxExample";
#endif
                    Delight.ComboBoxExample.Group1TemplateProperty.SetDefault(_comboBoxExample, ComboBoxExampleGroup1);
                    Delight.ComboBoxExample.Group2TemplateProperty.SetDefault(_comboBoxExample, ComboBoxExampleGroup2);
                    Delight.ComboBoxExample.Group3TemplateProperty.SetDefault(_comboBoxExample, ComboBoxExampleGroup3);
                    Delight.ComboBoxExample.CheckBox1TemplateProperty.SetDefault(_comboBoxExample, ComboBoxExampleCheckBox1);
                    Delight.ComboBoxExample.CheckBox2TemplateProperty.SetDefault(_comboBoxExample, ComboBoxExampleCheckBox2);
                    Delight.ComboBoxExample.CheckBox3TemplateProperty.SetDefault(_comboBoxExample, ComboBoxExampleCheckBox3);
                    Delight.ComboBoxExample.Group4TemplateProperty.SetDefault(_comboBoxExample, ComboBoxExampleGroup4);
                    Delight.ComboBoxExample.RadioButton1TemplateProperty.SetDefault(_comboBoxExample, ComboBoxExampleRadioButton1);
                    Delight.ComboBoxExample.RadioButton2TemplateProperty.SetDefault(_comboBoxExample, ComboBoxExampleRadioButton2);
                    Delight.ComboBoxExample.RadioButton3TemplateProperty.SetDefault(_comboBoxExample, ComboBoxExampleRadioButton3);
                    Delight.ComboBoxExample.Group5TemplateProperty.SetDefault(_comboBoxExample, ComboBoxExampleGroup5);
                    Delight.ComboBoxExample.Button1TemplateProperty.SetDefault(_comboBoxExample, ComboBoxExampleButton1);
                    Delight.ComboBoxExample.Button2TemplateProperty.SetDefault(_comboBoxExample, ComboBoxExampleButton2);
                    Delight.ComboBoxExample.ComboBoxTemplateProperty.SetDefault(_comboBoxExample, ComboBoxExampleComboBox);
                    Delight.ComboBoxExample.ComboBoxContentTemplateProperty.SetDefault(_comboBoxExample, ComboBoxExampleComboBoxContent);
                    Delight.ComboBoxExample.Label1TemplateProperty.SetDefault(_comboBoxExample, ComboBoxExampleLabel1);
                }
                return _comboBoxExample;
            }
        }

        private static Template _comboBoxExampleGroup1;
        public static Template ComboBoxExampleGroup1
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxExampleGroup1 == null || _comboBoxExampleGroup1.CurrentVersion != Template.Version)
#else
                if (_comboBoxExampleGroup1 == null)
#endif
                {
                    _comboBoxExampleGroup1 = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _comboBoxExampleGroup1.Name = "ComboBoxExampleGroup1";
#endif
                    Delight.Group.OrientationProperty.SetDefault(_comboBoxExampleGroup1, Delight.ElementOrientation.Vertical);
                    Delight.Group.SpacingProperty.SetDefault(_comboBoxExampleGroup1, new ElementSize(15f, ElementSizeUnit.Pixels));
                    Delight.Group.ContentAlignmentProperty.SetDefault(_comboBoxExampleGroup1, Delight.ElementAlignment.Left);
                }
                return _comboBoxExampleGroup1;
            }
        }

        private static Template _comboBoxExampleGroup2;
        public static Template ComboBoxExampleGroup2
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxExampleGroup2 == null || _comboBoxExampleGroup2.CurrentVersion != Template.Version)
#else
                if (_comboBoxExampleGroup2 == null)
#endif
                {
                    _comboBoxExampleGroup2 = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _comboBoxExampleGroup2.Name = "ComboBoxExampleGroup2";
#endif
                    Delight.Group.OrientationProperty.SetDefault(_comboBoxExampleGroup2, Delight.ElementOrientation.Horizontal);
                    Delight.Group.SpacingProperty.SetDefault(_comboBoxExampleGroup2, new ElementSize(50f, ElementSizeUnit.Pixels));
                }
                return _comboBoxExampleGroup2;
            }
        }

        private static Template _comboBoxExampleGroup3;
        public static Template ComboBoxExampleGroup3
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxExampleGroup3 == null || _comboBoxExampleGroup3.CurrentVersion != Template.Version)
#else
                if (_comboBoxExampleGroup3 == null)
#endif
                {
                    _comboBoxExampleGroup3 = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _comboBoxExampleGroup3.Name = "ComboBoxExampleGroup3";
#endif
                    Delight.Group.SpacingProperty.SetDefault(_comboBoxExampleGroup3, new ElementSize(10f, ElementSizeUnit.Pixels));
                    Delight.Group.ContentAlignmentProperty.SetDefault(_comboBoxExampleGroup3, Delight.ElementAlignment.Left);
                }
                return _comboBoxExampleGroup3;
            }
        }

        private static Template _comboBoxExampleCheckBox1;
        public static Template ComboBoxExampleCheckBox1
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxExampleCheckBox1 == null || _comboBoxExampleCheckBox1.CurrentVersion != Template.Version)
#else
                if (_comboBoxExampleCheckBox1 == null)
#endif
                {
                    _comboBoxExampleCheckBox1 = new Template(CheckBoxTemplates.CheckBox);
#if UNITY_EDITOR
                    _comboBoxExampleCheckBox1.Name = "ComboBoxExampleCheckBox1";
#endif
                    Delight.CheckBox.CheckBoxGroupTemplateProperty.SetDefault(_comboBoxExampleCheckBox1, ComboBoxExampleCheckBox1CheckBoxGroup);
                    Delight.CheckBox.CheckBoxImageViewTemplateProperty.SetDefault(_comboBoxExampleCheckBox1, ComboBoxExampleCheckBox1CheckBoxImageView);
                    Delight.CheckBox.CheckBoxLabelTemplateProperty.SetDefault(_comboBoxExampleCheckBox1, ComboBoxExampleCheckBox1CheckBoxLabel);
                }
                return _comboBoxExampleCheckBox1;
            }
        }

        private static Template _comboBoxExampleCheckBox1CheckBoxGroup;
        public static Template ComboBoxExampleCheckBox1CheckBoxGroup
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxExampleCheckBox1CheckBoxGroup == null || _comboBoxExampleCheckBox1CheckBoxGroup.CurrentVersion != Template.Version)
#else
                if (_comboBoxExampleCheckBox1CheckBoxGroup == null)
#endif
                {
                    _comboBoxExampleCheckBox1CheckBoxGroup = new Template(CheckBoxTemplates.CheckBoxCheckBoxGroup);
#if UNITY_EDITOR
                    _comboBoxExampleCheckBox1CheckBoxGroup.Name = "ComboBoxExampleCheckBox1CheckBoxGroup";
#endif
                }
                return _comboBoxExampleCheckBox1CheckBoxGroup;
            }
        }

        private static Template _comboBoxExampleCheckBox1CheckBoxImageView;
        public static Template ComboBoxExampleCheckBox1CheckBoxImageView
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxExampleCheckBox1CheckBoxImageView == null || _comboBoxExampleCheckBox1CheckBoxImageView.CurrentVersion != Template.Version)
#else
                if (_comboBoxExampleCheckBox1CheckBoxImageView == null)
#endif
                {
                    _comboBoxExampleCheckBox1CheckBoxImageView = new Template(CheckBoxTemplates.CheckBoxCheckBoxImageView);
#if UNITY_EDITOR
                    _comboBoxExampleCheckBox1CheckBoxImageView.Name = "ComboBoxExampleCheckBox1CheckBoxImageView";
#endif
                }
                return _comboBoxExampleCheckBox1CheckBoxImageView;
            }
        }

        private static Template _comboBoxExampleCheckBox1CheckBoxLabel;
        public static Template ComboBoxExampleCheckBox1CheckBoxLabel
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxExampleCheckBox1CheckBoxLabel == null || _comboBoxExampleCheckBox1CheckBoxLabel.CurrentVersion != Template.Version)
#else
                if (_comboBoxExampleCheckBox1CheckBoxLabel == null)
#endif
                {
                    _comboBoxExampleCheckBox1CheckBoxLabel = new Template(CheckBoxTemplates.CheckBoxCheckBoxLabel);
#if UNITY_EDITOR
                    _comboBoxExampleCheckBox1CheckBoxLabel.Name = "ComboBoxExampleCheckBox1CheckBoxLabel";
#endif
                    Delight.Label.TextProperty.SetDefault(_comboBoxExampleCheckBox1CheckBoxLabel, "Option 1");
                }
                return _comboBoxExampleCheckBox1CheckBoxLabel;
            }
        }

        private static Template _comboBoxExampleCheckBox2;
        public static Template ComboBoxExampleCheckBox2
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxExampleCheckBox2 == null || _comboBoxExampleCheckBox2.CurrentVersion != Template.Version)
#else
                if (_comboBoxExampleCheckBox2 == null)
#endif
                {
                    _comboBoxExampleCheckBox2 = new Template(CheckBoxTemplates.CheckBox);
#if UNITY_EDITOR
                    _comboBoxExampleCheckBox2.Name = "ComboBoxExampleCheckBox2";
#endif
                    Delight.CheckBox.CheckBoxGroupTemplateProperty.SetDefault(_comboBoxExampleCheckBox2, ComboBoxExampleCheckBox2CheckBoxGroup);
                    Delight.CheckBox.CheckBoxImageViewTemplateProperty.SetDefault(_comboBoxExampleCheckBox2, ComboBoxExampleCheckBox2CheckBoxImageView);
                    Delight.CheckBox.CheckBoxLabelTemplateProperty.SetDefault(_comboBoxExampleCheckBox2, ComboBoxExampleCheckBox2CheckBoxLabel);
                }
                return _comboBoxExampleCheckBox2;
            }
        }

        private static Template _comboBoxExampleCheckBox2CheckBoxGroup;
        public static Template ComboBoxExampleCheckBox2CheckBoxGroup
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxExampleCheckBox2CheckBoxGroup == null || _comboBoxExampleCheckBox2CheckBoxGroup.CurrentVersion != Template.Version)
#else
                if (_comboBoxExampleCheckBox2CheckBoxGroup == null)
#endif
                {
                    _comboBoxExampleCheckBox2CheckBoxGroup = new Template(CheckBoxTemplates.CheckBoxCheckBoxGroup);
#if UNITY_EDITOR
                    _comboBoxExampleCheckBox2CheckBoxGroup.Name = "ComboBoxExampleCheckBox2CheckBoxGroup";
#endif
                }
                return _comboBoxExampleCheckBox2CheckBoxGroup;
            }
        }

        private static Template _comboBoxExampleCheckBox2CheckBoxImageView;
        public static Template ComboBoxExampleCheckBox2CheckBoxImageView
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxExampleCheckBox2CheckBoxImageView == null || _comboBoxExampleCheckBox2CheckBoxImageView.CurrentVersion != Template.Version)
#else
                if (_comboBoxExampleCheckBox2CheckBoxImageView == null)
#endif
                {
                    _comboBoxExampleCheckBox2CheckBoxImageView = new Template(CheckBoxTemplates.CheckBoxCheckBoxImageView);
#if UNITY_EDITOR
                    _comboBoxExampleCheckBox2CheckBoxImageView.Name = "ComboBoxExampleCheckBox2CheckBoxImageView";
#endif
                }
                return _comboBoxExampleCheckBox2CheckBoxImageView;
            }
        }

        private static Template _comboBoxExampleCheckBox2CheckBoxLabel;
        public static Template ComboBoxExampleCheckBox2CheckBoxLabel
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxExampleCheckBox2CheckBoxLabel == null || _comboBoxExampleCheckBox2CheckBoxLabel.CurrentVersion != Template.Version)
#else
                if (_comboBoxExampleCheckBox2CheckBoxLabel == null)
#endif
                {
                    _comboBoxExampleCheckBox2CheckBoxLabel = new Template(CheckBoxTemplates.CheckBoxCheckBoxLabel);
#if UNITY_EDITOR
                    _comboBoxExampleCheckBox2CheckBoxLabel.Name = "ComboBoxExampleCheckBox2CheckBoxLabel";
#endif
                    Delight.Label.TextProperty.SetDefault(_comboBoxExampleCheckBox2CheckBoxLabel, "Option 2");
                }
                return _comboBoxExampleCheckBox2CheckBoxLabel;
            }
        }

        private static Template _comboBoxExampleCheckBox3;
        public static Template ComboBoxExampleCheckBox3
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxExampleCheckBox3 == null || _comboBoxExampleCheckBox3.CurrentVersion != Template.Version)
#else
                if (_comboBoxExampleCheckBox3 == null)
#endif
                {
                    _comboBoxExampleCheckBox3 = new Template(CheckBoxTemplates.CheckBox);
#if UNITY_EDITOR
                    _comboBoxExampleCheckBox3.Name = "ComboBoxExampleCheckBox3";
#endif
                    Delight.CheckBox.CheckBoxGroupTemplateProperty.SetDefault(_comboBoxExampleCheckBox3, ComboBoxExampleCheckBox3CheckBoxGroup);
                    Delight.CheckBox.CheckBoxImageViewTemplateProperty.SetDefault(_comboBoxExampleCheckBox3, ComboBoxExampleCheckBox3CheckBoxImageView);
                    Delight.CheckBox.CheckBoxLabelTemplateProperty.SetDefault(_comboBoxExampleCheckBox3, ComboBoxExampleCheckBox3CheckBoxLabel);
                }
                return _comboBoxExampleCheckBox3;
            }
        }

        private static Template _comboBoxExampleCheckBox3CheckBoxGroup;
        public static Template ComboBoxExampleCheckBox3CheckBoxGroup
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxExampleCheckBox3CheckBoxGroup == null || _comboBoxExampleCheckBox3CheckBoxGroup.CurrentVersion != Template.Version)
#else
                if (_comboBoxExampleCheckBox3CheckBoxGroup == null)
#endif
                {
                    _comboBoxExampleCheckBox3CheckBoxGroup = new Template(CheckBoxTemplates.CheckBoxCheckBoxGroup);
#if UNITY_EDITOR
                    _comboBoxExampleCheckBox3CheckBoxGroup.Name = "ComboBoxExampleCheckBox3CheckBoxGroup";
#endif
                }
                return _comboBoxExampleCheckBox3CheckBoxGroup;
            }
        }

        private static Template _comboBoxExampleCheckBox3CheckBoxImageView;
        public static Template ComboBoxExampleCheckBox3CheckBoxImageView
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxExampleCheckBox3CheckBoxImageView == null || _comboBoxExampleCheckBox3CheckBoxImageView.CurrentVersion != Template.Version)
#else
                if (_comboBoxExampleCheckBox3CheckBoxImageView == null)
#endif
                {
                    _comboBoxExampleCheckBox3CheckBoxImageView = new Template(CheckBoxTemplates.CheckBoxCheckBoxImageView);
#if UNITY_EDITOR
                    _comboBoxExampleCheckBox3CheckBoxImageView.Name = "ComboBoxExampleCheckBox3CheckBoxImageView";
#endif
                }
                return _comboBoxExampleCheckBox3CheckBoxImageView;
            }
        }

        private static Template _comboBoxExampleCheckBox3CheckBoxLabel;
        public static Template ComboBoxExampleCheckBox3CheckBoxLabel
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxExampleCheckBox3CheckBoxLabel == null || _comboBoxExampleCheckBox3CheckBoxLabel.CurrentVersion != Template.Version)
#else
                if (_comboBoxExampleCheckBox3CheckBoxLabel == null)
#endif
                {
                    _comboBoxExampleCheckBox3CheckBoxLabel = new Template(CheckBoxTemplates.CheckBoxCheckBoxLabel);
#if UNITY_EDITOR
                    _comboBoxExampleCheckBox3CheckBoxLabel.Name = "ComboBoxExampleCheckBox3CheckBoxLabel";
#endif
                    Delight.Label.TextProperty.SetDefault(_comboBoxExampleCheckBox3CheckBoxLabel, "Option 3");
                }
                return _comboBoxExampleCheckBox3CheckBoxLabel;
            }
        }

        private static Template _comboBoxExampleGroup4;
        public static Template ComboBoxExampleGroup4
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxExampleGroup4 == null || _comboBoxExampleGroup4.CurrentVersion != Template.Version)
#else
                if (_comboBoxExampleGroup4 == null)
#endif
                {
                    _comboBoxExampleGroup4 = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _comboBoxExampleGroup4.Name = "ComboBoxExampleGroup4";
#endif
                    Delight.Group.SpacingProperty.SetDefault(_comboBoxExampleGroup4, new ElementSize(10f, ElementSizeUnit.Pixels));
                    Delight.Group.ContentAlignmentProperty.SetDefault(_comboBoxExampleGroup4, Delight.ElementAlignment.Left);
                }
                return _comboBoxExampleGroup4;
            }
        }

        private static Template _comboBoxExampleRadioButton1;
        public static Template ComboBoxExampleRadioButton1
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxExampleRadioButton1 == null || _comboBoxExampleRadioButton1.CurrentVersion != Template.Version)
#else
                if (_comboBoxExampleRadioButton1 == null)
#endif
                {
                    _comboBoxExampleRadioButton1 = new Template(RadioButtonTemplates.RadioButton);
#if UNITY_EDITOR
                    _comboBoxExampleRadioButton1.Name = "ComboBoxExampleRadioButton1";
#endif
                    Delight.RadioButton.RadioButtonGroupTemplateProperty.SetDefault(_comboBoxExampleRadioButton1, ComboBoxExampleRadioButton1RadioButtonGroup);
                    Delight.RadioButton.RadioButtonImageViewTemplateProperty.SetDefault(_comboBoxExampleRadioButton1, ComboBoxExampleRadioButton1RadioButtonImageView);
                    Delight.RadioButton.RadioButtonLabelTemplateProperty.SetDefault(_comboBoxExampleRadioButton1, ComboBoxExampleRadioButton1RadioButtonLabel);
                }
                return _comboBoxExampleRadioButton1;
            }
        }

        private static Template _comboBoxExampleRadioButton1RadioButtonGroup;
        public static Template ComboBoxExampleRadioButton1RadioButtonGroup
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxExampleRadioButton1RadioButtonGroup == null || _comboBoxExampleRadioButton1RadioButtonGroup.CurrentVersion != Template.Version)
#else
                if (_comboBoxExampleRadioButton1RadioButtonGroup == null)
#endif
                {
                    _comboBoxExampleRadioButton1RadioButtonGroup = new Template(RadioButtonTemplates.RadioButtonRadioButtonGroup);
#if UNITY_EDITOR
                    _comboBoxExampleRadioButton1RadioButtonGroup.Name = "ComboBoxExampleRadioButton1RadioButtonGroup";
#endif
                }
                return _comboBoxExampleRadioButton1RadioButtonGroup;
            }
        }

        private static Template _comboBoxExampleRadioButton1RadioButtonImageView;
        public static Template ComboBoxExampleRadioButton1RadioButtonImageView
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxExampleRadioButton1RadioButtonImageView == null || _comboBoxExampleRadioButton1RadioButtonImageView.CurrentVersion != Template.Version)
#else
                if (_comboBoxExampleRadioButton1RadioButtonImageView == null)
#endif
                {
                    _comboBoxExampleRadioButton1RadioButtonImageView = new Template(RadioButtonTemplates.RadioButtonRadioButtonImageView);
#if UNITY_EDITOR
                    _comboBoxExampleRadioButton1RadioButtonImageView.Name = "ComboBoxExampleRadioButton1RadioButtonImageView";
#endif
                }
                return _comboBoxExampleRadioButton1RadioButtonImageView;
            }
        }

        private static Template _comboBoxExampleRadioButton1RadioButtonLabel;
        public static Template ComboBoxExampleRadioButton1RadioButtonLabel
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxExampleRadioButton1RadioButtonLabel == null || _comboBoxExampleRadioButton1RadioButtonLabel.CurrentVersion != Template.Version)
#else
                if (_comboBoxExampleRadioButton1RadioButtonLabel == null)
#endif
                {
                    _comboBoxExampleRadioButton1RadioButtonLabel = new Template(RadioButtonTemplates.RadioButtonRadioButtonLabel);
#if UNITY_EDITOR
                    _comboBoxExampleRadioButton1RadioButtonLabel.Name = "ComboBoxExampleRadioButton1RadioButtonLabel";
#endif
                    Delight.Label.TextProperty.SetDefault(_comboBoxExampleRadioButton1RadioButtonLabel, "Option 1");
                }
                return _comboBoxExampleRadioButton1RadioButtonLabel;
            }
        }

        private static Template _comboBoxExampleRadioButton2;
        public static Template ComboBoxExampleRadioButton2
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxExampleRadioButton2 == null || _comboBoxExampleRadioButton2.CurrentVersion != Template.Version)
#else
                if (_comboBoxExampleRadioButton2 == null)
#endif
                {
                    _comboBoxExampleRadioButton2 = new Template(RadioButtonTemplates.RadioButton);
#if UNITY_EDITOR
                    _comboBoxExampleRadioButton2.Name = "ComboBoxExampleRadioButton2";
#endif
                    Delight.RadioButton.RadioButtonGroupTemplateProperty.SetDefault(_comboBoxExampleRadioButton2, ComboBoxExampleRadioButton2RadioButtonGroup);
                    Delight.RadioButton.RadioButtonImageViewTemplateProperty.SetDefault(_comboBoxExampleRadioButton2, ComboBoxExampleRadioButton2RadioButtonImageView);
                    Delight.RadioButton.RadioButtonLabelTemplateProperty.SetDefault(_comboBoxExampleRadioButton2, ComboBoxExampleRadioButton2RadioButtonLabel);
                }
                return _comboBoxExampleRadioButton2;
            }
        }

        private static Template _comboBoxExampleRadioButton2RadioButtonGroup;
        public static Template ComboBoxExampleRadioButton2RadioButtonGroup
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxExampleRadioButton2RadioButtonGroup == null || _comboBoxExampleRadioButton2RadioButtonGroup.CurrentVersion != Template.Version)
#else
                if (_comboBoxExampleRadioButton2RadioButtonGroup == null)
#endif
                {
                    _comboBoxExampleRadioButton2RadioButtonGroup = new Template(RadioButtonTemplates.RadioButtonRadioButtonGroup);
#if UNITY_EDITOR
                    _comboBoxExampleRadioButton2RadioButtonGroup.Name = "ComboBoxExampleRadioButton2RadioButtonGroup";
#endif
                }
                return _comboBoxExampleRadioButton2RadioButtonGroup;
            }
        }

        private static Template _comboBoxExampleRadioButton2RadioButtonImageView;
        public static Template ComboBoxExampleRadioButton2RadioButtonImageView
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxExampleRadioButton2RadioButtonImageView == null || _comboBoxExampleRadioButton2RadioButtonImageView.CurrentVersion != Template.Version)
#else
                if (_comboBoxExampleRadioButton2RadioButtonImageView == null)
#endif
                {
                    _comboBoxExampleRadioButton2RadioButtonImageView = new Template(RadioButtonTemplates.RadioButtonRadioButtonImageView);
#if UNITY_EDITOR
                    _comboBoxExampleRadioButton2RadioButtonImageView.Name = "ComboBoxExampleRadioButton2RadioButtonImageView";
#endif
                }
                return _comboBoxExampleRadioButton2RadioButtonImageView;
            }
        }

        private static Template _comboBoxExampleRadioButton2RadioButtonLabel;
        public static Template ComboBoxExampleRadioButton2RadioButtonLabel
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxExampleRadioButton2RadioButtonLabel == null || _comboBoxExampleRadioButton2RadioButtonLabel.CurrentVersion != Template.Version)
#else
                if (_comboBoxExampleRadioButton2RadioButtonLabel == null)
#endif
                {
                    _comboBoxExampleRadioButton2RadioButtonLabel = new Template(RadioButtonTemplates.RadioButtonRadioButtonLabel);
#if UNITY_EDITOR
                    _comboBoxExampleRadioButton2RadioButtonLabel.Name = "ComboBoxExampleRadioButton2RadioButtonLabel";
#endif
                    Delight.Label.TextProperty.SetDefault(_comboBoxExampleRadioButton2RadioButtonLabel, "Option 2");
                }
                return _comboBoxExampleRadioButton2RadioButtonLabel;
            }
        }

        private static Template _comboBoxExampleRadioButton3;
        public static Template ComboBoxExampleRadioButton3
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxExampleRadioButton3 == null || _comboBoxExampleRadioButton3.CurrentVersion != Template.Version)
#else
                if (_comboBoxExampleRadioButton3 == null)
#endif
                {
                    _comboBoxExampleRadioButton3 = new Template(RadioButtonTemplates.RadioButton);
#if UNITY_EDITOR
                    _comboBoxExampleRadioButton3.Name = "ComboBoxExampleRadioButton3";
#endif
                    Delight.RadioButton.RadioButtonGroupTemplateProperty.SetDefault(_comboBoxExampleRadioButton3, ComboBoxExampleRadioButton3RadioButtonGroup);
                    Delight.RadioButton.RadioButtonImageViewTemplateProperty.SetDefault(_comboBoxExampleRadioButton3, ComboBoxExampleRadioButton3RadioButtonImageView);
                    Delight.RadioButton.RadioButtonLabelTemplateProperty.SetDefault(_comboBoxExampleRadioButton3, ComboBoxExampleRadioButton3RadioButtonLabel);
                }
                return _comboBoxExampleRadioButton3;
            }
        }

        private static Template _comboBoxExampleRadioButton3RadioButtonGroup;
        public static Template ComboBoxExampleRadioButton3RadioButtonGroup
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxExampleRadioButton3RadioButtonGroup == null || _comboBoxExampleRadioButton3RadioButtonGroup.CurrentVersion != Template.Version)
#else
                if (_comboBoxExampleRadioButton3RadioButtonGroup == null)
#endif
                {
                    _comboBoxExampleRadioButton3RadioButtonGroup = new Template(RadioButtonTemplates.RadioButtonRadioButtonGroup);
#if UNITY_EDITOR
                    _comboBoxExampleRadioButton3RadioButtonGroup.Name = "ComboBoxExampleRadioButton3RadioButtonGroup";
#endif
                }
                return _comboBoxExampleRadioButton3RadioButtonGroup;
            }
        }

        private static Template _comboBoxExampleRadioButton3RadioButtonImageView;
        public static Template ComboBoxExampleRadioButton3RadioButtonImageView
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxExampleRadioButton3RadioButtonImageView == null || _comboBoxExampleRadioButton3RadioButtonImageView.CurrentVersion != Template.Version)
#else
                if (_comboBoxExampleRadioButton3RadioButtonImageView == null)
#endif
                {
                    _comboBoxExampleRadioButton3RadioButtonImageView = new Template(RadioButtonTemplates.RadioButtonRadioButtonImageView);
#if UNITY_EDITOR
                    _comboBoxExampleRadioButton3RadioButtonImageView.Name = "ComboBoxExampleRadioButton3RadioButtonImageView";
#endif
                }
                return _comboBoxExampleRadioButton3RadioButtonImageView;
            }
        }

        private static Template _comboBoxExampleRadioButton3RadioButtonLabel;
        public static Template ComboBoxExampleRadioButton3RadioButtonLabel
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxExampleRadioButton3RadioButtonLabel == null || _comboBoxExampleRadioButton3RadioButtonLabel.CurrentVersion != Template.Version)
#else
                if (_comboBoxExampleRadioButton3RadioButtonLabel == null)
#endif
                {
                    _comboBoxExampleRadioButton3RadioButtonLabel = new Template(RadioButtonTemplates.RadioButtonRadioButtonLabel);
#if UNITY_EDITOR
                    _comboBoxExampleRadioButton3RadioButtonLabel.Name = "ComboBoxExampleRadioButton3RadioButtonLabel";
#endif
                    Delight.Label.TextProperty.SetDefault(_comboBoxExampleRadioButton3RadioButtonLabel, "Option 3");
                }
                return _comboBoxExampleRadioButton3RadioButtonLabel;
            }
        }

        private static Template _comboBoxExampleGroup5;
        public static Template ComboBoxExampleGroup5
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxExampleGroup5 == null || _comboBoxExampleGroup5.CurrentVersion != Template.Version)
#else
                if (_comboBoxExampleGroup5 == null)
#endif
                {
                    _comboBoxExampleGroup5 = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _comboBoxExampleGroup5.Name = "ComboBoxExampleGroup5";
#endif
                    Delight.Group.OrientationProperty.SetDefault(_comboBoxExampleGroup5, Delight.ElementOrientation.Horizontal);
                    Delight.Group.SpacingProperty.SetDefault(_comboBoxExampleGroup5, new ElementSize(15f, ElementSizeUnit.Pixels));
                }
                return _comboBoxExampleGroup5;
            }
        }

        private static Template _comboBoxExampleButton1;
        public static Template ComboBoxExampleButton1
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxExampleButton1 == null || _comboBoxExampleButton1.CurrentVersion != Template.Version)
#else
                if (_comboBoxExampleButton1 == null)
#endif
                {
                    _comboBoxExampleButton1 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _comboBoxExampleButton1.Name = "ComboBoxExampleButton1";
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_comboBoxExampleButton1, ComboBoxExampleButton1Label);
                }
                return _comboBoxExampleButton1;
            }
        }

        private static Template _comboBoxExampleButton1Label;
        public static Template ComboBoxExampleButton1Label
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxExampleButton1Label == null || _comboBoxExampleButton1Label.CurrentVersion != Template.Version)
#else
                if (_comboBoxExampleButton1Label == null)
#endif
                {
                    _comboBoxExampleButton1Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _comboBoxExampleButton1Label.Name = "ComboBoxExampleButton1Label";
#endif
                    Delight.Label.TextProperty.SetDefault(_comboBoxExampleButton1Label, "Add");
                }
                return _comboBoxExampleButton1Label;
            }
        }

        private static Template _comboBoxExampleButton2;
        public static Template ComboBoxExampleButton2
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxExampleButton2 == null || _comboBoxExampleButton2.CurrentVersion != Template.Version)
#else
                if (_comboBoxExampleButton2 == null)
#endif
                {
                    _comboBoxExampleButton2 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _comboBoxExampleButton2.Name = "ComboBoxExampleButton2";
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_comboBoxExampleButton2, ComboBoxExampleButton2Label);
                }
                return _comboBoxExampleButton2;
            }
        }

        private static Template _comboBoxExampleButton2Label;
        public static Template ComboBoxExampleButton2Label
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxExampleButton2Label == null || _comboBoxExampleButton2Label.CurrentVersion != Template.Version)
#else
                if (_comboBoxExampleButton2Label == null)
#endif
                {
                    _comboBoxExampleButton2Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _comboBoxExampleButton2Label.Name = "ComboBoxExampleButton2Label";
#endif
                    Delight.Label.TextProperty.SetDefault(_comboBoxExampleButton2Label, "Remove");
                }
                return _comboBoxExampleButton2Label;
            }
        }

        private static Template _comboBoxExampleComboBox;
        public static Template ComboBoxExampleComboBox
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxExampleComboBox == null || _comboBoxExampleComboBox.CurrentVersion != Template.Version)
#else
                if (_comboBoxExampleComboBox == null)
#endif
                {
                    _comboBoxExampleComboBox = new Template(ComboBoxTemplates.ComboBox);
#if UNITY_EDITOR
                    _comboBoxExampleComboBox.Name = "ComboBoxExampleComboBox";
#endif
                    Delight.ComboBox.IsDropUpProperty.SetDefault(_comboBoxExampleComboBox, false);
                    Delight.ComboBox.ComboBoxButtonTemplateProperty.SetDefault(_comboBoxExampleComboBox, ComboBoxExampleComboBoxComboBoxButton);
                    Delight.ComboBox.ComboBoxListCanvasTemplateProperty.SetDefault(_comboBoxExampleComboBox, ComboBoxExampleComboBoxComboBoxListCanvas);
                    Delight.ComboBox.ComboBoxListTemplateProperty.SetDefault(_comboBoxExampleComboBox, ComboBoxExampleComboBoxComboBoxList);
                }
                return _comboBoxExampleComboBox;
            }
        }

        private static Template _comboBoxExampleComboBoxComboBoxButton;
        public static Template ComboBoxExampleComboBoxComboBoxButton
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxExampleComboBoxComboBoxButton == null || _comboBoxExampleComboBoxComboBoxButton.CurrentVersion != Template.Version)
#else
                if (_comboBoxExampleComboBoxComboBoxButton == null)
#endif
                {
                    _comboBoxExampleComboBoxComboBoxButton = new Template(ComboBoxTemplates.ComboBoxComboBoxButton);
#if UNITY_EDITOR
                    _comboBoxExampleComboBoxComboBoxButton.Name = "ComboBoxExampleComboBoxComboBoxButton";
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_comboBoxExampleComboBoxComboBoxButton, ComboBoxExampleComboBoxComboBoxButtonLabel);
                }
                return _comboBoxExampleComboBoxComboBoxButton;
            }
        }

        private static Template _comboBoxExampleComboBoxComboBoxButtonLabel;
        public static Template ComboBoxExampleComboBoxComboBoxButtonLabel
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxExampleComboBoxComboBoxButtonLabel == null || _comboBoxExampleComboBoxComboBoxButtonLabel.CurrentVersion != Template.Version)
#else
                if (_comboBoxExampleComboBoxComboBoxButtonLabel == null)
#endif
                {
                    _comboBoxExampleComboBoxComboBoxButtonLabel = new Template(ComboBoxTemplates.ComboBoxComboBoxButtonLabel);
#if UNITY_EDITOR
                    _comboBoxExampleComboBoxComboBoxButtonLabel.Name = "ComboBoxExampleComboBoxComboBoxButtonLabel";
#endif
                }
                return _comboBoxExampleComboBoxComboBoxButtonLabel;
            }
        }

        private static Template _comboBoxExampleComboBoxComboBoxListCanvas;
        public static Template ComboBoxExampleComboBoxComboBoxListCanvas
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxExampleComboBoxComboBoxListCanvas == null || _comboBoxExampleComboBoxComboBoxListCanvas.CurrentVersion != Template.Version)
#else
                if (_comboBoxExampleComboBoxComboBoxListCanvas == null)
#endif
                {
                    _comboBoxExampleComboBoxComboBoxListCanvas = new Template(ComboBoxTemplates.ComboBoxComboBoxListCanvas);
#if UNITY_EDITOR
                    _comboBoxExampleComboBoxComboBoxListCanvas.Name = "ComboBoxExampleComboBoxComboBoxListCanvas";
#endif
                }
                return _comboBoxExampleComboBoxComboBoxListCanvas;
            }
        }

        private static Template _comboBoxExampleComboBoxComboBoxList;
        public static Template ComboBoxExampleComboBoxComboBoxList
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxExampleComboBoxComboBoxList == null || _comboBoxExampleComboBoxComboBoxList.CurrentVersion != Template.Version)
#else
                if (_comboBoxExampleComboBoxComboBoxList == null)
#endif
                {
                    _comboBoxExampleComboBoxComboBoxList = new Template(ComboBoxTemplates.ComboBoxComboBoxList);
#if UNITY_EDITOR
                    _comboBoxExampleComboBoxComboBoxList.Name = "ComboBoxExampleComboBoxComboBoxList";
#endif
                    Delight.List.ItemsProperty.SetHasBinding(_comboBoxExampleComboBoxComboBoxList);
                    Delight.List.ScrollableRegionTemplateProperty.SetDefault(_comboBoxExampleComboBoxComboBoxList, ComboBoxExampleComboBoxComboBoxListScrollableRegion);
                }
                return _comboBoxExampleComboBoxComboBoxList;
            }
        }

        private static Template _comboBoxExampleComboBoxComboBoxListScrollableRegion;
        public static Template ComboBoxExampleComboBoxComboBoxListScrollableRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxExampleComboBoxComboBoxListScrollableRegion == null || _comboBoxExampleComboBoxComboBoxListScrollableRegion.CurrentVersion != Template.Version)
#else
                if (_comboBoxExampleComboBoxComboBoxListScrollableRegion == null)
#endif
                {
                    _comboBoxExampleComboBoxComboBoxListScrollableRegion = new Template(ComboBoxTemplates.ComboBoxComboBoxListScrollableRegion);
#if UNITY_EDITOR
                    _comboBoxExampleComboBoxComboBoxListScrollableRegion.Name = "ComboBoxExampleComboBoxComboBoxListScrollableRegion";
#endif
                    Delight.ScrollableRegion.ContentRegionTemplateProperty.SetDefault(_comboBoxExampleComboBoxComboBoxListScrollableRegion, ComboBoxExampleComboBoxComboBoxListScrollableRegionContentRegion);
                    Delight.ScrollableRegion.HorizontalScrollbarTemplateProperty.SetDefault(_comboBoxExampleComboBoxComboBoxListScrollableRegion, ComboBoxExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbar);
                    Delight.ScrollableRegion.VerticalScrollbarTemplateProperty.SetDefault(_comboBoxExampleComboBoxComboBoxListScrollableRegion, ComboBoxExampleComboBoxComboBoxListScrollableRegionVerticalScrollbar);
                }
                return _comboBoxExampleComboBoxComboBoxListScrollableRegion;
            }
        }

        private static Template _comboBoxExampleComboBoxComboBoxListScrollableRegionContentRegion;
        public static Template ComboBoxExampleComboBoxComboBoxListScrollableRegionContentRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxExampleComboBoxComboBoxListScrollableRegionContentRegion == null || _comboBoxExampleComboBoxComboBoxListScrollableRegionContentRegion.CurrentVersion != Template.Version)
#else
                if (_comboBoxExampleComboBoxComboBoxListScrollableRegionContentRegion == null)
#endif
                {
                    _comboBoxExampleComboBoxComboBoxListScrollableRegionContentRegion = new Template(ComboBoxTemplates.ComboBoxComboBoxListScrollableRegionContentRegion);
#if UNITY_EDITOR
                    _comboBoxExampleComboBoxComboBoxListScrollableRegionContentRegion.Name = "ComboBoxExampleComboBoxComboBoxListScrollableRegionContentRegion";
#endif
                }
                return _comboBoxExampleComboBoxComboBoxListScrollableRegionContentRegion;
            }
        }

        private static Template _comboBoxExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbar;
        public static Template ComboBoxExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbar == null || _comboBoxExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbar.CurrentVersion != Template.Version)
#else
                if (_comboBoxExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbar == null)
#endif
                {
                    _comboBoxExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbar = new Template(ComboBoxTemplates.ComboBoxComboBoxListScrollableRegionHorizontalScrollbar);
#if UNITY_EDITOR
                    _comboBoxExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbar.Name = "ComboBoxExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbar";
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_comboBoxExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbar, ComboBoxExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_comboBoxExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbar, ComboBoxExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbarHandle);
                }
                return _comboBoxExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbar;
            }
        }

        private static Template _comboBoxExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbarBar;
        public static Template ComboBoxExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbarBar == null || _comboBoxExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_comboBoxExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbarBar == null)
#endif
                {
                    _comboBoxExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbarBar = new Template(ComboBoxTemplates.ComboBoxComboBoxListScrollableRegionHorizontalScrollbarBar);
#if UNITY_EDITOR
                    _comboBoxExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbarBar.Name = "ComboBoxExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbarBar";
#endif
                }
                return _comboBoxExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbarBar;
            }
        }

        private static Template _comboBoxExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbarHandle;
        public static Template ComboBoxExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbarHandle == null || _comboBoxExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_comboBoxExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbarHandle == null)
#endif
                {
                    _comboBoxExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbarHandle = new Template(ComboBoxTemplates.ComboBoxComboBoxListScrollableRegionHorizontalScrollbarHandle);
#if UNITY_EDITOR
                    _comboBoxExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbarHandle.Name = "ComboBoxExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbarHandle";
#endif
                }
                return _comboBoxExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbarHandle;
            }
        }

        private static Template _comboBoxExampleComboBoxComboBoxListScrollableRegionVerticalScrollbar;
        public static Template ComboBoxExampleComboBoxComboBoxListScrollableRegionVerticalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxExampleComboBoxComboBoxListScrollableRegionVerticalScrollbar == null || _comboBoxExampleComboBoxComboBoxListScrollableRegionVerticalScrollbar.CurrentVersion != Template.Version)
#else
                if (_comboBoxExampleComboBoxComboBoxListScrollableRegionVerticalScrollbar == null)
#endif
                {
                    _comboBoxExampleComboBoxComboBoxListScrollableRegionVerticalScrollbar = new Template(ComboBoxTemplates.ComboBoxComboBoxListScrollableRegionVerticalScrollbar);
#if UNITY_EDITOR
                    _comboBoxExampleComboBoxComboBoxListScrollableRegionVerticalScrollbar.Name = "ComboBoxExampleComboBoxComboBoxListScrollableRegionVerticalScrollbar";
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_comboBoxExampleComboBoxComboBoxListScrollableRegionVerticalScrollbar, ComboBoxExampleComboBoxComboBoxListScrollableRegionVerticalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_comboBoxExampleComboBoxComboBoxListScrollableRegionVerticalScrollbar, ComboBoxExampleComboBoxComboBoxListScrollableRegionVerticalScrollbarHandle);
                }
                return _comboBoxExampleComboBoxComboBoxListScrollableRegionVerticalScrollbar;
            }
        }

        private static Template _comboBoxExampleComboBoxComboBoxListScrollableRegionVerticalScrollbarBar;
        public static Template ComboBoxExampleComboBoxComboBoxListScrollableRegionVerticalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxExampleComboBoxComboBoxListScrollableRegionVerticalScrollbarBar == null || _comboBoxExampleComboBoxComboBoxListScrollableRegionVerticalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_comboBoxExampleComboBoxComboBoxListScrollableRegionVerticalScrollbarBar == null)
#endif
                {
                    _comboBoxExampleComboBoxComboBoxListScrollableRegionVerticalScrollbarBar = new Template(ComboBoxTemplates.ComboBoxComboBoxListScrollableRegionVerticalScrollbarBar);
#if UNITY_EDITOR
                    _comboBoxExampleComboBoxComboBoxListScrollableRegionVerticalScrollbarBar.Name = "ComboBoxExampleComboBoxComboBoxListScrollableRegionVerticalScrollbarBar";
#endif
                }
                return _comboBoxExampleComboBoxComboBoxListScrollableRegionVerticalScrollbarBar;
            }
        }

        private static Template _comboBoxExampleComboBoxComboBoxListScrollableRegionVerticalScrollbarHandle;
        public static Template ComboBoxExampleComboBoxComboBoxListScrollableRegionVerticalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxExampleComboBoxComboBoxListScrollableRegionVerticalScrollbarHandle == null || _comboBoxExampleComboBoxComboBoxListScrollableRegionVerticalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_comboBoxExampleComboBoxComboBoxListScrollableRegionVerticalScrollbarHandle == null)
#endif
                {
                    _comboBoxExampleComboBoxComboBoxListScrollableRegionVerticalScrollbarHandle = new Template(ComboBoxTemplates.ComboBoxComboBoxListScrollableRegionVerticalScrollbarHandle);
#if UNITY_EDITOR
                    _comboBoxExampleComboBoxComboBoxListScrollableRegionVerticalScrollbarHandle.Name = "ComboBoxExampleComboBoxComboBoxListScrollableRegionVerticalScrollbarHandle";
#endif
                }
                return _comboBoxExampleComboBoxComboBoxListScrollableRegionVerticalScrollbarHandle;
            }
        }

        private static Template _comboBoxExampleComboBoxContent;
        public static Template ComboBoxExampleComboBoxContent
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxExampleComboBoxContent == null || _comboBoxExampleComboBoxContent.CurrentVersion != Template.Version)
#else
                if (_comboBoxExampleComboBoxContent == null)
#endif
                {
                    _comboBoxExampleComboBoxContent = new Template(ComboBoxListItemTemplates.ComboBoxListItem);
#if UNITY_EDITOR
                    _comboBoxExampleComboBoxContent.Name = "ComboBoxExampleComboBoxContent";
#endif
                }
                return _comboBoxExampleComboBoxContent;
            }
        }

        private static Template _comboBoxExampleLabel1;
        public static Template ComboBoxExampleLabel1
        {
            get
            {
#if UNITY_EDITOR
                if (_comboBoxExampleLabel1 == null || _comboBoxExampleLabel1.CurrentVersion != Template.Version)
#else
                if (_comboBoxExampleLabel1 == null)
#endif
                {
                    _comboBoxExampleLabel1 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _comboBoxExampleLabel1.Name = "ComboBoxExampleLabel1";
#endif
                    Delight.Label.WidthProperty.SetDefault(_comboBoxExampleLabel1, new ElementSize(1f, ElementSizeUnit.Percents));
                    Delight.Label.MarginProperty.SetDefault(_comboBoxExampleLabel1, new ElementMargin(new ElementSize(10f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels)));
                    Delight.Label.TextProperty.SetHasBinding(_comboBoxExampleLabel1);
                }
                return _comboBoxExampleLabel1;
            }
        }

        #endregion
    }

    #endregion
}
