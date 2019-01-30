using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

#if NET_4_6
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
#endif

namespace Delight
{
    /// <summary>
    ///     Simple AssetBundle management
    /// </summary>
    public class AssetBundleManager : IDisposable
    {
        public enum DownloadSettings
        {
            UseCacheIfAvailable,
            DoNotUseCache
        }

        public enum PrioritizationStrategy
        {
            PrioritizeRemote,
            PrioritizeStreamingAssets,
        }

        public enum PrimaryManifestType
        {
            None,
            Remote,
            RemoteCached,
            StreamingAssets,
        }

        public bool Initialized { get; private set; }
        public AssetBundleManifest Manifest { get; private set; }
        public PrimaryManifestType PrimaryManifest { get; private set; }

        private const string MANIFEST_DOWNLOAD_IN_PROGRESS_KEY = "__manifest__";
        private const string MANIFEST_PLAYERPREFS_KEY = "__abm_manifest_version__";

        private string[] baseUri;
        private bool useHash;
        private PrioritizationStrategy defaultPrioritizationStrategy;
        private ICommandHandler<AssetBundleDownloadCommand> handler;
        private IDictionary<string, AssetBundleContainer> activeBundles = new Dictionary<string, AssetBundleContainer>(StringComparer.OrdinalIgnoreCase);
        private IDictionary<string, DownloadInProgressContainer> downloadsInProgress = new Dictionary<string, DownloadInProgressContainer>(StringComparer.OrdinalIgnoreCase);
        private IDictionary<string, string> unhashedToHashedBundleNameMap = new Dictionary<string, string>(10, StringComparer.OrdinalIgnoreCase);

        /// <summary>
        ///     Sets the base uri used for AssetBundle calls.
        /// </summary>
        public AssetBundleManager SetBaseUri(string uri)
        {
            return SetBaseUri(new[] { uri });
        }

        public AssetBundleManager SetBaseUri(string[] uris)
        {
            if (baseUri == null || baseUri.Length == 0) {
                Debug.LogFormat("Setting base uri to [{0}].", string.Join(",", uris));
            } else {
                Debug.LogWarningFormat("Overriding base uri from [{0}] to [{1}].", string.Join(",", baseUri), string.Join(",", uris));
            }

            baseUri = new string[uris.Length];

            for (int i = 0; i < uris.Length; i++) {
                var builder = new StringBuilder(uris[i]);

                if (!uris[i].EndsWith("/")) {
                    builder.Append("/");
                }

                builder.Append(Utility.GetPlatformName()).Append("/");
                baseUri[i] = builder.ToString();
            }

            return this;
        }

        /// <summary>
        ///     Sets the base uri used for AssetBundle calls to the one created by the AssetBundleBrowser when the bundles are
        ///     built.
        ///     Used for easier testing in the editor
        /// </summary>
        public AssetBundleManager UseSimulatedUri()
        {
            SetBaseUri(new[] { string.Format("file://{0}/../AssetBundles/", Application.dataPath) });
            return this;
        }

        /// <summary>
        ///     Sets the base uri used for AssetBundle calls to the StreamingAssets folder.
        /// </summary>
        public AssetBundleManager UseStreamingAssetsFolder()
        {
            SetBaseUri(new[] { Application.streamingAssetsPath });
            return this;
        }

        /// <summary>
        ///     Changes the strategy used to determine what should happen when an asset bundle exists in both the StreamingAssets
        ///     folder and the remote server.  The default is to prioritize the remote asset over the StreamingAssets folder
        /// </summary>
        public AssetBundleManager SetPrioritizationStrategy(PrioritizationStrategy strategy)
        {
            defaultPrioritizationStrategy = strategy;
            return this;
        }

        /// <summary>
        ///     Tell ABM to append the hash name to bundle names before downloading.
        ///     If you are using AssetBundleBrowser then you need to enable "Append Hash" in the advanced settings for this to
        ///     work.
        /// </summary>
        public AssetBundleManager AppendHashToBundleNames(bool appendHash = true)
        {
            if (appendHash && Initialized) {
                GenerateUnhashToHashMap(Manifest);
            }

            useHash = appendHash;
            return this;
        }

