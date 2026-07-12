using Microsoft.AspNetCore.Components;
using Radzen;
using SGC_Database_Backup.Components.Extensions;
using SGC_Database_Backup.Entities;
using SGC_Database_Backup.Repositories.Connections;

namespace SGC_Database_Backup.Components.Pages.Connections
{
    public partial class ConnectionManager
    {
        [Inject]
        private IDatabaseOptionsRepository DatabaseOptionService { get; set; }

        [Inject]
        private DialogService DialogService { get; set; }

        [Inject]
        private NotificationService NotificationService { get; set; }

        private IEnumerable<DatabaseOptions> databaseOptions { get; set; }
        private bool isLoading = false;

        protected override async Task OnInitializedAsync()
        {
            await LoadConnections();
        }

        private async Task LoadConnections()
        {
            try
            {
                isLoading = true;
                databaseOptions = await DatabaseOptionService.GetAllAsync();
            }
            finally
            {
                isLoading = false;
            }
        }

        private async Task EditConnection(int connectionId)
        {
            await DialogService.OpenAsync<AddEditConnection>("Editar conexión", new Dictionary<string, object?>
            {
                { "ConnectionId", connectionId },
                { "LoadConnections", EventCallback.Factory.Create(this, LoadConnections) }
            });
        }

        private async Task AddConnection()
        {
            await DialogService.OpenAsync<AddEditConnection>("Agregar conexión", new Dictionary<string, object?>
            {
                { "LoadConnections", EventCallback.Factory.Create(this, LoadConnections) }
            });
        }

        public async Task TestConnection(DatabaseOptions options)
        {
            try
            {
                isLoading = true;
                var connection = await DatabaseOptionService.FindAsync(options.Id);
                var result = await DatabaseOptionService.TestConnectionAsync(connection);
                if (result.Success)
                {
                   NotificationExtensions.NotifySuccess(NotificationService,"Conexión exitosa", "La conexión a la base de datos fue exitosa.");
                }
                else
                {
                  NotificationExtensions.NotifyError(NotificationService, "Error de conexión", $"No se pudo conectar a la base de datos: {result.Message}");
                }
            }
            finally
            {
                isLoading = false;
            }
        }
    }
}
