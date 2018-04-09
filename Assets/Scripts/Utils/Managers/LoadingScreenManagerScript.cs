using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Utilities managers namespace
/// </summary>
namespace Utils.Managers
{
    /// <summary>
    /// Loading screen manager class
    /// </summary>
    public class LoadingScreenManagerScript : MonoBehaviour
    {
        /// <summary>
        /// Async operation
        /// </summary>
        private AsyncOperation asyncOperation;

        /// <summary>
        /// Instance
        /// </summary>
        private static LoadingScreenManagerScript instance;

        /// <summary>
        /// Async operation
        /// </summary>
        public AsyncOperation AsyncOperation
        {
            get
            {
                return asyncOperation;
            }
        }

        /// <summary>
        /// Instance
        /// </summary>
        public static LoadingScreenManagerScript Instance
        {
            get
            {
                return instance;
            }
        }

        /// <summary>
        /// On enable
        /// </summary>
        private void OnEnable()
        {
            if (instance == null)
            {
                instance = this;
            }
        }

        /// <summary>
        /// On disable
        /// </summary>
        private void OnDisable()
        {
            if (instance == this)
            {
                instance = null;
            }
        }

        /// <summary>
        /// Start
        /// </summary>
        private void Start()
        {
            asyncOperation = SceneManager.LoadSceneAsync(LoadingSceneManager.SceneName);
        }
    }
}
