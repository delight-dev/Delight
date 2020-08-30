// Internal view logic generated from "ButtonsExample.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class ButtonsExample : LayoutRoot
    {
        #region Constructors

        public ButtonsExample(View parent, View layoutParent = null, string id = null, Template template = null, bool deferInitialization = false) :
            base(parent, layoutParent, id, template ?? ButtonsExampleTemplates.Default, deferInitialization)
        {
            if (deferInitialization)
                return;

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
            Button1.Click.RegisterHandler(this, "ButtonClick");
            Button2 = new Button(this, Group5.Content, "Button2", Button2Template);
            Label1 = new Label(this, Button2.Content, "Label1", Label1Template);
            Image1 = new Image(this, Button2.Content, "Image1", Image1Template);
            Label2 = new Label(this, Group1.Content, "Label2", Label2Template);

            // binding <Label Text="Click count: {ClickCount}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "ClickCount" }, new List<Func<BindableObject>> { () => this }) }, new BindingPath(new List<string> { "Label2", "Text" }, new List<Func<BindableObject>> { () => this, () => Label2 }), () => Label2.Text = String.Format("Click count: {0}", ClickCount), () => { }, false));
            ComboBox = new ComboBox(this, Group1.Content, "ComboBox", ComboBoxTemplate);
            ComboBox.ItemSelected.RegisterHandler(this, "ItemSelected");

            // binding <ComboBox Items="{player in @DemoPlayers}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> {  }, new List<Func<BindableObject>> {  }) }, new BindingPath(new List<string> { "ComboBox", "Items" }, new List<Func<BindableObject>> { () => this, () => ComboBox }), () => ComboBox.Items = Models.DemoPlayers, () => { }, false));

            // templates for ComboBox
            ComboBox.ContentTemplates.Add(new ContentTemplate(tiPlayer => 
            {
                var comboBoxContent = new ComboBoxListItem(this, ComboBox.Content, "ComboBoxContent", ComboBoxContentTemplate);
                var label3 = new Label(this, comboBoxContent.Content, "Label3", Label3Template);

                // binding <Label Text="{player.Name}">
                comboBoxContent.Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "Item", "Name" }, new List<Func<BindableObject>> { () => tiPlayer, () => (tiPlayer.Item as Delight.DemoPlayer) }) }, new BindingPath(new List<string> { "Text" }, new List<Func<BindableObject>> { () => label3 }), () => label3.Text = (tiPlayer.Item as Delight.DemoPlayer).Name, () => { }, false));
                comboBoxContent.IsDynamic = true;
                comboBoxContent.SetContentTemplateData(tiPlayer);
                return comboBoxContent;
            }, typeof(ComboBoxListItem), "ComboBoxContent"));
            ComboBox1 = new ComboBox(this, Group1.Content, "ComboBox1", ComboBox1Template);
            ComboBox1.ItemSelected.RegisterHandler(this, "ItemSelected");

            // templates for ComboBox1
            ComboBox1.ContentTemplates.Add(new ContentTemplate(x0 => 
            {
                var comboBoxListItem1 = new ComboBoxListItem(this, ComboBox1.Content, "ComboBoxListItem1", ComboBoxListItem1Template);
                var label4 = new Label(this, comboBoxListItem1.Content, "Label4", Label4Template);
                comboBoxListItem1.IsDynamic = true;
                comboBoxListItem1.SetContentTemplateData(x0);
                return comboBoxListItem1;
            }, typeof(ComboBoxListItem), "ComboBoxListItem1"));

            // templates for ComboBox1
            ComboBox1.ContentTemplates.Add(new ContentTemplate(x0 => 
            {
                var comboBoxListItem2 = new ComboBoxListItem(this, ComboBox1.Content, "ComboBoxListItem2", ComboBoxListItem2Template);
                var label5 = new Label(this, comboBoxListItem2.Content, "Label5", Label5Template);
                comboBoxListItem2.IsDynamic = true;
                comboBoxListItem2.SetContentTemplateData(x0);
                return comboBoxListItem2;
            }, typeof(ComboBoxListItem), "ComboBoxListItem2"));

            // templates for ComboBox1
            ComboBox1.ContentTemplates.Add(new ContentTemplate(x0 => 
            {
                var comboBoxListItem3 = new ComboBoxListItem(this, ComboBox1.Content, "ComboBoxListItem3", ComboBoxListItem3Template);
                var image2 = new Image(this, comboBoxListItem3.Content, "Image2", Image2Template);
                var label6 = new Label(this, comboBoxListItem3.Content, "Label6", Label6Template);
                comboBoxListItem3.IsDynamic = true;
                comboBoxListItem3.SetContentTemplateData(x0);
                return comboBoxListItem3;
            }, typeof(ComboBoxListItem), "ComboBoxListItem3"));
            this.AfterInitializeInternal();
        }

        public ButtonsExample() : this(null)
        {
        }

        static ButtonsExample()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(ButtonsExampleTemplates.Default, dependencyProperties);

            dependencyProperties.Add(ClickCountProperty);
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
            dependencyProperties.Add(Label1Property);
            dependencyProperties.Add(Label1TemplateProperty);
            dependencyProperties.Add(Image1Property);
            dependencyProperties.Add(Image1TemplateProperty);
            dependencyProperties.Add(Label2Property);
            dependencyProperties.Add(Label2TemplateProperty);
            dependencyProperties.Add(ComboBoxProperty);
            dependencyProperties.Add(ComboBoxTemplateProperty);
            dependencyProperties.Add(Label3Property);
            dependencyProperties.Add(Label3TemplateProperty);
            dependencyProperties.Add(ComboBox1Property);
            dependencyProperties.Add(ComboBox1TemplateProperty);
            dependencyProperties.Add(ComboBoxListItem1Property);
            dependencyProperties.Add(ComboBoxListItem1TemplateProperty);
            dependencyProperties.Add(Label4Property);
            dependencyProperties.Add(Label4TemplateProperty);
            dependencyProperties.Add(ComboBoxListItem2Property);
            dependencyProperties.Add(ComboBoxListItem2TemplateProperty);
            dependencyProperties.Add(Label5Property);
            dependencyProperties.Add(Label5TemplateProperty);
            dependencyProperties.Add(ComboBoxListItem3Property);
            dependencyProperties.Add(ComboBoxListItem3TemplateProperty);
            dependencyProperties.Add(Image2Property);
            dependencyProperties.Add(Image2TemplateProperty);
            dependencyProperties.Add(Label6Property);
            dependencyProperties.Add(Label6TemplateProperty);
            dependencyProperties.Add(ComboBoxContentProperty);
            dependencyProperties.Add(ComboBoxContentTemplateProperty);
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

        public readonly static DependencyProperty<Image> Image1Property = new DependencyProperty<Image>("Image1");
        public Image Image1
        {
            get { return Image1Property.GetValue(this); }
            set { Image1Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Image1TemplateProperty = new DependencyProperty<Template>("Image1Template");
        public Template Image1Template
        {
            get { return Image1TemplateProperty.GetValue(this); }
            set { Image1TemplateProperty.SetValue(this, value); }
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

        public readonly static DependencyProperty<ComboBox> ComboBox1Property = new DependencyProperty<ComboBox>("ComboBox1");
        public ComboBox ComboBox1
        {
            get { return ComboBox1Property.GetValue(this); }
            set { ComboBox1Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> ComboBox1TemplateProperty = new DependencyProperty<Template>("ComboBox1Template");
        public Template ComboBox1Template
        {
            get { return ComboBox1TemplateProperty.GetValue(this); }
            set { ComboBox1TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ComboBoxListItem> ComboBoxListItem1Property = new DependencyProperty<ComboBoxListItem>("ComboBoxListItem1");
        public ComboBoxListItem ComboBoxListItem1
        {
            get { return ComboBoxListItem1Property.GetValue(this); }
            set { ComboBoxListItem1Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> ComboBoxListItem1TemplateProperty = new DependencyProperty<Template>("ComboBoxListItem1Template");
        public Template ComboBoxListItem1Template
        {
            get { return ComboBoxListItem1TemplateProperty.GetValue(this); }
            set { ComboBoxListItem1TemplateProperty.SetValue(this, value); }
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

        public readonly static DependencyProperty<ComboBoxListItem> ComboBoxListItem2Property = new DependencyProperty<ComboBoxListItem>("ComboBoxListItem2");
        public ComboBoxListItem ComboBoxListItem2
        {
            get { return ComboBoxListItem2Property.GetValue(this); }
            set { ComboBoxListItem2Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> ComboBoxListItem2TemplateProperty = new DependencyProperty<Template>("ComboBoxListItem2Template");
        public Template ComboBoxListItem2Template
        {
            get { return ComboBoxListItem2TemplateProperty.GetValue(this); }
            set { ComboBoxListItem2TemplateProperty.SetValue(this, value); }
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

        public readonly static DependencyProperty<ComboBoxListItem> ComboBoxListItem3Property = new DependencyProperty<ComboBoxListItem>("ComboBoxListItem3");
        public ComboBoxListItem ComboBoxListItem3
        {
            get { return ComboBoxListItem3Property.GetValue(this); }
            set { ComboBoxListItem3Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> ComboBoxListItem3TemplateProperty = new DependencyProperty<Template>("ComboBoxListItem3Template");
        public Template ComboBoxListItem3Template
        {
            get { return ComboBoxListItem3TemplateProperty.GetValue(this); }
            set { ComboBoxListItem3TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Image> Image2Property = new DependencyProperty<Image>("Image2");
        public Image Image2
        {
            get { return Image2Property.GetValue(this); }
            set { Image2Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Image2TemplateProperty = new DependencyProperty<Template>("Image2Template");
        public Template Image2Template
        {
            get { return Image2TemplateProperty.GetValue(this); }
            set { Image2TemplateProperty.SetValue(this, value); }
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

    public static class ButtonsExampleTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return ButtonsExample;
            }
        }

        private static Template _buttonsExample;
        public static Template ButtonsExample
        {
            get
            {
#if UNITY_EDITOR
                if (_buttonsExample == null || _buttonsExample.CurrentVersion != Template.Version)
#else
                if (_buttonsExample == null)
#endif
                {
                    _buttonsExample = new Template(LayoutRootTemplates.LayoutRoot);
#if UNITY_EDITOR
                    _buttonsExample.Name = "ButtonsExample";
                    _buttonsExample.LineNumber = 0;
                    _buttonsExample.LinePosition = 0;
#endif
                    Delight.ButtonsExample.Group1TemplateProperty.SetDefault(_buttonsExample, ButtonsExampleGroup1);
                    Delight.ButtonsExample.Group2TemplateProperty.SetDefault(_buttonsExample, ButtonsExampleGroup2);
                    Delight.ButtonsExample.Group3TemplateProperty.SetDefault(_buttonsExample, ButtonsExampleGroup3);
                    Delight.ButtonsExample.CheckBox1TemplateProperty.SetDefault(_buttonsExample, ButtonsExampleCheckBox1);
                    Delight.ButtonsExample.CheckBox2TemplateProperty.SetDefault(_buttonsExample, ButtonsExampleCheckBox2);
                    Delight.ButtonsExample.CheckBox3TemplateProperty.SetDefault(_buttonsExample, ButtonsExampleCheckBox3);
                    Delight.ButtonsExample.Group4TemplateProperty.SetDefault(_buttonsExample, ButtonsExampleGroup4);
                    Delight.ButtonsExample.RadioButton1TemplateProperty.SetDefault(_buttonsExample, ButtonsExampleRadioButton1);
                    Delight.ButtonsExample.RadioButton2TemplateProperty.SetDefault(_buttonsExample, ButtonsExampleRadioButton2);
                    Delight.ButtonsExample.RadioButton3TemplateProperty.SetDefault(_buttonsExample, ButtonsExampleRadioButton3);
                    Delight.ButtonsExample.Group5TemplateProperty.SetDefault(_buttonsExample, ButtonsExampleGroup5);
                    Delight.ButtonsExample.Button1TemplateProperty.SetDefault(_buttonsExample, ButtonsExampleButton1);
                    Delight.ButtonsExample.Button2TemplateProperty.SetDefault(_buttonsExample, ButtonsExampleButton2);
                    Delight.ButtonsExample.Label1TemplateProperty.SetDefault(_buttonsExample, ButtonsExampleLabel1);
                    Delight.ButtonsExample.Image1TemplateProperty.SetDefault(_buttonsExample, ButtonsExampleImage1);
                    Delight.ButtonsExample.Label2TemplateProperty.SetDefault(_buttonsExample, ButtonsExampleLabel2);
                    Delight.ButtonsExample.ComboBoxTemplateProperty.SetDefault(_buttonsExample, ButtonsExampleComboBox);
                    Delight.ButtonsExample.ComboBoxContentTemplateProperty.SetDefault(_buttonsExample, ButtonsExampleComboBoxContent);
                    Delight.ButtonsExample.Label3TemplateProperty.SetDefault(_buttonsExample, ButtonsExampleLabel3);
                    Delight.ButtonsExample.ComboBox1TemplateProperty.SetDefault(_buttonsExample, ButtonsExampleComboBox1);
                    Delight.ButtonsExample.ComboBoxListItem1TemplateProperty.SetDefault(_buttonsExample, ButtonsExampleComboBoxListItem1);
                    Delight.ButtonsExample.Label4TemplateProperty.SetDefault(_buttonsExample, ButtonsExampleLabel4);
                    Delight.ButtonsExample.ComboBoxListItem2TemplateProperty.SetDefault(_buttonsExample, ButtonsExampleComboBoxListItem2);
                    Delight.ButtonsExample.Label5TemplateProperty.SetDefault(_buttonsExample, ButtonsExampleLabel5);
                    Delight.ButtonsExample.ComboBoxListItem3TemplateProperty.SetDefault(_buttonsExample, ButtonsExampleComboBoxListItem3);
                    Delight.ButtonsExample.Image2TemplateProperty.SetDefault(_buttonsExample, ButtonsExampleImage2);
                    Delight.ButtonsExample.Label6TemplateProperty.SetDefault(_buttonsExample, ButtonsExampleLabel6);
                }
                return _buttonsExample;
            }
        }

        private static Template _buttonsExampleGroup1;
        public static Template ButtonsExampleGroup1
        {
            get
            {
#if UNITY_EDITOR
                if (_buttonsExampleGroup1 == null || _buttonsExampleGroup1.CurrentVersion != Template.Version)
#else
                if (_buttonsExampleGroup1 == null)
#endif
                {
                    _buttonsExampleGroup1 = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _buttonsExampleGroup1.Name = "ButtonsExampleGroup1";
                    _buttonsExampleGroup1.LineNumber = 3;
                    _buttonsExampleGroup1.LinePosition = 4;
#endif
                    Delight.Group.OrientationProperty.SetDefault(_buttonsExampleGroup1, Delight.ElementOrientation.Vertical);
                    Delight.Group.SpacingProperty.SetDefault(_buttonsExampleGroup1, new ElementSize(10f, ElementSizeUnit.Pixels));
                }
                return _buttonsExampleGroup1;
            }
        }

        private static Template _buttonsExampleGroup2;
        public static Template ButtonsExampleGroup2
        {
            get
            {
#if UNITY_EDITOR
                if (_buttonsExampleGroup2 == null || _buttonsExampleGroup2.CurrentVersion != Template.Version)
#else
                if (_buttonsExampleGroup2 == null)
#endif
                {
                    _buttonsExampleGroup2 = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _buttonsExampleGroup2.Name = "ButtonsExampleGroup2";
                    _buttonsExampleGroup2.LineNumber = 5;
                    _buttonsExampleGroup2.LinePosition = 6;
#endif
                    Delight.Group.OrientationProperty.SetDefault(_buttonsExampleGroup2, Delight.ElementOrientation.Horizontal);
                    Delight.Group.SpacingProperty.SetDefault(_buttonsExampleGroup2, new ElementSize(50f, ElementSizeUnit.Pixels));
                }
                return _buttonsExampleGroup2;
            }
        }

        private static Template _buttonsExampleGroup3;
        public static Template ButtonsExampleGroup3
        {
            get
            {
#if UNITY_EDITOR
                if (_buttonsExampleGroup3 == null || _buttonsExampleGroup3.CurrentVersion != Template.Version)
#else
                if (_buttonsExampleGroup3 == null)
#endif
                {
                    _buttonsExampleGroup3 = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _buttonsExampleGroup3.Name = "ButtonsExampleGroup3";
                    _buttonsExampleGroup3.LineNumber = 6;
                    _buttonsExampleGroup3.LinePosition = 8;
#endif
                    Delight.Group.SpacingProperty.SetDefault(_buttonsExampleGroup3, new ElementSize(10f, ElementSizeUnit.Pixels));
                    Delight.Group.ContentAlignmentProperty.SetDefault(_buttonsExampleGroup3, Delight.ElementAlignment.Left);
                }
                return _buttonsExampleGroup3;
            }
        }

        private static Template _buttonsExampleCheckBox1;
        public static Template ButtonsExampleCheckBox1
        {
            get
            {
#if UNITY_EDITOR
                if (_buttonsExampleCheckBox1 == null || _buttonsExampleCheckBox1.CurrentVersion != Template.Version)
#else
                if (_buttonsExampleCheckBox1 == null)
#endif
                {
                    _buttonsExampleCheckBox1 = new Template(CheckBoxTemplates.CheckBox);
#if UNITY_EDITOR
                    _buttonsExampleCheckBox1.Name = "ButtonsExampleCheckBox1";
                    _buttonsExampleCheckBox1.LineNumber = 7;
                    _buttonsExampleCheckBox1.LinePosition = 10;
#endif
                    Delight.CheckBox.CheckBoxGroupTemplateProperty.SetDefault(_buttonsExampleCheckBox1, ButtonsExampleCheckBox1CheckBoxGroup);
                    Delight.CheckBox.CheckBoxImageViewTemplateProperty.SetDefault(_buttonsExampleCheckBox1, ButtonsExampleCheckBox1CheckBoxImageView);
                    Delight.CheckBox.CheckBoxLabelTemplateProperty.SetDefault(_buttonsExampleCheckBox1, ButtonsExampleCheckBox1CheckBoxLabel);
                }
                return _buttonsExampleCheckBox1;
            }
        }

        private static Template _buttonsExampleCheckBox1CheckBoxGroup;
        public static Template ButtonsExampleCheckBox1CheckBoxGroup
        {
            get
            {
#if UNITY_EDITOR
                if (_buttonsExampleCheckBox1CheckBoxGroup == null || _buttonsExampleCheckBox1CheckBoxGroup.CurrentVersion != Template.Version)
#else
                if (_buttonsExampleCheckBox1CheckBoxGroup == null)
#endif
                {
                    _buttonsExampleCheckBox1CheckBoxGroup = new Template(CheckBoxTemplates.CheckBoxCheckBoxGroup);
#if UNITY_EDITOR
                    _buttonsExampleCheckBox1CheckBoxGroup.Name = "ButtonsExampleCheckBox1CheckBoxGroup";
                    _buttonsExampleCheckBox1CheckBoxGroup.LineNumber = 9;
                    _buttonsExampleCheckBox1CheckBoxGroup.LinePosition = 4;
#endif
                }
                return _buttonsExampleCheckBox1CheckBoxGroup;
            }
        }

        private static Template _buttonsExampleCheckBox1CheckBoxImageView;
        public static Template ButtonsExampleCheckBox1CheckBoxImageView
        {
            get
            {
#if UNITY_EDITOR
                if (_buttonsExampleCheckBox1CheckBoxImageView == null || _buttonsExampleCheckBox1CheckBoxImageView.CurrentVersion != Template.Version)
#else
                if (_buttonsExampleCheckBox1CheckBoxImageView == null)
#endif
                {
                    _buttonsExampleCheckBox1CheckBoxImageView = new Template(CheckBoxTemplates.CheckBoxCheckBoxImageView);
#if UNITY_EDITOR
                    _buttonsExampleCheckBox1CheckBoxImageView.Name = "ButtonsExampleCheckBox1CheckBoxImageView";
                    _buttonsExampleCheckBox1CheckBoxImageView.LineNumber = 10;
                    _buttonsExampleCheckBox1CheckBoxImageView.LinePosition = 6;
#endif
                }
                return _buttonsExampleCheckBox1CheckBoxImageView;
            }
        }

        private static Template _buttonsExampleCheckBox1CheckBoxLabel;
        public static Template ButtonsExampleCheckBox1CheckBoxLabel
        {
            get
            {
#if UNITY_EDITOR
                if (_buttonsExampleCheckBox1CheckBoxLabel == null || _buttonsExampleCheckBox1CheckBoxLabel.CurrentVersion != Template.Version)
#else
                if (_buttonsExampleCheckBox1CheckBoxLabel == null)
#endif
                {
                    _buttonsExampleCheckBox1CheckBoxLabel = new Template(CheckBoxTemplates.CheckBoxCheckBoxLabel);
#if UNITY_EDITOR
                    _buttonsExampleCheckBox1CheckBoxLabel.Name = "ButtonsExampleCheckBox1CheckBoxLabel";
                    _buttonsExampleCheckBox1CheckBoxLabel.LineNumber = 11;
                    _buttonsExampleCheckBox1CheckBoxLabel.LinePosition = 6;
#endif
                    Delight.Label.TextProperty.SetDefault(_buttonsExampleCheckBox1CheckBoxLabel, "Option 1");
                }
                return _buttonsExampleCheckBox1CheckBoxLabel;
            }
        }

        private static Template _buttonsExampleCheckBox2;
        public static Template ButtonsExampleCheckBox2
        {
            get
            {
#if UNITY_EDITOR
                if (_buttonsExampleCheckBox2 == null || _buttonsExampleCheckBox2.CurrentVersion != Template.Version)
#else
                if (_buttonsExampleCheckBox2 == null)
#endif
                {
                    _buttonsExampleCheckBox2 = new Template(CheckBoxTemplates.CheckBox);
#if UNITY_EDITOR
                    _buttonsExampleCheckBox2.Name = "ButtonsExampleCheckBox2";
                    _buttonsExampleCheckBox2.LineNumber = 8;
                    _buttonsExampleCheckBox2.LinePosition = 10;
#endif
                    Delight.CheckBox.CheckBoxGroupTemplateProperty.SetDefault(_buttonsExampleCheckBox2, ButtonsExampleCheckBox2CheckBoxGroup);
                    Delight.CheckBox.CheckBoxImageViewTemplateProperty.SetDefault(_buttonsExampleCheckBox2, ButtonsExampleCheckBox2CheckBoxImageView);
                    Delight.CheckBox.CheckBoxLabelTemplateProperty.SetDefault(_buttonsExampleCheckBox2, ButtonsExampleCheckBox2CheckBoxLabel);
                }
                return _buttonsExampleCheckBox2;
            }
        }

        private static Template _buttonsExampleCheckBox2CheckBoxGroup;
        public static Template ButtonsExampleCheckBox2CheckBoxGroup
        {
            get
            {
#if UNITY_EDITOR
                if (_buttonsExampleCheckBox2CheckBoxGroup == null || _buttonsExampleCheckBox2CheckBoxGroup.CurrentVersion != Template.Version)
#else
                if (_buttonsExampleCheckBox2CheckBoxGroup == null)
#endif
                {
                    _buttonsExampleCheckBox2CheckBoxGroup = new Template(CheckBoxTemplates.CheckBoxCheckBoxGroup);
#if UNITY_EDITOR
                    _buttonsExampleCheckBox2CheckBoxGroup.Name = "ButtonsExampleCheckBox2CheckBoxGroup";
                    _buttonsExampleCheckBox2CheckBoxGroup.LineNumber = 9;
                    _buttonsExampleCheckBox2CheckBoxGroup.LinePosition = 4;
#endif
                }
                return _buttonsExampleCheckBox2CheckBoxGroup;
            }
        }

        private static Template _buttonsExampleCheckBox2CheckBoxImageView;
        public static Template ButtonsExampleCheckBox2CheckBoxImageView
        {
            get
            {
#if UNITY_EDITOR
                if (_buttonsExampleCheckBox2CheckBoxImageView == null || _buttonsExampleCheckBox2CheckBoxImageView.CurrentVersion != Template.Version)
#else
                if (_buttonsExampleCheckBox2CheckBoxImageView == null)
#endif
                {
                    _buttonsExampleCheckBox2CheckBoxImageView = new Template(CheckBoxTemplates.CheckBoxCheckBoxImageView);
#if UNITY_EDITOR
                    _buttonsExampleCheckBox2CheckBoxImageView.Name = "ButtonsExampleCheckBox2CheckBoxImageView";
                    _buttonsExampleCheckBox2CheckBoxImageView.LineNumber = 10;
                    _buttonsExampleCheckBox2CheckBoxImageView.LinePosition = 6;
#endif
                }
                return _buttonsExampleCheckBox2CheckBoxImageView;
            }
        }

        private static Template _buttonsExampleCheckBox2CheckBoxLabel;
        public static Template ButtonsExampleCheckBox2CheckBoxLabel
        {
            get
            {
#if UNITY_EDITOR
                if (_buttonsExampleCheckBox2CheckBoxLabel == null || _buttonsExampleCheckBox2CheckBoxLabel.CurrentVersion != Template.Version)
#else
                if (_buttonsExampleCheckBox2CheckBoxLabel == null)
#endif
                {
                    _buttonsExampleCheckBox2CheckBoxLabel = new Template(CheckBoxTemplates.CheckBoxCheckBoxLabel);
#if UNITY_EDITOR
                    _buttonsExampleCheckBox2CheckBoxLabel.Name = "ButtonsExampleCheckBox2CheckBoxLabel";
                    _buttonsExampleCheckBox2CheckBoxLabel.LineNumber = 11;
                    _buttonsExampleCheckBox2CheckBoxLabel.LinePosition = 6;
#endif
                    Delight.Label.TextProperty.SetDefault(_buttonsExampleCheckBox2CheckBoxLabel, "Option 2");
                }
                return _buttonsExampleCheckBox2CheckBoxLabel;
            }
        }

        private static Template _buttonsExampleCheckBox3;
        public static Template ButtonsExampleCheckBox3
        {
            get
            {
#if UNITY_EDITOR
                if (_buttonsExampleCheckBox3 == null || _buttonsExampleCheckBox3.CurrentVersion != Template.Version)
#else
                if (_buttonsExampleCheckBox3 == null)
#endif
                {
                    _buttonsExampleCheckBox3 = new Template(CheckBoxTemplates.CheckBox);
#if UNITY_EDITOR
                    _buttonsExampleCheckBox3.Name = "ButtonsExampleCheckBox3";
                    _buttonsExampleCheckBox3.LineNumber = 9;
                    _buttonsExampleCheckBox3.LinePosition = 10;
#endif
                    Delight.CheckBox.CheckBoxGroupTemplateProperty.SetDefault(_buttonsExampleCheckBox3, ButtonsExampleCheckBox3CheckBoxGroup);
                    Delight.CheckBox.CheckBoxImageViewTemplateProperty.SetDefault(_buttonsExampleCheckBox3, ButtonsExampleCheckBox3CheckBoxImageView);
                    Delight.CheckBox.CheckBoxLabelTemplateProperty.SetDefault(_buttonsExampleCheckBox3, ButtonsExampleCheckBox3CheckBoxLabel);
                }
                return _buttonsExampleCheckBox3;
            }
        }

        private static Template _buttonsExampleCheckBox3CheckBoxGroup;
        public static Template ButtonsExampleCheckBox3CheckBoxGroup
        {
            get
            {
#if UNITY_EDITOR
                if (_buttonsExampleCheckBox3CheckBoxGroup == null || _buttonsExampleCheckBox3CheckBoxGroup.CurrentVersion != Template.Version)
#else
                if (_buttonsExampleCheckBox3CheckBoxGroup == null)
#endif
                {
                    _buttonsExampleCheckBox3CheckBoxGroup = new Template(CheckBoxTemplates.CheckBoxCheckBoxGroup);
#if UNITY_EDITOR
                    _buttonsExampleCheckBox3CheckBoxGroup.Name = "ButtonsExampleCheckBox3CheckBoxGroup";
                    _buttonsExampleCheckBox3CheckBoxGroup.LineNumber = 9;
                    _buttonsExampleCheckBox3CheckBoxGroup.LinePosition = 4;
#endif
                }
                return _buttonsExampleCheckBox3CheckBoxGroup;
            }
        }

        private static Template _buttonsExampleCheckBox3CheckBoxImageView;
        public static Template ButtonsExampleCheckBox3CheckBoxImageView
        {
            get
            {
#if UNITY_EDITOR
                if (_buttonsExampleCheckBox3CheckBoxImageView == null || _buttonsExampleCheckBox3CheckBoxImageView.CurrentVersion != Template.Version)
#else
                if (_buttonsExampleCheckBox3CheckBoxImageView == null)
#endif
                {
                    _buttonsExampleCheckBox3CheckBoxImageView = new Template(CheckBoxTemplates.CheckBoxCheckBoxImageView);
#if UNITY_EDITOR
                    _buttonsExampleCheckBox3CheckBoxImageView.Name = "ButtonsExampleCheckBox3CheckBoxImageView";
                    _buttonsExampleCheckBox3CheckBoxImageView.LineNumber = 10;
                    _buttonsExampleCheckBox3CheckBoxImageView.LinePosition = 6;
#endif
                }
                return _buttonsExampleCheckBox3CheckBoxImageView;
            }
        }

        private static Template _buttonsExampleCheckBox3CheckBoxLabel;
        public static Template ButtonsExampleCheckBox3CheckBoxLabel
        {
            get
            {
#if UNITY_EDITOR
                if (_buttonsExampleCheckBox3CheckBoxLabel == null || _buttonsExampleCheckBox3CheckBoxLabel.CurrentVersion != Template.Version)
#else
                if (_buttonsExampleCheckBox3CheckBoxLabel == null)
#endif
                {
                    _buttonsExampleCheckBox3CheckBoxLabel = new Template(CheckBoxTemplates.CheckBoxCheckBoxLabel);
#if UNITY_EDITOR
                    _buttonsExampleCheckBox3CheckBoxLabel.Name = "ButtonsExampleCheckBox3CheckBoxLabel";
                    _buttonsExampleCheckBox3CheckBoxLabel.LineNumber = 11;
                    _buttonsExampleCheckBox3CheckBoxLabel.LinePosition = 6;
#endif
                    Delight.Label.TextProperty.SetDefault(_buttonsExampleCheckBox3CheckBoxLabel, "Option 3");
                }
                return _buttonsExampleCheckBox3CheckBoxLabel;
            }
        }

        private static Template _buttonsExampleGroup4;
        public static Template ButtonsExampleGroup4
        {
            get
            {
#if UNITY_EDITOR
                if (_buttonsExampleGroup4 == null || _buttonsExampleGroup4.CurrentVersion != Template.Version)
#else
                if (_buttonsExampleGroup4 == null)
#endif
                {
                    _buttonsExampleGroup4 = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _buttonsExampleGroup4.Name = "ButtonsExampleGroup4";
                    _buttonsExampleGroup4.LineNumber = 12;
                    _buttonsExampleGroup4.LinePosition = 8;
#endif
                    Delight.Group.SpacingProperty.SetDefault(_buttonsExampleGroup4, new ElementSize(10f, ElementSizeUnit.Pixels));
                    Delight.Group.ContentAlignmentProperty.SetDefault(_buttonsExampleGroup4, Delight.ElementAlignment.Left);
                }
                return _buttonsExampleGroup4;
            }
        }

        private static Template _buttonsExampleRadioButton1;
        public static Template ButtonsExampleRadioButton1
        {
            get
            {
#if UNITY_EDITOR
                if (_buttonsExampleRadioButton1 == null || _buttonsExampleRadioButton1.CurrentVersion != Template.Version)
#else
                if (_buttonsExampleRadioButton1 == null)
#endif
                {
                    _buttonsExampleRadioButton1 = new Template(RadioButtonTemplates.RadioButton);
#if UNITY_EDITOR
                    _buttonsExampleRadioButton1.Name = "ButtonsExampleRadioButton1";
                    _buttonsExampleRadioButton1.LineNumber = 13;
                    _buttonsExampleRadioButton1.LinePosition = 10;
#endif
                    Delight.RadioButton.RadioButtonGroupTemplateProperty.SetDefault(_buttonsExampleRadioButton1, ButtonsExampleRadioButton1RadioButtonGroup);
                    Delight.RadioButton.RadioButtonImageViewTemplateProperty.SetDefault(_buttonsExampleRadioButton1, ButtonsExampleRadioButton1RadioButtonImageView);
                    Delight.RadioButton.RadioButtonLabelTemplateProperty.SetDefault(_buttonsExampleRadioButton1, ButtonsExampleRadioButton1RadioButtonLabel);
                }
                return _buttonsExampleRadioButton1;
            }
        }

        private static Template _buttonsExampleRadioButton1RadioButtonGroup;
        public static Template ButtonsExampleRadioButton1RadioButtonGroup
        {
            get
            {
#if UNITY_EDITOR
                if (_buttonsExampleRadioButton1RadioButtonGroup == null || _buttonsExampleRadioButton1RadioButtonGroup.CurrentVersion != Template.Version)
#else
                if (_buttonsExampleRadioButton1RadioButtonGroup == null)
#endif
                {
                    _buttonsExampleRadioButton1RadioButtonGroup = new Template(RadioButtonTemplates.RadioButtonRadioButtonGroup);
#if UNITY_EDITOR
                    _buttonsExampleRadioButton1RadioButtonGroup.Name = "ButtonsExampleRadioButton1RadioButtonGroup";
                    _buttonsExampleRadioButton1RadioButtonGroup.LineNumber = 8;
                    _buttonsExampleRadioButton1RadioButtonGroup.LinePosition = 4;
#endif
                }
                return _buttonsExampleRadioButton1RadioButtonGroup;
            }
        }

        private static Template _buttonsExampleRadioButton1RadioButtonImageView;
        public static Template ButtonsExampleRadioButton1RadioButtonImageView
        {
            get
            {
#if UNITY_EDITOR
                if (_buttonsExampleRadioButton1RadioButtonImageView == null || _buttonsExampleRadioButton1RadioButtonImageView.CurrentVersion != Template.Version)
#else
                if (_buttonsExampleRadioButton1RadioButtonImageView == null)
#endif
                {
                    _buttonsExampleRadioButton1RadioButtonImageView = new Template(RadioButtonTemplates.RadioButtonRadioButtonImageView);
#if UNITY_EDITOR
                    _buttonsExampleRadioButton1RadioButtonImageView.Name = "ButtonsExampleRadioButton1RadioButtonImageView";
                    _buttonsExampleRadioButton1RadioButtonImageView.LineNumber = 9;
                    _buttonsExampleRadioButton1RadioButtonImageView.LinePosition = 6;
#endif
                }
                return _buttonsExampleRadioButton1RadioButtonImageView;
            }
        }

        private static Template _buttonsExampleRadioButton1RadioButtonLabel;
        public static Template ButtonsExampleRadioButton1RadioButtonLabel
        {
            get
            {
#if UNITY_EDITOR
                if (_buttonsExampleRadioButton1RadioButtonLabel == null || _buttonsExampleRadioButton1RadioButtonLabel.CurrentVersion != Template.Version)
#else
                if (_buttonsExampleRadioButton1RadioButtonLabel == null)
#endif
                {
                    _buttonsExampleRadioButton1RadioButtonLabel = new Template(RadioButtonTemplates.RadioButtonRadioButtonLabel);
#if UNITY_EDITOR
                    _buttonsExampleRadioButton1RadioButtonLabel.Name = "ButtonsExampleRadioButton1RadioButtonLabel";
                    _buttonsExampleRadioButton1RadioButtonLabel.LineNumber = 10;
                    _buttonsExampleRadioButton1RadioButtonLabel.LinePosition = 6;
#endif
                    Delight.Label.TextProperty.SetDefault(_buttonsExampleRadioButton1RadioButtonLabel, "Option 1");
                }
                return _buttonsExampleRadioButton1RadioButtonLabel;
            }
        }

        private static Template _buttonsExampleRadioButton2;
        public static Template ButtonsExampleRadioButton2
        {
            get
            {
#if UNITY_EDITOR
                if (_buttonsExampleRadioButton2 == null || _buttonsExampleRadioButton2.CurrentVersion != Template.Version)
#else
                if (_buttonsExampleRadioButton2 == null)
#endif
                {
                    _buttonsExampleRadioButton2 = new Template(RadioButtonTemplates.RadioButton);
#if UNITY_EDITOR
                    _buttonsExampleRadioButton2.Name = "ButtonsExampleRadioButton2";
                    _buttonsExampleRadioButton2.LineNumber = 14;
                    _buttonsExampleRadioButton2.LinePosition = 10;
#endif
                    Delight.RadioButton.RadioButtonGroupTemplateProperty.SetDefault(_buttonsExampleRadioButton2, ButtonsExampleRadioButton2RadioButtonGroup);
                    Delight.RadioButton.RadioButtonImageViewTemplateProperty.SetDefault(_buttonsExampleRadioButton2, ButtonsExampleRadioButton2RadioButtonImageView);
                    Delight.RadioButton.RadioButtonLabelTemplateProperty.SetDefault(_buttonsExampleRadioButton2, ButtonsExampleRadioButton2RadioButtonLabel);
                }
                return _buttonsExampleRadioButton2;
            }
        }

        private static Template _buttonsExampleRadioButton2RadioButtonGroup;
        public static Template ButtonsExampleRadioButton2RadioButtonGroup
        {
            get
            {
#if UNITY_EDITOR
                if (_buttonsExampleRadioButton2RadioButtonGroup == null || _buttonsExampleRadioButton2RadioButtonGroup.CurrentVersion != Template.Version)
#else
                if (_buttonsExampleRadioButton2RadioButtonGroup == null)
#endif
                {
                    _buttonsExampleRadioButton2RadioButtonGroup = new Template(RadioButtonTemplates.RadioButtonRadioButtonGroup);
#if UNITY_EDITOR
                    _buttonsExampleRadioButton2RadioButtonGroup.Name = "ButtonsExampleRadioButton2RadioButtonGroup";
                    _buttonsExampleRadioButton2RadioButtonGroup.LineNumber = 8;
                    _buttonsExampleRadioButton2RadioButtonGroup.LinePosition = 4;
#endif
                }
                return _buttonsExampleRadioButton2RadioButtonGroup;
            }
        }

        private static Template _buttonsExampleRadioButton2RadioButtonImageView;
        public static Template ButtonsExampleRadioButton2RadioButtonImageView
        {
            get
            {
#if UNITY_EDITOR
                if (_buttonsExampleRadioButton2RadioButtonImageView == null || _buttonsExampleRadioButton2RadioButtonImageView.CurrentVersion != Template.Version)
#else
                if (_buttonsExampleRadioButton2RadioButtonImageView == null)
#endif
                {
                    _buttonsExampleRadioButton2RadioButtonImageView = new Template(RadioButtonTemplates.RadioButtonRadioButtonImageView);
#if UNITY_EDITOR
                    _buttonsExampleRadioButton2RadioButtonImageView.Name = "ButtonsExampleRadioButton2RadioButtonImageView";
                    _buttonsExampleRadioButton2RadioButtonImageView.LineNumber = 9;
                    _buttonsExampleRadioButton2RadioButtonImageView.LinePosition = 6;
#endif
                }
                return _buttonsExampleRadioButton2RadioButtonImageView;
            }
        }

        private static Template _buttonsExampleRadioButton2RadioButtonLabel;
        public static Template ButtonsExampleRadioButton2RadioButtonLabel
        {
            get
            {
#if UNITY_EDITOR
                if (_buttonsExampleRadioButton2RadioButtonLabel == null || _buttonsExampleRadioButton2RadioButtonLabel.CurrentVersion != Template.Version)
#else
                if (_buttonsExampleRadioButton2RadioButtonLabel == null)
#endif
                {
                    _buttonsExampleRadioButton2RadioButtonLabel = new Template(RadioButtonTemplates.RadioButtonRadioButtonLabel);
#if UNITY_EDITOR
                    _buttonsExampleRadioButton2RadioButtonLabel.Name = "ButtonsExampleRadioButton2RadioButtonLabel";
                    _buttonsExampleRadioButton2RadioButtonLabel.LineNumber = 10;
                    _buttonsExampleRadioButton2RadioButtonLabel.LinePosition = 6;
#endif
                    Delight.Label.TextProperty.SetDefault(_buttonsExampleRadioButton2RadioButtonLabel, "Option 2");
                }
                return _buttonsExampleRadioButton2RadioButtonLabel;
            }
        }

        private static Template _buttonsExampleRadioButton3;
        public static Template ButtonsExampleRadioButton3
        {
            get
            {
#if UNITY_EDITOR
                if (_buttonsExampleRadioButton3 == null || _buttonsExampleRadioButton3.CurrentVersion != Template.Version)
#else
                if (_buttonsExampleRadioButton3 == null)
#endif
                {
                    _buttonsExampleRadioButton3 = new Template(RadioButtonTemplates.RadioButton);
#if UNITY_EDITOR
                    _buttonsExampleRadioButton3.Name = "ButtonsExampleRadioButton3";
                    _buttonsExampleRadioButton3.LineNumber = 15;
                    _buttonsExampleRadioButton3.LinePosition = 10;
#endif
                    Delight.RadioButton.RadioButtonGroupTemplateProperty.SetDefault(_buttonsExampleRadioButton3, ButtonsExampleRadioButton3RadioButtonGroup);
                    Delight.RadioButton.RadioButtonImageViewTemplateProperty.SetDefault(_buttonsExampleRadioButton3, ButtonsExampleRadioButton3RadioButtonImageView);
                    Delight.RadioButton.RadioButtonLabelTemplateProperty.SetDefault(_buttonsExampleRadioButton3, ButtonsExampleRadioButton3RadioButtonLabel);
                }
                return _buttonsExampleRadioButton3;
            }
        }

        private static Template _buttonsExampleRadioButton3RadioButtonGroup;
        public static Template ButtonsExampleRadioButton3RadioButtonGroup
        {
            get
            {
#if UNITY_EDITOR
                if (_buttonsExampleRadioButton3RadioButtonGroup == null || _buttonsExampleRadioButton3RadioButtonGroup.CurrentVersion != Template.Version)
#else
                if (_buttonsExampleRadioButton3RadioButtonGroup == null)
#endif
                {
                    _buttonsExampleRadioButton3RadioButtonGroup = new Template(RadioButtonTemplates.RadioButtonRadioButtonGroup);
#if UNITY_EDITOR
                    _buttonsExampleRadioButton3RadioButtonGroup.Name = "ButtonsExampleRadioButton3RadioButtonGroup";
                    _buttonsExampleRadioButton3RadioButtonGroup.LineNumber = 8;
                    _buttonsExampleRadioButton3RadioButtonGroup.LinePosition = 4;
#endif
                }
                return _buttonsExampleRadioButton3RadioButtonGroup;
            }
        }

        private static Template _buttonsExampleRadioButton3RadioButtonImageView;
        public static Template ButtonsExampleRadioButton3RadioButtonImageView
        {
            get
            {
#if UNITY_EDITOR
                if (_buttonsExampleRadioButton3RadioButtonImageView == null || _buttonsExampleRadioButton3RadioButtonImageView.CurrentVersion != Template.Version)
#else
                if (_buttonsExampleRadioButton3RadioButtonImageView == null)
#endif
                {
                    _buttonsExampleRadioButton3RadioButtonImageView = new Template(RadioButtonTemplates.RadioButtonRadioButtonImageView);
#if UNITY_EDITOR
                    _buttonsExampleRadioButton3RadioButtonImageView.Name = "ButtonsExampleRadioButton3RadioButtonImageView";
                    _buttonsExampleRadioButton3RadioButtonImageView.LineNumber = 9;
                    _buttonsExampleRadioButton3RadioButtonImageView.LinePosition = 6;
#endif
                }
                return _buttonsExampleRadioButton3RadioButtonImageView;
            }
        }

        private static Template _buttonsExampleRadioButton3RadioButtonLabel;
        public static Template ButtonsExampleRadioButton3RadioButtonLabel
        {
            get
            {
#if UNITY_EDITOR
                if (_buttonsExampleRadioButton3RadioButtonLabel == null || _buttonsExampleRadioButton3RadioButtonLabel.CurrentVersion != Template.Version)
#else
                if (_buttonsExampleRadioButton3RadioButtonLabel == null)
#endif
                {
                    _buttonsExampleRadioButton3RadioButtonLabel = new Template(RadioButtonTemplates.RadioButtonRadioButtonLabel);
#if UNITY_EDITOR
                    _buttonsExampleRadioButton3RadioButtonLabel.Name = "ButtonsExampleRadioButton3RadioButtonLabel";
                    _buttonsExampleRadioButton3RadioButtonLabel.LineNumber = 10;
                    _buttonsExampleRadioButton3RadioButtonLabel.LinePosition = 6;
#endif
                    Delight.Label.TextProperty.SetDefault(_buttonsExampleRadioButton3RadioButtonLabel, "Option 3");
                }
                return _buttonsExampleRadioButton3RadioButtonLabel;
            }
        }

        private static Template _buttonsExampleGroup5;
        public static Template ButtonsExampleGroup5
        {
            get
            {
#if UNITY_EDITOR
                if (_buttonsExampleGroup5 == null || _buttonsExampleGroup5.CurrentVersion != Template.Version)
#else
                if (_buttonsExampleGroup5 == null)
#endif
                {
                    _buttonsExampleGroup5 = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _buttonsExampleGroup5.Name = "ButtonsExampleGroup5";
                    _buttonsExampleGroup5.LineNumber = 19;
                    _buttonsExampleGroup5.LinePosition = 6;
#endif
                    Delight.Group.OrientationProperty.SetDefault(_buttonsExampleGroup5, Delight.ElementOrientation.Horizontal);
                    Delight.Group.SpacingProperty.SetDefault(_buttonsExampleGroup5, new ElementSize(15f, ElementSizeUnit.Pixels));
                }
                return _buttonsExampleGroup5;
            }
        }

        private static Template _buttonsExampleButton1;
        public static Template ButtonsExampleButton1
        {
            get
            {
#if UNITY_EDITOR
                if (_buttonsExampleButton1 == null || _buttonsExampleButton1.CurrentVersion != Template.Version)
#else
                if (_buttonsExampleButton1 == null)
#endif
                {
                    _buttonsExampleButton1 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _buttonsExampleButton1.Name = "ButtonsExampleButton1";
                    _buttonsExampleButton1.LineNumber = 20;
                    _buttonsExampleButton1.LinePosition = 8;
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_buttonsExampleButton1, ButtonsExampleButton1Label);
                }
                return _buttonsExampleButton1;
            }
        }

        private static Template _buttonsExampleButton1Label;
        public static Template ButtonsExampleButton1Label
        {
            get
            {
#if UNITY_EDITOR
                if (_buttonsExampleButton1Label == null || _buttonsExampleButton1Label.CurrentVersion != Template.Version)
#else
                if (_buttonsExampleButton1Label == null)
#endif
                {
                    _buttonsExampleButton1Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _buttonsExampleButton1Label.Name = "ButtonsExampleButton1Label";
                    _buttonsExampleButton1Label.LineNumber = 15;
                    _buttonsExampleButton1Label.LinePosition = 4;
#endif
                    Delight.Label.TextProperty.SetDefault(_buttonsExampleButton1Label, "Click Me");
                }
                return _buttonsExampleButton1Label;
            }
        }

        private static Template _buttonsExampleButton2;
        public static Template ButtonsExampleButton2
        {
            get
            {
#if UNITY_EDITOR
                if (_buttonsExampleButton2 == null || _buttonsExampleButton2.CurrentVersion != Template.Version)
#else
                if (_buttonsExampleButton2 == null)
#endif
                {
                    _buttonsExampleButton2 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _buttonsExampleButton2.Name = "ButtonsExampleButton2";
                    _buttonsExampleButton2.LineNumber = 21;
                    _buttonsExampleButton2.LinePosition = 8;
#endif
                    Delight.Button.IsToggleButtonProperty.SetDefault(_buttonsExampleButton2, true);
                    Delight.Button.WidthProperty.SetDefault(_buttonsExampleButton2, new ElementSize(100f, ElementSizeUnit.Pixels));
                    Delight.Button.LabelTemplateProperty.SetDefault(_buttonsExampleButton2, ButtonsExampleButton2Label);
                }
                return _buttonsExampleButton2;
            }
        }

        private static Template _buttonsExampleButton2Label;
        public static Template ButtonsExampleButton2Label
        {
            get
            {
#if UNITY_EDITOR
                if (_buttonsExampleButton2Label == null || _buttonsExampleButton2Label.CurrentVersion != Template.Version)
#else
                if (_buttonsExampleButton2Label == null)
#endif
                {
                    _buttonsExampleButton2Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _buttonsExampleButton2Label.Name = "ButtonsExampleButton2Label";
                    _buttonsExampleButton2Label.LineNumber = 15;
                    _buttonsExampleButton2Label.LinePosition = 4;
#endif
                }
                return _buttonsExampleButton2Label;
            }
        }

        private static Template _buttonsExampleLabel1;
        public static Template ButtonsExampleLabel1
        {
            get
            {
#if UNITY_EDITOR
                if (_buttonsExampleLabel1 == null || _buttonsExampleLabel1.CurrentVersion != Template.Version)
#else
                if (_buttonsExampleLabel1 == null)
#endif
                {
                    _buttonsExampleLabel1 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _buttonsExampleLabel1.Name = "ButtonsExampleLabel1";
                    _buttonsExampleLabel1.LineNumber = 22;
                    _buttonsExampleLabel1.LinePosition = 10;
#endif
                    Delight.Label.TextProperty.SetDefault(_buttonsExampleLabel1, "Toggle");
                    Delight.Label.OffsetProperty.SetDefault(_buttonsExampleLabel1, new ElementMargin(new ElementSize(35f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels)));
                    Delight.Label.AlignmentProperty.SetDefault(_buttonsExampleLabel1, Delight.ElementAlignment.Left);
                    Delight.Label.AutoSizeProperty.SetDefault(_buttonsExampleLabel1, Delight.AutoSize.Default);
                }
                return _buttonsExampleLabel1;
            }
        }

        private static Template _buttonsExampleImage1;
        public static Template ButtonsExampleImage1
        {
            get
            {
#if UNITY_EDITOR
                if (_buttonsExampleImage1 == null || _buttonsExampleImage1.CurrentVersion != Template.Version)
#else
                if (_buttonsExampleImage1 == null)
#endif
                {
                    _buttonsExampleImage1 = new Template(ImageTemplates.Image);
#if UNITY_EDITOR
                    _buttonsExampleImage1.Name = "ButtonsExampleImage1";
                    _buttonsExampleImage1.LineNumber = 23;
                    _buttonsExampleImage1.LinePosition = 10;
#endif
                    Delight.Image.SpriteProperty.SetDefault(_buttonsExampleImage1, Assets.Sprites["RainbowSquare"]);
                    Delight.Image.AlignmentProperty.SetDefault(_buttonsExampleImage1, Delight.ElementAlignment.Left);
                    Delight.Image.OffsetProperty.SetDefault(_buttonsExampleImage1, new ElementMargin(new ElementSize(5f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels)));
                }
                return _buttonsExampleImage1;
            }
        }

        private static Template _buttonsExampleLabel2;
        public static Template ButtonsExampleLabel2
        {
            get
            {
#if UNITY_EDITOR
                if (_buttonsExampleLabel2 == null || _buttonsExampleLabel2.CurrentVersion != Template.Version)
#else
                if (_buttonsExampleLabel2 == null)
#endif
                {
                    _buttonsExampleLabel2 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _buttonsExampleLabel2.Name = "ButtonsExampleLabel2";
                    _buttonsExampleLabel2.LineNumber = 27;
                    _buttonsExampleLabel2.LinePosition = 6;
#endif
                    Delight.Label.AutoSizeProperty.SetDefault(_buttonsExampleLabel2, Delight.AutoSize.Default);
                    Delight.Label.FontColorProperty.SetDefault(_buttonsExampleLabel2, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Label.TextProperty.SetHasBinding(_buttonsExampleLabel2);
                }
                return _buttonsExampleLabel2;
            }
        }

        private static Template _buttonsExampleComboBox;
        public static Template ButtonsExampleComboBox
        {
            get
            {
#if UNITY_EDITOR
                if (_buttonsExampleComboBox == null || _buttonsExampleComboBox.CurrentVersion != Template.Version)
#else
                if (_buttonsExampleComboBox == null)
#endif
                {
                    _buttonsExampleComboBox = new Template(ComboBoxTemplates.ComboBox);
#if UNITY_EDITOR
                    _buttonsExampleComboBox.Name = "ButtonsExampleComboBox";
                    _buttonsExampleComboBox.LineNumber = 29;
                    _buttonsExampleComboBox.LinePosition = 6;
#endif
                    Delight.ComboBox.IsDropUpProperty.SetDefault(_buttonsExampleComboBox, false);
                    Delight.ComboBox.ComboBoxButtonTemplateProperty.SetDefault(_buttonsExampleComboBox, ButtonsExampleComboBoxComboBoxButton);
                    Delight.ComboBox.ComboBoxListCanvasTemplateProperty.SetDefault(_buttonsExampleComboBox, ButtonsExampleComboBoxComboBoxListCanvas);
                    Delight.ComboBox.ComboBoxListTemplateProperty.SetDefault(_buttonsExampleComboBox, ButtonsExampleComboBoxComboBoxList);
                }
                return _buttonsExampleComboBox;
            }
        }

        private static Template _buttonsExampleComboBoxComboBoxButton;
        public static Template ButtonsExampleComboBoxComboBoxButton
        {
            get
            {
#if UNITY_EDITOR
                if (_buttonsExampleComboBoxComboBoxButton == null || _buttonsExampleComboBoxComboBoxButton.CurrentVersion != Template.Version)
#else
                if (_buttonsExampleComboBoxComboBoxButton == null)
#endif
                {
                    _buttonsExampleComboBoxComboBoxButton = new Template(ComboBoxTemplates.ComboBoxComboBoxButton);
#if UNITY_EDITOR
                    _buttonsExampleComboBoxComboBoxButton.Name = "ButtonsExampleComboBoxComboBoxButton";
                    _buttonsExampleComboBoxComboBoxButton.LineNumber = 10;
                    _buttonsExampleComboBoxComboBoxButton.LinePosition = 4;
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_buttonsExampleComboBoxComboBoxButton, ButtonsExampleComboBoxComboBoxButtonLabel);
                }
                return _buttonsExampleComboBoxComboBoxButton;
            }
        }

        private static Template _buttonsExampleComboBoxComboBoxButtonLabel;
        public static Template ButtonsExampleComboBoxComboBoxButtonLabel
        {
            get
            {
#if UNITY_EDITOR
                if (_buttonsExampleComboBoxComboBoxButtonLabel == null || _buttonsExampleComboBoxComboBoxButtonLabel.CurrentVersion != Template.Version)
#else
                if (_buttonsExampleComboBoxComboBoxButtonLabel == null)
#endif
                {
                    _buttonsExampleComboBoxComboBoxButtonLabel = new Template(ComboBoxTemplates.ComboBoxComboBoxButtonLabel);
#if UNITY_EDITOR
                    _buttonsExampleComboBoxComboBoxButtonLabel.Name = "ButtonsExampleComboBoxComboBoxButtonLabel";
                    _buttonsExampleComboBoxComboBoxButtonLabel.LineNumber = 15;
                    _buttonsExampleComboBoxComboBoxButtonLabel.LinePosition = 4;
#endif
                }
                return _buttonsExampleComboBoxComboBoxButtonLabel;
            }
        }

        private static Template _buttonsExampleComboBoxComboBoxListCanvas;
        public static Template ButtonsExampleComboBoxComboBoxListCanvas
        {
            get
            {
#if UNITY_EDITOR
                if (_buttonsExampleComboBoxComboBoxListCanvas == null || _buttonsExampleComboBoxComboBoxListCanvas.CurrentVersion != Template.Version)
#else
                if (_buttonsExampleComboBoxComboBoxListCanvas == null)
#endif
                {
                    _buttonsExampleComboBoxComboBoxListCanvas = new Template(ComboBoxTemplates.ComboBoxComboBoxListCanvas);
#if UNITY_EDITOR
                    _buttonsExampleComboBoxComboBoxListCanvas.Name = "ButtonsExampleComboBoxComboBoxListCanvas";
                    _buttonsExampleComboBoxComboBoxListCanvas.LineNumber = 11;
                    _buttonsExampleComboBoxComboBoxListCanvas.LinePosition = 4;
#endif
                }
                return _buttonsExampleComboBoxComboBoxListCanvas;
            }
        }

        private static Template _buttonsExampleComboBoxComboBoxList;
        public static Template ButtonsExampleComboBoxComboBoxList
        {
            get
            {
#if UNITY_EDITOR
                if (_buttonsExampleComboBoxComboBoxList == null || _buttonsExampleComboBoxComboBoxList.CurrentVersion != Template.Version)
#else
                if (_buttonsExampleComboBoxComboBoxList == null)
#endif
                {
                    _buttonsExampleComboBoxComboBoxList = new Template(ComboBoxTemplates.ComboBoxComboBoxList);
#if UNITY_EDITOR
                    _buttonsExampleComboBoxComboBoxList.Name = "ButtonsExampleComboBoxComboBoxList";
                    _buttonsExampleComboBoxComboBoxList.LineNumber = 12;
                    _buttonsExampleComboBoxComboBoxList.LinePosition = 6;
#endif
                    Delight.List.ItemsProperty.SetHasBinding(_buttonsExampleComboBoxComboBoxList);
                    Delight.List.ScrollableRegionTemplateProperty.SetDefault(_buttonsExampleComboBoxComboBoxList, ButtonsExampleComboBoxComboBoxListScrollableRegion);
                }
                return _buttonsExampleComboBoxComboBoxList;
            }
        }

        private static Template _buttonsExampleComboBoxComboBoxListScrollableRegion;
        public static Template ButtonsExampleComboBoxComboBoxListScrollableRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_buttonsExampleComboBoxComboBoxListScrollableRegion == null || _buttonsExampleComboBoxComboBoxListScrollableRegion.CurrentVersion != Template.Version)
#else
                if (_buttonsExampleComboBoxComboBoxListScrollableRegion == null)
#endif
                {
                    _buttonsExampleComboBoxComboBoxListScrollableRegion = new Template(ComboBoxTemplates.ComboBoxComboBoxListScrollableRegion);
#if UNITY_EDITOR
                    _buttonsExampleComboBoxComboBoxListScrollableRegion.Name = "ButtonsExampleComboBoxComboBoxListScrollableRegion";
                    _buttonsExampleComboBoxComboBoxListScrollableRegion.LineNumber = 27;
                    _buttonsExampleComboBoxComboBoxListScrollableRegion.LinePosition = 4;
#endif
                    Delight.ScrollableRegion.ContentRegionTemplateProperty.SetDefault(_buttonsExampleComboBoxComboBoxListScrollableRegion, ButtonsExampleComboBoxComboBoxListScrollableRegionContentRegion);
                    Delight.ScrollableRegion.HorizontalScrollbarTemplateProperty.SetDefault(_buttonsExampleComboBoxComboBoxListScrollableRegion, ButtonsExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbar);
                    Delight.ScrollableRegion.VerticalScrollbarTemplateProperty.SetDefault(_buttonsExampleComboBoxComboBoxListScrollableRegion, ButtonsExampleComboBoxComboBoxListScrollableRegionVerticalScrollbar);
                }
                return _buttonsExampleComboBoxComboBoxListScrollableRegion;
            }
        }

        private static Template _buttonsExampleComboBoxComboBoxListScrollableRegionContentRegion;
        public static Template ButtonsExampleComboBoxComboBoxListScrollableRegionContentRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_buttonsExampleComboBoxComboBoxListScrollableRegionContentRegion == null || _buttonsExampleComboBoxComboBoxListScrollableRegionContentRegion.CurrentVersion != Template.Version)
#else
                if (_buttonsExampleComboBoxComboBoxListScrollableRegionContentRegion == null)
#endif
                {
                    _buttonsExampleComboBoxComboBoxListScrollableRegionContentRegion = new Template(ComboBoxTemplates.ComboBoxComboBoxListScrollableRegionContentRegion);
#if UNITY_EDITOR
                    _buttonsExampleComboBoxComboBoxListScrollableRegionContentRegion.Name = "ButtonsExampleComboBoxComboBoxListScrollableRegionContentRegion";
                    _buttonsExampleComboBoxComboBoxListScrollableRegionContentRegion.LineNumber = 24;
                    _buttonsExampleComboBoxComboBoxListScrollableRegionContentRegion.LinePosition = 4;
#endif
                }
                return _buttonsExampleComboBoxComboBoxListScrollableRegionContentRegion;
            }
        }

        private static Template _buttonsExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbar;
        public static Template ButtonsExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_buttonsExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbar == null || _buttonsExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbar.CurrentVersion != Template.Version)
#else
                if (_buttonsExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbar == null)
#endif
                {
                    _buttonsExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbar = new Template(ComboBoxTemplates.ComboBoxComboBoxListScrollableRegionHorizontalScrollbar);
#if UNITY_EDITOR
                    _buttonsExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbar.Name = "ButtonsExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbar";
                    _buttonsExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbar.LineNumber = 26;
                    _buttonsExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbar.LinePosition = 4;
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_buttonsExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbar, ButtonsExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_buttonsExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbar, ButtonsExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbarHandle);
                }
                return _buttonsExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbar;
            }
        }

        private static Template _buttonsExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbarBar;
        public static Template ButtonsExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_buttonsExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbarBar == null || _buttonsExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_buttonsExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbarBar == null)
#endif
                {
                    _buttonsExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbarBar = new Template(ComboBoxTemplates.ComboBoxComboBoxListScrollableRegionHorizontalScrollbarBar);
#if UNITY_EDITOR
                    _buttonsExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbarBar.Name = "ButtonsExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbarBar";
                    _buttonsExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbarBar.LineNumber = 7;
                    _buttonsExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbarBar.LinePosition = 4;
#endif
                }
                return _buttonsExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbarBar;
            }
        }

        private static Template _buttonsExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbarHandle;
        public static Template ButtonsExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_buttonsExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbarHandle == null || _buttonsExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_buttonsExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbarHandle == null)
#endif
                {
                    _buttonsExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbarHandle = new Template(ComboBoxTemplates.ComboBoxComboBoxListScrollableRegionHorizontalScrollbarHandle);
#if UNITY_EDITOR
                    _buttonsExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbarHandle.Name = "ButtonsExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbarHandle";
                    _buttonsExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbarHandle.LineNumber = 8;
                    _buttonsExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbarHandle.LinePosition = 6;
#endif
                }
                return _buttonsExampleComboBoxComboBoxListScrollableRegionHorizontalScrollbarHandle;
            }
        }

        private static Template _buttonsExampleComboBoxComboBoxListScrollableRegionVerticalScrollbar;
        public static Template ButtonsExampleComboBoxComboBoxListScrollableRegionVerticalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_buttonsExampleComboBoxComboBoxListScrollableRegionVerticalScrollbar == null || _buttonsExampleComboBoxComboBoxListScrollableRegionVerticalScrollbar.CurrentVersion != Template.Version)
