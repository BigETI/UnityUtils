using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Utilities namespace
/// </summary>
namespace Utils
{
    /// <summary>
    /// Cached resources
    /// </summary>
    public static class CachedResources
    {
        /// <summary>
        /// Resources
        /// </summary>
        private static Dictionary<string, Object> resources = new Dictionary<string, Object>();

        /// <summary>
        /// Resource groups
        /// </summary>
        private static Dictionary<string, Object[]> resourceGroups = new Dictionary<string, Object[]>();

        /// <summary>
        /// Load resource
        /// </summary>
        /// <typeparam name="T">Resource type</typeparam>
        /// <param name="path">Resource path</param>
        /// <returns>Resource if successful, otherwise "null"</returns>
        public static T Load<T>(string path) where T : Object
        {
            T ret = null;
            if (path != null)
            {
                if (resources.ContainsKey(path))
                {
                    ret = resources[path] as T;
                }
                else
                {
                    ret = Resources.Load<T>(path);
                    if (ret != null)
                    {
                        resources.Add(path, ret);
                    }
                }
            }
            return ret;
        }

        /// <summary>
        /// Load all resources
        /// </summary>
        /// <typeparam name="T">Resources type</typeparam>
        /// <param name="path">Resources path</param>
        /// <returns>Resources if successful, otherwise "null"</returns>
        public static T[] LoadAll<T>(string path) where T : Object
        {
            T[] ret = null;
            if (path != null)
            {
                if (resourceGroups.ContainsKey(path))
                {
                    ret = resourceGroups[path] as T[];
                }
                else
                {
                    ret = Resources.LoadAll<T>(path);
                    if (ret != null)
                    {
                        resourceGroups.Add(path, ret);
                    }
                }
            }
            return ret;
        }

        /// <summary>
        /// Clear from cache
        /// </summary>
        /// <param name="path">Path to clear</param>
        public static void Clear(string path)
        {
            if (path != null)
            {
                if (resources.ContainsKey(path))
                {
                    resources.Remove(path);
                }
                else if (resourceGroups.ContainsKey(path))
                {
                    resourceGroups.Remove(path);
                }
            }
        }

        /// <summary>
        /// Clear cache
        /// </summary>
        public static void Clear()
        {
            resources.Clear();
            resourceGroups.Clear();
        }
    }
}
