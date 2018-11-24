using UnityEngine;
using UnityEngine.UI;
using Utils.Data;

/// <summary>
/// Utilities managers namespace
/// </summary>
namespace Utils.Managers
{
    /// <summary>
    /// Music UI controller script class
    /// </summary>
    public class MusicUIManagerScript : MonoBehaviour
    {
        /// <summary>
        /// Default icon sprite
        /// </summary>
        [SerializeField]
        private Sprite defaultIconSprite;

        /// <summary>
        /// Title text
        /// </summary>
        [SerializeField]
        private Text titleText;

        /// <summary>
        /// Description text
        /// </summary>
        [SerializeField]
        private Text descriptionText;

        /// <summary>
        /// Author text
        /// </summary>
        [SerializeField]
        private Text authorText;

        /// <summary>
        /// Icon image
        /// </summary>
        [SerializeField]
        private Image iconImage;

        /// <summary>
        /// Panel animator
        /// </summary>
        [SerializeField]
        private Animator panelAnimator;

        /// <summary>
        /// Instance
        /// </summary>
        private static MusicUIManagerScript instance = null;

        /// <summary>
        /// Instance
        /// </summary>
        public static MusicUIManagerScript Instance
        {
            get
            {
                return instance;
            }
        }

        /// <summary>
        /// Show play
        /// </summary>
        /// <param name="musicTitle">Music title</param>
        public void ShowPlay(MusicTitleData musicTitle)
        {
            if (titleText != null)
            {
                titleText.text = musicTitle.Title;
            }
            if (descriptionText != null)
            {
                descriptionText.text = musicTitle.Description;
            }
            if (authorText != null)
            {
                authorText.text = musicTitle.Author;
            }
            // TODO
            /*if (iconImage != null)
            {
                iconImage.sprite = ((musicTitle.IconSprite == null) ? defaultIconSprite : musicTitle.IconSprite);
            }*/
            if (panelAnimator != null)
            {
                panelAnimator.Play("Show");
            }
        }

        /// <summary>
        /// Hide play
        /// </summary>
        public void HidePlay()
        {
            if (panelAnimator != null)
            {
                panelAnimator.Play("Idle");
            }
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
        }
    }
}