#else
                if (_buttonsExampleComboBoxComboBoxListScrollableRegionVerticalScrollbar == null)
#endif
                {
                    _buttonsExampleComboBoxComboBoxListScrollableRegionVerticalScrollbar = new Template(ComboBoxTemplates.ComboBoxComboBoxListScrollableRegionVerticalScrollbar);
#if UNITY_EDITOR
                    _buttonsExampleComboBoxComboBoxListScrollableRegionVerticalScrollbar.Name = "ButtonsExampleComboBoxComboBoxListScrollableRegionVerticalScrollbar";
                    _buttonsExampleComboBoxComboBoxListScrollableRegionVerticalScrollbar.LineNumber = 27;
                    _buttonsExampleComboBoxComboBoxListScrollableRegionVerticalScrollbar.LinePosition = 4;
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_buttonsExampleComboBoxComboBoxListScrollableRegionVerticalScrollbar, ButtonsExampleComboBoxComboBoxListScrollableRegionVerticalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_buttonsExampleComboBoxComboBoxListScrollableRegionVerticalScrollbar, ButtonsExampleComboBoxComboBoxListScrollableRegionVerticalScrollbarHandle);
                }
                return _buttonsExampleComboBoxComboBoxListScrollableRegionVerticalScrollbar;
            }
        }

        private static Template _buttonsExampleComboBoxComboBoxListScrollableRegionVerticalScrollbarBar;
        public static Template ButtonsExampleComboBoxComboBoxListScrollableRegionVerticalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_buttonsExampleComboBoxComboBoxListScrollableRegionVerticalScrollbarBar == null || _buttonsExampleComboBoxComboBoxListScrollableRegionVerticalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_buttonsExampleComboBoxComboBoxListScrollableRegionVerticalScrollbarBar == null)
