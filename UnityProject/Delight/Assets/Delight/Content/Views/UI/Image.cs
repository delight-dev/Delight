#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class Image
    {
        /// <summary>
        /// Called when a property has been changed. 
        /// </summary>
        public override void OnPropertyChanged(object source, string property)
        {
            base.OnPropertyChanged(source, property);
            switch (property)
            {
                case nameof(Color): // TODO implement
                    break;
                case nameof(Sprite):
                    SpriteChanged();
                    break;
            }
        }

        protected override void BeforeLoad()
        {
            base.BeforeLoad();
            // always add image component
            if (ImageComponent == null)
            {
                ImageComponent = GameObject.AddComponent<UnityEngine.UI.Image>();
            }
        }

        /// <summary>
        /// Called when the sprite is changed. 
        /// </summary>
        protected virtual void SpriteChanged()
        {
            if (GameObject == null)
                return;

            var sprite = Sprite?.UnityObject;
            if (sprite != null && ImageComponent == null)
            {
                ImageComponent = GameObject.AddComponent<UnityEngine.UI.Image>();
            }

            if (ImageComponent != null)
            {
                ImageComponent.sprite = sprite;
                if (sprite != null && TypeProperty.IsUndefined(this))
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
            if (ImageComponent == null)
                return;

            if (ColorProperty.IsUndefined(this))
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

            if (Width == null && Height == null)
            {
                // if width and height is undefined, adjust size to native size of sprite
                var sprite = ImageComponent.overrideSprite ?? ImageComponent.sprite;
                if (sprite != null)
                {
                    ImageComponent.SetNativeSize();
                    OverrideWidth = ElementSize.FromPixels(ImageComponent.rectTransform.sizeDelta.x);
                    OverrideHeight = ElementSize.FromPixels(ImageComponent.rectTransform.sizeDelta.y);
                }
            }

            // disable raycast blocks if image is transparent
            ImageComponent.enabled = RaycastBlockMode == RaycastBlockMode.Always ? true : ImageComponent.color.a > 0;
        }
    }
}
