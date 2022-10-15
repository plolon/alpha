using PlatformService.Models;
using PlatformService.Persistence.IRepositories;

namespace PlatformService.Persistence.Repositories
{
    public class PlatformRepository : GenericRepository<Platform>, IPlatformRepository
    {
        public PlatformRepository(PlatformDbContext dbContext) : base(dbContext)
        {
        }
    }
}