#endif
                {
                    _buttonsExampleComboBoxComboBoxListScrollableRegionVerticalScrollbarBar = new Template(ComboBoxTemplates.ComboBoxComboBoxListScrollableRegionVerticalScrollbarBar);
#if UNITY_EDITOR
                    _buttonsExampleComboBoxComboBoxListScrollableRegionVerticalScrollbarBar.Name = "ButtonsExampleComboBoxComboBoxListScrollableRegionVerticalScrollbarBar";
                    _buttonsExampleComboBoxComboBoxListScrollableRegionVerticalScrollbarBar.LineNumber = 7;
                    _buttonsExampleComboBoxComboBoxListScrollableRegionVerticalScrollbarBar.LinePosition = 4;
#endif
                }
                return _buttonsExampleComboBoxComboBoxListScrollableRegionVerticalScrollbarBar;
            }
        }

        private static Template _buttonsExampleComboBoxComboBoxListScrollableRegionVerticalScrollbarHandle;
        public static Template ButtonsExampleComboBoxComboBoxListScrollableRegionVerticalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_buttonsExampleComboBoxComboBoxListScrollableRegionVerticalScrollbarHandle == null || _buttonsExampleComboBoxComboBoxListScrollableRegionVerticalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_buttonsExampleComboBoxComboBoxListScrollableRegionVerticalScrollbarHandle == null)
