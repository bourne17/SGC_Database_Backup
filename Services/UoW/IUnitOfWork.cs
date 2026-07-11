using SGC_Database_Backup.Repositories;

namespace SGC_Database_Backup.Services.UoW
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
    }
}
