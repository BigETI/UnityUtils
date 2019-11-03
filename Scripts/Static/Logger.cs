using System;
using System.IO;
using UnityEngine;

/// <summary>
/// Unity utilities namespace
/// </summary>
namespace UnityUtils
{
    /// <summary>
    /// Logger class
    /// </summary>
    public static class Logger
    {
        /// <summary>
        /// Game log path
        /// </summary>
        private static readonly string gameLogPath = Application.persistentDataPath + "/game.log";

        /// <summary>
        /// Error log path
        /// </summary>
        private static readonly string errorLogPath = Application.persistentDataPath + "/error.log";

        /// <summary>
        /// Log object
        /// </summary>
        /// <param name="obj">Object</param>
        public static void Log(object obj)
        {
            if (obj != null)
            {
                if (obj is string)
                {
                    Log((string)obj);
                }
                else
                {
                    Log(JsonUtility.ToJson(obj, true));
                }
            }
        }

        /// <summary>
        /// Log text
        /// </summary>
        /// <param name="text">Text</param>
        public static void Log(string text)
        {
            if (text != null)
            {
                AppendToFile(text, gameLogPath);
            }
        }

        /// <summary>
        /// Log object as error
        /// </summary>
        /// <param name="obj">Object</param>
        public static void LogError(object obj)
        {
            if (obj != null)
            {
                if (obj is string)
                {
                    LogError((string)obj);
                }
                else
                {
                    LogError(JsonUtility.ToJson(obj, true));
                }
            }
        }

        /// <summary>
        /// Log text as error
        /// </summary>
        /// <param name="text">Text</param>
        public static void LogError(string text)
        {
            if (text != null)
            {
                AppendToFile(text, errorLogPath);
            }
        }

        /// <summary>
        /// Append to file
        /// </summary>
        /// <param name="text">Text</param>
        /// <param name="path">Path</param>
        private static void AppendToFile(string text, string path)
        {
            using (FileStream stream = File.Open(path, FileMode.Append))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write("[");
                    writer.Write(DateTime.Now.ToString());
                    writer.WriteLine("]");
                    writer.WriteLine(text);
                    writer.WriteLine(string.Empty);
                }
            }
        }
    }
}
