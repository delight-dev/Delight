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
    public partial class ListExample : UIView
    {
        #region Constructors

        public ListExample(View parent, View layoutParent = null, string id = null, Template template = null, bool deferInitialization = false) :
            base(parent, layoutParent, id, template ?? ListExampleTemplates.Default, deferInitialization)
        {
            if (deferInitialization)
                return;

            // constructing List (List1)
            List1 = new List(this, this, "List1", List1Template);

            // binding <List Items="{player in @DemoPlayers}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> {  }, new List<Func<object>> {  }) }, new BindingPath(new List<string> { "List1", "Items" }, new List<Func<object>> { () => this, () => List1 }), () => List1.Items = Models.DemoPlayers, () => { }, false));

            // binding <List SelectedItem="{SelectedPlayer}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "SelectedPlayer" }, new List<Func<object>> { () => this }) }, new BindingPath(new List<string> { "List1", "SelectedItem" }, new List<Func<object>> { () => this, () => List1 }), () => List1.SelectedItem = SelectedPlayer, () => SelectedPlayer = List1.SelectedItem as Delight.DemoPlayer, true));

            // templates for List1
            List1.ContentTemplates.Add(new ContentTemplate(tiPlayer => 
            {
                var listItem1 = new ListItem(this, List1.Content, "ListItem1", ListItem1Template);
                listItem1.StateAnimations.Clear();
                var listItem1StateAnimation1 = new StateAnimation("Unlisted", DefaultStateName);
                listItem1StateAnimation1.Add(new Animator<Delight.ElementMargin>(listItem1, 2.85f, 0f, false, false, 0f, false, EasingFunctions.Get("ElasticEaseOut"), Delight.ElementMarginValueConverter.Interpolator, x => listItem1.Offset = x, () => listItem1.Offset, () => ListItem.OffsetProperty.NotifyPropertyChanged(listItem1), ListItem.OffsetProperty, "Unlisted", DefaultStateName));
                listItem1StateAnimation1.Add(new Animator<System.Boolean>(listItem1, 2.85f, 0f, false, false, 0f, false, EasingFunctions.Get("FlipStart"), Delight.BoolValueConverter.Interpolator, x => listItem1.IsVisible = x, () => listItem1.IsVisible, () => ListItem.IsVisibleProperty.NotifyPropertyChanged(listItem1), ListItem.IsVisibleProperty, "Unlisted", DefaultStateName));
                listItem1StateAnimation1.Add(new Animator<Delight.RaycastBlockMode>(listItem1, 2.85f, 0f, false, false, 0f, false, EasingFunctions.Get("FlipEnd"), Delight.EnumValueConverter<Delight.RaycastBlockMode>.Interpolator, x => listItem1.RaycastBlockMode = x, () => listItem1.RaycastBlockMode, () => ListItem.RaycastBlockModeProperty.NotifyPropertyChanged(listItem1), ListItem.RaycastBlockModeProperty, "Unlisted", DefaultStateName));
                listItem1.StateAnimations.Add(listItem1StateAnimation1);
                var listItem1StateAnimation2 = new StateAnimation(DefaultStateName, "Removed");
                listItem1StateAnimation2.Add(new Animator<UnityEngine.Vector3>(listItem1, 0.15f, 0f, false, false, 0f, false, EasingFunctions.Get("QuadraticEaseOut"), Delight.Vector3ValueConverter.Interpolator, x => listItem1.Scale = x, () => listItem1.Scale, () => ListItem.ScaleProperty.NotifyPropertyChanged(listItem1), ListItem.ScaleProperty, DefaultStateName, "Removed"));
                listItem1StateAnimation2.Add(new Animator<System.Boolean>(listItem1, 0.15f, 0f, false, false, 0f, false, EasingFunctions.Get("FlipEnd"), Delight.BoolValueConverter.Interpolator, x => listItem1.IsVisible = x, () => listItem1.IsVisible, () => ListItem.IsVisibleProperty.NotifyPropertyChanged(listItem1), ListItem.IsVisibleProperty, DefaultStateName, "Removed"));
                listItem1StateAnimation2.Add(new Animator<Delight.RaycastBlockMode>(listItem1, 0.15f, 0f, false, false, 0f, false, EasingFunctions.Get("FlipStart"), Delight.EnumValueConverter<Delight.RaycastBlockMode>.Interpolator, x => listItem1.RaycastBlockMode = x, () => listItem1.RaycastBlockMode, () => ListItem.RaycastBlockModeProperty.NotifyPropertyChanged(listItem1), ListItem.RaycastBlockModeProperty, DefaultStateName, "Removed"));
                listItem1.StateAnimations.Add(listItem1StateAnimation2);
                var region1 = new Region(this, listItem1.Content, "Region1", Region1Template);
                var image1 = new Image(this, region1.Content, "Image1", Image1Template);
                listItem1.SetListItemState.SetValue(image1, true);
                var image2 = new Image(this, region1.Content, "Image2", Image2Template);
                listItem1.SetListItemState.SetValue(image2, true);
                var region2 = new Region(this, region1.Content, "Region2", Region2Template);
                listItem1.SetListItemState.SetValue(region2, true);
                var label1 = new Label(this, region2.Content, "Label1", Label1Template);
                listItem1.SetListItemState.SetValue(label1, true);

                // binding <Label Text="{player.Name}">
                listItem1.Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "Item", "Name" }, new List<Func<object>> { () => tiPlayer, () => (tiPlayer.Item as Delight.DemoPlayer) }) }, new BindingPath(new List<string> { "Text" }, new List<Func<object>> { () => label1 }), () => label1.Text = (tiPlayer.Item as Delight.DemoPlayer).Name, () => { }, false));
                var mask1 = new Mask(this, region1.Content, "Mask1", Mask1Template);
                var image3 = new Image(this, mask1.Content, "Image3", Image3Template);

                // binding <Image Sprite="{player.Icon}">
                listItem1.Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "Item", "Icon" }, new List<Func<object>> { () => tiPlayer, () => (tiPlayer.Item as Delight.DemoPlayer) }) }, new BindingPath(new List<string> { "Sprite" }, new List<Func<object>> { () => image3 }), () => image3.Sprite = (tiPlayer.Item as Delight.DemoPlayer).Icon, () => { }, false));
                listItem1.IsDynamic = true;
                listItem1.SetContentTemplateData(tiPlayer);
                return listItem1;
            }, typeof(ListItem), "ListItem1"));

            // constructing Group (Group1)
            Group1 = new Group(this, this, "Group1", Group1Template);
            Button1 = new Button(this, Group1.Content, "Button1", Button1Template);
            Button1.Click.RegisterHandler(this, "Add");
            Button1.StateAnimations.Clear();
            var button1StateAnimation1 = new StateAnimation(AnyStateName, "Highlighted");
            button1StateAnimation1.Add(new Animator<UnityEngine.Color>(Button1, 0.05f, 0f, false, false, 0f, false, EasingFunctions.Get("Linear"), Delight.ColorValueConverter.Interpolator, x => Button1.BackgroundColor = x, () => Button1.BackgroundColor, () => Button.BackgroundColorProperty.NotifyPropertyChanged(Button1), Button.BackgroundColorProperty, AnyStateName, "Highlighted"));
            button1StateAnimation1.Add(new Animator<UnityEngine.Color>(Button1, 0.05f, 0f, false, false, 0f, false, EasingFunctions.Get("Linear"), Delight.ColorValueConverter.Interpolator, x => Button1.FontColor = x, () => Button1.FontColor, () => Button.FontColorProperty.NotifyPropertyChanged(Button1), Button.FontColorProperty, AnyStateName, "Highlighted"));
            Button1.StateAnimations.Add(button1StateAnimation1);
            var button1StateAnimation2 = new StateAnimation("Highlighted", DefaultStateName);
            button1StateAnimation2.Add(new Animator<UnityEngine.Color>(Button1, 0.5f, 0f, false, false, 0f, false, EasingFunctions.Get("Linear"), Delight.ColorValueConverter.Interpolator, x => Button1.BackgroundColor = x, () => Button1.BackgroundColor, () => Button.BackgroundColorProperty.NotifyPropertyChanged(Button1), Button.BackgroundColorProperty, "Highlighted", DefaultStateName));
            button1StateAnimation2.Add(new Animator<UnityEngine.Color>(Button1, 0.5f, 0f, false, false, 0f, false, EasingFunctions.Get("Linear"), Delight.ColorValueConverter.Interpolator, x => Button1.FontColor = x, () => Button1.FontColor, () => Button.FontColorProperty.NotifyPropertyChanged(Button1), Button.FontColorProperty, "Highlighted", DefaultStateName));
            Button1.StateAnimations.Add(button1StateAnimation2);
            Button2 = new Button(this, Group1.Content, "Button2", Button2Template);
            Button2.Click.RegisterHandler(() => Models.DemoPlayers.Remove(SelectedPlayer));
            Button2.StateAnimations.Clear();
            var button2StateAnimation1 = new StateAnimation(AnyStateName, "Highlighted");
            button2StateAnimation1.Add(new Animator<UnityEngine.Color>(Button2, 0.05f, 0f, false, false, 0f, false, EasingFunctions.Get("Linear"), Delight.ColorValueConverter.Interpolator, x => Button2.BackgroundColor = x, () => Button2.BackgroundColor, () => Button.BackgroundColorProperty.NotifyPropertyChanged(Button2), Button.BackgroundColorProperty, AnyStateName, "Highlighted"));
            button2StateAnimation1.Add(new Animator<UnityEngine.Color>(Button2, 0.05f, 0f, false, false, 0f, false, EasingFunctions.Get("Linear"), Delight.ColorValueConverter.Interpolator, x => Button2.FontColor = x, () => Button2.FontColor, () => Button.FontColorProperty.NotifyPropertyChanged(Button2), Button.FontColorProperty, AnyStateName, "Highlighted"));
            Button2.StateAnimations.Add(button2StateAnimation1);
            var button2StateAnimation2 = new StateAnimation("Highlighted", DefaultStateName);
            button2StateAnimation2.Add(new Animator<UnityEngine.Color>(Button2, 0.5f, 0f, false, false, 0f, false, EasingFunctions.Get("Linear"), Delight.ColorValueConverter.Interpolator, x => Button2.BackgroundColor = x, () => Button2.BackgroundColor, () => Button.BackgroundColorProperty.NotifyPropertyChanged(Button2), Button.BackgroundColorProperty, "Highlighted", DefaultStateName));
            button2StateAnimation2.Add(new Animator<UnityEngine.Color>(Button2, 0.5f, 0f, false, false, 0f, false, EasingFunctions.Get("Linear"), Delight.ColorValueConverter.Interpolator, x => Button2.FontColor = x, () => Button2.FontColor, () => Button.FontColorProperty.NotifyPropertyChanged(Button2), Button.FontColorProperty, "Highlighted", DefaultStateName));
            Button2.StateAnimations.Add(button2StateAnimation2);
            Button3 = new Button(this, Group1.Content, "Button3", Button3Template);
            Button3.Click.RegisterHandler(() => Models.DemoPlayers.Clear());
            Button3.StateAnimations.Clear();
            var button3StateAnimation1 = new StateAnimation(AnyStateName, "Highlighted");
            button3StateAnimation1.Add(new Animator<UnityEngine.Color>(Button3, 0.05f, 0f, false, false, 0f, false, EasingFunctions.Get("Linear"), Delight.ColorValueConverter.Interpolator, x => Button3.BackgroundColor = x, () => Button3.BackgroundColor, () => Button.BackgroundColorProperty.NotifyPropertyChanged(Button3), Button.BackgroundColorProperty, AnyStateName, "Highlighted"));
            button3StateAnimation1.Add(new Animator<UnityEngine.Color>(Button3, 0.05f, 0f, false, false, 0f, false, EasingFunctions.Get("Linear"), Delight.ColorValueConverter.Interpolator, x => Button3.FontColor = x, () => Button3.FontColor, () => Button.FontColorProperty.NotifyPropertyChanged(Button3), Button.FontColorProperty, AnyStateName, "Highlighted"));
            Button3.StateAnimations.Add(button3StateAnimation1);
            var button3StateAnimation2 = new StateAnimation("Highlighted", DefaultStateName);
            button3StateAnimation2.Add(new Animator<UnityEngine.Color>(Button3, 0.5f, 0f, false, false, 0f, false, EasingFunctions.Get("Linear"), Delight.ColorValueConverter.Interpolator, x => Button3.BackgroundColor = x, () => Button3.BackgroundColor, () => Button.BackgroundColorProperty.NotifyPropertyChanged(Button3), Button.BackgroundColorProperty, "Highlighted", DefaultStateName));
            button3StateAnimation2.Add(new Animator<UnityEngine.Color>(Button3, 0.5f, 0f, false, false, 0f, false, EasingFunctions.Get("Linear"), Delight.ColorValueConverter.Interpolator, x => Button3.FontColor = x, () => Button3.FontColor, () => Button.FontColorProperty.NotifyPropertyChanged(Button3), Button.FontColorProperty, "Highlighted", DefaultStateName));
            Button3.StateAnimations.Add(button3StateAnimation2);
            Button4 = new Button(this, Group1.Content, "Button4", Button4Template);
            Button4.Click.RegisterHandler(() => Models.DemoPlayers.Reset());
            Button4.StateAnimations.Clear();
            var button4StateAnimation1 = new StateAnimation(AnyStateName, "Highlighted");
            button4StateAnimation1.Add(new Animator<UnityEngine.Color>(Button4, 0.05f, 0f, false, false, 0f, false, EasingFunctions.Get("Linear"), Delight.ColorValueConverter.Interpolator, x => Button4.BackgroundColor = x, () => Button4.BackgroundColor, () => Button.BackgroundColorProperty.NotifyPropertyChanged(Button4), Button.BackgroundColorProperty, AnyStateName, "Highlighted"));
            button4StateAnimation1.Add(new Animator<UnityEngine.Color>(Button4, 0.05f, 0f, false, false, 0f, false, EasingFunctions.Get("Linear"), Delight.ColorValueConverter.Interpolator, x => Button4.FontColor = x, () => Button4.FontColor, () => Button.FontColorProperty.NotifyPropertyChanged(Button4), Button.FontColorProperty, AnyStateName, "Highlighted"));
            Button4.StateAnimations.Add(button4StateAnimation1);
            var button4StateAnimation2 = new StateAnimation("Highlighted", DefaultStateName);
            button4StateAnimation2.Add(new Animator<UnityEngine.Color>(Button4, 0.5f, 0f, false, false, 0f, false, EasingFunctions.Get("Linear"), Delight.ColorValueConverter.Interpolator, x => Button4.BackgroundColor = x, () => Button4.BackgroundColor, () => Button.BackgroundColorProperty.NotifyPropertyChanged(Button4), Button.BackgroundColorProperty, "Highlighted", DefaultStateName));
            button4StateAnimation2.Add(new Animator<UnityEngine.Color>(Button4, 0.5f, 0f, false, false, 0f, false, EasingFunctions.Get("Linear"), Delight.ColorValueConverter.Interpolator, x => Button4.FontColor = x, () => Button4.FontColor, () => Button.FontColorProperty.NotifyPropertyChanged(Button4), Button.FontColorProperty, "Highlighted", DefaultStateName));
            Button4.StateAnimations.Add(button4StateAnimation2);
            Button5 = new Button(this, Group1.Content, "Button5", Button5Template);
            Button5.Click.RegisterHandler(this, "Replace");
            Button5.StateAnimations.Clear();
            var button5StateAnimation1 = new StateAnimation(AnyStateName, "Highlighted");
            button5StateAnimation1.Add(new Animator<UnityEngine.Color>(Button5, 0.05f, 0f, false, false, 0f, false, EasingFunctions.Get("Linear"), Delight.ColorValueConverter.Interpolator, x => Button5.BackgroundColor = x, () => Button5.BackgroundColor, () => Button.BackgroundColorProperty.NotifyPropertyChanged(Button5), Button.BackgroundColorProperty, AnyStateName, "Highlighted"));
            button5StateAnimation1.Add(new Animator<UnityEngine.Color>(Button5, 0.05f, 0f, false, false, 0f, false, EasingFunctions.Get("Linear"), Delight.ColorValueConverter.Interpolator, x => Button5.FontColor = x, () => Button5.FontColor, () => Button.FontColorProperty.NotifyPropertyChanged(Button5), Button.FontColorProperty, AnyStateName, "Highlighted"));
            Button5.StateAnimations.Add(button5StateAnimation1);
            var button5StateAnimation2 = new StateAnimation("Highlighted", DefaultStateName);
            button5StateAnimation2.Add(new Animator<UnityEngine.Color>(Button5, 0.5f, 0f, false, false, 0f, false, EasingFunctions.Get("Linear"), Delight.ColorValueConverter.Interpolator, x => Button5.BackgroundColor = x, () => Button5.BackgroundColor, () => Button.BackgroundColorProperty.NotifyPropertyChanged(Button5), Button.BackgroundColorProperty, "Highlighted", DefaultStateName));
            button5StateAnimation2.Add(new Animator<UnityEngine.Color>(Button5, 0.5f, 0f, false, false, 0f, false, EasingFunctions.Get("Linear"), Delight.ColorValueConverter.Interpolator, x => Button5.FontColor = x, () => Button5.FontColor, () => Button.FontColorProperty.NotifyPropertyChanged(Button5), Button.FontColorProperty, "Highlighted", DefaultStateName));
            Button5.StateAnimations.Add(button5StateAnimation2);
            this.AfterInitializeInternal();
        }

        public ListExample() : this(null)
        {
        }

        static ListExample()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(ListExampleTemplates.Default, dependencyProperties);

            dependencyProperties.Add(SelectedPlayerProperty);
            dependencyProperties.Add(List1Property);
            dependencyProperties.Add(List1TemplateProperty);
            dependencyProperties.Add(ListItem1Property);
            dependencyProperties.Add(ListItem1TemplateProperty);
            dependencyProperties.Add(Region1Property);
            dependencyProperties.Add(Region1TemplateProperty);
            dependencyProperties.Add(Image1Property);
            dependencyProperties.Add(Image1TemplateProperty);
            dependencyProperties.Add(Image2Property);
            dependencyProperties.Add(Image2TemplateProperty);
            dependencyProperties.Add(Region2Property);
            dependencyProperties.Add(Region2TemplateProperty);
            dependencyProperties.Add(Label1Property);
            dependencyProperties.Add(Label1TemplateProperty);
            dependencyProperties.Add(Mask1Property);
            dependencyProperties.Add(Mask1TemplateProperty);
            dependencyProperties.Add(Image3Property);
            dependencyProperties.Add(Image3TemplateProperty);
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
            dependencyProperties.Add(Button5Property);
            dependencyProperties.Add(Button5TemplateProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<Delight.DemoPlayer> SelectedPlayerProperty = new DependencyProperty<Delight.DemoPlayer>("SelectedPlayer");
        public Delight.DemoPlayer SelectedPlayer
        {
            get { return SelectedPlayerProperty.GetValue(this); }
            set { SelectedPlayerProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<List> List1Property = new DependencyProperty<List>("List1");
        public List List1
        {
            get { return List1Property.GetValue(this); }
            set { List1Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> List1TemplateProperty = new DependencyProperty<Template>("List1Template");
        public Template List1Template
        {
            get { return List1TemplateProperty.GetValue(this); }
            set { List1TemplateProperty.SetValue(this, value); }
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

        public readonly static DependencyProperty<Mask> Mask1Property = new DependencyProperty<Mask>("Mask1");
        public Mask Mask1
        {
            get { return Mask1Property.GetValue(this); }
            set { Mask1Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Mask1TemplateProperty = new DependencyProperty<Template>("Mask1Template");
        public Template Mask1Template
        {
            get { return Mask1TemplateProperty.GetValue(this); }
            set { Mask1TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Image> Image3Property = new DependencyProperty<Image>("Image3");
        public Image Image3
        {
            get { return Image3Property.GetValue(this); }
            set { Image3Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Image3TemplateProperty = new DependencyProperty<Template>("Image3Template");
        public Template Image3Template
        {
            get { return Image3TemplateProperty.GetValue(this); }
            set { Image3TemplateProperty.SetValue(this, value); }
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
                    _listExample = new Template(UIViewTemplates.UIView);
#if UNITY_EDITOR
                    _listExample.Name = "ListExample";
                    _listExample.LineNumber = 0;
                    _listExample.LinePosition = 0;
#endif
                    Delight.ListExample.List1TemplateProperty.SetDefault(_listExample, ListExampleList1);
                    Delight.ListExample.ListItem1TemplateProperty.SetDefault(_listExample, ListExampleListItem1);
                    Delight.ListExample.Region1TemplateProperty.SetDefault(_listExample, ListExampleRegion1);
                    Delight.ListExample.Image1TemplateProperty.SetDefault(_listExample, ListExampleImage1);
                    Delight.ListExample.Image2TemplateProperty.SetDefault(_listExample, ListExampleImage2);
                    Delight.ListExample.Region2TemplateProperty.SetDefault(_listExample, ListExampleRegion2);
                    Delight.ListExample.Label1TemplateProperty.SetDefault(_listExample, ListExampleLabel1);
                    Delight.ListExample.Mask1TemplateProperty.SetDefault(_listExample, ListExampleMask1);
                    Delight.ListExample.Image3TemplateProperty.SetDefault(_listExample, ListExampleImage3);
                    Delight.ListExample.Group1TemplateProperty.SetDefault(_listExample, ListExampleGroup1);
                    Delight.ListExample.Button1TemplateProperty.SetDefault(_listExample, ListExampleButton1);
                    Delight.ListExample.Button2TemplateProperty.SetDefault(_listExample, ListExampleButton2);
                    Delight.ListExample.Button3TemplateProperty.SetDefault(_listExample, ListExampleButton3);
                    Delight.ListExample.Button4TemplateProperty.SetDefault(_listExample, ListExampleButton4);
                    Delight.ListExample.Button5TemplateProperty.SetDefault(_listExample, ListExampleButton5);
                }
                return _listExample;
            }
        }

        private static Template _listExampleList1;
        public static Template ListExampleList1
        {
            get
            {
#if UNITY_EDITOR
                if (_listExampleList1 == null || _listExampleList1.CurrentVersion != Template.Version)
#else
                if (_listExampleList1 == null)
#endif
                {
                    _listExampleList1 = new Template(ListTemplates.List);
#if UNITY_EDITOR
                    _listExampleList1.Name = "ListExampleList1";
                    _listExampleList1.LineNumber = 2;
                    _listExampleList1.LinePosition = 4;
#endif
                    Delight.List.SpacingProperty.SetDefault(_listExampleList1, new ElementSize(5f, ElementSizeUnit.Pixels));
                    Delight.List.CascadingAnimationDelayProperty.SetDefault(_listExampleList1, 0.05f);
                    Delight.List.ItemsProperty.SetHasBinding(_listExampleList1);
                    Delight.List.SelectedItemProperty.SetHasBinding(_listExampleList1);
                    Delight.List.ScrollableRegionTemplateProperty.SetDefault(_listExampleList1, ListExampleList1ScrollableRegion);
                }
                return _listExampleList1;
            }
        }

        private static Template _listExampleList1ScrollableRegion;
        public static Template ListExampleList1ScrollableRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_listExampleList1ScrollableRegion == null || _listExampleList1ScrollableRegion.CurrentVersion != Template.Version)
#else
                if (_listExampleList1ScrollableRegion == null)
#endif
                {
                    _listExampleList1ScrollableRegion = new Template(ListTemplates.ListScrollableRegion);
#if UNITY_EDITOR
                    _listExampleList1ScrollableRegion.Name = "ListExampleList1ScrollableRegion";
                    _listExampleList1ScrollableRegion.LineNumber = 29;
                    _listExampleList1ScrollableRegion.LinePosition = 4;
#endif
                    Delight.ScrollableRegion.ContentRegionTemplateProperty.SetDefault(_listExampleList1ScrollableRegion, ListExampleList1ScrollableRegionContentRegion);
                    Delight.ScrollableRegion.HorizontalScrollbarTemplateProperty.SetDefault(_listExampleList1ScrollableRegion, ListExampleList1ScrollableRegionHorizontalScrollbar);
                    Delight.ScrollableRegion.VerticalScrollbarTemplateProperty.SetDefault(_listExampleList1ScrollableRegion, ListExampleList1ScrollableRegionVerticalScrollbar);
                }
                return _listExampleList1ScrollableRegion;
            }
        }

        private static Template _listExampleList1ScrollableRegionContentRegion;
        public static Template ListExampleList1ScrollableRegionContentRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_listExampleList1ScrollableRegionContentRegion == null || _listExampleList1ScrollableRegionContentRegion.CurrentVersion != Template.Version)
#else
                if (_listExampleList1ScrollableRegionContentRegion == null)
#endif
                {
                    _listExampleList1ScrollableRegionContentRegion = new Template(ListTemplates.ListScrollableRegionContentRegion);
#if UNITY_EDITOR
                    _listExampleList1ScrollableRegionContentRegion.Name = "ListExampleList1ScrollableRegionContentRegion";
                    _listExampleList1ScrollableRegionContentRegion.LineNumber = 24;
                    _listExampleList1ScrollableRegionContentRegion.LinePosition = 4;
#endif
                }
                return _listExampleList1ScrollableRegionContentRegion;
            }
        }

        private static Template _listExampleList1ScrollableRegionHorizontalScrollbar;
        public static Template ListExampleList1ScrollableRegionHorizontalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_listExampleList1ScrollableRegionHorizontalScrollbar == null || _listExampleList1ScrollableRegionHorizontalScrollbar.CurrentVersion != Template.Version)
#else
                if (_listExampleList1ScrollableRegionHorizontalScrollbar == null)
#endif
                {
                    _listExampleList1ScrollableRegionHorizontalScrollbar = new Template(ListTemplates.ListScrollableRegionHorizontalScrollbar);
#if UNITY_EDITOR
                    _listExampleList1ScrollableRegionHorizontalScrollbar.Name = "ListExampleList1ScrollableRegionHorizontalScrollbar";
                    _listExampleList1ScrollableRegionHorizontalScrollbar.LineNumber = 26;
                    _listExampleList1ScrollableRegionHorizontalScrollbar.LinePosition = 4;
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_listExampleList1ScrollableRegionHorizontalScrollbar, ListExampleList1ScrollableRegionHorizontalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_listExampleList1ScrollableRegionHorizontalScrollbar, ListExampleList1ScrollableRegionHorizontalScrollbarHandle);
                }
                return _listExampleList1ScrollableRegionHorizontalScrollbar;
            }
        }

        private static Template _listExampleList1ScrollableRegionHorizontalScrollbarBar;
        public static Template ListExampleList1ScrollableRegionHorizontalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_listExampleList1ScrollableRegionHorizontalScrollbarBar == null || _listExampleList1ScrollableRegionHorizontalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_listExampleList1ScrollableRegionHorizontalScrollbarBar == null)
