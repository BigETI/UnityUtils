using System;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using Utils.Objects;

/// <summary>
/// Utilities data namespace
/// </summary>
namespace Utils.Data
{
    /// <summary>
    /// Music title data
    /// </summary>
    [Serializable]
    public class MusicTitleData : IComparable<MusicTitleData>
    {
        /// <summary>
        /// Audio clip
        /// </summary>
        [SerializeField]
        private string audioClip;

        /// <summary>
        /// Title
        /// </summary>
        [SerializeField]
        private string title;

        /// <summary>
        /// Description
        /// </summary>
        [TextArea]
        [SerializeField]
        private string description;

        /// <summary>
        /// Author
        /// </summary>
        [SerializeField]
        private string author;

        /// <summary>
        /// Icon sprite
        /// </summary>
        [SerializeField]
        private string iconSprite;

        /// <summary>
        /// Is resource
        /// </summary>
        [SerializeField]
        private bool isResource;

        /// <summary>
        /// Audio type
        /// </summary>
        [SerializeField]
        private AudioType audioType = AudioType.UNKNOWN;

        /// <summary>
        /// Audio clip
        /// </summary>
        private AudioClip audioClipObject;

        /// <summary>
        /// Web request
        /// </summary>
        private UnityWebRequest webRequest;

        /// <summary>
        /// Get audio type from URI
        /// </summary>
        /// <param name="uri">URI</param>
        /// <returns>Audio type</returns>
        private static AudioType GetAudioTypeFromURI(string uri)
        {
            AudioType ret = AudioType.UNKNOWN;
            try
            {
                Uri u = new Uri(uri);
                string extension = Path.GetExtension(u.AbsolutePath);
                if (extension != null)
                {
                    extension = extension.ToUpper();
                    foreach (AudioType audio_type in Enum.GetValues(typeof(AudioType)))
                    {
                        switch (audio_type)
                        {
                            case AudioType.AIFF:
                                if (extension == "AIFF")
                                {
                                    ret = audio_type;
                                }
                                break;
                            case AudioType.IT:
                                if (extension == "IT")
                                {
                                    ret = audio_type;
                                }
                                break;
                            case AudioType.MOD:
                                if (extension == "MOD")
                                {
                                    ret = audio_type;
                                }
                                break;
                            case AudioType.MPEG:
                                if ((extension == "MP2") || (extension == "MP3"))
                                {
                                    ret = audio_type;
                                }
                                break;
                            case AudioType.OGGVORBIS:
                                if (extension == "OGG")
                                {
                                    ret = audio_type;
                                }
                                break;
                            case AudioType.S3M:
                                if (extension == "S3M")
                                {
                                    ret = audio_type;
                                }
                                break;
                            case AudioType.VAG:
                                if (extension == "VAG")
                                {
                                    ret = audio_type;
                                }
                                break;
                            case AudioType.WAV:
                                if (extension == "WAV")
                                {
                                    ret = audio_type;
                                }
                                break;
                            case AudioType.XM:
                                if (extension == "XM")
                                {
                                    ret = audio_type;
                                }
                                break;
                            case AudioType.XMA:
                                if (extension == "XMA")
                                {
                                    ret = audio_type;
                                }
                                break;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
            return ret;
        }

        /// <summary>
        /// Audio clip
        /// </summary>
        public AudioClip AudioClip
        {
            get
            {
                if (audioClipObject == null)
                {
                    if (audioClip == null)
                    {
                        audioClip = "";
                    }
                    if (isResource)
                    {
                        audioClipObject = Resources.Load<AudioClip>(audioClip);
                    }
                }
                return audioClipObject;
            }
        }

        /// <summary>
        /// Title
        /// </summary>
        public string Title
        {
            get
            {
                return title;
            }
        }

        /// <summary>
        /// Description
        /// </summary>
        public string Description
        {
            get
            {
                return description;
            }
        }

        /// <summary>
        /// Author
        /// </summary>
        public string Author
        {
            get
            {
                return author;
            }
        }

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="musicTitle">Music title</param>
        public MusicTitleData(MusicTitleData musicTitle)
        {
            if (musicTitle != null)
            {
                audioClip = musicTitle.audioClip;
                audioClipObject = musicTitle.audioClipObject;
                title = musicTitle.title;
                description = musicTitle.description;
                author = musicTitle.author;
                iconSprite = musicTitle.iconSprite;
                isResource = musicTitle.isResource;
                audioType = musicTitle.audioType;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="musicTitle">Music title</param>
        /// <param name="resourcesPath">Resources path</param>
        public MusicTitleData(MusicTitleObjectScript musicTitle, string resourcesPath)
        {
            if (musicTitle != null)
            {
                audioClipObject = musicTitle.AudioClip;
                audioClip = ((audioClipObject == null) ? "" : (resourcesPath + "/" + audioClipObject.name));
                title = musicTitle.Title;
                description = musicTitle.Description;
                author = musicTitle.Author;
                isResource = true;
                audioType = AudioType.UNKNOWN;
            }
        }

        /// <summary>
        /// Compare to
        /// </summary>
        /// <param name="other">Other</param>
        /// <returns>Delta</returns>
        public int CompareTo(MusicTitleData other)
        {
            int ret = -1;
            if (other != null)
            {
                ret = Title.CompareTo(other.Title);
                if (ret == 0)
                {
                    ret = Author.CompareTo(other.Author);
                    if (ret == 0)
                    {
                        ret = Description.CompareTo(other.Description);
                    }
                }
            }
            return ret;
        }
    }
}
