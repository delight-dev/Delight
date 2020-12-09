#if DELIGHT_MODULE_PLAYFAB

// Internal view logic generated from "PlayFabDemo.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class PlayFabDemo : LayoutRoot
    {
        #region Constructors

        public PlayFabDemo(View parent, View layoutParent = null, string id = null, Template template = null, bool deferInitialization = false) :
            base(parent, layoutParent, id, template ?? PlayFabDemoTemplates.Default, deferInitialization)
        {
            if (deferInitialization)
                return;

            // constructing Grid (Grid1)
            Grid1 = new LayoutGrid(this, this, "Grid1", Grid1Template);
            Group1 = new Group(this, Grid1.Content, "Group1", Group1Template);
            Grid1.Cell.SetValue(Group1, new CellIndex(0, 0));
            Label1 = new Label(this, Group1.Content, "Label1", Label1Template);
            ToggleGroup1 = new ToggleGroup(this, Group1.Content, "ToggleGroup1", ToggleGroup1Template);
            Button1 = new Button(this, ToggleGroup1.Content, "Button1", Button1Template);
            Button1.Click.RegisterHandler(() => FeatureNavigator.Open("/Login"));
            Button2 = new Button(this, ToggleGroup1.Content, "Button2", Button2Template);
            Button2.Click.RegisterHandler(() => FeatureNavigator.Open("/Register"));
            Button3 = new Button(this, ToggleGroup1.Content, "Button3", Button3Template);
            Button3.Click.RegisterHandler(() => FeatureNavigator.Open("/PlayerProfile"));
            Button4 = new Button(this, ToggleGroup1.Content, "Button4", Button4Template);
            Button4.Click.RegisterHandler(() => Application.Quit());
            FeatureNavigator = new Navigator(this, Grid1.Content, "FeatureNavigator", FeatureNavigatorTemplate);
            Grid1.Cell.SetValue(FeatureNavigator, new CellIndex(0, 1));
            PlayFabLogin1 = new PlayFabLogin(this, FeatureNavigator.Content, "PlayFabLogin1", PlayFabLogin1Template);
            FeatureNavigator.Path.SetValue(PlayFabLogin1, "/Login");
            PlayFabRegister1 = new PlayFabRegister(this, FeatureNavigator.Content, "PlayFabRegister1", PlayFabRegister1Template);
            FeatureNavigator.Path.SetValue(PlayFabRegister1, "/Register");
            PlayFabPlayerProfileDetail1 = new PlayFabPlayerProfileDetail(this, FeatureNavigator.Content, "PlayFabPlayerProfileDetail1", PlayFabPlayerProfileDetail1Template);
            FeatureNavigator.Path.SetValue(PlayFabPlayerProfileDetail1, "/PlayerProfile");
            this.AfterInitializeInternal();
        }

        public PlayFabDemo() : this(null)
        {
        }

        static PlayFabDemo()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(PlayFabDemoTemplates.Default, dependencyProperties);

            dependencyProperties.Add(Grid1Property);
            dependencyProperties.Add(Grid1TemplateProperty);
            dependencyProperties.Add(Group1Property);
            dependencyProperties.Add(Group1TemplateProperty);
            dependencyProperties.Add(Label1Property);
            dependencyProperties.Add(Label1TemplateProperty);
            dependencyProperties.Add(ToggleGroup1Property);
            dependencyProperties.Add(ToggleGroup1TemplateProperty);
            dependencyProperties.Add(Button1Property);
            dependencyProperties.Add(Button1TemplateProperty);
            dependencyProperties.Add(Button2Property);
            dependencyProperties.Add(Button2TemplateProperty);
            dependencyProperties.Add(Button3Property);
            dependencyProperties.Add(Button3TemplateProperty);
            dependencyProperties.Add(Button4Property);
            dependencyProperties.Add(Button4TemplateProperty);
            dependencyProperties.Add(FeatureNavigatorProperty);
            dependencyProperties.Add(FeatureNavigatorTemplateProperty);
            dependencyProperties.Add(PlayFabLogin1Property);
            dependencyProperties.Add(PlayFabLogin1TemplateProperty);
            dependencyProperties.Add(PlayFabRegister1Property);
            dependencyProperties.Add(PlayFabRegister1TemplateProperty);
            dependencyProperties.Add(PlayFabPlayerProfileDetail1Property);
            dependencyProperties.Add(PlayFabPlayerProfileDetail1TemplateProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<LayoutGrid> Grid1Property = new DependencyProperty<LayoutGrid>("Grid1");
        public LayoutGrid Grid1
        {
            get { return Grid1Property.GetValue(this); }
            set { Grid1Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Grid1TemplateProperty = new DependencyProperty<Template>("Grid1Template");
        public Template Grid1Template
        {
            get { return Grid1TemplateProperty.GetValue(this); }
            set { Grid1TemplateProperty.SetValue(this, value); }
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

        public readonly static DependencyProperty<ToggleGroup> ToggleGroup1Property = new DependencyProperty<ToggleGroup>("ToggleGroup1");
        public ToggleGroup ToggleGroup1
        {
            get { return ToggleGroup1Property.GetValue(this); }
            set { ToggleGroup1Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> ToggleGroup1TemplateProperty = new DependencyProperty<Template>("ToggleGroup1Template");
        public Template ToggleGroup1Template
        {
            get { return ToggleGroup1TemplateProperty.GetValue(this); }
            set { ToggleGroup1TemplateProperty.SetValue(this, value); }
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

        public readonly static DependencyProperty<Button> Button4Property = new DependencyProperty<Button>("Button4");
        public Button Button4
        {
            get { return Button4Property.GetValue(this); }
            set { Button4Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Button4TemplateProperty = new DependencyProperty<Template>("Button4Template");
        public Template Button4Template
        {
            get { return Button4TemplateProperty.GetValue(this); }
            set { Button4TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Navigator> FeatureNavigatorProperty = new DependencyProperty<Navigator>("FeatureNavigator");
        public Navigator FeatureNavigator
        {
            get { return FeatureNavigatorProperty.GetValue(this); }
            set { FeatureNavigatorProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> FeatureNavigatorTemplateProperty = new DependencyProperty<Template>("FeatureNavigatorTemplate");
        public Template FeatureNavigatorTemplate
        {
            get { return FeatureNavigatorTemplateProperty.GetValue(this); }
            set { FeatureNavigatorTemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<PlayFabLogin> PlayFabLogin1Property = new DependencyProperty<PlayFabLogin>("PlayFabLogin1");
        public PlayFabLogin PlayFabLogin1
        {
            get { return PlayFabLogin1Property.GetValue(this); }
            set { PlayFabLogin1Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> PlayFabLogin1TemplateProperty = new DependencyProperty<Template>("PlayFabLogin1Template");
        public Template PlayFabLogin1Template
        {
            get { return PlayFabLogin1TemplateProperty.GetValue(this); }
            set { PlayFabLogin1TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<PlayFabRegister> PlayFabRegister1Property = new DependencyProperty<PlayFabRegister>("PlayFabRegister1");
        public PlayFabRegister PlayFabRegister1
        {
            get { return PlayFabRegister1Property.GetValue(this); }
            set { PlayFabRegister1Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> PlayFabRegister1TemplateProperty = new DependencyProperty<Template>("PlayFabRegister1Template");
        public Template PlayFabRegister1Template
        {
            get { return PlayFabRegister1TemplateProperty.GetValue(this); }
            set { PlayFabRegister1TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<PlayFabPlayerProfileDetail> PlayFabPlayerProfileDetail1Property = new DependencyProperty<PlayFabPlayerProfileDetail>("PlayFabPlayerProfileDetail1");
        public PlayFabPlayerProfileDetail PlayFabPlayerProfileDetail1
        {
            get { return PlayFabPlayerProfileDetail1Property.GetValue(this); }
            set { PlayFabPlayerProfileDetail1Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> PlayFabPlayerProfileDetail1TemplateProperty = new DependencyProperty<Template>("PlayFabPlayerProfileDetail1Template");
        public Template PlayFabPlayerProfileDetail1Template
        {
            get { return PlayFabPlayerProfileDetail1TemplateProperty.GetValue(this); }
            set { PlayFabPlayerProfileDetail1TemplateProperty.SetValue(this, value); }
        }

        #endregion
    }

    #region Data Templates

    public static class PlayFabDemoTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return PlayFabDemo;
            }
        }

        private static Template _playFabDemo;
        public static Template PlayFabDemo
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemo == null || _playFabDemo.CurrentVersion != Template.Version)
#else
                if (_playFabDemo == null)
#endif
                {
                    _playFabDemo = new Template(LayoutRootTemplates.LayoutRoot);
#if UNITY_EDITOR
                    _playFabDemo.Name = "PlayFabDemo";
                    _playFabDemo.LineNumber = 0;
                    _playFabDemo.LinePosition = 0;
#endif
                    Delight.PlayFabDemo.Grid1TemplateProperty.SetDefault(_playFabDemo, PlayFabDemoGrid1);
                    Delight.PlayFabDemo.Group1TemplateProperty.SetDefault(_playFabDemo, PlayFabDemoGroup1);
                    Delight.PlayFabDemo.Label1TemplateProperty.SetDefault(_playFabDemo, PlayFabDemoLabel1);
                    Delight.PlayFabDemo.ToggleGroup1TemplateProperty.SetDefault(_playFabDemo, PlayFabDemoToggleGroup1);
                    Delight.PlayFabDemo.Button1TemplateProperty.SetDefault(_playFabDemo, PlayFabDemoButton1);
                    Delight.PlayFabDemo.Button2TemplateProperty.SetDefault(_playFabDemo, PlayFabDemoButton2);
                    Delight.PlayFabDemo.Button3TemplateProperty.SetDefault(_playFabDemo, PlayFabDemoButton3);
                    Delight.PlayFabDemo.Button4TemplateProperty.SetDefault(_playFabDemo, PlayFabDemoButton4);
                    Delight.PlayFabDemo.FeatureNavigatorTemplateProperty.SetDefault(_playFabDemo, PlayFabDemoFeatureNavigator);
                    Delight.PlayFabDemo.PlayFabLogin1TemplateProperty.SetDefault(_playFabDemo, PlayFabDemoPlayFabLogin1);
                    Delight.PlayFabDemo.PlayFabRegister1TemplateProperty.SetDefault(_playFabDemo, PlayFabDemoPlayFabRegister1);
                    Delight.PlayFabDemo.PlayFabPlayerProfileDetail1TemplateProperty.SetDefault(_playFabDemo, PlayFabDemoPlayFabPlayerProfileDetail1);
                }
                return _playFabDemo;
            }
        }

        private static Template _playFabDemoGrid1;
        public static Template PlayFabDemoGrid1
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoGrid1 == null || _playFabDemoGrid1.CurrentVersion != Template.Version)
#else
                if (_playFabDemoGrid1 == null)
#endif
                {
                    _playFabDemoGrid1 = new Template(LayoutGridTemplates.LayoutGrid);
#if UNITY_EDITOR
                    _playFabDemoGrid1.Name = "PlayFabDemoGrid1";
                    _playFabDemoGrid1.LineNumber = 4;
                    _playFabDemoGrid1.LinePosition = 4;
#endif
                    Delight.LayoutGrid.ColumnsProperty.SetDefault(_playFabDemoGrid1, new ColumnDefinitions { new ColumnDefinition(new ElementSize(300f, ElementSizeUnit.Pixels)), new ColumnDefinition(new ElementSize(1f, ElementSizeUnit.Proportional))});
                }
                return _playFabDemoGrid1;
            }
        }

        private static Template _playFabDemoGroup1;
        public static Template PlayFabDemoGroup1
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoGroup1 == null || _playFabDemoGroup1.CurrentVersion != Template.Version)
#else
                if (_playFabDemoGroup1 == null)
#endif
                {
                    _playFabDemoGroup1 = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _playFabDemoGroup1.Name = "PlayFabDemoGroup1";
                    _playFabDemoGroup1.LineNumber = 6;
                    _playFabDemoGroup1.LinePosition = 6;
#endif
                    Delight.Group.MarginProperty.SetDefault(_playFabDemoGroup1, new ElementMargin(new ElementSize(10f, ElementSizeUnit.Pixels)));
                    Delight.Group.SpacingProperty.SetDefault(_playFabDemoGroup1, new ElementSize(10f, ElementSizeUnit.Pixels));
                }
                return _playFabDemoGroup1;
            }
        }

        private static Template _playFabDemoLabel1;
        public static Template PlayFabDemoLabel1
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoLabel1 == null || _playFabDemoLabel1.CurrentVersion != Template.Version)
#else
                if (_playFabDemoLabel1 == null)
#endif
                {
                    _playFabDemoLabel1 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _playFabDemoLabel1.Name = "PlayFabDemoLabel1";
                    _playFabDemoLabel1.LineNumber = 7;
                    _playFabDemoLabel1.LinePosition = 8;
#endif
                    Delight.Label.TextProperty.SetDefault(_playFabDemoLabel1, "PlayFab features");
                    Delight.Label.AutoSizeProperty.SetDefault(_playFabDemoLabel1, Delight.AutoSize.Default);
                    Delight.Label.FontSizeProperty.SetDefault(_playFabDemoLabel1, 30f);
                    Delight.Label.FontColorProperty.SetDefault(_playFabDemoLabel1, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Label.FontProperty.SetDefault(_playFabDemoLabel1, Assets.TMP_FontAssets["Segoe UI SDF"]);
                    Delight.Label.AlignmentProperty.SetDefault(_playFabDemoLabel1, Delight.ElementAlignment.Left);
                }
                return _playFabDemoLabel1;
            }
        }

        private static Template _playFabDemoToggleGroup1;
        public static Template PlayFabDemoToggleGroup1
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoToggleGroup1 == null || _playFabDemoToggleGroup1.CurrentVersion != Template.Version)
#else
                if (_playFabDemoToggleGroup1 == null)
#endif
                {
                    _playFabDemoToggleGroup1 = new Template(ToggleGroupTemplates.ToggleGroup);
#if UNITY_EDITOR
                    _playFabDemoToggleGroup1.Name = "PlayFabDemoToggleGroup1";
                    _playFabDemoToggleGroup1.LineNumber = 8;
                    _playFabDemoToggleGroup1.LinePosition = 8;
#endif
                    Delight.ToggleGroup.SpacingProperty.SetDefault(_playFabDemoToggleGroup1, new ElementSize(5f, ElementSizeUnit.Pixels));
                    Delight.ToggleGroup.AlignmentProperty.SetDefault(_playFabDemoToggleGroup1, Delight.ElementAlignment.Left);
                    Delight.ToggleGroup.ContentAlignmentProperty.SetDefault(_playFabDemoToggleGroup1, Delight.ElementAlignment.Left);
                }
                return _playFabDemoToggleGroup1;
            }
        }

        private static Template _playFabDemoButton1;
        public static Template PlayFabDemoButton1
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoButton1 == null || _playFabDemoButton1.CurrentVersion != Template.Version)
#else
                if (_playFabDemoButton1 == null)
#endif
                {
                    _playFabDemoButton1 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _playFabDemoButton1.Name = "PlayFabDemoButton1";
                    _playFabDemoButton1.LineNumber = 9;
                    _playFabDemoButton1.LinePosition = 10;
#endif
                    Delight.Button.ToggleValueProperty.SetDefault(_playFabDemoButton1, true);
                    Delight.Button.WidthProperty.SetDefault(_playFabDemoButton1, new ElementSize(200f, ElementSizeUnit.Pixels));
                    Delight.Button.LabelTemplateProperty.SetDefault(_playFabDemoButton1, PlayFabDemoButton1Label);
                }
                return _playFabDemoButton1;
            }
        }

        private static Template _playFabDemoButton1Label;
        public static Template PlayFabDemoButton1Label
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoButton1Label == null || _playFabDemoButton1Label.CurrentVersion != Template.Version)
#else
                if (_playFabDemoButton1Label == null)
#endif
                {
                    _playFabDemoButton1Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _playFabDemoButton1Label.Name = "PlayFabDemoButton1Label";
                    _playFabDemoButton1Label.LineNumber = 15;
                    _playFabDemoButton1Label.LinePosition = 4;
#endif
                    Delight.Label.TextProperty.SetDefault(_playFabDemoButton1Label, "Log in");
                }
                return _playFabDemoButton1Label;
            }
        }

        private static Template _playFabDemoButton2;
        public static Template PlayFabDemoButton2
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoButton2 == null || _playFabDemoButton2.CurrentVersion != Template.Version)
#else
                if (_playFabDemoButton2 == null)
#endif
                {
                    _playFabDemoButton2 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _playFabDemoButton2.Name = "PlayFabDemoButton2";
                    _playFabDemoButton2.LineNumber = 10;
                    _playFabDemoButton2.LinePosition = 10;
#endif
                    Delight.Button.WidthProperty.SetDefault(_playFabDemoButton2, new ElementSize(200f, ElementSizeUnit.Pixels));
                    Delight.Button.LabelTemplateProperty.SetDefault(_playFabDemoButton2, PlayFabDemoButton2Label);
                }
                return _playFabDemoButton2;
            }
        }

        private static Template _playFabDemoButton2Label;
        public static Template PlayFabDemoButton2Label
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoButton2Label == null || _playFabDemoButton2Label.CurrentVersion != Template.Version)
#else
                if (_playFabDemoButton2Label == null)
