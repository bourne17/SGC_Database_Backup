using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SGC_Database_Backup.Data;

namespace SGC_Database_Backup.Repositories.Generic
{
    public class GenericRepository<T>(IDbContextFactory<ApplicationDbContext> context) : IGenericRepository<T> where T : class
    {


        public async Task CreateAsync(T entity)
        {
            var dbcontext = await context.CreateDbContextAsync();
            await dbcontext.Set<T>().AddAsync(entity);
            await dbcontext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var dbcontext = await context.CreateDbContextAsync();
            var item = dbcontext.Set<T>().Find(id);
            if (item != null)
            {
                dbcontext.Set<T>().Remove(item);
                await dbcontext.SaveChangesAsync();
            }
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            var dbcontext = await context.CreateDbContextAsync();
            return await dbcontext.Set<T>().ToListAsync();
        }

        public async Task<T?> FindAsync(int id)
        {
            var dbcontext = await context.CreateDbContextAsync();
            return await dbcontext.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            var dbcontext = await context.CreateDbContextAsync();
            dbcontext.Set<T>().Update(entity);
            await dbcontext.SaveChangesAsync();
        }

        public async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            var dbcontext = await context.CreateDbContextAsync();
            return await dbcontext.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            var dbcontext = await context.CreateDbContextAsync();

            return await dbcontext.Set<T>().AnyAsync(predicate);

        }

        public async Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null)
        {
            var dbcontext = await context.CreateDbContextAsync();

            return predicate == null
                        ? await dbcontext.Set<T>().CountAsync()
                        : await dbcontext.Set<T>().CountAsync(predicate);
        }

        public async Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            var dbcontext = await context.CreateDbContextAsync();

            return await dbcontext.Set<T>().Where(predicate).ToListAsync();

        }

    }
}