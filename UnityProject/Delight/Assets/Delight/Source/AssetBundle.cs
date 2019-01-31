#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;
#endregion

namespace Delight
{
    public class AssetBundle : BindableObject
    {
        public static string SimulatedUri = string.Format("file://{0}/../AssetBundles/", Application.dataPath);

        public uint Version { get; set; }
        public StorageMode StorageMode { get; set; }
        public bool IsAlive { get; set; }
        public CacheMode CacheMode { get; set; }
        public DateTime LastReferenced { get; set; }
        public UnityEngine.AssetBundle AssetBundleObject { get; set; }

        private readonly SemaphoreLocker _locker = new SemaphoreLocker();

        public async Task<UnityEngine.AssetBundle> GetAsync()
        {
            await _locker.LockAsync(async () =>
            {
                if (AssetBundleObject != null)
                {
                    return;
                }

                // get bundle URI 
                string bundleBaseUri = SimulatedUri;
                if (!Application.isEditor)
                {
                    bundleBaseUri = StorageMode == StorageMode.Remote ?
                        Assets.ServerUriLocator.GetServerUri(Id) : Application.streamingAssetsPath;
                }

                if (!bundleBaseUri.EndsWith("/"))
                {
                    bundleBaseUri += "/";
                }

                var bundleUri = String.Format("{0}{1}/{2}", bundleBaseUri, AssetBundleData.GetPlatformName(), Id.ToLower());

                // get asset bundle
                var getBundleRequest = UnityWebRequestAssetBundle.GetAssetBundle(bundleUri, Version, 0);
                var response = (await getBundleRequest.SendWebRequest()) as UnityWebRequestAsyncOperation;
                if (response.webRequest.isNetworkError || response.webRequest.isHttpError)
                {
                    Debug.Log(String.Format("[Delight] Failed to load asset bundle \"{0}\" from URI \"{1}\".", Id, bundleUri));
                    return;
                }

                // simulate slow load
                await Task.Delay(5000);

                AssetBundleObject = DownloadHandlerAssetBundle.GetContent(response.webRequest);               
            });

            return AssetBundleObject;
        }
    }

    public partial class AssetBundleData : DataProvider<AssetBundle>
    {
        public static int Version = 0;

        public readonly AssetBundle Bundle1;
        public readonly AssetBundle Bundle2;

        public AssetBundleData()
        {
            Bundle1 = new AssetBundle { Id = "Bundle1", StorageMode = StorageMode.Remote };
            Bundle2 = new AssetBundle { Id = "Bundle2", StorageMode = StorageMode.Remote };

            Add(Bundle1);
            Add(Bundle2);
        }

        public static string GetPlatformName()
        {
#if UNITY_EDITOR
            return GetPlatformForAssetBundles(EditorUserBuildSettings.activeBuildTarget);
#else
			return GetPlatformForAssetBundles(Application.platform);
#endif
        }

        protected static string GetPlatformForAssetBundles(BuildTarget target)
        {
            switch (target)
            {
                case BuildTarget.Android:
                    return "Android";
                case BuildTarget.iOS:
                    return "iOS";
                case BuildTarget.tvOS:
                    return "tvOS";
                case BuildTarget.WebGL:
                    return "WebGL";
                case BuildTarget.StandaloneWindows:
                case BuildTarget.StandaloneWindows64:
                    return "StandaloneWindows";
#if UNITY_2017_4_OR_NEWER
                case BuildTarget.StandaloneOSX:
                    return "StandaloneOSX";
#else
                case BuildTarget.StandaloneOSXIntel:
                case BuildTarget.StandaloneOSXIntel64:
                    return "StandaloneOSXIntel";
#endif
                // Add more build targets for your own.
                // If you add more targets, don't forget to add the same platforms to the function below.
                case BuildTarget.StandaloneLinux:
                case BuildTarget.StandaloneLinux64:
                case BuildTarget.StandaloneLinuxUniversal:
                    return "StandaloneLinux";
#if UNITY_SWITCH
                case BuildTarget.Switch:
                    return "Switch";
#endif
                default:
                    return target.ToString();
            }
        }

        protected static string GetPlatformForAssetBundles(RuntimePlatform platform)
        {
            switch (platform)
            {
                case RuntimePlatform.Android:
                    return "Android";
                case RuntimePlatform.IPhonePlayer:
                    return "iOS";
                case RuntimePlatform.tvOS:
                    return "tvOS";
                case RuntimePlatform.WebGLPlayer:
                    return "WebGL";
                case RuntimePlatform.WindowsPlayer:
                    return "StandaloneWindows";
#if UNITY_2017_4_OR_NEWER
                case RuntimePlatform.OSXPlayer:
                    return "StandaloneOSX";
#else
                case RuntimePlatform.OSXPlayer:
                    return "StandaloneOSXIntel";
#endif
                case RuntimePlatform.LinuxPlayer:
                    return "StandaloneLinux";
#if UNITY_SWITCH
                case RuntimePlatform.Switch:
                    return "Switch";
#endif
                default:
                    return platform.ToString();
            }
        }
    }

    public static partial class Assets
    {
        public static AssetBundleData AssetBundles = new AssetBundleData();
    }

    public enum CacheMode
    {
        PerSession = 0,
        Timeout = 1,
        Never = 2,
        Forever = 4
    }
}
