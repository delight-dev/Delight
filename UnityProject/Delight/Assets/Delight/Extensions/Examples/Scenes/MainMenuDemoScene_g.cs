// Internal view logic generated from "MainMenuDemoScene.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class MainMenuDemoScene : UIView
    {
        #region Constructors

        public MainMenuDemoScene(View parent, View layoutParent = null, string id = null, Template template = null, bool deferInitialization = false) :
            base(parent, layoutParent, id, template ?? MainMenuDemoSceneTemplates.Default, deferInitialization)
        {
            if (deferInitialization)
                return;

            // constructing ViewSwitcher (SubmenuSwitcher)
            SubmenuSwitcher = new ViewSwitcher(this, this, "SubmenuSwitcher", SubmenuSwitcherTemplate);
            MainMenuWindow = new MainMenuExample(this, SubmenuSwitcher.Content, "MainMenuWindow", MainMenuWindowTemplate);
            MainMenuWindow.Play.RegisterHandler(this, "MainMenuPlay");
            LevelSelectWindow = new LevelSelectExample(this, SubmenuSwitcher.Content, "LevelSelectWindow", LevelSelectWindowTemplate);
            LevelSelectWindow.NavigateBack.RegisterHandler(this, "LevelSelectNavigateBack");
            this.AfterInitializeInternal();
        }

        public MainMenuDemoScene() : this(null)
        {
        }

        static MainMenuDemoScene()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(MainMenuDemoSceneTemplates.Default, dependencyProperties);

            dependencyProperties.Add(SubmenuSwitcherProperty);
            dependencyProperties.Add(SubmenuSwitcherTemplateProperty);
            dependencyProperties.Add(MainMenuWindowProperty);
            dependencyProperties.Add(MainMenuWindowTemplateProperty);
            dependencyProperties.Add(LevelSelectWindowProperty);
            dependencyProperties.Add(LevelSelectWindowTemplateProperty);
        }

        #endregion

        #region Properties

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

        public readonly static DependencyProperty<MainMenuExample> MainMenuWindowProperty = new DependencyProperty<MainMenuExample>("MainMenuWindow");
        public MainMenuExample MainMenuWindow
        {
            get { return MainMenuWindowProperty.GetValue(this); }
            set { MainMenuWindowProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> MainMenuWindowTemplateProperty = new DependencyProperty<Template>("MainMenuWindowTemplate");
        public Template MainMenuWindowTemplate
        {
            get { return MainMenuWindowTemplateProperty.GetValue(this); }
            set { MainMenuWindowTemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<LevelSelectExample> LevelSelectWindowProperty = new DependencyProperty<LevelSelectExample>("LevelSelectWindow");
        public LevelSelectExample LevelSelectWindow
        {
            get { return LevelSelectWindowProperty.GetValue(this); }
            set { LevelSelectWindowProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> LevelSelectWindowTemplateProperty = new DependencyProperty<Template>("LevelSelectWindowTemplate");
        public Template LevelSelectWindowTemplate
        {
            get { return LevelSelectWindowTemplateProperty.GetValue(this); }
            set { LevelSelectWindowTemplateProperty.SetValue(this, value); }
        }

        #endregion
    }

    #region Data Templates

    public static class MainMenuDemoSceneTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return MainMenuDemoScene;
            }
        }

        private static Template _mainMenuDemoScene;
        public static Template MainMenuDemoScene
        {
            get
            {
#if UNITY_EDITOR
                if (_mainMenuDemoScene == null || _mainMenuDemoScene.CurrentVersion != Template.Version)
#else
                if (_mainMenuDemoScene == null)
#endif
                {
                    _mainMenuDemoScene = new Template(UIViewTemplates.UIView);
#if UNITY_EDITOR
                    _mainMenuDemoScene.Name = "MainMenuDemoScene";
                    _mainMenuDemoScene.LineNumber = 0;
                    _mainMenuDemoScene.LinePosition = 0;
#endif
                    Delight.MainMenuDemoScene.SubmenuSwitcherTemplateProperty.SetDefault(_mainMenuDemoScene, MainMenuDemoSceneSubmenuSwitcher);
                    Delight.MainMenuDemoScene.MainMenuWindowTemplateProperty.SetDefault(_mainMenuDemoScene, MainMenuDemoSceneMainMenuWindow);
                    Delight.MainMenuDemoScene.LevelSelectWindowTemplateProperty.SetDefault(_mainMenuDemoScene, MainMenuDemoSceneLevelSelectWindow);
                }
                return _mainMenuDemoScene;
            }
        }

        private static Template _mainMenuDemoSceneSubmenuSwitcher;
        public static Template MainMenuDemoSceneSubmenuSwitcher
        {
            get
            {
#if UNITY_EDITOR
                if (_mainMenuDemoSceneSubmenuSwitcher == null || _mainMenuDemoSceneSubmenuSwitcher.CurrentVersion != Template.Version)
#else
                if (_mainMenuDemoSceneSubmenuSwitcher == null)
#endif
                {
                    _mainMenuDemoSceneSubmenuSwitcher = new Template(ViewSwitcherTemplates.ViewSwitcher);
#if UNITY_EDITOR
                    _mainMenuDemoSceneSubmenuSwitcher.Name = "MainMenuDemoSceneSubmenuSwitcher";
                    _mainMenuDemoSceneSubmenuSwitcher.LineNumber = 3;
                    _mainMenuDemoSceneSubmenuSwitcher.LinePosition = 4;
#endif
                }
                return _mainMenuDemoSceneSubmenuSwitcher;
            }
        }

        private static Template _mainMenuDemoSceneMainMenuWindow;
        public static Template MainMenuDemoSceneMainMenuWindow
        {
            get
            {
#if UNITY_EDITOR
                if (_mainMenuDemoSceneMainMenuWindow == null || _mainMenuDemoSceneMainMenuWindow.CurrentVersion != Template.Version)
#else
                if (_mainMenuDemoSceneMainMenuWindow == null)
#endif
                {
                    _mainMenuDemoSceneMainMenuWindow = new Template(MainMenuExampleTemplates.MainMenuExample);
#if UNITY_EDITOR
                    _mainMenuDemoSceneMainMenuWindow.Name = "MainMenuDemoSceneMainMenuWindow";
                    _mainMenuDemoSceneMainMenuWindow.LineNumber = 6;
                    _mainMenuDemoSceneMainMenuWindow.LinePosition = 6;
#endif
                    Delight.MainMenuExample.Image1TemplateProperty.SetDefault(_mainMenuDemoSceneMainMenuWindow, MainMenuDemoSceneMainMenuWindowImage1);
                    Delight.MainMenuExample.Label1TemplateProperty.SetDefault(_mainMenuDemoSceneMainMenuWindow, MainMenuDemoSceneMainMenuWindowLabel1);
                    Delight.MainMenuExample.Group1TemplateProperty.SetDefault(_mainMenuDemoSceneMainMenuWindow, MainMenuDemoSceneMainMenuWindowGroup1);
                    Delight.MainMenuExample.Button1TemplateProperty.SetDefault(_mainMenuDemoSceneMainMenuWindow, MainMenuDemoSceneMainMenuWindowButton1);
                    Delight.MainMenuExample.Button2TemplateProperty.SetDefault(_mainMenuDemoSceneMainMenuWindow, MainMenuDemoSceneMainMenuWindowButton2);
                    Delight.MainMenuExample.Button3TemplateProperty.SetDefault(_mainMenuDemoSceneMainMenuWindow, MainMenuDemoSceneMainMenuWindowButton3);
                }
                return _mainMenuDemoSceneMainMenuWindow;
            }
        }

        private static Template _mainMenuDemoSceneMainMenuWindowImage1;
        public static Template MainMenuDemoSceneMainMenuWindowImage1
        {
            get
            {
#if UNITY_EDITOR
                if (_mainMenuDemoSceneMainMenuWindowImage1 == null || _mainMenuDemoSceneMainMenuWindowImage1.CurrentVersion != Template.Version)
#else
                if (_mainMenuDemoSceneMainMenuWindowImage1 == null)
#endif
                {
                    _mainMenuDemoSceneMainMenuWindowImage1 = new Template(MainMenuExampleTemplates.MainMenuExampleImage1);
#if UNITY_EDITOR
                    _mainMenuDemoSceneMainMenuWindowImage1.Name = "MainMenuDemoSceneMainMenuWindowImage1";
                    _mainMenuDemoSceneMainMenuWindowImage1.LineNumber = 2;
                    _mainMenuDemoSceneMainMenuWindowImage1.LinePosition = 4;
#endif
                }
                return _mainMenuDemoSceneMainMenuWindowImage1;
            }
        }

        private static Template _mainMenuDemoSceneMainMenuWindowLabel1;
        public static Template MainMenuDemoSceneMainMenuWindowLabel1
        {
            get
            {
#if UNITY_EDITOR
                if (_mainMenuDemoSceneMainMenuWindowLabel1 == null || _mainMenuDemoSceneMainMenuWindowLabel1.CurrentVersion != Template.Version)
#else
                if (_mainMenuDemoSceneMainMenuWindowLabel1 == null)
#endif
                {
                    _mainMenuDemoSceneMainMenuWindowLabel1 = new Template(MainMenuExampleTemplates.MainMenuExampleLabel1);
#if UNITY_EDITOR
                    _mainMenuDemoSceneMainMenuWindowLabel1.Name = "MainMenuDemoSceneMainMenuWindowLabel1";
                    _mainMenuDemoSceneMainMenuWindowLabel1.LineNumber = 3;
                    _mainMenuDemoSceneMainMenuWindowLabel1.LinePosition = 4;
#endif
                }
                return _mainMenuDemoSceneMainMenuWindowLabel1;
            }
        }

        private static Template _mainMenuDemoSceneMainMenuWindowGroup1;
        public static Template MainMenuDemoSceneMainMenuWindowGroup1
        {
            get
            {
#if UNITY_EDITOR
                if (_mainMenuDemoSceneMainMenuWindowGroup1 == null || _mainMenuDemoSceneMainMenuWindowGroup1.CurrentVersion != Template.Version)
#else
                if (_mainMenuDemoSceneMainMenuWindowGroup1 == null)
#endif
                {
                    _mainMenuDemoSceneMainMenuWindowGroup1 = new Template(MainMenuExampleTemplates.MainMenuExampleGroup1);
#if UNITY_EDITOR
                    _mainMenuDemoSceneMainMenuWindowGroup1.Name = "MainMenuDemoSceneMainMenuWindowGroup1";
                    _mainMenuDemoSceneMainMenuWindowGroup1.LineNumber = 4;
                    _mainMenuDemoSceneMainMenuWindowGroup1.LinePosition = 4;
#endif
                }
                return _mainMenuDemoSceneMainMenuWindowGroup1;
            }
        }

        private static Template _mainMenuDemoSceneMainMenuWindowButton1;
        public static Template MainMenuDemoSceneMainMenuWindowButton1
        {
            get
            {
#if UNITY_EDITOR
                if (_mainMenuDemoSceneMainMenuWindowButton1 == null || _mainMenuDemoSceneMainMenuWindowButton1.CurrentVersion != Template.Version)
#else
                if (_mainMenuDemoSceneMainMenuWindowButton1 == null)
#endif
                {
                    _mainMenuDemoSceneMainMenuWindowButton1 = new Template(MainMenuExampleTemplates.MainMenuExampleButton1);
#if UNITY_EDITOR
                    _mainMenuDemoSceneMainMenuWindowButton1.Name = "MainMenuDemoSceneMainMenuWindowButton1";
                    _mainMenuDemoSceneMainMenuWindowButton1.LineNumber = 5;
                    _mainMenuDemoSceneMainMenuWindowButton1.LinePosition = 6;
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_mainMenuDemoSceneMainMenuWindowButton1, MainMenuDemoSceneMainMenuWindowButton1Label);
                }
                return _mainMenuDemoSceneMainMenuWindowButton1;
            }
        }

        private static Template _mainMenuDemoSceneMainMenuWindowButton1Label;
        public static Template MainMenuDemoSceneMainMenuWindowButton1Label
        {
            get
            {
#if UNITY_EDITOR
                if (_mainMenuDemoSceneMainMenuWindowButton1Label == null || _mainMenuDemoSceneMainMenuWindowButton1Label.CurrentVersion != Template.Version)
#else
                if (_mainMenuDemoSceneMainMenuWindowButton1Label == null)
#endif
                {
                    _mainMenuDemoSceneMainMenuWindowButton1Label = new Template(MainMenuExampleTemplates.MainMenuExampleButton1Label);
#if UNITY_EDITOR
                    _mainMenuDemoSceneMainMenuWindowButton1Label.Name = "MainMenuDemoSceneMainMenuWindowButton1Label";
                    _mainMenuDemoSceneMainMenuWindowButton1Label.LineNumber = 15;
                    _mainMenuDemoSceneMainMenuWindowButton1Label.LinePosition = 4;
#endif
                }
                return _mainMenuDemoSceneMainMenuWindowButton1Label;
            }
        }

        private static Template _mainMenuDemoSceneMainMenuWindowButton2;
        public static Template MainMenuDemoSceneMainMenuWindowButton2
        {
            get
            {
#if UNITY_EDITOR
                if (_mainMenuDemoSceneMainMenuWindowButton2 == null || _mainMenuDemoSceneMainMenuWindowButton2.CurrentVersion != Template.Version)
#else
                if (_mainMenuDemoSceneMainMenuWindowButton2 == null)
#endif
                {
                    _mainMenuDemoSceneMainMenuWindowButton2 = new Template(MainMenuExampleTemplates.MainMenuExampleButton2);
#if UNITY_EDITOR
                    _mainMenuDemoSceneMainMenuWindowButton2.Name = "MainMenuDemoSceneMainMenuWindowButton2";
                    _mainMenuDemoSceneMainMenuWindowButton2.LineNumber = 6;
                    _mainMenuDemoSceneMainMenuWindowButton2.LinePosition = 6;
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_mainMenuDemoSceneMainMenuWindowButton2, MainMenuDemoSceneMainMenuWindowButton2Label);
                }
                return _mainMenuDemoSceneMainMenuWindowButton2;
            }
        }

        private static Template _mainMenuDemoSceneMainMenuWindowButton2Label;
        public static Template MainMenuDemoSceneMainMenuWindowButton2Label
        {
            get
            {
#if UNITY_EDITOR
                if (_mainMenuDemoSceneMainMenuWindowButton2Label == null || _mainMenuDemoSceneMainMenuWindowButton2Label.CurrentVersion != Template.Version)
#else
                if (_mainMenuDemoSceneMainMenuWindowButton2Label == null)
#endif
                {
                    _mainMenuDemoSceneMainMenuWindowButton2Label = new Template(MainMenuExampleTemplates.MainMenuExampleButton2Label);
#if UNITY_EDITOR
                    _mainMenuDemoSceneMainMenuWindowButton2Label.Name = "MainMenuDemoSceneMainMenuWindowButton2Label";
                    _mainMenuDemoSceneMainMenuWindowButton2Label.LineNumber = 15;
                    _mainMenuDemoSceneMainMenuWindowButton2Label.LinePosition = 4;
#endif
                }
                return _mainMenuDemoSceneMainMenuWindowButton2Label;
            }
        }

        private static Template _mainMenuDemoSceneMainMenuWindowButton3;
        public static Template MainMenuDemoSceneMainMenuWindowButton3
        {
            get
            {
#if UNITY_EDITOR
                if (_mainMenuDemoSceneMainMenuWindowButton3 == null || _mainMenuDemoSceneMainMenuWindowButton3.CurrentVersion != Template.Version)
#else
                if (_mainMenuDemoSceneMainMenuWindowButton3 == null)
#endif
                {
                    _mainMenuDemoSceneMainMenuWindowButton3 = new Template(MainMenuExampleTemplates.MainMenuExampleButton3);
#if UNITY_EDITOR
                    _mainMenuDemoSceneMainMenuWindowButton3.Name = "MainMenuDemoSceneMainMenuWindowButton3";
                    _mainMenuDemoSceneMainMenuWindowButton3.LineNumber = 7;
                    _mainMenuDemoSceneMainMenuWindowButton3.LinePosition = 6;
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_mainMenuDemoSceneMainMenuWindowButton3, MainMenuDemoSceneMainMenuWindowButton3Label);
                }
                return _mainMenuDemoSceneMainMenuWindowButton3;
            }
        }

        private static Template _mainMenuDemoSceneMainMenuWindowButton3Label;
        public static Template MainMenuDemoSceneMainMenuWindowButton3Label
        {
            get
            {
#if UNITY_EDITOR
                if (_mainMenuDemoSceneMainMenuWindowButton3Label == null || _mainMenuDemoSceneMainMenuWindowButton3Label.CurrentVersion != Template.Version)
#else
                if (_mainMenuDemoSceneMainMenuWindowButton3Label == null)
#endif
                {
                    _mainMenuDemoSceneMainMenuWindowButton3Label = new Template(MainMenuExampleTemplates.MainMenuExampleButton3Label);
#if UNITY_EDITOR
                    _mainMenuDemoSceneMainMenuWindowButton3Label.Name = "MainMenuDemoSceneMainMenuWindowButton3Label";
                    _mainMenuDemoSceneMainMenuWindowButton3Label.LineNumber = 15;
                    _mainMenuDemoSceneMainMenuWindowButton3Label.LinePosition = 4;
#endif
                }
                return _mainMenuDemoSceneMainMenuWindowButton3Label;
            }
        }

        private static Template _mainMenuDemoSceneLevelSelectWindow;
        public static Template MainMenuDemoSceneLevelSelectWindow
        {
            get
            {
#if UNITY_EDITOR
                if (_mainMenuDemoSceneLevelSelectWindow == null || _mainMenuDemoSceneLevelSelectWindow.CurrentVersion != Template.Version)
#else
                if (_mainMenuDemoSceneLevelSelectWindow == null)
#endif
                {
                    _mainMenuDemoSceneLevelSelectWindow = new Template(LevelSelectExampleTemplates.LevelSelectExample);
#if UNITY_EDITOR
                    _mainMenuDemoSceneLevelSelectWindow.Name = "MainMenuDemoSceneLevelSelectWindow";
                    _mainMenuDemoSceneLevelSelectWindow.LineNumber = 9;
                    _mainMenuDemoSceneLevelSelectWindow.LinePosition = 6;
#endif
                    Delight.LevelSelectExample.Image1TemplateProperty.SetDefault(_mainMenuDemoSceneLevelSelectWindow, MainMenuDemoSceneLevelSelectWindowImage1);
                    Delight.LevelSelectExample.Label1TemplateProperty.SetDefault(_mainMenuDemoSceneLevelSelectWindow, MainMenuDemoSceneLevelSelectWindowLabel1);
                    Delight.LevelSelectExample.List1TemplateProperty.SetDefault(_mainMenuDemoSceneLevelSelectWindow, MainMenuDemoSceneLevelSelectWindowList1);
                    Delight.LevelSelectExample.ListItem1TemplateProperty.SetDefault(_mainMenuDemoSceneLevelSelectWindow, MainMenuDemoSceneLevelSelectWindowListItem1);
                    Delight.LevelSelectExample.Label2TemplateProperty.SetDefault(_mainMenuDemoSceneLevelSelectWindow, MainMenuDemoSceneLevelSelectWindowLabel2);
                    Delight.LevelSelectExample.Image2TemplateProperty.SetDefault(_mainMenuDemoSceneLevelSelectWindow, MainMenuDemoSceneLevelSelectWindowImage2);
                    Delight.LevelSelectExample.NavigationButton1TemplateProperty.SetDefault(_mainMenuDemoSceneLevelSelectWindow, MainMenuDemoSceneLevelSelectWindowNavigationButton1);
                    Delight.LevelSelectExample.NavigationButton2TemplateProperty.SetDefault(_mainMenuDemoSceneLevelSelectWindow, MainMenuDemoSceneLevelSelectWindowNavigationButton2);
                    Delight.LevelSelectExample.Button1TemplateProperty.SetDefault(_mainMenuDemoSceneLevelSelectWindow, MainMenuDemoSceneLevelSelectWindowButton1);
                }
                return _mainMenuDemoSceneLevelSelectWindow;
            }
        }

        private static Template _mainMenuDemoSceneLevelSelectWindowImage1;
        public static Template MainMenuDemoSceneLevelSelectWindowImage1
        {
            get
            {
#if UNITY_EDITOR
                if (_mainMenuDemoSceneLevelSelectWindowImage1 == null || _mainMenuDemoSceneLevelSelectWindowImage1.CurrentVersion != Template.Version)
#else
                if (_mainMenuDemoSceneLevelSelectWindowImage1 == null)
#endif
                {
                    _mainMenuDemoSceneLevelSelectWindowImage1 = new Template(LevelSelectExampleTemplates.LevelSelectExampleImage1);
#if UNITY_EDITOR
                    _mainMenuDemoSceneLevelSelectWindowImage1.Name = "MainMenuDemoSceneLevelSelectWindowImage1";
                    _mainMenuDemoSceneLevelSelectWindowImage1.LineNumber = 3;
                    _mainMenuDemoSceneLevelSelectWindowImage1.LinePosition = 4;
#endif
                }
                return _mainMenuDemoSceneLevelSelectWindowImage1;
            }
        }

        private static Template _mainMenuDemoSceneLevelSelectWindowLabel1;
        public static Template MainMenuDemoSceneLevelSelectWindowLabel1
        {
            get
            {
#if UNITY_EDITOR
                if (_mainMenuDemoSceneLevelSelectWindowLabel1 == null || _mainMenuDemoSceneLevelSelectWindowLabel1.CurrentVersion != Template.Version)
#else
                if (_mainMenuDemoSceneLevelSelectWindowLabel1 == null)
#endif
                {
                    _mainMenuDemoSceneLevelSelectWindowLabel1 = new Template(LevelSelectExampleTemplates.LevelSelectExampleLabel1);
#if UNITY_EDITOR
                    _mainMenuDemoSceneLevelSelectWindowLabel1.Name = "MainMenuDemoSceneLevelSelectWindowLabel1";
                    _mainMenuDemoSceneLevelSelectWindowLabel1.LineNumber = 4;
                    _mainMenuDemoSceneLevelSelectWindowLabel1.LinePosition = 4;
#endif
                }
                return _mainMenuDemoSceneLevelSelectWindowLabel1;
            }
        }

        private static Template _mainMenuDemoSceneLevelSelectWindowList1;
        public static Template MainMenuDemoSceneLevelSelectWindowList1
        {
            get
            {
#if UNITY_EDITOR
                if (_mainMenuDemoSceneLevelSelectWindowList1 == null || _mainMenuDemoSceneLevelSelectWindowList1.CurrentVersion != Template.Version)
#else
                if (_mainMenuDemoSceneLevelSelectWindowList1 == null)
#endif
                {
                    _mainMenuDemoSceneLevelSelectWindowList1 = new Template(LevelSelectExampleTemplates.LevelSelectExampleList1);
#if UNITY_EDITOR
                    _mainMenuDemoSceneLevelSelectWindowList1.Name = "MainMenuDemoSceneLevelSelectWindowList1";
                    _mainMenuDemoSceneLevelSelectWindowList1.LineNumber = 5;
                    _mainMenuDemoSceneLevelSelectWindowList1.LinePosition = 4;
#endif
                    Delight.List.ScrollableRegionTemplateProperty.SetDefault(_mainMenuDemoSceneLevelSelectWindowList1, MainMenuDemoSceneLevelSelectWindowList1ScrollableRegion);
                }
                return _mainMenuDemoSceneLevelSelectWindowList1;
            }
        }

        private static Template _mainMenuDemoSceneLevelSelectWindowList1ScrollableRegion;
        public static Template MainMenuDemoSceneLevelSelectWindowList1ScrollableRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_mainMenuDemoSceneLevelSelectWindowList1ScrollableRegion == null || _mainMenuDemoSceneLevelSelectWindowList1ScrollableRegion.CurrentVersion != Template.Version)
