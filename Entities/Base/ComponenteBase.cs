using System.ComponentModel.DataAnnotations;

namespace SGC_Database_Backup.Entities.Base
{
    public class ComponenteBase:EntityBase
    {
        [MaxLength(100)]

        public string Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
