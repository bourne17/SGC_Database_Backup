using SGC_Database_Backup.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGC_Database_Backup.Entities
{
    public class BackupsLogs : EntityBase
    {
        public BackupsJobs? BackupsJob { get; set; }

        public int? BackuptJobId { get; set; }

        [MaxLength(200)]
        public string BackupJobName { get; set; }

        public DateTime StartedAt { get; set; }

        public DateTime FinishedAt { get; set; }

        public BackupJobStatus? Status { get; set; }

        public int? StatusId { get; set; }

        [MaxLength(500)]
        public string FilePath { get; set; }

        [Column(TypeName = "decimal(19,2)")]
        public decimal FileSizeMb { get; set; }

        public string Details { get; set; }

        public string ErrorMessage { get; set; }

        public BackupLogsType? Type { get; set; }

        public int? TypeId { get; set; }

        public User? User { get; set; }

        public int? UserId { get; set; }
    }
}