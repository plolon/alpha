using CommandService.Models;
using CommandService.Persistence.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace CommandService.Persistence.Repositories
{
    public class CommandRepository : GenericRepository<Command>, ICommandRepository
    {
        private readonly CommandDbContext _dbContext;
        public CommandRepository(CommandDbContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<IEnumerable<Command>> GetCommandsForPlatform(int platformId)
        {
            return await _dbContext.Commands
            .Where(x => x.PlatformId.Equals(platformId))
            .ToListAsync();
        }

        public async Task<Command> GetCommand(int platformId, int commandId)
        {
            return await _dbContext.Commands
            .Where(x => x.PlatformId.Equals(platformId) && x.Id.Equals(commandId))
            .FirstOrDefaultAsync();
        }

        public async Task CreateCommand(int platformId, Command command)
        {
            if(command == null)
                throw new ArgumentNullException(nameof(command));

            command.PlatformId = platformId;
            await _dbContext.Commands.AddAsync(command);
        }

        public async Task<bool> ExternalPlatformExists(int id)
        {
            return await _dbContext.Platforms.AnyAsync(x => x.Id.Equals(id));
        }
    }
}