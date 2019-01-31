#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Text;
#endregion

namespace Delight
{
    public partial class AssetManagementTest
    {
        public AssetBundleManager abm;
         
        public void Test1()
        {
            Debug.Log("Calling LoadAssetBundle1()");
            LoadAssetBundle1();
        }

        public async void LoadAssetBundle1()
        {
            Debug.Log("Bundle1.GetAsync()");
            var bundle = await Assets.AssetBundles.Bundle1.GetAsync();
            Debug.Log("Bundle1.GetAsync() result: " + bundle);
        }

        public void Test2()
        {
            BigSlowView1.Unload();
        }

        protected override void BeforeLoad()
        {
            base.BeforeLoad();
        }

        public StringBuilder sb = new StringBuilder();
        private IDisposable _updateTimer;
        private IDisposable _updateLoadedAssets;
        protected override void AfterLoad()
        {            
            base.AfterLoad();

            _updateTimer = Observable.Interval(TimeSpan.FromMilliseconds(10)).Subscribe(x =>
            {
                TimeString = DateTime.Now.ToString("mm:ss.ff");
            });

            _updateLoadedAssets = Observable.Interval(TimeSpan.FromMilliseconds(500)).Subscribe(x =>
            {
                // print loaded sprites
                sb.Clear();
                foreach (var sprite in Assets.Sprites)
                {
                    sb.AppendLine("{0} ({1}) : {2}", sprite.Id, sprite.AssetBundleId, sprite.Object != null ? "yes" : "no");
                }

                LoadedAssetsString = sb.ToString();

                // print loaded asset bundles
                sb.Clear();
                foreach (var assetBundle in Assets.AssetBundles)
                {
                    sb.AppendLine("{0} : {1}", assetBundle.Id, assetBundle.AssetBundleObject != null ? "yes" : "no");
                }
                LoadedAssetBundlesString = sb.ToString();
            });
        }
    }
}
