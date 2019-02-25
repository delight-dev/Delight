// Internal view logic generated from "List.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class List : Collection
    {
        #region Constructors

        public List(View parent, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :
            base(parent, layoutParent, id, template ?? ListTemplates.Default, initializer)
        {
            // constructing ScrollableRegion (ScrollableRegion)
            ScrollableRegion = new ScrollableRegion(this, this, "ScrollableRegion", ScrollableRegionTemplate);
            Content = ScrollableRegion;
            this.AfterInitializeInternal();
        }

        public List() : this(null)
        {
        }

        static List()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(ListTemplates.Default, dependencyProperties);

            dependencyProperties.Add(OrientationProperty);
            dependencyProperties.Add(SpacingProperty);
            dependencyProperties.Add(ContentAlignmentProperty);
            dependencyProperties.Add(AlternateItemsProperty);
            dependencyProperties.Add(IsScrollableProperty);
            dependencyProperties.Add(IsVirtualizedProperty);
            dependencyProperties.Add(CanSelectProperty);
            dependencyProperties.Add(CanDeselectProperty);
            dependencyProperties.Add(CanMultiSelectProperty);
            dependencyProperties.Add(CanReselectProperty);
            dependencyProperties.Add(DeselectAfterSelectProperty);
            dependencyProperties.Add(SelectOnMouseUpProperty);
            dependencyProperties.Add(ScrollableRegionProperty);
            dependencyProperties.Add(ScrollableRegionTemplateProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<Delight.ElementOrientation> OrientationProperty = new DependencyProperty<Delight.ElementOrientation>("Orientation");
        public Delight.ElementOrientation Orientation
        {
            get { return OrientationProperty.GetValue(this); }
            set { OrientationProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Delight.ElementSize> SpacingProperty = new DependencyProperty<Delight.ElementSize>("Spacing");
        public Delight.ElementSize Spacing
        {
            get { return SpacingProperty.GetValue(this); }
            set { SpacingProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Delight.ElementAlignment> ContentAlignmentProperty = new DependencyProperty<Delight.ElementAlignment>("ContentAlignment");
        public Delight.ElementAlignment ContentAlignment
        {
            get { return ContentAlignmentProperty.GetValue(this); }
            set { ContentAlignmentProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> AlternateItemsProperty = new DependencyProperty<System.Boolean>("AlternateItems");
        public System.Boolean AlternateItems
        {
            get { return AlternateItemsProperty.GetValue(this); }
            set { AlternateItemsProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> IsScrollableProperty = new DependencyProperty<System.Boolean>("IsScrollable");
        public System.Boolean IsScrollable
        {
            get { return IsScrollableProperty.GetValue(this); }
            set { IsScrollableProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> IsVirtualizedProperty = new DependencyProperty<System.Boolean>("IsVirtualized");
        public System.Boolean IsVirtualized
        {
            get { return IsVirtualizedProperty.GetValue(this); }
            set { IsVirtualizedProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> CanSelectProperty = new DependencyProperty<System.Boolean>("CanSelect");
        public System.Boolean CanSelect
        {
            get { return CanSelectProperty.GetValue(this); }
            set { CanSelectProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> CanDeselectProperty = new DependencyProperty<System.Boolean>("CanDeselect");
        public System.Boolean CanDeselect
        {
            get { return CanDeselectProperty.GetValue(this); }
            set { CanDeselectProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> CanMultiSelectProperty = new DependencyProperty<System.Boolean>("CanMultiSelect");
        public System.Boolean CanMultiSelect
        {
            get { return CanMultiSelectProperty.GetValue(this); }
            set { CanMultiSelectProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> CanReselectProperty = new DependencyProperty<System.Boolean>("CanReselect");
        public System.Boolean CanReselect
        {
            get { return CanReselectProperty.GetValue(this); }
            set { CanReselectProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> DeselectAfterSelectProperty = new DependencyProperty<System.Boolean>("DeselectAfterSelect");
        public System.Boolean DeselectAfterSelect
        {
            get { return DeselectAfterSelectProperty.GetValue(this); }
            set { DeselectAfterSelectProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> SelectOnMouseUpProperty = new DependencyProperty<System.Boolean>("SelectOnMouseUp");
        public System.Boolean SelectOnMouseUp
        {
            get { return SelectOnMouseUpProperty.GetValue(this); }
            set { SelectOnMouseUpProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ScrollableRegion> ScrollableRegionProperty = new DependencyProperty<ScrollableRegion>("ScrollableRegion");
        public ScrollableRegion ScrollableRegion
        {
            get { return ScrollableRegionProperty.GetValue(this); }
            set { ScrollableRegionProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> ScrollableRegionTemplateProperty = new DependencyProperty<Template>("ScrollableRegionTemplate");
        public Template ScrollableRegionTemplate
        {
            get { return ScrollableRegionTemplateProperty.GetValue(this); }
            set { ScrollableRegionTemplateProperty.SetValue(this, value); }
        }

        #endregion
    }

    #region Data Templates

    public static class ListTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return List;
            }
        }

        private static Template _list;
        public static Template List
        {
            get
            {
#if UNITY_EDITOR
                if (_list == null || _list.CurrentVersion != Template.Version)
#else
                if (_list == null)
#endif
                {
                    _list = new Template(CollectionTemplates.Collection);
#if UNITY_EDITOR
                    _list.Name = "List";
#endif
                    Delight.List.ScrollableRegionTemplateProperty.SetDefault(_list, ListScrollableRegion);
                }
                return _list;
            }
        }

        private static Template _listScrollableRegion;
        public static Template ListScrollableRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_listScrollableRegion == null || _listScrollableRegion.CurrentVersion != Template.Version)
#else
                if (_listScrollableRegion == null)
#endif
                {
                    _listScrollableRegion = new Template(ScrollableRegionTemplates.ScrollableRegion);
#if UNITY_EDITOR
                    _listScrollableRegion.Name = "ListScrollableRegion";
#endif
                    Delight.ScrollableRegion.BubbleNotifyChildLayoutChangedProperty.SetDefault(_listScrollableRegion, true);
                }
                return _listScrollableRegion;
            }
        }

        #endregion
    }

    #endregion
}
