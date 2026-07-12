using SGC_Database_Backup.Entities;
using SGC_Database_Backup.Repositories.Generic;

namespace SGC_Database_Backup.Repositories.Users
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task SaveChanges(User? userToEdit);
    }
}