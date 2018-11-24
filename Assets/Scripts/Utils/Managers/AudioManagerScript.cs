using System.Collections.Generic;
using UnityEngine;
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
        /// Sound channel count
        /// </summary>
        [SerializeField]
        private uint soundChannelCount = 8;

        /// <summary>
        /// Resources path
        /// </summary>
        [SerializeField]
        private string resourcesPath = "MusicTitles";

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
        /// Anlayze music audio clip samples
        /// </summary>
        [SerializeField]
        private bool analyzeMusicAudioClipSamples;

        /// <summary>
        /// Music audio settings
        /// </summary>
        [SerializeField]
        private AudioSettingsData musicAudioSettings;

        /// <summary>
        /// Sound effects audio settings
        /// </summary>
        [SerializeField]
        private AudioSettingsData soundEffectsAudioSettings;

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
        /// Analyze music audio source
        /// </summary>
        private AudioSource analyzeMusicAudioSource;

        /// <summary>
        /// Sound effects
        /// </summary>
        private AudioGroup soundEffectsAudioGroup;

        /// <summary>
        /// Music audio clip samples
        /// </summary>
        private int musicAudioClipSamples;

        /// <summary>
        /// Analyzed samples
        /// </summary>
        private int analyzedSamples = 0;

        /// <summary>
        /// Analyze music numerator
        /// </summary>
        private long analyzeMusicNumerator;

        /// <summary>
        /// Analyze music denominator
        /// </summary>
        private long analyzeMusicDenominator;

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
        /// Music audio source
        /// </summary>
        public AudioSource MusicAudioSource
        {
            get
            {
                return musicAudioSource;
            }
        }

        /// <summary>
        /// Sound effects
        /// </summary>
        public AudioGroup SoundEffectsAudioGroup
        {
            get
            {
                return soundEffectsAudioGroup;
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
                    if (soundEffectsAudioGroup != null)
                    {
                        soundEffectsAudioGroup.IsMuted = isMuted;
                    }
                    Game.AnalyticsEvent(isMuted ? "muteAudio" : "unmuteAudio");
                }
            }
        }

        /// <summary>
        /// Music audio settings
        /// </summary>
        private AudioSettingsData MusicAudioSettings
        {
            get
            {
                if (musicAudioSettings == null)
                {
                    musicAudioSettings = new AudioSettingsData();
                }
                return musicAudioSettings;
            }
        }

        /// <summary>
        /// Sound effects audio settings
        /// </summary>
        private AudioSettingsData SoundEffectsAudioSettings
        {
            get
            {
                if (soundEffectsAudioSettings == null)
                {
                    soundEffectsAudioSettings = new AudioSettingsData();
                }
                return soundEffectsAudioSettings;
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
        /// Music time
        /// </summary>
        /// <remarks>This property is inconsistent, if audio is compressed!</remarks>
        public float MusicTime
        {
            get
            {
                return ((musicAudioSource == null) ? 0.0f : ((musicAudioSource.clip == null) ? 0.0f : musicAudioSource.time));
            }
            set
            {
                if (musicAudioSource != null)
                {
                    musicAudioSource.time = Mathf.Clamp(value, 0.0f, ((MusicAudioClip == null) ? 0.0f : Mathf.Max(0.0f, MusicAudioClip.length - 0.01f)));
                }
            }
        }

        /// <summary>
        /// Music time in samples
        /// </summary>
        /// <remarks>This property is inconsistent, if audio is compressed!</remarks>
        public int MusicTimeSamples
        {
            get
            {
                return ((musicAudioSource == null) ? 0 : ((musicAudioSource.clip == null) ? 0 : musicAudioSource.timeSamples));
            }
            set
            {
                if (musicAudioSource != null)
                {
                    musicAudioSource.timeSamples = ((MusicAudioClip == null) ? 0 : Mathf.Max(0, value - 1));
                }
            }
        }

        /// <summary>
        /// Music frequency
        /// </summary>
        public int MusicFrequency
        {
            get
            {
                return ((musicAudioSource == null) ? 1 : ((musicAudioSource.clip == null) ? 1 : musicAudioSource.clip.frequency));
            }
        }

        /// <summary>
        /// Music audio clip samples
        /// </summary>
        public int MusicAudioClipSamples
        {
            get
            {
                return ((analyzeMusicAudioClipSamples) ? musicAudioClipSamples : ((MusicAudioClip == null) ? 0 : MusicAudioClip.samples));
            }
        }

        /// <summary>
        /// Music audio clip
        /// </summary>
        public AudioClip MusicAudioClip
        {
            get
            {
                return ((musicAudioSource == null) ? null : musicAudioSource.clip);
            }
            private set
            {
                if (musicAudioSource != null)
                {
                    musicAudioSource.clip = value;
                    if (analyzeMusicAudioSource != null)
                    {
                        analyzeMusicAudioSource.clip = value;
                        analyzeMusicNumerator = 1L;
                        analyzeMusicDenominator = 1L;
                        analyzedSamples = Mathf.Max(0, value.samples - 1);
                        musicAudioClipSamples = value.samples;
                        analyzeMusicAudioSource.timeSamples = analyzedSamples;
                        analyzeMusicAudioSource.Play();
                    }
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
            if ((Playlist.Length > 0) && (musicAudioSource != null))
            {
                MusicTitleData music_title = Playlist[currentPlaylistIndex];
                MusicAudioClip = music_title.AudioClip;
                if (!isMuted)
                {
                    musicAudioSource.timeSamples = 0;
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
                MusicAudioClip = musicTitle.AudioClip;
                if (!isMuted)
                {
                    musicAudioSource.timeSamples = 0;
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
                MusicAudioClip = audioClip;
                if (!isMuted)
                {
                    musicAudioSource.timeSamples = 0;
                    musicAudioSource.Play();
                }
            }
        }

        /// <summary>
        /// Play music delayed
        /// </summary>
        /// <param name="musicTitle">Music title</param>
        /// <param name="delay">Delay</param>
        public void PlayMusicDelayed(MusicTitleData musicTitle, float delay)
        {
            float d = Mathf.Max(delay, 0.0f);
            if ((musicTitle != null) && (musicAudioSource != null))
            {
                MusicAudioClip = musicTitle.AudioClip;
                if (!isMuted)
                {
                    musicAudioSource.PlayDelayed(d);
                    if (MusicUIManagerScript.Instance != null)
                    {
                        MusicUIManagerScript.Instance.ShowPlay(musicTitle);
                    }
                }
            }
        }

        /// <summary>
        /// Play music delayed
        /// </summary>
        /// <param name="musicTitle">Music title</param>
        /// <param name="delay">Delay</param>
        public void PlayMusicDelayed(MusicTitleObjectScript musicTitle, float delay)
        {
            if (musicTitle != null)
            {
                PlayMusicDelayed(new MusicTitleData(musicTitle, ResourcesPath), delay);
            }
        }

        /// <summary>
        /// Play music delayed
        /// </summary>
        /// <param name="audioTranslation">Audio translation</param>
        /// <param name="delay">Delay</param>
        public void PlayMusicDelayed(AudioTranslationObjectScript audioTranslation, float delay)
        {
            if (audioTranslation != null)
            {
                PlayMusicDelayed(audioTranslation.AudioClip, delay);
            }
        }

        /// <summary>
        /// Play music
        /// </summary>
        /// <param name="audioClip">Audio clip</param>
        /// <param name="delay">Delay</param>
        public void PlayMusicDelayed(AudioClip audioClip, float delay)
        {
            float d = Mathf.Max(0.0f, delay);
            if ((audioClip != null) && (musicAudioSource != null))
            {
                MusicAudioClip = audioClip;
                if (!isMuted)
                {
                    musicAudioSource.timeSamples = 0;
                    musicAudioSource.PlayDelayed(d);
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
        /// Stop music
        /// </summary>
        public void StopMusic()
        {
            if (musicAudioSource != null)
            {
                musicAudioSource.Stop();
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
        /// Load playlist from resources
        /// </summary>
        public void LoadPlaylistFromResources()
        {
            LoadPlaylistFromResources(ResourcesPath);
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
            if (loadPlaylistFromResources)
            {
                LoadPlaylistFromResources();
            }
            musicAudioSource = gameObject.AddComponent<AudioSource>();
            MusicAudioSettings.ApplySettings(musicAudioSource);
            if (analyzeMusicAudioClipSamples)
            {
                analyzeMusicAudioSource = gameObject.AddComponent<AudioSource>();
                MusicAudioSettings.ApplySettings(analyzeMusicAudioSource);
                if (analyzeMusicAudioSource != null)
                {
                    analyzeMusicAudioSource.volume = 0.0f;
                }
            }
            soundEffectsAudioGroup = AudioGroup.CreateAudioGroup(gameObject, soundChannelCount, SoundEffectsAudioSettings);
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
            if (analyzeMusicAudioSource != null)
            {
                AudioClip clip = analyzeMusicAudioSource.clip;
                if (clip != null)
                {
                    if (analyzeMusicAudioSource.isPlaying)
                    {
                        if (analyzedSamples == analyzeMusicAudioSource.timeSamples)
                        {
                            musicAudioClipSamples = analyzedSamples + 1;
                        }
                        else
                        {
                            long old_analyze_music_numerator = analyzeMusicNumerator;
                            long old_analyze_music_denominator = analyzeMusicDenominator;
                            analyzeMusicNumerator *= 2L;
                            analyzeMusicDenominator *= 2L;
                            if (analyzedSamples < analyzeMusicAudioSource.timeSamples)
                            {
                                ++analyzeMusicNumerator;
                            }
                            else if (analyzedSamples > analyzeMusicAudioSource.timeSamples)
                            {
                                --analyzeMusicNumerator;
                            }
                            long max_samples = Mathf.Max(0, clip.samples - 1);
                            musicAudioClipSamples = analyzedSamples + 1;
                            analyzedSamples = (int)((max_samples * analyzeMusicNumerator) / analyzeMusicDenominator);
                            analyzeMusicAudioSource.timeSamples = analyzedSamples;
                            if (musicAudioClipSamples == (analyzedSamples + 1))
                            {
                                analyzeMusicNumerator = old_analyze_music_numerator;
                                analyzeMusicDenominator = old_analyze_music_denominator;
                            }
                        }
                    }
                    else
                    {
                        musicAudioClipSamples = analyzeMusicAudioSource.timeSamples + 1;
                    }
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
