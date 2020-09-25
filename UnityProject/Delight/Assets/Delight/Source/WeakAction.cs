#region Using Statements
using System;
using System.Reflection;
#endregion

namespace Delight
{

    /// <summary>
    /// Holds a weak reference to an action.
    /// </summary>
    public class WeakAction<T> : WeakAction, IInvokeWithObject
    {
        #region Fields

        private Action<T> _staticAction;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public WeakAction(object target, Action<T> action, bool keepTargetAlive = false)
        {
            if (action.Method.IsStatic)
            {
                _staticAction = action;
                if (target != null)
                {
                    _ownerWeakReference = new WeakReference(target);
                }
                return;
            }

            _actionMethodInfo = action.Method;
            _actionTargetWeakReference = new WeakReference(action.Target);
            _actionTarget = keepTargetAlive ? action.Target : null;
            _ownerWeakReference = new WeakReference(target);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Invokes action with object parameter.
        /// </summary>
        public void InvokeWithObject(object parameter)
        {
            var parameterCasted = (T)parameter;
            Invoke(parameterCasted);
        }

        /// <summary>
        /// Invokes action with default parameter.
        /// </summary>
        public new void Invoke()
        {
            Invoke(default(T));
        }

        /// <summary>
        /// Invokes action with parameter.
        /// </summary>
        public void Invoke(T parameter)
        {
            if (_staticAction != null)
            {
                _staticAction(parameter);
                return;
            }

            if (!IsAlive)
            {
                return;
            }

            var actionTarget = ActionTarget;
            if (_actionMethodInfo != null &&
                (_actionTarget != null || _actionTargetWeakReference != null)
                && actionTarget != null)
            {
                _actionMethodInfo.Invoke(actionTarget, new object[] { parameter });
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets boolean indicating if target is alive.
        /// </summary>
        public override bool IsAlive 
        {
            get
            {
                if (_staticAction == null && _ownerWeakReference == null)
                {
                    return false;
                }

                if (_staticAction != null)
                {
                    return _ownerWeakReference != null ? _ownerWeakReference.IsAlive : true;
                }

                return _ownerWeakReference.IsAlive;
            }
        }

        #endregion
    }

    /// <summary>
    /// Base class for weak action references.
    /// </summary>
    public class WeakAction
    {
        #region Fields 

        protected object _actionTarget;
        protected WeakReference _actionTargetWeakReference;
        protected WeakReference _ownerWeakReference;
        protected MethodInfo _actionMethodInfo;
        private Action _staticAction;

        #endregion

        #region Constructor

        /// <summary>
        /// Initiates a new instance of the class.
        /// </summary>
        public WeakAction(object owner, Action action, bool keepTargetAlive = false)
        {
            if (action.Method.IsStatic)
            {
                _staticAction = action;
                if (owner != null)
                {
                    _ownerWeakReference = new WeakReference(owner);
                }
                return;
            }

            _actionMethodInfo = action.Method;
            _actionTargetWeakReference = new WeakReference(action.Target);
            _actionTarget = keepTargetAlive ? action.Target : null;
            _ownerWeakReference = new WeakReference(owner);
        }

        /// <summary>
        /// Initiates a new instance of the class.
        /// </summary>
        protected WeakAction()
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Invokes action if alive.
        /// </summary>
        public void Invoke()
        {
            if (_staticAction != null)
            {
                _staticAction();
                return;
            }

            if (!IsAlive)
            {
                return;
            }

            var actionTarget = ActionTarget;
            if (_actionMethodInfo != null && 
                (_actionTarget != null || _actionTargetWeakReference != null)
                && actionTarget != null)
            {
                _actionMethodInfo.Invoke(actionTarget, null);
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets boolean indicating if target is alive.
        /// </summary>
        public virtual bool IsAlive
        {
            get
            {
                if (_staticAction == null && _ownerWeakReference == null && _actionTarget == null)
                {
                    return false;
                }

                if (_staticAction != null)
                {
                    return _ownerWeakReference != null ? _ownerWeakReference.IsAlive : true;
                }

                if (_actionTarget != null)
                {
                    return true;
                }

                if (_ownerWeakReference != null)
                {
                    return _ownerWeakReference.IsAlive;
                }

                return false;
            }
        }

        /// <summary>
        /// Gets target of the action.
        /// </summary>
        protected object ActionTarget
        {
            get
            {
                if (_actionTarget != null)
                {
                    return _actionTarget;
                }

                return _actionTargetWeakReference?.Target;
            }
        }

        /// <summary>
        /// Gets the owner of the action.
        /// </summary>
        public object Owner
        {
            get
            {
                return _ownerWeakReference?.Target;
            }
        }

        #endregion
    }
}
