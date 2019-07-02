#region Using Statements
#if UNITY_EDITOR
#endif
#endregion

namespace Delight
{
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
                _action.Invoke(sender, eventArgs);
            }
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

        #endregion
    }
}
