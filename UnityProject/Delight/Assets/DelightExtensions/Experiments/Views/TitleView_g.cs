// Internal view logic generated from "TitleView.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class TitleView : UIView
    {
        #region Constructors

        public TitleView(View parent, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :
            base(parent, layoutParent, id, template ?? TitleViewTemplates.Default, initializer)
        {
            // constructing Button (Button1)
            Button1 = new Button(this, this, "Button1", Button1Template);

            // binding <Button Text="{Title}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "Title" }, new List<Func<BindableObject>> { () => this }) }, new BindingPath(new List<string> { "Button1", "Text" }, new List<Func<BindableObject>> { () => this, () => Button1 }), () => Button1.Text = Title, () => { }, false));
            this.AfterInitializeInternal();
        }

        public TitleView() : this(null)
        {
        }

        static TitleView()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(TitleViewTemplates.Default, dependencyProperties);

            dependencyProperties.Add(TitleProperty);
            dependencyProperties.Add(Button1Property);
            dependencyProperties.Add(Button1TemplateProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<System.String> TitleProperty = new DependencyProperty<System.String>("Title");
        public System.String Title
        {
            get { return TitleProperty.GetValue(this); }
            set { TitleProperty.SetValue(this, value); }
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

        #endregion
    }

    #region Data Templates

    public static class TitleViewTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return TitleView;
            }
        }

        private static Template _titleView;
        public static Template TitleView
        {
            get
            {
#if UNITY_EDITOR
                if (_titleView == null || _titleView.CurrentVersion != Template.Version)
#else
                if (_titleView == null)
#endif
                {
                    _titleView = new Template(UIViewTemplates.UIView);
#if UNITY_EDITOR
                    _titleView.Name = "TitleView";
#endif
                    Delight.TitleView.Button1TemplateProperty.SetDefault(_titleView, TitleViewButton1);
                }
                return _titleView;
            }
        }

        private static Template _titleViewButton1;
        public static Template TitleViewButton1
        {
            get
            {
#if UNITY_EDITOR
                if (_titleViewButton1 == null || _titleViewButton1.CurrentVersion != Template.Version)
#else
                if (_titleViewButton1 == null)
#endif
                {
                    _titleViewButton1 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _titleViewButton1.Name = "TitleViewButton1";
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_titleViewButton1, TitleViewButton1Label);
                }
                return _titleViewButton1;
            }
        }

        private static Template _titleViewButton1Label;
        public static Template TitleViewButton1Label
        {
            get
            {
#if UNITY_EDITOR
                if (_titleViewButton1Label == null || _titleViewButton1Label.CurrentVersion != Template.Version)
#else
                if (_titleViewButton1Label == null)
#endif
                {
                    _titleViewButton1Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _titleViewButton1Label.Name = "TitleViewButton1Label";
#endif
                    Delight.Label.TextProperty.SetHasBinding(_titleViewButton1Label);
                }
                return _titleViewButton1Label;
            }
        }

        #endregion
    }

    #endregion
}
