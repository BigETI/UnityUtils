using UnityEngine;
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
        public static MusicTitleObjectScript[] Playlist
        {
            get
            {
                return (AudioManagerScript.Instance == null) ? (new MusicTitleObjectScript[0]) : AudioManagerScript.Instance.Playlist;
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
        public static void PlayMusic(MusicTitleObjectScript musicTitle)
        {
            if (AudioManagerScript.Instance != null)
            {
                AudioManagerScript.Instance.PlayMusic(musicTitle);
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