#endif
                {
                    _buttonsExampleComboBoxComboBoxListScrollableRegionVerticalScrollbarHandle = new Template(ComboBoxTemplates.ComboBoxComboBoxListScrollableRegionVerticalScrollbarHandle);
#if UNITY_EDITOR
                    _buttonsExampleComboBoxComboBoxListScrollableRegionVerticalScrollbarHandle.Name = "ButtonsExampleComboBoxComboBoxListScrollableRegionVerticalScrollbarHandle";
                    _buttonsExampleComboBoxComboBoxListScrollableRegionVerticalScrollbarHandle.LineNumber = 8;
                    _buttonsExampleComboBoxComboBoxListScrollableRegionVerticalScrollbarHandle.LinePosition = 6;
#endif
                }
                return _buttonsExampleComboBoxComboBoxListScrollableRegionVerticalScrollbarHandle;
            }
        }

        private static Template _buttonsExampleComboBoxContent;
        public static Template ButtonsExampleComboBoxContent
        {
            get
            {
#if UNITY_EDITOR
                if (_buttonsExampleComboBoxContent == null || _buttonsExampleComboBoxContent.CurrentVersion != Template.Version)
#else
                if (_buttonsExampleComboBoxContent == null)
#endif
                {
                    _buttonsExampleComboBoxContent = new Template(ComboBoxListItemTemplates.ComboBoxListItem);
#if UNITY_EDITOR
                    _buttonsExampleComboBoxContent.Name = "ButtonsExampleComboBoxContent";
                    _buttonsExampleComboBoxContent.LineNumber = 0;
                    _buttonsExampleComboBoxContent.LinePosition = 0;
#endif
                }
                return _buttonsExampleComboBoxContent;
            }
        }

        private static Template _buttonsExampleLabel3;
        public static Template ButtonsExampleLabel3
        {
            get
            {
#if UNITY_EDITOR
                if (_buttonsExampleLabel3 == null || _buttonsExampleLabel3.CurrentVersion != Template.Version)
#else
                if (_buttonsExampleLabel3 == null)
#endif
                {
                    _buttonsExampleLabel3 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _buttonsExampleLabel3.Name = "ButtonsExampleLabel3";
                    _buttonsExampleLabel3.LineNumber = 30;
                    _buttonsExampleLabel3.LinePosition = 8;
#endif
                    Delight.Label.WidthProperty.SetDefault(_buttonsExampleLabel3, new ElementSize(1f, ElementSizeUnit.Percents));
                    Delight.Label.MarginProperty.SetDefault(_buttonsExampleLabel3, new ElementMargin(new ElementSize(10f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels)));
                    Delight.Label.TextProperty.SetHasBinding(_buttonsExampleLabel3);
                }
                return _buttonsExampleLabel3;
            }
        }

        private static Template _buttonsExampleComboBox1;
        public static Template ButtonsExampleComboBox1
        {
            get
            {
#if UNITY_EDITOR
                if (_buttonsExampleComboBox1 == null || _buttonsExampleComboBox1.CurrentVersion != Template.Version)
#else
                if (_buttonsExampleComboBox1 == null)
#endif
                {
                    _buttonsExampleComboBox1 = new Template(ComboBoxTemplates.ComboBox);
#if UNITY_EDITOR
                    _buttonsExampleComboBox1.Name = "ButtonsExampleComboBox1";
                    _buttonsExampleComboBox1.LineNumber = 33;
                    _buttonsExampleComboBox1.LinePosition = 6;
#endif
                    Delight.ComboBox.IsDropUpProperty.SetDefault(_buttonsExampleComboBox1, false);
                    Delight.ComboBox.ComboBoxButtonTemplateProperty.SetDefault(_buttonsExampleComboBox1, ButtonsExampleComboBox1ComboBoxButton);
                    Delight.ComboBox.ComboBoxListCanvasTemplateProperty.SetDefault(_buttonsExampleComboBox1, ButtonsExampleComboBox1ComboBoxListCanvas);
                    Delight.ComboBox.ComboBoxListTemplateProperty.SetDefault(_buttonsExampleComboBox1, ButtonsExampleComboBox1ComboBoxList);
                }
                return _buttonsExampleComboBox1;
            }
        }

        private static Template _buttonsExampleComboBox1ComboBoxButton;
        public static Template ButtonsExampleComboBox1ComboBoxButton
        {
            get
            {
#if UNITY_EDITOR
                if (_buttonsExampleComboBox1ComboBoxButton == null || _buttonsExampleComboBox1ComboBoxButton.CurrentVersion != Template.Version)
#else
                if (_buttonsExampleComboBox1ComboBoxButton == null)
#endif
                {
                    _buttonsExampleComboBox1ComboBoxButton = new Template(ComboBoxTemplates.ComboBoxComboBoxButton);
#if UNITY_EDITOR
                    _buttonsExampleComboBox1ComboBoxButton.Name = "ButtonsExampleComboBox1ComboBoxButton";
                    _buttonsExampleComboBox1ComboBoxButton.LineNumber = 10;
                    _buttonsExampleComboBox1ComboBoxButton.LinePosition = 4;
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_buttonsExampleComboBox1ComboBoxButton, ButtonsExampleComboBox1ComboBoxButtonLabel);
                }
                return _buttonsExampleComboBox1ComboBoxButton;
            }
        }

        private static Template _buttonsExampleComboBox1ComboBoxButtonLabel;
        public static Template ButtonsExampleComboBox1ComboBoxButtonLabel
        {
            get
            {
#if UNITY_EDITOR
                if (_buttonsExampleComboBox1ComboBoxButtonLabel == null || _buttonsExampleComboBox1ComboBoxButtonLabel.CurrentVersion != Template.Version)
#else
                if (_buttonsExampleComboBox1ComboBoxButtonLabel == null)
#endif
                {
                    _buttonsExampleComboBox1ComboBoxButtonLabel = new Template(ComboBoxTemplates.ComboBoxComboBoxButtonLabel);
#if UNITY_EDITOR
                    _buttonsExampleComboBox1ComboBoxButtonLabel.Name = "ButtonsExampleComboBox1ComboBoxButtonLabel";
                    _buttonsExampleComboBox1ComboBoxButtonLabel.LineNumber = 15;
                    _buttonsExampleComboBox1ComboBoxButtonLabel.LinePosition = 4;
#endif
                }
                return _buttonsExampleComboBox1ComboBoxButtonLabel;
            }
        }

        private static Template _buttonsExampleComboBox1ComboBoxListCanvas;
        public static Template ButtonsExampleComboBox1ComboBoxListCanvas
        {
            get
            {
#if UNITY_EDITOR
                if (_buttonsExampleComboBox1ComboBoxListCanvas == null || _buttonsExampleComboBox1ComboBoxListCanvas.CurrentVersion != Template.Version)
#else
                if (_buttonsExampleComboBox1ComboBoxListCanvas == null)
#endif
                {
                    _buttonsExampleComboBox1ComboBoxListCanvas = new Template(ComboBoxTemplates.ComboBoxComboBoxListCanvas);
#if UNITY_EDITOR
                    _buttonsExampleComboBox1ComboBoxListCanvas.Name = "ButtonsExampleComboBox1ComboBoxListCanvas";
                    _buttonsExampleComboBox1ComboBoxListCanvas.LineNumber = 11;
                    _buttonsExampleComboBox1ComboBoxListCanvas.LinePosition = 4;
#endif
                }
                return _buttonsExampleComboBox1ComboBoxListCanvas;
            }
        }

        private static Template _buttonsExampleComboBox1ComboBoxList;
        public static Template ButtonsExampleComboBox1ComboBoxList
        {
            get
            {
#if UNITY_EDITOR
                if (_buttonsExampleComboBox1ComboBoxList == null || _buttonsExampleComboBox1ComboBoxList.CurrentVersion != Template.Version)
#else
                if (_buttonsExampleComboBox1ComboBoxList == null)
#endif
                {
                    _buttonsExampleComboBox1ComboBoxList = new Template(ComboBoxTemplates.ComboBoxComboBoxList);
#if UNITY_EDITOR
                    _buttonsExampleComboBox1ComboBoxList.Name = "ButtonsExampleComboBox1ComboBoxList";
                    _buttonsExampleComboBox1ComboBoxList.LineNumber = 12;
                    _buttonsExampleComboBox1ComboBoxList.LinePosition = 6;
#endif
                    Delight.List.ScrollableRegionTemplateProperty.SetDefault(_buttonsExampleComboBox1ComboBoxList, ButtonsExampleComboBox1ComboBoxListScrollableRegion);
                }
                return _buttonsExampleComboBox1ComboBoxList;
            }
        }

        private static Template _buttonsExampleComboBox1ComboBoxListScrollableRegion;
        public static Template ButtonsExampleComboBox1ComboBoxListScrollableRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_buttonsExampleComboBox1ComboBoxListScrollableRegion == null || _buttonsExampleComboBox1ComboBoxListScrollableRegion.CurrentVersion != Template.Version)
