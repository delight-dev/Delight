#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    /// <summary>
    /// Base class for views that has a background sprite and color. 
    /// </summary>
    public partial class UIImageView : UIView
    {
        #region Methods

        /// <summary>
        /// Called when a property has been changed. 
        /// </summary>
        public override void OnChanged(string property)
        {
            base.OnChanged(property);
            switch (property)
            {
                case nameof(BackgroundColor):
                    ImageChanged();
                    break;
                case nameof(BackgroundSprite):
                    SpriteChanged();
                    break;
            }
        }

        /// <summary>
        /// Called just before the view and its children are loaded.
        /// </summary>
        protected override void BeforeLoad()
        {
            if (IgnoreObject)
                return;

            base.BeforeLoad();

            if (ImageComponent == null)
            {
                // check if image color or sprite has binding
                if (BackgroundColorProperty.HasBinding(this) || BackgroundSpriteProperty.HasBinding(this) || BackgroundSprite != null)
                {
                    ImageComponent = GameObject.AddComponent<UnityEngine.UI.Image>();
                    FastMaterialChanged(); // apply fast material if specified
                }
            }

            SpriteChanged();
        }

        /// <summary>
        /// Called when the sprite is changed. 
        /// </summary>
        protected virtual void SpriteChanged()
        {
            if (IgnoreObject || GameObject == null)
                return;

            var sprite = BackgroundSprite?.UnityObject;
            if (sprite != null && ImageComponent == null)
            {
                ImageComponent = GameObject.AddComponent<UnityEngine.UI.Image>();
                FastMaterialChanged(); // apply fast material if specified
            }

            if (ImageComponent != null)
            {
                ImageComponent.sprite = sprite;
                if (sprite != null && BackgroundTypeProperty.IsUndefined(this))
                {
                    // if type is undefined auto-detect if sprite is sliced
                    if (sprite.border != Vector4.zero)
                    {
                        ImageComponent.type = UnityEngine.UI.Image.Type.Sliced;
                    }
                }
            }

            ImageChanged();
        }

        /// <summary>
        /// Called whenever properties affecting the image are changed. 
        /// </summary>
        public virtual void ImageChanged()
        {
            if (IgnoreObject)
                return;

            if (ImageComponent == null)
            {
                // add image component if background color is defined
                if (BackgroundColorProperty.IsUndefined(this, true))
                    return;
                
                ImageComponent = GameObject.AddComponent<UnityEngine.UI.Image>();
            }

            if (BackgroundColorProperty.IsUndefined(this))
            {
                if (ImageComponent.sprite != null || ImageComponent.overrideSprite != null)
                {
                    // use white color by default if image is set
                    ImageComponent.color = Color.white;
                }
                else
                {
                    // use clear color by default if image isn't set
                    ImageComponent.color = Color.clear;
                }
            }

            var sprite = ImageComponent.overrideSprite ?? ImageComponent.sprite;
            if (Width == null && Height == null)
            {
                // if width and height is undefined, adjust size to native size of sprite                
                if (sprite != null)
                {
                    ImageComponent.SetNativeSize();
                    OverrideWidth = ElementSize.FromPixels(ImageComponent.rectTransform.sizeDelta.x);
                    OverrideHeight = ElementSize.FromPixels(ImageComponent.rectTransform.sizeDelta.y);
                }
            }

            bool isLoading = BackgroundSprite != null && !BackgroundSprite.IsLoaded;
            if (isLoading && sprite == null)
            {
                // always disable image while loading if current sprite isn't set
                ImageComponent.enabled = false;
            }
            else
            {
                // disable raycast blocks if image is transparent
                ImageComponent.enabled = RaycastBlockMode == RaycastBlockMode.Always ? true : ImageComponent.color.a > 0;
            }
        }

        /// <summary>
        /// Returns boolean indicating if background is visible.
        /// </summary>
        private bool BackgroundIsVisible()
        {
            if (BackgroundColorProperty.IsUndefined(this))
                return false;

            if (BackgroundColor.a <= 0)
                return false;

            if (!AlphaProperty.IsUndefined(this) && Alpha <= 0)
                return false;

            return IsVisible;
        }

        /// <summary>
        /// Called whenever the UI fast default material has been loaded/changed.
        /// </summary>
        protected override void FastMaterialChanged()
        {
            base.FastMaterialChanged();
            if (!UseFastShader)
                return;

            if (ImageComponent == null)
                return;

            ImageComponent.material = FastMaterial?.UnityObject;
        }

        #endregion
    }
}
