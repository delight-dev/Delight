// Internal view logic generated from "Group.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class Group : UIImageView
    {
        #region Constructors

        public Group(View parent, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :
            base(parent, layoutParent, id, template ?? GroupTemplates.Default, initializer)
        {
        }

        public Group() : this(null)
        {
        }

        static Group()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(GroupTemplates.Default, dependencyProperties);

            dependencyProperties.Add(SpacingProperty);
            dependencyProperties.Add(OrientationProperty);
            dependencyProperties.Add(ContentAlignmentProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<Delight.ElementSize> SpacingProperty = new DependencyProperty<Delight.ElementSize>();
        public Delight.ElementSize Spacing
        {
            get { return SpacingProperty.GetValue(this); }
            set { SpacingProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Delight.ElementOrientation> OrientationProperty = new DependencyProperty<Delight.ElementOrientation>();
        public Delight.ElementOrientation Orientation
        {
            get { return OrientationProperty.GetValue(this); }
            set { OrientationProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Delight.ElementAlignment> ContentAlignmentProperty = new DependencyProperty<Delight.ElementAlignment>();
        public Delight.ElementAlignment ContentAlignment
        {
            get { return ContentAlignmentProperty.GetValue(this); }
            set { ContentAlignmentProperty.SetValue(this, value); }
        }

        #endregion
    }

    #region Data Templates

    public static class GroupTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return Group;
            }
        }

        private static Template _group;
        public static Template Group
        {
            get
            {
#if UNITY_EDITOR
                if (_group == null || _group.CurrentVersion != Template.Version)
#else
                if (_group == null)
#endif
                {
                    _group = new Template(UIImageViewTemplates.UIImageView);
                }
                return _group;
            }
        }

        #endregion
    }

    #endregion
}
