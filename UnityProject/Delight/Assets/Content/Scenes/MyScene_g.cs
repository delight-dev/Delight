// Internal view logic generated from "MyScene.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class MyScene : UIView
    {
        #region Constructors

        public MyScene(View parent, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :
            base(parent, layoutParent, id, template ?? MySceneTemplates.Default, initializer)
        {
            // constructing Label (Label1)
            Label1 = new Label(this, this, "Label1", Label1Template);
            this.AfterInitializeInternal();
        }

        public MyScene() : this(null)
        {
        }

        static MyScene()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(MySceneTemplates.Default, dependencyProperties);

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

    public static class MySceneTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return MyScene;
            }
        }

        private static Template _myScene;
        public static Template MyScene
        {
            get
            {
#if UNITY_EDITOR
                if (_myScene == null || _myScene.CurrentVersion != Template.Version)
#else
                if (_myScene == null)
#endif
                {
                    _myScene = new Template(UIViewTemplates.UIView);
#if UNITY_EDITOR
                    _myScene.Name = "MyScene";
#endif
                    Delight.MyScene.Label1TemplateProperty.SetDefault(_myScene, MySceneLabel1);
                }
                return _myScene;
            }
        }

        private static Template _mySceneLabel1;
        public static Template MySceneLabel1
        {
            get
            {
#if UNITY_EDITOR
                if (_mySceneLabel1 == null || _mySceneLabel1.CurrentVersion != Template.Version)
#else
                if (_mySceneLabel1 == null)
#endif
                {
                    _mySceneLabel1 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _mySceneLabel1.Name = "MySceneLabel1";
#endif
                    Delight.Label.TextProperty.SetDefault(_mySceneLabel1, "My first scene :)");
                    Delight.Label.FontColorProperty.SetDefault(_mySceneLabel1, new UnityEngine.Color(1f, 1f, 1f, 1f));
                }
                return _mySceneLabel1;
            }
        }

        #endregion
    }

    #endregion
}
