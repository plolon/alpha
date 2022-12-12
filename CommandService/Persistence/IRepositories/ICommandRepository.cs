using CommandService.Models;

namespace CommandService.Persistence.IRepositories
{
    public interface ICommandRepository : IGenericRepository<Command>
    {
        Task<Command> GetCommand(int platformId, int commandId);
        Task CreateCommand(int platformId, Command command);
        Task<IEnumerable<Command>> GetCommandsForPlatform(int platformId);
        Task<bool> ExternalPlatformExists(int id);
    }
}