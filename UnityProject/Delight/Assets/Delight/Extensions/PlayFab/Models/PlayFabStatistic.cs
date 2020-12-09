#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    /// <summary>
    /// Represents a player statistic.
    /// </summary>
    public partial class PlayFabStatistic: ModelObject
    {
        #region Properties

        private string _Name;
        /// <summary>
        /// Statistic name
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { SetProperty(ref _Name, value); }
        }

        private int _Value;
        /// <summary>
        /// Statistic value
        /// </summary>
        public int Value
        {
            get { return _Value; }
            set { SetProperty(ref _Value, value); }
        }

        private int _Version;
        /// <summary>
        /// Statistic version (0 if not a versioned statistic)
        /// </summary>
        public int Version
        {
            get { return _Version; }
            set { SetProperty(ref _Version, value); }
        }

        #endregion
    }
}
