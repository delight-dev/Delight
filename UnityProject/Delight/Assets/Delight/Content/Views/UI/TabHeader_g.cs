// Internal view logic generated from "TabHeader.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class TabHeader : Button
    {
        #region Constructors

        public TabHeader(View parent, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :
            base(parent, layoutParent, id, template ?? TabHeaderTemplates.Default, initializer)
        {
            ToggleClick.RegisterHandler(this, "TabToggleClick");
            this.AfterInitializeInternal();
        }

        public TabHeader() : this(null)
        {
        }

        static TabHeader()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(TabHeaderTemplates.Default, dependencyProperties);

            dependencyProperties.Add(ContentTemplateDataProperty);
            dependencyProperties.Add(TabIndexProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<Delight.ContentTemplateData> ContentTemplateDataProperty = new DependencyProperty<Delight.ContentTemplateData>("ContentTemplateData");
        public Delight.ContentTemplateData ContentTemplateData
        {
            get { return ContentTemplateDataProperty.GetValue(this); }
            set { ContentTemplateDataProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Int32> TabIndexProperty = new DependencyProperty<System.Int32>("TabIndex");
        public System.Int32 TabIndex
        {
            get { return TabIndexProperty.GetValue(this); }
            set { TabIndexProperty.SetValue(this, value); }
        }

        #endregion
    }

    #region Data Templates

    public static class TabHeaderTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return TabHeader;
            }
        }

        private static Template _tabHeader;
        public static Template TabHeader
        {
            get
            {
#if UNITY_EDITOR
                if (_tabHeader == null || _tabHeader.CurrentVersion != Template.Version)
#else
                if (_tabHeader == null)
#endif
                {
                    _tabHeader = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _tabHeader.Name = "TabHeader";
#endif
                    Delight.TabHeader.LabelTemplateProperty.SetDefault(_tabHeader, TabHeaderLabel);
                }
                return _tabHeader;
            }
        }

        private static Template _tabHeaderLabel;
        public static Template TabHeaderLabel
        {
            get
            {
#if UNITY_EDITOR
                if (_tabHeaderLabel == null || _tabHeaderLabel.CurrentVersion != Template.Version)
#else
                if (_tabHeaderLabel == null)
#endif
                {
                    _tabHeaderLabel = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _tabHeaderLabel.Name = "TabHeaderLabel";
#endif
                }
                return _tabHeaderLabel;
            }
        }

        #endregion
    }

    #endregion
}
