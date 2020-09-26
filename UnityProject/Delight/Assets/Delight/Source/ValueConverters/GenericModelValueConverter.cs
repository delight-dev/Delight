#region Using Statements
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
#endregion

namespace Delight
{
    /// <summary>
    /// Model value converter.
    /// </summary>
    public class GenericModelValueConverter : ValueConverter<GenericModelValueConverter>
    {
        #region Fields

        private Type _modelType;
        private bool _useModelConverter;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public GenericModelValueConverter(Type modelType, bool useModelConverter = false)
        {
            _modelType = modelType;
            _useModelConverter = useModelConverter;
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

            return String.Format("Models.{0}[\"{1}\"]", typeName.Pluralize(), stringValue);
        }

        public override object ConvertGeneric(string stringValue)
        {
            try
            {
                if (_useModelConverter)
                {
                    var collection = Models.RuntimeModelObject.GetPropertyValue(_modelType.Name.Pluralize()) as BindableCollection;
                    return collection != null ? collection.GetGeneric(stringValue) : null;
                }
                else
                {
                    string dataProviderName = _modelType.Name.Pluralize();

                    var dataProvider = typeof(Models).GetField(dataProviderName).GetValue(null);
                    var getMethod = dataProvider.GetType().GetMethod("Get", new Type[] { typeof(string) });
                    var item = getMethod.Invoke(dataProvider, new object[] { stringValue });

                    return item;
                }
            } 
            catch (Exception e)
            {
                Debug.Log(String.Format("Unable to convert \"{0}\" to model of type {1}. Exception thrown: {1}", stringValue, _modelType.Name, e.ToString()));
            }
            return null;
        }

        #endregion
    }
}