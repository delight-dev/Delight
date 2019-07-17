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
    /// <summary>
    /// View that displays an image sprite. Based on the UGUI ImageComponent. Adjusts its size and image type (spliced, etc) to the native sprite if not explicitly set.
    /// </summary>
    public partial class Image
    {
        /// <summary>
        /// Called when a property has been changed. 
        /// </summary>
        public override void OnChanged(string property)
        {
            base.OnChanged(property);
            switch (property)
            {
                case nameof(Color):
                    ImageChanged();
                    break;
                case nameof(Sprite):
                    SpriteChanged();
                    break;
            }
        }

        protected override void BeforeLoad()
        {
            base.BeforeLoad();
            if (IgnoreObject)
                return;

            // always add image component
            if (ImageComponent == null)
            {
                ImageComponent = GameObject.AddComponent<UnityEngine.UI.Image>();
                FastMaterialChanged(); // apply fast material if specified
            }

            SpriteChanged();
        }

        protected override void AfterLoad()
        {
            base.AfterLoad();

            // enable to have fonts pop in instead
            if (LoadMode.HasFlag(LoadMode.HiddenWhileLoading))
            {
                if (Sprite != null && !Sprite.IsLoaded)
                {
                    // hide image while loading
                    ImageComponent.enabled = false;
                }
            }
        }

        /// <summary>
        /// Called when the sprite is changed. 
        /// </summary>
        protected virtual void SpriteChanged()
        {
            if (GameObject == null)
                return;

            if (LoadMode.HasFlag(LoadMode.HiddenWhileLoading))
            {
                if (Sprite != null && Sprite.IsLoaded)
                {
                    ImageComponent.enabled = true;
                }
            }

            // uncomment for tracking sprite sets
            //var spriteInfo = Sprite == null ? "null" : String.Format("{0} (IsLoaded: {1})", Sprite.Id, Sprite.IsLoaded);
            //Debugger.Info(String.Format("{0}: Setting Sprite = {1}", Name, spriteInfo), LogCategory.Delight);

            var sprite = Sprite?.UnityObject;
            if (sprite != null && ImageComponent == null)
            {
                ImageComponent = GameObject.AddComponent<UnityEngine.UI.Image>();
                FastMaterialChanged(); // apply fast material if specified
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

            var sprite = ImageComponent.overrideSprite ?? ImageComponent.sprite;
            if (WidthProperty.IsUndefined(this) && HeightProperty.IsUndefined(this))
            {
                // if width and height is undefined, adjust size to native size of sprite                
                if (sprite != null)
                {
                    ImageComponent.SetNativeSize();
                    OverrideWidth = ElementSize.FromPixels(ImageComponent.rectTransform.sizeDelta.x);
                    OverrideHeight = ElementSize.FromPixels(ImageComponent.rectTransform.sizeDelta.y);
                }
            }

            bool isLoading = Sprite != null && !Sprite.IsLoaded;
            if (isLoading && sprite == null)
            {
                // always disable image while loading
                ImageComponent.enabled = false;
            }
            else
            {
                // disable raycast blocks if image is transparent
                ImageComponent.enabled = RaycastBlockMode == RaycastBlockMode.Always ? true : ImageComponent.color.a > 0;
            }
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
    }
}
