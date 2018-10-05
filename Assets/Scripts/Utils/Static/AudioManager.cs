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
        /// Shuffle playlist
        /// </summary>
        public static void ShufflePlaylist()
        {
            if (AudioManagerScript.Instance != null)
            {
                AudioManagerScript.Instance.ShufflePlaylist();
            }
        }
    }
}
