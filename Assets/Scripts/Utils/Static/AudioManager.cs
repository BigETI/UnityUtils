using UnityEngine;
using Utils.Data;
using Utils.Managers;
using Utils.Objects;

/// <summary>
/// Utilities namespace
/// </summary>
namespace Utils
{
    /// <summary>
    /// Audio manager class
    /// </summary>
    public static class AudioManager
    {

        /// <summary>
        /// Playlist
        /// </summary>
        public static MusicTitleData[] Playlist
        {
            get
            {
                return (AudioManagerScript.Instance == null) ? (new MusicTitleData[0]) : AudioManagerScript.Instance.Playlist;
            }
            set
            {
                if (AudioManagerScript.Instance != null)
                {
                    AudioManagerScript.Instance.Playlist = value;
                }
            }
        }

        /// <summary>
        /// Music audio source
        /// </summary>
        public static AudioSource MusicAudioSource
        {
            get
            {
                return (AudioManagerScript.Instance == null) ? null : AudioManagerScript.Instance.MusicAudioSource;
            }
        }

        /// <summary>
        /// Sound effects
        /// </summary>
        public static AudioGroup SoundEffectsAudioGroup
        {
            get
            {
                return (AudioManagerScript.Instance == null) ? null : AudioManagerScript.Instance.SoundEffectsAudioGroup;
            }
        }

        /// <summary>
        /// Is muted
        /// </summary>
        public static bool IsMuted
        {
            get
            {
                return ((AudioManagerScript.Instance == null) ? true : AudioManagerScript.Instance.IsMuted);
            }
            set
            {
                if (AudioManagerScript.Instance != null)
                {
                    AudioManagerScript.Instance.IsMuted = value;
                }
            }
        }

        /// <summary>
        /// Music volume
        /// </summary>
        public static float MusicVolume
        {
            get
            {
                return ((AudioManagerScript.Instance == null) ? 0.0f : AudioManagerScript.Instance.MusicVolume);
            }
            set
            {
                if (AudioManagerScript.Instance != null)
                {
                    AudioManagerScript.Instance.MusicVolume = value;
                }
            }
        }

        /// <summary>
        /// Sound effects volume
        /// </summary>
        public static float SoundEffectsVolume
        {
            get
            {
                return ((AudioManagerScript.Instance == null) ? 0.0f : AudioManagerScript.Instance.SoundEffectsVolume);
            }
            set
            {
                if (AudioManagerScript.Instance != null)
                {
                    AudioManagerScript.Instance.SoundEffectsVolume = value;
                }
            }
        }

        /// <summary>
        /// Resources path
        /// </summary>
        public static string ResourcesPath
        {
            get
            {
                return ((AudioManagerScript.Instance == null) ? "MusicTitles" : AudioManagerScript.Instance.ResourcesPath);
            }
        }

        /// <summary>
        /// Music time
        /// </summary>
        /// <remarks>This property is inconsistent, if audio is compressed!</remarks>
        public static float MusicTime
        {
            get
            {
                return ((AudioManagerScript.Instance == null) ? 0.0f : AudioManagerScript.Instance.MusicTime);
            }
            set
            {
                if (AudioManagerScript.Instance != null)
                {
                    AudioManagerScript.Instance.MusicTime = value;
                }
            }
        }

        /// <summary>
        /// Music time in samples
        /// </summary>
        /// <remarks>This property is inconsistent, if audio is compressed!</remarks>
        public static int MusicTimeSamples
        {
            get
            {
                return ((AudioManagerScript.Instance == null) ? 0 : AudioManagerScript.Instance.MusicTimeSamples);
            }
            set
            {
                if (AudioManagerScript.Instance != null)
                {
                    AudioManagerScript.Instance.MusicTimeSamples = value;
                }
            }
        }

        /// <summary>
        /// Music frequency
        /// </summary>
        public static int MusicFrequency
        {
            get
            {
                return ((AudioManagerScript.Instance == null) ? 0 : AudioManagerScript.Instance.MusicFrequency);
            }
        }

        /// <summary>
        /// Music audio clip samples
        /// </summary>
        public static int MusicAudioClipSamples
        {
            get
            {
                return ((AudioManagerScript.Instance == null) ? 0 : AudioManagerScript.Instance.MusicAudioClipSamples);
            }
        }

        /// <summary>
        /// Music audio clip
        /// </summary>
        public static AudioClip MusicAudioClip
        {
            get
            {
                return ((AudioManagerScript.Instance == null) ? null : AudioManagerScript.Instance.MusicAudioClip);
            }
        }

        /// <summary>
        /// Is playing music
        /// </summary>
        public static bool IsPlayingMusic
        {
            get
            {
                return ((AudioManagerScript.Instance == null) ? false : AudioManagerScript.Instance.IsPlayingMusic);
            }
        }