        /// <summary>
        ///     Downloads the AssetBundle manifest and prepares the system for bundle management.
        /// </summary>
        /// <param name="onComplete">Called when initialization is complete.</param>
        public void Initialize(Action<bool> onComplete)
        {
            if (baseUri.Length == 0) {
                Debug.LogError("You need to set the base uri before you can initialize.");
                return;
            }

            GetManifest(Utility.GetPlatformName(), bundle => onComplete(bundle != null));
        }

        /// <summary>
        ///     Downloads the AssetBundle manifest and prepares the system for bundle management.
        /// </summary>
        /// <returns>An IEnumerator that can be yielded to until the system is ready.</returns>
        public AssetBundleManifestAsync InitializeAsync()
        {
            if (baseUri == null || baseUri.Length == 0) {
                Debug.LogError("You need to set the base uri before you can initialize.");
                return null;
            }

            // Wrap the GetManifest with an async operation.
            return new AssetBundleManifestAsync(Utility.GetPlatformName(), GetManifest);
        }

        private void GetManifest(string bundleName, Action<AssetBundle> onComplete)
        {
            DownloadInProgressContainer inProgress;
            if (downloadsInProgress.TryGetValue(MANIFEST_DOWNLOAD_IN_PROGRESS_KEY, out inProgress)) {
                inProgress.References++;
                inProgress.OnComplete += onComplete;
                return;
            }

            downloadsInProgress.Add(MANIFEST_DOWNLOAD_IN_PROGRESS_KEY, new DownloadInProgressContainer(onComplete));
            PrimaryManifest = PrimaryManifestType.Remote;

            // The first attempt for the manifest should always be uncached.  The PlayerPrefs value may have been wiped so we have to calculate what the next uncached manifest version is.
            var manifestVersion = (uint)PlayerPrefs.GetInt(MANIFEST_PLAYERPREFS_KEY, 0) + 1;
            while (Caching.IsVersionCached(bundleName, new Hash128(0, 0, 0, manifestVersion)))
                manifestVersion++;

            GetManifestInternal(bundleName, manifestVersion, 0);
        }

        private void GetManifestInternal(string bundleName, uint version, int uriIndex)
        {
            handler = new AssetBundleDownloader(baseUri[uriIndex]);

            if (Application.isEditor == false) {
                handler = new StreamingAssetsBundleDownloadDecorator(handler, defaultPrioritizationStrategy);
            }

            handler.Handle(new AssetBundleDownloadCommand {
                BundleName = bundleName,
                Version = version,
                OnComplete = manifest => {
                    var maxIndex = baseUri.Length - 1;
                    if (manifest == null && uriIndex < maxIndex && version > 1) {
                        Debug.LogFormat("Unable to download manifest from [{0}], attempting [{1}]", baseUri[uriIndex], baseUri[uriIndex + 1]);
                        GetManifestInternal(bundleName, version, uriIndex + 1);
                    } else if (manifest == null && uriIndex >= maxIndex && version > 1 && PrimaryManifest != PrimaryManifestType.RemoteCached) {
                        PrimaryManifest = PrimaryManifestType.RemoteCached;
                        Debug.LogFormat("Unable to download manifest, attempting to use one previously downloaded (version [{0}]).", version);
                        GetManifestInternal(bundleName, version - 1, uriIndex);
                    } else {
                        OnInitializationComplete(manifest, bundleName, version);
                    }
                }
            });
        }

        private void OnInitializationComplete(AssetBundle manifestBundle, string bundleName, uint version)
        {
            if (manifestBundle == null) {
                Debug.LogError("AssetBundleManifest not found.");

                var streamingAssetsDecorator = handler as StreamingAssetsBundleDownloadDecorator;
                if (streamingAssetsDecorator != null) {
                    PrimaryManifest = PrimaryManifestType.StreamingAssets;
                    Manifest = streamingAssetsDecorator.GetManifest();

                    if (Manifest != null) {
                        Debug.LogWarning("Falling back to streaming assets for bundle information.");
                    }
                }
            } else {
                Manifest = manifestBundle.LoadAsset<AssetBundleManifest>("assetbundlemanifest");
                PlayerPrefs.SetInt(MANIFEST_PLAYERPREFS_KEY, (int)version);

#if UNITY_2017_1_OR_NEWER
                Caching.ClearOtherCachedVersions(bundleName, new Hash128(0, 0, 0, version));
#endif
            }

            if (Manifest == null) {
                PrimaryManifest = PrimaryManifestType.None;
            } else {
                Initialized = true;
                GenerateUnhashToHashMap(Manifest);
            }

            var inProgress = downloadsInProgress[MANIFEST_DOWNLOAD_IN_PROGRESS_KEY];
            downloadsInProgress.Remove(MANIFEST_DOWNLOAD_IN_PROGRESS_KEY);
            inProgress.OnComplete(manifestBundle);

            // Need to do this after OnComplete, otherwise the bundle will always be null
            if (manifestBundle != null) {
                manifestBundle.Unload(false);
            }
        }