#endif
                {
                    _playFabDemoButton2Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _playFabDemoButton2Label.Name = "PlayFabDemoButton2Label";
                    _playFabDemoButton2Label.LineNumber = 15;
                    _playFabDemoButton2Label.LinePosition = 4;
#endif
                    Delight.Label.TextProperty.SetDefault(_playFabDemoButton2Label, "Register new user");
                }
                return _playFabDemoButton2Label;
            }
        }

        private static Template _playFabDemoButton3;
        public static Template PlayFabDemoButton3
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoButton3 == null || _playFabDemoButton3.CurrentVersion != Template.Version)
#else
                if (_playFabDemoButton3 == null)
#endif
                {
                    _playFabDemoButton3 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _playFabDemoButton3.Name = "PlayFabDemoButton3";
                    _playFabDemoButton3.LineNumber = 11;
                    _playFabDemoButton3.LinePosition = 10;
#endif
                    Delight.Button.WidthProperty.SetDefault(_playFabDemoButton3, new ElementSize(200f, ElementSizeUnit.Pixels));
                    Delight.Button.LabelTemplateProperty.SetDefault(_playFabDemoButton3, PlayFabDemoButton3Label);
                }
                return _playFabDemoButton3;
            }
        }

        private static Template _playFabDemoButton3Label;
        public static Template PlayFabDemoButton3Label
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoButton3Label == null || _playFabDemoButton3Label.CurrentVersion != Template.Version)
#else
                if (_playFabDemoButton3Label == null)
#endif
                {
                    _playFabDemoButton3Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _playFabDemoButton3Label.Name = "PlayFabDemoButton3Label";
                    _playFabDemoButton3Label.LineNumber = 15;
                    _playFabDemoButton3Label.LinePosition = 4;
#endif
                    Delight.Label.TextProperty.SetDefault(_playFabDemoButton3Label, "Player profile");
                }
                return _playFabDemoButton3Label;
            }
        }

        private static Template _playFabDemoButton4;
        public static Template PlayFabDemoButton4
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoButton4 == null || _playFabDemoButton4.CurrentVersion != Template.Version)
#else
                if (_playFabDemoButton4 == null)
#endif
                {
                    _playFabDemoButton4 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _playFabDemoButton4.Name = "PlayFabDemoButton4";
                    _playFabDemoButton4.LineNumber = 12;
                    _playFabDemoButton4.LinePosition = 10;
#endif
                    Delight.Button.WidthProperty.SetDefault(_playFabDemoButton4, new ElementSize(200f, ElementSizeUnit.Pixels));
                    Delight.Button.LabelTemplateProperty.SetDefault(_playFabDemoButton4, PlayFabDemoButton4Label);
                }
                return _playFabDemoButton4;
            }
        }

        private static Template _playFabDemoButton4Label;
        public static Template PlayFabDemoButton4Label
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoButton4Label == null || _playFabDemoButton4Label.CurrentVersion != Template.Version)
#else
                if (_playFabDemoButton4Label == null)
#endif
                {
                    _playFabDemoButton4Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _playFabDemoButton4Label.Name = "PlayFabDemoButton4Label";
                    _playFabDemoButton4Label.LineNumber = 15;
                    _playFabDemoButton4Label.LinePosition = 4;
#endif
                    Delight.Label.TextProperty.SetDefault(_playFabDemoButton4Label, "Exit");
                }
                return _playFabDemoButton4Label;
            }
        }

        private static Template _playFabDemoFeatureNavigator;
        public static Template PlayFabDemoFeatureNavigator
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoFeatureNavigator == null || _playFabDemoFeatureNavigator.CurrentVersion != Template.Version)
#else
                if (_playFabDemoFeatureNavigator == null)
#endif
                {
                    _playFabDemoFeatureNavigator = new Template(NavigatorTemplates.Navigator);
#if UNITY_EDITOR
                    _playFabDemoFeatureNavigator.Name = "PlayFabDemoFeatureNavigator";
                    _playFabDemoFeatureNavigator.LineNumber = 16;
                    _playFabDemoFeatureNavigator.LinePosition = 6;
#endif
                }
                return _playFabDemoFeatureNavigator;
            }
        }

        private static Template _playFabDemoPlayFabLogin1;
        public static Template PlayFabDemoPlayFabLogin1
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoPlayFabLogin1 == null || _playFabDemoPlayFabLogin1.CurrentVersion != Template.Version)
#else
                if (_playFabDemoPlayFabLogin1 == null)
#endif
                {
                    _playFabDemoPlayFabLogin1 = new Template(PlayFabLoginTemplates.PlayFabLogin);
#if UNITY_EDITOR
                    _playFabDemoPlayFabLogin1.Name = "PlayFabDemoPlayFabLogin1";
                    _playFabDemoPlayFabLogin1.LineNumber = 17;
                    _playFabDemoPlayFabLogin1.LinePosition = 8;
#endif
                    Delight.PlayFabLogin.Grid1TemplateProperty.SetDefault(_playFabDemoPlayFabLogin1, PlayFabDemoPlayFabLogin1Grid1);
                    Delight.PlayFabLogin.Region1TemplateProperty.SetDefault(_playFabDemoPlayFabLogin1, PlayFabDemoPlayFabLogin1Region1);
                    Delight.PlayFabLogin.Group1TemplateProperty.SetDefault(_playFabDemoPlayFabLogin1, PlayFabDemoPlayFabLogin1Group1);
                    Delight.PlayFabLogin.Label1TemplateProperty.SetDefault(_playFabDemoPlayFabLogin1, PlayFabDemoPlayFabLogin1Label1);
                    Delight.PlayFabLogin.Label2TemplateProperty.SetDefault(_playFabDemoPlayFabLogin1, PlayFabDemoPlayFabLogin1Label2);
                    Delight.PlayFabLogin.InputField1TemplateProperty.SetDefault(_playFabDemoPlayFabLogin1, PlayFabDemoPlayFabLogin1InputField1);
                    Delight.PlayFabLogin.Label3TemplateProperty.SetDefault(_playFabDemoPlayFabLogin1, PlayFabDemoPlayFabLogin1Label3);
                    Delight.PlayFabLogin.InputField2TemplateProperty.SetDefault(_playFabDemoPlayFabLogin1, PlayFabDemoPlayFabLogin1InputField2);
                    Delight.PlayFabLogin.Button1TemplateProperty.SetDefault(_playFabDemoPlayFabLogin1, PlayFabDemoPlayFabLogin1Button1);
                    Delight.PlayFabLogin.Label4TemplateProperty.SetDefault(_playFabDemoPlayFabLogin1, PlayFabDemoPlayFabLogin1Label4);
                    Delight.PlayFabLogin.Group2TemplateProperty.SetDefault(_playFabDemoPlayFabLogin1, PlayFabDemoPlayFabLogin1Group2);
                    Delight.PlayFabLogin.Button2TemplateProperty.SetDefault(_playFabDemoPlayFabLogin1, PlayFabDemoPlayFabLogin1Button2);
                }
                return _playFabDemoPlayFabLogin1;
            }
        }

        private static Template _playFabDemoPlayFabLogin1Grid1;
        public static Template PlayFabDemoPlayFabLogin1Grid1
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoPlayFabLogin1Grid1 == null || _playFabDemoPlayFabLogin1Grid1.CurrentVersion != Template.Version)
#else
                if (_playFabDemoPlayFabLogin1Grid1 == null)
#endif
                {
                    _playFabDemoPlayFabLogin1Grid1 = new Template(PlayFabLoginTemplates.PlayFabLoginGrid1);
#if UNITY_EDITOR
                    _playFabDemoPlayFabLogin1Grid1.Name = "PlayFabDemoPlayFabLogin1Grid1";
                    _playFabDemoPlayFabLogin1Grid1.LineNumber = 4;
                    _playFabDemoPlayFabLogin1Grid1.LinePosition = 4;
#endif
                }
                return _playFabDemoPlayFabLogin1Grid1;
            }
        }

        private static Template _playFabDemoPlayFabLogin1Region1;
        public static Template PlayFabDemoPlayFabLogin1Region1
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoPlayFabLogin1Region1 == null || _playFabDemoPlayFabLogin1Region1.CurrentVersion != Template.Version)
#else
                if (_playFabDemoPlayFabLogin1Region1 == null)
#endif
                {
                    _playFabDemoPlayFabLogin1Region1 = new Template(PlayFabLoginTemplates.PlayFabLoginRegion1);
#if UNITY_EDITOR
                    _playFabDemoPlayFabLogin1Region1.Name = "PlayFabDemoPlayFabLogin1Region1";
                    _playFabDemoPlayFabLogin1Region1.LineNumber = 7;
                    _playFabDemoPlayFabLogin1Region1.LinePosition = 6;
#endif
                }
                return _playFabDemoPlayFabLogin1Region1;
            }
        }

        private static Template _playFabDemoPlayFabLogin1Group1;
        public static Template PlayFabDemoPlayFabLogin1Group1
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoPlayFabLogin1Group1 == null || _playFabDemoPlayFabLogin1Group1.CurrentVersion != Template.Version)
#else
                if (_playFabDemoPlayFabLogin1Group1 == null)
#endif
                {
                    _playFabDemoPlayFabLogin1Group1 = new Template(PlayFabLoginTemplates.PlayFabLoginGroup1);
#if UNITY_EDITOR
                    _playFabDemoPlayFabLogin1Group1.Name = "PlayFabDemoPlayFabLogin1Group1";
                    _playFabDemoPlayFabLogin1Group1.LineNumber = 8;
                    _playFabDemoPlayFabLogin1Group1.LinePosition = 8;
#endif
                }
                return _playFabDemoPlayFabLogin1Group1;
            }
        }

        private static Template _playFabDemoPlayFabLogin1Label1;
        public static Template PlayFabDemoPlayFabLogin1Label1
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoPlayFabLogin1Label1 == null || _playFabDemoPlayFabLogin1Label1.CurrentVersion != Template.Version)
#else
                if (_playFabDemoPlayFabLogin1Label1 == null)
