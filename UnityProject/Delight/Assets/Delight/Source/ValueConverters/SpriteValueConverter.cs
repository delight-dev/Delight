#region Using Statements
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
#endregion

namespace Delight
{
    /// <summary>
    /// Sprite value converter.
    /// </summary>
    public class SpriteValueConverter : ValueConverter<UnityEngine.Sprite>
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
        public override UnityEngine.Sprite Convert(string stringValue)
        {
            return null;
        }

        /// <summary>
        /// Converts value from object.
        /// </summary>
        public override UnityEngine.Sprite Convert(object objectValue)
        {
            if (objectValue == null)
                return default(UnityEngine.Sprite);

            return null;
        }

        #endregion
    }
}
