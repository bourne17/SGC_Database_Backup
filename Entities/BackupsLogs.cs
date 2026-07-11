using SGC_Database_Backup.Entities.Base;

namespace SGC_Database_Backup.Entities
{
    public class BackupsLogs:ComponenteBase
    {
        public BackupsJobs BackupsJob { get; set; }
        public int? BackuptJobId { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime FinishedAt { get; set; }
        public BackupJobStatus Status { get; set; }
        public int? StatusId { get; set; }
        public string FilePath { get; set; }
        public decimal FileSizeMb { get; set; }
        public string Details { get; set; }
        public string ErrorMessage { get; set; }
        public BackupLogsType Type { get; set; }
        public int? TypeId { get; set; } 
        public User User { get; set; }
        public int? UserId { get; set; }

    }
}
