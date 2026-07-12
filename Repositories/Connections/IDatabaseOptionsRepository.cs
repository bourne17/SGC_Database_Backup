using SGC_Database_Backup.Entities;
using SGC_Database_Backup.Repositories.Generic;
using System.Data.Common;

namespace SGC_Database_Backup.Repositories.Connections
{
    public interface IDatabaseOptionsRepository : IGenericRepository<DatabaseOptions>
    {
        Task<DbConnection> CreateConnection(DatabaseOptions options);

        Task<ConnectionTestResult> TestConnectionAsync(DatabaseOptions options);
    }
}