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
                    new ScheduleFrecuency { Id = 1, Description = "Once", CreatedAt = new DateTime(2026, 7, 11, 0, 0, 0), },
                    new ScheduleFrecuency { Id = 2, Description = "Daily", CreatedAt = new DateTime(2026, 7, 11, 0, 0, 0), },
                    new ScheduleFrecuency { Id = 3, Description = "Weekly", CreatedAt = new DateTime(2026, 7, 11, 0, 0, 0), },
                    new ScheduleFrecuency { Id = 4, Description = "Monthly", CreatedAt = new DateTime(2026, 7, 11, 0, 0, 0), },
                    new ScheduleFrecuency { Id = 5, Description = "Yearly", CreatedAt = new DateTime(2026, 7, 11, 0, 0, 0), }

                );
        }
    }
}