#endif
                {
                    _listExampleList1ScrollableRegionHorizontalScrollbarBar = new Template(ListTemplates.ListScrollableRegionHorizontalScrollbarBar);
#if UNITY_EDITOR
                    _listExampleList1ScrollableRegionHorizontalScrollbarBar.Name = "ListExampleList1ScrollableRegionHorizontalScrollbarBar";
                    _listExampleList1ScrollableRegionHorizontalScrollbarBar.LineNumber = 7;
                    _listExampleList1ScrollableRegionHorizontalScrollbarBar.LinePosition = 4;
#endif
                }
                return _listExampleList1ScrollableRegionHorizontalScrollbarBar;
            }
        }

        private static Template _listExampleList1ScrollableRegionHorizontalScrollbarHandle;
        public static Template ListExampleList1ScrollableRegionHorizontalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_listExampleList1ScrollableRegionHorizontalScrollbarHandle == null || _listExampleList1ScrollableRegionHorizontalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_listExampleList1ScrollableRegionHorizontalScrollbarHandle == null)
#endif
                {
                    _listExampleList1ScrollableRegionHorizontalScrollbarHandle = new Template(ListTemplates.ListScrollableRegionHorizontalScrollbarHandle);
#if UNITY_EDITOR
                    _listExampleList1ScrollableRegionHorizontalScrollbarHandle.Name = "ListExampleList1ScrollableRegionHorizontalScrollbarHandle";
                    _listExampleList1ScrollableRegionHorizontalScrollbarHandle.LineNumber = 8;
                    _listExampleList1ScrollableRegionHorizontalScrollbarHandle.LinePosition = 6;
#endif
                }
                return _listExampleList1ScrollableRegionHorizontalScrollbarHandle;
            }
        }

        private static Template _listExampleList1ScrollableRegionVerticalScrollbar;
        public static Template ListExampleList1ScrollableRegionVerticalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_listExampleList1ScrollableRegionVerticalScrollbar == null || _listExampleList1ScrollableRegionVerticalScrollbar.CurrentVersion != Template.Version)
