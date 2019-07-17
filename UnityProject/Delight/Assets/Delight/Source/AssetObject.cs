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
    /// Base class for unity asset object managers. Loads/unloads the asset on-demand as it's requested by views.
    /// </summary>
    public class AssetObject : AtomicBindableObject
    {
        #region Fields

        public virtual bool IsLoaded { get; }
        
        public bool IsResource { get; set; }
        public string RelativePath { get; set; }
        public bool IsUnmanaged { get; set; }

        public string AssetBundleId { get; set; }
        public AssetBundle AssetBundle
        {
            get { return Assets.AssetBundles[AssetBundleId]; }
            set { AssetBundleId = value?.Id; }
        }

        public Dictionary<int, WeakReference> _referenceObjects;

        public string Name
        {
            get
            {
                int separatorIndex = Id.LastIndexOf("/");
                return separatorIndex < 0 ? Id : Id.Substring(separatorIndex + 1);
            }
        }

        public string FullPath
        {
            get
            {
                return RelativePath + Name;
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public AssetObject()
        {
            _referenceObjects = new Dictionary<int, WeakReference>();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Registers that an object references the asset.
        /// </summary>
        public void RegisterReference(object referenceObject)
        {
            // register reference
            _referenceObjects[referenceObject.GetHashCode()] = new WeakReference(referenceObject);

            // register reference on asset bundle
            var assetBundle = AssetBundle;
            if (assetBundle != null)
            {
                assetBundle.RegisterReference(referenceObject);
            }

            // trigger load 
            //LoadGenericAsync(); 
            Load(); // loads resources synchronously to fix with with pop-ins
        }

        /// <summary>
        /// Registers that an object references the asset.
        /// </summary>
        public async Task RegisterReferenceAsync(object referenceObject)
        {
            // register reference
            _referenceObjects[referenceObject.GetHashCode()] = new WeakReference(referenceObject);

            // register reference on asset bundle
            var assetBundle = AssetBundle;
            if (assetBundle != null)
            {
                assetBundle.RegisterReference(referenceObject);
            }

            // trigger load 
            await LoadGenericAsync();
        }

        /// <summary>
        /// Unregisters an object from referencing the asset.
        /// </summary>
        public void UnregisterReference(object referenceObject)
        {
            // unregister reference
            _referenceObjects.Remove(referenceObject.GetHashCode());

            // remove dead references
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

            // if nothing references the asset, unload it
            if (_referenceObjects.Count <= 0)
            {
                Unload();
            }

            // unregister reference on asset bundle
            var assetBundle = AssetBundle;
            if (assetBundle == null)
                return;

            assetBundle.UnregisterReference(referenceObject);
        }

        /// <summary>
        /// Loads asset synchronously. 
        /// </summary>
        public virtual void Load()
        {
        }

        /// <summary>
        /// Loads the asset asynchronously. 
        /// </summary>
        public virtual async Task LoadGenericAsync()
        {
            await Task.FromResult(0); // just to prevent compiler warning
        }

        /// <summary>
        /// Unloads the asset.
        /// </summary>
        public virtual void Unload()
        {
        }

        /// <summary>
        /// Gets unity object.
        /// </summary>
        public virtual UnityEngine.Object GetUnityObject()
        {
            return null;
        }

        #endregion
    }

    /// <summary>
    /// Generic base class for unity asset object managers. Loads/unloads the asset on-demand as it's requested by views.
    /// </summary>
    public class AssetObject<T> : AssetObject
        where T : UnityEngine.Object
    {
        #region Fields

        public override bool IsLoaded
        {
            get { return UnityObject != null; }
        }

        private T _unityObject;
        public T UnityObject
        {
            get { return _unityObject; }
            set { SetProperty(ref _unityObject, value); }
        }

        private readonly SemaphoreLocker _locker = new SemaphoreLocker();

        #endregion

        #region Methods

        /// <summary>
        /// Load the asset synchronously. 
        /// </summary>
        public override void Load()
        {
            if (UnityObject != null || IsUnmanaged)
                return;

            // is asset included in build?
            if (IsResource)
            {
                // yes. load from resources folder
                var resourceObject = Resources.Load<T>(FullPath);
                if (resourceObject == null)
                {
                    Debug.Log(String.Format("#Delight# Unable to load resource asset \"{0}\". Resource not found.", FullPath));
                    OnPropertyChanged(nameof(UnityObject)); // trigger property change to signal listeners that load is complete
                    return;
                }

                UnityObject = resourceObject as T;
                return;
            }
            else
            {
#pragma warning disable CS4014
                // if asset is in bundle, load it asynchronously
                LoadGenericAsync();
#pragma warning restore CS4014
            }
        }

        /// <summary>
        /// Loads the asset asynchronously. 
        /// </summary>
        public override async Task LoadGenericAsync()
        {
            await LoadAsync();
        }

        /// <summary>
        /// Loads the asset asynchronously. 
        /// </summary>
        public async Task<T> LoadAsync()
        {
            await _locker.LockAsync(async () =>
            {
                // is the asset already loaded or managed elsewhere? 
                if (UnityObject != null || IsUnmanaged)
                {
                    return; // yes.
                }

                // simulate slow load
                //await Task.Delay(2000); // TODO add option to simulate network lag in editor

                // is asset included in build?
                if (IsResource)
                {
                    // yes. load from resources folder
                    var resourceObject = await Resources.LoadAsync<T>(FullPath);
                    if (resourceObject == null)
                    {
                        Debug.Log(String.Format("#Delight# Unable to load resource asset \"{0}\". Resource not found.", FullPath));
                        OnPropertyChanged(nameof(UnityObject)); // trigger property change to signal listeners that load is complete
                        return;
                    }

                    UnityObject = resourceObject as T;
                    return;
                }

                var assetBundle = AssetBundle;
                if (assetBundle == null)
                {
                    Debug.Log(String.Format("#Delight# Unable to load asset \"{0}\". Asset bundle \"{1}\" not found.", Id, AssetBundleId));
                    OnPropertyChanged(nameof(UnityObject)); // trigger property change to signal listeners that load is complete
                    return;
                }

                // get unity asset bundle
                var unityAssetBundle = await assetBundle.LoadAsync();
                if (unityAssetBundle == null)
                {
                    Debug.Log(String.Format("#Delight# Unable to load asset \"{0}\". Failed to load asset bundle \"{1}\".", Id, AssetBundleId));
                    OnPropertyChanged(nameof(UnityObject)); // trigger property change to signal listeners that load is complete
                    return;
                }

                // see if sprite is in bundle 
                //var unityObject = await unityAssetBundle.LoadAssetAsync<T>(Id); // bug in Unity makes it so assets loaded asynchronously does not get unloaded when Resources.UnloadAsset() is called
                var unityObject = unityAssetBundle.LoadAsset<T>(Id);
                if (unityObject == null)
                {
                    Debug.Log(String.Format("#Delight# Unable to load asset \"{0}\". Asset not found in asset bundle \"{1}\".", Id, AssetBundleId));
                    OnPropertyChanged(nameof(UnityObject)); // trigger property change to signal listeners that load is complete
                    return;
                }

                UnityObject = unityObject as T;
            });

            return UnityObject;
        }

        /// <summary>
        /// Unloads the asset.
        /// </summary>
        public override void Unload()
        {
            if (UnityObject == null || IsUnmanaged)
                return;

            if (IsResource)
            {
                Resources.UnloadAsset(UnityObject);
            }
            else
            {
                Resources.UnloadAsset(UnityObject);
                //Resources.UnloadUnusedAssets(); // expensive call as it goes through the entire hierarchy, but asset from bundle isn't freed from memory without calling it
            }

            UnityObject = null;
        }

        /// <summary>
        /// Gets unity object.
        /// </summary>
        public override UnityEngine.Object GetUnityObject()
        {
            return UnityObject;
        }

        #endregion
    }
}
