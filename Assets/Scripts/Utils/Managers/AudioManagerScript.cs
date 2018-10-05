using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Utils.Data;
using Utils.Objects;

/// <summary>
/// Utilities managers namespace
/// </summary>
namespace Utils.Managers
{
    /// <summary>
    /// Audio manager script class
    /// </summary>
    public class AudioManagerScript : MonoBehaviour
    {
        /// <summary>
        /// Music audio mixer group
        /// </summary>
        [SerializeField]
        private AudioMixerGroup musicAudioMixerGroup;

        /// <summary>
        /// Sound effects audio mixer group
        /// </summary>
        [SerializeField]
        private AudioMixerGroup soundEffectsAudioMixerGroup;

        /// <summary>
        /// Sound channel count
        /// </summary>
        [SerializeField]
        private uint soundChannelCount = 8;

        /// <summary>
        /// Is muted
        /// </summary>
        [SerializeField]
        private bool isMuted;

        /// <summary>
        /// Start muted if game runs in mobile
        /// </summary>
        [SerializeField]
        private bool startMutedIfMobile;

        /// <summary>
        /// Load playlist from resources
        /// </summary>
        [SerializeField]
        private bool loadPlaylistFromResources = true;

        /// <summary>
        /// Resources path
        /// </summary>
        [SerializeField]
        private string resourcesPath = "MusicTitles";

        /// <summary>
        /// Current playlist index
        /// </summary>
        private uint currentPlaylistIndex;

        /// <summary>
        /// Current sounds index
        /// </summary>
        private uint currentSoundsIndex;

        /// <summary>
        /// Game paused
        /// </summary>
        private bool gamePaused;

        /// <summary>
        /// Playlist
        /// </summary>
        private MusicTitleData[] playlist;

        /// <summary>
        /// Music audio source
        /// </summary>
        private AudioSource musicAudioSource;

        /// <summary>
        /// Sound effects
        /// </summary>
        private AudioGroup soundEffectsAudioGroup;

        /// <summary>
        /// Instance
        /// </summary>
        private static AudioManagerScript instance;

