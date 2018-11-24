using UnityEngine.SceneManagement;
using Utils.Managers;

/// <summary>
/// Utilities namespace
/// </summary>
namespace Utils
{
    /// <summary>
    /// Scene loader manager class
    /// </summary>
    public static class SceneLoaderManager
    {
        /// <summary>
        /// Scene name
        /// </summary>
        private static string sceneName = "IntroScene";

        /// <summary>
        /// Scene name
        /// </summary>
        public static string SceneName
        {
            get
            {
                return sceneName;
            }
        }

        /// <summary>
        /// Progress
        /// </summary>
        public static float Progress
        {
            get
            {
                return ((LoadingScreenManagerScript.Instance == null) ? 0.0f : LoadingScreenManagerScript.Instance.Progress);
            }
        }

        /// <summary>
        /// Load scene
        /// </summary>
        /// <param name="sceneName">Scene name</param>
        public static void LoadScene(string sceneName)
        {
            SceneLoaderManager.sceneName = sceneName;
            if (SceneLoaderManagerScript.Instance == null)
            {
                SceneManager.LoadScene("LoadingScreenScene");
            }
            else
            {
                SceneLoaderManagerScript.Instance.LoadScene();
            }
        }
    }
}
