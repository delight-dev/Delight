#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
#endregion

namespace Delight
{
    /// <summary>
    /// Defines a navigation button that is used by List views to navigate between pages.
    /// </summary>
    public partial class NavigationButton
    {
        #region Properties

        /// <summary>
        /// Parent list the navigation button resides in.
        /// </summary>
        public List ParentList { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Called when the navigation button is clicked.
        /// </summary>
        public void NavigationButtonClick()
        {
            if (ParentList == null)
                return;

            switch (NavigationType)
            {
                case NavigationButtonType.NextAndPrevious:
                    break;
                case NavigationButtonType.Next:
                    ParentList.NextPage();
                    break;
                case NavigationButtonType.Previous:
                    ParentList.PreviousPage();
                    break;
                case NavigationButtonType.Page:
                    ParentList.JumpToPage(PageIndex);
                    break;
            }
        }

        #endregion
    }
}