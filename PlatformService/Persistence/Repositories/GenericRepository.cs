using Microsoft.EntityFrameworkCore;
using PlatformService.Persistence.IRepositories;

namespace PlatformService.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T: class
    {
        private readonly PlatformDbContext _dbContext;

        public GenericRepository(PlatformDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> SaveChanges()
        {
            //TODO: Some logger logic with handle exception
            try
            {
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> Get(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task CreatePlatform(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
        }
    }
}