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
            var floatValueConverter = new FloatValueConverter();
            var elementSizeConverter = new ElementSizeValueConverter();

            string[] valueList = stringValue.Split(',');
            var rowDefinitions = new RowDefinitions();
            float minHeight;
            float maxHeight; 

            for (int i = 0; i < valueList.Count(); ++i)
            {
                minHeight = 0;
                maxHeight = float.MaxValue;

                var defStr = valueList[i];
                if (valueList[i].Contains("["))
                {
                    var minMaxList = valueList[i].Split(MinMaxDelimiterChars, StringSplitOptions.RemoveEmptyEntries);
                    defStr = minMaxList[0];

                    if (minMaxList.Length == 2)
                    {
                        minHeight = floatValueConverter.Convert(minMaxList[1]);
                    }
                    else if (minMaxList.Length == 3)
                    {
                        minHeight = floatValueConverter.Convert(minMaxList[1]);
                        maxHeight = floatValueConverter.Convert(minMaxList[2]);
                    }
                    else
                    {
                        // improperly formatted string
                        throw new Exception("Improperly formatted RowDefinitions string. Supported examples: *,10,50,2* | 100[50-200], 10 | 10%,40%,50% | 100,100[10]");
                    }
                }

                var rowDefinition = new RowDefinition(elementSizeConverter.Convert(defStr), minHeight, maxHeight);
                rowDefinitions.Add(rowDefinition);
            }

            return rowDefinitions;
        }

        /// <summary>
        /// Converts value from object.
        /// </summary>
        public override RowDefinitions Convert(object objectValue)
        {
            if (objectValue == null)
                return default(RowDefinitions);

            Type objectType = objectValue.GetType();
            if (objectType == typeof(string))
            {
                return Convert(objectValue as string);
            }
            else if (objectType == typeof(RowDefinitions))
            {
                return (RowDefinitions)objectValue;
            }

            throw new Exception(String.Format("Can't convert object of type \"{0}\" to {1}", objectType.Name, nameof(RowDefinitions)));
        }

        #endregion
    }
}
