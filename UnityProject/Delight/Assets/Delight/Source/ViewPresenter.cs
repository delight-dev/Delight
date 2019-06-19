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
    /// Presents a view in the scene.
    /// </summary>
    public class ViewPresenter : MonoBehaviour
    {
        #region Fields

        [HideInInspector]
        public GameObject GameObject;

        [HideInInspector]
        public string ViewTypeName;

        [HideInInspector]
        public string ViewTypeNamespace = "Delight";

        public LoadMode LoadMode = LoadMode.Automatic;
        public bool UseAsyncLoad = true;
        private View _view;

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

            if (_view == null)
            {
#if UNITY_EDITOR
                if (GameObject != null) GameObject.DestroyImmediate(GameObject);
#endif
                Create();

                if (_view == null)
                    return;
            }
 
            var sw2 = System.Diagnostics.Stopwatch.StartNew();

            if (UseAsyncLoad)
            {
                await _view.LoadAsync();
            }
            else
            {
                _view.Load();
            }

            sw2.Stop();
            Debug.Log(String.Format("Initialize view {0}: {1}", ViewTypeName, sw2.ElapsedMilliseconds));

            GameObject go = null;
            if (_view is UIView)
            {
                go = (_view as UIView)?.LayoutRoot?.GameObject;
            }
            else if (_view is SceneObjectView)
            {
                go = (_view as SceneObjectView)?.GameObject;
            }

            if (go != null)
            {
                go.transform.SetParent(gameObject.transform, false);
            }

#if UNITY_EDITOR
            if (!Application.isPlaying)
            {
                var sceneObject = _view as SceneObjectView;
                GameObject = sceneObject?.GameObject;
            }
#endif
        }

        public void Unload()
        {
            _view?.Unload();
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
            _view = type != null ? TypeHelper.CreateInstance(type) as View : null;
            sw.Stop();
            Debug.Log(String.Format("Create view {0}: {1}", ViewTypeName, sw.ElapsedMilliseconds));

            if (_view == null)
            {
                Debug.Log(String.Format("[Delight] ViewPresenter unable to present view \"{0}\". View with that name not found.", ViewTypeName));
                return;
            }
        }

        #endregion
    }
}
