using Microsoft.EntityFrameworkCore;
using SGC_Database_Backup.Data;
using SGC_Database_Backup.Repositories;

namespace SGC_Database_Backup.Services.UoW
{
    public class UnitOfWork(IDbContextFactory<ApplicationDbContext> context):IUnitOfWork
    {
        public IUserRepository Users { get; private set; }=new UserRepository(context);  
    }
}
