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
            Bundle2 = new AssetBundle { Id = "Bundle2", StorageMode = StorageMode.Local };

            Add(Bundle1);
            Add(Bundle2);
        }

        #endregion
    }

    #endregion

    #region Materials

    public partial class MaterialAsset : AssetObject<UnityEngine.Material>
    {
        public static implicit operator MaterialAsset(UnityEngine.Material unityObject)
        {
            return new MaterialAsset { UnityObject = unityObject, IsUnmanaged = true };
        }

        public static implicit operator MaterialAsset(string assetId)
        {
            if (String.IsNullOrEmpty(assetId))
                return null;

            return Assets.Materials[assetId];
        }
    }

    public partial class MaterialAssetData : DataProvider<MaterialAsset>
    {
        #region Fields

        public readonly MaterialAsset UIFastDefault;

        #endregion

        #region Constructor

        public MaterialAssetData()
        {
            UIFastDefault = new MaterialAsset { Id = "UI-Fast-Default", IsResource = true, RelativePath = "Materials/" };

            Add(UIFastDefault);
        }

        #endregion
    }

    public static partial class Assets
    {
        public static MaterialAssetData Materials = new MaterialAssetData();
    }

    #endregion

    #region Fonts

    public partial class FontAsset : AssetObject<UnityEngine.Font>
    {
        public static implicit operator FontAsset(UnityEngine.Font unityObject)
        {
            return new FontAsset { UnityObject = unityObject, IsUnmanaged = true };
        }

        public static implicit operator FontAsset(string assetId)
        {
            if (String.IsNullOrEmpty(assetId))
                return null;

            return Assets.Fonts[assetId];
        }
    }

    public partial class FontAssetData : DataProvider<FontAsset>
    {
        #region Fields

        public readonly FontAsset Ebrima;

        #endregion

        #region Constructor

        public FontAssetData()
        {
            Ebrima = new FontAsset { Id = "Ebrima", IsResource = true, RelativePath = "Fonts/" };

            Add(Ebrima);
        }

        #endregion
    }

    public static partial class Assets
    {
        public static FontAssetData Fonts = new FontAssetData();
    }

    #endregion

    #region Sprites

    public partial class SpriteAsset : AssetObject<UnityEngine.Sprite>
    {
        public static implicit operator SpriteAsset(UnityEngine.Sprite unityObject)
        {
            return new SpriteAsset { UnityObject = unityObject, IsUnmanaged = true };
        }

        public static implicit operator SpriteAsset(string assetId)
        {
            if (String.IsNullOrEmpty(assetId))
                return null;

            return Assets.Sprites[assetId];
        }
    }

    public partial class SpriteAssetData : DataProvider<SpriteAsset>
    {
        #region Fields

        public readonly SpriteAsset Frame1;
        public readonly SpriteAsset Frame2;
        public readonly SpriteAsset BigSprite;
        public readonly SpriteAsset Frame3;
        public readonly SpriteAsset Frame4;
        public readonly SpriteAsset CheckBox;
        public readonly SpriteAsset CheckBoxPressed;
        public readonly SpriteAsset CloseButton;
        public readonly SpriteAsset ComboBoxButton;
        public readonly SpriteAsset ComboBoxButtonPressed;
        public readonly SpriteAsset RadioButton;
        public readonly SpriteAsset RadioButtonPressed;
        public readonly SpriteAsset RainbowSquare;
        public readonly SpriteAsset DesignerGrid;
        public readonly SpriteAsset DesignerGrid2;
        public readonly SpriteAsset EditorGrid;

        #endregion

        #region Constructor

        public SpriteAssetData()
        {
            Frame1 = new SpriteAsset { Id = "Frame1", AssetBundleId = "Bundle1", RelativePath = "Sprites/" };
            Frame2 = new SpriteAsset { Id = "Frame2", AssetBundleId = "Bundle1", RelativePath = "Sprites/" };
            BigSprite = new SpriteAsset { Id = "BigSprite", AssetBundleId = "Bundle2", RelativePath = "" };
            Frame3 = new SpriteAsset { Id = "Frame3", AssetBundleId = "Bundle2", RelativePath = "" };
            Frame4 = new SpriteAsset { Id = "Frame4", AssetBundleId = "Bundle2", RelativePath = "" };
            CheckBox = new SpriteAsset { Id = "CheckBox", IsResource = true, RelativePath = "" };
            CheckBoxPressed = new SpriteAsset { Id = "CheckBoxPressed", IsResource = true, RelativePath = "" };
            CloseButton = new SpriteAsset { Id = "CloseButton", IsResource = true, RelativePath = "" };
            ComboBoxButton = new SpriteAsset { Id = "ComboBoxButton", IsResource = true, RelativePath = "" };
            ComboBoxButtonPressed = new SpriteAsset { Id = "ComboBoxButtonPressed", IsResource = true, RelativePath = "" };
            RadioButton = new SpriteAsset { Id = "RadioButton", IsResource = true, RelativePath = "" };
            RadioButtonPressed = new SpriteAsset { Id = "RadioButtonPressed", IsResource = true, RelativePath = "" };
            RainbowSquare = new SpriteAsset { Id = "RainbowSquare", IsResource = true, RelativePath = "" };
            DesignerGrid = new SpriteAsset { Id = "DesignerGrid", IsResource = true, RelativePath = "Sprites/" };
            DesignerGrid2 = new SpriteAsset { Id = "DesignerGrid2", IsResource = true, RelativePath = "Sprites/" };
            EditorGrid = new SpriteAsset { Id = "EditorGrid", IsResource = true, RelativePath = "Sprites/" };

            Add(Frame1);
            Add(Frame2);
            Add(BigSprite);
            Add(Frame3);
            Add(Frame4);
            Add(CheckBox);
            Add(CheckBoxPressed);
            Add(CloseButton);
            Add(ComboBoxButton);
            Add(ComboBoxButtonPressed);
            Add(RadioButton);
            Add(RadioButtonPressed);
            Add(RainbowSquare);
            Add(DesignerGrid);
            Add(DesignerGrid2);
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
        public static implicit operator Texture2DAsset(UnityEngine.Texture2D unityObject)
        {
            return new Texture2DAsset { UnityObject = unityObject, IsUnmanaged = true };
        }

        public static implicit operator Texture2DAsset(string assetId)
        {
            if (String.IsNullOrEmpty(assetId))
                return null;

            return Assets.Texture2Ds[assetId];
        }
    }

    public partial class Texture2DAssetData : DataProvider<Texture2DAsset>
    {
        #region Fields

        public readonly Texture2DAsset Bluefloral01;

        #endregion

        #region Constructor

        public Texture2DAssetData()
        {
            Bluefloral01 = new Texture2DAsset { Id = "bluefloral01", AssetBundleId = "Bundle2", RelativePath = "" };

            Add(Bluefloral01);
        }

        #endregion
    }

    public static partial class Assets
    {
        public static Texture2DAssetData Texture2Ds = new Texture2DAssetData();
    }

    #endregion

    #region TMP_FontAssets

    public partial class TMP_FontAsset : AssetObject<TMPro.TMP_FontAsset>
    {
        public static implicit operator TMP_FontAsset(TMPro.TMP_FontAsset unityObject)
        {
            return new TMP_FontAsset { UnityObject = unityObject, IsUnmanaged = true };
        }

        public static implicit operator TMP_FontAsset(string assetId)
        {
            if (String.IsNullOrEmpty(assetId))
                return null;

            return Assets.TMP_FontAssets[assetId];
        }
    }

    public partial class TMP_FontAssetData : DataProvider<TMP_FontAsset>
    {
        #region Fields

        public readonly TMP_FontAsset EbrimaSDF;

        #endregion

        #region Constructor

        public TMP_FontAssetData()
        {
            EbrimaSDF = new TMP_FontAsset { Id = "Ebrima SDF", IsResource = true, RelativePath = "Fonts/" };

            Add(EbrimaSDF);
        }

        #endregion
    }

    public static partial class Assets
    {
        public static TMP_FontAssetData TMP_FontAssets = new TMP_FontAssetData();
    }

    #endregion

    #region Shaders

    public partial class ShaderAsset : AssetObject<UnityEngine.Shader>
    {
        public static implicit operator ShaderAsset(UnityEngine.Shader unityObject)
        {
            return new ShaderAsset { UnityObject = unityObject, IsUnmanaged = true };
        }

        public static implicit operator ShaderAsset(string assetId)
        {
            if (String.IsNullOrEmpty(assetId))
                return null;

            return Assets.Shaders[assetId];
        }
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
}
