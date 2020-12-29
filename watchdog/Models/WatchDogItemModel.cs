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
    }

    public class WatchDogItem : IWatchDogItem
    {
        [Key]
        public string Name { get; set; }
        public int FrequencyMinutes { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
