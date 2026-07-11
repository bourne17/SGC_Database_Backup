using Microsoft.AspNetCore.Components;

namespace SGC_Database_Backup.Entities
{
    public class BackupsJobs:ComponentBase
    {
        public DatabaseConnections DbConnection { get; set; }
        public int? DbConnectionId { get; set; }
        public string DatabaseList { get; set; }
        public string ObjectToBackup { get; set; }
        public string BackupPath { get; set; }
        public Destination Destination { get; set; }
        public int? DestinationId { get; set; }
        public bool IsCompress { get; set; }
        public int RetentionDays { get; set; }
        public bool IsActive { get; set; }
        
    }
}
