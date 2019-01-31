using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Delight
{
    public class Utility
    {
        public const string AssetBundlesOutputPath = "AssetBundles";

        public static string GetPlatformName()
        {
#if UNITY_EDITOR
            return GetPlatformForAssetBundles(EditorUserBuildSettings.activeBuildTarget);
#else
			return GetPlatformForAssetBundles(Application.platform);
#endif
        }

        public static string GetPlatformForAssetBundles(BuildTarget target)
        {
            switch (target) {
                case BuildTarget.Android:
                    return "Android";
                case BuildTarget.iOS:
                    return "iOS";
                case BuildTarget.tvOS:
                    return "tvOS";
                case BuildTarget.WebGL:
                    return "WebGL";
                case BuildTarget.StandaloneWindows:
                case BuildTarget.StandaloneWindows64:
                    return "StandaloneWindows";
#if UNITY_2017_4_OR_NEWER
                case BuildTarget.StandaloneOSX:
                    return "StandaloneOSX";
#else
                case BuildTarget.StandaloneOSXIntel:
                case BuildTarget.StandaloneOSXIntel64:
                    return "StandaloneOSXIntel";
#endif
                // Add more build targets for your own.
                // If you add more targets, don't forget to add the same platforms to the function below.
                case BuildTarget.StandaloneLinux:
                case BuildTarget.StandaloneLinux64:
                case BuildTarget.StandaloneLinuxUniversal:
                    return "StandaloneLinux";
#if UNITY_SWITCH
                case BuildTarget.Switch:
                    return "Switch";
#endif
                default:
                    Debug.Log("Unknown BuildTarget: Using Default Enum Name: " + target);
                    return target.ToString();
            }
        }

        public static string GetPlatformForAssetBundles(RuntimePlatform platform)
        {
            switch (platform) {
                case RuntimePlatform.Android:
                    return "Android";
                case RuntimePlatform.IPhonePlayer:
                    return "iOS";
                case RuntimePlatform.tvOS:
                    return "tvOS";
                case RuntimePlatform.WebGLPlayer:
                    return "WebGL";
                case RuntimePlatform.WindowsPlayer:
                    return "StandaloneWindows";
#if UNITY_2017_4_OR_NEWER
                case RuntimePlatform.OSXPlayer:
                    return "StandaloneOSX";
#else
                case RuntimePlatform.OSXPlayer:
                    return "StandaloneOSXIntel";
#endif
                case RuntimePlatform.LinuxPlayer:
                    return "StandaloneLinux";
                case RuntimePlatform.Switch:
                    return "Switch";
                default:
                    return platform.ToString();
            }
        }
    }
}