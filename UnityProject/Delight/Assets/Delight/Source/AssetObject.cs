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
        public string AssetBundleId { get; set; }
        public AssetBundle AssetBundle
        {
            get { return Assets.AssetBundles[AssetBundleId]; }
            set { AssetBundleId = value?.Id; }
        }
    }

    /// <summary>
    /// Base class for unity asset objects.
    /// </summary>
    public class AssetObject<T> : AssetObject
        where T : UnityEngine.Object
    {
        #region Properties

        public T UnityObject { get; set; }

        private readonly SemaphoreLocker _locker = new SemaphoreLocker();

        #endregion

        #region Methods

        public async Task<T> GetAsync()
        {
            await _locker.LockAsync(async () =>
            {
                if (UnityObject != null)
                {
                    return;
                }

                var assetBundle = AssetBundle;
                if (assetBundle == null)
                {
                    Debug.Log(String.Format("[Delight] Unable to load asset \"{0}\". Asset bundle \"{1}\" not found.", Id, AssetBundleId));
                    return;
                }

                // get unity asset bundle URI 
                var unityAssetBundle = await assetBundle.GetAsync();

                // simulate slow load
                await Task.Delay(2500);

                // see if sprite is in bundle 

                var unityObject = unityAssetBundle.LoadAsset<T>(Id);

                Debug.Log(String.Format("Assets in bundle \"{0}\": {1}", AssetBundleId, string.Join(",", unityAssetBundle.GetAllAssetNames())));
                Debug.Log(String.Format("unityAssetBundle.LoadAsset<T>({0}) = {1}", Id, unityObject));

                UnityObject = unityObject;
            });

            return UnityObject;
        }

        #endregion
    }
}
