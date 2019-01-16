#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.EventSystems;
#endregion

namespace Delight
{
    /// <summary>
    /// PerformanceTest view.
    /// </summary>
    public partial class PerformanceTest : UIView
    {
        #region Fields

        #endregion

        #region Methods

        protected override void BeforeLoad()
        {
            base.BeforeLoad();

            //// add generic list
            //var listItems = new List<string, UIView>(this);

            //int maxCount = 10000;

            //// add some items to list
            //var items = new ObservableList<string>();
            //for (int i = 0; i < maxCount; ++i)
            //{
            //    items.Add("Item " + i );
            //}

            //listItems.Items = new ObservableList<string>(items);
        }

        #endregion
    }
}
