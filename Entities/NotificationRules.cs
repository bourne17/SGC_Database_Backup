using SGC_Database_Backup.Entities.Base;

namespace SGC_Database_Backup.Entities
{
    public class NotificationRules:EntityBase
    {
        public BackupsJobs? BackupsJobs { get; set; }
        public int? BackupsJobsId { get; set; }
        public bool OnSuccess { get; set; }
        public bool OnFailure { get; set; }
        public string Recipients { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set;} 
    }
}
