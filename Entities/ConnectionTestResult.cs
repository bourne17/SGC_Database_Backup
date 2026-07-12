namespace SGC_Database_Backup.Entities
{
    public class ConnectionTestResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public Exception Exception { get; set; } // opcional
    }
}
