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
                new BackupLogsType { Id = 1, Description = "Backup" },
                new BackupLogsType { Id = 2, Description = "Restore" }

            );
        }
    }
}