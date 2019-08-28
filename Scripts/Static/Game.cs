using System.Collections.Generic;
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
        public static bool IsMobile => (SystemInfo.deviceType == DeviceType.Handheld);

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
        /// Show advertisement
        /// </summary>
        /// <param name="showOptions">Show Options</param>
        public static void ShowAd(AdShowOptions showOptions)
        {
#if UNITY_ADS
            ShowOptions show_options = new ShowOptions();
            show_options.gamerSid = showOptions.GamerSID;
            show_options.resultCallback = (showResult) =>
            {
                if (showOptions.ResultCallback != null)
                {
                    showOptions.ResultCallback((EAdShowResult)showResult);
                }
            };
            Advertisement.Show(show_options);
#endif
        }

        /// <summary>
        /// Show advertisement
        /// </summary>
        /// <param name="placementID">Placement ID</param>
        public static void ShowAd(string placementID)
        {
#if UNITY_ADS
            Advertisement.Show(placementID);
#endif
        }

        /// <summary>
        /// Show advertisement
        /// </summary>
        /// <param name="placementID">Placement ID</param>
        /// <param name="showOptions">Show Options</param>
        public static void ShowAd(string placementID, AdShowOptions showOptions)
        {
#if UNITY_ADS
            ShowOptions show_options = new ShowOptions();
            show_options.gamerSid = showOptions.GamerSID;
            show_options.resultCallback = (showResult) =>
            {
                if (showOptions.ResultCallback != null)
                {
                    showOptions.ResultCallback((EAdShowResult)showResult);
                }
            };
            Advertisement.Show(placementID, show_options);
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
    }
}
