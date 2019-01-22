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
                }
                return _list;
            }
        }

        #endregion
    }

    #endregion
}
