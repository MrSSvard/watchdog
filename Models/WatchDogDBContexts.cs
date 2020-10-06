using Microsoft.EntityFrameworkCore;
using WatchDog.Models;
using System.Diagnostics.CodeAnalysis;

namespace WatchDog.DBContexts
{
    public class WatchDogDBContext : DbContext
    {
        public WatchDogDBContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        public DbSet<WatchDogItem> WatchDogItems { get; set; }

    }
}
