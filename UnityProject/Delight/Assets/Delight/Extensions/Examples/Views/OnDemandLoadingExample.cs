#region Using Statements
using UnityEngine.EventSystems;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Text;
#endregion

namespace Delight
{
    public partial class OnDemandLoadingExample
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
            //if (BigSpriteImage.Offset == null) // Testing setting offset
            //    BigSpriteImage.Offset = new ElementMargin();
            //BigSpriteImage.Offset.Left += 20;

            BigSpriteImage.Sprite = Assets.Sprites["Frame1"]; // TODO uncomment
        }

        private float _timer1;
        private float _timer2;
        private StringBuilder _sb = new StringBuilder();

        /// <summary>
        /// Called once per frame if EnableScriptEvents is true.
        /// </summary>
        public override void Update()
        {
            base.Update();

            if (_timer1 <= 0)
            {
                TimeString = String.Format("<mspace=13>{0}</mspace>", DateTime.Now.ToString("mm:ss.ff"));
            }

            if (_timer2 <= 0)
            {
                // print loaded sprites
                _sb.Clear();
                foreach (var sprite in Assets.Sprites)
                {
                    _sb.AppendLine("{0} ({1}) : {2}", sprite.Id, sprite.AssetBundleId ?? "Resources",
                        sprite.UnityObject != null ? "yes" : "no");
                }

                LoadedAssetsString = _sb.ToString();

                // print loaded asset bundles
                _sb.Clear();
                foreach (var assetBundle in Assets.AssetBundles)
                {
                    _sb.AppendLine("{0} : {1}", assetBundle.Id, assetBundle.UnityAssetBundle != null ? "yes" : "no");
                }

                LoadedAssetBundlesString = _sb.ToString();
            }

            _timer1 += Time.deltaTime;
            _timer2 += Time.deltaTime;

            if (_timer1 >= 0.01)
            {
                _timer1 = 0;
            }

            if (_timer2 >= 0.5)
            {
                _timer2 = 0;
            }
        }
    }
}
