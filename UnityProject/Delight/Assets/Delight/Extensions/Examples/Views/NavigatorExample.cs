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
    public partial class NavigatorExample
    {
        protected override void AfterLoad()
        {
            base.AfterLoad();
        }

        public void OpenRoot()
        {
            Navigator1.Push("/");
        }

        public void OpenTest()
        {
            Navigator1.Push("/test");
        }

        public void Pop()
        {
            Navigator1.Pop();
        }
    }
}
