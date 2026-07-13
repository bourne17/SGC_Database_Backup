using SGC_Database_Backup.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGC_Database_Backup.Entities
{
    public class Destination:ComponenteBase
    {
        public DestinationType? DestinationType { get; set; }
        public int DestinationTypeId { get; set; }
        [MaxLength(300)]
        public string Path { get; set; } = string.Empty;
        [MaxLength(100)]
        public string Host { get; set; } = string.Empty;
        [MaxLength(100)]
        public string UserName { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
        public int Port { get; set; }
        [MaxLength(100)]
        public string Bucket { get; set; } = string.Empty;
        public bool IsActive { get; set; }

        [NotMapped]
        public string DestinationTypeDescription { get; set; }=string.Empty;
    }
}
