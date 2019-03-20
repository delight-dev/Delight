#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class Scrollbar : UIView
    {
        public override void Ignore()
        {
            base.Ignore();
            Bar.Ignore();
            Handle.Ignore();
        }
    }
}
