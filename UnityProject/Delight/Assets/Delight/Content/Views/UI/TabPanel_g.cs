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
            this.AfterInitializeInternal();
        }

        public TabPanel() : this(null)
        {
        }

        static TabPanel()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(TabPanelTemplates.Default, dependencyProperties);
        }

        #endregion

        #region Properties

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
                }
                return _tabPanel;
            }
        }

        #endregion
    }

    #endregion
}
