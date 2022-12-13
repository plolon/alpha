using CommandService.Models;

namespace CommandService.Persistence.IRepositories
{
    public interface IPlatformRepository : IGenericRepository<Platform>
    {
        Task<bool> ExternalPlatformExists(int id);
    }
}