// Internal view logic generated from "ScrollableRegion.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class ScrollableRegion : UICanvas
    {
        #region Constructors

        public ScrollableRegion(View parent, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :
            base(parent, layoutParent, id, template ?? ScrollableRegionTemplates.Default, initializer)
        {
            // constructing Region (ContentRegion)
            ContentRegion = new Region(this, this, "ContentRegion", ContentRegionTemplate);
            Drag += ResolveActionHandler(this, "OnDrag");
            BeginDrag += ResolveActionHandler(this, "OnBeginDrag");
            InitializePotentialDrag += ResolveActionHandler(this, "OnInitializePotentialDrag");
            EndDrag += ResolveActionHandler(this, "OnEndDrag");
            Scroll += ResolveActionHandler(this, "OnScroll");
            ContentContainer = ContentRegion;
            this.AfterInitializeInternal();
        }

        public ScrollableRegion() : this(null)
        {
        }

        static ScrollableRegion()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(ScrollableRegionTemplates.Default, dependencyProperties);

            dependencyProperties.Add(MaskContentProperty);
            dependencyProperties.Add(MaskProperty);
            dependencyProperties.Add(DecelerationRateProperty);
            dependencyProperties.Add(ElasticityProperty);
            dependencyProperties.Add(CanScrollHorizontallyProperty);
            dependencyProperties.Add(CanScrollVerticallyProperty);
            dependencyProperties.Add(ContentAlignmentProperty);
            dependencyProperties.Add(AutoSizeContentRegionProperty);
            dependencyProperties.Add(ContentRegionProperty);
            dependencyProperties.Add(ContentRegionTemplateProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<System.Boolean> MaskContentProperty = new DependencyProperty<System.Boolean>("MaskContent");
        public System.Boolean MaskContent
        {
            get { return MaskContentProperty.GetValue(this); }
            set { MaskContentProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<UnityEngine.UI.RectMask2D> MaskProperty = new DependencyProperty<UnityEngine.UI.RectMask2D>("Mask");
        public UnityEngine.UI.RectMask2D Mask
        {
            get { return MaskProperty.GetValue(this); }
            set { MaskProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Single> DecelerationRateProperty = new DependencyProperty<System.Single>("DecelerationRate");
        public System.Single DecelerationRate
        {
            get { return DecelerationRateProperty.GetValue(this); }
            set { DecelerationRateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Single> ElasticityProperty = new DependencyProperty<System.Single>("Elasticity");
        public System.Single Elasticity
        {
            get { return ElasticityProperty.GetValue(this); }
            set { ElasticityProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> CanScrollHorizontallyProperty = new DependencyProperty<System.Boolean>("CanScrollHorizontally");
        public System.Boolean CanScrollHorizontally
        {
            get { return CanScrollHorizontallyProperty.GetValue(this); }
            set { CanScrollHorizontallyProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> CanScrollVerticallyProperty = new DependencyProperty<System.Boolean>("CanScrollVertically");
        public System.Boolean CanScrollVertically
        {
            get { return CanScrollVerticallyProperty.GetValue(this); }
            set { CanScrollVerticallyProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Delight.ElementAlignment> ContentAlignmentProperty = new DependencyProperty<Delight.ElementAlignment>("ContentAlignment");
        public Delight.ElementAlignment ContentAlignment
        {
            get { return ContentAlignmentProperty.GetValue(this); }
            set { ContentAlignmentProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> AutoSizeContentRegionProperty = new DependencyProperty<System.Boolean>("AutoSizeContentRegion");
        public System.Boolean AutoSizeContentRegion
        {
            get { return AutoSizeContentRegionProperty.GetValue(this); }
            set { AutoSizeContentRegionProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> ContentRegionProperty = new DependencyProperty<Region>("ContentRegion");
        public Region ContentRegion
        {
            get { return ContentRegionProperty.GetValue(this); }
            set { ContentRegionProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> ContentRegionTemplateProperty = new DependencyProperty<Template>("ContentRegionTemplate");
        public Template ContentRegionTemplate
        {
            get { return ContentRegionTemplateProperty.GetValue(this); }
            set { ContentRegionTemplateProperty.SetValue(this, value); }
        }

        #endregion
    }

    #region Data Templates

    public static class ScrollableRegionTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return ScrollableRegion;
            }
        }

        private static Template _scrollableRegion;
        public static Template ScrollableRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollableRegion == null || _scrollableRegion.CurrentVersion != Template.Version)
#else
                if (_scrollableRegion == null)
#endif
                {
                    _scrollableRegion = new Template(UICanvasTemplates.UICanvas);
#if UNITY_EDITOR
                    _scrollableRegion.Name = "ScrollableRegion";
#endif
                    Delight.ScrollableRegion.MaskContentProperty.SetDefault(_scrollableRegion, true);
                    Delight.ScrollableRegion.DecelerationRateProperty.SetDefault(_scrollableRegion, 0.135f);
                    Delight.ScrollableRegion.CanScrollHorizontallyProperty.SetDefault(_scrollableRegion, true);
                    Delight.ScrollableRegion.CanScrollVerticallyProperty.SetDefault(_scrollableRegion, true);
                    Delight.ScrollableRegion.EnableScriptEventsProperty.SetDefault(_scrollableRegion, true);
                    Delight.ScrollableRegion.AutoSizeContentRegionProperty.SetDefault(_scrollableRegion, true);
                    Delight.ScrollableRegion.ContentRegionTemplateProperty.SetDefault(_scrollableRegion, ScrollableRegionContentRegion);
                }
                return _scrollableRegion;
            }
        }

        private static Template _scrollableRegionContentRegion;
        public static Template ScrollableRegionContentRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollableRegionContentRegion == null || _scrollableRegionContentRegion.CurrentVersion != Template.Version)
#else
                if (_scrollableRegionContentRegion == null)
#endif
                {
                    _scrollableRegionContentRegion = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _scrollableRegionContentRegion.Name = "ScrollableRegionContentRegion";
#endif
                    Delight.Region.BubbleNotifyChildLayoutChangedProperty.SetDefault(_scrollableRegionContentRegion, true);
                }
                return _scrollableRegionContentRegion;
            }
        }

        #endregion
    }

    #endregion
}
