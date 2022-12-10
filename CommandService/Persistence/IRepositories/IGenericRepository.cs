namespace CommandService.Persistence.IRepositories
{
    public interface IGenericRepository<T> where T: class
    {
        Task<bool> SaveChanges();

        bool Exists(int id);

        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task Add(T entity);
    }
}