#else
                if (_listExampleList1ScrollableRegionVerticalScrollbar == null)
#endif
                {
                    _listExampleList1ScrollableRegionVerticalScrollbar = new Template(ListTemplates.ListScrollableRegionVerticalScrollbar);
#if UNITY_EDITOR
                    _listExampleList1ScrollableRegionVerticalScrollbar.Name = "ListExampleList1ScrollableRegionVerticalScrollbar";
                    _listExampleList1ScrollableRegionVerticalScrollbar.LineNumber = 27;
                    _listExampleList1ScrollableRegionVerticalScrollbar.LinePosition = 4;
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_listExampleList1ScrollableRegionVerticalScrollbar, ListExampleList1ScrollableRegionVerticalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_listExampleList1ScrollableRegionVerticalScrollbar, ListExampleList1ScrollableRegionVerticalScrollbarHandle);
                }
                return _listExampleList1ScrollableRegionVerticalScrollbar;
            }
        }

        private static Template _listExampleList1ScrollableRegionVerticalScrollbarBar;
        public static Template ListExampleList1ScrollableRegionVerticalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_listExampleList1ScrollableRegionVerticalScrollbarBar == null || _listExampleList1ScrollableRegionVerticalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_listExampleList1ScrollableRegionVerticalScrollbarBar == null)
