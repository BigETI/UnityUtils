﻿using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Utilities namespace
/// </summary>
namespace Utils
{
    /// <summary>
    /// Algorithm class
    /// </summary>
    public static class Algorithm
    {
        /// <summary>
        /// Shuffle
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="collection">Collection</param>
        /// <returns>Shuffled array</returns>
        public static T[] Shuffle<T>(IEnumerable<T> collection)
        {
            List<T> ret = new List<T>(collection);
            int n = ret.Count;
            while (n > 1)
            {
                int k = Random.Range(0, n--);
                T temp = ret[n];
                ret[n] = ret[k];
                ret[k] = temp;
            }
            return ret.ToArray();
        }
    }
}