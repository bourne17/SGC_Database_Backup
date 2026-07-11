using SGC_Database_Backup.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace SGC_Database_Backup.Entities
{
    public class Schedules:EntityBase
    {
        public BackupsJobs? BackupsJobs { get; set; }
        public int? BackupsJobsId { get; set; }
        public ScheduleFrecuency? Frecuency { get; set; }
        public int? FrecuencyId { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime? EndAt { get; set; }
        [MaxLength(100)]
        public string DayOfMonth { get; set; }
        public TimeOnly RunBetweenStart { get; set; }
        public TimeOnly RunBetweenEnd { get; set; }
        public bool IsRunMissed { get; set; }
        public DateTime NextRun { get; set;  }
        public DateTime LastRun { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}
