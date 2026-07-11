using Radzen;

namespace SGC_Database_Backup.Components.Extensions
{
    public static class NotificationExtensions
    {
        private const int DefaultDuration = 4000;

        // Método de extensión base
        public static void ShowAlert(this NotificationService service, NotificationSeverity severity, string summary, string detail, int duration = DefaultDuration)
        {
            service.Notify(new NotificationMessage
            {
                Severity = severity,
                Summary = summary,
                Detail = detail,
                Duration = duration
            });
        }

        // Atajos estáticos específicos
        public static void NotifySuccess(this NotificationService service, string summary, string detail)
        {
            service.ShowAlert(NotificationSeverity.Success, summary, detail);
        }

        public static void NotifyError(this NotificationService service, string summary, string detail)
        {
            service.ShowAlert(NotificationSeverity.Error, summary, detail);
        }

        public static void NotifyWarning(this NotificationService service, string summary, string detail)
        {
            service.ShowAlert(NotificationSeverity.Warning, summary, detail);
        }

        public static void NotifyInfo(this NotificationService service, string summary, string detail)
        {
            service.ShowAlert(NotificationSeverity.Info, summary, detail);
        }
    }
}