#endif
                {
                    _playFabDemoPlayFabLogin1Label1 = new Template(PlayFabLoginTemplates.PlayFabLoginLabel1);
#if UNITY_EDITOR
                    _playFabDemoPlayFabLogin1Label1.Name = "PlayFabDemoPlayFabLogin1Label1";
                    _playFabDemoPlayFabLogin1Label1.LineNumber = 9;
                    _playFabDemoPlayFabLogin1Label1.LinePosition = 10;
#endif
                }
                return _playFabDemoPlayFabLogin1Label1;
            }
        }

        private static Template _playFabDemoPlayFabLogin1Label2;
        public static Template PlayFabDemoPlayFabLogin1Label2
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoPlayFabLogin1Label2 == null || _playFabDemoPlayFabLogin1Label2.CurrentVersion != Template.Version)
#else
                if (_playFabDemoPlayFabLogin1Label2 == null)
#endif
                {
                    _playFabDemoPlayFabLogin1Label2 = new Template(PlayFabLoginTemplates.PlayFabLoginLabel2);
#if UNITY_EDITOR
                    _playFabDemoPlayFabLogin1Label2.Name = "PlayFabDemoPlayFabLogin1Label2";
                    _playFabDemoPlayFabLogin1Label2.LineNumber = 10;
                    _playFabDemoPlayFabLogin1Label2.LinePosition = 10;
#endif
                }
                return _playFabDemoPlayFabLogin1Label2;
            }
        }

        private static Template _playFabDemoPlayFabLogin1InputField1;
        public static Template PlayFabDemoPlayFabLogin1InputField1
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoPlayFabLogin1InputField1 == null || _playFabDemoPlayFabLogin1InputField1.CurrentVersion != Template.Version)
#else
                if (_playFabDemoPlayFabLogin1InputField1 == null)
#endif
                {
                    _playFabDemoPlayFabLogin1InputField1 = new Template(PlayFabLoginTemplates.PlayFabLoginInputField1);
#if UNITY_EDITOR
                    _playFabDemoPlayFabLogin1InputField1.Name = "PlayFabDemoPlayFabLogin1InputField1";
                    _playFabDemoPlayFabLogin1InputField1.LineNumber = 11;
                    _playFabDemoPlayFabLogin1InputField1.LinePosition = 10;
#endif
                    Delight.InputField.InputFieldPlaceholderTemplateProperty.SetDefault(_playFabDemoPlayFabLogin1InputField1, PlayFabDemoPlayFabLogin1InputField1InputFieldPlaceholder);
                    Delight.InputField.TextAreaTemplateProperty.SetDefault(_playFabDemoPlayFabLogin1InputField1, PlayFabDemoPlayFabLogin1InputField1TextArea);
                    Delight.InputField.InputTextTemplateProperty.SetDefault(_playFabDemoPlayFabLogin1InputField1, PlayFabDemoPlayFabLogin1InputField1InputText);
                }
                return _playFabDemoPlayFabLogin1InputField1;
            }
        }

        private static Template _playFabDemoPlayFabLogin1InputField1InputFieldPlaceholder;
        public static Template PlayFabDemoPlayFabLogin1InputField1InputFieldPlaceholder
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoPlayFabLogin1InputField1InputFieldPlaceholder == null || _playFabDemoPlayFabLogin1InputField1InputFieldPlaceholder.CurrentVersion != Template.Version)
#else
                if (_playFabDemoPlayFabLogin1InputField1InputFieldPlaceholder == null)
#endif
                {
                    _playFabDemoPlayFabLogin1InputField1InputFieldPlaceholder = new Template(PlayFabLoginTemplates.PlayFabLoginInputField1InputFieldPlaceholder);
#if UNITY_EDITOR
                    _playFabDemoPlayFabLogin1InputField1InputFieldPlaceholder.Name = "PlayFabDemoPlayFabLogin1InputField1InputFieldPlaceholder";
                    _playFabDemoPlayFabLogin1InputField1InputFieldPlaceholder.LineNumber = 12;
                    _playFabDemoPlayFabLogin1InputField1InputFieldPlaceholder.LinePosition = 4;
#endif
                }
                return _playFabDemoPlayFabLogin1InputField1InputFieldPlaceholder;
            }
        }

        private static Template _playFabDemoPlayFabLogin1InputField1TextArea;
        public static Template PlayFabDemoPlayFabLogin1InputField1TextArea
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoPlayFabLogin1InputField1TextArea == null || _playFabDemoPlayFabLogin1InputField1TextArea.CurrentVersion != Template.Version)
#else
                if (_playFabDemoPlayFabLogin1InputField1TextArea == null)
#endif
                {
                    _playFabDemoPlayFabLogin1InputField1TextArea = new Template(PlayFabLoginTemplates.PlayFabLoginInputField1TextArea);
#if UNITY_EDITOR
                    _playFabDemoPlayFabLogin1InputField1TextArea.Name = "PlayFabDemoPlayFabLogin1InputField1TextArea";
                    _playFabDemoPlayFabLogin1InputField1TextArea.LineNumber = 13;
                    _playFabDemoPlayFabLogin1InputField1TextArea.LinePosition = 4;
#endif
                }
                return _playFabDemoPlayFabLogin1InputField1TextArea;
            }
        }

        private static Template _playFabDemoPlayFabLogin1InputField1InputText;
        public static Template PlayFabDemoPlayFabLogin1InputField1InputText
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoPlayFabLogin1InputField1InputText == null || _playFabDemoPlayFabLogin1InputField1InputText.CurrentVersion != Template.Version)
#else
                if (_playFabDemoPlayFabLogin1InputField1InputText == null)
#endif
                {
                    _playFabDemoPlayFabLogin1InputField1InputText = new Template(PlayFabLoginTemplates.PlayFabLoginInputField1InputText);
#if UNITY_EDITOR
                    _playFabDemoPlayFabLogin1InputField1InputText.Name = "PlayFabDemoPlayFabLogin1InputField1InputText";
                    _playFabDemoPlayFabLogin1InputField1InputText.LineNumber = 14;
                    _playFabDemoPlayFabLogin1InputField1InputText.LinePosition = 6;
#endif
                }
                return _playFabDemoPlayFabLogin1InputField1InputText;
            }
        }

        private static Template _playFabDemoPlayFabLogin1Label3;
        public static Template PlayFabDemoPlayFabLogin1Label3
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoPlayFabLogin1Label3 == null || _playFabDemoPlayFabLogin1Label3.CurrentVersion != Template.Version)
#else
                if (_playFabDemoPlayFabLogin1Label3 == null)
#endif
                {
                    _playFabDemoPlayFabLogin1Label3 = new Template(PlayFabLoginTemplates.PlayFabLoginLabel3);
#if UNITY_EDITOR
                    _playFabDemoPlayFabLogin1Label3.Name = "PlayFabDemoPlayFabLogin1Label3";
                    _playFabDemoPlayFabLogin1Label3.LineNumber = 12;
                    _playFabDemoPlayFabLogin1Label3.LinePosition = 10;
#endif
                }
                return _playFabDemoPlayFabLogin1Label3;
            }
        }

        private static Template _playFabDemoPlayFabLogin1InputField2;
        public static Template PlayFabDemoPlayFabLogin1InputField2
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoPlayFabLogin1InputField2 == null || _playFabDemoPlayFabLogin1InputField2.CurrentVersion != Template.Version)
#else
                if (_playFabDemoPlayFabLogin1InputField2 == null)
#endif
                {
                    _playFabDemoPlayFabLogin1InputField2 = new Template(PlayFabLoginTemplates.PlayFabLoginInputField2);
#if UNITY_EDITOR
                    _playFabDemoPlayFabLogin1InputField2.Name = "PlayFabDemoPlayFabLogin1InputField2";
                    _playFabDemoPlayFabLogin1InputField2.LineNumber = 13;
                    _playFabDemoPlayFabLogin1InputField2.LinePosition = 10;
#endif
                    Delight.InputField.InputFieldPlaceholderTemplateProperty.SetDefault(_playFabDemoPlayFabLogin1InputField2, PlayFabDemoPlayFabLogin1InputField2InputFieldPlaceholder);
                    Delight.InputField.TextAreaTemplateProperty.SetDefault(_playFabDemoPlayFabLogin1InputField2, PlayFabDemoPlayFabLogin1InputField2TextArea);
                    Delight.InputField.InputTextTemplateProperty.SetDefault(_playFabDemoPlayFabLogin1InputField2, PlayFabDemoPlayFabLogin1InputField2InputText);
                }
                return _playFabDemoPlayFabLogin1InputField2;
            }
        }

        private static Template _playFabDemoPlayFabLogin1InputField2InputFieldPlaceholder;
        public static Template PlayFabDemoPlayFabLogin1InputField2InputFieldPlaceholder
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoPlayFabLogin1InputField2InputFieldPlaceholder == null || _playFabDemoPlayFabLogin1InputField2InputFieldPlaceholder.CurrentVersion != Template.Version)
#else
                if (_playFabDemoPlayFabLogin1InputField2InputFieldPlaceholder == null)
#endif
                {
                    _playFabDemoPlayFabLogin1InputField2InputFieldPlaceholder = new Template(PlayFabLoginTemplates.PlayFabLoginInputField2InputFieldPlaceholder);
#if UNITY_EDITOR
                    _playFabDemoPlayFabLogin1InputField2InputFieldPlaceholder.Name = "PlayFabDemoPlayFabLogin1InputField2InputFieldPlaceholder";
                    _playFabDemoPlayFabLogin1InputField2InputFieldPlaceholder.LineNumber = 12;
                    _playFabDemoPlayFabLogin1InputField2InputFieldPlaceholder.LinePosition = 4;
#endif
                }
                return _playFabDemoPlayFabLogin1InputField2InputFieldPlaceholder;
            }
        }

        private static Template _playFabDemoPlayFabLogin1InputField2TextArea;
        public static Template PlayFabDemoPlayFabLogin1InputField2TextArea
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoPlayFabLogin1InputField2TextArea == null || _playFabDemoPlayFabLogin1InputField2TextArea.CurrentVersion != Template.Version)
#else
                if (_playFabDemoPlayFabLogin1InputField2TextArea == null)
#endif
                {
                    _playFabDemoPlayFabLogin1InputField2TextArea = new Template(PlayFabLoginTemplates.PlayFabLoginInputField2TextArea);
#if UNITY_EDITOR
                    _playFabDemoPlayFabLogin1InputField2TextArea.Name = "PlayFabDemoPlayFabLogin1InputField2TextArea";
                    _playFabDemoPlayFabLogin1InputField2TextArea.LineNumber = 13;
                    _playFabDemoPlayFabLogin1InputField2TextArea.LinePosition = 4;
#endif
                }
                return _playFabDemoPlayFabLogin1InputField2TextArea;
            }
        }

        private static Template _playFabDemoPlayFabLogin1InputField2InputText;
        public static Template PlayFabDemoPlayFabLogin1InputField2InputText
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoPlayFabLogin1InputField2InputText == null || _playFabDemoPlayFabLogin1InputField2InputText.CurrentVersion != Template.Version)
#else
                if (_playFabDemoPlayFabLogin1InputField2InputText == null)
#endif
                {
                    _playFabDemoPlayFabLogin1InputField2InputText = new Template(PlayFabLoginTemplates.PlayFabLoginInputField2InputText);
#if UNITY_EDITOR
                    _playFabDemoPlayFabLogin1InputField2InputText.Name = "PlayFabDemoPlayFabLogin1InputField2InputText";
                    _playFabDemoPlayFabLogin1InputField2InputText.LineNumber = 14;
                    _playFabDemoPlayFabLogin1InputField2InputText.LinePosition = 6;
#endif
                }
                return _playFabDemoPlayFabLogin1InputField2InputText;
            }
        }

        private static Template _playFabDemoPlayFabLogin1Button1;
        public static Template PlayFabDemoPlayFabLogin1Button1
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoPlayFabLogin1Button1 == null || _playFabDemoPlayFabLogin1Button1.CurrentVersion != Template.Version)
#else
                if (_playFabDemoPlayFabLogin1Button1 == null)
#endif
                {
                    _playFabDemoPlayFabLogin1Button1 = new Template(PlayFabLoginTemplates.PlayFabLoginButton1);
#if UNITY_EDITOR
                    _playFabDemoPlayFabLogin1Button1.Name = "PlayFabDemoPlayFabLogin1Button1";
                    _playFabDemoPlayFabLogin1Button1.LineNumber = 14;
                    _playFabDemoPlayFabLogin1Button1.LinePosition = 10;
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_playFabDemoPlayFabLogin1Button1, PlayFabDemoPlayFabLogin1Button1Label);
                }
                return _playFabDemoPlayFabLogin1Button1;
            }
        }

        private static Template _playFabDemoPlayFabLogin1Button1Label;
        public static Template PlayFabDemoPlayFabLogin1Button1Label
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoPlayFabLogin1Button1Label == null || _playFabDemoPlayFabLogin1Button1Label.CurrentVersion != Template.Version)
#else
                if (_playFabDemoPlayFabLogin1Button1Label == null)
