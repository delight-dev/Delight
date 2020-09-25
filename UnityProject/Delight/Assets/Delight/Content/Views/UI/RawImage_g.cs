// Internal view logic generated from "RawImage.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class RawImage : UIView
    {
        #region Constructors

        public RawImage(View parent, View layoutParent = null, string id = null, Template template = null, bool deferInitialization = false) :
            base(parent, layoutParent, id, template ?? RawImageTemplates.Default, deferInitialization)
        {
            if (deferInitialization)
                return;

            this.AfterInitializeInternal();
        }

        public RawImage() : this(null)
        {
        }

        static RawImage()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(RawImageTemplates.Default, dependencyProperties);

            dependencyProperties.Add(RawImageComponentProperty);
            dependencyProperties.Add(TextureProperty);
            dependencyProperties.Add(UvRectProperty);
            dependencyProperties.Add(OnCullStateChangedProperty);
            dependencyProperties.Add(MaskableProperty);
            dependencyProperties.Add(IsMaskingGraphicProperty);
            dependencyProperties.Add(ColorProperty);
            dependencyProperties.Add(RaycastTargetProperty);
            dependencyProperties.Add(MaterialProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<UnityEngine.UI.RawImage> RawImageComponentProperty = new DependencyProperty<UnityEngine.UI.RawImage>("RawImageComponent");
        public UnityEngine.UI.RawImage RawImageComponent
        {
            get { return RawImageComponentProperty.GetValue(this); }
            set { RawImageComponentProperty.SetValue(this, value); }
        }

        public readonly static MappedAssetDependencyProperty<TextureAsset, UnityEngine.UI.RawImage, RawImage> TextureProperty = new MappedAssetDependencyProperty<TextureAsset, UnityEngine.UI.RawImage, RawImage>("Texture", x => x.RawImageComponent, (x, y) => x.texture = y?.UnityObject);
        /// <summary>The texture of the view. The value is the name of the texture asset file without extension, e.g. "mytexture".</summary>
        public TextureAsset Texture
        {
            get { return TextureProperty.GetValue(this); }
            set { TextureProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<UnityEngine.Rect, UnityEngine.UI.RawImage, RawImage> UvRectProperty = new MappedDependencyProperty<UnityEngine.Rect, UnityEngine.UI.RawImage, RawImage>("UvRect", x => x.RawImageComponent, x => x.uvRect, (x, y) => x.uvRect = y);
        /// <summary>The texture coordinates.</summary>
        public UnityEngine.Rect UvRect
        {
            get { return UvRectProperty.GetValue(this); }
            set { UvRectProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<UnityEngine.UI.MaskableGraphic.CullStateChangedEvent, UnityEngine.UI.RawImage, RawImage> OnCullStateChangedProperty = new MappedDependencyProperty<UnityEngine.UI.MaskableGraphic.CullStateChangedEvent, UnityEngine.UI.RawImage, RawImage>("OnCullStateChanged", x => x.RawImageComponent, x => x.onCullStateChanged, (x, y) => x.onCullStateChanged = y);
        /// <summary>Callback called when the culling state of this graphic either becomes culled or visible.</summary>
        public UnityEngine.UI.MaskableGraphic.CullStateChangedEvent OnCullStateChanged
        {
            get { return OnCullStateChangedProperty.GetValue(this); }
            set { OnCullStateChangedProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Boolean, UnityEngine.UI.RawImage, RawImage> MaskableProperty = new MappedDependencyProperty<System.Boolean, UnityEngine.UI.RawImage, RawImage>("Maskable", x => x.RawImageComponent, x => x.maskable, (x, y) => x.maskable = y);
        /// <summary>Boolean indicating if the graphic allows masking.</summary>
        public System.Boolean Maskable
        {
            get { return MaskableProperty.GetValue(this); }
            set { MaskableProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Boolean, UnityEngine.UI.RawImage, RawImage> IsMaskingGraphicProperty = new MappedDependencyProperty<System.Boolean, UnityEngine.UI.RawImage, RawImage>("IsMaskingGraphic", x => x.RawImageComponent, x => x.isMaskingGraphic, (x, y) => x.isMaskingGraphic = y);
        /// <summary>Boolean indicating if image is a masking graphic.</summary>
        public System.Boolean IsMaskingGraphic
        {
            get { return IsMaskingGraphicProperty.GetValue(this); }
            set { IsMaskingGraphicProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<UnityEngine.Color, UnityEngine.UI.RawImage, RawImage> ColorProperty = new MappedDependencyProperty<UnityEngine.Color, UnityEngine.UI.RawImage, RawImage>("Color", x => x.RawImageComponent, x => x.color, (x, y) => x.color = y);
        /// <summary>Color of the image. Color values can be specified by name (Red, Blue, Coral, etc), hexcode (#aarrggbb or #rrggbb) or rgb/rgba value ("1.0,0.0,0.5" or "1,1,1,0.5").</summary>
        public UnityEngine.Color Color
        {
            get { return ColorProperty.GetValue(this); }
            set { ColorProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Boolean, UnityEngine.UI.RawImage, RawImage> RaycastTargetProperty = new MappedDependencyProperty<System.Boolean, UnityEngine.UI.RawImage, RawImage>("RaycastTarget", x => x.RawImageComponent, x => x.raycastTarget, (x, y) => x.raycastTarget = y);
        /// <summary>Boolean indicating if the graphic should be considered a target for raycasting.</summary>
        public System.Boolean RaycastTarget
        {
            get { return RaycastTargetProperty.GetValue(this); }
            set { RaycastTargetProperty.SetValue(this, value); }
        }

        public readonly static MappedAssetDependencyProperty<MaterialAsset, UnityEngine.UI.RawImage, RawImage> MaterialProperty = new MappedAssetDependencyProperty<MaterialAsset, UnityEngine.UI.RawImage, RawImage>("Material", x => x.RawImageComponent, (x, y) => x.material = y?.UnityObject);
        /// <summary>Material used by the image.</summary>
        public MaterialAsset Material
        {
            get { return MaterialProperty.GetValue(this); }
            set { MaterialProperty.SetValue(this, value); }
        }

        #endregion
    }

    #region Data Templates

    public static class RawImageTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return RawImage;
            }
        }

        private static Template _rawImage;
        public static Template RawImage
        {
            get
            {
#if UNITY_EDITOR
                if (_rawImage == null || _rawImage.CurrentVersion != Template.Version)
#else
                if (_rawImage == null)
#endif
                {
                    _rawImage = new Template(UIViewTemplates.UIView);
#if UNITY_EDITOR
                    _rawImage.Name = "RawImage";
                    _rawImage.LineNumber = 0;
                    _rawImage.LinePosition = 0;
#endif
                }
                return _rawImage;
            }
        }

        #endregion
    }

    #endregion
}
