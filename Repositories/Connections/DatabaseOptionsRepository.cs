using Microsoft.EntityFrameworkCore;
using SGC_Database_Backup.Data;
using SGC_Database_Backup.Entities;
using SGC_Database_Backup.Repositories.Generic;

namespace SGC_Database_Backup.Repositories.Connections
{
    public class DatabaseOptionsRepository(IDbContextFactory<ApplicationDbContext> context) : GenericRepository<DatabaseOptions>(context), IDatabaseOptionsRepository
    {
        public override async Task<IEnumerable<DatabaseOptions>> GetAllAsync()
        {
            var dbcontext = await context.CreateDbContextAsync();
            return await dbcontext.DatabaseOptions.Select(x => new DatabaseOptions
            {
                Description = x.Description,
                TypeEngineDescription = x.TypeEngine.Description,
                Host = x.Host,
                Port = x.Port,
                UserName = x.UserName,
                IsActive = x.IsActive
            }).ToListAsync();
        }
    }
}