#endif
                {
                    _playFabDemoPlayFabLogin1Button1Label = new Template(PlayFabLoginTemplates.PlayFabLoginButton1Label);
#if UNITY_EDITOR
                    _playFabDemoPlayFabLogin1Button1Label.Name = "PlayFabDemoPlayFabLogin1Button1Label";
                    _playFabDemoPlayFabLogin1Button1Label.LineNumber = 15;
                    _playFabDemoPlayFabLogin1Button1Label.LinePosition = 4;
#endif
                }
                return _playFabDemoPlayFabLogin1Button1Label;
            }
        }

        private static Template _playFabDemoPlayFabLogin1Label4;
        public static Template PlayFabDemoPlayFabLogin1Label4
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoPlayFabLogin1Label4 == null || _playFabDemoPlayFabLogin1Label4.CurrentVersion != Template.Version)
#else
                if (_playFabDemoPlayFabLogin1Label4 == null)
#endif
                {
                    _playFabDemoPlayFabLogin1Label4 = new Template(PlayFabLoginTemplates.PlayFabLoginLabel4);
#if UNITY_EDITOR
                    _playFabDemoPlayFabLogin1Label4.Name = "PlayFabDemoPlayFabLogin1Label4";
                    _playFabDemoPlayFabLogin1Label4.LineNumber = 15;
                    _playFabDemoPlayFabLogin1Label4.LinePosition = 10;
#endif
                }
                return _playFabDemoPlayFabLogin1Label4;
            }
        }

        private static Template _playFabDemoPlayFabLogin1Group2;
        public static Template PlayFabDemoPlayFabLogin1Group2
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoPlayFabLogin1Group2 == null || _playFabDemoPlayFabLogin1Group2.CurrentVersion != Template.Version)
#else
                if (_playFabDemoPlayFabLogin1Group2 == null)
#endif
                {
                    _playFabDemoPlayFabLogin1Group2 = new Template(PlayFabLoginTemplates.PlayFabLoginGroup2);
#if UNITY_EDITOR
                    _playFabDemoPlayFabLogin1Group2.Name = "PlayFabDemoPlayFabLogin1Group2";
                    _playFabDemoPlayFabLogin1Group2.LineNumber = 17;
                    _playFabDemoPlayFabLogin1Group2.LinePosition = 8;
#endif
                }
                return _playFabDemoPlayFabLogin1Group2;
            }
        }

        private static Template _playFabDemoPlayFabLogin1Button2;
        public static Template PlayFabDemoPlayFabLogin1Button2
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoPlayFabLogin1Button2 == null || _playFabDemoPlayFabLogin1Button2.CurrentVersion != Template.Version)
#else
                if (_playFabDemoPlayFabLogin1Button2 == null)
#endif
                {
                    _playFabDemoPlayFabLogin1Button2 = new Template(PlayFabLoginTemplates.PlayFabLoginButton2);
#if UNITY_EDITOR
                    _playFabDemoPlayFabLogin1Button2.Name = "PlayFabDemoPlayFabLogin1Button2";
                    _playFabDemoPlayFabLogin1Button2.LineNumber = 18;
                    _playFabDemoPlayFabLogin1Button2.LinePosition = 10;
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_playFabDemoPlayFabLogin1Button2, PlayFabDemoPlayFabLogin1Button2Label);
                }
                return _playFabDemoPlayFabLogin1Button2;
            }
        }

        private static Template _playFabDemoPlayFabLogin1Button2Label;
        public static Template PlayFabDemoPlayFabLogin1Button2Label
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoPlayFabLogin1Button2Label == null || _playFabDemoPlayFabLogin1Button2Label.CurrentVersion != Template.Version)
#else
                if (_playFabDemoPlayFabLogin1Button2Label == null)
#endif
                {
                    _playFabDemoPlayFabLogin1Button2Label = new Template(PlayFabLoginTemplates.PlayFabLoginButton2Label);
#if UNITY_EDITOR
                    _playFabDemoPlayFabLogin1Button2Label.Name = "PlayFabDemoPlayFabLogin1Button2Label";
                    _playFabDemoPlayFabLogin1Button2Label.LineNumber = 15;
                    _playFabDemoPlayFabLogin1Button2Label.LinePosition = 4;
#endif
                }
                return _playFabDemoPlayFabLogin1Button2Label;
            }
        }

        private static Template _playFabDemoPlayFabRegister1;
        public static Template PlayFabDemoPlayFabRegister1
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoPlayFabRegister1 == null || _playFabDemoPlayFabRegister1.CurrentVersion != Template.Version)
#else
                if (_playFabDemoPlayFabRegister1 == null)
#endif
                {
                    _playFabDemoPlayFabRegister1 = new Template(PlayFabRegisterTemplates.PlayFabRegister);
#if UNITY_EDITOR
                    _playFabDemoPlayFabRegister1.Name = "PlayFabDemoPlayFabRegister1";
                    _playFabDemoPlayFabRegister1.LineNumber = 18;
                    _playFabDemoPlayFabRegister1.LinePosition = 8;
#endif
                    Delight.PlayFabRegister.Grid1TemplateProperty.SetDefault(_playFabDemoPlayFabRegister1, PlayFabDemoPlayFabRegister1Grid1);
                    Delight.PlayFabRegister.Region1TemplateProperty.SetDefault(_playFabDemoPlayFabRegister1, PlayFabDemoPlayFabRegister1Region1);
                    Delight.PlayFabRegister.Group1TemplateProperty.SetDefault(_playFabDemoPlayFabRegister1, PlayFabDemoPlayFabRegister1Group1);
                    Delight.PlayFabRegister.Label1TemplateProperty.SetDefault(_playFabDemoPlayFabRegister1, PlayFabDemoPlayFabRegister1Label1);
                    Delight.PlayFabRegister.Label2TemplateProperty.SetDefault(_playFabDemoPlayFabRegister1, PlayFabDemoPlayFabRegister1Label2);
                    Delight.PlayFabRegister.InputField1TemplateProperty.SetDefault(_playFabDemoPlayFabRegister1, PlayFabDemoPlayFabRegister1InputField1);
                    Delight.PlayFabRegister.Label3TemplateProperty.SetDefault(_playFabDemoPlayFabRegister1, PlayFabDemoPlayFabRegister1Label3);
                    Delight.PlayFabRegister.InputField2TemplateProperty.SetDefault(_playFabDemoPlayFabRegister1, PlayFabDemoPlayFabRegister1InputField2);
                    Delight.PlayFabRegister.Button1TemplateProperty.SetDefault(_playFabDemoPlayFabRegister1, PlayFabDemoPlayFabRegister1Button1);
                    Delight.PlayFabRegister.Label4TemplateProperty.SetDefault(_playFabDemoPlayFabRegister1, PlayFabDemoPlayFabRegister1Label4);
                }
                return _playFabDemoPlayFabRegister1;
            }
        }

        private static Template _playFabDemoPlayFabRegister1Grid1;
        public static Template PlayFabDemoPlayFabRegister1Grid1
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoPlayFabRegister1Grid1 == null || _playFabDemoPlayFabRegister1Grid1.CurrentVersion != Template.Version)
#else
                if (_playFabDemoPlayFabRegister1Grid1 == null)
#endif
                {
                    _playFabDemoPlayFabRegister1Grid1 = new Template(PlayFabRegisterTemplates.PlayFabRegisterGrid1);
#if UNITY_EDITOR
                    _playFabDemoPlayFabRegister1Grid1.Name = "PlayFabDemoPlayFabRegister1Grid1";
                    _playFabDemoPlayFabRegister1Grid1.LineNumber = 4;
                    _playFabDemoPlayFabRegister1Grid1.LinePosition = 4;
#endif
                }
                return _playFabDemoPlayFabRegister1Grid1;
            }
        }

        private static Template _playFabDemoPlayFabRegister1Region1;
        public static Template PlayFabDemoPlayFabRegister1Region1
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoPlayFabRegister1Region1 == null || _playFabDemoPlayFabRegister1Region1.CurrentVersion != Template.Version)
#else
                if (_playFabDemoPlayFabRegister1Region1 == null)
#endif
                {
                    _playFabDemoPlayFabRegister1Region1 = new Template(PlayFabRegisterTemplates.PlayFabRegisterRegion1);
#if UNITY_EDITOR
                    _playFabDemoPlayFabRegister1Region1.Name = "PlayFabDemoPlayFabRegister1Region1";
                    _playFabDemoPlayFabRegister1Region1.LineNumber = 7;
                    _playFabDemoPlayFabRegister1Region1.LinePosition = 6;
#endif
                }
                return _playFabDemoPlayFabRegister1Region1;
            }
        }

        private static Template _playFabDemoPlayFabRegister1Group1;
        public static Template PlayFabDemoPlayFabRegister1Group1
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoPlayFabRegister1Group1 == null || _playFabDemoPlayFabRegister1Group1.CurrentVersion != Template.Version)
#else
                if (_playFabDemoPlayFabRegister1Group1 == null)
#endif
                {
                    _playFabDemoPlayFabRegister1Group1 = new Template(PlayFabRegisterTemplates.PlayFabRegisterGroup1);
#if UNITY_EDITOR
                    _playFabDemoPlayFabRegister1Group1.Name = "PlayFabDemoPlayFabRegister1Group1";
                    _playFabDemoPlayFabRegister1Group1.LineNumber = 8;
                    _playFabDemoPlayFabRegister1Group1.LinePosition = 8;
#endif
                }
                return _playFabDemoPlayFabRegister1Group1;
            }
        }

        private static Template _playFabDemoPlayFabRegister1Label1;
        public static Template PlayFabDemoPlayFabRegister1Label1
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoPlayFabRegister1Label1 == null || _playFabDemoPlayFabRegister1Label1.CurrentVersion != Template.Version)
#else
                if (_playFabDemoPlayFabRegister1Label1 == null)
#endif
                {
                    _playFabDemoPlayFabRegister1Label1 = new Template(PlayFabRegisterTemplates.PlayFabRegisterLabel1);
#if UNITY_EDITOR
                    _playFabDemoPlayFabRegister1Label1.Name = "PlayFabDemoPlayFabRegister1Label1";
                    _playFabDemoPlayFabRegister1Label1.LineNumber = 9;
                    _playFabDemoPlayFabRegister1Label1.LinePosition = 10;
#endif
                }
                return _playFabDemoPlayFabRegister1Label1;
            }
        }

        private static Template _playFabDemoPlayFabRegister1Label2;
        public static Template PlayFabDemoPlayFabRegister1Label2
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoPlayFabRegister1Label2 == null || _playFabDemoPlayFabRegister1Label2.CurrentVersion != Template.Version)
#else
                if (_playFabDemoPlayFabRegister1Label2 == null)
#endif
                {
                    _playFabDemoPlayFabRegister1Label2 = new Template(PlayFabRegisterTemplates.PlayFabRegisterLabel2);
#if UNITY_EDITOR
                    _playFabDemoPlayFabRegister1Label2.Name = "PlayFabDemoPlayFabRegister1Label2";
                    _playFabDemoPlayFabRegister1Label2.LineNumber = 10;
                    _playFabDemoPlayFabRegister1Label2.LinePosition = 10;
#endif
                }
                return _playFabDemoPlayFabRegister1Label2;
            }
        }

        private static Template _playFabDemoPlayFabRegister1InputField1;
        public static Template PlayFabDemoPlayFabRegister1InputField1
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoPlayFabRegister1InputField1 == null || _playFabDemoPlayFabRegister1InputField1.CurrentVersion != Template.Version)
#else
                if (_playFabDemoPlayFabRegister1InputField1 == null)
#endif
                {
                    _playFabDemoPlayFabRegister1InputField1 = new Template(PlayFabRegisterTemplates.PlayFabRegisterInputField1);
#if UNITY_EDITOR
                    _playFabDemoPlayFabRegister1InputField1.Name = "PlayFabDemoPlayFabRegister1InputField1";
                    _playFabDemoPlayFabRegister1InputField1.LineNumber = 11;
                    _playFabDemoPlayFabRegister1InputField1.LinePosition = 10;
#endif
                    Delight.InputField.InputFieldPlaceholderTemplateProperty.SetDefault(_playFabDemoPlayFabRegister1InputField1, PlayFabDemoPlayFabRegister1InputField1InputFieldPlaceholder);
                    Delight.InputField.TextAreaTemplateProperty.SetDefault(_playFabDemoPlayFabRegister1InputField1, PlayFabDemoPlayFabRegister1InputField1TextArea);
                    Delight.InputField.InputTextTemplateProperty.SetDefault(_playFabDemoPlayFabRegister1InputField1, PlayFabDemoPlayFabRegister1InputField1InputText);
                }
                return _playFabDemoPlayFabRegister1InputField1;
            }
        }

        private static Template _playFabDemoPlayFabRegister1InputField1InputFieldPlaceholder;
        public static Template PlayFabDemoPlayFabRegister1InputField1InputFieldPlaceholder
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoPlayFabRegister1InputField1InputFieldPlaceholder == null || _playFabDemoPlayFabRegister1InputField1InputFieldPlaceholder.CurrentVersion != Template.Version)
#else
                if (_playFabDemoPlayFabRegister1InputField1InputFieldPlaceholder == null)
