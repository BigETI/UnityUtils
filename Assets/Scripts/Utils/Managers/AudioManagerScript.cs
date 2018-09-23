using UnityEngine;
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
        /// Sound channel count
        /// </summary>
        [SerializeField]
        private uint soundChannelCount = 8;

        /// <summary>
        /// Is muted
        /// </summary>
        [SerializeField]
        private bool isMuted = false;

        /// <summary>
        /// Start muted if game runs in mobile
        /// </summary>
        [SerializeField]
        private bool startMutedIfMobile = false;

        /// <summary>
        /// Current playlist index
        /// </summary>
        private uint currentPlaylistIndex = 0U;

        /// <summary>
        /// Current sounds index
        /// </summary>
        private uint currentSoundsIndex = 0U;

        /// <summary>
        /// Game paused
        /// </summary>
        private bool gamePaused = false;

        /// <summary>
        /// Playlist
        /// </summary>
        private MusicTitleObjectScript[] playlist;

        /// <summary>
        /// Music audio source
        /// </summary>
        private AudioSource musicAudioSource;

        /// <summary>
        /// Sounds audio sources
        /// </summary>
        private AudioSource[] soundsAudioSources;

        /// <summary>
        /// Instance
        /// </summary>
        private static AudioManagerScript instance;

        /// <summary>
        /// Playlist
        /// </summary>
        public MusicTitleObjectScript[] Playlist
        {
            get
            {
                return playlist;
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
                        musicAudioSource.Stop();
                        if (MusicUIManagerScript.Instance != null)
                        {
                            MusicUIManagerScript.Instance.HidePlay();
                        }
                    }
                    else
                    {
                        if (playlist.Length > 0)
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
                return musicAudioSource.volume;
            }
            set
            {
                musicAudioSource.volume = value;
            }
        }

        /// <summary>
        /// Sound effects volume
        /// </summary>
        public float SoundEffectsVolume
        {
            get
            {
                return ((soundsAudioSources.Length > 0) ? soundsAudioSources[0].volume : 0.0f);
            }
            set
            {
                foreach (AudioSource sounds_audio_source in soundsAudioSources)
                {
                    sounds_audio_source.volume = value;
                }
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
            if (playlist.Length > 0)
            {
                MusicTitleObjectScript music_title = playlist[currentPlaylistIndex];
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
            if (playlist != null)
            {
                if (playlist.Length > 0)
                {
                    ++currentPlaylistIndex;
                    if (currentPlaylistIndex >= playlist.Length)
                    {
                        currentPlaylistIndex = 0U;
                    }
                    PlayCurrentMusic();
                }
            }
        }

        /// <summary>
        /// Play sound effect
        /// </summary>
        /// <param name="clip"></param>
        public void PlaySoundEffect(AudioClip clip)
        {
            if (soundsAudioSources != null)
            {
                if (soundsAudioSources.Length > 0)
                {
                    AudioSource audio_source = soundsAudioSources[currentSoundsIndex];

                    audio_source.clip = clip;
                    if (!isMuted)
                    {
                        audio_source.Play();
                        ++currentSoundsIndex;
                    }
                    if (currentSoundsIndex >= soundsAudioSources.Length)
                    {
                        currentSoundsIndex = 0U;
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
        /// Shuffle playlist
        /// </summary>
        public void ShufflePlaylist()
        {
            playlist = Algorithm.Shuffle(playlist);
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
        /// Start
        /// </summary>
        private void Start()
        {
            playlist = Resources.LoadAll<MusicTitleObjectScript>("MusicTitles");
            musicAudioSource = gameObject.AddComponent<AudioSource>();
            musicAudioSource.playOnAwake = false;
            musicAudioSource.volume = 0.25f;
            soundsAudioSources = new AudioSource[soundChannelCount];
            for (uint i = 0U; i != soundChannelCount; i++)
            {
                soundsAudioSources[i] = gameObject.AddComponent<AudioSource>();
                soundsAudioSources[i].playOnAwake = false;
            }
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
                if ((!gamePaused) && (!(musicAudioSource.isPlaying)))
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
