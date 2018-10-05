using System;
using UnityEngine;

/// <summary>
/// Utilities data namespace
/// </summary>
namespace Utils.Data
{
    /// <summary>
    /// Translated audio data class
    /// </summary>
    [Serializable]
    public class TranslatedAudioData
    {
        /// <summary>
        /// Audio clip
        /// </summary>
        [TextArea]
        [SerializeField]
        private AudioClip audioClip;

        /// <summary>
        /// Language
        /// </summary>
        [SerializeField]
        private SystemLanguage language = SystemLanguage.English;

        /// <summary>
        /// Text
        /// </summary>
        public AudioClip AudioClip
        {
            get
            {
                return audioClip;
            }
        }

        /// <summary>
        /// Language
        /// </summary>
        public SystemLanguage Language
        {
            get
            {
                return language;
            }
        }

        /// <summary>
        /// To string
        /// </summary>
        /// <returns>String representation</returns>
        public override string ToString()
        {
            return ((audioClip == null) ? "" : audioClip.name);
        }
    }
}
