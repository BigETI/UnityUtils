using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;
#if UNITY_ADS
using UnityEngine.Advertisements;
#endif
#if UNITY_ANALYTICS
using UnityEngine.Analytics;
#endif

/// <summary>
/// Utilitites namespace
/// </summary>
namespace Utils
{
    /// <summary>
    /// Game class
    /// </summary>
    public static class Game
    {
        /// <summary>
        /// Is any key down
        /// </summary>
        private static bool isAnyKeyDown;

        /// <summary>
        /// Any key
        /// </summary>
        public static bool AnyKey
        {
            get
            {
                return ((Input.touchCount > 0) || Input.anyKey);
            }
        }

        /// <summary>
        /// Any key down
        /// </summary>
        public static bool AnyKeyDown
        {
            get
            {
                bool ret = false;
                if (isAnyKeyDown)
                {
                    if (!AnyKey)
                    {
                        isAnyKeyDown = false;
                    }
                }
                else
                {
                    if (AnyKey)
                    {
                        ret = true;
                        isAnyKeyDown = true;
                    }
                }
                return ret;
            }
        }

        /// <summary>
        /// Is mobile
        /// </summary>
        public static bool IsMobile
        {
            get
            {
                return SystemInfo.deviceType == DeviceType.Handheld;
            }
        }

        /// <summary>
        /// Is ad supported
        /// </summary>
        public static bool IsAdSupported
        {
            get
            {
#if UNITY_ADS
                return true;
#else
                return false;
#endif
            }
        }

        /// <summary>
        /// Is showing advertisement
        /// </summary>
        public static bool IsShowingAd
        {
            get
            {
#if UNITY_ADS
                return Advertisement.isShowing;
#else
                return false;
#endif
            }
        }

        /// <summary>
        /// Quit
        /// </summary>
        public static void Quit()
        {
            //SaveGame.Save();
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

        /// <summary>
        /// Show advertisement
        /// </summary>
        public static void ShowAd()
        {
#if UNITY_ADS
            Advertisement.Show();
#endif
        }

        /// <summary>
        /// Analytics event
        /// </summary>
        /// <param name="customEventName">Custom event name</param>
        public static void AnalyticsEvent(string customEventName)
        {
#if UNITY_ANALYTICS
            Analytics.CustomEvent(customEventName);
#endif
        }

        /// <summary>
        /// Analytics event
        /// </summary>
        /// <param name="customEventName">Custom event name</param>
        /// <param name="position">Position</param>
        public static void AnalyticsEvent(string customEventName, Vector3 position)
        {
#if UNITY_ANALYTICS
            Analytics.CustomEvent(customEventName, position);
#endif
        }

        /// <summary>
        /// Analytics event
        /// </summary>
        /// <param name="customEventName">Custom event name</param>
        /// <param name="eventData">Event data</param>
        public static void AnalyticsEvent(string customEventName, IDictionary<string, object> eventData)
        {
#if UNITY_ANALYTICS
            Analytics.CustomEvent(customEventName, eventData);
#endif
        }

        /// <summary>
        /// SHA 256
        /// </summary>
        /// <param name="text">Text</param>
        /// <returns>Result</returns>
        public static string SHA256(string text)
        {
            StringBuilder ret = new StringBuilder();
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            foreach (byte b in hash)
            {
                ret.Append(System.String.Format("{0:x2}", b));
            }
            return ret.ToString();
        }

        /// <summary>
        /// SHA 512
        /// </summary>
        /// <param name="text">Text</param>
        /// <returns>Result</returns>
        public static string SHA512(string text)
        {
            StringBuilder ret = new StringBuilder();
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            SHA512Managed hashstring = new SHA512Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            foreach (byte b in hash)
            {
                ret.Append(System.String.Format("{0:x2}", b));
            }
            return ret.ToString();
        }
    }
}
