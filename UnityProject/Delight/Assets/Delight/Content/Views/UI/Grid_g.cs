// Internal view logic generated from "Grid.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class Grid : UIImageView
    {
        #region Constructors

        public Grid(View parent, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :
            base(parent, layoutParent, id, template ?? GridTemplates.Default, initializer)
        {
            this.AfterInitializeInternal();
        }

        public Grid() : this(null)
        {
        }

        static Grid()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(GridTemplates.Default, dependencyProperties);
        }

        #endregion

        #region Properties

        #endregion
    }

    #region Data Templates

    public static class GridTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return Grid;
            }
        }

        private static Template _grid;
        public static Template Grid
        {
            get
            {
#if UNITY_EDITOR
                if (_grid == null || _grid.CurrentVersion != Template.Version)
#else
                if (_grid == null)
#endif
                {
                    _grid = new Template(UIImageViewTemplates.UIImageView);
#if UNITY_EDITOR
                    _grid.Name = "Grid";
#endif
                }
                return _grid;
            }
        }

        #endregion
    }

    #endregion
}
