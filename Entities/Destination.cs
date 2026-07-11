using SGC_Database_Backup.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace SGC_Database_Backup.Entities
{
    public class Destination:ComponenteBase
    {
        public DestinationType DestinationType { get; set; }
        public int DestinationTypeId { get; set; }
        [MaxLength(300)]
        public string Path { get; set; }
        [MaxLength(100)]
        public string Host { get; set; }
        [MaxLength(100)]
        public string UserName { get; set; }
        
        public string Password { get; set; }
        public int Port { get; set; }
        [MaxLength(100)]
        public string Bucket { get; set; }
        public bool IsActive { get; set; }
    }
}
