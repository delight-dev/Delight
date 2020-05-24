// Internal view logic generated from "MainMenuExample.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class MainMenuExample : UIView
    {
        #region Constructors

        public MainMenuExample(View parent, View layoutParent = null, string id = null, Template template = null, bool deferInitialization = false) :
            base(parent, layoutParent, id, template ?? MainMenuExampleTemplates.Default, deferInitialization)
        {
            if (deferInitialization)
                return;

            // constructing Image (Image1)
            Image1 = new Image(this, this, "Image1", Image1Template);

            // constructing Label (Label1)
            Label1 = new Label(this, this, "Label1", Label1Template);

            // constructing Group (Group1)
            Group1 = new Group(this, this, "Group1", Group1Template);
            Button1 = new Button(this, Group1.Content, "Button1", Button1Template);
            Button1.Click.RegisterHandler(this, "Play");
            Button2 = new Button(this, Group1.Content, "Button2", Button2Template);
            Button2.Click.RegisterHandler(this, "ShowOptions");
            Button3 = new Button(this, Group1.Content, "Button3", Button3Template);
            Button3.Click.RegisterHandler(this, "Quit");
            this.AfterInitializeInternal();
        }

        public MainMenuExample() : this(null)
        {
        }

        static MainMenuExample()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(MainMenuExampleTemplates.Default, dependencyProperties);

            dependencyProperties.Add(Image1Property);
            dependencyProperties.Add(Image1TemplateProperty);
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
        }

        #endregion

        #region Properties

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

    public static class MainMenuExampleTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return MainMenuExample;
            }
        }

        private static Template _mainMenuExample;
        public static Template MainMenuExample
        {
            get
            {
#if UNITY_EDITOR
                if (_mainMenuExample == null || _mainMenuExample.CurrentVersion != Template.Version)
#else
                if (_mainMenuExample == null)
#endif
                {
                    _mainMenuExample = new Template(UIViewTemplates.UIView);
#if UNITY_EDITOR
                    _mainMenuExample.Name = "MainMenuExample";
#endif
                    Delight.MainMenuExample.Image1TemplateProperty.SetDefault(_mainMenuExample, MainMenuExampleImage1);
                    Delight.MainMenuExample.Label1TemplateProperty.SetDefault(_mainMenuExample, MainMenuExampleLabel1);
                    Delight.MainMenuExample.Group1TemplateProperty.SetDefault(_mainMenuExample, MainMenuExampleGroup1);
                    Delight.MainMenuExample.Button1TemplateProperty.SetDefault(_mainMenuExample, MainMenuExampleButton1);
                    Delight.MainMenuExample.Button2TemplateProperty.SetDefault(_mainMenuExample, MainMenuExampleButton2);
                    Delight.MainMenuExample.Button3TemplateProperty.SetDefault(_mainMenuExample, MainMenuExampleButton3);
                }
                return _mainMenuExample;
            }
        }

        private static Template _mainMenuExampleImage1;
        public static Template MainMenuExampleImage1
        {
            get
            {
#if UNITY_EDITOR
                if (_mainMenuExampleImage1 == null || _mainMenuExampleImage1.CurrentVersion != Template.Version)
#else
                if (_mainMenuExampleImage1 == null)
#endif
                {
                    _mainMenuExampleImage1 = new Template(ImageTemplates.Image);
#if UNITY_EDITOR
                    _mainMenuExampleImage1.Name = "MainMenuExampleImage1";
#endif
                    Delight.Image.SpriteProperty.SetDefault(_mainMenuExampleImage1, Assets.Sprites["MainMenuDemoBg"]);
                    Delight.Image.HeightProperty.SetDefault(_mainMenuExampleImage1, new ElementSize(480f, ElementSizeUnit.Pixels));
                    Delight.Image.PreserveAspectProperty.SetDefault(_mainMenuExampleImage1, true);
                }
                return _mainMenuExampleImage1;
            }
        }

        private static Template _mainMenuExampleLabel1;
        public static Template MainMenuExampleLabel1
        {
            get
            {
#if UNITY_EDITOR
                if (_mainMenuExampleLabel1 == null || _mainMenuExampleLabel1.CurrentVersion != Template.Version)
#else
                if (_mainMenuExampleLabel1 == null)
#endif
                {
                    _mainMenuExampleLabel1 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _mainMenuExampleLabel1.Name = "MainMenuExampleLabel1";
#endif
                    Delight.Label.FontColorProperty.SetDefault(_mainMenuExampleLabel1, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Label.FontSizeProperty.SetDefault(_mainMenuExampleLabel1, 40f);
                    Delight.Label.FontProperty.SetDefault(_mainMenuExampleLabel1, Assets.TMP_FontAssets["AveriaSansLibre-Bold SDF"]);
                    Delight.Label.AutoSizeProperty.SetDefault(_mainMenuExampleLabel1, Delight.AutoSize.Default);
                    Delight.Label.TextProperty.SetDefault(_mainMenuExampleLabel1, "Main Menu");
                    Delight.Label.OffsetProperty.SetDefault(_mainMenuExampleLabel1, new ElementMargin(new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(210f, ElementSizeUnit.Pixels)));
                }
                return _mainMenuExampleLabel1;
            }
        }

        private static Template _mainMenuExampleGroup1;
        public static Template MainMenuExampleGroup1
        {
            get
            {
#if UNITY_EDITOR
                if (_mainMenuExampleGroup1 == null || _mainMenuExampleGroup1.CurrentVersion != Template.Version)
#else
                if (_mainMenuExampleGroup1 == null)
#endif
                {
                    _mainMenuExampleGroup1 = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _mainMenuExampleGroup1.Name = "MainMenuExampleGroup1";
#endif
                    Delight.Group.SpacingProperty.SetDefault(_mainMenuExampleGroup1, new ElementSize(10f, ElementSizeUnit.Pixels));
                    Delight.Group.OffsetProperty.SetDefault(_mainMenuExampleGroup1, new ElementMargin(new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(25f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels)));
                }
                return _mainMenuExampleGroup1;
            }
        }

        private static Template _mainMenuExampleButton1;
        public static Template MainMenuExampleButton1
        {
            get
            {
#if UNITY_EDITOR
                if (_mainMenuExampleButton1 == null || _mainMenuExampleButton1.CurrentVersion != Template.Version)
#else
                if (_mainMenuExampleButton1 == null)
#endif
                {
                    _mainMenuExampleButton1 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _mainMenuExampleButton1.Name = "MainMenuExampleButton1";
#endif
                    Delight.Button.BackgroundSpriteProperty.SetDefault(_mainMenuExampleButton1, Assets.Sprites["MainMenuDemoButton"]);
                    Delight.Button.BackgroundSpriteProperty.SetStateDefault("Pressed", _mainMenuExampleButton1, Assets.Sprites["MainMenuDemoButtonPressed"]);
                    Delight.Button.BackgroundColorProperty.SetDefault(_mainMenuExampleButton1, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Button.BackgroundColorProperty.SetStateDefault("Highlighted", _mainMenuExampleButton1, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Button.BackgroundColorProperty.SetStateDefault("Pressed", _mainMenuExampleButton1, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Button.WidthProperty.SetDefault(_mainMenuExampleButton1, new ElementSize(218f, ElementSizeUnit.Pixels));
                    Delight.Button.HeightProperty.SetDefault(_mainMenuExampleButton1, new ElementSize(117f, ElementSizeUnit.Pixels));
                    Delight.Button.TextOffsetProperty.SetDefault(_mainMenuExampleButton1, new ElementMargin(new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(6f, ElementSizeUnit.Pixels)));
                    Delight.Button.LabelTemplateProperty.SetDefault(_mainMenuExampleButton1, MainMenuExampleButton1Label);
                }
                return _mainMenuExampleButton1;
            }
        }

        private static Template _mainMenuExampleButton1Label;
        public static Template MainMenuExampleButton1Label
        {
            get
            {
#if UNITY_EDITOR
                if (_mainMenuExampleButton1Label == null || _mainMenuExampleButton1Label.CurrentVersion != Template.Version)
#else
                if (_mainMenuExampleButton1Label == null)
#endif
                {
                    _mainMenuExampleButton1Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _mainMenuExampleButton1Label.Name = "MainMenuExampleButton1Label";
#endif
                    Delight.Label.FontSizeProperty.SetDefault(_mainMenuExampleButton1Label, 40f);
                    Delight.Label.FontProperty.SetDefault(_mainMenuExampleButton1Label, Assets.TMP_FontAssets["AveriaSansLibre-Bold SDF"]);
                    Delight.Label.FontColorProperty.SetDefault(_mainMenuExampleButton1Label, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Label.FontColorProperty.SetStateDefault("Highlighted", _mainMenuExampleButton1Label, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Label.FontColorProperty.SetStateDefault("Pressed", _mainMenuExampleButton1Label, new UnityEngine.Color(0.8f, 0.8f, 0.8f, 1f));
                    Delight.Label.TextProperty.SetDefault(_mainMenuExampleButton1Label, "Play");
                }
                return _mainMenuExampleButton1Label;
            }
        }

        private static Template _mainMenuExampleButton2;
        public static Template MainMenuExampleButton2
        {
            get
            {
#if UNITY_EDITOR
                if (_mainMenuExampleButton2 == null || _mainMenuExampleButton2.CurrentVersion != Template.Version)
#else
                if (_mainMenuExampleButton2 == null)
#endif
                {
                    _mainMenuExampleButton2 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _mainMenuExampleButton2.Name = "MainMenuExampleButton2";
#endif
                    Delight.Button.BackgroundSpriteProperty.SetDefault(_mainMenuExampleButton2, Assets.Sprites["MainMenuDemoButton"]);
                    Delight.Button.BackgroundSpriteProperty.SetStateDefault("Pressed", _mainMenuExampleButton2, Assets.Sprites["MainMenuDemoButtonPressed"]);
                    Delight.Button.BackgroundColorProperty.SetDefault(_mainMenuExampleButton2, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Button.BackgroundColorProperty.SetStateDefault("Highlighted", _mainMenuExampleButton2, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Button.BackgroundColorProperty.SetStateDefault("Pressed", _mainMenuExampleButton2, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Button.WidthProperty.SetDefault(_mainMenuExampleButton2, new ElementSize(218f, ElementSizeUnit.Pixels));
                    Delight.Button.HeightProperty.SetDefault(_mainMenuExampleButton2, new ElementSize(117f, ElementSizeUnit.Pixels));
                    Delight.Button.TextOffsetProperty.SetDefault(_mainMenuExampleButton2, new ElementMargin(new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(6f, ElementSizeUnit.Pixels)));
                    Delight.Button.LabelTemplateProperty.SetDefault(_mainMenuExampleButton2, MainMenuExampleButton2Label);
                }
                return _mainMenuExampleButton2;
            }
        }

        private static Template _mainMenuExampleButton2Label;
        public static Template MainMenuExampleButton2Label
        {
            get
            {
#if UNITY_EDITOR
                if (_mainMenuExampleButton2Label == null || _mainMenuExampleButton2Label.CurrentVersion != Template.Version)
#else
                if (_mainMenuExampleButton2Label == null)
#endif
                {
                    _mainMenuExampleButton2Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _mainMenuExampleButton2Label.Name = "MainMenuExampleButton2Label";
#endif
                    Delight.Label.FontSizeProperty.SetDefault(_mainMenuExampleButton2Label, 40f);
                    Delight.Label.FontProperty.SetDefault(_mainMenuExampleButton2Label, Assets.TMP_FontAssets["AveriaSansLibre-Bold SDF"]);
                    Delight.Label.FontColorProperty.SetDefault(_mainMenuExampleButton2Label, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Label.FontColorProperty.SetStateDefault("Highlighted", _mainMenuExampleButton2Label, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Label.FontColorProperty.SetStateDefault("Pressed", _mainMenuExampleButton2Label, new UnityEngine.Color(0.8f, 0.8f, 0.8f, 1f));
                    Delight.Label.TextProperty.SetDefault(_mainMenuExampleButton2Label, "Options");
                }
                return _mainMenuExampleButton2Label;
            }
        }

        private static Template _mainMenuExampleButton3;
        public static Template MainMenuExampleButton3
        {
            get
            {
#if UNITY_EDITOR
                if (_mainMenuExampleButton3 == null || _mainMenuExampleButton3.CurrentVersion != Template.Version)
#else
                if (_mainMenuExampleButton3 == null)
#endif
                {
                    _mainMenuExampleButton3 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _mainMenuExampleButton3.Name = "MainMenuExampleButton3";
#endif
                    Delight.Button.BackgroundSpriteProperty.SetDefault(_mainMenuExampleButton3, Assets.Sprites["MainMenuDemoButton"]);
                    Delight.Button.BackgroundSpriteProperty.SetStateDefault("Pressed", _mainMenuExampleButton3, Assets.Sprites["MainMenuDemoButtonPressed"]);
                    Delight.Button.BackgroundColorProperty.SetDefault(_mainMenuExampleButton3, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Button.BackgroundColorProperty.SetStateDefault("Highlighted", _mainMenuExampleButton3, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Button.BackgroundColorProperty.SetStateDefault("Pressed", _mainMenuExampleButton3, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Button.WidthProperty.SetDefault(_mainMenuExampleButton3, new ElementSize(218f, ElementSizeUnit.Pixels));
                    Delight.Button.HeightProperty.SetDefault(_mainMenuExampleButton3, new ElementSize(117f, ElementSizeUnit.Pixels));
                    Delight.Button.TextOffsetProperty.SetDefault(_mainMenuExampleButton3, new ElementMargin(new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(6f, ElementSizeUnit.Pixels)));
                    Delight.Button.LabelTemplateProperty.SetDefault(_mainMenuExampleButton3, MainMenuExampleButton3Label);
                }
                return _mainMenuExampleButton3;
            }
        }

        private static Template _mainMenuExampleButton3Label;
        public static Template MainMenuExampleButton3Label
        {
            get
            {
#if UNITY_EDITOR
                if (_mainMenuExampleButton3Label == null || _mainMenuExampleButton3Label.CurrentVersion != Template.Version)
#else
                if (_mainMenuExampleButton3Label == null)
#endif
                {
                    _mainMenuExampleButton3Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _mainMenuExampleButton3Label.Name = "MainMenuExampleButton3Label";
#endif
                    Delight.Label.FontSizeProperty.SetDefault(_mainMenuExampleButton3Label, 40f);
                    Delight.Label.FontProperty.SetDefault(_mainMenuExampleButton3Label, Assets.TMP_FontAssets["AveriaSansLibre-Bold SDF"]);
                    Delight.Label.FontColorProperty.SetDefault(_mainMenuExampleButton3Label, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Label.FontColorProperty.SetStateDefault("Highlighted", _mainMenuExampleButton3Label, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Label.FontColorProperty.SetStateDefault("Pressed", _mainMenuExampleButton3Label, new UnityEngine.Color(0.8f, 0.8f, 0.8f, 1f));
                    Delight.Label.TextProperty.SetDefault(_mainMenuExampleButton3Label, "Quit");
                }
                return _mainMenuExampleButton3Label;
            }
        }

        #endregion
    }

    #endregion
}
