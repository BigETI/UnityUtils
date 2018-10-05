using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Utilities data class
/// </summary>
namespace Utils.Data
{
    /// <summary>
    /// Audio translation data class
    /// </summary>
    [Serializable]
    public class AudioTranslationData : IComparable<AudioTranslationData>
    {

        /// <summary>
        /// Audios
        /// </summary>
        [SerializeField]
        private TranslatedAudioData[] audios = new TranslatedAudioData[] { new TranslatedAudioData() };

        /// <summary>
        /// Lookup
        /// </summary>
        private Dictionary<SystemLanguage, AudioClip> lookup;

        /// <summary>
        /// Audios
        /// </summary>
        public IEnumerable<TranslatedAudioData> Audios
        {
            get
            {
                return audios;
            }
        }

        /// <summary>
        /// Audios
        /// </summary>
        public AudioClip AudioClip
        {
            get
            {
                AudioClip ret = null;
                if (lookup == null)
                {
                    lookup = new Dictionary<SystemLanguage, AudioClip>();
                    foreach (TranslatedAudioData audio in audios)
                    {
                        if (lookup.ContainsKey(audio.Language))
                        {
                            lookup[audio.Language] = audio.AudioClip;
                        }
                        else
                        {
                            lookup.Add(audio.Language, audio.AudioClip);
                        }
                    }
                }
                if (lookup.ContainsKey(Translator.SystemLanguage))
                {
                    ret = lookup[Translator.SystemLanguage];
                }
                else if (audios.Length > 0)
                {
                    ret = audios[0].AudioClip;
                }
                return ret;
            }
        }

        /// <summary>
        /// Compare to
        /// </summary>
        /// <param name="other">Other</param>
        /// <returns>Result</returns>
        public int CompareTo(AudioTranslationData other)
        {
            int ret = 1;
            if (other != null)
            {
                ret = ((AudioClip == null ? "" : AudioClip.name).CompareTo((other.AudioClip == null) ? "" : other.AudioClip.name));
            }
            return ret;
        }
    }
}