#else
                if (_buttonsExampleComboBox1ComboBoxListScrollableRegion == null)
#endif
                {
                    _buttonsExampleComboBox1ComboBoxListScrollableRegion = new Template(ComboBoxTemplates.ComboBoxComboBoxListScrollableRegion);
#if UNITY_EDITOR
                    _buttonsExampleComboBox1ComboBoxListScrollableRegion.Name = "ButtonsExampleComboBox1ComboBoxListScrollableRegion";
                    _buttonsExampleComboBox1ComboBoxListScrollableRegion.LineNumber = 27;
                    _buttonsExampleComboBox1ComboBoxListScrollableRegion.LinePosition = 4;
#endif
                    Delight.ScrollableRegion.ContentRegionTemplateProperty.SetDefault(_buttonsExampleComboBox1ComboBoxListScrollableRegion, ButtonsExampleComboBox1ComboBoxListScrollableRegionContentRegion);
                    Delight.ScrollableRegion.HorizontalScrollbarTemplateProperty.SetDefault(_buttonsExampleComboBox1ComboBoxListScrollableRegion, ButtonsExampleComboBox1ComboBoxListScrollableRegionHorizontalScrollbar);
                    Delight.ScrollableRegion.VerticalScrollbarTemplateProperty.SetDefault(_buttonsExampleComboBox1ComboBoxListScrollableRegion, ButtonsExampleComboBox1ComboBoxListScrollableRegionVerticalScrollbar);
                }
                return _buttonsExampleComboBox1ComboBoxListScrollableRegion;
            }
        }

        private static Template _buttonsExampleComboBox1ComboBoxListScrollableRegionContentRegion;
        public static Template ButtonsExampleComboBox1ComboBoxListScrollableRegionContentRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_buttonsExampleComboBox1ComboBoxListScrollableRegionContentRegion == null || _buttonsExampleComboBox1ComboBoxListScrollableRegionContentRegion.CurrentVersion != Template.Version)
