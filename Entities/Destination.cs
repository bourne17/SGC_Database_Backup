using SGC_Database_Backup.Entities.Base;

namespace SGC_Database_Backup.Entities
{
    public class Destination:ComponenteBase
    {
        public DestinationType DestinationType { get; set; }
        public int DestinationTypeId { get; set; }
        public string Path { get; set; }
        public string Host { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
        public string Bucket { get; set; }
        public bool IsActive { get; set; }
    }
}
