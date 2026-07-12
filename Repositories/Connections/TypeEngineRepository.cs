using Microsoft.EntityFrameworkCore;
using SGC_Database_Backup.Data;
using SGC_Database_Backup.Entities;
using SGC_Database_Backup.Repositories.Generic;

namespace SGC_Database_Backup.Repositories.Connections
{
    public class TypeEngineRepository : GenericRepository<TypeEngine>, ITypeEngineRepository
    {
        public TypeEngineRepository(IDbContextFactory<ApplicationDbContext> context) : base(context)
        {
        }
    }
}
