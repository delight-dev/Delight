#region Using Statements
using System;
using System.Reflection;
using UnityEngine;
#if DELIGHT_MODULE_PLAYFAB
using PlayFab;
#endif
#endregion

namespace Delight
{
    /// <summary>
    /// Global manager that performs initialization and updates for Delight.
    /// </summary>
    public class DelightManager : MonoBehaviour
    {
        #region Fields

        public static DelightManager Instance { get; private set; }

        #endregion

        #region Method

        /// <summary>
        /// Makes sure an instance of the Delight manager is created.
        /// </summary>
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

        /// <summary>
        /// Initializes the Delight framework.
        /// </summary>
        public void Awake()
        {
            // detect device, screen size, etc.
            // get device type
            Models.Globals.DeviceType = GetDeviceType();
#if DELIGHT_MODULE_PLAYFAB
            if (!String.IsNullOrEmpty(Config.PlayFabTitleId))
            {
                PlayFabSettings.TitleId = Config.PlayFabTitleId;
            }
#endif
        }

        /// <summary>
        /// Updates the Delight framework.
        /// </summary>
        public void Update()
        {
            // TODO maybe use the messenger system to notify screen orientation and size changes

            // update screen orientation and size
            Models.Globals.ScreenOrientation = Screen.orientation;

            if (Models.Globals.ScreenWidth.Pixels != Screen.width)
            {
                Models.Globals.ScreenWidth = Screen.width;
            }

            if (Models.Globals.ScreenHeight.Pixels != Screen.height)
            {
                Models.Globals.ScreenHeight = Screen.height;
            }

            // update location
            if (Input.location.isEnabledByUser)
            {
                if (Input.location.status != LocationServiceStatus.Running)
                {
                    Input.location.Start();
                }
                else
                {
                    Models.Globals.Longitude = Input.location.lastData.longitude;
                    Models.Globals.Latitude = Input.location.lastData.latitude;
                    Models.Globals.Altitude = Input.location.lastData.altitude;
                }
            }
        }

        /// <summary>
        /// Gets device type. If handheld it guesses if it's a Tablet or Mobile based on aspect ratio and diagonal size in inches.
        /// </summary>
        public static DeviceType GetDeviceType()
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

        /// <summary>
        /// Gets diagonal size of screen in inches.
        /// </summary>
        private static float DeviceDiagonalSizeInInches()
        {
            float screenWidth = Screen.width / Screen.dpi;
            float screenHeight = Screen.height / Screen.dpi;
            float diagonalInches = Mathf.Sqrt(Mathf.Pow(screenWidth, 2) + Mathf.Pow(screenHeight, 2));
            return diagonalInches;
        }

        #endregion
    }
}
