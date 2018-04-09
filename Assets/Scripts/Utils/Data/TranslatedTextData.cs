using System;
using UnityEngine;

/// <summary>
/// Utilities data namespace
/// </summary>
namespace Utils.Data
{
    /// <summary>
    /// Translated text data class
    /// </summary>
    [Serializable]
    public class TranslatedTextData
    {
        /// <summary>
        /// Text
        /// </summary>
        [TextArea]
        [SerializeField]
        private string text;

        /// <summary>
        /// Language
        /// </summary>
        [SerializeField]
        private SystemLanguage language = SystemLanguage.English;

        /// <summary>
        /// Text
        /// </summary>
        public string Text
        {
            get
            {
                return text;
            }
        }

        /// <summary>
        /// Language
        /// </summary>
        public SystemLanguage Language
        {
            get
            {
                return language;
            }
        }

        /// <summary>
        /// To string
        /// </summary>
        /// <returns>String representation</returns>
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
