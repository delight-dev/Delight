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
        public void LoadAll()
        {
            if (!ImageSet1.IsLoaded) ToggleLoad1();
            if (!ImageSet2.IsLoaded) ToggleLoad2();
            if (!ImageSet3.IsLoaded) ToggleLoad3();
            if (!ImageSet4.IsLoaded) ToggleLoad4();
        }

        public void UnloadAll()
        {
            if (ImageSet1.IsLoaded) ToggleLoad1();
            if (ImageSet2.IsLoaded) ToggleLoad2();
            if (ImageSet3.IsLoaded) ToggleLoad3();
            if (ImageSet4.IsLoaded) ToggleLoad4();
            GC.Collect();
        }

        public async void ToggleLoad1()
        {
            if (!ImageSet1.IsLoaded)
            {
                await ImageSet1.LoadAsync();
                Load1Button.Text = "Unload Set 1";
            }
            else
            {
                ImageSet1.Unload();
                Load1Button.Text = "Load Set 1";                
            }
        }

        public async void ToggleLoad2()
        {
            if (!ImageSet2.IsLoaded)
            {
                await ImageSet2.LoadAsync();
                Load2Button.Text = "Unload Set 2";
            }
            else
            {
                ImageSet2.Unload();
                Load2Button.Text = "Load Set 2";
            }
        }

        public async void ToggleLoad3()
        {
            if (!ImageSet3.IsLoaded)
            {
                await ImageSet3.LoadAsync();
                Load3Button.Text = "Unload Set 3";
            }
            else
            {
                ImageSet3.Unload();
                Load3Button.Text = "Load Set 3";
            }
        }

        public async void ToggleLoad4()
        {
            if (!ImageSet4.IsLoaded)
            {
                await ImageSet4.LoadAsync();
                Load4Button.Text = "Unload Set 4";
            }
            else
            {
                ImageSet4.Unload();
                Load4Button.Text = "Load Set 4";
            }
        }

        public void SetSprite()
        {
            BigSpriteImage.Sprite = Assets.Sprites.Frame1;
        }
       
        public StringBuilder sb = new StringBuilder();
        private IDisposable _updateTimer;
        private IDisposable _updateLoadedAssets;
        protected override void AfterLoad()
        {            
            base.AfterLoad();

            _updateTimer = Observable.Interval(TimeSpan.FromMilliseconds(10)).Subscribe(x =>
            {
                // print timer to see if UI thread stalls or not
                TimeString = String.Format("<mspace=13>{0}</mspace>", DateTime.Now.ToString("mm:ss.ff"));
            });

            _updateLoadedAssets = Observable.Interval(TimeSpan.FromMilliseconds(500)).Subscribe(x =>
            {
                // print loaded sprites
                sb.Clear();
                foreach (var sprite in Assets.Sprites)
                {
                    sb.AppendLine("{0} ({1}) : {2}", sprite.Id, sprite.AssetBundleId ?? "Resources", sprite.UnityObject != null ? "yes" : "no");
                }

                LoadedAssetsString = sb.ToString();

                // print loaded asset bundles
                sb.Clear();
                foreach (var assetBundle in Assets.AssetBundles)
                {
                    sb.AppendLine("{0} : {1}", assetBundle.Id, assetBundle.UnityAssetBundle != null ? "yes" : "no");
                }
                LoadedAssetBundlesString = sb.ToString();
            });
        }
    }
}
