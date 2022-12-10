using Microsoft.EntityFrameworkCore;
using CommandService.Persistence.IRepositories;

namespace CommandService.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T: class
    {
        private readonly CommandDbContext _dbContext;

        public GenericRepository(CommandDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> SaveChanges()
        {
            return (await _dbContext.SaveChangesAsync() >= 0);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> Get(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task Add(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
        }
    }
}