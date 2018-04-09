using UnityEngine;

/// <summary>
/// Utilities namespace
/// </summary>
namespace Utils
{
    /// <summary>
    /// Translator class
    /// </summary>
    public static class Translator
    {
        /// <summary>
        /// Forced system language
        /// </summary>
        private static SystemLanguage forcedSystemLanguage = SystemLanguage.English;

        /// <summary>
        /// Force system language
        /// </summary>
        private static bool forceSystemLanguage = false;

        /// <summary>
        /// System language
        /// </summary>
        public static SystemLanguage SystemLanguage
        {
            get
            {
                return (forceSystemLanguage ? forcedSystemLanguage : Application.systemLanguage);
            }
        }

        /// <summary>
        /// Force system language
        /// </summary>
        /// <param name="systemLanguage">System language</param>
        public static void ForceSystemLanguage(SystemLanguage systemLanguage)
        {
            forcedSystemLanguage = systemLanguage;
            forceSystemLanguage = true;
        }

        /// <summary>
        /// Remove forced system language
        /// </summary>
        public static void RemoveForcedSystemLanguage()
        {
            forcedSystemLanguage = SystemLanguage.English;
            forceSystemLanguage = false;
        }
    }
}