#endif
                {
                    _playFabDemoPlayFabRegister1InputField1InputFieldPlaceholder = new Template(PlayFabRegisterTemplates.PlayFabRegisterInputField1InputFieldPlaceholder);
#if UNITY_EDITOR
                    _playFabDemoPlayFabRegister1InputField1InputFieldPlaceholder.Name = "PlayFabDemoPlayFabRegister1InputField1InputFieldPlaceholder";
                    _playFabDemoPlayFabRegister1InputField1InputFieldPlaceholder.LineNumber = 12;
                    _playFabDemoPlayFabRegister1InputField1InputFieldPlaceholder.LinePosition = 4;
#endif
                }
                return _playFabDemoPlayFabRegister1InputField1InputFieldPlaceholder;
            }
        }

        private static Template _playFabDemoPlayFabRegister1InputField1TextArea;
        public static Template PlayFabDemoPlayFabRegister1InputField1TextArea
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoPlayFabRegister1InputField1TextArea == null || _playFabDemoPlayFabRegister1InputField1TextArea.CurrentVersion != Template.Version)
#else
                if (_playFabDemoPlayFabRegister1InputField1TextArea == null)
#endif
                {
                    _playFabDemoPlayFabRegister1InputField1TextArea = new Template(PlayFabRegisterTemplates.PlayFabRegisterInputField1TextArea);
#if UNITY_EDITOR
                    _playFabDemoPlayFabRegister1InputField1TextArea.Name = "PlayFabDemoPlayFabRegister1InputField1TextArea";
                    _playFabDemoPlayFabRegister1InputField1TextArea.LineNumber = 13;
                    _playFabDemoPlayFabRegister1InputField1TextArea.LinePosition = 4;
#endif
                }
                return _playFabDemoPlayFabRegister1InputField1TextArea;
            }
        }

        private static Template _playFabDemoPlayFabRegister1InputField1InputText;
        public static Template PlayFabDemoPlayFabRegister1InputField1InputText
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoPlayFabRegister1InputField1InputText == null || _playFabDemoPlayFabRegister1InputField1InputText.CurrentVersion != Template.Version)
#else
                if (_playFabDemoPlayFabRegister1InputField1InputText == null)
#endif
                {
                    _playFabDemoPlayFabRegister1InputField1InputText = new Template(PlayFabRegisterTemplates.PlayFabRegisterInputField1InputText);
#if UNITY_EDITOR
                    _playFabDemoPlayFabRegister1InputField1InputText.Name = "PlayFabDemoPlayFabRegister1InputField1InputText";
                    _playFabDemoPlayFabRegister1InputField1InputText.LineNumber = 14;
                    _playFabDemoPlayFabRegister1InputField1InputText.LinePosition = 6;
#endif
                }
                return _playFabDemoPlayFabRegister1InputField1InputText;
            }
        }

        private static Template _playFabDemoPlayFabRegister1Label3;
        public static Template PlayFabDemoPlayFabRegister1Label3
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoPlayFabRegister1Label3 == null || _playFabDemoPlayFabRegister1Label3.CurrentVersion != Template.Version)
#else
                if (_playFabDemoPlayFabRegister1Label3 == null)
#endif
                {
                    _playFabDemoPlayFabRegister1Label3 = new Template(PlayFabRegisterTemplates.PlayFabRegisterLabel3);
#if UNITY_EDITOR
                    _playFabDemoPlayFabRegister1Label3.Name = "PlayFabDemoPlayFabRegister1Label3";
                    _playFabDemoPlayFabRegister1Label3.LineNumber = 12;
                    _playFabDemoPlayFabRegister1Label3.LinePosition = 10;
#endif
                }
                return _playFabDemoPlayFabRegister1Label3;
            }
        }

        private static Template _playFabDemoPlayFabRegister1InputField2;
        public static Template PlayFabDemoPlayFabRegister1InputField2
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoPlayFabRegister1InputField2 == null || _playFabDemoPlayFabRegister1InputField2.CurrentVersion != Template.Version)
#else
                if (_playFabDemoPlayFabRegister1InputField2 == null)
#endif
                {
                    _playFabDemoPlayFabRegister1InputField2 = new Template(PlayFabRegisterTemplates.PlayFabRegisterInputField2);
#if UNITY_EDITOR
                    _playFabDemoPlayFabRegister1InputField2.Name = "PlayFabDemoPlayFabRegister1InputField2";
                    _playFabDemoPlayFabRegister1InputField2.LineNumber = 13;
                    _playFabDemoPlayFabRegister1InputField2.LinePosition = 10;
#endif
                    Delight.InputField.InputFieldPlaceholderTemplateProperty.SetDefault(_playFabDemoPlayFabRegister1InputField2, PlayFabDemoPlayFabRegister1InputField2InputFieldPlaceholder);
                    Delight.InputField.TextAreaTemplateProperty.SetDefault(_playFabDemoPlayFabRegister1InputField2, PlayFabDemoPlayFabRegister1InputField2TextArea);
                    Delight.InputField.InputTextTemplateProperty.SetDefault(_playFabDemoPlayFabRegister1InputField2, PlayFabDemoPlayFabRegister1InputField2InputText);
                }
                return _playFabDemoPlayFabRegister1InputField2;
            }
        }

        private static Template _playFabDemoPlayFabRegister1InputField2InputFieldPlaceholder;
        public static Template PlayFabDemoPlayFabRegister1InputField2InputFieldPlaceholder
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoPlayFabRegister1InputField2InputFieldPlaceholder == null || _playFabDemoPlayFabRegister1InputField2InputFieldPlaceholder.CurrentVersion != Template.Version)
#else
                if (_playFabDemoPlayFabRegister1InputField2InputFieldPlaceholder == null)
#endif
                {
                    _playFabDemoPlayFabRegister1InputField2InputFieldPlaceholder = new Template(PlayFabRegisterTemplates.PlayFabRegisterInputField2InputFieldPlaceholder);
#if UNITY_EDITOR
                    _playFabDemoPlayFabRegister1InputField2InputFieldPlaceholder.Name = "PlayFabDemoPlayFabRegister1InputField2InputFieldPlaceholder";
                    _playFabDemoPlayFabRegister1InputField2InputFieldPlaceholder.LineNumber = 12;
                    _playFabDemoPlayFabRegister1InputField2InputFieldPlaceholder.LinePosition = 4;
#endif
                }
                return _playFabDemoPlayFabRegister1InputField2InputFieldPlaceholder;
            }
        }

        private static Template _playFabDemoPlayFabRegister1InputField2TextArea;
        public static Template PlayFabDemoPlayFabRegister1InputField2TextArea
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoPlayFabRegister1InputField2TextArea == null || _playFabDemoPlayFabRegister1InputField2TextArea.CurrentVersion != Template.Version)
#else
                if (_playFabDemoPlayFabRegister1InputField2TextArea == null)
#endif
                {
                    _playFabDemoPlayFabRegister1InputField2TextArea = new Template(PlayFabRegisterTemplates.PlayFabRegisterInputField2TextArea);
#if UNITY_EDITOR
                    _playFabDemoPlayFabRegister1InputField2TextArea.Name = "PlayFabDemoPlayFabRegister1InputField2TextArea";
                    _playFabDemoPlayFabRegister1InputField2TextArea.LineNumber = 13;
                    _playFabDemoPlayFabRegister1InputField2TextArea.LinePosition = 4;
#endif
                }
                return _playFabDemoPlayFabRegister1InputField2TextArea;
            }
        }

        private static Template _playFabDemoPlayFabRegister1InputField2InputText;
        public static Template PlayFabDemoPlayFabRegister1InputField2InputText
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoPlayFabRegister1InputField2InputText == null || _playFabDemoPlayFabRegister1InputField2InputText.CurrentVersion != Template.Version)
#else
                if (_playFabDemoPlayFabRegister1InputField2InputText == null)
#endif
                {
                    _playFabDemoPlayFabRegister1InputField2InputText = new Template(PlayFabRegisterTemplates.PlayFabRegisterInputField2InputText);
#if UNITY_EDITOR
                    _playFabDemoPlayFabRegister1InputField2InputText.Name = "PlayFabDemoPlayFabRegister1InputField2InputText";
                    _playFabDemoPlayFabRegister1InputField2InputText.LineNumber = 14;
                    _playFabDemoPlayFabRegister1InputField2InputText.LinePosition = 6;
#endif
                }
                return _playFabDemoPlayFabRegister1InputField2InputText;
            }
        }

        private static Template _playFabDemoPlayFabRegister1Button1;
        public static Template PlayFabDemoPlayFabRegister1Button1
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoPlayFabRegister1Button1 == null || _playFabDemoPlayFabRegister1Button1.CurrentVersion != Template.Version)
#else
                if (_playFabDemoPlayFabRegister1Button1 == null)
#endif
                {
                    _playFabDemoPlayFabRegister1Button1 = new Template(PlayFabRegisterTemplates.PlayFabRegisterButton1);
#if UNITY_EDITOR
                    _playFabDemoPlayFabRegister1Button1.Name = "PlayFabDemoPlayFabRegister1Button1";
                    _playFabDemoPlayFabRegister1Button1.LineNumber = 14;
                    _playFabDemoPlayFabRegister1Button1.LinePosition = 10;
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_playFabDemoPlayFabRegister1Button1, PlayFabDemoPlayFabRegister1Button1Label);
                }
                return _playFabDemoPlayFabRegister1Button1;
            }
        }

        private static Template _playFabDemoPlayFabRegister1Button1Label;
        public static Template PlayFabDemoPlayFabRegister1Button1Label
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoPlayFabRegister1Button1Label == null || _playFabDemoPlayFabRegister1Button1Label.CurrentVersion != Template.Version)
#else
                if (_playFabDemoPlayFabRegister1Button1Label == null)
#endif
                {
                    _playFabDemoPlayFabRegister1Button1Label = new Template(PlayFabRegisterTemplates.PlayFabRegisterButton1Label);
#if UNITY_EDITOR
                    _playFabDemoPlayFabRegister1Button1Label.Name = "PlayFabDemoPlayFabRegister1Button1Label";
                    _playFabDemoPlayFabRegister1Button1Label.LineNumber = 15;
                    _playFabDemoPlayFabRegister1Button1Label.LinePosition = 4;
#endif
                }
                return _playFabDemoPlayFabRegister1Button1Label;
            }
        }

        private static Template _playFabDemoPlayFabRegister1Label4;
        public static Template PlayFabDemoPlayFabRegister1Label4
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoPlayFabRegister1Label4 == null || _playFabDemoPlayFabRegister1Label4.CurrentVersion != Template.Version)
#else
                if (_playFabDemoPlayFabRegister1Label4 == null)
#endif
                {
                    _playFabDemoPlayFabRegister1Label4 = new Template(PlayFabRegisterTemplates.PlayFabRegisterLabel4);
#if UNITY_EDITOR
                    _playFabDemoPlayFabRegister1Label4.Name = "PlayFabDemoPlayFabRegister1Label4";
                    _playFabDemoPlayFabRegister1Label4.LineNumber = 15;
                    _playFabDemoPlayFabRegister1Label4.LinePosition = 10;
#endif
                }
                return _playFabDemoPlayFabRegister1Label4;
            }
        }

        private static Template _playFabDemoPlayFabPlayerProfileDetail1;
        public static Template PlayFabDemoPlayFabPlayerProfileDetail1
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoPlayFabPlayerProfileDetail1 == null || _playFabDemoPlayFabPlayerProfileDetail1.CurrentVersion != Template.Version)
#else
                if (_playFabDemoPlayFabPlayerProfileDetail1 == null)
