using System;
using UnityEngine;

/// <summary>
/// Utilities namespace
/// </summary>
namespace Utils
{
    /// <summary>
    /// Advertisement show options
    /// </summary>
    public class AdShowOptions
    {
        /// <summary>
        /// Gamer serial ID
        /// </summary>
        private string gamerSID;

        /// <summary>
        /// Result callback
        /// </summary>
        private Action<EAdShowResult> resultCallback;

        /// <summary>
        /// Gamer serial ID
        /// </summary>
        public string GamerSID
        {
            get
            {
                if (gamerSID == null)
                {
                    gamerSID = "";
                }
                return gamerSID;
            }
        }

        /// <summary>
        /// Result callback
        /// </summary>
        public Action<EAdShowResult> ResultCallback
        {
            get
            {
                return resultCallback;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="resultCallback">Result callback</param>
        public AdShowOptions(Action<EAdShowResult> resultCallback)
        {
            this.resultCallback = resultCallback;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="gamerSID">Gamer serial ID</param>
        /// <param name="resultCallback">Result callback</param>
        public AdShowOptions(string gamerSID, Action<EAdShowResult> resultCallback)
        {
            this.gamerSID = gamerSID;
            this.resultCallback = resultCallback;
        }
    }
}
