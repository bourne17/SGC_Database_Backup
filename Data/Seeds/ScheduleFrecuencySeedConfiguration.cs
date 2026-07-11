using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGC_Database_Backup.Entities;

namespace SGC_Database_Backup.Data.Seeds
{
    public class ScheduleFrecuencySeedConfiguration : IEntityTypeConfiguration<ScheduleFrecuency>
    {
        public void Configure(EntityTypeBuilder<ScheduleFrecuency> builder)
        {
            builder.ToTable("ScheduleFrecuency")
                .HasData(
                    new ScheduleFrecuency { Id = 1, Description = "Once" },
                    new ScheduleFrecuency { Id = 2, Description = "Daily" },
                    new ScheduleFrecuency { Id = 3, Description = "Weekly" },
                    new ScheduleFrecuency { Id = 4, Description = "Monthly" },
                    new ScheduleFrecuency { Id = 5, Description = "Yearly" }

                );
        }
    }
}
