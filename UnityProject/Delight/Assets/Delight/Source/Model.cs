#region Using Statements
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
#endregion

namespace Delight
{
    /// <summary>
    /// Base class for models.
    /// </summary>
    public partial class ViewModel : DependencyObject
    {
        #region Fields
        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public ViewModel(string id, Template template) : base(id, template ?? ViewModelTemplates.Default)
        {
        }

        #endregion

        #region Properties
        #endregion
    }

    #region Data Templates

    public static class ViewModelTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return ViewModel;
            }
        }

        private static Template _viewModel;
        public static Template ViewModel
        {
            get
            {
                if (_viewModel == null)
                {
                    _viewModel = new Template(null);
                }
                return _viewModel;
            }
        }

        #endregion
    }

    #endregion
}
