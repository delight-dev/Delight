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

    /// <summary>
    /// AssetBundle data provider. Contains references to all asset bundles in the project.
    /// </summary>
    public partial class AssetBundleData : DataProvider<AssetBundle>
    {
        #region Fields

        public readonly AssetBundle Bundle1;
        public readonly AssetBundle Bundle2;

        #endregion

        #region Constructor

        public AssetBundleData()
        {
            Bundle1 = new AssetBundle { Id = "Bundle1", StorageMode = StorageMode.Remote };
            Bundle2 = new AssetBundle { Id = "Bundle2", StorageMode = StorageMode.Remote };

            Add(Bundle1);
            Add(Bundle2);
        }

        #endregion
    }

    #endregion

    #region Materials

    /// <summary>
    /// Manages a UnityEngine.Material object. Loads/unloads the asset on-demand as it's requested by views.
    /// </summary>
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

            if (assetId.StartsWith("?"))
                assetId = assetId.Substring(1);

            return Assets.Materials[assetId];
        }
    }

    /// <summary>
    /// MaterialAsset data provider. Contains references to all materials in the project.
    /// </summary>
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

    /// <summary>
    /// Manages a UnityEngine.Font object. Loads/unloads the asset on-demand as it's requested by views.
    /// </summary>
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

            if (assetId.StartsWith("?"))
                assetId = assetId.Substring(1);

            return Assets.Fonts[assetId];
        }
    }

    /// <summary>
    /// FontAsset data provider. Contains references to all fonts in the project.
    /// </summary>
    public partial class FontAssetData : DataProvider<FontAsset>
    {
        #region Fields

        public readonly FontAsset Ebrima;
        public readonly FontAsset InconsolataRegular;
        public readonly FontAsset SegoeUI;

        #endregion

        #region Constructor

        public FontAssetData()
        {
            Ebrima = new FontAsset { Id = "Ebrima", IsResource = true, RelativePath = "Fonts/" };
            InconsolataRegular = new FontAsset { Id = "Inconsolata-Regular", IsResource = true, RelativePath = "Fonts/" };
            SegoeUI = new FontAsset { Id = "Segoe UI", IsResource = true, RelativePath = "Fonts/" };

            Add(Ebrima);
            Add(InconsolataRegular);
            Add(SegoeUI);
        }

        #endregion
    }

    public static partial class Assets
    {
        public static FontAssetData Fonts = new FontAssetData();
    }

    #endregion

    #region Sprites

    /// <summary>
    /// Manages a UnityEngine.Sprite object. Loads/unloads the asset on-demand as it's requested by views.
    /// </summary>
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

            if (assetId.StartsWith("?"))
                assetId = assetId.Substring(1);

            return Assets.Sprites[assetId];
        }
    }

    /// <summary>
    /// SpriteAsset data provider. Contains references to all sprites in the project.
    /// </summary>
    public partial class SpriteAssetData : DataProvider<SpriteAsset>
    {
        #region Fields

        public readonly SpriteAsset CheckBox;
        public readonly SpriteAsset CheckBoxPressed;
        public readonly SpriteAsset CloseButton;
        public readonly SpriteAsset ComboBoxButton;
        public readonly SpriteAsset ComboBoxButtonPressed;
        public readonly SpriteAsset Delighticon;
        public readonly SpriteAsset DesignerGrid;
        public readonly SpriteAsset DesignerGrid2;
        public readonly SpriteAsset EditorGrid;
        public readonly SpriteAsset ListSelection;
        public readonly SpriteAsset RadioButton;
        public readonly SpriteAsset RadioButtonPressed;
        public readonly SpriteAsset RainbowSquare;
        public readonly SpriteAsset Selection;
        public readonly SpriteAsset TooltipArrow;
        public readonly SpriteAsset Frame1;
        public readonly SpriteAsset Frame2;
        public readonly SpriteAsset BigSprite;
        public readonly SpriteAsset Frame3;
        public readonly SpriteAsset Frame4;

        #endregion

        #region Constructor

        public SpriteAssetData()
        {
            CheckBox = new SpriteAsset { Id = "CheckBox", IsResource = true, RelativePath = "Sprites/" };
            CheckBoxPressed = new SpriteAsset { Id = "CheckBoxPressed", IsResource = true, RelativePath = "Sprites/" };
            CloseButton = new SpriteAsset { Id = "CloseButton", IsResource = true, RelativePath = "Sprites/" };
            ComboBoxButton = new SpriteAsset { Id = "ComboBoxButton", IsResource = true, RelativePath = "Sprites/" };
            ComboBoxButtonPressed = new SpriteAsset { Id = "ComboBoxButtonPressed", IsResource = true, RelativePath = "Sprites/" };
            Delighticon = new SpriteAsset { Id = "delight-icon", IsResource = true, RelativePath = "Sprites/" };
            DesignerGrid = new SpriteAsset { Id = "DesignerGrid", IsResource = true, RelativePath = "Sprites/" };
            DesignerGrid2 = new SpriteAsset { Id = "DesignerGrid2", IsResource = true, RelativePath = "Sprites/" };
            EditorGrid = new SpriteAsset { Id = "EditorGrid", IsResource = true, RelativePath = "Sprites/" };
            ListSelection = new SpriteAsset { Id = "ListSelection", IsResource = true, RelativePath = "Sprites/" };
            RadioButton = new SpriteAsset { Id = "RadioButton", IsResource = true, RelativePath = "Sprites/" };
            RadioButtonPressed = new SpriteAsset { Id = "RadioButtonPressed", IsResource = true, RelativePath = "Sprites/" };
            RainbowSquare = new SpriteAsset { Id = "RainbowSquare", IsResource = true, RelativePath = "Sprites/" };
            Selection = new SpriteAsset { Id = "Selection", IsResource = true, RelativePath = "Sprites/" };
            TooltipArrow = new SpriteAsset { Id = "TooltipArrow", IsResource = true, RelativePath = "Sprites/" };
            Frame1 = new SpriteAsset { Id = "Frame1", AssetBundleId = "Bundle1", RelativePath = "Sprites/" };
            Frame2 = new SpriteAsset { Id = "Frame2", AssetBundleId = "Bundle1", RelativePath = "Sprites/" };
            BigSprite = new SpriteAsset { Id = "BigSprite", AssetBundleId = "Bundle2", RelativePath = "" };
            Frame3 = new SpriteAsset { Id = "Frame3", AssetBundleId = "Bundle2", RelativePath = "" };
            Frame4 = new SpriteAsset { Id = "Frame4", AssetBundleId = "Bundle2", RelativePath = "" };

            Add(CheckBox);
            Add(CheckBoxPressed);
            Add(CloseButton);
            Add(ComboBoxButton);
            Add(ComboBoxButtonPressed);
            Add(Delighticon);
            Add(DesignerGrid);
            Add(DesignerGrid2);
            Add(EditorGrid);
            Add(ListSelection);
            Add(RadioButton);
            Add(RadioButtonPressed);
            Add(RainbowSquare);
            Add(Selection);
            Add(TooltipArrow);
            Add(Frame1);
            Add(Frame2);
            Add(BigSprite);
            Add(Frame3);
            Add(Frame4);
        }

        #endregion
    }

    public static partial class Assets
    {
        public static SpriteAssetData Sprites = new SpriteAssetData();
    }

    #endregion

    #region TMP_FontAssets

    /// <summary>
    /// Manages a TMPro.TMP_FontAsset object. Loads/unloads the asset on-demand as it's requested by views.
    /// </summary>
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

            if (assetId.StartsWith("?"))
                assetId = assetId.Substring(1);

            return Assets.TMP_FontAssets[assetId];
        }
    }

    /// <summary>
    /// TMP_FontAsset data provider. Contains references to all tmp_fontassets in the project.
    /// </summary>
    public partial class TMP_FontAssetData : DataProvider<TMP_FontAsset>
    {
        #region Fields

        public readonly TMP_FontAsset EbrimaSDF;
        public readonly TMP_FontAsset InconsolataRegularSDF;
        public readonly TMP_FontAsset SegoeUISDF;

        #endregion

        #region Constructor

        public TMP_FontAssetData()
        {
            EbrimaSDF = new TMP_FontAsset { Id = "Ebrima SDF", IsResource = true, RelativePath = "Fonts/" };
            InconsolataRegularSDF = new TMP_FontAsset { Id = "Inconsolata-Regular SDF", IsResource = true, RelativePath = "Fonts/" };
            SegoeUISDF = new TMP_FontAsset { Id = "Segoe UI SDF", IsResource = true, RelativePath = "Fonts/" };

            Add(EbrimaSDF);
            Add(InconsolataRegularSDF);
            Add(SegoeUISDF);
        }

        #endregion
    }

    public static partial class Assets
    {
        public static TMP_FontAssetData TMP_FontAssets = new TMP_FontAssetData();
    }

    #endregion

    #region Shaders

    /// <summary>
    /// Manages a UnityEngine.Shader object. Loads/unloads the asset on-demand as it's requested by views.
    /// </summary>
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

            if (assetId.StartsWith("?"))
                assetId = assetId.Substring(1);

            return Assets.Shaders[assetId];
        }
    }

    /// <summary>
    /// ShaderAsset data provider. Contains references to all shaders in the project.
    /// </summary>
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

    #region Texture2Ds

    /// <summary>
    /// Manages a UnityEngine.Texture2D object. Loads/unloads the asset on-demand as it's requested by views.
    /// </summary>
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

            if (assetId.StartsWith("?"))
                assetId = assetId.Substring(1);

            return Assets.Texture2Ds[assetId];
        }
    }

    /// <summary>
    /// Texture2DAsset data provider. Contains references to all texture2ds in the project.
    /// </summary>
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

    #region TMP_ColorGradients

    /// <summary>
    /// Manages a TMPro.TMP_ColorGradient object. Loads/unloads the asset on-demand as it's requested by views.
    /// </summary>
    public partial class TMP_ColorGradientAsset : AssetObject<TMPro.TMP_ColorGradient>
    {
        public static implicit operator TMP_ColorGradientAsset(TMPro.TMP_ColorGradient unityObject)
        {
            return new TMP_ColorGradientAsset { UnityObject = unityObject, IsUnmanaged = true };
        }

        public static implicit operator TMP_ColorGradientAsset(string assetId)
        {
            if (String.IsNullOrEmpty(assetId))
                return null;

            if (assetId.StartsWith("?"))
                assetId = assetId.Substring(1);

            return Assets.TMP_ColorGradients[assetId];
        }
    }

    /// <summary>
    /// TMP_ColorGradientAsset data provider. Contains references to all tmp_colorgradients in the project.
    /// </summary>
    public partial class TMP_ColorGradientAssetData : DataProvider<TMP_ColorGradientAsset>
    {
    }

    public static partial class Assets
    {
        public static TMP_ColorGradientAssetData TMP_ColorGradients = new TMP_ColorGradientAssetData();
    }

    #endregion

    #region TMP_SpriteAssets

    /// <summary>
    /// Manages a TMPro.TMP_SpriteAsset object. Loads/unloads the asset on-demand as it's requested by views.
    /// </summary>
    public partial class TMP_SpriteAsset : AssetObject<TMPro.TMP_SpriteAsset>
    {
        public static implicit operator TMP_SpriteAsset(TMPro.TMP_SpriteAsset unityObject)
        {
            return new TMP_SpriteAsset { UnityObject = unityObject, IsUnmanaged = true };
        }

        public static implicit operator TMP_SpriteAsset(string assetId)
        {
            if (String.IsNullOrEmpty(assetId))
                return null;

            if (assetId.StartsWith("?"))
                assetId = assetId.Substring(1);

            return Assets.TMP_SpriteAssets[assetId];
        }
    }

    /// <summary>
    /// TMP_SpriteAsset data provider. Contains references to all tmp_spriteassets in the project.
    /// </summary>
    public partial class TMP_SpriteAssetData : DataProvider<TMP_SpriteAsset>
    {
    }

    public static partial class Assets
    {
        public static TMP_SpriteAssetData TMP_SpriteAssets = new TMP_SpriteAssetData();
    }

    #endregion

    #region Textures

    /// <summary>
    /// Manages a UnityEngine.Texture object. Loads/unloads the asset on-demand as it's requested by views.
    /// </summary>
    public partial class TextureAsset : AssetObject<UnityEngine.Texture>
    {
        public static implicit operator TextureAsset(UnityEngine.Texture unityObject)
        {
            return new TextureAsset { UnityObject = unityObject, IsUnmanaged = true };
        }

        public static implicit operator TextureAsset(string assetId)
        {
            if (String.IsNullOrEmpty(assetId))
                return null;

            if (assetId.StartsWith("?"))
                assetId = assetId.Substring(1);

            return Assets.Textures[assetId];
        }
    }

    /// <summary>
    /// TextureAsset data provider. Contains references to all textures in the project.
    /// </summary>
    public partial class TextureAssetData : DataProvider<TextureAsset>
    {
    }

    public static partial class Assets
    {
        public static TextureAssetData Textures = new TextureAssetData();
    }

    #endregion

    #region TMP_InputValidators

    /// <summary>
    /// Manages a TMPro.TMP_InputValidator object. Loads/unloads the asset on-demand as it's requested by views.
    /// </summary>
    public partial class TMP_InputValidatorAsset : AssetObject<TMPro.TMP_InputValidator>
    {
        public static implicit operator TMP_InputValidatorAsset(TMPro.TMP_InputValidator unityObject)
        {
            return new TMP_InputValidatorAsset { UnityObject = unityObject, IsUnmanaged = true };
        }

        public static implicit operator TMP_InputValidatorAsset(string assetId)
        {
            if (String.IsNullOrEmpty(assetId))
                return null;

            if (assetId.StartsWith("?"))
                assetId = assetId.Substring(1);

            return Assets.TMP_InputValidators[assetId];
        }
    }

    /// <summary>
    /// TMP_InputValidatorAsset data provider. Contains references to all tmp_inputvalidators in the project.
    /// </summary>
    public partial class TMP_InputValidatorAssetData : DataProvider<TMP_InputValidatorAsset>
    {
    }

    public static partial class Assets
    {
        public static TMP_InputValidatorAssetData TMP_InputValidators = new TMP_InputValidatorAssetData();
    }

    #endregion
}
