using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGC_Database_Backup.Entities;

namespace SGC_Database_Backup.Data.Seeds
{
    public class DestinationTypeSeedConfiguration : IEntityTypeConfiguration<DestinationType>
    {
        public void Configure(EntityTypeBuilder<DestinationType> builder)
        {
            builder.ToTable("DestinationTypes")
                .HasData(
                    new DestinationType { Id = 1, Description = "Local", CreatedAt = new DateTime(2026, 7, 11, 0, 0, 0), },
                    new DestinationType { Id = 2, Description = "Ftp", CreatedAt = new DateTime(2026, 7, 11, 0, 0, 0), }
                );
        }
    }
}
