using SGC_Database_Backup.Entities.Base;

namespace SGC_Database_Backup.Entities
{
    public class TypeEngine:ComponenteBase
    {
        public int DefaultPort { get; set; }
        public bool HasSqlOptions { get; set; }
    }
}
