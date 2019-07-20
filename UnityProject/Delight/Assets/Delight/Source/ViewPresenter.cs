#region Using Statements
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Timers;
using UnityEngine;
#endregion

namespace Delight
{
    /// <summary>
    /// MonoBehavior for presenting a view in the scene. Used to e.g. create and load the main scene view.
    /// </summary>
    public class ViewPresenter : MonoBehaviour
    {
        #region Fields

        [HideInInspector]
        public string ViewTypeName;

        [HideInInspector]
        public string ViewTypeNamespace = "Delight";

        public LoadMode LoadMode = LoadMode.Automatic;
        public bool UseAsyncLoad = true;

        private View _presentedView;
        public View PresentedView
        {
            get
            {
                return _presentedView;
            }
        }

        public GameObject _layoutRootGameObject;
        public GameObject LayoutRootGameObject
        {
            get
            {
                return _layoutRootGameObject;
            }
        }

        #endregion

        #region Methods

        public async void Start()
        {
            if (!LoadMode.HasFlag(LoadMode.Manual))
            {
                await Load();
            }
        }

        public async Task Load()
        {
            if (String.IsNullOrEmpty(ViewTypeName))
                return;

            if (_presentedView == null)
            {
#if UNITY_EDITOR
                if (_layoutRootGameObject != null) GameObject.DestroyImmediate(_layoutRootGameObject);
#endif
                _presentedView = Assets.CreateView(ViewTypeName);
                if (_presentedView == null)
                {
                    Create();
                }

                if (_presentedView == null)
                    return;
            }
 
            var sw2 = System.Diagnostics.Stopwatch.StartNew();

            if (UseAsyncLoad)
            {
                await _presentedView.LoadAsync();
            }
            else
            {
                _presentedView.Load();
            }

            sw2.Stop();
            Debug.Log(String.Format("Initialize view {0}: {1}", ViewTypeName, sw2.ElapsedMilliseconds));

            GameObject go = null;
            if (_presentedView is UIView)
            {
                go = (_presentedView as UIView)?.LayoutRoot?.GameObject;
            }
            else if (_presentedView is SceneObjectView)
            {
                go = (_presentedView as SceneObjectView)?.GameObject;
            }

            if (go != null)
            {
                go.transform.SetParent(gameObject.transform, false);
            }

            _layoutRootGameObject = go;
        }

        public void Unload()
        {
            _presentedView?.Unload();
        }

        /// <summary>
        /// Instantiates the view to be presented.
        /// </summary>
        public void Create()
        {
            if (String.IsNullOrEmpty(ViewTypeName))
                return;

            var type = TypeHelper.GetType(ViewTypeName, ViewTypeNamespace);

            var sw = System.Diagnostics.Stopwatch.StartNew();
            _presentedView = type != null ? TypeHelper.CreateInstance(type) as View : null;
            sw.Stop();
            Debug.Log(String.Format("Create view {0}: {1}", ViewTypeName, sw.ElapsedMilliseconds));

            if (_presentedView == null)
            {
                Debug.Log(String.Format("#Delight# ViewPresenter unable to present view \"{0}\". View with that name not found.", ViewTypeName));
                return;
            }
        }

        #endregion
    }
}
