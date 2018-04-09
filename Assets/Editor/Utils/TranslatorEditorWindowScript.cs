using System.Text;
using UnityEditor;
using UnityEngine;
using Utils.Data;
using Utils.Objects;

/// <summary>
/// Utilities editor namespace
/// </summary>
namespace Utils.Editor
{
    /// <summary>
    /// Translator editor window script class
    /// </summary>
    public class TranslatorEditorWindowScript : EditorWindow
    {
        /// <summary>
        /// To system language
        /// </summary>
        private SystemLanguage toSystemLanguage = SystemLanguage.English;

        /// <summary>
        /// Is not translated
        /// </summary>
        /// <param name="translation">Translation</param>
        /// <returns>Result</returns>
        private bool IsNotTranslated(TranslationObjectScript translation)
        {
            bool ret = true;
            foreach (TranslatedTextData text in translation.Translation.Texts)
            {
                if (text.Language == toSystemLanguage)
                {
                    ret = false;
                    break;
                }
            }
            return ret;
        }

        /// <summary>
        /// Show window
        /// </summary>
        [MenuItem("Window/Utils/Translator")]
        public static void ShowWindow()
        {
            GetWindow<TranslatorEditorWindowScript>("Translator");
        }

        /// <summary>
        /// On GUI
        /// </summary>
        private void OnGUI()
        {
            toSystemLanguage = (SystemLanguage)(EditorGUILayout.EnumPopup("To System Language", toSystemLanguage));
            if (GUILayout.Button("Copy translation form to clipboard"))
            {
                TranslationObjectScript[] translations = Resources.LoadAll<TranslationObjectScript>("Translations");
                if (translations != null)
                {
                    StringBuilder sb = new StringBuilder("# Translation form\r\n\r\n## Description\r\nThis form is used to translate words into ");
                    sb.AppendLine(toSystemLanguage.ToString());
                    sb.AppendLine("\r\n\r\n## Words\r\n");
                    foreach (TranslationObjectScript translation in translations)
                    {
                        if (IsNotTranslated(translation))
                        {
                            sb.Append("### ");
                            sb.AppendLine(translation.name);
                            if (translation.Comment != null)
                            {
                                if (translation.Comment.Trim().Length > 0)
                                {
                                    sb.Append("Comment: ");
                                    sb.AppendLine(translation.Comment);
                                }
                            }
                            foreach (TranslatedTextData text in translation.Translation.Texts)
                            {
                                sb.Append("In ");
                                sb.Append(text.Language.ToString());
                                sb.Append(": ");
                                sb.Append(text.Text);
                                sb.AppendLine();
                            }
                            sb.Append("\r\nWhat is it called in ");
                            sb.Append(toSystemLanguage.ToString());
                            sb.Append("?: ");
                            sb.AppendLine("\r\n\r\n");
                        }
                    }
                    sb.Append("## Conclusion\r\nThank your for translating into ");
                    sb.AppendLine(toSystemLanguage.ToString());
                    GUIUtility.systemCopyBuffer = sb.ToString();
                }
            }
        }
    }
}
