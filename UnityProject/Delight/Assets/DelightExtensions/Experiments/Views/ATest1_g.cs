// Internal view logic generated from "ATest1.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class ATest1 : UIView
    {
        #region Constructors

        public ATest1(View parent, View layoutParent = null, string id = null, Template template = null, bool deferInitialization = false) :
            base(parent, layoutParent, id, template ?? ATest1Templates.Default, deferInitialization)
        {
            if (deferInitialization)
                return;

            this.AfterInitializeInternal();
        }

        public ATest1() : this(null)
        {
        }

        static ATest1()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(ATest1Templates.Default, dependencyProperties);
        }

        #endregion

        #region Properties

        #endregion
    }

    #region Data Templates

    public static class ATest1Templates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return ATest1;
            }
        }

        private static Template _aTest1;
        public static Template ATest1
        {
            get
            {
#if UNITY_EDITOR
                if (_aTest1 == null || _aTest1.CurrentVersion != Template.Version)
#else
                if (_aTest1 == null)
#endif
                {
                    _aTest1 = new Template(UIViewTemplates.UIView);
#if UNITY_EDITOR
                    _aTest1.Name = "ATest1";
#endif
                }
                return _aTest1;
            }
        }

        #endregion
    }

    #endregion
}
