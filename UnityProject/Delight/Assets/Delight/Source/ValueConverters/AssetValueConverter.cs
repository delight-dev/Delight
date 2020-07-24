#region Using Statements
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
#endregion

namespace Delight
{
    /// <summary>
    /// Asset value converter.
    /// </summary>
    public class AssetObjectValueConverter : ValueConverter
    {
        #region Constructor

        private string _assetTypeName;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public AssetObjectValueConverter(string assetTypeName)
        {
            _assetTypeName = assetTypeName;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets initializer from string value.
        /// </summary>
        public static string GetInitializer(string typeName, string stringValue)
        {
            if (String.IsNullOrEmpty(stringValue))
            {
                return "null";
            }

            return String.Format("Assets.{0}[\"{1}\"]", typeName.Pluralize(), stringValue);
        }

        /// <summary>
        /// Converts value from string.
        /// </summary>
        public override object ConvertGeneric(string stringValue)
        {
            // used for runtime conversions of strings to assets
            var collection = Assets.RuntimeAssetObject.GetPropertyValue(_assetTypeName.Pluralize()) as BindableCollection;
            return collection != null ? collection.GetGeneric(stringValue) : null;
        }

        /// <summary>
        /// Converts value from object.
        /// </summary>
        public override object ConvertGeneric(object objectValue)
        {
            if (objectValue is string)
            {
                return ConvertGeneric((string)objectValue);
            }
            return null;
        }

        #endregion
    }
}