#endif
                {
                    _listExampleList1ScrollableRegionVerticalScrollbarBar = new Template(ListTemplates.ListScrollableRegionVerticalScrollbarBar);
#if UNITY_EDITOR
                    _listExampleList1ScrollableRegionVerticalScrollbarBar.Name = "ListExampleList1ScrollableRegionVerticalScrollbarBar";
                    _listExampleList1ScrollableRegionVerticalScrollbarBar.LineNumber = 7;
                    _listExampleList1ScrollableRegionVerticalScrollbarBar.LinePosition = 4;
#endif
                }
                return _listExampleList1ScrollableRegionVerticalScrollbarBar;
            }
        }

        private static Template _listExampleList1ScrollableRegionVerticalScrollbarHandle;
        public static Template ListExampleList1ScrollableRegionVerticalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_listExampleList1ScrollableRegionVerticalScrollbarHandle == null || _listExampleList1ScrollableRegionVerticalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_listExampleList1ScrollableRegionVerticalScrollbarHandle == null)
#endif
                {
                    _listExampleList1ScrollableRegionVerticalScrollbarHandle = new Template(ListTemplates.ListScrollableRegionVerticalScrollbarHandle);
#if UNITY_EDITOR
                    _listExampleList1ScrollableRegionVerticalScrollbarHandle.Name = "ListExampleList1ScrollableRegionVerticalScrollbarHandle";
                    _listExampleList1ScrollableRegionVerticalScrollbarHandle.LineNumber = 8;
                    _listExampleList1ScrollableRegionVerticalScrollbarHandle.LinePosition = 6;
#endif
                }
                return _listExampleList1ScrollableRegionVerticalScrollbarHandle;
            }
        }

        private static Template _listExampleListItem1;
        public static Template ListExampleListItem1
        {
            get
            {
#if UNITY_EDITOR
                if (_listExampleListItem1 == null || _listExampleListItem1.CurrentVersion != Template.Version)
#else
                if (_listExampleListItem1 == null)
#endif
                {
                    _listExampleListItem1 = new Template(ListItemTemplates.ListItem);
#if UNITY_EDITOR
                    _listExampleListItem1.Name = "ListExampleListItem1";
                    _listExampleListItem1.LineNumber = 3;
                    _listExampleListItem1.LinePosition = 6;
#endif
                    Delight.ListItem.BackgroundColorProperty.SetStateDefault("Alternate", _listExampleListItem1, new UnityEngine.Color(0f, 0f, 0f, 0f));
                    Delight.ListItem.BackgroundColorProperty.SetStateDefault("Pressed", _listExampleListItem1, new UnityEngine.Color(0f, 0f, 0f, 0f));
                    Delight.ListItem.BackgroundColorProperty.SetStateDefault("Highlighted", _listExampleListItem1, new UnityEngine.Color(0f, 0f, 0f, 0f));
                    Delight.ListItem.BackgroundColorProperty.SetStateDefault("Selected", _listExampleListItem1, new UnityEngine.Color(0f, 0f, 0f, 0f));
                    Delight.ListItem.BackgroundColorProperty.SetDefault(_listExampleListItem1, new UnityEngine.Color(0f, 0f, 0f, 0f));
                    Delight.ListItem.OffsetProperty.SetDefault(_listExampleListItem1, new ElementMargin(new ElementSize(0f, ElementSizeUnit.Percents), new ElementSize(0f, ElementSizeUnit.Percents), new ElementSize(0f, ElementSizeUnit.Percents), new ElementSize(0f, ElementSizeUnit.Percents)));
                    Delight.ListItem.OffsetProperty.SetStateDefault("Unlisted", _listExampleListItem1, new ElementMargin(new ElementSize(1f, ElementSizeUnit.Percents), new ElementSize(0f, ElementSizeUnit.Percents), new ElementSize(0f, ElementSizeUnit.Percents), new ElementSize(0f, ElementSizeUnit.Percents)));
                    Delight.ListItem.IsVisibleProperty.SetDefault(_listExampleListItem1, true);
                    Delight.ListItem.IsVisibleProperty.SetStateDefault("Unlisted", _listExampleListItem1, false);
                    Delight.ListItem.IsVisibleProperty.SetStateDefault("Removed", _listExampleListItem1, false);
                    Delight.ListItem.RaycastBlockModeProperty.SetDefault(_listExampleListItem1, Delight.RaycastBlockMode.Always);
                    Delight.ListItem.RaycastBlockModeProperty.SetStateDefault("Unlisted", _listExampleListItem1, Delight.RaycastBlockMode.Never);
                    Delight.ListItem.RaycastBlockModeProperty.SetStateDefault("Removed", _listExampleListItem1, Delight.RaycastBlockMode.Never);
                    Delight.ListItem.ScaleProperty.SetDefault(_listExampleListItem1, new Vector3(1f, 1f, 0f));
                    Delight.ListItem.ScaleProperty.SetStateDefault("Unlisted", _listExampleListItem1, new Vector3(1f, 1f, 0f));
                    Delight.ListItem.ScaleProperty.SetStateDefault("Removed", _listExampleListItem1, new Vector3(0f, 0f, 0f));
                    Delight.ListItem.WidthProperty.SetDefault(_listExampleListItem1, new ElementSize(180f, ElementSizeUnit.Pixels));
                    Delight.ListItem.HeightProperty.SetDefault(_listExampleListItem1, new ElementSize(43f, ElementSizeUnit.Pixels));
                }
                return _listExampleListItem1;
            }
        }

        private static Template _listExampleRegion1;
        public static Template ListExampleRegion1
        {
            get
            {
#if UNITY_EDITOR
                if (_listExampleRegion1 == null || _listExampleRegion1.CurrentVersion != Template.Version)
#else
                if (_listExampleRegion1 == null)
#endif
                {
                    _listExampleRegion1 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _listExampleRegion1.Name = "ListExampleRegion1";
                    _listExampleRegion1.LineNumber = 4;
                    _listExampleRegion1.LinePosition = 8;
#endif
                    Delight.Region.WidthProperty.SetDefault(_listExampleRegion1, new ElementSize(180f, ElementSizeUnit.Pixels));
                    Delight.Region.HeightProperty.SetDefault(_listExampleRegion1, new ElementSize(43f, ElementSizeUnit.Pixels));
                }
                return _listExampleRegion1;
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
                    _listExampleImage1.LineNumber = 5;
                    _listExampleImage1.LinePosition = 10;
#endif
                    Delight.Image.SpriteProperty.SetDefault(_listExampleImage1, Assets.Sprites["CircleFull@512px"]);
                    Delight.Image.AlignmentProperty.SetDefault(_listExampleImage1, Delight.ElementAlignment.Left);
                    Delight.Image.ColorProperty.SetStateDefault("Highlighted", _listExampleImage1, new UnityEngine.Color(0.9647059f, 0.4745098f, 0.9960784f, 1f));
                    Delight.Image.ColorProperty.SetStateDefault("Selected", _listExampleImage1, new UnityEngine.Color(0.8509804f, 0.09803922f, 0.8784314f, 1f));
                    Delight.Image.WidthProperty.SetDefault(_listExampleImage1, new ElementSize(43f, ElementSizeUnit.Pixels));
                    Delight.Image.HeightProperty.SetDefault(_listExampleImage1, new ElementSize(43f, ElementSizeUnit.Pixels));
                }
                return _listExampleImage1;
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
                    _listExampleImage2.LineNumber = 6;
                    _listExampleImage2.LinePosition = 10;
#endif
                    Delight.Image.SpriteProperty.SetDefault(_listExampleImage2, Assets.Sprites["CircleFull@512px"]);
                    Delight.Image.AlignmentProperty.SetDefault(_listExampleImage2, Delight.ElementAlignment.Right);
                    Delight.Image.ColorProperty.SetStateDefault("Highlighted", _listExampleImage2, new UnityEngine.Color(0.9647059f, 0.4745098f, 0.9960784f, 1f));
                    Delight.Image.ColorProperty.SetStateDefault("Selected", _listExampleImage2, new UnityEngine.Color(0.8509804f, 0.09803922f, 0.8784314f, 1f));
                    Delight.Image.WidthProperty.SetDefault(_listExampleImage2, new ElementSize(43f, ElementSizeUnit.Pixels));
                    Delight.Image.HeightProperty.SetDefault(_listExampleImage2, new ElementSize(43f, ElementSizeUnit.Pixels));
                }
                return _listExampleImage2;
            }
        }

        private static Template _listExampleRegion2;
        public static Template ListExampleRegion2
        {
            get
            {
#if UNITY_EDITOR
                if (_listExampleRegion2 == null || _listExampleRegion2.CurrentVersion != Template.Version)
#else
                if (_listExampleRegion2 == null)
#endif
                {
                    _listExampleRegion2 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _listExampleRegion2.Name = "ListExampleRegion2";
                    _listExampleRegion2.LineNumber = 7;
                    _listExampleRegion2.LinePosition = 10;
#endif
                    Delight.Region.MarginProperty.SetDefault(_listExampleRegion2, new ElementMargin(new ElementSize(21.5f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(21.5f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels)));
                    Delight.Region.BackgroundColorProperty.SetDefault(_listExampleRegion2, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Region.BackgroundColorProperty.SetStateDefault("Highlighted", _listExampleRegion2, new UnityEngine.Color(0.9647059f, 0.4745098f, 0.9960784f, 1f));
                    Delight.Region.BackgroundColorProperty.SetStateDefault("Selected", _listExampleRegion2, new UnityEngine.Color(0.8509804f, 0.09803922f, 0.8784314f, 1f));
                }
                return _listExampleRegion2;
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
                    _listExampleLabel1.LineNumber = 8;
                    _listExampleLabel1.LinePosition = 12;
#endif
                    Delight.Label.OffsetProperty.SetDefault(_listExampleLabel1, new ElementMargin(new ElementSize(20f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels)));
                    Delight.Label.FontColorProperty.SetDefault(_listExampleLabel1, new UnityEngine.Color(0f, 0f, 0f, 1f));
                    Delight.Label.FontColorProperty.SetStateDefault("Selected", _listExampleLabel1, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Label.TextProperty.SetHasBinding(_listExampleLabel1);
                }
                return _listExampleLabel1;
            }
        }

        private static Template _listExampleMask1;
        public static Template ListExampleMask1
        {
            get
            {
#if UNITY_EDITOR
                if (_listExampleMask1 == null || _listExampleMask1.CurrentVersion != Template.Version)
#else
                if (_listExampleMask1 == null)
#endif
                {
                    _listExampleMask1 = new Template(MaskTemplates.Mask);
#if UNITY_EDITOR
                    _listExampleMask1.Name = "ListExampleMask1";
                    _listExampleMask1.LineNumber = 10;
                    _listExampleMask1.LinePosition = 10;
#endif
                    Delight.Mask.BackgroundSpriteProperty.SetDefault(_listExampleMask1, Assets.Sprites["CircleFull@512px"]);
                    Delight.Mask.AlignmentProperty.SetDefault(_listExampleMask1, Delight.ElementAlignment.Left);
                    Delight.Mask.OffsetProperty.SetDefault(_listExampleMask1, new ElementMargin(new ElementSize(5f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels)));
                    Delight.Mask.WidthProperty.SetDefault(_listExampleMask1, new ElementSize(35f, ElementSizeUnit.Pixels));
                    Delight.Mask.HeightProperty.SetDefault(_listExampleMask1, new ElementSize(35f, ElementSizeUnit.Pixels));
                }
                return _listExampleMask1;
            }
        }

        private static Template _listExampleImage3;
        public static Template ListExampleImage3
        {
            get
            {
#if UNITY_EDITOR
                if (_listExampleImage3 == null || _listExampleImage3.CurrentVersion != Template.Version)
#else
                if (_listExampleImage3 == null)
#endif
                {
                    _listExampleImage3 = new Template(ImageTemplates.Image);
#if UNITY_EDITOR
                    _listExampleImage3.Name = "ListExampleImage3";
                    _listExampleImage3.LineNumber = 11;
                    _listExampleImage3.LinePosition = 12;
#endif
                    Delight.Image.OffsetProperty.SetDefault(_listExampleImage3, new ElementMargin(new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels)));
                    Delight.Image.PreserveAspectProperty.SetDefault(_listExampleImage3, true);
                    Delight.Image.SpriteProperty.SetHasBinding(_listExampleImage3);
                    Delight.Image.WidthProperty.SetDefault(_listExampleImage3, new ElementSize(35f, ElementSizeUnit.Pixels));
                    Delight.Image.HeightProperty.SetDefault(_listExampleImage3, new ElementSize(35f, ElementSizeUnit.Pixels));
                }
                return _listExampleImage3;
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
                    _listExampleGroup1.LineNumber = 17;
                    _listExampleGroup1.LinePosition = 4;
#endif
                    Delight.Group.AlignmentProperty.SetDefault(_listExampleGroup1, Delight.ElementAlignment.Left);
                    Delight.Group.SpacingProperty.SetDefault(_listExampleGroup1, new ElementSize(5f, ElementSizeUnit.Pixels));
                    Delight.Group.OffsetProperty.SetDefault(_listExampleGroup1, new ElementMargin(new ElementSize(10f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels)));
                }
                return _listExampleGroup1;
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
                    _listExampleButton1.LineNumber = 18;
                    _listExampleButton1.LinePosition = 6;
#endif
                    Delight.Button.BackgroundSpriteProperty.SetDefault(_listExampleButton1, Assets.Sprites["RoundedSquareFull@128px"]);
                    Delight.Button.BackgroundColorProperty.SetDefault(_listExampleButton1, new UnityEngine.Color(0.4901961f, 0.4901961f, 0.4901961f, 1f));
                    Delight.Button.BackgroundColorProperty.SetStateDefault("Highlighted", _listExampleButton1, new UnityEngine.Color(0.8980392f, 0.8980392f, 0.8980392f, 1f));
                    Delight.Button.BackgroundColorProperty.SetStateDefault("Pressed", _listExampleButton1, new UnityEngine.Color(0.9372549f, 0.4392157f, 0.4156863f, 1f));
                    Delight.Button.HeightProperty.SetDefault(_listExampleButton1, new ElementSize(30f, ElementSizeUnit.Pixels));
                    Delight.Button.BackgroundColorProperty.SetStateDefault("Disabled", _listExampleButton1, new UnityEngine.Color(0.4901961f, 0.4901961f, 0.4901961f, 1f));
                    Delight.Button.WidthProperty.SetDefault(_listExampleButton1, new ElementSize(150f, ElementSizeUnit.Pixels));
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
                    _listExampleButton1Label.LineNumber = 15;
                    _listExampleButton1Label.LinePosition = 4;
#endif
                    Delight.Label.FontColorProperty.SetDefault(_listExampleButton1Label, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Label.FontStyleProperty.SetDefault(_listExampleButton1Label, TMPro.FontStyles.Normal);
                    Delight.Label.FontColorProperty.SetStateDefault("Highlighted", _listExampleButton1Label, new UnityEngine.Color(0f, 0f, 0f, 1f));
                    Delight.Label.FontColorProperty.SetStateDefault("Pressed", _listExampleButton1Label, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Label.FontSizeProperty.SetDefault(_listExampleButton1Label, 16f);
                    Delight.Label.FontStyleProperty.SetStateDefault("Disabled", _listExampleButton1Label, TMPro.FontStyles.Italic);
                    Delight.Label.FontColorProperty.SetStateDefault("Disabled", _listExampleButton1Label, new UnityEngine.Color(0.8f, 0.8f, 0.8f, 1f));
                    Delight.Label.TextProperty.SetDefault(_listExampleButton1Label, "Add");
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
                    _listExampleButton2.LineNumber = 19;
                    _listExampleButton2.LinePosition = 6;
#endif
                    Delight.Button.BackgroundSpriteProperty.SetDefault(_listExampleButton2, Assets.Sprites["RoundedSquareFull@128px"]);
                    Delight.Button.BackgroundColorProperty.SetDefault(_listExampleButton2, new UnityEngine.Color(0.4901961f, 0.4901961f, 0.4901961f, 1f));
                    Delight.Button.BackgroundColorProperty.SetStateDefault("Highlighted", _listExampleButton2, new UnityEngine.Color(0.8980392f, 0.8980392f, 0.8980392f, 1f));
                    Delight.Button.BackgroundColorProperty.SetStateDefault("Pressed", _listExampleButton2, new UnityEngine.Color(0.9372549f, 0.4392157f, 0.4156863f, 1f));
                    Delight.Button.HeightProperty.SetDefault(_listExampleButton2, new ElementSize(30f, ElementSizeUnit.Pixels));
                    Delight.Button.BackgroundColorProperty.SetStateDefault("Disabled", _listExampleButton2, new UnityEngine.Color(0.4901961f, 0.4901961f, 0.4901961f, 1f));
                    Delight.Button.WidthProperty.SetDefault(_listExampleButton2, new ElementSize(150f, ElementSizeUnit.Pixels));
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
                    _listExampleButton2Label.LineNumber = 15;
                    _listExampleButton2Label.LinePosition = 4;
#endif
                    Delight.Label.FontColorProperty.SetDefault(_listExampleButton2Label, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Label.FontStyleProperty.SetDefault(_listExampleButton2Label, TMPro.FontStyles.Normal);
                    Delight.Label.FontColorProperty.SetStateDefault("Highlighted", _listExampleButton2Label, new UnityEngine.Color(0f, 0f, 0f, 1f));
                    Delight.Label.FontColorProperty.SetStateDefault("Pressed", _listExampleButton2Label, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Label.FontSizeProperty.SetDefault(_listExampleButton2Label, 16f);
                    Delight.Label.FontStyleProperty.SetStateDefault("Disabled", _listExampleButton2Label, TMPro.FontStyles.Italic);
                    Delight.Label.FontColorProperty.SetStateDefault("Disabled", _listExampleButton2Label, new UnityEngine.Color(0.8f, 0.8f, 0.8f, 1f));
                    Delight.Label.TextProperty.SetDefault(_listExampleButton2Label, "Remove Selected");
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
                    _listExampleButton3.LineNumber = 20;
                    _listExampleButton3.LinePosition = 6;
#endif
                    Delight.Button.BackgroundSpriteProperty.SetDefault(_listExampleButton3, Assets.Sprites["RoundedSquareFull@128px"]);
                    Delight.Button.BackgroundColorProperty.SetDefault(_listExampleButton3, new UnityEngine.Color(0.4901961f, 0.4901961f, 0.4901961f, 1f));
                    Delight.Button.BackgroundColorProperty.SetStateDefault("Highlighted", _listExampleButton3, new UnityEngine.Color(0.8980392f, 0.8980392f, 0.8980392f, 1f));
                    Delight.Button.BackgroundColorProperty.SetStateDefault("Pressed", _listExampleButton3, new UnityEngine.Color(0.9372549f, 0.4392157f, 0.4156863f, 1f));
                    Delight.Button.HeightProperty.SetDefault(_listExampleButton3, new ElementSize(30f, ElementSizeUnit.Pixels));
                    Delight.Button.BackgroundColorProperty.SetStateDefault("Disabled", _listExampleButton3, new UnityEngine.Color(0.4901961f, 0.4901961f, 0.4901961f, 1f));
                    Delight.Button.WidthProperty.SetDefault(_listExampleButton3, new ElementSize(150f, ElementSizeUnit.Pixels));
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
                    _listExampleButton3Label.LineNumber = 15;
                    _listExampleButton3Label.LinePosition = 4;
#endif
                    Delight.Label.FontColorProperty.SetDefault(_listExampleButton3Label, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Label.FontStyleProperty.SetDefault(_listExampleButton3Label, TMPro.FontStyles.Normal);
                    Delight.Label.FontColorProperty.SetStateDefault("Highlighted", _listExampleButton3Label, new UnityEngine.Color(0f, 0f, 0f, 1f));
                    Delight.Label.FontColorProperty.SetStateDefault("Pressed", _listExampleButton3Label, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Label.FontSizeProperty.SetDefault(_listExampleButton3Label, 16f);
                    Delight.Label.FontStyleProperty.SetStateDefault("Disabled", _listExampleButton3Label, TMPro.FontStyles.Italic);
                    Delight.Label.FontColorProperty.SetStateDefault("Disabled", _listExampleButton3Label, new UnityEngine.Color(0.8f, 0.8f, 0.8f, 1f));
                    Delight.Label.TextProperty.SetDefault(_listExampleButton3Label, "Clear");
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
                    _listExampleButton4.LineNumber = 21;
                    _listExampleButton4.LinePosition = 6;
#endif
                    Delight.Button.BackgroundSpriteProperty.SetDefault(_listExampleButton4, Assets.Sprites["RoundedSquareFull@128px"]);
                    Delight.Button.BackgroundColorProperty.SetDefault(_listExampleButton4, new UnityEngine.Color(0.4901961f, 0.4901961f, 0.4901961f, 1f));
                    Delight.Button.BackgroundColorProperty.SetStateDefault("Highlighted", _listExampleButton4, new UnityEngine.Color(0.8980392f, 0.8980392f, 0.8980392f, 1f));
                    Delight.Button.BackgroundColorProperty.SetStateDefault("Pressed", _listExampleButton4, new UnityEngine.Color(0.9372549f, 0.4392157f, 0.4156863f, 1f));
                    Delight.Button.HeightProperty.SetDefault(_listExampleButton4, new ElementSize(30f, ElementSizeUnit.Pixels));
                    Delight.Button.BackgroundColorProperty.SetStateDefault("Disabled", _listExampleButton4, new UnityEngine.Color(0.4901961f, 0.4901961f, 0.4901961f, 1f));
                    Delight.Button.WidthProperty.SetDefault(_listExampleButton4, new ElementSize(150f, ElementSizeUnit.Pixels));
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
                    _listExampleButton4Label.LineNumber = 15;
                    _listExampleButton4Label.LinePosition = 4;
#endif
                    Delight.Label.FontColorProperty.SetDefault(_listExampleButton4Label, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Label.FontStyleProperty.SetDefault(_listExampleButton4Label, TMPro.FontStyles.Normal);
                    Delight.Label.FontColorProperty.SetStateDefault("Highlighted", _listExampleButton4Label, new UnityEngine.Color(0f, 0f, 0f, 1f));
                    Delight.Label.FontColorProperty.SetStateDefault("Pressed", _listExampleButton4Label, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Label.FontSizeProperty.SetDefault(_listExampleButton4Label, 16f);
                    Delight.Label.FontStyleProperty.SetStateDefault("Disabled", _listExampleButton4Label, TMPro.FontStyles.Italic);
                    Delight.Label.FontColorProperty.SetStateDefault("Disabled", _listExampleButton4Label, new UnityEngine.Color(0.8f, 0.8f, 0.8f, 1f));
                    Delight.Label.TextProperty.SetDefault(_listExampleButton4Label, "Reset");
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
                    _listExampleButton5.LineNumber = 22;
                    _listExampleButton5.LinePosition = 6;
#endif
                    Delight.Button.BackgroundSpriteProperty.SetDefault(_listExampleButton5, Assets.Sprites["RoundedSquareFull@128px"]);
                    Delight.Button.BackgroundColorProperty.SetDefault(_listExampleButton5, new UnityEngine.Color(0.4901961f, 0.4901961f, 0.4901961f, 1f));
                    Delight.Button.BackgroundColorProperty.SetStateDefault("Highlighted", _listExampleButton5, new UnityEngine.Color(0.8980392f, 0.8980392f, 0.8980392f, 1f));
                    Delight.Button.BackgroundColorProperty.SetStateDefault("Pressed", _listExampleButton5, new UnityEngine.Color(0.9372549f, 0.4392157f, 0.4156863f, 1f));
                    Delight.Button.HeightProperty.SetDefault(_listExampleButton5, new ElementSize(30f, ElementSizeUnit.Pixels));
                    Delight.Button.BackgroundColorProperty.SetStateDefault("Disabled", _listExampleButton5, new UnityEngine.Color(0.4901961f, 0.4901961f, 0.4901961f, 1f));
                    Delight.Button.WidthProperty.SetDefault(_listExampleButton5, new ElementSize(150f, ElementSizeUnit.Pixels));
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
                    _listExampleButton5Label.LineNumber = 15;
                    _listExampleButton5Label.LinePosition = 4;
#endif
                    Delight.Label.FontColorProperty.SetDefault(_listExampleButton5Label, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Label.FontStyleProperty.SetDefault(_listExampleButton5Label, TMPro.FontStyles.Normal);
                    Delight.Label.FontColorProperty.SetStateDefault("Highlighted", _listExampleButton5Label, new UnityEngine.Color(0f, 0f, 0f, 1f));
                    Delight.Label.FontColorProperty.SetStateDefault("Pressed", _listExampleButton5Label, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Label.FontSizeProperty.SetDefault(_listExampleButton5Label, 16f);
                    Delight.Label.FontStyleProperty.SetStateDefault("Disabled", _listExampleButton5Label, TMPro.FontStyles.Italic);
                    Delight.Label.FontColorProperty.SetStateDefault("Disabled", _listExampleButton5Label, new UnityEngine.Color(0.8f, 0.8f, 0.8f, 1f));
                    Delight.Label.TextProperty.SetDefault(_listExampleButton5Label, "Replace");
                }
                return _listExampleButton5Label;
            }
        }

        #endregion
    }

    #endregion
}
