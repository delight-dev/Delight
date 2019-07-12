// Internal view logic generated from "NewScene.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class NewScene : UIView
    {
        #region Constructors

        public NewScene(View parent, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :
            base(parent, layoutParent, id, template ?? NewSceneTemplates.Default, initializer)
        {
            // constructing Label (Label1)
            Label1 = new Label(this, this, "Label1", Label1Template);

            // constructing MainMenu (MainMenu1)
            MainMenu1 = new MainMenu(this, this, "MainMenu1", MainMenu1Template);
            this.AfterInitializeInternal();
        }

        public NewScene() : this(null)
        {
        }

        static NewScene()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(NewSceneTemplates.Default, dependencyProperties);

            dependencyProperties.Add(Label1Property);
            dependencyProperties.Add(Label1TemplateProperty);
            dependencyProperties.Add(MainMenu1Property);
            dependencyProperties.Add(MainMenu1TemplateProperty);
        }

        #endregion

        #region Properties

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

    public static class NewSceneTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return NewScene;
            }
        }

        private static Template _newScene;
        public static Template NewScene
        {
            get
            {
#if UNITY_EDITOR
                if (_newScene == null || _newScene.CurrentVersion != Template.Version)
#else
                if (_newScene == null)
#endif
                {
                    _newScene = new Template(UIViewTemplates.UIView);
#if UNITY_EDITOR
                    _newScene.Name = "NewScene";
#endif
                    Delight.NewScene.Label1TemplateProperty.SetDefault(_newScene, NewSceneLabel1);
                    Delight.NewScene.MainMenu1TemplateProperty.SetDefault(_newScene, NewSceneMainMenu1);
                }
                return _newScene;
            }
        }

        private static Template _newSceneLabel1;
        public static Template NewSceneLabel1
        {
            get
            {
#if UNITY_EDITOR
                if (_newSceneLabel1 == null || _newSceneLabel1.CurrentVersion != Template.Version)
#else
                if (_newSceneLabel1 == null)
#endif
                {
                    _newSceneLabel1 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _newSceneLabel1.Name = "NewSceneLabel1";
#endif
                    Delight.Label.TextProperty.SetDefault(_newSceneLabel1, "Awesome!");
                }
                return _newSceneLabel1;
            }
        }

        private static Template _newSceneMainMenu1;
        public static Template NewSceneMainMenu1
        {
            get
            {
#if UNITY_EDITOR
                if (_newSceneMainMenu1 == null || _newSceneMainMenu1.CurrentVersion != Template.Version)
#else
                if (_newSceneMainMenu1 == null)
#endif
                {
                    _newSceneMainMenu1 = new Template(MainMenuTemplates.MainMenu);
#if UNITY_EDITOR
                    _newSceneMainMenu1.Name = "NewSceneMainMenu1";
#endif
                    Delight.MainMenu.Group1TemplateProperty.SetDefault(_newSceneMainMenu1, NewSceneMainMenu1Group1);
                    Delight.MainMenu.Button1TemplateProperty.SetDefault(_newSceneMainMenu1, NewSceneMainMenu1Button1);
                    Delight.MainMenu.Button2TemplateProperty.SetDefault(_newSceneMainMenu1, NewSceneMainMenu1Button2);
                    Delight.MainMenu.Button3TemplateProperty.SetDefault(_newSceneMainMenu1, NewSceneMainMenu1Button3);
                }
                return _newSceneMainMenu1;
            }
        }

        private static Template _newSceneMainMenu1Group1;
        public static Template NewSceneMainMenu1Group1
        {
            get
            {
#if UNITY_EDITOR
                if (_newSceneMainMenu1Group1 == null || _newSceneMainMenu1Group1.CurrentVersion != Template.Version)
#else
                if (_newSceneMainMenu1Group1 == null)
#endif
                {
                    _newSceneMainMenu1Group1 = new Template(MainMenuTemplates.MainMenuGroup1);
#if UNITY_EDITOR
                    _newSceneMainMenu1Group1.Name = "NewSceneMainMenu1Group1";
#endif
                }
                return _newSceneMainMenu1Group1;
            }
        }

        private static Template _newSceneMainMenu1Button1;
        public static Template NewSceneMainMenu1Button1
        {
            get
            {
#if UNITY_EDITOR
                if (_newSceneMainMenu1Button1 == null || _newSceneMainMenu1Button1.CurrentVersion != Template.Version)
#else
                if (_newSceneMainMenu1Button1 == null)
#endif
                {
                    _newSceneMainMenu1Button1 = new Template(MainMenuTemplates.MainMenuButton1);
#if UNITY_EDITOR
                    _newSceneMainMenu1Button1.Name = "NewSceneMainMenu1Button1";
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_newSceneMainMenu1Button1, NewSceneMainMenu1Button1Label);
                }
                return _newSceneMainMenu1Button1;
            }
        }

        private static Template _newSceneMainMenu1Button1Label;
        public static Template NewSceneMainMenu1Button1Label
        {
            get
            {
#if UNITY_EDITOR
                if (_newSceneMainMenu1Button1Label == null || _newSceneMainMenu1Button1Label.CurrentVersion != Template.Version)
#else
                if (_newSceneMainMenu1Button1Label == null)
#endif
                {
                    _newSceneMainMenu1Button1Label = new Template(MainMenuTemplates.MainMenuButton1Label);
#if UNITY_EDITOR
                    _newSceneMainMenu1Button1Label.Name = "NewSceneMainMenu1Button1Label";
#endif
                }
                return _newSceneMainMenu1Button1Label;
            }
        }

        private static Template _newSceneMainMenu1Button2;
        public static Template NewSceneMainMenu1Button2
        {
            get
            {
#if UNITY_EDITOR
                if (_newSceneMainMenu1Button2 == null || _newSceneMainMenu1Button2.CurrentVersion != Template.Version)
#else
                if (_newSceneMainMenu1Button2 == null)
#endif
                {
                    _newSceneMainMenu1Button2 = new Template(MainMenuTemplates.MainMenuButton2);
#if UNITY_EDITOR
                    _newSceneMainMenu1Button2.Name = "NewSceneMainMenu1Button2";
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_newSceneMainMenu1Button2, NewSceneMainMenu1Button2Label);
                }
                return _newSceneMainMenu1Button2;
            }
        }

        private static Template _newSceneMainMenu1Button2Label;
        public static Template NewSceneMainMenu1Button2Label
        {
            get
            {
#if UNITY_EDITOR
                if (_newSceneMainMenu1Button2Label == null || _newSceneMainMenu1Button2Label.CurrentVersion != Template.Version)
#else
                if (_newSceneMainMenu1Button2Label == null)
#endif
                {
                    _newSceneMainMenu1Button2Label = new Template(MainMenuTemplates.MainMenuButton2Label);
#if UNITY_EDITOR
                    _newSceneMainMenu1Button2Label.Name = "NewSceneMainMenu1Button2Label";
#endif
                }
                return _newSceneMainMenu1Button2Label;
            }
        }

        private static Template _newSceneMainMenu1Button3;
        public static Template NewSceneMainMenu1Button3
        {
            get
            {
#if UNITY_EDITOR
                if (_newSceneMainMenu1Button3 == null || _newSceneMainMenu1Button3.CurrentVersion != Template.Version)
#else
                if (_newSceneMainMenu1Button3 == null)
#endif
                {
                    _newSceneMainMenu1Button3 = new Template(MainMenuTemplates.MainMenuButton3);
#if UNITY_EDITOR
                    _newSceneMainMenu1Button3.Name = "NewSceneMainMenu1Button3";
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_newSceneMainMenu1Button3, NewSceneMainMenu1Button3Label);
                }
                return _newSceneMainMenu1Button3;
            }
        }

        private static Template _newSceneMainMenu1Button3Label;
        public static Template NewSceneMainMenu1Button3Label
        {
            get
            {
#if UNITY_EDITOR
                if (_newSceneMainMenu1Button3Label == null || _newSceneMainMenu1Button3Label.CurrentVersion != Template.Version)
#else
                if (_newSceneMainMenu1Button3Label == null)
#endif
                {
                    _newSceneMainMenu1Button3Label = new Template(MainMenuTemplates.MainMenuButton3Label);
#if UNITY_EDITOR
                    _newSceneMainMenu1Button3Label.Name = "NewSceneMainMenu1Button3Label";
#endif
                }
                return _newSceneMainMenu1Button3Label;
            }
        }

        #endregion
    }

    #endregion
}