#else
                if (_mainMenuDemoSceneLevelSelectWindowList1ScrollableRegion == null)
#endif
                {
                    _mainMenuDemoSceneLevelSelectWindowList1ScrollableRegion = new Template(LevelSelectExampleTemplates.LevelSelectExampleList1ScrollableRegion);
#if UNITY_EDITOR
                    _mainMenuDemoSceneLevelSelectWindowList1ScrollableRegion.Name = "MainMenuDemoSceneLevelSelectWindowList1ScrollableRegion";
                    _mainMenuDemoSceneLevelSelectWindowList1ScrollableRegion.LineNumber = 27;
                    _mainMenuDemoSceneLevelSelectWindowList1ScrollableRegion.LinePosition = 4;
#endif
                    Delight.ScrollableRegion.ContentRegionTemplateProperty.SetDefault(_mainMenuDemoSceneLevelSelectWindowList1ScrollableRegion, MainMenuDemoSceneLevelSelectWindowList1ScrollableRegionContentRegion);
                    Delight.ScrollableRegion.HorizontalScrollbarTemplateProperty.SetDefault(_mainMenuDemoSceneLevelSelectWindowList1ScrollableRegion, MainMenuDemoSceneLevelSelectWindowList1ScrollableRegionHorizontalScrollbar);
                    Delight.ScrollableRegion.VerticalScrollbarTemplateProperty.SetDefault(_mainMenuDemoSceneLevelSelectWindowList1ScrollableRegion, MainMenuDemoSceneLevelSelectWindowList1ScrollableRegionVerticalScrollbar);
                }
                return _mainMenuDemoSceneLevelSelectWindowList1ScrollableRegion;
            }
        }

        private static Template _mainMenuDemoSceneLevelSelectWindowList1ScrollableRegionContentRegion;
        public static Template MainMenuDemoSceneLevelSelectWindowList1ScrollableRegionContentRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_mainMenuDemoSceneLevelSelectWindowList1ScrollableRegionContentRegion == null || _mainMenuDemoSceneLevelSelectWindowList1ScrollableRegionContentRegion.CurrentVersion != Template.Version)
