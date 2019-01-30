// Internal view logic generated from "Region.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class Region : UIImageView
    {
        #region Constructors

        public Region(View parent, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :
            base(parent, layoutParent, id, template ?? RegionTemplates.Default, initializer)
        {
            this.AfterInitializeInternal();
        }

        public Region() : this(null)
        {
        }

        static Region()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(RegionTemplates.Default, dependencyProperties);
        }

        #endregion

        #region Properties

        #endregion
    }

    #region Data Templates

    public static class RegionTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return Region;
            }
        }

        private static Template _region;
        public static Template Region
        {
            get
            {
#if UNITY_EDITOR
                if (_region == null || _region.CurrentVersion != Template.Version)
#else
                if (_region == null)
#endif
                {
                    _region = new Template(UIImageViewTemplates.UIImageView);
                }
                return _region;
            }
        }

        #endregion
    }

    #endregion
}
