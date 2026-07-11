using System.Linq.Expressions;
using SGC_Database_Backup.Entities;

namespace SGC_Database_Backup.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T?> FindAsync(int id);

        Task<IEnumerable<T>> GetAllAsync();

        Task CreateAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(int id);
        Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);

        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);

        Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null);

        Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate);
    }
}