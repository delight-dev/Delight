// Internal view logic generated from "Aa.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class Aa : UIView
    {
        #region Constructors

        public Aa(View parent, View layoutParent = null, string id = null, Template template = null, bool deferInitialization = false) :
            base(parent, layoutParent, id, template ?? AaTemplates.Default, deferInitialization)
        {
            if (deferInitialization)
                return;

            // constructing Group (Group1)
            Group1 = new Group(this, this, "Group1", Group1Template);
            Label1 = new Label(this, Group1.Content, "Label1", Label1Template);

            // binding <Label Text="{@TestBinding1}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> {  }, new List<Func<BindableObject>> {  }) }, new BindingPath(new List<string> { "Label1", "Text" }, new List<Func<BindableObject>> { () => this, () => Label1 }), () => Label1.Text = Models.TestBinding1, () => { }, false));
            Label2 = new Label(this, Group1.Content, "Label2", Label2Template);

            // binding <Label Text="{@Player1.Name}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "Name" }, new List<Func<BindableObject>> { () => Models.Player1 }) }, new BindingPath(new List<string> { "Label2", "Text" }, new List<Func<BindableObject>> { () => this, () => Label2 }), () => Label2.Text = Models.Player1.Name, () => { }, false));
            this.AfterInitializeInternal();
        }

        public Aa() : this(null)
        {
        }

        static Aa()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(AaTemplates.Default, dependencyProperties);

            dependencyProperties.Add(Group1Property);
            dependencyProperties.Add(Group1TemplateProperty);
            dependencyProperties.Add(Label1Property);
            dependencyProperties.Add(Label1TemplateProperty);
            dependencyProperties.Add(Label2Property);
            dependencyProperties.Add(Label2TemplateProperty);
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

        public readonly static DependencyProperty<Label> Label2Property = new DependencyProperty<Label>("Label2");
        public Label Label2
        {
            get { return Label2Property.GetValue(this); }
            set { Label2Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Label2TemplateProperty = new DependencyProperty<Template>("Label2Template");
        public Template Label2Template
        {
            get { return Label2TemplateProperty.GetValue(this); }
            set { Label2TemplateProperty.SetValue(this, value); }
        }

        #endregion
    }

    #region Data Templates

    public static class AaTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return Aa;
            }
        }

        private static Template _aa;
        public static Template Aa
        {
            get
            {
#if UNITY_EDITOR
                if (_aa == null || _aa.CurrentVersion != Template.Version)
#else
                if (_aa == null)
#endif
                {
                    _aa = new Template(UIViewTemplates.UIView);
#if UNITY_EDITOR
                    _aa.Name = "Aa";
#endif
                    Delight.Aa.Group1TemplateProperty.SetDefault(_aa, AaGroup1);
                    Delight.Aa.Label1TemplateProperty.SetDefault(_aa, AaLabel1);
                    Delight.Aa.Label2TemplateProperty.SetDefault(_aa, AaLabel2);
                }
                return _aa;
            }
        }

        private static Template _aaGroup1;
        public static Template AaGroup1
        {
            get
            {
#if UNITY_EDITOR
                if (_aaGroup1 == null || _aaGroup1.CurrentVersion != Template.Version)
#else
                if (_aaGroup1 == null)
#endif
                {
                    _aaGroup1 = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _aaGroup1.Name = "AaGroup1";
#endif
                }
                return _aaGroup1;
            }
        }

        private static Template _aaLabel1;
        public static Template AaLabel1
        {
            get
            {
#if UNITY_EDITOR
                if (_aaLabel1 == null || _aaLabel1.CurrentVersion != Template.Version)
#else
                if (_aaLabel1 == null)
#endif
                {
                    _aaLabel1 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _aaLabel1.Name = "AaLabel1";
#endif
                    Delight.Label.TextProperty.SetHasBinding(_aaLabel1);
                }
                return _aaLabel1;
            }
        }

        private static Template _aaLabel2;
        public static Template AaLabel2
        {
            get
            {
#if UNITY_EDITOR
                if (_aaLabel2 == null || _aaLabel2.CurrentVersion != Template.Version)
#else
                if (_aaLabel2 == null)
#endif
                {
                    _aaLabel2 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _aaLabel2.Name = "AaLabel2";
#endif
                    Delight.Label.TextProperty.SetHasBinding(_aaLabel2);
                }
                return _aaLabel2;
            }
        }

        #endregion
    }

    #endregion
}
