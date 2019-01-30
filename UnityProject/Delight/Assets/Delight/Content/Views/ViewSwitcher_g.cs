// Internal view logic generated from "ViewSwitcher.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class ViewSwitcher : SceneObjectView
    {
        #region Constructors

        public ViewSwitcher(View parent, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :
            base(parent, layoutParent, id, template ?? ViewSwitcherTemplates.Default, initializer)
        {
            this.AfterInitializeInternal();
        }

        public ViewSwitcher() : this(null)
        {
        }

        static ViewSwitcher()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(ViewSwitcherTemplates.Default, dependencyProperties);
        }

        #endregion

        #region Properties

        #endregion
    }

    #region Data Templates

    public static class ViewSwitcherTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return ViewSwitcher;
            }
        }

        private static Template _viewSwitcher;
        public static Template ViewSwitcher
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcher == null || _viewSwitcher.CurrentVersion != Template.Version)
#else
                if (_viewSwitcher == null)
#endif
                {
                    _viewSwitcher = new Template(SceneObjectViewTemplates.SceneObjectView);
                }
                return _viewSwitcher;
            }
        }

        #endregion
    }

    #endregion
}
