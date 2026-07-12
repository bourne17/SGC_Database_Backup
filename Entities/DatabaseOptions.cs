using SGC_Database_Backup.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGC_Database_Backup.Entities
{
    public class DatabaseOptions : ComponenteBase
    {
        public TypeEngine TypeEngine { get; set; }

        public int? TypeEngineId { get; set; }

        [MaxLength(300)]
        public string Host { get; set; } = string.Empty;

        public int Port { get; set; }

        [MaxLength(100)]
        public string UserName { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        [MaxLength(100)]
        public string Sid_Service { get; set; } = string.Empty;

        [MaxLength(100)]
        public string DefaultDB { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;

        public bool IsEncrypt { get; set; } = false;

        public bool TrustServerCertificate { get; set; } = false;

        [NotMapped]
        public string TypeEngineDescription { get; set; } = string.Empty;
    }
}