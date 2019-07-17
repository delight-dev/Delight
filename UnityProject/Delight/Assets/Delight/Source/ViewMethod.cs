#region Using Statements
using System;
using System.Reflection;
using UnityEngine;
#endregion

namespace Delight
{
    /// <summary>
    /// Contains information about a view method.
    /// </summary>
    public class ViewMethod : BindableObject
    {
        #region Fields

        public MethodInfo _method;
        public MethodInfo Method
        {
            get
            {
                return _method;
            }
            set
            {
                SetProperty(ref _method, value);
            }
        }

        private bool _isEnabled;
        public bool IsEnabled
        {
            get
            {
                return _isEnabled;
            }
            set
            {
                SetProperty(ref _isEnabled, value);
            }
        }

        private object _obj;

        #endregion

        #region Constructor

        public ViewMethod()
        {
            _isEnabled = true;
        }

        #endregion

        #region Method

        public object Invoke(params object[] parameters)
        {
            if (_isEnabled)
            {
                return _method?.Invoke(_obj, parameters);
            }
            return null;
        }

        public void RegisterMethod(object obj, string methodName)
        {
            // look for a method with the same name as the entry
            var parentType = obj.GetType();
            var method = parentType.GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (method == null)
            {
                Debug.LogError(String.Format("#Delight# {0}: Unable to initialize view method \"{1}()\". View method not found in view \"{2}\".", GetType().Name, methodName, parentType.Name));
                return;
            }

            _method = method;
            _obj = obj;
        }

        #endregion
    }
}
