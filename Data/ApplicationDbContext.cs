using Microsoft.EntityFrameworkCore;
using SGC_Database_Backup.Data.Seeds;
using SGC_Database_Backup.Entities;


namespace SGC_Database_Backup.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Esto aplica los datos de la semilla a la tabla Users
            modelBuilder.ApplyConfiguration(new UserSeedConfiguration());
        }
    }
}