using SGC_Database_Backup.Entities;

namespace SGC_Database_Backup.Services.Users
{
    public interface IUserService
    {
        public Task<IEnumerable<User>> GetAllAsync();
        public Task<User?> FindByIdAsync(int userId);
        Task SaveChanges(User? userToEdit);
    }
}
