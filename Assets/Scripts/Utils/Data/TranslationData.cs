using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Utilties data namespace
/// </summary>
namespace Utils.Data
{
    /// <summary>
    /// Translation data class
    /// </summary>
    [Serializable]
    public class TranslationData : IComparable<TranslationData>
    {
        /// <summary>
        /// Texts
        /// </summary>
        [SerializeField]
        private TranslatedTextData[] texts = new TranslatedTextData[] { new TranslatedTextData() };

        /// <summary>
        /// Lookup
        /// </summary>
        private Dictionary<SystemLanguage, string> lookup;

        /// <summary>
        /// Texts
        /// </summary>
        public IEnumerable<TranslatedTextData> Texts
        {
            get
            {
                return texts;
            }
        }

        /// <summary>
        /// Compare to
        /// </summary>
        /// <param name="other">Other</param>
        /// <returns>Result</returns>
        public int CompareTo(TranslationData other)
        {
            int ret = 1;
            if (other != null)
            {
                ret = ToString().CompareTo(other.ToString());
            }
            return ret;
        }

        /// <summary>
        /// To string
        /// </summary>
        /// <returns>String representation</returns>
        public override string ToString()
        {
            string ret = "";
            if (lookup == null)
            {
                lookup = new Dictionary<SystemLanguage, string>();
                foreach (TranslatedTextData text in texts)
                {
                    if (lookup.ContainsKey(text.Language))
                    {
                        lookup[text.Language] = text.Text;
                    }
                    else
                    {
                        lookup.Add(text.Language, text.Text);
                    }
                }
            }
            if (lookup.ContainsKey(Translator.SystemLanguage))
            {
                ret = lookup[Translator.SystemLanguage];
            }
            else if (texts.Length > 0)
            {
                ret = texts[0].Text;
            }
            return ret;
        }
    }
}
