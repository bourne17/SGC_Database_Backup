using Microsoft.AspNetCore.Mvc.ModelBinding;
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
        public DbSet <BackupJobStatus> BackupJobStatuses { get; set; }
        public DbSet<DestinationType> DestinationTypes { get; set; }
        public DbSet<BackupLogsType> BackupLogsTypes { get; set; }
        public DbSet<ScheduleFrecuency> ScheduleFrecuencies { get; set; }
        public DbSet<TypeEngine> TypeEngines { get; set; }
        public DbSet<BackupsJobs> BackupsJobs { get; set; }
        public DbSet<BackupsLogs> BackupsLogs { get; set; }
        public DbSet<DatabaseOptions> DatabaseOptions { get; set; }
        public DbSet<Destination> Destination { get; set; }
        public DbSet<EmailConfiguration> EmailConfigurations { get; set; }
        public DbSet<NotificationRules> NotificationRules { get; set; }
        public DbSet<Schedules> Schedules { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Esto aplica los datos de la semilla a la tabla Users
            modelBuilder.ApplyConfiguration(new UserSeedConfiguration());
            modelBuilder.ApplyConfiguration(new BackupJobStatusSeedConfiguration());
            modelBuilder.ApplyConfiguration(new DestinationTypeSeedConfiguration());
            modelBuilder.ApplyConfiguration(new BackupLogTypeSeedConfiguration());
            modelBuilder.ApplyConfiguration(new ScheduleFrecuencySeedConfiguration());
            modelBuilder.ApplyConfiguration(new TypeEngineSeedConfiguration());
        }
    }
}