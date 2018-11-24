using System;
using UnityEngine;

/// <summary>
/// Utilities data namespace
/// </summary>
namespace Utils.Data
{
    /// <summary>
    /// Date and time data
    /// </summary>
    [Serializable]
    public class DateTimeData
    {
        /// <summary>
        /// Minute
        /// </summary>
        [SerializeField]
        private int year;

        /// <summary>
        /// Minute
        /// </summary>
        [SerializeField]
        private int month;

        /// <summary>
        /// Minute
        /// </summary>
        [SerializeField]
        private int day;

        /// <summary>
        /// Minute
        /// </summary>
        [SerializeField]
        private int hour;

        /// <summary>
        /// Minute
        /// </summary>
        [SerializeField]
        private int minute;

        /// <summary>
        /// Second
        /// </summary>
        [SerializeField]
        private int second;

        /// <summary>
        /// Millisecond
        /// </summary>
        [SerializeField]
        private int millisecond;

        /// <summary>
        /// Date and time
        /// </summary>
        public DateTime DateTime
        {
            get
            {
                return new DateTime(year, month, day, hour, minute, second, millisecond);
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dateTime">Date and time</param>
        public DateTimeData(DateTime dateTime)
        {
            millisecond = dateTime.Millisecond;
            second = dateTime.Second;
            minute = dateTime.Minute;
            hour = dateTime.Hour;
            day = dateTime.Day;
            month = dateTime.Month;
            year = dateTime.Year;
        }

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="dateTime">Date and time</param>
        public DateTimeData(DateTimeData dateTime)
        {
            if (dateTime != null)
            {
                millisecond = dateTime.millisecond;
                second = dateTime.second;
                minute = dateTime.minute;
                hour = dateTime.hour;
                day = dateTime.day;
                month = dateTime.month;
                year = dateTime.year;
            }
        }
    }
}
