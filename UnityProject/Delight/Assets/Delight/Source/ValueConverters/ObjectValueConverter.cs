using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Delight
{
    /// <summary>
    /// Object value converter.
    /// </summary>
    public class ObjectValueConverter : ValueConverter<object>
    {
        #region Methods

        public override string GetInitializer(string stringValue)
        {
            return "\"" + stringValue + "\"";
        }

        public override object Convert(object objectValue)
        {
            return objectValue?.ToString();
        }

        #endregion
    }

}
