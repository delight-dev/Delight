#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class Highscore : ModelObject
    {
        public string ScoreText
        {
            get { return _score.ToString(); }
        }
    }
}
