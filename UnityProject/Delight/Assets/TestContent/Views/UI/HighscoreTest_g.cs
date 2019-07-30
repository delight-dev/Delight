// Internal view logic generated from "HighscoreTest.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class HighscoreTest : LayoutRoot
    {
        #region Constructors

        public HighscoreTest(View parent, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :
            base(parent, layoutParent, id, template ?? HighscoreTestTemplates.Default, initializer)
        {
            // constructing Group (Group1)
            Group1 = new Group(this, this, "Group1", Group1Template);
            Group2 = new Group(this, Group1.Content, "Group2", Group2Template);
            Button1 = new Button(this, Group2.Content, "Button1", Button1Template);
            Button1.Click.RegisterHandler(this, "LoadHighscores");
            Button2 = new Button(this, Group2.Content, "Button2", Button2Template);
            Button2.Click.RegisterHandler(this, "SaveHighscores");
            Button3 = new Button(this, Group2.Content, "Button3", Button3Template);
            Button3.Click.RegisterHandler(this, "Clear");
            InputField1 = new InputField(this, Group2.Content, "InputField1", InputField1Template);

            // binding <InputField Text="{PlayerId}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "PlayerId" }, new List<Func<BindableObject>> { () => this }) }, new BindingPath(new List<string> { "InputField1", "Text" }, new List<Func<BindableObject>> { () => this, () => InputField1 }), () => InputField1.Text = PlayerId, () => PlayerId = InputField1.Text, true));
            InputField2 = new InputField(this, Group2.Content, "InputField2", InputField2Template);

            // binding <InputField Text="{Score}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "Score" }, new List<Func<BindableObject>> { () => this }) }, new BindingPath(new List<string> { "InputField2", "Text" }, new List<Func<BindableObject>> { () => this, () => InputField2 }), () => InputField2.Text = Score, () => Score = InputField2.Text, true));
            Button4 = new Button(this, Group2.Content, "Button4", Button4Template);
            Button4.Click.RegisterHandler(this, "Add");
            Button5 = new Button(this, Group2.Content, "Button5", Button5Template);
            Button5.Click.RegisterHandler(this, "Remove");
            HighscoreList = new List(this, Group1.Content, "HighscoreList", HighscoreListTemplate);

            // binding <List Items="{highscore in @Highscores}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> {  }, new List<Func<BindableObject>> {  }) }, new BindingPath(new List<string> { "HighscoreList", "Items" }, new List<Func<BindableObject>> { () => this, () => HighscoreList }), () => HighscoreList.Items = Models.Highscores, () => { }, false));

            // binding <List SelectedItem="{SelectedHighscore}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "SelectedHighscore" }, new List<Func<BindableObject>> { () => this }) }, new BindingPath(new List<string> { "HighscoreList", "SelectedItem" }, new List<Func<BindableObject>> { () => this, () => HighscoreList }), () => HighscoreList.SelectedItem = SelectedHighscore, () => SelectedHighscore = HighscoreList.SelectedItem as Delight.Highscore, true));

            // templates for HighscoreList
            HighscoreList.ContentTemplates.Add(new ContentTemplate(tiHighscore => 
            {
                var listItem1 = new ListItem(this, HighscoreList.Content, "ListItem1", ListItem1Template);
                var label1 = new Label(this, listItem1.Content, "Label1", Label1Template);

                // binding <Label Text="{highscore.Player.Name}">
                listItem1.Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "Item", "Player", "Name" }, new List<Func<BindableObject>> { () => tiHighscore, () => (tiHighscore.Item as Delight.Highscore), () => (tiHighscore.Item as Delight.Highscore).Player }) }, new BindingPath(new List<string> { "Text" }, new List<Func<BindableObject>> { () => label1 }), () => label1.Text = (tiHighscore.Item as Delight.Highscore).Player.Name, () => { }, false));
                var label2 = new Label(this, listItem1.Content, "Label2", Label2Template);

                // binding <Label Text="{highscore.ScoreText}">
                listItem1.Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "Item", "ScoreText" }, new List<Func<BindableObject>> { () => tiHighscore, () => (tiHighscore.Item as Delight.Highscore) }) }, new BindingPath(new List<string> { "Text" }, new List<Func<BindableObject>> { () => label2 }), () => label2.Text = (tiHighscore.Item as Delight.Highscore).ScoreText, () => { }, false));
                listItem1.IsDynamic = true;
                listItem1.SetContentTemplateData(tiHighscore);
                return listItem1;
            }, typeof(ListItem), "ListItem1"));
            this.AfterInitializeInternal();
        }

        public HighscoreTest() : this(null)
        {
        }

        static HighscoreTest()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(HighscoreTestTemplates.Default, dependencyProperties);

            dependencyProperties.Add(SelectedHighscoreProperty);
            dependencyProperties.Add(ScoreProperty);
            dependencyProperties.Add(PlayerIdProperty);
            dependencyProperties.Add(Group1Property);
            dependencyProperties.Add(Group1TemplateProperty);
            dependencyProperties.Add(Group2Property);
            dependencyProperties.Add(Group2TemplateProperty);
            dependencyProperties.Add(Button1Property);
            dependencyProperties.Add(Button1TemplateProperty);
            dependencyProperties.Add(Button2Property);
            dependencyProperties.Add(Button2TemplateProperty);
            dependencyProperties.Add(Button3Property);
            dependencyProperties.Add(Button3TemplateProperty);
            dependencyProperties.Add(InputField1Property);
            dependencyProperties.Add(InputField1TemplateProperty);
            dependencyProperties.Add(InputField2Property);
            dependencyProperties.Add(InputField2TemplateProperty);
            dependencyProperties.Add(Button4Property);
            dependencyProperties.Add(Button4TemplateProperty);
            dependencyProperties.Add(Button5Property);
            dependencyProperties.Add(Button5TemplateProperty);
            dependencyProperties.Add(HighscoreListProperty);
            dependencyProperties.Add(HighscoreListTemplateProperty);
            dependencyProperties.Add(ListItem1Property);
            dependencyProperties.Add(ListItem1TemplateProperty);
            dependencyProperties.Add(Label1Property);
            dependencyProperties.Add(Label1TemplateProperty);
            dependencyProperties.Add(Label2Property);
            dependencyProperties.Add(Label2TemplateProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<Delight.Highscore> SelectedHighscoreProperty = new DependencyProperty<Delight.Highscore>("SelectedHighscore");
        public Delight.Highscore SelectedHighscore
        {
            get { return SelectedHighscoreProperty.GetValue(this); }
            set { SelectedHighscoreProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.String> ScoreProperty = new DependencyProperty<System.String>("Score");
        public System.String Score
        {
            get { return ScoreProperty.GetValue(this); }
            set { ScoreProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.String> PlayerIdProperty = new DependencyProperty<System.String>("PlayerId");
        public System.String PlayerId
        {
            get { return PlayerIdProperty.GetValue(this); }
            set { PlayerIdProperty.SetValue(this, value); }
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

        public readonly static DependencyProperty<InputField> InputField1Property = new DependencyProperty<InputField>("InputField1");
        public InputField InputField1
        {
            get { return InputField1Property.GetValue(this); }
            set { InputField1Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> InputField1TemplateProperty = new DependencyProperty<Template>("InputField1Template");
        public Template InputField1Template
        {
            get { return InputField1TemplateProperty.GetValue(this); }
            set { InputField1TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<InputField> InputField2Property = new DependencyProperty<InputField>("InputField2");
        public InputField InputField2
        {
            get { return InputField2Property.GetValue(this); }
            set { InputField2Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> InputField2TemplateProperty = new DependencyProperty<Template>("InputField2Template");
        public Template InputField2Template
        {
            get { return InputField2TemplateProperty.GetValue(this); }
            set { InputField2TemplateProperty.SetValue(this, value); }
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

        public readonly static DependencyProperty<List> HighscoreListProperty = new DependencyProperty<List>("HighscoreList");
        public List HighscoreList
        {
            get { return HighscoreListProperty.GetValue(this); }
            set { HighscoreListProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> HighscoreListTemplateProperty = new DependencyProperty<Template>("HighscoreListTemplate");
        public Template HighscoreListTemplate
        {
            get { return HighscoreListTemplateProperty.GetValue(this); }
            set { HighscoreListTemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ListItem> ListItem1Property = new DependencyProperty<ListItem>("ListItem1");
        public ListItem ListItem1
        {
            get { return ListItem1Property.GetValue(this); }
            set { ListItem1Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> ListItem1TemplateProperty = new DependencyProperty<Template>("ListItem1Template");
        public Template ListItem1Template
        {
            get { return ListItem1TemplateProperty.GetValue(this); }
            set { ListItem1TemplateProperty.SetValue(this, value); }
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

    public static class HighscoreTestTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return HighscoreTest;
            }
        }

        private static Template _highscoreTest;
        public static Template HighscoreTest
        {
            get
            {
#if UNITY_EDITOR
                if (_highscoreTest == null || _highscoreTest.CurrentVersion != Template.Version)
#else
                if (_highscoreTest == null)
#endif
                {
                    _highscoreTest = new Template(LayoutRootTemplates.LayoutRoot);
#if UNITY_EDITOR
                    _highscoreTest.Name = "HighscoreTest";
#endif
                    Delight.HighscoreTest.Group1TemplateProperty.SetDefault(_highscoreTest, HighscoreTestGroup1);
                    Delight.HighscoreTest.Group2TemplateProperty.SetDefault(_highscoreTest, HighscoreTestGroup2);
                    Delight.HighscoreTest.Button1TemplateProperty.SetDefault(_highscoreTest, HighscoreTestButton1);
                    Delight.HighscoreTest.Button2TemplateProperty.SetDefault(_highscoreTest, HighscoreTestButton2);
                    Delight.HighscoreTest.Button3TemplateProperty.SetDefault(_highscoreTest, HighscoreTestButton3);
                    Delight.HighscoreTest.InputField1TemplateProperty.SetDefault(_highscoreTest, HighscoreTestInputField1);
                    Delight.HighscoreTest.InputField2TemplateProperty.SetDefault(_highscoreTest, HighscoreTestInputField2);
                    Delight.HighscoreTest.Button4TemplateProperty.SetDefault(_highscoreTest, HighscoreTestButton4);
                    Delight.HighscoreTest.Button5TemplateProperty.SetDefault(_highscoreTest, HighscoreTestButton5);
                    Delight.HighscoreTest.HighscoreListTemplateProperty.SetDefault(_highscoreTest, HighscoreTestHighscoreList);
                    Delight.HighscoreTest.ListItem1TemplateProperty.SetDefault(_highscoreTest, HighscoreTestListItem1);
                    Delight.HighscoreTest.Label1TemplateProperty.SetDefault(_highscoreTest, HighscoreTestLabel1);
                    Delight.HighscoreTest.Label2TemplateProperty.SetDefault(_highscoreTest, HighscoreTestLabel2);
                }
                return _highscoreTest;
            }
        }

        private static Template _highscoreTestGroup1;
        public static Template HighscoreTestGroup1
        {
            get
            {
#if UNITY_EDITOR
                if (_highscoreTestGroup1 == null || _highscoreTestGroup1.CurrentVersion != Template.Version)
#else
                if (_highscoreTestGroup1 == null)
#endif
                {
                    _highscoreTestGroup1 = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _highscoreTestGroup1.Name = "HighscoreTestGroup1";
#endif
                    Delight.Group.OrientationProperty.SetDefault(_highscoreTestGroup1, Delight.ElementOrientation.Horizontal);
                    Delight.Group.SpacingProperty.SetDefault(_highscoreTestGroup1, new ElementSize(10f, ElementSizeUnit.Pixels));
                }
                return _highscoreTestGroup1;
            }
        }

        private static Template _highscoreTestGroup2;
        public static Template HighscoreTestGroup2
        {
            get
            {
#if UNITY_EDITOR
                if (_highscoreTestGroup2 == null || _highscoreTestGroup2.CurrentVersion != Template.Version)
#else
                if (_highscoreTestGroup2 == null)
#endif
                {
                    _highscoreTestGroup2 = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _highscoreTestGroup2.Name = "HighscoreTestGroup2";
#endif
                    Delight.Group.SpacingProperty.SetDefault(_highscoreTestGroup2, new ElementSize(10f, ElementSizeUnit.Pixels));
                    Delight.Group.WidthProperty.SetDefault(_highscoreTestGroup2, new ElementSize(100f, ElementSizeUnit.Pixels));
                }
                return _highscoreTestGroup2;
            }
        }

        private static Template _highscoreTestButton1;
        public static Template HighscoreTestButton1
        {
            get
            {
#if UNITY_EDITOR
                if (_highscoreTestButton1 == null || _highscoreTestButton1.CurrentVersion != Template.Version)
#else
                if (_highscoreTestButton1 == null)
#endif
                {
                    _highscoreTestButton1 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _highscoreTestButton1.Name = "HighscoreTestButton1";
#endif
                    Delight.Button.WidthProperty.SetDefault(_highscoreTestButton1, new ElementSize(120f, ElementSizeUnit.Pixels));
                    Delight.Button.LabelTemplateProperty.SetDefault(_highscoreTestButton1, HighscoreTestButton1Label);
                }
                return _highscoreTestButton1;
            }
        }

        private static Template _highscoreTestButton1Label;
        public static Template HighscoreTestButton1Label
        {
            get
            {
#if UNITY_EDITOR
                if (_highscoreTestButton1Label == null || _highscoreTestButton1Label.CurrentVersion != Template.Version)
#else
                if (_highscoreTestButton1Label == null)
#endif
                {
                    _highscoreTestButton1Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _highscoreTestButton1Label.Name = "HighscoreTestButton1Label";
#endif
                    Delight.Label.TextProperty.SetDefault(_highscoreTestButton1Label, "Load");
                }
                return _highscoreTestButton1Label;
            }
        }

        private static Template _highscoreTestButton2;
        public static Template HighscoreTestButton2
        {
            get
            {
#if UNITY_EDITOR
                if (_highscoreTestButton2 == null || _highscoreTestButton2.CurrentVersion != Template.Version)
#else
                if (_highscoreTestButton2 == null)
#endif
                {
                    _highscoreTestButton2 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _highscoreTestButton2.Name = "HighscoreTestButton2";
#endif
                    Delight.Button.WidthProperty.SetDefault(_highscoreTestButton2, new ElementSize(120f, ElementSizeUnit.Pixels));
                    Delight.Button.LabelTemplateProperty.SetDefault(_highscoreTestButton2, HighscoreTestButton2Label);
                }
                return _highscoreTestButton2;
            }
        }

        private static Template _highscoreTestButton2Label;
        public static Template HighscoreTestButton2Label
        {
            get
            {
#if UNITY_EDITOR
                if (_highscoreTestButton2Label == null || _highscoreTestButton2Label.CurrentVersion != Template.Version)
#else
                if (_highscoreTestButton2Label == null)
#endif
                {
                    _highscoreTestButton2Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _highscoreTestButton2Label.Name = "HighscoreTestButton2Label";
#endif
                    Delight.Label.TextProperty.SetDefault(_highscoreTestButton2Label, "Save");
                }
                return _highscoreTestButton2Label;
            }
        }

        private static Template _highscoreTestButton3;
        public static Template HighscoreTestButton3
        {
            get
            {
#if UNITY_EDITOR
                if (_highscoreTestButton3 == null || _highscoreTestButton3.CurrentVersion != Template.Version)
#else
                if (_highscoreTestButton3 == null)
#endif
                {
                    _highscoreTestButton3 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _highscoreTestButton3.Name = "HighscoreTestButton3";
#endif
                    Delight.Button.WidthProperty.SetDefault(_highscoreTestButton3, new ElementSize(120f, ElementSizeUnit.Pixels));
                    Delight.Button.LabelTemplateProperty.SetDefault(_highscoreTestButton3, HighscoreTestButton3Label);
                }
                return _highscoreTestButton3;
            }
        }

        private static Template _highscoreTestButton3Label;
        public static Template HighscoreTestButton3Label
        {
            get
            {
#if UNITY_EDITOR
                if (_highscoreTestButton3Label == null || _highscoreTestButton3Label.CurrentVersion != Template.Version)
#else
                if (_highscoreTestButton3Label == null)
#endif
                {
                    _highscoreTestButton3Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _highscoreTestButton3Label.Name = "HighscoreTestButton3Label";
#endif
                    Delight.Label.TextProperty.SetDefault(_highscoreTestButton3Label, "Clear");
                }
                return _highscoreTestButton3Label;
            }
        }

        private static Template _highscoreTestInputField1;
        public static Template HighscoreTestInputField1
        {
            get
            {
#if UNITY_EDITOR
                if (_highscoreTestInputField1 == null || _highscoreTestInputField1.CurrentVersion != Template.Version)
#else
                if (_highscoreTestInputField1 == null)
#endif
                {
                    _highscoreTestInputField1 = new Template(InputFieldTemplates.InputField);
#if UNITY_EDITOR
                    _highscoreTestInputField1.Name = "HighscoreTestInputField1";
#endif
                    Delight.InputField.WidthProperty.SetDefault(_highscoreTestInputField1, new ElementSize(200f, ElementSizeUnit.Pixels));
                    Delight.InputField.TextProperty.SetHasBinding(_highscoreTestInputField1);
                    Delight.InputField.InputFieldPlaceholderTemplateProperty.SetDefault(_highscoreTestInputField1, HighscoreTestInputField1InputFieldPlaceholder);
                    Delight.InputField.TextAreaTemplateProperty.SetDefault(_highscoreTestInputField1, HighscoreTestInputField1TextArea);
                    Delight.InputField.InputTextTemplateProperty.SetDefault(_highscoreTestInputField1, HighscoreTestInputField1InputText);
                }
                return _highscoreTestInputField1;
            }
        }

        private static Template _highscoreTestInputField1InputFieldPlaceholder;
        public static Template HighscoreTestInputField1InputFieldPlaceholder
        {
            get
            {
#if UNITY_EDITOR
                if (_highscoreTestInputField1InputFieldPlaceholder == null || _highscoreTestInputField1InputFieldPlaceholder.CurrentVersion != Template.Version)
#else
                if (_highscoreTestInputField1InputFieldPlaceholder == null)
#endif
                {
                    _highscoreTestInputField1InputFieldPlaceholder = new Template(InputFieldTemplates.InputFieldInputFieldPlaceholder);
#if UNITY_EDITOR
                    _highscoreTestInputField1InputFieldPlaceholder.Name = "HighscoreTestInputField1InputFieldPlaceholder";
#endif
                }
                return _highscoreTestInputField1InputFieldPlaceholder;
            }
        }

        private static Template _highscoreTestInputField1TextArea;
        public static Template HighscoreTestInputField1TextArea
        {
            get
            {
#if UNITY_EDITOR
                if (_highscoreTestInputField1TextArea == null || _highscoreTestInputField1TextArea.CurrentVersion != Template.Version)
#else
                if (_highscoreTestInputField1TextArea == null)
#endif
                {
                    _highscoreTestInputField1TextArea = new Template(InputFieldTemplates.InputFieldTextArea);
#if UNITY_EDITOR
                    _highscoreTestInputField1TextArea.Name = "HighscoreTestInputField1TextArea";
#endif
                }
                return _highscoreTestInputField1TextArea;
            }
        }

        private static Template _highscoreTestInputField1InputText;
        public static Template HighscoreTestInputField1InputText
        {
            get
            {
#if UNITY_EDITOR
                if (_highscoreTestInputField1InputText == null || _highscoreTestInputField1InputText.CurrentVersion != Template.Version)
#else
                if (_highscoreTestInputField1InputText == null)
#endif
                {
                    _highscoreTestInputField1InputText = new Template(InputFieldTemplates.InputFieldInputText);
#if UNITY_EDITOR
                    _highscoreTestInputField1InputText.Name = "HighscoreTestInputField1InputText";
#endif
                }
                return _highscoreTestInputField1InputText;
            }
        }

        private static Template _highscoreTestInputField2;
        public static Template HighscoreTestInputField2
        {
            get
            {
#if UNITY_EDITOR
                if (_highscoreTestInputField2 == null || _highscoreTestInputField2.CurrentVersion != Template.Version)
#else
                if (_highscoreTestInputField2 == null)
#endif
                {
                    _highscoreTestInputField2 = new Template(InputFieldTemplates.InputField);
#if UNITY_EDITOR
                    _highscoreTestInputField2.Name = "HighscoreTestInputField2";
#endif
                    Delight.InputField.WidthProperty.SetDefault(_highscoreTestInputField2, new ElementSize(200f, ElementSizeUnit.Pixels));
                    Delight.InputField.TextProperty.SetHasBinding(_highscoreTestInputField2);
                    Delight.InputField.InputFieldPlaceholderTemplateProperty.SetDefault(_highscoreTestInputField2, HighscoreTestInputField2InputFieldPlaceholder);
                    Delight.InputField.TextAreaTemplateProperty.SetDefault(_highscoreTestInputField2, HighscoreTestInputField2TextArea);
                    Delight.InputField.InputTextTemplateProperty.SetDefault(_highscoreTestInputField2, HighscoreTestInputField2InputText);
                }
                return _highscoreTestInputField2;
            }
        }

        private static Template _highscoreTestInputField2InputFieldPlaceholder;
        public static Template HighscoreTestInputField2InputFieldPlaceholder
        {
            get
            {
#if UNITY_EDITOR
                if (_highscoreTestInputField2InputFieldPlaceholder == null || _highscoreTestInputField2InputFieldPlaceholder.CurrentVersion != Template.Version)
#else
                if (_highscoreTestInputField2InputFieldPlaceholder == null)
#endif
                {
                    _highscoreTestInputField2InputFieldPlaceholder = new Template(InputFieldTemplates.InputFieldInputFieldPlaceholder);
#if UNITY_EDITOR
                    _highscoreTestInputField2InputFieldPlaceholder.Name = "HighscoreTestInputField2InputFieldPlaceholder";
#endif
                }
                return _highscoreTestInputField2InputFieldPlaceholder;
            }
        }

        private static Template _highscoreTestInputField2TextArea;
        public static Template HighscoreTestInputField2TextArea
        {
            get
            {
#if UNITY_EDITOR
                if (_highscoreTestInputField2TextArea == null || _highscoreTestInputField2TextArea.CurrentVersion != Template.Version)
#else
                if (_highscoreTestInputField2TextArea == null)
#endif
                {
                    _highscoreTestInputField2TextArea = new Template(InputFieldTemplates.InputFieldTextArea);
#if UNITY_EDITOR
                    _highscoreTestInputField2TextArea.Name = "HighscoreTestInputField2TextArea";
#endif
                }
                return _highscoreTestInputField2TextArea;
            }
        }

        private static Template _highscoreTestInputField2InputText;
        public static Template HighscoreTestInputField2InputText
        {
            get
            {
#if UNITY_EDITOR
                if (_highscoreTestInputField2InputText == null || _highscoreTestInputField2InputText.CurrentVersion != Template.Version)
#else
                if (_highscoreTestInputField2InputText == null)
#endif
                {
                    _highscoreTestInputField2InputText = new Template(InputFieldTemplates.InputFieldInputText);
#if UNITY_EDITOR
                    _highscoreTestInputField2InputText.Name = "HighscoreTestInputField2InputText";
#endif
                }
                return _highscoreTestInputField2InputText;
            }
        }

        private static Template _highscoreTestButton4;
        public static Template HighscoreTestButton4
        {
            get
            {
#if UNITY_EDITOR
                if (_highscoreTestButton4 == null || _highscoreTestButton4.CurrentVersion != Template.Version)
#else
                if (_highscoreTestButton4 == null)
#endif
                {
                    _highscoreTestButton4 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _highscoreTestButton4.Name = "HighscoreTestButton4";
#endif
                    Delight.Button.WidthProperty.SetDefault(_highscoreTestButton4, new ElementSize(120f, ElementSizeUnit.Pixels));
                    Delight.Button.LabelTemplateProperty.SetDefault(_highscoreTestButton4, HighscoreTestButton4Label);
                }
                return _highscoreTestButton4;
            }
        }

        private static Template _highscoreTestButton4Label;
        public static Template HighscoreTestButton4Label
        {
            get
            {
#if UNITY_EDITOR
                if (_highscoreTestButton4Label == null || _highscoreTestButton4Label.CurrentVersion != Template.Version)
#else
                if (_highscoreTestButton4Label == null)
#endif
                {
                    _highscoreTestButton4Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _highscoreTestButton4Label.Name = "HighscoreTestButton4Label";
#endif
                    Delight.Label.TextProperty.SetDefault(_highscoreTestButton4Label, "Add");
                }
                return _highscoreTestButton4Label;
            }
        }

        private static Template _highscoreTestButton5;
        public static Template HighscoreTestButton5
        {
            get
            {
#if UNITY_EDITOR
                if (_highscoreTestButton5 == null || _highscoreTestButton5.CurrentVersion != Template.Version)
#else
                if (_highscoreTestButton5 == null)
#endif
                {
                    _highscoreTestButton5 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _highscoreTestButton5.Name = "HighscoreTestButton5";
#endif
                    Delight.Button.WidthProperty.SetDefault(_highscoreTestButton5, new ElementSize(120f, ElementSizeUnit.Pixels));
                    Delight.Button.LabelTemplateProperty.SetDefault(_highscoreTestButton5, HighscoreTestButton5Label);
                }
                return _highscoreTestButton5;
            }
        }

        private static Template _highscoreTestButton5Label;
        public static Template HighscoreTestButton5Label
        {
            get
            {
#if UNITY_EDITOR
                if (_highscoreTestButton5Label == null || _highscoreTestButton5Label.CurrentVersion != Template.Version)
#else
                if (_highscoreTestButton5Label == null)
#endif
                {
                    _highscoreTestButton5Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _highscoreTestButton5Label.Name = "HighscoreTestButton5Label";
#endif
                    Delight.Label.TextProperty.SetDefault(_highscoreTestButton5Label, "Remove");
                }
                return _highscoreTestButton5Label;
            }
        }

        private static Template _highscoreTestHighscoreList;
        public static Template HighscoreTestHighscoreList
        {
            get
            {
#if UNITY_EDITOR
                if (_highscoreTestHighscoreList == null || _highscoreTestHighscoreList.CurrentVersion != Template.Version)
#else
                if (_highscoreTestHighscoreList == null)
#endif
                {
                    _highscoreTestHighscoreList = new Template(ListTemplates.List);
#if UNITY_EDITOR
                    _highscoreTestHighscoreList.Name = "HighscoreTestHighscoreList";
#endif
                    Delight.List.WidthProperty.SetDefault(_highscoreTestHighscoreList, new ElementSize(300f, ElementSizeUnit.Pixels));
                    Delight.List.BackgroundColorProperty.SetDefault(_highscoreTestHighscoreList, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.List.IsScrollableProperty.SetDefault(_highscoreTestHighscoreList, true);
                    Delight.List.ItemsProperty.SetHasBinding(_highscoreTestHighscoreList);
                    Delight.List.SelectedItemProperty.SetHasBinding(_highscoreTestHighscoreList);
                    Delight.List.ScrollableRegionTemplateProperty.SetDefault(_highscoreTestHighscoreList, HighscoreTestHighscoreListScrollableRegion);
                }
                return _highscoreTestHighscoreList;
            }
        }

        private static Template _highscoreTestHighscoreListScrollableRegion;
        public static Template HighscoreTestHighscoreListScrollableRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_highscoreTestHighscoreListScrollableRegion == null || _highscoreTestHighscoreListScrollableRegion.CurrentVersion != Template.Version)
#else
                if (_highscoreTestHighscoreListScrollableRegion == null)
#endif
                {
                    _highscoreTestHighscoreListScrollableRegion = new Template(ListTemplates.ListScrollableRegion);
#if UNITY_EDITOR
                    _highscoreTestHighscoreListScrollableRegion.Name = "HighscoreTestHighscoreListScrollableRegion";
#endif
                    Delight.ScrollableRegion.ContentRegionTemplateProperty.SetDefault(_highscoreTestHighscoreListScrollableRegion, HighscoreTestHighscoreListScrollableRegionContentRegion);
                    Delight.ScrollableRegion.HorizontalScrollbarTemplateProperty.SetDefault(_highscoreTestHighscoreListScrollableRegion, HighscoreTestHighscoreListScrollableRegionHorizontalScrollbar);
                    Delight.ScrollableRegion.VerticalScrollbarTemplateProperty.SetDefault(_highscoreTestHighscoreListScrollableRegion, HighscoreTestHighscoreListScrollableRegionVerticalScrollbar);
                }
                return _highscoreTestHighscoreListScrollableRegion;
            }
        }

        private static Template _highscoreTestHighscoreListScrollableRegionContentRegion;
        public static Template HighscoreTestHighscoreListScrollableRegionContentRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_highscoreTestHighscoreListScrollableRegionContentRegion == null || _highscoreTestHighscoreListScrollableRegionContentRegion.CurrentVersion != Template.Version)
#else
                if (_highscoreTestHighscoreListScrollableRegionContentRegion == null)
#endif
                {
                    _highscoreTestHighscoreListScrollableRegionContentRegion = new Template(ListTemplates.ListScrollableRegionContentRegion);
#if UNITY_EDITOR
                    _highscoreTestHighscoreListScrollableRegionContentRegion.Name = "HighscoreTestHighscoreListScrollableRegionContentRegion";
#endif
                }
                return _highscoreTestHighscoreListScrollableRegionContentRegion;
            }
        }

        private static Template _highscoreTestHighscoreListScrollableRegionHorizontalScrollbar;
        public static Template HighscoreTestHighscoreListScrollableRegionHorizontalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_highscoreTestHighscoreListScrollableRegionHorizontalScrollbar == null || _highscoreTestHighscoreListScrollableRegionHorizontalScrollbar.CurrentVersion != Template.Version)
#else
                if (_highscoreTestHighscoreListScrollableRegionHorizontalScrollbar == null)
#endif
                {
                    _highscoreTestHighscoreListScrollableRegionHorizontalScrollbar = new Template(ListTemplates.ListScrollableRegionHorizontalScrollbar);
#if UNITY_EDITOR
                    _highscoreTestHighscoreListScrollableRegionHorizontalScrollbar.Name = "HighscoreTestHighscoreListScrollableRegionHorizontalScrollbar";
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_highscoreTestHighscoreListScrollableRegionHorizontalScrollbar, HighscoreTestHighscoreListScrollableRegionHorizontalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_highscoreTestHighscoreListScrollableRegionHorizontalScrollbar, HighscoreTestHighscoreListScrollableRegionHorizontalScrollbarHandle);
                }
                return _highscoreTestHighscoreListScrollableRegionHorizontalScrollbar;
            }
        }

        private static Template _highscoreTestHighscoreListScrollableRegionHorizontalScrollbarBar;
        public static Template HighscoreTestHighscoreListScrollableRegionHorizontalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_highscoreTestHighscoreListScrollableRegionHorizontalScrollbarBar == null || _highscoreTestHighscoreListScrollableRegionHorizontalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_highscoreTestHighscoreListScrollableRegionHorizontalScrollbarBar == null)
#endif
                {
                    _highscoreTestHighscoreListScrollableRegionHorizontalScrollbarBar = new Template(ListTemplates.ListScrollableRegionHorizontalScrollbarBar);
#if UNITY_EDITOR
                    _highscoreTestHighscoreListScrollableRegionHorizontalScrollbarBar.Name = "HighscoreTestHighscoreListScrollableRegionHorizontalScrollbarBar";
#endif
                }
                return _highscoreTestHighscoreListScrollableRegionHorizontalScrollbarBar;
            }
        }

        private static Template _highscoreTestHighscoreListScrollableRegionHorizontalScrollbarHandle;
        public static Template HighscoreTestHighscoreListScrollableRegionHorizontalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_highscoreTestHighscoreListScrollableRegionHorizontalScrollbarHandle == null || _highscoreTestHighscoreListScrollableRegionHorizontalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_highscoreTestHighscoreListScrollableRegionHorizontalScrollbarHandle == null)
#endif
                {
                    _highscoreTestHighscoreListScrollableRegionHorizontalScrollbarHandle = new Template(ListTemplates.ListScrollableRegionHorizontalScrollbarHandle);
#if UNITY_EDITOR
                    _highscoreTestHighscoreListScrollableRegionHorizontalScrollbarHandle.Name = "HighscoreTestHighscoreListScrollableRegionHorizontalScrollbarHandle";
#endif
                }
                return _highscoreTestHighscoreListScrollableRegionHorizontalScrollbarHandle;
            }
        }

        private static Template _highscoreTestHighscoreListScrollableRegionVerticalScrollbar;
        public static Template HighscoreTestHighscoreListScrollableRegionVerticalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_highscoreTestHighscoreListScrollableRegionVerticalScrollbar == null || _highscoreTestHighscoreListScrollableRegionVerticalScrollbar.CurrentVersion != Template.Version)
#else
                if (_highscoreTestHighscoreListScrollableRegionVerticalScrollbar == null)
#endif
                {
                    _highscoreTestHighscoreListScrollableRegionVerticalScrollbar = new Template(ListTemplates.ListScrollableRegionVerticalScrollbar);
#if UNITY_EDITOR
                    _highscoreTestHighscoreListScrollableRegionVerticalScrollbar.Name = "HighscoreTestHighscoreListScrollableRegionVerticalScrollbar";
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_highscoreTestHighscoreListScrollableRegionVerticalScrollbar, HighscoreTestHighscoreListScrollableRegionVerticalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_highscoreTestHighscoreListScrollableRegionVerticalScrollbar, HighscoreTestHighscoreListScrollableRegionVerticalScrollbarHandle);
                }
                return _highscoreTestHighscoreListScrollableRegionVerticalScrollbar;
            }
        }

        private static Template _highscoreTestHighscoreListScrollableRegionVerticalScrollbarBar;
        public static Template HighscoreTestHighscoreListScrollableRegionVerticalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_highscoreTestHighscoreListScrollableRegionVerticalScrollbarBar == null || _highscoreTestHighscoreListScrollableRegionVerticalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_highscoreTestHighscoreListScrollableRegionVerticalScrollbarBar == null)
