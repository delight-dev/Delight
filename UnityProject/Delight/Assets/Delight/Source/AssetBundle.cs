#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.Networking;
#endregion

namespace Delight
{
    /// <summary>
    /// Base class for asset bundles. Loads/unloads the bundle on-demand as it's requested by views.
    /// </summary>
    public class AssetBundle : BindableObject
    {
        #region Fields

        public static string SimulatedUri = string.Format("file://{0}/../AssetBundles/", Application.dataPath);
        public const string DelightAssetsFolder = "Delight/";

        public uint Version { get; set; }
        public StorageMode StorageMode { get; set; }
        public LoadMode LoadMode { get; set; }
        public UnityEngine.AssetBundle UnityAssetBundle { get; set; }

        private readonly SemaphoreLocker _locker;
        public Dictionary<int, WeakReference> _referenceObjects;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the class. 
        /// </summary>
        public AssetBundle()
        {
            _locker = new SemaphoreLocker();
            _referenceObjects = new Dictionary<int, WeakReference>();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Registers load object. 
        /// </summary>
        public void RegisterReference(object referenceObject)
        {
            if (LoadMode != LoadMode.Automatic)
                return;

            _referenceObjects[referenceObject.GetHashCode()] = new WeakReference(referenceObject);
        }

        /// <summary>
        /// Registers load object. 
        /// </summary>
        public void UnregisterReference(object referenceObject)
        {
            if (LoadMode != LoadMode.Automatic)
                return;

            _referenceObjects.Remove(referenceObject.GetHashCode());
            List<int> deadReferences = null;
            foreach (var refObjects in _referenceObjects)
            {
                if (refObjects.Value.IsAlive)
                    continue;

                if (deadReferences == null)
                    deadReferences = new List<int>();
                deadReferences.Add(refObjects.Value.Target.GetHashCode());
            }

            if (deadReferences != null)
            {
                foreach (var deadReference in deadReferences)
                {
                    _referenceObjects.Remove(deadReference);
                }
            }

            if (_referenceObjects.Count <= 0 && UnityAssetBundle != null)
            {
                // unload bundle
                UnityAssetBundle.Unload(true);
                UnityAssetBundle = null;

                Debug.Log("#Delight# Unloading asset bundle: " + Id);
            }
        }

        /// <summary>
        /// Loads the asset bundle asynchronously, returns the loaded object.
        /// </summary>
        public async Task<UnityEngine.AssetBundle> LoadAsync()
        {
            await _locker.LockAsync(async () =>
            {
                if (UnityAssetBundle != null)
                {
                    return;
                }

                Debug.Log("#Delight# Loading asset bundle: " + Id);

                // get bundle URI 
                var bundleBaseUri = StorageMode == StorageMode.Remote ?
                    Config.ServerUriLocator.GetServerUri(Id) : Application.streamingAssetsPath;
                if (!bundleBaseUri.EndsWith("/"))
                {
                    bundleBaseUri += "/";
                }

                var bundleUri = string.Empty;
                if (StorageMode == StorageMode.Remote)
                {
                    bundleUri = String.Format("{0}{1}{2}{3}", bundleBaseUri, AssetBundleData.GetPlatformName() + "/", DelightAssetsFolder, Id.ToLower());
                }
                else
                {
                    bundleUri = String.Format("{0}{1}{2}", bundleBaseUri, DelightAssetsFolder, Id.ToLower());
                }

                // get asset bundle
                var version = Version > 0 ? Version : Config.AssetBundleVersion;
                var getBundleRequest = version > 0 ? UnityWebRequestAssetBundle.GetAssetBundle(bundleUri, version, 0) : 
                    UnityWebRequestAssetBundle.GetAssetBundle(bundleUri);
                var response = (await getBundleRequest.SendWebRequest()) as UnityWebRequestAsyncOperation;
                if (response.webRequest.isNetworkError || response.webRequest.isHttpError)
                {
                    Debug.Log(String.Format("#Delight# Failed to load asset bundle \"{0}\" from URI \"{1}\".", Id, bundleUri));
                    return;
                }

                // simulate slow load
                // await Task.Delay(1500); // TODO remove

                UnityAssetBundle = DownloadHandlerAssetBundle.GetContent(response.webRequest);
            });

            return UnityAssetBundle;
        }

        #endregion
    }

    /// <summary>
    /// Asset bundle data provider. Contains all the asset bundles used by the framework.
    /// </summary>
    public partial class AssetBundleData : DataProvider<AssetBundle>
    {
        #region Methods

        public static string GetPlatformName()
        {
#if UNITY_EDITOR
            return GetPlatformForAssetBundles(EditorUserBuildSettings.activeBuildTarget);
#else
			return GetPlatformForAssetBundles(Application.platform);
#endif
        }

#if UNITY_EDITOR
        public static string GetPlatformForAssetBundles(BuildTarget target)
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
                    Debug.Log("Unknown BuildTarget: Using Default Enum Name: " + target);
                    return target.ToString();
            }
        }
#endif

        public static string GetPlatformForAssetBundles(RuntimePlatform platform)
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
                // Add more build targets for your own.
                // If you add more targets, don't forget to add the same platforms to the function above.
                default:
                    Debug.Log("Unknown BuildTarget: Using Default Enum Name: " + platform);
                    return platform.ToString();
            }
        }

        #endregion
    }
    
    /// <summary>
    /// Contains references to asset bundle data.
    /// </summary>
    public static partial class Assets
    {
        public static AssetBundleData AssetBundles = new AssetBundleData();
    }
}
