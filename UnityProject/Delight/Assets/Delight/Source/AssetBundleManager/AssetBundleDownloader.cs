using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

namespace Delight
{
    public struct AssetBundleDownloadCommand
    {
        public string BundleName;
        public Hash128 Hash;
        public uint Version;
        public Action<AssetBundle> OnComplete;
    }

    public class AssetBundleDownloader : ICommandHandler<AssetBundleDownloadCommand>
    {
        private const int MAX_RETRY_COUNT = 3;
        private const float RETRY_WAIT_PERIOD = 1;
        private const int MAX_SIMULTANEOUS_DOWNLOADS = 4;

        private static readonly Hash128 DEFAULT_HASH = default(Hash128);

        private static readonly long[] RETRY_ON_ERRORS = {
            503 // Temporary Server Error
        };

        private string baseUri;
        private Action<IEnumerator> coroutineHandler;

        private int activeDownloads = 0;
        private Queue<IEnumerator> downloadQueue = new Queue<IEnumerator>();
        private bool cachingDisabled;

        /// <summary>
        ///     Creates a new instance of the AssetBundleDownloader.
        /// </summary>
        /// <param name="baseUri">Uri to use as the base for all bundle requests.</param>
        public AssetBundleDownloader(string baseUri)
        {
            this.baseUri = baseUri;

#if UNITY_EDITOR
            if (!Application.isPlaying)
                coroutineHandler = EditorCoroutine.Start;
            else
#endif
                coroutineHandler = AssetBundleDownloaderMonobehaviour.Instance.HandleCoroutine;

            if (!this.baseUri.EndsWith("/")) {
                this.baseUri += "/";
            }
        }

        /// <summary>
        ///     Begin handling of a AssetBundleDownloadCommand object.
        /// </summary>
        public void Handle(AssetBundleDownloadCommand cmd)
        {
            InternalHandle(Download(cmd, 0));
        }

        private void InternalHandle(IEnumerator downloadCoroutine)
        {
            if (activeDownloads < MAX_SIMULTANEOUS_DOWNLOADS) {
                activeDownloads++;
                coroutineHandler(downloadCoroutine);
            } else {
                downloadQueue.Enqueue(downloadCoroutine);
            }
        }

        private IEnumerator Download(AssetBundleDownloadCommand cmd, int retryCount)
        {
            var uri = baseUri + cmd.BundleName;
            UnityWebRequest req;
            if (cachingDisabled || (cmd.Version <= 0 && cmd.Hash == DEFAULT_HASH)) {
                Debug.Log(string.Format("GetAssetBundle [{0}].", uri));
#if UNITY_2018_1_OR_NEWER
                req = UnityWebRequestAssetBundle.GetAssetBundle(uri);
#else
                req = UnityWebRequest.GetAssetBundle(uri);
#endif
            } else if (cmd.Hash == DEFAULT_HASH) {
                Debug.Log(string.Format("GetAssetBundle [{0}] v[{1}] [{2}].", Caching.IsVersionCached(uri, new Hash128(0, 0, 0, cmd.Version)) ? "cached" : "uncached", cmd.Version, uri));
#if UNITY_2018_1_OR_NEWER
                req = UnityWebRequestAssetBundle.GetAssetBundle(uri, cmd.Version, 0);
#else
                req = UnityWebRequest.GetAssetBundle(uri, cmd.Version, 0);
#endif
            } else {
                Debug.Log(string.Format("GetAssetBundle [{0}] [{1}] [{2}].", Caching.IsVersionCached(uri, cmd.Hash) ? "cached" : "uncached", uri, cmd.Hash));
#if UNITY_2018_1_OR_NEWER
                req = UnityWebRequestAssetBundle.GetAssetBundle(uri, cmd.Hash, 0);
#else
                req = UnityWebRequest.GetAssetBundle(uri, cmd.Hash, 0);
#endif
            }

#if UNITY_2017_2_OR_NEWER
            req.SendWebRequest();
#else
            req.Send();
#endif

            while (!req.isDone) {
                yield return null;
            }

#if UNITY_2017_1_OR_NEWER
            var isNetworkError = req.isNetworkError;
            var isHttpError = req.isHttpError;
#else
            var isNetworkError = req.isError;
            var isHttpError = (req.responseCode < 200 || req.responseCode > 299) && req.responseCode != 0;  // 0 indicates the cached version may have been downloaded.  If there was an error then req.isError should have a non-0 code.
#endif

            if (isHttpError) {
                Debug.LogError(string.Format("Error downloading [{0}]: [{1}] [{2}]", uri, req.responseCode, req.error));

                if (retryCount < MAX_RETRY_COUNT && RETRY_ON_ERRORS.Contains(req.responseCode)) {
                    Debug.LogWarning(string.Format("Retrying [{0}] in [{1}] seconds...", uri, RETRY_WAIT_PERIOD));
                    req.Dispose();
                    activeDownloads--;
                    yield return new WaitForSeconds(RETRY_WAIT_PERIOD);
                    InternalHandle(Download(cmd, retryCount + 1));
                    yield break;
                }
            }

            AssetBundle bundle;

            if (isNetworkError) {
                Debug.LogError(string.Format("Error downloading [{0}]: [{1}]", uri, req.error));
                bundle = null;
            } else {
                bundle = DownloadHandlerAssetBundle.GetContent(req);
            }

            if (!isNetworkError && !isHttpError && string.IsNullOrEmpty(req.error) && bundle == null) {
                if (cachingDisabled) {
                    Debug.LogWarning(string.Format("There was no error downloading [{0}] but the bundle is null.  Caching has already been disabled, not sure there's anything else that can be done.  Returning...", uri));
                } else {
                    Debug.LogWarning(string.Format("There was no error downloading [{0}] but the bundle is null.  Assuming there's something wrong with the cache folder, retrying with cache disabled now and for future requests...", uri));
                    cachingDisabled = true;
                    req.Dispose();
                    activeDownloads--;
                    yield return new WaitForSeconds(RETRY_WAIT_PERIOD);
                    InternalHandle(Download(cmd, retryCount + 1));
                    yield break;
                }
            }

            try {
                cmd.OnComplete(bundle);
            } finally {
                req.Dispose();

                activeDownloads--;

                if (downloadQueue.Count > 0) {
                    InternalHandle(downloadQueue.Dequeue());
                }
            }
        }
    }
}