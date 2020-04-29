// Internal view logic generated from "MainMenuScene.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class MainMenuScene : UIView
    {
        #region Constructors

        public MainMenuScene(View parent, View layoutParent = null, string id = null, Template template = null, bool deferInitialization = false) :
            base(parent, layoutParent, id, template ?? MainMenuSceneTemplates.Default, deferInitialization)
        {
            if (deferInitialization)
                return;

            // constructing MainMenu (MainMenu1)
            MainMenu1 = new MainMenu(this, this, "MainMenu1", MainMenu1Template);
            this.AfterInitializeInternal();
        }

        public MainMenuScene() : this(null)
        {
        }

        static MainMenuScene()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(MainMenuSceneTemplates.Default, dependencyProperties);

            dependencyProperties.Add(MainMenu1Property);
            dependencyProperties.Add(MainMenu1TemplateProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<MainMenu> MainMenu1Property = new DependencyProperty<MainMenu>("MainMenu1");
        public MainMenu MainMenu1
        {
            get { return MainMenu1Property.GetValue(this); }
            set { MainMenu1Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> MainMenu1TemplateProperty = new DependencyProperty<Template>("MainMenu1Template");
        public Template MainMenu1Template
        {
            get { return MainMenu1TemplateProperty.GetValue(this); }
            set { MainMenu1TemplateProperty.SetValue(this, value); }
        }

        #endregion
    }

    #region Data Templates

    public static class MainMenuSceneTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return MainMenuScene;
            }
        }

        private static Template _mainMenuScene;
        public static Template MainMenuScene
        {
            get
            {
#if UNITY_EDITOR
                if (_mainMenuScene == null || _mainMenuScene.CurrentVersion != Template.Version)
#else
                if (_mainMenuScene == null)
#endif
                {
                    _mainMenuScene = new Template(UIViewTemplates.UIView);
#if UNITY_EDITOR
                    _mainMenuScene.Name = "MainMenuScene";
#endif
                    Delight.MainMenuScene.MainMenu1TemplateProperty.SetDefault(_mainMenuScene, MainMenuSceneMainMenu1);
                }
                return _mainMenuScene;
            }
        }

        private static Template _mainMenuSceneMainMenu1;
        public static Template MainMenuSceneMainMenu1
        {
            get
            {
#if UNITY_EDITOR
                if (_mainMenuSceneMainMenu1 == null || _mainMenuSceneMainMenu1.CurrentVersion != Template.Version)
#else
                if (_mainMenuSceneMainMenu1 == null)
#endif
                {
                    _mainMenuSceneMainMenu1 = new Template(MainMenuTemplates.MainMenu);
#if UNITY_EDITOR
                    _mainMenuSceneMainMenu1.Name = "MainMenuSceneMainMenu1";
#endif
                    Delight.MainMenu.Region1TemplateProperty.SetDefault(_mainMenuSceneMainMenu1, MainMenuSceneMainMenu1Region1);
                    Delight.MainMenu.Group1TemplateProperty.SetDefault(_mainMenuSceneMainMenu1, MainMenuSceneMainMenu1Group1);
                    Delight.MainMenu.Button1TemplateProperty.SetDefault(_mainMenuSceneMainMenu1, MainMenuSceneMainMenu1Button1);
                    Delight.MainMenu.Button2TemplateProperty.SetDefault(_mainMenuSceneMainMenu1, MainMenuSceneMainMenu1Button2);
                    Delight.MainMenu.Button3TemplateProperty.SetDefault(_mainMenuSceneMainMenu1, MainMenuSceneMainMenu1Button3);
                    Delight.MainMenu.Region2TemplateProperty.SetDefault(_mainMenuSceneMainMenu1, MainMenuSceneMainMenu1Region2);
                    Delight.MainMenu.SubmenuSwitcherTemplateProperty.SetDefault(_mainMenuSceneMainMenu1, MainMenuSceneMainMenu1SubmenuSwitcher);
                    Delight.MainMenu.LevelSelectTemplateProperty.SetDefault(_mainMenuSceneMainMenu1, MainMenuSceneMainMenu1LevelSelect);
                    Delight.MainMenu.OptionsTemplateProperty.SetDefault(_mainMenuSceneMainMenu1, MainMenuSceneMainMenu1Options);
                }
                return _mainMenuSceneMainMenu1;
            }
        }

        private static Template _mainMenuSceneMainMenu1Region1;
        public static Template MainMenuSceneMainMenu1Region1
        {
            get
            {
#if UNITY_EDITOR
                if (_mainMenuSceneMainMenu1Region1 == null || _mainMenuSceneMainMenu1Region1.CurrentVersion != Template.Version)
#else
                if (_mainMenuSceneMainMenu1Region1 == null)
#endif
                {
                    _mainMenuSceneMainMenu1Region1 = new Template(MainMenuTemplates.MainMenuRegion1);
#if UNITY_EDITOR
                    _mainMenuSceneMainMenu1Region1.Name = "MainMenuSceneMainMenu1Region1";
#endif
                }
                return _mainMenuSceneMainMenu1Region1;
            }
        }

        private static Template _mainMenuSceneMainMenu1Group1;
        public static Template MainMenuSceneMainMenu1Group1
        {
            get
            {
#if UNITY_EDITOR
                if (_mainMenuSceneMainMenu1Group1 == null || _mainMenuSceneMainMenu1Group1.CurrentVersion != Template.Version)
#else
                if (_mainMenuSceneMainMenu1Group1 == null)
#endif
                {
                    _mainMenuSceneMainMenu1Group1 = new Template(MainMenuTemplates.MainMenuGroup1);
#if UNITY_EDITOR
                    _mainMenuSceneMainMenu1Group1.Name = "MainMenuSceneMainMenu1Group1";
#endif
                }
                return _mainMenuSceneMainMenu1Group1;
            }
        }

        private static Template _mainMenuSceneMainMenu1Button1;
        public static Template MainMenuSceneMainMenu1Button1
        {
            get
            {
#if UNITY_EDITOR
                if (_mainMenuSceneMainMenu1Button1 == null || _mainMenuSceneMainMenu1Button1.CurrentVersion != Template.Version)
#else
                if (_mainMenuSceneMainMenu1Button1 == null)
#endif
                {
                    _mainMenuSceneMainMenu1Button1 = new Template(MainMenuTemplates.MainMenuButton1);
#if UNITY_EDITOR
                    _mainMenuSceneMainMenu1Button1.Name = "MainMenuSceneMainMenu1Button1";
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_mainMenuSceneMainMenu1Button1, MainMenuSceneMainMenu1Button1Label);
                }
                return _mainMenuSceneMainMenu1Button1;
            }
        }

        private static Template _mainMenuSceneMainMenu1Button1Label;
        public static Template MainMenuSceneMainMenu1Button1Label
        {
            get
            {
#if UNITY_EDITOR
                if (_mainMenuSceneMainMenu1Button1Label == null || _mainMenuSceneMainMenu1Button1Label.CurrentVersion != Template.Version)
#else
                if (_mainMenuSceneMainMenu1Button1Label == null)
#endif
                {
                    _mainMenuSceneMainMenu1Button1Label = new Template(MainMenuTemplates.MainMenuButton1Label);
#if UNITY_EDITOR
                    _mainMenuSceneMainMenu1Button1Label.Name = "MainMenuSceneMainMenu1Button1Label";
#endif
                }
                return _mainMenuSceneMainMenu1Button1Label;
            }
        }

        private static Template _mainMenuSceneMainMenu1Button2;
        public static Template MainMenuSceneMainMenu1Button2
        {
            get
            {
#if UNITY_EDITOR
                if (_mainMenuSceneMainMenu1Button2 == null || _mainMenuSceneMainMenu1Button2.CurrentVersion != Template.Version)
#else
                if (_mainMenuSceneMainMenu1Button2 == null)
#endif
                {
                    _mainMenuSceneMainMenu1Button2 = new Template(MainMenuTemplates.MainMenuButton2);
#if UNITY_EDITOR
                    _mainMenuSceneMainMenu1Button2.Name = "MainMenuSceneMainMenu1Button2";
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_mainMenuSceneMainMenu1Button2, MainMenuSceneMainMenu1Button2Label);
                }
                return _mainMenuSceneMainMenu1Button2;
            }
        }

        private static Template _mainMenuSceneMainMenu1Button2Label;
        public static Template MainMenuSceneMainMenu1Button2Label
        {
            get
            {
#if UNITY_EDITOR
                if (_mainMenuSceneMainMenu1Button2Label == null || _mainMenuSceneMainMenu1Button2Label.CurrentVersion != Template.Version)
#else
                if (_mainMenuSceneMainMenu1Button2Label == null)
#endif
                {
                    _mainMenuSceneMainMenu1Button2Label = new Template(MainMenuTemplates.MainMenuButton2Label);
#if UNITY_EDITOR
                    _mainMenuSceneMainMenu1Button2Label.Name = "MainMenuSceneMainMenu1Button2Label";
#endif
                }
                return _mainMenuSceneMainMenu1Button2Label;
            }
        }

        private static Template _mainMenuSceneMainMenu1Button3;
        public static Template MainMenuSceneMainMenu1Button3
        {
            get
            {
#if UNITY_EDITOR
                if (_mainMenuSceneMainMenu1Button3 == null || _mainMenuSceneMainMenu1Button3.CurrentVersion != Template.Version)
#else
                if (_mainMenuSceneMainMenu1Button3 == null)
#endif
                {
                    _mainMenuSceneMainMenu1Button3 = new Template(MainMenuTemplates.MainMenuButton3);
#if UNITY_EDITOR
                    _mainMenuSceneMainMenu1Button3.Name = "MainMenuSceneMainMenu1Button3";
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_mainMenuSceneMainMenu1Button3, MainMenuSceneMainMenu1Button3Label);
                }
                return _mainMenuSceneMainMenu1Button3;
            }
        }

        private static Template _mainMenuSceneMainMenu1Button3Label;
        public static Template MainMenuSceneMainMenu1Button3Label
        {
            get
            {
#if UNITY_EDITOR
                if (_mainMenuSceneMainMenu1Button3Label == null || _mainMenuSceneMainMenu1Button3Label.CurrentVersion != Template.Version)
#else
                if (_mainMenuSceneMainMenu1Button3Label == null)
#endif
                {
                    _mainMenuSceneMainMenu1Button3Label = new Template(MainMenuTemplates.MainMenuButton3Label);
#if UNITY_EDITOR
                    _mainMenuSceneMainMenu1Button3Label.Name = "MainMenuSceneMainMenu1Button3Label";
#endif
                }
                return _mainMenuSceneMainMenu1Button3Label;
            }
        }

        private static Template _mainMenuSceneMainMenu1Region2;
        public static Template MainMenuSceneMainMenu1Region2
        {
            get
            {
#if UNITY_EDITOR
                if (_mainMenuSceneMainMenu1Region2 == null || _mainMenuSceneMainMenu1Region2.CurrentVersion != Template.Version)
#else
                if (_mainMenuSceneMainMenu1Region2 == null)
#endif
                {
                    _mainMenuSceneMainMenu1Region2 = new Template(MainMenuTemplates.MainMenuRegion2);
#if UNITY_EDITOR
                    _mainMenuSceneMainMenu1Region2.Name = "MainMenuSceneMainMenu1Region2";
#endif
                }
                return _mainMenuSceneMainMenu1Region2;
            }
        }

        private static Template _mainMenuSceneMainMenu1SubmenuSwitcher;
        public static Template MainMenuSceneMainMenu1SubmenuSwitcher
        {
            get
            {
#if UNITY_EDITOR
                if (_mainMenuSceneMainMenu1SubmenuSwitcher == null || _mainMenuSceneMainMenu1SubmenuSwitcher.CurrentVersion != Template.Version)
#else
                if (_mainMenuSceneMainMenu1SubmenuSwitcher == null)
#endif
                {
                    _mainMenuSceneMainMenu1SubmenuSwitcher = new Template(MainMenuTemplates.MainMenuSubmenuSwitcher);
#if UNITY_EDITOR
                    _mainMenuSceneMainMenu1SubmenuSwitcher.Name = "MainMenuSceneMainMenu1SubmenuSwitcher";
#endif
                }
                return _mainMenuSceneMainMenu1SubmenuSwitcher;
            }
        }

        private static Template _mainMenuSceneMainMenu1LevelSelect;
        public static Template MainMenuSceneMainMenu1LevelSelect
        {
            get
            {
#if UNITY_EDITOR
                if (_mainMenuSceneMainMenu1LevelSelect == null || _mainMenuSceneMainMenu1LevelSelect.CurrentVersion != Template.Version)
#else
                if (_mainMenuSceneMainMenu1LevelSelect == null)
#endif
                {
                    _mainMenuSceneMainMenu1LevelSelect = new Template(MainMenuTemplates.MainMenuLevelSelect);
#if UNITY_EDITOR
                    _mainMenuSceneMainMenu1LevelSelect.Name = "MainMenuSceneMainMenu1LevelSelect";
#endif
                }
                return _mainMenuSceneMainMenu1LevelSelect;
            }
        }

        private static Template _mainMenuSceneMainMenu1Options;
        public static Template MainMenuSceneMainMenu1Options
        {
            get
            {
#if UNITY_EDITOR
                if (_mainMenuSceneMainMenu1Options == null || _mainMenuSceneMainMenu1Options.CurrentVersion != Template.Version)
#else
                if (_mainMenuSceneMainMenu1Options == null)
#endif
                {
                    _mainMenuSceneMainMenu1Options = new Template(MainMenuTemplates.MainMenuOptions);
#if UNITY_EDITOR
                    _mainMenuSceneMainMenu1Options.Name = "MainMenuSceneMainMenu1Options";
#endif
                }
                return _mainMenuSceneMainMenu1Options;
            }
        }

        #endregion
    }

    #endregion
}
