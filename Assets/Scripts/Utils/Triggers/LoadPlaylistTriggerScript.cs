using UnityEngine;
using Utils.Data;

/// <summary>
/// Utilities triggers namespace
/// </summary>
namespace Utils.Triggers
{
    /// <summary>
    /// Load playlist trigger script class
    /// </summary>
    public class LoadPlaylistTriggerScript : MonoBehaviour
    {
        /// <summary>
        /// Load from resources
        /// </summary>
        [SerializeField]
        private bool loadFromResources;

        /// <summary>
        /// Resources path
        /// </summary>
        [SerializeField]
        private string resourcesPath = "MusicTitles";

        /// <summary>
        /// Playlist
        /// </summary>
        [SerializeField]
        private MusicTitleData[] playlist;

        /// <summary>
        /// Resources path
        /// </summary>
        private string ResourcesPath
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
        /// Playlist
        /// </summary>
        private MusicTitleData[] Playlist
        {
            get
            {
                if (playlist == null)
                {
                    playlist = new MusicTitleData[0];
                }
                return playlist;
            }
        }

        /// <summary>
        /// Awake
        /// </summary>
        public void Awake()
        {
            if (loadFromResources)
            {
                AudioManager.LoadPlaylistFromResources(resourcesPath);
            }
            else
            {
                AudioManager.Playlist = Playlist;
            }
            Destroy(this);
        }
    }
}