#else
                if (_mainMenuDemoSceneLevelSelectWindowList1ScrollableRegionContentRegion == null)
#endif
                {
                    _mainMenuDemoSceneLevelSelectWindowList1ScrollableRegionContentRegion = new Template(LevelSelectExampleTemplates.LevelSelectExampleList1ScrollableRegionContentRegion);
#if UNITY_EDITOR
                    _mainMenuDemoSceneLevelSelectWindowList1ScrollableRegionContentRegion.Name = "MainMenuDemoSceneLevelSelectWindowList1ScrollableRegionContentRegion";
                    _mainMenuDemoSceneLevelSelectWindowList1ScrollableRegionContentRegion.LineNumber = 24;
                    _mainMenuDemoSceneLevelSelectWindowList1ScrollableRegionContentRegion.LinePosition = 4;
#endif
                }
                return _mainMenuDemoSceneLevelSelectWindowList1ScrollableRegionContentRegion;
            }
        }

        private static Template _mainMenuDemoSceneLevelSelectWindowList1ScrollableRegionHorizontalScrollbar;
        public static Template MainMenuDemoSceneLevelSelectWindowList1ScrollableRegionHorizontalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_mainMenuDemoSceneLevelSelectWindowList1ScrollableRegionHorizontalScrollbar == null || _mainMenuDemoSceneLevelSelectWindowList1ScrollableRegionHorizontalScrollbar.CurrentVersion != Template.Version)
