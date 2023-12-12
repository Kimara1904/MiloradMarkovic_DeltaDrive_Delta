namespace MiloradMarkovic_DeltaDrive_Delta.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IQueryable<T>> GetAllAsync();
        Task<T?> FindAsync(int id);
        Task Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task AddRange(IEnumerable<T> entities);
    }
}
