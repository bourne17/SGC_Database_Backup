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
                new BackupJobStatus { Id = 1, Description = "Running", CreatedAt = new DateTime(2026, 7, 11, 0, 0, 0), },
                new BackupJobStatus { Id = 2, Description = "Success", CreatedAt = new DateTime(2026, 7, 11, 0, 0, 0), },
                new BackupJobStatus { Id = 3, Description = "Error", CreatedAt = new DateTime(2026, 7, 11, 0, 0, 0), },
                new BackupJobStatus { Id = 4, Description = "Partial", CreatedAt = new DateTime(2026, 7, 11, 0, 0, 0), }
            );
        }
    }
}
