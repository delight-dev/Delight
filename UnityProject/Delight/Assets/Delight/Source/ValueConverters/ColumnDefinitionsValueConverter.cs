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
    /// ColumnDefinitions value converter.
    /// </summary>
    public class ColumnDefinitionsValueConverter : ValueConverter<ColumnDefinitions>
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
            sb.Append("new ColumnDefinitions { ");
            for (int i = 0; i < valueList.Count(); ++i)
            {
                sb.AppendFormat("new ColumnDefinition({0})", elementSizeConverter.GetInitializer(valueList[i]));
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
        public override ColumnDefinitions Convert(string stringValue)
        {
            return null;
        }

        /// <summary>
        /// Converts value from object.
        /// </summary>
        public override ColumnDefinitions Convert(object objectValue)
        {
            return null;
        }

        #endregion
    }
}
