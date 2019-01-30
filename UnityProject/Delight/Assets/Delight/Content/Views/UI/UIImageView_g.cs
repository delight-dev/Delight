// Internal view logic generated from "UIImageView.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class UIImageView : UIView
    {
        #region Constructors

        public UIImageView(View parent, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :
            base(parent, layoutParent, id, template ?? UIImageViewTemplates.Default, initializer)
        {
            this.AfterInitializeInternal();
        }

        public UIImageView() : this(null)
        {
        }

        static UIImageView()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(UIImageViewTemplates.Default, dependencyProperties);

            dependencyProperties.Add(ImageProperty);
            dependencyProperties.Add(BackgroundSpriteProperty);
            dependencyProperties.Add(BackgroundOverrideSpriteProperty);
            dependencyProperties.Add(BackgroundTypeProperty);
            dependencyProperties.Add(BackgroundPreserveAspectProperty);
            dependencyProperties.Add(BackgroundFillCenterProperty);
            dependencyProperties.Add(BackgroundFillMethodProperty);
            dependencyProperties.Add(BackgroundFillAmountProperty);
            dependencyProperties.Add(BackgroundFillClockwiseProperty);
            dependencyProperties.Add(BackgroundFillOriginProperty);
            dependencyProperties.Add(BackgroundAlphaHitTestMinimumThresholdProperty);
            dependencyProperties.Add(BackgroundUseSpriteMeshProperty);
            dependencyProperties.Add(BackgroundMaterialProperty);
            dependencyProperties.Add(BackgroundOnCullStateChangedProperty);
            dependencyProperties.Add(BackgroundMaskableProperty);
            dependencyProperties.Add(BackgroundColorProperty);
            dependencyProperties.Add(BackgroundRaycastTargetProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<UnityEngine.UI.Image> ImageProperty = new DependencyProperty<UnityEngine.UI.Image>("Image");
        public UnityEngine.UI.Image Image
        {
            get { return ImageProperty.GetValue(this); }
            set { ImageProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<UnityEngine.Sprite, UnityEngine.UI.Image, UIImageView> BackgroundSpriteProperty = new MappedDependencyProperty<UnityEngine.Sprite, UnityEngine.UI.Image, UIImageView>("BackgroundSprite", x => x.Image, x => x.sprite, (x, y) => x.sprite = y);
        public UnityEngine.Sprite BackgroundSprite
        {
            get { return BackgroundSpriteProperty.GetValue(this); }
            set { BackgroundSpriteProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<UnityEngine.Sprite, UnityEngine.UI.Image, UIImageView> BackgroundOverrideSpriteProperty = new MappedDependencyProperty<UnityEngine.Sprite, UnityEngine.UI.Image, UIImageView>("BackgroundOverrideSprite", x => x.Image, x => x.overrideSprite, (x, y) => x.overrideSprite = y);
        public UnityEngine.Sprite BackgroundOverrideSprite
        {
            get { return BackgroundOverrideSpriteProperty.GetValue(this); }
            set { BackgroundOverrideSpriteProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<UnityEngine.UI.Image.Type, UnityEngine.UI.Image, UIImageView> BackgroundTypeProperty = new MappedDependencyProperty<UnityEngine.UI.Image.Type, UnityEngine.UI.Image, UIImageView>("BackgroundType", x => x.Image, x => x.type, (x, y) => x.type = y);
        public UnityEngine.UI.Image.Type BackgroundType
        {
            get { return BackgroundTypeProperty.GetValue(this); }
            set { BackgroundTypeProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Boolean, UnityEngine.UI.Image, UIImageView> BackgroundPreserveAspectProperty = new MappedDependencyProperty<System.Boolean, UnityEngine.UI.Image, UIImageView>("BackgroundPreserveAspect", x => x.Image, x => x.preserveAspect, (x, y) => x.preserveAspect = y);
        public System.Boolean BackgroundPreserveAspect
        {
            get { return BackgroundPreserveAspectProperty.GetValue(this); }
            set { BackgroundPreserveAspectProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Boolean, UnityEngine.UI.Image, UIImageView> BackgroundFillCenterProperty = new MappedDependencyProperty<System.Boolean, UnityEngine.UI.Image, UIImageView>("BackgroundFillCenter", x => x.Image, x => x.fillCenter, (x, y) => x.fillCenter = y);
        public System.Boolean BackgroundFillCenter
        {
            get { return BackgroundFillCenterProperty.GetValue(this); }
            set { BackgroundFillCenterProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<UnityEngine.UI.Image.FillMethod, UnityEngine.UI.Image, UIImageView> BackgroundFillMethodProperty = new MappedDependencyProperty<UnityEngine.UI.Image.FillMethod, UnityEngine.UI.Image, UIImageView>("BackgroundFillMethod", x => x.Image, x => x.fillMethod, (x, y) => x.fillMethod = y);
        public UnityEngine.UI.Image.FillMethod BackgroundFillMethod
        {
            get { return BackgroundFillMethodProperty.GetValue(this); }
            set { BackgroundFillMethodProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Single, UnityEngine.UI.Image, UIImageView> BackgroundFillAmountProperty = new MappedDependencyProperty<System.Single, UnityEngine.UI.Image, UIImageView>("BackgroundFillAmount", x => x.Image, x => x.fillAmount, (x, y) => x.fillAmount = y);
        public System.Single BackgroundFillAmount
        {
            get { return BackgroundFillAmountProperty.GetValue(this); }
            set { BackgroundFillAmountProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Boolean, UnityEngine.UI.Image, UIImageView> BackgroundFillClockwiseProperty = new MappedDependencyProperty<System.Boolean, UnityEngine.UI.Image, UIImageView>("BackgroundFillClockwise", x => x.Image, x => x.fillClockwise, (x, y) => x.fillClockwise = y);
        public System.Boolean BackgroundFillClockwise
        {
            get { return BackgroundFillClockwiseProperty.GetValue(this); }
            set { BackgroundFillClockwiseProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Int32, UnityEngine.UI.Image, UIImageView> BackgroundFillOriginProperty = new MappedDependencyProperty<System.Int32, UnityEngine.UI.Image, UIImageView>("BackgroundFillOrigin", x => x.Image, x => x.fillOrigin, (x, y) => x.fillOrigin = y);
        public System.Int32 BackgroundFillOrigin
        {
            get { return BackgroundFillOriginProperty.GetValue(this); }
            set { BackgroundFillOriginProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Single, UnityEngine.UI.Image, UIImageView> BackgroundAlphaHitTestMinimumThresholdProperty = new MappedDependencyProperty<System.Single, UnityEngine.UI.Image, UIImageView>("BackgroundAlphaHitTestMinimumThreshold", x => x.Image, x => x.alphaHitTestMinimumThreshold, (x, y) => x.alphaHitTestMinimumThreshold = y);
        public System.Single BackgroundAlphaHitTestMinimumThreshold
        {
            get { return BackgroundAlphaHitTestMinimumThresholdProperty.GetValue(this); }
            set { BackgroundAlphaHitTestMinimumThresholdProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Boolean, UnityEngine.UI.Image, UIImageView> BackgroundUseSpriteMeshProperty = new MappedDependencyProperty<System.Boolean, UnityEngine.UI.Image, UIImageView>("BackgroundUseSpriteMesh", x => x.Image, x => x.useSpriteMesh, (x, y) => x.useSpriteMesh = y);
        public System.Boolean BackgroundUseSpriteMesh
        {
            get { return BackgroundUseSpriteMeshProperty.GetValue(this); }
            set { BackgroundUseSpriteMeshProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<UnityEngine.Material, UnityEngine.UI.Image, UIImageView> BackgroundMaterialProperty = new MappedDependencyProperty<UnityEngine.Material, UnityEngine.UI.Image, UIImageView>("BackgroundMaterial", x => x.Image, x => x.material, (x, y) => x.material = y);
        public UnityEngine.Material BackgroundMaterial
        {
            get { return BackgroundMaterialProperty.GetValue(this); }
            set { BackgroundMaterialProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<UnityEngine.UI.MaskableGraphic.CullStateChangedEvent, UnityEngine.UI.Image, UIImageView> BackgroundOnCullStateChangedProperty = new MappedDependencyProperty<UnityEngine.UI.MaskableGraphic.CullStateChangedEvent, UnityEngine.UI.Image, UIImageView>("BackgroundOnCullStateChanged", x => x.Image, x => x.onCullStateChanged, (x, y) => x.onCullStateChanged = y);
        public UnityEngine.UI.MaskableGraphic.CullStateChangedEvent BackgroundOnCullStateChanged
        {
            get { return BackgroundOnCullStateChangedProperty.GetValue(this); }
            set { BackgroundOnCullStateChangedProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Boolean, UnityEngine.UI.Image, UIImageView> BackgroundMaskableProperty = new MappedDependencyProperty<System.Boolean, UnityEngine.UI.Image, UIImageView>("BackgroundMaskable", x => x.Image, x => x.maskable, (x, y) => x.maskable = y);
        public System.Boolean BackgroundMaskable
        {
            get { return BackgroundMaskableProperty.GetValue(this); }
            set { BackgroundMaskableProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<UnityEngine.Color, UnityEngine.UI.Image, UIImageView> BackgroundColorProperty = new MappedDependencyProperty<UnityEngine.Color, UnityEngine.UI.Image, UIImageView>("BackgroundColor", x => x.Image, x => x.color, (x, y) => x.color = y);
        public UnityEngine.Color BackgroundColor
        {
            get { return BackgroundColorProperty.GetValue(this); }
            set { BackgroundColorProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Boolean, UnityEngine.UI.Image, UIImageView> BackgroundRaycastTargetProperty = new MappedDependencyProperty<System.Boolean, UnityEngine.UI.Image, UIImageView>("BackgroundRaycastTarget", x => x.Image, x => x.raycastTarget, (x, y) => x.raycastTarget = y);
        public System.Boolean BackgroundRaycastTarget
        {
            get { return BackgroundRaycastTargetProperty.GetValue(this); }
            set { BackgroundRaycastTargetProperty.SetValue(this, value); }
        }

        #endregion
    }

    #region Data Templates

    public static class UIImageViewTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return UIImageView;
            }
        }

        private static Template _uIImageView;
        public static Template UIImageView
        {
            get
            {
#if UNITY_EDITOR
                if (_uIImageView == null || _uIImageView.CurrentVersion != Template.Version)
#else
                if (_uIImageView == null)
#endif
                {
                    _uIImageView = new Template(UIViewTemplates.UIView);
                    Delight.UIImageView.BackgroundColorProperty.SetDefault(_uIImageView, new UnityEngine.Color(0f, 0f, 0f, 0f));
                }
                return _uIImageView;
            }
        }

        #endregion
    }

    #endregion
}
