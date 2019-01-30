using System.Collections;
using UnityEngine;

namespace Delight
{
    public class AssetBundleDownloaderMonobehaviour : MonoBehaviour
    {
        private static AssetBundleDownloaderMonobehaviour instance;

        public static AssetBundleDownloaderMonobehaviour Instance {
            get {
                if (instance == null) instance = CreateInstance();
                return instance;
            }
        }

        private static AssetBundleDownloaderMonobehaviour CreateInstance()
        {
            var go = new GameObject("AssetBundleDownloaderMonobehaviour");
            DontDestroyOnLoad(go);
            return go.AddComponent<AssetBundleDownloaderMonobehaviour>();
        }

        private void Awake()
        {
            if (instance != null) {
                DestroyImmediate(gameObject);
                return;
            }

            Application.runInBackground = true; // Http requests respond even if you lose focus
        }

        private void OnDestroy()
        {
            if (instance == this) {
                instance = null;
            }
        }

        public void HandleCoroutine(IEnumerator coroutine)
        {
            StartCoroutine(coroutine);
        }
    }
}