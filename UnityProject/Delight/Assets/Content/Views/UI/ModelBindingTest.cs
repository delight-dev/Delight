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
        List<BindableObjectBinding> _bindableObjectBindings = new List<BindableObjectBinding>();

        protected override void Initialize()
        {
            base.Initialize();

            // set up binding to model
            //_bindableObjectBindings.Add(new BindableObjectBinding("Name", "Text", () => Models.Players.Player1, () => Label1, () => Label1.Text = Models.Players.Player1.Name, () => Models.Players.Player1.Name = Label1.Text));
        }

        protected override void BeforeLoad()
        {
            base.BeforeLoad();
        }

        public void Test1()
        {
            Models.Players.Player1.Name = "Julia";
        }
    }
}
