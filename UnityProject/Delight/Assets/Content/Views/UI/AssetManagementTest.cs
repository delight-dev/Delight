#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
#endregion

namespace Delight
{
    public partial class AssetManagementTest
    {
        public AssetBundleManager abm;
         
        public void Test1()
        {
            LoadAssetBundleAsync("bundle1");

            BigSlowView1.LoadAsync();

            //Image1.Sprite = Assets.Sprites.Frame1;
        }

        public async void LoadAssetBundleAsync(string bundleName)
        {
            await LoadAssetBundle(bundleName);
        }

        System.Collections.IEnumerator LoadAssetBundle(string bundleName)
        { 
            AssetBundleManager abm = new AssetBundleManager();
            if (Application.isEditor)
            {
                abm.UseSimulatedUri();
            }
            else
            {
                // TODO check if asset should be loaded locally (StreamingAssets) or from server
                abm.SetBaseUri("https://www.example.com/bundles");
            }
            var initializeAsync = abm.InitializeAsync();
            yield return initializeAsync;

            if (initializeAsync.Success)
            {
                AssetBundleAsync bundle = abm.GetBundleAsync(bundleName);
                yield return bundle;

                // TODO remove, simulate slow loading of asset bundle
                yield return new WaitForSeconds(7);

                if (bundle.AssetBundle != null)
                {
                    Debug.Log("WOOOHOOO!!! we loaded a BUNDLE!");
                    // do something with the bundle
                    abm.UnloadBundle(bundle.AssetBundle);
                }
            }
            else
            {
                Debug.LogError("[Delight] Error initializing ABM.");
            }

            abm.Dispose();
        }

        public void Test2()
        {
        }

        protected override void BeforeLoad()
        {
            base.BeforeLoad();
        }

        private IDisposable _update;
        protected override void AfterLoad()
        {
            base.AfterLoad();

            // add one player every second
            _update = Observable.Interval(TimeSpan.FromMilliseconds(10)).Subscribe(x =>
            {
                TimeString = DateTime.Now.ToString("mm:ss.ff");
            });
        }
    }
}