#else
                if (_mainMenuDemoSceneLevelSelectWindowList1ScrollableRegionHorizontalScrollbar == null)
#endif
                {
                    _mainMenuDemoSceneLevelSelectWindowList1ScrollableRegionHorizontalScrollbar = new Template(LevelSelectExampleTemplates.LevelSelectExampleList1ScrollableRegionHorizontalScrollbar);
#if UNITY_EDITOR
                    _mainMenuDemoSceneLevelSelectWindowList1ScrollableRegionHorizontalScrollbar.Name = "MainMenuDemoSceneLevelSelectWindowList1ScrollableRegionHorizontalScrollbar";
                    _mainMenuDemoSceneLevelSelectWindowList1ScrollableRegionHorizontalScrollbar.LineNumber = 26;
                    _mainMenuDemoSceneLevelSelectWindowList1ScrollableRegionHorizontalScrollbar.LinePosition = 4;
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_mainMenuDemoSceneLevelSelectWindowList1ScrollableRegionHorizontalScrollbar, MainMenuDemoSceneLevelSelectWindowList1ScrollableRegionHorizontalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_mainMenuDemoSceneLevelSelectWindowList1ScrollableRegionHorizontalScrollbar, MainMenuDemoSceneLevelSelectWindowList1ScrollableRegionHorizontalScrollbarHandle);
                }
                return _mainMenuDemoSceneLevelSelectWindowList1ScrollableRegionHorizontalScrollbar;
            }
        }

        private static Template _mainMenuDemoSceneLevelSelectWindowList1ScrollableRegionHorizontalScrollbarBar;
        public static Template MainMenuDemoSceneLevelSelectWindowList1ScrollableRegionHorizontalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_mainMenuDemoSceneLevelSelectWindowList1ScrollableRegionHorizontalScrollbarBar == null || _mainMenuDemoSceneLevelSelectWindowList1ScrollableRegionHorizontalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_mainMenuDemoSceneLevelSelectWindowList1ScrollableRegionHorizontalScrollbarBar == null)
