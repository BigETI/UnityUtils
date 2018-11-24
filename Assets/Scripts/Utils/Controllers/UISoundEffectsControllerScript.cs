using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Utils.Data;

/// <summary>
/// Utilities controllers namespace
/// </summary>
namespace Utils.Controllers
{
    /// <summary>
    /// UI sound effects controller script class
    /// </summary>
    [RequireComponent(typeof(EventTrigger))]
    public class UISoundEffectsControllerScript : MonoBehaviour
    {
        /// <summary>
        /// Randomize sound selection
        /// </summary>
        [SerializeField]
        private bool randomizeSoundSelection;

        /// <summary>
        /// Sound effects
        /// </summary>
        [SerializeField]
        private UISoundEffectData[] soundEffects;

        /// <summary>
        /// Sound effects dictionary
        /// </summary>
        private Dictionary<EEventTriggerType, List<AudioClip>> soundEffectsDictionary;

        /// <summary>
        /// Toggle fix
        /// </summary>
        private bool toggleFix;

        /// <summary>
        /// Sound effects
        /// </summary>
        private UISoundEffectData[] SoundEffects
        {
            get
            {
                if (soundEffects == null)
                {
                    soundEffects = new UISoundEffectData[0];
                }
                return soundEffects;
            }
        }

        /// <summary>
        /// Sound effects dictionary
        /// </summary>
        private Dictionary<EEventTriggerType, List<AudioClip>> SoundEffectsDictionary
        {
            get
            {
                if (soundEffectsDictionary == null)
                {
                    soundEffectsDictionary = new Dictionary<EEventTriggerType, List<AudioClip>>();
                    foreach (UISoundEffectData sound_effect in SoundEffects)
                    {
                        if (sound_effect != null)
                        {
                            if (sound_effect.SoundEffectAudioClip != null)
                            {
                                List<AudioClip> audio_clips = null;
                                if (soundEffectsDictionary.ContainsKey(sound_effect.EventTriggerType))
                                {
                                    audio_clips = soundEffectsDictionary[sound_effect.EventTriggerType];
                                }
                                else
                                {
                                    audio_clips = new List<AudioClip>();
                                    soundEffectsDictionary.Add(sound_effect.EventTriggerType, audio_clips);
                                }
                                audio_clips.Add(sound_effect.SoundEffectAudioClip);
                            }
                        }
                    }
                }
                return soundEffectsDictionary;
            }
        }

        /// <summary>
        /// Trigger event
        /// </summary>
        /// <param name="eventTriggerType">Event trigger type</param>
        private void TriggerEvent(EEventTriggerType eventTriggerType)
        {
            if (SoundEffectsDictionary.ContainsKey(eventTriggerType))
            {
                if (randomizeSoundSelection)
                {
                    List<AudioClip> audio_clips = SoundEffectsDictionary[eventTriggerType];
                    if (audio_clips.Count > 0)
                    {
                        AudioManager.PlaySoundEffect(audio_clips[Random.Range(0, audio_clips.Count)]);
                    }
                }
                else
                {
                    foreach (AudioClip audio_clip in SoundEffectsDictionary[eventTriggerType])
                    {
                        AudioManager.PlaySoundEffect(audio_clip);
                    }
                }
            }
        }

        /// <summary>
        /// Start
        /// </summary>
        private void Start()
        {
            EventTrigger event_trigger = GetComponent<EventTrigger>();
            if (event_trigger != null)
            {
                foreach (EventTrigger.Entry entry in event_trigger.triggers)
                {
                    entry.callback.AddListener((baseEvent) =>
                    {
                        TriggerEvent((EEventTriggerType)(entry.eventID));
                    });
                }
            }
            Button button = GetComponent<Button>();
            if (button != null)
            {
                button.onClick.AddListener(() =>
                {
                    TriggerEvent(EEventTriggerType.Click);
                });
            }
            InputField input_field = GetComponent<InputField>();
            if (input_field != null)
            {
                input_field.onValueChanged.AddListener((value) =>
                {
                    TriggerEvent(EEventTriggerType.ValueChanged);
                });
                input_field.onEndEdit.AddListener((value) =>
                {
                    TriggerEvent(EEventTriggerType.EndEdit);
                });
            }
            Slider slider = GetComponent<Slider>();
            if (slider != null)
            {
                slider.onValueChanged.AddListener((value) =>
                {
                    TriggerEvent(EEventTriggerType.ValueChanged);
                });
            }
            Toggle toggle = GetComponent<Toggle>();
            if (toggle != null)
            {
                toggleFix = toggle.isOn;
                toggle.onValueChanged.AddListener((value) =>
                {
                    if (toggleFix != value)
                    {
                        toggleFix = value;
                        TriggerEvent(EEventTriggerType.ValueChanged);
                    }
                });
            }
        }
    }
}
