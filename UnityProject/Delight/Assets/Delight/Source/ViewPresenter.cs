#region Using Statements
using System;
using System.Runtime.CompilerServices;
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

        public string ViewTypeName;
        public string ViewTypeNamespace = "Delight";
        public bool LoadOnStart = true;
        private View _view;

        #endregion

        #region Methods

        public async void Start()
        {
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

            if (LoadOnStart)
            {
                var sw2 = System.Diagnostics.Stopwatch.StartNew();
                await _view.LoadAsync();
                sw2.Stop();
                Debug.Log(String.Format("Initialize view {0}: {1}", ViewTypeName, sw2.ElapsedMilliseconds));
            }
            
            Debug.Log("Done.");
        }

        public async void Load()
        {
            await _view.LoadAsync();
        }

        public void Unload()
        {
            _view.Unload();
        }

        #endregion
    }
}
