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
            }
        }

        // 1. whenever the sprite asset changes or on load we want to 
        //    1.1. unregister listeners to old sprite asset
        //    1.2. register listeners to new sprite asset
        //    1.3. initiate load of sprite object
        //    1.4. in the callback map value to our ImageComponent.sprite
        // 2. whenever we unload the view
        //    2.1. unregister listeners to sprite asset
        // find a nice construct to automate these operations

        protected override void AfterLoad()
        {
            base.AfterLoad();

            RegisterAssetListeners();
        }

        protected override void AfterUnload()
        {
            base.AfterUnload();

            UnregisterAssetListeners();
        }

        public virtual void UnregisterAssetListeners()
        {
            if (Sprite != null) Sprite.PropertyChanged -= SpritePropertyChanged;
        }

        public virtual void RegisterAssetListeners()
        {
            if (Sprite != null)
            {
                Sprite.PropertyChanged -= SpritePropertyChanged;
                Sprite.PropertyChanged += SpritePropertyChanged;

                if (Sprite.UnityObject == null)
                {
                    Sprite.LoadAsync();
                }
                else
                {
                    SpritePropertyChanged(Sprite, nameof(Sprite.UnityObject));
                }
            }
        }

        protected virtual void SpritePropertyChanged(object source, string propertyName)
        {
            if (propertyName != "UnityObject") return;
            if (ImageComponent == null)
            {
                ImageComponent = GameObject.AddComponent<UnityEngine.UI.Image>();
            }

            var sprite = Sprite.UnityObject;
            ImageComponent.sprite = sprite;
            if (sprite != null && TypeProperty.IsUndefined(this))
            {
                // if type is undefined auto-detect if sprite is sliced
                if (sprite.border != Vector4.zero)
                {
                    ImageComponent.type = UnityEngine.UI.Image.Type.Sliced;
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

        // TODO experminental code, remove
        public void RegisterAssetListener<T>(AssetObject<T> assetObject) where T : UnityEngine.Object
        {
            if (assetObject != null)
            {
                assetObject.PropertyChanged -= AssetObjectPropertyChanged;
                assetObject.PropertyChanged += AssetObjectPropertyChanged;

                if (assetObject.UnityObject != null)
                {
                    // trigger property changed
                    AssetObjectPropertyChanged(assetObject, nameof(AssetObject<T>.UnityObject));
                }
            }
        }

        private void AssetObjectPropertyChanged(object source, string propertyName)
        {
        }
    }
}
