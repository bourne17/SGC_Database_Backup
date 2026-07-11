using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGC_Database_Backup.Entities;

namespace SGC_Database_Backup.Data.Seeds
{
    public class BackupJobStatusSeedConfiguration : IEntityTypeConfiguration<BackupJobStatus>
    {
        public void Configure(EntityTypeBuilder<BackupJobStatus> builder)
        {
            builder.ToTable("BackupJobStatus");
            builder.HasData(
                new BackupJobStatus { Id = 1, Description = "Running" },
                new BackupJobStatus { Id = 2, Description = "Success" },
                new BackupJobStatus { Id = 3, Description = "Error" },
                new BackupJobStatus { Id = 4, Description = "Partial" }
            );
        }
    }
}
