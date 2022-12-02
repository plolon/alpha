using System.Reflection;
using Microsoft.EntityFrameworkCore;
using PlatformService.Models;
using PlatformService.Persistence.Configuration;

namespace PlatformService.Persistence
{
    public class PlatformDbContext : DbContext
    {
        public PlatformDbContext(DbContextOptions<PlatformDbContext> options) :base(options)
        {
        }

        public DbSet<Platform> Platforms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new PlatformConfiguration()); // only dev
        }
    }
}