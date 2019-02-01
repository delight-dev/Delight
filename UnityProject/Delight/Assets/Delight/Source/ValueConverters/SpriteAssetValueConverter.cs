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
            return null;
        }

        /// <summary>
        /// Converts value from object.
        /// </summary>
        public override SpriteAsset Convert(object objectValue)
        {
            if (objectValue == null)
                return default(SpriteAsset);

            return null;
        }

        #endregion
    }
}
