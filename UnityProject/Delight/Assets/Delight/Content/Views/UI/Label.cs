#if !DELIGHT_MODULE_TEXTMESHPRO

#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class Label
    {
        #region Properties

        public float PreferredWidth
        {
            get { return 0; }
        }

        public float PreferredHeight
        {
            get { return 0; }
        }

        #endregion
    }
}

#endif