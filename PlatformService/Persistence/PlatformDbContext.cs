using Microsoft.EntityFrameworkCore;
using PlatformService.Models;

namespace PlatformService.Persistence
{
    public class PlatformDbContext : DbContext
    {
        public PlatformDbContext(DbContextOptions<PlatformDbContext> options)
        {
        }

        public DbSet<Platform> Platforms { get; set; }
    }
}