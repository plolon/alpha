using CommandService.Models;
using CommandService.Persistence.IRepositories;

namespace CommandService.Persistence.Repositories
{
    public class CommandRepository : GenericRepository<Command>, ICommandRepository
    {
        public CommandRepository(CommandDbContext dbContext) : base(dbContext)
        {
        }
    }
}