#else
                if (_buttonsExampleComboBox1ComboBoxListScrollableRegionContentRegion == null)
#endif
                {
                    _buttonsExampleComboBox1ComboBoxListScrollableRegionContentRegion = new Template(ComboBoxTemplates.ComboBoxComboBoxListScrollableRegionContentRegion);
#if UNITY_EDITOR
                    _buttonsExampleComboBox1ComboBoxListScrollableRegionContentRegion.Name = "ButtonsExampleComboBox1ComboBoxListScrollableRegionContentRegion";
                    _buttonsExampleComboBox1ComboBoxListScrollableRegionContentRegion.LineNumber = 24;
                    _buttonsExampleComboBox1ComboBoxListScrollableRegionContentRegion.LinePosition = 4;
#endif
                }
                return _buttonsExampleComboBox1ComboBoxListScrollableRegionContentRegion;
            }
        }

        private static Template _buttonsExampleComboBox1ComboBoxListScrollableRegionHorizontalScrollbar;
        public static Template ButtonsExampleComboBox1ComboBoxListScrollableRegionHorizontalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_buttonsExampleComboBox1ComboBoxListScrollableRegionHorizontalScrollbar == null || _buttonsExampleComboBox1ComboBoxListScrollableRegionHorizontalScrollbar.CurrentVersion != Template.Version)