        /// <summary>
        /// Playlist
        /// </summary>
        public MusicTitleData[] Playlist
        {
            get
            {
                if (playlist == null)
                {
                    playlist = new MusicTitleData[0];
                }
                return playlist;
            }
            set
            {
                if (value != null)
                {
                    bool is_playing_music = IsPlayingMusic;
                    List<MusicTitleData> list = new List<MusicTitleData>();
                    foreach (MusicTitleData music_title in value)
                    {
                        if (music_title != null)
                        {
                            list.Add(new MusicTitleData(music_title));
                        }
                    }
                    if (is_playing_music)
                    {
                        IsMuted = true;
                    }
                    playlist = list.ToArray();
                    list.Clear();
                    if (is_playing_music)
                    {
                        IsMuted = false;
                    }
                    currentPlaylistIndex = 0U;
                }
            }
        }

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
                    if (isMuted)
                    {
                        if (musicAudioSource != null)
                        {
                            musicAudioSource.Stop();
                        }
                        if (MusicUIManagerScript.Instance != null)
                        {
                            MusicUIManagerScript.Instance.HidePlay();
                        }
                    }
                    else
                    {
                        if (Playlist.Length > 0)
                        {
                            PlayCurrentMusic();
                        }
                    }
                    Game.AnalyticsEvent(isMuted ? "muteAudio" : "unmuteAudio");
                }
            }
        }

        /// <summary>
        /// Music volume
        /// </summary>
        public float MusicVolume
        {
            get
            {
                return ((musicAudioSource == null) ? 0.0f : musicAudioSource.volume);
            }
            set
            {
                if (musicAudioSource != null)
                {
                    musicAudioSource.volume = Mathf.Clamp(value, 0.0f, 1.0f);
                }
            }
        }

        /// <summary>
        /// Sound effects volume
        /// </summary>
        public float SoundEffectsVolume
        {
            get
            {
                return ((soundEffectsAudioGroup == null) ? 0.0f : soundEffectsAudioGroup.Volume);
            }
            set
            {
                if (soundEffectsAudioGroup != null)
                {
                    soundEffectsAudioGroup.Volume = value;
                }
            }
        }

        /// <summary>
        /// Is playing music
        /// </summary>
        public bool IsPlayingMusic
        {
            get
            {
                return ((musicAudioSource == null) ? false : musicAudioSource.isPlaying);
            }
        }

        /// <summary>
        /// Instance
        /// </summary>
        public static AudioManagerScript Instance
        {
            get
            {
                return instance;
            }
        }

        /// <summary>
        /// Play current music
        /// </summary>
        private void PlayCurrentMusic()
        {
            if ((Playlist.Length > 0) && (musicAudioSource != null))
            {
                MusicTitleData music_title = Playlist[currentPlaylistIndex];
                musicAudioSource.clip = music_title.AudioClip;
                if (!isMuted)
                {
                    musicAudioSource.Play();
                    if (MusicUIManagerScript.Instance != null)
                    {
                        MusicUIManagerScript.Instance.ShowPlay(music_title);
                    }
                }
            }
        }

        /// <summary>
        /// Play next music
        /// </summary>
        public void PlayNextMusic()
        {
            if (Playlist.Length > 0)
            {
                ++currentPlaylistIndex;
                if (currentPlaylistIndex >= Playlist.Length)
                {
                    currentPlaylistIndex = 0U;
                }
                PlayCurrentMusic();
            }
        }

        /// <summary>
        /// Play sound effect
        /// </summary>
        /// <param name="audioTranslation">Audio translation</param>
        public void PlaySoundEffect(AudioTranslationObjectScript audioTranslation)
        {
            if (audioTranslation != null)
            {
                PlaySoundEffect(audioTranslation.AudioClip);
            }
        }

        /// <summary>
        /// Play sound effect
        /// </summary>
        /// <param name="clip"></param>
        public void PlaySoundEffect(AudioClip clip)
        {
            if (soundEffectsAudioGroup != null)
            {
                soundEffectsAudioGroup.Play(clip);
            }
        }

        /// <summary>
        /// Play music
        /// </summary>
        /// <param name="musicTitle">Music title</param>
        public void PlayMusic(MusicTitleData musicTitle)
        {
            if ((musicTitle != null) && (musicAudioSource != null))
            {
                musicAudioSource.clip = musicTitle.AudioClip;
                if (!isMuted)
                {
                    musicAudioSource.Play();
                    if (MusicUIManagerScript.Instance != null)
                    {
                        MusicUIManagerScript.Instance.ShowPlay(musicTitle);
                    }
                }
            }
        }

        /// <summary>
        /// Play music
        /// </summary>
        /// <param name="musicTitle">Music title</param>
        public void PlayMusic(MusicTitleObjectScript musicTitle)
        {
            if (musicTitle != null)
            {
                PlayMusic(new MusicTitleData(musicTitle, ResourcesPath));
            }
        }

        /// <summary>
        /// Play music
        /// </summary>
        /// <param name="audioTranslation">Audio translation</param>
        public void PlayMusic(AudioTranslationObjectScript audioTranslation)
        {
            if (audioTranslation != null)
            {
                PlayMusic(audioTranslation.AudioClip);
            }
        }

        /// <summary>
        /// Play music
        /// </summary>
        /// <param name="audioClip">Audio clip</param>
        public void PlayMusic(AudioClip audioClip)
        {
            if ((audioClip != null) && (musicAudioSource != null))
            {
                musicAudioSource.clip = audioClip;
                if (!isMuted)
                {
                    musicAudioSource.Play();
                }
            }
        }

        /// <summary>
        /// Replay music
        /// </summary>
        public void ReplayMusic()
        {
            if (musicAudioSource != null)
            {
                musicAudioSource.Stop();
                musicAudioSource.Play();
            }
        }

        /// <summary>
        /// Shuffle playlist
        /// </summary>
        public void ShufflePlaylist()
        {
            Playlist = Algorithm.Shuffle(Playlist);
        }

        /// <summary>
        /// Awake
        /// </summary>
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
            if (startMutedIfMobile)
            {
                isMuted = Game.IsMobile;
            }
        }

        /// <summary>
        /// Load playlist from resources
        /// </summary>
        /// <param name="path">Path</param>
        public void LoadPlaylistFromResources(string path)
        {
            MusicTitleObjectScript[] playlist_objects = Resources.LoadAll<MusicTitleObjectScript>(path);
            if (playlist_objects != null)
            {
                MusicTitleData[] playlist = new MusicTitleData[playlist_objects.Length];
                for (int i = 0; i < playlist.Length; i++)
                {
                    playlist[i] = new MusicTitleData(playlist_objects[i], path);
                }
                Playlist = playlist;
            }
            else
            {
                Playlist = new MusicTitleData[0];
            }
        }

        /// <summary>
        /// Resources path
        /// </summary>
        public string ResourcesPath
        {
            get
            {
                if (resourcesPath == null)
                {
                    resourcesPath = "MusicTitles";
                }
                return resourcesPath;
            }
        }

        /// <summary>
        /// Load playlist from resources
        /// </summary>
        public void LoadPlaylistFromResources()
        {
            LoadPlaylistFromResources(ResourcesPath);
        }

        /// <summary>
        /// Start
        /// </summary>
        private void Start()
        {
            if (loadPlaylistFromResources)
            {
                LoadPlaylistFromResources();
            }
            musicAudioSource = gameObject.AddComponent<AudioSource>();
            if (musicAudioSource != null)
            {
                musicAudioSource.playOnAwake = false;
                musicAudioSource.volume = MusicVolume;
                musicAudioSource.outputAudioMixerGroup = musicAudioMixerGroup;
            }
            soundEffectsAudioGroup = AudioGroup.CreateAudioGroup(gameObject, soundChannelCount, soundEffectsAudioMixerGroup);
            ShufflePlaylist();
            PlayCurrentMusic();
        }

        /// <summary>
        /// Update
        /// </summary>
        private void Update()
        {
            if (!isMuted)
            {
                if ((!gamePaused) && (!IsPlayingMusic))
                {
                    PlayNextMusic();
                }
            }
        }

        /// <summary>
        /// On application pause
        /// </summary>
        /// <param name="pause">Pause</param>
        private void OnApplicationPause(bool pause)
        {
            gamePaused = pause;
        }
    }
}
