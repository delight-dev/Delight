#region Using Statements
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
#endregion

namespace Delight
{
    /// <summary>
    /// Sprite asset value converter.
    /// </summary>
    public class SpriteAssetValueConverter : ValueConverter<SpriteAsset>
    {
        #region Methods

        /// <summary>
        /// Gets initializer from string value.
        /// </summary>
        public override string GetInitializer(string stringValue)
        {
            return String.Format("Assets.Sprites[\"{0}\"]", stringValue);
        }

        /// <summary>
        /// Converts value from string.
        /// </summary>
        public override SpriteAsset Convert(string stringValue)
        {
            return Assets.Sprites[stringValue];
        }

        /// <summary>
        /// Converts value from object.
        /// </summary>
        public override SpriteAsset Convert(object objectValue)
        {
            if (objectValue == null)
                return default(SpriteAsset);

            Type objectType = objectValue.GetType();
            if (objectType == typeof(string))
            {
                return Convert(objectValue as string);
            }
            else if (objectType == typeof(SpriteAsset))
            {
                return (SpriteAsset)objectValue;
            }

            throw new Exception(String.Format("Can't convert object of type \"{0}\" to {1}", objectType.Name, nameof(SpriteAsset)));
        }

        /// <summary>
        /// Interpolates value for type.
        /// </summary>
        public override SpriteAsset Interpolate(SpriteAsset from, SpriteAsset to, float weight)
        {
            return Interpolator(from, to, weight);
        }

        /// <summary>
        /// Interpolates value for type.
        /// </summary>
        public static SpriteAsset Interpolator(SpriteAsset from, SpriteAsset to, float weight)
        {
            return weight < 1f ? from : to;
        }

        #endregion
    }
}