        private void GenerateUnhashToHashMap(AssetBundleManifest manifest)
        {
            unhashedToHashedBundleNameMap.Clear();

            var splitChar = new[] { '_' };
            var allBundles = manifest.GetAllAssetBundles();

            for (int i = 0; i < allBundles.Length; i++) {
                var split = allBundles[i].Split(splitChar, 2);
                if (split.Length != 2) continue;
                unhashedToHashedBundleNameMap[split[0]] = allBundles[i];
            }
        }

        /// <summary>
        ///     Downloads an AssetBundle or returns a cached AssetBundle if it has already been downloaded.
        ///     Remember to call <see cref="UnloadBundle(UnityEngine.AssetBundle,bool)" /> for every bundle you download once you
        ///     are done with it.
        /// </summary>
        /// <param name="bundleName">Name of the bundle to download.</param>
        /// <param name="onComplete">Action to perform when the bundle has been successfully downloaded.</param>
        public void GetBundle(string bundleName, Action<AssetBundle> onComplete)
        {
            if (Initialized == false) {
                Debug.LogError("AssetBundleManager must be initialized before you can get a bundle.");
                onComplete(null);
                return;
            }

            GetBundle(bundleName, onComplete, DownloadSettings.UseCacheIfAvailable);
        }

        /// <summary>
        ///     Downloads an AssetBundle or returns a cached AssetBundle if it has already been downloaded.
        ///     Remember to call <see cref="UnloadBundle(UnityEngine.AssetBundle,bool)" /> for every bundle you download once you
        ///     are done with it.
        /// </summary>
        /// <param name="bundleName">Name of the bundle to download.</param>
        /// <param name="onComplete">Action to perform when the bundle has been successfully downloaded.</param>
        /// <param name="downloadSettings">
        ///     Tell the function to use a previously downloaded version of the bundle if available.
        ///     Important!  If the bundle is currently "active" (it has not been unloaded) then the active bundle will be used
        ///     regardless of this setting.  If it's important that a new version is downloaded then be sure it isn't active.
        /// </param>
        public void GetBundle(string bundleName, Action<AssetBundle> onComplete, DownloadSettings downloadSettings)
        {
            if (Initialized == false) {
                Debug.LogError("AssetBundleManager must be initialized before you can get a bundle.");
                onComplete(null);
                return;
            }

            if (useHash) bundleName = GetHashedBundleName(bundleName);

            AssetBundleContainer active;

            if (activeBundles.TryGetValue(bundleName, out active)) {
                active.References++;
                onComplete(active.AssetBundle);
                return;
            }

            DownloadInProgressContainer inProgress;

            if (downloadsInProgress.TryGetValue(bundleName, out inProgress)) {
                inProgress.References++;
                inProgress.OnComplete += onComplete;
                return;
            }

            downloadsInProgress.Add(bundleName, new DownloadInProgressContainer(onComplete));

            var mainBundle = new AssetBundleDownloadCommand {
                BundleName = bundleName,
                Hash = downloadSettings == DownloadSettings.UseCacheIfAvailable ? Manifest.GetAssetBundleHash(bundleName) : default(Hash128),
                OnComplete = bundle => OnDownloadComplete(bundleName, bundle)
            };

            var dependencies = Manifest.GetDirectDependencies(bundleName);
            var dependenciesToDownload = new List<string>();

            for (int i = 0; i < dependencies.Length; i++) {
                if (activeBundles.TryGetValue(dependencies[i], out active)) {
                    active.References++;
                } else {
                    dependenciesToDownload.Add(dependencies[i]);
                }
            }

            if (dependenciesToDownload.Count > 0) {
                var dependencyCount = dependenciesToDownload.Count;
                Action<AssetBundle> onDependenciesComplete = dependency => {
                    if (--dependencyCount == 0)
                        handler.Handle(mainBundle);
                };

                for (int i = 0; i < dependenciesToDownload.Count; i++) {
                    var dependencyName = dependenciesToDownload[i];
                    GetBundle(dependencyName, onDependenciesComplete);
                }
            } else {
                handler.Handle(mainBundle);
            }
        }

#if NET_4_6
        /// <summary>
        ///     Downloads the AssetBundle manifest and prepares the system for bundle management.
        /// </summary>
        public async Task<bool> Initialize()
        {
            var completionSource = new TaskCompletionSource<bool>();
            var onComplete = new Action<bool>(b => completionSource.SetResult(b));
            Initialize(onComplete);
            return await completionSource.Task;
        }

