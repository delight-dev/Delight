#region Using Statements
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnityEngine;
#endregion

namespace Delight
{
    /// <summary>
    /// Represents a selected view in the designer.
    /// </summary>
    [Serializable]
    public class SelectedViewInfo : BindableObject
    {
        #region Fields

        [SerializeField]
        private UIView _view;
        public UIView View
        {
            get { return _view; }
            set { SetProperty(ref _view, value); }
        }

        #endregion
    }
}