#else
                if (_buttonsExampleComboBox1ComboBoxListScrollableRegionHorizontalScrollbar == null)
#endif
                {
                    _buttonsExampleComboBox1ComboBoxListScrollableRegionHorizontalScrollbar = new Template(ComboBoxTemplates.ComboBoxComboBoxListScrollableRegionHorizontalScrollbar);
#if UNITY_EDITOR
                    _buttonsExampleComboBox1ComboBoxListScrollableRegionHorizontalScrollbar.Name = "ButtonsExampleComboBox1ComboBoxListScrollableRegionHorizontalScrollbar";
                    _buttonsExampleComboBox1ComboBoxListScrollableRegionHorizontalScrollbar.LineNumber = 26;
                    _buttonsExampleComboBox1ComboBoxListScrollableRegionHorizontalScrollbar.LinePosition = 4;
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_buttonsExampleComboBox1ComboBoxListScrollableRegionHorizontalScrollbar, ButtonsExampleComboBox1ComboBoxListScrollableRegionHorizontalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_buttonsExampleComboBox1ComboBoxListScrollableRegionHorizontalScrollbar, ButtonsExampleComboBox1ComboBoxListScrollableRegionHorizontalScrollbarHandle);
                }
                return _buttonsExampleComboBox1ComboBoxListScrollableRegionHorizontalScrollbar;
            }
        }

        private static Template _buttonsExampleComboBox1ComboBoxListScrollableRegionHorizontalScrollbarBar;
        public static Template ButtonsExampleComboBox1ComboBoxListScrollableRegionHorizontalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_buttonsExampleComboBox1ComboBoxListScrollableRegionHorizontalScrollbarBar == null || _buttonsExampleComboBox1ComboBoxListScrollableRegionHorizontalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_buttonsExampleComboBox1ComboBoxListScrollableRegionHorizontalScrollbarBar == null)
#endif
                {
                    _buttonsExampleComboBox1ComboBoxListScrollableRegionHorizontalScrollbarBar = new Template(ComboBoxTemplates.ComboBoxComboBoxListScrollableRegionHorizontalScrollbarBar);
#if UNITY_EDITOR
                    _buttonsExampleComboBox1ComboBoxListScrollableRegionHorizontalScrollbarBar.Name = "ButtonsExampleComboBox1ComboBoxListScrollableRegionHorizontalScrollbarBar";
                    _buttonsExampleComboBox1ComboBoxListScrollableRegionHorizontalScrollbarBar.LineNumber = 7;
                    _buttonsExampleComboBox1ComboBoxListScrollableRegionHorizontalScrollbarBar.LinePosition = 4;
#endif
                }
                return _buttonsExampleComboBox1ComboBoxListScrollableRegionHorizontalScrollbarBar;
            }
        }

        private static Template _buttonsExampleComboBox1ComboBoxListScrollableRegionHorizontalScrollbarHandle;
        public static Template ButtonsExampleComboBox1ComboBoxListScrollableRegionHorizontalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_buttonsExampleComboBox1ComboBoxListScrollableRegionHorizontalScrollbarHandle == null || _buttonsExampleComboBox1ComboBoxListScrollableRegionHorizontalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_buttonsExampleComboBox1ComboBoxListScrollableRegionHorizontalScrollbarHandle == null)
