#region Using Statements
using UnityEngine;
#endregion

namespace Delight
{
    /// <summary>
    /// Defeault server uri locator. Uses URI specified in config or simulated URI if UseSimulatedUriInEditor is true.
    /// </summary>
    public class ServerUriLocator
    {
        public virtual string GetServerUri(string bundleName)
        {
            if (Config.UseSimulatedUriInEditor)
                return AssetBundle.SimulatedUri;

            return Config.ServerUri;
        }
    }
}