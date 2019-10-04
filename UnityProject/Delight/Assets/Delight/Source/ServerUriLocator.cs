#region Using Statements
using System;
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
            if (Config.UseSimulatedUriInEditor && Application.isEditor)
                return AssetBundle.SimulatedUri;

            return Config.ServerUri;
        }

        public virtual string GetBundleUri(string bundleName, StorageMode storageMode)
        {
            var bundleBaseUri = storageMode == StorageMode.Remote ?
                Config.ServerUriLocator.GetServerUri(bundleName) : Application.streamingAssetsPath;
            if (!bundleBaseUri.EndsWith("/"))
            {
                bundleBaseUri += "/";
            }

            var bundleUri = String.Format("{0}{1}{2}{3}", bundleBaseUri, AssetBundleData.GetPlatformName() + "/", AssetBundle.DelightAssetsFolder, bundleName.ToLower());
            return bundleUri;
        }
    }
}
