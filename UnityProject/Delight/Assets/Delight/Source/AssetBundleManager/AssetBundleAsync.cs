using System;
using System.Collections;
using UnityEngine;

namespace Delight
{
    /// <summary>
    ///     An asynchronous wrapper for the AssetBundleManager downloading system
    /// </summary>
    public class AssetBundleAsync : IEnumerator
    {
        public AssetBundle AssetBundle;

        public bool IsDone { get; private set; }
        public bool Failed { get; private set; }

        public AssetBundleAsync(string bundleName, Action<string, Action<AssetBundle>> callToAction)
        {
            IsDone = false;
            callToAction(bundleName, OnAssetBundleComplete);
        }

        public AssetBundleAsync()
        {
            IsDone = true;
            Failed = true;
        }

        private void OnAssetBundleComplete(AssetBundle bundle)
        {
            AssetBundle = bundle;
            Failed = bundle == null;
            IsDone = true;
        }

        public bool MoveNext()
        {
            return !IsDone;
        }

        public void Reset()
        { }

        public object Current {
            get { return null; }
        }
    }

    /// <summary>
    ///     An asynchronous wrapper for the AssetBundleManager manifest downloading system
    /// </summary>
    public class AssetBundleManifestAsync : IEnumerator
    {
        public bool Success { get; private set; }
        public bool IsDone { get; private set; }

        public AssetBundleManifestAsync(string bundleName, Action<string, Action<AssetBundle>> callToAction)
        {
            IsDone = false;
            callToAction(bundleName, OnAssetBundleManifestComplete);
        }

        private void OnAssetBundleManifestComplete(AssetBundle bundle)
        {
            Success = bundle != null;
            IsDone = true;
        }

        public bool MoveNext()
        {
            return !IsDone;
        }

        public void Reset()
        { }

        public object Current {
            get { return null; }
        }
    }
}