// Internal view logic generated from "ListExample.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class ListExample : LayoutRoot
    {
        #region Constructors

        public ListExample(View parent, View layoutParent = null, string id = null, Template template = null, bool deferInitialization = false) :
            base(parent, layoutParent, id, template ?? ListExampleTemplates.Default, deferInitialization)
        {
            if (deferInitialization)
                return;

            // constructing Group (Group1)
            Group1 = new Group(this, this, "Group1", Group1Template);
            Group2 = new Group(this, Group1.Content, "Group2", Group2Template);
            InputField1 = new InputField(this, Group2.Content, "InputField1", InputField1Template);

            // binding <InputField Text="{ItemIndex}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "ItemIndex" }, new List<Func<BindableObject>> { () => this }) }, new BindingPath(new List<string> { "InputField1", "Text" }, new List<Func<BindableObject>> { () => this, () => InputField1 }), () => InputField1.Text = ItemIndex, () => ItemIndex = InputField1.Text, true));
            Button1 = new Button(this, Group2.Content, "Button1", Button1Template);
            Button1.Click.RegisterHandler(this, "SelectItem");
            Button2 = new Button(this, Group2.Content, "Button2", Button2Template);
            Button2.Click.RegisterHandler(this, "ScrollTo");
            Button3 = new Button(this, Group2.Content, "Button3", Button3Template);
            Button3.Click.RegisterHandler(this, "ScrollToSelected");
            Button4 = new Button(this, Group2.Content, "Button4", Button4Template);
            Button4.Click.RegisterHandler(this, "AddItem");
            Button5 = new Button(this, Group2.Content, "Button5", Button5Template);
            Button5.Click.RegisterHandler(this, "InsertItem");
            Button6 = new Button(this, Group2.Content, "Button6", Button6Template);
            Button6.Click.RegisterHandler(this, "RemoveItem");
            PlayerList = new List(this, Group1.Content, "PlayerList", PlayerListTemplate);
            PlayerList.TemplateSelector.RegisterMethod(this, "MyTemplateSelector");

            // binding <List Items="{player in Players}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "Players" }, new List<Func<BindableObject>> { () => this }) }, new BindingPath(new List<string> { "PlayerList", "Items" }, new List<Func<BindableObject>> { () => this, () => PlayerList }), () => PlayerList.Items = Players, () => { }, false));

            // binding <List SelectedItem="{SelectedPlayer}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "SelectedPlayer" }, new List<Func<BindableObject>> { () => this }) }, new BindingPath(new List<string> { "PlayerList", "SelectedItem" }, new List<Func<BindableObject>> { () => this, () => PlayerList }), () => PlayerList.SelectedItem = SelectedPlayer, () => SelectedPlayer = PlayerList.SelectedItem as Delight.Player, true));

            // templates for PlayerList
            PlayerList.ContentTemplates.Add(new ContentTemplate(tiPlayer => 
            {
                var templateA = new ListItem(this, PlayerList.Content, "TemplateA", TemplateATemplate);
                var image1 = new Image(this, templateA.Content, "Image1", Image1Template);

                // binding <Image Color="{player.Color}">
                templateA.Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "Item", "Color" }, new List<Func<BindableObject>> { () => tiPlayer, () => (tiPlayer.Item as Delight.Player) }) }, new BindingPath(new List<string> { "Color" }, new List<Func<BindableObject>> { () => image1 }), () => image1.Color = (tiPlayer.Item as Delight.Player).Color, () => { }, false));
                var label1 = new Label(this, templateA.Content, "Label1", Label1Template);

                // binding <Label Text="{player.Name}">
                templateA.Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "Item", "Name" }, new List<Func<BindableObject>> { () => tiPlayer, () => (tiPlayer.Item as Delight.Player) }) }, new BindingPath(new List<string> { "Text" }, new List<Func<BindableObject>> { () => label1 }), () => label1.Text = (tiPlayer.Item as Delight.Player).Name, () => { }, false));
                templateA.IsDynamic = true;
                templateA.SetContentTemplateData(tiPlayer);
                return templateA;
            }, typeof(ListItem), "TemplateA"));

            // templates for PlayerList
            PlayerList.ContentTemplates.Add(new ContentTemplate(tiPlayer => 
            {
                var templateB = new ListItem(this, PlayerList.Content, "TemplateB", TemplateBTemplate);
                var image2 = new Image(this, templateB.Content, "Image2", Image2Template);

                // binding <Image Color="{player.Color}">
                templateB.Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "Item", "Color" }, new List<Func<BindableObject>> { () => tiPlayer, () => (tiPlayer.Item as Delight.Player) }) }, new BindingPath(new List<string> { "Color" }, new List<Func<BindableObject>> { () => image2 }), () => image2.Color = (tiPlayer.Item as Delight.Player).Color, () => { }, false));
                var label2 = new Label(this, templateB.Content, "Label2", Label2Template);

                // binding <Label Text="Supreme {player.Name}">
                templateB.Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "Item", "Name" }, new List<Func<BindableObject>> { () => tiPlayer, () => (tiPlayer.Item as Delight.Player) }) }, new BindingPath(new List<string> { "Text" }, new List<Func<BindableObject>> { () => label2 }), () => label2.Text = String.Format("Supreme {0}", (tiPlayer.Item as Delight.Player).Name), () => { }, false));
                templateB.IsDynamic = true;
                templateB.SetContentTemplateData(tiPlayer);
                return templateB;
            }, typeof(ListItem), "TemplateB"));
            this.AfterInitializeInternal();
        }

        public ListExample() : this(null)
        {
        }

        static ListExample()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(ListExampleTemplates.Default, dependencyProperties);

            dependencyProperties.Add(PlayersProperty);
            dependencyProperties.Add(ItemIndexProperty);
            dependencyProperties.Add(SelectedPlayerProperty);
            dependencyProperties.Add(Group1Property);
            dependencyProperties.Add(Group1TemplateProperty);
            dependencyProperties.Add(Group2Property);
            dependencyProperties.Add(Group2TemplateProperty);
            dependencyProperties.Add(InputField1Property);
            dependencyProperties.Add(InputField1TemplateProperty);
            dependencyProperties.Add(Button1Property);
            dependencyProperties.Add(Button1TemplateProperty);
            dependencyProperties.Add(Button2Property);
            dependencyProperties.Add(Button2TemplateProperty);
            dependencyProperties.Add(Button3Property);
            dependencyProperties.Add(Button3TemplateProperty);
            dependencyProperties.Add(Button4Property);
            dependencyProperties.Add(Button4TemplateProperty);
            dependencyProperties.Add(Button5Property);
            dependencyProperties.Add(Button5TemplateProperty);
            dependencyProperties.Add(Button6Property);
            dependencyProperties.Add(Button6TemplateProperty);
            dependencyProperties.Add(PlayerListProperty);
            dependencyProperties.Add(PlayerListTemplateProperty);
            dependencyProperties.Add(TemplateAProperty);
            dependencyProperties.Add(TemplateATemplateProperty);
            dependencyProperties.Add(Image1Property);
            dependencyProperties.Add(Image1TemplateProperty);
            dependencyProperties.Add(Label1Property);
            dependencyProperties.Add(Label1TemplateProperty);
            dependencyProperties.Add(TemplateBProperty);
            dependencyProperties.Add(TemplateBTemplateProperty);
            dependencyProperties.Add(Image2Property);
            dependencyProperties.Add(Image2TemplateProperty);
            dependencyProperties.Add(Label2Property);
            dependencyProperties.Add(Label2TemplateProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<Delight.BindableCollection<Delight.Player>> PlayersProperty = new DependencyProperty<Delight.BindableCollection<Delight.Player>>("Players");
        public Delight.BindableCollection<Delight.Player> Players
        {
            get { return PlayersProperty.GetValue(this); }
            set { PlayersProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.String> ItemIndexProperty = new DependencyProperty<System.String>("ItemIndex");
        public System.String ItemIndex
        {
            get { return ItemIndexProperty.GetValue(this); }
            set { ItemIndexProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Delight.Player> SelectedPlayerProperty = new DependencyProperty<Delight.Player>("SelectedPlayer");
        public Delight.Player SelectedPlayer
        {
            get { return SelectedPlayerProperty.GetValue(this); }
            set { SelectedPlayerProperty.SetValue(this, value); }
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

        public readonly static DependencyProperty<List> PlayerListProperty = new DependencyProperty<List>("PlayerList");
        public List PlayerList
        {
            get { return PlayerListProperty.GetValue(this); }
            set { PlayerListProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> PlayerListTemplateProperty = new DependencyProperty<Template>("PlayerListTemplate");
        public Template PlayerListTemplate
        {
            get { return PlayerListTemplateProperty.GetValue(this); }
            set { PlayerListTemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ListItem> TemplateAProperty = new DependencyProperty<ListItem>("TemplateA");
        public ListItem TemplateA
        {
            get { return TemplateAProperty.GetValue(this); }
            set { TemplateAProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> TemplateATemplateProperty = new DependencyProperty<Template>("TemplateATemplate");
        public Template TemplateATemplate
        {
            get { return TemplateATemplateProperty.GetValue(this); }
            set { TemplateATemplateProperty.SetValue(this, value); }
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

        public readonly static DependencyProperty<ListItem> TemplateBProperty = new DependencyProperty<ListItem>("TemplateB");
        public ListItem TemplateB
        {
            get { return TemplateBProperty.GetValue(this); }
            set { TemplateBProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> TemplateBTemplateProperty = new DependencyProperty<Template>("TemplateBTemplate");
        public Template TemplateBTemplate
        {
            get { return TemplateBTemplateProperty.GetValue(this); }
            set { TemplateBTemplateProperty.SetValue(this, value); }
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

    public static class ListExampleTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return ListExample;
            }
        }

        private static Template _listExample;
        public static Template ListExample
        {
            get
            {
#if UNITY_EDITOR
                if (_listExample == null || _listExample.CurrentVersion != Template.Version)
#else
                if (_listExample == null)
#endif
                {
                    _listExample = new Template(LayoutRootTemplates.LayoutRoot);
#if UNITY_EDITOR
                    _listExample.Name = "ListExample";
#endif
                    Delight.ListExample.Group1TemplateProperty.SetDefault(_listExample, ListExampleGroup1);
                    Delight.ListExample.Group2TemplateProperty.SetDefault(_listExample, ListExampleGroup2);
                    Delight.ListExample.InputField1TemplateProperty.SetDefault(_listExample, ListExampleInputField1);
                    Delight.ListExample.Button1TemplateProperty.SetDefault(_listExample, ListExampleButton1);
                    Delight.ListExample.Button2TemplateProperty.SetDefault(_listExample, ListExampleButton2);
                    Delight.ListExample.Button3TemplateProperty.SetDefault(_listExample, ListExampleButton3);
                    Delight.ListExample.Button4TemplateProperty.SetDefault(_listExample, ListExampleButton4);
                    Delight.ListExample.Button5TemplateProperty.SetDefault(_listExample, ListExampleButton5);
                    Delight.ListExample.Button6TemplateProperty.SetDefault(_listExample, ListExampleButton6);
                    Delight.ListExample.PlayerListTemplateProperty.SetDefault(_listExample, ListExamplePlayerList);
                    Delight.ListExample.TemplateATemplateProperty.SetDefault(_listExample, ListExampleTemplateA);
                    Delight.ListExample.Image1TemplateProperty.SetDefault(_listExample, ListExampleImage1);
                    Delight.ListExample.Label1TemplateProperty.SetDefault(_listExample, ListExampleLabel1);
                    Delight.ListExample.TemplateBTemplateProperty.SetDefault(_listExample, ListExampleTemplateB);
                    Delight.ListExample.Image2TemplateProperty.SetDefault(_listExample, ListExampleImage2);
                    Delight.ListExample.Label2TemplateProperty.SetDefault(_listExample, ListExampleLabel2);
                }
                return _listExample;
            }
        }

        private static Template _listExampleGroup1;
        public static Template ListExampleGroup1
        {
            get
            {
#if UNITY_EDITOR
                if (_listExampleGroup1 == null || _listExampleGroup1.CurrentVersion != Template.Version)
#else
                if (_listExampleGroup1 == null)
#endif
                {
                    _listExampleGroup1 = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _listExampleGroup1.Name = "ListExampleGroup1";
#endif
                    Delight.Group.OrientationProperty.SetDefault(_listExampleGroup1, Delight.ElementOrientation.Horizontal);
                    Delight.Group.SpacingProperty.SetDefault(_listExampleGroup1, new ElementSize(10f, ElementSizeUnit.Pixels));
                }
                return _listExampleGroup1;
            }
        }

        private static Template _listExampleGroup2;
        public static Template ListExampleGroup2
        {
            get
            {
#if UNITY_EDITOR
                if (_listExampleGroup2 == null || _listExampleGroup2.CurrentVersion != Template.Version)
#else
                if (_listExampleGroup2 == null)
#endif
                {
                    _listExampleGroup2 = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _listExampleGroup2.Name = "ListExampleGroup2";
#endif
                    Delight.Group.SpacingProperty.SetDefault(_listExampleGroup2, new ElementSize(10f, ElementSizeUnit.Pixels));
                    Delight.Group.WidthProperty.SetDefault(_listExampleGroup2, new ElementSize(200f, ElementSizeUnit.Pixels));
                }
                return _listExampleGroup2;
            }
        }

        private static Template _listExampleInputField1;
        public static Template ListExampleInputField1
        {
            get
            {
#if UNITY_EDITOR
                if (_listExampleInputField1 == null || _listExampleInputField1.CurrentVersion != Template.Version)
#else
                if (_listExampleInputField1 == null)
#endif
                {
                    _listExampleInputField1 = new Template(InputFieldTemplates.InputField);
#if UNITY_EDITOR
                    _listExampleInputField1.Name = "ListExampleInputField1";
#endif
                    Delight.InputField.WidthProperty.SetDefault(_listExampleInputField1, new ElementSize(200f, ElementSizeUnit.Pixels));
                    Delight.InputField.TextProperty.SetHasBinding(_listExampleInputField1);
                    Delight.InputField.InputFieldPlaceholderTemplateProperty.SetDefault(_listExampleInputField1, ListExampleInputField1InputFieldPlaceholder);
                    Delight.InputField.TextAreaTemplateProperty.SetDefault(_listExampleInputField1, ListExampleInputField1TextArea);
                    Delight.InputField.InputTextTemplateProperty.SetDefault(_listExampleInputField1, ListExampleInputField1InputText);
                }
                return _listExampleInputField1;
            }
        }

        private static Template _listExampleInputField1InputFieldPlaceholder;
        public static Template ListExampleInputField1InputFieldPlaceholder
        {
            get
            {
#if UNITY_EDITOR
                if (_listExampleInputField1InputFieldPlaceholder == null || _listExampleInputField1InputFieldPlaceholder.CurrentVersion != Template.Version)
#else
                if (_listExampleInputField1InputFieldPlaceholder == null)
#endif
                {
                    _listExampleInputField1InputFieldPlaceholder = new Template(InputFieldTemplates.InputFieldInputFieldPlaceholder);
#if UNITY_EDITOR
                    _listExampleInputField1InputFieldPlaceholder.Name = "ListExampleInputField1InputFieldPlaceholder";
#endif
                }
                return _listExampleInputField1InputFieldPlaceholder;
            }
        }

        private static Template _listExampleInputField1TextArea;
        public static Template ListExampleInputField1TextArea
        {
            get
            {
#if UNITY_EDITOR
                if (_listExampleInputField1TextArea == null || _listExampleInputField1TextArea.CurrentVersion != Template.Version)
#else
                if (_listExampleInputField1TextArea == null)
#endif
                {
                    _listExampleInputField1TextArea = new Template(InputFieldTemplates.InputFieldTextArea);
#if UNITY_EDITOR
                    _listExampleInputField1TextArea.Name = "ListExampleInputField1TextArea";
#endif
                }
                return _listExampleInputField1TextArea;
            }
        }

        private static Template _listExampleInputField1InputText;
        public static Template ListExampleInputField1InputText
        {
            get
            {
#if UNITY_EDITOR
                if (_listExampleInputField1InputText == null || _listExampleInputField1InputText.CurrentVersion != Template.Version)
#else
                if (_listExampleInputField1InputText == null)
#endif
                {
                    _listExampleInputField1InputText = new Template(InputFieldTemplates.InputFieldInputText);
#if UNITY_EDITOR
                    _listExampleInputField1InputText.Name = "ListExampleInputField1InputText";
#endif
                }
                return _listExampleInputField1InputText;
            }
        }

        private static Template _listExampleButton1;
        public static Template ListExampleButton1
        {
            get
            {
#if UNITY_EDITOR
                if (_listExampleButton1 == null || _listExampleButton1.CurrentVersion != Template.Version)
#else
                if (_listExampleButton1 == null)
#endif
                {
                    _listExampleButton1 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _listExampleButton1.Name = "ListExampleButton1";
#endif
                    Delight.Button.WidthProperty.SetDefault(_listExampleButton1, new ElementSize(200f, ElementSizeUnit.Pixels));
                    Delight.Button.LabelTemplateProperty.SetDefault(_listExampleButton1, ListExampleButton1Label);
                }
                return _listExampleButton1;
            }
        }

        private static Template _listExampleButton1Label;
        public static Template ListExampleButton1Label
        {
            get
            {
#if UNITY_EDITOR
                if (_listExampleButton1Label == null || _listExampleButton1Label.CurrentVersion != Template.Version)
#else
                if (_listExampleButton1Label == null)
#endif
                {
                    _listExampleButton1Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _listExampleButton1Label.Name = "ListExampleButton1Label";
#endif
                    Delight.Label.TextProperty.SetDefault(_listExampleButton1Label, "Select");
                }
                return _listExampleButton1Label;
            }
        }

        private static Template _listExampleButton2;
        public static Template ListExampleButton2
        {
            get
            {
#if UNITY_EDITOR
                if (_listExampleButton2 == null || _listExampleButton2.CurrentVersion != Template.Version)
#else
                if (_listExampleButton2 == null)
#endif
                {
                    _listExampleButton2 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _listExampleButton2.Name = "ListExampleButton2";
#endif
                    Delight.Button.WidthProperty.SetDefault(_listExampleButton2, new ElementSize(200f, ElementSizeUnit.Pixels));
                    Delight.Button.LabelTemplateProperty.SetDefault(_listExampleButton2, ListExampleButton2Label);
                }
                return _listExampleButton2;
            }
        }

        private static Template _listExampleButton2Label;
        public static Template ListExampleButton2Label
        {
            get
            {
#if UNITY_EDITOR
                if (_listExampleButton2Label == null || _listExampleButton2Label.CurrentVersion != Template.Version)
#else
                if (_listExampleButton2Label == null)
#endif
                {
                    _listExampleButton2Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _listExampleButton2Label.Name = "ListExampleButton2Label";
#endif
                    Delight.Label.TextProperty.SetDefault(_listExampleButton2Label, "ScrollTo");
                }
                return _listExampleButton2Label;
            }
        }

        private static Template _listExampleButton3;
        public static Template ListExampleButton3
        {
            get
            {
#if UNITY_EDITOR
                if (_listExampleButton3 == null || _listExampleButton3.CurrentVersion != Template.Version)
#else
                if (_listExampleButton3 == null)
#endif
                {
                    _listExampleButton3 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _listExampleButton3.Name = "ListExampleButton3";
#endif
                    Delight.Button.WidthProperty.SetDefault(_listExampleButton3, new ElementSize(200f, ElementSizeUnit.Pixels));
                    Delight.Button.MarginProperty.SetDefault(_listExampleButton3, new ElementMargin(new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(5f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels)));
                    Delight.Button.LabelTemplateProperty.SetDefault(_listExampleButton3, ListExampleButton3Label);
                }
                return _listExampleButton3;
            }
        }

        private static Template _listExampleButton3Label;
        public static Template ListExampleButton3Label
        {
            get
            {
#if UNITY_EDITOR
                if (_listExampleButton3Label == null || _listExampleButton3Label.CurrentVersion != Template.Version)
#else
                if (_listExampleButton3Label == null)
#endif
                {
                    _listExampleButton3Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _listExampleButton3Label.Name = "ListExampleButton3Label";
#endif
                    Delight.Label.TextProperty.SetDefault(_listExampleButton3Label, "ScrollToSelected");
                }
                return _listExampleButton3Label;
            }
        }

        private static Template _listExampleButton4;
        public static Template ListExampleButton4
        {
            get
            {
#if UNITY_EDITOR
                if (_listExampleButton4 == null || _listExampleButton4.CurrentVersion != Template.Version)
#else
                if (_listExampleButton4 == null)
#endif
                {
                    _listExampleButton4 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _listExampleButton4.Name = "ListExampleButton4";
#endif
                    Delight.Button.WidthProperty.SetDefault(_listExampleButton4, new ElementSize(200f, ElementSizeUnit.Pixels));
                    Delight.Button.MarginProperty.SetDefault(_listExampleButton4, new ElementMargin(new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(5f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels)));
                    Delight.Button.LabelTemplateProperty.SetDefault(_listExampleButton4, ListExampleButton4Label);
                }
                return _listExampleButton4;
            }
        }

        private static Template _listExampleButton4Label;
        public static Template ListExampleButton4Label
        {
            get
            {
#if UNITY_EDITOR
                if (_listExampleButton4Label == null || _listExampleButton4Label.CurrentVersion != Template.Version)
#else
                if (_listExampleButton4Label == null)
#endif
                {
                    _listExampleButton4Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _listExampleButton4Label.Name = "ListExampleButton4Label";
#endif
                    Delight.Label.TextProperty.SetDefault(_listExampleButton4Label, "Add");
                }
                return _listExampleButton4Label;
            }
        }

        private static Template _listExampleButton5;
        public static Template ListExampleButton5
        {
            get
            {
#if UNITY_EDITOR
                if (_listExampleButton5 == null || _listExampleButton5.CurrentVersion != Template.Version)
#else
                if (_listExampleButton5 == null)
#endif
                {
                    _listExampleButton5 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _listExampleButton5.Name = "ListExampleButton5";
#endif
                    Delight.Button.WidthProperty.SetDefault(_listExampleButton5, new ElementSize(200f, ElementSizeUnit.Pixels));
                    Delight.Button.MarginProperty.SetDefault(_listExampleButton5, new ElementMargin(new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(5f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels)));
                    Delight.Button.LabelTemplateProperty.SetDefault(_listExampleButton5, ListExampleButton5Label);
                }
                return _listExampleButton5;
            }
        }

        private static Template _listExampleButton5Label;
        public static Template ListExampleButton5Label
        {
            get
            {
#if UNITY_EDITOR
                if (_listExampleButton5Label == null || _listExampleButton5Label.CurrentVersion != Template.Version)
#else
                if (_listExampleButton5Label == null)
#endif
                {
                    _listExampleButton5Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _listExampleButton5Label.Name = "ListExampleButton5Label";
#endif
                    Delight.Label.TextProperty.SetDefault(_listExampleButton5Label, "Insert");
                }
                return _listExampleButton5Label;
            }
        }

        private static Template _listExampleButton6;
        public static Template ListExampleButton6
        {
            get
            {
#if UNITY_EDITOR
                if (_listExampleButton6 == null || _listExampleButton6.CurrentVersion != Template.Version)
#else
                if (_listExampleButton6 == null)
#endif
                {
                    _listExampleButton6 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _listExampleButton6.Name = "ListExampleButton6";
#endif
                    Delight.Button.WidthProperty.SetDefault(_listExampleButton6, new ElementSize(200f, ElementSizeUnit.Pixels));
                    Delight.Button.MarginProperty.SetDefault(_listExampleButton6, new ElementMargin(new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(5f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels)));
                    Delight.Button.LabelTemplateProperty.SetDefault(_listExampleButton6, ListExampleButton6Label);
                }
                return _listExampleButton6;
            }
        }

        private static Template _listExampleButton6Label;
        public static Template ListExampleButton6Label
        {
            get
            {
#if UNITY_EDITOR
                if (_listExampleButton6Label == null || _listExampleButton6Label.CurrentVersion != Template.Version)
#else
                if (_listExampleButton6Label == null)
#endif
                {
                    _listExampleButton6Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _listExampleButton6Label.Name = "ListExampleButton6Label";
#endif
                    Delight.Label.TextProperty.SetDefault(_listExampleButton6Label, "Remove");
                }
                return _listExampleButton6Label;
            }
        }

        private static Template _listExamplePlayerList;
        public static Template ListExamplePlayerList
        {
            get
            {
#if UNITY_EDITOR
                if (_listExamplePlayerList == null || _listExamplePlayerList.CurrentVersion != Template.Version)
#else
                if (_listExamplePlayerList == null)
#endif
                {
                    _listExamplePlayerList = new Template(ListTemplates.List);
#if UNITY_EDITOR
                    _listExamplePlayerList.Name = "ListExamplePlayerList";
#endif
                    Delight.List.WidthProperty.SetDefault(_listExamplePlayerList, new ElementSize(425f, ElementSizeUnit.Pixels));
                    Delight.List.HeightProperty.SetDefault(_listExamplePlayerList, new ElementSize(500f, ElementSizeUnit.Pixels));
                    Delight.List.BackgroundColorProperty.SetDefault(_listExamplePlayerList, new UnityEngine.Color(0f, 1f, 0f, 1f));
                    Delight.List.SpacingProperty.SetDefault(_listExamplePlayerList, new ElementSize(5f, ElementSizeUnit.Pixels));
                    Delight.List.IsScrollableProperty.SetDefault(_listExamplePlayerList, true);
                    Delight.List.OverflowProperty.SetDefault(_listExamplePlayerList, Delight.OverflowMode.Wrap);
                    Delight.List.OrientationProperty.SetDefault(_listExamplePlayerList, Delight.ElementOrientation.Horizontal);
                    Delight.List.CanMultiSelectProperty.SetDefault(_listExamplePlayerList, false);
                    Delight.List.IsVirtualizedProperty.SetDefault(_listExamplePlayerList, true);
                    Delight.List.ItemsProperty.SetHasBinding(_listExamplePlayerList);
                    Delight.List.SelectedItemProperty.SetHasBinding(_listExamplePlayerList);
                    Delight.List.ScrollableRegionTemplateProperty.SetDefault(_listExamplePlayerList, ListExamplePlayerListScrollableRegion);
                }
                return _listExamplePlayerList;
            }
        }

        private static Template _listExamplePlayerListScrollableRegion;
        public static Template ListExamplePlayerListScrollableRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_listExamplePlayerListScrollableRegion == null || _listExamplePlayerListScrollableRegion.CurrentVersion != Template.Version)
#else
                if (_listExamplePlayerListScrollableRegion == null)
#endif
                {
                    _listExamplePlayerListScrollableRegion = new Template(ListTemplates.ListScrollableRegion);
#if UNITY_EDITOR
                    _listExamplePlayerListScrollableRegion.Name = "ListExamplePlayerListScrollableRegion";
#endif
                    Delight.ScrollableRegion.ContentRegionTemplateProperty.SetDefault(_listExamplePlayerListScrollableRegion, ListExamplePlayerListScrollableRegionContentRegion);
                    Delight.ScrollableRegion.HorizontalScrollbarTemplateProperty.SetDefault(_listExamplePlayerListScrollableRegion, ListExamplePlayerListScrollableRegionHorizontalScrollbar);
                    Delight.ScrollableRegion.VerticalScrollbarTemplateProperty.SetDefault(_listExamplePlayerListScrollableRegion, ListExamplePlayerListScrollableRegionVerticalScrollbar);
                }
                return _listExamplePlayerListScrollableRegion;
            }
        }

        private static Template _listExamplePlayerListScrollableRegionContentRegion;
        public static Template ListExamplePlayerListScrollableRegionContentRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_listExamplePlayerListScrollableRegionContentRegion == null || _listExamplePlayerListScrollableRegionContentRegion.CurrentVersion != Template.Version)
#else
                if (_listExamplePlayerListScrollableRegionContentRegion == null)
#endif
                {
                    _listExamplePlayerListScrollableRegionContentRegion = new Template(ListTemplates.ListScrollableRegionContentRegion);
#if UNITY_EDITOR
                    _listExamplePlayerListScrollableRegionContentRegion.Name = "ListExamplePlayerListScrollableRegionContentRegion";
#endif
                }
                return _listExamplePlayerListScrollableRegionContentRegion;
            }
        }

        private static Template _listExamplePlayerListScrollableRegionHorizontalScrollbar;
        public static Template ListExamplePlayerListScrollableRegionHorizontalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_listExamplePlayerListScrollableRegionHorizontalScrollbar == null || _listExamplePlayerListScrollableRegionHorizontalScrollbar.CurrentVersion != Template.Version)
#else
                if (_listExamplePlayerListScrollableRegionHorizontalScrollbar == null)
#endif
                {
                    _listExamplePlayerListScrollableRegionHorizontalScrollbar = new Template(ListTemplates.ListScrollableRegionHorizontalScrollbar);
#if UNITY_EDITOR
                    _listExamplePlayerListScrollableRegionHorizontalScrollbar.Name = "ListExamplePlayerListScrollableRegionHorizontalScrollbar";
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_listExamplePlayerListScrollableRegionHorizontalScrollbar, ListExamplePlayerListScrollableRegionHorizontalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_listExamplePlayerListScrollableRegionHorizontalScrollbar, ListExamplePlayerListScrollableRegionHorizontalScrollbarHandle);
                }
                return _listExamplePlayerListScrollableRegionHorizontalScrollbar;
            }
        }

        private static Template _listExamplePlayerListScrollableRegionHorizontalScrollbarBar;
        public static Template ListExamplePlayerListScrollableRegionHorizontalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_listExamplePlayerListScrollableRegionHorizontalScrollbarBar == null || _listExamplePlayerListScrollableRegionHorizontalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_listExamplePlayerListScrollableRegionHorizontalScrollbarBar == null)
#endif
                {
                    _listExamplePlayerListScrollableRegionHorizontalScrollbarBar = new Template(ListTemplates.ListScrollableRegionHorizontalScrollbarBar);
#if UNITY_EDITOR
                    _listExamplePlayerListScrollableRegionHorizontalScrollbarBar.Name = "ListExamplePlayerListScrollableRegionHorizontalScrollbarBar";
#endif
                }
                return _listExamplePlayerListScrollableRegionHorizontalScrollbarBar;
            }
        }

        private static Template _listExamplePlayerListScrollableRegionHorizontalScrollbarHandle;
        public static Template ListExamplePlayerListScrollableRegionHorizontalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_listExamplePlayerListScrollableRegionHorizontalScrollbarHandle == null || _listExamplePlayerListScrollableRegionHorizontalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_listExamplePlayerListScrollableRegionHorizontalScrollbarHandle == null)
