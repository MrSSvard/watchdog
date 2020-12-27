using System;
using System.ComponentModel.DataAnnotations;

namespace WatchDog.Models
{
    public interface IWatchDogItem
    {
        [Key]
        string Name { get; set; }
        int FrequencyMinutes { get; set; }
        DateTime CreatedDate { get; }
        DateTime ModifiedDate { get; set; }
    }

    public class WatchDogItem : IWatchDogItem
    {
        [Key]
        public string Name { get; set; }
        public int FrequencyMinutes { get; set; }
        public DateTime CreatedDate { get; }
        public DateTime ModifiedDate { get; set; }

        public WatchDogItem()
        {
            this.CreatedDate = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, "Europe/Stockholm");
            this.ModifiedDate = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, "Europe/Stockholm");
        }
    }
}

