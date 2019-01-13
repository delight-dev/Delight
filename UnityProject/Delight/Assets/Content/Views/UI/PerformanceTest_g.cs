// Internal view logic generated from "PerformanceTest.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class PerformanceTest : UIView
    {
        #region Constructors

        public PerformanceTest(View parent, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :
            base(parent, layoutParent, id, template ?? PerformanceTestTemplates.Default, initializer)
        {
        }

        public PerformanceTest() : this(null)
        {
        }

        static PerformanceTest()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(PerformanceTestTemplates.Default, dependencyProperties);
        }

        #endregion

        #region Properties

        #endregion
    }

    #region Data Templates

    public static class PerformanceTestTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return PerformanceTest;
            }
        }

        private static Template _performanceTest;
        public static Template PerformanceTest
        {
            get
            {
#if UNITY_EDITOR
                if (_performanceTest == null || _performanceTest.CurrentVersion != Template.Version)
#else
                if (_performanceTest == null)
#endif
                {
                    _performanceTest = new Template(UIViewTemplates.UIView);
                }
                return _performanceTest;
            }
        }

        #endregion
    }

    #endregion
}