#endif
                {
                    _highscoreTestHighscoreListScrollableRegionVerticalScrollbarBar = new Template(ListTemplates.ListScrollableRegionVerticalScrollbarBar);
#if UNITY_EDITOR
                    _highscoreTestHighscoreListScrollableRegionVerticalScrollbarBar.Name = "HighscoreTestHighscoreListScrollableRegionVerticalScrollbarBar";
#endif
                }
                return _highscoreTestHighscoreListScrollableRegionVerticalScrollbarBar;
            }
        }

        private static Template _highscoreTestHighscoreListScrollableRegionVerticalScrollbarHandle;
        public static Template HighscoreTestHighscoreListScrollableRegionVerticalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_highscoreTestHighscoreListScrollableRegionVerticalScrollbarHandle == null || _highscoreTestHighscoreListScrollableRegionVerticalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_highscoreTestHighscoreListScrollableRegionVerticalScrollbarHandle == null)
#endif
                {
                    _highscoreTestHighscoreListScrollableRegionVerticalScrollbarHandle = new Template(ListTemplates.ListScrollableRegionVerticalScrollbarHandle);
#if UNITY_EDITOR
                    _highscoreTestHighscoreListScrollableRegionVerticalScrollbarHandle.Name = "HighscoreTestHighscoreListScrollableRegionVerticalScrollbarHandle";
#endif
                }
                return _highscoreTestHighscoreListScrollableRegionVerticalScrollbarHandle;
            }
        }

        private static Template _highscoreTestListItem1;
        public static Template HighscoreTestListItem1
        {
            get
            {
#if UNITY_EDITOR
                if (_highscoreTestListItem1 == null || _highscoreTestListItem1.CurrentVersion != Template.Version)
#else
                if (_highscoreTestListItem1 == null)
#endif
                {
                    _highscoreTestListItem1 = new Template(ListItemTemplates.ListItem);
#if UNITY_EDITOR
                    _highscoreTestListItem1.Name = "HighscoreTestListItem1";
#endif
                    Delight.ListItem.WidthProperty.SetDefault(_highscoreTestListItem1, new ElementSize(1f, ElementSizeUnit.Percents));
                    Delight.ListItem.BackgroundColorProperty.SetDefault(_highscoreTestListItem1, new UnityEngine.Color(1f, 1f, 1f, 1f));
                }
                return _highscoreTestListItem1;
            }
        }

        private static Template _highscoreTestLabel1;
        public static Template HighscoreTestLabel1
        {
            get
            {
#if UNITY_EDITOR
                if (_highscoreTestLabel1 == null || _highscoreTestLabel1.CurrentVersion != Template.Version)
#else
                if (_highscoreTestLabel1 == null)
#endif
                {
                    _highscoreTestLabel1 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _highscoreTestLabel1.Name = "HighscoreTestLabel1";
#endif
                    Delight.Label.AutoSizeProperty.SetDefault(_highscoreTestLabel1, Delight.AutoSize.Width);
                    Delight.Label.AlignmentProperty.SetDefault(_highscoreTestLabel1, Delight.ElementAlignment.Left);
                    Delight.Label.MarginProperty.SetDefault(_highscoreTestLabel1, new ElementMargin(new ElementSize(10f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels)));
                    Delight.Label.TextProperty.SetHasBinding(_highscoreTestLabel1);
                }
                return _highscoreTestLabel1;
            }
        }

        private static Template _highscoreTestLabel2;
        public static Template HighscoreTestLabel2
        {
            get
            {
#if UNITY_EDITOR
                if (_highscoreTestLabel2 == null || _highscoreTestLabel2.CurrentVersion != Template.Version)
#else
                if (_highscoreTestLabel2 == null)
#endif
                {
                    _highscoreTestLabel2 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _highscoreTestLabel2.Name = "HighscoreTestLabel2";
#endif
                    Delight.Label.AutoSizeProperty.SetDefault(_highscoreTestLabel2, Delight.AutoSize.Width);
                    Delight.Label.AlignmentProperty.SetDefault(_highscoreTestLabel2, Delight.ElementAlignment.Right);
                    Delight.Label.FontStyleProperty.SetDefault(_highscoreTestLabel2, TMPro.FontStyles.Bold);
                    Delight.Label.OffsetProperty.SetDefault(_highscoreTestLabel2, new ElementMargin(new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(25f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels)));
                    Delight.Label.TextProperty.SetHasBinding(_highscoreTestLabel2);
                }
                return _highscoreTestLabel2;
            }
        }

        #endregion
    }

    #endregion
}
