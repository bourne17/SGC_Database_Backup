using Microsoft.EntityFrameworkCore;
using SGC_Database_Backup.Data;
using SGC_Database_Backup.Entities;
using SGC_Database_Backup.Repositories.Generic;

namespace SGC_Database_Backup.Repositories.Destinations
{
    public class DestinationRepository(IDbContextFactory<ApplicationDbContext> context) : GenericRepository<Destination>(context), IDestinationRepository
    {
        public override async Task<IEnumerable<Destination>> GetAllAsync()
        {
            var dbcontext = await context.CreateDbContextAsync();

            return await dbcontext.Destination.Select(x => new Destination
            {
                Id = x.Id,
                Description = x.Description,
                Path=x.Path,
                DestinationTypeDescription=x.DestinationType.Description,
                IsActive=x.IsActive
            }).ToListAsync();
        }
    }
}