        /// <summary>
        /// Play next music
        /// </summary>
        public static void PlayNextMusic()
        {
            if (AudioManagerScript.Instance != null)
            {
                AudioManagerScript.Instance.PlayNextMusic();
            }
        }

        /// <summary>
        /// Play sound effect
        /// </summary>
        /// <param name="audioTranslation">Audio translation</param>
        public static void PlaySoundEffect(AudioTranslationObjectScript audioTranslation)
        {
            if (AudioManagerScript.Instance != null)
            {
                AudioManagerScript.Instance.PlaySoundEffect(audioTranslation);
            }
        }

        /// <summary>
        /// Play sound effect
        /// </summary>
        /// <param name="clip"></param>
        public static void PlaySoundEffect(AudioClip clip)
        {
            if (AudioManagerScript.Instance != null)
            {
                AudioManagerScript.Instance.PlaySoundEffect(clip);
            }
        }

        /// <summary>
        /// Play music
        /// </summary>
        /// <param name="musicTitle">Music title</param>
        public static void PlayMusic(MusicTitleData musicTitle)
        {
            if (AudioManagerScript.Instance != null)
            {
                AudioManagerScript.Instance.PlayMusic(musicTitle);
            }
        }

        /// <summary>
        /// Play music
        /// </summary>
        /// <param name="musicTitle">Music title</param>
        public static void PlayMusic(MusicTitleObjectScript musicTitle)
        {
            if (AudioManagerScript.Instance != null)
            {
                AudioManagerScript.Instance.PlayMusic(musicTitle);
            }
        }

        /// <summary>
        /// Play music
        /// </summary>
        /// <param name="audioTranslation">Audio translation</param>
        public static void PlayMusic(AudioTranslationObjectScript audioTranslation)
        {
            if (AudioManagerScript.Instance != null)
            {
                AudioManagerScript.Instance.PlayMusic(audioTranslation);
            }
        }

        /// <summary>
        /// Play music
        /// </summary>
        /// <param name="audioClip">Audio clip</param>
        public static void PlayMusic(AudioClip audioClip)
        {
            if (AudioManagerScript.Instance != null)
            {
                AudioManagerScript.Instance.PlayMusic(audioClip);
            }
        }

        /// <summary>
        /// Play music delayed
        /// </summary>
        /// <param name="musicTitle">Music title</param>
        /// <param name="delay">Delay</param>
        public static void PlayMusicDelayed(MusicTitleData musicTitle, float delay)
        {
            if (AudioManagerScript.Instance != null)
            {
                AudioManagerScript.Instance.PlayMusicDelayed(musicTitle, delay);
            }
        }

        /// <summary>
        /// Play music delayed
        /// </summary>
        /// <param name="musicTitle">Music title</param>
        /// <param name="delay">Delay</param>
        public static void PlayMusicDelayed(MusicTitleObjectScript musicTitle, float delay)
        {
            if (AudioManagerScript.Instance != null)
            {
                AudioManagerScript.Instance.PlayMusicDelayed(musicTitle, delay);
            }
        }

        /// <summary>
        /// Play music delayed
        /// </summary>
        /// <param name="audioTranslation">Audio translation</param>
        /// <param name="delay">Delay</param>
        public static void PlayMusicDelayed(AudioTranslationObjectScript audioTranslation, float delay)
        {
            if (AudioManagerScript.Instance != null)
            {
                AudioManagerScript.Instance.PlayMusicDelayed(audioTranslation, delay);
            }
        }

        /// <summary>
        /// Play music delayed
        /// </summary>
        /// <param name="audioClip">Audio clip</param>
        /// <param name="delay">Delay</param>
        public static void PlayMusicDelayed(AudioClip audioClip, float delay)
        {
            if (AudioManagerScript.Instance != null)
            {
                AudioManagerScript.Instance.PlayMusicDelayed(audioClip, delay);
            }
        }

        /// <summary>
        /// Replay music
        /// </summary>
        public static void ReplayMusic()
        {
            if (AudioManagerScript.Instance != null)
            {
                AudioManagerScript.Instance.ReplayMusic();
            }
        }

        /// <summary>
        /// Stop music
        /// </summary>
        public static void StopMusic()
        {
            if (AudioManagerScript.Instance != null)
            {
                AudioManagerScript.Instance.StopMusic();
            }
        }

        /// <summary>
        /// Shuffle playlist
        /// </summary>
        public static void ShufflePlaylist()
        {
            if (AudioManagerScript.Instance != null)
            {
                AudioManagerScript.Instance.ShufflePlaylist();
            }
        }

        /// <summary>
        /// Load playlist from resources
        /// </summary>
        /// <param name="path">Path</param>
        public static void LoadPlaylistFromResources(string path)
        {
            if (AudioManagerScript.Instance != null)
            {
                AudioManagerScript.Instance.LoadPlaylistFromResources(path);
            }
        }
    }
}
