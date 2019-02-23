// Asset data and providers generated from asset content
#region Using Statements
using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    #region Asset Bundles

    public partial class AssetBundleData : DataProvider<AssetBundle>
    {
        #region Fields

        public readonly AssetBundle Bundle1;
        public readonly AssetBundle Bundle2;

        #endregion

        #region Constructor

        public AssetBundleData()
        {
            Bundle1 = new AssetBundle { Id = "Bundle1", StorageMode = StorageMode.Local };
            Bundle2 = new AssetBundle { Id = "Bundle2", StorageMode = StorageMode.Remote };

            Add(Bundle1);
            Add(Bundle2);
        }

        #endregion
    }

    #endregion

    #region TMP_FontAssets

    public partial class TMP_FontAsset : AssetObject<TMPro.TMP_FontAsset>
    {
    }

    public partial class TMP_FontAssetData : DataProvider<TMP_FontAsset>
    {
        #region Fields

        public readonly TMP_FontAsset LiberationSansSDF;

        #endregion

        #region Constructor

        public TMP_FontAssetData()
        {
            LiberationSansSDF = new TMP_FontAsset { Id = "LiberationSans SDF", AssetBundleId = "Bundle1", RelativePath = "Sprites/" };

            Add(LiberationSansSDF);
        }

        #endregion
    }

    public static partial class Assets
    {
        public static TMP_FontAssetData TMP_FontAssets = new TMP_FontAssetData();
    }

    #endregion

    #region Materials

    public partial class MaterialAsset : AssetObject<UnityEngine.Material>
    {
    }

    public partial class MaterialAssetData : DataProvider<MaterialAsset>
    {
        #region Fields

        public readonly MaterialAsset Netpattern01;
        public readonly MaterialAsset LiberationSansSDFDropShadow;
        public readonly MaterialAsset UIFastDefault;

        #endregion

        #region Constructor

        public MaterialAssetData()
        {
            Netpattern01 = new MaterialAsset { Id = "Net pattern 01", AssetBundleId = "Bundle1", RelativePath = "Materials/Net 01/" };
            LiberationSansSDFDropShadow = new MaterialAsset { Id = "LiberationSans SDF - Drop Shadow", AssetBundleId = "Bundle1", RelativePath = "Sprites/" };
            UIFastDefault = new MaterialAsset { Id = "UI-Fast-Default", IsResource = true, RelativePath = "Materials/" };

            Add(Netpattern01);
            Add(LiberationSansSDFDropShadow);
            Add(UIFastDefault);
        }

        #endregion
    }

    public static partial class Assets
    {
        public static MaterialAssetData Materials = new MaterialAssetData();
    }

    #endregion

    #region Sprites

    public partial class SpriteAsset : AssetObject<UnityEngine.Sprite>
    {
    }

    public partial class SpriteAssetData : DataProvider<SpriteAsset>
    {
        #region Fields

        public readonly SpriteAsset Frame1;
        public readonly SpriteAsset Frame2;
        public readonly SpriteAsset BigSprite;
        public readonly SpriteAsset Frame3;
        public readonly SpriteAsset Frame4;
        public readonly SpriteAsset EditorGrid;

        #endregion

        #region Constructor

        public SpriteAssetData()
        {
            Frame1 = new SpriteAsset { Id = "Frame1", AssetBundleId = "Bundle1", RelativePath = "Sprites/" };
            Frame2 = new SpriteAsset { Id = "Frame2", AssetBundleId = "Bundle1", RelativePath = "Sprites/" };
            BigSprite = new SpriteAsset { Id = "BigSprite", AssetBundleId = "Bundle2", RelativePath = "" };
            Frame3 = new SpriteAsset { Id = "Frame3", AssetBundleId = "Bundle2", RelativePath = "" };
            Frame4 = new SpriteAsset { Id = "Frame4", IsResource = true, RelativePath = "" };
            EditorGrid = new SpriteAsset { Id = "EditorGrid", IsResource = true, RelativePath = "Sprites/" };

            Add(Frame1);
            Add(Frame2);
            Add(BigSprite);
            Add(Frame3);
            Add(Frame4);
            Add(EditorGrid);
        }

        #endregion
    }

    public static partial class Assets
    {
        public static SpriteAssetData Sprites = new SpriteAssetData();
    }

    #endregion

    #region Texture2Ds

    public partial class Texture2DAsset : AssetObject<UnityEngine.Texture2D>
    {
    }

    public partial class Texture2DAssetData : DataProvider<Texture2DAsset>
    {
        #region Fields

        public readonly Texture2DAsset Diffuse;
        public readonly Texture2DAsset Normal;
        public readonly Texture2DAsset Preview;
        public readonly Texture2DAsset Bluefloral01;

        #endregion

        #region Constructor

        public Texture2DAssetData()
        {
            Diffuse = new Texture2DAsset { Id = "diffuse", AssetBundleId = "Bundle1", RelativePath = "Materials/Net 01/" };
            Normal = new Texture2DAsset { Id = "normal", AssetBundleId = "Bundle1", RelativePath = "Materials/Net 01/" };
            Preview = new Texture2DAsset { Id = "preview", AssetBundleId = "Bundle1", RelativePath = "Materials/Net 01/" };
            Bluefloral01 = new Texture2DAsset { Id = "bluefloral01", AssetBundleId = "Bundle2", RelativePath = "" };

            Add(Diffuse);
            Add(Normal);
            Add(Preview);
            Add(Bluefloral01);
        }

        #endregion
    }

    public static partial class Assets
    {
        public static Texture2DAssetData Texture2Ds = new Texture2DAssetData();
    }

    #endregion

    #region Shaders

    public partial class ShaderAsset : AssetObject<UnityEngine.Shader>
    {
    }

    public partial class ShaderAssetData : DataProvider<ShaderAsset>
    {
        #region Fields

        public readonly ShaderAsset UIFastDefault;

        #endregion

        #region Constructor

        public ShaderAssetData()
        {
            UIFastDefault = new ShaderAsset { Id = "UI-Fast-Default", IsResource = true, RelativePath = "Shaders/" };

            Add(UIFastDefault);
        }

        #endregion
    }

    public static partial class Assets
    {
        public static ShaderAssetData Shaders = new ShaderAssetData();
    }

    #endregion

    #region TMP_ColorGradients

    public partial class TMP_ColorGradientAsset : AssetObject<TMPro.TMP_ColorGradient>
    {
    }

    public partial class TMP_ColorGradientAssetData : DataProvider<TMP_ColorGradientAsset>
    {
    }

    public static partial class Assets
    {
        public static TMP_ColorGradientAssetData TMP_ColorGradients = new TMP_ColorGradientAssetData();
    }

    #endregion

    #region TMP_SpriteAssets

    public partial class TMP_SpriteAsset : AssetObject<TMPro.TMP_SpriteAsset>
    {
    }

    public partial class TMP_SpriteAssetData : DataProvider<TMP_SpriteAsset>
    {
    }

    public static partial class Assets
    {
        public static TMP_SpriteAssetData TMP_SpriteAssets = new TMP_SpriteAssetData();
    }

    #endregion
}
