#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
#endregion

namespace Delight
{
    public class SpriteAsset : AssetObject<Sprite>
    {
    }

    public partial class SpriteAssets : BindableCollection<SpriteAsset>
    {
        public readonly SpriteAsset Frame1;
        public readonly SpriteAsset Frame2;
        public readonly SpriteAsset Frame3;
        public readonly SpriteAsset Frame4;

        public SpriteAssets()
        {
            Frame1 = new SpriteAsset { Id = "Frame1", AssetBundleId = "Bundle1" };
            Frame2 = new SpriteAsset { Id = "Frame2", AssetBundleId = "Bundle1" };
            Frame3 = new SpriteAsset { Id = "Frame3", AssetBundleId = "Bundle2" };
            Frame4 = new SpriteAsset { Id = "Frame4", IsResource = true }; // AssetBundleId = "Bundle2" };

            Add(Frame1);
            Add(Frame2);
            Add(Frame3);
            Add(Frame4);
        }
    }

    public static partial class Assets
    {
        public static SpriteAssets Sprites = new SpriteAssets();
    }
}
