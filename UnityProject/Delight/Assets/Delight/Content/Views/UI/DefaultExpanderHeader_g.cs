// Internal view logic generated from "DefaultExpanderHeader.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class DefaultExpanderHeader : ExpanderHeader
    {
        #region Constructors

        public DefaultExpanderHeader(View parent, View layoutParent = null, string id = null, Template template = null, bool deferInitialization = false) :
            base(parent, layoutParent, id, template ?? DefaultExpanderHeaderTemplates.Default, deferInitialization)
        {
            if (deferInitialization)
                return;

            // constructing Group (HeaderGroup)
            HeaderGroup = new Group(this, this, "HeaderGroup", HeaderGroupTemplate);
            HeaderIcon = new Image(this, HeaderGroup.Content, "HeaderIcon", HeaderIconTemplate);

            // binding <Image Sprite="{Sprite}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "Sprite" }, new List<Func<BindableObject>> { () => this }) }, new BindingPath(new List<string> { "HeaderIcon", "Sprite" }, new List<Func<BindableObject>> { () => this, () => HeaderIcon }), () => HeaderIcon.Sprite = Sprite, () => { }, false));
            HeaderLabel = new Label(this, HeaderGroup.Content, "HeaderLabel", HeaderLabelTemplate);

            // binding <Label Text="{Text}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "Text" }, new List<Func<BindableObject>> { () => this }) }, new BindingPath(new List<string> { "HeaderLabel", "Text" }, new List<Func<BindableObject>> { () => this, () => HeaderLabel }), () => HeaderLabel.Text = Text, () => { }, false));
            this.AfterInitializeInternal();
        }

        public DefaultExpanderHeader() : this(null)
        {
        }

        static DefaultExpanderHeader()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(DefaultExpanderHeaderTemplates.Default, dependencyProperties);

            dependencyProperties.Add(HeaderGroupProperty);
            dependencyProperties.Add(HeaderGroupTemplateProperty);
            dependencyProperties.Add(HeaderIconProperty);
            dependencyProperties.Add(HeaderIconTemplateProperty);
            dependencyProperties.Add(HeaderLabelProperty);
            dependencyProperties.Add(HeaderLabelTemplateProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<Group> HeaderGroupProperty = new DependencyProperty<Group>("HeaderGroup");
        public Group HeaderGroup
        {
            get { return HeaderGroupProperty.GetValue(this); }
            set { HeaderGroupProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> HeaderGroupTemplateProperty = new DependencyProperty<Template>("HeaderGroupTemplate");
        public Template HeaderGroupTemplate
        {
            get { return HeaderGroupTemplateProperty.GetValue(this); }
            set { HeaderGroupTemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Image> HeaderIconProperty = new DependencyProperty<Image>("HeaderIcon");
        public Image HeaderIcon
        {
            get { return HeaderIconProperty.GetValue(this); }
            set { HeaderIconProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> HeaderIconTemplateProperty = new DependencyProperty<Template>("HeaderIconTemplate");
        public Template HeaderIconTemplate
        {
            get { return HeaderIconTemplateProperty.GetValue(this); }
            set { HeaderIconTemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Label> HeaderLabelProperty = new DependencyProperty<Label>("HeaderLabel");
        public Label HeaderLabel
        {
            get { return HeaderLabelProperty.GetValue(this); }
            set { HeaderLabelProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> HeaderLabelTemplateProperty = new DependencyProperty<Template>("HeaderLabelTemplate");
        public Template HeaderLabelTemplate
        {
            get { return HeaderLabelTemplateProperty.GetValue(this); }
            set { HeaderLabelTemplateProperty.SetValue(this, value); }
        }

        #endregion
    }

    #region Data Templates

    public static class DefaultExpanderHeaderTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return DefaultExpanderHeader;
            }
        }

        private static Template _defaultExpanderHeader;
        public static Template DefaultExpanderHeader
        {
            get
            {
#if UNITY_EDITOR
                if (_defaultExpanderHeader == null || _defaultExpanderHeader.CurrentVersion != Template.Version)
#else
                if (_defaultExpanderHeader == null)
#endif
                {
                    _defaultExpanderHeader = new Template(ExpanderHeaderTemplates.ExpanderHeader);
#if UNITY_EDITOR
                    _defaultExpanderHeader.Name = "DefaultExpanderHeader";
                    _defaultExpanderHeader.LineNumber = 0;
                    _defaultExpanderHeader.LinePosition = 0;
#endif
                    Delight.DefaultExpanderHeader.HeightProperty.SetDefault(_defaultExpanderHeader, new ElementSize(20f, ElementSizeUnit.Pixels));
                    Delight.DefaultExpanderHeader.HeaderGroupTemplateProperty.SetDefault(_defaultExpanderHeader, DefaultExpanderHeaderHeaderGroup);
                    Delight.DefaultExpanderHeader.HeaderIconTemplateProperty.SetDefault(_defaultExpanderHeader, DefaultExpanderHeaderHeaderIcon);
                    Delight.DefaultExpanderHeader.HeaderLabelTemplateProperty.SetDefault(_defaultExpanderHeader, DefaultExpanderHeaderHeaderLabel);
                }
                return _defaultExpanderHeader;
            }
        }

        private static Template _defaultExpanderHeaderHeaderGroup;
        public static Template DefaultExpanderHeaderHeaderGroup
        {
            get
            {
#if UNITY_EDITOR
                if (_defaultExpanderHeaderHeaderGroup == null || _defaultExpanderHeaderHeaderGroup.CurrentVersion != Template.Version)
#else
                if (_defaultExpanderHeaderHeaderGroup == null)
#endif
                {
                    _defaultExpanderHeaderHeaderGroup = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _defaultExpanderHeaderHeaderGroup.Name = "DefaultExpanderHeaderHeaderGroup";
                    _defaultExpanderHeaderHeaderGroup.LineNumber = 3;
                    _defaultExpanderHeaderHeaderGroup.LinePosition = 4;
#endif
                    Delight.Group.OrientationProperty.SetDefault(_defaultExpanderHeaderHeaderGroup, Delight.ElementOrientation.Horizontal);
                    Delight.Group.SpacingProperty.SetDefault(_defaultExpanderHeaderHeaderGroup, new ElementSize(5f, ElementSizeUnit.Pixels));
                    Delight.Group.AlignmentProperty.SetDefault(_defaultExpanderHeaderHeaderGroup, Delight.ElementAlignment.TopLeft);
                }
                return _defaultExpanderHeaderHeaderGroup;
            }
        }

        private static Template _defaultExpanderHeaderHeaderIcon;
        public static Template DefaultExpanderHeaderHeaderIcon
        {
            get
            {
#if UNITY_EDITOR
                if (_defaultExpanderHeaderHeaderIcon == null || _defaultExpanderHeaderHeaderIcon.CurrentVersion != Template.Version)
#else
                if (_defaultExpanderHeaderHeaderIcon == null)
#endif
                {
                    _defaultExpanderHeaderHeaderIcon = new Template(ImageTemplates.Image);
#if UNITY_EDITOR
                    _defaultExpanderHeaderHeaderIcon.Name = "DefaultExpanderHeaderHeaderIcon";
                    _defaultExpanderHeaderHeaderIcon.LineNumber = 4;
                    _defaultExpanderHeaderHeaderIcon.LinePosition = 6;
#endif
                    Delight.Image.SpriteProperty.SetHasBinding(_defaultExpanderHeaderHeaderIcon);
                }
                return _defaultExpanderHeaderHeaderIcon;
            }
        }

        private static Template _defaultExpanderHeaderHeaderLabel;
        public static Template DefaultExpanderHeaderHeaderLabel
        {
            get
            {
#if UNITY_EDITOR
                if (_defaultExpanderHeaderHeaderLabel == null || _defaultExpanderHeaderHeaderLabel.CurrentVersion != Template.Version)
#else
                if (_defaultExpanderHeaderHeaderLabel == null)
#endif
                {
                    _defaultExpanderHeaderHeaderLabel = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _defaultExpanderHeaderHeaderLabel.Name = "DefaultExpanderHeaderHeaderLabel";
                    _defaultExpanderHeaderHeaderLabel.LineNumber = 5;
                    _defaultExpanderHeaderHeaderLabel.LinePosition = 6;
#endif
                    Delight.Label.AutoSizeProperty.SetDefault(_defaultExpanderHeaderHeaderLabel, Delight.AutoSize.Default);
                    Delight.Label.TextProperty.SetHasBinding(_defaultExpanderHeaderHeaderLabel);
                }
                return _defaultExpanderHeaderHeaderLabel;
            }
        }

        #endregion
    }

    #endregion
}
