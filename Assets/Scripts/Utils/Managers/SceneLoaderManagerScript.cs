using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

/// <summary>
/// Utilities managers namespace
/// </summary>
namespace Utils.Managers
{
    /// <summary>
    /// Scene loader manager script
    /// </summary>
    public class SceneLoaderManagerScript : MonoBehaviour
    {
        /// <summary>
        /// On load scene
        /// </summary>
        [SerializeField]
        private UnityEvent onLoadScene;

        /// <summary>
        /// On scene loaded
        /// </summary>
        [SerializeField]
        private UnityEvent onSceneLoaded;

        /// <summary>
        /// On scene load error
        /// </summary>
        [SerializeField]
        private UnityEvent onSceneLoadError;

        /// <summary>
        /// Async operation
        /// </summary>
        private AsyncOperation asyncOperation;

        /// <summary>
        /// Instance
        /// </summary>
        private static SceneLoaderManagerScript instance;

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
        /// Progress
        /// </summary>
        public float Progress
        {
            get
            {
                return ((asyncOperation == null) ? 0.0f : asyncOperation.progress);
            }
        }

        /// <summary>
        /// Instance
        /// </summary>
        public static SceneLoaderManagerScript Instance
        {
            get
            {
                return instance;
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

        /// <summary>
        /// Load scene
        /// </summary>
        public void LoadScene()
        {
            if (asyncOperation == null)
            {
                asyncOperation = SceneManager.LoadSceneAsync(SceneLoaderManager.SceneName);
                if (onLoadScene != null)
                {
                    onLoadScene.Invoke();
                }
            }
        }

        /// <summary>
        /// Update
        /// </summary>
        private void Update()
        {
            if (asyncOperation != null)
            {
                if (asyncOperation.isDone)
                {
                    asyncOperation = null;
                    if (onSceneLoaded != null)
                    {
                        onSceneLoaded.Invoke();
                    }
                }
            }
        }
    }
}
