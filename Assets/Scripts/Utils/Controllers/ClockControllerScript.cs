using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Utilities controllers namespace
/// </summary>
namespace Utils.Controllers
{
    /// <summary>
    /// Clock manager script class
    /// </summary>
    public class ClockControllerScript : MonoBehaviour
    {
        /// <summary>
        /// Time
        /// </summary>
        [Range(0.000390625f, float.MaxValue)]
        [SerializeField]
        private float time = 1.0f;

        /// <summary>
        /// Is running
        /// </summary>
        [SerializeField]
        private bool isRunning = true;

        /// <summary>
        /// Unscaled time
        /// </summary>
        [SerializeField]
        private bool unscaledTime;

        /// <summary>
        /// On tick
        /// </summary>
        [SerializeField]
        private UnityEvent onTick;

        /// <summary>
        /// Elapsed timke
        /// </summary>
        private float elapsedTime = 0.0f;

        /// <summary>
        /// Time
        /// </summary>
        public float Time
        {
            get
            {
                return time;
            }
            set
            {
                time = Mathf.Max(value, 0.0f);
            }
        }

        /// <summary>
        /// Is running
        /// </summary>
        public bool IsRunning
        {
            get
            {
                return isRunning;
            }
            set
            {
                if (isRunning != value)
                {
                    elapsedTime = 0.0f;
                    isRunning = value;
                }
            }
        }

        /// <summary>
        /// Update
        /// </summary>
        private void Update()
        {
            if (isRunning)
            {
                elapsedTime += (unscaledTime ? UnityEngine.Time.unscaledDeltaTime : UnityEngine.Time.deltaTime);
                while (elapsedTime >= time)
                {
                    elapsedTime -= time;
                    onTick.Invoke();
                }
            }
        }
    }
}
