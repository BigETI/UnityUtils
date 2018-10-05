using System;
using UnityEngine;
using Utils.Data;

/// <summary>
/// Utilities objects namespace
/// </summary>
namespace Utils.Objects
{
    /// <summary>
    /// Audio translation object script class
    /// </summary>
    [CreateAssetMenu(fileName = "AudioTranslation", menuName = "Utils/AudioTranslation")]
    public class AudioTranslationObjectScript : ScriptableObject, IComparable<AudioTranslationObjectScript>
    {
        /// <summary>
        /// Audio translation
        /// </summary>
        [SerializeField]
        private AudioTranslationData audioTranslation;

        /// <summary>
        /// Comment
        /// </summary>
        [TextArea]
        [SerializeField]
        private string comment;

        /// <summary>
        /// Audio translation
        /// </summary>
        public AudioTranslationData AudioTranslation
        {
            get
            {
                return audioTranslation;
            }
        }

        /// <summary>
        /// Audio clip
        /// </summary>
        public AudioClip AudioClip
        {
            get
            {
                return ((audioTranslation == null) ? null : audioTranslation.AudioClip);
            }
        }

        /// <summary>
        /// Comment
        /// </summary>
        public string Comment
        {
            get
            {
                return comment;
            }
        }

        /// <summary>
        /// Compare to
        /// </summary>
        /// <param name="other">Other</param>
        /// <returns>Result</returns>
        public int CompareTo(AudioTranslationObjectScript other)
        {
            int ret = 1;
            if (other != null)
            {
                ret = name.CompareTo(other.name);
            }
            return ret;
        }
    }
}
