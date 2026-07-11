using Microsoft.AspNetCore.Components;
using SGC_Database_Backup.Entities.Base;

namespace SGC_Database_Backup.Entities
{
    public class DatabaseConnections:ComponenteBase
    {
       
        public TypeEngine TypeEngine { get; set; }
        public int? TypeEngineId { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Sid_Service { get; set; }
        public string DefaultDB { get; set; }
        public bool IsActive { get; set; }
     
        public bool IsEncrypt { get; set; }
        public bool TrustServerCertificate { get; set; }
    }
}
