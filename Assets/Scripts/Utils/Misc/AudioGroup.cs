using UnityEngine;
using UnityEngine.Audio;
using Utils.Objects;

/// <summary>
/// Utilities namespace
/// </summary>
namespace Utils
{
    /// <summary>
    /// Audio group data class
    /// </summary>
    public class AudioGroup
    {
        /// <summary>
        /// Audio sources
        /// </summary>
        private AudioSource[] audioSources;

        /// <summary>
        /// Is muted
        /// </summary>
        private bool isMuted;

        /// <summary>
        /// Current sounds index
        /// </summary>
        private uint currentSoundsIndex;

        /// <summary>
        /// Is muted
        /// </summary>
        public bool IsMuted
        {
            get
            {
                return isMuted;
            }
            set
            {
                if (isMuted != value)
                {
                    isMuted = value;
                }
            }
        }

        /// <summary>
        /// Volume
        /// </summary>
        public float Volume
        {
            get
            {
                return ((audioSources.Length > 0) ? audioSources[0].volume : 0.0f);
            }
            set
            {
                foreach (AudioSource audio_source in audioSources)
                {
                    if (audio_source != null)
                    {
                        audio_source.volume = Mathf.Clamp(value, 0.0f, 1.0f);
                    }
                }
            }
        }

        /// <summary>
        /// Spatialize
        /// </summary>
        public bool Spatialize
        {
            get
            {
                return ((audioSources.Length > 0) ? audioSources[0].spatialize : false);
            }
            set
            {
                foreach (AudioSource audio_source in audioSources)
                {
                    if (audio_source != null)
                    {
                        audio_source.spatialize = value;
                    }
                }
            }
        }

        /// <summary>
        /// Spatial blend
        /// </summary>
        public float SpatialBlend
        {
            get
            {
                return ((audioSources.Length > 0) ? audioSources[0].spatialBlend : 0.0f);
            }
            set
            {
                foreach (AudioSource audio_source in audioSources)
                {
                    if (audio_source != null)
                    {
                        audio_source.spatialBlend = Mathf.Clamp(value, 0.0f, 1.0f);
                    }
                }
            }
        }

        /// <summary>
        /// Play
        /// </summary>
        /// <param name="audioTranslation">Audio translation</param>
        public void Play(AudioTranslationObjectScript audioTranslation)
        {
            if (audioTranslation != null)
            {
                Play(audioTranslation.AudioClip);
            }
        }

        /// <summary>
        /// Play
        /// </summary>
        /// <param name="clip"></param>
        public void Play(AudioClip clip)
        {
            if (audioSources != null)
            {
                if (audioSources.Length > 0)
                {
                    AudioSource audio_source = audioSources[currentSoundsIndex];
                    if (audio_source != null)
                    {
                        audio_source.clip = clip;
                        if (!isMuted)
                        {
                            audio_source.Play();
                            ++currentSoundsIndex;
                        }
                        if (currentSoundsIndex >= audioSources.Length)
                        {
                            currentSoundsIndex = 0U;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="audioSources">Audio sources</param>
        private AudioGroup(AudioSource[] audioSources)
        {
            this.audioSources = audioSources;
        }

        /// <summary>
        /// Create audio group
        /// </summary>
        /// <param name="gameObject">Game object</param>
        /// <param name="soundChannelCount">Sound channel count</param>
        /// <param name="audioMixerGroup">Audio mixer group</param>
        /// <returns>Audio group if successful, otherwise "null"</returns>
        public static AudioGroup CreateAudioGroup(GameObject gameObject, uint soundChannelCount, AudioMixerGroup audioMixerGroup)
        {
            AudioGroup ret = null;
            if ((gameObject != null) && (soundChannelCount > 0U))
            {
                AudioSource[] audio_sources = new AudioSource[soundChannelCount];
                for (uint i = 0U; i != soundChannelCount; i++)
                {
                    AudioSource audio_source = gameObject.AddComponent<AudioSource>();
                    if (audio_source != null)
                    {
                        audio_source.playOnAwake = false;
                        audio_source.outputAudioMixerGroup = audioMixerGroup;
                    }
                    audio_sources[i] = audio_source;
                }
                ret = new AudioGroup(audio_sources);
            }
            return ret;
        }

        /// <summary>
        /// Create audio group
        /// </summary>
        /// <param name="gameObject">Game object</param>
        /// <param name="soundChannelCount">Sound channel count</param>
        /// <returns>Audio group if successful, otherwise "null"</returns>
        public static AudioGroup CreateAudioGroup(GameObject gameObject, uint soundChannelCount)
        {
            return CreateAudioGroup(gameObject, soundChannelCount, null);
        }
    }
}
