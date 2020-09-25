// Internal view logic generated from "Tab.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class Tab : UIView
    {
        #region Constructors

        public Tab(View parent, View layoutParent = null, string id = null, Template template = null, bool deferInitialization = false) :
            base(parent, layoutParent, id, template ?? TabTemplates.Default, deferInitialization)
        {
            if (deferInitialization)
                return;

            this.AfterInitializeInternal();
        }

        public Tab() : this(null)
        {
        }

        static Tab()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(TabTemplates.Default, dependencyProperties);

            dependencyProperties.Add(ContentTemplateDataProperty);
            dependencyProperties.Add(TextProperty);
            dependencyProperties.Add(TabHeaderIdProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<Delight.ContentTemplateData> ContentTemplateDataProperty = new DependencyProperty<Delight.ContentTemplateData>("ContentTemplateData");
        /// <summary>Holds the content template data.</summary>
        public Delight.ContentTemplateData ContentTemplateData
        {
            get { return ContentTemplateDataProperty.GetValue(this); }
            set { ContentTemplateDataProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.String> TextProperty = new DependencyProperty<System.String>("Text");
        /// <summary>Default tab header text.</summary>
        public System.String Text
        {
            get { return TextProperty.GetValue(this); }
            set { TextProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.String> TabHeaderIdProperty = new DependencyProperty<System.String>("TabHeaderId");
        /// <summary>ID of TabHeader belonging to this tab.</summary>
        public System.String TabHeaderId
        {
            get { return TabHeaderIdProperty.GetValue(this); }
            set { TabHeaderIdProperty.SetValue(this, value); }
        }

        #endregion
    }

    #region Data Templates

    public static class TabTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return Tab;
            }
        }

        private static Template _tab;
        public static Template Tab
        {
            get
            {
#if UNITY_EDITOR
                if (_tab == null || _tab.CurrentVersion != Template.Version)
#else
                if (_tab == null)
#endif
                {
                    _tab = new Template(UIViewTemplates.UIView);
#if UNITY_EDITOR
                    _tab.Name = "Tab";
                    _tab.LineNumber = 0;
                    _tab.LinePosition = 0;
#endif
                }
                return _tab;
            }
        }

        #endregion
    }

    #endregion
}
