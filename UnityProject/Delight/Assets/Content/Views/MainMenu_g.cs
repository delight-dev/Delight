// Internal view logic generated from "MainMenu.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class MainMenu : UIView
    {
        #region Constructors

        public MainMenu(View parent, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :
            base(parent, layoutParent, id, template ?? MainMenuTemplates.Default, initializer)
        {
            // constructing Group (Group1)
            Group1 = new Group(this, this, "Group1", Group1Template);
            Button1 = new Button(this, Group1.Content, "Button1", Button1Template);
            Button1.Click.RegisterHandler(this, "Play");
            Button2 = new Button(this, Group1.Content, "Button2", Button2Template);
            Button2.Click.RegisterHandler(this, "Options");
            Button3 = new Button(this, Group1.Content, "Button3", Button3Template);
            Button3.Click.RegisterHandler(this, "Quit");
            Button3.MouseDown.RegisterHandler(this, "QuitMouseDown");
            this.AfterInitializeInternal();
        }

        public MainMenu() : this(null)
        {
        }

        static MainMenu()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(MainMenuTemplates.Default, dependencyProperties);

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

    public static class MainMenuTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return MainMenu;
            }
        }

        private static Template _mainMenu;
        public static Template MainMenu
        {
            get
            {
#if UNITY_EDITOR
                if (_mainMenu == null || _mainMenu.CurrentVersion != Template.Version)
#else
                if (_mainMenu == null)
#endif
                {
                    _mainMenu = new Template(UIViewTemplates.UIView);
#if UNITY_EDITOR
                    _mainMenu.Name = "MainMenu";
#endif
                    Delight.MainMenu.Group1TemplateProperty.SetDefault(_mainMenu, MainMenuGroup1);
                    Delight.MainMenu.Button1TemplateProperty.SetDefault(_mainMenu, MainMenuButton1);
                    Delight.MainMenu.Button2TemplateProperty.SetDefault(_mainMenu, MainMenuButton2);
                    Delight.MainMenu.Button3TemplateProperty.SetDefault(_mainMenu, MainMenuButton3);
                }
                return _mainMenu;
            }
        }

        private static Template _mainMenuGroup1;
        public static Template MainMenuGroup1
        {
            get
            {
#if UNITY_EDITOR
                if (_mainMenuGroup1 == null || _mainMenuGroup1.CurrentVersion != Template.Version)
#else
                if (_mainMenuGroup1 == null)
#endif
                {
                    _mainMenuGroup1 = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _mainMenuGroup1.Name = "MainMenuGroup1";
#endif
                    Delight.Group.SpacingProperty.SetDefault(_mainMenuGroup1, new ElementSize(10f, ElementSizeUnit.Pixels));
                }
                return _mainMenuGroup1;
            }
        }

        private static Template _mainMenuButton1;
        public static Template MainMenuButton1
        {
            get
            {
#if UNITY_EDITOR
                if (_mainMenuButton1 == null || _mainMenuButton1.CurrentVersion != Template.Version)
#else
                if (_mainMenuButton1 == null)
#endif
                {
                    _mainMenuButton1 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _mainMenuButton1.Name = "MainMenuButton1";
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_mainMenuButton1, MainMenuButton1Label);
                }
                return _mainMenuButton1;
            }
        }

        private static Template _mainMenuButton1Label;
        public static Template MainMenuButton1Label
        {
            get
            {
#if UNITY_EDITOR
                if (_mainMenuButton1Label == null || _mainMenuButton1Label.CurrentVersion != Template.Version)
#else
                if (_mainMenuButton1Label == null)
#endif
                {
                    _mainMenuButton1Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _mainMenuButton1Label.Name = "MainMenuButton1Label";
#endif
                    Delight.Label.TextProperty.SetDefault(_mainMenuButton1Label, "Play");
                }
                return _mainMenuButton1Label;
            }
        }

        private static Template _mainMenuButton2;
        public static Template MainMenuButton2
        {
            get
            {
#if UNITY_EDITOR
                if (_mainMenuButton2 == null || _mainMenuButton2.CurrentVersion != Template.Version)
#else
                if (_mainMenuButton2 == null)
#endif
                {
                    _mainMenuButton2 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _mainMenuButton2.Name = "MainMenuButton2";
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_mainMenuButton2, MainMenuButton2Label);
                }
                return _mainMenuButton2;
            }
        }

        private static Template _mainMenuButton2Label;
        public static Template MainMenuButton2Label
        {
            get
            {
#if UNITY_EDITOR
                if (_mainMenuButton2Label == null || _mainMenuButton2Label.CurrentVersion != Template.Version)
#else
                if (_mainMenuButton2Label == null)
#endif
                {
                    _mainMenuButton2Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _mainMenuButton2Label.Name = "MainMenuButton2Label";
#endif
                    Delight.Label.TextProperty.SetDefault(_mainMenuButton2Label, "Options");
                }
                return _mainMenuButton2Label;
            }
        }

        private static Template _mainMenuButton3;
        public static Template MainMenuButton3
        {
            get
            {
#if UNITY_EDITOR
                if (_mainMenuButton3 == null || _mainMenuButton3.CurrentVersion != Template.Version)
#else
                if (_mainMenuButton3 == null)
#endif
                {
                    _mainMenuButton3 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _mainMenuButton3.Name = "MainMenuButton3";
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_mainMenuButton3, MainMenuButton3Label);
                }
                return _mainMenuButton3;
            }
        }

        private static Template _mainMenuButton3Label;
        public static Template MainMenuButton3Label
        {
            get
            {
#if UNITY_EDITOR
                if (_mainMenuButton3Label == null || _mainMenuButton3Label.CurrentVersion != Template.Version)
#else
                if (_mainMenuButton3Label == null)
#endif
                {
                    _mainMenuButton3Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _mainMenuButton3Label.Name = "MainMenuButton3Label";
#endif
                    Delight.Label.TextProperty.SetDefault(_mainMenuButton3Label, "Quit");
                }
                return _mainMenuButton3Label;
            }
        }

        #endregion
    }

    #endregion
}
