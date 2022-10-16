namespace PlatformService.Persistence.IRepositories
{
    public interface IGenericRepository<T> where T: class
    {
        Task<bool> SaveChanges();

        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task Add(T entity);
    }
}