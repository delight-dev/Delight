// Internal view logic generated from "ExpanderContent.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class ExpanderContent : Frame
    {
        #region Constructors

        public ExpanderContent(View parent, View layoutParent = null, string id = null, Template template = null, bool deferInitialization = false) :
            base(parent, layoutParent, id, template ?? ExpanderContentTemplates.Default, deferInitialization)
        {
            if (deferInitialization)
                return;

            this.AfterInitializeInternal();
        }

        public ExpanderContent() : this(null)
        {
        }

        static ExpanderContent()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(ExpanderContentTemplates.Default, dependencyProperties);

            dependencyProperties.Add(ContentTemplateDataProperty);
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

        #endregion
    }

    #region Data Templates

    public static class ExpanderContentTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return ExpanderContent;
            }
        }

        private static Template _expanderContent;
        public static Template ExpanderContent
        {
            get
            {
#if UNITY_EDITOR
                if (_expanderContent == null || _expanderContent.CurrentVersion != Template.Version)
#else
                if (_expanderContent == null)
#endif
                {
                    _expanderContent = new Template(FrameTemplates.Frame);
#if UNITY_EDITOR
                    _expanderContent.Name = "ExpanderContent";
                    _expanderContent.LineNumber = 0;
                    _expanderContent.LinePosition = 0;
#endif
                }
                return _expanderContent;
            }
        }

        #endregion
    }

    #endregion
}