#endif
                {
                    _mainMenuDemoSceneLevelSelectWindowList1ScrollableRegionHorizontalScrollbarBar = new Template(LevelSelectExampleTemplates.LevelSelectExampleList1ScrollableRegionHorizontalScrollbarBar);
#if UNITY_EDITOR
                    _mainMenuDemoSceneLevelSelectWindowList1ScrollableRegionHorizontalScrollbarBar.Name = "MainMenuDemoSceneLevelSelectWindowList1ScrollableRegionHorizontalScrollbarBar";
                    _mainMenuDemoSceneLevelSelectWindowList1ScrollableRegionHorizontalScrollbarBar.LineNumber = 7;
                    _mainMenuDemoSceneLevelSelectWindowList1ScrollableRegionHorizontalScrollbarBar.LinePosition = 4;
#endif
                }
                return _mainMenuDemoSceneLevelSelectWindowList1ScrollableRegionHorizontalScrollbarBar;
            }
        }

        private static Template _mainMenuDemoSceneLevelSelectWindowList1ScrollableRegionHorizontalScrollbarHandle;
        public static Template MainMenuDemoSceneLevelSelectWindowList1ScrollableRegionHorizontalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_mainMenuDemoSceneLevelSelectWindowList1ScrollableRegionHorizontalScrollbarHandle == null || _mainMenuDemoSceneLevelSelectWindowList1ScrollableRegionHorizontalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_mainMenuDemoSceneLevelSelectWindowList1ScrollableRegionHorizontalScrollbarHandle == null)
