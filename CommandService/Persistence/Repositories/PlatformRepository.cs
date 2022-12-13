using CommandService.Models;
using CommandService.Persistence.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace CommandService.Persistence.Repositories
{
    public class PlatformRepository : GenericRepository<Platform>, IPlatformRepository
    {
        private readonly CommandDbContext _dbContext;
        public PlatformRepository(CommandDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> ExternalPlatformExists(int id)
        {
            return await _dbContext.Platforms.AnyAsync(x => x.Id.Equals(id));
        }
    }
}