        /// <summary>
        ///     Downloads an AssetBundle or returns a cached AssetBundle if it has already been downloaded.
        ///     Remember to call <see cref="UnloadBundle(UnityEngine.AssetBundle,bool)" /> for every bundle you download once you
        ///     are done with it.
        /// </summary>
        /// <param name="bundleName">Name of the bundle to download.</param>
        public async Task<AssetBundle> GetBundle(string bundleName)
        {
            var completionSource = new TaskCompletionSource<AssetBundle>();
            var onComplete = new Action<AssetBundle>(bundle => completionSource.SetResult(bundle));
            GetBundle(bundleName, onComplete);
            return await completionSource.Task;
        }

        /// <summary>
        ///     Downloads an AssetBundle or returns a cached AssetBundle if it has already been downloaded.
        ///     Remember to call <see cref="UnloadBundle(UnityEngine.AssetBundle,bool)" /> for every bundle you download once you
        ///     are done with it.
        /// </summary>
        /// <param name="bundleName">Name of the bundle to download.</param>
        /// <param name="downloadSettings">
        ///     Tell the function to use a previously downloaded version of the bundle if available.
        ///     Important!  If the bundle is currently "active" (it has not been unloaded) then the active bundle will be used
        ///     regardless of this setting.  If it's important that a new version is downloaded then be sure it isn't active.
        /// </param>
        public async Task<AssetBundle> GetBundle(string bundleName, DownloadSettings downloadSettings)
        {
            var completionSource = new TaskCompletionSource<AssetBundle>();
            var onComplete = new Action<AssetBundle>(bundle => completionSource.SetResult(bundle));
            GetBundle(bundleName, onComplete, downloadSettings);
            return await completionSource.Task;
        }

        /// <summary>
        ///     Downloads a bundle (or uses a cached bundle) and loads a Unity scene contained in an asset bundle asynchronously.
        /// </summary>
        /// <param name="bundleName">Name of the bundle to donwnload.</param>
        /// <param name="levelName">Name of the unity scene to load.</param>
        /// <param name="loadSceneMode">See <see cref="LoadSceneMode">UnityEngine.SceneManagement.LoadSceneMode</see>.</param>
        /// <returns></returns>
        public async Task<AsyncOperation> LoadLevelAsync(string bundleName, string levelName, LoadSceneMode loadSceneMode)
        {
            try {
                await GetBundle(bundleName);
                return SceneManager.LoadSceneAsync(levelName, loadSceneMode);
            } catch {
                Debug.LogError($"Error while loading the scene {levelName} from {bundleName}");
                throw;
            }
        }
#endif

        /// <summary>
        ///     Asynchronously downloads an AssetBundle or returns a cached AssetBundle if it has already been downloaded.
        ///     Remember to call <see cref="UnloadBundle(UnityEngine.AssetBundle,bool)" /> for every bundle you download once you
        ///     are done with it.
        /// </summary>
        /// <param name="bundleName"></param>
        /// <returns></returns>
        public AssetBundleAsync GetBundleAsync(string bundleName)
        {
            if (Initialized == false) {
                Debug.LogError("AssetBundleManager must be initialized before you can get a bundle.");
                return new AssetBundleAsync();
            }

            return new AssetBundleAsync(bundleName, GetBundle);
        }


