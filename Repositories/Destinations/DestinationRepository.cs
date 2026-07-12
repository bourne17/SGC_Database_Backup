using Microsoft.EntityFrameworkCore;
using SGC_Database_Backup.Data;
using SGC_Database_Backup.Entities;
using SGC_Database_Backup.Repositories.Generic;

namespace SGC_Database_Backup.Repositories.Destinations
{
    public class DestinationRepository : GenericRepository<Destination>, IDestinationRepostory
    {
        public DestinationRepository(IDbContextFactory<ApplicationDbContext> context) : base(context)
        {
        }
    }
}
