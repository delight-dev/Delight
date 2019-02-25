#region Using Statements
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using UnityEngine;
using System.Text;
#endregion

namespace Delight
{
    /// <summary>
    /// RowDefinitions value converter.
    /// </summary>
    public class RowDefinitionsValueConverter : ValueConverter<RowDefinitions>
    {
        #region Methods

        /// <summary>
        /// Gets initializer from string value.
        /// </summary>
        public override string GetInitializer(string stringValue)
        {
            var elementSizeConverter = new ElementSizeValueConverter();
            var sb = new StringBuilder();

            string[] valueList = stringValue.Split(',');
            sb.Append("new RowDefinitions { ");
            for (int i = 0; i < valueList.Count(); ++i)
            {
                sb.AppendFormat("new RowDefinition({0})", elementSizeConverter.GetInitializer(valueList[i]));
                if (i < valueList.Count() - 1)
                {
                    sb.Append(", ");
                }
            }
            sb.Append("}");

            return sb.ToString();
        }

        /// <summary>
        /// Converts value from string.
        /// </summary>
        public override RowDefinitions Convert(string stringValue)
        {
            return null;
        }

        /// <summary>
        /// Converts value from object.
        /// </summary>
        public override RowDefinitions Convert(object objectValue)
        {
            return null;
        }

        #endregion
    }
}
