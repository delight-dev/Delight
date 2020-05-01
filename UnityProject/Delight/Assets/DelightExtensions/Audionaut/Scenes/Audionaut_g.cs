// Internal view logic generated from "Audionaut.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class Audionaut : UIView
    {
        #region Constructors

        public Audionaut(View parent, View layoutParent = null, string id = null, Template template = null, bool deferInitialization = false) :
            base(parent, layoutParent, id, template ?? AudionautTemplates.Default, deferInitialization)
        {
            if (deferInitialization)
                return;

            this.AfterInitializeInternal();
        }

        public Audionaut() : this(null)
        {
        }

        static Audionaut()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(AudionautTemplates.Default, dependencyProperties);
        }

        #endregion

        #region Properties

        #endregion
    }

    #region Data Templates

    public static class AudionautTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return Audionaut;
            }
        }

        private static Template _audionaut;
        public static Template Audionaut
        {
            get
            {
#if UNITY_EDITOR
                if (_audionaut == null || _audionaut.CurrentVersion != Template.Version)
#else
                if (_audionaut == null)
#endif
                {
                    _audionaut = new Template(UIViewTemplates.UIView);
#if UNITY_EDITOR
                    _audionaut.Name = "Audionaut";
#endif
                }
                return _audionaut;
            }
        }

        #endregion
    }

    #endregion
}
