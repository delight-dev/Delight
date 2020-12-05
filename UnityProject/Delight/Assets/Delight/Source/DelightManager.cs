#region Using Statements
using System;
using System.Reflection;
using UnityEngine;
#endregion

namespace Delight
{
    /// <summary>
    /// Manages Delight content. 
    /// </summary>
    public class DelightManager : MonoBehaviour
    {
        #region Fields

        public static DelightManager Instance { get; private set; }

        #endregion

        #region Method

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        static void OnRuntimeMethodLoad()
        {
            var instance = FindObjectOfType<DelightManager>();
            if (instance == null)
            {
                instance = new GameObject("Delight Manager").AddComponent<DelightManager>();
            }

            DontDestroyOnLoad(instance);
            Instance = instance;
        }

        public void Awake()
        {
            // detect device, screen size, etc.
            // get device type
            Models.Globals.DeviceType = GetDeviceType();
        }

        public void Update()
        {
            // TODO maybe use the messenger system to notify screen orientation and size changes

            // update screen orientation
            Models.Globals.ScreenOrientation = Screen.orientation;
            Models.Globals.ScreenWidth.Pixels = Screen.width;
            Models.Globals.ScreenHeight.Pixels = Screen.height;
        }

        public DeviceType GetDeviceType()
        {
            if (SystemInfo.deviceType != UnityEngine.DeviceType.Handheld)
                return DeviceType.Desktop;

#if UNITY_IOS
            bool deviceIsIpad = UnityEngine.iOS.Device.generation.ToString().Contains("iPad");
            if (deviceIsIpad)
            {
                return Models.Globals.DeviceType = DeviceType.Tablet;
            }
            
            bool deviceIsIphone = UnityEngine.iOS.Device.generation.ToString().Contains("iPhone");
            if (deviceIsIphone)
            {
                return Models.Globals.DeviceType = DeviceType.Mobile;
            }
#endif
            float aspectRatio = Mathf.Max(Screen.width, Screen.height) / Mathf.Min(Screen.width, Screen.height);
            bool isTablet = (DeviceDiagonalSizeInInches() > 6.5f && aspectRatio < 2f);

            return isTablet ? DeviceType.Tablet : DeviceType.Mobile;
        }

        private float DeviceDiagonalSizeInInches()
        {
            float screenWidth = Screen.width / Screen.dpi;
            float screenHeight = Screen.height / Screen.dpi;
            float diagonalInches = Mathf.Sqrt(Mathf.Pow(screenWidth, 2) + Mathf.Pow(screenHeight, 2));
            return diagonalInches;
        }

        #endregion
    }
}
