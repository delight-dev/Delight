#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
#endregion

namespace Delight
{
    /// <summary>
    /// Similar to the Image view but displays a Texture2D asset.
    /// </summary>
    public partial class RawImage
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
                case nameof(Color):
                    ImageChanged();
                    break;
                case nameof(Texture):
                    TextureChanged();
                    break;
            }
        }

        /// <summary>
        /// Called before the view has been loaded.
        /// </summary>
        protected override void BeforeLoad()
        {
            base.BeforeLoad();
            if (IgnoreObject)
                return;

            // always add raw image component
            if (RawImageComponent == null)
            {
                RawImageComponent = GameObject.AddComponent<UnityEngine.UI.RawImage>();
                FastMaterialChanged(); // apply fast material if specified
            }

            TextureChanged();
        }

        /// <summary>
        /// Called after the view has been loaded.
        /// </summary>
        protected override void AfterLoad()
        {
            base.AfterLoad();

            // enable to have fonts pop in instead
            if (LoadMode.HasFlag(LoadMode.HiddenWhileLoading))
            {
                if (Texture != null && !Texture.IsLoaded)
                {
                    // hide image while loading
                    RawImageComponent.enabled = false;
                }
            }
        }

        /// <summary>
        /// Called when the texture is changed. 
        /// </summary>
        protected virtual void TextureChanged()
        {
            if (GameObject == null)
                return;

            if (LoadMode.HasFlag(LoadMode.HiddenWhileLoading))
            {
                if (Texture != null && Texture.IsLoaded)
                {
                    RawImageComponent.enabled = true;
                }
            }

            // uncomment for tracking texture sets
            //var spriteInfo = Sprite == null ? "null" : String.Format("{0} (IsLoaded: {1})", Sprite.Id, Sprite.IsLoaded);
            //Debugger.Info(String.Format("{0}: Setting Sprite = {1}", Name, spriteInfo), LogCategory.Delight);

            var texture = Texture?.UnityObject;
            if (texture != null && RawImageComponent == null)
            {
                RawImageComponent = GameObject.AddComponent<UnityEngine.UI.RawImage>();
                FastMaterialChanged(); // apply fast material if specified
            }

            if (RawImageComponent != null)
            {
                RawImageComponent.texture = texture;
            }

            ImageChanged();
        }

        /// <summary>
        /// Called whenever properties affecting the image are changed. 
        /// </summary>
        public virtual void ImageChanged()
        {
            if (RawImageComponent == null)
                return;

            if (ColorProperty.IsUndefined(this))
            {
                if (RawImageComponent.texture != null)
                {
                    // use white color by default if image is set
                    RawImageComponent.color = Color.white;
                }
                else
                {
                    // use clear color by default if image isn't set
                    RawImageComponent.color = Color.clear;
                }
            }

            var texture = RawImageComponent.texture;
            if (WidthProperty.IsUndefined(this) && HeightProperty.IsUndefined(this))
            {
                // if width and height is undefined, adjust size to native size of sprite                
                if (texture != null)
                {
                    RawImageComponent.SetNativeSize();
                    OverrideWidth = ElementSize.FromPixels(RawImageComponent.rectTransform.sizeDelta.x);
                    OverrideHeight = ElementSize.FromPixels(RawImageComponent.rectTransform.sizeDelta.y);
                }
            }

            bool isLoading = Texture != null && !Texture.IsLoaded;
            if (isLoading && texture == null)
            {
                // always disable image while loading
                RawImageComponent.enabled = false;
            }
            else
            {
                // disable raycast blocks if image is transparent
                RawImageComponent.enabled = RaycastBlockMode == RaycastBlockMode.Always ? true : RawImageComponent.color.a > 0;
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

            if (RawImageComponent == null)
                return;

            RawImageComponent.material = FastMaterial?.UnityObject;
        }
        #endregion
    }
}
