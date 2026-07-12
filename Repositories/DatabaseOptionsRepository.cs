using Microsoft.EntityFrameworkCore;
using SGC_Database_Backup.Data;
using SGC_Database_Backup.Entities;

namespace SGC_Database_Backup.Repositories
{
    public class DatabaseOptionsRepository : GenericRepository<DatabaseOptions>, IDatabaseOptionsRepository
    {
        public DatabaseOptionsRepository(IDbContextFactory<ApplicationDbContext> context) : base(context)
        {
        }
    }
}
