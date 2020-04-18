// Internal view logic generated from "Options.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class Options : UIView
    {
        #region Constructors

        public Options(View parent, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :
            base(parent, layoutParent, id, template ?? OptionsTemplates.Default, initializer)
        {
            this.AfterInitializeInternal();
        }

        public Options() : this(null)
        {
        }

        static Options()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(OptionsTemplates.Default, dependencyProperties);
        }

        #endregion

        #region Properties

        #endregion
    }

    #region Data Templates

    public static class OptionsTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return Options;
            }
        }

        private static Template _options;
        public static Template Options
        {
            get
            {
#if UNITY_EDITOR
                if (_options == null || _options.CurrentVersion != Template.Version)
#else
                if (_options == null)
#endif
                {
                    _options = new Template(UIViewTemplates.UIView);
#if UNITY_EDITOR
                    _options.Name = "Options";
#endif
                }
                return _options;
            }
        }

        #endregion
    }

    #endregion
}
