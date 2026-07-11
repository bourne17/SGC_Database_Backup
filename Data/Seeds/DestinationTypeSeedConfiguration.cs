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
                    new DestinationType { Id = 1, Description = "Local" },
                    new DestinationType { Id = 2, Description = "Ftp" }
                );
        }
    }
}
