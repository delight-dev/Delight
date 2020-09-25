#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class DemoLevel : ModelObject
    {   
        public SpriteAsset Stars
        {
            get
            {
                return Assets.Sprites["Stars" + Score];
            }
        }
    }
}
