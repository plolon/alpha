using CommandService.Models;
using CommandService.Persistence.IRepositories;

namespace CommandService.Persistence.Repositories
{
    public class PlatformRepository : GenericRepository<Platform>, IPlatformRepository
    {
        public PlatformRepository(CommandDbContext dbContext) : base(dbContext)
        {
        }
    }
}