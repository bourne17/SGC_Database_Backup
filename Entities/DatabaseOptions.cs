using SGC_Database_Backup.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace SGC_Database_Backup.Entities
{
    public class DatabaseOptions : ComponenteBase
    {
        public TypeEngine TypeEngine { get; set; }

        public int? TypeEngineId { get; set; }

        [MaxLength(300)]
        public string Host { get; set; }

        public int Port { get; set; }

        [MaxLength(100)]
        public string UserName { get; set; }

        public string Password { get; set; }

        [MaxLength(100)]
        public string Sid_Service { get; set; }

        [MaxLength(100)]
        public string DefaultDB { get; set; }

        public bool IsActive { get; set; }

        public bool IsEncrypt { get; set; }

        public bool TrustServerCertificate { get; set; }
    }
}