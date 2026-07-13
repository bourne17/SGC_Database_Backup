using Microsoft.EntityFrameworkCore;
using SGC_Database_Backup.Data;
using SGC_Database_Backup.Entities;
using SGC_Database_Backup.Repositories.BackupJobs;
using SGC_Database_Backup.Repositories.Generic;

namespace SGC_Database_Backup.Repositories.BackupRepository
{
    public class BackupJobRepository(IDbContextFactory<ApplicationDbContext> context) : GenericRepository<BackupsJobs>(context), IBackupJobRepository
    {
    }
}
