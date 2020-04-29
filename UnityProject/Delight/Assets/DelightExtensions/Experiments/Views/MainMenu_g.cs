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

        public MainMenu(View parent, View layoutParent = null, string id = null, Template template = null, bool deferInitialization = false) :
            base(parent, layoutParent, id, template ?? MainMenuTemplates.Default, deferInitialization)
        {
            if (deferInitialization)
                return;

            // constructing Region (Region1)
            Region1 = new Region(this, this, "Region1", Region1Template);
            Group1 = new Group(this, Region1.Content, "Group1", Group1Template);
            Button1 = new Button(this, Group1.Content, "Button1", Button1Template);
            Button1.Click.RegisterHandler(this, "Play");
            Button2 = new Button(this, Group1.Content, "Button2", Button2Template);
            Button2.Click.RegisterHandler(this, "ShowOptions");
            Button3 = new Button(this, Group1.Content, "Button3", Button3Template);
            Button3.Click.RegisterHandler(this, "Quit");

            // constructing Region (Region2)
            Region2 = new Region(this, this, "Region2", Region2Template);
            SubmenuSwitcher = new ViewSwitcher(this, Region2.Content, "SubmenuSwitcher", SubmenuSwitcherTemplate);
            LevelSelect = new LevelSelect(this, SubmenuSwitcher.Content, "LevelSelect", LevelSelectTemplate);
            Options = new Options(this, SubmenuSwitcher.Content, "Options", OptionsTemplate);
            this.AfterInitializeInternal();
        }

        public MainMenu() : this(null)
        {
        }

        static MainMenu()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(MainMenuTemplates.Default, dependencyProperties);

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
            dependencyProperties.Add(Region2Property);
            dependencyProperties.Add(Region2TemplateProperty);
            dependencyProperties.Add(SubmenuSwitcherProperty);
            dependencyProperties.Add(SubmenuSwitcherTemplateProperty);
            dependencyProperties.Add(LevelSelectProperty);
            dependencyProperties.Add(LevelSelectTemplateProperty);
            dependencyProperties.Add(OptionsProperty);
            dependencyProperties.Add(OptionsTemplateProperty);
        }

        #endregion

        #region Properties

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

        public readonly static DependencyProperty<ViewSwitcher> SubmenuSwitcherProperty = new DependencyProperty<ViewSwitcher>("SubmenuSwitcher");
        public ViewSwitcher SubmenuSwitcher
        {
            get { return SubmenuSwitcherProperty.GetValue(this); }
            set { SubmenuSwitcherProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> SubmenuSwitcherTemplateProperty = new DependencyProperty<Template>("SubmenuSwitcherTemplate");
        public Template SubmenuSwitcherTemplate
        {
            get { return SubmenuSwitcherTemplateProperty.GetValue(this); }
            set { SubmenuSwitcherTemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<LevelSelect> LevelSelectProperty = new DependencyProperty<LevelSelect>("LevelSelect");
        public LevelSelect LevelSelect
        {
            get { return LevelSelectProperty.GetValue(this); }
            set { LevelSelectProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> LevelSelectTemplateProperty = new DependencyProperty<Template>("LevelSelectTemplate");
        public Template LevelSelectTemplate
        {
            get { return LevelSelectTemplateProperty.GetValue(this); }
            set { LevelSelectTemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Options> OptionsProperty = new DependencyProperty<Options>("Options");
        public Options Options
        {
            get { return OptionsProperty.GetValue(this); }
            set { OptionsProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> OptionsTemplateProperty = new DependencyProperty<Template>("OptionsTemplate");
        public Template OptionsTemplate
        {
            get { return OptionsTemplateProperty.GetValue(this); }
            set { OptionsTemplateProperty.SetValue(this, value); }
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
                    Delight.MainMenu.Region1TemplateProperty.SetDefault(_mainMenu, MainMenuRegion1);
                    Delight.MainMenu.Group1TemplateProperty.SetDefault(_mainMenu, MainMenuGroup1);
                    Delight.MainMenu.Button1TemplateProperty.SetDefault(_mainMenu, MainMenuButton1);
                    Delight.MainMenu.Button2TemplateProperty.SetDefault(_mainMenu, MainMenuButton2);
                    Delight.MainMenu.Button3TemplateProperty.SetDefault(_mainMenu, MainMenuButton3);
                    Delight.MainMenu.Region2TemplateProperty.SetDefault(_mainMenu, MainMenuRegion2);
                    Delight.MainMenu.SubmenuSwitcherTemplateProperty.SetDefault(_mainMenu, MainMenuSubmenuSwitcher);
                    Delight.MainMenu.LevelSelectTemplateProperty.SetDefault(_mainMenu, MainMenuLevelSelect);
                    Delight.MainMenu.OptionsTemplateProperty.SetDefault(_mainMenu, MainMenuOptions);
                }
                return _mainMenu;
            }
        }

        private static Template _mainMenuRegion1;
        public static Template MainMenuRegion1
        {
            get
            {
#if UNITY_EDITOR
                if (_mainMenuRegion1 == null || _mainMenuRegion1.CurrentVersion != Template.Version)
#else
                if (_mainMenuRegion1 == null)
#endif
                {
                    _mainMenuRegion1 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _mainMenuRegion1.Name = "MainMenuRegion1";
#endif
                    Delight.Region.WidthProperty.SetDefault(_mainMenuRegion1, new ElementSize(0.25f, ElementSizeUnit.Percents));
                    Delight.Region.AlignmentProperty.SetDefault(_mainMenuRegion1, Delight.ElementAlignment.Left);
                    Delight.Region.MarginProperty.SetDefault(_mainMenuRegion1, new ElementMargin(new ElementSize(30f, ElementSizeUnit.Pixels), new ElementSize(30f, ElementSizeUnit.Pixels), new ElementSize(15f, ElementSizeUnit.Pixels), new ElementSize(30f, ElementSizeUnit.Pixels)));
                    Delight.Region.BackgroundColorProperty.SetDefault(_mainMenuRegion1, new UnityEngine.Color(0.9372549f, 0.4392157f, 0.4156863f, 1f));
                }
                return _mainMenuRegion1;
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
                    Delight.Group.AlignmentProperty.SetDefault(_mainMenuGroup1, Delight.ElementAlignment.Top);
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
                    Delight.Button.WidthProperty.SetDefault(_mainMenuButton1, new ElementSize(140f, ElementSizeUnit.Pixels));
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
                    Delight.Button.WidthProperty.SetDefault(_mainMenuButton2, new ElementSize(140f, ElementSizeUnit.Pixels));
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
                    Delight.Button.WidthProperty.SetDefault(_mainMenuButton3, new ElementSize(140f, ElementSizeUnit.Pixels));
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

        private static Template _mainMenuRegion2;
        public static Template MainMenuRegion2
        {
            get
            {
#if UNITY_EDITOR
                if (_mainMenuRegion2 == null || _mainMenuRegion2.CurrentVersion != Template.Version)
#else
                if (_mainMenuRegion2 == null)
#endif
                {
                    _mainMenuRegion2 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _mainMenuRegion2.Name = "MainMenuRegion2";
#endif
                    Delight.Region.WidthProperty.SetDefault(_mainMenuRegion2, new ElementSize(0.75f, ElementSizeUnit.Percents));
                    Delight.Region.AlignmentProperty.SetDefault(_mainMenuRegion2, Delight.ElementAlignment.Right);
                    Delight.Region.MarginProperty.SetDefault(_mainMenuRegion2, new ElementMargin(new ElementSize(15f, ElementSizeUnit.Pixels), new ElementSize(30f, ElementSizeUnit.Pixels), new ElementSize(30f, ElementSizeUnit.Pixels), new ElementSize(30f, ElementSizeUnit.Pixels)));
                    Delight.Region.BackgroundColorProperty.SetDefault(_mainMenuRegion2, new UnityEngine.Color(0.5803922f, 0.5803922f, 0.5803922f, 1f));
                }
                return _mainMenuRegion2;
            }
        }

        private static Template _mainMenuSubmenuSwitcher;
        public static Template MainMenuSubmenuSwitcher
        {
            get
            {
#if UNITY_EDITOR
                if (_mainMenuSubmenuSwitcher == null || _mainMenuSubmenuSwitcher.CurrentVersion != Template.Version)
#else
                if (_mainMenuSubmenuSwitcher == null)
#endif
                {
                    _mainMenuSubmenuSwitcher = new Template(ViewSwitcherTemplates.ViewSwitcher);
#if UNITY_EDITOR
                    _mainMenuSubmenuSwitcher.Name = "MainMenuSubmenuSwitcher";
#endif
                    Delight.ViewSwitcher.ShowFirstByDefaultProperty.SetDefault(_mainMenuSubmenuSwitcher, false);
                }
                return _mainMenuSubmenuSwitcher;
            }
        }

        private static Template _mainMenuLevelSelect;
        public static Template MainMenuLevelSelect
        {
            get
            {
#if UNITY_EDITOR
                if (_mainMenuLevelSelect == null || _mainMenuLevelSelect.CurrentVersion != Template.Version)
#else
                if (_mainMenuLevelSelect == null)
#endif
                {
                    _mainMenuLevelSelect = new Template(LevelSelectTemplates.LevelSelect);
#if UNITY_EDITOR
                    _mainMenuLevelSelect.Name = "MainMenuLevelSelect";
#endif
                }
                return _mainMenuLevelSelect;
            }
        }

        private static Template _mainMenuOptions;
        public static Template MainMenuOptions
        {
            get
            {
#if UNITY_EDITOR
                if (_mainMenuOptions == null || _mainMenuOptions.CurrentVersion != Template.Version)
#else
                if (_mainMenuOptions == null)
#endif
                {
                    _mainMenuOptions = new Template(OptionsTemplates.Options);
#if UNITY_EDITOR
                    _mainMenuOptions.Name = "MainMenuOptions";
#endif
                }
                return _mainMenuOptions;
            }
        }

        #endregion
    }

    #endregion
}
