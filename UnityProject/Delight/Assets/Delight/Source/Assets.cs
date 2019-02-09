#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UniRx.Async;
using UnityEngine;
#endregion

namespace Delight
{
    /// <summary>
    /// Main access point for all the assets used by the framework. 
    /// </summary>
    public static partial class Assets
    {
        public static string AssetBundlesServerUri = AssetBundle.SimulatedUri;
        public static ServerUriLocator AssetBundlesServerUriLocator = new ServerUriLocator();
    }
}
