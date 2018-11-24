using System;
using UnityEngine;

/// <summary>
/// Utilities data namespace
/// </summary>
namespace Utils.Data
{
    /// <summary>
    /// UI sound effect data
    /// </summary>
    [Serializable]
    public class UISoundEffectData
    {
        /// <summary>
        /// Sound effect audio clip
        /// </summary>
        [SerializeField]
        private AudioClip soundEffectAudioClip;

        /// <summary>
        /// Event trigger type
        /// </summary>
        [SerializeField]
        private EEventTriggerType eventTriggerType;

        /// <summary>
        /// Sound effect audio clip
        /// </summary>
        public AudioClip SoundEffectAudioClip
        {
            get
            {
                return soundEffectAudioClip;
            }
        }

        /// <summary>
        /// Event trigger type
        /// </summary>
        public EEventTriggerType EventTriggerType
        {
            get
            {
                return eventTriggerType;
            }
        }
    }
}
