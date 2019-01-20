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

        protected override void Initialize()
        {
            base.Initialize();

            Player1 = new Player
            {
                Name = "Player 1",
                ChildPlayer = new Player
                {
                    Name = "Player 1.1",
                    ChildPlayer = new Player
                    {
                        Name = "Player 1.1.1"
                    }
                }
            };
        }

        public void Test1()
        {
            Debug.Log("Setting Player1.ChildPlayer.ChildPlayer.Name = \"Test 1\";");
            Player1.ChildPlayer.ChildPlayer.Name = "Test 1";
        }

        public void Test2()
        {
            Debug.Log("Setting BindingTest1.Player1 = new Player {...}");
            BindingTest1.Player1 = new Player
            {
                Name = "Player 3",
                ChildPlayer = new Player
                {
                    Name = "Player 3.1",
                    ChildPlayer = new Player
                    {
                        Name = "Player 3.1.1"
                    }
                }
            };
        }

        public void Test3()
        {
            Debug.Log("Setting Player1.ChildPlayer = new Player {...}");

            Player1.ChildPlayer = new Player
            {
                Name = "Player 4.1",
                ChildPlayer = new Player
                {
                    Name = "Player 4.1.1"
                }
            };
        }

        public void LogBinding()
        {
            Debug.Log("TestPlayer1.Name = " + Player1.Name);
            Debug.Log("TestPlayer1.ChildPlayer.Name = " + Player1.ChildPlayer.Name);
            Debug.Log("TestPlayer1.ChildPlayer.ChildPlayer.Name = " + Player1.ChildPlayer.ChildPlayer.Name);
        }

        #endregion
    }
}
