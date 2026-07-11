using System.ComponentModel.DataAnnotations;

namespace SGC_Database_Backup.Entities.Base
{
    public class EntityBase
    {
        [Key]
        public int Id { get; set; }
    }
}
