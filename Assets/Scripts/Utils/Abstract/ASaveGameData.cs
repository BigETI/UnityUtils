using System;
using UnityEngine;
using Utils.Data;

/// <summary>
/// Utilities namespace
/// </summary>
namespace Utils
{
    /// <summary>
    /// Save game data interface
    /// </summary>
    [Serializable]
    public abstract class ASaveGameData
    {
        /// <summary>
        /// Last save date and time
        /// </summary>
        [SerializeField]
        private DateTimeData lastSaveDateTime;

        /// <summary>
        /// Last save date and time
        /// </summary>
        public DateTime LastSaveDateTime
        {
            get
            {
                if (lastSaveDateTime == null)
                {
                    lastSaveDateTime = new DateTimeData(DateTime.Now);
                }
                return lastSaveDateTime.DateTime;
            }
            set
            {
                lastSaveDateTime = new DateTimeData(value);
            }
        }

        /// <summary>
        /// Update last save date and time
        /// </summary>
        public void UpdateLastSaveDateTime()
        {
            lastSaveDateTime = new DateTimeData(DateTime.Now);
        }
    }
}
