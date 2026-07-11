using Microsoft.EntityFrameworkCore;
using SGC_Database_Backup.Data;
using SGC_Database_Backup.Entities;

namespace SGC_Database_Backup.Repositories
{
    public class UserRepository(IDbContextFactory<ApplicationDbContext> context) : GenericRepository<User>(context), IUserRepository
    {
        public async Task SaveChanges(User? userToEdit)
        {
            ArgumentNullException.ThrowIfNull(userToEdit);
            if (await AnyAsync(x => x.Id == userToEdit.Id))
            {
                await UpdateAsync(userToEdit);
            }
            else
            {
                await CreateAsync(userToEdit);
            }
        }
    }
}