#endif
                {
                    _mainMenuDemoSceneLevelSelectWindowList1ScrollableRegionHorizontalScrollbarHandle = new Template(LevelSelectExampleTemplates.LevelSelectExampleList1ScrollableRegionHorizontalScrollbarHandle);
#if UNITY_EDITOR
                    _mainMenuDemoSceneLevelSelectWindowList1ScrollableRegionHorizontalScrollbarHandle.Name = "MainMenuDemoSceneLevelSelectWindowList1ScrollableRegionHorizontalScrollbarHandle";
                    _mainMenuDemoSceneLevelSelectWindowList1ScrollableRegionHorizontalScrollbarHandle.LineNumber = 8;
                    _mainMenuDemoSceneLevelSelectWindowList1ScrollableRegionHorizontalScrollbarHandle.LinePosition = 6;
#endif
                }
                return _mainMenuDemoSceneLevelSelectWindowList1ScrollableRegionHorizontalScrollbarHandle;
            }
        }

        private static Template _mainMenuDemoSceneLevelSelectWindowList1ScrollableRegionVerticalScrollbar;
        public static Template MainMenuDemoSceneLevelSelectWindowList1ScrollableRegionVerticalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_mainMenuDemoSceneLevelSelectWindowList1ScrollableRegionVerticalScrollbar == null || _mainMenuDemoSceneLevelSelectWindowList1ScrollableRegionVerticalScrollbar.CurrentVersion != Template.Version)
#else
                if (_mainMenuDemoSceneLevelSelectWindowList1ScrollableRegionVerticalScrollbar == null)
#endif
                {
                    _mainMenuDemoSceneLevelSelectWindowList1ScrollableRegionVerticalScrollbar = new Template(LevelSelectExampleTemplates.LevelSelectExampleList1ScrollableRegionVerticalScrollbar);
#if UNITY_EDITOR
                    _mainMenuDemoSceneLevelSelectWindowList1ScrollableRegionVerticalScrollbar.Name = "MainMenuDemoSceneLevelSelectWindowList1ScrollableRegionVerticalScrollbar";
                    _mainMenuDemoSceneLevelSelectWindowList1ScrollableRegionVerticalScrollbar.LineNumber = 27;
                    _mainMenuDemoSceneLevelSelectWindowList1ScrollableRegionVerticalScrollbar.LinePosition = 4;
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_mainMenuDemoSceneLevelSelectWindowList1ScrollableRegionVerticalScrollbar, MainMenuDemoSceneLevelSelectWindowList1ScrollableRegionVerticalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_mainMenuDemoSceneLevelSelectWindowList1ScrollableRegionVerticalScrollbar, MainMenuDemoSceneLevelSelectWindowList1ScrollableRegionVerticalScrollbarHandle);
                }
                return _mainMenuDemoSceneLevelSelectWindowList1ScrollableRegionVerticalScrollbar;
            }
        }

        private static Template _mainMenuDemoSceneLevelSelectWindowList1ScrollableRegionVerticalScrollbarBar;
        public static Template MainMenuDemoSceneLevelSelectWindowList1ScrollableRegionVerticalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_mainMenuDemoSceneLevelSelectWindowList1ScrollableRegionVerticalScrollbarBar == null || _mainMenuDemoSceneLevelSelectWindowList1ScrollableRegionVerticalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_mainMenuDemoSceneLevelSelectWindowList1ScrollableRegionVerticalScrollbarBar == null)
#endif
                {
                    _mainMenuDemoSceneLevelSelectWindowList1ScrollableRegionVerticalScrollbarBar = new Template(LevelSelectExampleTemplates.LevelSelectExampleList1ScrollableRegionVerticalScrollbarBar);
#if UNITY_EDITOR
                    _mainMenuDemoSceneLevelSelectWindowList1ScrollableRegionVerticalScrollbarBar.Name = "MainMenuDemoSceneLevelSelectWindowList1ScrollableRegionVerticalScrollbarBar";
                    _mainMenuDemoSceneLevelSelectWindowList1ScrollableRegionVerticalScrollbarBar.LineNumber = 7;
                    _mainMenuDemoSceneLevelSelectWindowList1ScrollableRegionVerticalScrollbarBar.LinePosition = 4;
#endif
                }
                return _mainMenuDemoSceneLevelSelectWindowList1ScrollableRegionVerticalScrollbarBar;
            }
        }

        private static Template _mainMenuDemoSceneLevelSelectWindowList1ScrollableRegionVerticalScrollbarHandle;
        public static Template MainMenuDemoSceneLevelSelectWindowList1ScrollableRegionVerticalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_mainMenuDemoSceneLevelSelectWindowList1ScrollableRegionVerticalScrollbarHandle == null || _mainMenuDemoSceneLevelSelectWindowList1ScrollableRegionVerticalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_mainMenuDemoSceneLevelSelectWindowList1ScrollableRegionVerticalScrollbarHandle == null)
