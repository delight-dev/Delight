#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine;
#endregion

namespace Delight
{
    /// <summary>
    /// Base class for unity asset objects.
    /// </summary>
    public class AssetObject : BindableObject
    {
        #region Fields

        public bool IsResource { get; set; }

        public string AssetBundleId { get; set; }
        public AssetBundle AssetBundle
        {
            get { return Assets.AssetBundles[AssetBundleId]; }
            set { AssetBundleId = value?.Id; }
        }

        #endregion
    }

    /// <summary>
    /// Base class for unity asset objects.
    /// </summary>
    public class AssetObject<T> : AssetObject
        where T : UnityEngine.Object
    {
        #region Fields

        private T _unityObject;
        public T UnityObject
        {
            get { return _unityObject; }
            set { SetProperty(ref _unityObject, value); }
        }

        private readonly SemaphoreLocker _locker = new SemaphoreLocker();

        #endregion

        #region Methods

        public void RegisterReference(object referenceObject)
        {
            var assetBundle = AssetBundle;
            if (assetBundle == null)
                return; // TODO if resource keep track of references per asset object not bundle

            assetBundle.RegisterReference(referenceObject);
        }

        public void UnregisterReference(object referenceObject)
        {
            var assetBundle = AssetBundle;
            if (assetBundle == null)
                return; // TODO if resource keep track of references per asset object not bundle

            assetBundle.UnregisterReference(referenceObject);
        }

        public async void LoadAsync()
        {
            await GetAsync();
        }

        public async Task<T> GetAsync()
        {
            await _locker.LockAsync(async () =>
            {
                if (UnityObject != null)
                {
                    return;
                }

                // is asset included in build?
                if (IsResource)
                {
                    // yes. load from resources folder
                    var resourceObject = await Resources.LoadAsync<T>(Id);
                    if (resourceObject == null)
                    {
                        Debug.Log(String.Format("[Delight] Unable to load resource asset \"{0}\". Resource not found.", Id));
                        return;
                    }

                    UnityObject = resourceObject as T;
                    return;
                }

                var assetBundle = AssetBundle;
                if (assetBundle == null)
                {
                    Debug.Log(String.Format("[Delight] Unable to load asset \"{0}\". Asset bundle \"{1}\" not found.", Id, AssetBundleId));
                    return;
                }

                // get unity asset bundle
                var unityAssetBundle = await assetBundle.GetAsync();
                if (unityAssetBundle == null)
                {
                    Debug.Log(String.Format("[Delight] Unable to load asset \"{0}\". Failed to load asset bundle \"{1}\".", Id, AssetBundleId));
                    return;
                }

                // simulate slow load
                // await Task.Delay(1500); // TODO remove

                // see if sprite is in bundle 
                var unityObject = await unityAssetBundle.LoadAssetAsync<T>(Id);
                if (unityObject == null)
                {
                    Debug.Log(String.Format("[Delight] Unable to load asset \"{0}\". Asset not found in asset bundle \"{1}\".", Id, AssetBundleId));
                    return;
                }

                UnityObject = unityObject as T;
            });

            return UnityObject;
        }

        #endregion
    }
}