        /// <summary>
        ///     Returns the bundle name with the bundle hash appended to it.  Needed if you have hash naming enabled via
        ///     <code>AppendHashToBundleNames(true)</code>
        /// </summary>
        public string GetHashedBundleName(string bundleName)
        {
            try {
                bundleName = unhashedToHashedBundleNameMap[bundleName];
            } catch {
                Debug.LogWarningFormat("Unable to find hash for bundle [{0}], this request is likely to fail.", bundleName);
            }

            return bundleName;
        }

        public bool IsVersionCached(string bundleName)
        {
            if (Manifest == null) return false;
            if (useHash) bundleName = GetHashedBundleName(bundleName);
            if (string.IsNullOrEmpty(bundleName)) return false;
            return Caching.IsVersionCached(bundleName, Manifest.GetAssetBundleHash(bundleName));
        }

        /// <summary>
        ///     Cleans up all downloaded bundles
        /// </summary>
        public void Dispose()
        {
            foreach (var cache in activeBundles.Values) {
                if (cache.AssetBundle != null) {
                    cache.AssetBundle.Unload(true);
                }
            }

            activeBundles.Clear();
        }

        /// <summary>
        ///     Unloads an AssetBundle.  Objects that were loaded from this bundle will need to be manually destroyed.
        /// </summary>
        /// <param name="bundle">Bundle to unload.</param>
        public void UnloadBundle(AssetBundle bundle)
        {
            if (bundle == null) return;
            UnloadBundle(bundle.name, false, false);
        }

        /// <summary>
        ///     Unloads an AssetBundle.
        /// </summary>
        /// <param name="bundle">Bundle to unload.</param>
        /// <param name="unloadAllLoadedObjects">
        ///     When true, all objects that were loaded from this bundle will be destroyed as
        ///     well. If there are game objects in your scene referencing those assets, the references to them will become missing.
        /// </param>
        public void UnloadBundle(AssetBundle bundle, bool unloadAllLoadedObjects)
        {
            if (bundle == null) return;
            UnloadBundle(bundle.name, unloadAllLoadedObjects, false);
        }

        /// <summary>
        ///     Unloads an AssetBundle.
        /// </summary>
        /// <param name="bundleName">Bundle to unload.</param>
        /// <param name="unloadAllLoadedObjects">
        ///     When true, all objects that were loaded from this bundle will be destroyed as
        ///     well. If there are game objects in your scene referencing those assets, the references to them will become missing.
        /// </param>
        /// <param name="force">Unload the bundle even if we believe there are other dependencies on it.</param>
        public void UnloadBundle(string bundleName, bool unloadAllLoadedObjects, bool force)
        {
            if (bundleName == null) return;

            AssetBundleContainer cache;

            if (!activeBundles.TryGetValue(bundleName, out cache)) return;

            if (force || --cache.References <= 0) {
                if (cache.AssetBundle != null) {
                    cache.AssetBundle.Unload(unloadAllLoadedObjects);
                }

                activeBundles.Remove(bundleName);

                for (int i = 0; i < cache.Dependencies.Length; i++) {
                    UnloadBundle(cache.Dependencies[i], unloadAllLoadedObjects, force);
                }
            }
        }

        /// <summary>
        ///     Caches the downloaded bundle and pushes it to the onComplete callback.
        /// </summary>
        private void OnDownloadComplete(string bundleName, AssetBundle bundle)
        {
            var inProgress = downloadsInProgress[bundleName];
            downloadsInProgress.Remove(bundleName);

            try {
                activeBundles.Add(bundleName, new AssetBundleContainer {
                    AssetBundle = bundle,
                    References = inProgress.References,
                    Dependencies = Manifest.GetDirectDependencies(bundleName)
                });
            } catch (ArgumentException) {
                Debug.LogWarning("Attempted to activate a bundle that was already active.  Not sure how this happened, attempting to fail gracefully.");
                activeBundles[bundleName].References++;
            }

            inProgress.OnComplete(bundle);
        }

        internal class AssetBundleContainer
        {
            public AssetBundle AssetBundle;
            public int References = 1;
            public string[] Dependencies;
        }

        internal class DownloadInProgressContainer
        {
            public int References;
            public Action<AssetBundle> OnComplete;

            public DownloadInProgressContainer(Action<AssetBundle> onComplete)
            {
                References = 1;
                OnComplete = onComplete;
            }
        }
    }
}