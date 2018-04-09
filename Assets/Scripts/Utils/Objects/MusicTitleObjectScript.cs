using UnityEngine;

/// <summary>
/// Utilities objects namespace
/// </summary>
namespace Utils.Objects
{
    /// <summary>
    /// Music title object script class
    /// </summary>
    [CreateAssetMenu(fileName = "MusicTitle", menuName = "Utils/MusicTitle")]
    public class MusicTitleObjectScript : ScriptableObject
    {
        /// <summary>
        /// Audio clip
        /// </summary>
        [SerializeField]
        private AudioClip audioClip;

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
        private Sprite iconSprite;

        /// <summary>
        /// Audio clip
        /// </summary>
        public AudioClip AudioClip
        {
            get
            {
                return audioClip;
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
        /// Icon sprite
        /// </summary>
        public Sprite IconSprite
        {
            get
            {
                return iconSprite;
            }
        }
    }
}
