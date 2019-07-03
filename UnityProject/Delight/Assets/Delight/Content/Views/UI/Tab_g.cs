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

        public Tab(View parent, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :
            base(parent, layoutParent, id, template ?? TabTemplates.Default, initializer)
        {
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
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<Delight.ContentTemplateData> ContentTemplateDataProperty = new DependencyProperty<Delight.ContentTemplateData>("ContentTemplateData");
        public Delight.ContentTemplateData ContentTemplateData
        {
            get { return ContentTemplateDataProperty.GetValue(this); }
            set { ContentTemplateDataProperty.SetValue(this, value); }
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
#endif
                }
                return _tab;
            }
        }

        #endregion
    }

    #endregion
}
