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
    public partial class TestExample
    {
        public void OnItemSelected(ItemSelectionActionData itemData)
        {
            Debug.Log("Item selected");
        }

        private bool _toggle = true;
        public void Test()
        {
            //foreach (var demoLevel in Models.DemoLevels.ToList())
            //{
            //    if (_toggle)
            //    {
            //        if (demoLevel.Score == 3)
            //            demoLevel.Score = -1;
            //    }
            //    else
            //    {
            //        if (demoLevel.Score == -1)
            //            demoLevel.Score = 3;
            //    }
            //}

            //_toggle = !_toggle;

            Models.FilteredDemoLevels.ItemsModified();
        }

        public string Test2(int number)
        {
            return String.Format("Number: {0}", number);
        }
    }

    public static partial class Models
    {
        public static BindableCollection<DemoLevel> FilteredDemoLevels = new BindableCollectionSubset<DemoLevel>(DemoLevels, x => x.Score == 3, nameof(DemoLevel.Score));
    }
}