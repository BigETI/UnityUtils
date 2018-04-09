using UnityEngine.SceneManagement;

/// <summary>
/// Utilities namespace
/// </summary>
namespace Utils
{
    /// <summary>
    /// Loading scene manager class
    /// </summary>
    public static class LoadingSceneManager
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
        /// Load scene
        /// </summary>
        /// <param name="sceneName">Scene name</param>
        public static void LoadScene(string sceneName)
        {
            LoadingSceneManager.sceneName = sceneName;
            SceneManager.LoadScene("LoadingScreenScene");
        }
    }
}
