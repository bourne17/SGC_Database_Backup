using Microsoft.EntityFrameworkCore;
using SGC_Database_Backup.Data;
using SGC_Database_Backup.Entities;

namespace SGC_Database_Backup.Repositories
{
    public class DatabaseOptionsRepository(IDbContextFactory<ApplicationDbContext> context) : GenericRepository<DatabaseOptions>(context)
    {
    }
}
