using System;

namespace WatchDog.Models
{
    public interface IWatchDogItem
    {
        int Id { get; set; }
        string Name { get; set; }
        int FrequencyMinutes { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime ModifiedDate { get; set; }
    }

    public class WatchDogItem : IWatchDogItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FrequencyMinutes { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public WatchDogItem()
        {
            this.CreatedDate = DateTime.UtcNow;
            this.ModifiedDate = DateTime.UtcNow;
        }
    }
}

