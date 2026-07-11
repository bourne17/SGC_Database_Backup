using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGC_Database_Backup.Entities;

namespace SGC_Database_Backup.Data.Seeds
{
    public class TypEngineSeedConfiguration : IEntityTypeConfiguration<TypeEngine>
    {
        public void Configure(EntityTypeBuilder<TypeEngine> builder)
        {
            builder.ToTable("TypeEngine");
            builder.HasData(
                new TypeEngine { Id = 1, Description = "MariaDb" },
                new TypeEngine { Id = 2, Description = "MySQL" },
                new TypeEngine { Id = 3, Description = "Oracle" },
                new TypeEngine { Id = 4, Description = "PostgreSQL" } ,
                new TypeEngine { Id = 5, Description = "SQL Server" },
                new TypeEngine { Id = 6, Description = "SQLite" },
                new TypeEngine { Id = 7, Description = "Firebird" }
            );
        }
    }
}