#endif
                {
                    _playFabDemoPlayFabPlayerProfileDetail1 = new Template(PlayFabPlayerProfileDetailTemplates.PlayFabPlayerProfileDetail);
#if UNITY_EDITOR
                    _playFabDemoPlayFabPlayerProfileDetail1.Name = "PlayFabDemoPlayFabPlayerProfileDetail1";
                    _playFabDemoPlayFabPlayerProfileDetail1.LineNumber = 19;
                    _playFabDemoPlayFabPlayerProfileDetail1.LinePosition = 8;
#endif
                    Delight.PlayFabPlayerProfileDetail.Group1TemplateProperty.SetDefault(_playFabDemoPlayFabPlayerProfileDetail1, PlayFabDemoPlayFabPlayerProfileDetail1Group1);
                    Delight.PlayFabPlayerProfileDetail.Label1TemplateProperty.SetDefault(_playFabDemoPlayFabPlayerProfileDetail1, PlayFabDemoPlayFabPlayerProfileDetail1Label1);
                    Delight.PlayFabPlayerProfileDetail.Grid1TemplateProperty.SetDefault(_playFabDemoPlayFabPlayerProfileDetail1, PlayFabDemoPlayFabPlayerProfileDetail1Grid1);
                    Delight.PlayFabPlayerProfileDetail.Label2TemplateProperty.SetDefault(_playFabDemoPlayFabPlayerProfileDetail1, PlayFabDemoPlayFabPlayerProfileDetail1Label2);
                    Delight.PlayFabPlayerProfileDetail.Label3TemplateProperty.SetDefault(_playFabDemoPlayFabPlayerProfileDetail1, PlayFabDemoPlayFabPlayerProfileDetail1Label3);
                    Delight.PlayFabPlayerProfileDetail.Label4TemplateProperty.SetDefault(_playFabDemoPlayFabPlayerProfileDetail1, PlayFabDemoPlayFabPlayerProfileDetail1Label4);
                    Delight.PlayFabPlayerProfileDetail.InputField1TemplateProperty.SetDefault(_playFabDemoPlayFabPlayerProfileDetail1, PlayFabDemoPlayFabPlayerProfileDetail1InputField1);
                    Delight.PlayFabPlayerProfileDetail.Group2TemplateProperty.SetDefault(_playFabDemoPlayFabPlayerProfileDetail1, PlayFabDemoPlayFabPlayerProfileDetail1Group2);
                    Delight.PlayFabPlayerProfileDetail.Label5TemplateProperty.SetDefault(_playFabDemoPlayFabPlayerProfileDetail1, PlayFabDemoPlayFabPlayerProfileDetail1Label5);
                    Delight.PlayFabPlayerProfileDetail.List1TemplateProperty.SetDefault(_playFabDemoPlayFabPlayerProfileDetail1, PlayFabDemoPlayFabPlayerProfileDetail1List1);
                    Delight.PlayFabPlayerProfileDetail.ListItem1TemplateProperty.SetDefault(_playFabDemoPlayFabPlayerProfileDetail1, PlayFabDemoPlayFabPlayerProfileDetail1ListItem1);
                    Delight.PlayFabPlayerProfileDetail.Grid2TemplateProperty.SetDefault(_playFabDemoPlayFabPlayerProfileDetail1, PlayFabDemoPlayFabPlayerProfileDetail1Grid2);
                    Delight.PlayFabPlayerProfileDetail.Label6TemplateProperty.SetDefault(_playFabDemoPlayFabPlayerProfileDetail1, PlayFabDemoPlayFabPlayerProfileDetail1Label6);
                    Delight.PlayFabPlayerProfileDetail.Label7TemplateProperty.SetDefault(_playFabDemoPlayFabPlayerProfileDetail1, PlayFabDemoPlayFabPlayerProfileDetail1Label7);
                    Delight.PlayFabPlayerProfileDetail.Label8TemplateProperty.SetDefault(_playFabDemoPlayFabPlayerProfileDetail1, PlayFabDemoPlayFabPlayerProfileDetail1Label8);
                    Delight.PlayFabPlayerProfileDetail.Label9TemplateProperty.SetDefault(_playFabDemoPlayFabPlayerProfileDetail1, PlayFabDemoPlayFabPlayerProfileDetail1Label9);
                    Delight.PlayFabPlayerProfileDetail.Group3TemplateProperty.SetDefault(_playFabDemoPlayFabPlayerProfileDetail1, PlayFabDemoPlayFabPlayerProfileDetail1Group3);
                    Delight.PlayFabPlayerProfileDetail.Button1TemplateProperty.SetDefault(_playFabDemoPlayFabPlayerProfileDetail1, PlayFabDemoPlayFabPlayerProfileDetail1Button1);
                    Delight.PlayFabPlayerProfileDetail.Button2TemplateProperty.SetDefault(_playFabDemoPlayFabPlayerProfileDetail1, PlayFabDemoPlayFabPlayerProfileDetail1Button2);
                    Delight.PlayFabPlayerProfileDetail.Region1TemplateProperty.SetDefault(_playFabDemoPlayFabPlayerProfileDetail1, PlayFabDemoPlayFabPlayerProfileDetail1Region1);
                    Delight.PlayFabPlayerProfileDetail.Label10TemplateProperty.SetDefault(_playFabDemoPlayFabPlayerProfileDetail1, PlayFabDemoPlayFabPlayerProfileDetail1Label10);
                }
                return _playFabDemoPlayFabPlayerProfileDetail1;
            }
        }

        private static Template _playFabDemoPlayFabPlayerProfileDetail1Group1;
        public static Template PlayFabDemoPlayFabPlayerProfileDetail1Group1
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoPlayFabPlayerProfileDetail1Group1 == null || _playFabDemoPlayFabPlayerProfileDetail1Group1.CurrentVersion != Template.Version)
#else
                if (_playFabDemoPlayFabPlayerProfileDetail1Group1 == null)
#endif
                {
                    _playFabDemoPlayFabPlayerProfileDetail1Group1 = new Template(PlayFabPlayerProfileDetailTemplates.PlayFabPlayerProfileDetailGroup1);
#if UNITY_EDITOR
                    _playFabDemoPlayFabPlayerProfileDetail1Group1.Name = "PlayFabDemoPlayFabPlayerProfileDetail1Group1";
                    _playFabDemoPlayFabPlayerProfileDetail1Group1.LineNumber = 4;
                    _playFabDemoPlayFabPlayerProfileDetail1Group1.LinePosition = 4;
#endif
                }
                return _playFabDemoPlayFabPlayerProfileDetail1Group1;
            }
        }

        private static Template _playFabDemoPlayFabPlayerProfileDetail1Label1;
        public static Template PlayFabDemoPlayFabPlayerProfileDetail1Label1
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoPlayFabPlayerProfileDetail1Label1 == null || _playFabDemoPlayFabPlayerProfileDetail1Label1.CurrentVersion != Template.Version)
#else
                if (_playFabDemoPlayFabPlayerProfileDetail1Label1 == null)
#endif
                {
                    _playFabDemoPlayFabPlayerProfileDetail1Label1 = new Template(PlayFabPlayerProfileDetailTemplates.PlayFabPlayerProfileDetailLabel1);
#if UNITY_EDITOR
                    _playFabDemoPlayFabPlayerProfileDetail1Label1.Name = "PlayFabDemoPlayFabPlayerProfileDetail1Label1";
                    _playFabDemoPlayFabPlayerProfileDetail1Label1.LineNumber = 5;
                    _playFabDemoPlayFabPlayerProfileDetail1Label1.LinePosition = 6;
#endif
                }
                return _playFabDemoPlayFabPlayerProfileDetail1Label1;
            }
        }

        private static Template _playFabDemoPlayFabPlayerProfileDetail1Grid1;
        public static Template PlayFabDemoPlayFabPlayerProfileDetail1Grid1
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoPlayFabPlayerProfileDetail1Grid1 == null || _playFabDemoPlayFabPlayerProfileDetail1Grid1.CurrentVersion != Template.Version)
#else
                if (_playFabDemoPlayFabPlayerProfileDetail1Grid1 == null)
#endif
                {
                    _playFabDemoPlayFabPlayerProfileDetail1Grid1 = new Template(PlayFabPlayerProfileDetailTemplates.PlayFabPlayerProfileDetailGrid1);
#if UNITY_EDITOR
                    _playFabDemoPlayFabPlayerProfileDetail1Grid1.Name = "PlayFabDemoPlayFabPlayerProfileDetail1Grid1";
                    _playFabDemoPlayFabPlayerProfileDetail1Grid1.LineNumber = 6;
                    _playFabDemoPlayFabPlayerProfileDetail1Grid1.LinePosition = 6;
#endif
                }
                return _playFabDemoPlayFabPlayerProfileDetail1Grid1;
            }
        }

        private static Template _playFabDemoPlayFabPlayerProfileDetail1Label2;
        public static Template PlayFabDemoPlayFabPlayerProfileDetail1Label2
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoPlayFabPlayerProfileDetail1Label2 == null || _playFabDemoPlayFabPlayerProfileDetail1Label2.CurrentVersion != Template.Version)
#else
                if (_playFabDemoPlayFabPlayerProfileDetail1Label2 == null)
#endif
                {
                    _playFabDemoPlayFabPlayerProfileDetail1Label2 = new Template(PlayFabPlayerProfileDetailTemplates.PlayFabPlayerProfileDetailLabel2);
#if UNITY_EDITOR
                    _playFabDemoPlayFabPlayerProfileDetail1Label2.Name = "PlayFabDemoPlayFabPlayerProfileDetail1Label2";
                    _playFabDemoPlayFabPlayerProfileDetail1Label2.LineNumber = 7;
                    _playFabDemoPlayFabPlayerProfileDetail1Label2.LinePosition = 8;
#endif
                }
                return _playFabDemoPlayFabPlayerProfileDetail1Label2;
            }
        }

        private static Template _playFabDemoPlayFabPlayerProfileDetail1Label3;
        public static Template PlayFabDemoPlayFabPlayerProfileDetail1Label3
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoPlayFabPlayerProfileDetail1Label3 == null || _playFabDemoPlayFabPlayerProfileDetail1Label3.CurrentVersion != Template.Version)
#else
                if (_playFabDemoPlayFabPlayerProfileDetail1Label3 == null)
#endif
                {
                    _playFabDemoPlayFabPlayerProfileDetail1Label3 = new Template(PlayFabPlayerProfileDetailTemplates.PlayFabPlayerProfileDetailLabel3);
#if UNITY_EDITOR
                    _playFabDemoPlayFabPlayerProfileDetail1Label3.Name = "PlayFabDemoPlayFabPlayerProfileDetail1Label3";
                    _playFabDemoPlayFabPlayerProfileDetail1Label3.LineNumber = 8;
                    _playFabDemoPlayFabPlayerProfileDetail1Label3.LinePosition = 8;
#endif
                }
                return _playFabDemoPlayFabPlayerProfileDetail1Label3;
            }
        }

        private static Template _playFabDemoPlayFabPlayerProfileDetail1Label4;
        public static Template PlayFabDemoPlayFabPlayerProfileDetail1Label4
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoPlayFabPlayerProfileDetail1Label4 == null || _playFabDemoPlayFabPlayerProfileDetail1Label4.CurrentVersion != Template.Version)
#else
                if (_playFabDemoPlayFabPlayerProfileDetail1Label4 == null)
#endif
                {
                    _playFabDemoPlayFabPlayerProfileDetail1Label4 = new Template(PlayFabPlayerProfileDetailTemplates.PlayFabPlayerProfileDetailLabel4);
#if UNITY_EDITOR
                    _playFabDemoPlayFabPlayerProfileDetail1Label4.Name = "PlayFabDemoPlayFabPlayerProfileDetail1Label4";
                    _playFabDemoPlayFabPlayerProfileDetail1Label4.LineNumber = 10;
                    _playFabDemoPlayFabPlayerProfileDetail1Label4.LinePosition = 8;
#endif
                }
                return _playFabDemoPlayFabPlayerProfileDetail1Label4;
            }
        }

        private static Template _playFabDemoPlayFabPlayerProfileDetail1InputField1;
        public static Template PlayFabDemoPlayFabPlayerProfileDetail1InputField1
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoPlayFabPlayerProfileDetail1InputField1 == null || _playFabDemoPlayFabPlayerProfileDetail1InputField1.CurrentVersion != Template.Version)
#else
                if (_playFabDemoPlayFabPlayerProfileDetail1InputField1 == null)
#endif
                {
                    _playFabDemoPlayFabPlayerProfileDetail1InputField1 = new Template(PlayFabPlayerProfileDetailTemplates.PlayFabPlayerProfileDetailInputField1);
#if UNITY_EDITOR
                    _playFabDemoPlayFabPlayerProfileDetail1InputField1.Name = "PlayFabDemoPlayFabPlayerProfileDetail1InputField1";
                    _playFabDemoPlayFabPlayerProfileDetail1InputField1.LineNumber = 11;
                    _playFabDemoPlayFabPlayerProfileDetail1InputField1.LinePosition = 8;
#endif
                    Delight.InputField.InputFieldPlaceholderTemplateProperty.SetDefault(_playFabDemoPlayFabPlayerProfileDetail1InputField1, PlayFabDemoPlayFabPlayerProfileDetail1InputField1InputFieldPlaceholder);
                    Delight.InputField.TextAreaTemplateProperty.SetDefault(_playFabDemoPlayFabPlayerProfileDetail1InputField1, PlayFabDemoPlayFabPlayerProfileDetail1InputField1TextArea);
                    Delight.InputField.InputTextTemplateProperty.SetDefault(_playFabDemoPlayFabPlayerProfileDetail1InputField1, PlayFabDemoPlayFabPlayerProfileDetail1InputField1InputText);
                }
                return _playFabDemoPlayFabPlayerProfileDetail1InputField1;
            }
        }

        private static Template _playFabDemoPlayFabPlayerProfileDetail1InputField1InputFieldPlaceholder;
        public static Template PlayFabDemoPlayFabPlayerProfileDetail1InputField1InputFieldPlaceholder
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoPlayFabPlayerProfileDetail1InputField1InputFieldPlaceholder == null || _playFabDemoPlayFabPlayerProfileDetail1InputField1InputFieldPlaceholder.CurrentVersion != Template.Version)
#else
                if (_playFabDemoPlayFabPlayerProfileDetail1InputField1InputFieldPlaceholder == null)
#endif
                {
                    _playFabDemoPlayFabPlayerProfileDetail1InputField1InputFieldPlaceholder = new Template(PlayFabPlayerProfileDetailTemplates.PlayFabPlayerProfileDetailInputField1InputFieldPlaceholder);
#if UNITY_EDITOR
                    _playFabDemoPlayFabPlayerProfileDetail1InputField1InputFieldPlaceholder.Name = "PlayFabDemoPlayFabPlayerProfileDetail1InputField1InputFieldPlaceholder";
                    _playFabDemoPlayFabPlayerProfileDetail1InputField1InputFieldPlaceholder.LineNumber = 12;
                    _playFabDemoPlayFabPlayerProfileDetail1InputField1InputFieldPlaceholder.LinePosition = 4;
#endif
                }
                return _playFabDemoPlayFabPlayerProfileDetail1InputField1InputFieldPlaceholder;
            }
        }

        private static Template _playFabDemoPlayFabPlayerProfileDetail1InputField1TextArea;
        public static Template PlayFabDemoPlayFabPlayerProfileDetail1InputField1TextArea
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoPlayFabPlayerProfileDetail1InputField1TextArea == null || _playFabDemoPlayFabPlayerProfileDetail1InputField1TextArea.CurrentVersion != Template.Version)
#else
                if (_playFabDemoPlayFabPlayerProfileDetail1InputField1TextArea == null)
