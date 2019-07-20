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
        #region Fields

        private static readonly char[] MinMaxDelimiterChars = { ' ', '[', ']', '-' };

        #endregion

        #region Methods

        /// <summary>
        /// Gets initializer from string value.
        /// </summary>
        public override string GetInitializer(string stringValue)
        {
            var floatValueConverter = new FloatValueConverter();
            var elementSizeConverter = new ElementSizeValueConverter();
            var sb = new StringBuilder();

            string[] valueList = stringValue.Split(',');
            sb.Append("new RowDefinitions { ");
            for (int i = 0; i < valueList.Count(); ++i)
            {
                var defStr = valueList[i];
                string minMaxStr = string.Empty;
                if (valueList[i].Contains("["))
                {
                    var minMaxList = valueList[i].Split(MinMaxDelimiterChars, StringSplitOptions.RemoveEmptyEntries);
                    defStr = minMaxList[0];

                    if (minMaxList.Length == 2)
                    {
                        minMaxStr = String.Format(", {0}", floatValueConverter.GetInitializer(minMaxList[1]));
                    }
                    else if (minMaxList.Length == 3)
                    {
                        minMaxStr = String.Format(", {0}, {1}", floatValueConverter.GetInitializer(minMaxList[1]),
                            floatValueConverter.GetInitializer(minMaxList[2]));
                    }
                    else
                    {
                        // improperly formatted string
                        throw new Exception("Improperly formatted RowDefinitions string. Supported examples: *,10,50,2* | 100[50-200], 10 | 10%,40%,50% | 100,100[10]");
                    }
                }

                sb.AppendFormat("new RowDefinition({0}{1})", elementSizeConverter.GetInitializer(defStr), minMaxStr);
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
