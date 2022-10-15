using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using PlatformService.Models;

namespace PlatformService.Data
{
    public class PlatformDbContext : DbContext
    {
        public PlatformDbContext(DbContextOptions<PlatformDbContext> options)
        {
        }

        public DbSet<Platform> Platforms { get; set; }
    }
}