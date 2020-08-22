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

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public GenericModelValueConverter(Type modelType)
        {
            _modelType = modelType;
        }

        #endregion

        #region Methods

        public override object ConvertGeneric(string stringValue)
        {
            try
            {
                string dataProviderName = _modelType.Name.Pluralize();
                
                var dataProvider = typeof(Models).GetField(dataProviderName).GetValue(null);
                var getMethod = dataProvider.GetType().GetMethod("Get",new Type[] { typeof(string) });
                var item = getMethod.Invoke(dataProvider, new object[] { stringValue });

                return item;
            } 
            catch (Exception e)
            {
                Debug.Log(String.Format("Unable to convert \"{0}\" to model of type {1}. Exception thrown: {1}", stringValue, _modelType.Name, e.Message));
            }
            return null;
        }

        #endregion
    }
}