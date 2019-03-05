#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class Achievement : ModelObject
    {
    }

    public partial class AchievementData : DataProvider<Achievement>
    {
        public AchievementData()
        {
            Add(new Achievement { PlayerId = "Player1", Title = "A1-1" });
            Add(new Achievement { PlayerId = "Player1", Title = "A1-2" });
            Add(new Achievement { PlayerId = "Player1", Title = "A1-3" });
            Add(new Achievement { PlayerId = "Player1", Title = "A1-4" });
            Add(new Achievement { PlayerId = "Player2", Title = "A2-1" });
            Add(new Achievement { PlayerId = "Player2", Title = "A2-2" });
            Add(new Achievement { PlayerId = "Player2", Title = "A2-3" });
            Add(new Achievement { PlayerId = "Player3", Title = "A3-1" });
            Add(new Achievement { PlayerId = "Player3", Title = "A3-2" });
            Add(new Achievement { PlayerId = "Player4", Title = "A4-1" });
        }
    }
}
