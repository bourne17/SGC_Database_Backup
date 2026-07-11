using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGC_Database_Backup.Entities;

namespace SGC_Database_Backup.Data.Seeds
{
    public class BackupLogTypeSeedConfiguration : IEntityTypeConfiguration<BackupLogsType>
    {
        public void Configure(EntityTypeBuilder<BackupLogsType> builder)
        {
            builder.ToTable("BackupLogsTypes");
            builder.HasData(
                new BackupLogsType { Id = 1, Description = "Backup", CreatedAt = new DateTime(2026, 7, 11, 0, 0, 0), },
                new BackupLogsType { Id = 2, Description = "Restore", CreatedAt = new DateTime(2026, 7, 11, 0, 0, 0), }

            );
        }
    }
}