using System.Collections;
using UnityEngine;

namespace Delight
{
    public class Example2 : MonoBehaviour
    {
        private IEnumerator Start()
        {
            AssetBundleManager abm = new AssetBundleManager();
            abm.SetBaseUri("https://www.example.com/bundles");
            var initializeAsync = abm.InitializeAsync();
            yield return initializeAsync;

            if (initializeAsync.Success) {
                AssetBundleAsync bundle = abm.GetBundleAsync("BundleNameHere");
                yield return bundle;

                if (bundle.AssetBundle != null) {
                    // Do something with the bundle
                    abm.UnloadBundle(bundle.AssetBundle);
                }
            } else {
                Debug.LogError("Error initializing ABM.");
            }


            abm.Dispose();
        }
    }
}