#region Using Statements
using System;
using System.Reflection;
using UnityEngine;
#endregion

namespace Delight
{
    /// <summary>
    /// A view action keeps a list of action handlers and allows for easy enabling / disabling invoking them when the action is triggered.
    /// </summary>
    public class ViewAction : BindableObject
    {
        #region Fields

        public delegate void ViewActionDelegate(DependencyObject sender, object eventArgs);

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

        public ViewActionDelegate _action;
        public ViewActionDelegate Action
        {
            get
            {
                return _action;
            }
            set
            {
                SetProperty(ref _action, value);
            }
        }

        #endregion

        #region Constructor

        public ViewAction()
        {
            _isEnabled = true;
        }

        #endregion

        #region Method

        public void Invoke(DependencyObject sender, object eventArgs)
        {
            if (_isEnabled)
            {
                _action?.Invoke(sender, eventArgs);
            }
        }
                
        public void RegisterHandler(View parent, string actionHandlerName, params Func<object>[] paramGetters)
        {
            RegisterHandler(ResolveActionHandler(parent, actionHandlerName, paramGetters));
        }

        public void RegisterHandler(ViewActionDelegate viewAction)
        {
            _action -= viewAction;
            _action += viewAction;
        }

        public void UnregisterHandler(ViewActionDelegate viewAction)
        {
            _action -= viewAction;
        }

