// Internal view logic generated from "LevelSelect.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class LevelSelect : UIView
    {
        #region Constructors

        public LevelSelect(View parent, View layoutParent = null, string id = null, Template template = null, bool deferInitialization = false) :
            base(parent, layoutParent, id, template ?? LevelSelectTemplates.Default, deferInitialization)
        {
            if (deferInitialization)
                return;

            this.AfterInitializeInternal();
        }

        public LevelSelect() : this(null)
        {
        }

        static LevelSelect()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(LevelSelectTemplates.Default, dependencyProperties);
        }

        #endregion

        #region Properties

        #endregion
    }

    #region Data Templates

    public static class LevelSelectTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return LevelSelect;
            }
        }

        private static Template _levelSelect;
        public static Template LevelSelect
        {
            get
            {
#if UNITY_EDITOR
                if (_levelSelect == null || _levelSelect.CurrentVersion != Template.Version)
#else
                if (_levelSelect == null)
#endif
                {
                    _levelSelect = new Template(UIViewTemplates.UIView);
#if UNITY_EDITOR
                    _levelSelect.Name = "LevelSelect";
#endif
                }
                return _levelSelect;
            }
        }

        #endregion
    }

    #endregion
}
