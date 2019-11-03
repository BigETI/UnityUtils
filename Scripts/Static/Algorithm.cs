using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Unity utilities namespace
/// </summary>
namespace UnityUtils
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

        /// <summary>
        /// Clamp
        /// </summary>
        /// <param name="value">Value</param>
        /// <param name="min">Minimum</param>
        /// <param name="max">Maximum</param>
        /// <returns>Clamped value</returns>
        public static double Clamp(double value, double min, double max)
        {
            return ((value < min) ? min : ((value > max) ? max : value));
        }

        /// <summary>
        /// Turn
        /// </summary>
        /// <param name="value">Value</param>
        /// <param name="min">Minimum</param>
        /// <param name="max">Maximum</param>
        /// <returns>Turned value</returns>
        public static float Turn(float value, float min, float max)
        {
            float ret = value;
            float mn = Mathf.Min(min, max);
            float mx = Mathf.Max(min, max);
            float delta = Mathf.Abs(mx - mn);
            if (delta > float.Epsilon)
            {
                while (ret < mn)
                {
                    ret += delta;
                }
                while (ret >= mx)
                {
                    ret -= delta;
                }
            }
            else
            {
                ret = mn;
            }
            return ret;
        }

        /// <summary>
        /// Turn difference signed
        /// </summary>
        /// <param name="fromAngle">From angle</param>
        /// <param name="toAngle">To angle</param>
        /// <param name="min">Minimum</param>
        /// <param name="max">Maximum</param>
        /// <returns>Turn difference</returns>
        public static float TurnDifferenceSigned(float from, float to, float min, float max)
        {
            float f = Turn(from, min, max);
            float t = Turn(to, min, max);
            float mn = Mathf.Min(min, max);
            float mx = Mathf.Max(min, max);
            float a = Turn(t - f, mn, mx);
            float b = Turn(f - t, mn, mx);
            return ((a < b) ? a : -b);
        }
    }
}
