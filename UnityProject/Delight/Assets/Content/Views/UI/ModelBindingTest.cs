#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class ModelBindingTest
    {
        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void BeforeLoad()
        {
            base.BeforeLoad();
        }

        int i = 0;
        public void Test1()
        {
            Models.Players.Player1.Name = "Julia " + i++;
            Debug.Log("Models.Players.Player1.Name = " + Models.Players.Player1.Name);
        }

        public void Test2()
        {
            Label1.Text = "Sanna";
            Debug.Log("Models.Players.Player1.Name = " + Models.Players.Player1.Name);
        }
    }
}
