// Internal view logic generated from "DraggableThing.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class DraggableThing : DraggableRegion
    {
        #region Constructors

        public DraggableThing(View parent, View layoutParent = null, string id = null, Template template = null, bool deferInitialization = false) :
            base(parent, layoutParent, id, template ?? DraggableThingTemplates.Default, deferInitialization)
        {
            if (deferInitialization)
                return;

            // constructing Button (test)
            test = new Button(this, this, "test", testTemplate);
            this.AfterInitializeInternal();
        }

        public DraggableThing() : this(null)
        {
        }

        static DraggableThing()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(DraggableThingTemplates.Default, dependencyProperties);

            dependencyProperties.Add(testProperty);
            dependencyProperties.Add(testTemplateProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<Button> testProperty = new DependencyProperty<Button>("test");
        public Button test
        {
            get { return testProperty.GetValue(this); }
            set { testProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> testTemplateProperty = new DependencyProperty<Template>("testTemplate");
        public Template testTemplate
        {
            get { return testTemplateProperty.GetValue(this); }
            set { testTemplateProperty.SetValue(this, value); }
        }

        #endregion
    }

    #region Data Templates

    public static class DraggableThingTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return DraggableThing;
            }
        }

        private static Template _draggableThing;
        public static Template DraggableThing
        {
            get
            {
#if UNITY_EDITOR
                if (_draggableThing == null || _draggableThing.CurrentVersion != Template.Version)
#else
                if (_draggableThing == null)
#endif
                {
                    _draggableThing = new Template(DraggableRegionTemplates.DraggableRegion);
#if UNITY_EDITOR
                    _draggableThing.Name = "DraggableThing";
                    _draggableThing.LineNumber = 0;
                    _draggableThing.LinePosition = 0;
#endif
                    Delight.DraggableThing.testTemplateProperty.SetDefault(_draggableThing, DraggableThingtest);
                }
                return _draggableThing;
            }
        }

        private static Template _draggableThingtest;
        public static Template DraggableThingtest
        {
            get
            {
#if UNITY_EDITOR
                if (_draggableThingtest == null || _draggableThingtest.CurrentVersion != Template.Version)
#else
                if (_draggableThingtest == null)
#endif
                {
                    _draggableThingtest = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _draggableThingtest.Name = "DraggableThingtest";
                    _draggableThingtest.LineNumber = 2;
                    _draggableThingtest.LinePosition = 4;
#endif
                    Delight.Button.OffsetProperty.SetDefault(_draggableThingtest, new ElementMargin(new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(40f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels)));
                    Delight.Button.LabelTemplateProperty.SetDefault(_draggableThingtest, DraggableThingtestLabel);
                }
                return _draggableThingtest;
            }
        }

        private static Template _draggableThingtestLabel;
        public static Template DraggableThingtestLabel
        {
            get
            {
#if UNITY_EDITOR
                if (_draggableThingtestLabel == null || _draggableThingtestLabel.CurrentVersion != Template.Version)
#else
                if (_draggableThingtestLabel == null)
#endif
                {
                    _draggableThingtestLabel = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _draggableThingtestLabel.Name = "DraggableThingtestLabel";
                    _draggableThingtestLabel.LineNumber = 15;
                    _draggableThingtestLabel.LinePosition = 4;
#endif
                    Delight.Label.TextProperty.SetDefault(_draggableThingtestLabel, "Heyy");
                }
                return _draggableThingtestLabel;
            }
        }

        #endregion
    }

    #endregion
}