#endif
                {
                    _listExamplePlayerListScrollableRegionHorizontalScrollbarHandle = new Template(ListTemplates.ListScrollableRegionHorizontalScrollbarHandle);
#if UNITY_EDITOR
                    _listExamplePlayerListScrollableRegionHorizontalScrollbarHandle.Name = "ListExamplePlayerListScrollableRegionHorizontalScrollbarHandle";
#endif
                }
                return _listExamplePlayerListScrollableRegionHorizontalScrollbarHandle;
            }
        }

        private static Template _listExamplePlayerListScrollableRegionVerticalScrollbar;
        public static Template ListExamplePlayerListScrollableRegionVerticalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_listExamplePlayerListScrollableRegionVerticalScrollbar == null || _listExamplePlayerListScrollableRegionVerticalScrollbar.CurrentVersion != Template.Version)
#else
                if (_listExamplePlayerListScrollableRegionVerticalScrollbar == null)
#endif
                {
                    _listExamplePlayerListScrollableRegionVerticalScrollbar = new Template(ListTemplates.ListScrollableRegionVerticalScrollbar);
#if UNITY_EDITOR
                    _listExamplePlayerListScrollableRegionVerticalScrollbar.Name = "ListExamplePlayerListScrollableRegionVerticalScrollbar";
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_listExamplePlayerListScrollableRegionVerticalScrollbar, ListExamplePlayerListScrollableRegionVerticalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_listExamplePlayerListScrollableRegionVerticalScrollbar, ListExamplePlayerListScrollableRegionVerticalScrollbarHandle);
                }
                return _listExamplePlayerListScrollableRegionVerticalScrollbar;
            }
        }

        private static Template _listExamplePlayerListScrollableRegionVerticalScrollbarBar;
        public static Template ListExamplePlayerListScrollableRegionVerticalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_listExamplePlayerListScrollableRegionVerticalScrollbarBar == null || _listExamplePlayerListScrollableRegionVerticalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_listExamplePlayerListScrollableRegionVerticalScrollbarBar == null)
