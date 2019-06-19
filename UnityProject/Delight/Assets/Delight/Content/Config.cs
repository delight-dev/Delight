#region Using Statements
using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    /// <summary>
    /// Main access point for the configuration used by the framework.
    /// </summary>
    public static partial class Config
    {
        #region Fields

        public static bool UseSimulatedUriInEditor = true;
        public static string ServerUri = AssetBundle.SimulatedUri;
        public static ServerUriLocator ServerUriLocator = new ServerUriLocator();
        public static uint AssetBundleVersion = 0;

        #endregion
    }
}
