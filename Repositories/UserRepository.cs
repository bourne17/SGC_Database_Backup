using Microsoft.EntityFrameworkCore;
using SGC_Database_Backup.Data;
using SGC_Database_Backup.Entities;

namespace SGC_Database_Backup.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(IDbContextFactory<ApplicationDbContext> context) : base(context)
        {
        }

    }
}