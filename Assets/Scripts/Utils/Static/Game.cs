using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
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
        /// Save game path
        /// </summary>
        private static string saveGamePath;

        /// <summary>
        /// Save game data
        /// </summary>
        private static ASaveGameData saveGameData;

        /// <summary>
        /// Backup save game data
        /// </summary>
        private static ASaveGameData backupSaveGameData;

        /// <summary>
        /// Save game data type
        /// </summary>
        private static Type saveGameDataType;

        /// <summary>
        /// Save game data assembly
        /// </summary>
        private static Assembly saveGameDataAssembly;

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
                return (SystemInfo.deviceType == DeviceType.Handheld);
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
        /// Save game path
        /// </summary>
        public static string SaveGamePath
        {
            get
            {
                if (saveGamePath == null)
                {
                    saveGamePath = Application.persistentDataPath + "/save-game.json";
                }
                return saveGamePath;
            }
        }

        /// <summary>
        /// Save game data
        /// </summary>
        public static ASaveGameData SaveGameData
        {
            get
            {
                if ((saveGameData == null) && (SaveGameDataType != null))
                {
                    Load();
                    if (saveGameData == null)
                    {
                        try
                        {
                            saveGameData = (ASaveGameData)(Activator.CreateInstance(SaveGameDataType));
                            Save();
                        }
                        catch (Exception e)
                        {
                            Debug.LogError(e);
                        }
                    }
                }
                return saveGameData;
            }
        }

        /// <summary>
        /// Get save game data
        /// </summary>
        /// <typeparam name="T">Save game type</typeparam>
        /// <returns>Save game if successful, otherwise "null"</returns>
        public static T GetSaveGameData<T>() where T : ASaveGameData
        {
            return SaveGameData as T;
        }

        /// <summary>
        /// Backup save game data
        /// </summary>
        public static ASaveGameData BackupSaveGameData
        {
            get
            {
                if ((backupSaveGameData == null) && (SaveGameDataType != null))
                {
                    try
                    {
                        backupSaveGameData = (ASaveGameData)(Activator.CreateInstance(SaveGameDataType, SaveGameData));
                    }
                    catch (Exception e)
                    {
                        Debug.LogError(e);
                    }
                }
                return backupSaveGameData;
            }
        }

        /// <summary>
        /// Save game data type
        /// </summary>
        private static Type SaveGameDataType
        {
            get
            {
                if (saveGameDataAssembly == null)
                {
                    try
                    {
                        List<Type> types = new List<Type>();
                        saveGameDataAssembly = Assembly.GetAssembly(typeof(Game));
                        if (saveGameDataAssembly != null)
                        {
                            foreach (Type type in saveGameDataAssembly.GetTypes())
                            {
                                if (type != null)
                                {
                                    if (type.IsClass && (!(type.IsAbstract)) && (!(type.IsInterface)) && typeof(ASaveGameData).IsAssignableFrom(type))
                                    {
                                        types.Add(type);
                                    }
                                }
                            }
                        }
                        if (types.Count <= 0)
                        {
                            Debug.LogError("Please implement a class inherited from \"" + typeof(ASaveGameData).FullName + "\"");
                        }
                        else if (types.Count > 1)
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.Append("There are too many classes inherited from \"");
                            sb.Append(typeof(ASaveGameData).FullName);
                            sb.AppendLine("\":");
                            foreach (Type type in types)
                            {
                                sb.Append("\t\"");
                                sb.Append(type.FullName);
                                sb.AppendLine("\"");
                            }
                            Debug.LogError(sb.ToString());
                        }
                        else
                        {
                            saveGameDataType = types[0];
                        }
                        types.Clear();
                    }
                    catch (Exception e)
                    {
                        Debug.LogError(e);
                    }
                }
                return saveGameDataType;
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

        /// <summary>
        /// Load save game
        /// </summary>
        /// <returns>"true" if successful, otherwise "false"</returns>
        public static bool Load()
        {
            return Load(SaveGamePath);
        }

        /// <summary>
        /// Load save game
        /// </summary>
        /// <param name="path">Save game path</param>
        /// <returns>"true" if successful, otherwise "false"</returns>
        public static bool Load(string path)
        {
            bool ret = false;
            if ((path != null) && (SaveGameDataType != null))
            {
                try
                {
                    if (File.Exists(path))
                    {
                        using (StreamReader reader = new StreamReader(File.Open(path, FileMode.Open)))
                        {
                            saveGameData = (ASaveGameData)(JsonUtility.FromJson(reader.ReadToEnd(), SaveGameDataType));
                            backupSaveGameData = (ASaveGameData)(Activator.CreateInstance(SaveGameDataType, saveGameData));
                            ret = true;
                        }
                    }
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
            }
            return ret;
        }

        /// <summary>
        /// Save game
        /// </summary>
        /// <returns>"true" if successful, otherwise "false"</returns>
        public static bool Save()
        {
            return Save(SaveGamePath);
        }

        /// <summary>
        /// Save game
        /// </summary>
        /// <param name="path">Save game path</param>
        /// <returns>"true" if successful, otherwise "false"</returns>
        public static bool Save(string path)
        {
            bool ret = false;
            if ((saveGameData != null) && (path != null) && (SaveGameDataType != null))
            {
                string backup_path = path + ".backup";
                try
                {
                    if (File.Exists(path))
                    {
                        File.Copy(path, backup_path, true);
                        File.Delete(path);
                    }
                    using (StreamWriter writer = new StreamWriter(File.Open(path, FileMode.Create)))
                    {
                        saveGameData.UpdateLastSaveDateTime();
                        writer.Write(JsonUtility.ToJson(saveGameData));
                        backupSaveGameData = (ASaveGameData)(Activator.CreateInstance(SaveGameDataType, saveGameData));
                        ret = true;
                    }
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                    try
                    {
                        if (File.Exists(backup_path))
                        {
                            File.Copy(backup_path, path, true);
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.LogError(ex.Message);
                    }
                }
                try
                {
                    if (File.Exists(backup_path))
                    {
                        File.Delete(backup_path);
                    }
                }
                catch (Exception ex)
                {
                    Debug.LogError(ex.Message);
                }
            }
            return ret;
        }

        /// <summary>
        /// Restore save game data from backup save game data
        /// </summary>
        public static void RestoreSaveGameDataFromBackupSaveGameData()
        {
            if (backupSaveGameData != null)
            {
                saveGameData = (ASaveGameData)(Activator.CreateInstance(SaveGameDataType, backupSaveGameData));
            }
        }
    }
}
