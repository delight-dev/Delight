// Internal view logic generated from "ToggleGroup.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class ToggleGroup : Group
    {
        #region Constructors

        public ToggleGroup(View parent, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :
            base(parent, layoutParent, id, template ?? ToggleGroupTemplates.Default, initializer)
        {
            this.AfterInitializeInternal();
        }

        public ToggleGroup() : this(null)
        {
        }

        static ToggleGroup()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(ToggleGroupTemplates.Default, dependencyProperties);
        }

        #endregion

        #region Properties

        #endregion
    }

    #region Data Templates

    public static class ToggleGroupTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return ToggleGroup;
            }
        }

        private static Template _toggleGroup;
        public static Template ToggleGroup
        {
            get
            {
#if UNITY_EDITOR
                if (_toggleGroup == null || _toggleGroup.CurrentVersion != Template.Version)
#else
                if (_toggleGroup == null)
#endif
                {
                    _toggleGroup = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _toggleGroup.Name = "ToggleGroup";
#endif
                }
                return _toggleGroup;
            }
        }

        #endregion
    }

    #endregion
}
