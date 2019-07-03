// Internal view logic generated from "TabPanel.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class TabPanel : Collection
    {
        #region Constructors

        public TabPanel(View parent, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :
            base(parent, layoutParent, id, template ?? TabPanelTemplates.Default, initializer)
        {
            // constructing ViewSwitcher (TabSwitcher)
            TabSwitcher = new ViewSwitcher(this, this, "TabSwitcher", TabSwitcherTemplate);

            // constructing ToggleGroup (TabHeaderGroup)
            TabHeaderGroup = new ToggleGroup(this, this, "TabHeaderGroup", TabHeaderGroupTemplate);
            ContentContainer = TabSwitcher;
            this.AfterInitializeInternal();
        }

        public TabPanel() : this(null)
        {
        }

        static TabPanel()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(TabPanelTemplates.Default, dependencyProperties);

            dependencyProperties.Add(SelectedTabIndexProperty);
            dependencyProperties.Add(TabSwitcherProperty);
            dependencyProperties.Add(TabSwitcherTemplateProperty);
            dependencyProperties.Add(TabHeaderGroupProperty);
            dependencyProperties.Add(TabHeaderGroupTemplateProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<System.Int32> SelectedTabIndexProperty = new DependencyProperty<System.Int32>("SelectedTabIndex");
        public System.Int32 SelectedTabIndex
        {
            get { return SelectedTabIndexProperty.GetValue(this); }
            set { SelectedTabIndexProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ViewSwitcher> TabSwitcherProperty = new DependencyProperty<ViewSwitcher>("TabSwitcher");
        public ViewSwitcher TabSwitcher
        {
            get { return TabSwitcherProperty.GetValue(this); }
            set { TabSwitcherProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> TabSwitcherTemplateProperty = new DependencyProperty<Template>("TabSwitcherTemplate");
        public Template TabSwitcherTemplate
        {
            get { return TabSwitcherTemplateProperty.GetValue(this); }
            set { TabSwitcherTemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ToggleGroup> TabHeaderGroupProperty = new DependencyProperty<ToggleGroup>("TabHeaderGroup");
        public ToggleGroup TabHeaderGroup
        {
            get { return TabHeaderGroupProperty.GetValue(this); }
            set { TabHeaderGroupProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> TabHeaderGroupTemplateProperty = new DependencyProperty<Template>("TabHeaderGroupTemplate");
        public Template TabHeaderGroupTemplate
        {
            get { return TabHeaderGroupTemplateProperty.GetValue(this); }
            set { TabHeaderGroupTemplateProperty.SetValue(this, value); }
        }

        #endregion
    }

    #region Data Templates

    public static class TabPanelTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return TabPanel;
            }
        }

        private static Template _tabPanel;
        public static Template TabPanel
        {
            get
            {
#if UNITY_EDITOR
                if (_tabPanel == null || _tabPanel.CurrentVersion != Template.Version)
#else
                if (_tabPanel == null)
#endif
                {
                    _tabPanel = new Template(CollectionTemplates.Collection);
#if UNITY_EDITOR
                    _tabPanel.Name = "TabPanel";
#endif
                    Delight.TabPanel.SelectedTabIndexProperty.SetDefault(_tabPanel, 0);
                    Delight.TabPanel.TabSwitcherTemplateProperty.SetDefault(_tabPanel, TabPanelTabSwitcher);
                    Delight.TabPanel.TabHeaderGroupTemplateProperty.SetDefault(_tabPanel, TabPanelTabHeaderGroup);
                }
                return _tabPanel;
            }
        }

        private static Template _tabPanelTabSwitcher;
        public static Template TabPanelTabSwitcher
        {
            get
            {
#if UNITY_EDITOR
                if (_tabPanelTabSwitcher == null || _tabPanelTabSwitcher.CurrentVersion != Template.Version)
#else
                if (_tabPanelTabSwitcher == null)
#endif
                {
                    _tabPanelTabSwitcher = new Template(ViewSwitcherTemplates.ViewSwitcher);
#if UNITY_EDITOR
                    _tabPanelTabSwitcher.Name = "TabPanelTabSwitcher";
#endif
                }
                return _tabPanelTabSwitcher;
            }
        }

        private static Template _tabPanelTabHeaderGroup;
        public static Template TabPanelTabHeaderGroup
        {
            get
            {
#if UNITY_EDITOR
                if (_tabPanelTabHeaderGroup == null || _tabPanelTabHeaderGroup.CurrentVersion != Template.Version)
#else
                if (_tabPanelTabHeaderGroup == null)
#endif
                {
                    _tabPanelTabHeaderGroup = new Template(ToggleGroupTemplates.ToggleGroup);
#if UNITY_EDITOR
                    _tabPanelTabHeaderGroup.Name = "TabPanelTabHeaderGroup";
#endif
                    Delight.ToggleGroup.OrientationProperty.SetDefault(_tabPanelTabHeaderGroup, Delight.ElementOrientation.Horizontal);
                    Delight.ToggleGroup.AlignmentProperty.SetDefault(_tabPanelTabHeaderGroup, Delight.ElementAlignment.TopLeft);
                }
                return _tabPanelTabHeaderGroup;
            }
        }

        #endregion
    }

    #endregion
}