#endif
                {
                    _buttonsExampleComboBox1ComboBoxListScrollableRegionHorizontalScrollbarHandle = new Template(ComboBoxTemplates.ComboBoxComboBoxListScrollableRegionHorizontalScrollbarHandle);
#if UNITY_EDITOR
                    _buttonsExampleComboBox1ComboBoxListScrollableRegionHorizontalScrollbarHandle.Name = "ButtonsExampleComboBox1ComboBoxListScrollableRegionHorizontalScrollbarHandle";
                    _buttonsExampleComboBox1ComboBoxListScrollableRegionHorizontalScrollbarHandle.LineNumber = 8;
                    _buttonsExampleComboBox1ComboBoxListScrollableRegionHorizontalScrollbarHandle.LinePosition = 6;
#endif
                }
                return _buttonsExampleComboBox1ComboBoxListScrollableRegionHorizontalScrollbarHandle;
            }
        }

        private static Template _buttonsExampleComboBox1ComboBoxListScrollableRegionVerticalScrollbar;
        public static Template ButtonsExampleComboBox1ComboBoxListScrollableRegionVerticalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_buttonsExampleComboBox1ComboBoxListScrollableRegionVerticalScrollbar == null || _buttonsExampleComboBox1ComboBoxListScrollableRegionVerticalScrollbar.CurrentVersion != Template.Version)
#else
                if (_buttonsExampleComboBox1ComboBoxListScrollableRegionVerticalScrollbar == null)
#endif
                {
                    _buttonsExampleComboBox1ComboBoxListScrollableRegionVerticalScrollbar = new Template(ComboBoxTemplates.ComboBoxComboBoxListScrollableRegionVerticalScrollbar);
#if UNITY_EDITOR
                    _buttonsExampleComboBox1ComboBoxListScrollableRegionVerticalScrollbar.Name = "ButtonsExampleComboBox1ComboBoxListScrollableRegionVerticalScrollbar";
                    _buttonsExampleComboBox1ComboBoxListScrollableRegionVerticalScrollbar.LineNumber = 27;
                    _buttonsExampleComboBox1ComboBoxListScrollableRegionVerticalScrollbar.LinePosition = 4;
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_buttonsExampleComboBox1ComboBoxListScrollableRegionVerticalScrollbar, ButtonsExampleComboBox1ComboBoxListScrollableRegionVerticalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_buttonsExampleComboBox1ComboBoxListScrollableRegionVerticalScrollbar, ButtonsExampleComboBox1ComboBoxListScrollableRegionVerticalScrollbarHandle);
                }
                return _buttonsExampleComboBox1ComboBoxListScrollableRegionVerticalScrollbar;
            }
        }

        private static Template _buttonsExampleComboBox1ComboBoxListScrollableRegionVerticalScrollbarBar;
        public static Template ButtonsExampleComboBox1ComboBoxListScrollableRegionVerticalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_buttonsExampleComboBox1ComboBoxListScrollableRegionVerticalScrollbarBar == null || _buttonsExampleComboBox1ComboBoxListScrollableRegionVerticalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_buttonsExampleComboBox1ComboBoxListScrollableRegionVerticalScrollbarBar == null)
#endif
                {
                    _buttonsExampleComboBox1ComboBoxListScrollableRegionVerticalScrollbarBar = new Template(ComboBoxTemplates.ComboBoxComboBoxListScrollableRegionVerticalScrollbarBar);
#if UNITY_EDITOR
                    _buttonsExampleComboBox1ComboBoxListScrollableRegionVerticalScrollbarBar.Name = "ButtonsExampleComboBox1ComboBoxListScrollableRegionVerticalScrollbarBar";
                    _buttonsExampleComboBox1ComboBoxListScrollableRegionVerticalScrollbarBar.LineNumber = 7;
                    _buttonsExampleComboBox1ComboBoxListScrollableRegionVerticalScrollbarBar.LinePosition = 4;
#endif
                }
                return _buttonsExampleComboBox1ComboBoxListScrollableRegionVerticalScrollbarBar;
            }
        }

        private static Template _buttonsExampleComboBox1ComboBoxListScrollableRegionVerticalScrollbarHandle;
        public static Template ButtonsExampleComboBox1ComboBoxListScrollableRegionVerticalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_buttonsExampleComboBox1ComboBoxListScrollableRegionVerticalScrollbarHandle == null || _buttonsExampleComboBox1ComboBoxListScrollableRegionVerticalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_buttonsExampleComboBox1ComboBoxListScrollableRegionVerticalScrollbarHandle == null)
#endif
                {
                    _buttonsExampleComboBox1ComboBoxListScrollableRegionVerticalScrollbarHandle = new Template(ComboBoxTemplates.ComboBoxComboBoxListScrollableRegionVerticalScrollbarHandle);
#if UNITY_EDITOR
                    _buttonsExampleComboBox1ComboBoxListScrollableRegionVerticalScrollbarHandle.Name = "ButtonsExampleComboBox1ComboBoxListScrollableRegionVerticalScrollbarHandle";
                    _buttonsExampleComboBox1ComboBoxListScrollableRegionVerticalScrollbarHandle.LineNumber = 8;
                    _buttonsExampleComboBox1ComboBoxListScrollableRegionVerticalScrollbarHandle.LinePosition = 6;
#endif
                }
                return _buttonsExampleComboBox1ComboBoxListScrollableRegionVerticalScrollbarHandle;
            }
        }

        private static Template _buttonsExampleComboBoxListItem1;
        public static Template ButtonsExampleComboBoxListItem1
        {
            get
            {
#if UNITY_EDITOR
                if (_buttonsExampleComboBoxListItem1 == null || _buttonsExampleComboBoxListItem1.CurrentVersion != Template.Version)
#else
                if (_buttonsExampleComboBoxListItem1 == null)
#endif
                {
                    _buttonsExampleComboBoxListItem1 = new Template(ComboBoxListItemTemplates.ComboBoxListItem);
#if UNITY_EDITOR
                    _buttonsExampleComboBoxListItem1.Name = "ButtonsExampleComboBoxListItem1";
                    _buttonsExampleComboBoxListItem1.LineNumber = 34;
                    _buttonsExampleComboBoxListItem1.LinePosition = 8;
#endif
                }
                return _buttonsExampleComboBoxListItem1;
            }
        }

        private static Template _buttonsExampleLabel4;
        public static Template ButtonsExampleLabel4
        {
            get
            {
#if UNITY_EDITOR
                if (_buttonsExampleLabel4 == null || _buttonsExampleLabel4.CurrentVersion != Template.Version)
#else
                if (_buttonsExampleLabel4 == null)
#endif
                {
                    _buttonsExampleLabel4 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _buttonsExampleLabel4.Name = "ButtonsExampleLabel4";
                    _buttonsExampleLabel4.LineNumber = 35;
                    _buttonsExampleLabel4.LinePosition = 10;
#endif
                    Delight.Label.TextProperty.SetDefault(_buttonsExampleLabel4, "Option 1");
                    Delight.Label.WidthProperty.SetDefault(_buttonsExampleLabel4, new ElementSize(1f, ElementSizeUnit.Percents));
                    Delight.Label.MarginProperty.SetDefault(_buttonsExampleLabel4, new ElementMargin(new ElementSize(10f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels)));
                }
                return _buttonsExampleLabel4;
            }
        }

        private static Template _buttonsExampleComboBoxListItem2;
        public static Template ButtonsExampleComboBoxListItem2
        {
            get
            {
#if UNITY_EDITOR
                if (_buttonsExampleComboBoxListItem2 == null || _buttonsExampleComboBoxListItem2.CurrentVersion != Template.Version)
#else
                if (_buttonsExampleComboBoxListItem2 == null)
#endif
                {
                    _buttonsExampleComboBoxListItem2 = new Template(ComboBoxListItemTemplates.ComboBoxListItem);
#if UNITY_EDITOR
                    _buttonsExampleComboBoxListItem2.Name = "ButtonsExampleComboBoxListItem2";
                    _buttonsExampleComboBoxListItem2.LineNumber = 37;
                    _buttonsExampleComboBoxListItem2.LinePosition = 8;
#endif
                }
                return _buttonsExampleComboBoxListItem2;
            }
        }

        private static Template _buttonsExampleLabel5;
        public static Template ButtonsExampleLabel5
        {
            get
            {
#if UNITY_EDITOR
                if (_buttonsExampleLabel5 == null || _buttonsExampleLabel5.CurrentVersion != Template.Version)
#else
                if (_buttonsExampleLabel5 == null)
#endif
                {
                    _buttonsExampleLabel5 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _buttonsExampleLabel5.Name = "ButtonsExampleLabel5";
                    _buttonsExampleLabel5.LineNumber = 38;
                    _buttonsExampleLabel5.LinePosition = 10;
#endif
                    Delight.Label.TextProperty.SetDefault(_buttonsExampleLabel5, "Option 2");
                    Delight.Label.WidthProperty.SetDefault(_buttonsExampleLabel5, new ElementSize(1f, ElementSizeUnit.Percents));
                    Delight.Label.MarginProperty.SetDefault(_buttonsExampleLabel5, new ElementMargin(new ElementSize(10f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels)));
                }
                return _buttonsExampleLabel5;
            }
        }

        private static Template _buttonsExampleComboBoxListItem3;
        public static Template ButtonsExampleComboBoxListItem3
        {
            get
            {
#if UNITY_EDITOR
                if (_buttonsExampleComboBoxListItem3 == null || _buttonsExampleComboBoxListItem3.CurrentVersion != Template.Version)
#else
                if (_buttonsExampleComboBoxListItem3 == null)
#endif
                {
                    _buttonsExampleComboBoxListItem3 = new Template(ComboBoxListItemTemplates.ComboBoxListItem);
#if UNITY_EDITOR
                    _buttonsExampleComboBoxListItem3.Name = "ButtonsExampleComboBoxListItem3";
                    _buttonsExampleComboBoxListItem3.LineNumber = 40;
                    _buttonsExampleComboBoxListItem3.LinePosition = 8;
#endif
                }
                return _buttonsExampleComboBoxListItem3;
            }
        }

        private static Template _buttonsExampleImage2;
        public static Template ButtonsExampleImage2
        {
            get
            {
#if UNITY_EDITOR
                if (_buttonsExampleImage2 == null || _buttonsExampleImage2.CurrentVersion != Template.Version)
#else
                if (_buttonsExampleImage2 == null)
#endif
                {
                    _buttonsExampleImage2 = new Template(ImageTemplates.Image);
#if UNITY_EDITOR
                    _buttonsExampleImage2.Name = "ButtonsExampleImage2";
                    _buttonsExampleImage2.LineNumber = 41;
                    _buttonsExampleImage2.LinePosition = 10;
#endif
                    Delight.Image.SpriteProperty.SetDefault(_buttonsExampleImage2, Assets.Sprites["RainbowSquare"]);
                    Delight.Image.AlignmentProperty.SetDefault(_buttonsExampleImage2, Delight.ElementAlignment.Left);
                    Delight.Image.OffsetProperty.SetDefault(_buttonsExampleImage2, new ElementMargin(new ElementSize(5f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels)));
                }
                return _buttonsExampleImage2;
            }
        }

        private static Template _buttonsExampleLabel6;
        public static Template ButtonsExampleLabel6
        {
            get
            {
#if UNITY_EDITOR
                if (_buttonsExampleLabel6 == null || _buttonsExampleLabel6.CurrentVersion != Template.Version)
#else
                if (_buttonsExampleLabel6 == null)
#endif
                {
                    _buttonsExampleLabel6 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _buttonsExampleLabel6.Name = "ButtonsExampleLabel6";
                    _buttonsExampleLabel6.LineNumber = 42;
                    _buttonsExampleLabel6.LinePosition = 10;
#endif
                    Delight.Label.TextProperty.SetDefault(_buttonsExampleLabel6, "Option 3");
                    Delight.Label.WidthProperty.SetDefault(_buttonsExampleLabel6, new ElementSize(1f, ElementSizeUnit.Percents));
                    Delight.Label.MarginProperty.SetDefault(_buttonsExampleLabel6, new ElementMargin(new ElementSize(30f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels)));
                }
                return _buttonsExampleLabel6;
            }
        }

        #endregion
    }

    #endregion
}
