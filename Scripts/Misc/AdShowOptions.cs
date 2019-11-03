using System;

/// <summary>
/// Unity utilities namespace
/// </summary>
namespace UnityUtils
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
        /// Gamer serial ID
        /// </summary>
        public string GamerSID
        {
            get
            {
                if (gamerSID == null)
                {
                    gamerSID = string.Empty;
                }
                return gamerSID;
            }
        }

        /// <summary>
        /// Result callback
        /// </summary>
        public Action<EAdShowResult> ResultCallback { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="resultCallback">Result callback</param>
        public AdShowOptions(Action<EAdShowResult> resultCallback)
        {
            ResultCallback = resultCallback;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="gamerSID">Gamer serial ID</param>
        /// <param name="resultCallback">Result callback</param>
        public AdShowOptions(string gamerSID, Action<EAdShowResult> resultCallback)
        {
            this.gamerSID = gamerSID;
            ResultCallback = resultCallback;
        }
    }
}
