using System;
using System.ComponentModel.DataAnnotations;

namespace WatchDog.Models
{
    public interface IWatchDogItem
    {
        [Key]
        string Name { get; set; }
        int FrequencyMinutes { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime ModifiedDate { get; set; }
        DateTime LastCheckin { get; set; }

        bool IsLate();
        int HowLate();
    }

    public class WatchDogItem : IWatchDogItem
    {
        [Key]
        public string Name { get; set; }
        public int FrequencyMinutes { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime LastCheckin { get; set; }

        public bool IsLate()
        {
            DateTime currentTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, "Europe/Stockholm");
            return LastCheckin.AddMinutes(FrequencyMinutes) < currentTime;
        }

        public int HowLate()
        {
            DateTime currentTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, "Europe/Stockholm");
            return Convert.ToInt32(currentTime.Subtract(LastCheckin.AddMinutes(FrequencyMinutes)).TotalMinutes);
        }
    }
}
