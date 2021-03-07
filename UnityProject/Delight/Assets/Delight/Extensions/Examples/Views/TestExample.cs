#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
#endregion

namespace Delight
{
    public partial class TestExample
    {
        public override void AfterInitialize()
        {
            base.AfterInitialize();

            if (Models.NonBindableLevels.Count <= 0)
            {
                Models.NonBindableLevels.Add(new NonBindableLevel { Name = "level 1" });
                Models.NonBindableLevels.Add(new NonBindableLevel { Name = "level 2" });
                Models.NonBindableLevels.Add(new NonBindableLevel { Name = "level 3" });
                Models.NonBindableLevels.Add(new NonBindableLevel { Name = "level 4" });
            }
        }

        public void OnItemSelected(ItemSelectionActionData itemData)
        {
            Debug.Log("Item selected");
        }

        //private bool _toggle = true;
        public void Test()
        {
            // test switching scenes
            //SceneManager.LoadScene("MainMenuDemoScene");

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

            //Models.FilteredDemoLevels.ItemsModified();

            
        }

        private int _bindableObjectCount = 0;
        private int _bindableObjectValueCount = 0;
        public void NonBindableTest1()
        {
            _bindableObjectValueCount = 1;
            NonBindableLevel = new NonBindableLevel { Name = String.Format("Object{0}Value1", ++_bindableObjectCount) };
        }

        public void NonBindableTest2()
        {
            if (NonBindableLevel != null)
            {
                NonBindableLevel.Name = String.Format("Object{0}Value{1}", _bindableObjectCount, ++_bindableObjectValueCount); 
            }
            //BindableCollection test = Models.NonBindableLevels.ToBindableCollection(LayoutRoot);
        }

        public string Test2(int number)
        {
            return String.Format("Number: {0}", number);
        }

        public void AddLevel(NonBindableLevel level)
        {
            Models.NonBindableLevels.Add(new NonBindableLevel { Name = "New Level" });
        }

        public void RemoveLevel(NonBindableLevel level)
        {
            Models.NonBindableLevels.Remove(level);
        }
    }

    public static partial class Models
    {
        public static BindableCollection<DemoLevel> FilteredDemoLevels = new BindableCollectionSubset<DemoLevel>(DemoLevels, x => x.Score == 3, nameof(DemoLevel.Score));
    }
}