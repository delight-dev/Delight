// Internal view logic generated from "TabPanelExample.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class TabPanelExample : UIView
    {
        #region Constructors

        public TabPanelExample(View parent, View layoutParent = null, string id = null, Template template = null, bool deferInitialization = false) :
            base(parent, layoutParent, id, template ?? TabPanelExampleTemplates.Default, deferInitialization)
        {
            if (deferInitialization)
                return;

            // constructing TabPanel (TabPanel1)
            TabPanel1 = new TabPanel(this, this, "TabPanel1", TabPanel1Template);

            // binding <TabPanel Items="{player in @DemoPlayers}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> {  }, new List<Func<BindableObject>> {  }) }, new BindingPath(new List<string> { "TabPanel1", "Items" }, new List<Func<BindableObject>> { () => this, () => TabPanel1 }), () => TabPanel1.Items = Models.DemoPlayers, () => { }, false));

            // templates for TabPanel1
            TabPanel1.ContentTemplates.Add(new ContentTemplate(tiPlayer => 
            {
                var tabHeader1 = new TabHeader(this, TabPanel1.Content, "TabHeader1", TabHeader1Template);

                // binding <TabHeader Text="{player.Name}">
                tabHeader1.Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "Item", "Name" }, new List<Func<BindableObject>> { () => tiPlayer, () => (tiPlayer.Item as Delight.DemoPlayer) }) }, new BindingPath(new List<string> { "Text" }, new List<Func<BindableObject>> { () => tabHeader1 }), () => tabHeader1.Text = (tiPlayer.Item as Delight.DemoPlayer).Name, () => { }, false));
                tabHeader1.IsDynamic = true;
                tabHeader1.SetContentTemplateData(tiPlayer);
                return tabHeader1;
            }, typeof(TabHeader), "TabHeader1"));

            // templates for TabPanel1
            TabPanel1.ContentTemplates.Add(new ContentTemplate(tiPlayer => 
            {
                var tab1 = new Tab(this, TabPanel1.Content, "Tab1", Tab1Template);
                var label1 = new Label(this, tab1.Content, "Label1", Label1Template);

                // binding <Label Text="{player.Name}">
                tab1.Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "Item", "Name" }, new List<Func<BindableObject>> { () => tiPlayer, () => (tiPlayer.Item as Delight.DemoPlayer) }) }, new BindingPath(new List<string> { "Text" }, new List<Func<BindableObject>> { () => label1 }), () => label1.Text = (tiPlayer.Item as Delight.DemoPlayer).Name, () => { }, false));
                tab1.IsDynamic = true;
                tab1.SetContentTemplateData(tiPlayer);
                return tab1;
            }, typeof(Tab), "Tab1"));
            this.AfterInitializeInternal();
        }

        public TabPanelExample() : this(null)
        {
        }

        static TabPanelExample()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(TabPanelExampleTemplates.Default, dependencyProperties);

            dependencyProperties.Add(TabPanel1Property);
            dependencyProperties.Add(TabPanel1TemplateProperty);
            dependencyProperties.Add(TabHeader1Property);
            dependencyProperties.Add(TabHeader1TemplateProperty);
            dependencyProperties.Add(Tab1Property);
            dependencyProperties.Add(Tab1TemplateProperty);
            dependencyProperties.Add(Label1Property);
            dependencyProperties.Add(Label1TemplateProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<TabPanel> TabPanel1Property = new DependencyProperty<TabPanel>("TabPanel1");
        public TabPanel TabPanel1
        {
            get { return TabPanel1Property.GetValue(this); }
            set { TabPanel1Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> TabPanel1TemplateProperty = new DependencyProperty<Template>("TabPanel1Template");
        public Template TabPanel1Template
        {
            get { return TabPanel1TemplateProperty.GetValue(this); }
            set { TabPanel1TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<TabHeader> TabHeader1Property = new DependencyProperty<TabHeader>("TabHeader1");
        public TabHeader TabHeader1
        {
            get { return TabHeader1Property.GetValue(this); }
            set { TabHeader1Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> TabHeader1TemplateProperty = new DependencyProperty<Template>("TabHeader1Template");
        public Template TabHeader1Template
        {
            get { return TabHeader1TemplateProperty.GetValue(this); }
            set { TabHeader1TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Tab> Tab1Property = new DependencyProperty<Tab>("Tab1");
        public Tab Tab1
        {
            get { return Tab1Property.GetValue(this); }
            set { Tab1Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Tab1TemplateProperty = new DependencyProperty<Template>("Tab1Template");
        public Template Tab1Template
        {
            get { return Tab1TemplateProperty.GetValue(this); }
            set { Tab1TemplateProperty.SetValue(this, value); }
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

        #endregion
    }

    #region Data Templates

    public static class TabPanelExampleTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return TabPanelExample;
            }
        }

        private static Template _tabPanelExample;
        public static Template TabPanelExample
        {
            get
            {
#if UNITY_EDITOR
                if (_tabPanelExample == null || _tabPanelExample.CurrentVersion != Template.Version)
#else
                if (_tabPanelExample == null)
#endif
                {
                    _tabPanelExample = new Template(UIViewTemplates.UIView);
#if UNITY_EDITOR
                    _tabPanelExample.Name = "TabPanelExample";
                    _tabPanelExample.LineNumber = 0;
                    _tabPanelExample.LinePosition = 0;
#endif
                    Delight.TabPanelExample.TabPanel1TemplateProperty.SetDefault(_tabPanelExample, TabPanelExampleTabPanel1);
                    Delight.TabPanelExample.TabHeader1TemplateProperty.SetDefault(_tabPanelExample, TabPanelExampleTabHeader1);
                    Delight.TabPanelExample.Tab1TemplateProperty.SetDefault(_tabPanelExample, TabPanelExampleTab1);
                    Delight.TabPanelExample.Label1TemplateProperty.SetDefault(_tabPanelExample, TabPanelExampleLabel1);
                }
                return _tabPanelExample;
            }
        }

        private static Template _tabPanelExampleTabPanel1;
        public static Template TabPanelExampleTabPanel1
        {
            get
            {
#if UNITY_EDITOR
                if (_tabPanelExampleTabPanel1 == null || _tabPanelExampleTabPanel1.CurrentVersion != Template.Version)
#else
                if (_tabPanelExampleTabPanel1 == null)
#endif
                {
                    _tabPanelExampleTabPanel1 = new Template(TabPanelTemplates.TabPanel);
#if UNITY_EDITOR
                    _tabPanelExampleTabPanel1.Name = "TabPanelExampleTabPanel1";
                    _tabPanelExampleTabPanel1.LineNumber = 14;
                    _tabPanelExampleTabPanel1.LinePosition = 4;
#endif
                    Delight.TabPanel.ItemsProperty.SetHasBinding(_tabPanelExampleTabPanel1);
                    Delight.TabPanel.TabSwitcherTemplateProperty.SetDefault(_tabPanelExampleTabPanel1, TabPanelExampleTabPanel1TabSwitcher);
                    Delight.TabPanel.TabHeaderGroupTemplateProperty.SetDefault(_tabPanelExampleTabPanel1, TabPanelExampleTabPanel1TabHeaderGroup);
                }
                return _tabPanelExampleTabPanel1;
            }
        }

        private static Template _tabPanelExampleTabPanel1TabSwitcher;
        public static Template TabPanelExampleTabPanel1TabSwitcher
        {
            get
            {
#if UNITY_EDITOR
                if (_tabPanelExampleTabPanel1TabSwitcher == null || _tabPanelExampleTabPanel1TabSwitcher.CurrentVersion != Template.Version)
#else
                if (_tabPanelExampleTabPanel1TabSwitcher == null)
#endif
                {
                    _tabPanelExampleTabPanel1TabSwitcher = new Template(TabPanelTemplates.TabPanelTabSwitcher);
#if UNITY_EDITOR
                    _tabPanelExampleTabPanel1TabSwitcher.Name = "TabPanelExampleTabPanel1TabSwitcher";
                    _tabPanelExampleTabPanel1TabSwitcher.LineNumber = 7;
                    _tabPanelExampleTabPanel1TabSwitcher.LinePosition = 4;
#endif
                }
                return _tabPanelExampleTabPanel1TabSwitcher;
            }
        }

        private static Template _tabPanelExampleTabPanel1TabHeaderGroup;
        public static Template TabPanelExampleTabPanel1TabHeaderGroup
        {
            get
            {
#if UNITY_EDITOR
                if (_tabPanelExampleTabPanel1TabHeaderGroup == null || _tabPanelExampleTabPanel1TabHeaderGroup.CurrentVersion != Template.Version)
#else
                if (_tabPanelExampleTabPanel1TabHeaderGroup == null)
#endif
                {
                    _tabPanelExampleTabPanel1TabHeaderGroup = new Template(TabPanelTemplates.TabPanelTabHeaderGroup);
#if UNITY_EDITOR
                    _tabPanelExampleTabPanel1TabHeaderGroup.Name = "TabPanelExampleTabPanel1TabHeaderGroup";
                    _tabPanelExampleTabPanel1TabHeaderGroup.LineNumber = 9;
                    _tabPanelExampleTabPanel1TabHeaderGroup.LinePosition = 4;
#endif
                }
                return _tabPanelExampleTabPanel1TabHeaderGroup;
            }
        }

        private static Template _tabPanelExampleTabHeader1;
        public static Template TabPanelExampleTabHeader1
        {
            get
            {
#if UNITY_EDITOR
                if (_tabPanelExampleTabHeader1 == null || _tabPanelExampleTabHeader1.CurrentVersion != Template.Version)
#else
                if (_tabPanelExampleTabHeader1 == null)
#endif
                {
                    _tabPanelExampleTabHeader1 = new Template(TabHeaderTemplates.TabHeader);
#if UNITY_EDITOR
                    _tabPanelExampleTabHeader1.Name = "TabPanelExampleTabHeader1";
                    _tabPanelExampleTabHeader1.LineNumber = 15;
                    _tabPanelExampleTabHeader1.LinePosition = 6;
#endif
                    Delight.TabHeader.LabelTemplateProperty.SetDefault(_tabPanelExampleTabHeader1, TabPanelExampleTabHeader1Label);
                }
                return _tabPanelExampleTabHeader1;
            }
        }

        private static Template _tabPanelExampleTabHeader1Label;
        public static Template TabPanelExampleTabHeader1Label
        {
            get
            {
#if UNITY_EDITOR
                if (_tabPanelExampleTabHeader1Label == null || _tabPanelExampleTabHeader1Label.CurrentVersion != Template.Version)
#else
                if (_tabPanelExampleTabHeader1Label == null)
#endif
                {
                    _tabPanelExampleTabHeader1Label = new Template(TabHeaderTemplates.TabHeaderLabel);
#if UNITY_EDITOR
                    _tabPanelExampleTabHeader1Label.Name = "TabPanelExampleTabHeader1Label";
                    _tabPanelExampleTabHeader1Label.LineNumber = 15;
                    _tabPanelExampleTabHeader1Label.LinePosition = 4;
#endif
                    Delight.Label.TextProperty.SetHasBinding(_tabPanelExampleTabHeader1Label);
                }
                return _tabPanelExampleTabHeader1Label;
            }
        }

        private static Template _tabPanelExampleTab1;
        public static Template TabPanelExampleTab1
        {
            get
            {
#if UNITY_EDITOR
                if (_tabPanelExampleTab1 == null || _tabPanelExampleTab1.CurrentVersion != Template.Version)
#else
                if (_tabPanelExampleTab1 == null)
#endif
                {
                    _tabPanelExampleTab1 = new Template(TabTemplates.Tab);
#if UNITY_EDITOR
                    _tabPanelExampleTab1.Name = "TabPanelExampleTab1";
                    _tabPanelExampleTab1.LineNumber = 16;
                    _tabPanelExampleTab1.LinePosition = 6;
#endif
                }
                return _tabPanelExampleTab1;
            }
        }

        private static Template _tabPanelExampleLabel1;
        public static Template TabPanelExampleLabel1
        {
            get
            {
#if UNITY_EDITOR
                if (_tabPanelExampleLabel1 == null || _tabPanelExampleLabel1.CurrentVersion != Template.Version)
#else
                if (_tabPanelExampleLabel1 == null)
#endif
                {
                    _tabPanelExampleLabel1 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _tabPanelExampleLabel1.Name = "TabPanelExampleLabel1";
                    _tabPanelExampleLabel1.LineNumber = 17;
                    _tabPanelExampleLabel1.LinePosition = 8;
#endif
                    Delight.Label.TextProperty.SetHasBinding(_tabPanelExampleLabel1);
                }
                return _tabPanelExampleLabel1;
            }
        }

        #endregion
    }

    #endregion
}
