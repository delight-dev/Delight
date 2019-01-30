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
    /// TestScene view.
    /// </summary>
    public partial class TestScene
    {
        #region Fields
        #endregion

        #region Methods

        public void Test1()
        {
            //Debug.Log("Setting Models.Players.Player1.ChildPlayer.ChildPlayer.Name = \"Test 1\";");
            //Models.Players.Player1.ChildPlayer.ChildPlayer.Name = "Test 1";

            Debug.Log("Setting Models.Players[0] = new Player(Patrik 1)");
            //Models.Players["Player1"].ChildPlayer = new Player
            //{
            //    Name = "Patrik 1",
            //    ChildPlayer = new Player
            //    {
            //        Name = "Patrik 1.1",
            //        ChildPlayer = new Player
            //        {
            //            Name = "Patrik 1.1.1"
            //        }
            //    }
            //};
        }

        public void Test2()
        {
            Debug.Log("Setting BindingTest1.Player1 = new Player {...}");
            //BindingTest1.Player1.ChildPlayer = new Player
            //{
            //    Name = "Test 2",
            //    ChildPlayer = new Player
            //    {
            //        Name = "Test 2.1",
            //        ChildPlayer = new Player
            //        {
            //            Name = "Test 2.1.1"
            //        }
            //    }
            //};
        }

        public void Test3()
        {
            Debug.Log("Setting Models.Players.Player1.ChildPlayer = new Player {...}");

            //Models.Players.Player1.ChildPlayer = new Player
            //{
            //    Name = "Test 3.1",
            //    ChildPlayer = new Player
            //    {
            //        Name = "Test 3.1.1"
            //    }
            //};
        }

        public void LogBinding()
        {
            //Debug.Log("Models.Players.Player1.Name = " + Models.Players.Player1.Name);
            //Debug.Log("Models.Players.Player1.ChildPlayer.Name = " + Models.Players.Player1.ChildPlayer.Name);
            //Debug.Log("Models.Players.Player1.ChildPlayer.ChildPlayer.Name = " + Models.Players.Player1.ChildPlayer.ChildPlayer.Name);
        }

        #endregion
    }
}