#endif
                {
                    _playFabDemoPlayFabPlayerProfileDetail1InputField1TextArea = new Template(PlayFabPlayerProfileDetailTemplates.PlayFabPlayerProfileDetailInputField1TextArea);
#if UNITY_EDITOR
                    _playFabDemoPlayFabPlayerProfileDetail1InputField1TextArea.Name = "PlayFabDemoPlayFabPlayerProfileDetail1InputField1TextArea";
                    _playFabDemoPlayFabPlayerProfileDetail1InputField1TextArea.LineNumber = 13;
                    _playFabDemoPlayFabPlayerProfileDetail1InputField1TextArea.LinePosition = 4;
#endif
                }
                return _playFabDemoPlayFabPlayerProfileDetail1InputField1TextArea;
            }
        }

        private static Template _playFabDemoPlayFabPlayerProfileDetail1InputField1InputText;
        public static Template PlayFabDemoPlayFabPlayerProfileDetail1InputField1InputText
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoPlayFabPlayerProfileDetail1InputField1InputText == null || _playFabDemoPlayFabPlayerProfileDetail1InputField1InputText.CurrentVersion != Template.Version)
#else
                if (_playFabDemoPlayFabPlayerProfileDetail1InputField1InputText == null)
#endif
                {
                    _playFabDemoPlayFabPlayerProfileDetail1InputField1InputText = new Template(PlayFabPlayerProfileDetailTemplates.PlayFabPlayerProfileDetailInputField1InputText);
#if UNITY_EDITOR
                    _playFabDemoPlayFabPlayerProfileDetail1InputField1InputText.Name = "PlayFabDemoPlayFabPlayerProfileDetail1InputField1InputText";
                    _playFabDemoPlayFabPlayerProfileDetail1InputField1InputText.LineNumber = 14;
                    _playFabDemoPlayFabPlayerProfileDetail1InputField1InputText.LinePosition = 6;
#endif
                }
                return _playFabDemoPlayFabPlayerProfileDetail1InputField1InputText;
            }
        }

        private static Template _playFabDemoPlayFabPlayerProfileDetail1Group2;
        public static Template PlayFabDemoPlayFabPlayerProfileDetail1Group2
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoPlayFabPlayerProfileDetail1Group2 == null || _playFabDemoPlayFabPlayerProfileDetail1Group2.CurrentVersion != Template.Version)
#else
                if (_playFabDemoPlayFabPlayerProfileDetail1Group2 == null)
#endif
                {
                    _playFabDemoPlayFabPlayerProfileDetail1Group2 = new Template(PlayFabPlayerProfileDetailTemplates.PlayFabPlayerProfileDetailGroup2);
#if UNITY_EDITOR
                    _playFabDemoPlayFabPlayerProfileDetail1Group2.Name = "PlayFabDemoPlayFabPlayerProfileDetail1Group2";
                    _playFabDemoPlayFabPlayerProfileDetail1Group2.LineNumber = 13;
                    _playFabDemoPlayFabPlayerProfileDetail1Group2.LinePosition = 8;
#endif
                }
                return _playFabDemoPlayFabPlayerProfileDetail1Group2;
            }
        }

        private static Template _playFabDemoPlayFabPlayerProfileDetail1Label5;
        public static Template PlayFabDemoPlayFabPlayerProfileDetail1Label5
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoPlayFabPlayerProfileDetail1Label5 == null || _playFabDemoPlayFabPlayerProfileDetail1Label5.CurrentVersion != Template.Version)
#else
                if (_playFabDemoPlayFabPlayerProfileDetail1Label5 == null)
#endif
                {
                    _playFabDemoPlayFabPlayerProfileDetail1Label5 = new Template(PlayFabPlayerProfileDetailTemplates.PlayFabPlayerProfileDetailLabel5);
#if UNITY_EDITOR
                    _playFabDemoPlayFabPlayerProfileDetail1Label5.Name = "PlayFabDemoPlayFabPlayerProfileDetail1Label5";
                    _playFabDemoPlayFabPlayerProfileDetail1Label5.LineNumber = 14;
                    _playFabDemoPlayFabPlayerProfileDetail1Label5.LinePosition = 10;
#endif
                }
                return _playFabDemoPlayFabPlayerProfileDetail1Label5;
            }
        }

        private static Template _playFabDemoPlayFabPlayerProfileDetail1List1;
        public static Template PlayFabDemoPlayFabPlayerProfileDetail1List1
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoPlayFabPlayerProfileDetail1List1 == null || _playFabDemoPlayFabPlayerProfileDetail1List1.CurrentVersion != Template.Version)
#else
                if (_playFabDemoPlayFabPlayerProfileDetail1List1 == null)
#endif
                {
                    _playFabDemoPlayFabPlayerProfileDetail1List1 = new Template(PlayFabPlayerProfileDetailTemplates.PlayFabPlayerProfileDetailList1);
#if UNITY_EDITOR
                    _playFabDemoPlayFabPlayerProfileDetail1List1.Name = "PlayFabDemoPlayFabPlayerProfileDetail1List1";
                    _playFabDemoPlayFabPlayerProfileDetail1List1.LineNumber = 15;
                    _playFabDemoPlayFabPlayerProfileDetail1List1.LinePosition = 10;
#endif
                    Delight.List.ScrollableRegionTemplateProperty.SetDefault(_playFabDemoPlayFabPlayerProfileDetail1List1, PlayFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegion);
                }
                return _playFabDemoPlayFabPlayerProfileDetail1List1;
            }
        }

        private static Template _playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegion;
        public static Template PlayFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegion == null || _playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegion.CurrentVersion != Template.Version)
#else
                if (_playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegion == null)
#endif
                {
                    _playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegion = new Template(PlayFabPlayerProfileDetailTemplates.PlayFabPlayerProfileDetailList1ScrollableRegion);
#if UNITY_EDITOR
                    _playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegion.Name = "PlayFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegion";
                    _playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegion.LineNumber = 29;
                    _playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegion.LinePosition = 4;
#endif
                    Delight.ScrollableRegion.ContentRegionTemplateProperty.SetDefault(_playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegion, PlayFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionContentRegion);
                    Delight.ScrollableRegion.HorizontalScrollbarTemplateProperty.SetDefault(_playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegion, PlayFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionHorizontalScrollbar);
                    Delight.ScrollableRegion.VerticalScrollbarTemplateProperty.SetDefault(_playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegion, PlayFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionVerticalScrollbar);
                }
                return _playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegion;
            }
        }

        private static Template _playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionContentRegion;
        public static Template PlayFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionContentRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionContentRegion == null || _playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionContentRegion.CurrentVersion != Template.Version)
#else
                if (_playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionContentRegion == null)
#endif
                {
                    _playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionContentRegion = new Template(PlayFabPlayerProfileDetailTemplates.PlayFabPlayerProfileDetailList1ScrollableRegionContentRegion);
#if UNITY_EDITOR
                    _playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionContentRegion.Name = "PlayFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionContentRegion";
                    _playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionContentRegion.LineNumber = 24;
                    _playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionContentRegion.LinePosition = 4;
#endif
                }
                return _playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionContentRegion;
            }
        }

        private static Template _playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionHorizontalScrollbar;
        public static Template PlayFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionHorizontalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionHorizontalScrollbar == null || _playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionHorizontalScrollbar.CurrentVersion != Template.Version)
#else
                if (_playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionHorizontalScrollbar == null)
#endif
                {
                    _playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionHorizontalScrollbar = new Template(PlayFabPlayerProfileDetailTemplates.PlayFabPlayerProfileDetailList1ScrollableRegionHorizontalScrollbar);
#if UNITY_EDITOR
                    _playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionHorizontalScrollbar.Name = "PlayFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionHorizontalScrollbar";
                    _playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionHorizontalScrollbar.LineNumber = 26;
                    _playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionHorizontalScrollbar.LinePosition = 4;
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionHorizontalScrollbar, PlayFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionHorizontalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionHorizontalScrollbar, PlayFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionHorizontalScrollbarHandle);
                }
                return _playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionHorizontalScrollbar;
            }
        }

        private static Template _playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionHorizontalScrollbarBar;
        public static Template PlayFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionHorizontalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionHorizontalScrollbarBar == null || _playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionHorizontalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionHorizontalScrollbarBar == null)
#endif
                {
                    _playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionHorizontalScrollbarBar = new Template(PlayFabPlayerProfileDetailTemplates.PlayFabPlayerProfileDetailList1ScrollableRegionHorizontalScrollbarBar);
#if UNITY_EDITOR
                    _playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionHorizontalScrollbarBar.Name = "PlayFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionHorizontalScrollbarBar";
                    _playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionHorizontalScrollbarBar.LineNumber = 7;
                    _playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionHorizontalScrollbarBar.LinePosition = 4;
#endif
                }
                return _playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionHorizontalScrollbarBar;
            }
        }

        private static Template _playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionHorizontalScrollbarHandle;
        public static Template PlayFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionHorizontalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionHorizontalScrollbarHandle == null || _playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionHorizontalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionHorizontalScrollbarHandle == null)
#endif
                {
                    _playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionHorizontalScrollbarHandle = new Template(PlayFabPlayerProfileDetailTemplates.PlayFabPlayerProfileDetailList1ScrollableRegionHorizontalScrollbarHandle);
#if UNITY_EDITOR
                    _playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionHorizontalScrollbarHandle.Name = "PlayFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionHorizontalScrollbarHandle";
                    _playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionHorizontalScrollbarHandle.LineNumber = 8;
                    _playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionHorizontalScrollbarHandle.LinePosition = 6;
#endif
                }
                return _playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionHorizontalScrollbarHandle;
            }
        }

        private static Template _playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionVerticalScrollbar;
        public static Template PlayFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionVerticalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionVerticalScrollbar == null || _playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionVerticalScrollbar.CurrentVersion != Template.Version)
#else
                if (_playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionVerticalScrollbar == null)
#endif
                {
                    _playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionVerticalScrollbar = new Template(PlayFabPlayerProfileDetailTemplates.PlayFabPlayerProfileDetailList1ScrollableRegionVerticalScrollbar);
#if UNITY_EDITOR
                    _playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionVerticalScrollbar.Name = "PlayFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionVerticalScrollbar";
                    _playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionVerticalScrollbar.LineNumber = 27;
                    _playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionVerticalScrollbar.LinePosition = 4;
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionVerticalScrollbar, PlayFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionVerticalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionVerticalScrollbar, PlayFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionVerticalScrollbarHandle);
                }
                return _playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionVerticalScrollbar;
            }
        }

        private static Template _playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionVerticalScrollbarBar;
        public static Template PlayFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionVerticalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionVerticalScrollbarBar == null || _playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionVerticalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionVerticalScrollbarBar == null)
#endif
                {
                    _playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionVerticalScrollbarBar = new Template(PlayFabPlayerProfileDetailTemplates.PlayFabPlayerProfileDetailList1ScrollableRegionVerticalScrollbarBar);
#if UNITY_EDITOR
                    _playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionVerticalScrollbarBar.Name = "PlayFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionVerticalScrollbarBar";
                    _playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionVerticalScrollbarBar.LineNumber = 7;
                    _playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionVerticalScrollbarBar.LinePosition = 4;
#endif
                }
                return _playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionVerticalScrollbarBar;
            }
        }

        private static Template _playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionVerticalScrollbarHandle;
        public static Template PlayFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionVerticalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionVerticalScrollbarHandle == null || _playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionVerticalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionVerticalScrollbarHandle == null)
#endif
                {
                    _playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionVerticalScrollbarHandle = new Template(PlayFabPlayerProfileDetailTemplates.PlayFabPlayerProfileDetailList1ScrollableRegionVerticalScrollbarHandle);
#if UNITY_EDITOR
                    _playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionVerticalScrollbarHandle.Name = "PlayFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionVerticalScrollbarHandle";
                    _playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionVerticalScrollbarHandle.LineNumber = 8;
                    _playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionVerticalScrollbarHandle.LinePosition = 6;
#endif
                }
                return _playFabDemoPlayFabPlayerProfileDetail1List1ScrollableRegionVerticalScrollbarHandle;
            }
        }

        private static Template _playFabDemoPlayFabPlayerProfileDetail1ListItem1;
        public static Template PlayFabDemoPlayFabPlayerProfileDetail1ListItem1
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoPlayFabPlayerProfileDetail1ListItem1 == null || _playFabDemoPlayFabPlayerProfileDetail1ListItem1.CurrentVersion != Template.Version)
#else
                if (_playFabDemoPlayFabPlayerProfileDetail1ListItem1 == null)
#endif
                {
                    _playFabDemoPlayFabPlayerProfileDetail1ListItem1 = new Template(PlayFabPlayerProfileDetailTemplates.PlayFabPlayerProfileDetailListItem1);
#if UNITY_EDITOR
                    _playFabDemoPlayFabPlayerProfileDetail1ListItem1.Name = "PlayFabDemoPlayFabPlayerProfileDetail1ListItem1";
                    _playFabDemoPlayFabPlayerProfileDetail1ListItem1.LineNumber = 17;
                    _playFabDemoPlayFabPlayerProfileDetail1ListItem1.LinePosition = 12;
#endif
                }
                return _playFabDemoPlayFabPlayerProfileDetail1ListItem1;
            }
        }

        private static Template _playFabDemoPlayFabPlayerProfileDetail1Grid2;
        public static Template PlayFabDemoPlayFabPlayerProfileDetail1Grid2
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoPlayFabPlayerProfileDetail1Grid2 == null || _playFabDemoPlayFabPlayerProfileDetail1Grid2.CurrentVersion != Template.Version)
#else
                if (_playFabDemoPlayFabPlayerProfileDetail1Grid2 == null)
