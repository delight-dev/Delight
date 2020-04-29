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

        public NewScene(View parent, View layoutParent = null, string id = null, Template template = null, bool deferInitialization = false) :
            base(parent, layoutParent, id, template ?? NewSceneTemplates.Default, deferInitialization)
        {
            if (deferInitialization)
                return;

            // constructing Label (Label1)
            Label1 = new Label(this, this, "Label1", Label1Template);
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

        #endregion
    }

    #endregion
}