#endif
                {
                    _listExamplePlayerListScrollableRegionVerticalScrollbarBar = new Template(ListTemplates.ListScrollableRegionVerticalScrollbarBar);
#if UNITY_EDITOR
                    _listExamplePlayerListScrollableRegionVerticalScrollbarBar.Name = "ListExamplePlayerListScrollableRegionVerticalScrollbarBar";
#endif
                }
                return _listExamplePlayerListScrollableRegionVerticalScrollbarBar;
            }
        }

        private static Template _listExamplePlayerListScrollableRegionVerticalScrollbarHandle;
        public static Template ListExamplePlayerListScrollableRegionVerticalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_listExamplePlayerListScrollableRegionVerticalScrollbarHandle == null || _listExamplePlayerListScrollableRegionVerticalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_listExamplePlayerListScrollableRegionVerticalScrollbarHandle == null)
#endif
                {
                    _listExamplePlayerListScrollableRegionVerticalScrollbarHandle = new Template(ListTemplates.ListScrollableRegionVerticalScrollbarHandle);
#if UNITY_EDITOR
                    _listExamplePlayerListScrollableRegionVerticalScrollbarHandle.Name = "ListExamplePlayerListScrollableRegionVerticalScrollbarHandle";
#endif
                }
                return _listExamplePlayerListScrollableRegionVerticalScrollbarHandle;
            }
        }

        private static Template _listExampleTemplateA;
        public static Template ListExampleTemplateA
        {
            get
            {
#if UNITY_EDITOR
                if (_listExampleTemplateA == null || _listExampleTemplateA.CurrentVersion != Template.Version)
#else
                if (_listExampleTemplateA == null)
#endif
                {
                    _listExampleTemplateA = new Template(ListItemTemplates.ListItem);
#if UNITY_EDITOR
                    _listExampleTemplateA.Name = "ListExampleTemplateA";
#endif
                    Delight.ListItem.WidthProperty.SetDefault(_listExampleTemplateA, new ElementSize(100f, ElementSizeUnit.Pixels));
                    Delight.ListItem.HeightProperty.SetDefault(_listExampleTemplateA, new ElementSize(100f, ElementSizeUnit.Pixels));
                }
                return _listExampleTemplateA;
            }
        }

        private static Template _listExampleImage1;
        public static Template ListExampleImage1
        {
            get
            {
#if UNITY_EDITOR
                if (_listExampleImage1 == null || _listExampleImage1.CurrentVersion != Template.Version)
#else
                if (_listExampleImage1 == null)
#endif
                {
                    _listExampleImage1 = new Template(ImageTemplates.Image);
#if UNITY_EDITOR
                    _listExampleImage1.Name = "ListExampleImage1";
#endif
                    Delight.Image.MarginProperty.SetDefault(_listExampleImage1, new ElementMargin(new ElementSize(5f, ElementSizeUnit.Pixels)));
                    Delight.Image.ColorProperty.SetHasBinding(_listExampleImage1);
                }
                return _listExampleImage1;
            }
        }

        private static Template _listExampleLabel1;
        public static Template ListExampleLabel1
        {
            get
            {
#if UNITY_EDITOR
                if (_listExampleLabel1 == null || _listExampleLabel1.CurrentVersion != Template.Version)
#else
                if (_listExampleLabel1 == null)
#endif
                {
                    _listExampleLabel1 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _listExampleLabel1.Name = "ListExampleLabel1";
#endif
                    Delight.Label.AutoSizeProperty.SetDefault(_listExampleLabel1, Delight.AutoSize.Default);
                    Delight.Label.TextProperty.SetHasBinding(_listExampleLabel1);
                }
                return _listExampleLabel1;
            }
        }

        private static Template _listExampleTemplateB;
        public static Template ListExampleTemplateB
        {
            get
            {
#if UNITY_EDITOR
                if (_listExampleTemplateB == null || _listExampleTemplateB.CurrentVersion != Template.Version)
#else
                if (_listExampleTemplateB == null)
#endif
                {
                    _listExampleTemplateB = new Template(ListItemTemplates.ListItem);
#if UNITY_EDITOR
                    _listExampleTemplateB.Name = "ListExampleTemplateB";
#endif
                    Delight.ListItem.WidthProperty.SetDefault(_listExampleTemplateB, new ElementSize(205f, ElementSizeUnit.Pixels));
                    Delight.ListItem.HeightProperty.SetDefault(_listExampleTemplateB, new ElementSize(100f, ElementSizeUnit.Pixels));
                }
                return _listExampleTemplateB;
            }
        }

        private static Template _listExampleImage2;
        public static Template ListExampleImage2
        {
            get
            {
#if UNITY_EDITOR
                if (_listExampleImage2 == null || _listExampleImage2.CurrentVersion != Template.Version)
#else
                if (_listExampleImage2 == null)
#endif
                {
                    _listExampleImage2 = new Template(ImageTemplates.Image);
#if UNITY_EDITOR
                    _listExampleImage2.Name = "ListExampleImage2";
#endif
                    Delight.Image.MarginProperty.SetDefault(_listExampleImage2, new ElementMargin(new ElementSize(5f, ElementSizeUnit.Pixels)));
                    Delight.Image.ColorProperty.SetHasBinding(_listExampleImage2);
                }
                return _listExampleImage2;
            }
        }

        private static Template _listExampleLabel2;
        public static Template ListExampleLabel2
        {
            get
            {
#if UNITY_EDITOR
                if (_listExampleLabel2 == null || _listExampleLabel2.CurrentVersion != Template.Version)
#else
                if (_listExampleLabel2 == null)
#endif
                {
                    _listExampleLabel2 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _listExampleLabel2.Name = "ListExampleLabel2";
#endif
                    Delight.Label.AutoSizeProperty.SetDefault(_listExampleLabel2, Delight.AutoSize.Default);
                    Delight.Label.TextProperty.SetHasBinding(_listExampleLabel2);
                }
                return _listExampleLabel2;
            }
        }

        #endregion
    }

    #endregion
}
