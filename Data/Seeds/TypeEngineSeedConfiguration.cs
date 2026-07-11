using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGC_Database_Backup.Entities;

namespace SGC_Database_Backup.Data.Seeds
{
    public class TypeEngineSeedConfiguration : IEntityTypeConfiguration<TypeEngine>
    {
        public void Configure(EntityTypeBuilder<TypeEngine> builder)
        {
            builder.ToTable("TypeEngine");
            builder.HasData(
                new TypeEngine { Id = 1, Description = "MariaDb" , CreatedAt = new DateTime(2026, 7, 11, 0, 0, 0) },
                new TypeEngine { Id = 2, Description = "MySQL" , CreatedAt = new DateTime(2026, 7, 11, 0, 0, 0) },
                new TypeEngine { Id = 3, Description = "Oracle" , CreatedAt = new DateTime(2026, 7, 11, 0, 0, 0) },
                new TypeEngine { Id = 4, Description = "PostgreSQL" , CreatedAt = new DateTime(2026, 7, 11, 0, 0, 0) } ,
                new TypeEngine { Id = 5, Description = "SQL Server" , CreatedAt = new DateTime(2026, 7, 11, 0, 0, 0) },
                new TypeEngine { Id = 6, Description = "SQLite" , CreatedAt = new DateTime(2026, 7, 11, 0, 0, 0) },
                new TypeEngine { Id = 7, Description = "Firebird" , CreatedAt = new DateTime(2026, 7, 11, 0, 0, 0) }
            );
        }
    }
}
