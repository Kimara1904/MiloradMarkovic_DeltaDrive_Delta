using Microsoft.EntityFrameworkCore;
using MiloradMarkovic_DeltaDrive_Delta.Repositories.Interfaces;

namespace MiloradMarkovic_DeltaDrive_Delta.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbContext _context;

        public GenericRepository(DbContext context)
        {
            _context = context;
        }

        public async Task AddRange(IEnumerable<T> entities)
        {
            var data = await _context.Set<T>().ToListAsync();
            if (data.Count == 0)
            {
                await _context.Set<T>().AddRangeAsync(entities);
            }
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<T?> FindAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IQueryable<T>> GetAllAsync()
        {
            var results = await _context.Set<T>().ToListAsync();
            return results.AsQueryable();
        }

        public async Task Insert(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
