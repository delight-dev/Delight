#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    /// <summary>
    /// Main access point for all the assets used by the framework. 
    /// </summary>
    public static partial class Assets
    {
        #region Fields

        public static string DefaultAssetBundlesServerUri = AssetBundle.SimulatedUri;
        public static ServerUriLocator AssetBundlesServerUriLocator = new ServerUriLocator();

        #endregion
    }
}