        /// <summary>
        /// Resolves action handler from name. 
        /// </summary>
        private ViewActionDelegate ResolveActionHandler(object obj, string actionHandlerName, params Func<object>[] paramGetters)
        {
            // look for a method with the same name as the entry
            var parentType = obj.GetType();
            var actionHandler = parentType.GetMethod(actionHandlerName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (actionHandler == null)
            {
                Debug.LogError(String.Format("#Delight# {0}: Unable to initialize view action handler \"{1}()\". View action handler not found in view \"{2}\".", GetType().Name, actionHandlerName, parentType.Name));
                return (x, y) => { };
            }

            ParameterInfo[] viewActionMethodParameters = actionHandler.GetParameters();
            int parameterCount = viewActionMethodParameters.Length;
            if (parameterCount <= 0)
            {
                return (x, y) => actionHandler.Invoke(obj, null);
            }

            if (paramGetters.Length > 0)
            {
                // check if first parameter is a reference to the sender or view action
                if (typeof(View).IsAssignableFrom(viewActionMethodParameters[0].ParameterType))
                {
                    switch (paramGetters.Length)
                    {
                        case 1:
                            return (x, y) => actionHandler.Invoke(obj, new object[] { x, paramGetters[0]() });
                        case 2:
                            return (x, y) => actionHandler.Invoke(obj, new object[] { x, paramGetters[0](), paramGetters[1]() });
                        case 3:
                            return (x, y) => actionHandler.Invoke(obj, new object[] { x, paramGetters[0](), paramGetters[1](), paramGetters[2]() });
                        case 4:
                            return (x, y) => actionHandler.Invoke(obj, new object[] { x, paramGetters[0](), paramGetters[1](), paramGetters[2](), paramGetters[3]() });
                        case 5:
                            return (x, y) => actionHandler.Invoke(obj, new object[] { x, paramGetters[0](), paramGetters[1](), paramGetters[2](), paramGetters[3](), paramGetters[4]() });
                        case 6:
                            return (x, y) => actionHandler.Invoke(obj, new object[] { x, paramGetters[0](), paramGetters[1](), paramGetters[2](), paramGetters[3](), paramGetters[4](), paramGetters[5]() });
                        case 7:
                            return (x, y) => actionHandler.Invoke(obj, new object[] { x, paramGetters[0](), paramGetters[1](), paramGetters[2](), paramGetters[3](), paramGetters[4](), paramGetters[5](), paramGetters[6]() });
                        case 8:
                            return (x, y) => actionHandler.Invoke(obj, new object[] { x, paramGetters[0](), paramGetters[1](), paramGetters[2](), paramGetters[3](), paramGetters[4](), paramGetters[5](), paramGetters[6](), paramGetters[7]() });
                        case 9:
                            return (x, y) => actionHandler.Invoke(obj, new object[] { x, paramGetters[0](), paramGetters[1](), paramGetters[2](), paramGetters[3](), paramGetters[4](), paramGetters[5](), paramGetters[6](), paramGetters[7](), paramGetters[8]() });
                        case 10:
                            return (x, y) => actionHandler.Invoke(obj, new object[] { x, paramGetters[0](), paramGetters[1](), paramGetters[2](), paramGetters[3](), paramGetters[4](), paramGetters[5](), paramGetters[6](), paramGetters[7](), paramGetters[8](), paramGetters[9]() });
                        default:
                            Debug.LogError(String.Format("#Delight# {0}: Unable to initialize view action handler \"{1}()\". A maximum of 10 parameters are allowed for view action handlers.", GetType().Name, actionHandlerName, parentType.Name));
                            return (x, y) => { };
                    }
                }
                else
                {
                    switch (paramGetters.Length)
                    {
                        case 1:
                            return (x, y) => actionHandler.Invoke(obj, new object[] { paramGetters[0]() });
                        case 2:
                            return (x, y) => actionHandler.Invoke(obj, new object[] { paramGetters[0](), paramGetters[1]() });
                        case 3:
                            return (x, y) => actionHandler.Invoke(obj, new object[] { paramGetters[0](), paramGetters[1](), paramGetters[2]() });
                        case 4:
                            return (x, y) => actionHandler.Invoke(obj, new object[] { paramGetters[0](), paramGetters[1](), paramGetters[2](), paramGetters[3]() });
                        case 5:
                            return (x, y) => actionHandler.Invoke(obj, new object[] { paramGetters[0](), paramGetters[1](), paramGetters[2](), paramGetters[3](), paramGetters[4]() });
                        case 6:
                            return (x, y) => actionHandler.Invoke(obj, new object[] { paramGetters[0](), paramGetters[1](), paramGetters[2](), paramGetters[3](), paramGetters[4](), paramGetters[5]() });
                        case 7:
                            return (x, y) => actionHandler.Invoke(obj, new object[] { paramGetters[0](), paramGetters[1](), paramGetters[2](), paramGetters[3](), paramGetters[4](), paramGetters[5](), paramGetters[6]() });
                        case 8:
                            return (x, y) => actionHandler.Invoke(obj, new object[] { paramGetters[0](), paramGetters[1](), paramGetters[2](), paramGetters[3](), paramGetters[4](), paramGetters[5](), paramGetters[6](), paramGetters[7]() });
                        case 9:
                            return (x, y) => actionHandler.Invoke(obj, new object[] { paramGetters[0](), paramGetters[1](), paramGetters[2](), paramGetters[3](), paramGetters[4](), paramGetters[5](), paramGetters[6](), paramGetters[7](), paramGetters[8]() });
                        case 10:
                            return (x, y) => actionHandler.Invoke(obj, new object[] { paramGetters[0](), paramGetters[1](), paramGetters[2](), paramGetters[3](), paramGetters[4](), paramGetters[5](), paramGetters[6](), paramGetters[7](), paramGetters[8](), paramGetters[9]() });
                        default:
                            Debug.LogError(String.Format("#Delight# {0}: Unable to initialize view action handler \"{1}()\". A maximum of 10 parameters are allowed for view action handlers.", GetType().Name, actionHandlerName, parentType.Name));
                            return (x, y) => { };
                    }
                }
            }

            if (parameterCount == 1)
            {
                // check if first parameter is a reference to the sender or view action
                if (typeof(View).IsAssignableFrom(viewActionMethodParameters[0].ParameterType))
                {
                    // parameter is the sender
                    return (x, y) => actionHandler.Invoke(obj, new object[] { x });
                }
                else if (typeof(ActionData).IsAssignableFrom(viewActionMethodParameters[0].ParameterType))
                {
                    // parameter is the view action data
                    return (x, y) => actionHandler.Invoke(obj, new object[] { y });
                }
                else
                {
                    // try pass the raw data
                    return (x, y) => actionHandler.Invoke(obj, new object[] { (y as ActionData) != null ? (y as ActionData).RawData : y });
                }
            }
            else
            {
                return (x, y) => actionHandler.Invoke(obj, new object[] { x, y });
            }
        }

        #endregion
    }
}
