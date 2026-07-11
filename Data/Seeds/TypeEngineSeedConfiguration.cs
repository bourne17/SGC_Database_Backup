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
                new TypeEngine { Id = 1, Description = "MariaDb" ,DefaultPort=3306,HasSqlOptions=false, CreatedAt = new DateTime(2026, 7, 11, 0, 0, 0) },
                new TypeEngine { Id = 2, Description = "MySQL" ,DefaultPort=3306,HasSqlOptions=false, CreatedAt = new DateTime(2026, 7, 11, 0, 0, 0) },
                new TypeEngine { Id = 3, Description = "Oracle" ,DefaultPort=1521,HasSqlOptions=false, CreatedAt = new DateTime(2026, 7, 11, 0, 0, 0) },
                new TypeEngine { Id = 4, Description = "PostgreSQL" ,DefaultPort=5432,HasSqlOptions=false, CreatedAt = new DateTime(2026, 7, 11, 0, 0, 0) } ,
                new TypeEngine { Id = 5, Description = "SQL Server" ,DefaultPort=1433,HasSqlOptions=true, CreatedAt = new DateTime(2026, 7, 11, 0, 0, 0) },
                new TypeEngine { Id = 6, Description = "SQLite" ,DefaultPort=0,HasSqlOptions=false, CreatedAt = new DateTime(2026, 7, 11, 0, 0, 0) },
                new TypeEngine { Id = 7, Description = "Firebird" ,DefaultPort=3050,HasSqlOptions=false, CreatedAt = new DateTime(2026, 7, 11, 0, 0, 0) }
            );
        }
    }
}
