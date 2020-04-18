// Internal view logic generated from "Image.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class Image : UIView
    {
        #region Constructors

        public Image(View parent, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :
            base(parent, layoutParent, id, template ?? ImageTemplates.Default, initializer)
        {
            this.AfterInitializeInternal();
        }

        public Image() : this(null)
        {
        }

        static Image()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(ImageTemplates.Default, dependencyProperties);

            dependencyProperties.Add(ImageComponentProperty);
            dependencyProperties.Add(SpriteProperty);
            dependencyProperties.Add(OverrideSpriteProperty);
            dependencyProperties.Add(TypeProperty);
            dependencyProperties.Add(PreserveAspectProperty);
            dependencyProperties.Add(FillCenterProperty);
            dependencyProperties.Add(FillMethodProperty);
            dependencyProperties.Add(FillAmountProperty);
            dependencyProperties.Add(FillClockwiseProperty);
            dependencyProperties.Add(FillOriginProperty);
            dependencyProperties.Add(AlphaHitTestMinimumThresholdProperty);
            dependencyProperties.Add(UseSpriteMeshProperty);
            dependencyProperties.Add(PixelsPerUnitMultiplierProperty);
            dependencyProperties.Add(MaterialProperty);
            dependencyProperties.Add(OnCullStateChangedProperty);
            dependencyProperties.Add(MaskableProperty);
            dependencyProperties.Add(ColorProperty);
            dependencyProperties.Add(RaycastTargetProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<UnityEngine.UI.Image> ImageComponentProperty = new DependencyProperty<UnityEngine.UI.Image>("ImageComponent");
        public UnityEngine.UI.Image ImageComponent
        {
            get { return ImageComponentProperty.GetValue(this); }
            set { ImageComponentProperty.SetValue(this, value); }
        }

        public readonly static MappedAssetDependencyProperty<SpriteAsset, UnityEngine.UI.Image, Image> SpriteProperty = new MappedAssetDependencyProperty<SpriteAsset, UnityEngine.UI.Image, Image>("Sprite", x => x.ImageComponent, (x, y) => x.sprite = y?.UnityObject);
        public SpriteAsset Sprite
        {
            get { return SpriteProperty.GetValue(this); }
            set { SpriteProperty.SetValue(this, value); }
        }

        public readonly static MappedAssetDependencyProperty<SpriteAsset, UnityEngine.UI.Image, Image> OverrideSpriteProperty = new MappedAssetDependencyProperty<SpriteAsset, UnityEngine.UI.Image, Image>("OverrideSprite", x => x.ImageComponent, (x, y) => x.overrideSprite = y?.UnityObject);
        public SpriteAsset OverrideSprite
        {
            get { return OverrideSpriteProperty.GetValue(this); }
            set { OverrideSpriteProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<UnityEngine.UI.Image.Type, UnityEngine.UI.Image, Image> TypeProperty = new MappedDependencyProperty<UnityEngine.UI.Image.Type, UnityEngine.UI.Image, Image>("Type", x => x.ImageComponent, x => x.type, (x, y) => x.type = y);
        public UnityEngine.UI.Image.Type Type
        {
            get { return TypeProperty.GetValue(this); }
            set { TypeProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Boolean, UnityEngine.UI.Image, Image> PreserveAspectProperty = new MappedDependencyProperty<System.Boolean, UnityEngine.UI.Image, Image>("PreserveAspect", x => x.ImageComponent, x => x.preserveAspect, (x, y) => x.preserveAspect = y);
        public System.Boolean PreserveAspect
        {
            get { return PreserveAspectProperty.GetValue(this); }
            set { PreserveAspectProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Boolean, UnityEngine.UI.Image, Image> FillCenterProperty = new MappedDependencyProperty<System.Boolean, UnityEngine.UI.Image, Image>("FillCenter", x => x.ImageComponent, x => x.fillCenter, (x, y) => x.fillCenter = y);
        public System.Boolean FillCenter
        {
            get { return FillCenterProperty.GetValue(this); }
            set { FillCenterProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<UnityEngine.UI.Image.FillMethod, UnityEngine.UI.Image, Image> FillMethodProperty = new MappedDependencyProperty<UnityEngine.UI.Image.FillMethod, UnityEngine.UI.Image, Image>("FillMethod", x => x.ImageComponent, x => x.fillMethod, (x, y) => x.fillMethod = y);
        public UnityEngine.UI.Image.FillMethod FillMethod
        {
            get { return FillMethodProperty.GetValue(this); }
            set { FillMethodProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Single, UnityEngine.UI.Image, Image> FillAmountProperty = new MappedDependencyProperty<System.Single, UnityEngine.UI.Image, Image>("FillAmount", x => x.ImageComponent, x => x.fillAmount, (x, y) => x.fillAmount = y);
        public System.Single FillAmount
        {
            get { return FillAmountProperty.GetValue(this); }
            set { FillAmountProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Boolean, UnityEngine.UI.Image, Image> FillClockwiseProperty = new MappedDependencyProperty<System.Boolean, UnityEngine.UI.Image, Image>("FillClockwise", x => x.ImageComponent, x => x.fillClockwise, (x, y) => x.fillClockwise = y);
        public System.Boolean FillClockwise
        {
            get { return FillClockwiseProperty.GetValue(this); }
            set { FillClockwiseProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Int32, UnityEngine.UI.Image, Image> FillOriginProperty = new MappedDependencyProperty<System.Int32, UnityEngine.UI.Image, Image>("FillOrigin", x => x.ImageComponent, x => x.fillOrigin, (x, y) => x.fillOrigin = y);
        public System.Int32 FillOrigin
        {
            get { return FillOriginProperty.GetValue(this); }
            set { FillOriginProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Single, UnityEngine.UI.Image, Image> AlphaHitTestMinimumThresholdProperty = new MappedDependencyProperty<System.Single, UnityEngine.UI.Image, Image>("AlphaHitTestMinimumThreshold", x => x.ImageComponent, x => x.alphaHitTestMinimumThreshold, (x, y) => x.alphaHitTestMinimumThreshold = y);
        public System.Single AlphaHitTestMinimumThreshold
        {
            get { return AlphaHitTestMinimumThresholdProperty.GetValue(this); }
            set { AlphaHitTestMinimumThresholdProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Boolean, UnityEngine.UI.Image, Image> UseSpriteMeshProperty = new MappedDependencyProperty<System.Boolean, UnityEngine.UI.Image, Image>("UseSpriteMesh", x => x.ImageComponent, x => x.useSpriteMesh, (x, y) => x.useSpriteMesh = y);
        public System.Boolean UseSpriteMesh
        {
            get { return UseSpriteMeshProperty.GetValue(this); }
            set { UseSpriteMeshProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Single, UnityEngine.UI.Image, Image> PixelsPerUnitMultiplierProperty = new MappedDependencyProperty<System.Single, UnityEngine.UI.Image, Image>("PixelsPerUnitMultiplier", x => x.ImageComponent, x => x.pixelsPerUnitMultiplier, (x, y) => x.pixelsPerUnitMultiplier = y);
        public System.Single PixelsPerUnitMultiplier
        {
            get { return PixelsPerUnitMultiplierProperty.GetValue(this); }
            set { PixelsPerUnitMultiplierProperty.SetValue(this, value); }
        }

        public readonly static MappedAssetDependencyProperty<MaterialAsset, UnityEngine.UI.Image, Image> MaterialProperty = new MappedAssetDependencyProperty<MaterialAsset, UnityEngine.UI.Image, Image>("Material", x => x.ImageComponent, (x, y) => x.material = y?.UnityObject);
        public MaterialAsset Material
        {
            get { return MaterialProperty.GetValue(this); }
            set { MaterialProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<UnityEngine.UI.MaskableGraphic.CullStateChangedEvent, UnityEngine.UI.Image, Image> OnCullStateChangedProperty = new MappedDependencyProperty<UnityEngine.UI.MaskableGraphic.CullStateChangedEvent, UnityEngine.UI.Image, Image>("OnCullStateChanged", x => x.ImageComponent, x => x.onCullStateChanged, (x, y) => x.onCullStateChanged = y);
        public UnityEngine.UI.MaskableGraphic.CullStateChangedEvent OnCullStateChanged
        {
            get { return OnCullStateChangedProperty.GetValue(this); }
            set { OnCullStateChangedProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Boolean, UnityEngine.UI.Image, Image> MaskableProperty = new MappedDependencyProperty<System.Boolean, UnityEngine.UI.Image, Image>("Maskable", x => x.ImageComponent, x => x.maskable, (x, y) => x.maskable = y);
        public System.Boolean Maskable
        {
            get { return MaskableProperty.GetValue(this); }
            set { MaskableProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<UnityEngine.Color, UnityEngine.UI.Image, Image> ColorProperty = new MappedDependencyProperty<UnityEngine.Color, UnityEngine.UI.Image, Image>("Color", x => x.ImageComponent, x => x.color, (x, y) => x.color = y);
        public UnityEngine.Color Color
        {
            get { return ColorProperty.GetValue(this); }
            set { ColorProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Boolean, UnityEngine.UI.Image, Image> RaycastTargetProperty = new MappedDependencyProperty<System.Boolean, UnityEngine.UI.Image, Image>("RaycastTarget", x => x.ImageComponent, x => x.raycastTarget, (x, y) => x.raycastTarget = y);
        public System.Boolean RaycastTarget
        {
            get { return RaycastTargetProperty.GetValue(this); }
            set { RaycastTargetProperty.SetValue(this, value); }
        }

        #endregion
    }

    #region Data Templates

    public static class ImageTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return Image;
            }
        }

        private static Template _image;
        public static Template Image
        {
            get
            {
#if UNITY_EDITOR
                if (_image == null || _image.CurrentVersion != Template.Version)
#else
                if (_image == null)
#endif
                {
                    _image = new Template(UIViewTemplates.UIView);
#if UNITY_EDITOR
                    _image.Name = "Image";
#endif
                }
                return _image;
            }
        }

        #endregion
    }

    #endregion
}