#endif
                {
                    _mainMenuDemoSceneLevelSelectWindowList1ScrollableRegionVerticalScrollbarHandle = new Template(LevelSelectExampleTemplates.LevelSelectExampleList1ScrollableRegionVerticalScrollbarHandle);
#if UNITY_EDITOR
                    _mainMenuDemoSceneLevelSelectWindowList1ScrollableRegionVerticalScrollbarHandle.Name = "MainMenuDemoSceneLevelSelectWindowList1ScrollableRegionVerticalScrollbarHandle";
                    _mainMenuDemoSceneLevelSelectWindowList1ScrollableRegionVerticalScrollbarHandle.LineNumber = 8;
                    _mainMenuDemoSceneLevelSelectWindowList1ScrollableRegionVerticalScrollbarHandle.LinePosition = 6;
#endif
                }
                return _mainMenuDemoSceneLevelSelectWindowList1ScrollableRegionVerticalScrollbarHandle;
            }
        }

        private static Template _mainMenuDemoSceneLevelSelectWindowListItem1;
        public static Template MainMenuDemoSceneLevelSelectWindowListItem1
        {
            get
            {
#if UNITY_EDITOR
                if (_mainMenuDemoSceneLevelSelectWindowListItem1 == null || _mainMenuDemoSceneLevelSelectWindowListItem1.CurrentVersion != Template.Version)
#else
                if (_mainMenuDemoSceneLevelSelectWindowListItem1 == null)
#endif
                {
                    _mainMenuDemoSceneLevelSelectWindowListItem1 = new Template(LevelSelectExampleTemplates.LevelSelectExampleListItem1);
#if UNITY_EDITOR
                    _mainMenuDemoSceneLevelSelectWindowListItem1.Name = "MainMenuDemoSceneLevelSelectWindowListItem1";
                    _mainMenuDemoSceneLevelSelectWindowListItem1.LineNumber = 10;
                    _mainMenuDemoSceneLevelSelectWindowListItem1.LinePosition = 6;
#endif
                }
                return _mainMenuDemoSceneLevelSelectWindowListItem1;
            }
        }

        private static Template _mainMenuDemoSceneLevelSelectWindowLabel2;
        public static Template MainMenuDemoSceneLevelSelectWindowLabel2
        {
            get
            {
#if UNITY_EDITOR
                if (_mainMenuDemoSceneLevelSelectWindowLabel2 == null || _mainMenuDemoSceneLevelSelectWindowLabel2.CurrentVersion != Template.Version)
#else
                if (_mainMenuDemoSceneLevelSelectWindowLabel2 == null)
#endif
                {
                    _mainMenuDemoSceneLevelSelectWindowLabel2 = new Template(LevelSelectExampleTemplates.LevelSelectExampleLabel2);
#if UNITY_EDITOR
                    _mainMenuDemoSceneLevelSelectWindowLabel2.Name = "MainMenuDemoSceneLevelSelectWindowLabel2";
                    _mainMenuDemoSceneLevelSelectWindowLabel2.LineNumber = 11;
                    _mainMenuDemoSceneLevelSelectWindowLabel2.LinePosition = 8;
#endif
                }
                return _mainMenuDemoSceneLevelSelectWindowLabel2;
            }
        }

        private static Template _mainMenuDemoSceneLevelSelectWindowImage2;
        public static Template MainMenuDemoSceneLevelSelectWindowImage2
        {
            get
            {
#if UNITY_EDITOR
                if (_mainMenuDemoSceneLevelSelectWindowImage2 == null || _mainMenuDemoSceneLevelSelectWindowImage2.CurrentVersion != Template.Version)
#else
                if (_mainMenuDemoSceneLevelSelectWindowImage2 == null)
#endif
                {
                    _mainMenuDemoSceneLevelSelectWindowImage2 = new Template(LevelSelectExampleTemplates.LevelSelectExampleImage2);
#if UNITY_EDITOR
                    _mainMenuDemoSceneLevelSelectWindowImage2.Name = "MainMenuDemoSceneLevelSelectWindowImage2";
                    _mainMenuDemoSceneLevelSelectWindowImage2.LineNumber = 13;
                    _mainMenuDemoSceneLevelSelectWindowImage2.LinePosition = 8;
#endif
                }
                return _mainMenuDemoSceneLevelSelectWindowImage2;
            }
        }

        private static Template _mainMenuDemoSceneLevelSelectWindowNavigationButton1;
        public static Template MainMenuDemoSceneLevelSelectWindowNavigationButton1
        {
            get
            {
#if UNITY_EDITOR
                if (_mainMenuDemoSceneLevelSelectWindowNavigationButton1 == null || _mainMenuDemoSceneLevelSelectWindowNavigationButton1.CurrentVersion != Template.Version)
#else
                if (_mainMenuDemoSceneLevelSelectWindowNavigationButton1 == null)
#endif
                {
                    _mainMenuDemoSceneLevelSelectWindowNavigationButton1 = new Template(LevelSelectExampleTemplates.LevelSelectExampleNavigationButton1);
#if UNITY_EDITOR
                    _mainMenuDemoSceneLevelSelectWindowNavigationButton1.Name = "MainMenuDemoSceneLevelSelectWindowNavigationButton1";
                    _mainMenuDemoSceneLevelSelectWindowNavigationButton1.LineNumber = 15;
                    _mainMenuDemoSceneLevelSelectWindowNavigationButton1.LinePosition = 6;
#endif
                    Delight.NavigationButton.LabelTemplateProperty.SetDefault(_mainMenuDemoSceneLevelSelectWindowNavigationButton1, MainMenuDemoSceneLevelSelectWindowNavigationButton1Label);
                }
                return _mainMenuDemoSceneLevelSelectWindowNavigationButton1;
            }
        }

        private static Template _mainMenuDemoSceneLevelSelectWindowNavigationButton1Label;
        public static Template MainMenuDemoSceneLevelSelectWindowNavigationButton1Label
        {
            get
            {
#if UNITY_EDITOR
                if (_mainMenuDemoSceneLevelSelectWindowNavigationButton1Label == null || _mainMenuDemoSceneLevelSelectWindowNavigationButton1Label.CurrentVersion != Template.Version)
#else
                if (_mainMenuDemoSceneLevelSelectWindowNavigationButton1Label == null)
#endif
                {
                    _mainMenuDemoSceneLevelSelectWindowNavigationButton1Label = new Template(LevelSelectExampleTemplates.LevelSelectExampleNavigationButton1Label);
#if UNITY_EDITOR
                    _mainMenuDemoSceneLevelSelectWindowNavigationButton1Label.Name = "MainMenuDemoSceneLevelSelectWindowNavigationButton1Label";
                    _mainMenuDemoSceneLevelSelectWindowNavigationButton1Label.LineNumber = 15;
                    _mainMenuDemoSceneLevelSelectWindowNavigationButton1Label.LinePosition = 4;
#endif
                }
                return _mainMenuDemoSceneLevelSelectWindowNavigationButton1Label;
            }
        }

        private static Template _mainMenuDemoSceneLevelSelectWindowNavigationButton2;
        public static Template MainMenuDemoSceneLevelSelectWindowNavigationButton2
        {
            get
            {
#if UNITY_EDITOR
                if (_mainMenuDemoSceneLevelSelectWindowNavigationButton2 == null || _mainMenuDemoSceneLevelSelectWindowNavigationButton2.CurrentVersion != Template.Version)
#else
                if (_mainMenuDemoSceneLevelSelectWindowNavigationButton2 == null)
#endif
                {
                    _mainMenuDemoSceneLevelSelectWindowNavigationButton2 = new Template(LevelSelectExampleTemplates.LevelSelectExampleNavigationButton2);
#if UNITY_EDITOR
                    _mainMenuDemoSceneLevelSelectWindowNavigationButton2.Name = "MainMenuDemoSceneLevelSelectWindowNavigationButton2";
                    _mainMenuDemoSceneLevelSelectWindowNavigationButton2.LineNumber = 18;
                    _mainMenuDemoSceneLevelSelectWindowNavigationButton2.LinePosition = 6;
#endif
                    Delight.NavigationButton.LabelTemplateProperty.SetDefault(_mainMenuDemoSceneLevelSelectWindowNavigationButton2, MainMenuDemoSceneLevelSelectWindowNavigationButton2Label);
                }
                return _mainMenuDemoSceneLevelSelectWindowNavigationButton2;
            }
        }

        private static Template _mainMenuDemoSceneLevelSelectWindowNavigationButton2Label;
        public static Template MainMenuDemoSceneLevelSelectWindowNavigationButton2Label
        {
            get
            {
#if UNITY_EDITOR
                if (_mainMenuDemoSceneLevelSelectWindowNavigationButton2Label == null || _mainMenuDemoSceneLevelSelectWindowNavigationButton2Label.CurrentVersion != Template.Version)
#else
                if (_mainMenuDemoSceneLevelSelectWindowNavigationButton2Label == null)
#endif
                {
                    _mainMenuDemoSceneLevelSelectWindowNavigationButton2Label = new Template(LevelSelectExampleTemplates.LevelSelectExampleNavigationButton2Label);
#if UNITY_EDITOR
                    _mainMenuDemoSceneLevelSelectWindowNavigationButton2Label.Name = "MainMenuDemoSceneLevelSelectWindowNavigationButton2Label";
                    _mainMenuDemoSceneLevelSelectWindowNavigationButton2Label.LineNumber = 15;
                    _mainMenuDemoSceneLevelSelectWindowNavigationButton2Label.LinePosition = 4;
#endif
                }
                return _mainMenuDemoSceneLevelSelectWindowNavigationButton2Label;
            }
        }

        private static Template _mainMenuDemoSceneLevelSelectWindowButton1;
        public static Template MainMenuDemoSceneLevelSelectWindowButton1
        {
            get
            {
#if UNITY_EDITOR
                if (_mainMenuDemoSceneLevelSelectWindowButton1 == null || _mainMenuDemoSceneLevelSelectWindowButton1.CurrentVersion != Template.Version)
#else
                if (_mainMenuDemoSceneLevelSelectWindowButton1 == null)
#endif
                {
                    _mainMenuDemoSceneLevelSelectWindowButton1 = new Template(LevelSelectExampleTemplates.LevelSelectExampleButton1);
#if UNITY_EDITOR
                    _mainMenuDemoSceneLevelSelectWindowButton1.Name = "MainMenuDemoSceneLevelSelectWindowButton1";
                    _mainMenuDemoSceneLevelSelectWindowButton1.LineNumber = 22;
                    _mainMenuDemoSceneLevelSelectWindowButton1.LinePosition = 4;
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_mainMenuDemoSceneLevelSelectWindowButton1, MainMenuDemoSceneLevelSelectWindowButton1Label);
                }
                return _mainMenuDemoSceneLevelSelectWindowButton1;
            }
        }

        private static Template _mainMenuDemoSceneLevelSelectWindowButton1Label;
        public static Template MainMenuDemoSceneLevelSelectWindowButton1Label
        {
            get
            {
#if UNITY_EDITOR
                if (_mainMenuDemoSceneLevelSelectWindowButton1Label == null || _mainMenuDemoSceneLevelSelectWindowButton1Label.CurrentVersion != Template.Version)
#else
                if (_mainMenuDemoSceneLevelSelectWindowButton1Label == null)
#endif
                {
                    _mainMenuDemoSceneLevelSelectWindowButton1Label = new Template(LevelSelectExampleTemplates.LevelSelectExampleButton1Label);
#if UNITY_EDITOR
                    _mainMenuDemoSceneLevelSelectWindowButton1Label.Name = "MainMenuDemoSceneLevelSelectWindowButton1Label";
                    _mainMenuDemoSceneLevelSelectWindowButton1Label.LineNumber = 15;
                    _mainMenuDemoSceneLevelSelectWindowButton1Label.LinePosition = 4;
#endif
                }
                return _mainMenuDemoSceneLevelSelectWindowButton1Label;
            }
        }

        #endregion
    }

    #endregion
}
