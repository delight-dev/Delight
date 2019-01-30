#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class BigSlowView
    {
        #region Methods

        protected override void BeforeLoad()
        {
            base.BeforeLoad();
            TestMethod();
        }

        public async void TestMethod()
        {
            Debug.Log("BigSlowView loading...");
            await Task.Delay(5000); // simulate a slow loading view
            BackgroundColor = new Color(1, 0, 0);
            Debug.Log("BigSlowView loading complete.");
        }

        #endregion
    }
}
