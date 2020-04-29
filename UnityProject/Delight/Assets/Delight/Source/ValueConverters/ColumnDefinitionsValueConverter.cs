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
            sb.Append("new ColumnDefinitions { ");
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
                        throw new Exception("Improperly formatted ColumnDefinitions string. Supported examples: *,10,50,2* | 100[50-200], 10 | 10%,40%,50% | 100,100[10]");
                    }
                }

                sb.AppendFormat("new ColumnDefinition({0}{1})", elementSizeConverter.GetInitializer(defStr), minMaxStr);
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
            var floatValueConverter = new FloatValueConverter();
            var elementSizeConverter = new ElementSizeValueConverter();

            string[] valueList = stringValue.Split(',');
            var columnDefinitions = new ColumnDefinitions();
            float minWidth;
            float maxWidth;

            for (int i = 0; i < valueList.Count(); ++i)
            {
                minWidth = 0;
                maxWidth = float.MaxValue;

                var defStr = valueList[i];
                if (valueList[i].Contains("["))
                {
                    var minMaxList = valueList[i].Split(MinMaxDelimiterChars, StringSplitOptions.RemoveEmptyEntries);
                    defStr = minMaxList[0];

                    if (minMaxList.Length == 2)
                    {
                        minWidth = floatValueConverter.Convert(minMaxList[1]);
                    }
                    else if (minMaxList.Length == 3)
                    {
                        minWidth = floatValueConverter.Convert(minMaxList[1]);
                        maxWidth = floatValueConverter.Convert(minMaxList[2]);
                    }
                    else
                    {
                        // improperly formatted string
                        throw new Exception("Improperly formatted ColumnDefinitions string. Supported examples: *,10,50,2* | 100[50-200], 10 | 10%,40%,50% | 100,100[10]");
                    }
                }

                var columnDefinition = new ColumnDefinition(elementSizeConverter.Convert(defStr), minWidth, maxWidth);
                columnDefinitions.Add(columnDefinition);
            }

            return columnDefinitions;
        }

        /// <summary>
        /// Converts value from object.
        /// </summary>
        public override ColumnDefinitions Convert(object objectValue)
        {
            if (objectValue == null)
                return default(ColumnDefinitions);

            Type objectType = objectValue.GetType();
            if (objectType == typeof(string))
            {
                return Convert(objectValue as string);
            }
            else if (objectType == typeof(ColumnDefinitions))
            {
                return (ColumnDefinitions)objectValue;
            }

            throw new Exception(String.Format("Can't convert object of type \"{0}\" to {1}", objectType.Name, nameof(ColumnDefinitions)));
        }

        #endregion
    }
}