#endif
                {
                    _playFabDemoPlayFabPlayerProfileDetail1Grid2 = new Template(PlayFabPlayerProfileDetailTemplates.PlayFabPlayerProfileDetailGrid2);
#if UNITY_EDITOR
                    _playFabDemoPlayFabPlayerProfileDetail1Grid2.Name = "PlayFabDemoPlayFabPlayerProfileDetail1Grid2";
                    _playFabDemoPlayFabPlayerProfileDetail1Grid2.LineNumber = 19;
                    _playFabDemoPlayFabPlayerProfileDetail1Grid2.LinePosition = 14;
#endif
                }
                return _playFabDemoPlayFabPlayerProfileDetail1Grid2;
            }
        }

        private static Template _playFabDemoPlayFabPlayerProfileDetail1Label6;
        public static Template PlayFabDemoPlayFabPlayerProfileDetail1Label6
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoPlayFabPlayerProfileDetail1Label6 == null || _playFabDemoPlayFabPlayerProfileDetail1Label6.CurrentVersion != Template.Version)
#else
                if (_playFabDemoPlayFabPlayerProfileDetail1Label6 == null)
#endif
                {
                    _playFabDemoPlayFabPlayerProfileDetail1Label6 = new Template(PlayFabPlayerProfileDetailTemplates.PlayFabPlayerProfileDetailLabel6);
#if UNITY_EDITOR
                    _playFabDemoPlayFabPlayerProfileDetail1Label6.Name = "PlayFabDemoPlayFabPlayerProfileDetail1Label6";
                    _playFabDemoPlayFabPlayerProfileDetail1Label6.LineNumber = 20;
                    _playFabDemoPlayFabPlayerProfileDetail1Label6.LinePosition = 16;
#endif
                }
                return _playFabDemoPlayFabPlayerProfileDetail1Label6;
            }
        }

        private static Template _playFabDemoPlayFabPlayerProfileDetail1Label7;
        public static Template PlayFabDemoPlayFabPlayerProfileDetail1Label7
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoPlayFabPlayerProfileDetail1Label7 == null || _playFabDemoPlayFabPlayerProfileDetail1Label7.CurrentVersion != Template.Version)
#else
                if (_playFabDemoPlayFabPlayerProfileDetail1Label7 == null)
#endif
                {
                    _playFabDemoPlayFabPlayerProfileDetail1Label7 = new Template(PlayFabPlayerProfileDetailTemplates.PlayFabPlayerProfileDetailLabel7);
#if UNITY_EDITOR
                    _playFabDemoPlayFabPlayerProfileDetail1Label7.Name = "PlayFabDemoPlayFabPlayerProfileDetail1Label7";
                    _playFabDemoPlayFabPlayerProfileDetail1Label7.LineNumber = 21;
                    _playFabDemoPlayFabPlayerProfileDetail1Label7.LinePosition = 16;
#endif
                }
                return _playFabDemoPlayFabPlayerProfileDetail1Label7;
            }
        }

        private static Template _playFabDemoPlayFabPlayerProfileDetail1Label8;
        public static Template PlayFabDemoPlayFabPlayerProfileDetail1Label8
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoPlayFabPlayerProfileDetail1Label8 == null || _playFabDemoPlayFabPlayerProfileDetail1Label8.CurrentVersion != Template.Version)
#else
                if (_playFabDemoPlayFabPlayerProfileDetail1Label8 == null)
#endif
                {
                    _playFabDemoPlayFabPlayerProfileDetail1Label8 = new Template(PlayFabPlayerProfileDetailTemplates.PlayFabPlayerProfileDetailLabel8);
#if UNITY_EDITOR
                    _playFabDemoPlayFabPlayerProfileDetail1Label8.Name = "PlayFabDemoPlayFabPlayerProfileDetail1Label8";
                    _playFabDemoPlayFabPlayerProfileDetail1Label8.LineNumber = 23;
                    _playFabDemoPlayFabPlayerProfileDetail1Label8.LinePosition = 16;
#endif
                }
                return _playFabDemoPlayFabPlayerProfileDetail1Label8;
            }
        }

        private static Template _playFabDemoPlayFabPlayerProfileDetail1Label9;
        public static Template PlayFabDemoPlayFabPlayerProfileDetail1Label9
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoPlayFabPlayerProfileDetail1Label9 == null || _playFabDemoPlayFabPlayerProfileDetail1Label9.CurrentVersion != Template.Version)
#else
                if (_playFabDemoPlayFabPlayerProfileDetail1Label9 == null)
#endif
                {
                    _playFabDemoPlayFabPlayerProfileDetail1Label9 = new Template(PlayFabPlayerProfileDetailTemplates.PlayFabPlayerProfileDetailLabel9);
#if UNITY_EDITOR
                    _playFabDemoPlayFabPlayerProfileDetail1Label9.Name = "PlayFabDemoPlayFabPlayerProfileDetail1Label9";
                    _playFabDemoPlayFabPlayerProfileDetail1Label9.LineNumber = 24;
                    _playFabDemoPlayFabPlayerProfileDetail1Label9.LinePosition = 16;
#endif
                }
                return _playFabDemoPlayFabPlayerProfileDetail1Label9;
            }
        }

        private static Template _playFabDemoPlayFabPlayerProfileDetail1Group3;
        public static Template PlayFabDemoPlayFabPlayerProfileDetail1Group3
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoPlayFabPlayerProfileDetail1Group3 == null || _playFabDemoPlayFabPlayerProfileDetail1Group3.CurrentVersion != Template.Version)
#else
                if (_playFabDemoPlayFabPlayerProfileDetail1Group3 == null)
#endif
                {
                    _playFabDemoPlayFabPlayerProfileDetail1Group3 = new Template(PlayFabPlayerProfileDetailTemplates.PlayFabPlayerProfileDetailGroup3);
#if UNITY_EDITOR
                    _playFabDemoPlayFabPlayerProfileDetail1Group3.Name = "PlayFabDemoPlayFabPlayerProfileDetail1Group3";
                    _playFabDemoPlayFabPlayerProfileDetail1Group3.LineNumber = 29;
                    _playFabDemoPlayFabPlayerProfileDetail1Group3.LinePosition = 10;
#endif
                }
                return _playFabDemoPlayFabPlayerProfileDetail1Group3;
            }
        }

        private static Template _playFabDemoPlayFabPlayerProfileDetail1Button1;
        public static Template PlayFabDemoPlayFabPlayerProfileDetail1Button1
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoPlayFabPlayerProfileDetail1Button1 == null || _playFabDemoPlayFabPlayerProfileDetail1Button1.CurrentVersion != Template.Version)
#else
                if (_playFabDemoPlayFabPlayerProfileDetail1Button1 == null)
#endif
                {
                    _playFabDemoPlayFabPlayerProfileDetail1Button1 = new Template(PlayFabPlayerProfileDetailTemplates.PlayFabPlayerProfileDetailButton1);
#if UNITY_EDITOR
                    _playFabDemoPlayFabPlayerProfileDetail1Button1.Name = "PlayFabDemoPlayFabPlayerProfileDetail1Button1";
                    _playFabDemoPlayFabPlayerProfileDetail1Button1.LineNumber = 30;
                    _playFabDemoPlayFabPlayerProfileDetail1Button1.LinePosition = 12;
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_playFabDemoPlayFabPlayerProfileDetail1Button1, PlayFabDemoPlayFabPlayerProfileDetail1Button1Label);
                }
                return _playFabDemoPlayFabPlayerProfileDetail1Button1;
            }
        }

        private static Template _playFabDemoPlayFabPlayerProfileDetail1Button1Label;
        public static Template PlayFabDemoPlayFabPlayerProfileDetail1Button1Label
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoPlayFabPlayerProfileDetail1Button1Label == null || _playFabDemoPlayFabPlayerProfileDetail1Button1Label.CurrentVersion != Template.Version)
#else
                if (_playFabDemoPlayFabPlayerProfileDetail1Button1Label == null)
#endif
                {
                    _playFabDemoPlayFabPlayerProfileDetail1Button1Label = new Template(PlayFabPlayerProfileDetailTemplates.PlayFabPlayerProfileDetailButton1Label);
#if UNITY_EDITOR
                    _playFabDemoPlayFabPlayerProfileDetail1Button1Label.Name = "PlayFabDemoPlayFabPlayerProfileDetail1Button1Label";
                    _playFabDemoPlayFabPlayerProfileDetail1Button1Label.LineNumber = 15;
                    _playFabDemoPlayFabPlayerProfileDetail1Button1Label.LinePosition = 4;
#endif
                }
                return _playFabDemoPlayFabPlayerProfileDetail1Button1Label;
            }
        }

        private static Template _playFabDemoPlayFabPlayerProfileDetail1Button2;
        public static Template PlayFabDemoPlayFabPlayerProfileDetail1Button2
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoPlayFabPlayerProfileDetail1Button2 == null || _playFabDemoPlayFabPlayerProfileDetail1Button2.CurrentVersion != Template.Version)
#else
                if (_playFabDemoPlayFabPlayerProfileDetail1Button2 == null)
#endif
                {
                    _playFabDemoPlayFabPlayerProfileDetail1Button2 = new Template(PlayFabPlayerProfileDetailTemplates.PlayFabPlayerProfileDetailButton2);
#if UNITY_EDITOR
                    _playFabDemoPlayFabPlayerProfileDetail1Button2.Name = "PlayFabDemoPlayFabPlayerProfileDetail1Button2";
                    _playFabDemoPlayFabPlayerProfileDetail1Button2.LineNumber = 31;
                    _playFabDemoPlayFabPlayerProfileDetail1Button2.LinePosition = 12;
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_playFabDemoPlayFabPlayerProfileDetail1Button2, PlayFabDemoPlayFabPlayerProfileDetail1Button2Label);
                }
                return _playFabDemoPlayFabPlayerProfileDetail1Button2;
            }
        }

        private static Template _playFabDemoPlayFabPlayerProfileDetail1Button2Label;
        public static Template PlayFabDemoPlayFabPlayerProfileDetail1Button2Label
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoPlayFabPlayerProfileDetail1Button2Label == null || _playFabDemoPlayFabPlayerProfileDetail1Button2Label.CurrentVersion != Template.Version)
#else
                if (_playFabDemoPlayFabPlayerProfileDetail1Button2Label == null)
#endif
                {
                    _playFabDemoPlayFabPlayerProfileDetail1Button2Label = new Template(PlayFabPlayerProfileDetailTemplates.PlayFabPlayerProfileDetailButton2Label);
#if UNITY_EDITOR
                    _playFabDemoPlayFabPlayerProfileDetail1Button2Label.Name = "PlayFabDemoPlayFabPlayerProfileDetail1Button2Label";
                    _playFabDemoPlayFabPlayerProfileDetail1Button2Label.LineNumber = 15;
                    _playFabDemoPlayFabPlayerProfileDetail1Button2Label.LinePosition = 4;
#endif
                }
                return _playFabDemoPlayFabPlayerProfileDetail1Button2Label;
            }
        }

        private static Template _playFabDemoPlayFabPlayerProfileDetail1Region1;
        public static Template PlayFabDemoPlayFabPlayerProfileDetail1Region1
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoPlayFabPlayerProfileDetail1Region1 == null || _playFabDemoPlayFabPlayerProfileDetail1Region1.CurrentVersion != Template.Version)
#else
                if (_playFabDemoPlayFabPlayerProfileDetail1Region1 == null)
#endif
                {
                    _playFabDemoPlayFabPlayerProfileDetail1Region1 = new Template(PlayFabPlayerProfileDetailTemplates.PlayFabPlayerProfileDetailRegion1);
#if UNITY_EDITOR
                    _playFabDemoPlayFabPlayerProfileDetail1Region1.Name = "PlayFabDemoPlayFabPlayerProfileDetail1Region1";
                    _playFabDemoPlayFabPlayerProfileDetail1Region1.LineNumber = 36;
                    _playFabDemoPlayFabPlayerProfileDetail1Region1.LinePosition = 4;
#endif
                }
                return _playFabDemoPlayFabPlayerProfileDetail1Region1;
            }
        }

        private static Template _playFabDemoPlayFabPlayerProfileDetail1Label10;
        public static Template PlayFabDemoPlayFabPlayerProfileDetail1Label10
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabDemoPlayFabPlayerProfileDetail1Label10 == null || _playFabDemoPlayFabPlayerProfileDetail1Label10.CurrentVersion != Template.Version)
#else
                if (_playFabDemoPlayFabPlayerProfileDetail1Label10 == null)
#endif
                {
                    _playFabDemoPlayFabPlayerProfileDetail1Label10 = new Template(PlayFabPlayerProfileDetailTemplates.PlayFabPlayerProfileDetailLabel10);
#if UNITY_EDITOR
                    _playFabDemoPlayFabPlayerProfileDetail1Label10.Name = "PlayFabDemoPlayFabPlayerProfileDetail1Label10";
                    _playFabDemoPlayFabPlayerProfileDetail1Label10.LineNumber = 37;
                    _playFabDemoPlayFabPlayerProfileDetail1Label10.LinePosition = 6;
#endif
                }
                return _playFabDemoPlayFabPlayerProfileDetail1Label10;
            }
        }

        #endregion
    }

    #endregion
}

#endif
