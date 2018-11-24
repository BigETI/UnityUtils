using UnityEngine;
using UnityEngine.UI;
using Utils.Objects;

/// <summary>
/// Utilities triggers namespace
/// </summary>
namespace Utils.Triggers
{
    /// <summary>
    /// Translator trigger script class
    /// </summary>
    [RequireComponent(typeof(Text))]
    public class TranslatorTriggerScript : MonoBehaviour
    {
        /// <summary>
        /// Translation object
        /// </summary>
        [SerializeField]
        private TranslationObjectScript translationObject;

        /// <summary>
        /// Translation
        /// </summary>
        public string Translation
        {
            get
            {
                return ((translationObject == null) ? "" : translationObject.ToString());
            }
        }

        /// <summary>
        /// Start
        /// </summary>
        private void Start()
        {
            Text text = GetComponent<Text>();
            if (text != null)
            {
                text.text = Translation;
            }
            Destroy(this);
        }
    }
}
