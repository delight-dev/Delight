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

            // set up binding to model
            _bindings.Add(new Binding("Name", "Text", () => Models.Players.Player1, () => Label1, () => Label1.Text = Models.Players.Player1.Name, () => Models.Players.Player1.Name = Label1.Text));
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
