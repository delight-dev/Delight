// Internal view logic generated from "Aa.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class Aa : UIView
    {
        #region Constructors

        public Aa(View parent, View layoutParent = null, string id = null, Template template = null, bool deferInitialization = false) :
            base(parent, layoutParent, id, template ?? AaTemplates.Default, deferInitialization)
        {
            if (deferInitialization)
                return;

            this.AfterInitializeInternal();
        }

        public Aa() : this(null)
        {
        }

        static Aa()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(AaTemplates.Default, dependencyProperties);
        }

        #endregion

        #region Properties

        #endregion
    }

    #region Data Templates

    public static class AaTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return Aa;
            }
        }

        private static Template _aa;
        public static Template Aa
        {
            get
            {
#if UNITY_EDITOR
                if (_aa == null || _aa.CurrentVersion != Template.Version)
#else
                if (_aa == null)
#endif
                {
                    _aa = new Template(UIViewTemplates.UIView);
#if UNITY_EDITOR
                    _aa.Name = "Aa";
#endif
                }
                return _aa;
            }
        }

        #endregion
    }

    #endregion
}
